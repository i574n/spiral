use rayon::prelude::*;
use spiral_split_model::{Shard, SplitPlan, ambient_type_target};
use std::{
    collections::{BTreeMap, BTreeSet},
    fs,
    sync::OnceLock,
};

fn hash_bytes(mut hash: u64, bytes: &[u8]) -> u64 {
    for byte in bytes {
        hash = (hash ^ u64::from(*byte)).wrapping_mul(1_099_511_628_211);
    }
    hash
}

#[must_use]
pub fn generator_fingerprint() -> u64 {
    static FINGERPRINT: OnceLock<u64> = OnceLock::new();
    *FINGERPRINT.get_or_init(|| {
        let source_hash = env!("SPIRAL_SPLIT_TOOL_FINGERPRINT")
            .parse::<u64>()
            .expect("build script must provide a numeric splitter fingerprint");
        std::env::current_exe()
            .ok()
            .and_then(|path| fs::read(path).ok())
            .map_or(source_hash, |binary| {
                hash_bytes(hash_bytes(source_hash, b"spiral-split-binary\0"), &binary)
            })
    })
}

#[must_use]
pub fn transform_fingerprint() -> u64 {
    static FINGERPRINT: OnceLock<u64> = OnceLock::new();
    *FINGERPRINT.get_or_init(|| {
        env!("SPIRAL_SPLIT_TRANSFORM_FINGERPRINT")
            .parse::<u64>()
            .expect("build script must provide a numeric transform fingerprint")
    })
}

fn declaration_shards(plan: &SplitPlan) -> Vec<usize> {
    let mut result = vec![0usize; plan.declarations.len()];
    for shard in &plan.shards {
        for declaration in &shard.declarations {
            result[declaration.0] = shard.id;
        }
    }
    result
}

fn identifier_suffix(value: &str) -> bool {
    let mut chars = value.chars();
    let Some(first) = chars.next() else {
        return false;
    };
    (first == '_' || first.is_alphabetic())
        && chars
            .all(|character| character == '_' || character == '\'' || character.is_alphanumeric())
}

fn declares_symbol(text: &str, keyword: &str, symbol: &str) -> bool {
    let prefix = format!("{keyword} {symbol}");
    text.lines().map(str::trim_start).any(|line| {
        line.strip_prefix(&prefix).is_some_and(|rest| {
            rest.is_empty()
                || rest.starts_with(|character: char| {
                    character.is_whitespace() || matches!(character, '=' | '<' | '(' | ':')
                })
        })
    })
}

fn declares_attributed_type(text: &str, symbol: &str) -> bool {
    text.lines().map(str::trim_start).any(|line| {
        let Some(after_type) = line.strip_prefix("type ") else {
            return false;
        };
        let candidate = if after_type.starts_with("[<") {
            after_type
                .find("]")
                .map(|end| after_type[end + 1..].trim_start())
                .unwrap_or(after_type)
        } else {
            after_type
        };
        candidate.strip_prefix(symbol).is_some_and(|rest| {
            rest.is_empty()
                || rest.starts_with(|character: char| {
                    character.is_whitespace() || matches!(character, '=' | '<' | '(' | ':')
                })
        })
    })
}

fn declares_type_symbol(text: &str, symbol: &str) -> bool {
    declares_symbol(text, "type", symbol)
        || declares_symbol(text, "and", symbol)
        || declares_attributed_type(text, symbol)
}

#[must_use]
pub fn unique_type_providers(plan: &SplitPlan) -> BTreeMap<String, usize> {
    let declaration_shards = declaration_shards(plan);
    let mut candidates = BTreeMap::<String, BTreeSet<usize>>::new();
    for declaration in &plan.declarations {
        let provider = declaration_shards[declaration.id.0];
        for definition in &declaration.definitions {
            let suffix = definition
                .rsplit_once('.')
                .map_or(definition.as_str(), |(_, suffix)| suffix);
            if identifier_suffix(suffix) && declares_type_symbol(&declaration.text, suffix) {
                candidates
                    .entry(suffix.to_owned())
                    .or_default()
                    .insert(provider);
            }
        }
    }
    candidates
        .into_iter()
        .filter_map(|(symbol, providers)| {
            (providers.len() == 1).then(|| (symbol, *providers.iter().next().unwrap()))
        })
        .collect()
}

