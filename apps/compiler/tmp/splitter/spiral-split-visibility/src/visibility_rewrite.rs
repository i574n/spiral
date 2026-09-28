#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
enum RepresentationState {
    #[default]
    Outside,
    AwaitingVisibility,
}

fn top_level_type_header(line: &str) -> bool {
    let trimmed = line.trim_start();
    let indent = line.len() - trimmed.len();
    indent == 4
        && (trimmed.starts_with("type ") || trimmed.starts_with("and "))
        && trimmed.trim_end().ends_with('=')
}

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct DisposableVisibility {
    state: RepresentationState,
}

impl DisposableVisibility {
    pub fn promote_line<'a>(&mut self, line: &'a str) -> Option<&'a str> {
        if top_level_type_header(line) {
            self.state = RepresentationState::AwaitingVisibility;
            return Some(line);
        }
        if self.state == RepresentationState::AwaitingVisibility {
            let trimmed = line.trim();
            if trimmed.is_empty() {
                return Some(line);
            }
            self.state = RepresentationState::Outside;
            if trimmed == "private" {
                return None;
            }
        }
        Some(line)
    }
}

/// Widen only a generated shard's multiline private type representation.
///
/// The authoritative monolith remains unchanged. This transformation mirrors
/// the existing promotion of `type T = private ...`, but also handles the F#
/// layout form where `private` occupies the next indented line.
pub fn promote_multiline_private_representations(text: &str) -> String {
    let mut state = RepresentationState::Outside;
    let mut lines = Vec::new();
    for line in text.lines() {
        if top_level_type_header(line) {
            state = RepresentationState::AwaitingVisibility;
            lines.push(line.to_owned());
            continue;
        }
        if state == RepresentationState::AwaitingVisibility {
            let trimmed = line.trim();
            if trimmed.is_empty() {
                lines.push(line.to_owned());
                continue;
            }
            state = RepresentationState::Outside;
            if trimmed == "private" {
                continue;
            }
            if let Some(representation) = trimmed.strip_prefix("private ") {
                let indentation = line.len() - line.trim_start().len();
                lines.push(format!("{}{}", &line[..indentation], representation));
                continue;
            }
        }
        lines.push(line.to_owned());
    }
    let mut output = lines.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        output.push('\n');
    }
    output
}

/// Widen a generated shard's single-line private type representation.
///
/// F# also permits `type T = private { ... }` and
/// `type T = private | Case ...`. The monolith keeps that privacy; only the
/// disposable cross-assembly copy exposes the representation needed by later
/// shards.
pub fn promote_single_line_private_representations(text: &str) -> String {
    let mut output = text
        .lines()
        .map(|line| {
            let trimmed = line.trim_start();
            let indent = line.len() - trimmed.len();
            if indent == 4
                && (trimmed.starts_with("type ") || trimmed.starts_with("and "))
                && trimmed.contains(" = private ")
            {
                line.replacen(" = private ", " = ", 1)
            } else {
                line.to_owned()
            }
        })
        .collect::<Vec<_>>()
        .join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        output.push('\n');
    }
    output
}

/// Preserve phantom state parameters that F# otherwise erases to `obj` when a
/// factory is compiled before its callers constrain the return type.
///
/// These are disposable source annotations only. They make the already-present
/// typestate relations explicit at the assembly boundary without changing the
/// authoritative monolith.
pub fn stabilize_operational_work_factories(text: &str) -> String {
    text.replace(
        "        let create<'Phase,'Kind> binding generation instantiation backend =",
        "        let create<'Phase,'Kind> binding generation instantiation backend : WorkUnitId<'Phase,'Kind> =",
    )
    .replace(
        "        let createQueued workUnit owner generation dependencyRefs siteId semanticCost commitOrdinal =",
        "        let createQueued<'CompilerPhase,'Kind,'Owner>\n            (workUnit:WorkUnitId<'CompilerPhase,'Kind>)\n            (owner:WorkOwnerCapability<'Owner>)\n            generation dependencyRefs siteId semanticCost commitOrdinal\n            : WorkItem<'CompilerPhase,'Kind,'Owner,WorkQueuedState> =",
    )
}

