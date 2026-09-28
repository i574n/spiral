use spiral_split_gear_bridge::BridgeReport;
use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct IdentityFusion {
    pub groups: Vec<(usize, Vec<usize>)>,
    pub anonymous_shards: usize,
    pub affinity_unions: usize,
    pub mutable_address_unions: usize,
    pub cycle_collapses: usize,
    pub cycle_groups: usize,
    pub largest_cycle_groups: usize,
    pub initial_groups: usize,
}

#[derive(Clone, Debug)]
struct DisjointSet {
    parent: Vec<usize>,
    size: Vec<usize>,
}

impl DisjointSet {
    fn new(count: usize) -> Self {
        Self {
            parent: (0..count).collect(),
            size: vec![1; count],
        }
    }

    fn find(&mut self, value: usize) -> usize {
        let parent = self.parent[value];
        if parent != value {
            self.parent[value] = self.find(parent);
        }
        self.parent[value]
    }

    fn union(&mut self, left: usize, right: usize) -> bool {
        let mut left = self.find(left);
        let mut right = self.find(right);
        if left == right {
            return false;
        }
        if self.size[left] < self.size[right] {
            std::mem::swap(&mut left, &mut right);
        }
        self.parent[right] = left;
        self.size[left] += self.size[right];
        true
    }
}

fn anonymous_record_ranges(text: &str) -> Vec<(usize, &str)> {
    let bytes = text.as_bytes();
    let mut stack = Vec::new();
    let mut result = Vec::new();
    let mut index = 0usize;
    while index + 1 < bytes.len() {
        if bytes[index] == b'{' && bytes[index + 1] == b'|' {
            stack.push(index + 2);
            index += 2;
            continue;
        }
        if bytes[index] == b'|' && bytes[index + 1] == b'}' {
            if let Some(start) = stack.pop() {
                result.push((start, &text[start..index]));
            }
            index += 2;
            continue;
        }
        index += 1;
    }
    result
}

fn anonymous_record_contents(text: &str) -> Vec<&str> {
    anonymous_record_ranges(text)
        .into_iter()
        .map(|(_, content)| content)
        .collect()
}

fn field_label(segment: &str) -> Option<String> {
    let segment = segment.trim();
    if segment.is_empty() || segment.contains(" with ") {
        return None;
    }
    let delimiter = segment
        .char_indices()
        .find_map(|(index, character)| matches!(character, ':' | '=').then_some(index));
    let label = delimiter.map_or(segment, |index| &segment[..index]).trim();
    let mut characters = label.chars();
    let first = characters.next()?;
    if !(first == '_' || first.is_ascii_alphabetic())
        || !characters.all(|character| {
            character == '_' || character == '\'' || character.is_ascii_alphanumeric()
        })
    {
        return None;
    }
    Some(label.to_owned())
}

fn anonymous_record_shape(content: &str) -> Option<String> {
    let mut fields = BTreeSet::new();
    let mut start = 0usize;
    let mut depth = 0usize;
    for (index, character) in content.char_indices() {
        match character {
            '(' | '[' | '{' => depth += 1,
            ')' | ']' | '}' => depth = depth.saturating_sub(1),
            ';' | '\n' if depth == 0 => {
                if let Some(label) = field_label(&content[start..index]) {
                    fields.insert(label);
                }
                start = index + character.len_utf8();
            }
            _ => {}
        }
    }
    if let Some(label) = field_label(&content[start..]) {
        fields.insert(label);
    }
    (!fields.is_empty()).then(|| fields.into_iter().collect::<Vec<_>>().join(","))
}

fn declaration_shapes(text: &str) -> BTreeSet<String> {
    anonymous_record_contents(text)
        .into_iter()
        .filter_map(anonymous_record_shape)
        .collect()
}

fn declaration_defines_alias(text: &str) -> bool {
    let text = text.trim_start();
    text.starts_with("type ") || text.starts_with("and ")
}

#[allow(dead_code)]
fn alias_name_from_line(line: &str) -> Option<String> {
    let line = line.trim_start();
    let rest = line
        .strip_prefix("type ")
        .or_else(|| line.strip_prefix("and "))?;
    let name = rest
        .chars()
        .take_while(|character| {
            *character == '_' || *character == '\'' || character.is_ascii_alphanumeric()
        })
        .collect::<String>();
    (!name.is_empty()).then_some(name)
}

