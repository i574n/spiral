use spiral_split_model::{DeclarationKind, SplitPlan};
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct UnionGroup {
    pub provider: usize,
    pub source_module: Option<String>,
    pub source_order: Option<usize>,
    pub type_name: String,
    pub cases: BTreeSet<String>,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct UnionContextIndex {
    pub groups: Vec<UnionGroup>,
    pub providers_by_case: BTreeMap<String, BTreeSet<usize>>,
    groups_by_case: BTreeMap<String, BTreeSet<usize>>,
    provider_dependencies: BTreeMap<usize, BTreeSet<usize>>,
    /// Case sets of unions nested inside whole-module declarations (not split into type groups). They
    /// are only evidence that a match is local to that shard, never an owner to qualify against,
    /// because a nested type is reached through its module path rather than the shard module.
    nested_local_cases: BTreeMap<usize, Vec<BTreeSet<String>>>,
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum BranchKind {
    Conditional,
    Match,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct CaseOccurrence {
    line: usize,
    start: usize,
    end: usize,
    name: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct BranchCluster {
    kind: BranchKind,
    occurrences: Vec<CaseOccurrence>,
}

fn leading_spaces(line: &str) -> usize {
    line.len() - line.trim_start().len()
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn identifier_prefix(text: &str) -> Option<&str> {
    let mut chars = text.char_indices();
    let (_, first) = chars.next()?;
    if !identifier_start(first) {
        return None;
    }
    let mut end = first.len_utf8();
    for (index, character) in chars {
        if !identifier_continue(character) {
            break;
        }
        end = index + character.len_utf8();
    }
    Some(&text[..end])
}

fn uppercase_identifier_prefix(text: &str) -> Option<&str> {
    let identifier = identifier_prefix(text)?;
    identifier
        .chars()
        .next()
        .is_some_and(char::is_uppercase)
        .then_some(identifier)
}

fn type_name_from_header(trimmed: &str) -> Option<String> {
    let tail = trimmed
        .strip_prefix("type ")
        .or_else(|| trimmed.strip_prefix("and "))?
        .trim_start();
    let name = identifier_prefix(tail)?;
    Some(name.to_owned())
}

fn first_case_after_bar(trimmed: &str) -> Option<String> {
    let tail = trimmed.strip_prefix('|')?.trim_start();
    uppercase_identifier_prefix(tail).map(str::to_owned)
}

fn inline_case_names(trimmed: &str) -> BTreeSet<String> {
    let mut result = BTreeSet::new();
    let Some((_, body)) = trimmed.split_once('=') else {
        return result;
    };
    if !body.contains('|') {
        return result;
    }
    for segment in body.split('|') {
        let segment = segment.trim_start();
        if let Some(name) = uppercase_identifier_prefix(segment) {
            result.insert(name.to_owned());
        }
    }
    result
}

fn parse_union_groups(
    text: &str,
    provider: usize,
    source_module: Option<&str>,
    source_order: Option<usize>,
) -> Vec<UnionGroup> {
    #[derive(Debug)]
    struct Pending {
        type_name: String,
        header_indent: usize,
        awaiting_body: bool,
        case_indent: Option<usize>,
        cases: BTreeSet<String>,
    }

    fn finish(
        result: &mut Vec<UnionGroup>,
        pending: Option<Pending>,
        provider: usize,
        source_module: Option<&str>,
        source_order: Option<usize>,
    ) {
        if let Some(pending) = pending
            && !pending.cases.is_empty()
        {
            result.push(UnionGroup {
                provider,
                source_module: source_module.map(str::to_owned),
                source_order,
                type_name: pending.type_name,
                cases: pending.cases,
            });
        }
    }

    let mut result = Vec::new();
    let mut pending: Option<Pending> = None;
    for line in text.lines() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") || trimmed.starts_with("[<") {
            continue;
        }
        let indent = leading_spaces(line);
        if let Some(type_name) = type_name_from_header(trimmed) {
            finish(
                &mut result,
                pending.take(),
                provider,
                source_module,
                source_order,
            );
            let cases = inline_case_names(trimmed);
            pending = Some(Pending {
                type_name,
                header_indent: indent,
                awaiting_body: cases.is_empty(),
                case_indent: None,
                cases,
            });
            continue;
        }

        let Some(current) = pending.as_mut() else {
            continue;
        };
        if indent <= current.header_indent {
            finish(
                &mut result,
                pending.take(),
                provider,
                source_module,
                source_order,
            );
            continue;
        }
        if current.awaiting_body {
            if trimmed == "private" {
                continue;
            }
            if let Some(case_name) = first_case_after_bar(trimmed) {
                current.case_indent = Some(indent);
                current.cases.insert(case_name);
            }
            current.awaiting_body = false;
            continue;
        }
        if current.case_indent == Some(indent)
            && let Some(case_name) = first_case_after_bar(trimmed)
        {
            current.cases.insert(case_name);
        }
    }
    finish(&mut result, pending, provider, source_module, source_order);
    result
}

impl UnionContextIndex {
    #[must_use]
    pub fn from_provider_sources<'a>(sources: impl IntoIterator<Item = (usize, &'a str)>) -> Self {
        Self::from_scoped_provider_sources(
            sources
                .into_iter()
                .map(|(provider, text)| (provider, None, text)),
        )
    }

    #[must_use]
    pub fn from_scoped_provider_sources<'a>(
        sources: impl IntoIterator<Item = (usize, Option<&'a str>, &'a str)>,
    ) -> Self {
        let mut groups = Vec::new();
        for (provider, source_module, text) in sources {
            groups.extend(parse_union_groups(text, provider, source_module, None));
        }
        Self::from_groups(groups)
    }

    #[must_use]
    pub fn from_ordered_scoped_provider_sources<'a>(
        sources: impl IntoIterator<Item = (usize, Option<&'a str>, usize, &'a str)>,
    ) -> Self {
        let mut groups = Vec::new();
        for (provider, source_module, source_order, text) in sources {
            groups.extend(parse_union_groups(
                text,
                provider,
                source_module,
                Some(source_order),
            ));
        }
        Self::from_groups(groups)
    }

    fn from_groups(groups: Vec<UnionGroup>) -> Self {
        let mut providers_by_case = BTreeMap::<String, BTreeSet<usize>>::new();
        let mut groups_by_case = BTreeMap::<String, BTreeSet<usize>>::new();
        for (group_index, group) in groups.iter().enumerate() {
            for case in &group.cases {
                providers_by_case
                    .entry(case.clone())
                    .or_default()
                    .insert(group.provider);
                groups_by_case
                    .entry(case.clone())
                    .or_default()
                    .insert(group_index);
            }
        }
        Self {
            groups,
            providers_by_case,
            groups_by_case,
            provider_dependencies: BTreeMap::new(),
            nested_local_cases: BTreeMap::new(),
        }
    }
}

