use std::collections::{BTreeMap, BTreeSet};
use std::fmt::{Display, Formatter};
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Closed;

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum CaptureClosureBlocker {
    DuplicateComponent(usize),
    DuplicateProvider {
        symbol: String,
        first: usize,
        second: usize,
    },
}

impl Display for CaptureClosureBlocker {
    fn fmt(&self, formatter: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            Self::DuplicateComponent(component) => {
                write!(formatter, "duplicate-component:{component}")
            }
            Self::DuplicateProvider {
                symbol,
                first,
                second,
            } => write!(formatter, "duplicate-provider:{symbol}:{first}:{second}"),
        }
    }
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum CaptureOrigin {
    Direct,
    Through {
        provider: usize,
        tail: Box<CaptureOrigin>,
    },
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct CaptureNode {
    pub component: usize,
    pub names: BTreeSet<String>,
    pub references: BTreeSet<String>,
    pub parameters: BTreeSet<String>,
    pub bound: BTreeSet<String>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct CaptureEdge {
    pub caller: usize,
    pub callee: usize,
    pub symbol: String,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct CaptureClosure<S> {
    pub required: BTreeMap<usize, BTreeMap<String, CaptureOrigin>>,
    pub edges: Vec<CaptureEdge>,
    pub iterations: usize,
    stage: PhantomData<fn() -> S>,
}

impl CaptureClosure<Closed> {
    #[must_use]
    pub fn required_for(&self, component: usize) -> Option<&BTreeMap<String, CaptureOrigin>> {
        self.required.get(&component)
    }
}

fn provider_index(nodes: &[CaptureNode]) -> Result<BTreeMap<String, usize>, CaptureClosureBlocker> {
    let mut providers = BTreeMap::<String, usize>::new();
    let mut components = BTreeSet::new();
    for node in nodes {
        if !components.insert(node.component) {
            return Err(CaptureClosureBlocker::DuplicateComponent(node.component));
        }
        for name in &node.names {
            if let Some(previous) = providers.insert(name.clone(), node.component)
                && previous != node.component
            {
                return Err(CaptureClosureBlocker::DuplicateProvider {
                    symbol: name.clone(),
                    first: previous,
                    second: node.component,
                });
            }
        }
    }
    Ok(providers)
}

fn edges(nodes: &[CaptureNode], providers: &BTreeMap<String, usize>) -> Vec<CaptureEdge> {
    let mut result = Vec::new();
    for node in nodes {
        for reference in &node.references {
            let Some(callee) = providers.get(reference).copied() else {
                continue;
            };
            if callee != node.component {
                result.push(CaptureEdge {
                    caller: node.component,
                    callee,
                    symbol: reference.clone(),
                });
            }
        }
    }
    result.sort_by(|left, right| {
        (left.caller, left.callee, left.symbol.as_str()).cmp(&(
            right.caller,
            right.callee,
            right.symbol.as_str(),
        ))
    });
    result.dedup();
    result
}

fn seed(nodes: &[CaptureNode]) -> BTreeMap<usize, BTreeMap<String, CaptureOrigin>> {
    nodes
        .iter()
        .map(|node| {
            (
                node.component,
                node.parameters
                    .iter()
                    .map(|parameter| (parameter.clone(), CaptureOrigin::Direct))
                    .collect(),
            )
        })
        .collect()
}

fn step(
    current: &BTreeMap<usize, BTreeMap<String, CaptureOrigin>>,
    edges: &[CaptureEdge],
    bound: &BTreeMap<usize, BTreeSet<String>>,
) -> (BTreeMap<usize, BTreeMap<String, CaptureOrigin>>, bool) {
    let mut next = current.clone();
    let mut changed = false;
    for edge in edges {
        let Some(callee) = current.get(&edge.callee) else {
            continue;
        };
        let Some(caller) = next.get_mut(&edge.caller) else {
            continue;
        };
        for (parameter, origin) in callee {
            if caller.contains_key(parameter)
                || bound
                    .get(&edge.caller)
                    .is_some_and(|names| names.contains(parameter))
            {
                continue;
            }
            caller.insert(
                parameter.clone(),
                CaptureOrigin::Through {
                    provider: edge.callee,
                    tail: Box::new(origin.clone()),
                },
            );
            changed = true;
        }
    }
    (next, changed)
}

fn converge(
    current: BTreeMap<usize, BTreeMap<String, CaptureOrigin>>,
    edges: &[CaptureEdge],
    bound: &BTreeMap<usize, BTreeSet<String>>,
    iterations: usize,
) -> (BTreeMap<usize, BTreeMap<String, CaptureOrigin>>, usize) {
    let (next, changed) = step(&current, edges, bound);
    if changed {
        converge(next, edges, bound, iterations + 1)
    } else {
        (next, iterations)
    }
}

pub fn close_capture_requirements(
    nodes: &[CaptureNode],
) -> Result<CaptureClosure<Closed>, CaptureClosureBlocker> {
    let providers = provider_index(nodes)?;
    let edges = edges(nodes, &providers);
    let bound = nodes
        .iter()
        .map(|node| (node.component, node.bound.clone()))
        .collect::<BTreeMap<_, _>>();
    let (required, iterations) = converge(seed(nodes), &edges, &bound, 0);
    Ok(CaptureClosure {
        required,
        edges,
        iterations,
        stage: PhantomData,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    fn set(values: &[&str]) -> BTreeSet<String> {
        values.iter().map(|value| (*value).to_owned()).collect()
    }

    fn node(
        component: usize,
        names: &[&str],
        references: &[&str],
        parameters: &[&str],
    ) -> CaptureNode {
        CaptureNode {
            component,
            names: set(names),
            references: set(references),
            parameters: set(parameters),
            bound: BTreeSet::new(),
        }
    }

    #[test]
    fn closes_capture_requirements_across_selected_call_chain() {
        let closure = close_capture_requirements(&[
            node(0, &["first"], &["second"], &["own"]),
            node(1, &["second"], &["third"], &["env"]),
            node(2, &["third"], &[], &["push_op_no_rewrite"]),
        ])
        .expect("closure");
        let first = closure.required_for(0).expect("first");
        assert_eq!(
            first.keys().cloned().collect::<Vec<_>>(),
            vec![
                "env".to_owned(),
                "own".to_owned(),
                "push_op_no_rewrite".to_owned(),
            ]
        );
        assert!(matches!(
            first.get("push_op_no_rewrite"),
            Some(CaptureOrigin::Through { provider: 1, tail })
                if matches!(tail.as_ref(), CaptureOrigin::Through { provider: 2, .. })
        ));
        assert!(closure.iterations >= 2);
    }

    #[test]
    fn caller_bound_parameters_are_not_repropagated() {
        let mut caller = node(0, &["first"], &["second"], &["own"]);
        caller.bound = set(&["s", "x"]);
        let mut callee = node(1, &["second"], &[], &["env", "s", "x"]);
        callee.bound = set(&["s", "x"]);
        let closure = close_capture_requirements(&[caller, callee]).expect("closure");
        assert_eq!(
            closure
                .required_for(0)
                .expect("caller")
                .keys()
                .cloned()
                .collect::<Vec<_>>(),
            vec!["env".to_owned(), "own".to_owned()]
        );
    }

    #[test]
    fn direct_capture_wins_over_transitive_provider() {
        let closure = close_capture_requirements(&[
            node(0, &["first"], &["second"], &["env"]),
            node(1, &["second"], &[], &["env"]),
        ])
        .expect("closure");
        assert_eq!(
            closure.required_for(0).and_then(|row| row.get("env")),
            Some(&CaptureOrigin::Direct)
        );
    }
}
