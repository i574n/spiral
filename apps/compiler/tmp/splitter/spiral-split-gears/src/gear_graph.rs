mod gear_compile_order;
mod gear_cyclic_source;

use gear_compile_order::compile_order;
use gear_cyclic_source::fuse_cyclic_sources;
use rayon::prelude::*;
use spiral_split_anonymous_boundary::{render_boundary_rewrite_tsv, rewrite_gear_boundaries};
use spiral_split_bridge_receipt::read_bridge_tsv;
use spiral_split_contextual_constructor::{
    render_contextual_constructor_tsv, rewrite_contextual_constructors,
};
use spiral_split_gear_bridge::{BridgeReport, render_bridge_tsv, rewrite_anonymous_record_bridges};
use spiral_split_gear_identity::fuse_identity_groups_with_bridge_report;
use spiral_split_gear_objective::{LayerObjective, PlanningPrefix};
use spiral_split_gear_order::stable_topological_order;
use spiral_split_gear_scc::{
    Condensed, SccPlan, components_by_layer, condense_compile_sccs, render_sccs_tsv,
};
use spiral_split_generated_dependency::{
    GeneratedDependency, qualify_generated_helper_references,
    qualify_unique_type_annotation_references, scan_generated_dependencies,
};
use spiral_split_model::{PROJECT_OVERHEAD_LINES, SplitPlan, fnv1a64, planning_lines};
use spiral_split_union_forward_identity::{
    render_union_forward_tsv, rewrite_union_forward_identities,
};
use std::cmp::Reverse;
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::Write as _;
use std::fs;
use std::marker::PhantomData;
use std::path::{Path, PathBuf};

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Planned;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Emitted;

/// How condensed components are packed into gears.
#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum GearPacking {
    /// Per-dependency-layer bin packing (hop-count layers).
    Layer,
    /// Packing on a simulated build timeline that bounds the critical path (`pack_components_on_timeline`).
    Timeline,
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub struct GearPolicy {
    pub target_lines: usize,
    pub max_lines: usize,
    pub max_teeth: usize,
    pub assembly_cost: u64,
    pub reference_cost: u64,
    pub imbalance_cost: u64,
    pub packing: GearPacking,
}