/// Preserve caller-driven numeric inference when a private formatting helper
/// becomes public only for disposable cross-assembly typechecking.
///
/// The decision is local to one top-level binding body. A numeric formatter in
/// a later sibling must not make an unrelated private helper inline: F# checks
/// every inline body for transitively accessible implementation details.
fn top_level_binding_boundary(line: &str) -> bool {
    let trimmed = line.trim_start();
    let indent = line.len() - trimmed.len();
    indent <= 4
        && (trimmed.starts_with("let ")
            || trimmed.starts_with("type ")
            || trimmed.starts_with("and ")
            || trimmed.starts_with("module ")
            || trimmed.starts_with("open ")
            || trimmed.starts_with("exception "))
}

fn private_binding_has_explicit_parameter(lines: &[String], index: usize, end: usize) -> bool {
    let mut header = String::new();
    for line in &lines[index..end] {
        if !header.is_empty() {
            header.push(' ');
        }
        header.push_str(line.trim());
        if line.contains('=') {
            break;
        }
    }
    let Some(tail) = header
        .strip_prefix("let private ")
        .or_else(|| header.strip_prefix("let "))
    else {
        return false;
    };
    if tail.starts_with("rec ") || tail.starts_with("inline ") {
        return false;
    }
    let Some((head, _)) = tail.split_once('=') else {
        return false;
    };
    let mut tokens = head.split_whitespace();
    let Some(_name) = tokens.next() else {
        return false;
    };
    tokens
        .next()
        .is_some_and(|parameter| !parameter.starts_with(':'))
}

fn numeric_formatting_body(body: &str) -> bool {
    let numeric_format = ["%u", "%d", "%i", "%x", "%X", "%o"]
        .into_iter()
        .any(|specifier| body.contains(specifier));
    let formatting_helper =
        body.contains("sprintf") || body.contains("printf") || body.contains("ksprintf");
    formatting_helper && numeric_format
}

fn next_top_level_boundaries(lines: &[String]) -> Vec<usize> {
    let mut next = lines.len();
    let mut result = vec![lines.len(); lines.len()];
    for index in (0..lines.len()).rev() {
        result[index] = next;
        if top_level_binding_boundary(&lines[index]) {
            next = index;
        }
    }
    result
}

pub fn preserve_private_numeric_format_inference(text: &str) -> String {
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    let boundaries = next_top_level_boundaries(&lines);
    let candidates = lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| line.starts_with("    let private ").then_some(index))
        .collect::<Vec<_>>();
    for index in candidates {
        let end = boundaries[index];
        if !private_binding_has_explicit_parameter(&lines, index, end) {
            continue;
        }
        let body = lines[index..end].join("\n");
        if numeric_formatting_body(&body) {
            lines[index] = lines[index].replacen("    let private ", "    let private inline ", 1);
        }
    }
    let mut output = lines.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        output.push('\n');
    }
    output
}

fn numeric_conversion_binding_needs_inline(lines: &[String], index: usize, end: usize) -> bool {
    let mut header = String::new();
    for line in &lines[index..end] {
        if !header.is_empty() {
            header.push(' ');
        }
        header.push_str(line.trim());
        if line.contains('=') {
            break;
        }
    }
    let Some(mut tail) = header.strip_prefix("let ") else {
        return false;
    };
    if let Some(private_tail) = tail.strip_prefix("private ") {
        tail = private_tail;
    }
    if tail.starts_with("rec ") || tail.starts_with("inline ") {
        return false;
    }
    let Some((head, _)) = tail.split_once('=') else {
        return false;
    };
    let mut tokens = head.split_whitespace();
    let Some(_name) = tokens.next() else {
        return false;
    };
    let parameters = tokens
        .filter(|token| !token.starts_with(':'))
        .map(|token| token.trim_matches(|character| character == '(' || character == ')'))
        .filter(|token| !token.is_empty())
        .collect::<Vec<_>>();
    if parameters.is_empty() {
        return false;
    }
    let body = lines[index..end].join("\n");
    parameters
        .iter()
        .any(|parameter| body.contains(&format!("int64 {parameter}")))
        && body.contains("0L")
}

