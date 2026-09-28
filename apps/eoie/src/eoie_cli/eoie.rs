#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use command_spec_domain::{eoie_command_code, eoie_command_count, eoie_command_descriptor, eoie_command_descriptor_json, eoie_command_schema_witness, eoie_command_proxy_usage, eoie_proxy_route_code, eoie_proxy_route_witness, eoie_help_flag_code, eoie_help_flag_witness};
use canonical_plan_ir_domain::{eoie_plan_ir_count, eoie_plan_ir_decode_code, eoie_plan_ir_descriptor, eoie_plan_ir_index_valid, eoie_plan_ir_projection_witness, eoie_plan_ir_schema, eoie_plan_ir_stage_witness};
use eoie_agile_lease::lease_authority_code;

#[must_use]
fn EoieShimArgv0Code() -> i32 { eoie_legacy_operations::dogfood_shim_argv0_code() }

#[must_use]
fn EoieShimDispatch() -> i32 { eoie_legacy_operations::dogfood_shim_dispatch() }

#[must_use]
fn EoieProcessVerbCode() -> i32 {
    if lease_authority_code() != 0 { return 7; }
    let verb = std::env::args().nth(1).unwrap_or_else(|| "status".to_owned());
    let code = eoie_command_code(&verb);
    if code <= 6 { code as i32 } else { 6 }
}

#[must_use]
fn EoieProcessTailCount() -> i32 {
    std::env::args().skip(2).count() as i32
}

fn eoie_authority_summary_for_mask(mask: i32) -> Result<(i32, i32, i32, String), String> {
    let state = authority_state_domain::eoie_authority_state(mask, 0);
    if mask < 0 || state < 0 { return Err("typed authority state rejected".to_owned()); }
    let labels = authority_state_domain::eoie_authority_blocker_labels("v1");
    let labels = [labels.0, labels.1, labels.2, labels.3, labels.4];
    let mut reasons = Vec::new();
    for (index, label) in labels.into_iter().enumerate() {
        let bit = authority_state_domain::eoie_authority_blocker_bit(index as i32, 0);
        if bit <= 0 { return Err("typed authority blocker catalog rejected".to_owned()); }
        if mask & bit != 0 { reasons.push(label.to_string()); }
    }
    Ok((mask, state, 1, if reasons.is_empty() { "none".to_owned() } else { reasons.join(",") }))
}

fn eoie_authority_summary() -> Result<(i32, i32, i32, String), String> {
    eoie_authority_summary_for_mask(authority_state_domain::eoie_authority_declared_mask(0, 0))
}

#[must_use]
fn EoieStatusOk(migration: i32) -> i32 {
    let (mask, state, operational_minus_fallback, reasons) = match eoie_authority_summary() {
        Ok(value) => value,
        Err(error) => { eprintln!("eoie error: authority state: {error}"); return 2; }
    };
    let authority = if state == 1 { "exclusive" } else { "blocked" };
    let operational = i32::from(operational_minus_fallback == 1);
    println!(
        "eoie status ok migration={migration}/1000 public_verbs=5/5 spiral_state=true spiral_first=true authority_formal={authority} authority_blocker_mask={mask} authority_blockers={reasons} operational_replacement={operational} legacy_fallback_execution=false"
    );
    0
}

