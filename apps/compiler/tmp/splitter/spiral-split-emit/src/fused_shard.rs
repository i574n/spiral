fn rewrite_qualified(text: &str, plan: &QualifiedRewritePlan, current_shard: usize) -> String {
    let member_rewritten = plan
        .qualified_member_index
        .apply(text, &plan.qualified_members);
    let rewritten = plan
        .replacement_index
        .apply(&member_rewritten, &plan.replacements);
    plan.companions
        .iter()
        .filter(|companion| {
            companion.provider != current_shard && !declares_type_symbol(text, &companion.suffix)
        })
        .fold(rewritten, |text, companion| {
            replace_companion_member_access(&text, &companion.suffix, &companion.alias)
        })
}

pub struct FusedRenderIndex<'a> {
    rewrite_plan: QualifiedRewritePlan,
    split_source_modules: BTreeSet<&'a str>,
    type_providers: BTreeMap<String, usize>,
    late_type_open_index: LateTypeOpenIndex,
    typed_by_shard: BTreeMap<usize, BTreeSet<usize>>,
    caller_parameter_types: BTreeMap<DeclarationId, Vec<CallerParameterType>>,
    higher_order_array_returns: BTreeMap<DeclarationId, Vec<HigherOrderArrayReturnShape>>,
    caller_contract_providers: BTreeMap<usize, Vec<usize>>,
    pattern_owner_witnesses: BTreeMap<DeclarationId, Vec<PatternOwnerWitness>>,
    local_record_owner_witnesses: BTreeMap<DeclarationId, Vec<LocalRecordOwnerWitness>>,
    record_return_owner_witnesses: BTreeMap<DeclarationId, Vec<RecordReturnOwnerWitness>>,
    numeric_conversion_helpers: BTreeSet<String>,
    union_context: UnionContextIndex,
    lexical_open_index: LexicalOpenIndex,
    declaration_shards: Vec<usize>,
}

impl<'a> FusedRenderIndex<'a> {
    #[must_use]
    pub fn build(plan: &'a SplitPlan) -> Self {
        let rewrite_plan = qualified_replacements(plan);
        let split_source_modules = plan
            .declarations
            .iter()
            .filter_map(|declaration| declaration.scope.module_name())
            .collect::<BTreeSet<_>>();
        let type_providers = unique_type_providers(plan);
        let late_type_open_index = LateTypeOpenIndex::build(plan);
        let typed_by_shard = typed_use_type_providers_by_shard(plan, &type_providers);
        let mut caller_contracts = analyze_caller_contracts(plan, &type_providers);
        let caller_projection_contracts =
            analyze_caller_projection_contracts(plan, &type_providers);
        for (declaration, mut rows) in caller_projection_contracts.parameter_types {
            caller_contracts
                .parameter_types
                .entry(declaration)
                .or_default()
                .append(&mut rows);
        }
        for rows in caller_contracts.parameter_types.values_mut() {
            rows.sort();
            rows.dedup();
        }
        for (shard, providers) in caller_projection_contracts.type_providers_by_shard {
            let target = caller_contracts
                .type_providers_by_shard
                .entry(shard)
                .or_default();
            target.extend(providers);
            target.sort_unstable();
            target.dedup();
        }
        let forwarded_binding_contracts = analyze_forwarded_binding_contracts(
            plan,
            &type_providers,
            &caller_contracts.parameter_types,
        );
        for (declaration, mut rows) in forwarded_binding_contracts.parameter_types {
            caller_contracts
                .parameter_types
                .entry(declaration)
                .or_default()
                .append(&mut rows);
        }
        for (shard, providers) in forwarded_binding_contracts.type_providers_by_shard {
            let target = caller_contracts
                .type_providers_by_shard
                .entry(shard)
                .or_default();
            target.extend(providers);
            target.sort_unstable();
            target.dedup();
        }
        for rows in caller_contracts.parameter_types.values_mut() {
            rows.sort();
            rows.dedup();
        }
        let higher_order_array_returns = analyze_higher_order_array_returns(plan);
        let pattern_owner_witnesses = analyze_pattern_record_owners(plan);
        let local_record_owner_witnesses = analyze_local_record_owners(plan);
        let record_return_owner_witnesses = analyze_record_return_owners(plan);
        let numeric_conversion_helpers = collect_numeric_conversion_helpers(plan);
        let union_context = analyze_union_context(plan);
        let lexical_open_index = LexicalOpenIndex::build(&union_context);
        Self {
            rewrite_plan,
            split_source_modules,
            type_providers,
            late_type_open_index,
            typed_by_shard,
            caller_parameter_types: caller_contracts.parameter_types,
            higher_order_array_returns,
            caller_contract_providers: caller_contracts.type_providers_by_shard,
            pattern_owner_witnesses,
            local_record_owner_witnesses,
            record_return_owner_witnesses,
            numeric_conversion_helpers,
            union_context,
            lexical_open_index,
            declaration_shards: declaration_shards(plan),
        }
    }

    pub fn render_single(&self, plan: &SplitPlan, shard: usize) -> Result<String, String> {
        let shard = plan
            .shards
            .get(shard)
            .ok_or_else(|| "single render references an unknown shard".to_owned())?;
        let render_context = RenderSourceContext {
            rewrite_plan: &self.rewrite_plan,
            split_source_modules: &self.split_source_modules,
            type_providers: &self.type_providers,
            late_type_open_index: &self.late_type_open_index,
            typed_use_providers: &self.typed_by_shard,
            caller_contract_providers: &self.caller_contract_providers,
            caller_parameter_types: &self.caller_parameter_types,
            higher_order_array_returns: &self.higher_order_array_returns,
            pattern_owner_witnesses: &self.pattern_owner_witnesses,
            local_record_owner_witnesses: &self.local_record_owner_witnesses,
            record_return_owner_witnesses: &self.record_return_owner_witnesses,
            numeric_conversion_helpers: &self.numeric_conversion_helpers,
            union_context: &self.union_context,
            lexical_open_index: &self.lexical_open_index,
            declaration_shards: &self.declaration_shards,
        };
        Ok(render_source(plan, shard, &render_context))
    }

