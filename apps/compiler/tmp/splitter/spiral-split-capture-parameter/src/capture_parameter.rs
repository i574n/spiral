#[derive(Clone, Debug, Eq, PartialEq)]
pub enum CaptureParameter {
    Plain { name: String },
    Explicit { name: String, annotation: String },
    ConstructorInferred { name: String, annotation: String },
    StaticFactoryInferred { name: String, annotation: String },
    ObjectExpressionInferred { name: String, annotation: String },
}

#[derive(Clone, Debug, Eq, PartialEq)]
enum InferredBindingType {
    Constructor(String),
    StaticSelfFactory(String),
    ObjectExpression(String),
}

impl CaptureParameter {
    #[must_use]
    pub fn from_owner(owner_text: &str, name: &str) -> Self {
        if let Some(annotation) = explicit_binding_type(owner_text, name) {
            return Self::Explicit {
                name: name.to_owned(),
                annotation,
            };
        }
        if let Some(annotation) = explicit_function_binding_type(owner_text, name) {
            return Self::Explicit {
                name: name.to_owned(),
                annotation,
            };
        }
        match inferred_binding_type(owner_text, name) {
            Some(InferredBindingType::Constructor(annotation)) => Self::ConstructorInferred {
                name: name.to_owned(),
                annotation,
            },
            Some(InferredBindingType::StaticSelfFactory(annotation)) => {
                Self::StaticFactoryInferred {
                    name: name.to_owned(),
                    annotation,
                }
            }
            Some(InferredBindingType::ObjectExpression(annotation)) => {
                Self::ObjectExpressionInferred {
                    name: name.to_owned(),
                    annotation,
                }
            }
            None => Self::Plain {
                name: name.to_owned(),
            },
        }
    }

    #[must_use]
    pub fn annotation(&self) -> Option<&str> {
        match self {
            Self::Plain { .. } => None,
            Self::Explicit { annotation, .. }
            | Self::ConstructorInferred { annotation, .. }
            | Self::StaticFactoryInferred { annotation, .. }
            | Self::ObjectExpressionInferred { annotation, .. } => Some(annotation),
        }
    }

    #[must_use]
    pub fn render_definition(&self) -> String {
        match self {
            Self::Plain { name } => name.clone(),
            Self::Explicit { name, annotation }
            | Self::ConstructorInferred { name, annotation }
            | Self::StaticFactoryInferred { name, annotation }
            | Self::ObjectExpressionInferred { name, annotation } => {
                format!("({name}: {annotation})")
            }
        }
    }
}

#[must_use]
pub fn definition_parameters(owner_text: &str, names: &[String]) -> Vec<String> {
    definition_parameters_before(owner_text, names, owner_text.lines().count())
}

#[must_use]
pub fn unique_definition_parameter(owner_text: &str, name: &str) -> Option<String> {
    let bindings = owner_text
        .lines()
        .filter(|line| binding_tail(line, name).is_some())
        .count();
    if bindings != 1 {
        return None;
    }
    let rendered = CaptureParameter::from_owner(owner_text, name).render_definition();
    (rendered != name).then_some(rendered)
}

#[must_use]
pub fn definition_parameters_before(
    owner_text: &str,
    names: &[String],
    before_line: usize,
) -> Vec<String> {
    let visible_prefix = owner_text
        .lines()
        .take(before_line)
        .collect::<Vec<_>>()
        .join("\n");
    names
        .iter()
        .map(|name| {
            if let Some(annotation) =
                explicit_enclosing_parameter_type(owner_text, name, before_line)
            {
                CaptureParameter::Explicit {
                    name: name.clone(),
                    annotation,
                }
                .render_definition()
            } else if let Some(annotation) =
                recursive_group_parameter_type(owner_text, name, before_line)
            {
                CaptureParameter::Explicit {
                    name: name.clone(),
                    annotation,
                }
                .render_definition()
            } else {
                CaptureParameter::from_owner(&visible_prefix, name).render_definition()
            }
        })
        .collect()
}

fn binding_tail<'a>(line: &'a str, name: &str) -> Option<&'a str> {
    let mut binding = line.trim_start().strip_prefix("let ")?;
    if let Some(rest) = binding.strip_prefix("mutable ") {
        binding = rest;
    }
    let rest = binding.strip_prefix(name)?;
    if rest
        .as_bytes()
        .first()
        .is_some_and(|byte| !matches!(byte, b' ' | b'\t' | b':' | b'='))
    {
        return None;
    }
    Some(rest.trim_start())
}

