use spiral_split_binding_header::{
    BindingHeader, BindingOrigin, BindingRole, binding_header, identifiers,
};
use spiral_split_capture_parameter::{
    definition_parameters_before, recursive_group_parameter_type,
};
use spiral_split_lift::{Classified, LocalGroup, LocalLiftPlan};
use spiral_split_lift_plan::ParametricComponent;
use spiral_split_model::{DeclarationId, SplitPlan, fnv1a64};
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::path::{Path, PathBuf};

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum RecursiveExtractionShape {
    CyclicScc,
    RecursiveSingleton,
    ContinuationSingleton,
}

impl RecursiveExtractionShape {
    #[must_use]
    pub const fn as_str(self) -> &'static str {
        match self {
            Self::CyclicScc => "cyclic-scc",
            Self::RecursiveSingleton => "recursive-singleton",
            Self::ContinuationSingleton => "continuation-singleton",
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct RecursiveSccReceipt {
    pub shape: RecursiveExtractionShape,
    pub owner: usize,
    pub component: usize,
    pub members: usize,
    pub extracted_lines: usize,
    pub wrapper_lines: usize,
    pub max_impl_lines: usize,
    pub output_fingerprint: u64,
    pub output: PathBuf,
    pub receipt: PathBuf,
}

#[derive(Clone, Debug)]
struct Member {
    header: BindingHeader,
    collapsed_header: String,
    header_line_count: usize,
    function_value: bool,
    impl_name: String,
    peers: Vec<String>,
    captures: Vec<String>,
    arguments: Vec<String>,
    active_pattern_preludes: Vec<String>,
    relative_start: usize,
    relative_end: usize,
}

#[derive(Clone, Debug)]
struct ActivePatternProvider {
    local_index: usize,
    names: BTreeSet<String>,
}

fn leading_spaces(line: &str) -> usize {
    line.bytes().take_while(|byte| *byte == b' ').count()
}

fn sanitize(name: &str) -> String {
    name.chars()
        .map(|character| {
            if character.is_ascii_alphanumeric() || character == '_' {
                character
            } else {
                '_'
            }
        })
        .collect()
}

fn after_binding_name<'a>(line: &'a str, name: &str) -> Result<&'a str, String> {
    let trimmed = line.trim_start();
    let position = trimmed
        .find(name)
        .ok_or_else(|| format!("binding name not found in header: {name}: {trimmed}"))?;
    Ok(&trimmed[position + name.len()..])
}

fn ordered_arguments(line: &str, header: &BindingHeader) -> Result<Vec<String>, String> {
    let after = after_binding_name(line, &header.name)?;
    let before_equals = after.split_once('=').map_or(after, |(before, _)| before);
    let ordered = identifiers(before_equals)
        .into_iter()
        .filter(|name| header.parameters.contains(name))
        .fold(Vec::<String>::new(), |mut values, name| {
            if !values.contains(&name) {
                values.push(name);
            }
            values
        });
    if ordered.len() != header.parameters.len() {
        return Err(format!(
            "cannot reconstruct ordered parameters for {}: expected={:?} actual={ordered:?}",
            header.name, header.parameters
        ));
    }
    if ordered.is_empty() {
        return Err(format!(
            "recursive SCC member has no reconstructable function arguments: {}",
            header.name
        ));
    }
    Ok(ordered)
}

fn member_arguments(
    line: &str,
    header: &BindingHeader,
    function_value: bool,
) -> Result<Vec<String>, String> {
    if !function_value {
        return ordered_arguments(line, header);
    }
    let mut arguments = if header.parameters.is_empty() {
        Vec::new()
    } else {
        ordered_arguments(line, header)?
    };
    arguments.push("__spiral_scc_arg".to_owned());
    Ok(arguments)
}

