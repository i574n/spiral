//! Stable gears and part numbers across emissions.
//!
//! Adding or removing a top-level declaration used to renumber every later part (`PartNNNN` is the
//! shard's position in source order) and, through the greedy timeline packing, reshape most gears
//! downstream; 98% of the parts that changed were only renumbered. With the previous emission's
//! anchors (`SPIRAL_GEAR_ANCHORS`: each declaration's key with the part and gear it ended up in), the
//! packer keeps components in their previous gear and the emitted parts and gears keep their numbers.
//! Numbers then no longer follow source order: consumers that need the order read `anchors.tsv`, whose
//! rows are the declarations in source order.

use spiral_split_model::{DeclarationScope, SplitPlan};
use std::collections::{BTreeMap, BTreeSet, HashMap};
use std::fs;
use std::path::Path;
use std::sync::OnceLock;

/// Path of the previous emission's `anchors.tsv`. Unset, or a missing file: plain source-order numbering.
pub const ANCHORS_ENV: &str = "SPIRAL_GEAR_ANCHORS";
pub const ANCHORS_FILE: &str = "anchors.tsv";

#[derive(Clone, Debug, Default, Eq, PartialEq)]
pub struct Anchors {
    /// Declaration key -> (part number, gear number) in the previous emission.
    by_key: HashMap<String, (usize, usize)>,
}

impl Anchors {
    #[must_use]
    pub fn parse(text: &str) -> Self {
        let mut by_key = HashMap::new();
        for line in text.lines().skip(1) {
            let mut cells = line.split('\t');
            let (Some(key), Some(part), Some(gear)) = (cells.next(), cells.next(), cells.next()) else {
                continue;
            };
            if let (Ok(part), Ok(gear)) = (part.parse(), gear.parse()) {
                by_key.insert(key.to_owned(), (part, gear));
            }
        }
        Self { by_key }
    }

    fn get(&self, key: &str) -> Option<(usize, usize)> {
        self.by_key.get(key).copied()
    }

    fn max_part(&self) -> Option<usize> {
        self.by_key.values().map(|(part, _)| *part).max()
    }

    fn max_gear(&self) -> Option<usize> {
        self.by_key.values().map(|(_, gear)| *gear).max()
    }
}

/// The anchors named by `SPIRAL_GEAR_ANCHORS`, read once per process.
pub fn anchors_from_env() -> Option<&'static Anchors> {
    static ANCHORS: OnceLock<Option<Anchors>> = OnceLock::new();
    ANCHORS
        .get_or_init(|| {
            let path = std::env::var_os(ANCHORS_ENV)?;
            let text = fs::read_to_string(path).ok()?;
            let anchors = Anchors::parse(&text);
            (!anchors.by_key.is_empty()).then_some(anchors)
        })
        .as_ref()
}

/// A key per declaration that survives body edits and insertions elsewhere: module, heading (the
/// `/// ### name` doc heading, often empty), the names it defines, and the occurrence among declarations
/// with all of those equal. The defined names matter: with module and heading alone, one declaration
/// added without a heading shifted the occurrence of every later heading-less one in its module, so they
/// all took their predecessor's anchor.
#[must_use]
pub fn declaration_keys(split: &SplitPlan) -> Vec<String> {
    let clean = |text: &str| text.trim().replace(['\t', '\r', '\n'], " ");
    let mut seen = HashMap::<String, usize>::new();
    split
        .declarations
        .iter()
        .map(|declaration| {
            let module = match &declaration.scope {
                DeclarationScope::ModuleFragment { module_name, .. } => clean(module_name),
                DeclarationScope::Root => String::new(),
            };
            let heading = clean(&declaration.heading);
            let definitions = declaration
                .definitions
                .iter()
                .map(|name| clean(name))
                .collect::<Vec<_>>()
                .join(",");
            let base = format!("{module}\u{1f}{heading}\u{1f}{definitions}");
            let ordinal = seen.entry(base.clone()).or_insert(0);
            let key = format!("{base}\u{1f}{ordinal}");
            *ordinal += 1;
            key
        })
        .collect()
}

