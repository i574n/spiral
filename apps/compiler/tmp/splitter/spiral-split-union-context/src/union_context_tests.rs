use super::*;

fn deps(values: &[usize]) -> BTreeSet<usize> {
    values.iter().copied().collect()
}

#[test]
fn parses_multiline_and_inline_union_groups_without_nested_match_cases() {
    let source = r#"
type A =
    | One
    | Two of int

type B = Left | Right

type R = { value : int }
    member this.F() =
        match this.value with
        | 0 -> 1
        | _ -> 2
"#;
    let index = UnionContextIndex::from_provider_sources([(7, source)]);
    assert_eq!(index.groups.len(), 2);
    assert!(index.providers_by_case.contains_key("One"));
    assert!(index.providers_by_case.contains_key("Left"));
    assert!(!index.providers_by_case.contains_key("_"));
}

#[test]
fn conditional_siblings_choose_latest_shared_owner_over_intruding_case() {
    let shared = r#"
type GraphProgressWorkState =
    | WorkUnitDiscovered
    | WorkUnitCompleted
    | WorkUnitBlocked
    | WorkUnitReservedUndiscovered
    | WorkUnitObserverOnly
"#;
    let intruder = r#"
type WorkUnitDisposition =
    | WorkUnitBlocked of string
    | WorkUnitSucceeded
"#;
    let index =
        UnionContextIndex::from_provider_sources([(13, shared), (20, intruder), (21, shared)]);
    let source = r#"let state =
    if closed then WorkUnitCompleted
    elif blocked then WorkUnitBlocked
    elif reserved then WorkUnitReservedUndiscovered
    else WorkUnitObserverOnly
"#;
    let rewritten = qualify_ambiguous_union_branches(
        source,
        &index,
        &deps(&[13, 20, 21]),
        &[13, 21, 20],
        |provider| format!("P{provider}"),
    );
    assert!(rewritten.contains("then P21.WorkUnitCompleted"));
    assert!(rewritten.contains("then P21.WorkUnitBlocked"));
    assert!(rewritten.contains("then P21.WorkUnitReservedUndiscovered"));
    assert!(rewritten.contains("else P21.WorkUnitObserverOnly"));
}

#[test]
fn dependency_root_owner_beats_later_duplicate_owner() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let intruder = "type U =\n    | Left of int\n";
    let mut index =
        UnionContextIndex::from_provider_sources([(13, shared), (20, intruder), (21, shared)]);
    index.provider_dependencies.insert(21, deps(&[13]));
    let source = "let x =\n    if flag then Left\n    else Right\n";
    let rewritten = qualify_ambiguous_union_branches(
        source,
        &index,
        &deps(&[13, 20, 21]),
        &[13, 21, 20],
        |provider| format!("P{provider}"),
    );
    assert!(rewritten.contains("then P13.Left"));
    assert!(rewritten.contains("else P13.Right"));
}

#[test]
fn exact_duplicate_groups_without_intruder_do_not_force_qualification() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let index = UnionContextIndex::from_provider_sources([(1, shared), (2, shared)]);
    let source = "let x =\n    if flag then Left\n    else Right\n";
    assert_eq!(
        qualify_ambiguous_union_branches(source, &index, &deps(&[1, 2]), &[1, 2], |p| format!(
            "P{p}"
        )),
        source
    );
}

#[test]
fn match_siblings_are_qualified_locally_when_one_case_is_contaminated() {
    let intended = "type T =\n    | Left\n    | Right\n";
    let intruder = "type U =\n    | Left of int\n";
    let index = UnionContextIndex::from_provider_sources([(4, intended), (9, intruder)]);
    let source = "let f = function\n    | Left -> 1\n    | Right -> 2\n";
    let rewritten =
        qualify_ambiguous_union_branches(source, &index, &deps(&[4, 9]), &[4, 9], |provider| {
            format!("P{provider}")
        });
    assert!(rewritten.contains("| P4.Left -> 1"));
    assert!(rewritten.contains("| P4.Right -> 2"));
}

#[test]
fn multiline_match_arms_keep_shared_union_cluster() {
    let shared = "type T =\n    | Left of int\n    | Right\n";
    let mut index = UnionContextIndex::from_provider_sources([(13, shared), (21, shared)]);
    index.provider_dependencies.insert(21, deps(&[13]));
    let source = r#"let f = function
    | Left value ->
        value |> ignore
        1
    | Right ->
        2
"#;
    let rewritten =
        qualify_ambiguous_union_branches(source, &index, &deps(&[13, 21]), &[13, 21], |provider| {
            format!("P{provider}")
        });
    assert!(rewritten.contains("| P13.Left value ->"));
    assert!(rewritten.contains("| P13.Right ->"));
}

#[test]
fn explicit_union_parameter_anchors_ambiguous_comparisons() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let index = UnionContextIndex::from_provider_sources([(13, shared), (21, shared)]);
    let source = r#"let f (phase:P13.T) =
    let paused = phase = Left
    let live = Right <> phase
    paused, live
"#;
    let rewritten = qualify_typed_union_comparisons(source, &index, &deps(&[13, 21]), |provider| {
        format!("P{provider}")
    });
    assert!(rewritten.contains("phase = P13.Left"));
    assert!(rewritten.contains("P13.Right <> phase"));
}

#[test]
fn typed_union_binding_scan_preserves_multiple_explicit_owners() {
    let shared = "type T =\n    | Left\n    | Right\n\ntype U =\n    | Hot\n    | Cold\n";
    let index = UnionContextIndex::from_provider_sources([(13, shared), (21, shared)]);
    let source = r#"let f (phase:P13.T) (mode:P21.U) =
    phase = Left, mode = Hot
"#;
    let rewritten = qualify_typed_union_comparisons(source, &index, &deps(&[13, 21]), |provider| {
        format!("P{provider}")
    });
    assert!(rewritten.contains("phase = P13.Left"));
    assert!(rewritten.contains("mode = P21.Hot"));
}

