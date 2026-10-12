use super::*;

#[test]
fn record_parser_preserves_mutability_field_type_and_generic_arity() {
    let source = r#"type JPTypeCell<'a> = {
    ivar : Hopac.IVar<'a option>
    mutable owner : JpTypeOwner
}"#;
    let parsed = record_types(source, 7, None, None);
    assert_eq!(parsed.len(), 1);
    assert_eq!(parsed[0].generic_arity, 1);
    assert_eq!(parsed[0].fields["owner"].type_symbol, "JpTypeOwner");
    assert_eq!(parsed[0].fields["owner"].type_identity, "JpTypeOwner");
    assert!(parsed[0].fields["owner"].mutable);
    assert_eq!(render_record_type(&parsed[0]), "JPTypeCell<_>");
    assert_eq!(record_owner(&parsed[0], 7), Some(RecordOwner::Local));
    assert_eq!(
        render_record_owner_type(&parsed[0], RecordOwner::Local),
        "JPTypeCell<_>"
    );
}

#[test]
fn record_parser_does_not_steal_fields_from_a_later_record_in_nested_module() {
    let source = r#"module DiagnosticClassifier =
    type DiagnosticCodeId =
        | DiagnosticEJP0002
        | DiagnosticEJP0003

    type DiagnosticClassification = {
        code : DiagnosticCodeId
        disposition : int
    }"#;
    let parsed = record_types(source, 7, None, None);
    assert_eq!(parsed.len(), 1);
    assert_eq!(
        render_record_type(&parsed[0]),
        "DiagnosticClassifier.DiagnosticClassification"
    );
}

#[test]
fn record_renderer_composes_outer_and_nested_module_paths() {
    let source = r#"module Inner =
    type Receipt = {
        code : string
        disposition : int
    }"#;
    let parsed = record_types(source, 7, Some("Outer"), None);
    assert_eq!(parsed.len(), 1);
    assert_eq!(render_record_type(&parsed[0]), "Outer.Inner.Receipt");
    assert_eq!(record_owner(&parsed[0], 7), None);
    assert_eq!(record_owner(&parsed[0], 9), Some(RecordOwner::External));
    assert_eq!(
        render_record_owner_type(&parsed[0], RecordOwner::External),
        "Outer.Inner.Receipt"
    );
}

#[test]
fn record_parser_skips_type_accessibility_modifiers() {
    let source = r#"type private BuildTraceTerminalityDecision = private {
    disposition : BuildTraceDiagnosticDisposition
    payload : BuildTracePayloadKind
}"#;
    let parsed = record_types(source, 9, None, None);
    assert_eq!(parsed.len(), 1);
    assert_eq!(parsed[0].name, "BuildTraceTerminalityDecision");
    assert_eq!(
        render_record_type(&parsed[0]),
        "BuildTraceTerminalityDecision"
    );
}

#[test]
fn immutable_owner_is_not_mutable_evidence() {
    let source = r#"type NativeHopacCell<'a> = {
    result : IVar<'a>
    owner : NativeHopacCacheOwnerId
}"#;
    let parsed = record_types(source, 4, None, None);
    assert!(!parsed[0].fields["owner"].mutable);
}

#[test]
fn binding_parser_keeps_untyped_parameter_positions() {
    let source = r#"module Authority =
    let snapshot cell = lock cell (fun () -> cell.owner)
    let tryAcquire threadId cell =
        lock cell (fun () -> cell.owner <- JpTypeOwned threadId)"#;
    let parsed = bindings(source);
    assert_eq!(parsed[0].parameters, vec!["cell"]);
    assert_eq!(parsed[1].parameters, vec!["threadId", "cell"]);
}

#[test]
fn projected_field_shape_collects_only_direct_parameter_fields() {
    let source = r#"let render envelope =
    envelope.proof |> ignore
    envelope.planRef |> ignore
    envelope.transaction.transactionRef |> ignore
    other.envelope |> ignore"#;
    let binding = &bindings(source)[0];
    assert_eq!(
        projected_fields(&binding.body, "envelope"),
        BTreeSet::from([
            "planRef".to_owned(),
            "proof".to_owned(),
            "transaction".to_owned(),
        ])
    );
}

#[test]
fn mutable_field_and_match_cases_are_detected_locally() {
    let source = r#"let tryAcquire threadId cell =
    match cell.owner with
    | JpTypeUnowned ->
        cell.owner <- JpTypeOwned threadId
    | JpTypeOwned owner -> ()"#;
    let binding = &bindings(source)[0];
    assert!(assigns_field(&binding.body, "cell", "owner"));
    assert_eq!(
        matched_cases(&binding.body, "cell", "owner"),
        BTreeSet::from(["JpTypeOwned".to_owned(), "JpTypeUnowned".to_owned()])
    );
}

#[test]
fn same_field_type_identity_is_ambiguous_across_record_owners() {
    let field = RecordField {
        mutable: false,
        type_symbol: "TerminalFlowIdentityRef".to_owned(),
        type_identity: "TerminalFlowIdentityRef<TerminalFlowCicTermRefKind>".to_owned(),
        type_text: "TerminalFlowIdentityRef<TerminalFlowCicTermRefKind>".to_owned(),
    };
    let record = |provider, name: &str| RecordType {
        provider,
        declaration: None,
        module_name: None,
        local_module_name: None,
        name: name.to_owned(),
        generic_arity: 0,
        fields: BTreeMap::from([("termRef".to_owned(), field.clone())]),
        members: BTreeSet::new(),
    };
    let records = vec![
        record(7, "DefinitionCheckJob"),
        record(5, "TermInternReceipt"),
    ];
    let competitors = BTreeSet::from([0usize, 1usize]);
    assert!(!field_type_identity_is_unique(
        &records,
        0,
        &competitors,
        "termRef"
    ));
}

#[test]
fn single_field_projection_prefers_original_source_scope_across_split_shards() {
    let record = |provider, declaration, module_name: Option<&str>, name: &str| RecordType {
        provider,
        declaration: Some(DeclarationId(declaration)),
        module_name: module_name.map(str::to_owned),
        local_module_name: None,
        name: name.to_owned(),
        generic_arity: 0,
        fields: BTreeMap::from([(
            "nodes".to_owned(),
            RecordField {
                mutable: false,
                type_symbol: "obj".to_owned(),
                type_identity: "obj list".to_owned(),
                type_text: "obj list".to_owned(),
            },
        )]),
        members: BTreeSet::new(),
    };
    let records = vec![
        record(7, 10, None, "EvalNodePath"),
        record(8, 20, Some("BigStack"), "TerminalFlowQapWorkDag"),
    ];
    let visible = BTreeSet::from([0usize, 1usize]);
    assert_eq!(
        latest_source_record_index(&records, &visible, None, DeclarationId(30)),
        Some(0)
    );
}

#[test]
fn projected_match_evidence_blocks_single_field_heuristic_annotation() {
    let body = r#"match classification.disposition with
    | DiagnosticTerminalNative
    | DiagnosticTerminalSemantic -> true
    | _ -> false"#;
    assert!(has_projected_match_evidence(body, "classification"));
    assert!(!has_projected_match_evidence(
        "path.nodes |> List.length",
        "path"
    ));
}
