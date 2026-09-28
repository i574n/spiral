use spiral_split_model::{
    BoundaryReason, CompilerProfile, Declaration, DeclarationId, DeclarationKind, DeclarationScope,
    LineSpan, Program, Scanned, SourceText, fnv1a64,
};

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum LexicalState {
    Code,
    BlockComment { depth: usize },
    TripleString,
}

fn sanitize_line(mut state: LexicalState, line: &str) -> (LexicalState, String) {
    let chars = line.chars().collect::<Vec<_>>();
    let mut output = String::with_capacity(chars.len());
    let mut index = 0usize;
    while index < chars.len() {
        match state {
            LexicalState::Code => {
                let a = chars[index];
                let b = chars.get(index + 1).copied();
                let c = chars.get(index + 2).copied();
                if a == '/' && b == Some('/') {
                    output.extend(std::iter::repeat_n(' ', chars.len() - index));
                    break;
                }
                if a == '(' && b == Some('*') {
                    output.push(' ');
                    output.push(' ');
                    index += 2;
                    state = LexicalState::BlockComment { depth: 1 };
                    continue;
                }
                if a == '"' && b == Some('"') && c == Some('"') {
                    output.extend([' ', ' ', ' ']);
                    index += 3;
                    state = LexicalState::TripleString;
                    continue;
                }
                if a == '"' {
                    output.push(' ');
                    index += 1;
                    let mut escaped = false;
                    while index < chars.len() {
                        let current = chars[index];
                        output.push(' ');
                        index += 1;
                        if escaped {
                            escaped = false;
                        } else if current == '\\' {
                            escaped = true;
                        } else if current == '"' {
                            break;
                        }
                    }
                    continue;
                }
                output.push(a);
                index += 1;
            }
            LexicalState::BlockComment { mut depth } => {
                let a = chars[index];
                let b = chars.get(index + 1).copied();
                if a == '(' && b == Some('*') {
                    output.extend([' ', ' ']);
                    index += 2;
                    depth += 1;
                } else if a == '*' && b == Some(')') {
                    output.extend([' ', ' ']);
                    index += 2;
                    depth -= 1;
                    if depth == 0 {
                        state = LexicalState::Code;
                        continue;
                    }
                } else {
                    output.push(' ');
                    index += 1;
                }
                state = LexicalState::BlockComment { depth };
            }
            LexicalState::TripleString => {
                let a = chars[index];
                let b = chars.get(index + 1).copied();
                let c = chars.get(index + 2).copied();
                if a == '"' && b == Some('"') && c == Some('"') {
                    output.extend([' ', ' ', ' ']);
                    index += 3;
                    state = LexicalState::Code;
                } else {
                    output.push(' ');
                    index += 1;
                }
            }
        }
    }
    (state, output)
}

fn exactly_module_top_level(line: &str) -> bool {
    line.starts_with("    ") && !line.starts_with("        ") && !line.starts_with("    \t")
}

fn record_open(active_opens: &mut Vec<String>, open_line: String) {
    if let Some(index) = active_opens
        .iter()
        .position(|existing| existing == &open_line)
    {
        active_opens.remove(index);
    }
    active_opens.push(open_line);
}

fn classify(trimmed: &str) -> Option<DeclarationKind> {
    if trimmed.starts_with("type ") {
        Some(DeclarationKind::TypeGroup)
    } else if trimmed.starts_with("let ") {
        Some(DeclarationKind::LetGroup)
    } else if trimmed.starts_with("module ") {
        Some(DeclarationKind::Module)
    } else if trimmed.starts_with("exception ") {
        Some(DeclarationKind::Exception)
    } else if trimmed.starts_with("#if ") || trimmed == "#if" {
        Some(DeclarationKind::Directive)
    } else if trimmed.starts_with("do ") || trimmed == "do" {
        Some(DeclarationKind::Value)
    } else if trimmed.starts_with("and ") {
        Some(DeclarationKind::Other)
    } else {
        None
    }
}