#[must_use]
fn EoieStatusLive(migration: i32) -> i32 {
    let root_text = std::env::args().nth(2).unwrap_or_default();
    let root = std::path::Path::new(&root_text);
    let evidence = match evidence_currentness_domain::evidence_status(root) {
        Ok(value) => value,
        Err(error) => { eprintln!("eoie error: live status evidence: {error}"); return 2; }
    };
    let semantic_current = match semantic_evidence_domain::verify_closeout_registry(root, migration) {
        Ok(_) => 1i32,
        Err(error) => { eprintln!("eoie error: live status semantic closeout: {error}"); return 2; }
    };
    let cold_current = match cold_proof_domain::verify_formal_authority(root) {
        Ok(_) => 30i32,
        Err(error) => { eprintln!("eoie error: live status ColdProofV4, differential catalog or family contracts: {error}"); return 2; }
    };
    let proof_mask = authority_state_domain::eoie_authority_live_mask(semantic_current + cold_current, 0); let declared_mask = authority_state_domain::eoie_authority_declared_mask(0, 0); let live_mask = if proof_mask < 0 || declared_mask < 0 { -1 } else { proof_mask | declared_mask };
    let (authority_mask, authority_state, operational_minus_fallback, authority_reasons) = match eoie_authority_summary_for_mask(live_mask) {
        Ok(value) => value,
        Err(error) => { eprintln!("eoie error: live status authority: {error}"); return 2; }
    };
    let authority_mode = if authority_state == 1 { "exclusive" } else { "blocked" };
    let operational_replacement = i32::from(operational_minus_fallback == 1);
    let toolchain_text = match evidence_currentness_domain::toolchain_status(root) {
        Ok(Some(value)) => format!("toolchain=current toolchain_declared={} toolchain_observed={} toolchain_verified={}", value.declared, value.observed, value.verified),
        Ok(None) => "toolchain=absent".to_owned(),
        Err(error) => { eprintln!("eoie error: live status Rust toolchain: {error}"); return 2; }
    };
    match eoie_compiler_discovery::resolve_spiral_compiler(None) {
        Ok(Some(compiler)) => println!("eoie status live migration={migration}/1000 spiral_state=true spiral_first=true evidence_declared={} evidence_observed={} evidence_verified={} evidence_current=true {} compiler=available compiler_source={} compiler_sha256={} compiler_entry_sha256={} compiler_facade_sha256={} authority_formal={} authority_blocker_mask={} authority_blockers={} operational_replacement={} legacy_fallback_execution=false", evidence.declared, evidence.observed, evidence.verified, toolchain_text, compiler.source, compiler.sha256, compiler.entry_sha256, compiler.facade_sha256.as_deref().unwrap_or("absent"), authority_mode, authority_mask, authority_reasons, operational_replacement),
        Ok(None) => println!("eoie status live migration={migration}/1000 spiral_state=true spiral_first=true evidence_declared={} evidence_observed={} evidence_verified={} evidence_current=true {} compiler=absent authority_formal={} authority_blocker_mask={} authority_blockers={} operational_replacement={} legacy_fallback_execution=false", evidence.declared, evidence.observed, evidence.verified, toolchain_text, authority_mode, authority_mask, authority_reasons, operational_replacement),
        Err(error) => { eprintln!("eoie error: live status compiler discovery: {error}"); return 2; }
    }
    0
}

#[must_use]
fn EoieProcessBatchStatus() -> i32 { process_batch_plan_domain::eoie_batch_matrix_auto_chain_budget(60000, 16000) }

fn eoie_public_valid_values() -> String { (0..eoie_command_count()).map(|index| eoie_command_descriptor(&index.to_string()).0.to_string()).collect::<Vec<_>>().join("|") }
fn eoie_actionable_error(reason: &str, intent: &str, usage: &str, valid: &str, corrected: &str) -> i32 { eprintln!("eoie error: {reason}\nintent: {intent}\nusage: eoie {usage}\nvalid: {valid}\ncorrected: {corrected}"); 2 }

#[must_use]
fn EoieStatusArityError() -> i32 { let descriptor = eoie_command_descriptor("0"); eoie_actionable_error("status accepts zero arguments or one bundle root", "status", descriptor.2.as_ref(), "zero arguments|one bundle root", "eoie status") }

#[must_use]
fn EoieStatusAuthorityError() -> i32 {
    eprintln!("eoie error: workspace-state authority rejected");
    2
}

#[must_use]
fn eoie_reenter_with_compiler(verb: &str, forwarded: &[&str], compiler: &str) -> i32 {
    let compiler = std::path::Path::new(compiler);
    if !compiler.is_absolute() || !compiler.is_file() {
        eprintln!("eoie error: Spiral compiler must be an absolute regular file: {}", compiler.display());
        return 2;
    }
    let executable = match std::env::current_exe() {
        Ok(value) => value,
        Err(error) => {
            eprintln!("eoie error: locate current executable: {error}");
            return 2;
        }
    };
    let fallback_timeout_ms = std::env::var("EOIE_REENTER_TIMEOUT_MS").ok().and_then(|value| value.parse::<u64>().ok()).filter(|value| *value > 0).unwrap_or(300_000);
    let timeout_ms = forwarded.get(1).and_then(|root| {
        let root = std::path::Path::new(root);
        let (_, _, wrap_at_unix_ms, _, should_wrap, _) = eoie_agile_lease::agile_prompt_lease_clock(root).ok()?;
        if should_wrap { return Some(1); }
        let now_unix_ms = eoie_agile_lease::agile_now_unix_ms().ok()?;
        Some(wrap_at_unix_ms.saturating_sub(now_unix_ms).max(1))
    }).unwrap_or(fallback_timeout_ms);
    let mut command = std::process::Command::new(executable);
    command.arg(verb)
        .args(forwarded)
        .env("EOIE_SPIRAL_COMPILE", compiler)
        .env("EOIE_PATCH_COMPILE_REQUIRED", "1");
    match eoie_process_observation::run_bounded_streaming_receipted_observed(&mut command, timeout_ms, "cli-reenter-with-compiler", None) {
        Ok(observation) => observation.status.code().unwrap_or(2),
        Err(error) => {
            eprintln!("eoie error: reenter {verb}: {error}");
            2
        }
    }
}

