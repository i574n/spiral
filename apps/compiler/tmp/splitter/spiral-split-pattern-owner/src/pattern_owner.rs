use spiral_split_forwarded_return::transparent_control_flow_return_names;
use spiral_split_member_projection::MemberProjectionIndex;
use spiral_split_model::{DeclarationId, SplitPlan};
use spiral_split_record_owner::RecordProjectionIndex;
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::Write as _;

#[derive(Clone, Debug, Eq, PartialEq)]
enum PatternTerm {
    Binding(String),
    Constructor {
        symbol: String,
        payload: Vec<PatternTerm>,
    },
    Product(Vec<PatternTerm>),
    Ignore,
}

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct PatternOwnerWitness {
    pub line_index: usize,
    pub variable: String,
    pub type_symbol: String,
    pub projected_fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct LocalRecordOwnerWitness {
    pub line_index: usize,
    pub variable: String,
    pub type_symbol: String,
    pub projected_fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct LocalRecordProjection {
    line_index: usize,
    variable: String,
    rhs_callee: Option<String>,
    rhs_callee_qualified: bool,
    first_field: String,
    projected_fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct PatternProjection {
    line_index: usize,
    variable: String,
    constructor: String,
    first_field: String,
    projected_fields: BTreeSet<String>,
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
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

fn ignored_binding(symbol: &str) -> bool {
    matches!(
        symbol,
        "_" | "as" | "when" | "true" | "false" | "null" | "function"
    )
}

fn pattern_tree(text: &str) -> PatternTerm {
    let bytes = text.as_bytes();
    let mut cursor = 0usize;
    let mut terms = Vec::new();
    while cursor < bytes.len() {
        let Some(character) = text[cursor..].chars().next() else {
            break;
        };
        if character == '('
            && let Some(close) = matching_paren(text, cursor)
        {
            terms.push(pattern_tree(&text[cursor + 1..close]));
            cursor = close + 1;
            continue;
        }
        if !identifier_start(character) {
            cursor += character.len_utf8();
            continue;
        }
        let start = cursor;
        cursor += character.len_utf8();
        while cursor < bytes.len() {
            let Some(next) = text[cursor..].chars().next() else {
                break;
            };
            if !identifier_continue(next) {
                break;
            }
            cursor += next.len_utf8();
        }
        let symbol = &text[start..cursor];
        if ignored_binding(symbol) {
            terms.push(PatternTerm::Ignore);
        } else if symbol.chars().next().is_some_and(char::is_uppercase) {
            terms.push(PatternTerm::Constructor {
                symbol: symbol.to_owned(),
                payload: Vec::new(),
            });
        } else {
            terms.push(PatternTerm::Binding(symbol.to_owned()));
        }
    }
    match terms.len() {
        0 => PatternTerm::Ignore,
        1 => terms.pop().expect("one pattern term"),
        _ => PatternTerm::Product(terms),
    }
}

fn collect_bindings(term: &PatternTerm, output: &mut BTreeSet<String>) {
    match term {
        PatternTerm::Binding(symbol) => {
            output.insert(symbol.clone());
        }
        PatternTerm::Constructor { payload, .. } | PatternTerm::Product(payload) => {
            for term in payload {
                collect_bindings(term, output);
            }
        }
        PatternTerm::Ignore => {}
    }
}

fn bound_variables(pattern: &str) -> BTreeSet<String> {
    let pattern = pattern
        .split_once(" when ")
        .map_or(pattern, |(head, _)| head);
    let mut output = BTreeSet::new();
    collect_bindings(&pattern_tree(pattern), &mut output);
    output
}

fn root_constructor(pattern: &str) -> Option<String> {
    let pattern = pattern
        .split_once(" when ")
        .map_or(pattern, |(head, _)| head)
        .trim();
    let symbol = pattern
        .chars()
        .skip_while(|character| !identifier_start(*character))
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    symbol
        .chars()
        .next()
        .is_some_and(char::is_uppercase)
        .then_some(symbol)
}

fn declared_payload_cases(plan: &SplitPlan) -> BTreeSet<String> {
    plan.declarations
        .iter()
        .filter(|declaration| !declaration.text.contains("RequireQualifiedAccess"))
        .flat_map(|declaration| declaration.text.lines())
        .filter_map(|line| {
            let body = line.trim().strip_prefix('|')?.trim_start();
            let (case, _) = body.split_once(" of ")?;
            let case = case.trim();
            let mut chars = case.chars();
            (chars.next().is_some_and(char::is_uppercase) && chars.all(identifier_continue))
                .then(|| case.to_owned())
        })
        .collect()
}

fn projected_fields_in_order(text: &str, variable: &str) -> Vec<String> {
    let prefix = format!("{variable}.");
    let mut output = Vec::new();
    for (index, _) in text.match_indices(&prefix) {
        let before = text[..index].chars().next_back();
        if before.is_some_and(identifier_continue) {
            continue;
        }
        let field_start = index + prefix.len();
        let mut end = field_start;
        for character in text[field_start..].chars() {
            if !identifier_continue(character) {
                break;
            }
            end += character.len_utf8();
        }
        if end > field_start {
            let field = text[field_start..end].to_owned();
            if !output.contains(&field) {
                output.push(field);
            }
        }
    }
    output
}

fn leading_spaces(line: &str) -> usize {
    line.len() - line.trim_start().len()
}

fn pattern_projections(text: &str) -> Vec<PatternProjection> {
    let lines = text.lines().collect::<Vec<_>>();
    let mut output = Vec::new();
    for (line_index, line) in lines.iter().enumerate() {
        let trimmed = line.trim_start();
        let Some(after_bar) = trimmed.strip_prefix('|') else {
            continue;
        };
        if after_bar.starts_with('>') || after_bar.starts_with('|') {
            continue;
        }
        let Some((pattern, _)) = after_bar.split_once("->") else {
            continue;
        };
        let Some(constructor) = root_constructor(pattern) else {
            continue;
        };
        let arm_indent = leading_spaces(line);
        let mut end = line_index + 1;
        while end < lines.len() {
            let candidate = lines[end];
            if !candidate.trim().is_empty() && leading_spaces(candidate) <= arm_indent {
                break;
            }
            end += 1;
        }
        let body = lines[line_index..end].join("\n");
        for variable in bound_variables(pattern) {
            let field_order = projected_fields_in_order(&body, &variable);
            if field_order.len() >= 2 {
                output.push(PatternProjection {
                    line_index,
                    variable,
                    constructor: constructor.clone(),
                    first_field: field_order[0].clone(),
                    projected_fields: field_order.into_iter().collect(),
                });
            }
        }
    }
    output.sort_by(|left, right| {
        left.line_index
            .cmp(&right.line_index)
            .then_with(|| left.variable.cmp(&right.variable))
    });
    output.dedup();
    output
}

fn local_binding_name(line: &str) -> Option<String> {
    let rest = line.trim_start().strip_prefix("let ")?;
    if rest.starts_with("rec ") || rest.starts_with("mutable ") {
        return None;
    }
    let name = rest
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    if name.is_empty() || !name.chars().next().is_some_and(identifier_start) {
        return None;
    }
    rest[name.len()..]
        .trim_start()
        .starts_with('=')
        .then_some(name)
}

fn local_binding_rhs_callee(line: &str) -> Option<String> {
    let (_, rhs) = line.split_once('=')?;
    let rhs = rhs.trim_start();
    let token = rhs
        .chars()
        .take_while(|character| identifier_continue(*character) || *character == '.')
        .collect::<String>();
    if token.is_empty() || token.ends_with('.') {
        return None;
    }
    let remainder = rhs[token.len()..].trim_start();
    if remainder.is_empty() {
        return None;
    }
    token
        .rsplit('.')
        .find(|piece| !piece.is_empty())
        .map(str::to_owned)
}

fn local_binding_rhs_callee_is_qualified(line: &str) -> bool {
    let Some((_, rhs)) = line.split_once('=') else {
        return false;
    };
    let rhs = rhs.trim_start();
    let token = rhs
        .chars()
        .take_while(|character| identifier_continue(*character) || *character == '.')
        .collect::<String>();
    if token.is_empty() || token.ends_with('.') {
        return false;
    }
    let remainder = rhs[token.len()..].trim_start();
    !remainder.is_empty() && token.contains('.')
}

fn strip_balanced_outer_parens(mut text: &str) -> &str {
    loop {
        let trimmed = text.trim();
        if !trimmed.starts_with('(')
            || matching_paren(trimmed, 0) != Some(trimmed.len().saturating_sub(1))
        {
            return trimmed;
        }
        text = &trimmed[1..trimmed.len() - 1];
    }
}

fn local_binding_rhs_head<'a>(line: &'a str, body: &'a str) -> &'a str {
    let inline_rhs = line.split_once('=').map_or("", |(_, rhs)| rhs.trim());
    if inline_rhs.is_empty() {
        body.lines()
            .map(str::trim)
            .find(|line| !line.is_empty())
            .unwrap_or("")
    } else {
        inline_rhs
    }
}

fn local_binding_rhs_is_pure_projection(line: &str, body: &str) -> bool {
    let rhs = strip_balanced_outer_parens(local_binding_rhs_head(line, body));
    !rhs.is_empty()
        && rhs.contains('.')
        && !rhs.starts_with('.')
        && !rhs.ends_with('.')
        && rhs
            .chars()
            .all(|character| identifier_continue(character) || character == '.')
}

fn local_binding_rhs_is_control_flow(line: &str, body: &str) -> bool {
    let inline_rhs = line.split_once('=').map_or("", |(_, rhs)| rhs.trim());
    let head = if inline_rhs.is_empty() {
        body.lines()
            .map(str::trim)
            .find(|line| !line.is_empty())
            .unwrap_or("")
    } else {
        inline_rhs
    };
    matches!(
        head.split_whitespace().next(),
        Some("match" | "if" | "try" | "function")
    )
}

fn explicit_binding_return_type(line: &str) -> Option<(String, String)> {
    let mut body = line
        .trim_start()
        .strip_prefix("let ")
        .or_else(|| line.trim_start().strip_prefix("and "))?
        .trim_start();
    loop {
        let before = body;
        for modifier in ["rec ", "private ", "internal ", "public ", "inline "] {
            if let Some(rest) = body.strip_prefix(modifier) {
                body = rest.trim_start();
                break;
            }
        }
        if body == before {
            break;
        }
    }
    let name = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    if name.is_empty() || !name.chars().next().is_some_and(identifier_start) {
        return None;
    }
    let after_name = &body[name.len()..];
    let (left, _) = after_name.split_once('=')?;
    let mut depth = 0usize;
    let mut return_colon = None;
    for (index, character) in left.char_indices() {
        match character {
            '(' | '[' | '{' | '<' => depth += 1,
            ')' | ']' | '}' | '>' => depth = depth.saturating_sub(1),
            ':' if depth == 0 => return_colon = Some(index),
            _ => {}
        }
    }
    let return_type = left[return_colon? + 1..].trim();
    (!return_type.is_empty()).then(|| (name, return_type.to_owned()))
}

fn explicit_binding_return_types(plan: &SplitPlan) -> BTreeMap<String, String> {
    let mut candidates = BTreeMap::<String, BTreeSet<String>>::new();
    for declaration in &plan.declarations {
        for line in declaration.text.lines() {
            if let Some((name, return_type)) = explicit_binding_return_type(line) {
                candidates.entry(name).or_default().insert(return_type);
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(name, returns)| {
            (returns.len() == 1)
                .then(|| (name, returns.into_iter().next().expect("one return type")))
        })
        .collect()
}

fn binding_name(line: &str) -> Option<String> {
    let mut body = line
        .trim_start()
        .strip_prefix("let ")
        .or_else(|| line.trim_start().strip_prefix("and "))?
        .trim_start();
    loop {
        let before = body;
        for modifier in ["rec ", "private ", "internal ", "public ", "inline "] {
            if let Some(rest) = body.strip_prefix(modifier) {
                body = rest.trim_start();
                break;
            }
        }
        if body == before {
            break;
        }
    }
    let name = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    (!name.is_empty() && name.chars().next().is_some_and(identifier_start)).then_some(name)
}

fn control_flow_binding_return_names_in_text(text: &str) -> BTreeSet<String> {
    let lines = text.lines().collect::<Vec<_>>();
    let mut output = BTreeSet::new();
    for (index, line) in lines.iter().enumerate() {
        let Some(name) = binding_name(line) else {
            continue;
        };
        let Some((_, inline_rhs)) = line.split_once('=') else {
            continue;
        };
        let head = if inline_rhs.trim().is_empty() {
            lines[index + 1..]
                .iter()
                .map(|candidate| candidate.trim())
                .find(|candidate| !candidate.is_empty())
                .unwrap_or("")
        } else {
            inline_rhs.trim()
        };
        if matches!(
            head.split_whitespace().next(),
            Some("match" | "if" | "try" | "function")
        ) {
            output.insert(name);
        }
    }
    output
}

fn control_flow_binding_return_names(plan: &SplitPlan) -> BTreeSet<String> {
    plan.declarations
        .iter()
        .flat_map(|declaration| control_flow_binding_return_names_in_text(&declaration.text))
        .collect()
}

fn direct_anonymous_record_return_at(lines: &[&str], header_index: usize) -> Option<String> {
    let header = *lines.get(header_index)?;
    let mut rest = header.trim_start().strip_prefix("let ")?.trim_start();
    for modifier in ["rec ", "private ", "internal ", "public "] {
        if rest.starts_with(modifier) {
            rest = rest[modifier.len()..].trim_start();
        }
    }
    let name = rest
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    if name.is_empty() || !name.chars().next().is_some_and(identifier_start) {
        return None;
    }
    let equal = header.find('=')?;
    if header[equal + 1..].trim_start().starts_with("{|") {
        return Some(name);
    }
    lines[header_index + 1..]
        .iter()
        .map(|line| line.trim_start())
        .find(|line| !line.is_empty())
        .filter(|line| line.starts_with("{|"))
        .map(|_| name)
}

fn direct_anonymous_record_return_names_in_text(text: &str) -> BTreeSet<String> {
    let lines = text.lines().collect::<Vec<_>>();
    lines
        .iter()
        .enumerate()
        .filter(|(_, line)| line.trim_start().starts_with("let "))
        .filter_map(|(header_index, _)| direct_anonymous_record_return_at(&lines, header_index))
        .collect()
}

#[cfg(test)]
fn direct_anonymous_record_return_name(text: &str) -> Option<String> {
    direct_anonymous_record_return_names_in_text(text)
        .into_iter()
        .next()
}

fn direct_anonymous_record_return_names(plan: &SplitPlan) -> BTreeSet<String> {
    plan.declarations
        .iter()
        .flat_map(|declaration| direct_anonymous_record_return_names_in_text(&declaration.text))
        .collect()
}

fn local_record_projections(text: &str) -> Vec<LocalRecordProjection> {
    let lines = text.lines().collect::<Vec<_>>();
    let mut output = Vec::new();
    for (line_index, line) in lines.iter().enumerate() {
        let Some(variable) = local_binding_name(line) else {
            continue;
        };
        let rhs_callee = local_binding_rhs_callee(line);
        let rhs_callee_qualified = local_binding_rhs_callee_is_qualified(line);
        let binding_indent = leading_spaces(line);
        let mut end = line_index + 1;
        while end < lines.len() {
            let candidate = lines[end];
            if !candidate.trim().is_empty() && leading_spaces(candidate) < binding_indent {
                break;
            }
            end += 1;
        }
        let body = lines[line_index + 1..end].join("\n");
        if local_binding_rhs_is_control_flow(line, &body)
            || local_binding_rhs_is_pure_projection(line, &body)
        {
            continue;
        }
        let field_order = projected_fields_in_order(&body, &variable);
        if field_order.len() >= 2 {
            output.push(LocalRecordProjection {
                line_index,
                variable,
                rhs_callee,
                rhs_callee_qualified,
                first_field: field_order[0].clone(),
                projected_fields: field_order.into_iter().collect(),
            });
        }
    }
    output.sort_by(|left, right| {
        left.line_index
            .cmp(&right.line_index)
            .then_with(|| left.variable.cmp(&right.variable))
    });
    output.dedup();
    output
}

fn contains_whole_identifier(text: &str, symbol: &str) -> bool {
    text.match_indices(symbol).any(|(index, matched)| {
        let before = text[..index].chars().next_back();
        let after = text[index + matched.len()..].chars().next();
        before.is_none_or(|character| !identifier_continue(character))
            && after.is_none_or(|character| !identifier_continue(character))
    })
}

fn shadow_lambda_lines(text: &str, witness: &LocalRecordOwnerWitness) -> Vec<usize> {
    let lines = text.lines().collect::<Vec<_>>();
    let Some(binding_line) = lines.get(witness.line_index) else {
        return Vec::new();
    };
    let Some((_, rhs)) = binding_line.split_once('=') else {
        return Vec::new();
    };
    let Some(lookup) = rhs.split_whitespace().last() else {
        return Vec::new();
    };
    if lookup.is_empty()
        || !lookup.chars().next().is_some_and(identifier_start)
        || !lookup.chars().all(identifier_continue)
    {
        return Vec::new();
    }
    let binding_indent = leading_spaces(binding_line);
    let marker = format!("fun {} ->", witness.variable);
    let mut output = Vec::new();
    for (line_index, line) in lines.iter().enumerate().skip(witness.line_index + 1) {
        if !line.trim().is_empty() && leading_spaces(line) < binding_indent {
            break;
        }
        let Some(marker_index) = line.find(&marker) else {
            continue;
        };
        if contains_whole_identifier(&line[..marker_index], lookup) {
            output.push(line_index);
        }
    }
    output
}

fn local_owner_type_is_renderable(type_symbol: &str) -> bool {
    let mut chars = type_symbol.chars();
    chars.next().is_some_and(identifier_start)
        && chars.all(|character| identifier_continue(character) || character == '.')
}

#[must_use]
pub fn analyze_local_record_owners(
    plan: &SplitPlan,
) -> BTreeMap<DeclarationId, Vec<LocalRecordOwnerWitness>> {
    let record_index = RecordProjectionIndex::new(plan);
    let member_projection_index = MemberProjectionIndex::from_texts(
        plan.declarations
            .iter()
            .map(|declaration| declaration.text.as_str()),
    );
    let anonymous_record_returns = direct_anonymous_record_return_names(plan);
    let control_flow_returns = control_flow_binding_return_names(plan);
    let transparent_control_flow_returns = plan
        .declarations
        .iter()
        .flat_map(|declaration| transparent_control_flow_return_names(&declaration.text))
        .collect::<BTreeSet<_>>();
    let explicit_return_types = explicit_binding_return_types(plan);
    let mut output = BTreeMap::<DeclarationId, Vec<LocalRecordOwnerWitness>>::new();
    for declaration in &plan.declarations {
        for projection in local_record_projections(&declaration.text) {
            if projection
                .rhs_callee
                .as_ref()
                .is_some_and(|callee| anonymous_record_returns.contains(callee))
            {
                continue;
            }
            if !record_index.field_is_ambiguous(plan, declaration.id, &projection.first_field) {
                continue;
            }
            let explicit_return_type = (!projection.rhs_callee_qualified)
                .then(|| {
                    projection
                        .rhs_callee
                        .as_ref()
                        .and_then(|callee| explicit_return_types.get(callee))
                })
                .flatten();
            if explicit_return_type.is_none()
                && !projection.rhs_callee_qualified
                && projection.rhs_callee.as_ref().is_some_and(|callee| {
                    control_flow_returns.contains(callee)
                        && !transparent_control_flow_returns.contains(callee)
                })
            {
                continue;
            }
            let transparent_control_flow_return = explicit_return_type.is_none()
                && !projection.rhs_callee_qualified
                && projection
                    .rhs_callee
                    .as_ref()
                    .is_some_and(|callee| transparent_control_flow_returns.contains(callee));
            if transparent_control_flow_return
                && member_projection_index.shadows_fields(&projection.projected_fields)
            {
                continue;
            }
            let type_symbol = if let Some(type_symbol) = explicit_return_type {
                if !local_owner_type_is_renderable(type_symbol) {
                    continue;
                }
                type_symbol.clone()
            } else {
                let Some(type_symbol) = record_index.unique_owner_type(
                    plan,
                    declaration.id,
                    &projection.projected_fields,
                ) else {
                    continue;
                };
                if !local_owner_type_is_renderable(&type_symbol) {
                    continue;
                }
                type_symbol
            };
            output
                .entry(declaration.id)
                .or_default()
                .push(LocalRecordOwnerWitness {
                    line_index: projection.line_index,
                    variable: projection.variable,
                    type_symbol,
                    projected_fields: projection.projected_fields,
                });
        }
    }
    let anchored = output.clone();
    for (declaration_id, witnesses) in anchored {
        let Some(declaration) = plan
            .declarations
            .iter()
            .find(|declaration| declaration.id == declaration_id)
        else {
            continue;
        };
        for witness in witnesses {
            for line_index in shadow_lambda_lines(&declaration.text, &witness) {
                output
                    .entry(declaration_id)
                    .or_default()
                    .push(LocalRecordOwnerWitness {
                        line_index,
                        variable: witness.variable.clone(),
                        type_symbol: witness.type_symbol.clone(),
                        projected_fields: witness.projected_fields.clone(),
                    });
            }
        }
    }
    for witnesses in output.values_mut() {
        witnesses.sort();
        witnesses.dedup();
    }
    output
}

#[must_use]
pub fn analyze_pattern_record_owners(
    plan: &SplitPlan,
) -> BTreeMap<DeclarationId, Vec<PatternOwnerWitness>> {
    let record_index = RecordProjectionIndex::new(plan);
    let declared_payload_cases = declared_payload_cases(plan);
    let mut output = BTreeMap::<DeclarationId, Vec<PatternOwnerWitness>>::new();
    for declaration in &plan.declarations {
        for projection in pattern_projections(&declaration.text) {
            if declared_payload_cases.contains(&projection.constructor) {
                continue;
            }
            if !record_index.field_is_ambiguous(plan, declaration.id, &projection.first_field) {
                continue;
            }
            let Some(type_symbol) =
                record_index.unique_owner_type(plan, declaration.id, &projection.projected_fields)
            else {
                continue;
            };
            output
                .entry(declaration.id)
                .or_default()
                .push(PatternOwnerWitness {
                    line_index: projection.line_index,
                    variable: projection.variable,
                    type_symbol,
                    projected_fields: projection.projected_fields,
                });
        }
    }
    for witnesses in output.values_mut() {
        witnesses.sort();
        witnesses.dedup();
    }
    output
}

#[must_use]
pub fn render_pattern_owner_witnesses(
    witnesses: &BTreeMap<DeclarationId, Vec<PatternOwnerWitness>>,
) -> String {
    let mut output = String::from("declaration\tline\tvariable\ttype\tfields\n");
    for (declaration, rows) in witnesses {
        for witness in rows {
            let fields = witness
                .projected_fields
                .iter()
                .cloned()
                .collect::<Vec<_>>()
                .join(",");
            let _ = writeln!(
                output,
                "{}\t{}\t{}\t{}\t{}",
                declaration.0,
                witness.line_index + 1,
                witness.variable,
                witness.type_symbol,
                fields
            );
        }
    }
    output
}

fn whole_identifier(text: &str, symbol: &str) -> Option<usize> {
    text.match_indices(symbol).find_map(|(index, matched)| {
        let before = text[..index].chars().next_back();
        let after = text[index + matched.len()..].chars().next();
        (before.is_none_or(|character| !identifier_continue(character))
            && after.is_none_or(|character| !identifier_continue(character)))
        .then_some(index)
    })
}

#[must_use]
pub fn render_local_record_owner_witnesses(
    witnesses: &BTreeMap<DeclarationId, Vec<LocalRecordOwnerWitness>>,
) -> String {
    let mut output = String::from("declaration\tline\tvariable\ttype\tfields\n");
    for (declaration, rows) in witnesses {
        for witness in rows {
            let fields = witness
                .projected_fields
                .iter()
                .cloned()
                .collect::<Vec<_>>()
                .join(",");
            let _ = writeln!(
                output,
                "{}\t{}\t{}\t{}\t{}",
                declaration.0,
                witness.line_index + 1,
                witness.variable,
                witness.type_symbol,
                fields
            );
        }
    }
    output
}

fn annotate_local_binding(line: &str, witness: &LocalRecordOwnerWitness) -> String {
    let lambda_marker = format!("fun {} ->", witness.variable);
    if let Some(marker_index) = line.find(&lambda_marker) {
        let variable_index = marker_index + "fun ".len();
        let mut output = line.to_owned();
        let replacement = format!("({} : {})", witness.variable, witness.type_symbol);
        output.replace_range(
            variable_index..variable_index + witness.variable.len(),
            &replacement,
        );
        return output;
    }
    let Some(equal) = line.find('=') else {
        return line.to_owned();
    };
    let mut left = line[..equal].to_owned();
    if left.contains(&format!("{} :", witness.variable))
        || left.contains(&format!("{}:", witness.variable))
    {
        return line.to_owned();
    }
    let Some(index) = whole_identifier(&left, &witness.variable) else {
        return line.to_owned();
    };
    let replacement = format!("({} : {})", witness.variable, witness.type_symbol);
    left.replace_range(index..index + witness.variable.len(), &replacement);
    format!("{left}{}", &line[equal..])
}

#[must_use]
pub fn apply_local_record_owner_witnesses(
    text: &str,
    witnesses: &[LocalRecordOwnerWitness],
) -> String {
    if witnesses.is_empty() {
        return text.to_owned();
    }
    let mut by_line = BTreeMap::<usize, &LocalRecordOwnerWitness>::new();
    for witness in witnesses {
        by_line.entry(witness.line_index).or_insert(witness);
    }
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    for (line_index, witness) in by_line {
        if let Some(line) = lines.get_mut(line_index) {
            *line = annotate_local_binding(line, witness);
        }
    }
    let mut output = lines.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        output.push('\n');
    }
    output
}

fn annotate_pattern_line(line: &str, witnesses: &[&PatternOwnerWitness]) -> String {
    let Some((pattern, rhs)) = line.split_once("->") else {
        return line.to_owned();
    };
    let mut pattern = pattern.to_owned();
    for witness in witnesses {
        if pattern.contains(&format!("{} :", witness.variable))
            || pattern.contains(&format!("{}:", witness.variable))
        {
            continue;
        }
        let Some(index) = whole_identifier(&pattern, &witness.variable) else {
            continue;
        };
        let replacement = format!("({} : {})", witness.variable, witness.type_symbol);
        pattern.replace_range(index..index + witness.variable.len(), &replacement);
    }
    format!("{pattern}->{rhs}")
}

#[must_use]
pub fn apply_pattern_owner_witnesses(text: &str, witnesses: &[PatternOwnerWitness]) -> String {
    if witnesses.is_empty() {
        return text.to_owned();
    }
    let mut by_line = BTreeMap::<usize, Vec<&PatternOwnerWitness>>::new();
    for witness in witnesses {
        by_line.entry(witness.line_index).or_default().push(witness);
    }
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    for (line_index, witnesses) in by_line {
        if let Some(line) = lines.get_mut(line_index) {
            *line = annotate_pattern_line(line, &witnesses);
        }
    }
    let mut output = lines.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        output.push('\n');
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn recursive_pattern_tree_keeps_only_bindings() {
        assert_eq!(
            bound_variables("Ok (envelope, Some proof)"),
            BTreeSet::from(["envelope".to_owned(), "proof".to_owned()])
        );
    }

    #[test]
    fn pattern_arm_projection_shape_is_local() {
        let source = r#"let render = function
    | Ok envelope ->
        envelope.proof |> ignore
        envelope.planRef |> ignore
        envelope.transaction.transactionRef |> ignore
    | Error missingEvidence ->
        missingEvidence.code |> ignore
        other.code |> ignore"#;
        let projections = pattern_projections(source);
        assert_eq!(projections.len(), 1);
        assert_eq!(projections[0].variable, "envelope");
        assert_eq!(projections[0].first_field, "proof");
        assert_eq!(
            projections[0].projected_fields,
            BTreeSet::from([
                "planRef".to_owned(),
                "proof".to_owned(),
                "transaction".to_owned(),
            ])
        );
    }

    #[test]
    fn pipeline_with_lambda_is_not_a_pattern_arm() {
        let source = r#"let summarize values =
    values
    |> Seq.choose (fun record ->
        record.key |> ignore
        record.state |> ignore
        Some record)"#;
        assert!(pattern_projections(source).is_empty());
    }

    #[test]
    fn witness_annotates_only_pattern_binding() {
        let source = "    | Ok envelope -> envelope.proof\n";
        let witness = PatternOwnerWitness {
            line_index: 0,
            variable: "envelope".to_owned(),
            type_symbol: "Envelope<_>".to_owned(),
            projected_fields: BTreeSet::from(["planRef".to_owned(), "proof".to_owned()]),
        };
        assert_eq!(
            apply_pattern_owner_witnesses(source, &[witness]),
            "    | Ok (envelope : Envelope<_>) -> envelope.proof\n"
        );
    }

    #[test]
    fn local_binding_projection_uses_the_remainder_of_its_block() {
        let source = r#"match lookup with
    | Some lookup ->
        let continuation = getValue lookup
        use continuation.state
        use continuation.continuationRef
    | None -> ()"#;
        let projections = local_record_projections(source);
        assert_eq!(projections.len(), 1);
        assert_eq!(projections[0].variable, "continuation");
        assert_eq!(
            projections[0].projected_fields,
            BTreeSet::from(["continuationRef".to_owned(), "state".to_owned()])
        );
    }

    #[test]
    fn multiline_control_flow_binding_skips_projection_only_owner_inference() {
        let source = r#"let advance fairnessEpoch rawSample =
    let sample =
        match fairnessEpoch with
        | Some epoch -> bindEpoch epoch rawSample
        | None -> rawSample
    use sample.admissionRef
    use sample.fairnessEpochRef"#;
        assert!(local_record_projections(source).is_empty());
    }

    #[test]
    fn inline_control_flow_binding_skips_projection_only_owner_inference() {
        let source = r#"let advance ready left right =
    let sample = if ready then left else right
    use sample.admissionRef
    use sample.fairnessEpochRef"#;
        assert!(local_record_projections(source).is_empty());
    }

    #[test]
    fn local_owner_witness_annotates_only_the_simple_let_binder() {
        let source = "        let continuation = getValue lookup\n        use continuation.state\n";
        let witness = LocalRecordOwnerWitness {
            line_index: 0,
            variable: "continuation".to_owned(),
            type_symbol: "spiral_compiler_Part1288.JpDeclaredRecordTypeFoldBackContinuation"
                .to_owned(),
            projected_fields: BTreeSet::from(["continuationRef".to_owned(), "state".to_owned()]),
        };
        assert_eq!(
            apply_local_record_owner_witnesses(source, &[witness]),
            "        let (continuation : spiral_compiler_Part1288.JpDeclaredRecordTypeFoldBackContinuation) = getValue lookup\n        use continuation.state\n"
        );
    }

    #[test]
    fn shared_lookup_shadow_lambda_reuses_the_proven_local_owner() {
        let source = "match lookup with\n    | Some lookup ->\n        let continuation = extract lookup\n        runner jobId lookup (fun continuation ->\n            use continuation.state)\n";
        let witness = LocalRecordOwnerWitness {
            line_index: 2,
            variable: "continuation".to_owned(),
            type_symbol: "FoldContinuation".to_owned(),
            projected_fields: BTreeSet::from(["continuationRef".to_owned(), "state".to_owned()]),
        };
        assert_eq!(shadow_lambda_lines(source, &witness), vec![3]);
        let lambda_witness = LocalRecordOwnerWitness {
            line_index: 3,
            ..witness
        };
        assert!(
            apply_local_record_owner_witnesses(source, &[lambda_witness])
                .contains("runner jobId lookup (fun (continuation : FoldContinuation) ->")
        );
    }

    #[test]
    fn shadow_lambda_requires_the_same_lookup_witness() {
        let source = "let continuation = extract lookup\nrunner jobId otherLookup (fun continuation -> use continuation.state)\n";
        let witness = LocalRecordOwnerWitness {
            line_index: 0,
            variable: "continuation".to_owned(),
            type_symbol: "FoldContinuation".to_owned(),
            projected_fields: BTreeSet::from(["continuationRef".to_owned(), "state".to_owned()]),
        };
        assert!(shadow_lambda_lines(source, &witness).is_empty());
    }

    #[test]
    fn inferred_local_owner_rejects_generic_type_application() {
        assert!(!local_owner_type_is_renderable("ReplayKey<_>"));
        assert!(!local_owner_type_is_renderable("ReplayKey<'K, 'Token>"));
        assert!(local_owner_type_is_renderable(
            "JpDeclaredRecordTypeFoldBackContinuation"
        ));
        assert!(local_owner_type_is_renderable(
            "spiral_compiler_Part1288.JpDeclaredRecordTypeFoldBackContinuation"
        ));
    }

    #[test]
    fn local_projection_remembers_the_unqualified_rhs_callee() {
        let source = r#"let data = TermCycleFuse.traceFrameData frame
use data.path
use data.fromLine"#;
        let projections = local_record_projections(source);
        assert_eq!(projections.len(), 1);
        assert_eq!(projections[0].rhs_callee.as_deref(), Some("traceFrameData"));
    }

    #[test]
    fn indexed_rhs_is_not_treated_as_a_callee_contract() {
        assert_eq!(local_binding_rhs_callee("let v = scope.[body]"), None);
        assert_eq!(
            local_binding_rhs_callee("let request = authorized.request"),
            None
        );
        assert_eq!(
            local_binding_rhs_callee("let x = inferTop_env_default default_env").as_deref(),
            Some("inferTop_env_default")
        );
        assert_eq!(
            local_binding_rhs_callee("let data = TermCycleFuse.traceFrameData frame").as_deref(),
            Some("traceFrameData")
        );
    }

    #[test]
    fn pure_member_access_rhs_is_fail_closed_for_projection_owner() {
        assert!(local_binding_rhs_is_pure_projection(
            "let stageToken = transaction.actorLease.actorJoin",
            ""
        ));
        assert!(local_binding_rhs_is_pure_projection(
            "let stageToken = (transaction.actorLease.actorJoin)",
            ""
        ));
        assert!(!local_binding_rhs_is_pure_projection(
            "let data = TermCycleFuse.traceFrameData frame",
            ""
        ));
        let inline = r#"let stageToken = transaction.actorLease.actorJoin
consume stageToken.credentialGraphClosureRef
consume stageToken.terminalOrderAdmissionRef"#;
        assert!(local_record_projections(inline).is_empty());
        let multiline = r#"let stageToken =
    (transaction.actorLease.actorJoin)
consume stageToken.credentialGraphClosureRef
consume stageToken.terminalOrderAdmissionRef"#;
        assert!(local_record_projections(multiline).is_empty());
    }

    #[test]
    fn control_flow_derived_helper_returns_are_detected_one_hop() {
        let source = r#"let private terminalFlowPushPossessionHead = function
    | Genesis receipt -> receipt
    | Step(receipt, _) -> receipt

let multiline source =
    match source with
    | Some value -> value
    | None -> fallback

let direct source = transform source"#;
        assert_eq!(
            control_flow_binding_return_names_in_text(source),
            BTreeSet::from([
                "multiline".to_owned(),
                "terminalFlowPushPossessionHead".to_owned(),
            ])
        );
    }

    #[test]
    fn explicit_named_return_type_is_detected_from_binding_header() {
        assert_eq!(
            explicit_binding_return_type("let inferTop_env_default default_env : TopEnv ="),
            Some(("inferTop_env_default".to_owned(), "TopEnv".to_owned()))
        );
        assert_eq!(
            explicit_binding_return_type("let same_shape (x : InferEnv) = x"),
            None
        );
        assert_eq!(
            explicit_binding_return_type("let installed x : TerminalFlowOutcomeAdmission option ="),
            Some((
                "installed".to_owned(),
                "TerminalFlowOutcomeAdmission option".to_owned()
            ))
        );
        assert!(!local_owner_type_is_renderable(
            "TerminalFlowOutcomeAdmission option"
        ));
    }

    #[test]
    fn direct_anonymous_record_return_is_detected_from_function_body() {
        let source = r#"let traceFrameData (frame: TermCycleFuseTraceFrame) =
    {| path = frame.path
       fromLine = frame.fromLine |}"#;
        assert_eq!(
            direct_anonymous_record_return_name(source).as_deref(),
            Some("traceFrameData")
        );
    }

    #[test]
    fn named_or_forwarded_return_is_not_anonymous_record_evidence() {
        let source = r#"let jpDeclaredContinuationLookupValue = function
    | FromSnapshot continuation -> continuation
    | FromLocator continuation -> continuation"#;
        assert_eq!(direct_anonymous_record_return_name(source), None);
    }

    #[test]
    fn anonymous_return_scan_finds_later_helper_in_same_declaration() {
        let source = r#"module TermCycleFuse =
    let traceFrame path =
        { path = path }

    let traceFrameData frame =
        {| path = frame.path
           fromLine = frame.fromLine |}"#;
        assert_eq!(
            direct_anonymous_record_return_names_in_text(source),
            BTreeSet::from(["traceFrameData".to_owned()])
        );
    }
}
