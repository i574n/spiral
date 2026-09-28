#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[rustfmt::skip]
mod ingest_runtime {
use super::*;
use std::{fs,path::{Path,PathBuf}};
fn topology_entries(path:&Path)->Result<Vec<PathBuf>,String>{let mut out=fs::read_dir(path).map_err(|e|format!("read {}: {e}",path.display()))?.map(|x|x.map(|e|e.path()).map_err(|e|e.to_string())).collect::<Result<Vec<_>,_>>()?;out.sort();Ok(out)}
fn topology_arg<'a>(args:&'a [String],index:usize,label:&str)->Result<&'a str,String>{args.get(index).map(String::as_str).ok_or_else(||format!("missing {label}"))}
fn topology_relative(root:&Path,path:&Path)->String{path.strip_prefix(root).unwrap_or(path).to_string_lossy().replace('\\',"/")}
#[derive(Clone, Debug)]
struct IngestTarget { workspace: String, item: String, priority: u16, status: String, reason: String, source: String, score: i32 }

fn ingest_roots(root: &Path) -> Result<Vec<(String, PathBuf)>, String> {
    if root.join("ingest").is_dir() {
        let name = root.file_name().and_then(|value| value.to_str()).unwrap_or("workspace").to_owned();
        return Ok(vec![(name, root.to_path_buf())]);
    }
    let mut rows = Vec::new();
    for child in topology_entries(root)? {
        if child.is_dir() && child.join("ingest").is_dir() {
            let name = child.file_name().and_then(|value| value.to_str()).unwrap_or("workspace").to_owned();
            rows.push((name, child));
        }
    }
    if rows.is_empty() { return Err(format!("ingest root has no ingest workspace: {}", root.display())); }
    Ok(rows)
}

fn ingest_files(path: &Path, out: &mut Vec<PathBuf>) -> Result<(), String> {
    for child in topology_entries(path)? {
        let metadata = fs::symlink_metadata(&child).map_err(|error| format!("metadata {}: {error}", child.display()))?;
        if metadata.file_type().is_symlink() { return Err(format!("ingest rejects symlink: {}", child.display())); }
        if metadata.is_dir() { ingest_files(&child, out)?; } else if metadata.is_file() { out.push(child); }
    }
    Ok(())
}

fn ingest_toolchain_tarball(path: &Path) -> bool {
    let lower = path.to_string_lossy().replace('\\', "/").to_ascii_lowercase();
    lower.contains("rust-nightly") && lower.ends_with(".tar.xz")
}

fn ingest_archive(path: &Path) -> bool {
    let lower = path.to_string_lossy().to_ascii_lowercase();
    lower.ends_with(".zip") || lower.ends_with(".xz") || lower.ends_with(".gz") || lower.ends_with(".tar") || lower.ends_with(".bz2")
}

fn ingest_atomic_write(path: &Path, text: &str) -> Result<(), String> {
    let parent = path.parent().ok_or_else(|| format!("path has no parent: {}", path.display()))?;
    fs::create_dir_all(parent).map_err(|error| format!("create {}: {error}", parent.display()))?;
    let name = path.file_name().and_then(|value| value.to_str()).unwrap_or("targets");
    let temporary = parent.join(format!(".{name}.eoie-ingest-{}", std::process::id()));
    fs::write(&temporary, text.as_bytes()).map_err(|error| format!("write {}: {error}", temporary.display()))?;
    fs::rename(&temporary, path).map_err(|error| format!("commit {}: {error}", path.display()))
}

fn ingest_classify_item(item: &str) -> (&'static str, u16) {
    let lower = item.to_ascii_lowercase();
    if lower.contains("rust-nightly") && lower.ends_with(".tar.xz") { ("archive-only", 1) }
    else if lower.ends_with("targets.tsv") || lower.ends_with("manifest.tsv") { ("hold", 2) }
    else if lower.ends_with(".cpp") || lower.ends_with(".fs") || lower.ends_with(".fsx") || lower.ends_with(".dib") { ("port-now", 9) }
    else if lower.ends_with(".pdf") || lower.ends_with(".md") || lower.ends_with(".txt") { ("extract-next", 7) }
    else if lower.ends_with(".zip") { ("extract-next", 6) }
    else { ("hold", 3) }
}

