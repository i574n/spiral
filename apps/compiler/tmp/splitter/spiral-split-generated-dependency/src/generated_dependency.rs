use rayon::prelude::*;
use spiral_split_fsharp_lex::character_literal_starts;
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::path::Path;

const PART_PREFIX: &[u8] = b"spiral_compiler_Part";

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct GeneratedDependency {
    pub consumer_shard: usize,
    pub provider_shard: usize,
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum LexicalState {
    Code,
    String,
    VerbatimString,
    BlockComment(usize),
}

fn code_projection(text: &str) -> String {
    let bytes = text.as_bytes();
    let mut projected = Vec::with_capacity(bytes.len());
    let mut state = LexicalState::Code;
    let mut index = 0usize;
    while index < bytes.len() {
        match state {
            LexicalState::Code => {
                if bytes[index..].starts_with(b"//") {
                    while index < bytes.len() && bytes[index] != b'\n' {
                        projected.push(b' ');
                        index += 1;
                    }
                } else if bytes[index..].starts_with(b"(*") {
                    projected.extend_from_slice(b"  ");
                    index += 2;
                    state = LexicalState::BlockComment(1);
                } else if bytes[index..].starts_with(b"@\"") {
                    projected.extend_from_slice(b"  ");
                    index += 2;
                    state = LexicalState::VerbatimString;
                } else if character_literal_starts(bytes, index) {
                    // A char literal such as '"' must not open a string: that blanked everything up to
                    // the next quote, hid a `type` declared there, and made its name look unique.
                    let mut end = index + 1;
                    if bytes[end] == b'\\' {
                        end += 2;
                    }
                    while end < bytes.len() && bytes[end] != b'\'' {
                        end += 1;
                    }
                    let end = (end + 1).min(bytes.len());
                    projected.extend(std::iter::repeat_n(b' ', end - index));
                    index = end;
                } else if bytes[index] == b'"' {
                    projected.push(b' ');
                    index += 1;
                    state = LexicalState::String;
                } else {
                    projected.push(bytes[index]);
                    index += 1;
                }
            }
            LexicalState::String => {
                if bytes[index] == b'\\' && index + 1 < bytes.len() {
                    projected.extend_from_slice(b"  ");
                    index += 2;
                } else {
                    let closing = bytes[index] == b'"';
                    projected.push(if bytes[index] == b'\n' { b'\n' } else { b' ' });
                    index += 1;
                    if closing {
                        state = LexicalState::Code;
                    }
                }
            }
            LexicalState::VerbatimString => {
                if bytes[index..].starts_with(b"\"\"") {
                    projected.extend_from_slice(b"  ");
                    index += 2;
                } else {
                    let closing = bytes[index] == b'"';
                    projected.push(if bytes[index] == b'\n' { b'\n' } else { b' ' });
                    index += 1;
                    if closing {
                        state = LexicalState::Code;
                    }
                }
            }
            LexicalState::BlockComment(depth) => {
                if bytes[index..].starts_with(b"(*") {
                    projected.extend_from_slice(b"  ");
                    index += 2;
                    state = LexicalState::BlockComment(depth + 1);
                } else if bytes[index..].starts_with(b"*)") {
                    projected.extend_from_slice(b"  ");
                    index += 2;
                    state = if depth == 1 {
                        LexicalState::Code
                    } else {
                        LexicalState::BlockComment(depth - 1)
                    };
                } else {
                    projected.push(if bytes[index] == b'\n' { b'\n' } else { b' ' });
                    index += 1;
                }
            }
        }
    }
    String::from_utf8(projected).expect("projection preserves UTF-8 byte structure")
}

fn part_references(text: &str) -> BTreeSet<usize> {
    let code = code_projection(text);
    let bytes = code.as_bytes();
    let mut references = BTreeSet::new();
    let mut cursor = 0usize;
    while cursor + PART_PREFIX.len() < bytes.len() {
        let Some(relative) = bytes[cursor..]
            .windows(PART_PREFIX.len())
            .position(|window| window == PART_PREFIX)
        else {
            break;
        };
        let start = cursor + relative + PART_PREFIX.len();
        let end = bytes[start..]
            .iter()
            .position(|byte| !byte.is_ascii_digit())
            .map_or(bytes.len(), |relative_end| start + relative_end);
        if start < end
            && let Ok(value) = code[start..end].parse::<usize>()
        {
            references.insert(value);
        }
        cursor = end.max(start + 1);
    }
    references
}

fn generated_identifier_ranges(code: &str) -> Vec<(usize, usize, String)> {
    let bytes = code.as_bytes();
    let mut ranges = Vec::new();
    let mut index = 0usize;
    while index < bytes.len() {
        let byte = bytes[index];
        if byte != b'_' && !byte.is_ascii_alphabetic() {
            index += 1;
            continue;
        }
        let start = index;
        index += 1;
        while index < bytes.len()
            && (bytes[index] == b'_'
                || bytes[index] == b'\''
                || bytes[index].is_ascii_alphanumeric())
        {
            index += 1;
        }
        let name = &code[start..index];
        if name.starts_with("__spiral_lift_") {
            ranges.push((start, index, name.to_owned()));
        }
    }
    ranges
}

fn generated_definition_ranges(code: &str) -> Vec<(usize, usize, String)> {
    let mut ranges = Vec::new();
    let mut offset = 0usize;
    for line in code.split_inclusive('\n') {
        let bytes = line.as_bytes();
        let mut index = bytes.iter().take_while(|byte| **byte == b' ').count();
        if bytes.get(index..index + 4) == Some(b"let ")
            || bytes.get(index..index + 4) == Some(b"and ")
        {
            index += 4;
        } else {
            offset += line.len();
            continue;
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
        if !bytes
            .get(index)
            .copied()
            .is_some_and(|byte| byte == b'_' || byte.is_ascii_alphabetic())
        {
            offset += line.len();
            continue;
        }
        index += 1;
        while index < bytes.len()
            && (bytes[index] == b'_'
                || bytes[index] == b'\''
                || bytes[index].is_ascii_alphanumeric())
        {
            index += 1;
        }
        let name = &line[start..index];
        if name.starts_with("__spiral_lift_") {
            ranges.push((offset + start, offset + index, name.to_owned()));
        }
        offset += line.len();
    }
    ranges
}

fn qualified_generated_provider_before_identifier(code: &str, start: usize) -> Option<usize> {
    if start == 0 || code.as_bytes().get(start - 1) != Some(&b'.') {
        return None;
    }
    let digits_end = start - 1;
    let mut digits_start = digits_end;
    while digits_start > 0 && code.as_bytes()[digits_start - 1].is_ascii_digit() {
        digits_start -= 1;
    }
    if digits_start == digits_end {
        return None;
    }
    let prefix_start = digits_start.checked_sub(PART_PREFIX.len())?;
    if code.as_bytes().get(prefix_start..digits_start) != Some(PART_PREFIX) {
        return None;
    }
    code[digits_start..digits_end].parse::<usize>().ok()
}

fn raw_line_allows_code_identifier(text: &str, start: usize) -> bool {
    let line_start = text[..start].rfind('\n').map_or(0, |position| position + 1);
    let prefix = &text[line_start..start];
    if prefix.contains("//") {
        return false;
    }
    let mut escaped = false;
    let mut in_string = false;
    for byte in prefix.bytes() {
        if byte == b'\\' && !escaped {
            escaped = true;
            continue;
        }
        if byte == b'\"' && !escaped {
            in_string = !in_string;
        }
        escaped = false;
    }
    !in_string
}

fn qualify_generated_helper_texts_raw_fallback(
    texts: &mut [String],
    dependencies: &mut BTreeSet<(usize, usize)>,
) -> Result<(), String> {
    let definitions = texts
        .iter()
        .map(|text| generated_definition_ranges(text))
        .collect::<Vec<_>>();
    let mut providers = BTreeMap::<String, Vec<usize>>::new();
    for (shard, ranges) in definitions.iter().enumerate() {
        for (_, _, name) in ranges {
            providers.entry(name.clone()).or_default().push(shard);
        }
    }

    for shard in 0..texts.len() {
        let definition_positions = definitions[shard]
            .iter()
            .map(|(start, end, _)| (*start, *end))
            .collect::<BTreeSet<_>>();
        let code = &texts[shard];
        let mut replacements = Vec::<(usize, usize, String)>::new();
        for (start, end, name) in generated_identifier_ranges(code) {
            if definition_positions.contains(&(start, end)) {
                continue;
            }
            if !raw_line_allows_code_identifier(code, start) {
                continue;
            }
            if let Some(provider) = qualified_generated_provider_before_identifier(code, start) {
                if provider != shard {
                    let Some(candidates) = providers.get(&name) else {
                        return Err(format!(
                            "qualified generated helper {name} references unknown provider shard {provider}"
                        ));
                    };
                    if !candidates.contains(&provider) {
                        return Err(format!(
                            "qualified generated helper {name} references shard {provider}, but providers are {:?}",
                            candidates
                        ));
                    }
                    dependencies.insert((shard, provider));
                }
                continue;
            }
            if start > 0 && code.as_bytes()[start - 1] == b'.' {
                continue;
            }
            let Some(candidates) = providers.get(&name) else {
                continue;
            };
            if candidates.len() != 1 {
                return Err(format!(
                    "ambiguous generated helper provider {name}: {:?}",
                    candidates
                ));
            }
            let provider = candidates[0];
            if provider == shard {
                continue;
            }
            dependencies.insert((shard, provider));
            replacements.push((
                start,
                end,
                format!("spiral_compiler_Part{provider:04}.{name}"),
            ));
        }
        if replacements.is_empty() {
            continue;
        }
        let mut rewritten = texts[shard].clone();
        for (start, end, replacement) in replacements.into_iter().rev() {
            rewritten.replace_range(start..end, &replacement);
        }
        texts[shard] = rewritten;
    }
    Ok(())
}

fn qualify_generated_helper_texts(
    texts: &mut [String],
) -> Result<Vec<GeneratedDependency>, String> {
    let projections = texts
        .iter()
        .map(|text| code_projection(text))
        .collect::<Vec<_>>();
    let definitions = projections
        .iter()
        .map(|code| generated_definition_ranges(code))
        .collect::<Vec<_>>();
    let mut providers = BTreeMap::<String, Vec<usize>>::new();
    for (shard, ranges) in definitions.iter().enumerate() {
        for (_, _, name) in ranges {
            providers.entry(name.clone()).or_default().push(shard);
        }
    }

    let mut dependencies = BTreeSet::<(usize, usize)>::new();
    for shard in 0..texts.len() {
        let definition_positions = definitions[shard]
            .iter()
            .map(|(start, end, _)| (*start, *end))
            .collect::<BTreeSet<_>>();
        let code = &projections[shard];
        let mut replacements = Vec::<(usize, usize, String)>::new();
        for (start, end, name) in generated_identifier_ranges(code) {
            if definition_positions.contains(&(start, end)) {
                continue;
            }
            if let Some(provider) = qualified_generated_provider_before_identifier(code, start) {
                if provider != shard {
                    let Some(candidates) = providers.get(&name) else {
                        return Err(format!(
                            "qualified generated helper {name} references unknown provider shard {provider}"
                        ));
                    };
                    if !candidates.contains(&provider) {
                        return Err(format!(
                            "qualified generated helper {name} references shard {provider}, but providers are {:?}",
                            candidates
                        ));
                    }
                    dependencies.insert((shard, provider));
                }
                continue;
            }
            if start > 0 && code.as_bytes()[start - 1] == b'.' {
                continue;
            }
            let Some(candidates) = providers.get(&name) else {
                continue;
            };
            if candidates.len() != 1 {
                return Err(format!(
                    "ambiguous generated helper provider {name}: {:?}",
                    candidates
                ));
            }
            let provider = candidates[0];
            if provider == shard {
                continue;
            }
            dependencies.insert((shard, provider));
            replacements.push((
                start,
                end,
                format!("spiral_compiler_Part{provider:04}.{name}"),
            ));
        }
        if replacements.is_empty() {
            continue;
        }
        let mut rewritten = texts[shard].clone();
        for (start, end, replacement) in replacements.into_iter().rev() {
            rewritten.replace_range(start..end, &replacement);
        }
        texts[shard] = rewritten;
    }

    qualify_generated_helper_texts_raw_fallback(texts, &mut dependencies)?;

    Ok(dependencies
        .into_iter()
        .map(|(consumer_shard, provider_shard)| GeneratedDependency {
            consumer_shard,
            provider_shard,
        })
        .collect())
}

fn top_level_type_names(code: &str) -> Vec<String> {
    let mut names = Vec::new();
    for line in code.lines() {
        let trimmed = line.trim_start();
        let Some(rest) = trimmed.strip_prefix("type ") else {
            continue;
        };
        let bytes = rest.as_bytes();
        let Some(first) = bytes.first().copied() else {
            continue;
        };
        if first != b'_' && !first.is_ascii_alphabetic() {
            continue;
        }
        let mut end = 1usize;
        while end < bytes.len()
            && (bytes[end] == b'_' || bytes[end] == b'\'' || bytes[end].is_ascii_alphanumeric())
        {
            end += 1;
        }
        names.push(rest[..end].to_owned());
    }
    names
}

fn opened_part_references(code: &str) -> BTreeSet<usize> {
    let mut references = BTreeSet::new();
    for line in code.lines() {
        let trimmed = line.trim_start();
        let Some(rest) = trimmed.strip_prefix("open spiral_compiler_Part") else {
            continue;
        };
        let digits = rest
            .bytes()
            .take_while(|byte| byte.is_ascii_digit())
            .count();
        if digits == 0 {
            continue;
        }
        if let Ok(provider) = rest[..digits].parse::<usize>() {
            references.insert(provider);
        }
    }
    references
}

fn type_annotation_identifier_ranges(code: &str) -> Vec<(usize, usize, String)> {
    let bytes = code.as_bytes();
    let mut ranges = Vec::new();
    let mut index = 0usize;
    while index < bytes.len() {
        if bytes[index] != b':' || bytes.get(index + 1) == Some(&b':') {
            index += 1;
            continue;
        }
        let mut start = index + 1;
        while start < bytes.len() && bytes[start].is_ascii_whitespace() {
            start += 1;
        }
        let Some(first) = bytes.get(start).copied() else {
            break;
        };
        if first != b'_' && !first.is_ascii_alphabetic() {
            index += 1;
            continue;
        }
        let mut end = start + 1;
        while end < bytes.len()
            && (bytes[end] == b'_' || bytes[end] == b'\'' || bytes[end].is_ascii_alphanumeric())
        {
            end += 1;
        }
        ranges.push((start, end, code[start..end].to_owned()));
        index = end;
    }
    ranges
}

fn qualify_unique_type_annotation_texts(
    texts: &mut [String],
) -> Result<Vec<GeneratedDependency>, String> {
    let projections = texts
        .iter()
        .map(|text| code_projection(text))
        .collect::<Vec<_>>();
    let mut providers = BTreeMap::<String, BTreeSet<usize>>::new();
    for (shard, code) in projections.iter().enumerate() {
        for name in top_level_type_names(code) {
            providers.entry(name).or_default().insert(shard);
        }
    }

    let unique = providers
        .into_iter()
        .filter_map(|(name, shards)| {
            (shards.len() == 1).then(|| (name, *shards.first().expect("one provider")))
        })
        .collect::<BTreeMap<_, _>>();
    let mut dependencies = BTreeSet::<(usize, usize)>::new();
    for shard in 0..texts.len() {
        let code = &projections[shard];
        let opened = opened_part_references(code);
        let mut replacements = Vec::<(usize, usize, String)>::new();
        for (start, end, name) in type_annotation_identifier_ranges(code) {
            let Some(provider) = unique.get(&name).copied() else {
                continue;
            };
            if provider == shard || opened.contains(&provider) {
                continue;
            }
            dependencies.insert((shard, provider));
            replacements.push((
                start,
                end,
                format!("spiral_compiler_Part{provider:04}.{name}"),
            ));
        }
        if replacements.is_empty() {
            continue;
        }
        let mut rewritten = texts[shard].clone();
        for (start, end, replacement) in replacements.into_iter().rev() {
            rewritten.replace_range(start..end, &replacement);
        }
        texts[shard] = rewritten;
    }

    Ok(dependencies
        .into_iter()
        .map(|(consumer_shard, provider_shard)| GeneratedDependency {
            consumer_shard,
            provider_shard,
        })
        .collect())
}

pub fn qualify_unique_type_annotation_references(
    output_root: &Path,
    shard_count: usize,
) -> Result<Vec<GeneratedDependency>, String> {
    let mut texts = (0..shard_count)
        .map(|shard| {
            let path = output_root.join(format!("Part{shard:04}.fs"));
            fs::read_to_string(&path).map_err(|error| format!("read {}: {error}", path.display()))
        })
        .collect::<Result<Vec<_>, String>>()?;
    let before = texts.clone();
    let dependencies = qualify_unique_type_annotation_texts(&mut texts)?;
    for (shard, (original, rewritten)) in before.iter().zip(&texts).enumerate() {
        if original == rewritten {
            continue;
        }
        let path = output_root.join(format!("Part{shard:04}.fs"));
        let temporary = path.with_extension("fs.tmp");
        fs::write(&temporary, rewritten)
            .map_err(|error| format!("write {}: {error}", temporary.display()))?;
        fs::rename(&temporary, &path)
            .map_err(|error| format!("commit {}: {error}", path.display()))?;
    }
    Ok(dependencies)
}

pub fn qualify_generated_helper_references(
    output_root: &Path,
    shard_count: usize,
) -> Result<Vec<GeneratedDependency>, String> {
    let mut texts = (0..shard_count)
        .map(|shard| {
            let path = output_root.join(format!("Part{shard:04}.fs"));
            fs::read_to_string(&path).map_err(|error| format!("read {}: {error}", path.display()))
        })
        .collect::<Result<Vec<_>, String>>()?;
    let before = texts.clone();
    let dependencies = qualify_generated_helper_texts(&mut texts)?;
    for (shard, (original, rewritten)) in before.iter().zip(&texts).enumerate() {
        if original == rewritten {
            continue;
        }
        let path = output_root.join(format!("Part{shard:04}.fs"));
        let temporary = path.with_extension("fs.tmp");
        fs::write(&temporary, rewritten)
            .map_err(|error| format!("write {}: {error}", temporary.display()))?;
        fs::rename(&temporary, &path)
            .map_err(|error| format!("commit {}: {error}", path.display()))?;
    }
    Ok(dependencies)
}

pub fn scan_generated_dependencies(
    output_root: &Path,
    shard_count: usize,
) -> Result<Vec<GeneratedDependency>, String> {
    let rows = (0..shard_count)
        .into_par_iter()
        .map(|consumer_shard| {
            let path = output_root.join(format!("Part{consumer_shard:04}.fs"));
            let text = fs::read_to_string(&path)
                .map_err(|error| format!("read {}: {error}", path.display()))?;
            Ok(part_references(&text)
                .into_iter()
                .filter(move |provider_shard| {
                    *provider_shard < shard_count && *provider_shard != consumer_shard
                })
                .map(move |provider_shard| GeneratedDependency {
                    consumer_shard,
                    provider_shard,
                })
                .collect::<Vec<_>>())
        })
        .collect::<Result<Vec<_>, String>>()?;
    Ok(rows.into_iter().flatten().collect())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn qualified_generated_part_references_are_retained() {
        let references = part_references(
            "module spiral_compiler_Part1505\n\
             type T = spiral_compiler_Part0585.Alias\n\
             open spiral_compiler_Part0574\n",
        );
        assert_eq!(references, BTreeSet::from([574, 585, 1505]));
    }

    #[test]
    fn char_literal_quote_does_not_hide_a_type_declaration() {
        // Two parts declare `Key`; the second declares it after a '"' char literal. The name is not
        // unique, so a third part's annotation must stay as written.
        let mut texts = vec![
            "module spiral_compiler_Part0000 =\n    type Key<'K> = { node: string }\n".to_owned(),
            "module spiral_compiler_Part0001 =\n    let separators = [| ':'; '\"'; '\\'' |]\n    type Key<'Kind> =\n        | Node of int\n"
                .to_owned(),
            "module spiral_compiler_Part0002 =\n    type Graph = | Term of key: Key<int>\n".to_owned(),
        ];
        let dependencies = qualify_unique_type_annotation_texts(&mut texts).expect("qualify");
        assert!(dependencies.is_empty());
        assert!(texts[2].contains("key: Key<int>"));
    }

    #[test]
    fn strings_and_comments_do_not_create_dependencies() {
        let references = part_references(
            "let telemetry = \"sink=spiral_compiler_Part0257.emit\"\n\
             let verbatim = @\"spiral_compiler_Part0300.value\"\n\
             // spiral_compiler_Part0400.value\n\
             (* spiral_compiler_Part0500.value *)\n\
             let actual : spiral_compiler_Part0585.Alias = value\n",
        );
        assert_eq!(references, BTreeSet::from([585]));
    }

    #[test]
    fn malformed_and_unrelated_suffixes_are_ignored() {
        let references = part_references(
            "spiral_compiler_Part nope\nspiral_compiler_Part0042.value\nother_Part0043\n",
        );
        assert_eq!(references, BTreeSet::from([42]));
    }

    #[test]
    fn qualifies_cross_part_generated_helper_reference() {
        let helper = "__spiral_lift_9891_232_jpRunDeclaredContinuationLookup";
        let mut texts = vec![
            format!(
                "module spiral_compiler_Part0000\nlet consume job lookup run = {helper} job lookup run\n"
            ),
            format!("module spiral_compiler_Part0001\nlet {helper} job lookup run = run lookup\n"),
        ];
        let dependencies = qualify_generated_helper_texts(&mut texts).expect("qualification");
        assert_eq!(
            dependencies,
            vec![GeneratedDependency {
                consumer_shard: 0,
                provider_shard: 1,
            }]
        );
        assert!(texts[0].contains(&format!("spiral_compiler_Part0001.{helper} job lookup run")));
        assert!(texts[1].contains(&format!("let {helper} job lookup run")));
    }

    #[test]
    fn qualifies_generated_helper_inside_generated_helper_body() {
        let outer = "__spiral_lift_10115_59_outer";
        let worker = "__spiral_lift_10132_108_term2";
        let worker_tick = "__spiral_lift_10132_107_global'";
        let mut texts = vec![
            format!(
                "module spiral_compiler_Part0000\nlet {outer} term s fmt str =\n    let fmt,str = ({worker} term) s fmt str\n    ({worker_tick} s) str\n"
            ),
            format!("module spiral_compiler_Part0001\nlet {worker_tick} s str = str\n"),
            format!(
                "module spiral_compiler_Part0002\nlet {worker} term s a b = term s a, term s b\n"
            ),
        ];
        let dependencies = qualify_generated_helper_texts(&mut texts).expect("qualification");
        assert_eq!(
            dependencies,
            vec![
                GeneratedDependency {
                    consumer_shard: 0,
                    provider_shard: 1,
                },
                GeneratedDependency {
                    consumer_shard: 0,
                    provider_shard: 2,
                },
            ]
        );
        assert!(texts[0].contains(&format!("spiral_compiler_Part0002.{worker} term")));
        assert!(texts[0].contains(&format!("spiral_compiler_Part0001.{worker_tick} s")));
    }

    #[test]
    fn generated_helper_qualification_is_lexical_and_idempotent() {
        let helper = "__spiral_lift_worker";
        let original = format!(
            "module spiral_compiler_Part0000\nlet text = \"{helper}\"\n// {helper}\nlet consume x = spiral_compiler_Part0001.{helper} x\n"
        );
        let mut texts = vec![
            original.clone(),
            format!("module spiral_compiler_Part0001\nlet {helper} x = x\n"),
        ];
        let dependencies = qualify_generated_helper_texts(&mut texts).expect("qualification");
        assert_eq!(
            dependencies,
            vec![GeneratedDependency {
                consumer_shard: 0,
                provider_shard: 1,
            }]
        );
        assert_eq!(texts[0], original);
        let second = qualify_generated_helper_texts(&mut texts).expect("second qualification");
        assert_eq!(
            second,
            vec![GeneratedDependency {
                consumer_shard: 0,
                provider_shard: 1,
            }]
        );
        assert_eq!(texts[0], original);
    }

    #[test]
    fn qualifies_unique_cross_part_type_annotation() {
        let mut texts = vec![
            "module spiral_compiler_Part0000\nlet consume () =\n    let (runtime : ServerRuntime) = newServerCore ()\n    runtime\n".to_owned(),
            "module spiral_compiler_Part0001\ntype ServerRuntime() = class end\n".to_owned(),
        ];
        let dependencies = qualify_unique_type_annotation_texts(&mut texts).expect("qualification");
        assert_eq!(
            dependencies,
            vec![GeneratedDependency {
                consumer_shard: 0,
                provider_shard: 1,
            }]
        );
        assert!(texts[0].contains("runtime : spiral_compiler_Part0001.ServerRuntime"));
    }

    #[test]
    fn open_provider_keeps_type_annotation_unqualified() {
        let original = "module spiral_compiler_Part0000\nopen spiral_compiler_Part0001\nlet consume (runtime : ServerRuntime) = runtime\n".to_owned();
        let mut texts = vec![
            original.clone(),
            "module spiral_compiler_Part0001\ntype ServerRuntime() = class end\n".to_owned(),
        ];
        let dependencies = qualify_unique_type_annotation_texts(&mut texts).expect("qualification");
        assert!(dependencies.is_empty());
        assert_eq!(texts[0], original);
    }

    #[test]
    fn type_annotation_qualification_ignores_strings_comments_and_is_idempotent() {
        let original = "module spiral_compiler_Part0000\nlet text = \"x : ServerRuntime\"\n// let fake : ServerRuntime = value\nlet consume (runtime : spiral_compiler_Part0001.ServerRuntime) = runtime\n".to_owned();
        let mut texts = vec![
            original.clone(),
            "module spiral_compiler_Part0001\ntype ServerRuntime() = class end\n".to_owned(),
        ];
        let dependencies = qualify_unique_type_annotation_texts(&mut texts).expect("qualification");
        assert!(dependencies.is_empty());
        assert_eq!(texts[0], original);
        let second =
            qualify_unique_type_annotation_texts(&mut texts).expect("second qualification");
        assert!(second.is_empty());
        assert_eq!(texts[0], original);
    }
}
