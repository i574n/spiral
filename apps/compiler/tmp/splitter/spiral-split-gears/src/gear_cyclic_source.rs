use rayon::prelude::*;
use spiral_split_emit::FusedRenderIndex;
use spiral_split_gear_scc::{Condensed, SccPlan};
use spiral_split_model::SplitPlan;
use std::collections::{BTreeMap, BTreeSet};
use std::fmt::Write as _;
use std::fs;
use std::path::Path;

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub(crate) struct CyclicSourceFusion {
    pub groups: usize,
    pub fused_shards: usize,
    pub rewritten_consumers: usize,
    rows: Vec<(usize, usize, Vec<usize>)>,
}

impl CyclicSourceFusion {
    pub(crate) fn render_tsv(&self) -> String {
        let mut output = String::from("component\trepresentative\taliases\tshards\n");
        for (component, representative, aliases) in &self.rows {
            let alias_text = aliases
                .iter()
                .map(ToString::to_string)
                .collect::<Vec<_>>()
                .join(",");
            let _ = writeln!(
                output,
                "{component}\t{representative}\t{alias_text}\t{}",
                aliases.len() + 1
            );
        }
        let _ = writeln!(
            output,
            "summary\t-\t-\tgroups={} fused_shards={} rewritten_consumers={}",
            self.groups, self.fused_shards, self.rewritten_consumers
        );
        output
    }
}

fn part_name(shard: usize) -> String {
    format!("Part{shard:04}")
}

fn module_name(shard: usize) -> String {
    format!("spiral_compiler_{}", part_name(shard))
}

fn cyclic_source_fusion_needed(cyclic_components: usize) -> bool {
    cyclic_components > 0
}

fn cyclic_alias_scan_needed(alias_to_representative: &BTreeMap<usize, usize>) -> bool {
    !alias_to_representative.is_empty()
}

fn atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let temporary = path.with_extension("tmp-cyclic-source");
    fs::write(&temporary, text)
        .map_err(|error| format!("write {}: {error}", temporary.display()))?;
    if path.exists() {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

fn alias_placeholder(representative: usize, alias: usize) -> String {
    format!(
        "namespace Polyglot\n\nmodule {} =\n    let fusedRepresentativeShard = {}\n",
        module_name(alias),
        representative
    )
}

fn identifier_char(ch: char) -> bool {
    ch == '_' || ch == '\'' || ch.is_alphanumeric()
}

fn rewrite_module_aliases(text: &str, replacements: &BTreeMap<String, String>) -> String {
    if replacements.is_empty() {
        return text.to_string();
    }
    let mut output = String::with_capacity(text.len());
    let mut copied_until = 0usize;
    let mut chars = text.char_indices().peekable();
    while let Some((begin, ch)) = chars.next() {
        if !identifier_char(ch) {
            continue;
        }
        let mut end = begin + ch.len_utf8();
        while let Some(&(index, next)) = chars.peek() {
            if !identifier_char(next) {
                break;
            }
            chars.next();
            end = index + next.len_utf8();
        }
        let token = &text[begin..end];
        if let Some(replacement) = replacements.get(token) {
            output.push_str(&text[copied_until..begin]);
            output.push_str(replacement);
            copied_until = end;
        }
    }
    if copied_until == 0 {
        text.to_string()
    } else {
        output.push_str(&text[copied_until..]);
        output
    }
}

pub(crate) fn fuse_cyclic_sources(
    split: &SplitPlan,
    sccs: &SccPlan<Condensed>,
    output_root: &Path,
) -> Result<CyclicSourceFusion, String> {
    let mut receipt = CyclicSourceFusion::default();
    if !cyclic_source_fusion_needed(sccs.cyclic_components) {
        return Ok(receipt);
    }
    let mut alias_to_representative = BTreeMap::<usize, usize>::new();
    let mut fused_members = BTreeSet::new();
    let render_index = FusedRenderIndex::build(split);

    for component in sccs
        .components
        .iter()
        .filter(|component| component.cyclic && component.shards.len() > 1)
    {
        let (representative, source) = render_index.render(split, &component.shards)?;
        atomic_write(
            &output_root.join(format!("{}.fs", part_name(representative))),
            &source,
        )?;
        let aliases = component
            .shards
            .iter()
            .copied()
            .filter(|shard| *shard != representative)
            .collect::<Vec<_>>();
        for alias in &aliases {
            alias_to_representative.insert(*alias, representative);
        }
        fused_members.extend(component.shards.iter().copied());
        receipt.groups += 1;
        receipt.fused_shards += component.shards.len();
        receipt.rows.push((component.id, representative, aliases));
    }

    if !cyclic_alias_scan_needed(&alias_to_representative) {
        return Ok(receipt);
    }

    let module_replacements = alias_to_representative
        .iter()
        .map(|(alias, representative)| (module_name(*alias), module_name(*representative)))
        .collect::<BTreeMap<_, _>>();
    let rewritten_consumers = split
        .shards
        .par_iter()
        .filter(|shard| !fused_members.contains(&shard.id))
        .map(|shard| {
            let path = output_root.join(format!("{}.fs", part_name(shard.id)));
            let text = fs::read_to_string(&path)
                .map_err(|error| format!("read {}: {error}", path.display()))?;
            let rewritten = rewrite_module_aliases(&text, &module_replacements);
            if rewritten == text {
                Ok(false)
            } else {
                atomic_write(&path, &rewritten)?;
                Ok(true)
            }
        })
        .collect::<Result<Vec<_>, String>>()?
        .into_iter()
        .filter(|rewritten| *rewritten)
        .count();
    receipt.rewritten_consumers += rewritten_consumers;

    for (alias, representative) in alias_to_representative {
        atomic_write(
            &output_root.join(format!("{}.fs", part_name(alias))),
            &alias_placeholder(representative, alias),
        )?;
    }
    Ok(receipt)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn acyclic_plan_skips_fusion_index_and_consumer_scan() {
        assert!(!cyclic_source_fusion_needed(0));
        assert!(cyclic_source_fusion_needed(1));
        assert!(!cyclic_alias_scan_needed(&BTreeMap::new()));
        assert!(cyclic_alias_scan_needed(&BTreeMap::from([(
            2usize, 1usize
        )])));
    }

    #[test]
    fn indexed_alias_rewrite_matches_previous_replacement_semantics() {
        let replacements = BTreeMap::from([
            (
                "spiral_compiler_Part0002".to_string(),
                "spiral_compiler_Part0001".to_string(),
            ),
            (
                "spiral_compiler_Part0010".to_string(),
                "spiral_compiler_Part0009".to_string(),
            ),
        ]);
        let text = concat!(
            "open spiral_compiler_Part0002\n",
            "let a = spiral_compiler_Part0010.value\n",
            "let b = spiral_compiler_Part0002.value\n"
        );
        let previous = replacements
            .iter()
            .fold(text.to_string(), |text, (alias, representative)| {
                text.replace(alias, representative)
            });
        assert_eq!(rewrite_module_aliases(text, &replacements), previous);
    }
}
