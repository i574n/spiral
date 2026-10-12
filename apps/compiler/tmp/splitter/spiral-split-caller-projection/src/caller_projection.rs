use spiral_split_call_contract::{CallerContractIndex, CallerParameterType};
use spiral_split_model::{DeclarationId, SplitPlan};
use spiral_split_record_owner::RecordProjectionIndex;
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
enum ParameterContract {
    Inferred(String),
    Other,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct ProjectedArgument {
    base: String,
    field: String,
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn identifier_suffix(value: &str) -> bool {
    let mut chars = value.chars();
    chars.next().is_some_and(identifier_start) && chars.all(identifier_continue)
}

fn binding_body(mut line: &str) -> Option<&str> {
    line = line.trim_start();
    line = line
        .strip_prefix("let ")
        .or_else(|| line.strip_prefix("and "))?;
    loop {
        let before = line;
        for modifier in [
            "rec ",
            "private ",
            "internal ",
            "public ",
            "inline ",
            "mutable ",
        ] {
            if let Some(rest) = line.strip_prefix(modifier) {
                line = rest;
                break;
            }
        }
        if line == before {
            return Some(line);
        }
    }
}

fn binding_defines_symbol(line: &str, symbol: &str) -> bool {
    let Some(body) = binding_body(line) else {
        return false;
    };
    body.strip_prefix(symbol).is_some_and(|rest| {
        rest.is_empty()
            || rest.starts_with(|character: char| {
                character.is_whitespace() || matches!(character, '(' | ':' | '=')
            })
    })
}

fn binding_header(text: &str, symbol: &str) -> Option<String> {
    if !identifier_suffix(symbol) {
        return None;
    }
    let lines = text.lines().collect::<Vec<_>>();
    let start = lines
        .iter()
        .position(|line| binding_defines_symbol(line, symbol))?;
    let mut header = String::new();
    for line in &lines[start..] {
        if !header.is_empty() {
            header.push(' ');
        }
        header.push_str(line.trim());
        if line.contains('=') {
            break;
        }
    }
    Some(header)
}

fn matching_paren(text: &str, open: usize) -> Option<usize> {
    let mut depth = 0usize;
    for (offset, character) in text[open..].char_indices() {
        match character {
            '(' => depth += 1,
            ')' => {
                depth = depth.saturating_sub(1);
                if depth == 0 {
                    return Some(open + offset);
                }
            }
            _ => {}
        }
    }
    None
}

fn parse_parameters(after_name: &str) -> Vec<ParameterContract> {
    let bytes = after_name.as_bytes();
    let mut cursor = 0usize;
    let mut result = Vec::new();
    while cursor < bytes.len() {
        while cursor < bytes.len() && bytes[cursor].is_ascii_whitespace() {
            cursor += 1;
        }
        if cursor >= bytes.len() || matches!(bytes[cursor], b'=' | b':') {
            break;
        }
        if bytes[cursor] == b'(' {
            let Some(close) = matching_paren(after_name, cursor) else {
                result.push(ParameterContract::Other);
                break;
            };
            result.push(ParameterContract::Other);
            cursor = close + 1;
            continue;
        }
        let Some(first) = after_name[cursor..].chars().next() else {
            break;
        };
        if !identifier_start(first) {
            result.push(ParameterContract::Other);
            cursor += first.len_utf8();
            continue;
        }
        let start = cursor;
        cursor += first.len_utf8();
        while cursor < bytes.len() {
            let Some(character) = after_name[cursor..].chars().next() else {
                break;
            };
            if !identifier_continue(character) {
                break;
            }
            cursor += character.len_utf8();
        }
        result.push(ParameterContract::Inferred(
            after_name[start..cursor].to_owned(),
        ));
    }
    result
}

fn binding_parameters(text: &str, symbol: &str) -> Option<Vec<ParameterContract>> {
    let header = binding_header(text, symbol)?;
    let before_equals = header
        .split_once('=')
        .map_or(header.as_str(), |(left, _)| left);
    let body = binding_body(before_equals)?;
    let after_name = body.strip_prefix(symbol)?;
    Some(parse_parameters(after_name))
}

fn typed_parenthesized_parameter(body: &str) -> Option<(String, String)> {
    let (left, right) = body.split_once(':')?;
    let name = left
        .split_whitespace()
        .last()
        .filter(|candidate| identifier_suffix(candidate))?;
    let type_text = right.trim();
    if type_text.is_empty() {
        return None;
    }
    Some((name.to_owned(), type_text.to_owned()))
}

fn explicit_variable_types(text: &str) -> BTreeMap<String, BTreeSet<String>> {
    let lines = text.lines().collect::<Vec<_>>();
    let mut result = BTreeMap::<String, BTreeSet<String>>::new();
    for (index, line) in lines.iter().enumerate() {
        let Some(body) = binding_body(line) else {
            continue;
        };
        let symbol = body
            .chars()
            .take_while(|character| identifier_continue(*character))
            .collect::<String>();
        if !identifier_suffix(&symbol) {
            continue;
        }
        let mut header = line.trim().to_owned();
        if !line.contains('=') {
            for continuation in &lines[index + 1..] {
                header.push(' ');
                header.push_str(continuation.trim());
                if continuation.contains('=') {
                    break;
                }
            }
        }
        let before_equals = header
            .split_once('=')
            .map_or(header.as_str(), |(left, _)| left);
        let Some(header_body) = binding_body(before_equals) else {
            continue;
        };
        let Some(after_name) = header_body.strip_prefix(&symbol) else {
            continue;
        };
        let bytes = after_name.as_bytes();
        let mut cursor = 0usize;
        while cursor < bytes.len() {
            while cursor < bytes.len() && bytes[cursor].is_ascii_whitespace() {
                cursor += 1;
            }
            if cursor >= bytes.len() || matches!(bytes[cursor], b'=' | b':') {
                break;
            }
            if bytes[cursor] != b'(' {
                let Some(character) = after_name[cursor..].chars().next() else {
                    break;
                };
                cursor += character.len_utf8();
                continue;
            }
            let Some(close) = matching_paren(after_name, cursor) else {
                break;
            };
            if let Some((name, type_text)) =
                typed_parenthesized_parameter(&after_name[cursor + 1..close])
            {
                result.entry(name).or_default().insert(type_text);
            }
            cursor = close + 1;
        }
    }
    result
}

fn parse_identifier(text: &str, cursor: &mut usize) -> Option<String> {
    let first = text[*cursor..].chars().next()?;
    if !identifier_start(first) {
        return None;
    }
    let start = *cursor;
    *cursor += first.len_utf8();
    while *cursor < text.len() {
        let Some(character) = text[*cursor..].chars().next() else {
            break;
        };
        if !identifier_continue(character) {
            break;
        }
        *cursor += character.len_utf8();
    }
    Some(text[start..*cursor].to_owned())
}

fn projected_arguments_after_call(
    source: &str,
    symbol: &str,
) -> Vec<Vec<Option<ProjectedArgument>>> {
    let mut result = Vec::new();
    let mut remaining = source;
    while let Some(index) = remaining.find(symbol) {
        let before = &remaining[..index];
        let after_symbol = &remaining[index + symbol.len()..];
        let left_boundary = before
            .chars()
            .next_back()
            .is_none_or(|character| !identifier_continue(character));
        let right_boundary = after_symbol
            .chars()
            .next()
            .is_none_or(|character| !identifier_continue(character));
        if left_boundary && right_boundary {
            let line_tail = after_symbol.lines().next().unwrap_or(after_symbol);
            let mut cursor = 0usize;
            let mut arguments = Vec::new();
            while cursor < line_tail.len() {
                while cursor < line_tail.len() && line_tail.as_bytes()[cursor].is_ascii_whitespace()
                {
                    cursor += 1;
                }
                if cursor >= line_tail.len() {
                    break;
                }
                let start = cursor;
                let Some(base) = parse_identifier(line_tail, &mut cursor) else {
                    break;
                };
                let mut projection = None;
                if cursor < line_tail.len() && line_tail.as_bytes()[cursor] == b'.' {
                    cursor += 1;
                    let Some(field) = parse_identifier(line_tail, &mut cursor) else {
                        break;
                    };
                    let mut chained = false;
                    while cursor < line_tail.len() && line_tail.as_bytes()[cursor] == b'.' {
                        chained = true;
                        cursor += 1;
                        if parse_identifier(line_tail, &mut cursor).is_none() {
                            break;
                        }
                    }
                    if !chained {
                        projection = Some(ProjectedArgument { base, field });
                    }
                }
                arguments.push(projection);
                if cursor == start {
                    break;
                }
            }
            if !arguments.is_empty() {
                result.push(arguments);
            }
        }
        remaining = after_symbol;
    }
    result
}

fn declaration_shards(plan: &SplitPlan) -> Vec<usize> {
    let mut result = vec![0usize; plan.declarations.len()];
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            result[declaration.0] = shard.id;
        }
    }
    result
}

