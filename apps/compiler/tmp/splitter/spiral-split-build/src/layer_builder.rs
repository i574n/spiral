use rayon::prelude::*;
use spiral_split_build_checkpoint::{
    CheckpointSession, FailureRef, LayerCommit, PlanIdentity, fingerprint_inputs,
};
use spiral_split_build_gap::{GapGraph, GapNode, GapSchedule, render_gap_tsv};
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::marker::PhantomData;
use std::path::{Path, PathBuf};
use std::process::Command;
use std::time::{Duration, Instant, SystemTime};

pub enum Planned {}
pub enum Compiled {}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BuildUnit {
    pub shard: usize,
    pub layer: usize,
    pub project: PathBuf,
}

#[derive(Clone, Debug)]
pub struct BuildOptions {
    pub output_root: PathBuf,
    pub dotnet: PathBuf,
    pub through: Option<usize>,
    pub configuration: String,
}

#[derive(Clone, Debug)]
pub struct LayerPlan<S> {
    pub output_root: PathBuf,
    pub dotnet: PathBuf,
    pub configuration: String,
    pub units: Vec<BuildUnit>,
    pub layers: BTreeMap<usize, Vec<BuildUnit>>,
    stage: PhantomData<S>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct UnitResult {
    pub shard: usize,
    pub layer: usize,
    pub success: bool,
    pub skipped: bool,
    pub elapsed: Duration,
    pub stdout: PathBuf,
    pub stderr: PathBuf,
}

#[derive(Clone, Debug)]
pub struct BuildReceipt {
    pub layers: usize,
    pub attempted: usize,
    pub passed: usize,
    pub skipped: usize,
    pub failed: usize,
    pub elapsed: Duration,
    pub through: usize,
    pub receipt: PathBuf,
}

#[derive(Clone, Debug)]
pub struct TargetBuildReceipt {
    pub targets: Vec<usize>,
    pub selected: usize,
    pub fresh_boundaries: usize,
    pub edges_examined: usize,
    pub max_depth: usize,
    pub plan: PathBuf,
    pub progress: PathBuf,
    pub build: BuildReceipt,
}

fn atomic_write(path: &Path, bytes: &[u8]) -> Result<(), String> {
    let parent = path
        .parent()
        .ok_or_else(|| format!("path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let temporary = path.with_extension(format!("tmp-{}", std::process::id()));
    fs::write(&temporary, bytes)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

fn parse_usize(value: &str, field: &str, line: usize) -> Result<usize, String> {
    value
        .parse::<usize>()
        .map_err(|error| format!("parts.tsv line {line}: invalid {field} {value:?}: {error}"))
}

fn parse_parts(output_root: &Path, through: Option<usize>) -> Result<Vec<BuildUnit>, String> {
    let parts_path = output_root.join("parts.tsv");
    let text = fs::read_to_string(&parts_path)
        .map_err(|error| format!("read {}: {error}", parts_path.display()))?;
    let mut lines = text.lines();
    let header = lines
        .next()
        .ok_or_else(|| "parts.tsv is empty".to_owned())?;
    let fields = header.split('\t').collect::<Vec<_>>();
    let shard_index = fields
        .iter()
        .position(|field| *field == "shard")
        .ok_or_else(|| "parts.tsv is missing shard column".to_owned())?;
    let layer_index = fields
        .iter()
        .position(|field| *field == "layer")
        .ok_or_else(|| "parts.tsv is missing layer column".to_owned())?;
    let required = shard_index.max(layer_index);
    let mut units = Vec::new();
    for (offset, line) in lines.enumerate() {
        if line.trim().is_empty() {
            continue;
        }
        let line_number = offset + 2;
        let values = line.split('\t').collect::<Vec<_>>();
        if values.len() <= required {
            return Err(format!(
                "parts.tsv line {line_number}: expected at least {} columns",
                required + 1
            ));
        }
        let shard = parse_usize(values[shard_index], "shard", line_number)?;
        if through.is_some_and(|limit| shard > limit) {
            continue;
        }
        let layer = parse_usize(values[layer_index], "layer", line_number)?;
        units.push(BuildUnit {
            shard,
            layer,
            project: output_root.join(format!("Part{shard:04}.fsproj")),
        });
    }
    if units.is_empty() {
        return Err("parts.tsv selected no build units".to_owned());
    }
    units.sort_by_key(|unit| unit.shard);
    Ok(units)
}

pub fn plan_layers(options: &BuildOptions) -> Result<LayerPlan<Planned>, String> {
    if !options.output_root.is_dir() {
        return Err(format!(
            "output root does not exist: {}",
            options.output_root.display()
        ));
    }
    if !options.dotnet.is_file() {
        return Err(format!(
            "dotnet executable does not exist: {}",
            options.dotnet.display()
        ));
    }
    let units = parse_parts(&options.output_root, options.through)?;
    for unit in &units {
        if !unit.project.is_file() {
            return Err(format!(
                "missing generated project: {}",
                unit.project.display()
            ));
        }
    }
    let mut layers = BTreeMap::<usize, Vec<BuildUnit>>::new();
    for unit in &units {
        layers.entry(unit.layer).or_default().push(unit.clone());
    }
    Ok(LayerPlan {
        output_root: options.output_root.clone(),
        dotnet: options.dotnet.clone(),
        configuration: options.configuration.clone(),
        units,
        layers,
        stage: PhantomData,
    })
}

fn reference_output(plan: &LayerPlan<Planned>, shard: usize) -> PathBuf {
    let name = format!("Part{shard:04}");
    plan.output_root
        .join(".build-cache/obj")
        .join(&name)
        .join("linux/amd64")
        .join(&plan.configuration)
        .join("net11.0/ref")
        .join(format!("SpiralCompiler{name}.dll"))
}

fn modified(path: &Path) -> Option<SystemTime> {
    fs::metadata(path).ok()?.modified().ok()
}

fn referenced_shards(project: &str) -> Vec<usize> {
    let mut result = Vec::new();
    for (start, _) in project.match_indices("Part") {
        let suffix = &project[start + 4..];
        let digits = suffix.chars().take(4).collect::<String>();
        if digits.len() == 4
            && suffix.get(4..11) == Some(".fsproj")
            && let Ok(shard) = digits.parse::<usize>()
        {
            result.push(shard);
        }
    }
    result.sort_unstable();
    result.dedup();
    result
}

fn unit_is_fresh(plan: &LayerPlan<Planned>, unit: &BuildUnit) -> bool {
    let output = reference_output(plan, unit.shard);
    let Some(output_time) = modified(&output) else {
        return false;
    };
    let source = plan.output_root.join(format!("Part{:04}.fs", unit.shard));
    for input in [&unit.project, &source] {
        let Some(input_time) = modified(input) else {
            return false;
        };
        if input_time > output_time {
            return false;
        }
    }
    let Ok(project) = fs::read_to_string(&unit.project) else {
        return false;
    };
    referenced_shards(&project).into_iter().all(|dependency| {
        modified(&reference_output(plan, dependency)).is_some_and(|time| time <= output_time)
    })
}

fn plan_target_gaps(plan: &LayerPlan<Planned>, targets: &[usize]) -> Result<GapSchedule, String> {
    if targets.is_empty() {
        return Err("target build requires at least one shard".to_owned());
    }
    let known = plan
        .units
        .iter()
        .map(|unit| unit.shard)
        .collect::<BTreeSet<_>>();
    let mut dependencies = BTreeMap::<usize, Vec<usize>>::new();
    for unit in &plan.units {
        let project = fs::read_to_string(&unit.project)
            .map_err(|error| format!("read {}: {error}", unit.project.display()))?;
        let references = referenced_shards(&project);
        for dependency in &references {
            if !known.contains(dependency) {
                return Err(format!(
                    "Part{:04} references unknown generated Part{dependency:04}",
                    unit.shard
                ));
            }
        }
        dependencies.insert(unit.shard, references);
    }

    let mut effective_fresh = BTreeMap::<usize, bool>::new();
    for units in plan.layers.values() {
        for unit in units {
            let dependencies_fresh = dependencies
                .get(&unit.shard)
                .into_iter()
                .flatten()
                .all(|dependency| effective_fresh.get(dependency).copied().unwrap_or(false));
            effective_fresh.insert(unit.shard, unit_is_fresh(plan, unit) && dependencies_fresh);
        }
    }

    let nodes = plan
        .units
        .iter()
        .map(|unit| GapNode {
            shard: unit.shard,
            layer: unit.layer,
            dependencies: dependencies.get(&unit.shard).cloned().unwrap_or_default(),
            fresh: effective_fresh.get(&unit.shard).copied().unwrap_or(false),
        })
        .collect::<Vec<_>>();
    let scheduled = GapGraph::discover(nodes, targets.to_vec())?.schedule()?;
    Ok(scheduled.receipt().clone())
}

fn run_unit(plan: &LayerPlan<Planned>, unit: &BuildUnit) -> Result<UnitResult, String> {
    let name = format!("Part{:04}", unit.shard);
    let log_root = plan.output_root.join(".build-cache/logs");
    let stdout_path = log_root.join(format!("{name}.stdout"));
    let stderr_path = log_root.join(format!("{name}.stderr"));
    let started = Instant::now();
    if unit_is_fresh(plan, unit) {
        atomic_write(&stdout_path, b"skipped:fresh\n")?;
        atomic_write(&stderr_path, b"")?;
        return Ok(UnitResult {
            shard: unit.shard,
            layer: unit.layer,
            success: true,
            skipped: true,
            elapsed: started.elapsed(),
            stdout: stdout_path,
            stderr: stderr_path,
        });
    }
    let output = Command::new(&plan.dotnet)
        .current_dir(&plan.output_root)
        .env("DOTNET_MULTILEVEL_LOOKUP", "0")
        .env("DOTNET_NOLOGO", "1")
        .env("DOTNET_CLI_TELEMETRY_OPTOUT", "1")
        .env("DOTNET_SKIP_FIRST_TIME_EXPERIENCE", "1")
        .arg("build")
        .arg(format!("{name}.fsproj"))
        .arg("--no-restore")
        .arg("--no-dependencies")
        .arg("--disable-build-servers")
        .arg("-c")
        .arg(&plan.configuration)
        .arg("-m:1")
        .arg("-v:q")
        .output()
        .map_err(|error| format!("spawn dotnet for {name}: {error}"))?;
    atomic_write(&stdout_path, &output.stdout)?;
    atomic_write(&stderr_path, &output.stderr)?;
    Ok(UnitResult {
        shard: unit.shard,
        layer: unit.layer,
        success: output.status.success(),
        skipped: false,
        elapsed: started.elapsed(),
        stdout: stdout_path,
        stderr: stderr_path,
    })
}

fn render_receipt(plan: &LayerPlan<Planned>, results: &[UnitResult], elapsed: Duration) -> String {
    let passed = results
        .iter()
        .filter(|result| result.success && !result.skipped)
        .count();
    let failed = results.iter().filter(|result| !result.success).count();
    let through = plan.units.iter().map(|unit| unit.shard).max().unwrap_or(0);
    let mut output = format!(
        "key	value
layers	{}
attempted	{}
passed	{}
failed	{}
through	{}
elapsed_ms	{:.3}

shard	layer	status	elapsed_ms	stdout	stderr
",
        plan.layers.len(),
        results.len(),
        passed,
        failed,
        through,
        elapsed.as_secs_f64() * 1000.0,
    );
    for result in results {
        output.push_str(&format!(
            "{}	{}	{}	{:.3}	{}	{}
",
            result.shard,
            result.layer,
            if result.skipped {
                "skip"
            } else if result.success {
                "pass"
            } else {
                "fail"
            },
            result.elapsed.as_secs_f64() * 1000.0,
            result.stdout.display(),
            result.stderr.display(),
        ));
    }
    output
}

fn select_target_plan(
    plan: &LayerPlan<Planned>,
    schedule: &GapSchedule,
) -> Result<LayerPlan<Planned>, String> {
    let by_shard = plan
        .units
        .iter()
        .map(|unit| (unit.shard, unit))
        .collect::<BTreeMap<_, _>>();
    let mut units = Vec::with_capacity(schedule.selected.len());
    let mut layers = BTreeMap::<usize, Vec<BuildUnit>>::new();
    for (layer, shards) in &schedule.layers {
        for shard in shards {
            let unit = (*by_shard
                .get(shard)
                .ok_or_else(|| format!("gap schedule lost Part{shard:04}"))?)
            .clone();
            units.push(unit.clone());
            layers.entry(*layer).or_default().push(unit);
        }
    }
    units.sort_by_key(|unit| unit.shard);
    Ok(LayerPlan {
        output_root: plan.output_root.clone(),
        dotnet: plan.dotnet.clone(),
        configuration: plan.configuration.clone(),
        units,
        layers,
        stage: PhantomData,
    })
}

fn render_target_receipt(
    schedule: &GapSchedule,
    plan: &LayerPlan<Planned>,
    results: &[UnitResult],
    elapsed: Duration,
) -> String {
    let mut output = render_gap_tsv(schedule);
    output.push('\n');
    output.push_str(&render_receipt(plan, results, elapsed));
    output
}

fn checkpoint_identity(
    plan: &LayerPlan<Planned>,
    schedule: &GapSchedule,
) -> Result<PlanIdentity, String> {
    let signature = format!(
        "targets={:?}\nconfiguration={}\nunits={}",
        schedule.targets,
        plan.configuration,
        plan.units.len(),
    );
    let mut inputs = Vec::with_capacity(plan.units.len() * 2 + 1);
    inputs.push(plan.output_root.join("parts.tsv"));
    for unit in &plan.units {
        inputs.push(unit.project.clone());
        inputs.push(plan.output_root.join(format!("Part{:04}.fs", unit.shard)));
    }
    let fingerprint = fingerprint_inputs(&signature, &inputs)?;
    PlanIdentity::new(schedule.targets.clone(), fingerprint)
}

pub fn build_targets(
    options: &BuildOptions,
    targets: &[usize],
) -> Result<TargetBuildReceipt, String> {
    let all_options = BuildOptions {
        output_root: options.output_root.clone(),
        dotnet: options.dotnet.clone(),
        through: None,
        configuration: options.configuration.clone(),
    };
    let full_plan = plan_layers(&all_options)?;
    let schedule = plan_target_gaps(&full_plan, targets)?;
    let plan_path = full_plan.output_root.join("build-gaps.plan.tsv");
    atomic_write(&plan_path, render_gap_tsv(&schedule).as_bytes())?;
    let target_plan = select_target_plan(&full_plan, &schedule)?;
    let receipt_path = full_plan.output_root.join("build-targets.receipt.tsv");
    let identity = checkpoint_identity(&full_plan, &schedule)?;
    let mut checkpoint =
        CheckpointSession::begin(&full_plan.output_root, identity, schedule.selected.to_vec())?;
    let started = Instant::now();
    let mut results = Vec::with_capacity(target_plan.units.len());

    for (layer, units) in &target_plan.layers {
        let layer_started = Instant::now();
        let mut layer_results = units
            .par_iter()
            .map(|unit| run_unit(&target_plan, unit))
            .collect::<Result<Vec<_>, _>>()?;
        layer_results.sort_by_key(|result| result.shard);
        let layer_shards = layer_results
            .iter()
            .map(|result| result.shard)
            .collect::<Vec<_>>();
        let layer_passed = layer_results
            .iter()
            .filter(|result| result.success && !result.skipped)
            .count();
        let layer_skipped = layer_results.iter().filter(|result| result.skipped).count();
        let failure_refs = layer_results
            .iter()
            .filter(|result| !result.success)
            .map(|result| FailureRef {
                shard: result.shard,
                stderr: result.stderr.clone(),
            })
            .collect::<Vec<_>>();
        let failures = failure_refs
            .iter()
            .map(|failure| format!("Part{:04} ({})", failure.shard, failure.stderr.display()))
            .collect::<Vec<_>>();
        let commit = if failure_refs.is_empty() {
            LayerCommit::passed(
                *layer,
                layer_shards,
                layer_passed,
                layer_skipped,
                layer_started.elapsed(),
            )?
        } else {
            LayerCommit::failed(
                *layer,
                layer_shards,
                layer_passed,
                layer_skipped,
                failure_refs,
                layer_started.elapsed(),
            )?
        };
        checkpoint = checkpoint.record_layer(commit)?;
        results.extend(layer_results);
        if !failures.is_empty() {
            let failure_note = format!("target build failed: {}", failures.join(", "));
            let _failed_checkpoint = checkpoint.fail(&failure_note)?;
            atomic_write(
                &receipt_path,
                render_target_receipt(&schedule, &target_plan, &results, started.elapsed())
                    .as_bytes(),
            )?;
            return Err(format!(
                "{}; receipt={}",
                failure_note,
                receipt_path.display()
            ));
        }
    }
    let completed_checkpoint = checkpoint.succeed()?;
    let progress_path = completed_checkpoint.progress_path();

    let elapsed = started.elapsed();
    atomic_write(
        &receipt_path,
        render_target_receipt(&schedule, &target_plan, &results, elapsed).as_bytes(),
    )?;
    let passed = results
        .iter()
        .filter(|result| result.success && !result.skipped)
        .count();
    let skipped = results.iter().filter(|result| result.skipped).count();
    let failed = results.len() - passed - skipped;
    let build = BuildReceipt {
        layers: target_plan.layers.len(),
        attempted: results.len(),
        passed,
        skipped,
        failed,
        elapsed,
        through: schedule.targets.iter().copied().max().unwrap_or(0),
        receipt: receipt_path,
    };
    Ok(TargetBuildReceipt {
        targets: schedule.targets.clone(),
        selected: schedule.selected.len(),
        fresh_boundaries: schedule.fresh_boundaries.len(),
        edges_examined: schedule.edges_examined,
        max_depth: schedule.max_depth,
        plan: plan_path,
        progress: progress_path,
        build,
    })
}

pub fn build_layers(options: &BuildOptions) -> Result<BuildReceipt, String> {
    let plan = plan_layers(options)?;
    let started = Instant::now();
    let mut results = Vec::with_capacity(plan.units.len());
    for units in plan.layers.values() {
        let mut layer_results = units
            .par_iter()
            .map(|unit| run_unit(&plan, unit))
            .collect::<Result<Vec<_>, _>>()?;
        layer_results.sort_by_key(|result| result.shard);
        let failures = layer_results
            .iter()
            .filter(|result| !result.success)
            .map(|result| format!("Part{:04} ({})", result.shard, result.stderr.display()))
            .collect::<Vec<_>>();
        results.extend(layer_results);
        if !failures.is_empty() {
            let receipt_path = plan.output_root.join("build-layers.receipt.tsv");
            atomic_write(
                &receipt_path,
                render_receipt(&plan, &results, started.elapsed()).as_bytes(),
            )?;
            return Err(format!("layer build failed: {}", failures.join(", ")));
        }
    }
    let elapsed = started.elapsed();
    let receipt_path = plan.output_root.join("build-layers.receipt.tsv");
    atomic_write(
        &receipt_path,
        render_receipt(&plan, &results, elapsed).as_bytes(),
    )?;
    let passed = results
        .iter()
        .filter(|result| result.success && !result.skipped)
        .count();
    let skipped = results.iter().filter(|result| result.skipped).count();
    let through = plan.units.iter().map(|unit| unit.shard).max().unwrap_or(0);
    let compiled = LayerPlan::<Compiled> {
        output_root: plan.output_root,
        dotnet: plan.dotnet,
        configuration: plan.configuration,
        units: plan.units,
        layers: plan.layers,
        stage: PhantomData,
    };
    let _ = compiled;
    Ok(BuildReceipt {
        layers: results
            .iter()
            .map(|result| result.layer)
            .max()
            .map_or(0, |value| value + 1),
        attempted: results.len(),
        passed,
        skipped,
        failed: results.len() - passed - skipped,
        elapsed,
        through,
        receipt: receipt_path,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn parts_are_grouped_by_layer_and_bounded_by_shard() {
        let root = std::env::temp_dir().join(format!("spiral-split-build-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).unwrap();
        fs::write(
            root.join("parts.tsv"),
            "shard	declarations	lines	bytes	layer
0	0	1	1	0
1	1	1	1	1
2	2	1	1	1
",
        )
        .unwrap();
        for shard in 0..=2 {
            fs::write(root.join(format!("Part{shard:04}.fsproj")), "<Project />").unwrap();
        }
        let units = parse_parts(&root, Some(1)).unwrap();
        assert_eq!(units.len(), 2);
        assert_eq!(units[0].layer, 0);
        assert_eq!(units[1].layer, 1);
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn project_reference_parser_is_deduplicated() {
        let project = r#"<ProjectReference Include="Part0012.fsproj" />
<ProjectReference Include="Part0012.fsproj" />
<ProjectReference Include="Part0042.fsproj" />"#;
        assert_eq!(referenced_shards(project), vec![12, 42]);
    }

    #[test]
    fn fresh_reference_output_skips_until_an_input_changes() {
        let root =
            std::env::temp_dir().join(format!("spiral-split-build-fresh-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).unwrap();
        let unit = BuildUnit {
            shard: 0,
            layer: 1,
            project: root.join("Part0000.fsproj"),
        };
        fs::write(
            &unit.project,
            "<ProjectReference Include=\"Part0001.fsproj\" />",
        )
        .unwrap();
        fs::write(root.join("Part0000.fs"), "module Part0000").unwrap();
        let plan = LayerPlan::<Planned> {
            output_root: root.clone(),
            dotnet: root.join("dotnet"),
            configuration: "Release".to_owned(),
            units: vec![unit.clone()],
            layers: BTreeMap::new(),
            stage: PhantomData,
        };
        let dependency = reference_output(&plan, 1);
        fs::create_dir_all(dependency.parent().unwrap()).unwrap();
        fs::write(&dependency, "dependency").unwrap();
        std::thread::sleep(Duration::from_millis(10));
        let output = reference_output(&plan, 0);
        fs::create_dir_all(output.parent().unwrap()).unwrap();
        fs::write(&output, "output").unwrap();
        assert!(unit_is_fresh(&plan, &unit));
        std::thread::sleep(Duration::from_millis(10));
        fs::write(root.join("Part0000.fs"), "module Part0000Changed").unwrap();
        assert!(!unit_is_fresh(&plan, &unit));
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn target_gaps_propagate_staleness_through_locally_fresh_consumers() {
        let root = std::env::temp_dir().join(format!(
            "spiral-split-build-gap-propagation-{}",
            std::process::id()
        ));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).unwrap();
        let dependency = BuildUnit {
            shard: 0,
            layer: 0,
            project: root.join("Part0000.fsproj"),
        };
        let target = BuildUnit {
            shard: 1,
            layer: 1,
            project: root.join("Part0001.fsproj"),
        };
        fs::write(&dependency.project, "<Project />").unwrap();
        fs::write(
            &target.project,
            "<ProjectReference Include=\"Part0000.fsproj\" />",
        )
        .unwrap();
        fs::write(root.join("Part0000.fs"), "module Part0000").unwrap();
        fs::write(root.join("Part0001.fs"), "module Part0001").unwrap();
        let mut layers = BTreeMap::new();
        layers.insert(0, vec![dependency.clone()]);
        layers.insert(1, vec![target.clone()]);
        let plan = LayerPlan::<Planned> {
            output_root: root.clone(),
            dotnet: root.join("dotnet"),
            configuration: "Release".to_owned(),
            units: vec![dependency.clone(), target.clone()],
            layers,
            stage: PhantomData,
        };
        std::thread::sleep(Duration::from_millis(10));
        for shard in 0..=1 {
            let output = reference_output(&plan, shard);
            fs::create_dir_all(output.parent().unwrap()).unwrap();
            fs::write(output, format!("Part{shard:04}")).unwrap();
            std::thread::sleep(Duration::from_millis(10));
        }
        assert!(unit_is_fresh(&plan, &dependency));
        assert!(unit_is_fresh(&plan, &target));
        fs::write(root.join("Part0000.fs"), "module Part0000Changed").unwrap();
        assert!(!unit_is_fresh(&plan, &dependency));
        assert!(unit_is_fresh(&plan, &target));
        let schedule = plan_target_gaps(&plan, &[1]).unwrap();
        assert_eq!(schedule.selected, vec![0, 1]);
        assert!(schedule.fresh_boundaries.is_empty());
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn missing_columns_are_rejected() {
        let root =
            std::env::temp_dir().join(format!("spiral-split-build-bad-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).unwrap();
        fs::write(
            root.join("parts.tsv"),
            "shard
0
",
        )
        .unwrap();
        assert!(parse_parts(&root, None).is_err());
        fs::remove_dir_all(root).unwrap();
    }
}
