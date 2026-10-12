use super::*;
use spiral_split_model::{BoundaryReason, DeclarationKind, LineSpan, Raw};

fn set(values: &[&str]) -> BTreeSet<String> {
    values.iter().map(|value| (*value).to_owned()).collect()
}

#[test]
fn owner_parameter_annotations_preserve_typed_capture() {
    let lines = ["and term (s : LangEnv) (x:E) : Data =", "    match x with"];
    let captures = set(&["s", "x"]);
    let annotations = owner_parameter_annotations(&lines, &captures);
    assert_eq!(annotations.get("s").map(String::as_str), Some("LangEnv"));
    assert_eq!(annotations.get("x").map(String::as_str), Some("E"));
}

#[test]
fn source_capture_annotations_recover_only_unambiguous_types() {
    let source = "let outer capture = capture\nlet jp_method_completed_cells =\n    System.Collections.Concurrent.ConcurrentDictionary<Key,Value>()\nlet jp_method_exns : System.Collections.Concurrent.ConcurrentQueue<Failure> =\n    System.Collections.Concurrent.ConcurrentQueue()\nlet ambiguous : First = first\nlet ambiguous : Second = second\n";
    let captures = set(&["jp_method_completed_cells", "jp_method_exns", "ambiguous"]);
    let lines = source.lines().collect::<Vec<_>>();
    let annotations = capture_annotations_from_lines(&lines, &captures);
    assert_eq!(
        annotations
            .get("jp_method_completed_cells")
            .map(String::as_str),
        Some("System.Collections.Concurrent.ConcurrentDictionary<Key,Value>")
    );
    assert_eq!(
        annotations.get("jp_method_exns").map(String::as_str),
        Some("System.Collections.Concurrent.ConcurrentQueue<Failure>")
    );
    assert!(!annotations.contains_key("ambiguous"));
}

fn fixture() -> (String, Declaration<Linked>, LocalGroup, Vec<LocalGroup>) {
    let text = "let outer env x =\n    let helper y = env + y\n    let mutable counter = env\n    let target s x =\n        let local = s + 1\n        match x with\n        | A value ->\n            helper value + local\n        | B value ->\n            value + env\n        | C value ->\n            counter <- value\n            counter\n    target env x\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 15 },
        "let outer env x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let helper = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 3,
        line_count: 1,
        names: set(&["helper"]),
        parameters: set(&["y"]),
        references: set(&["env"]),
        captures: set(&["env"]),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Captures(set(&["env"])),
    };
    let mutable_group = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 1,
        start_line: 3,
        end_line: 4,
        line_count: 1,
        names: set(&["counter"]),
        parameters: BTreeSet::new(),
        references: BTreeSet::new(),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::MutableBinding),
    };
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 2,
        start_line: 4,
        end_line: 14,
        line_count: 10,
        names: set(&["target"]),
        parameters: set(&["s", "x"]),
        references: set(&["helper", "counter"]),
        captures: BTreeSet::new(),
        local_dependencies: set(&[]).into_iter().map(|_| 0usize).collect(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation),
    };
    let mut parent = parent;
    parent.local_dependencies = BTreeSet::from([0, 1]);
    let groups = vec![helper, mutable_group, parent.clone()];
    (text.to_owned(), owner, parent, groups)
}

#[test]
fn owner_body_match_can_be_rewritten() {
    let text =
        "let outer x =\n    match x with\n    | A value -> value + 1\n    | B value -> value\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 5 },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let plan = analyze_owner_match_branches(&owner, &[]).expect("owner match plan");
    assert_eq!(plan.parent, MatchParent::OwnerBody);
    let artifact =
        rewrite_owner_match_branches_with_annotations(text, &owner, &[], &[0], &BTreeMap::new())
            .expect("owner match rewrite");
    assert_eq!(artifact.parent, MatchParent::OwnerBody);
    assert!(artifact.final_source.contains("__spiral_match_0_body_0"));
}

