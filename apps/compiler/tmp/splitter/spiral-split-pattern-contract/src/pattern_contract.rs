use spiral_split_model::{DeclarationId, SplitPlan};
use std::collections::{BTreeMap, BTreeSet};

pub type BoundVariableTypes = BTreeMap<String, BTreeSet<String>>;

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct LocalCallType {
    pub symbol: String,
    pub argument_index: usize,
    pub type_symbol: String,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct PatternContractIndex {
    pub variable_types: BTreeMap<DeclarationId, BoundVariableTypes>,
    pub local_calls: BTreeMap<DeclarationId, Vec<LocalCallType>>,
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn identifier(value: &str) -> bool {
    let mut chars = value.chars();
    chars.next().is_some_and(identifier_start) && chars.all(identifier_continue)
}

fn simple_type_symbol(value: &str) -> Option<String> {
    let token = value
        .split_whitespace()
        .next()?
        .trim_matches(|character: char| matches!(character, '(' | ')' | '[' | ']'));
    let symbol = token.rsplit('.').next().unwrap_or(token);
    identifier(symbol).then(|| symbol.to_owned())
}

fn parse_case_definition(line: &str) -> Option<(String, Vec<String>)> {
    let body = line.trim().strip_prefix('|')?.trim_start();
    let (case, payload) = body.split_once(" of ")?;
    let case = case.trim();
    if !identifier(case) {
        return None;
    }
    let types = payload
        .split('*')
        .filter_map(simple_type_symbol)
        .collect::<Vec<_>>();
    (!types.is_empty()).then(|| (case.to_owned(), types))
}

fn case_payloads(plan: &SplitPlan) -> BTreeMap<String, Vec<String>> {
    let mut candidates = BTreeMap::<String, BTreeSet<Vec<String>>>::new();
    for declaration in &plan.declarations {
        for line in declaration.text.lines() {
            if let Some((case, payload)) = parse_case_definition(line) {
                candidates.entry(case).or_default().insert(payload);
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(case, payloads)| {
            (payloads.len() == 1).then(|| (case, payloads.into_iter().next().unwrap()))
        })
        .collect()
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

fn simple_pattern_arguments(body: &str) -> Vec<Option<String>> {
    body.split(',')
        .map(|part| {
            let value = part.trim();
            identifier(value).then(|| value.to_owned())
        })
        .collect()
}

fn bind_case_patterns(
    line: &str,
    payloads: &BTreeMap<String, Vec<String>>,
    output: &mut BoundVariableTypes,
) {
    let Some((pattern, _)) = line.split_once("->") else {
        return;
    };
    let bytes = pattern.as_bytes();
    let mut cursor = 0usize;
    while cursor < bytes.len() {
        let Some(first) = pattern[cursor..].chars().next() else {
            break;
        };
        if !identifier_start(first) {
            cursor += first.len_utf8();
            continue;
        }
        let start = cursor;
        cursor += first.len_utf8();
        while cursor < bytes.len() {
            let Some(character) = pattern[cursor..].chars().next() else {
                break;
            };
            if !identifier_continue(character) {
                break;
            }
            cursor += character.len_utf8();
        }
        let case = &pattern[start..cursor];
        let Some(types) = payloads.get(case) else {
            continue;
        };
        let after = pattern[cursor..].trim_start();
        if !after.starts_with('(') {
            continue;
        }
        let Some(close) = matching_paren(after, 0) else {
            continue;
        };
        let arguments = simple_pattern_arguments(&after[1..close]);
        if arguments.len() != types.len() {
            continue;
        }
        for (argument, type_symbol) in arguments.into_iter().zip(types) {
            if let Some(argument) = argument {
                output
                    .entry(argument)
                    .or_default()
                    .insert(type_symbol.clone());
            }
        }
    }
}

fn local_binding_symbol(line: &str) -> Option<String> {
    let mut body = line
        .trim_start()
        .strip_prefix("let ")
        .or_else(|| line.trim_start().strip_prefix("and "))?;
    loop {
        let before = body;
        for modifier in [
            "rec ",
            "private ",
            "internal ",
            "public ",
            "inline ",
            "mutable ",
        ] {
            if let Some(rest) = body.strip_prefix(modifier) {
                body = rest;
                break;
            }
        }
        if body == before {
            break;
        }
    }
    let symbol = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    identifier(&symbol).then_some(symbol)
}

fn local_calls_with_typed_arguments(
    line: &str,
    types: &BoundVariableTypes,
    local_symbols: &BTreeSet<String>,
) -> Vec<LocalCallType> {
    let rhs = line.split_once("->").map_or(line, |(_, rhs)| rhs);
    let bytes = rhs.as_bytes();
    let mut cursor = 0usize;
    let mut result = Vec::new();
    while cursor < bytes.len() {
        let Some(first) = rhs[cursor..].chars().next() else {
            break;
        };
        if !identifier_start(first) {
            cursor += first.len_utf8();
            continue;
        }
        let start = cursor;
        cursor += first.len_utf8();
        while cursor < bytes.len() {
            let Some(character) = rhs[cursor..].chars().next() else {
                break;
            };
            if !identifier_continue(character) {
                break;
            }
            cursor += character.len_utf8();
        }
        let symbol = &rhs[start..cursor];
        if !local_symbols.contains(symbol) || types.contains_key(symbol) {
            continue;
        }
        let mut argument_cursor = cursor;
        let mut argument_index = 0usize;
        loop {
            while argument_cursor < bytes.len() && bytes[argument_cursor].is_ascii_whitespace() {
                argument_cursor += 1;
            }
            if argument_cursor >= bytes.len() {
                break;
            }
            let Some(argument_first) = rhs[argument_cursor..].chars().next() else {
                break;
            };
            if !identifier_start(argument_first) {
                break;
            }
            let argument_start = argument_cursor;
            argument_cursor += argument_first.len_utf8();
            while argument_cursor < bytes.len() {
                let Some(character) = rhs[argument_cursor..].chars().next() else {
                    break;
                };
                if !identifier_continue(character) {
                    break;
                }
                argument_cursor += character.len_utf8();
            }
            let argument = &rhs[argument_start..argument_cursor];
            if let Some(argument_types) = types.get(argument).filter(|types| types.len() == 1) {
                result.push(LocalCallType {
                    symbol: symbol.to_owned(),
                    argument_index,
                    type_symbol: argument_types.iter().next().unwrap().clone(),
                });
            }
            argument_index += 1;
        }
    }
    result.sort();
    result.dedup();
    result
}

fn declaration_pattern_contracts(
    text: &str,
    payloads: &BTreeMap<String, Vec<String>>,
) -> (BoundVariableTypes, Vec<LocalCallType>) {
    let local_symbols = text
        .lines()
        .filter_map(local_binding_symbol)
        .collect::<BTreeSet<_>>();
    let mut declaration_types = BoundVariableTypes::new();
    let mut declaration_calls = Vec::new();
    let mut active_arm = None::<(usize, BoundVariableTypes)>;
    for line in text.lines() {
        let trimmed = line.trim_start();
        let indent = line.len() - trimmed.len();
        let mut line_types = BoundVariableTypes::new();
        bind_case_patterns(line, payloads, &mut line_types);
        if !line_types.is_empty() {
            declaration_calls.extend(local_calls_with_typed_arguments(
                line,
                &line_types,
                &local_symbols,
            ));
            active_arm = Some((indent, line_types.clone()));
            for (name, types) in line_types {
                declaration_types.entry(name).or_default().extend(types);
            }
            continue;
        }
        if active_arm
            .as_ref()
            .is_some_and(|(arm_indent, _)| !trimmed.is_empty() && indent <= *arm_indent)
        {
            active_arm = None;
        }
        if let Some((_, arm_types)) = &active_arm {
            declaration_calls.extend(local_calls_with_typed_arguments(
                line,
                arm_types,
                &local_symbols,
            ));
        }
    }
    declaration_calls.sort();
    declaration_calls.dedup();
    (declaration_types, declaration_calls)
}

#[must_use]
pub fn analyze_pattern_contracts(plan: &SplitPlan) -> PatternContractIndex {
    let payloads = case_payloads(plan);
    let mut variable_types = BTreeMap::new();
    let mut local_calls = BTreeMap::new();
    for declaration in &plan.declarations {
        let (declaration_types, declaration_calls) =
            declaration_pattern_contracts(&declaration.text, &payloads);
        if !declaration_types.is_empty() {
            variable_types.insert(declaration.id, declaration_types);
        }
        if !declaration_calls.is_empty() {
            local_calls.insert(declaration.id, declaration_calls);
        }
    }
    PatternContractIndex {
        variable_types,
        local_calls,
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn parses_union_payload_types() {
        assert_eq!(
            parse_case_definition("    | TyMetavar of MVar * T option ref"),
            Some((
                "TyMetavar".to_owned(),
                vec!["MVar".to_owned(), "T".to_owned()]
            ))
        );
    }

    #[test]
    fn du_payload_binds_simple_pattern_variables() {
        let payloads = BTreeMap::from([(
            "TyMetavar".to_owned(),
            vec!["MVar".to_owned(), "T".to_owned()],
        )]);
        let mut output = BoundVariableTypes::new();
        bind_case_patterns(
            "| TyMetavar(a,link), b | b, TyMetavar(a,link) -> validate_mvar_unification a b",
            &payloads,
            &mut output,
        );
        assert_eq!(output.get("a"), Some(&BTreeSet::from(["MVar".to_owned()])));
        assert_eq!(output.get("link"), Some(&BTreeSet::from(["T".to_owned()])));
    }

    #[test]
    fn constructor_like_calls_outside_pattern_arrows_are_ignored() {
        let payloads = BTreeMap::from([("TyMetavar".to_owned(), vec!["MVar".to_owned()])]);
        let mut output = BoundVariableTypes::new();
        bind_case_patterns("let x = TyMetavar(a)", &payloads, &mut output);
        assert!(output.is_empty());
    }

    #[test]
    fn du_payload_types_flow_to_multiline_arm_calls() {
        let payloads = BTreeMap::from([(
            "TyMetavar".to_owned(),
            vec!["MVar".to_owned(), "T".to_owned()],
        )]);
        let source = r#"let validate_mvar_unification i x = i.scope
let loop pair =
    match pair with
    | TyMetavar(a,link), b | b, TyMetavar(a,link) ->
        validate_mvar_unification a b
    | _ -> ()"#;
        let (_, calls) = declaration_pattern_contracts(source, &payloads);
        assert!(calls.contains(&LocalCallType {
            symbol: "validate_mvar_unification".to_owned(),
            argument_index: 0,
            type_symbol: "MVar".to_owned(),
        }));
    }

    #[test]
    fn multiline_arm_contracts_ignore_non_local_calls() {
        let payloads = BTreeMap::from([("TyMetavar".to_owned(), vec!["MVar".to_owned()])]);
        let source = r#"let loop pair =
    match pair with
    | TyMetavar(a) ->
        external_helper a
    | _ -> ()"#;
        let (_, calls) = declaration_pattern_contracts(source, &payloads);
        assert!(calls.is_empty());
    }

    #[test]
    fn pattern_binding_shadowing_local_function_symbol_is_not_call() {
        let payloads = BTreeMap::from([(
            "TyOp".to_owned(),
            vec!["OpTag".to_owned(), "Data".to_owned()],
        )]);
        let source = r#"let rec op s d a = s
and codegen x =
    match x with
    | TyOp(op,l) ->
        sprintf "%A with %i args not supported" op l.Length
    | _ -> ()"#;
        let (_, calls) = declaration_pattern_contracts(source, &payloads);
        assert!(!calls.iter().any(|call| call.symbol == "op"));
    }
}
