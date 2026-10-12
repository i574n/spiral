use spiral_split_capture_parameter::CaptureParameter;
use spiral_split_pattern_contract::BoundVariableTypes;
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ParameterContract {
    Explicit { name: String, type_symbol: String },
    Inferred { name: String },
    Pattern,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BindingContract {
    pub parameters: Vec<ParameterContract>,
}
fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

pub fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

pub fn identifier_suffix(value: &str) -> bool {
    let mut chars = value.chars();
    chars.next().is_some_and(identifier_start) && chars.all(identifier_continue)
}

pub fn binding_body(mut line: &str) -> Option<&str> {
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

fn typed_parenthesized_parameter(body: &str) -> Option<(String, String)> {
    let (left, right) = body.split_once(':')?;
    let name = left
        .split_whitespace()
        .last()
        .filter(|candidate| identifier_suffix(candidate))?;
    let type_path = right
        .trim_start()
        .chars()
        .take_while(|character| *character == '.' || identifier_continue(*character))
        .collect::<String>();
    let type_symbol = type_path.rsplit('.').next().unwrap_or_default();
    identifier_suffix(type_symbol).then(|| (name.to_owned(), type_symbol.to_owned()))
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
                result.push(ParameterContract::Pattern);
                break;
            };
            let body = &after_name[cursor + 1..close];
            result.push(
                typed_parenthesized_parameter(body)
                    .map_or(ParameterContract::Pattern, |(name, type_symbol)| {
                        ParameterContract::Explicit { name, type_symbol }
                    }),
            );
            cursor = close + 1;
            continue;
        }
        let start = cursor;
        let Some(first) = after_name[cursor..].chars().next() else {
            break;
        };
        if !identifier_start(first) {
            result.push(ParameterContract::Pattern);
            cursor += first.len_utf8();
            continue;
        }
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
        result.push(ParameterContract::Inferred {
            name: after_name[start..cursor].to_owned(),
        });
    }
    result
}

pub fn binding_contract(text: &str, symbol: &str) -> Option<BindingContract> {
    contract_from_header(&binding_header(text, symbol)?, symbol)
}

fn contract_from_header(header: &str, symbol: &str) -> Option<BindingContract> {
    let before_equals = header.split_once('=').map_or(header, |(left, _)| left);
    let body = binding_body(before_equals)?;
    let after_name = body.strip_prefix(symbol)?;
    Some(BindingContract {
        parameters: parse_parameters(after_name),
    })
}

/// The first defining line of every binding in one text, so contracts for many symbols of the same
/// declaration cost one pass instead of a full rescan each (`binding_contract` rescans the whole text,
/// which made the 1.7 MB `peval` declaration quadratic).
pub struct BindingIndex<'a> {
    lines: Vec<&'a str>,
    first_definition: BTreeMap<&'a str, usize>,
}

impl<'a> BindingIndex<'a> {
    #[must_use]
    pub fn new(text: &'a str) -> Self {
        let lines = text.lines().collect::<Vec<_>>();
        let mut first_definition = BTreeMap::new();
        for (index, line) in lines.iter().enumerate() {
            let Some(body) = binding_body(line) else {
                continue;
            };
            let end = body
                .char_indices()
                .find(|(_, character)| !identifier_continue(*character))
                .map_or(body.len(), |(offset, _)| offset);
            let symbol = &body[..end];
            // The same acceptance rule as `binding_defines_symbol`.
            if identifier_suffix(symbol) && binding_defines_symbol(line, symbol) {
                first_definition.entry(symbol).or_insert(index);
            }
        }
        Self { lines, first_definition }
    }

    /// Equal to `binding_contract(text, symbol)` for the indexed text.
    #[must_use]
    pub fn contract(&self, symbol: &str) -> Option<BindingContract> {
        let start = *self.first_definition.get(symbol)?;
        let mut header = String::new();
        for line in &self.lines[start..] {
            if !header.is_empty() {
                header.push(' ');
            }
            header.push_str(line.trim());
            if line.contains('=') {
                break;
            }
        }
        contract_from_header(&header, symbol)
    }
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
        for parameter in parse_parameters(after_name) {
            if let ParameterContract::Explicit { name, type_symbol } = parameter {
                result.entry(name).or_default().insert(type_symbol);
            }
        }
    }
    result
}

