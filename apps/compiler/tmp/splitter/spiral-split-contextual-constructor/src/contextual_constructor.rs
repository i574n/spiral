use rayon::prelude::*;
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::marker::PhantomData;
use std::path::Path;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ConsumerAssembly;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ContextualConstructorPlan<'a, Scope = ConsumerAssembly> {
    Stable(PhantomData<Scope>),
    Adapt {
        constructor: &'a str,
        fields: Vec<&'a str>,
        parameter: &'a str,
        scope: PhantomData<Scope>,
    },
}

pub fn plan_contextual_constructor<'a>(
    constructor: &'a str,
    fields: impl IntoIterator<Item = &'a str>,
    parameter: &'a str,
    visible: bool,
) -> ContextualConstructorPlan<'a> {
    let fields = fields.into_iter().collect::<Vec<_>>();
    if !visible || constructor.trim().is_empty() || parameter.trim().is_empty() || fields.is_empty()
    {
        ContextualConstructorPlan::Stable(PhantomData)
    } else {
        ContextualConstructorPlan::Adapt {
            constructor,
            fields,
            parameter,
            scope: PhantomData,
        }
    }
}

pub fn render_contextual_constructor(plan: &ContextualConstructorPlan<'_>) -> Option<String> {
    match plan {
        ContextualConstructorPlan::Stable(_) => None,
        ContextualConstructorPlan::Adapt {
            constructor,
            fields,
            parameter,
            ..
        } => {
            let assignments = fields
                .iter()
                .map(|field| format!("{field} = {parameter}.{field}"))
                .collect::<Vec<_>>()
                .join("; ");
            Some(format!(
                "(fun {parameter} -> {constructor} {{| {assignments} |}})"
            ))
        }
    }
}

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
struct RecordAlias {
    provider_shard: usize,
    name: String,
    fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
struct UnionConstructor {
    provider_shard: usize,
    name: String,
    fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ContextualConstructorRewrite {
    pub consumer_shard: usize,
    pub expected_provider_shard: usize,
    pub constructor_provider_shard: usize,
    pub expected_alias: String,
    pub constructor: String,
    pub line: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ContextualConstructorDeclarationRewrite {
    pub constructor_provider_shard: usize,
    pub alias_provider_shard: usize,
    pub constructor: String,
    pub alias: String,
    pub line: usize,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct ContextualConstructorReport {
    pub files_scanned: usize,
    pub files_changed: usize,
    pub adapters: usize,
    pub declaration_adapters: usize,
    pub rewrites: Vec<ContextualConstructorRewrite>,
    pub declaration_rewrites: Vec<ContextualConstructorDeclarationRewrite>,
}

fn identifier(value: &str) -> bool {
    let mut chars = value.chars();
    matches!(chars.next(), Some(c) if c == '_' || c.is_ascii_alphabetic())
        && chars.all(|c| c == '_' || c == '\'' || c.is_ascii_alphanumeric())
}

fn identifiers(value: &str) -> impl Iterator<Item = &str> {
    value
        .split(|c: char| !(c == '_' || c == '\'' || c.is_ascii_alphanumeric()))
        .filter(|token| identifier(token))
}

fn record_fields(value: &str) -> Option<BTreeSet<String>> {
    let begin = value.find("{|")? + 2;
    let end = value[begin..].find("|}")? + begin;
    let mut fields = BTreeSet::new();
    for field in value[begin..end].split(';') {
        let field = field.trim();
        if field.is_empty() || field.contains(" with ") {
            continue;
        }
        let separator = field.find(':').or_else(|| field.find('='))?;
        let name = field[..separator].trim();
        if identifier(name) {
            fields.insert(name.to_string());
        }
    }
    (!fields.is_empty()).then_some(fields)
}

fn direct_alias(shard: usize, line: &str) -> Option<RecordAlias> {
    let line = line.trim_start();
    let declaration = line
        .strip_prefix("type ")
        .or_else(|| line.strip_prefix("and "))?;
    let (left, right) = declaration.split_once('=')?;
    if !right.trim_start().starts_with("{|") {
        return None;
    }
    let name = left.split_whitespace().next()?.trim();
    if !identifier(name) {
        return None;
    }
    Some(RecordAlias {
        provider_shard: shard,
        name: name.to_string(),
        fields: record_fields(right)?,
    })
}

fn union_constructor(shard: usize, line: &str) -> Option<UnionConstructor> {
    let line = line.trim_start().strip_prefix('|')?.trim_start();
    let (left, right) = line.split_once(" of ")?;
    if !right.trim_start().starts_with("{|") {
        return None;
    }
    let name = left.split_whitespace().next()?.trim();
    if !identifier(name) {
        return None;
    }
    Some(UnionConstructor {
        provider_shard: shard,
        name: name.to_string(),
        fields: record_fields(right)?,
    })
}

fn visible(
    provider_shard: usize,
    consumer_shard: usize,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> bool {
    let Some(&provider_gear) = shard_to_gear.get(provider_shard) else {
        return false;
    };
    let Some(&consumer_gear) = shard_to_gear.get(consumer_shard) else {
        return false;
    };
    provider_gear != consumer_gear
        && gear_dependencies
            .get(consumer_gear)
            .is_some_and(|dependencies| dependencies.contains(&provider_gear))
}

fn field_before_colon(line: &str) -> Option<&str> {
    let (left, _) = line.split_once(':')?;
    let field = left.trim();
    identifier(field).then_some(field)
}

fn build_field_aliases(
    texts: &[String],
    aliases_by_name: &BTreeMap<String, Vec<RecordAlias>>,
) -> BTreeMap<String, Vec<RecordAlias>> {
    let mut result = BTreeMap::<String, BTreeSet<RecordAlias>>::new();
    for text in texts {
        for line in text.lines() {
            let Some(field) = field_before_colon(line) else {
                continue;
            };
            let Some((_, right)) = line.split_once(':') else {
                continue;
            };
            for token in identifiers(right) {
                if let Some(aliases) = aliases_by_name.get(token) {
                    result
                        .entry(field.to_string())
                        .or_default()
                        .extend(aliases.iter().cloned());
                }
            }
        }
    }
    result
        .into_iter()
        .map(|(field, aliases)| (field, aliases.into_iter().collect()))
        .collect()
}

fn assignment_field(line: &str) -> Option<&str> {
    let line = line.trim_start();
    if line.starts_with("let ")
        || line.starts_with("and ")
        || line.starts_with("type ")
        || line.starts_with('|')
    {
        return None;
    }
    let (left, _) = line.split_once('=')?;
    let field = left.trim();
    identifier(field).then_some(field)
}

fn identifier_byte(byte: u8) -> bool {
    byte == b'_' || byte == b'\'' || byte.is_ascii_alphanumeric()
}

fn identifier_spans(value: &str, name: &str) -> Vec<(usize, usize)> {
    value
        .match_indices(name)
        .filter_map(|(begin, _)| {
            let end = begin + name.len();
            let bytes = value.as_bytes();
            let left_ok = begin == 0 || !identifier_byte(bytes[begin - 1]);
            let right_ok = end == bytes.len() || !identifier_byte(bytes[end]);
            (left_ok && right_ok).then_some((begin, end))
        })
        .collect()
}

fn unique_expected_alias(
    field: &str,
    consumer_shard: usize,
    field_aliases: &BTreeMap<String, Vec<RecordAlias>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Option<RecordAlias> {
    let aliases = field_aliases.get(field)?;
    let visible = aliases
        .iter()
        .filter(|alias| {
            visible(
                alias.provider_shard,
                consumer_shard,
                shard_to_gear,
                gear_dependencies,
            )
        })
        .cloned()
        .collect::<BTreeSet<_>>();
    (visible.len() == 1).then(|| visible.into_iter().next().expect("one visible alias"))
}

fn unique_constructor(
    right: &str,
    expected: &RecordAlias,
    consumer_shard: usize,
    constructors_by_name: &BTreeMap<String, Vec<UnionConstructor>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Option<(UnionConstructor, usize, usize)> {
    let mut candidates = BTreeSet::<(UnionConstructor, usize, usize)>::new();
    for token in identifiers(right) {
        let Some(constructors) = constructors_by_name.get(token) else {
            continue;
        };
        for constructor in constructors.iter().filter(|constructor| {
            constructor.fields == expected.fields
                && visible(
                    constructor.provider_shard,
                    consumer_shard,
                    shard_to_gear,
                    gear_dependencies,
                )
        }) {
            let spans = identifier_spans(right, &constructor.name);
            if spans.len() == 1 {
                let (begin, end) = spans[0];
                candidates.insert((constructor.clone(), begin, end));
            }
        }
    }
    (candidates.len() == 1).then(|| candidates.into_iter().next().expect("one constructor"))
}

fn rewrite_line(
    consumer_shard: usize,
    line_number: usize,
    line: &str,
    field_aliases: &BTreeMap<String, Vec<RecordAlias>>,
    constructors_by_name: &BTreeMap<String, Vec<UnionConstructor>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> (String, Option<ContextualConstructorRewrite>) {
    if line.contains("__spiral_split_contextual_constructor") {
        return (line.to_string(), None);
    }
    let Some(field) = assignment_field(line) else {
        return (line.to_string(), None);
    };
    let Some(expected) = unique_expected_alias(
        field,
        consumer_shard,
        field_aliases,
        shard_to_gear,
        gear_dependencies,
    ) else {
        return (line.to_string(), None);
    };
    let Some((constructor, begin, end)) = line.split_once('=').and_then(|(_, right)| {
        unique_constructor(
            right,
            &expected,
            consumer_shard,
            constructors_by_name,
            shard_to_gear,
            gear_dependencies,
        )
        .map(|(constructor, relative_begin, relative_end)| {
            let offset = line.find('=').expect("assignment") + 1;
            (constructor, offset + relative_begin, offset + relative_end)
        })
    }) else {
        return (line.to_string(), None);
    };
    let parameter = "__spiral_split_contextual_constructor_value";
    let fields = constructor
        .fields
        .iter()
        .map(String::as_str)
        .collect::<Vec<_>>();
    let plan = plan_contextual_constructor(&constructor.name, fields, parameter, true);
    let Some(adapter) = render_contextual_constructor(&plan) else {
        return (line.to_string(), None);
    };
    let mut output = line.to_string();
    output.replace_range(begin..end, &adapter);
    let rewrite = ContextualConstructorRewrite {
        consumer_shard,
        expected_provider_shard: expected.provider_shard,
        constructor_provider_shard: constructor.provider_shard,
        expected_alias: expected.name,
        constructor: constructor.name,
        line: line_number,
    };
    (output, Some(rewrite))
}

fn rewrite_text(
    consumer_shard: usize,
    text: &str,
    field_aliases: &BTreeMap<String, Vec<RecordAlias>>,
    constructors_by_name: &BTreeMap<String, Vec<UnionConstructor>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> (String, Vec<ContextualConstructorRewrite>) {
    let mut lines = Vec::new();
    let mut rewrites = Vec::new();
    for (index, line) in text.lines().enumerate() {
        let (line, rewrite) = rewrite_line(
            consumer_shard,
            index + 1,
            line,
            field_aliases,
            constructors_by_name,
            shard_to_gear,
            gear_dependencies,
        );
        lines.push(line);
        rewrites.extend(rewrite);
    }
    let mut output = lines.join("\n");
    if text.ends_with('\n') {
        output.push('\n');
    }
    (output, rewrites)
}

fn declaration_targets(
    rewrites: &[ContextualConstructorRewrite],
) -> BTreeMap<(usize, String), BTreeSet<(usize, String)>> {
    let mut targets = BTreeMap::<(usize, String), BTreeSet<(usize, String)>>::new();
    for rewrite in rewrites {
        targets
            .entry((
                rewrite.constructor_provider_shard,
                rewrite.constructor.clone(),
            ))
            .or_default()
            .insert((
                rewrite.expected_provider_shard,
                rewrite.expected_alias.clone(),
            ));
    }
    targets
}

fn rewrite_constructor_declaration_line(
    shard: usize,
    line_number: usize,
    line: &str,
    targets: &BTreeMap<(usize, String), BTreeSet<(usize, String)>>,
    aliases_by_name: &BTreeMap<String, Vec<RecordAlias>>,
    shard_to_gear: &[usize],
) -> (String, Option<ContextualConstructorDeclarationRewrite>) {
    let Some(constructor) = union_constructor(shard, line) else {
        return (line.to_string(), None);
    };
    let Some(candidates) = targets.get(&(shard, constructor.name.clone())) else {
        return (line.to_string(), None);
    };
    if candidates.len() != 1 {
        return (line.to_string(), None);
    }
    let (alias_provider_shard, alias) = candidates.iter().next().expect("one candidate");
    let alias_matches = aliases_by_name.get(alias).is_some_and(|aliases| {
        aliases.iter().any(|candidate| {
            candidate.provider_shard == *alias_provider_shard
                && candidate.fields == constructor.fields
        })
    });
    if !alias_matches || shard_to_gear.get(shard) == shard_to_gear.get(*alias_provider_shard) {
        return (line.to_string(), None);
    }
    let Some(separator) = line.find(" of ") else {
        return (line.to_string(), None);
    };
    let payload_begin = separator + " of ".len();
    let Some(payload_tail) = line[payload_begin..].find("|}") else {
        return (line.to_string(), None);
    };
    let payload_end = payload_begin + payload_tail + 2;
    if !line[payload_begin..payload_end]
        .trim_start()
        .starts_with("{|")
    {
        return (line.to_string(), None);
    }
    let qualified_alias = format!("spiral_compiler_Part{:04}.{}", alias_provider_shard, alias);
    let mut output = line.to_string();
    output.replace_range(payload_begin..payload_end, &qualified_alias);
    (
        output,
        Some(ContextualConstructorDeclarationRewrite {
            constructor_provider_shard: shard,
            alias_provider_shard: *alias_provider_shard,
            constructor: constructor.name,
            alias: alias.clone(),
            line: line_number,
        }),
    )
}

fn rewrite_constructor_declarations(
    shard: usize,
    text: &str,
    targets: &BTreeMap<(usize, String), BTreeSet<(usize, String)>>,
    aliases_by_name: &BTreeMap<String, Vec<RecordAlias>>,
    shard_to_gear: &[usize],
) -> (String, Vec<ContextualConstructorDeclarationRewrite>) {
    let mut lines = Vec::new();
    let mut rewrites = Vec::new();
    for (index, line) in text.lines().enumerate() {
        let (line, rewrite) = rewrite_constructor_declaration_line(
            shard,
            index + 1,
            line,
            targets,
            aliases_by_name,
            shard_to_gear,
        );
        lines.push(line);
        rewrites.extend(rewrite);
    }
    let mut output = lines.join("\n");
    if text.ends_with('\n') {
        output.push('\n');
    }
    (output, rewrites)
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let temporary = path.with_extension("fs.contextual.tmp");
    fs::write(&temporary, text)
        .map_err(|error| format!("cannot write {}: {error}", temporary.display()))?;
    fs::rename(&temporary, path)
        .map_err(|error| format!("cannot promote {}: {error}", path.display()))
}

pub fn rewrite_contextual_constructors(
    output_root: &Path,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Result<ContextualConstructorReport, String> {
    if shard_to_gear.is_empty() {
        return Ok(ContextualConstructorReport::default());
    }
    let texts = (0..shard_to_gear.len())
        .into_par_iter()
        .map(|shard| {
            let path = output_root.join(format!("Part{shard:04}.fs"));
            fs::read_to_string(&path)
                .map_err(|error| format!("cannot read {}: {error}", path.display()))
        })
        .collect::<Result<Vec<_>, _>>()?;

    let mut aliases = texts
        .iter()
        .enumerate()
        .flat_map(|(shard, text)| {
            text.lines()
                .filter_map(move |line| direct_alias(shard, line))
        })
        .collect::<Vec<_>>();
    aliases.sort();
    aliases.dedup();
    let mut aliases_by_name = BTreeMap::<String, Vec<RecordAlias>>::new();
    for alias in &aliases {
        aliases_by_name
            .entry(alias.name.clone())
            .or_default()
            .push(alias.clone());
    }
    let field_aliases = build_field_aliases(&texts, &aliases_by_name);

    let mut constructors = texts
        .iter()
        .enumerate()
        .flat_map(|(shard, text)| {
            text.lines()
                .filter_map(move |line| union_constructor(shard, line))
        })
        .collect::<Vec<_>>();
    constructors.sort();
    constructors.dedup();
    let mut constructors_by_name = BTreeMap::<String, Vec<UnionConstructor>>::new();
    for constructor in &constructors {
        constructors_by_name
            .entry(constructor.name.clone())
            .or_default()
            .push(constructor.clone());
    }

    let planned = texts
        .par_iter()
        .enumerate()
        .map(|(shard, text)| {
            let (rewritten, rewrites) = rewrite_text(
                shard,
                text,
                &field_aliases,
                &constructors_by_name,
                shard_to_gear,
                gear_dependencies,
            );
            (shard, rewritten, rewrites)
        })
        .collect::<Vec<_>>();

    let mut report = ContextualConstructorReport {
        files_scanned: texts.len(),
        ..ContextualConstructorReport::default()
    };
    let mut changed_shards = BTreeSet::new();
    for (shard, rewritten, mut rewrites) in planned {
        if rewritten != texts[shard] {
            atomic_write(&output_root.join(format!("Part{shard:04}.fs")), &rewritten)?;
            changed_shards.insert(shard);
        }
        report.adapters += rewrites.len();
        report.rewrites.append(&mut rewrites);
    }
    report.rewrites.sort_by_key(|rewrite| {
        (
            rewrite.consumer_shard,
            rewrite.line,
            rewrite.constructor_provider_shard,
            rewrite.constructor.clone(),
        )
    });

    let targets = declaration_targets(&report.rewrites);
    for shard in 0..shard_to_gear.len() {
        let path = output_root.join(format!("Part{shard:04}.fs"));
        let current = fs::read_to_string(&path)
            .map_err(|error| format!("cannot read {}: {error}", path.display()))?;
        let (rewritten, mut declaration_rewrites) = rewrite_constructor_declarations(
            shard,
            &current,
            &targets,
            &aliases_by_name,
            shard_to_gear,
        );
        if rewritten != current {
            atomic_write(&path, &rewritten)?;
            changed_shards.insert(shard);
        }
        report.declaration_adapters += declaration_rewrites.len();
        report
            .declaration_rewrites
            .append(&mut declaration_rewrites);
    }
    report.declaration_rewrites.sort_by_key(|rewrite| {
        (
            rewrite.constructor_provider_shard,
            rewrite.line,
            rewrite.alias_provider_shard,
            rewrite.constructor.clone(),
        )
    });
    report.files_changed = changed_shards.len();
    Ok(report)
}

pub fn render_contextual_constructor_tsv(report: &ContextualConstructorReport) -> String {
    let mut output = String::from(
        "consumer_shard\texpected_provider_shard\tconstructor_provider_shard\texpected_alias\tconstructor\tline\n",
    );
    for rewrite in &report.rewrites {
        output.push_str(&format!(
            "{}\t{}\t{}\t{}\t{}\t{}\n",
            rewrite.consumer_shard,
            rewrite.expected_provider_shard,
            rewrite.constructor_provider_shard,
            rewrite.expected_alias,
            rewrite.constructor,
            rewrite.line
        ));
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    fn alias(provider_shard: usize, name: &str, fields: &[&str]) -> RecordAlias {
        RecordAlias {
            provider_shard,
            name: name.to_string(),
            fields: fields.iter().map(|field| (*field).to_string()).collect(),
        }
    }

    fn constructor(provider_shard: usize, name: &str, fields: &[&str]) -> UnionConstructor {
        UnionConstructor {
            provider_shard,
            name: name.to_string(),
            fields: fields.iter().map(|field| (*field).to_string()).collect(),
        }
    }

    #[test]
    fn renders_contextual_constructor_adapter() {
        let plan = plan_contextual_constructor("PackageErrors", ["errors", "uri"], "value", true);
        let rendered = render_contextual_constructor(&plan).expect("adapter");
        assert!(rendered.contains("fun value -> PackageErrors"));
        assert!(rendered.contains("errors = value.errors"));
        assert!(rendered.contains("uri = value.uri"));
    }

    #[test]
    fn fails_closed_without_visibility() {
        let plan = plan_contextual_constructor("PackageErrors", ["uri"], "value", false);
        assert_eq!(render_contextual_constructor(&plan), None);
    }

    #[test]
    fn rewrites_field_constructor_when_shapes_and_predecessors_are_unique() {
        let expected = alias(0, "LocalizedErrors", &["errors", "uri"]);
        let constructor = constructor(1, "PackageErrors", &["errors", "uri"]);
        let field_aliases = BTreeMap::from([("package".to_string(), vec![expected])]);
        let constructors = BTreeMap::from([("PackageErrors".to_string(), vec![constructor])]);
        let shard_to_gear = vec![0, 1, 2];
        let dependencies = vec![BTreeSet::new(), BTreeSet::new(), BTreeSet::from([0, 1])];
        let input = "        package = error_ch_create PackageErrors\n";
        let (output, rewrites) = rewrite_text(
            2,
            input,
            &field_aliases,
            &constructors,
            &shard_to_gear,
            &dependencies,
        );
        assert!(output.contains(
            "error_ch_create (fun __spiral_split_contextual_constructor_value -> PackageErrors"
        ));
        assert_eq!(rewrites.len(), 1);
        assert_eq!(rewrites[0].expected_provider_shard, 0);
        assert_eq!(rewrites[0].constructor_provider_shard, 1);
    }

    #[test]
    fn refuses_constructor_when_provider_is_not_a_predecessor() {
        let expected = alias(0, "LocalizedErrors", &["errors", "uri"]);
        let constructor = constructor(1, "PackageErrors", &["errors", "uri"]);
        let field_aliases = BTreeMap::from([("package".to_string(), vec![expected])]);
        let constructors = BTreeMap::from([("PackageErrors".to_string(), vec![constructor])]);
        let shard_to_gear = vec![0, 1, 2];
        let dependencies = vec![BTreeSet::new(), BTreeSet::new(), BTreeSet::from([0])];
        let input = "package = error_ch_create PackageErrors\n";
        let (output, rewrites) = rewrite_text(
            2,
            input,
            &field_aliases,
            &constructors,
            &shard_to_gear,
            &dependencies,
        );
        assert_eq!(output, input);
        assert!(rewrites.is_empty());
    }

    #[test]
    fn refuses_ambiguous_expected_alias() {
        let first = alias(0, "LocalizedErrorsA", &["errors", "uri"]);
        let second = alias(1, "LocalizedErrorsB", &["errors", "uri"]);
        let constructor = constructor(2, "PackageErrors", &["errors", "uri"]);
        let field_aliases = BTreeMap::from([("package".to_string(), vec![first, second])]);
        let constructors = BTreeMap::from([("PackageErrors".to_string(), vec![constructor])]);
        let shard_to_gear = vec![0, 1, 2, 3];
        let dependencies = vec![
            BTreeSet::new(),
            BTreeSet::new(),
            BTreeSet::new(),
            BTreeSet::from([0, 1, 2]),
        ];
        let input = "package = error_ch_create PackageErrors\n";
        let (output, rewrites) = rewrite_text(
            3,
            input,
            &field_aliases,
            &constructors,
            &shard_to_gear,
            &dependencies,
        );
        assert_eq!(output, input);
        assert!(rewrites.is_empty());
    }

    #[test]
    fn rewrites_constructor_payload_to_unique_cross_gear_alias() {
        let evidence = vec![ContextualConstructorRewrite {
            consumer_shard: 2,
            expected_provider_shard: 0,
            constructor_provider_shard: 1,
            expected_alias: "LocalizedErrors".to_string(),
            constructor: "PackageErrors".to_string(),
            line: 1,
        }];
        let targets = declaration_targets(&evidence);
        let aliases = BTreeMap::from([(
            "LocalizedErrors".to_string(),
            vec![alias(0, "LocalizedErrors", &["errors", "uri"])],
        )]);
        let shard_to_gear = vec![0, 1, 2];
        let input = "        | PackageErrors of {|uri : string; errors : RString list|}\n";
        let (output, rewrites) =
            rewrite_constructor_declarations(1, input, &targets, &aliases, &shard_to_gear);
        assert!(output.contains("PackageErrors of spiral_compiler_Part0000.LocalizedErrors"));
        assert_eq!(rewrites.len(), 1);
        assert_eq!(rewrites[0].alias_provider_shard, 0);
    }

    #[test]
    fn refuses_constructor_declaration_when_contexts_disagree() {
        let evidence = vec![
            ContextualConstructorRewrite {
                consumer_shard: 2,
                expected_provider_shard: 0,
                constructor_provider_shard: 1,
                expected_alias: "LocalizedErrors".to_string(),
                constructor: "PackageErrors".to_string(),
                line: 1,
            },
            ContextualConstructorRewrite {
                consumer_shard: 3,
                expected_provider_shard: 3,
                constructor_provider_shard: 1,
                expected_alias: "OtherErrors".to_string(),
                constructor: "PackageErrors".to_string(),
                line: 1,
            },
        ];
        let targets = declaration_targets(&evidence);
        let aliases = BTreeMap::from([
            (
                "LocalizedErrors".to_string(),
                vec![alias(0, "LocalizedErrors", &["errors", "uri"])],
            ),
            (
                "OtherErrors".to_string(),
                vec![alias(3, "OtherErrors", &["errors", "uri"])],
            ),
        ]);
        let shard_to_gear = vec![0, 1, 2, 3];
        let input = "| PackageErrors of {|uri : string; errors : RString list|}\n";
        let (output, rewrites) =
            rewrite_constructor_declarations(1, input, &targets, &aliases, &shard_to_gear);
        assert_eq!(output, input);
        assert!(rewrites.is_empty());
    }
}
