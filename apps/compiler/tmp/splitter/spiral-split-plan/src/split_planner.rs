use spiral_split_model::{
    DeclarationId, Linked, Program, ReferenceMode, Shard, SplitPlan, SplitPolicy, fnv1a64,
};
use std::collections::{BTreeMap, BTreeSet};

fn declaration_layers(program: &Program<Linked>) -> Vec<usize> {
    let mut layers = Vec::with_capacity(program.declarations.len());
    for declaration in &program.declarations {
        let layer = declaration
            .direct_dependencies
            .iter()
            .map(|dependency| layers[dependency.0])
            .max()
            .unwrap_or(0)
            + 1;
        layers.push(layer);
    }
    layers
}

/// Latest line-weighted finish of each declaration such that the whole graph still finishes within
/// the declaration critical path plus `allowance` lines. Dependencies always precede their consumers in
/// F# source order.
fn declaration_latest_finish(program: &Program<Linked>, allowance: usize) -> Vec<usize> {
    let count = program.declarations.len();
    let mut finishes = vec![0usize; count];
    for declaration in &program.declarations {
        let id = declaration.id.0;
        finishes[id] = declaration
            .direct_dependencies
            .iter()
            .map(|dependency| finishes[dependency.0])
            .max()
            .unwrap_or(0)
            + declaration.line_count();
    }
    let horizon = finishes.iter().copied().max().unwrap_or(0) + allowance;
    let mut latest_finish = vec![horizon; count];
    for declaration in program.declarations.iter().rev() {
        let id = declaration.id.0;
        let latest_start = latest_finish[id].saturating_sub(declaration.line_count());
        for dependency in &declaration.direct_dependencies {
            latest_finish[dependency.0] = latest_finish[dependency.0].min(latest_start);
        }
    }
    latest_finish
}

/// Module-aware packing that keeps the shard graph's critical path within the declaration critical
/// path plus an allowance. Packing a module's declarations in source order welded its dependency chains
/// into consecutive shards (the hopac core's shard critical path was 126k lines against a 35k-line
/// declaration floor). Here declarations are placed in source order and a group is simulated as one
/// compile unit (it starts when its dependency groups finish and takes its total lines); a declaration
/// joins its module's open group only while that group still finishes within every member's latest
/// finish, and only while no other group depends on it yet (so growing it cannot delay placed work).
/// By induction every declaration then finishes within its latest finish, so the shard critical path
/// stays within the floor plus the allowance, which buys fewer, larger projects.
fn critical_path_module_groups(program: &Program<Linked>, max_lines: usize) -> Vec<Vec<DeclarationId>> {
    struct OpenGroup {
        members: Vec<DeclarationId>,
        lines: usize,
        start: usize,
        finish_cap: usize,
        has_dependents: bool,
    }
    let allowance = max_lines.saturating_mul(4);
    let latest_finish = declaration_latest_finish(program, allowance);
    let mut groups: Vec<OpenGroup> = Vec::new();
    let mut group_of = vec![usize::MAX; program.declarations.len()];
    let mut open_by_module = BTreeMap::<String, usize>::new();
    for declaration in &program.declarations {
        let id = declaration.id.0;
        let lines = declaration.line_count();
        let module = declaration.scope.module_name().map(str::to_owned);
        let candidate = module.as_ref().and_then(|name| open_by_module.get(name).copied());
        let ready_excluding = |excluded: Option<usize>| {
            declaration
                .direct_dependencies
                .iter()
                .map(|dependency| group_of[dependency.0])
                .filter(|group| *group != usize::MAX && Some(*group) != excluded)
                .map(|group| groups[group].start + groups[group].lines)
                .max()
                .unwrap_or(0)
        };
        let joined = candidate.filter(|&group| {
            let open = &groups[group];
            let start = open.start.max(ready_excluding(Some(group)));
            let finish = start + open.lines + lines;
            !open.has_dependents
                && open.lines + lines <= max_lines
                && finish <= open.finish_cap.min(latest_finish[id])
        });
        let target = if let Some(group) = joined {
            let start = groups[group].start.max(ready_excluding(Some(group)));
            let open = &mut groups[group];
            open.start = start;
            open.lines += lines;
            open.finish_cap = open.finish_cap.min(latest_finish[id]);
            open.members.push(declaration.id);
            group
        } else {
            groups.push(OpenGroup {
                members: vec![declaration.id],
                lines,
                start: ready_excluding(None),
                finish_cap: latest_finish[id],
                has_dependents: false,
            });
            groups.len() - 1
        };
        if let Some(name) = module {
            open_by_module.insert(name, target);
        }
        group_of[id] = target;
        for dependency in &declaration.direct_dependencies {
            let provider = group_of[dependency.0];
            if provider != usize::MAX && provider != target {
                groups[provider].has_dependents = true;
            }
        }
    }
    // A group never grows once another group depends on it, so the groups are acyclic by construction;
    // condensing strongly connected groups is a cheap guard that keeps the shard graph a DAG regardless
    // (a single-project build needs a file order, and gears need acyclic references).
    condense_group_cycles(program, &group_of)
}

