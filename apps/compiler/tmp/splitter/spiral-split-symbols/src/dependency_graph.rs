use rayon::prelude::*;
use spiral_split_model::{
    Declaration, DeclarationId, DeclarationKind, DeclarationScope, DependencyWitness, Linked,
    Program, Scanned, ambient_type_target,
};
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug)]
struct SymbolShape {
    definitions: BTreeSet<String>,
    references: BTreeSet<String>,
}

fn is_identifier_start(character: char) -> bool {
    character == '_' || character.is_alphabetic()
}

fn is_identifier_continue(character: char) -> bool {
    character == '_' || character == '\'' || character.is_alphanumeric()
}

fn is_operator(character: char) -> bool {
    matches!(
        character,
        '!' | '%'
            | '&'
            | '*'
            | '+'
            | '-'
            | '.'
            | '/'
            | ':'
            | '<'
            | '='
            | '>'
            | '?'
            | '@'
            | '^'
            | '|'
            | '~'
            | '{'
            | '}'
            | ';'
    )
}

fn tokens(text: &str) -> Vec<String> {
    let chars = text.chars().collect::<Vec<_>>();
    let mut result = Vec::new();
    let mut index = 0usize;
    while index < chars.len() {
        let current = chars[index];
        if current == '/' && chars.get(index + 1) == Some(&'/') {
            while index < chars.len() && chars[index] != '\n' {
                index += 1;
            }
            continue;
        }
        if current == '\'' {
            if chars.get(index + 2) == Some(&'\'') {
                index += 3;
                continue;
            }
            if chars.get(index + 1) == Some(&'\\') && chars.get(index + 3) == Some(&'\'') {
                index += 4;
                continue;
            }
            if chars
                .get(index + 1)
                .is_some_and(|character| is_identifier_start(*character))
            {
                let start = index;
                index += 2;
                while index < chars.len() && is_identifier_continue(chars[index]) {
                    index += 1;
                }
                result.push(chars[start..index].iter().collect());
                continue;
            }
        }
        if current == '"' {
            index += 1;
            let mut escaped = false;
            while index < chars.len() {
                let value = chars[index];
                index += 1;
                if escaped {
                    escaped = false;
                } else if value == '\\' {
                    escaped = true;
                } else if value == '"' {
                    break;
                }
            }
            continue;
        }
        if is_identifier_start(current) {
            let start = index;
            index += 1;
            while index < chars.len() && is_identifier_continue(chars[index]) {
                index += 1;
            }
            result.push(chars[start..index].iter().collect());
            continue;
        }
        if is_operator(current) {
            let start = index;
            index += 1;
            while index < chars.len() && is_operator(chars[index]) {
                index += 1;
            }
            result.push(chars[start..index].iter().collect());
            continue;
        }
        index += 1;
    }
    result
}

fn identifier_token(token: &str) -> bool {
    let mut characters = token.chars();
    characters.next().is_some_and(is_identifier_start) && characters.all(is_identifier_continue)
}

fn starts_with_at(bytes: &[u8], index: usize, needle: &[u8]) -> bool {
    bytes.get(index..index + needle.len()) == Some(needle)
}

