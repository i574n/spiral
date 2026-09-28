use spiral_split_gears::Gear;
use std::fmt::Write as _;
use std::marker::PhantomData;

#[derive(Clone, Copy, Debug, Default, Eq, PartialEq)]
pub struct Computed;

#[derive(Clone, Debug, Eq, PartialEq)]
pub struct CriticalPathStep {
    pub order: usize,
    pub gear_id: usize,
    pub source_layer: usize,
    pub lines: usize,
    pub cumulative_lines: usize,
    pub first_shard: usize,
    pub last_shard: usize,
    pub teeth: usize,
}

#[derive(Clone, Debug, Eq, PartialEq)]
pub enum CriticalPathWitness<State> {
    Empty(PhantomData<State>),
    Path {
        total_lines: usize,
        steps: Vec<CriticalPathStep>,
        state: PhantomData<State>,
    },
}

#[must_use]
pub fn compute_critical_path(gears: &[Gear]) -> CriticalPathWitness<Computed> {
    if gears.is_empty() {
        return CriticalPathWitness::Empty(PhantomData);
    }
    let mut path_lines = vec![0usize; gears.len()];
    let mut path_gears = vec![0usize; gears.len()];
    let mut predecessor = vec![None::<usize>; gears.len()];
    for gear in gears {
        let dependency = gear
            .dependencies
            .iter()
            .copied()
            .max_by_key(|dependency| (path_lines[*dependency], path_gears[*dependency]));
        let (dependency_lines, dependency_gears) = dependency
            .map(|id| (path_lines[id], path_gears[id]))
            .unwrap_or((0, 0));
        path_lines[gear.id] = dependency_lines + gear.lines;
        path_gears[gear.id] = dependency_gears + 1;
        predecessor[gear.id] = dependency;
    }
    let terminal = gears
        .iter()
        .map(|gear| gear.id)
        .max_by_key(|id| (path_lines[*id], path_gears[*id]))
        .expect("non-empty gears have a terminal");
    let mut ids = Vec::with_capacity(path_gears[terminal]);
    let mut cursor = Some(terminal);
    while let Some(id) = cursor {
        ids.push(id);
        cursor = predecessor[id];
    }
    ids.reverse();
    let steps = ids
        .into_iter()
        .enumerate()
        .map(|(order, id)| {
            let gear = &gears[id];
            CriticalPathStep {
                order,
                gear_id: id,
                source_layer: gear.source_layer,
                lines: gear.lines,
                cumulative_lines: path_lines[id],
                first_shard: gear.shards.first().copied().unwrap_or(0),
                last_shard: gear.shards.last().copied().unwrap_or(0),
                teeth: gear.shards.len(),
            }
        })
        .collect::<Vec<_>>();
    CriticalPathWitness::Path {
        total_lines: path_lines[terminal],
        steps,
        state: PhantomData,
    }
}

#[must_use]
pub fn render_critical_path_tsv(witness: &CriticalPathWitness<Computed>) -> String {
    let mut output = String::from(
        "critical_path_order\tgear\tsource_layer\tlines\tcumulative_lines\tfirst_shard\tlast_shard\tteeth\n",
    );
    if let CriticalPathWitness::Path { steps, .. } = witness {
        for step in steps {
            let _ = writeln!(
                output,
                "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",
                step.order,
                step.gear_id,
                step.source_layer,
                step.lines,
                step.cumulative_lines,
                step.first_shard,
                step.last_shard,
                step.teeth
            );
        }
    }
    output
}

#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_gears::GearOrigin;
    use std::collections::BTreeSet;

    fn gear(id: usize, lines: usize, dependencies: &[usize]) -> Gear {
        Gear {
            id,
            source_layer: id,
            shards: vec![id],
            dependencies: dependencies.iter().copied().collect::<BTreeSet<_>>(),
            lines,
            bytes: lines,
            fingerprint: id as u64,
            oversize: false,
            origin: GearOrigin::Layer { source_layer: id },
        }
    }

    #[test]
    fn reconstructs_the_exact_maximum_line_path() {
        let gears = vec![
            gear(0, 10, &[]),
            gear(1, 20, &[0]),
            gear(2, 50, &[]),
            gear(3, 30, &[1, 2]),
        ];
        let witness = compute_critical_path(&gears);
        let CriticalPathWitness::Path {
            total_lines, steps, ..
        } = witness
        else {
            panic!("expected path witness");
        };
        assert_eq!(total_lines, 80);
        assert_eq!(
            steps.iter().map(|step| step.gear_id).collect::<Vec<_>>(),
            vec![2, 3]
        );
        assert_eq!(steps.last().map(|step| step.cumulative_lines), Some(80));
    }

    #[test]
    fn uses_gear_count_as_the_same_tie_breaker_as_metrics() {
        let gears = vec![
            gear(0, 10, &[]),
            gear(1, 10, &[0]),
            gear(2, 20, &[]),
            gear(3, 1, &[1, 2]),
        ];
        let witness = compute_critical_path(&gears);
        let CriticalPathWitness::Path { steps, .. } = witness else {
            panic!("expected path witness");
        };
        assert_eq!(
            steps.iter().map(|step| step.gear_id).collect::<Vec<_>>(),
            vec![0, 1, 3]
        );
    }
}
