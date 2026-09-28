use std::collections::BTreeSet;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum BindingRole {
    Function,
    Value,
    DestructuredValue,
    ActivePattern,
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum BindingOrigin {
    Let,
    RecursiveContinuation,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BindingHeader {
    pub name: String,
    pub origin: BindingOrigin,
    pub bound_names: BTreeSet<String>,
    pub capturable_names: BTreeSet<String>,
    pub parameters: BTreeSet<String>,
    pub role: BindingRole,
    pub mutable: bool,
    pub inline: bool,
}

fn identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

#[must_use]
pub fn identifiers(text: &str) -> Vec<String> {
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
        if current == '\'' && next.is_some_and(|value| value != '\n') {
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

#[must_use]
pub fn keyword(value: &str) -> bool {
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
            | "return!"
            | "static"
            | "struct"
            | "then"
            | "true"
            | "try"
            | "type"
            | "use"
            | "use!"
            | "val"
            | "when"
            | "while"
            | "with"
            | "yield"
            | "yield!"
    )
}

#[must_use]
pub fn binding_body(line: &str) -> Option<(&str, bool)> {
    let trimmed = line.trim_start();
    let (mut body, continuation) = if let Some(body) = trimmed.strip_prefix("let ") {
        (body, false)
    } else {
        let body = trimmed.strip_prefix("and ")?;
        (body, true)
    };
    loop {
        let before = body;
        for modifier in ["rec ", "private ", "internal ", "public ", "inline "] {
            if let Some(rest) = body.strip_prefix(modifier) {
                body = rest;
                break;
            }
        }
        if body == before {
            break;
        }
    }
    Some((body, continuation))
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum ParameterScan {
    Pattern,
    TypeAnnotation {
        pattern_depth: usize,
        nested_depth: usize,
        angle_depth: usize,
    },
}

fn parameter_pattern_text(text: &str) -> String {
    let chars = text.chars().collect::<Vec<_>>();
    let mut output = String::with_capacity(text.len());
    let mut index = 0usize;
    let mut depth = 0usize;
    let mut state = ParameterScan::Pattern;
    while index < chars.len() {
        let current = chars[index];
        let previous = index
            .checked_sub(1)
            .and_then(|position| chars.get(position))
            .copied();
        let next = chars.get(index + 1).copied();
        state = match state {
            ParameterScan::Pattern => {
                if current == ':' && previous != Some(':') && next != Some(':') {
                    if depth == 0 {
                        break;
                    }
                    ParameterScan::TypeAnnotation {
                        pattern_depth: depth,
                        nested_depth: 0,
                        angle_depth: 0,
                    }
                } else {
                    match current {
                        '(' | '[' | '{' => depth += 1,
                        ')' | ']' | '}' => depth = depth.saturating_sub(1),
                        _ => {}
                    }
                    output.push(current);
                    ParameterScan::Pattern
                }
            }
            ParameterScan::TypeAnnotation {
                pattern_depth,
                mut nested_depth,
                mut angle_depth,
            } => match current {
                '<' => {
                    angle_depth += 1;
                    ParameterScan::TypeAnnotation {
                        pattern_depth,
                        nested_depth,
                        angle_depth,
                    }
                }
                '>' => {
                    angle_depth = angle_depth.saturating_sub(1);
                    ParameterScan::TypeAnnotation {
                        pattern_depth,
                        nested_depth,
                        angle_depth,
                    }
                }
                '(' | '[' | '{' => {
                    nested_depth += 1;
                    ParameterScan::TypeAnnotation {
                        pattern_depth,
                        nested_depth,
                        angle_depth,
                    }
                }
                ')' | ']' | '}' if nested_depth > 0 => {
                    nested_depth -= 1;
                    ParameterScan::TypeAnnotation {
                        pattern_depth,
                        nested_depth,
                        angle_depth,
                    }
                }
                ')' | ']' | '}' if angle_depth == 0 && depth == pattern_depth => {
                    depth = depth.saturating_sub(1);
                    output.push(current);
                    ParameterScan::Pattern
                }
                ',' if nested_depth == 0 && angle_depth == 0 && depth == pattern_depth => {
                    output.push(current);
                    ParameterScan::Pattern
                }
                _ => ParameterScan::TypeAnnotation {
                    pattern_depth,
                    nested_depth,
                    angle_depth,
                },
            },
        };
        index += 1;
    }
    output
}

fn parameter_names(text: &str) -> BTreeSet<String> {
    identifiers(&parameter_pattern_text(text))
        .into_iter()
        .filter(|token| !keyword(token))
        .collect()
}

fn active_pattern_names(before_equals: &str) -> Option<(BTreeSet<String>, &str)> {
    let body = before_equals.trim_start().strip_prefix("(|")?;
    let (cases, rest) = body.split_once("|)")?;
    let names = cases
        .split('|')
        .filter_map(|case| {
            let case = case.trim();
            let tokens = identifiers(case);
            (case != "_" && tokens.len() == 1 && tokens[0] == case).then(|| case.to_owned())
        })
        .collect::<BTreeSet<_>>();
    (!names.is_empty()).then_some((names, rest))
}

fn destructured_value_names(before_equals: &str) -> Option<BTreeSet<String>> {
    let body = before_equals
        .trim()
        .strip_prefix('(')
        .and_then(|value| value.strip_suffix(')'))
        .unwrap_or_else(|| before_equals.trim());
    if !body.contains(',') {
        return None;
    }
    let mut names = BTreeSet::new();
    for part in body.split(',') {
        let part = part.trim();
        let tokens = identifiers(part);
        if tokens.len() != 1 || tokens[0] != part || keyword(part) {
            return None;
        }
        names.insert(part.to_owned());
    }
    (names.len() > 1).then_some(names)
}

#[must_use]
pub fn binding_header(line: &str) -> Option<BindingHeader> {
    let trimmed = line.trim_start();
    let mutable = trimmed.starts_with("let mutable ") || trimmed.starts_with("and mutable ");
    let inline = trimmed.contains("let inline ")
        || trimmed.contains("let private inline ")
        || trimmed.contains("let inline private ")
        || trimmed.contains("and inline ");
    let (body, continuation) = binding_body(line)?;
    let origin = if continuation {
        BindingOrigin::RecursiveContinuation
    } else {
        BindingOrigin::Let
    };
    let before_equals = body
        .split_once('=')
        .map_or(body, |(header, _)| header)
        .trim();

    if let Some((bound_names, rest)) = active_pattern_names(before_equals) {
        let name = bound_names.iter().next()?.clone();
        let parameters = parameter_names(rest);
        return Some(BindingHeader {
            name,
            bound_names,
            capturable_names: BTreeSet::new(),
            parameters,
            role: BindingRole::ActivePattern,
            origin,
            mutable,
            inline,
        });
    }

    if let Some(bound_names) = destructured_value_names(before_equals) {
        let name = bound_names.iter().next()?.clone();
        return Some(BindingHeader {
            name,
            capturable_names: bound_names.clone(),
            bound_names,
            parameters: BTreeSet::new(),
            role: BindingRole::DestructuredValue,
            origin,
            mutable,
            inline,
        });
    }

    let name = identifiers(before_equals)
        .into_iter()
        .find(|token| !keyword(token))?;
    let after_name = before_equals
        .strip_prefix(&name)
        .unwrap_or_default()
        .trim_start();
    let typed_value = after_name.starts_with(':');
    let function = !after_name.is_empty() && !typed_value;
    let parameters = parameter_names(after_name);
    let bound_names = BTreeSet::from([name.clone()]);
    Some(BindingHeader {
        name,
        capturable_names: bound_names.clone(),
        bound_names,
        parameters,
        role: if function {
            BindingRole::Function
        } else {
            BindingRole::Value
        },
        origin,
        mutable,
        inline,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn active_pattern_cases_are_symbols_not_capturable_values() {
        let header =
            binding_header("        let (|JpIvarReady|JpIvarPending|) (ivar:Hopac.IVar<'a>) =")
                .expect("active pattern header");
        assert_eq!(header.role, BindingRole::ActivePattern);
        assert_eq!(
            header.bound_names,
            BTreeSet::from(["JpIvarPending".to_owned(), "JpIvarReady".to_owned()])
        );
        assert!(header.capturable_names.is_empty());
        assert!(header.parameters.contains("ivar"));
    }

    #[test]
    fn tuple_binder_values_remain_capturable() {
        let header = binding_header("        let nextEvalNodePath, reCount = state, node")
            .expect("tuple header");
        assert_eq!(header.role, BindingRole::DestructuredValue);
        assert_eq!(header.bound_names, header.capturable_names);
        assert_eq!(header.bound_names.len(), 2);
    }

    #[test]
    fn typed_function_header_only_exposes_value_binders() {
        let header = binding_header("        and term_core (s : LangEnv) (x:E) : Data =")
            .expect("typed function header");
        assert_eq!(header.role, BindingRole::Function);
        assert_eq!(header.origin, BindingOrigin::RecursiveContinuation);
        assert_eq!(
            header.parameters,
            BTreeSet::from(["s".to_owned(), "x".to_owned()])
        );
    }

    #[test]
    fn active_pattern_type_annotation_is_not_a_parameter() {
        let header =
            binding_header("        let (|JpIvarReady|JpIvarPending|) (ivar:Hopac.IVar<'a>) =")
                .expect("active pattern header");
        assert_eq!(header.parameters, BTreeSet::from(["ivar".to_owned()]));
    }

    #[test]
    fn regular_function_and_value_are_distinct() {
        let function = binding_header("        let helper x = x + 1").expect("function");
        let value = binding_header("        let counter : int = 0").expect("value");
        assert_eq!(function.role, BindingRole::Function);
        assert_eq!(function.origin, BindingOrigin::Let);
        assert_eq!(value.role, BindingRole::Value);
        assert_eq!(value.origin, BindingOrigin::Let);
    }
}
