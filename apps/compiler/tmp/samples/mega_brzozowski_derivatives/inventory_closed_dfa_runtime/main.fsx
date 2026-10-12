type [<Struct>] US0 =
    | US0_BitZero
    | US0_BitOne
and UH0 =
    | UH0_SymbolListNil
    | UH0_SymbolListCons of US0 * UH0
and UH2 =
    | UH2_InputEmpty
    | UH2_InputCons of US0 * UH2
and UH1 =
    | UH1_InputListNil
    | UH1_InputListCons of UH2 * UH1
and [<Struct>] US1 =
    | US1_TriA
    | US1_TriB
    | US1_TriC
and UH3 =
    | UH3_SymbolListNil
    | UH3_SymbolListCons of US1 * UH3
and UH5 =
    | UH5_InputEmpty
    | UH5_InputCons of US1 * UH5
and UH4 =
    | UH4_InputListNil
    | UH4_InputListCons of UH5 * UH4
and [<Struct>] US2 =
    | US2_ModelA
    | US2_ModelB
    | US2_ModelC
and UH6 =
    | UH6_InputEmpty
    | UH6_InputCons of US2 * UH6
and UH7 =
    | UH7_RegexEmpty
    | UH7_RegexEpsilon
    | UH7_RegexChar of US0
    | UH7_RegexAlt of UH7 * UH7
    | UH7_RegexCat of UH7 * UH7
    | UH7_RegexStar of UH7
and [<Struct>] US3 =
    | US3_InventoryDfaAccepted
    | US3_InventoryDfaRejected
    | US3_InventoryDfaInputOutsideInventory
and [<Struct>] US4 =
    | US4_SymbolLess
    | US4_SymbolSame
    | US4_SymbolGreater
and [<Struct>] US5 =
    | US5_Nullable
    | US5_NonNullable
and UH8 =
    | UH8_RegexEmpty
    | UH8_RegexEpsilon
    | UH8_RegexChar of US1
    | UH8_RegexAlt of UH8 * UH8
    | UH8_RegexCat of UH8 * UH8
    | UH8_RegexStar of UH8
let rec input_singletons_from_symbols_0 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH1 = input_singletons_from_symbols_0(v3)
        let v5 : UH2 = UH2_InputEmpty
        let v6 : UH2 = UH2_InputCons(v2, v5)
        UH1_InputListCons(v6, v4)
    | UH0_SymbolListNil -> (* SymbolListNil *)
        UH1_InputListNil
and input_prepend_symbol_to_corpus_2 (v0 : US0, v1 : UH1) : UH1 =
    match v1 with
    | UH1_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH1 = input_prepend_symbol_to_corpus_2(v0, v4)
        let v6 : UH2 = UH2_InputCons(v0, v3)
        UH1_InputListCons(v6, v5)
    | UH1_InputListNil -> (* InputListNil *)
        UH1_InputListNil
and input_list_append_3 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : UH1 = input_list_append_3(v3, v1)
        UH1_InputListCons(v2, v4)
    | UH1_InputListNil -> (* InputListNil *)
        v1
and input_prepend_symbols_to_corpus_1 (v0 : UH0, v1 : UH1) : UH1 =
    match v0 with
    | UH0_SymbolListCons(v3, v4) -> (* SymbolListCons *)
        let v5 : UH1 = input_prepend_symbol_to_corpus_2(v3, v1)
        let v6 : UH1 = input_prepend_symbols_to_corpus_1(v4, v1)
        input_list_append_3(v5, v6)
    | UH0_SymbolListNil -> (* SymbolListNil *)
        UH1_InputListNil
and input_singletons_from_symbols_4 (v0 : UH3) : UH4 =
    match v0 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = input_singletons_from_symbols_4(v3)
        let v5 : UH5 = UH5_InputEmpty
        let v6 : UH5 = UH5_InputCons(v2, v5)
        UH4_InputListCons(v6, v4)
    | UH3_SymbolListNil -> (* SymbolListNil *)
        UH4_InputListNil
