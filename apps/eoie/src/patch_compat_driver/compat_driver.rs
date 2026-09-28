#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
use eoie_backup_domain::{
    eoie_patch_backup_binding_slot, eoie_patch_backup_next_count,
    eoie_patch_backup_should_capture, eoie_patch_backup_slot, eoie_patch_capture_authorized,
    eoie_patch_capture_binding_slot, 
    eoie_patch_promotion_slot_authorized,
    
    eoie_patch_restoration_select, eoie_patch_restoration_bind,
    eoie_patch_restoration_complete, eoie_patch_restoration_attempt_count,
    eoie_patch_restoration_attempt_authorized, eoie_patch_restoration_counter_next,
    eoie_patch_restoration_accumulator_outcome,
};
use eoie_patch_control_domain::{ eoie_patch_restoration_payload_identity, eoie_patch_restoration_payload_slot_binding, eoie_patch_restoration_payload_outcome_binding, parse_patch_exact_source, patch_occurrence_count, patch_rooted, patch_target_max_bytes};
use eoie_patch_effect_domain::{eoie_patch_authority_pair, eoie_patch_read_limit_binding, eoie_patch_read_receipt_binding, eoie_patch_remove_receipt_binding, eoie_patch_rename_slot_authorized, eoie_patch_rename_slot_binding, eoie_patch_rename_stage_authorized, eoie_patch_stage_identity, eoie_patch_write_bytes_authorized, eoie_patch_write_slot_binding};
use eoie_patch_orchestration_domain::{eoie_patch_orchestration_complete_binding, eoie_patch_orchestration_guard_identity, eoie_patch_orchestration_guard_match_binding, eoie_patch_orchestration_guard_needle_binding, eoie_patch_orchestration_operation_binding, eoie_patch_orchestration_promotion_binding, eoie_patch_orchestration_stage_binding, eoie_patch_orchestration_witness_binding};
use eoie_patch_source_adapter::prepare_patch_source;
use eoie_rust_std_fs::{
    discard_stage, promote_stage_receipted, read_regular_text_limited, restore_text, stage_text_receipted_bound,
    StagedWriteReceipt,
};
use std::collections::BTreeMap;
use std::env;
use std::fs;
use std::path::{Path, PathBuf};
#[must_use]
pub fn patch_plan_error(code: i32) -> i32 {
    let message = match code {
        0 => "typed patch plan contains no PatchExact values",
        -1 => "typed patch plan is malformed",
        -2 => "typed patch plan exceeds 256 KiB",
        -3 => "typed patch plan source is unavailable",
        _ => "typed patch plan returned an invalid witness",
    };
    eprintln!("eoie error: {message}");
    2
}

fn patch_finish(result: Result<(), String>) -> i32 {
    if let Err(error) = result {
        eprintln!("eoie error: {error}");
        2
    } else {
        0
    }
}

fn read_patch_target_text(path: &Path, max_bytes: usize) -> Result<String, String> {
    let text = read_regular_text_limited(path, max_bytes).map_err(|error| {
        if error.contains("exceeds limit") {
            format!("patch target exceeds typed capture limit: {}: {error}", path.display())
        } else {
            error
        }
    })?;
    let observed = text.len();
    let observed_i32 = i32::try_from(observed).unwrap_or(i32::MAX);
    let limit_i32 = i32::try_from(max_bytes)
        .map_err(|_| "typed capture limit does not fit i32".to_owned())?;
    if eoie_patch_read_limit_binding(limit_i32, observed_i32) != observed_i32 {
        return Err(format!("patch target exceeds typed capture limit: {} bytes={} limit={}", path.display(), observed, max_bytes));
    }
    if eoie_patch_read_receipt_binding(observed_i32, observed_i32) != observed_i32 {
        return Err(format!("patch target read receipt mismatch: {}", path.display()));
    }
    Ok(text)
}

fn authorize_staged_write(
    backup_slot: usize,
    expected_bytes: usize,
    observed_bytes: usize,
) -> Result<usize, String> {
    let slot = i32::try_from(backup_slot)
        .map_err(|_| "temporary write backup slot does not fit i32".to_owned())?;
    let expected = i32::try_from(expected_bytes)
        .map_err(|_| "expected temporary write length does not fit i32".to_owned())?;
    let observed = i32::try_from(observed_bytes)
        .map_err(|_| "observed temporary write length does not fit i32".to_owned())?;
    let authorized = eoie_patch_write_bytes_authorized(expected, observed);
    let bound_slot = eoie_patch_write_slot_binding(slot, authorized);
    if bound_slot != slot {
        return Err(format!(
            "typed temporary write receipt mismatch: expected={expected_bytes} observed={observed_bytes}"
        ));
    }
    usize::try_from(bound_slot)
        .map_err(|_| "typed temporary write slot is negative".to_owned())
}

