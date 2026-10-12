type [<Struct>] US0 =
    | US0_BitZero
    | US0_BitOne
and UH0 =
    | UH0_RegexEmpty
    | UH0_RegexEpsilon
    | UH0_RegexChar of US0
    | UH0_RegexAlt of UH0 * UH0
    | UH0_RegexCat of UH0 * UH0
    | UH0_RegexStar of UH0
and [<Struct>] US1 =
    | US1_SymbolLess
    | US1_SymbolSame
    | US1_SymbolGreater
and UH1 =
    | UH1_StateBudgetZero
    | UH1_StateBudgetSucc of UH1
and UH2 =
    | UH2_SymbolListNil
    | UH2_SymbolListCons of US0 * UH2
and UH3 =
    | UH3_RegexListNil
    | UH3_RegexListCons of UH0 * UH3
and [<Struct>] US2 =
    | US2_DfaClosureComplete of f0_0 : UH3
    | US2_DfaClosureBudgetExceeded of f1_0 : UH3
and [<Struct>] US3 =
    | US3_Nullable
    | US3_NonNullable
and [<Struct>] US4 =
    | US4_DfaRepresentativeFound of f0_0 : UH0
    | US4_DfaRepresentativeMissing
and UH4 =
    | UH4_DfaStatePairNil
    | UH4_DfaStatePairCons of UH0 * UH0 * UH4
and UH5 =
    | UH5_InputEmpty
    | UH5_InputCons of US0 * UH5
and UH6 =
    | UH6_DfaConstructivePairTraceNil
    | UH6_DfaConstructivePairTraceCons of UH0 * UH0 * UH5 * UH6
and [<Struct>] US5 =
    | US5_DfaConstructiveEquivalent
    | US5_DfaConstructiveDistinguished of f1_0 : UH5
and UH7 =
    | UH7_InputListNil
    | UH7_InputListCons of UH5 * UH7
and [<Struct>] US6 =
    | US6_TriA
    | US6_TriB
    | US6_TriC
and UH8 =
    | UH8_RegexEmpty
    | UH8_RegexEpsilon
    | UH8_RegexChar of US6
    | UH8_RegexAlt of UH8 * UH8
    | UH8_RegexCat of UH8 * UH8
    | UH8_RegexStar of UH8
and UH9 =
    | UH9_SymbolListNil
    | UH9_SymbolListCons of US6 * UH9
and UH10 =
    | UH10_RegexListNil
    | UH10_RegexListCons of UH8 * UH10
and [<Struct>] US7 =
    | US7_DfaClosureComplete of f0_0 : UH10
    | US7_DfaClosureBudgetExceeded of f1_0 : UH10
and [<Struct>] US8 =
    | US8_DfaRepresentativeFound of f0_0 : UH8
    | US8_DfaRepresentativeMissing
and UH11 =
    | UH11_DfaStatePairNil
    | UH11_DfaStatePairCons of UH8 * UH8 * UH11
and UH12 =
    | UH12_InputEmpty
    | UH12_InputCons of US6 * UH12
and UH13 =
    | UH13_DfaConstructivePairTraceNil
    | UH13_DfaConstructivePairTraceCons of UH8 * UH8 * UH12 * UH13
and [<Struct>] US9 =
    | US9_DfaConstructiveEquivalent
    | US9_DfaConstructiveDistinguished of f1_0 : UH12
and UH14 =
    | UH14_InputListNil
    | UH14_InputListCons of UH12 * UH14