fn ingest_derive(workspace: &str, text: &str, source: &str) -> Vec<IngestTarget> {
    let mut rows = Vec::new();
    for line in text.lines().skip(1) {
        let cols = line.split('\t').collect::<Vec<_>>();
        if cols.is_empty() { continue; }
        let item = cols.iter().find(|value| value.contains('/') || value.contains('.')).copied().unwrap_or(cols[0]).trim();
        if item.is_empty() { continue; }
        let (status, priority) = ingest_classify_item(item);
        rows.push(IngestTarget { workspace: workspace.to_owned(), item: item.to_owned(), priority, status: status.to_owned(), reason: format!("derived-from-manifest:{status}"), source: source.to_owned(), score: 0 });
    }
    rows.sort_by(|a,b| b.priority.cmp(&a.priority).then_with(|| a.item.cmp(&b.item)));
    rows.dedup_by(|a,b| a.workspace == b.workspace && a.item == b.item);
    rows
}

fn ingest_parse_targets(source: &str, text: &str) -> Vec<IngestTarget> {
    let mut rows = Vec::new();
    for line in text.lines().skip(1) {
        let cols = line.split('\t').collect::<Vec<_>>();
        if cols.len() < 5 { continue; }
        let Ok(priority) = cols[2].trim().parse::<u16>() else { continue; };
        let workspace = cols[0].trim();
        let item = cols[1].trim();
        if workspace.is_empty() || item.is_empty() { continue; }
        rows.push(IngestTarget { workspace: workspace.to_owned(), item: item.to_owned(), priority, status: cols[3].trim().to_owned(), reason: cols[4..].join(" "), source: source.to_owned(), score: 0 });
    }
    rows
}

fn ingest_status_weight(status: &str) -> i32 { match status { "port-now" => 300, "extract-next" => 180, "indexed-target" => 120, "pending-command-map" => 110, "kept-source-only" => 90, "archive-kept" | "corpus-kept" => 60, "hold" | "external-cache-only" | "indexed-not-authority" => -80, _ => 0 } }
fn ingest_reason_weight(reason: &str) -> i32 {
    let lower = reason.to_ascii_lowercase();
    let mut score = 0;
    for (needle, weight) in [("baseline",40),("neural",36),("standalone",34),("generic",30),("real",28),("gate",24),("appendix",20),("oracle",18),("no-medical-claim",18),("heavy",-24),("hold",-30),("overclaim",-34)] { if lower.contains(needle) { score += weight; } }
    score
}
fn ingest_frontier_score(row: &IngestTarget) -> i32 { i32::from(row.priority) * 100 + ingest_status_weight(&row.status) + ingest_reason_weight(&row.reason) - if row.source.ends_with(".derived.tsv") { 18 } else { 0 } }
fn ingest_priority_class(priority: u16) -> i32 { if priority >= 8 { 3 } else if priority >= 4 { 2 } else { 1 } }
fn ingest_rank(mut rows: Vec<IngestTarget>) -> Vec<IngestTarget> {
    for row in &mut rows { row.score = ingest_frontier_score(row); }
    rows.sort_by(|a,b| b.score.cmp(&a.score).then_with(|| b.priority.cmp(&a.priority)).then_with(|| a.workspace.cmp(&b.workspace)).then_with(|| a.item.cmp(&b.item)));
    rows
}
fn ingest_targets_tsv(rows: &[IngestTarget]) -> String {
    let mut out = String::from("workspace\titem\tpriority\tstatus\treason\n");
    for row in rows { out.push_str(&format!("{}\t{}\t{}\t{}\t{}\n", row.workspace, row.item, row.priority, row.status, row.reason.replace('\t', " "))); }
    out
}

pub fn ingest_map_run(args: &[String]) -> Result<(), String> {
    if args.len() != 2 { return Err("ingest-map expects root".to_owned()); }
    let root = Path::new(topology_arg(args,1,"root")?);
    println!("workspace\tingest_manifest\tpayload_files\tarchive_files\ttotal_bytes\tscore\thint");
    for (workspace, path) in ingest_roots(root)? {
        let ingest = path.join("ingest"); let manifest = ingest.join("INGEST.md").is_file(); let mut files=Vec::new(); ingest_files(&ingest,&mut files)?;
        let payload=files.len(); let archives=files.iter().filter(|path| ingest_archive(path)).count(); let bytes=files.iter().map(|path| fs::metadata(path).map(|m|m.len()).unwrap_or(0)).sum::<u64>();
        let class = eoie_ingest_authority_binding(i32::from(manifest), payload as i32); if class == 0 || !manifest { return Err(format!("ingest-map missing INGEST.md workspace={workspace}")); }
        let score = (if manifest {360} else {0}) + (if payload>0 {420} else {0}) + 120; let hint = if payload==0 {"manifest-only"} else {"restartable-ingest"};
        println!("{workspace}\t{}\t{payload}\t{archives}\t{bytes}\t{score}\t{hint}", manifest);
    }
    println!("eoie proxy ingest-map ok root={}",root.display()); Ok(())
}