fn authorize_promotion_identity(
    expected_stage: usize,
    observed_stage: i32,
    expected_slot: usize,
    observed_slot: i32,
) -> Result<usize, String> {
    let expected_stage_i32 = i32::try_from(expected_stage)
        .map_err(|_| "expected promotion stage does not fit i32".to_owned())?;
    let expected_slot_i32 = i32::try_from(expected_slot)
        .map_err(|_| "expected promotion slot does not fit i32".to_owned())?;
    let stage_authorized =
        eoie_patch_rename_stage_authorized(expected_stage_i32, observed_stage);
    let slot_authorized =
        eoie_patch_rename_slot_authorized(expected_slot_i32, observed_slot);
    let authorized = eoie_patch_authority_pair(stage_authorized, slot_authorized);
    let bound_slot = eoie_patch_rename_slot_binding(expected_slot_i32, authorized);
    if bound_slot != expected_slot_i32 {
        return Err(format!(
            "typed promotion identity mismatch: expected_stage={expected_stage} observed_stage={observed_stage} expected_slot={expected_slot} observed_slot={observed_slot}"
        ));
    }
    usize::try_from(bound_slot)
        .map_err(|_| "typed promotion slot is negative".to_owned())
}

#[derive(Clone, Copy, Debug, PartialEq, Eq)]
enum PatchFault {
    CheckOnly,
    BetweenPromotions,
    BetweenPromotionsRollbackFailure,
    RehearseRollback,
}


fn patch_fault_from_env() -> Option<PatchFault> {
    match env::var("EOIE_PATCH_FAULT").ok().as_deref() {
        Some("between-promotions") => Some(PatchFault::BetweenPromotions),
        Some("between-promotions-rollback-failure") => {
            Some(PatchFault::BetweenPromotionsRollbackFailure)
        }
        _ => None,
    }
}


fn apply_patch_context(root: &Path, source: &str, validated_count: i32) -> Result<(), String> {
    apply_patch_context_with_fault(root, source, validated_count, patch_fault_from_env(), None)
}

