use super::*;

struct Fixture(std::path::PathBuf);
impl Fixture {
    fn new() -> Self {
        let nonce = std::time::SystemTime::now().duration_since(std::time::UNIX_EPOCH).unwrap().as_nanos();
        let root = std::env::temp_dir().join(format!("eoie-fs-actions-{}-{nonce}", std::process::id()));
        std::fs::create_dir_all(root.join("nested/deeper")).unwrap();
        std::fs::write(root.join("target.txt"), "root target").unwrap();
        Self(root)
    }
}
impl Drop for Fixture {
    fn drop(&mut self) { let _ = std::fs::remove_dir_all(&self.0); }
}

#[test]
fn chmod_accepts_real_directories_and_preserves_verification() {
    let fixture = Fixture::new();
    let directory = fixture.0.join("nested");
    let mode = fs_action_mode(&directory).unwrap();
    let items = [FsActionItem { relative: "nested".into(), kind: FsActionKind::Chmod { expected_mode: mode, new_mode: mode } }];
    let prepared = fs_action_prepare(&fixture.0, &items).unwrap();
    let undo = fs_action_apply_one(&prepared[0]).unwrap();
    fs_action_verify_one(&prepared[0]).unwrap();
    fs_action_rollback(&[undo]).unwrap();
}

#[test]
fn nested_symlink_targets_remain_root_relative() {
    let fixture = Fixture::new();
    for (link, expected) in [("link", "target.txt"), ("nested/link", "../target.txt"), ("nested/deeper/link", "../../target.txt")] {
        let items = [FsActionItem { relative: link.into(), kind: FsActionKind::Symlink { target: "target.txt".into() } }];
        let prepared = fs_action_prepare(&fixture.0, &items).unwrap();
        let FsPreparedAction::Symlink { path, target, .. } = &prepared[0] else { panic!("expected symlink") };
        assert_eq!(target, &std::path::PathBuf::from(expected));
        assert_eq!(std::fs::read_to_string(path.parent().unwrap().join(target)).unwrap(), "root target");
        // Verify the actual filesystem link where symlink creation is available.
        match fs_action_apply_one(&prepared[0]) {
            Ok(undo) => {
                fs_action_verify_one(&prepared[0]).unwrap();
                assert_eq!(std::fs::read_to_string(path).unwrap(), "root target");
                fs_action_rollback(&[undo]).unwrap();
                assert!(!path.exists());
            }
            Err(error) if cfg!(windows) && error.contains("1314") => eprintln!("symlink privilege unavailable; target resolution was verified"),
            Err(error) => panic!("{error}"),
        }
    }
}

#[test]
fn spiral_mode_policy_rejects_out_of_range_values() {
    for mode in -1..=4096 {
        assert_eq!(eoie_fs_actions_mode_valid_binding(mode, 0), i32::from((0..=4095).contains(&mode)));
    }
    assert_eq!(eoie_fs_actions_mode_valid_binding(493, 1), 0);
    assert!(fs_action_parse_mode("10000").is_err());
    assert_eq!(fs_action_parse_mode("0o755").unwrap(), 0o755);
}