#[must_use]
fn EoiePatchAdapter() -> i32 {
    let args = std::env::args().skip(2).collect::<Vec<_>>();
    let subcommand = args.first().map(String::as_str); if !matches!(subcommand, Some("apply" | "check" | "rehearse" | "gated")) { let descriptor = eoie_command_descriptor("1"); let reason = subcommand.map(|value| format!("unknown patch subcommand: {value}")).unwrap_or_else(|| "patch subcommand required".to_owned()); return eoie_actionable_error(&reason, "patch", descriptor.2.as_ref(), descriptor.2.as_ref(), "eoie help patch"); }
    if args.len() == 5 && args[0] == "apply" && args[3] == "--compiler" {
        return eoie_reenter_with_compiler(
            "patch",
            &[args[0].as_str(), args[1].as_str(), args[2].as_str()],
            args[4].as_str(),
        );
    }
    if args.first().map(String::as_str) == Some("rehearse") {
        return eoie_patch_rehearsal::eoie_patch_rehearse_run();
    }
    if args.first().map(String::as_str) == Some("gated") {
        return eoie_patch_rehearsal::eoie_patch_gated_run();
    }
    eoie_patch_mutation::eoie_patch_run()
}

#[must_use]
fn EoieAgileAdapter() -> i32 {
    let args = std::env::args().skip(2).collect::<Vec<_>>();
    let subcommand = args.first().map(String::as_str); if !matches!(subcommand, Some("begin" | "lease" | "status" | "handoff" | "list" | "check" | "record" | "set")) { let descriptor = eoie_command_descriptor("2"); let reason = subcommand.map(|value| format!("unknown agile subcommand: {value}")).unwrap_or_else(|| "agile subcommand required".to_owned()); return eoie_actionable_error(&reason, "agile", descriptor.2.as_ref(), descriptor.2.as_ref(), "eoie help agile"); }
    if args.len() == 4 && args[0] == "check" && args[2] == "--compiler" {
        return eoie_agile_state::agile_check_with_compiler_owned(args[1].as_str(), args[3].as_str());
    }
    eoie_agile_mutation::eoie_agile_run()
}

#[must_use]
fn EoieBundleAdapter() -> i32 {
    let args = std::env::args().skip(2).collect::<Vec<_>>();
    let subcommand = args.first().map(String::as_str); if !matches!(subcommand, Some("growth-baseline" | "growth-receipt" | "check" | "create" | "create-flat" | "verify" | "verify-flat" | "rehydrate" | "retention-plan" | "retention-apply")) { let descriptor = eoie_command_descriptor("3"); let reason = subcommand.map(|value| format!("unknown bundle subcommand: {value}")).unwrap_or_else(|| "bundle subcommand required".to_owned()); return eoie_actionable_error(&reason, "bundle", descriptor.2.as_ref(), descriptor.2.as_ref(), "eoie help bundle"); }
    match subcommand {
        Some("retention-plan") => eoie_proxy_result(eoie_bundle_retention::retention_plan_command(&args)),
        Some("retention-apply") => eoie_proxy_result(eoie_bundle_retention::retention_apply_command(&args)),
        _ => eoie_legacy_operations::eoie_bundle_run(),
    }
}

fn eoie_proxy_result(result: Result<(), String>) -> i32 {
    if let Err(error) = result {
        eprintln!("eoie error: {error}");
        2
    } else {
        0
    }
}