#[must_use]
pub fn analyze_union_context(plan: &SplitPlan) -> UnionContextIndex {
    let mut declaration_shards = vec![0usize; plan.declarations.len()];
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            declaration_shards[declaration.0] = shard.id;
        }
    }
    let mut index = UnionContextIndex::from_ordered_scoped_provider_sources(
        plan.declarations.iter().filter_map(|declaration| {
            (declaration.boundary.kind() == DeclarationKind::TypeGroup).then_some((
                declaration_shards[declaration.id.0],
                declaration.scope.module_name(),
                declaration.id.0,
                declaration.text.as_str(),
            ))
        }),
    );
    for declaration in &plan.declarations {
        if declaration.boundary.kind() == DeclarationKind::TypeGroup {
            continue;
        }
        let provider = declaration_shards[declaration.id.0];
        for group in parse_union_groups(&declaration.text, provider, None, None) {
            index
                .nested_local_cases
                .entry(provider)
                .or_default()
                .push(group.cases);
        }
    }
    for shard in &plan.shards {
        index
            .provider_dependencies
            .insert(shard.id, shard.compile_dependencies.clone());
    }
    index
}

#[derive(Clone, Copy, Debug, Eq, PartialEq, Ord, PartialOrd)]
enum UnionOwner {
    Local,
    External(usize),
}

impl UnionOwner {
    fn from_provider(provider: usize, current_provider: usize) -> Self {
        if provider == current_provider {
            Self::Local
        } else {
            Self::External(provider)
        }
    }

    fn external_provider(self) -> Option<usize> {
        match self {
            Self::Local => None,
            Self::External(provider) => Some(provider),
        }
    }
}

