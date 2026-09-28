#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_patch_control_domain::{patch_quoted_fields, patch_safe_relative};
use eoie_proxy_search::{inspection_file_sha256, inspection_sha256, inspection_tree_sha256};
use eoie_rust_std_fs::atomic_write;
use std::collections::BTreeSet;
use std::env;
use std::fs;
use std::path::Path;

#[derive(Clone, Debug)]
pub struct EvidenceCurrentnessSummary { pub declared: usize, pub observed: usize, pub verified: usize }

#[derive(Clone, Debug)]
struct EvidenceSpec { relative: String, sha256: String, bytes: u64 }

#[derive(Clone, Debug)]
enum EvidenceTreePolicy { Exact, StateWithoutMetaManifests }

#[derive(Clone, Debug)]
struct EvidenceTreeSpec { relative: String, sha256: String, policy: EvidenceTreePolicy }

fn evidence_parse_tree_specs(source: &str) -> Result<Vec<EvidenceTreeSpec>, String> {
    let mut specs = Vec::new();
    let mut seen = BTreeSet::new();
    for (number, line) in source.lines().enumerate() {
        if !line.contains("EvidenceTreeRef (") { continue; }
        let fields = patch_quoted_fields(line)?;
        if fields.len() != 2 { return Err(format!("EvidenceTreeRef on line {} expects path and sha256 strings", number + 1)); }
        let relative = patch_safe_relative(&fields[0])?;
        let relative_text = relative.to_string_lossy().replace('\\', "/");
        if !seen.insert(relative_text.clone()) { return Err(format!("duplicate EvidenceTreeRef path: {relative_text}")); }
        let sha256 = fields[1].to_ascii_lowercase();
        if sha256.len() != 64 || !sha256.bytes().all(|byte| byte.is_ascii_hexdigit()) { return Err(format!("EvidenceTreeRef sha256 is malformed on line {}", number + 1)); }
        let policy = if line.contains("StateTreeWithoutMetaManifests") {
            if relative_text != "state" { return Err("StateTreeWithoutMetaManifests is valid only for state".to_owned()); }
            EvidenceTreePolicy::StateWithoutMetaManifests
        } else if line.contains("ExactTree") { EvidenceTreePolicy::Exact } else { return Err(format!("EvidenceTreeRef policy missing on line {}", number + 1)); };
        specs.push(EvidenceTreeSpec { relative: relative_text, sha256, policy });
    }
    Ok(specs)
}

fn evidence_tree_relative(root: &Path, path: &Path) -> Result<String, String> {
    let relative = path.strip_prefix(root).map_err(|_| format!("tree path escaped root: {}", path.display()))?;
    Ok(relative.components().map(|component| component.as_os_str().to_string_lossy().into_owned()).collect::<Vec<_>>().join("/"))
}

fn evidence_tree_collect_filtered(root: &Path, path: &Path, excluded_a: &Path, excluded_b: &Path, manifest: &mut Vec<String>, total: &mut u64, limit: u64) -> Result<(), String> {
    if path == excluded_a || path == excluded_b { return Ok(()); }
    let metadata = fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("tree hash refuses symlink: {}", path.display())); }
    let relative = evidence_tree_relative(root, path)?;
    if metadata.is_dir() {
        manifest.push(format!("d\t{relative}"));
        let mut children = fs::read_dir(path).map_err(|error| format!("read {}: {error}", path.display()))?.map(|entry| entry.map(|entry| entry.path()).map_err(|error| error.to_string())).collect::<Result<Vec<_>, _>>()?;
        children.sort();
        for child in children { evidence_tree_collect_filtered(root, &child, excluded_a, excluded_b, manifest, total, limit)?; }
    } else if metadata.is_file() {
        *total = total.checked_add(metadata.len()).ok_or_else(|| "tree byte count overflow".to_owned())?;
        if *total > limit { return Err(format!("tree hash input exceeds limit: bytes={} limit={limit}", *total)); }
        manifest.push(format!("f\t{relative}\t{}\t{}", metadata.len(), inspection_file_sha256(path)?));
    } else { return Err(format!("unsupported tree entry: {}", path.display())); }
    Ok(())
}