#[allow(dead_code)]
fn alias_name_before(text: &str, position: usize) -> Option<String> {
    text[..position]
        .lines()
        .rev()
        .find_map(alias_name_from_line)
}

#[allow(dead_code)]
fn aliases_by_shape(text: &str) -> BTreeMap<String, BTreeSet<String>> {
    let mut result = BTreeMap::<String, BTreeSet<String>>::new();
    for (position, content) in anonymous_record_ranges(text) {
        let Some(shape) = anonymous_record_shape(content) else {
            continue;
        };
        let Some(name) = alias_name_before(text, position) else {
            continue;
        };
        result.entry(shape).or_default().insert(name);
    }
    result
}

#[allow(dead_code)]
fn text_mentions_identifier(text: &str, identifier: &str) -> bool {
    text.match_indices(identifier).any(|(index, _)| {
        let before = text[..index].chars().next_back();
        let after = text[index + identifier.len()..].chars().next();
        let boundary = |character: Option<char>| {
            character.is_none_or(|character| {
                !(character == '_' || character == '\'' || character.is_ascii_alphanumeric())
            })
        };
        boundary(before) && boundary(after)
    })
}

fn binding_identifier(value: &str) -> Option<String> {
    let identifier = value
        .trim_start()
        .chars()
        .take_while(|character| {
            *character == '_' || *character == '\'' || character.is_ascii_alphanumeric()
        })
        .collect::<String>();
    (!identifier.is_empty()).then_some(identifier)
}

fn top_level_mutable_name(text: &str) -> Option<String> {
    const PREFIXES: [&str; 6] = [
        "let mutable private ",
        "let mutable internal ",
        "let private mutable ",
        "let internal mutable ",
        "let mutable ",
        "let rec mutable ",
    ];
    for line in text.lines().map(str::trim_start) {
        if line.is_empty() || line.starts_with("//") || line.starts_with("[<") {
            continue;
        }
        return PREFIXES
            .iter()
            .find_map(|prefix| line.strip_prefix(prefix).and_then(binding_identifier));
    }
    None
}

fn addressed_identifiers(text: &str) -> BTreeSet<String> {
    let bytes = text.as_bytes();
    let mut result = BTreeSet::new();
    let mut index = 0usize;
    while index + 1 < bytes.len() {
        if bytes[index] == b'&'
            && bytes[index + 1] != b'&'
            && (bytes[index + 1] == b'_' || bytes[index + 1].is_ascii_alphabetic())
        {
            let start = index + 1;
            let mut end = start + 1;
            while end < bytes.len()
                && (bytes[end] == b'_' || bytes[end] == b'\'' || bytes[end].is_ascii_alphanumeric())
            {
                end += 1;
            }
            result.insert(text[start..end].to_owned());
            index = end;
        } else {
            index += 1;
        }
    }
    result
}

fn shard_mutable_names(plan: &SplitPlan, shard: usize) -> BTreeSet<String> {
    plan.shards[shard]
        .declarations
        .iter()
        .filter_map(|declaration| plan.declarations.get(declaration.0))
        .filter_map(|declaration| top_level_mutable_name(&declaration.text))
        .collect()
}

fn shard_addressed_names(plan: &SplitPlan, shard: usize) -> BTreeSet<String> {
    plan.shards[shard]
        .declarations
        .iter()
        .filter_map(|declaration| plan.declarations.get(declaration.0))
        .flat_map(|declaration| addressed_identifiers(&declaration.text))
        .collect()
}

fn shard_alias_shapes(plan: &SplitPlan, shard: usize) -> BTreeSet<String> {
    plan.shards[shard]
        .declarations
        .iter()
        .filter_map(|declaration| plan.declarations.get(declaration.0))
        .filter(|declaration| declaration_defines_alias(&declaration.text))
        .flat_map(|declaration| declaration_shapes(&declaration.text))
        .collect()
}

