use super::{AnonymousRecordAlias, alias_name, assigned_field_names, atomic_write, record_shape};
use spiral_split_bridge_index::anonymous_record_spans;
use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::path::Path;

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
enum IdentityKind {
    Direct,
    Wrapped,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct IdentityCandidate {
    provider: usize,
    owner: String,
    name: String,
    anonymous_type: String,
    fields: BTreeSet<String>,
    kind: IdentityKind,
}

fn normalized(text: &str) -> String {
    text.chars()
        .filter(|character| !character.is_whitespace())
        .collect()
}

fn owner_before_span(text: &str, span_start: usize) -> Option<String> {
    text[..span_start].lines().rev().find_map(|line| {
        let trimmed = line.trim_start();
        let remainder = trimmed
            .strip_prefix("type ")
            .or_else(|| trimmed.strip_prefix("and "))?;
        let owner = remainder
            .split(|character: char| {
                character.is_whitespace() || character == '=' || character == '<'
            })
            .next()
            .unwrap_or_default();
        (!owner.is_empty()).then(|| owner.to_owned())
    })
}

fn anonymous_span_begins_owner_rhs(text: &str, owner_start: usize, span_start: usize) -> bool {
    let owner_prefix = &text[owner_start..span_start];
    owner_prefix
        .find('=')
        .is_some_and(|equals| owner_prefix[equals + 1..].trim().is_empty())
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct UnionListIdentityCandidate {
    provider: usize,
    owner: String,
    case_name: String,
    name: String,
    anonymous_type: String,
    fields: BTreeSet<String>,
}

fn union_case_name_before_span(text: &str, span_start: usize) -> Option<String> {
    let line_start = text[..span_start].rfind('\n').map_or(0, |index| index + 1);
    let prefix = text[line_start..span_start].trim();
    let body = prefix.strip_prefix('|')?.trim();
    let case_name = body.strip_suffix(" of")?.trim();
    super::valid_identifier(case_name).then(|| case_name.to_owned())
}

fn union_list_identity_candidates(plan: &SplitPlan) -> Vec<UnionListIdentityCandidate> {
    let mut result = Vec::new();
    for shard in &plan.shards {
        for declaration_id in &shard.declarations {
            let Some(declaration) = plan.declarations.get(declaration_id.0) else {
                continue;
            };
            for (start, end) in anonymous_record_spans(&declaration.text) {
                let line_end = declaration.text[end..]
                    .find('\n')
                    .map_or(declaration.text.len(), |offset| end + offset);
                let suffix = declaration.text[end..line_end]
                    .split_once("//")
                    .map_or(&declaration.text[end..line_end], |(before, _)| before)
                    .trim();
                if suffix != "list" {
                    continue;
                }
                let Some(owner) = owner_before_span(&declaration.text, start) else {
                    continue;
                };
                let Some(case_name) = union_case_name_before_span(&declaration.text, start) else {
                    continue;
                };
                let anonymous_fields = &declaration.text[start + 2..end - 2];
                if !anonymous_fields.contains(':') {
                    continue;
                }
                let Some(fields) = record_shape(anonymous_fields) else {
                    continue;
                };
                result.push(UnionListIdentityCandidate {
                    provider: shard.id,
                    name: format!("SpiralSplitAnon_{owner}_{case_name}_Value"),
                    owner,
                    case_name,
                    anonymous_type: declaration.text[start..end].to_owned(),
                    fields,
                });
            }
        }
    }
    result
}

fn rewrite_union_list_provider(text: &str, candidate: &UnionListIdentityCandidate) -> String {
    if text.contains(&format!("type {} =", candidate.name))
        || text.contains(&format!("and {} =", candidate.name))
    {
        return text.to_owned();
    }
    let Some((begin, end, indentation)) = declaration_range(text, &candidate.owner) else {
        return text.to_owned();
    };
    let body = &text[begin..end];
    let marker = format!("| {} of", candidate.case_name);
    let Some(case_offset) = body.find(&marker) else {
        return text.to_owned();
    };
    let Some(relative_anon) = body[case_offset..].find(&candidate.anonymous_type) else {
        return text.to_owned();
    };
    let anon_start = case_offset + relative_anon;
    let anon_end = anon_start + candidate.anonymous_type.len();
    let mut rewritten_body = body.to_owned();
    rewritten_body.replace_range(anon_start..anon_end, &candidate.name);
    let keyword = if text[begin..].trim_start().starts_with("and ") {
        "and"
    } else {
        "type"
    };
    let alias = format!(
        "{indentation}{keyword} {} = {}\n\n",
        candidate.name, candidate.anonymous_type
    );
    let mut output = String::with_capacity(text.len() + alias.len());
    output.push_str(&text[..begin]);
    output.push_str(&alias);
    output.push_str(&rewritten_body);
    output.push_str(&text[end..]);
    output
}

fn annotate_union_list_literals(
    text: &str,
    consumer_shard: usize,
    candidates: &[UnionListIdentityCandidate],
) -> String {
    let mut by_fields = BTreeMap::<BTreeSet<String>, Vec<&UnionListIdentityCandidate>>::new();
    for candidate in candidates {
        by_fields
            .entry(candidate.fields.clone())
            .or_default()
            .push(candidate);
    }
    let mut replacements = Vec::<(usize, usize, String)>::new();
    for (start, end) in anonymous_record_spans(text) {
        let content = &text[start + 2..end - 2];
        let assigned = assigned_field_names(content);
        if assigned.is_empty() {
            continue;
        }
        let fields = assigned
            .into_iter()
            .map(str::to_owned)
            .collect::<BTreeSet<_>>();
        let Some(matching) = by_fields.get(&fields) else {
            continue;
        };
        if matching.len() != 1 {
            continue;
        }
        let candidate = matching[0];
        let suffix = text[end..].trim_start();
        if suffix.starts_with(':') {
            continue;
        }
        let alias = if consumer_shard == candidate.provider {
            candidate.name.clone()
        } else {
            format!(
                "spiral_compiler_Part{:04}.{}",
                candidate.provider, candidate.name
            )
        };
        replacements.push((start, end, format!("({} : {alias})", &text[start..end])));
    }
    let mut output = text.to_owned();
    for (start, end, replacement) in replacements.into_iter().rev() {
        output.replace_range(start..end, &replacement);
    }
    output
}

fn materialize_union_list_identities(
    plan: &SplitPlan,
    output_root: &Path,
) -> Result<(usize, Vec<AnonymousRecordAlias>), String> {
    let candidates = union_list_identity_candidates(plan);
    if candidates.is_empty() {
        return Ok((0, Vec::new()));
    }
    let mut changed = 0usize;
    for candidate in &candidates {
        let path = output_root.join(format!("Part{:04}.fs", candidate.provider));
        let text = fs::read_to_string(&path)
            .map_err(|error| format!("read {}: {error}", path.display()))?;
        let rewritten = rewrite_union_list_provider(&text, candidate);
        if rewritten != text {
            atomic_write(&path, &rewritten)?;
            changed += 1;
        }
    }
    for shard in &plan.shards {
        let path = output_root.join(format!("Part{:04}.fs", shard.id));
        let text = fs::read_to_string(&path)
            .map_err(|error| format!("read {}: {error}", path.display()))?;
        let rewritten = annotate_union_list_literals(&text, shard.id, &candidates);
        if rewritten != text {
            atomic_write(&path, &rewritten)?;
            changed += 1;
        }
    }
    let aliases = candidates
        .into_iter()
        .map(|candidate| AnonymousRecordAlias {
            provider_shard: candidate.provider,
            name: candidate.name,
            fields: candidate.fields,
        })
        .collect();
    Ok((changed, aliases))
}

fn candidates(plan: &SplitPlan) -> Vec<IdentityCandidate> {
    let mut result = Vec::new();
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            let Some(declaration) = plan.declarations.get(declaration.0) else {
                continue;
            };
            let Some((start, end)) = anonymous_record_spans(&declaration.text)
                .into_iter()
                .max_by_key(|(start, end)| end - start)
            else {
                continue;
            };
            let Some(owner) = owner_before_span(&declaration.text, start)
                .or_else(|| alias_name(&declaration.text))
            else {
                continue;
            };
            let Some((owner_start, owner_end, _)) = declaration_range(&declaration.text, &owner)
            else {
                continue;
            };
            if start < owner_start || end > owner_end {
                continue;
            }
            if !anonymous_span_begins_owner_rhs(&declaration.text, owner_start, start) {
                continue;
            }
            let anonymous_fields = &declaration.text[start + 2..end - 2];
            if !anonymous_fields.contains(':') {
                continue;
            }
            let anonymous_type = declaration.text[start..end].to_owned();
            let Some(fields) = record_shape(anonymous_fields) else {
                continue;
            };
            let suffix = declaration.text[end..].trim();
            let kind = if suffix.is_empty() || suffix.starts_with("//") {
                IdentityKind::Direct
            } else {
                IdentityKind::Wrapped
            };
            let name = match kind {
                IdentityKind::Direct => owner.clone(),
                IdentityKind::Wrapped => format!("SpiralSplitAnon_{owner}_Value"),
            };
            result.push(IdentityCandidate {
                provider: shard.id,
                owner,
                name,
                anonymous_type,
                fields,
                kind,
            });
        }
    }
    result
}