fn record_fields(text: &str, symbol: &str) -> Option<Vec<String>> {
    let lines = text.lines().collect::<Vec<_>>();
    let declaration_line = lines.iter().position(|line| {
        let trimmed = line.trim_start();
        (trimmed.starts_with("type ") || trimmed.starts_with("and "))
            && trimmed.contains(symbol)
            && declares_type_symbol(trimmed, symbol)
    })?;
    let tail = lines[declaration_line..].join("\n");
    let open = tail.find('{')?;
    if tail[open + 1..].trim_start().starts_with('|') {
        return None;
    }
    let close = tail[open + 1..].find('}')? + open + 1;
    let mut fields = tail[open + 1..close]
        .split([';', '\n'])
        .filter_map(|piece| {
            let before_comment = piece.split_once("//").map_or(piece, |(head, _)| head);
            let left = before_comment.split_once(':')?.0.trim();
            let left = left.strip_prefix("mutable ").unwrap_or(left).trim();
            let field = left.split_whitespace().last()?;
            identifier_suffix(field).then(|| field.to_owned())
        })
        .collect::<Vec<_>>();
    fields.sort();
    fields.dedup();
    (fields.len() >= 2).then_some(fields)
}

fn record_literal_shapes(source: &str) -> BTreeSet<Vec<String>> {
    let bytes = source.as_bytes();
    let mut shapes = BTreeSet::new();
    let mut index = 0usize;
    while index < bytes.len() {
        if bytes[index] != b'{' || bytes.get(index + 1) == Some(&b'|') {
            index += 1;
            continue;
        }
        let mut depth = 1usize;
        let mut cursor = index + 1;
        let mut in_string = false;
        while cursor < bytes.len() && depth > 0 {
            match bytes[cursor] {
                b'"' if cursor == 0 || bytes[cursor - 1] != b'\\' => in_string = !in_string,
                b'{' if !in_string => depth += 1,
                b'}' if !in_string => depth -= 1,
                _ => {}
            }
            cursor += 1;
        }
        if depth != 0 {
            break;
        }
        let body = &source[index + 1..cursor - 1];
        let mut fields = body
            .split([';', '\n'])
            .filter_map(|piece| {
                let left = piece.split_once('=')?.0.trim();
                let field = left.split_whitespace().last()?;
                identifier_suffix(field).then(|| field.to_owned())
            })
            .collect::<Vec<_>>();
        fields.sort();
        fields.dedup();
        if fields.len() >= 2 {
            shapes.insert(fields);
        }
        index = cursor;
    }
    shapes
}

fn unique_record_shape_providers(plan: &SplitPlan) -> BTreeMap<Vec<String>, usize> {
    let declaration_shards = declaration_shards(plan);
    let candidates = plan
        .declarations
        .par_iter()
        .flat_map_iter(|declaration| {
            let provider = declaration_shards[declaration.id.0];
            declaration
                .definitions
                .iter()
                .filter_map(move |definition| {
                    let suffix = definition
                        .rsplit_once('.')
                        .map_or(definition.as_str(), |(_, suffix)| suffix);
                    if !identifier_suffix(suffix)
                        || !declares_type_symbol(&declaration.text, suffix)
                    {
                        return None;
                    }
                    record_fields(&declaration.text, suffix).map(|fields| (fields, provider))
                })
        })
        .collect::<Vec<_>>();
    let mut providers_by_shape = BTreeMap::<Vec<String>, BTreeSet<usize>>::new();
    for (fields, provider) in candidates {
        providers_by_shape
            .entry(fields)
            .or_default()
            .insert(provider);
    }
    providers_by_shape
        .into_iter()
        .filter_map(|(shape, providers)| {
            (providers.len() == 1).then(|| (shape, *providers.iter().next().unwrap()))
        })
        .collect()
}

fn binding_body(mut line: &str) -> Option<&str> {
    line = line.trim_start();
    line = line
        .strip_prefix("let ")
        .or_else(|| line.strip_prefix("and "))?;
    loop {
        let before = line;
        for modifier in [
            "rec ",
            "private ",
            "internal ",
            "public ",
            "inline ",
            "mutable ",
        ] {
            if let Some(rest) = line.strip_prefix(modifier) {
                line = rest;
                break;
            }
        }
        if line == before {
            return Some(line);
        }
    }
}

