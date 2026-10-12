mod wrapped_anonymous_identity;

use rayon::prelude::*;
use spiral_split_bridge_index::{
    CompactPrefixIndex, all_anonymous_record_spans, anonymous_record_spans,
    innermost_anonymous_record_spans,
};
use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::path::Path;

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub struct AnonymousRecordAlias {
    pub provider_shard: usize,
    pub name: String,
    pub fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
struct NestedAnonymousRecordAlias {
    provider_shard: usize,
    owner: String,
    field: String,
    name: String,
    anonymous_type: String,
    fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
pub struct NamedTupleAlias {
    pub provider_shard: usize,
    pub name: String,
    pub elements: Vec<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BridgeAnnotation {
    pub consumer_shard: usize,
    pub provider_shard: usize,
    pub alias: String,
    pub fields: BTreeSet<String>,
    pub line: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BridgeAmbiguity {
    pub consumer_shard: usize,
    pub aliases: Vec<String>,
    pub fields: BTreeSet<String>,
    pub line: usize,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct BridgeReport {
    pub aliases: usize,
    pub files_scanned: usize,
    pub files_changed: usize,
    pub literals_seen: usize,
    pub annotations: Vec<BridgeAnnotation>,
    pub ambiguities: Vec<BridgeAmbiguity>,
}

fn valid_identifier(value: &str) -> bool {
    let mut characters = value.chars();
    let Some(first) = characters.next() else {
        return false;
    };
    (first == '_' || first.is_ascii_alphabetic())
        && characters.all(|character| {
            character == '_' || character == '\'' || character.is_ascii_alphanumeric()
        })
}

fn declaration_header(text: &str) -> Option<&str> {
    text.lines().map(str::trim_start).find(|line| {
        !line.is_empty()
            && !line.starts_with("//")
            && !line.starts_with("[<")
            && !line.starts_with('#')
    })
}

fn alias_name(text: &str) -> Option<String> {
    let header = declaration_header(text)?;
    let rest = header
        .strip_prefix("type ")
        .or_else(|| header.strip_prefix("and "))?;
    let equals = rest.find('=')?;
    let left = rest[..equals].trim();
    if left.contains('<') || left.contains('(') {
        return None;
    }
    let name = left.split_whitespace().next()?;
    valid_identifier(name).then(|| name.to_owned())
}

fn split_top_level(text: &str, delimiter: char) -> Vec<&str> {
    let mut parts = Vec::new();
    let mut start = 0usize;
    let mut depth = 0usize;
    for (index, character) in text.char_indices() {
        match character {
            '(' | '[' | '{' | '<' => depth += 1,
            ')' | ']' | '}' | '>' => depth = depth.saturating_sub(1),
            value if value == delimiter && depth == 0 => {
                parts.push(text[start..index].trim());
                start = index + value.len_utf8();
            }
            _ => {}
        }
    }
    parts.push(text[start..].trim());
    parts
}

fn named_tuple_alias(text: &str, provider_shard: usize) -> Option<NamedTupleAlias> {
    let header = declaration_header(text)?;
    let rest = header
        .strip_prefix("type ")
        .or_else(|| header.strip_prefix("and "))?;
    let equals = rest.find('=')?;
    let left = rest[..equals].trim();
    if left.contains('<') || left.contains('(') {
        return None;
    }
    let name = left.split_whitespace().next()?;
    if !valid_identifier(name) {
        return None;
    }
    let elements = split_top_level(rest[equals + 1..].trim(), '*');
    if elements.len() < 2 || elements.iter().any(|element| !valid_identifier(element)) {
        return None;
    }
    Some(NamedTupleAlias {
        provider_shard,
        name: name.to_owned(),
        elements: elements.into_iter().map(str::to_owned).collect(),
    })
}

fn field_label(segment: &str) -> Option<String> {
    let segment = segment.trim();
    if segment.is_empty() {
        return None;
    }
    let delimiter = segment
        .char_indices()
        .find_map(|(index, character)| matches!(character, ':' | '=').then_some(index));
    let label = delimiter.map_or(segment, |index| &segment[..index]).trim();
    valid_identifier(label).then(|| label.to_owned())
}

fn record_shape(content: &str) -> Option<BTreeSet<String>> {
    let mut fields = BTreeSet::new();
    let mut start = 0usize;
    let mut depth = 0usize;
    for (index, character) in content.char_indices() {
        match character {
            '(' | '[' | '{' => depth += 1,
            ')' | ']' | '}' => depth = depth.saturating_sub(1),
            character if (character == ';' || character as u32 == 10) && depth == 0 => {
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
    (!fields.is_empty()).then_some(fields)
}

fn contains_update(content: &str) -> bool {
    content
        .split(|character: char| {
            !(character == '_' || character == '\'' || character.is_ascii_alphanumeric())
        })
        .any(|token| token == "with")
}

fn assigned_field_names(text: &str) -> BTreeSet<&str> {
    let mut fields = BTreeSet::new();
    for (equals, character) in text.char_indices() {
        if character != '=' {
            continue;
        }
        let before = text[..equals].trim_end();
        let start = before
            .char_indices()
            .rev()
            .find_map(|(index, character)| {
                (!(character == '_' || character == '\'' || character.is_ascii_alphanumeric()))
                    .then_some(index + character.len_utf8())
            })
            .unwrap_or(0);
        let field = &before[start..];
        if valid_identifier(field) {
            fields.insert(field);
        }
    }
    fields
}

fn update_base_identifier(content: &str) -> Option<String> {
    let trimmed = content.trim_start();
    let with = trimmed.find(" with ")?;
    let base = trimmed[..with].trim();
    valid_identifier(base).then(|| base.to_owned())
}

fn base_has_alias_annotation(compact_prefix: &str, base: &str, alias: &str) -> bool {
    compact_prefix.contains(&format!("{base}:{alias}"))
}

fn tuple_binding_has_alias(
    compact_prefix: &str,
    base: &str,
    alias: &str,
    tuple_aliases: &[NamedTupleAlias],
) -> bool {
    tuple_aliases.iter().any(|tuple_alias| {
        let needle = format!(":{}", tuple_alias.name);
        compact_prefix.rmatch_indices(&needle).any(|(colon, _)| {
            let before = compact_prefix[..colon].trim_end_matches(')');
            let Some(open) = before.rfind('(') else {
                return false;
            };
            let bindings = split_top_level(&before[open + 1..], ',');
            bindings.len() == tuple_alias.elements.len()
                && bindings
                    .iter()
                    .zip(&tuple_alias.elements)
                    .any(|(binding, element)| {
                        binding.trim_matches(|character| character == '(' || character == ')')
                            == base
                            && element == alias
                    })
        })
    })
}

fn alias_from_declaration(text: &str, provider_shard: usize) -> Option<AnonymousRecordAlias> {
    let name = alias_name(text)?;
    let (start, end) = anonymous_record_spans(text)
        .into_iter()
        .max_by_key(|(start, end)| end - start)?;
    let equals = text[..start].rfind('=')?;
    if !text[equals + 1..start].trim().is_empty() {
        return None;
    }
    let suffix = text[end..].trim();
    if !suffix.is_empty() && !suffix.starts_with("//") {
        return None;
    }
    let fields = record_shape(&text[start + 2..end - 2])?;
    Some(AnonymousRecordAlias {
        provider_shard,
        name,
        fields,
    })
}

fn nested_aliases_from_declaration(
    text: &str,
    provider_shard: usize,
) -> Vec<NestedAnonymousRecordAlias> {
    let Some(owner) = alias_name(text) else {
        return Vec::new();
    };
    let Some(header) = declaration_header(text) else {
        return Vec::new();
    };
    if !header.starts_with("type ") || !text.contains("{|") {
        return Vec::new();
    }
    let mut aliases = Vec::new();
    for (start, end) in all_anonymous_record_spans(text) {
        if text[end..].trim().is_empty() {
            continue;
        }
        let line_start = text[..start].rfind('\n').map_or(0, |index| index + 1);
        let line_end = text[end..]
            .find('\n')
            .map_or(text.len(), |index| end + index);
        let line = &text[line_start..line_end];
        let local_start = start - line_start;
        let Some(colon) = line[..local_start].rfind(':') else {
            continue;
        };
        let Some(field) = line[..colon]
            .split(|character: char| character.is_whitespace() || matches!(character, '{' | ';'))
            .rfind(|part| !part.is_empty())
        else {
            continue;
        };
        if !valid_identifier(field) {
            continue;
        }
        let Some(fields) = record_shape(&text[start + 2..end - 2]) else {
            continue;
        };
        aliases.push(NestedAnonymousRecordAlias {
            provider_shard,
            owner: owner.clone(),
            field: field.to_owned(),
            name: format!("SpiralSplitAnon_{owner}_{field}"),
            anonymous_type: text[start..end].to_owned(),
            fields,
        });
    }
    aliases
}

fn collect_nested_aliases(plan: &SplitPlan) -> Vec<NestedAnonymousRecordAlias> {
    let mut aliases = BTreeSet::new();
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            let Some(declaration) = plan.declarations.get(declaration.0) else {
                continue;
            };
            aliases.extend(nested_aliases_from_declaration(&declaration.text, shard.id));
        }
    }
    aliases.into_iter().collect()
}

fn normalized_anonymous_type(text: &str) -> String {
    text.chars()
        .filter(|character| !character.is_whitespace())
        .collect()
}

fn canonical_nested_aliases(
    aliases: &[NestedAnonymousRecordAlias],
) -> BTreeMap<(usize, String), NestedAnonymousRecordAlias> {
    let mut canonical_by_shape = BTreeMap::<String, NestedAnonymousRecordAlias>::new();
    for alias in aliases {
        canonical_by_shape
            .entry(normalized_anonymous_type(&alias.anonymous_type))
            .and_modify(|canonical| {
                if (alias.provider_shard, alias.name.as_str())
                    < (canonical.provider_shard, canonical.name.as_str())
                {
                    *canonical = alias.clone();
                }
            })
            .or_insert_with(|| alias.clone());
    }
    aliases
        .iter()
        .map(|alias| {
            let canonical = canonical_by_shape
                .get(&normalized_anonymous_type(&alias.anonymous_type))
                .expect("every nested alias shape has a canonical alias")
                .clone();
            ((alias.provider_shard, alias.name.clone()), canonical)
        })
        .collect()
}

fn rewrite_nested_alias_provider(
    text: &str,
    aliases: &[NestedAnonymousRecordAlias],
    canonical: &BTreeMap<(usize, String), NestedAnonymousRecordAlias>,
) -> String {
    let mut lines = text
        .split_inclusive('\n')
        .map(str::to_owned)
        .collect::<Vec<_>>();
    for alias in aliases {
        let canonical_alias = canonical
            .get(&(alias.provider_shard, alias.name.clone()))
            .expect("every nested alias has a canonical target");
        let field_type = if canonical_alias.provider_shard == alias.provider_shard
            && canonical_alias.name == alias.name
        {
            alias.name.clone()
        } else {
            format!(
                "spiral_compiler_Part{:04}.{}",
                canonical_alias.provider_shard, canonical_alias.name
            )
        };
        let field_needle = format!("{} :", alias.field);
        if let Some(line) = lines
            .iter_mut()
            .find(|line| line.contains(&field_needle) && line.contains(&alias.anonymous_type))
        {
            *line = line.replacen(&alias.anonymous_type, &field_type, 1);
        }
        if field_type != alias.name {
            continue;
        }
        let type_needle = format!("type {} =", alias.owner);
        let Some(owner_index) = lines
            .iter()
            .position(|line| line.trim_start().starts_with(&type_needle))
        else {
            continue;
        };
        if lines.iter().any(|line| {
            line.trim_start()
                .starts_with(&format!("type {} =", alias.name))
        }) {
            continue;
        }
        let mut insertion = owner_index;
        while insertion > 0 {
            let previous = lines[insertion - 1].trim_start();
            if previous.starts_with("///") || previous.starts_with("[<") {
                insertion -= 1;
            } else {
                break;
            }
        }
        let indentation = lines[owner_index]
            .chars()
            .take_while(|character| character.is_whitespace())
            .collect::<String>();
        lines.insert(
            insertion,
            format!(
                "{indentation}type {} = {}\n",
                alias.name, alias.anonymous_type
            ),
        );
    }
    lines.concat()
}

fn rewrite_nested_alias_providers(
    output_root: &Path,
    aliases: &[NestedAnonymousRecordAlias],
    canonical: &BTreeMap<(usize, String), NestedAnonymousRecordAlias>,
) -> Result<usize, String> {
    let mut by_provider = BTreeMap::<usize, Vec<NestedAnonymousRecordAlias>>::new();
    for alias in aliases {
        by_provider
            .entry(alias.provider_shard)
            .or_default()
            .push(alias.clone());
    }
    let mut files_changed = 0usize;
    for (provider, aliases) in by_provider {
        let path = output_root.join(format!("Part{provider:04}.fs"));
        let text = fs::read_to_string(&path)
            .map_err(|error| format!("read {}: {error}", path.display()))?;
        let rewritten = rewrite_nested_alias_provider(&text, &aliases, canonical);
        if rewritten != text {
            atomic_write(&path, &rewritten)?;
            files_changed += 1;
        }
    }
    Ok(files_changed)
}

#[must_use]
pub fn collect_aliases(plan: &SplitPlan) -> Vec<AnonymousRecordAlias> {
    let mut aliases = BTreeSet::new();
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            let Some(declaration) = plan.declarations.get(declaration.0) else {
                continue;
            };
            if let Some(alias) = alias_from_declaration(&declaration.text, shard.id) {
                aliases.insert(alias);
            }
        }
    }
    aliases.into_iter().collect()
}

#[must_use]
pub fn collect_tuple_aliases(plan: &SplitPlan) -> Vec<NamedTupleAlias> {
    let mut aliases = BTreeSet::new();
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            let Some(declaration) = plan.declarations.get(declaration.0) else {
                continue;
            };
            if let Some(alias) = named_tuple_alias(&declaration.text, shard.id) {
                aliases.insert(alias);
            }
        }
    }
    aliases.into_iter().collect()
}

fn dependency_closures(plan: &SplitPlan) -> BTreeMap<usize, BTreeSet<usize>> {
    let direct = plan
        .shards
        .iter()
        .map(|shard| (shard.id, shard.direct_dependencies.clone()))
        .collect::<BTreeMap<_, _>>();
    plan.shards
        .iter()
        .map(|shard| {
            let mut closure = BTreeSet::new();
            let mut pending = shard
                .direct_dependencies
                .iter()
                .copied()
                .collect::<Vec<_>>();
            while let Some(provider) = pending.pop() {
                if !closure.insert(provider) {
                    continue;
                }
                if let Some(dependencies) = direct.get(&provider) {
                    pending.extend(dependencies.iter().copied());
                }
            }
            (shard.id, closure)
        })
        .collect()
}

fn aliases_by_provider(
    aliases: &[AnonymousRecordAlias],
) -> BTreeMap<usize, Vec<AnonymousRecordAlias>> {
    let mut result = BTreeMap::<usize, Vec<AnonymousRecordAlias>>::new();
    for alias in aliases {
        result
            .entry(alias.provider_shard)
            .or_default()
            .push(alias.clone());
    }
    result
}

fn tuple_aliases_by_provider(aliases: &[NamedTupleAlias]) -> BTreeMap<usize, Vec<NamedTupleAlias>> {
    let mut result = BTreeMap::<usize, Vec<NamedTupleAlias>>::new();
    for alias in aliases {
        result
            .entry(alias.provider_shard)
            .or_default()
            .push(alias.clone());
    }
    result
}

fn line_number(text: &str, byte: usize) -> usize {
    text[..byte].bytes().filter(|byte| *byte == 10).count() + 1
}

fn annotate_alias_return_bridges(
    text: &str,
    consumer_shard: usize,
    candidates: &[AnonymousRecordAlias],
) -> (String, Vec<BridgeAnnotation>) {
    let mut output = String::with_capacity(text.len());
    let mut annotations = Vec::new();
    let mut candidates_by_name = BTreeMap::<&str, Vec<&AnonymousRecordAlias>>::new();
    for candidate in candidates {
        candidates_by_name
            .entry(candidate.name.as_str())
            .or_default()
            .push(candidate);
    }
    for (line_index, line) in text.split_inclusive('\n').enumerate() {
        let has_newline = line.ends_with('\n');
        let body = line.strip_suffix('\n').unwrap_or(line);
        let trimmed = body.trim_start();
        let indent = &body[..body.len() - trimmed.len()];
        let Some(equals) = trimmed.rfind(" = ") else {
            output.push_str(line);
            continue;
        };
        if !trimmed.starts_with("let ") {
            output.push_str(line);
            continue;
        }
        let signature = &trimmed[..equals];
        let expression = trimmed[equals + 3..].trim();
        if expression.is_empty() || expression.starts_with("{|") || expression.contains("//") {
            output.push_str(line);
            continue;
        }
        let compact_signature = signature
            .chars()
            .filter(|character| !character.is_whitespace())
            .collect::<String>();
        let Some((_, return_type)) = compact_signature.rsplit_once(':') else {
            output.push_str(line);
            continue;
        };
        let Some(matching) = candidates_by_name.get(return_type) else {
            output.push_str(line);
            continue;
        };
        if matching.len() != 1 {
            output.push_str(line);
            continue;
        }
        let alias = matching[0];
        let temporary = "__spiral_split_bridge_value";
        let fields = alias
            .fields
            .iter()
            .map(|field| format!("{field} = {temporary}.{field}"))
            .collect::<Vec<_>>()
            .join("; ");
        output.push_str(indent);
        output.push_str(signature);
        output.push_str(" =\n");
        output.push_str(indent);
        output.push_str("    let ");
        output.push_str(temporary);
        output.push_str(" = ");
        output.push_str(expression);
        output.push('\n');
        output.push_str(indent);
        output.push_str("    ({| ");
        output.push_str(&fields);
        output.push_str(" |} : ");
        output.push_str(&alias.name);
        output.push(')');
        if has_newline {
            output.push('\n');
        }
        annotations.push(BridgeAnnotation {
            consumer_shard,
            provider_shard: alias.provider_shard,
            alias: alias.name.clone(),
            fields: alias.fields.clone(),
            line: line_index + 1,
        });
    }
    (output, annotations)
}

fn annotate_source(
    text: &str,
    consumer_shard: usize,
    candidates: &[AnonymousRecordAlias],
    tuple_aliases: &[NamedTupleAlias],
) -> (String, usize, Vec<BridgeAnnotation>, Vec<BridgeAmbiguity>) {
    let (return_rewritten, mut annotations) =
        annotate_alias_return_bridges(text, consumer_shard, candidates);
    let text = return_rewritten.as_str();
    let mut candidates_by_shape = BTreeMap::<&BTreeSet<String>, Vec<&AnonymousRecordAlias>>::new();
    for candidate in candidates {
        candidates_by_shape
            .entry(&candidate.fields)
            .or_default()
            .push(candidate);
    }
    let identifiers = text
        .split(|character: char| {
            !(character == '_' || character == '\'' || character.is_ascii_alphanumeric())
        })
        .filter(|token| !token.is_empty())
        .collect::<BTreeSet<_>>();
    let tuple_element_aliases = tuple_aliases
        .iter()
        .filter(|tuple_alias| identifiers.contains(tuple_alias.name.as_str()))
        .flat_map(|tuple_alias| tuple_alias.elements.iter().map(String::as_str))
        .collect::<BTreeSet<_>>();
    let update_candidates = candidates
        .iter()
        .filter(|candidate| {
            identifiers.contains(candidate.name.as_str())
                || tuple_element_aliases.contains(candidate.name.as_str())
        })
        .collect::<Vec<_>>();
    let mut replacements = Vec::<(usize, usize, String)>::new();
    let mut ambiguities = Vec::new();
    let mut literals_seen = 0usize;
    let assigned_fields = assigned_field_names(text);
    let nested_alias_names = candidates
        .iter()
        .filter(|candidate| {
            candidate.name.starts_with("SpiralSplitAnon_")
                && candidate
                    .fields
                    .iter()
                    .all(|field| assigned_fields.contains(field.as_str()))
        })
        .map(|candidate| candidate.name.as_str())
        .collect::<BTreeSet<_>>();
    let has_nested_alias = !nested_alias_names.is_empty();
    let outer_spans = anonymous_record_spans(text);
    let outer_span_set = outer_spans.iter().copied().collect::<BTreeSet<_>>();
    let mut spans = outer_spans;
    if has_nested_alias {
        spans.extend(innermost_anonymous_record_spans(text));
        spans.sort_unstable();
        spans.dedup();
    }
    spans.sort_by_key(|(start, end)| end - start);
    let compact_prefix_index = CompactPrefixIndex::new(text, spans.iter().map(|(start, _)| *start));
    for (start, end) in spans {
        if replacements
            .iter()
            .any(|(existing_start, existing_end, _)| start < *existing_end && *existing_start < end)
        {
            continue;
        }
        let content = &text[start + 2..end - 2];
        let nested_span = !outer_span_set.contains(&(start, end));
        if nested_span && contains_update(content) {
            continue;
        }
        if contains_update(content) {
            literals_seen += 1;
            let Some(base) = update_base_identifier(content) else {
                continue;
            };
            let compact_prefix = compact_prefix_index
                .prefix(start)
                .expect("every scanned span start is indexed");
            let matching = update_candidates
                .iter()
                .filter(|alias| {
                    base_has_alias_annotation(compact_prefix, &base, &alias.name)
                        || tuple_binding_has_alias(
                            compact_prefix,
                            &base,
                            &alias.name,
                            tuple_aliases,
                        )
                })
                .copied()
                .collect::<Vec<_>>();
            if matching.len() == 1 {
                let alias = matching[0];
                let suffix = text[end..].trim_start();
                if !suffix.starts_with(':') {
                    replacements.push((
                        start,
                        end,
                        format!("({} : {})", &text[start..end], alias.name),
                    ));
                    annotations.push(BridgeAnnotation {
                        consumer_shard,
                        provider_shard: alias.provider_shard,
                        alias: alias.name.clone(),
                        fields: alias.fields.clone(),
                        line: line_number(text, start),
                    });
                }
            } else if matching.len() > 1 {
                ambiguities.push(BridgeAmbiguity {
                    consumer_shard,
                    aliases: matching.iter().map(|alias| alias.name.clone()).collect(),
                    fields: BTreeSet::new(),
                    line: line_number(text, start),
                });
            }
            continue;
        }
        let Some(fields) = record_shape(content) else {
            continue;
        };
        literals_seen += 1;
        let mut matching = candidates_by_shape
            .get(&fields)
            .cloned()
            .unwrap_or_default();
        if nested_span {
            matching.retain(|alias| nested_alias_names.contains(alias.name.as_str()));
        }
        if matching.len() == 1 {
            let alias = matching[0];
            let suffix = text[end..].trim_start();
            if suffix.starts_with(':') {
                continue;
            }
            replacements.push((
                start,
                end,
                format!("({} : {})", &text[start..end], alias.name),
            ));
            annotations.push(BridgeAnnotation {
                consumer_shard,
                provider_shard: alias.provider_shard,
                alias: alias.name.clone(),
                fields,
                line: line_number(text, start),
            });
        } else if matching.len() > 1 {
            ambiguities.push(BridgeAmbiguity {
                consumer_shard,
                aliases: matching.iter().map(|alias| alias.name.clone()).collect(),
                fields,
                line: line_number(text, start),
            });
        }
    }
    replacements.sort_by_key(|(start, _, _)| *start);
    let mut output = text.to_owned();
    for (start, end, replacement) in replacements.into_iter().rev() {
        output.replace_range(start..end, &replacement);
    }
    (output, literals_seen, annotations, ambiguities)
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let temporary = path.with_extension("bridge.tmp");
    fs::write(&temporary, text)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

pub fn rewrite_anonymous_record_bridges(
    plan: &SplitPlan,
    output_root: &Path,
) -> Result<BridgeReport, String> {
    let (wrapped_files_changed, identity_aliases) =
        wrapped_anonymous_identity::canonicalize_wrapped_anonymous_types(plan, output_root)?;
    let mut aliases = collect_aliases(plan);
    aliases.extend(identity_aliases);
    let nested_aliases = collect_nested_aliases(plan);
    let canonical_nested = canonical_nested_aliases(&nested_aliases);
    let provider_files_changed =
        rewrite_nested_alias_providers(output_root, &nested_aliases, &canonical_nested)?;
    let canonical_aliases = canonical_nested.values().cloned().collect::<BTreeSet<_>>();
    aliases.extend(
        canonical_aliases
            .into_iter()
            .map(|alias| AnonymousRecordAlias {
                provider_shard: alias.provider_shard,
                name: alias.name,
                fields: alias.fields,
            }),
    );
    let tuple_aliases = collect_tuple_aliases(plan);
    let by_provider = aliases_by_provider(&aliases);
    let tuple_by_provider = tuple_aliases_by_provider(&tuple_aliases);
    let dependency_closures = dependency_closures(plan);
    let mut report = BridgeReport {
        aliases: aliases.len(),
        files_changed: wrapped_files_changed + provider_files_changed,
        ..BridgeReport::default()
    };
    let shard_reports = plan
        .shards
        .par_iter()
        .map(|shard| -> Result<BridgeReport, String> {
            let path = output_root.join(format!("Part{:04}.fs", shard.id));
            let text = fs::read_to_string(&path)
                .map_err(|error| format!("read {}: {error}", path.display()))?;
            let mut visible_providers = shard.direct_dependencies.clone();
            for line in text.lines() {
                let Some(rest) = line.trim().strip_prefix("open spiral_compiler_Part") else {
                    continue;
                };
                let digits = rest
                    .chars()
                    .take_while(char::is_ascii_digit)
                    .collect::<String>();
                if let Ok(provider) = digits.parse::<usize>() {
                    visible_providers.insert(provider);
                }
            }
            let mut providers = dependency_closures
                .get(&shard.id)
                .cloned()
                .unwrap_or_default();
            providers.extend(visible_providers.iter().copied());
            for provider in &visible_providers {
                if let Some(transitive) = dependency_closures.get(provider) {
                    providers.extend(transitive.iter().copied());
                }
            }
            let mut candidates = BTreeSet::new();
            let mut tuple_candidates = BTreeSet::new();
            for provider in providers {
                if let Some(values) = by_provider.get(&provider) {
                    candidates.extend(values.iter().map(|alias| {
                        if visible_providers.contains(&provider) {
                            alias.clone()
                        } else {
                            AnonymousRecordAlias {
                                provider_shard: alias.provider_shard,
                                name: format!("spiral_compiler_Part{provider:04}.{}", alias.name),
                                fields: alias.fields.clone(),
                            }
                        }
                    }));
                }
                if visible_providers.contains(&provider)
                    && let Some(values) = tuple_by_provider.get(&provider)
                {
                    tuple_candidates.extend(values.iter().cloned());
                }
            }
            if candidates.is_empty() {
                return Ok(BridgeReport::default());
            }
            let (rewritten, seen, annotations, ambiguities) = annotate_source(
                &text,
                shard.id,
                &candidates.into_iter().collect::<Vec<_>>(),
                &tuple_candidates.into_iter().collect::<Vec<_>>(),
            );
            let changed = usize::from(rewritten != text);
            if changed == 1 {
                atomic_write(&path, &rewritten)?;
            }
            Ok(BridgeReport {
                files_scanned: 1,
                files_changed: changed,
                literals_seen: seen,
                annotations,
                ambiguities,
                ..BridgeReport::default()
            })
        })
        .collect::<Result<Vec<_>, _>>()?;
    for shard_report in shard_reports {
        report.files_scanned += shard_report.files_scanned;
        report.files_changed += shard_report.files_changed;
        report.literals_seen += shard_report.literals_seen;
        report.annotations.extend(shard_report.annotations);
        report.ambiguities.extend(shard_report.ambiguities);
    }
    Ok(report)
}

#[must_use]
pub fn render_bridge_tsv(report: &BridgeReport) -> String {
    let mut output = String::from(
        "status consumer_shard provider_shard alias fields line note
",
    );
    for annotation in &report.annotations {
        output.push_str(&format!(
            "annotated {} {} {} {} {} external-alias-type-annotation
",
            annotation.consumer_shard,
            annotation.provider_shard,
            annotation.alias,
            annotation
                .fields
                .iter()
                .cloned()
                .collect::<Vec<_>>()
                .join(","),
            annotation.line
        ));
    }
    for ambiguity in &report.ambiguities {
        output.push_str(&format!(
            "ambiguous {} - {} {} {} multiple-direct-aliases
",
            ambiguity.consumer_shard,
            ambiguity.aliases.join(","),
            ambiguity
                .fields
                .iter()
                .cloned()
                .collect::<Vec<_>>()
                .join(","),
            ambiguity.line
        ));
    }
    output.push_str(&format!(
        "summary - - - - - aliases={} files_scanned={} files_changed={} literals_seen={} annotations={} ambiguities={}
",
        report.aliases,
        report.files_scanned,
        report.files_changed,
        report.literals_seen,
        report.annotations.len(),
        report.ambiguities.len()
    ));
    output
}

#[cfg(test)]
include!("anonymous_record_bridge_nested_tests.rs");

#[cfg(test)]
#[cfg(test)]
include!("anonymous_record_bridge_tests.rs");