fn caller_binding_group_prefix(text: &str, call_offset: usize) -> &str {
    let prefix = &text[..call_offset];
    let lines = prefix.split_inclusive('\n').collect::<Vec<_>>();
    let Some(last) = lines.last() else {
        return prefix;
    };
    let last_line = last.trim_end_matches('\n');
    let call_indent = last_line.len() - last_line.trim_start().len();
    let mut binding_index = None;
    for index in (0..lines.len()).rev() {
        let line = lines[index].trim_end_matches('\n');
        if binding_body(line).is_none() {
            continue;
        }
        let indent = line.len() - line.trim_start().len();
        let same_line = index + 1 == lines.len();
        if (same_line && indent <= call_indent) || indent < call_indent {
            binding_index = Some(index);
            break;
        }
    }
    let Some(binding_index) = binding_index else {
        return prefix;
    };
    let binding_line = lines[binding_index].trim_end_matches('\n');
    let binding_indent = binding_line.len() - binding_line.trim_start().len();
    let mut group_start = binding_index;
    if binding_line.trim_start().starts_with("and ") {
        let mut cursor = binding_index;
        while cursor > 0 {
            cursor -= 1;
            let previous = lines[cursor].trim_end_matches('\n');
            let trimmed = previous.trim_start();
            if trimmed.is_empty() || trimmed.starts_with("//") {
                continue;
            }
            let indent = previous.len() - trimmed.len();
            if indent > binding_indent {
                continue;
            }
            if indent < binding_indent {
                break;
            }
            if trimmed.starts_with("and ") {
                group_start = cursor;
                continue;
            }
            if trimmed.starts_with("let rec ") {
                group_start = cursor;
            }
            break;
        }
    }
    let start = lines[..group_start]
        .iter()
        .map(|line| line.len())
        .sum::<usize>();
    &text[start..call_offset]
}

fn ancestor_explicit_variable_types(
    text: &str,
    call_offset: usize,
) -> BTreeMap<String, BTreeSet<String>> {
    let prefix = &text[..call_offset];
    let lines = prefix.lines().collect::<Vec<_>>();
    let Some(last) = lines.last() else {
        return BTreeMap::new();
    };
    let mut threshold = last.len() - last.trim_start().len() + 1;
    let mut result = BTreeMap::<String, BTreeSet<String>>::new();
    for line in lines.iter().rev() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || binding_body(line).is_none() {
            continue;
        }
        let indent = line.len() - trimmed.len();
        if indent >= threshold {
            continue;
        }
        for (name, types) in explicit_variable_types(line) {
            result.entry(name).or_default().extend(types);
        }
        threshold = indent;
    }
    result
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SimpleCallSite {
    pub offset: usize,
    pub arguments: Vec<Option<String>>,
}

fn skip_parenthesized_argument(text: &str, open: usize) -> Option<usize> {
    let bytes = text.as_bytes();
    if bytes.get(open) != Some(&b'(') {
        return None;
    }
    let mut depth = 0usize;
    let mut cursor = open;
    while cursor < bytes.len() {
        match bytes[cursor] {
            b'(' => depth += 1,
            b')' => {
                depth = depth.checked_sub(1)?;
                if depth == 0 {
                    return Some(cursor + 1);
                }
            }
            _ => {}
        }
        cursor += 1;
    }
    None
}

