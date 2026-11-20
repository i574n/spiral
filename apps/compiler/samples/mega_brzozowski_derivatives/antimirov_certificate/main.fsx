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
    | UH1_RegexListNil
    | UH1_RegexListCons of UH0 * UH1
and UH2 =
    | UH2_StateBudgetZero
    | UH2_StateBudgetSucc of UH2
and UH3 =
    | UH3_SymbolListNil
    | UH3_SymbolListCons of US0 * UH3
and [<Struct>] US2 =
    | US2_Nullable
    | US2_NonNullable
and [<Struct>] US3 =
    | US3_TriA
    | US3_TriB
    | US3_TriC
and UH4 =
    | UH4_RegexEmpty
    | UH4_RegexEpsilon
    | UH4_RegexChar of US3
    | UH4_RegexAlt of UH4 * UH4
    | UH4_RegexCat of UH4 * UH4
    | UH4_RegexStar of UH4
and UH5 =
    | UH5_RegexListNil
    | UH5_RegexListCons of UH4 * UH5
and UH6 =
    | UH6_SymbolListNil
    | UH6_SymbolListCons of US3 * UH6
and UH7 =
    | UH7_InputEmpty
    | UH7_InputCons of US0 * UH7
and [<Struct>] US5 =
    | US5_DerivativeVerified of f0_0 : UH0 * f0_1 : US0 * f0_2 : UH0
and [<Struct>] US4 =
    | US4_DerivativePipelineRejected
    | US4_DerivativePipelineVerified of f1_0 : US5
and UH8 =
    | UH8_InputEmpty
    | UH8_InputCons of US3 * UH8
and [<Struct>] US7 =
    | US7_DerivativeVerified of f0_0 : UH4 * f0_1 : US3 * f0_2 : UH4
