pub use spiral_split_call_scope::unshadowed_projected_fields;
use spiral_split_call_scope::{
    BindingIndex, ParameterContract, binding_body, binding_contract, binding_has_field_projection,
    has_untyped_projection_parameter,
    identifier_continue, identifier_suffix, inferred_binding_type,
    inferred_untyped_parameter_types_with_bindings,
};
#[cfg(test)]
use spiral_split_call_scope::{inferred_untyped_parameter_types, simple_arguments_after_call};
use spiral_split_model::{DeclarationId, SplitPlan};
#[cfg(test)]
use spiral_split_pattern_contract::BoundVariableTypes;
use spiral_split_pattern_contract::analyze_pattern_contracts;
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct CallerParameterType {
    pub symbol: String,
    pub parameter_index: usize,
    pub parameter_name: String,
    pub type_symbol: String,
    /// Number of generic parameters of `type_symbol`; the annotation is rendered with that many `_`
    /// arguments (`T<_>`), because a bare generic type name in an annotation is an F# error.
    pub type_arguments: usize,
}

/// Generic arity of every type declared in the plan (`type Name<'a, 'b>` / `and Name<'a>`), by name.
fn declared_type_arities(plan: &SplitPlan) -> BTreeMap<String, usize> {
    let mut arities = BTreeMap::new();
    for declaration in &plan.declarations {
        for line in declaration.text.lines() {
            let trimmed = line.trim_start();
            let Some(rest) = trimmed.strip_prefix("type ").or_else(|| trimmed.strip_prefix("and ")) else {
                continue;
            };
            let rest = rest.trim_start();
            let name_end = rest
                .find(|character: char| !(character.is_alphanumeric() || character == '_' || character == '\''))
                .unwrap_or(rest.len());
            let (name, tail) = rest.split_at(name_end);
            if name.is_empty() {
                continue;
            }
            let arity = tail
                .strip_prefix('<')
                .and_then(|arguments| arguments.split_once('>'))
                .map_or(0, |(arguments, _)| arguments.split(',').filter(|argument| !argument.trim().is_empty()).count());
            arities.entry(name.to_owned()).or_insert(arity);
        }
    }
    arities
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct CallerContractIndex {
    pub parameter_types: BTreeMap<DeclarationId, Vec<CallerParameterType>>,
    pub type_providers_by_shard: BTreeMap<usize, Vec<usize>>,
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

#[must_use]
pub fn analyze_caller_contracts(
    plan: &SplitPlan,
    type_providers: &BTreeMap<String, usize>,
) -> CallerContractIndex {
    let declaration_shards = declaration_shards(plan);
    let pattern_contracts = analyze_pattern_contracts(plan);
    let mut evidence = BTreeMap::<(DeclarationId, String, usize, String), BTreeSet<String>>::new();
    let mut local_evidence =
        BTreeMap::<(DeclarationId, String, usize, String), BTreeSet<String>>::new();
    let mut local_symbols = BTreeSet::<(DeclarationId, String)>::new();
    // A binding's annotation depends only on its provider, not on the consumer: one scan of the
    // provider's text per (provider, symbol) instead of one per witness edge (~900k on the Hopac core).
    let mut binding_types = BTreeMap::<(DeclarationId, String), Option<String>>::new();
    let mut projection_candidates = BTreeMap::<(DeclarationId, String), bool>::new();
    for consumer in &plan.declarations {
        let pattern_types = pattern_contracts.variable_types.get(&consumer.id);
        let mut visible_binding_types = BTreeMap::<String, BTreeSet<String>>::new();
        for witness in &consumer.witnesses {
            let symbol = witness
                .symbol
                .rsplit_once('.')
                .map_or(witness.symbol.as_str(), |(_, suffix)| suffix);
            if !identifier_suffix(symbol) {
                continue;
            }
            let annotation = binding_types
                .entry((witness.provider, symbol.to_owned()))
                .or_insert_with(|| inferred_binding_type(&plan.declarations[witness.provider.0].text, symbol));
            if let Some(annotation) = annotation.clone() {
                visible_binding_types
                    .entry(symbol.to_owned())
                    .or_default()
                    .insert(annotation);
            }
        }
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
            if !*projection_candidates
                .entry((witness.provider, symbol.to_owned()))
                .or_insert_with(|| has_untyped_projection_parameter(&provider.text, symbol))
            {
                continue;
            }
            for (parameter_index, (parameter_name, type_symbol)) in
                inferred_untyped_parameter_types_with_bindings(
                    &provider.text,
                    symbol,
                    &consumer.text,
                    pattern_types,
                    &visible_binding_types,
                )
            {
                evidence
                    .entry((
                        witness.provider,
                        symbol.to_owned(),
                        parameter_index,
                        parameter_name,
                    ))
                    .or_default()
                    .insert(type_symbol);
            }
        }
        for local in pattern_contracts
            .local_calls
            .get(&consumer.id)
            .into_iter()
            .flatten()
        {
            let Some(contract) = binding_contract(&consumer.text, &local.symbol) else {
                continue;
            };
            let Some(ParameterContract::Inferred { name }) =
                contract.parameters.get(local.argument_index)
            else {
                continue;
            };
            if !binding_has_field_projection(&consumer.text, &local.symbol, name) {
                continue;
            }
            local_symbols.insert((consumer.id, local.symbol.clone()));
            local_evidence
                .entry((
                    consumer.id,
                    local.symbol.clone(),
                    local.argument_index,
                    name.clone(),
                ))
                .or_default()
                .insert(local.type_symbol.clone());
        }
    }

    evidence.retain(|(provider, symbol, _, _), _| {
        !local_symbols.contains(&(*provider, symbol.clone()))
    });
    evidence.extend(local_evidence);

    let type_arities = declared_type_arities(plan);
    let mut parameter_types = BTreeMap::<DeclarationId, Vec<CallerParameterType>>::new();
    for ((provider, symbol, parameter_index, parameter_name), types) in evidence {
        if types.len() != 1 {
            continue;
        }
        let type_symbol = types.into_iter().next().unwrap();
        let provider_shard = declaration_shards[provider.0];
        if let Some(type_provider) = type_providers.get(&type_symbol).copied() {
            if type_provider == provider_shard
                || !plan.shards[provider_shard]
                    .compile_dependencies
                    .contains(&type_provider)
            {
                continue;
            }
        } else if !caller_type_is_qualified(&type_symbol) {
            continue;
        }
        parameter_types
            .entry(provider)
            .or_default()
            .push(CallerParameterType {
                symbol,
                parameter_index,
                parameter_name,
                type_arguments: type_symbol
                    .rsplit('.')
                    .next()
                    .and_then(|name| type_arities.get(name).copied())
                    .unwrap_or(0),
                type_symbol,
            });
    }
    for rows in parameter_types.values_mut() {
        rows.sort();
        rows.dedup();
    }

    let mut by_shard = BTreeMap::<usize, Vec<(usize, usize, String, usize)>>::new();
    for (provider, rows) in &parameter_types {
        let provider_shard = declaration_shards[provider.0];
        for row in rows {
            let Some(type_provider) = type_providers.get(&row.type_symbol).copied() else {
                continue;
            };
            if type_provider == provider_shard
                || !plan.shards[provider_shard]
                    .compile_dependencies
                    .contains(&type_provider)
            {
                continue;
            }
            by_shard.entry(provider_shard).or_default().push((
                provider.0,
                row.parameter_index,
                row.symbol.clone(),
                type_provider,
            ));
        }
    }
    let type_providers_by_shard = by_shard
        .into_iter()
        .map(|(shard, mut rows)| {
            rows.sort();
            let mut seen = BTreeSet::new();
            let ordered = rows
                .into_iter()
                .filter_map(|(_, _, _, provider)| seen.insert(provider).then_some(provider))
                .collect();
            (shard, ordered)
        })
        .collect();

    CallerContractIndex {
        parameter_types,
        type_providers_by_shard,
    }
}

fn binding_symbol(line: &str) -> Option<String> {
    let body = binding_body(line)?;
    let symbol = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    identifier_suffix(&symbol).then_some(symbol)
}

fn binding_header_ranges(
    text: &str,
    wanted: &BTreeSet<String>,
) -> BTreeMap<String, (usize, usize)> {
    let mut result = BTreeMap::new();
    let mut offset = 0usize;
    for line in text.split_inclusive('\n') {
        let source_line = line.trim_end_matches('\n');
        if let Some(symbol) = binding_symbol(source_line)
            && wanted.contains(&symbol)
            && !result.contains_key(&symbol)
            && let Some(equals) = text[offset..].find('=')
        {
            result.insert(symbol, (offset, offset + equals));
        }
        offset += line.len();
    }
    result
}

fn whole_identifier_match(text: &str, start: usize, needle: &str) -> bool {
    let before = text[..start].chars().next_back();
    let after = text[start + needle.len()..].chars().next();
    before.is_none_or(|character| !identifier_continue(character))
        && after.is_none_or(|character| !identifier_continue(character))
}

fn caller_type_leaf(type_symbol: &str) -> String {
    let generic_at = type_symbol.find('<').unwrap_or(type_symbol.len());
    let base = &type_symbol[..generic_at];
    let suffix = &type_symbol[generic_at..];
    format!("{}{}", base.rsplit('.').next().unwrap_or(base), suffix)
}

fn caller_type_is_qualified(type_symbol: &str) -> bool {
    let generic_at = type_symbol.find('<').unwrap_or(type_symbol.len());
    type_symbol[..generic_at].contains('.')
}

fn resolve_parameter_witnesses(witnesses: &[CallerParameterType]) -> Vec<CallerParameterType> {
    let mut grouped = BTreeMap::<(String, String), Vec<&CallerParameterType>>::new();
    for witness in witnesses {
        grouped
            .entry((witness.symbol.clone(), witness.parameter_name.clone()))
            .or_default()
            .push(witness);
    }
    let mut resolved = Vec::new();
    for rows in grouped.values() {
        let types = rows
            .iter()
            .map(|row| row.type_symbol.as_str())
            .collect::<BTreeSet<_>>();
        if types.len() == 1 {
            resolved.push((*rows[0]).clone());
            continue;
        }
        let leaves = types
            .iter()
            .map(|type_symbol| caller_type_leaf(type_symbol))
            .collect::<BTreeSet<_>>();
        if leaves.len() != 1 {
            continue;
        }
        let qualified = rows
            .iter()
            .filter(|row| caller_type_is_qualified(&row.type_symbol))
            .map(|row| row.type_symbol.as_str())
            .collect::<BTreeSet<_>>();
        if qualified.len() != 1 {
            continue;
        }
        let wanted = *qualified.iter().next().expect("one qualified type");
        if let Some(row) = rows.iter().find(|row| row.type_symbol == wanted) {
            resolved.push((**row).clone());
        }
    }
    resolved.sort();
    resolved
}

#[must_use]
pub fn apply_caller_parameter_types(text: &str, witnesses: &[CallerParameterType]) -> String {
    let witnesses = resolve_parameter_witnesses(witnesses);
    let wanted = witnesses
        .iter()
        .map(|witness| witness.symbol.clone())
        .collect::<BTreeSet<_>>();
    let ranges = binding_header_ranges(text, &wanted);
    let mut edits = Vec::<(usize, usize, String)>::new();
    for witness in &witnesses {
        let Some((start, end)) = ranges.get(&witness.symbol).copied() else {
            continue;
        };
        let header = &text[start..end];
        let Some(symbol_at) = header.find(&witness.symbol) else {
            continue;
        };
        let mut search = symbol_at + witness.symbol.len();
        let mut parameter_at = None;
        while let Some(relative) = header[search..].find(&witness.parameter_name) {
            let index = search + relative;
            if whole_identifier_match(header, index, &witness.parameter_name) {
                parameter_at = Some(index);
                break;
            }
            search = index + witness.parameter_name.len();
        }
        let Some(parameter_at) = parameter_at else {
            continue;
        };
        let absolute = start + parameter_at;
        let type_arguments = if witness.type_arguments > 0 && !witness.type_symbol.contains('<') {
            format!("<{}>", vec!["_"; witness.type_arguments].join(","))
        } else {
            String::new()
        };
        edits.push((
            absolute,
            absolute + witness.parameter_name.len(),
            format!("({} : {}{type_arguments})", witness.parameter_name, witness.type_symbol),
        ));
    }
    edits.sort_by(|left, right| right.0.cmp(&left.0).then(right.1.cmp(&left.1)));
    edits.dedup();
    let mut output = text.to_owned();
    for (start, end, replacement) in edits {
        output.replace_range(start..end, &replacement);
    }
    output
}

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct HigherOrderArrayReturnShape {
    pub symbol: String,
    pub parameter_index: usize,
    pub parameter_name: String,
    pub function_arity: usize,
    pub element_type: String,
}

fn union_case_owners(plan: &SplitPlan) -> BTreeMap<String, String> {
    let mut candidates = BTreeMap::<String, BTreeSet<String>>::new();
    for declaration in &plan.declarations {
        let mut owner = None::<String>;
        let mut type_indent = None::<usize>;
        for line in declaration.text.lines() {
            let trimmed = line.trim_start();
            let indent = line.len() - trimmed.len();
            if trimmed.is_empty() || trimmed.starts_with("//") || trimmed.starts_with("[<") {
                continue;
            }
            if let Some(body) = trimmed.strip_prefix("type ")
                && let Some((head, _)) = body.split_once('=')
            {
                let head = head.trim();
                let symbol = head
                    .chars()
                    .take_while(|character| identifier_continue(*character))
                    .collect::<String>();
                let rest = head[symbol.len()..].trim();
                if identifier_suffix(&symbol) && (rest.is_empty() || rest.starts_with('<')) {
                    owner = Some(symbol);
                    type_indent = Some(indent);
                    continue;
                }
            }
            if owner.is_some()
                && type_indent == Some(indent)
                && let Some(body) = trimmed.strip_prefix("and ")
                && let Some((head, _)) = body.split_once('=')
            {
                let head = head.trim();
                let symbol = head
                    .chars()
                    .take_while(|character| identifier_continue(*character))
                    .collect::<String>();
                let rest = head[symbol.len()..].trim();
                if identifier_suffix(&symbol) && (rest.is_empty() || rest.starts_with('<')) {
                    owner = Some(symbol);
                    continue;
                }
            }
            let Some(current) = owner.as_ref() else {
                continue;
            };
            let Some(group_indent) = type_indent else {
                continue;
            };
            if indent <= group_indent {
                owner = None;
                type_indent = None;
                continue;
            }
            let Some(pattern) = trimmed.strip_prefix('|') else {
                continue;
            };
            let case = pattern
                .trim_start()
                .chars()
                .take_while(|character| identifier_continue(*character))
                .collect::<String>();
            if case.chars().next().is_some_and(char::is_uppercase) {
                candidates.entry(case).or_default().insert(current.clone());
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(case, owners)| {
            (owners.len() == 1).then(|| (case, owners.into_iter().next().unwrap()))
        })
        .collect()
}

/// `binding_scope_text` for every symbol of one text in a single pass. A scope opens at the first line
/// binding its symbol and closes at the next binding line indented no deeper; open scopes nest, so they
/// form a stack ordered by indentation.
fn binding_scopes(text: &str) -> BTreeMap<String, (usize, usize)> {
    let mut result = BTreeMap::new();
    let mut open = Vec::<(String, usize, usize)>::new(); // symbol, indent, start offset
    let mut offset = 0usize;
    for line in text.split_inclusive('\n') {
        let source = line.trim_end_matches('\n');
        let trimmed = source.trim_start();
        if let Some(symbol) = binding_symbol(source) {
            let indent = source.len() - trimmed.len();
            while open.last().is_some_and(|(_, open_indent, _)| indent <= *open_indent) {
                let (closed, _, start) = open.pop().unwrap();
                result.insert(closed, (start, offset));
            }
            if !result.contains_key(&symbol) && !open.iter().any(|(name, _, _)| *name == symbol) {
                open.push((symbol, indent, offset));
            }
        }
        offset += line.len();
    }
    for (symbol, _, start) in open {
        result.insert(symbol, (start, text.len()));
    }
    result
}

#[allow(dead_code)]
fn binding_scope_text<'a>(text: &'a str, symbol: &str) -> Option<&'a str> {
    let mut offset = 0usize;
    let mut start = None;
    let mut binding_indent = 0usize;
    for line in text.split_inclusive('\n') {
        let source = line.trim_end_matches('\n');
        if start.is_none() {
            if binding_symbol(source).as_deref() == Some(symbol) {
                start = Some(offset);
                binding_indent = source.len() - source.trim_start().len();
            }
        } else {
            let trimmed = source.trim_start();
            if !trimmed.is_empty()
                && source.len() - trimmed.len() <= binding_indent
                && binding_symbol(source).is_some()
            {
                return start.map(|start| &text[start..offset]);
            }
        }
        offset += line.len();
    }
    start.map(|start| &text[start..])
}

fn pair_call_result(scope: &str, parameter: &str) -> Option<String> {
    for line in scope.lines() {
        let Some(body) = line.trim_start().strip_prefix("let ") else {
            continue;
        };
        let Some((left, right)) = body.split_once('=') else {
            continue;
        };
        let mut pair = left.split(',').map(str::trim);
        let Some(first) = pair.next() else {
            continue;
        };
        let Some(second) = pair.next() else {
            continue;
        };
        if pair.next().is_some() || !identifier_suffix(first) || !identifier_suffix(second) {
            continue;
        }
        let right = right.trim_start();
        if right
            .strip_prefix(parameter)
            .is_some_and(|rest| rest.chars().next().is_some_and(char::is_whitespace))
        {
            return Some(first.to_owned());
        }
    }
    None
}

fn indexed_match_owner(
    scope: &str,
    value: &str,
    case_owners: &BTreeMap<String, String>,
) -> Option<String> {
    if !scope.contains(&format!("{value}.Length")) || !scope.contains(&format!("{value}.[")) {
        return None;
    }
    let lines = scope.lines().collect::<Vec<_>>();
    let match_at = lines
        .iter()
        .position(|line| line.contains("match ") && line.contains(&format!("{value}.[")))?;
    let mut owners = BTreeSet::new();
    let mut case_indent = None::<usize>;
    for line in lines.iter().skip(match_at + 1).take(24) {
        let trimmed = line.trim_start();
        if trimmed.is_empty() {
            continue;
        }
        let indent = line.len() - trimmed.len();
        let Some(after_bar) = trimmed.strip_prefix('|') else {
            if case_indent.is_some_and(|wanted| indent < wanted) {
                break;
            }
            continue;
        };
        let wanted = *case_indent.get_or_insert(indent);
        if indent != wanted {
            continue;
        }
        let Some((pattern, _)) = after_bar.split_once("->") else {
            continue;
        };
        for token in pattern.split(|character: char| !identifier_continue(character)) {
            if token.chars().next().is_some_and(char::is_uppercase)
                && let Some(owner) = case_owners.get(token)
            {
                owners.insert(owner.clone());
            }
        }
    }
    (owners.len() == 1).then(|| owners.into_iter().next().unwrap())
}

fn unique_binding_arities(plan: &SplitPlan) -> BTreeMap<String, usize> {
    let mut candidates = BTreeMap::<String, BTreeSet<usize>>::new();
    for declaration in &plan.declarations {
        let index = BindingIndex::new(&declaration.text);
        for line in declaration.text.lines() {
            let Some(symbol) = binding_symbol(line) else {
                continue;
            };
            if let Some(contract) = index.contract(&symbol) {
                candidates
                    .entry(symbol)
                    .or_default()
                    .insert(contract.parameters.len());
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(symbol, arities)| {
            (arities.len() == 1).then(|| (symbol, arities.into_iter().next().unwrap()))
        })
        .collect()
}

#[must_use]
pub fn analyze_higher_order_array_returns(
    plan: &SplitPlan,
) -> BTreeMap<DeclarationId, Vec<HigherOrderArrayReturnShape>> {
    let case_owners = union_case_owners(plan);
    let arities = unique_binding_arities(plan);
    let mut result = BTreeMap::<DeclarationId, Vec<HigherOrderArrayReturnShape>>::new();
    for declaration in &plan.declarations {
        let index = BindingIndex::new(&declaration.text);
        let scopes = binding_scopes(&declaration.text);
        for line in declaration.text.lines() {
            let Some(symbol) = binding_symbol(line) else {
                continue;
            };
            let Some(contract) = index.contract(&symbol) else {
                continue;
            };
            let Some(scope) = scopes
                .get(&symbol)
                .map(|(start, end)| &declaration.text[*start..*end])
            else {
                continue;
            };
            for (parameter_index, parameter) in contract.parameters.iter().enumerate() {
                let ParameterContract::Inferred { name } = parameter else {
                    continue;
                };
                let Some(function_arity) = arities.get(name).copied().filter(|arity| *arity > 0)
                else {
                    continue;
                };
                let Some(value) = pair_call_result(scope, name) else {
                    continue;
                };
                let Some(element_type) = indexed_match_owner(scope, &value, &case_owners) else {
                    continue;
                };
                result
                    .entry(declaration.id)
                    .or_default()
                    .push(HigherOrderArrayReturnShape {
                        symbol: symbol.clone(),
                        parameter_index,
                        parameter_name: name.clone(),
                        function_arity,
                        element_type,
                    });
            }
        }
    }
    for rows in result.values_mut() {
        rows.sort();
        rows.dedup();
    }
    result
}

#[must_use]
pub fn apply_higher_order_array_returns(
    text: &str,
    witnesses: &[HigherOrderArrayReturnShape],
) -> String {
    let wanted = witnesses
        .iter()
        .map(|witness| witness.symbol.clone())
        .collect::<BTreeSet<_>>();
    let ranges = binding_header_ranges(text, &wanted);
    let mut edits = Vec::new();
    for witness in witnesses {
        let Some((start, end)) = ranges.get(&witness.symbol).copied() else {
            continue;
        };
        let header = &text[start..end];
        let mut search = 0usize;
        let mut parameter_at = None;
        while let Some(relative) = header[search..].find(&witness.parameter_name) {
            let index = search + relative;
            if whole_identifier_match(header, index, &witness.parameter_name) {
                parameter_at = Some(index);
                break;
            }
            search = index + witness.parameter_name.len();
        }
        let Some(parameter_at) = parameter_at else {
            continue;
        };
        let arrows = "_ -> ".repeat(witness.function_arity);
        edits.push((
            start + parameter_at,
            start + parameter_at + witness.parameter_name.len(),
            format!(
                "({} : {}{} array * _)",
                witness.parameter_name, arrows, witness.element_type
            ),
        ));
    }
    edits.sort_by(|left, right| right.0.cmp(&left.0).then(right.1.cmp(&left.1)));
    edits.dedup();
    let mut output = text.to_owned();
    for (start, end, replacement) in edits {
        output.replace_range(start..end, &replacement);
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn indexed_contracts_and_scopes_match_the_rescanning_versions() {
        let text = "let outer a (b : T) =
    let inner x = x
    let inner y = y + 1
    let pair f = f 1
    and other z = z
let later<'t> q = q
let outer again = 0
let tail (u : U) v =
        let deep w = w
";
        let index = BindingIndex::new(text);
        let scopes = binding_scopes(text);
        for symbol in ["outer", "inner", "pair", "other", "later", "tail", "deep", "missing"] {
            assert_eq!(index.contract(symbol), binding_contract(text, symbol), "contract {symbol}");
            assert_eq!(
                scopes.get(symbol).map(|(start, end)| &text[*start..*end]),
                binding_scope_text(text, symbol),
                "scope {symbol}"
            );
        }
    }

    fn synthetic_plan(texts: &[&str]) -> SplitPlan {
        use spiral_split_model::{
            BoundaryReason, CompilerProfile, Declaration, DeclarationKind, LineSpan, Linked,
            ReferenceMode, SourceText, SplitPolicy,
        };
        use std::path::PathBuf;

        let declarations = texts
            .iter()
            .enumerate()
            .map(|(index, text)| {
                Declaration::<Linked>::new(
                    DeclarationId(index),
                    LineSpan {
                        start: 0,
                        end: text.lines().count(),
                    },
                    format!("decl-{index}"),
                    (*text).to_owned(),
                    BoundaryReason::TopLevel(DeclarationKind::Other),
                    Vec::new(),
                    0,
                )
            })
            .collect();
        SplitPlan {
            source: SourceText {
                path: PathBuf::from("synthetic.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "Synthetic".to_owned(),
                profile: CompilerProfile::Unknown,
                fingerprint: 0,
                bytes: 0,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations,
            shards: Vec::new(),
        }
    }

    #[test]
    fn typed_bind_owner_survives_mutually_recursive_type_group_without_leaking() {
        let type_group = r#"type TypedBind =
    | TyLet of Data * Trace * TypedOp
    | TyLocalReturnOp of Trace * TypedOp * Data
    | TyLocalReturnData of Data * Trace
and TypedOp =
    | TyIf of Data * Data * Data"#;
        let leaked_record_scope = r#"type CFunRecC = { tag : int; range : Ty }

let codegen binds =
    match binds with
    | TyLocalReturnOp(_,op,_) -> op
    | TyLocalReturnData(data,_) -> data"#;
        let plan = synthetic_plan(&[type_group, leaked_record_scope]);
        let owners = union_case_owners(&plan);
        assert_eq!(
            owners.get("TyLocalReturnOp").map(String::as_str),
            Some("TypedBind")
        );
        assert_eq!(
            owners.get("TyLocalReturnData").map(String::as_str),
            Some("TypedBind")
        );
    }

    #[test]
    fn higher_order_pair_array_shape_is_narrow_and_structural() {
        let scope = r#"let lifted term_scope' s on_succ =
    let tr, type_tr = term_scope' s true on_succ
    if tr.Length = 1 then
        match tr.[0] with
        | TyLocalReturnOp(_,op,_) -> op
        | TyLocalReturnData(data,_) -> data
    else failwith \"shape\""#;
        assert_eq!(
            pair_call_result(scope, "term_scope'"),
            Some("tr".to_owned())
        );
        let owners = BTreeMap::from([
            ("TyLocalReturnOp".to_owned(), "TypedBind".to_owned()),
            ("TyLocalReturnData".to_owned(), "TypedBind".to_owned()),
        ]);
        assert_eq!(
            indexed_match_owner(scope, "tr", &owners),
            Some("TypedBind".to_owned())
        );
        let witness = HigherOrderArrayReturnShape {
            symbol: "lifted".to_owned(),
            parameter_index: 0,
            parameter_name: "term_scope'".to_owned(),
            function_arity: 3,
            element_type: "TypedBind".to_owned(),
        };
        assert_eq!(
            apply_higher_order_array_returns(
                "let lifted term_scope' s on_succ = term_scope' s true on_succ\n",
                &[witness],
            ),
            "let lifted (term_scope' : _ -> _ -> _ -> TypedBind array * _) s on_succ = term_scope' s true on_succ\n"
        );
    }

    #[test]
    fn higher_order_shape_fails_closed_without_indexed_array_evidence() {
        let scope = "let lifted f x =\n    let value, ty = f x\n    value |> consume\n";
        let owners = BTreeMap::from([("Case".to_owned(), "Payload".to_owned())]);
        assert_eq!(pair_call_result(scope, "f"), Some("value".to_owned()));
        assert_eq!(indexed_match_owner(scope, "value", &owners), None);
    }

    #[test]
    fn binding_contract_preserves_typed_and_inferred_parameter_positions() {
        let contract = binding_contract(
            "let prepassModule_open (top_env : PrepassTopEnv) env a l = env.term",
            "prepassModule_open",
        )
        .unwrap();
        assert_eq!(
            contract.parameters,
            vec![
                ParameterContract::Explicit {
                    name: "top_env".to_owned(),
                    type_symbol: "PrepassTopEnv".to_owned(),
                },
                ParameterContract::Inferred {
                    name: "env".to_owned(),
                },
                ParameterContract::Inferred {
                    name: "a".to_owned(),
                },
                ParameterContract::Inferred {
                    name: "l".to_owned(),
                },
            ]
        );
    }

    #[test]
    fn recursive_group_supplies_unique_caller_type_for_untyped_provider_parameter() {
        let provider = "let prepassModule_open (top_env : PrepassTopEnv) env a l = env.term";
        let consumer = r#"let rec pattern_match (env : PartEvalPrepassEnv) r body clauses = body
and ty' case_metavar (env : PartEvalPrepassEnv) x = x
and term env x =
    match x with
    | RawOpen (_,a,l,on_succ) -> term (prepassModule_open top_env env a l) on_succ"#;
        assert_eq!(
            inferred_untyped_parameter_types(provider, "prepassModule_open", consumer, None),
            BTreeMap::from([(1usize, ("env".to_owned(), "PartEvalPrepassEnv".to_owned()),)])
        );
    }

    #[test]
    fn conflicting_caller_annotations_do_not_produce_contract_evidence() {
        let provider = "let helper env value = env.term";
        let consumer = r#"let first (env : FirstEnv) = helper env 1
let second (env : SecondEnv) = helper env 2"#;
        assert!(inferred_untyped_parameter_types(provider, "helper", consumer, None).is_empty());
    }

    #[test]
    fn later_same_name_annotation_does_not_flow_back_into_earlier_call() {
        let provider = "let helper ty value = ty.term";
        let consumer = r#"let caller ty = helper ty 1
let ty : Ty = failwith \"shadow\""#;
        assert!(inferred_untyped_parameter_types(provider, "helper", consumer, None).is_empty());
    }

    #[test]
    fn projected_argument_does_not_impersonate_direct_caller_type_evidence() {
        let provider = "let isActive context = context.nesting > 0";
        let consumer = "let check (s : LangEnv) = isActive s.bigStack";
        assert!(inferred_untyped_parameter_types(provider, "isActive", consumer, None).is_empty());
    }

    #[test]
    fn forwarded_scalar_parameter_does_not_take_a_caller_type() {
        let provider = "let error_char i er = Error [range_char i, er]";
        let consumer = "let parse_error (i : Tokenizer) er = error_char i er";
        assert!(
            inferred_untyped_parameter_types(provider, "error_char", consumer, None).is_empty()
        );
    }

    #[test]
    fn local_pattern_type_beats_unrelated_same_name_annotation() {
        let provider = "let validate_mvar_unification i x = i.scope";
        let consumer = "let unrelated (a : GlobalId) = a\nlet loop x = match x with | TyMetavar(a,link), b -> validate_mvar_unification a b";
        let patterns =
            BoundVariableTypes::from([("a".to_owned(), BTreeSet::from(["MVar".to_owned()]))]);
        assert_eq!(
            inferred_untyped_parameter_types(
                provider,
                "validate_mvar_unification",
                consumer,
                Some(&patterns),
            ),
            BTreeMap::from([(0usize, ("i".to_owned(), "MVar".to_owned()))])
        );
    }

    #[test]
    fn field_projection_evidence_is_scoped_to_the_target_binding() {
        let declaration = r#"let unrelated (x : SymbolString) = x.text
let loop state x =
    match x with
    | PatValue _ -> state
let caller (x : SymbolString) state = loop state x"#;
        assert!(binding_has_field_projection(declaration, "unrelated", "x"));
        assert!(!binding_has_field_projection(declaration, "loop", "x"));
        assert!(
            inferred_untyped_parameter_types(declaration, "loop", declaration, None).is_empty()
        );
    }

    #[test]
    fn nested_pattern_shadow_does_not_impersonate_outer_parameter_projection() {
        let shadow_only = r#"let validate top x =
    match top with
    | Ok x ->
        consume x.term
    match x with
    | Choice1Of2 value -> consume value
    | Choice2Of2 value -> consume value
"#;
        assert!(!binding_has_field_projection(shadow_only, "validate", "x"));

        let outer_use = r#"let validate top x =
    match top with
    | Ok x -> consume x.term
    consume x.term
"#;
        assert!(binding_has_field_projection(outer_use, "validate", "x"));
    }

    #[test]
    fn nested_binding_shadow_does_not_impersonate_outer_parameter_projection() {
        let source = r#"let validate top x =
    let rec cterm state x =
        consume x.term
    and ctype state x =
        consume x.ty
    match x with
    | Choice1Of2 value -> consume value
    | Choice2Of2 value -> consume value
"#;
        assert!(unshadowed_projected_fields(source, "x").is_empty());

        let outer_use = r#"let validate top x =
    let nested x = consume x.term
    consume x.term
"#;
        assert_eq!(
            unshadowed_projected_fields(outer_use, "x"),
            BTreeSet::from(["term".to_owned()])
        );
    }

    #[test]
    fn call_parser_reads_simple_identifier_arguments_inside_parentheses() {
        assert_eq!(
            simple_arguments_after_call("term (helper top_env env a l) on_succ", "helper")
                .into_iter()
                .map(|call| call.arguments)
                .collect::<Vec<_>>(),
            vec![vec![
                Some("top_env".to_owned()),
                Some("env".to_owned()),
                Some("a".to_owned()),
                Some("l".to_owned()),
            ]]
        );
    }

    #[test]
    fn caller_type_is_materialized_only_on_the_untyped_parameter() {
        let source = "let prepassModule_open (top_env : PrepassTopEnv) env a l = env.term\n";
        let witness = CallerParameterType {
            type_arguments: 0,
            symbol: "prepassModule_open".to_owned(),
            parameter_index: 1,
            parameter_name: "env".to_owned(),
            type_symbol: "PartEvalPrepassEnv".to_owned(),
        };
        assert_eq!(
            apply_caller_parameter_types(source, &[witness]),
            "let prepassModule_open (top_env : PrepassTopEnv) (env : PartEvalPrepassEnv) a l = env.term\n"
        );
    }

    #[test]
    fn multiple_parameter_edits_do_not_shift_later_offsets() {
        let source = "let helper first second = first.scope + second.scope\n";
        let witnesses = [
            CallerParameterType {
                type_arguments: 0,
                symbol: "helper".to_owned(),
                parameter_index: 0,
                parameter_name: "first".to_owned(),
                type_symbol: "First".to_owned(),
            },
            CallerParameterType {
                type_arguments: 0,
                symbol: "helper".to_owned(),
                parameter_index: 1,
                parameter_name: "second".to_owned(),
                type_symbol: "Second".to_owned(),
            },
        ];
        assert_eq!(
            apply_caller_parameter_types(source, &witnesses),
            "let helper (first : First) (second : Second) = first.scope + second.scope\n"
        );
    }

    #[test]
    fn duplicate_parameter_evidence_prefers_one_qualified_refinement() {
        let source = "let terminalFlowKernelStageCode kernel = kernel.invariant\n";
        let witnesses = [
            CallerParameterType {
                type_arguments: 0,
                symbol: "terminalFlowKernelStageCode".to_owned(),
                parameter_index: 0,
                parameter_name: "kernel".to_owned(),
                type_symbol: "TerminalFlowKernelState".to_owned(),
            },
            CallerParameterType {
                type_arguments: 0,
                symbol: "terminalFlowKernelStageCode".to_owned(),
                parameter_index: 0,
                parameter_name: "kernel".to_owned(),
                type_symbol: "spiral_compiler_Part0764.TerminalFlowKernelState".to_owned(),
            },
        ];
        assert_eq!(
            apply_caller_parameter_types(source, &witnesses),
            "let terminalFlowKernelStageCode (kernel : spiral_compiler_Part0764.TerminalFlowKernelState) = kernel.invariant\n"
        );
    }

    #[test]
    fn conflicting_parameter_evidence_fails_closed_without_edit() {
        let source = "let helper value = value.term\n";
        let witnesses = [
            CallerParameterType {
                type_arguments: 0,
                symbol: "helper".to_owned(),
                parameter_index: 0,
                parameter_name: "value".to_owned(),
                type_symbol: "InferEnv".to_owned(),
            },
            CallerParameterType {
                type_arguments: 0,
                symbol: "helper".to_owned(),
                parameter_index: 0,
                parameter_name: "value".to_owned(),
                type_symbol: "RawExpr".to_owned(),
            },
        ];
        assert_eq!(apply_caller_parameter_types(source, &witnesses), source);
    }
}
