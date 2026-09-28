#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_rust_std_fs::{copy_regular_atomic_preserve, read_regular_limited, read_regular_text_limited, rooted_path};
use rayon::prelude::*;
use std::fs;
use std::path::{Path, PathBuf};

fn inspection_arg<'a>(args: &'a [String], index: usize, name: &str) -> Result<&'a str, String> {
    args.get(index).map(String::as_str).ok_or_else(|| format!("missing argument: {name}"))
}

fn inspection_text_limit() -> usize {
    std::env::var("EOIE_INSPECTION_TEXT_LIMIT_BYTES").ok().and_then(|value| value.parse().ok()).unwrap_or(16 * 1024 * 1024)
}

fn inspection_slice_lines(source: &str, start: usize, count: usize) -> Vec<String> {
    source.lines().enumerate().skip(start.saturating_sub(1)).take(count).map(|(index, line)| format!("{}\t{}", index + 1, line)).collect()
}

fn inspection_slice(args: &[String]) -> Result<(), String> {
    if args.len() != 5 { return Err("fs-slice expects root, relative, start, count".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let path = rooted_path(root, inspection_arg(args, 2, "relative")?)?;
    let start = inspection_arg(args, 3, "start")?.parse::<usize>().map_err(|_| "invalid start".to_owned())?;
    let count = inspection_arg(args, 4, "count")?.parse::<usize>().map_err(|_| "invalid count".to_owned())?;
    let source = read_regular_text_limited(&path, inspection_text_limit())?;
    for line in inspection_slice_lines(&source, start, count) { println!("{line}"); }
    Ok(())
}

fn inspection_context(args: &[String]) -> Result<(), String> {
    if args.len() != 5 { return Err("fs-context expects root, relative, needle, radius-bytes".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let path = rooted_path(root, inspection_arg(args, 2, "relative")?)?;
    let needle = inspection_arg(args, 3, "needle")?.as_bytes();
    if needle.is_empty() { return Err("needle must not be empty".to_owned()); }
    let radius = inspection_arg(args, 4, "radius-bytes")?.parse::<usize>().map_err(|_| "invalid radius-bytes".to_owned())?;
    let source = read_regular_limited(&path, inspection_text_limit())?;
    let position = source.windows(needle.len()).position(|window| window == needle).ok_or_else(|| "needle not found".to_owned())?;
    let from = position.saturating_sub(radius);
    let to = source.len().min(position + needle.len() + radius);
    println!("{}", String::from_utf8_lossy(&source[from..to]));
    Ok(())
}

fn inspection_collect(root: &Path, path: &Path, needle: &str, limit: usize, parallel: bool, tagged: bool) -> Result<Vec<String>, String> {
    let metadata = fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("refusing symlink: {}", path.display())); }
    if metadata.is_dir() {
        let mut children = fs::read_dir(path).map_err(|error| format!("read {}: {error}", path.display()))?.map(|entry| entry.map(|entry| entry.path()).map_err(|error| error.to_string())).collect::<Result<Vec<_>, _>>()?;
        children.sort();
        let nested = if parallel { children.par_iter().map(|child| inspection_collect(root, child, needle, limit, true, tagged)).collect::<Vec<_>>() } else { children.iter().map(|child| inspection_collect(root, child, needle, limit, false, tagged)).collect::<Vec<_>>() };
        let mut hits = Vec::new();
        for result in nested { hits.extend(result?); if hits.len() > limit { return Err(format!("search hit limit exceeded: {limit}")); } }
        hits.sort();
        Ok(hits)
    } else if metadata.is_file() {
        let Ok(source) = read_regular_text_limited(path, inspection_text_limit()) else { return Ok(Vec::new()); };
        let mut hits = Vec::new();
        let relative = path.strip_prefix(root).map_err(|_| format!("search path escaped root: {}", path.display()))?.components().map(|component| component.as_os_str().to_string_lossy().into_owned()).collect::<Vec<_>>().join("/"); let tag = if tagged { mnemonic_path_tag(&relative)? } else { String::new() }; for (index, line) in source.lines().enumerate() { if line.contains(needle) { if tagged { hits.push(format!("{tag}\t{relative}:{}:{}", index + 1, line)); } else { hits.push(format!("{}:{}:{}", path.display(), index + 1, line)); } } }
        if hits.len() > limit { return Err(format!("search hit limit exceeded: {limit}")); }
        Ok(hits)
    } else { Ok(Vec::new()) }
}

fn inspection_search(args: &[String]) -> Result<(), String> {
    if args.len() != 4 { return Err("fs-search expects root, relative, needle".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let path = rooted_path(root, inspection_arg(args, 2, "relative")?)?;
    let limit = std::env::var("EOIE_SEARCH_MAX_HITS").ok().and_then(|value| value.parse().ok()).unwrap_or(20_000usize);
    for hit in inspection_collect(root, &path, inspection_arg(args, 3, "needle")?, limit, true, false)? { println!("{hit}"); }
    Ok(())
}

fn inspection_parallel_search(args: &[String]) -> Result<(), String> {
    if args.len() != 5 { return Err("parallel-search expects root, relative, needle, max-hits".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let relative = inspection_arg(args, 2, "relative")?;
    let path = rooted_path(root, relative)?;
    let needle = inspection_arg(args, 3, "needle")?;
    if needle.is_empty() { return Err("needle must not be empty".to_owned()); }
    let limit = inspection_arg(args, 4, "max-hits")?.parse::<usize>().map_err(|_| "invalid max-hits".to_owned())?;
    let workers = std::env::var("EOIE_PARALLEL_WORKERS").ok().and_then(|value| value.parse::<usize>().ok()).unwrap_or(56);
    if eoie_proxy_search_proxy_parallel_search_request_binding(0, limit as i32) != 1 || eoie_proxy_search_proxy_parallel_search_worker_binding(workers as i32, 56) != 1 { return Err("typed parallel-search request rejected".to_owned()); }
    let serial = inspection_collect(root, &path, needle, limit, false, true)?;
    let pool = rayon::ThreadPoolBuilder::new().num_threads(workers).build().map_err(|error| format!("build Rayon pool: {error}"))?;
    let parallel = pool.install(|| inspection_collect(root, &path, needle, limit, true, true))?;
    if eoie_proxy_search_proxy_parallel_search_parity_binding(serial.len() as i32, parallel.len() as i32) != 1 || serial != parallel { return Err("serial and parallel search results diverged".to_owned()); }
    for hit in &parallel { println!("{hit}"); }
    println!("eoie proxy parallel-search ok workers={workers} hits={} parity=exact ordering=deterministic", parallel.len());
    Ok(())
}

pub fn manifest_collect(root: &Path, path: &Path, limit: usize, parallel: bool) -> Result<Vec<String>, String> {
    let metadata = fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("manifest refuses symlink: {}", path.display())); }
    let relative = path.strip_prefix(root).map_err(|_| format!("manifest path escaped root: {}", path.display()))?.components().map(|component| component.as_os_str().to_string_lossy().into_owned()).collect::<Vec<_>>().join("/");
    let tag_path = if relative.is_empty() { "root" } else { relative.as_str() };
    let tag = mnemonic_path_tag(tag_path)?;
    if metadata.is_dir() {
        let mut children = fs::read_dir(path).map_err(|error| format!("read {}: {error}", path.display()))?.map(|entry| entry.map(|entry| entry.path()).map_err(|error| error.to_string())).collect::<Result<Vec<_>, _>>()?;
        children.sort();
        let nested = if parallel { children.par_iter().map(|child| manifest_collect(root, child, limit, true)).collect::<Vec<_>>() } else { children.iter().map(|child| manifest_collect(root, child, limit, false)).collect::<Vec<_>>() };
        let mut entries = vec![format!("d\t{tag}\t{relative}")];
        for result in nested { entries.extend(result?); if entries.len() > limit { return Err(format!("manifest entry limit exceeded: {limit}")); } }
        entries.sort();
        Ok(entries)
    } else if metadata.is_file() {
        Ok(vec![format!("f\t{tag}\t{relative}\t{}\t{}", metadata.len(), inspection_file_sha256(path)?)])
    } else { Err(format!("unsupported manifest entry: {}", path.display())) }
}

fn inspection_consumer_write(path:&Path,bytes:&[u8])->Result<(),String>{let parent=path.parent().ok_or_else(||format!("consumer output has no parent: {}",path.display()))?;fs::create_dir_all(parent).map_err(|error|format!("create {}: {error}",parent.display()))?;let previous=fs::read(path).ok();let stage=parent.join(format!(".parallel-consumer-{}",std::process::id()));fs::write(&stage,bytes).map_err(|error|format!("write {}: {error}",stage.display()))?;fs::rename(&stage,path).map_err(|error|format!("commit {}: {error}",path.display()))?;if std::env::var("EOIE_PARALLEL_CONSUMER_FAULT").ok().as_deref()==Some("after-write"){match previous{Some(value)=>fs::write(path,value).map_err(|error|format!("restore {}: {error}",path.display()))?,None=>{let _=fs::remove_file(path);}}return Err("injected parallel consumer failure after write".to_owned())}Ok(())}

fn inspection_parallel_manifest(args: &[String]) -> Result<(), String> {
    if args.len() != 4 && args.len() != 6 { return Err("parallel-manifest expects root, relative, max-entries, optionally preview|apply and output-relative".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let path = rooted_path(root, inspection_arg(args, 2, "relative")?)?;
    let limit = inspection_arg(args, 3, "max-entries")?.parse::<usize>().map_err(|_| "invalid max-entries".to_owned())?;
    let consumer = if args.len()==6 { let mode=match inspection_arg(args,4,"mode")?{"preview"=>0,"apply"=>1,_=>return Err("parallel-manifest consumer mode must be preview or apply".to_owned())}; let output=inspection_arg(args,5,"output-relative")?; let segments=std::path::Path::new(output).components().count() as i32; if eoie_proxy_search_proxy_parallel_consumer_mode_binding(mode,segments)!=1{return Err("typed parallel consumer request rejected".to_owned())} Some((mode,rooted_path(root,output)?)) } else { None };
    let workers = std::env::var("EOIE_PARALLEL_WORKERS").ok().and_then(|value| value.parse::<usize>().ok()).unwrap_or(56);
    if eoie_proxy_search_proxy_parallel_search_request_binding(0, limit as i32) != 1 || eoie_proxy_search_proxy_parallel_search_worker_binding(workers as i32, 56) != 1 { return Err("typed parallel-manifest request rejected".to_owned()); }
    let serial = manifest_collect(root, &path, limit, false)?;
    let pool = rayon::ThreadPoolBuilder::new().num_threads(workers).build().map_err(|error| format!("build Rayon pool: {error}"))?;
    let parallel = pool.install(|| manifest_collect(root, &path, limit, true))?;
    let sorted = i32::from(parallel.windows(2).all(|window| window[0] <= window[1]));
    let unique = i32::from(parallel.windows(2).all(|window| window[0] != window[1]));
    let serial_hash = inspection_sha256(serial.join("\n").into_bytes());
    let parallel_hash = inspection_sha256(parallel.join("\n").into_bytes());
    let serial_prefix = i32::from_str_radix(&serial_hash[..7], 16).map_err(|error| format!("manifest fingerprint: {error}"))?;
    let parallel_prefix = i32::from_str_radix(&parallel_hash[..7], 16).map_err(|error| format!("manifest fingerprint: {error}"))?;
    if eoie_proxy_search_proxy_parallel_manifest_order_binding(sorted, unique) != 1 || eoie_proxy_search_proxy_parallel_manifest_parity_binding(serial_prefix, parallel_prefix) != 1 || serial != parallel { return Err("serial and parallel manifests diverged".to_owned()); }
    let consumer_payload=|entries:usize,manifest_hash:&str|format!("open core\n// parallel-readiness|entries={entries}|manifest_sha256={manifest_hash}|workers_required=56\ninl parallel_readiness_entry_count () : u32 = {entries}u32\ninl parallel_readiness_worker_floor () : u32 = 56u32\ninl parallel_readiness_manifest_sha256 () : string = \"{manifest_hash}\"\ninl main () : i32 = 0i32\n").into_bytes();
    let serial_payload=consumer_payload(serial.len(),&serial_hash);
    let payload=consumer_payload(parallel.len(),&parallel_hash);
    if let Some((mode,target))=consumer { let serial_output_hash=inspection_sha256(serial_payload.clone()); let output_hash=inspection_sha256(payload.clone()); let serial_output_prefix=i32::from_str_radix(&serial_output_hash[..7],16).map_err(|error|format!("consumer fingerprint: {error}"))?; let output_prefix=i32::from_str_radix(&output_hash[..7],16).map_err(|error|format!("consumer fingerprint: {error}"))?; if serial_payload!=payload || eoie_proxy_search_proxy_parallel_consumer_output_binding(serial_output_prefix,output_prefix)!=1{return Err("serial and parallel consumer outputs diverged".to_owned())} if mode==1 { inspection_consumer_write(&target,&payload)?; let observed=fs::read(&target).map_err(|error|format!("read {}: {error}",target.display()))?; if observed!=payload{return Err("parallel consumer bytes diverged".to_owned())} } println!("eoie proxy parallel-manifest consumer={} output={} bytes={} sha256={} manifest_sha256={}",if mode==0{"preview"}else{"apply"},target.display(),payload.len(),output_hash,parallel_hash); }
    for entry in &parallel { println!("{entry}"); }
    println!("eoie proxy parallel-manifest ok workers={workers} entries={} sha256={parallel_hash} parity=exact ordering=deterministic", parallel.len());
    Ok(())
}

pub fn inspection_sha256(mut data: Vec<u8>) -> String {
    const K: [u32; 64] = [0x428a2f98,0x71374491,0xb5c0fbcf,0xe9b5dba5,0x3956c25b,0x59f111f1,0x923f82a4,0xab1c5ed5,0xd807aa98,0x12835b01,0x243185be,0x550c7dc3,0x72be5d74,0x80deb1fe,0x9bdc06a7,0xc19bf174,0xe49b69c1,0xefbe4786,0x0fc19dc6,0x240ca1cc,0x2de92c6f,0x4a7484aa,0x5cb0a9dc,0x76f988da,0x983e5152,0xa831c66d,0xb00327c8,0xbf597fc7,0xc6e00bf3,0xd5a79147,0x06ca6351,0x14292967,0x27b70a85,0x2e1b2138,0x4d2c6dfc,0x53380d13,0x650a7354,0x766a0abb,0x81c2c92e,0x92722c85,0xa2bfe8a1,0xa81a664b,0xc24b8b70,0xc76c51a3,0xd192e819,0xd6990624,0xf40e3585,0x106aa070,0x19a4c116,0x1e376c08,0x2748774c,0x34b0bcb5,0x391c0cb3,0x4ed8aa4a,0x5b9cca4f,0x682e6ff3,0x748f82ee,0x78a5636f,0x84c87814,0x8cc70208,0x90befffa,0xa4506ceb,0xbef9a3f7,0xc67178f2];
    let bit_len = (data.len() as u64).wrapping_mul(8); data.push(0x80); while data.len() % 64 != 56 { data.push(0); } data.extend_from_slice(&bit_len.to_be_bytes());
    let mut h = [0x6a09e667u32,0xbb67ae85,0x3c6ef372,0xa54ff53a,0x510e527f,0x9b05688c,0x1f83d9ab,0x5be0cd19];
    for chunk in data.chunks_exact(64) {
        let mut w = [0u32; 64];
        for i in 0..16 { w[i] = u32::from_be_bytes([chunk[i*4], chunk[i*4+1], chunk[i*4+2], chunk[i*4+3]]); }
        for i in 16..64 { let s0 = w[i-15].rotate_right(7) ^ w[i-15].rotate_right(18) ^ (w[i-15] >> 3); let s1 = w[i-2].rotate_right(17) ^ w[i-2].rotate_right(19) ^ (w[i-2] >> 10); w[i] = w[i-16].wrapping_add(s0).wrapping_add(w[i-7]).wrapping_add(s1); }
        let (mut a,mut b,mut c,mut d,mut e,mut f,mut g,mut hh) = (h[0],h[1],h[2],h[3],h[4],h[5],h[6],h[7]);
        for i in 0..64 { let s1 = e.rotate_right(6) ^ e.rotate_right(11) ^ e.rotate_right(25); let ch = (e & f) ^ ((!e) & g); let t1 = hh.wrapping_add(s1).wrapping_add(ch).wrapping_add(K[i]).wrapping_add(w[i]); let s0 = a.rotate_right(2) ^ a.rotate_right(13) ^ a.rotate_right(22); let maj = (a & b) ^ (a & c) ^ (b & c); let t2 = s0.wrapping_add(maj); hh=g; g=f; f=e; e=d.wrapping_add(t1); d=c; c=b; b=a; a=t1.wrapping_add(t2); }
        h[0]=h[0].wrapping_add(a); h[1]=h[1].wrapping_add(b); h[2]=h[2].wrapping_add(c); h[3]=h[3].wrapping_add(d); h[4]=h[4].wrapping_add(e); h[5]=h[5].wrapping_add(f); h[6]=h[6].wrapping_add(g); h[7]=h[7].wrapping_add(hh);
    }
    h.iter().map(|value| format!("{value:08x}")).collect()
}

pub fn inspection_file_sha256(path: &Path) -> Result<String, String> {
    let metadata = fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() || !metadata.is_file() { return Err(format!("regular file required: {}", path.display())); }
    let limit = std::env::var("EOIE_HASH_LIMIT_BYTES").ok().and_then(|value| value.parse::<u64>().ok()).unwrap_or(512 * 1024 * 1024);
    if metadata.len() > limit { return Err(format!("hash input exceeds limit: bytes={} limit={limit}", metadata.len())); }
    Ok(inspection_sha256(fs::read(path).map_err(|error| format!("read {}: {error}", path.display()))?))
}

fn inspection_hash(args: &[String]) -> Result<(), String> {
    let path = match args.len() { 2 => PathBuf::from(inspection_arg(args, 1, "path")?), 3 => rooted_path(Path::new(inspection_arg(args, 1, "root")?), inspection_arg(args, 2, "relative")?)?, _ => return Err("hash expects path or root, relative".to_owned()) };
    println!("{}", inspection_file_sha256(&path)?);
    Ok(())
}

fn inspection_relative_text(root: &Path, path: &Path) -> Result<String, String> {
    let relative = path.strip_prefix(root).map_err(|_| format!("tree path escaped root: {}", path.display()))?;
    Ok(relative.components().map(|component| component.as_os_str().to_string_lossy().into_owned()).collect::<Vec<_>>().join("/"))
}

fn inspection_tree_collect(root: &Path, path: &Path, manifest: &mut Vec<String>, total: &mut u64, limit: u64) -> Result<(), String> {
    let metadata = fs::symlink_metadata(path).map_err(|error| format!("metadata {}: {error}", path.display()))?;
    if metadata.file_type().is_symlink() { return Err(format!("tree hash refuses symlink: {}", path.display())); }
    let relative = inspection_relative_text(root, path)?;
    if metadata.is_dir() {
        manifest.push(format!("d\t{relative}"));
        let mut children = fs::read_dir(path).map_err(|error| format!("read {}: {error}", path.display()))?.map(|entry| entry.map(|entry| entry.path()).map_err(|error| error.to_string())).collect::<Result<Vec<_>, _>>()?;
        children.sort();
        for child in children { inspection_tree_collect(root, &child, manifest, total, limit)?; }
    } else if metadata.is_file() {
        *total = total.checked_add(metadata.len()).ok_or_else(|| "tree byte count overflow".to_owned())?;
        if *total > limit { return Err(format!("tree hash input exceeds limit: bytes={} limit={limit}", *total)); }
        manifest.push(format!("f\t{relative}\t{}\t{}", metadata.len(), inspection_file_sha256(path)?));
    } else { return Err(format!("unsupported tree entry: {}", path.display())); }
    Ok(())
}

pub fn inspection_tree_sha256(root: &Path, relative: &str) -> Result<String, String> {
    let path = rooted_path(root, relative)?;
    let limit = std::env::var("EOIE_TREE_HASH_LIMIT_BYTES").ok().and_then(|value| value.parse::<u64>().ok()).unwrap_or(1024 * 1024 * 1024);
    let mut manifest = Vec::new();
    let mut total = 0u64;
    inspection_tree_collect(root, &path, &mut manifest, &mut total, limit)?;
    manifest.sort();
    Ok(inspection_sha256(manifest.join("\n").into_bytes()))
}

fn inspection_hash_tree(args: &[String]) -> Result<(), String> {
    if args.len() != 3 { return Err("hash-tree expects root, relative".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let relative = inspection_arg(args, 2, "relative")?;
    let segments = Path::new(relative).components().count() as i32;
    if eoie_proxy_search_proxy_hash_tree_request_binding(i32::from(root.is_dir()), segments) != 1 { return Err("typed hash-tree request rejected".to_owned()); }
    println!("{}", inspection_tree_sha256(root, relative)?);
    Ok(())
}

fn inspection_copy(args: &[String]) -> Result<(), String> {
    if args.len() != 4 { return Err("fs-copy expects root, source, target".to_owned()); }
    let root = Path::new(inspection_arg(args, 1, "root")?);
    let source = rooted_path(root, inspection_arg(args, 2, "source")?)?;
    let target = rooted_path(root, inspection_arg(args, 3, "target")?)?;
    let bytes = copy_regular_atomic_preserve(&source, &target)?;
    println!("eoie proxy fs-copy ok source={} target={} bytes={bytes}", source.display(), target.display());
    Ok(())
}

pub fn proxy_search(args: &[String]) -> Result<(), String> {
    match args.first().map(String::as_str) {
        Some("fs-slice") => inspection_slice(args),
        Some("fs-context") => inspection_context(args),
        Some("fs-search") => inspection_search(args),
        Some("parallel-search") => inspection_parallel_search(args),
        Some("parallel-manifest") => inspection_parallel_manifest(args),
        Some("hash") => inspection_hash(args),
        Some("hash-tree") => inspection_hash_tree(args),
        Some("fs-copy") => inspection_copy(args),
        _ => Err("inspection expects fs-slice, fs-context, fs-search, parallel-search, parallel-manifest, hash, hash-tree, or fs-copy".to_owned()),
    }
}

const PATH_TAG_A:&str="amber|ashen|austere|brisk|calm|candid|cobalt|crisp|dapper|deep|dry|eager|ember|faint|feral|firm|frost|gentle|gloss|granite|hollow|honest|humid|ivory|jade|jovial|keen|lunar|mellow|mirth|muted|nimble|noble|noisy|oaken|open|pale|plain|polar|proud|quick|quiet|rapid|rare|raw|rich|sacred|salty|sandy|sharp|silken|sober|solar|solid|stark|steel|subtle|swift|tender|tidal|urban|vivid|warm|wild";
const PATH_TAG_B:&str="anchor|basalt|beacon|boulder|bridge|cable|cairn|candle|canyon|cipher|citadel|compass|copper|cradle|delta|drift|engine|fabric|fable|fjord|forest|forge|garden|glyph|hammer|harbor|horizon|island|kernel|ladder|lattice|lumen|mantle|matrix|meadow|mirror|needle|obelisk|orbit|packet|pebble|pillar|prism|quarry|rail|raven|reef|ribbon|river|rocket|saddle|signal|silo|socket|spindle|spiral|stone|switch|temple|thread|tunnel|valley|vector|vault";
const PATH_TAG_C:&str="archive|atlas|backlog|bundle|circuit|clause|contract|core|diff|driver|epoch|file|flow|graph|hint|index|ingest|intent|io|journal|lease|ledger|log|lore|manifest|mesh|method|node|opcode|origin|patch|path|plan|proof|receipt|relay|route|schema|scope|seal|shard|signal|slice|state|stream|syntax|task|token|tool|trace|tree|tribe|truth|turn|unit|vector|version|warp|weave|witness|work|workspace|wrap|zerg";
fn path_tag_word(bank:&'static str,index:usize)->Result<&'static str,String>{bank.split('|').nth(index).ok_or_else(||format!("path-tag word index escaped bank: {index}"))}

fn path_tag_normalize(input: &str) -> Result<String, String> {
    let replaced = input.replace('\\', "/");
    let is_absolute = replaced.starts_with('/') || replaced.as_bytes().get(1).is_some_and(|byte| *byte == b':');
    let mut has_parent = false;
    let mut segments = Vec::new();
    for segment in replaced.split('/') { match segment { "" | "." => {}, ".." => has_parent = true, value => segments.push(value) } }
    let segment_count = if segments.is_empty() { 1 } else { segments.len() };
    let flags = i32::from(is_absolute) + i32::from(has_parent);
    if eoie_proxy_search_proxy_path_tag_relative_packed_binding(flags, segment_count as i32) != 1 { return Err(format!("path-tag rejects non-relative path: {input}")); }
    Ok(if segments.is_empty() { ".".to_owned() } else { segments.join("/") })
}

pub fn mnemonic_path_tag(input: &str) -> Result<String, String> {
    let normalized = path_tag_normalize(input)?;
    let digest = inspection_sha256(normalized.as_bytes().to_vec());
    let prefix = u32::from_str_radix(&digest[..5], 16).map_err(|error| format!("decode path-tag digest: {error}"))? >> 2;
    if eoie_proxy_search_proxy_path_tag_packed_indices_binding(prefix as i32, 64) != 1 { return Err("path-tag indices escaped word banks".to_owned()); }
    let a = ((prefix >> 12) & 63) as usize; let b = ((prefix >> 6) & 63) as usize; let c = (prefix & 63) as usize;
    let tag = format!("{}-{}-{}", path_tag_word(PATH_TAG_A,a)?, path_tag_word(PATH_TAG_B,b)?, path_tag_word(PATH_TAG_C,c)?);
    if eoie_proxy_search_proxy_path_tag_shape_binding(3, 2) != 1 { return Err("path-tag shape rejected".to_owned()); }
    Ok(tag)
}

fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 0i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    method1(v0, v1)
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 262143i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 64i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 64i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    method3(v0, v1)
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 3i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 3i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 2i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 2i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    method5(v0, v1)
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            1i32
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    method7(v0, v1)
}
fn method9(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        1i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            1i32
        }
    }
}
fn method8(mut v0: i32, mut v1: i32) -> i32 {
    method9(v0, v1)
}
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 0i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method10(mut v0: i32, mut v1: i32) -> i32 {
    method11(v0, v1)
}
fn method13(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
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
fn method12(mut v0: i32, mut v1: i32) -> i32 {
    method13(v0, v1)
}
fn method15(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 == v1;
            if v4 {
                1i32
            } else {
                0i32
            }
        }
    }
}
fn method14(mut v0: i32, mut v1: i32) -> i32 {
    method15(v0, v1)
}
fn method17(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            1i32
        }
    }
}
fn method16(mut v0: i32, mut v1: i32) -> i32 {
    method17(v0, v1)
}
fn method19(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == v1;
    if v2 {
        1i32
    } else {
        0i32
    }
}
fn method18(mut v0: i32, mut v1: i32) -> i32 {
    method19(v0, v1)
}
fn method21(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method20(mut v0: i32, mut v1: i32) -> i32 {
    method21(v0, v1)
}
fn method23(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == v1;
    if v2 {
        1i32
    } else {
        0i32
    }
}
fn method22(mut v0: i32, mut v1: i32) -> i32 {
    method23(v0, v1)
}
fn method25(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 1i32;
    if v2 {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            1i32
        }
    } else {
        0i32
    }
}
fn method24(mut v0: i32, mut v1: i32) -> i32 {
    method25(v0, v1)
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method2(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method4(v0, v1)
    })
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method6(v0, v1)
    })
}
fn closure4() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method8(v0, v1)
    })
}
fn closure5() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method10(v0, v1)
    })
}
fn closure6() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method12(v0, v1)
    })
}
fn closure7() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method14(v0, v1)
    })
}
fn closure8() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method16(v0, v1)
    })
}
fn closure9() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method18(v0, v1)
    })
}
fn closure10() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method20(v0, v1)
    })
}
fn closure11() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method22(v0, v1)
    })
}
fn closure12() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method24(v0, v1)
    })
}
pub fn eoie_proxy_search_proxy_path_tag_relative_packed_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_proxy_search_proxy_path_tag_packed_indices_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_proxy_search_proxy_path_tag_shape_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_proxy_search_proxy_path_tag_determinism_binding(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
pub fn eoie_proxy_search_proxy_path_tag_collision_binding(v0: i32, v1: i32) -> i32 {
    closure4()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_search_request_binding(v0: i32, v1: i32) -> i32 {
    closure5()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_search_worker_binding(v0: i32, v1: i32) -> i32 {
    closure6()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_search_parity_binding(v0: i32, v1: i32) -> i32 {
    closure7()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_manifest_order_binding(v0: i32, v1: i32) -> i32 {
    closure8()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_manifest_parity_binding(v0: i32, v1: i32) -> i32 {
    closure9()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_consumer_mode_binding(v0: i32, v1: i32) -> i32 {
    closure10()(v0, v1)
}
pub fn eoie_proxy_search_proxy_parallel_consumer_output_binding(v0: i32, v1: i32) -> i32 {
    closure11()(v0, v1)
}
pub fn eoie_proxy_search_proxy_hash_tree_request_binding(v0: i32, v1: i32) -> i32 {
    closure12()(v0, v1)
}
