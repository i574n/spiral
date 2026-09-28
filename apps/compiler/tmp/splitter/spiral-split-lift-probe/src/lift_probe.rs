use spiral_split_lift::analyze_local_lifts;
use spiral_split_lift_funnel::trace_owner_funnel_symbol;
use spiral_split_model::{CompilerProfile, ReferenceMode, SplitPolicy};
use spiral_split_plan::plan_splits;
use spiral_split_scan::{refine_hopac_modules, scan_declarations};
use spiral_split_source::load_source;
use spiral_split_symbols::link_dependencies;
use std::env;
use std::path::Path;

fn parse_usize(value: &str, label: &str) -> Result<usize, String> {
    value
        .parse::<usize>()
        .map_err(|error| format!("invalid {label}: {error}"))
}

fn run(args: &[String]) -> Result<(), String> {
    if !(4..=6).contains(&args.len()) {
        return Err(
            "usage: spiral-split-lift-probe <source.fs> <owner-id> <local-index> <symbol> [max-lines] [threads]"
                .to_owned(),
        );
    }
    let source_path = Path::new(&args[0]);
    let owner_id = parse_usize(&args[1], "owner id")?;
    let local_index = parse_usize(&args[2], "local index")?;
    let symbol = &args[3];
    let max_lines = args
        .get(4)
        .map_or(Ok(1000), |value| parse_usize(value, "max lines"))?;
    let threads = args
        .get(5)
        .map_or_else(
            || std::thread::available_parallelism().map_or(1, |value| value.get()),
            |value| parse_usize(value, "threads").unwrap_or(1),
        )
        .max(1);
    if !(50..=1000).contains(&max_lines) {
        return Err("max lines must be between 50 and 1000".to_owned());
    }
    rayon::ThreadPoolBuilder::new()
        .num_threads(threads)
        .thread_name(|index| format!("spiral-lift-probe-{index:02}"))
        .build_global()
        .map_err(|error| format!("configure Rayon: {error}"))?;

    let source = load_source(source_path)?;
    let profile = source.profile;
    let scanned = refine_hopac_modules(scan_declarations(source)?, max_lines)?;
    let linked = link_dependencies(scanned);
    let policy = match profile {
        CompilerProfile::Hopac => SplitPolicy::ModuleAware { max_lines },
        _ => SplitPolicy::Declaration,
    };
    let plan = plan_splits(linked, policy, ReferenceMode::Closure);
    let local = analyze_local_lifts(&plan);
    let owner = plan
        .declarations
        .get(owner_id)
        .ok_or_else(|| format!("owner not found: {owner_id}"))?;
    let parent = local
        .groups
        .iter()
        .find(|group| group.owner.0 == owner_id && group.local_index == local_index)
        .ok_or_else(|| {
            format!("local group not found: owner={owner_id} local-index={local_index}")
        })?;
    let trace = trace_owner_funnel_symbol(owner, parent, max_lines, symbol)
        .map_err(|error| format!("funnel trace blocked: {error}"))?;
    println!(
        "owner\t{}\tlocal_index\t{}\tsymbol\t{}\tselected\t{}",
        trace.owner.0,
        trace.parent_local_index,
        trace.symbol,
        trace
            .selected
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(",")
    );
    print!("{}", trace.render_tsv());
    Ok(())
}

fn main() {
    let args = env::args().skip(1).collect::<Vec<_>>();
    if let Err(error) = run(&args) {
        eprintln!("spiral-split-lift-probe error: {error}");
        std::process::exit(2);
    }
}
