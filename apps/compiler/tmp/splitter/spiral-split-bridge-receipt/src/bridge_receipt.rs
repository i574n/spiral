use spiral_split_gear_bridge::{BridgeAmbiguity, BridgeAnnotation, BridgeReport};
use std::collections::BTreeSet;
use std::fs;
use std::path::Path;

fn fields(text: &str) -> BTreeSet<String> {
    if text == "-" || text.is_empty() {
        BTreeSet::new()
    } else {
        text.split(',').map(str::to_owned).collect()
    }
}

pub fn read_bridge_tsv(path: &Path) -> Result<BridgeReport, String> {
    let text = fs::read_to_string(path)
        .map_err(|error| format!("read bridge receipt {}: {error}", path.display()))?;
    let mut report = BridgeReport::default();
    for line in text.lines().skip(1) {
        let columns = line.split_whitespace().collect::<Vec<_>>();
        match columns.first().copied() {
            Some("annotated") if columns.len() >= 6 => {
                report.annotations.push(BridgeAnnotation {
                    consumer_shard: columns[1]
                        .parse()
                        .map_err(|_| format!("invalid consumer shard: {line}"))?,
                    provider_shard: columns[2]
                        .parse()
                        .map_err(|_| format!("invalid provider shard: {line}"))?,
                    alias: columns[3].to_owned(),
                    fields: fields(columns[4]),
                    line: columns[5]
                        .parse()
                        .map_err(|_| format!("invalid bridge line: {line}"))?,
                });
            }
            Some("ambiguous") if columns.len() >= 6 => {
                report.ambiguities.push(BridgeAmbiguity {
                    consumer_shard: columns[1]
                        .parse()
                        .map_err(|_| format!("invalid consumer shard: {line}"))?,
                    aliases: columns[3].split(',').map(str::to_owned).collect(),
                    fields: fields(columns[4]),
                    line: columns[5]
                        .parse()
                        .map_err(|_| format!("invalid bridge line: {line}"))?,
                });
            }
            Some("summary") => {
                for value in columns.iter().skip(6) {
                    let Some((key, value)) = value.split_once('=') else {
                        continue;
                    };
                    let Ok(value) = value.parse::<usize>() else {
                        continue;
                    };
                    match key {
                        "aliases" => report.aliases = value,
                        "files_scanned" => report.files_scanned = value,
                        "files_changed" => report.files_changed = value,
                        "literals_seen" => report.literals_seen = value,
                        _ => {}
                    }
                }
            }
            Some("annotated" | "ambiguous") => {
                return Err(format!("malformed bridge receipt row: {line}"));
            }
            _ => {}
        }
    }
    Ok(report)
}

#[cfg(test)]
mod tests {
    use super::read_bridge_tsv;
    use std::fs;

    #[test]
    fn reloads_bridge_annotations_without_rewriting_sources() {
        let root =
            std::env::temp_dir().join(format!("spiral-bridge-receipt-{}", std::process::id()));
        fs::create_dir_all(&root).expect("root");
        let path = root.join("bridge.tsv");
        fs::write(&path, "status consumer_shard provider_shard alias fields line note\nannotated 3 1 Alias a,b 42 external-alias-type-annotation\nsummary - - - - - aliases=1 files_scanned=4 files_changed=1 literals_seen=2 annotations=1 ambiguities=0\n").expect("write");
        let report = read_bridge_tsv(&path).expect("receipt");
        assert_eq!(report.annotations.len(), 1);
        assert_eq!(report.annotations[0].consumer_shard, 3);
        assert_eq!(report.annotations[0].provider_shard, 1);
        assert_eq!(
            report.annotations[0]
                .fields
                .iter()
                .cloned()
                .collect::<Vec<_>>(),
            vec!["a", "b"]
        );
        assert_eq!(report.aliases, 1);
        assert_eq!(report.files_changed, 1);
        let _ = fs::remove_dir_all(root);
    }
}