fn binding_defines_symbol(line: &str, symbol: &str) -> bool {
    let Some(body) = binding_body(line) else {
        return false;
    };
    body.strip_prefix(symbol).is_some_and(|rest| {
        rest.is_empty()
            || rest.starts_with(|character: char| {
                character.is_whitespace() || matches!(character, '(' | ':' | '=')
            })
    })
}

fn typed_parameter_types(text: &str, symbol: &str) -> BTreeSet<String> {
    if !identifier_suffix(symbol) {
        return BTreeSet::new();
    }
    let lines = text.lines().collect::<Vec<_>>();
    let Some(start) = lines
        .iter()
        .position(|line| binding_defines_symbol(line, symbol))
    else {
        return BTreeSet::new();
    };
    let mut header = String::new();
    for line in &lines[start..] {
        if !header.is_empty() {
            header.push(' ');
        }
        header.push_str(line.trim());
        if line.contains('=') {
            break;
        }
    }
    let before_equals = header
        .split_once('=')
        .map_or(header.as_str(), |(before, _)| before);
    let Some(body) = binding_body(before_equals) else {
        return BTreeSet::new();
    };
    let Some(after_name) = body.strip_prefix(symbol) else {
        return BTreeSet::new();
    };

    let chars = after_name.char_indices().collect::<Vec<_>>();
    let mut depth = 0usize;
    let mut result = BTreeSet::new();
    for (index, (_, character)) in chars.iter().enumerate() {
        match character {
            '(' => depth += 1,
            ')' => depth = depth.saturating_sub(1),
            ':' if depth > 0 => {
                let byte_index = chars[index].0 + character.len_utf8();
                let tail = after_name[byte_index..].trim_start();
                let type_path = tail
                    .chars()
                    .take_while(|candidate| {
                        *candidate == '_'
                            || *candidate == '\''
                            || *candidate == '.'
                            || candidate.is_alphanumeric()
                    })
                    .collect::<String>();
                let suffix = type_path.rsplit('.').next().unwrap_or_default();
                if identifier_suffix(suffix) {
                    result.insert(suffix.to_owned());
                }
            }
            _ => {}
        }
    }
    result
}

#[must_use]
pub fn typed_use_type_providers_by_shard(
    plan: &SplitPlan,
    providers: &BTreeMap<String, usize>,
) -> BTreeMap<usize, BTreeSet<usize>> {
    let mut result = BTreeMap::new();
    let mut contract_cache = BTreeMap::<(usize, String), BTreeSet<usize>>::new();
    for shard in &plan.shards {
        let mut shard_providers = BTreeSet::new();
        for declaration_id in &shard.declarations {
            let declaration = &plan.declarations[declaration_id.0];
            for witness in &declaration.witnesses {
                let symbol = witness
                    .symbol
                    .rsplit_once('.')
                    .map_or(witness.symbol.as_str(), |(_, suffix)| suffix);
                let key = (witness.provider.0, symbol.to_owned());
                let contract = contract_cache.entry(key).or_insert_with(|| {
                    let provider_declaration = &plan.declarations[witness.provider.0];
                    typed_parameter_types(&provider_declaration.text, symbol)
                        .into_iter()
                        .filter_map(|type_symbol| providers.get(&type_symbol).copied())
                        .collect()
                });
                shard_providers.extend(contract.iter().copied().filter(|type_provider| {
                    *type_provider != shard.id && shard.compile_dependencies.contains(type_provider)
                }));
            }
        }
        if !shard_providers.is_empty() {
            result.insert(shard.id, shard_providers);
        }
    }
    result
}

fn compile_provider_is_available(
    provider: usize,
    shard_id: usize,
    compile_dependencies: &BTreeSet<usize>,
) -> bool {
    provider != shard_id && compile_dependencies.contains(&provider)
}

fn has_field_projection(text: &str, field: &str) -> bool {
    let needle = format!(".{field}");
    text.match_indices(&needle).any(|(index, matched)| {
        let after = &text[index + matched.len()..];
        after.chars().next().is_none_or(|character| {
            !(character == '_' || character == '\'' || character.is_alphanumeric())
        })
    })
}