/// Groups declarations by `representative` and merges every strongly connected set of groups (by
/// direct declaration dependencies), returning groups ordered by their first declaration.
fn condense_group_cycles(program: &Program<Linked>, representative: &[usize]) -> Vec<Vec<DeclarationId>> {
    let mut index = BTreeMap::<usize, usize>::new();
    for group in representative {
        let next = index.len();
        index.entry(*group).or_insert(next);
    }
    let count = index.len();
    let node_of = |declaration: usize| index[&representative[declaration]];
    let mut forward = vec![BTreeSet::<usize>::new(); count];
    let mut backward = vec![BTreeSet::<usize>::new(); count];
    for declaration in &program.declarations {
        let consumer = node_of(declaration.id.0);
        for dependency in &declaration.direct_dependencies {
            let provider = node_of(dependency.0);
            if provider != consumer {
                forward[provider].insert(consumer);
                backward[consumer].insert(provider);
            }
        }
    }
    // Kosaraju, iterative.
    let mut visited = vec![false; count];
    let mut order = Vec::with_capacity(count);
    for root in 0..count {
        if visited[root] {
            continue;
        }
        visited[root] = true;
        let mut stack = vec![(root, forward[root].iter().copied().collect::<Vec<_>>(), 0usize)];
        while let Some((node, edges, next)) = stack.last_mut() {
            if *next < edges.len() {
                let target = edges[*next];
                *next += 1;
                if !visited[target] {
                    visited[target] = true;
                    let target_edges = forward[target].iter().copied().collect::<Vec<_>>();
                    stack.push((target, target_edges, 0));
                }
            } else {
                order.push(*node);
                stack.pop();
            }
        }
    }
    let mut component = vec![usize::MAX; count];
    let mut components = 0usize;
    for &root in order.iter().rev() {
        if component[root] != usize::MAX {
            continue;
        }
        let mut stack = vec![root];
        component[root] = components;
        while let Some(node) = stack.pop() {
            for &provider in &backward[node] {
                if component[provider] == usize::MAX {
                    component[provider] = components;
                    stack.push(provider);
                }
            }
        }
        components += 1;
    }
    let mut merged = vec![Vec::<DeclarationId>::new(); components];
    for declaration in &program.declarations {
        merged[component[node_of(declaration.id.0)]].push(declaration.id);
    }
    let mut merged = merged.into_iter().filter(|group| !group.is_empty()).collect::<Vec<_>>();
    merged.sort_by_key(|group| group.first().map_or(usize::MAX, |id| id.0));
    merged
}