pub fn evidence_state_tree_sha256(root: &Path) -> Result<String, String> {
    let path = root.join("state");
    let excluded_evidence = root.join("state/evidence.spi");
    let excluded_attestation = root.join("state/typecheck_receipts.spi");
    let limit = env::var("EOIE_TREE_HASH_LIMIT_BYTES").ok().and_then(|value| value.parse::<u64>().ok()).unwrap_or(1024 * 1024 * 1024);
    let mut manifest = Vec::new();
    let mut total = 0u64;
    evidence_tree_collect_filtered(root, &path, &excluded_evidence, &excluded_attestation, &mut manifest, &mut total, limit)?;
    manifest.sort();
    Ok(inspection_sha256(manifest.join("\n").into_bytes()))
}

pub fn refresh_release_closeout_evidence(root: &Path, closeout_sha256: &str, closeout_bytes: u64) -> Result<i32, String> {
    if closeout_sha256.len() != 64 || !closeout_sha256.bytes().all(|byte| byte.is_ascii_hexdigit()) { return Err("closeout evidence sha256 is malformed".to_owned()); }
    let manifest_path = root.join("state/evidence.spi");
    let original = fs::read_to_string(&manifest_path).map_err(|error| format!("read {}: {error}", manifest_path.display()))?;
    let state_sha256 = evidence_state_tree_sha256(root)?;
    let cold_proof_path = root.join("state/cold_proof.spi");
    let cold_proof_metadata = fs::symlink_metadata(&cold_proof_path).map_err(|error| format!("metadata {}: {error}", cold_proof_path.display()))?;
    if !cold_proof_metadata.is_file() || cold_proof_metadata.file_type().is_symlink() { return Err("cold proof evidence target must be a regular file".to_owned()); }
    let cold_proof_sha256 = inspection_file_sha256(&cold_proof_path)?;
    let cold_proof_bytes = cold_proof_metadata.len();
    let cargo_lock_path = root.join("src/Cargo.lock");
    let cargo_lock_metadata = fs::symlink_metadata(&cargo_lock_path).map_err(|error| format!("metadata {}: {error}", cargo_lock_path.display()))?;
    if !cargo_lock_metadata.is_file() || cargo_lock_metadata.file_type().is_symlink() { return Err("Cargo.lock evidence target must be a regular file".to_owned()); }
    let cargo_lock_sha256 = inspection_file_sha256(&cargo_lock_path)?;
    let cargo_lock_bytes = cargo_lock_metadata.len();
    let eoie_path = root.join("eoie");
    let eoie_metadata = fs::symlink_metadata(&eoie_path).map_err(|error| format!("metadata {}: {error}", eoie_path.display()))?;
    if !eoie_metadata.is_file() || eoie_metadata.file_type().is_symlink() { return Err("EOIE binary evidence target must be a regular file".to_owned()); }
    let eoie_sha256 = inspection_file_sha256(&eoie_path)?;
    let eoie_bytes = eoie_metadata.len();
    let source_sha256 = inspection_tree_sha256(root, "src")?;
    let mut release_hits = 0usize;
    let mut cold_hits = 0usize;
    let mut cargo_hits = 0usize;
    let mut binary_hits = 0usize;
    let mut source_hits = 0usize;
    let mut state_hits = 0usize;
    let mut output = Vec::new();
    for line in original.lines() {
        let mut updated = line.to_owned();
        if line.contains("EvidenceRef (") {
            let fields = patch_quoted_fields(line)?;
            if fields.len() == 2 && fields[0] == "state/release_closeout.spi" {
                release_hits += 1;
                updated = updated.replacen(&fields[1], closeout_sha256, 1);
                let old_bytes = evidence_parse_u64(line)?;
                updated = updated.replacen(&format!("{old_bytes}u64"), &format!("{closeout_bytes}u64"), 1);
            }
            if fields.len() == 2 && fields[0] == "state/cold_proof.spi" {
                cold_hits += 1;
                updated = updated.replacen(&fields[1], &cold_proof_sha256, 1);
                let old_bytes = evidence_parse_u64(line)?;
                updated = updated.replacen(&format!("{old_bytes}u64"), &format!("{cold_proof_bytes}u64"), 1);
            }
            if fields.len() == 2 && fields[0] == "src/Cargo.lock" {
                cargo_hits += 1;
                updated = updated.replacen(&fields[1], &cargo_lock_sha256, 1);
                let old_bytes = evidence_parse_u64(line)?;
                updated = updated.replacen(&format!("{old_bytes}u64"), &format!("{cargo_lock_bytes}u64"), 1);
            }
            if fields.len() == 2 && fields[0] == "eoie" {
                binary_hits += 1;
                updated = updated.replacen(&fields[1], &eoie_sha256, 1);
                let old_bytes = evidence_parse_u64(line)?;
                updated = updated.replacen(&format!("{old_bytes}u64"), &format!("{eoie_bytes}u64"), 1);
            }
        }
        if line.contains("EvidenceTreeRef (") && line.contains("ExactTree") {
            let fields = patch_quoted_fields(line)?;
            if fields.len() == 2 && fields[0] == "src" {
                source_hits += 1;
                updated = updated.replacen(&fields[1], &source_sha256, 1);
            }
        }
        if line.contains("EvidenceTreeRef (") && line.contains("StateTreeWithoutMetaManifests") {
            let fields = patch_quoted_fields(line)?;
            if fields.len() == 2 && fields[0] == "state" {
                state_hits += 1;
                updated = updated.replacen(&fields[1], &state_sha256, 1);
            }
        }
        output.push(updated);
    }
    if release_hits == 0 && cold_hits == 0 && cargo_hits == 0 && binary_hits == 0 && source_hits == 0 && state_hits == 0 { let summary = check_evidence_tree(root)?; return if summary.declared == summary.verified { Ok(127) } else { Err(format!("closeout evidence currentness incomplete declared={} verified={}", summary.declared, summary.verified)) }; }
    if release_hits != 1 || cold_hits != 1 || cargo_hits != 1 || binary_hits != 1 || source_hits != 1 || state_hits != 1 { return Err(format!("closeout evidence anchors rejected release_hits={release_hits} cold_hits={cold_hits} cargo_hits={cargo_hits} binary_hits={binary_hits} source_hits={source_hits} state_hits={state_hits}")); }
    let next = output.join("\n") + "\n";
    atomic_write(&manifest_path, next.as_bytes())?;
    match check_evidence_tree(root) {
        Ok(summary) if summary.declared == summary.verified => Ok(127),
        Ok(summary) => { let _ = atomic_write(&manifest_path, original.as_bytes()); Err(format!("closeout evidence refresh incomplete declared={} verified={}", summary.declared, summary.verified)) },
        Err(error) => { let _ = atomic_write(&manifest_path, original.as_bytes()); Err(format!("closeout evidence refresh rolled back: {error}")) },
    }
}

