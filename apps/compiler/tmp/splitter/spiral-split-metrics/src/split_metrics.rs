use spiral_split_model::{PROJECT_OVERHEAD_LINES, SplitMetrics, SplitPlan};
use std::{collections::BTreeMap, fs, path::PathBuf, time::Instant};

pub struct PhaseReceipt {
    path: PathBuf,
    started: Instant,
    log: String,
}

impl PhaseReceipt {
    #[must_use]
    pub fn new(path: PathBuf) -> Self {
        Self {
            path,
            started: Instant::now(),
            log: String::from("phase\telapsed_ms\n"),
        }
    }

    pub fn record(&mut self, phase: &str) -> Result<(), String> {
        self.log.push_str(&format!(
            "{phase}\t{:.3}\n",
            self.started.elapsed().as_secs_f64() * 1000.0
        ));
        if let Some(parent) = self.path.parent() {
            fs::create_dir_all(parent)
                .map_err(|error| format!("create {}: {error}", parent.display()))?;
        }
        fs::write(&self.path, &self.log)
            .map_err(|error| format!("write {}: {error}", self.path.display()))
    }
}

fn percentile(sorted: &[usize], numerator: usize, denominator: usize) -> usize {
    if sorted.is_empty() {
        return 0;
    }
    let index = ((sorted.len() - 1) * numerator).div_ceil(denominator);
    sorted[index.min(sorted.len() - 1)]
}

/// Longest weighted path through a DAG given as `dependencies[node]` (indices into `weights`).
/// Returns (path weight, path from its first provider to its last consumer). Iterative post-order DFS,
/// so a deep graph (the hopac core has ~10k declarations in long chains) cannot overflow the stack.
/// Edges to unknown nodes are ignored; a cycle edge is ignored once its target is on the DFS stack.
#[must_use]
pub fn longest_weighted_path(weights: &[usize], dependencies: &[Vec<usize>]) -> (usize, Vec<usize>) {
    const UNVISITED: u8 = 0;
    const ACTIVE: u8 = 1;
    const DONE: u8 = 2;
    let count = weights.len();
    let mut state = vec![UNVISITED; count];
    let mut finish = vec![0usize; count];
    let mut predecessor = vec![usize::MAX; count];
    for root in 0..count {
        if state[root] != UNVISITED {
            continue;
        }
        let mut stack = vec![(root, 0usize)];
        state[root] = ACTIVE;
        while let Some((node, next)) = stack.last_mut() {
            let node = *node;
            let deps = &dependencies[node];
            if *next < deps.len() {
                let dep = deps[*next];
                *next += 1;
                if dep < count && state[dep] == UNVISITED {
                    state[dep] = ACTIVE;
                    stack.push((dep, 0));
                }
                continue;
            }
            let mut best = 0usize;
            let mut best_dep = usize::MAX;
            for &dep in deps {
                if dep < count && state[dep] == DONE && finish[dep] > best {
                    best = finish[dep];
                    best_dep = dep;
                }
            }
            finish[node] = best + weights[node];
            predecessor[node] = best_dep;
            state[node] = DONE;
            stack.pop();
        }
    }
    let Some(end) = (0..count).max_by_key(|&node| finish[node]) else {
        return (0, Vec::new());
    };
    let mut path = vec![end];
    let mut current = end;
    while predecessor[current] != usize::MAX {
        current = predecessor[current];
        path.push(current);
    }
    path.reverse();
    (finish[end], path)
}

/// Longest line-weighted path through the declaration graph using the closure (compile) edges that
/// shard project references are built from.
#[must_use]
pub fn declaration_closure_critical_lines(plan: &SplitPlan) -> usize {
    let (weights, _) = declaration_graph(plan);
    let index = plan
        .declarations
        .iter()
        .enumerate()
        .map(|(position, declaration)| (declaration.id.0, position))
        .collect::<std::collections::HashMap<usize, usize>>();
    let dependencies = plan
        .declarations
        .iter()
        .map(|declaration| {
            declaration
                .closure_dependencies
                .iter()
                .filter_map(|id| index.get(&id.0).copied())
                .collect()
        })
        .collect::<Vec<Vec<usize>>>();
    longest_weighted_path(&weights, &dependencies).0
}

fn declaration_graph(plan: &SplitPlan) -> (Vec<usize>, Vec<Vec<usize>>) {
    let index = plan
        .declarations
        .iter()
        .enumerate()
        .map(|(position, declaration)| (declaration.id.0, position))
        .collect::<std::collections::HashMap<usize, usize>>();
    let weights = plan
        .declarations
        .iter()
        .map(|declaration| declaration.span.end.saturating_sub(declaration.span.start).max(1))
        .collect();
    let dependencies = plan
        .declarations
        .iter()
        .map(|declaration| {
            declaration
                .direct_dependencies
                .iter()
                .filter_map(|id| index.get(&id.0).copied())
                .collect()
        })
        .collect();
    (weights, dependencies)
}

