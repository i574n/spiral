#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn owner_growth_current(root: &std::path::Path) -> Result<std::collections::BTreeMap<String,u32>, String> { eoie_source_map::source_owner_rust_lines(root) }

type OwnerGrowthParsed = (String, std::collections::BTreeMap<String,u32>, std::collections::BTreeSet<String>);

fn owner_growth_parse(root: &std::path::Path) -> Result<OwnerGrowthParsed, String> {
    let path = root.join("state/owner_growth.spi");
    let source = std::fs::read_to_string(&path).map_err(|error| format!("read {}: {error}", path.display()))?;
    let mut predecessor = None::<String>;
    let mut baseline = std::collections::BTreeMap::new();
    let mut changes = std::collections::BTreeSet::new();
    for line in source.lines() {
        if line.contains("owner_growth_predecessor_sha256 () : string = \"") {
            let value = line.split('\"').nth(1).ok_or_else(|| format!("malformed predecessor sha row: {line}"))?;
            owner_growth_sha256_token(value, "predecessor sha256")?;
            if predecessor.replace(value.to_owned()).is_some() { return Err("duplicate owner growth predecessor sha256".to_owned()); }
        } else if line.contains("= OwnerBaseline (\"") {
            let parts = line.split('\"').collect::<Vec<_>>();
            if parts.len() < 3 { return Err(format!("malformed OwnerBaseline row: {line}")); }
            let owner = parts[1].to_owned();
            let tail = parts[2].split(',').nth(1).ok_or_else(|| format!("missing baseline lines: {line}"))?.trim().trim_end_matches(')').trim_end_matches("u32");
            let lines = tail.parse::<u32>().map_err(|_| format!("invalid baseline lines: {line}"))?;
            if baseline.insert(owner.clone(), lines).is_some() { return Err(format!("duplicate owner baseline: {owner}")); }
        } else if line.contains("= OwnerChange (\"") {
            let parts = line.split('\"').collect::<Vec<_>>();
            if parts.len() < 7 || parts[3].is_empty() || parts[5].is_empty() { return Err(format!("malformed OwnerChange row: {line}")); }
            if !changes.insert(parts[1].to_owned()) { return Err(format!("duplicate owner change receipt: {}", parts[1])); }
        }
    }
    let predecessor = predecessor.ok_or_else(|| "owner growth predecessor sha256 is missing".to_owned())?;
    if baseline.is_empty() { return Err("owner growth baseline is empty".to_owned()); }
    Ok((predecessor, baseline, changes))
}

fn owner_growth_token(value: &str, label: &str) -> Result<(), String> {
    if value.is_empty() || value.bytes().any(|b| b == b'\"' || b == b'\n' || b == b'\r' || b == b'\t') { return Err(format!("owner growth {label} must be a non-empty single-line token without quotes or tabs")); }
    Ok(())
}

fn owner_growth_sha256_token(value: &str, label: &str) -> Result<(), String> {
    owner_growth_token(value, label)?;
    if value.len() != 64 || !value.bytes().all(|byte| byte.is_ascii_hexdigit()) { return Err(format!("owner growth {label} must be a sixty-four-character hex SHA-256")); }
    Ok(())
}

fn owner_growth_changed(baseline: &std::collections::BTreeMap<String,u32>, current: &std::collections::BTreeMap<String,u32>) -> std::collections::BTreeSet<String> {
    baseline.keys().chain(current.keys()).filter(|owner| baseline.get(*owner).copied().unwrap_or(0) != current.get(*owner).copied().unwrap_or(0)).cloned().collect()
}

fn owner_growth_render(predecessor_sha256: &str, baseline: &std::collections::BTreeMap<String,u32>, changed: &std::collections::BTreeSet<String>, reason: &str, reference: &str) -> String {
    let mut out = format!("union owner_growth_entry =\n    | OwnerBaseline : string * u32\n    | OwnerChange : string * string * string\n\ninl owner_growth_policy_version () : u32 = 4u32\ninl owner_growth_predecessor_sha256 () : string = \"{predecessor_sha256}\"\n");
    for (index,(owner,lines)) in baseline.iter().enumerate() { out.push_str(&format!("inl owner_growth_baseline_{index:03} () : owner_growth_entry = OwnerBaseline (\"{owner}\", {lines}u32)\n")); }
    if !changed.is_empty() { out.push('\n'); }
    for (index,owner) in changed.iter().enumerate() { out.push_str(&format!("inl owner_growth_change_{index:03} () : owner_growth_entry = OwnerChange (\"{owner}\", \"{reason}\", \"{reference}\")\n")); }
    out.push_str("\ninl main () : i32 = 0i32\n");
    out
}