fn canonical_duplicate_type_owners(
    index: &UnionContextIndex,
    current_provider: usize,
    compile_dependencies: &BTreeSet<usize>,
    source_module: Option<&str>,
) -> BTreeMap<String, UnionOwner> {
    let mut groups_by_name = BTreeMap::<String, Vec<&UnionGroup>>::new();
    for group in &index.groups {
        if group.provider == current_provider || compile_dependencies.contains(&group.provider) {
            groups_by_name
                .entry(group.type_name.clone())
                .or_default()
                .push(group);
        }
    }
    let mut result = BTreeMap::new();
    for (type_name, groups) in groups_by_name {
        if groups.len() < 2 {
            continue;
        }
        let cases = &groups[0].cases;
        if groups.iter().any(|group| group.cases != *cases) {
            continue;
        }
        let providers = groups
            .iter()
            .map(|group| group.provider)
            .collect::<BTreeSet<_>>();
        if providers.len() < 2 {
            continue;
        }
        if providers.contains(&current_provider) {
            result.insert(type_name, UnionOwner::Local);
            continue;
        }
        if let Some(source_module) = source_module {
            let lexical = groups
                .iter()
                .filter(|group| group.source_module.as_deref() == Some(source_module))
                .map(|group| group.provider)
                .collect::<BTreeSet<_>>();
            if let Some(provider) = lexical.iter().copied().next()
                && lexical.len() == 1
            {
                result.insert(
                    type_name,
                    UnionOwner::from_provider(provider, current_provider),
                );
                continue;
            }
        }
        let roots = providers
            .iter()
            .copied()
            .filter(|provider| {
                !index
                    .provider_dependencies
                    .get(provider)
                    .is_some_and(|dependencies| {
                        dependencies
                            .iter()
                            .any(|dependency| providers.contains(dependency))
                    })
            })
            .collect::<Vec<_>>();
        if let [root] = roots.as_slice() {
            result.insert(
                type_name,
                UnionOwner::from_provider(*root, current_provider),
            );
        }
    }
    result
}

#[must_use]
pub fn qualify_duplicate_union_type_annotations<F>(
    text: &str,
    index: &UnionContextIndex,
    current_provider: usize,
    compile_dependencies: &BTreeSet<usize>,
    module_name: F,
) -> String
where
    F: Fn(usize) -> String,
{
    qualify_duplicate_union_type_annotations_scoped(
        text,
        index,
        current_provider,
        compile_dependencies,
        None,
        module_name,
    )
}

#[must_use]
pub fn qualify_duplicate_union_type_annotations_scoped<F>(
    text: &str,
    index: &UnionContextIndex,
    current_provider: usize,
    compile_dependencies: &BTreeSet<usize>,
    source_module: Option<&str>,
    module_name: F,
) -> String
where
    F: Fn(usize) -> String,
{
    let owners = canonical_duplicate_type_owners(
        index,
        current_provider,
        compile_dependencies,
        source_module,
    );
    if owners.is_empty() {
        return text.to_owned();
    }
    let mut output = Vec::new();
    for line in text.lines() {
        let code_end = line.find("//").unwrap_or(line.len());
        let code = &line[..code_end];
        let mut replacements = Vec::<(usize, usize, String)>::new();
        for (colon, _) in code.match_indices(':') {
            let tail = &code[colon + 1..];
            let whitespace = tail.len() - tail.trim_start().len();
            let start = colon + 1 + whitespace;
            let Some(name) = identifier_prefix(&code[start..]) else {
                continue;
            };
            let Some(owner) = owners.get(name) else {
                continue;
            };
            let Some(provider) = owner.external_provider() else {
                continue;
            };
            replacements.push((
                start,
                start + name.len(),
                format!("{}.{}", module_name(provider), name),
            ));
        }
        let mut rewritten = line.to_owned();
        replacements.sort_by_key(|(start, _, _)| std::cmp::Reverse(*start));
        for (start, end, replacement) in replacements {
            rewritten.replace_range(start..end, &replacement);
        }
        output.push(rewritten);
    }
    let mut result = output.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        result.push('\n');
    }
    result
}