/// Preserve caller-driven integer width when a helper converts selected
/// parameters with `int64` but leaves their public assembly signature inferred.
fn inline_binding_name(line: &str) -> Option<String> {
    let trimmed = line.trim_start();
    let tail = trimmed
        .strip_prefix("let private inline ")
        .or_else(|| trimmed.strip_prefix("let inline "))?;
    tail.split(|character: char| character.is_whitespace() || character == '=' || character == '(')
        .find(|token| !token.is_empty())
        .map(str::to_owned)
}

fn simple_numeric_wrapper_needs_inline(
    lines: &[String],
    index: usize,
    end: usize,
    inline_numeric_helpers: &std::collections::BTreeSet<String>,
) -> bool {
    let mut header = String::new();
    for line in &lines[index..end] {
        if !header.is_empty() {
            header.push(' ');
        }
        header.push_str(line.trim());
        if line.contains('=') {
            break;
        }
    }
    let Some(tail) = header
        .strip_prefix("let private ")
        .or_else(|| header.strip_prefix("let "))
    else {
        return false;
    };
    if tail.starts_with("rec ") || tail.starts_with("inline ") {
        return false;
    }
    let Some((head, _)) = tail.split_once('=') else {
        return false;
    };
    let mut tokens = head.split_whitespace();
    let Some(_name) = tokens.next() else {
        return false;
    };
    let parameters = tokens
        .filter(|token| !token.starts_with(':'))
        .map(|token| token.trim_matches(|character| character == '(' || character == ')'))
        .filter(|token| !token.is_empty())
        .collect::<Vec<_>>();
    if parameters.is_empty() {
        return false;
    }
    let body = lines[index..end].join("\n");
    if body.len() > 1200
        || body.lines().count() > 4
        || body.contains("\n        let ")
        || body.contains("\n        match ")
        || body.contains("\n        if ")
    {
        return false;
    }
    inline_numeric_helpers.iter().any(|helper| {
        parameters
            .iter()
            .any(|parameter| body.contains(&format!("{helper} {parameter}")))
    })
}

pub fn numeric_conversion_helper_names(text: &str) -> std::collections::BTreeSet<String> {
    let lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    let boundaries = next_top_level_boundaries(&lines);
    lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| {
            let end = boundaries[index];
            if !line.starts_with("    let ")
                || !numeric_conversion_binding_needs_inline(&lines, index, end)
            {
                return None;
            }
            value_binding_head(line).map(|(_, name, _, _)| name)
        })
        .collect()
}

pub fn preserve_numeric_conversion_inference_with_helpers(
    text: &str,
    known_numeric_helpers: &std::collections::BTreeSet<String>,
) -> String {
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    let boundaries = next_top_level_boundaries(&lines);
    let candidates = lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| line.starts_with("    let ").then_some(index))
        .collect::<Vec<_>>();
    for &index in &candidates {
        let end = boundaries[index];
        if !numeric_conversion_binding_needs_inline(&lines, index, end) {
            continue;
        }
        if lines[index].starts_with("    let private ") {
            lines[index] = lines[index].replacen("    let private ", "    let private inline ", 1);
        } else {
            lines[index] = lines[index].replacen("    let ", "    let inline ", 1);
        }
    }

    loop {
        let mut inline_numeric_helpers = known_numeric_helpers.clone();
        inline_numeric_helpers.extend(lines.iter().filter_map(|line| inline_binding_name(line)));
        let mut changed = false;
        for &index in &candidates {
            let end = boundaries[index];
            if simple_numeric_wrapper_needs_inline(&lines, index, end, &inline_numeric_helpers) {
                let promoted = if lines[index].starts_with("    let private ") {
                    lines[index].replacen("    let private ", "    let private inline ", 1)
                } else {
                    lines[index].replacen("    let ", "    let inline ", 1)
                };
                if promoted != lines[index] {
                    lines[index] = promoted;
                    changed = true;
                }
            }
        }
        if !changed {
            break;
        }
    }

    let mut output = lines.join("\n");
    if text.as_bytes().last() == Some(&b'\n') {
        output.push('\n');
    }
    output
}

