use std::time::Duration;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum Stage {
    Gears,
    Build,
}

impl Stage {
    pub const fn name(self) -> &'static str {
        match self {
            Self::Gears => "gears",
            Self::Build => "build",
        }
    }

    pub fn parse(value: &str) -> Option<Self> {
        match value {
            "gears" => Some(Self::Gears),
            "build" => Some(Self::Build),
            _ => None,
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum StageStatus {
    Passed,
    Yielded,
    Failed,
}

impl StageStatus {
    pub const fn name(self) -> &'static str {
        match self {
            Self::Passed => "pass",
            Self::Yielded => "yield",
            Self::Failed => "fail",
        }
    }

    pub fn parse(value: &str) -> Option<Self> {
        match value {
            "pass" => Some(Self::Passed),
            "yield" => Some(Self::Yielded),
            "fail" => Some(Self::Failed),
            _ => None,
        }
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum MatrixStatus {
    Running,
    Yielded,
    Failed,
    Passed,
}

impl MatrixStatus {
    pub const fn name(self) -> &'static str {
        match self {
            Self::Running => "running",
            Self::Yielded => "yield",
            Self::Failed => "fail",
            Self::Passed => "pass",
        }
    }

    pub const fn after_stage(status: StageStatus) -> Self {
        match status {
            StageStatus::Passed => Self::Running,
            StageStatus::Yielded => Self::Yielded,
            StageStatus::Failed => Self::Failed,
        }
    }

    pub fn parse(value: &str) -> Option<Self> {
        match value {
            "running" => Some(Self::Running),
            "yield" => Some(Self::Yielded),
            "fail" => Some(Self::Failed),
            "pass" => Some(Self::Passed),
            _ => None,
        }
    }
}

#[derive(Clone, Debug, PartialEq)]
pub struct StageReceipt {
    pub lane: String,
    pub stage: Stage,
    pub status: StageStatus,
    pub elapsed: Duration,
    pub stdout_bytes: usize,
    pub stderr_bytes: usize,
    pub note: String,
}

#[derive(Clone, Copy, Debug)]
pub struct MatrixReceipt<'a> {
    pub identity: &'a str,
    pub status: MatrixStatus,
    pub lanes: usize,
    pub completed_lanes: usize,
    pub current_lane: &'a str,
    pub current_stage: &'a str,
    pub elapsed: Duration,
    pub rows: &'a [StageReceipt],
}

fn sanitize_note(value: &str) -> String {
    value
        .chars()
        .map(|character| {
            if matches!(character, '\t' | '\r' | '\n') {
                ' '
            } else {
                character
            }
        })
        .take(600)
        .collect()
}

impl<'a> MatrixReceipt<'a> {
    pub const fn new(
        identity: &'a str,
        status: MatrixStatus,
        progress: (usize, usize),
        cursor: (&'a str, &'a str),
        elapsed: Duration,
        rows: &'a [StageReceipt],
    ) -> Self {
        Self {
            identity,
            status,
            lanes: progress.0,
            completed_lanes: progress.1,
            current_lane: cursor.0,
            current_stage: cursor.1,
            elapsed,
            rows,
        }
    }

    pub fn render(self) -> String {
        let mut out = String::new();
        out.push_str("key\tvalue\n");
        out.push_str(&format!("identity\t{}\n", self.identity));
        out.push_str(&format!("status\t{}\n", self.status.name()));
        out.push_str(&format!("lanes\t{}\n", self.lanes));
        out.push_str(&format!("completed_lanes\t{}\n", self.completed_lanes));
        out.push_str(&format!("current_lane\t{}\n", self.current_lane));
        out.push_str(&format!("current_stage\t{}\n", self.current_stage));
        out.push_str(&format!(
            "elapsed_ms\t{:.3}\n",
            self.elapsed.as_secs_f64() * 1000.0
        ));
        out.push_str("\nlane\tstage\tstatus\telapsed_ms\tstdout_bytes\tstderr_bytes\tnote\n");
        for row in self.rows {
            out.push_str(&format!(
                "{}\t{}\t{}\t{:.3}\t{}\t{}\t{}\n",
                row.lane,
                row.stage.name(),
                row.status.name(),
                row.elapsed.as_secs_f64() * 1000.0,
                row.stdout_bytes,
                row.stderr_bytes,
                sanitize_note(&row.note),
            ));
        }
        out
    }
}

pub fn parse_resume_rows(text: &str, identity: &str) -> Vec<StageReceipt> {
    let stored_identity = text.lines().find_map(|line| {
        let mut fields = line.split('\t');
        (fields.next() == Some("identity")).then(|| fields.next().unwrap_or_default())
    });
    if stored_identity != Some(identity) {
        return Vec::new();
    }
    let Some(header) = text
        .lines()
        .position(|line| line.starts_with("lane\tstage\tstatus\t"))
    else {
        return Vec::new();
    };
    text.lines()
        .skip(header + 1)
        .filter_map(|line| {
            let fields = line.split('\t').collect::<Vec<_>>();
            if fields.len() != 7 {
                return None;
            }
            Some(StageReceipt {
                lane: fields[0].to_owned(),
                stage: Stage::parse(fields[1])?,
                status: StageStatus::parse(fields[2])?,
                elapsed: Duration::from_secs_f64(fields[3].parse::<f64>().ok()? / 1000.0),
                stdout_bytes: fields[4].parse().ok()?,
                stderr_bytes: fields[5].parse().ok()?,
                note: fields[6].to_owned(),
            })
        })
        .collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn receipt_roundtrip_preserves_terminal_rows() {
        let rows = vec![StageReceipt {
            lane: "base".to_owned(),
            stage: Stage::Build,
            status: StageStatus::Passed,
            elapsed: Duration::from_millis(12),
            stdout_bytes: 3,
            stderr_bytes: 4,
            note: "ok\nwith newline".to_owned(),
        }];
        let text = MatrixReceipt {
            identity: "abc",
            status: MatrixStatus::Yielded,
            lanes: 3,
            completed_lanes: 1,
            current_lane: "portable",
            current_stage: Stage::Build.name(),
            elapsed: Duration::from_millis(20),
            rows: &rows,
        }
        .render();
        assert!(text.contains("status\tyield\n"));
        assert!(text.contains("ok with newline"));
        let mut expected = rows;
        expected[0].note = "ok with newline".to_owned();
        assert_eq!(parse_resume_rows(&text, "abc"), expected);
        assert!(parse_resume_rows(&text, "other").is_empty());
    }

    #[test]
    fn stage_status_maps_to_matrix_status() {
        assert_eq!(
            MatrixStatus::after_stage(StageStatus::Passed),
            MatrixStatus::Running
        );
        assert_eq!(
            MatrixStatus::after_stage(StageStatus::Yielded),
            MatrixStatus::Yielded
        );
        assert_eq!(
            MatrixStatus::after_stage(StageStatus::Failed),
            MatrixStatus::Failed
        );
    }
}
