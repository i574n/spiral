use spiral_split_binding_header::{binding_header, identifiers, keyword};
use spiral_split_call_contract::unshadowed_projected_fields;
use spiral_split_call_scope::{ParameterContract, binding_contract, simple_arguments_after_call};
use spiral_split_match_branch::{MatchBranch, MatchPatternAnnotation};
use spiral_split_model::{Declaration, DeclarationId, Linked, SplitPlan};
use spiral_split_record_owner::RecordProjectionIndex;
use std::collections::{BTreeMap, BTreeSet};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Discovered;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Resolved;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchOwnerCandidate {
    pub branch: usize,
    pub binding: String,
    pub fields: BTreeSet<String>,
    pub evidence: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchOwnerEvidence {
    pub branch: usize,
    pub binding: String,
    pub owner_type: String,
    pub fields: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum MatchOwnerBlocker {
    InvalidBranchSpan(usize),
    NoProjectedBinding(usize),
    NoUniqueRecordOwner(usize),
    AmbiguousProjectedBinding(usize),
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum MatchOwnerResolution {
    Unique(MatchOwnerEvidence),
    Unresolved {
        branch: usize,
        blocker: MatchOwnerBlocker,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct MatchOwnerPlan<S> {
    pub owner: DeclarationId,
    pub candidates: Vec<MatchOwnerCandidate>,
    pub resolutions: Vec<MatchOwnerResolution>,
    pub requested: Vec<usize>,
    stage: PhantomData<fn() -> S>,
}

fn lowercase_binding(name: &str) -> bool {
    name != "_"
        && !keyword(name)
        && name
            .chars()
            .next()
            .is_some_and(|character| character.is_ascii_lowercase())
}

fn branch_lines<'a>(owner: &'a Declaration<Linked>, branch: &MatchBranch) -> Option<Vec<&'a str>> {
    let lines = owner.text.lines().collect::<Vec<_>>();
    let start = branch.start_line.checked_sub(owner.span.start)?;
    let end = branch.end_line.checked_sub(owner.span.start)?;
    (start < end && end <= lines.len()).then(|| lines[start..end].to_vec())
}

fn branch_evidence_text(lines: &[&str]) -> String {
    let Some(first) = lines.first() else {
        return String::new();
    };
    let mut evidence = Vec::<String>::new();
    if let Some((head, tail)) = first.trim_start().split_once("->") {
        if let Some((_, guard)) = head.split_once(" when ") {
            let guard = guard.trim();
            if !guard.is_empty() {
                evidence.push(guard.to_owned());
            }
        }
        let tail = tail.trim();
        if !tail.is_empty() {
            evidence.push(tail.to_owned());
        }
    }
    evidence.extend(lines.iter().skip(1).map(|line| (*line).to_owned()));
    evidence.join("\n")
}

fn type_leaf(type_symbol: &str) -> String {
    let generic_at = type_symbol.find('<').unwrap_or(type_symbol.len());
    let base = &type_symbol[..generic_at];
    let suffix = &type_symbol[generic_at..];
    format!("{}{}", base.rsplit('.').next().unwrap_or(base), suffix)
}

fn resolve_type_candidates(types: BTreeSet<String>) -> Option<String> {
    if types.len() == 1 {
        return types.into_iter().next();
    }
    let leaves = types
        .iter()
        .map(|value| type_leaf(value))
        .collect::<BTreeSet<_>>();
    if leaves.len() != 1 {
        return None;
    }
    let qualified = types
        .iter()
        .filter(|value| {
            value
                .split('<')
                .next()
                .is_some_and(|base| base.contains('.'))
        })
        .cloned()
        .collect::<Vec<_>>();
    match qualified.as_slice() {
        [only] => Some(only.clone()),
        _ => None,
    }
}

fn explicit_call_owner_type(
    plan: &SplitPlan,
    projection_index: &RecordProjectionIndex,
    owner: DeclarationId,
    evidence: &str,
    binding: &str,
) -> Option<String> {
    let used_symbols = identifiers(evidence).into_iter().collect::<BTreeSet<_>>();
    let mut types = BTreeSet::<String>::new();
    for declaration in &plan.declarations {
        let symbols = declaration
            .text
            .lines()
            .filter_map(binding_header)
            .filter(|header| !header.parameters.is_empty() && used_symbols.contains(&header.name))
            .map(|header| header.name)
            .collect::<BTreeSet<_>>();
        for symbol in symbols {
            let Some(contract) = binding_contract(&declaration.text, &symbol) else {
                continue;
            };
            for call in simple_arguments_after_call(evidence, &symbol) {
                for (index, argument) in call.arguments.iter().enumerate() {
                    if argument.as_deref() != Some(binding) {
                        continue;
                    }
                    if let Some(ParameterContract::Explicit { type_symbol, .. }) =
                        contract.parameters.get(index)
                        && let Some(owner_type) = projection_index
                            .unique_visible_owner_type_for_leaf(plan, owner, type_symbol)
                    {
                        types.insert(owner_type);
                    }
                }
            }
        }
    }
    resolve_type_candidates(types)
}

fn merge_owner_types(projected: Option<String>, called: Option<String>) -> Option<String> {
    let types = projected.into_iter().chain(called).collect::<BTreeSet<_>>();
    resolve_type_candidates(types)
}

#[must_use]
pub fn discover_match_owners(
    owner: &Declaration<Linked>,
    branches: &[MatchBranch],
    selected: &[usize],
) -> MatchOwnerPlan<Discovered> {
    let requested = selected.iter().copied().collect::<BTreeSet<_>>();
    let mut candidates = Vec::new();
    let mut resolutions = Vec::new();
    for branch in branches
        .iter()
        .filter(|branch| requested.contains(&branch.ordinal))
    {
        let Some(lines) = branch_lines(owner, branch) else {
            resolutions.push(MatchOwnerResolution::Unresolved {
                branch: branch.ordinal,
                blocker: MatchOwnerBlocker::InvalidBranchSpan(branch.ordinal),
            });
            continue;
        };
        let evidence = branch_evidence_text(&lines);
        let mut bindings = identifiers(&branch.pattern)
            .into_iter()
            .filter(|name| lowercase_binding(name))
            .collect::<BTreeSet<_>>();
        bindings.extend(
            branch
                .captures
                .iter()
                .filter(|name| lowercase_binding(name))
                .cloned(),
        );
        let mut branch_candidates = bindings
            .into_iter()
            .map(|binding| MatchOwnerCandidate {
                branch: branch.ordinal,
                fields: unshadowed_projected_fields(&evidence, &binding),
                evidence: evidence.clone(),
                binding,
            })
            .filter(|candidate| candidate.fields.len() >= 2)
            .collect::<Vec<_>>();
        if branch_candidates.is_empty() {
            resolutions.push(MatchOwnerResolution::Unresolved {
                branch: branch.ordinal,
                blocker: MatchOwnerBlocker::NoProjectedBinding(branch.ordinal),
            });
        }
        candidates.append(&mut branch_candidates);
    }
    MatchOwnerPlan {
        owner: owner.id,
        candidates,
        resolutions,
        requested: requested.into_iter().collect(),
        stage: PhantomData,
    }
}

impl MatchOwnerPlan<Discovered> {
    #[must_use]
    pub fn resolve(self, plan: &SplitPlan) -> MatchOwnerPlan<Resolved> {
        let index = RecordProjectionIndex::new(plan);
        let mut resolutions = self.resolutions;
        for branch in &self.requested {
            if resolutions.iter().any(|resolution| match resolution {
                MatchOwnerResolution::Unique(evidence) => evidence.branch == *branch,
                MatchOwnerResolution::Unresolved {
                    branch: current, ..
                } => current == branch,
            }) {
                continue;
            }
            let candidates = self
                .candidates
                .iter()
                .filter(|candidate| candidate.branch == *branch)
                .collect::<Vec<_>>();
            let unique = candidates
                .iter()
                .filter_map(|candidate| {
                    let projected = index.unique_owner_type_for_projections(
                        plan,
                        self.owner,
                        &candidate.fields,
                    );
                    let called = explicit_call_owner_type(
                        plan,
                        &index,
                        self.owner,
                        &candidate.evidence,
                        &candidate.binding,
                    );
                    merge_owner_types(projected, called).map(|owner_type| MatchOwnerEvidence {
                        branch: *branch,
                        binding: candidate.binding.clone(),
                        owner_type,
                        fields: candidate.fields.clone(),
                    })
                })
                .collect::<Vec<_>>();
            let resolution = match unique.as_slice() {
                [evidence] => MatchOwnerResolution::Unique(evidence.clone()),
                [] => MatchOwnerResolution::Unresolved {
                    branch: *branch,
                    blocker: MatchOwnerBlocker::NoUniqueRecordOwner(*branch),
                },
                _ => MatchOwnerResolution::Unresolved {
                    branch: *branch,
                    blocker: MatchOwnerBlocker::AmbiguousProjectedBinding(*branch),
                },
            };
            resolutions.push(resolution);
        }
        resolutions.sort_by_key(|resolution| match resolution {
            MatchOwnerResolution::Unique(evidence) => evidence.branch,
            MatchOwnerResolution::Unresolved { branch, .. } => *branch,
        });
        MatchOwnerPlan {
            owner: self.owner,
            candidates: self.candidates,
            resolutions,
            requested: self.requested,
            stage: PhantomData,
        }
    }
}

impl MatchOwnerPlan<Resolved> {
    #[must_use]
    pub fn annotations(&self) -> BTreeMap<usize, MatchPatternAnnotation> {
        self.resolutions
            .iter()
            .filter_map(|resolution| match resolution {
                MatchOwnerResolution::Unique(evidence) => Some((
                    evidence.branch,
                    MatchPatternAnnotation {
                        binding: evidence.binding.clone(),
                        owner_type: evidence.owner_type.clone(),
                    },
                )),
                MatchOwnerResolution::Unresolved { .. } => None,
            })
            .collect()
    }

    #[must_use]
    pub fn annotated_branches(&self) -> usize {
        self.resolutions
            .iter()
            .filter(|resolution| matches!(resolution, MatchOwnerResolution::Unique(_)))
            .count()
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_match_branch::{BranchDisposition, MatchBranch};
    use spiral_split_model::{
        BoundaryReason, CompilerProfile, DeclarationKind, LineSpan, Raw, ReferenceMode, Shard,
        SourceText, SplitPolicy, fnv1a64,
    };
    use std::path::PathBuf;

    fn declaration(
        id: usize,
        start: usize,
        text: &str,
        kind: DeclarationKind,
    ) -> Declaration<Linked> {
        Declaration::<Raw>::new(
            DeclarationId(id),
            LineSpan {
                start,
                end: start + text.lines().count(),
            },
            text.lines().next().unwrap_or_default().to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(kind),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
        .restage()
    }

    fn plan() -> SplitPlan {
        let record = "module EvalWorklist =\n    type Frame = { status : int; phase : int; payload : int; identity : int }\n    with\n        member this.semanticCell = this.payload";
        let owner = "let outer input =\n    let target input =\n        match input with\n        | Some pinned when pinned.status > 0 ->\n            pinned.phase + pinned.payload + pinned.identity + pinned.semanticCell\n        | None ->\n            0\n    target input";
        let declarations = vec![
            declaration(0, 1, record, DeclarationKind::Module),
            declaration(1, 10, owner, DeclarationKind::LetGroup),
        ];
        let source_text = format!("{record}\n{owner}\n");
        SplitPlan {
            source: SourceText {
                path: PathBuf::from("fixture.fs"),
                lines: source_text.lines().map(str::to_owned).collect(),
                module_line: 1,
                module_name: "spiral_compiler".to_owned(),
                profile: CompilerProfile::Hopac,
                fingerprint: fnv1a64(source_text.as_bytes()),
                bytes: source_text.len(),
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Direct,
            declarations,
            shards: vec![
                Shard {
                    id: 0,
                    declarations: vec![DeclarationId(0)],
                    direct_dependencies: BTreeSet::new(),
                    compile_dependencies: BTreeSet::new(),
                    ambient_opens: Vec::new(),
                    line_count: 2,
                    bytes: record.len(),
                    layer: 0,
                    oversize: false,
                    fingerprint: fnv1a64(record.as_bytes()),
                },
                Shard {
                    id: 1,
                    declarations: vec![DeclarationId(1)],
                    direct_dependencies: BTreeSet::from([0]),
                    compile_dependencies: BTreeSet::from([0]),
                    ambient_opens: Vec::new(),
                    line_count: owner.lines().count(),
                    bytes: owner.len(),
                    layer: 1,
                    oversize: false,
                    fingerprint: fnv1a64(owner.as_bytes()),
                },
            ],
        }
    }

    #[test]
    fn resolves_pattern_binding_from_projected_fields_without_pattern_shadowing() {
        let plan = plan();
        let branch = MatchBranch {
            ordinal: 0,
            start_line: 13,
            end_line: 15,
            line_count: 2,
            pattern: "Some pinned".to_owned(),
            guard: Some("pinned.status > 0".to_owned()),
            captures: BTreeSet::new(),
            mutable_captures: BTreeMap::new(),
            mirror_guard: true,
            disposition: BranchDisposition::Extractable,
        };
        let discovered = discover_match_owners(&plan.declarations[1], &[branch], &[0]);
        assert_eq!(discovered.candidates.len(), 1);
        assert_eq!(
            discovered.candidates[0].fields,
            BTreeSet::from([
                "identity".to_owned(),
                "payload".to_owned(),
                "phase".to_owned(),
                "semanticCell".to_owned(),
                "status".to_owned(),
            ])
        );
        let resolved = discovered.resolve(&plan);
        let annotations = resolved.annotations();
        assert_eq!(resolved.annotated_branches(), 1);
        assert_eq!(annotations[&0].binding, "pinned");
        assert_eq!(annotations[&0].owner_type, "EvalWorklist.Frame");
    }

    fn call_contract_plan(conflicting_call: bool) -> (SplitPlan, MatchBranch) {
        let frame = "module EvalWorklist =\n    type Frame = { status : int; reason : int }";
        let ingress = "module Other =\n    type Ingress = { status : int; reason : int }";
        let use_frame = "let use_frame (frame: EvalWorklist.Frame) = frame.status";
        let use_other = "let use_other (frame: Other.Ingress) = frame.status";
        let owner = if conflicting_call {
            "let outer input =\n    match input with\n    | Some pinned ->\n        let rank = use_frame pinned + use_other pinned\n        pinned.status + pinned.reason + rank\n    | None -> 0"
        } else {
            "let outer input =\n    match input with\n    | Some pinned ->\n        let rank = use_frame pinned\n        pinned.status + pinned.reason + rank\n    | None -> 0"
        };
        let declarations = vec![
            declaration(0, 1, frame, DeclarationKind::Module),
            declaration(1, 4, ingress, DeclarationKind::Module),
            declaration(2, 7, use_frame, DeclarationKind::LetGroup),
            declaration(3, 9, use_other, DeclarationKind::LetGroup),
            declaration(4, 20, owner, DeclarationKind::LetGroup),
        ];
        let source_text = format!("{frame}\n{ingress}\n{use_frame}\n{use_other}\n{owner}\n");
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("call-contract-fixture.fs"),
                lines: source_text.lines().map(str::to_owned).collect(),
                module_line: 1,
                module_name: "spiral_compiler".to_owned(),
                profile: CompilerProfile::Hopac,
                fingerprint: fnv1a64(source_text.as_bytes()),
                bytes: source_text.len(),
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Direct,
            declarations,
            shards: vec![
                Shard {
                    id: 0,
                    declarations: vec![DeclarationId(0)],
                    direct_dependencies: BTreeSet::new(),
                    compile_dependencies: BTreeSet::new(),
                    ambient_opens: Vec::new(),
                    line_count: frame.lines().count(),
                    bytes: frame.len(),
                    layer: 0,
                    oversize: false,
                    fingerprint: fnv1a64(frame.as_bytes()),
                },
                Shard {
                    id: 1,
                    declarations: vec![DeclarationId(1)],
                    direct_dependencies: BTreeSet::new(),
                    compile_dependencies: BTreeSet::new(),
                    ambient_opens: Vec::new(),
                    line_count: ingress.lines().count(),
                    bytes: ingress.len(),
                    layer: 0,
                    oversize: false,
                    fingerprint: fnv1a64(ingress.as_bytes()),
                },
                Shard {
                    id: 2,
                    declarations: vec![DeclarationId(2)],
                    direct_dependencies: BTreeSet::from([0]),
                    compile_dependencies: BTreeSet::from([0]),
                    ambient_opens: Vec::new(),
                    line_count: use_frame.lines().count(),
                    bytes: use_frame.len(),
                    layer: 1,
                    oversize: false,
                    fingerprint: fnv1a64(use_frame.as_bytes()),
                },
                Shard {
                    id: 3,
                    declarations: vec![DeclarationId(3)],
                    direct_dependencies: BTreeSet::from([1]),
                    compile_dependencies: BTreeSet::from([1]),
                    ambient_opens: Vec::new(),
                    line_count: use_other.lines().count(),
                    bytes: use_other.len(),
                    layer: 1,
                    oversize: false,
                    fingerprint: fnv1a64(use_other.as_bytes()),
                },
                Shard {
                    id: 4,
                    declarations: vec![DeclarationId(4)],
                    direct_dependencies: BTreeSet::from([0, 1, 2, 3]),
                    compile_dependencies: BTreeSet::from([0, 1, 2, 3]),
                    ambient_opens: Vec::new(),
                    line_count: owner.lines().count(),
                    bytes: owner.len(),
                    layer: 2,
                    oversize: false,
                    fingerprint: fnv1a64(owner.as_bytes()),
                },
            ],
        };
        let branch = MatchBranch {
            ordinal: 0,
            start_line: 22,
            end_line: 25,
            line_count: 3,
            pattern: "Some pinned".to_owned(),
            guard: None,
            captures: BTreeSet::new(),
            mutable_captures: BTreeMap::new(),
            mirror_guard: false,
            disposition: BranchDisposition::Extractable,
        };
        (plan, branch)
    }

    #[test]
    fn resolves_ambiguous_projections_from_unique_explicit_call_contract() {
        let (plan, branch) = call_contract_plan(false);
        let discovered = discover_match_owners(&plan.declarations[4], &[branch], &[0]);
        assert_eq!(discovered.candidates.len(), 1);
        assert_eq!(
            discovered.candidates[0].fields,
            BTreeSet::from(["reason".to_owned(), "status".to_owned()])
        );
        let resolved = discovered.resolve(&plan);
        let annotations = resolved.annotations();
        assert_eq!(resolved.annotated_branches(), 1);
        assert_eq!(annotations[&0].binding, "pinned");
        assert_eq!(annotations[&0].owner_type, "EvalWorklist.Frame");
    }

    #[test]
    fn resolves_capture_parameter_from_unique_projected_record_owner() {
        let records = "module EvalWorklist =\n    type WorkItem = { commitOrdinal : int; generation : int; workUnit : int }\n    type WorkExecutionPlan = { commitOrdinal : int; generation : int }";
        let owner = "let outer item input =\n    match input with\n    | Cancelled cancellation ->\n        item.commitOrdinal + item.generation + item.workUnit + cancellation\n    | Other -> 0";
        let declarations = vec![
            declaration(0, 1, records, DeclarationKind::Module),
            declaration(1, 10, owner, DeclarationKind::LetGroup),
        ];
        let source_text = format!("{records}\n{owner}\n");
        let plan = SplitPlan {
            source: SourceText {
                path: PathBuf::from("capture-owner-fixture.fs"),
                lines: source_text.lines().map(str::to_owned).collect(),
                module_line: 1,
                module_name: "spiral_compiler".to_owned(),
                profile: CompilerProfile::Hopac,
                fingerprint: fnv1a64(source_text.as_bytes()),
                bytes: source_text.len(),
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Direct,
            declarations,
            shards: vec![
                Shard {
                    id: 0,
                    declarations: vec![DeclarationId(0)],
                    direct_dependencies: BTreeSet::new(),
                    compile_dependencies: BTreeSet::new(),
                    ambient_opens: Vec::new(),
                    line_count: records.lines().count(),
                    bytes: records.len(),
                    layer: 0,
                    oversize: false,
                    fingerprint: fnv1a64(records.as_bytes()),
                },
                Shard {
                    id: 1,
                    declarations: vec![DeclarationId(1)],
                    direct_dependencies: BTreeSet::from([0]),
                    compile_dependencies: BTreeSet::from([0]),
                    ambient_opens: Vec::new(),
                    line_count: owner.lines().count(),
                    bytes: owner.len(),
                    layer: 1,
                    oversize: false,
                    fingerprint: fnv1a64(owner.as_bytes()),
                },
            ],
        };
        let branch = MatchBranch {
            ordinal: 0,
            start_line: 12,
            end_line: 14,
            line_count: 2,
            pattern: "Cancelled cancellation".to_owned(),
            guard: None,
            captures: BTreeSet::from(["item".to_owned()]),
            mutable_captures: BTreeMap::new(),
            mirror_guard: false,
            disposition: BranchDisposition::Extractable,
        };
        let discovered = discover_match_owners(&plan.declarations[1], &[branch], &[0]);
        assert_eq!(discovered.candidates.len(), 1);
        assert_eq!(discovered.candidates[0].binding, "item");
        assert_eq!(
            discovered.candidates[0].fields,
            BTreeSet::from([
                "commitOrdinal".to_owned(),
                "generation".to_owned(),
                "workUnit".to_owned(),
            ])
        );
        let resolved = discovered.resolve(&plan);
        let annotations = resolved.annotations();
        assert_eq!(annotations[&0].binding, "item");
        assert_eq!(annotations[&0].owner_type, "EvalWorklist.WorkItem");
    }

    #[test]
    fn conflicting_explicit_call_contracts_remain_fail_closed() {
        let (plan, branch) = call_contract_plan(true);
        let resolved = discover_match_owners(&plan.declarations[4], &[branch], &[0]).resolve(&plan);
        assert_eq!(resolved.annotated_branches(), 0);
        assert!(matches!(
            resolved.resolutions.as_slice(),
            [MatchOwnerResolution::Unresolved {
                blocker: MatchOwnerBlocker::NoUniqueRecordOwner(0),
                ..
            }]
        ));
    }
}