fn apply_patch_context_with_fault(
    root: &Path,
    source: &str,
    validated_count: i32,
    fault: Option<PatchFault>,
    mut postgate: Option<&mut dyn FnMut() -> Result<(), String>>,
) -> Result<(), String> {
    if validated_count <= 0 {
        return Err("typed patch witness must be positive".to_owned());
    }
    let patches = parse_patch_exact_source(source)?;
    if patches.is_empty() {
        return Err("typed patch plan contains no PatchExact values".to_owned());
    }
    let parsed_count = i32::try_from(patches.len())
        .map_err(|_| "patch plan operation count overflow".to_owned())?;
    let driver_expected_operations = eoie_patch_orchestration_witness_binding(validated_count, parsed_count);
    if driver_expected_operations != parsed_count {
        return Err(format!(
            "patch plan witness mismatch: spiral={validated_count} host={parsed_count}"
        ));
    }

    let target_max_bytes = patch_target_max_bytes()?;
    let mut backups = TypedBackups::default();
    let mut current: BTreeMap<PathBuf, (String, usize)> = BTreeMap::new();
    let mut operation_cursor = 0i32;
    for (operation_index, patch) in patches.iter().enumerate() {
        let observed_operation = i32::try_from(operation_index).map_err(|_| "patch operation index does not fit i32".to_owned())?;
        let next_operation_cursor = eoie_patch_orchestration_operation_binding(operation_cursor, observed_operation);
        let operation_authorized = if next_operation_cursor < 0 { 0 } else { 1 };
        if operation_authorized != 1 {
            return Err(format!("typed patch operation order mismatch: expected={operation_cursor} observed={operation_index}"));
        }
        let path = patch_rooted(root, &patch.relative)?;
        let text = if let Some((text, _)) = current.get(&path) {
            text.clone()
        } else {
            read_patch_target_text(&path, target_max_bytes)?
        };
        let backup_slot = backups.observe(&path, &text, target_max_bytes)?;
        let count = patch_occurrence_count(&text, &patch.before);
        let guard_payload_invalid = { let path_slot = i32::try_from(backup_slot).unwrap_or(-1); let guard = eoie_patch_orchestration_guard_identity(observed_operation, path_slot); let guard = eoie_patch_orchestration_guard_needle_binding(guard, i32::try_from(patch.before.len()).unwrap_or(i32::MAX)); let guard = eoie_patch_orchestration_guard_match_binding(guard, i32::try_from(count).unwrap_or(i32::MAX));   guard != observed_operation }; if guard_payload_invalid {
            return Err(format!(
                "patch precondition failed: {} has {count} matches",
                path.display()
            ));
        }
        current.insert(path, (text.replacen(&patch.before, &patch.after, 1), backup_slot));
        
        if operation_cursor < 0 { return Err("typed patch driver operation receipt mismatch".to_owned()); }
        operation_cursor = next_operation_cursor;
        if operation_cursor < 0 {
            return Err("typed patch operation cursor became invalid".to_owned());
        }
    }

    if eoie_patch_orchestration_complete_binding(driver_expected_operations, operation_cursor) != 1 {
        return Err("typed patch driver operation completion mismatch".to_owned());
    }
    if eoie_patch_orchestration_complete_binding(parsed_count, operation_cursor) != 1 {
        return Err(format!("typed patch commit witness mismatch: expected={parsed_count} observed={operation_cursor}"));
    }
    if fault == Some(PatchFault::CheckOnly) {
        return Ok(());
    }

    let mut staged = Vec::new();
    for (stage_index, (path, (text, backup_slot))) in current.iter().enumerate() {
        let slot = i32::try_from(*backup_slot).map_err(|error| error.to_string())?;
        let stage_index = i32::try_from(stage_index).map_err(|error| error.to_string())?;
        let bound_slot = eoie_patch_backup_binding_slot(slot, stage_index);
        if bound_slot != slot {
            return Err(path.display().to_string());
        }
        let bound_slot = usize::try_from(bound_slot).map_err(|error| error.to_string())?;
        let bound_slot_i32 = i32::try_from(bound_slot)
            .map_err(|_| "bound stage slot does not fit i32".to_owned())?;
        if eoie_patch_stage_identity(stage_index, bound_slot_i32) != bound_slot_i32 { return Err(path.display().to_string()); } let receipt = stage_text_receipted_bound(path, text, stage_index, bound_slot_i32)?;
        let write_slot = match authorize_staged_write(
            bound_slot,
            text.len(),
            receipt.bytes_written(),
        ) {
            Ok(slot) => slot,
            Err(error) => {
                let remove_outcome = if discard_stage(receipt.temporary()).is_ok() { 1 } else { 0 };
                if eoie_patch_remove_receipt_binding(receipt.stage_index(), remove_outcome) != receipt.stage_index() { return Err("typed remove receipt mismatch".to_owned()); }
                return Err(error);
            }
        };
        staged.push((receipt, write_slot));
    }
    let driver_expected_files = i32::try_from(current.len()).map_err(|_| "typed patch driver file count overflow".to_owned())?;
    let driver_observed_stages = i32::try_from(staged.len()).map_err(|_| "typed patch driver stage count overflow".to_owned())?;
    let driver_stage_count = eoie_patch_orchestration_stage_binding(driver_expected_files, driver_observed_stages);
    if driver_stage_count != driver_expected_files { return Err("typed patch driver stage receipt mismatch".to_owned()); }

    fn rollback_error(
        backups: &TypedBackups,
        committed_count: usize,
        staged: &[(StagedWriteReceipt, usize)],
        original: String,
    ) -> String {
        patch_error_with_rollback(
            original,
            rollback_by_spiral(backups, committed_count, staged),
        )
    }


    let mut committed_count = 0usize;
    let mut driver_promotion_cursor = 0i32;
    for (index, (receipt, expected_slot)) in staged.iter().enumerate() {
        if let Err(error) = authorize_promotion_identity(
            index,
            receipt.stage_index(),
            *expected_slot,
            receipt.backup_slot(),
        ) {
            return Err(rollback_error(
                &backups,
                committed_count,
                &staged,
                error,
            ));
        }
        let promotion = match promote_stage_receipted(receipt) {
            Ok(promotion) => promotion,
            Err(error) => {
                return Err(rollback_error(
                    &backups,
                    committed_count,
                    &staged,
                    format!("commit {}: {error}", receipt.target().display()),
                ));
            }
        };
        let promoted_count = match committed_count.checked_add(1) {
            Some(value) => value,
            None => {
                return Err(rollback_error(
                    &backups,
                    committed_count,
                    &staged,
                    "committed promotion count overflow".to_owned(),
                ));
            }
        };
        if let Err(error) = authorize_promotion_identity(
            index,
            promotion.stage_index(),
            *expected_slot,
            promotion.backup_slot(),
        ) {
            return Err(rollback_error(
                &backups,
                promoted_count,
                &staged,
                error,
            ));
        }
        if promotion.target() != receipt.target()
            || promotion.temporary() != receipt.temporary()
        {
            return Err(rollback_error(
                &backups,
                promoted_count,
                &staged,
                "promotion receipt path identity mismatch".to_owned(),
            ));
        }
        let next_driver_promotion_cursor = eoie_patch_orchestration_promotion_binding(driver_promotion_cursor, promotion.stage_index());
        if next_driver_promotion_cursor < 0 {
            return Err(rollback_error(&backups, promoted_count, &staged, "typed patch driver promotion receipt mismatch".to_owned()));
        }
        driver_promotion_cursor = next_driver_promotion_cursor;
        committed_count = promoted_count;
        if index == 0
            && staged.len() > 1
            && matches!(
                fault,
                Some(PatchFault::BetweenPromotions)
                    | Some(PatchFault::BetweenPromotionsRollbackFailure)
            )
        {
            let original = "injected patch fault between promotions".to_owned();
            if fault == Some(PatchFault::BetweenPromotionsRollbackFailure)
                && let Err(error) =
                    fs::remove_file(receipt.target()).and_then(|_| fs::create_dir(receipt.target()))
            {
                return Err(rollback_error(
                    &backups,
                    committed_count,
                    &staged,
                    format!("{original}; restoration fault setup: {error}"),
                ));
            }
            return Err(rollback_error(
                &backups,
                committed_count,
                &staged,
                original,
            ));
        }
    }
    if eoie_patch_orchestration_complete_binding(driver_stage_count, driver_promotion_cursor) != 1 {
        return Err(rollback_error(&backups, committed_count, &staged, "typed patch driver completion mismatch".to_owned()));
    }
    if let Some(gate) = postgate.as_mut()
        && let Err(error) = gate()
    {
        return Err(rollback_error(
            &backups,
            committed_count,
            &staged,
            format!("patch executable postgate rejected: {error}"),
        ));
    }
    if fault == Some(PatchFault::RehearseRollback) {
        let receipt = rollback_by_spiral(&backups, committed_count, &staged)
            .map_err(|failure| format!("patch rehearsal rollback failed; {}", failure.public_context()))?;
        for (path, (_, slot)) in &current {
            let original = backups.original(*slot).ok_or_else(|| "patch rehearsal selected a missing backup".to_owned())?;
            let observed = read_patch_target_text(path, target_max_bytes)?;
            if &observed != original {
                return Err(format!("patch rehearsal byte verification failed: {}", path.display()));
            }
        }
        println!(
            "eoie patch rehearse ok operations={} files={} {}",
            patches.len(),
            current.len(),
            receipt.public_context()
        );
        return Ok(());
    }

    println!(
        "eoie patch ok operations={} files={} witness=spiral",
        patches.len(),
        current.len()
    );
    Ok(())
}