#[test]
fn bounded_owner_match_prefers_largest_naturally_partitioned_match() {
    let text = "let outer x =\n    match x with\n    | A value ->\n        let y = value + 1\n        match y with\n        | 0 -> 0\n        | 1 -> 1\n        | _ -> 2\n        y\n    | B -> 0\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let ordinary = analyze_owner_match_branches(&owner, &[]).expect("ordinary match plan");
    assert_eq!(ordinary.match_line, 2);
    let bounded = analyze_owner_bounded_match_branches(&owner, &[], 3).expect("bounded match plan");
    assert_eq!(bounded.match_line, 5);
    assert_eq!(bounded.branches.len(), 3);
    assert!(bounded.branches.iter().all(|branch| branch.line_count <= 3));
}

#[test]
fn bounded_complex_subject_is_aliased_without_re_evaluation() {
    let text = "let outer x =\n    match x with\n    | A value ->\n        match classify value, other value with\n        | Some a, Some b -> a + b\n        | _ -> 0\n        value\n    | B -> 0\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let plan =
        analyze_owner_bounded_match_branches(&owner, &[], 2).expect("bounded complex match plan");
    assert_eq!(plan.match_line, 4);
    let artifact = rewrite_owner_bounded_match_branches_with_annotations(
        text,
        &owner,
        &[],
        2,
        &[0, 1],
        &BTreeMap::new(),
    )
    .expect("bounded complex rewrite");
    assert!(
        artifact
            .owner_text
            .contains("as __spiral_match_subject_0_4_0")
    );
    assert!(
        artifact
            .hoisted_text
            .contains("match __spiral_match_subject_0_4_0 with")
    );
    assert_eq!(
        artifact
            .final_source
            .matches("classify value, other value")
            .count(),
        1
    );
}

#[test]
fn bounded_anonymous_function_cases_are_partitionable_without_reapplying_input() {
    let source = "let outer req env =\n    req >>- function\n        | A x ->\n            consume env x\n            consume env x\n        | B y ->\n            consume env y\n            consume env y\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + source.lines().count(),
        },
        "let outer req env =".to_owned(),
        source.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(source.as_bytes()),
    )
    .restage();
    let plan = analyze_owner_bounded_match_branches(&owner, &[], 10).expect("plan");
    assert_eq!(plan.subject, "");
    assert_eq!(plan.branches.len(), 2);
    assert!(
        plan.branches
            .iter()
            .all(|branch| matches!(branch.disposition, BranchDisposition::Extractable))
    );
    let artifact = rewrite_owner_bounded_match_branches_with_annotations(
        source,
        &owner,
        &[],
        10,
        &[0, 1],
        &BTreeMap::new(),
    )
    .expect("rewrite");
    assert_eq!(artifact.final_source.matches("req >>- function").count(), 1);
    assert!(
        artifact
            .final_source
            .contains("((A x) as __spiral_match_subject_")
    );
    assert!(
        artifact
            .final_source
            .contains("((B y) as __spiral_match_subject_")
    );
}

#[test]
fn multiline_or_pattern_is_one_branch_and_aliases_the_whole_rule() {
    let source = "let outer x =\n    match classify x, other x with\n    | First(a,b), _\n    | Second(a,b,_), _ ->\n        a + b\n    | _ -> 0\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + source.lines().count(),
        },
        "let outer x =".to_owned(),
        source.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(source.as_bytes()),
    )
    .restage();
    let plan = analyze_owner_bounded_match_branches(&owner, &[], 10).expect("or-pattern plan");
    assert_eq!(plan.branches.len(), 2);
    assert_eq!(plan.branches[0].pattern, "First(a,b), _ | Second(a,b,_), _");
    let artifact = rewrite_owner_bounded_match_branches_with_annotations(
        source,
        &owner,
        &[],
        10,
        &[0],
        &BTreeMap::new(),
    )
    .expect("or-pattern rewrite");
    assert!(
        artifact
            .owner_text
            .contains("((First(a,b), _ | Second(a,b,_), _) as __spiral_match_subject_0_2_0)")
    );
    assert_eq!(artifact.owner_text.matches("First(a,b)").count(), 1);
    assert_eq!(artifact.owner_text.matches("Second(a,b,_)").count(), 1);
}

