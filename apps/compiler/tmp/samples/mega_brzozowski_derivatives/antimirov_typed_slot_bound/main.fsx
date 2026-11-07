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
    | UH2_PositionTreeChar of US0
and UH3 =
    | UH3_PositionTreeAlt of UH2 * UH2
and UH4 =
    | UH4_PositionTreeStar of UH3
and UH5 =
    | UH5_PositionTreeCat of UH4 * UH2
and UH6 =
    | UH6_StateBudgetZero
    | UH6_StateBudgetSucc of UH6
and UH10 =
    | UH10_OriginSlotChar
and UH9 =
    | UH9_OriginSlotAltLeft of UH10
    | UH9_OriginSlotAltRight of UH10
and UH8 =
    | UH8_OriginSlotStar of UH9
and UH7 =
    | UH7_OriginSlotCatLeft of UH8
    | UH7_OriginSlotCatRight of UH10
and [<Struct>] US3 =
    | US3_SupportSlotRoot
    | US3_SupportSlotOrigin of f1_0 : UH7
and [<Struct>] US2 =
    | US2_SupportSlotMissing
    | US2_SupportSlotFound of f1_0 : US3
and [<Struct>] US4 =
    | US4_OriginSlotMissing
    | US4_OriginSlotFound of f1_0 : UH7
and [<Struct>] US5 =
    | US5_OriginSlotMissing
    | US5_OriginSlotFound of f1_0 : UH8
and [<Struct>] US6 =
    | US6_OriginSlotMissing
    | US6_OriginSlotFound of f1_0 : UH9
and [<Struct>] US7 =
    | US7_OriginSlotMissing
    | US7_OriginSlotFound of f1_0 : UH10
and [<Struct>] US8 =
    | US8_TriA
    | US8_TriB
    | US8_TriC
and UH11 =
    | UH11_RegexEmpty
    | UH11_RegexEpsilon
    | UH11_RegexChar of US8
    | UH11_RegexAlt of UH11 * UH11
    | UH11_RegexCat of UH11 * UH11
    | UH11_RegexStar of UH11
and UH12 =
    | UH12_RegexListNil
    | UH12_RegexListCons of UH11 * UH12
and UH13 =
    | UH13_PositionTreeChar of US8
and UH14 =
    | UH14_PositionTreeStar of UH13
and UH15 =
    | UH15_OriginSlotStar of UH10
and [<Struct>] US10 =
    | US10_SupportSlotRoot
    | US10_SupportSlotOrigin of f1_0 : UH15
and [<Struct>] US9 =
    | US9_SupportSlotMissing
    | US9_SupportSlotFound of f1_0 : US10
and [<Struct>] US11 =
    | US11_OriginSlotMissing
    | US11_OriginSlotFound of f1_0 : UH15
and UH16 =
    | UH16_PositionTreeAlt of UH13 * UH13
and UH17 =
    | UH17_PositionTreeStar of UH16
and UH18 =
    | UH18_PositionTreeCat of UH17 * UH13
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
and regex_list_distinct_12 (v0 : UH1) : bool =
    match v0 with
    | UH1_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : bool = regex_list_contains_10(v1, v2)
        if v3 then
            false
        else
            regex_list_distinct_12(v2)
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and antimirov_position_tree_budget_16 (v0 : UH2) : UH6 =
    match v0 with
    | UH2_PositionTreeChar(v1) -> (* PositionTreeChar *)
        let v2 : UH6 = UH6_StateBudgetZero
        UH6_StateBudgetSucc(v2)
and state_budget_add_17 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_StateBudgetSucc(v2) -> (* StateBudgetSucc *)
        let v3 : UH6 = state_budget_add_17(v2, v1)
        UH6_StateBudgetSucc(v3)
    | UH6_StateBudgetZero -> (* StateBudgetZero *)
        v1
and antimirov_position_tree_budget_15 (v0 : UH3) : UH6 =
    match v0 with
    | UH3_PositionTreeAlt(v1, v2) -> (* PositionTreeAlt *)
        let v3 : UH6 = antimirov_position_tree_budget_16(v1)
        let v4 : UH6 = antimirov_position_tree_budget_16(v2)
        state_budget_add_17(v3, v4)
and antimirov_position_tree_budget_14 (v0 : UH4) : UH6 =
    match v0 with
    | UH4_PositionTreeStar(v1) -> (* PositionTreeStar *)
        antimirov_position_tree_budget_15(v1)
and antimirov_position_tree_budget_13 (v0 : UH5) : UH6 =
    match v0 with
    | UH5_PositionTreeCat(v1, v2) -> (* PositionTreeCat *)
        let v3 : UH6 = antimirov_position_tree_budget_14(v1)
        let v4 : UH6 = antimirov_position_tree_budget_16(v2)
        state_budget_add_17(v3, v4)