/// The most common value, ties to the smallest.
fn majority(values: impl IntoIterator<Item = usize>) -> Option<usize> {
    let mut counts = BTreeMap::<usize, usize>::new();
    for value in values {
        *counts.entry(value).or_default() += 1;
    }
    counts
        .into_iter()
        .max_by(|(a, ca), (b, cb)| ca.cmp(cb).then(b.cmp(a)))
        .map(|(value, _)| value)
}

/// The previous gear of each group of shards: the majority over their declarations' anchors.
#[must_use]
pub fn previous_gear(split: &SplitPlan, keys: &[String], anchors: &Anchors, shards: &[usize]) -> Option<usize> {
    majority(
        shards
            .iter()
            .flat_map(|shard| split.shards[*shard].declarations.iter())
            .filter_map(|declaration| anchors.get(&keys[declaration.0]).map(|(_, gear)| gear)),
    )
}

/// The previous emission's gears as a partition of the condensed components, in topological order.
/// Anchored components return to their previous gear; a new component joins the gear of the component
/// just before it in source order (or starts one). Gears that an edit made mutually dependent are merged,
/// so the partition stays acyclic without re-planning the rest.
#[must_use]
pub fn anchored_partition(
    split: &SplitPlan,
    sccs: &spiral_split_gear_scc::SccPlan<spiral_split_gear_scc::Condensed>,
    anchors: &Anchors,
) -> Vec<Vec<usize>> {
    let keys = declaration_keys(split);
    let components = &sccs.components;
    let mut by_first_shard = (0..components.len()).collect::<Vec<_>>();
    by_first_shard.sort_by_key(|component| components[*component].shards.first().copied().unwrap_or(usize::MAX));
    // Group keys: previous gear numbers, and fresh keys above them for gears that did not exist.
    let mut fresh = anchors.max_gear().map_or(0, |max| max + 1);
    let mut key_of = vec![usize::MAX; components.len()];
    let mut last_key = None;
    for &component in &by_first_shard {
        let key = previous_gear(split, &keys, anchors, &components[component].shards)
            .or(last_key)
            .unwrap_or_else(|| {
                fresh += 1;
                fresh - 1
            });
        key_of[component] = key;
        last_key = Some(key);
    }
    // Group graph by component dependencies; merge strongly connected groups (Kosaraju, iterative).
    let group_keys = key_of.iter().copied().collect::<BTreeSet<_>>().into_iter().collect::<Vec<_>>();
    let index_of = group_keys.iter().enumerate().map(|(index, key)| (*key, index)).collect::<HashMap<_, _>>();
    let count = group_keys.len();
    let group = |component: usize| index_of[&key_of[component]];
    let mut forward = vec![BTreeSet::<usize>::new(); count];
    let mut backward = vec![BTreeSet::<usize>::new(); count];
    for (component, data) in components.iter().enumerate() {
        for dependency in &data.dependencies {
            let (provider, consumer) = (group(*dependency), group(component));
            if provider != consumer {
                forward[provider].insert(consumer);
                backward[consumer].insert(provider);
            }
        }
    }
    let mut visited = vec![false; count];
    let mut finish_order = Vec::with_capacity(count);
    for root in 0..count {
        if visited[root] {
            continue;
        }
        visited[root] = true;
        let mut stack = vec![(root, forward[root].iter().copied().collect::<Vec<_>>(), 0usize)];
        while let Some((node, edges, next)) = stack.last_mut() {
            if *next < edges.len() {
                let target = edges[*next];
                *next += 1;
                if !visited[target] {
                    visited[target] = true;
                    stack.push((target, forward[target].iter().copied().collect(), 0));
                }
            } else {
                finish_order.push(*node);
                stack.pop();
            }
        }
    }
    let mut merged = vec![usize::MAX; count];
    let mut merged_count = 0;
    for &root in finish_order.iter().rev() {
        if merged[root] != usize::MAX {
            continue;
        }
        merged[root] = merged_count;
        let mut stack = vec![root];
        while let Some(node) = stack.pop() {
            for &provider in &backward[node] {
                if merged[provider] == usize::MAX {
                    merged[provider] = merged_count;
                    stack.push(provider);
                }
            }
        }
        merged_count += 1;
    }
    if std::env::var("SPIRAL_GEAR_ANCHOR_DEBUG").as_deref() == Ok("1") {
        let mut sizes = BTreeMap::<usize, usize>::new();
        for scc in &merged {
            *sizes.entry(*scc).or_default() += 1;
        }
        let (largest, size) = sizes.iter().max_by_key(|(_, size)| **size).map_or((0, 0), |(scc, size)| (*scc, *size));
        eprintln!("[anchored_partition] groups {count} -> {merged_count}; largest merged cycle has {size} groups");
        if size > 1 {
            let mut shown = 0;
            for (component, data) in components.iter().enumerate() {
                for dependency in &data.dependencies {
                    let (provider, consumer) = (group(*dependency), group(component));
                    if provider != consumer && merged[provider] == largest && merged[consumer] == largest
                        && group_keys[provider] > group_keys[consumer] && shown < 12
                    {
                        shown += 1;
                        eprintln!(
                            "  backward edge: gear {} (shard {:?}) -> gear {} (shard {:?})",
                            group_keys[provider], components[*dependency].shards, group_keys[consumer], data.shards
                        );
                    }
                }
            }
        }
    }
    // Kosaraju numbers components in topological order (providers first) over the condensed graph.
    let mut result = vec![Vec::<usize>::new(); merged_count];
    for (component, data) in components.iter().enumerate() {
        result[merged[group(component)]].extend(data.shards.iter().copied());
    }
    for shards in &mut result {
        shards.sort_unstable();
    }
    result.retain(|shards| !shards.is_empty());
    result
}

