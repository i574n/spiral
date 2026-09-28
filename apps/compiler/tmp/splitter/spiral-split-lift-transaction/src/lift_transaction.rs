use spiral_split_lift_batch::{BatchApplied, BatchRewriteArtifact};
use spiral_split_lift_funnel::{Applied as FunnelApplied, FunnelArtifact};
use spiral_split_lift_rewrite::{Applied, RewriteArtifact};
use spiral_split_match_branch::{Applied as MatchBranchApplied, MatchBranchArtifact};
use spiral_split_model::fnv1a64;
use std::fmt::{Display, Formatter, Write as _};
use std::fs::{self, File};
use std::io::Write;
use std::marker::PhantomData;
use std::path::{Path, PathBuf};

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Prepared;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Committed;

pub trait TransactionArtifact {
    fn original_fingerprint(&self) -> u64;
    fn render_transaction_receipt(&self) -> String;
}

impl TransactionArtifact for RewriteArtifact<Applied> {
    fn original_fingerprint(&self) -> u64 {
        self.original_fingerprint
    }

    fn render_transaction_receipt(&self) -> String {
        RewriteArtifact::<Applied>::render_receipt(self)
    }
}

impl TransactionArtifact for BatchRewriteArtifact<BatchApplied> {
    fn original_fingerprint(&self) -> u64 {
        self.original_fingerprint
    }

    fn render_transaction_receipt(&self) -> String {
        BatchRewriteArtifact::<BatchApplied>::render_receipt(self)
    }
}

impl TransactionArtifact for FunnelArtifact<FunnelApplied> {
    fn original_fingerprint(&self) -> u64 {
        self.original_fingerprint
    }

    fn render_transaction_receipt(&self) -> String {
        FunnelArtifact::<FunnelApplied>::render_receipt(self)
    }
}

impl TransactionArtifact for MatchBranchArtifact<MatchBranchApplied> {
    fn original_fingerprint(&self) -> u64 {
        self.original_fingerprint
    }