#[test]
fn owner_body_match_ignores_leading_doc_comments() {
    let text = "/// owner documentation\nlet outer x =\n    match x with\n    | A value -> value + 1\n    | B value -> value\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 6 },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let plan = analyze_owner_match_branches(&owner, &[]).expect("owner match plan");
    assert_eq!(plan.parent, MatchParent::OwnerBody);
    let artifact =
        rewrite_owner_match_branches_with_annotations(text, &owner, &[], &[0], &BTreeMap::new())
            .expect("owner match rewrite");
    assert_eq!(artifact.parent, MatchParent::OwnerBody);
    assert!(artifact.final_source.contains("__spiral_match_0_body_0"));
}

#[test]
fn already_extracted_match_does_not_hide_later_match() {
    let text = "let outer x =\n    match x with\n    | A -> __spiral_match_0_body_0 x\n    | B -> __spiral_match_0_body_1 x\n    match x with\n    | C -> 1\n    | D -> 2\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 8 },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let plan = analyze_owner_match_branches(&owner, &[]).expect("later owner match plan");
    assert_eq!(plan.match_line, 5);
    assert_eq!(plan.branches[0].pattern, "C");
    assert_eq!(plan.branches[1].pattern, "D");
}

#[test]
fn qualified_member_before_local_shadow_is_not_outer_capture() {
    let text = "let outer x =\n    let mutable current = 1\n    match x with\n    | A ->\n        let generation = CacheGeneration.current ()\n        [1] |> List.fold (fun current value -> current + value) 0\n    | B -> current\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let (groups, _) = spiral_split_lift::analyze_owner_lifts(&owner);
    let plan = analyze_owner_match_branches(&owner, &groups).expect("owner match plan");
    assert!(!plan.branches[0].captures.contains("current"));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
}

#[test]
fn qualified_member_name_alone_is_not_outer_mutable_capture() {
    let text = "let outer x =\n    let mutable current = 1\n    match x with\n    | A -> CacheGeneration.current ()\n    | B -> current\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let (groups, _) = spiral_split_lift::analyze_owner_lifts(&owner);
    let plan = analyze_owner_match_branches(&owner, &groups).expect("owner match plan");
    assert!(!plan.branches[0].captures.contains("current"));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
}

#[test]
fn local_function_parameter_does_not_reopen_outer_mutable_capture() {
    let text = "let outer x =\n    let mutable t = 1\n    match x with\n    | A ->\n        let is_positive t = t > 0\n        is_positive 1\n    | B -> t\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let (groups, _) = spiral_split_lift::analyze_owner_lifts(&owner);
    let plan = analyze_owner_match_branches(&owner, &groups).expect("owner match plan");
    assert!(!plan.branches[0].captures.contains("t"));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
}

#[test]
fn infers_only_trivial_mutable_literal_types() {
    assert_eq!(
        mutable_binding_type("    let mutable waited = 0", "waited").as_deref(),
        Some("int")
    );
    assert_eq!(
        mutable_binding_type("    let mutable ready = false", "ready").as_deref(),
        Some("bool")
    );
    assert_eq!(
        mutable_binding_type("    let mutable x = make_value ()", "x"),
        None
    );
}

#[test]
fn enclosing_case_bindings_feed_nested_match_captures() {
    let lines = [
        "    try",
        "        work ()",
        "    with",
        "    | Other _ ->",
        "        ignore 0",
        "    | Deferred(decision, deferralReservation) ->",
        "        let suspendResult = suspend ()",
        "        match suspendResult with",
        "        | Ok _ -> deferralReservation",
        "        | Error _ -> decision",
    ];
    assert_eq!(
        enclosing_case_bindings(&lines, 7),
        set(&["decision", "deferralReservation"])
    );
}