fn eoie_plan_ir_inspect(args: &[String]) -> Result<(), String> {
    if eoie_plan_ir_stage_witness() != 1 { return Err("typed Plan IR stage witness rejected".to_owned()); }
    if eoie_plan_ir_count() <= 0 { return Err("typed Plan IR provider is empty".to_owned()); }
    if args.len() != 2 { return Err("plan-ir-inspect expects one index".to_owned()); }
    let index = &args[1];
    if eoie_plan_ir_index_valid(index) != 1 { return Err(format!("invalid Plan IR index: {index}")); }
    let numeric_index = index.parse::<u64>().map_err(|_| "Plan IR index must be integer".to_owned())?;
    let descriptor = eoie_plan_ir_descriptor(index);
    if eoie_plan_ir_decode_code(descriptor.0.as_ref(), descriptor.1.as_ref(), descriptor.2.as_ref(), descriptor.3.as_ref(), descriptor.4.as_ref()) != numeric_index { return Err(format!("canonical Plan IR descriptor rejected: {index}")); }
    println!("schema={} index={} op={} target={} expected={} payload={} effect={}", eoie_plan_ir_schema("schema"), index, descriptor.0, descriptor.1, descriptor.2, descriptor.3, descriptor.4);
    Ok(())
}

fn eoie_plan_ir_check(args: &[String]) -> Result<(), String> {
    if args.len() != 1 { return Err("plan-ir-check accepts no extra arguments".to_owned()); }
    if eoie_plan_ir_stage_witness() != 1 { return Err("typed Plan IR stage witness rejected".to_owned()); }
    if eoie_plan_ir_projection_witness() != 1 { return Err("typed Plan IR manifest projection witness rejected".to_owned()); }
    let count = eoie_plan_ir_count();
    if count <= 0 { return Err("typed Plan IR provider is empty".to_owned()); }
    for index in 0..count {
        let key = index.to_string();
        let descriptor = eoie_plan_ir_descriptor(&key);
        if eoie_plan_ir_decode_code(descriptor.0.as_ref(), descriptor.1.as_ref(), descriptor.2.as_ref(), descriptor.3.as_ref(), descriptor.4.as_ref()) != index as u64 { return Err(format!("canonical Plan IR descriptor rejected: {key}")); }
    }
    println!("eoie plan-ir check ok schema={} count={} stage_witness=1 projection_witness=1", eoie_plan_ir_schema("schema"), count);
    Ok(())
}

#[must_use]
fn EoieProxyAdapter() -> i32 {
    let args = std::env::args().skip(2).collect::<Vec<_>>();
    if args.is_empty() { let descriptor = eoie_command_descriptor("4"); return eoie_actionable_error("proxy capability required", "proxy capability", descriptor.2.as_ref(), descriptor.2.as_ref(), "eoie help proxy"); }
    if eoie_proxy_route_witness() != 1 { return eoie_actionable_error("typed proxy route witness rejected", "proxy capability", "proxy <capability>", "typed proxy route catalog", "eoie help proxy"); }
    let route = eoie_proxy_route_code(args[0].as_str());
    match route {
        0 => eoie_proxy_result(eoie_plan_ir_inspect(&args)),
        1 => eoie_proxy_result(eoie_plan_ir_check(&args)),
        2 => eoie_proxy_result(eoie_release_hygiene::prune_compiler_sidecars(&args)),
        3 => eoie_proxy_result(eoie_release_hygiene::incident_recovery_run(&args)),
        4 => eoie_proxy_result(bundle_retention_domain::external_payload_run(&args)),
        5 => eoie_proxy_result(eoie_coverage_prune::coverage_export(&args)),
        6 => eoie_proxy_result(eoie_coverage_prune::coverage_union(&args)),
        7 => eoie_proxy_result(legacy_capability_domain::legacy_surface_run(&args)),
        8 => eoie_proxy_result(legacy_capability_domain::legacy_install_self_run(&args)),
        9 => eoie_proxy_result(legacy_capability_domain::legacy_self_upgrade_check_run(&args)),
        10 => eoie_proxy_result(eoie_legacy_operations::legacy_restart_baton_run(&args)),
        11 => eoie_proxy_result(eoie_patch_driver_domain::source_authoring_run(&args)),
        12 => eoie_proxy_result(eoie_batch_write::filesystem_batch_write_run(&args)),
        13 => eoie_proxy_result(eoie_fs_actions::filesystem_actions_run(&args)),
        14 => eoie_proxy_result(eoie_handoff::binary_install_run(&args)),
        15 => eoie_proxy_result(eoie_handoff::release_closeout_run(&args)),
        16 => eoie_proxy_result(eoie_legacy_operations::dogfood_shim_proxy(&args)),
        17 => eoie_proxy_result(legacy_capability_domain::legacy_chmod_run(&args)),
        18 => eoie_proxy_result(legacy_capability_domain::legacy_symlink_run(&args)),
        19 => eoie_proxy_result(legacy_capability_domain::legacy_copy_tree_run(&args)),
        20 => eoie_proxy_result(legacy_capability_domain::legacy_command_capture_run(&args)),
        21 => eoie_proxy_result(process_batch_plan_domain::command_capture_env_run(&args)),
        22 => eoie_proxy_result(process_batch_plan_domain::command_capture_matrix_run(&args)),
        23 => eoie_proxy_result(process_batch_plan_domain::command_capture_matrix_gate_run(&args)),
        24 => eoie_proxy_result(process_batch_plan_domain::batch_plan_run(&args)),
        25 => eoie_proxy_result(process_batch_plan_domain::batch_plan_resume_run(&args)),
        26 => eoie_proxy_result(eoie_toolchain_proxy::portable_toolchain_run(&args)),
        27 => eoie_proxy_result(eoie_product_diff::product_diff_run(&args)),
        28 => eoie_proxy_result(eoie_product_diff::source_recovery_run(&args)),
        29 => eoie_proxy_result(eoie_proxy_search::proxy_search(&args)),
        30 => eoie_proxy_result(eoie_bundle_manifest::archive_extract_generic_run(&args)),
        31 => eoie_proxy_result(archive_deflate_domain::archive_extract_run(&args)),
        _ => eoie_legacy_operations::eoie_proxy_run(),
    }
}

