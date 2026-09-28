use std::collections::BTreeSet;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct StableTopologicalOrder {
    pub ordered_old: Vec<usize>,
    pub old_to_new: Vec<usize>,
}

pub fn stable_topological_order(
    dependencies: &[BTreeSet<usize>],
) -> Result<StableTopologicalOrder, String> {
    let count = dependencies.len();
    let mut pending = vec![0usize; count];
    let mut successors = vec![Vec::<usize>::new(); count];
    for (consumer, providers) in dependencies.iter().enumerate() {
        pending[consumer] = providers.len();
        for provider in providers {
            if *provider >= count {
                return Err(format!(
                    "topology references unknown provider {provider} from node {consumer}"
                ));
            }
            if *provider == consumer {
                return Err(format!(
                    "topology contains self dependency at node {consumer}"
                ));
            }
            successors[*provider].push(consumer);
        }
    }
    for children in &mut successors {
        children.sort_unstable();
    }
    let mut ready = (0..count)
        .filter(|node| pending[*node] == 0)
        .collect::<BTreeSet<_>>();
    let mut ordered_old = Vec::with_capacity(count);
    while let Some(node) = ready.pop_first() {
        ordered_old.push(node);
        for successor in &successors[node] {
            pending[*successor] = pending[*successor]
                .checked_sub(1)
                .ok_or_else(|| format!("topology counter underflow at node {successor}"))?;
            if pending[*successor] == 0 {
                ready.insert(*successor);
            }
        }
    }
    if ordered_old.len() != count {
        let blocked = pending
            .iter()
            .enumerate()
            .filter_map(|(node, value)| (*value > 0).then_some(node.to_string()))
            .collect::<Vec<_>>()
            .join(",");
        let mut walk = Vec::<usize>::new();
        let mut current = pending
            .iter()
            .enumerate()
            .find_map(|(node, value)| (*value > 0).then_some(node))
            .expect("blocked topology has at least one unresolved node");
        let witness = loop {
            if let Some(begin) = walk.iter().position(|node| *node == current) {
                let mut cycle = walk[begin..].to_vec();
                cycle.push(current);
                break cycle;
            }
            walk.push(current);
            let Some(next) = dependencies[current]
                .iter()
                .copied()
                .find(|provider| pending[*provider] > 0)
            else {
                break Vec::new();
            };
            current = next;
        };
        let witness = witness
            .iter()
            .map(ToString::to_string)
            .collect::<Vec<_>>()
            .join("->");
        return Err(format!(
            "generated dependencies contain a cycle among nodes {blocked}; witness={witness}"
        ));
    }
    let mut old_to_new = vec![usize::MAX; count];
    for (new, old) in ordered_old.iter().copied().enumerate() {
        old_to_new[old] = new;
    }
    Ok(StableTopologicalOrder {
        ordered_old,
        old_to_new,
    })
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn forward_dependency_is_reordered_stably() {
        let dependencies = vec![BTreeSet::from([1]), BTreeSet::new(), BTreeSet::new()];
        let order = stable_topological_order(&dependencies).unwrap();
        assert_eq!(order.ordered_old, vec![1, 0, 2]);
        assert_eq!(order.old_to_new, vec![1, 0, 2]);
    }

    #[test]
    fn cycles_fail_closed() {
        let dependencies = vec![BTreeSet::from([1]), BTreeSet::from([0])];
        let error = stable_topological_order(&dependencies).unwrap_err();
        assert!(error.contains("cycle"));
    }
}