fn explicit_binding_type(owner_text: &str, name: &str) -> Option<String> {
    owner_text.lines().find_map(|line| {
        let rest = binding_tail(line, name)?.strip_prefix(':')?.trim_start();
        let equals = rest.find(" =")?;
        let annotation = rest[..equals].trim();
        (!annotation.is_empty()).then(|| annotation.to_owned())
    })
}

fn function_binding_tail<'a>(line: &'a str, name: &str) -> Option<&'a str> {
    let trimmed = line.trim_start();
    let mut binding = if let Some(rest) = trimmed.strip_prefix("let ") {
        rest
    } else {
        trimmed.strip_prefix("and ")?
    };
    if let Some(rest) = binding.strip_prefix("rec ") {
        binding = rest;
    }
    let rest = binding.strip_prefix(name)?;
    if rest
        .as_bytes()
        .first()
        .is_some_and(|byte| !matches!(byte, b' ' | b'\t' | b'('))
    {
        return None;
    }
    Some(rest.trim_start())
}

fn explicit_function_binding_type(owner_text: &str, name: &str) -> Option<String> {
    owner_text.lines().find_map(|line| {
        let mut rest = function_binding_tail(line, name)?;
        if !rest.starts_with('(') {
            return None;
        }
        let mut parameters = Vec::<String>::new();
        while rest.starts_with('(') {
            let close = matching_parenthesis(rest, 0)?;
            let inside = rest[1..close].trim();
            let (_, annotation) = inside.split_once(':')?;
            let annotation = annotation.trim();
            if annotation.is_empty() {
                return None;
            }
            parameters.push(annotation.to_owned());
            rest = rest[close + 1..].trim_start();
        }
        if parameters.is_empty() {
            return None;
        }
        let return_tail = rest.strip_prefix(':')?.trim_start();
        let equals = return_tail.find(" =")?;
        let return_annotation = return_tail[..equals].trim();
        if return_annotation.is_empty() {
            return None;
        }
        let mut signature = parameters
            .into_iter()
            .map(|annotation| format!("({annotation})"))
            .collect::<Vec<_>>();
        signature.push(return_annotation.to_owned());
        Some(namespace_function_type_variables(
            &signature.join(" -> "),
            name,
        ))
    })
}

fn namespace_function_type_variables(annotation: &str, name: &str) -> String {
    let namespace = name
        .chars()
        .map(|ch| {
            if ch.is_ascii_alphanumeric() || ch == '_' {
                ch
            } else {
                '_'
            }
        })
        .collect::<String>();
    let mut output = String::with_capacity(annotation.len() + namespace.len());
    let mut chars = annotation.chars().peekable();
    while let Some(ch) = chars.next() {
        if ch == '\''
            && chars
                .peek()
                .is_some_and(|next| next.is_ascii_alphabetic() || *next == '_')
        {
            output.push('\'');
            output.push_str(&namespace);
            output.push('_');
            while chars
                .peek()
                .is_some_and(|next| next.is_ascii_alphanumeric() || *next == '_')
            {
                output.push(chars.next().expect("peeked type variable character"));
            }
        } else {
            output.push(ch);
        }
    }
    output
}

fn matching_parenthesis(text: &str, open: usize) -> Option<usize> {
    let bytes = text.as_bytes();
    let mut depth = 0usize;
    for (offset, byte) in bytes[open..].iter().enumerate() {
        match byte {
            b'(' => depth += 1,
            b')' => {
                depth = depth.saturating_sub(1);
                if depth == 0 {
                    return Some(open + offset);
                }
            }
            _ => {}
        }
    }
    None
}

fn typed_parameter_annotation(header: &str, name: &str) -> Option<String> {
    let before_equals = header.split_once('=').map_or(header, |(left, _)| left);
    let bytes = before_equals.as_bytes();
    let mut cursor = 0usize;
    while cursor < bytes.len() {
        if bytes[cursor] != b'(' {
            cursor += 1;
            continue;
        }
        let close = matching_parenthesis(before_equals, cursor)?;
        let inside = before_equals[cursor + 1..close].trim();
        if let Some((left, right)) = inside.split_once(':') {
            let binder = left.trim().strip_prefix('~').unwrap_or(left.trim()).trim();
            let annotation = right.trim();
            if binder == name && !annotation.is_empty() {
                return Some(annotation.to_owned());
            }
        }
        cursor = close + 1;
    }
    None
}

