use spiral_split_call_contract::{CallerContractIndex, CallerParameterType};
use spiral_split_call_scope::{
    BindingContract, ParameterContract, binding_body, binding_contract, identifier_continue,
    identifier_suffix, simple_arguments_after_call,
};
use spiral_split_fsharp_lex::code_only_mask;
use spiral_split_model::{DeclarationId, SplitPlan};
use std::collections::{BTreeMap, BTreeSet, VecDeque};

#[derive(Clone, Debug, Eq, PartialEq)]
enum PrimitiveReference {
    Bool,
}

#[derive(Clone, Debug, Eq, PartialEq)]
enum BindingTypeEvidence {
    Annotated(String),
    Object,
    Reference(PrimitiveReference),
    Constructor(String),
    QualifiedConstructor(String),
    StaticFactory(String),
}

impl BindingTypeEvidence {
    fn type_text(
        &self,
        plan: &SplitPlan,
        type_providers: &BTreeMap<String, usize>,
    ) -> Option<String> {
        match self {
            Self::Annotated(type_text) => Some(type_text.clone()),
            Self::Object => Some("obj".to_owned()),
            Self::Reference(PrimitiveReference::Bool) => Some("bool ref".to_owned()),
            Self::QualifiedConstructor(type_text) | Self::StaticFactory(type_text) => {
                Some(type_text.clone())
            }
            Self::Constructor(type_text) => {
                let symbol = type_leaf(type_text);
                let provider = type_providers.get(symbol)?;
                declares_non_generic_type(plan, *provider, symbol).then(|| type_text.clone())
            }
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
struct ForwardKey {
    provider: DeclarationId,
    symbol: String,
    parameter_index: usize,
    parameter_name: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
enum ArgumentSource {
    Local(String),
    Forwarded {
        consumer: DeclarationId,
        parameter_name: String,
    },
    Unsupported,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
struct ForwardSlot {
    sources: Vec<ArgumentSource>,
    complete: bool,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct ScopedLocalType {
    offset: usize,
    indent: usize,
    type_text: String,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
struct DeclarationTypeScope {
    unique_parameters: BTreeSet<String>,
    local_types: BTreeMap<String, Vec<ScopedLocalType>>,
}

impl DeclarationTypeScope {
    fn build(
        plan: &SplitPlan,
        declaration: DeclarationId,
        type_providers: &BTreeMap<String, usize>,
    ) -> Self {
        let text = &plan.declarations[declaration.0].text;
        let mut binding_heads = Vec::<(String, usize)>::new();
        let mut local_types = BTreeMap::<String, Vec<ScopedLocalType>>::new();
        let mut offset = 0usize;
        for line in text.split_inclusive('\n') {
            let source_line = line.trim_end_matches('\n');
            let indent = source_line
                .chars()
                .take_while(|character| character.is_whitespace())
                .count();
            if let Some(symbol) = binding_symbol(source_line) {
                binding_heads.push((symbol, indent));
            }
            if let Some((name, evidence)) = simple_value_binding_evidence(source_line)
                && let Some(type_text) = evidence.type_text(plan, type_providers)
            {
                local_types.entry(name).or_default().push(ScopedLocalType {
                    offset,
                    indent,
                    type_text,
                });
            }
            offset += line.len();
        }

        let minimum_indent = binding_heads.iter().map(|(_, indent)| *indent).min();
        let mut top_symbols = binding_heads
            .into_iter()
            .filter_map(|(symbol, indent)| (Some(indent) == minimum_indent).then_some(symbol))
            .collect::<Vec<_>>();
        top_symbols.sort();
        top_symbols.dedup();
        let mut parameter_counts = BTreeMap::<String, usize>::new();
        for symbol in top_symbols {
            let Some(contract) = binding_contract(text, &symbol) else {
                continue;
            };
            for parameter in contract.parameters {
                let name = match parameter {
                    ParameterContract::Explicit { name, .. }
                    | ParameterContract::Inferred { name } => name,
                    ParameterContract::Pattern => continue,
                };
                *parameter_counts.entry(name).or_default() += 1;
            }
        }
        let unique_parameters = parameter_counts
            .into_iter()
            .filter_map(|(name, count)| (count == 1).then_some(name))
            .collect();
        Self {
            unique_parameters,
            local_types,
        }
    }

    fn local_type(&self, name: &str, call_offset: usize, call_indent: usize) -> Option<String> {
        let mut candidates = BTreeSet::<String>::new();
        for evidence in self.local_types.get(name).into_iter().flatten() {
            if evidence.offset < call_offset && evidence.indent <= call_indent {
                candidates.insert(evidence.type_text.clone());
            }
        }
        one_compatible_type(candidates.iter())
    }
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

fn binding_symbol(line: &str) -> Option<String> {
    let body = binding_body(line)?;
    let symbol = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    identifier_suffix(&symbol).then_some(symbol)
}

fn simple_value_binding_evidence(line: &str) -> Option<(String, BindingTypeEvidence)> {
    let body = binding_body(line)?;
    let symbol = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    if !identifier_suffix(&symbol) {
        return None;
    }
    let tail = body.get(symbol.len()..)?;
    let (header, rhs) = tail.split_once('=')?;
    let header = header.trim();
    if !header.is_empty() {
        let type_text = header.strip_prefix(':')?.trim();
        if type_text.is_empty() {
            return None;
        }
        return Some((symbol, BindingTypeEvidence::Annotated(type_text.to_owned())));
    }

    let rhs = rhs.split_once("//").map_or(rhs, |(body, _)| body).trim();
    if matches!(rhs, "obj()" | "obj ()") {
        return Some((symbol, BindingTypeEvidence::Object));
    }
    if matches!(rhs, "ref false" | "ref true") {
        return Some((
            symbol,
            BindingTypeEvidence::Reference(PrimitiveReference::Bool),
        ));
    }

    let rhs = rhs.strip_prefix("new ").unwrap_or(rhs);
    let open = rhs.find('(')?;
    let candidate = rhs[..open].trim();
    if let Some(owner_type) = candidate.strip_suffix(".StartNew") {
        let owner_leaf = owner_type.rsplit('.').next()?;
        if identifier_suffix(owner_leaf)
            && owner_leaf.chars().next().is_some_and(char::is_uppercase)
        {
            return Some((
                symbol,
                BindingTypeEvidence::StaticFactory(owner_type.to_owned()),
            ));
        }
    }
    let generic_at = candidate.find('<').unwrap_or(candidate.len());
    let head = candidate[..generic_at].trim();
    let leaf = head.rsplit('.').next()?;
    if !identifier_suffix(leaf) || !leaf.chars().next().is_some_and(char::is_uppercase) {
        return None;
    }
    let evidence = if candidate.contains('.') {
        BindingTypeEvidence::QualifiedConstructor(candidate.to_owned())
    } else if generic_at < candidate.len() {
        return None;
    } else {
        BindingTypeEvidence::Constructor(candidate.to_owned())
    };
    Some((symbol, evidence))
}

fn declares_non_generic_type(plan: &SplitPlan, provider_shard: usize, symbol: &str) -> bool {
    let Some(shard) = plan.shards.get(provider_shard) else {
        return false;
    };
    shard.declarations.iter().any(|declaration_id| {
        plan.declarations[declaration_id.0]
            .text
            .lines()
            .any(|line| {
                let line = line.trim_start();
                let Some(rest) = line
                    .strip_prefix("type ")
                    .or_else(|| line.strip_prefix("and "))
                else {
                    return false;
                };
                let Some(tail) = rest.strip_prefix(symbol) else {
                    return false;
                };
                if tail.starts_with('<') {
                    return false;
                }
                tail.starts_with('(')
                    || tail.starts_with(" =")
                    || tail.starts_with('=')
                    || tail.starts_with(char::is_whitespace)
            })
    })
}

fn call_line_indent(text: &str, call_offset: usize) -> usize {
    let start = text[..call_offset.min(text.len())]
        .rfind('\n')
        .map_or(0, |index| index + 1);
    text[start..]
        .chars()
        .take_while(|character| character.is_whitespace() && *character != '\n')
        .count()
}

fn type_leaf(type_text: &str) -> &str {
    let before_ref = type_text.strip_suffix(" ref").unwrap_or(type_text);
    let generic_at = before_ref.find('<').unwrap_or(before_ref.len());
    before_ref[..generic_at]
        .trim()
        .rsplit('.')
        .next()
        .unwrap_or(before_ref)
}

fn canonical_type(type_text: &str) -> String {
    let suffix = if type_text.ends_with(" ref") {
        " ref"
    } else {
        ""
    };
    let base = type_text.strip_suffix(suffix).unwrap_or(type_text);
    let generic_at = base.find('<').unwrap_or(base.len());
    let head = base[..generic_at]
        .trim()
        .rsplit('.')
        .next()
        .unwrap_or(base[..generic_at].trim());
    format!("{}{}{}", head, &base[generic_at..], suffix)
}

fn one_compatible_type<'a>(types: impl IntoIterator<Item = &'a String>) -> Option<String> {
    let mut canonical = BTreeSet::new();
    let mut qualified = BTreeSet::new();
    let mut first = None::<String>;
    for type_text in types {
        first.get_or_insert_with(|| type_text.clone());
        canonical.insert(canonical_type(type_text));
        if type_text.contains('.') {
            qualified.insert(type_text.clone());
        }
    }
    if canonical.len() != 1 {
        return None;
    }
    if qualified.len() == 1 {
        return qualified.into_iter().next();
    }
    first
}

fn seed_name_types(
    scopes: &[DeclarationTypeScope],
    seeds: &BTreeMap<DeclarationId, Vec<CallerParameterType>>,
) -> BTreeMap<(DeclarationId, String), String> {
    let mut candidates = BTreeMap::<(DeclarationId, String), BTreeSet<String>>::new();
    for (declaration, rows) in seeds {
        for row in rows {
            if scopes[declaration.0]
                .unique_parameters
                .contains(&row.parameter_name)
            {
                candidates
                    .entry((*declaration, row.parameter_name.clone()))
                    .or_default()
                    .insert(row.type_symbol.clone());
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(key, values)| one_compatible_type(values.iter()).map(|value| (key, value)))
        .collect()
}

fn cached_contract<'a>(
    plan: &SplitPlan,
    cache: &'a mut BTreeMap<(DeclarationId, String), Option<BindingContract>>,
    provider: DeclarationId,
    symbol: &str,
) -> Option<&'a BindingContract> {
    let key = (provider, symbol.to_owned());
    if !cache.contains_key(&key) {
        cache.insert(
            key.clone(),
            binding_contract(&plan.declarations[provider.0].text, symbol),
        );
    }
    cache.get(&key).and_then(Option::as_ref)
}

fn explicit_parameter_type_text(text: &str, symbol: &str, parameter_name: &str) -> Option<String> {
    let mut header = String::new();
    let mut collecting = false;
    for line in text.lines() {
        if !collecting {
            if binding_symbol(line).as_deref() != Some(symbol) {
                continue;
            }
            collecting = true;
        }
        if !header.is_empty() {
            header.push(' ');
        }
        header.push_str(line.trim());
        if line.contains('=') {
            break;
        }
    }
    if header.is_empty() {
        return None;
    }
    let bytes = header.as_bytes();
    let mut cursor = 0usize;
    while cursor < bytes.len() {
        if bytes[cursor] != b'(' {
            cursor += 1;
            continue;
        }
        let open = cursor;
        let mut depth = 1usize;
        cursor += 1;
        while cursor < bytes.len() && depth > 0 {
            match bytes[cursor] {
                b'(' => depth += 1,
                b')' => depth -= 1,
                _ => {}
            }
            cursor += 1;
        }
        if depth != 0 || cursor <= open + 1 {
            return None;
        }
        let body = &header[open + 1..cursor - 1];
        let Some((left, right)) = body.split_once(':') else {
            continue;
        };
        let name = left.split_whitespace().last()?;
        if name == parameter_name {
            let type_text = right.trim();
            if !type_text.is_empty() {
                return Some(type_text.to_owned());
            }
        }
    }
    None
}

fn internal_typed_parameter_types(
    plan: &SplitPlan,
    scopes: &[DeclarationTypeScope],
) -> BTreeMap<(DeclarationId, String), String> {
    let mut candidates = BTreeMap::<(DeclarationId, String), BTreeSet<String>>::new();
    let mut contracts = BTreeMap::<(DeclarationId, String), Option<BindingContract>>::new();
    for consumer in &plan.declarations {
        let mut seen = BTreeSet::<(DeclarationId, String)>::new();
        for witness in &consumer.witnesses {
            if witness.provider == consumer.id {
                continue;
            }
            let symbol = witness
                .symbol
                .rsplit_once('.')
                .map_or(witness.symbol.as_str(), |(_, suffix)| suffix);
            if !identifier_suffix(symbol) || !seen.insert((witness.provider, symbol.to_owned())) {
                continue;
            }
            let Some(contract) = cached_contract(plan, &mut contracts, witness.provider, symbol)
            else {
                continue;
            };
            let calls = simple_arguments_after_call(&consumer.text, symbol);
            for (parameter_index, parameter) in contract.parameters.iter().enumerate() {
                let ParameterContract::Explicit {
                    name: explicit_name,
                    type_symbol,
                } = parameter
                else {
                    continue;
                };
                let full_type = explicit_parameter_type_text(
                    &plan.declarations[witness.provider.0].text,
                    symbol,
                    explicit_name,
                )
                .unwrap_or_else(|| type_symbol.clone());
                for call in &calls {
                    let Some(Some(argument)) = call.arguments.get(parameter_index) else {
                        continue;
                    };
                    if scopes[consumer.id.0].unique_parameters.contains(argument) {
                        candidates
                            .entry((consumer.id, argument.clone()))
                            .or_default()
                            .insert(full_type.clone());
                    }
                }
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(key, values)| one_compatible_type(values.iter()).map(|value| (key, value)))
        .collect()
}

fn build_forward_slots(
    plan: &SplitPlan,
    scopes: &[DeclarationTypeScope],
) -> BTreeMap<ForwardKey, ForwardSlot> {
    let mut slots = BTreeMap::<ForwardKey, ForwardSlot>::new();
    let mut contracts = BTreeMap::<(DeclarationId, String), Option<BindingContract>>::new();
    for consumer in &plan.declarations {
        let mut seen = BTreeSet::<(DeclarationId, String)>::new();
        for witness in &consumer.witnesses {
            if witness.provider == consumer.id {
                continue;
            }
            let symbol = witness
                .symbol
                .rsplit_once('.')
                .map_or(witness.symbol.as_str(), |(_, suffix)| suffix);
            if !identifier_suffix(symbol) || !seen.insert((witness.provider, symbol.to_owned())) {
                continue;
            }
            let Some(contract) = cached_contract(plan, &mut contracts, witness.provider, symbol)
            else {
                continue;
            };
            let calls = simple_arguments_after_call(&consumer.text, symbol);
            if calls.is_empty() {
                continue;
            }
            let call_indents = calls
                .iter()
                .map(|call| call_line_indent(&consumer.text, call.offset))
                .collect::<Vec<_>>();

            for (parameter_index, parameter) in contract.parameters.iter().enumerate() {
                let ParameterContract::Inferred {
                    name: parameter_name,
                } = parameter
                else {
                    continue;
                };
                let key = ForwardKey {
                    provider: witness.provider,
                    symbol: symbol.to_owned(),
                    parameter_index,
                    parameter_name: parameter_name.clone(),
                };
                let slot = slots.entry(key).or_insert_with(|| ForwardSlot {
                    sources: Vec::new(),
                    complete: true,
                });
                for (call, call_indent) in calls.iter().zip(&call_indents) {
                    let source = match call.arguments.get(parameter_index).and_then(Option::as_ref)
                    {
                        Some(argument) => {
                            if let Some(type_text) = scopes[consumer.id.0].local_type(
                                argument,
                                call.offset,
                                *call_indent,
                            ) {
                                ArgumentSource::Local(type_text)
                            } else if scopes[consumer.id.0].unique_parameters.contains(argument) {
                                ArgumentSource::Forwarded {
                                    consumer: consumer.id,
                                    parameter_name: argument.clone(),
                                }
                            } else {
                                ArgumentSource::Unsupported
                            }
                        }
                        None => ArgumentSource::Unsupported,
                    };
                    if matches!(source, ArgumentSource::Unsupported) {
                        slot.complete = false;
                    }
                    slot.sources.push(source);
                }
            }
        }
    }
    slots
}

fn has_member_access(text: &str, parameter_name: &str) -> bool {
    text.match_indices(parameter_name).any(|(offset, _)| {
        let before = text[..offset].chars().next_back();
        let after = text[offset + parameter_name.len()..].chars().next();
        before.is_none_or(|character| !identifier_continue(character)) && after == Some('.')
    })
}

fn has_lock_argument(text: &str, parameter_name: &str) -> bool {
    let mut previous = None::<String>;
    let mut token = String::new();
    for character in text.chars().chain(std::iter::once(' ')) {
        if identifier_continue(character) {
            token.push(character);
            continue;
        }
        if !token.is_empty() {
            if previous.as_deref() == Some("lock") && token == parameter_name {
                return true;
            }
            previous = Some(std::mem::take(&mut token));
        }
    }
    false
}

fn parameter_demands_annotation(text: &str, parameter_name: &str) -> bool {
    if parameter_name.len() < 4 {
        return false;
    }
    let Ok(code_only) = code_only_mask(text) else {
        return false;
    };
    code_only.lines().any(|code| {
        has_member_access(code, parameter_name) || has_lock_argument(code, parameter_name)
    })
}

fn referenced_type_providers(
    type_text: &str,
    type_providers: &BTreeMap<String, usize>,
) -> BTreeSet<usize> {
    let mut providers = BTreeSet::new();
    let mut token = String::new();
    for character in type_text.chars().chain(std::iter::once(' ')) {
        if identifier_continue(character) {
            token.push(character);
            continue;
        }
        if let Some(provider) = type_providers.get(&token) {
            providers.insert(*provider);
        }
        token.clear();
    }
    providers
}

fn materializable_type(
    plan: &SplitPlan,
    declaration_shards: &[usize],
    provider: DeclarationId,
    type_text: &str,
    type_providers: &BTreeMap<String, usize>,
) -> Option<Option<usize>> {
    let leaf = type_leaf(type_text);
    let provider_shard = declaration_shards[provider.0];
    for referenced_provider in referenced_type_providers(type_text, type_providers) {
        if referenced_provider != provider_shard
            && !plan.shards[provider_shard]
                .compile_dependencies
                .contains(&referenced_provider)
        {
            return None;
        }
    }
    if let Some(type_provider) = type_providers.get(leaf).copied() {
        if type_provider == provider_shard {
            return Some(None);
        }
        return Some(Some(type_provider));
    }
    matches!(
        type_text,
        "obj" | "bool ref" | "int" | "int64" | "string" | "bool"
    )
    .then_some(None)
    .or_else(|| type_text.contains('.').then_some(None))
}

fn resolve_nested_type_tokens(
    type_text: &str,
    target_shard: usize,
    type_providers: &BTreeMap<String, usize>,
) -> String {
    let mut output = String::with_capacity(type_text.len() + 32);
    let mut cursor = 0usize;
    while cursor < type_text.len() {
        let character = type_text[cursor..].chars().next().expect("character");
        if character == '\'' {
            cursor += character.len_utf8();
            while cursor < type_text.len() {
                let next = type_text[cursor..]
                    .chars()
                    .next()
                    .expect("type variable character");
                if !identifier_continue(next) {
                    break;
                }
                cursor += next.len_utf8();
            }
            output.push('_');
            continue;
        }
        if identifier_continue(character) && !character.is_ascii_digit() {
            let start = cursor;
            cursor += character.len_utf8();
            while cursor < type_text.len() {
                let next = type_text[cursor..]
                    .chars()
                    .next()
                    .expect("identifier character");
                if !identifier_continue(next) {
                    break;
                }
                cursor += next.len_utf8();
            }
            let token = &type_text[start..cursor];
            let already_qualified =
                start > 0 && type_text[..start].chars().next_back() == Some('.');
            match type_providers.get(token).copied() {
                Some(provider_shard) if !already_qualified && provider_shard != target_shard => {
                    output.push_str(&format!("spiral_compiler_Part{provider_shard:04}."));
                    output.push_str(token);
                }
                _ => output.push_str(token),
            }
            continue;
        }
        output.push(character);
        cursor += character.len_utf8();
    }
    output
}

fn resolve_type_for_target(
    type_text: &str,
    target_shard: usize,
    type_provider: Option<usize>,
    type_providers: &BTreeMap<String, usize>,
) -> String {
    let suffix = if type_text.ends_with(" ref") {
        " ref"
    } else {
        ""
    };
    let base = type_text.strip_suffix(suffix).unwrap_or(type_text);
    let generic_at = base.find('<').unwrap_or(base.len());
    let head = base[..generic_at].trim();
    let leaf = head.rsplit('.').next().unwrap_or(head);
    let resolved_head = match type_providers.get(leaf).copied() {
        Some(provider_shard) if provider_shard == target_shard => leaf.to_owned(),
        Some(provider_shard) if type_provider == Some(provider_shard) => {
            format!("spiral_compiler_Part{provider_shard:04}.{leaf}")
        }
        _ => head.to_owned(),
    };
    let nested = resolve_nested_type_tokens(&base[generic_at..], target_shard, type_providers);
    format!("{resolved_head}{nested}{suffix}")
}

#[must_use]
pub fn analyze_forwarded_binding_contracts(
    plan: &SplitPlan,
    type_providers: &BTreeMap<String, usize>,
    seeds: &BTreeMap<DeclarationId, Vec<CallerParameterType>>,
) -> CallerContractIndex {
    let declaration_shards = declaration_shards(plan);
    let scopes = plan
        .declarations
        .iter()
        .map(|declaration| DeclarationTypeScope::build(plan, declaration.id, type_providers))
        .collect::<Vec<_>>();
    let slots = build_forward_slots(plan, &scopes);
    let mut resolved_names = seed_name_types(&scopes, seeds);
    let seed_keys = seeds
        .iter()
        .flat_map(|(provider, rows)| {
            rows.iter().map(|row| ForwardKey {
                provider: *provider,
                symbol: row.symbol.clone(),
                parameter_index: row.parameter_index,
                parameter_name: row.parameter_name.clone(),
            })
        })
        .collect::<BTreeSet<_>>();

    let slot_rows = slots.into_iter().collect::<Vec<_>>();
    let mut waiters = BTreeMap::<(DeclarationId, String), Vec<usize>>::new();
    for (slot_index, (_, slot)) in slot_rows.iter().enumerate() {
        for source in &slot.sources {
            if let ArgumentSource::Forwarded {
                consumer,
                parameter_name,
            } = source
            {
                waiters
                    .entry((*consumer, parameter_name.clone()))
                    .or_default()
                    .push(slot_index);
            }
        }
    }

    let mut queue = (0..slot_rows.len()).collect::<VecDeque<_>>();
    let mut queued = vec![true; slot_rows.len()];
    let mut inferred = BTreeMap::<ForwardKey, (String, Option<usize>)>::new();
    let internal_types = internal_typed_parameter_types(plan, &scopes);
    for (key, _) in &slot_rows {
        if seed_keys.contains(key) {
            continue;
        }
        let Some(type_text) = internal_types.get(&(key.provider, key.parameter_name.clone()))
        else {
            continue;
        };
        let Some(type_provider) = materializable_type(
            plan,
            &declaration_shards,
            key.provider,
            type_text,
            type_providers,
        ) else {
            continue;
        };
        let resolved_type = resolve_type_for_target(
            type_text,
            declaration_shards[key.provider.0],
            type_provider,
            type_providers,
        );
        inferred.insert(key.clone(), (resolved_type.clone(), type_provider));
        resolved_names.insert((key.provider, key.parameter_name.clone()), resolved_type);
    }
    while let Some(slot_index) = queue.pop_front() {
        queued[slot_index] = false;
        let (key, slot) = &slot_rows[slot_index];
        if !slot.complete || seed_keys.contains(key) || inferred.contains_key(key) {
            continue;
        }
        let mut types = BTreeSet::<String>::new();
        let mut complete = true;
        for source in &slot.sources {
            let type_text = match source {
                ArgumentSource::Local(type_text) => Some(type_text.clone()),
                ArgumentSource::Forwarded {
                    consumer,
                    parameter_name,
                } => resolved_names
                    .get(&(*consumer, parameter_name.clone()))
                    .cloned(),
                ArgumentSource::Unsupported => None,
            };
            let Some(type_text) = type_text else {
                complete = false;
                break;
            };
            types.insert(type_text);
        }
        if !complete {
            continue;
        }
        let Some(type_text) = one_compatible_type(types.iter()) else {
            continue;
        };
        let Some(type_provider) = materializable_type(
            plan,
            &declaration_shards,
            key.provider,
            &type_text,
            type_providers,
        ) else {
            continue;
        };
        let resolved_type = resolve_type_for_target(
            &type_text,
            declaration_shards[key.provider.0],
            type_provider,
            type_providers,
        );
        inferred.insert(key.clone(), (resolved_type.clone(), type_provider));

        if scopes[key.provider.0]
            .unique_parameters
            .contains(&key.parameter_name)
        {
            let name_key = (key.provider, key.parameter_name.clone());
            if resolved_names
                .get(&name_key)
                .is_none_or(|existing| canonical_type(existing) == canonical_type(&resolved_type))
            {
                let newly_available = resolved_names
                    .insert(name_key.clone(), resolved_type)
                    .is_none();
                if newly_available {
                    for dependent in waiters.get(&name_key).into_iter().flatten() {
                        if !queued[*dependent] {
                            queue.push_back(*dependent);
                            queued[*dependent] = true;
                        }
                    }
                }
            }
        }
    }

    let mut parameter_types = BTreeMap::<DeclarationId, Vec<CallerParameterType>>::new();
    let mut provider_rows = BTreeMap::<usize, Vec<(usize, usize, String, usize)>>::new();
    for (key, (type_symbol, _type_provider)) in inferred {
        let declaration = &plan.declarations[key.provider.0];
        if !parameter_demands_annotation(&declaration.text, &key.parameter_name) {
            continue;
        }
        let shard = declaration_shards[key.provider.0];
        let referenced_providers = referenced_type_providers(&type_symbol, type_providers);
        parameter_types
            .entry(key.provider)
            .or_default()
            .push(CallerParameterType {
                type_arguments: 0,
                symbol: key.symbol.clone(),
                parameter_index: key.parameter_index,
                parameter_name: key.parameter_name,
                type_symbol,
            });
        for type_provider in referenced_providers {
            if type_provider == shard {
                continue;
            }
            provider_rows.entry(shard).or_default().push((
                key.provider.0,
                key.parameter_index,
                key.symbol.clone(),
                type_provider,
            ));
        }
    }
    for rows in parameter_types.values_mut() {
        rows.sort();
        rows.dedup();
    }
    let type_providers_by_shard = provider_rows
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
    use spiral_split_model::{
        BoundaryReason, CompilerProfile, Declaration, DeclarationKind, DependencyWitness, LineSpan,
        Linked, ReferenceMode, Shard, SourceText, SplitPolicy,
    };
    use std::path::PathBuf;

    fn declaration(index: usize, text: &str) -> Declaration<Linked> {
        Declaration::<Linked>::new(
            DeclarationId(index),
            LineSpan {
                start: 0,
                end: text.lines().count(),
            },
            format!("decl-{index}"),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::Other),
            Vec::new(),
            0,
        )
    }

    fn shard(id: usize, declaration: usize, dependencies: &[usize]) -> Shard {
        Shard {
            id,
            declarations: vec![DeclarationId(declaration)],
            direct_dependencies: dependencies.iter().copied().collect(),
            compile_dependencies: dependencies.iter().copied().collect(),
            ambient_opens: Vec::new(),
            line_count: 1,
            bytes: 1,
            layer: id,
            oversize: false,
            fingerprint: 0,
        }
    }

    fn forwarded_plan() -> SplitPlan {
        let mut declarations = vec![
            declaration(
                0,
                "type StripedHashConsTable(shardCount: int) =\n    member _.Add(x: 'a) = x\n",
            ),
            declaration(
                1,
                "let leaf backend_strings backend_strings_lock backend_switch_lock backend_switch_validate_all = lock backend_strings_lock (fun () -> backend_strings.Add \"x\") |> ignore; backend_switch_validate_all.Value <- false; lock backend_switch_lock (fun () -> ())\n",
            ),
            declaration(
                2,
                "let forward backend_strings backend_strings_lock backend_switch_lock backend_switch_validate_all = leaf backend_strings backend_strings_lock backend_switch_lock backend_switch_validate_all\n",
            ),
            declaration(
                3,
                "let root () =\n    let backend_strings = StripedHashConsTable(32)\n    let backend_strings_lock = obj()\n    let backend_switch_validate_all = ref false\n    let backend_switch_lock = obj()\n    forward backend_strings backend_strings_lock backend_switch_lock backend_switch_validate_all\n",
            ),
        ];
        declarations[2].witnesses.push(DependencyWitness {
            symbol: "leaf".to_owned(),
            provider: DeclarationId(1),
        });
        declarations[3].witnesses.push(DependencyWitness {
            symbol: "forward".to_owned(),
            provider: DeclarationId(2),
        });
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
            shards: vec![
                shard(0, 0, &[]),
                shard(1, 1, &[0]),
                shard(2, 2, &[0, 1]),
                shard(3, 3, &[0, 1, 2]),
            ],
        }
    }

    #[test]
    fn local_binding_shapes_are_small_and_explicit() {
        assert_eq!(
            simple_value_binding_evidence("let table = StripedHashConsTable(32)"),
            Some((
                "table".to_owned(),
                BindingTypeEvidence::Constructor("StripedHashConsTable".to_owned())
            ))
        );
        assert_eq!(
            simple_value_binding_evidence(
                "let traces = System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<RData [] * Ty [] * Ty>, Trace>(HashIdentity.Reference)"
            ),
            Some((
                "traces".to_owned(),
                BindingTypeEvidence::QualifiedConstructor(
                    "System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<RData [] * Ty [] * Ty>, Trace>".to_owned()
                )
            ))
        );
        assert_eq!(
            simple_value_binding_evidence("let peval_sw = System.Diagnostics.Stopwatch.StartNew()"),
            Some((
                "peval_sw".to_owned(),
                BindingTypeEvidence::StaticFactory("System.Diagnostics.Stopwatch".to_owned())
            ))
        );
        assert_eq!(
            simple_value_binding_evidence("let sb = System.Text.StringBuilder()"),
            Some((
                "sb".to_owned(),
                BindingTypeEvidence::QualifiedConstructor("System.Text.StringBuilder".to_owned())
            ))
        );
        assert_eq!(
            simple_value_binding_evidence("let gate = obj()"),
            Some(("gate".to_owned(), BindingTypeEvidence::Object))
        );
        assert_eq!(
            simple_value_binding_evidence("let enabled = ref false"),
            Some((
                "enabled".to_owned(),
                BindingTypeEvidence::Reference(PrimitiveReference::Bool)
            ))
        );
    }

    #[test]
    fn later_binding_does_not_flow_backward_into_call() {
        let plan = forwarded_plan();
        let text = "let root () =\n    forward table\n    let table = StripedHashConsTable(32)\n";
        let mut declaration = declaration(4, text);
        declaration.witnesses.push(DependencyWitness {
            symbol: "forward".to_owned(),
            provider: DeclarationId(2),
        });
        let mut plan = plan;
        plan.declarations.push(declaration);
        plan.shards.push(shard(4, 4, &[0, 1, 2]));
        let scopes = plan
            .declarations
            .iter()
            .map(|declaration| {
                DeclarationTypeScope::build(
                    &plan,
                    declaration.id,
                    &BTreeMap::from([("StripedHashConsTable".to_owned(), 0)]),
                )
            })
            .collect::<Vec<_>>();
        let call = simple_arguments_after_call(text, "forward")
            .into_iter()
            .next()
            .unwrap();
        assert_eq!(
            scopes[4].local_type("table", call.offset, call_line_indent(text, call.offset)),
            None
        );
    }

    #[test]
    fn only_type_demanding_parameters_render_annotations() {
        let plan = forwarded_plan();
        assert!(!parameter_demands_annotation("let f x = x.Value", "x"));
        assert!(parameter_demands_annotation(
            &plan.declarations[1].text,
            "backend_strings"
        ));
        assert!(parameter_demands_annotation(
            &plan.declarations[1].text,
            "backend_strings_lock"
        ));
        assert!(parameter_demands_annotation(
            &plan.declarations[1].text,
            "backend_switch_validate_all"
        ));
        assert!(!parameter_demands_annotation(
            &plan.declarations[2].text,
            "backend_strings"
        ));
        assert!(!parameter_demands_annotation(
            "let f apply = let message = \"type apply.\\n\" in apply value",
            "apply"
        ));
    }

    #[test]
    fn nested_generic_type_providers_are_discovered() {
        let providers = BTreeMap::from([
            ("ConsedNode".to_owned(), 189usize),
            ("RData".to_owned(), 686usize),
            ("Ty".to_owned(), 748usize),
        ]);
        assert_eq!(
            referenced_type_providers(
                "System.Collections.Concurrent.ConcurrentDictionary<Ty, ConsedNode<RData [] * Ty [] * Ty>>",
                &providers,
            ),
            BTreeSet::from([189usize, 686usize, 748usize]),
        );
    }

    #[test]
    fn type_resolution_qualifies_external_and_unqualifies_local() {
        let providers =
            BTreeMap::from([("Node".to_owned(), 152usize), ("Kind".to_owned(), 152usize)]);
        assert_eq!(
            resolve_type_for_target("Node", 1431, Some(152), &providers),
            "spiral_compiler_Part0152.Node"
        );
        assert_eq!(
            resolve_type_for_target("spiral_compiler_Part0152.Node", 152, None, &providers,),
            "Node"
        );
        assert_eq!(
            resolve_type_for_target("Node<Kind>", 1431, Some(152), &providers),
            "spiral_compiler_Part0152.Node<spiral_compiler_Part0152.Kind>"
        );
        assert_eq!(
            resolve_type_for_target("Node<'Kind>", 1431, Some(152), &providers),
            "spiral_compiler_Part0152.Node<_>"
        );
    }

    #[test]
    fn typed_callee_use_seeds_forwarded_parameter_type() {
        let mut declarations = vec![
            declaration(
                0,
                "type WorkDagAuthority<'Kind> = { semanticFactDebt:int }\n",
            ),
            declaration(
                1,
                "let workDagAuthorityText (authority:WorkDagAuthority<'Kind>) = string authority.semanticFactDebt\n",
            ),
            declaration(
                2,
                "let helper progressTerminalWorkDagAuthority = progressTerminalWorkDagAuthority.semanticFactDebt |> ignore; workDagAuthorityText progressTerminalWorkDagAuthority\n",
            ),
            declaration(
                3,
                "let root progressTerminalWorkDagAuthority = helper progressTerminalWorkDagAuthority\n",
            ),
        ];
        declarations[2].witnesses.push(DependencyWitness {
            symbol: "workDagAuthorityText".to_owned(),
            provider: DeclarationId(1),
        });
        declarations[3].witnesses.push(DependencyWitness {
            symbol: "helper".to_owned(),
            provider: DeclarationId(2),
        });
        let plan = SplitPlan {
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
            shards: vec![
                shard(0, 0, &[]),
                shard(1, 1, &[0]),
                shard(2, 2, &[0, 1]),
                shard(3, 3, &[0, 1, 2]),
            ],
        };
        let result = analyze_forwarded_binding_contracts(
            &plan,
            &BTreeMap::from([("WorkDagAuthority".to_owned(), 0usize)]),
            &BTreeMap::new(),
        );
        assert_eq!(
            result.parameter_types[&DeclarationId(2)][0].type_symbol,
            "spiral_compiler_Part0000.WorkDagAuthority<_>"
        );
    }

    #[test]
    fn binding_types_propagate_through_forwarded_parameters_by_worklist() {
        let plan = forwarded_plan();
        let result = analyze_forwarded_binding_contracts(
            &plan,
            &BTreeMap::from([("StripedHashConsTable".to_owned(), 0)]),
            &BTreeMap::new(),
        );
        let leaf = &result.parameter_types[&DeclarationId(1)];
        assert_eq!(leaf.len(), 4);
        assert_eq!(
            leaf[0].type_symbol,
            "spiral_compiler_Part0000.StripedHashConsTable"
        );
        assert_eq!(leaf[1].type_symbol, "obj");
        assert_eq!(leaf[2].type_symbol, "obj");
        assert_eq!(leaf[3].type_symbol, "bool ref");
        assert!(!result.parameter_types.contains_key(&DeclarationId(2)));
        assert_eq!(result.type_providers_by_shard[&1], vec![0]);
        assert!(!result.type_providers_by_shard.contains_key(&2));
    }
}
