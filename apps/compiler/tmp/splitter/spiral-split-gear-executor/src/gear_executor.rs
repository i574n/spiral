use spiral_split_build_budget::{BudgetDecision, BuildBudget};
use spiral_split_build_checkpoint::{
    CheckpointSession, FailureRef, LayerCommit, PlanIdentity, fingerprint_inputs_relative,
};
use spiral_split_dotnet_build_command::{DotnetBuildSpec, DotnetBuildTarget, build_command};
use spiral_split_gear_artifact_state::{
    ArtifactPreparation, ArtifactTarget, commit_cached_artifact_state, prepare_artifact_state,
};
use spiral_split_gear_execution_trace::{ExecutionPhases, GearWorkerTrace};
use spiral_split_gear_fingerprint::{
    FingerprintNode, derive_transitive_fingerprints, direct_fingerprint,
};
use spiral_split_gear_receipt::render_receipt as render_budget_receipt;
pub use spiral_split_gear_receipt::{ExecutionOutcome, GearExecutionReceipt, GearUnitResult};
use spiral_split_gear_restore::{GearRestoreOptions, ensure_gear_restore_assets};
use spiral_split_process_supervisor::{run_bounded_process, run_bounded_process_observed};
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::marker::PhantomData;
use std::path::{Path, PathBuf};
use std::sync::{Arc, OnceLock};
use std::thread;
use std::time::{Duration, Instant};

#[derive(Debug)]
pub enum Loaded {}
#[derive(Debug)]
pub enum Validated {}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearUnit {
    pub id: usize,
    pub layer: usize,
    pub dependencies: Vec<usize>,
    pub source_fingerprint: u64,
    pub project: PathBuf,
    pub inputs: Vec<PathBuf>,
    pub build_fingerprint: u64,
    pub artifact_fingerprint: u64,
}

#[derive(Clone, Debug)]
pub struct GearExecutionPlan<S> {
    pub output_root: PathBuf,
    pub configuration: String,
    pub units: Vec<GearUnit>,
    pub layers: BTreeMap<usize, Vec<GearUnit>>,
    pub identity: PlanIdentity,
    stage: PhantomData<S>,
}

#[derive(Clone, Debug)]
pub struct GearExecutionOptions {
    pub output_root: PathBuf,
    pub dotnet: PathBuf,
    pub configuration: String,
    pub jobs: usize,
    pub force: bool,
    pub through: Option<usize>,
    pub process_timeout: Duration,
    pub build_budget: Option<Duration>,
    pub build_reserve: Duration,
}

fn parse_usize(value: &str, field: &str, line: usize) -> Result<usize, String> {
    value
        .parse::<usize>()
        .map_err(|error| format!("gears.tsv line {line}: invalid {field} {value:?}: {error}"))
}

fn parse_u64(value: &str, field: &str, line: usize) -> Result<u64, String> {
    value
        .parse::<u64>()
        .map_err(|error| format!("gears.tsv line {line}: invalid {field} {value:?}: {error}"))
}

fn parse_dependencies(value: &str, line: usize) -> Result<Vec<usize>, String> {
    if value.is_empty() || value == "-" {
        return Ok(Vec::new());
    }
    value
        .split(',')
        .map(|item| parse_usize(item, "dependency", line))
        .collect()
}

fn parse_manifest_row(
    line: &str,
    line_number: usize,
) -> Result<(usize, usize, Vec<usize>, u64), String> {
    let fields = line.split_whitespace().collect::<Vec<_>>();
    if fields.len() != 9 && fields.len() != 10 {
        return Err(format!(
            "gears.tsv line {line_number}: expected 9 or 10 columns, got {}",
            fields.len()
        ));
    }
    let id = parse_usize(fields[0], "gear", line_number)?;
    let layer = parse_usize(fields[1], "source_layer", line_number)?;
    let (dependencies, fingerprint_index) = if fields.len() == 10 {
        (parse_dependencies(fields[7], line_number)?, 8)
    } else {
        (Vec::new(), 7)
    };
    let fingerprint = parse_u64(fields[fingerprint_index], "fingerprint", line_number)?;
    Ok((id, layer, dependencies, fingerprint))
}

