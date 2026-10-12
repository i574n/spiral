use spiral_split_union_context::UnionContextIndex;
use std::collections::{BTreeMap, BTreeSet};

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct LexicalCollisionWitness {
    pub provider: usize,
    pub type_names: BTreeSet<String>,
    pub shadowing_providers: BTreeSet<usize>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum LexicalOpenPlan {
    Stable,
    Reopen {
        witness: LexicalCollisionWitness,
        next: Box<LexicalOpenPlan>,
    },
}

impl LexicalOpenPlan {
    #[must_use]
    pub fn providers(&self) -> Vec<usize> {
        fn collect(plan: &LexicalOpenPlan, providers: &mut Vec<usize>) {
            match plan {
                LexicalOpenPlan::Stable => {}
                LexicalOpenPlan::Reopen { witness, next } => {
                    providers.push(witness.provider);
                    collect(next, providers);
                }
            }
        }

        let mut providers = Vec::new();
        collect(self, &mut providers);
        providers
    }
}

fn plan_from(mut witnesses: Vec<LexicalCollisionWitness>) -> LexicalOpenPlan {
    let Some(witness) = witnesses.pop() else {
        return LexicalOpenPlan::Stable;
    };
    let next = plan_from(witnesses);
    LexicalOpenPlan::Reopen {
        witness,
        next: Box::new(next),
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
struct OrderedCaseOwner {
    provider: usize,
    source_order: usize,
    type_name: String,
    cases: BTreeSet<String>,
}

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct LexicalOpenIndex {
    by_source_module: BTreeMap<Option<String>, Vec<LexicalCollisionWitness>>,
    ordered_by_source_module: BTreeMap<Option<String>, Vec<OrderedCaseOwner>>,
}

impl LexicalOpenIndex {
    #[must_use]
    pub fn build(index: &UnionContextIndex) -> Self {
        let mut shapes = BTreeMap::<(String, BTreeSet<String>), Vec<_>>::new();
        for group in &index.groups {
            shapes
                .entry((group.type_name.clone(), group.cases.clone()))
                .or_default()
                .push(group);
        }

        let mut collisions =
            BTreeMap::<(Option<String>, usize), (BTreeSet<String>, BTreeSet<usize>)>::new();
        for ((type_name, _), groups) in shapes {
            let providers = groups
                .iter()
                .map(|group| group.provider)
                .collect::<BTreeSet<_>>();
            if providers.len() < 2 {
                continue;
            }

            let mut lexical_providers = BTreeMap::<Option<String>, BTreeSet<usize>>::new();
            for group in groups {
                lexical_providers
                    .entry(group.source_module.clone())
                    .or_default()
                    .insert(group.provider);
            }

            for (source_module, owners) in lexical_providers {
                if owners.len() != 1 {
                    continue;
                }
                let provider = *owners.iter().next().expect("singleton lexical provider");
                let shadowing = providers
                    .iter()
                    .copied()
                    .filter(|candidate| *candidate != provider)
                    .collect::<BTreeSet<_>>();
                if shadowing.is_empty() {
                    continue;
                }
                let entry = collisions.entry((source_module, provider)).or_default();
                entry.0.insert(type_name.clone());
                entry.1.extend(shadowing);
            }
        }

        let mut by_source_module = BTreeMap::<Option<String>, Vec<LexicalCollisionWitness>>::new();
        for ((source_module, provider), (type_names, shadowing_providers)) in collisions {
            by_source_module
                .entry(source_module)
                .or_default()
                .push(LexicalCollisionWitness {
                    provider,
                    type_names,
                    shadowing_providers,
                });
        }
        for witnesses in by_source_module.values_mut() {
            witnesses.sort_by_key(|witness| witness.provider);
        }

        let mut ordered_by_source_module = BTreeMap::<Option<String>, Vec<OrderedCaseOwner>>::new();
        for group in &index.groups {
            let Some(source_order) = group.source_order else {
                continue;
            };
            ordered_by_source_module
                .entry(group.source_module.clone())
                .or_default()
                .push(OrderedCaseOwner {
                    provider: group.provider,
                    source_order,
                    type_name: group.type_name.clone(),
                    cases: group.cases.clone(),
                });
        }
        for owners in ordered_by_source_module.values_mut() {
            owners.sort_by_key(|owner| (owner.source_order, owner.provider));
        }

        Self {
            by_source_module,
            ordered_by_source_module,
        }
    }

    #[must_use]
    pub fn plan(
        &self,
        current_provider: usize,
        compile_dependencies: &BTreeSet<usize>,
        source_module: Option<&str>,
        consumer_order: usize,
    ) -> LexicalOpenPlan {
        let source_module = source_module.map(str::to_owned);
        let accessible = |provider: usize| {
            provider == current_provider || compile_dependencies.contains(&provider)
        };
        let mut selected = self
            .by_source_module
            .get(&source_module)
            .into_iter()
            .flatten()
            .filter(|witness| witness.provider != current_provider && accessible(witness.provider))
            .filter_map(|witness| {
                let shadowing_providers = witness
                    .shadowing_providers
                    .iter()
                    .copied()
                    .filter(|provider| accessible(*provider))
                    .collect::<BTreeSet<_>>();
                (!shadowing_providers.is_empty()).then(|| LexicalCollisionWitness {
                    provider: witness.provider,
                    type_names: witness.type_names.clone(),
                    shadowing_providers,
                })
            })
            .collect::<Vec<_>>();

        if let Some(owners) = self.ordered_by_source_module.get(&source_module) {
            let mut owners_by_case = BTreeMap::<String, Vec<&OrderedCaseOwner>>::new();
            for owner in owners
                .iter()
                .filter(|owner| owner.source_order < consumer_order && accessible(owner.provider))
            {
                for case in &owner.cases {
                    owners_by_case.entry(case.clone()).or_default().push(owner);
                }
            }

            let mut lexical = BTreeMap::<usize, (usize, BTreeSet<String>, BTreeSet<usize>)>::new();
            for candidates in owners_by_case.into_values() {
                let providers = candidates
                    .iter()
                    .map(|owner| owner.provider)
                    .collect::<BTreeSet<_>>();
                if providers.len() < 2 {
                    continue;
                }
                let latest = candidates
                    .iter()
                    .max_by_key(|owner| (owner.source_order, owner.provider))
                    .expect("non-empty lexical case owners");
                if latest.provider == current_provider {
                    continue;
                }
                let entry = lexical
                    .entry(latest.provider)
                    .or_insert_with(|| (latest.source_order, BTreeSet::new(), BTreeSet::new()));
                entry.0 = entry.0.max(latest.source_order);
                entry.1.insert(latest.type_name.clone());
                entry.2.extend(
                    providers
                        .iter()
                        .copied()
                        .filter(|provider| *provider != latest.provider),
                );
            }

            let mut lexical = lexical.into_iter().collect::<Vec<_>>();
            lexical.sort_by_key(|(provider, (source_order, _, _))| (*source_order, *provider));
            selected.extend(lexical.into_iter().map(
                |(provider, (_, type_names, shadowing_providers))| LexicalCollisionWitness {
                    provider,
                    type_names,
                    shadowing_providers,
                },
            ));
        }

        plan_from(selected.into_iter().rev().collect())
    }

    #[must_use]
    pub fn source_module_count(&self) -> usize {
        self.by_source_module.len()
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    fn duplicate_index() -> UnionContextIndex {
        UnionContextIndex::from_scoped_provider_sources([
            (
                2,
                Some("DiagJson"),
                "type Terminal =\
    | Ready\
    | Blocked\
",
            ),
            (
                7,
                Some("BigStack"),
                "type Terminal =\
    | Ready\
    | Blocked\
",
            ),
        ])
    }

    #[test]
    fn reopens_unique_lexical_provider_after_foreign_shadow() {
        let index = LexicalOpenIndex::build(&duplicate_index());
        let plan = index.plan(11, &BTreeSet::from([2, 7]), Some("BigStack"), 100);
        assert_eq!(plan.providers(), vec![7]);
    }

    #[test]
    fn local_owner_needs_no_reopen() {
        let index = LexicalOpenIndex::build(&duplicate_index());
        let plan = index.plan(7, &BTreeSet::from([2]), Some("BigStack"), 100);
        assert_eq!(plan, LexicalOpenPlan::Stable);
    }

    #[test]
    fn unrelated_source_module_does_not_guess() {
        let index = LexicalOpenIndex::build(&duplicate_index());
        let plan = index.plan(11, &BTreeSet::from([2, 7]), Some("Other"), 100);
        assert_eq!(plan, LexicalOpenPlan::Stable);
    }

    #[test]
    fn inaccessible_shadow_does_not_trigger_reopen() {
        let index = LexicalOpenIndex::build(&duplicate_index());
        let plan = index.plan(11, &BTreeSet::from([7]), Some("BigStack"), 100);
        assert_eq!(plan, LexicalOpenPlan::Stable);
    }

    #[test]
    fn index_is_compiled_once_by_source_module() {
        let index = LexicalOpenIndex::build(&duplicate_index());
        assert_eq!(index.source_module_count(), 2);
        assert_eq!(
            index
                .plan(11, &BTreeSet::from([2, 7]), Some("DiagJson"), 100)
                .providers(),
            vec![2]
        );
        assert_eq!(
            index
                .plan(11, &BTreeSet::from([2, 7]), Some("BigStack"), 100)
                .providers(),
            vec![7]
        );
    }

    #[test]
    fn latest_preceding_same_module_constructor_owner_wins() {
        let index = UnionContextIndex::from_ordered_scoped_provider_sources([
            (
                3,
                None,
                10,
                "type Raw =\n    | Directory of int * int * Raw list\n    | File of int * int * bool * bool\n",
            ),
            (
                7,
                None,
                20,
                "type Cooked =\n    | Directory of int * int * string * Cooked list\n    | File of int * int * string option\n",
            ),
        ]);
        let lexical = LexicalOpenIndex::build(&index);
        assert_eq!(
            lexical
                .plan(11, &BTreeSet::from([3, 7]), None, 30)
                .providers(),
            vec![7]
        );
        assert_eq!(
            lexical.plan(11, &BTreeSet::from([3, 7]), None, 15),
            LexicalOpenPlan::Stable
        );
    }
}