fn interpolation_expressions(text: &str) -> Vec<String> {
    let bytes = text.as_bytes();
    let mut result = Vec::new();
    let mut index = 0usize;
    while index + 1 < bytes.len() {
        if bytes[index] != b'$' || bytes[index + 1] != b'"' {
            index += 1;
            continue;
        }
        let triple = starts_with_at(bytes, index + 1, b"\"\"\"");
        index += if triple { 4 } else { 2 };
        let mut escaped = false;
        while index < bytes.len() {
            if triple && starts_with_at(bytes, index, b"\"\"\"") {
                index += 3;
                break;
            }
            if !triple {
                if escaped {
                    escaped = false;
                    index += 1;
                    continue;
                }
                if bytes[index] == 92 {
                    escaped = true;
                    index += 1;
                    continue;
                }
                if bytes[index] == b'"' {
                    index += 1;
                    break;
                }
            }
            if bytes[index] == b'{' {
                if bytes.get(index + 1) == Some(&b'{') {
                    index += 2;
                    continue;
                }
                let start = index + 1;
                index += 1;
                let mut depth = 1usize;
                let mut quote = None;
                let mut quote_escaped = false;
                let mut quote_triple = false;
                while index < bytes.len() && depth > 0 {
                    if let Some(delimiter) = quote {
                        if quote_triple
                            && delimiter == b'"'
                            && starts_with_at(bytes, index, b"\"\"\"")
                        {
                            quote = None;
                            quote_triple = false;
                            index += 3;
                            continue;
                        }
                        if !quote_triple {
                            if quote_escaped {
                                quote_escaped = false;
                                index += 1;
                                continue;
                            }
                            if bytes[index] == 92 {
                                quote_escaped = true;
                                index += 1;
                                continue;
                            }
                            if bytes[index] == delimiter {
                                quote = None;
                                index += 1;
                                continue;
                            }
                        }
                        index += 1;
                        continue;
                    }
                    if bytes[index] == b'"' {
                        quote = Some(b'"');
                        quote_triple = starts_with_at(bytes, index, b"\"\"\"");
                        index += if quote_triple { 3 } else { 1 };
                        continue;
                    }
                    if bytes[index] == b'\'' {
                        if bytes.get(index + 2) == Some(&b'\'') {
                            index += 3;
                            continue;
                        }
                        if bytes.get(index + 1) == Some(&92) && bytes.get(index + 3) == Some(&b'\'')
                        {
                            index += 4;
                            continue;
                        }
                    }
                    match bytes[index] {
                        b'{' => depth += 1,
                        b'}' => {
                            depth -= 1;
                            if depth == 0 {
                                result.push(text[start..index].to_owned());
                                index += 1;
                                break;
                            }
                        }
                        _ => {}
                    }
                    index += 1;
                }
                continue;
            }
            if bytes[index] == b'}' && bytes.get(index + 1) == Some(&b'}') {
                index += 2;
            } else {
                index += 1;
            }
        }
    }
    result
}

fn analysis_tokens(text: &str) -> Vec<String> {
    let mut result = tokens(text);
    for expression in interpolation_expressions(text) {
        result.extend(analysis_tokens(&expression));
    }
    result
}

fn symbol_tokens(text: &str) -> Vec<String> {
    let raw = analysis_tokens(text);
    let mut result = raw.clone();
    for start in 0..raw.len() {
        if !identifier_token(&raw[start]) {
            continue;
        }
        let mut qualified = raw[start].clone();
        let mut index = start + 1;
        let mut depth = 0usize;
        while index + 1 < raw.len() && raw[index] == "." && identifier_token(&raw[index + 1]) {
            qualified.push('.');
            qualified.push_str(&raw[index + 1]);
            depth += 1;
            result.push(qualified.clone());
            index += 2;
        }
        if depth == 0 {
            continue;
        }
    }
    result
}

fn field_references(text: &str) -> BTreeSet<String> {
    let raw = analysis_tokens(text);
    let mut result = raw
        .windows(2)
        .filter(|pair| pair[0] == "." && identifier_token(&pair[1]))
        .map(|pair| format!("field:{}", pair[1]))
        .collect::<BTreeSet<_>>();
    let mut brace_depth = 0usize;
    for (index, token) in raw.iter().enumerate() {
        match token.as_str() {
            "{" => brace_depth += 1,
            "}" => brace_depth = brace_depth.saturating_sub(1),
            _ if brace_depth > 0 && identifier_token(token) => {
                let previous = index.checked_sub(1).and_then(|value| raw.get(value));
                let next = raw.get(index + 1);
                let explicit = next.is_some_and(|value| value == "=" || value == ":");
                let punned_start =
                    previous.is_none_or(|value| matches!(value.as_str(), "{" | ";" | "|"));
                let punned_end =
                    next.is_some_and(|value| matches!(value.as_str(), "}" | ";" | "|"));
                if explicit || (punned_start && punned_end) {
                    result.insert(format!("field:{token}"));
                }
            }
            _ => {}
        }
    }
    result
}

fn analysis_text(declaration: &Declaration<Scanned>) -> String {
    match &declaration.scope {
        DeclarationScope::Root => declaration.text.clone(),
        DeclarationScope::ModuleFragment {
            prefix_lines,
            dedent_spaces,
            ..
        } => {
            let prefix = " ".repeat(*dedent_spaces);
            let mut output = declaration
                .text
                .lines()
                .skip(*prefix_lines)
                .map(|line| line.strip_prefix(&prefix).unwrap_or(line))
                .collect::<Vec<_>>()
                .join("\n");
            output.push('\n');
            output
        }
    }
}

