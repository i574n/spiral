#[cfg(test)]
mod tests {
    use super::*;
    use spiral_split_model::{
        CompilerProfile, DeclarationId, ReferenceMode, Shard, SourceText, SplitPolicy,
    };

    fn shard(id: usize, layer: usize, lines: usize, dependencies: &[usize]) -> Shard {
        Shard {
            id,
            declarations: vec![DeclarationId(id)],
            direct_dependencies: dependencies.iter().copied().collect(),
            compile_dependencies: dependencies.iter().copied().collect(),
            ambient_opens: Vec::new(),
            line_count: lines,
            bytes: lines * 10,
            layer,
            oversize: false,
            fingerprint: id as u64 + 1,
        }
    }

    fn plan(shards: Vec<Shard>) -> SplitPlan {
        SplitPlan {
            source: SourceText {
                path: PathBuf::from("test.fs"),
                lines: Vec::new(),
                module_line: 0,
                module_name: "spiral_compiler".to_owned(),
                profile: CompilerProfile::PortableFork,
                fingerprint: 1,
                bytes: 1,
            },
            policy: SplitPolicy::Declaration,
            reference_mode: ReferenceMode::Closure,
            declarations: Vec::new(),
            shards,
        }
    }

    #[test]
    fn independent_teeth_pack_inside_the_same_layer() {
        let split = plan(vec![
            shard(0, 1, 400, &[]),
            shard(1, 1, 500, &[]),
            shard(2, 2, 300, &[0, 1]),
        ]);
        let gears = plan_gears(
            &split,
            GearPolicy {
                target_lines: 1_000,
                max_lines: 1_100,
                max_teeth: 8,
                packing: GearPacking::Layer,
                ..GearPolicy::default()
            },
        )
        .expect("gears");
        assert_eq!(gears.gears.len(), 3);
        assert_eq!(gears.gears[0].shards, vec![0]);
        assert_eq!(gears.gears[1].shards, vec![1]);
        assert_eq!(gears.gears[2].dependencies, BTreeSet::from([0, 1]));
    }

    #[test]
    fn critical_path_objective_prefers_width_before_assembly_count() {
        let split = plan(vec![
            shard(0, 1, 800, &[]),
            shard(1, 1, 700, &[]),
            shard(2, 1, 300, &[]),
            shard(3, 1, 200, &[]),
        ]);
        let gears = plan_gears(
            &split,
            GearPolicy {
                target_lines: 1_000,
                max_lines: 1_000,
                max_teeth: 8,
                packing: GearPacking::Layer,
                ..GearPolicy::default()
            },
        )
        .expect("balanced antichain");
        assert_eq!(gears.gears.len(), 3);
        assert_eq!(gears.gears[0].shards, vec![0]);
        assert_eq!(gears.gears[1].shards, vec![1]);
        assert_eq!(gears.gears[2].shards, vec![2, 3]);
        assert_eq!(
            gears
                .gears
                .iter()
                .map(|gear| gear.lines)
                .collect::<Vec<_>>(),
            vec![800, 700, 500]
        );
        let metrics = measure_gears(&split, &gears);
        assert_eq!(metrics.widest_layer, 3);
        assert_eq!(metrics.barrier_critical_lines, 800);
        assert_eq!(metrics.critical_path_lines, 800);
    }

    #[test]
    fn exclusive_dependency_layers_merge_when_bounded() {
        let split = plan(vec![shard(0, 1, 10, &[]), shard(1, 2, 10, &[0])]);
        let policy = GearPolicy {
            packing: GearPacking::Layer,
            ..GearPolicy::default()
        };
        let gears = plan_gears(&split, policy).expect("gears");
        assert_eq!(gears.gears.len(), 1);
        assert_eq!(gears.gears[0].shards, vec![0, 1]);
        assert_eq!(gears.series_unions, 1);
    }

    #[test]
    fn timeline_packing_fuses_a_serial_chain_into_one_gear() {
        // A chain gains nothing from separate projects; each split would pay the project overhead.
        let split = plan(vec![
            shard(0, 1, 100, &[]),
            shard(1, 2, 100, &[0]),
            shard(2, 3, 100, &[1]),
        ]);
        let gears = plan_gears(&split, GearPolicy::default()).expect("gears");
        assert_eq!(gears.gears.len(), 1);
        assert_eq!(gears.gears[0].shards, vec![0, 1, 2]);
    }

    #[test]
    fn timeline_packing_respects_the_gear_line_cap() {
        let split = plan(vec![shard(0, 1, 2_000, &[]), shard(1, 1, 2_000, &[])]);
        let gears = plan_gears(&split, GearPolicy::default()).expect("gears");
        assert!(gears.gears.iter().all(|gear| gear.lines <= GearPolicy::default().max_lines));
        assert_eq!(gears.gears.len(), 2);
    }

    #[test]
    fn stored_layers_are_recomputed_from_compile_dependencies() {
        let split = plan(vec![shard(0, 12, 10, &[]), shard(1, 11, 10, &[0])]);
        let gears = plan_gears(
            &split,
            GearPolicy {
                target_lines: 10,
                max_lines: 15,
                max_teeth: 8,
                ..GearPolicy::default()
            },
        )
        .expect("gears");
        assert_eq!(gears.gears.len(), 2);
        assert_eq!(gears.gears[0].source_layer, 0);
        assert_eq!(gears.gears[1].source_layer, 1);
        assert_eq!(gears.gears[1].dependencies, BTreeSet::from([0]));
    }

