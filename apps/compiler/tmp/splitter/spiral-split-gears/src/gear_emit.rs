fn atomic_write(path: &Path, content: &str) -> Result<(), String> {
    if let Some(parent) = path.parent() {
        fs::create_dir_all(parent)
            .map_err(|error| format!("create {}: {error}", parent.display()))?;
    }
    let temporary = path.with_extension("tmp");
    fs::write(&temporary, content)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

/// Line (1-based) of the first module-level `do`: one directly in a `module X =` body, not inside a
/// binding or type.
fn module_level_do(text: &str) -> Option<usize> {
    let mut bodies = vec![0usize];
    for (index, line) in text.lines().enumerate() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let indent = line.len() - trimmed.len();
        while bodies.len() > 1 && indent < bodies[bodies.len() - 1] {
            bodies.pop();
        }
        if trimmed.starts_with("module ") && trimmed.trim_end().ends_with('=') {
            bodies.push(indent + 4);
        } else if indent == bodies[bodies.len() - 1]
            && (trimmed.starts_with("do ") || trimmed.trim_end() == "do")
        {
            return Some(index + 1);
        }
    }
    None
}

const SPLIT_INITIALIZE: &str = "spiral_split_initialize";

/// A library assembly runs a file's initialization only once a value of that file is read, so the
/// monolith's module-level `do`s (hook installations, registries) would silently never run once split.
/// Each part holding one gets a value to read, and `GearRoot.initialize ()` reads them in source order;
/// the host calls it where the monolith's startup would first touch the core.
fn render_gear_root(output_root: &Path) -> Result<String, String> {
    let mut parts = fs::read_dir(output_root)
        .map_err(|error| format!("read {}: {error}", output_root.display()))?
        .filter_map(Result::ok)
        .map(|entry| entry.path())
        .filter(|path| {
            path.file_name()
                .and_then(|name| name.to_str())
                .is_some_and(|name| name.starts_with("Part") && name.ends_with(".fs"))
        })
        .collect::<Vec<_>>();
    parts.sort();
    let mut touches = String::new();
    for path in parts {
        let text = fs::read_to_string(&path)
            .map_err(|error| format!("read {}: {error}", path.display()))?;
        if module_level_do(&text).is_none() {
            continue;
        }
        let Some(module) = text.lines().find_map(|line| {
            line.strip_prefix("module ")?.strip_suffix(" =").map(str::to_owned)
        }) else {
            return Err(format!("{}: module-level `do` outside a part module", path.display()));
        };
        if !text.contains(SPLIT_INITIALIZE) {
            let newline = if text.contains("\r\n") { "\r\n" } else { "\n" };
            let separator = if text.ends_with('\n') { "" } else { newline };
            atomic_write(
                &path,
                &format!("{text}{separator}{newline}    let {SPLIT_INITIALIZE} = obj (){newline}"),
            )?;
        }
        let _ = writeln!(touches, "        {module}.{SPLIT_INITIALIZE} |> ignore");
    }
    Ok(format!(
        "namespace Polyglot\nmodule GearRoot =\n    let ready = true\n    \
         /// Runs the source's module-level `do`s in source order, as the monolith's startup would.\n    \
         let initialize () =\n{touches}        ()\n"
    ))
}

struct GearEmitPhases {
    path: PathBuf,
    started: std::time::Instant,
    rows: String,
}

impl GearEmitPhases {
    fn new(output_root: &Path) -> Result<Self, String> {
        let mut phases = Self {
            path: output_root.join("gear-emit-phases.tsv"),
            started: std::time::Instant::now(),
            rows: "phase\telapsed_ms\n".to_owned(),
        };
        phases.record("start")?;
        Ok(phases)
    }

    fn record(&mut self, phase: &str) -> Result<(), String> {
        let elapsed = self.started.elapsed().as_secs_f64() * 1_000.0;
        let _ = writeln!(self.rows, "{phase}\t{elapsed:.3}");
        atomic_write(&self.path, &self.rows)
    }
}

fn validate_generated_shard_topology(
    split: &SplitPlan,
    output_root: &Path,
) -> Result<(), String> {
    let generated = scan_generated_dependencies(output_root, split.shards.len())?;
    let mut dependencies = split
        .shards
        .iter()
        .map(|shard| shard.compile_dependencies.clone())
        .collect::<Vec<_>>();
    for dependency in generated {
        dependencies[dependency.consumer_shard].insert(dependency.provider_shard);
    }
    stable_topological_order(&dependencies)
        .map(|_| ())
        .map_err(|error| format!("generated shard topology: {error}"))
}