fn compile_inputs(output_root: &Path, project: &Path) -> Result<Vec<PathBuf>, String> {
    let text = fs::read_to_string(project)
        .map_err(|error| format!("read {}: {error}", project.display()))?;
    let mut paths = vec![project.to_path_buf()];
    for tail in text.split("<Compile Include=\"").skip(1) {
        let Some((relative, _)) = tail.split_once('"') else {
            continue;
        };
        paths.push(output_root.join(relative));
    }
    for name in ["global.json", "NuGet.Config", "Directory.Build.props"] {
        let path = output_root.join(name);
        if path.is_file() {
            paths.push(path);
        }
    }
    paths.sort();
    paths.dedup();
    for path in &paths {
        if !path.is_file() {
            return Err(format!("gear input is missing: {}", path.display()));
        }
    }
    Ok(paths)
}

fn transform_fingerprint(output_root: &Path) -> Result<u64, String> {
    let receipt = output_root.join("source.receipt.tsv");
    let text = fs::read_to_string(&receipt)
        .map_err(|error| format!("read {}: {error}", receipt.display()))?;
    let value = text
        .lines()
        .find_map(|line| {
            let (key, value) = line.split_once('\t')?;
            (key == "transform_fingerprint").then_some(value)
        })
        .ok_or_else(|| format!("{} is missing transform_fingerprint", receipt.display()))?;
    value.parse::<u64>().map_err(|error| {
        format!(
            "{} has invalid transform_fingerprint {value:?}: {error}",
            receipt.display()
        )
    })
}

fn unit_fingerprint(
    output_root: &Path,
    id: usize,
    layer: usize,
    source_fingerprint: u64,
    dependencies: &[usize],
    configuration: &str,
    paths: &[PathBuf],
) -> Result<u64, String> {
    fingerprint_inputs_relative(
        output_root,
        &format!(
            "gear={id}
layer={layer}
source={source_fingerprint}
dependencies={dependencies:?}
configuration={configuration}"
        ),
        paths,
    )
}

pub fn load_gear_plan(
    output_root: &Path,
    configuration: impl Into<String>,
    through: Option<usize>,
) -> Result<GearExecutionPlan<Loaded>, String> {
    let configuration = configuration.into();
    let transform_fingerprint = transform_fingerprint(output_root)?;
    let manifest = output_root.join("gears.tsv");
    let text = fs::read_to_string(&manifest)
        .map_err(|error| format!("read {}: {error}", manifest.display()))?;
    let mut units = Vec::new();
    for (index, line) in text.lines().enumerate().skip(1) {
        if line.trim().is_empty() {
            continue;
        }
        let line_number = index + 1;
        let (id, layer, dependencies, source_fingerprint) = parse_manifest_row(line, line_number)?;
        if through.is_some_and(|maximum| id > maximum) {
            continue;
        }
        let project = output_root.join(format!("Gear{id:04}.fsproj"));
        let inputs = compile_inputs(output_root, &project)?;
        let build_fingerprint = unit_fingerprint(
            output_root,
            id,
            layer,
            source_fingerprint,
            &dependencies,
            &configuration,
            &inputs,
        )?;
        units.push(GearUnit {
            id,
            layer,
            dependencies,
            source_fingerprint,
            project,
            inputs,
            build_fingerprint,
            artifact_fingerprint: build_fingerprint,
        });
    }
    if units.is_empty() {
        return Err("gears.tsv contains no gears".to_owned());
    }
    units.sort_by_key(|unit| unit.id);
    let fingerprint_nodes = units
        .iter()
        .map(|unit| FingerprintNode {
            id: unit.id,
            direct: direct_fingerprint(unit.build_fingerprint),
            dependencies: unit.dependencies.clone(),
        })
        .collect::<Vec<_>>();
    let transitive = derive_transitive_fingerprints(&fingerprint_nodes)?;
    for unit in &mut units {
        unit.artifact_fingerprint = transitive
            .get(&unit.id)
            .ok_or_else(|| format!("missing transitive fingerprint for Gear{:04}", unit.id))?
            .value();
    }
    let signature = format!(
        "configuration={}
transform={}
gears={:?}",
        configuration,
        transform_fingerprint,
        units
            .iter()
            .map(|unit| (
                unit.id,
                unit.layer,
                unit.build_fingerprint,
                unit.artifact_fingerprint,
            ))
            .collect::<Vec<_>>()
    );
    let mut identity_paths = vec![
        manifest,
        output_root.join("GearRoot.fsproj"),
        output_root.join("source.receipt.tsv"),
    ];
    identity_paths.extend(units.iter().flat_map(|unit| unit.inputs.iter().cloned()));
    let identity = PlanIdentity::new(
        units.iter().map(|unit| unit.id).collect(),
        fingerprint_inputs_relative(output_root, &signature, &identity_paths)?,
    )?;
    Ok(GearExecutionPlan {
        output_root: output_root.to_path_buf(),
        configuration,
        units,
        layers: BTreeMap::new(),
        identity,
        stage: PhantomData,
    })
}

