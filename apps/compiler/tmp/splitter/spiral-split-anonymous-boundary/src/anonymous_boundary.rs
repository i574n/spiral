use rayon::prelude::*;
use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::marker::PhantomData;
use std::path::Path;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BoundaryCardinality {
    Value,
    List(Box<BoundaryCardinality>),
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ConsumerAssembly;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BoundaryBridgePlan<'a, Scope = ConsumerAssembly> {
    Stable(PhantomData<Scope>),
    Rebuild {
        alias: &'a str,
        fields: Vec<&'a str>,
        expression: &'a str,
        cardinality: BoundaryCardinality,
        scope: PhantomData<Scope>,
    },
}

pub fn plan_boundary_bridge<'a>(
    alias: &'a str,
    fields: impl IntoIterator<Item = &'a str>,
    expression: &'a str,
    cardinality: BoundaryCardinality,
    alias_visible_to_consumer: bool,
) -> BoundaryBridgePlan<'a> {
    let fields = fields.into_iter().collect::<Vec<_>>();
    if !alias_visible_to_consumer || alias.trim().is_empty() || fields.is_empty() {
        BoundaryBridgePlan::Stable(PhantomData)
    } else {
        BoundaryBridgePlan::Rebuild {
            alias,
            fields,
            expression,
            cardinality,
            scope: PhantomData,
        }
    }
}

fn record_rebuild(alias: &str, fields: &[&str], value: &str) -> String {
    let assignments = fields
        .iter()
        .map(|field| format!("{field} = {value}.{field}"))
        .collect::<Vec<_>>()
        .join("; ");
    format!("({{| {assignments} |}} : {alias})")
}

fn render_cardinality(
    alias: &str,
    fields: &[&str],
    expression: &str,
    cardinality: &BoundaryCardinality,
    depth: usize,
) -> String {
    match cardinality {
        BoundaryCardinality::Value => record_rebuild(alias, fields, expression),
        BoundaryCardinality::List(inner) => {
            let value = format!("__spiral_split_boundary_{depth}");
            let rebuilt = render_cardinality(alias, fields, &value, inner, depth + 1);
            format!("(({expression}) |> List.map (fun {value} -> {rebuilt}))")
        }
    }
}