#[test]
fn assignment_detection_respects_identifier_boundaries() {
    assert!(capture_is_assigned("s <- next", "s"));
    assert!(capture_is_assigned("    s    <- next", "s"));
    assert!(!capture_is_assigned("replay_s <- next", "s"));
    assert!(!capture_is_assigned("xs <- rest", "s"));
    assert!(!capture_is_assigned("obj.s <- value", "s"));
}

#[test]
fn enclosing_for_binder_is_available_to_nested_match_branch() {
    let lines = [
        "    for index = 0 to steps.Length - 1 do",
        "        let stepResult = runStep index",
        "        match stepResult with",
        "        | DB -> index",
        "        | _ -> -1",
    ];
    let bound = enclosing_loop_bindings(&lines, 2);
    assert_eq!(bound, BTreeSet::from(["index".to_owned()]));
}

#[test]
fn outer_loop_binder_is_captured_when_parent_local_starts_inside_loop() {
    let text = "let outer steps =\n    for index = 0 to steps.Length - 1 do\n        let target stepResult =\n            match stepResult with\n            | DB ->\n                ignore index\n            | _ -> ()\n        target steps.[index]\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 9 },
        "let outer steps =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 3,
        end_line: 8,
        line_count: 5,
        names: set(&["target"]),
        parameters: set(&["stepResult"]),
        references: set(&["index"]),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation),
    };
    let groups = vec![parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("nested loop match plan");
    assert!(plan.branches[0].captures.contains("index"));
}

#[test]
fn nested_local_function_parameters_feed_match_branch_captures() {
    let text = "let outer root =\n    let target item =\n        let retire\n            suspendedCursor\n            durationMs =\n            let terminalRetirement = classify item\n            match terminalRetirement with\n            | Some result -> suspendedCursor, durationMs, result\n            | None -> suspendedCursor, durationMs, item\n        retire root 1L\n    target root\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 12 },
        "let outer root =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 11,
        line_count: 9,
        names: set(&["target"]),
        parameters: set(&["item"]),
        references: BTreeSet::new(),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation),
    };
    let groups = vec![parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups)
        .expect("nested local parameter match plan");
    assert!(plan.branches[0].captures.contains("suspendedCursor"));
    assert!(plan.branches[0].captures.contains("durationMs"));
}

#[test]
fn enclosing_sequential_values_feed_nested_match_branch_captures() {
    let text = "let outer root =\n    let cse = makeCse root\n    let path = makePath root\n    let parent = makeParent root\n    let continuationRef = makeRef root\n    let h = makeH root\n    for i = 0 to 1 do\n        let target item =\n            match item with\n            | Some value ->\n                consume cse i path parent continuationRef h value\n            | None -> ()\n        target root\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 14 },
        "let outer root =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 8,
        end_line: 13,
        line_count: 5,
        names: set(&["target"]),
        parameters: set(&["item"]),
        references: BTreeSet::new(),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::RecursiveContinuation),
    };
    let groups = vec![parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups)
        .expect("nested sequential-value match plan");
    for name in ["cse", "i", "path", "parent", "continuationRef", "h"] {
        assert!(plan.branches[0].captures.contains(name), "missing {name}");
    }
}

#[test]
fn discovers_direct_case_captures_and_blocks_mutable_capture() {
    let (_, owner, parent, groups) = fixture();
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert_eq!(plan.subject, "x");
    assert_eq!(plan.branches.len(), 3);
    assert!(plan.branches[0].captures.contains("helper"));
    assert!(plan.branches[0].captures.contains("local"));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
    assert!(matches!(
        plan.branches[2].disposition,
        BranchDisposition::Blocked(BranchBlocker::MutableCapture { .. })
    ));
}

