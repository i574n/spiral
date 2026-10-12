use spiral_split_capture_parameter::CaptureParameter;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct HeaderStabilization {
    pub text: String,
    pub rewritten_parameters: usize,
}

fn identifier_start(byte: u8) -> bool {
    byte == b'_' || byte.is_ascii_alphabetic()
}

fn identifier_continue(byte: u8) -> bool {
    identifier_start(byte) || byte.is_ascii_digit() || byte == b'\''
}

fn binding_name(line: &str) -> Option<&str> {
    let mut rest = line.trim_start();
    rest = rest
        .strip_prefix("let ")
        .or_else(|| rest.strip_prefix("and "))?;
    if let Some(next) = rest.strip_prefix("rec ") {
        rest = next;
    }
    if let Some(next) = rest.strip_prefix("mutable ") {
        rest = next;
    }
    let bytes = rest.as_bytes();
    if !bytes.first().copied().is_some_and(identifier_start) {
        return None;
    }
    let mut end = 1usize;
    while bytes.get(end).copied().is_some_and(identifier_continue) {
        end += 1;
    }
    Some(&rest[..end])
}

fn binding_count(owner_text: &str, name: &str) -> usize {
    owner_text
        .lines()
        .filter(|line| binding_name(line) == Some(name))
        .count()
}

fn inferred_unique_binding_parameter(owner_text: &str, name: &str) -> Option<String> {
    if binding_count(owner_text, name) != 1 {
        return None;
    }
    match CaptureParameter::from_owner(owner_text, name) {
        CaptureParameter::Plain { .. } => None,
        parameter => Some(parameter.render_definition()),
    }
}

fn matching_parenthesis(text: &str, open: usize, end: usize) -> Option<usize> {
    let bytes = text.as_bytes();
    let mut depth = 0usize;
    let mut index = open;
    while index < end {
        match bytes[index] {
            b'(' => depth += 1,
            b')' => {
                depth = depth.checked_sub(1)?;
                if depth == 0 {
                    return Some(index);
                }
            }
            _ => {}
        }
        index += 1;
    }
    None
}

fn generated_header_prefix_end(line: &str) -> Option<usize> {
    let bytes = line.as_bytes();
    let mut cursor = line.len() - line.trim_start().len();
    if line[cursor..].starts_with("let ") {
        cursor += 4;
    } else if line[cursor..].starts_with("and ") {
        cursor += 4;
    } else {
        return None;
    }
    if line[cursor..].starts_with("rec ") {
        cursor += 4;
    }
    if !line[cursor..].starts_with("__spiral_") {
        return None;
    }
    if !bytes.get(cursor).copied().is_some_and(identifier_start) {
        return None;
    }
    cursor += 1;
    while bytes.get(cursor).copied().is_some_and(identifier_continue) {
        cursor += 1;
    }
    Some(cursor)
}

fn header_equals(line: &str, start: usize) -> Option<usize> {
    let bytes = line.as_bytes();
    let mut depth = 0usize;
    let mut cursor = start;
    while cursor < bytes.len() {
        match bytes[cursor] {
            b'(' => depth += 1,
            b')' => depth = depth.saturating_sub(1),
            b'=' if depth == 0 => return Some(cursor),
            _ => {}
        }
        cursor += 1;
    }
    None
}

fn stabilize_line(owner_text: &str, line: &str) -> (String, usize) {
    let Some(name_end) = generated_header_prefix_end(line) else {
        return (line.to_owned(), 0);
    };
    let Some(equals) = header_equals(line, name_end) else {
        return (line.to_owned(), 0);
    };
    let bytes = line.as_bytes();
    let mut output = String::with_capacity(line.len() + 64);
    output.push_str(&line[..name_end]);
    let mut cursor = name_end;
    let mut rewrites = 0usize;
    while cursor < equals {
        let byte = bytes[cursor];
        if byte.is_ascii_whitespace() {
            output.push(byte as char);
            cursor += 1;
            continue;
        }
        if byte == b'(' {
            let Some(close) = matching_parenthesis(line, cursor, equals) else {
                return (line.to_owned(), 0);
            };
            output.push_str(&line[cursor..=close]);
            cursor = close + 1;
            continue;
        }
        let start = cursor;
        while cursor < equals && !bytes[cursor].is_ascii_whitespace() {
            cursor += 1;
        }
        let token = &line[start..cursor];
        let plain = token
            .as_bytes()
            .first()
            .copied()
            .is_some_and(identifier_start)
            && token.as_bytes().iter().copied().all(identifier_continue);
        if plain && let Some(rendered) = inferred_unique_binding_parameter(owner_text, token) {
            output.push_str(&rendered);
            rewrites += 1;
        } else {
            output.push_str(token);
        }
    }
    output.push_str(&line[equals..]);
    (output, rewrites)
}

#[must_use]
pub fn stabilize_generated_capture_headers(owner_text: &str) -> HeaderStabilization {
    let trailing_newline = owner_text.ends_with('\n');
    let mut rewritten_parameters = 0usize;
    let lines = owner_text
        .lines()
        .map(|line| {
            let (line, rewrites) = stabilize_line(owner_text, line);
            rewritten_parameters += rewrites;
            line
        })
        .collect::<Vec<_>>();
    let mut text = lines.join("\n");
    if trailing_newline {
        text.push('\n');
    }
    HeaderStabilization {
        text,
        rewritten_parameters,
    }
}

#[cfg(test)]
mod tests {
    use super::stabilize_generated_capture_headers;

    #[test]
    fn stabilizes_generated_capture_from_unique_later_constructor_binding() {
        let owner = "let __spiral_helper cache x = cache.TryGetValue x\nlet cache = System.Collections.Concurrent.ConcurrentDictionary<int,string>()\n";
        let result = stabilize_generated_capture_headers(owner);
        assert_eq!(result.rewritten_parameters, 1);
        assert!(result.text.contains("let __spiral_helper (cache: System.Collections.Concurrent.ConcurrentDictionary<int,string>) x ="));
    }

    #[test]
    fn leaves_ambiguous_binding_name_untyped() {
        let owner = "let __spiral_helper cache x = cache.TryGetValue x\nlet cache = System.Collections.Generic.Dictionary<int,string>()\nlet cache = System.Collections.Generic.Dictionary<int,string>()\n";
        let result = stabilize_generated_capture_headers(owner);
        assert_eq!(result.rewritten_parameters, 0);
        assert!(result.text.starts_with("let __spiral_helper cache x ="));
    }

    #[test]
    fn preserves_already_typed_and_unrelated_parameters() {
        let owner =
            "let __spiral_helper (cache: Cache) x = cache.Read x\nlet cache : Cache = create ()\n";
        let result = stabilize_generated_capture_headers(owner);
        assert_eq!(result.rewritten_parameters, 0);
        assert_eq!(result.text, owner);
    }

    #[test]
    fn reproduces_join_point_trace_capture_shape() {
        let owner = "let __spiral_scc_ty_core_impl jp_type_key_traces term x = jp_type_key_traces.TryGetValue x\nlet jp_type_key_traces = System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<Ty []>, Trace>(HashIdentity.Reference)\n";
        let result = stabilize_generated_capture_headers(owner);
        assert_eq!(result.rewritten_parameters, 1);
        assert!(result.text.contains("(jp_type_key_traces: System.Collections.Concurrent.ConcurrentDictionary<ConsedNode<Ty []>, Trace>)"));
        assert!(result.text.contains(" term x ="));
    }
}