fn ordered_unique_names<'a>(names: impl Iterator<Item = &'a String>) -> Vec<String> {
    let mut seen = BTreeSet::<String>::new();
    names
        .filter_map(|name| {
            if seen.insert(name.clone()) {
                Some(name.clone())
            } else {
                None
            }
        })
        .collect()
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum MaterializationVisit {
    Visiting,
    Materialized,
}

fn active_pattern_providers(
    owner_text: &str,
    owner_start: usize,
    groups: &[LocalGroup],
    owner_id: DeclarationId,
) -> Result<Vec<ActivePatternProvider>, String> {
    let owner_lines = owner_text.lines().collect::<Vec<_>>();
    let mut providers = Vec::new();
    for group in groups.iter().filter(|group| group.owner == owner_id) {
        let relative_start = group
            .start_line
            .checked_sub(owner_start)
            .ok_or_else(|| format!("active pattern starts before owner: {}", group.local_index))?;
        let relative_end = group
            .end_line
            .checked_sub(owner_start)
            .ok_or_else(|| format!("active pattern ends before owner: {}", group.local_index))?;
        let selected = owner_lines
            .get(relative_start..relative_end)
            .ok_or_else(|| format!("active pattern outside owner: {}", group.local_index))?;
        let Some(header_line_count) = selected
            .iter()
            .position(|line| line.contains('='))
            .map(|index| index + 1)
        else {
            continue;
        };
        let header_text = selected[..header_line_count].join(" ");
        let Some(header) = binding_header(&header_text) else {
            continue;
        };
        if header.role != BindingRole::ActivePattern {
            continue;
        }
        providers.push(ActivePatternProvider {
            local_index: group.local_index,
            names: group.names.clone(),
        });
    }
    Ok(providers)
}

fn owner_local_group<'a>(
    groups: &'a [LocalGroup],
    owner_id: DeclarationId,
    local_index: usize,
) -> Result<&'a LocalGroup, String> {
    groups
        .iter()
        .find(|group| group.owner == owner_id && group.local_index == local_index)
        .ok_or_else(|| {
            format!(
                "active pattern dependency not found: owner={} local={local_index}",
                owner_id.0
            )
        })
}

fn render_local_materialization(
    group: &LocalGroup,
    owner_text: &str,
    owner_start: usize,
    target_indent: usize,
) -> Result<String, String> {
    let owner_lines = owner_text.lines().collect::<Vec<_>>();
    let relative_start = group.start_line.checked_sub(owner_start).ok_or_else(|| {
        format!(
            "materialized local starts before owner: {}",
            group.local_index
        )
    })?;
    let relative_end = group.end_line.checked_sub(owner_start).ok_or_else(|| {
        format!(
            "materialized local ends before owner: {}",
            group.local_index
        )
    })?;
    let selected = owner_lines
        .get(relative_start..relative_end)
        .ok_or_else(|| format!("materialized local outside owner: {}", group.local_index))?;
    let source_indent = selected
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or(target_indent, |line| leading_spaces(line));
    let mut rendered = Vec::with_capacity(selected.len());
    for line in selected {
        if line.trim().is_empty() {
            rendered.push(String::new());
            continue;
        }
        let indent = leading_spaces(line);
        if indent < source_indent {
            return Err(format!(
                "cannot reindent materialized local {}: {line}",
                group.local_index
            ));
        }
        let relative = indent - source_indent;
        let content = line.get(indent..).unwrap_or(line);
        rendered.push(format!(
            "{}{}{}",
            " ".repeat(target_indent),
            " ".repeat(relative),
            content
        ));
    }
    Ok(rendered.join("\n"))
}

#[allow(clippy::too_many_arguments)]
fn materialize_local_closure(
    local_index: usize,
    owner_text: &str,
    owner_start: usize,
    groups: &[LocalGroup],
    owner_id: DeclarationId,
    component_local_indices: &BTreeSet<usize>,
    visits: &mut BTreeMap<usize, MaterializationVisit>,
    materialized_names: &mut BTreeSet<String>,
    captures: &mut BTreeSet<String>,
    preludes: &mut Vec<String>,
) -> Result<(), String> {
    if component_local_indices.contains(&local_index) {
        return Err(format!(
            "active pattern dependency enters recursive SCC: owner={} local={local_index}",
            owner_id.0
        ));
    }
    match visits.get(&local_index) {
        Some(MaterializationVisit::Materialized) => return Ok(()),
        Some(MaterializationVisit::Visiting) => {
            return Err(format!(
                "active pattern dependency cycle: owner={} local={local_index}",
                owner_id.0
            ));
        }
        None => {}
    }
    visits.insert(local_index, MaterializationVisit::Visiting);
    let group = owner_local_group(groups, owner_id, local_index)?;
    for dependency in &group.local_dependencies {
        materialize_local_closure(
            *dependency,
            owner_text,
            owner_start,
            groups,
            owner_id,
            component_local_indices,
            visits,
            materialized_names,
            captures,
            preludes,
        )?;
    }
    materialized_names.extend(group.names.iter().cloned());
    captures.extend(group.captures.iter().cloned());
    preludes.push(render_local_materialization(
        group,
        owner_text,
        owner_start,
        8,
    )?);
    visits.insert(local_index, MaterializationVisit::Materialized);
    Ok(())
}

