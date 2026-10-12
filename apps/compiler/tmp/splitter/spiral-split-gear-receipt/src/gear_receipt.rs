use std::path::PathBuf;
use std::time::Duration;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ExecutionOutcome {
    Passed,
    Failed,
    Yielded,
}

impl ExecutionOutcome {
    pub fn status(self) -> &'static str {
        match self {
            Self::Passed => "pass",
            Self::Failed => "fail",
            Self::Yielded => "yield",
        }
    }

    pub fn cli_status(self) -> &'static str {
        match self {
            Self::Passed => "passed",
            Self::Failed => "failed",
            Self::Yielded => "yielded",
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearUnitResult {
    pub id: usize,
    pub layer: usize,
    pub success: bool,
    pub skipped: bool,
    pub elapsed: Duration,
    pub stdout: PathBuf,
    pub stderr: PathBuf,
}

#[derive(Clone, Debug)]
pub struct GearExecutionReceipt {
    pub gears: usize,
    pub layers: usize,
    pub restore_seeded: usize,
    pub restore_reused: usize,
    pub restore_invoked: bool,
    pub restore_receipt: PathBuf,
    pub completed: usize,
    pub completed_layers: usize,
    pub outcome: ExecutionOutcome,
    pub passed: usize,
    pub skipped: usize,
    pub failed: usize,
    pub root_built: bool,
    pub root_skipped: bool,
    pub elapsed: Duration,
    pub progress: PathBuf,
    pub receipt: PathBuf,
}

pub type RootExecutionResult = (bool, bool, Duration, PathBuf, PathBuf);

pub fn render_receipt(
    total_gears: usize,
    total_layers: usize,
    results: &[GearUnitResult],
    root: &RootExecutionResult,
    elapsed: Duration,
    outcome: ExecutionOutcome,
) -> String {
    let passed = results
        .iter()
        .filter(|result| result.success && !result.skipped)
        .count();
    let skipped = results.iter().filter(|result| result.skipped).count();
    let failed = results.iter().filter(|result| !result.success).count();
    let root_status = match outcome {
        ExecutionOutcome::Yielded => "deferred",
        _ if root.1 => "skip",
        _ if root.0 => "pass",
        _ => "fail",
    };
    let mut output = format!(
        "key value\nstatus {}\ngears {}\nlayers {}\ncompleted {}\npassed {}\nskipped {}\nfailed {}\nroot_status {}\nroot_skipped {}\nelapsed_ms {:.3}\n\ngear layer status elapsed_ms stdout stderr\n",
        outcome.status(),
        total_gears,
        total_layers,
        results.len(),
        passed,
        skipped,
        failed,
        root_status,
        root.1,
        elapsed.as_secs_f64() * 1000.0,
    );
    for result in results {
        output.push_str(&format!(
            "{} {} {} {:.3} {} {}\n",
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
        "root - {} {:.3} {} {}\n",
        root_status,
        root.2.as_secs_f64() * 1000.0,
        root.3.display(),
        root.4.display(),
    ));
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn yielded_receipt_is_not_reported_as_failure() {
        let root = (
            false,
            false,
            Duration::ZERO,
            PathBuf::from("root.stdout"),
            PathBuf::from("root.stderr"),
        );
        let text = render_receipt(
            3,
            2,
            &[],
            &root,
            Duration::from_millis(4),
            ExecutionOutcome::Yielded,
        );
        assert!(text.contains("status yield"));
        assert!(text.contains("root_status deferred"));
        assert!(text.contains("completed 0"));
    }
}
