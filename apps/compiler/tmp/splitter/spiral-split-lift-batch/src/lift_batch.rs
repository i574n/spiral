use spiral_split_capture_closure::{
    CaptureClosureBlocker, CaptureNode, CaptureOrigin, close_capture_requirements,
};
use spiral_split_detached_call::{DetachedCallEvidence, certify_detached_call};
use spiral_split_fsharp_lex::{LexicalState, SymbolLexicalProbe, probe_symbol_states};
use spiral_split_lift::LocalGroup;
use spiral_split_lift_plan::{CaptureFlow, ParameterSlot, ParametricComponent};
use spiral_split_lift_rewrite::{
    AppliedEdit, CallRequirement, RewriteBlocker, outer_recursive_group_head,
    rewrite_bounded_owner_with_requirement, rewrite_call_sites,
};
use spiral_split_model::{Declaration, DeclarationId, Linked, fnv1a64};
use spiral_split_recursive_header_stabilize::stabilize_generated_capture_headers;
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct BatchApplied;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DetachedCallDiagnostic {
    pub component: usize,
    pub symbol: String,
    pub owner_mentions: usize,
    pub hoisted_mentions: usize,
    pub owner_line_calls: usize,
    pub owner_probe: SymbolLexicalProbe,
    pub owner_entry_line_text: String,
    pub owner_first_string_newline_text: String,
    pub owner_symbol_state_entry_text: String,
    pub owner_symbol_state_prev_line_text: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum BatchBlocker {
    EmptySelection,
    DuplicateComponent(usize),
    ComponentNotFound(usize),
    OwnerMismatch(usize),
    ComponentBlocked(usize),
    MultiGroupComponent(usize),
    GroupNotFound(usize),
    OverlappingGroups {
        first: usize,
        second: usize,
    },
    InvalidAdjustedSpan(usize),
    Rewrite {
        component: usize,
        blocker: RewriteBlocker,
    },
    LexicalImbalance {
        component: usize,
        state: LexicalState,
        entry_line: usize,
    },
    CaptureClosure(CaptureClosureBlocker),
    DetachedCallUnowned(Box<DetachedCallDiagnostic>),
}

impl Display for BatchBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::EmptySelection => formatter.write_str("empty-selection"),
            Self::DuplicateComponent(component) => {
                write!(formatter, "duplicate-component:{component}")
            }
            Self::ComponentNotFound(component) => {
                write!(formatter, "component-not-found:{component}")
            }
            Self::OwnerMismatch(component) => write!(formatter, "owner-mismatch:{component}"),
            Self::ComponentBlocked(component) => write!(formatter, "component-blocked:{component}"),
            Self::MultiGroupComponent(component) => {
                write!(formatter, "multi-group-component:{component}")
            }
            Self::GroupNotFound(group) => write!(formatter, "group-not-found:{group}"),
            Self::OverlappingGroups { first, second } => {
                write!(formatter, "overlapping-groups:{first}:{second}")
            }
            Self::InvalidAdjustedSpan(component) => {
                write!(formatter, "invalid-adjusted-span:{component}")
            }
            Self::Rewrite { component, blocker } => {
                write!(formatter, "rewrite:{component}:{blocker}")
            }
            Self::LexicalImbalance {
                component,
                state,
                entry_line,
            } => write!(
                formatter,
                "lexical-imbalance:{component}:{state}:entry-line={entry_line}"
            ),
            Self::CaptureClosure(blocker) => write!(formatter, "capture-closure:{blocker}"),
            Self::DetachedCallUnowned(diagnostic) => {
                let DetachedCallDiagnostic {
                    component,
                    symbol,
                    owner_mentions,
                    hoisted_mentions,
                    owner_line_calls,
                    owner_probe,
                    owner_entry_line_text,
                    owner_first_string_newline_text,
                    owner_symbol_state_entry_text,
                    owner_symbol_state_prev_line_text,
                } = diagnostic.as_ref();
                write!(
                    formatter,
                    "detached-call-unowned:{component}:{symbol}:owner-mentions={owner_mentions}:hoisted-mentions={hoisted_mentions}:owner-line-calls={owner_line_calls}:lex-code={}:lex-line={}:lex-block={}:lex-string={}:lex-verbatim={}:lex-char={}:lex-final={}:lex-entry-line={}:lex-entry-byte={}:lex-first-string-newline={}:lex-symbol-line={}:lex-symbol-entry-line={}:lex-symbol-second-prior-entry-line={}:lex-symbol-last-code-line={}:lex-entry-text={owner_entry_line_text:?}:lex-first-string-newline-text={owner_first_string_newline_text:?}:lex-symbol-entry-text={owner_symbol_state_entry_text:?}:lex-symbol-second-prior-text={owner_symbol_state_prev_line_text:?}",
                    owner_probe.code,
                    owner_probe.line_comment,
                    owner_probe.block_comment,
                    owner_probe.string_literal,
                    owner_probe.verbatim_string,
                    owner_probe.character_literal,
                    owner_probe.final_state,
                    owner_probe.final_state_entry_line,
                    owner_probe.final_state_entry_offset,
                    owner_probe.first_string_newline_line,
                    owner_probe.first_symbol_line,
                    owner_probe.first_symbol_state_entry_line,
                    owner_probe.first_symbol_second_prior_state_entry_line,
                    owner_probe.first_symbol_last_code_line,
                )
            }
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BatchComponentReceipt {
    pub component: usize,
    pub group: usize,
    pub start_line: usize,
    pub end_line: usize,
    pub removed_lines: usize,
    pub rewritten_calls: usize,
    pub detached_unused: bool,
    pub parameters: Vec<String>,
    pub lifted_names: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct BatchRewriteArtifact<S> {
    pub owner: DeclarationId,
    pub components: Vec<usize>,
    pub original_fingerprint: u64,
    pub output_fingerprint: u64,
    pub hoisted_text: String,
    pub owner_text: String,
    pub full_text: String,
    pub rewritten_calls: usize,
    pub parameters: Vec<String>,
    pub edits: Vec<AppliedEdit>,
    pub receipts: Vec<BatchComponentReceipt>,
    stage: PhantomData<fn() -> S>,
}

impl BatchRewriteArtifact<BatchApplied> {
    #[must_use]
    pub fn render_receipt(&self) -> String {
        let mut output = String::new();
        let _ = writeln!(
            output,
            "owner components original_fingerprint output_fingerprint rewritten_calls parameters hoisted_lines owner_lines"
        );
        let _ = writeln!(
            output,
            "{} {} {} {} {} {} {} {}",
            self.owner.0,
            self.components
                .iter()
                .map(usize::to_string)
                .collect::<Vec<_>>()
                .join(","),
            self.original_fingerprint,
            self.output_fingerprint,
            self.rewritten_calls,
            self.parameters.join(","),
            self.hoisted_text.lines().count(),
            self.owner_text.lines().count(),
        );
        let _ = writeln!(
            output,
            "component group start_line end_line removed_lines rewritten_calls detached_unused parameters lifted_names"
        );
        for receipt in &self.receipts {
            let _ = writeln!(
                output,
                "{} {} {} {} {} {} {} {} {}",
                receipt.component,
                receipt.group,
                receipt.start_line,
                receipt.end_line,
                receipt.removed_lines,
                receipt.rewritten_calls,
                receipt.detached_unused,
                receipt.parameters.join(","),
                receipt.lifted_names,
            );
        }
        output
    }
}

#[derive(Clone, Debug)]
struct Candidate<'a> {
    component: ParametricComponent,
    group_index: usize,
    group: &'a LocalGroup,
}

fn closure_flow(parameter: &str, origin: &CaptureOrigin) -> CaptureFlow {
    match origin {
        CaptureOrigin::Direct => CaptureFlow::Direct {
            parameter: parameter.to_owned(),
        },
        CaptureOrigin::Through { provider, tail } => CaptureFlow::Through {
            parameter: parameter.to_owned(),
            provider: *provider,
            tail: Box::new(closure_flow(parameter, tail)),
        },
    }
}

fn close_candidate_parameters(candidates: &mut [Candidate<'_>]) -> Result<(), BatchBlocker> {
    let nodes = candidates
        .iter()
        .map(|candidate| CaptureNode {
            component: candidate.component.component,
            names: candidate.component.names.clone(),
            references: candidate.group.references.clone(),
            parameters: candidate
                .component
                .parameters
                .iter()
                .map(|slot| slot.name.clone())
                .collect(),
            bound: candidate.group.parameters.clone(),
        })
        .collect::<Vec<_>>();
    let closure = close_capture_requirements(&nodes).map_err(BatchBlocker::CaptureClosure)?;
    for candidate in candidates {
        let existing = candidate
            .component
            .parameters
            .iter()
            .map(|slot| (slot.name.clone(), slot.clone()))
            .collect::<BTreeMap<_, _>>();
        let required = closure
            .required_for(candidate.component.component)
            .expect("selected component must exist in capture closure");
        candidate.component.parameters = required
            .iter()
            .enumerate()
            .map(|(ordinal, (name, origin))| {
                if let Some(existing) = existing.get(name) {
                    let mut slot = existing.clone();
                    slot.ordinal = ordinal;
                    slot
                } else {
                    ParameterSlot {
                        ordinal,
                        name: name.clone(),
                        flow: closure_flow(name, origin),
                    }
                }
            })
            .collect();
        candidate.component.effective_captures = required.keys().cloned().collect();
    }
    Ok(())
}

fn candidates<'a>(
    owner: &Declaration<Linked>,
    groups: &'a [LocalGroup],
    components: &'a [ParametricComponent],
    selected: &[usize],
) -> Result<Vec<Candidate<'a>>, BatchBlocker> {
    if selected.is_empty() {
        return Err(BatchBlocker::EmptySelection);
    }
    let by_component = components
        .iter()
        .filter(|component| component.owner == owner.id)
        .map(|component| (component.component, component))
        .collect::<BTreeMap<_, _>>();
    let mut explicit = BTreeSet::new();
    for component_id in selected {
        if !explicit.insert(*component_id) {
            return Err(BatchBlocker::DuplicateComponent(*component_id));
        }
        let component = by_component
            .get(component_id)
            .ok_or(BatchBlocker::ComponentNotFound(*component_id))?;
        if !component.eligible() {
            return Err(BatchBlocker::ComponentBlocked(*component_id));
        }
    }
    let mut expanded = selected.to_vec();
    let mut included = explicit;
    let mut cursor = 0usize;
    while cursor < expanded.len() {
        let component_id = expanded[cursor];
        let component = by_component
            .get(&component_id)
            .ok_or(BatchBlocker::ComponentNotFound(component_id))?;
        for dependency in &component.dependencies {
            let dependency_component = by_component
                .get(dependency)
                .ok_or(BatchBlocker::ComponentNotFound(*dependency))?;
            if dependency_component.eligible() && included.insert(*dependency) {
                expanded.push(*dependency);
            }
        }
        cursor += 1;
    }
    let selected_names = expanded
        .iter()
        .filter_map(|component_id| by_component.get(component_id))
        .flat_map(|component| component.names.iter().cloned())
        .collect::<BTreeSet<_>>();
    let mut seen = BTreeSet::new();
    let mut result = Vec::new();
    for component_id in &expanded {
        if !seen.insert(*component_id) {
            return Err(BatchBlocker::DuplicateComponent(*component_id));
        }
        let mut component = by_component
            .get(component_id)
            .map(|component| (*component).clone())
            .ok_or(BatchBlocker::ComponentNotFound(*component_id))?;
        if component.owner != owner.id {
            return Err(BatchBlocker::OwnerMismatch(*component_id));
        }
        if !component.eligible() {
            return Err(BatchBlocker::ComponentBlocked(*component_id));
        }
        component
            .parameters
            .retain(|slot| !selected_names.contains(&slot.name));
        component
            .direct_captures
            .retain(|name| !selected_names.contains(name));
        component
            .effective_captures
            .retain(|name| !selected_names.contains(name));
        let group_index = match component.members.as_slice() {
            [group_index] => *group_index,
            _ => return Err(BatchBlocker::MultiGroupComponent(*component_id)),
        };
        let group = groups
            .get(group_index)
            .ok_or(BatchBlocker::GroupNotFound(group_index))?;
        if group.owner != owner.id {
            return Err(BatchBlocker::OwnerMismatch(*component_id));
        }
        result.push(Candidate {
            component,
            group_index,
            group,
        });
    }
    close_candidate_parameters(&mut result)?;
    result.sort_by_key(|candidate| candidate.group.start_line);
    for pair in result.windows(2) {
        if pair[0].group.end_line > pair[1].group.start_line {
            return Err(BatchBlocker::OverlappingGroups {
                first: pair[0].group_index,
                second: pair[1].group_index,
            });
        }
    }
    Ok(result)
}

