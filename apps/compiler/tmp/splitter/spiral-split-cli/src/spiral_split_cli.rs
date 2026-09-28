use rayon::prelude::*;
use spiral_split_build::{BuildOptions, build_layers, build_targets};
use spiral_split_cross_stage_relink::{
    RelinkBlocker, promotions_from_edits, relink_promoted_captures,
};
use spiral_split_eligible_resume::{
    EligibleResumeState, load_or_initialize, resume_path, write_state,
};
use spiral_split_emit::{EmitOptions, emit_plan};
use spiral_split_gear_executor::{GearExecutionOptions, execute_gears};
use spiral_split_gear_hydration::{GearHydrationOptions, hydrate_matching_gears};
use spiral_split_gears::{
    GearEmitOptions, GearPolicy, emit_gears, measure_gears, plan_gears, plan_gears_from_emitted,
    render_gear_metrics_tsv,
};
use spiral_split_lift::{analyze_local_lifts, render_local_lift_summary, render_local_lift_tsv};
use spiral_split_lift_batch::{
    BatchBlocker, preflight_detached_call_uses, rewrite_owner_batch, splice_batch_owner,
};
use spiral_split_lift_funnel::{
    funnel_candidate_lines, rewrite_owner_funnel, rewrite_owner_terminal_match,
};
use spiral_split_lift_plan::{
    ParametricComponent, plan_parametric_lifts, render_parametric_summary, render_parametric_tsv,
};
use spiral_split_lift_rewrite::{rewrite_bounded_owner, splice_rewritten_owner};
use spiral_split_lift_transaction::prepare_transaction;
use spiral_split_loc::{measure_workspace_loc, render_loc_tsv, write_loc_report};
use spiral_split_match_branch::{
    BranchDisposition, analyze_match_branches, analyze_owner_bounded_match_branches,
    analyze_owner_match_branches, render_match_branch_tsv, rewrite_match_branches_with_annotations,
    rewrite_owner_bounded_match_branches_with_annotations,
    rewrite_owner_match_branches_with_annotations,
};
use spiral_split_match_owner::discover_match_owners;
use spiral_split_metrics::{
    PhaseReceipt, declaration_closure_critical_lines, declaration_critical_chain, measure,
    render_oversize_tsv, render_summary, render_tsv, shard_critical_chain,
};
use spiral_split_model::{CompilerProfile, ReferenceMode, SplitPlan, SplitPolicy, fnv1a64};
use spiral_split_plan::plan_splits;
use spiral_split_recursive_scc::{extract_recursive_scc, extract_recursive_scc_selective};
use spiral_split_restore_seed::seed_restore_assets;
use spiral_split_runtime_policy::{bounded_process_jobs, configure_parallel_runtime};
use spiral_split_scan::{refine_hopac_modules, scan_declarations};
use spiral_split_source::load_source;
use spiral_split_symbols::link_dependencies;
use spiral_split_value_body::{rewrite_value_body, rewrite_value_body_at_line, splice_value_body};
use std::collections::BTreeSet;
use std::env;
use std::fs;
use std::path::{Path, PathBuf};
use std::time::{Duration, Instant};

#[derive(Clone, Debug)]
struct CommonOptions {
    policy_name: String,
    max_lines: usize,
    reference_mode: ReferenceMode,
    threads: usize,
    cache_root: Option<PathBuf>,
    assembly_root: Option<PathBuf>,
    assembly_overlay_root: Option<PathBuf>,
    dotnet: PathBuf,
    through: Option<usize>,
    process_timeout: Duration,
    build_budget: Option<Duration>,
    build_reserve: Duration,
}

impl Default for CommonOptions {
    fn default() -> Self {
        Self {
            policy_name: "auto".to_owned(),
            max_lines: 1000,
            reference_mode: ReferenceMode::Closure,
            threads: std::thread::available_parallelism().map_or(1, |value| value.get()),
            cache_root: None,
            assembly_root: None,
            assembly_overlay_root: None,
            dotnet: PathBuf::from("dotnet"),
            through: None,
            process_timeout: Duration::from_secs(18),
            build_budget: Some(Duration::from_secs(28)),
            build_reserve: Duration::from_secs(5),
        }
    }
}

impl CommonOptions {
    fn policy_for(&self, profile: CompilerProfile) -> Result<SplitPolicy, String> {
        if !(50..=1000).contains(&self.max_lines) {
            return Err("--max-lines must be between 50 and 1000".to_owned());
        }
        match self.policy_name.as_str() {
            "auto" => match profile {
                CompilerProfile::Hopac => Ok(SplitPolicy::ModuleAware {
                    max_lines: self.max_lines,
                }),
                _ => Ok(SplitPolicy::Declaration),
            },
            "declaration" => Ok(SplitPolicy::Declaration),
            "bounded" => Ok(SplitPolicy::BoundedLines {
                max_lines: self.max_lines,
            }),
            "layered" => Ok(SplitPolicy::DependencyLayer {
                max_lines: self.max_lines,
            }),
            "module-aware" => Ok(SplitPolicy::ModuleAware {
                max_lines: self.max_lines,
            }),
            value => Err(format!("unknown policy: {value}")),
        }
    }
}

const USAGE: &str = r#"spiral-split: granular disposable F# compiler splitter

usage:
  spiral-split analyze <source.fs> [source.fs ...] [options]
  spiral-split emit <source.fs> <out-dir> [options]
  spiral-split gears <source.fs> <out-dir> [options]
  spiral-split gear-build <out-dir> [options]
  spiral-split gear-hydrate <source-out-dir> <out-dir> --through N [options]
  spiral-split verify <source.fs> <out-dir> [options]
  spiral-split seed-assets <out-dir> [options]
  spiral-split build <out-dir> [options]
  spiral-split build-target <out-dir> <shard-ids> [options]
  spiral-split loc <workspace-root> [options]
  spiral-split local-lift <source.fs> [source.fs ...] [options]
  spiral-split parametric-lift <source.fs> [source.fs ...] [options]
  spiral-split rewrite-owner <source.fs> <owner-id> <component-id> <out.fs> [options]
  spiral-split rewrite-owner-value-body <source.fs> <owner-id> <local-index|line:N> <out.fs> [options]
  spiral-split match-branches <source.fs> <owner-id|largest> <local-index|largest> [options]
  spiral-split rewrite-owner-branches <source.fs> <owner-id|largest> <local-index|largest> <branch-ids|largest[:N]> <out.fs> [options]
  spiral-split rewrite-owner-batch <source.fs> <owner-id|largest> <component-ids|eligible> <out.fs> [options]
  spiral-split rewrite-owner-terminal <source.fs> <owner-id|largest> <out.fs> [options]
  spiral-split rewrite-owner-funnel <source.fs> <owner-id|largest> <local-index|largest|largest-nested> <out.fs> [options]
  spiral-split rewrite-owner-recursive <source.fs> <owner-id> <component-id> <out.fs> [options]
  spiral-split bench <source.fs> [source.fs ...] [options]
  spiral-split chain <source.fs> [options]      line-weighted declaration critical chain
  spiral-split gear-bench <source.fs> [options] plan shards and gears only; report build shape

options:
  --policy auto|declaration|bounded|layered|module-aware
  --max-lines N                 hard planning cap, 50..1000
  --reference direct|closure    project-reference graph
  --threads N                   Rayon worker count
  --cache-root DIR              generated MSBuild cache root
  --assembly-root DIR           dependency DLL directory (default: SPIRAL_ASSEMBLY_ROOT, <cache>/lib)
  --assembly-overlay-root DIR   current assemblies overriding fallback by name
  --dotnet PATH                 dotnet executable for layered build
  --through N                   highest shard compiled by layered build
  --process-timeout-seconds N   per-gear/root timeout, default 18s
  --build-budget-seconds N      gear-build wall-clock transaction budget, default 28s
  --build-reserve-seconds N     reserve before transaction deadline, default 5s
"#;

fn usage() -> &'static str {
    USAGE
}

fn value(args: &[String], index: &mut usize, flag: &str) -> Result<String, String> {
    *index += 1;
    args.get(*index)
        .cloned()
        .ok_or_else(|| format!("missing value for {flag}"))
}