    #[must_use]
    pub fn companion_count(&self) -> usize {
        self.rewrite_plan.companions.len()
    }

    pub fn render(
        &self,
        plan: &SplitPlan,
        shards: &[usize],
    ) -> Result<(usize, String), String> {
        let Some(representative) = shards.iter().copied().min() else {
            return Err("cannot render an empty cyclic shard group".to_owned());
        };
        let members = shards.iter().copied().collect::<BTreeSet<_>>();
        if members.iter().any(|shard| *shard >= plan.shards.len()) {
            return Err("cyclic shard group contains an unknown shard".to_owned());
        }

        let mut declarations = members
            .iter()
            .flat_map(|shard| plan.shards[*shard].declarations.iter().copied())
            .collect::<Vec<_>>();
        declarations.sort_by_key(|declaration| declaration.0);
        declarations.dedup();
        let direct_dependencies = members
            .iter()
            .flat_map(|shard| plan.shards[*shard].direct_dependencies.iter().copied())
            .filter(|dependency| !members.contains(dependency))
            .collect::<BTreeSet<_>>();
        let compile_dependencies = members
            .iter()
            .flat_map(|shard| plan.shards[*shard].compile_dependencies.iter().copied())
            .filter(|dependency| !members.contains(dependency))
            .collect::<BTreeSet<_>>();
        let mut ambient_opens = Vec::new();
        let mut seen_opens = BTreeSet::new();
        for shard in &members {
            for open in &plan.shards[*shard].ambient_opens {
                if seen_opens.insert(open.clone()) {
                    ambient_opens.push(open.clone());
                }
            }
        }
        let fused = Shard {
            id: representative,
            declarations,
            direct_dependencies,
            compile_dependencies,
            ambient_opens,
            line_count: members
                .iter()
                .map(|shard| plan.shards[*shard].line_count)
                .sum(),
            bytes: members.iter().map(|shard| plan.shards[*shard].bytes).sum(),
            layer: members
                .iter()
                .map(|shard| plan.shards[*shard].layer)
                .min()
                .unwrap_or(0),
            oversize: members.iter().any(|shard| plan.shards[*shard].oversize),
            fingerprint: members.iter().fold(0u64, |fingerprint, shard| {
                fingerprint
                    ^ plan.shards[*shard]
                        .fingerprint
                        .rotate_left((*shard % 64) as u32)
            }),
        };

        let mut rewrite_plan = self.rewrite_plan.clone();
        for (_, target) in &mut rewrite_plan.replacements {
            for shard in &members {
                let prefix = format!("{}.", module_name(*shard));
                if let Some(suffix) = target.strip_prefix(&prefix) {
                    *target = suffix.to_owned();
                    break;
                }
            }
        }
        for companion in &mut rewrite_plan.companions {
            if members.contains(&companion.provider) {
                companion.provider = representative;
                companion.target = format!("{}.{}", module_name(representative), companion.suffix);
            }
        }
        let fused_typed = members
            .iter()
            .filter_map(|member| self.typed_by_shard.get(member))
            .flatten()
            .copied()
            .collect::<BTreeSet<_>>();
        let mut typed_use_providers = BTreeMap::new();
        if !fused_typed.is_empty() {
            typed_use_providers.insert(representative, fused_typed);
        }
        let mut seen_caller = BTreeSet::new();
        let fused_caller = members
            .iter()
            .filter_map(|member| self.caller_contract_providers.get(member))
            .flatten()
            .copied()
            .filter(|provider| seen_caller.insert(*provider))
            .collect::<Vec<_>>();
        let mut caller_contract_providers = BTreeMap::new();
        if !fused_caller.is_empty() {
            caller_contract_providers.insert(representative, fused_caller);
        }
        // Members of the fused shard now live in the representative.
        let mut declaration_shards = self.declaration_shards.clone();
        for declaration in &fused.declarations {
            declaration_shards[declaration.0] = representative;
        }
        let render_context = RenderSourceContext {
            declaration_shards: &declaration_shards,
            rewrite_plan: &rewrite_plan,
            split_source_modules: &self.split_source_modules,
            type_providers: &self.type_providers,
            late_type_open_index: &self.late_type_open_index,
            typed_use_providers: &typed_use_providers,
            caller_contract_providers: &caller_contract_providers,
            caller_parameter_types: &self.caller_parameter_types,
            higher_order_array_returns: &self.higher_order_array_returns,
            pattern_owner_witnesses: &self.pattern_owner_witnesses,
            local_record_owner_witnesses: &self.local_record_owner_witnesses,
            record_return_owner_witnesses: &self.record_return_owner_witnesses,
            numeric_conversion_helpers: &self.numeric_conversion_helpers,
            union_context: &self.union_context,
            lexical_open_index: &self.lexical_open_index,
        };
        Ok((representative, render_source(plan, &fused, &render_context)))
    }
}

pub fn render_fused_cyclic_shard_source(
    plan: &SplitPlan,
    shards: &[usize],
) -> Result<(usize, String), String> {
    FusedRenderIndex::build(plan).render(plan, shards)
}
