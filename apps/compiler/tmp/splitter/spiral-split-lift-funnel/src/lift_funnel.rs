use spiral_split_deferred_ambient::{
    identify_deferred_ambient, suppress_deferred_ambient_captures,
};
use spiral_split_fsharp_lex::{
    LexicalBlocker, LexicalState, SymbolLexicalProbe, line_start_states, probe_symbol_states,
};
use spiral_split_funnel_rollback::{DependencyNode, RollbackSelection, exclude_with_dependents};
use spiral_split_lift::{
    LiftDisposition, LocalComponent, LocalGroup, OwnerForecast, analyze_owner_lifts,
};
use spiral_split_lift_batch::{
    BatchApplied, BatchBlocker, BatchRewriteArtifact, preflight_detached_call_uses,
    rewrite_owner_batch, splice_batch_owner,
};
use spiral_split_lift_plan::{ParametricComponent, plan_parametric_parts};
use spiral_split_model::{
    BoundaryReason, Declaration, DeclarationId, DeclarationKind, LineSpan, Linked, Raw, fnv1a64,
};
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Applied;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum FunnelBlocker {
    OwnerMismatch,
    InvalidParentSpan,
    NoNestedBindings,
    NoTerminalMatchPartition,
    EmptyNestedSelection,
    EmptyPromotionSelection,
    MissingGeneratedBinding(String),
    Lexical(LexicalBlocker),
    Batch(BatchBlocker),
}

impl Display for FunnelBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::OwnerMismatch => formatter.write_str("owner-mismatch"),
            Self::InvalidParentSpan => formatter.write_str("invalid-parent-span"),
            Self::NoNestedBindings => formatter.write_str("no-nested-bindings"),
            Self::NoTerminalMatchPartition => formatter.write_str("no-terminal-match-partition"),
            Self::EmptyNestedSelection => formatter.write_str("empty-nested-selection"),
            Self::EmptyPromotionSelection => formatter.write_str("empty-promotion-selection"),
            Self::MissingGeneratedBinding(name) => {
                write!(formatter, "missing-generated-binding:{name}")
            }
            Self::Lexical(blocker) => write!(formatter, "lexical:{blocker}"),
            Self::Batch(blocker) => write!(formatter, "batch:{blocker}"),
        }
    }
}

impl From<BatchBlocker> for FunnelBlocker {
    fn from(value: BatchBlocker) -> Self {
        Self::Batch(value)
    }
}