fn keyword(token: &str) -> bool {
    matches!(
        token,
        "abstract"
            | "and"
            | "as"
            | "assert"
            | "base"
            | "begin"
            | "class"
            | "default"
            | "delegate"
            | "do"
            | "done"
            | "downcast"
            | "downto"
            | "elif"
            | "else"
            | "end"
            | "exception"
            | "extern"
            | "false"
            | "finally"
            | "fixed"
            | "for"
            | "fun"
            | "function"
            | "global"
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
            | "void"
            | "when"
            | "while"
            | "with"
            | "yield"
    )
}

fn leading_spaces(line: &str) -> usize {
    line.chars()
        .take_while(|character| *character == ' ')
        .count()
}

fn starts_definition(line: &str, kind: DeclarationKind) -> bool {
    let trimmed = line.trim_start();
    match kind {
        DeclarationKind::TypeGroup => trimmed.starts_with("type ") || trimmed.starts_with("and "),
        DeclarationKind::LetGroup => trimmed.starts_with("let ") || trimmed.starts_with("and "),
        DeclarationKind::Module => trimmed.starts_with("module "),
        DeclarationKind::Exception => trimmed.starts_with("exception "),
        DeclarationKind::Directive | DeclarationKind::Value | DeclarationKind::Other => false,
    }
}

fn definition_indent(text: &str, kind: DeclarationKind) -> Option<usize> {
    text.lines()
        .filter(|line| starts_definition(line, kind))
        .map(leading_spaces)
        .min()
}

fn type_definition_after(line: &str, keyword: &str) -> Option<String> {
    let trimmed = line.trim_start();
    let mut tail = trimmed.strip_prefix(keyword)?.trim_start().to_owned();
    while let Some(start) = tail.find("[<") {
        let relative_end = tail[start + 2..].find(">]")?;
        let end = start + 2 + relative_end + 2;
        tail.replace_range(start..end, " ");
    }
    tokens(&tail).into_iter().find(|token| {
        !token.starts_with('\'')
            && token.chars().next().is_some_and(is_identifier_start)
            && !matches!(
                token.as_str(),
                "rec" | "inline" | "private" | "internal" | "public" | "mutable" | "static"
            )
    })
}

fn definition_after<'a>(tokens: &'a [String], keyword: &str) -> Option<&'a str> {
    let position = tokens.iter().position(|token| token == keyword)?;
    tokens[position + 1..]
        .iter()
        .find(|token| {
            !token.starts_with('\'')
                && !matches!(
                    token.as_str(),
                    "rec" | "inline" | "private" | "internal" | "public" | "mutable" | "static"
                )
        })
        .map(String::as_str)
}

fn let_definition_after(tokens: &[String], binding_keyword: &str) -> Option<String> {
    let position = tokens.iter().position(|token| token == binding_keyword)?;
    let tail = &tokens[position + 1..];
    let start = tail.iter().position(|token| {
        !token.starts_with('\'')
            && !matches!(
                token.as_str(),
                "rec" | "inline" | "private" | "internal" | "public" | "mutable" | "static"
            )
    })?;
    if tail[start] == "|" {
        return tail[start + 1..]
            .iter()
            .take_while(|token| token.as_str() != "=")
            .find(|token| identifier_token(token) && token.as_str() != "_" && !keyword(token))
            .cloned();
    }
    Some(tail[start].clone())
}

fn insert_union_cases(result: &mut BTreeSet<String>, line_tokens: &[String], include_equals: bool) {
    for pair in line_tokens.windows(2) {
        let is_case = pair[0] == "|" || (include_equals && pair[0] == "=");
        if is_case && identifier_token(&pair[1]) && !keyword(&pair[1]) {
            result.insert(pair[1].clone());
        }
    }
    if include_equals
        && let Some(equals) = line_tokens.iter().position(|token| token == "=")
        && let Some(case) = line_tokens[equals + 1..]
            .iter()
            .find(|token| !matches!(token.as_str(), "private" | "internal" | "public"))
        && identifier_token(case)
        && !keyword(case)
    {
        result.insert(case.clone());
    }
}