and [<Struct>] US6 =
    | US6_DerivativePipelineRejected
    | US6_DerivativePipelineVerified of f1_0 : US7
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
and regex_list_contains_10 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_5(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_10(v0, v3)
    | UH1_RegexListNil -> (* RegexListNil *)
        false
and antimirov_insert_unique_9 (v0 : UH0, v1 : UH1) : UH1 =
    let v2 : UH0 = normalize_0(v0)
    let v3 : bool = regex_list_contains_10(v2, v1)
    if v3 then
        v1
    else
        UH1_RegexListCons(v2, v1)
and antimirov_union_8 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = antimirov_insert_unique_9(v2, v1)
        antimirov_union_8(v3, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        v1
and antimirov_map_cat_right_11 (v0 : UH1, v1 : UH0) : UH1 =
    match v0 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH0 = make_cat_4(v3, v1)
        let v6 : UH1 = antimirov_map_cat_right_11(v4, v1)
        antimirov_insert_unique_9(v5, v6)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and antimirov_residual_support_7 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH1 = antimirov_residual_support_7(v7)
        let v10 : UH1 = antimirov_residual_support_7(v8)
        antimirov_union_8(v9, v10)
    | UH0_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : UH1 = antimirov_residual_support_7(v12)
        let v15 : UH1 = antimirov_map_cat_right_11(v14, v13)
        let v16 : UH1 = antimirov_residual_support_7(v13)
        antimirov_union_8(v15, v16)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH0 = UH0_RegexEpsilon
        let v5 : UH1 = UH1_RegexListNil
        UH1_RegexListCons(v4, v5)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH1_RegexListNil
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH1_RegexListNil
    | UH0_RegexStar(v18) -> (* RegexStar *)
        let v19 : UH1 = antimirov_residual_support_7(v18)
        let v20 : UH0 = UH0_RegexStar(v18)
        antimirov_map_cat_right_11(v19, v20)
and antimirov_origin_append_13 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = antimirov_origin_append_13(v3, v1)
        UH1_RegexListCons(v2, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        v1
and antimirov_origin_map_cat_right_14 (v0 : UH1, v1 : UH0) : UH1 =
    match v0 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH0 = make_cat_4(v3, v1)
        let v6 : UH0 = normalize_0(v5)
        let v7 : UH1 = antimirov_origin_map_cat_right_14(v4, v1)
        UH1_RegexListCons(v6, v7)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and antimirov_position_origins_12 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH1 = antimirov_position_origins_12(v7)
        let v10 : UH1 = antimirov_position_origins_12(v8)
        antimirov_origin_append_13(v9, v10)
    | UH0_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : UH1 = antimirov_position_origins_12(v12)
        let v15 : UH1 = antimirov_origin_map_cat_right_14(v14, v13)
        let v16 : UH1 = antimirov_position_origins_12(v13)
        antimirov_origin_append_13(v15, v16)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH0 = UH0_RegexEpsilon
        let v5 : UH1 = UH1_RegexListNil
        UH1_RegexListCons(v4, v5)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH1_RegexListNil
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH1_RegexListNil
    | UH0_RegexStar(v18) -> (* RegexStar *)
        let v19 : UH1 = antimirov_position_origins_12(v18)
        let v20 : UH0 = UH0_RegexStar(v18)
        antimirov_origin_map_cat_right_14(v19, v20)
and regex_list_distinct_15 (v0 : UH1) : bool =
    match v0 with
    | UH1_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : bool = regex_list_contains_10(v1, v2)
        if v3 then
            false
        else
            regex_list_distinct_15(v2)
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and antimirov_subset_16 (v0 : UH1, v1 : UH1) : bool =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH0 = normalize_0(v2)
        let v5 : bool = regex_list_contains_10(v4, v1)
        if v5 then
            antimirov_subset_16(v3, v1)
        else
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and state_budget_add_18 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_StateBudgetSucc(v2) -> (* StateBudgetSucc *)
        let v3 : UH2 = state_budget_add_18(v2, v1)
        UH2_StateBudgetSucc(v3)
    | UH2_StateBudgetZero -> (* StateBudgetZero *)
        v1
and regex_position_count_17 (v0 : UH0) : UH2 =
    match v0 with
    | UH0_RegexAlt(v6, v7) -> (* RegexAlt *)
        let v8 : UH2 = regex_position_count_17(v6)
        let v9 : UH2 = regex_position_count_17(v7)
        state_budget_add_18(v8, v9)
    | UH0_RegexCat(v11, v12) -> (* RegexCat *)
        let v13 : UH2 = regex_position_count_17(v11)
        let v14 : UH2 = regex_position_count_17(v12)
        state_budget_add_18(v13, v14)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH2 = UH2_StateBudgetZero
        UH2_StateBudgetSucc(v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH2_StateBudgetZero
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH2_StateBudgetZero
    | UH0_RegexStar(v16) -> (* RegexStar *)
        regex_position_count_17(v16)
and regex_list_exact_budget_19 (v0 : UH1, v1 : UH2) : bool =
    match v0 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH2_StateBudgetSucc(v5) -> (* StateBudgetSucc *)
            regex_list_exact_budget_19(v4, v5)
        | _ ->
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        match v1 with
        | UH2_StateBudgetZero -> (* StateBudgetZero *)
            true
        | _ ->
            false
and nullable_22 (v0 : UH0) : US2 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_22(v5)
        let v8 : US2 = nullable_22(v6)
        match v7 with
        | US2_Nullable -> (* Nullable *)
            US2_Nullable
        | _ ->
            match v8 with
            | US2_Nullable -> (* Nullable *)
                US2_Nullable
            | _ ->
                match v7 with
                | US2_NonNullable -> (* NonNullable *)
                    match v8 with
                    | US2_NonNullable -> (* NonNullable *)
                        US2_NonNullable
    | UH0_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US2 = nullable_22(v16)
        let v19 : US2 = nullable_22(v17)
        match v18 with
        | US2_Nullable -> (* Nullable *)
            match v19 with
            | US2_Nullable -> (* Nullable *)
                US2_Nullable
            | _ ->
                US2_NonNullable
        | _ ->
            US2_NonNullable
    | UH0_RegexChar(v3) -> (* RegexChar *)
        US2_NonNullable
    | UH0_RegexEmpty -> (* RegexEmpty *)
        US2_NonNullable
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        US2_Nullable
    | UH0_RegexStar(v25) -> (* RegexStar *)
        US2_Nullable
and antimirov_partial_derivative_21 (v0 : UH0, v1 : US0) : UH1 =
    match v0 with
    | UH0_RegexAlt(v21, v22) -> (* RegexAlt *)
        let v23 : UH1 = antimirov_partial_derivative_21(v21, v1)
        let v24 : UH1 = antimirov_partial_derivative_21(v22, v1)
        antimirov_union_8(v23, v24)
    | UH0_RegexCat(v26, v27) -> (* RegexCat *)
        let v28 : UH1 = antimirov_partial_derivative_21(v26, v1)
        let v29 : UH1 = antimirov_map_cat_right_11(v28, v27)
        let v30 : US2 = nullable_22(v26)
        match v30 with
        | US2_NonNullable -> (* NonNullable *)
            v29
        | US2_Nullable -> (* Nullable *)
            let v31 : UH1 = antimirov_partial_derivative_21(v27, v1)
            antimirov_union_8(v29, v31)
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
            let v16 : UH0 = UH0_RegexEpsilon
            let v17 : UH1 = UH1_RegexListNil
            UH1_RegexListCons(v16, v17)
        else
            UH1_RegexListNil
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH1_RegexListNil
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH1_RegexListNil
    | UH0_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH1 = antimirov_partial_derivative_21(v35, v1)
        let v37 : UH0 = UH0_RegexStar(v35)
        antimirov_map_cat_right_11(v36, v37)
and antimirov_partial_derivatives_origin_supported_20 (v0 : UH0, v1 : UH3) : bool =
    match v1 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH0 = normalize_0(v0)
        let v5 : UH1 = antimirov_partial_derivative_21(v4, v2)
        let v6 : UH1 = antimirov_position_origins_12(v4)
        let v7 : bool = antimirov_subset_16(v5, v6)
        if v7 then
            antimirov_partial_derivatives_origin_supported_20(v0, v3)
        else
            false
    | UH3_SymbolListNil -> (* SymbolListNil *)
        true
and antimirov_value_supported_for_symbols_24 (v0 : UH0, v1 : UH0, v2 : UH3) : bool =
    match v2 with
    | UH3_SymbolListCons(v3, v4) -> (* SymbolListCons *)
        let v5 : UH0 = normalize_0(v1)
        let v6 : UH1 = antimirov_partial_derivative_21(v5, v3)
        let v7 : UH0 = normalize_0(v0)
        let v8 : UH1 = antimirov_residual_support_7(v7)
        let v9 : UH1 = antimirov_insert_unique_9(v7, v8)
        let v10 : bool = antimirov_subset_16(v6, v9)
        if v10 then
            antimirov_value_supported_for_symbols_24(v0, v1, v4)
        else
            false
    | UH3_SymbolListNil -> (* SymbolListNil *)
        true
and antimirov_support_closed_23 (v0 : UH0, v1 : UH1, v2 : UH3) : bool =
    match v1 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : bool = antimirov_value_supported_for_symbols_24(v0, v3, v2)
        if v5 then
            antimirov_support_closed_23(v0, v4, v2)
        else
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and antimirov_state_regex_26 (v0 : UH1) : UH0 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH0 = antimirov_state_regex_26(v3)
        make_alt_1(v2, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH0_RegexEmpty
and derivative_28 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_28(v19, v1)
        let v22 : UH0 = derivative_28(v20, v1)
        make_alt_1(v21, v22)
    | UH0_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_22(v24)
        match v26 with
        | US2_NonNullable -> (* NonNullable *)
            let v31 : UH0 = derivative_28(v24, v1)
            make_cat_4(v31, v25)
        | US2_Nullable -> (* Nullable *)
            let v27 : UH0 = derivative_28(v24, v1)
            let v28 : UH0 = make_cat_4(v27, v25)
            let v29 : UH0 = derivative_28(v25, v1)
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
        let v36 : UH0 = derivative_28(v35, v1)
        let v37 : UH0 = make_star_6(v35)
        make_cat_4(v36, v37)
and canonical_derivative_27 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_0(v0)
    let v3 : UH0 = derivative_28(v2, v1)
    normalize_0(v3)
and antimirov_reconstruction_symbols_25 (v0 : UH0, v1 : UH3) : bool =
    match v1 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH0 = normalize_0(v0)
        let v5 : UH1 = antimirov_partial_derivative_21(v4, v2)
        let v6 : UH0 = antimirov_state_regex_26(v5)
        let v7 : UH0 = normalize_0(v6)
        let v8 : UH0 = canonical_derivative_27(v4, v2)
        let v9 : bool = regex_equal_5(v7, v8)
        if v9 then
            antimirov_reconstruction_symbols_25(v0, v3)
        else
            false
    | UH3_SymbolListNil -> (* SymbolListNil *)
        true
and regex_compare_32 (v0 : UH4, v1 : UH4) : US1 =
    match v0 with
    | UH4_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH4_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = regex_compare_32(v59, v61)
            match v63 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_32(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_SymbolGreater
    | UH4_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH4_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US1 = regex_compare_32(v34, v40)
            match v42 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_32(v35, v41)
            | _ ->
                v42
        | UH4_RegexChar(v38) -> (* RegexChar *)
            US1_SymbolGreater
        | UH4_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH4_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH4_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH4_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US3_TriA -> (* TriA *)
                match v13 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v13 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v10 with
                    | US3_TriB -> (* TriB *)
                        match v13 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US3_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US3_TriC -> (* TriC *)
                        match v13 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US3_TriC -> (* TriC *)
                            US1_SymbolSame
        | UH4_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH4_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH4_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH4_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH4_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH4_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH4_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH4_RegexAlt(v51, v52) -> (* RegexAlt *)
            US1_SymbolLess
        | UH4_RegexStar(v54) -> (* RegexStar *)
            regex_compare_32(v50, v54)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_31 (v0 : UH4, v1 : UH4) : UH4 =
    match v1 with
    | UH4_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_32(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH4 = alt_insert_sorted_31(v0, v3)
            UH4_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH4_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH4_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_32(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH4_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH4_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_30 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH4 = alt_insert_sorted_31(v2, v1)
        make_alt_30(v3, v4)
    | UH4_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_31(v0, v1)
and regex_equal_34 (v0 : UH4, v1 : UH4) : bool =
    match v0 with
    | UH4_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH4_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_34(v24, v26)
            if v28 then
                regex_equal_34(v25, v27)
            else
                false
        | _ ->
            false
    | UH4_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH4_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_34(v32, v34)
            if v36 then
                regex_equal_34(v33, v35)
            else
                false
        | _ ->
            false
    | UH4_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH4_RegexChar(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US3_TriA -> (* TriA *)
                    match v5 with
                    | US3_TriA -> (* TriA *)
                        US1_SymbolSame
                    | _ ->
                        US1_SymbolLess
                | _ ->
                    match v5 with
                    | US3_TriA -> (* TriA *)
                        US1_SymbolGreater
                    | _ ->
                        match v4 with
                        | US3_TriB -> (* TriB *)
                            match v5 with
                            | US3_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US3_TriC -> (* TriC *)
                                US1_SymbolLess
                        | US3_TriC -> (* TriC *)
                            match v5 with
                            | US3_TriB -> (* TriB *)
                                US1_SymbolGreater
                            | US3_TriC -> (* TriC *)
                                US1_SymbolSame
            match v21 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH4_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH4_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH4_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH4_RegexStar(v40) -> (* RegexStar *)
        match v1 with
        | UH4_RegexStar(v41) -> (* RegexStar *)
            regex_equal_34(v40, v41)
        | _ ->
            false
and make_cat_33 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH4_RegexEmpty
    | _ ->
        match v1 with
        | UH4_RegexEmpty -> (* RegexEmpty *)
            UH4_RegexEmpty
        | _ ->
            match v0 with
            | UH4_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH4_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH4_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH4 = make_cat_33(v13, v1)
                        UH4_RegexCat(v12, v14)
                    | UH4_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH4_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_34(v4, v5)
                            if v6 then
                                UH4_RegexStar(v4)
                            else
                                UH4_RegexCat(v0, v1)
                        | _ ->
                            UH4_RegexCat(v0, v1)
                    | _ ->
                        UH4_RegexCat(v0, v1)
and make_star_35 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH4_RegexEpsilon
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH4_RegexEpsilon
    | UH4_RegexStar(v3) -> (* RegexStar *)
        UH4_RegexStar(v3)
    | _ ->
        UH4_RegexStar(v0)
and normalize_29 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH4 = normalize_29(v5)
        let v8 : UH4 = normalize_29(v6)
        make_alt_30(v7, v8)
    | UH4_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH4 = normalize_29(v10)
        let v13 : UH4 = normalize_29(v11)
        make_cat_33(v12, v13)
    | UH4_RegexChar(v3) -> (* RegexChar *)
        UH4_RegexChar(v3)
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH4_RegexEmpty
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH4_RegexEpsilon
    | UH4_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH4 = normalize_29(v15)
        make_star_35(v16)
and regex_list_contains_39 (v0 : UH4, v1 : UH5) : bool =
    match v1 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_34(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_39(v0, v3)
    | UH5_RegexListNil -> (* RegexListNil *)
        false
and antimirov_insert_unique_38 (v0 : UH4, v1 : UH5) : UH5 =
    let v2 : UH4 = normalize_29(v0)
    let v3 : bool = regex_list_contains_39(v2, v1)
    if v3 then
        v1
    else
        UH5_RegexListCons(v2, v1)
and antimirov_union_37 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH5 = antimirov_insert_unique_38(v2, v1)
        antimirov_union_37(v3, v4)
    | UH5_RegexListNil -> (* RegexListNil *)
        v1
and antimirov_map_cat_right_40 (v0 : UH5, v1 : UH4) : UH5 =
    match v0 with
    | UH5_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = make_cat_33(v3, v1)
        let v6 : UH5 = antimirov_map_cat_right_40(v4, v1)
        antimirov_insert_unique_38(v5, v6)
    | UH5_RegexListNil -> (* RegexListNil *)
        UH5_RegexListNil
and antimirov_residual_support_36 (v0 : UH4) : UH5 =
    match v0 with
    | UH4_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH5 = antimirov_residual_support_36(v7)
        let v10 : UH5 = antimirov_residual_support_36(v8)
        antimirov_union_37(v9, v10)
    | UH4_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : UH5 = antimirov_residual_support_36(v12)
        let v15 : UH5 = antimirov_map_cat_right_40(v14, v13)
        let v16 : UH5 = antimirov_residual_support_36(v13)
        antimirov_union_37(v15, v16)
    | UH4_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH4 = UH4_RegexEpsilon
        let v5 : UH5 = UH5_RegexListNil
        UH5_RegexListCons(v4, v5)
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexListNil
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH5_RegexListNil
    | UH4_RegexStar(v18) -> (* RegexStar *)
        let v19 : UH5 = antimirov_residual_support_36(v18)
        let v20 : UH4 = UH4_RegexStar(v18)
        antimirov_map_cat_right_40(v19, v20)
and antimirov_origin_append_42 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH5 = antimirov_origin_append_42(v3, v1)
        UH5_RegexListCons(v2, v4)
    | UH5_RegexListNil -> (* RegexListNil *)
        v1
and antimirov_origin_map_cat_right_43 (v0 : UH5, v1 : UH4) : UH5 =
    match v0 with
    | UH5_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = make_cat_33(v3, v1)
        let v6 : UH4 = normalize_29(v5)
        let v7 : UH5 = antimirov_origin_map_cat_right_43(v4, v1)
        UH5_RegexListCons(v6, v7)
    | UH5_RegexListNil -> (* RegexListNil *)
        UH5_RegexListNil
and antimirov_position_origins_41 (v0 : UH4) : UH5 =
    match v0 with
    | UH4_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH5 = antimirov_position_origins_41(v7)
        let v10 : UH5 = antimirov_position_origins_41(v8)
        antimirov_origin_append_42(v9, v10)
    | UH4_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : UH5 = antimirov_position_origins_41(v12)
        let v15 : UH5 = antimirov_origin_map_cat_right_43(v14, v13)
        let v16 : UH5 = antimirov_position_origins_41(v13)
        antimirov_origin_append_42(v15, v16)
    | UH4_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH4 = UH4_RegexEpsilon
        let v5 : UH5 = UH5_RegexListNil
        UH5_RegexListCons(v4, v5)
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexListNil
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH5_RegexListNil
    | UH4_RegexStar(v18) -> (* RegexStar *)
        let v19 : UH5 = antimirov_position_origins_41(v18)
        let v20 : UH4 = UH4_RegexStar(v18)
        antimirov_origin_map_cat_right_43(v19, v20)
and regex_list_distinct_44 (v0 : UH5) : bool =
    match v0 with
    | UH5_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : bool = regex_list_contains_39(v1, v2)
        if v3 then
            false
        else
            regex_list_distinct_44(v2)
    | UH5_RegexListNil -> (* RegexListNil *)
        true
and antimirov_subset_45 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = normalize_29(v2)
        let v5 : bool = regex_list_contains_39(v4, v1)
        if v5 then
            antimirov_subset_45(v3, v1)
        else
            false
    | UH5_RegexListNil -> (* RegexListNil *)
        true
and regex_position_count_46 (v0 : UH4) : UH2 =
    match v0 with
    | UH4_RegexAlt(v6, v7) -> (* RegexAlt *)
        let v8 : UH2 = regex_position_count_46(v6)
        let v9 : UH2 = regex_position_count_46(v7)
        state_budget_add_18(v8, v9)
    | UH4_RegexCat(v11, v12) -> (* RegexCat *)
        let v13 : UH2 = regex_position_count_46(v11)
        let v14 : UH2 = regex_position_count_46(v12)
        state_budget_add_18(v13, v14)
    | UH4_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH2 = UH2_StateBudgetZero
        UH2_StateBudgetSucc(v4)
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH2_StateBudgetZero
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH2_StateBudgetZero
    | UH4_RegexStar(v16) -> (* RegexStar *)
        regex_position_count_46(v16)
and regex_list_exact_budget_47 (v0 : UH5, v1 : UH2) : bool =
    match v0 with
    | UH5_RegexListCons(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH2_StateBudgetSucc(v5) -> (* StateBudgetSucc *)
            regex_list_exact_budget_47(v4, v5)
        | _ ->
            false
    | UH5_RegexListNil -> (* RegexListNil *)
        match v1 with
        | UH2_StateBudgetZero -> (* StateBudgetZero *)
            true
        | _ ->
            false
and nullable_50 (v0 : UH4) : US2 =
    match v0 with
    | UH4_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_50(v5)
        let v8 : US2 = nullable_50(v6)
        match v7 with
        | US2_Nullable -> (* Nullable *)
            US2_Nullable
        | _ ->
            match v8 with
            | US2_Nullable -> (* Nullable *)
                US2_Nullable
            | _ ->
                match v7 with
                | US2_NonNullable -> (* NonNullable *)
                    match v8 with
                    | US2_NonNullable -> (* NonNullable *)
                        US2_NonNullable
    | UH4_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US2 = nullable_50(v16)
        let v19 : US2 = nullable_50(v17)
        match v18 with
        | US2_Nullable -> (* Nullable *)
            match v19 with
            | US2_Nullable -> (* Nullable *)
                US2_Nullable
            | _ ->
                US2_NonNullable
        | _ ->
            US2_NonNullable
    | UH4_RegexChar(v3) -> (* RegexChar *)
        US2_NonNullable
    | UH4_RegexEmpty -> (* RegexEmpty *)
        US2_NonNullable
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        US2_Nullable
    | UH4_RegexStar(v25) -> (* RegexStar *)
        US2_Nullable
and antimirov_partial_derivative_49 (v0 : UH4, v1 : US3) : UH5 =
    match v0 with
    | UH4_RegexAlt(v27, v28) -> (* RegexAlt *)
        let v29 : UH5 = antimirov_partial_derivative_49(v27, v1)
        let v30 : UH5 = antimirov_partial_derivative_49(v28, v1)
        antimirov_union_37(v29, v30)
    | UH4_RegexCat(v32, v33) -> (* RegexCat *)
        let v34 : UH5 = antimirov_partial_derivative_49(v32, v1)
        let v35 : UH5 = antimirov_map_cat_right_40(v34, v33)
        let v36 : US2 = nullable_50(v32)
        match v36 with
        | US2_NonNullable -> (* NonNullable *)
            v35
        | US2_Nullable -> (* Nullable *)
            let v37 : UH5 = antimirov_partial_derivative_49(v33, v1)
            antimirov_union_37(v35, v37)
    | UH4_RegexChar(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US3_TriA -> (* TriA *)
                match v1 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v1 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v4 with
                    | US3_TriB -> (* TriB *)
                        match v1 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US3_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US3_TriC -> (* TriC *)
                        match v1 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US3_TriC -> (* TriC *)
                            US1_SymbolSame
        let v21 : bool =
            match v20 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            let v22 : UH4 = UH4_RegexEpsilon
            let v23 : UH5 = UH5_RegexListNil
            UH5_RegexListCons(v22, v23)
        else
            UH5_RegexListNil
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexListNil
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH5_RegexListNil
    | UH4_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH5 = antimirov_partial_derivative_49(v41, v1)
        let v43 : UH4 = UH4_RegexStar(v41)
        antimirov_map_cat_right_40(v42, v43)
and antimirov_partial_derivatives_origin_supported_48 (v0 : UH4, v1 : UH6) : bool =
    match v1 with
    | UH6_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = normalize_29(v0)
        let v5 : UH5 = antimirov_partial_derivative_49(v4, v2)
        let v6 : UH5 = antimirov_position_origins_41(v4)
        let v7 : bool = antimirov_subset_45(v5, v6)
        if v7 then
            antimirov_partial_derivatives_origin_supported_48(v0, v3)
        else
            false
    | UH6_SymbolListNil -> (* SymbolListNil *)
        true
and antimirov_value_supported_for_symbols_52 (v0 : UH4, v1 : UH4, v2 : UH6) : bool =
    match v2 with
    | UH6_SymbolListCons(v3, v4) -> (* SymbolListCons *)
        let v5 : UH4 = normalize_29(v1)
        let v6 : UH5 = antimirov_partial_derivative_49(v5, v3)
        let v7 : UH4 = normalize_29(v0)
        let v8 : UH5 = antimirov_residual_support_36(v7)
        let v9 : UH5 = antimirov_insert_unique_38(v7, v8)
        let v10 : bool = antimirov_subset_45(v6, v9)
        if v10 then
            antimirov_value_supported_for_symbols_52(v0, v1, v4)
        else
            false
    | UH6_SymbolListNil -> (* SymbolListNil *)
        true
and antimirov_support_closed_51 (v0 : UH4, v1 : UH5, v2 : UH6) : bool =
    match v1 with
    | UH5_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : bool = antimirov_value_supported_for_symbols_52(v0, v3, v2)
        if v5 then
            antimirov_support_closed_51(v0, v4, v2)
        else
            false
    | UH5_RegexListNil -> (* RegexListNil *)
        true
and antimirov_state_regex_54 (v0 : UH5) : UH4 =
    match v0 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = antimirov_state_regex_54(v3)
        make_alt_30(v2, v4)
    | UH5_RegexListNil -> (* RegexListNil *)
        UH4_RegexEmpty
and derivative_56 (v0 : UH4, v1 : US3) : UH4 =
    match v0 with
    | UH4_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH4 = derivative_56(v25, v1)
        let v28 : UH4 = derivative_56(v26, v1)
        make_alt_30(v27, v28)
    | UH4_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_50(v30)
        match v32 with
        | US2_NonNullable -> (* NonNullable *)
            let v37 : UH4 = derivative_56(v30, v1)
            make_cat_33(v37, v31)
        | US2_Nullable -> (* Nullable *)
            let v33 : UH4 = derivative_56(v30, v1)
            let v34 : UH4 = make_cat_33(v33, v31)
            let v35 : UH4 = derivative_56(v31, v1)
            make_alt_30(v34, v35)
    | UH4_RegexChar(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US3_TriA -> (* TriA *)
                match v1 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v1 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v4 with
                    | US3_TriB -> (* TriB *)
                        match v1 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US3_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US3_TriC -> (* TriC *)
                        match v1 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US3_TriC -> (* TriC *)
                            US1_SymbolSame
        let v21 : bool =
            match v20 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH4_RegexEpsilon
        else
            UH4_RegexEmpty
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH4_RegexEmpty
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH4_RegexEmpty
    | UH4_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH4 = derivative_56(v41, v1)
        let v43 : UH4 = make_star_35(v41)
        make_cat_33(v42, v43)
and canonical_derivative_55 (v0 : UH4, v1 : US3) : UH4 =
    let v2 : UH4 = normalize_29(v0)
    let v3 : UH4 = derivative_56(v2, v1)
    normalize_29(v3)
and antimirov_reconstruction_symbols_53 (v0 : UH4, v1 : UH6) : bool =
    match v1 with
    | UH6_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = normalize_29(v0)
        let v5 : UH5 = antimirov_partial_derivative_49(v4, v2)
        let v6 : UH4 = antimirov_state_regex_54(v5)
        let v7 : UH4 = normalize_29(v6)
        let v8 : UH4 = canonical_derivative_55(v4, v2)
        let v9 : bool = regex_equal_34(v7, v8)
        if v9 then
            antimirov_reconstruction_symbols_53(v0, v3)
        else
            false
    | UH6_SymbolListNil -> (* SymbolListNil *)
        true
and regex_chars_from_symbols_57 (v0 : UH3) : UH1 =
    match v0 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH1 = regex_chars_from_symbols_57(v3)
        let v5 : UH0 = UH0_RegexChar(v2)
        UH1_RegexListCons(v5, v4)
    | UH3_SymbolListNil -> (* SymbolListNil *)
        UH1_RegexListNil
and regex_star_corpus_58 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = regex_star_corpus_58(v3)
        let v5 : UH0 = UH0_RegexStar(v2)
        UH1_RegexListCons(v5, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and regex_pairs_with_60 (v0 : UH0, v1 : UH1) : UH1 =
    match v1 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH1 = regex_pairs_with_60(v0, v4)
        let v6 : UH0 = UH0_RegexAlt(v0, v3)
        let v7 : UH0 = UH0_RegexCat(v0, v3)
        let v8 : UH1 = UH1_RegexListCons(v7, v5)
        UH1_RegexListCons(v6, v8)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and regex_list_append_61 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = regex_list_append_61(v3, v1)
        UH1_RegexListCons(v2, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        v1
and regex_binary_corpus_59 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH1 = regex_pairs_with_60(v3, v1)
        let v6 : UH1 = regex_binary_corpus_59(v4, v1)
        regex_list_append_61(v5, v6)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and regex_chars_from_symbols_62 (v0 : UH6) : UH5 =
    match v0 with
    | UH6_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH5 = regex_chars_from_symbols_62(v3)
        let v5 : UH4 = UH4_RegexChar(v2)
        UH5_RegexListCons(v5, v4)
    | UH6_SymbolListNil -> (* SymbolListNil *)
        UH5_RegexListNil
and regex_star_corpus_63 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH5 = regex_star_corpus_63(v3)
        let v5 : UH4 = UH4_RegexStar(v2)
        UH5_RegexListCons(v5, v4)
    | UH5_RegexListNil -> (* RegexListNil *)
        UH5_RegexListNil
and regex_pairs_with_65 (v0 : UH4, v1 : UH5) : UH5 =
    match v1 with
    | UH5_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH5 = regex_pairs_with_65(v0, v4)
        let v6 : UH4 = UH4_RegexAlt(v0, v3)
        let v7 : UH4 = UH4_RegexCat(v0, v3)
        let v8 : UH5 = UH5_RegexListCons(v7, v5)
        UH5_RegexListCons(v6, v8)
    | UH5_RegexListNil -> (* RegexListNil *)
        UH5_RegexListNil
and regex_list_append_66 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH5 = regex_list_append_66(v3, v1)
        UH5_RegexListCons(v2, v4)
    | UH5_RegexListNil -> (* RegexListNil *)
        v1
and regex_binary_corpus_64 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH5 = regex_pairs_with_65(v3, v1)
        let v6 : UH5 = regex_binary_corpus_64(v4, v1)
        regex_list_append_66(v5, v6)
    | UH5_RegexListNil -> (* RegexListNil *)
        UH5_RegexListNil
and antimirov_corpus_certificate_67 (v0 : UH1) : bool =
    match v0 with
    | UH1_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : UH0 = normalize_0(v1)
        let v4 : UH1 = antimirov_residual_support_7(v3)
        let v5 : UH1 = antimirov_insert_unique_9(v3, v4)
        let v6 : UH0 = normalize_0(v1)
        let v7 : UH1 = antimirov_position_origins_12(v6)
        let v8 : UH0 = normalize_0(v1)
        let v9 : UH1 = antimirov_residual_support_7(v8)
        let v10 : UH0 = normalize_0(v8)
        let v11 : UH1 = antimirov_residual_support_7(v10)
        let v12 : UH1 = antimirov_insert_unique_9(v10, v11)
        let v13 : bool = regex_list_distinct_15(v12)
        let v15 : bool =
            if v13 then
                antimirov_subset_16(v9, v7)
            else
                false
        let v17 : bool =
            if v15 then
                antimirov_subset_16(v7, v9)
            else
                false
        let v20 : bool =
            if v17 then
                let v18 : UH1 = UH1_RegexListCons(v8, v7)
                antimirov_subset_16(v12, v18)
            else
                false
        let v23 : bool =
            if v20 then
                let v21 : UH2 = regex_position_count_17(v8)
                regex_list_exact_budget_19(v7, v21)
            else
                false
        let v28 : bool =
            if v23 then
                let v24 : UH1 = UH1_RegexListCons(v8, v7)
                let v25 : UH2 = regex_position_count_17(v8)
                let v26 : UH2 = UH2_StateBudgetSucc(v25)
                regex_list_exact_budget_19(v24, v26)
            else
                false
        let v49 : bool =
            if v28 then
                let v29 : US0 = US0_BitZero
                let v30 : US0 = US0_BitOne
                let v31 : UH3 = UH3_SymbolListNil
                let v32 : UH3 = UH3_SymbolListCons(v30, v31)
                let v33 : UH3 = UH3_SymbolListCons(v29, v32)
                let v34 : bool = antimirov_partial_derivatives_origin_supported_20(v1, v33)
                if v34 then
                    let v35 : US0 = US0_BitZero
                    let v36 : US0 = US0_BitOne
                    let v37 : UH3 = UH3_SymbolListNil
                    let v38 : UH3 = UH3_SymbolListCons(v36, v37)
                    let v39 : UH3 = UH3_SymbolListCons(v35, v38)
                    let v40 : bool = antimirov_support_closed_23(v1, v5, v39)
                    if v40 then
                        let v41 : US0 = US0_BitZero
                        let v42 : US0 = US0_BitOne
                        let v43 : UH3 = UH3_SymbolListNil
                        let v44 : UH3 = UH3_SymbolListCons(v42, v43)
                        let v45 : UH3 = UH3_SymbolListCons(v41, v44)
                        antimirov_reconstruction_symbols_25(v1, v45)
                    else
                        false
                else
                    false
            else
                false
        if v49 then
            antimirov_corpus_certificate_67(v2)
        else
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and antimirov_corpus_certificate_68 (v0 : UH5) : bool =
    match v0 with
    | UH5_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : UH4 = normalize_29(v1)
        let v4 : UH5 = antimirov_residual_support_36(v3)
        let v5 : UH5 = antimirov_insert_unique_38(v3, v4)
        let v6 : UH4 = normalize_29(v1)
        let v7 : UH5 = antimirov_position_origins_41(v6)
        let v8 : UH4 = normalize_29(v1)
        let v9 : UH5 = antimirov_residual_support_36(v8)
        let v10 : UH4 = normalize_29(v8)
        let v11 : UH5 = antimirov_residual_support_36(v10)
        let v12 : UH5 = antimirov_insert_unique_38(v10, v11)
        let v13 : bool = regex_list_distinct_44(v12)
        let v15 : bool =
            if v13 then
                antimirov_subset_45(v9, v7)
            else
                false
        let v17 : bool =
            if v15 then
                antimirov_subset_45(v7, v9)
            else
                false
        let v20 : bool =
            if v17 then
                let v18 : UH5 = UH5_RegexListCons(v8, v7)
                antimirov_subset_45(v12, v18)
            else
                false
        let v23 : bool =
            if v20 then
                let v21 : UH2 = regex_position_count_46(v8)
                regex_list_exact_budget_47(v7, v21)
            else
                false
        let v28 : bool =
            if v23 then
                let v24 : UH5 = UH5_RegexListCons(v8, v7)
                let v25 : UH2 = regex_position_count_46(v8)
                let v26 : UH2 = UH2_StateBudgetSucc(v25)
                regex_list_exact_budget_47(v24, v26)
            else
                false
        let v55 : bool =
            if v28 then
                let v29 : US3 = US3_TriA
                let v30 : US3 = US3_TriB
                let v31 : US3 = US3_TriC
                let v32 : UH6 = UH6_SymbolListNil
                let v33 : UH6 = UH6_SymbolListCons(v31, v32)
                let v34 : UH6 = UH6_SymbolListCons(v30, v33)
                let v35 : UH6 = UH6_SymbolListCons(v29, v34)
                let v36 : bool = antimirov_partial_derivatives_origin_supported_48(v1, v35)
                if v36 then
                    let v37 : US3 = US3_TriA
                    let v38 : US3 = US3_TriB
                    let v39 : US3 = US3_TriC
                    let v40 : UH6 = UH6_SymbolListNil
                    let v41 : UH6 = UH6_SymbolListCons(v39, v40)
                    let v42 : UH6 = UH6_SymbolListCons(v38, v41)
                    let v43 : UH6 = UH6_SymbolListCons(v37, v42)
                    let v44 : bool = antimirov_support_closed_51(v1, v5, v43)
                    if v44 then
                        let v45 : US3 = US3_TriA
                        let v46 : US3 = US3_TriB
                        let v47 : US3 = US3_TriC
                        let v48 : UH6 = UH6_SymbolListNil
                        let v49 : UH6 = UH6_SymbolListCons(v47, v48)
                        let v50 : UH6 = UH6_SymbolListCons(v46, v49)
                        let v51 : UH6 = UH6_SymbolListCons(v45, v50)
                        antimirov_reconstruction_symbols_53(v1, v51)
                    else
                        false
                else
                    false
            else
                false
        if v55 then
            antimirov_corpus_certificate_68(v2)
        else
            false
    | UH5_RegexListNil -> (* RegexListNil *)
        true
and reference_derivative_69 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = reference_derivative_69(v19, v1)
        let v22 : UH0 = reference_derivative_69(v20, v1)
        UH0_RegexAlt(v21, v22)
    | UH0_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_22(v24)
        match v26 with
        | US2_NonNullable -> (* NonNullable *)
            let v31 : UH0 = reference_derivative_69(v24, v1)
            UH0_RegexCat(v31, v25)
        | US2_Nullable -> (* Nullable *)
            let v27 : UH0 = reference_derivative_69(v24, v1)
            let v28 : UH0 = reference_derivative_69(v25, v1)
            let v29 : UH0 = UH0_RegexCat(v27, v25)
            UH0_RegexAlt(v29, v28)
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
        let v36 : UH0 = reference_derivative_69(v35, v1)
        let v37 : UH0 = UH0_RegexStar(v35)
        UH0_RegexCat(v36, v37)
and contains_71 (v0 : US0, v1 : UH3) : bool =
    match v1 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_BitOne -> (* BitOne *)
                match v2 with
                | US0_BitOne -> (* BitOne *)
                    US1_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US1_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v2 with
                | US0_BitOne -> (* BitOne *)
                    US1_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US1_SymbolSame
        let v14 : bool =
            match v13 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v14 then
            true
        else
            contains_71(v0, v3)
    | UH3_SymbolListNil -> (* SymbolListNil *)
        false
and input_symbols_covered_70 (v0 : UH7, v1 : UH3) : bool =
    match v0 with
    | UH7_InputCons(v2, v3) -> (* InputCons *)
        let v4 : bool = contains_71(v2, v1)
        if v4 then
            input_symbols_covered_70(v3, v1)
        else
            false
    | UH7_InputEmpty -> (* InputEmpty *)
        true
and reference_derivative_72 (v0 : UH4, v1 : US3) : UH4 =
    match v0 with
    | UH4_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH4 = reference_derivative_72(v25, v1)
        let v28 : UH4 = reference_derivative_72(v26, v1)
        UH4_RegexAlt(v27, v28)
    | UH4_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_50(v30)
        match v32 with
        | US2_NonNullable -> (* NonNullable *)
            let v37 : UH4 = reference_derivative_72(v30, v1)
            UH4_RegexCat(v37, v31)
        | US2_Nullable -> (* Nullable *)
            let v33 : UH4 = reference_derivative_72(v30, v1)
            let v34 : UH4 = reference_derivative_72(v31, v1)
            let v35 : UH4 = UH4_RegexCat(v33, v31)
            UH4_RegexAlt(v35, v34)
    | UH4_RegexChar(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US3_TriA -> (* TriA *)
                match v1 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v1 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v4 with
                    | US3_TriB -> (* TriB *)
                        match v1 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US3_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US3_TriC -> (* TriC *)
                        match v1 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US3_TriC -> (* TriC *)
                            US1_SymbolSame
        let v21 : bool =
            match v20 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH4_RegexEpsilon
        else
            UH4_RegexEmpty
    | UH4_RegexEmpty -> (* RegexEmpty *)
        UH4_RegexEmpty
    | UH4_RegexEpsilon -> (* RegexEpsilon *)
        UH4_RegexEmpty
    | UH4_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH4 = reference_derivative_72(v41, v1)
        let v43 : UH4 = UH4_RegexStar(v41)
        UH4_RegexCat(v42, v43)
and contains_74 (v0 : US3, v1 : UH6) : bool =
    match v1 with
    | UH6_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v19 : US1 =
            match v0 with
            | US3_TriA -> (* TriA *)
                match v2 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v2 with
                | US3_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v0 with
                    | US3_TriB -> (* TriB *)
                        match v2 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US3_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US3_TriC -> (* TriC *)
                        match v2 with
                        | US3_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US3_TriC -> (* TriC *)
                            US1_SymbolSame
        let v20 : bool =
            match v19 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v20 then
            true
        else
            contains_74(v0, v3)
    | UH6_SymbolListNil -> (* SymbolListNil *)
        false
and input_symbols_covered_73 (v0 : UH8, v1 : UH6) : bool =
    match v0 with
    | UH8_InputCons(v2, v3) -> (* InputCons *)
        let v4 : bool = contains_74(v2, v1)
        if v4 then
            input_symbols_covered_73(v3, v1)
        else
            false
    | UH8_InputEmpty -> (* InputEmpty *)
        true
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
let v10 : UH1 = antimirov_residual_support_7(v9)
let v11 : UH1 = antimirov_insert_unique_9(v9, v10)
let v12 : US0 = US0_BitZero
let v13 : UH0 = UH0_RegexChar(v12)
let v14 : US0 = US0_BitOne
let v15 : UH0 = UH0_RegexChar(v14)
let v16 : UH0 = UH0_RegexAlt(v13, v15)
let v17 : UH0 = UH0_RegexStar(v16)
let v18 : US0 = US0_BitZero
let v19 : UH0 = UH0_RegexChar(v18)
let v20 : UH0 = UH0_RegexCat(v17, v19)
let v21 : UH0 = normalize_0(v20)
let v22 : UH1 = antimirov_position_origins_12(v21)
let v23 : US0 = US0_BitZero
let v24 : UH0 = UH0_RegexChar(v23)
let v25 : US0 = US0_BitOne
let v26 : UH0 = UH0_RegexChar(v25)
let v27 : UH0 = UH0_RegexAlt(v24, v26)
let v28 : UH0 = UH0_RegexStar(v27)
let v29 : US0 = US0_BitZero
let v30 : UH0 = UH0_RegexChar(v29)
let v31 : UH0 = UH0_RegexCat(v28, v30)
let v32 : UH0 = normalize_0(v31)
let v33 : UH1 = antimirov_residual_support_7(v32)
let v34 : UH0 = normalize_0(v32)
let v35 : UH1 = antimirov_residual_support_7(v34)
let v36 : UH1 = antimirov_insert_unique_9(v34, v35)
let v37 : bool = regex_list_distinct_15(v36)
let v39 : bool =
    if v37 then
        antimirov_subset_16(v33, v22)
    else
        false
let v41 : bool =
    if v39 then
        antimirov_subset_16(v22, v33)
    else
        false
let v44 : bool =
    if v41 then
        let v42 : UH1 = UH1_RegexListCons(v32, v22)
        antimirov_subset_16(v36, v42)
    else
        false
let v47 : bool =
    if v44 then
        let v45 : UH2 = regex_position_count_17(v32)
        regex_list_exact_budget_19(v22, v45)
    else
        false
let v52 : bool =
    if v47 then
        let v48 : UH1 = UH1_RegexListCons(v32, v22)
        let v49 : UH2 = regex_position_count_17(v32)
        let v50 : UH2 = UH2_StateBudgetSucc(v49)
        regex_list_exact_budget_19(v48, v50)
    else
        false
let v100 : bool =
    if v52 then
        let v53 : US0 = US0_BitZero
        let v54 : UH0 = UH0_RegexChar(v53)
        let v55 : US0 = US0_BitOne
        let v56 : UH0 = UH0_RegexChar(v55)
        let v57 : UH0 = UH0_RegexAlt(v54, v56)
        let v58 : UH0 = UH0_RegexStar(v57)
        let v59 : US0 = US0_BitZero
        let v60 : UH0 = UH0_RegexChar(v59)
        let v61 : UH0 = UH0_RegexCat(v58, v60)
        let v62 : US0 = US0_BitZero
        let v63 : US0 = US0_BitOne
        let v64 : UH3 = UH3_SymbolListNil
        let v65 : UH3 = UH3_SymbolListCons(v63, v64)
        let v66 : UH3 = UH3_SymbolListCons(v62, v65)
        let v67 : bool = antimirov_partial_derivatives_origin_supported_20(v61, v66)
        if v67 then
            let v68 : US0 = US0_BitZero
            let v69 : UH0 = UH0_RegexChar(v68)
            let v70 : US0 = US0_BitOne
            let v71 : UH0 = UH0_RegexChar(v70)
            let v72 : UH0 = UH0_RegexAlt(v69, v71)
            let v73 : UH0 = UH0_RegexStar(v72)
            let v74 : US0 = US0_BitZero
            let v75 : UH0 = UH0_RegexChar(v74)
            let v76 : UH0 = UH0_RegexCat(v73, v75)
            let v77 : US0 = US0_BitZero
            let v78 : US0 = US0_BitOne
            let v79 : UH3 = UH3_SymbolListNil
            let v80 : UH3 = UH3_SymbolListCons(v78, v79)
            let v81 : UH3 = UH3_SymbolListCons(v77, v80)
            let v82 : bool = antimirov_support_closed_23(v76, v11, v81)
            if v82 then
                let v83 : US0 = US0_BitZero
                let v84 : UH0 = UH0_RegexChar(v83)
                let v85 : US0 = US0_BitOne
                let v86 : UH0 = UH0_RegexChar(v85)
                let v87 : UH0 = UH0_RegexAlt(v84, v86)
                let v88 : UH0 = UH0_RegexStar(v87)
                let v89 : US0 = US0_BitZero
                let v90 : UH0 = UH0_RegexChar(v89)
                let v91 : UH0 = UH0_RegexCat(v88, v90)
                let v92 : US0 = US0_BitZero
                let v93 : US0 = US0_BitOne
                let v94 : UH3 = UH3_SymbolListNil
                let v95 : UH3 = UH3_SymbolListCons(v93, v94)
                let v96 : UH3 = UH3_SymbolListCons(v92, v95)
                antimirov_reconstruction_symbols_25(v91, v96)
            else
                false
        else
            false
    else
        false
if v100 then
    ()
else
    failwith<unit> "Brzozowski state must reconstruct from its Antimirov partial-derivative subset"
let v101 : US0 = US0_BitZero
let v102 : UH0 = UH0_RegexChar(v101)
let v103 : US0 = US0_BitOne
let v104 : UH0 = UH0_RegexChar(v103)
let v105 : UH0 = UH0_RegexAlt(v102, v104)
let v106 : UH0 = UH0_RegexStar(v105)
let v107 : US0 = US0_BitZero
let v108 : UH0 = UH0_RegexChar(v107)
let v109 : UH0 = UH0_RegexCat(v106, v108)
let v110 : UH0 = normalize_0(v109)
let v111 : UH1 = antimirov_position_origins_12(v110)
let v118 : bool =
    match v111 with
    | UH1_RegexListCons(v112, v113) -> (* RegexListCons *)
        let v114 : UH2 = regex_position_count_17(v110)
        let v115 : bool = regex_list_exact_budget_19(v113, v114)
        let v116 : bool = v115 = false
        v116
    | UH1_RegexListNil -> (* RegexListNil *)
        false
if v118 then
    ()
else
    failwith<unit> "removing one concrete bit origin must violate the exact position count"
let v119 : UH1 = antimirov_position_origins_12(v110)
let v155 : bool =
    match v119 with
    | UH1_RegexListCons(v120, v121) -> (* RegexListCons *)
        let v122 : UH0 = normalize_0(v110)
        let v123 : UH1 = antimirov_residual_support_7(v122)
        let v124 : UH0 = normalize_0(v122)
        let v125 : UH1 = antimirov_residual_support_7(v124)
        let v126 : UH1 = antimirov_insert_unique_9(v124, v125)
        let v127 : bool = regex_list_distinct_15(v126)
        let v131 : bool =
            if v127 then
                let v128 : UH0 = UH0_RegexEmpty
                let v129 : UH1 = UH1_RegexListCons(v128, v121)
                antimirov_subset_16(v123, v129)
            else
                false
        let v135 : bool =
            if v131 then
                let v132 : UH0 = UH0_RegexEmpty
                let v133 : UH1 = UH1_RegexListCons(v132, v121)
                antimirov_subset_16(v133, v123)
            else
                false
        let v140 : bool =
            if v135 then
                let v136 : UH0 = UH0_RegexEmpty
                let v137 : UH1 = UH1_RegexListCons(v136, v121)
                let v138 : UH1 = UH1_RegexListCons(v122, v137)
                antimirov_subset_16(v126, v138)
            else
                false
        let v145 : bool =
            if v140 then
                let v141 : UH0 = UH0_RegexEmpty
                let v142 : UH1 = UH1_RegexListCons(v141, v121)
                let v143 : UH2 = regex_position_count_17(v122)
                regex_list_exact_budget_19(v142, v143)
            else
                false
        let v152 : bool =
            if v145 then
                let v146 : UH0 = UH0_RegexEmpty
                let v147 : UH1 = UH1_RegexListCons(v146, v121)
                let v148 : UH1 = UH1_RegexListCons(v122, v147)
                let v149 : UH2 = regex_position_count_17(v122)
                let v150 : UH2 = UH2_StateBudgetSucc(v149)
                regex_list_exact_budget_19(v148, v150)
            else
                false
        let v153 : bool = v152 = false
        v153
    | UH1_RegexListNil -> (* RegexListNil *)
        false
if v155 then
    ()
else
    failwith<unit> "a same-cardinality forged origin set must fail semantic origin validation"
let v156 : US3 = US3_TriA
let v157 : UH4 = UH4_RegexChar(v156)
let v158 : UH4 = UH4_RegexStar(v157)
let v159 : UH4 = normalize_29(v158)
let v160 : UH5 = antimirov_residual_support_36(v159)
let v161 : UH5 = antimirov_insert_unique_38(v159, v160)
let v162 : US3 = US3_TriA
let v163 : UH4 = UH4_RegexChar(v162)
let v164 : UH4 = UH4_RegexStar(v163)
let v165 : UH4 = normalize_29(v164)
let v166 : UH5 = antimirov_position_origins_41(v165)
let v167 : US3 = US3_TriA
let v168 : UH4 = UH4_RegexChar(v167)
let v169 : UH4 = UH4_RegexStar(v168)
let v170 : UH4 = normalize_29(v169)
let v171 : UH5 = antimirov_residual_support_36(v170)
let v172 : UH4 = normalize_29(v170)
let v173 : UH5 = antimirov_residual_support_36(v172)
let v174 : UH5 = antimirov_insert_unique_38(v172, v173)
let v175 : bool = regex_list_distinct_44(v174)
let v177 : bool =
    if v175 then
        antimirov_subset_45(v171, v166)
    else
        false
let v179 : bool =
    if v177 then
        antimirov_subset_45(v166, v171)
    else
        false
let v182 : bool =
    if v179 then
        let v180 : UH5 = UH5_RegexListCons(v170, v166)
        antimirov_subset_45(v174, v180)
    else
        false
let v185 : bool =
    if v182 then
        let v183 : UH2 = regex_position_count_46(v170)
        regex_list_exact_budget_47(v166, v183)
    else
        false
let v190 : bool =
    if v185 then
        let v186 : UH5 = UH5_RegexListCons(v170, v166)
        let v187 : UH2 = regex_position_count_46(v170)
        let v188 : UH2 = UH2_StateBudgetSucc(v187)
        regex_list_exact_budget_47(v186, v188)
    else
        false
let v226 : bool =
    if v190 then
        let v191 : US3 = US3_TriA
        let v192 : UH4 = UH4_RegexChar(v191)
        let v193 : UH4 = UH4_RegexStar(v192)
        let v194 : US3 = US3_TriA
        let v195 : US3 = US3_TriB
        let v196 : US3 = US3_TriC
        let v197 : UH6 = UH6_SymbolListNil
        let v198 : UH6 = UH6_SymbolListCons(v196, v197)
        let v199 : UH6 = UH6_SymbolListCons(v195, v198)
        let v200 : UH6 = UH6_SymbolListCons(v194, v199)
        let v201 : bool = antimirov_partial_derivatives_origin_supported_48(v193, v200)
        if v201 then
            let v202 : US3 = US3_TriA
            let v203 : UH4 = UH4_RegexChar(v202)
            let v204 : UH4 = UH4_RegexStar(v203)
            let v205 : US3 = US3_TriA
            let v206 : US3 = US3_TriB
            let v207 : US3 = US3_TriC
            let v208 : UH6 = UH6_SymbolListNil
            let v209 : UH6 = UH6_SymbolListCons(v207, v208)
            let v210 : UH6 = UH6_SymbolListCons(v206, v209)
            let v211 : UH6 = UH6_SymbolListCons(v205, v210)
            let v212 : bool = antimirov_support_closed_51(v204, v161, v211)
            if v212 then
                let v213 : US3 = US3_TriA
                let v214 : UH4 = UH4_RegexChar(v213)
                let v215 : UH4 = UH4_RegexStar(v214)
                let v216 : US3 = US3_TriA
                let v217 : US3 = US3_TriB
                let v218 : US3 = US3_TriC
                let v219 : UH6 = UH6_SymbolListNil
                let v220 : UH6 = UH6_SymbolListCons(v218, v219)
                let v221 : UH6 = UH6_SymbolListCons(v217, v220)
                let v222 : UH6 = UH6_SymbolListCons(v216, v221)
                antimirov_reconstruction_symbols_53(v215, v222)
            else
                false
        else
            false
    else
        false
if v226 then
    ()
else
    failwith<unit> "ternary star partial-derivative support must remain bounded and closed"
let v227 : US3 = US3_TriA
let v228 : UH4 = UH4_RegexChar(v227)
let v229 : US3 = US3_TriB
let v230 : UH4 = UH4_RegexChar(v229)
let v231 : UH4 = UH4_RegexAlt(v228, v230)
let v232 : UH4 = UH4_RegexStar(v231)
let v233 : US3 = US3_TriC
let v234 : UH4 = UH4_RegexChar(v233)
let v235 : UH4 = UH4_RegexCat(v232, v234)
let v236 : UH4 = normalize_29(v235)
let v237 : UH5 = antimirov_residual_support_36(v236)
let v238 : UH5 = antimirov_insert_unique_38(v236, v237)
let v239 : US3 = US3_TriA
let v240 : UH4 = UH4_RegexChar(v239)
let v241 : US3 = US3_TriB
let v242 : UH4 = UH4_RegexChar(v241)
let v243 : UH4 = UH4_RegexAlt(v240, v242)
let v244 : UH4 = UH4_RegexStar(v243)
let v245 : US3 = US3_TriC
let v246 : UH4 = UH4_RegexChar(v245)
let v247 : UH4 = UH4_RegexCat(v244, v246)
let v248 : UH4 = normalize_29(v247)
let v249 : UH5 = antimirov_position_origins_41(v248)
let v250 : US3 = US3_TriA
let v251 : UH4 = UH4_RegexChar(v250)
let v252 : US3 = US3_TriB
let v253 : UH4 = UH4_RegexChar(v252)
let v254 : UH4 = UH4_RegexAlt(v251, v253)
let v255 : UH4 = UH4_RegexStar(v254)
let v256 : US3 = US3_TriC
let v257 : UH4 = UH4_RegexChar(v256)
let v258 : UH4 = UH4_RegexCat(v255, v257)
let v259 : UH4 = normalize_29(v258)
let v260 : UH5 = antimirov_residual_support_36(v259)
let v261 : UH4 = normalize_29(v259)
let v262 : UH5 = antimirov_residual_support_36(v261)
let v263 : UH5 = antimirov_insert_unique_38(v261, v262)
let v264 : bool = regex_list_distinct_44(v263)
let v266 : bool =
    if v264 then
        antimirov_subset_45(v260, v249)
    else
        false
let v268 : bool =
    if v266 then
        antimirov_subset_45(v249, v260)
    else
        false
let v271 : bool =
    if v268 then
        let v269 : UH5 = UH5_RegexListCons(v259, v249)
        antimirov_subset_45(v263, v269)
    else
        false
let v274 : bool =
    if v271 then
        let v272 : UH2 = regex_position_count_46(v259)
        regex_list_exact_budget_47(v249, v272)
    else
        false
let v279 : bool =
    if v274 then
        let v275 : UH5 = UH5_RegexListCons(v259, v249)
        let v276 : UH2 = regex_position_count_46(v259)
        let v277 : UH2 = UH2_StateBudgetSucc(v276)
        regex_list_exact_budget_47(v275, v277)
    else
        false
let v333 : bool =
    if v279 then
        let v280 : US3 = US3_TriA
        let v281 : UH4 = UH4_RegexChar(v280)
        let v282 : US3 = US3_TriB
        let v283 : UH4 = UH4_RegexChar(v282)
        let v284 : UH4 = UH4_RegexAlt(v281, v283)
        let v285 : UH4 = UH4_RegexStar(v284)
        let v286 : US3 = US3_TriC
        let v287 : UH4 = UH4_RegexChar(v286)
        let v288 : UH4 = UH4_RegexCat(v285, v287)
        let v289 : US3 = US3_TriA
        let v290 : US3 = US3_TriB
        let v291 : US3 = US3_TriC
        let v292 : UH6 = UH6_SymbolListNil
        let v293 : UH6 = UH6_SymbolListCons(v291, v292)
        let v294 : UH6 = UH6_SymbolListCons(v290, v293)
        let v295 : UH6 = UH6_SymbolListCons(v289, v294)
        let v296 : bool = antimirov_partial_derivatives_origin_supported_48(v288, v295)
        if v296 then
            let v297 : US3 = US3_TriA
            let v298 : UH4 = UH4_RegexChar(v297)
            let v299 : US3 = US3_TriB
            let v300 : UH4 = UH4_RegexChar(v299)
            let v301 : UH4 = UH4_RegexAlt(v298, v300)
            let v302 : UH4 = UH4_RegexStar(v301)
            let v303 : US3 = US3_TriC
            let v304 : UH4 = UH4_RegexChar(v303)
            let v305 : UH4 = UH4_RegexCat(v302, v304)
            let v306 : US3 = US3_TriA
            let v307 : US3 = US3_TriB
            let v308 : US3 = US3_TriC
            let v309 : UH6 = UH6_SymbolListNil
            let v310 : UH6 = UH6_SymbolListCons(v308, v309)
            let v311 : UH6 = UH6_SymbolListCons(v307, v310)
            let v312 : UH6 = UH6_SymbolListCons(v306, v311)
            let v313 : bool = antimirov_support_closed_51(v305, v238, v312)
            if v313 then
                let v314 : US3 = US3_TriA
                let v315 : UH4 = UH4_RegexChar(v314)
                let v316 : US3 = US3_TriB
                let v317 : UH4 = UH4_RegexChar(v316)
                let v318 : UH4 = UH4_RegexAlt(v315, v317)
                let v319 : UH4 = UH4_RegexStar(v318)
                let v320 : US3 = US3_TriC
                let v321 : UH4 = UH4_RegexChar(v320)
                let v322 : UH4 = UH4_RegexCat(v319, v321)
                let v323 : US3 = US3_TriA
                let v324 : US3 = US3_TriB
                let v325 : US3 = US3_TriC
                let v326 : UH6 = UH6_SymbolListNil
                let v327 : UH6 = UH6_SymbolListCons(v325, v326)
                let v328 : UH6 = UH6_SymbolListCons(v324, v327)
                let v329 : UH6 = UH6_SymbolListCons(v323, v328)
                antimirov_reconstruction_symbols_53(v322, v329)
            else
                false
        else
            false
    else
        false
if v333 then
    ()
else
    failwith<unit> "ternary concatenation/alt/star support must remain bounded and closed"
let v334 : US3 = US3_TriA
let v335 : UH4 = UH4_RegexChar(v334)
let v336 : US3 = US3_TriB
let v337 : UH4 = UH4_RegexChar(v336)
let v338 : UH4 = UH4_RegexAlt(v335, v337)
let v339 : UH4 = UH4_RegexStar(v338)
let v340 : US3 = US3_TriC
let v341 : UH4 = UH4_RegexChar(v340)
let v342 : UH4 = UH4_RegexCat(v339, v341)
let v343 : UH4 = normalize_29(v342)
let v344 : UH5 = antimirov_position_origins_41(v343)
let v351 : bool =
    match v344 with
    | UH5_RegexListCons(v345, v346) -> (* RegexListCons *)
        let v347 : UH2 = regex_position_count_46(v343)
        let v348 : bool = regex_list_exact_budget_47(v346, v347)
        let v349 : bool = v348 = false
        v349
    | UH5_RegexListNil -> (* RegexListNil *)
        false
if v351 then
    ()
else
    failwith<unit> "removing one concrete ternary origin must violate the exact position count"
let v352 : US0 = US0_BitZero
let v353 : US0 = US0_BitOne
let v354 : UH3 = UH3_SymbolListNil
let v355 : UH3 = UH3_SymbolListCons(v353, v354)
let v356 : UH3 = UH3_SymbolListCons(v352, v355)
let v357 : UH1 = regex_chars_from_symbols_57(v356)
let v358 : UH0 = UH0_RegexEmpty
let v359 : UH0 = UH0_RegexEpsilon
let v360 : UH1 = UH1_RegexListCons(v359, v357)
let v361 : UH1 = UH1_RegexListCons(v358, v360)
let v362 : UH0 = UH0_RegexEmpty
let v363 : UH0 = UH0_RegexEpsilon
let v364 : UH1 = UH1_RegexListCons(v363, v357)
let v365 : UH1 = UH1_RegexListCons(v362, v364)
let v366 : UH1 = regex_star_corpus_58(v365)
let v367 : UH0 = UH0_RegexEmpty
let v368 : UH0 = UH0_RegexEpsilon
let v369 : UH1 = UH1_RegexListCons(v368, v357)
let v370 : UH1 = UH1_RegexListCons(v367, v369)
let v371 : UH0 = UH0_RegexEmpty
let v372 : UH0 = UH0_RegexEpsilon
let v373 : UH1 = UH1_RegexListCons(v372, v357)
let v374 : UH1 = UH1_RegexListCons(v371, v373)
let v375 : UH1 = regex_binary_corpus_59(v370, v374)
let v376 : UH1 = regex_list_append_61(v366, v375)
let v377 : UH1 = regex_list_append_61(v361, v376)
let v378 : US3 = US3_TriA
let v379 : US3 = US3_TriB
let v380 : US3 = US3_TriC
let v381 : UH6 = UH6_SymbolListNil
let v382 : UH6 = UH6_SymbolListCons(v380, v381)
let v383 : UH6 = UH6_SymbolListCons(v379, v382)
let v384 : UH6 = UH6_SymbolListCons(v378, v383)
let v385 : UH5 = regex_chars_from_symbols_62(v384)
let v386 : UH4 = UH4_RegexEmpty
let v387 : UH4 = UH4_RegexEpsilon
let v388 : UH5 = UH5_RegexListCons(v387, v385)
let v389 : UH5 = UH5_RegexListCons(v386, v388)
let v390 : UH4 = UH4_RegexEmpty
let v391 : UH4 = UH4_RegexEpsilon
let v392 : UH5 = UH5_RegexListCons(v391, v385)
let v393 : UH5 = UH5_RegexListCons(v390, v392)
let v394 : UH5 = regex_star_corpus_63(v393)
let v395 : UH4 = UH4_RegexEmpty
let v396 : UH4 = UH4_RegexEpsilon
let v397 : UH5 = UH5_RegexListCons(v396, v385)
let v398 : UH5 = UH5_RegexListCons(v395, v397)
let v399 : UH4 = UH4_RegexEmpty
let v400 : UH4 = UH4_RegexEpsilon
let v401 : UH5 = UH5_RegexListCons(v400, v385)
let v402 : UH5 = UH5_RegexListCons(v399, v401)
let v403 : UH5 = regex_binary_corpus_64(v398, v402)
let v404 : UH5 = regex_list_append_66(v394, v403)
let v405 : UH5 = regex_list_append_66(v389, v404)
let v406 : bool = antimirov_corpus_certificate_67(v377)
if v406 then
    ()
else
    failwith<unit> "depth-one bit corpus must satisfy Antimirov reconstruction, support closure and positions-plus-one bound"
let v407 : bool = antimirov_corpus_certificate_68(v405)
if v407 then
    ()
else
    failwith<unit> "depth-one ternary corpus must satisfy Antimirov reconstruction, support closure and positions-plus-one bound"
let v408 : US0 = US0_BitZero
let v409 : UH0 = UH0_RegexChar(v408)
let v410 : US0 = US0_BitOne
let v411 : UH0 = UH0_RegexChar(v410)
let v412 : UH0 = UH0_RegexAlt(v409, v411)
let v413 : UH0 = UH0_RegexStar(v412)
let v414 : US0 = US0_BitZero
let v415 : UH0 = UH0_RegexChar(v414)
let v416 : UH0 = UH0_RegexCat(v413, v415)
let v417 : UH0 = normalize_0(v416)
let v418 : UH1 = antimirov_residual_support_7(v417)
let v419 : UH1 = antimirov_insert_unique_9(v417, v418)
let v420 : US0 = US0_BitZero
let v421 : UH0 = UH0_RegexChar(v420)
let v422 : US0 = US0_BitOne
let v423 : UH0 = UH0_RegexChar(v422)
let v424 : UH0 = UH0_RegexAlt(v421, v423)
let v425 : UH0 = UH0_RegexStar(v424)
let v426 : US0 = US0_BitZero
let v427 : UH0 = UH0_RegexChar(v426)
let v428 : UH0 = UH0_RegexCat(v425, v427)
let v429 : UH0 = normalize_0(v428)
let v430 : UH1 = antimirov_position_origins_12(v429)
let v431 : US0 = US0_BitZero
let v432 : UH0 = UH0_RegexChar(v431)
let v433 : US0 = US0_BitOne
let v434 : UH0 = UH0_RegexChar(v433)
let v435 : UH0 = UH0_RegexAlt(v432, v434)
let v436 : UH0 = UH0_RegexStar(v435)
let v437 : US0 = US0_BitZero
let v438 : UH0 = UH0_RegexChar(v437)
let v439 : UH0 = UH0_RegexCat(v436, v438)
let v440 : UH0 = normalize_0(v439)
let v441 : UH1 = antimirov_residual_support_7(v440)
let v442 : UH0 = normalize_0(v440)
let v443 : UH1 = antimirov_residual_support_7(v442)
let v444 : UH1 = antimirov_insert_unique_9(v442, v443)
let v445 : bool = regex_list_distinct_15(v444)
let v447 : bool =
    if v445 then
        antimirov_subset_16(v441, v430)
    else
        false
let v449 : bool =
    if v447 then
        antimirov_subset_16(v430, v441)
    else
        false
let v452 : bool =
    if v449 then
        let v450 : UH1 = UH1_RegexListCons(v440, v430)
        antimirov_subset_16(v444, v450)
    else
        false
let v455 : bool =
    if v452 then
        let v453 : UH2 = regex_position_count_17(v440)
        regex_list_exact_budget_19(v430, v453)
    else
        false
let v460 : bool =
    if v455 then
        let v456 : UH1 = UH1_RegexListCons(v440, v430)
        let v457 : UH2 = regex_position_count_17(v440)
        let v458 : UH2 = UH2_StateBudgetSucc(v457)
        regex_list_exact_budget_19(v456, v458)
    else
        false
let v508 : bool =
    if v460 then
        let v461 : US0 = US0_BitZero
        let v462 : UH0 = UH0_RegexChar(v461)
        let v463 : US0 = US0_BitOne
        let v464 : UH0 = UH0_RegexChar(v463)
        let v465 : UH0 = UH0_RegexAlt(v462, v464)
        let v466 : UH0 = UH0_RegexStar(v465)
        let v467 : US0 = US0_BitZero
        let v468 : UH0 = UH0_RegexChar(v467)
        let v469 : UH0 = UH0_RegexCat(v466, v468)
        let v470 : US0 = US0_BitZero
        let v471 : US0 = US0_BitOne
        let v472 : UH3 = UH3_SymbolListNil
        let v473 : UH3 = UH3_SymbolListCons(v471, v472)
        let v474 : UH3 = UH3_SymbolListCons(v470, v473)
        let v475 : bool = antimirov_partial_derivatives_origin_supported_20(v469, v474)
        if v475 then
            let v476 : US0 = US0_BitZero
            let v477 : UH0 = UH0_RegexChar(v476)
            let v478 : US0 = US0_BitOne
            let v479 : UH0 = UH0_RegexChar(v478)
            let v480 : UH0 = UH0_RegexAlt(v477, v479)
            let v481 : UH0 = UH0_RegexStar(v480)
            let v482 : US0 = US0_BitZero
            let v483 : UH0 = UH0_RegexChar(v482)
            let v484 : UH0 = UH0_RegexCat(v481, v483)
            let v485 : US0 = US0_BitZero
            let v486 : US0 = US0_BitOne
            let v487 : UH3 = UH3_SymbolListNil
            let v488 : UH3 = UH3_SymbolListCons(v486, v487)
            let v489 : UH3 = UH3_SymbolListCons(v485, v488)
            let v490 : bool = antimirov_support_closed_23(v484, v419, v489)
            if v490 then
                let v491 : US0 = US0_BitZero
                let v492 : UH0 = UH0_RegexChar(v491)
                let v493 : US0 = US0_BitOne
                let v494 : UH0 = UH0_RegexChar(v493)
                let v495 : UH0 = UH0_RegexAlt(v492, v494)
                let v496 : UH0 = UH0_RegexStar(v495)
                let v497 : US0 = US0_BitZero
                let v498 : UH0 = UH0_RegexChar(v497)
                let v499 : UH0 = UH0_RegexCat(v496, v498)
                let v500 : US0 = US0_BitZero
                let v501 : US0 = US0_BitOne
                let v502 : UH3 = UH3_SymbolListNil
                let v503 : UH3 = UH3_SymbolListCons(v501, v502)
                let v504 : UH3 = UH3_SymbolListCons(v500, v503)
                antimirov_reconstruction_symbols_25(v499, v504)
            else
                false
        else
            false
    else
        false
let v616 : bool =
    if v508 then
        let v509 : US3 = US3_TriA
        let v510 : UH4 = UH4_RegexChar(v509)
        let v511 : US3 = US3_TriB
        let v512 : UH4 = UH4_RegexChar(v511)
        let v513 : UH4 = UH4_RegexAlt(v510, v512)
        let v514 : UH4 = UH4_RegexStar(v513)
        let v515 : US3 = US3_TriC
        let v516 : UH4 = UH4_RegexChar(v515)
        let v517 : UH4 = UH4_RegexCat(v514, v516)
        let v518 : UH4 = normalize_29(v517)
        let v519 : UH5 = antimirov_residual_support_36(v518)
        let v520 : UH5 = antimirov_insert_unique_38(v518, v519)
        let v521 : US3 = US3_TriA
        let v522 : UH4 = UH4_RegexChar(v521)
        let v523 : US3 = US3_TriB
        let v524 : UH4 = UH4_RegexChar(v523)
        let v525 : UH4 = UH4_RegexAlt(v522, v524)
        let v526 : UH4 = UH4_RegexStar(v525)
        let v527 : US3 = US3_TriC
        let v528 : UH4 = UH4_RegexChar(v527)
        let v529 : UH4 = UH4_RegexCat(v526, v528)
        let v530 : UH4 = normalize_29(v529)
        let v531 : UH5 = antimirov_position_origins_41(v530)
        let v532 : US3 = US3_TriA
        let v533 : UH4 = UH4_RegexChar(v532)
        let v534 : US3 = US3_TriB
        let v535 : UH4 = UH4_RegexChar(v534)
        let v536 : UH4 = UH4_RegexAlt(v533, v535)
        let v537 : UH4 = UH4_RegexStar(v536)
        let v538 : US3 = US3_TriC
        let v539 : UH4 = UH4_RegexChar(v538)
        let v540 : UH4 = UH4_RegexCat(v537, v539)
        let v541 : UH4 = normalize_29(v540)
        let v542 : UH5 = antimirov_residual_support_36(v541)
        let v543 : UH4 = normalize_29(v541)
        let v544 : UH5 = antimirov_residual_support_36(v543)
        let v545 : UH5 = antimirov_insert_unique_38(v543, v544)
        let v546 : bool = regex_list_distinct_44(v545)
        let v548 : bool =
            if v546 then
                antimirov_subset_45(v542, v531)
            else
                false
        let v550 : bool =
            if v548 then
                antimirov_subset_45(v531, v542)
            else
                false
        let v553 : bool =
            if v550 then
                let v551 : UH5 = UH5_RegexListCons(v541, v531)
                antimirov_subset_45(v545, v551)
            else
                false
        let v556 : bool =
            if v553 then
                let v554 : UH2 = regex_position_count_46(v541)
                regex_list_exact_budget_47(v531, v554)
            else
                false
        let v561 : bool =
            if v556 then
                let v557 : UH5 = UH5_RegexListCons(v541, v531)
                let v558 : UH2 = regex_position_count_46(v541)
                let v559 : UH2 = UH2_StateBudgetSucc(v558)
                regex_list_exact_budget_47(v557, v559)
            else
                false
        if v561 then
            let v562 : US3 = US3_TriA
            let v563 : UH4 = UH4_RegexChar(v562)
            let v564 : US3 = US3_TriB
            let v565 : UH4 = UH4_RegexChar(v564)
            let v566 : UH4 = UH4_RegexAlt(v563, v565)
            let v567 : UH4 = UH4_RegexStar(v566)
            let v568 : US3 = US3_TriC
            let v569 : UH4 = UH4_RegexChar(v568)
            let v570 : UH4 = UH4_RegexCat(v567, v569)
            let v571 : US3 = US3_TriA
            let v572 : US3 = US3_TriB
            let v573 : US3 = US3_TriC
            let v574 : UH6 = UH6_SymbolListNil
            let v575 : UH6 = UH6_SymbolListCons(v573, v574)
            let v576 : UH6 = UH6_SymbolListCons(v572, v575)
            let v577 : UH6 = UH6_SymbolListCons(v571, v576)
            let v578 : bool = antimirov_partial_derivatives_origin_supported_48(v570, v577)
            if v578 then
                let v579 : US3 = US3_TriA
                let v580 : UH4 = UH4_RegexChar(v579)
                let v581 : US3 = US3_TriB
                let v582 : UH4 = UH4_RegexChar(v581)
                let v583 : UH4 = UH4_RegexAlt(v580, v582)
                let v584 : UH4 = UH4_RegexStar(v583)
                let v585 : US3 = US3_TriC
                let v586 : UH4 = UH4_RegexChar(v585)
                let v587 : UH4 = UH4_RegexCat(v584, v586)
                let v588 : US3 = US3_TriA
                let v589 : US3 = US3_TriB
                let v590 : US3 = US3_TriC
                let v591 : UH6 = UH6_SymbolListNil
                let v592 : UH6 = UH6_SymbolListCons(v590, v591)
                let v593 : UH6 = UH6_SymbolListCons(v589, v592)
                let v594 : UH6 = UH6_SymbolListCons(v588, v593)
                let v595 : bool = antimirov_support_closed_51(v587, v520, v594)
                if v595 then
                    let v596 : US3 = US3_TriA
                    let v597 : UH4 = UH4_RegexChar(v596)
                    let v598 : US3 = US3_TriB
                    let v599 : UH4 = UH4_RegexChar(v598)
                    let v600 : UH4 = UH4_RegexAlt(v597, v599)
                    let v601 : UH4 = UH4_RegexStar(v600)
                    let v602 : US3 = US3_TriC
                    let v603 : UH4 = UH4_RegexChar(v602)
                    let v604 : UH4 = UH4_RegexCat(v601, v603)
                    let v605 : US3 = US3_TriA
                    let v606 : US3 = US3_TriB
                    let v607 : US3 = US3_TriC
                    let v608 : UH6 = UH6_SymbolListNil
                    let v609 : UH6 = UH6_SymbolListCons(v607, v608)
                    let v610 : UH6 = UH6_SymbolListCons(v606, v609)
                    let v611 : UH6 = UH6_SymbolListCons(v605, v610)
                    antimirov_reconstruction_symbols_53(v604, v611)
                else
                    false
            else
                false
        else
            false
    else
        false
if v616 then
    ()
else
    failwith<unit> "higher-ranked Antimirov programs must execute alphabet-indexed certificates without erasing their family"
let v617 : US0 = US0_BitZero
let v618 : UH0 = UH0_RegexChar(v617)
let v619 : UH0 = UH0_RegexStar(v618)
let v620 : UH0 = normalize_0(v619)
let v621 : US0 = US0_BitZero
let v622 : UH0 = canonical_derivative_27(v620, v621)
let v623 : US0 = US0_BitZero
let v624 : UH0 = reference_derivative_69(v620, v623)
let v625 : UH0 = normalize_0(v624)
let v626 : US0 = US0_BitZero
let v627 : UH1 = antimirov_partial_derivative_21(v620, v626)
let v628 : UH0 = antimirov_state_regex_26(v627)
let v629 : UH0 = normalize_0(v628)
let v630 : US0 = US0_BitZero
let v631 : UH7 = UH7_InputEmpty
let v632 : UH7 = UH7_InputCons(v630, v631)
let v633 : US0 = US0_BitZero
let v634 : US0 = US0_BitOne
let v635 : UH3 = UH3_SymbolListNil
let v636 : UH3 = UH3_SymbolListCons(v634, v635)
let v637 : UH3 = UH3_SymbolListCons(v633, v636)
let v638 : bool = input_symbols_covered_70(v632, v637)
let v662 : bool =
    if v638 then
        let v639 : UH0 = normalize_0(v620)
        let v640 : UH1 = antimirov_position_origins_12(v639)
        let v641 : UH0 = normalize_0(v620)
        let v642 : UH1 = antimirov_residual_support_7(v641)
        let v643 : UH0 = normalize_0(v641)
        let v644 : UH1 = antimirov_residual_support_7(v643)
        let v645 : UH1 = antimirov_insert_unique_9(v643, v644)
        let v646 : bool = regex_list_distinct_15(v645)
        let v648 : bool =
            if v646 then
                antimirov_subset_16(v642, v640)
            else
                false
        let v650 : bool =
            if v648 then
                antimirov_subset_16(v640, v642)
            else
                false
        let v653 : bool =
            if v650 then
                let v651 : UH1 = UH1_RegexListCons(v641, v640)
                antimirov_subset_16(v645, v651)
            else
                false
        let v656 : bool =
            if v653 then
                let v654 : UH2 = regex_position_count_17(v641)
                regex_list_exact_budget_19(v640, v654)
            else
                false
        if v656 then
            let v657 : UH1 = UH1_RegexListCons(v641, v640)
            let v658 : UH2 = regex_position_count_17(v641)
            let v659 : UH2 = UH2_StateBudgetSucc(v658)
            regex_list_exact_budget_19(v657, v659)
        else
            false
    else
        false
let v668 : bool =
    if v662 then
        let v663 : UH0 = normalize_0(v620)
        let v664 : US0 = US0_BitZero
        let v665 : UH1 = antimirov_partial_derivative_21(v663, v664)
        let v666 : UH1 = antimirov_position_origins_12(v663)
        antimirov_subset_16(v665, v666)
    else
        false
let v670 : bool =
    if v668 then
        regex_equal_5(v622, v625)
    else
        false
let v672 : bool =
    if v670 then
        regex_equal_5(v622, v629)
    else
        false
let v677 : US4 =
    if v672 then
        let v673 : US0 = US0_BitZero
        let v674 : US5 = US5_DerivativeVerified(v620, v673, v622)
        US4_DerivativePipelineVerified(v674)
    else
        US4_DerivativePipelineRejected
let v680 : bool =
    match v677 with
    | US4_DerivativePipelineRejected -> (* DerivativePipelineRejected *)
        false
    | US4_DerivativePipelineVerified(v678) -> (* DerivativePipelineVerified *)
        true
let v747 : bool =
    if v680 then
        let v681 : US3 = US3_TriA
        let v682 : UH4 = UH4_RegexChar(v681)
        let v683 : UH4 = UH4_RegexStar(v682)
        let v684 : UH4 = normalize_29(v683)
        let v685 : US3 = US3_TriA
        let v686 : UH4 = canonical_derivative_55(v684, v685)
        let v687 : US3 = US3_TriA
        let v688 : UH4 = reference_derivative_72(v684, v687)
        let v689 : UH4 = normalize_29(v688)
        let v690 : US3 = US3_TriA
        let v691 : UH5 = antimirov_partial_derivative_49(v684, v690)
        let v692 : UH4 = antimirov_state_regex_54(v691)
        let v693 : UH4 = normalize_29(v692)
        let v694 : US3 = US3_TriA
        let v695 : UH8 = UH8_InputEmpty
        let v696 : UH8 = UH8_InputCons(v694, v695)
        let v697 : US3 = US3_TriA
        let v698 : US3 = US3_TriB
        let v699 : US3 = US3_TriC
        let v700 : UH6 = UH6_SymbolListNil
        let v701 : UH6 = UH6_SymbolListCons(v699, v700)
        let v702 : UH6 = UH6_SymbolListCons(v698, v701)
        let v703 : UH6 = UH6_SymbolListCons(v697, v702)
        let v704 : bool = input_symbols_covered_73(v696, v703)
        let v728 : bool =
            if v704 then
                let v705 : UH4 = normalize_29(v684)
                let v706 : UH5 = antimirov_position_origins_41(v705)
                let v707 : UH4 = normalize_29(v684)
                let v708 : UH5 = antimirov_residual_support_36(v707)
                let v709 : UH4 = normalize_29(v707)
                let v710 : UH5 = antimirov_residual_support_36(v709)
                let v711 : UH5 = antimirov_insert_unique_38(v709, v710)
                let v712 : bool = regex_list_distinct_44(v711)
                let v714 : bool =
                    if v712 then
                        antimirov_subset_45(v708, v706)
                    else
                        false
                let v716 : bool =
                    if v714 then
                        antimirov_subset_45(v706, v708)
                    else
                        false
                let v719 : bool =
                    if v716 then
                        let v717 : UH5 = UH5_RegexListCons(v707, v706)
                        antimirov_subset_45(v711, v717)
                    else
                        false
                let v722 : bool =
                    if v719 then
                        let v720 : UH2 = regex_position_count_46(v707)
                        regex_list_exact_budget_47(v706, v720)
                    else
                        false
                if v722 then
                    let v723 : UH5 = UH5_RegexListCons(v707, v706)
                    let v724 : UH2 = regex_position_count_46(v707)
                    let v725 : UH2 = UH2_StateBudgetSucc(v724)
                    regex_list_exact_budget_47(v723, v725)
                else
                    false
            else
                false
        let v734 : bool =
            if v728 then
                let v729 : UH4 = normalize_29(v684)
                let v730 : US3 = US3_TriA
                let v731 : UH5 = antimirov_partial_derivative_49(v729, v730)
                let v732 : UH5 = antimirov_position_origins_41(v729)
                antimirov_subset_45(v731, v732)
            else
                false
        let v736 : bool =
            if v734 then
                regex_equal_34(v686, v689)
            else
                false
        let v738 : bool =
            if v736 then
                regex_equal_34(v686, v693)
            else
                false
        let v743 : US6 =
            if v738 then
                let v739 : US3 = US3_TriA
                let v740 : US7 = US7_DerivativeVerified(v684, v739, v686)
                US6_DerivativePipelineVerified(v740)
            else
                US6_DerivativePipelineRejected
        let v746 : bool =
            match v743 with
            | US6_DerivativePipelineRejected -> (* DerivativePipelineRejected *)
                false
            | US6_DerivativePipelineVerified(v744) -> (* DerivativePipelineVerified *)
                true
        v746
    else
        false
if v747 then
    ()
else
    failwith<unit> "higher-ranked derivative programs must enforce normalize-then-verify before sealing across alphabets"
let v748 : US0 = US0_BitZero
let v749 : UH0 = UH0_RegexChar(v748)
let v750 : UH0 = UH0_RegexStar(v749)
let v751 : UH0 = normalize_0(v750)
let v752 : string = "brzozowski-antimirov-certificate-green"
v752
