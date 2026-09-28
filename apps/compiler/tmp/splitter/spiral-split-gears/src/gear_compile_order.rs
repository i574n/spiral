use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};

pub(crate) fn compile_order(split: &SplitPlan, shards: &[usize]) -> Vec<usize> {
    let members = shards.iter().copied().collect::<BTreeSet<_>>();
    let mut remaining_dependencies = BTreeMap::<usize, usize>::new();
    let mut successors = BTreeMap::<usize, BTreeSet<usize>>::new();

    for shard in shards {
        let dependencies = split.shards[*shard]
            .compile_dependencies
            .intersection(&members)
            .copied()
            .collect::<Vec<_>>();
        remaining_dependencies.insert(*shard, dependencies.len());
        for dependency in dependencies {
            successors.entry(dependency).or_default().insert(*shard);
        }
    }

    let mut ready = remaining_dependencies
        .iter()
        .filter_map(|(shard, count)| (*count == 0).then_some(*shard))
        .collect::<BTreeSet<_>>();
    let mut ordered = Vec::with_capacity(shards.len());
    let mut emitted = BTreeSet::new();

    while let Some(shard) = ready.pop_first() {
        ordered.push(shard);
        emitted.insert(shard);
        if let Some(consumers) = successors.get(&shard) {
            for consumer in consumers {
                let remaining = remaining_dependencies
                    .get_mut(consumer)
                    .expect("known in-gear consumer");
                *remaining = remaining.saturating_sub(1);
                if *remaining == 0 {
                    ready.insert(*consumer);
                }
            }
        }
    }

    for shard in shards {
        if !emitted.contains(shard) {
            ordered.push(*shard);
        }
    }
    ordered
}
