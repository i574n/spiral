use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::Write as _;
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Raw;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Condensed;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum SccWitness {
    Root { shard: usize },
    Link { shard: usize, next: Box<SccWitness> },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SccComponent {
    pub id: usize,
    pub shards: Vec<usize>,
    pub dependencies: BTreeSet<usize>,
    pub layer: usize,
    pub lines: usize,
    pub bytes: usize,
    pub cyclic: bool,
    pub witness: SccWitness,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SccPlan<State> {
    pub components: Vec<SccComponent>,
    pub shard_to_component: Vec<usize>,
    pub cyclic_components: usize,
    pub largest_component: usize,
    state: PhantomData<State>,
}

impl<State> SccPlan<State> {
    #[must_use]
    pub fn restage<Next>(self) -> SccPlan<Next> {
        SccPlan {
            components: self.components,
            shard_to_component: self.shard_to_component,
            cyclic_components: self.cyclic_components,
            largest_component: self.largest_component,
            state: PhantomData,
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SccMetrics {
    pub shards: usize,
    pub components: usize,
    pub cyclic_components: usize,
    pub collapsed_shards: usize,
    pub largest_component: usize,
    pub component_edges: usize,
    pub layers: usize,
    pub widest_layer: usize,
}

fn validate_plan(plan: &SplitPlan) -> Result<(), String> {
    for (expected, shard) in plan.shards.iter().enumerate() {
        if shard.id != expected {
            return Err(format!(
                "shard ids must be dense before SCC condensation: expected {expected}, got {}",
                shard.id
            ));
        }
        for dependency in &shard.compile_dependencies {
            if *dependency >= plan.shards.len() {
                return Err(format!(
                    "shard {expected} has out-of-range compile dependency {dependency}"
                ));
            }
        }
    }
    Ok(())
}

fn visit_forward(
    node: usize,
    graph: &[BTreeSet<usize>],
    visited: &mut [bool],
    order: &mut Vec<usize>,
) {
    if visited[node] {
        return;
    }
    visited[node] = true;
    for next in &graph[node] {
        visit_forward(*next, graph, visited, order);
    }
    order.push(node);
}

fn visit_reverse(
    node: usize,
    reverse: &[BTreeSet<usize>],
    visited: &mut [bool],
    component: &mut Vec<usize>,
) {
    if visited[node] {
        return;
    }
    visited[node] = true;
    component.push(node);
    for next in &reverse[node] {
        visit_reverse(*next, reverse, visited, component);
    }
}

fn raw_components(graph: &[BTreeSet<usize>]) -> Vec<Vec<usize>> {
    let mut visited = vec![false; graph.len()];
    let mut order = Vec::with_capacity(graph.len());
    for node in 0..graph.len() {
        visit_forward(node, graph, &mut visited, &mut order);
    }
    let mut reverse = vec![BTreeSet::new(); graph.len()];
    for (consumer, providers) in graph.iter().enumerate() {
        for provider in providers {
            reverse[*provider].insert(consumer);
        }
    }
    visited.fill(false);
    let mut components = Vec::new();
    while let Some(node) = order.pop() {
        if visited[node] {
            continue;
        }
        let mut component = Vec::new();
        visit_reverse(node, &reverse, &mut visited, &mut component);
        component.sort_unstable();
        components.push(component);
    }
    components
}

fn build_witness(shards: &[usize]) -> SccWitness {
    let mut iterator = shards.iter().rev();
    let first = *iterator.next().expect("SCC components are non-empty");
    iterator.fold(SccWitness::Root { shard: first }, |next, shard| {
        SccWitness::Link {
            shard: *shard,
            next: Box::new(next),
        }
    })
}

fn component_graph(
    plan: &SplitPlan,
    components: &[Vec<usize>],
) -> (Vec<BTreeSet<usize>>, Vec<usize>) {
    let mut shard_to_component = vec![usize::MAX; plan.shards.len()];
    for (component, shards) in components.iter().enumerate() {
        for shard in shards {
            shard_to_component[*shard] = component;
        }
    }
    let mut dependencies = vec![BTreeSet::new(); components.len()];
    for (component, shards) in components.iter().enumerate() {
        for shard in shards {
            for dependency in &plan.shards[*shard].compile_dependencies {
                let provider = shard_to_component[*dependency];
                if provider != component {
                    dependencies[component].insert(provider);
                }
            }
        }
    }
    (dependencies, shard_to_component)
}

fn topological_order(
    components: &[Vec<usize>],
    dependencies: &[BTreeSet<usize>],
) -> Result<Vec<usize>, String> {
    let mut consumers = vec![BTreeSet::new(); components.len()];
    let mut indegree = vec![0usize; components.len()];
    for (consumer, providers) in dependencies.iter().enumerate() {
        indegree[consumer] = providers.len();
        for provider in providers {
            consumers[*provider].insert(consumer);
        }
    }
    let mut ready = indegree
        .iter()
        .enumerate()
        .filter_map(|(component, degree)| {
            (*degree == 0).then_some((components[component][0], component))
        })
        .collect::<BTreeSet<_>>();
    let mut order = Vec::with_capacity(components.len());
    while let Some((first_shard, component)) = ready.pop_first() {
        let _ = first_shard;
        order.push(component);
        for consumer in &consumers[component] {
            indegree[*consumer] -= 1;
            if indegree[*consumer] == 0 {
                ready.insert((components[*consumer][0], *consumer));
            }
        }
    }
    if order.len() != components.len() {
        return Err("SCC condensation produced a cyclic quotient".to_owned());
    }
    Ok(order)
}

pub fn condense_compile_sccs(plan: &SplitPlan) -> Result<SccPlan<Condensed>, String> {
    validate_plan(plan)?;
    if plan.shards.is_empty() {
        return Err("cannot condense SCCs for an empty split".to_owned());
    }
    let graph = plan
        .shards
        .iter()
        .map(|shard| shard.compile_dependencies.clone())
        .collect::<Vec<_>>();
    let components = raw_components(&graph);
    let (dependencies, raw_shard_to_component) = component_graph(plan, &components);
    let order = topological_order(&components, &dependencies)?;
    let mut raw_to_final = vec![usize::MAX; components.len()];
    for (final_id, raw_id) in order.iter().enumerate() {
        raw_to_final[*raw_id] = final_id;
    }
    let mut final_components: Vec<SccComponent> = Vec::with_capacity(components.len());
    let mut shard_to_component = vec![usize::MAX; plan.shards.len()];
    for (final_id, raw_id) in order.into_iter().enumerate() {
        let shards = components[raw_id].clone();
        let remapped_dependencies = dependencies[raw_id]
            .iter()
            .map(|dependency| raw_to_final[*dependency])
            .collect::<BTreeSet<_>>();
        if remapped_dependencies
            .iter()
            .any(|dependency| *dependency >= final_id)
        {
            return Err(format!(
                "component {final_id} has a non-backward dependency after SCC condensation"
            ));
        }
        let layer = remapped_dependencies
            .iter()
            .map(|dependency| final_components[*dependency].layer + 1)
            .max()
            .unwrap_or(0);
        let lines = shards
            .iter()
            .map(|shard| plan.shards[*shard].line_count)
            .sum();
        let bytes = shards.iter().map(|shard| plan.shards[*shard].bytes).sum();
        let cyclic = shards.len() > 1
            || shards
                .iter()
                .any(|shard| plan.shards[*shard].compile_dependencies.contains(shard));
        for shard in &shards {
            shard_to_component[*shard] = final_id;
        }
        final_components.push(SccComponent {
            id: final_id,
            witness: build_witness(&shards),
            shards,
            dependencies: remapped_dependencies,
            layer,
            lines,
            bytes,
            cyclic,
        });
    }
    if raw_shard_to_component.contains(&usize::MAX) || shard_to_component.contains(&usize::MAX) {
        return Err("SCC condensation left a shard unmapped".to_owned());
    }
    let cyclic_components = final_components
        .iter()
        .filter(|component| component.cyclic)
        .count();
    let largest_component = final_components
        .iter()
        .map(|component| component.shards.len())
        .max()
        .unwrap_or(0);
    Ok(SccPlan {
        components: final_components,
        shard_to_component,
        cyclic_components,
        largest_component,
        state: PhantomData,
    })
}

#[must_use]
pub fn components_by_layer(plan: &SccPlan<Condensed>) -> BTreeMap<usize, Vec<usize>> {
    let mut result = BTreeMap::<usize, Vec<usize>>::new();
    for component in &plan.components {
        result
            .entry(component.layer)
            .or_default()
            .push(component.id);
    }
    result
}

#[must_use]
pub fn measure_sccs(plan: &SccPlan<Condensed>) -> SccMetrics {
    let by_layer = components_by_layer(plan);
    SccMetrics {
        shards: plan.shard_to_component.len(),
        components: plan.components.len(),
        cyclic_components: plan.cyclic_components,
        collapsed_shards: plan
            .shard_to_component
            .len()
            .saturating_sub(plan.components.len()),
        largest_component: plan.largest_component,
        component_edges: plan
            .components
            .iter()
            .map(|component| component.dependencies.len())
            .sum(),
        layers: by_layer.len(),
        widest_layer: by_layer.values().map(Vec::len).max().unwrap_or(0),
    }
}

#[must_use]
pub fn render_sccs_tsv(plan: &SccPlan<Condensed>) -> String {
    let mut output = String::from(
        "component layer shards first_shard last_shard dependencies lines bytes cyclic\
",
    );
    for component in &plan.components {
        let dependencies = component
            .dependencies
            .iter()
            .map(ToString::to_string)
            .collect::<Vec<_>>()
            .join(",");
        let _ = writeln!(
            output,
            "{} {} {} {} {} {} {} {} {}",
            component.id,
            component.layer,
            component.shards.len(),
            component.shards.first().copied().unwrap_or(0),
            component.shards.last().copied().unwrap_or(0),
            dependencies,
            component.lines,
            component.bytes,
            component.cyclic
        );
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{
        CompilerProfile, DeclarationId, ReferenceMode, Shard, SourceText, SplitPolicy,
    };
    use std::path::PathBuf;

    fn shard(id: usize, dependencies: &[usize]) -> Shard {
        Shard {
            id,
            declarations: vec![DeclarationId(id)],
            direct_dependencies: dependencies.iter().copied().collect(),
            compile_dependencies: dependencies.iter().copied().collect(),
            ambient_opens: Vec::new(),
            line_count: 10,
            bytes: 100,
            layer: 0,
            oversize: false,
            fingerprint: id as u64 + 1,
        }
    }

    fn split(shards: Vec<Shard>) -> SplitPlan {
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
    fn mutual_cycle_becomes_one_component() {
        let plan = split(vec![shard(0, &[1]), shard(1, &[0]), shard(2, &[1])]);
        let condensed = condense_compile_sccs(&plan).expect("condensed");
        assert_eq!(condensed.components.len(), 2);
        assert_eq!(condensed.components[0].shards, vec![0, 1]);
        assert!(condensed.components[0].cyclic);
        assert_eq!(condensed.components[1].shards, vec![2]);
        assert_eq!(condensed.components[1].dependencies, BTreeSet::from([0]));
        assert_eq!(condensed.components[1].layer, 1);
    }

    #[test]
    fn forward_dependency_is_reordered_without_fusion() {
        let plan = split(vec![shard(0, &[1]), shard(1, &[])]);
        let condensed = condense_compile_sccs(&plan).expect("condensed");
        assert_eq!(condensed.components[0].shards, vec![1]);
        assert_eq!(condensed.components[1].shards, vec![0]);
        assert_eq!(condensed.components[1].dependencies, BTreeSet::from([0]));
    }

    #[test]
    fn self_loop_is_cyclic_but_remains_singleton() {
        let plan = split(vec![shard(0, &[0])]);
        let condensed = condense_compile_sccs(&plan).expect("condensed");
        assert_eq!(condensed.components.len(), 1);
        assert!(condensed.components[0].cyclic);
        assert_eq!(condensed.cyclic_components, 1);
    }

    #[test]
    fn out_of_range_dependency_is_rejected() {
        let plan = split(vec![shard(0, &[1])]);
        let error = condense_compile_sccs(&plan).expect_err("range");
        assert!(error.contains("out-of-range"));
    }
}
