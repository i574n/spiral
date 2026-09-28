use std::time::{Duration, Instant};

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum BuildBudget {
    Unlimited,
    Limited { total: Duration, reserve: Duration },
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum BudgetDecision {
    Dispatch,
    Yield {
        elapsed: Duration,
        remaining: Duration,
        required: Duration,
    },
}

impl BuildBudget {
    pub fn limited(total: Duration, reserve: Duration) -> Self {
        Self::Limited { total, reserve }
    }

    pub fn decision_at(self, elapsed: Duration, prospective: Duration) -> BudgetDecision {
        match self {
            Self::Unlimited => BudgetDecision::Dispatch,
            Self::Limited { total, reserve } => {
                let remaining = total.saturating_sub(elapsed);
                let required = prospective.saturating_add(reserve);
                if remaining > required {
                    BudgetDecision::Dispatch
                } else {
                    BudgetDecision::Yield {
                        elapsed,
                        remaining,
                        required,
                    }
                }
            }
        }
    }

    pub fn clock(self) -> BuildBudgetClock {
        BuildBudgetClock {
            budget: self,
            started: Instant::now(),
        }
    }
}

#[derive(Debug)]
pub struct BuildBudgetClock {
    budget: BuildBudget,
    started: Instant,
}

impl BuildBudgetClock {
    pub fn decision(&self, prospective: Duration) -> BudgetDecision {
        self.budget.decision_at(self.started.elapsed(), prospective)
    }
}

impl BudgetDecision {
    pub fn yield_note(self) -> Option<String> {
        match self {
            Self::Dispatch => None,
            Self::Yield {
                elapsed,
                remaining,
                required,
            } => Some(format!(
                "build budget yielded: elapsed_ms={:.3} remaining_ms={:.3} required_ms={:.3}",
                elapsed.as_secs_f64() * 1000.0,
                remaining.as_secs_f64() * 1000.0,
                required.as_secs_f64() * 1000.0,
            )),
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn unlimited_budget_always_dispatches() {
        assert_eq!(
            BuildBudget::Unlimited.decision_at(Duration::from_secs(999), Duration::from_secs(60)),
            BudgetDecision::Dispatch
        );
    }

    #[test]
    fn limited_budget_dispatches_only_with_full_horizon_and_reserve() {
        let budget = BuildBudget::limited(Duration::from_secs(90), Duration::from_secs(10));
        assert_eq!(
            budget.decision_at(Duration::from_secs(19), Duration::from_secs(60)),
            BudgetDecision::Dispatch
        );
        assert!(matches!(
            budget.decision_at(Duration::from_secs(20), Duration::from_secs(60)),
            BudgetDecision::Yield { .. }
        ));
    }

    #[test]
    fn elapsed_beyond_total_saturates_to_yield() {
        let budget = BuildBudget::limited(Duration::from_secs(5), Duration::ZERO);
        assert!(matches!(
            budget.decision_at(Duration::from_secs(9), Duration::from_secs(1)),
            BudgetDecision::Yield { remaining, .. } if remaining == Duration::ZERO
        ));
    }

    #[test]
    fn harness_profile_yields_before_a_second_late_dispatch() {
        let budget = BuildBudget::limited(Duration::from_secs(28), Duration::from_secs(5));
        assert_eq!(
            budget.decision_at(Duration::from_secs(4), Duration::from_secs(18)),
            BudgetDecision::Dispatch
        );
        assert!(matches!(
            budget.decision_at(Duration::from_secs(5), Duration::from_secs(18)),
            BudgetDecision::Yield { .. }
        ));
    }
}
