mod tests {
    use super::*;

fn alias(name: &str, fields: &[&str]) -> AnonymousRecordAlias {
    AnonymousRecordAlias {
        provider_shard: 3,
        name: name.to_owned(),
        fields: fields.iter().map(|field| (*field).to_owned()).collect(),
    }
}

fn nested_alias(
    provider_shard: usize,
    owner: &str,
    field: &str,
    name: &str,
    anonymous_type: &str,
) -> NestedAnonymousRecordAlias {
    NestedAnonymousRecordAlias {
        provider_shard,
        owner: owner.to_owned(),
        field: field.to_owned(),
        name: name.to_owned(),
        anonymous_type: anonymous_type.to_owned(),
        fields: record_shape(&anonymous_type[2..anonymous_type.len() - 2]).unwrap(),
    }
}

#[test]
fn equivalent_nested_aliases_share_the_earliest_provider_identity() {
    let first = nested_alias(4, "TopEnv", "item", "TopItem", "{| value : int |}");
    let second = nested_alias(9, "PackageEnv", "item", "PackageItem", "{|value:int|}");
    let canonical = canonical_nested_aliases(&[first.clone(), second.clone()]);
    assert_eq!(
        canonical.get(&(second.provider_shard, second.name.clone())),
        Some(&first)
    );
    let input = "    type PackageEnv = {\n        item : {|value:int|}\n    }\n";
    let rewritten = rewrite_nested_alias_provider(input, &[second], &canonical);
    assert!(rewritten.contains("item : spiral_compiler_Part0004.TopItem"));
    assert!(!rewritten.contains("type PackageItem ="));
}

#[test]
fn matching_literal_gets_external_alias_annotation() {
    let source = "let f x = {|vars = x; range = None|}\n";
    let (rewritten, seen, annotations, ambiguities) = annotate_source(
        source,
        9,
        &[alias("PropagatedVarsEnv", &["vars", "range"])],
        &[],
    );
    assert_eq!(seen, 1);
    assert_eq!(annotations.len(), 1);
    assert!(ambiguities.is_empty());
    assert!(rewritten.contains("({|vars = x; range = None|} : PropagatedVarsEnv)"));
}

#[test]
fn untyped_update_literal_is_left_unchanged() {
    let source = "let f x = {|x with vars = Set.empty|}\n";
    let (rewritten, seen, annotations, ambiguities) =
        annotate_source(source, 9, &[alias("PropagatedVarsEnv", &["vars"])], &[]);
    assert_eq!(seen, 1);
    assert!(annotations.is_empty());
    assert!(ambiguities.is_empty());
    assert_eq!(rewritten, source);
}

#[test]
fn typed_update_literal_inherits_external_alias() {
    let source = "let f (a : VSCPos) = {|a with line = a.line + 1|}\n";
    let (rewritten, seen, annotations, ambiguities) =
        annotate_source(source, 9, &[alias("VSCPos", &["character", "line"])], &[]);
    assert_eq!(seen, 1);
    assert_eq!(annotations.len(), 1);
    assert!(ambiguities.is_empty());
    assert!(rewritten.contains("({|a with line = a.line + 1|} : VSCPos)"));
}

#[test]
fn destructured_named_tuple_propagates_element_aliases() {
    let source = "let add line ((a,b) : VSCRange) = {|a with line = line+a.line|}, {|b with line = line+b.line|}\n";
    let tuple_alias = NamedTupleAlias {
        provider_shard: 4,
        name: "VSCRange".to_owned(),
        elements: vec!["VSCPos".to_owned(), "VSCPos".to_owned()],
    };
    let (rewritten, seen, annotations, ambiguities) = annotate_source(
        source,
        9,
        &[alias("VSCPos", &["character", "line"])],
        &[tuple_alias],
    );
    assert_eq!(seen, 2);
    assert_eq!(annotations.len(), 2);
    assert!(ambiguities.is_empty());
    assert_eq!(rewritten.matches(": VSCPos").count(), 2);
}

#[test]
fn parses_named_tuple_aliases() {
    let alias = named_tuple_alias("type VSCRange = VSCPos * VSCPos", 7).unwrap();
    assert_eq!(alias.name, "VSCRange");
    assert_eq!(alias.elements, vec!["VSCPos", "VSCPos"]);
}

#[test]
fn alias_return_expression_is_reconstructed_once() {
    let source = "let inline union_view (h: Union) : UnionView = h.Item\n";
    let (rewritten, seen, annotations, ambiguities) = annotate_source(
        source,
        645,
        &[alias(
            "UnionView",
            &["cases", "layout", "tags", "tag_cases", "is_degenerate"],
        )],
        &[],
    );
    assert_eq!(seen, 1);
    assert_eq!(annotations.len(), 1);
    assert!(ambiguities.is_empty());
    assert!(rewritten.contains("let __spiral_split_bridge_value = h.Item"));
    assert!(rewritten.contains("cases = __spiral_split_bridge_value.cases"));
    assert!(rewritten.contains("|} : UnionView)"));
}

#[test]
fn ambiguous_alias_shape_is_reported_without_rewrite() {
    let source = "let f x = {|value = x|}\n";
    let candidates = [alias("Left", &["value"]), alias("Right", &["value"])];
    let (rewritten, seen, annotations, ambiguities) =
        annotate_source(source, 9, &candidates, &[]);
    assert_eq!(seen, 1);
    assert!(annotations.is_empty());
    assert_eq!(ambiguities.len(), 1);
    assert_eq!(rewritten, source);
}

#[test]
fn wrapper_type_is_not_treated_as_anonymous_record_alias() {
    let source = "type Nominal = {|body : int; name : string|} ConsedNode";
    assert!(alias_from_declaration(source, 4).is_none());
}

#[test]
fn union_case_payload_is_not_treated_as_anonymous_record_alias() {
    let source = "type ProjectCodeAction =\n    | CreateFile of {| filePath : string |}\n    | RenameDirectory of {| dirPath : string; target : string; validate_as_file : bool |}\n";
    assert!(alias_from_declaration(source, 1450).is_none());
}
}