/// Assigns each id its anchored number when that number is still free, in id order, and fresh numbers
/// above every previous one to the rest.
fn assign(anchored: &[Option<usize>], fresh_from: usize) -> Vec<usize> {
    let mut used = BTreeSet::new();
    let mut numbers = vec![usize::MAX; anchored.len()];
    for (id, anchor) in anchored.iter().enumerate() {
        if let Some(number) = anchor
            && used.insert(*number)
        {
            numbers[id] = *number;
        }
    }
    let mut fresh = fresh_from.max(used.iter().next_back().map_or(0, |max| max + 1));
    for number in &mut numbers {
        if *number == usize::MAX {
            *number = fresh;
            fresh += 1;
        }
    }
    numbers
}

/// Final part and gear numbers: the previous emission's where the anchors say so.
#[derive(Clone, Debug, Eq, PartialEq)]
pub struct StableNames {
    pub parts: Vec<usize>,
    pub gears: Vec<usize>,
}

impl StableNames {
    #[must_use]
    pub fn is_identity(&self) -> bool {
        self.parts.iter().enumerate().all(|(id, number)| id == *number)
            && self.gears.iter().enumerate().all(|(id, number)| id == *number)
    }
}

#[must_use]
pub fn stable_names(
    split: &SplitPlan,
    gears: &[crate::Gear],
    anchors: Option<&Anchors>,
) -> StableNames {
    let Some(anchors) = anchors else {
        return StableNames {
            parts: (0..split.shards.len()).collect(),
            gears: (0..gears.len()).collect(),
        };
    };
    let keys = declaration_keys(split);
    let part_anchors = split
        .shards
        .iter()
        .map(|shard| {
            majority(
                shard
                    .declarations
                    .iter()
                    .filter_map(|declaration| anchors.get(&keys[declaration.0]).map(|(part, _)| part)),
            )
        })
        .collect::<Vec<_>>();
    let gear_anchors = gears
        .iter()
        .map(|gear| previous_gear(split, &keys, anchors, &gear.shards))
        .collect::<Vec<_>>();
    StableNames {
        parts: assign(&part_anchors, anchors.max_part().map_or(0, |max| max + 1)),
        gears: assign(&gear_anchors, anchors.max_gear().map_or(0, |max| max + 1)),
    }
}

