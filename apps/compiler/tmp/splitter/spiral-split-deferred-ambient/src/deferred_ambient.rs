use spiral_split_lift::LocalGroup;
use spiral_split_lift_plan::{ParametricComponent, RewriteIntent};
use std::collections::{BTreeMap, BTreeSet};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Identified;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum DeferredAmbientSource {
    CaptureFreeOuterDependency {
        local_index: usize,
        component: usize,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DeferredAmbientBinding {
    pub name: String,
    pub source: DeferredAmbientSource,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DeferredAmbientPlan<S> {
    pub bindings: Vec<DeferredAmbientBinding>,
    stage: PhantomData<fn() -> S>,
}

impl DeferredAmbientPlan<Identified> {
    #[must_use]
    pub fn names(&self) -> BTreeSet<String> {
        self.bindings
            .iter()
            .map(|binding| binding.name.clone())
            .collect()
    }

    #[must_use]
    pub fn providers(&self) -> BTreeSet<usize> {
        self.bindings
            .iter()
            .map(|binding| match binding.source {
                DeferredAmbientSource::CaptureFreeOuterDependency { component, .. } => component,
            })
            .collect()
    }
}

#[must_use]
pub fn identify_deferred_ambient(
    parent: &LocalGroup,
    outer_groups: &[LocalGroup],
    outer_components: &[ParametricComponent],
    nested_components: &[ParametricComponent],
) -> DeferredAmbientPlan<Identified> {
    let requested = nested_components
        .iter()
        .flat_map(|component| component.effective_captures.iter().cloned())
        .collect::<BTreeSet<_>>();
    let mut bindings = BTreeMap::<String, (usize, DeferredAmbientBinding)>::new();
    for component in outer_components {
        let safe = component.owner == parent.owner
            && component.eligible()
            && component.members.len() == 1
            && component.effective_captures.is_empty()
            && component.end_line <= parent.start_line;
        if !safe {
            continue;
        }
        let Some(group) = component
            .members
            .first()
            .and_then(|member| outer_groups.get(*member))
        else {
            continue;
        };
        if group.owner != parent.owner {
            continue;
        }
        for name in component.names.intersection(&requested) {
            let binding = DeferredAmbientBinding {
                name: name.clone(),
                source: DeferredAmbientSource::CaptureFreeOuterDependency {
                    local_index: group.local_index,
                    component: component.component,
                },
            };
            match bindings.get(name) {
                Some((end_line, _)) if *end_line >= component.end_line => {}
                _ => {
                    bindings.insert(name.clone(), (component.end_line, binding));
                }
            }
        }
    }
    DeferredAmbientPlan {
        bindings: bindings.into_values().map(|(_, binding)| binding).collect(),
        stage: PhantomData,
    }
}

#[must_use]
pub fn suppress_deferred_ambient_captures(
    mut components: Vec<ParametricComponent>,
    plan: &DeferredAmbientPlan<Identified>,
) -> Vec<ParametricComponent> {
    let names = plan.names();
    if names.is_empty() {
        return components;
    }
    for component in &mut components {
        component
            .direct_captures
            .retain(|name| !names.contains(name));
        component
            .effective_captures
            .retain(|name| !names.contains(name));
        component
            .parameters
            .retain(|slot| !names.contains(&slot.name));
        for (ordinal, slot) in component.parameters.iter_mut().enumerate() {
            slot.ordinal = ordinal;
        }
        component.intents.retain(|intent| match intent {
            RewriteIntent::AddParameter { parameter, .. }
            | RewriteIntent::ThreadArgument { parameter, .. } => !names.contains(parameter),
            RewriteIntent::Hoist { .. } => true,
        });
        let ordinals = component
            .parameters
            .iter()
            .map(|slot| (slot.name.clone(), slot.ordinal))
            .collect::<BTreeMap<_, _>>();
        for intent in &mut component.intents {
            if let RewriteIntent::AddParameter {
                parameter, ordinal, ..
            } = intent
                && let Some(next) = ordinals.get(parameter)
            {
                *ordinal = *next;
            }
        }
    }
    components
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_lift::{LiftDisposition, LocalGroup};
    use spiral_split_lift_plan::{CaptureFlow, ParameterSlot, RewriteIntent};
    use spiral_split_model::DeclarationId;

    fn group(local_index: usize, name: &str, start: usize, end: usize) -> LocalGroup {
        LocalGroup {
            owner: DeclarationId(7),
            owner_heading: "outer".to_owned(),
            local_index,
            start_line: start,
            end_line: end,
            line_count: end.saturating_sub(start),
            names: BTreeSet::from([name.to_owned()]),
            parameters: BTreeSet::new(),
            references: BTreeSet::new(),
            captures: BTreeSet::new(),
            local_dependencies: BTreeSet::new(),
            disposition: LiftDisposition::Liftable,
        }
    }

    fn component(
        component: usize,
        member: usize,
        name: &str,
        start: usize,
        end: usize,
        captures: &[&str],
    ) -> ParametricComponent {
        let direct = captures
            .iter()
            .map(|capture| (*capture).to_owned())
            .collect::<BTreeSet<_>>();
        let parameters = direct
            .iter()
            .enumerate()
            .map(|(ordinal, name)| ParameterSlot {
                ordinal,
                name: name.clone(),
                flow: CaptureFlow::Direct {
                    parameter: name.clone(),
                },
            })
            .collect::<Vec<_>>();
        ParametricComponent {
            owner: DeclarationId(7),
            component,
            members: vec![member],
            names: BTreeSet::from([name.to_owned()]),
            dependencies: BTreeSet::new(),
            line_count: end.saturating_sub(start),
            start_line: start,
            end_line: end,
            direct_captures: direct.clone(),
            effective_captures: direct,
            parameters,
            recursive: false,
            blocker: None,
            intents: Vec::new(),
        }
    }

    #[test]
    fn identifies_capture_free_outer_dependency() {
        let helper = group(3, "poly", 10, 14);
        let mut parent = group(9, "nested", 20, 80);
        parent.local_dependencies.insert(3);
        let groups = vec![helper, parent.clone()];
        let components = vec![
            component(4, 0, "poly", 10, 14, &[]),
            component(8, 1, "nested", 20, 80, &["state"]),
        ];
        let nested = vec![component(9, 0, "inner", 0, 20, &["poly", "state"])];
        let plan = identify_deferred_ambient(&parent, &groups, &components, &nested);
        assert_eq!(plan.names(), BTreeSet::from(["poly".to_owned()]));
        assert_eq!(plan.providers(), BTreeSet::from([4]));
    }

    #[test]
    fn refuses_outer_dependency_that_needs_capture_parameters() {
        let helper = group(3, "poly", 10, 14);
        let mut parent = group(9, "nested", 20, 80);
        parent.local_dependencies.insert(3);
        let groups = vec![helper, parent.clone()];
        let components = vec![
            component(4, 0, "poly", 10, 14, &["env"]),
            component(8, 1, "nested", 20, 80, &[]),
        ];
        let nested = vec![component(9, 0, "inner", 0, 20, &["poly"])];
        let plan = identify_deferred_ambient(&parent, &groups, &components, &nested);
        assert!(plan.bindings.is_empty());
    }

    #[test]
    fn suppresses_only_deferred_ambient_capture_slots() {
        let plan = DeferredAmbientPlan::<Identified> {
            bindings: vec![DeferredAmbientBinding {
                name: "poly".to_owned(),
                source: DeferredAmbientSource::CaptureFreeOuterDependency {
                    local_index: 3,
                    component: 4,
                },
            }],
            stage: PhantomData,
        };
        let mut value = component(8, 0, "nested", 20, 80, &["poly", "state"]);
        value.intents = vec![
            RewriteIntent::AddParameter {
                owner: DeclarationId(7),
                component: 8,
                binding: "nested".to_owned(),
                parameter: "poly".to_owned(),
                ordinal: 0,
            },
            RewriteIntent::AddParameter {
                owner: DeclarationId(7),
                component: 8,
                binding: "nested".to_owned(),
                parameter: "state".to_owned(),
                ordinal: 1,
            },
        ];
        let result = suppress_deferred_ambient_captures(vec![value], &plan);
        let value = &result[0];
        assert_eq!(value.direct_captures, BTreeSet::from(["state".to_owned()]));
        assert_eq!(
            value.effective_captures,
            BTreeSet::from(["state".to_owned()])
        );
        assert_eq!(value.parameters.len(), 1);
        assert_eq!(value.parameters[0].name, "state");
        assert_eq!(value.parameters[0].ordinal, 0);
        assert!(value.intents.iter().all(|intent| match intent {
            RewriteIntent::AddParameter {
                parameter, ordinal, ..
            } => parameter == "state" && *ordinal == 0,
            _ => true,
        }));
    }
}