fn declaration_groups(
    program: &Program<Linked>,
    policy: SplitPolicy,
    layers: &[usize],
) -> Vec<Vec<DeclarationId>> {
    match policy {
        SplitPolicy::Declaration => program
            .declarations
            .iter()
            .map(|declaration| vec![declaration.id])
            .collect(),
        SplitPolicy::BoundedLines { max_lines } => {
            let mut groups = Vec::<Vec<DeclarationId>>::new();
            let mut current = Vec::<DeclarationId>::new();
            let mut current_lines = 0usize;
            for declaration in &program.declarations {
                let lines = declaration.line_count();
                if !current.is_empty() && current_lines + lines > max_lines {
                    groups.push(std::mem::take(&mut current));
                    current_lines = 0;
                }
                current.push(declaration.id);
                current_lines += lines;
            }
            if !current.is_empty() {
                groups.push(current);
            }
            groups
        }
        SplitPolicy::DependencyLayer { max_lines } => {
            let mut by_layer = BTreeMap::<usize, Vec<DeclarationId>>::new();
            for declaration in &program.declarations {
                by_layer
                    .entry(layers[declaration.id.0])
                    .or_default()
                    .push(declaration.id);
            }
            let mut groups = Vec::new();
            for declarations in by_layer.into_values() {
                let mut current = Vec::<DeclarationId>::new();
                let mut current_lines = 0usize;
                for id in declarations {
                    let lines = program.declarations[id.0].line_count();
                    if !current.is_empty() && current_lines + lines > max_lines {
                        groups.push(std::mem::take(&mut current));
                        current_lines = 0;
                    }
                    current.push(id);
                    current_lines += lines;
                }
                if !current.is_empty() {
                    groups.push(current);
                }
            }
            groups
        }
        SplitPolicy::ModuleAware { max_lines } => critical_path_module_groups(program, max_lines),
    }
}

fn ordered_opens(program: &Program<Linked>, declarations: &[DeclarationId]) -> Vec<String> {
    let mut result = Vec::new();
    for declaration in declarations {
        for open_line in &program.declarations[declaration.0].ambient_opens {
            if let Some(index) = result.iter().position(|existing| existing == open_line) {
                result.remove(index);
            }
            result.push(open_line.clone());
        }
    }
    result
}

fn shard_fingerprint(program: &Program<Linked>, declarations: &[DeclarationId]) -> u64 {
    let mut bytes = Vec::with_capacity(declarations.len() * 8);
    for declaration in declarations {
        bytes.extend_from_slice(
            &program.declarations[declaration.0]
                .fingerprint
                .to_le_bytes(),
        );
    }
    fnv1a64(&bytes)
}

