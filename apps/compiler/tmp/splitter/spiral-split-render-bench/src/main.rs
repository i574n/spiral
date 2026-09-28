use spiral_split_anonymous_boundary::{render_boundary_rewrite_tsv, rewrite_gear_boundaries};
use spiral_split_contextual_constructor::{
    render_contextual_constructor_tsv, rewrite_contextual_constructors,
};
use spiral_split_emit::FusedRenderIndex;
use spiral_split_gear_bridge::rewrite_anonymous_record_bridges;
use spiral_split_gear_scc::condense_compile_sccs;
use spiral_split_gears::{GearEmitOptions, GearPolicy, emit_gears, plan_gears};
use spiral_split_model::{CompilerProfile, ReferenceMode, SplitPlan, SplitPolicy};
use spiral_split_plan::plan_splits;
use spiral_split_scan::{refine_hopac_modules, scan_declarations};
use spiral_split_source::load_source;
use spiral_split_symbols::link_dependencies;
use spiral_split_union_context::{
    analyze_union_context, qualify_ambiguous_union_branches_scoped,
    qualify_duplicate_union_type_annotations_scoped, qualify_typed_union_comparisons,
};
use std::env;
use std::fs;
use std::path::{Path, PathBuf};
use std::time::Instant;

fn plan(path: &Path, max_lines: usize) -> Result<SplitPlan, String> {
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

fn usage() -> &'static str {
    "usage: spiral-split-render-bench <source.fs> <shard-id> [output.fs] [max-lines]\n       spiral-split-render-bench --boundary <source.fs> <generated-dir> <assembly-root>\n       spiral-split-render-bench --contextual <source.fs> <generated-dir>\n       spiral-split-render-bench --fused-profile <source.fs>\n       spiral-split-render-bench --union-profile <source.fs> <shard-id>"
}

fn fused_profile(source: &Path) -> Result<(), String> {
    let plan_started = Instant::now();
    let plan = plan(source, 1000)?;
    let sccs = condense_compile_sccs(&plan)?;
    let plan_ms = plan_started.elapsed().as_secs_f64() * 1000.0;
    let index_started = Instant::now();
    let index = FusedRenderIndex::build(&plan);
    let index_ms = index_started.elapsed().as_secs_f64() * 1000.0;
    println!("metric\tvalue");
    println!("plan_ms\t{plan_ms:.3}");
    println!("index_ms\t{index_ms:.3}");
    let mut total_ms = 0.0;
    let mut groups = 0usize;
    for component in sccs
        .components
        .iter()
        .filter(|component| component.cyclic && component.shards.len() > 1)
    {
        let started = Instant::now();
        let (_, rendered) = index.render(&plan, &component.shards)?;
        let elapsed_ms = started.elapsed().as_secs_f64() * 1000.0;
        total_ms += elapsed_ms;
        groups += 1;
        println!(
            "component\t{}\tshards={}\tbytes={}\telapsed_ms={elapsed_ms:.3}",
            component.id,
            component.shards.len(),
            rendered.len()
        );
    }
    println!("cyclic_groups\t{groups}");
    println!("cyclic_render_ms\t{total_ms:.3}");
    Ok(())
}

fn boundary_run(source: &Path, output: &Path, assembly_root: &Path) -> Result<(), String> {
    let started = Instant::now();
    let plan = plan(source, 1000)?;
    let gears = plan_gears(&plan, GearPolicy::default())?;
    let bridge = rewrite_anonymous_record_bridges(&plan, output)?;
    let dependencies = gears
        .gears
        .iter()
        .map(|gear| gear.dependencies.clone())
        .collect::<Vec<_>>();
    let report = rewrite_gear_boundaries(output, &gears.shard_to_gear, &dependencies)?;
    let _ = emit_gears(
        &plan,
        gears,
        &GearEmitOptions {
            output_root: output.to_path_buf(),
            assembly_root: assembly_root.to_path_buf(),
            assembly_overlay_root: None,
        },
    )?;
    println!("metric\tvalue");
    println!("bridge_annotated\t{}", bridge.annotations.len());
    println!("files_scanned\t{}", report.files_scanned);
    println!("files_changed\t{}", report.files_changed);
    println!("update_rebuilds\t{}", report.update_rebuilds);
    println!("higher_order_rebuilds\t{}", report.higher_order_rebuilds);
    println!(
        "elapsed_ms\t{:.3}",
        started.elapsed().as_secs_f64() * 1000.0
    );
    print!("{}", render_boundary_rewrite_tsv(&report));
    Ok(())
}

fn contextual_run(source: &Path, output: &Path) -> Result<(), String> {
    let started = Instant::now();
    let plan = plan(source, 1000)?;
    let gears = plan_gears(&plan, GearPolicy::default())?;
    let dependencies = gears
        .gears
        .iter()
        .map(|gear| gear.dependencies.clone())
        .collect::<Vec<_>>();
    let report = rewrite_contextual_constructors(output, &gears.shard_to_gear, &dependencies)?;
    println!("metric\tvalue");
    println!("files_scanned\t{}", report.files_scanned);
    println!("files_changed\t{}", report.files_changed);
    println!("adapters\t{}", report.adapters);
    println!(
        "elapsed_ms\t{:.3}",
        started.elapsed().as_secs_f64() * 1000.0
    );
    print!("{}", render_contextual_constructor_tsv(&report));
    Ok(())
}

