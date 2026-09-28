#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![allow(dead_code)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_source_map::source_rebuild_pairs;
use std::fs;
use std::path::Path;

fn cold_relative(root: &Path, path: &Path) -> Result<String,String> {
    let relative = path.strip_prefix(root).map_err(|_| format!("cold rebuild path escapes root: {}", path.display()))?;
    Ok(relative.to_string_lossy().replace('\\', "/"))
}

fn cold_no_space(value: &str, label: &str) -> Result<(),String> {
    if value.chars().any(char::is_whitespace) { Err(format!("cold rebuild {label} contains whitespace: {value}")) } else { Ok(()) }
}

fn cold_matrix_write(root: &Path, relative: &str, eoie: &str, compiler: &str, dotnet: &str, rustfmt: &str) -> Result<(), String> {
    for (label,value) in [("eoie",eoie),("compiler",compiler),("dotnet",dotnet),("rustfmt",rustfmt)] { cold_no_space(value,label)?; }
    cold_no_space(&root.to_string_lossy(),"root")?;
    let pairs = source_rebuild_pairs(root)?;
    let target = root.join(relative);
    let matrix_dir = target.parent().unwrap_or(root);
    fs::create_dir_all(matrix_dir).map_err(|e|format!("mkdir {}: {e}",matrix_dir.display()))?;
    let header = "id\tprogram\targs\tcwd\tenv\trequired_status\ton_error\tdepends_on\treceipt\n";
    let mut out = String::from(header);
    let mut batch_count = 0usize;
    let mut solo_count = 0usize;
    let mut format_count = 0usize;
    for (shard_index, group) in pairs.chunks(2).enumerate() {
        let mut batch = String::new();
        let mut fast_count = 0usize;
        for (input,output) in group {
            let input_rel = cold_relative(root,input)?;
            let output_rel = cold_relative(root,output)?;
            cold_no_space(&input_rel,"input")?; cold_no_space(&output_rel,"output")?;
            cold_no_space(&input.to_string_lossy(),"input absolute")?; cold_no_space(&output.to_string_lossy(),"output absolute")?;
            let owner_code = if input_rel == "src/backup_domain/main.spi" { 1 } else if input_rel == "src/eoie_agile_mutation/agile_mutation.spi" { 2 } else if input_rel == "src/eoie_agile_policy/policy.spi" { 3 } else if input_rel == "src/eoie_agile_state/state.spi" { 4 } else if input_rel == "src/eoie_process/process.spi" { 5 } else if input_rel == "src/eoie_agile_lease/lease.spi" { 6 } else if input_rel == "src/patch_compat_driver/main.spi" { 7 } else if input_rel == "src/eoie_proxy_search/search.spi" { 8 } else if input_rel == "src/bundle_retention_domain/main.spi" { 9 } else if input_rel == "src/eoie_release_hygiene/main.spi" { 10 } else if input_rel == "src/cold_proof_domain/main.spi" { 11 } else if input_rel == "src/eoie_coverage_prune/coverage.spi" { 12 } else if input_rel == "src/eoie_bundle_retention/main.spi" { 13 } else if input_rel == "src/eoie_bundle_zip/bundle.spi" { 14 } else if input_rel == "src/archive_deflate_domain/main.spi" { 15 } else if input_rel == "src/eoie_cold_rebuild_matrix/main.spi" { 16 } else { 0 };
            let lane = eoie_cold_compile_lane(owner_code,0);
            let format_lane = eoie_cold_format_lane(owner_code,0);
            if lane < 0 || format_lane < 0 { return Err(format!("typed cold lane rejected owner: {input_rel}")); }
            if lane == 1 {
                let compile_id = format!("compile-solo-{shard_index:02}-{solo_count:02}");
                let row_compile = format!("{compile_id}\t{compiler}\t--backend Rust --dotnet {dotnet} --timeout-ms 14000 {} {}\t.\t\tpass\tstop\t\t.cold-rebuild/receipts/{compile_id}.txt\n", input.display(), output.display());
                out.push_str(&row_compile);
                if format_lane == 1 {
                    let fmt_id = format!("fmt-density-{shard_index:02}-{solo_count:02}");
                    let row_fmt = format!("{fmt_id}\t{rustfmt}\t--edition 2024 --config-path {}/src/rustfmt.toml {}\t.\t\tpass\tstop\t{compile_id}\t.cold-rebuild/receipts/{fmt_id}.txt\n", root.display(), output.display());
                    out.push_str(&row_fmt);
                    format_count += 1;
                }
                solo_count += 1;
            } else {
                batch.push_str(&format!("{}\t{}\n", input.display(), output.display()));
                fast_count += 1;
            }
        }
        if fast_count > 0 {
            let batch_path = matrix_dir.join(format!("compiler-batch-{shard_index:02}.tsv"));
            cold_no_space(&batch_path.to_string_lossy(),"batch manifest")?;
            fs::write(&batch_path,batch.as_bytes()).map_err(|e|format!("write {}: {e}",batch_path.display()))?;
            let compile_id = format!("compile-batch-{shard_index:02}");
            let row_compile = format!("{compile_id}\t{compiler}\t--backend Rust --dotnet {dotnet} --timeout-ms 14000 --batch {}\t.\t\tpass\tstop\t\t.cold-rebuild/receipts/{compile_id}.txt\n", batch_path.display());
            out.push_str(&row_compile);
            batch_count += 1;
        }
    }
    fs::write(&target,out.as_bytes()).map_err(|e|format!("write {}: {e}",target.display()))?;
    println!("eoie proxy cold-rebuild-matrix ok pairs={} rows={} shard_width=2 batch_chains={} solo_chains={} density_formats={} path={}", pairs.len(), batch_count+solo_count+format_count, batch_count, solo_count, format_count, target.display());
    Ok(())
}

pub fn cold_rebuild_matrix_run(args: &[String]) -> Result<(), String> {
    if args.len() != 7 { return Err("cold-rebuild-matrix expects root matrix-relative eoie compiler dotnet rustfmt".to_owned()); }
    cold_matrix_write(Path::new(&args[1]), &args[2], &args[3], &args[4], &args[5], &args[6])
}

fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 == 0i32;
    if v2 {
        let mut v3: bool = v0 == 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v0 < 1i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 16i32 < v0;
                if v5 {
                    -1i32
                } else {
                    1i32
                }
            }
        }
    } else {
        -1i32
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 == 0i32;
    if v2 {
        let mut v3: bool = v0 < 0i32;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = 16i32 < v0;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = v0 == 10i32;
                if v5 {
                    0i32
                } else {
                    let mut v6: bool = v0 == 14i32;
                    if v6 {
                        0i32
                    } else {
                        let mut v7: bool = 6i32 < v0;
                        if v7 {
                            1i32
                        } else {
                            0i32
                        }
                    }
                }
            }
        }
    } else {
        -1i32
    }
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
pub fn eoie_cold_compile_lane(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_cold_format_lane(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