and regex_position_count_18 (v0 : UH0) : UH6 =
    match v0 with
    | UH0_RegexAlt(v6, v7) -> (* RegexAlt *)
        let v8 : UH6 = regex_position_count_18(v6)
        let v9 : UH6 = regex_position_count_18(v7)
        state_budget_add_17(v8, v9)
    | UH0_RegexCat(v11, v12) -> (* RegexCat *)
        let v13 : UH6 = regex_position_count_18(v11)
        let v14 : UH6 = regex_position_count_18(v12)
        state_budget_add_17(v13, v14)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_StateBudgetZero
        UH6_StateBudgetSucc(v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH6_StateBudgetZero
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH6_StateBudgetZero
    | UH0_RegexStar(v16) -> (* RegexStar *)
        regex_position_count_18(v16)
and state_budget_same_19 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_StateBudgetSucc(v3) -> (* StateBudgetSucc *)
        match v1 with
        | UH6_StateBudgetSucc(v4) -> (* StateBudgetSucc *)
            state_budget_same_19(v3, v4)
        | _ ->
            false
    | UH6_StateBudgetZero -> (* StateBudgetZero *)
        match v1 with
        | UH6_StateBudgetZero -> (* StateBudgetZero *)
            true
        | _ ->
            false
and closure1 (v0 : UH0) (v1 : UH0) : UH0 =
    let v2 : UH0 = make_cat_4(v0, v1)
    normalize_0(v2)
and closure0 () (v0 : UH0) : (UH0 -> UH0) =
    closure1(v0)
and closure3 (v0 : UH0) (v1 : UH0) : bool =
    regex_equal_5(v0, v1)
and closure2 () (v0 : UH0) : (UH0 -> bool) =
    closure3(v0)
and antimirov_support_covered_by_typed_slots_20 (v0 : (UH0 -> (UH0 -> UH0)), v1 : (UH0 -> (UH0 -> bool)), v2 : UH0, v3 : UH5, v4 : UH1) : bool =
    match v4 with
    | UH1_RegexListCons(v5, v6) -> (* RegexListCons *)
        let v7 : (UH0 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v106 : US2 =
            if v8 then
                let v9 : US3 = US3_SupportSlotRoot
                US2_SupportSlotFound(v9)
            else
                let v99 : US4 =
                    match v3 with
                    | UH5_PositionTreeCat(v11, v12) -> (* PositionTreeCat *)
                        let v15 : UH0 =
                            match v12 with
                            | UH2_PositionTreeChar(v13) -> (* PositionTreeChar *)
                                UH0_RegexChar(v13)
                        let v16 : (UH0 -> UH0) = v0 v15
                        let v17 : UH0 = UH0_RegexEpsilon
                        let v18 : UH0 = v16 v17
                        let v75 : US5 =
                            match v11 with
                            | UH4_PositionTreeStar(v19) -> (* PositionTreeStar *)
                                let v29 : UH0 =
                                    match v19 with
                                    | UH3_PositionTreeAlt(v20, v21) -> (* PositionTreeAlt *)
                                        let v24 : UH0 =
                                            match v20 with
                                            | UH2_PositionTreeChar(v22) -> (* PositionTreeChar *)
                                                UH0_RegexChar(v22)
                                        let v27 : UH0 =
                                            match v21 with
                                            | UH2_PositionTreeChar(v25) -> (* PositionTreeChar *)
                                                UH0_RegexChar(v25)
                                        UH0_RegexAlt(v24, v27)
                                let v30 : UH0 = UH0_RegexStar(v29)
                                let v31 : (UH0 -> UH0) = v0 v30
                                let v32 : UH0 = v31 v18
                                let v68 : US6 =
                                    match v19 with
                                    | UH3_PositionTreeAlt(v33, v34) -> (* PositionTreeAlt *)
                                        let v45 : US7 =
                                            match v33 with
                                            | UH2_PositionTreeChar(v35) -> (* PositionTreeChar *)
                                                let v36 : UH0 = UH0_RegexEpsilon
                                                let v37 : (UH0 -> UH0) = v0 v36
                                                let v38 : UH0 = v37 v32
                                                let v39 : (UH0 -> bool) = v1 v5
                                                let v40 : bool = v39 v38
                                                if v40 then
                                                    let v41 : UH10 = UH10_OriginSlotChar
                                                    US7_OriginSlotFound(v41)
                                                else
                                                    US7_OriginSlotMissing
                                        match v45 with
                                        | US7_OriginSlotFound(v46) -> (* OriginSlotFound *)
                                            let v47 : UH9 = UH9_OriginSlotAltLeft(v46)
                                            US6_OriginSlotFound(v47)
                                        | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                                            let v59 : US7 =
                                                match v34 with
                                                | UH2_PositionTreeChar(v49) -> (* PositionTreeChar *)
                                                    let v50 : UH0 = UH0_RegexEpsilon
                                                    let v51 : (UH0 -> UH0) = v0 v50
                                                    let v52 : UH0 = v51 v32
                                                    let v53 : (UH0 -> bool) = v1 v5
                                                    let v54 : bool = v53 v52
                                                    if v54 then
                                                        let v55 : UH10 = UH10_OriginSlotChar
                                                        US7_OriginSlotFound(v55)
                                                    else
                                                        US7_OriginSlotMissing
                                            match v59 with
                                            | US7_OriginSlotFound(v60) -> (* OriginSlotFound *)
                                                let v61 : UH9 = UH9_OriginSlotAltRight(v60)
                                                US6_OriginSlotFound(v61)
                                            | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                                                US6_OriginSlotMissing
                                match v68 with
                                | US6_OriginSlotFound(v69) -> (* OriginSlotFound *)
                                    let v70 : UH8 = UH8_OriginSlotStar(v69)
                                    US5_OriginSlotFound(v70)
                                | US6_OriginSlotMissing -> (* OriginSlotMissing *)
                                    US5_OriginSlotMissing
                        match v75 with
                        | US5_OriginSlotFound(v76) -> (* OriginSlotFound *)
                            let v77 : UH7 = UH7_OriginSlotCatLeft(v76)
                            US4_OriginSlotFound(v77)
                        | US5_OriginSlotMissing -> (* OriginSlotMissing *)
                            let v90 : US7 =
                                match v12 with
                                | UH2_PositionTreeChar(v79) -> (* PositionTreeChar *)
                                    let v80 : UH0 = UH0_RegexEpsilon
                                    let v81 : (UH0 -> UH0) = v0 v80
                                    let v82 : UH0 = UH0_RegexEpsilon
                                    let v83 : UH0 = v81 v82
                                    let v84 : (UH0 -> bool) = v1 v5
                                    let v85 : bool = v84 v83
                                    if v85 then
                                        let v86 : UH10 = UH10_OriginSlotChar
                                        US7_OriginSlotFound(v86)
                                    else
                                        US7_OriginSlotMissing
                            match v90 with
                            | US7_OriginSlotFound(v91) -> (* OriginSlotFound *)
                                let v92 : UH7 = UH7_OriginSlotCatRight(v91)
                                US4_OriginSlotFound(v92)
                            | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                                US4_OriginSlotMissing
                match v99 with
                | US4_OriginSlotFound(v100) -> (* OriginSlotFound *)
                    let v101 : US3 = US3_SupportSlotOrigin(v100)
                    US2_SupportSlotFound(v101)
                | US4_OriginSlotMissing -> (* OriginSlotMissing *)
                    US2_SupportSlotMissing
        match v106 with
        | US2_SupportSlotFound(v107) -> (* SupportSlotFound *)
            let v108 : (UH0 -> bool) = v1 v5
            let v167 : UH0 =
                match v107 with
                | US3_SupportSlotOrigin(v109) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH5_PositionTreeCat(v110, v111) -> (* PositionTreeCat *)
                        match v109 with
                        | UH7_OriginSlotCatLeft(v112) -> (* OriginSlotCatLeft *)
                            let v115 : UH0 =
                                match v111 with
                                | UH2_PositionTreeChar(v113) -> (* PositionTreeChar *)
                                    UH0_RegexChar(v113)
                            let v116 : (UH0 -> UH0) = v0 v115
                            let v117 : UH0 = UH0_RegexEpsilon
                            let v118 : UH0 = v116 v117
                            match v110 with
                            | UH4_PositionTreeStar(v119) -> (* PositionTreeStar *)
                                match v112 with
                                | UH8_OriginSlotStar(v120) -> (* OriginSlotStar *)
                                    let v130 : UH0 =
                                        match v119 with
                                        | UH3_PositionTreeAlt(v121, v122) -> (* PositionTreeAlt *)
                                            let v125 : UH0 =
                                                match v121 with
                                                | UH2_PositionTreeChar(v123) -> (* PositionTreeChar *)
                                                    UH0_RegexChar(v123)
                                            let v128 : UH0 =
                                                match v122 with
                                                | UH2_PositionTreeChar(v126) -> (* PositionTreeChar *)
                                                    UH0_RegexChar(v126)
                                            UH0_RegexAlt(v125, v128)
                                    let v131 : UH0 = UH0_RegexStar(v130)
                                    let v132 : (UH0 -> UH0) = v0 v131
                                    let v133 : UH0 = v132 v118
                                    match v119 with
                                    | UH3_PositionTreeAlt(v134, v135) -> (* PositionTreeAlt *)
                                        match v120 with
                                        | UH9_OriginSlotAltLeft(v136) -> (* OriginSlotAltLeft *)
                                            match v134 with
                                            | UH2_PositionTreeChar(v137) -> (* PositionTreeChar *)
                                                match v136 with
                                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                                    let v138 : UH0 = UH0_RegexEpsilon
                                                    let v139 : (UH0 -> UH0) = v0 v138
                                                    v139 v133
                                        | UH9_OriginSlotAltRight(v143) -> (* OriginSlotAltRight *)
                                            match v135 with
                                            | UH2_PositionTreeChar(v144) -> (* PositionTreeChar *)
                                                match v143 with
                                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                                    let v145 : UH0 = UH0_RegexEpsilon
                                                    let v146 : (UH0 -> UH0) = v0 v145
                                                    v146 v133
                        | UH7_OriginSlotCatRight(v155) -> (* OriginSlotCatRight *)
                            match v111 with
                            | UH2_PositionTreeChar(v156) -> (* PositionTreeChar *)
                                match v155 with
                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                    let v157 : UH0 = UH0_RegexEpsilon
                                    let v158 : (UH0 -> UH0) = v0 v157
                                    let v159 : UH0 = UH0_RegexEpsilon
                                    v158 v159
                | US3_SupportSlotRoot -> (* SupportSlotRoot *)
                    v2
            let v168 : bool = v108 v167
            if v168 then
                antimirov_support_covered_by_typed_slots_20(v0, v1, v2, v3, v6)
            else
                false
        | US2_SupportSlotMissing -> (* SupportSlotMissing *)
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and regex_compare_24 (v0 : UH11, v1 : UH11) : US1 =
    match v0 with
    | UH11_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH11_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = regex_compare_24(v59, v61)
            match v63 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_24(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_SymbolGreater
    | UH11_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH11_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US1 = regex_compare_24(v34, v40)
            match v42 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_24(v35, v41)
            | _ ->
                v42
        | UH11_RegexChar(v38) -> (* RegexChar *)
            US1_SymbolGreater
        | UH11_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH11_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH11_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH11_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US8_TriA -> (* TriA *)
                match v13 with
                | US8_TriA -> (* TriA *)
                    US1_SymbolSame
                | _ ->
                    US1_SymbolLess
            | _ ->
                match v13 with
                | US8_TriA -> (* TriA *)
                    US1_SymbolGreater
                | _ ->
                    match v10 with
                    | US8_TriB -> (* TriB *)
                        match v13 with
                        | US8_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US8_TriC -> (* TriC *)
                            US1_SymbolLess
                    | US8_TriC -> (* TriC *)
                        match v13 with
                        | US8_TriB -> (* TriB *)
                            US1_SymbolGreater
                        | US8_TriC -> (* TriC *)
                            US1_SymbolSame
        | UH11_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH11_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH11_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH11_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH11_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH11_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH11_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH11_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH11_RegexAlt(v51, v52) -> (* RegexAlt *)
            US1_SymbolLess
        | UH11_RegexStar(v54) -> (* RegexStar *)
            regex_compare_24(v50, v54)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_23 (v0 : UH11, v1 : UH11) : UH11 =
    match v1 with
    | UH11_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_24(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH11 = alt_insert_sorted_23(v0, v3)
            UH11_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH11_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH11_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_24(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH11_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH11_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_22 (v0 : UH11, v1 : UH11) : UH11 =
    match v0 with
    | UH11_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH11 = alt_insert_sorted_23(v2, v1)
        make_alt_22(v3, v4)
    | UH11_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_23(v0, v1)
and regex_equal_26 (v0 : UH11, v1 : UH11) : bool =
    match v0 with
    | UH11_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH11_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_26(v24, v26)
            if v28 then
                regex_equal_26(v25, v27)
            else
                false
        | _ ->
            false
    | UH11_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH11_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_26(v32, v34)
            if v36 then
                regex_equal_26(v33, v35)
            else
                false
        | _ ->
            false
    | UH11_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH11_RegexChar(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US8_TriA -> (* TriA *)
                    match v5 with
                    | US8_TriA -> (* TriA *)
                        US1_SymbolSame
                    | _ ->
                        US1_SymbolLess
                | _ ->
                    match v5 with
                    | US8_TriA -> (* TriA *)
                        US1_SymbolGreater
                    | _ ->
                        match v4 with
                        | US8_TriB -> (* TriB *)
                            match v5 with
                            | US8_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US8_TriC -> (* TriC *)
                                US1_SymbolLess
                        | US8_TriC -> (* TriC *)
                            match v5 with
                            | US8_TriB -> (* TriB *)
                                US1_SymbolGreater
                            | US8_TriC -> (* TriC *)
                                US1_SymbolSame
            match v21 with
            | US1_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH11_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH11_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH11_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH11_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH11_RegexStar(v40) -> (* RegexStar *)
        match v1 with
        | UH11_RegexStar(v41) -> (* RegexStar *)
            regex_equal_26(v40, v41)
        | _ ->
            false
and make_cat_25 (v0 : UH11, v1 : UH11) : UH11 =
    match v0 with
    | UH11_RegexEmpty -> (* RegexEmpty *)
        UH11_RegexEmpty
    | _ ->
        match v1 with
        | UH11_RegexEmpty -> (* RegexEmpty *)
            UH11_RegexEmpty
        | _ ->
            match v0 with
            | UH11_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH11_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH11_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH11 = make_cat_25(v13, v1)
                        UH11_RegexCat(v12, v14)
                    | UH11_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH11_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_26(v4, v5)
                            if v6 then
                                UH11_RegexStar(v4)
                            else
                                UH11_RegexCat(v0, v1)
                        | _ ->
                            UH11_RegexCat(v0, v1)
                    | _ ->
                        UH11_RegexCat(v0, v1)
and make_star_27 (v0 : UH11) : UH11 =
    match v0 with
    | UH11_RegexEmpty -> (* RegexEmpty *)
        UH11_RegexEpsilon
    | UH11_RegexEpsilon -> (* RegexEpsilon *)
        UH11_RegexEpsilon
    | UH11_RegexStar(v3) -> (* RegexStar *)
        UH11_RegexStar(v3)
    | _ ->
        UH11_RegexStar(v0)
and normalize_21 (v0 : UH11) : UH11 =
    match v0 with
    | UH11_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH11 = normalize_21(v5)
        let v8 : UH11 = normalize_21(v6)
        make_alt_22(v7, v8)
    | UH11_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH11 = normalize_21(v10)
        let v13 : UH11 = normalize_21(v11)
        make_cat_25(v12, v13)
    | UH11_RegexChar(v3) -> (* RegexChar *)
        UH11_RegexChar(v3)
    | UH11_RegexEmpty -> (* RegexEmpty *)
        UH11_RegexEmpty
    | UH11_RegexEpsilon -> (* RegexEpsilon *)
        UH11_RegexEpsilon
    | UH11_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH11 = normalize_21(v15)
        make_star_27(v16)
and regex_list_contains_31 (v0 : UH11, v1 : UH12) : bool =
    match v1 with
    | UH12_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_26(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_31(v0, v3)
    | UH12_RegexListNil -> (* RegexListNil *)
        false
and antimirov_insert_unique_30 (v0 : UH11, v1 : UH12) : UH12 =
    let v2 : UH11 = normalize_21(v0)
    let v3 : bool = regex_list_contains_31(v2, v1)
    if v3 then
        v1
    else
        UH12_RegexListCons(v2, v1)
and antimirov_union_29 (v0 : UH12, v1 : UH12) : UH12 =
    match v0 with
    | UH12_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH12 = antimirov_insert_unique_30(v2, v1)
        antimirov_union_29(v3, v4)
    | UH12_RegexListNil -> (* RegexListNil *)
        v1
and antimirov_map_cat_right_32 (v0 : UH12, v1 : UH11) : UH12 =
    match v0 with
    | UH12_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH11 = make_cat_25(v3, v1)
        let v6 : UH12 = antimirov_map_cat_right_32(v4, v1)
        antimirov_insert_unique_30(v5, v6)
    | UH12_RegexListNil -> (* RegexListNil *)
        UH12_RegexListNil
and antimirov_residual_support_28 (v0 : UH11) : UH12 =
    match v0 with
    | UH11_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH12 = antimirov_residual_support_28(v7)
        let v10 : UH12 = antimirov_residual_support_28(v8)
        antimirov_union_29(v9, v10)
    | UH11_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : UH12 = antimirov_residual_support_28(v12)
        let v15 : UH12 = antimirov_map_cat_right_32(v14, v13)
        let v16 : UH12 = antimirov_residual_support_28(v13)
        antimirov_union_29(v15, v16)
    | UH11_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH11 = UH11_RegexEpsilon
        let v5 : UH12 = UH12_RegexListNil
        UH12_RegexListCons(v4, v5)
    | UH11_RegexEmpty -> (* RegexEmpty *)
        UH12_RegexListNil
    | UH11_RegexEpsilon -> (* RegexEpsilon *)
        UH12_RegexListNil
    | UH11_RegexStar(v18) -> (* RegexStar *)
        let v19 : UH12 = antimirov_residual_support_28(v18)
        let v20 : UH11 = UH11_RegexStar(v18)
        antimirov_map_cat_right_32(v19, v20)
and regex_list_distinct_33 (v0 : UH12) : bool =
    match v0 with
    | UH12_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : bool = regex_list_contains_31(v1, v2)
        if v3 then
            false
        else
            regex_list_distinct_33(v2)
    | UH12_RegexListNil -> (* RegexListNil *)
        true
and antimirov_position_tree_budget_35 (v0 : UH13) : UH6 =
    match v0 with
    | UH13_PositionTreeChar(v1) -> (* PositionTreeChar *)
        let v2 : UH6 = UH6_StateBudgetZero
        UH6_StateBudgetSucc(v2)
and antimirov_position_tree_budget_34 (v0 : UH14) : UH6 =
    match v0 with
    | UH14_PositionTreeStar(v1) -> (* PositionTreeStar *)
        antimirov_position_tree_budget_35(v1)
and regex_position_count_36 (v0 : UH11) : UH6 =
    match v0 with
    | UH11_RegexAlt(v6, v7) -> (* RegexAlt *)
        let v8 : UH6 = regex_position_count_36(v6)
        let v9 : UH6 = regex_position_count_36(v7)
        state_budget_add_17(v8, v9)
    | UH11_RegexCat(v11, v12) -> (* RegexCat *)
        let v13 : UH6 = regex_position_count_36(v11)
        let v14 : UH6 = regex_position_count_36(v12)
        state_budget_add_17(v13, v14)
    | UH11_RegexChar(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_StateBudgetZero
        UH6_StateBudgetSucc(v4)
    | UH11_RegexEmpty -> (* RegexEmpty *)
        UH6_StateBudgetZero
    | UH11_RegexEpsilon -> (* RegexEpsilon *)
        UH6_StateBudgetZero
    | UH11_RegexStar(v16) -> (* RegexStar *)
        regex_position_count_36(v16)
and closure5 (v0 : UH11) (v1 : UH11) : UH11 =
    let v2 : UH11 = make_cat_25(v0, v1)
    normalize_21(v2)
and closure4 () (v0 : UH11) : (UH11 -> UH11) =
    closure5(v0)
and closure7 (v0 : UH11) (v1 : UH11) : bool =
    regex_equal_26(v0, v1)
and closure6 () (v0 : UH11) : (UH11 -> bool) =
    closure7(v0)
and antimirov_support_covered_by_typed_slots_37 (v0 : (UH11 -> (UH11 -> UH11)), v1 : (UH11 -> (UH11 -> bool)), v2 : UH11, v3 : UH14, v4 : UH12) : bool =
    match v4 with
    | UH12_RegexListCons(v5, v6) -> (* RegexListCons *)
        let v7 : (UH11 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v43 : US9 =
            if v8 then
                let v9 : US10 = US10_SupportSlotRoot
                US9_SupportSlotFound(v9)
            else
                let v36 : US11 =
                    match v3 with
                    | UH14_PositionTreeStar(v11) -> (* PositionTreeStar *)
                        let v14 : UH11 =
                            match v11 with
                            | UH13_PositionTreeChar(v12) -> (* PositionTreeChar *)
                                UH11_RegexChar(v12)
                        let v15 : UH11 = UH11_RegexStar(v14)
                        let v16 : (UH11 -> UH11) = v0 v15
                        let v17 : UH11 = UH11_RegexEpsilon
                        let v18 : UH11 = v16 v17
                        let v29 : US7 =
                            match v11 with
                            | UH13_PositionTreeChar(v19) -> (* PositionTreeChar *)
                                let v20 : UH11 = UH11_RegexEpsilon
                                let v21 : (UH11 -> UH11) = v0 v20
                                let v22 : UH11 = v21 v18
                                let v23 : (UH11 -> bool) = v1 v5
                                let v24 : bool = v23 v22
                                if v24 then
                                    let v25 : UH10 = UH10_OriginSlotChar
                                    US7_OriginSlotFound(v25)
                                else
                                    US7_OriginSlotMissing
                        match v29 with
                        | US7_OriginSlotFound(v30) -> (* OriginSlotFound *)
                            let v31 : UH15 = UH15_OriginSlotStar(v30)
                            US11_OriginSlotFound(v31)
                        | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                            US11_OriginSlotMissing
                match v36 with
                | US11_OriginSlotFound(v37) -> (* OriginSlotFound *)
                    let v38 : US10 = US10_SupportSlotOrigin(v37)
                    US9_SupportSlotFound(v38)
                | US11_OriginSlotMissing -> (* OriginSlotMissing *)
                    US9_SupportSlotMissing
        match v43 with
        | US9_SupportSlotFound(v44) -> (* SupportSlotFound *)
            let v45 : (UH11 -> bool) = v1 v5
            let v65 : UH11 =
                match v44 with
                | US10_SupportSlotOrigin(v46) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH14_PositionTreeStar(v47) -> (* PositionTreeStar *)
                        match v46 with
                        | UH15_OriginSlotStar(v48) -> (* OriginSlotStar *)
                            let v51 : UH11 =
                                match v47 with
                                | UH13_PositionTreeChar(v49) -> (* PositionTreeChar *)
                                    UH11_RegexChar(v49)
                            let v52 : UH11 = UH11_RegexStar(v51)
                            let v53 : (UH11 -> UH11) = v0 v52
                            let v54 : UH11 = UH11_RegexEpsilon
                            let v55 : UH11 = v53 v54
                            match v47 with
                            | UH13_PositionTreeChar(v56) -> (* PositionTreeChar *)
                                match v48 with
                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                    let v57 : UH11 = UH11_RegexEpsilon
                                    let v58 : (UH11 -> UH11) = v0 v57
                                    v58 v55
                | US10_SupportSlotRoot -> (* SupportSlotRoot *)
                    v2
            let v66 : bool = v45 v65
            if v66 then
                antimirov_support_covered_by_typed_slots_37(v0, v1, v2, v3, v6)
            else
                false
        | US9_SupportSlotMissing -> (* SupportSlotMissing *)
            false
    | UH12_RegexListNil -> (* RegexListNil *)
        true
and antimirov_position_tree_budget_40 (v0 : UH16) : UH6 =
    match v0 with
    | UH16_PositionTreeAlt(v1, v2) -> (* PositionTreeAlt *)
        let v3 : UH6 = antimirov_position_tree_budget_35(v1)
        let v4 : UH6 = antimirov_position_tree_budget_35(v2)
        state_budget_add_17(v3, v4)
and antimirov_position_tree_budget_39 (v0 : UH17) : UH6 =
    match v0 with
    | UH17_PositionTreeStar(v1) -> (* PositionTreeStar *)
        antimirov_position_tree_budget_40(v1)
and antimirov_position_tree_budget_38 (v0 : UH18) : UH6 =
    match v0 with
    | UH18_PositionTreeCat(v1, v2) -> (* PositionTreeCat *)
        let v3 : UH6 = antimirov_position_tree_budget_39(v1)
        let v4 : UH6 = antimirov_position_tree_budget_35(v2)
        state_budget_add_17(v3, v4)
and antimirov_support_covered_by_typed_slots_41 (v0 : (UH11 -> (UH11 -> UH11)), v1 : (UH11 -> (UH11 -> bool)), v2 : UH11, v3 : UH18, v4 : UH12) : bool =
    match v4 with
    | UH12_RegexListCons(v5, v6) -> (* RegexListCons *)
        let v7 : (UH11 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v106 : US2 =
            if v8 then
                let v9 : US3 = US3_SupportSlotRoot
                US2_SupportSlotFound(v9)
            else
                let v99 : US4 =
                    match v3 with
                    | UH18_PositionTreeCat(v11, v12) -> (* PositionTreeCat *)
                        let v15 : UH11 =
                            match v12 with
                            | UH13_PositionTreeChar(v13) -> (* PositionTreeChar *)
                                UH11_RegexChar(v13)
                        let v16 : (UH11 -> UH11) = v0 v15
                        let v17 : UH11 = UH11_RegexEpsilon
                        let v18 : UH11 = v16 v17
                        let v75 : US5 =
                            match v11 with
                            | UH17_PositionTreeStar(v19) -> (* PositionTreeStar *)
                                let v29 : UH11 =
                                    match v19 with
                                    | UH16_PositionTreeAlt(v20, v21) -> (* PositionTreeAlt *)
                                        let v24 : UH11 =
                                            match v20 with
                                            | UH13_PositionTreeChar(v22) -> (* PositionTreeChar *)
                                                UH11_RegexChar(v22)
                                        let v27 : UH11 =
                                            match v21 with
                                            | UH13_PositionTreeChar(v25) -> (* PositionTreeChar *)
                                                UH11_RegexChar(v25)
                                        UH11_RegexAlt(v24, v27)
                                let v30 : UH11 = UH11_RegexStar(v29)
                                let v31 : (UH11 -> UH11) = v0 v30
                                let v32 : UH11 = v31 v18
                                let v68 : US6 =
                                    match v19 with
                                    | UH16_PositionTreeAlt(v33, v34) -> (* PositionTreeAlt *)
                                        let v45 : US7 =
                                            match v33 with
                                            | UH13_PositionTreeChar(v35) -> (* PositionTreeChar *)
                                                let v36 : UH11 = UH11_RegexEpsilon
                                                let v37 : (UH11 -> UH11) = v0 v36
                                                let v38 : UH11 = v37 v32
                                                let v39 : (UH11 -> bool) = v1 v5
                                                let v40 : bool = v39 v38
                                                if v40 then
                                                    let v41 : UH10 = UH10_OriginSlotChar
                                                    US7_OriginSlotFound(v41)
                                                else
                                                    US7_OriginSlotMissing
                                        match v45 with
                                        | US7_OriginSlotFound(v46) -> (* OriginSlotFound *)
                                            let v47 : UH9 = UH9_OriginSlotAltLeft(v46)
                                            US6_OriginSlotFound(v47)
                                        | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                                            let v59 : US7 =
                                                match v34 with
                                                | UH13_PositionTreeChar(v49) -> (* PositionTreeChar *)
                                                    let v50 : UH11 = UH11_RegexEpsilon
                                                    let v51 : (UH11 -> UH11) = v0 v50
                                                    let v52 : UH11 = v51 v32
                                                    let v53 : (UH11 -> bool) = v1 v5
                                                    let v54 : bool = v53 v52
                                                    if v54 then
                                                        let v55 : UH10 = UH10_OriginSlotChar
                                                        US7_OriginSlotFound(v55)
                                                    else
                                                        US7_OriginSlotMissing
                                            match v59 with
                                            | US7_OriginSlotFound(v60) -> (* OriginSlotFound *)
                                                let v61 : UH9 = UH9_OriginSlotAltRight(v60)
                                                US6_OriginSlotFound(v61)
                                            | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                                                US6_OriginSlotMissing
                                match v68 with
                                | US6_OriginSlotFound(v69) -> (* OriginSlotFound *)
                                    let v70 : UH8 = UH8_OriginSlotStar(v69)
                                    US5_OriginSlotFound(v70)
                                | US6_OriginSlotMissing -> (* OriginSlotMissing *)
                                    US5_OriginSlotMissing
                        match v75 with
                        | US5_OriginSlotFound(v76) -> (* OriginSlotFound *)
                            let v77 : UH7 = UH7_OriginSlotCatLeft(v76)
                            US4_OriginSlotFound(v77)
                        | US5_OriginSlotMissing -> (* OriginSlotMissing *)
                            let v90 : US7 =
                                match v12 with
                                | UH13_PositionTreeChar(v79) -> (* PositionTreeChar *)
                                    let v80 : UH11 = UH11_RegexEpsilon
                                    let v81 : (UH11 -> UH11) = v0 v80
                                    let v82 : UH11 = UH11_RegexEpsilon
                                    let v83 : UH11 = v81 v82
                                    let v84 : (UH11 -> bool) = v1 v5
                                    let v85 : bool = v84 v83
                                    if v85 then
                                        let v86 : UH10 = UH10_OriginSlotChar
                                        US7_OriginSlotFound(v86)
                                    else
                                        US7_OriginSlotMissing
                            match v90 with
                            | US7_OriginSlotFound(v91) -> (* OriginSlotFound *)
                                let v92 : UH7 = UH7_OriginSlotCatRight(v91)
                                US4_OriginSlotFound(v92)
                            | US7_OriginSlotMissing -> (* OriginSlotMissing *)
                                US4_OriginSlotMissing
                match v99 with
                | US4_OriginSlotFound(v100) -> (* OriginSlotFound *)
                    let v101 : US3 = US3_SupportSlotOrigin(v100)
                    US2_SupportSlotFound(v101)
                | US4_OriginSlotMissing -> (* OriginSlotMissing *)
                    US2_SupportSlotMissing
        match v106 with
        | US2_SupportSlotFound(v107) -> (* SupportSlotFound *)
            let v108 : (UH11 -> bool) = v1 v5
            let v167 : UH11 =
                match v107 with
                | US3_SupportSlotOrigin(v109) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH18_PositionTreeCat(v110, v111) -> (* PositionTreeCat *)
                        match v109 with
                        | UH7_OriginSlotCatLeft(v112) -> (* OriginSlotCatLeft *)
                            let v115 : UH11 =
                                match v111 with
                                | UH13_PositionTreeChar(v113) -> (* PositionTreeChar *)
                                    UH11_RegexChar(v113)
                            let v116 : (UH11 -> UH11) = v0 v115
                            let v117 : UH11 = UH11_RegexEpsilon
                            let v118 : UH11 = v116 v117
                            match v110 with
                            | UH17_PositionTreeStar(v119) -> (* PositionTreeStar *)
                                match v112 with
                                | UH8_OriginSlotStar(v120) -> (* OriginSlotStar *)
                                    let v130 : UH11 =
                                        match v119 with
                                        | UH16_PositionTreeAlt(v121, v122) -> (* PositionTreeAlt *)
                                            let v125 : UH11 =
                                                match v121 with
                                                | UH13_PositionTreeChar(v123) -> (* PositionTreeChar *)
                                                    UH11_RegexChar(v123)
                                            let v128 : UH11 =
                                                match v122 with
                                                | UH13_PositionTreeChar(v126) -> (* PositionTreeChar *)
                                                    UH11_RegexChar(v126)
                                            UH11_RegexAlt(v125, v128)
                                    let v131 : UH11 = UH11_RegexStar(v130)
                                    let v132 : (UH11 -> UH11) = v0 v131
                                    let v133 : UH11 = v132 v118
                                    match v119 with
                                    | UH16_PositionTreeAlt(v134, v135) -> (* PositionTreeAlt *)
                                        match v120 with
                                        | UH9_OriginSlotAltLeft(v136) -> (* OriginSlotAltLeft *)
                                            match v134 with
                                            | UH13_PositionTreeChar(v137) -> (* PositionTreeChar *)
                                                match v136 with
                                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                                    let v138 : UH11 = UH11_RegexEpsilon
                                                    let v139 : (UH11 -> UH11) = v0 v138
                                                    v139 v133
                                        | UH9_OriginSlotAltRight(v143) -> (* OriginSlotAltRight *)
                                            match v135 with
                                            | UH13_PositionTreeChar(v144) -> (* PositionTreeChar *)
                                                match v143 with
                                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                                    let v145 : UH11 = UH11_RegexEpsilon
                                                    let v146 : (UH11 -> UH11) = v0 v145
                                                    v146 v133
                        | UH7_OriginSlotCatRight(v155) -> (* OriginSlotCatRight *)
                            match v111 with
                            | UH13_PositionTreeChar(v156) -> (* PositionTreeChar *)
                                match v155 with
                                | UH10_OriginSlotChar -> (* OriginSlotChar *)
                                    let v157 : UH11 = UH11_RegexEpsilon
                                    let v158 : (UH11 -> UH11) = v0 v157
                                    let v159 : UH11 = UH11_RegexEpsilon
                                    v158 v159
                | US3_SupportSlotRoot -> (* SupportSlotRoot *)
                    v2
            let v168 : bool = v108 v167
            if v168 then
                antimirov_support_covered_by_typed_slots_41(v0, v1, v2, v3, v6)
            else
                false
        | US2_SupportSlotMissing -> (* SupportSlotMissing *)
            false
    | UH12_RegexListNil -> (* RegexListNil *)
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
let v10 : UH0 = normalize_0(v9)
let v11 : UH1 = antimirov_residual_support_7(v10)
let v12 : UH1 = antimirov_insert_unique_9(v10, v11)
let v13 : bool = regex_list_distinct_12(v12)
let v14 : US0 = US0_BitZero
let v15 : UH0 = UH0_RegexChar(v14)
let v16 : US0 = US0_BitOne
let v17 : UH0 = UH0_RegexChar(v16)
let v18 : UH0 = UH0_RegexAlt(v15, v17)
let v19 : UH0 = UH0_RegexStar(v18)
let v20 : US0 = US0_BitZero
let v21 : UH0 = UH0_RegexChar(v20)
let v22 : UH0 = UH0_RegexCat(v19, v21)
let v23 : UH0 = normalize_0(v22)
let v24 : bool = regex_equal_5(v23, v9)
let v37 : bool =
    if v24 then
        let v25 : US0 = US0_BitZero
        let v26 : UH2 = UH2_PositionTreeChar(v25)
        let v27 : US0 = US0_BitOne
        let v28 : UH2 = UH2_PositionTreeChar(v27)
        let v29 : UH3 = UH3_PositionTreeAlt(v26, v28)
        let v30 : UH4 = UH4_PositionTreeStar(v29)
        let v31 : US0 = US0_BitZero
        let v32 : UH2 = UH2_PositionTreeChar(v31)
        let v33 : UH5 = UH5_PositionTreeCat(v30, v32)
        let v34 : UH6 = antimirov_position_tree_budget_13(v33)
        let v35 : UH6 = regex_position_count_18(v9)
        state_budget_same_19(v34, v35)
    else
        false
let v38 : bool = v37 && v13
let v51 : bool =
    if v38 then
        let v39 : (UH0 -> (UH0 -> UH0)) = closure0()
        let v40 : (UH0 -> (UH0 -> bool)) = closure2()
        let v41 : US0 = US0_BitZero
        let v42 : UH2 = UH2_PositionTreeChar(v41)
        let v43 : US0 = US0_BitOne
        let v44 : UH2 = UH2_PositionTreeChar(v43)
        let v45 : UH3 = UH3_PositionTreeAlt(v42, v44)
        let v46 : UH4 = UH4_PositionTreeStar(v45)
        let v47 : US0 = US0_BitZero
        let v48 : UH2 = UH2_PositionTreeChar(v47)
        let v49 : UH5 = UH5_PositionTreeCat(v46, v48)
        antimirov_support_covered_by_typed_slots_20(v39, v40, v9, v49, v12)
    else
        false
if v51 then
    ()
else
    failwith<unit> "bit Antimirov support must fit the typed root-plus-position slot universe"
let v52 : US0 = US0_BitZero
let v53 : UH0 = UH0_RegexChar(v52)
let v54 : US0 = US0_BitOne
let v55 : UH0 = UH0_RegexChar(v54)
let v56 : UH0 = UH0_RegexAlt(v53, v55)
let v57 : UH0 = UH0_RegexStar(v56)
let v58 : US0 = US0_BitZero
let v59 : UH0 = UH0_RegexChar(v58)
let v60 : UH0 = UH0_RegexCat(v57, v59)
let v61 : UH0 = normalize_0(v60)
let v62 : UH0 = normalize_0(v61)
let v63 : UH1 = antimirov_residual_support_7(v62)
let v64 : UH1 = antimirov_insert_unique_9(v62, v63)
let v65 : bool = regex_list_distinct_12(v64)
let v66 : US0 = US0_BitZero
let v67 : UH0 = UH0_RegexChar(v66)
let v68 : US0 = US0_BitOne
let v69 : UH0 = UH0_RegexChar(v68)
let v70 : UH0 = UH0_RegexAlt(v67, v69)
let v71 : UH0 = UH0_RegexStar(v70)
let v72 : US0 = US0_BitOne
let v73 : UH0 = UH0_RegexChar(v72)
let v74 : UH0 = UH0_RegexCat(v71, v73)
let v75 : UH0 = normalize_0(v74)
let v76 : bool = regex_equal_5(v75, v61)
let v89 : bool =
    if v76 then
        let v77 : US0 = US0_BitZero
        let v78 : UH2 = UH2_PositionTreeChar(v77)
        let v79 : US0 = US0_BitOne
        let v80 : UH2 = UH2_PositionTreeChar(v79)
        let v81 : UH3 = UH3_PositionTreeAlt(v78, v80)
        let v82 : UH4 = UH4_PositionTreeStar(v81)
        let v83 : US0 = US0_BitOne
        let v84 : UH2 = UH2_PositionTreeChar(v83)
        let v85 : UH5 = UH5_PositionTreeCat(v82, v84)
        let v86 : UH6 = antimirov_position_tree_budget_13(v85)
        let v87 : UH6 = regex_position_count_18(v61)
        state_budget_same_19(v86, v87)
    else
        false
let v90 : bool = v89 && v65
let v103 : bool =
    if v90 then
        let v91 : (UH0 -> (UH0 -> UH0)) = closure0()
        let v92 : (UH0 -> (UH0 -> bool)) = closure2()
        let v93 : US0 = US0_BitZero
        let v94 : UH2 = UH2_PositionTreeChar(v93)
        let v95 : US0 = US0_BitOne
        let v96 : UH2 = UH2_PositionTreeChar(v95)
        let v97 : UH3 = UH3_PositionTreeAlt(v94, v96)
        let v98 : UH4 = UH4_PositionTreeStar(v97)
        let v99 : US0 = US0_BitOne
        let v100 : UH2 = UH2_PositionTreeChar(v99)
        let v101 : UH5 = UH5_PositionTreeCat(v98, v100)
        antimirov_support_covered_by_typed_slots_20(v91, v92, v61, v101, v64)
    else
        false
let v104 : bool = v103 = false
if v104 then
    ()
else
    failwith<unit> "same-cardinality forged typed position tree must not certify the source regex"
let v105 : US8 = US8_TriA
let v106 : UH11 = UH11_RegexChar(v105)
let v107 : UH11 = UH11_RegexStar(v106)
let v108 : UH11 = normalize_21(v107)
let v109 : UH11 = normalize_21(v108)
let v110 : UH12 = antimirov_residual_support_28(v109)
let v111 : UH12 = antimirov_insert_unique_30(v109, v110)
let v112 : bool = regex_list_distinct_33(v111)
let v113 : US8 = US8_TriA
let v114 : UH11 = UH11_RegexChar(v113)
let v115 : UH11 = UH11_RegexStar(v114)
let v116 : UH11 = normalize_21(v115)
let v117 : bool = regex_equal_26(v116, v108)
let v124 : bool =
    if v117 then
        let v118 : US8 = US8_TriA
        let v119 : UH13 = UH13_PositionTreeChar(v118)
        let v120 : UH14 = UH14_PositionTreeStar(v119)
        let v121 : UH6 = antimirov_position_tree_budget_34(v120)
        let v122 : UH6 = regex_position_count_36(v108)
        state_budget_same_19(v121, v122)
    else
        false
let v125 : bool = v124 && v112
let v132 : bool =
    if v125 then
        let v126 : (UH11 -> (UH11 -> UH11)) = closure4()
        let v127 : (UH11 -> (UH11 -> bool)) = closure6()
        let v128 : US8 = US8_TriA
        let v129 : UH13 = UH13_PositionTreeChar(v128)
        let v130 : UH14 = UH14_PositionTreeStar(v129)
        antimirov_support_covered_by_typed_slots_37(v126, v127, v108, v130, v111)
    else
        false
if v132 then
    ()
else
    failwith<unit> "ternary star support must fit the typed root-plus-position slot universe"
let v133 : US8 = US8_TriA
let v134 : UH11 = UH11_RegexChar(v133)
let v135 : US8 = US8_TriB
let v136 : UH11 = UH11_RegexChar(v135)
let v137 : UH11 = UH11_RegexAlt(v134, v136)
let v138 : UH11 = UH11_RegexStar(v137)
let v139 : US8 = US8_TriC
let v140 : UH11 = UH11_RegexChar(v139)
let v141 : UH11 = UH11_RegexCat(v138, v140)
let v142 : UH11 = normalize_21(v141)
let v143 : UH11 = normalize_21(v142)
let v144 : UH12 = antimirov_residual_support_28(v143)
let v145 : UH12 = antimirov_insert_unique_30(v143, v144)
let v146 : bool = regex_list_distinct_33(v145)
let v147 : US8 = US8_TriA
let v148 : UH11 = UH11_RegexChar(v147)
let v149 : US8 = US8_TriB
let v150 : UH11 = UH11_RegexChar(v149)
let v151 : UH11 = UH11_RegexAlt(v148, v150)
let v152 : UH11 = UH11_RegexStar(v151)
let v153 : US8 = US8_TriC
let v154 : UH11 = UH11_RegexChar(v153)
let v155 : UH11 = UH11_RegexCat(v152, v154)
let v156 : UH11 = normalize_21(v155)
let v157 : bool = regex_equal_26(v156, v142)
let v170 : bool =
    if v157 then
        let v158 : US8 = US8_TriA
        let v159 : UH13 = UH13_PositionTreeChar(v158)
        let v160 : US8 = US8_TriB
        let v161 : UH13 = UH13_PositionTreeChar(v160)
        let v162 : UH16 = UH16_PositionTreeAlt(v159, v161)
        let v163 : UH17 = UH17_PositionTreeStar(v162)
        let v164 : US8 = US8_TriC
        let v165 : UH13 = UH13_PositionTreeChar(v164)
        let v166 : UH18 = UH18_PositionTreeCat(v163, v165)
        let v167 : UH6 = antimirov_position_tree_budget_38(v166)
        let v168 : UH6 = regex_position_count_36(v142)
        state_budget_same_19(v167, v168)
    else
        false
let v171 : bool = v170 && v146
let v184 : bool =
    if v171 then
        let v172 : (UH11 -> (UH11 -> UH11)) = closure4()
        let v173 : (UH11 -> (UH11 -> bool)) = closure6()
        let v174 : US8 = US8_TriA
        let v175 : UH13 = UH13_PositionTreeChar(v174)
        let v176 : US8 = US8_TriB
        let v177 : UH13 = UH13_PositionTreeChar(v176)
        let v178 : UH16 = UH16_PositionTreeAlt(v175, v177)
        let v179 : UH17 = UH17_PositionTreeStar(v178)
        let v180 : US8 = US8_TriC
        let v181 : UH13 = UH13_PositionTreeChar(v180)
        let v182 : UH18 = UH18_PositionTreeCat(v179, v181)
        antimirov_support_covered_by_typed_slots_41(v172, v173, v142, v182, v145)
    else
        false
if v184 then
    ()
else
    failwith<unit> "ternary cat/alt/star support must fit the typed root-plus-position slot universe"
let v185 : string = "brzozowski-antimirov-typed-slot-bound-green"
v185