#[test]
fn preserves_guard_in_caller_and_excludes_guard_only_captures() {
    let text = "let outer limit env x =\n    let target x =\n        match x with\n        | Some value when value > limit ->\n            value + env\n        | None ->\n            env\n    target x\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 9 },
        "let outer limit env x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 8,
        line_count: 6,
        names: set(&["target"]),
        parameters: set(&["x"]),
        references: set(&["env", "limit"]),
        captures: set(&["env", "limit"]),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Captures(set(&["env", "limit"])),
    };
    let groups = vec![parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert_eq!(plan.branches[0].pattern, "Some value");
    assert_eq!(plan.branches[0].guard.as_deref(), Some("value > limit"));
    assert_eq!(plan.branches[0].captures, set(&["env"]));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));

    let artifact = rewrite_match_branches(text, &owner, &parent, &groups, &[0]).expect("rewrite");
    assert!(
        artifact
            .owner_text
            .contains("| Some value when value > limit -> __spiral_match_0_0_0 env x")
    );
    assert!(
        artifact
            .hoisted_text
            .contains("let private __spiral_match_0_0_0 env x =")
    );
    assert!(artifact.hoisted_text.contains("| Some value ->"));
    assert!(
        !artifact
            .hoisted_text
            .contains("__spiral_match_0_0_0 env limit x")
    );
}

#[test]
fn rewrites_typed_mutable_capture_as_byref() {
    let text = "let outer x =\n    let mutable seen : int option = None\n    let target x =\n        match x with\n        | Some value when value > 0 ->\n            seen <- Some value\n            value\n        | None ->\n            0\n    target x\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 11 },
        "let outer x =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let mutable_group = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 3,
        line_count: 1,
        names: set(&["seen"]),
        parameters: BTreeSet::new(),
        references: BTreeSet::new(),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Unsupported(UnsupportedReason::MutableBinding),
    };
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 1,
        start_line: 3,
        end_line: 10,
        line_count: 7,
        names: set(&["target"]),
        parameters: set(&["x"]),
        references: set(&["seen"]),
        captures: set(&["seen"]),
        local_dependencies: BTreeSet::from([0]),
        disposition: LiftDisposition::Captures(set(&["seen"])),
    };
    let groups = vec![mutable_group, parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert_eq!(
        plan.branches[0]
            .mutable_captures
            .get("seen")
            .map(String::as_str),
        Some("int option")
    );
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
    let artifact = rewrite_match_branches(text, &owner, &parent, &groups, &[0]).expect("rewrite");
    assert!(
        artifact
            .hoisted_text
            .contains("(seen: byref<int option>) x =")
    );
    assert!(artifact.owner_text.contains("&seen x"));
    assert!(artifact.hoisted_text.contains("seen <- Some value"));
}

#[test]
fn rewrites_multiple_branches_into_parallel_helpers() {
    let (source, owner, parent, groups) = fixture();
    let artifact =
        rewrite_match_branches(&source, &owner, &parent, &groups, &[0, 1]).expect("rewrite");
    assert_eq!(artifact.helper_count, 2);
    assert!(artifact.hoisted_text.contains("__spiral_match_0_2_0"));
    assert!(artifact.hoisted_text.contains("__spiral_match_0_2_1"));
    assert!(
        artifact
            .owner_text
            .contains("| A value -> __spiral_match_0_2_0")
    );
    assert!(
        artifact
            .owner_text
            .contains("| B value -> __spiral_match_0_2_1")
    );
    assert!(artifact.owner_text.contains("counter <- value"));
}

#[test]
fn captures_owner_parameters_and_mirrors_guard_without_guard_capture() {
    let text = "let outer tag input =\n    let target input =\n        match input with\n        | Some value when Helpers.is_ready value.status ->\n            tag + value.payload\n        | None ->\n            tag\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 9 },
        "let outer tag input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 8,
        line_count: 6,
        names: set(&["target"]),
        parameters: set(&["input"]),
        references: set(&["tag"]),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Captures(set(&["tag"])),
    };
    let groups = vec![parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert!(plan.branches[0].captures.contains("tag"));
    assert!(plan.branches[0].mirror_guard);
    let artifact = rewrite_match_branches(text, &owner, &parent, &groups, &[0]).expect("rewrite");
    assert!(artifact.owner_text.contains(
        "| Some value when Helpers.is_ready value.status -> __spiral_match_0_0_0 tag input"
    ));
    assert!(
        artifact
            .hoisted_text
            .contains("let private __spiral_match_0_0_0 tag input =")
    );
    assert!(
        artifact
            .hoisted_text
            .contains("| Some value when Helpers.is_ready value.status ->")
    );
}