#[must_use]
fn EoieHelpRejected() -> i32 {
    let args = std::env::args().skip(2).collect::<Vec<_>>();
    let count = eoie_command_count();
    if count <= 0 { eprintln!("eoie error: typed command catalog is empty"); return 2; }
    if args.len() == 2 && eoie_command_code(&args[0]) == 4 {
        let usage = eoie_command_proxy_usage(&args[1]);
        if usage.is_empty() { let valid = eoie_command_descriptor("4").2; return eoie_actionable_error(&format!("unknown proxy help target: {}", args[1]), "proxy help", "help proxy <capability>", valid.as_ref(), "eoie help"); }
        println!("usage: eoie {}", usage);
        return 0;
    }
    if args.len() > 1 { let descriptor = eoie_command_descriptor("5"); let valid = format!("{}|proxy <capability>|--completion|--json|--schema", eoie_public_valid_values()); return eoie_actionable_error("help accepts zero arguments, one verb, proxy <capability>, --completion, --json, or --schema", "help", descriptor.2.as_ref(), &valid, "eoie help"); }
    if let Some(target) = args.first() {
        if eoie_help_flag_witness() != 1 { eprintln!("eoie error: typed help flag witness rejected"); return 2; }
        let help_flag = eoie_help_flag_code(target);
        if help_flag == 0 {
            for index in 0..count { let descriptor = eoie_command_descriptor(&index.to_string()); println!("{}", descriptor.0); }
            return 0;
        }
        if help_flag == 1 {
            if eoie_command_schema_witness() != 1 { eprintln!("eoie error: typed command schema witness rejected"); return 2; }
            print!("[");
            for index in 0..count { if index > 0 { print!(","); } print!("{}", eoie_command_descriptor_json(&index.to_string())); }
            println!("]");
            return 0;
        }
        if help_flag == 2 {
            if eoie_command_schema_witness() != 1 { eprintln!("eoie error: typed command schema witness rejected"); return 2; }
            println!("command-spec");
            return 0;
        }
        let code = eoie_command_code(target);
        if code >= count as u64 { let proxy_usage = eoie_command_proxy_usage(target); if !proxy_usage.is_empty() { let corrected = format!("eoie help proxy {target}"); return eoie_actionable_error(&format!("help target is a proxy capability: {target}"), "proxy help", "help proxy <capability>", proxy_usage.as_ref(), &corrected); } let valid = eoie_public_valid_values(); return eoie_actionable_error(&format!("unknown help target: {target}"), "help", "help [verb|--completion|--json|--schema]", &valid, "eoie help"); }
        let descriptor = eoie_command_descriptor(&code.to_string());
        println!("name={} effect={} handler={}", descriptor.0, descriptor.1, descriptor.4);
        println!("summary={}", descriptor.3);
        println!("usage: eoie {}", descriptor.2);
        return 0;
    }
    println!("usage: eoie <status|patch|agile|bundle|proxy|help> ...");
    for index in 0..count { let descriptor = eoie_command_descriptor(&index.to_string()); println!("{}", descriptor.2); }
    println!("deployment: runtime operations are compilerless; source-author and prune-uncovered are build-authoring operations requiring EOIE_SPIRAL_COMPILE");
    0
}

