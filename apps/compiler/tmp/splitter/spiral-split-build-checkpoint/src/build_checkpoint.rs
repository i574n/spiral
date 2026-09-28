use std::collections::BTreeSet;
use std::fs;
use std::marker::PhantomData;
use std::path::{Path, PathBuf};
use std::time::Duration;

pub enum Running {}
pub enum Succeeded {}
pub enum Failed {}
pub enum Yielded {}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct PlanIdentity {
    pub targets: Vec<usize>,
    pub fingerprint: u64,
}

impl PlanIdentity {
    pub fn new(mut targets: Vec<usize>, fingerprint: u64) -> Result<Self, String> {
        targets.sort_unstable();
        targets.dedup();
        if targets.is_empty() {
            return Err("checkpoint identity requires at least one target".to_owned());
        }
        Ok(Self {
            targets,
            fingerprint,
        })
    }

    fn target_text(&self) -> String {
        self.targets
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(",")
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct FailureRef {
    pub shard: usize,
    pub stderr: PathBuf,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum LayerOutcome {
    Passed {
        passed: usize,
        skipped: usize,
    },
    Failed {
        passed: usize,
        skipped: usize,
        failures: Vec<FailureRef>,
    },
}

impl LayerOutcome {
    fn passed(&self) -> usize {
        match self {
            Self::Passed { passed, .. } | Self::Failed { passed, .. } => *passed,
        }
    }

    fn skipped(&self) -> usize {
        match self {
            Self::Passed { skipped, .. } | Self::Failed { skipped, .. } => *skipped,
        }
    }

    fn failed(&self) -> usize {
        match self {
            Self::Passed { .. } => 0,
            Self::Failed { failures, .. } => failures.len(),
        }
    }

    fn status(&self) -> &'static str {
        match self {
            Self::Passed { .. } => "pass",
            Self::Failed { .. } => "fail",
        }
    }

    fn failures_text(&self) -> String {
        match self {
            Self::Passed { .. } => "-".to_owned(),
            Self::Failed { failures, .. } => failures
                .iter()
                .map(|failure| format!("{}:{}", failure.shard, failure.stderr.display()))
                .collect::<Vec<_>>()
                .join(";"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LayerCommit {
    pub layer: usize,
    pub shards: Vec<usize>,
    pub elapsed: Duration,
    pub outcome: LayerOutcome,
}

impl LayerCommit {
    pub fn passed(
        layer: usize,
        mut shards: Vec<usize>,
        passed: usize,
        skipped: usize,
        elapsed: Duration,
    ) -> Result<Self, String> {
        normalize_shards(&mut shards)?;
        if passed + skipped != shards.len() {
            return Err(format!(
                "layer {layer}: passed {passed} + skipped {skipped} != shards {}",
                shards.len()
            ));
        }
        Ok(Self {
            layer,
            shards,
            elapsed,
            outcome: LayerOutcome::Passed { passed, skipped },
        })
    }

    pub fn failed(
        layer: usize,
        mut shards: Vec<usize>,
        passed: usize,
        skipped: usize,
        mut failures: Vec<FailureRef>,
        elapsed: Duration,
    ) -> Result<Self, String> {
        normalize_shards(&mut shards)?;
        failures.sort_by_key(|failure| failure.shard);
        let unique_failures = failures
            .iter()
            .map(|failure| failure.shard)
            .collect::<BTreeSet<_>>();
        if unique_failures.len() != failures.len() {
            return Err(format!("layer {layer}: duplicate failed shard"));
        }
        if failures.is_empty() {
            return Err(format!("layer {layer}: failed outcome requires failures"));
        }
        if passed + skipped + failures.len() != shards.len() {
            return Err(format!(
                "layer {layer}: passed {passed} + skipped {skipped} + failed {} != shards {}",
                failures.len(),
                shards.len()
            ));
        }
        Ok(Self {
            layer,
            shards,
            elapsed,
            outcome: LayerOutcome::Failed {
                passed,
                skipped,
                failures,
            },
        })
    }

    fn attempted(&self) -> usize {
        self.shards.len()
    }
}

fn normalize_shards(shards: &mut Vec<usize>) -> Result<(), String> {
    if shards.is_empty() {
        return Err("layer checkpoint requires at least one shard".to_owned());
    }
    shards.sort_unstable();
    let before = shards.len();
    shards.dedup();
    if shards.len() != before {
        return Err("layer checkpoint contains duplicate shards".to_owned());
    }
    Ok(())
}

#[derive(Clone, Debug)]
pub struct CheckpointSession<S> {
    output_root: PathBuf,
    session_dir: PathBuf,
    identity: PlanIdentity,
    selected: Vec<usize>,
    commits: Vec<LayerCommit>,
    note: String,
    stage: PhantomData<S>,
}

impl CheckpointSession<Running> {
    pub fn begin(
        output_root: &Path,
        identity: PlanIdentity,
        mut selected: Vec<usize>,
    ) -> Result<Self, String> {
        selected.sort_unstable();
        selected.dedup();
        let session_dir = output_root
            .join(".build-cache/checkpoints")
            .join(format!("{:016x}", identity.fingerprint));
        fs::create_dir_all(&session_dir)
            .map_err(|error| format!("create {}: {error}", session_dir.display()))?;
        let commits = load_commits(&session_dir.join("session.tsv"), &identity)?;
        let session = Self {
            output_root: output_root.to_path_buf(),
            session_dir,
            identity,
            selected,
            commits,
            note: "running".to_owned(),
            stage: PhantomData,
        };
        session.persist("running")?;
        Ok(session)
    }

    pub fn record_layer(mut self, commit: LayerCommit) -> Result<Self, String> {
        if let Some(previous) = self.commits.iter().find(|item| item.layer == commit.layer)
            && previous == &commit
        {
            self.persist("running")?;
            return Ok(self);
        }
        let superseded = self
            .commits
            .iter()
            .filter(|item| item.layer >= commit.layer)
            .map(|item| item.layer)
            .collect::<Vec<_>>();
        for layer in superseded {
            let path = self.session_dir.join(format!("layer-{layer:04}.tsv"));
            if path.exists() {
                fs::remove_file(&path)
                    .map_err(|error| format!("remove {}: {error}", path.display()))?;
            }
        }
        self.commits.retain(|item| item.layer < commit.layer);
        let layer_path = self
            .session_dir
            .join(format!("layer-{:04}.tsv", commit.layer));
        atomic_write(
            &layer_path,
            render_layer(&self.identity, &commit).as_bytes(),
        )?;
        self.commits.push(commit);
        self.persist("running")?;
        Ok(self)
    }

    pub fn succeed(self) -> Result<CheckpointSession<Succeeded>, String> {
        self.close::<Succeeded>("succeeded")
    }

    pub fn yield_now(
        mut self,
        note: impl Into<String>,
    ) -> Result<CheckpointSession<Yielded>, String> {
        self.note = sanitize(&note.into());
        self.close::<Yielded>("yielded")
    }

    pub fn fail(mut self, note: impl Into<String>) -> Result<CheckpointSession<Failed>, String> {
        self.note = sanitize(&note.into());
        self.close::<Failed>("failed")
    }

    fn close<T>(mut self, status: &str) -> Result<CheckpointSession<T>, String> {
        if self.note == "running" {
            self.note = status.to_owned();
        }
        self.persist(status)?;
        Ok(CheckpointSession {
            output_root: self.output_root,
            session_dir: self.session_dir,
            identity: self.identity,
            selected: self.selected,
            commits: self.commits,
            note: self.note,
            stage: PhantomData,
        })
    }
}

impl<S> CheckpointSession<S> {
    pub fn progress_path(&self) -> PathBuf {
        self.output_root.join("build-targets.progress.tsv")
    }

    pub fn session_path(&self) -> PathBuf {
        self.session_dir.join("session.tsv")
    }

    pub fn committed_layers(&self) -> usize {
        self.commits.len()
    }

    fn persist(&self, status: &str) -> Result<(), String> {
        let text = render_session(self, status);
        atomic_write(&self.session_path(), text.as_bytes())?;
        atomic_write(&self.progress_path(), text.as_bytes())
    }
}

pub fn fingerprint_inputs(signature: &str, paths: &[PathBuf]) -> Result<u64, String> {
    let mut sorted = paths.to_vec();
    sorted.sort();
    sorted.dedup();
    let mut hash = fnv1a(0xcbf29ce484222325, signature.as_bytes());
    for path in sorted {
        hash = fnv1a(hash, path.to_string_lossy().as_bytes());
        let bytes = fs::read(&path).map_err(|error| format!("read {}: {error}", path.display()))?;
        hash = fnv1a(hash, &(bytes.len() as u64).to_le_bytes());
        hash = fnv1a(hash, &bytes);
    }
    Ok(hash)
}

pub fn fingerprint_inputs_relative(
    root: &Path,
    signature: &str,
    paths: &[PathBuf],
) -> Result<u64, String> {
    let mut logical = paths
        .iter()
        .map(|path| {
            let relative = path.strip_prefix(root).map_err(|error| {
                format!(
                    "fingerprint input {} is outside root {}: {error}",
                    path.display(),
                    root.display()
                )
            })?;
            Ok((relative.to_path_buf(), path.clone()))
        })
        .collect::<Result<Vec<_>, String>>()?;
    logical.sort_by(|left, right| left.0.cmp(&right.0));
    logical.dedup_by(|left, right| left.0 == right.0);
    let mut hash = fnv1a(0xcbf29ce484222325, signature.as_bytes());
    for (relative, path) in logical {
        let logical_name = relative.to_string_lossy().replace('\\', "/");
        hash = fnv1a(hash, logical_name.as_bytes());
        let bytes = fs::read(&path).map_err(|error| format!("read {}: {error}", path.display()))?;
        hash = fnv1a(hash, &(bytes.len() as u64).to_le_bytes());
        hash = fnv1a(hash, &bytes);
    }
    Ok(hash)
}

fn fnv1a(mut hash: u64, bytes: &[u8]) -> u64 {
    for byte in bytes {
        hash ^= u64::from(*byte);
        hash = hash.wrapping_mul(0x100000001b3);
    }
    hash
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

fn sanitize(value: &str) -> String {
    value
        .chars()
        .map(|character| match character as u32 {
            9 | 10 | 13 => ' ',
            _ => character,
        })
        .collect()
}

fn separator() -> char {
    char::from(9)
}

fn newline() -> char {
    char::from(10)
}

fn push_fields(output: &mut String, fields: &[String]) {
    let separator = separator().to_string();
    output.push_str(&fields.join(&separator));
    output.push(newline());
}

fn commit_fields(commit: &LayerCommit) -> Vec<String> {
    vec![
        commit.layer.to_string(),
        commit.outcome.status().to_owned(),
        commit
            .shards
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(","),
        commit.attempted().to_string(),
        commit.outcome.passed().to_string(),
        commit.outcome.skipped().to_string(),
        commit.outcome.failed().to_string(),
        format!("{:.3}", commit.elapsed.as_secs_f64() * 1000.0),
        commit.outcome.failures_text(),
    ]
}

fn render_layer(identity: &PlanIdentity, commit: &LayerCommit) -> String {
    let mut output = String::new();
    push_fields(
        &mut output,
        &[
            "fingerprint".to_owned(),
            "targets".to_owned(),
            "layer".to_owned(),
            "status".to_owned(),
            "shards".to_owned(),
            "attempted".to_owned(),
            "passed".to_owned(),
            "skipped".to_owned(),
            "failed".to_owned(),
            "elapsed_ms".to_owned(),
            "failures".to_owned(),
        ],
    );
    let mut row = vec![
        format!("{:016x}", identity.fingerprint),
        identity.target_text(),
    ];
    row.extend(commit_fields(commit));
    push_fields(&mut output, &row);
    output
}

fn render_session<S>(session: &CheckpointSession<S>, status: &str) -> String {
    let attempted = session
        .commits
        .iter()
        .map(LayerCommit::attempted)
        .sum::<usize>();
    let passed = session
        .commits
        .iter()
        .map(|commit| commit.outcome.passed())
        .sum::<usize>();
    let skipped = session
        .commits
        .iter()
        .map(|commit| commit.outcome.skipped())
        .sum::<usize>();
    let failed = session
        .commits
        .iter()
        .map(|commit| commit.outcome.failed())
        .sum::<usize>();
    let selected = session
        .selected
        .iter()
        .map(usize::to_string)
        .collect::<Vec<_>>()
        .join(",");
    let mut output = String::new();
    for (key, value) in [
        ("key", "value".to_owned()),
        ("status", status.to_owned()),
        ("note", sanitize(&session.note)),
        (
            "fingerprint",
            format!("{:016x}", session.identity.fingerprint),
        ),
        ("targets", session.identity.target_text()),
        ("selected_current", selected),
        ("committed_layers", session.commits.len().to_string()),
        ("attempted", attempted.to_string()),
        ("passed", passed.to_string()),
        ("skipped", skipped.to_string()),
        ("failed", failed.to_string()),
    ] {
        push_fields(&mut output, &[key.to_owned(), value]);
    }
    output.push(newline());
    push_fields(
        &mut output,
        &[
            "layer".to_owned(),
            "status".to_owned(),
            "shards".to_owned(),
            "attempted".to_owned(),
            "passed".to_owned(),
            "skipped".to_owned(),
            "failed".to_owned(),
            "elapsed_ms".to_owned(),
            "failures".to_owned(),
        ],
    );
    for commit in &session.commits {
        push_fields(&mut output, &commit_fields(commit));
    }
    output
}

fn load_commits(path: &Path, identity: &PlanIdentity) -> Result<Vec<LayerCommit>, String> {
    let Ok(text) = fs::read_to_string(path) else {
        return Ok(Vec::new());
    };
    let expected_fingerprint = format!("{:016x}", identity.fingerprint);
    let expected_targets = identity.target_text();
    let mut fingerprint_matches = false;
    let mut targets_match = false;
    let mut rows = false;
    let mut commits = Vec::new();
    for line in text.lines() {
        let fields = line.split(separator()).collect::<Vec<_>>();
        if fields.len() == 2 && fields[0] == "fingerprint" {
            fingerprint_matches = fields[1] == expected_fingerprint;
            continue;
        }
        if fields.len() == 2 && fields[0] == "targets" {
            targets_match = fields[1] == expected_targets;
            continue;
        }
        if fields.first() == Some(&"layer") && fields.get(1) == Some(&"status") {
            rows = true;
            continue;
        }
        if rows && !line.trim().is_empty() {
            commits.push(parse_commit(&fields)?);
        }
    }
    if !fingerprint_matches || !targets_match {
        return Ok(Vec::new());
    }
    commits.sort_by_key(|commit| commit.layer);
    let unique = commits
        .iter()
        .map(|commit| commit.layer)
        .collect::<BTreeSet<_>>();
    if unique.len() != commits.len() {
        return Err(format!("duplicate layers in {}", path.display()));
    }
    Ok(commits)
}

fn parse_commit(fields: &[&str]) -> Result<LayerCommit, String> {
    if fields.len() != 9 {
        return Err(format!(
            "invalid checkpoint row with {} fields",
            fields.len()
        ));
    }
    let parse = |value: &str, name: &str| {
        value
            .parse::<usize>()
            .map_err(|error| format!("invalid {name} {value:?}: {error}"))
    };
    let layer = parse(fields[0], "layer")?;
    let shards = if fields[2].is_empty() {
        Vec::new()
    } else {
        fields[2]
            .split(',')
            .map(|value| parse(value, "shard"))
            .collect::<Result<Vec<_>, _>>()?
    };
    let attempted = parse(fields[3], "attempted")?;
    let passed = parse(fields[4], "passed")?;
    let skipped = parse(fields[5], "skipped")?;
    let failed = parse(fields[6], "failed")?;
    let elapsed = Duration::from_secs_f64(
        fields[7]
            .parse::<f64>()
            .map_err(|error| format!("invalid elapsed_ms {:?}: {error}", fields[7]))?
            / 1000.0,
    );
    if attempted != shards.len() {
        return Err(format!(
            "layer {layer}: attempted count does not match shards"
        ));
    }
    match fields[1] {
        "pass" if failed == 0 => LayerCommit::passed(layer, shards, passed, skipped, elapsed),
        "fail" if failed > 0 => {
            let failures = fields[8]
                .split(';')
                .filter(|value| *value != "-" && !value.is_empty())
                .map(|value| {
                    let (shard, stderr) = value
                        .split_once(':')
                        .ok_or_else(|| format!("invalid failure reference {value:?}"))?;
                    Ok(FailureRef {
                        shard: parse(shard, "failed shard")?,
                        stderr: PathBuf::from(stderr),
                    })
                })
                .collect::<Result<Vec<_>, String>>()?;
            if failures.len() != failed {
                return Err(format!("layer {layer}: failure count mismatch"));
            }
            LayerCommit::failed(layer, shards, passed, skipped, failures, elapsed)
        }
        status => Err(format!("invalid checkpoint status {status:?}")),
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use std::time::{SystemTime, UNIX_EPOCH};

    fn temp_root(name: &str) -> PathBuf {
        let nonce = SystemTime::now()
            .duration_since(UNIX_EPOCH)
            .unwrap()
            .as_nanos();
        std::env::temp_dir().join(format!("spiral-checkpoint-{name}-{nonce}"))
    }

    fn field(key: &str, value: &str) -> String {
        format!("{key}{}{value}", separator())
    }

    #[test]
    fn each_layer_is_persisted_before_session_completion() {
        let root = temp_root("durable");
        let identity = PlanIdentity::new(vec![9], 42).unwrap();
        let session = CheckpointSession::begin(&root, identity, vec![1, 2]).unwrap();
        let session = session
            .record_layer(LayerCommit::passed(0, vec![1], 1, 0, Duration::from_millis(4)).unwrap())
            .unwrap();
        let progress = fs::read_to_string(session.progress_path()).unwrap();
        assert!(progress.contains(&field("status", "running")));
        assert!(progress.contains(&field("committed_layers", "1")));
        assert!(session.session_dir.join("layer-0000.tsv").is_file());
        let done = session.succeed().unwrap();
        assert!(
            fs::read_to_string(done.progress_path())
                .unwrap()
                .contains(&field("status", "succeeded"))
        );
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn rerun_recovers_committed_layers_for_same_plan() {
        let root = temp_root("resume");
        let identity = PlanIdentity::new(vec![7], 77).unwrap();
        let session = CheckpointSession::begin(&root, identity.clone(), vec![2, 3]).unwrap();
        let _running = session
            .record_layer(LayerCommit::passed(2, vec![2], 1, 0, Duration::from_millis(2)).unwrap())
            .unwrap();
        let resumed = CheckpointSession::begin(&root, identity, vec![3]).unwrap();
        assert_eq!(resumed.committed_layers(), 1);
        let resumed = resumed
            .record_layer(LayerCommit::passed(3, vec![3], 1, 0, Duration::from_millis(3)).unwrap())
            .unwrap();
        assert_eq!(resumed.committed_layers(), 2);
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn rebuilding_an_earlier_layer_truncates_newer_receipts() {
        let root = temp_root("truncate");
        let identity = PlanIdentity::new(vec![7], 78).unwrap();
        let session = CheckpointSession::begin(&root, identity.clone(), vec![2, 3]).unwrap();
        let session = session
            .record_layer(LayerCommit::passed(2, vec![2], 1, 0, Duration::from_millis(2)).unwrap())
            .unwrap()
            .record_layer(LayerCommit::passed(3, vec![3], 1, 0, Duration::from_millis(3)).unwrap())
            .unwrap();
        assert_eq!(session.committed_layers(), 2);
        let resumed = CheckpointSession::begin(&root, identity, vec![2, 3])
            .unwrap()
            .record_layer(LayerCommit::passed(2, vec![2], 1, 0, Duration::from_millis(9)).unwrap())
            .unwrap();
        assert_eq!(resumed.committed_layers(), 1);
        assert!(!resumed.session_dir.join("layer-0003.tsv").exists());
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn failed_layer_records_stderr_evidence() {
        let root = temp_root("failure");
        let identity = PlanIdentity::new(vec![3], 99).unwrap();
        let session = CheckpointSession::begin(&root, identity, vec![3]).unwrap();
        let failure = FailureRef {
            shard: 3,
            stderr: root.join("Part0003.stderr"),
        };
        let session = session
            .record_layer(
                LayerCommit::failed(1, vec![3], 0, 0, vec![failure], Duration::from_millis(8))
                    .unwrap(),
            )
            .unwrap();
        let failed = session.fail("compile failed").unwrap();
        let progress = fs::read_to_string(failed.progress_path()).unwrap();
        assert!(progress.contains(&field("status", "failed")));
        assert!(progress.contains("3:"));
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn fingerprints_change_with_input_bytes() {
        let root = temp_root("fingerprint");
        fs::create_dir_all(&root).unwrap();
        let input = root.join("input.fs");
        fs::write(&input, "let x = 1").unwrap();
        let first = fingerprint_inputs("targets=1", std::slice::from_ref(&input)).unwrap();
        fs::write(&input, "let x = 2").unwrap();
        let second = fingerprint_inputs("targets=1", &[input]).unwrap();
        assert_ne!(first, second);
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn relative_fingerprints_ignore_workspace_location() {
        let first_root = temp_root("relative-a");
        let second_root = temp_root("relative-b");
        fs::create_dir_all(&first_root).unwrap();
        fs::create_dir_all(&second_root).unwrap();
        let first_input = first_root.join("input.fs");
        let second_input = second_root.join("input.fs");
        fs::write(&first_input, "let x = 1").unwrap();
        fs::write(&second_input, "let x = 1").unwrap();
        let first = fingerprint_inputs_relative(&first_root, "targets=1", &[first_input]).unwrap();
        let second = fingerprint_inputs_relative(
            &second_root,
            "targets=1",
            std::slice::from_ref(&second_input),
        )
        .unwrap();
        assert_eq!(first, second);
        fs::write(&second_input, "let x = 2").unwrap();
        let changed =
            fingerprint_inputs_relative(&second_root, "targets=1", &[second_input]).unwrap();
        assert_ne!(first, changed);
        fs::remove_dir_all(first_root).unwrap();
        fs::remove_dir_all(second_root).unwrap();
    }
}