#[must_use]
fn adjusted_group(group: &LocalGroup, removed_lines: usize) -> Option<LocalGroup> {
    let mut adjusted = group.clone();
    adjusted.start_line = adjusted.start_line.checked_sub(removed_lines)?;
    adjusted.end_line = adjusted.end_line.checked_sub(removed_lines)?;
    Some(adjusted)
}

pub fn preflight_detached_call_uses(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    components: &[ParametricComponent],
    selected: &[usize],
) -> Result<BTreeSet<usize>, BatchBlocker> {
    let ordered = candidates(owner, groups, components, selected)?;
    let mut rejected = BTreeSet::new();
    for candidate in ordered {
        if candidate.component.recursive || candidate.group.names.len() != 1 {
            continue;
        }
        let original = candidate
            .group
            .names
            .iter()
            .next()
            .expect("single-name detached candidate");
        match rewrite_call_sites(&owner.text, original, original, &[]) {
            Ok(_) => {}
            Err(RewriteBlocker::NonCallUse(_) | RewriteBlocker::QualifiedUse(_)) => {
                rejected.insert(candidate.component.component);
            }
            Err(blocker) => {
                return Err(BatchBlocker::Rewrite {
                    component: candidate.component.component,
                    blocker,
                });
            }
        }
    }
    Ok(rejected)
}

