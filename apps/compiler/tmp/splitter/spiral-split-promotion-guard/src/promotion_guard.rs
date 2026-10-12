use std::env;
use std::fs;
use std::marker::PhantomData;
use std::path::Path;

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
struct GearPerformance {
    critical_path_lines: usize,
    barrier_critical_lines: usize,
    max_gear_lines: usize,
    cyclic_sccs: usize,
}

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
struct Unchecked;

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
struct Compared;

#[derive(Debug, Clone, Copy, PartialEq, Eq)]
struct PromotionEvidence<State> {
    authority: GearPerformance,
    candidate: GearPerformance,
    _state: PhantomData<State>,
}

#[derive(Debug, Clone, PartialEq, Eq)]
enum PromotionBlocker {
    CyclicScc { candidate: usize },
    CriticalPathRegression { authority: usize, candidate: usize },
    BarrierRegression { authority: usize, candidate: usize },
    MaxGearRegression { authority: usize, candidate: usize },
}

#[derive(Debug, Clone, PartialEq, Eq)]
enum PromotionDecision {
    Promote(PromotionEvidence<Compared>),
    Reject {
        evidence: PromotionEvidence<Compared>,
        blockers: Vec<PromotionBlocker>,
    },
}

fn metric(text: &str, name: &str) -> Result<usize, String> {
    text.lines()
        .filter_map(|line| {
            let mut cells = line.split_whitespace();
            let key = cells.next()?;
            let value = cells.next()?;
            (key == name).then_some(value)
        })
        .next()
        .ok_or_else(|| format!("missing metric: {name}"))?
        .parse::<usize>()
        .map_err(|error| format!("invalid metric {name}: {error}"))
}

fn parse_metrics(text: &str) -> Result<GearPerformance, String> {
    Ok(GearPerformance {
        critical_path_lines: metric(text, "critical_path_lines")?,
        barrier_critical_lines: metric(text, "barrier_critical_lines")?,
        max_gear_lines: metric(text, "max_gear_lines")?,
        cyclic_sccs: metric(text, "cyclic_sccs")?,
    })
}

fn load_metrics(path: &Path) -> Result<GearPerformance, String> {
    let text =
        fs::read_to_string(path).map_err(|error| format!("read {}: {error}", path.display()))?;
    parse_metrics(&text)
}

impl PromotionEvidence<Unchecked> {
    fn new(authority: GearPerformance, candidate: GearPerformance) -> Self {
        Self {
            authority,
            candidate,
            _state: PhantomData,
        }
    }

    fn compare(self) -> PromotionDecision {
        let evidence = PromotionEvidence::<Compared> {
            authority: self.authority,
            candidate: self.candidate,
            _state: PhantomData,
        };
        let mut blockers = Vec::new();
        if self.candidate.cyclic_sccs != 0 {
            blockers.push(PromotionBlocker::CyclicScc {
                candidate: self.candidate.cyclic_sccs,
            });
        }
        if self.candidate.critical_path_lines > self.authority.critical_path_lines {
            blockers.push(PromotionBlocker::CriticalPathRegression {
                authority: self.authority.critical_path_lines,
                candidate: self.candidate.critical_path_lines,
            });
        }
        if self.candidate.barrier_critical_lines > self.authority.barrier_critical_lines {
            blockers.push(PromotionBlocker::BarrierRegression {
                authority: self.authority.barrier_critical_lines,
                candidate: self.candidate.barrier_critical_lines,
            });
        }
        if self.candidate.max_gear_lines > self.authority.max_gear_lines {
            blockers.push(PromotionBlocker::MaxGearRegression {
                authority: self.authority.max_gear_lines,
                candidate: self.candidate.max_gear_lines,
            });
        }
        if blockers.is_empty() {
            PromotionDecision::Promote(evidence)
        } else {
            PromotionDecision::Reject { evidence, blockers }
        }
    }
}

fn signed_delta(candidate: usize, authority: usize) -> i128 {
    candidate as i128 - authority as i128
}

