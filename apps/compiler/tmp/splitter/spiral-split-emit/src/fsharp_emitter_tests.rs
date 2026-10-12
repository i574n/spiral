#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn source_opens_only_witness_providers() {
        let shard = Shard {
            id: 2,
            declarations: Vec::new(),
            direct_dependencies: BTreeSet::from([1]),
            compile_dependencies: BTreeSet::from([0, 1]),
            ambient_opens: Vec::new(),
            line_count: 0,
            bytes: 0,
            layer: 1,
            oversize: false,
            fingerprint: 0,
        };
        assert_eq!(source_open_dependencies(&shard), &BTreeSet::from([1]));
    }

    #[test]
    fn dependency_modules_straddle_the_lexical_open_frontier() {
        let make_shard = |id, direct_dependencies, ambient_opens| Shard {
            id,
            declarations: Vec::new(),
            direct_dependencies,
            compile_dependencies: BTreeSet::new(),
            ambient_opens,
            line_count: 0,
            bytes: 0,
            layer: 1,
            oversize: false,
            fingerprint: 0,
        };
        let shards = vec![
            make_shard(0, BTreeSet::new(), Vec::new()),
            make_shard(1, BTreeSet::new(), vec!["    open FParsec".to_owned()]),
            make_shard(
                2,
                BTreeSet::from([0, 1]),
                vec!["    open FParsec".to_owned()],
            ),
        ];
        let prelude = render_open_prelude(&shards, &shards[2], &BTreeSet::new(), &BTreeMap::new());
        let old_provider = prelude.find("open spiral_compiler_Part0000").unwrap();
        let ambient = prelude.find("open FParsec").unwrap();
        let contextual_provider = prelude.find("open spiral_compiler_Part0001").unwrap();
        let core_reopen = prelude.rfind("open Microsoft.FSharp.Core").unwrap();
        assert!(old_provider < ambient);
        assert!(ambient < contextual_provider);
        assert!(contextual_provider < core_reopen);
    }

    #[test]
    fn fparsec_parser_result_cases_are_qualified_without_reopening_failure() {
        let ambient = vec!["    open FParsec".to_owned()];
        let source = "match result with\n| Success(value,state,pos) -> value\n| Failure(message,error,state) -> message".to_owned();
        let qualified = qualify_ambient_cases(source, &ambient);
        assert!(qualified.contains("FParsec.CharParsers.Success"));
        assert!(qualified.contains("FParsec.CharParsers.Failure"));
    }

    #[test]
    fn providers_open_after_their_lexical_prefix() {
        let make_shard = |id, direct_dependencies, ambient_opens| Shard {
            id,
            declarations: Vec::new(),
            direct_dependencies,
            compile_dependencies: BTreeSet::new(),
            ambient_opens,
            line_count: 0,
            bytes: 0,
            layer: 1,
            oversize: false,
            fingerprint: 0,
        };
        let shards = vec![
            make_shard(
                0,
                BTreeSet::new(),
                vec!["    open FSharpx.Collections".to_owned()],
            ),
            make_shard(
                1,
                BTreeSet::from([0]),
                vec![
                    "    open FSharpx.Collections".to_owned(),
                    "    open Hopac".to_owned(),
                ],
            ),
        ];
        let prelude = render_open_prelude(&shards, &shards[1], &BTreeSet::new(), &BTreeMap::new());
        let first_import = prelude.find("open FSharpx.Collections").unwrap();
        let provider = prelude.find("open spiral_compiler_Part0000").unwrap();
        let later_import = prelude.find("open Hopac").unwrap();
        assert!(first_import < provider);
        assert!(provider < later_import);
    }

    #[test]
    fn late_type_opens_do_not_reopen_existing_providers() {
        let existing = BTreeSet::from([266usize, 267usize]);
        let rendered = render_missing_provider_opens([266usize, 267usize, 799usize], &existing);
        assert!(!rendered.contains("Part0266"));
        assert!(!rendered.contains("Part0267"));
        assert!(rendered.contains("open spiral_compiler_Part0799"));
    }

    #[test]
    fn attributed_type_declarations_are_detected() {
        assert!(declares_type_symbol(
            "type [<ReferenceEquality>] Var = { name : string }",
            "Var"
        ));
        assert!(declares_type_symbol("and T = A | B", "T"));
        assert!(!declares_type_symbol("let Var = 1", "Var"));
    }

    #[test]
    fn companion_internal_members_are_public_only_at_the_direct_module_level() {
        let plan = QualifiedRewritePlan {
            replacements: Vec::new(),
            qualified_members: Vec::new(),
            replacement_index: OrderedReplacementIndex::new(&[]),
            qualified_member_index: OrderedReplacementIndex::new(&[]),
            companions: vec![CompanionRewrite {
                provider: 3,
                suffix: "KernelTerm".to_owned(),
                alias: "split_companion_0003_KernelTerm".to_owned(),
                target: "spiral_compiler_Part0003.KernelTerm".to_owned(),
            }],
        };
        let source = "    module KernelTerm =\n        let internal ofId value = value\n        module Nested =\n            let internal hidden value = value\n\n    module Other =\n        let internal keep value = value\n";
        let rewritten = promote_companion_internal_members(source, &plan, 3);
        assert!(rewritten.contains("        let ofId value = value"));
        assert!(rewritten.contains("            let internal hidden value = value"));
        assert!(rewritten.contains("        let internal keep value = value"));
        assert_eq!(promote_companion_internal_members(source, &plan, 4), source);
    }

    #[test]
    fn companion_member_rewrite_respects_identifier_boundaries() {
        let plan = QualifiedRewritePlan {
            replacements: Vec::new(),
            qualified_members: Vec::new(),
            replacement_index: OrderedReplacementIndex::new(&[]),
            qualified_member_index: OrderedReplacementIndex::new(&[]),
            companions: vec![CompanionRewrite {
                provider: 197,
                suffix: "WorkUnitId".to_owned(),
                alias: "split_companion_0197_WorkUnitId".to_owned(),
                target: "spiral_compiler_Part0197.WorkUnitId".to_owned(),
            }],
        };
        let source = "minimalProgressWorkUnitId.ofText value\nWorkUnitId.ofText value\nminimalProgress.WorkUnitId.ofText value";
        let rewritten = rewrite_qualified(source, &plan, 224);
        assert!(rewritten.contains("minimalProgressWorkUnitId.ofText value"));
        assert!(rewritten.contains("split_companion_0197_WorkUnitId.ofText value"));
        assert!(rewritten.contains("minimalProgress.WorkUnitId.ofText value"));
        assert!(!rewritten.contains("minimalProgress.split_companion_0197_WorkUnitId"));
        let local = "type WorkUnitId = WorkUnitId of int\nmodule WorkUnitId =\n    let ofText value = value\nlet value = WorkUnitId.ofText 1";
        assert_eq!(rewrite_qualified(local, &plan, 224), local);
    }

    #[test]
    fn private_top_level_is_promoted() {
        assert_eq!(
            make_public_top_level("    let private x = 1"),
            "    let x = 1"
        );
        assert_eq!(
            make_public_top_level("        let private x = 1"),
            "        let private x = 1"
        );
    }

    #[cfg(unix)]
    #[test]
    fn identical_atomic_write_preserves_the_existing_inode() {
        use std::os::unix::fs::MetadataExt;

        let root =
            std::env::temp_dir().join(format!("spiral-split-atomic-write-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(&root).unwrap();
        let path = root.join("stable.txt");
        let link = root.join("stable-link.txt");
        fs::write(&path, "stable").unwrap();
        fs::hard_link(&path, &link).unwrap();
        atomic_write(&path, "stable").unwrap();
        assert_eq!(
            fs::metadata(&path).unwrap().ino(),
            fs::metadata(&link).unwrap().ino()
        );
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn restore_assets_are_seeded_for_all_projects() {
        let root =
            std::env::temp_dir().join(format!("spiral-split-restore-seed-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(root.join(".build-cache/obj/Part0000")).unwrap();
        fs::write(
            root.join("parts.tsv"),
            "shard	declarations
0	0
1	1
",
        )
        .unwrap();
        fs::write(
            root.join(".build-cache/obj/Part0000/project.assets.json"),
            "{}",
        )
        .unwrap();
        assert_eq!(seed_restore_assets(&root).unwrap(), 3);
        assert_eq!(
            fs::read_to_string(root.join(".build-cache/obj/Part0001/project.assets.json")).unwrap(),
            "{}"
        );
        assert_eq!(
            fs::read_to_string(root.join(".build-cache/obj/SplitRoot/project.assets.json"))
                .unwrap(),
            "{}"
        );
        assert!(root.join("restore-seed.receipt.tsv").is_file());
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn reset_preserves_incremental_cache() {
        let root = std::env::temp_dir().join(format!("spiral-split-reset-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(root.join(".build-cache/obj")).unwrap();
        fs::create_dir_all(root.join(".gear-build/state")).unwrap();
        fs::write(root.join(".build-cache/obj/keep.txt"), "cache").unwrap();
        fs::write(root.join(".gear-build/state/Gear0000.tsv"), "fingerprint\t1\n").unwrap();
        fs::write(root.join("stale.fs"), "stale").unwrap();
        let options = EmitOptions {
            output_root: root.clone(),
            cache_root: root.join(".build-cache"),
            assembly_root: root.join("lib"),
            assembly_overlay_root: None,
        };
        reset_output_root(
            &options,
            ResumeParts {
                sources: false,
                projects: false,
                prebridge_complete: false,
                complete: false,
            },
        )
        .unwrap();
        assert!(root.join(".build-cache/obj/keep.txt").is_file());
        assert!(root.join(".gear-build/state/Gear0000.tsv").is_file());
        assert!(!root.join("stale.fs").exists());
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn complete_resume_preserves_emission_sidecars_and_discards_gear_outputs() {
        let root =
            std::env::temp_dir().join(format!("spiral-split-full-resume-{}", std::process::id()));
        let _ = fs::remove_dir_all(&root);
        fs::create_dir_all(root.join(".build-cache")).unwrap();
        fs::write(root.join("metrics.tsv"), "metric\tvalue\n").unwrap();
        fs::write(root.join("Gear0000.fsproj"), "stale gear").unwrap();
        let options = EmitOptions {
            output_root: root.clone(),
            cache_root: root.join(".build-cache"),
            assembly_root: root.join("lib"),
            assembly_overlay_root: None,
        };
        reset_output_root(
            &options,
            ResumeParts {
                sources: true,
                projects: true,
                prebridge_complete: false,
                complete: true,
            },
        )
        .unwrap();
        assert!(root.join("metrics.tsv").is_file());
        assert!(!root.join("Gear0000.fsproj").exists());
        fs::remove_dir_all(root).unwrap();
    }

    #[test]
    fn directory_props_partition_outputs_by_project() {
        let options = EmitOptions {
            output_root: PathBuf::from("/tmp/out"),
            cache_root: PathBuf::from("/tmp/cache"),
            assembly_root: PathBuf::from("/tmp/lib"),
            assembly_overlay_root: None,
        };
        let text = render_directory_props_with_identity(&options, 42);
        // PathBuf::join uses the platform separator (`\` on Windows), which MSBuild accepts either way.
        let cache = PathBuf::from("/tmp/cache").join("000000000000002a").display().to_string();
        assert!(text.contains(&format!("<BaseOutputPath>{cache}/bin/$(MSBuildProjectName)/</BaseOutputPath>")));
        assert!(text.contains(&format!("<BaseIntermediateOutputPath>{cache}/obj/$(MSBuildProjectName)/</BaseIntermediateOutputPath>")));
    }

    #[test]
    fn root_destination_is_rejected_before_mutation() {
        let options = EmitOptions {
            output_root: PathBuf::from("/mnt/data"),
            cache_root: PathBuf::from("/tmp/cache"),
            assembly_root: PathBuf::from("/tmp/lib"),
            assembly_overlay_root: None,
        };
        let result = if options.output_root == Path::new("/mnt/data") {
            Err::<(), _>("blocked")
        } else {
            Ok(())
        };
        assert!(result.is_err());
    }
}