/// The declaration-level critical chain (first provider first), for finding which edges keep the
/// graph serial.
#[must_use]
pub fn declaration_critical_chain(plan: &SplitPlan) -> (usize, Vec<usize>) {
    let (weights, dependencies) = declaration_graph(plan);
    longest_weighted_path(&weights, &dependencies)
}

/// The line-weighted shard critical chain (indices into `plan.shards`, first provider first).
#[must_use]
pub fn shard_critical_chain(plan: &SplitPlan) -> (usize, Vec<usize>) {
    let (weights, dependencies) = shard_graph(plan, 0);
    longest_weighted_path(&weights, &dependencies)
}

fn shard_graph(plan: &SplitPlan, overhead: usize) -> (Vec<usize>, Vec<Vec<usize>>) {
    let index = plan
        .shards
        .iter()
        .enumerate()
        .map(|(position, shard)| (shard.id, position))
        .collect::<std::collections::HashMap<_, _>>();
    let weights = plan.shards.iter().map(|shard| shard.line_count + overhead).collect();
    let dependencies = plan
        .shards
        .iter()
        .map(|shard| {
            shard
                .compile_dependencies
                .iter()
                .filter_map(|id| index.get(id).copied())
                .collect()
        })
        .collect();
    (weights, dependencies)
}

#[must_use]
pub fn measure(plan: &SplitPlan) -> SplitMetrics {
    let mut shard_lines = plan
        .shards
        .iter()
        .map(|shard| shard.line_count)
        .collect::<Vec<_>>();
    shard_lines.sort_unstable();
    let direct_edges = plan
        .shards
        .iter()
        .map(|shard| shard.direct_dependencies.len())
        .sum();
    let compile_edges = plan
        .shards
        .iter()
        .map(|shard| shard.compile_dependencies.len())
        .sum();
    let dense_baseline_edges = plan
        .shards
        .len()
        .saturating_mul(plan.shards.len().saturating_sub(1))
        / 2;
    let mut layer_width = BTreeMap::<usize, usize>::new();
    for shard in &plan.shards {
        *layer_width.entry(shard.layer).or_default() += 1;
    }
    let layers = layer_width.len();
    let widest_layer = layer_width.values().copied().max().unwrap_or(0);
    let estimated_parallelism = if layers == 0 {
        0.0
    } else {
        plan.shards.len() as f64 / layers as f64
    };
    let edge_reduction_ratio = if dense_baseline_edges == 0 {
        1.0
    } else {
        1.0 - compile_edges as f64 / dense_baseline_edges as f64
    };
    let (line_weights, shard_dependencies) = shard_graph(plan, 0);
    let (critical_path_lines, _) = longest_weighted_path(&line_weights, &shard_dependencies);
    let (work_weights, _) = shard_graph(plan, PROJECT_OVERHEAD_LINES);
    let (critical_work, _) = longest_weighted_path(&work_weights, &shard_dependencies);
    let total_work = work_weights.iter().sum::<usize>();
    let work_parallelism = if critical_work == 0 {
        0.0
    } else {
        total_work as f64 / critical_work as f64
    };
    let (declaration_critical_path_lines, _) = declaration_critical_chain(plan);
    SplitMetrics {
        source_bytes: plan.source.bytes,
        source_lines: plan.source.lines.len(),
        declarations: plan.declarations.len(),
        shards: plan.shards.len(),
        direct_edges,
        compile_edges,
        dense_baseline_edges,
        layers,
        widest_layer,
        max_shard_lines: shard_lines.last().copied().unwrap_or(0),
        p50_shard_lines: percentile(&shard_lines, 50, 100),
        p95_shard_lines: percentile(&shard_lines, 95, 100),
        oversize_shards: plan.shards.iter().filter(|shard| shard.oversize).count(),
        estimated_parallelism,
        edge_reduction_ratio,
        critical_path_lines,
        declaration_critical_path_lines,
        work_parallelism,
    }
}

