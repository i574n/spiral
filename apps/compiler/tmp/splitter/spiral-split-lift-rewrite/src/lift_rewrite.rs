use spiral_split_capture_parameter::{
    definition_parameters_before as capture_definition_parameters_before,
    recursive_group_parameter_type as capture_recursive_group_parameter_type,
};
use spiral_split_fsharp_lex::{
    LexicalBlocker as FSharpLexicalBlocker, LexicalState, character_literal_starts, transition,
};
use spiral_split_lift::LocalGroup;
use spiral_split_lift_plan::{ParameterSlot, ParametricComponent};
use spiral_split_model::{Declaration, DeclarationId, Linked};
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Applied;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum CallRequirement {
    Required,
    Optional,
}

impl CallRequirement {
    fn required(self) -> bool {
        matches!(self, Self::Required)
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum RewriteBlocker {
    OwnerMismatch,
    ComponentBlocked,
    RecursiveComponent,
    MultiGroupComponent,
    MultiBindingGroup,
    MissingGroupMember,
    InvalidLineSpan,
    UnsupportedHeader,
    TripleQuotedString,
    QualifiedUse(String),
    NonCallUse(String),
    MissingCall(String),
}

impl Display for RewriteBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::OwnerMismatch => formatter.write_str("owner-mismatch"),
            Self::ComponentBlocked => formatter.write_str("component-blocked"),
            Self::RecursiveComponent => formatter.write_str("recursive-component"),
            Self::MultiGroupComponent => formatter.write_str("multi-group-component"),
            Self::MultiBindingGroup => formatter.write_str("multi-binding-group"),
            Self::MissingGroupMember => formatter.write_str("missing-group-member"),
            Self::InvalidLineSpan => formatter.write_str("invalid-line-span"),
            Self::UnsupportedHeader => formatter.write_str("unsupported-header"),
            Self::TripleQuotedString => formatter.write_str("triple-quoted-string"),
            Self::QualifiedUse(symbol) => write!(formatter, "qualified-use:{symbol}"),
            Self::NonCallUse(symbol) => write!(formatter, "non-call-use:{symbol}"),
            Self::MissingCall(symbol) => write!(formatter, "missing-call:{symbol}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum AppliedEdit {
    Hoist {
        from_start_line: usize,
        from_end_line: usize,
        inserted_before_line: usize,
    },
    Rename {
        from: String,
        to: String,
    },
    AddParameter {
        symbol: String,
        name: String,
        ordinal: usize,
    },
    RewriteCall {
        symbol: String,
        arguments: Vec<String>,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct RewriteArtifact<S> {
    pub owner: DeclarationId,
    pub component: usize,
    pub original_fingerprint: u64,
    pub lifted_name: String,
    pub parameters: Vec<String>,
    pub hoisted_text: String,
    pub owner_text: String,
    pub full_text: String,
    pub edits: Vec<AppliedEdit>,
    pub rewritten_calls: usize,
    stage: PhantomData<fn() -> S>,
}

impl RewriteArtifact<Applied> {
    #[must_use]
    pub fn render_receipt(&self) -> String {
        let mut output = String::from(
            "owner	component	fingerprint	lifted_name	parameters	rewritten_calls	hoisted_lines	owner_lines
",
        );
        let _ = writeln!(
            output,
            "{}	{}	{}	{}	{}	{}	{}	{}",
            self.owner.0,
            self.component,
            self.original_fingerprint,
            self.lifted_name,
            self.parameters.join(","),
            self.rewritten_calls,
            self.hoisted_text.lines().count(),
            self.owner_text.lines().count(),
        );
        output
    }
}

fn leading_spaces(line: &str) -> usize {
    line.as_bytes()
        .iter()
        .take_while(|byte| **byte == b' ')
        .count()
}

fn identifier_start(byte: u8) -> bool {
    byte == b'_' || byte.is_ascii_alphabetic()
}

fn identifier_continue(byte: u8) -> bool {
    identifier_start(byte) || byte.is_ascii_digit() || byte == b'\''
}

fn binding_name_range(line: &str, expected: &str) -> Option<(usize, usize)> {
    let bytes = line.as_bytes();
    let mut index = leading_spaces(line);
    let keyword = if bytes.get(index..index + 4) == Some(b"let ") {
        index += 4;
        "let"
    } else if bytes.get(index..index + 4) == Some(b"and ") {
        index += 4;
        "and"
    } else {
        return None;
    };
    let _ = keyword;
    while bytes.get(index) == Some(&b' ') {
        index += 1;
    }
    if bytes.get(index..index + 4) == Some(b"rec ") {
        index += 4;
        while bytes.get(index) == Some(&b' ') {
            index += 1;
        }
    }
    let start = index;
    if !bytes.get(index).copied().is_some_and(identifier_start) {
        return None;
    }
    index += 1;
    while bytes.get(index).copied().is_some_and(identifier_continue) {
        index += 1;
    }
    (line.get(start..index) == Some(expected)).then_some((start, index))
}

fn rewrite_header(
    line: &str,
    original: &str,
    lifted: &str,
    parameters: &[String],
) -> Result<String, RewriteBlocker> {
    let (start, end) =
        binding_name_range(line, original).ok_or(RewriteBlocker::UnsupportedHeader)?;
    let mut output = String::with_capacity(line.len() + lifted.len() + parameters.len() * 8);
    output.push_str(&line[..start]);
    output.push_str(lifted);
    for parameter in parameters {
        output.push(' ');
        output.push_str(parameter);
    }
    output.push_str(&line[end..]);
    Ok(output)
}

fn annotate_recursive_group_header_parameters(
    line: &str,
    original: &str,
    owner_text: &str,
    group_start: usize,
) -> String {
    let Some((_, name_end)) = binding_name_range(line, original) else {
        return line.to_owned();
    };
    let bytes = line.as_bytes();
    let mut output = String::with_capacity(line.len() + 32);
    output.push_str(&line[..name_end]);
    let mut cursor = name_end;
    while cursor < bytes.len() {
        if bytes[cursor].is_ascii_whitespace() {
            output.push(bytes[cursor] as char);
            cursor += 1;
            continue;
        }
        let start = cursor;
        while cursor < bytes.len() && !bytes[cursor].is_ascii_whitespace() {
            cursor += 1;
        }
        let token = &line[start..cursor];
        if token == "=" {
            output.push_str(&line[start..]);
            break;
        }
        let plain_identifier = token
            .as_bytes()
            .first()
            .copied()
            .is_some_and(identifier_start)
            && token.as_bytes().iter().copied().all(identifier_continue);
        if plain_identifier {
            if let Some(annotation) =
                capture_recursive_group_parameter_type(owner_text, token, group_start)
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
            output.push_str(token);
        }
    }
    output
}

fn dedent(line: &str, spaces: usize) -> String {
    if line.trim().is_empty() {
        String::new()
    } else if line.len() >= spaces && line.as_bytes()[..spaces].iter().all(|byte| *byte == b' ') {
        line[spaces..].to_owned()
    } else {
        line.to_owned()
    }
}

fn argument_starts(byte: u8) -> bool {
    matches!(
        byte,
        b'(' | b'[' | b'{' | b'"' | b'\'' | b'_' | b'-' | b'+' | b'$' | b'0'..=b'9'
            | b'a'..=b'z' | b'A'..=b'Z'
    )
}

fn line_indent(bytes: &[u8], at: usize) -> usize {
    let line_start = bytes[..at]
        .iter()
        .rposition(|byte| *byte == b'\n')
        .map_or(0, |index| index + 1);
    bytes[line_start..at]
        .iter()
        .take_while(|byte| matches!(byte, b' ' | b'\t'))
        .map(|byte| if *byte == b'\t' { 4 } else { 1 })
        .sum()
}

fn call_follows(bytes: &[u8], start: usize, mut index: usize) -> bool {
    while bytes
        .get(index)
        .is_some_and(|byte| matches!(byte, b' ' | b'\t'))
    {
        index += 1;
    }
    if bytes.get(index).copied().is_some_and(argument_starts) {
        return true;
    }
    if !matches!(bytes.get(index), Some(b'\r' | b'\n')) {
        return false;
    }
    let base_indent = line_indent(bytes, start);
    while index < bytes.len() {
        if bytes.get(index) == Some(&b'\r') {
            index += 1;
        }
        if bytes.get(index) != Some(&b'\n') {
            return false;
        }
        index += 1;
        let mut continuation_indent = 0usize;
        while let Some(byte) = bytes.get(index) {
            match byte {
                b' ' => continuation_indent += 1,
                b'\t' => continuation_indent += 4,
                _ => break,
            }
            index += 1;
        }
        match bytes.get(index).copied() {
            Some(b'\r' | b'\n') => continue,
            Some(byte) => return continuation_indent > base_indent && argument_starts(byte),
            None => return false,
        }
    }
    false
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum CallForm {
    Direct,
    PipelineTarget,
    TerminalArgument,
}

fn pipeline_precedes(bytes: &[u8], mut start: usize) -> bool {
    while start > 0 && matches!(bytes[start - 1], b' ' | 9) {
        start -= 1;
    }
    start >= 2 && bytes.get(start - 2..start) == Some(b"|>")
}

fn terminal_argument_precedes(bytes: &[u8], start: usize, end: usize) -> bool {
    let mut after = end;
    while bytes
        .get(after)
        .is_some_and(|byte| matches!(byte, b' ' | b'\t'))
    {
        after += 1;
    }
    if !matches!(
        bytes.get(after),
        None | Some(b'\r' | b'\n' | b')' | b']' | b'}' | b',' | b';')
    ) {
        return false;
    }

    let mut cursor = start;
    let mut separated = false;
    while cursor > 0 && matches!(bytes[cursor - 1], b' ' | b'\t') {
        cursor -= 1;
        separated = true;
    }
    if !separated || cursor == 0 {
        return false;
    }
    if matches!(bytes.get(cursor - 1), Some(b')' | b']' | b'}')) {
        return true;
    }
    let head_end = cursor;
    while cursor > 0 && (identifier_continue(bytes[cursor - 1]) || bytes[cursor - 1] == b'.') {
        cursor -= 1;
    }
    if cursor == head_end {
        return false;
    }
    let head = &bytes[cursor..head_end];
    if head.first() == Some(&b'.') || head.last() == Some(&b'.') {
        return false;
    }
    let terminal = head.rsplit(|byte| *byte == b'.').next().unwrap_or(head);
    !matches!(
        terminal,
        b"and"
            | b"do"
            | b"else"
            | b"elif"
            | b"finally"
            | b"for"
            | b"fun"
            | b"function"
            | b"if"
            | b"in"
            | b"let"
            | b"match"
            | b"then"
            | b"try"
            | b"use"
            | b"when"
            | b"while"
            | b"with"
            | b"yield"
            | b"return"
    )
}

fn call_form(bytes: &[u8], start: usize, end: usize) -> Option<CallForm> {
    if call_follows(bytes, start, end) {
        Some(CallForm::Direct)
    } else if pipeline_precedes(bytes, start) {
        Some(CallForm::PipelineTarget)
    } else if terminal_argument_precedes(bytes, start, end) {
        Some(CallForm::TerminalArgument)
    } else {
        None
    }
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum ReferenceUse {
    Call,
    AssignedValue,
}

fn assignment_precedes(bytes: &[u8], mut start: usize) -> bool {
    while start > 0 && matches!(bytes[start - 1], b' ' | b'\t') {
        start -= 1;
    }
    (start >= 2 && bytes.get(start - 2..start) == Some(b"<-"))
        || (start >= 1 && bytes.get(start - 1) == Some(&b'='))
}

fn assigned_value_terminates(bytes: &[u8], mut end: usize) -> bool {
    while bytes
        .get(end)
        .is_some_and(|byte| matches!(byte, b' ' | b'\t'))
    {
        end += 1;
    }
    matches!(
        bytes.get(end),
        None | Some(b'\r' | b'\n' | b')' | b']' | b'}' | b',' | b';')
    )
}

fn reference_use(bytes: &[u8], start: usize, end: usize) -> Option<ReferenceUse> {
    if call_form(bytes, start, end).is_some() {
        Some(ReferenceUse::Call)
    } else if assignment_precedes(bytes, start) && assigned_value_terminates(bytes, end) {
        Some(ReferenceUse::AssignedValue)
    } else {
        None
    }
}

fn shadowed_binding_spans(text: &str, expected: &str) -> Vec<(usize, usize)> {
    let lines = text.split_inclusive('\n').collect::<Vec<_>>();
    let mut starts = Vec::with_capacity(lines.len());
    let mut offset = 0usize;
    for line in &lines {
        starts.push(offset);
        offset += line.len();
    }
    let mut spans = Vec::new();
    for (line_index, raw_line) in lines.iter().enumerate() {
        let line = raw_line.trim_end_matches(['\r', '\n']);
        if binding_name_range(line, expected).is_none() {
            continue;
        }
        let indent = leading_spaces(line);
        let mut end = text.len();
        for cursor in line_index + 1..lines.len() {
            let candidate = lines[cursor].trim_end_matches(['\r', '\n']);
            let trimmed = candidate.trim();
            if trimmed.is_empty() || trimmed.starts_with("//") {
                continue;
            }
            if leading_spaces(candidate) < indent {
                end = starts[cursor];
                break;
            }
        }
        spans.push((starts[line_index], end));
    }
    spans
}

fn rewrite_calls(
    text: &str,
    original: &str,
    lifted: &str,
    parameters: &[String],
    require_call: bool,
) -> Result<(String, usize), RewriteBlocker> {
    let bytes = text.as_bytes();
    let mut output = String::with_capacity(text.len() + 64);
    let mut index = 0usize;
    let mut calls = 0usize;
    let shadowed = shadowed_binding_spans(text, original);
    let mut state = LexicalState::Code;
    while index < bytes.len() {
        let current = bytes[index];
        if let Some(step) = transition(state, bytes, index).map_err(|blocker| match blocker {
            FSharpLexicalBlocker::TripleQuotedString => RewriteBlocker::TripleQuotedString,
        })? {
            output.push_str(&text[index..index + step.consumed]);
            state = step.state;
            index += step.consumed;
            continue;
        }
        if character_literal_starts(bytes, index) {
            output.push('\'');
            state = LexicalState::CharacterLiteral;
            index += 1;
            continue;
        }
        if identifier_start(current) {
            let start = index;
            index += 1;
            while bytes.get(index).copied().is_some_and(identifier_continue) {
                index += 1;
            }
            let token = &text[start..index];
            if token == original {
                if shadowed
                    .iter()
                    .any(|(shadow_start, shadow_end)| *shadow_start <= start && start < *shadow_end)
                {
                    output.push_str(token);
                    continue;
                }
                if start > 0 && bytes[start - 1] == b'.' {
                    output.push_str(token);
                    continue;
                }
                if reference_use(bytes, start, index).is_none() {
                    return Err(RewriteBlocker::NonCallUse(original.to_owned()));
                }
                if parameters.is_empty() {
                    output.push_str(lifted);
                } else {
                    output.push('(');
                    output.push_str(lifted);
                    for parameter in parameters {
                        output.push(' ');
                        output.push_str(parameter);
                    }
                    output.push(')');
                }
                calls += 1;
            } else {
                output.push_str(token);
            }
            continue;
        }
        output.push(current as char);
        index += 1;
    }
    if require_call && calls == 0 {
        return Err(RewriteBlocker::MissingCall(original.to_owned()));
    }
    Ok((output, calls))
}

pub fn rewrite_call_sites(
    text: &str,
    original: &str,
    lifted: &str,
    parameters: &[String],
) -> Result<(String, usize), RewriteBlocker> {
    rewrite_calls(text, original, lifted, parameters, false)
}

fn parameter_names(parameters: &[ParameterSlot]) -> Vec<String> {
    parameters.iter().map(|slot| slot.name.clone()).collect()
}

#[must_use]
pub fn lifted_binding_name(owner: DeclarationId, component: usize, original: &str) -> String {
    format!("__spiral_lift_{}_{}_{}", owner.0, component, original)
}

fn ordered_binding_names(
    lines: &[String],
    names: &std::collections::BTreeSet<String>,
) -> Result<Vec<(usize, String)>, RewriteBlocker> {
    let mut result = Vec::new();
    for (line_index, line) in lines.iter().enumerate() {
        for name in names {
            if binding_name_range(line, name).is_some()
                && !result.iter().any(|(_, existing)| existing == name)
            {
                result.push((line_index, name.clone()));
            }
        }
    }
    if result.len() != names.len() {
        return Err(RewriteBlocker::MissingGroupMember);
    }
    result.sort_by_key(|(line_index, _)| *line_index);
    Ok(result)
}

pub fn outer_recursive_group_head(
    lines: &[&str],
    start: usize,
    owner_indent: usize,
) -> Option<usize> {
    let mut cursor = start;
    while cursor > 0 {
        cursor -= 1;
        let line = lines[cursor];
        let trimmed = line.trim();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let indent = leading_spaces(line);
        if indent > owner_indent {
            continue;
        }
        if indent < owner_indent {
            return None;
        }
        if trimmed.starts_with("and ") {
            continue;
        }
        return trimmed.starts_with("let rec ").then_some(cursor);
    }
    None
}

fn rewrite_recursive_group(
    owner: &Declaration<Linked>,
    group_index: usize,
    group: &LocalGroup,
    component: &ParametricComponent,
    call_requirement: CallRequirement,
) -> Result<RewriteArtifact<Applied>, RewriteBlocker> {
    if component.members.as_slice() != [group_index] {
        return Err(if component.members.len() == 1 {
            RewriteBlocker::MissingGroupMember
        } else {
            RewriteBlocker::MultiGroupComponent
        });
    }
    if group.names.is_empty() {
        return Err(RewriteBlocker::MultiBindingGroup);
    }
    let relative_start = group
        .start_line
        .checked_sub(owner.span.start)
        .ok_or(RewriteBlocker::InvalidLineSpan)?;
    let relative_end = group
        .end_line
        .checked_sub(owner.span.start)
        .ok_or(RewriteBlocker::InvalidLineSpan)?;
    let recursive_group_start = component
        .start_line
        .checked_sub(owner.span.start)
        .unwrap_or(relative_start);
    let mut lines = owner.text.lines().map(str::to_owned).collect::<Vec<_>>();
    if relative_start >= relative_end || relative_end > lines.len() {
        return Err(RewriteBlocker::InvalidLineSpan);
    }
    let owner_indent = lines.first().map_or(0, |line| leading_spaces(line));
    let local_indent = leading_spaces(&lines[relative_start]);
    if local_indent <= owner_indent {
        return Err(RewriteBlocker::InvalidLineSpan);
    }
    let parameters = parameter_names(&component.parameters);
    let definition_parameters =
        capture_definition_parameters_before(&owner.text, &parameters, relative_start);
    let selected = lines[relative_start..relative_end].to_vec();
    let mut hoisted_lines = selected
        .iter()
        .map(|line| dedent(line, local_indent - owner_indent))
        .collect::<Vec<_>>();
    let ordered = ordered_binding_names(&hoisted_lines, &group.names)?;
    let mappings = ordered
        .iter()
        .map(|(_, original)| {
            (
                original.clone(),
                lifted_binding_name(owner.id, component.component, original),
            )
        })
        .collect::<Vec<_>>();
    for ((line_index, original), (_, lifted)) in ordered.iter().zip(&mappings) {
        let typed_header = annotate_recursive_group_header_parameters(
            &hoisted_lines[*line_index],
            original,
            &owner.text,
            recursive_group_start,
        );
        hoisted_lines[*line_index] =
            rewrite_header(&typed_header, original, lifted, &definition_parameters)?;
    }
    lines.drain(relative_start..relative_end);
    let newline = char::from(10).to_string();
    let mut hoisted_text = hoisted_lines.join(&newline);
    let mut owner_text = lines.join(&newline);
    let mut rewritten_calls = 0usize;
    for (original, lifted) in &mappings {
        let (next_hoisted, internal_calls) =
            rewrite_calls(&hoisted_text, original, lifted, &parameters, false)?;
        let (next_owner, external_calls) =
            rewrite_calls(&owner_text, original, lifted, &parameters, false)?;
        if call_requirement.required() && internal_calls + external_calls == 0 {
            return Err(RewriteBlocker::MissingCall(original.clone()));
        }
        hoisted_text = next_hoisted;
        owner_text = next_owner;
        rewritten_calls += internal_calls + external_calls;
    }
    let trailing = owner.text.as_bytes().last() == Some(&10);
    let mut full_text = format!("{hoisted_text}{newline}{newline}{owner_text}");
    if trailing {
        full_text.push(char::from(10));
    }
    let mut edits = vec![AppliedEdit::Hoist {
        from_start_line: group.start_line,
        from_end_line: group.end_line,
        inserted_before_line: owner.span.start,
    }];
    for (original, lifted) in &mappings {
        edits.push(AppliedEdit::Rename {
            from: original.clone(),
            to: lifted.clone(),
        });
        edits.extend(parameters.iter().enumerate().map(|(ordinal, name)| {
            AppliedEdit::AddParameter {
                symbol: original.clone(),
                name: name.clone(),
                ordinal,
            }
        }));
        edits.push(AppliedEdit::RewriteCall {
            symbol: original.clone(),
            arguments: parameters.clone(),
        });
    }
    Ok(RewriteArtifact {
        owner: owner.id,
        component: component.component,
        original_fingerprint: owner.fingerprint,
        lifted_name: mappings
            .iter()
            .map(|(_, lifted)| lifted.clone())
            .collect::<Vec<_>>()
            .join(","),
        parameters,
        hoisted_text,
        owner_text,
        full_text,
        edits,
        rewritten_calls,
        stage: PhantomData,
    })
}

pub fn rewrite_bounded_owner(
    owner: &Declaration<Linked>,
    group_index: usize,
    group: &LocalGroup,
    component: &ParametricComponent,
) -> Result<RewriteArtifact<Applied>, RewriteBlocker> {
    rewrite_bounded_owner_with_requirement(
        owner,
        group_index,
        group,
        component,
        CallRequirement::Required,
    )
}

pub fn line_start_offset(text: &str, line_index: usize) -> usize {
    let mut offset = 0usize;
    for (index, line) in text.split_inclusive('\n').enumerate() {
        if index == line_index {
            return offset;
        }
        offset += line.len();
    }
    text.len()
}

fn rewrite_calls_in_line_scope(
    text: &str,
    start_line: usize,
    end_line: usize,
    original: &str,
    lifted: &str,
    parameters: &[String],
) -> Result<(String, usize), RewriteBlocker> {
    let start = line_start_offset(text, start_line);
    let end = line_start_offset(text, end_line).max(start);
    let (middle, calls) = rewrite_calls(&text[start..end], original, lifted, parameters, false)?;
    let mut output = String::with_capacity(text.len() + 64);
    output.push_str(&text[..start]);
    output.push_str(&middle);
    output.push_str(&text[end..]);
    Ok((output, calls))
}

pub fn rewrite_bounded_owner_with_requirement(
    owner: &Declaration<Linked>,
    group_index: usize,
    group: &LocalGroup,
    component: &ParametricComponent,
    call_requirement: CallRequirement,
) -> Result<RewriteArtifact<Applied>, RewriteBlocker> {
    if owner.id != group.owner || owner.id != component.owner {
        return Err(RewriteBlocker::OwnerMismatch);
    }
    if !component.eligible() {
        return Err(RewriteBlocker::ComponentBlocked);
    }
    if component.recursive || group.names.len() > 1 {
        return rewrite_recursive_group(owner, group_index, group, component, call_requirement);
    }
    if component.members.as_slice() != [group_index] {
        return Err(if component.members.len() == 1 {
            RewriteBlocker::MissingGroupMember
        } else {
            RewriteBlocker::MultiGroupComponent
        });
    }
    if group.names.len() != 1 {
        return Err(RewriteBlocker::MultiBindingGroup);
    }
    let original = group
        .names
        .iter()
        .next()
        .cloned()
        .ok_or(RewriteBlocker::MultiBindingGroup)?;
    let relative_start = group
        .start_line
        .checked_sub(owner.span.start)
        .ok_or(RewriteBlocker::InvalidLineSpan)?;
    let relative_end = group
        .end_line
        .checked_sub(owner.span.start)
        .ok_or(RewriteBlocker::InvalidLineSpan)?;
    let recursive_group_start = component
        .start_line
        .checked_sub(owner.span.start)
        .unwrap_or(relative_start);
    let mut lines = owner.text.lines().map(str::to_owned).collect::<Vec<_>>();
    if relative_start >= relative_end || relative_end > lines.len() {
        return Err(RewriteBlocker::InvalidLineSpan);
    }
    let owner_indent = lines.first().map_or(0, |line| leading_spaces(line));
    let local_indent = leading_spaces(&lines[relative_start]);
    if local_indent <= owner_indent {
        return Err(RewriteBlocker::InvalidLineSpan);
    }
    let parameters = parameter_names(&component.parameters);
    let definition_parameters =
        capture_definition_parameters_before(&owner.text, &parameters, relative_start);
    let lifted_name = lifted_binding_name(owner.id, component.component, &original);
    let selected = lines[relative_start..relative_end].to_vec();
    let mut hoisted_lines = selected
        .iter()
        .map(|line| dedent(line, local_indent - owner_indent))
        .collect::<Vec<_>>();
    let typed_header = annotate_recursive_group_header_parameters(
        &hoisted_lines[0],
        &original,
        &owner.text,
        recursive_group_start,
    );
    hoisted_lines[0] = rewrite_header(
        &typed_header,
        &original,
        &lifted_name,
        &definition_parameters,
    )?;
    let lexical_scope_end = lines
        .iter()
        .enumerate()
        .skip(relative_end)
        .find(|(_, line)| {
            let trimmed = line.trim();
            !trimmed.is_empty() && !trimmed.starts_with("//") && leading_spaces(line) < local_indent
        })
        .map_or(lines.len(), |(index, _)| index);
    let removed_lines = relative_end - relative_start;
    let lexical_scope_end_after = lexical_scope_end.saturating_sub(removed_lines);
    lines.drain(relative_start..relative_end);
    let newline = char::from(10).to_string();
    let owner_without_group = lines.join(&newline);
    let hoisted_text = hoisted_lines.join(&newline);
    let same_name_capture = parameters.iter().any(|parameter| parameter == &original);
    let (hoisted_text, internal_calls) = if same_name_capture {
        (hoisted_text, 0)
    } else {
        rewrite_calls(&hoisted_text, &original, &lifted_name, &parameters, false)?
    };
    let (owner_text, external_calls) = if same_name_capture {
        rewrite_calls_in_line_scope(
            &owner_without_group,
            relative_start,
            lexical_scope_end_after,
            &original,
            &lifted_name,
            &parameters,
        )?
    } else {
        rewrite_calls(
            &owner_without_group,
            &original,
            &lifted_name,
            &parameters,
            false,
        )?
    };
    if call_requirement.required() && internal_calls + external_calls == 0 {
        return Err(RewriteBlocker::MissingCall(original.clone()));
    }
    let rewritten_calls = internal_calls + external_calls;
    let trailing = owner.text.as_bytes().last() == Some(&10);
    let mut full_text = format!("{hoisted_text}{newline}{newline}{owner_text}");
    if trailing {
        full_text.push(char::from(10));
    }
    let mut edits = vec![
        AppliedEdit::Hoist {
            from_start_line: group.start_line,
            from_end_line: group.end_line,
            inserted_before_line: owner.span.start,
        },
        AppliedEdit::Rename {
            from: original.clone(),
            to: lifted_name.clone(),
        },
    ];
    edits.extend(
        parameters
            .iter()
            .enumerate()
            .map(|(ordinal, name)| AppliedEdit::AddParameter {
                symbol: original.clone(),
                name: name.clone(),
                ordinal,
            }),
    );
    edits.push(AppliedEdit::RewriteCall {
        symbol: original,
        arguments: parameters.clone(),
    });
    Ok(RewriteArtifact {
        owner: owner.id,
        component: component.component,
        original_fingerprint: owner.fingerprint,
        lifted_name,
        parameters,
        hoisted_text,
        owner_text,
        full_text,
        edits,
        rewritten_calls,
        stage: PhantomData,
    })
}

pub fn splice_rewritten_owner(
    source: &str,
    owner: &Declaration<Linked>,
    artifact: &RewriteArtifact<Applied>,
) -> Result<String, RewriteBlocker> {
    if owner.id != artifact.owner {
        return Err(RewriteBlocker::OwnerMismatch);
    }
    let lines = source.lines().collect::<Vec<_>>();
    let (start, end) = if owner.span.start == 0 {
        (0, owner.span.end)
    } else {
        (owner.span.start - 1, owner.span.end.saturating_sub(1))
    };
    if start >= end || end > lines.len() {
        return Err(RewriteBlocker::InvalidLineSpan);
    }
    let original_indent = lines[start..end]
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or(0, |line| leading_spaces(line));
    let align = |block: &str| -> Result<Vec<String>, RewriteBlocker> {
        let block_indent = block
            .lines()
            .find(|line| !line.trim().is_empty())
            .map_or(0, leading_spaces);
        if block_indent > original_indent {
            return Err(RewriteBlocker::InvalidLineSpan);
        }
        let padding = " ".repeat(original_indent - block_indent);
        Ok(block
            .lines()
            .map(|line| {
                if line.is_empty() {
                    String::new()
                } else {
                    format!("{padding}{line}")
                }
            })
            .collect())
    };
    let owner_continues_group = lines
        .get(start)
        .is_some_and(|line| line.trim_start().starts_with("and "));
    let insert_at = if owner_continues_group {
        outer_recursive_group_head(&lines, start, original_indent)
            .ok_or(RewriteBlocker::UnsupportedHeader)?
    } else {
        start
    };
    let mut output = Vec::<String>::new();
    output.extend(lines[..insert_at].iter().map(|line| (*line).to_owned()));
    output.extend(align(&artifact.hoisted_text)?);
    output.push(String::new());
    output.extend(
        lines[insert_at..start]
            .iter()
            .map(|line| (*line).to_owned()),
    );
    output.extend(align(&artifact.owner_text)?);
    output.extend(lines[end..].iter().map(|line| (*line).to_owned()));
    let mut text = output.join("\n");
    if source.ends_with('\n') {
        text.push('\n');
    }
    Ok(text)
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_lift::{LiftDisposition, LocalGroup};
    use spiral_split_lift_plan::{CaptureFlow, ParameterSlot};
    use spiral_split_model::{
        BoundaryReason, Declaration, DeclarationKind, LineSpan, Raw, fnv1a64,
    };
    use std::collections::BTreeSet;

    fn set(values: &[&str]) -> BTreeSet<String> {
        values.iter().map(|value| (*value).to_owned()).collect()
    }

    fn owner(text: &str) -> Declaration<Linked> {
        Declaration::<Raw>::new(
            DeclarationId(0),
            LineSpan {
                start: 0,
                end: text.lines().count(),
            },
            "let outer env value =".to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
        .restage()
    }

    #[test]
    fn annotates_untyped_header_from_recursive_group_witness() {
        let owner_text =
            "and ty_core s x = ty_core_impl s x\n#if DEBUG\n#endif\nand term (s : LangEnv) x = x\n";
        assert_eq!(
            annotate_recursive_group_header_parameters(
                "and ty_core s x = ty_core_impl s x",
                "ty_core",
                owner_text,
                0,
            ),
            "and ty_core (s: LangEnv) x = ty_core_impl s x"
        );
    }

    #[test]
    fn leaves_untyped_function_parameter_without_group_witness() {
        let owner_text =
            "let unrelated (ty : Ty) = ty\nand helper ty s = ty s\nand term (s : LangEnv) x = x\n";
        assert_eq!(
            annotate_recursive_group_header_parameters(
                "and helper ty s = ty s",
                "helper",
                owner_text,
                1,
            ),
            "and helper ty (s: LangEnv) = ty s"
        );
    }

    fn group() -> LocalGroup {
        LocalGroup {
            owner: DeclarationId(0),
            owner_heading: "let outer env value =".to_owned(),
            local_index: 0,
            start_line: 1,
            end_line: 2,
            line_count: 1,
            names: set(&["helper"]),
            parameters: set(&["x"]),
            references: set(&["env"]),
            captures: set(&["env"]),
            local_dependencies: BTreeSet::new(),
            disposition: LiftDisposition::Captures(set(&["env"])),
        }
    }

    fn component() -> ParametricComponent {
        ParametricComponent {
            owner: DeclarationId(0),
            component: 0,
            members: vec![0],
            names: set(&["helper"]),
            dependencies: BTreeSet::new(),
            line_count: 1,
            start_line: 1,
            end_line: 2,
            direct_captures: set(&["env"]),
            effective_captures: set(&["env"]),
            parameters: vec![ParameterSlot {
                ordinal: 0,
                name: "env".to_owned(),
                flow: CaptureFlow::Direct {
                    parameter: "env".to_owned(),
                },
            }],
            recursive: false,
            blocker: None,
            intents: Vec::new(),
        }
    }

    #[test]
    fn function_value_header_accepts_injected_capture_parameters() {
        let parameters = vec!["env".to_owned()];
        let rewritten = rewrite_header(
            "    let choose = function",
            "choose",
            "__spiral_lift_choose",
            &parameters,
        )
        .expect("function-value header rewrite");
        assert_eq!(rewritten, "    let __spiral_lift_choose env = function");
    }

    #[test]
    fn hoists_single_captured_helper() {
        let source = "let outer env value =
    let helper x = env + x
    helper value
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert_eq!(
            artifact.full_text,
            "let __spiral_lift_0_0_helper env x = env + x

    let outer env value =
    (__spiral_lift_0_0_helper env) value
    "
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn non_recursive_same_name_capture_is_not_rewritten_inside_hoisted_body() {
        let source =
            "let outer helper value =\n    let helper x = helper (x + 1)\n    helper value\n";
        let mut local = group();
        local.names = set(&["helper"]);
        local.parameters = set(&["x"]);
        local.references = BTreeSet::new();
        local.captures = set(&["helper"]);
        local.disposition = LiftDisposition::Captures(set(&["helper"]));
        let mut parametric = component();
        parametric.names = set(&["helper"]);
        parametric.direct_captures = set(&["helper"]);
        parametric.effective_captures = set(&["helper"]);
        parametric.parameters = vec![ParameterSlot {
            ordinal: 0,
            name: "helper".to_owned(),
            flow: CaptureFlow::Direct {
                parameter: "helper".to_owned(),
            },
        }];
        let artifact = rewrite_bounded_owner(&owner(source), 0, &local, &parametric)
            .expect("same-name capture rewrite");
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_lift_0_0_helper helper x = helper (x + 1)")
        );
        assert!(artifact.owner_text.starts_with("let outer helper value ="));
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_0_helper helper) value")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn hoisted_helper_keeps_let_until_source_aware_splice() {
        let source = "and outer env value =\n    let helper x = env + x\n    helper value\n";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(
            artifact
                .hoisted_text
                .starts_with("let __spiral_lift_0_0_helper env x =")
        );
    }

    #[test]
    fn finds_outer_recursive_group_head_before_continuation() {
        let source = "let rec first x =\n    x\nand outer env value =\n    let helper x = env + x\n    helper value\n";
        let lines = source.lines().collect::<Vec<_>>();
        assert_eq!(outer_recursive_group_head(&lines, 2, 0), Some(0));
    }

    #[test]
    fn strings_and_comments_are_not_rewritten() {
        let source = "let outer env value =
    let helper x = env + x
    // helper ignored
    let text = \"helper\"
    helper value
    ";
        let mut group = group();
        group.end_line = 2;
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group, &component()).expect("rewrite");
        assert!(artifact.owner_text.contains("// helper ignored"));
        assert!(artifact.owner_text.contains("\"helper\""));
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn verbatim_string_trailing_backslash_does_not_leak() {
        let source = r#"let outer env value =
    let helper x = env + x
    let path = @"C:\"
    helper value
    "#;
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(artifact.owner_text.contains(r#"@"C:\""#));
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_0_helper env) value")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn verbatim_string_doubled_quotes_do_not_expose_identifiers() {
        let source = r#"let outer env value =
    let helper x = env + x
    let text = @"helper says ""helper"""
    helper value
    "#;
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(artifact.owner_text.contains(r#"@"helper says ""helper""""#));
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn rewrites_pipeline_target_as_partial_application() {
        let source = "let outer env value =
    let helper x = env + x
    value |> helper
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(
            artifact
                .owner_text
                .contains("value |> (__spiral_lift_0_0_helper env)")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn rewrites_indented_multiline_application() {
        let source = "let outer env value =
    let helper x = env + x
    helper
        value
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_0_helper env)\n        value")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn parenthesizes_captured_helper_when_passed_as_outer_argument() {
        let source = "let outer env value =
    let helper x = env + x
    consume helper value
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(
            artifact
                .owner_text
                .contains("consume (__spiral_lift_0_0_helper env) value")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn rewrites_terminal_higher_order_argument() {
        let source = "let outer env value =
    let helper x = env + x
    value |> List.map helper
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(
            artifact
                .owner_text
                .contains("value |> List.map (__spiral_lift_0_0_helper env)")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn rewrites_terminal_argument_after_braced_value() {
        let text = "Job.iterateServer { value = 1 } helper\n";
        let (rewritten, calls) =
            rewrite_call_sites(text, "helper", "lifted", &["env".to_owned()]).expect("rewrite");
        assert_eq!(rewritten, "Job.iterateServer { value = 1 } (lifted env)\n");
        assert_eq!(calls, 1);
    }

    #[test]
    fn rewrites_interpolated_string_argument() {
        let text = "fatal $\"message {value}\"\n";
        let (rewritten, calls) =
            rewrite_call_sites(text, "fatal", "lifted", &["env".to_owned()]).expect("rewrite");
        assert_eq!(rewritten, "(lifted env) $\"message {value}\"\n");
        assert_eq!(calls, 1);
    }

    #[test]
    fn ignores_qualified_member_with_same_name() {
        let text = "errors.fatal value\nfatal value\n";
        let (rewritten, calls) =
            rewrite_call_sites(text, "fatal", "lifted", &["env".to_owned()]).expect("rewrite");
        assert_eq!(rewritten, "errors.fatal value\n(lifted env) value\n");
        assert_eq!(calls, 1);
    }

    #[test]
    fn preserves_lexically_shadowed_helper_binding_and_calls() {
        let text = "helper value\nlet branch =\n    let rec helper x = x\n    helper value\nhelper value\n";
        let (rewritten, calls) =
            rewrite_call_sites(text, "helper", "lifted", &["env".to_owned()]).expect("rewrite");
        assert_eq!(
            rewritten,
            "(lifted env) value\nlet branch =\n    let rec helper x = x\n    helper value\n(lifted env) value\n"
        );
        assert_eq!(calls, 2);
    }

    #[test]
    fn rewrites_function_value_assignment() {
        let source = "let outer env value =
    let helper x = env + x
    let alias = helper
    alias value
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        assert!(
            artifact
                .owner_text
                .contains("let alias = (__spiral_lift_0_0_helper env)")
        );
        assert_eq!(artifact.rewritten_calls, 1);
    }

    #[test]
    fn rewrites_provider_assignment_to_explicit_partial_application() {
        let text = "provider <- helper\n";
        let (rewritten, references) = rewrite_call_sites(
            text,
            "helper",
            "lifted",
            &["state".to_owned(), "mailbox".to_owned()],
        )
        .expect("assigned function value is a safe closure boundary");
        assert_eq!(rewritten, "provider <- (lifted state mailbox)\n");
        assert_eq!(references, 1);
    }

    #[test]
    fn rejects_record_field_label_that_only_looks_like_a_function_value() {
        let text = "let record = { helper = value }\n";
        let error = rewrite_call_sites(text, "helper", "lifted", &["env".to_owned()])
            .expect_err("field label is not a value reference");
        assert_eq!(error, RewriteBlocker::NonCallUse("helper".to_owned()));
    }

    #[test]
    fn rewrites_single_binding_self_calls_when_recursive_flag_is_missing() {
        let source = "let outer env value =\n    let rec helper x =\n        if x = 0 then env else helper (x - 1)\n    helper value\n";
        let mut group = group();
        group.end_line = 3;
        group.line_count = 2;
        group.references = set(&["env", "helper"]);
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group, &component()).expect("rewrite");
        assert!(
            artifact
                .hoisted_text
                .contains("(__spiral_lift_0_0_helper env) (x - 1)")
        );
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_0_helper env) value")
        );
        assert_eq!(artifact.rewritten_calls, 2);
    }

    #[test]
    fn hoists_mutually_recursive_group() {
        let source = "let outer env value =
    let rec even n =
        if n = 0 then env else odd (n - 1)
    and odd n =
        if n = 0 then env else even (n - 1)
    even value
    ";
        let mut group = group();
        group.end_line = 5;
        group.line_count = 4;
        group.names = set(&["even", "odd"]);
        group.parameters = set(&["n"]);
        group.references = set(&["env", "even", "odd"]);
        group.local_dependencies = BTreeSet::new();
        let mut component = component();
        component.names = set(&["even", "odd"]);
        component.line_count = 4;
        component.end_line = 5;
        component.recursive = true;
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group, &component).expect("rewrite");
        assert!(
            artifact
                .hoisted_text
                .contains("let rec __spiral_lift_0_0_even env n =")
        );
        assert!(
            artifact
                .hoisted_text
                .contains("and __spiral_lift_0_0_odd env n =")
        );
        assert!(
            artifact
                .hoisted_text
                .contains("(__spiral_lift_0_0_odd env) (n - 1)")
        );
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_0_even env) value")
        );
        assert_eq!(artifact.rewritten_calls, 3);
    }

    #[test]
    fn recursive_group_rewrites_function_value_assignment() {
        let source = "let outer env value =
    let rec even n =
        if n = 0 then env else odd (n - 1)
    and odd n =
        if n = 0 then env else even (n - 1)
    let alias = even
    alias value
    ";
        let mut group = group();
        group.end_line = 5;
        group.line_count = 4;
        group.names = set(&["even", "odd"]);
        group.parameters = set(&["n"]);
        group.references = set(&["env", "even", "odd"]);
        let mut component = component();
        component.names = set(&["even", "odd"]);
        component.line_count = 4;
        component.end_line = 5;
        component.recursive = true;
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group, &component).expect("rewrite");
        assert!(
            artifact
                .owner_text
                .contains("let alias = (__spiral_lift_0_0_even env)")
        );
        assert_eq!(artifact.rewritten_calls, 3);
    }

    #[test]
    fn receipt_is_stable() {
        let source = "let outer env value =
    let helper x = env + x
    helper value
    ";
        let artifact =
            rewrite_bounded_owner(&owner(source), 0, &group(), &component()).expect("rewrite");
        let receipt = artifact.render_receipt();
        assert!(receipt.contains("__spiral_lift_0_0_helper"));
        assert!(receipt.contains("	env	1	"));
    }
}