fn validate_split_topology(split: &SplitPlan) -> Result<(), String> {
    let dependencies = split
        .shards
        .iter()
        .map(|shard| shard.compile_dependencies.clone())
        .collect::<Vec<_>>();
    stable_topological_order(&dependencies)
        .map(|_| ())
        .map_err(|error| format!("generated shard topology: {error}"))
}

fn replan_with_explicit_generated_dependencies(
    split: &SplitPlan,
    generated: &[GeneratedDependency],
    policy: GearPolicy,
    bridge: &BridgeReport,
) -> Result<(SplitPlan, GearPlan<Planned>, usize), String> {
    let mut effective = split.clone();
    let mut added = 0usize;
    for dependency in generated {
        if dependency.consumer_shard == dependency.provider_shard {
            continue;
        }
        added += usize::from(
            effective.shards[dependency.consumer_shard]
                .compile_dependencies
                .insert(dependency.provider_shard),
        );
    }
    validate_split_topology(&effective)?;
    let gears = plan_gears_with_bridge_report(&effective, policy, bridge)?;
    Ok((effective, gears, added))
}

fn replan_with_generated_dependencies(
    split: &SplitPlan,
    output_root: &Path,
    policy: GearPolicy,
    bridge: &BridgeReport,
) -> Result<(SplitPlan, GearPlan<Planned>, usize), String> {
    let generated = scan_generated_dependencies(output_root, split.shards.len())?;
    let (effective, gears, added) =
        replan_with_explicit_generated_dependencies(split, &generated, policy, bridge)?;
    validate_generated_shard_topology(&effective, output_root)?;
    Ok((effective, gears, added))
}