fn shard_union_case_shapes(plan: &SplitPlan, shard: usize) -> BTreeSet<String> {
    plan.shards[shard]
        .declarations
        .iter()
        .filter_map(|declaration| plan.declarations.get(declaration.0))
        .filter(|declaration| {
            declaration.text.lines().any(|line| {
                let line = line.trim_start();
                line.starts_with('|') && line.contains("{|")
            })
        })
        .flat_map(|declaration| declaration_shapes(&declaration.text))
        .collect()
}

#[allow(dead_code)]
fn shard_aliases_by_shape(plan: &SplitPlan, shard: usize) -> BTreeMap<String, BTreeSet<String>> {
    let mut result = BTreeMap::<String, BTreeSet<String>>::new();
    for declaration in plan.shards[shard]
        .declarations
        .iter()
        .filter_map(|declaration| plan.declarations.get(declaration.0))
        .filter(|declaration| declaration_defines_alias(&declaration.text))
    {
        for (shape, names) in aliases_by_shape(&declaration.text) {
            result.entry(shape).or_default().extend(names);
        }
    }
    result
}

fn shard_literal_shapes(plan: &SplitPlan, shard: usize) -> BTreeSet<String> {
    plan.shards[shard]
        .declarations
        .iter()
        .filter_map(|declaration| plan.declarations.get(declaration.0))
        .filter(|declaration| !declaration_defines_alias(&declaration.text))
        .flat_map(|declaration| declaration_shapes(&declaration.text))
        .collect()
}

fn bridgeable_affinity_shapes(report: &BridgeReport) -> BTreeSet<(usize, usize, String)> {
    report
        .annotations
        .iter()
        .map(|annotation| {
            (
                annotation.consumer_shard,
                annotation.provider_shard,
                annotation
                    .fields
                    .iter()
                    .cloned()
                    .collect::<Vec<_>>()
                    .join(","),
            )
        })
        .collect()
}

fn collapse_groups(
    plan: &SplitPlan,
    groups: &[(usize, Vec<usize>)],
    dsu: &mut DisjointSet,
) -> Vec<(usize, Vec<usize>)> {
    let mut collapsed = BTreeMap::<usize, (usize, BTreeSet<usize>)>::new();
    for (group, (layer, shards)) in groups.iter().enumerate() {
        let root = dsu.find(group);
        let entry = collapsed.entry(root).or_insert((0, BTreeSet::new()));
        entry.0 = entry.0.max(*layer);
        entry.1.extend(shards.iter().copied());
    }
    collapsed
        .into_values()
        .map(|(layer, shards)| {
            let layer = shards
                .iter()
                .map(|shard| plan.shards[*shard].layer)
                .max()
                .unwrap_or(layer);
            (layer, shards.into_iter().collect())
        })
        .collect()
}

