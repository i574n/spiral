#[derive(Clone, Copy)]
struct ResumeParts {
    sources: bool,
    projects: bool,
    prebridge_complete: bool,
    complete: bool,
}

const PRE_RENDER_SIDECARS: [&str; 9] = [
    "caller-contract-evidence.tsv",
    "caller-projection-evidence.tsv",
    "mutable-record-owner-evidence.tsv",
    "forwarded-binding-evidence.tsv",
    "caller-contracts.tsv",
    "record-return-owner-witnesses.tsv",
    "local-record-owner-witnesses.tsv",
    "pattern-owner-witnesses.tsv",
    "emit-phases.tsv",
];

const EMISSION_SIDECARS: [&str; 20] = [
    "caller-contract-evidence.tsv",
    "caller-projection-evidence.tsv",
    "mutable-record-owner-evidence.tsv",
    "forwarded-binding-evidence.tsv",
    "caller-contracts.tsv",
    "record-return-owner-witnesses.tsv",
    "local-record-owner-witnesses.tsv",
    "pattern-owner-witnesses.tsv",
    "Directory.Build.props",
    "NuGet.Config",
    "SplitRoot.fs",
    "SplitRoot.fsproj",
    "parts.tsv",
    "edges.tsv",
    "metrics.tsv",
    "oversize.tsv",
    "module-fragments.tsv",
    "qualified-rewrites.tsv",
    "source.receipt.tsv",
    "emit-phases.tsv",
];

fn part_source_artifact(path: &Path) -> bool {
    let Some(name) = path.file_name().and_then(|name| name.to_str()) else {
        return false;
    };
    name.starts_with("Part") && name.ends_with(".fs")
}

fn part_project_artifact(path: &Path) -> bool {
    let Some(name) = path.file_name().and_then(|name| name.to_str()) else {
        return false;
    };
    name.starts_with("Part") && name.ends_with(".fsproj")
}

fn emission_sidecar_artifact(path: &Path) -> bool {
    let Some(name) = path.file_name().and_then(|name| name.to_str()) else {
        return false;
    };
    EMISSION_SIDECARS.contains(&name)
}

fn part_artifacts_complete(plan: &SplitPlan, options: &EmitOptions) -> bool {
    (0..plan.shards.len()).all(|index| {
        let name = part_name(index);
        options.output_root.join(format!("{name}.fs")).is_file()
            && options
                .output_root
                .join(format!("{name}.fsproj"))
                .is_file()
    })
}

fn pre_render_sidecars_complete(options: &EmitOptions) -> bool {
    PRE_RENDER_SIDECARS
        .iter()
        .all(|name| options.output_root.join(name).is_file())
}

fn emission_artifacts_complete(plan: &SplitPlan, options: &EmitOptions) -> bool {
    part_artifacts_complete(plan, options)
        && EMISSION_SIDECARS
            .iter()
            .all(|name| options.output_root.join(name).is_file())
}

fn emission_identity(plan: &SplitPlan, options: &EmitOptions) -> String {
    format!(
        "key\tvalue\nsource_fingerprint\t{}\nprofile\t{}\npolicy\t{}\nreference_mode\t{}\nassembly_root\t{}\nassembly_overlay_root\t{}\ngenerator_fingerprint\t{}\ntransform_fingerprint\t{}\n",
        plan.source.fingerprint,
        plan.source.profile,
        plan.policy,
        plan.reference_mode,
        options.assembly_root.display(),
        options
            .assembly_overlay_root
            .as_deref()
            .map_or_else(|| "-".to_owned(), |root| root.display().to_string()),
        generator_fingerprint(),
        transform_fingerprint(),
    )
}

fn source_receipt_matches(plan: &SplitPlan, options: &EmitOptions) -> bool {
    let Ok(receipt) = fs::read_to_string(options.output_root.join("source.receipt.tsv")) else {
        return false;
    };
    let expected = [
        format!("source_fingerprint\t{}", plan.source.fingerprint),
        format!("profile\t{}", plan.source.profile),
        format!("policy\t{}", plan.policy),
        format!("reference_mode\t{}", plan.reference_mode),
        format!("generator_fingerprint\t{}", generator_fingerprint()),
        format!("transform_fingerprint\t{}", transform_fingerprint()),
    ];
    expected
        .iter()
        .all(|row| receipt.lines().any(|line| line == row))
}