fn base_type_symbol(type_text: &str) -> String {
    let base = type_text.split('<').next().unwrap_or(type_text).trim();
    base.rsplit('.').next().unwrap_or(base).to_owned()
}

fn complete_projection_coverage(total: usize, supported: usize) -> bool {
    total > 0 && total == supported
}

#[must_use]
pub fn analyze_caller_projection_contracts(
    plan: &SplitPlan,
    type_providers: &BTreeMap<String, usize>,
) -> CallerContractIndex {
    let projection_index = RecordProjectionIndex::new(plan);
    let declaration_shards = declaration_shards(plan);
    let mut evidence =
        BTreeMap::<(DeclarationId, String, usize, String), BTreeSet<(String, String)>>::new();
    let mut total_calls = BTreeMap::<(DeclarationId, String, usize, String), usize>::new();
    let mut supported_calls = BTreeMap::<(DeclarationId, String, usize, String), usize>::new();

    for consumer in &plan.declarations {
        let explicit = explicit_variable_types(&consumer.text);
        let mut seen = BTreeSet::<(DeclarationId, String)>::new();
        for witness in &consumer.witnesses {
            let symbol = witness
                .symbol
                .rsplit_once('.')
                .map_or(witness.symbol.as_str(), |(_, suffix)| suffix);
            if !identifier_suffix(symbol) || !seen.insert((witness.provider, symbol.to_owned())) {
                continue;
            }
            let provider = &plan.declarations[witness.provider.0];
            let Some(parameters) = binding_parameters(&provider.text, symbol) else {
                continue;
            };
            for arguments in projected_arguments_after_call(&consumer.text, symbol) {
                for (parameter_index, parameter) in parameters.iter().enumerate() {
                    let ParameterContract::Inferred(parameter_name) = parameter else {
                        continue;
                    };
                    let key = (
                        witness.provider,
                        symbol.to_owned(),
                        parameter_index,
                        parameter_name.clone(),
                    );
                    *total_calls.entry(key.clone()).or_default() += 1;
                    let Some(Some(argument)) = arguments.get(parameter_index) else {
                        continue;
                    };
                    let Some(parent_types) = explicit.get(&argument.base) else {
                        continue;
                    };
                    if parent_types.len() != 1 {
                        continue;
                    }
                    let parent_type = parent_types.iter().next().expect("one parent type");
                    let Some(projected) = projection_index.projected_field_type(
                        plan,
                        consumer.id,
                        parent_type,
                        &argument.field,
                    ) else {
                        continue;
                    };
                    *supported_calls.entry(key.clone()).or_default() += 1;
                    evidence
                        .entry(key)
                        .or_default()
                        .insert((projected.type_text, projected.type_symbol));
                }
            }
        }
    }

    let mut parameter_types = BTreeMap::<DeclarationId, Vec<CallerParameterType>>::new();
    let mut by_shard = BTreeMap::<usize, Vec<(usize, usize, String, usize)>>::new();
    for (key, types) in evidence {
        let total = total_calls.get(&key).copied().unwrap_or(0);
        let supported = supported_calls.get(&key).copied().unwrap_or(0);
        if !complete_projection_coverage(total, supported) || types.len() != 1 {
            continue;
        }
        let (provider, symbol, parameter_index, parameter_name) = key;
        let (type_text, type_symbol) = types.into_iter().next().expect("one projected type");
        let provider_shard = declaration_shards[provider.0];
        let Some(type_provider) = type_providers
            .get(&type_symbol)
            .copied()
            .or_else(|| type_providers.get(&base_type_symbol(&type_text)).copied())
        else {
            continue;
        };
        if type_provider != provider_shard
            && !plan.shards[provider_shard]
                .compile_dependencies
                .contains(&type_provider)
        {
            continue;
        }
        parameter_types
            .entry(provider)
            .or_default()
            .push(CallerParameterType {
                type_arguments: 0,
                symbol: symbol.clone(),
                parameter_index,
                parameter_name,
                type_symbol: type_text,
            });
        if type_provider != provider_shard {
            by_shard.entry(provider_shard).or_default().push((
                provider.0,
                parameter_index,
                symbol,
                type_provider,
            ));
        }
    }
    for rows in parameter_types.values_mut() {
        rows.sort();
        rows.dedup();
    }
    let type_providers_by_shard = by_shard
        .into_iter()
        .map(|(shard, mut rows)| {
            rows.sort();
            let mut seen = BTreeSet::new();
            let providers = rows
                .into_iter()
                .filter_map(|(_, _, _, provider)| seen.insert(provider).then_some(provider))
                .collect();
            (shard, providers)
        })
        .collect();
    CallerContractIndex {
        parameter_types,
        type_providers_by_shard,
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn call_parser_preserves_projected_argument_position() {
        assert_eq!(
            projected_arguments_after_call(
                "let x = helper identity nowMs state.credentialLedger",
                "helper"
            ),
            vec![vec![
                None,
                None,
                Some(ProjectedArgument {
                    base: "state".to_owned(),
                    field: "credentialLedger".to_owned(),
                }),
            ]]
        );
    }

    #[test]
    fn multi_hop_projection_is_fail_closed_but_keeps_argument_position() {
        assert_eq!(
            projected_arguments_after_call(
                "let x = helper evidence.frontier.retired state.credentialLedger",
                "helper"
            ),
            vec![vec![
                None,
                Some(ProjectedArgument {
                    base: "state".to_owned(),
                    field: "credentialLedger".to_owned(),
                }),
            ]]
        );
    }

    #[test]
    fn projection_contract_requires_complete_callsite_coverage() {
        assert!(complete_projection_coverage(1, 1));
        assert!(complete_projection_coverage(3, 3));
        assert!(!complete_projection_coverage(0, 0));
        assert!(!complete_projection_coverage(3, 1));
    }

    #[test]
    fn explicit_parent_type_must_be_unique() {
        let source = r#"let first (state : FirstState) = state
let second (state : SecondState) = state"#;
        assert_eq!(
            explicit_variable_types(source)["state"],
            BTreeSet::from(["FirstState".to_owned(), "SecondState".to_owned()])
        );
    }

    #[test]
    fn provider_contract_keeps_only_untyped_parameter_names() {
        assert_eq!(
            binding_parameters(
                "let helper (identity : Identity) nowMs current = current",
                "helper"
            ),
            Some(vec![
                ParameterContract::Other,
                ParameterContract::Inferred("nowMs".to_owned()),
                ParameterContract::Inferred("current".to_owned()),
            ])
        );
    }
}
