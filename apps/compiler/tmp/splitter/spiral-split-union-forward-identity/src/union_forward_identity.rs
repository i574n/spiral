use std::collections::{BTreeMap, BTreeSet};
use std::fs;
use std::path::Path;

#[derive(Clone, Debug, Eq, Ord, PartialEq, PartialOrd)]
struct CaseKey {
    shard: usize,
    owner: String,
    case: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct CaseDefinition {
    key: CaseKey,
    anonymous_type: String,
    normalized_type: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct UnionForwardEvidence {
    pub consumer_shard: usize,
    pub source_shard: usize,
    pub target_shard: usize,
    pub source_owner: String,
    pub source_case: String,
    pub target_owner: String,
    pub target_case: String,
    pub line: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct UnionForwardRewrite {
    pub source_shard: usize,
    pub target_shard: usize,
    pub source_owner: String,
    pub source_case: String,
    pub target_owner: String,
    pub target_case: String,
    pub alias: String,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct UnionForwardReport {
    pub files_scanned: usize,
    pub files_changed: usize,
    pub aliases_created: usize,
    pub evidences: Vec<UnionForwardEvidence>,
    pub rewrites: Vec<UnionForwardRewrite>,
    pub ambiguous_sources: usize,
    pub cyclic_sources: usize,
}

fn identifier(value: &str) -> bool {
    let mut chars = value.chars();
    matches!(chars.next(), Some(c) if c == '_' || c.is_ascii_alphabetic())
        && chars.all(|c| c == '_' || c == '\'' || c.is_ascii_alphanumeric())
}

fn normalized(value: &str) -> String {
    value
        .chars()
        .filter(|character| !character.is_whitespace())
        .collect()
}

fn owner_from_declaration(line: &str) -> Option<String> {
    let trimmed = line.trim_start();
    let rest = trimmed
        .strip_prefix("type ")
        .or_else(|| trimmed.strip_prefix("and "))?;
    let owner = rest
        .split(|character: char| {
            character.is_whitespace() || matches!(character, '=' | '<' | '(' | '[' | '{')
        })
        .next()
        .unwrap_or_default();
    identifier(owner).then(|| owner.to_owned())
}

fn top_level_boundary(line: &str) -> bool {
    let trimmed = line.trim_start();
    let indent = line.len() - trimmed.len();
    indent <= 4
        && ["type ", "and ", "let ", "module ", "open ", "exception "]
            .into_iter()
            .any(|prefix| trimmed.starts_with(prefix))
}

fn anonymous_union_case(line: &str) -> Option<(String, String)> {
    let trimmed = line.trim_start().strip_prefix('|')?.trim_start();
    let (left, right) = trimmed.split_once(" of ")?;
    let case = left.split_whitespace().next()?.trim();
    if !identifier(case) {
        return None;
    }
    let right = right.trim_start();
    if !right.starts_with("{|") {
        return None;
    }
    let end = right.find("|}")? + 2;
    Some((case.to_owned(), right[..end].to_owned()))
}

fn collect_definitions(shard: usize, text: &str) -> Vec<CaseDefinition> {
    let mut owner = None::<String>;
    let mut result = Vec::new();
    for line in text.lines() {
        if let Some(next_owner) = owner_from_declaration(line) {
            owner = Some(next_owner);
        } else if top_level_boundary(line) {
            owner = None;
        }
        let Some(current_owner) = owner.as_ref() else {
            continue;
        };
        let Some((case, anonymous_type)) = anonymous_union_case(line) else {
            continue;
        };
        result.push(CaseDefinition {
            key: CaseKey {
                shard,
                owner: current_owner.clone(),
                case,
            },
            normalized_type: normalized(&anonymous_type),
            anonymous_type,
        });
    }
    result
}

fn parse_qualified_source(value: &str) -> Option<(usize, String)> {
    let rest = value.strip_prefix("spiral_compiler_Part")?;
    let (digits, case) = rest.split_once('.')?;
    if digits.len() != 4 || !digits.chars().all(|character| character.is_ascii_digit()) {
        return None;
    }
    let shard = digits.parse::<usize>().ok()?;
    identifier(case).then(|| (shard, case.to_owned()))
}

fn source_definition<'a>(
    source_shard: usize,
    source_case: &str,
    by_provider_case: &'a BTreeMap<(usize, String), Vec<CaseDefinition>>,
) -> Option<&'a CaseDefinition> {
    let definitions = by_provider_case.get(&(source_shard, source_case.to_owned()))?;
    (definitions.len() == 1).then(|| &definitions[0])
}

fn target_uses_parameter(right: &str, target: &CaseDefinition, parameter: &str) -> bool {
    let owners = [
        format!("{}.{}", target.key.owner, target.key.case),
        format!(
            "spiral_compiler_Part{:04}.{}",
            target.key.shard, target.key.case
        ),
    ];
    owners.into_iter().any(|constructor| {
        right.contains(&format!("{constructor} {parameter}"))
            || right.contains(&format!("{constructor}({parameter},"))
            || right.contains(&format!("{constructor} ({parameter},"))
    })
}

fn direct_forward(
    consumer_shard: usize,
    line_number: usize,
    line: &str,
    definitions: &[CaseDefinition],
    by_provider_case: &BTreeMap<(usize, String), Vec<CaseDefinition>>,
) -> Option<UnionForwardEvidence> {
    let trimmed = line.trim_start().strip_prefix("| ")?;
    let (left, right) = trimmed.split_once(" -> ")?;
    let mut pattern = left.split_whitespace();
    let source_reference = pattern.next()?;
    let parameter = pattern.next()?;
    if pattern.next().is_some() || !identifier(parameter) {
        return None;
    }
    let (source_shard, source_case) = parse_qualified_source(source_reference)?;
    let source = source_definition(source_shard, &source_case, by_provider_case)?;
    let mut targets = BTreeSet::<CaseKey>::new();
    for target in definitions.iter().filter(|target| {
        target.key.shard != source.key.shard && target.normalized_type == source.normalized_type
    }) {
        if target_uses_parameter(right, target, parameter) {
            targets.insert(target.key.clone());
        }
    }
    if targets.len() != 1 {
        return None;
    }
    let target = targets.into_iter().next().expect("one target");
    Some(UnionForwardEvidence {
        consumer_shard,
        source_shard: source.key.shard,
        target_shard: target.shard,
        source_owner: source.key.owner.clone(),
        source_case: source.key.case.clone(),
        target_owner: target.owner,
        target_case: target.case,
        line: line_number,
    })
}

fn evidence_source(evidence: &UnionForwardEvidence) -> CaseKey {
    CaseKey {
        shard: evidence.source_shard,
        owner: evidence.source_owner.clone(),
        case: evidence.source_case.clone(),
    }
}

fn evidence_target(evidence: &UnionForwardEvidence) -> CaseKey {
    CaseKey {
        shard: evidence.target_shard,
        owner: evidence.target_owner.clone(),
        case: evidence.target_case.clone(),
    }
}

fn dependency_closures(dependencies: &[BTreeSet<usize>]) -> Vec<BTreeSet<usize>> {
    (0..dependencies.len())
        .map(|gear| {
            let mut closure = BTreeSet::new();
            let mut pending = dependencies[gear].iter().copied().collect::<Vec<_>>();
            while let Some(provider) = pending.pop() {
                if !closure.insert(provider) {
                    continue;
                }
                if let Some(next) = dependencies.get(provider) {
                    pending.extend(next.iter().copied());
                }
            }
            closure
        })
        .collect()
}

fn canonical_direction(
    evidence: &UnionForwardEvidence,
    shard_to_gear: &[usize],
    closures: &[BTreeSet<usize>],
) -> Option<(CaseKey, CaseKey)> {
    let source = evidence_source(evidence);
    let target = evidence_target(evidence);
    let source_gear = *shard_to_gear.get(source.shard)?;
    let target_gear = *shard_to_gear.get(target.shard)?;
    if source_gear == target_gear {
        return None;
    }
    let target_depends_source = closures
        .get(target_gear)
        .is_some_and(|dependencies| dependencies.contains(&source_gear));
    let source_depends_target = closures
        .get(source_gear)
        .is_some_and(|dependencies| dependencies.contains(&target_gear));
    match (target_depends_source, source_depends_target) {
        (true, false) => Some((target, source)),
        (false, true) => Some((source, target)),
        _ => None,
    }
}

fn resolve_sink(
    start: &CaseKey,
    direct: &BTreeMap<CaseKey, CaseKey>,
    blocked: &BTreeSet<CaseKey>,
) -> Result<CaseKey, ()> {
    let mut current = start.clone();
    let mut seen = BTreeSet::new();
    loop {
        if blocked.contains(&current) || !seen.insert(current.clone()) {
            return Err(());
        }
        let Some(next) = direct.get(&current) else {
            return Ok(current);
        };
        current = next.clone();
    }
}

fn alias_name(key: &CaseKey) -> String {
    format!("SpiralSplitAnon_{}_{}", key.owner, key.case)
}

fn rewrite_file(
    shard: usize,
    text: &str,
    replacements: &BTreeMap<CaseKey, String>,
    canonical_aliases: &BTreeMap<CaseKey, String>,
    definitions: &BTreeMap<CaseKey, CaseDefinition>,
) -> String {
    let mut owner = None::<String>;
    let mut output = String::with_capacity(text.len() + 256);
    let existing_aliases = canonical_aliases
        .iter()
        .filter(|(key, _)| key.shard == shard)
        .filter_map(|(_, alias)| {
            (text.contains(&format!("type {alias} =")) || text.contains(&format!("and {alias} =")))
                .then_some(alias.clone())
        })
        .collect::<BTreeSet<_>>();

    for line in text.split_inclusive('\n') {
        let body = line.strip_suffix('\n').unwrap_or(line);
        let newline = if line.ends_with('\n') { "\n" } else { "" };
        if let Some(next_owner) = owner_from_declaration(body) {
            let trimmed = body.trim_start();
            let indent = &body[..body.len() - trimmed.len()];
            let keyword = if trimmed.starts_with("and ") {
                "and"
            } else {
                "type"
            };
            let mut aliases = canonical_aliases
                .iter()
                .filter(|(key, _)| key.shard == shard && key.owner == next_owner)
                .collect::<Vec<_>>();
            aliases.sort_by_key(|(key, alias)| (key.case.as_str(), alias.as_str()));
            for (key, alias) in aliases {
                if existing_aliases.contains(alias) {
                    continue;
                }
                let Some(definition) = definitions.get(key) else {
                    continue;
                };
                output.push_str(&format!(
                    "{indent}{keyword} {alias} = {}\n",
                    definition.anonymous_type
                ));
            }
            owner = Some(next_owner);
        } else if top_level_boundary(body) {
            owner = None;
        }

        let mut rewritten = body.to_owned();
        if let Some(current_owner) = owner.as_ref()
            && let Some((case, anonymous_type)) = anonymous_union_case(body)
        {
            let key = CaseKey {
                shard,
                owner: current_owner.clone(),
                case,
            };
            if let Some(replacement) = replacements.get(&key) {
                rewritten = body.replacen(&anonymous_type, replacement, 1);
            }
        }
        output.push_str(&rewritten);
        output.push_str(newline);
    }
    output
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let temporary = path.with_extension("fs.union-forward.tmp");
    fs::write(&temporary, text)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

pub fn rewrite_union_forward_identities(
    output_root: &Path,
    shard_count: usize,
    shard_to_gear: &[usize],
    gear_dependencies: &[BTreeSet<usize>],
) -> Result<UnionForwardReport, String> {
    let texts = (0..shard_count)
        .map(|shard| {
            let path = output_root.join(format!("Part{shard:04}.fs"));
            fs::read_to_string(&path).map_err(|error| format!("read {}: {error}", path.display()))
        })
        .collect::<Result<Vec<_>, _>>()?;
    let definitions = texts
        .iter()
        .enumerate()
        .flat_map(|(shard, text)| collect_definitions(shard, text))
        .collect::<Vec<_>>();
    let definitions_by_key = definitions
        .iter()
        .cloned()
        .map(|definition| (definition.key.clone(), definition))
        .collect::<BTreeMap<_, _>>();
    let mut by_provider_case = BTreeMap::<(usize, String), Vec<CaseDefinition>>::new();
    for definition in &definitions {
        by_provider_case
            .entry((definition.key.shard, definition.key.case.clone()))
            .or_default()
            .push(definition.clone());
    }

    let mut evidences = Vec::new();
    for (shard, text) in texts.iter().enumerate() {
        for (line, source) in text.lines().enumerate() {
            if let Some(evidence) =
                direct_forward(shard, line + 1, source, &definitions, &by_provider_case)
            {
                evidences.push(evidence);
            }
        }
    }
    evidences.sort_by_key(|evidence| {
        (
            evidence.consumer_shard,
            evidence.line,
            evidence.source_shard,
            evidence.source_case.clone(),
        )
    });
    evidences.dedup();

    let closures = dependency_closures(gear_dependencies);
    let mut targets_by_source = BTreeMap::<CaseKey, BTreeSet<CaseKey>>::new();
    for evidence in &evidences {
        let Some((downstream, upstream)) = canonical_direction(evidence, shard_to_gear, &closures)
        else {
            continue;
        };
        targets_by_source
            .entry(downstream)
            .or_default()
            .insert(upstream);
    }
    let blocked = targets_by_source
        .iter()
        .filter(|(_, targets)| targets.len() != 1)
        .map(|(source, _)| source.clone())
        .collect::<BTreeSet<_>>();
    let direct = targets_by_source
        .iter()
        .filter(|(source, targets)| !blocked.contains(*source) && targets.len() == 1)
        .map(|(source, targets)| {
            (
                source.clone(),
                targets.iter().next().expect("one target").clone(),
            )
        })
        .collect::<BTreeMap<_, _>>();

    let mut report = UnionForwardReport {
        files_scanned: texts.len(),
        evidences,
        ambiguous_sources: blocked.len(),
        ..UnionForwardReport::default()
    };
    let mut replacements = BTreeMap::<CaseKey, String>::new();
    let mut canonical_aliases = BTreeMap::<CaseKey, String>::new();
    for source in direct.keys() {
        let sink = match resolve_sink(source, &direct, &blocked) {
            Ok(sink) => sink,
            Err(()) => {
                report.cyclic_sources += 1;
                continue;
            }
        };
        if &sink == source {
            continue;
        }
        let Some(source_definition) = definitions_by_key.get(source) else {
            continue;
        };
        let Some(sink_definition) = definitions_by_key.get(&sink) else {
            continue;
        };
        if source_definition.normalized_type != sink_definition.normalized_type {
            continue;
        }
        let alias = alias_name(&sink);
        canonical_aliases.insert(sink.clone(), alias.clone());
        replacements.insert(
            source.clone(),
            format!("spiral_compiler_Part{:04}.{alias}", sink.shard),
        );
        replacements.insert(sink.clone(), alias.clone());
        report.rewrites.push(UnionForwardRewrite {
            source_shard: source.shard,
            target_shard: sink.shard,
            source_owner: source.owner.clone(),
            source_case: source.case.clone(),
            target_owner: sink.owner.clone(),
            target_case: sink.case.clone(),
            alias,
        });
    }
    report.rewrites.sort_by_key(|rewrite| {
        (
            rewrite.source_shard,
            rewrite.source_owner.clone(),
            rewrite.source_case.clone(),
        )
    });
    report.rewrites.dedup();
    report.aliases_created = canonical_aliases.len();

    for (shard, text) in texts.iter().enumerate() {
        let rewritten = rewrite_file(
            shard,
            text,
            &replacements,
            &canonical_aliases,
            &definitions_by_key,
        );
        if rewritten != *text {
            atomic_write(&output_root.join(format!("Part{shard:04}.fs")), &rewritten)?;
            report.files_changed += 1;
        }
    }
    Ok(report)
}

pub fn render_union_forward_tsv(report: &UnionForwardReport) -> String {
    let mut output = String::from(
        "source_shard\ttarget_shard\tsource_owner\tsource_case\ttarget_owner\ttarget_case\talias\n",
    );
    for rewrite in &report.rewrites {
        output.push_str(&format!(
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\n",
            rewrite.source_shard,
            rewrite.target_shard,
            rewrite.source_owner,
            rewrite.source_case,
            rewrite.target_owner,
            rewrite.target_case,
            rewrite.alias
        ));
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn direct_forward_requires_same_parameter_and_unique_shape_target() {
        let source = CaseDefinition {
            key: CaseKey {
                shard: 20,
                owner: "ClientReq".to_owned(),
                case: "Open".to_owned(),
            },
            anonymous_type: "{| uri : string |}".to_owned(),
            normalized_type: "{|uri:string|}".to_owned(),
        };
        let target = CaseDefinition {
            key: CaseKey {
                shard: 10,
                owner: "SupervisorReq".to_owned(),
                case: "Open".to_owned(),
            },
            anonymous_type: "{| uri : string |}".to_owned(),
            normalized_type: "{|uri:string|}".to_owned(),
        };
        let definitions = vec![source.clone(), target.clone()];
        let by_provider_case = BTreeMap::from([((20, "Open".to_owned()), vec![source])]);
        let line = "| spiral_compiler_Part0020.Open x -> send (SupervisorReq.Open x)";
        let evidence =
            direct_forward(30, 7, line, &definitions, &by_provider_case).expect("forward");
        assert_eq!(evidence.source_shard, 20);
        assert_eq!(evidence.target_shard, 10);
        let tuple_line =
            "| spiral_compiler_Part0020.Open x -> job (fun res -> SupervisorReq.Open(x,res))";
        assert!(direct_forward(30, 8, tuple_line, &definitions, &by_provider_case).is_some());
    }

    #[test]
    fn reciprocal_forwarding_is_rejected_as_a_cycle() {
        let a = CaseKey {
            shard: 1,
            owner: "A".to_owned(),
            case: "Open".to_owned(),
        };
        let b = CaseKey {
            shard: 2,
            owner: "B".to_owned(),
            case: "Open".to_owned(),
        };
        let direct = BTreeMap::from([(a.clone(), b.clone()), (b.clone(), a.clone())]);
        assert!(resolve_sink(&a, &direct, &BTreeSet::new()).is_err());
    }

    #[test]
    fn canonical_direction_uses_the_existing_predecessor() {
        let evidence = UnionForwardEvidence {
            consumer_shard: 30,
            source_shard: 20,
            target_shard: 10,
            source_owner: "ClientReq".to_owned(),
            source_case: "Open".to_owned(),
            target_owner: "SupervisorReq".to_owned(),
            target_case: "Open".to_owned(),
            line: 1,
        };
        let mut shard_to_gear = vec![0; 31];
        shard_to_gear[20] = 0;
        shard_to_gear[10] = 1;
        let dependencies = vec![BTreeSet::new(), BTreeSet::from([0])];
        let closures = dependency_closures(&dependencies);
        let (redirect, canonical) =
            canonical_direction(&evidence, &shard_to_gear, &closures).expect("ordered");
        assert_eq!(redirect.shard, 10);
        assert_eq!(canonical.shard, 20);
    }

    #[test]
    fn rewrite_inserts_alias_only_at_flow_sink() {
        let source_text = "    type ClientReq =\n        | Open of {| uri : string |}\n";
        let target_text = "    type SupervisorReq =\n        | Open of {| uri : string |}\n";
        let source = CaseKey {
            shard: 20,
            owner: "ClientReq".to_owned(),
            case: "Open".to_owned(),
        };
        let target = CaseKey {
            shard: 10,
            owner: "SupervisorReq".to_owned(),
            case: "Open".to_owned(),
        };
        let definitions = BTreeMap::from([
            (
                source.clone(),
                CaseDefinition {
                    key: source.clone(),
                    anonymous_type: "{| uri : string |}".to_owned(),
                    normalized_type: "{|uri:string|}".to_owned(),
                },
            ),
            (
                target.clone(),
                CaseDefinition {
                    key: target.clone(),
                    anonymous_type: "{| uri : string |}".to_owned(),
                    normalized_type: "{|uri:string|}".to_owned(),
                },
            ),
        ]);
        let alias = alias_name(&target);
        let replacements = BTreeMap::from([
            (source, format!("spiral_compiler_Part0010.{alias}")),
            (target.clone(), alias.clone()),
        ]);
        let aliases = BTreeMap::from([(target, alias.clone())]);
        let source_rewritten = rewrite_file(20, source_text, &replacements, &aliases, &definitions);
        let target_rewritten = rewrite_file(10, target_text, &replacements, &aliases, &definitions);
        assert!(source_rewritten.contains(&format!("Open of spiral_compiler_Part0010.{alias}")));
        assert!(target_rewritten.contains(&format!("type {alias} = {{| uri : string |}}")));
        assert!(target_rewritten.contains(&format!("Open of {alias}")));
    }
}
