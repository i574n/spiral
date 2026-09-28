use spiral_split_cross_stage_thread::{
    ThreadBlocker, annotate_lifted_capture_parameters, thread_missing_parameters_transitively,
};
use spiral_split_lift_rewrite::{AppliedEdit, RewriteBlocker, rewrite_call_sites};
use std::collections::BTreeMap;
use std::fmt::{Display, Formatter, Write as _};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct Promotion {
    pub original: String,
    pub lifted: String,
    pub parameters: Vec<String>,
}

impl Promotion {
    #[must_use]
    pub fn new(
        original: impl Into<String>,
        lifted: impl Into<String>,
        parameters: Vec<String>,
    ) -> Self {
        Self {
            original: original.into(),
            lifted: lifted.into(),
            parameters,
        }
    }
}

#[must_use]
pub fn promotions_from_edits(edits: &[AppliedEdit]) -> Vec<Promotion> {
    let mut renames = Vec::new();
    let mut parameters = BTreeMap::<String, Vec<(usize, String)>>::new();
    for edit in edits {
        match edit {
            AppliedEdit::Rename { from, to } => renames.push((from.clone(), to.clone())),
            AppliedEdit::AddParameter {
                symbol,
                name,
                ordinal,
            } => parameters
                .entry(symbol.clone())
                .or_default()
                .push((*ordinal, name.clone())),
            AppliedEdit::Hoist { .. } | AppliedEdit::RewriteCall { .. } => {}
        }
    }
    renames
        .into_iter()
        .map(|(original, lifted)| {
            let mut slots = parameters.remove(&original).unwrap_or_default();
            slots.sort_by_key(|(ordinal, _)| *ordinal);
            Promotion::new(
                original,
                lifted,
                slots.into_iter().map(|(_, name)| name).collect(),
            )
        })
        .collect()
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum RelinkBlocker {
    UnsupportedCapturedPromotion {
        original: String,
    },
    AmbiguousHelperCall {
        helper: String,
        promotion: String,
        line: usize,
    },
    UnavailablePromotionParameters {
        helper: String,
        promotion: String,
        missing: Vec<String>,
    },
    Thread {
        helper: String,
        promotion: String,
        source: ThreadBlocker,
    },
    MissingHelperCall {
        helper: String,
    },
    BodyLineDrift {
        helper: String,
    },
    Rewrite {
        helper: String,
        source: RewriteBlocker,
    },
}

impl Display for RelinkBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::UnsupportedCapturedPromotion { original } => {
                write!(formatter, "captured-promotion-has-parameters:{original}")
            }
            Self::AmbiguousHelperCall {
                helper,
                promotion,
                line,
            } => {
                write!(
                    formatter,
                    "ambiguous-helper-call:{helper}:promotion={promotion}:line={line}"
                )
            }
            Self::UnavailablePromotionParameters {
                helper,
                promotion,
                missing,
            } => write!(
                formatter,
                "unavailable-promotion-parameters:{helper}:promotion={promotion}:missing={}",
                missing.join(",")
            ),
            Self::Thread {
                helper,
                promotion,
                source,
            } => write!(formatter, "thread:{helper}:promotion={promotion}:{source}"),
            Self::MissingHelperCall { helper } => write!(formatter, "missing-helper-call:{helper}"),
            Self::BodyLineDrift { helper } => write!(formatter, "body-line-drift:{helper}"),
            Self::Rewrite { helper, source } => write!(formatter, "rewrite:{helper}:{source}"),
        }
    }
}