and input_prepend_symbol_to_corpus_6 (v0 : US1, v1 : UH4) : UH4 =
    match v1 with
    | UH4_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = input_prepend_symbol_to_corpus_6(v0, v4)
        let v6 : UH5 = UH5_InputCons(v0, v3)
        UH4_InputListCons(v6, v5)
    | UH4_InputListNil -> (* InputListNil *)
        UH4_InputListNil
and input_list_append_7 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : UH4 = input_list_append_7(v3, v1)
        UH4_InputListCons(v2, v4)
    | UH4_InputListNil -> (* InputListNil *)
        v1
and input_prepend_symbols_to_corpus_5 (v0 : UH3, v1 : UH4) : UH4 =
    match v0 with
    | UH3_SymbolListCons(v3, v4) -> (* SymbolListCons *)
        let v5 : UH4 = input_prepend_symbol_to_corpus_6(v3, v1)
        let v6 : UH4 = input_prepend_symbols_to_corpus_5(v4, v1)
        input_list_append_7(v5, v6)
    | UH3_SymbolListNil -> (* SymbolListNil *)
        UH4_InputListNil
and loop_9 (v0 : int32, v1 : UH2) : US3 =
    match v1 with
    | UH2_InputCons(v6, v7) -> (* InputCons *)
        let v11 : US4 =
            match v6 with
            | US0_BitOne -> (* BitOne *)
                US4_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                US4_SymbolSame
        let v12 : bool =
            match v11 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        let v19 : int32 =
            if v12 then
                0
            else
                let v16 : US4 =
                    match v6 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolLess
                let v17 : bool =
                    match v16 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v17 then
                    1
                else
                    -1
        let v20 : bool = v19 < 0
        if v20 then
            US3_InventoryDfaInputOutsideInventory
        else
            let v22 : bool = v0 = 0
            let v27 : int32 =
                if v22 then
                    let v23 : bool = v19 = 0
                    if v23 then
                        0
                    else
                        1
                else
                    let v25 : bool = v19 = 0
                    if v25 then
                        0
                    else
                        1
            loop_9(v27, v7)
    | UH2_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 0
        if v2 then
            US3_InventoryDfaAccepted
        else
            US3_InventoryDfaRejected
and regex_compare_15 (v0 : UH7, v1 : UH7) : US4 =
    match v0 with
    | UH7_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH7_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US4 = regex_compare_15(v53, v55)
            match v57 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_15(v54, v56)
            | _ ->
                v57
        | _ ->
            US4_SymbolGreater
    | UH7_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH7_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US4 = regex_compare_15(v28, v34)
            match v36 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_15(v29, v35)
            | _ ->
                v36
        | UH7_RegexChar(v32) -> (* RegexChar *)
            US4_SymbolGreater
        | UH7_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH7_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolGreater
        | _ ->
            US4_SymbolLess
    | UH7_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH7_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US0_BitOne -> (* BitOne *)
                match v13 with
                | US0_BitOne -> (* BitOne *)
                    US4_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US4_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v13 with
                | US0_BitOne -> (* BitOne *)
                    US4_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US4_SymbolSame
        | UH7_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH7_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolGreater
        | _ ->
            US4_SymbolLess
    | UH7_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH7_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolSame
        | _ ->
            US4_SymbolLess
    | UH7_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH7_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH7_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolSame
        | _ ->
            US4_SymbolLess
    | UH7_RegexStar(v44) -> (* RegexStar *)
        match v1 with
        | UH7_RegexAlt(v45, v46) -> (* RegexAlt *)
            US4_SymbolLess
        | UH7_RegexStar(v48) -> (* RegexStar *)
            regex_compare_15(v44, v48)
        | _ ->
            US4_SymbolGreater
and alt_insert_sorted_14 (v0 : UH7, v1 : UH7) : UH7 =
    match v1 with
    | UH7_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = regex_compare_15(v0, v2)
        match v4 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH7 = alt_insert_sorted_14(v0, v3)
            UH7_RegexAlt(v2, v6)
        | US4_SymbolLess -> (* SymbolLess *)
            UH7_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
    | UH7_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US4 = regex_compare_15(v0, v1)
        match v11 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            UH7_RegexAlt(v1, v0)
        | US4_SymbolLess -> (* SymbolLess *)
            UH7_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_13 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH7 = alt_insert_sorted_14(v2, v1)
        make_alt_13(v3, v4)
    | UH7_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_14(v0, v1)