fn active_pattern_materialization(
    body: &str,
    providers: &[ActivePatternProvider],
    owner_text: &str,
    owner_start: usize,
    groups: &[LocalGroup],
    owner_id: DeclarationId,
    component_local_indices: &BTreeSet<usize>,
) -> Result<(BTreeSet<String>, BTreeSet<String>, Vec<String>), String> {
    let lexical = identifiers(body).into_iter().collect::<BTreeSet<_>>();
    let mut materialized_names = BTreeSet::new();
    let mut captures = BTreeSet::new();
    let mut preludes = Vec::new();
    let mut visits = BTreeMap::new();
    for provider in providers {
        if provider.names.is_disjoint(&lexical) {
            continue;
        }
        materialize_local_closure(
            provider.local_index,
            owner_text,
            owner_start,
            groups,
            owner_id,
            component_local_indices,
            &mut visits,
            &mut materialized_names,
            &mut captures,
            &mut preludes,
        )?;
    }
    Ok((materialized_names, captures, preludes))
}

fn extra_parameters(member: &Member) -> Vec<String> {
    let arguments = member.arguments.iter().cloned().collect::<BTreeSet<_>>();
    ordered_unique_names(member.peers.iter().chain(member.captures.iter()))
        .into_iter()
        .filter(|name| !arguments.contains(name))
        .collect()
}

fn annotate_recursive_arguments(
    line: &str,
    header: &BindingHeader,
    owner_text: &str,
    group_start: usize,
) -> String {
    let equals = line.find('=').unwrap_or(line.len());
    let mut output = String::with_capacity(line.len() + 32);
    let mut cursor = 0usize;
    while cursor < line.len() {
        if cursor >= equals {
            output.push_str(&line[cursor..]);
            break;
        }
        let character = line[cursor..]
            .chars()
            .next()
            .expect("cursor on char boundary");
        if character == '_' || character.is_alphabetic() {
            let start = cursor;
            cursor += character.len_utf8();
            while cursor < equals {
                let next = line[cursor..]
                    .chars()
                    .next()
                    .expect("cursor on char boundary");
                if next == '_' || next == '\'' || next.is_alphanumeric() {
                    cursor += next.len_utf8();
                } else {
                    break;
                }
            }
            let token = &line[start..cursor];
            let next_non_space = line[cursor..equals]
                .chars()
                .find(|value| !value.is_whitespace());
            if token != header.name
                && header.parameters.contains(token)
                && next_non_space != Some(':')
                && let Some(annotation) =
                    recursive_group_parameter_type(owner_text, token, group_start)
            {
                output.push('(');
                output.push_str(token);
                output.push_str(": ");
                output.push_str(&annotation);
                output.push(')');
            } else {
                output.push_str(token);
            }
        } else {
            output.push(character);
            cursor += character.len_utf8();
        }
    }
    output
}

fn impl_header(
    member: &Member,
    original: &str,
    indent: usize,
    owner_text: &str,
) -> Result<String, String> {
    let after = after_binding_name(original, &member.header.name)?.trim_start();
    let extras = extra_parameters(member);
    let rendered_extras = definition_parameters_before(owner_text, &extras, member.relative_start);
    let prefix = if rendered_extras.is_empty() {
        String::new()
    } else {
        format!("{} ", rendered_extras.join(" "))
    };
    Ok(format!(
        "{}let {} {prefix}{after}",
        " ".repeat(indent),
        member.impl_name
    ))
}

fn wrapper_header(member: &Member, indent: usize) -> Result<String, String> {
    let (before_equals, _) = member
        .collapsed_header
        .split_once('=')
        .ok_or_else(|| format!("recursive header has no equals: {}", member.header.name))?;
    let normalized = before_equals.trim();
    if member.function_value {
        Ok(format!(
            "{}{} __spiral_scc_arg =",
            " ".repeat(indent),
            normalized
        ))
    } else {
        Ok(format!("{}{} =", " ".repeat(indent), normalized))
    }
}