pub fn simple_arguments_after_call(source: &str, symbol: &str) -> Vec<SimpleCallSite> {
    let mut result = Vec::new();
    let mut search_from = 0usize;
    while let Some(relative) = source[search_from..].find(symbol) {
        let index = search_from + relative;
        let before = &source[..index];
        let after_symbol = &source[index + symbol.len()..];
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
            let bytes = line_tail.as_bytes();
            let mut arguments = Vec::new();
            while cursor < bytes.len() {
                while cursor < bytes.len() && bytes[cursor].is_ascii_whitespace() {
                    cursor += 1;
                }
                if cursor >= bytes.len() {
                    break;
                }
                if bytes[cursor] == b'(' {
                    let Some(next) = skip_parenthesized_argument(line_tail, cursor) else {
                        break;
                    };
                    arguments.push(None);
                    cursor = next;
                    continue;
                }
                let Some(first) = line_tail[cursor..].chars().next() else {
                    break;
                };
                if !identifier_start(first) {
                    break;
                }
                let start = cursor;
                cursor += first.len_utf8();
                while cursor < bytes.len() {
                    let Some(character) = line_tail[cursor..].chars().next() else {
                        break;
                    };
                    if !identifier_continue(character) {
                        break;
                    }
                    cursor += character.len_utf8();
                }
                let argument = line_tail[start..cursor].to_owned();
                let projected = cursor < bytes.len() && bytes[cursor] == b'.';
                while cursor < bytes.len() && bytes[cursor] == b'.' {
                    cursor += 1;
                    let projection_start = cursor;
                    while cursor < bytes.len() {
                        let Some(character) = line_tail[cursor..].chars().next() else {
                            break;
                        };
                        if !identifier_continue(character) {
                            break;
                        }
                        cursor += character.len_utf8();
                    }
                    if projection_start == cursor {
                        break;
                    }
                }
                if cursor < bytes.len() && bytes[cursor] == b'(' {
                    let Some(next) = skip_parenthesized_argument(line_tail, cursor) else {
                        break;
                    };
                    cursor = next;
                    arguments.push(None);
                } else {
                    arguments.push((!projected).then_some(argument));
                }
            }
            if !arguments.is_empty() {
                result.push(SimpleCallSite {
                    offset: index,
                    arguments,
                });
            }
        }
        search_from = index + symbol.len();
    }
    result
}

fn pattern_arm_binds_identifier(line: &str, parameter: &str) -> bool {
    let trimmed = line.trim_start();
    let Some((pattern, _)) = trimmed.split_once("->") else {
        return false;
    };
    if !trimmed.starts_with('|') && !trimmed.contains("fun ") {
        return false;
    }
    pattern
        .split(|character: char| !identifier_continue(character))
        .any(|token| token == parameter)
}

fn binding_shadows_identifier(line: &str, parameter: &str) -> bool {
    let Some(body) = binding_body(line) else {
        return false;
    };
    let symbol = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    if symbol.is_empty() {
        return false;
    }
    if symbol == parameter {
        return true;
    }
    let after_name = &body[symbol.len()..];
    parse_parameters(after_name)
        .into_iter()
        .any(|contract| match contract {
            ParameterContract::Explicit { name, .. } | ParameterContract::Inferred { name } => {
                name == parameter
            }
            ParameterContract::Pattern => false,
        })
}

#[must_use]
pub fn unshadowed_projected_fields(text: &str, parameter: &str) -> BTreeSet<String> {
    let mut shadow_indents = Vec::<usize>::new();
    let mut first_binding = true;
    let mut result = BTreeSet::new();
    let needle = format!("{parameter}.");
    for line in text.lines() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let indent = line.len() - trimmed.len();
        while shadow_indents
            .last()
            .is_some_and(|shadow_indent| indent <= *shadow_indent)
        {
            shadow_indents.pop();
        }
        if binding_body(line).is_some() {
            if first_binding {
                first_binding = false;
            } else if binding_shadows_identifier(line, parameter) {
                shadow_indents.push(indent);
            }
        }
        if pattern_arm_binds_identifier(line, parameter) {
            shadow_indents.push(indent);
        }
        if !shadow_indents.is_empty() {
            continue;
        }
        for (index, _) in line.match_indices(&needle) {
            if line[..index]
                .chars()
                .next_back()
                .is_some_and(|character| identifier_continue(character) || character == '.')
            {
                continue;
            }
            let field_start = index + needle.len();
            let field = line[field_start..]
                .chars()
                .take_while(|character| identifier_continue(*character))
                .collect::<String>();
            if !field.is_empty() {
                result.insert(field);
            }
        }
    }
    result
}