fn late_type_open_candidates_from_source(
    source: &str,
    shard_id: usize,
    compile_dependencies: &BTreeSet<usize>,
    providers: &BTreeMap<String, usize>,
    typed_providers: Option<&BTreeSet<usize>>,
    record_providers: &BTreeMap<Vec<String>, usize>,
) -> Vec<usize> {
    let identifiers = source
        .split(|character: char| {
            !(character == '_' || character == '\'' || character.is_alphanumeric())
        })
        .filter(|token| !token.is_empty())
        .collect::<BTreeSet<_>>();
    let mut candidates = providers
        .iter()
        .filter_map(|(symbol, provider)| {
            (compile_provider_is_available(*provider, shard_id, compile_dependencies)
                && identifiers.contains(symbol.as_str()))
            .then_some(*provider)
        })
        .collect::<BTreeSet<_>>();

    for shape in record_literal_shapes(source) {
        if shape
            .first()
            .is_some_and(|field| has_field_projection(source, field))
        {
            continue;
        }
        if let Some(provider) = record_providers.get(&shape)
            && *provider != shard_id
            && compile_dependencies.contains(provider)
        {
            candidates.insert(*provider);
        }
    }

    // A referenced helper with an explicitly typed parameter carries stronger
    // evidence than lexical record-field overlap. Re-open those type providers
    // last so ambiguous field projections follow the helper contract while
    // exact record literals remain resolved by their unique field shape.
    if let Some(typed_providers) = typed_providers {
        for provider in typed_providers {
            candidates.remove(provider);
        }
    }
    let mut ordered = candidates.into_iter().collect::<Vec<_>>();
    if let Some(typed_providers) = typed_providers {
        ordered.extend(typed_providers.iter().copied());
    }
    // Caller contracts are materialized as explicit parameter annotations.
    // Re-opening their providers globally would let one local contract change
    // unrelated record inference throughout the whole generated shard.
    ordered.retain(|provider| {
        compile_provider_is_available(*provider, shard_id, compile_dependencies)
    });
    ordered
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LateTypeOpenIndex {
    record_providers: BTreeMap<Vec<String>, usize>,
}

impl LateTypeOpenIndex {
    #[must_use]
    pub fn build(plan: &SplitPlan) -> Self {
        Self {
            record_providers: unique_record_shape_providers(plan),
        }
    }

    #[must_use]
    pub fn candidates(
        &self,
        plan: &SplitPlan,
        shard: &Shard,
        providers: &BTreeMap<String, usize>,
        typed_providers: Option<&BTreeSet<usize>>,
        _caller_contract_providers: Option<&[usize]>,
    ) -> Vec<usize> {
        let source = shard
            .declarations
            .iter()
            .map(|id| plan.declarations[id.0].text.as_str())
            .collect::<Vec<_>>()
            .join("\n");
        late_type_open_candidates_from_source(
            &source,
            shard.id,
            &shard.compile_dependencies,
            providers,
            typed_providers,
            &self.record_providers,
        )
    }
}

#[must_use]
pub fn late_type_open_candidates(
    plan: &SplitPlan,
    shard: &Shard,
    providers: &BTreeMap<String, usize>,
    typed_providers: Option<&BTreeSet<usize>>,
    caller_contract_providers: Option<&[usize]>,
) -> Vec<usize> {
    LateTypeOpenIndex::build(plan).candidates(
        plan,
        shard,
        providers,
        typed_providers,
        caller_contract_providers,
    )
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum AmbientTypeOpen<'a> {
    Preserve(&'a str),
    Split {
        indent: &'a str,
        provider: usize,
        symbol: &'a str,
    },
}

#[must_use]
pub fn resolve_ambient_type_open<'a, F>(
    line: &'a str,
    provider: F,
    dependencies: &BTreeSet<usize>,
) -> AmbientTypeOpen<'a>
where
    F: FnOnce(&str) -> Option<usize>,
{
    let Some(target) = ambient_type_target(line) else {
        return AmbientTypeOpen::Preserve(line);
    };
    let symbol = target.rsplit('.').next().unwrap_or(target);
    let Some(provider) = provider(symbol).filter(|id| dependencies.contains(id)) else {
        return AmbientTypeOpen::Preserve(line);
    };
    AmbientTypeOpen::Split {
        indent: &line[..line.len() - line.trim_start().len()],
        provider,
        symbol,
    }
}

#[must_use]
pub fn provider_open_insertion(provider_opens: &[String], consumer_opens: &[String]) -> usize {
    let prefix_len = provider_opens.len();
    if consumer_opens
        .get(..prefix_len)
        .is_some_and(|prefix| prefix == provider_opens)
    {
        return prefix_len;
    }
    provider_opens
        .iter()
        .filter_map(|open_line| {
            consumer_opens
                .iter()
                .rposition(|candidate| candidate == open_line)
                .map(|index| index + 1)
        })
        .max()
        .unwrap_or(0)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn record_literal_shapes_are_structural_and_sorted() {
        let shapes = record_literal_shapes(
            r#"let a = {from=0; text=text}
let b = {nearTo=i+1; from=i}"#,
        );
        assert!(shapes.contains(&vec!["from".to_owned(), "text".to_owned()]));
        assert!(shapes.contains(&vec!["from".to_owned(), "nearTo".to_owned()]));
    }

    #[test]
    fn record_fields_ignore_mutability_and_comments() {
        let text = r#"type Tokenizer = {
    text : string // line
    mutable from : int
    } with
    member t.Index = t.from"#;
        assert_eq!(
            record_fields(text, "Tokenizer"),
            Some(vec!["from".to_owned(), "text".to_owned()])
        );
    }

    #[test]
    fn union_payload_is_not_a_record_type_shape() {
        let text = r#"type Event =
    | Event of {| from : int; text : string |}"#;
        assert_eq!(record_fields(text, "Event"), None);
    }

    #[test]
    fn typed_parameter_types_follow_multiline_qualified_helper_contract() {
        let text = r#"let inline step
    amount
    (state : Lexer.Tokenizer)
    =
    state"#;
        assert_eq!(
            typed_parameter_types(text, "step"),
            BTreeSet::from(["Tokenizer".to_owned()])
        );
    }

    #[test]
    fn typed_parameter_types_ignore_return_annotations_and_untyped_parameters() {
        let text = r#"let peek state : Tokenizer = state"#;
        assert!(typed_parameter_types(text, "peek").is_empty());
    }

    #[test]
    fn field_projection_is_detected_without_prefix_false_positives() {
        assert!(has_field_projection("let x = state.from", "from"));
        assert!(!has_field_projection("let x = state.fromage", "from"));
    }

    #[test]
    fn late_type_open_index_preserves_unique_record_shape_provider() {
        let providers = BTreeMap::new();
        let dependencies = BTreeSet::from([2usize]);
        let record_providers =
            BTreeMap::from([(vec!["from".to_owned(), "nearTo".to_owned()], 2usize)]);
        assert_eq!(
            late_type_open_candidates_from_source(
                "let range = {from=0; nearTo=1}",
                7,
                &dependencies,
                &providers,
                None,
                &record_providers,
            ),
            vec![2]
        );
    }

    #[test]
    fn late_open_provider_must_belong_to_compile_closure() {
        let dependencies = BTreeSet::from([2usize, 4usize]);
        assert!(compile_provider_is_available(2, 7, &dependencies));
        assert!(!compile_provider_is_available(3, 7, &dependencies));
        assert!(!compile_provider_is_available(7, 7, &dependencies));
    }

    #[test]
    fn ambient_type_open_uses_explicit_split_provider() {
        let dependencies = BTreeSet::from([7usize]);
        assert_eq!(
            resolve_ambient_type_open(
                "    open type SemanticStatusId",
                |symbol| (symbol == "SemanticStatusId").then_some(7),
                &dependencies,
            ),
            AmbientTypeOpen::Split {
                indent: "    ",
                provider: 7,
                symbol: "SemanticStatusId",
            }
        );
    }

    #[test]
    fn ambient_type_open_preserves_unavailable_provider() {
        let dependencies = BTreeSet::from([4usize]);
        assert_eq!(
            resolve_ambient_type_open(
                "    open type EvalWorklist.SemanticStatusId",
                |symbol| (symbol == "SemanticStatusId").then_some(7),
                &dependencies,
            ),
            AmbientTypeOpen::Preserve("    open type EvalWorklist.SemanticStatusId")
        );
    }

    #[test]
    fn provider_open_follows_shared_ambient_context_when_order_is_not_prefix() {
        let provider = vec![
            "    open FSharpx.Collections".to_owned(),
            "    open Hopac".to_owned(),
            "    open System.Text".to_owned(),
        ];
        let consumer = vec![
            "    open FSharpx.Collections".to_owned(),
            "    open System.Text".to_owned(),
            "    open Hopac".to_owned(),
        ];
        assert_eq!(provider_open_insertion(&provider, &consumer), 3);
    }
}