#[derive(Default)]
struct TypedBackups {
    slot_by_path: BTreeMap<PathBuf, usize>,
    originals: Vec<String>,
}

impl TypedBackups {
    fn observe(&mut self, path: &Path, text: &str, max_bytes: usize) -> Result<usize, String> {
        let existing = self
            .slot_by_path
            .get(path)
            .and_then(|slot| i32::try_from(*slot).ok())
            .unwrap_or(-1);
        let next = i32::try_from(self.originals.len())
            .map_err(|_| "backup slot count overflow".to_owned())?;
        let should_capture = eoie_patch_backup_should_capture(existing, next) == 1;
        let observed = i32::try_from(text.len()).unwrap_or(i32::MAX);
        let limit = i32::try_from(max_bytes)
            .map_err(|_| "typed capture limit does not fit i32".to_owned())?;
        let capture_authorized = eoie_patch_capture_authorized(observed, limit);
        let planned_slot = eoie_patch_backup_slot(existing, next);
        let planned_count = eoie_patch_backup_next_count(existing, next);
        let slot = usize::try_from(planned_slot)
            .map_err(|_| "typed backup slot is negative".to_owned())?;
        let count = usize::try_from(planned_count)
            .map_err(|_| "typed backup count is negative".to_owned())?;

        if should_capture {
            let bound_slot = eoie_patch_capture_binding_slot(planned_slot, capture_authorized);
            if bound_slot != planned_slot {
                return Err("typed backup capture authority denied".to_owned());
            }
            let expected_count = self
                .originals
                .len()
                .checked_add(1)
                .ok_or_else(|| "backup slot count overflow".to_owned())?;
            if slot != self.originals.len() || count != expected_count {
                return Err("typed backup capture plan diverged".to_owned());
            }
            self.originals.push(text.to_owned());
            self.slot_by_path.insert(path.to_path_buf(), slot);
        } else if self.slot_by_path.get(path).copied() != Some(slot)
            || count != self.originals.len()
        {
            return Err("typed backup reuse plan diverged".to_owned());
        }

        Ok(slot)
    }

    fn original(&self, slot: usize) -> Option<&String> {
        self.originals.get(slot)
    }
}

#[derive(Debug, Clone)]
struct RestorationPathFailure {
    path: PathBuf,
    message: String,
}