pub fn ingest_trim_run(args: &[String]) -> Result<(), String> {
    if args.len()!=2 { return Err("ingest-trim-check expects root".to_owned()); } let root=Path::new(topology_arg(args,1,"root")?); let mut blocked=0; println!("path\tbytes\tverdict\treason");
    for (_,path) in ingest_roots(root)? { let mut files=Vec::new(); ingest_files(&path.join("ingest"),&mut files)?; for file in files { let bytes=fs::metadata(&file).map(|m|m.len()).unwrap_or(0); let rel=topology_relative(root,&file); if ingest_toolchain_tarball(&file) { blocked+=1; println!("{rel}\t{bytes}\tRemoveToolchainTarball\ttoolchain-tarball-too-heavy"); } else if bytes>64*1024*1024 { println!("{rel}\t{bytes}\tQuarantineHeavy\theavy-but-not-toolchain"); } else { println!("{rel}\t{bytes}\tKeep\trestart-input-kept"); } } }
    if blocked!=0 || eoie_ingest_authority_binding(blocked,0)!=1 { return Err(format!("ingest trim rejected toolchain_tarballs={blocked}")); } println!("eoie proxy ingest-trim-check ok root={}",root.display()); Ok(())
}

pub fn ingest_extracted_run(args: &[String]) -> Result<(), String> {
    if args.len()!=2 { return Err("ingest-extracted-manifest expects root".to_owned()); } let root=Path::new(topology_arg(args,1,"root")?); println!("workspace\tingest_md\textracted_dir\textracted_manifest\ttoolchain_tarball\tscore\thint");
    for (workspace,path) in ingest_roots(root)? { let ingest=path.join("ingest"); let extracted=ingest.join("extracted"); let has_md=ingest.join("INGEST.md").is_file(); let has_manifest=extracted.join("manifest.tsv").is_file(); let mut files=Vec::new(); ingest_files(&ingest,&mut files)?; let tarballs=files.iter().filter(|file|ingest_toolchain_tarball(file)).count(); let both=i32::from(has_md&&has_manifest); let ok=eoie_ingest_authority_binding(both,tarballs as i32); let score=400+(if has_md{250}else{0})+(if has_manifest{250}else{0})+(if tarballs==0{100}else{0}); let hint=if tarballs>0{"remove-toolchain-tarball"}else if !has_manifest{"write-ingest-extracted-manifest"}else{"ready-for-port-without-archive-stuffing"}; println!("{workspace}\t{has_md}\t{}\t{has_manifest}\t{}\t{score}\t{hint}",extracted.is_dir(),tarballs>0); if ok!=1 || both!=1 || tarballs!=0{return Err(format!("ingest extracted not ready workspace={workspace}"));} } println!("eoie proxy ingest-extracted-manifest ok root={}",root.display()); Ok(())
}

pub fn ingest_targets_run(args: &[String]) -> Result<(), String> {
    if args.len()!=2 { return Err("ingest-targets expects root".to_owned()); } let root=Path::new(topology_arg(args,1,"root")?); let mut rows=Vec::new(); let mut manual=0; let mut derived=0;
    for (workspace,path) in ingest_roots(root)? { let extracted=path.join("ingest/extracted"); for file in ["targets.tsv","targets.derived.tsv"] { let target=extracted.join(file); if target.is_file(){ let text=fs::read_to_string(&target).map_err(|error|format!("read {}: {error}",target.display()))?; let source=format!("{workspace}/ingest/extracted/{file}"); let parsed=ingest_parse_targets(&source,&text); if file=="targets.tsv"{manual+=parsed.len();}else{derived+=parsed.len();} rows.extend(parsed); } } }
    if manual+derived==0 || eoie_ingest_authority_binding(manual as i32,derived as i32)!=1 { return Err("ingest-targets has no targets".to_owned()); } let rows=ingest_rank(rows); println!("rank\tworkspace\titem\tpriority\tstatus\tscore\treason"); for (index,row) in rows.iter().enumerate(){println!("{}\t{}\t{}\t{}\t{}\t{}\t{}",index+1,row.workspace,row.item,row.priority,row.status,row.score,row.reason);} println!("eoie proxy ingest-targets ok root={} manual={} derived={} total={}",root.display(),manual,derived,rows.len()); Ok(())
}