fn component_graph(
    plan: &SplitPlan,
    groups: &[(usize, Vec<usize>)],
) -> (Vec<BTreeSet<usize>>, Vec<usize>) {
    let mut shard_to_group = vec![usize::MAX; plan.shards.len()];
    for (group, (_, shards)) in groups.iter().enumerate() {
        for shard in shards {
            shard_to_group[*shard] = group;
        }
    }
    let mut graph = vec![BTreeSet::new(); groups.len()];
    for (consumer_group, (_, shards)) in groups.iter().enumerate() {
        for dependency in shards
            .iter()
            .flat_map(|shard| plan.shards[*shard].compile_dependencies.iter())
        {
            let provider_group = shard_to_group[*dependency];
            if provider_group != consumer_group {
                graph[consumer_group].insert(provider_group);
            }
        }
    }
    (graph, shard_to_group)
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

fn strongly_connected_components(graph: &[BTreeSet<usize>]) -> Vec<Vec<usize>> {
    let mut visited = vec![false; graph.len()];
    let mut order = Vec::with_capacity(graph.len());
    for node in 0..graph.len() {
        visit_forward(node, graph, &mut visited, &mut order);
    }
    let mut reverse = vec![BTreeSet::new(); graph.len()];
    for (node, dependencies) in graph.iter().enumerate() {
        for dependency in dependencies {
            reverse[*dependency].insert(node);
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

fn topological_order(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
) -> Result<Vec<(usize, Vec<usize>)>, String> {
    let (dependencies, _) = component_graph(plan, &groups);
    let mut consumers = vec![BTreeSet::new(); groups.len()];
    let mut indegree = vec![0usize; groups.len()];
    for (consumer, providers) in dependencies.iter().enumerate() {
        indegree[consumer] = providers.len();
        for provider in providers {
            consumers[*provider].insert(consumer);
        }
    }
    let mut ready = indegree
        .iter()
        .enumerate()
        .filter_map(|(group, degree)| (*degree == 0).then_some(group))
        .collect::<BTreeSet<_>>();
    let mut order = Vec::with_capacity(groups.len());
    while let Some(group) = ready.pop_first() {
        order.push(group);
        for consumer in &consumers[group] {
            indegree[*consumer] -= 1;
            if indegree[*consumer] == 0 {
                ready.insert(*consumer);
            }
        }
    }
    if order.len() != groups.len() {
        return Err("identity-fused gear graph remains cyclic".to_owned());
    }
    Ok(order
        .into_iter()
        .map(|group| groups[group].clone())
        .collect())
}

fn recompute_group_layers(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
) -> Result<Vec<(usize, Vec<usize>)>, String> {
    let mut shard_to_group = vec![usize::MAX; plan.shards.len()];
    for (group, (_, shards)) in groups.iter().enumerate() {
        for shard in shards {
            shard_to_group[*shard] = group;
        }
    }
    if shard_to_group.contains(&usize::MAX) {
        return Err("layer recomputation received an incomplete shard partition".to_owned());
    }
    let mut layers = vec![0usize; groups.len()];
    let mut result = Vec::with_capacity(groups.len());
    for (group, (_, shards)) in groups.into_iter().enumerate() {
        let mut layer = 0usize;
        for dependency in shards
            .iter()
            .flat_map(|shard| plan.shards[*shard].compile_dependencies.iter())
        {
            let provider = shard_to_group[*dependency];
            if provider == group {
                continue;
            }
            if provider >= group {
                return Err("group layer recomputation received a non-topological order".to_owned());
            }
            layer = layer.max(layers[provider] + 1);
        }
        layers[group] = layer;
        result.push((layer, shards));
    }
    Ok(result)
}

fn fuse_identity_groups_with_bridges(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
    bridge_report: &BridgeReport,
) -> Result<IdentityFusion, String> {
    let initial_groups = groups.len();
    let mut shard_to_group = vec![usize::MAX; plan.shards.len()];
    for (group, (_, shards)) in groups.iter().enumerate() {
        for shard in shards {
            shard_to_group[*shard] = group;
        }
    }
    if shard_to_group.contains(&usize::MAX) {
        return Err("identity fusion received an incomplete shard partition".to_owned());
    }
    let alias_shapes = (0..plan.shards.len())
        .map(|shard| shard_alias_shapes(plan, shard))
        .collect::<Vec<_>>();
    let union_case_shapes = (0..plan.shards.len())
        .map(|shard| shard_union_case_shapes(plan, shard))
        .collect::<Vec<_>>();
    let literal_shapes = (0..plan.shards.len())
        .map(|shard| shard_literal_shapes(plan, shard))
        .collect::<Vec<_>>();
    let mutable_names = (0..plan.shards.len())
        .map(|shard| shard_mutable_names(plan, shard))
        .collect::<Vec<_>>();
    let addressed_names = (0..plan.shards.len())
        .map(|shard| shard_addressed_names(plan, shard))
        .collect::<Vec<_>>();
    let bridgeable = bridgeable_affinity_shapes(bridge_report);
    let mut dsu = DisjointSet::new(groups.len());
    let mut affinity_unions = 0usize;
    for consumer in 0..plan.shards.len() {
        let providers = plan.shards[consumer]
            .direct_dependencies
            .iter()
            .copied()
            .filter(|provider| !union_case_shapes[*provider].is_empty())
            .collect::<Vec<_>>();
        for (offset, left) in providers.iter().enumerate() {
            for right in providers.iter().skip(offset + 1) {
                if !union_case_shapes[*left].is_disjoint(&union_case_shapes[*right]) {
                    affinity_unions +=
                        usize::from(dsu.union(shard_to_group[*left], shard_to_group[*right]));
                }
            }
        }
    }
    for shard in 0..plan.shards.len() {
        if literal_shapes[shard].is_empty() {
            continue;
        }
        let group = shard_to_group[shard];
        for provider in &plan.shards[shard].direct_dependencies {
            let shared = alias_shapes[*provider]
                .intersection(&literal_shapes[shard])
                .collect::<Vec<_>>();
            if shared.is_empty() {
                continue;
            }
            let fully_bridgeable = shared
                .iter()
                .all(|shape| bridgeable.contains(&(shard, *provider, (*shape).clone())));
            if !fully_bridgeable {
                affinity_unions += usize::from(dsu.union(group, shard_to_group[*provider]));
            }
        }
    }
    let mut mutable_address_unions = 0usize;
    for shard in 0..plan.shards.len() {
        if addressed_names[shard].is_empty() {
            continue;
        }
        let group = shard_to_group[shard];
        for provider in &plan.shards[shard].direct_dependencies {
            if !mutable_names[*provider].is_disjoint(&addressed_names[shard]) {
                mutable_address_unions += usize::from(dsu.union(group, shard_to_group[*provider]));
            }
        }
    }
    let mut collapsed = collapse_groups(plan, &groups, &mut dsu);
    let (graph, _) = component_graph(plan, &collapsed);
    let components = strongly_connected_components(&graph);
    let cycle_groups = components
        .iter()
        .filter(|component| component.len() > 1)
        .map(Vec::len)
        .sum();
    let largest_cycle_groups = components
        .iter()
        .filter(|component| component.len() > 1)
        .map(Vec::len)
        .max()
        .unwrap_or(0);
    let mut cycle_collapses = 0usize;
    if components.iter().any(|component| component.len() > 1) {
        let mut cycle_dsu = DisjointSet::new(collapsed.len());
        for component in components.iter().filter(|component| component.len() > 1) {
            cycle_collapses += 1;
            for group in component.iter().skip(1) {
                cycle_dsu.union(component[0], *group);
            }
        }
        collapsed = collapse_groups(plan, &collapsed, &mut cycle_dsu);
    }
    let groups = recompute_group_layers(plan, topological_order(plan, collapsed)?)?;
    Ok(IdentityFusion {
        groups,
        anonymous_shards: alias_shapes
            .iter()
            .zip(&literal_shapes)
            .filter(|(aliases, literals)| !aliases.is_empty() || !literals.is_empty())
            .count(),
        affinity_unions,
        mutable_address_unions,
        cycle_collapses,
        cycle_groups,
        largest_cycle_groups,
        initial_groups,
    })
}

pub fn fuse_identity_groups(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
) -> Result<IdentityFusion, String> {
    fuse_identity_groups_with_bridges(plan, groups, &BridgeReport::default())
}

pub fn fuse_identity_groups_with_bridge_report(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
    bridge_report: &BridgeReport,
) -> Result<IdentityFusion, String> {
    fuse_identity_groups_with_bridges(plan, groups, bridge_report)
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MutableAddressFusion {
    pub groups: Vec<(usize, Vec<usize>)>,
    pub unions: usize,
    pub cycle_collapses: usize,
    pub cycle_groups: usize,
    pub largest_cycle_groups: usize,
    pub initial_groups: usize,
}

pub fn fuse_mutable_address_groups(
    plan: &SplitPlan,
    groups: Vec<(usize, Vec<usize>)>,
) -> Result<MutableAddressFusion, String> {
    let initial_groups = groups.len();
    let mut shard_to_group = vec![usize::MAX; plan.shards.len()];
    for (group, (_, shards)) in groups.iter().enumerate() {
        for shard in shards {
            shard_to_group[*shard] = group;
        }
    }
    if shard_to_group.contains(&usize::MAX) {
        return Err("mutable-address fusion received an incomplete shard partition".to_owned());
    }
    let mutable_names = (0..plan.shards.len())
        .map(|shard| shard_mutable_names(plan, shard))
        .collect::<Vec<_>>();
    let addressed_names = (0..plan.shards.len())
        .map(|shard| shard_addressed_names(plan, shard))
        .collect::<Vec<_>>();
    let mut dsu = DisjointSet::new(groups.len());
    let mut unions = 0usize;
    for shard in 0..plan.shards.len() {
        if addressed_names[shard].is_empty() {
            continue;
        }
        let group = shard_to_group[shard];
        for provider in &plan.shards[shard].direct_dependencies {
            if !mutable_names[*provider].is_disjoint(&addressed_names[shard]) {
                unions += usize::from(dsu.union(group, shard_to_group[*provider]));
            }
        }
    }
    let mut collapsed = collapse_groups(plan, &groups, &mut dsu);
    let (graph, _) = component_graph(plan, &collapsed);
    let components = strongly_connected_components(&graph);
    let cycle_groups = components
        .iter()
        .filter(|component| component.len() > 1)
        .map(Vec::len)
        .sum();
    let largest_cycle_groups = components
        .iter()
        .filter(|component| component.len() > 1)
        .map(Vec::len)
        .max()
        .unwrap_or(0);
    let mut cycle_collapses = 0usize;
    if components.iter().any(|component| component.len() > 1) {
        let mut cycle_dsu = DisjointSet::new(collapsed.len());
        for component in components.iter().filter(|component| component.len() > 1) {
            cycle_collapses += 1;
            for group in component.iter().skip(1) {
                cycle_dsu.union(component[0], *group);
            }
        }
        collapsed = collapse_groups(plan, &collapsed, &mut cycle_dsu);
    }
    Ok(MutableAddressFusion {
        groups: recompute_group_layers(plan, topological_order(plan, collapsed)?)?,
        unions,
        cycle_collapses,
        cycle_groups,
        largest_cycle_groups,
        initial_groups,
    })
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_gear_bridge::BridgeAnnotation;
    use spiral_split_model::{
        BoundaryReason, CompilerProfile, Declaration, DeclarationId, DeclarationKind, LineSpan,
        Linked, ReferenceMode, Shard, SourceText, SplitPolicy,
    };
    use std::path::PathBuf;

    fn declaration(id: usize, text: &str, module: &str) -> Declaration<Linked> {
        Declaration::<Linked>::new(
            DeclarationId(id),
            LineSpan {
                start: id,
                end: id + 1,
            },
            String::new(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            id as u64,
        )
        .with_scope(spiral_split_model::DeclarationScope::ModuleFragment {
            module_name: module.to_owned(),
            ordinal: id,
            prefix_lines: 0,
            dedent_spaces: 0,
        })
        .restage()
    }

    fn shard(id: usize, layer: usize, dependencies: &[usize]) -> Shard {
        Shard {
            id,
            declarations: vec![DeclarationId(id)],
            direct_dependencies: dependencies.iter().copied().collect(),
            compile_dependencies: dependencies.iter().copied().collect(),
            ambient_opens: Vec::new(),
            line_count: 10,
            bytes: 100,
            layer,
            oversize: false,
            fingerprint: id as u64 + 1,
        }
    }

    #[test]
    fn co_consumed_union_payload_shapes_share_an_assembly() {
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "test".to_owned(),
                profile: CompilerProfile::PortableFork,
                fingerprint: 5,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: vec![
                declaration(0, "type ClientReq =\n    | Open of {| uri : string |}", "M"),
                declaration(
                    1,
                    "type SupervisorReq =\n    | Open of {| uri : string |}",
                    "M",
                ),
                declaration(
                    2,
                    "let forward = function | ClientReq.Open x -> SupervisorReq.Open x",
                    "M",
                ),
            ],
            shards: vec![shard(0, 0, &[]), shard(1, 0, &[]), shard(2, 1, &[0, 1])],
        };
        let fusion = fuse_identity_groups(&plan, vec![(0, vec![0]), (0, vec![1]), (1, vec![2])])
            .expect("fusion");
        assert_eq!(fusion.groups.len(), 2);
        assert!(
            fusion
                .groups
                .iter()
                .any(|(_, shards)| shards == &vec![0, 1])
        );
        assert_eq!(fusion.affinity_unions, 1);
    }

    #[test]
    fn anonymous_record_affinity_collapses_resulting_cycles() {
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "test".to_owned(),
                profile: CompilerProfile::PortableFork,
                fingerprint: 1,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: vec![
                declaration(0, "type A = {| value : int |}", "M"),
                declaration(1, "let bridge x = x", "N"),
                declaration(2, "let make () : A = {| value = 1 |}", "M"),
            ],
            shards: vec![shard(0, 0, &[]), shard(1, 1, &[0]), shard(2, 2, &[1, 0])],
        };
        let fusion = fuse_identity_groups(&plan, vec![(0, vec![0]), (1, vec![1]), (2, vec![2])])
            .expect("fusion");
        assert_eq!(fusion.groups.len(), 1);
        assert_eq!(fusion.groups[0].1, vec![0, 1, 2]);
        assert_eq!(fusion.initial_groups, 3);
        assert_eq!(fusion.affinity_unions, 1);
        assert_eq!(fusion.cycle_collapses, 1);
        assert_eq!(fusion.cycle_groups, 2);
        assert_eq!(fusion.largest_cycle_groups, 2);
    }

    #[test]
    fn proven_bridge_annotations_skip_only_the_matching_affinity_union() {
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "test".to_owned(),
                profile: CompilerProfile::PortableFork,
                fingerprint: 4,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: vec![
                declaration(0, "type A = {| value : int |}", "M"),
                declaration(1, "let bridge x = x", "N"),
                declaration(2, "let make () : A = {| value = 1 |}", "M"),
            ],
            shards: vec![shard(0, 0, &[]), shard(1, 1, &[0]), shard(2, 2, &[1, 0])],
        };
        let report = BridgeReport {
            annotations: vec![BridgeAnnotation {
                consumer_shard: 2,
                provider_shard: 0,
                alias: "A".to_owned(),
                fields: BTreeSet::from(["value".to_owned()]),
                line: 1,
            }],
            ..BridgeReport::default()
        };
        let fusion = fuse_identity_groups_with_bridge_report(
            &plan,
            vec![(0, vec![0]), (1, vec![1]), (2, vec![2])],
            &report,
        )
        .expect("bridged fusion");
        assert_eq!(fusion.groups.len(), 3);
        assert_eq!(fusion.affinity_unions, 0);
        assert_eq!(fusion.cycle_collapses, 0);
    }

    #[test]
    fn dependent_anonymous_record_aliases_require_bridge_reconstruction() {
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "test".to_owned(),
                profile: CompilerProfile::Hopac,
                fingerprint: 3,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: vec![
                declaration(
                    0,
                    "/// ### PartEvalMacro\ntype PartEvalMacro = Text of string\nand Ty = YVoid\nand Union = {|cases : Map<int * string, Ty>; layout : UnionLayout; tags : Dictionary<string,int>; tag_cases : (string * Ty) []; is_degenerate : bool|} H",
                    "M",
                ),
                declaration(
                    1,
                    "/// ### UnionView\ntype UnionView = {| cases : Map<int * string, Ty>; layout : UnionLayout; tags : Dictionary<string, int>; tag_cases : (string * Ty) []; is_degenerate : bool |}",
                    "M",
                ),
                declaration(
                    2,
                    "let inline union_view (h: Union) : UnionView = h.Item",
                    "M",
                ),
            ],
            shards: vec![shard(0, 0, &[]), shard(1, 1, &[0]), shard(2, 2, &[0, 1])],
        };
        let fusion = fuse_identity_groups(&plan, vec![(0, vec![0]), (1, vec![1]), (2, vec![2])])
            .expect("fusion");
        assert_eq!(fusion.groups.len(), 3);
        assert_eq!(fusion.affinity_unions, 0);
    }

    #[test]
    fn addressed_top_level_mutables_are_fused_with_their_consumers() {
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "test".to_owned(),
                profile: CompilerProfile::Hopac,
                fingerprint: 2,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: vec![
                declaration(0, "let mutable private cell = 0", "M"),
                declaration(
                    1,
                    "let read () = System.Threading.Volatile.Read(&cell)",
                    "M",
                ),
            ],
            shards: vec![shard(0, 0, &[]), shard(1, 1, &[0])],
        };
        let fusion =
            fuse_mutable_address_groups(&plan, vec![(0, vec![0]), (1, vec![1])]).expect("fusion");
        assert_eq!(fusion.groups.len(), 1);
        assert_eq!(fusion.groups[0].1, vec![0, 1]);
        assert_eq!(fusion.initial_groups, 2);
        assert_eq!(fusion.unions, 1);
        assert_eq!(fusion.cycle_collapses, 0);
        assert_eq!(fusion.cycle_groups, 0);
        assert_eq!(fusion.largest_cycle_groups, 0);
    }
}