pub fn render_boundary_bridge(plan: &BoundaryBridgePlan<'_>) -> Option<String> {
    match plan {
        BoundaryBridgePlan::Stable(_) => None,
        BoundaryBridgePlan::Rebuild {
            alias,
            fields,
            expression,
            cardinality,
            ..
        } => Some(render_cardinality(
            alias,
            fields,
            expression,
            cardinality,
            0,
        )),
    }
}

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
struct BoundaryAlias {
    provider_shard: usize,
    name: String,
    fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BoundaryRewriteKind {
    RecordUpdate,
    HigherOrderArgument,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BoundaryRewrite {
    pub consumer_shard: usize,
    pub provider_shard: usize,
    pub alias: String,
    pub line: usize,
    pub kind: BoundaryRewriteKind,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct BoundaryRewriteReport {
    pub files_scanned: usize,
    pub files_changed: usize,
    pub update_rebuilds: usize,
    pub higher_order_rebuilds: usize,
    pub rewrites: Vec<BoundaryRewrite>,
}

fn identifier(value: &str) -> bool {
    let mut chars = value.chars();
    matches!(chars.next(), Some(c) if c == '_' || c.is_ascii_alphabetic())
        && chars.all(|c| c == '_' || c.is_ascii_alphanumeric() || c == '\'')
}

fn identifiers(value: &str) -> impl Iterator<Item = &str> {
    value
        .split(|c: char| !(c == '_' || c == '\'' || c.is_ascii_alphanumeric()))
        .filter(|x| identifier(x))
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

fn direct_alias(shard: usize, line: &str) -> Option<BoundaryAlias> {
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
    Some(BoundaryAlias {
        provider_shard: shard,
        name: name.to_string(),
        fields: record_fields(right)?,
    })
}

fn shape_key(fields: &BTreeSet<String>) -> String {
    fields.iter().cloned().collect::<Vec<_>>().join("\u{1f}")
}

fn alias_visible(
    alias: &BoundaryAlias,
    consumer_shard: usize,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> bool {
    let Some(&consumer_gear) = shard_to_gear.get(consumer_shard) else {
        return false;
    };
    let Some(&provider_gear) = shard_to_gear.get(alias.provider_shard) else {
        return false;
    };
    provider_gear != consumer_gear
        && gear_dependencies
            .get(consumer_gear)
            .is_some_and(|dependencies| dependencies.contains(&provider_gear))
}

fn qualified_alias(alias: &BoundaryAlias) -> String {
    format!(
        "spiral_compiler_Part{:04}.{}",
        alias.provider_shard, alias.name
    )
}

fn field_before_colon(line: &str) -> Option<&str> {
    let colon = line.find(':')?;
    let prefix = &line[..colon];
    prefix
        .rsplit(|c: char| !(c == '_' || c == '\'' || c.is_ascii_alphanumeric()))
        .find(|x| identifier(x))
}

fn build_field_aliases(
    texts: &[String],
    aliases_by_name: &BTreeMap<String, Vec<BoundaryAlias>>,
) -> BTreeMap<String, Vec<BoundaryAlias>> {
    let mut result = BTreeMap::<String, BTreeSet<BoundaryAlias>>::new();
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

fn source_projection(prefix: &str) -> Option<&str> {
    let pipe = prefix.rfind("|>")?;
    let left = prefix[..pipe].trim_end();
    let dot = left.rfind('.')?;
    let projection = left[dot + 1..].trim();
    identifier(projection).then_some(projection)
}

fn lambda_binds(prefix: &str, name: &str) -> bool {
    let Some(fun_at) = prefix.rfind("fun ") else {
        return false;
    };
    let params = &prefix[fun_at + 4..];
    let Some(arrow) = params.find("->") else {
        return false;
    };
    identifiers(&params[..arrow]).any(|param| param == name)
}

fn update_shape(value: &str) -> Option<(String, BTreeSet<String>)> {
    let begin = value.find("{|")? + 2;
    let end = value[begin..].find("|}")? + begin;
    let body = value[begin..end].trim();
    let (base, updates) = body.split_once(" with ")?;
    let base = base.trim();
    if !identifier(base) {
        return None;
    }
    let mut fields = BTreeSet::new();
    for update in updates.split(';') {
        let (field, _) = update.trim().split_once('=')?;
        let field = field.trim();
        if !identifier(field) {
            return None;
        }
        fields.insert(field.to_string());
    }
    (!fields.is_empty()).then_some((base.to_string(), fields))
}

fn unique_update_target(
    source_field: &str,
    update_fields: &BTreeSet<String>,
    consumer_shard: usize,
    field_aliases: &BTreeMap<String, Vec<BoundaryAlias>>,
    aliases_by_shape: &BTreeMap<String, Vec<BoundaryAlias>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Option<BoundaryAlias> {
    let sources = field_aliases.get(source_field)?;
    let mut targets = BTreeSet::new();
    for source in sources
        .iter()
        .filter(|alias| alias_visible(alias, consumer_shard, shard_to_gear, gear_dependencies))
    {
        let mut shape = source.fields.clone();
        shape.extend(update_fields.iter().cloned());
        let Some(candidates) = aliases_by_shape.get(&shape_key(&shape)) else {
            continue;
        };
        targets.extend(
            candidates
                .iter()
                .filter(|alias| {
                    alias.fields == shape
                        && alias_visible(alias, consumer_shard, shard_to_gear, gear_dependencies)
                })
                .cloned(),
        );
    }
    (targets.len() == 1).then(|| targets.into_iter().next().expect("one target"))
}

fn rewrite_updates(
    consumer_shard: usize,
    line_number: usize,
    line: &str,
    field_aliases: &BTreeMap<String, Vec<BoundaryAlias>>,
    aliases_by_shape: &BTreeMap<String, Vec<BoundaryAlias>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> (String, Vec<BoundaryRewrite>) {
    if line.contains("__spiral_split_boundary_") {
        return (line.to_string(), Vec::new());
    }
    let mut output = line.to_string();
    let mut rewrites = Vec::new();
    let mut cursor = 0usize;
    while let Some(relative_begin) = output[cursor..].find("{|") {
        let begin = cursor + relative_begin;
        let Some(relative_end) = output[begin + 2..].find("|}") else {
            break;
        };
        let end = begin + 2 + relative_end + 2;
        let expression = output[begin..end].to_string();
        let Some((base, updated_fields)) = update_shape(&expression) else {
            cursor = end;
            continue;
        };
        let prefix = &output[..begin];
        let Some(source_field) = source_projection(prefix) else {
            cursor = end;
            continue;
        };
        if !lambda_binds(prefix, &base) {
            cursor = end;
            continue;
        }
        let Some(target) = unique_update_target(
            source_field,
            &updated_fields,
            consumer_shard,
            field_aliases,
            aliases_by_shape,
            shard_to_gear,
            gear_dependencies,
        ) else {
            cursor = end;
            continue;
        };
        let alias = qualified_alias(&target);
        let rendered = format!("({expression} : {alias})");
        output.replace_range(begin..end, &rendered);
        rewrites.push(BoundaryRewrite {
            consumer_shard,
            provider_shard: target.provider_shard,
            alias: target.name,
            line: line_number,
            kind: BoundaryRewriteKind::RecordUpdate,
        });
        cursor = begin + rendered.len();
    }
    (output, rewrites)
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct HigherOrderWitness {
    params: Vec<String>,
    alias: BoundaryAlias,
    cardinality: BoundaryCardinality,
}

fn last_identifier(value: &str) -> Option<&str> {
    value
        .rsplit(|c: char| !(c == '_' || c == '\'' || c.is_ascii_alphanumeric()))
        .find(|x| identifier(x))
}

fn annotated_alias_after_record(line: &str, record_end: usize) -> Option<&str> {
    let tail = &line[record_end..];
    let colon = tail.find(':')?;
    let token = tail[colon + 1..]
        .trim_start()
        .split(|c: char| !(c == '_' || c == '\'' || c == '.' || c.is_ascii_alphanumeric()))
        .next()?;
    let name = token.rsplit('.').next()?;
    identifier(name).then_some(name)
}

fn witness_from_line(
    consumer_shard: usize,
    line: &str,
    aliases_by_name: &BTreeMap<String, Vec<BoundaryAlias>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Option<(String, HigherOrderWitness)> {
    let fun_at = line.find("(fun ")?;
    let helper = last_identifier(&line[..fun_at])?.to_string();
    let after_fun = &line[fun_at + 5..];
    let arrow = after_fun.find("->")?;
    let params = identifiers(&after_fun[..arrow])
        .map(str::to_string)
        .collect::<Vec<_>>();
    if params.is_empty() {
        return None;
    }
    let body_offset = fun_at + 5 + arrow + 2;
    let body = &line[body_offset..];
    let record_at = body.find("{|")? + body_offset;
    let record_end = line[record_at + 2..].find("|}")? + record_at + 4;
    let fields = record_fields(&line[record_at..record_end])?;
    let alias_name = annotated_alias_after_record(line, record_end)?;
    let aliases = aliases_by_name.get(alias_name)?;
    let visible = aliases
        .iter()
        .filter(|alias| {
            alias.fields == fields
                && alias_visible(alias, consumer_shard, shard_to_gear, gear_dependencies)
        })
        .cloned()
        .collect::<Vec<_>>();
    if visible.len() != 1 {
        return None;
    }
    let before_record = &line[body_offset..record_at];
    let after_record = &line[record_end..];
    let cardinality = if before_record.contains('[') && after_record.contains(']') {
        BoundaryCardinality::List(Box::new(BoundaryCardinality::Value))
    } else {
        BoundaryCardinality::Value
    };
    Some((
        helper,
        HigherOrderWitness {
            params,
            alias: visible.into_iter().next().expect("one visible alias"),
            cardinality,
        },
    ))
}

fn higher_order_witnesses(
    consumer_shard: usize,
    text: &str,
    aliases_by_name: &BTreeMap<String, Vec<BoundaryAlias>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> BTreeMap<String, HigherOrderWitness> {
    let mut unique = BTreeMap::<String, HigherOrderWitness>::new();
    let mut ambiguous = BTreeSet::new();
    for line in text.lines() {
        let Some((helper, witness)) = witness_from_line(
            consumer_shard,
            line,
            aliases_by_name,
            shard_to_gear,
            gear_dependencies,
        ) else {
            continue;
        };
        if let Some(existing) = unique.get(&helper) {
            if existing != &witness {
                ambiguous.insert(helper);
            }
        } else {
            unique.insert(helper, witness);
        }
    }
    for helper in ambiguous {
        unique.remove(&helper);
    }
    unique
}

fn matching_paren(line: &str, open: usize) -> Option<usize> {
    let mut depth = 0usize;
    for (offset, ch) in line[open..].char_indices() {
        match ch {
            '(' => depth += 1,
            ')' => {
                depth = depth.checked_sub(1)?;
                if depth == 0 {
                    return Some(open + offset);
                }
            }
            _ => {}
        }
    }
    None
}

fn rewrite_higher_order_calls(
    consumer_shard: usize,
    line_number: usize,
    line: &str,
    witnesses: &BTreeMap<String, HigherOrderWitness>,
) -> (String, Vec<BoundaryRewrite>) {
    if line.contains("__spiral_split_boundary_") {
        return (line.to_string(), Vec::new());
    }
    let mut output = line.to_string();
    let mut rewrites = Vec::new();
    for (helper, witness) in witnesses {
        let needle = format!("{helper} (");
        let mut cursor = 0usize;
        while let Some(relative) = output[cursor..].find(&needle) {
            let helper_at = cursor + relative;
            let open = helper_at + helper.len() + 1;
            let Some(close) = matching_paren(&output, open) else {
                break;
            };
            let expression = output[open + 1..close].trim().to_string();
            if expression.starts_with("fun ") || expression.is_empty() {
                cursor = close + 1;
                continue;
            }
            let applied = format!("({expression}) {}", witness.params.join(" "));
            let alias = qualified_alias(&witness.alias);
            let fields = witness
                .alias
                .fields
                .iter()
                .map(String::as_str)
                .collect::<Vec<_>>();
            let plan =
                plan_boundary_bridge(&alias, fields, &applied, witness.cardinality.clone(), true);
            let Some(rendered) = render_boundary_bridge(&plan) else {
                cursor = close + 1;
                continue;
            };
            let lambda = format!("fun {} -> {rendered}", witness.params.join(" "));
            output.replace_range(open + 1..close, &lambda);
            rewrites.push(BoundaryRewrite {
                consumer_shard,
                provider_shard: witness.alias.provider_shard,
                alias: witness.alias.name.clone(),
                line: line_number,
                kind: BoundaryRewriteKind::HigherOrderArgument,
            });
            cursor = open + 1 + lambda.len() + 1;
        }
    }
    (output, rewrites)
}

fn rewrite_consumer_text(
    consumer_shard: usize,
    text: &str,
    field_aliases: &BTreeMap<String, Vec<BoundaryAlias>>,
    aliases_by_name: &BTreeMap<String, Vec<BoundaryAlias>>,
    aliases_by_shape: &BTreeMap<String, Vec<BoundaryAlias>>,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> (String, Vec<BoundaryRewrite>) {
    let witnesses = higher_order_witnesses(
        consumer_shard,
        text,
        aliases_by_name,
        shard_to_gear,
        gear_dependencies,
    );
    let mut rewritten = Vec::new();
    let mut rewrites = Vec::new();
    for (index, line) in text.lines().enumerate() {
        let (line, mut update_rewrites) = rewrite_updates(
            consumer_shard,
            index + 1,
            line,
            field_aliases,
            aliases_by_shape,
            shard_to_gear,
            gear_dependencies,
        );
        let (line, mut call_rewrites) =
            rewrite_higher_order_calls(consumer_shard, index + 1, &line, &witnesses);
        rewritten.push(line);
        rewrites.append(&mut update_rewrites);
        rewrites.append(&mut call_rewrites);
    }
    let mut output = rewritten.join("\n");
    if text.ends_with('\n') {
        output.push('\n');
    }
    (output, rewrites)
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let temporary = path.with_extension("fs.boundary.tmp");
    fs::write(&temporary, text)
        .map_err(|error| format!("cannot write {}: {error}", temporary.display()))?;
    fs::rename(&temporary, path)
        .map_err(|error| format!("cannot promote {}: {error}", path.display()))
}

pub fn rewrite_gear_boundaries(
    output_root: &Path,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Result<BoundaryRewriteReport, String> {
    if shard_to_gear.is_empty() {
        return Ok(BoundaryRewriteReport::default());
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

    let mut aliases_by_name = BTreeMap::<String, Vec<BoundaryAlias>>::new();
    let mut aliases_by_shape = BTreeMap::<String, Vec<BoundaryAlias>>::new();
    for alias in &aliases {
        aliases_by_name
            .entry(alias.name.clone())
            .or_default()
            .push(alias.clone());
        aliases_by_shape
            .entry(shape_key(&alias.fields))
            .or_default()
            .push(alias.clone());
    }
    let field_aliases = build_field_aliases(&texts, &aliases_by_name);

    let planned = texts
        .par_iter()
        .enumerate()
        .map(|(shard, text)| {
            let (rewritten, rewrites) = rewrite_consumer_text(
                shard,
                text,
                &field_aliases,
                &aliases_by_name,
                &aliases_by_shape,
                shard_to_gear,
                gear_dependencies,
            );
            (shard, rewritten, rewrites)
        })
        .collect::<Vec<_>>();

    let mut report = BoundaryRewriteReport {
        files_scanned: texts.len(),
        ..BoundaryRewriteReport::default()
    };
    for (shard, rewritten, mut rewrites) in planned {
        if rewritten != texts[shard] {
            atomic_write(&output_root.join(format!("Part{shard:04}.fs")), &rewritten)?;
            report.files_changed += 1;
        }
        for rewrite in &rewrites {
            match rewrite.kind {
                BoundaryRewriteKind::RecordUpdate => report.update_rebuilds += 1,
                BoundaryRewriteKind::HigherOrderArgument => report.higher_order_rebuilds += 1,
            }
        }
        report.rewrites.append(&mut rewrites);
    }
    report.rewrites.sort_by_key(|rewrite| {
        (
            rewrite.consumer_shard,
            rewrite.line,
            rewrite.provider_shard,
            rewrite.alias.clone(),
        )
    });
    Ok(report)
}

pub fn render_boundary_rewrite_tsv(report: &BoundaryRewriteReport) -> String {
    let mut output = String::from("kind\tconsumer_shard\tprovider_shard\talias\tline\n");
    for rewrite in &report.rewrites {
        let kind = match rewrite.kind {
            BoundaryRewriteKind::RecordUpdate => "record-update",
            BoundaryRewriteKind::HigherOrderArgument => "higher-order-argument",
        };
        output.push_str(&format!(
            "{kind}\t{}\t{}\t{}\t{}\n",
            rewrite.consumer_shard, rewrite.provider_shard, rewrite.alias, rewrite.line
        ));
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn rebuilds_value_in_consumer_identity() {
        let plan = plan_boundary_bridge(
            "TargetAlias",
            ["body", "id", "name"],
            "source_value",
            BoundaryCardinality::Value,
            true,
        );
        let rendered = render_boundary_bridge(&plan).expect("rebuild plan");
        assert!(rendered.contains(": TargetAlias"));
        assert!(rendered.contains("body = source_value.body"));
        assert!(rendered.contains("id = source_value.id"));
        assert!(rendered.contains("name = source_value.name"));
        assert!(!rendered.contains("fun __spiral_split_boundary_"));
    }

    #[test]
    fn rebuilds_each_list_element_at_boundary() {
        let plan = plan_boundary_bridge(
            "ArtifactAlias",
            ["code", "file_extension"],
            "external_codegen file body artifacts",
            BoundaryCardinality::List(Box::new(BoundaryCardinality::Value)),
            true,
        );
        let rendered = render_boundary_bridge(&plan).expect("rebuild plan");
        assert!(rendered.contains("List.map"));
        assert!(rendered.contains(": ArtifactAlias"));
        assert!(rendered.contains("code = __spiral_split_boundary_0.code"));
        assert!(rendered.contains("file_extension = __spiral_split_boundary_0.file_extension"));
        assert_eq!(rendered.matches("fun __spiral_split_boundary_").count(), 1);
    }

    #[test]
    fn rebuilds_update_result_from_expected_boundary_identity() {
        let plan = plan_boundary_bridge(
            "TargetAlias",
            ["body", "id", "name"],
            "{| source_value with id = key |}",
            BoundaryCardinality::Value,
            true,
        );
        let rendered = render_boundary_bridge(&plan).expect("rebuild plan");
        assert!(rendered.contains("{| source_value with id = key |}"));
        assert!(rendered.contains(": TargetAlias"));
        assert!(rendered.contains("body = {| source_value with id = key |}.body"));
    }

    #[test]
    fn fails_closed_without_visible_alias() {
        let plan = plan_boundary_bridge(
            "HiddenAlias",
            ["x"],
            "external_value",
            BoundaryCardinality::Value,
            false,
        );
        assert_eq!(render_boundary_bridge(&plan), None);
    }

    #[test]
    fn recursive_cardinality_is_compositional() {
        let plan = plan_boundary_bridge(
            "NestedAlias",
            ["x"],
            "external_batches",
            BoundaryCardinality::List(Box::new(BoundaryCardinality::List(Box::new(
                BoundaryCardinality::Value,
            )))),
            true,
        );
        let rendered = render_boundary_bridge(&plan).expect("rebuild plan");
        assert_eq!(rendered.matches("List.map").count(), 2);
        assert!(rendered.contains(": NestedAlias"));
    }

    fn alias(provider_shard: usize, name: &str, fields: &[&str]) -> BoundaryAlias {
        BoundaryAlias {
            provider_shard,
            name: name.to_string(),
            fields: fields.iter().map(|field| (*field).to_string()).collect(),
        }
    }

    fn indexes(
        aliases: &[BoundaryAlias],
    ) -> (
        BTreeMap<String, Vec<BoundaryAlias>>,
        BTreeMap<String, Vec<BoundaryAlias>>,
    ) {
        let mut by_name = BTreeMap::<String, Vec<BoundaryAlias>>::new();
        let mut by_shape = BTreeMap::<String, Vec<BoundaryAlias>>::new();
        for item in aliases {
            by_name
                .entry(item.name.clone())
                .or_default()
                .push(item.clone());
            by_shape
                .entry(shape_key(&item.fields))
                .or_default()
                .push(item.clone());
        }
        (by_name, by_shape)
    }

    #[test]
    fn infers_record_update_target_from_projection_shape_and_predecessors() {
        let source = alias(0, "SourceEnvelope", &["alpha", "beta"]);
        let target = alias(1, "ExtendedEnvelope", &["alpha", "beta", "gamma"]);
        let (by_name, by_shape) = indexes(&[source.clone(), target]);
        let field_aliases = BTreeMap::from([("entries".to_string(), vec![source])]);
        let shard_to_gear = vec![0, 1, 2];
        let dependencies = vec![BTreeSet::new(), BTreeSet::new(), BTreeSet::from([0, 1])];
        let input = "env.entries |> Map.iter (fun key value -> sink {|value with gamma=key|})\n";
        let (output, rewrites) = rewrite_consumer_text(
            2,
            input,
            &field_aliases,
            &by_name,
            &by_shape,
            &shard_to_gear,
            &dependencies,
        );
        assert!(output.contains("spiral_compiler_Part0001.ExtendedEnvelope"));
        assert!(
            output
                .contains("({|value with gamma=key|} : spiral_compiler_Part0001.ExtendedEnvelope)")
        );
        assert_eq!(rewrites.len(), 1);
        assert_eq!(rewrites[0].kind, BoundaryRewriteKind::RecordUpdate);
    }

    #[test]
    fn infers_higher_order_boundary_from_typed_witness() {
        let result = alias(0, "ResultEnvelope", &["left", "right"]);
        let (by_name, by_shape) = indexes(std::slice::from_ref(&result));
        let shard_to_gear = vec![0, 1];
        let dependencies = vec![BTreeSet::new(), BTreeSet::from([0])];
        let input = concat!(
            "let seed = dispatch (fun a b -> [({|left=a; right=b|} : ResultEnvelope)]) mode\n",
            "let next = dispatch (External.generate cfg) mode\n"
        );
        let (output, rewrites) = rewrite_consumer_text(
            1,
            input,
            &BTreeMap::new(),
            &by_name,
            &by_shape,
            &shard_to_gear,
            &dependencies,
        );
        assert!(output.contains("fun a b ->"));
        assert!(output.contains("(External.generate cfg) a b"));
        assert!(output.contains("List.map"));
        assert!(output.contains("spiral_compiler_Part0000.ResultEnvelope"));
        assert_eq!(
            rewrites
                .iter()
                .filter(|rewrite| rewrite.kind == BoundaryRewriteKind::HigherOrderArgument)
                .count(),
            1
        );
    }

    #[test]
    fn refuses_boundary_when_provider_is_not_a_predecessor() {
        let result = alias(0, "ResultEnvelope", &["left", "right"]);
        let (by_name, by_shape) = indexes(std::slice::from_ref(&result));
        let shard_to_gear = vec![0, 1];
        let dependencies = vec![BTreeSet::new(), BTreeSet::new()];
        let input = concat!(
            "let seed = dispatch (fun a b -> [({|left=a; right=b|} : ResultEnvelope)]) mode\n",
            "let next = dispatch (External.generate cfg) mode\n"
        );
        let (output, rewrites) = rewrite_consumer_text(
            1,
            input,
            &BTreeMap::new(),
            &by_name,
            &by_shape,
            &shard_to_gear,
            &dependencies,
        );
        assert_eq!(output, input);
        assert!(rewrites.is_empty());
    }

    #[test]
    fn ambiguous_update_target_stays_stable() {
        let source = alias(0, "SourceEnvelope", &["alpha", "beta"]);
        let first = alias(1, "FirstExtended", &["alpha", "beta", "gamma"]);
        let second = alias(2, "SecondExtended", &["alpha", "beta", "gamma"]);
        let (by_name, by_shape) = indexes(&[source.clone(), first, second]);
        let field_aliases = BTreeMap::from([("entries".to_string(), vec![source])]);
        let shard_to_gear = vec![0, 1, 2, 3];
        let dependencies = vec![
            BTreeSet::new(),
            BTreeSet::new(),
            BTreeSet::new(),
            BTreeSet::from([0, 1, 2]),
        ];
        let input = "env.entries |> Map.iter (fun key value -> sink {|value with gamma=key|})\n";
        let (output, rewrites) = rewrite_consumer_text(
            3,
            input,
            &field_aliases,
            &by_name,
            &by_shape,
            &shard_to_gear,
            &dependencies,
        );
        assert_eq!(output, input);
        assert!(rewrites.is_empty());
    }
}