fn parameter_has_field_projection(text: &str, parameter: &str) -> bool {
    !unshadowed_projected_fields(text, parameter).is_empty()
}

fn binding_scope<'a>(text: &'a str, symbol: &str) -> Option<&'a str> {
    let mut offset = 0usize;
    let mut start = None;
    let mut binding_indent = 0usize;
    for line in text.split_inclusive('\n') {
        let source_line = line.trim_end_matches('\n');
        if start.is_none() {
            if binding_defines_symbol(source_line, symbol) {
                start = Some(offset);
                binding_indent = source_line.len() - source_line.trim_start().len();
            }
        } else {
            let trimmed = source_line.trim_start();
            if !trimmed.is_empty() && !trimmed.starts_with("//") {
                let indent = source_line.len() - trimmed.len();
                if indent <= binding_indent {
                    return start.map(|start| &text[start..offset]);
                }
            }
        }
        offset += line.len();
    }
    start.map(|start| &text[start..])
}

pub fn binding_has_field_projection(text: &str, symbol: &str, parameter: &str) -> bool {
    binding_scope(text, symbol)
        .is_some_and(|scope| parameter_has_field_projection(scope, parameter))
}

fn parameter_application_on_line(line: &str, parameter: &str) -> bool {
    let code = line.split_once("//").map_or(line, |(code, _)| code);
    let mut search_from = 0usize;
    while let Some(relative) = code[search_from..].find(parameter) {
        let index = search_from + relative;
        let before = &code[..index];
        let after = &code[index + parameter.len()..];
        let left_boundary = before
            .chars()
            .next_back()
            .is_none_or(|character| !identifier_continue(character));
        let right_boundary = after
            .chars()
            .next()
            .is_none_or(|character| !identifier_continue(character));
        if left_boundary && right_boundary {
            let trimmed = after.trim_start();
            if after.len() != trimmed.len() {
                let next = trimmed
                    .chars()
                    .take_while(|character| identifier_continue(*character))
                    .collect::<String>();
                if !next.is_empty()
                    && !matches!(
                        next.as_str(),
                        "with" | "then" | "else" | "do" | "in" | "when" | "as" | "and" | "or"
                    )
                {
                    return true;
                }
                if trimmed.starts_with('(')
                    || trimmed.starts_with('[')
                    || trimmed.starts_with('"')
                    || trimmed.starts_with(|character: char| character.is_ascii_digit())
                {
                    return true;
                }
            } else if trimmed.starts_with('(') {
                return true;
            }
        }
        search_from = index + parameter.len();
    }
    false
}

#[must_use]
pub fn binding_applies_parameter(text: &str, symbol: &str, parameter: &str) -> bool {
    let Some(scope) = binding_scope(text, symbol) else {
        return false;
    };
    let body = scope.split_once('=').map_or(scope, |(_, body)| body);
    let mut shadow_indents = Vec::<usize>::new();
    for line in body.lines() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let indent = line.len() - trimmed.len();
        while shadow_indents
            .last()
            .is_some_and(|shadow_indent| indent <= *shadow_indent)
        {
            shadow_indents.pop();
        }
        if binding_shadows_identifier(line, parameter)
            || pattern_arm_binds_identifier(line, parameter)
        {
            shadow_indents.push(indent);
        }
        if shadow_indents.is_empty() && parameter_application_on_line(line, parameter) {
            return true;
        }
    }
    false
}

pub fn inferred_untyped_parameter_types(
    provider_text: &str,
    symbol: &str,
    consumer_text: &str,
    pattern_types: Option<&BoundVariableTypes>,
) -> BTreeMap<usize, (String, String)> {
    inferred_untyped_parameter_types_with_bindings(
        provider_text,
        symbol,
        consumer_text,
        pattern_types,
        &BTreeMap::new(),
    )
}

