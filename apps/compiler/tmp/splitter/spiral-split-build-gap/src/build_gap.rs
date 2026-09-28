use std::collections::{BTreeMap, BTreeSet};
use std::marker::PhantomData;

#[derive(Debug)]
pub enum Discovered {}
#[derive(Debug)]
pub enum Scheduled {}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BuildDemand {
    Target {
        shard: usize,
    },
    Dependency {
        shard: usize,
        parent: usize,
        cause: Box<BuildDemand>,
    },
}

impl BuildDemand {
    pub fn shard(&self) -> usize {
        match self {
            Self::Target { shard } | Self::Dependency { shard, .. } => *shard,
        }
    }

    pub fn depth(&self) -> usize {
        match self {
            Self::Target { .. } => 0,
            Self::Dependency { cause, .. } => cause.depth() + 1,
        }
    }

    pub fn lineage(&self) -> Vec<usize> {
        match self {
            Self::Target { shard } => vec![*shard],
            Self::Dependency { shard, cause, .. } => {
                let mut lineage = cause.lineage();
                lineage.push(*shard);
                lineage
            }
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GapNode {
    pub shard: usize,
    pub layer: usize,
    pub dependencies: Vec<usize>,
    pub fresh: bool,
}

#[derive(Clone, Debug)]
pub struct GapGraph<S> {
    nodes: BTreeMap<usize, GapNode>,
    targets: Vec<usize>,
    schedule: Option<GapSchedule>,
    stage: PhantomData<S>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GapSchedule {
    pub targets: Vec<usize>,
    pub selected: Vec<usize>,
    pub fresh_boundaries: Vec<usize>,
    pub layers: BTreeMap<usize, Vec<usize>>,
    pub reasons: BTreeMap<usize, BuildDemand>,
    pub edges_examined: usize,
    pub max_depth: usize,
}

impl GapGraph<Discovered> {
    pub fn discover(nodes: Vec<GapNode>, mut targets: Vec<usize>) -> Result<Self, String> {
        if nodes.is_empty() {
            return Err("gap graph requires at least one node".to_owned());
        }
        if targets.is_empty() {
            return Err("gap graph requires at least one target".to_owned());
        }
        targets.sort_unstable();
        targets.dedup();

        let mut indexed = BTreeMap::new();
        for mut node in nodes {
            node.dependencies.sort_unstable();
            node.dependencies.dedup();
            let shard = node.shard;
            if indexed.insert(shard, node).is_some() {
                return Err(format!("duplicate gap node: Part{shard:04}"));
            }
        }
        for target in &targets {
            if !indexed.contains_key(target) {
                return Err(format!("target is absent from gap graph: Part{target:04}"));
            }
        }
        for node in indexed.values() {
            for dependency in &node.dependencies {
                let dependency_node = indexed.get(dependency).ok_or_else(|| {
                    format!(
                        "Part{:04} references absent Part{dependency:04}",
                        node.shard
                    )
                })?;
                if dependency_node.layer >= node.layer {
                    return Err(format!(
                        "non-descending dependency: Part{:04} layer {} -> Part{dependency:04} layer {}",
                        node.shard, node.layer, dependency_node.layer
                    ));
                }
            }
        }
        Ok(Self {
            nodes: indexed,
            targets,
            schedule: None,
            stage: PhantomData,
        })
    }

    pub fn schedule(self) -> Result<GapGraph<Scheduled>, String> {
        let mut selected = BTreeSet::new();
        let mut fresh_boundaries = BTreeSet::new();
        let mut reasons = BTreeMap::new();
        let mut visiting = BTreeSet::new();
        let mut edges_examined = 0usize;

        for target in &self.targets {
            visit(
                *target,
                BuildDemand::Target { shard: *target },
                &self.nodes,
                &mut selected,
                &mut fresh_boundaries,
                &mut reasons,
                &mut visiting,
                &mut edges_examined,
            )?;
        }

        let mut layers = BTreeMap::<usize, Vec<usize>>::new();
        for shard in &selected {
            let node = self
                .nodes
                .get(shard)
                .ok_or_else(|| format!("scheduled node disappeared: Part{shard:04}"))?;
            layers.entry(node.layer).or_default().push(*shard);
        }
        let max_depth = reasons.values().map(BuildDemand::depth).max().unwrap_or(0);
        let schedule = GapSchedule {
            targets: self.targets.clone(),
            selected: selected.into_iter().collect(),
            fresh_boundaries: fresh_boundaries.into_iter().collect(),
            layers,
            reasons,
            edges_examined,
            max_depth,
        };
        Ok(GapGraph {
            nodes: self.nodes,
            targets: self.targets,
            schedule: Some(schedule),
            stage: PhantomData,
        })
    }
}

impl GapGraph<Scheduled> {
    pub fn receipt(&self) -> &GapSchedule {
        self.schedule
            .as_ref()
            .expect("scheduled gap graph always carries a receipt")
    }
}

#[allow(clippy::too_many_arguments)]
fn visit(
    shard: usize,
    demand: BuildDemand,
    nodes: &BTreeMap<usize, GapNode>,
    selected: &mut BTreeSet<usize>,
    fresh_boundaries: &mut BTreeSet<usize>,
    reasons: &mut BTreeMap<usize, BuildDemand>,
    visiting: &mut BTreeSet<usize>,
    edges_examined: &mut usize,
) -> Result<(), String> {
    if selected.contains(&shard) || fresh_boundaries.contains(&shard) {
        return Ok(());
    }
    let node = nodes
        .get(&shard)
        .ok_or_else(|| format!("gap visit references absent Part{shard:04}"))?;
    if node.fresh {
        fresh_boundaries.insert(shard);
        reasons.entry(shard).or_insert(demand);
        return Ok(());
    }
    if !visiting.insert(shard) {
        return Err(format!("dependency cycle reaches Part{shard:04}"));
    }
    for dependency in &node.dependencies {
        *edges_examined += 1;
        visit(
            *dependency,
            BuildDemand::Dependency {
                shard: *dependency,
                parent: shard,
                cause: Box::new(demand.clone()),
            },
            nodes,
            selected,
            fresh_boundaries,
            reasons,
            visiting,
            edges_examined,
        )?;
    }
    visiting.remove(&shard);
    selected.insert(shard);
    reasons.entry(shard).or_insert(demand);
    Ok(())
}

pub fn render_gap_tsv(schedule: &GapSchedule) -> String {
    let mut output = format!(
        "key	value
\
targets	{}
\
selected	{}
\
fresh_boundaries	{}
\
layers	{}
\
edges_examined	{}
\
max_depth	{}

\
kind	shard	layer	lineage
",
        schedule.targets.len(),
        schedule.selected.len(),
        schedule.fresh_boundaries.len(),
        schedule.layers.len(),
        schedule.edges_examined,
        schedule.max_depth,
    );
    let layer_by_shard = schedule
        .layers
        .iter()
        .flat_map(|(layer, shards)| shards.iter().map(move |shard| (*shard, *layer)))
        .collect::<BTreeMap<_, _>>();
    for target in &schedule.targets {
        output.push_str(&format!(
            "target	{target}	-	{target}
"
        ));
    }
    for shard in &schedule.selected {
        let layer = layer_by_shard.get(shard).copied().unwrap_or(0);
        let lineage = schedule
            .reasons
            .get(shard)
            .map(BuildDemand::lineage)
            .unwrap_or_else(|| vec![*shard])
            .into_iter()
            .map(|value| format!("Part{value:04}"))
            .collect::<Vec<_>>()
            .join("->");
        output.push_str(&format!(
            "selected	{shard}	{layer}	{lineage}
"
        ));
    }
    for shard in &schedule.fresh_boundaries {
        let lineage = schedule
            .reasons
            .get(shard)
            .map(BuildDemand::lineage)
            .unwrap_or_else(|| vec![*shard])
            .into_iter()
            .map(|value| format!("Part{value:04}"))
            .collect::<Vec<_>>()
            .join("->");
        output.push_str(&format!(
            "fresh-boundary	{shard}	-	{lineage}
"
        ));
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    fn node(shard: usize, layer: usize, dependencies: &[usize], fresh: bool) -> GapNode {
        GapNode {
            shard,
            layer,
            dependencies: dependencies.to_vec(),
            fresh,
        }
    }

    #[test]
    fn selects_only_stale_dependency_closure() {
        let graph = GapGraph::discover(
            vec![
                node(0, 0, &[], true),
                node(1, 1, &[0], false),
                node(2, 1, &[0], true),
                node(3, 2, &[1, 2], false),
            ],
            vec![3],
        )
        .unwrap()
        .schedule()
        .unwrap();
        let receipt = graph.receipt();
        assert_eq!(receipt.selected, vec![1, 3]);
        assert_eq!(receipt.fresh_boundaries, vec![0, 2]);
        assert_eq!(receipt.layers.get(&1), Some(&vec![1]));
        assert_eq!(receipt.layers.get(&2), Some(&vec![3]));
        assert_eq!(receipt.max_depth, 2);
    }

    #[test]
    fn fresh_target_stops_without_work() {
        let graph = GapGraph::discover(vec![node(0, 0, &[], true)], vec![0])
            .unwrap()
            .schedule()
            .unwrap();
        assert!(graph.receipt().selected.is_empty());
        assert_eq!(graph.receipt().fresh_boundaries, vec![0]);
    }

    #[test]
    fn missing_dependency_is_rejected() {
        let error = GapGraph::discover(vec![node(2, 1, &[1], false)], vec![2]).unwrap_err();
        assert!(error.contains("absent Part0001"));
    }

    #[test]
    fn non_descending_dependency_is_rejected() {
        let error = GapGraph::discover(
            vec![node(0, 1, &[], false), node(1, 1, &[0], false)],
            vec![1],
        )
        .unwrap_err();
        assert!(error.contains("non-descending dependency"));
    }

    #[test]
    fn duplicate_targets_and_dependencies_are_normalized() {
        let graph = GapGraph::discover(
            vec![node(0, 0, &[], true), node(1, 1, &[0, 0], false)],
            vec![1, 1],
        )
        .unwrap()
        .schedule()
        .unwrap();
        assert_eq!(graph.receipt().targets, vec![1]);
        assert_eq!(graph.receipt().edges_examined, 1);
    }
}