and regex_equal_17 (v0 : UH7, v1 : UH7) : bool =
    match v0 with
    | UH7_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH7_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_17(v18, v20)
            if v22 then
                regex_equal_17(v19, v21)
            else
                false
        | _ ->
            false
    | UH7_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH7_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_17(v26, v28)
            if v30 then
                regex_equal_17(v27, v29)
            else
                false
        | _ ->
            false
    | UH7_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH7_RegexChar(v5) -> (* RegexChar *)
            let v15 : US4 =
                match v4 with
                | US0_BitOne -> (* BitOne *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolSame
            match v15 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH7_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH7_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH7_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH7_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH7_RegexStar(v34) -> (* RegexStar *)
        match v1 with
        | UH7_RegexStar(v35) -> (* RegexStar *)
            regex_equal_17(v34, v35)
        | _ ->
            false
and make_cat_16 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_RegexEmpty -> (* RegexEmpty *)
        UH7_RegexEmpty
    | _ ->
        match v1 with
        | UH7_RegexEmpty -> (* RegexEmpty *)
            UH7_RegexEmpty
        | _ ->
            match v0 with
            | UH7_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH7_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH7_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH7 = make_cat_16(v13, v1)
                        UH7_RegexCat(v12, v14)
                    | UH7_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH7_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_17(v4, v5)
                            if v6 then
                                UH7_RegexStar(v4)
                            else
                                UH7_RegexCat(v0, v1)
                        | _ ->
                            UH7_RegexCat(v0, v1)
                    | _ ->
                        UH7_RegexCat(v0, v1)
and make_star_18 (v0 : UH7) : UH7 =
    match v0 with
    | UH7_RegexEmpty -> (* RegexEmpty *)
        UH7_RegexEpsilon
    | UH7_RegexEpsilon -> (* RegexEpsilon *)
        UH7_RegexEpsilon
    | UH7_RegexStar(v3) -> (* RegexStar *)
        UH7_RegexStar(v3)
    | _ ->
        UH7_RegexStar(v0)
and normalize_12 (v0 : UH7) : UH7 =
    match v0 with
    | UH7_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH7 = normalize_12(v5)
        let v8 : UH7 = normalize_12(v6)
        make_alt_13(v7, v8)
    | UH7_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH7 = normalize_12(v10)
        let v13 : UH7 = normalize_12(v11)
        make_cat_16(v12, v13)
    | UH7_RegexChar(v3) -> (* RegexChar *)
        UH7_RegexChar(v3)
    | UH7_RegexEmpty -> (* RegexEmpty *)
        UH7_RegexEmpty
    | UH7_RegexEpsilon -> (* RegexEpsilon *)
        UH7_RegexEpsilon
    | UH7_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH7 = normalize_12(v15)
        make_star_18(v16)
and nullable_20 (v0 : UH7) : US5 =
    match v0 with
    | UH7_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US5 = nullable_20(v5)
        let v8 : US5 = nullable_20(v6)
        match v7 with
        | US5_Nullable -> (* Nullable *)
            US5_Nullable
        | _ ->
            match v8 with
            | US5_Nullable -> (* Nullable *)
                US5_Nullable
            | _ ->
                match v7 with
                | US5_NonNullable -> (* NonNullable *)
                    match v8 with
                    | US5_NonNullable -> (* NonNullable *)
                        US5_NonNullable
    | UH7_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US5 = nullable_20(v16)
        let v19 : US5 = nullable_20(v17)
        match v18 with
        | US5_Nullable -> (* Nullable *)
            match v19 with
            | US5_Nullable -> (* Nullable *)
                US5_Nullable
            | _ ->
                US5_NonNullable
        | _ ->
            US5_NonNullable
    | UH7_RegexChar(v3) -> (* RegexChar *)
        US5_NonNullable
    | UH7_RegexEmpty -> (* RegexEmpty *)
        US5_NonNullable
    | UH7_RegexEpsilon -> (* RegexEpsilon *)
        US5_Nullable
    | UH7_RegexStar(v25) -> (* RegexStar *)
        US5_Nullable
and derivative_19 (v0 : UH7, v1 : US0) : UH7 =
    match v0 with
    | UH7_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH7 = derivative_19(v19, v1)
        let v22 : UH7 = derivative_19(v20, v1)
        make_alt_13(v21, v22)
    | UH7_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US5 = nullable_20(v24)
        match v26 with
        | US5_NonNullable -> (* NonNullable *)
            let v31 : UH7 = derivative_19(v24, v1)
            make_cat_16(v31, v25)
        | US5_Nullable -> (* Nullable *)
            let v27 : UH7 = derivative_19(v24, v1)
            let v28 : UH7 = make_cat_16(v27, v25)
            let v29 : UH7 = derivative_19(v25, v1)
            make_alt_13(v28, v29)
    | UH7_RegexChar(v4) -> (* RegexChar *)
        let v14 : US4 =
            match v4 with
            | US0_BitOne -> (* BitOne *)
                match v1 with
                | US0_BitOne -> (* BitOne *)
                    US4_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US4_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v1 with
                | US0_BitOne -> (* BitOne *)
                    US4_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US4_SymbolSame
        let v15 : bool =
            match v14 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH7_RegexEpsilon
        else
            UH7_RegexEmpty
    | UH7_RegexEmpty -> (* RegexEmpty *)
        UH7_RegexEmpty
    | UH7_RegexEpsilon -> (* RegexEpsilon *)
        UH7_RegexEmpty
    | UH7_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH7 = derivative_19(v35, v1)
        let v37 : UH7 = make_star_18(v35)
        make_cat_16(v36, v37)
and canonical_derivative_11 (v0 : UH7, v1 : US0) : UH7 =
    let v2 : UH7 = normalize_12(v0)
    let v3 : UH7 = derivative_19(v2, v1)
    normalize_12(v3)
and accepts_10 (v0 : UH7, v1 : UH2) : bool =
    match v1 with
    | UH2_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH7 = canonical_derivative_11(v0, v6)
        accepts_10(v8, v7)
    | UH2_InputEmpty -> (* InputEmpty *)
        let v2 : UH7 = normalize_12(v0)
        let v3 : US5 = nullable_20(v2)
        match v3 with
        | US5_NonNullable -> (* NonNullable *)
            false
        | US5_Nullable -> (* Nullable *)
            true
and loop_8 (v0 : UH7, v1 : UH1) : bool =
    match v1 with
    | UH1_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : int32 = 1
        let v5 : US3 = loop_9(v4, v2)
        let v11 : bool =
            match v5 with
            | US3_InventoryDfaAccepted -> (* InventoryDfaAccepted *)
                accepts_10(v0, v2)
            | US3_InventoryDfaInputOutsideInventory -> (* InventoryDfaInputOutsideInventory *)
                false
            | US3_InventoryDfaRejected -> (* InventoryDfaRejected *)
                let v7 : bool = accepts_10(v0, v2)
                let v8 : bool = v7 = false
                v8
        if v11 then
            loop_8(v0, v3)
        else
            false
    | UH1_InputListNil -> (* InputListNil *)
        true
and loop_22 (v0 : int32, v1 : UH5) : US3 =
    match v1 with
    | UH5_InputCons(v8, v9) -> (* InputCons *)
        let v12 : US4 =
            match v8 with
            | US1_TriA -> (* TriA *)
                US4_SymbolSame
            | _ ->
                US4_SymbolGreater
        let v13 : bool =
            match v12 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        let v30 : int32 =
            if v13 then
                0
            else
                let v19 : US4 =
                    match v8 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolLess
                    | US1_TriB -> (* TriB *)
                        US4_SymbolSame
                    | US1_TriC -> (* TriC *)
                        US4_SymbolGreater
                let v20 : bool =
                    match v19 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v20 then
                    1
                else
                    let v26 : US4 =
                        match v8 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolLess
                        | US1_TriB -> (* TriB *)
                            US4_SymbolLess
                        | US1_TriC -> (* TriC *)
                            US4_SymbolSame
                    let v27 : bool =
                        match v26 with
                        | US4_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    if v27 then
                        2
                    else
                        -1
        let v31 : bool = v30 < 0
        if v31 then
            US3_InventoryDfaInputOutsideInventory
        else
            let v33 : bool = v0 = 0
            let v46 : int32 =
                if v33 then
                    let v34 : bool = v30 = 0
                    if v34 then
                        0
                    else
                        let v35 : bool = v30 = 1
                        0
                else
                    let v37 : bool = v0 = 1
                    if v37 then
                        let v38 : bool = v30 = 0
                        if v38 then
                            0
                        else
                            let v39 : bool = v30 = 1
                            0
                    else
                        let v41 : bool = v30 = 0
                        if v41 then
                            2
                        else
                            let v42 : bool = v30 = 1
                            if v42 then
                                2
                            else
                                1
            loop_22(v46, v9)
    | UH5_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 0
        let v4 : bool =
            if v2 then
                false
            else
                let v3 : bool = v0 = 1
                v3
        if v4 then
            US3_InventoryDfaAccepted
        else
            US3_InventoryDfaRejected
and regex_compare_28 (v0 : UH8, v1 : UH8) : US4 =
    match v0 with
    | UH8_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH8_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US4 = regex_compare_28(v59, v61)
            match v63 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_28(v60, v62)
            | _ ->
                v63
        | _ ->
            US4_SymbolGreater
    | UH8_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH8_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US4 = regex_compare_28(v34, v40)
            match v42 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_28(v35, v41)
            | _ ->
                v42
        | UH8_RegexChar(v38) -> (* RegexChar *)
            US4_SymbolGreater
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolGreater
        | _ ->
            US4_SymbolLess
    | UH8_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH8_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US1_TriA -> (* TriA *)
                match v13 with
                | US1_TriA -> (* TriA *)
                    US4_SymbolSame
                | _ ->
                    US4_SymbolLess
            | _ ->
                match v13 with
                | US1_TriA -> (* TriA *)
                    US4_SymbolGreater
                | _ ->
                    match v10 with
                    | US1_TriB -> (* TriB *)
                        match v13 with
                        | US1_TriB -> (* TriB *)
                            US4_SymbolSame
                        | US1_TriC -> (* TriC *)
                            US4_SymbolLess
                    | US1_TriC -> (* TriC *)
                        match v13 with
                        | US1_TriB -> (* TriB *)
                            US4_SymbolGreater
                        | US1_TriC -> (* TriC *)
                            US4_SymbolSame
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolGreater
        | _ ->
            US4_SymbolLess
    | UH8_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolSame
        | _ ->
            US4_SymbolLess
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH8_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH8_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolSame
        | _ ->
            US4_SymbolLess
    | UH8_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH8_RegexAlt(v51, v52) -> (* RegexAlt *)
            US4_SymbolLess
        | UH8_RegexStar(v54) -> (* RegexStar *)
            regex_compare_28(v50, v54)
        | _ ->
            US4_SymbolGreater
and alt_insert_sorted_27 (v0 : UH8, v1 : UH8) : UH8 =
    match v1 with
    | UH8_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = regex_compare_28(v0, v2)
        match v4 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH8 = alt_insert_sorted_27(v0, v3)
            UH8_RegexAlt(v2, v6)
        | US4_SymbolLess -> (* SymbolLess *)
            UH8_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
    | UH8_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US4 = regex_compare_28(v0, v1)
        match v11 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            UH8_RegexAlt(v1, v0)
        | US4_SymbolLess -> (* SymbolLess *)
            UH8_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_26 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH8 = alt_insert_sorted_27(v2, v1)
        make_alt_26(v3, v4)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_27(v0, v1)
and regex_equal_30 (v0 : UH8, v1 : UH8) : bool =
    match v0 with
    | UH8_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH8_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_30(v24, v26)
            if v28 then
                regex_equal_30(v25, v27)
            else
                false
        | _ ->
            false
    | UH8_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH8_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_30(v32, v34)
            if v36 then
                regex_equal_30(v33, v35)
            else
                false
        | _ ->
            false
    | UH8_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH8_RegexChar(v5) -> (* RegexChar *)
            let v21 : US4 =
                match v4 with
                | US1_TriA -> (* TriA *)
                    match v5 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolSame
                    | _ ->
                        US4_SymbolLess
                | _ ->
                    match v5 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolGreater
                    | _ ->
                        match v4 with
                        | US1_TriB -> (* TriB *)
                            match v5 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolSame
                            | US1_TriC -> (* TriC *)
                                US4_SymbolLess
                        | US1_TriC -> (* TriC *)
                            match v5 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolGreater
                            | US1_TriC -> (* TriC *)
                                US4_SymbolSame
            match v21 with
            | US4_SymbolSame -> (* SymbolSame *)
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
            regex_equal_30(v40, v41)
        | _ ->
            false
and make_cat_29 (v0 : UH8, v1 : UH8) : UH8 =
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
                        let v14 : UH8 = make_cat_29(v13, v1)
                        UH8_RegexCat(v12, v14)
                    | UH8_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH8_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_30(v4, v5)
                            if v6 then
                                UH8_RegexStar(v4)
                            else
                                UH8_RegexCat(v0, v1)
                        | _ ->
                            UH8_RegexCat(v0, v1)
                    | _ ->
                        UH8_RegexCat(v0, v1)
and make_star_31 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEpsilon
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEpsilon
    | UH8_RegexStar(v3) -> (* RegexStar *)
        UH8_RegexStar(v3)
    | _ ->
        UH8_RegexStar(v0)
and normalize_25 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH8 = normalize_25(v5)
        let v8 : UH8 = normalize_25(v6)
        make_alt_26(v7, v8)
    | UH8_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH8 = normalize_25(v10)
        let v13 : UH8 = normalize_25(v11)
        make_cat_29(v12, v13)
    | UH8_RegexChar(v3) -> (* RegexChar *)
        UH8_RegexChar(v3)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEmpty
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEpsilon
    | UH8_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH8 = normalize_25(v15)
        make_star_31(v16)
and nullable_33 (v0 : UH8) : US5 =
    match v0 with
    | UH8_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US5 = nullable_33(v5)
        let v8 : US5 = nullable_33(v6)
        match v7 with
        | US5_Nullable -> (* Nullable *)
            US5_Nullable
        | _ ->
            match v8 with
            | US5_Nullable -> (* Nullable *)
                US5_Nullable
            | _ ->
                match v7 with
                | US5_NonNullable -> (* NonNullable *)
                    match v8 with
                    | US5_NonNullable -> (* NonNullable *)
                        US5_NonNullable
    | UH8_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US5 = nullable_33(v16)
        let v19 : US5 = nullable_33(v17)
        match v18 with
        | US5_Nullable -> (* Nullable *)
            match v19 with
            | US5_Nullable -> (* Nullable *)
                US5_Nullable
            | _ ->
                US5_NonNullable
        | _ ->
            US5_NonNullable
    | UH8_RegexChar(v3) -> (* RegexChar *)
        US5_NonNullable
    | UH8_RegexEmpty -> (* RegexEmpty *)
        US5_NonNullable
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        US5_Nullable
    | UH8_RegexStar(v25) -> (* RegexStar *)
        US5_Nullable
and derivative_32 (v0 : UH8, v1 : US1) : UH8 =
    match v0 with
    | UH8_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH8 = derivative_32(v25, v1)
        let v28 : UH8 = derivative_32(v26, v1)
        make_alt_26(v27, v28)
    | UH8_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US5 = nullable_33(v30)
        match v32 with
        | US5_NonNullable -> (* NonNullable *)
            let v37 : UH8 = derivative_32(v30, v1)
            make_cat_29(v37, v31)
        | US5_Nullable -> (* Nullable *)
            let v33 : UH8 = derivative_32(v30, v1)
            let v34 : UH8 = make_cat_29(v33, v31)
            let v35 : UH8 = derivative_32(v31, v1)
            make_alt_26(v34, v35)
    | UH8_RegexChar(v4) -> (* RegexChar *)
        let v20 : US4 =
            match v4 with
            | US1_TriA -> (* TriA *)
                match v1 with
                | US1_TriA -> (* TriA *)
                    US4_SymbolSame
                | _ ->
                    US4_SymbolLess
            | _ ->
                match v1 with
                | US1_TriA -> (* TriA *)
                    US4_SymbolGreater
                | _ ->
                    match v4 with
                    | US1_TriB -> (* TriB *)
                        match v1 with
                        | US1_TriB -> (* TriB *)
                            US4_SymbolSame
                        | US1_TriC -> (* TriC *)
                            US4_SymbolLess
                    | US1_TriC -> (* TriC *)
                        match v1 with
                        | US1_TriB -> (* TriB *)
                            US4_SymbolGreater
                        | US1_TriC -> (* TriC *)
                            US4_SymbolSame
        let v21 : bool =
            match v20 with
            | US4_SymbolSame -> (* SymbolSame *)
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
        let v42 : UH8 = derivative_32(v41, v1)
        let v43 : UH8 = make_star_31(v41)
        make_cat_29(v42, v43)
and canonical_derivative_24 (v0 : UH8, v1 : US1) : UH8 =
    let v2 : UH8 = normalize_25(v0)
    let v3 : UH8 = derivative_32(v2, v1)
    normalize_25(v3)
and accepts_23 (v0 : UH8, v1 : UH5) : bool =
    match v1 with
    | UH5_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH8 = canonical_derivative_24(v0, v6)
        accepts_23(v8, v7)
    | UH5_InputEmpty -> (* InputEmpty *)
        let v2 : UH8 = normalize_25(v0)
        let v3 : US5 = nullable_33(v2)
        match v3 with
        | US5_NonNullable -> (* NonNullable *)
            false
        | US5_Nullable -> (* Nullable *)
            true
and loop_21 (v0 : UH8, v1 : UH4) : bool =
    match v1 with
    | UH4_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : int32 = 2
        let v5 : US3 = loop_22(v4, v2)
        let v11 : bool =
            match v5 with
            | US3_InventoryDfaAccepted -> (* InventoryDfaAccepted *)
                accepts_23(v0, v2)
            | US3_InventoryDfaInputOutsideInventory -> (* InventoryDfaInputOutsideInventory *)
                false
            | US3_InventoryDfaRejected -> (* InventoryDfaRejected *)
                let v7 : bool = accepts_23(v0, v2)
                let v8 : bool = v7 = false
                v8
        if v11 then
            loop_21(v0, v3)
        else
            false
    | UH4_InputListNil -> (* InputListNil *)
        true
and loop_34 (v0 : int32, v1 : UH6) : US3 =
    match v1 with
    | UH6_InputCons(v7, v8) -> (* InputCons *)
        let v11 : US4 =
            match v7 with
            | US2_ModelA -> (* ModelA *)
                US4_SymbolSame
            | _ ->
                US4_SymbolGreater
        let v12 : bool =
            match v11 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        let v21 : int32 =
            if v12 then
                0
            else
                let v18 : US4 =
                    match v7 with
                    | US2_ModelA -> (* ModelA *)
                        US4_SymbolLess
                    | US2_ModelB -> (* ModelB *)
                        US4_SymbolSame
                    | US2_ModelC -> (* ModelC *)
                        US4_SymbolGreater
                let v19 : bool =
                    match v18 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v19 then
                    1
                else
                    -1
        let v22 : bool = v21 < 0
        if v22 then
            US3_InventoryDfaInputOutsideInventory
        else
            let v24 : bool = v0 = 0
            let v28 : int32 =
                if v24 then
                    let v25 : bool = v21 = 0
                    0
                else
                    let v26 : bool = v21 = 0
                    if v26 then
                        1
                    else
                        0
            loop_34(v28, v8)
    | UH6_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 0
        let v3 : bool = v2 = false
        if v3 then
            US3_InventoryDfaAccepted
        else
            US3_InventoryDfaRejected
let v0 : US0 = US0_BitZero
let v1 : US0 = US0_BitOne
let v2 : UH0 = UH0_SymbolListNil
let v3 : UH0 = UH0_SymbolListCons(v1, v2)
let v4 : UH0 = UH0_SymbolListCons(v0, v3)
let v5 : UH1 = input_singletons_from_symbols_0(v4)
let v6 : UH2 = UH2_InputEmpty
let v7 : UH1 = UH1_InputListCons(v6, v5)
let v8 : US0 = US0_BitZero
let v9 : US0 = US0_BitOne
let v10 : UH0 = UH0_SymbolListNil
let v11 : UH0 = UH0_SymbolListCons(v9, v10)
let v12 : UH0 = UH0_SymbolListCons(v8, v11)
let v13 : US0 = US0_BitZero
let v14 : US0 = US0_BitOne
let v15 : UH0 = UH0_SymbolListNil
let v16 : UH0 = UH0_SymbolListCons(v14, v15)
let v17 : UH0 = UH0_SymbolListCons(v13, v16)
let v18 : UH1 = input_singletons_from_symbols_0(v17)
let v19 : UH1 = input_prepend_symbols_to_corpus_1(v12, v18)
let v20 : UH1 = input_list_append_3(v7, v19)
let v21 : US1 = US1_TriA
let v22 : US1 = US1_TriB
let v23 : US1 = US1_TriC
let v24 : UH3 = UH3_SymbolListNil
let v25 : UH3 = UH3_SymbolListCons(v23, v24)
let v26 : UH3 = UH3_SymbolListCons(v22, v25)
let v27 : UH3 = UH3_SymbolListCons(v21, v26)
let v28 : UH4 = input_singletons_from_symbols_4(v27)
let v29 : UH5 = UH5_InputEmpty
let v30 : UH4 = UH4_InputListCons(v29, v28)
let v31 : US1 = US1_TriA
let v32 : US1 = US1_TriB
let v33 : US1 = US1_TriC
let v34 : UH3 = UH3_SymbolListNil
let v35 : UH3 = UH3_SymbolListCons(v33, v34)
let v36 : UH3 = UH3_SymbolListCons(v32, v35)
let v37 : UH3 = UH3_SymbolListCons(v31, v36)
let v38 : US1 = US1_TriA
let v39 : US1 = US1_TriB
let v40 : US1 = US1_TriC
let v41 : UH3 = UH3_SymbolListNil
let v42 : UH3 = UH3_SymbolListCons(v40, v41)
let v43 : UH3 = UH3_SymbolListCons(v39, v42)
let v44 : UH3 = UH3_SymbolListCons(v38, v43)
let v45 : UH4 = input_singletons_from_symbols_4(v44)
let v46 : UH4 = input_prepend_symbols_to_corpus_5(v37, v45)
let v47 : UH4 = input_list_append_7(v30, v46)
let v48 : US2 = US2_ModelC
let v49 : UH6 = UH6_InputEmpty
let v50 : UH6 = UH6_InputCons(v48, v49)
let v51 : US0 = US0_BitZero
let v52 : UH7 = UH7_RegexChar(v51)
let v53 : US0 = US0_BitOne
let v54 : UH7 = UH7_RegexChar(v53)
let v55 : UH7 = UH7_RegexAlt(v52, v54)
let v56 : UH7 = UH7_RegexStar(v55)
let v57 : US0 = US0_BitZero
let v58 : UH7 = UH7_RegexChar(v57)
let v59 : UH7 = UH7_RegexCat(v56, v58)
let v60 : bool = loop_8(v59, v20)
let v75 : bool =
    if v60 then
        let v61 : US1 = US1_TriA
        let v62 : UH8 = UH8_RegexChar(v61)
        let v63 : US1 = US1_TriB
        let v64 : UH8 = UH8_RegexChar(v63)
        let v65 : UH8 = UH8_RegexAlt(v62, v64)
        let v66 : UH8 = UH8_RegexStar(v65)
        let v67 : US1 = US1_TriC
        let v68 : UH8 = UH8_RegexChar(v67)
        let v69 : UH8 = UH8_RegexCat(v66, v68)
        let v70 : bool = loop_21(v69, v47)
        if v70 then
            let v71 : int32 = 1
            let v72 : US3 = loop_34(v71, v50)
            match v72 with
            | US3_InventoryDfaInputOutsideInventory -> (* InventoryDfaInputOutsideInventory *)
                true
            | _ ->
                false
        else
            false
    else
        false
if v75 then
    0
else
    1