pub fn preserve_numeric_conversion_inference(text: &str) -> String {
    preserve_numeric_conversion_inference_with_helpers(text, &std::collections::BTreeSet::new())
}

fn identifier_mentioned(text: &str, name: &str) -> bool {
    text.match_indices(name).any(|(offset, _)| {
        let before = text[..offset].chars().next_back();
        let after = text[offset + name.len()..].chars().next();
        let identifier = |character: Option<char>| {
            character
                .is_some_and(|value| value.is_ascii_alphanumeric() || value == '_' || value == '\'')
        };
        !identifier(before) && !identifier(after)
    })
}

#[derive(Clone, Debug)]
struct ValueBinding {
    line: usize,
    end: usize,
    name: String,
    private: bool,
    inline: bool,
}

fn value_binding_head(line: &str) -> Option<(usize, String, bool, bool)> {
    let trimmed = line.trim_start();
    let indent = line.len() - trimmed.len();
    let tail = trimmed.strip_prefix("let ")?;
    let tokens = tail
        .split(|character: char| character.is_whitespace() || character == '=' || character == '(')
        .filter(|token| !token.is_empty())
        .collect::<Vec<_>>();
    let private = tokens.contains(&"private");
    let inline = tokens.contains(&"inline");
    let name = tokens.into_iter().find(|token| {
        !matches!(
            *token,
            "private" | "internal" | "inline" | "rec" | "mutable"
        )
    })?;
    let first = name.chars().next()?;
    if !(first.is_ascii_alphabetic() || first == '_') {
        return None;
    }
    Some((indent, name.to_owned(), private, inline))
}

fn binding_boundary_indent(line: &str) -> Option<usize> {
    let trimmed = line.trim_start();
    let indent = line.len() - trimmed.len();
    (trimmed.starts_with("let ")
        || trimmed.starts_with("type ")
        || trimmed.starts_with("and ")
        || trimmed.starts_with("module ")
        || trimmed.starts_with("open ")
        || trimmed.starts_with("exception "))
    .then_some(indent)
}

fn next_binding_boundaries(lines: &[String]) -> Vec<usize> {
    let maximum_indent = lines
        .iter()
        .map(|line| line.len() - line.trim_start().len())
        .max()
        .unwrap_or(0);
    let mut nearest_by_indent = vec![lines.len(); maximum_indent + 1];
    let mut result = vec![lines.len(); lines.len()];
    for index in (0..lines.len()).rev() {
        let indent = lines[index].len() - lines[index].trim_start().len();
        result[index] = nearest_by_indent[..=indent]
            .iter()
            .copied()
            .min()
            .unwrap_or(lines.len());
        if let Some(boundary_indent) = binding_boundary_indent(&lines[index]) {
            nearest_by_indent[boundary_indent] = index;
        }
    }
    result
}

fn value_bindings(lines: &[String]) -> Vec<ValueBinding> {
    let boundaries = next_binding_boundaries(lines);
    lines
        .iter()
        .enumerate()
        .filter_map(|(line, text)| {
            let (_indent, name, private, inline) = value_binding_head(text)?;
            Some(ValueBinding {
                line,
                end: boundaries[line],
                name,
                private,
                inline,
            })
        })
        .collect()
}