fn wrapper_body(member: &Member, indent: usize) -> String {
    let extras = extra_parameters(member);
    let applied = ordered_unique_names(extras.iter().chain(member.arguments.iter())).join(" ");
    format!("{}{} {}", " ".repeat(indent + 4), member.impl_name, applied)
}

fn outdent(line: &str, spaces: usize) -> Result<String, String> {
    if line.trim().is_empty() {
        return Ok(String::new());
    }
    if leading_spaces(line) < spaces {
        return Err(format!(
            "cannot outdent recursive implementation by {spaces}: {line}"
        ));
    }
    Ok(line[spaces..].to_owned())
}

fn receipt_path(output: &Path) -> PathBuf {
    let mut value = output.as_os_str().to_owned();
    value.push(".recursive-scc.tsv");
    PathBuf::from(value)
}

fn join_source(lines: &[String], original_bytes: usize) -> String {
    let mut text = lines.join("\n");
    if original_bytes > text.len() {
        text.push('\n');
    }
    text
}

fn recursive_peers(
    body: &str,
    references: &BTreeSet<String>,
    owner_local_names: &BTreeSet<String>,
    parameters: &BTreeSet<String>,
) -> Vec<String> {
    let lexical = identifiers(body).into_iter().collect::<BTreeSet<_>>();
    references
        .union(&lexical)
        .filter(|name| owner_local_names.contains(*name))
        .filter(|name| !parameters.contains(*name))
        .cloned()
        .collect()
}

fn recursive_extraction_shape(
    recursive: bool,
    origins: &[BindingOrigin],
) -> Result<RecursiveExtractionShape, String> {
    match (recursive, origins) {
        (true, [_]) => Ok(RecursiveExtractionShape::RecursiveSingleton),
        (true, [_, ..]) => Ok(RecursiveExtractionShape::CyclicScc),
        (false, [BindingOrigin::RecursiveContinuation]) => {
            Ok(RecursiveExtractionShape::ContinuationSingleton)
        }
        _ => Err(format!(
            "component is not a supported recursive extraction shape: recursive={recursive} members={} origins={origins:?}",
            origins.len()
        )),
    }
}