#[derive(Debug, Clone)]
struct RestorationReceipt {
    expected_count: i32,
    success_count: i32,
    failure_count: i32,
    payload_identities: Vec<i32>,
    pending_identity: i32,
    restored_paths: Vec<PathBuf>,
    failures: Vec<RestorationPathFailure>,
}

impl RestorationReceipt {
    fn new(expected_count: i32) -> Result<Self, String> {
        if expected_count < 0 {
            return Err("typed restoration expected count is negative".to_owned());
        }
        Ok(Self {
            expected_count,
            success_count: 0,
            failure_count: 0,
            payload_identities: Vec::new(),
            pending_identity: -1,
            restored_paths: Vec::new(),
            failures: Vec::new(),
        })
    }

    fn attempt_count(&self) -> i32 {
        eoie_patch_restoration_attempt_count(self.success_count, self.failure_count)
    }

    fn authorize_attempt(&self) -> i32 {
        eoie_patch_restoration_attempt_authorized(self.expected_count, self.attempt_count())
    }

    fn begin_attempt(&mut self, identity: i32) {
        if identity < 0 || self.payload_identities.contains(&identity) {
            self.pending_identity = -1;
        } else {
            self.pending_identity = identity;
        }
    }

    fn take_attempt_identity(&mut self, outcome: i32) -> i32 {
        let identity = eoie_patch_restoration_payload_outcome_binding(self.pending_identity, outcome);
        self.pending_identity = -1;
        identity
    }

    fn record_success(&mut self, path: &Path) {
        let identity = self.take_attempt_identity(1);
        if identity < 0 {
            self.success_count = -1;
            return;
        }
        let next = eoie_patch_restoration_counter_next(self.success_count, self.authorize_attempt());
        if next < 0 {
            self.success_count = -1;
            return;
        }
        self.success_count = next;
        self.payload_identities.push(identity);
        self.restored_paths.push(path.to_path_buf());
    }

    fn record_failure(&mut self, path: &Path, message: impl Into<String>) {
        let identity = self.take_attempt_identity(2);
        if identity < 0 {
            self.failure_count = -1;
            return;
        }
        let next = eoie_patch_restoration_counter_next(self.failure_count, self.authorize_attempt());
        if next < 0 {
            self.failure_count = -1;
            return;
        }
        self.failure_count = next;
        self.payload_identities.push(identity);
        self.failures.push(RestorationPathFailure {
            path: path.to_path_buf(),
            message: message.into(),
        });
    }

    fn outcome(&self) -> i32 {
        let complete = eoie_patch_restoration_complete(self.expected_count, self.attempt_count());
        eoie_patch_restoration_accumulator_outcome(complete, self.failure_count)
    }

}

#[derive(Debug)]
struct RestorationFailure {
    message: String,
    receipt: RestorationReceipt,
}

fn restoration_payload_identity_for(
    candidate_index: usize,
    observed_stage: i32,
    expected_slot: usize,
    observed_slot: i32,
) -> Result<i32, String> {
    let candidate = i32::try_from(candidate_index)
        .map_err(|_| "restoration payload candidate does not fit i32".to_owned())?;
    let expected_slot = i32::try_from(expected_slot)
        .map_err(|_| "restoration payload slot does not fit i32".to_owned())?;
    let identity = eoie_patch_restoration_payload_identity(candidate, observed_stage);
    let slot_authorized = eoie_patch_promotion_slot_authorized(expected_slot, observed_slot);
    let identity = eoie_patch_restoration_payload_slot_binding(identity, slot_authorized);
    if identity < 0 {
        Err("typed restoration payload identity mismatch".to_owned())
    } else {
        Ok(identity)
    }
}

fn expected_restoration_payload_identity(
    candidate_index: usize,
    expected_slot: usize,
) -> Result<i32, String> {
    let candidate = i32::try_from(candidate_index)
        .map_err(|_| "restoration payload candidate does not fit i32".to_owned())?;
    let slot = i32::try_from(expected_slot)
        .map_err(|_| "restoration payload slot does not fit i32".to_owned())?;
    restoration_payload_identity_for(candidate_index, candidate, expected_slot, slot)
}

fn fatal_restoration_failure(
    message: impl Into<String>,
    receipt: &RestorationReceipt,
    staged: &[(StagedWriteReceipt, usize)],
    committed_count: usize,
) -> RestorationFailure {
    let message = message.into();
    let mut receipt = receipt.clone();
    for (candidate_index, (pending, expected_slot)) in staged.iter().take(committed_count).enumerate() {
        let path = pending.target();
        let identity = expected_restoration_payload_identity(candidate_index, *expected_slot)
            .unwrap_or_else(|_| i32::try_from(candidate_index).unwrap_or(-1));
        if !receipt.payload_identities.contains(&identity) {
            receipt.begin_attempt(identity);
            receipt.record_failure(path, message.clone());
        }
    }
    RestorationFailure { message, receipt }
}

