mod nested_tests {
    use super::*;

    #[test]
    fn nested_record_field_becomes_provider_owned_alias() {
        let source = "type PrepassTopEnv = {\n    nominals : Map<GlobalId,{|body : TPrepass; name : string|}>\n}\n";
        let aliases = nested_aliases_from_declaration(source, 607);
        assert_eq!(aliases.len(), 1);
        let alias = &aliases[0];
        assert_eq!(alias.name, "SpiralSplitAnon_PrepassTopEnv_nominals");
        assert_eq!(
            alias.fields,
            BTreeSet::from(["body".to_owned(), "name".to_owned()])
        );
        let canonical = canonical_nested_aliases(&aliases);
        let rewritten = rewrite_nested_alias_provider(source, &aliases, &canonical);
        assert!(rewritten.starts_with(
            "type SpiralSplitAnon_PrepassTopEnv_nominals = {|body : TPrepass; name : string|}\n"
        ));
        assert!(
            rewritten.contains("nominals : Map<GlobalId,SpiralSplitAnon_PrepassTopEnv_nominals>")
        );
    }

    #[test]
    fn nested_provider_alias_annotates_nested_consumer_literal() {
        let source = "let f () = {| value = Map.add at {|body=bodyt; name=name|} nominals |}\n";
        let candidate = AnonymousRecordAlias {
            provider_shard: 607,
            name: "SpiralSplitAnon_PrepassTopEnv_nominals".to_owned(),
            fields: BTreeSet::from(["body".to_owned(), "name".to_owned()]),
        };
        let (rewritten, seen, annotations, ambiguities) =
            annotate_source(source, 636, &[candidate], &[]);
        assert!(seen >= 1);
        assert_eq!(annotations.len(), 1);
        assert!(ambiguities.is_empty());
        assert!(
            rewritten
                .contains("({|body=bodyt; name=name|} : SpiralSplitAnon_PrepassTopEnv_nominals)")
        );
    }
}
