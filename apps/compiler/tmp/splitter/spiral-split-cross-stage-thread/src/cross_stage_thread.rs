use spiral_split_capture_parameter::unique_definition_parameter;
use std::fmt::{Display, Formatter};
use std::marker::PhantomData;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ParameterSource {
    CapturedPartialApplication,
    SameCallLine,
    SameBlockBinding { binding: String },
    AncestorBlockBinding { binding: String },
    AncestorBinding { binding: String },
    ThreadedGeneratedAncestor { binding: String },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ScopeWitness {
    Nil,
    Cons {
        parameter: String,
        source: ParameterSource,
        tail: Box<ScopeWitness>,
    },
}

impl ScopeWitness {
    fn push(self, parameter: impl Into<String>, source: ParameterSource) -> Self {
        Self::Cons {
            parameter: parameter.into(),
            source,
            tail: Box::new(self),
        }
    }

    #[must_use]
    pub fn len(&self) -> usize {
        match self {
            Self::Nil => 0,
            Self::Cons { tail, .. } => 1 + tail.len(),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ThreadBlocker {
    MissingHelperHeader {
        helper: String,
    },
    AmbiguousHelperHeader {
        helper: String,
    },
    MissingCapturedParameter {
        helper: String,
        promotion: String,
    },
    AmbiguousHelperUse {
        helper: String,
        line: usize,
    },
    MissingCapturedArgument {
        helper: String,
        line: usize,
    },
    ParameterUnavailable {
        helper: String,
        parameter: String,
        line: usize,
    },
    BodyRewriteLineDrift {
        helper: String,
    },
    MissingHelperCall {
        helper: String,
    },
}

impl Display for ThreadBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::MissingHelperHeader { helper } => {
                write!(formatter, "missing-helper-header:{helper}")
            }
            Self::AmbiguousHelperHeader { helper } => {
                write!(formatter, "ambiguous-helper-header:{helper}")
            }
            Self::MissingCapturedParameter { helper, promotion } => {
                write!(
                    formatter,
                    "missing-captured-parameter:{helper}:promotion={promotion}"
                )
            }
            Self::AmbiguousHelperUse { helper, line } => {
                write!(formatter, "ambiguous-helper-use:{helper}:line={line}")
            }
            Self::MissingCapturedArgument { helper, line } => {
                write!(formatter, "missing-captured-argument:{helper}:line={line}")
            }
            Self::ParameterUnavailable {
                helper,
                parameter,
                line,
            } => write!(
                formatter,
                "parameter-unavailable:{helper}:parameter={parameter}:line={line}"
            ),
            Self::BodyRewriteLineDrift { helper } => {
                write!(formatter, "body-rewrite-line-drift:{helper}")
            }
            Self::MissingHelperCall { helper } => write!(formatter, "missing-helper-call:{helper}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ThreadReceipt {
    pub helper: String,
    pub promotion: String,
    pub inserted_parameters: Vec<String>,
    pub call_sites: usize,
    pub witnesses: ScopeWitness,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ThreadArtifact {
    pub text: String,
    pub receipt: ThreadReceipt,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Unchecked;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Proven;

#[derive(Clone, Debug, Eq, PartialEq)]
struct PlannedCall {
    line: usize,
    insert_at: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ThreadPlan<State> {
    helper: String,
    promotion: String,
    lifted: String,
    all_parameters: Vec<String>,
    missing: Vec<String>,
    lines: Vec<String>,
    trailing_newline: bool,
    header: usize,
    header_insert_at: usize,
    calls: Vec<PlannedCall>,
    witnesses: ScopeWitness,
    _state: PhantomData<State>,
}

fn identifier_start(byte: u8) -> bool {
    byte == b'_' || byte.is_ascii_alphabetic()
}

fn identifier_continue(byte: u8) -> bool {
    identifier_start(byte) || byte.is_ascii_digit() || byte == b'\''
}

fn identifier_ranges(text: &str, expected: &str) -> Vec<(usize, usize)> {
    let bytes = text.as_bytes();
    let mut ranges = Vec::new();
    let mut index = 0usize;
    while index < bytes.len() {
        if !identifier_start(bytes[index]) {
            index += 1;
            continue;
        }
        let start = index;
        index += 1;
        while bytes.get(index).copied().is_some_and(identifier_continue) {
            index += 1;
        }
        if text.get(start..index) == Some(expected) {
            ranges.push((start, index));
        }
    }
    ranges
}

fn leading_spaces(line: &str) -> usize {
    line.as_bytes()
        .iter()
        .take_while(|byte| **byte == b' ')
        .count()
}

fn binding_body(mut line: &str) -> Option<&str> {
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

fn binding_name_and_parameters(line: &str) -> Option<(String, Vec<String>)> {
    let body = binding_body(line)?;
    let name_end = body
        .as_bytes()
        .iter()
        .position(|byte| !identifier_continue(*byte))
        .unwrap_or(body.len());
    let name = body.get(..name_end)?.to_owned();
    if name.is_empty() {
        return None;
    }
    let before_equals = body
        .get(name_end..)?
        .split_once('=')
        .map_or(body.get(name_end..)?, |(left, _)| left);
    let bytes = before_equals.as_bytes();
    let mut parameters = Vec::new();
    let mut cursor = 0usize;
    while cursor < bytes.len() {
        if !identifier_start(bytes[cursor]) {
            cursor += 1;
            continue;
        }
        let start = cursor;
        cursor += 1;
        while bytes.get(cursor).copied().is_some_and(identifier_continue) {
            cursor += 1;
        }
        let candidate = &before_equals[start..cursor];
        if !matches!(candidate, "unit" | "struct") {
            parameters.push(candidate.to_owned());
        }
    }
    Some((name, parameters))
}

fn ancestor_parameter_binding(
    lines: &[String],
    line_index: usize,
    parameter: &str,
) -> Option<String> {
    let call_indent = leading_spaces(lines.get(line_index)?);
    let mut threshold = call_indent;
    for line in lines[..line_index].iter().rev() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let indent = leading_spaces(line);
        if indent >= threshold {
            continue;
        }
        let Some((binding, parameters)) = binding_name_and_parameters(line) else {
            continue;
        };
        if parameters.iter().any(|candidate| candidate == parameter) {
            return Some(binding);
        }
        threshold = indent;
    }
    None
}

fn immutable_value_binding_name(line: &str) -> Option<String> {
    let body = line.trim_start().strip_prefix("let ")?;
    if [
        "mutable ",
        "rec ",
        "inline ",
        "private ",
        "internal ",
        "public ",
    ]
    .iter()
    .any(|modifier| body.starts_with(modifier))
    {
        return None;
    }
    let name_end = body
        .as_bytes()
        .iter()
        .position(|byte| !identifier_continue(*byte))
        .unwrap_or(body.len());
    let name = body.get(..name_end)?;
    if name.is_empty() {
        return None;
    }
    let suffix = body.get(name_end..)?.trim_start();
    let before_equals = suffix.split_once('=')?.0.trim();
    if !before_equals.is_empty() && !before_equals.starts_with(':') {
        return None;
    }
    Some(name.to_owned())
}

fn same_block_immutable_binding(
    lines: &[String],
    line_index: usize,
    parameter: &str,
) -> Option<String> {
    let indent = leading_spaces(lines.get(line_index)?);
    for line in lines[..line_index].iter().rev() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let candidate_indent = leading_spaces(line);
        if candidate_indent < indent {
            break;
        }
        if candidate_indent > indent {
            continue;
        }
        if matches!(trimmed, "else" | "try" | "finally" | "with" | "function")
            || trimmed.starts_with('|')
        {
            return None;
        }
        if immutable_value_binding_name(line).as_deref() == Some(parameter) {
            return Some(parameter.to_owned());
        }
    }
    None
}

fn ancestor_block_immutable_binding(
    lines: &[String],
    line_index: usize,
    parameter: &str,
) -> Option<String> {
    let call_indent = leading_spaces(lines.get(line_index)?);
    let (ancestor_index, ancestor_indent) =
        lines[..line_index]
            .iter()
            .enumerate()
            .rev()
            .find_map(|(index, line)| {
                let trimmed = line.trim_start();
                if trimmed.is_empty() || trimmed.starts_with("//") {
                    return None;
                }
                let indent = leading_spaces(line);
                (indent < call_indent && binding_name_and_parameters(line).is_some())
                    .then_some((index, indent))
            })?;
    for line in lines[..ancestor_index].iter().rev() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let candidate_indent = leading_spaces(line);
        if candidate_indent < ancestor_indent {
            break;
        }
        if candidate_indent > ancestor_indent {
            continue;
        }
        if matches!(trimmed, "else" | "try" | "finally" | "with" | "function")
            || trimmed.starts_with('|')
        {
            return None;
        }
        if immutable_value_binding_name(line).as_deref() == Some(parameter) {
            return Some(parameter.to_owned());
        }
    }
    None
}

fn nearest_ancestor_binding(lines: &[String], line_index: usize) -> Option<String> {
    let call_indent = leading_spaces(lines.get(line_index)?);
    for (candidate_index, line) in lines[..line_index].iter().enumerate().rev() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        let candidate_indent = leading_spaces(line);
        if candidate_indent >= call_indent {
            continue;
        }
        let Some((binding, _)) = binding_name_and_parameters(line) else {
            continue;
        };
        let encloses_call = lines[candidate_index + 1..line_index]
            .iter()
            .filter(|between| {
                let trimmed = between.trim_start();
                !trimmed.is_empty() && !trimmed.starts_with("//")
            })
            .all(|between| leading_spaces(between) > candidate_indent);
        if encloses_call && generated_binding(&binding) {
            return Some(binding);
        }
    }
    None
}

fn generated_binding(binding: &str) -> bool {
    binding.starts_with("__spiral_lift_")
        || binding.starts_with("__spiral_scc_")
        || binding.starts_with("__spiral_match_")
}

pub fn annotate_lifted_capture_parameters(
    text: &str,
    lifted: &str,
    parameters: &[String],
) -> Result<String, ThreadBlocker> {
    let trailing_newline = text.ends_with('\n');
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    let headers = lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| {
            let (binding, _) = binding_name_and_parameters(line)?;
            (binding == lifted).then_some(index)
        })
        .collect::<Vec<_>>();
    let header = match headers.as_slice() {
        [] => return Ok(text.to_owned()),
        [header] => *header,
        _ => {
            return Err(ThreadBlocker::AmbiguousHelperHeader {
                helper: lifted.to_owned(),
            });
        }
    };
    for parameter in parameters {
        let Some(rendered) = unique_definition_parameter(text, parameter) else {
            continue;
        };
        let ranges = identifier_ranges(&lines[header], parameter);
        let [(start, end)] = ranges.as_slice() else {
            continue;
        };
        let suffix = &lines[header][*end..];
        if suffix.trim_start().starts_with(':') {
            continue;
        }
        lines[header].replace_range(*start..*end, &rendered);
    }
    let mut output = lines.join("\n");
    if trailing_newline {
        output.push('\n');
    }
    Ok(output)
}

fn insert_parameter_after_identifier(
    line: &mut String,
    identifier: &str,
    parameter: &str,
) -> Result<(), ThreadBlocker> {
    let ranges = identifier_ranges(line, identifier);
    let [(_, end)] = ranges.as_slice() else {
        return Err(ThreadBlocker::AmbiguousHelperUse {
            helper: identifier.to_owned(),
            line: 0,
        });
    };
    line.insert_str(*end, &format!(" {parameter}"));
    Ok(())
}

fn thread_generated_parameter(
    lines: &mut [String],
    helper: &str,
    parameter: &str,
    stack: &mut Vec<String>,
) -> Result<(), ThreadBlocker> {
    if stack.iter().any(|candidate| candidate == helper) {
        return Err(ThreadBlocker::ParameterUnavailable {
            helper: helper.to_owned(),
            parameter: parameter.to_owned(),
            line: 0,
        });
    }
    let headers = lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| {
            let (binding, parameters) = binding_name_and_parameters(line)?;
            (binding == helper).then_some((index, parameters))
        })
        .collect::<Vec<_>>();
    let [(header, parameters)] = headers.as_slice() else {
        return Err(if headers.is_empty() {
            ThreadBlocker::MissingHelperHeader {
                helper: helper.to_owned(),
            }
        } else {
            ThreadBlocker::AmbiguousHelperHeader {
                helper: helper.to_owned(),
            }
        });
    };
    if parameters.iter().any(|candidate| candidate == parameter) {
        return Ok(());
    }

    stack.push(helper.to_owned());
    insert_parameter_after_identifier(&mut lines[*header], helper, parameter)?;
    let call_lines = lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| {
            if index == *header || line.trim_start().starts_with("//") {
                return None;
            }
            (!identifier_ranges(line, helper).is_empty()).then_some(index)
        })
        .collect::<Vec<_>>();
    if call_lines.is_empty() {
        stack.pop();
        return Ok(());
    }

    for line_index in call_lines {
        let ranges = identifier_ranges(&lines[line_index], helper);
        let [(_, helper_end)] = ranges.as_slice() else {
            stack.pop();
            return Err(ThreadBlocker::AmbiguousHelperUse {
                helper: helper.to_owned(),
                line: line_index + 1,
            });
        };
        let before = &lines[line_index][..ranges[0].0];
        let after = &lines[line_index][*helper_end..];
        let source_available = !identifier_ranges(before, parameter).is_empty()
            || !identifier_ranges(after, parameter).is_empty()
            || same_block_immutable_binding(lines, line_index, parameter).is_some()
            || ancestor_block_immutable_binding(lines, line_index, parameter).is_some()
            || ancestor_parameter_binding(lines, line_index, parameter).is_some();
        if !source_available {
            let Some(parent) = nearest_ancestor_binding(lines, line_index) else {
                stack.pop();
                return Err(ThreadBlocker::ParameterUnavailable {
                    helper: helper.to_owned(),
                    parameter: parameter.to_owned(),
                    line: line_index + 1,
                });
            };
            if !generated_binding(&parent) {
                stack.pop();
                return Err(ThreadBlocker::ParameterUnavailable {
                    helper: helper.to_owned(),
                    parameter: parameter.to_owned(),
                    line: line_index + 1,
                });
            }
            thread_generated_parameter(lines, &parent, parameter, stack)?;
        }
        insert_parameter_after_identifier(&mut lines[line_index], helper, parameter)?;
    }
    stack.pop();
    Ok(())
}

fn skip_ascii_whitespace(bytes: &[u8], mut index: usize) -> usize {
    while bytes
        .get(index)
        .is_some_and(|byte| byte.is_ascii_whitespace())
    {
        index += 1;
    }
    index
}

fn exact_partial_application(
    line: &str,
    lifted_start: usize,
    lifted_end: usize,
    parameters: &[String],
) -> Option<(usize, usize)> {
    let bytes = line.as_bytes();
    let mut open = lifted_start;
    while open > 0 && bytes[open - 1].is_ascii_whitespace() {
        open -= 1;
    }
    if open == 0 || bytes[open - 1] != b'(' {
        return None;
    }
    let start = open - 1;
    let mut cursor = lifted_end;
    for parameter in parameters {
        let parameter_start = skip_ascii_whitespace(bytes, cursor);
        if parameter_start == cursor
            || !bytes
                .get(parameter_start)
                .copied()
                .is_some_and(identifier_start)
        {
            return None;
        }
        let mut parameter_end = parameter_start + 1;
        while bytes
            .get(parameter_end)
            .copied()
            .is_some_and(identifier_continue)
        {
            parameter_end += 1;
        }
        if line.get(parameter_start..parameter_end) != Some(parameter.as_str()) {
            return None;
        }
        cursor = parameter_end;
    }
    cursor = skip_ascii_whitespace(bytes, cursor);
    (bytes.get(cursor) == Some(&b')')).then_some((start, cursor + 1))
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum CaptureShape {
    Bare { start: usize, end: usize },
    Partial { start: usize, end: usize },
}

impl CaptureShape {
    const fn range(self) -> (usize, usize) {
        match self {
            Self::Bare { start, end } | Self::Partial { start, end } => (start, end),
        }
    }
}

fn captured_argument(
    line: &str,
    helper_end: usize,
    promotion: &str,
    lifted: &str,
    parameters: &[String],
) -> Option<CaptureShape> {
    let suffix = line.get(helper_end..)?;
    let original = identifier_ranges(suffix, promotion);
    let lifted_ranges = identifier_ranges(suffix, lifted);
    match (original.as_slice(), lifted_ranges.as_slice()) {
        ([(start, end)], []) => Some(CaptureShape::Bare {
            start: helper_end + *start,
            end: helper_end + *end,
        }),
        ([], [(start, end)]) => {
            exact_partial_application(line, helper_end + *start, helper_end + *end, parameters)
                .map(|(start, end)| CaptureShape::Partial { start, end })
        }
        _ => None,
    }
}

impl ThreadPlan<Unchecked> {
    pub fn new(
        text: &str,
        helper: &str,
        promotion: &str,
        lifted: &str,
        all_parameters: &[String],
        missing: &[String],
    ) -> Result<Self, ThreadBlocker> {
        let lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
        let headers = lines
            .iter()
            .enumerate()
            .filter_map(|(index, line)| {
                let (binding, parameters) = binding_name_and_parameters(line)?;
                (binding == helper).then_some((index, parameters))
            })
            .collect::<Vec<_>>();
        let [(header, header_parameters)] = headers.as_slice() else {
            return Err(if headers.is_empty() {
                ThreadBlocker::MissingHelperHeader {
                    helper: helper.to_owned(),
                }
            } else {
                ThreadBlocker::AmbiguousHelperHeader {
                    helper: helper.to_owned(),
                }
            });
        };
        let header = *header;
        let missing = missing
            .iter()
            .filter(|parameter| {
                !header_parameters
                    .iter()
                    .any(|present| present == *parameter)
            })
            .cloned()
            .collect::<Vec<_>>();
        let helper_range = identifier_ranges(&lines[header], helper);
        let [(_, helper_end)] = helper_range.as_slice() else {
            return Err(ThreadBlocker::AmbiguousHelperHeader {
                helper: helper.to_owned(),
            });
        };
        let promotion_ranges = identifier_ranges(&lines[header][*helper_end..], promotion);
        let [(relative_start, _)] = promotion_ranges.as_slice() else {
            return Err(ThreadBlocker::MissingCapturedParameter {
                helper: helper.to_owned(),
                promotion: promotion.to_owned(),
            });
        };
        Ok(Self {
            helper: helper.to_owned(),
            promotion: promotion.to_owned(),
            lifted: lifted.to_owned(),
            all_parameters: all_parameters.to_vec(),
            missing,
            lines,
            trailing_newline: text.ends_with('\n'),
            header,
            header_insert_at: *helper_end + *relative_start,
            calls: Vec::new(),
            witnesses: ScopeWitness::Nil,
            _state: PhantomData,
        })
    }

    pub fn prove(mut self) -> Result<ThreadPlan<Proven>, ThreadBlocker> {
        for line_index in 0..self.lines.len() {
            if line_index == self.header || self.lines[line_index].trim_start().starts_with("//") {
                continue;
            }
            let helper_ranges = identifier_ranges(&self.lines[line_index], &self.helper);
            if helper_ranges.is_empty() {
                continue;
            }
            let [(_, helper_end)] = helper_ranges.as_slice() else {
                return Err(ThreadBlocker::AmbiguousHelperUse {
                    helper: self.helper.clone(),
                    line: line_index + 1,
                });
            };
            let shape = captured_argument(
                &self.lines[line_index],
                *helper_end,
                &self.promotion,
                &self.lifted,
                &self.all_parameters,
            )
            .ok_or_else(|| ThreadBlocker::MissingCapturedArgument {
                helper: self.helper.clone(),
                line: line_index + 1,
            })?;
            let (capture_start, capture_end) = shape.range();
            for parameter in &self.missing {
                let source = if matches!(shape, CaptureShape::Partial { .. }) {
                    ParameterSource::CapturedPartialApplication
                } else {
                    let before = &self.lines[line_index][..capture_start];
                    let after = &self.lines[line_index][capture_end..];
                    if !identifier_ranges(before, parameter).is_empty()
                        || !identifier_ranges(after, parameter).is_empty()
                    {
                        ParameterSource::SameCallLine
                    } else if let Some(binding) =
                        same_block_immutable_binding(&self.lines, line_index, parameter)
                    {
                        ParameterSource::SameBlockBinding { binding }
                    } else if let Some(binding) =
                        ancestor_block_immutable_binding(&self.lines, line_index, parameter)
                    {
                        ParameterSource::AncestorBlockBinding { binding }
                    } else if let Some(binding) =
                        ancestor_parameter_binding(&self.lines, line_index, parameter)
                    {
                        ParameterSource::AncestorBinding { binding }
                    } else {
                        return Err(ThreadBlocker::ParameterUnavailable {
                            helper: self.helper.clone(),
                            parameter: parameter.clone(),
                            line: line_index + 1,
                        });
                    }
                };
                self.witnesses = self.witnesses.push(parameter.clone(), source);
            }
            self.calls.push(PlannedCall {
                line: line_index,
                insert_at: capture_start,
            });
        }
        if self.calls.is_empty() {
            return Err(ThreadBlocker::MissingHelperCall {
                helper: self.helper.clone(),
            });
        }
        Ok(ThreadPlan {
            helper: self.helper,
            promotion: self.promotion,
            lifted: self.lifted,
            all_parameters: self.all_parameters,
            missing: self.missing,
            lines: self.lines,
            trailing_newline: self.trailing_newline,
            header: self.header,
            header_insert_at: self.header_insert_at,
            calls: self.calls,
            witnesses: self.witnesses,
            _state: PhantomData,
        })
    }
}

impl ThreadPlan<Proven> {
    #[must_use]
    pub fn commit(mut self) -> ThreadArtifact {
        let insertion = if self.missing.is_empty() {
            String::new()
        } else {
            format!("{} ", self.missing.join(" "))
        };
        self.lines[self.header].insert_str(self.header_insert_at, &insertion);
        for call in &self.calls {
            self.lines[call.line].insert_str(call.insert_at, &insertion);
        }
        let mut text = self.lines.join("\n");
        if self.trailing_newline {
            text.push('\n');
        }
        ThreadArtifact {
            text,
            receipt: ThreadReceipt {
                helper: self.helper,
                promotion: self.promotion,
                inserted_parameters: self.missing,
                call_sites: self.calls.len(),
                witnesses: self.witnesses,
            },
        }
    }
}

pub fn thread_missing_parameters(
    text: &str,
    helper: &str,
    promotion: &str,
    lifted: &str,
    all_parameters: &[String],
    missing: &[String],
) -> Result<ThreadArtifact, ThreadBlocker> {
    let mut artifact =
        ThreadPlan::<Unchecked>::new(text, helper, promotion, lifted, all_parameters, missing)?
            .prove()?
            .commit();
    artifact.text = annotate_lifted_capture_parameters(&artifact.text, lifted, all_parameters)?;
    Ok(artifact)
}

pub fn thread_missing_parameters_transitively(
    text: &str,
    helper: &str,
    promotion: &str,
    lifted: &str,
    all_parameters: &[String],
    missing: &[String],
) -> Result<ThreadArtifact, ThreadBlocker> {
    let trailing_newline = text.ends_with('\n');
    let mut source = text.to_owned();
    let max_rounds = missing.len().saturating_mul(16).max(16);
    for _ in 0..max_rounds {
        match ThreadPlan::<Unchecked>::new(
            &source,
            helper,
            promotion,
            lifted,
            all_parameters,
            missing,
        )
        .and_then(ThreadPlan::prove)
        {
            Ok(plan) => {
                let mut artifact = plan.commit();
                artifact.text =
                    annotate_lifted_capture_parameters(&artifact.text, lifted, all_parameters)?;
                return Ok(artifact);
            }
            Err(ThreadBlocker::ParameterUnavailable {
                helper: blocked_helper,
                parameter,
                line,
            }) => {
                let mut lines = source.lines().map(str::to_owned).collect::<Vec<_>>();
                let Some(parent) = line
                    .checked_sub(1)
                    .and_then(|index| nearest_ancestor_binding(&lines, index))
                else {
                    return Err(ThreadBlocker::ParameterUnavailable {
                        helper: blocked_helper,
                        parameter,
                        line,
                    });
                };
                if !generated_binding(&parent) {
                    return Err(ThreadBlocker::ParameterUnavailable {
                        helper: blocked_helper,
                        parameter,
                        line,
                    });
                }
                let mut stack = Vec::new();
                thread_generated_parameter(&mut lines, &parent, &parameter, &mut stack)?;
                source = lines.join("\n");
                if trailing_newline {
                    source.push('\n');
                }
            }
            Err(error) => return Err(error),
        }
    }
    Err(ThreadBlocker::ParameterUnavailable {
        helper: helper.to_owned(),
        parameter: missing.first().cloned().unwrap_or_default(),
        line: 0,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn threads_missing_parameter_from_ancestor_binding() {
        let source = r#"    let __spiral_lift_inner state poly term =
        poly term

    let __spiral_lift_poly state depth job = job

    let owner state depth term =
        (__spiral_lift_inner state poly) term
"#;
        let artifact = thread_missing_parameters(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned(), "depth".to_owned()],
            &["depth".to_owned()],
        )
        .expect("ancestor parameter is a lexical witness");
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_inner state depth poly term =")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_inner state depth poly) term")
        );
        assert_eq!(artifact.receipt.call_sites, 1);
        assert_eq!(artifact.receipt.witnesses.len(), 1);
    }

    #[test]
    fn threads_missing_parameters_from_exact_partial_application() {
        let source = r#"    let rec __spiral_scc_owner state poly term =
        poly term
    and owner state depth term =
        __spiral_scc_owner state (__spiral_lift_poly state depth) term

    let __spiral_lift_poly state depth job = job
"#;
        let artifact = thread_missing_parameters(
            source,
            "__spiral_scc_owner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned(), "depth".to_owned()],
            &["depth".to_owned()],
        )
        .expect("partial application carries the missing parameter");
        assert!(
            artifact
                .text
                .contains("let rec __spiral_scc_owner state depth poly term =")
        );
        assert!(
            artifact
                .text
                .contains("__spiral_scc_owner state depth (__spiral_lift_poly state depth) term")
        );
    }

    #[test]
    fn threads_parameter_transitively_to_same_block_binding() {
        let source = r#"    let __spiral_lift_inner poly term =
        poly term

    let __spiral_lift_outer poly term =
        (__spiral_lift_inner poly) term

    let owner poly term =
        let state = new_state ()
        (__spiral_lift_outer poly) term

    let __spiral_lift_poly state job = job
"#;
        let artifact = thread_missing_parameters_transitively(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned()],
            &["state".to_owned()],
        )
        .expect("generated ancestors should thread from a same-block immutable binding");
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_inner state poly term =")
        );
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_outer state poly term =")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_inner state poly) term")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_outer state poly) term")
        );
    }

    #[test]
    fn threads_parameter_from_immutable_binding_in_ancestor_block() {
        let source = r#"    let __spiral_lift_inner poly term =
        poly term

    let __spiral_scc_outer poly term =
        (__spiral_lift_inner poly) term

    let owner input =
        let state = new_state ()
        let local term =
            (__spiral_scc_outer poly) term
        local input

    let __spiral_lift_poly state job = job
"#;
        let artifact = thread_missing_parameters_transitively(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned()],
            &["state".to_owned()],
        )
        .expect(
            "a later local function may capture an earlier immutable binding in its parent block",
        );
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_inner state poly term =")
        );
        assert!(
            artifact
                .text
                .contains("let __spiral_scc_outer state poly term =")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_scc_outer state poly) term")
        );
    }

    #[test]
    fn threads_parameter_through_generated_match_wrapper_and_scc() {
        let source = r#"    let __spiral_lift_inner poly term =
        poly term

    let __spiral_match_owner () =
        (__spiral_lift_inner poly) term

    let __spiral_scc_outer term =
        __spiral_match_owner ()

    let owner input =
        let state = new_state ()
        let local term =
            __spiral_scc_outer term
        local input

    let __spiral_lift_poly state job = job
"#;
        let artifact = thread_missing_parameters_transitively(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned()],
            &["state".to_owned()],
        )
        .expect("generated match wrappers belong to the same transitive capture chain");
        assert!(
            artifact
                .text
                .contains("let __spiral_match_owner state () =")
        );
        assert!(
            artifact
                .text
                .contains("let __spiral_scc_outer state term =")
        );
        assert!(artifact.text.contains("__spiral_match_owner state ()"));
        assert!(artifact.text.contains("__spiral_scc_outer state term"));
    }

    #[test]
    fn threads_parameter_through_local_closure_to_generated_ancestor() {
        let source = r#"    let __spiral_lift_inner poly term =
        poly term

    let __spiral_match_owner poly input =
        let run () =
            (__spiral_lift_inner poly) input
        run ()

    let __spiral_lift_poly state term = term

    let owner state input =
        (__spiral_match_owner poly) input
"#;
        let artifact = thread_missing_parameters_transitively(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned()],
            &["state".to_owned()],
        )
        .expect("local closures should capture from a threaded generated ancestor");
        assert!(
            artifact
                .text
                .contains("let __spiral_match_owner state poly input =")
        );
        assert!(artifact.text.contains("let run () ="));
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_inner state poly) input")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_match_owner state poly) input")
        );
    }

    #[test]
    fn annotates_historical_lifted_capture_from_unique_binding() {
        let source = r#"    let __spiral_lift_preview cache x =
        cache.TryGetValue x

    let __spiral_scc_owner preview x =
        preview x

    let cache = System.Collections.Concurrent.ConcurrentDictionary<int, string>()

    let owner x =
        __spiral_scc_owner (__spiral_lift_preview cache) x
"#;
        let artifact = thread_missing_parameters(
            source,
            "__spiral_scc_owner",
            "preview",
            "__spiral_lift_preview",
            &["cache".to_owned()],
            &[],
        )
        .expect("unique constructor binding should restore the capture annotation");
        assert!(artifact.text.contains(
            "let __spiral_lift_preview (cache: System.Collections.Concurrent.ConcurrentDictionary<int, string>) x ="
        ));
    }

    #[test]
    fn threads_parameter_through_recursive_generated_helper_past_local_values() {
        let source = r#"    let rec __spiral_lift_inner poly () =
        let snapshot = poly ()
        if snapshot then ()
        else
            (__spiral_lift_inner poly) ()

    let owner state =
        (__spiral_lift_inner poly) ()

    let __spiral_lift_poly state () = true
"#;
        let artifact = thread_missing_parameters_transitively(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned()],
            &["state".to_owned()],
        )
        .expect("recursive generated helper should forward its newly threaded parameter");
        assert!(
            artifact
                .text
                .contains("let rec __spiral_lift_inner state poly () ="),
            "{}",
            artifact.text
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_inner state poly) ()")
        );
    }

    #[test]
    fn fails_closed_when_parameter_is_not_in_lexical_scope() {
        let source = r#"    let __spiral_lift_inner state poly term =
        poly term

    let owner state term =
        (__spiral_lift_inner state poly) term
"#;
        let error = thread_missing_parameters(
            source,
            "__spiral_lift_inner",
            "poly",
            "__spiral_lift_poly",
            &["state".to_owned(), "depth".to_owned()],
            &["depth".to_owned()],
        )
        .expect_err("unavailable parameter must remain blocked");
        assert!(matches!(
            error,
            ThreadBlocker::ParameterUnavailable { parameter, .. } if parameter == "depth"
        ));
    }
}