fn evidence_parse_u64(line: &str) -> Result<u64, String> {
    let marker = line.find("u64").ok_or_else(|| "EvidenceRef bytes must use u64".to_owned())?;
    let prefix = &line[..marker];
    let digits_rev = prefix.chars().rev().skip_while(|c| c.is_whitespace()).take_while(|c| c.is_ascii_digit()).collect::<String>();
    if digits_rev.is_empty() { return Err("EvidenceRef bytes are missing".to_owned()); }
    digits_rev.chars().rev().collect::<String>().parse::<u64>().map_err(|_| "EvidenceRef bytes are invalid".to_owned())
}

fn evidence_parse_specs(source: &str) -> Result<Vec<EvidenceSpec>, String> {
    let mut specs = Vec::new();
    let mut seen = BTreeSet::new();
    for (number, line) in source.lines().enumerate() {
        if !line.contains("EvidenceRef (") { continue; }
        let fields = patch_quoted_fields(line)?;
        if fields.len() != 2 { return Err(format!("EvidenceRef on line {} expects path and sha256 strings", number + 1)); }
        let relative = patch_safe_relative(&fields[0])?;
        if relative == Path::new("state/evidence.spi") { return Err(format!("EvidenceRef escaped evidence root on line {}: {}", number + 1, fields[0])); }
        let relative_text = relative.to_string_lossy().replace('\\', "/");
        if !seen.insert(relative_text.clone()) { return Err(format!("duplicate EvidenceRef path: {relative_text}")); }
        let sha256 = fields[1].to_ascii_lowercase();
        if sha256.len() != 64 || !sha256.bytes().all(|byte| byte.is_ascii_hexdigit()) { return Err(format!("EvidenceRef sha256 is malformed on line {}", number + 1)); }
        specs.push(EvidenceSpec { relative: relative_text, sha256, bytes: evidence_parse_u64(line)? });
    }
    if specs.is_empty() { return Err("state/evidence.spi contains no EvidenceRef rows".to_owned()); }
    Ok(specs)
}

