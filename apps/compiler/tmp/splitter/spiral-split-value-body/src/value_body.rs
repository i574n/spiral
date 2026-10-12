use spiral_split_binding_header::{BindingOrigin, BindingRole, binding_header};
use spiral_split_capture_parameter::definition_parameters_before;
use spiral_split_lift::{
    LiftDisposition, LocalGroup, UnsupportedReason, analyze_owner_lifts,
    has_untyped_captured_member_receiver, pattern_scoped_identifiers,
};
use spiral_split_lift_rewrite::outer_recursive_group_head;
use spiral_split_model::{Declaration, DeclarationId, Linked};
use std::collections::BTreeSet;
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Applied;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ValueBodyBlocker {
    OwnerMismatch,
    NotValueBinding,
    MultiBindingGroup,
    MutableCapture(BTreeSet<String>),
    InvalidLineSpan,
    UnsupportedHeader,
    FunctionDelegation(String),
    ExpressionDelegation(String),
}

impl Display for ValueBodyBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::OwnerMismatch => formatter.write_str("owner-mismatch"),
            Self::NotValueBinding => formatter.write_str("not-value-binding"),
            Self::MultiBindingGroup => formatter.write_str("multi-binding-group"),
            Self::MutableCapture(values) => write!(
                formatter,
                "mutable-capture:{}",
                values.iter().cloned().collect::<Vec<_>>().join(",")
            ),
            Self::InvalidLineSpan => formatter.write_str("invalid-line-span"),
            Self::UnsupportedHeader => formatter.write_str("unsupported-header"),
            Self::FunctionDelegation(reason) => write!(formatter, "function-delegation:{reason}"),
            Self::ExpressionDelegation(reason) => {
                write!(formatter, "expression-delegation:{reason}")
            }
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ValueBodyArtifact<S> {
    pub owner: DeclarationId,
    pub local_index: usize,
    pub original_fingerprint: u64,
    pub original_name: String,
    pub helper_name: String,
    pub captures: Vec<String>,
    pub hoisted_text: String,
    pub owner_text: String,
    pub full_text: String,
    stage: PhantomData<fn() -> S>,
}