/// Widen only private value bindings required by public inline bodies.
///
/// Inline F# bodies are serialized into consumer assemblies. Any private value
/// they capture must therefore be accessible there. The generated shard may
/// expose that minimal transitive closure while the authoritative monolith
/// keeps its original visibility.
fn identifier_character(character: char) -> bool {
    character.is_ascii_alphanumeric() || character == '_' || character == '\''
}

fn referenced_private_bindings(
    body: &str,
    private_by_name: &std::collections::BTreeMap<&str, Vec<usize>>,
    complex_private: &[(usize, &str)],
) -> std::collections::BTreeSet<usize> {
    let mut result = std::collections::BTreeSet::new();
    let mut start = None;
    for (offset, character) in body
        .char_indices()
        .chain(std::iter::once((body.len(), ' ')))
    {
        if identifier_character(character) {
            start.get_or_insert(offset);
            continue;
        }
        if let Some(begin) = start.take()
            && let Some(bindings) = private_by_name.get(&body[begin..offset])
        {
            result.extend(bindings.iter().copied());
        }
    }
    for (binding, name) in complex_private {
        if identifier_mentioned(body, name) {
            result.insert(*binding);
        }
    }
    result
}

pub fn promote_inline_private_dependencies(text: &str) -> String {
    let mut lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
    let bindings = value_bindings(&lines);
    let mut private_by_name = std::collections::BTreeMap::<&str, Vec<usize>>::new();
    let mut complex_private = Vec::<(usize, &str)>::new();
    for (index, binding) in bindings
        .iter()
        .enumerate()
        .filter(|(_, binding)| binding.private)
    {
        if binding.name.chars().all(identifier_character) {
            private_by_name
                .entry(binding.name.as_str())
                .or_default()
                .push(index);
        } else {
            complex_private.push((index, binding.name.as_str()));
        }
    }
    let mut queue = std::collections::VecDeque::from_iter(
        bindings
            .iter()
            .enumerate()
            .filter_map(|(index, binding)| binding.inline.then_some(index)),
    );
    let mut scanned = std::collections::BTreeSet::<usize>::new();
    let mut required = std::collections::BTreeSet::<usize>::new();
    while let Some(binding_index) = queue.pop_front() {
        if !scanned.insert(binding_index) {
            continue;
        }
        let binding = &bindings[binding_index];
        let body = lines[binding.line..binding.end].join("\n");
        for dependency in referenced_private_bindings(&body, &private_by_name, &complex_private) {
            let dependency_line = bindings[dependency].line;
            if required.insert(dependency_line) {
                queue.push_back(dependency);
            }
        }
    }
    for line in required {
        lines[line] = lines[line].replacen("private ", "", 1);
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
    fn promotes_multiline_private_union_representation() {
        let input = "    type Ref<'Kind> =\n        private\n        | Ref of string\n";
        assert_eq!(
            promote_multiline_private_representations(input),
            "    type Ref<'Kind> =\n        | Ref of string\n"
        );
    }

    #[test]
    fn promotes_private_union_case_on_the_representation_line() {
        let input = "    type EvidenceSet =\n        private EvidenceSet of int * int list\n";
        assert_eq!(
            promote_multiline_private_representations(input),
            "    type EvidenceSet =\n        EvidenceSet of int * int list\n"
        );
    }

    #[test]
    fn promotes_multiline_private_record_representation() {
        let input = "    type Token =\n        private\n        { value : string }\n";
        assert_eq!(
            promote_multiline_private_representations(input),
            "    type Token =\n        { value : string }\n"
        );
    }

    #[test]
    fn promotes_single_line_private_record_and_union_representations() {
        let input = "    type Decision = private { rule : int }\n    and Choice = private | Left | Right\n        type Nested = private { value : int }\n";
        assert_eq!(
            promote_single_line_private_representations(input),
            "    type Decision = { rule : int }\n    and Choice = | Left | Right\n        type Nested = private { value : int }\n"
        );
    }

    #[test]
    fn preserves_nested_private_lines_and_non_type_declarations() {
        let input = "    let outer () =\n        private\n        1\n\n        type Nested =\n            private\n            | Nested\n";
        assert_eq!(promote_multiline_private_representations(input), input);
    }

    #[test]
    fn preserves_type_body_when_private_is_not_the_first_content_line() {
        let input =
            "    type Token =\n        // representation note\n        private\n        | Token\n";
        assert_eq!(promote_multiline_private_representations(input), input);
    }

    #[test]
    fn keeps_uint_format_helpers_caller_inferred_across_assemblies() {
        let input = "    let private fairnessRef a b =\n        sprintf \"%u:%u\" a b\n";
        assert_eq!(
            preserve_private_numeric_format_inference(input),
            "    let private inline fairnessRef a b =\n        sprintf \"%u:%u\" a b\n"
        );
    }

    #[test]
    fn keeps_multiline_numeric_helpers_caller_inferred() {
        let input = "    let private openForQap\n        reducerSequence\n        materialEpoch\n        =\n        sprintf \"%d:%d\" reducerSequence materialEpoch\n";
        assert_eq!(
            preserve_private_numeric_format_inference(input),
            "    let private inline openForQap\n        reducerSequence\n        materialEpoch\n        =\n        sprintf \"%d:%d\" reducerSequence materialEpoch\n"
        );
    }

    #[test]
    fn keeps_sibling_binding_inference_independent() {
        let input = "    let private capForName name =\n        classify name\n\n    let private fairnessRef a b =\n        sprintf \"%u:%u\" a b\n";
        assert_eq!(
            preserve_private_numeric_format_inference(input),
            "    let private capForName name =\n        classify name\n\n    let private inline fairnessRef a b =\n        sprintf \"%u:%u\" a b\n"
        );
    }

    #[test]
    fn leaves_string_only_private_format_helpers_unchanged() {
        let input = "    let private label value =\n        sprintf \"%s\" value\n";
        assert_eq!(preserve_private_numeric_format_inference(input), input);
    }

    #[test]
    fn leaves_recursive_numeric_helpers_unchanged() {
        let input = "    let rec private loop value =\n        sprintf \"%u\" value\n";
        assert_eq!(preserve_private_numeric_format_inference(input), input);
    }

    #[test]
    fn leaves_function_expression_bindings_unchanged() {
        let input =
            "    let private render = function\n        | Value value -> sprintf \"%u\" value\n";
        assert_eq!(preserve_private_numeric_format_inference(input), input);
    }

    #[test]
    fn keeps_int64_conversion_helpers_caller_inferred() {
        let input = "    let retryWaitPressureFor waitedMs stalledMs cappedMs =\n        if waitedMs < 0L then 0\n        elif waitedMs >= int64 cappedMs then 1\n        elif waitedMs > int64 stalledMs then 2\n        else 3\n";
        assert_eq!(
            preserve_numeric_conversion_inference(input),
            "    let inline retryWaitPressureFor waitedMs stalledMs cappedMs =\n        if waitedMs < 0L then 0\n        elif waitedMs >= int64 cappedMs then 1\n        elif waitedMs > int64 stalledMs then 2\n        else 3\n"
        );
    }

    #[test]
    fn propagates_numeric_width_through_simple_private_wrapper() {
        let input = "    let private bigStackJoinNodeCount value = max 0L (int64 value)\n\n    let private bigStackJoinProofAdvanceProductive prior evidence semanticFactCount consumedActivePairs waited =\n        BigStackJoinProductive(prior, evidence, bigStackJoinNodeCount semanticFactCount, bigStackJoinNodeCount consumedActivePairs, waited)\n";
        assert_eq!(
            preserve_numeric_conversion_inference(input),
            "    let private inline bigStackJoinNodeCount value = max 0L (int64 value)\n\n    let private inline bigStackJoinProofAdvanceProductive prior evidence semanticFactCount consumedActivePairs waited =\n        BigStackJoinProductive(prior, evidence, bigStackJoinNodeCount semanticFactCount, bigStackJoinNodeCount consumedActivePairs, waited)\n"
        );
    }

    #[test]
    fn propagates_numeric_width_through_public_simple_wrapper() {
        let input = "    let bigStackJoinNodeCount value = max 0L (int64 value)\n\n    let bigStackJoinProofAdvanceProductive prior evidence semanticFactCount consumedActivePairs waited =\n        BigStackJoinProductive(prior, evidence, bigStackJoinNodeCount semanticFactCount, bigStackJoinNodeCount consumedActivePairs, waited)\n";
        assert_eq!(
            preserve_numeric_conversion_inference(input),
            "    let inline bigStackJoinNodeCount value = max 0L (int64 value)\n\n    let inline bigStackJoinProofAdvanceProductive prior evidence semanticFactCount consumedActivePairs waited =\n        BigStackJoinProductive(prior, evidence, bigStackJoinNodeCount semanticFactCount, bigStackJoinNodeCount consumedActivePairs, waited)\n"
        );
    }

    #[test]
    fn propagates_known_numeric_helper_across_declarations() {
        let known = std::collections::BTreeSet::from(["bigStackJoinNodeCount".to_owned()]);
        let input = "    let bigStackJoinProofAdvanceProductive prior evidence semanticFactCount consumedActivePairs waited =\n        BigStackJoinProductive(prior, evidence, bigStackJoinNodeCount semanticFactCount, bigStackJoinNodeCount consumedActivePairs, waited)\n";
        assert_eq!(
            preserve_numeric_conversion_inference_with_helpers(input, &known),
            "    let inline bigStackJoinProofAdvanceProductive prior evidence semanticFactCount consumedActivePairs waited =\n        BigStackJoinProductive(prior, evidence, bigStackJoinNodeCount semanticFactCount, bigStackJoinNodeCount consumedActivePairs, waited)\n"
        );
    }

    #[test]
    fn leaves_large_numeric_wrapper_uninlined() {
        let input = "    let private count value = max 0L (int64 value)\n\n    let private wrapper value =\n        let one = count value\n        let two = one + 1L\n        let three = two + 1L\n        let four = three + 1L\n        four\n";
        assert!(preserve_numeric_conversion_inference(input).contains("let private wrapper value"));
    }

    #[test]
    fn leaves_conversion_helpers_without_long_authority_unchanged() {
        let input = "    let normalize value = int64 value\n";
        assert_eq!(preserve_numeric_conversion_inference(input), input);
    }

    #[test]
    fn promotes_private_values_captured_by_inline_bindings() {
        let input = "    module Guard =\n        let private cap = 5\n        let inline apply value = cap + value\n";
        assert_eq!(
            promote_inline_private_dependencies(input),
            "    module Guard =\n        let cap = 5\n        let inline apply value = cap + value\n"
        );
    }

    #[test]
    fn promotes_inline_private_dependencies_transitively() {
        let input = "    module Guard =\n        let private cap = 5\n        let private addCap value = cap + value\n        let inline apply value = addCap value\n";
        assert_eq!(
            promote_inline_private_dependencies(input),
            "    module Guard =\n        let cap = 5\n        let addCap value = cap + value\n        let inline apply value = addCap value\n"
        );
    }

    #[test]
    fn keeps_unreferenced_private_values_private() {
        let input = "    module Guard =\n        let private unused = 5\n        let inline apply value = value + 1\n";
        assert_eq!(promote_inline_private_dependencies(input), input);
    }

    #[test]
    fn promotes_large_private_dependency_chain_once() {
        let mut input = String::from("    module Guard =\n");
        input.push_str("        let private p0000 value = value + 1\n");
        for index in 1..512 {
            input.push_str(&format!(
                "        let private p{index:04} value = p{:04} value + 1\n",
                index - 1
            ));
        }
        input.push_str("        let inline apply value = p0511 value\n");
        let output = promote_inline_private_dependencies(&input);
        assert!(!output.contains("let private p"));
        assert!(output.contains("let inline apply value = p0511 value"));
    }
}
