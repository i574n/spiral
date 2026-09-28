#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use canonical_plan_ir_domain::parse_plan_ir_manifest as patch_parse_plan_ir_manifest;
use eoie_process::{compile_spiral_plan_ir as patch_compile_plan_ir, resolve_spiral_compiler as patch_resolve_spiral_compiler};
use eoie_proxy_search::inspection_sha256;
use eoie_rust_std_fs::{atomic_write, read_regular_limited, read_regular_text_limited, rooted_canonical_directory, rooted_entry_exists, rooted_regular_size, rooted_remove_regular};
use std::path::{Path, PathBuf};

const PATCH_RESUME_RELATIVE: &str = "state/patch_resume.spi";
const PATCH_PLAN_MAX_BYTES: u64 = 256 * 1024;

fn remove_regular_if_present(path: &Path) -> Result<(), String> {
    if rooted_entry_exists(path)? { rooted_remove_regular(path)?; }
    Ok(())
}

fn patch_compiled_plan_if_present(plan: &Path) -> Result<(String, String), String> {
    let Some(compiler) = patch_resolve_spiral_compiler(None)? else {
        return Err("compiled patch provider requires a Spiral compiler".to_owned());
    };
    let output = plan.with_extension(format!("eoie-plan-ir-{}.ir", std::process::id()));
    let status = patch_compile_plan_ir(compiler.path.to_string_lossy().as_ref(), plan, &output, 30000)?;
    let manifest_result = if status.success() {
        read_regular_text_limited(&output, 2 * 1024 * 1024)
    } else {
        Err(format!("Spiral Plan IR compilation failed for {}", plan.display()))
    };
    let _ = remove_regular_if_present(&output);
    let _ = remove_regular_if_present(&PathBuf::from(format!("{}.spiral-entry", output.display())));
    let _ = remove_regular_if_present(&plan.with_extension("c"));
    let manifest = manifest_result?;
    patch_parse_plan_ir_manifest(&manifest)?;
    let compiler_status = format!("plan-ir:{}:{}", compiler.source, compiler.fingerprint);
    Ok((manifest, compiler_status))
}

fn patch_resume_escape(value: &str) -> String {
    value.replace('\\', "\\\\").replace('\"', "\\\"").replace('\n', "\\n").replace('\r', "\\r")
}

fn patch_resume_path(root: &Path) -> PathBuf { root.join(PATCH_RESUME_RELATIVE) }

fn patch_resume_render(plan: &Path, source: &[u8], compiled: &str) -> Result<String, String> {
    let plan_parent = plan.parent().ok_or_else(|| format!("plan has no parent: {}", plan.display()))?;
    let canonical_parent = rooted_canonical_directory(plan_parent)?;
    let plan_leaf = plan.file_name().ok_or_else(|| format!("plan has no leaf: {}", plan.display()))?;
    let canonical = canonical_parent.join(plan_leaf);
    let plan_text = patch_resume_escape(&canonical.to_string_lossy());
    let fingerprint = inspection_sha256(source.to_vec());
    let compiled_fingerprint = inspection_sha256(compiled.as_bytes().to_vec());
    let bytes = i32::try_from(source.len()).map_err(|_| "patch plan size does not fit i32".to_owned())?;
    Ok(format!("union patch_resume_phase = | PatchResumeIdentified :: patch_resume_phase\nunion patch_resume_receipt = | PatchResumeReceipt :: string * string * string * i32 * patch_resume_phase -> patch_resume_receipt\ninl current () : patch_resume_receipt = PatchResumeReceipt (\"{plan_text}\", \"{fingerprint}\", \"{compiled_fingerprint}\", {bytes}i32, PatchResumeIdentified)\ninl main () : i32 = 0i32\n"))
}

fn patch_resume_atomic_write(path: &Path, bytes: &[u8]) -> Result<(), String> {
    atomic_write(path, bytes)
}