pub fn rewrite_owner_batch(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    components: &[ParametricComponent],
    selected: &[usize],
) -> Result<BatchRewriteArtifact<BatchApplied>, BatchBlocker> {
    let ordered = candidates(owner, groups, components, selected)?;
    let stabilized = stabilize_generated_capture_headers(&owner.text);
    let mut current = owner.clone();
    current.text = stabilized.text;
    current.fingerprint = fnv1a64(current.text.as_bytes());
    let mut removed_lines = 0usize;
    let mut hoisted = Vec::<(usize, String)>::new();
    let mut edits = Vec::new();
    let mut receipts = Vec::new();
    let mut rewritten_calls = 0usize;
    let mut parameters = BTreeSet::new();
    let mut component_ids = Vec::new();

    for candidate in ordered {
        let adjusted = adjusted_group(candidate.group, removed_lines).ok_or(
            BatchBlocker::InvalidAdjustedSpan(candidate.component.component),
        )?;
        let detached_call = !candidate.component.recursive && candidate.group.names.len() == 1;
        let call_requirement = if detached_call {
            CallRequirement::Optional
        } else {
            CallRequirement::Required
        };
        let artifact = rewrite_bounded_owner_with_requirement(
            &current,
            candidate.group_index,
            &adjusted,
            &candidate.component,
            call_requirement,
        )
        .map_err(|blocker| BatchBlocker::Rewrite {
            component: candidate.component.component,
            blocker,
        })?;
        let lexical_probe =
            probe_symbol_states(&artifact.owner_text, "").map_err(|_| BatchBlocker::Rewrite {
                component: candidate.component.component,
                blocker: RewriteBlocker::TripleQuotedString,
            })?;
        if !matches!(
            lexical_probe.final_state,
            LexicalState::Code | LexicalState::LineComment
        ) {
            return Err(BatchBlocker::LexicalImbalance {
                component: candidate.component.component,
                state: lexical_probe.final_state,
                entry_line: lexical_probe.final_state_entry_line,
            });
        }
        let mut prior_hoisted_calls = 0usize;
        let mut detached_unused = false;
        if detached_call {
            let original = candidate
                .group
                .names
                .iter()
                .next()
                .expect("single-name detached candidate");
            for (_, text) in &mut hoisted {
                let (rewritten, calls) =
                    rewrite_call_sites(text, original, &artifact.lifted_name, &artifact.parameters)
                        .map_err(|blocker| BatchBlocker::Rewrite {
                            component: candidate.component.component,
                            blocker,
                        })?;
                *text = rewritten;
                prior_hoisted_calls += calls;
            }
            if artifact.rewritten_calls + prior_hoisted_calls == 0 {
                let owner_mentions = artifact.owner_text.matches(original).count();
                let hoisted_mentions = hoisted
                    .iter()
                    .map(|(_, text)| text.matches(original).count())
                    .sum();
                let owner_line_calls = artifact
                    .owner_text
                    .lines()
                    .map(|line| {
                        rewrite_call_sites(
                            line,
                            original,
                            &artifact.lifted_name,
                            &artifact.parameters,
                        )
                        .map_or(0, |(_, calls)| calls)
                    })
                    .sum();
                let owner_probe =
                    probe_symbol_states(&artifact.owner_text, original).map_err(|_| {
                        BatchBlocker::Rewrite {
                            component: candidate.component.component,
                            blocker: RewriteBlocker::TripleQuotedString,
                        }
                    })?;
                let ownership = certify_detached_call(DetachedCallEvidence {
                    rewritten_calls: artifact.rewritten_calls,
                    prior_hoisted_calls,
                    owner_mentions,
                    hoisted_mentions,
                    owner_line_calls,
                    owner_code_mentions: owner_probe.code,
                });
                if ownership.is_unused_binding() {
                    detached_unused = true;
                } else {
                    let owner_entry_line_text = if owner_probe.final_state == LexicalState::Code {
                        String::new()
                    } else {
                        artifact
                            .owner_text
                            .lines()
                            .nth(owner_probe.final_state_entry_line.saturating_sub(1))
                            .unwrap_or_default()
                            .trim()
                            .to_owned()
                    };
                    let owner_first_string_newline_text =
                        if owner_probe.first_string_newline_line == 0 {
                            String::new()
                        } else {
                            artifact
                                .owner_text
                                .lines()
                                .nth(owner_probe.first_string_newline_line.saturating_sub(1))
                                .unwrap_or_default()
                                .trim()
                                .to_owned()
                        };
                    let owner_symbol_state_entry_text =
                        if owner_probe.first_symbol_state_entry_line == 0 {
                            String::new()
                        } else {
                            artifact
                                .owner_text
                                .lines()
                                .nth(owner_probe.first_symbol_state_entry_line.saturating_sub(1))
                                .unwrap_or_default()
                                .trim()
                                .to_owned()
                        };
                    let owner_symbol_state_prev_line_text =
                        if owner_probe.first_symbol_second_prior_state_entry_line == 0 {
                            String::new()
                        } else {
                            artifact
                                .owner_text
                                .lines()
                                .nth(
                                    owner_probe
                                        .first_symbol_second_prior_state_entry_line
                                        .saturating_sub(1),
                                )
                                .unwrap_or_default()
                                .trim()
                                .to_owned()
                        };
                    return Err(BatchBlocker::DetachedCallUnowned(Box::new(
                        DetachedCallDiagnostic {
                            component: candidate.component.component,
                            symbol: original.clone(),
                            owner_mentions,
                            hoisted_mentions,
                            owner_line_calls,
                            owner_probe,
                            owner_entry_line_text,
                            owner_first_string_newline_text,
                            owner_symbol_state_entry_text,
                            owner_symbol_state_prev_line_text,
                        },
                    )));
                }
            }
        }
        let component_rewritten_calls = artifact.rewritten_calls + prior_hoisted_calls;
        component_ids.push(candidate.component.component);
        parameters.extend(artifact.parameters.iter().cloned());
        rewritten_calls += component_rewritten_calls;
        edits.extend(artifact.edits.clone());
        hoisted.push((candidate.group.start_line, artifact.hoisted_text.clone()));
        receipts.push(BatchComponentReceipt {
            component: candidate.component.component,
            group: candidate.group_index,
            start_line: candidate.group.start_line,
            end_line: candidate.group.end_line,
            removed_lines: candidate.group.line_count,
            rewritten_calls: component_rewritten_calls,
            detached_unused,
            parameters: artifact.parameters.clone(),
            lifted_names: artifact.lifted_name.clone(),
        });
        current.text = artifact.owner_text;
        current.fingerprint = fnv1a64(current.text.as_bytes());
        current.span.end = current.span.start + current.text.lines().count();
        removed_lines += candidate.group.line_count;
    }

    hoisted.sort_by_key(|(start_line, _)| *start_line);
    let separator = format!("{}{}", char::from(10), char::from(10));
    let hoisted_text = hoisted
        .into_iter()
        .map(|(_, text)| text)
        .collect::<Vec<_>>()
        .join(&separator);
    let trailing = owner.text.as_bytes().last() == Some(&10);
    let mut full_text = format!("{hoisted_text}{separator}{}", current.text);
    if trailing {
        full_text.push(char::from(10));
    }
    let output_fingerprint = fnv1a64(full_text.as_bytes());
    Ok(BatchRewriteArtifact {
        owner: owner.id,
        components: component_ids,
        original_fingerprint: owner.fingerprint,
        output_fingerprint,
        hoisted_text,
        owner_text: current.text,
        full_text,
        rewritten_calls,
        parameters: parameters.into_iter().collect(),
        edits,
        receipts,
        stage: PhantomData,
    })
}