fn is_trivia(trimmed: &str) -> bool {
    trimmed.is_empty()
        || trimmed.starts_with("//")
        || trimmed.starts_with("///")
        || trimmed.starts_with("[<")
        || trimmed.starts_with("#nowarn")
}

fn heading(lines: &[String]) -> String {
    lines
        .iter()
        .find_map(|line| {
            let trimmed = line.trim();
            trimmed
                .strip_prefix("/// ##")
                .map(str::trim)
                .filter(|value| !value.is_empty())
                .map(str::to_owned)
        })
        .unwrap_or_default()
}

struct DeclarationSlice {
    start: usize,
    end: usize,
    kind: DeclarationKind,
    trivia_lines: usize,
    directive_depth: usize,
    ambient_opens: Vec<String>,
}

fn declaration(id: usize, source: &SourceText, slice: DeclarationSlice) -> Declaration<Scanned> {
    let DeclarationSlice {
        start,
        end,
        kind,
        trivia_lines,
        directive_depth,
        ambient_opens,
    } = slice;
    let selected = &source.lines[start..end];
    let text = format!("{}\n", selected.join("\n"));
    let mut boundary = BoundaryReason::TopLevel(kind);
    if directive_depth > 0 {
        boundary = BoundaryReason::Guarded {
            directive_depth,
            inner: Box::new(boundary),
        };
    }
    if trivia_lines > 0 {
        boundary = BoundaryReason::AttachedTrivia {
            lines: trivia_lines,
            inner: Box::new(boundary),
        };
    }
    Declaration::new(
        DeclarationId(id),
        LineSpan {
            start: start + 1,
            end: end + 1,
        },
        heading(selected),
        text.clone(),
        boundary,
        ambient_opens,
        fnv1a64(text.as_bytes()),
    )
}

pub fn scan_declarations(source: SourceText) -> Result<Program<Scanned>, String> {
    let mut lexical = LexicalState::Code;
    let mut active_opens = Vec::<String>::new();
    let mut declarations = Vec::new();
    let mut current_start = None::<usize>;
    let mut current_kind = DeclarationKind::Other;
    let mut current_trivia = 0usize;
    let mut current_guard_depth = 0usize;
    let mut current_opens = Vec::<String>::new();
    let mut pending_trivia = None::<usize>;
    let mut directive_depth = 0usize;

    for index in (source.module_line + 1)..source.lines.len() {
        let line = &source.lines[index];
        let (next_lexical, sanitized) = sanitize_line(lexical, line);
        lexical = next_lexical;
        let trimmed_original = line.trim();
        let trimmed = sanitized.trim();
        let top_level = lexical == LexicalState::Code && exactly_module_top_level(line);

        if directive_depth == 0 && top_level && trimmed.starts_with("open ") {
            if let Some(start) = current_start.take() {
                declarations.push(declaration(
                    declarations.len(),
                    &source,
                    DeclarationSlice {
                        start,
                        end: pending_trivia.unwrap_or(index),
                        kind: current_kind,
                        trivia_lines: current_trivia,
                        directive_depth: current_guard_depth,
                        ambient_opens: current_opens.clone(),
                    },
                ));
            }
            let open_line = line.trim_end().to_owned();
            record_open(&mut active_opens, open_line);
            pending_trivia = None;
            continue;
        }

        if top_level && trimmed.starts_with("#if") {
            if directive_depth == 0 {
                let start = pending_trivia.take().unwrap_or(index);
                if let Some(previous) = current_start.replace(start) {
                    declarations.push(declaration(
                        declarations.len(),
                        &source,
                        DeclarationSlice {
                            start: previous,
                            end: start,
                            kind: current_kind,
                            trivia_lines: current_trivia,
                            directive_depth: current_guard_depth,
                            ambient_opens: current_opens.clone(),
                        },
                    ));
                }
                current_kind = DeclarationKind::Directive;
                current_trivia = index.saturating_sub(start);
                current_guard_depth = 1;
                current_opens = active_opens.clone();
            }
            directive_depth += 1;
            continue;
        }
        if top_level && trimmed.starts_with("#endif") && directive_depth > 0 {
            directive_depth -= 1;
            continue;
        }
        if directive_depth > 0 {
            continue;
        }

        if is_trivia(trimmed_original) {
            pending_trivia.get_or_insert(index);
            continue;
        }

        if !top_level {
            pending_trivia = None;
            continue;
        }

        let Some(kind) = classify(trimmed) else {
            pending_trivia = None;
            continue;
        };
        let continuation = trimmed.starts_with("and ")
            && matches!(
                current_kind,
                DeclarationKind::TypeGroup | DeclarationKind::LetGroup
            )
            && current_start.is_some();
        if continuation {
            pending_trivia = None;
            continue;
        }

        let start = pending_trivia.take().unwrap_or(index);
        if let Some(previous) = current_start.replace(start) {
            declarations.push(declaration(
                declarations.len(),
                &source,
                DeclarationSlice {
                    start: previous,
                    end: start,
                    kind: current_kind,
                    trivia_lines: current_trivia,
                    directive_depth: current_guard_depth,
                    ambient_opens: current_opens.clone(),
                },
            ));
        }
        current_kind = kind;
        current_trivia = index.saturating_sub(start);
        current_guard_depth = 0;
        current_opens = active_opens.clone();
    }

    if directive_depth != 0 {
        return Err(format!(
            "unbalanced top-level conditional depth {directive_depth} in {}",
            source.path.display()
        ));
    }
    if !matches!(lexical, LexicalState::Code) {
        return Err(format!(
            "unterminated multiline lexical region in {}",
            source.path.display()
        ));
    }
    if let Some(start) = current_start {
        declarations.push(declaration(
            declarations.len(),
            &source,
            DeclarationSlice {
                start,
                end: source.lines.len(),
                kind: current_kind,
                trivia_lines: current_trivia,
                directive_depth: current_guard_depth,
                ambient_opens: current_opens,
            },
        ));
    }
    if declarations.is_empty() {
        return Err(format!(
            "no splittable declarations found in {}",
            source.path.display()
        ));
    }
    Ok(Program::new(source, declarations))
}