fn parse_common(args: &[String]) -> Result<(Vec<String>, CommonOptions), String> {
    let mut positional = Vec::new();
    let mut common = CommonOptions::default();
    let mut index = 0usize;
    while index < args.len() {
        match args[index].as_str() {
            "--policy" => common.policy_name = value(args, &mut index, "--policy")?,
            "--max-lines" => {
                common.max_lines = value(args, &mut index, "--max-lines")?
                    .parse()
                    .map_err(|error| format!("invalid --max-lines: {error}"))?;
            }
            "--reference" => {
                common.reference_mode = match value(args, &mut index, "--reference")?.as_str() {
                    "direct" => ReferenceMode::Direct,
                    "closure" => ReferenceMode::Closure,
                    other => return Err(format!("unknown reference mode: {other}")),
                };
            }
            "--threads" => {
                common.threads = value(args, &mut index, "--threads")?
                    .parse::<usize>()
                    .map_err(|error| format!("invalid --threads: {error}"))?
                    .clamp(1, 256);
            }
            "--cache-root" => {
                common.cache_root = Some(PathBuf::from(value(args, &mut index, "--cache-root")?))
            }
            "--assembly-root" => {
                common.assembly_root =
                    Some(PathBuf::from(value(args, &mut index, "--assembly-root")?));
            }
            "--assembly-overlay-root" => {
                common.assembly_overlay_root = Some(PathBuf::from(value(
                    args,
                    &mut index,
                    "--assembly-overlay-root",
                )?));
            }
            "--dotnet" => {
                common.dotnet = PathBuf::from(value(args, &mut index, "--dotnet")?);
            }
            "--through" => {
                common.through = Some(
                    value(args, &mut index, "--through")?
                        .parse::<usize>()
                        .map_err(|error| format!("invalid --through: {error}"))?,
                );
            }
            "--process-timeout-seconds" => {
                let seconds = value(args, &mut index, "--process-timeout-seconds")?
                    .parse::<u64>()
                    .map_err(|error| format!("invalid --process-timeout-seconds: {error}"))?;
                common.process_timeout = Duration::from_secs(seconds.clamp(1, 3600));
            }
            "--build-budget-seconds" => {
                let seconds = value(args, &mut index, "--build-budget-seconds")?
                    .parse::<u64>()
                    .map_err(|error| format!("invalid --build-budget-seconds: {error}"))?;
                common.build_budget = Some(Duration::from_secs(seconds.clamp(1, 86400)));
            }
            "--build-reserve-seconds" => {
                let seconds = value(args, &mut index, "--build-reserve-seconds")?
                    .parse::<u64>()
                    .map_err(|error| format!("invalid --build-reserve-seconds: {error}"))?;
                common.build_reserve = Duration::from_secs(seconds.min(3600));
            }
            "--help" | "-h" => return Err(usage().to_owned()),
            option if option.starts_with('-') => return Err(format!("unknown option: {option}")),
            path => positional.push(path.to_owned()),
        }
        index += 1;
    }
    Ok((positional, common))
}

fn pipeline(path: &Path, common: &CommonOptions) -> Result<SplitPlan, String> {
    let source = load_source(path)?;
    let profile = source.profile;
    let scanned = refine_hopac_modules(scan_declarations(source)?, common.max_lines)?;
    let linked = link_dependencies(scanned);
    Ok(plan_splits(
        linked,
        common.policy_for(profile)?,
        common.reference_mode,
    ))
}

/// A source-tree directory of prebuilt managed dependencies, used when it actually holds assemblies.
const ASSEMBLY_ROOTS: [&str; 1] = ["compiler/lib"];

fn has_assemblies(directory: &Path) -> bool {
    fs::read_dir(directory).is_ok_and(|entries| {
        entries.flatten().any(|entry| entry.path().extension().is_some_and(|extension| extension == "dll"))
    })
}

/// The flat dependency directory the compiler scripts build into the cache (`Get-SpiralLibDir`):
/// `SPIRAL_ASSEMBLY_ROOT`, else `<cache>/lib` with the same cache resolution as `scripts/env.ps1`.
fn cache_assembly_root() -> Option<PathBuf> {
    if let Some(root) = env::var_os("SPIRAL_ASSEMBLY_ROOT") {
        return Some(PathBuf::from(root));
    }
    let cache = env::var_os("SPIRAL_BIN_CACHE_DIR")
        .map(PathBuf::from)
        .or_else(|| env::var_os("LOCALAPPDATA").map(|base| PathBuf::from(base).join("spiral-bin")))
        .or_else(|| env::var_os("HOME").map(|home| PathBuf::from(home).join(".cache/spiral-bin")))?;
    let lib = cache.join("lib");
    has_assemblies(&lib).then_some(lib)
}

fn discover_assembly_root(source: &Path) -> PathBuf {
    // Emitted projects live elsewhere (the cache), so their HintPaths must be absolute: a relative
    // source path (`compiler/cores/hopac/spiral_compiler.fs`) used to yield `compiler/lib`, which
    // MSBuild then resolved against each generated project's own directory.
    let found = discover_assembly_root_relative(source);
    std::path::absolute(&found).unwrap_or(found)
}

fn discover_assembly_root_relative(source: &Path) -> PathBuf {
    if let Some(root) = cache_assembly_root() {
        return root;
    }
    for ancestor in source.ancestors() {
        for root in ASSEMBLY_ROOTS {
            let candidate = ancestor.join(root);
            if has_assemblies(&candidate) {
                return candidate;
            }
        }
    }
    if let Ok(current) = env::current_dir() {
        for ancestor in current.ancestors() {
            for root in ASSEMBLY_ROOTS {
                let candidate = ancestor.join(root);
                if has_assemblies(&candidate) {
                    return candidate;
                }
            }
        }
    }
    source
        .parent()
        .unwrap_or_else(|| Path::new("."))
        .to_path_buf()
}

fn analyze(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.is_empty() {
        return Err("analyze expects at least one source".to_owned());
    }
    for path in paths {
        let started = Instant::now();
        let plan = pipeline(Path::new(path), common)?;
        let metrics = measure(&plan);
        println!("{}", render_summary(&plan, &metrics));
        println!(
            "elapsed_ms\t{:.3}",
            started.elapsed().as_secs_f64() * 1000.0
        );
        print!("{}", render_tsv(&plan, &metrics));
        if metrics.oversize_shards > 0 {
            print!("{}", render_oversize_tsv(&plan));
        }
    }
    Ok(())
}

fn emit(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 2 {
        return Err("emit expects <source.fs> <out-dir>".to_owned());
    }
    let source = PathBuf::from(&paths[0]);
    let output = PathBuf::from(&paths[1]);
    let started = Instant::now();
    let plan = pipeline(&source, common)?;
    let options = EmitOptions {
        output_root: output.clone(),
        cache_root: common
            .cache_root
            .clone()
            .unwrap_or_else(|| output.join(".build-cache")),
        assembly_root: common
            .assembly_root
            .clone()
            .unwrap_or_else(|| discover_assembly_root(&source)),
        assembly_overlay_root: common.assembly_overlay_root.clone(),
    };
    let receipt = emit_plan(&plan, &options)?;
    let metrics = measure(&plan);
    let local = analyze_local_lifts(&plan);
    let parametric = plan_parametric_lifts(&local);
    fs::write(output.join("local-lift.tsv"), render_local_lift_tsv(&local))
        .map_err(|error| format!("write local-lift.tsv: {error}"))?;
    fs::write(
        output.join("parametric-lift.tsv"),
        render_parametric_tsv(&parametric),
    )
    .map_err(|error| format!("write parametric-lift.tsv: {error}"))?;
    println!("{}", render_summary(&plan, &metrics));
    println!("{}", render_local_lift_summary(&local));
    println!("{}", render_parametric_summary(&parametric));
    println!(
        "emit=passed output={} shards={} files={} fingerprint={} elapsed_ms={:.3}",
        receipt.output_root.display(),
        receipt.shards,
        receipt.files,
        receipt.source_fingerprint,
        started.elapsed().as_secs_f64() * 1000.0
    );
    Ok(())
}

fn gears(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 2 {
        return Err("gears expects <source.fs> <out-dir>".to_owned());
    }
    let source = PathBuf::from(&paths[0]);
    let output = PathBuf::from(&paths[1]);
    let started = Instant::now();
    let mut phases = PhaseReceipt::new(output.join("gears-phases.tsv"));
    phases.record("start")?;
    let plan = pipeline(&source, common)?;
    phases.record("pipeline")?;
    let assembly_root = common
        .assembly_root
        .clone()
        .unwrap_or_else(|| discover_assembly_root(&source));
    emit_plan(
        &plan,
        &EmitOptions {
            output_root: output.clone(),
            cache_root: common
                .cache_root
                .clone()
                .unwrap_or_else(|| output.join(".build-cache")),
            assembly_root: assembly_root.clone(),
            assembly_overlay_root: common.assembly_overlay_root.clone(),
        },
    )?;
    phases.record("emit_plan")?;
    let gear_plan = plan_gears_from_emitted(&plan, &output, GearPolicy::default())?;
    phases.record("plan_gears")?;
    let metrics = measure_gears(&plan, &gear_plan);
    phases.record("measure_gears")?;
    let (_, receipt) = emit_gears(
        &plan,
        gear_plan,
        &GearEmitOptions {
            output_root: output.clone(),
            assembly_root,
            assembly_overlay_root: common.assembly_overlay_root.clone(),
        },
    )?;
    phases.record("emit_gears")?;
    print!("{}", render_gear_metrics_tsv(&metrics));
    println!(
        "gears=passed output={} shards={} gears={} assemblies_removed={} layers={} widest_layer={} p95_lines={} max_lines={} gear_edges={} estimated_parallelism={:.3} files={} fingerprint={} elapsed_ms={:.3}",
        receipt.output_root.display(),
        metrics.shards,
        metrics.gears,
        metrics.assemblies_removed,
        metrics.layers,
        metrics.widest_layer,
        metrics.p95_gear_lines,
        metrics.max_gear_lines,
        metrics.gear_edges,
        metrics.estimated_parallelism,
        receipt.files,
        receipt.source_fingerprint,
        started.elapsed().as_secs_f64() * 1000.0
    );
    Ok(())
}