fn occurrence_after_marker(line: &str, marker: &str, line_index: usize) -> Option<CaseOccurrence> {
    let marker_start = line.find(marker)?;
    let tail_start = marker_start + marker.len();
    let tail = &line[tail_start..];
    let whitespace = tail.len() - tail.trim_start().len();
    let start = tail_start + whitespace;
    let name = uppercase_identifier_prefix(&line[start..])?;
    Some(CaseOccurrence {
        line: line_index,
        start,
        end: start + name.len(),
        name: name.to_owned(),
    })
}

fn conditional_occurrence(line: &str, line_index: usize) -> Option<CaseOccurrence> {
    let trimmed = line.trim_start();
    if trimmed.starts_with("if ") || trimmed.starts_with("elif ") {
        occurrence_after_marker(line, " then ", line_index)
    } else if trimmed.starts_with("else ") {
        occurrence_after_marker(line, "else ", line_index)
    } else {
        None
    }
}

fn match_occurrence(line: &str, line_index: usize) -> Option<CaseOccurrence> {
    let trimmed = line.trim_start();
    let after_bar = trimmed.strip_prefix('|')?.trim_start();
    let name = uppercase_identifier_prefix(after_bar)?;
    if !after_bar[name.len()..].contains("->") {
        return None;
    }
    let absolute_trim = line.len() - trimmed.len();
    let after_bar_offset = trimmed.len() - trimmed.strip_prefix('|')?.trim_start().len();
    let start = absolute_trim + after_bar_offset;
    Some(CaseOccurrence {
        line: line_index,
        start,
        end: start + name.len(),
        name: name.to_owned(),
    })
}

fn conditional_clusters(lines: &[&str]) -> Vec<BranchCluster> {
    let mut result = Vec::new();
    let mut index = 0usize;
    while index < lines.len() {
        let line = lines[index];
        let trimmed = line.trim_start();
        if !trimmed.starts_with("if ") {
            index += 1;
            continue;
        }
        let indent = leading_spaces(line);
        let mut occurrences = Vec::new();
        if let Some(occurrence) = conditional_occurrence(line, index) {
            occurrences.push(occurrence);
        }
        let mut cursor = index + 1;
        while cursor < lines.len() {
            let candidate = lines[cursor];
            let candidate_trimmed = candidate.trim_start();
            if candidate_trimmed.is_empty() {
                cursor += 1;
                continue;
            }
            if leading_spaces(candidate) != indent {
                break;
            }
            if candidate_trimmed.starts_with("elif ") {
                if let Some(occurrence) = conditional_occurrence(candidate, cursor) {
                    occurrences.push(occurrence);
                }
                cursor += 1;
                continue;
            }
            if candidate_trimmed.starts_with("else ") {
                if let Some(occurrence) = conditional_occurrence(candidate, cursor) {
                    occurrences.push(occurrence);
                }
                cursor += 1;
            }
            break;
        }
        if occurrences.len() >= 2 {
            result.push(BranchCluster {
                kind: BranchKind::Conditional,
                occurrences,
            });
        }
        index = cursor.max(index + 1);
    }
    result
}

fn match_clusters(lines: &[&str]) -> Vec<BranchCluster> {
    let mut result = Vec::new();
    let mut index = 0usize;
    while index < lines.len() {
        let Some(first) = match_occurrence(lines[index], index) else {
            index += 1;
            continue;
        };
        let indent = leading_spaces(lines[index]);
        let mut occurrences = vec![first];
        let mut cursor = index + 1;
        while cursor < lines.len() {
            let candidate = lines[cursor];
            let candidate_trimmed = candidate.trim_start();
            if candidate_trimmed.is_empty() || candidate_trimmed.starts_with("//") {
                cursor += 1;
                continue;
            }
            let candidate_indent = leading_spaces(candidate);
            if candidate_indent < indent {
                break;
            }
            if candidate_indent > indent {
                cursor += 1;
                continue;
            }
            let Some(occurrence) = match_occurrence(candidate, cursor) else {
                break;
            };
            occurrences.push(occurrence);
            cursor += 1;
        }
        if occurrences.len() >= 2 {
            result.push(BranchCluster {
                kind: BranchKind::Match,
                occurrences,
            });
        }
        index = cursor.max(index + 1);
    }
    result
}