fn patch_resume_matches(root: &Path, expected: &str) -> Result<bool, String> {
    let receipt = patch_resume_path(root);
    if !rooted_entry_exists(&receipt)? { return Ok(false); }
    Ok(read_regular_text_limited(&receipt, 64 * 1024)? == expected)
}

pub fn patch_resume_complete(root: &str, source: &str) -> Result<(), String> {
    let root = rooted_canonical_directory(Path::new(root))?;
    let root = root.as_path();
    let receipt = patch_resume_path(root);
    let observed = read_regular_text_limited(&receipt, 64 * 1024)?;
    let compiled_fingerprint = inspection_sha256(source.as_bytes().to_vec());
    let identity = i32::from(observed.contains(&compiled_fingerprint));
    if eoie_patch_source_adapter_source_resume_pair_binding(1, identity) != 1 {
        return Err("typed patch resume completion identity mismatch".to_owned());
    }
    rooted_remove_regular(&receipt)?;
    let removed = i32::from(!rooted_entry_exists(&receipt)?);
    if eoie_patch_source_adapter_source_resume_completion_binding(1, removed) != 1 {
        return Err("typed patch resume receipt close rejected".to_owned());
    }
    println!("eoie patch resume closed receipt={}", receipt.display());
    Ok(())
}

pub fn prepare_patch_source(root: &str, plan: &str) -> Result<String, String> {
    let root = rooted_canonical_directory(Path::new(root))?;
    let root = root.as_path();
    let plan = Path::new(plan);
    let plan_size = rooted_regular_size(plan)?;
    if plan_size > PATCH_PLAN_MAX_BYTES {
        return Err(format!("patch plan exceeds 256 KiB: {}", plan.display()));
    }
    let before = read_regular_limited(plan, PATCH_PLAN_MAX_BYTES as usize)?;
    let _source = String::from_utf8(before.clone()).map_err(|error| format!("patch plan is not UTF-8: {}: {error}", plan.display()))?;
    let (source, compiler_status) = patch_compiled_plan_if_present(plan)?;
    let expected = patch_resume_render(plan, &before, &source)?;
    let receipt = patch_resume_path(root);
    let present = i32::from(rooted_entry_exists(&receipt)?);
    let matches = i32::from(patch_resume_matches(root, &expected)?);
    let decision = eoie_patch_source_adapter_source_resume_decision_binding(present, matches);
    if decision == 1 {
        println!("eoie patch resume phase=identified resumed=true compiler={} receipt={}", compiler_status, receipt.display());
        return Ok(source);
    }
    if decision < 0 {
        rooted_remove_regular(&receipt)?;
    }
    let observed = read_regular_limited(plan, PATCH_PLAN_MAX_BYTES as usize)?;
    if observed != before {
        return Err(format!("patch plan changed during runtime identification: {}", plan.display()));
    }
    let rendered = patch_resume_render(plan, &before, &source)?;
    patch_resume_atomic_write(&receipt, rendered.as_bytes())?;
    if eoie_patch_source_adapter_source_resume_pair_binding(1, i32::from(patch_resume_matches(root, &rendered)?)) != 1 {
        let _ = remove_regular_if_present(&receipt);
        return Err("typed patch resume receipt verification rejected".to_owned());
    }
    println!("eoie patch resume phase=identified resumed=false compiler={} receipt={}", compiler_status, receipt.display());
    Ok(source)
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
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
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    method1(v0, v1)
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
        if v3 {
            -1i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                -1i32
            } else {
                let mut v5: bool = 1i32 < v1;
                if v5 {
                    -1i32
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
    method1(v0, v1)
}
fn method4(mut v0: i32, mut v1: i32) -> i32 {
    method5(v0, v1)
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
pub fn eoie_patch_source_adapter_source_resume_pair_binding(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_patch_source_adapter_source_resume_decision_binding(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_patch_source_adapter_source_resume_completion_binding(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