fn evidence_collect_files(bundle_root: &Path, current: &Path, out: &mut BTreeSet<String>) -> Result<(), String> {
    for entry in fs::read_dir(current).map_err(|error| format!("read evidence tree {}: {error}", current.display()))? {
        let entry = entry.map_err(|error| error.to_string())?;
        let path = entry.path();
        let metadata = fs::symlink_metadata(&path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
        if metadata.file_type().is_symlink() { return Err(format!("evidence symlink is forbidden: {}", path.display())); }
        if metadata.is_dir() { evidence_collect_files(bundle_root, &path, out)?; continue; }
        if !metadata.is_file() { return Err(format!("unsupported evidence entry: {}", path.display())); }
        let relative = path.strip_prefix(bundle_root).map_err(|error| error.to_string())?.to_string_lossy().replace('\\', "/");
        out.insert(relative);
    }
    Ok(())
}

pub fn check_evidence_tree(root: &Path) -> Result<EvidenceCurrentnessSummary, String> {
    if !root.is_dir() { return Err(format!("bundle root is not a directory: {}", root.display())); }
    let evidence_root = root.join("evidence");
    if !evidence_root.is_dir() { return Err("missing evidence root".to_owned()); }
    let manifest_path = root.join("state/evidence.spi");
    let source = fs::read_to_string(&manifest_path).map_err(|error| format!("read {}: {error}", manifest_path.display()))?;
    let specs = evidence_parse_specs(&source)?;
    let tree_specs = evidence_parse_tree_specs(&source)?;
    let declared_evidence = specs.iter().filter(|spec| spec.relative.starts_with("evidence/")).map(|spec| spec.relative.clone()).collect::<BTreeSet<_>>();
    let mut observed = BTreeSet::new();
    evidence_collect_files(root, &evidence_root, &mut observed)?;
    let missing = declared_evidence.difference(&observed).cloned().collect::<Vec<_>>();
    let unexpected = observed.difference(&declared_evidence).cloned().collect::<Vec<_>>();
    if !missing.is_empty() || !unexpected.is_empty() { return Err(format!("evidence closure mismatch missing={missing:?} unexpected={unexpected:?}")); }
    let mut verified = 0usize;
    let mut observed_specs = 0usize;
    for spec in &specs {
        let path = root.join(&spec.relative);
        let metadata = fs::symlink_metadata(&path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
        let regular = metadata.is_file() && !metadata.file_type().is_symlink();
        let bytes_match = regular && metadata.len() == spec.bytes;
        let observed_sha = if regular { inspection_file_sha256(&path)? } else { String::new() };
        let sha_match = observed_sha == spec.sha256;
        if regular { observed_specs += 1; }
        let in_scope = path.starts_with(root) && spec.relative != "state/evidence.spi";
        let mask = i32::from(in_scope) + 2 * i32::from(regular) + 4 * i32::from(bytes_match) + 8 * i32::from(sha_match);
        if mask != 15 {
            return Err(format!("evidence identity mismatch path={} expected_bytes={} observed_bytes={} expected_sha256={} observed_sha256={} mask={}", path.display(), spec.bytes, metadata.len(), spec.sha256, observed_sha, mask));
        }
        verified += 1;
    }
    let mut tree_verified = 0usize;
    for spec in &tree_specs {
        let observed_sha = match spec.policy {
            EvidenceTreePolicy::Exact => inspection_tree_sha256(root, &spec.relative)?,
            EvidenceTreePolicy::StateWithoutMetaManifests => evidence_state_tree_sha256(root)?,
        };
        if observed_sha != spec.sha256 { return Err(format!("evidence tree identity mismatch path={} expected_sha256={} observed_sha256={}", spec.relative, spec.sha256, observed_sha)); }
        tree_verified += 1;
    }
    if specs.len() != verified { return Err(format!("typed evidence file set rejected declared={} verified={}", specs.len(), verified)); }
    if tree_specs.len() != tree_verified { return Err(format!("typed evidence tree set rejected declared={} verified={}", tree_specs.len(), tree_verified)); }
    Ok(EvidenceCurrentnessSummary { declared: specs.len() + tree_specs.len(), observed: observed_specs + tree_verified, verified: verified + tree_verified })
}

pub fn evidence_status(root: &Path) -> Result<EvidenceCurrentnessSummary, String> { check_evidence_tree(root) }

#[derive(Clone, Debug)]
pub struct ToolchainCurrentnessSummary { pub declared: usize, pub observed: usize, pub verified: usize }

fn toolchain_env_name(relative: &str) -> Option<&'static str> {
    match relative { "rustc" => Some("RUSTC"), "cargo" => Some("CARGO"), "rustdoc" => Some("RUSTDOC"), "rustfmt" => Some("RUSTFMT"), _ => None }
}

pub fn toolchain_status(root: &Path) -> Result<Option<ToolchainCurrentnessSummary>, String> {
    let state = root.join("state/toolchain_identity.spi");
    let source = fs::read_to_string(&state).map_err(|error| format!("read {}: {error}", state.display()))?;
    let specs = evidence_parse_specs(&source)?;
    let provided = specs.iter().filter(|spec| toolchain_env_name(&spec.relative).and_then(env::var_os).is_some()).count();
    if provided == 0 { return Ok(None); }
    if provided != specs.len() { return Err(format!("partial Rust toolchain environment observed={provided} declared={}", specs.len())); }
    let mut observed = 0usize;
    let mut verified = 0usize;
    for spec in &specs {
        let env_name = toolchain_env_name(&spec.relative).ok_or_else(|| format!("unknown Rust tool identity: {}", spec.relative))?;
        let value = env::var_os(env_name).ok_or_else(|| format!("missing Rust tool environment: {env_name}"))?;
        let path = Path::new(&value);
        if !path.is_absolute() { return Err(format!("Rust tool path must be absolute: {env_name}")); }
        let metadata = fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
        let regular = metadata.is_file() && !metadata.file_type().is_symlink();
        if regular { observed += 1; }
        let bytes_match = regular && metadata.len() == spec.bytes;
        let sha256 = if regular { inspection_file_sha256(path)? } else { String::new() };
        if !regular || !bytes_match || sha256 != spec.sha256 { return Err(format!("Rust tool identity mismatch tool={} expected_bytes={} observed_bytes={} expected_sha256={} observed_sha256={}", spec.relative, spec.bytes, metadata.len(), spec.sha256, sha256)); }
        verified += 1;
    }
    Ok(Some(ToolchainCurrentnessSummary { declared: specs.len(), observed, verified }))
}

fn spiral_main() -> i32 {
    0i32
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