impl GearExecutionPlan<Loaded> {
    pub fn validate(self) -> Result<GearExecutionPlan<Validated>, String> {
        let known = self
            .units
            .iter()
            .map(|unit| unit.id)
            .collect::<BTreeSet<_>>();
        if known.len() != self.units.len() {
            return Err("gears.tsv contains duplicate gear ids".to_owned());
        }
        let layer_by_id = self
            .units
            .iter()
            .map(|unit| (unit.id, unit.layer))
            .collect::<BTreeMap<_, _>>();
        let mut layers = BTreeMap::<usize, Vec<GearUnit>>::new();
        for unit in &self.units {
            let mut dependencies = unit.dependencies.clone();
            dependencies.sort_unstable();
            dependencies.dedup();
            if dependencies.len() != unit.dependencies.len() {
                return Err(format!(
                    "Gear{:04} contains duplicate dependencies",
                    unit.id
                ));
            }
            for dependency in &dependencies {
                let dependency_layer = layer_by_id.get(dependency).ok_or_else(|| {
                    format!("Gear{:04} references unknown Gear{dependency:04}", unit.id)
                })?;
                if dependency_layer >= &unit.layer {
                    return Err(format!(
                        "Gear{:04} layer {} depends on Gear{dependency:04} layer {dependency_layer}",
                        unit.id, unit.layer
                    ));
                }
            }
            layers.entry(unit.layer).or_default().push(unit.clone());
        }
        for layer in layers.values_mut() {
            layer.sort_by_key(|unit| unit.id);
        }
        Ok(GearExecutionPlan {
            output_root: self.output_root,
            configuration: self.configuration,
            units: self.units,
            layers,
            identity: self.identity,
            stage: PhantomData,
        })
    }
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

fn effective_freshness(
    plan: &GearExecutionPlan<Validated>,
    force: bool,
) -> Result<BTreeMap<usize, bool>, String> {
    let mut fresh = BTreeMap::new();
    for units in plan.layers.values() {
        for unit in units {
            let dependencies_fresh = unit
                .dependencies
                .iter()
                .all(|dependency| fresh.get(dependency).copied().unwrap_or(false));
            let target = ArtifactTarget::Gear { id: unit.id };
            let own_fresh = if force {
                false
            } else {
                matches!(
                    prepare_artifact_state(&plan.output_root, target, unit.artifact_fingerprint)?,
                    ArtifactPreparation::Current | ArtifactPreparation::Hydrated
                )
            };
            fresh.insert(unit.id, own_fresh && dependencies_fresh);
        }
    }
    Ok(fresh)
}

fn run_gear(
    options: &GearExecutionOptions,
    unit: &GearUnit,
    skip: bool,
) -> Result<GearUnitResult, String> {
    let name = format!("Gear{:04}", unit.id);
    let log_root = options.output_root.join(".gear-build/logs");
    let stdout = log_root.join(format!("{name}.stdout"));
    let stderr = log_root.join(format!("{name}.stderr"));
    let started = Instant::now();
    let mut worker_trace = GearWorkerTrace::new(&options.output_root, unit.id)?;
    if skip {
        worker_trace.record("skip")?;
        atomic_write(
            &stdout,
            b"skipped:fresh
",
        )?;
        atomic_write(&stderr, b"")?;
        return Ok(GearUnitResult {
            id: unit.id,
            layer: unit.layer,
            success: true,
            skipped: true,
            elapsed: started.elapsed(),
            stdout,
            stderr,
        });
    }
    let command = build_command(&DotnetBuildSpec {
        dotnet: &options.dotnet,
        working_dir: &options.output_root,
        configuration: &options.configuration,
        target: DotnetBuildTarget::Gear { id: unit.id },
    });
    worker_trace.record("command_ready")?;
    let capture = run_bounded_process_observed(command, options.process_timeout, &name, |phase| {
        worker_trace.record(phase.trace_name())
    })?;
    worker_trace.record("capture_return")?;
    let success = capture.success();
    atomic_write(&stdout, &capture.stdout)?;
    worker_trace.record("stdout_committed")?;
    atomic_write(&stderr, &capture.stderr)?;
    worker_trace.record("stderr_committed")?;
    if success {
        let target = ArtifactTarget::Gear { id: unit.id };
        commit_cached_artifact_state(&options.output_root, target, unit.artifact_fingerprint)?;
        worker_trace.record("state_committed")?;
    }
    worker_trace.record("return")?;
    Ok(GearUnitResult {
        id: unit.id,
        layer: unit.layer,
        success,
        skipped: false,
        elapsed: started.elapsed(),
        stdout,
        stderr,
    })
}

fn run_root(
    options: &GearExecutionOptions,
    plan_fingerprint: u64,
) -> Result<(bool, bool, Duration, PathBuf, PathBuf), String> {
    let stdout = options.output_root.join(".gear-build/logs/GearRoot.stdout");
    let stderr = options.output_root.join(".gear-build/logs/GearRoot.stderr");
    let target = ArtifactTarget::Root;
    let started = Instant::now();
    let preparation = if options.force {
        ArtifactPreparation::Stale
    } else {
        prepare_artifact_state(&options.output_root, target, plan_fingerprint)?
    };
    if matches!(
        preparation,
        ArtifactPreparation::Current | ArtifactPreparation::Hydrated
    ) {
        atomic_write(
            &stdout,
            b"skipped:fresh
",
        )?;
        atomic_write(&stderr, b"")?;
        return Ok((true, true, started.elapsed(), stdout, stderr));
    }
    let command = build_command(&DotnetBuildSpec {
        dotnet: &options.dotnet,
        working_dir: &options.output_root,
        configuration: &options.configuration,
        target: DotnetBuildTarget::Root,
    });
    let capture = run_bounded_process(command, options.process_timeout, "GearRoot")?;
    let success = capture.success();
    atomic_write(&stdout, &capture.stdout)?;
    atomic_write(&stderr, &capture.stderr)?;
    if success {
        commit_cached_artifact_state(&options.output_root, target, plan_fingerprint)?;
    }
    Ok((success, false, started.elapsed(), stdout, stderr))
}

fn render_receipt(
    plan: &GearExecutionPlan<Validated>,
    results: &[GearUnitResult],
    root: &(bool, bool, Duration, PathBuf, PathBuf),
    elapsed: Duration,
) -> String {
    let passed = results
        .iter()
        .filter(|result| result.success && !result.skipped)
        .count();
    let skipped = results.iter().filter(|result| result.skipped).count();
    let failed = results.iter().filter(|result| !result.success).count();
    let mut output = format!(
        "key	value
status	{}
gears	{}
layers	{}
passed	{}
skipped	{}
failed	{}
root_status	{}
root_skipped	{}
elapsed_ms	{:.3}

gear	layer	status	elapsed_ms	stdout	stderr
",
        if failed == 0 && root.0 {
            "pass"
        } else {
            "fail"
        },
        plan.units.len(),
        plan.layers.len(),
        passed,
        skipped,
        failed,
        if root.0 { "pass" } else { "fail" },
        root.1,
        elapsed.as_secs_f64() * 1000.0,
    );
    for result in results {
        output.push_str(&format!(
            "{}	{}	{}	{:.3}	{}	{}
",
            result.id,
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
    output.push_str(&format!(
        "root	-	{}	{:.3}	{}	{}
",
        if root.1 {
            "skip"
        } else if root.0 {
            "pass"
        } else {
            "fail"
        },
        root.2.as_secs_f64() * 1000.0,
        root.3.display(),
        root.4.display(),
    ));
    output
}

pub fn execute_gears(options: &GearExecutionOptions) -> Result<GearExecutionReceipt, String> {
    if options.jobs == 0 {
        return Err("gear executor jobs must be greater than zero".to_owned());
    }
    let budget = options
        .build_budget
        .map_or(BuildBudget::Unlimited, |total| {
            BuildBudget::limited(total, options.build_reserve)
        });
    let budget = budget.clock();
    let mut phases = ExecutionPhases::new(&options.output_root)?;
    let restore = ensure_gear_restore_assets(&GearRestoreOptions {
        output_root: options.output_root.clone(),
        dotnet: options.dotnet.clone(),
        jobs: options.jobs,
    })?;
    phases.record("restore")?;
    let plan = load_gear_plan(
        &options.output_root,
        options.configuration.clone(),
        options.through,
    )?
    .validate()?;
    phases.record("plan")?;
    let freshness = effective_freshness(&plan, options.force)?;
    phases.record("freshness")?;
    let checkpoint_root = options.output_root.join(".gear-build/checkpoint");
    let mut checkpoint = Some(CheckpointSession::begin(
        &checkpoint_root,
        plan.identity.clone(),
        plan.units.iter().map(|unit| unit.id).collect(),
    )?);
    phases.record("checkpoint")?;
    let started = Instant::now();
    let unit_by_id = plan
        .units
        .iter()
        .map(|unit| (unit.id, unit))
        .collect::<BTreeMap<_, _>>();
    let mut remaining_dependencies = plan
        .units
        .iter()
        .map(|unit| (unit.id, unit.dependencies.len()))
        .collect::<BTreeMap<_, _>>();
    let mut dependents = BTreeMap::<usize, Vec<usize>>::new();
    for unit in &plan.units {
        for dependency in &unit.dependencies {
            dependents.entry(*dependency).or_default().push(unit.id);
        }
    }
    for children in dependents.values_mut() {
        children.sort_unstable();
    }
    let mut ready = remaining_dependencies
        .iter()
        .filter_map(|(id, pending)| (*pending == 0).then_some(*id))
        .collect::<BTreeSet<_>>();
    let layer_order = plan.layers.keys().copied().collect::<Vec<_>>();
    let mut next_layer = 0usize;
    let mut layer_started = BTreeMap::<usize, Instant>::new();
    let mut result_by_id = BTreeMap::<usize, GearUnitResult>::new();
    let mut running = BTreeMap::<usize, Arc<OnceLock<Result<GearUnitResult, String>>>>::new();
    let mut yield_decision = None::<BudgetDecision>;

    thread::scope(|scope| -> Result<(), String> {
        loop {
            while running.len() < options.jobs && yield_decision.is_none() {
                let Some(id) = ready.pop_first() else {
                    break;
                };
                let unit = *unit_by_id
                    .get(&id)
                    .ok_or_else(|| format!("ready queue references unknown Gear{id:04}"))?;
                let skip = freshness.get(&id).copied().unwrap_or(false);
                if !skip {
                    let decision = budget.decision(options.process_timeout);
                    if matches!(decision, BudgetDecision::Yield { .. }) {
                        ready.insert(id);
                        yield_decision = Some(decision);
                        phases.record("yield_budget")?;
                        break;
                    }
                }
                layer_started.entry(unit.layer).or_insert_with(Instant::now);
                phases.record(&format!(
                    "dispatch_{id:04}_{}",
                    if skip { "skip" } else { "build" }
                ))?;
                let slot = Arc::new(OnceLock::new());
                let worker_slot = Arc::clone(&slot);
                scope.spawn(move || {
                    let _ = worker_slot.set(run_gear(options, unit, skip));
                });
                running.insert(id, slot);
            }

            if running.is_empty() {
                break;
            }

            let completed = running
                .iter()
                .find_map(|(id, slot)| slot.get().cloned().map(|result| (*id, result)));
            let Some((completed_id, result)) = completed else {
                thread::sleep(Duration::from_millis(2));
                continue;
            };
            running.remove(&completed_id);
            let result = result?;
            let id = result.id;
            debug_assert_eq!(completed_id, id);
            phases.record(&format!(
                "complete_{id:04}_{}",
                if result.skipped {
                    "skip"
                } else if result.success {
                    "pass"
                } else {
                    "fail"
                }
            ))?;
            if result.success {
                for dependent in dependents.get(&id).into_iter().flatten() {
                    let pending = remaining_dependencies.get_mut(dependent).ok_or_else(|| {
                        format!("missing dependency counter for Gear{dependent:04}")
                    })?;
                    *pending = pending.checked_sub(1).ok_or_else(|| {
                        format!("dependency counter underflow for Gear{dependent:04}")
                    })?;
                    if *pending == 0 {
                        ready.insert(*dependent);
                    }
                }
            }
            result_by_id.insert(id, result);

            while next_layer < layer_order.len() {
                let layer = layer_order[next_layer];
                let units = plan
                    .layers
                    .get(&layer)
                    .ok_or_else(|| format!("missing layer {layer}"))?;
                if !units.iter().all(|unit| result_by_id.contains_key(&unit.id)) {
                    break;
                }
                let layer_results = units
                    .iter()
                    .map(|unit| result_by_id[&unit.id].clone())
                    .collect::<Vec<_>>();
                let passed = layer_results
                    .iter()
                    .filter(|result| result.success && !result.skipped)
                    .count();
                let skipped = layer_results.iter().filter(|result| result.skipped).count();
                let failures = layer_results
                    .iter()
                    .filter(|result| !result.success)
                    .map(|result| FailureRef {
                        shard: result.id,
                        stderr: result.stderr.clone(),
                    })
                    .collect::<Vec<_>>();
                let ids = layer_results
                    .iter()
                    .map(|result| result.id)
                    .collect::<Vec<_>>();
                let elapsed = layer_started
                    .get(&layer)
                    .map(Instant::elapsed)
                    .unwrap_or(Duration::ZERO);
                let commit = if failures.is_empty() {
                    LayerCommit::passed(layer, ids, passed, skipped, elapsed)?
                } else {
                    LayerCommit::failed(layer, ids, passed, skipped, failures, elapsed)?
                };
                let active = checkpoint
                    .take()
                    .ok_or_else(|| "checkpoint state is missing".to_owned())?;
                checkpoint = Some(active.record_layer(commit)?);
                next_layer += 1;
            }
        }
        Ok(())
    })?;
    phases.record("execution")?;

    let checkpoint = checkpoint
        .take()
        .ok_or_else(|| "checkpoint state is missing after ready queue".to_owned())?;
    let mut results = result_by_id.into_values().collect::<Vec<_>>();
    results.sort_by_key(|result| result.id);
    if yield_decision.is_none()
        && results.len() == plan.units.len()
        && results.iter().all(|result| result.success)
        && options.through.is_none()
    {
        let decision = budget.decision(options.process_timeout);
        if matches!(decision, BudgetDecision::Yield { .. }) {
            yield_decision = Some(decision);
            phases.record("yield_before_root")?;
        }
    }
    if let Some(decision) = yield_decision.filter(|_| results.iter().all(|result| result.success)) {
        let note = decision
            .yield_note()
            .unwrap_or_else(|| "build budget yielded".to_owned());
        let completed_layers = checkpoint.committed_layers();
        let yielded = checkpoint.yield_now(note)?;
        let progress = yielded.progress_path();
        let elapsed = started.elapsed();
        let root = (
            false,
            false,
            Duration::ZERO,
            options.output_root.join(".gear-build/logs/GearRoot.stdout"),
            options.output_root.join(".gear-build/logs/GearRoot.stderr"),
        );
        let receipt = options.output_root.join("gear-build.receipt.tsv");
        atomic_write(
            &receipt,
            render_budget_receipt(
                plan.units.len(),
                plan.layers.len(),
                &results,
                &root,
                elapsed,
                ExecutionOutcome::Yielded,
            )
            .as_bytes(),
        )?;
        let passed = results
            .iter()
            .filter(|result| result.success && !result.skipped)
            .count();
        let skipped = results.iter().filter(|result| result.skipped).count();
        let failed = results.iter().filter(|result| !result.success).count();
        return Ok(GearExecutionReceipt {
            gears: plan.units.len(),
            layers: plan.layers.len(),
            restore_seeded: restore.copied,
            restore_reused: restore.reused,
            restore_invoked: restore.restored_seed,
            restore_receipt: restore.receipt,
            completed: results.len(),
            completed_layers,
            outcome: ExecutionOutcome::Yielded,
            passed,
            skipped,
            failed,
            root_built: false,
            root_skipped: false,
            elapsed,
            progress,
            receipt,
        });
    }
    if results.len() != plan.units.len() || results.iter().any(|result| !result.success) {
        let _failed = checkpoint.fail("dependency-ready gear execution failed")?;
        let root = (
            false,
            false,
            Duration::ZERO,
            options.output_root.join(".gear-build/logs/GearRoot.stdout"),
            options.output_root.join(".gear-build/logs/GearRoot.stderr"),
        );
        let receipt = options.output_root.join("gear-build.receipt.tsv");
        atomic_write(
            &receipt,
            render_receipt(&plan, &results, &root, started.elapsed()).as_bytes(),
        )?;
        return Err(format!("gear build failed; receipt={}", receipt.display()));
    }

    let root = if options.through.is_some() {
        (
            true,
            true,
            Duration::ZERO,
            options.output_root.join(".gear-build/logs/GearRoot.stdout"),
            options.output_root.join(".gear-build/logs/GearRoot.stderr"),
        )
    } else {
        run_root(options, plan.identity.fingerprint)?
    };
    if !root.0 {
        let _failed = checkpoint.fail("GearRoot failed")?;
        let receipt = options.output_root.join("gear-build.receipt.tsv");
        atomic_write(
            &receipt,
            render_receipt(&plan, &results, &root, started.elapsed()).as_bytes(),
        )?;
        return Err(format!("GearRoot failed; stderr={}", root.4.display()));
    }
    let completed = checkpoint.succeed()?;
    let progress = completed.progress_path();
    let elapsed = started.elapsed();
    let receipt = options.output_root.join("gear-build.receipt.tsv");
    atomic_write(
        &receipt,
        render_receipt(&plan, &results, &root, elapsed).as_bytes(),
    )?;
    let passed = results
        .iter()
        .filter(|result| result.success && !result.skipped)
        .count();
    let skipped = results.iter().filter(|result| result.skipped).count();
    let failed = results.iter().filter(|result| !result.success).count();
    Ok(GearExecutionReceipt {
        gears: plan.units.len(),
        layers: plan.layers.len(),
        restore_seeded: restore.copied,
        restore_reused: restore.reused,
        restore_invoked: restore.restored_seed,
        restore_receipt: restore.receipt,
        completed: results.len(),
        completed_layers: plan.layers.len(),
        outcome: ExecutionOutcome::Passed,
        passed,
        skipped,
        failed,
        root_built: root.0 && !root.1,
        root_skipped: root.1,
        elapsed,
        progress,
        receipt,
    })
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_gear_artifact_state::artifact_exists;

    fn temp_root(name: &str) -> PathBuf {
        std::env::temp_dir().join(format!(
            "spiral-gear-executor-{name}-{}",
            std::process::id()
        ))
    }

    #[test]
    fn directory_props_are_part_of_unit_freshness() {
        let root = temp_root("directory-props-input");
        fs::create_dir_all(&root).unwrap();
        fs::write(
            root.join("Gear0000.fsproj"),
            "<Project><ItemGroup><Compile Include=\"Part0000.fs\" /></ItemGroup></Project>\n",
        )
        .unwrap();
        fs::write(root.join("Part0000.fs"), "module Part0000\n").unwrap();
        fs::write(root.join("Directory.Build.props"), "<Project />\n").unwrap();
        let inputs = compile_inputs(&root, &root.join("Gear0000.fsproj")).unwrap();
        assert!(inputs.contains(&root.join("Directory.Build.props")));
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn transform_fingerprint_invalidates_plan_and_gear_identity() {
        let root = temp_root("transform-identity");
        fs::create_dir_all(&root).unwrap();
        fs::write(
            root.join("gears.tsv"),
            "gear source_layer source_bytes gear_bytes parts dependencies fingerprint oversize\n0 0 0 0 1 0 0 123 false\n",
        )
        .unwrap();
        fs::write(root.join("GearRoot.fsproj"), "<Project />\n").unwrap();
        fs::write(
            root.join("Gear0000.fsproj"),
            "<Project><ItemGroup><Compile Include=\"Part0000.fs\" /></ItemGroup></Project>\n",
        )
        .unwrap();
        fs::write(root.join("Part0000.fs"), "module Part0000\n").unwrap();
        fs::write(
            root.join("source.receipt.tsv"),
            "key\tvalue\ntransform_fingerprint\t11\n",
        )
        .unwrap();
        let first = load_gear_plan(&root, "Release", Some(0)).unwrap();
        fs::write(
            root.join("source.receipt.tsv"),
            "key\tvalue\ntransform_fingerprint\t12\n",
        )
        .unwrap();
        let second = load_gear_plan(&root, "Release", Some(0)).unwrap();
        assert_ne!(first.identity.fingerprint, second.identity.fingerprint);
        assert_eq!(
            first.units[0].build_fingerprint,
            second.units[0].build_fingerprint
        );
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn plan_rejects_same_layer_dependencies() {
        let plan = GearExecutionPlan {
            output_root: PathBuf::from("out"),
            configuration: "Release".to_owned(),
            units: vec![
                GearUnit {
                    id: 0,
                    layer: 1,
                    dependencies: Vec::new(),
                    source_fingerprint: 1,
                    project: PathBuf::from("a"),
                    inputs: Vec::new(),
                    build_fingerprint: 1,
                    artifact_fingerprint: 1,
                },
                GearUnit {
                    id: 1,
                    layer: 1,
                    dependencies: vec![0],
                    source_fingerprint: 2,
                    project: PathBuf::from("b"),
                    inputs: Vec::new(),
                    build_fingerprint: 2,
                    artifact_fingerprint: 2,
                },
            ],
            layers: BTreeMap::new(),
            identity: PlanIdentity::new(vec![0, 1], 9).unwrap(),
            stage: PhantomData::<Loaded>,
        };
        assert!(plan.validate().unwrap_err().contains("depends on"));
    }

    #[test]
    fn configured_base_output_path_is_the_assembly_authority() {
        let root = temp_root("configured-artifacts");
        let artifacts = temp_root("configured-artifacts-bin");
        let intermediate = temp_root("configured-artifacts-obj");
        let ref_dir = intermediate.join("linux/amd64/Release/net11.0/ref");
        fs::create_dir_all(&root).unwrap();
        fs::create_dir_all(artifacts.join("linux/amd64/Release/net11.0")).unwrap();
        fs::create_dir_all(&ref_dir).unwrap();
        fs::write(
            root.join("Directory.Build.props"),
            format!(
                "<Project><PropertyGroup><BaseOutputPath>{}/</BaseOutputPath><BaseIntermediateOutputPath>{}/</BaseIntermediateOutputPath></PropertyGroup></Project>\n",
                artifacts.display(),
                intermediate.display()
            ),
        )
        .unwrap();
        fs::write(
            artifacts.join("linux/amd64/Release/net11.0/SpiralCompilerGear0007.dll"),
            "dll",
        )
        .unwrap();
        fs::write(ref_dir.join("SpiralCompilerGear0007.dll"), "ref").unwrap();
        fs::write(intermediate.join("project.assets.json"), "assets").unwrap();
        assert!(artifact_exists(&root, ArtifactTarget::Gear { id: 7 }));
        assert!(!artifact_exists(&root, ArtifactTarget::Gear { id: 8 }));
        fs::remove_dir_all(root).unwrap();
        fs::remove_dir_all(artifacts).unwrap();
        fs::remove_dir_all(intermediate).unwrap();
    }
}