fn gear_build(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 1 {
        return Err("gear-build expects <out-dir>".to_owned());
    }
    let output_root = PathBuf::from(&paths[0]);
    let receipt = execute_gears(&GearExecutionOptions {
        output_root,
        dotnet: common.dotnet.clone(),
        configuration: "Release".to_owned(),
        jobs: bounded_process_jobs(common.threads),
        force: false,
        through: common.through,
        process_timeout: common.process_timeout,
        build_budget: common.build_budget,
        build_reserve: common.build_reserve,
    })?;
    println!(
        "gear-build={} gears={} layers={} completed={} completed_layers={} restore_seeded={} restore_reused={} restore_invoked={} restore_receipt={} passed={} skipped={} failed={} root_built={} root_skipped={} progress={} receipt={} elapsed_ms={:.3}",
        receipt.outcome.cli_status(),
        receipt.gears,
        receipt.layers,
        receipt.completed,
        receipt.completed_layers,
        receipt.restore_seeded,
        receipt.restore_reused,
        receipt.restore_invoked,
        receipt.restore_receipt.display(),
        receipt.passed,
        receipt.skipped,
        receipt.failed,
        receipt.root_built,
        receipt.root_skipped,
        receipt.progress.display(),
        receipt.receipt.display(),
        receipt.elapsed.as_secs_f64() * 1000.0,
    );
    Ok(())
}
fn gear_hydrate(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 2 {
        return Err("gear-hydrate expects <source-out-dir> <out-dir>".to_owned());
    }
    let through = common
        .through
        .ok_or_else(|| "gear-hydrate requires --through N".to_owned())?;
    let receipt = hydrate_matching_gears(&GearHydrationOptions {
        source_root: PathBuf::from(&paths[0]),
        output_root: PathBuf::from(&paths[1]),
        dotnet: common.dotnet.clone(),
        jobs: bounded_process_jobs(common.threads),
        through,
    })?;
    println!(
        "gear-hydrate=passed gears={} mismatched_gears={} copied_files={} restore_copied={} restore_reused={} receipt={}",
        receipt.gears,
        receipt.mismatched_gears,
        receipt.copied_files,
        receipt.restore_copied,
        receipt.restore_reused,
        receipt.receipt.display(),
    );
    Ok(())
}

fn verify_output(plan: &SplitPlan, output: &Path) -> Result<(), String> {
    let receipt_path = output.join("source.receipt.tsv");
    let receipt = fs::read_to_string(&receipt_path)
        .map_err(|error| format!("read {}: {error}", receipt_path.display()))?;
    let expected = format!("source_fingerprint\t{}", plan.source.fingerprint);
    if !receipt.lines().any(|line| line == expected) {
        return Err(format!("source receipt does not contain {expected}"));
    }
    let parts_path = output.join("parts.tsv");
    let parts = fs::read_to_string(&parts_path)
        .map_err(|error| format!("read {}: {error}", parts_path.display()))?;
    let part_rows = parts
        .lines()
        .skip(1)
        .filter(|line| !line.is_empty())
        .count();
    if part_rows != plan.shards.len() {
        return Err(format!(
            "parts row mismatch: expected {}, got {part_rows}",
            plan.shards.len()
        ));
    }
    plan.shards.par_iter().try_for_each(|shard| {
        let part = format!("Part{:04}", shard.id);
        for extension in ["fs", "fsproj"] {
            let path = output.join(format!("{part}.{extension}"));
            let metadata =
                fs::metadata(&path).map_err(|error| format!("stat {}: {error}", path.display()))?;
            if metadata.len() == 0 {
                return Err(format!("empty emitted file: {}", path.display()));
            }
        }
        Ok::<(), String>(())
    })?;
    Ok(())
}

fn verify(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 2 {
        return Err("verify expects <source.fs> <out-dir>".to_owned());
    }
    let plan = pipeline(Path::new(&paths[0]), common)?;
    verify_output(&plan, Path::new(&paths[1]))?;
    println!(
        "verify=passed source={} output={} fingerprint={} shards={}",
        paths[0],
        paths[1],
        plan.source.fingerprint,
        plan.shards.len()
    );
    Ok(())
}

fn seed_assets(paths: &[String]) -> Result<(), String> {
    if paths.len() != 1 {
        return Err("seed-assets expects <out-dir>".to_owned());
    }
    let output = Path::new(&paths[0]);
    let seeded = seed_restore_assets(output)?;
    println!(
        "seed-assets=passed output={} seeded_projects={seeded}",
        output.display()
    );
    Ok(())
}

fn build(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 1 {
        return Err("build expects <out-dir>".to_owned());
    }
    let receipt = build_layers(&BuildOptions {
        output_root: PathBuf::from(&paths[0]),
        dotnet: common.dotnet.clone(),
        through: common.through,
        configuration: "Release".to_owned(),
    })?;
    println!(
        "build=passed output={} layers={} attempted={} passed={} skipped={} failed={} through={} elapsed_ms={:.3} receipt={}",
        paths[0],
        receipt.layers,
        receipt.attempted,
        receipt.passed,
        receipt.skipped,
        receipt.failed,
        receipt.through,
        receipt.elapsed.as_secs_f64() * 1000.0,
        receipt.receipt.display(),
    );
    Ok(())
}

fn build_target(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.len() != 2 {
        return Err("build-target expects <out-dir> <shard-ids>".to_owned());
    }
    if common.through.is_some() {
        return Err("build-target does not accept --through".to_owned());
    }
    let targets = component_ids(&paths[1])?;
    let receipt = build_targets(
        &BuildOptions {
            output_root: PathBuf::from(&paths[0]),
            dotnet: common.dotnet.clone(),
            through: None,
            configuration: "Release".to_owned(),
        },
        &targets,
    )?;
    println!(
        "build-target=passed output={} targets={:?} selected={} fresh_boundaries={} edges_examined={} max_depth={} layers={} attempted={} passed={} skipped={} failed={} elapsed_ms={:.3} plan={} progress={} receipt={}",
        paths[0],
        receipt.targets,
        receipt.selected,
        receipt.fresh_boundaries,
        receipt.edges_examined,
        receipt.max_depth,
        receipt.build.layers,
        receipt.build.attempted,
        receipt.build.passed,
        receipt.build.skipped,
        receipt.build.failed,
        receipt.build.elapsed.as_secs_f64() * 1000.0,
        receipt.plan.display(),
        receipt.progress.display(),
        receipt.build.receipt.display(),
    );
    Ok(())
}

fn loc(paths: &[String]) -> Result<(), String> {
    if paths.len() != 1 {
        return Err("loc expects <workspace-root>".to_owned());
    }
    let root = Path::new(&paths[0]);
    let rows = measure_workspace_loc(root)?;
    let report = write_loc_report(root)?;
    print!("{}", render_loc_tsv(&rows));
    println!(
        "loc=passed root={} rows={} report={}",
        root.display(),
        rows.len(),
        report.display()
    );
    Ok(())
}

fn local_lift(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.is_empty() {
        return Err("local-lift expects at least one source".to_owned());
    }
    for path in paths {
        let started = Instant::now();
        let plan = pipeline(Path::new(path), common)?;
        let local = analyze_local_lifts(&plan);
        println!("source\t{}", path);
        println!("{}", render_local_lift_summary(&local));
        print!("{}", render_local_lift_tsv(&local));
        println!(
            "elapsed_ms\t{:.3}",
            started.elapsed().as_secs_f64() * 1000.0
        );
    }
    Ok(())
}

fn parametric_lift(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.is_empty() {
        return Err("parametric-lift expects at least one source".to_owned());
    }
    for path in paths {
        let started = Instant::now();
        let plan = pipeline(Path::new(path), common)?;
        let local = analyze_local_lifts(&plan);
        let parametric = plan_parametric_lifts(&local);
        println!("source\t{}", path);
        println!("{}", render_parametric_summary(&parametric));
        print!("{}", render_parametric_tsv(&parametric));
        println!(
            "elapsed_ms\t{:.3}",
            started.elapsed().as_secs_f64() * 1000.0
        );
    }
    Ok(())
}