fn discard_restoration_stages(staged: &[(StagedWriteReceipt, usize)]) {
    for (pending, _) in staged {
        let _ = discard_stage(pending.temporary());
    }
}

fn rollback_by_spiral(
    backups: &TypedBackups,
    committed_count: usize,
    staged: &[(StagedWriteReceipt, usize)],
) -> Result<RestorationReceipt, RestorationFailure> {
    let expected_count = match i32::try_from(committed_count) {
        Ok(value) => value,
        Err(_) => {
            let restoration_receipt = RestorationReceipt::new(0)
                .expect("zero-count restoration receipt");
            let failure = fatal_restoration_failure(
                "restoration count overflow",
                &restoration_receipt,
                staged,
                committed_count,
            );
            discard_restoration_stages(staged);
            return Err(failure);
        }
    };
    let mut restoration_receipt = match RestorationReceipt::new(expected_count) {
        Ok(receipt) => receipt,
        Err(error) => {
            let restoration_receipt = RestorationReceipt::new(0)
                .expect("zero-count restoration receipt");
            let failure = fatal_restoration_failure(
                error,
                &restoration_receipt,
                staged,
                committed_count,
            );
            discard_restoration_stages(staged);
            return Err(failure);
        }
    };
    let committed_i32 = i32::try_from(committed_count).unwrap_or(i32::MAX);
    let mut cursor = 0i32;
    loop {
        let candidate = eoie_patch_restoration_select(committed_i32, cursor);
        if candidate < 0 {
            break;
        }
        let candidate_index = match usize::try_from(candidate) {
            Ok(value) => value,
            Err(_) => {
                let failure = fatal_restoration_failure(
                    "typed restoration selected an invalid index",
                    &restoration_receipt,
                    staged,
                    committed_count,
                );
                discard_restoration_stages(staged);
                return Err(failure);
            }
        };
        let Some((receipt, expected_slot)) = staged.get(candidate_index) else {
            let failure = fatal_restoration_failure(
                "typed restoration selected a missing staged receipt",
                &restoration_receipt,
                staged,
                committed_count,
            );
            discard_restoration_stages(staged);
            return Err(failure);
        };
        let expected_identity = match expected_restoration_payload_identity(candidate_index, *expected_slot) {
            Ok(identity) => identity,
            Err(error) => {
                let failure = fatal_restoration_failure(
                    error,
                    &restoration_receipt,
                    staged,
                    committed_count,
                );
                discard_restoration_stages(staged);
                return Err(failure);
            }
        };
        restoration_receipt.begin_attempt(expected_identity);
        let observed_index = match i32::try_from(candidate_index) {
            Ok(value) => value,
            Err(_) => {
                restoration_receipt.record_failure(
                    receipt.target(),
                    "restoration index overflow",
                );
                cursor = cursor.saturating_add(1);
                continue;
            }
        };
        if eoie_patch_restoration_bind(candidate, observed_index) != candidate {
            restoration_receipt.record_failure(
                receipt.target(),
                "typed restoration receipt index mismatch",
            );
            cursor = cursor.saturating_add(1);
            continue;
        }
        let bound_slot = match authorize_promotion_identity(
            candidate_index,
            receipt.stage_index(),
            *expected_slot,
            receipt.backup_slot(),
        ) {
            Ok(value) => value,
            Err(error) => {
                restoration_receipt.record_failure(receipt.target(), error);
                cursor = cursor.saturating_add(1);
                continue;
            }
        };
        let observed_identity = match restoration_payload_identity_for(
            candidate_index,
            receipt.stage_index(),
            *expected_slot,
            receipt.backup_slot(),
        ) {
            Ok(identity) => identity,
            Err(error) => {
                restoration_receipt.record_failure(receipt.target(), error);
                cursor = cursor.saturating_add(1);
                continue;
            }
        };
        restoration_receipt.begin_attempt(observed_identity);
        let original = match backups.original(bound_slot) {
            Some(value) => value,
            None => {
                restoration_receipt.record_failure(
                    receipt.target(),
                    "typed restoration selected a missing backup",
                );
                cursor = cursor.saturating_add(1);
                continue;
            }
        };
        match restore_text(receipt.target(), original) {
            Ok(()) => restoration_receipt.record_success(receipt.target()),
            Err(error) => restoration_receipt.record_failure(receipt.target(), error),
        }
        cursor = cursor.saturating_add(1);
    }
    let outcome = restoration_receipt.outcome();
    discard_restoration_stages(staged);
    match outcome {
        1 => Ok(restoration_receipt),
        2 => Err(RestorationFailure {
            message: "best-effort restoration completed with path failures".to_owned(),
            receipt: restoration_receipt,
        }),
        0 => {
            let attempted_count = restoration_receipt.attempt_count();
            Err(fatal_restoration_failure(
                format!(
                    "typed restoration attempts incomplete: expected={expected_count} observed={attempted_count}"
                ),
                &restoration_receipt,
                staged,
                committed_count,
            ))
        }
        _ => Err(fatal_restoration_failure(
            "typed restoration accumulator entered an invalid state",
            &restoration_receipt,
            staged,
            committed_count,
        )),
    }
}