fn owner_growth_write(root: &std::path::Path, text: &str) -> Result<(), String> {
    let path = root.join("state/owner_growth.spi");
    let tmp = root.join("state/owner_growth.spi.tmp");
    std::fs::write(&tmp, text).map_err(|error| format!("write {}: {error}", tmp.display()))?;
    std::fs::rename(&tmp, &path).map_err(|error| format!("rename {} -> {}: {error}", tmp.display(), path.display()))
}

fn owner_growth_predecessor_proof(predecessor_archive: &std::path::Path, previous: &std::path::Path) -> Result<String, String> {
    let _ = eoie_bundle_manifest::verify_generic_flat_zip(predecessor_archive, 30_000_000)?;
    let manifest = eoie_bundle_manifest::collect_bundle_manifest(previous)?;
    let stage = std::env::temp_dir().join(format!("eoie-owner-growth-predecessor-{}.zip", std::process::id()));
    let _ = std::fs::remove_file(&stage);
    let result = (|| -> Result<String, String> {
        eoie_bundle_manifest::write_deterministic_deflate_zip(previous, &stage, &manifest)?;
        let expected = eoie_proxy_search::inspection_file_sha256(predecessor_archive)?;
        let observed = eoie_proxy_search::inspection_file_sha256(&stage)?;
        owner_growth_sha256_token(&expected, "predecessor sha256")?;
        if expected != observed { return Err(format!("owner growth predecessor archive/root mismatch expected={expected} observed={observed}")); }
        Ok(expected)
    })();
    let _ = std::fs::remove_file(&stage);
    result
}

pub fn owner_growth_seed(predecessor_archive: &std::path::Path, previous: &std::path::Path, root: &std::path::Path) -> Result<(), String> {
    let predecessor_sha256 = owner_growth_predecessor_proof(predecessor_archive, previous)?;
    let baseline = owner_growth_current(previous)?;
    owner_growth_write(root, &owner_growth_render(&predecessor_sha256, &baseline, &std::collections::BTreeSet::new(), "seed", "OWNER-GROWTH-TELEMETRY"))?;
    println!("eoie bundle growth-baseline ok owners={} predecessor_sha256={} previous={} root={}", baseline.len(), predecessor_sha256, previous.display(), root.display());
    Ok(())
}

pub fn owner_growth_author(root: &std::path::Path, reason: &str, reference: &str) -> Result<(), String> {
    owner_growth_token(reason, "reason")?; owner_growth_token(reference, "reference")?;
    let (predecessor_sha256, baseline, _) = owner_growth_parse(root)?;
    let current = owner_growth_current(root)?;
    let changed = owner_growth_changed(&baseline, &current);
    owner_growth_write(root, &owner_growth_render(&predecessor_sha256, &baseline, &changed, reason, reference))?;
    println!("eoie bundle growth-receipt ok changed={} reason={} reference={}", changed.len(), reason, reference);
    Ok(())
}

#[rustfmt::skip]
pub fn owner_growth_all_owner_check(root: &std::path::Path) -> Result<(), String> {
    let (predecessor_sha256, baseline, receipts) = owner_growth_parse(root)?; let current = owner_growth_current(root)?; let changed = owner_growth_changed(&baseline, &current);
    if changed != receipts {
        let missing = changed.difference(&receipts).cloned().collect::<Vec<_>>(); let stale = receipts.difference(&changed).cloned().collect::<Vec<_>>();
        return Err(format!("owner growth receipt coverage mismatch missing={missing:?} stale={stale:?}"));
    }
    let mut growth = 0u32; let mut shrink = 0u32;
    let owners = baseline.keys().chain(current.keys()).cloned().collect::<std::collections::BTreeSet<_>>();
    for owner in owners {
        let before = baseline.get(&owner).copied().unwrap_or(0); let after = current.get(&owner).copied().unwrap_or(0);
        if after > before { growth = growth.saturating_add(after - before); } else { shrink = shrink.saturating_add(before - after); }
    }
    let compensated = eoie_bundle_owner_growth_compensation_binding(i32::try_from(growth).unwrap_or(i32::MAX), i32::try_from(shrink).unwrap_or(i32::MAX));
    println!("owner_growth_owners={} owner_growth_changed={} owner_growth_rust_growth={} owner_growth_rust_shrink={} owner_growth_compensated={} owner_growth_predecessor_sha256={} owner_growth_net_policy=report-only", current.len(), changed.len(), growth, shrink, compensated, predecessor_sha256);
    Ok(())
}

fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < v0;
        if v3 {
            0i32
        } else {
            1i32
        }
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    method1(v0, v1)
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
pub fn eoie_bundle_owner_growth_compensation_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