/// The bare name of the single union in `provider` that declares every case of the cluster, if unique.
fn owning_union_type(cluster: &BranchCluster, index: &UnionContextIndex, provider: usize) -> Option<String> {
    let names = cluster
        .occurrences
        .iter()
        .map(|occurrence| occurrence.name.as_str())
        .collect::<BTreeSet<_>>();
    let mut owners = index.groups.iter().filter(|group| {
        group.provider == provider && names.iter().all(|name| group.cases.contains(*name))
    });
    let owner = owners.next()?;
    if owners.next().is_some() {
        return None;
    }
    let bare = owner
        .type_name
        .split(['<', ' '])
        .next()
        .unwrap_or_default()
        .trim();
    (!bare.is_empty()).then(|| bare.to_owned())
}

fn selected_owner(
    cluster: &BranchCluster,
    index: &UnionContextIndex,
    current_provider: usize,
    compile_dependencies: &BTreeSet<usize>,
    provider_order: &[usize],
    source_module: Option<&str>,
) -> Option<UnionOwner> {
    let names = cluster
        .occurrences
        .iter()
        .map(|occurrence| occurrence.name.as_str())
        .collect::<BTreeSet<_>>();
    if names.len() < 2 {
        return None;
    }
    if index
        .nested_local_cases
        .get(&current_provider)
        .is_some_and(|groups| groups.iter().any(|cases| names.iter().all(|name| cases.contains(*name))))
    {
        return Some(UnionOwner::Local);
    }
    let mut case_groups = names
        .iter()
        .filter_map(|name| index.groups_by_case.get(*name));
    let first_groups = case_groups.next()?;
    let mut candidate_groups = first_groups.clone();
    for groups in case_groups {
        candidate_groups = candidate_groups.intersection(groups).copied().collect();
        if candidate_groups.is_empty() {
            return None;
        }
    }
    let candidate_providers = candidate_groups
        .iter()
        .copied()
        .filter_map(|group_index| {
            let group = &index.groups[group_index];
            (group.provider == current_provider || compile_dependencies.contains(&group.provider))
                .then_some(group.provider)
        })
        .collect::<BTreeSet<_>>();
    if candidate_providers.is_empty() {
        return None;
    }
    if candidate_providers.contains(&current_provider) {
        return Some(UnionOwner::Local);
    }
    if let Some(source_module) = source_module {
        let lexical = candidate_groups
            .iter()
            .filter_map(|group_index| {
                let group = &index.groups[*group_index];
                (group.source_module.as_deref() == Some(source_module)
                    && candidate_providers.contains(&group.provider))
                .then_some(group.provider)
            })
            .collect::<BTreeSet<_>>();
        if let Some(provider) = lexical.iter().copied().next()
            && lexical.len() == 1
        {
            return Some(UnionOwner::External(provider));
        }
    }

    let intrusion = names.iter().any(|name| {
        index.providers_by_case.get(*name).is_some_and(|providers| {
            providers
                .iter()
                .filter(|provider| {
                    **provider == current_provider || compile_dependencies.contains(provider)
                })
                .any(|provider| !candidate_providers.contains(provider))
        })
    });
    let root_providers = candidate_providers
        .iter()
        .copied()
        .filter(|provider| {
            !index
                .provider_dependencies
                .get(provider)
                .is_some_and(|dependencies| {
                    dependencies
                        .iter()
                        .any(|dependency| candidate_providers.contains(dependency))
                })
        })
        .collect::<BTreeSet<_>>();
    let unique_dependency_root = candidate_providers.len() > 1 && root_providers.len() == 1;
    if !intrusion && !unique_dependency_root {
        return None;
    }
    let eligible = if root_providers.is_empty() {
        &candidate_providers
    } else {
        &root_providers
    };
    let ranks = provider_order.iter().enumerate().fold(
        BTreeMap::<usize, usize>::new(),
        |mut ranks, (rank, provider)| {
            ranks.insert(*provider, rank);
            ranks
        },
    );
    eligible
        .iter()
        .copied()
        .filter_map(|provider| ranks.get(&provider).copied().map(|rank| (rank, provider)))
        .max()
        .map(|(_, provider)| UnionOwner::External(provider))
}

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
struct TypedUnionBinding {
    variable: String,
    provider: usize,
    cases: BTreeSet<String>,
}

