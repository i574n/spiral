use spiral_split_gears::{
    GearMetrics, GearPlan, GearPolicy, Planned, measure_gears, plan_gears_from_emitted,
};
use spiral_split_model::SplitPlan;
use std::fmt::Write as _;
use std::path::Path;

#[derive(Clone, Copy, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub enum PolicyFamily {
    Default,
    Balanced,
    Fine,
    Micro,
}

impl PolicyFamily {
    #[must_use]
    pub const fn label(self) -> &'static str {
        match self {
            Self::Default => "default",
            Self::Balanced => "balanced",
            Self::Fine => "fine",
            Self::Micro => "micro",
        }
    }

    #[must_use]
    pub fn policy(self) -> GearPolicy {
        let base = GearPolicy::default();
        match self {
            Self::Default => base,
            Self::Balanced => GearPolicy {
                target_lines: 1_200,
                max_lines: 2_000,
                max_teeth: 24,
                ..base
            },
            Self::Fine => GearPolicy {
                target_lines: 900,
                max_lines: 1_600,
                max_teeth: 20,
                ..base
            },
            Self::Micro => GearPolicy {
                target_lines: 650,
                max_lines: 1_200,
                max_teeth: 12,
                ..base
            },
        }
    }
}

#[derive(Clone, Debug, PartialEq)]
pub struct PolicyCandidate {
    pub family: PolicyFamily,
    pub metrics: GearMetrics,
}

#[derive(Clone, Debug)]
pub struct PolicySelection {
    pub family: PolicyFamily,
    pub plan: GearPlan<Planned>,
    pub metrics: GearMetrics,
    pub candidates: Vec<PolicyCandidate>,
}

fn score(
    metrics: &GearMetrics,
    family: PolicyFamily,
) -> (usize, usize, usize, usize, usize, usize, PolicyFamily) {
    (
        metrics.critical_path_lines,
        metrics.barrier_critical_lines,
        metrics.max_gear_lines,
        metrics.oversize_gears,
        metrics.gears,
        metrics.gear_edges,
        family,
    )
}

pub fn select_policy_from_emitted(
    plan: &SplitPlan,
    emitted: &Path,
) -> Result<PolicySelection, String> {
    let families = [
        PolicyFamily::Default,
        PolicyFamily::Balanced,
        PolicyFamily::Fine,
        PolicyFamily::Micro,
    ];
    let mut evaluated = Vec::with_capacity(families.len());
    for family in families {
        let gear_plan = plan_gears_from_emitted(plan, emitted, family.policy())?;
        let metrics = measure_gears(plan, &gear_plan);
        evaluated.push((family, gear_plan, metrics));
    }
    let selected_index = evaluated
        .iter()
        .enumerate()
        .min_by_key(|(_, (family, _, metrics))| score(metrics, *family))
        .map(|(index, _)| index)
        .ok_or_else(|| "gear policy search produced no candidates".to_owned())?;
    let candidates = evaluated
        .iter()
        .map(|(family, _, metrics)| PolicyCandidate {
            family: *family,
            metrics: metrics.clone(),
        })
        .collect::<Vec<_>>();
    let (family, plan, metrics) = evaluated.remove(selected_index);
    Ok(PolicySelection {
        family,
        plan,
        metrics,
        candidates,
    })
}

#[must_use]
pub fn render_policy_search_tsv(selection: &PolicySelection) -> String {
    let mut output = String::from(
        "selected\tfamily\tcritical_path_lines\tbarrier_critical_lines\tmax_gear_lines\toversize_gears\tgears\tgear_edges\n",
    );
    for candidate in &selection.candidates {
        let metrics = &candidate.metrics;
        let _ = writeln!(
            output,
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
            if candidate.family == selection.family {
                "yes"
            } else {
                "no"
            },
            candidate.family.label(),
            metrics.critical_path_lines,
            metrics.barrier_critical_lines,
            metrics.max_gear_lines,
            metrics.oversize_gears,
            metrics.gears,
            metrics.gear_edges,
        );
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn families_become_progressively_finer() {
        let values = [
            PolicyFamily::Default,
            PolicyFamily::Balanced,
            PolicyFamily::Fine,
            PolicyFamily::Micro,
        ]
        .map(PolicyFamily::policy);
        assert!(
            values
                .windows(2)
                .all(|pair| pair[1].target_lines < pair[0].target_lines)
        );
        assert!(
            values
                .windows(2)
                .all(|pair| pair[1].max_lines < pair[0].max_lines)
        );
    }

    #[test]
    fn critical_path_dominates_assembly_count() {
        let mut faster = blank_metrics();
        faster.critical_path_lines = 90;
        faster.gears = 100;
        let mut fused = blank_metrics();
        fused.critical_path_lines = 100;
        fused.gears = 1;
        assert!(score(&faster, PolicyFamily::Micro) < score(&fused, PolicyFamily::Default));
    }

    #[test]
    fn barrier_breaks_equal_critical_path() {
        let mut a = blank_metrics();
        a.critical_path_lines = 100;
        a.barrier_critical_lines = 120;
        let mut b = a.clone();
        b.barrier_critical_lines = 110;
        assert!(score(&b, PolicyFamily::Balanced) < score(&a, PolicyFamily::Default));
    }

    fn blank_metrics() -> GearMetrics {
        GearMetrics {
            shards: 0,
            gears: 0,
            assemblies_removed: 0,
            gear_edges: 0,
            layers: 0,
            widest_layer: 0,
            max_gear_lines: 0,
            p50_gear_lines: 0,
            p95_gear_lines: 0,
            oversize_gears: 0,
            scc_components: 0,
            cyclic_sccs: 0,
            max_scc_shards: 0,
            identity_initial_groups: 0,
            identity_affinity_unions: 0,
            identity_cycle_groups: 0,
            identity_largest_cycle_groups: 0,
            mutable_address_unions: 0,
            mutable_address_cycle_collapses: 0,
            series_unions: 0,
            critical_path_gears: 0,
            critical_path_lines: 0,
            barrier_critical_lines: 0,
            estimated_parallelism: 0.0,
            dag_estimated_parallelism: 0.0,
        }
    }
}