/// `anchors.tsv`: every declaration in source order with its final part and gear numbers.
#[must_use]
pub fn render_anchors(split: &SplitPlan, shard_to_gear: &[usize], names: &StableNames) -> String {
    let keys = declaration_keys(split);
    let mut shard_of = vec![usize::MAX; split.declarations.len()];
    for shard in &split.shards {
        for declaration in &shard.declarations {
            shard_of[declaration.0] = shard.id;
        }
    }
    let mut output = String::from("declaration\tpart\tgear\n");
    for (declaration, key) in keys.iter().enumerate() {
        let shard = shard_of[declaration];
        if shard == usize::MAX {
            continue;
        }
        let part = names.parts[shard];
        let gear = names.gears[shard_to_gear[shard]];
        output.push_str(&format!("{key}\t{part}\t{gear}\n"));
    }
    output
}

/// Project references are rendered in planning-id order, which renamed gears no longer follow; MSBuild
/// does not care about their order (F# `Compile` items are left alone), so sort each run by name to keep a
/// gear project byte-identical when its references are.
fn sort_project_references(text: &str) -> String {
    let lines = text.split_inclusive('\n').collect::<Vec<_>>();
    let is_reference = |line: &str| line.trim_start().starts_with("<ProjectReference ");
    let mut output = String::with_capacity(text.len());
    let mut index = 0;
    while index < lines.len() {
        if is_reference(lines[index]) {
            let end = (index..lines.len()).find(|at| !is_reference(lines[*at])).unwrap_or(lines.len());
            let mut run = lines[index..end].to_vec();
            run.sort_unstable();
            run.into_iter().for_each(|line| output.push_str(line));
            index = end;
        } else {
            output.push_str(lines[index]);
            index += 1;
        }
    }
    output
}

/// `PartNNNN`/`GearNNNN` (4 or more digits, not preceded by a digit) renumbered through `names`.
fn rename_numbers(text: &str, names: &StableNames) -> Result<String, String> {
    let mut output = String::with_capacity(text.len());
    let bytes = text.as_bytes();
    let mut index = 0;
    while index < bytes.len() {
        let rest = &text[index..];
        let prefix = if rest.starts_with("Part") {
            Some(("Part", &names.parts))
        } else if rest.starts_with("Gear") {
            Some(("Gear", &names.gears))
        } else {
            None
        };
        if let Some((word, table)) = prefix {
            let digits_start = index + word.len();
            let digits_end = text[digits_start..]
                .find(|character: char| !character.is_ascii_digit())
                .map_or(text.len(), |offset| digits_start + offset);
            let preceded_by_digit = index > 0 && bytes[index - 1].is_ascii_digit();
            if digits_end - digits_start >= 4 && !preceded_by_digit {
                let id: usize = text[digits_start..digits_end]
                    .parse()
                    .map_err(|error| format!("bad {word} number in emitted text: {error}"))?;
                let number = table
                    .get(id)
                    .ok_or_else(|| format!("{word}{id:04} is outside the plan ({} entries)", table.len()))?;
                output.push_str(&format!("{word}{number:04}"));
                index = digits_end;
                continue;
            }
        }
        let character = rest.chars().next().expect("non-empty remainder");
        output.push(character);
        index += character.len_utf8();
    }
    Ok(output)
}