fn qualified_type_prefix(text: &str) -> Option<&str> {
    let trimmed = text.trim_start();
    let end = trimmed
        .char_indices()
        .find_map(|(index, character)| {
            (!(identifier_continue(character) || character == '.')).then_some(index)
        })
        .unwrap_or(trimmed.len());
    (end > 0).then_some(&trimmed[..end])
}

fn typed_union_bindings<F>(
    text: &str,
    index: &UnionContextIndex,
    compile_dependencies: &BTreeSet<usize>,
    module_name: &F,
) -> Vec<TypedUnionBinding>
where
    F: Fn(usize) -> String,
{
    let mut groups_by_marker = BTreeMap::<String, Vec<&UnionGroup>>::new();
    for group in &index.groups {
        if compile_dependencies.contains(&group.provider) {
            groups_by_marker
                .entry(format!(
                    "{}.{}",
                    module_name(group.provider),
                    group.type_name
                ))
                .or_default()
                .push(group);
        }
    }
    if groups_by_marker.is_empty() {
        return Vec::new();
    }

    let mut result = Vec::new();
    for line in text.lines() {
        for (colon, _) in line.match_indices(':') {
            let Some(marker) = qualified_type_prefix(&line[colon + 1..]) else {
                continue;
            };
            let Some(groups) = groups_by_marker.get(marker) else {
                continue;
            };
            let head = line[..colon].trim_end();
            let name_end = head.len();
            let name_start = head
                .char_indices()
                .rev()
                .find_map(|(index, character)| {
                    (!identifier_continue(character)).then_some(index + character.len_utf8())
                })
                .unwrap_or(0);
            let variable = &head[name_start..name_end];
            if variable.is_empty()
                || !variable.chars().next().is_some_and(identifier_start)
                || !variable.chars().all(identifier_continue)
            {
                continue;
            }
            result.extend(groups.iter().map(|group| TypedUnionBinding {
                variable: variable.to_owned(),
                provider: group.provider,
                cases: group.cases.clone(),
            }));
        }
    }
    result.sort();
    result.dedup();
    result
}

fn comparison_left(code: &str, operator_start: usize) -> Option<(usize, usize, &str)> {
    let end = operator_start;
    let mut start = end;
    for (index, character) in code[..end].char_indices().rev() {
        if !identifier_continue(character) {
            break;
        }
        start = index;
    }
    let value = &code[start..end];
    (!value.is_empty()
        && value.chars().next().is_some_and(identifier_start)
        && value.chars().all(identifier_continue))
    .then_some((start, end, value))
}

fn comparison_right(code: &str, operator_end: usize) -> Option<(usize, usize, &str)> {
    let start = operator_end;
    let mut end = start;
    for (offset, character) in code[start..].char_indices() {
        if !identifier_continue(character) {
            break;
        }
        end = start + offset + character.len_utf8();
    }
    let value = &code[start..end];
    (!value.is_empty()
        && value.chars().next().is_some_and(identifier_start)
        && value.chars().all(identifier_continue))
    .then_some((start, end, value))
}