pub fn emit_gears(
    split: &SplitPlan,
    mut gears: GearPlan<Planned>,
    options: &GearEmitOptions,
) -> Result<(GearPlan<Emitted>, GearEmitReceipt), String> {
    if options.output_root == Path::new("/") || options.output_root == Path::new("/mnt/data") {
        return Err("refusing gear emission into root or /mnt/data".to_owned());
    }
    for shard in &split.shards {
        let source = options
            .output_root
            .join(format!("{}.fs", part_name(shard.id)));
        if !source.is_file() {
            return Err(format!(
                "missing emitted shard {}; run emit before gears",
                source.display()
            ));
        }
    }

    let mut phases = GearEmitPhases::new(&options.output_root)?;
    let sccs = condense_compile_sccs(split)?;
    phases.record("sccs")?;
    let cyclic_sources = fuse_cyclic_sources(split, &sccs, &options.output_root)?;
    phases.record("cyclic_sources")?;
    let bridge = rewrite_anonymous_record_bridges(split, &options.output_root)?;
    phases.record("anonymous_record_bridges")?;
    let generated_helper_dependencies = qualify_generated_helper_references(
        &options.output_root,
        split.shards.len(),
    )?;
    phases.record("generated_helper_qualification")?;
    let generated_type_dependencies = qualify_unique_type_annotation_references(
        &options.output_root,
        split.shards.len(),
    )?;
    phases.record("generated_type_qualification")?;

    let policy = gears.policy;
    let (mut effective_split, replanned, _qualified_generated_dependencies) =
        replan_with_generated_dependencies(split, &options.output_root, policy, &bridge)?;
    gears = replanned;
    for dependency in &generated_helper_dependencies {
        let consumer = gears.shard_to_gear[dependency.consumer_shard];
        let provider = gears.shard_to_gear[dependency.provider_shard];
        if consumer == provider && dependency.provider_shard > dependency.consumer_shard {
            return Err(format!(
                "generated helper forward reference remains inside Gear{consumer:04}: Part{:04} -> Part{:04}",
                dependency.consumer_shard, dependency.provider_shard
            ));
        }
    }
    for dependency in &generated_type_dependencies {
        let consumer = gears.shard_to_gear[dependency.consumer_shard];
        let provider = gears.shard_to_gear[dependency.provider_shard];
        if consumer == provider && dependency.provider_shard > dependency.consumer_shard {
            return Err(format!(
                "generated type forward reference remains inside Gear{consumer:04}: Part{:04} -> Part{:04}",
                dependency.consumer_shard, dependency.provider_shard
            ));
        }
    }
    phases.record("generated_dependency_replan")?;

    let union_forward_dependencies = gears
        .gears
        .iter()
        .map(|gear| gear.dependencies.clone())
        .collect::<Vec<_>>();
    let union_forward = rewrite_union_forward_identities(
        &options.output_root,
        effective_split.shards.len(),
        &gears.shard_to_gear,
        &union_forward_dependencies,
    )?;
    phases.record("union_forward_identities")?;
    let (next_split, replanned, _union_generated_dependencies) = replan_with_generated_dependencies(
        &effective_split,
        &options.output_root,
        policy,
        &bridge,
    )?;
    effective_split = next_split;
    gears = replanned;
    phases.record("union_forward_replan")?;

    let gear_dependencies = gears
        .gears
        .iter()
        .map(|gear| gear.dependencies.clone())
        .collect::<Vec<_>>();
    let boundary = rewrite_gear_boundaries(
        &options.output_root,
        &gears.shard_to_gear,
        &gear_dependencies,
    )?;
    phases.record("anonymous_record_boundaries")?;
    let contextual = rewrite_contextual_constructors(
        &options.output_root,
        &gears.shard_to_gear,
        &gear_dependencies,
    )?;
    phases.record("contextual_constructors")?;
    let (next_split, replanned, _contextual_generated_dependencies) =
        replan_with_generated_dependencies(
            &effective_split,
            &options.output_root,
            policy,
            &bridge,
        )?;
    effective_split = next_split;
    gears = replanned;
    phases.record("contextual_generated_dependency_replan")?;

    let late_generated_helper_dependencies = qualify_generated_helper_references(
        &options.output_root,
        effective_split.shards.len(),
    )?;
    phases.record("late_generated_helper_qualification")?;
    let (next_split, replanned, _late_generated_helper_added) =
        replan_with_explicit_generated_dependencies(
            &effective_split,
            &late_generated_helper_dependencies,
            policy,
            &bridge,
        )?;
    effective_split = next_split;
    gears = replanned;
    phases.record("late_generated_helper_dependency_replan")?;
    let late_generated_type_dependencies = qualify_unique_type_annotation_references(
        &options.output_root,
        effective_split.shards.len(),
    )?;
    phases.record("late_generated_type_qualification")?;
    let (next_split, replanned, _late_generated_type_added) =
        replan_with_explicit_generated_dependencies(
            &effective_split,
            &late_generated_type_dependencies,
            policy,
            &bridge,
        )?;
    effective_split = next_split;
    gears = replanned;
    phases.record("late_generated_type_dependency_replan")?;
    let (next_split, replanned, _late_contextual_generated_dependencies) =
        replan_with_generated_dependencies(
            &effective_split,
            &options.output_root,
            policy,
            &bridge,
        )?;
    effective_split = next_split;
    gears = replanned;
    phases.record("late_contextual_generated_dependency_replan")?;

    let references = external_references(options);
    phases.record("external_references")?;
    gears
        .gears
        .par_iter()
        .map(|gear| {
            let compile_dependencies = compile_reference_dependencies(&gears, gear);
            let signature_dependencies = compile_dependencies
                .difference(&gear.dependencies)
                .copied()
                .collect::<BTreeSet<_>>();
            atomic_write(
                &options
                    .output_root
                    .join(format!("{}.fsproj", gear_name(gear.id))),
                &render_gear_project_with_dependencies(
                    &effective_split,
                    gear,
                    &signature_dependencies,
                    &references,
                ),
            )
        })
        .collect::<Result<Vec<_>, _>>()?;
    phases.record("gear_projects")?;
    let metrics = measure_gears(&effective_split, &gears);
    phases.record("metrics")?;
    let effective_sccs = condense_compile_sccs(&effective_split)?;
    let sidecars = [
        ("GearRoot.fs", render_gear_root(&options.output_root)?),
        ("GearRoot.fsproj", render_root_project(&gears)),
        ("GearBuild.proj", render_gear_build_project(&gears)),
        ("gears.tsv", render_gears_tsv(&gears)),
        ("gear-edges.tsv", render_gear_edges_tsv(&gears)),
        ("gear-metrics.tsv", render_gear_metrics_tsv(&metrics)),
        ("gear-sccs.tsv", render_sccs_tsv(&effective_sccs)),
        (
            "gear-cyclic-source-fusions.tsv",
            cyclic_sources.render_tsv(),
        ),
        (
            "gear-anonymous-record-bridges.tsv",
            render_bridge_tsv(&bridge),
        ),
        (
            "gear-union-forward-identities.tsv",
            render_union_forward_tsv(&union_forward),
        ),
        (
            "gear-anonymous-boundary-rewrites.tsv",
            render_boundary_rewrite_tsv(&boundary),
        ),
        (
            "gear-contextual-constructor-rewrites.tsv",
            render_contextual_constructor_tsv(&contextual),
        ),
    ];
    for (name, content) in sidecars {
        atomic_write(&options.output_root.join(name), &content)?;
    }
    phases.record("sidecars")?;
    let receipt = GearEmitReceipt {
        gears: gears.gears.len(),
        files: gears.gears.len() + 13,
        source_fingerprint: split.source.fingerprint,
        output_root: options.output_root.clone(),
    };
    Ok((gears.restage(), receipt))
}
