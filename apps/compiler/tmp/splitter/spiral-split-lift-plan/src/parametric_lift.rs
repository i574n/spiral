use rayon::prelude::*;
use spiral_split_lift::{
    Classified, LiftDisposition, LocalComponent, LocalGroup, LocalLiftPlan, OwnerForecast,
    UnsupportedReason,
};
use spiral_split_model::DeclarationId;
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::{Display, Formatter, Write as _};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Planned;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum ParametricBlocker {
    Unsupported(UnsupportedReason),
    DependsOnBlocked(usize),
    MissingGroup(usize),
    CrossOwnerDependency(usize),
    ShadowedSelfCapture(String),
    EmptyComponent,
}

impl Display for ParametricBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Unsupported(reason) => write!(formatter, "unsupported:{reason}"),
            Self::DependsOnBlocked(component) => {
                write!(formatter, "depends-on-blocked:{component}")
            }
            Self::MissingGroup(group) => write!(formatter, "missing-group:{group}"),
            Self::CrossOwnerDependency(component) => {
                write!(formatter, "cross-owner-dependency:{component}")
            }
            Self::ShadowedSelfCapture(name) => {
                write!(formatter, "shadowed-self-capture:{name}")
            }
            Self::EmptyComponent => formatter.write_str("empty-component"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum CaptureFlow {
    Direct {
        parameter: String,
    },
    Through {
        parameter: String,
        provider: usize,
        tail: Box<CaptureFlow>,
    },
}

impl CaptureFlow {
    #[must_use]
    pub fn parameter(&self) -> &str {
        match self {
            Self::Direct { parameter } | Self::Through { parameter, .. } => parameter,
        }
    }

    #[must_use]
    pub fn depth(&self) -> usize {
        match self {
            Self::Direct { .. } => 1,
            Self::Through { tail, .. } => 1 + tail.depth(),
        }
    }
}

impl Display for CaptureFlow {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::Direct { parameter } => write!(formatter, "direct:{parameter}"),
            Self::Through {
                parameter,
                provider,
                tail,
            } => write!(formatter, "through:{provider}:{parameter}>{tail}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ParameterSlot {
    pub ordinal: usize,
    pub name: String,
    pub flow: CaptureFlow,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum RewriteIntent {
    Hoist {
        owner: DeclarationId,
        component: usize,
        start_line: usize,
        end_line: usize,
    },
    AddParameter {
        owner: DeclarationId,
        component: usize,
        binding: String,
        parameter: String,
        ordinal: usize,
    },
    ThreadArgument {
        owner: DeclarationId,
        caller: usize,
        callee: usize,
        symbol: String,
        parameter: String,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ParametricComponent {
    pub owner: DeclarationId,
    pub component: usize,
    pub members: Vec<usize>,
    pub names: BTreeSet<String>,
    pub dependencies: BTreeSet<usize>,
    pub line_count: usize,
    pub start_line: usize,
    pub end_line: usize,
    pub direct_captures: BTreeSet<String>,
    pub effective_captures: BTreeSet<String>,
    pub parameters: Vec<ParameterSlot>,
    pub recursive: bool,
    pub blocker: Option<ParametricBlocker>,
    pub intents: Vec<RewriteIntent>,
}

impl ParametricComponent {
    #[must_use]
    pub fn eligible(&self) -> bool {
        self.blocker.is_none()
    }

    #[must_use]
    pub fn parameterized(&self) -> bool {
        self.eligible() && !self.parameters.is_empty()
    }

    #[must_use]
    pub fn propagated_capture_count(&self) -> usize {
        self.effective_captures
            .difference(&self.direct_captures)
            .count()
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct OwnerParametricForecast {
    pub owner: DeclarationId,
    pub heading: String,
    pub lines_before: usize,
    pub eligible_lines: usize,
    pub lines_after: usize,
    pub components: usize,
    pub parameterized_components: usize,
    pub max_parameters: usize,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct ParametricSummary {
    pub owners: usize,
    pub components: usize,
    pub eligible_components: usize,
    pub parameterized_components: usize,
    pub blocked_components: usize,
    pub recursive_components: usize,
    pub direct_capture_slots: usize,
    pub propagated_capture_slots: usize,
    pub total_parameters: usize,
    pub max_parameters: usize,
    pub definition_edits: usize,
    pub argument_edits: usize,
    pub eligible_lines: usize,
    pub max_owner_lines_before: usize,
    pub max_owner_lines_after: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct ParametricLiftPlan<S> {
    pub components: Vec<ParametricComponent>,
    pub owners: Vec<OwnerParametricForecast>,
    pub summary: ParametricSummary,
    stage: PhantomData<fn() -> S>,
}

#[derive(Clone, Debug)]
struct ComponentDraft {
    owner: DeclarationId,
    component: usize,
    members: Vec<usize>,
    names: BTreeSet<String>,
    dependencies: BTreeSet<usize>,
    line_count: usize,
    start_line: usize,
    end_line: usize,
    direct_captures: BTreeSet<String>,
    effective_captures: BTreeSet<String>,
    recursive: bool,
    blocker: Option<ParametricBlocker>,
}

fn join(values: &BTreeSet<String>) -> String {
    values.iter().cloned().collect::<Vec<_>>().join(",")
}

fn owner_group_index(groups: &[LocalGroup]) -> BTreeMap<DeclarationId, BTreeMap<usize, usize>> {
    let mut result = BTreeMap::new();
    for (index, group) in groups.iter().enumerate() {
        result
            .entry(group.owner)
            .or_insert_with(BTreeMap::new)
            .insert(group.local_index, index);
    }
    result
}

fn group_component_index(components: &[LocalComponent]) -> BTreeMap<usize, usize> {
    let mut result = BTreeMap::new();
    for (index, component) in components.iter().enumerate() {
        for member in &component.members {
            result.insert(*member, index);
        }
    }
    result
}

fn draft_components(groups: &[LocalGroup], components: &[LocalComponent]) -> Vec<ComponentDraft> {
    let owner_groups = owner_group_index(groups);
    let group_components = group_component_index(components);
    components
        .par_iter()
        .map(|component| {
            let mut names = BTreeSet::new();
            let mut direct_captures = BTreeSet::new();
            let mut dependencies = BTreeSet::new();
            let mut blocker = if component.members.is_empty() {
                Some(ParametricBlocker::EmptyComponent)
            } else {
                None
            };
            let mut start_line = usize::MAX;
            let mut end_line = 0usize;
            let mut self_edge = false;
            for member in &component.members {
                let Some(group) = groups.get(*member) else {
                    blocker.get_or_insert(ParametricBlocker::MissingGroup(*member));
                    continue;
                };
                if group.owner != component.owner {
                    blocker.get_or_insert(ParametricBlocker::CrossOwnerDependency(
                        component.component,
                    ));
                }
                names.extend(group.names.iter().cloned());
                direct_captures.extend(group.captures.iter().cloned());
                start_line = start_line.min(group.start_line);
                end_line = end_line.max(group.end_line);
                if let LiftDisposition::Unsupported(reason) = group.disposition {
                    blocker.get_or_insert(ParametricBlocker::Unsupported(reason));
                }
                let local_map = owner_groups.get(&group.owner);
                for dependency in &group.local_dependencies {
                    let Some(target_group) = local_map.and_then(|map| map.get(dependency)) else {
                        blocker.get_or_insert(ParametricBlocker::MissingGroup(*dependency));
                        continue;
                    };
                    let Some(target_component_index) = group_components.get(target_group) else {
                        blocker.get_or_insert(ParametricBlocker::MissingGroup(*target_group));
                        continue;
                    };
                    let target = &components[*target_component_index];
                    if target.owner != component.owner {
                        blocker.get_or_insert(ParametricBlocker::CrossOwnerDependency(
                            target.component,
                        ));
                    } else if target.component == component.component {
                        self_edge = true;
                    } else {
                        dependencies.insert(target.component);
                    }
                }
            }
            if start_line == usize::MAX {
                start_line = 0;
            }
            let recursive = component.members.len() > 1 || self_edge;
            if !recursive && let Some(name) = names.intersection(&direct_captures).next().cloned() {
                blocker.get_or_insert(ParametricBlocker::ShadowedSelfCapture(name));
            }
            ComponentDraft {
                owner: component.owner,
                component: component.component,
                members: component.members.clone(),
                names,
                dependencies,
                line_count: component.line_count,
                start_line,
                end_line,
                effective_captures: direct_captures.clone(),
                direct_captures,
                recursive,
                blocker,
            }
        })
        .collect()
}

fn propagate(drafts: &mut [ComponentDraft]) {
    let by_id = drafts
        .iter()
        .enumerate()
        .map(|(index, draft)| (draft.component, index))
        .collect::<BTreeMap<_, _>>();
    loop {
        let snapshot = drafts.to_vec();
        let mut changed = false;
        for draft in drafts.iter_mut() {
            if draft.blocker.is_some() {
                continue;
            }
            for dependency in draft.dependencies.clone() {
                let Some(target_index) = by_id.get(&dependency).copied() else {
                    if draft.blocker.is_none() {
                        draft.blocker = Some(ParametricBlocker::MissingGroup(dependency));
                        changed = true;
                    }
                    continue;
                };
                let target = &snapshot[target_index];
                if target.owner != draft.owner {
                    if draft.blocker.is_none() {
                        draft.blocker = Some(ParametricBlocker::CrossOwnerDependency(dependency));
                        changed = true;
                    }
                } else if target.blocker.is_some() {
                    if target.names.is_empty() {
                        if draft.blocker.is_none() {
                            draft.blocker = Some(ParametricBlocker::DependsOnBlocked(dependency));
                            changed = true;
                        }
                    } else if let Some(name) =
                        draft.names.intersection(&target.names).next().cloned()
                    {
                        if draft.blocker.is_none() {
                            draft.blocker = Some(ParametricBlocker::ShadowedSelfCapture(name));
                            changed = true;
                        }
                    } else {
                        // A blocked local dependency can stay in the owner.  Hoisting the
                        // caller only needs the dependency value itself as an explicit
                        // parameter; its private captures do not escape with the caller.
                        let before = draft.effective_captures.len();
                        draft
                            .effective_captures
                            .extend(target.names.iter().cloned());
                        changed |= before != draft.effective_captures.len();
                    }
                } else {
                    let before = draft.effective_captures.len();
                    draft
                        .effective_captures
                        .extend(target.effective_captures.iter().cloned());
                    changed |= before != draft.effective_captures.len();
                }
            }
        }
        if !changed {
            break;
        }
    }
}

fn capture_flow(
    index: usize,
    parameter: &str,
    drafts: &[ComponentDraft],
    by_id: &BTreeMap<usize, usize>,
    visited: &mut BTreeSet<usize>,
) -> CaptureFlow {
    let draft = &drafts[index];
    if draft.direct_captures.contains(parameter) || !visited.insert(draft.component) {
        return CaptureFlow::Direct {
            parameter: parameter.to_owned(),
        };
    }
    for dependency in &draft.dependencies {
        let Some(target_index) = by_id.get(dependency).copied() else {
            continue;
        };
        if drafts[target_index].effective_captures.contains(parameter) {
            return CaptureFlow::Through {
                parameter: parameter.to_owned(),
                provider: *dependency,
                tail: Box::new(capture_flow(
                    target_index,
                    parameter,
                    drafts,
                    by_id,
                    visited,
                )),
            };
        }
    }
    CaptureFlow::Direct {
        parameter: parameter.to_owned(),
    }
}

fn intents_for(
    draft: &ComponentDraft,
    parameters: &[ParameterSlot],
    groups: &[LocalGroup],
    drafts: &[ComponentDraft],
    by_id: &BTreeMap<usize, usize>,
) -> Vec<RewriteIntent> {
    if draft.blocker.is_some() {
        return Vec::new();
    }
    let mut result = vec![RewriteIntent::Hoist {
        owner: draft.owner,
        component: draft.component,
        start_line: draft.start_line,
        end_line: draft.end_line,
    }];
    for member in &draft.members {
        if let Some(group) = groups.get(*member) {
            for binding in &group.names {
                for parameter in parameters {
                    result.push(RewriteIntent::AddParameter {
                        owner: draft.owner,
                        component: draft.component,
                        binding: binding.clone(),
                        parameter: parameter.name.clone(),
                        ordinal: parameter.ordinal,
                    });
                }
            }
        }
    }
    for dependency in &draft.dependencies {
        let Some(target_index) = by_id.get(dependency).copied() else {
            continue;
        };
        let target = &drafts[target_index];
        let symbol = target.names.iter().next().cloned().unwrap_or_default();
        for parameter in &target.effective_captures {
            result.push(RewriteIntent::ThreadArgument {
                owner: draft.owner,
                caller: draft.component,
                callee: *dependency,
                symbol: symbol.clone(),
                parameter: parameter.clone(),
            });
        }
    }
    result
}

fn plan_from_parts(
    groups: &[LocalGroup],
    components: &[LocalComponent],
    owners: &[OwnerForecast],
) -> ParametricLiftPlan<Planned> {
    let mut drafts = draft_components(groups, components);
    drafts.sort_by_key(|draft| (draft.owner, draft.component));
    propagate(&mut drafts);
    let by_id = drafts
        .iter()
        .enumerate()
        .map(|(index, draft)| (draft.component, index))
        .collect::<BTreeMap<_, _>>();
    let planned = drafts
        .iter()
        .enumerate()
        .map(|(index, draft)| {
            let parameters = if draft.blocker.is_none() {
                draft
                    .effective_captures
                    .iter()
                    .enumerate()
                    .map(|(ordinal, name)| ParameterSlot {
                        ordinal,
                        name: name.clone(),
                        flow: capture_flow(index, name, &drafts, &by_id, &mut BTreeSet::new()),
                    })
                    .collect::<Vec<_>>()
            } else {
                Vec::new()
            };
            let intents = intents_for(draft, &parameters, groups, &drafts, &by_id);
            ParametricComponent {
                owner: draft.owner,
                component: draft.component,
                members: draft.members.clone(),
                names: draft.names.clone(),
                dependencies: draft.dependencies.clone(),
                line_count: draft.line_count,
                start_line: draft.start_line,
                end_line: draft.end_line,
                direct_captures: draft.direct_captures.clone(),
                effective_captures: draft.effective_captures.clone(),
                parameters,
                recursive: draft.recursive,
                blocker: draft.blocker.clone(),
                intents,
            }
        })
        .collect::<Vec<_>>();
    let owner_rows = owners
        .iter()
        .map(|owner| {
            let values = planned
                .iter()
                .filter(|component| component.owner == owner.owner)
                .collect::<Vec<_>>();
            let eligible_lines = values
                .iter()
                .filter(|component| component.eligible())
                .map(|component| component.line_count)
                .sum::<usize>();
            OwnerParametricForecast {
                owner: owner.owner,
                heading: owner.heading.clone(),
                lines_before: owner.lines_before,
                eligible_lines,
                lines_after: owner.lines_before.saturating_sub(eligible_lines),
                components: values.len(),
                parameterized_components: values
                    .iter()
                    .filter(|component| component.parameterized())
                    .count(),
                max_parameters: values
                    .iter()
                    .map(|component| component.parameters.len())
                    .max()
                    .unwrap_or(0),
            }
        })
        .collect::<Vec<_>>();
    let definition_edits = planned
        .iter()
        .flat_map(|component| component.intents.iter())
        .filter(|intent| matches!(intent, RewriteIntent::AddParameter { .. }))
        .count();
    let argument_edits = planned
        .iter()
        .flat_map(|component| component.intents.iter())
        .filter(|intent| matches!(intent, RewriteIntent::ThreadArgument { .. }))
        .count();
    let summary = ParametricSummary {
        owners: owner_rows.len(),
        components: planned.len(),
        eligible_components: planned
            .iter()
            .filter(|component| component.eligible())
            .count(),
        parameterized_components: planned
            .iter()
            .filter(|component| component.parameterized())
            .count(),
        blocked_components: planned
            .iter()
            .filter(|component| !component.eligible())
            .count(),
        recursive_components: planned
            .iter()
            .filter(|component| component.recursive)
            .count(),
        direct_capture_slots: planned
            .iter()
            .map(|component| component.direct_captures.len())
            .sum(),
        propagated_capture_slots: planned
            .iter()
            .map(ParametricComponent::propagated_capture_count)
            .sum(),
        total_parameters: planned
            .iter()
            .map(|component| component.parameters.len())
            .sum(),
        max_parameters: planned
            .iter()
            .map(|component| component.parameters.len())
            .max()
            .unwrap_or(0),
        definition_edits,
        argument_edits,
        eligible_lines: owner_rows.iter().map(|owner| owner.eligible_lines).sum(),
        max_owner_lines_before: owner_rows
            .iter()
            .map(|owner| owner.lines_before)
            .max()
            .unwrap_or(0),
        max_owner_lines_after: owner_rows
            .iter()
            .map(|owner| owner.lines_after)
            .max()
            .unwrap_or(0),
    };
    ParametricLiftPlan {
        components: planned,
        owners: owner_rows,
        summary,
        stage: PhantomData,
    }
}

#[must_use]
pub fn plan_parametric_parts(
    groups: &[LocalGroup],
    components: &[LocalComponent],
    owners: &[OwnerForecast],
) -> ParametricLiftPlan<Planned> {
    plan_from_parts(groups, components, owners)
}

#[must_use]
pub fn plan_parametric_lifts(local: &LocalLiftPlan<Classified>) -> ParametricLiftPlan<Planned> {
    plan_parametric_parts(&local.groups, &local.components, &local.owners)
}

#[must_use]
pub fn render_parametric_summary(plan: &ParametricLiftPlan<Planned>) -> String {
    let summary = &plan.summary;
    format!(
        "parametric_lift owners={} components={} eligible={} parameterized={} blocked={} recursive={} direct_slots={} propagated_slots={} parameters={} max_parameters={} definition_edits={} argument_edits={} eligible_lines={} max_before={} max_after={}",
        summary.owners,
        summary.components,
        summary.eligible_components,
        summary.parameterized_components,
        summary.blocked_components,
        summary.recursive_components,
        summary.direct_capture_slots,
        summary.propagated_capture_slots,
        summary.total_parameters,
        summary.max_parameters,
        summary.definition_edits,
        summary.argument_edits,
        summary.eligible_lines,
        summary.max_owner_lines_before,
        summary.max_owner_lines_after,
    )
}

#[must_use]
pub fn render_parametric_tsv(plan: &ParametricLiftPlan<Planned>) -> String {
    let mut output = String::from(
        "owner	component	lines	start	end	members	names	dependencies	direct_captures	effective_captures	parameters	recursive	eligible	blocker	definition_edits	argument_edits
",
    );
    for component in &plan.components {
        let parameters = component
            .parameters
            .iter()
            .map(|parameter| {
                format!(
                    "{}:{}:{}",
                    parameter.ordinal, parameter.name, parameter.flow
                )
            })
            .collect::<Vec<_>>()
            .join(",");
        let definition_edits = component
            .intents
            .iter()
            .filter(|intent| matches!(intent, RewriteIntent::AddParameter { .. }))
            .count();
        let argument_edits = component
            .intents
            .iter()
            .filter(|intent| matches!(intent, RewriteIntent::ThreadArgument { .. }))
            .count();
        let _ = writeln!(
            output,
            "{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}	{}",
            component.owner.0,
            component.component,
            component.line_count,
            component.start_line,
            component.end_line,
            component
                .members
                .iter()
                .map(usize::to_string)
                .collect::<Vec<_>>()
                .join(","),
            join(&component.names),
            component
                .dependencies
                .iter()
                .map(usize::to_string)
                .collect::<Vec<_>>()
                .join(","),
            join(&component.direct_captures),
            join(&component.effective_captures),
            parameters,
            component.recursive,
            component.eligible(),
            component
                .blocker
                .as_ref()
                .map(ToString::to_string)
                .unwrap_or_default(),
            definition_edits,
            argument_edits,
        );
    }
    output.push_str(
        "
owner	heading	lines_before	eligible_lines	lines_after	components	parameterized_components	max_parameters
",
    );
    for owner in &plan.owners {
        let _ = writeln!(
            output,
            "{}	{}	{}	{}	{}	{}	{}	{}",
            owner.owner.0,
            owner.heading.replace('\t', " "),
            owner.lines_before,
            owner.eligible_lines,
            owner.lines_after,
            owner.components,
            owner.parameterized_components,
            owner.max_parameters,
        );
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;

    fn group(
        local_index: usize,
        name: &str,
        captures: &[&str],
        dependencies: &[usize],
        disposition: LiftDisposition,
    ) -> LocalGroup {
        LocalGroup {
            owner: DeclarationId(0),
            owner_heading: "outer".to_owned(),
            local_index,
            start_line: 10 + local_index * 5,
            end_line: 14 + local_index * 5,
            line_count: 5,
            names: BTreeSet::from([name.to_owned()]),
            parameters: BTreeSet::from(["value".to_owned()]),
            references: BTreeSet::new(),
            captures: captures.iter().map(|value| (*value).to_owned()).collect(),
            local_dependencies: dependencies.iter().copied().collect(),
            disposition,
        }
    }

    fn component(id: usize, members: &[usize]) -> LocalComponent {
        LocalComponent {
            owner: DeclarationId(0),
            component: id,
            members: members.to_vec(),
            line_count: members.len() * 5,
            captures: BTreeSet::new(),
            liftable: false,
        }
    }

    fn owner(lines: usize) -> OwnerForecast {
        OwnerForecast {
            owner: DeclarationId(0),
            heading: "outer".to_owned(),
            lines_before: lines,
            liftable_lines: 0,
            lines_after: lines,
            local_groups: 0,
            liftable_groups: 0,
        }
    }

    #[test]
    fn direct_capture_becomes_canonical_parameter() {
        let groups = vec![group(
            0,
            "helper",
            &["zeta", "alpha"],
            &[],
            LiftDisposition::Captures(BTreeSet::new()),
        )];
        let plan = plan_from_parts(&groups, &[component(0, &[0])], &[owner(100)]);
        assert_eq!(
            plan.components[0]
                .parameters
                .iter()
                .map(|parameter| parameter.name.as_str())
                .collect::<Vec<_>>(),
            vec!["alpha", "zeta"]
        );
        assert!(matches!(
            plan.components[0].parameters[0].flow,
            CaptureFlow::Direct { .. }
        ));
    }

    #[test]
    fn non_recursive_same_name_capture_is_blocked() {
        let groups = vec![group(
            0,
            "helper",
            &["env", "helper"],
            &[],
            LiftDisposition::Captures(BTreeSet::new()),
        )];
        let plan = plan_from_parts(&groups, &[component(0, &[0])], &[owner(100)]);
        assert!(!plan.components[0].eligible());
        assert!(plan.components[0].parameters.is_empty());
        assert!(matches!(
            plan.components[0].blocker,
            Some(ParametricBlocker::ShadowedSelfCapture(ref name)) if name == "helper"
        ));
    }

    #[test]
    fn captures_propagate_from_callee_to_caller() {
        let groups = vec![
            group(0, "caller", &[], &[1], LiftDisposition::Liftable),
            group(
                1,
                "callee",
                &["env"],
                &[],
                LiftDisposition::Captures(BTreeSet::new()),
            ),
        ];
        let plan = plan_from_parts(
            &groups,
            &[component(0, &[0]), component(1, &[1])],
            &[owner(100)],
        );
        assert!(plan.components[0].effective_captures.contains("env"));
        assert_eq!(plan.components[0].propagated_capture_count(), 1);
        assert_eq!(plan.components[0].parameters[0].flow.depth(), 2);
        assert_eq!(plan.summary.argument_edits, 1);
    }

    #[test]
    fn blocked_dependency_becomes_an_explicit_capture() {
        let groups = vec![
            group(0, "caller", &[], &[1], LiftDisposition::Liftable),
            group(
                1,
                "value",
                &[],
                &[],
                LiftDisposition::Unsupported(UnsupportedReason::ValueBinding),
            ),
        ];
        let plan = plan_from_parts(
            &groups,
            &[component(0, &[0]), component(1, &[1])],
            &[owner(100)],
        );
        let caller = &plan.components[0];
        assert!(caller.eligible());
        assert_eq!(caller.parameters.len(), 1);
        assert_eq!(caller.parameters[0].name, "value");
        assert!(matches!(
            caller.parameters[0].flow,
            CaptureFlow::Direct { .. }
        ));
        assert!(!plan.components[1].eligible());
        assert_eq!(plan.summary.blocked_components, 1);
    }

    #[test]
    fn recursive_component_shares_capture_order() {
        let groups = vec![
            group(
                0,
                "even",
                &["limit"],
                &[1],
                LiftDisposition::Captures(BTreeSet::new()),
            ),
            group(
                1,
                "odd",
                &["limit"],
                &[0],
                LiftDisposition::Captures(BTreeSet::new()),
            ),
        ];
        let plan = plan_from_parts(&groups, &[component(0, &[0, 1])], &[owner(100)]);
        assert!(plan.components[0].recursive);
        assert_eq!(plan.components[0].parameters.len(), 1);
        assert_eq!(plan.summary.definition_edits, 2);
    }

    #[test]
    fn owner_forecast_counts_all_parametric_lines() {
        let groups = vec![group(
            0,
            "helper",
            &["env"],
            &[],
            LiftDisposition::Captures(BTreeSet::new()),
        )];
        let plan = plan_from_parts(&groups, &[component(0, &[0])], &[owner(100)]);
        assert_eq!(plan.owners[0].eligible_lines, 5);
        assert_eq!(plan.owners[0].lines_after, 95);
        assert_eq!(plan.summary.max_owner_lines_after, 95);
    }

    #[test]
    fn capture_free_component_needs_no_parameter_edits() {
        let groups = vec![group(0, "helper", &[], &[], LiftDisposition::Liftable)];
        let plan = plan_from_parts(&groups, &[component(0, &[0])], &[owner(100)]);
        assert!(plan.components[0].eligible());
        assert!(!plan.components[0].parameterized());
        assert_eq!(plan.summary.definition_edits, 0);
    }
}