#[must_use]
pub fn qualify_typed_union_comparisons<F>(
    text: &str,
    index: &UnionContextIndex,
    compile_dependencies: &BTreeSet<usize>,
    module_name: F,
) -> String
where
    F: Fn(usize) -> String,
{
    let bindings = typed_union_bindings(text, index, compile_dependencies, &module_name);
    if bindings.is_empty() {
        return text.to_owned();
    }
    let ambiguous_cases = index
        .providers_by_case
        .iter()
        .filter(|(_, providers)| {
            providers
                .iter()
                .filter(|provider| compile_dependencies.contains(provider))
                .count()
                > 1
        })
        .map(|(case, _)| case.clone())
        .collect::<BTreeSet<_>>();
    let mut providers = BTreeMap::<(String, String), usize>::new();
    for binding in &bindings {
        for case in binding.cases.intersection(&ambiguous_cases) {
            providers
                .entry((binding.variable.clone(), case.clone()))
                .or_insert(binding.provider);
        }
    }
    if providers.is_empty() {
        return text.to_owned();
    }

    let mut output = Vec::new();
    for line in text.lines() {
        let comment_start = line.find("//").unwrap_or(line.len());
        let (code, comment) = line.split_at(comment_start);
        let mut replacements = Vec::<(usize, usize, String)>::new();
        for operator in [" = ", " <> "] {
            for (operator_start, _) in code.match_indices(operator) {
                let operator_end = operator_start + operator.len();
                let Some((left_start, left_end, left)) = comparison_left(code, operator_start)
                else {
                    continue;
                };
                let Some((right_start, right_end, right)) = comparison_right(code, operator_end)
                else {
                    continue;
                };
                if let Some(provider) = providers.get(&(left.to_owned(), right.to_owned())) {
                    replacements.push((
                        right_start,
                        right_end,
                        format!("{}.{}", module_name(*provider), right),
                    ));
                } else if let Some(provider) = providers.get(&(right.to_owned(), left.to_owned())) {
                    replacements.push((
                        left_start,
                        left_end,
                        format!("{}.{}", module_name(*provider), left),
                    ));
                }
            }
        }
        replacements.sort_by_key(|right| std::cmp::Reverse(right.0));
        replacements.dedup_by(|left, right| left.0 == right.0 && left.1 == right.1);
        let mut rewritten = code.to_owned();
        for (start, end, replacement) in replacements {
            rewritten.replace_range(start..end, &replacement);
        }
        output.push(format!("{rewritten}{comment}"));
    }
    let mut result = output.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        result.push('\n');
    }
    result
}

#[must_use]
pub fn qualify_ambiguous_union_branches<F>(
    text: &str,
    index: &UnionContextIndex,
    compile_dependencies: &BTreeSet<usize>,
    provider_order: &[usize],
    module_name: F,
) -> String
where
    F: Fn(usize) -> String,
{
    qualify_ambiguous_union_branches_scoped(
        text,
        index,
        usize::MAX,
        compile_dependencies,
        provider_order,
        None,
        module_name,
    )
}

#[must_use]
pub fn qualify_ambiguous_union_branches_scoped<F>(
    text: &str,
    index: &UnionContextIndex,
    current_provider: usize,
    compile_dependencies: &BTreeSet<usize>,
    provider_order: &[usize],
    source_module: Option<&str>,
    module_name: F,
) -> String
where
    F: Fn(usize) -> String,
{
    let lines = text.lines().collect::<Vec<_>>();
    let mut rewrites = BTreeMap::<usize, Vec<(usize, usize, String)>>::new();
    for cluster in conditional_clusters(&lines)
        .into_iter()
        .chain(match_clusters(&lines))
    {
        let Some(owner) = selected_owner(
            &cluster,
            index,
            current_provider,
            compile_dependencies,
            provider_order,
            source_module,
        ) else {
            continue;
        };
        let Some(provider) = owner.external_provider() else {
            continue;
        };
        let prefix = module_name(provider);
        let owning_type = owning_union_type(&cluster, index, provider);
        for occurrence in cluster.occurrences {
            // `Module.Case` resolves to the *first* union in that module declaring the case, while the
            // monolith's unqualified use saw the *latest* one; when the provider declares this case in
            // more than one union, qualify through the owning type instead (`Module.Type.Case`).
            let colliding = index
                .groups
                .iter()
                .filter(|group| group.provider == provider && group.cases.contains(&occurrence.name))
                .count()
                > 1;
            let qualified = match (&owning_type, colliding) {
                (Some(type_name), true) => format!("{prefix}.{type_name}.{}", occurrence.name),
                _ => format!("{prefix}.{}", occurrence.name),
            };
            rewrites
                .entry(occurrence.line)
                .or_default()
                .push((occurrence.start, occurrence.end, qualified));
        }
    }

    if rewrites.is_empty() {
        return text.to_owned();
    }
    let mut output = Vec::with_capacity(lines.len());
    for (line_index, line) in lines.iter().enumerate() {
        let mut rewritten = (*line).to_owned();
        if let Some(line_rewrites) = rewrites.get(&line_index) {
            let mut ordered = line_rewrites.clone();
            ordered.sort_by_key(|(start, _, _)| std::cmp::Reverse(*start));
            for (start, end, replacement) in ordered {
                rewritten.replace_range(start..end, &replacement);
            }
        }
        output.push(rewritten);
    }
    let mut result = output.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        result.push('\n');
    }
    result
}

#[cfg(test)]
mod union_context_tests;