impl Default for GearPolicy {
    fn default() -> Self {
        Self {
            target_lines: 1_500,
            max_lines: 2_400,
            max_teeth: 32,
            assembly_cost: 20_000,
            reference_cost: 120,
            imbalance_cost: 8,
            packing: GearPacking::Timeline,
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum GearOrigin {
    Layer {
        source_layer: usize,
    },
    Balanced {
        lines: usize,
        teeth: usize,
        external_references: usize,
        inner: Box<GearOrigin>,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Gear {
    pub id: usize,
    pub source_layer: usize,
    pub shards: Vec<usize>,
    pub dependencies: BTreeSet<usize>,
    pub lines: usize,
    pub bytes: usize,
    pub fingerprint: u64,
    pub oversize: bool,
    pub origin: GearOrigin,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearPlan<State> {
    pub policy: GearPolicy,
    pub gears: Vec<Gear>,
    pub shard_to_gear: Vec<usize>,
    pub score: u64,
    pub scc_components: usize,
    pub cyclic_sccs: usize,
    pub max_scc_shards: usize,
    pub identity_initial_groups: usize,
    pub identity_affinity_unions: usize,
    pub identity_cycle_groups: usize,
    pub identity_largest_cycle_groups: usize,
    pub mutable_address_unions: usize,
    pub mutable_address_cycle_collapses: usize,
    pub series_unions: usize,
    state: PhantomData<State>,
}

impl<State> GearPlan<State> {
    #[must_use]
    pub fn restage<Next>(self) -> GearPlan<Next> {
        GearPlan {
            policy: self.policy,
            gears: self.gears,
            shard_to_gear: self.shard_to_gear,
            score: self.score,
            scc_components: self.scc_components,
            cyclic_sccs: self.cyclic_sccs,
            max_scc_shards: self.max_scc_shards,
            identity_initial_groups: self.identity_initial_groups,
            identity_affinity_unions: self.identity_affinity_unions,
            identity_cycle_groups: self.identity_cycle_groups,
            identity_largest_cycle_groups: self.identity_largest_cycle_groups,
            mutable_address_unions: self.mutable_address_unions,
            mutable_address_cycle_collapses: self.mutable_address_cycle_collapses,
            series_unions: self.series_unions,
            state: PhantomData,
        }
    }
}

#[derive(Clone, Debug, PartialEq)]
pub struct GearMetrics {
    pub shards: usize,
    pub gears: usize,
    pub assemblies_removed: usize,
    pub gear_edges: usize,
    pub layers: usize,
    pub widest_layer: usize,
    pub max_gear_lines: usize,
    pub p50_gear_lines: usize,
    pub p95_gear_lines: usize,
    pub oversize_gears: usize,
    pub scc_components: usize,
    pub cyclic_sccs: usize,
    pub max_scc_shards: usize,
    pub identity_initial_groups: usize,
    pub identity_affinity_unions: usize,
    pub identity_cycle_groups: usize,
    pub identity_largest_cycle_groups: usize,
    pub mutable_address_unions: usize,
    pub mutable_address_cycle_collapses: usize,
    pub series_unions: usize,
    pub critical_path_gears: usize,
    pub critical_path_lines: usize,
    pub barrier_critical_lines: usize,
    pub estimated_parallelism: f64,
    pub dag_estimated_parallelism: f64,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearEmitOptions {
    pub output_root: PathBuf,
    pub assembly_root: PathBuf,
    pub assembly_overlay_root: Option<PathBuf>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GearEmitReceipt {
    pub gears: usize,
    pub files: usize,
    pub source_fingerprint: u64,
    pub output_root: PathBuf,
}

fn validate_policy(policy: GearPolicy) -> Result<(), String> {
    if policy.target_lines == 0 {
        return Err("gear target_lines must be positive".to_owned());
    }
    if policy.max_lines < policy.target_lines {
        return Err("gear max_lines must be at least target_lines".to_owned());
    }
    if policy.max_teeth == 0 {
        return Err("gear max_teeth must be positive".to_owned());
    }
    Ok(())
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
struct LayerBin {
    components: Vec<usize>,
    lines: usize,
    teeth: usize,
}

fn pack_component_layer(
    sccs: &SccPlan<Condensed>,
    components: &[usize],
    bin_count: usize,
    policy: GearPolicy,
) -> Option<Vec<Vec<usize>>> {
    let mut order = components.to_vec();
    order.sort_by_key(|component| {
        let value = &sccs.components[*component];
        (
            Reverse(value.lines),
            Reverse(value.shards.len()),
            *component,
        )
    });
    let mut bins = vec![LayerBin::default(); bin_count];
    for component in order {
        let value = &sccs.components[component];
        let forced_oversize =
            value.lines > policy.max_lines || value.shards.len() > policy.max_teeth;
        let chosen = bins
            .iter()
            .enumerate()
            .filter(|(_, bin)| {
                if forced_oversize {
                    bin.components.is_empty()
                } else {
                    bin.lines + value.lines <= policy.max_lines
                        && bin.teeth + value.shards.len() <= policy.max_teeth
                }
            })
            .min_by_key(|(index, bin)| (bin.lines, bin.teeth, *index))
            .map(|(index, _)| index)?;
        bins[chosen].components.push(component);
        bins[chosen].lines += value.lines;
        bins[chosen].teeth += value.shards.len();
    }
    let mut groups = bins
        .into_iter()
        .filter(|bin| !bin.components.is_empty())
        .map(|bin| {
            let mut shards = bin
                .components
                .into_iter()
                .flat_map(|component| sccs.components[component].shards.iter().copied())
                .collect::<Vec<_>>();
            shards.sort_unstable();
            shards.dedup();
            shards
        })
        .collect::<Vec<_>>();
    groups.sort_by_key(|shards| shards.first().copied().unwrap_or(usize::MAX));
    Some(groups)
}

fn layer_partition_secondary_cost(
    plan: &SplitPlan,
    groups: &[Vec<usize>],
    policy: GearPolicy,
) -> u64 {
    groups
        .iter()
        .map(|shards| segment_cost(plan, shards, policy))
        .fold(0, u64::saturating_add)
}

fn partition_component_layer(
    plan: &SplitPlan,
    sccs: &SccPlan<Condensed>,
    components: &[usize],
    policy: GearPolicy,
    prefix: &PlanningPrefix,
) -> Result<(Vec<Vec<usize>>, LayerObjective), String> {
    let mut best = None::<(LayerObjective, Vec<Vec<usize>>)>;
    for bin_count in 1..=components.len() {
        let Some(groups) = pack_component_layer(sccs, components, bin_count, policy) else {
            continue;
        };
        let secondary_cost = layer_partition_secondary_cost(plan, &groups, policy);
        let objective = prefix.score_layer(plan, &groups, secondary_cost)?;
        let candidate = (objective, groups);
        if best.as_ref().is_none_or(|current| candidate < *current) {
            best = Some(candidate);
        }
    }
    let Some((objective, groups)) = best else {
        return Err("gear planner could not pack condensed dependency layer".to_owned());
    };
    Ok((groups, objective))
}

fn imbalance(lines: usize, target: usize) -> u64 {
    lines.abs_diff(target) as u64
}

fn segment_cost(plan: &SplitPlan, shards: &[usize], policy: GearPolicy) -> u64 {
    let lines = shards
        .iter()
        .map(|id| plan.shards[*id].line_count)
        .sum::<usize>();
    let references = shards
        .iter()
        .flat_map(|id| plan.shards[*id].compile_dependencies.iter().copied())
        .collect::<BTreeSet<_>>()
        .len();
    let overflow = lines.saturating_sub(policy.max_lines) as u64;
    policy.assembly_cost
        + references as u64 * policy.reference_cost
        + imbalance(lines, policy.target_lines) * policy.imbalance_cost
        + overflow * overflow * policy.imbalance_cost
}

fn gear_fingerprint(plan: &SplitPlan, shards: &[usize]) -> u64 {
    let mut bytes = Vec::with_capacity(shards.len() * 8);
    for shard in shards {
        bytes.extend_from_slice(&plan.shards[*shard].fingerprint.to_le_bytes());
    }
    fnv1a64(&bytes)
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct SeriesFusion {
    groups: Vec<(usize, Vec<usize>)>,
    unions: usize,
}

type GroupDependencyGraph = (Vec<BTreeSet<usize>>, Vec<BTreeSet<usize>>);

fn group_dependency_graph(
    plan: &SplitPlan,
    groups: &[(usize, Vec<usize>)],
) -> Result<GroupDependencyGraph, String> {
    let mut shard_to_group = vec![usize::MAX; plan.shards.len()];
    for (group, (_, shards)) in groups.iter().enumerate() {
        for shard in shards {
            if *shard >= shard_to_group.len() {
                return Err(format!("series fusion received unknown shard {shard}"));
            }
            shard_to_group[*shard] = group;
        }
    }
    if shard_to_group.contains(&usize::MAX) {
        return Err("series fusion received an incomplete shard partition".to_owned());
    }
    let mut dependencies = vec![BTreeSet::new(); groups.len()];
    let mut successors = vec![BTreeSet::new(); groups.len()];
    for (consumer, (_, shards)) in groups.iter().enumerate() {
        for dependency in shards
            .iter()
            .flat_map(|shard| plan.shards[*shard].compile_dependencies.iter())
        {
            let provider = shard_to_group[*dependency];
            if provider == consumer {
                continue;
            }
            if provider >= consumer {
                return Err(format!(
                    "series fusion received non-topological edge {provider}->{consumer}"
                ));
            }
            dependencies[consumer].insert(provider);
            successors[provider].insert(consumer);
        }
    }
    Ok((dependencies, successors))
}

fn recompute_series_layers(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
) -> Result<Vec<(usize, Vec<usize>)>, String> {
    let (dependencies, _) = group_dependency_graph(plan, &groups)?;
    let mut layers = vec![0usize; groups.len()];
    let mut result = Vec::with_capacity(groups.len());
    for (group, (_, shards)) in groups.into_iter().enumerate() {
        let layer = dependencies[group]
            .iter()
            .map(|dependency| layers[*dependency] + 1)
            .max()
            .unwrap_or(0);
        layers[group] = layer;
        result.push((layer, shards));
    }
    Ok(result)
}

fn fuse_series_corridors(
    plan: &SplitPlan,
    mut groups: Vec<(usize, Vec<usize>)>,
    policy: GearPolicy,
) -> Result<SeriesFusion, String> {
    let mut unions = 0usize;
    loop {
        let (dependencies, successors) = group_dependency_graph(plan, &groups)?;
        let candidate = (0..groups.len()).find_map(|provider| {
            let consumer = successors[provider].iter().next().copied()?;
            if successors[provider].len() != 1
                || dependencies[consumer].len() != 1
                || !dependencies[consumer].contains(&provider)
            {
                return None;
            }
            let lines = groups[provider]
                .1
                .iter()
                .chain(&groups[consumer].1)
                .map(|shard| planning_lines(plan.shards[*shard].line_count))
                .sum::<usize>();
            let teeth = groups[provider].1.len() + groups[consumer].1.len();
            (lines <= policy.max_lines && teeth <= policy.max_teeth).then_some((provider, consumer))
        });
        let Some((provider, consumer)) = candidate else {
            break;
        };
        let mut shards = groups[provider].1.iter().copied().collect::<BTreeSet<_>>();
        shards.extend(groups[consumer].1.iter().copied());
        groups[provider].1 = shards.into_iter().collect();
        groups.remove(consumer);
        unions += 1;
    }
    Ok(SeriesFusion {
        groups: recompute_series_layers(plan, groups)?,
        unions,
    })
}

/// Packs condensed components into gears on a simulated build timeline. Every gear is one
/// `dotnet build` that starts when its provider gears finish and costs its lines plus a fixed project
/// overhead. The former per-layer bin packing grouped components by hop count, so a small component on
/// the critical chain shared a gear with large unrelated components of the same layer, and the gear
/// critical path grew back to ~67k lines from a ~39k-line shard graph. Here components are placed in
/// topological order; a component joins the latest-finishing gear among its providers (or another
/// provider gear) only if, after propagating the growth to every downstream gear, each gear still
/// finishes within its members' latest finish (from the all-singleton schedule plus an allowance).
/// Otherwise it starts a new gear. Gears are ranked and edges only ever go from lower to higher rank,
/// so the gear graph stays acyclic. Timeline and `merge_cap` both weigh components with `planning_lines`:
/// greedy packing leaves many gears just under capacity, so with exact lines a few lines added to one
/// body tipped a gear over and reshaped the gears downstream.
fn pack_components_on_timeline(
    sccs: &SccPlan<Condensed>,
    policy: GearPolicy,
    allowance: usize,
) -> Vec<Vec<usize>> {
    struct Group {
        components: Vec<usize>,
        lines: usize,
        weight: usize,
        start: usize,
        finish: usize,
        cap: usize,
        rank: usize,
        providers: BTreeSet<usize>,
        consumers: BTreeSet<usize>,
    }
    let components = &sccs.components;
    let count = components.len();
    let mut order = (0..count).collect::<Vec<_>>();
    order.sort_by_key(|component| {
        (
            components[*component].layer,
            components[*component].shards.first().copied().unwrap_or(usize::MAX),
        )
    });
    // All-singleton schedule and latest finishes.
    let overhead = PROJECT_OVERHEAD_LINES;
    let weight_of = |component: usize| planning_lines(components[component].lines);
    let mut finish_single = vec![0usize; count];
    for &component in &order {
        let ready = components[component]
            .dependencies
            .iter()
            .filter(|dependency| **dependency != component)
            .map(|dependency| finish_single[*dependency])
            .max()
            .unwrap_or(0);
        finish_single[component] = ready + overhead + weight_of(component);
    }
    // Slack relative to the critical path (so it does not shrink when `planning_lines` rounds the many
    // small components up), and a whole critical path of it: gear builds run 2 MSBuild nodes wide on a
    // workstation, where fewer projects beat a wider graph (141 gears instead of 268 on the hopac core).
    let floor = finish_single.iter().copied().max().unwrap_or(0);
    let horizon = floor + allowance.max(floor);
    let mut latest_finish = vec![horizon; count];
    for &component in order.iter().rev() {
        let latest_start = latest_finish[component]
            .saturating_sub(weight_of(component) + overhead);
        for dependency in &components[component].dependencies {
            if *dependency != component {
                latest_finish[*dependency] = latest_finish[*dependency].min(latest_start);
            }
        }
    }
    let merge_cap = std::env::var("SPIRAL_GEAR_MERGE_LINES")
        .ok()
        .and_then(|value| value.parse::<usize>().ok())
        .unwrap_or(policy.max_lines);
    let mut groups: Vec<Group> = Vec::new();
    let mut group_of = vec![usize::MAX; count];
    for &component in &order {
        let lines = components[component].lines;
        let weight = weight_of(component);
        let provider_groups = components[component]
            .dependencies
            .iter()
            .filter(|dependency| **dependency != component)
            .map(|dependency| group_of[*dependency])
            .filter(|group| *group != usize::MAX)
            .collect::<BTreeSet<_>>();
        let mut candidates = provider_groups.iter().copied().collect::<Vec<_>>();
        candidates.sort_by_key(|group| std::cmp::Reverse(groups[*group].finish));
        // Also consider the most recent gears as siblings: packing independent components together is
        // what amortizes the fixed per-project overhead, when the timeline has room for it.
        for recent in (0..groups.len()).rev().take(8) {
            if !candidates.contains(&recent) {
                candidates.push(recent);
            }
        }
        let mut placed = None;
        for target in candidates {
            if groups[target].weight + weight > merge_cap {
                continue;
            }
            if provider_groups
                .iter()
                .any(|group| *group != target && groups[*group].rank >= groups[target].rank)
            {
                continue;
            }
            // Tentatively grow `target` and propagate finishes downstream; roll back on violation.
            let mut log = Vec::<(usize, usize, usize)>::new();
            let ready = provider_groups
                .iter()
                .filter(|group| **group != target)
                .map(|group| groups[*group].finish)
                .max()
                .unwrap_or(0);
            log.push((target, groups[target].start, groups[target].finish));
            groups[target].start = groups[target].start.max(ready);
            groups[target].lines += lines;
            groups[target].weight += weight;
            groups[target].finish = groups[target].start + overhead + groups[target].weight;
            let cap = groups[target].cap.min(latest_finish[component]);
            let mut ok = groups[target].finish <= cap;
            let mut queue = groups[target].consumers.iter().copied().collect::<Vec<_>>();
            while ok {
                let Some(consumer) = queue.pop() else { break };
                let start = groups[consumer]
                    .providers
                    .iter()
                    .map(|provider| groups[*provider].finish)
                    .max()
                    .unwrap_or(0);
                if start <= groups[consumer].start {
                    continue;
                }
                log.push((consumer, groups[consumer].start, groups[consumer].finish));
                groups[consumer].start = start;
                groups[consumer].finish = start + overhead + groups[consumer].weight;
                if groups[consumer].finish > groups[consumer].cap {
                    ok = false;
                }
                queue.extend(groups[consumer].consumers.iter().copied());
            }
            if ok {
                groups[target].cap = cap;
                placed = Some(target);
                break;
            }
            groups[target].lines -= lines;
            groups[target].weight -= weight;
            for (group, start, finish) in log.into_iter().rev() {
                groups[group].start = start;
                groups[group].finish = finish;
            }
        }
        let target = placed.unwrap_or_else(|| {
            let start = provider_groups
                .iter()
                .map(|group| groups[*group].finish)
                .max()
                .unwrap_or(0);
            groups.push(Group {
                components: Vec::new(),
                lines,
                weight,
                start,
                finish: start + overhead + weight,
                cap: latest_finish[component],
                rank: groups.len(),
                providers: BTreeSet::new(),
                consumers: BTreeSet::new(),
            });
            groups.len() - 1
        });
        groups[target].components.push(component);
        group_of[component] = target;
        for provider in provider_groups {
            if provider != target {
                groups[target].providers.insert(provider);
                groups[provider].consumers.insert(target);
            }
        }
    }
    groups
        .into_iter()
        .map(|group| {
            let mut shards = group
                .components
                .into_iter()
                .flat_map(|component| components[component].shards.iter().copied())
                .collect::<Vec<_>>();
            shards.sort_unstable();
            shards
        })
        .collect()
}

fn plan_gears_with_bridge_report(
    plan: &SplitPlan,
    policy: GearPolicy,
    bridge_report: &BridgeReport,
) -> Result<GearPlan<Planned>, String> {
    validate_policy(policy)?;
    if plan.shards.is_empty() {
        return Err("cannot plan gears for an empty split".to_owned());
    }
    let sccs = condense_compile_sccs(plan)?;
    let mut groups = Vec::<(usize, Vec<usize>)>::new();
    let layer_packing = policy.packing == GearPacking::Layer
        || std::env::var("SPIRAL_GEAR_PACKING").as_deref() == Ok("layer");
    if layer_packing {
        // Former per-layer bin packing (GearPacking::Layer), kept for comparison benchmarks.
        let by_layer = components_by_layer(&sccs);
        let mut prefix = PlanningPrefix::new(plan.shards.len());
        for (layer, components) in by_layer {
            let (layer_groups, objective) =
                partition_component_layer(plan, &sccs, &components, policy, &prefix)?;
            prefix.commit_layer(plan, &layer_groups, objective.secondary_cost)?;
            groups.extend(layer_groups.into_iter().map(|group| (layer, group)));
        }
    } else {
        let allowance = policy.max_lines.saturating_mul(4);
        let packed = pack_components_on_timeline(&sccs, policy, allowance);
        groups = recompute_series_layers(plan, packed.into_iter().map(|shards| (0, shards)).collect())?;
    }
    // Anonymous-record identities and address-taken top-level mutables must
    // remain in the same assembly as their consumers when bridge rewriting
    // cannot preserve the compiler's hidden assembly identity.
    let identity_fusion = fuse_identity_groups_with_bridge_report(plan, groups, bridge_report)?;
    let series_fusion = fuse_series_corridors(plan, identity_fusion.groups, policy)?;
    let groups = series_fusion.groups;
    let mut shard_to_gear = vec![usize::MAX; plan.shards.len()];
    for (gear_id, (_, shards)) in groups.iter().enumerate() {
        for shard in shards {
            shard_to_gear[*shard] = gear_id;
        }
    }
    if shard_to_gear.contains(&usize::MAX) {
        return Err("gear plan left at least one shard unmapped".to_owned());
    }
    let gears = groups
        .into_iter()
        .enumerate()
        .map(|(id, (source_layer, shards))| {
            let dependencies = shards
                .iter()
                .flat_map(|shard| plan.shards[*shard].compile_dependencies.iter().copied())
                .map(|dependency| shard_to_gear[dependency])
                .filter(|dependency| *dependency != id)
                .collect::<BTreeSet<_>>();
            let lines = shards
                .iter()
                .map(|shard| plan.shards[*shard].line_count)
                .sum::<usize>();
            let bytes = shards
                .iter()
                .map(|shard| plan.shards[*shard].bytes)
                .sum::<usize>();
            let origin = GearOrigin::Balanced {
                lines,
                teeth: shards.len(),
                external_references: dependencies.len(),
                inner: Box::new(GearOrigin::Layer { source_layer }),
            };
            Gear {
                id,
                source_layer,
                fingerprint: gear_fingerprint(plan, &shards),
                oversize: lines > policy.max_lines,
                shards,
                dependencies,
                lines,
                bytes,
                origin,
            }
        })
        .collect::<Vec<_>>();
    for gear in &gears {
        if gear
            .dependencies
            .iter()
            .any(|dependency| *dependency >= gear.id)
        {
            return Err(format!(
                "gear {} has a non-backward dependency after quotienting",
                gear.id
            ));
        }
    }
    let score = dag_critical_path(&gears).0 as u64;
    Ok(GearPlan {
        policy,
        gears,
        shard_to_gear,
        score,
        scc_components: sccs.components.len(),
        cyclic_sccs: sccs.cyclic_components,
        max_scc_shards: sccs.largest_component,
        identity_initial_groups: identity_fusion.initial_groups,
        identity_affinity_unions: identity_fusion.affinity_unions,
        identity_cycle_groups: identity_fusion.cycle_groups,
        identity_largest_cycle_groups: identity_fusion.largest_cycle_groups,
        mutable_address_unions: identity_fusion.mutable_address_unions,
        mutable_address_cycle_collapses: identity_fusion.cycle_collapses,
        series_unions: series_fusion.unions,
        state: PhantomData,
    })
}

pub fn plan_gears(plan: &SplitPlan, policy: GearPolicy) -> Result<GearPlan<Planned>, String> {
    plan_gears_with_bridge_report(plan, policy, &BridgeReport::default())
}

pub fn plan_gears_from_emitted(
    plan: &SplitPlan,
    output_root: &Path,
    policy: GearPolicy,
) -> Result<GearPlan<Planned>, String> {
    let receipt = output_root.join("gear-preplan-anonymous-record-bridges.tsv");
    let bridge_report = if receipt.is_file() {
        read_bridge_tsv(&receipt)?
    } else {
        let report = rewrite_anonymous_record_bridges(plan, output_root)?;
        fs::write(&receipt, render_bridge_tsv(&report))
            .map_err(|error| format!("write preplan bridge receipt: {error}"))?;
        report
    };
    plan_gears_with_bridge_report(plan, policy, &bridge_report)
}

fn percentile(values: &[usize], numerator: usize, denominator: usize) -> usize {
    if values.is_empty() {
        return 0;
    }
    let index = ((values.len() - 1) * numerator) / denominator;
    values[index]
}

fn dag_critical_path(gears: &[Gear]) -> (usize, usize) {
    let mut path_lines = vec![0usize; gears.len()];
    let mut path_gears = vec![0usize; gears.len()];
    for gear in gears {
        let (dependency_lines, dependency_gears) = gear
            .dependencies
            .iter()
            .map(|dependency| (path_lines[*dependency], path_gears[*dependency]))
            .max_by_key(|(lines, count)| (*lines, *count))
            .unwrap_or((0, 0));
        path_lines[gear.id] = dependency_lines + gear.lines;
        path_gears[gear.id] = dependency_gears + 1;
    }
    gears
        .iter()
        .map(|gear| (path_lines[gear.id], path_gears[gear.id]))
        .max_by_key(|(lines, count)| (*lines, *count))
        .unwrap_or((0, 0))
}

#[must_use]
pub fn measure_gears(plan: &SplitPlan, gears: &GearPlan<Planned>) -> GearMetrics {
    let mut lines = gears
        .gears
        .iter()
        .map(|gear| gear.lines)
        .collect::<Vec<_>>();
    lines.sort_unstable();
    let mut by_layer = BTreeMap::<usize, usize>::new();
    for gear in &gears.gears {
        *by_layer.entry(gear.source_layer).or_default() += 1;
    }
    let total_lines = lines.iter().sum::<usize>();
    let barrier_critical_lines = by_layer
        .keys()
        .map(|layer| {
            gears
                .gears
                .iter()
                .filter(|gear| gear.source_layer == *layer)
                .map(|gear| gear.lines)
                .max()
                .unwrap_or(0)
        })
        .sum::<usize>();
    let (critical_path_lines, critical_path_gears) = dag_critical_path(&gears.gears);
    GearMetrics {
        shards: plan.shards.len(),
        gears: gears.gears.len(),
        assemblies_removed: plan.shards.len().saturating_sub(gears.gears.len()),
        gear_edges: gears.gears.iter().map(|gear| gear.dependencies.len()).sum(),
        layers: by_layer.len(),
        widest_layer: by_layer.values().copied().max().unwrap_or(0),
        max_gear_lines: lines.last().copied().unwrap_or(0),
        p50_gear_lines: percentile(&lines, 50, 100),
        p95_gear_lines: percentile(&lines, 95, 100),
        oversize_gears: gears.gears.iter().filter(|gear| gear.oversize).count(),
        scc_components: gears.scc_components,
        cyclic_sccs: gears.cyclic_sccs,
        max_scc_shards: gears.max_scc_shards,
        identity_initial_groups: gears.identity_initial_groups,
        identity_affinity_unions: gears.identity_affinity_unions,
        identity_cycle_groups: gears.identity_cycle_groups,
        identity_largest_cycle_groups: gears.identity_largest_cycle_groups,
        mutable_address_unions: gears.mutable_address_unions,
        mutable_address_cycle_collapses: gears.mutable_address_cycle_collapses,
        series_unions: gears.series_unions,
        critical_path_gears,
        critical_path_lines,
        barrier_critical_lines,
        estimated_parallelism: if barrier_critical_lines == 0 {
            0.0
        } else {
            total_lines as f64 / barrier_critical_lines as f64
        },
        dag_estimated_parallelism: if critical_path_lines == 0 {
            0.0
        } else {
            total_lines as f64 / critical_path_lines as f64
        },
    }
}

#[must_use]
pub fn render_gears_tsv(gears: &GearPlan<Planned>) -> String {
    let mut output = String::from(
        "gear	source_layer	first_shard	last_shard	teeth	lines	bytes	dependencies	fingerprint	oversize
",
    );
    for gear in &gears.gears {
        let dependencies = gear
            .dependencies
            .iter()
            .map(ToString::to_string)
            .collect::<Vec<_>>()
            .join(",");
        let _ = writeln!(
            output,
            "{}	{}	{}	{}	{}	{}	{}	{}	{}	{}",
            gear.id,
            gear.source_layer,
            gear.shards.first().copied().unwrap_or(0),
            gear.shards.last().copied().unwrap_or(0),
            gear.shards.len(),
            gear.lines,
            gear.bytes,
            dependencies,
            gear.fingerprint,
            gear.oversize
        );
    }
    output
}

#[must_use]
pub fn render_gear_edges_tsv(gears: &GearPlan<Planned>) -> String {
    let mut output = String::from(
        "gear	dependency
",
    );
    for gear in &gears.gears {
        for dependency in &gear.dependencies {
            let _ = writeln!(output, "{}	{dependency}", gear.id);
        }
    }
    output
}

#[must_use]
pub fn render_gear_metrics_tsv(metrics: &GearMetrics) -> String {
    let base = format!(
        "metric	value
shards	{}
gears	{}
assemblies_removed	{}
gear_edges	{}
layers	{}
widest_layer	{}
max_gear_lines	{}
p50_gear_lines	{}
p95_gear_lines	{}
oversize_gears	{}
series_unions	{}
critical_path_gears	{}
critical_path_lines	{}
barrier_critical_lines	{}
estimated_parallelism	{:.4}
dag_estimated_parallelism	{:.4}
",
        metrics.shards,
        metrics.gears,
        metrics.assemblies_removed,
        metrics.gear_edges,
        metrics.layers,
        metrics.widest_layer,
        metrics.max_gear_lines,
        metrics.p50_gear_lines,
        metrics.p95_gear_lines,
        metrics.oversize_gears,
        metrics.series_unions,
        metrics.critical_path_gears,
        metrics.critical_path_lines,
        metrics.barrier_critical_lines,
        metrics.estimated_parallelism,
        metrics.dag_estimated_parallelism
    );
    format!(
        "{base}scc_components {}\ncyclic_sccs {}\nmax_scc_shards {}\nidentity_initial_groups {}\nidentity_affinity_unions {}\nidentity_cycle_groups {}\nidentity_largest_cycle_groups {}\nmutable_address_unions {}\nidentity_cycle_collapses {}\nmutable_address_cycle_collapses {}\n",
        metrics.scc_components,
        metrics.cyclic_sccs,
        metrics.max_scc_shards,
        metrics.identity_initial_groups,
        metrics.identity_affinity_unions,
        metrics.identity_cycle_groups,
        metrics.identity_largest_cycle_groups,
        metrics.mutable_address_unions,
        metrics.mutable_address_cycle_collapses,
        metrics.mutable_address_cycle_collapses
    )
}

fn part_name(id: usize) -> String {
    format!("Part{id:04}")
}

fn gear_name(id: usize) -> String {
    format!("Gear{id:04}")
}

fn xml_escape(value: &str) -> String {
    value
        .replace('&', "&amp;")
        .replace('<', "&lt;")
        .replace('>', "&gt;")
        .replace('"', "&quot;")
        .replace('\'', "&apos;")
}

fn external_references(options: &GearEmitOptions) -> Vec<(String, PathBuf)> {
    spiral_split_assembly_refs::discover_assembly_references_with_overlay(
        &options.assembly_root,
        options.assembly_overlay_root.as_deref(),
    )
    .unwrap_or_default()
}

fn render_reference_items(output: &mut String, references: &[(String, PathBuf)]) {
    if references.is_empty() {
        return;
    }
    output.push_str(
        "  <ItemGroup>
",
    );
    for (name, path) in references {
        let _ = writeln!(
            output,
            "    <Reference Include=\"{}\"><HintPath>{}</HintPath><Private>true</Private></Reference>",
            xml_escape(name),
            xml_escape(&path.display().to_string())
        );
    }
    output.push_str(
        "  </ItemGroup>
",
    );
}

fn compile_reference_dependencies(gears: &GearPlan<Planned>, gear: &Gear) -> BTreeSet<usize> {
    let mut dependencies = gear.dependencies.clone();
    let mut frontier = gear.dependencies.iter().copied().collect::<Vec<_>>();
    while let Some(dependency) = frontier.pop() {
        for ancestor in &gears.gears[dependency].dependencies {
            if dependencies.insert(*ancestor) {
                frontier.push(*ancestor);
            }
        }
    }
    dependencies
}

fn render_gear_project_with_dependencies(
    split: &SplitPlan,
    gear: &Gear,
    signature_dependencies: &BTreeSet<usize>,
    references: &[(String, PathBuf)],
) -> String {
    let name = gear_name(gear.id);
    let mut output = String::new();
    output.push_str(
        "<Project Sdk=\"Microsoft.NET.Sdk\">
  <PropertyGroup>
",
    );
    output.push_str(
        "    <TargetFramework>net11.0</TargetFramework>
",
    );
    output.push_str(
        "    <LangVersion>preview</LangVersion>
",
    );
    output.push_str(
        "    <OutputType>Library</OutputType>
",
    );
    let _ = writeln!(
        output,
        "    <AssemblyName>SpiralCompiler{name}</AssemblyName>"
    );
    output.push_str(
        "    <RootNamespace>Polyglot</RootNamespace>
",
    );
    output.push_str(
        "    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
",
    );
    output.push_str(
        "    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
",
    );
    output.push_str(
        "    <RestoreIgnoreFailedSources>true</RestoreIgnoreFailedSources>
",
    );
    output.push_str(
        "    <DefineConstants>_LINUX</DefineConstants>
",
    );
    output.push_str("    <OtherFlags>--nooptimizationdata --tailcalls- --crossoptimize- --compressmetadata-</OtherFlags>
");
    output.push_str(
        "  </PropertyGroup>
  <ItemGroup>
",
    );
    for shard in compile_order(split, &gear.shards) {
        let _ = writeln!(
            output,
            "    <Compile Include=\"{}.fs\" />",
            part_name(shard)
        );
    }
    output.push_str(
        "  </ItemGroup>
",
    );
    if !gear.dependencies.is_empty() {
        output.push_str(
            "  <ItemGroup>
",
        );
        for dependency in &gear.dependencies {
            let _ = writeln!(
                output,
                "    <ProjectReference Include=\"{}.fsproj\" ReferenceOutputAssembly=\"true\" />",
                gear_name(*dependency)
            );
        }
        output.push_str(
            "  </ItemGroup>
",
        );
    }
    if !signature_dependencies.is_empty() {
        output.push_str("  <ItemGroup>\n");
        for dependency in signature_dependencies {
            let dependency_name = gear_name(*dependency);
            let _ = writeln!(
                output,
                "    <ProjectReference Include=\"{dependency_name}.fsproj\" ReferenceOutputAssembly=\"true\" />"
            );
        }
        output.push_str("  </ItemGroup>\n");
    }
    render_reference_items(&mut output, references);
    output.push_str(
        "  <ItemGroup><FrameworkReference Include=\"Microsoft.AspNetCore.App\" /></ItemGroup>
</Project>
",
    );
    output
}

#[cfg(test)]
fn render_gear_project(split: &SplitPlan, gear: &Gear, references: &[(String, PathBuf)]) -> String {
    render_gear_project_with_dependencies(split, gear, &BTreeSet::new(), references)
}

fn render_gear_build_project(gears: &GearPlan<Planned>) -> String {
    let mut by_layer = BTreeMap::<usize, Vec<usize>>::new();
    for gear in &gears.gears {
        by_layer.entry(gear.source_layer).or_default().push(gear.id);
    }
    let mut output = String::from(
        "<Project>\n  <PropertyGroup>\n    <Configuration Condition=\"'$(Configuration)' == ''\">Release</Configuration>\n  </PropertyGroup>\n",
    );
    let mut previous = None::<String>;
    for (layer, ids) in by_layer {
        let target = format!("BuildLayer{layer:04}");
        let dependency = previous.as_ref().map_or(String::new(), |name| {
            format!(" DependsOnTargets=\"{name}\"")
        });
        let projects = ids
            .into_iter()
            .map(|id| format!("{}.fsproj", gear_name(id)))
            .collect::<Vec<_>>()
            .join(";");
        let _ = writeln!(output, "  <Target Name=\"{target}\"{dependency}>");
        let _ = writeln!(
            output,
            "    <MSBuild Projects=\"{projects}\" Targets=\"Build\" BuildInParallel=\"true\" Properties=\"Configuration=$(Configuration);BuildProjectReferences=false;Restore=false;UseSharedCompilation=false\" />"
        );
        output.push_str("  </Target>\n");
        previous = Some(target);
    }
    if let Some(last) = previous {
        let _ = writeln!(
            output,
            "  <Target Name=\"BuildGears\" DependsOnTargets=\"{last}\" />"
        );
        output.push_str("  <Target Name=\"BuildAll\" DependsOnTargets=\"BuildGears\">\n    <MSBuild Projects=\"GearRoot.fsproj\" Targets=\"Build\" Properties=\"Configuration=$(Configuration);BuildProjectReferences=false;Restore=false;UseSharedCompilation=false\" />\n  </Target>\n");
    }
    output.push_str("</Project>\n");
    output
}

fn render_root_project(gears: &GearPlan<Planned>) -> String {
    let mut output = String::from(
        "<Project Sdk=\"Microsoft.NET.Sdk\">
  <PropertyGroup>
    <TargetFramework>net11.0</TargetFramework>
    <LangVersion>preview</LangVersion>
    <OutputType>Library</OutputType>
    <AssemblyName>SpiralCompilerGearRoot</AssemblyName>
    <RootNamespace>Polyglot</RootNamespace>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <RestoreIgnoreFailedSources>true</RestoreIgnoreFailedSources>
  </PropertyGroup>
  <ItemGroup><Compile Include=\"GearRoot.fs\" /></ItemGroup>
  <ItemGroup>
",
    );
    for gear in &gears.gears {
        let _ = writeln!(
            output,
            "    <ProjectReference Include=\"{}.fsproj\" ReferenceOutputAssembly=\"true\" />",
            gear_name(gear.id)
        );
    }
    output.push_str(
        "  </ItemGroup>
</Project>
",
    );
    output
}

include!("gear_emit.rs");

include!("gear_graph_tests.rs");
