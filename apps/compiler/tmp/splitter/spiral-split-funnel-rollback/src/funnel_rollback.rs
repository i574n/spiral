use std::collections::BTreeSet;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct DependencyNode {
    pub component: usize,
    pub dependencies: BTreeSet<usize>,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum RollbackSelection {
    Stable {
        selected: Vec<usize>,
    },
    Reduced {
        selected: Vec<usize>,
        removed: Vec<usize>,
    },
    Empty {
        removed: Vec<usize>,
    },
}

#[must_use]
pub fn exclude_with_dependents(
    selected: &[usize],
    nodes: &[DependencyNode],
    rejected_roots: &BTreeSet<usize>,
) -> RollbackSelection {
    let selected_set = selected.iter().copied().collect::<BTreeSet<_>>();
    let mut removed = rejected_roots
        .intersection(&selected_set)
        .copied()
        .collect::<BTreeSet<_>>();

    loop {
        let before = removed.len();
        for node in nodes {
            if selected_set.contains(&node.component)
                && node
                    .dependencies
                    .iter()
                    .any(|dependency| removed.contains(dependency))
            {
                removed.insert(node.component);
            }
        }
        if removed.len() == before {
            break;
        }
    }

    let kept = selected
        .iter()
        .copied()
        .filter(|component| !removed.contains(component))
        .collect::<Vec<_>>();
    let removed = removed.into_iter().collect::<Vec<_>>();
    if removed.is_empty() {
        RollbackSelection::Stable { selected: kept }
    } else if kept.is_empty() {
        RollbackSelection::Empty { removed }
    } else {
        RollbackSelection::Reduced {
            selected: kept,
            removed,
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    fn node(component: usize, dependencies: &[usize]) -> DependencyNode {
        DependencyNode {
            component,
            dependencies: dependencies.iter().copied().collect(),
        }
    }

    #[test]
    fn rejects_dependents_transitively() {
        let nodes = vec![node(1, &[2]), node(2, &[3]), node(3, &[]), node(4, &[])];
        assert_eq!(
            exclude_with_dependents(&[1, 2, 3, 4], &nodes, &BTreeSet::from([3])),
            RollbackSelection::Reduced {
                selected: vec![4],
                removed: vec![1, 2, 3],
            }
        );
    }

    #[test]
    fn preserves_unrelated_selection() {
        let nodes = vec![node(1, &[]), node(2, &[1]), node(3, &[])];
        assert_eq!(
            exclude_with_dependents(&[1, 2, 3], &nodes, &BTreeSet::from([9])),
            RollbackSelection::Stable {
                selected: vec![1, 2, 3],
            }
        );
    }

    #[test]
    fn reports_empty_when_rejection_owns_the_selection() {
        let nodes = vec![node(1, &[2]), node(2, &[])];
        assert_eq!(
            exclude_with_dependents(&[1, 2], &nodes, &BTreeSet::from([2])),
            RollbackSelection::Empty {
                removed: vec![1, 2],
            }
        );
    }
}