fn make_members(
    plan: &SplitPlan,
    local: &LocalLiftPlan<Classified>,
    component: &ParametricComponent,
) -> Result<(RecursiveExtractionShape, Vec<Member>), String> {
    if component.members.is_empty() {
        return Err(format!(
            "recursive extraction component is empty: {}",
            component.component
        ));
    }
    let owner = plan
        .declarations
        .get(component.owner.0)
        .ok_or_else(|| format!("owner not found: {}", component.owner.0))?;
    let component_names = component.names.clone();
    let owner_local_names = local
        .groups
        .iter()
        .filter(|group| group.owner == component.owner)
        .flat_map(|group| group.names.iter().cloned())
        .collect::<BTreeSet<_>>();
    let recursive_group_start = component
        .start_line
        .checked_sub(owner.span.start)
        .ok_or_else(|| format!("component starts before owner: {}", component.component))?;
    let component_local_indices = component
        .members
        .iter()
        .map(|index| {
            local
                .groups
                .get(*index)
                .map(|group| group.local_index)
                .ok_or_else(|| format!("local group not found: {index}"))
        })
        .collect::<Result<BTreeSet<_>, String>>()?;
    let active_patterns = active_pattern_providers(
        &owner.text,
        owner.span.start,
        &local.groups,
        component.owner,
    )?;
    let mut members = component
        .members
        .iter()
        .map(|index| {
            let group = local
                .groups
                .get(*index)
                .ok_or_else(|| format!("local group not found: {index}"))?;
            if group.owner != component.owner {
                return Err(format!(
                    "cross-owner recursive member: group={} owner={} expected={}",
                    index, group.owner.0, component.owner.0
                ));
            }
            let relative_start = group
                .start_line
                .checked_sub(owner.span.start)
                .ok_or_else(|| format!("group starts before owner: {index}"))?;
            let relative_end = group
                .end_line
                .checked_sub(owner.span.start)
                .ok_or_else(|| format!("group ends before owner: {index}"))?;
            let owner_lines = owner.text.lines().collect::<Vec<_>>();
            let selected = owner_lines
                .get(relative_start..relative_end)
                .ok_or_else(|| format!("group outside owner: {index}"))?;
            let header_line_count = selected
                .iter()
                .position(|line| line.contains('='))
                .map(|index| index + 1)
                .ok_or_else(|| format!("recursive header has no equals: group={index}"))?;
            let raw_collapsed_header = selected[..header_line_count].join(" ");
            let header = binding_header(&raw_collapsed_header).ok_or_else(|| {
                format!("cannot parse recursive group header: {raw_collapsed_header}")
            })?;
            let collapsed_header = annotate_recursive_arguments(
                &raw_collapsed_header,
                &header,
                &owner.text,
                recursive_group_start,
            );
            let selected_text = selected.join("\n");
            let function_value = selected_text
                .split_once('=')
                .is_some_and(|(_, rhs)| rhs.trim_start().starts_with("function"));
            if header.role != BindingRole::Function && !function_value {
                return Err(format!(
                    "recursive SCC member is not a function: {} role={:?} prefix={}",
                    header.name,
                    header.role,
                    selected_text.chars().take(240).collect::<String>()
                ));
            }
            let arguments = member_arguments(&collapsed_header, &header, function_value)?;
            let body = selected[header_line_count..].join("\n");
            let (active_pattern_names, active_pattern_captures, active_pattern_preludes) =
                active_pattern_materialization(
                    &body,
                    &active_patterns,
                    &owner.text,
                    owner.span.start,
                    &local.groups,
                    component.owner,
                    &component_local_indices,
                )?;
            let peers = recursive_peers(
                &body,
                &group.references,
                &owner_local_names,
                &header.parameters,
            )
            .into_iter()
            .filter(|name| !active_pattern_names.contains(name))
            .collect::<Vec<_>>();
            let captures =
                ordered_unique_names(group.captures.iter().chain(active_pattern_captures.iter()))
                    .into_iter()
                    .filter(|name| !component_names.contains(name))
                    .filter(|name| !header.parameters.contains(name))
                    .filter(|name| !active_pattern_names.contains(name))
                    .collect::<Vec<_>>();
            Ok(Member {
                impl_name: format!(
                    "__spiral_scc_{}_{}_{}",
                    component.owner.0,
                    component.component,
                    sanitize(&header.name)
                ),
                header,
                collapsed_header,
                header_line_count,
                function_value,
                peers,
                captures,
                arguments,
                active_pattern_preludes,
                relative_start,
                relative_end,
            })
        })
        .collect::<Result<Vec<_>, String>>()?;
    members.sort_by_key(|member| member.relative_start);
    let origins = members
        .iter()
        .map(|member| member.header.origin)
        .collect::<Vec<_>>();
    let shape = recursive_extraction_shape(component.recursive, &origins)?;
    Ok((shape, members))
}

pub fn extract_recursive_scc(
    plan: &SplitPlan,
    local: &LocalLiftPlan<Classified>,
    component: &ParametricComponent,
    output: &Path,
) -> Result<RecursiveSccReceipt, String> {
    extract_recursive_scc_selective(plan, local, component, &BTreeSet::new(), output)
}

