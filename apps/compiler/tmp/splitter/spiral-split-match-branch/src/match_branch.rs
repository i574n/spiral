use spiral_split_binding_header::{BindingRole, binding_header, identifiers, keyword};
use spiral_split_fsharp_lex::code_only_mask;
use spiral_split_lift::{LiftDisposition, LocalGroup, UnsupportedReason};
use spiral_split_model::{Declaration, DeclarationId, Linked, fnv1a64};
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Discovered;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Certified;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Applied;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum MatchParent {
    OwnerBody,
    Local(usize),
}

impl Display for MatchParent {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::OwnerBody => formatter.write_str("body"),
            Self::Local(index) => write!(formatter, "{index}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BranchBlocker {
    OwnerMismatch,
    InvalidParentSpan,
    NoDirectMatch,
    NoDirectCases,
    InvalidCaseHeader(usize),
    GuardedCase(usize),
    SubjectShadowed(usize),
    MutableCapture { branch: usize, name: String },
    Lexical(String),
    EmptySelection,
    BranchNotFound(usize),
    RecursiveOwnerHead,
    InvalidOwnerHeader,
    PatternAnnotationMismatch(usize),
    ActivePatternDependency { branch: usize, name: String },
}

impl Display for BranchBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::OwnerMismatch => formatter.write_str("owner-mismatch"),
            Self::InvalidParentSpan => formatter.write_str("invalid-parent-span"),
            Self::NoDirectMatch => formatter.write_str("no-direct-match"),
            Self::NoDirectCases => formatter.write_str("no-direct-cases"),
            Self::InvalidCaseHeader(branch) => write!(formatter, "invalid-case-header:{branch}"),
            Self::GuardedCase(branch) => write!(formatter, "guarded-case:{branch}"),
            Self::SubjectShadowed(branch) => write!(formatter, "subject-shadowed:{branch}"),
            Self::MutableCapture { branch, name } => {
                write!(formatter, "mutable-capture:{branch}:{name}")
            }
            Self::Lexical(message) => write!(formatter, "lexical:{message}"),
            Self::EmptySelection => formatter.write_str("empty-selection"),
            Self::BranchNotFound(branch) => write!(formatter, "branch-not-found:{branch}"),
            Self::RecursiveOwnerHead => formatter.write_str("recursive-owner-head"),
            Self::InvalidOwnerHeader => formatter.write_str("invalid-owner-header"),
            Self::PatternAnnotationMismatch(branch) => {
                write!(formatter, "pattern-annotation-mismatch:{branch}")
            }
            Self::ActivePatternDependency { branch, name } => {
                write!(formatter, "active-pattern-dependency:{branch}:{name}")
            }
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BranchDisposition {
    Extractable,
    Blocked(BranchBlocker),
}

impl Display for BranchDisposition {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Extractable => formatter.write_str("extractable"),
            Self::Blocked(blocker) => write!(formatter, "blocked:{blocker}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchBranch {
    pub ordinal: usize,
    pub start_line: usize,
    pub end_line: usize,
    pub line_count: usize,
    pub pattern: String,
    pub guard: Option<String>,
    pub captures: BTreeSet<String>,
    pub mutable_captures: BTreeMap<String, String>,
    pub mirror_guard: bool,
    pub disposition: BranchDisposition,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchPatternAnnotation {
    pub binding: String,
    pub owner_type: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchBranchPlan<S> {
    pub owner: DeclarationId,
    pub parent: MatchParent,
    pub match_line: usize,
    pub subject: String,
    pub branches: Vec<MatchBranch>,
    stage: PhantomData<fn() -> S>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchBranchArtifact<S> {
    pub owner: DeclarationId,
    pub parent: MatchParent,
    pub original_fingerprint: u64,
    pub selected: Vec<usize>,
    pub extracted_lines: usize,
    pub max_branch_lines: usize,
    pub helper_count: usize,
    pub capture_count: usize,
    pub owner_text: String,
    pub hoisted_text: String,
    pub final_source: String,
    stage: PhantomData<fn() -> S>,
}

impl MatchBranchArtifact<Applied> {
    #[must_use]
    pub fn render_receipt(&self) -> String {
        let mut output = String::new();
        let _ = writeln!(
            output,
            "match_branch owner={} parent={} original_fingerprint={} selected={} extracted_lines={} max_branch_lines={} helper_count={} capture_count={}",
            self.owner.0,
            self.parent,
            self.original_fingerprint,
            self.selected
                .iter()
                .map(usize::to_string)
                .collect::<Vec<_>>()
                .join(","),
            self.extracted_lines,
            self.max_branch_lines,
            self.helper_count,
            self.capture_count,
        );
        output
    }
}

fn leading_spaces(line: &str) -> usize {
    line.bytes().take_while(|byte| *byte == b' ').count()
}

fn is_blank_or_comment(line: &str) -> bool {
    let trimmed = line.trim();
    trimmed.is_empty() || trimmed.starts_with("//")
}

fn match_subject_expression(line: &str) -> Option<String> {
    let trimmed = line.trim();
    let body = trimmed
        .strip_prefix("match ")?
        .strip_suffix(" with")?
        .trim();
    (!body.is_empty()).then(|| body.to_owned())
}

fn simple_match_subject(line: &str) -> Option<String> {
    let body = match_subject_expression(line)?;
    let tokens = identifiers(&body);
    (tokens.len() == 1 && tokens[0] == body).then_some(body)
}

fn simple_subject_name(subject: &str) -> Option<&str> {
    let tokens = identifiers(subject);
    (tokens.len() == 1 && tokens[0] == subject).then_some(subject)
}

fn parse_case_header(
    line: &str,
    ordinal: usize,
) -> Result<(String, Option<String>, String), BranchBlocker> {
    let trimmed = line.trim_start();
    let body = trimmed
        .strip_prefix('|')
        .ok_or(BranchBlocker::InvalidCaseHeader(ordinal))?
        .trim_start();
    let (head, tail) = body
        .split_once("->")
        .ok_or(BranchBlocker::InvalidCaseHeader(ordinal))?;
    let head = head.trim();
    let (pattern, guard) = match head.split_once(" when ") {
        Some((pattern, guard)) if !pattern.trim().is_empty() && !guard.trim().is_empty() => {
            (pattern.trim().to_owned(), Some(guard.trim().to_owned()))
        }
        Some(_) => return Err(BranchBlocker::GuardedCase(ordinal)),
        None if !head.is_empty() => (head.to_owned(), None),
        None => return Err(BranchBlocker::InvalidCaseHeader(ordinal)),
    };
    Ok((pattern, guard, tail.trim_start().to_owned()))
}

fn parse_case_header_span(
    lines: &[&str],
    ordinal: usize,
) -> Result<(String, Option<String>, String, usize), BranchBlocker> {
    let mut alternatives = Vec::<String>::new();
    for (offset, line) in lines.iter().enumerate() {
        if is_blank_or_comment(line) {
            continue;
        }
        let trimmed = line.trim_start();
        let body = trimmed
            .strip_prefix('|')
            .ok_or(BranchBlocker::InvalidCaseHeader(ordinal))?
            .trim_start();
        if body.contains("->") {
            let (pattern, guard, same_line_tail) = parse_case_header(line, ordinal)?;
            alternatives.push(pattern);
            return Ok((alternatives.join(" | "), guard, same_line_tail, offset + 1));
        }
        if body.is_empty() {
            return Err(BranchBlocker::InvalidCaseHeader(ordinal));
        }
        alternatives.push(body.to_owned());
    }
    Err(BranchBlocker::InvalidCaseHeader(ordinal))
}

fn direct_cases_at_indent(
    masked_lines: &[&str],
    anchor_index: usize,
    case_indent: usize,
) -> Vec<(usize, usize)> {
    let anchor_indent = leading_spaces(masked_lines[anchor_index]);
    let mut starts = Vec::new();
    let mut index = anchor_index + 1;
    let mut seen_case = false;
    let mut pending_or_header = false;
    while index < masked_lines.len() {
        let line = masked_lines[index];
        if is_blank_or_comment(line) {
            index += 1;
            continue;
        }
        let indent = leading_spaces(line);
        let trimmed = line.trim_start();
        if indent == case_indent && trimmed.starts_with('|') {
            if !pending_or_header {
                starts.push(index);
            }
            pending_or_header = !trimmed.contains("->");
            seen_case = true;
            index += 1;
            continue;
        }
        if seen_case && indent <= case_indent {
            break;
        }
        if !seen_case && indent <= anchor_indent {
            break;
        }
        index += 1;
    }
    let end = index;
    starts
        .iter()
        .enumerate()
        .map(|(ordinal, start)| {
            let next = starts.get(ordinal + 1).copied().unwrap_or(end);
            (*start, next)
        })
        .collect()
}

fn direct_cases(masked_lines: &[&str], match_index: usize) -> Vec<(usize, usize)> {
    direct_cases_at_indent(
        masked_lines,
        match_index,
        leading_spaces(masked_lines[match_index]),
    )
}

fn anonymous_function_case_indent(line: &str) -> Option<usize> {
    let trimmed = line.trim_end();
    let function_at = trimmed.rfind("function")?;
    let before = trimmed.get(..function_at)?;
    let after = trimmed.get(function_at + "function".len()..)?;
    if !after.trim().is_empty()
        || before.chars().next_back().is_some_and(|character| {
            character == '_' || character == '\'' || character.is_alphanumeric()
        })
    {
        return None;
    }
    Some(leading_spaces(line) + 4)
}

fn direct_match_already_extracted(masked_lines: &[&str], cases: &[(usize, usize)]) -> bool {
    let mut parsed_cases = 0usize;
    for (ordinal, (start, end)) in cases.iter().copied().enumerate() {
        let Ok((_, _, same_line_tail, header_lines)) =
            parse_case_header_span(&masked_lines[start..end], ordinal)
        else {
            continue;
        };
        parsed_cases += 1;
        let trailing = masked_lines[start + header_lines..end]
            .iter()
            .filter(|line| !is_blank_or_comment(line))
            .map(|line| line.trim())
            .collect::<Vec<_>>();
        if !same_line_tail.trim().is_empty() {
            if !same_line_tail.trim().starts_with("__spiral_match_") || !trailing.is_empty() {
                return false;
            }
        } else if trailing.len() != 1 || !trailing[0].starts_with("__spiral_match_") {
            return false;
        }
    }
    parsed_cases > 0
}

fn local_bound_names(lines: &[&str]) -> BTreeSet<String> {
    lines
        .iter()
        .filter_map(|line| binding_header(line))
        .flat_map(|header| {
            header
                .bound_names
                .into_iter()
                .chain(header.parameters)
                .collect::<Vec<_>>()
        })
        .collect()
}

fn recursive_binding_line(line: &str) -> bool {
    let trimmed = line.trim_start();
    let Some(mut body) = trimmed.strip_prefix("let ") else {
        return trimmed.starts_with("and ");
    };
    loop {
        if body.strip_prefix("rec ").is_some() {
            return true;
        }
        let before = body;
        for modifier in ["private ", "internal ", "public ", "inline ", "mutable "] {
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

fn non_recursive_shadow_uses_outer(lines: &[&str], name: &str) -> bool {
    lines.iter().any(|line| {
        let Some(header) = binding_header(line) else {
            return false;
        };
        if !header.bound_names.iter().any(|bound| bound == name) || recursive_binding_line(line) {
            return false;
        }
        line.split_once('=').is_some_and(|(_, rhs)| {
            identifiers(rhs)
                .into_iter()
                .any(|identifier| identifier == name)
        })
    })
}

fn lexical_binding_on_line(line: &str, name: &str) -> bool {
    if let Some(header) = binding_header(line)
        && header
            .bound_names
            .iter()
            .chain(header.parameters.iter())
            .any(|bound| bound == name)
    {
        return true;
    }

    let trimmed = line.trim_start();
    if let Some(case) = trimmed.strip_prefix('|')
        && let Some((pattern, _)) = case.split_once("->")
    {
        let pattern = pattern.split(" when ").next().unwrap_or(pattern);
        if identifiers(pattern).into_iter().any(|bound| bound == name) {
            return true;
        }
    }
    if let Some(fun_start) = trimmed.find("fun ") {
        let parameters = &trimmed[fun_start + 4..];
        if let Some((parameters, _)) = parameters.split_once("->")
            && identifiers(parameters)
                .into_iter()
                .any(|bound| bound == name)
        {
            return true;
        }
    }
    if let Some(loop_body) = trimmed.strip_prefix("for ")
        && identifiers(loop_body)
            .into_iter()
            .next()
            .is_some_and(|bound| bound == name)
    {
        return true;
    }
    false
}

fn unqualified_identifier_occurs(text: &str, name: &str) -> bool {
    let Ok(masked) = code_only_mask(text) else {
        return false;
    };
    let bytes = masked.as_bytes();
    let name_bytes = name.as_bytes();
    if name_bytes.is_empty() || name_bytes.len() > bytes.len() {
        return false;
    }
    let identifier_byte = |byte: u8| byte == b'_' || byte == b'\'' || byte.is_ascii_alphanumeric();
    for start in 0..=bytes.len() - name_bytes.len() {
        let end = start + name_bytes.len();
        if &bytes[start..end] != name_bytes {
            continue;
        }
        if start > 0 && identifier_byte(bytes[start - 1]) {
            continue;
        }
        if end < bytes.len() && identifier_byte(bytes[end]) {
            continue;
        }
        let mut prefix = start;
        while prefix > 0 && bytes[prefix - 1].is_ascii_whitespace() {
            prefix -= 1;
        }
        if prefix > 0 && bytes[prefix - 1] == b'.' {
            continue;
        }
        return true;
    }
    false
}

fn outer_reference_precedes_first_binding(lines: &[&str], name: &str) -> bool {
    for line in lines {
        let binds = lexical_binding_on_line(line, name);
        if !binds && unqualified_identifier_occurs(line, name) {
            return true;
        }
        if binds {
            if binding_header(line)
                .is_some_and(|header| header.parameters.iter().any(|parameter| parameter == name))
            {
                return false;
            }
            return !recursive_binding_line(line)
                && line
                    .split_once('=')
                    .is_some_and(|(_, rhs)| unqualified_identifier_occurs(rhs, name));
        }
    }
    false
}

fn lowercase_pattern_binding(name: &str) -> bool {
    name != "_"
        && !keyword(name)
        && name
            .chars()
            .next()
            .is_some_and(|character| character.is_ascii_lowercase())
}

fn nested_bound_names(lines: &[&str]) -> BTreeSet<String> {
    let mut bound = BTreeSet::new();
    for line in lines {
        let trimmed = line.trim_start();
        if let Some(case) = trimmed.strip_prefix('|') {
            if let Some((pattern, _)) = case.split_once("->") {
                let pattern = pattern.split(" when ").next().unwrap_or(pattern);
                bound.extend(
                    identifiers(pattern)
                        .into_iter()
                        .filter(|name| lowercase_pattern_binding(name)),
                );
            }
        }
        if let Some(fun_start) = trimmed.find("fun ") {
            let parameters = &trimmed[fun_start + 4..];
            if let Some((parameters, _)) = parameters.split_once("->") {
                bound.extend(
                    identifiers(parameters)
                        .into_iter()
                        .filter(|name| lowercase_pattern_binding(name)),
                );
            }
        }
        if let Some(loop_body) = trimmed.strip_prefix("for ") {
            if let Some(name) = identifiers(loop_body)
                .into_iter()
                .find(|name| lowercase_pattern_binding(name))
            {
                bound.insert(name);
            }
        }
    }
    bound
}

fn enclosing_case_bindings(lines: &[&str], target_index: usize) -> BTreeSet<String> {
    let mut bound = BTreeSet::new();
    if target_index >= lines.len() {
        return bound;
    }
    for (index, line) in lines.iter().enumerate().take(target_index) {
        let trimmed = line.trim_start();
        let Some(case_body) = trimmed.strip_prefix("| ") else {
            continue;
        };
        let Some((case_head, _)) = case_body.split_once("->") else {
            continue;
        };
        let case_indent = leading_spaces(line);
        let encloses_target = lines[index + 1..target_index].iter().all(|candidate| {
            let candidate_trimmed = candidate.trim_start();
            candidate_trimmed.is_empty()
                || candidate_trimmed.starts_with("//")
                || leading_spaces(candidate) > case_indent
        });
        if !encloses_target {
            continue;
        }
        let pattern = case_head.split(" when ").next().unwrap_or(case_head);
        bound.extend(
            identifiers(pattern)
                .into_iter()
                .filter(|name| lowercase_pattern_binding(name)),
        );
    }
    bound
}

fn enclosing_loop_bindings(lines: &[&str], target_index: usize) -> BTreeSet<String> {
    let mut bound = BTreeSet::new();
    if target_index >= lines.len() {
        return bound;
    }
    for (index, line) in lines.iter().enumerate().take(target_index) {
        let trimmed = line.trim_start();
        let Some(loop_body) = trimmed.strip_prefix("for ") else {
            continue;
        };
        let loop_indent = leading_spaces(line);
        let encloses_target = lines[index + 1..target_index].iter().all(|candidate| {
            let candidate_trimmed = candidate.trim_start();
            candidate_trimmed.is_empty()
                || candidate_trimmed.starts_with("//")
                || leading_spaces(candidate) > loop_indent
        });
        if !encloses_target {
            continue;
        }
        let binder = loop_body
            .split_once(" in ")
            .map(|(binder, _)| binder)
            .or_else(|| loop_body.split_once('=').map(|(binder, _)| binder))
            .unwrap_or(loop_body);
        bound.extend(
            identifiers(binder)
                .into_iter()
                .filter(|name| lowercase_pattern_binding(name)),
        );
    }
    bound
}

fn enclosing_function_parameters(lines: &[&str], target_index: usize) -> BTreeSet<String> {
    let mut parameters = BTreeSet::new();
    if target_index >= lines.len() {
        return parameters;
    }
    let mut index = 0usize;
    while index < target_index {
        let line = lines[index];
        let trimmed = line.trim_start();
        if !(trimmed.starts_with("let ") || trimmed.starts_with("and ")) {
            index += 1;
            continue;
        }
        let function_indent = leading_spaces(line);
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
        if header.role == BindingRole::Function && !header.parameters.is_empty() {
            let encloses_target = lines[header_end + 1..target_index].iter().all(|candidate| {
                let candidate_trimmed = candidate.trim_start();
                candidate_trimmed.is_empty()
                    || candidate_trimmed.starts_with("//")
                    || leading_spaces(candidate) > function_indent
            });
            if encloses_target {
                parameters.extend(header.parameters);
            }
        }
        index += 1;
    }
    parameters
}

fn enclosing_value_bindings(lines: &[&str], target_index: usize) -> BTreeSet<String> {
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
            BindingRole::Value | BindingRole::DestructuredValue
        ) {
            index += 1;
            continue;
        }
        let scope_broken = lines[header_end + 1..target_index].iter().any(|candidate| {
            let candidate_trimmed = candidate.trim_start();
            !candidate_trimmed.is_empty()
                && !candidate_trimmed.starts_with("//")
                && leading_spaces(candidate) < binding_indent
        });
        if scope_broken {
            index += 1;
            continue;
        }
        let completed_before_target = target_indent <= binding_indent
            || lines[header_end + 1..target_index].iter().any(|candidate| {
                let candidate_trimmed = candidate.trim_start();
                !candidate_trimmed.is_empty()
                    && !candidate_trimmed.starts_with("//")
                    && leading_spaces(candidate) <= binding_indent
            });
        if completed_before_target {
            bound.extend(header.bound_names);
        }
        index += 1;
    }
    bound
}

fn capture_is_assigned(mask: &str, name: &str) -> bool {
    mask.lines().any(|line| {
        line.match_indices(name).any(|(start, _)| {
            let before = line[..start].chars().next_back();
            if before.is_some_and(identifier_continue_for_annotation) || before == Some('.') {
                return false;
            }
            let end = start + name.len();
            let after = line[end..].chars().next();
            if after.is_some_and(identifier_continue_for_annotation) {
                return false;
            }
            line[end..].trim_start().starts_with("<-")
        })
    })
}

fn mutable_binding_type(line: &str, name: &str) -> Option<String> {
    let trimmed = line.trim_start();
    let body = trimmed
        .strip_prefix("let mutable ")
        .or_else(|| trimmed.strip_prefix("and mutable "))?;
    let (header, rhs) = body.split_once('=')?;
    let rest = header.trim().strip_prefix(name)?.trim_start();
    if let Some(ty) = rest
        .strip_prefix(':')
        .map(str::trim)
        .filter(|ty| !ty.is_empty())
    {
        return Some(ty.to_owned());
    }
    if !rest.is_empty() {
        return None;
    }
    let rhs = rhs.trim();
    if rhs.parse::<i64>().is_ok() {
        Some("int".to_owned())
    } else if matches!(rhs, "true" | "false") {
        Some("bool".to_owned())
    } else {
        None
    }
}

fn sibling_map<'a>(
    groups: &'a [LocalGroup],
    owner: DeclarationId,
) -> BTreeMap<usize, &'a LocalGroup> {
    groups
        .iter()
        .filter(|group| group.owner == owner)
        .map(|group| (group.local_index, group))
        .collect()
}

fn owner_header_parameters(owner: &Declaration<Linked>) -> BTreeSet<String> {
    let mut parameters = binding_header(&owner.heading)
        .map(|header| header.parameters.into_iter().collect::<BTreeSet<_>>())
        .unwrap_or_default();
    for line in owner.text.lines().skip(1) {
        let trimmed = line.trim();
        if trimmed.contains('=') {
            break;
        }
        if let Some(body) = trimmed.strip_prefix('(') {
            if let Some((name_part, _)) = body.split_once(':') {
                if let Some(name) = identifiers(name_part)
                    .into_iter()
                    .find(|name| lowercase_pattern_binding(name))
                {
                    parameters.insert(name);
                }
            }
        } else if let Some(name) = identifiers(trimmed)
            .into_iter()
            .find(|name| lowercase_pattern_binding(name))
        {
            parameters.insert(name);
        }
    }
    parameters
}

fn local_group_binding_header(
    owner: &Declaration<Linked>,
    group: &LocalGroup,
) -> Option<spiral_split_binding_header::BindingHeader> {
    let start = group.start_line.checked_sub(owner.span.start)?;
    let end = group.end_line.checked_sub(owner.span.start)?;
    let lines = owner.text.lines().collect::<Vec<_>>();
    if start >= end || end > lines.len() {
        return None;
    }
    let mut header_text = String::new();
    for line in &lines[start..end] {
        if !header_text.is_empty() {
            header_text.push('\n');
        }
        header_text.push_str(line);
        if header_text.contains('=') {
            break;
        }
    }
    binding_header(&header_text)
}

fn active_pattern_case_providers(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    before_line: usize,
) -> BTreeMap<String, usize> {
    let mut providers = BTreeMap::new();
    for group in groups
        .iter()
        .filter(|group| group.owner == owner.id && group.start_line < before_line)
    {
        let Some(header) = local_group_binding_header(owner, group) else {
            continue;
        };
        if header.role != BindingRole::ActivePattern {
            continue;
        }
        for name in header.bound_names {
            providers.insert(name, group.local_index);
        }
    }
    providers
}

fn active_pattern_groups_in_text(
    text: &str,
    providers: &BTreeMap<String, usize>,
) -> BTreeMap<usize, String> {
    let mut required = BTreeMap::new();
    for name in identifiers(text) {
        if let Some(group) = providers.get(&name) {
            required.entry(*group).or_insert(name);
        }
    }
    required
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum MaterializationVisit {
    Visiting,
    Materialized,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
struct ActivePatternMaterialization {
    names: BTreeSet<String>,
    captures: BTreeSet<String>,
    local_indices: Vec<usize>,
}

fn safely_materializable_local(
    owner: &Declaration<Linked>,
    group: &LocalGroup,
    root_active_pattern: bool,
) -> bool {
    match &group.disposition {
        LiftDisposition::Liftable | LiftDisposition::Captures(_) => true,
        LiftDisposition::Unsupported(UnsupportedReason::ComplexBinder) if root_active_pattern => {
            local_group_binding_header(owner, group)
                .is_some_and(|header| header.role == BindingRole::ActivePattern)
        }
        LiftDisposition::Unsupported(_) => false,
    }
}

#[allow(clippy::too_many_arguments)]
fn materialize_active_pattern_local(
    owner: &Declaration<Linked>,
    siblings: &BTreeMap<usize, &LocalGroup>,
    local_index: usize,
    before_line: usize,
    root_active_pattern: bool,
    visits: &mut BTreeMap<usize, MaterializationVisit>,
    materialization: &mut ActivePatternMaterialization,
) -> Result<(), ()> {
    match visits.get(&local_index) {
        Some(MaterializationVisit::Materialized) => return Ok(()),
        Some(MaterializationVisit::Visiting) => return Err(()),
        None => {}
    }
    let group = siblings.get(&local_index).copied().ok_or(())?;
    if group.start_line >= before_line
        || !safely_materializable_local(owner, group, root_active_pattern)
    {
        return Err(());
    }
    visits.insert(local_index, MaterializationVisit::Visiting);
    for dependency in &group.local_dependencies {
        materialize_active_pattern_local(
            owner,
            siblings,
            *dependency,
            before_line,
            false,
            visits,
            materialization,
        )?;
    }
    materialization.names.extend(group.names.iter().cloned());
    materialization
        .captures
        .extend(group.captures.iter().cloned());
    materialization.local_indices.push(local_index);
    visits.insert(local_index, MaterializationVisit::Materialized);
    Ok(())
}

fn active_pattern_materialization(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    before_line: usize,
    text: &str,
    branch: usize,
) -> Result<ActivePatternMaterialization, BranchBlocker> {
    let providers = active_pattern_case_providers(owner, groups, before_line);
    if providers.is_empty() {
        return Ok(ActivePatternMaterialization::default());
    }
    let masked = code_only_mask(text).map_err(|error| BranchBlocker::Lexical(error.to_string()))?;
    let required = active_pattern_groups_in_text(&masked, &providers);
    if required.is_empty() {
        return Ok(ActivePatternMaterialization::default());
    }
    let siblings = sibling_map(groups, owner.id);
    let mut visits = BTreeMap::new();
    let mut materialization = ActivePatternMaterialization::default();
    for (local_index, case_name) in required {
        if materialize_active_pattern_local(
            owner,
            &siblings,
            local_index,
            before_line,
            true,
            &mut visits,
            &mut materialization,
        )
        .is_err()
        {
            return Err(BranchBlocker::ActivePatternDependency {
                branch,
                name: case_name,
            });
        }
    }
    for name in &materialization.names {
        materialization.captures.remove(name);
    }
    Ok(materialization)
}

fn render_materialized_local(
    owner: &Declaration<Linked>,
    group: &LocalGroup,
    target_indent: usize,
) -> Result<String, ()> {
    let owner_lines = owner.text.lines().collect::<Vec<_>>();
    let start = group.start_line.checked_sub(owner.span.start).ok_or(())?;
    let end = group.end_line.checked_sub(owner.span.start).ok_or(())?;
    if start >= end || end > owner_lines.len() {
        return Err(());
    }
    let block = &owner_lines[start..end];
    let block_indent = block
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or(target_indent, |line| leading_spaces(line));
    let mut output = String::new();
    for line in block {
        if line.trim().is_empty() {
            output.push('\n');
            continue;
        }
        let indent = leading_spaces(line);
        if indent < block_indent {
            return Err(());
        }
        let relative = indent - block_indent;
        let content = line.get(indent..).unwrap_or(line);
        let _ = writeln!(
            output,
            "{}{}{}",
            " ".repeat(target_indent),
            " ".repeat(relative),
            content
        );
    }
    Ok(output.trim_end().to_owned())
}

fn render_active_pattern_prelude(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    before_line: usize,
    raw_lines: &[&str],
    owner_indent: usize,
    branch: usize,
) -> Result<String, BranchBlocker> {
    let materialization =
        active_pattern_materialization(owner, groups, before_line, &raw_lines.join("\n"), branch)?;
    if materialization.local_indices.is_empty() {
        return Ok(String::new());
    }
    let siblings = sibling_map(groups, owner.id);
    let mut blocks = Vec::with_capacity(materialization.local_indices.len());
    for local_index in materialization.local_indices {
        let group = siblings.get(&local_index).copied().ok_or_else(|| {
            BranchBlocker::ActivePatternDependency {
                branch,
                name: format!("local-{local_index}"),
            }
        })?;
        blocks.push(
            render_materialized_local(owner, group, owner_indent + 4).map_err(|()| {
                BranchBlocker::ActivePatternDependency {
                    branch,
                    name: group
                        .names
                        .iter()
                        .next()
                        .cloned()
                        .unwrap_or_else(|| format!("local-{local_index}")),
                }
            })?,
        );
    }
    Ok(blocks.join("\n\n"))
}

fn analyze_match_branches_in_scope(
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    groups: &[LocalGroup],
    parent_scope: MatchParent,
    max_case_lines: Option<usize>,
) -> Result<MatchBranchPlan<Certified>, BranchBlocker> {
    if owner.id != parent.owner {
        return Err(BranchBlocker::OwnerMismatch);
    }
    let relative_start = parent
        .start_line
        .checked_sub(owner.span.start)
        .ok_or(BranchBlocker::InvalidParentSpan)?;
    let relative_end = parent
        .end_line
        .checked_sub(owner.span.start)
        .ok_or(BranchBlocker::InvalidParentSpan)?;
    let lines = owner.text.lines().collect::<Vec<_>>();
    if relative_start >= relative_end || relative_end > lines.len() {
        return Err(BranchBlocker::InvalidParentSpan);
    }
    let parent_lines = &lines[relative_start..relative_end];
    let parent_text = parent_lines.join("\n");
    let mask =
        code_only_mask(&parent_text).map_err(|error| BranchBlocker::Lexical(error.to_string()))?;
    let masked_lines = mask.lines().collect::<Vec<_>>();
    let parent_indent = leading_spaces(parent_lines[0]);

    let mut candidates = Vec::<(usize, String, Vec<(usize, usize)>)>::new();
    for (index, line) in masked_lines.iter().enumerate() {
        if leading_spaces(line) <= parent_indent {
            continue;
        }
        let candidate = match max_case_lines {
            Some(_) => match match_subject_expression(line) {
                Some(subject) => Some((subject, direct_cases(&masked_lines, index))),
                None => anonymous_function_case_indent(line).map(|case_indent| {
                    (
                        String::new(),
                        direct_cases_at_indent(&masked_lines, index, case_indent),
                    )
                }),
            },
            None => simple_match_subject(line)
                .map(|subject| (subject, direct_cases(&masked_lines, index))),
        };
        let Some((subject, cases)) = candidate else {
            continue;
        };
        if cases.len() < 2 || direct_match_already_extracted(&masked_lines, &cases) {
            continue;
        }
        let total_span = cases.last().map_or(0, |(_, end)| end.saturating_sub(index));
        let score = match max_case_lines {
            Some(limit) => cases
                .iter()
                .map(|(start, end)| end.saturating_sub(*start))
                .filter(|lines| *lines <= limit)
                .sum(),
            None => total_span,
        };
        if score > 0 {
            candidates.push((score, subject, cases));
        }
    }
    let (_, subject, case_spans) = candidates
        .into_iter()
        .max_by_key(|(score, _, spans)| (*score, spans.len()))
        .ok_or(BranchBlocker::NoDirectMatch)?;
    let match_local_index = case_spans
        .first()
        .map(|(start, _)| start.saturating_sub(1))
        .ok_or(BranchBlocker::NoDirectCases)?;

    let match_absolute = parent.start_line + match_local_index;
    let dependency_before_line = match parent_scope {
        MatchParent::OwnerBody => match_absolute,
        MatchParent::Local(_) => parent.start_line,
    };
    let sibling = sibling_map(groups, owner.id);
    let active_pattern_providers =
        active_pattern_case_providers(owner, groups, dependency_before_line);
    let mut available = parent.parameters.clone();
    available.extend(owner_header_parameters(owner));
    available.extend(parent.captures.iter().cloned());
    for dependency in &parent.local_dependencies {
        if let Some(group) = sibling.get(dependency) {
            available.extend(group.names.iter().cloned());
        }
    }
    available.extend(parent.names.iter().cloned());
    let owner_match_index = relative_start + match_local_index;
    available.extend(enclosing_case_bindings(&lines, owner_match_index));
    available.extend(enclosing_loop_bindings(&lines, owner_match_index));
    available.extend(enclosing_function_parameters(&lines, owner_match_index));
    available.extend(enclosing_value_bindings(&lines, owner_match_index));

    let mut mutable = BTreeSet::new();
    for group in groups.iter().filter(|group| group.owner == owner.id) {
        if matches!(
            group.disposition,
            LiftDisposition::Unsupported(UnsupportedReason::MutableBinding)
        ) {
            mutable.extend(group.names.iter().cloned());
        }
    }
    let mut mutable_types = BTreeMap::<String, String>::new();
    for line in &lines[..relative_start + match_local_index] {
        if let Some(header) = binding_header(line) {
            if header.mutable {
                for name in header.bound_names {
                    if let Some(ty) = mutable_binding_type(line, &name) {
                        mutable_types.insert(name, ty);
                    }
                }
            }
        }
    }
    let mut inner_active_pattern_cases = BTreeSet::new();
    for line in &parent_lines[..match_local_index] {
        if let Some(header) = binding_header(line) {
            if header.role == BindingRole::ActivePattern {
                inner_active_pattern_cases.extend(header.bound_names.iter().cloned());
            }
            available.extend(header.bound_names.iter().cloned());
            if header.mutable {
                mutable.extend(header.bound_names);
            }
        }
    }

    let mut branches = Vec::with_capacity(case_spans.len());
    for (ordinal, (start, end)) in case_spans.into_iter().enumerate() {
        let absolute_start = parent.start_line + start;
        let absolute_end = parent.start_line + end;
        let raw_lines = &parent_lines[start..end];
        let masked_branch = masked_lines[start..end].join("\n");
        let header_result = parse_case_header_span(&masked_lines[start..end], ordinal);
        let (pattern, guard, same_line_tail, header_lines) = match header_result {
            Ok(value) => value,
            Err(blocker) => {
                branches.push(MatchBranch {
                    ordinal,
                    start_line: absolute_start,
                    end_line: absolute_end,
                    line_count: end.saturating_sub(start),
                    pattern: raw_lines[0].trim().to_owned(),
                    guard: None,
                    captures: BTreeSet::new(),
                    mutable_captures: BTreeMap::new(),
                    mirror_guard: false,
                    disposition: BranchDisposition::Blocked(blocker),
                });
                continue;
            }
        };
        if guard.is_some() && raw_lines[0] != masked_lines[start] {
            branches.push(MatchBranch {
                ordinal,
                start_line: absolute_start,
                end_line: absolute_end,
                line_count: end.saturating_sub(start),
                pattern,
                guard,
                captures: BTreeSet::new(),
                mutable_captures: BTreeMap::new(),
                mirror_guard: false,
                disposition: BranchDisposition::Blocked(BranchBlocker::GuardedCase(ordinal)),
            });
            continue;
        }
        let pattern_names = identifiers(&pattern).into_iter().collect::<BTreeSet<_>>();
        if pattern_names.contains(&subject) {
            branches.push(MatchBranch {
                ordinal,
                start_line: absolute_start,
                end_line: absolute_end,
                line_count: end.saturating_sub(start),
                pattern,
                guard,
                captures: BTreeSet::new(),
                mutable_captures: BTreeMap::new(),
                mirror_guard: false,
                disposition: BranchDisposition::Blocked(BranchBlocker::SubjectShadowed(ordinal)),
            });
            continue;
        }
        let local_bound = local_bound_names(raw_lines);
        let nested_bound = nested_bound_names(&masked_lines[start..end]);
        let mut body_mask = same_line_tail;
        for line in &masked_lines[start + header_lines..end] {
            if !body_mask.is_empty() {
                body_mask.push('\n');
            }
            body_mask.push_str(line);
        }
        let referenced = identifiers(&body_mask)
            .into_iter()
            .filter(|name| unqualified_identifier_occurs(&body_mask, name))
            .collect::<BTreeSet<_>>();
        let branch_identifiers = identifiers(&masked_branch)
            .into_iter()
            .collect::<BTreeSet<_>>();
        let mut active_pattern_blocker = branch_identifiers
            .intersection(&inner_active_pattern_cases)
            .find(|name| !active_pattern_providers.contains_key(*name))
            .cloned();
        let pattern_materialization = if active_pattern_blocker.is_none() {
            match active_pattern_materialization(
                owner,
                groups,
                dependency_before_line,
                &masked_branch,
                ordinal,
            ) {
                Ok(materialization) => Some(materialization),
                Err(BranchBlocker::ActivePatternDependency { name, .. }) => {
                    active_pattern_blocker = Some(name);
                    None
                }
                Err(blocker) => return Err(blocker),
            }
        } else {
            None
        };
        let mut captures = referenced
            .intersection(&available)
            .filter(|name| **name != subject)
            .filter(|name| name.as_str() != "_" && !keyword(name))
            .filter(|name| !pattern_names.contains(*name))
            .filter(|name| {
                !local_bound.contains(*name)
                    || non_recursive_shadow_uses_outer(raw_lines, name.as_str())
                    || outer_reference_precedes_first_binding(raw_lines, name.as_str())
            })
            .filter(|name| {
                !nested_bound.contains(*name)
                    || outer_reference_precedes_first_binding(raw_lines, name.as_str())
            })
            .cloned()
            .collect::<BTreeSet<_>>();
        if let Some(materialization) = &pattern_materialization {
            captures.extend(materialization.captures.iter().cloned());
            for name in &materialization.names {
                captures.remove(name);
            }
        }
        for case_name in active_pattern_providers.keys() {
            captures.remove(case_name);
        }
        let guard_local_captures = guard
            .as_ref()
            .map(|guard| {
                identifiers(guard)
                    .into_iter()
                    .filter(|name| available.contains(name))
                    .filter(|name| !pattern_names.contains(name))
                    .filter(|name| !active_pattern_providers.contains_key(name))
                    .filter(|name| !inner_active_pattern_cases.contains(name))
                    .collect::<BTreeSet<_>>()
            })
            .unwrap_or_default();
        let mirror_guard = guard.is_some() && guard_local_captures.is_empty();
        let mut mutable_captures = BTreeMap::<String, String>::new();
        let mut unsupported_mutable = None;
        for name in &captures {
            if mutable.contains(name) || capture_is_assigned(&masked_branch, name) {
                if let Some(ty) = mutable_types.get(name) {
                    mutable_captures.insert(name.clone(), ty.clone());
                } else {
                    unsupported_mutable = Some(name.clone());
                    break;
                }
            }
        }
        let disposition = if let Some(name) = active_pattern_blocker {
            BranchDisposition::Blocked(BranchBlocker::ActivePatternDependency {
                branch: ordinal,
                name,
            })
        } else if let Some(name) = unsupported_mutable {
            BranchDisposition::Blocked(BranchBlocker::MutableCapture {
                branch: ordinal,
                name,
            })
        } else {
            BranchDisposition::Extractable
        };
        branches.push(MatchBranch {
            ordinal,
            start_line: absolute_start,
            end_line: absolute_end,
            line_count: end.saturating_sub(start),
            pattern,
            guard,
            captures,
            mutable_captures,
            mirror_guard,
            disposition,
        });
    }

    Ok(MatchBranchPlan {
        owner: owner.id,
        parent: parent_scope,
        match_line: match_absolute,
        subject,
        branches,
        stage: PhantomData,
    })
}

fn owner_body_parent(owner: &Declaration<Linked>) -> Result<LocalGroup, BranchBlocker> {
    let head = if binding_header(&owner.heading).is_some() {
        owner.heading.as_str()
    } else {
        owner
            .text
            .lines()
            .find(|line| binding_header(line).is_some())
            .ok_or(BranchBlocker::InvalidOwnerHeader)?
    };
    let header = binding_header(head).ok_or(BranchBlocker::InvalidOwnerHeader)?;
    if head.trim_start().starts_with("and ") {
        return Err(BranchBlocker::RecursiveOwnerHead);
    }
    Ok(LocalGroup {
        owner: owner.id,
        owner_heading: "owner-body".to_owned(),
        local_index: usize::MAX,
        start_line: owner.span.start,
        end_line: owner.span.end,
        line_count: owner.span.end.saturating_sub(owner.span.start),
        names: header.bound_names.into_iter().collect(),
        parameters: header.parameters.into_iter().collect(),
        references: BTreeSet::new(),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation),
    })
}

pub fn analyze_match_branches(
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    groups: &[LocalGroup],
) -> Result<MatchBranchPlan<Certified>, BranchBlocker> {
    analyze_match_branches_in_scope(
        owner,
        parent,
        groups,
        MatchParent::Local(parent.local_index),
        None,
    )
}

pub fn analyze_owner_match_branches(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
) -> Result<MatchBranchPlan<Certified>, BranchBlocker> {
    let parent = owner_body_parent(owner)?;
    analyze_match_branches_in_scope(owner, &parent, groups, MatchParent::OwnerBody, None)
}

pub fn analyze_owner_bounded_match_branches(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    max_case_lines: usize,
) -> Result<MatchBranchPlan<Certified>, BranchBlocker> {
    let parent = owner_body_parent(owner)?;
    analyze_match_branches_in_scope(
        owner,
        &parent,
        groups,
        MatchParent::OwnerBody,
        Some(max_case_lines),
    )
}

fn indent_line(indent: usize, line: &str) -> String {
    if line.trim().is_empty() {
        String::new()
    } else {
        format!("{}{}", " ".repeat(indent), line)
    }
}

fn helper_name(owner: DeclarationId, parent: MatchParent, ordinal: usize) -> String {
    match parent {
        MatchParent::OwnerBody => format!("__spiral_match_{}_body_{}", owner.0, ordinal),
        MatchParent::Local(index) => format!("__spiral_match_{}_{}_{}", owner.0, index, ordinal),
    }
}

fn identifier_continue_for_annotation(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn explicit_value_binding_type(line: &str, name: &str) -> Option<String> {
    let header = binding_header(line)?;
    if header.role != BindingRole::Value || header.name != name {
        return None;
    }
    let trimmed = line.trim_start();
    let name_at = trimmed.find(name)?;
    let rest = trimmed.get(name_at + name.len()..)?.trim_start();
    let annotated = rest.strip_prefix(':')?.trim_start();
    let (ty, _) = annotated.split_once('=')?;
    let ty = ty.trim();
    (!ty.is_empty()).then(|| ty.to_owned())
}

fn constructor_value_binding_type(expression: &str) -> Option<String> {
    let expression = expression.trim();
    let open = expression.find('(')?;
    let candidate = expression[..open].trim();
    if candidate.is_empty()
        || candidate.contains('_')
        || !candidate.contains('<')
        || !candidate.chars().all(|character| {
            character.is_alphanumeric()
                || matches!(
                    character,
                    '_' | '\'' | '.' | '<' | '>' | ',' | '[' | ']' | '*' | ' '
                )
        })
    {
        return None;
    }
    Some(candidate.to_owned())
}

fn owner_parameter_annotations(
    owner_lines: &[&str],
    captures: &BTreeSet<String>,
) -> BTreeMap<String, String> {
    let mut annotations = BTreeMap::new();
    let Some(header) = owner_lines.iter().find(|line| !line.trim().is_empty()) else {
        return annotations;
    };
    let header = header.split_once('=').map_or(*header, |(head, _)| head);
    let chars = header.chars().collect::<Vec<_>>();
    let mut cursor = 0usize;
    while cursor < chars.len() {
        if chars[cursor] != '(' {
            cursor += 1;
            continue;
        }
        let start = cursor + 1;
        cursor += 1;
        let mut depth = 1usize;
        while cursor < chars.len() && depth > 0 {
            match chars[cursor] {
                '(' => depth += 1,
                ')' => depth -= 1,
                _ => {}
            }
            cursor += 1;
        }
        if depth != 0 {
            break;
        }
        let content = chars[start..cursor - 1].iter().collect::<String>();
        let Some((name, ty)) = content.split_once(':') else {
            continue;
        };
        let name = name.trim();
        let ty = ty.trim();
        if name.is_empty()
            || ty.is_empty()
            || !captures.contains(name)
            || !name.chars().all(identifier_continue_for_annotation)
        {
            continue;
        }
        annotations.insert(name.to_owned(), ty.to_owned());
    }
    annotations
}

fn owner_capture_annotations(
    owner_lines: &[&str],
    owner_indent: usize,
    branch_start: usize,
    captures: &BTreeSet<String>,
) -> BTreeMap<String, String> {
    let local_indent = owner_indent + 4;
    let mut annotations = owner_parameter_annotations(owner_lines, captures);
    for (index, line) in owner_lines.iter().take(branch_start).enumerate() {
        if leading_spaces(line) != local_indent {
            continue;
        }
        let Some(header) = binding_header(line) else {
            continue;
        };
        if header.role != BindingRole::Value || !captures.contains(&header.name) {
            continue;
        }
        if let Some(ty) = explicit_value_binding_type(line, &header.name) {
            annotations.insert(header.name.clone(), ty);
            continue;
        }
        let Some((_, rhs)) = line.split_once('=') else {
            continue;
        };
        let rhs = if rhs.trim().is_empty() {
            owner_lines
                .iter()
                .take(branch_start)
                .skip(index + 1)
                .find(|candidate| !candidate.trim().is_empty())
                .filter(|candidate| leading_spaces(candidate) > local_indent)
                .map_or("", |candidate| candidate.trim())
        } else {
            rhs.trim()
        };
        if let Some(ty) = constructor_value_binding_type(rhs) {
            annotations.insert(header.name.clone(), ty);
        }
    }
    annotations
}

fn capture_annotations_from_lines(
    lines: &[&str],
    captures: &BTreeSet<String>,
) -> BTreeMap<String, String> {
    let mut candidates = BTreeMap::<String, BTreeSet<String>>::new();
    for (index, line) in lines.iter().enumerate() {
        let Some(header) = binding_header(line) else {
            continue;
        };
        if header.role != BindingRole::Value || !captures.contains(&header.name) {
            continue;
        }
        let explicit = explicit_value_binding_type(line, &header.name);
        let inferred = if explicit.is_none() {
            line.split_once('=').and_then(|(_, rhs)| {
                let binding_indent = leading_spaces(line);
                let rhs = if rhs.trim().is_empty() {
                    lines
                        .iter()
                        .skip(index + 1)
                        .find(|candidate| !candidate.trim().is_empty())
                        .filter(|candidate| leading_spaces(candidate) > binding_indent)
                        .map_or("", |candidate| candidate.trim())
                } else {
                    rhs.trim()
                };
                constructor_value_binding_type(rhs)
            })
        } else {
            None
        };
        if let Some(ty) = explicit.or(inferred) {
            candidates.entry(header.name).or_default().insert(ty);
        }
    }
    candidates
        .into_iter()
        .filter_map(|(name, types)| {
            if types.len() != 1 {
                return None;
            }
            types.into_iter().next().map(|ty| (name, ty))
        })
        .collect()
}

fn callsite_capture_annotations(
    source_lines: &[&str],
    owner: &Declaration<Linked>,
    captures: &BTreeSet<String>,
) -> BTreeMap<String, String> {
    let Some(head) = owner.text.lines().find(|line| !line.trim().is_empty()) else {
        return BTreeMap::new();
    };
    let Some(header) = binding_header(head) else {
        return BTreeMap::new();
    };
    let owner_end = owner.span.end.saturating_sub(1).min(source_lines.len());
    let Some(call_index) =
        source_lines
            .iter()
            .enumerate()
            .skip(owner_end)
            .find_map(|(index, line)| {
                if line.trim_start().starts_with("//") || !identifiers(line).contains(&header.name)
                {
                    return None;
                }
                let redeclares_owner =
                    binding_header(line).is_some_and(|binding| binding.name == header.name);
                (!redeclares_owner).then_some(index)
            })
    else {
        return BTreeMap::new();
    };
    capture_annotations_from_lines(&source_lines[owner_end..call_index], captures)
}

fn annotate_pattern(
    pattern: &str,
    annotation: Option<&MatchPatternAnnotation>,
    branch: usize,
) -> Result<String, BranchBlocker> {
    let Some(annotation) = annotation else {
        return Ok(pattern.to_owned());
    };
    let mut matches = pattern
        .match_indices(&annotation.binding)
        .filter(|(index, _)| {
            let before = pattern[..*index].chars().next_back();
            let after = pattern[*index + annotation.binding.len()..].chars().next();
            before.is_none_or(|character| !identifier_continue_for_annotation(character))
                && after.is_none_or(|character| !identifier_continue_for_annotation(character))
        });
    let Some((index, _)) = matches.next() else {
        return Err(BranchBlocker::PatternAnnotationMismatch(branch));
    };
    if matches.next().is_some() {
        return Err(BranchBlocker::PatternAnnotationMismatch(branch));
    }
    let mut output = String::with_capacity(pattern.len() + annotation.owner_type.len() + 4);
    output.push_str(&pattern[..index]);
    output.push('(');
    output.push_str(&annotation.binding);
    output.push_str(": ");
    output.push_str(&annotation.owner_type);
    output.push(')');
    output.push_str(&pattern[index + annotation.binding.len()..]);
    Ok(output)
}

fn branch_helper(
    owner_indent: usize,
    subject: &str,
    branch: &MatchBranch,
    annotation: Option<&MatchPatternAnnotation>,
    capture_annotations: &BTreeMap<String, String>,
    raw_lines: &[&str],
    active_pattern_prelude: &str,
    parent: MatchParent,
    owner: DeclarationId,
) -> Result<String, BranchBlocker> {
    let helper = helper_name(owner, parent, branch.ordinal);
    let captures = branch
        .captures
        .iter()
        .map(|name| {
            if let Some(ty) = branch.mutable_captures.get(name) {
                format!("({name}: byref<{ty}>)")
            } else if let Some(ty) = capture_annotations.get(name) {
                format!("({name}: {ty})")
            } else if let Some(annotation) =
                annotation.filter(|annotation| annotation.binding == *name)
            {
                format!("({name}: {})", annotation.owner_type)
            } else {
                name.clone()
            }
        })
        .collect::<Vec<_>>();
    let mut output = String::new();
    let params = if captures.is_empty() {
        String::new()
    } else {
        format!("{} ", captures.join(" "))
    };
    let _ = writeln!(
        output,
        "{}let private {} {}{} =",
        " ".repeat(owner_indent),
        helper,
        params,
        subject
    );
    if !active_pattern_prelude.is_empty() {
        output.push_str(active_pattern_prelude);
        output.push('\n');
    }
    let _ = writeln!(
        output,
        "{}match {} with",
        " ".repeat(owner_indent + 4),
        subject
    );
    let pattern_annotation =
        annotation.filter(|annotation| !branch.captures.contains(&annotation.binding));
    let helper_pattern = annotate_pattern(&branch.pattern, pattern_annotation, branch.ordinal)?;
    let helper_case = if branch.mirror_guard {
        branch.guard.as_ref().map_or_else(
            || helper_pattern.clone(),
            |guard| format!("{} when {}", helper_pattern, guard),
        )
    } else {
        helper_pattern
    };
    let _ = writeln!(
        output,
        "{}| {} ->",
        " ".repeat(owner_indent + 4),
        helper_case
    );
    let (_, _, same_line_tail, header_lines) = parse_case_header_span(raw_lines, branch.ordinal)?;
    if !same_line_tail.is_empty() {
        let _ = writeln!(output, "{}{}", " ".repeat(owner_indent + 8), same_line_tail);
    }
    let case_indent = leading_spaces(raw_lines[0]);
    let body_indent = case_indent + 4;
    for line in raw_lines.iter().skip(header_lines) {
        if line.trim().is_empty() {
            output.push('\n');
            continue;
        }
        let indent = leading_spaces(line);
        let relative = indent.saturating_sub(body_indent);
        let content = line.get(indent..).unwrap_or(line);
        let _ = writeln!(
            output,
            "{}{}{}",
            " ".repeat(owner_indent + 8),
            " ".repeat(relative),
            content
        );
    }
    let _ = writeln!(
        output,
        "{}| _ -> failwith \"Compiler error: generated match branch contract violated.\"",
        " ".repeat(owner_indent + 4)
    );
    Ok(output.trim_end().to_owned())
}

fn rewrite_match_branches_in_scope(
    source: &str,
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    groups: &[LocalGroup],
    parent_scope: MatchParent,
    max_case_lines: Option<usize>,
    selected: &[usize],
    annotations: &BTreeMap<usize, MatchPatternAnnotation>,
) -> Result<MatchBranchArtifact<Applied>, BranchBlocker> {
    if selected.is_empty() {
        return Err(BranchBlocker::EmptySelection);
    }
    let plan =
        analyze_match_branches_in_scope(owner, parent, groups, parent_scope, max_case_lines)?;
    let selected_set = selected.iter().copied().collect::<BTreeSet<_>>();
    let selected_branches = selected
        .iter()
        .map(|ordinal| {
            plan.branches
                .iter()
                .find(|branch| branch.ordinal == *ordinal)
                .ok_or(BranchBlocker::BranchNotFound(*ordinal))
        })
        .collect::<Result<Vec<_>, _>>()?;
    for branch in &selected_branches {
        if let BranchDisposition::Blocked(blocker) = &branch.disposition {
            return Err(blocker.clone());
        }
    }
    let source_lines = source.lines().collect::<Vec<_>>();
    let owner_start = owner.span.start.saturating_sub(1);
    let owner_end = owner.span.end.saturating_sub(1);
    if owner_start >= owner_end || owner_end > source_lines.len() {
        return Err(BranchBlocker::InvalidParentSpan);
    }
    let owner_lines = owner.text.lines().collect::<Vec<_>>();
    let owner_indent = owner_lines
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or(0, |line| leading_spaces(line));
    let owner_head = owner_lines
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or("", |line| line.trim_start());
    if owner_head.starts_with("and ") {
        return Err(BranchBlocker::RecursiveOwnerHead);
    }

    let simple_subject = simple_subject_name(&plan.subject);
    let mut helpers = Vec::new();
    let mut replacements = Vec::<(usize, usize, String)>::new();
    for branch in &selected_branches {
        let subject_argument = simple_subject.map_or_else(
            || {
                format!(
                    "__spiral_match_subject_{}_{}_{}",
                    owner.id.0, plan.match_line, branch.ordinal
                )
            },
            str::to_owned,
        );
        if simple_subject.is_none() && owner.text.contains(&subject_argument) {
            return Err(BranchBlocker::Lexical(format!(
                "match-subject-alias-collision:{}",
                subject_argument
            )));
        }
        let start = branch
            .start_line
            .checked_sub(owner.span.start)
            .ok_or(BranchBlocker::InvalidParentSpan)?;
        let end = branch
            .end_line
            .checked_sub(owner.span.start)
            .ok_or(BranchBlocker::InvalidParentSpan)?;
        if start >= end || end > owner_lines.len() {
            return Err(BranchBlocker::InvalidParentSpan);
        }
        let active_pattern_prelude = render_active_pattern_prelude(
            owner,
            groups,
            parent.start_line,
            &owner_lines[start..end],
            owner_indent,
            branch.ordinal,
        )?;
        let mut capture_annotations =
            owner_capture_annotations(&owner_lines, owner_indent, start, &branch.captures);
        for (name, ty) in callsite_capture_annotations(&source_lines, owner, &branch.captures) {
            capture_annotations.entry(name).or_insert(ty);
        }
        helpers.push(branch_helper(
            owner_indent,
            &subject_argument,
            branch,
            annotations.get(&branch.ordinal),
            &capture_annotations,
            &owner_lines[start..end],
            &active_pattern_prelude,
            parent_scope,
            owner.id,
        )?);
        let helper = helper_name(owner.id, parent_scope, branch.ordinal);
        let args = branch
            .captures
            .iter()
            .map(|name| {
                if branch.mutable_captures.contains_key(name) {
                    format!("&{name}")
                } else {
                    name.clone()
                }
            })
            .collect::<Vec<_>>()
            .join(" ");
        let call = if args.is_empty() {
            format!("{} {}", helper, subject_argument)
        } else {
            format!("{} {} {}", helper, args, subject_argument)
        };
        let caller_pattern = simple_subject.map_or_else(
            || format!("(({}) as {})", branch.pattern, subject_argument),
            |_| branch.pattern.clone(),
        );
        let branch_head = branch.guard.as_ref().map_or_else(
            || format!("| {} -> {}", caller_pattern, call),
            |guard| format!("| {} when {} -> {}", caller_pattern, guard, call),
        );
        let replacement = indent_line(leading_spaces(owner_lines[start]), &branch_head);
        replacements.push((start, end, replacement));
    }
    replacements.sort_by_key(|(start, _, _)| *start);
    let mut rewritten_owner = Vec::<String>::new();
    let mut cursor = 0usize;
    for (start, end, replacement) in &replacements {
        rewritten_owner.extend(
            owner_lines[cursor..*start]
                .iter()
                .map(|line| (*line).to_owned()),
        );
        rewritten_owner.push(replacement.clone());
        cursor = *end;
    }
    rewritten_owner.extend(owner_lines[cursor..].iter().map(|line| (*line).to_owned()));
    let owner_text = rewritten_owner.join("\n");
    let hoisted_text = helpers.join("\n\n");

    let mut output = Vec::<String>::new();
    output.extend(
        source_lines[..owner_start]
            .iter()
            .map(|line| (*line).to_owned()),
    );
    output.extend(hoisted_text.lines().map(str::to_owned));
    output.push(String::new());
    output.extend(owner_text.lines().map(str::to_owned));
    output.extend(
        source_lines[owner_end..]
            .iter()
            .map(|line| (*line).to_owned()),
    );
    let mut final_source = output.join("\n");
    if source.ends_with('\n') {
        final_source.push('\n');
    }

    let extracted_lines = selected_branches
        .iter()
        .map(|branch| branch.line_count)
        .sum();
    let max_branch_lines = selected_branches
        .iter()
        .map(|branch| branch.line_count)
        .max()
        .unwrap_or(0);
    let capture_count = selected_branches
        .iter()
        .map(|branch| branch.captures.len())
        .sum();
    Ok(MatchBranchArtifact {
        owner: owner.id,
        parent: parent_scope,
        original_fingerprint: fnv1a64(owner.text.as_bytes()),
        selected: selected_set.into_iter().collect(),
        extracted_lines,
        max_branch_lines,
        helper_count: selected_branches.len(),
        capture_count,
        owner_text,
        hoisted_text,
        final_source,
        stage: PhantomData,
    })
}

pub fn rewrite_match_branches(
    source: &str,
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    groups: &[LocalGroup],
    selected: &[usize],
) -> Result<MatchBranchArtifact<Applied>, BranchBlocker> {
    rewrite_match_branches_in_scope(
        source,
        owner,
        parent,
        groups,
        MatchParent::Local(parent.local_index),
        None,
        selected,
        &BTreeMap::new(),
    )
}

pub fn rewrite_match_branches_with_annotations(
    source: &str,
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    groups: &[LocalGroup],
    selected: &[usize],
    annotations: &BTreeMap<usize, MatchPatternAnnotation>,
) -> Result<MatchBranchArtifact<Applied>, BranchBlocker> {
    rewrite_match_branches_in_scope(
        source,
        owner,
        parent,
        groups,
        MatchParent::Local(parent.local_index),
        None,
        selected,
        annotations,
    )
}

pub fn rewrite_owner_match_branches_with_annotations(
    source: &str,
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    selected: &[usize],
    annotations: &BTreeMap<usize, MatchPatternAnnotation>,
) -> Result<MatchBranchArtifact<Applied>, BranchBlocker> {
    let parent = owner_body_parent(owner)?;
    rewrite_match_branches_in_scope(
        source,
        owner,
        &parent,
        groups,
        MatchParent::OwnerBody,
        None,
        selected,
        annotations,
    )
}

pub fn rewrite_owner_bounded_match_branches_with_annotations(
    source: &str,
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    max_case_lines: usize,
    selected: &[usize],
    annotations: &BTreeMap<usize, MatchPatternAnnotation>,
) -> Result<MatchBranchArtifact<Applied>, BranchBlocker> {
    let parent = owner_body_parent(owner)?;
    rewrite_match_branches_in_scope(
        source,
        owner,
        &parent,
        groups,
        MatchParent::OwnerBody,
        Some(max_case_lines),
        selected,
        annotations,
    )
}

#[must_use]
pub fn render_match_branch_tsv(plan: &MatchBranchPlan<Certified>) -> String {
    let mut output = String::from(
        "owner\tparent_local\tmatch_line\tbranch\tstart\tend\tlines\tpattern\tcaptures\tdisposition\n",
    );
    for branch in &plan.branches {
        let _ = writeln!(
            output,
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
            plan.owner.0,
            plan.parent,
            plan.match_line,
            branch.ordinal,
            branch.start_line,
            branch.end_line,
            branch.line_count,
            branch.pattern.replace('\t', " "),
            branch
                .captures
                .iter()
                .cloned()
                .collect::<Vec<_>>()
                .join(","),
            branch.disposition,
        );
    }
    output
}

#[cfg(test)]
mod tests;