fn canonical(candidates: &[IdentityCandidate]) -> BTreeMap<String, IdentityCandidate> {
    let mut result = BTreeMap::<String, IdentityCandidate>::new();
    for candidate in candidates {
        result
            .entry(normalized(&candidate.anonymous_type))
            .and_modify(|existing| {
                if (candidate.provider, candidate.name.as_str())
                    < (existing.provider, existing.name.as_str())
                {
                    *existing = candidate.clone();
                }
            })
            .or_insert_with(|| candidate.clone());
    }
    result
}

fn top_level_boundary(line: &str) -> bool {
    let trimmed = line.trim_start();
    let indent = line.len() - trimmed.len();
    indent <= 4
        && ["type ", "and ", "let ", "module ", "open ", "exception "]
            .into_iter()
            .any(|prefix| trimmed.starts_with(prefix))
}

fn declaration_range(text: &str, owner: &str) -> Option<(usize, usize, String)> {
    let mut offsets = Vec::new();
    let mut start = 0usize;
    for line in text.split_inclusive('\n') {
        offsets.push((start, start + line.len(), line));
        start += line.len();
    }
    if start < text.len() {
        offsets.push((start, text.len(), &text[start..]));
    }
    let type_prefix = format!("type {owner}");
    let and_prefix = format!("and {owner}");
    let index = offsets.iter().position(|(_, _, line)| {
        let trimmed = line.trim_start();
        trimmed.starts_with(&type_prefix) || trimmed.starts_with(&and_prefix)
    })?;
    let begin = offsets[index].0;
    let end = offsets
        .iter()
        .skip(index + 1)
        .find(|(_, _, line)| top_level_boundary(line))
        .map_or(text.len(), |(start, _, _)| *start);
    let line = offsets[index].2;
    let indentation = line[..line.len() - line.trim_start().len()].to_owned();
    Some((begin, end, indentation))
}