fn leading_indent(line: &str) -> usize {
    line.as_bytes()
        .iter()
        .take_while(|byte| matches!(byte, b' ' | b'\t'))
        .map(|byte| if *byte == b'\t' { 4 } else { 1 })
        .sum()
}

fn binding_header(lines: &[&str], start: usize, before_line: usize) -> String {
    let mut header = lines[start].trim_start().to_owned();
    let mut index = start;
    while !header.contains('=') && index + 1 < before_line {
        index += 1;
        header.push(' ');
        header.push_str(lines[index].trim());
    }
    header
}

fn explicit_enclosing_parameter_type(
    owner_text: &str,
    name: &str,
    before_line: usize,
) -> Option<String> {
    let lines = owner_text.lines().collect::<Vec<_>>();
    let local_indent = lines
        .get(before_line)
        .map_or(usize::MAX, |line| leading_indent(line));
    let mut parent_indent = local_indent;
    let mut cursor = before_line.min(lines.len());
    while cursor > 0 {
        cursor -= 1;
        let line = lines[cursor];
        let trimmed = line.trim_start();
        if !(trimmed.starts_with("let ") || trimmed.starts_with("and ")) {
            continue;
        }
        let indent = leading_indent(line);
        if indent >= parent_indent {
            continue;
        }
        let header = binding_header(&lines, cursor, before_line.min(lines.len()));
        if let Some(annotation) = typed_parameter_annotation(&header, name) {
            return Some(annotation);
        }
        parent_indent = indent;
        if parent_indent == 0 {
            break;
        }
    }
    None
}

#[must_use]
pub fn recursive_group_parameter_type(
    owner_text: &str,
    name: &str,
    before_line: usize,
) -> Option<String> {
    let lines = owner_text.lines().collect::<Vec<_>>();
    let start = *lines.get(before_line)?;
    let start_trimmed = start.trim_start();
    if !(start_trimmed.starts_with("let rec ") || start_trimmed.starts_with("and ")) {
        return None;
    }
    let group_indent = leading_indent(start);
    let mut annotation: Option<String> = None;
    let mut witnesses = 0usize;
    let mut cursor = before_line;
    while cursor < lines.len() {
        let line = lines[cursor];
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") {
            cursor += 1;
            continue;
        }
        let indent = leading_indent(line);
        if indent < group_indent {
            break;
        }
        if indent == group_indent {
            let member = if cursor == before_line {
                trimmed.starts_with("let rec ") || trimmed.starts_with("and ")
            } else {
                trimmed.starts_with("and ")
            };
            if !member {
                if trimmed.starts_with("let ")
                    || trimmed.starts_with("type ")
                    || trimmed.starts_with("module ")
                    || trimmed.starts_with("namespace ")
                    || trimmed.starts_with("open ")
                {
                    break;
                }
                cursor += 1;
                continue;
            }
            let member_tail = trimmed
                .strip_prefix("let rec ")
                .or_else(|| trimmed.strip_prefix("and "))
                .unwrap_or_default();
            if member_tail.strip_prefix(name).is_some_and(|rest| {
                rest.is_empty()
                    || rest
                        .as_bytes()
                        .first()
                        .is_some_and(|byte| matches!(byte, b' ' | b'\t' | b'(' | b':'))
            }) {
                return None;
            }
            let header = binding_header(&lines, cursor, lines.len());
            if let Some(candidate) = typed_parameter_annotation(&header, name) {
                match &annotation {
                    Some(existing) if existing != &candidate => return None,
                    Some(_) => witnesses += 1,
                    None => {
                        annotation = Some(candidate);
                        witnesses = 1;
                    }
                }
            }
        }
        cursor += 1;
    }
    (witnesses >= 2)
        .then_some(annotation)
        .flatten()
        .filter(|value| value.trim().chars().count() > 1)
}

fn inferred_binding_type(owner_text: &str, name: &str) -> Option<InferredBindingType> {
    let lines = owner_text.lines().collect::<Vec<_>>();
    lines.iter().enumerate().find_map(|(index, line)| {
        let rest = binding_tail(line, name)?;
        if rest.starts_with(':') {
            return None;
        }
        let expression = rest.strip_prefix('=')?.trim();
        if !expression.is_empty() {
            return inferred_binding_from_expression(expression);
        }
        let binding_indent = line.len() - line.trim_start().len();
        let continuation = lines.get(index + 1)?;
        let continuation_indent = continuation.len() - continuation.trim_start().len();
        (continuation_indent > binding_indent)
            .then(|| continuation.trim())
            .and_then(inferred_binding_from_expression)
    })
}