pub fn ingest_targets_derive_run(args: &[String]) -> Result<(), String> {
    if args.len()!=2 { return Err("ingest-targets-derive expects root".to_owned()); } let root=Path::new(topology_arg(args,1,"root")?); let mut total=0;
    for (workspace,path) in ingest_roots(root)? { let extracted=path.join("ingest/extracted"); let manifest=extracted.join("manifest.tsv"); if !manifest.is_file(){return Err(format!("missing ingest manifest workspace={workspace}"));} let text=fs::read_to_string(&manifest).map_err(|error|format!("read {}: {error}",manifest.display()))?; let rows=ingest_derive(&workspace,&text,&format!("{workspace}/ingest/extracted/targets.derived.tsv")); if rows.is_empty(){return Err(format!("derived ingest targets empty workspace={workspace}"));} let target=extracted.join("targets.derived.tsv"); ingest_atomic_write(&target,&ingest_targets_tsv(&rows))?; total+=rows.len(); }
    if total==0 || eoie_ingest_authority_binding(0,total as i32)!=1{return Err("derived target contract rejected".to_owned());} println!("eoie proxy ingest-targets-derive ok root={} targets={}",root.display(),total); Ok(())
}

pub fn frontier_map_run(args: &[String]) -> Result<(), String> {
    if args.len()!=2 { return Err("frontier-map expects root".to_owned()); } let root=Path::new(topology_arg(args,1,"root")?); let mut rows=Vec::new();
    for (workspace,path) in ingest_roots(root)? { let extracted=path.join("ingest/extracted"); for file in ["targets.tsv","targets.derived.tsv"] { let target=extracted.join(file); if target.is_file(){let text=fs::read_to_string(&target).map_err(|error|format!("read {}: {error}",target.display()))?;rows.extend(ingest_parse_targets(&format!("{workspace}/ingest/extracted/{file}"),&text));} } }
    let rows=ingest_rank(rows); let top=rows.first().map(|row|ingest_priority_class(row.priority)).unwrap_or(0); if rows.is_empty() || top==0 || eoie_ingest_authority_binding(rows.len() as i32,top)!=1{return Err("frontier-map has no actionable frontier".to_owned());} println!("rank\tworkspace\titem\tpriority\tstatus\tscore\tsource\treason"); for (index,row) in rows.iter().enumerate(){println!("{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}",index+1,row.workspace,row.item,row.priority,row.status,row.score,row.source,row.reason);} println!("eoie proxy frontier-map ok root={} frontier_count={}",root.display(),rows.len()); Ok(())
}
}
pub use ingest_runtime::{frontier_map_run, ingest_extracted_run, ingest_map_run, ingest_targets_derive_run, ingest_targets_run, ingest_trim_run};

fn method1(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
    let mut v5: bool = v0 < 1i32;
    if v5 {
        0i32
    } else {
        let mut v6: bool = v1 < 1i32;
        if v6 {
            0i32
        } else {
            let mut v7: bool = v2 < 1i32;
            if v7 {
                0i32
            } else {
                let mut v8: bool = v3 < 1i32;
                if v8 {
                    0i32
                } else {
                    let mut v9: bool = v4 < 1i32;
                    if v9 {
                        0i32
                    } else {
                        1i32
                    }
                }
            }
        }
    }
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                1i32
            } else {
                2i32
            }
        }
    }
}
fn method3(mut v0: i32) -> i32 {
    let mut v1: bool = v0 < 0i32;
    if v1 {
        0i32
    } else {
        let mut v2: bool = 0i32 < v0;
        if v2 {
            0i32
        } else {
            1i32
        }
    }
}
fn method4(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    let mut v3: i32 = method3(v2);
    let mut v4: bool = v0 < 1i32;
    if v4 {
        0i32
    } else {
        let mut v5: bool = v1 < 1i32;
        if v5 {
            0i32
        } else {
            let mut v6: bool = v3 < 1i32;
            if v6 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method5(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < 1i32;
            if v4 {
                let mut v5: bool = v1 < 1i32;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            } else {
                1i32
            }
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 1i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = 3i32 < v1;
            if v4 {
                0i32
            } else {
                1i32
            }
        }
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: i32 = 1i32;
            let mut v5: i32 = 2i32;
            let mut v6: i32 = method2(v4, v5);
            let mut v7: i32 = 0i32;
            let mut v8: i32 = method3(v7);
            let mut v9: i32 = 1i32;
            let mut v10: i32 = 1i32;
            let mut v11: i32 = 0i32;
            let mut v12: i32 = method4(v9, v10, v11);
            let mut v13: i32 = 1i32;
            let mut v14: i32 = 2i32;
            let mut v15: i32 = method5(v13, v14);
            let mut v16: i32 = 3i32;
            let mut v17: i32 = 3i32;
            let mut v18: i32 = method6(v16, v17);
            method1(v6, v8, v12, v15, v18)
        }
    }
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
pub fn eoie_ingest_authority_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