let rec regex_compare_3 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = regex_compare_3(v53, v55)
            match v57 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_3(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_SymbolGreater
    | UH0_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US1 = regex_compare_3(v28, v34)
            match v36 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_3(v29, v35)
            | _ ->
                v36
        | UH0_RegexChar(v32) -> (* RegexChar *)
            US1_SymbolGreater
        | UH0_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH0_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH0_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH0_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US0_BitOne -> (* BitOne *)
                match v13 with
                | US0_BitOne -> (* BitOne *)
                    US1_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US1_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v13 with
                | US0_BitOne -> (* BitOne *)
                    US1_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US1_SymbolSame
        | UH0_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH0_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH0_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH0_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH0_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH0_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH0_RegexStar(v44) -> (* RegexStar *)
        match v1 with
        | UH0_RegexAlt(v45, v46) -> (* RegexAlt *)
            US1_SymbolLess
        | UH0_RegexStar(v48) -> (* RegexStar *)
            regex_compare_3(v44, v48)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_2 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_3(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH0 = alt_insert_sorted_2(v0, v3)
            UH0_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_3(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH0_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_1 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = alt_insert_sorted_2(v2, v1)
        make_alt_1(v3, v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_2(v0, v1)
and regex_equal_5 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_5(v18, v20)
            if v22 then
                regex_equal_5(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_5(v26, v28)
            if v30 then
                regex_equal_5(v27, v29)
            else
                false
        | _ ->
            false
    | UH0_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH0_RegexChar(v5) -> (* RegexChar *)
            let v15 : US1 =
                match v4 with
                | US0_BitOne -> (* BitOne *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolSame
            match v15 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH0_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH0_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH0_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH0_RegexStar(v34) -> (* RegexStar *)
        match v1 with
        | UH0_RegexStar(v35) -> (* RegexStar *)
            regex_equal_5(v34, v35)
        | _ ->
            false
and make_cat_4 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEmpty
    | _ ->
        match v1 with
        | UH0_RegexEmpty -> (* RegexEmpty *)
            UH0_RegexEmpty
        | _ ->
            match v0 with
            | UH0_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH0_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH0_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH0 = make_cat_4(v13, v1)
                        UH0_RegexCat(v12, v14)
                    | UH0_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_5(v4, v5)
                            if v6 then
                                UH0_RegexStar(v4)
                            else
                                UH0_RegexCat(v0, v1)
                        | _ ->
                            UH0_RegexCat(v0, v1)
                    | _ ->
                        UH0_RegexCat(v0, v1)
and make_star_6 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEpsilon
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v3) -> (* RegexStar *)
        UH0_RegexStar(v3)
    | _ ->
        UH0_RegexStar(v0)
and normalize_0 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = normalize_0(v5)
        let v8 : UH0 = normalize_0(v6)
        make_alt_1(v7, v8)
    | UH0_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = normalize_0(v10)
        let v13 : UH0 = normalize_0(v11)
        make_cat_4(v12, v13)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        UH0_RegexChar(v3)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEmpty
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH0 = normalize_0(v15)
        make_star_6(v16)
and state_budget_add_8 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_StateBudgetSucc(v2) -> (* StateBudgetSucc *)
        let v3 : UH1 = state_budget_add_8(v2, v1)
        UH1_StateBudgetSucc(v3)
    | UH1_StateBudgetZero -> (* StateBudgetZero *)
        v1
and regex_position_count_7 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_RegexAlt(v6, v7) -> (* RegexAlt *)
        let v8 : UH1 = regex_position_count_7(v6)
        let v9 : UH1 = regex_position_count_7(v7)
        state_budget_add_8(v8, v9)
    | UH0_RegexCat(v11, v12) -> (* RegexCat *)
        let v13 : UH1 = regex_position_count_7(v11)
        let v14 : UH1 = regex_position_count_7(v12)
        state_budget_add_8(v13, v14)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH1 = UH1_StateBudgetZero
        UH1_StateBudgetSucc(v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH1_StateBudgetZero
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH1_StateBudgetZero
    | UH0_RegexStar(v16) -> (* RegexStar *)
        regex_position_count_7(v16)
and state_budget_add_10 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_StateBudgetSucc(v1) -> (* StateBudgetSucc *)
        let v2 : UH1 = state_budget_add_8(v1, v0)
        UH1_StateBudgetSucc(v2)
    | UH1_StateBudgetZero -> (* StateBudgetZero *)
        v0
and state_budget_pow2_9 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_StateBudgetSucc(v3) -> (* StateBudgetSucc *)
        let v4 : UH1 = state_budget_pow2_9(v3)
        state_budget_add_10(v4)
    | UH1_StateBudgetZero -> (* StateBudgetZero *)
        let v1 : UH1 = UH1_StateBudgetZero
        UH1_StateBudgetSucc(v1)
and nullable_15 (v0 : UH0) : US3 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_15(v5)
        let v8 : US3 = nullable_15(v6)
        match v7 with
        | US3_Nullable -> (* Nullable *)
            US3_Nullable
        | _ ->
            match v8 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                match v7 with
                | US3_NonNullable -> (* NonNullable *)
                    match v8 with
                    | US3_NonNullable -> (* NonNullable *)
                        US3_NonNullable
    | UH0_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US3 = nullable_15(v16)
        let v19 : US3 = nullable_15(v17)
        match v18 with
        | US3_Nullable -> (* Nullable *)
            match v19 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                US3_NonNullable
        | _ ->
            US3_NonNullable
    | UH0_RegexChar(v3) -> (* RegexChar *)
        US3_NonNullable
    | UH0_RegexEmpty -> (* RegexEmpty *)
        US3_NonNullable
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        US3_Nullable
    | UH0_RegexStar(v25) -> (* RegexStar *)
        US3_Nullable
and derivative_14 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_14(v19, v1)
        let v22 : UH0 = derivative_14(v20, v1)
        make_alt_1(v21, v22)
    | UH0_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US3 = nullable_15(v24)
        match v26 with
        | US3_NonNullable -> (* NonNullable *)
            let v31 : UH0 = derivative_14(v24, v1)
            make_cat_4(v31, v25)
        | US3_Nullable -> (* Nullable *)
            let v27 : UH0 = derivative_14(v24, v1)
            let v28 : UH0 = make_cat_4(v27, v25)
            let v29 : UH0 = derivative_14(v25, v1)
            make_alt_1(v28, v29)
    | UH0_RegexChar(v4) -> (* RegexChar *)
        let v14 : US1 =
            match v4 with
            | US0_BitOne -> (* BitOne *)
                match v1 with
                | US0_BitOne -> (* BitOne *)
                    US1_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US1_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v1 with
                | US0_BitOne -> (* BitOne *)
                    US1_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US1_SymbolSame
        let v15 : bool =
            match v14 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH0_RegexEpsilon
        else
            UH0_RegexEmpty
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEmpty
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEmpty
    | UH0_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH0 = derivative_14(v35, v1)
        let v37 : UH0 = make_star_6(v35)
        make_cat_4(v36, v37)
and canonical_derivative_13 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_0(v0)
    let v3 : UH0 = derivative_14(v2, v1)
    normalize_0(v3)
and regex_list_contains_16 (v0 : UH0, v1 : UH3) : bool =
    match v1 with
    | UH3_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_5(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_16(v0, v3)
    | UH3_RegexListNil -> (* RegexListNil *)
        false
and dfa_enqueue_symbols_12 (v0 : UH0, v1 : UH2, v2 : UH3, v3 : UH3) : struct (UH3 * UH3) =
    match v1 with
    | UH2_SymbolListCons(v4, v5) -> (* SymbolListCons *)
        let v6 : UH0 = canonical_derivative_13(v0, v4)
        let v7 : bool = regex_list_contains_16(v6, v2)
        if v7 then
            dfa_enqueue_symbols_12(v0, v5, v2, v3)
        else
            let v10 : UH3 = UH3_RegexListCons(v6, v2)
            let v11 : UH3 = UH3_RegexListCons(v6, v3)
            dfa_enqueue_symbols_12(v0, v5, v10, v11)
    | UH2_SymbolListNil -> (* SymbolListNil *)
        struct (v2, v3)
and dfa_closure_loop_bounded_11 (v0 : UH2, v1 : UH1, v2 : UH3, v3 : UH3) : US2 =
    match v3 with
    | UH3_RegexListCons(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH1_StateBudgetSucc(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH3, v10 : UH3) = dfa_enqueue_symbols_12(v5, v0, v2, v6)
            dfa_closure_loop_bounded_11(v0, v8, v9, v10)
        | UH1_StateBudgetZero -> (* StateBudgetZero *)
            US2_DfaClosureBudgetExceeded(v2)
    | UH3_RegexListNil -> (* RegexListNil *)
        US2_DfaClosureComplete(v2)
and dfa_state_pair_list_contains_20 (v0 : UH0, v1 : UH0, v2 : UH4) : bool =
    match v2 with
    | UH4_DfaStatePairCons(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_5(v0, v3)
        let v11 : bool =
            if v6 then
                regex_equal_5(v1, v4)
            else
                let v8 : bool = regex_equal_5(v0, v4)
                if v8 then
                    regex_equal_5(v1, v3)
                else
                    false
        if v11 then
            true
        else
            dfa_state_pair_list_contains_20(v0, v1, v5)
    | UH4_DfaStatePairNil -> (* DfaStatePairNil *)
        false
and dfa_state_pair_enqueue_symbols_21 (v0 : UH0, v1 : UH0, v2 : UH2, v3 : UH4) : UH4 =
    match v2 with
    | UH2_SymbolListCons(v4, v5) -> (* SymbolListCons *)
        let v6 : UH0 = canonical_derivative_13(v0, v4)
        let v7 : UH0 = canonical_derivative_13(v1, v4)
        let v8 : UH4 = UH4_DfaStatePairCons(v6, v7, v3)
        dfa_state_pair_enqueue_symbols_21(v0, v1, v5, v8)
    | UH2_SymbolListNil -> (* SymbolListNil *)
        v3
and dfa_bisimulation_work_19 (v0 : UH2, v1 : UH4, v2 : UH4) : bool =
    match v1 with
    | UH4_DfaStatePairCons(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_5(v3, v4)
        if v6 then
            dfa_bisimulation_work_19(v0, v5, v2)
        else
            let v8 : bool = dfa_state_pair_list_contains_20(v3, v4, v2)
            if v8 then
                dfa_bisimulation_work_19(v0, v5, v2)
            else
                let v10 : US3 = nullable_15(v3)
                let v11 : US3 = nullable_15(v4)
                let v15 : bool =
                    match v10 with
                    | US3_NonNullable -> (* NonNullable *)
                        match v11 with
                        | US3_NonNullable -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_Nullable -> (* Nullable *)
                        match v11 with
                        | US3_Nullable -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH4 = dfa_state_pair_enqueue_symbols_21(v3, v4, v0, v5)
                    let v17 : UH4 = UH4_DfaStatePairCons(v3, v4, v2)
                    dfa_bisimulation_work_19(v0, v16, v17)
                else
                    false
    | UH4_DfaStatePairNil -> (* DfaStatePairNil *)
        true
and dfa_find_bisimilar_representative_18 (v0 : UH0, v1 : UH3, v2 : UH2) : US4 =
    match v1 with
    | UH3_RegexListCons(v4, v5) -> (* RegexListCons *)
        let v6 : UH0 = normalize_0(v0)
        let v7 : UH0 = normalize_0(v4)
        let v8 : UH4 = UH4_DfaStatePairNil
        let v9 : UH4 = UH4_DfaStatePairCons(v6, v7, v8)
        let v10 : UH4 = UH4_DfaStatePairNil
        let v11 : bool = dfa_bisimulation_work_19(v2, v9, v10)
        if v11 then
            US4_DfaRepresentativeFound(v4)
        else
            dfa_find_bisimilar_representative_18(v0, v5, v2)
    | UH3_RegexListNil -> (* RegexListNil *)
        US4_DfaRepresentativeMissing
and dfa_minimize_states_loop_17 (v0 : UH3, v1 : UH2, v2 : UH3) : UH3 =
    match v0 with
    | UH3_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : US4 = dfa_find_bisimilar_representative_18(v3, v2, v1)
        match v5 with
        | US4_DfaRepresentativeFound(v6) -> (* DfaRepresentativeFound *)
            dfa_minimize_states_loop_17(v4, v1, v2)
        | US4_DfaRepresentativeMissing -> (* DfaRepresentativeMissing *)
            let v8 : UH3 = UH3_RegexListCons(v3, v2)
            dfa_minimize_states_loop_17(v4, v1, v8)
    | UH3_RegexListNil -> (* RegexListNil *)
        v2
and dfa_constructive_input_snoc_26 (v0 : UH5, v1 : US0) : UH5 =
    match v0 with
    | UH5_InputCons(v4, v5) -> (* InputCons *)
        let v6 : UH5 = dfa_constructive_input_snoc_26(v5, v1)
        UH5_InputCons(v4, v6)
    | UH5_InputEmpty -> (* InputEmpty *)
        let v2 : UH5 = UH5_InputEmpty
        UH5_InputCons(v1, v2)
and dfa_constructive_pair_trace_enqueue_symbols_25 (v0 : UH0, v1 : UH0, v2 : UH5, v3 : UH2, v4 : UH6) : UH6 =
    match v3 with
    | UH2_SymbolListCons(v5, v6) -> (* SymbolListCons *)
        let v7 : UH0 = canonical_derivative_13(v0, v5)
        let v8 : UH0 = canonical_derivative_13(v1, v5)
        let v9 : UH5 = dfa_constructive_input_snoc_26(v2, v5)
        let v10 : UH6 = UH6_DfaConstructivePairTraceCons(v7, v8, v9, v4)
        dfa_constructive_pair_trace_enqueue_symbols_25(v0, v1, v2, v6, v10)
    | UH2_SymbolListNil -> (* SymbolListNil *)
        v4
and dfa_constructive_distinguishing_work_24 (v0 : UH2, v1 : UH6, v2 : UH4) : US5 =
    match v1 with
    | UH6_DfaConstructivePairTraceCons(v4, v5, v6, v7) -> (* DfaConstructivePairTraceCons *)
        let v8 : bool = regex_equal_5(v4, v5)
        if v8 then
            dfa_constructive_distinguishing_work_24(v0, v7, v2)
        else
            let v10 : bool = dfa_state_pair_list_contains_20(v4, v5, v2)
            if v10 then
                dfa_constructive_distinguishing_work_24(v0, v7, v2)
            else
                let v12 : US3 = nullable_15(v4)
                let v13 : US3 = nullable_15(v5)
                let v17 : bool =
                    match v12 with
                    | US3_NonNullable -> (* NonNullable *)
                        match v13 with
                        | US3_NonNullable -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_Nullable -> (* Nullable *)
                        match v13 with
                        | US3_Nullable -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v17 then
                    let v18 : UH6 = dfa_constructive_pair_trace_enqueue_symbols_25(v4, v5, v6, v0, v7)
                    let v19 : UH4 = UH4_DfaStatePairCons(v4, v5, v2)
                    dfa_constructive_distinguishing_work_24(v0, v18, v19)
                else
                    US5_DfaConstructiveDistinguished(v6)
    | UH6_DfaConstructivePairTraceNil -> (* DfaConstructivePairTraceNil *)
        US5_DfaConstructiveEquivalent
and input_list_append_28 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : UH7 = input_list_append_28(v3, v1)
        UH7_InputListCons(v2, v4)
    | UH7_InputListNil -> (* InputListNil *)
        v1
and consume_right_29 (v0 : UH0, v1 : UH7) : UH7 =
    match v1 with
    | UH7_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = language_remainders_27(v0, v3)
        let v6 : UH7 = consume_right_29(v0, v4)
        input_list_append_28(v5, v6)
    | UH7_InputListNil -> (* InputListNil *)
        UH7_InputListNil
and input_equal_33 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_InputCons(v3, v4) -> (* InputCons *)
        match v1 with
        | UH5_InputCons(v5, v6) -> (* InputCons *)
            let v16 : US1 =
                match v3 with
                | US0_BitOne -> (* BitOne *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolSame
            let v17 : bool =
                match v16 with
                | US1_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                input_equal_33(v4, v6)
            else
                false
        | _ ->
            false
    | UH5_InputEmpty -> (* InputEmpty *)
        match v1 with
        | UH5_InputEmpty -> (* InputEmpty *)
            true
        | _ ->
            false
and input_list_contains_32 (v0 : UH5, v1 : UH7) : bool =
    match v1 with
    | UH7_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_33(v0, v2)
        if v4 then
            true
        else
            input_list_contains_32(v0, v3)
    | UH7_InputListNil -> (* InputListNil *)
        false
and input_list_enqueue_new_31 (v0 : UH7, v1 : UH7, v2 : UH7) : struct (UH7 * UH7) =
    match v0 with
    | UH7_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_32(v3, v1)
        if v5 then
            input_list_enqueue_new_31(v4, v1, v2)
        else
            let v8 : UH7 = UH7_InputListCons(v3, v1)
            let v9 : UH7 = UH7_InputListCons(v3, v2)
            input_list_enqueue_new_31(v4, v8, v9)
    | UH7_InputListNil -> (* InputListNil *)
        struct (v1, v2)
and closure_30 (v0 : UH0, v1 : UH7, v2 : UH7) : UH7 =
    match v1 with
    | UH7_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = language_remainders_27(v0, v3)
        let struct (v6 : UH7, v7 : UH7) = input_list_enqueue_new_31(v5, v2, v4)
        closure_30(v0, v7, v6)
    | UH7_InputListNil -> (* InputListNil *)
        v2
and language_remainders_27 (v0 : UH0, v1 : UH5) : UH7 =
    match v0 with
    | UH0_RegexAlt(v26, v27) -> (* RegexAlt *)
        let v28 : UH7 = language_remainders_27(v26, v1)
        let v29 : UH7 = language_remainders_27(v27, v1)
        input_list_append_28(v28, v29)
    | UH0_RegexCat(v31, v32) -> (* RegexCat *)
        let v33 : UH7 = language_remainders_27(v31, v1)
        consume_right_29(v32, v33)
    | UH0_RegexChar(v5) -> (* RegexChar *)
        match v1 with
        | UH5_InputCons(v7, v8) -> (* InputCons *)
            let v18 : US1 =
                match v5 with
                | US0_BitOne -> (* BitOne *)
                    match v7 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v7 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolSame
            let v19 : bool =
                match v18 with
                | US1_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH7 = UH7_InputListNil
                UH7_InputListCons(v8, v20)
            else
                UH7_InputListNil
        | UH5_InputEmpty -> (* InputEmpty *)
            UH7_InputListNil
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH7_InputListNil
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        let v3 : UH7 = UH7_InputListNil
        UH7_InputListCons(v1, v3)
    | UH0_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH7 = UH7_InputListNil
        let v37 : UH7 = UH7_InputListCons(v1, v36)
        let v38 : UH7 = UH7_InputListNil
        let v39 : UH7 = UH7_InputListCons(v1, v38)
        closure_30(v35, v37, v39)
and dfa_state_distinct_with_witness_against_23 (v0 : UH0, v1 : UH3, v2 : UH2) : bool =
    match v1 with
    | UH3_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH0 = normalize_0(v0)
        let v6 : UH0 = normalize_0(v3)
        let v7 : UH5 = UH5_InputEmpty
        let v8 : UH6 = UH6_DfaConstructivePairTraceNil
        let v9 : UH6 = UH6_DfaConstructivePairTraceCons(v5, v6, v7, v8)
        let v10 : UH4 = UH4_DfaStatePairNil
        let v11 : US5 = dfa_constructive_distinguishing_work_24(v2, v9, v10)
        match v11 with
        | US5_DfaConstructiveDistinguished(v12) -> (* DfaConstructiveDistinguished *)
            let v13 : UH0 = normalize_0(v0)
            let v14 : UH5 = UH5_InputEmpty
            let v15 : UH7 = language_remainders_27(v13, v12)
            let v16 : bool = input_list_contains_32(v14, v15)
            let v17 : UH0 = normalize_0(v3)
            let v18 : UH5 = UH5_InputEmpty
            let v19 : UH7 = language_remainders_27(v17, v12)
            let v20 : bool = input_list_contains_32(v18, v19)
            let v22 : bool =
                if v16 then
                    v20
                else
                    let v21 : bool = false = v20
                    v21
            let v23 : bool = v22 = false
            if v23 then
                dfa_state_distinct_with_witness_against_23(v0, v4, v2)
            else
                false
        | US5_DfaConstructiveEquivalent -> (* DfaConstructiveEquivalent *)
            false
    | UH3_RegexListNil -> (* RegexListNil *)
        true
and dfa_minimal_with_distinguishing_witnesses_22 (v0 : UH3, v1 : UH2) : bool =
    match v0 with
    | UH3_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_distinct_with_witness_against_23(v2, v3, v1)
        if v4 then
            dfa_minimal_with_distinguishing_witnesses_22(v3, v1)
        else
            false
    | UH3_RegexListNil -> (* RegexListNil *)
        true
and regex_compare_37 (v0 : UH8, v1 : UH8) : US1 =
    match v0 with
    | UH8_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH8_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = regex_compare_37(v59, v61)
            match v63 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_37(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_SymbolGreater
    | UH8_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH8_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US1 = regex_compare_37(v34, v40)
            match v42 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_37(v35, v41)
            | _ ->
                v42
        | UH8_RegexChar(v38) -> (* RegexChar *)
            US1_SymbolGreater
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH8_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH8_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US6_TriA -> (* TriA *)
                match v13 with
                | US6_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v13 with
                | US6_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v10 with
                    | US6_TriB -> (* TriB *)
                        match v13 with
                        | US6_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US6_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US6_TriC -> (* TriC *)
                        match v13 with
                        | US6_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US6_TriC -> (* TriC *)
                            US1_SymbolSame
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH8_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH8_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH8_RegexAlt(v51, v52) -> (* RegexAlt *)
            US1_SymbolLess
        | UH8_RegexStar(v54) -> (* RegexStar *)
            regex_compare_37(v50, v54)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_36 (v0 : UH8, v1 : UH8) : UH8 =
    match v1 with
    | UH8_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_37(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH8 = alt_insert_sorted_36(v0, v3)
            UH8_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH8_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH8_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_37(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH8_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH8_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_35 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH8 = alt_insert_sorted_36(v2, v1)
        make_alt_35(v3, v4)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_36(v0, v1)
and regex_equal_39 (v0 : UH8, v1 : UH8) : bool =
    match v0 with
    | UH8_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH8_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_39(v24, v26)
            if v28 then
                regex_equal_39(v25, v27)
            else
                false
        | _ ->
            false
    | UH8_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH8_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_39(v32, v34)
            if v36 then
                regex_equal_39(v33, v35)
            else
                false
        | _ ->
            false
    | UH8_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH8_RegexChar(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US6_TriA -> (* TriA *)
                    match v5 with
                    | US6_TriA -> (* TriA *)
                        US1_SymbolSame
                    | _ ->
                        US1_SymbolLess
                | _ ->
                    match v5 with
                    | US6_TriA -> (* TriA *)
                        US1_SymbolGreater
                    | _ ->
                        match v4 with
                        | US6_TriB -> (* TriB *)
                            match v5 with
                            | US6_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US6_TriC -> (* TriC *)
                                US1_SymbolLess
                        | US6_TriC -> (* TriC *)
                            match v5 with
                            | US6_TriB -> (* TriB *)
                                US1_SymbolGreater
                            | US6_TriC -> (* TriC *)
                                US1_SymbolSame
            match v21 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH8_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH8_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH8_RegexStar(v40) -> (* RegexStar *)
        match v1 with
        | UH8_RegexStar(v41) -> (* RegexStar *)
            regex_equal_39(v40, v41)
        | _ ->
            false
and make_cat_38 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEmpty
    | _ ->
        match v1 with
        | UH8_RegexEmpty -> (* RegexEmpty *)
            UH8_RegexEmpty
        | _ ->
            match v0 with
            | UH8_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH8_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH8_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH8 = make_cat_38(v13, v1)
                        UH8_RegexCat(v12, v14)
                    | UH8_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH8_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_39(v4, v5)
                            if v6 then
                                UH8_RegexStar(v4)
                            else
                                UH8_RegexCat(v0, v1)
                        | _ ->
                            UH8_RegexCat(v0, v1)
                    | _ ->
                        UH8_RegexCat(v0, v1)
and make_star_40 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEpsilon
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEpsilon
    | UH8_RegexStar(v3) -> (* RegexStar *)
        UH8_RegexStar(v3)
    | _ ->
        UH8_RegexStar(v0)
and normalize_34 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH8 = normalize_34(v5)
        let v8 : UH8 = normalize_34(v6)
        make_alt_35(v7, v8)
    | UH8_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH8 = normalize_34(v10)
        let v13 : UH8 = normalize_34(v11)
        make_cat_38(v12, v13)
    | UH8_RegexChar(v3) -> (* RegexChar *)
        UH8_RegexChar(v3)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEmpty
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEpsilon
    | UH8_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH8 = normalize_34(v15)
        make_star_40(v16)
and regex_position_count_41 (v0 : UH8) : UH1 =
    match v0 with
    | UH8_RegexAlt(v6, v7) -> (* RegexAlt *)
        let v8 : UH1 = regex_position_count_41(v6)
        let v9 : UH1 = regex_position_count_41(v7)
        state_budget_add_8(v8, v9)
    | UH8_RegexCat(v11, v12) -> (* RegexCat *)
        let v13 : UH1 = regex_position_count_41(v11)
        let v14 : UH1 = regex_position_count_41(v12)
        state_budget_add_8(v13, v14)
    | UH8_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH1 = UH1_StateBudgetZero
        UH1_StateBudgetSucc(v4)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH1_StateBudgetZero
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH1_StateBudgetZero
    | UH8_RegexStar(v16) -> (* RegexStar *)
        regex_position_count_41(v16)
and nullable_46 (v0 : UH8) : US3 =
    match v0 with
    | UH8_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_46(v5)
        let v8 : US3 = nullable_46(v6)
        match v7 with
        | US3_Nullable -> (* Nullable *)
            US3_Nullable
        | _ ->
            match v8 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                match v7 with
                | US3_NonNullable -> (* NonNullable *)
                    match v8 with
                    | US3_NonNullable -> (* NonNullable *)
                        US3_NonNullable
    | UH8_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US3 = nullable_46(v16)
        let v19 : US3 = nullable_46(v17)
        match v18 with
        | US3_Nullable -> (* Nullable *)
            match v19 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                US3_NonNullable
        | _ ->
            US3_NonNullable
    | UH8_RegexChar(v3) -> (* RegexChar *)
        US3_NonNullable
    | UH8_RegexEmpty -> (* RegexEmpty *)
        US3_NonNullable
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        US3_Nullable
    | UH8_RegexStar(v25) -> (* RegexStar *)
        US3_Nullable
and derivative_45 (v0 : UH8, v1 : US6) : UH8 =
    match v0 with
    | UH8_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH8 = derivative_45(v25, v1)
        let v28 : UH8 = derivative_45(v26, v1)
        make_alt_35(v27, v28)
    | UH8_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US3 = nullable_46(v30)
        match v32 with
        | US3_NonNullable -> (* NonNullable *)
            let v37 : UH8 = derivative_45(v30, v1)
            make_cat_38(v37, v31)
        | US3_Nullable -> (* Nullable *)
            let v33 : UH8 = derivative_45(v30, v1)
            let v34 : UH8 = make_cat_38(v33, v31)
            let v35 : UH8 = derivative_45(v31, v1)
            make_alt_35(v34, v35)
    | UH8_RegexChar(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US6_TriA -> (* TriA *)
                match v1 with
                | US6_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v1 with
                | US6_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v4 with
                    | US6_TriB -> (* TriB *)
                        match v1 with
                        | US6_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US6_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US6_TriC -> (* TriC *)
                        match v1 with
                        | US6_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US6_TriC -> (* TriC *)
                            US1_SymbolSame
        let v21 : bool =
            match v20 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH8_RegexEpsilon
        else
            UH8_RegexEmpty
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEmpty
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEmpty
    | UH8_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH8 = derivative_45(v41, v1)
        let v43 : UH8 = make_star_40(v41)
        make_cat_38(v42, v43)
and canonical_derivative_44 (v0 : UH8, v1 : US6) : UH8 =
    let v2 : UH8 = normalize_34(v0)
    let v3 : UH8 = derivative_45(v2, v1)
    normalize_34(v3)
and regex_list_contains_47 (v0 : UH8, v1 : UH10) : bool =
    match v1 with
    | UH10_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_39(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_47(v0, v3)
    | UH10_RegexListNil -> (* RegexListNil *)
        false
and dfa_enqueue_symbols_43 (v0 : UH8, v1 : UH9, v2 : UH10, v3 : UH10) : struct (UH10 * UH10) =
    match v1 with
    | UH9_SymbolListCons(v4, v5) -> (* SymbolListCons *)
        let v6 : UH8 = canonical_derivative_44(v0, v4)
        let v7 : bool = regex_list_contains_47(v6, v2)
        if v7 then
            dfa_enqueue_symbols_43(v0, v5, v2, v3)
        else
            let v10 : UH10 = UH10_RegexListCons(v6, v2)
            let v11 : UH10 = UH10_RegexListCons(v6, v3)
            dfa_enqueue_symbols_43(v0, v5, v10, v11)
    | UH9_SymbolListNil -> (* SymbolListNil *)
        struct (v2, v3)
and dfa_closure_loop_bounded_42 (v0 : UH9, v1 : UH1, v2 : UH10, v3 : UH10) : US7 =
    match v3 with
    | UH10_RegexListCons(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH1_StateBudgetSucc(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH10, v10 : UH10) = dfa_enqueue_symbols_43(v5, v0, v2, v6)
            dfa_closure_loop_bounded_42(v0, v8, v9, v10)
        | UH1_StateBudgetZero -> (* StateBudgetZero *)
            US7_DfaClosureBudgetExceeded(v2)
    | UH10_RegexListNil -> (* RegexListNil *)
        US7_DfaClosureComplete(v2)
and dfa_state_pair_list_contains_51 (v0 : UH8, v1 : UH8, v2 : UH11) : bool =
    match v2 with
    | UH11_DfaStatePairCons(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_39(v0, v3)
        let v11 : bool =
            if v6 then
                regex_equal_39(v1, v4)
            else
                let v8 : bool = regex_equal_39(v0, v4)
                if v8 then
                    regex_equal_39(v1, v3)
                else
                    false
        if v11 then
            true
        else
            dfa_state_pair_list_contains_51(v0, v1, v5)
    | UH11_DfaStatePairNil -> (* DfaStatePairNil *)
        false
and dfa_state_pair_enqueue_symbols_52 (v0 : UH8, v1 : UH8, v2 : UH9, v3 : UH11) : UH11 =
    match v2 with
    | UH9_SymbolListCons(v4, v5) -> (* SymbolListCons *)
        let v6 : UH8 = canonical_derivative_44(v0, v4)
        let v7 : UH8 = canonical_derivative_44(v1, v4)
        let v8 : UH11 = UH11_DfaStatePairCons(v6, v7, v3)
        dfa_state_pair_enqueue_symbols_52(v0, v1, v5, v8)
    | UH9_SymbolListNil -> (* SymbolListNil *)
        v3
and dfa_bisimulation_work_50 (v0 : UH9, v1 : UH11, v2 : UH11) : bool =
    match v1 with
    | UH11_DfaStatePairCons(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_39(v3, v4)
        if v6 then
            dfa_bisimulation_work_50(v0, v5, v2)
        else
            let v8 : bool = dfa_state_pair_list_contains_51(v3, v4, v2)
            if v8 then
                dfa_bisimulation_work_50(v0, v5, v2)
            else
                let v10 : US3 = nullable_46(v3)
                let v11 : US3 = nullable_46(v4)
                let v15 : bool =
                    match v10 with
                    | US3_NonNullable -> (* NonNullable *)
                        match v11 with
                        | US3_NonNullable -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_Nullable -> (* Nullable *)
                        match v11 with
                        | US3_Nullable -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH11 = dfa_state_pair_enqueue_symbols_52(v3, v4, v0, v5)
                    let v17 : UH11 = UH11_DfaStatePairCons(v3, v4, v2)
                    dfa_bisimulation_work_50(v0, v16, v17)
                else
                    false
    | UH11_DfaStatePairNil -> (* DfaStatePairNil *)
        true
and dfa_find_bisimilar_representative_49 (v0 : UH8, v1 : UH10, v2 : UH9) : US8 =
    match v1 with
    | UH10_RegexListCons(v4, v5) -> (* RegexListCons *)
        let v6 : UH8 = normalize_34(v0)
        let v7 : UH8 = normalize_34(v4)
        let v8 : UH11 = UH11_DfaStatePairNil
        let v9 : UH11 = UH11_DfaStatePairCons(v6, v7, v8)
        let v10 : UH11 = UH11_DfaStatePairNil
        let v11 : bool = dfa_bisimulation_work_50(v2, v9, v10)
        if v11 then
            US8_DfaRepresentativeFound(v4)
        else
            dfa_find_bisimilar_representative_49(v0, v5, v2)
    | UH10_RegexListNil -> (* RegexListNil *)
        US8_DfaRepresentativeMissing
and dfa_minimize_states_loop_48 (v0 : UH10, v1 : UH9, v2 : UH10) : UH10 =
    match v0 with
    | UH10_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : US8 = dfa_find_bisimilar_representative_49(v3, v2, v1)
        match v5 with
        | US8_DfaRepresentativeFound(v6) -> (* DfaRepresentativeFound *)
            dfa_minimize_states_loop_48(v4, v1, v2)
        | US8_DfaRepresentativeMissing -> (* DfaRepresentativeMissing *)
            let v8 : UH10 = UH10_RegexListCons(v3, v2)
            dfa_minimize_states_loop_48(v4, v1, v8)
    | UH10_RegexListNil -> (* RegexListNil *)
        v2
and dfa_constructive_input_snoc_57 (v0 : UH12, v1 : US6) : UH12 =
    match v0 with
    | UH12_InputCons(v4, v5) -> (* InputCons *)
        let v6 : UH12 = dfa_constructive_input_snoc_57(v5, v1)
        UH12_InputCons(v4, v6)
    | UH12_InputEmpty -> (* InputEmpty *)
        let v2 : UH12 = UH12_InputEmpty
        UH12_InputCons(v1, v2)
and dfa_constructive_pair_trace_enqueue_symbols_56 (v0 : UH8, v1 : UH8, v2 : UH12, v3 : UH9, v4 : UH13) : UH13 =
    match v3 with
    | UH9_SymbolListCons(v5, v6) -> (* SymbolListCons *)
        let v7 : UH8 = canonical_derivative_44(v0, v5)
        let v8 : UH8 = canonical_derivative_44(v1, v5)
        let v9 : UH12 = dfa_constructive_input_snoc_57(v2, v5)
        let v10 : UH13 = UH13_DfaConstructivePairTraceCons(v7, v8, v9, v4)
        dfa_constructive_pair_trace_enqueue_symbols_56(v0, v1, v2, v6, v10)
    | UH9_SymbolListNil -> (* SymbolListNil *)
        v4
and dfa_constructive_distinguishing_work_55 (v0 : UH9, v1 : UH13, v2 : UH11) : US9 =
    match v1 with
    | UH13_DfaConstructivePairTraceCons(v4, v5, v6, v7) -> (* DfaConstructivePairTraceCons *)
        let v8 : bool = regex_equal_39(v4, v5)
        if v8 then
            dfa_constructive_distinguishing_work_55(v0, v7, v2)
        else
            let v10 : bool = dfa_state_pair_list_contains_51(v4, v5, v2)
            if v10 then
                dfa_constructive_distinguishing_work_55(v0, v7, v2)
            else
                let v12 : US3 = nullable_46(v4)
                let v13 : US3 = nullable_46(v5)
                let v17 : bool =
                    match v12 with
                    | US3_NonNullable -> (* NonNullable *)
                        match v13 with
                        | US3_NonNullable -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_Nullable -> (* Nullable *)
                        match v13 with
                        | US3_Nullable -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v17 then
                    let v18 : UH13 = dfa_constructive_pair_trace_enqueue_symbols_56(v4, v5, v6, v0, v7)
                    let v19 : UH11 = UH11_DfaStatePairCons(v4, v5, v2)
                    dfa_constructive_distinguishing_work_55(v0, v18, v19)
                else
                    US9_DfaConstructiveDistinguished(v6)
    | UH13_DfaConstructivePairTraceNil -> (* DfaConstructivePairTraceNil *)
        US9_DfaConstructiveEquivalent
and input_list_append_59 (v0 : UH14, v1 : UH14) : UH14 =
    match v0 with
    | UH14_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : UH14 = input_list_append_59(v3, v1)
        UH14_InputListCons(v2, v4)
    | UH14_InputListNil -> (* InputListNil *)
        v1
and consume_right_60 (v0 : UH8, v1 : UH14) : UH14 =
    match v1 with
    | UH14_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH14 = language_remainders_58(v0, v3)
        let v6 : UH14 = consume_right_60(v0, v4)
        input_list_append_59(v5, v6)
    | UH14_InputListNil -> (* InputListNil *)
        UH14_InputListNil
and input_equal_64 (v0 : UH12, v1 : UH12) : bool =
    match v0 with
    | UH12_InputCons(v3, v4) -> (* InputCons *)
        match v1 with
        | UH12_InputCons(v5, v6) -> (* InputCons *)
            let v22 : US1 =
                match v3 with
                | US6_TriA -> (* TriA *)
                    match v5 with
                    | US6_TriA -> (* TriA *)
                        US1_SymbolSame
                    | _ ->
                        US1_SymbolLess
                | _ ->
                    match v5 with
                    | US6_TriA -> (* TriA *)
                        US1_SymbolGreater
                    | _ ->
                        match v3 with
                        | US6_TriB -> (* TriB *)
                            match v5 with
                            | US6_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US6_TriC -> (* TriC *)
                                US1_SymbolLess
                        | US6_TriC -> (* TriC *)
                            match v5 with
                            | US6_TriB -> (* TriB *)
                                US1_SymbolGreater
                            | US6_TriC -> (* TriC *)
                                US1_SymbolSame
            let v23 : bool =
                match v22 with
                | US1_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                input_equal_64(v4, v6)
            else
                false
        | _ ->
            false
    | UH12_InputEmpty -> (* InputEmpty *)
        match v1 with
        | UH12_InputEmpty -> (* InputEmpty *)
            true
        | _ ->
            false
and input_list_contains_63 (v0 : UH12, v1 : UH14) : bool =
    match v1 with
    | UH14_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_64(v0, v2)
        if v4 then
            true
        else
            input_list_contains_63(v0, v3)
    | UH14_InputListNil -> (* InputListNil *)
        false
and input_list_enqueue_new_62 (v0 : UH14, v1 : UH14, v2 : UH14) : struct (UH14 * UH14) =
    match v0 with
    | UH14_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_63(v3, v1)
        if v5 then
            input_list_enqueue_new_62(v4, v1, v2)
        else
            let v8 : UH14 = UH14_InputListCons(v3, v1)
            let v9 : UH14 = UH14_InputListCons(v3, v2)
            input_list_enqueue_new_62(v4, v8, v9)
    | UH14_InputListNil -> (* InputListNil *)
        struct (v1, v2)
and closure_61 (v0 : UH8, v1 : UH14, v2 : UH14) : UH14 =
    match v1 with
    | UH14_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH14 = language_remainders_58(v0, v3)
        let struct (v6 : UH14, v7 : UH14) = input_list_enqueue_new_62(v5, v2, v4)
        closure_61(v0, v7, v6)
    | UH14_InputListNil -> (* InputListNil *)
        v2
and language_remainders_58 (v0 : UH8, v1 : UH12) : UH14 =
    match v0 with
    | UH8_RegexAlt(v32, v33) -> (* RegexAlt *)
        let v34 : UH14 = language_remainders_58(v32, v1)
        let v35 : UH14 = language_remainders_58(v33, v1)
        input_list_append_59(v34, v35)
    | UH8_RegexCat(v37, v38) -> (* RegexCat *)
        let v39 : UH14 = language_remainders_58(v37, v1)
        consume_right_60(v38, v39)
    | UH8_RegexChar(v5) -> (* RegexChar *)
        match v1 with
        | UH12_InputCons(v7, v8) -> (* InputCons *)
            let v24 : US1 =
                match v5 with
                | US6_TriA -> (* TriA *)
                    match v7 with
                    | US6_TriA -> (* TriA *)
                        US1_SymbolSame
                    | _ ->
                        US1_SymbolLess
                | _ ->
                    match v7 with
                    | US6_TriA -> (* TriA *)
                        US1_SymbolGreater
                    | _ ->
                        match v5 with
                        | US6_TriB -> (* TriB *)
                            match v7 with
                            | US6_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US6_TriC -> (* TriC *)
                                US1_SymbolLess
                        | US6_TriC -> (* TriC *)
                            match v7 with
                            | US6_TriB -> (* TriB *)
                                US1_SymbolGreater
                            | US6_TriC -> (* TriC *)
                                US1_SymbolSame
            let v25 : bool =
                match v24 with
                | US1_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH14 = UH14_InputListNil
                UH14_InputListCons(v8, v26)
            else
                UH14_InputListNil
        | UH12_InputEmpty -> (* InputEmpty *)
            UH14_InputListNil
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH14_InputListNil
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        let v3 : UH14 = UH14_InputListNil
        UH14_InputListCons(v1, v3)
    | UH8_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH14 = UH14_InputListNil
        let v43 : UH14 = UH14_InputListCons(v1, v42)
        let v44 : UH14 = UH14_InputListNil
        let v45 : UH14 = UH14_InputListCons(v1, v44)
        closure_61(v41, v43, v45)
and dfa_state_distinct_with_witness_against_54 (v0 : UH8, v1 : UH10, v2 : UH9) : bool =
    match v1 with
    | UH10_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH8 = normalize_34(v0)
        let v6 : UH8 = normalize_34(v3)
        let v7 : UH12 = UH12_InputEmpty
        let v8 : UH13 = UH13_DfaConstructivePairTraceNil
        let v9 : UH13 = UH13_DfaConstructivePairTraceCons(v5, v6, v7, v8)
        let v10 : UH11 = UH11_DfaStatePairNil
        let v11 : US9 = dfa_constructive_distinguishing_work_55(v2, v9, v10)
        match v11 with
        | US9_DfaConstructiveDistinguished(v12) -> (* DfaConstructiveDistinguished *)
            let v13 : UH8 = normalize_34(v0)
            let v14 : UH12 = UH12_InputEmpty
            let v15 : UH14 = language_remainders_58(v13, v12)
            let v16 : bool = input_list_contains_63(v14, v15)
            let v17 : UH8 = normalize_34(v3)
            let v18 : UH12 = UH12_InputEmpty
            let v19 : UH14 = language_remainders_58(v17, v12)
            let v20 : bool = input_list_contains_63(v18, v19)
            let v22 : bool =
                if v16 then
                    v20
                else
                    let v21 : bool = false = v20
                    v21
            let v23 : bool = v22 = false
            if v23 then
                dfa_state_distinct_with_witness_against_54(v0, v4, v2)
            else
                false
        | US9_DfaConstructiveEquivalent -> (* DfaConstructiveEquivalent *)
            false
    | UH10_RegexListNil -> (* RegexListNil *)
        true
and dfa_minimal_with_distinguishing_witnesses_53 (v0 : UH10, v1 : UH9) : bool =
    match v0 with
    | UH10_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_distinct_with_witness_against_54(v2, v3, v1)
        if v4 then
            dfa_minimal_with_distinguishing_witnesses_53(v3, v1)
        else
            false
    | UH10_RegexListNil -> (* RegexListNil *)
        true
and regex_list_exact_budget_65 (v0 : UH3, v1 : UH1) : bool =
    match v0 with
    | UH3_RegexListCons(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH1_StateBudgetSucc(v5) -> (* StateBudgetSucc *)
            regex_list_exact_budget_65(v4, v5)
        | _ ->
            false
    | UH3_RegexListNil -> (* RegexListNil *)
        match v1 with
        | UH1_StateBudgetZero -> (* StateBudgetZero *)
            true
        | _ ->
            false
and regex_list_exact_budget_66 (v0 : UH10, v1 : UH1) : bool =
    match v0 with
    | UH10_RegexListCons(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH1_StateBudgetSucc(v5) -> (* StateBudgetSucc *)
            regex_list_exact_budget_66(v4, v5)
        | _ ->
            false
    | UH10_RegexListNil -> (* RegexListNil *)
        match v1 with
        | UH1_StateBudgetZero -> (* StateBudgetZero *)
            true
        | _ ->
            false
let v0 : US0 = US0_BitZero
let v1 : UH0 = UH0_RegexChar(v0)
let v2 : US0 = US0_BitOne
let v3 : UH0 = UH0_RegexChar(v2)
let v4 : UH0 = UH0_RegexAlt(v1, v3)
let v5 : UH0 = UH0_RegexStar(v4)
let v6 : US0 = US0_BitZero
let v7 : UH0 = UH0_RegexChar(v6)
let v8 : UH0 = UH0_RegexCat(v5, v7)
let v9 : UH0 = normalize_0(v8)
let v10 : UH0 = normalize_0(v9)
let v11 : UH1 = regex_position_count_7(v10)
let v12 : UH1 = UH1_StateBudgetSucc(v11)
let v13 : UH1 = state_budget_pow2_9(v12)
let v14 : UH0 = normalize_0(v10)
let v15 : US0 = US0_BitZero
let v16 : US0 = US0_BitOne
let v17 : UH2 = UH2_SymbolListNil
let v18 : UH2 = UH2_SymbolListCons(v16, v17)
let v19 : UH2 = UH2_SymbolListCons(v15, v18)
let v20 : UH3 = UH3_RegexListNil
let v21 : UH3 = UH3_RegexListCons(v14, v20)
let v22 : UH3 = UH3_RegexListNil
let v23 : UH3 = UH3_RegexListCons(v14, v22)
let v24 : US2 = dfa_closure_loop_bounded_11(v19, v13, v21, v23)
let v41 : bool =
    match v24 with
    | US2_DfaClosureBudgetExceeded(v25) -> (* DfaClosureBudgetExceeded *)
        false
    | US2_DfaClosureComplete(v26) -> (* DfaClosureComplete *)
        let v27 : US0 = US0_BitZero
        let v28 : US0 = US0_BitOne
        let v29 : UH2 = UH2_SymbolListNil
        let v30 : UH2 = UH2_SymbolListCons(v28, v29)
        let v31 : UH2 = UH2_SymbolListCons(v27, v30)
        let v32 : UH3 = UH3_RegexListNil
        let v33 : UH3 = dfa_minimize_states_loop_17(v26, v31, v32)
        let v34 : US0 = US0_BitZero
        let v35 : US0 = US0_BitOne
        let v36 : UH2 = UH2_SymbolListNil
        let v37 : UH2 = UH2_SymbolListCons(v35, v36)
        let v38 : UH2 = UH2_SymbolListCons(v34, v37)
        dfa_minimal_with_distinguishing_witnesses_22(v33, v38)
if v41 then
    ()
else
    failwith<unit> "bit minimized DFA representatives should carry independent distinguishing words"
let v42 : US6 = US6_TriA
let v43 : UH8 = UH8_RegexChar(v42)
let v44 : UH8 = UH8_RegexStar(v43)
let v45 : UH8 = normalize_34(v44)
let v46 : UH8 = normalize_34(v45)
let v47 : UH1 = regex_position_count_41(v46)
let v48 : UH1 = UH1_StateBudgetSucc(v47)
let v49 : UH1 = state_budget_pow2_9(v48)
let v50 : UH8 = normalize_34(v46)
let v51 : US6 = US6_TriA
let v52 : US6 = US6_TriB
let v53 : US6 = US6_TriC
let v54 : UH9 = UH9_SymbolListNil
let v55 : UH9 = UH9_SymbolListCons(v53, v54)
let v56 : UH9 = UH9_SymbolListCons(v52, v55)
let v57 : UH9 = UH9_SymbolListCons(v51, v56)
let v58 : UH10 = UH10_RegexListNil
let v59 : UH10 = UH10_RegexListCons(v50, v58)
let v60 : UH10 = UH10_RegexListNil
let v61 : UH10 = UH10_RegexListCons(v50, v60)
let v62 : US7 = dfa_closure_loop_bounded_42(v57, v49, v59, v61)
let v83 : bool =
    match v62 with
    | US7_DfaClosureBudgetExceeded(v63) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_DfaClosureComplete(v64) -> (* DfaClosureComplete *)
        let v65 : US6 = US6_TriA
        let v66 : US6 = US6_TriB
        let v67 : US6 = US6_TriC
        let v68 : UH9 = UH9_SymbolListNil
        let v69 : UH9 = UH9_SymbolListCons(v67, v68)
        let v70 : UH9 = UH9_SymbolListCons(v66, v69)
        let v71 : UH9 = UH9_SymbolListCons(v65, v70)
        let v72 : UH10 = UH10_RegexListNil
        let v73 : UH10 = dfa_minimize_states_loop_48(v64, v71, v72)
        let v74 : US6 = US6_TriA
        let v75 : US6 = US6_TriB
        let v76 : US6 = US6_TriC
        let v77 : UH9 = UH9_SymbolListNil
        let v78 : UH9 = UH9_SymbolListCons(v76, v77)
        let v79 : UH9 = UH9_SymbolListCons(v75, v78)
        let v80 : UH9 = UH9_SymbolListCons(v74, v79)
        dfa_minimal_with_distinguishing_witnesses_53(v73, v80)
if v83 then
    ()
else
    failwith<unit> "ternary star minimized DFA representatives should carry independent distinguishing words"
let v84 : US6 = US6_TriA
let v85 : UH8 = UH8_RegexChar(v84)
let v86 : US6 = US6_TriA
let v87 : UH8 = UH8_RegexChar(v86)
let v88 : UH8 = UH8_RegexStar(v87)
let v89 : UH8 = UH8_RegexCat(v85, v88)
let v90 : US6 = US6_TriB
let v91 : UH8 = UH8_RegexChar(v90)
let v92 : US6 = US6_TriA
let v93 : UH8 = UH8_RegexChar(v92)
let v94 : US6 = US6_TriA
let v95 : UH8 = UH8_RegexChar(v94)
let v96 : UH8 = UH8_RegexCat(v93, v95)
let v97 : UH8 = UH8_RegexStar(v96)
let v98 : US6 = US6_TriA
let v99 : UH8 = UH8_RegexChar(v98)
let v100 : UH8 = UH8_RegexCat(v99, v97)
let v101 : UH8 = UH8_RegexAlt(v97, v100)
let v102 : UH8 = UH8_RegexCat(v91, v101)
let v103 : UH8 = UH8_RegexAlt(v89, v102)
let v104 : UH8 = normalize_34(v103)
let v105 : UH8 = normalize_34(v104)
let v106 : UH1 = regex_position_count_41(v105)
let v107 : UH1 = UH1_StateBudgetSucc(v106)
let v108 : UH1 = state_budget_pow2_9(v107)
let v109 : UH8 = normalize_34(v105)
let v110 : US6 = US6_TriA
let v111 : US6 = US6_TriB
let v112 : US6 = US6_TriC
let v113 : UH9 = UH9_SymbolListNil
let v114 : UH9 = UH9_SymbolListCons(v112, v113)
let v115 : UH9 = UH9_SymbolListCons(v111, v114)
let v116 : UH9 = UH9_SymbolListCons(v110, v115)
let v117 : UH10 = UH10_RegexListNil
let v118 : UH10 = UH10_RegexListCons(v109, v117)
let v119 : UH10 = UH10_RegexListNil
let v120 : UH10 = UH10_RegexListCons(v109, v119)
let v121 : US7 = dfa_closure_loop_bounded_42(v116, v108, v118, v120)
let v142 : bool =
    match v121 with
    | US7_DfaClosureBudgetExceeded(v122) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_DfaClosureComplete(v123) -> (* DfaClosureComplete *)
        let v124 : US6 = US6_TriA
        let v125 : US6 = US6_TriB
        let v126 : US6 = US6_TriC
        let v127 : UH9 = UH9_SymbolListNil
        let v128 : UH9 = UH9_SymbolListCons(v126, v127)
        let v129 : UH9 = UH9_SymbolListCons(v125, v128)
        let v130 : UH9 = UH9_SymbolListCons(v124, v129)
        let v131 : UH10 = UH10_RegexListNil
        let v132 : UH10 = dfa_minimize_states_loop_48(v123, v130, v131)
        let v133 : US6 = US6_TriA
        let v134 : US6 = US6_TriB
        let v135 : US6 = US6_TriC
        let v136 : UH9 = UH9_SymbolListNil
        let v137 : UH9 = UH9_SymbolListCons(v135, v136)
        let v138 : UH9 = UH9_SymbolListCons(v134, v137)
        let v139 : UH9 = UH9_SymbolListCons(v133, v138)
        dfa_minimal_with_distinguishing_witnesses_53(v132, v139)
if v142 then
    ()
else
    failwith<unit> "cyclic quotient representatives should carry independent distinguishing words"
let v143 : US0 = US0_BitZero
let v144 : UH0 = UH0_RegexChar(v143)
let v145 : US0 = US0_BitOne
let v146 : UH0 = UH0_RegexChar(v145)
let v147 : UH0 = UH0_RegexAlt(v144, v146)
let v148 : UH0 = UH0_RegexStar(v147)
let v149 : US0 = US0_BitZero
let v150 : UH0 = UH0_RegexChar(v149)
let v151 : UH0 = UH0_RegexCat(v148, v150)
let v152 : UH0 = normalize_0(v151)
let v153 : UH0 = normalize_0(v152)
let v154 : UH1 = regex_position_count_7(v153)
let v155 : UH1 = UH1_StateBudgetSucc(v154)
let v156 : UH1 = state_budget_pow2_9(v155)
let v157 : UH0 = normalize_0(v153)
let v158 : US0 = US0_BitZero
let v159 : US0 = US0_BitOne
let v160 : UH2 = UH2_SymbolListNil
let v161 : UH2 = UH2_SymbolListCons(v159, v160)
let v162 : UH2 = UH2_SymbolListCons(v158, v161)
let v163 : UH3 = UH3_RegexListNil
let v164 : UH3 = UH3_RegexListCons(v157, v163)
let v165 : UH3 = UH3_RegexListNil
let v166 : UH3 = UH3_RegexListCons(v157, v165)
let v167 : US2 = dfa_closure_loop_bounded_11(v162, v156, v164, v166)
let v182 : bool =
    match v167 with
    | US2_DfaClosureBudgetExceeded(v168) -> (* DfaClosureBudgetExceeded *)
        false
    | US2_DfaClosureComplete(v169) -> (* DfaClosureComplete *)
        let v170 : US0 = US0_BitZero
        let v171 : US0 = US0_BitOne
        let v172 : UH2 = UH2_SymbolListNil
        let v173 : UH2 = UH2_SymbolListCons(v171, v172)
        let v174 : UH2 = UH2_SymbolListCons(v170, v173)
        let v175 : UH3 = UH3_RegexListNil
        let v176 : UH3 = dfa_minimize_states_loop_17(v169, v174, v175)
        let v177 : UH1 = UH1_StateBudgetZero
        let v178 : UH1 = UH1_StateBudgetSucc(v177)
        let v179 : UH1 = UH1_StateBudgetSucc(v178)
        regex_list_exact_budget_65(v176, v179)
if v182 then
    ()
else
    failwith<unit> "bit minimized DFA should match the independent two-state reference quotient"
let v183 : US6 = US6_TriA
let v184 : UH8 = UH8_RegexChar(v183)
let v185 : UH8 = UH8_RegexStar(v184)
let v186 : UH8 = normalize_34(v185)
let v187 : UH8 = normalize_34(v186)
let v188 : UH1 = regex_position_count_41(v187)
let v189 : UH1 = UH1_StateBudgetSucc(v188)
let v190 : UH1 = state_budget_pow2_9(v189)
let v191 : UH8 = normalize_34(v187)
let v192 : US6 = US6_TriA
let v193 : US6 = US6_TriB
let v194 : US6 = US6_TriC
let v195 : UH9 = UH9_SymbolListNil
let v196 : UH9 = UH9_SymbolListCons(v194, v195)
let v197 : UH9 = UH9_SymbolListCons(v193, v196)
let v198 : UH9 = UH9_SymbolListCons(v192, v197)
let v199 : UH10 = UH10_RegexListNil
let v200 : UH10 = UH10_RegexListCons(v191, v199)
let v201 : UH10 = UH10_RegexListNil
let v202 : UH10 = UH10_RegexListCons(v191, v201)
let v203 : US7 = dfa_closure_loop_bounded_42(v198, v190, v200, v202)
let v220 : bool =
    match v203 with
    | US7_DfaClosureBudgetExceeded(v204) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_DfaClosureComplete(v205) -> (* DfaClosureComplete *)
        let v206 : US6 = US6_TriA
        let v207 : US6 = US6_TriB
        let v208 : US6 = US6_TriC
        let v209 : UH9 = UH9_SymbolListNil
        let v210 : UH9 = UH9_SymbolListCons(v208, v209)
        let v211 : UH9 = UH9_SymbolListCons(v207, v210)
        let v212 : UH9 = UH9_SymbolListCons(v206, v211)
        let v213 : UH10 = UH10_RegexListNil
        let v214 : UH10 = dfa_minimize_states_loop_48(v205, v212, v213)
        let v215 : UH1 = UH1_StateBudgetZero
        let v216 : UH1 = UH1_StateBudgetSucc(v215)
        let v217 : UH1 = UH1_StateBudgetSucc(v216)
        regex_list_exact_budget_66(v214, v217)
if v220 then
    ()
else
    failwith<unit> "ternary star minimized DFA should match the independent two-state reference quotient"
let v221 : US6 = US6_TriA
let v222 : UH8 = UH8_RegexChar(v221)
let v223 : US6 = US6_TriA
let v224 : UH8 = UH8_RegexChar(v223)
let v225 : UH8 = UH8_RegexStar(v224)
let v226 : UH8 = UH8_RegexCat(v222, v225)
let v227 : US6 = US6_TriB
let v228 : UH8 = UH8_RegexChar(v227)
let v229 : US6 = US6_TriA
let v230 : UH8 = UH8_RegexChar(v229)
let v231 : US6 = US6_TriA
let v232 : UH8 = UH8_RegexChar(v231)
let v233 : UH8 = UH8_RegexCat(v230, v232)
let v234 : UH8 = UH8_RegexStar(v233)
let v235 : US6 = US6_TriA
let v236 : UH8 = UH8_RegexChar(v235)
let v237 : UH8 = UH8_RegexCat(v236, v234)
let v238 : UH8 = UH8_RegexAlt(v234, v237)
let v239 : UH8 = UH8_RegexCat(v228, v238)
let v240 : UH8 = UH8_RegexAlt(v226, v239)
let v241 : UH8 = normalize_34(v240)
let v242 : UH8 = normalize_34(v241)
let v243 : UH1 = regex_position_count_41(v242)
let v244 : UH1 = UH1_StateBudgetSucc(v243)
let v245 : UH1 = state_budget_pow2_9(v244)
let v246 : UH8 = normalize_34(v242)
let v247 : US6 = US6_TriA
let v248 : US6 = US6_TriB
let v249 : US6 = US6_TriC
let v250 : UH9 = UH9_SymbolListNil
let v251 : UH9 = UH9_SymbolListCons(v249, v250)
let v252 : UH9 = UH9_SymbolListCons(v248, v251)
let v253 : UH9 = UH9_SymbolListCons(v247, v252)
let v254 : UH10 = UH10_RegexListNil
let v255 : UH10 = UH10_RegexListCons(v246, v254)
let v256 : UH10 = UH10_RegexListNil
let v257 : UH10 = UH10_RegexListCons(v246, v256)
let v258 : US7 = dfa_closure_loop_bounded_42(v253, v245, v255, v257)
let v276 : bool =
    match v258 with
    | US7_DfaClosureBudgetExceeded(v259) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_DfaClosureComplete(v260) -> (* DfaClosureComplete *)
        let v261 : US6 = US6_TriA
        let v262 : US6 = US6_TriB
        let v263 : US6 = US6_TriC
        let v264 : UH9 = UH9_SymbolListNil
        let v265 : UH9 = UH9_SymbolListCons(v263, v264)
        let v266 : UH9 = UH9_SymbolListCons(v262, v265)
        let v267 : UH9 = UH9_SymbolListCons(v261, v266)
        let v268 : UH10 = UH10_RegexListNil
        let v269 : UH10 = dfa_minimize_states_loop_48(v260, v267, v268)
        let v270 : UH1 = UH1_StateBudgetZero
        let v271 : UH1 = UH1_StateBudgetSucc(v270)
        let v272 : UH1 = UH1_StateBudgetSucc(v271)
        let v273 : UH1 = UH1_StateBudgetSucc(v272)
        regex_list_exact_budget_66(v269, v273)
if v276 then
    ()
else
    failwith<unit> "cyclic minimized DFA should match the independent three-state reference quotient"
let v277 : UH0 = UH0_RegexEpsilon
let v278 : UH0 = normalize_0(v277)
let v279 : UH0 = UH0_RegexEmpty
let v280 : UH0 = normalize_0(v279)
let v281 : US0 = US0_BitZero
let v282 : US0 = US0_BitOne
let v283 : UH2 = UH2_SymbolListNil
let v284 : UH2 = UH2_SymbolListCons(v282, v283)
let v285 : UH2 = UH2_SymbolListCons(v281, v284)
let v286 : UH5 = UH5_InputEmpty
let v287 : UH6 = UH6_DfaConstructivePairTraceNil
let v288 : UH6 = UH6_DfaConstructivePairTraceCons(v278, v280, v286, v287)
let v289 : UH4 = UH4_DfaStatePairNil
let v290 : US5 = dfa_constructive_distinguishing_work_24(v285, v288, v289)
let v319 : bool =
    match v290 with
    | US5_DfaConstructiveDistinguished(v304) -> (* DfaConstructiveDistinguished *)
        let v305 : UH0 = UH0_RegexEpsilon
        let v306 : UH0 = normalize_0(v305)
        let v307 : UH5 = UH5_InputEmpty
        let v308 : UH7 = language_remainders_27(v306, v304)
        let v309 : bool = input_list_contains_32(v307, v308)
        let v310 : UH0 = UH0_RegexEmpty
        let v311 : UH0 = normalize_0(v310)
        let v312 : UH5 = UH5_InputEmpty
        let v313 : UH7 = language_remainders_27(v311, v304)
        let v314 : bool = input_list_contains_32(v312, v313)
        let v316 : bool =
            if v309 then
                v314
            else
                let v315 : bool = false = v314
                v315
        let v317 : bool = v316 = false
        v317
    | US5_DfaConstructiveEquivalent -> (* DfaConstructiveEquivalent *)
        let v291 : UH0 = UH0_RegexEpsilon
        let v292 : UH0 = normalize_0(v291)
        let v293 : UH0 = UH0_RegexEmpty
        let v294 : UH0 = normalize_0(v293)
        let v295 : US0 = US0_BitZero
        let v296 : US0 = US0_BitOne
        let v297 : UH2 = UH2_SymbolListNil
        let v298 : UH2 = UH2_SymbolListCons(v296, v297)
        let v299 : UH2 = UH2_SymbolListCons(v295, v298)
        let v300 : UH4 = UH4_DfaStatePairNil
        let v301 : UH4 = UH4_DfaStatePairCons(v292, v294, v300)
        let v302 : UH4 = UH4_DfaStatePairNil
        dfa_bisimulation_work_19(v299, v301, v302)
if v319 then
    ()
else
    failwith<unit> "nullable mismatch should produce a language-valid distinguishing word"
let v320 : UH0 = UH0_RegexEpsilon
let v321 : UH0 = normalize_0(v320)
let v322 : UH5 = UH5_InputEmpty
let v323 : US0 = US0_BitZero
let v324 : UH5 = UH5_InputEmpty
let v325 : UH5 = UH5_InputCons(v323, v324)
let v326 : UH7 = language_remainders_27(v321, v325)
let v327 : bool = input_list_contains_32(v322, v326)
let v328 : UH0 = UH0_RegexEmpty
let v329 : UH0 = normalize_0(v328)
let v330 : UH5 = UH5_InputEmpty
let v331 : US0 = US0_BitZero
let v332 : UH5 = UH5_InputEmpty
let v333 : UH5 = UH5_InputCons(v331, v332)
let v334 : UH7 = language_remainders_27(v329, v333)
let v335 : bool = input_list_contains_32(v330, v334)
let v337 : bool =
    if v327 then
        v335
    else
        let v336 : bool = false = v335
        v336
let v338 : bool = v337 = false
let v339 : bool = v338 = false
if v339 then
    ()
else
    failwith<unit> "independent language semantics must reject a forged non-distinguishing word"
let v340 : US0 = US0_BitZero
let v341 : UH0 = UH0_RegexChar(v340)
let v342 : US0 = US0_BitZero
let v343 : UH0 = UH0_RegexChar(v342)
let v344 : UH0 = UH0_RegexAlt(v341, v343)
let v345 : UH0 = normalize_0(v344)
let v346 : US0 = US0_BitZero
let v347 : UH0 = UH0_RegexChar(v346)
let v348 : UH0 = normalize_0(v347)
let v349 : US0 = US0_BitZero
let v350 : US0 = US0_BitOne
let v351 : UH2 = UH2_SymbolListNil
let v352 : UH2 = UH2_SymbolListCons(v350, v351)
let v353 : UH2 = UH2_SymbolListCons(v349, v352)
let v354 : UH5 = UH5_InputEmpty
let v355 : UH6 = UH6_DfaConstructivePairTraceNil
let v356 : UH6 = UH6_DfaConstructivePairTraceCons(v345, v348, v354, v355)
let v357 : UH4 = UH4_DfaStatePairNil
let v358 : US5 = dfa_constructive_distinguishing_work_24(v353, v356, v357)
let v397 : bool =
    match v358 with
    | US5_DfaConstructiveDistinguished(v377) -> (* DfaConstructiveDistinguished *)
        let v378 : US0 = US0_BitZero
        let v379 : UH0 = UH0_RegexChar(v378)
        let v380 : US0 = US0_BitZero
        let v381 : UH0 = UH0_RegexChar(v380)
        let v382 : UH0 = UH0_RegexAlt(v379, v381)
        let v383 : UH0 = normalize_0(v382)
        let v384 : UH5 = UH5_InputEmpty
        let v385 : UH7 = language_remainders_27(v383, v377)
        let v386 : bool = input_list_contains_32(v384, v385)
        let v387 : US0 = US0_BitZero
        let v388 : UH0 = UH0_RegexChar(v387)
        let v389 : UH0 = normalize_0(v388)
        let v390 : UH5 = UH5_InputEmpty
        let v391 : UH7 = language_remainders_27(v389, v377)
        let v392 : bool = input_list_contains_32(v390, v391)
        let v394 : bool =
            if v386 then
                v392
            else
                let v393 : bool = false = v392
                v393
        let v395 : bool = v394 = false
        v395
    | US5_DfaConstructiveEquivalent -> (* DfaConstructiveEquivalent *)
        let v359 : US0 = US0_BitZero
        let v360 : UH0 = UH0_RegexChar(v359)
        let v361 : US0 = US0_BitZero
        let v362 : UH0 = UH0_RegexChar(v361)
        let v363 : UH0 = UH0_RegexAlt(v360, v362)
        let v364 : UH0 = normalize_0(v363)
        let v365 : US0 = US0_BitZero
        let v366 : UH0 = UH0_RegexChar(v365)
        let v367 : UH0 = normalize_0(v366)
        let v368 : US0 = US0_BitZero
        let v369 : US0 = US0_BitOne
        let v370 : UH2 = UH2_SymbolListNil
        let v371 : UH2 = UH2_SymbolListCons(v369, v370)
        let v372 : UH2 = UH2_SymbolListCons(v368, v371)
        let v373 : UH4 = UH4_DfaStatePairNil
        let v374 : UH4 = UH4_DfaStatePairCons(v364, v367, v373)
        let v375 : UH4 = UH4_DfaStatePairNil
        dfa_bisimulation_work_19(v372, v374, v375)
if v397 then
    ()
else
    failwith<unit> "normalized language-equivalent states should remain bisimilar"
let v398 : string = "brzozowski-minimization-witness-green"
v398