#[test]
fn separate_unions_in_one_provider_do_not_form_a_false_shared_owner() {
    let split = "type A =\n    | Left\n\ntype B =\n    | Right\n";
    let intruder = "type U =\n    | Left of int\n";
    let index = UnionContextIndex::from_provider_sources([(4, split), (9, intruder)]);
    let source = "let f = function\n    | Left -> 1\n    | Right -> 2\n";
    assert_eq!(
        qualify_ambiguous_union_branches(source, &index, &deps(&[4, 9]), &[4, 9], |p| format!(
            "P{p}"
        )),
        source
    );
}

#[test]
fn dependency_root_duplicate_without_intruder_is_canonical() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let mut index = UnionContextIndex::from_provider_sources([(13, shared), (21, shared)]);
    index.provider_dependencies.insert(21, deps(&[13]));
    let source = "let f = function\n    | Left -> 1\n    | Right -> 2\n";
    let rewritten =
        qualify_ambiguous_union_branches(source, &index, &deps(&[13, 21]), &[13, 21], |provider| {
            format!("P{provider}")
        });
    assert!(rewritten.contains("| P13.Left -> 1"));
    assert!(rewritten.contains("| P13.Right -> 2"));
}

#[test]
fn duplicate_union_type_annotations_use_dependency_root() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let mut index = UnionContextIndex::from_provider_sources([(13, shared), (21, shared)]);
    index.provider_dependencies.insert(21, deps(&[13]));
    let source = "let f (x:T) : T = x // T stays comment\n";
    let rewritten = qualify_duplicate_union_type_annotations(
        source,
        &index,
        30,
        &deps(&[13, 21]),
        |provider| format!("P{provider}"),
    );
    assert_eq!(
        rewritten,
        "let f (x:P13.T) : P13.T = x // T stays comment\n"
    );
}

#[test]
fn lexical_module_owner_beats_dependency_root_for_duplicate_union() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let mut index = UnionContextIndex::from_scoped_provider_sources([
        (13, Some("Root"), shared),
        (21, Some("Local"), shared),
    ]);
    index.provider_dependencies.insert(21, deps(&[13]));
    let annotated = qualify_duplicate_union_type_annotations_scoped(
        "let f (x:T) : T = x\n",
        &index,
        30,
        &deps(&[13, 21]),
        Some("Local"),
        |provider| format!("P{provider}"),
    );
    assert_eq!(annotated, "let f (x:P21.T) : P21.T = x\n");
    let branched = qualify_ambiguous_union_branches_scoped(
        "let f = function\n    | Left -> 1\n    | Right -> 2\n",
        &index,
        30,
        &deps(&[13, 21]),
        &[13, 21],
        Some("Local"),
        |provider| format!("P{provider}"),
    );
    assert!(branched.contains("| P21.Left -> 1"));
    assert!(branched.contains("| P21.Right -> 2"));
}

#[test]
fn same_shard_duplicate_union_owner_stays_local_and_unqualified() {
    let shared = "type T =\n    | Left\n    | Right\n";
    let mut index = UnionContextIndex::from_scoped_provider_sources([
        (13, Some("Root"), shared),
        (21, Some("Local"), shared),
    ]);
    index.provider_dependencies.insert(21, deps(&[13]));
    let annotated = qualify_duplicate_union_type_annotations_scoped(
        "let f (x:T) : T = x\n",
        &index,
        21,
        &deps(&[13]),
        None,
        |provider| format!("P{provider}"),
    );
    assert_eq!(annotated, "let f (x:T) : T = x\n");
    let source = "let f = function\n    | Left -> 1\n    | Right -> 2\n";
    let branched = qualify_ambiguous_union_branches_scoped(
        source,
        &index,
        21,
        &deps(&[13]),
        &[13],
        None,
        |provider| format!("P{provider}"),
    );
    assert_eq!(branched, source);
}

#[test]
fn unavailable_owner_is_never_introduced() {
    let intended = "type T =\n    | Left\n    | Right\n";
    let intruder = "type U =\n    | Left of int\n";
    let index = UnionContextIndex::from_provider_sources([(4, intended), (9, intruder)]);
    let source = "let f = function\n    | Left -> 1\n    | Right -> 2\n";
    assert_eq!(
        qualify_ambiguous_union_branches(source, &index, &deps(&[9]), &[9], |p| format!("P{p}")),
        source
    );
}

#[test]
fn union_nested_in_a_whole_module_declaration_keeps_its_match_local() {
    let shared = "type R =\n    | TailEnd\n    | Local of int\n";
    let mut index = UnionContextIndex::from_scoped_provider_sources([
        (3, Some("CodegenC"), shared),
        (5, Some("CodegenCpp"), shared),
    ]);
    index.provider_dependencies.insert(5, deps(&[3]));
    index
        .nested_local_cases
        .entry(7)
        .or_default()
        .extend(parse_union_groups(&format!("module Py =\n    {}", shared.replace('\n', "\n    ")), 7, None, None)
            .into_iter()
            .map(|group| group.cases));
    let source = "let f r =\n    match r with\n    | TailEnd -> 1\n    | Local x -> x\n";
    let branched = qualify_ambiguous_union_branches_scoped(
        source,
        &index,
        7,
        &deps(&[3, 5]),
        &[3, 5],
        None,
        |provider| format!("P{provider}"),
    );
    assert_eq!(branched, source);
}