    fn render_transaction_receipt(&self) -> String {
        MatchBranchArtifact::<MatchBranchApplied>::render_receipt(self)
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum TransactionBlocker {
    OwnerFingerprintMismatch {
        expected: u64,
        actual: u64,
    },
    Io {
        operation: &'static str,
        path: PathBuf,
        message: String,
    },
    OutputFingerprintMismatch {
        expected: u64,
        actual: u64,
    },
}

impl Display for TransactionBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::OwnerFingerprintMismatch { expected, actual } => {
                write!(formatter, "owner-fingerprint-mismatch:{expected}:{actual}")
            }
            Self::Io {
                operation,
                path,
                message,
            } => {
                write!(formatter, "io:{operation}:{}:{message}", path.display())
            }
            Self::OutputFingerprintMismatch { expected, actual } => {
                write!(formatter, "output-fingerprint-mismatch:{expected}:{actual}")
            }
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct RewriteTransaction<S> {
    pub output: PathBuf,
    pub receipt: PathBuf,
    pub owner_fingerprint: u64,
    pub output_fingerprint: u64,
    pub output_bytes: usize,
    output_text: String,
    receipt_text: String,
    stage: PhantomData<fn() -> S>,
}

fn io(operation: &'static str, path: &Path, error: std::io::Error) -> TransactionBlocker {
    TransactionBlocker::Io {
        operation,
        path: path.to_path_buf(),
        message: error.to_string(),
    }
}

fn temp_path(path: &Path) -> PathBuf {
    let name = path
        .file_name()
        .and_then(|name| name.to_str())
        .unwrap_or("rewrite");
    path.with_file_name(format!(".{name}.spiral-tmp"))
}

fn write_synced(path: &Path, text: &str) -> Result<(), TransactionBlocker> {
    let mut file = File::create(path).map_err(|error| io("create", path, error))?;
    file.write_all(text.as_bytes())
        .map_err(|error| io("write", path, error))?;
    file.sync_all().map_err(|error| io("sync", path, error))
}

fn remove_if_present(path: &Path) {
    if path.exists() {
        let _ = fs::remove_file(path);
    }
}

pub fn prepare_transaction<A: TransactionArtifact>(
    owner_text: &str,
    rewritten_source: String,
    output: PathBuf,
    artifact: &A,
) -> Result<RewriteTransaction<Prepared>, TransactionBlocker> {
    let actual = fnv1a64(owner_text.as_bytes());
    let expected = artifact.original_fingerprint();
    if actual != expected {
        return Err(TransactionBlocker::OwnerFingerprintMismatch { expected, actual });
    }
    let receipt = output.with_extension("rewrite.tsv");
    let output_fingerprint = fnv1a64(rewritten_source.as_bytes());
    let mut receipt_text = artifact.render_transaction_receipt();
    let _ = writeln!(
        receipt_text,
        "transaction output={} output_fingerprint={} output_bytes={} status=prepared",
        output.display(),
        output_fingerprint,
        rewritten_source.len()
    );
    Ok(RewriteTransaction {
        output,
        receipt,
        owner_fingerprint: actual,
        output_fingerprint,
        output_bytes: rewritten_source.len(),
        output_text: rewritten_source,
        receipt_text,
        stage: PhantomData,
    })
}

impl RewriteTransaction<Prepared> {
    pub fn commit(self) -> Result<RewriteTransaction<Committed>, TransactionBlocker> {
        if let Some(parent) = self.output.parent() {
            fs::create_dir_all(parent).map_err(|error| io("mkdir", parent, error))?;
        }
        if let Some(parent) = self.receipt.parent() {
            fs::create_dir_all(parent).map_err(|error| io("mkdir", parent, error))?;
        }
        let output_temp = temp_path(&self.output);
        let receipt_temp = temp_path(&self.receipt);
        remove_if_present(&output_temp);
        remove_if_present(&receipt_temp);
        let mut committed_receipt = self.receipt_text.clone();
        let _ = writeln!(
            committed_receipt,
            "transaction_commit output_fingerprint={} output_bytes={} status=committed",
            self.output_fingerprint, self.output_bytes
        );
        write_synced(&output_temp, &self.output_text)?;
        write_synced(&receipt_temp, &committed_receipt)?;
        fs::rename(&output_temp, &self.output)
            .map_err(|error| io("commit-output", &self.output, error))?;
        if let Err(error) = fs::rename(&receipt_temp, &self.receipt) {
            remove_if_present(&self.output);
            remove_if_present(&receipt_temp);
            return Err(io("commit-receipt", &self.receipt, error));
        }
        let persisted =
            fs::read(&self.output).map_err(|error| io("readback", &self.output, error))?;
        let actual = fnv1a64(&persisted);
        if actual != self.output_fingerprint {
            remove_if_present(&self.output);
            remove_if_present(&self.receipt);
            return Err(TransactionBlocker::OutputFingerprintMismatch {
                expected: self.output_fingerprint,
                actual,
            });
        }
        Ok(RewriteTransaction {
            output: self.output,
            receipt: self.receipt,
            owner_fingerprint: self.owner_fingerprint,
            output_fingerprint: self.output_fingerprint,
            output_bytes: self.output_bytes,
            output_text: self.output_text,
            receipt_text: committed_receipt,
            stage: PhantomData,
        })
    }
}

impl RewriteTransaction<Committed> {
    pub fn rollback(self) -> Result<RewriteTransaction<Prepared>, TransactionBlocker> {
        if self.output.exists() {
            fs::remove_file(&self.output)
                .map_err(|error| io("rollback-output", &self.output, error))?;
        }
        if self.receipt.exists() {
            fs::remove_file(&self.receipt)
                .map_err(|error| io("rollback-receipt", &self.receipt, error))?;
        }
        Ok(RewriteTransaction {
            output: self.output,
            receipt: self.receipt,
            owner_fingerprint: self.owner_fingerprint,
            output_fingerprint: self.output_fingerprint,
            output_bytes: self.output_bytes,
            output_text: self.output_text,
            receipt_text: self.receipt_text,
            stage: PhantomData,
        })
    }

    #[must_use]
    pub fn render_commit_receipt(&self) -> String {
        format!(
            "output={} receipt={} owner_fingerprint={} output_fingerprint={} output_bytes={} status=committed",
            self.output.display(),
            self.receipt.display(),
            self.owner_fingerprint,
            self.output_fingerprint,
            self.output_bytes
        )
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_lift::{LiftDisposition, LocalGroup};
    use spiral_split_lift_plan::{CaptureFlow, ParameterSlot, ParametricComponent};
    use spiral_split_lift_rewrite::rewrite_bounded_owner;
    use spiral_split_model::{
        BoundaryReason, Declaration, DeclarationId, DeclarationKind, LineSpan, Linked, Raw,
    };
    use std::collections::BTreeSet;
    use std::sync::atomic::{AtomicUsize, Ordering};

    static NEXT: AtomicUsize = AtomicUsize::new(0);

    fn set(values: &[&str]) -> BTreeSet<String> {
        values.iter().map(|value| (*value).to_owned()).collect()
    }

    fn fixture() -> (Declaration<Linked>, LocalGroup, ParametricComponent) {
        let text = "let outer env value =
    let helper x = env + x
    helper value
";
        let owner = Declaration::<Raw>::new(
            DeclarationId(0),
            LineSpan { start: 0, end: 3 },
            "let outer env value =".to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
        .restage();
        let group = LocalGroup {
            owner: DeclarationId(0),
            owner_heading: "let outer env value =".to_owned(),
            local_index: 0,
            start_line: 1,
            end_line: 2,
            line_count: 1,
            names: set(&["helper"]),
            parameters: set(&["x"]),
            references: set(&["env"]),
            captures: set(&["env"]),
            local_dependencies: BTreeSet::new(),
            disposition: LiftDisposition::Captures(set(&["env"])),
        };
        let component = ParametricComponent {
            owner: DeclarationId(0),
            component: 0,
            members: vec![0],
            names: set(&["helper"]),
            dependencies: BTreeSet::new(),
            line_count: 1,
            start_line: 1,
            end_line: 2,
            direct_captures: set(&["env"]),
            effective_captures: set(&["env"]),
            parameters: vec![ParameterSlot {
                ordinal: 0,
                name: "env".to_owned(),
                flow: CaptureFlow::Direct {
                    parameter: "env".to_owned(),
                },
            }],
            recursive: false,
            blocker: None,
            intents: Vec::new(),
        };
        (owner, group, component)
    }

    fn root() -> PathBuf {
        std::env::temp_dir().join(format!(
            "spiral-lift-transaction-{}-{}",
            std::process::id(),
            NEXT.fetch_add(1, Ordering::Relaxed)
        ))
    }

    #[test]
    fn commits_and_rolls_back_atomically() {
        let (owner, group, component) = fixture();
        let artifact = rewrite_bounded_owner(&owner, 0, &group, &component).expect("rewrite");
        let dir = root();
        let output = dir.join("after.fsx");
        let transaction = prepare_transaction(
            &owner.text,
            artifact.full_text.clone(),
            output.clone(),
            &artifact,
        )
        .expect("prepare");
        let committed = transaction.commit().expect("commit");
        assert!(output.is_file());
        assert!(committed.receipt.is_file());
        assert!(
            committed
                .render_commit_receipt()
                .contains("status=committed")
        );
        let persisted_receipt = fs::read_to_string(&committed.receipt).expect("receipt");
        assert!(persisted_receipt.contains("transaction_commit"));
        assert!(persisted_receipt.contains("status=committed"));
        let prepared = committed.rollback().expect("rollback");
        assert!(!prepared.output.exists());
        assert!(!prepared.receipt.exists());
        let _ = fs::remove_dir_all(dir);
    }

    #[test]
    fn rejects_stale_owner_fingerprint() {
        let (owner, group, component) = fixture();
        let artifact = rewrite_bounded_owner(&owner, 0, &group, &component).expect("rewrite");
        let error = prepare_transaction(
            "different",
            artifact.full_text.clone(),
            root().join("after.fsx"),
            &artifact,
        )
        .expect_err("stale");
        assert!(matches!(
            error,
            TransactionBlocker::OwnerFingerprintMismatch { .. }
        ));
    }
}