fn component_ids(value: &str) -> Result<Vec<usize>, String> {
    let result = value
        .split(',')
        .filter(|part| !part.is_empty())
        .map(|part| {
            part.parse::<usize>()
                .map_err(|error| format!("invalid component id {part}: {error}"))
        })
        .collect::<Result<Vec<_>, _>>()?;
    if result.is_empty() {
        Err("component id list is empty".to_owned())
    } else {
        Ok(result)
    }
}

fn component_depends_on(
    components: &[ParametricComponent],
    candidate: usize,
    blocked: usize,
) -> bool {
    let mut stack = vec![candidate];
    let mut seen = Vec::new();
    while let Some(component_id) = stack.pop() {
        if component_id == blocked {
            return true;
        }
        if seen.contains(&component_id) {
            continue;
        }
        seen.push(component_id);
        if let Some(component) = components
            .iter()
            .find(|component| component.component == component_id)
        {
            stack.extend(component.dependencies.iter().copied());
        }
    }
    false
}

fn exclude_component_or_dependents(
    selected: &mut Vec<usize>,
    components: &[ParametricComponent],
    blocked: usize,
) -> usize {
    let before = selected.len();
    selected.retain(|candidate| !component_depends_on(components, *candidate, blocked));
    before - selected.len()
}

fn commit_empty_eligible_batch(
    source: &Path,
    output: &Path,
    path: &Path,
    state: &mut EligibleResumeState,
    blocked_component: Option<usize>,
) -> Result<(), String> {
    state.selected.clear();
    write_state(path, state, "complete", blocked_component)?;
    let parent = output
        .parent()
        .ok_or_else(|| format!("eligible output has no parent: {}", output.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = output.with_extension(format!("noop-{}", std::process::id()));
    fs::copy(source, &temporary).map_err(|error| {
        format!(
            "copy {} to {}: {error}",
            source.display(),
            temporary.display()
        )
    })?;
    if output.exists() {
        fs::remove_file(output).map_err(|error| format!("remove {}: {error}", output.display()))?;
    }
    fs::rename(&temporary, output)
        .map_err(|error| format!("commit {}: {error}", output.display()))?;
    Ok(())
}

fn rewrite_owner_terminal_command(args: &[String]) -> Result<(), String> {
    if args.len() < 3 {
        return Err(
            "rewrite-owner-terminal expects <source.fs> <owner-id|largest> <out.fs> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_selector = args[1].clone();
    let output = PathBuf::from(&args[2]);
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[3..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner-terminal accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let owner_id = if owner_selector == "largest" {
        plan.declarations
            .iter()
            .max_by_key(|declaration| declaration.text.lines().count())
            .map(|declaration| declaration.id.0)
            .ok_or_else(|| "cannot select largest owner from empty plan".to_owned())?
    } else {
        owner_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid owner id: {error}"))?
    };
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let mut source_text = plan.source.lines.join("\n");
    if plan.source.bytes > source_text.len() {
        source_text.push('\n');
    }
    let (artifact, rewritten) = rewrite_owner_terminal_match(&source_text, owner, common.max_lines)
        .map_err(|error| format!("terminal match rewrite blocked: {error}"))?;
    let owner_after = artifact.owner_text.lines().count();
    let owner_before = owner.text.lines().count();
    let committed = prepare_transaction(&owner.text, rewritten, output.clone(), &artifact)
        .map_err(|error| format!("transaction prepare blocked: {error}"))?
        .commit()
        .map_err(|error| format!("transaction commit blocked: {error}"))?;
    println!(
        "rewrite-owner-terminal=passed source={} owner={} output={} receipt={} owner_before={} owner_after={} components={} calls={} output_fingerprint={}",
        source.display(),
        owner_id,
        output.display(),
        committed.receipt.display(),
        owner_before,
        owner_after,
        artifact
            .components
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(","),
        artifact.rewritten_calls,
        committed.output_fingerprint
    );
    Ok(())
}

fn rewrite_owner_funnel_command(args: &[String]) -> Result<(), String> {
    if args.len() < 4 {
        return Err(
            "rewrite-owner-funnel expects <source.fs> <owner-id> <local-index> <out.fs> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_selector = args[1].clone();
    let local_selector = args[2].clone();
    let output = PathBuf::from(&args[3]);
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[4..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner-funnel accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let owner_id = if owner_selector == "largest" {
        plan.declarations
            .iter()
            .max_by_key(|declaration| declaration.text.lines().count())
            .map(|declaration| declaration.id.0)
            .ok_or_else(|| "cannot select largest owner from empty plan".to_owned())?
    } else {
        owner_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid owner id: {error}"))?
    };
    let local = analyze_local_lifts(&plan);
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let parent = if local_selector == "largest" {
        local
            .groups
            .iter()
            .filter(|group| group.owner.0 == owner_id)
            .max_by_key(|group| group.line_count)
            .ok_or_else(|| format!("owner {owner_id} has no local groups"))?
    } else if local_selector == "largest-nested" {
        local
            .groups
            .iter()
            .filter(|group| group.owner.0 == owner_id)
            .filter_map(|group| {
                funnel_candidate_lines(owner, group, common.max_lines)
                    .ok()
                    .map(|score| (score, group))
            })
            .max_by_key(|(score, group)| (*score, group.line_count))
            .map(|(_, group)| group)
            .ok_or_else(|| format!("owner {owner_id} has no funnelable local groups"))?
    } else {
        let local_index = local_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid local index: {error}"))?;
        local
            .groups
            .iter()
            .find(|group| group.owner.0 == owner_id && group.local_index == local_index)
            .ok_or_else(|| {
                format!("local group not found: owner={owner_id} local-index={local_index}")
            })?
    };
    let local_index = parent.local_index;
    let mut source_text = plan.source.lines.join("\n");
    if plan.source.bytes > source_text.len() {
        source_text.push('\n');
    }
    let artifact = rewrite_owner_funnel(&source_text, owner, parent, common.max_lines)
        .map_err(|error| format!("funnel rewrite blocked: {error}"))?;
    let committed = prepare_transaction(
        &owner.text,
        artifact.final_source.clone(),
        output.clone(),
        &artifact,
    )
    .map_err(|error| format!("transaction prepare blocked: {error}"))?
    .commit()
    .map_err(|error| format!("transaction commit blocked: {error}"))?;
    println!(
        "rewrite-owner-funnel=passed source={} owner={} local_index={} output={} receipt={} parent_before={} parent_after={} owner_before={} owner_after={} nested_components={} promoted_components={} calls={} output_fingerprint={}",
        source.display(),
        owner_id,
        local_index,
        output.display(),
        committed.receipt.display(),
        artifact.parent_lines_before,
        artifact.parent_lines_after,
        artifact.owner_lines_before,
        artifact.owner_lines_after,
        artifact
            .nested_selected
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(","),
        artifact
            .promoted_selected
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(","),
        artifact.rewritten_calls,
        committed.output_fingerprint,
    );
    Ok(())
}

fn select_owner_and_local(
    plan: &SplitPlan,
    owner_selector: &str,
    local_selector: &str,
) -> Result<
    (
        usize,
        usize,
        spiral_split_lift::LocalLiftPlan<spiral_split_lift::Classified>,
    ),
    String,
> {
    let owner_id = if owner_selector == "largest" {
        plan.declarations
            .iter()
            .max_by_key(|declaration| declaration.text.lines().count())
            .map(|declaration| declaration.id.0)
            .ok_or_else(|| "cannot select largest owner from empty plan".to_owned())?
    } else {
        owner_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid owner id: {error}"))?
    };
    let local = analyze_local_lifts(plan);
    let local_index = if matches!(local_selector, "owner" | "owner-bounded") {
        usize::MAX
    } else if local_selector == "largest" {
        local
            .groups
            .iter()
            .filter(|group| group.owner.0 == owner_id)
            .max_by_key(|group| group.line_count)
            .map(|group| group.local_index)
            .ok_or_else(|| format!("owner {owner_id} has no local groups"))?
    } else {
        let local_index = local_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid local index: {error}"))?;
        if !local
            .groups
            .iter()
            .any(|group| group.owner.0 == owner_id && group.local_index == local_index)
        {
            return Err(format!(
                "local group not found: owner={owner_id} local-index={local_index}"
            ));
        }
        local_index
    };
    Ok((owner_id, local_index, local))
}

fn match_branches_command(args: &[String]) -> Result<(), String> {
    if args.len() < 3 {
        return Err(
            "match-branches expects <source.fs> <owner-id|largest> <local-index|largest> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_selector = args[1].clone();
    let local_selector = args[2].clone();
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[3..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("match-branches accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("match-branches", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let (owner_id, local_index, local) =
        select_owner_and_local(&plan, &owner_selector, &local_selector)?;
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let parent = if local_index == usize::MAX {
        None
    } else {
        Some(
            local
                .groups
                .iter()
                .find(|group| group.owner.0 == owner_id && group.local_index == local_index)
                .ok_or_else(|| {
                    format!("local group not found: owner={owner_id} local-index={local_index}")
                })?,
        )
    };
    let branch_plan = match parent {
        Some(parent) => analyze_match_branches(owner, parent, &local.groups),
        None if local_selector == "owner-bounded" => {
            analyze_owner_bounded_match_branches(owner, &local.groups, common.max_lines)
        }
        None => analyze_owner_match_branches(owner, &local.groups),
    }
    .map_err(|error| format!("match branch analysis blocked: {error}"))?;
    println!("source\t{}", source.display());
    print!("{}", render_match_branch_tsv(&branch_plan));
    Ok(())
}

fn rewrite_owner_branches_command(args: &[String]) -> Result<(), String> {
    if args.len() < 5 {
        return Err("rewrite-owner-branches expects <source.fs> <owner-id|largest> <local-index|largest> <branch-ids|largest[:N]> <out.fs> [options]".to_owned());
    }
    let source = PathBuf::from(&args[0]);
    let owner_selector = args[1].clone();
    let local_selector = args[2].clone();
    let branch_selector = args[3].clone();
    let output = PathBuf::from(&args[4]);
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[5..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner-branches accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite-owner-branches", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let (owner_id, local_index, local) =
        select_owner_and_local(&plan, &owner_selector, &local_selector)?;
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let parent = if local_index == usize::MAX {
        None
    } else {
        Some(
            local
                .groups
                .iter()
                .find(|group| group.owner.0 == owner_id && group.local_index == local_index)
                .ok_or_else(|| {
                    format!("local group not found: owner={owner_id} local-index={local_index}")
                })?,
        )
    };
    let branch_plan = match parent {
        Some(parent) => analyze_match_branches(owner, parent, &local.groups),
        None if local_selector == "owner-bounded" => {
            analyze_owner_bounded_match_branches(owner, &local.groups, common.max_lines)
        }
        None => analyze_owner_match_branches(owner, &local.groups),
    }
    .map_err(|error| format!("match branch analysis blocked: {error}"))?;
    let selected = if branch_selector == "extractable" {
        branch_plan
            .branches
            .iter()
            .filter(|branch| matches!(branch.disposition, BranchDisposition::Extractable))
            .filter(|branch| {
                local_selector != "owner-bounded" || branch.line_count <= common.max_lines
            })
            .map(|branch| branch.ordinal)
            .collect::<Vec<_>>()
    } else if branch_selector == "largest" || branch_selector.starts_with("largest:") {
        let count = branch_selector
            .split_once(':')
            .map_or(Ok(1usize), |(_, value)| {
                value
                    .parse::<usize>()
                    .map_err(|error| format!("invalid largest branch count: {error}"))
            })?;
        if count == 0 {
            return Err("largest branch count must be positive".to_owned());
        }
        let mut extractable = branch_plan
            .branches
            .iter()
            .filter(|branch| matches!(branch.disposition, BranchDisposition::Extractable))
            .map(|branch| (branch.line_count, branch.ordinal))
            .collect::<Vec<_>>();
        extractable.sort_by_key(|(lines, ordinal)| (std::cmp::Reverse(*lines), *ordinal));
        let mut selected = extractable
            .into_iter()
            .take(count)
            .map(|(_, ordinal)| ordinal)
            .collect::<Vec<_>>();
        selected.sort_unstable();
        selected
    } else {
        let mut selected = branch_selector
            .split(',')
            .filter(|value| !value.is_empty())
            .map(|value| {
                value
                    .parse::<usize>()
                    .map_err(|error| format!("invalid branch id {value}: {error}"))
            })
            .collect::<Result<Vec<_>, _>>()?;
        selected.sort_unstable();
        selected.dedup();
        selected
    };
    let mut source_text = plan.source.lines.join("\n");
    if plan.source.bytes > source_text.len() {
        source_text.push('\n');
    }
    let owner_resolution =
        discover_match_owners(owner, &branch_plan.branches, &selected).resolve(&plan);
    let owner_annotations = owner_resolution.annotations();
    let annotated_branches = owner_resolution.annotated_branches();
    println!(
        "match-owner-diagnostic owner={} candidates={:?} resolutions={:?}",
        owner_id, owner_resolution.candidates, owner_resolution.resolutions
    );
    let artifact = match parent {
        Some(parent) => rewrite_match_branches_with_annotations(
            &source_text,
            owner,
            parent,
            &local.groups,
            &selected,
            &owner_annotations,
        ),
        None if local_selector == "owner-bounded" => {
            rewrite_owner_bounded_match_branches_with_annotations(
                &source_text,
                owner,
                &local.groups,
                common.max_lines,
                &selected,
                &owner_annotations,
            )
        }
        None => rewrite_owner_match_branches_with_annotations(
            &source_text,
            owner,
            &local.groups,
            &selected,
            &owner_annotations,
        ),
    }
    .map_err(|error| format!("match branch rewrite blocked: {error}"))?;
    let committed = prepare_transaction(
        &owner.text,
        artifact.final_source.clone(),
        output.clone(),
        &artifact,
    )
    .map_err(|error| format!("transaction prepare blocked: {error}"))?
    .commit()
    .map_err(|error| format!("transaction commit blocked: {error}"))?;
    let local_label = if local_index == usize::MAX {
        "owner".to_owned()
    } else {
        local_index.to_string()
    };
    println!(
        "rewrite-owner-branches=passed source={} owner={} local_index={} branches={} extracted_lines={} max_branch_lines={} helpers={} captures={} owner_annotations={} output={} receipt={} output_fingerprint={}",
        source.display(),
        owner_id,
        local_label,
        artifact
            .selected
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(","),
        artifact.extracted_lines,
        artifact.max_branch_lines,
        artifact.helper_count,
        artifact.capture_count,
        annotated_branches,
        output.display(),
        committed.receipt.display(),
        committed.output_fingerprint,
    );
    Ok(())
}

fn rewrite_owner_batch_command(args: &[String]) -> Result<(), String> {
    if args.len() < 4 {
        return Err(
            "rewrite-owner-batch expects <source.fs> <owner-id> <component-ids> <out.fs> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_selector = args[1].clone();
    let selector = args[2].clone();
    let output = PathBuf::from(&args[3]);
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[4..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner-batch accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let owner_id = if owner_selector == "largest" {
        plan.declarations
            .iter()
            .max_by_key(|declaration| declaration.text.lines().count())
            .map(|declaration| declaration.id.0)
            .ok_or_else(|| "cannot select largest owner from empty plan".to_owned())?
    } else {
        owner_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid owner id: {error}"))?
    };
    let local = analyze_local_lifts(&plan);
    let parametric = plan_parametric_lifts(&local);
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let mut resume = None;
    let mut selected = if selector == "eligible" {
        let ids = parametric
            .components
            .iter()
            .filter(|component| component.owner == owner.id && component.eligible())
            .map(|component| component.component)
            .collect::<Vec<_>>();
        if ids.is_empty() {
            return Err(format!("owner {owner_id} has no eligible components"));
        }
        let path = resume_path(&output);
        let state = load_or_initialize(&path, plan.source.fingerprint, owner_id, ids)?;
        if state.selected.is_empty() {
            let mut state = state;
            commit_empty_eligible_batch(&source, &output, &path, &mut state, None)?;
            println!(
                "rewrite-owner-batch=complete-empty source={} owner={} output={} resume={}",
                source.display(),
                owner_id,
                output.display(),
                path.display()
            );
            return Ok(());
        }
        let selected = state.selected.clone();
        resume = Some((path, state));
        selected
    } else {
        component_ids(&selector)?
    };
    if selector == "eligible" {
        let rejected =
            preflight_detached_call_uses(owner, &local.groups, &parametric.components, &selected)
                .map_err(|error| format!("eligible preflight blocked: {error}"))?;
        let mut removed = 0usize;
        for component in rejected {
            removed +=
                exclude_component_or_dependents(&mut selected, &parametric.components, component);
        }
        if selected.is_empty() {
            let (path, state) = resume
                .as_mut()
                .ok_or_else(|| "eligible resume state missing".to_owned())?;
            commit_empty_eligible_batch(&source, &output, path, state, None)?;
            println!(
                "rewrite-owner-batch=complete-empty source={} owner={} output={} resume={}",
                source.display(),
                owner_id,
                output.display(),
                path.display()
            );
            return Ok(());
        }
        if removed > 0 {
            let (path, state) = resume
                .as_mut()
                .ok_or_else(|| "eligible resume state missing".to_owned())?;
            state.selected = selected.clone();
            write_state(path, state, "preflight", None)?;
        }
    }
    let artifact = if selector == "eligible" {
        match rewrite_owner_batch(owner, &local.groups, &parametric.components, &selected) {
            Ok(artifact) => artifact,
            Err(
                BatchBlocker::Rewrite { component, .. }
                | BatchBlocker::LexicalImbalance { component, .. }
                | BatchBlocker::InvalidAdjustedSpan(component),
            ) => {
                let removed = exclude_component_or_dependents(
                    &mut selected,
                    &parametric.components,
                    component,
                );
                if removed == 0 {
                    return Err(format!(
                        "eligible batch could not exclude incompatible component {component}"
                    ));
                }
                if selected.is_empty() {
                    let (path, state) = resume
                        .as_mut()
                        .ok_or_else(|| "eligible resume state missing".to_owned())?;
                    commit_empty_eligible_batch(&source, &output, path, state, Some(component))?;
                    println!(
                        "rewrite-owner-batch=complete-empty source={} owner={} blocked_component={} removed={} output={} resume={}",
                        source.display(),
                        owner_id,
                        component,
                        removed,
                        output.display(),
                        path.display()
                    );
                    return Ok(());
                }
                let (path, state) = resume
                    .as_mut()
                    .ok_or_else(|| "eligible resume state missing".to_owned())?;
                state.selected = selected.clone();
                write_state(path, state, "yield", Some(component))?;
                println!(
                    "rewrite-owner-batch=yield source={} owner={} blocked_component={} removed={} remaining={} resume={}",
                    source.display(),
                    owner_id,
                    component,
                    removed,
                    selected.len(),
                    path.display()
                );
                return Ok(());
            }
            Err(BatchBlocker::DetachedCallUnowned(diagnostic)) => {
                let component = diagnostic.component;
                let removed = exclude_component_or_dependents(
                    &mut selected,
                    &parametric.components,
                    component,
                );
                if removed == 0 {
                    return Err(format!(
                        "eligible batch could not exclude detached-call component {component}"
                    ));
                }
                if selected.is_empty() {
                    let (path, state) = resume
                        .as_mut()
                        .ok_or_else(|| "eligible resume state missing".to_owned())?;
                    commit_empty_eligible_batch(&source, &output, path, state, Some(component))?;
                    println!(
                        "rewrite-owner-batch=complete-empty source={} owner={} blocked_component={} removed={} output={} resume={}",
                        source.display(),
                        owner_id,
                        component,
                        removed,
                        output.display(),
                        path.display()
                    );
                    return Ok(());
                }
                let (path, state) = resume
                    .as_mut()
                    .ok_or_else(|| "eligible resume state missing".to_owned())?;
                state.selected = selected.clone();
                write_state(path, state, "yield", Some(component))?;
                println!(
                    "rewrite-owner-batch=yield source={} owner={} blocked_component={} removed={} remaining={} resume={}",
                    source.display(),
                    owner_id,
                    component,
                    removed,
                    selected.len(),
                    path.display()
                );
                return Ok(());
            }
            Err(error) => return Err(format!("batch rewrite blocked: {error}")),
        }
    } else {
        rewrite_owner_batch(owner, &local.groups, &parametric.components, &selected)
            .map_err(|error| format!("batch rewrite blocked: {error}"))?
    };
    let mut source_text = plan.source.lines.join("\n");
    if plan.source.bytes > source_text.len() {
        source_text.push('\n');
    }
    let rewritten = splice_batch_owner(&source_text, owner, &artifact)
        .map_err(|error| format!("batch splice blocked: {error}"))?;
    let promotions = promotions_from_edits(&artifact.edits);
    let relinked = match relink_promoted_captures(&rewritten, &promotions) {
        Ok(relinked) => relinked,
        Err(error) if selector == "eligible" => {
            let Some((helper, promotion)) = error.exclusion_hint() else {
                return Err(format!("cross-stage relink blocked: {error}"));
            };
            let candidates = parametric
                .components
                .iter()
                .filter(|component| {
                    component.owner == owner.id
                        && selected.contains(&component.component)
                        && component.names.iter().any(|name| name == promotion)
                })
                .map(|component| component.component)
                .collect::<Vec<_>>();
            let [component] = candidates.as_slice() else {
                return Err(format!(
                    "cross-stage relink blocker could not map promotion to one selected component: helper={helper} promotion={promotion} blocker={error} candidates={}",
                    candidates
                        .iter()
                        .map(usize::to_string)
                        .collect::<Vec<_>>()
                        .join(",")
                ));
            };
            let component = *component;
            let removed =
                exclude_component_or_dependents(&mut selected, &parametric.components, component);
            if removed == 0 {
                return Err(format!(
                    "cross-stage relink blocker could not exclude component {component}: promotion={promotion}"
                ));
            }
            let (path, state) = resume
                .as_mut()
                .ok_or_else(|| "eligible resume state missing".to_owned())?;
            state.selected = selected.clone();
            if selected.is_empty() {
                commit_empty_eligible_batch(&source, &output, path, state, Some(component))?;
                println!(
                    "rewrite-owner-batch=complete-empty-cross-stage source={} owner={} blocked_component={} promotion={} blocker={} removed={} output={} resume={}",
                    source.display(),
                    owner_id,
                    component,
                    promotion,
                    error,
                    removed,
                    output.display(),
                    path.display()
                );
                return Ok(());
            }
            write_state(path, state, "yield", Some(component))?;
            println!(
                "rewrite-owner-batch=yield-cross-stage source={} owner={} blocked_component={} promotion={} helper={} blocker={} removed={} remaining={} resume={}",
                source.display(),
                owner_id,
                component,
                promotion,
                helper,
                error,
                removed,
                selected.len(),
                path.display()
            );
            return Ok(());
        }
        Err(error) => return Err(format!("cross-stage relink blocked: {error}")),
    };
    let relinked_helpers = relinked.rewritten_helpers();
    let relinked_body_calls = relinked.rewritten_body_calls();
    let removed_capture_arguments = relinked.removed_call_arguments();
    let committed = prepare_transaction(&owner.text, relinked.text, output.clone(), &artifact)
        .map_err(|error| format!("transaction prepare blocked: {error}"))?
        .commit()
        .map_err(|error| format!("transaction commit blocked: {error}"))?;
    if let Some((path, mut state)) = resume {
        state.selected = selected.clone();
        write_state(&path, &state, "complete", None)?;
    }
    println!(
        "rewrite-owner-batch=passed source={} owner={} components={} output={} receipt={} calls={} parameters={} relinked_helpers={} relinked_body_calls={} removed_capture_arguments={} output_fingerprint={}",
        source.display(),
        owner_id,
        artifact
            .components
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(","),
        output.display(),
        committed.receipt.display(),
        artifact.rewritten_calls,
        artifact.parameters.join(","),
        relinked_helpers,
        relinked_body_calls,
        removed_capture_arguments,
        committed.output_fingerprint
    );
    Ok(())
}

fn rewrite_owner_value_body_command(args: &[String]) -> Result<(), String> {
    if args.len() < 4 {
        return Err(
            "rewrite-owner-value-body expects <source.fs> <owner-id> <local-index> <out.fs> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_id = args[1]
        .parse::<usize>()
        .map_err(|error| format!("invalid owner id: {error}"))?;
    let local_selector = args[2].clone();
    let output = PathBuf::from(&args[3]);
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[4..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner-value-body accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite-owner-value-body", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let artifact = if let Some(line) = local_selector.strip_prefix("line:") {
        let absolute_line = line
            .parse::<usize>()
            .map_err(|error| format!("invalid value-body line: {error}"))?;
        rewrite_value_body_at_line(owner, absolute_line)
            .map_err(|error| format!("value-body rewrite blocked: {error}"))?
    } else {
        let local_index = local_selector
            .parse::<usize>()
            .map_err(|error| format!("invalid local index: {error}"))?;
        let local = analyze_local_lifts(&plan);
        let group = local
            .groups
            .iter()
            .find(|candidate| candidate.owner.0 == owner_id && candidate.local_index == local_index)
            .ok_or_else(|| {
                format!("value group not found: owner={owner_id} local_index={local_index}")
            })?;
        rewrite_value_body(owner, group)
            .map_err(|error| format!("value-body rewrite blocked: {error}"))?
    };
    let mut source_text = plan.source.lines.join("\n");
    if plan.source.bytes > source_text.len() {
        source_text.push('\n');
    }
    let rewritten = splice_value_body(&source_text, owner, &artifact)
        .map_err(|error| format!("value-body splice blocked: {error}"))?;
    if let Some(parent) = output.parent() {
        fs::create_dir_all(parent).map_err(|error| format!("create output parent: {error}"))?;
    }
    let temporary = output.with_extension("value-body.tmp");
    fs::write(&temporary, &rewritten).map_err(|error| format!("write value-body temp: {error}"))?;
    fs::rename(&temporary, &output)
        .map_err(|error| format!("commit value-body output: {error}"))?;
    let receipt = output.with_extension("value-body.tsv");
    let output_fingerprint = fnv1a64(rewritten.as_bytes());
    let mut receipt_text = artifact.render_receipt();
    receipt_text.push_str(&format!(
        "transaction\toutput={}\toutput_fingerprint={}\toutput_bytes={}\tstatus=committed\n",
        output.display(),
        output_fingerprint,
        rewritten.len()
    ));
    fs::write(&receipt, receipt_text)
        .map_err(|error| format!("write value-body receipt: {error}"))?;
    println!(
        "rewrite-owner-value-body=passed source={} owner={} local_index={} helper={} captures={} output={} receipt={} output_fingerprint={}",
        source.display(),
        owner_id,
        artifact.local_index,
        artifact.helper_name,
        artifact.captures.join(","),
        output.display(),
        receipt.display(),
        output_fingerprint
    );
    Ok(())
}

fn rewrite_owner_command(args: &[String]) -> Result<(), String> {
    if args.len() < 4 {
        return Err(
            "rewrite-owner expects <source.fs> <owner-id> <component-id> <out.fs> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_id = args[1]
        .parse::<usize>()
        .map_err(|error| format!("invalid owner id: {error}"))?;
    let component_id = args[2]
        .parse::<usize>()
        .map_err(|error| format!("invalid component id: {error}"))?;
    let output = PathBuf::from(&args[3]);
    let mut common_args = vec![args[0].clone()];
    common_args.extend_from_slice(&args[4..]);
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let local = analyze_local_lifts(&plan);
    let parametric = plan_parametric_lifts(&local);
    let component = parametric
        .components
        .iter()
        .find(|candidate| candidate.owner.0 == owner_id && candidate.component == component_id)
        .ok_or_else(|| format!("component not found: owner={owner_id} component={component_id}"))?;
    let group_index = *component
        .members
        .first()
        .ok_or_else(|| "component has no groups".to_owned())?;
    let group = local
        .groups
        .get(group_index)
        .ok_or_else(|| format!("group not found: {group_index}"))?;
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let artifact = rewrite_bounded_owner(owner, group_index, group, component)
        .map_err(|error| format!("rewrite blocked: {error}"))?;
    let mut source_text = plan.source.lines.join("\n");
    if plan.source.bytes > source_text.len() {
        source_text.push('\n');
    }
    let rewritten = splice_rewritten_owner(&source_text, owner, &artifact)
        .map_err(|error| format!("splice blocked: {error}"))?;
    let committed = prepare_transaction(&owner.text, rewritten, output.clone(), &artifact)
        .map_err(|error| format!("transaction prepare blocked: {error}"))?
        .commit()
        .map_err(|error| format!("transaction commit blocked: {error}"))?;
    let receipt = committed.receipt.clone();
    println!(
        "rewrite-owner=passed source={} owner={} component={} output={} receipt={} calls={} parameters={} output_fingerprint={}",
        source.display(),
        owner_id,
        component_id,
        output.display(),
        receipt.display(),
        artifact.rewritten_calls,
        artifact.parameters.join(","),
        committed.output_fingerprint
    );
    Ok(())
}

fn rewrite_owner_recursive_command(args: &[String]) -> Result<(), String> {
    if args.len() < 4 {
        return Err(
            "rewrite-owner-recursive expects <source.fs> <owner-id> <component-id> <out.fs> [options]"
                .to_owned(),
        );
    }
    let source = PathBuf::from(&args[0]);
    let owner_id = args[1]
        .parse::<usize>()
        .map_err(|error| format!("invalid owner id: {error}"))?;
    let component_id = args[2]
        .parse::<usize>()
        .map_err(|error| format!("invalid component id: {error}"))?;
    let output = PathBuf::from(&args[3]);
    let mut keep_members = BTreeSet::<String>::new();
    let mut common_args = vec![args[0].clone()];
    let mut index = 4usize;
    while index < args.len() {
        if args[index] == "--keep-member" {
            let name = args
                .get(index + 1)
                .ok_or_else(|| "--keep-member expects a member name".to_owned())?;
            if !keep_members.insert(name.clone()) {
                return Err(format!("duplicate --keep-member: {name}"));
            }
            index += 2;
        } else {
            common_args.push(args[index].clone());
            index += 1;
        }
    }
    let (paths, common) = parse_common(&common_args)?;
    if paths.len() != 1 {
        return Err("rewrite-owner-recursive accepts exactly one source".to_owned());
    }
    configure_parallel_runtime("rewrite-owner-recursive", common.threads)?;
    let plan = pipeline(&source, &common)?;
    let local = analyze_local_lifts(&plan);
    let parametric = plan_parametric_lifts(&local);
    let component = parametric
        .components
        .iter()
        .find(|candidate| candidate.owner.0 == owner_id && candidate.component == component_id)
        .ok_or_else(|| format!("component not found: owner={owner_id} component={component_id}"))?;
    let receipt = if keep_members.is_empty() {
        extract_recursive_scc(&plan, &local, component, &output)?
    } else {
        extract_recursive_scc_selective(&plan, &local, component, &keep_members, &output)?
    };
    println!(
        "rewrite-owner-recursive=passed source={} owner={} component={} members={} extracted_lines={} wrapper_lines={} max_impl_lines={} output={} receipt={} output_fingerprint={}",
        source.display(),
        receipt.owner,
        receipt.component,
        receipt.members,
        receipt.extracted_lines,
        receipt.wrapper_lines,
        receipt.max_impl_lines,
        receipt.output.display(),
        receipt.receipt.display(),
        receipt.output_fingerprint
    );
    Ok(())
}

fn bench(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    if paths.is_empty() {
        return Err("bench expects at least one source".to_owned());
    }
    let rows = paths
        .par_iter()
        .map(|path| {
            let started = Instant::now();
            let plan = pipeline(Path::new(path), common)?;
            let metrics = measure(&plan);
            Ok::<_, String>((path.clone(), plan, metrics, started.elapsed()))
        })
        .collect::<Result<Vec<_>, _>>()?;
    println!(
        "source\tprofile\tbytes\tlines\tdeclarations\tshards\tlayers\twidest\tp95_lines\tmax_lines\toversize\tdirect_edges\tcompile_edges\tdense_edges\tedge_reduction\testimated_parallelism\tcritical_path_lines\tdeclaration_critical_path_lines\twork_parallelism\telapsed_ms"
    );
    for (path, plan, metrics, elapsed) in rows {
        println!(
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{:.6}\t{:.3}\t{}\t{}\t{:.3}\t{:.3}",
            path,
            plan.source.profile,
            metrics.source_bytes,
            metrics.source_lines,
            metrics.declarations,
            metrics.shards,
            metrics.layers,
            metrics.widest_layer,
            metrics.p95_shard_lines,
            metrics.max_shard_lines,
            metrics.oversize_shards,
            metrics.direct_edges,
            metrics.compile_edges,
            metrics.dense_baseline_edges,
            metrics.edge_reduction_ratio,
            metrics.estimated_parallelism,
            metrics.critical_path_lines,
            metrics.declaration_critical_path_lines,
            metrics.work_parallelism,
            elapsed.as_secs_f64() * 1000.0,
        );
    }
    Ok(())
}

/// Plans shards and gears without emitting anything and reports the build-shape figures that decide
/// wall time: gear count, chain depth, and the critical path with a fixed per-project overhead
/// (`PROJECT_OVERHEAD_LINES`). Planning skips the emitted-bridge preplan, so identity fusions can
/// differ slightly from `gears`. Takes seconds instead of minutes, for iterating on packing.
fn gear_bench(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    use spiral_split_model::PROJECT_OVERHEAD_LINES;
    let path = paths.first().ok_or("gear-bench expects <source.fs>")?;
    let started = Instant::now();
    let plan = pipeline(Path::new(path), common)?;
    let split = measure(&plan);
    let gears = plan_gears(&plan, GearPolicy::default())?;
    let metrics = measure_gears(&plan, &gears);
    let mut finish = vec![0usize; gears.gears.len()];
    let mut depth = vec![0usize; gears.gears.len()];
    for gear in &gears.gears {
        let (ready, ready_depth) = gear
            .dependencies
            .iter()
            .map(|dependency| (finish[*dependency], depth[*dependency]))
            .max()
            .unwrap_or((0, 0));
        finish[gear.id] = ready + gear.lines + PROJECT_OVERHEAD_LINES;
        depth[gear.id] = ready_depth + 1;
    }
    let critical = finish.iter().copied().max().unwrap_or(0);
    let chain_depth = (0..finish.len())
        .max_by_key(|gear| finish[*gear])
        .map_or(0, |gear| depth[gear]);
    let total = gears
        .gears
        .iter()
        .map(|gear| gear.lines + PROJECT_OVERHEAD_LINES)
        .sum::<usize>();
    let monolith = plan.source.lines.len() + PROJECT_OVERHEAD_LINES;
    println!(
        "shards\t{}\tshard_critical_lines\t{}\tdeclaration_floor_lines\t{}\tgears\t{}\tgear_critical_lines\t{}\tchain_gears\t{}\tseries_unions\t{}\toverhead_critical\t{}\toverhead_total\t{}\twork_parallelism\t{:.2}\tspeedup_vs_monolith_unbounded\t{:.2}\telapsed_ms\t{:.0}",
        split.shards,
        split.critical_path_lines,
        split.declaration_critical_path_lines,
        metrics.gears,
        metrics.critical_path_lines,
        chain_depth,
        metrics.series_unions,
        critical,
        total,
        total as f64 / critical.max(1) as f64,
        monolith as f64 / critical.max(1) as f64,
        started.elapsed().as_secs_f64() * 1000.0
    );
    Ok(())
}

/// Prints the line-weighted declaration critical chain, first provider first, with the symbol that
/// links each declaration to its predecessor on the chain. False or avoidable links are where
/// parallelism is lost.
fn chain(paths: &[String], common: &CommonOptions) -> Result<(), String> {
    let path = paths.first().ok_or("chain expects <source.fs>")?;
    let plan = pipeline(Path::new(path), common)?;
    let (lines, chain) = declaration_critical_chain(&plan);
    println!(
        "declaration_critical_path_lines\t{lines}\tclosure_edge_critical_path_lines\t{}\tsource_lines\t{}\tchain_declarations\t{}",
        declaration_closure_critical_lines(&plan),
        plan.source.lines.len(),
        chain.len()
    );
    println!("position\tdeclaration\tstart_line\tlines\tlink_symbol\theading");
    let mut previous: Option<&spiral_split_model::Declaration<spiral_split_model::Linked>> = None;
    for (position, &index) in chain.iter().enumerate() {
        let declaration = &plan.declarations[index];
        let link = previous
            .and_then(|provider| {
                declaration
                    .witnesses
                    .iter()
                    .find(|witness| witness.provider == provider.id)
                    .map(|witness| witness.symbol.clone())
            })
            .unwrap_or_default();
        println!(
            "{position}\t{}\t{}\t{}\t{link}\t{}",
            declaration.id.0,
            declaration.span.start + 1,
            declaration.span.end.saturating_sub(declaration.span.start).max(1),
            declaration.heading.replace('\t', " ")
        );
        previous = Some(declaration);
    }
    let (shard_lines, shard_chain) = shard_critical_chain(&plan);
    println!("shard_critical_path_lines\t{shard_lines}\tchain_shards\t{}", shard_chain.len());
    println!("position\tshard\tlines\tdeclarations\tfirst_line\theading");
    for (position, &index) in shard_chain.iter().enumerate() {
        let shard = &plan.shards[index];
        let first = shard.declarations.first().map(|id| &plan.declarations[id.0]);
        println!(
            "{position}\t{}\t{}\t{}\t{}\t{}",
            shard.id,
            shard.line_count,
            shard.declarations.len(),
            first.map_or(0, |declaration| declaration.span.start + 1),
            first.map_or(String::new(), |declaration| declaration.heading.replace('\t', " "))
        );
    }
    Ok(())
}

fn run() -> Result<(), String> {
    let args = env::args().skip(1).collect::<Vec<_>>();
    if matches!(
        args.first().map(String::as_str),
        Some("help" | "--help" | "-h")
    ) {
        print!("{}", usage());
        return Ok(());
    }
    let command = args.first().ok_or_else(|| usage().to_owned())?;
    if command == "rewrite-owner-value-body" {
        return rewrite_owner_value_body_command(&args[1..]);
    }
    if command == "rewrite-owner" {
        return rewrite_owner_command(&args[1..]);
    }
    if command == "match-branches" {
        return match_branches_command(&args[1..]);
    }
    if command == "rewrite-owner-branches" {
        return rewrite_owner_branches_command(&args[1..]);
    }
    if command == "rewrite-owner-batch" {
        return rewrite_owner_batch_command(&args[1..]);
    }
    if command == "rewrite-owner-terminal" {
        return rewrite_owner_terminal_command(&args[1..]);
    }
    if command == "rewrite-owner-funnel" {
        return rewrite_owner_funnel_command(&args[1..]);
    }
    if command == "rewrite-owner-recursive" {
        return rewrite_owner_recursive_command(&args[1..]);
    }
    let (paths, common) = parse_common(&args[1..])?;
    configure_parallel_runtime(command, common.threads)?;
    match command.as_str() {
        "analyze" => analyze(&paths, &common),
        "emit" => emit(&paths, &common),
        "gears" => gears(&paths, &common),
        "gear-build" => gear_build(&paths, &common),
        "gear-hydrate" => gear_hydrate(&paths, &common),
        "verify" => verify(&paths, &common),
        "seed-assets" => seed_assets(&paths),
        "build" => build(&paths, &common),
        "build-target" => build_target(&paths, &common),
        "loc" => loc(&paths),
        "local-lift" => local_lift(&paths, &common),
        "parametric-lift" => parametric_lift(&paths, &common),
        "bench" => bench(&paths, &common),
        "chain" => chain(&paths, &common),
        "gear-bench" => gear_bench(&paths, &common),
        "help" => Err(usage().to_owned()),
        other => Err(format!("unknown command: {other}\n\n{}", usage())),
    }
}

fn main() {
    if let Err(error) = run() {
        eprintln!("spiral-split error: {error}");
        std::process::exit(2);
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn auto_policy_refines_only_hopac() {
        let options = CommonOptions::default();
        assert_eq!(
            options.policy_for(CompilerProfile::Hopac).expect("hopac"),
            SplitPolicy::ModuleAware { max_lines: 1000 }
        );
        assert_eq!(
            options
                .policy_for(CompilerProfile::PortableFork)
                .expect("portable"),
            SplitPolicy::Declaration
        );
        assert_eq!(
            options
                .policy_for(CompilerProfile::PreHopac)
                .expect("pre-hopac"),
            SplitPolicy::Declaration
        );
    }

    #[test]
    fn parses_component_batches() {
        assert_eq!(component_ids("4,2,9").expect("components"), vec![4, 2, 9]);
        assert!(component_ids("").is_err());
        assert!(component_ids("4,nope").is_err());
    }

    #[test]
    fn portable_lines_definition_reaches_tab_positions() {
        let source = PathBuf::from(env!("CARGO_MANIFEST_DIR")).join("../../../spiral_compiler.fs");
        let plan = pipeline(&source, &CommonOptions::default()).expect("portable pipeline");
        let provider = &plan.declarations[18];
        let record = &plan.declarations[88];
        let consumer = &plan.declarations[633];
        assert!(
            !record.definitions.contains("lines"),
            "record fields must remain namespaced: {:?}",
            record.definitions
        );
        assert!(
            provider.definitions.contains("lines"),
            "provider definitions: {:?}",
            provider.definitions
        );
        assert!(
            consumer.references.contains("lines"),
            "consumer references: {:?}",
            consumer.references
        );
        assert!(
            consumer.direct_dependencies.contains(&provider.id),
            "consumer dependencies: {:?}; witnesses: {:?}",
            consumer.direct_dependencies,
            consumer.witnesses
        );
    }

    #[test]
    fn portable_union_cases_and_same_named_types_keep_dependencies() {
        let source = PathBuf::from(env!("CARGO_MANIFEST_DIR")).join("../../../spiral_compiler.fs");
        let plan = pipeline(&source, &CommonOptions::default()).expect("portable pipeline");
        let parser_error = &plan.declarations[151];
        let string_consumer = &plan.declarations[183];
        assert!(parser_error.definitions.contains("ExpectedStringClose"));
        assert!(
            string_consumer
                .direct_dependencies
                .contains(&parser_error.id),
            "string-close witnesses: {:?}",
            string_consumer.witnesses
        );
        let parenthesis = &plan.declarations[91];
        let parenthesis_consumer = &plan.declarations[218];
        assert!(parenthesis.definitions.contains("Round"));
        assert!(
            parenthesis_consumer
                .direct_dependencies
                .contains(&parenthesis.id),
            "inline-union witnesses: {:?}",
            parenthesis_consumer.witnesses
        );
        let type_union = &plan.declarations[314];
        let type_consumer = &plan.declarations[345];
        assert!(type_union.definitions.contains("TyApply"));
        assert!(
            type_consumer.direct_dependencies.contains(&type_union.id),
            "TyApply provider definitions: {:?}; consumer definitions: {:?}; references: {:?}; witnesses: {:?}",
            type_union.definitions,
            type_consumer.definitions,
            type_consumer.references,
            type_consumer.witnesses
        );
        let traced_type = &plan.declarations[698];
        let traced_union = &plan.declarations[729];
        assert!(traced_type.definitions.contains("TracedError"));
        assert!(traced_union.references.contains("TracedError"));
        assert!(
            traced_union.direct_dependencies.contains(&traced_type.id),
            "same-name type/constructor witnesses: {:?}",
            traced_union.witnesses
        );
    }
}