impl From<LexicalBlocker> for FunnelBlocker {
    fn from(value: LexicalBlocker) -> Self {
        Self::Lexical(value)
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum SelectionReason {
    SizeTarget {
        component: usize,
        lines: usize,
    },
    Dependency {
        component: usize,
        required_by: usize,
        tail: Box<SelectionReason>,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct SelectionReceipt {
    pub component: usize,
    pub lines: usize,
    pub reason: SelectionReason,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct FunnelArtifact<S> {
    pub owner: DeclarationId,
    pub original_fingerprint: u64,
    pub parent_local_index: usize,
    pub parent_lines_before: usize,
    pub parent_lines_after: usize,
    pub owner_lines_before: usize,
    pub owner_lines_after: usize,
    pub nested_selected: Vec<usize>,
    pub promoted_selected: Vec<usize>,
    pub generated_names: BTreeSet<String>,
    pub nested_receipts: Vec<SelectionReceipt>,
    pub promoted_receipts: Vec<SelectionReceipt>,
    pub rewritten_calls: usize,
    pub final_source: String,
    pub nested_batch: BatchRewriteArtifact<BatchApplied>,
    pub promoted_batch: BatchRewriteArtifact<BatchApplied>,
    stage: PhantomData<fn() -> S>,
}

impl FunnelArtifact<Applied> {
    #[must_use]
    pub fn render_receipt(&self) -> String {
        let mut output = String::new();
        let _ = writeln!(
            output,
            "owner parent_local parent_before parent_after owner_before owner_after nested_components promoted_components generated_names rewritten_calls"
        );
        let _ = writeln!(
            output,
            "{} {} {} {} {} {} {} {} {} {}",
            self.owner.0,
            self.parent_local_index,
            self.parent_lines_before,
            self.parent_lines_after,
            self.owner_lines_before,
            self.owner_lines_after,
            join_usize(&self.nested_selected),
            join_usize(&self.promoted_selected),
            self.generated_names
                .iter()
                .cloned()
                .collect::<Vec<_>>()
                .join(","),
            self.rewritten_calls,
        );
        output.push_str(
            "stage component lines reason
",
        );
        for receipt in &self.nested_receipts {
            let _ = writeln!(
                output,
                "nested {} {} {}",
                receipt.component,
                receipt.lines,
                render_reason(&receipt.reason)
            );
        }
        for receipt in &self.promoted_receipts {
            let _ = writeln!(
                output,
                "promoted {} {} {}",
                receipt.component,
                receipt.lines,
                render_reason(&receipt.reason)
            );
        }
        output
    }
}

fn join_usize(values: &[usize]) -> String {
    values
        .iter()
        .map(usize::to_string)
        .collect::<Vec<_>>()
        .join(",")
}

fn render_reason(reason: &SelectionReason) -> String {
    match reason {
        SelectionReason::SizeTarget { component, lines } => {
            format!("size-target:{component}:{lines}")
        }
        SelectionReason::Dependency {
            component,
            required_by,
            tail,
        } => format!(
            "dependency:{component}:required-by:{required_by}>{}",
            render_reason(tail)
        ),
    }
}

fn owner_forecast(
    declaration: &Declaration<Linked>,
    groups: &[LocalGroup],
    components: &[LocalComponent],
) -> OwnerForecast {
    let liftable_lines = components
        .iter()
        .filter(|component| component.liftable)
        .map(|component| component.line_count)
        .sum::<usize>();
    OwnerForecast {
        owner: declaration.id,
        heading: declaration.heading.clone(),
        lines_before: declaration.line_count(),
        liftable_lines,
        lines_after: declaration.line_count().saturating_sub(liftable_lines),
        local_groups: groups.len(),
        liftable_groups: groups
            .iter()
            .filter(|group| matches!(group.disposition, LiftDisposition::Liftable))
            .count(),
    }
}

fn plan_owner(declaration: &Declaration<Linked>) -> (Vec<LocalGroup>, Vec<ParametricComponent>) {
    let (groups, components) = analyze_owner_lifts(declaration);
    let forecast = owner_forecast(declaration, &groups, &components);
    let plan = plan_parametric_parts(&groups, &components, &[forecast]);
    (groups, plan.components)
}

fn synthetic_id(owner: DeclarationId, parent: &LocalGroup) -> DeclarationId {
    DeclarationId(
        owner
            .0
            .saturating_mul(1_000_003)
            .saturating_add(parent.start_line),
    )
}

fn extract_parent(
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
) -> Result<Declaration<Linked>, FunnelBlocker> {
    if owner.id != parent.owner {
        return Err(FunnelBlocker::OwnerMismatch);
    }
    let start = parent
        .start_line
        .checked_sub(owner.span.start)
        .ok_or(FunnelBlocker::InvalidParentSpan)?;
    let end = parent
        .end_line
        .checked_sub(owner.span.start)
        .ok_or(FunnelBlocker::InvalidParentSpan)?;
    let lines = owner.text.lines().collect::<Vec<_>>();
    if start >= end || end > lines.len() {
        return Err(FunnelBlocker::InvalidParentSpan);
    }
    let text = lines[start..end].join(
        "
",
    );
    let heading = parent
        .names
        .iter()
        .next()
        .cloned()
        .unwrap_or_else(|| owner.heading.clone());
    Ok(Declaration::<Raw>::new(
        synthetic_id(owner.id, parent),
        LineSpan {
            start: 0,
            end: text.lines().count(),
        },
        heading,
        text.clone(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        owner.ambient_opens.clone(),
        fnv1a64(text.as_bytes()),
    )
    .restage())
}

fn replace_parent(
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    replacement: &str,
) -> Result<Declaration<Linked>, FunnelBlocker> {
    let start = parent
        .start_line
        .checked_sub(owner.span.start)
        .ok_or(FunnelBlocker::InvalidParentSpan)?;
    let end = parent
        .end_line
        .checked_sub(owner.span.start)
        .ok_or(FunnelBlocker::InvalidParentSpan)?;
    let mut lines = owner.text.lines().map(str::to_owned).collect::<Vec<_>>();
    if start >= end || end > lines.len() {
        return Err(FunnelBlocker::InvalidParentSpan);
    }
    lines.splice(start..end, replacement.lines().map(str::to_owned));
    let trailing = owner.text.ends_with(char::from(10));
    let mut text = lines.join(&char::from(10).to_string());
    if trailing {
        text.push(char::from(10));
    }
    let mut updated = owner.clone();
    updated.text = text;
    updated.fingerprint = fnv1a64(updated.text.as_bytes());
    updated.span.end = updated.span.start + updated.text.lines().count();
    Ok(updated)
}

fn component_map(components: &[ParametricComponent]) -> BTreeMap<usize, &ParametricComponent> {
    components
        .iter()
        .map(|component| (component.component, component))
        .collect()
}

fn admissible(component: &ParametricComponent) -> bool {
    component.eligible() && component.members.len() == 1
}

fn add_closure(
    component: usize,
    required_by: usize,
    map: &BTreeMap<usize, &ParametricComponent>,
    selected: &mut BTreeSet<usize>,
    reasons: &mut BTreeMap<usize, SelectionReason>,
    visiting: &mut BTreeSet<usize>,
    root: &SelectionReason,
) -> bool {
    if selected.contains(&component) {
        return true;
    }
    let Some(value) = map.get(&component).copied() else {
        return false;
    };
    if !admissible(value) || !visiting.insert(component) {
        return false;
    }
    for dependency in &value.dependencies {
        let reason = SelectionReason::Dependency {
            component: *dependency,
            required_by: component,
            tail: Box::new(root.clone()),
        };
        if !add_closure(
            *dependency,
            component,
            map,
            selected,
            reasons,
            visiting,
            &reason,
        ) {
            visiting.remove(&component);
            return false;
        }
    }
    visiting.remove(&component);
    selected.insert(component);
    reasons.entry(component).or_insert_with(|| {
        if component == required_by {
            root.clone()
        } else {
            SelectionReason::Dependency {
                component,
                required_by,
                tail: Box::new(root.clone()),
            }
        }
    });
    true
}

fn select_for_target(
    components: &[ParametricComponent],
    before_lines: usize,
    max_lines: usize,
) -> (Vec<usize>, Vec<SelectionReceipt>) {
    let map = component_map(components);
    let mut candidates = components
        .iter()
        .filter(|component| admissible(component))
        .collect::<Vec<_>>();
    candidates.sort_by_key(|component| (usize::MAX - component.line_count, component.component));
    let mut selected = BTreeSet::new();
    let mut reasons = BTreeMap::new();
    for candidate in components.iter().filter(|component| {
        admissible(component)
            && component
                .names
                .iter()
                .any(|name| name.starts_with("__spiral_match_"))
    }) {
        let root = SelectionReason::SizeTarget {
            component: candidate.component,
            lines: candidate.line_count,
        };
        let _ = add_closure(
            candidate.component,
            candidate.component,
            &map,
            &mut selected,
            &mut reasons,
            &mut BTreeSet::new(),
            &root,
        );
    }
    for candidate in candidates {
        let removed = selected
            .iter()
            .filter_map(|component| map.get(component))
            .map(|component| component.line_count)
            .sum::<usize>();
        if before_lines.saturating_sub(removed) <= max_lines {
            break;
        }
        let root = SelectionReason::SizeTarget {
            component: candidate.component,
            lines: candidate.line_count,
        };
        let mut trial = selected.clone();
        let mut trial_reasons = reasons.clone();
        if add_closure(
            candidate.component,
            candidate.component,
            &map,
            &mut trial,
            &mut trial_reasons,
            &mut BTreeSet::new(),
            &root,
        ) {
            selected = trial;
            reasons = trial_reasons;
        }
    }
    let ids = selected.into_iter().collect::<Vec<_>>();
    let receipts = ids
        .iter()
        .filter_map(|component| {
            Some(SelectionReceipt {
                component: *component,
                lines: map.get(component)?.line_count,
                reason: reasons.get(component)?.clone(),
            })
        })
        .collect();
    (ids, receipts)
}

fn select_named_closure(
    components: &[ParametricComponent],
    names: &BTreeSet<String>,
) -> (Vec<usize>, Vec<SelectionReceipt>) {
    let map = component_map(components);
    let mut selected = BTreeSet::new();
    let mut reasons = BTreeMap::new();
    let mut targets = components
        .iter()
        .filter(|component| {
            admissible(component) && component.names.iter().any(|name| names.contains(name))
        })
        .collect::<Vec<_>>();
    targets.sort_by_key(|component| component.component);
    for target in targets {
        let root = SelectionReason::SizeTarget {
            component: target.component,
            lines: target.line_count,
        };
        let mut trial = selected.clone();
        let mut trial_reasons = reasons.clone();
        if add_closure(
            target.component,
            target.component,
            &map,
            &mut trial,
            &mut trial_reasons,
            &mut BTreeSet::new(),
            &root,
        ) {
            selected = trial;
            reasons = trial_reasons;
        }
    }
    let ids = selected.into_iter().collect::<Vec<_>>();
    let receipts = ids
        .iter()
        .filter_map(|component| {
            Some(SelectionReceipt {
                component: *component,
                lines: map.get(component)?.line_count,
                reason: reasons.get(component)?.clone(),
            })
        })
        .collect();
    (ids, receipts)
}

fn generated_names(batch: &BatchRewriteArtifact<BatchApplied>) -> BTreeSet<String> {
    batch
        .receipts
        .iter()
        .flat_map(|receipt| receipt.lifted_names.split(','))
        .map(str::trim)
        .filter(|name| !name.is_empty())
        .map(str::to_owned)
        .collect()
}

fn leading_width(line: &str) -> usize {
    line.len().saturating_sub(line.trim_start().len())
}

fn case_starts(
    lines: &[String],
    line_states: &[LexicalState],
    match_index: usize,
    end: usize,
    indent: usize,
) -> Vec<usize> {
    let mut starts = Vec::new();
    let mut has_arrow = false;
    for (index, line) in lines.iter().enumerate().take(end).skip(match_index + 1) {
        let trimmed = line.trim_start();
        if line_states.get(index) == Some(&LexicalState::Code)
            && leading_width(line) == indent
            && trimmed.starts_with('|')
            && (starts.is_empty() || has_arrow)
        {
            starts.push(index);
            has_arrow = false;
        }
        if !starts.is_empty()
            && line_states.get(index) == Some(&LexicalState::Code)
            && line.contains("->")
        {
            has_arrow = true;
        }
    }
    starts
}

fn match_end(
    lines: &[String],
    line_states: &[LexicalState],
    match_index: usize,
    indent: usize,
) -> usize {
    lines
        .iter()
        .enumerate()
        .skip(match_index + 1)
        .find_map(|(index, line)| {
            let trimmed = line.trim();
            (!trimmed.is_empty()
                && line_states.get(index) == Some(&LexicalState::Code)
                && leading_width(line) <= indent
                && !line.trim_start().starts_with('|'))
            .then_some(index)
        })
        .unwrap_or(lines.len())
}

fn partition_terminal_match(
    declaration: &Declaration<Linked>,
    max_lines: usize,
) -> Option<Declaration<Linked>> {
    let mut lines = declaration
        .text
        .lines()
        .map(str::to_owned)
        .collect::<Vec<_>>();
    let line_states = line_start_states(&declaration.text).ok()?;
    let candidate = lines
        .iter()
        .enumerate()
        .filter(|(_, line)| {
            let trimmed = line.trim();
            trimmed.starts_with("match ") && trimmed.ends_with(" with")
        })
        .filter_map(|(match_index, line)| {
            let indent = leading_width(line);
            let end = match_end(&lines, &line_states, match_index, indent);
            let starts = case_starts(&lines, &line_states, match_index, end, indent);
            (starts.len() > 1).then_some((end - match_index, match_index, end, indent, starts))
        })
        .max_by_key(|candidate| candidate.0)?;
    let (_, match_index, end, indent, starts) = candidate;
    if end.saturating_sub(match_index) <= max_lines {
        return None;
    }
    let budget = max_lines.saturating_sub(12).max(64);
    let mut chunks = Vec::new();
    let mut chunk_start = starts[0];
    let mut chunk_lines = 0usize;
    for (position, start) in starts.iter().copied().enumerate() {
        let case_end = starts.get(position + 1).copied().unwrap_or(end);
        let case_lines = case_end.saturating_sub(start);
        if chunk_lines > 0 && chunk_lines + case_lines > budget {
            chunks.push((chunk_start, start));
            chunk_start = start;
            chunk_lines = 0;
        }
        chunk_lines += case_lines;
    }
    chunks.push((chunk_start, end));
    if chunks.len() < 2 {
        return None;
    }
    let prefix = " ".repeat(indent);
    let match_expression = lines[match_index].trim_start().to_owned();
    let names = (0..chunks.len())
        .map(|index| format!("__spiral_match_{}_{}", declaration.id.0, index))
        .collect::<Vec<_>>();
    let mut replacement = Vec::new();
    for index in (0..chunks.len()).rev() {
        let (start, chunk_end) = chunks[index];
        replacement.push(format!("{prefix}let {} () =", names[index]));
        replacement.push(format!("{prefix}    {match_expression}"));
        replacement.extend(
            lines[start..chunk_end]
                .iter()
                .map(|line| format!("    {line}")),
        );
        if let Some(next) = names.get(index + 1) {
            replacement.push(format!("{prefix}    | _ -> {next} ()"));
        }
    }
    replacement.push(format!("{prefix}{} ()", names[0]));
    lines.splice(match_index..end, replacement);
    let trailing = declaration.text.ends_with(char::from(10));
    let mut text = lines.join(&char::from(10).to_string());
    if trailing {
        text.push(char::from(10));
    }
    let mut updated = declaration.clone();
    updated.text = text;
    updated.fingerprint = fnv1a64(updated.text.as_bytes());
    updated.span.end = updated.span.start + updated.text.lines().count();
    Some(updated)
}

#[derive(Clone, Copy, Debug, Eq, PartialEq)]
pub enum FunnelTraceBoundary {
    Original,
    AfterTerminalPartition,
    AfterComponent(usize),
    BlockedAtComponent(usize),
}

impl Display for FunnelTraceBoundary {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Original => formatter.write_str("original"),
            Self::AfterTerminalPartition => formatter.write_str("after-terminal-partition"),
            Self::AfterComponent(component) => write!(formatter, "after:{component}"),
            Self::BlockedAtComponent(component) => write!(formatter, "blocked:{component}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct FunnelLexicalStep {
    pub prefix_len: usize,
    pub boundary: FunnelTraceBoundary,
    pub owner_lines: usize,
    pub probe: Option<SymbolLexicalProbe>,
    pub blocker: Option<BatchBlocker>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct FunnelLexicalTrace {
    pub owner: DeclarationId,
    pub parent_local_index: usize,
    pub symbol: String,
    pub selected: Vec<usize>,
    pub steps: Vec<FunnelLexicalStep>,
}

impl FunnelLexicalTrace {
    #[must_use]
    pub fn render_tsv(&self) -> String {
        let baseline = self.steps.first().and_then(|step| step.probe);
        let mut output = String::from(
            "prefix\tboundary\towner_lines\tcode\tline\tblock\tstring\tverbatim\tinterpolated\tchar\tfinal\tfirst_string_newline\tfirst_symbol_line\tchanged\tblocker\n",
        );
        for step in &self.steps {
            if let Some(probe) = step.probe {
                let changed = baseline.is_some_and(|base| {
                    (
                        probe.code,
                        probe.line_comment,
                        probe.block_comment,
                        probe.string_literal,
                        probe.verbatim_string,
                        probe.interpolated_string,
                        probe.character_literal,
                    ) != (
                        base.code,
                        base.line_comment,
                        base.block_comment,
                        base.string_literal,
                        base.verbatim_string,
                        base.interpolated_string,
                        base.character_literal,
                    )
                });
                let blocker = step
                    .blocker
                    .as_ref()
                    .map(ToString::to_string)
                    .unwrap_or_else(|| "-".to_owned());
                let _ = writeln!(
                    output,
                    "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
                    step.prefix_len,
                    step.boundary,
                    step.owner_lines,
                    probe.code,
                    probe.line_comment,
                    probe.block_comment,
                    probe.string_literal,
                    probe.verbatim_string,
                    probe.interpolated_string,
                    probe.character_literal,
                    probe.final_state,
                    probe.first_string_newline_line,
                    probe.first_symbol_line,
                    changed,
                    blocker,
                );
            } else {
                let blocker = step
                    .blocker
                    .as_ref()
                    .map(ToString::to_string)
                    .unwrap_or_else(|| "-".to_owned());
                let _ = writeln!(
                    output,
                    "{}\t{}\t{}\t-\t-\t-\t-\t-\t-\t-\t-\t-\t-\t-\t{}",
                    step.prefix_len, step.boundary, step.owner_lines, blocker,
                );
            }
        }
        output
    }
}

pub fn trace_owner_funnel_symbol(
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    max_lines: usize,
    symbol: &str,
) -> Result<FunnelLexicalTrace, FunnelBlocker> {
    let extracted_owner = extract_parent(owner, parent)?;
    let nested_owner = partition_terminal_match(&extracted_owner, max_lines)
        .unwrap_or_else(|| extracted_owner.clone());
    let (nested_groups, nested_components) = plan_owner(&nested_owner);
    if nested_groups.is_empty() {
        return Err(FunnelBlocker::NoNestedBindings);
    }
    let (nested_selected, _) =
        select_for_target(&nested_components, nested_owner.line_count(), max_lines);
    if nested_selected.is_empty() {
        return Err(FunnelBlocker::EmptyNestedSelection);
    }
    let mut selected = nested_selected;
    selected.sort_by_key(|component| {
        nested_components
            .iter()
            .find(|candidate| candidate.component == *component)
            .map_or((usize::MAX, *component), |candidate| {
                (candidate.start_line, *component)
            })
    });
    let mut steps = vec![
        FunnelLexicalStep {
            prefix_len: 0,
            boundary: FunnelTraceBoundary::Original,
            owner_lines: extracted_owner.line_count(),
            probe: Some(probe_symbol_states(&extracted_owner.text, symbol)?),
            blocker: None,
        },
        FunnelLexicalStep {
            prefix_len: 0,
            boundary: FunnelTraceBoundary::AfterTerminalPartition,
            owner_lines: nested_owner.line_count(),
            probe: Some(probe_symbol_states(&nested_owner.text, symbol)?),
            blocker: None,
        },
    ];
    for prefix_len in 1..=selected.len() {
        let component = selected[prefix_len - 1];
        match rewrite_owner_batch(
            &nested_owner,
            &nested_groups,
            &nested_components,
            &selected[..prefix_len],
        ) {
            Ok(batch) => steps.push(FunnelLexicalStep {
                prefix_len,
                boundary: FunnelTraceBoundary::AfterComponent(component),
                owner_lines: batch.owner_text.lines().count(),
                probe: Some(probe_symbol_states(&batch.owner_text, symbol)?),
                blocker: None,
            }),
            Err(blocker) => {
                steps.push(FunnelLexicalStep {
                    prefix_len,
                    boundary: FunnelTraceBoundary::BlockedAtComponent(component),
                    owner_lines: steps
                        .last()
                        .map_or(nested_owner.line_count(), |step| step.owner_lines),
                    probe: None,
                    blocker: Some(blocker),
                });
                break;
            }
        }
    }
    Ok(FunnelLexicalTrace {
        owner: owner.id,
        parent_local_index: parent.local_index,
        symbol: symbol.to_owned(),
        selected,
        steps,
    })
}

pub fn rewrite_owner_terminal_match(
    source: &str,
    owner: &Declaration<Linked>,
    max_lines: usize,
) -> Result<(BatchRewriteArtifact<BatchApplied>, String), FunnelBlocker> {
    let partitioned = partition_terminal_match(owner, max_lines)
        .ok_or(FunnelBlocker::NoTerminalMatchPartition)?;
    let (groups, components) = plan_owner(&partitioned);
    let prefix = format!("__spiral_match_{}_", owner.id.0);
    let generated = groups
        .iter()
        .flat_map(|group| group.names.iter())
        .filter(|name| name.starts_with(&prefix))
        .cloned()
        .collect::<BTreeSet<_>>();
    if generated.is_empty() {
        return Err(FunnelBlocker::NoNestedBindings);
    }
    let (selected, _) = select_named_closure(&components, &generated);
    if selected.is_empty() {
        return Err(FunnelBlocker::EmptyPromotionSelection);
    }
    let mut batch = rewrite_owner_batch(&partitioned, &groups, &components, &selected)?;
    batch.original_fingerprint = owner.fingerprint;
    let rewritten = splice_batch_owner(source, owner, &batch)?;
    Ok((batch, rewritten))
}

pub fn funnel_candidate_lines(
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    max_lines: usize,
) -> Result<usize, FunnelBlocker> {
    let extracted_owner = extract_parent(owner, parent)?;
    let nested_owner = partition_terminal_match(&extracted_owner, max_lines)
        .unwrap_or_else(|| extracted_owner.clone());
    let (nested_groups, nested_components) = plan_owner(&nested_owner);
    if nested_groups.is_empty() {
        return Err(FunnelBlocker::NoNestedBindings);
    }
    let (selected, receipts) =
        select_for_target(&nested_components, nested_owner.line_count(), max_lines);
    if selected.is_empty() {
        return Err(FunnelBlocker::EmptyNestedSelection);
    }
    Ok(receipts.iter().map(|receipt| receipt.lines).sum())
}

fn rollback_component(blocker: &BatchBlocker) -> Option<usize> {
    match blocker {
        BatchBlocker::ComponentBlocked(component)
        | BatchBlocker::MultiGroupComponent(component)
        | BatchBlocker::Rewrite { component, .. }
        | BatchBlocker::LexicalImbalance { component, .. } => Some(*component),
        BatchBlocker::DetachedCallUnowned(diagnostic) => Some(diagnostic.component),
        _ => None,
    }
}

fn rewrite_nested_with_rollback(
    owner: &Declaration<Linked>,
    groups: &[LocalGroup],
    components: &[ParametricComponent],
    selected: &mut Vec<usize>,
    dependency_nodes: &[DependencyNode],
) -> Result<(BatchRewriteArtifact<BatchApplied>, Vec<usize>), FunnelBlocker> {
    let mut rejected = Vec::new();
    loop {
        if selected.is_empty() {
            return Err(FunnelBlocker::EmptyNestedSelection);
        }
        match rewrite_owner_batch(owner, groups, components, selected) {
            Ok(batch) => return Ok((batch, rejected)),
            Err(blocker) => {
                let Some(component) = rollback_component(&blocker) else {
                    return Err(blocker.into());
                };
                match exclude_with_dependents(
                    selected,
                    dependency_nodes,
                    &BTreeSet::from([component]),
                ) {
                    RollbackSelection::Reduced {
                        selected: reduced,
                        removed,
                    } => {
                        rejected.extend(removed);
                        *selected = reduced;
                    }
                    RollbackSelection::Empty { removed } => {
                        rejected.extend(removed);
                        return Err(FunnelBlocker::EmptyNestedSelection);
                    }
                    RollbackSelection::Stable { .. } => return Err(blocker.into()),
                }
            }
        }
    }
}

pub fn rewrite_owner_funnel(
    source: &str,
    owner: &Declaration<Linked>,
    parent: &LocalGroup,
    max_lines: usize,
) -> Result<FunnelArtifact<Applied>, FunnelBlocker> {
    let extracted_owner = extract_parent(owner, parent)?;
    let nested_owner = partition_terminal_match(&extracted_owner, max_lines)
        .unwrap_or_else(|| extracted_owner.clone());
    let (nested_groups, nested_components) = plan_owner(&nested_owner);
    if nested_groups.is_empty() {
        return Err(FunnelBlocker::NoNestedBindings);
    }
    let (mut nested_selected, nested_receipts_seed) =
        select_for_target(&nested_components, nested_owner.line_count(), max_lines);
    let dependency_nodes = nested_components
        .iter()
        .map(|component| DependencyNode {
            component: component.component,
            dependencies: component.dependencies.clone(),
        })
        .collect::<Vec<_>>();
    let preflight_rejected = preflight_detached_call_uses(
        &nested_owner,
        &nested_groups,
        &nested_components,
        &nested_selected,
    )?;
    if !preflight_rejected.is_empty() {
        match exclude_with_dependents(&nested_selected, &dependency_nodes, &preflight_rejected) {
            RollbackSelection::Reduced { selected, .. } => nested_selected = selected,
            RollbackSelection::Empty { .. } => return Err(FunnelBlocker::EmptyNestedSelection),
            RollbackSelection::Stable { .. } => {}
        }
    }
    let (
        nested_batch,
        generated_names,
        updated_owner,
        promoted_groups,
        promoted_components,
        promoted_selected,
        promoted_receipts,
    ) = loop {
        if nested_selected.is_empty() {
            return Err(FunnelBlocker::EmptyNestedSelection);
        }
        let (nested_batch, _) = rewrite_nested_with_rollback(
            &nested_owner,
            &nested_groups,
            &nested_components,
            &mut nested_selected,
            &dependency_nodes,
        )?;
        let generated_names = generated_names(&nested_batch);
        let updated_owner = replace_parent(owner, parent, &nested_batch.full_text)?;
        let (promoted_groups, promoted_components_raw) = plan_owner(&updated_owner);
        let (initial_promoted_selected, _) =
            select_named_closure(&promoted_components_raw, &generated_names);
        let initial_promoted_ids = initial_promoted_selected
            .iter()
            .copied()
            .collect::<BTreeSet<_>>();
        let promoted_consumers = promoted_components_raw
            .iter()
            .filter(|component| initial_promoted_ids.contains(&component.component))
            .cloned()
            .collect::<Vec<_>>();
        let deferred_ambient = identify_deferred_ambient(
            parent,
            &promoted_groups,
            &promoted_components_raw,
            &promoted_consumers,
        );
        let promoted_components =
            suppress_deferred_ambient_captures(promoted_components_raw, &deferred_ambient);
        let mut promotion_names = generated_names.clone();
        promotion_names.extend(deferred_ambient.names());
        let (promoted_selected, promoted_receipts) =
            select_named_closure(&promoted_components, &promotion_names);
        let promoted_ids = promoted_selected.iter().copied().collect::<BTreeSet<_>>();
        let missing = generated_names.iter().find(|name| {
            !promoted_components.iter().any(|component| {
                promoted_ids.contains(&component.component) && component.names.contains(*name)
            })
        });
        let Some(name) = missing.cloned() else {
            break (
                nested_batch,
                generated_names,
                updated_owner,
                promoted_groups,
                promoted_components,
                promoted_selected,
                promoted_receipts,
            );
        };
        let producer = nested_batch.receipts.iter().find_map(|receipt| {
            receipt
                .lifted_names
                .split(',')
                .map(str::trim)
                .any(|candidate| candidate == name)
                .then_some(receipt.component)
        });
        let Some(producer) = producer else {
            return Err(FunnelBlocker::MissingGeneratedBinding(name));
        };
        match exclude_with_dependents(
            &nested_selected,
            &dependency_nodes,
            &BTreeSet::from([producer]),
        ) {
            RollbackSelection::Reduced { selected, .. } => nested_selected = selected,
            RollbackSelection::Empty { .. } => return Err(FunnelBlocker::EmptyNestedSelection),
            RollbackSelection::Stable { .. } => {
                return Err(FunnelBlocker::MissingGeneratedBinding(name));
            }
        }
    };
    if promoted_selected.is_empty() {
        return Err(FunnelBlocker::EmptyPromotionSelection);
    }
    let selected_ids = nested_selected.iter().copied().collect::<BTreeSet<_>>();
    let nested_receipts = nested_receipts_seed
        .into_iter()
        .filter(|receipt| selected_ids.contains(&receipt.component))
        .collect::<Vec<_>>();
    let promoted_batch = rewrite_owner_batch(
        &updated_owner,
        &promoted_groups,
        &promoted_components,
        &promoted_selected,
    )?;
    let final_source = splice_batch_owner(source, owner, &promoted_batch)?;
    Ok(FunnelArtifact {
        owner: owner.id,
        original_fingerprint: owner.fingerprint,
        parent_local_index: parent.local_index,
        parent_lines_before: nested_owner.line_count(),
        parent_lines_after: nested_batch.owner_text.lines().count(),
        owner_lines_before: owner.line_count(),
        owner_lines_after: promoted_batch.owner_text.lines().count(),
        nested_selected,
        promoted_selected,
        generated_names,
        nested_receipts,
        promoted_receipts,
        rewritten_calls: nested_batch.rewritten_calls + promoted_batch.rewritten_calls,
        final_source,
        nested_batch,
        promoted_batch,
        stage: PhantomData,
    })
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_lift::LiftDisposition;
    use std::collections::BTreeSet;

    fn source_fixture() -> (String, Declaration<Linked>, LocalGroup) {
        let source = "let outer env value =
    let nested x =
        let add y = env + y
        let twice y = add y + add y
        twice x
    nested value
"
        .to_owned();
        let owner = Declaration::<Raw>::new(
            DeclarationId(7),
            LineSpan { start: 0, end: 6 },
            "let outer env value =".to_owned(),
            source.clone(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(source.as_bytes()),
        )
        .restage();
        let parent = LocalGroup {
            owner: DeclarationId(7),
            owner_heading: owner.heading.clone(),
            local_index: 0,
            start_line: 1,
            end_line: 5,
            line_count: 4,
            names: BTreeSet::from(["nested".to_owned()]),
            parameters: BTreeSet::from(["x".to_owned()]),
            references: BTreeSet::new(),
            captures: BTreeSet::from(["env".to_owned()]),
            local_dependencies: BTreeSet::new(),
            disposition: LiftDisposition::Captures(BTreeSet::from(["env".to_owned()])),
        };
        (source, owner, parent)
    }

    #[test]
    fn terminal_partition_boundaries_ignore_multiline_string_lines() {
        let text = "match x with\n| A ->\n    failwith \"first\n| not a case\nend\"\n| B ->\n    helper x\n";
        let lines = text.lines().map(str::to_owned).collect::<Vec<_>>();
        let states = line_start_states(text).expect("line states");
        let end = match_end(&lines, &states, 0, 0);
        let starts = case_starts(&lines, &states, 0, end, 0);
        assert_eq!(end, lines.len());
        assert_eq!(starts, vec![1, 5]);
    }

    #[test]
    fn funnels_nested_helpers_to_top_level() {
        let (source, owner, parent) = source_fixture();
        let artifact = rewrite_owner_funnel(&source, &owner, &parent, 2).expect("funnel");
        assert!(!artifact.nested_selected.is_empty());
        assert!(!artifact.promoted_selected.is_empty());
        assert!(artifact.owner_lines_after < artifact.owner_lines_before);
        assert!(artifact.final_source.contains("__spiral_lift_"));
        assert!(artifact.final_source.contains("let outer env value ="));
    }

    #[test]
    fn late_non_call_use_rolls_back_component_and_dependents() {
        let text = "let outer env value =\n    let good x = env + x\n    let bad x = env + x\n    let alias = bad\n    good value\n";
        let owner = Declaration::<Raw>::new(
            DeclarationId(9),
            LineSpan { start: 0, end: 5 },
            "let outer env value =".to_owned(),
            text.to_owned(),
            BoundaryReason::TopLevel(DeclarationKind::LetGroup),
            Vec::new(),
            fnv1a64(text.as_bytes()),
        )
        .restage();
        let (groups, components) = plan_owner(&owner);
        let good = components
            .iter()
            .find(|component| component.names.contains("good"))
            .expect("good component")
            .component;
        let bad = components
            .iter()
            .find(|component| component.names.contains("bad"))
            .expect("bad component")
            .component;
        let dependency_nodes = components
            .iter()
            .map(|component| DependencyNode {
                component: component.component,
                dependencies: component.dependencies.clone(),
            })
            .collect::<Vec<_>>();
        let mut selected = vec![good, bad];
        let (batch, rejected) = rewrite_nested_with_rollback(
            &owner,
            &groups,
            &components,
            &mut selected,
            &dependency_nodes,
        )
        .expect("safe subset");
        assert!(rejected.contains(&bad));
        assert!(selected.contains(&good));
        assert!(!selected.contains(&bad));
        assert!(batch.hoisted_text.contains("good"));
    }
}