fn inferred_binding_from_expression(expression: &str) -> Option<InferredBindingType> {
    let expression = expression.trim();
    if let Some(rest) = expression.strip_prefix("{ new ")
        && let Some((annotation, _)) = rest.split_once(" with")
    {
        let annotation = annotation.trim();
        if !annotation.is_empty() {
            return Some(InferredBindingType::ObjectExpression(annotation.to_owned()));
        }
    }
    if let Some(rest) = expression.strip_prefix("lazy")
        && (rest.is_empty()
            || rest.starts_with('(')
            || rest.chars().next().is_some_and(char::is_whitespace))
    {
        return Some(InferredBindingType::Constructor("Lazy<_>".to_owned()));
    }
    let zero_argument_constructor = expression.strip_suffix("()").map(str::trim);
    if let Some(constructor) = zero_argument_constructor
        && let Some(owner_type) = constructor.strip_suffix(".StartNew")
    {
        let owner_leaf = owner_type.rsplit('.').next()?;
        if owner_leaf.chars().next().is_some_and(char::is_uppercase) {
            return Some(InferredBindingType::StaticSelfFactory(
                owner_type.to_owned(),
            ));
        }
    }
    let constructor = if let Some(constructor) = zero_argument_constructor {
        constructor
    } else {
        let open = expression.find('(')?;
        let constructor = expression[..open].trim();
        if !expression.ends_with(')') || !constructor.contains('<') {
            return None;
        }
        constructor
    };
    if constructor.is_empty() || !(constructor.contains('.') || constructor.contains('<')) {
        return None;
    }
    if constructor.chars().any(|ch| {
        !(ch.is_ascii_alphanumeric()
            || matches!(
                ch,
                '_' | '.' | '<' | '>' | ',' | ' ' | '\'' | '[' | ']' | '*'
            ))
    }) {
        return None;
    }
    let terminal = constructor.rsplit('.').next()?.split('<').next()?.trim();
    terminal
        .chars()
        .next()
        .is_some_and(char::is_uppercase)
        .then(|| InferredBindingType::Constructor(constructor.to_owned()))
}

#[cfg(test)]
mod tests {
    use super::{CaptureParameter, definition_parameters, definition_parameters_before};