pub fn plan_splits(
    program: Program<Linked>,
    policy: SplitPolicy,
    reference_mode: ReferenceMode,
) -> SplitPlan {
    let layers = declaration_layers(&program);
    let groups = declaration_groups(&program, policy, &layers);
    let mut declaration_to_shard = vec![0usize; program.declarations.len()];
    for (shard, declarations) in groups.iter().enumerate() {
        for declaration in declarations {
            declaration_to_shard[declaration.0] = shard;
        }
    }

    let max_lines = policy.max_lines();
    let shards = groups
        .iter()
        .enumerate()
        .map(|(id, declarations)| {
            let mut direct_dependencies = BTreeSet::new();
            let mut compile_dependencies = BTreeSet::new();
            let mut line_count = 0usize;
            let mut bytes = 0usize;
            let mut layer = 1usize;
            for declaration_id in declarations {
                let declaration = &program.declarations[declaration_id.0];
                line_count += declaration.line_count();
                bytes += declaration.text.len();
                layer = layer.max(layers[declaration_id.0]);
                for dependency in &declaration.direct_dependencies {
                    let dependency_shard = declaration_to_shard[dependency.0];
                    if dependency_shard != id {
                        direct_dependencies.insert(dependency_shard);
                    }
                }
                let selected = match reference_mode {
                    ReferenceMode::Direct => &declaration.direct_dependencies,
                    ReferenceMode::Closure => &declaration.closure_dependencies,
                };
                for dependency in selected {
                    let dependency_shard = declaration_to_shard[dependency.0];
                    if dependency_shard != id {
                        compile_dependencies.insert(dependency_shard);
                    }
                }
            }
            Shard {
                id,
                declarations: declarations.clone(),
                direct_dependencies,
                compile_dependencies,
                ambient_opens: ordered_opens(&program, declarations),
                line_count,
                bytes,
                layer,
                oversize: line_count > max_lines,
                fingerprint: shard_fingerprint(&program, declarations),
            }
        })
        .collect();

    SplitPlan {
        source: program.source,
        policy,
        reference_mode,
        declarations: program.declarations,
        shards,
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{
        BoundaryReason, CompilerProfile, Declaration, DeclarationKind, DeclarationScope, LineSpan,
        SourceText,
    };
    use std::path::PathBuf;

    fn linked(id: usize, dependency: Option<usize>) -> spiral_split_model::Declaration<Linked> {
        let mut declaration = Declaration::<spiral_split_model::Raw>::new(
            DeclarationId(id),
            LineSpan {
                start: id + 1,
                end: id + 2,
            },
            String::new(),
            format!("    let value{id} = {id}\n"),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            id as u64,
        )
        .restage::<Linked>();
        if let Some(dependency) = dependency {
            declaration
                .direct_dependencies
                .insert(DeclarationId(dependency));
            declaration
                .closure_dependencies
                .insert(DeclarationId(dependency));
        }
        declaration
    }

    fn program() -> Program<Linked> {
        Program::new(
            SourceText {
                path: PathBuf::from("test.fs"),
                lines: vec![String::new(); 3],
                module_line: 0,
                module_name: "spiral_compiler".to_owned(),
                profile: CompilerProfile::PreHopac,
                fingerprint: 1,
                bytes: 1,
            },
            vec![linked(0, None), linked(1, Some(0)), linked(2, None)],
        )
    }

    #[test]
    fn declaration_policy_is_maximally_granular() {
        let plan = plan_splits(program(), SplitPolicy::Declaration, ReferenceMode::Direct);
        assert_eq!(plan.shards.len(), 3);
        assert_eq!(plan.shards[1].direct_dependencies, BTreeSet::from([0]));
    }

    #[test]
    fn layered_policy_exposes_parallel_width() {
        let plan = plan_splits(
            program(),
            SplitPolicy::DependencyLayer { max_lines: 100 },
            ReferenceMode::Direct,
        );
        assert_eq!(plan.shards.len(), 2);
    }

    #[test]
    fn module_aware_policy_groups_only_within_the_same_module() {
        let mut source = program();
        source.declarations[0].scope = DeclarationScope::ModuleFragment {
            module_name: "BigStack".to_owned(),
            ordinal: 0,
            prefix_lines: 1,
            dedent_spaces: 4,
        };
        source.declarations[1].scope = DeclarationScope::ModuleFragment {
            module_name: "BigStack".to_owned(),
            ordinal: 1,
            prefix_lines: 1,
            dedent_spaces: 4,
        };
        source.declarations[2].scope = DeclarationScope::ModuleFragment {
            module_name: "Other".to_owned(),
            ordinal: 0,
            prefix_lines: 1,
            dedent_spaces: 4,
        };
        let plan = plan_splits(
            source,
            SplitPolicy::ModuleAware { max_lines: 100 },
            ReferenceMode::Direct,
        );
        assert_eq!(plan.shards.len(), 2);
        assert_eq!(plan.shards[0].declarations.len(), 2);
        assert_eq!(plan.shards[1].declarations.len(), 1);
    }

    #[test]
    fn grouped_declarations_keep_last_open_precedence() {
        let mut source = program();
        source.declarations[0].ambient_opens = vec![
            "    open Hopac.Infixes".to_owned(),
            "    open FParsec".to_owned(),
        ];
        source.declarations[1].ambient_opens = vec![
            "    open FParsec".to_owned(),
            "    open Hopac.Infixes".to_owned(),
        ];
        for (ordinal, declaration) in source.declarations[..2].iter_mut().enumerate() {
            declaration.scope = DeclarationScope::ModuleFragment {
                module_name: "Supervisor".to_owned(),
                ordinal,
                prefix_lines: 0,
                dedent_spaces: 4,
            };
        }
        let plan = plan_splits(
            source,
            SplitPolicy::ModuleAware { max_lines: 100 },
            ReferenceMode::Direct,
        );
        assert_eq!(
            plan.shards[0].ambient_opens,
            vec!["    open FParsec", "    open Hopac.Infixes"]
        );
    }
}