fn render_decision(decision: &PromotionDecision) -> String {
    let evidence = match decision {
        PromotionDecision::Promote(evidence) => evidence,
        PromotionDecision::Reject { evidence, .. } => evidence,
    };
    let status = match decision {
        PromotionDecision::Promote(_) => "promote",
        PromotionDecision::Reject { .. } => "reject",
    };
    let blockers = match decision {
        PromotionDecision::Promote(_) => "none".to_owned(),
        PromotionDecision::Reject { blockers, .. } => blockers
            .iter()
            .map(|blocker| match blocker {
                PromotionBlocker::CyclicScc { .. } => "cyclic_scc",
                PromotionBlocker::CriticalPathRegression { .. } => "critical_path",
                PromotionBlocker::BarrierRegression { .. } => "barrier_critical_path",
                PromotionBlocker::MaxGearRegression { .. } => "max_gear",
            })
            .collect::<Vec<_>>()
            .join(","),
    };
    format!(
        "decision={status} blockers={blockers} critical_path_delta={} barrier_delta={} max_gear_delta={}\n",
        signed_delta(
            evidence.candidate.critical_path_lines,
            evidence.authority.critical_path_lines
        ),
        signed_delta(
            evidence.candidate.barrier_critical_lines,
            evidence.authority.barrier_critical_lines
        ),
        signed_delta(
            evidence.candidate.max_gear_lines,
            evidence.authority.max_gear_lines
        ),
    )
}

fn run(args: &[String]) -> Result<PromotionDecision, String> {
    if args.len() != 2 {
        return Err(
            "usage: spiral-performance-gate <authority-metrics.tsv> <candidate-metrics.tsv>"
                .to_owned(),
        );
    }
    let authority = load_metrics(Path::new(&args[0]))?;
    let candidate = load_metrics(Path::new(&args[1]))?;
    Ok(PromotionEvidence::<Unchecked>::new(authority, candidate).compare())
}

fn main() {
    let args = env::args().skip(1).collect::<Vec<_>>();
    match run(&args) {
        Ok(decision) => {
            print!("{}", render_decision(&decision));
            if matches!(decision, PromotionDecision::Reject { .. }) {
                std::process::exit(3);
            }
        }
        Err(error) => {
            eprintln!("spiral-performance-gate error: {error}");
            std::process::exit(2);
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    fn metrics(critical: usize, barrier: usize, max: usize, cycles: usize) -> GearPerformance {
        GearPerformance {
            critical_path_lines: critical,
            barrier_critical_lines: barrier,
            max_gear_lines: max,
            cyclic_sccs: cycles,
        }
    }

    #[test]
    fn promotes_only_when_compile_floors_do_not_regress() {
        let decision = PromotionEvidence::<Unchecked>::new(
            metrics(16_001, 16_001, 15_351, 0),
            metrics(9_705, 10_691, 2_124, 0),
        )
        .compare();
        assert!(matches!(decision, PromotionDecision::Promote(_)));
    }

    #[test]
    fn rejects_shorter_peak_when_critical_path_gets_worse() {
        let decision = PromotionEvidence::<Unchecked>::new(
            metrics(9_705, 10_691, 2_124, 0),
            metrics(10_001, 10_691, 2_000, 0),
        )
        .compare();
        assert!(matches!(
            decision,
            PromotionDecision::Reject { ref blockers, .. }
                if blockers.iter().any(|blocker| matches!(blocker, PromotionBlocker::CriticalPathRegression { .. }))
        ));
    }

    #[test]
    fn rejects_barrier_or_max_gear_regression_and_cycles() {
        let decision = PromotionEvidence::<Unchecked>::new(
            metrics(10_000, 10_500, 2_000, 0),
            metrics(9_900, 10_600, 2_100, 1),
        )
        .compare();
        let PromotionDecision::Reject { blockers, .. } = decision else {
            panic!("candidate must be rejected")
        };
        assert_eq!(blockers.len(), 3);
    }

    #[test]
    fn parses_both_tabular_and_space_metrics_rows() {
        let parsed = parse_metrics(
            "metric\tvalue\ncritical_path_lines\t9705\nbarrier_critical_lines\t10691\nmax_gear_lines\t2124\ncyclic_sccs 0\n",
        )
        .expect("metrics parse");
        assert_eq!(parsed, metrics(9_705, 10_691, 2_124, 0));
    }
}