impl ValueBodyArtifact<Applied> {
    #[must_use]
    pub fn render_receipt(&self) -> String {
        let mut output = String::from(
            "owner\tlocal_index\tfingerprint\toriginal\thelper\tcaptures\thoisted_lines\towner_lines\n",
        );
        let _ = writeln!(
            output,
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
            self.owner.0,
            self.local_index,
            self.original_fingerprint,
            self.original_name,
            self.helper_name,
            self.captures.join(","),
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
    if bytes.get(index..index + 4) == Some(b"let ") || bytes.get(index..index + 4) == Some(b"and ")
    {
        index += 4;
    } else {
        return None;
    }
    while bytes.get(index) == Some(&b' ') {
        index += 1;
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

fn dedent(line: &str, spaces: usize) -> String {
    if line.trim().is_empty() {
        String::new()
    } else if line.len() >= spaces && line.as_bytes()[..spaces].iter().all(|byte| *byte == b' ') {
        line[spaces..].to_owned()
    } else {
        line.to_owned()
    }
}

fn helper_header(
    line: &str,
    original: &str,
    helper: &str,
    captures: &[String],
) -> Result<String, ValueBodyBlocker> {
    let (start, end) =
        binding_name_range(line, original).ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let mut output = String::with_capacity(line.len() + helper.len() + captures.len() * 8 + 3);
    output.push_str(&line[..start]);
    output.push_str(helper);
    if captures.is_empty() {
        output.push_str(" ()");
    } else {
        for capture in captures {
            output.push(' ');
            output.push_str(capture);
        }
    }
    output.push_str(&line[end..]);
    Ok(output)
}

fn assigned_capture(text: &str, capture: &str) -> bool {
    text.lines().any(|line| {
        line.match_indices("<-").any(|(operator, _)| {
            let lhs = line[..operator].trim_end();
            let bytes = lhs.as_bytes();
            let mut start = bytes.len();
            while start > 0 && identifier_continue(bytes[start - 1]) {
                start -= 1;
            }
            lhs.get(start..) == Some(capture)
        })
    })
}

fn function_helper_header(
    line: &str,
    original: &str,
    helper: &str,
    captures: &[String],
) -> Result<String, ValueBodyBlocker> {
    if line.trim_start().starts_with("and ") {
        let indent = leading_spaces(line);
        let (_, end) =
            binding_name_range(line, original).ok_or(ValueBodyBlocker::UnsupportedHeader)?;
        let mut output = format!("{}let private {}", " ".repeat(indent), helper);
        for capture in captures {
            output.push(' ');
            output.push_str(capture);
        }
        output.push_str(&line[end..]);
        Ok(output)
    } else {
        helper_header(line, original, helper, captures)
    }
}

fn destructured_helper_header(
    line: &str,
    helper: &str,
    captures: &[String],
) -> Result<String, ValueBodyBlocker> {
    let indent = leading_spaces(line);
    let (_, rhs) = line
        .split_once('=')
        .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let mut output = format!("{}let private {}", " ".repeat(indent), helper);
    if captures.is_empty() {
        output.push_str(" ()");
    } else {
        for capture in captures {
            output.push(' ');
            output.push_str(capture);
        }
    }
    output.push_str(" =");
    if !rhs.trim().is_empty() {
        output.push(' ');
        output.push_str(rhs.trim_start());
    }
    Ok(output)
}

fn local_stub(line: &str, helper: &str, captures: &[String]) -> Result<String, ValueBodyBlocker> {
    let (left, _) = line
        .split_once('=')
        .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let mut output = String::with_capacity(left.len() + helper.len() + captures.len() * 8 + 6);
    output.push_str(left.trim_end());
    output.push_str(" = ");
    output.push_str(helper);
    if captures.is_empty() {
        output.push_str(" ()");
    } else {
        for capture in captures {
            output.push(' ');
            output.push_str(capture);
        }
    }
    Ok(output)
}

fn simple_identifier(text: &str) -> bool {
    let bytes = text.as_bytes();
    let Some(first) = bytes.first().copied() else {
        return false;
    };
    identifier_start(first) && bytes[1..].iter().copied().all(identifier_continue)
}

fn function_parameter_tokens(text: &str) -> Option<Vec<String>> {
    let mut tokens = Vec::new();
    let mut current = String::new();
    let mut depth = 0usize;
    for character in text.chars() {
        match character {
            '(' | '[' | '{' => {
                depth += 1;
                current.push(character);
            }
            ')' | ']' | '}' => {
                depth = depth.checked_sub(1)?;
                current.push(character);
            }
            character if character.is_whitespace() && depth == 0 => {
                if !current.trim().is_empty() {
                    tokens.push(current.trim().to_owned());
                    current.clear();
                }
            }
            _ => current.push(character),
        }
    }
    if depth != 0 {
        return None;
    }
    if !current.trim().is_empty() {
        tokens.push(current.trim().to_owned());
    }
    Some(tokens)
}

fn function_call_arguments(line: &str, original: &str) -> Result<Vec<String>, ValueBodyBlocker> {
    let (_, end) = binding_name_range(line, original).ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let tail = line.get(end..).ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let (header, _) = tail
        .split_once('=')
        .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let mut depth = 0usize;
    let mut parameter_end = header.len();
    for (index, character) in header.char_indices() {
        match character {
            '(' | '[' | '{' => depth += 1,
            ')' | ']' | '}' => depth = depth.saturating_sub(1),
            ':' if depth == 0 => {
                parameter_end = index;
                break;
            }
            _ => {}
        }
    }
    let parameters = function_parameter_tokens(&header[..parameter_end])
        .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    parameters
        .into_iter()
        .map(|token| {
            if token == "()" {
                return Ok(token);
            }
            if simple_identifier(&token) {
                return Ok(token);
            }
            let inner = token
                .strip_prefix('(')
                .and_then(|value| value.strip_suffix(')'))
                .ok_or(ValueBodyBlocker::UnsupportedHeader)?
                .trim();
            let name = inner.split_once(':').map_or(inner, |(name, _)| name).trim();
            if simple_identifier(name) {
                Ok(name.to_owned())
            } else {
                Err(ValueBodyBlocker::UnsupportedHeader)
            }
        })
        .collect()
}

fn function_stub(
    line: &str,
    original: &str,
    helper: &str,
    captures: &[String],
) -> Result<String, ValueBodyBlocker> {
    let (left, _) = line
        .split_once('=')
        .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let arguments = function_call_arguments(line, original)?;
    let mut output = String::with_capacity(line.len() + helper.len() + captures.len() * 8 + 24);
    output.push_str(left.trim_end());
    output.push_str(" = ");
    output.push_str(helper);
    if captures.is_empty() {
        output.push_str(" ()");
    } else {
        for capture in captures {
            output.push(' ');
            output.push_str(capture);
        }
    }
    for argument in arguments {
        output.push(' ');
        output.push_str(&argument);
    }
    Ok(output)
}

fn owner_parameters(owner: &Declaration<Linked>) -> BTreeSet<String> {
    owner
        .text
        .lines()
        .find_map(binding_header)
        .map_or_else(BTreeSet::new, |header| header.parameters)
}

#[must_use]
pub fn value_body_name(owner: DeclarationId, local_index: usize, original: &str) -> String {
    format!("__spiral_body_{}_{}_{}", owner.0, local_index, original)
}

fn enclosing_capturable_bindings(lines: &[&str], target_index: usize) -> BTreeSet<String> {
    let mut bound = BTreeSet::new();
    if target_index >= lines.len() {
        return bound;
    }
    let target_indent = leading_spaces(lines[target_index]);
    let mut index = 0usize;
    while index < target_index {
        let line = lines[index];
        let trimmed = line.trim_start();
        if !(trimmed.starts_with("let ") || trimmed.starts_with("and ")) {
            index += 1;
            continue;
        }
        let binding_indent = leading_spaces(line);
        let mut header_end = index;
        let mut header_text = line.to_owned();
        while !header_text.contains('=') && header_end + 1 < target_index {
            header_end += 1;
            header_text.push('\n');
            header_text.push_str(lines[header_end]);
        }
        let Some(header) = binding_header(&header_text) else {
            index += 1;
            continue;
        };
        if !matches!(
            header.role,
            BindingRole::Value | BindingRole::DestructuredValue | BindingRole::Function
        ) {
            index += 1;
            continue;
        }
        let scope_broken = lines[header_end + 1..target_index].iter().any(|candidate| {
            let trimmed = candidate.trim_start();
            !trimmed.is_empty()
                && !trimmed.starts_with("//")
                && leading_spaces(candidate) < binding_indent
        });
        if scope_broken {
            index += 1;
            continue;
        }
        let completed_before_target = target_indent <= binding_indent
            || lines[header_end + 1..target_index].iter().any(|candidate| {
                let trimmed = candidate.trim_start();
                !trimmed.is_empty()
                    && !trimmed.starts_with("//")
                    && leading_spaces(candidate) <= binding_indent
            });
        if completed_before_target {
            bound.extend(header.bound_names);
        }
        index += 1;
    }
    bound
}

fn enclosing_bindings(lines: &[&str], target_index: usize) -> BTreeSet<String> {
    let mut bound = BTreeSet::new();
    if target_index >= lines.len() {
        return bound;
    }
    let target_indent = leading_spaces(lines[target_index]);
    let mut index = 0usize;
    while index < target_index {
        let line = lines[index];
        let trimmed = line.trim_start();
        if !(trimmed.starts_with("let ") || trimmed.starts_with("and ")) {
            index += 1;
            continue;
        }
        let binding_indent = leading_spaces(line);
        let mut header_end = index;
        let mut header_text = line.to_owned();
        while !header_text.contains('=') && header_end + 1 < target_index {
            header_end += 1;
            header_text.push('\n');
            header_text.push_str(lines[header_end]);
        }
        let Some(header) = binding_header(&header_text) else {
            index += 1;
            continue;
        };
        let scope_broken = lines[header_end + 1..target_index].iter().any(|candidate| {
            let trimmed = candidate.trim_start();
            !trimmed.is_empty()
                && !trimmed.starts_with("//")
                && leading_spaces(candidate) < binding_indent
        });
        if !scope_broken {
            let completed_before_target = target_indent <= binding_indent
                || lines[header_end + 1..target_index].iter().any(|candidate| {
                    let trimmed = candidate.trim_start();
                    !trimmed.is_empty()
                        && !trimmed.starts_with("//")
                        && leading_spaces(candidate) <= binding_indent
                });
            if completed_before_target {
                bound.extend(header.bound_names);
            }
        }
        index += 1;
    }
    bound
}

fn binding_body_end(lines: &[&str], start: usize) -> usize {
    let indent = leading_spaces(lines[start]);
    for (index, line) in lines.iter().enumerate().skip(start + 1) {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        if leading_spaces(line) <= indent {
            return index;
        }
    }
    lines.len()
}

fn rewrite_sequential_expression_at_line(
    owner: &Declaration<Linked>,
    _absolute_line: usize,
    relative_start: usize,
    lines: &[&str],
) -> Result<ValueBodyArtifact<Applied>, ValueBodyBlocker> {
    let first = lines[relative_start];
    let trimmed = first.trim_start();
    if !(trimmed.contains("(fun ") || trimmed.contains("(fun(") || trimmed.ends_with(" fun")) {
        return Err(ValueBodyBlocker::UnsupportedHeader);
    }
    let owner_indent = owner
        .text
        .lines()
        .find(|line| !line.trim().is_empty() && !line.trim_start().starts_with("//"))
        .map_or(0, leading_spaces);
    let local_indent = leading_spaces(first);
    if local_indent <= owner_indent {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let relative_end = binding_body_end(lines, relative_start);
    if relative_end <= relative_start + 1 {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let selected = lines[relative_start..relative_end].join("\n");
    let mut visible = owner_parameters(owner);
    visible.extend(enclosing_bindings(lines, relative_start));
    let mut locally_bound = BTreeSet::new();
    for line in &lines[relative_start..relative_end] {
        if let Some(header) = binding_header(line) {
            locally_bound.extend(header.bound_names);
            locally_bound.extend(header.parameters);
        }
    }
    let captures = pattern_scoped_identifiers(&selected)
        .intersection(&visible)
        .filter(|name| !locally_bound.contains(*name))
        .cloned()
        .collect::<BTreeSet<_>>();
    if has_untyped_captured_member_receiver(&owner.text, relative_start, &selected, &captures) {
        return Err(ValueBodyBlocker::ExpressionDelegation(
            "captured-member-receiver".to_owned(),
        ));
    }
    let mutable_captures = captures
        .iter()
        .filter(|capture| assigned_capture(&selected, capture))
        .cloned()
        .collect::<BTreeSet<_>>();
    if !mutable_captures.is_empty() {
        return Err(ValueBodyBlocker::MutableCapture(mutable_captures));
    }
    let captures = captures.into_iter().collect::<Vec<_>>();
    let capture_definitions = definition_parameters_before(&owner.text, &captures, relative_start);
    let helper = value_body_name(owner.id, relative_start, "expr");
    let mut header = format!("{}let private {}", " ".repeat(owner_indent), helper);
    for capture in &capture_definitions {
        header.push(' ');
        header.push_str(capture);
    }
    header.push_str(" () =");
    let body_indent = owner_indent + 4;
    let remove = local_indent.saturating_sub(body_indent);
    let body = lines[relative_start..relative_end]
        .iter()
        .map(|line| dedent(line, remove))
        .collect::<Vec<_>>()
        .join("\n");
    let hoisted_text = format!("{header}\n{body}");
    let mut call = format!("{}{}", " ".repeat(local_indent), helper);
    for capture in &captures {
        call.push(' ');
        call.push_str(capture);
    }
    call.push_str(" ()");
    let mut owner_lines =
        Vec::<String>::with_capacity(lines.len() - (relative_end - relative_start) + 1);
    owner_lines.extend(
        lines[..relative_start]
            .iter()
            .map(|line| (*line).to_owned()),
    );
    owner_lines.push(call);
    owner_lines.extend(lines[relative_end..].iter().map(|line| (*line).to_owned()));
    let mut owner_text = owner_lines.join("\n");
    if owner.text.ends_with('\n') {
        owner_text.push('\n');
    }
    let full_text = format!("{hoisted_text}\n\n{owner_text}");
    Ok(ValueBodyArtifact {
        owner: owner.id,
        local_index: relative_start,
        original_fingerprint: owner.fingerprint,
        original_name: "expression".to_owned(),
        helper_name: helper,
        captures,
        hoisted_text,
        owner_text,
        full_text,
        stage: PhantomData,
    })
}

pub fn rewrite_value_body_at_line(
    owner: &Declaration<Linked>,
    absolute_line: usize,
) -> Result<ValueBodyArtifact<Applied>, ValueBodyBlocker> {
    let relative_start = absolute_line
        .checked_sub(owner.span.start)
        .ok_or(ValueBodyBlocker::InvalidLineSpan)?;
    let lines = owner.text.lines().collect::<Vec<_>>();
    if relative_start >= lines.len() {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let Some(parsed) = binding_header(lines[relative_start]) else {
        return rewrite_sequential_expression_at_line(owner, absolute_line, relative_start, &lines);
    };
    if parsed.role == BindingRole::Function {
        let (groups, _) = analyze_owner_lifts(owner);
        let group = groups
            .iter()
            .find(|group| {
                group.start_line == absolute_line
                    && group.names.contains(&parsed.name)
                    && group.owner == owner.id
            })
            .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
        return rewrite_value_body(owner, group);
    }
    if !matches!(
        parsed.role,
        BindingRole::Value | BindingRole::DestructuredValue
    ) || parsed.origin != BindingOrigin::Let
        || parsed.mutable
        || parsed.inline
        || parsed.bound_names.is_empty()
    {
        return Err(ValueBodyBlocker::NotValueBinding);
    }
    let relative_end = binding_body_end(&lines, relative_start);
    if relative_end <= relative_start + 1 {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let selected = lines[relative_start..relative_end].join("\n");
    let mut visible = owner_parameters(owner);
    visible.extend(enclosing_capturable_bindings(&lines, relative_start));
    let mut locally_bound = parsed.bound_names.clone();
    for line in &lines[relative_start + 1..relative_end] {
        if let Some(header) = binding_header(line) {
            locally_bound.extend(header.bound_names);
        }
    }
    let captures = pattern_scoped_identifiers(&selected)
        .intersection(&visible)
        .filter(|name| !locally_bound.contains(*name))
        .cloned()
        .collect::<BTreeSet<_>>();
    let group = LocalGroup {
        owner: owner.id,
        owner_heading: owner.heading.clone(),
        local_index: relative_start,
        start_line: absolute_line,
        end_line: owner.span.start + relative_end,
        line_count: relative_end - relative_start,
        names: parsed.bound_names,
        parameters: BTreeSet::new(),
        references: captures.clone(),
        captures,
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::ValueBinding),
    };
    rewrite_value_body(owner, &group)
}

pub fn rewrite_value_body(
    owner: &Declaration<Linked>,
    group: &LocalGroup,
) -> Result<ValueBodyArtifact<Applied>, ValueBodyBlocker> {
    if owner.id != group.owner {
        return Err(ValueBodyBlocker::OwnerMismatch);
    }
    let parameters = owner_parameters(owner);
    if group.names.is_empty() {
        return Err(ValueBodyBlocker::MultiBindingGroup);
    }
    let original = group.names.iter().cloned().collect::<Vec<_>>().join("_");
    let relative_start = group
        .start_line
        .checked_sub(owner.span.start)
        .ok_or(ValueBodyBlocker::InvalidLineSpan)?;
    let relative_end = group
        .end_line
        .checked_sub(owner.span.start)
        .ok_or(ValueBodyBlocker::InvalidLineSpan)?;
    let lines = owner.text.lines().map(str::to_owned).collect::<Vec<_>>();
    if relative_start >= relative_end || relative_end > lines.len() {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let parsed =
        binding_header(&lines[relative_start]).ok_or(ValueBodyBlocker::UnsupportedHeader)?;
    let binding_matches = match parsed.role {
        BindingRole::Value | BindingRole::Function => {
            group.names.len() == 1 && group.names.contains(&parsed.name)
        }
        BindingRole::DestructuredValue => parsed.bound_names == group.names,
        _ => false,
    };
    let function = parsed.role == BindingRole::Function;
    let delegatable_origin = parsed.origin == BindingOrigin::Let
        || (function && parsed.origin == BindingOrigin::RecursiveContinuation);
    if !binding_matches || !delegatable_origin || parsed.mutable || parsed.inline {
        return Err(ValueBodyBlocker::NotValueBinding);
    }
    if function {
        if !matches!(
            group.disposition,
            LiftDisposition::Liftable
                | LiftDisposition::Captures(_)
                | LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation)
        ) {
            return Err(ValueBodyBlocker::FunctionDelegation(
                group.disposition.to_string(),
            ));
        }
    } else if !matches!(
        group.disposition,
        LiftDisposition::Unsupported(UnsupportedReason::ValueBinding)
    ) {
        return Err(ValueBodyBlocker::NotValueBinding);
    }
    let owner_indent = lines.first().map_or(0, |line| leading_spaces(line));
    let local_indent = leading_spaces(&lines[relative_start]);
    if local_indent <= owner_indent {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let mut capture_set = group.captures.clone();
    if !group.local_dependencies.is_empty() {
        let (groups, _) = analyze_owner_lifts(owner);
        for dependency in &group.local_dependencies {
            let provider = groups
                .iter()
                .find(|candidate| candidate.local_index == *dependency)
                .ok_or(ValueBodyBlocker::UnsupportedHeader)?;
            capture_set.extend(provider.names.iter().cloned());
        }
    }
    let captures = capture_set.iter().cloned().collect::<Vec<_>>();
    let local_captures = capture_set
        .difference(&parameters)
        .cloned()
        .collect::<BTreeSet<_>>();
    let capture_definitions = definition_parameters_before(&owner.text, &captures, relative_start);
    let helper = value_body_name(owner.id, group.local_index, &original);
    let selected = lines[relative_start..relative_end].to_vec();
    let selected_text = selected.join("\n");
    let mutable_captures = local_captures
        .iter()
        .filter(|capture| assigned_capture(&selected_text, capture))
        .cloned()
        .collect::<BTreeSet<_>>();
    if !mutable_captures.is_empty() {
        return Err(ValueBodyBlocker::MutableCapture(mutable_captures));
    }
    let mut hoisted = selected
        .iter()
        .map(|line| dedent(line, local_indent - owner_indent))
        .collect::<Vec<_>>();
    hoisted[0] = if parsed.role == BindingRole::DestructuredValue {
        destructured_helper_header(&hoisted[0], &helper, &capture_definitions)?
    } else {
        let name = group
            .names
            .iter()
            .next()
            .ok_or(ValueBodyBlocker::MultiBindingGroup)?;
        if function {
            function_helper_header(&hoisted[0], name, &helper, &capture_definitions)?
        } else {
            helper_header(&hoisted[0], name, &helper, &capture_definitions)?
        }
    };
    let stub = if function {
        function_stub(&lines[relative_start], &parsed.name, &helper, &captures)?
    } else {
        local_stub(&lines[relative_start], &helper, &captures)?
    };
    let mut owner_lines = Vec::<String>::with_capacity(lines.len() - selected.len() + 1);
    owner_lines.extend(lines[..relative_start].iter().cloned());
    owner_lines.push(stub);
    owner_lines.extend(lines[relative_end..].iter().cloned());
    let newline = "\n";
    let hoisted_text = hoisted.join(newline);
    let mut owner_text = owner_lines.join(newline);
    if owner.text.ends_with('\n') {
        owner_text.push('\n');
    }
    let full_text = format!("{hoisted_text}\n\n{owner_text}");
    Ok(ValueBodyArtifact {
        owner: owner.id,
        local_index: group.local_index,
        original_fingerprint: owner.fingerprint,
        original_name: original,
        helper_name: helper,
        captures,
        hoisted_text,
        owner_text,
        full_text,
        stage: PhantomData,
    })
}

pub fn splice_value_body(
    source: &str,
    owner: &Declaration<Linked>,
    artifact: &ValueBodyArtifact<Applied>,
) -> Result<String, ValueBodyBlocker> {
    if owner.id != artifact.owner {
        return Err(ValueBodyBlocker::OwnerMismatch);
    }
    let lines = source.lines().collect::<Vec<_>>();
    let (start, end) = if owner.span.start == 0 {
        (0, owner.span.end)
    } else {
        (owner.span.start - 1, owner.span.end.saturating_sub(1))
    };
    if start >= end || end > lines.len() {
        return Err(ValueBodyBlocker::InvalidLineSpan);
    }
    let original_indent = lines[start..end]
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or(0, |line| leading_spaces(line));
    let align = |block: &str| -> Result<Vec<String>, ValueBodyBlocker> {
        let block_indent = block
            .lines()
            .find(|line| !line.trim().is_empty())
            .map_or(0, leading_spaces);
        if block_indent > original_indent {
            return Err(ValueBodyBlocker::InvalidLineSpan);
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
            .ok_or(ValueBodyBlocker::UnsupportedHeader)?
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
    use spiral_split_model::{BoundaryReason, DeclarationKind, LineSpan, Raw, fnv1a64};

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
            "let outer env input =".to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
        .restage()
    }

    fn group(captures: &[&str], start: usize, end: usize) -> LocalGroup {
        LocalGroup {
            owner: DeclarationId(0),
            owner_heading: "let outer env input =".to_owned(),
            local_index: 0,
            start_line: start,
            end_line: end,
            line_count: end - start,
            names: set(&["value"]),
            parameters: BTreeSet::new(),
            references: set(captures),
            captures: set(captures),
            local_dependencies: BTreeSet::new(),
            disposition: LiftDisposition::Unsupported(UnsupportedReason::ValueBinding),
        }
    }

    #[test]
    fn hoists_value_body_but_keeps_single_evaluation_at_original_point() {
        let text = "let outer env input =\n    let value = compute env input\n    consume value\n";
        let artifact =
            rewrite_value_body(&owner(text), &group(&["env", "input"], 1, 2)).expect("body split");
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_body_0_0_value env input = compute env input")
        );
        assert!(
            artifact
                .owner_text
                .contains("let value = __spiral_body_0_0_value env input")
        );
        assert!(artifact.owner_text.contains("consume value"));
    }

    #[test]
    fn zero_capture_body_uses_unit_thunk_to_preserve_evaluation_time() {
        let text =
            "let outer env input =\n    let value : int = computeGlobal ()\n    consume value\n";
        let artifact = rewrite_value_body(&owner(text), &group(&[], 1, 2)).expect("body split");
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_body_0_0_value () : int = computeGlobal ()")
        );
        assert!(
            artifact
                .owner_text
                .contains("let value : int = __spiral_body_0_0_value ()")
        );
    }

    #[test]
    fn multiline_value_moves_as_one_body_and_leaves_one_stub() {
        let text = "let outer env input =\n    let value =\n        input\n        |> map env\n    consume value\n";
        let artifact =
            rewrite_value_body(&owner(text), &group(&["env", "input"], 1, 4)).expect("body split");
        assert!(artifact.hoisted_text.contains("input\n    |> map env"));
        assert!(
            artifact
                .owner_text
                .contains("let value = __spiral_body_0_0_value env input\n    consume value")
        );
    }

    #[test]
    fn local_capture_is_parameterized_at_the_original_evaluation_point() {
        let text = "let outer env input =\n    let prior = input + 1\n    let value = prior + env\n    consume value\n";
        let artifact = rewrite_value_body(&owner(text), &group(&["env", "prior"], 2, 3))
            .expect("local capture should become a helper parameter");
        assert!(artifact.hoisted_text.contains("env prior = prior + env"));
        assert!(
            artifact
                .owner_text
                .contains("= __spiral_body_0_0_value env prior")
        );
    }

    #[test]
    fn nested_line_value_body_recovers_enclosing_values_as_parameters() {
        let text = "let outer input =\n    try\n        let gate = input > 0\n        if gate then\n            let value =\n                input + 1\n                |> consume gate\n            consume value\n        else ()\n    with _ -> ()\n";
        let artifact = rewrite_value_body_at_line(&owner(text), 4).expect("nested body split");
        assert!(artifact.captures.contains(&"gate".to_owned()));
        assert!(artifact.captures.contains(&"input".to_owned()));
        assert!(artifact.hoisted_text.contains("input"));
        assert!(artifact.owner_text.contains("__spiral_body_0_4_value"));
    }

    #[test]
    fn line_value_body_captures_preceding_local_function() {
        let text = "let outer input =\n    let normalize value = value + input\n    let value =\n        normalize input\n        |> id\n    consume value\n";
        let artifact = rewrite_value_body_at_line(&owner(text), 2)
            .expect("preceding local function should become a helper parameter");
        assert!(artifact.captures.contains(&"input".to_owned()));
        assert!(artifact.captures.contains(&"normalize".to_owned()));
        assert!(artifact.hoisted_text.contains("normalize input"));
        assert!(artifact.owner_text.contains("__spiral_body_0_2_value"));
    }

    #[test]
    fn destructured_line_value_body_returns_the_original_tuple_at_the_callsite() {
        let text = "let outer input =\n    let gate = input > 0\n    let left, right =\n        compute input gate\n        |> split\n    consume left right\n";
        let artifact = rewrite_value_body_at_line(&owner(text), 2).expect("tuple body split");
        assert_eq!(
            artifact.captures,
            vec!["gate".to_owned(), "input".to_owned()]
        );
        assert!(
            artifact
                .hoisted_text
                .contains("let private __spiral_body_0_2_left_right gate input =")
        );
        assert!(
            artifact
                .owner_text
                .contains("let left, right = __spiral_body_0_2_left_right gate input")
        );
    }

    #[test]
    fn delegates_local_function_body_and_passes_local_function_dependencies() {
        let text = "let outer (cache: System.Collections.Generic.Dictionary<int,int>) input =\n    let prior x = x + input\n    let helper key (value:int) =\n        if cache.ContainsKey(key) then prior value else prior key\n    helper 1 2\n";
        let artifact = rewrite_value_body_at_line(&owner(text), 2).expect("function delegation");
        assert!(artifact.captures.contains(&"cache".to_owned()));
        assert!(artifact.captures.contains(&"prior".to_owned()));
        assert!(artifact.hoisted_text.contains(
            "(cache: System.Collections.Generic.Dictionary<int,int>) prior key (value:int) ="
        ));
        assert!(artifact.owner_text.contains(
            "let helper key (value:int) = __spiral_body_0_1_helper cache prior key value"
        ));
    }

    #[test]
    fn direct_value_body_materializes_local_dependency_providers() {
        let text = "let outer input =\n    let minimalPhysicalOrZero value = value\n    let minimalPhysicalInt64OrZero value = value\n    let semanticCost label value = value\n    let astCost label value = value\n    let beatNo = 4L\n    let value =\n        let left = minimalPhysicalOrZero input\n        let right = minimalPhysicalInt64OrZero input\n        semanticCost \"phase\" beatNo + astCost \"ast\" beatNo + int64 left.Length + int64 right.Length\n    consume value\n";
        let owner = owner(text);
        let (groups, _) = analyze_owner_lifts(&owner);
        let group = groups
            .iter()
            .find(|group| group.names.contains("value"))
            .expect("value group");
        let artifact = rewrite_value_body(&owner, group)
            .expect("value dependency providers should become helper parameters");
        for provider in [
            "minimalPhysicalOrZero",
            "minimalPhysicalInt64OrZero",
            "semanticCost",
            "astCost",
            "beatNo",
        ] {
            assert!(
                artifact.captures.contains(&provider.to_owned()),
                "missing provider {provider}: {:?}",
                artifact.captures
            );
        }
    }

    #[test]
    fn delegates_unit_function_with_explicit_thunk_call() {
        let text = "let outer input =\n    let helper () =\n        input + 1\n    helper ()\n";
        let artifact = rewrite_value_body_at_line(&owner(text), 1).expect("unit delegation");
        assert!(
            artifact
                .hoisted_text
                .contains("__spiral_body_0_0_helper input () =")
        );
        assert!(
            artifact
                .owner_text
                .contains("helper () = __spiral_body_0_0_helper input ()")
        );
    }

    #[test]
    fn delegates_sequential_lambda_expression_at_the_same_evaluation_point() {
        let text = "let outer (cache: System.Collections.Generic.Dictionary<int,int>) input =\n    let prior = input + 1\n    register (fun key ->\n        cache.Add(key, prior))\n    consume input\n";
        let artifact =
            rewrite_value_body_at_line(&owner(text), 2).expect("sequential expression delegation");
        assert!(artifact.captures.contains(&"cache".to_owned()));
        assert!(artifact.captures.contains(&"prior".to_owned()));
        assert!(artifact.hoisted_text.contains(
            "let private __spiral_body_0_2_expr (cache: System.Collections.Generic.Dictionary<int,int>) prior () ="
        ));
        assert!(
            artifact
                .owner_text
                .contains("__spiral_body_0_2_expr cache prior ()\n    consume input")
        );
    }

    #[test]
    fn sequential_expression_respects_member_receiver_safety() {
        let text = "let outer errors input =\n    register (fun key ->\n        errors.Add(key))\n    consume input\n";
        let error = rewrite_value_body_at_line(&owner(text), 1)
            .expect_err("untyped member receiver must remain blocked");
        assert!(matches!(
            error,
            ValueBodyBlocker::ExpressionDelegation(reason) if reason.contains("captured-member-receiver")
        ));
    }

    #[test]
    fn delegates_orphan_recursive_continuation_body_without_breaking_wrapper() {
        let text = "let outer x =\n    let rec first n = n + x\n    installBridge first\n    and later n =\n        first n + x\n    later x\n";
        let artifact = rewrite_value_body_at_line(&owner(text), 3)
            .expect("recursive continuation body delegation");
        assert!(
            artifact
                .hoisted_text
                .contains("let private __spiral_body_0_1_later")
        );
        assert!(!artifact.hoisted_text.contains("and __spiral_body"));
        assert!(
            artifact
                .owner_text
                .contains("and later n = __spiral_body_0_1_later first x n")
        );
        assert!(artifact.captures.contains(&"first".to_owned()));
        assert!(artifact.captures.contains(&"x".to_owned()));
    }

    #[test]
    fn function_delegation_respects_member_receiver_safety() {
        let text = "let outer errors input =\n    let helper x =\n        errors.Add(x)\n    helper input\n";
        let error = rewrite_value_body_at_line(&owner(text), 1)
            .expect_err("untyped member receiver must remain blocked");
        assert!(
            matches!(error, ValueBodyBlocker::FunctionDelegation(reason) if reason.contains("captured-member-receiver"))
        );
    }

    #[test]
    fn assigned_local_capture_remains_fail_closed() {
        let text = "let outer env input =\n    let mutable prior = input + 1\n    let value =\n        prior <- prior + env\n        prior\n    consume value\n";
        let error = rewrite_value_body(&owner(text), &group(&["env", "prior"], 2, 5))
            .expect_err("assigned capture must remain blocked");
        assert!(
            matches!(error, ValueBodyBlocker::MutableCapture(values) if values.contains("prior"))
        );
    }
}
