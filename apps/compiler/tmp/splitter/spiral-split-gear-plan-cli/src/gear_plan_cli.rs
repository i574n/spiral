use rayon::ThreadPoolBuilder;
use spiral_split_critical_path_witness::{compute_critical_path, render_critical_path_tsv};
use spiral_split_gear_policy_search::{render_policy_search_tsv, select_policy_from_emitted};
use spiral_split_gears::{GearEmitOptions, emit_gears, render_gear_metrics_tsv};
use spiral_split_model::{CompilerProfile, ReferenceMode, SplitPlan, SplitPolicy};
use spiral_split_plan::plan_splits;
use spiral_split_scan::{refine_hopac_modules, scan_declarations};
use spiral_split_source::load_source;
use spiral_split_symbols::link_dependencies;
use std::env;
use std::path::{Path, PathBuf};
use std::time::Instant;

#[derive(Debug, Clone, PartialEq, Eq)]
struct Options {
    source: PathBuf,
    emitted: PathBuf,
    max_lines: usize,
    threads: usize,
    emit_gears: bool,
    assembly_root: Option<PathBuf>,
}

fn usage() -> &'static str {
    "usage: spiral-gear-plan <source.fs> <emitted-dir> [--max-lines N] [--threads N] [--emit-gears --assembly-root DIR]"
}

fn parse_args(args: &[String]) -> Result<Options, String> {
    let mut positional = Vec::new();
    let mut max_lines = 1000usize;
    let mut threads = std::thread::available_parallelism().map_or(1, |value| value.get());
    let mut emit_gears = false;
    let mut assembly_root = None;
    let mut index = 0usize;
    while index < args.len() {
        match args[index].as_str() {
            "--max-lines" => {
                index += 1;
                max_lines = args
                    .get(index)
                    .ok_or_else(|| "missing value for --max-lines".to_owned())?
                    .parse::<usize>()
                    .map_err(|error| format!("invalid --max-lines: {error}"))?;
            }
            "--threads" => {
                index += 1;
                threads = args
                    .get(index)
                    .ok_or_else(|| "missing value for --threads".to_owned())?
                    .parse::<usize>()
                    .map_err(|error| format!("invalid --threads: {error}"))?
                    .clamp(1, 256);
            }
            "--emit-gears" => emit_gears = true,
            "--assembly-root" => {
                index += 1;
                assembly_root =
                    Some(PathBuf::from(args.get(index).ok_or_else(|| {
                        "missing value for --assembly-root".to_owned()
                    })?));
            }
            "--help" | "-h" => return Err(usage().to_owned()),
            option if option.starts_with('-') => return Err(format!("unknown option: {option}")),
            path => positional.push(PathBuf::from(path)),
        }
        index += 1;
    }
    if positional.len() != 2 {
        return Err(usage().to_owned());
    }
    if !(50..=1000).contains(&max_lines) {
        return Err("--max-lines must be between 50 and 1000".to_owned());
    }
    Ok(Options {
        source: positional.remove(0),
        emitted: positional.remove(0),
        max_lines,
        threads,
        emit_gears,
        assembly_root,
    })
}

fn split_plan(path: &Path, max_lines: usize) -> Result<SplitPlan, String> {
    let source = load_source(path)?;
    let profile = source.profile;
    let scanned = refine_hopac_modules(scan_declarations(source)?, max_lines)?;
    let linked = link_dependencies(scanned);
    let policy = match profile {
        CompilerProfile::Hopac => SplitPolicy::ModuleAware { max_lines },
        _ => SplitPolicy::Declaration,
    };
    Ok(plan_splits(linked, policy, ReferenceMode::Closure))
}

fn run(args: &[String]) -> Result<(), String> {
    let options = parse_args(args)?;
    ThreadPoolBuilder::new()
        .num_threads(options.threads)
        .build_global()
        .map_err(|error| format!("configure rayon: {error}"))?;
    let started = Instant::now();
    let plan = split_plan(&options.source, options.max_lines)?;
    let selection = select_policy_from_emitted(&plan, &options.emitted)?;
    print!("{}", render_policy_search_tsv(&selection));
    let selected_family = selection.family.label();
    let gears = selection.plan;
    let metrics = selection.metrics;
    let critical_path = compute_critical_path(&gears.gears);
    print!("{}", render_critical_path_tsv(&critical_path));
    print!("{}", render_gear_metrics_tsv(&metrics));
    println!(
        "gear-plan-emitted=passed policy={} shards={} gears={} layers={} p95_lines={} max_lines={} critical_path_gears={} critical_path_lines={} cyclic_sccs={} max_scc_shards={} dag_parallelism={:.3} elapsed_ms={:.3}",
        selected_family,
        metrics.shards,
        metrics.gears,
        metrics.layers,
        metrics.p95_gear_lines,
        metrics.max_gear_lines,
        metrics.critical_path_gears,
        metrics.critical_path_lines,
        metrics.cyclic_sccs,
        metrics.max_scc_shards,
        metrics.dag_estimated_parallelism,
        started.elapsed().as_secs_f64() * 1000.0
    );
    if options.emit_gears {
        let assembly_root = options
            .assembly_root
            .clone()
            .ok_or_else(|| "--emit-gears requires --assembly-root DIR".to_owned())?;
        let (_, receipt) = emit_gears(
            &plan,
            gears,
            &GearEmitOptions {
                output_root: options.emitted.clone(),
                assembly_root,
                assembly_overlay_root: None,
            },
        )?;
        println!(
            "gear-emission=passed output={} files={} fingerprint={}",
            receipt.output_root.display(),
            receipt.files,
            receipt.source_fingerprint
        );
    }
    Ok(())
}

fn main() {
    let args = env::args().skip(1).collect::<Vec<_>>();
    if let Err(error) = run(&args) {
        eprintln!("spiral-gear-plan error: {error}");
        std::process::exit(2);
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn parse_defaults_and_thread_override() {
        let args = vec![
            "source.fs".to_owned(),
            "generated".to_owned(),
            "--threads".to_owned(),
            "56".to_owned(),
        ];
        let parsed = parse_args(&args).expect("parse options");
        assert_eq!(parsed.source, PathBuf::from("source.fs"));
        assert_eq!(parsed.emitted, PathBuf::from("generated"));
        assert_eq!(parsed.max_lines, 1000);
        assert_eq!(parsed.threads, 56);
    }

    #[test]
    fn rejects_out_of_range_line_cap() {
        let args = vec![
            "source.fs".to_owned(),
            "generated".to_owned(),
            "--max-lines".to_owned(),
            "1001".to_owned(),
        ];
        assert_eq!(
            parse_args(&args).expect_err("line cap should fail"),
            "--max-lines must be between 50 and 1000"
        );
    }
}