fn rewrite_candidate(
    text: &str,
    candidate: &IdentityCandidate,
    canonical: &IdentityCandidate,
) -> String {
    if candidate.kind == IdentityKind::Direct
        && candidate.provider == canonical.provider
        && candidate.name == canonical.name
    {
        return text.to_owned();
    }
    let Some((begin, end, indentation)) = declaration_range(text, &candidate.owner) else {
        return text.to_owned();
    };
    let target = if candidate.provider == canonical.provider && candidate.name == canonical.name {
        candidate.name.clone()
    } else {
        format!(
            "spiral_compiler_Part{:04}.{}",
            canonical.provider, canonical.name
        )
    };
    let body = &text[begin..end];
    let rewritten_body = body.replacen(&candidate.anonymous_type, &target, 1);
    if rewritten_body == body {
        return text.to_owned();
    }
    let mut output = String::with_capacity(text.len() + candidate.anonymous_type.len());
    output.push_str(&text[..begin]);
    output.push_str(&rewritten_body);
    output.push_str(&text[end..]);
    if candidate.kind == IdentityKind::Wrapped
        && candidate.provider == canonical.provider
        && candidate.name == canonical.name
        && !text.contains(&format!("type {} =", candidate.name))
    {
        let keyword = if text[begin..].trim_start().starts_with("and ") {
            "and"
        } else {
            "type"
        };
        output.insert_str(
            begin,
            &format!(
                "{indentation}{keyword} {} = {}\n\n",
                candidate.name, candidate.anonymous_type
            ),
        );
    }
    output
}