    #[test]
    fn preserves_explicit_single_line_binding_type() {
        let owner = "let cache : System.Collections.Generic.Dictionary<int,int> = create()\nlet value = 1\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::Explicit {
                name: "cache".to_owned(),
                annotation: "System.Collections.Generic.Dictionary<int,int>".to_owned(),
            }
        );
        assert_eq!(
            definition_parameters(owner, &["cache".to_owned(), "value".to_owned()]),
            vec![
                "(cache: System.Collections.Generic.Dictionary<int,int>)".to_owned(),
                "value".to_owned(),
            ]
        );
    }

    #[test]
    fn lexical_cutoff_ignores_later_shadowing_binding() {
        let owner =
            "let ty s x = x\nlet helper value = ty value\nlet ty : Ty = failwith \"shadow\"\n";
        assert_eq!(
            definition_parameters_before(owner, &["ty".to_owned()], 1),
            vec!["ty".to_owned()]
        );
    }

    #[test]
    fn derives_type_from_qualified_generic_constructor() {
        let owner = "let cache = System.Collections.Concurrent.ConcurrentDictionary<int64,int>()\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::ConstructorInferred {
                name: "cache".to_owned(),
                annotation: "System.Collections.Concurrent.ConcurrentDictionary<int64,int>"
                    .to_owned(),
            }
        );
        assert_eq!(
            definition_parameters(owner, &["cache".to_owned()]),
            vec![
                "(cache: System.Collections.Concurrent.ConcurrentDictionary<int64,int>)".to_owned()
            ]
        );
    }

    #[test]
    fn derives_type_from_constructor_with_fsharp_array_generic_argument() {
        let owner = "let jp_type_inflight = System.Threading.AsyncLocal<System.Collections.Generic.HashSet<ConsedNode<Ty []>>>()\n";
        assert_eq!(
            definition_parameters(owner, &["jp_type_inflight".to_owned()]),
            vec!["(jp_type_inflight: System.Threading.AsyncLocal<System.Collections.Generic.HashSet<ConsedNode<Ty []>>>)".to_owned()]
        );
    }

    #[test]
    fn derives_type_from_constructor_with_fsharp_tuple_generic_argument() {
        let owner = "let jp_method_key_names = System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<RData [] * Ty [] * Ty>, string>(HashIdentity.Reference)\n";
        assert_eq!(
            definition_parameters(owner, &["jp_method_key_names".to_owned()]),
            vec!["(jp_method_key_names: System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<RData [] * Ty [] * Ty>, string>)".to_owned()]
        );
    }

    #[test]
    fn derives_type_from_qualified_generic_constructor_with_arguments() {
        let owner = "let cache = System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<Ty []>, Trace>(HashIdentity.Reference)\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::ConstructorInferred {
                name: "cache".to_owned(),
                annotation:
                    "System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<Ty []>, Trace>"
                        .to_owned(),
            }
        );
    }

    #[test]
    fn derives_type_from_static_self_factory() {
        let owner = "let peval_sw = System.Diagnostics.Stopwatch.StartNew()\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "peval_sw"),
            CaptureParameter::StaticFactoryInferred {
                name: "peval_sw".to_owned(),
                annotation: "System.Diagnostics.Stopwatch".to_owned(),
            }
        );
        assert_eq!(
            definition_parameters(owner, &["peval_sw".to_owned()]),
            vec!["(peval_sw: System.Diagnostics.Stopwatch)".to_owned()]
        );
    }

    #[test]
    fn derives_type_from_indented_constructor_continuation() {
        let owner =
            "let cache =\n    System.Collections.Concurrent.ConcurrentDictionary<int64,int>()\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::ConstructorInferred {
                name: "cache".to_owned(),
                annotation: "System.Collections.Concurrent.ConcurrentDictionary<int64,int>"
                    .to_owned(),
            }
        );
    }

    #[test]
    fn preserves_typed_outer_function_parameter() {
        let owner = "let outer (state : Domain.State) value =\n    let helper x = state.value + x\n    helper value\n";
        assert_eq!(
            definition_parameters_before(owner, &["state".to_owned()], 1),
            vec!["(state: Domain.State)".to_owned()]
        );
    }

    #[test]
    fn nearest_typed_parameter_binding_wins() {
        let owner = "let first (state : FirstState) = state\nand outer (state : SecondState) value =\n    let helper x = state.value + x\n";
        assert_eq!(
            definition_parameters_before(owner, &["state".to_owned()], 2),
            vec!["(state: SecondState)".to_owned()]
        );
    }

    #[test]
    fn sibling_typed_parameter_does_not_type_outer_capture() {
        let owner = "let ty s x = x\nlet outer value =\n    let sibling (ty : Ty) = ty\n    let helper x = ty x\n    helper value\n";
        assert_eq!(
            definition_parameters_before(owner, &["ty".to_owned()], 3),
            vec!["ty".to_owned()]
        );
    }

    #[test]
    fn recursive_group_typed_parameter_can_type_capture() {
        let owner = "let rec ty s x = x\nand ty_core s x = ty s x\nand term (s : LangEnv) x = x\nand closure_env (s : LangEnv) x = x\n";
        assert_eq!(
            definition_parameters_before(owner, &["s".to_owned(), "ty".to_owned()], 1),
            vec!["(s: LangEnv)".to_owned(), "ty".to_owned()]
        );
    }

    #[test]
    fn recursive_group_binding_name_blocks_homonymous_parameter_witnesses() {
        let owner = "let rec ty s x = x\nand first (ty : Ty) x = x\nand second (ty : Ty) x = x\nand helper ty s = ty s\n";
        assert_eq!(
            definition_parameters_before(owner, &["ty".to_owned()], 0),
            vec!["ty".to_owned()]
        );
    }

    #[test]
    fn recursive_group_scan_crosses_preprocessor_directives() {
        let owner = "and ty_core s x = x\n#if DEBUG\n#endif\nand closure_env (s : LangEnv) x = x\nand term (s : LangEnv) x = x\n";
        assert_eq!(
            definition_parameters_before(owner, &["s".to_owned()], 0),
            vec!["(s: LangEnv)".to_owned()]
        );
    }

    #[test]
    fn earlier_same_indent_typed_parameter_does_not_type_function_capture() {
        let owner = "let unrelated (ty : Ty) = ty\nlet rec ty s x = x\nand helper s x = ty s x\nand term (s : LangEnv) x = x\nand closure_env (s : LangEnv) x = x\n";
        assert_eq!(
            definition_parameters_before(owner, &["s".to_owned(), "ty".to_owned()], 1),
            vec!["(s: LangEnv)".to_owned(), "ty".to_owned()]
        );
    }

    #[test]
    fn single_recursive_group_witness_does_not_type_every_homonym() {
        let owner = "let rec data_to_ty s x = x\nand term s (x : E) = x\n";
        assert_eq!(
            definition_parameters_before(owner, &["x".to_owned()], 0),
            vec!["x".to_owned()]
        );
    }

    #[test]
    fn derives_type_from_fully_annotated_function_binding() {
        let owner = "let get_async_local (slot : System.Threading.AsyncLocal<'T>) (mk : unit -> 'T) : 'T =\n    mk ()\nlet helper () = get_async_local\n";
        assert_eq!(
            definition_parameters_before(owner, &["get_async_local".to_owned()], 2),
            vec![
                "(get_async_local: (System.Threading.AsyncLocal<'get_async_local_T>) -> (unit -> 'get_async_local_T) -> 'get_async_local_T)"
                    .to_owned()
            ]
        );
    }

    #[test]
    fn namespaces_generic_function_capture_variables_independently() {
        let owner = "let get_async_local (slot : System.Threading.AsyncLocal<'T>) (mk : unit -> 'T) : 'T = mk ()\nlet jp_ivar_try_read (ivar : Hopac.IVar<'T>) : 'T option = None\nlet helper () = get_async_local, jp_ivar_try_read\n";
        assert_eq!(
            definition_parameters_before(
                owner,
                &["get_async_local".to_owned(), "jp_ivar_try_read".to_owned()],
                2
            ),
            vec![
                "(get_async_local: (System.Threading.AsyncLocal<'get_async_local_T>) -> (unit -> 'get_async_local_T) -> 'get_async_local_T)".to_owned(),
                "(jp_ivar_try_read: (Hopac.IVar<'jp_ivar_try_read_T>) -> 'jp_ivar_try_read_T option)".to_owned()
            ]
        );
    }

    #[test]
    fn does_not_guess_partially_annotated_function_binding() {
        let owner = "let get_async_local slot (mk : unit -> 'T) : 'T =\n    mk ()\nlet helper () = get_async_local\n";
        assert_eq!(
            definition_parameters_before(owner, &["get_async_local".to_owned()], 2),
            vec!["get_async_local".to_owned()]
        );
    }

    #[test]
    fn derives_type_from_typed_object_expression() {
        let owner = "let comparer =\n    { new System.Collections.Generic.IEqualityComparer<ConsedNode<Ty []>> with\n        member _.Equals(a,b) = a = b\n        member _.GetHashCode(a) = hash a\n    }\nlet helper () = comparer\n";
        assert_eq!(
            definition_parameters_before(owner, &["comparer".to_owned()], 5),
            vec![
                "(comparer: System.Collections.Generic.IEqualityComparer<ConsedNode<Ty []>>)"
                    .to_owned()
            ]
        );
    }

    #[test]
    fn derives_type_from_lazy_binding() {
        let owner = "let gate = lazy (create_gate ())\nlet helper () = gate.Force()\n";
        assert_eq!(
            definition_parameters_before(owner, &["gate".to_owned()], 1),
            vec!["(gate: Lazy<_>)".to_owned()]
        );
    }

    #[test]
    fn does_not_guess_plain_function_calls() {
        let owner = "let cache = create()\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::Plain {
                name: "cache".to_owned(),
            }
        );
    }

    #[test]
    fn does_not_guess_multiline_annotations() {
        let owner = "let cache :\n    System.Collections.Generic.Dictionary<int,int> = create()\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::Plain {
                name: "cache".to_owned(),
            }
        );
    }

    #[test]
    fn respects_identifier_boundaries() {
        let owner = "let cache_extra : int = 1\n";
        assert_eq!(
            CaptureParameter::from_owner(owner, "cache"),
            CaptureParameter::Plain {
                name: "cache".to_owned(),
            }
        );
    }
}
