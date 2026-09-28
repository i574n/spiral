#[test]
fn spiral_archive_permissions_preserve_executable_and_readonly_intent() {
    use eoie_bundle_manifest::eoie_bundle_portable_mode_binding as mode;
    assert_eq!(mode(0, 0), 0o644);
    assert_eq!(mode(0, 1), 0o444);
    assert_eq!(mode(1, 0), 0o755);
    assert_eq!(mode(1, 1), 0o555);
}
