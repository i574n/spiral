use spiral_split_model::SplitPlan;
use std::collections::BTreeSet;

#[derive(Clone, Copy, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub struct LayerObjective {
    pub critical_path_lines: usize,
    pub assemblies: usize,
    pub reference_edges: usize,
    pub secondary_cost: u64,
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum DependencyResolution {
    Internal,
    Prior { gear: usize, path_lines: usize },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct PlanningPrefix {
    shard_to_gear: Vec<Option<usize>>,
    gear_path_lines: Vec<usize>,
    critical_path_lines: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct LayerProjection {
    objective: LayerObjective,
    path_lines: Vec<usize>,
}

impl PlanningPrefix {
    #[must_use]
    pub fn new(shards: usize) -> Self {
        Self {
            shard_to_gear: vec![None; shards],
            gear_path_lines: Vec::new(),
            critical_path_lines: 0,
        }
    }

    #[must_use]
    pub fn critical_path_lines(&self) -> usize {
        self.critical_path_lines
    }

    pub fn score_layer(
        &self,
        plan: &SplitPlan,
        groups: &[Vec<usize>],
        secondary_cost: u64,
    ) -> Result<LayerObjective, String> {
        Ok(self.project_layer(plan, groups, secondary_cost)?.objective)
    }

    pub fn commit_layer(
        &mut self,
        plan: &SplitPlan,
        groups: &[Vec<usize>],
        secondary_cost: u64,
    ) -> Result<LayerObjective, String> {
        let projection = self.project_layer(plan, groups, secondary_cost)?;
        let first_gear = self.gear_path_lines.len();
        for (local_gear, group) in groups.iter().enumerate() {
            let gear = first_gear + local_gear;
            for shard in group {
                if self.shard_to_gear[*shard].replace(gear).is_some() {
                    return Err(format!("planning prefix remapped shard {shard}"));
                }
            }
        }
        self.gear_path_lines.extend(projection.path_lines);
        self.critical_path_lines = projection.objective.critical_path_lines;
        Ok(projection.objective)
    }

    fn project_layer(
        &self,
        plan: &SplitPlan,
        groups: &[Vec<usize>],
        secondary_cost: u64,
    ) -> Result<LayerProjection, String> {
        let mut local_group = vec![None; plan.shards.len()];
        for (group, shards) in groups.iter().enumerate() {
            for shard in shards {
                if *shard >= local_group.len() {
                    return Err(format!("layer objective received unknown shard {shard}"));
                }
                if local_group[*shard].replace(group).is_some() {
                    return Err(format!("layer objective received duplicate shard {shard}"));
                }
            }
        }

        let mut path_lines = Vec::with_capacity(groups.len());
        let mut reference_edges = 0usize;
        for (group, shards) in groups.iter().enumerate() {
            let lines = shards
                .iter()
                .map(|shard| plan.shards[*shard].line_count)
                .sum::<usize>();
            let mut dependencies = BTreeSet::new();
            for shard in shards {
                for dependency in &plan.shards[*shard].compile_dependencies {
                    match self.resolve_dependency(*dependency, group, &local_group)? {
                        DependencyResolution::Internal => {}
                        DependencyResolution::Prior { gear, path_lines } => {
                            dependencies.insert((gear, path_lines));
                        }
                    }
                }
            }
            reference_edges += dependencies.len();
            let prior_path = dependencies
                .iter()
                .map(|(_, path_lines)| *path_lines)
                .max()
                .unwrap_or(0);
            path_lines.push(prior_path.saturating_add(lines));
        }

        let critical_path_lines = self
            .critical_path_lines
            .max(path_lines.iter().copied().max().unwrap_or(0));
        Ok(LayerProjection {
            objective: LayerObjective {
                critical_path_lines,
                assemblies: groups.len(),
                reference_edges,
                secondary_cost,
            },
            path_lines,
        })
    }

    fn resolve_dependency(
        &self,
        dependency: usize,
        consumer_group: usize,
        local_group: &[Option<usize>],
    ) -> Result<DependencyResolution, String> {
        if dependency >= local_group.len() {
            return Err(format!(
                "layer objective dependency {dependency} is out of range"
            ));
        }
        if let Some(provider_group) = local_group[dependency] {
            if provider_group == consumer_group {
                return Ok(DependencyResolution::Internal);
            }
            return Err(format!(
                "layer objective found cross-group dependency inside one SCC layer: {provider_group}->{consumer_group}"
            ));
        }
        let gear = self.shard_to_gear[dependency].ok_or_else(|| {
            format!("layer objective dependency {dependency} was not planned earlier")
        })?;
        Ok(DependencyResolution::Prior {
            gear,
            path_lines: self.gear_path_lines[gear],
        })
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{
        CompilerProfile, DeclarationId, ReferenceMode, Shard, SourceText, SplitPolicy,
    };
    use std::path::PathBuf;

    fn shard(id: usize, lines: usize, dependencies: &[usize]) -> Shard {
        Shard {
            id,
            declarations: vec![DeclarationId(id)],
            direct_dependencies: dependencies.iter().copied().collect(),
            compile_dependencies: dependencies.iter().copied().collect(),
            ambient_opens: Vec::new(),
            line_count: lines,
            bytes: lines * 10,
            layer: 0,
            oversize: false,
            fingerprint: id as u64 + 1,
        }
    }

    fn plan(shards: Vec<Shard>) -> SplitPlan {
        SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "Test".to_owned(),
                profile: CompilerProfile::PortableFork,
                fingerprint: 1,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: Vec::new(),
            shards,
        }
    }

    #[test]
    fn shorter_critical_path_beats_fewer_assemblies() {
        let split = plan(vec![
            shard(0, 800, &[]),
            shard(1, 700, &[]),
            shard(2, 300, &[]),
            shard(3, 200, &[]),
        ]);
        let prefix = PlanningPrefix::new(split.shards.len());
        let two = prefix
            .score_layer(&split, &[vec![0, 3], vec![1, 2]], 1)
            .expect("two groups");
        let three = prefix
            .score_layer(&split, &[vec![0], vec![1], vec![2, 3]], 99_999)
            .expect("three groups");
        assert_eq!(two.critical_path_lines, 1_000);
        assert_eq!(three.critical_path_lines, 800);
        assert!(three < two);
    }

    #[test]
    fn committed_prefix_carries_dependency_path_into_next_layer() {
        let split = plan(vec![shard(0, 800, &[]), shard(1, 300, &[0])]);
        let mut prefix = PlanningPrefix::new(split.shards.len());
        prefix
            .commit_layer(&split, &[vec![0]], 0)
            .expect("first layer");
        let next = prefix
            .score_layer(&split, &[vec![1]], 0)
            .expect("second layer");
        assert_eq!(next.critical_path_lines, 1_100);
    }

    #[test]
    fn same_layer_cross_group_dependency_is_rejected() {
        let split = plan(vec![shard(0, 10, &[]), shard(1, 10, &[0])]);
        let prefix = PlanningPrefix::new(split.shards.len());
        let error = prefix
            .score_layer(&split, &[vec![0], vec![1]], 0)
            .expect_err("cross-group edge");
        assert!(error.contains("cross-group dependency"));
    }
}