fn exact_indent(line: &str, spaces: usize) -> bool {
    let bytes = line.as_bytes();
    bytes.len() >= spaces
        && bytes[..spaces].iter().all(|byte| *byte == b' ')
        && bytes
            .get(spaces)
            .is_some_and(|byte| *byte != b' ' && *byte != b'\t')
}

fn leading_spaces(line: &str) -> usize {
    line.bytes().take_while(|byte| *byte == b' ').count()
}

fn nested_module_name(declaration: &Declaration<Scanned>) -> Option<(usize, usize, String)> {
    let skip = match declaration.scope {
        DeclarationScope::Root => 0,
        DeclarationScope::ModuleFragment { prefix_lines, .. } => prefix_lines,
    };
    declaration
        .text
        .lines()
        .enumerate()
        .skip(skip)
        .find_map(|(index, line)| {
            let indent = leading_spaces(line);
            if indent < 4 || !exact_indent(line, indent) {
                return None;
            }
            let body = line.trim().strip_prefix("module ")?.trim_start();
            let body = body.strip_prefix("rec ").unwrap_or(body);
            let name = body
                .split(|character: char| character == '=' || character.is_whitespace())
                .find(|part| !part.is_empty())?;
            Some((index, indent, name.to_owned()))
        })
}

#[derive(Clone, Debug)]
struct NestedStart {
    start: usize,
    kind: DeclarationKind,
    trivia_lines: usize,
    directive_depth: usize,
    ambient_opens: Vec<String>,
}

fn dedent_open(line: &str, body_indent: usize) -> String {
    let remove = " ".repeat(body_indent.saturating_sub(4));
    line.strip_prefix(&remove)
        .unwrap_or(line)
        .trim_end()
        .to_owned()
}