impl RelinkBlocker {
    #[must_use]
    pub fn exclusion_hint(&self) -> Option<(&str, &str)> {
        match self {
            Self::UnavailablePromotionParameters {
                helper, promotion, ..
            }
            | Self::AmbiguousHelperCall {
                helper, promotion, ..
            }
            | Self::Thread {
                helper, promotion, ..
            } => Some((helper, promotion)),
            _ => None,
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct RelinkedHelper {
    pub helper: String,
    pub promotion: String,
    pub threaded_parameters: usize,
    pub rewritten_body_calls: usize,
    pub removed_call_arguments: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct RelinkArtifact {
    pub text: String,
    pub helpers: Vec<RelinkedHelper>,
}

impl RelinkArtifact {
    #[must_use]
    pub fn rewritten_helpers(&self) -> usize {
        self.helpers.len()
    }

    #[must_use]
    pub fn removed_call_arguments(&self) -> usize {
        self.helpers
            .iter()
            .map(|helper| helper.removed_call_arguments)
            .sum()
    }

    #[must_use]
    pub fn rewritten_body_calls(&self) -> usize {
        self.helpers
            .iter()
            .map(|helper| helper.rewritten_body_calls)
            .sum()
    }

    #[must_use]
    pub fn threaded_parameters(&self) -> usize {
        self.helpers
            .iter()
            .map(|helper| helper.threaded_parameters)
            .sum()
    }

    #[must_use]
    pub fn render_receipt(&self) -> String {
        let mut output = String::from(
            "helper\tpromotion\tthreaded_parameters\trewritten_body_calls\tremoved_call_arguments\n",
        );
        for helper in &self.helpers {
            let _ = writeln!(
                output,
                "{}\t{}\t{}\t{}\t{}",
                helper.helper,
                helper.promotion,
                helper.threaded_parameters,
                helper.rewritten_body_calls,
                helper.removed_call_arguments
            );
        }
        output
    }
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

fn generated_binding(line: &str) -> Option<(String, usize, usize)> {
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
    let name = line.get(start..index)?;
    (name.starts_with("__spiral_lift_") || name.starts_with("__spiral_scc_"))
        .then(|| (name.to_owned(), start, index))
}

fn helper_captures(line: &str, helper_end: usize, original: &str) -> bool {
    let header_end = line.rfind('=').unwrap_or(line.len());
    if helper_end >= header_end {
        return false;
    }
    identifier_ranges(&line[helper_end..header_end], original).len() == 1
}

fn missing_helper_parameters(line: &str, helper_end: usize, parameters: &[String]) -> Vec<String> {
    let header_end = line.rfind('=').unwrap_or(line.len());
    if helper_end >= header_end {
        return parameters.to_vec();
    }
    let header = &line[helper_end..header_end];
    parameters
        .iter()
        .filter(|parameter| identifier_ranges(header, parameter).len() != 1)
        .cloned()
        .collect()
}

fn annotated_parameter_group(
    line: &str,
    helper_end: usize,
    header_end: usize,
    start: usize,
    end: usize,
) -> Option<(usize, usize, usize)> {
    let bytes = line.as_bytes();
    let mut stack = Vec::new();
    let mut candidate = None;
    for index in helper_end..header_end {
        match bytes[index] {
            b'(' => stack.push(index),
            b')' => {
                let Some(open) = stack.pop() else {
                    return None;
                };
                if open < start && end <= index {
                    let mut depth = 0usize;
                    let mut colon = None;
                    for cursor in open + 1..index {
                        match bytes[cursor] {
                            b'(' => depth += 1,
                            b')' => depth = depth.saturating_sub(1),
                            b':' if depth == 0 && cursor >= end => {
                                colon = Some(cursor);
                                break;
                            }
                            _ => {}
                        }
                    }
                    if let Some(colon) = colon {
                        candidate = Some((open, index, colon));
                    }
                }
            }
            _ => {}
        }
    }
    candidate
}

fn remove_header_parameter(line: &str, helper_end: usize, original: &str) -> Option<String> {
    let header_end = line.rfind('=').unwrap_or(line.len());
    let ranges = identifier_ranges(&line[helper_end..header_end], original);
    let [(relative_start, relative_end)] = ranges.as_slice() else {
        return None;
    };
    let start = helper_end + relative_start;
    let end = helper_end + relative_end;
    if let Some((open, close, _colon)) =
        annotated_parameter_group(line, helper_end, header_end, start, end)
    {
        let preserved = line[open + 1..start].trim_end();
        let mut output = String::with_capacity(line.len());
        if preserved.trim().is_empty() {
            let mut erase_start = open;
            if erase_start > helper_end && line.as_bytes()[erase_start - 1].is_ascii_whitespace() {
                erase_start -= 1;
            }
            output.push_str(&line[..erase_start]);
            output.push_str(&line[close + 1..]);
        } else {
            output.push_str(&line[..open]);
            output.push_str(preserved.trim_start());
            output.push_str(&line[close + 1..]);
        }
        return Some(output);
    }

    let mut erase_start = start;
    if erase_start > helper_end && line.as_bytes()[erase_start - 1] == b' ' {
        erase_start -= 1;
    }
    let mut output = String::with_capacity(line.len());
    output.push_str(&line[..erase_start]);
    output.push_str(&line[end..]);
    Some(output)
}

fn helper_body_end(lines: &[String], header: usize, indent: usize) -> usize {
    for (index, line) in lines.iter().enumerate().skip(header + 1) {
        let trimmed = line.trim();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            continue;
        }
        if leading_spaces(line) <= indent {
            return index;
        }
    }
    lines.len()
}

fn call_token_ranges(line: &str, after: usize, candidates: &[&str]) -> Vec<(usize, usize)> {
    let mut ranges = Vec::new();
    for candidate in candidates {
        for (start, end) in identifier_ranges(&line[after..], candidate) {
            ranges.push((after + start, after + end));
        }
    }
    ranges.sort_unstable();
    ranges.dedup();
    ranges
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum CapturedArgumentShape {
    BareIdentifier { start: usize, end: usize },
    ExactPartialApplication { start: usize, end: usize },
}

impl CapturedArgumentShape {
    const fn range(self) -> (usize, usize) {
        match self {
            Self::BareIdentifier { start, end } | Self::ExactPartialApplication { start, end } => {
                (start, end)
            }
        }
    }
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
) -> Option<CapturedArgumentShape> {
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
    (bytes.get(cursor) == Some(&b')')).then_some(CapturedArgumentShape::ExactPartialApplication {
        start,
        end: cursor + 1,
    })
}

fn captured_argument(
    line: &str,
    helper_end: usize,
    promotion: &Promotion,
    parameters_available: bool,
) -> Result<Option<CapturedArgumentShape>, ()> {
    if promotion.parameters.is_empty() {
        let candidates = call_token_ranges(
            line,
            helper_end,
            &[promotion.original.as_str(), promotion.lifted.as_str()],
        );
        return match candidates.as_slice() {
            [] => Ok(None),
            [(start, end)] => Ok(Some(CapturedArgumentShape::BareIdentifier {
                start: *start,
                end: *end,
            })),
            _ => Err(()),
        };
    }

    if !parameters_available {
        return Err(());
    }
    let suffix = &line[helper_end..];
    let lifted = identifier_ranges(suffix, &promotion.lifted);
    let original = identifier_ranges(suffix, &promotion.original);
    match (lifted.as_slice(), original.as_slice()) {
        ([], []) => Ok(None),
        ([], [(start, end)]) => Ok(Some(CapturedArgumentShape::BareIdentifier {
            start: helper_end + *start,
            end: helper_end + *end,
        })),
        ([(relative_start, relative_end)], []) => exact_partial_application(
            line,
            helper_end + *relative_start,
            helper_end + *relative_end,
            &promotion.parameters,
        )
        .map(Some)
        .ok_or(()),
        _ => Err(()),
    }
}

fn remove_call_capture(
    line: &str,
    helper: &str,
    promotion: &Promotion,
    parameters_available: bool,
) -> Result<Option<String>, ()> {
    let helper_ranges = identifier_ranges(line, helper);
    if helper_ranges.is_empty() {
        return Ok(None);
    }
    if helper_ranges.len() != 1 {
        return Err(());
    }
    let (_, helper_end) = helper_ranges[0];
    let Some(argument) = captured_argument(line, helper_end, promotion, parameters_available)?
    else {
        return Ok(None);
    };
    let (start, end) = argument.range();
    let mut erase_start = start;
    if erase_start > helper_end && line.as_bytes()[erase_start - 1].is_ascii_whitespace() {
        erase_start -= 1;
    } else if end < line.len() && line.as_bytes()[end].is_ascii_whitespace() {
        let mut erase_end = end + 1;
        while erase_end < line.len() && line.as_bytes()[erase_end] == b' ' {
            erase_end += 1;
        }
        let mut output = String::with_capacity(line.len());
        output.push_str(&line[..start]);
        output.push_str(&line[erase_end..]);
        return Ok(Some(output));
    } else {
        return Err(());
    }
    let mut output = String::with_capacity(line.len());
    output.push_str(&line[..erase_start]);
    output.push_str(&line[end..]);
    Ok(Some(output))
}

fn replace_body_lines(
    lines: &mut [String],
    start: usize,
    end: usize,
    replacement: &str,
    helper: &str,
) -> Result<(), RelinkBlocker> {
    let replacement_lines = replacement
        .split('\n')
        .map(str::to_owned)
        .collect::<Vec<_>>();
    if replacement_lines.len() != end.saturating_sub(start) {
        return Err(RelinkBlocker::BodyLineDrift {
            helper: helper.to_owned(),
        });
    }
    for (target, replacement) in lines[start..end].iter_mut().zip(replacement_lines) {
        *target = replacement;
    }
    Ok(())
}

fn relink_helper(
    lines: &mut [String],
    header: usize,
    promotion: &Promotion,
) -> Result<RelinkedHelper, RelinkBlocker> {
    let (helper, _, helper_end) =
        generated_binding(&lines[header]).ok_or_else(|| RelinkBlocker::AmbiguousHelperCall {
            helper: "<missing-generated-binding>".to_owned(),
            promotion: promotion.original.clone(),
            line: header + 1,
        })?;
    let missing_parameters =
        missing_helper_parameters(&lines[header], helper_end, &promotion.parameters);
    let mut threaded_parameters = 0usize;
    if !missing_parameters.is_empty() {
        let mut thread_source = lines.join("\n");
        if lines.last().is_some_and(String::is_empty) {
            thread_source.push('\n');
        }
        let threaded = thread_missing_parameters_transitively(
            &thread_source,
            &helper,
            &promotion.original,
            &promotion.lifted,
            &promotion.parameters,
            &missing_parameters,
        )
        .map_err(|source| RelinkBlocker::Thread {
            helper: helper.clone(),
            promotion: promotion.original.clone(),
            source,
        })?;
        let threaded_lines = threaded.text.lines().map(str::to_owned).collect::<Vec<_>>();
        if threaded_lines.len() != lines.len() {
            return Err(RelinkBlocker::BodyLineDrift {
                helper: helper.clone(),
            });
        }
        for (target, replacement) in lines.iter_mut().zip(threaded_lines) {
            *target = replacement;
        }
        threaded_parameters = threaded.receipt.inserted_parameters.len();
        let (_, _, threaded_helper_end) = generated_binding(&lines[header]).ok_or_else(|| {
            RelinkBlocker::AmbiguousHelperCall {
                helper: helper.clone(),
                promotion: promotion.original.clone(),
                line: header + 1,
            }
        })?;
        let still_missing =
            missing_helper_parameters(&lines[header], threaded_helper_end, &promotion.parameters);
        if !still_missing.is_empty() {
            return Err(RelinkBlocker::UnavailablePromotionParameters {
                helper: helper.clone(),
                promotion: promotion.original.clone(),
                missing: still_missing,
            });
        }
    }
    let (_, _, helper_end) =
        generated_binding(&lines[header]).ok_or_else(|| RelinkBlocker::AmbiguousHelperCall {
            helper: helper.clone(),
            promotion: promotion.original.clone(),
            line: header + 1,
        })?;
    let parameters_available = true;
    let indent = leading_spaces(&lines[header]);
    lines[header] = remove_header_parameter(&lines[header], helper_end, &promotion.original)
        .ok_or_else(|| RelinkBlocker::AmbiguousHelperCall {
            helper: helper.clone(),
            promotion: promotion.original.clone(),
            line: header + 1,
        })?;

    let body_end = helper_body_end(lines, header, indent);
    let body_start = header + 1;
    let body = lines[body_start..body_end].join("\n");
    let (rewritten, rewritten_body_calls) = rewrite_call_sites(
        &body,
        &promotion.original,
        &promotion.lifted,
        &promotion.parameters,
    )
    .map_err(|source| RelinkBlocker::Rewrite {
        helper: helper.clone(),
        source,
    })?;
    if rewritten.split('\n').count() != body_end.saturating_sub(body_start)
        && threaded_parameters > 0
    {
        return Err(RelinkBlocker::Thread {
            helper: helper.clone(),
            promotion: promotion.original.clone(),
            source: ThreadBlocker::BodyRewriteLineDrift {
                helper: helper.clone(),
            },
        });
    }
    replace_body_lines(lines, body_start, body_end, &rewritten, &helper)?;

    let mut removed_call_arguments = 0usize;
    for (line_index, line) in lines.iter_mut().enumerate() {
        if line_index == header {
            continue;
        }
        match remove_call_capture(line, &helper, promotion, parameters_available) {
            Ok(Some(next)) => {
                *line = next;
                removed_call_arguments += 1;
            }
            Ok(None) => {}
            Err(()) => {
                return Err(RelinkBlocker::AmbiguousHelperCall {
                    helper: helper.clone(),
                    promotion: promotion.original.clone(),
                    line: line_index + 1,
                });
            }
        }
    }
    if removed_call_arguments == 0 {
        return Err(RelinkBlocker::MissingHelperCall {
            helper: helper.clone(),
        });
    }
    Ok(RelinkedHelper {
        helper,
        promotion: promotion.original.clone(),
        threaded_parameters,
        rewritten_body_calls,
        removed_call_arguments,
    })
}

fn helper_has_captured_argument(
    lines: &[String],
    header: usize,
    helper: &str,
    promotion: &Promotion,
) -> bool {
    lines.iter().enumerate().any(|(line_index, line)| {
        if line_index == header {
            return false;
        }
        let ranges = identifier_ranges(line, helper);
        let [(_, helper_end)] = ranges.as_slice() else {
            return false;
        };
        let suffix = &line[*helper_end..];
        !identifier_ranges(suffix, &promotion.original).is_empty()
            || !identifier_ranges(suffix, &promotion.lifted).is_empty()
    })
}

pub fn relink_promoted_captures(
    text: &str,
    promotions: &[Promotion],
) -> Result<RelinkArtifact, RelinkBlocker> {
    let trailing_newline = text.ends_with('\n');
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    let mut helpers = Vec::new();

    for promotion in promotions {
        let mut source = lines.join("\n");
        if trailing_newline {
            source.push('\n');
        }
        let annotated =
            annotate_lifted_capture_parameters(&source, &promotion.lifted, &promotion.parameters)
                .map_err(|source| RelinkBlocker::Thread {
                helper: promotion.lifted.clone(),
                promotion: promotion.original.clone(),
                source,
            })?;
        let annotated_lines = annotated.lines().map(str::to_owned).collect::<Vec<_>>();
        if annotated_lines.len() != lines.len() {
            return Err(RelinkBlocker::BodyLineDrift {
                helper: promotion.lifted.clone(),
            });
        }
        for (target, replacement) in lines.iter_mut().zip(annotated_lines) {
            *target = replacement;
        }
        loop {
            let candidate = lines.iter().enumerate().find_map(|(index, line)| {
                let (helper, _, helper_end) = generated_binding(line)?;
                (helper_captures(line, helper_end, &promotion.original)
                    && helper_has_captured_argument(&lines, index, &helper, promotion))
                .then_some(index)
            });
            let Some(header) = candidate else {
                break;
            };
            helpers.push(relink_helper(&mut lines, header, promotion)?);
        }
    }

    let mut output = lines.join("\n");
    if trailing_newline {
        output.push('\n');
    }
    Ok(RelinkArtifact {
        text: output,
        helpers,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    fn promotion(original: &str, lifted: &str) -> Promotion {
        Promotion::new(original, lifted, Vec::new())
    }

    #[test]
    fn relinks_polymorphic_capture_through_generated_helper_chain() {
        let source = r#"    let __spiral_lift_inner data poly apply x =
        poly 1 lookup (fun continuation -> continuation.state)

    let __spiral_lift_outer env poly apply x =
        (__spiral_lift_inner data poly) apply x

    let __spiral_lift_new_poly job lookup run =
        run continuation

    let owner apply x =
        (__spiral_lift_outer env __spiral_lift_new_poly) apply x
"#;
        let artifact =
            relink_promoted_captures(source, &[promotion("poly", "__spiral_lift_new_poly")])
                .expect("cross-stage relink");
        assert_eq!(artifact.rewritten_helpers(), 2);
        assert_eq!(artifact.removed_call_arguments(), 2);
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_inner data apply x =")
        );
        assert!(artifact.text.contains("__spiral_lift_new_poly 1 lookup"));
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_outer env apply x =")
        );
        assert!(artifact.text.contains("(__spiral_lift_inner data) apply x"));
        assert!(artifact.text.contains("(__spiral_lift_outer env) apply x"));
        assert!(
            !artifact
                .text
                .contains("__spiral_lift_outer env __spiral_lift_new_poly")
        );
    }

    #[test]
    fn relinks_polymorphic_capture_through_generated_recursive_scc() {
        let source = r#"    let rec __spiral_scc_owner poly term x =
        poly 1 lookup (fun continuation -> continuation.state)
    and owner term x =
        __spiral_scc_owner poly term x

    let __spiral_lift_poly job lookup run =
        run continuation
"#;
        let artifact = relink_promoted_captures(source, &[promotion("poly", "__spiral_lift_poly")])
            .expect("recursive SCC relink");
        assert_eq!(artifact.rewritten_helpers(), 1);
        assert_eq!(artifact.removed_call_arguments(), 1);
        assert!(
            artifact
                .text
                .contains("let rec __spiral_scc_owner term x =")
        );
        assert!(artifact.text.contains("__spiral_lift_poly 1 lookup"));
        assert!(artifact.text.contains("__spiral_scc_owner term x"));
        assert!(!artifact.text.contains("__spiral_scc_owner poly term x"));
    }

    #[test]
    fn relinks_ordinary_monomorphic_capture() {
        let source = r#"    let __spiral_lift_worker state normalize item =
        normalize item

    let __spiral_lift_normalize item =
        item

    let owner item =
        __spiral_lift_worker state __spiral_lift_normalize item
"#;
        let artifact =
            relink_promoted_captures(source, &[promotion("normalize", "__spiral_lift_normalize")])
                .expect("monomorphic relink");
        assert_eq!(artifact.rewritten_helpers(), 1);
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_worker state item =")
        );
        assert!(artifact.text.contains("__spiral_lift_normalize item"));
        assert!(artifact.text.contains("__spiral_lift_worker state item"));
    }

    #[test]
    fn ignores_generated_helper_parameter_that_only_shadows_promotion() {
        let source = r#"    let __spiral_lift_context spawn recursion =
        spawn.contextRef, recursion

    let __spiral_lift_spawn item = item

    let owner spawnContext recursion =
        __spiral_lift_context spawnContext recursion
"#;
        let artifact =
            relink_promoted_captures(source, &[promotion("spawn", "__spiral_lift_spawn")])
                .expect("shadowing helper parameter is not a promoted capture");
        assert!(artifact.helpers.is_empty());
        assert_eq!(artifact.text, source);
    }

    #[test]
    fn ignores_non_generated_bindings() {
        let source = "    let ordinary poly x = poly x\n    let __spiral_lift_poly x = x\n";
        let artifact = relink_promoted_captures(source, &[promotion("poly", "__spiral_lift_poly")])
            .expect("no relink needed");
        assert!(artifact.helpers.is_empty());
        assert_eq!(artifact.text, source);
    }

    #[test]
    fn relinks_parameterized_polymorphic_capture_through_recursive_scc() {
        let source = r#"    let rec __spiral_scc_owner env state depth bridge term_depth poly term =
        let data = poly 1 lookup_data (fun continuation -> continuation.state)
        let fields = poly 2 lookup_fields (fun continuation -> continuation.fields)
        data, fields
    and owner state depth bridge term_depth term =
        __spiral_scc_owner env state depth bridge term_depth (__spiral_lift_poly state depth bridge term_depth) term

    let __spiral_lift_poly state depth bridge term_depth job lookup run =
        run continuation
"#;
        let artifact = relink_promoted_captures(
            source,
            &[Promotion::new(
                "poly",
                "__spiral_lift_poly",
                vec![
                    "state".to_owned(),
                    "depth".to_owned(),
                    "bridge".to_owned(),
                    "term_depth".to_owned(),
                ],
            )],
        )
        .expect("parameterized recursive SCC relink");
        assert_eq!(artifact.rewritten_helpers(), 1);
        assert_eq!(artifact.rewritten_body_calls(), 2);
        assert_eq!(artifact.removed_call_arguments(), 1);
        assert!(
            artifact
                .text
                .contains("let rec __spiral_scc_owner env state depth bridge term_depth term =")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_poly state depth bridge term_depth) 1 lookup_data")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_poly state depth bridge term_depth) 2 lookup_fields")
        );
        assert!(
            artifact
                .text
                .contains("__spiral_scc_owner env state depth bridge term_depth term")
        );
        assert!(
            !artifact
                .text
                .contains("__spiral_scc_owner env (__spiral_lift_poly")
        );
    }

    #[test]
    fn relinks_parameterized_capture_from_bare_terminal_argument() {
        let source = r#"    let __spiral_lift_terminal state depth poly term =
        poly term

    let __spiral_lift_poly state depth job = job

    let owner state depth poly term =
        (__spiral_lift_terminal state depth poly) term
"#;
        let artifact = relink_promoted_captures(
            source,
            &[Promotion::new(
                "poly",
                "__spiral_lift_poly",
                vec!["state".to_owned(), "depth".to_owned()],
            )],
        )
        .expect("parameterized terminal capture relink");
        assert_eq!(artifact.rewritten_helpers(), 1);
        assert_eq!(artifact.rewritten_body_calls(), 1);
        assert_eq!(artifact.removed_call_arguments(), 1);
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_terminal state depth term =")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_poly state depth) term")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_terminal state depth) term")
        );
    }

    #[test]
    fn threads_missing_parameter_before_relinking_generated_helper() {
        let source = r#"    let __spiral_lift_terminal state poly term =
        poly term

    let __spiral_lift_poly state depth job = job

    let owner state depth term =
        (__spiral_lift_terminal state poly) term
"#;
        let artifact = relink_promoted_captures(
            source,
            &[Promotion::new(
                "poly",
                "__spiral_lift_poly",
                vec!["state".to_owned(), "depth".to_owned()],
            )],
        )
        .expect("missing lexical state should be threaded before relinking");
        assert_eq!(artifact.threaded_parameters(), 1);
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_terminal state depth term =")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_poly state depth) term")
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_terminal state depth) term")
        );
    }

    #[test]
    fn annotates_promoted_helper_capture_even_when_threading_is_not_needed() {
        let source = r#"    let __spiral_lift_preview cache x =
        cache.TryGetValue x

    let __spiral_lift_worker cache preview x =
        preview x

    let cache = System.Collections.Concurrent.ConcurrentDictionary<int, string>()

    let owner x =
        __spiral_lift_worker cache (__spiral_lift_preview cache) x
"#;
        let artifact = relink_promoted_captures(
            source,
            &[Promotion::new(
                "preview",
                "__spiral_lift_preview",
                vec!["cache".to_owned()],
            )],
        )
        .expect("unique capture binding should annotate the promoted helper");
        assert!(artifact.text.contains(
            "let __spiral_lift_preview (cache: System.Collections.Concurrent.ConcurrentDictionary<int, string>) x ="
        ));
    }

    #[test]
    fn removes_annotated_function_capture_group_after_threading() {
        let source = r#"    let __spiral_lift_worker state (ids placeholders predicate: (Ty) -> (Ty) -> bool) ty x =
        predicate ty ty

    let __spiral_lift_predicate ids placeholders left right =
        true

    let owner state ids placeholders ty x =
        __spiral_lift_worker state (__spiral_lift_predicate ids placeholders) ty x
"#;
        let artifact = relink_promoted_captures(
            source,
            &[Promotion::new(
                "predicate",
                "__spiral_lift_predicate",
                vec!["ids".to_owned(), "placeholders".to_owned()],
            )],
        )
        .expect("annotated function capture should remove only the promoted predicate");
        assert!(
            artifact
                .text
                .contains("let __spiral_lift_worker state ids placeholders ty x ="),
            "{}",
            artifact.text
        );
        assert!(
            artifact
                .text
                .contains("(__spiral_lift_predicate ids placeholders) ty ty")
        );
        assert!(artifact.text.contains("__spiral_lift_worker state ty x"));
        assert!(!artifact.text.contains("predicate: (Ty) -> (Ty) -> bool"));
    }

    #[test]
    fn rejects_parameterized_capture_when_partial_application_does_not_match() {
        let source = r#"    let rec __spiral_scc_owner state depth poly term =
        poly term
    and owner state depth term =
        __spiral_scc_owner state depth (__spiral_lift_poly state wrong) term

    let __spiral_lift_poly state depth term = term
"#;
        let error = relink_promoted_captures(
            source,
            &[Promotion::new(
                "poly",
                "__spiral_lift_poly",
                vec!["state".to_owned(), "depth".to_owned()],
            )],
        )
        .expect_err("mismatched partial application must fail closed");
        assert!(matches!(
            error,
            RelinkBlocker::AmbiguousHelperCall { helper, .. }
                if helper == "__spiral_scc_owner"
        ));
    }

    #[test]
    fn rejects_parameterized_capture_when_helper_lacks_required_parameter() {
        let source = r#"    let __spiral_lift_terminal state poly term =
        poly term

    let __spiral_lift_poly state depth job = job

    let owner state poly term =
        (__spiral_lift_terminal state poly) term
"#;
        let error = relink_promoted_captures(
            source,
            &[Promotion::new(
                "poly",
                "__spiral_lift_poly",
                vec!["state".to_owned(), "depth".to_owned()],
            )],
        )
        .expect_err("missing captured parameter must fail closed");
        assert!(matches!(
            error,
            RelinkBlocker::Thread {
                helper,
                promotion,
                source: ThreadBlocker::ParameterUnavailable { parameter, .. },
            } if helper == "__spiral_lift_terminal"
                && promotion == "poly"
                && parameter == "depth"
        ));
    }
}