impl RestorationReceipt {
    fn failed_paths(&self) -> Vec<PathBuf> {
        self.failures.iter().map(|failure| failure.path.clone()).collect()
    }

    fn public_context(&self) -> String {
        let failed_paths = self.failed_paths();
        if self.outcome() == 1 {
            format!(
                "rollback=restored restored_paths={} failed_paths=[]",
                restoration_paths_text(&self.restored_paths)
            )
        } else {
            format!(
                "rollback=failed restoration_error={} restored_paths={} failed_paths={}",
                restoration_failures_text(&self.failures),
                restoration_paths_text(&self.restored_paths),
                restoration_paths_text(&failed_paths)
            )
        }
    }
}

impl RestorationFailure {
    fn public_context(&self) -> String {
        if self.receipt.failures.is_empty() {
            format!(
                "rollback=failed restoration_error=[<rollback>=>{}] restored_paths={} failed_paths=[]",
                self.message,
                restoration_paths_text(&self.receipt.restored_paths)
            )
        } else {
            self.receipt.public_context()
        }
    }
}

fn restoration_failures_text(failures: &[RestorationPathFailure]) -> String {
    let body = failures
        .iter()
        .map(|failure| format!("{}=>{}", failure.path.display(), failure.message))
        .collect::<Vec<_>>()
        .join(",");
    format!("[{body}]")
}

fn restoration_paths_text(paths: &[PathBuf]) -> String {
    let body = paths
        .iter()
        .map(|path| path.display().to_string())
        .collect::<Vec<_>>()
        .join(",");
    format!("[{body}]")
}

fn patch_error_with_rollback(
    original: String,
    rollback: Result<RestorationReceipt, RestorationFailure>,
) -> String {
    match rollback {
        Ok(receipt) => format!("{original}; {}", receipt.public_context()),
        Err(failure) => format!("{original}; {}", failure.public_context()),
    }
}

#[must_use]
pub fn patch_prepare_source_owned(root: &str, plan: &str) -> std::rc::Rc<str> {
    match prepare_patch_source(root, plan) {
        Ok(source) => std::rc::Rc::<str>::from(source),
        Err(error) => {
            eprintln!("eoie error: {error}");
            std::rc::Rc::<str>::default()
        }
    }
}

#[must_use]
pub fn patch_check_context_owned(root: &str, source: &str, validated_count: i32) -> i32 {
    match apply_patch_context_with_fault(
        std::path::Path::new(root),
        source,
        validated_count,
        Some(PatchFault::CheckOnly),
        None,
    ) {
        Ok(()) => validated_count,
        Err(error) => {
            eprintln!("eoie error: {error}");
            -1
        }
    }
}

#[must_use]
pub fn patch_apply_context_owned(root: &str, source: &str, validated_count: i32) -> i32 {
    if std::env::var("EOIE_PATCH_FAULT").ok().as_deref() == Some("after-typecheck") {
        return patch_finish(Err("injected patch fault after typecheck".to_owned()));
    }
    let result = apply_patch_context(std::path::Path::new(root), source, validated_count);
    if result.is_ok()
        && let Err(error) = eoie_patch_source_adapter::patch_resume_complete(root, source)
    {
        return patch_finish(Err(error));
    }
    patch_finish(result)
}

#[must_use]
pub fn patch_rehearse_context_owned(root: &str, source: &str, validated_count: i32) -> i32 {
    patch_finish(apply_patch_context_with_fault(
        std::path::Path::new(root),
        source,
        validated_count,
        Some(PatchFault::RehearseRollback),
        None,
    ))
}

#[must_use]
pub fn patch_apply_gated_context_owned<F>(root: &str, source: &str, validated_count: i32, mut gate: F) -> i32
where
    F: FnMut() -> Result<(), String>,
{
    patch_finish(apply_patch_context_with_fault(
        std::path::Path::new(root),
        source,
        validated_count,
        None,
        Some(&mut gate),
    ))
}


#[cfg(feature = "test-support")]
pub mod test_support {
    use super::*;