fn union_case_definitions(text: &str, header_indent: usize) -> BTreeSet<String> {
    let mut result = BTreeSet::new();
    let mut awaiting_body = false;
    let mut case_indent = None;
    for line in text.lines() {
        let trimmed = line.trim_start();
        if trimmed.is_empty() || trimmed.starts_with("//") || trimmed.starts_with("[<") {
            continue;
        }
        let indent = leading_spaces(line);
        let line_tokens = tokens(line);
        let is_header =
            indent == header_indent && starts_definition(line, DeclarationKind::TypeGroup);
        if is_header {
            let inline_union = line_tokens.iter().any(|token| token == "|")
                || line_tokens.windows(3).any(|window| {
                    window[0] == "="
                        && identifier_token(&window[1])
                        && !keyword(&window[1])
                        && window[2] == "of"
                })
                || line_tokens.windows(4).any(|window| {
                    window[0] == "="
                        && matches!(window[1].as_str(), "private" | "internal" | "public")
                        && identifier_token(&window[2])
                        && !keyword(&window[2])
                        && window[3] == "of"
                });
            insert_union_cases(&mut result, &line_tokens, inline_union);
            awaiting_body = true;
            case_indent = None;
            continue;
        }
        if awaiting_body {
            // `type T =` / `private` / `| Case ...`: an accessibility line between the header and the
            // cases is part of the representation, not its end (missing it dropped every case of such
            // unions, and with them the dependency edges of their users).
            if matches!(trimmed.trim_end(), "private" | "internal" | "public") {
                continue;
            }
            if trimmed.starts_with('|') {
                case_indent = Some(indent);
                insert_union_cases(&mut result, &line_tokens, false);
            }
            awaiting_body = false;
            continue;
        }
        if case_indent == Some(indent) && trimmed.starts_with('|') {
            insert_union_cases(&mut result, &line_tokens, false);
        } else if case_indent.is_some() && indent <= header_indent {
            case_indent = None;
        }
    }
    result
}

fn definitions(declaration: &Declaration<Scanned>) -> BTreeSet<String> {
    let kind = declaration.boundary.kind();
    let text = analysis_text(declaration);
    let indent = definition_indent(&text, kind);
    let mut result = text
        .lines()
        .filter(|line| starts_definition(line, kind))
        .filter(|line| indent.is_some_and(|value| leading_spaces(line) == value))
        .filter_map(|line| {
            let line_tokens = tokens(line);
            match kind {
                DeclarationKind::TypeGroup => type_definition_after(line, "type")
                    .or_else(|| type_definition_after(line, "and")),
                DeclarationKind::LetGroup => let_definition_after(&line_tokens, "let")
                    .or_else(|| let_definition_after(&line_tokens, "and")),
                DeclarationKind::Module => {
                    definition_after(&line_tokens, "module").map(str::to_owned)
                }
                DeclarationKind::Exception => {
                    definition_after(&line_tokens, "exception").map(str::to_owned)
                }
                DeclarationKind::Directive | DeclarationKind::Value | DeclarationKind::Other => {
                    None
                }
            }
        })
        .collect::<BTreeSet<_>>();
    if kind == DeclarationKind::TypeGroup {
        result.extend(union_case_definitions(&text, indent.unwrap_or_default()));
        for line in text.lines() {
            let line_tokens = tokens(line);
            for pair in line_tokens.windows(2) {
                if pair[1] == ":" && !keyword(&pair[0]) {
                    result.insert(format!("field:{}", pair[0]));
                }
            }
        }
    }
    if let Some(module_name) = declaration.scope.module_name() {
        let module_parts = module_name.split('.').collect::<Vec<_>>();
        let simple = result
            .iter()
            .filter(|definition| !definition.contains('.'))
            .cloned()
            .collect::<Vec<_>>();
        for definition in simple {
            for start in 0..module_parts.len() {
                result.insert(format!(
                    "{}.{}",
                    module_parts[start..].join("."),
                    definition
                ));
            }
        }
    }
    result
}

fn shape(declaration: &Declaration<Scanned>) -> SymbolShape {
    let definitions = definitions(declaration);
    let text = analysis_text(declaration);
    let occurrences = symbol_tokens(&text)
        .into_iter()
        .filter(|token| !keyword(token))
        .collect::<Vec<_>>();
    let mut occurrence_counts = BTreeMap::<String, usize>::new();
    for token in &occurrences {
        *occurrence_counts.entry(token.clone()).or_default() += 1;
    }
    let mut references = occurrences
        .into_iter()
        .filter(|token| {
            !definitions.contains(token)
                || occurrence_counts.get(token).copied().unwrap_or_default() > 1
        })
        .collect::<BTreeSet<_>>();
    references.extend(
        field_references(&text)
            .into_iter()
            .filter(|token| !definitions.contains(token)),
    );
    references.extend(
        declaration
            .ambient_opens
            .iter()
            .filter_map(|line| ambient_type_target(line).map(str::to_owned)),
    );
    SymbolShape {
        definitions,
        references,
    }
}

