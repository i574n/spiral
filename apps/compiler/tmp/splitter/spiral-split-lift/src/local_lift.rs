use rayon::prelude::*;
use spiral_split_binding_header::{
    BindingOrigin, BindingRole, binding_header as parse_binding_header,
};
use spiral_split_capture_parameter::definition_parameters_before;
use spiral_split_model::{Declaration, DeclarationId, DeclarationKind, Linked, SplitPlan};
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Discovered;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Classified;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum UnsupportedReason {
    ValueBinding,
    ComplexBinder,
    MutableBinding,
    InlineBinding,
    RecursiveContinuation,
    CapturedMemberReceiver,
    NoLocalBindings,
}

impl Display for UnsupportedReason {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        formatter.write_str(match self {
            Self::ValueBinding => "value-binding",
            Self::ComplexBinder => "complex-binder",
            Self::MutableBinding => "mutable-binding",
            Self::InlineBinding => "inline-binding",
            Self::RecursiveContinuation => "recursive-continuation",
            Self::CapturedMemberReceiver => "captured-member-receiver",
            Self::NoLocalBindings => "no-local-bindings",
        })
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum LiftDisposition {
    Liftable,
    Captures(BTreeSet<String>),
    Unsupported(UnsupportedReason),
}

impl Display for LiftDisposition {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Liftable => formatter.write_str("liftable"),
            Self::Captures(values) => write!(formatter, "captures:{}", join(values)),
            Self::Unsupported(reason) => write!(formatter, "unsupported:{reason}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum LocalDependency {
    Direct {
        symbol: String,
        provider: usize,
    },
    Through {
        symbol: String,
        provider: usize,
        tail: Box<LocalDependency>,
    },
}

impl LocalDependency {
    #[must_use]
    pub fn provider(&self) -> usize {
        match self {
            Self::Direct { provider, .. } | Self::Through { provider, .. } => *provider,
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LocalGroup {
    pub owner: DeclarationId,
    pub owner_heading: String,
    pub local_index: usize,
    pub start_line: usize,
    pub end_line: usize,
    pub line_count: usize,
    pub names: BTreeSet<String>,
    pub parameters: BTreeSet<String>,
    pub references: BTreeSet<String>,
    pub captures: BTreeSet<String>,
    pub local_dependencies: BTreeSet<usize>,
    pub disposition: LiftDisposition,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LocalComponent {
    pub owner: DeclarationId,
    pub component: usize,
    pub members: Vec<usize>,
    pub line_count: usize,
    pub captures: BTreeSet<String>,
    pub liftable: bool,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct OwnerForecast {
    pub owner: DeclarationId,
    pub heading: String,
    pub lines_before: usize,
    pub liftable_lines: usize,
    pub lines_after: usize,
    pub local_groups: usize,
    pub liftable_groups: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LiftSummary {
    pub owners: usize,
    pub groups: usize,
    pub components: usize,
    pub liftable_groups: usize,
    pub liftable_components: usize,
    pub liftable_lines: usize,
    pub captured_groups: usize,
    pub unsupported_groups: usize,
    pub max_owner_lines_before: usize,
    pub max_owner_lines_after: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LocalLiftPlan<S> {
    pub groups: Vec<LocalGroup>,
    pub components: Vec<LocalComponent>,
    pub owners: Vec<OwnerForecast>,
    pub summary: LiftSummary,
    stage: PhantomData<fn() -> S>,
}

#[derive(Clone, Debug)]
struct BindingHeader {
    bound_names: BTreeSet<String>,
    capturable_names: BTreeSet<String>,
    parameters: BTreeSet<String>,
    function: bool,
    active_pattern: bool,
    unsupported: Option<UnsupportedReason>,
}

#[derive(Clone, Debug)]
struct GroupDraft {
    owner: DeclarationId,
    owner_heading: String,
    local_index: usize,
    start_line: usize,
    end_line: usize,
    line_count: usize,
    names: BTreeSet<String>,
    parameters: BTreeSet<String>,
    references: BTreeSet<String>,
    captures: BTreeSet<String>,
    shadow_captures: BTreeSet<String>,
    active_pattern: bool,
    unsupported: Option<UnsupportedReason>,
}

fn join(values: &BTreeSet<String>) -> String {
    values.iter().cloned().collect::<Vec<_>>().join(",")
}

fn leading_spaces(line: &str) -> usize {
    line.bytes().take_while(|byte| *byte == b' ').count()
}

fn exact_indent(line: &str, spaces: usize) -> bool {
    leading_spaces(line) == spaces
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn character_literal_start(chars: &[char], index: usize) -> bool {
    if chars.get(index).copied() != Some('\'') {
        return false;
    }
    let Some(next) = chars.get(index + 1).copied() else {
        return false;
    };
    if next == '\\' {
        return true;
    }
    if identifier_start(next) {
        let mut end = index + 2;
        while end < chars.len() && identifier_continue(chars[end]) {
            end += 1;
        }
        return chars.get(end).copied() == Some('\'');
    }
    chars.get(index + 2).copied() == Some('\'')
}

fn identifiers(text: &str) -> Vec<String> {
    let chars = text.chars().collect::<Vec<_>>();
    let mut result = Vec::new();
    let mut index = 0usize;
    let mut string = false;
    let mut character = false;
    let mut line_comment = false;
    let mut block_depth = 0usize;
    while index < chars.len() {
        let current = chars[index];
        let next = chars.get(index + 1).copied();
        if line_comment {
            if current == '\n' {
                line_comment = false;
            }
            index += 1;
            continue;
        }
        if block_depth > 0 {
            if current == '(' && next == Some('*') {
                block_depth += 1;
                index += 2;
            } else if current == '*' && next == Some(')') {
                block_depth -= 1;
                index += 2;
            } else {
                index += 1;
            }
            continue;
        }
        if string {
            if current == '\\' {
                index = (index + 2).min(chars.len());
            } else {
                if current == '"' {
                    string = false;
                }
                index += 1;
            }
            continue;
        }
        if character {
            if current == '\\' {
                index = (index + 2).min(chars.len());
            } else {
                if current == '\'' {
                    character = false;
                }
                index += 1;
            }
            continue;
        }
        if current == '/' && next == Some('/') {
            line_comment = true;
            index += 2;
            continue;
        }
        if current == '(' && next == Some('*') {
            block_depth = 1;
            index += 2;
            continue;
        }
        if current == '"' {
            string = true;
            index += 1;
            continue;
        }
        if character_literal_start(&chars, index) {
            character = true;
            index += 1;
            continue;
        }
        if identifier_start(current) {
            let start = index;
            index += 1;
            while index < chars.len() && identifier_continue(chars[index]) {
                index += 1;
            }
            result.push(chars[start..index].iter().collect());
            continue;
        }
        index += 1;
    }
    result
}

fn captured_member_receivers(text: &str, captures: &BTreeSet<String>) -> BTreeSet<String> {
    let mut receivers = BTreeSet::new();
    if captures.is_empty() {
        return receivers;
    }
    let chars = text.chars().collect::<Vec<_>>();
    let mut index = 0usize;
    let mut string = false;
    let mut character = false;
    let mut line_comment = false;
    let mut block_depth = 0usize;
    while index < chars.len() {
        let current = chars[index];
        let next = chars.get(index + 1).copied();
        if line_comment {
            if current == '\n' {
                line_comment = false;
            }
            index += 1;
            continue;
        }
        if block_depth > 0 {
            if current == '(' && next == Some('*') {
                block_depth += 1;
                index += 2;
            } else if current == '*' && next == Some(')') {
                block_depth -= 1;
                index += 2;
            } else {
                index += 1;
            }
            continue;
        }
        if string {
            if current == '\\' {
                index = (index + 2).min(chars.len());
            } else {
                if current == '"' {
                    string = false;
                }
                index += 1;
            }
            continue;
        }
        if character {
            if current == '\\' {
                index = (index + 2).min(chars.len());
            } else {
                if current == '\'' {
                    character = false;
                }
                index += 1;
            }
            continue;
        }
        if current == '/' && next == Some('/') {
            line_comment = true;
            index += 2;
            continue;
        }
        if current == '(' && next == Some('*') {
            block_depth = 1;
            index += 2;
            continue;
        }
        if current == '"' {
            string = true;
            index += 1;
            continue;
        }
        if character_literal_start(&chars, index) {
            character = true;
            index += 1;
            continue;
        }
        if identifier_start(current) {
            let start = index;
            index += 1;
            while index < chars.len() && identifier_continue(chars[index]) {
                index += 1;
            }
            let name = chars[start..index].iter().collect::<String>();
            let mut after = index;
            while after < chars.len() && chars[after].is_whitespace() {
                after += 1;
            }
            if captures.contains(&name) && chars.get(after).copied() == Some('.') {
                receivers.insert(name);
            }
            continue;
        }
        index += 1;
    }
    receivers
}

pub fn has_untyped_captured_member_receiver(
    owner_text: &str,
    before_line: usize,
    text: &str,
    captures: &BTreeSet<String>,
) -> bool {
    let receivers = captured_member_receivers(text, captures);
    if receivers.is_empty() {
        return false;
    }
    let names = receivers.into_iter().collect::<Vec<_>>();
    definition_parameters_before(owner_text, &names, before_line)
        .into_iter()
        .zip(names)
        .any(|(definition, name)| definition == name)
}

fn keyword(value: &str) -> bool {
    matches!(
        value,
        "and"
            | "as"
            | "assert"
            | "do"
            | "done"
            | "elif"
            | "else"
            | "exception"
            | "false"
            | "finally"
            | "for"
            | "fun"
            | "function"
            | "if"
            | "in"
            | "inherit"
            | "inline"
            | "interface"
            | "internal"
            | "lazy"
            | "let"
            | "match"
            | "member"
            | "module"
            | "mutable"
            | "namespace"
            | "new"
            | "not"
            | "null"
            | "of"
            | "open"
            | "or"
            | "override"
            | "private"
            | "public"
            | "rec"
            | "return"
            | "static"
            | "struct"
            | "then"
            | "to"
            | "true"
            | "try"
            | "type"
            | "upcast"
            | "use"
            | "val"
            | "when"
            | "while"
            | "with"
            | "yield"
            | "_"
    )
}

fn binding_header(line: &str) -> Option<BindingHeader> {
    let parsed = parse_binding_header(line)?;
    let function_value = parsed.role == BindingRole::Value
        && line.split_once('=').is_some_and(|(_, rhs)| {
            let rhs = rhs.trim_start();
            rhs == "function" || rhs.starts_with("function ")
        });
    let function = parsed.role == BindingRole::Function || function_value;
    let unsupported = if parsed.origin == BindingOrigin::RecursiveContinuation {
        Some(UnsupportedReason::RecursiveContinuation)
    } else if parsed.mutable {
        Some(UnsupportedReason::MutableBinding)
    } else if parsed.inline {
        Some(UnsupportedReason::InlineBinding)
    } else {
        match parsed.role {
            BindingRole::Function => None,
            BindingRole::Value if function_value => None,
            BindingRole::Value => Some(UnsupportedReason::ValueBinding),
            BindingRole::DestructuredValue | BindingRole::ActivePattern => {
                Some(UnsupportedReason::ComplexBinder)
            }
        }
    };
    Some(BindingHeader {
        bound_names: parsed.bound_names,
        capturable_names: parsed.capturable_names,
        parameters: parsed.parameters,
        function,
        active_pattern: parsed.role == BindingRole::ActivePattern,
        unsupported,
    })
}

fn declaration_indent(declaration: &Declaration<Linked>) -> Option<usize> {
    declaration
        .text
        .lines()
        .find(|line| !line.trim().is_empty() && !line.trim_start().starts_with("//"))
        .map(leading_spaces)
}

fn outer_parameters(declaration: &Declaration<Linked>) -> BTreeSet<String> {
    let mut parameters = BTreeSet::new();
    let mut header_started = false;
    for line in declaration.text.lines() {
        let trimmed = line.trim();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        if !header_started {
            if !(trimmed.starts_with("let ") || trimmed.starts_with("and ")) {
                continue;
            }
            header_started = true;
            if let Some(header) = binding_header(line) {
                parameters.extend(header.parameters);
            }
            if trimmed.contains('=') {
                break;
            }
            continue;
        }
        if trimmed.contains('=') {
            break;
        }
        let binder = trimmed
            .strip_prefix('(')
            .and_then(|body| body.split_once(':').map(|(names, _)| names).or(Some(body)))
            .unwrap_or(trimmed);
        parameters.extend(
            identifiers(binder)
                .into_iter()
                .filter(|name| !keyword(name))
                .filter(|name| {
                    name.chars()
                        .next()
                        .is_some_and(|character| character == '_' || character.is_lowercase())
                }),
        );
    }
    parameters
}

fn local_starts(lines: &[&str], local_indent: usize) -> Vec<usize> {
    let mut starts = Vec::new();
    for (index, line) in lines.iter().enumerate() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") || !exact_indent(line, local_indent) {
            continue;
        }
        if trimmed.starts_with("let ") || trimmed.starts_with("and ") {
            // A generated owner can interleave side-effect bridge expressions between
            // members of the original recursive local group. Keep modeling a later
            // `and` continuation even after such a bridge; body delegation leaves the
            // recursive wrapper in place and moves only the oversized implementation.
            starts.push(index);
        }
    }
    starts
}

fn transparent_local_indent(lines: &[&str], top_indent: usize) -> Option<usize> {
    let direct_indent = top_indent + 4;
    if !local_starts(lines, direct_indent).is_empty() {
        return Some(direct_indent);
    }
    let first_direct = lines.iter().find(|line| {
        let trimmed = line.trim_start();
        !trimmed.is_empty() && !trimmed.starts_with("//") && exact_indent(line, direct_indent)
    })?;
    if first_direct.trim() != "try" {
        return None;
    }
    let nested_indent = direct_indent + 4;
    (!local_starts(lines, nested_indent).is_empty()).then_some(nested_indent)
}

fn group_end(lines: &[&str], start: usize, local_indent: usize) -> usize {
    for (index, line) in lines.iter().enumerate().skip(start + 1) {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        if exact_indent(line, local_indent) {
            return index;
        }
    }
    lines.len()
}

fn group_headers(lines: &[&str], local_indent: usize) -> Vec<BindingHeader> {
    let mut headers = Vec::new();
    let mut index = 0usize;
    while index < lines.len() {
        let line = lines[index];
        let trimmed = line.trim_start();
        if !exact_indent(line, local_indent)
            || !(trimmed.starts_with("let ") || trimmed.starts_with("and "))
        {
            index += 1;
            continue;
        }
        let mut header_text = line.to_owned();
        let mut cursor = index + 1;
        while !header_text.contains('=') && cursor < lines.len() {
            let next = lines[cursor];
            let next_trimmed = next.trim_start();
            if exact_indent(next, local_indent)
                && (next_trimmed.starts_with("let ") || next_trimmed.starts_with("and "))
            {
                break;
            }
            header_text.push('\n');
            header_text.push_str(next);
            cursor += 1;
        }
        if let Some(header) = binding_header(&header_text) {
            headers.push(header);
        }
        index = cursor.max(index + 1);
    }
    headers
}

fn recursive_binding(line: &str) -> bool {
    let trimmed = line.trim_start();
    let Some(mut body) = trimmed.strip_prefix("let ") else {
        return trimmed.starts_with("and ");
    };
    loop {
        if let Some(rest) = body.strip_prefix("rec ") {
            let _ = rest;
            return true;
        }
        let before = body;
        for modifier in ["private ", "internal ", "public ", "inline "] {
            if let Some(rest) = body.strip_prefix(modifier) {
                body = rest;
                break;
            }
        }
        if body == before {
            return false;
        }
    }
}

fn non_recursive_shadow_captures(
    selected: &[&str],
    headers: &[BindingHeader],
    outer_bound: &BTreeSet<String>,
) -> BTreeSet<String> {
    if headers.len() != 1 || selected.first().is_none_or(|line| recursive_binding(line)) {
        return BTreeSet::new();
    }
    let text = selected.join("\n");
    let rhs = text.split_once('=').map_or("", |(_, rhs)| rhs);
    let rhs_identifiers = identifiers(rhs).into_iter().collect::<BTreeSet<_>>();
    headers[0]
        .bound_names
        .intersection(outer_bound)
        .filter(|name| rhs_identifiers.contains(*name))
        .cloned()
        .collect()
}

pub fn pattern_scoped_identifiers(text: &str) -> BTreeSet<String> {
    let mut references = BTreeSet::new();
    let mut case_scopes = Vec::<(usize, BTreeSet<String>)>::new();
    for line in text.lines() {
        let trimmed = line.trim_start();
        let indent = leading_spaces(line);
        let case_pattern = trimmed.strip_prefix('|').and_then(|case| {
            case.split_once("->").map(|(pattern, _)| {
                pattern
                    .split_once(" when ")
                    .map_or(pattern, |(value, _)| value)
            })
        });
        if case_pattern.is_some() {
            while case_scopes
                .last()
                .is_some_and(|(scope_indent, _)| *scope_indent >= indent)
            {
                case_scopes.pop();
            }
        } else if !trimmed.is_empty() && !trimmed.starts_with("//") {
            while case_scopes
                .last()
                .is_some_and(|(scope_indent, _)| indent <= *scope_indent)
            {
                case_scopes.pop();
            }
        }
        if let Some(pattern) = case_pattern {
            let bound = identifiers(pattern)
                .into_iter()
                .filter(|token| !keyword(token))
                .filter(|token| {
                    token
                        .chars()
                        .next()
                        .is_some_and(|character| character == '_' || character.is_lowercase())
                })
                .collect::<BTreeSet<_>>();
            case_scopes.push((indent, bound));
        }
        references.extend(
            identifiers(line)
                .into_iter()
                .filter(|token| !case_scopes.iter().any(|(_, bound)| bound.contains(token))),
        );
    }
    references
}

fn discover_owner(declaration: &Declaration<Linked>) -> Vec<GroupDraft> {
    if declaration.boundary.kind() != DeclarationKind::LetGroup {
        return Vec::new();
    }
    let Some(top_indent) = declaration_indent(declaration) else {
        return Vec::new();
    };
    let lines = declaration.text.lines().collect::<Vec<_>>();
    let Some(local_indent) = transparent_local_indent(&lines, top_indent) else {
        return Vec::new();
    };
    let starts = local_starts(&lines, local_indent);
    let mut outer_bound = outer_parameters(declaration);
    let mut drafts = Vec::new();
    for (local_index, start) in starts.iter().copied().enumerate() {
        let end = group_end(&lines, start, local_indent);
        let selected = &lines[start..end];
        let headers = group_headers(selected, local_indent);
        if headers.is_empty() {
            continue;
        }
        let names = headers
            .iter()
            .flat_map(|header| header.bound_names.iter().cloned())
            .collect::<BTreeSet<_>>();
        let capturable_names = headers
            .iter()
            .flat_map(|header| header.capturable_names.iter().cloned())
            .collect::<BTreeSet<_>>();
        let parameters = headers
            .iter()
            .flat_map(|header| header.parameters.iter().cloned())
            .collect::<BTreeSet<_>>();
        let text = selected.join(
            "
",
        );
        let references = pattern_scoped_identifiers(&text)
            .into_iter()
            .filter(|token| {
                !keyword(token) && !names.contains(token) && !parameters.contains(token)
            })
            .collect::<BTreeSet<_>>();
        let captures = references
            .intersection(&outer_bound)
            .cloned()
            .collect::<BTreeSet<_>>();
        let shadow_captures = non_recursive_shadow_captures(selected, &headers, &outer_bound);
        let unsupported = headers
            .iter()
            .find_map(|header| {
                header
                    .unsupported
                    .or_else(|| (!header.function).then_some(UnsupportedReason::ValueBinding))
            })
            .or_else(|| {
                has_untyped_captured_member_receiver(&declaration.text, start, &text, &captures)
                    .then_some(UnsupportedReason::CapturedMemberReceiver)
            });
        drafts.push(GroupDraft {
            owner: declaration.id,
            owner_heading: declaration.heading.clone(),
            local_index,
            start_line: declaration.span.start + start,
            end_line: declaration.span.start + end,
            line_count: end.saturating_sub(start),
            names: names.clone(),
            parameters,
            references,
            captures,
            shadow_captures,
            active_pattern: headers.iter().any(|header| header.active_pattern),
            unsupported,
        });
        outer_bound.extend(capturable_names);
    }
    drafts
}

fn shard_oversize_declarations(plan: &SplitPlan) -> BTreeSet<DeclarationId> {
    plan.shards
        .iter()
        .filter(|shard| shard.oversize)
        .flat_map(|shard| shard.declarations.iter().copied())
        .collect()
}

fn generated_draft(draft: &GroupDraft) -> bool {
    !draft.names.is_empty()
        && draft
            .names
            .iter()
            .all(|name| name.starts_with("__spiral_lift_") || name.starts_with("__spiral_match_"))
}

fn local_edges(drafts: &[GroupDraft]) -> Vec<BTreeSet<usize>> {
    let providers = drafts
        .iter()
        .enumerate()
        .filter(|(_, draft)| draft.unsupported != Some(UnsupportedReason::ValueBinding))
        .flat_map(|(index, draft)| {
            draft
                .names
                .iter()
                .cloned()
                .map(move |name| (name, (index, draft.active_pattern)))
        })
        .collect::<BTreeMap<_, _>>();
    drafts
        .iter()
        .map(|draft| {
            let generated_consumer = generated_draft(draft);
            draft
                .references
                .iter()
                .filter_map(|reference| providers.get(reference).copied())
                .filter_map(|(index, active_pattern_provider)| {
                    (!generated_consumer || active_pattern_provider).then_some(index)
                })
                .collect()
        })
        .collect()
}

fn strongly_connected(edges: &[BTreeSet<usize>]) -> Vec<Vec<usize>> {
    struct Tarjan<'a> {
        edges: &'a [BTreeSet<usize>],
        index: usize,
        indices: Vec<Option<usize>>,
        lowlink: Vec<usize>,
        stack: Vec<usize>,
        on_stack: Vec<bool>,
        components: Vec<Vec<usize>>,
    }
    fn visit(node: usize, state: &mut Tarjan<'_>) {
        state.indices[node] = Some(state.index);
        state.lowlink[node] = state.index;
        state.index += 1;
        state.stack.push(node);
        state.on_stack[node] = true;
        for next in &state.edges[node] {
            if state.indices[*next].is_none() {
                visit(*next, state);
                state.lowlink[node] = state.lowlink[node].min(state.lowlink[*next]);
            } else if state.on_stack[*next] {
                state.lowlink[node] = state.lowlink[node].min(state.indices[*next].unwrap_or(0));
            }
        }
        if state.lowlink[node] == state.indices[node].unwrap_or(usize::MAX) {
            let mut component = Vec::new();
            while let Some(member) = state.stack.pop() {
                state.on_stack[member] = false;
                component.push(member);
                if member == node {
                    break;
                }
            }
            component.sort_unstable();
            state.components.push(component);
        }
    }
    let mut state = Tarjan {
        edges,
        index: 0,
        indices: vec![None; edges.len()],
        lowlink: vec![0; edges.len()],
        stack: Vec::new(),
        on_stack: vec![false; edges.len()],
        components: Vec::new(),
    };
    for node in 0..edges.len() {
        if state.indices[node].is_none() {
            visit(node, &mut state);
        }
    }
    state.components.sort_by_key(|component| component[0]);
    state.components
}

fn classify_owner(drafts: Vec<GroupDraft>) -> (Vec<LocalGroup>, Vec<LocalComponent>) {
    let edges = local_edges(&drafts);
    let local_names = drafts
        .iter()
        .filter(|draft| draft.unsupported != Some(UnsupportedReason::ValueBinding))
        .flat_map(|draft| draft.names.iter().cloned())
        .collect::<BTreeSet<_>>();
    let empty_names = BTreeSet::new();
    let components = strongly_connected(&edges);
    let mut component_of = vec![0usize; drafts.len()];
    for (component, members) in components.iter().enumerate() {
        for member in members {
            component_of[*member] = component;
        }
    }
    let groups = drafts
        .iter()
        .enumerate()
        .map(|(index, draft)| {
            let hidden_names = if generated_draft(draft) {
                &empty_names
            } else {
                &local_names
            };
            let captures = draft
                .captures
                .difference(hidden_names)
                .chain(draft.shadow_captures.iter())
                .cloned()
                .collect::<BTreeSet<_>>();
            let disposition = if let Some(reason) = draft.unsupported {
                LiftDisposition::Unsupported(reason)
            } else if captures.is_empty() {
                LiftDisposition::Liftable
            } else {
                LiftDisposition::Captures(captures.clone())
            };
            LocalGroup {
                owner: draft.owner,
                owner_heading: draft.owner_heading.clone(),
                local_index: draft.local_index,
                start_line: draft.start_line,
                end_line: draft.end_line,
                line_count: draft.line_count,
                names: draft.names.clone(),
                parameters: draft.parameters.clone(),
                references: draft.references.clone(),
                captures,
                local_dependencies: edges[index].clone(),
                disposition,
            }
        })
        .collect::<Vec<_>>();
    let owner = drafts.first().map_or(DeclarationId(0), |draft| draft.owner);
    let classified_components = components
        .into_iter()
        .enumerate()
        .map(|(component, members)| {
            let captures = members
                .iter()
                .flat_map(|member| groups[*member].captures.iter().cloned())
                .collect::<BTreeSet<_>>();
            let liftable = members
                .iter()
                .all(|member| matches!(groups[*member].disposition, LiftDisposition::Liftable));
            LocalComponent {
                owner,
                component,
                line_count: members
                    .iter()
                    .map(|member| groups[*member].line_count)
                    .sum(),
                members,
                captures,
                liftable,
            }
        })
        .collect();
    let _ = component_of;
    (groups, classified_components)
}

#[must_use]
pub fn analyze_owner_lifts(
    declaration: &Declaration<Linked>,
) -> (Vec<LocalGroup>, Vec<LocalComponent>) {
    classify_owner(discover_owner(declaration))
}

#[must_use]
pub fn analyze_local_lifts(plan: &SplitPlan) -> LocalLiftPlan<Classified> {
    let oversize = shard_oversize_declarations(plan);
    let owner_rows = oversize
        .par_iter()
        .filter_map(|id| {
            let declaration = &plan.declarations[id.0];
            let drafts = discover_owner(declaration);
            if drafts.is_empty() {
                None
            } else {
                let (groups, components) = classify_owner(drafts);
                Some((
                    declaration.id,
                    declaration.heading.clone(),
                    declaration.line_count(),
                    groups,
                    components,
                ))
            }
        })
        .collect::<Vec<_>>();
    let mut groups = Vec::new();
    let mut components = Vec::new();
    let mut owners = Vec::new();
    for (owner, heading, lines_before, mut local_groups, mut local_components) in owner_rows {
        let group_base = groups.len();
        for component in &mut local_components {
            component.component += components.len();
            for member in &mut component.members {
                *member += group_base;
            }
        }
        let liftable_lines = local_components
            .iter()
            .filter(|component| component.liftable)
            .map(|component| component.line_count)
            .sum::<usize>();
        let liftable_groups = local_groups
            .iter()
            .filter(|group| matches!(group.disposition, LiftDisposition::Liftable))
            .count();
        owners.push(OwnerForecast {
            owner,
            heading,
            lines_before,
            liftable_lines,
            lines_after: lines_before.saturating_sub(liftable_lines),
            local_groups: local_groups.len(),
            liftable_groups,
        });
        groups.append(&mut local_groups);
        components.append(&mut local_components);
    }
    groups.sort_by_key(|group| (group.owner, group.local_index));
    components.sort_by_key(|component| (component.owner, component.component));
    owners.sort_by_key(|owner| owner.owner);
    let summary = LiftSummary {
        owners: owners.len(),
        groups: groups.len(),
        components: components.len(),
        liftable_groups: groups
            .iter()
            .filter(|group| matches!(group.disposition, LiftDisposition::Liftable))
            .count(),
        liftable_components: components
            .iter()
            .filter(|component| component.liftable)
            .count(),
        liftable_lines: components
            .iter()
            .filter(|component| component.liftable)
            .map(|component| component.line_count)
            .sum(),
        captured_groups: groups
            .iter()
            .filter(|group| matches!(group.disposition, LiftDisposition::Captures(_)))
            .count(),
        unsupported_groups: groups
            .iter()
            .filter(|group| matches!(group.disposition, LiftDisposition::Unsupported(_)))
            .count(),
        max_owner_lines_before: owners
            .iter()
            .map(|owner| owner.lines_before)
            .max()
            .unwrap_or(0),
        max_owner_lines_after: owners
            .iter()
            .map(|owner| owner.lines_after)
            .max()
            .unwrap_or(0),
    };
    LocalLiftPlan {
        groups,
        components,
        owners,
        summary,
        stage: PhantomData,
    }
}

#[must_use]
pub fn render_local_lift_summary(plan: &LocalLiftPlan<Classified>) -> String {
    let summary = &plan.summary;
    format!(
        "local_lift owners={} groups={} components={} liftable_groups={} liftable_components={} liftable_lines={} captured_groups={} unsupported_groups={} max_before={} max_after={}",
        summary.owners,
        summary.groups,
        summary.components,
        summary.liftable_groups,
        summary.liftable_components,
        summary.liftable_lines,
        summary.captured_groups,
        summary.unsupported_groups,
        summary.max_owner_lines_before,
        summary.max_owner_lines_after,
    )
}

#[must_use]
pub fn render_local_lift_tsv(plan: &LocalLiftPlan<Classified>) -> String {
    let mut output = String::from(
        "owner	heading	local	start	end	lines	names	parameters	captures	dependencies	disposition
",
    );
    for group in &plan.groups {
        let dependencies = group
            .local_dependencies
            .iter()
            .map(usize::to_string)
            .collect::<Vec<_>>()
            .join(",");
        let _ = writeln!(
            output,
            "{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}",
            group.owner.0,
            group.owner_heading.replace('\t', " "),
            group.local_index,
            group.start_line,
            group.end_line,
            group.line_count,
            join(&group.names),
            join(&group.parameters),
            join(&group.captures),
            dependencies,
            group.disposition,
        );
    }
    output.push_str(
        "
owner	heading	lines_before	liftable_lines	lines_after	local_groups	liftable_groups
",
    );
    for owner in &plan.owners {
        let _ = writeln!(
            output,
            "{}	{}	{}	{}	{}	{}	{}",
            owner.owner.0,
            owner.heading.replace('\t', " "),
            owner.lines_before,
            owner.liftable_lines,
            owner.lines_after,
            owner.local_groups,
            owner.liftable_groups,
        );
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{BoundaryReason, LineSpan, Raw};

    fn declaration(text: &str) -> Declaration<Linked> {
        Declaration::<Raw>::new(
            DeclarationId(0),
            LineSpan {
                start: 10,
                end: 10 + text.lines().count(),
            },
            "outer".to_owned(),
            format!("{text}\n"),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            1,
        )
        .restage()
    }

    #[test]
    fn capture_free_helper_is_liftable() {
        let value = declaration(
            "    let outer x =
        let helper y = y + 1
        helper x",
        );
        let drafts = discover_owner(&value);
        let (groups, components) = classify_owner(drafts);
        assert_eq!(groups.len(), 1);
        assert!(matches!(groups[0].disposition, LiftDisposition::Liftable));
        assert!(components[0].liftable);
    }

    #[test]
    fn outer_parameter_capture_blocks_lift() {
        let value = declaration(
            "    let outer x =
        let helper y = x + y
        helper 1",
        );
        let drafts = discover_owner(&value);
        let (groups, components) = classify_owner(drafts);
        assert!(matches!(
            groups[0].disposition,
            LiftDisposition::Captures(_)
        ));
        assert!(groups[0].captures.contains("x"));
        assert!(!components[0].liftable);
    }

    #[test]
    fn multiline_owner_header_parameters_are_capturable() {
        let value = declaration(
            "    let outer<'T>
        (context: Context)
        (tag: string)
        (f: Context -> 'T)
        : 'T option =
        let spawn () =
            ignore tag
            Some (f context)
        spawn ()",
        );
        assert_eq!(
            outer_parameters(&value),
            BTreeSet::from(["context".to_owned(), "f".to_owned(), "tag".to_owned()])
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert_eq!(
            drafts[0].captures,
            BTreeSet::from(["context".to_owned(), "f".to_owned(), "tag".to_owned()])
        );
    }

    #[test]
    fn recursive_continuation_blocks_partial_group_hoist() {
        let value = declaration(
            "    let outer x =
        let rec even n = if n = 0 then true else odd (n - 1)
        and odd n = if n = 0 then false else even (n - 1)
        even x",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(drafts[0].names, BTreeSet::from(["even".to_owned()]));
        assert_eq!(drafts[1].names, BTreeSet::from(["odd".to_owned()]));
        let (groups, components) = classify_owner(drafts);
        assert!(matches!(groups[0].disposition, LiftDisposition::Liftable));
        assert!(matches!(
            groups[1].disposition,
            LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation)
        ));
        assert_eq!(components.len(), 1);
        assert_eq!(components[0].members, vec![0, 1]);
        assert!(!components[0].liftable);
    }

    #[test]
    fn orphan_recursive_continuation_after_bridge_is_still_discovered() {
        let value = declaration(
            "    let outer x =\n        let rec first n = n + x\n        installBridge first\n        and later n = first n + x\n        later x",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(drafts[0].names, BTreeSet::from(["first".to_owned()]));
        assert_eq!(drafts[1].names, BTreeSet::from(["later".to_owned()]));
        let (groups, _) = classify_owner(drafts);
        assert!(matches!(
            groups[1].disposition,
            LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation)
        ));
        assert!(groups[1].captures.contains("x"));
    }

    #[test]
    fn previous_local_value_is_reported_as_capture() {
        let value = declaration(
            "    let outer x =
        let offset = x + 1
        let helper y = offset + y
        helper 1",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(drafts[1].captures, BTreeSet::from(["offset".to_owned()]));
    }

    #[test]
    fn previous_local_value_after_generic_type_parameter_is_reported_as_capture() {
        let value = declaration(
            "    let outer () =\n        let dispatch = function\n            | true -> \"yes\"\n            | false -> \"no\"\n        let helper (cell: Hopac.IVar<'T>) (value: 'T) =\n            let typed : Holder<'T> = value\n            ignore cell\n            ignore typed\n            dispatch value\n        helper",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(drafts[1].captures, BTreeSet::from(["dispatch".to_owned()]));
    }

    #[test]
    fn non_recursive_same_name_binding_captures_outer_value() {
        let value =
            declaration("    let outer f value =\n        let f x = f (x + 1)\n        f value");
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert_eq!(drafts[0].shadow_captures, BTreeSet::from(["f".to_owned()]));
        let (groups, components) = classify_owner(drafts);
        assert_eq!(groups[0].captures, BTreeSet::from(["f".to_owned()]));
        assert!(groups[0].local_dependencies.is_empty());
        assert!(!components[0].liftable);
    }

    #[test]
    fn recursive_same_name_binding_does_not_capture_outer_value() {
        let value = declaration(
            "    let outer f value =\n        let rec f x = if x = 0 then value else f (x - 1)\n        f value",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(drafts[0].shadow_captures.is_empty());
        let (groups, _) = classify_owner(drafts);
        assert!(!groups[0].captures.contains("f"));
    }

    #[test]
    fn function_value_binding_is_liftable() {
        let value = declaration(
            "    let outer () =\n        let choose = function\n            | Some x -> x\n            | None -> failwith \"none\"\n        choose",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(drafts[0].unsupported.is_none());
        assert!(drafts[0].captures.is_empty());
        let (groups, components) = classify_owner(drafts);
        assert_eq!(groups[0].disposition, LiftDisposition::Liftable);
        assert!(components[0].liftable);
    }

    #[test]
    fn tuple_value_binding_is_classified_as_complex_binder() {
        let value = declaration(
            "    let outer state node =\n        let nextEvalNodePath, reCount = state, node\n        reCount",
        );
        let drafts = discover_owner(&value);
        let (groups, components) = classify_owner(drafts);
        let expected = LiftDisposition::Unsupported(UnsupportedReason::ComplexBinder);
        assert_eq!(groups[0].disposition, expected);
        assert!(!components[0].liftable);
    }

    #[test]
    fn active_pattern_cases_are_dependencies_not_captures() {
        let value = declaration(
            "    let outer state =\n        let (|Ready|Pending|) ivar = if true then Ready ivar else Pending ivar\n        let __spiral_match_helper input = match input with | Ready value -> value | Pending _ -> 0\n        __spiral_match_helper state",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(
            drafts[0].names,
            BTreeSet::from(["Pending".to_owned(), "Ready".to_owned()])
        );
        assert_eq!(
            drafts[0].unsupported,
            Some(UnsupportedReason::ComplexBinder)
        );
        assert!(drafts[1].captures.is_empty());
        let (groups, _) = classify_owner(drafts);
        assert!(groups[1].local_dependencies.contains(&0));
    }

    #[test]
    fn pattern_alias_does_not_capture_outer_same_name() {
        let value = declaration(
            "    let outer x state =
        let choose input = function
            | Some _ as x -> x
            | None -> input
        choose state",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(!drafts[0].captures.contains("x"));
    }

    #[test]
    fn pattern_alias_does_not_hide_real_outer_capture() {
        let value = declaration(
            "    let outer x state =
        let choose input =
            let before = x
            match input with
            | Some _ as x -> x
            | None -> before
        choose state",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(drafts[0].captures.contains("x"));
    }

    #[test]
    fn simple_pattern_binder_does_not_capture_outer_same_name() {
        let value = declaration(
            "    let outer x state =
        let choose = function
            | x -> x
        choose state",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(!drafts[0].captures.contains("x"));
    }

    #[test]
    fn pattern_guard_keeps_real_outer_capture() {
        let value = declaration(
            "    let outer pred state =
        let choose = function
            | Some x when pred x -> x
            | None -> false
        choose state",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert_eq!(drafts[0].captures, BTreeSet::from(["pred".to_owned()]));
    }

    #[test]
    fn nested_match_keeps_enclosing_case_binding_shadowed() {
        let value = declaration(
            "    let outer x state =\n        let choose xs =\n            match xs with\n            | x :: rest ->\n                match rest with\n                | y :: _ when x = y -> x\n                | _ -> x\n            | [] -> state\n        choose []",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(!drafts[0].captures.contains("x"));
        assert_eq!(drafts[0].captures, BTreeSet::from(["state".to_owned()]));
    }

    #[test]
    fn multiline_function_header_is_not_misclassified_as_value_binding() {
        let value = declaration(
            "    let outer env =\n        let helper\n            (x : int)\n            : int =\n            env + x\n        helper 1",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert_eq!(drafts[0].parameters, BTreeSet::from(["x".to_owned()]));
        assert_eq!(drafts[0].captures, BTreeSet::from(["env".to_owned()]));
        assert_eq!(drafts[0].unsupported, None);
    }

    #[test]
    fn transparent_try_body_exposes_nested_local_bindings() {
        let value = declaration(
            "    let outer x =\n        try\n            let prior = x + 1\n            let value = prior + 2\n            value\n        with _ -> 0",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(drafts[0].names, BTreeSet::from(["prior".to_owned()]));
        assert_eq!(drafts[1].captures, BTreeSet::from(["prior".to_owned()]));
    }

    #[test]
    fn captured_member_receiver_is_blocked_before_parametric_hoist() {
        let value = declaration(
            "    let outer errors r vars =
        let helper r vars =
            if List.exists id vars then errors.Add(r, vars)
        helper r vars",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert_eq!(drafts[0].captures, BTreeSet::from(["errors".to_owned()]));
        assert_eq!(
            drafts[0].unsupported,
            Some(UnsupportedReason::CapturedMemberReceiver)
        );
        let (groups, components) = classify_owner(drafts);
        assert_eq!(
            groups[0].disposition,
            LiftDisposition::Unsupported(UnsupportedReason::CapturedMemberReceiver)
        );
        assert!(!components[0].liftable);
    }

    #[test]
    fn typed_captured_member_receiver_is_liftable() {
        let value = declaration(
            "    let outer x =
        let cache = System.Collections.Concurrent.ConcurrentDictionary<int,int>()
        let helper key value =
            cache.TryAdd(key, value)
        helper x x",
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 2);
        assert_eq!(drafts[1].captures, BTreeSet::from(["cache".to_owned()]));
        assert_eq!(drafts[1].unsupported, None);
        let (groups, _) = classify_owner(drafts);
        assert!(!matches!(
            groups[1].disposition,
            LiftDisposition::Unsupported(UnsupportedReason::CapturedMemberReceiver)
        ));
    }

    #[test]
    fn member_receiver_text_inside_string_or_comment_does_not_block() {
        let value = declaration(
            r#"    let outer errors =
        let helper y =
            // errors.Add(y)
            let text = "errors.Add(y)"
            y + text.Length
        helper 1"#,
        );
        let drafts = discover_owner(&value);
        assert_eq!(drafts.len(), 1);
        assert!(drafts[0].captures.is_empty());
        assert_eq!(drafts[0].unsupported, None);
    }

    #[test]
    fn strings_and_comments_do_not_create_captures() {
        let value = declaration(
            "    let outer x =\n        let helper y =\n            // x\n            let text = \"x\"\n            y + text.Length\n        helper 1",
        );
        let drafts = discover_owner(&value);
        assert!(drafts[0].captures.is_empty());
    }
}