/// Rewrites `PartNNNN`/`GearNNNN` in every emitted file (names and contents) to the stable numbers. All
/// new contents are computed before anything is written, so a number moving onto another's old name
/// cannot clobber it.
pub fn apply_stable_names(output_root: &Path, names: &StableNames) -> Result<usize, String> {
    if names.is_identity() {
        return Ok(0);
    }
    let rename = |text: &str| rename_numbers(text, names);
    let mut rewritten = Vec::new();
    let entries = fs::read_dir(output_root)
        .map_err(|error| format!("read {}: {error}", output_root.display()))?;
    for entry in entries {
        let entry = entry.map_err(|error| format!("read {}: {error}", output_root.display()))?;
        let path = entry.path();
        let Some(name) = path.file_name().and_then(|name| name.to_str()).map(str::to_owned) else {
            continue;
        };
        let text_file = [".fs", ".fsproj", ".proj", ".tsv"]
            .iter()
            .any(|extension| name.ends_with(extension));
        if !path.is_file() || !text_file || name == ANCHORS_FILE {
            continue;
        }
        let text = fs::read_to_string(&path).map_err(|error| format!("read {}: {error}", path.display()))?;
        let mut text = rename(&text)?;
        if name.ends_with(".fsproj") || name.ends_with(".proj") {
            text = sort_project_references(&text);
        }
        rewritten.push((path, rename(&name)?, text));
    }
    for (path, _, _) in &rewritten {
        fs::remove_file(path).map_err(|error| format!("remove {}: {error}", path.display()))?;
    }
    for (_, name, text) in &rewritten {
        fs::write(output_root.join(name), text)
            .map_err(|error| format!("write {name}: {error}"))?;
    }
    Ok(rewritten.len())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn majority_prefers_the_most_common_then_the_smallest() {
        assert_eq!(majority([3, 5, 5, 3, 3]), Some(3));
        assert_eq!(majority([7, 2]), Some(2));
        assert_eq!(majority([]), None);
    }

    #[test]
    fn assign_keeps_free_anchors_and_numbers_the_rest_above_every_previous_number() {
        // Ids 1 and 3 both claim 4: the first keeps it.
        assert_eq!(assign(&[Some(0), Some(4), None, Some(4)], 5), vec![0, 4, 5, 6]);
        assert_eq!(assign(&[None, None], 0), vec![0, 1]);
    }

    #[test]
    fn renames_parts_and_gears_but_not_other_words() {
        let names = StableNames { parts: vec![7, 3], gears: vec![2] };
        let text = "open spiral_compiler_Part0001\n<Compile Include=\"Part0000.fs\" /> SpiralCompilerGear0000 Partial GearRoot 12Part0000";
        assert_eq!(
            rename_numbers(text, &names).unwrap(),
            "open spiral_compiler_Part0003\n<Compile Include=\"Part0007.fs\" /> SpiralCompilerGear0002 Partial GearRoot 12Part0000"
        );
        assert!(rename_numbers("Part0009", &names).is_err());
    }

    #[test]
    fn sorts_only_project_reference_runs() {
        let text = "<Compile Include=\"B.fs\" />\n<Compile Include=\"A.fs\" />\n  <ProjectReference Include=\"Gear0009.fsproj\" />\n  <ProjectReference Include=\"Gear0002.fsproj\" />\n</ItemGroup>\n";
        assert_eq!(
            sort_project_references(text),
            "<Compile Include=\"B.fs\" />\n<Compile Include=\"A.fs\" />\n  <ProjectReference Include=\"Gear0002.fsproj\" />\n  <ProjectReference Include=\"Gear0009.fsproj\" />\n</ItemGroup>\n"
        );
    }

    #[test]
    fn parses_anchors_and_skips_the_header_and_bad_rows() {
        let anchors = Anchors::parse("declaration\tpart\tgear\nm\u{1f}h\u{1f}x\u{1f}0\t12\t3\nbad\trow\n");
        assert_eq!(anchors.get("m\u{1f}h\u{1f}x\u{1f}0"), Some((12, 3)));
        assert_eq!(anchors.max_part(), Some(12));
        assert_eq!(anchors.get("bad"), None);
    }
}