fn nested_starts(
    lines: &[String],
    header: usize,
    body_indent: usize,
) -> Result<Vec<NestedStart>, String> {
    let mut lexical = LexicalState::Code;
    let mut active_opens = Vec::<String>::new();
    let mut starts = Vec::<NestedStart>::new();
    let mut pending_trivia = None::<usize>;
    let mut directive_depth = 0usize;

    for (index, line) in lines.iter().enumerate().skip(header + 1) {
        let (next_lexical, sanitized) = sanitize_line(lexical, line);
        lexical = next_lexical;
        let trimmed_original = line.trim();
        let trimmed = sanitized.trim();
        let nested_top = lexical == LexicalState::Code && exact_indent(line, body_indent);

        if directive_depth == 0 && nested_top && trimmed.starts_with("open ") {
            let open_line = dedent_open(line, body_indent);
            record_open(&mut active_opens, open_line);
            pending_trivia = None;
            continue;
        }
        if nested_top && trimmed.starts_with("#if") {
            if directive_depth == 0 {
                let start = pending_trivia.take().unwrap_or(index);
                starts.push(NestedStart {
                    start,
                    kind: DeclarationKind::Directive,
                    trivia_lines: index.saturating_sub(start),
                    directive_depth: 1,
                    ambient_opens: active_opens.clone(),
                });
            }
            directive_depth += 1;
            continue;
        }
        if nested_top && trimmed.starts_with("#endif") && directive_depth > 0 {
            directive_depth -= 1;
            continue;
        }
        if directive_depth > 0 {
            continue;
        }
        if is_trivia(trimmed_original) {
            pending_trivia.get_or_insert(index);
            continue;
        }
        if !nested_top {
            pending_trivia = None;
            continue;
        }
        let Some(kind) = classify(trimmed) else {
            pending_trivia = None;
            continue;
        };
        let continuation = trimmed.starts_with("and ")
            && starts.last().is_some_and(|previous| {
                matches!(
                    previous.kind,
                    DeclarationKind::TypeGroup | DeclarationKind::LetGroup
                )
            });
        if continuation {
            pending_trivia = None;
            continue;
        }
        let start = pending_trivia.take().unwrap_or(index);
        starts.push(NestedStart {
            start,
            kind,
            trivia_lines: index.saturating_sub(start),
            directive_depth: 0,
            ambient_opens: active_opens.clone(),
        });
    }
    if directive_depth != 0 {
        return Err(format!(
            "unbalanced nested conditional depth {directive_depth}"
        ));
    }
    if !matches!(lexical, LexicalState::Code) {
        return Err("unterminated nested multiline lexical region".to_owned());
    }
    Ok(starts)
}

fn nested_reason(module_name: &str, ordinal: usize, start: &NestedStart) -> BoundaryReason {
    let mut inner = BoundaryReason::TopLevel(start.kind);
    if start.directive_depth > 0 {
        inner = BoundaryReason::Guarded {
            directive_depth: start.directive_depth,
            inner: Box::new(inner),
        };
    }
    if start.trivia_lines > 0 {
        inner = BoundaryReason::AttachedTrivia {
            lines: start.trivia_lines,
            inner: Box::new(inner),
        };
    }
    BoundaryReason::NestedModule {
        module_name: module_name.to_owned(),
        ordinal,
        inner: Box::new(inner),
    }
}