pub fn link_dependencies(program: Program<Scanned>) -> Program<Linked> {
    let shapes = program
        .declarations
        .par_iter()
        .map(shape)
        .collect::<Vec<_>>();
    let mut providers = BTreeMap::<String, Vec<DeclarationId>>::new();
    let mut linked = Vec::<Declaration<Linked>>::with_capacity(program.declarations.len());

    for (declaration, shape) in program.declarations.into_iter().zip(shapes) {
        let mut declaration = declaration.restage::<Linked>();
        declaration.definitions = shape.definitions;
        declaration.references = shape.references;
        for symbol in &declaration.references {
            if let Some(candidates) = providers.get(symbol) {
                let selected = if symbol.starts_with("field:") {
                    candidates.to_vec()
                } else {
                    candidates.last().copied().into_iter().collect::<Vec<_>>()
                };
                for provider in selected {
                    declaration.direct_dependencies.insert(provider);
                    declaration.witnesses.push(DependencyWitness {
                        symbol: symbol.clone(),
                        provider,
                    });
                }
            }
        }
        let direct = declaration.direct_dependencies.clone();
        for dependency in direct {
            declaration.closure_dependencies.insert(dependency);
            declaration
                .closure_dependencies
                .extend(linked[dependency.0].closure_dependencies.iter().copied());
        }
        for definition in &declaration.definitions {
            providers
                .entry(definition.clone())
                .or_default()
                .push(declaration.id);
        }
        linked.push(declaration);
    }
    Program::new(program.source, linked)
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{
        BoundaryReason, CompilerProfile, Declaration, DeclarationId, LineSpan, SourceText, fnv1a64,
    };
    use std::path::PathBuf;

    fn declaration(id: usize, text: &str) -> Declaration<Scanned> {
        Declaration::new(
            DeclarationId(id),
            LineSpan {
                start: id + 1,
                end: id + 2,
            },
            String::new(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
    }

    fn type_declaration(id: usize, text: &str) -> Declaration<Scanned> {
        let mut declaration = declaration(id, text);
        declaration.boundary = BoundaryReason::TopLevel(DeclarationKind::TypeGroup);
        declaration
    }

    #[test]
    fn record_fields_and_union_cases_link_to_their_type_group() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PreHopac,
            fingerprint: 0,
            bytes: 0,
        };
        let program = Program::new(
            source,
            vec![
                type_declaration(
                    0,
                    "    type Flags = { allow_term : bool; allow_wildcard : bool }
",
                ),
                declaration(
                    1,
                    "    let defaults = { allow_term = false; allow_wildcard = true }
",
                ),
                type_declaration(
                    2,
                    "    type Choice =
        | Ready
",
                ),
                declaration(
                    3,
                    "    let choice = Ready
",
                ),
                declaration(
                    4,
                    "    let read_flags x = x.allow_term
",
                ),
            ],
        );
        let linked = link_dependencies(program);
        assert!(
            linked.declarations[1]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
        assert!(
            linked.declarations[3]
                .direct_dependencies
                .contains(&DeclarationId(2))
        );
        assert!(
            linked.declarations[4]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
    }

    #[test]
    fn single_case_union_with_payload_exports_discriminator() {
        let declaration = type_declaration(
            0,
            "    [<Struct>]\n    type JpOperationPhaseSampleId = private JpOperationPhaseSample of phase:int * nodeId:int\n",
        );
        let shape = shape(&declaration);
        assert!(shape.definitions.contains("JpOperationPhaseSample"));
    }

    #[test]
    fn nested_match_cases_are_not_exported_as_union_cases() {
        let declaration = type_declaration(
            0,
            "    type HoverTypes() =\n        let inspect x =\n            match x with\n            | TyApply _ -> true\n            | _ -> false\n",
        );
        let shape = shape(&declaration);
        assert!(shape.definitions.contains("HoverTypes"));
        assert!(!shape.definitions.contains("TyApply"));
    }

    #[test]
    fn postfix_generic_type_name_links_to_its_provider() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PortableFork,
            fingerprint: 0,
            bytes: 0,
        };
        let program = Program::new(
            source,
            vec![
                type_declaration(
                    0,
                    "    type [<ReferenceEquality>] 'a ref' = { mutable contents' : 'a }\n",
                ),
                type_declaration(1, "    type TT = KindMetavar of TT option ref'\n"),
            ],
        );
        let linked = link_dependencies(program);
        assert!(linked.declarations[0].definitions.contains("ref'"));
        assert!(
            linked.declarations[1]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
    }

    #[test]
    fn dedented_top_level_definition_links_to_consumer() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PreHopac,
            fingerprint: 0,
            bytes: 0,
        };
        let program = Program::new(
            source,
            vec![
                declaration(
                    0,
                    "let lines (str : string) = str\
",
                ),
                declaration(
                    1,
                    "let consume str = lines str\
",
                ),
            ],
        );
        let linked = link_dependencies(program);
        assert!(linked.declarations[0].definitions.contains("lines"));
        assert!(
            linked.declarations[1]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
    }

    #[test]
    fn links_to_prior_definition() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PreHopac,
            fingerprint: 0,
            bytes: 0,
        };
        let program = Program::new(
            source,
            vec![
                declaration(0, "    let alpha x = x\n"),
                declaration(1, "    let beta x = alpha x\n"),
            ],
        );
        let linked = link_dependencies(program);
        assert!(
            linked.declarations[1]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
    }

    #[test]
    fn char_literals_do_not_hide_following_identifiers() {
        let visible = tokens("f '\"' || is_parenth_open c || is_parenth_close c");
        assert!(visible.contains(&"is_parenth_open".to_owned()));
        assert!(visible.contains(&"is_parenth_close".to_owned()));
    }

    #[test]
    fn operator_tokens_are_visible() {
        assert!(tokens("a >>= b").contains(&">>=".to_owned()));
    }

    #[test]
    fn qualified_module_fragment_definition_links_external_use() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::Hopac,
            fingerprint: 0,
            bytes: 0,
        };
        let provider = declaration(0, "    module BigStack =\n        let run x = x\n").with_scope(
            DeclarationScope::ModuleFragment {
                module_name: "BigStack".to_owned(),
                ordinal: 0,
                prefix_lines: 1,
                dedent_spaces: 4,
            },
        );
        let consumer = declaration(1, "    let value = BigStack.run 1\n");
        let linked = link_dependencies(Program::new(source, vec![provider, consumer]));
        assert!(linked.declarations[0].definitions.contains("BigStack.run"));
        assert!(
            linked.declarations[1]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
        assert!(
            linked.declarations[1]
                .witnesses
                .iter()
                .any(|witness| witness.symbol == "BigStack.run")
        );
    }

    #[test]
    fn qualified_token_chains_are_retained() {
        let visible = symbol_tokens("BigStack.Inner.run context");
        assert!(visible.contains(&"BigStack.Inner".to_owned()));
        assert!(visible.contains(&"BigStack.Inner.run".to_owned()));
    }

    #[test]
    fn interpolated_expressions_link_to_their_providers() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PortableFork,
            fingerprint: 0,
            bytes: 0,
        };
        let program = Program::new(
            source,
            vec![
                declaration(
                    0,
                    "    let show_ty x = string x\
",
                ),
                declaration(
                    1,
                    r#"    let render x = $"Got: {show_ty x}"
"#,
                ),
            ],
        );
        let linked = link_dependencies(program);
        assert!(
            linked.declarations[1]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
        assert!(
            linked.declarations[1]
                .witnesses
                .iter()
                .any(|witness| witness.symbol == "show_ty")
        );
    }

    #[test]
    fn union_cases_after_a_separate_private_line_are_definitions() {
        let text = "    type Capability =\n        private\n        | Applied of int\n        | OwnerDebt of int\n        member x.value = 0\n";
        let cases = union_case_definitions(text, 4);
        assert!(cases.contains("Applied"));
        assert!(cases.contains("OwnerDebt"));
    }

    #[test]
    fn active_pattern_definitions_shadow_earlier_union_cases() {
        let source = SourceText {
            path: PathBuf::from("test.fs"),
            lines: Vec::new(),
            module_line: 0,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PortableFork,
            fingerprint: 0,
            bytes: 0,
        };
        let program = Program::new(
            source,
            vec![
                type_declaration(
                    0,
                    "    type ConstraintOrModule = C of int | M\
",
                ),
                declaration(
                    1,
                    "    let inline (|C|) (x : Holder) = x.node\
",
                ),
                declaration(
                    2,
                    "    let read x = match x with | C value -> value\
",
                ),
            ],
        );
        let linked = link_dependencies(program);
        assert!(linked.declarations[1].definitions.contains("C"));
        assert!(
            linked.declarations[2]
                .direct_dependencies
                .contains(&DeclarationId(1))
        );
        assert!(
            !linked.declarations[2]
                .direct_dependencies
                .contains(&DeclarationId(0))
        );
    }
}