pub fn extract_recursive_scc_selective(
    plan: &SplitPlan,
    local: &LocalLiftPlan<Classified>,
    component: &ParametricComponent,
    kept_members: &BTreeSet<String>,
    output: &Path,
) -> Result<RecursiveSccReceipt, String> {
    let owner = plan
        .declarations
        .get(component.owner.0)
        .ok_or_else(|| format!("owner not found: {}", component.owner.0))?;
    let (shape, members) = make_members(plan, local, component)?;
    for kept in kept_members {
        if !members.iter().any(|member| &member.header.name == kept) {
            return Err(format!("kept recursive member not found: {kept}"));
        }
    }
    let owner_lines = owner.text.lines().collect::<Vec<_>>();
    let mut implementations = Vec::<String>::new();
    let mut max_impl_lines = 0usize;
    let mut extracted_lines = 0usize;
    for member in &members {
        if kept_members.contains(&member.header.name) {
            continue;
        }
        let selected = &owner_lines[member.relative_start..member.relative_end];
        let member_indent = leading_spaces(owner_lines[member.relative_start]);
        extracted_lines += selected.len();
        max_impl_lines = max_impl_lines.max(selected.len());
        implementations.push(impl_header(
            member,
            &member.collapsed_header,
            4,
            &owner.text,
        )?);
        for prelude in &member.active_pattern_preludes {
            implementations.extend(prelude.lines().map(str::to_owned));
            implementations.push(String::new());
        }
        for line in &selected[member.header_line_count..] {
            implementations.push(outdent(line, member_indent.saturating_sub(4))?);
        }
        implementations.push(String::new());
    }

    let mut rewritten_owner = Vec::<String>::new();
    let mut cursor = 0usize;
    let mut wrapper_lines = 0usize;
    for member in &members {
        if member.relative_start < cursor {
            return Err(format!(
                "recursive SCC member spans overlap: {} start={} cursor={}",
                member.header.name, member.relative_start, cursor
            ));
        }
        rewritten_owner.extend(
            owner_lines[cursor..member.relative_start]
                .iter()
                .map(|line| (*line).to_owned()),
        );
        if kept_members.contains(&member.header.name) {
            rewritten_owner.extend(
                owner_lines[member.relative_start..member.relative_end]
                    .iter()
                    .map(|line| (*line).to_owned()),
            );
        } else {
            let member_indent = leading_spaces(owner_lines[member.relative_start]);
            rewritten_owner.push(wrapper_header(member, member_indent)?);
            rewritten_owner.push(wrapper_body(member, member_indent));
            wrapper_lines += 2;
        }
        cursor = member.relative_end;
    }
    rewritten_owner.extend(owner_lines[cursor..].iter().map(|line| (*line).to_owned()));

    let mut source_lines = Vec::<String>::new();
    source_lines.extend(plan.source.lines[..owner.span.start].iter().cloned());
    source_lines.extend(implementations.iter().cloned());
    source_lines.extend(rewritten_owner);
    source_lines.extend(plan.source.lines[owner.span.end..].iter().cloned());
    let rewritten = join_source(&source_lines, plan.source.bytes);
    if let Some(parent) = output.parent() {
        fs::create_dir_all(parent)
            .map_err(|error| format!("cannot create recursive SCC output parent: {error}"))?;
    }
    fs::write(output, &rewritten)
        .map_err(|error| format!("cannot write {}: {error}", output.display()))?;
    let output_fingerprint = fnv1a64(rewritten.as_bytes());
    let receipt = receipt_path(output);
    let receipt_text = format!(
        "status\tpassed\nshape\t{}\nowner\t{}\ncomponent\t{}\nmembers\t{}\nextracted_lines\t{}\nwrapper_lines\t{}\nmax_impl_lines\t{}\noutput_fingerprint\t{}\nimplementations\t{}\n",
        shape.as_str(),
        component.owner.0,
        component.component,
        members.len(),
        extracted_lines,
        wrapper_lines,
        max_impl_lines,
        output_fingerprint,
        members
            .iter()
            .filter(|member| !kept_members.contains(&member.header.name))
            .map(|member| member.impl_name.clone())
            .collect::<Vec<_>>()
            .join(",")
    );
    fs::write(&receipt, receipt_text)
        .map_err(|error| format!("cannot write {}: {error}", receipt.display()))?;
    Ok(RecursiveSccReceipt {
        shape,
        owner: component.owner.0,
        component: component.component,
        members: members.len(),
        extracted_lines,
        wrapper_lines,
        max_impl_lines,
        output_fingerprint,
        output: output.to_path_buf(),
        receipt,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    fn member(header_line: &str) -> Member {
        let header = binding_header(header_line).expect("header");
        Member {
            collapsed_header: header_line.to_owned(),
            header_line_count: 1,
            header,
            function_value: false,
            impl_name: "__impl_f".to_owned(),
            peers: vec!["g".to_owned()],
            captures: vec!["env".to_owned()],
            arguments: vec!["x".to_owned()],
            active_pattern_preludes: Vec::new(),
            relative_start: 0,
            relative_end: 2,
        }
    }

    fn local_group(
        local_index: usize,
        start_line: usize,
        end_line: usize,
        names: &[&str],
        captures: &[&str],
        dependencies: &[usize],
    ) -> LocalGroup {
        LocalGroup {
            owner: DeclarationId(0),
            owner_heading: "owner".to_owned(),
            local_index,
            start_line,
            end_line,
            line_count: end_line - start_line,
            names: names.iter().map(|name| (*name).to_owned()).collect(),
            parameters: BTreeSet::new(),
            references: BTreeSet::new(),
            captures: captures.iter().map(|name| (*name).to_owned()).collect(),
            local_dependencies: dependencies.iter().copied().collect(),
            disposition: spiral_split_lift::LiftDisposition::Liftable,
        }
    }

    #[test]
    fn implementation_header_keeps_original_signature() {
        let value = member("    let rec f (x : int) : int =");
        assert_eq!(
            impl_header(&value, "    let rec f (x : int) : int =", 4, "").expect("impl"),
            "    let __impl_f g env (x : int) : int ="
        );
    }

    #[test]
    fn implementation_header_types_object_expression_capture() {
        let mut value = member("let rec f x =");
        value.peers.clear();
        value.captures = vec!["comparer".to_owned()];
        value.relative_start = 5;
        let owner = "let comparer =\n    { new System.Collections.Generic.IEqualityComparer<ConsedNode<Ty []>> with\n        member _.Equals(a,b) = a = b\n        member _.GetHashCode(a) = hash a\n    }\nlet rec f x =\n    x\n";
        assert_eq!(
            impl_header(&value, "let rec f x =", 4, owner).expect("impl"),
            "    let __impl_f (comparer: System.Collections.Generic.IEqualityComparer<ConsedNode<Ty []>>) x ="
        );
    }

    #[test]
    fn wrapper_reconnects_peer_capture_and_argument() {
        let value = member("    let rec f x =");
        assert_eq!(wrapper_body(&value, 4), "        __impl_f g env x");
    }

    #[test]
    fn implementation_dependencies_are_deduplicated_across_peer_and_capture() {
        let mut value = member("    let rec f x =");
        value.peers = vec!["shared".to_owned(), "g".to_owned()];
        value.captures = vec!["shared".to_owned(), "env".to_owned()];
        assert_eq!(
            impl_header(&value, "    let rec f x =", 4, "").expect("impl"),
            "    let __impl_f shared g env x ="
        );
        assert_eq!(wrapper_body(&value, 4), "        __impl_f shared g env x");
    }

    #[test]
    fn original_argument_wins_over_duplicate_capture() {
        let mut value = member("    let rec f env x =");
        value.peers.clear();
        value.captures = vec!["env".to_owned()];
        value.arguments = vec!["env".to_owned(), "x".to_owned()];
        assert_eq!(
            impl_header(&value, "    let rec f env x =", 4, "").expect("impl"),
            "    let __impl_f env x ="
        );
        assert_eq!(wrapper_body(&value, 4), "        __impl_f env x");
    }

    #[test]
    fn function_value_keeps_declared_arguments_before_implicit_case_argument() {
        let header = binding_header("and assert_ty_lit s = function").expect("header");
        assert_eq!(
            member_arguments("and assert_ty_lit s = function", &header, true).expect("args"),
            vec!["s", "__spiral_scc_arg"]
        );
    }

    #[test]
    fn parameterless_function_value_uses_only_implicit_case_argument() {
        let header = binding_header("let choose = function").expect("header");
        assert_eq!(
            member_arguments("let choose = function", &header, true).expect("args"),
            vec!["__spiral_scc_arg"]
        );
    }

    #[test]
    fn ordered_arguments_ignore_type_names() {
        let header = binding_header("    let rec f (x : SomeType) y : int =").expect("header");
        assert_eq!(
            ordered_arguments("    let rec f (x : SomeType) y : int =", &header).expect("args"),
            vec!["x", "y"]
        );
    }

    #[test]
    fn lexical_peer_witness_recovers_missing_graph_reference() {
        let owner_local_names = BTreeSet::from(["f".to_owned(), "g".to_owned()]);
        let parameters = BTreeSet::from(["x".to_owned()]);
        let references = BTreeSet::new();
        assert_eq!(
            recursive_peers(
                "if x = 0 then 0 else g (x - 1)",
                &references,
                &owner_local_names,
                &parameters,
            ),
            vec!["g"]
        );
    }

    #[test]
    fn lexical_peer_witness_ignores_comments_strings_and_parameters() {
        let owner_local_names = BTreeSet::from(["f".to_owned(), "g".to_owned()]);
        let parameters = BTreeSet::from(["g".to_owned()]);
        let references = BTreeSet::new();
        assert!(
            recursive_peers(
                "// f\nlet text = \"f g\"\ng 1",
                &references,
                &owner_local_names,
                &parameters,
            )
            .is_empty()
        );
    }

    #[test]
    fn active_pattern_materialization_closes_dependencies_in_topological_order() {
        let owner = "let outer ready value =\n    let is_ready x = ready x\n    let (|Ready|Pending|) value =\n        if is_ready value then Ready value else Pending value\n    match value with\n    | Ready x -> x\n    | Pending x -> x";
        let groups = vec![
            local_group(0, 1, 2, &["is_ready"], &["ready"], &[]),
            local_group(1, 2, 4, &["Pending", "Ready"], &[], &[0]),
        ];
        let provider = ActivePatternProvider {
            local_index: 1,
            names: BTreeSet::from(["Pending".to_owned(), "Ready".to_owned()]),
        };
        let (materialized_names, captures, preludes) = active_pattern_materialization(
            "match value with | Ready x -> x | Pending x -> x",
            &[provider],
            owner,
            0,
            &groups,
            DeclarationId(0),
            &BTreeSet::new(),
        )
        .expect("materialization");
        assert_eq!(
            materialized_names,
            BTreeSet::from([
                "Pending".to_owned(),
                "Ready".to_owned(),
                "is_ready".to_owned(),
            ])
        );
        assert_eq!(captures, BTreeSet::from(["ready".to_owned()]));
        assert_eq!(preludes.len(), 2);
        assert!(preludes[0].contains("let is_ready x = ready x"));
        assert!(preludes[1].contains("let (|Ready|Pending|) value ="));
        assert!(preludes[1].contains("if is_ready value then Ready value else Pending value"));
    }

    #[test]
    fn active_pattern_materialization_rejects_dependency_cycle() {
        let owner = "let outer value =\n    let first x = second x\n    let (|Ready|_|) value =\n        if first value then Some value else None";
        let groups = vec![
            local_group(0, 1, 2, &["first"], &[], &[1]),
            local_group(1, 2, 4, &["Ready"], &[], &[0]),
        ];
        let provider = ActivePatternProvider {
            local_index: 1,
            names: BTreeSet::from(["Ready".to_owned()]),
        };
        let error = active_pattern_materialization(
            "match value with | Ready x -> x | _ -> value",
            &[provider],
            owner,
            0,
            &groups,
            DeclarationId(0),
            &BTreeSet::new(),
        )
        .expect_err("cyclic materialization must block");
        assert!(error.contains("active pattern dependency cycle"));
    }

    #[test]
    fn active_pattern_materialization_rejects_dependency_into_recursive_scc() {
        let owner = "let outer value =\n    let (|Ready|_|) value =\n        if recursive_member value then Some value else None";
        let groups = vec![local_group(1, 1, 3, &["Ready"], &[], &[7])];
        let provider = ActivePatternProvider {
            local_index: 1,
            names: BTreeSet::from(["Ready".to_owned()]),
        };
        let error = active_pattern_materialization(
            "match value with | Ready x -> x | _ -> value",
            &[provider],
            owner,
            0,
            &groups,
            DeclarationId(0),
            &BTreeSet::from([7]),
        )
        .expect_err("dependency into recursive SCC must block");
        assert!(error.contains("active pattern dependency enters recursive SCC"));
    }

    #[test]
    fn multi_member_recursive_component_is_cyclic_scc() {
        assert_eq!(
            recursive_extraction_shape(
                true,
                &[BindingOrigin::Let, BindingOrigin::RecursiveContinuation],
            )
            .expect("shape"),
            RecursiveExtractionShape::CyclicScc
        );
    }

    #[test]
    fn recursive_singleton_keeps_explicit_shape() {
        assert_eq!(
            recursive_extraction_shape(true, &[BindingOrigin::Let]).expect("shape"),
            RecursiveExtractionShape::RecursiveSingleton
        );
    }

    #[test]
    fn continuation_singleton_requires_recursive_continuation_origin() {
        assert_eq!(
            recursive_extraction_shape(false, &[BindingOrigin::RecursiveContinuation])
                .expect("shape"),
            RecursiveExtractionShape::ContinuationSingleton
        );
        assert!(recursive_extraction_shape(false, &[BindingOrigin::Let]).is_err());
    }
}