fn split_nested_module(
    declaration: Declaration<Scanned>,
    max_lines: usize,
) -> Result<Vec<Declaration<Scanned>>, String> {
    if declaration.boundary.kind() != DeclarationKind::Module
        || declaration.line_count() <= max_lines
    {
        return Ok(vec![declaration]);
    }
    let Some((header, header_indent, local_module_name)) = nested_module_name(&declaration) else {
        return Ok(vec![declaration]);
    };
    let module_name = declaration.scope.module_name().map_or_else(
        || local_module_name.clone(),
        |parent| format!("{parent}.{local_module_name}"),
    );
    let body_indent = header_indent + 4;
    let lines = declaration
        .text
        .lines()
        .map(str::to_owned)
        .collect::<Vec<_>>();
    let starts = nested_starts(&lines, header, body_indent)
        .map_err(|error| format!("nested module {module_name}: {error}"))?;
    if starts.len() < 2 {
        return Ok(vec![declaration]);
    }

    let mut fragments = Vec::with_capacity(starts.len());
    for (ordinal, start) in starts.iter().enumerate() {
        let local_start = if ordinal == 0 { 0 } else { start.start };
        let local_end = starts
            .get(ordinal + 1)
            .map_or(lines.len(), |next| next.start);
        let selected = &lines[local_start..local_end];
        let text = format!("{}\n", selected.join("\n"));
        let nested_heading = heading(selected);
        let fragment_heading = if declaration.heading.is_empty() {
            format!("{module_name} / {nested_heading}")
        } else if nested_heading.is_empty() {
            format!("{} / {module_name}", declaration.heading)
        } else {
            format!("{} / {nested_heading}", declaration.heading)
        };
        let mut ambient_opens = declaration.ambient_opens.clone();
        for open_line in &start.ambient_opens {
            record_open(&mut ambient_opens, open_line.clone());
        }
        fragments.push(
            Declaration::new(
                declaration.id,
                LineSpan {
                    start: declaration.span.start + local_start,
                    end: declaration.span.start + local_end,
                },
                fragment_heading,
                text.clone(),
                nested_reason(&module_name, ordinal, start),
                ambient_opens,
                fnv1a64(text.as_bytes()),
            )
            .with_scope(DeclarationScope::ModuleFragment {
                module_name: module_name.clone(),
                ordinal,
                prefix_lines: if ordinal == 0 { start.start } else { 0 },
                dedent_spaces: header_indent,
            }),
        );
    }
    Ok(fragments)
}

fn refine_module_recursive(
    declaration: Declaration<Scanned>,
    max_lines: usize,
    depth: usize,
) -> Result<Vec<Declaration<Scanned>>, String> {
    if depth >= 16 {
        return Err(format!(
            "nested module refinement exceeded depth 16 near {}",
            declaration.heading
        ));
    }
    let fragments = split_nested_module(declaration, max_lines)?;
    if fragments.len() == 1 {
        return Ok(fragments);
    }
    let mut refined = Vec::new();
    for fragment in fragments {
        refined.extend(refine_module_recursive(fragment, max_lines, depth + 1)?);
    }
    Ok(refined)
}

