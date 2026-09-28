use std::collections::BTreeSet;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum ForwardedReturnShape {
    TransparentIdentifier,
    ComputedControlFlow,
    Other,
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_ascii_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    identifier_start(character) || character.is_ascii_digit() || character == '\''
}

fn bare_identifier(text: &str) -> Option<&str> {
    let value = text.trim();
    (!value.is_empty()
        && value.chars().next().is_some_and(identifier_start)
        && value.chars().all(identifier_continue))
    .then_some(value)
}

fn binding_name(line: &str) -> Option<String> {
    let mut body = line
        .trim_start()
        .strip_prefix("let ")
        .or_else(|| line.trim_start().strip_prefix("and "))?
        .trim_start();
    loop {
        let before = body;
        for modifier in ["rec ", "private ", "internal ", "public ", "inline "] {
            if let Some(rest) = body.strip_prefix(modifier) {
                body = rest.trim_start();
                break;
            }
        }
        if body == before {
            break;
        }
    }
    let name = body
        .chars()
        .take_while(|character| identifier_continue(*character))
        .collect::<String>();
    (!name.is_empty() && name.chars().next().is_some_and(identifier_start)).then_some(name)
}

fn leading_spaces(line: &str) -> usize {
    line.len() - line.trim_start().len()
}

#[must_use]
pub fn forwarded_return_shape(lines: &[&str], header_index: usize) -> ForwardedReturnShape {
    let Some(header) = lines.get(header_index) else {
        return ForwardedReturnShape::Other;
    };
    let Some((_, inline_rhs)) = header.split_once('=') else {
        return ForwardedReturnShape::Other;
    };
    let inline_rhs = inline_rhs.trim();
    if inline_rhs.split_whitespace().next() != Some("function") {
        return ForwardedReturnShape::Other;
    }
    let indent = leading_spaces(header);
    let mut arrows = 0usize;
    for line in &lines[header_index + 1..] {
        if !line.trim().is_empty() && leading_spaces(line) <= indent {
            break;
        }
        let Some((_, rhs)) = line.split_once("->") else {
            continue;
        };
        arrows += 1;
        if bare_identifier(rhs).is_none() {
            return ForwardedReturnShape::ComputedControlFlow;
        }
    }
    if arrows > 0 {
        ForwardedReturnShape::TransparentIdentifier
    } else {
        ForwardedReturnShape::ComputedControlFlow
    }
}

#[must_use]
pub fn transparent_control_flow_return_names(text: &str) -> BTreeSet<String> {
    let lines = text.lines().collect::<Vec<_>>();
    lines
        .iter()
        .enumerate()
        .filter_map(|(index, line)| {
            let name = binding_name(line)?;
            (forwarded_return_shape(&lines, index) == ForwardedReturnShape::TransparentIdentifier)
                .then_some(name)
        })
        .collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn alternative_patterns_forwarding_the_payload_are_transparent() {
        let source = r#"let lookupValue = function
    | FromSnapshot(_, continuation)
    | FromLocator(_, continuation) -> continuation"#;
        assert_eq!(
            transparent_control_flow_return_names(source),
            BTreeSet::from(["lookupValue".to_owned()])
        );
    }

    #[test]
    fn computed_branch_result_is_not_transparent() {
        let source = r#"let choose = function
    | Left value -> transform value
    | Right value -> value"#;
        assert!(transparent_control_flow_return_names(source).is_empty());
    }

    #[test]
    fn ordinary_match_binding_is_not_a_transparent_function_forwarder() {
        let source = r#"let choose value =
    match value with
    | Some item -> item
    | None -> fallback"#;
        assert!(transparent_control_flow_return_names(source).is_empty());
    }
}