#[test]
fn non_recursive_same_name_local_binding_keeps_outer_capture() {
    let text = "let outer s input =\n    let target input =\n        match input with\n        | Some r ->\n            consume (fun () ->\n                let s = add_trace s r\n                s)\n            consume s\n        | None ->\n            s\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 12 },
        "let outer s input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 11,
        line_count: 9,
        names: set(&["target"]),
        parameters: set(&["input"]),
        references: set(&["s"]),
        captures: set(&["s"]),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Captures(set(&["s"])),
    };
    let groups = vec![parent.clone()];
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert!(plan.branches[0].captures.contains("s"));
    let artifact = rewrite_match_branches(text, &owner, &parent, &groups, &[0]).expect("rewrite");
    assert!(
        artifact
            .hoisted_text
            .contains("let private __spiral_match_0_0_0 s input =")
    );
    assert!(
        artifact
            .owner_text
            .contains("| Some r -> __spiral_match_0_0_0 s input")
    );
}

#[test]
fn annotates_pattern_binding_only_in_hoisted_helper() {
    let text = "let outer tag input =\n    let target input =\n        match input with\n        | Some value when Helpers.is_ready value.status ->\n            tag + value.payload\n        | None ->\n            tag\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 9 },
        "let outer tag input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 8,
        line_count: 6,
        names: set(&["target"]),
        parameters: set(&["input"]),
        references: set(&["tag"]),
        captures: BTreeSet::new(),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Captures(set(&["tag"])),
    };
    let groups = vec![parent.clone()];
    let annotations = BTreeMap::from([(
        0,
        MatchPatternAnnotation {
            binding: "value".to_owned(),
            owner_type: "EvalWorklist.Frame".to_owned(),
        },
    )]);
    let artifact =
        rewrite_match_branches_with_annotations(text, &owner, &parent, &groups, &[0], &annotations)
            .expect("rewrite");
    assert!(
        artifact
            .hoisted_text
            .contains("| Some (value: EvalWorklist.Frame) when Helpers.is_ready value.status ->")
    );
    assert!(artifact.owner_text.contains(
        "| Some value when Helpers.is_ready value.status -> __spiral_match_0_0_0 tag input"
    ));
}

#[test]
fn annotates_capture_parameter_only_in_hoisted_helper() {
    let text = "let outer item input =\n    let target input =\n        match input with\n        | Cancelled cancellation ->\n            item.commitOrdinal + item.generation + cancellation\n        | Other ->\n            0\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan { start: 1, end: 9 },
        "let outer item input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let parent = LocalGroup {
        owner: DeclarationId(0),
        owner_heading: "outer".to_owned(),
        local_index: 0,
        start_line: 2,
        end_line: 8,
        line_count: 6,
        names: set(&["target"]),
        parameters: set(&["input"]),
        references: set(&["item"]),
        captures: set(&["item"]),
        local_dependencies: BTreeSet::new(),
        disposition: LiftDisposition::Captures(set(&["item"])),
    };
    let groups = vec![parent.clone()];
    let annotations = BTreeMap::from([(
        0,
        MatchPatternAnnotation {
            binding: "item".to_owned(),
            owner_type: "EvalWorklist.WorkItem".to_owned(),
        },
    )]);
    let artifact =
        rewrite_match_branches_with_annotations(text, &owner, &parent, &groups, &[0], &annotations)
            .expect("rewrite");
    assert!(
        artifact
            .hoisted_text
            .contains("let private __spiral_match_0_0_0 (item: EvalWorklist.WorkItem) input =")
    );
    assert!(
        artifact
            .hoisted_text
            .contains("| Cancelled cancellation ->")
    );
    assert!(
        artifact
            .owner_text
            .contains("| Cancelled cancellation -> __spiral_match_0_0_0 item input")
    );
}

