use super::*;

#[test]
fn full_field_type_identity_keeps_generic_arguments_for_discrimination() {
    let source = r#"type Scheduler = {
    admissionRef : uint32
}
type Admission = {
    admissionRef : TerminalFlowIdentityRef< AdmissionKind >
}
type Other = {
    admissionRef : TerminalFlowIdentityRef<OtherKind>
}"#;
    let parsed = record_types(source, 4, None, None);
    assert_eq!(parsed.len(), 3);
    assert_eq!(parsed[0].fields["admissionRef"].type_identity, "uint32");
    assert_eq!(
        parsed[1].fields["admissionRef"].type_identity,
        "TerminalFlowIdentityRef<AdmissionKind>"
    );
    assert_eq!(
        parsed[2].fields["admissionRef"].type_identity,
        "TerminalFlowIdentityRef<OtherKind>"
    );
    assert!(field_type_identity_is_unique(
        &parsed,
        1,
        &BTreeSet::from([0, 1, 2]),
        "admissionRef"
    ));
}

#[test]
fn identical_full_field_type_identity_remains_ambiguous() {
    let source = r#"type Earlier = {
    termRef : TerminalFlowIdentityRef<TerminalFlowCicTermRefKind>
}
type Intended = {
    termRef : TerminalFlowIdentityRef< TerminalFlowCicTermRefKind >
}"#;
    let parsed = record_types(source, 4, None, None);
    assert_eq!(parsed.len(), 2);
    assert!(!field_type_identity_is_unique(
        &parsed,
        1,
        &BTreeSet::from([0, 1]),
        "termRef"
    ));
}