    pub fn temporary(label: &str) -> PathBuf { let stamp = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).expect("clock").as_nanos(); env::temp_dir().join(format!("eoie-patch-property-{label}-{}-{stamp}", std::process::id())) }

    fn plan_hex(value: &str) -> String { value.as_bytes().iter().map(|byte| format!("{byte:02x}")).collect() }

    pub fn plan(relative: &str, before: &str, after: &str) -> String { format!("op\t{}\t{}\t{}\t{}\t{}\n", plan_hex("patch-exact"), plan_hex(relative), plan_hex(before), plan_hex(after), plan_hex("write")) } 

    fn canonical_test_plan(source: &str) -> String { format!("EOIE-PLAN-IR\t1\n{source}") }

    pub fn apply(root: &Path, source: &str, count: i32) -> Result<(), String> { let source = canonical_test_plan(source); apply_patch_context(root, &source, count) }

    pub fn apply_fault(root: &Path, source: &str, count: i32, fault_code: i32) -> Result<(), String> {
        let fault = match fault_code { 1 => Some(PatchFault::BetweenPromotions), 2 => Some(PatchFault::BetweenPromotionsRollbackFailure), _ => None };
        let source = canonical_test_plan(source); apply_patch_context_with_fault(root, &source, count, fault, None)
    }

    pub fn rehearse(root: &Path, source: &str, count: i32) -> Result<(), String> { let source = canonical_test_plan(source); apply_patch_context_with_fault(root, &source, count, Some(PatchFault::RehearseRollback), None) }

    pub fn gated(root: &Path, source: &str, count: i32, gate_passes: bool) -> Result<(), String> {
        let mut gate = || if gate_passes { Ok(()) } else { Err("test executable gate rejected".to_owned()) };
        let source = canonical_test_plan(source); apply_patch_context_with_fault(root, &source, count, None, Some(&mut gate))
    }

    pub fn gated_with_corruption(root: &Path, source: &str, count: i32, corrupt_relative: &str) -> Result<(), String> {
        let target = root.join(corrupt_relative);
        let mut gate = || { fs::remove_file(&target).map_err(|error| error.to_string())?; fs::create_dir(&target).map_err(|error| error.to_string())?; Err("test executable gate rejected after target corruption".to_owned()) };
        let source = canonical_test_plan(source); apply_patch_context_with_fault(root, &source, count, None, Some(&mut gate))
    }

    pub fn bounded_read(path: &Path, limit: usize) -> Result<String, String> { read_patch_target_text(path, limit) }

    pub fn staged_write_mismatch(root: &Path) -> Result<String, String> {
        let target = root.join("value.txt");
        fs::write(&target, "old").map_err(|error| error.to_string())?;
        let receipt = stage_text_receipted_bound(&target, "new", 0, 0)?;
        let error = authorize_staged_write(0, 4, receipt.bytes_written())
            .expect_err("mismatched receipt");
        discard_stage(receipt.temporary())?;
        if eoie_patch_remove_receipt_binding(receipt.stage_index(), 1) != receipt.stage_index() { return Err("typed remove receipt mismatch".to_owned()); }
        Ok(error)
    }

    pub fn promotion_receipt_roundtrip(root: &Path) -> Result<(), String> {
        let target = root.join("target.txt");
        let other = root.join("other.txt");
        fs::write(&target, "old").map_err(|error| error.to_string())?;
        fs::write(&other, "other").map_err(|error| error.to_string())?;
        let receipt = stage_text_receipted_bound(&target, "new", 0, 7)?;
        if authorize_promotion_identity(1, receipt.stage_index(), 7, receipt.backup_slot()).is_ok() {
            return Err("mismatched promotion identity was accepted".to_owned());
        }
        authorize_promotion_identity(0, receipt.stage_index(), 7, receipt.backup_slot())?;
        let promotion = promote_stage_receipted(&receipt)?;
        authorize_promotion_identity(0, promotion.stage_index(), 7, promotion.backup_slot())?;
        if promotion.target() != target || fs::read_to_string(&target).map_err(|error| error.to_string())? != "new" {
            return Err("promotion receipt did not bind the target".to_owned());
        }
        Ok(())
    }

    pub fn restoration_receipt_paths(root: &Path) -> Result<Vec<PathBuf>, String> {
        let target = root.join("value.txt");
        fs::write(&target, "old").map_err(|error| error.to_string())?;
        let mut backups = TypedBackups::default();
        let slot = backups.observe(&target, "old", 1024)?;
        let staged_receipt = stage_text_receipted_bound(
            &target,
            "new",
            0,
            i32::try_from(slot).map_err(|error| error.to_string())?,
        )?;
        promote_stage_receipted(&staged_receipt)?;
        let staged = vec![(staged_receipt, slot)];
        rollback_by_spiral(&backups, 1, &staged).map(|receipt| receipt.restored_paths)
            .map_err(|failure| failure.public_context())
    }
}

fn spiral_main() -> i32 {
    0i32
}
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(main.join().unwrap());
}