    #[test]
    fn forward_dependencies_are_topologically_relayered() {
        let split = plan(vec![shard(0, 4, 10, &[1]), shard(1, 3, 10, &[])]);
        let gears = plan_gears(
            &split,
            GearPolicy {
                target_lines: 10,
                max_lines: 15,
                max_teeth: 8,
                ..GearPolicy::default()
            },
        )
        .expect("gears");
        assert_eq!(gears.gears.len(), 2);
        assert_eq!(gears.gears[0].shards, vec![1]);
        assert_eq!(gears.gears[1].shards, vec![0]);
        assert_eq!(gears.gears[1].dependencies, BTreeSet::from([0]));
    }

    #[test]
    fn emitted_generated_dependency_is_replanned_before_packing() {
        let root = std::env::temp_dir().join(format!(
            "spiral-gears-generated-replan-{}",
            std::process::id()
        ));
        let _ = std::fs::remove_dir_all(&root);
        std::fs::create_dir_all(&root).expect("root");
        std::fs::write(
            root.join("Part0000.fs"),
            "module spiral_compiler_Part0000\nlet consume (x : spiral_compiler_Part0001.T) = x\n",
        )
        .expect("consumer");
        std::fs::write(
            root.join("Part0001.fs"),
            "module spiral_compiler_Part0001\ntype T = int\n",
        )
        .expect("provider");
        let split = plan(vec![shard(0, 0, 10, &[]), shard(1, 0, 10, &[])]);
        let (effective, gears, added) = replan_with_generated_dependencies(
            &split,
            &root,
            GearPolicy {
                target_lines: 10,
                max_lines: 15,
                max_teeth: 8,
                ..GearPolicy::default()
            },
            &BridgeReport::default(),
        )
        .expect("generated replan");
        assert_eq!(added, 1);
        assert_eq!(effective.shards[0].compile_dependencies, BTreeSet::from([1]));
        assert_eq!(gears.gears.len(), 2);
        assert_eq!(gears.gears[0].shards, vec![1]);
        assert_eq!(gears.gears[1].shards, vec![0]);
        assert_eq!(gears.gears[1].dependencies, BTreeSet::from([0]));
        std::fs::remove_dir_all(root).expect("cleanup");
    }

    #[test]
    fn compile_dependency_cycles_become_indivisible_gears() {
        let split = plan(vec![shard(0, 0, 10, &[1]), shard(1, 0, 10, &[0])]);
        let gears = plan_gears(&split, GearPolicy::default()).expect("cycle condensed");
        assert_eq!(gears.gears.len(), 1);
        assert_eq!(gears.gears[0].shards, vec![0, 1]);
        assert_eq!(gears.cyclic_sccs, 1);
        assert_eq!(gears.max_scc_shards, 2);
    }

    #[test]
    fn project_orders_teeth_by_in_gear_dependencies() {
        let split = plan(vec![
            shard(0, 1, 30, &[1, 2]),
            shard(1, 1, 30, &[]),
            shard(2, 1, 30, &[]),
        ]);
        let gear = Gear {
            id: 5,
            source_layer: 2,
            shards: vec![0, 1, 2],
            dependencies: BTreeSet::from([3, 4]),
            lines: 90,
            bytes: 900,
            fingerprint: 1,
            oversize: false,
            origin: GearOrigin::Layer { source_layer: 2 },
        };
        let project = render_gear_project(&split, &gear, &[]);
        let consumer = project.find("Part0000.fs").expect("consumer");
        let provider_a = project.find("Part0001.fs").expect("provider 1");
        let provider_b = project.find("Part0002.fs").expect("provider 2");
        assert!(provider_a < consumer && provider_b < consumer);
        assert!(project.contains("Gear0003.fsproj"));
        assert!(project.contains("Gear0004.fsproj"));
    }

    #[test]
    fn project_reference_closure_carries_transitive_signature_assemblies() {
        let split = plan(vec![
            shard(0, 2, 10, &[1]),
            shard(1, 1, 10, &[2]),
            shard(2, 0, 10, &[]),
        ]);
        let gears = plan_gears(
            &split,
            GearPolicy {
                target_lines: 1,
                max_lines: 1,
                max_teeth: 1,
                ..GearPolicy::default()
            },
        )
        .expect("gears");
        let consumer = gears
            .gears
            .iter()
            .find(|gear| gear.shards.contains(&0))
            .expect("consumer gear");
        assert_eq!(consumer.dependencies.len(), 1);
        let direct = *consumer.dependencies.iter().next().expect("direct dependency");
        let transitive = *gears.gears[direct]
            .dependencies
            .iter()
            .next()
            .expect("transitive dependency");
        assert!(!consumer.dependencies.contains(&transitive));
        let project_dependencies = compile_reference_dependencies(&gears, consumer);
        assert!(project_dependencies.contains(&direct));
        assert!(project_dependencies.contains(&transitive));
        let project = render_gear_project_with_dependencies(
            &split,
            consumer,
            &project_dependencies,
            &[],
        );
        assert!(project.contains(&format!("{}.fsproj", gear_name(direct))));
        assert!(project.contains(&format!("{}.fsproj", gear_name(transitive))));
    }

    #[test]
    fn build_project_compiles_layers_without_dependency_graph_traversal() {
        let split = plan(vec![shard(0, 1, 10, &[]), shard(1, 2, 10, &[0])]);
        let gears = plan_gears(
            &split,
            GearPolicy {
                target_lines: 10,
                max_lines: 15,
                max_teeth: 8,
                ..GearPolicy::default()
            },
        )
        .expect("gears");
        let project = render_gear_build_project(&gears);
        assert!(project.contains("BuildLayer0000"));
        assert!(project.contains("BuildLayer0001"));
        assert!(project.contains("BuildProjectReferences=false"));
        assert!(project.contains("BuildInParallel=\"true\""));
        assert!(project.contains("GearRoot.fsproj"));
    }
}