#[must_use]
pub fn render_tsv(plan: &SplitPlan, metrics: &SplitMetrics) -> String {
    let mut output = String::from("metric\tvalue\tnote\n");
    let rows = [
        (
            "profile",
            plan.source.profile.to_string(),
            "detected source family",
        ),
        ("policy", plan.policy.to_string(), "split policy"),
        (
            "reference_mode",
            plan.reference_mode.to_string(),
            "project reference mode",
        ),
        (
            "source_bytes",
            metrics.source_bytes.to_string(),
            "truth monolith bytes",
        ),
        (
            "source_lines",
            metrics.source_lines.to_string(),
            "truth monolith lines",
        ),
        (
            "declarations",
            metrics.declarations.to_string(),
            "safe top-level units",
        ),
        (
            "shards",
            metrics.shards.to_string(),
            "generated F# projects",
        ),
        (
            "direct_edges",
            metrics.direct_edges.to_string(),
            "symbol-derived shard edges",
        ),
        (
            "compile_edges",
            metrics.compile_edges.to_string(),
            "selected project edges",
        ),
        (
            "dense_baseline_edges",
            metrics.dense_baseline_edges.to_string(),
            "all-prior reference baseline",
        ),
        ("layers", metrics.layers.to_string(), "dependency depth"),
        (
            "widest_layer",
            metrics.widest_layer.to_string(),
            "maximum parallel frontier",
        ),
        (
            "p50_shard_lines",
            metrics.p50_shard_lines.to_string(),
            "median shard lines",
        ),
        (
            "p95_shard_lines",
            metrics.p95_shard_lines.to_string(),
            "95th percentile shard lines",
        ),
        (
            "max_shard_lines",
            metrics.max_shard_lines.to_string(),
            "largest indivisible declaration group",
        ),
        (
            "oversize_shards",
            metrics.oversize_shards.to_string(),
            "groups beyond configured cap",
        ),
        (
            "estimated_parallelism",
            format!("{:.3}", metrics.estimated_parallelism),
            "shards divided by layers",
        ),
        (
            "edge_reduction_ratio",
            format!("{:.6}", metrics.edge_reduction_ratio),
            "fraction removed versus dense baseline",
        ),
        (
            "critical_path_lines",
            metrics.critical_path_lines.to_string(),
            "line-weighted longest shard chain",
        ),
        (
            "declaration_critical_path_lines",
            metrics.declaration_critical_path_lines.to_string(),
            "line-weighted longest declaration chain (packing floor)",
        ),
        (
            "work_parallelism",
            format!("{:.3}", metrics.work_parallelism),
            "total work over critical work, per-project overhead included",
        ),
    ];
    for (metric, value, note) in rows {
        output.push_str(metric);
        output.push('\t');
        output.push_str(&value);
        output.push('\t');
        output.push_str(note);
        output.push('\n');
    }
    output
}

#[must_use]
pub fn render_oversize_tsv(plan: &SplitPlan) -> String {
    let mut shards = plan
        .shards
        .iter()
        .filter(|shard| shard.oversize)
        .collect::<Vec<_>>();
    shards.sort_by_key(|shard| std::cmp::Reverse(shard.line_count));
    let mut output =
        String::from("shard\tdeclarations\tstart_line\tend_line\tlines\tbytes\tkind\theading\n");
    for shard in shards {
        let Some(first_id) = shard.declarations.first() else {
            continue;
        };
        let Some(last_id) = shard.declarations.last() else {
            continue;
        };
        let first = &plan.declarations[first_id.0];
        let last = &plan.declarations[last_id.0];
        let kind = if shard.declarations.len() == 1 {
            first.boundary.kind().to_string()
        } else {
            "group".to_owned()
        };
        let declarations = shard
            .declarations
            .iter()
            .map(|id| id.0.to_string())
            .collect::<Vec<_>>()
            .join(",");
        let heading = first.heading.replace(['\t', '\n'], " ");
        output.push_str(&format!(
            "{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\n",
            shard.id,
            declarations,
            first.span.start,
            last.span.end,
            shard.line_count,
            shard.bytes,
            kind,
            heading,
        ));
    }
    output
}

#[must_use]
pub fn render_summary(plan: &SplitPlan, metrics: &SplitMetrics) -> String {
    format!(
        "source={} profile={} declarations={} shards={} layers={} widest={} p95_lines={} max_lines={} oversize={} direct_edges={} compile_edges={} dense_edges={} edge_reduction={:.2}% estimated_parallelism={:.2} critical_path_lines={} declaration_critical_path_lines={} work_parallelism={:.2}",
        plan.source.path.display(),
        plan.source.profile,
        metrics.declarations,
        metrics.shards,
        metrics.layers,
        metrics.widest_layer,
        metrics.p95_shard_lines,
        metrics.max_shard_lines,
        metrics.oversize_shards,
        metrics.direct_edges,
        metrics.compile_edges,
        metrics.dense_baseline_edges,
        metrics.edge_reduction_ratio * 100.0,
        metrics.estimated_parallelism,
        metrics.critical_path_lines,
        metrics.declaration_critical_path_lines,
        metrics.work_parallelism,
    )
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn percentile_handles_empty_input() {
        assert_eq!(percentile(&[], 95, 100), 0);
    }

    #[test]
    fn percentile_is_deterministic() {
        assert_eq!(percentile(&[1, 2, 3, 4, 5], 50, 100), 3);
        assert_eq!(percentile(&[1, 2, 3, 4, 5], 95, 100), 5);
    }
}