fn leading_spaces(line: &str) -> usize {
    line.as_bytes()
        .iter()
        .take_while(|byte| **byte == b' ')
        .count()
}

pub fn splice_batch_owner(
    source: &str,
    owner: &Declaration<Linked>,
    artifact: &BatchRewriteArtifact<BatchApplied>,
) -> Result<String, BatchBlocker> {
    if owner.id != artifact.owner {
        return Err(BatchBlocker::OwnerMismatch(usize::MAX));
    }
    let lines = source.lines().collect::<Vec<_>>();
    let (start, end) = if owner.span.start == 0 {
        (0, owner.span.end)
    } else {
        (owner.span.start - 1, owner.span.end.saturating_sub(1))
    };
    if start >= end || end > lines.len() {
        return Err(BatchBlocker::InvalidAdjustedSpan(usize::MAX));
    }
    let original_indent = lines[start..end]
        .iter()
        .find(|line| !line.trim().is_empty())
        .map_or(0, |line| leading_spaces(line));
    let align = |block: &str| -> Result<Vec<String>, BatchBlocker> {
        let block_indent = block
            .lines()
            .find(|line| !line.trim().is_empty())
            .map_or(0, leading_spaces);
        if block_indent > original_indent {
            return Err(BatchBlocker::InvalidAdjustedSpan(usize::MAX));
        }
        let padding = " ".repeat(original_indent - block_indent);
        Ok(block
            .lines()
            .map(|line| {
                if line.is_empty() {
                    String::new()
                } else {
                    format!("{padding}{line}")
                }
            })
            .collect())
    };
    let owner_continues_group = lines
        .get(start)
        .is_some_and(|line| line.trim_start().starts_with("and "));
    let insert_at = if owner_continues_group {
        outer_recursive_group_head(&lines, start, original_indent).ok_or(BatchBlocker::Rewrite {
            component: usize::MAX,
            blocker: RewriteBlocker::UnsupportedHeader,
        })?
    } else {
        start
    };
    let mut output = Vec::<String>::new();
    output.extend(lines[..insert_at].iter().map(|line| (*line).to_owned()));
    output.extend(align(&artifact.hoisted_text)?);
    output.push(String::new());
    output.extend(
        lines[insert_at..start]
            .iter()
            .map(|line| (*line).to_owned()),
    );
    output.extend(align(&artifact.owner_text)?);
    output.extend(lines[end..].iter().map(|line| (*line).to_owned()));
    let mut text = output.join(&char::from(10).to_string());
    if source.ends_with(char::from(10)) {
        text.push(char::from(10));
    }
    Ok(text)
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_lift::{LiftDisposition, LocalGroup};
    use spiral_split_lift_plan::{CaptureFlow, ParameterSlot};
    use spiral_split_model::{
        BoundaryReason, Declaration, DeclarationKind, LineSpan, Raw, fnv1a64,
    };

    fn set(values: &[&str]) -> BTreeSet<String> {
        values.iter().map(|value| (*value).to_owned()).collect()
    }

    fn owner(text: &str) -> Declaration<Linked> {
        Declaration::<Raw>::new(
            DeclarationId(0),
            LineSpan {
                start: 0,
                end: text.lines().count(),
            },
            "let outer env value =".to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
        .restage()
    }

    fn group(index: usize, start: usize, name: &str, captures: &[&str]) -> LocalGroup {
        LocalGroup {
            owner: DeclarationId(0),
            owner_heading: "outer".to_owned(),
            local_index: index,
            start_line: start,
            end_line: start + 1,
            line_count: 1,
            names: set(&[name]),
            parameters: set(&["x"]),
            references: set(captures),
            captures: set(captures),
            local_dependencies: BTreeSet::new(),
            disposition: if captures.is_empty() {
                LiftDisposition::Liftable
            } else {
                LiftDisposition::Captures(set(captures))
            },
        }
    }

    fn component(id: usize, group: usize, name: &str, parameters: &[&str]) -> ParametricComponent {
        let effective = set(parameters);
        ParametricComponent {
            owner: DeclarationId(0),
            component: id,
            members: vec![group],
            names: set(&[name]),
            dependencies: BTreeSet::new(),
            line_count: 1,
            start_line: group + 1,
            end_line: group + 2,
            direct_captures: effective.clone(),
            effective_captures: effective,
            parameters: parameters
                .iter()
                .enumerate()
                .map(|(ordinal, name)| ParameterSlot {
                    ordinal,
                    name: (*name).to_owned(),
                    flow: CaptureFlow::Direct {
                        parameter: (*name).to_owned(),
                    },
                })
                .collect(),
            recursive: false,
            blocker: None,
            intents: Vec::new(),
        }
    }

    #[test]
    fn rewrites_two_groups_in_source_order() {
        let source = r#"let outer env value =
    let add x = env + x
    let double x = add x * 2
    double value
"#;
        let groups = vec![
            group(0, 1, "add", &["env"]),
            group(1, 2, "double", &["env"]),
        ];
        let components = vec![
            component(0, 0, "add", &["env"]),
            component(1, 1, "double", &["add", "env"]),
        ];
        let artifact = rewrite_owner_batch(&owner(source), &groups, &components, &[1, 0])
            .expect("batch rewrite");
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_lift_0_0_add env x =")
        );
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_lift_0_1_double env x =")
        );
        assert!(
            artifact
                .hoisted_text
                .contains("(__spiral_lift_0_0_add env) x * 2")
        );
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_1_double env) value")
        );
        assert_eq!(artifact.components, vec![0, 1]);
        assert_eq!(artifact.rewritten_calls, 2);
    }

    #[test]
    fn selected_component_closes_eligible_local_dependencies() {
        let source = r#"let outer env value =
    let add x = env + x
    let double x = add x * 2
    double value
"#;
        let groups = vec![
            group(0, 1, "add", &["env"]),
            group(1, 2, "double", &["add", "env"]),
        ];
        let mut components = vec![
            component(0, 0, "add", &["env"]),
            component(1, 1, "double", &["add", "env"]),
        ];
        components[1].dependencies.insert(0);
        let artifact = rewrite_owner_batch(&owner(source), &groups, &components, &[1])
            .expect("dependency-closed batch rewrite");
        assert_eq!(artifact.components, vec![0, 1]);
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_lift_0_0_add env x =")
        );
        assert!(
            artifact
                .hoisted_text
                .contains("let __spiral_lift_0_1_double env x = (__spiral_lift_0_0_add env) x * 2")
        );
    }

    #[test]
    fn rewrites_forward_dependency_from_already_hoisted_binding() {
        let source = r#"let outer env value =
    let rec first x = second x
    and second x = env + x
    first value
"#;
        let groups = vec![
            group(0, 1, "first", &["second"]),
            group(1, 2, "second", &["env"]),
        ];
        let components = vec![
            component(0, 0, "first", &["second"]),
            component(1, 1, "second", &["env"]),
        ];
        let artifact = rewrite_owner_batch(&owner(source), &groups, &components, &[0, 1])
            .expect("forward dependency rewrite");
        assert!(
            artifact.hoisted_text.contains(
                "let rec __spiral_lift_0_0_first env x = (__spiral_lift_0_1_second env) x"
            )
        );
        assert!(
            artifact
                .hoisted_text
                .contains("and __spiral_lift_0_1_second env x = env + x")
        );
        assert!(
            artifact
                .owner_text
                .contains("(__spiral_lift_0_0_first env) value")
        );
    }

    #[test]
    fn duplicate_component_is_rejected() {
        let source = r#"let outer env value =
    let add x = env + x
    add value
"#;
        let groups = vec![group(0, 1, "add", &["env"])];
        let components = vec![component(0, 0, "add", &["env"])];
        let error = rewrite_owner_batch(&owner(source), &groups, &components, &[0, 0])
            .expect_err("duplicate must fail");
        assert_eq!(error, BatchBlocker::DuplicateComponent(0));
    }

    #[test]
    fn detached_function_without_consumer_is_certified_unused() {
        let source = r#"let outer env value =
    let add x = env + x
    value
"#;
        let groups = vec![group(0, 1, "add", &["env"])];
        let components = vec![component(0, 0, "add", &["env"])];
        let artifact = rewrite_owner_batch(&owner(source), &groups, &components, &[0])
            .expect("unused function binding may be hoisted");
        assert_eq!(artifact.components, vec![0]);
        assert_eq!(artifact.rewritten_calls, 0);
        assert!(artifact.receipts[0].detached_unused);
        assert!(artifact.hoisted_text.contains("__spiral_lift_0_0_add env"));
        assert!(!artifact.owner_text.contains("let add"));
    }

    #[test]
    fn overlapping_groups_are_rejected() {
        let source = r#"let outer env value =
    let add x = env + x
    let double x = add x * 2
    double value
"#;
        let first = group(0, 1, "add", &["env"]);
        let mut second = group(1, 1, "double", &["env"]);
        second.end_line = 3;
        second.line_count = 2;
        let groups = vec![first, second];
        let components = vec![
            component(0, 0, "add", &["env"]),
            component(1, 1, "double", &["add", "env"]),
        ];
        let error = rewrite_owner_batch(&owner(source), &groups, &components, &[0, 1])
            .expect_err("overlap must fail");
        assert_eq!(
            error,
            BatchBlocker::OverlappingGroups {
                first: 0,
                second: 1,
            }
        );
    }

    #[test]
    fn batch_splice_moves_hoist_before_outer_recursive_head() {
        let source = "let rec head x =\n    member x\nand member x =\n    x\n";
        let owner = Declaration::<Raw>::new(
            DeclarationId(0),
            LineSpan { start: 3, end: 5 },
            "and member x =".to_owned(),
            "and member x =\n    x".to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            0,
        )
        .restage();
        let artifact = BatchRewriteArtifact {
            owner: DeclarationId(0),
            components: vec![0],
            original_fingerprint: 0,
            output_fingerprint: 0,
            hoisted_text: "let helper x = x".to_owned(),
            owner_text: "and member x =\n    x".to_owned(),
            full_text: String::new(),
            rewritten_calls: 0,
            parameters: Vec::new(),
            edits: Vec::new(),
            receipts: Vec::new(),
            stage: PhantomData,
        };
        let rewritten = splice_batch_owner(source, &owner, &artifact).expect("splice");
        assert_eq!(
            rewritten,
            "let helper x = x\n\nlet rec head x =\n    member x\nand member x =\n    x\n"
        );
    }
}