fn union_profile(source: &Path, shard_id: usize) -> Result<(), String> {
    let plan = plan(source, 1000)?;
    let shard = plan
        .shards
        .get(shard_id)
        .ok_or_else(|| format!("shard {shard_id} is outside 0..{}", plan.shards.len()))?;
    let declaration_id = shard
        .declarations
        .first()
        .ok_or_else(|| format!("shard {shard_id} has no declarations"))?;
    let declaration = &plan.declarations[declaration_id.0];
    let union_context = analyze_union_context(&plan);
    let provider_order = shard
        .compile_dependencies
        .iter()
        .copied()
        .collect::<Vec<_>>();
    let module_name = |provider: usize| format!("spiral_compiler_Part{provider:04}");

    let duplicate_started = Instant::now();
    let duplicate = qualify_duplicate_union_type_annotations_scoped(
        &declaration.text,
        &union_context,
        shard.id,
        &shard.compile_dependencies,
        declaration.scope.module_name(),
        module_name,
    );
    let duplicate_ms = duplicate_started.elapsed().as_secs_f64() * 1000.0;

    let ambiguous_started = Instant::now();
    let ambiguous = qualify_ambiguous_union_branches_scoped(
        &duplicate,
        &union_context,
        shard.id,
        &shard.compile_dependencies,
        &provider_order,
        declaration.scope.module_name(),
        module_name,
    );
    let ambiguous_ms = ambiguous_started.elapsed().as_secs_f64() * 1000.0;

    let typed_started = Instant::now();
    let typed = qualify_typed_union_comparisons(
        &ambiguous,
        &union_context,
        &shard.compile_dependencies,
        module_name,
    );
    let typed_ms = typed_started.elapsed().as_secs_f64() * 1000.0;

    println!("metric\tvalue");
    println!("shard\t{shard_id}");
    println!("declaration\t{}", declaration_id.0);
    println!("source_lines\t{}", declaration.line_count());
    println!("compile_dependencies\t{}", shard.compile_dependencies.len());
    println!("duplicate_ms\t{duplicate_ms:.3}");
    println!("ambiguous_ms\t{ambiguous_ms:.3}");
    println!("typed_ms\t{typed_ms:.3}");
    println!("output_bytes\t{}", typed.len());
    Ok(())
}

fn run() -> Result<(), String> {
    let args = env::args().skip(1).collect::<Vec<_>>();
    if args.first().map(String::as_str) == Some("--union-profile") {
        if args.len() != 3 {
            return Err(usage().to_owned());
        }
        let shard = args[2]
            .parse::<usize>()
            .map_err(|error| format!("invalid shard id: {error}"))?;
        return union_profile(Path::new(&args[1]), shard);
    }
    if args.first().map(String::as_str) == Some("--fused-profile") {
        if args.len() != 2 {
            return Err(usage().to_owned());
        }
        return fused_profile(Path::new(&args[1]));
    }
    if args.first().map(String::as_str) == Some("--contextual") {
        if args.len() != 3 {
            return Err(usage().to_owned());
        }
        return contextual_run(Path::new(&args[1]), Path::new(&args[2]));
    }
    if args.first().map(String::as_str) == Some("--boundary") {
        if args.len() != 4 {
            return Err(usage().to_owned());
        }
        return boundary_run(
            Path::new(&args[1]),
            Path::new(&args[2]),
            Path::new(&args[3]),
        );
    }
    if !(2..=4).contains(&args.len()) {
        return Err(usage().to_owned());
    }
    let source = PathBuf::from(&args[0]);
    let shard = args[1]
        .parse::<usize>()
        .map_err(|error| format!("invalid shard id: {error}"))?;
    let output = args.get(2).map(PathBuf::from);
    let max_lines = args.get(3).map_or(Ok(1000usize), |value| {
        value
            .parse::<usize>()
            .map_err(|error| format!("invalid max-lines: {error}"))
    })?;
    if !(50..=1000).contains(&max_lines) {
        return Err("max-lines must be between 50 and 1000".to_owned());
    }

    let plan_started = Instant::now();
    let plan = plan(&source, max_lines)?;
    let plan_elapsed = plan_started.elapsed();
    if shard >= plan.shards.len() {
        return Err(format!("shard {shard} is outside 0..{}", plan.shards.len()));
    }

    let index_started = Instant::now();
    let index = FusedRenderIndex::build(&plan);
    let index_elapsed = index_started.elapsed();
    let render_started = Instant::now();
    let representative = shard;
    let rendered = index.render_single(&plan, shard)?;
    let render_elapsed = render_started.elapsed();
    if let Some(path) = output {
        fs::write(&path, rendered.as_bytes())
            .map_err(|error| format!("write {}: {error}", path.display()))?;
    }

    println!("metric\tvalue");
    println!("shard\t{shard}");
    println!("representative\t{representative}");
    println!("declarations\t{}", plan.shards[shard].declarations.len());
    println!("source_lines\t{}", plan.shards[shard].line_count);
    println!("rendered_bytes\t{}", rendered.len());
    println!("plan_ms\t{:.3}", plan_elapsed.as_secs_f64() * 1000.0);
    println!("index_ms\t{:.3}", index_elapsed.as_secs_f64() * 1000.0);
    println!("companions\t{}", index.companion_count());
    println!("render_ms\t{:.3}", render_elapsed.as_secs_f64() * 1000.0);
    Ok(())
}

fn main() {
    if let Err(error) = run() {
        eprintln!("{error}");
        std::process::exit(1);
    }
}