pub fn refine_hopac_modules(
    program: Program<Scanned>,
    max_lines: usize,
) -> Result<Program<Scanned>, String> {
    if program.source.profile != CompilerProfile::Hopac {
        return Ok(program);
    }
    let mut refined = Vec::new();
    for declaration in program.declarations {
        refined.extend(refine_module_recursive(declaration, max_lines, 0)?);
    }
    for (index, declaration) in refined.iter_mut().enumerate() {
        declaration.id = DeclarationId(index);
    }
    Ok(Program::new(program.source, refined))
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{CompilerProfile, SourceText};
    use std::path::PathBuf;

    fn source(text: &str) -> SourceText {
        SourceText {
            path: PathBuf::from("test.fs"),
            lines: text.split('\n').map(str::to_owned).collect(),
            module_line: 1,
            module_name: "spiral_compiler".to_owned(),
            profile: CompilerProfile::PreHopac,
            fingerprint: fnv1a64(text.as_bytes()),
            bytes: text.len(),
        }
    }

    #[test]
    fn keeps_mutual_type_group_together() {
        let program = scan_declarations(source(
            "namespace P\nmodule spiral_compiler =\n    type A = A of B\n    and B = B of A\n    let x = 1",
        ))
        .expect("scan");
        assert_eq!(program.declarations.len(), 2);
        assert!(program.declarations[0].text.contains("and B"));
    }

    #[test]
    fn ambient_open_is_replayed() {
        let program = scan_declarations(source(
            "namespace P\nmodule spiral_compiler =\n    open System\n    let x = DateTime.Now",
        ))
        .expect("scan");
        assert_eq!(
            program.declarations[0].ambient_opens,
            vec!["    open System"]
        );
    }

    #[test]
    fn later_reopen_restores_shadowing_precedence() {
        let program = scan_declarations(source(
            "namespace P\nmodule spiral_compiler =\n    open Hopac.Infixes\n    open FParsec\n    open Hopac.Infixes\n    let x = 1",
        ))
        .expect("scan");
        assert_eq!(
            program.declarations[0].ambient_opens,
            vec!["    open FParsec", "    open Hopac.Infixes"]
        );
    }

    #[test]
    fn nested_reopen_restores_shadowing_precedence() {
        let text = "namespace P\nmodule spiral_compiler =\n    module BigStack =\n        open Hopac.Infixes\n        open FParsec\n        open Hopac.Infixes\n        let x = 1\n        let y = x + 1";
        let mut input = source(text);
        input.profile = CompilerProfile::Hopac;
        let scanned = scan_declarations(input).expect("scan");
        let refined = refine_hopac_modules(scanned, 1).expect("refine");
        let x = refined
            .declarations
            .iter()
            .find(|declaration| declaration.text.contains("let x"))
            .expect("x declaration");
        assert_eq!(
            x.ambient_opens,
            vec!["    open FParsec", "    open Hopac.Infixes"]
        );
    }

    #[test]
    fn hopac_module_is_split_into_internal_declarations() {
        let text = "namespace P\nmodule spiral_compiler =\n    module BigStack =\n        open System\n        type State = { depth : int }\n        let private root = { depth = 0 }\n        let next x = x.depth + root.depth\n    let outside = BigStack.next { depth = 1 }";
        let mut input = source(text);
        input.profile = CompilerProfile::Hopac;
        let scanned = scan_declarations(input).expect("scan");
        let refined = refine_hopac_modules(scanned, 3).expect("refine");
        assert_eq!(refined.declarations.len(), 4);
        assert!(matches!(
            refined.declarations[0].scope,
            DeclarationScope::ModuleFragment {
                ref module_name,
                ordinal: 0,
                prefix_lines: 2,
                dedent_spaces: 4,
            } if module_name == "BigStack"
        ));
        assert_eq!(
            refined.declarations[0].ambient_opens,
            vec!["    open System"]
        );
        assert!(
            refined.declarations[0]
                .text
                .starts_with("    module BigStack")
        );
        assert!(refined.declarations[2].text.contains("let next"));
        let reconstructed = refined
            .declarations
            .iter()
            .map(|declaration| declaration.text.as_str())
            .collect::<String>();
        assert_eq!(
            reconstructed,
            text.lines()
                .skip(2)
                .map(|line| format!("{line}\n"))
                .collect::<String>()
        );
    }

    #[test]
    fn recursively_splits_nested_hopac_modules() {
        let text = "namespace P\nmodule spiral_compiler =\n    module Outer =\n        let a = 1\n        module Inner =\n            let b = a + 1\n            let c = b + 1\n        let d = Inner.c\n    let outside = Outer.d";
        let mut input = source(text);
        input.profile = CompilerProfile::Hopac;
        let scanned = scan_declarations(input).expect("scan");
        let refined = refine_hopac_modules(scanned, 2).expect("refine");
        assert_eq!(refined.declarations.len(), 5);
        assert!(refined.declarations.iter().any(|declaration| {
            matches!(
                &declaration.scope,
                DeclarationScope::ModuleFragment {
                    module_name,
                    dedent_spaces: 8,
                    ..
                } if module_name == "Outer.Inner"
            )
        }));
        let reconstructed = refined
            .declarations
            .iter()
            .map(|declaration| declaration.text.as_str())
            .collect::<String>();
        assert_eq!(
            reconstructed,
            text.lines()
                .skip(2)
                .map(|line| format!("{line}\n"))
                .collect::<String>()
        );
    }

    #[test]
    fn non_hopac_module_remains_atomic() {
        let text = "namespace P\nmodule spiral_compiler =\n    module Big =\n        let a = 1\n        let b = a + 1";
        let scanned = scan_declarations(source(text)).expect("scan");
        let refined = refine_hopac_modules(scanned, 2).expect("refine");
        assert_eq!(refined.declarations.len(), 1);
        assert!(matches!(
            refined.declarations[0].scope,
            DeclarationScope::Root
        ));
    }
}