#[must_use]
fn EoieUnknownRejected() -> i32 { let verb = std::env::args().nth(1).unwrap_or_default(); let proxy_usage = eoie_command_proxy_usage(&verb); if !proxy_usage.is_empty() { let corrected = format!("eoie {proxy_usage}"); return eoie_actionable_error(&format!("proxy capability used as public verb: {verb}"), "proxy capability", proxy_usage.as_ref(), "proxy <capability>", &corrected); } let valid = eoie_public_valid_values(); eoie_actionable_error(&format!("unknown verb: {verb}"), "public command", "<status|patch|agile|bundle|proxy|help> ...", &valid, "eoie help") }

#[derive(Clone)]
enum US0 {
    US0_0,
    US0_1,
    US0_2,
    US0_3,
    US0_4,
    US0_5,
    US0_6,
    US0_7,
}
impl US0 {
    fn tag(&self) -> i32 {
        match self {
            US0::US0_0 => 0,
            US0::US0_1 => 1,
            US0::US0_2 => 2,
            US0::US0_3 => 3,
            US0::US0_4 => 4,
            US0::US0_5 => 5,
            US0::US0_6 => 6,
            US0::US0_7 => 7,
        }
    }
}
fn method0(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    let mut v4: bool = v0 < 1i32;
    if v4 {
        0i32
    } else {
        let mut v5: bool = v1 < 1i32;
        if v5 {
            0i32
        } else {
            let mut v6: bool = v2 < 1i32;
            if v6 {
                0i32
            } else {
                let mut v7: bool = v3 < 0i32;
                if v7 {
                    0i32
                } else {
                    let mut v8: bool = v0 < v1;
                    if v8 {
                        0i32
                    } else {
                        let mut v9: i32 = v0 - v1;
                        let mut v10: bool = v9 == v3;
                        if v10 {
                            1i32
                        } else {
                            0i32
                        }
                    }
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    let mut v4: bool = v0 < 1i32;
    if v4 {
        0i32
    } else {
        let mut v5: bool = v1 < v0;
        if v5 {
            0i32
        } else {
            let mut v6: bool = v2 < 1i32;
            if v6 {
                0i32
            } else {
                let mut v7: bool = v3 < 500i32;
                if v7 {
                    0i32
                } else {
                    1i32
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
        let mut v3: bool = 1000i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 1i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 1000i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 == 4500000i32;
    if v2 {
        let mut v3: bool = v1 == 600000i32;
        if v3 {
            1i32
        } else {
            0i32
        }
    } else {
        0i32
    }
}
fn method4(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32) -> i32 {
    let mut v4: i32 = v0 * v1;
    let mut v5: i32 = v2 * v3;
    let mut v6: i32 = v4 * v5;
    v6
}
fn method5(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    let mut v3: bool = v0 == 0i32;
    if v3 {
        let mut v4: bool = v2 == 0i32;
        if v4 {
            1i32
        } else {
            0i32
        }
    } else {
        let mut v6: bool = v1 == 1i32;
        if v6 {
            let mut v7: bool = v2 == 1i32;
            if v7 {
                1i32
            } else {
                0i32
            }
        } else {
            let mut v9: bool = v2 == 2i32;
            if v9 {
                1i32
            } else {
                0i32
            }
        }
    }
}
fn method6(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = v1 < 0i32;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < v0;
            if v4 {
                1i32
            } else {
                0i32
            }
        }
    }
}
fn method7(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v1 == 0i32;
    if v2 {
        1i32
    } else {
        let mut v3: bool = v1 == 1i32;
        if v3 {
            let mut v4: bool = v0 == 1i32;
            if v4 {
                1i32
            } else {
                0i32
            }
        } else {
            0i32
        }
    }
}
fn method8(mut v0: i32) -> i32 {
    let mut v1: bool = v0 == 0i32;
    if v1 {
        1i32
    } else {
        0i32
    }
}
fn method9(mut v0: i32) -> i32 {
    let mut v1: bool = v0 == 0i32;
    if v1 {
        1i32
    } else {
        0i32
    }
}
fn method10(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
    let mut v5: i32 = v0 * v1;
    let mut v6: i32 = v2 * v3;
    let mut v7: i32 = v5 * v6;
    let mut v8: i32 = v7 * v4;
    v8
}
fn method12(mut v0: i32, mut v1: i32) -> i32 {
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
fn method11(mut v0: i32, mut v1: i32) -> i32 {
    method12(v0, v1)
}
fn method13(mut v0: i32, mut v1: i32) -> i32 {
    method12(v0, v1)
}
fn method14(mut v0: i32, mut v1: i32) -> i32 {
    method12(v0, v1)
}
fn method15(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 1i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 1i32 < v0;
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
fn method16(mut v0: i32, mut v1: i32) -> i32 {
    method12(v0, v1)
}
fn method17(mut v0: i32, mut v1: i32) -> i32 {
    method12(v0, v1)
}
fn method18(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: i32, mut v5: i32) -> i32 {
    let mut v6: bool = v0 < 1i32;
    if v6 {
        0i32
    } else {
        let mut v7: bool = v1 < 1i32;
        if v7 {
            0i32
        } else {
            let mut v8: bool = v2 < 1i32;
            if v8 {
                0i32
            } else {
                let mut v9: bool = v3 < 1i32;
                if v9 {
                    0i32
                } else {
                    let mut v10: bool = v4 < 1i32;
                    if v10 {
                        0i32
                    } else {
                        let mut v11: bool = v5 < 1i32;
                        if v11 {
                            0i32
                        } else {
                            1i32
                        }
                    }
                }
            }
        }
    }
}
fn method19(mut v0: i32, mut v1: i32) -> i32 {
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
fn method20(mut v0: i32) -> i32 {
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
fn method21(mut v0: i32, mut v1: i32, mut v2: i32) -> i32 {
    let mut v3: i32 = method20(v2);
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
fn method22(mut v0: i32, mut v1: i32) -> i32 {
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
fn method23(mut v0: i32, mut v1: i32) -> i32 {
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
fn method24(mut v0: i32, mut v1: i32, mut v2: i32, mut v3: i32, mut v4: i32) -> i32 {
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
fn spiral_main() -> i32 {
    let mut v0: i32 = EoieShimArgv0Code();
    let mut v1: bool = 0i32 == v0;
    if v1 {
        let mut v2: i32 = EoieProcessVerbCode();
        let mut v3: bool = 0i32 == v2;
        let mut v24: US0 = if v3 {
            US0::US0_0
        } else {
            let mut v5: bool = 1i32 == v2;
            if v5 {
                US0::US0_1
            } else {
                let mut v7: bool = 2i32 == v2;
                if v7 {
                    US0::US0_2
                } else {
                    let mut v9: bool = 3i32 == v2;
                    if v9 {
                        US0::US0_3
                    } else {
                        let mut v11: bool = 4i32 == v2;
                        if v11 {
                            US0::US0_4
                        } else {
                            let mut v13: bool = 5i32 == v2;
                            if v13 {
                                US0::US0_5
                            } else {
                                let mut v15: bool = 7i32 == v2;
                                if v15 {
                                    US0::US0_7
                                } else {
                                    US0::US0_6
                                }
                            }
                        }
                    }
                }
            }
        };
        match &v24 {
            US0::US0_2 => { // AgileHandler
                let mut v129: i32 = EoieAgileAdapter();
                v129
            }
            US0::US0_3 => { // BundleHandler
                let mut v130: i32 = EoieBundleAdapter();
                v130
            }
            US0::US0_5 => { // HelpHandler
                let mut v132: i32 = EoieHelpRejected();
                v132
            }
            US0::US0_7 => { // LeaseDeniedHandler
                2i32
            }
            US0::US0_1 => { // PatchHandler
                let mut v128: i32 = EoiePatchAdapter();
                v128
            }
            US0::US0_4 => { // ProxyHandler
                let mut v131: i32 = EoieProxyAdapter();
                v131
            }
            US0::US0_0 => { // StatusHandler
                let mut v25: i32 = EoieProcessTailCount();
                let mut v26: bool = 0i32 == v25;
                if v26 {
                    let mut v27: i32 = 162i32;
                    let mut v28: i32 = 68i32;
                    let mut v29: i32 = 162i32;
                    let mut v30: i32 = 94i32;
                    let mut v31: i32 = method0(v27, v28, v29, v30);
                    let mut v32: i32 = 44i32;
                    let mut v33: i32 = 69i32;
                    let mut v34: i32 = 637i32;
                    let mut v35: i32 = 500i32;
                    let mut v36: i32 = method1(v32, v33, v34, v35);
                    let mut v37: i32 = 974i32;
                    let mut v38: i32 = 1000i32;
                    let mut v39: i32 = 59i32;
                    let mut v40: i32 = 62i32;
                    let mut v41: i32 = method2(v37, v38);
                    let mut v42: i32 = 4500000i32;
                    let mut v43: i32 = 600000i32;
                    let mut v44: i32 = method3(v42, v43);
                    let mut v45: i32 = method4(v31, v36, v41, v44);
                    let mut v46: bool = 1i32 == v45;
                    if v46 {
                        let mut v47: i32 = 0i32;
                        let mut v48: i32 = 0i32;
                        let mut v49: i32 = 0i32;
                        let mut v50: i32 = method5(v47, v48, v49);
                        let mut v51: i32 = 1i32;
                        let mut v52: i32 = 0i32;
                        let mut v53: i32 = 2i32;
                        let mut v54: i32 = method5(v51, v52, v53);
                        let mut v55: i32 = 1i32;
                        let mut v56: i32 = 1i32;
                        let mut v57: i32 = 1i32;
                        let mut v58: i32 = method5(v55, v56, v57);
                        let mut v59: i32 = v54 * v58;
                        let mut v60: i32 = v50 * v59;
                        let mut v61: i32 = 8i32;
                        let mut v62: i32 = 5i32;
                        let mut v63: i32 = method6(v61, v62);
                        let mut v64: i32 = 1i32;
                        let mut v65: i32 = 1i32;
                        let mut v66: i32 = method7(v64, v65);
                        let mut v67: i32 = 0i32;
                        let mut v68: i32 = method8(v67);
                        let mut v69: i32 = 0i32;
                        let mut v70: i32 = method9(v69);
                        let mut v71: i32 = method10(v63, v60, v66, v68, v70);
                        let mut v72: bool = 1i32 == v71;
                        if v72 {
                            let mut v73: i32 = 1i32;
                            let mut v74: i32 = 1i32;
                            let mut v75: i32 = method11(v73, v74);
                            let mut v76: i32 = 1i32;
                            let mut v77: i32 = 1i32;
                            let mut v78: i32 = method13(v76, v77);
                            let mut v79: i32 = 1i32;
                            let mut v80: i32 = 1i32;
                            let mut v81: i32 = method14(v79, v80);
                            let mut v82: i32 = 1i32;
                            let mut v83: i32 = 2i32;
                            let mut v84: i32 = method15(v82, v83);
                            let mut v85: i32 = 1i32;
                            let mut v86: i32 = 1i32;
                            let mut v87: i32 = method16(v85, v86);
                            let mut v88: i32 = 1i32;
                            let mut v89: i32 = 1i32;
                            let mut v90: i32 = method17(v88, v89);
                            let mut v91: i32 = method18(v75, v78, v81, v84, v87, v90);
                            let mut v92: bool = 1i32 == v91;
                            if v92 {
                                let mut v93: i32 = 1i32;
                                let mut v94: i32 = 2i32;
                                let mut v95: i32 = method19(v93, v94);
                                let mut v96: i32 = 0i32;
                                let mut v97: i32 = method20(v96);
                                let mut v98: i32 = 1i32;
                                let mut v99: i32 = 1i32;
                                let mut v100: i32 = 0i32;
                                let mut v101: i32 = method21(v98, v99, v100);
                                let mut v102: i32 = 1i32;
                                let mut v103: i32 = 2i32;
                                let mut v104: i32 = method22(v102, v103);
                                let mut v105: i32 = 3i32;
                                let mut v106: i32 = 3i32;
                                let mut v107: i32 = method23(v105, v106);
                                let mut v108: i32 = method24(v95, v97, v101, v104, v107);
                                let mut v109: bool = 1i32 == v108;
                                if v109 {
                                    let mut v110: i32 = EoieProcessBatchStatus();
                                    let mut v111: bool = 1i32 == v110;
                                    if v111 {
                                        let mut v112: i32 = EoieStatusOk(987i32);
                                        v112
                                    } else {
                                        let mut v113: i32 = EoieStatusAuthorityError();
                                        v113
                                    }
                                } else {
                                    let mut v115: i32 = EoieStatusAuthorityError();
                                    v115
                                }
                            } else {
                                let mut v117: i32 = EoieStatusAuthorityError();
                                v117
                            }
                        } else {
                            let mut v119: i32 = EoieStatusAuthorityError();
                            v119
                        }
                    } else {
                        let mut v121: i32 = EoieStatusAuthorityError();
                        v121
                    }
                } else {
                    let mut v123: bool = 1i32 == v25;
                    if v123 {
                        let mut v124: i32 = EoieStatusLive(987i32);
                        v124
                    } else {
                        let mut v125: i32 = EoieStatusArityError();
                        v125
                    }
                }
            }
            US0::US0_6 => { // UnknownHandler
                let mut v133: i32 = EoieUnknownRejected();
                v133
            }
            _ => unreachable!(),
        }
    } else {
        let mut v142: i32 = EoieShimDispatch();
        v142
    }
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