#[test]
fn clones_owner_active_pattern_into_hoisted_helper() {
    let text = "let outer ready input =\n    let (|Ready|Pending|) value =\n        if ready value then Ready value else Pending value\n    let target input =\n        match input with\n        | Some value ->\n            match value with\n            | Ready x -> x\n            | Pending x -> x\n        | None ->\n            0\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer ready input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let (groups, _) = spiral_split_lift::analyze_owner_lifts(&owner);
    let parent = groups
        .iter()
        .find(|group| group.names.contains("target"))
        .expect("target group")
        .clone();
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert_eq!(plan.branches[0].captures, set(&["ready"]));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
    let artifact = rewrite_match_branches(text, &owner, &parent, &groups, &[0]).expect("rewrite");
    assert!(
        artifact
            .hoisted_text
            .contains("let private __spiral_match_0_1_0 ready input =")
    );
    assert!(
        artifact
            .hoisted_text
            .contains("let (|Ready|Pending|) value =")
    );
    assert!(!artifact.hoisted_text.contains("__spiral_match_0_1_0 Ready"));
    assert!(
        artifact
            .owner_text
            .contains("| Some value -> __spiral_match_0_1_0 ready input")
    );
}

#[test]
fn closes_active_pattern_provider_dependencies_in_topological_order() {
    let text = "let outer threshold input =\n    let classify value = value > threshold\n    let (|Ready|Pending|) value =\n        if classify value then Ready value else Pending value\n    let target input =\n        match input with\n        | Some value ->\n            match value with\n            | Ready x -> x\n            | Pending x -> x\n        | None ->\n            0\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer threshold input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let (groups, _) = spiral_split_lift::analyze_owner_lifts(&owner);
    let parent = groups
        .iter()
        .find(|group| group.names.contains("target"))
        .expect("target group")
        .clone();
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert_eq!(plan.branches[0].captures, set(&["threshold"]));
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Extractable
    ));
    let artifact = rewrite_match_branches(text, &owner, &parent, &groups, &[0]).expect("rewrite");
    let classify = artifact
        .hoisted_text
        .find("let classify value =")
        .expect("classify");
    let pattern = artifact
        .hoisted_text
        .find("let (|Ready|Pending|) value =")
        .expect("active pattern");
    assert!(classify < pattern);
    assert!(
        artifact
            .hoisted_text
            .contains("let private __spiral_match_0_2_0 threshold input =")
    );
}

#[test]
fn blocks_active_pattern_dependency_on_mutable_local() {
    let text = "let outer threshold input =\n    let mutable classify = fun value -> value > threshold\n    let (|Ready|Pending|) value =\n        if classify value then Ready value else Pending value\n    let target input =\n        match input with\n        | Some value ->\n            match value with\n            | Ready x -> x\n            | Pending x -> x\n        | None ->\n            0\n    target input\n";
    let owner = Declaration::<Raw>::new(
        DeclarationId(0),
        LineSpan {
            start: 1,
            end: 1 + text.lines().count(),
        },
        "let outer threshold input =".to_owned(),
        text.to_owned(),
        BoundaryReason::TopLevel(DeclarationKind::LetGroup),
        Vec::new(),
        fnv1a64(text.as_bytes()),
    )
    .restage();
    let (groups, _) = spiral_split_lift::analyze_owner_lifts(&owner);
    let parent = groups
        .iter()
        .find(|group| group.names.contains("target"))
        .expect("target group")
        .clone();
    let plan = analyze_match_branches(&owner, &parent, &groups).expect("plan");
    assert!(matches!(
        plan.branches[0].disposition,
        BranchDisposition::Blocked(BranchBlocker::ActivePatternDependency { .. })
    ));
}