#[must_use]
pub fn inferred_binding_type(text: &str, name: &str) -> Option<String> {
    CaptureParameter::from_owner(text, name)
        .annotation()
        .map(str::to_owned)
}

/// Whether `inferred_untyped_parameter_types_with_bindings` can return anything for `symbol` in this
/// provider, whatever the consumer: some inferred parameter is field-projected and never applied. Depends
/// only on the provider, so callers can cache it per (provider, symbol).
#[must_use]
pub fn has_untyped_projection_parameter(provider_text: &str, symbol: &str) -> bool {
    let Some(contract) = binding_contract(provider_text, symbol) else {
        return false;
    };
    contract.parameters.iter().any(|parameter| {
        matches!(parameter, ParameterContract::Inferred { name }
            if binding_has_field_projection(provider_text, symbol, name)
                && !binding_applies_parameter(provider_text, symbol, name))
    })
}

#[must_use]
pub fn inferred_untyped_parameter_types_with_bindings(
    provider_text: &str,
    symbol: &str,
    consumer_text: &str,
    pattern_types: Option<&BoundVariableTypes>,
    visible_binding_types: &BTreeMap<String, BTreeSet<String>>,
) -> BTreeMap<usize, (String, String)> {
    let Some(contract) = binding_contract(provider_text, symbol) else {
        return BTreeMap::new();
    };
    let calls = simple_arguments_after_call(consumer_text, symbol);
    let mut candidates = BTreeMap::<usize, BTreeSet<String>>::new();
    for call in calls {
        let call_offset = call.offset;
        let arguments = call.arguments;
        let visible_prefix = caller_binding_group_prefix(consumer_text, call_offset);
        let mut explicit = explicit_variable_types(visible_prefix);
        for (name, types) in ancestor_explicit_variable_types(consumer_text, call_offset) {
            explicit.entry(name).or_default().extend(types);
        }
        for (index, parameter) in contract.parameters.iter().enumerate() {
            let ParameterContract::Inferred { name } = parameter else {
                continue;
            };
            if !binding_has_field_projection(provider_text, symbol, name)
                || binding_applies_parameter(provider_text, symbol, name)
            {
                continue;
            }
            let Some(Some(argument)) = arguments.get(index) else {
                continue;
            };
            let pattern_type = pattern_types
                .and_then(|types| types.get(argument))
                .filter(|types| types.len() == 1)
                .and_then(|types| types.iter().next().cloned());
            if let Some(type_symbol) = pattern_type {
                candidates.entry(index).or_default().insert(type_symbol);
                continue;
            }
            if let Some(types) = explicit.get(argument) {
                candidates
                    .entry(index)
                    .or_default()
                    .extend(types.iter().cloned());
                continue;
            }
            if let Some(annotation) =
                CaptureParameter::from_owner(visible_prefix, argument).annotation()
            {
                candidates
                    .entry(index)
                    .or_default()
                    .insert(annotation.to_owned());
                continue;
            }
            if let Some(types) = visible_binding_types.get(argument) {
                candidates
                    .entry(index)
                    .or_default()
                    .extend(types.iter().cloned());
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(index, types)| {
            if types.len() != 1 {
                return None;
            }
            let ParameterContract::Inferred { name } = contract.parameters.get(index)? else {
                return None;
            };
            Some((index, (name.clone(), types.into_iter().next().unwrap())))
        })
        .collect()
}

#[cfg(test)]
mod tests {
    use super::{
        binding_applies_parameter, inferred_untyped_parameter_types,
        inferred_untyped_parameter_types_with_bindings, simple_arguments_after_call,
    };
    use std::collections::{BTreeMap, BTreeSet};

    #[test]
    fn caller_contract_does_not_annotate_function_valued_parameter_as_record_data() {
        let provider = "let provider ty env =\n    let _ = ty.field\n    ty env body\n";
        let consumer = "let caller (ty: Ty) env = provider ty env\n";
        assert!(binding_applies_parameter(provider, "provider", "ty"));
        assert!(inferred_untyped_parameter_types(provider, "provider", consumer, None).is_empty());
    }

    #[test]
    fn caller_contract_still_annotates_projected_data_parameter() {
        let provider = "let provider state =\n    state.field\n";
        let consumer = "let caller (state: LangEnv) = provider state\n";
        let inferred = inferred_untyped_parameter_types(provider, "provider", consumer, None);
        assert_eq!(
            inferred.get(&0),
            Some(&("state".to_owned(), "LangEnv".to_owned()))
        );
    }

    #[test]
    fn parenthesized_arguments_preserve_later_argument_positions() {
        let calls = simple_arguments_after_call(
            "provider first (__spiral_lift cache other) later final",
            "provider",
        );
        assert_eq!(calls.len(), 1);
        assert_eq!(
            calls[0].arguments,
            vec![
                Some("first".to_owned()),
                None,
                Some("later".to_owned()),
                Some("final".to_owned()),
            ]
        );
    }

    #[test]
    fn witnessed_type_survives_parenthesized_earlier_argument() {
        let provider = "let provider first lifted cache key =\n    match cache.TryGetValue key with\n    | true, value -> value\n    | _ -> failwith \"missing\"\n";
        let consumer =
            "let caller first cache key = provider first (__spiral_lift cache) cache key\n";
        let visible = BTreeMap::from([(
            "cache".to_owned(),
            BTreeSet::from([
                "System.Collections.Concurrent.ConcurrentDictionary<Key, Trace>".to_owned(),
            ]),
        )]);
        assert_eq!(
            inferred_untyped_parameter_types_with_bindings(
                provider, "provider", consumer, None, &visible,
            ),
            BTreeMap::from([(
                2usize,
                (
                    "cache".to_owned(),
                    "System.Collections.Concurrent.ConcurrentDictionary<Key, Trace>".to_owned(),
                ),
            )])
        );
    }

    #[test]
    fn local_generic_constructor_binding_can_supply_caller_type() {
        let provider = "let provider cache key =\n    match cache.TryGetValue key with\n    | true, value -> value\n    | _ -> failwith \"missing\"\n";
        let consumer = "let caller key =\n    let cache = System.Collections.Concurrent.ConcurrentDictionary<Key, Trace>(HashIdentity.Reference)\n    provider cache key\n";
        assert_eq!(
            inferred_untyped_parameter_types(provider, "provider", consumer, None),
            BTreeMap::from([(
                0usize,
                (
                    "cache".to_owned(),
                    "System.Collections.Concurrent.ConcurrentDictionary<Key, Trace>".to_owned(),
                ),
            )])
        );
    }

    #[test]
    fn witnessed_binding_from_separate_declaration_can_supply_caller_type() {
        let provider = "let provider cache key =\n    match cache.TryGetValue key with\n    | true, value -> value\n    | _ -> failwith \"missing\"\n";
        let consumer = "let caller cache key = provider cache key\n";
        let visible = BTreeMap::from([(
            "cache".to_owned(),
            BTreeSet::from([
                "System.Collections.Concurrent.ConcurrentDictionary<Key, Trace>".to_owned(),
            ]),
        )]);
        assert_eq!(
            inferred_untyped_parameter_types_with_bindings(
                provider, "provider", consumer, None, &visible,
            ),
            BTreeMap::from([(
                0usize,
                (
                    "cache".to_owned(),
                    "System.Collections.Concurrent.ConcurrentDictionary<Key, Trace>".to_owned(),
                ),
            )])
        );
    }

    #[test]
    fn member_segment_does_not_impersonate_parameter_projection() {
        let provider = "let provider ty free_vars =\n    consume free_vars.ty.free_vars\n";
        let consumer = "let caller (ty : Ty) free_vars = provider ty free_vars\n";
        assert!(inferred_untyped_parameter_types(provider, "provider", consumer, None).is_empty());
    }

    #[test]
    fn shadowed_function_name_does_not_poison_outer_parameter_contract() {
        let provider =
            "let provider state =\n    let nested state arg = state arg\n    state.field\n";
        assert!(!binding_applies_parameter(provider, "provider", "state"));
    }
}