pub(super) fn canonicalize_wrapped_anonymous_types(
    plan: &SplitPlan,
    output_root: &Path,
) -> Result<(usize, Vec<AnonymousRecordAlias>), String> {
    let (union_list_files_changed, mut union_list_aliases) =
        materialize_union_list_identities(plan, output_root)?;
    let candidates = candidates(plan);
    let canonical = canonical(&candidates);
    let mut by_provider = BTreeMap::<usize, Vec<IdentityCandidate>>::new();
    for candidate in candidates {
        by_provider
            .entry(candidate.provider)
            .or_default()
            .push(candidate);
    }
    let mut files_changed = 0usize;
    for (provider, candidates) in by_provider {
        let path = output_root.join(format!("Part{provider:04}.fs"));
        let text = fs::read_to_string(&path)
            .map_err(|error| format!("read {}: {error}", path.display()))?;
        let rewritten = candidates.iter().fold(text.clone(), |text, candidate| {
            let target = canonical
                .get(&normalized(&candidate.anonymous_type))
                .expect("every anonymous identity has a canonical target");
            rewrite_candidate(&text, candidate, target)
        });
        if rewritten != text {
            atomic_write(&path, &rewritten)?;
            files_changed += 1;
        }
    }
    let mut aliases = canonical
        .values()
        .map(|candidate| AnonymousRecordAlias {
            provider_shard: candidate.provider,
            name: candidate.name.clone(),
            fields: candidate.fields.clone(),
        })
        .collect::<BTreeSet<_>>()
        .into_iter()
        .collect::<Vec<_>>();
    aliases.append(&mut union_list_aliases);
    aliases.sort();
    aliases.dedup();
    Ok((union_list_files_changed + files_changed, aliases))
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn union_case_payload_does_not_begin_the_owner_rhs() {
        let input = "type ProjectCodeAction =\n    | CreateFile of {| filePath : string |}\n    | RenameDirectory of {| dirPath : string; target : string |}\n";
        let start = input.rfind("{|").expect("anonymous union payload");
        assert!(!anonymous_span_begins_owner_rhs(input, 0, start));
    }

    #[test]
    fn direct_alias_anonymous_span_begins_the_owner_rhs() {
        let input = "type VSCPos = {| line : int; character : int |}\n";
        let start = input.find("{|").expect("anonymous alias");
        assert!(anonymous_span_begins_owner_rhs(input, 0, start));
    }

    #[test]
    fn owner_tracks_the_type_that_contains_the_anonymous_span() {
        let input =
            "    type PartEvalMacro = Text of string\n    and Union = {| value : int |} H\n";
        let start = input.find("{|").expect("anonymous record");
        assert_eq!(owner_before_span(input, start).as_deref(), Some("Union"));
    }

    #[test]
    fn wrapped_identity_is_inserted_before_its_mutual_group() {
        let input =
            "    type PartEvalMacro = Text of string\n    and Union = {| value : int |} H\n";
        let candidate = IdentityCandidate {
            provider: 40,
            owner: "Union".to_owned(),
            name: "SpiralSplitAnon_Union_Value".to_owned(),
            anonymous_type: "{| value : int |}".to_owned(),
            fields: BTreeSet::from(["value".to_owned()]),
            kind: IdentityKind::Wrapped,
        };
        let rewritten = rewrite_candidate(input, &candidate, &candidate);
        assert!(rewritten.starts_with("    type PartEvalMacro = Text of string"));
        assert!(rewritten.contains("and SpiralSplitAnon_Union_Value = {| value : int |}"));
        assert!(rewritten.contains("and Union = SpiralSplitAnon_Union_Value H"));
    }

    #[test]
    fn wrapped_identity_becomes_a_named_canonical_alias() {
        let input = "    and Union = {| value : int |} H\n";
        let candidate = IdentityCandidate {
            provider: 40,
            owner: "Union".to_owned(),
            name: "SpiralSplitAnon_Union_Value".to_owned(),
            anonymous_type: "{| value : int |}".to_owned(),
            fields: BTreeSet::from(["value".to_owned()]),
            kind: IdentityKind::Wrapped,
        };
        let rewritten = rewrite_candidate(input, &candidate, &candidate);
        assert!(rewritten.contains("and SpiralSplitAnon_Union_Value = {| value : int |}"));
        assert!(rewritten.contains("and Union = SpiralSplitAnon_Union_Value H"));
    }

    #[test]
    fn canonical_direct_alias_keeps_its_anonymous_shape() {
        let input = "    type VSCPos = {| line : int; character : int |}\n";
        let candidate = IdentityCandidate {
            provider: 306,
            owner: "VSCPos".to_owned(),
            name: "VSCPos".to_owned(),
            anonymous_type: "{| line : int; character : int |}".to_owned(),
            fields: BTreeSet::from(["character".to_owned(), "line".to_owned()]),
            kind: IdentityKind::Direct,
        };
        assert_eq!(rewrite_candidate(input, &candidate, &candidate), input);
    }

    #[test]
    fn later_direct_alias_points_to_the_canonical_provider() {
        let input = "    type UnionView = {| value : int |}\n";
        let candidate = IdentityCandidate {
            provider: 41,
            owner: "UnionView".to_owned(),
            name: "UnionView".to_owned(),
            anonymous_type: "{| value : int |}".to_owned(),
            fields: BTreeSet::from(["value".to_owned()]),
            kind: IdentityKind::Direct,
        };
        let canonical = IdentityCandidate {
            provider: 40,
            owner: "Union".to_owned(),
            name: "SpiralSplitAnon_Union_Value".to_owned(),
            anonymous_type: "{| value : int |}".to_owned(),
            fields: BTreeSet::from(["value".to_owned()]),
            kind: IdentityKind::Wrapped,
        };
        assert_eq!(
            rewrite_candidate(input, &candidate, &canonical),
            "    type UnionView = spiral_compiler_Part0040.SpiralSplitAnon_Union_Value\n"
        );
    }

    #[test]
    fn list_wrapped_union_payload_gets_case_specific_identity() {
        let input = "    type BuildResult =\n        | BuildOk of {|code: string; file_extension : string|} list\n        | BuildSkip\n";
        let candidate = UnionListIdentityCandidate {
            provider: 697,
            owner: "BuildResult".to_owned(),
            case_name: "BuildOk".to_owned(),
            name: "SpiralSplitAnon_BuildResult_BuildOk_Value".to_owned(),
            anonymous_type: "{|code: string; file_extension : string|}".to_owned(),
            fields: BTreeSet::from(["code".to_owned(), "file_extension".to_owned()]),
        };
        let rewritten = rewrite_union_list_provider(input, &candidate);
        assert!(rewritten.contains("type SpiralSplitAnon_BuildResult_BuildOk_Value = {|code: string; file_extension : string|}"));
        assert!(rewritten.contains("| BuildOk of SpiralSplitAnon_BuildResult_BuildOk_Value list"));
    }

    #[test]
    fn list_payload_identity_annotates_matching_literals_but_not_type_shapes() {
        let candidate = UnionListIdentityCandidate {
            provider: 697,
            owner: "BuildResult".to_owned(),
            case_name: "BuildOk".to_owned(),
            name: "SpiralSplitAnon_BuildResult_BuildOk_Value".to_owned(),
            anonymous_type: "{|code: string; file_extension : string|}".to_owned(),
            fields: BTreeSet::from(["code".to_owned(), "file_extension".to_owned()]),
        };
        let literal = "let x = [{|code = value; file_extension = \".py\"|}]\n";
        let rewritten =
            annotate_union_list_literals(literal, 514, std::slice::from_ref(&candidate));
        assert!(
            rewritten
                .contains("spiral_compiler_Part0697.SpiralSplitAnon_BuildResult_BuildOk_Value")
        );
        let type_shape = "type T = {|code: string; file_extension : string|}\n";
        assert_eq!(
            annotate_union_list_literals(type_shape, 514, &[candidate]),
            type_shape
        );
    }
}
