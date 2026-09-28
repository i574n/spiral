if 3L <> 3L || 2L <> 2L || 2L <> 2L || 7L <> 7L then failwith "exact-linear-indexed-conditional-runtime-mismatch"
if 7L <> 7L || 2L <> 2L || 7L <> 7L || 2L <> 2L then failwith "exact-linear-indexed-conditional-small-step-runtime-mismatch"
if 7L <> 7L || 7L <> 7L || 7L <> 7L || 4L <> 4L then failwith "exact-linear-indexed-conditional-guard-step-runtime-mismatch"
let v0 : int64 = 1L + 0L
let v1 : int64 = 1L + v0
let v2 : int64 = 1L + v1
let v3 : int64 = 1L + v2
if v3 <> 4L then failwith "exact-linear-indexed-Application-argument-depth-four-mismatch"
let v4 : int64 = 1L + 0L
let v5 : int64 = 1L + v4
let v6 : int64 = 1L + v5
let v7 : int64 = 1L + v6
if v7 <> 4L then failwith "exact-linear-indexed-Application-argument-depth-four-mismatch"
let v8 : int64 = 1L + 0L
let v9 : int64 = 0L + v8
let v10 : int64 = 1L + 0L
let v11 : int64 = v9 + v10
let v12 : int64 = 1L + 0L
let v13 : int64 = 1L + v12
let v14 : int64 = 1L + v13
let v15 : int64 = 1L + 0L
let v16 : int64 = 1L + v15
let v17 : int64 = 1L + v16
if 0L <> 0L || v17 <> 3L || v14 <> 3L then failwith "exact-linear-recursive-indexed-variable-renaming-runtime-mismatch"
let v18 : int64 = 1L + 0L
let v19 : int64 = 1L + v18
let v20 : int64 = 1L + v19
let v21 : int64 = 1L + 0L
let v22 : int64 = 1L + v21
let v23 : int64 = 1L + v22
let v24 : int64 = 1L + 0L
let v25 : int64 = 1L + v24
let v26 : int64 = 1L + v25
let v27 : int64 = 1L + 0L
let v28 : int64 = 1L + 0L
let v29 : int64 = 1L + v28
let v30 : int64 = v27 + v29
if 0L <> 0L || v20 <> 3L || v23 <> v20 || v26 <> 3L || v30 <> v26 then failwith "exact-linear-indexed-variable-renaming-composition-runtime-mismatch"
let v31 : int64 = 1L + 0L
let v32 : int64 = 1L + v31
let v33 : int64 = 1L + 0L
let v34 : int64 = 1L + 0L
let v35 : int64 = 1L + v34
let v36 : int64 = 1L + 0L
let v37 : int64 = v35 + v36
if v32 <> 2L || v33 <> 1L || v37 <> 3L then failwith "exact-linear-indexed-unit-bool-weakened-tensor-runtime-mismatch"
let v38 : int64 = 1L + 0L
let v39 : int64 = 1L + 0L
let v40 : int64 = 1L + v39
let v41 : int64 = 1L + 0L
let v42 : int64 = 1L + 0L
let v43 : int64 = 1L + v42
let v44 : int64 = v41 + v43
if v38 <> 1L || v40 <> 2L || v44 <> 3L then failwith "exact-linear-indexed-Bool-application-weakened-runtime-mismatch"
if 0L <> 0L then failwith "exact-linear-indexed-weakened-identity-lambda-runtime-mismatch"
if 0L <> 0L || 2L <> 2L then failwith "exact-linear-indexed-two-step-weakened-identity-lambda-runtime-mismatch"
if 0L <> 0L || 2L <> 2L then failwith "exact-linear-indexed-two-step-weakened-identity-lambda-runtime-mismatch"
let v45 : int64 = 1L + 0L
let v46 : int64 = 1L + v45
if v46 <> 2L then failwith "exact-linear-indexed-arbitrary-outer-lambda-plan-runtime-mismatch"
let v47 : int64 = 1L + 0L
let v48 : int64 = 1L + v47
let v49 : int64 = 1L + 0L
let v50 : int64 = 1L + 0L
let v51 : int64 = v49 + v50
if v48 <> 2L || v51 <> v48 || 0L <> 0L || 0L <> 0L || 2L <> 2L || 2L <> 2L then failwith "exact-linear-indexed-outer-weakening-composition-runtime-mismatch"
let v52 : int64 = 1L + 0L
let v53 : int64 = 1L + v52
let v54 : int64 = 1L + v53
let v55 : int64 = 1L + 0L
let v56 : int64 = 1L + v55
let v57 : int64 = 1L + v56
let v58 : int64 = 1L + 0L
let v59 : int64 = 1L + v58
let v60 : int64 = 1L + v59
let v61 : int64 = 1L + 0L
let v62 : int64 = 1L + v61
let v63 : int64 = 1L + v62
if v60 <> 3L || v63 <> v60 || 0L <> 0L || 0L <> 0L || v54 <> 3L || v57 <> v54 then failwith "exact-linear-indexed-outer-weakening-associativity-runtime-mismatch"
let v64 : int64 = 1L + 1L
let v65 : int64 = v64 + 1L
let v66 : int64 = 1L + v65
let v67 : int64 = 1L + 1L
let v68 : int64 = 1L + v67
let v69 : int64 = 1L + 1L
let v70 : int64 = 1L + v69
let v71 : int64 = 1L + v70
let v72 : int64 = v71 + 1L
let v73 : int64 = 1L + v72
let v74 : int64 = 1L + 1L
let v75 : int64 = 1L + v74
let v76 : int64 = 1L + 1L
let v77 : int64 = 1L + v76
let v78 : int64 = 1L + 1L
let v79 : int64 = 1L + v78
let v80 : int64 = 1L + v79
let v81 : int64 = v80 + 1L
let v82 : int64 = 1L + v81
let v83 : int64 = 1L + 1L
let v84 : int64 = 1L + v83
let v85 : int64 = 1L + 1L
let v86 : int64 = 1L + v85
let v87 : int64 = 1L + v86
let v88 : int64 = 1L + v87
let v89 : int64 = v88 + 1L
let v90 : int64 = 1L + v89
let v91 : int64 = 1L + 1L
let v92 : int64 = 1L + v91
let v93 : int64 = 1L + v92
let v94 : int64 = 1L + v93
let v95 : int64 = v94 + 1L
let v96 : int64 = 1L + v95
let v97 : int64 = 1L + v96
let v98 : int64 = v97 + 1L
let v99 : int64 = 1L + v98
let v100 : int64 = 1L + 1L
let v101 : int64 = 1L + v100
let v102 : int64 = 1L + v101
let v103 : int64 = 1L + v102
let v104 : int64 = v103 + 1L
let v105 : int64 = 1L + v104
if 1L <> 1L || v66 <> 4L || 1L <> 1L || v68 <> 3L || v73 <> 6L || v75 <> 3L || v77 <> 3L || v82 <> 6L || v84 <> 3L || v90 <> 7L || v99 <> 10L || v105 <> 7L then failwith "exact-linear-indexed-closed-recursive-beta-materialization-runtime-mismatch"
let v106 : int64 = 1L + 1L
let v107 : int64 = 1L + v106
let v108 : int64 = 1L + v107
let v109 : int64 = 1L + v108
let v110 : int64 = v109 + 1L
let v111 : int64 = 1L + v110
let v112 : int64 = 1L + 1L
let v113 : int64 = 1L + v112
let v114 : int64 = 1L + v113
if 1L <> 1L || 6L <> 6L || v111 <> 7L || v114 <> 4L || v111 - v114 <> 3L then failwith "exact-linear-indexed-nested-lambda-substitution-runtime-mismatch"
let v115 : int64 = 1L + 1L
let v116 : int64 = 1L + v115
let v117 : int64 = 1L + v116
let v118 : int64 = 1L + v117
let v119 : int64 = 1L + 1L
let v120 : int64 = v118 + v119
let v121 : int64 = 1L + v120
let v122 : int64 = 1L + 1L
let v123 : int64 = v122 + 1L
let v124 : int64 = 1L + v123
let v125 : int64 = 1L + v124
let v126 : int64 = 1L + 1L
let v127 : int64 = v126 + 1L
let v128 : int64 = 1L + v127
if 1L <> 1L || 6L <> 6L || v121 <> 8L || v125 <> 5L || 1L <> 1L || v128 <> 4L || v121 - v125 <> 3L then failwith "exact-linear-indexed-application-lambda-substitution-runtime-mismatch"
let v129 : int64 = 1L + 1L
let v130 : int64 = 1L + v129
let v131 : int64 = 1L + v130
let v132 : int64 = 1L + v131
let v133 : int64 = 1L + 1L
let v134 : int64 = v132 + v133
let v135 : int64 = 1L + v134
let v136 : int64 = 1L + 1L
let v137 : int64 = v136 + 1L
let v138 : int64 = 1L + v137
let v139 : int64 = 1L + v138
if 1L <> 1L || 6L <> 6L || v135 <> 8L || v139 <> 5L || 1L <> 1L || 1L <> 1L then failwith "exact-linear-indexed-application-lambda-substitution-preservation-runtime-mismatch"
let v140 : string = "the-public-Self-main-now-invokes-membership-indexed-lambdas-the-shared-expression-surface-a-total-all-used-fold-an-all-membership-spine-runtime-closed-versus-affine-evidence-a-generic-type-indexed-two-cell-application-family-a-source-derived-application-argument-projection-one-source-derived-binder-crossing-a-total-generic-membership-weakening-rule-an-application-renaming-one-total-expression-renaming-over-all-five-active-constructors-a-two-step-composition-a-recursive-source-to-target-renaming-chain-interpreter-and-an-indexed-renaming-append-law-and-left-right-identity-laws-plus-a-recursive-renaming-plan-for-the-source-derived-substitution-target-and-an-active-AST-expression-derived-from-that-target-before-the-same-total-renaming-interpreter-runs-plus-left-and-right-renaming-identity-laws-over-that-derived-substitution-expression-where-composed-sequential-and-identity-extended-application-preserve-the-same-slots-types-usage-and-resource-distinctness-across-arbitrary-finite-extension-plans-plus-one-recursive-Term-Gamma-usage-A-family-with-context-aligned-usage-indices-a-lambda-that-consumes-its-newest-binder-and-a-merge-relation-without-Used-Used-plus-an-all-used-index-with-a-fully-used-wrapper-for-arbitrary-contexts-and-a-distinct-closed-wrapper-restricted-to-the-empty-context-both-linked-to-the-exact-term-usage-plus-a-generic-one-cell-variable-renaming-that-weakens-membership-and-single-use-in-lockstep-plus-a-two-variable-Unit-Bool-tensor-that-reuses-that-renaming-and-whose-disjoint-single-use-merge-produces-the-same-allUsed-index-consumed-by-closedness-plus-a-recursive-indexed-variable-renaming-plan-that-moves-membership-and-single-use-in-lockstep-across-three-heterogeneous-context-extensions-and-materializes-the-target-Term-from-those-derived-indices-plus-a-structural-composition-operator-whose-one-cell-prefix-and-two-cell-suffix-agree-with-the-direct-three-cell-plan-at-membership-single-use-and-Term-indices-plus-a-composite-Unit-Bool-tensor-renaming-that-renames-both-variable-children-and-lifts-their-disjoint-usage-merge-with-one-UnusedUnused-head-plus-a-composite-Bool-application-renaming-that-moves-the-function-and-argument-variables-and-their-disjoint-usage-merge-through-the-same-one-cell-extension-plus-a-binder-crossing-renaming-of-the-existing-indexed-Unit-identity-lambda-that-keeps-the-bound-variable-at-slot-zero-used-once-and-the-added-outer-Bool-resource-unused-plus-a-second-sequential-binder-crossing-that-adds-another-unused-outer-Unit-resource-while-preserving-the-same-bound-slot-and-single-use-index-plus-one-recursive-arbitrary-outer-weakening-plan-that-materializes-the-same-indexed-Unit-identity-lambda-under-any-finite-sequence-of-free-context-extensions-and-derives-every-outer-usage-cell-as-Unused-plus-a-structural-composition-operator-whose-Bool-prefix-and-Unit-suffix-agree-with-the-direct-two-step-plan-in-bound-slot-and-derived-Unused-cells-plus-an-indexed-associativity-law-whose-two-parenthesizations-of-three-heterogeneous-one-cell-outer-plans-preserve-bound-slot-zero-and-three-derived-Unused-cells-plus-a-source-derived-closed-Unit-identity-beta-step-whose-constructor-accepts-only-the-argument-and-rebuilds-the-exact-indexed-identity-application-so-an-arbitrary-function-cannot-be-relabelled-as-f-x-to-x-plus-one-polymorphic-existential-identity-beta-step-that-hides-the-shared-argument-domain-codomain-and-target-type-and-closes-both-Unit-and-Bool-fixtures-plus-one-capture-avoiding-indexed-substitution-step-that-crosses-a-real-Tensor-body-rebuilds-the-disjoint-usage-merge-by-construction-and-closes-for-both-Unit-and-composite-Unit-Bool-tensor-arguments-plus-one-nested-lambda-substitution-step-where-an-outer-linear-Unit-used-once-beside-the-inner-bound-Bool-is-replaced-by-a-closed-Unit-weakened-under-that-binder-while-the-bound-Bool-remains-slot-zero-and-used-once-and-the-source-application-shrinks-from-seven-to-four-nodes-with-all-usage-merges-rebuilt-by-construction-plus-one-higher-order-application-under-lambda-substitution-where-a-closed-Bool-identity-replaces-the-linear-outer-function-is-weakened-under-the-inner-Bool-binder-and-rebuilds-a-four-node-application-body-so-the-source-eight-node-beta-application-reduces-to-a-five-node-target-lambda-with-usage-merges-derived-by-construction-plus-one-single-source-step-that-carries-only-the-closed-Bool-identity-witness-derives-both-source-and-target-and-packages-each-with-its-exact-empty-context-allUsed-proof-so-closedness-and-type-preservation-are-construction-invariants-plus-an-arbitrary-finite-recursive-program-of-such-closed-preservation-steps-whose-fold-derives-every-source-target-and-closedness-cell-before-aggregating-two-eight-to-five-node-reductions-without-caller-supplied-targets-plus-one-total-identity-substitution-defined-by-structural-recursion-over-all-seven-active-Term-constructors-that-preserves-context-usage-and-type-indices-by-construction-plus-one-total-nonidentity-Bool-literal-replacement-over-those-same-seven-constructors-that-replaces-every-BoolTrue-by-BoolFalse-while-preserving-the-exact-context-usage-type-and-structure-indices-plus-the-specialized-source-derived-choice-and-recursive-Bool-substitution-corridors-are-physically-retired-after-zero-consumer-preflight-and-one-recursive-open-typed-substitution-covers-Variable-Tensor-Application-and-Lambda-with-its-own-linear-usage-plus-one-recursive-term-strengthening-relation-covers-all-seven-active-Term-constructors-and-one-active-proof-composes-Variable-Bool-Tensor-Application-and-Lambda-while-removing-one-Unused-context-cell-plus-one-source-derived-substitution-to-strengthening-composition-family-shares-the-open-Unit-intermediate-through-Variable-both-Tensor-positions-both-Application-positions-and-Lambda-outer-with-the-bound-variable-preserved-and-the-open-replacement-lifted-without-capture-plus-one-canonical-reduction-family-now-connects-Conditional-fixed-open-beta-a-type-parametric-open-identity-beta-instantiated-at-Unit-and-Bool-and-one-type-parametric-open-Tensor-beta-whose-bound-left-child-is-substituted-while-BoolTrue-is-strengthened-with-source-contractum-and-local-preservation-derived-by-construction-while-Application-Lambda-and-Conditional-beta-bodies-now-share-source-derived-contracta-and-one-inductive-preservation-function-covering-all-three-Conditional-rules-and-every-canonical-beta-rule-plus-one-source-derived-value-family-for-Unit-Bool-and-Lambda-one-Unit-canonical-form-eliminator-one-Bool-True-or-False-canonical-form-eliminator-one-closed-progress-witness-that-distinguishes-values-from-an-existing-Conditional-reduction-and-one-recursive-closed-Bool-Conditional-normalization-certificate-that-derives-the-source-canonical-result-and-step-count-for-arbitrarily-nested-guards-plus-one-normalization-backed-linked-authority-that-derives-its-source-final-Bool-value-and-progress-without-a-public-disconnected-trace-plus-one-covered-closed-normalizing-fragment-that-derives-source-progress-final-canonical-value-and-a-non-False-type-witness-with-no-constructor-for-the-empty-False-type-plus-no-active-no-closed-False-eliminator-because-the-empty-match-candidate-is-quarantined-after-compiler-rejection-and-a-structural-positive-elimination-over-the-entire-canonical-empty-context-empty-usage-Term-family-is-still-required-while-universal-progress-general-Application-progress-beta-congruence-confluence-and-strong-normalization-remain-open-sealed"
v140
