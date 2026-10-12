use spiral_split_model::{DeclarationId, SplitPlan};
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq, Ord, PartialOrd)]
pub struct RecordReturnOwnerWitness {
    pub binding: String,
    pub type_symbol: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct RecordOwner {
    declaration: DeclarationId,
    provider: usize,
    source_module: Option<String>,
    name: String,
    fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct BindingHeader {
    name: String,
    equals: usize,
    explicit_return_type: bool,
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

fn declaration_shards(plan: &SplitPlan) -> Vec<usize> {
    let mut result = vec![usize::MAX; plan.declarations.len()];
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            result[declaration.0] = shard.id;
        }
    }
    result
}

fn definition_leaf(definition: &str) -> &str {
    definition
        .rsplit_once('.')
        .map_or(definition, |(_, suffix)| suffix)
}

fn type_symbol_after_attributes(mut text: &str) -> &str {
    text = text.trim_start();
    while let Some(rest) = text.strip_prefix("[<") {
        let Some(end) = rest.find(">]") else {
            break;
        };
        text = rest[end + 2..].trim_start();
    }
    text
}

fn declares_type_symbol(text: &str, symbol: &str) -> bool {
    text.lines().map(str::trim_start).any(|line| {
        ["type ", "and "].into_iter().any(|keyword| {
            let Some(rest) = line.strip_prefix(keyword) else {
                return false;
            };
            let mut rest = type_symbol_after_attributes(rest);
            loop {
                let before = rest;
                for modifier in ["private ", "internal ", "public ", "rec "] {
                    if let Some(next) = rest.strip_prefix(modifier) {
                        rest = next.trim_start();
                        break;
                    }
                }
                if rest == before {
                    break;
                }
            }
            rest.strip_prefix(symbol).is_some_and(|tail| {
                tail.is_empty()
                    || tail.starts_with(char::is_whitespace)
                    || tail.starts_with(['=', '<', '('])
            })
        })
    })
}

fn field_name(piece: &str, separator: char) -> Option<String> {
    let before_comment = piece.split_once("//").map_or(piece, |(head, _)| head);
    let left = before_comment.split_once(separator)?.0.trim();
    let left = left.strip_prefix("mutable ").unwrap_or(left).trim();
    let field = left.split_whitespace().last()?;
    identifier_prefix(field).map(str::to_owned)
}

fn record_type_fields(text: &str, symbol: &str) -> Option<BTreeSet<String>> {
    let lines = text.lines().collect::<Vec<_>>();
    let declaration_line = lines.iter().position(|line| {
        let trimmed = line.trim_start();
        (trimmed.starts_with("type ") || trimmed.starts_with("and "))
            && declares_type_symbol(trimmed, symbol)
    })?;
    let tail = lines[declaration_line..].join("\n");
    let open = tail.find('{')?;
    if tail[open + 1..].trim_start().starts_with('|') {
        return None;
    }
    let close = tail[open + 1..].find('}')? + open + 1;
    let fields = tail[open + 1..close]
        .split([';', '\n'])
        .filter_map(|piece| field_name(piece, ':'))
        .collect::<BTreeSet<_>>();
    (fields.len() >= 2).then_some(fields)
}

fn record_owners(plan: &SplitPlan, declaration_shards: &[usize]) -> Vec<RecordOwner> {
    let mut output = Vec::new();
    for declaration in &plan.declarations {
        let provider = declaration_shards[declaration.id.0];
        if provider == usize::MAX {
            continue;
        }
        let source_module = declaration.scope.module_name().map(str::to_owned);
        for definition in &declaration.definitions {
            let name = definition_leaf(definition);
            if !declares_type_symbol(&declaration.text, name) {
                continue;
            }
            let Some(fields) = record_type_fields(&declaration.text, name) else {
                continue;
            };
            output.push(RecordOwner {
                declaration: declaration.id,
                provider,
                source_module: source_module.clone(),
                name: name.to_owned(),
                fields,
            });
        }
    }
    output.sort_by_key(|owner| (owner.declaration.0, owner.provider, owner.name.clone()));
    output.dedup();
    output
}

fn find_binding_start(text: &str) -> Option<usize> {
    let mut offset = 0usize;
    for line in text.split_inclusive('\n') {
        let trimmed = line.trim_start();
        if trimmed.starts_with("let ") || trimmed.starts_with("and ") {
            return Some(offset + line.len() - trimmed.len());
        }
        offset += line.len();
    }
    None
}

fn binding_header(text: &str) -> Option<BindingHeader> {
    let start = find_binding_start(text)?;
    let tail = &text[start..];
    let keyword_len = if tail.starts_with("let ") { 4 } else { 4 };
    let mut header_tail = tail[keyword_len..].trim_start();
    loop {
        let before = header_tail;
        for modifier in [
            "private ",
            "internal ",
            "public ",
            "inline ",
            "rec ",
            "mutable ",
        ] {
            if let Some(rest) = header_tail.strip_prefix(modifier) {
                header_tail = rest.trim_start();
                break;
            }
        }
        if header_tail == before {
            break;
        }
    }
    let name = identifier_prefix(header_tail)?.to_owned();

    let bytes = text.as_bytes();
    let mut index = start;
    let mut paren = 0usize;
    let mut bracket = 0usize;
    let mut angle = 0usize;
    let mut in_string = false;
    let mut explicit_return_type = false;
    while index < bytes.len() {
        match bytes[index] {
            b'"' if index == 0 || bytes[index - 1] != b'\\' => in_string = !in_string,
            b'(' if !in_string => paren += 1,
            b')' if !in_string => paren = paren.saturating_sub(1),
            b'[' if !in_string => bracket += 1,
            b']' if !in_string => bracket = bracket.saturating_sub(1),
            b'<' if !in_string => angle += 1,
            b'>' if !in_string => angle = angle.saturating_sub(1),
            b':' if !in_string && paren == 0 && bracket == 0 && angle == 0 => {
                explicit_return_type = true;
            }
            b'=' if !in_string && paren == 0 && bracket == 0 && angle == 0 => {
                return Some(BindingHeader {
                    name,
                    equals: index,
                    explicit_return_type,
                });
            }
            _ => {}
        }
        index += 1;
    }
    None
}

fn top_level_literal_fields(body: &str) -> Option<BTreeSet<String>> {
    let bytes = body.as_bytes();
    let mut fields = BTreeSet::new();
    let mut segment_start = 0usize;
    let mut braces = 0usize;
    let mut parens = 0usize;
    let mut brackets = 0usize;
    let mut in_string = false;
    let mut cursor = 0usize;
    while cursor <= bytes.len() {
        let boundary = cursor == bytes.len()
            || (!in_string
                && braces == 0
                && parens == 0
                && brackets == 0
                && matches!(bytes[cursor], b';' | b'\n'));
        if boundary {
            let piece = body[segment_start..cursor].trim();
            if let Some(field) = field_name(piece, '=') {
                fields.insert(field);
            }
            segment_start = cursor.saturating_add(1);
        }
        if cursor == bytes.len() {
            break;
        }
        match bytes[cursor] {
            b'"' if cursor == 0 || bytes[cursor - 1] != b'\\' => in_string = !in_string,
            b'{' if !in_string => braces += 1,
            b'}' if !in_string => braces = braces.saturating_sub(1),
            b'(' if !in_string => parens += 1,
            b')' if !in_string => parens = parens.saturating_sub(1),
            b'[' if !in_string => brackets += 1,
            b']' if !in_string => brackets = brackets.saturating_sub(1),
            _ => {}
        }
        cursor += 1;
    }
    (fields.len() >= 2).then_some(fields)
}

fn record_literal_shapes(text: &str) -> BTreeSet<BTreeSet<String>> {
    let bytes = text.as_bytes();
    let mut shapes = BTreeSet::new();
    let mut index = 0usize;
    while index < bytes.len() {
        if bytes[index] != b'{' || bytes.get(index + 1) == Some(&b'|') {
            index += 1;
            continue;
        }
        let mut depth = 1usize;
        let mut cursor = index + 1;
        let mut in_string = false;
        while cursor < bytes.len() && depth > 0 {
            match bytes[cursor] {
                b'"' if bytes[cursor - 1] != b'\\' => in_string = !in_string,
                b'{' if !in_string => depth += 1,
                b'}' if !in_string => depth -= 1,
                _ => {}
            }
            cursor += 1;
        }
        if depth != 0 {
            break;
        }
        let body = &text[index + 1..cursor - 1];
        let before_first_equals = body.split_once('=').map_or(body, |(head, _)| head);
        let is_record_update = before_first_equals
            .split_whitespace()
            .any(|token| token == "with");
        if !is_record_update && let Some(fields) = top_level_literal_fields(body) {
            shapes.insert(fields);
        }
        index = cursor;
    }
    shapes
}

fn render_owner_type(owner: &RecordOwner, current_provider: usize) -> String {
    if owner.provider == current_provider {
        owner.name.clone()
    } else {
        format!("spiral_compiler_Part{:04}.{}", owner.provider, owner.name)
    }
}

#[must_use]
pub fn analyze_record_return_owners(
    plan: &SplitPlan,
) -> BTreeMap<DeclarationId, Vec<RecordReturnOwnerWitness>> {
    let declaration_shards = declaration_shards(plan);
    let records = record_owners(plan, &declaration_shards);
    let mut output = BTreeMap::<DeclarationId, Vec<RecordReturnOwnerWitness>>::new();

    for declaration in &plan.declarations {
        let current_provider = declaration_shards[declaration.id.0];
        if current_provider == usize::MAX {
            continue;
        }
        let Some(header) = binding_header(&declaration.text) else {
            continue;
        };
        if header.explicit_return_type {
            continue;
        }
        let body = &declaration.text[header.equals + 1..];
        let trimmed = body.trim_start();
        if !(trimmed.starts_with('{')
            || trimmed.starts_with("match ")
            || trimmed.starts_with("if ")
            || trimmed.starts_with("try ")
            || trimmed.starts_with("function"))
        {
            continue;
        }
        let shapes = record_literal_shapes(body);
        if shapes.len() != 1 {
            continue;
        }
        let shape = shapes.iter().next().expect("one record return shape");
        let source_module = declaration.scope.module_name();
        let mut candidates = records
            .iter()
            .filter(|owner| owner.declaration.0 < declaration.id.0)
            .filter(|owner| owner.source_module.as_deref() == source_module)
            .filter(|owner| &owner.fields == shape)
            .filter(|owner| {
                owner.provider == current_provider
                    || plan.shards[current_provider]
                        .compile_dependencies
                        .contains(&owner.provider)
            })
            .collect::<Vec<_>>();
        candidates.sort_by_key(|owner| (owner.declaration.0, owner.provider));
        let distinct_types = candidates
            .iter()
            .map(|owner| owner.name.as_str())
            .collect::<BTreeSet<_>>();
        if distinct_types.len() < 2 {
            continue;
        }
        let Some(owner) = candidates.last() else {
            continue;
        };
        output
            .entry(declaration.id)
            .or_default()
            .push(RecordReturnOwnerWitness {
                binding: header.name,
                type_symbol: render_owner_type(owner, current_provider),
            });
    }

    output
}

fn annotate_return_type(text: &str, witness: &RecordReturnOwnerWitness) -> String {
    let Some(header) = binding_header(text) else {
        return text.to_owned();
    };
    if header.name != witness.binding || header.explicit_return_type {
        return text.to_owned();
    }
    let insert = text[..header.equals].trim_end().len();
    let mut output = String::with_capacity(text.len() + witness.type_symbol.len() + 3);
    output.push_str(&text[..insert]);
    output.push_str(" : ");
    output.push_str(&witness.type_symbol);
    output.push_str(&text[insert..]);
    output
}

#[must_use]
pub fn apply_record_return_owner_witnesses(
    text: &str,
    witnesses: &[RecordReturnOwnerWitness],
) -> String {
    witnesses.iter().fold(text.to_owned(), |current, witness| {
        annotate_return_type(&current, witness)
    })
}

#[must_use]
pub fn render_record_return_owner_witnesses(
    witnesses: &BTreeMap<DeclarationId, Vec<RecordReturnOwnerWitness>>,
) -> String {
    let mut output = String::from("declaration\tbinding\ttype\n");
    for (declaration, rows) in witnesses {
        for witness in rows {
            output.push_str(&format!(
                "{}\t{}\t{}\n",
                declaration.0, witness.binding, witness.type_symbol
            ));
        }
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{
        BoundaryReason, CompilerProfile, Declaration, DeclarationKind, LineSpan, Linked,
        ReferenceMode, Shard, SourceText, SplitPolicy,
    };
    use std::path::PathBuf;

    fn declaration(id: usize, name: &str, text: &str) -> Declaration<Linked> {
        let mut declaration = Declaration::<Linked>::new(
            DeclarationId(id),
            LineSpan {
                start: id * 10,
                end: id * 10 + text.lines().count(),
            },
            name.to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::Other),
            Vec::new(),
            0,
        );
        declaration.definitions.insert(name.to_owned());
        declaration
    }

    fn shard(id: usize, declarations: Vec<usize>, dependencies: &[usize]) -> Shard {
        Shard {
            id,
            declarations: declarations.into_iter().map(DeclarationId).collect(),
            direct_dependencies: dependencies.iter().copied().collect(),
            compile_dependencies: dependencies.iter().copied().collect(),
            ambient_opens: Vec::new(),
            line_count: 1,
            bytes: 1,
            layer: id,
            oversize: false,
            fingerprint: id as u64,
        }
    }

    fn plan(function_text: &str) -> SplitPlan {
        let dispatch = r#"type TerminalFlowDispatchRequirementBlocker = private {
    kind : int
    requirementRef : uint32
    satisfierRef : uint32
    blockerRef : uint32
    ageMs : int64
    reason : string
}"#;
        let consume = r#"type TerminalFlowConsumeRequirementBlocker = private {
    kind : int
    requirementRef : uint32
    satisfierRef : uint32
    blockerRef : uint32
    ageMs : int64
    reason : string
}"#;
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
            declarations: vec![
                declaration(0, "TerminalFlowDispatchRequirementBlocker", dispatch),
                declaration(1, "TerminalFlowConsumeRequirementBlocker", consume),
                declaration(2, "terminalFlowConsumeRequirementBlocker", function_text),
            ],
            shards: vec![shard(0, vec![0], &[]), shard(1, vec![1, 2], &[0])],
        }
    }

    #[test]
    fn latest_same_source_record_owner_annotates_ambiguous_return() {
        let function = r#"let private terminalFlowConsumeRequirementBlocker credentialLedger kind reason nowMs =
    match credentialLedger with
    | Some credential ->
        { kind = kind
          requirementRef = credential
          satisfierRef = credential
          blockerRef = credential
          ageMs = nowMs
          reason = reason }
    | None ->
        { kind = kind
          requirementRef = 0u
          satisfierRef = 0u
          blockerRef = 0u
          ageMs = 0L
          reason = reason }"#;
        let plan = plan(function);
        let witnesses = analyze_record_return_owners(&plan);
        assert_eq!(
            witnesses[&DeclarationId(2)][0].type_symbol,
            "TerminalFlowConsumeRequirementBlocker"
        );
        let rewritten =
            apply_record_return_owner_witnesses(function, &witnesses[&DeclarationId(2)]);
        assert!(rewritten.contains(
            "terminalFlowConsumeRequirementBlocker credentialLedger kind reason nowMs : TerminalFlowConsumeRequirementBlocker ="
        ));
    }

    #[test]
    fn explicit_return_type_is_not_rewritten() {
        let function = r#"let private terminalFlowConsumeRequirementBlocker credentialLedger kind reason nowMs : TerminalFlowConsumeRequirementBlocker =
    { kind = kind
      requirementRef = 0u
      satisfierRef = 0u
      blockerRef = 0u
      ageMs = 0L
      reason = reason }"#;
        let plan = plan(function);
        assert!(analyze_record_return_owners(&plan).is_empty());
    }

    #[test]
    fn newline_record_update_does_not_infer_return_owner() {
        let function = r#"let update (value : TerminalFlowDispatchRequirementBlocker) =
    {value with
        kind = 2
        requirementRef = 7u
        satisfierRef = 8u
        blockerRef = 9u
        ageMs = 10L
        reason = \"updated\"}"#;
        let plan = plan(function);
        assert!(analyze_record_return_owners(&plan).is_empty());
    }

    #[test]
    fn single_visible_record_shape_needs_no_witness() {
        let function = r#"let build kind reason =
    { kind = kind
      requirementRef = 0u
      satisfierRef = 0u
      blockerRef = 0u
      ageMs = 0L
      reason = reason }"#;
        let mut plan = plan(function);
        plan.declarations.remove(0);
        plan.declarations[0].id = DeclarationId(0);
        plan.declarations[1].id = DeclarationId(1);
        plan.shards = vec![shard(0, vec![0, 1], &[])];
        assert!(analyze_record_return_owners(&plan).is_empty());
    }
}