fn reset_output_root(options: &EmitOptions, resume: ResumeParts) -> Result<(), String> {
    if !options.output_root.exists() {
        return fs::create_dir_all(&options.output_root)
            .map_err(|error| format!("create {}: {error}", options.output_root.display()));
    }
    for entry in fs::read_dir(&options.output_root)
        .map_err(|error| format!("list {}: {error}", options.output_root.display()))?
    {
        let entry = entry.map_err(|error| format!("read output entry: {error}"))?;
        let path = entry.path();
        if options.cache_root.starts_with(&path)
            || path.file_name().is_some_and(|name| name == ".gear-build")
            || (resume.sources && part_source_artifact(&path))
            || (resume.sources
                && path
                    .file_name()
                    .is_some_and(|name| name == "gear-preplan-anonymous-record-bridges.tsv"))
            || (resume.projects && part_project_artifact(&path))
            || ((resume.prebridge_complete || resume.complete) && emission_sidecar_artifact(&path))
        {
            continue;
        }
        if path.is_dir() {
            fs::remove_dir_all(&path)
                .map_err(|error| format!("remove {}: {error}", path.display()))?;
        } else {
            fs::remove_file(&path)
                .map_err(|error| format!("remove {}: {error}", path.display()))?;
        }
    }
    Ok(())
}

fn resumable_sources(projects: bool, source_receipt: bool, postprocessed_sources: bool) -> bool {
    if postprocessed_sources {
        projects && source_receipt
    } else {
        projects || source_receipt
    }
}

fn prepare_output_root(plan: &SplitPlan, options: &EmitOptions) -> Result<ResumeParts, String> {
    let identity = emission_identity(plan, options);
    let receipt = options.cache_root.join("emit-input.receipt.tsv");
    let projects = fs::read_to_string(&receipt)
        .map(|existing| existing == identity)
        .unwrap_or(false);
    // Anonymous-record preplanning rewrites Part*.fs after source.receipt.tsv is written.
    // Those postprocessed sources are resumable only when both the source receipt and the full
    // emission-input identity match. The gears planner then reloads the persisted bridge receipt
    // instead of applying the anonymous-record rewrite a second time.
    let postprocessed_sources = options
        .output_root
        .join("gear-preplan-anonymous-record-bridges.tsv")
        .is_file();
    let sources = resumable_sources(
        projects,
        source_receipt_matches(plan, options),
        postprocessed_sources,
    );
    let prebridge_complete = !postprocessed_sources
        && sources
        && projects
        && part_artifacts_complete(plan, options)
        && pre_render_sidecars_complete(options);
    let complete = sources && projects && emission_artifacts_complete(plan, options);
    let resume = ResumeParts {
        sources,
        projects,
        prebridge_complete,
        complete,
    };
    reset_output_root(options, resume)?;
    fs::create_dir_all(&options.cache_root)
        .map_err(|error| format!("create {}: {error}", options.cache_root.display()))?;
    atomic_write(&receipt, &identity)?;
    Ok(resume)
}

fn finalize_prebridge_emission(
    plan: &SplitPlan,
    options: &EmitOptions,
) -> Result<EmitReceipt, String> {
    let references = external_references(options);
    let rewrite_plan = qualified_replacements(plan);
    let metrics = measure(plan);
    let sidecars = [
        (
            "Directory.Build.props",
            render_directory_props_with_identity(
                options,
                cache_namespace_fingerprint(plan, options),
            ),
        ),
        ("NuGet.Config", render_nuget_config().to_owned()),
        ("SplitRoot.fs", render_root_source(plan)),
        ("SplitRoot.fsproj", render_root_project(plan)),
        ("parts.tsv", render_parts(plan)),
        ("edges.tsv", render_edges(plan)),
        ("metrics.tsv", render_tsv(plan, &metrics)),
        ("oversize.tsv", render_oversize_tsv(plan)),
        ("module-fragments.tsv", render_module_fragments(plan)),
        (
            "qualified-rewrites.tsv",
            render_qualified_rewrites(&rewrite_plan.replacements),
        ),
        (
            "source.receipt.tsv",
            render_receipt(plan, &references, &rewrite_plan.replacements),
        ),
    ];
    for (name, content) in sidecars {
        atomic_write(&options.output_root.join(name), &content)?;
    }
    let expected_files = plan.shards.len() * 2 + EMISSION_SIDECARS.len();
    let actual_files = fs::read_dir(&options.output_root)
        .map_err(|error| format!("list {}: {error}", options.output_root.display()))?
        .filter_map(Result::ok)
        .filter(|entry| {
            entry.path().is_file()
                && entry.file_name() != "gear-preplan-anonymous-record-bridges.tsv"
        })
        .count();
    if actual_files != expected_files {
        return Err(format!(
            "prebridge resume file count mismatch: expected {expected_files}, got {actual_files}"
        ));
    }
    Ok(EmitReceipt {
        shards: plan.shards.len(),
        files: actual_files,
        source_fingerprint: plan.source.fingerprint,
        output_root: options.output_root.clone(),
    })
}

#[cfg(test)]
mod output_reset_tests {
    use super::resumable_sources;

    #[test]
    fn postprocessed_sources_resume_only_with_both_identity_receipts() {
        assert!(resumable_sources(true, false, false));
        assert!(resumable_sources(false, true, false));
        assert!(resumable_sources(true, true, true));
        assert!(!resumable_sources(true, false, true));
        assert!(!resumable_sources(false, true, true));
    }
}
