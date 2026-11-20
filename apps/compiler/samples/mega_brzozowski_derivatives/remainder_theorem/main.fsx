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
and UH6 =
    | UH6_RegexEmpty
    | UH6_RegexEpsilon
    | UH6_RegexChar of US0
    | UH6_RegexAlt of UH6 * UH6
    | UH6_RegexCat of UH6 * UH6
    | UH6_RegexStar of UH6
and [<Struct>] US2 =
    | US2_RemainderCatNullable
    | US2_RemainderCatNonNullable
and UH7 =
    | UH7_RemainderProofEmpty of US0 * UH2
    | UH7_RemainderProofEpsilon of US0 * UH2
    | UH7_RemainderProofChar of US0 * US0 * UH2
    | UH7_RemainderProofAlt of US0 * UH2 * UH7 * UH7
    | UH7_RemainderProofCat of US0 * UH2 * US2 * UH7 * UH7
    | UH7_RemainderProofStar of US0 * UH2 * UH7
and [<Struct>] US3 =
    | US3_Nullable
    | US3_NonNullable
and [<Struct>] US4 =
    | US4_SymbolLess
    | US4_SymbolSame
    | US4_SymbolGreater
and UH8 =
    | UH8_RegexEmpty
    | UH8_RegexEpsilon
    | UH8_RegexChar of US1
    | UH8_RegexAlt of UH8 * UH8
    | UH8_RegexCat of UH8 * UH8
    | UH8_RegexStar of UH8
and UH9 =
    | UH9_RemainderProofEmpty of US1 * UH5
    | UH9_RemainderProofEpsilon of US1 * UH5
    | UH9_RemainderProofChar of US1 * US1 * UH5
    | UH9_RemainderProofAlt of US1 * UH5 * UH9 * UH9
    | UH9_RemainderProofCat of US1 * UH5 * US2 * UH9 * UH9
    | UH9_RemainderProofStar of US1 * UH5 * UH9
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
and nullable_11 (v0 : UH6) : US3 =
    match v0 with
    | UH6_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_11(v5)
        let v8 : US3 = nullable_11(v6)
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
    | UH6_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US3 = nullable_11(v16)
        let v19 : US3 = nullable_11(v17)
        match v18 with
        | US3_Nullable -> (* Nullable *)
            match v19 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                US3_NonNullable
        | _ ->
            US3_NonNullable
    | UH6_RegexChar(v3) -> (* RegexChar *)
        US3_NonNullable
    | UH6_RegexEmpty -> (* RegexEmpty *)
        US3_NonNullable
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        US3_Nullable
    | UH6_RegexStar(v25) -> (* RegexStar *)
        US3_Nullable
and derivative_remainder_proof_make_10 (v0 : UH6, v1 : US0, v2 : UH2) : UH7 =
    match v0 with
    | UH6_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH7 = derivative_remainder_proof_make_10(v7, v1, v2)
        let v10 : UH7 = derivative_remainder_proof_make_10(v8, v1, v2)
        UH7_RemainderProofAlt(v1, v2, v9, v10)
    | UH6_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : US3 = nullable_11(v12)
        let v18 : US2 =
            match v14 with
            | US3_NonNullable -> (* NonNullable *)
                US2_RemainderCatNonNullable
            | US3_Nullable -> (* Nullable *)
                US2_RemainderCatNullable
        let v19 : UH7 = derivative_remainder_proof_make_10(v12, v1, v2)
        let v20 : UH7 = derivative_remainder_proof_make_10(v13, v1, v2)
        UH7_RemainderProofCat(v1, v2, v18, v19, v20)
    | UH6_RegexChar(v5) -> (* RegexChar *)
        UH7_RemainderProofChar(v5, v1, v2)
    | UH6_RegexEmpty -> (* RegexEmpty *)
        UH7_RemainderProofEmpty(v1, v2)
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        UH7_RemainderProofEpsilon(v1, v2)
    | UH6_RegexStar(v22) -> (* RegexStar *)
        let v23 : UH7 = derivative_remainder_proof_make_10(v22, v1, v2)
        UH7_RemainderProofStar(v1, v2, v23)
and derivative_remainder_proof_source_12 (v0 : UH7) : UH6 =
    match v0 with
    | UH7_RemainderProofAlt(v11, v12, v13, v14) -> (* RemainderProofAlt *)
        let v15 : UH6 = derivative_remainder_proof_source_12(v13)
        let v16 : UH6 = derivative_remainder_proof_source_12(v14)
        UH6_RegexAlt(v15, v16)
    | UH7_RemainderProofCat(v18, v19, v20, v21, v22) -> (* RemainderProofCat *)
        let v23 : UH6 = derivative_remainder_proof_source_12(v21)
        let v24 : UH6 = derivative_remainder_proof_source_12(v22)
        UH6_RegexCat(v23, v24)
    | UH7_RemainderProofChar(v7, v8, v9) -> (* RemainderProofChar *)
        UH6_RegexChar(v7)
    | UH7_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        UH6_RegexEmpty
    | UH7_RemainderProofEpsilon(v4, v5) -> (* RemainderProofEpsilon *)
        UH6_RegexEpsilon
    | UH7_RemainderProofStar(v26, v27, v28) -> (* RemainderProofStar *)
        let v29 : UH6 = derivative_remainder_proof_source_12(v28)
        UH6_RegexStar(v29)
and regex_equal_13 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH6_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_13(v18, v20)
            if v22 then
                regex_equal_13(v19, v21)
            else
                false
        | _ ->
            false
    | UH6_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH6_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_13(v26, v28)
            if v30 then
                regex_equal_13(v27, v29)
            else
                false
        | _ ->
            false
    | UH6_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH6_RegexChar(v5) -> (* RegexChar *)
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
    | UH6_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH6_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH6_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH6_RegexStar(v34) -> (* RegexStar *)
        match v1 with
        | UH6_RegexStar(v35) -> (* RegexStar *)
            regex_equal_13(v34, v35)
        | _ ->
            false
and derivative_remainder_proof_symbol_14 (v0 : UH7) : US0 =
    match v0 with
    | UH7_RemainderProofAlt(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v8
    | UH7_RemainderProofCat(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v12
    | UH7_RemainderProofChar(v5, v6, v7) -> (* RemainderProofChar *)
        v6
    | UH7_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        v1
    | UH7_RemainderProofEpsilon(v3, v4) -> (* RemainderProofEpsilon *)
        v3
    | UH7_RemainderProofStar(v17, v18, v19) -> (* RemainderProofStar *)
        v17
and derivative_remainder_proof_suffix_15 (v0 : UH7) : UH2 =
    match v0 with
    | UH7_RemainderProofAlt(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v9
    | UH7_RemainderProofCat(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v13
    | UH7_RemainderProofChar(v5, v6, v7) -> (* RemainderProofChar *)
        v7
    | UH7_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        v2
    | UH7_RemainderProofEpsilon(v3, v4) -> (* RemainderProofEpsilon *)
        v4
    | UH7_RemainderProofStar(v17, v18, v19) -> (* RemainderProofStar *)
        v18
and input_equal_16 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_InputCons(v3, v4) -> (* InputCons *)
        match v1 with
        | UH2_InputCons(v5, v6) -> (* InputCons *)
            let v16 : US4 =
                match v3 with
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
            let v17 : bool =
                match v16 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                input_equal_16(v4, v6)
            else
                false
        | _ ->
            false
    | UH2_InputEmpty -> (* InputEmpty *)
        match v1 with
        | UH2_InputEmpty -> (* InputEmpty *)
            true
        | _ ->
            false
and regex_compare_21 (v0 : UH6, v1 : UH6) : US4 =
    match v0 with
    | UH6_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH6_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US4 = regex_compare_21(v53, v55)
            match v57 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_21(v54, v56)
            | _ ->
                v57
        | _ ->
            US4_SymbolGreater
    | UH6_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH6_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US4 = regex_compare_21(v28, v34)
            match v36 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_21(v29, v35)
            | _ ->
                v36
        | UH6_RegexChar(v32) -> (* RegexChar *)
            US4_SymbolGreater
        | UH6_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH6_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolGreater
        | _ ->
            US4_SymbolLess
    | UH6_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH6_RegexChar(v13) -> (* RegexChar *)
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
        | UH6_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH6_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolGreater
        | _ ->
            US4_SymbolLess
    | UH6_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH6_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolSame
        | _ ->
            US4_SymbolLess
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH6_RegexEmpty -> (* RegexEmpty *)
            US4_SymbolGreater
        | UH6_RegexEpsilon -> (* RegexEpsilon *)
            US4_SymbolSame
        | _ ->
            US4_SymbolLess
    | UH6_RegexStar(v44) -> (* RegexStar *)
        match v1 with
        | UH6_RegexAlt(v45, v46) -> (* RegexAlt *)
            US4_SymbolLess
        | UH6_RegexStar(v48) -> (* RegexStar *)
            regex_compare_21(v44, v48)
        | _ ->
            US4_SymbolGreater
and alt_insert_sorted_20 (v0 : UH6, v1 : UH6) : UH6 =
    match v1 with
    | UH6_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = regex_compare_21(v0, v2)
        match v4 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH6 = alt_insert_sorted_20(v0, v3)
            UH6_RegexAlt(v2, v6)
        | US4_SymbolLess -> (* SymbolLess *)
            UH6_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
    | UH6_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US4 = regex_compare_21(v0, v1)
        match v11 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            UH6_RegexAlt(v1, v0)
        | US4_SymbolLess -> (* SymbolLess *)
            UH6_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_19 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH6 = alt_insert_sorted_20(v2, v1)
        make_alt_19(v3, v4)
    | UH6_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_20(v0, v1)
and make_cat_22 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_RegexEmpty -> (* RegexEmpty *)
        UH6_RegexEmpty
    | _ ->
        match v1 with
        | UH6_RegexEmpty -> (* RegexEmpty *)
            UH6_RegexEmpty
        | _ ->
            match v0 with
            | UH6_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH6_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH6_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH6 = make_cat_22(v13, v1)
                        UH6_RegexCat(v12, v14)
                    | UH6_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH6_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_13(v4, v5)
                            if v6 then
                                UH6_RegexStar(v4)
                            else
                                UH6_RegexCat(v0, v1)
                        | _ ->
                            UH6_RegexCat(v0, v1)
                    | _ ->
                        UH6_RegexCat(v0, v1)
and make_star_23 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_RegexEmpty -> (* RegexEmpty *)
        UH6_RegexEpsilon
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        UH6_RegexEpsilon
    | UH6_RegexStar(v3) -> (* RegexStar *)
        UH6_RegexStar(v3)
    | _ ->
        UH6_RegexStar(v0)
and normalize_18 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH6 = normalize_18(v5)
        let v8 : UH6 = normalize_18(v6)
        make_alt_19(v7, v8)
    | UH6_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH6 = normalize_18(v10)
        let v13 : UH6 = normalize_18(v11)
        make_cat_22(v12, v13)
    | UH6_RegexChar(v3) -> (* RegexChar *)
        UH6_RegexChar(v3)
    | UH6_RegexEmpty -> (* RegexEmpty *)
        UH6_RegexEmpty
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        UH6_RegexEpsilon
    | UH6_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH6 = normalize_18(v15)
        make_star_23(v16)
and derivative_24 (v0 : UH6, v1 : US0) : UH6 =
    match v0 with
    | UH6_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH6 = derivative_24(v19, v1)
        let v22 : UH6 = derivative_24(v20, v1)
        make_alt_19(v21, v22)
    | UH6_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US3 = nullable_11(v24)
        match v26 with
        | US3_NonNullable -> (* NonNullable *)
            let v31 : UH6 = derivative_24(v24, v1)
            make_cat_22(v31, v25)
        | US3_Nullable -> (* Nullable *)
            let v27 : UH6 = derivative_24(v24, v1)
            let v28 : UH6 = make_cat_22(v27, v25)
            let v29 : UH6 = derivative_24(v25, v1)
            make_alt_19(v28, v29)
    | UH6_RegexChar(v4) -> (* RegexChar *)
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
            UH6_RegexEpsilon
        else
            UH6_RegexEmpty
    | UH6_RegexEmpty -> (* RegexEmpty *)
        UH6_RegexEmpty
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        UH6_RegexEmpty
    | UH6_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH6 = derivative_24(v35, v1)
        let v37 : UH6 = make_star_23(v35)
        make_cat_22(v36, v37)
and canonical_derivative_17 (v0 : UH6, v1 : US0) : UH6 =
    let v2 : UH6 = normalize_18(v0)
    let v3 : UH6 = derivative_24(v2, v1)
    normalize_18(v3)
and derivative_remainder_proof_candidate_25 (v0 : UH7) : UH6 =
    match v0 with
    | UH7_RemainderProofAlt(v24, v25, v26, v27) -> (* RemainderProofAlt *)
        let v28 : UH6 = derivative_remainder_proof_candidate_25(v26)
        let v29 : UH6 = derivative_remainder_proof_candidate_25(v27)
        UH6_RegexAlt(v28, v29)
    | UH7_RemainderProofCat(v31, v32, v33, v34, v35) -> (* RemainderProofCat *)
        let v36 : UH6 = derivative_remainder_proof_candidate_25(v34)
        let v37 : UH6 = derivative_remainder_proof_candidate_25(v35)
        let v38 : UH6 = derivative_remainder_proof_source_12(v35)
        match v33 with
        | US2_RemainderCatNonNullable -> (* RemainderCatNonNullable *)
            UH6_RegexCat(v36, v38)
        | US2_RemainderCatNullable -> (* RemainderCatNullable *)
            let v39 : UH6 = UH6_RegexCat(v36, v38)
            UH6_RegexAlt(v39, v37)
    | UH7_RemainderProofChar(v7, v8, v9) -> (* RemainderProofChar *)
        let v19 : US4 =
            match v7 with
            | US0_BitOne -> (* BitOne *)
                match v8 with
                | US0_BitOne -> (* BitOne *)
                    US4_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US4_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v8 with
                | US0_BitOne -> (* BitOne *)
                    US4_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US4_SymbolSame
        let v20 : bool =
            match v19 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v20 then
            UH6_RegexEpsilon
        else
            UH6_RegexEmpty
    | UH7_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        UH6_RegexEmpty
    | UH7_RemainderProofEpsilon(v4, v5) -> (* RemainderProofEpsilon *)
        UH6_RegexEmpty
    | UH7_RemainderProofStar(v44, v45, v46) -> (* RemainderProofStar *)
        let v47 : UH6 = derivative_remainder_proof_candidate_25(v46)
        let v48 : UH6 = derivative_remainder_proof_source_12(v46)
        let v49 : UH6 = UH6_RegexStar(v48)
        UH6_RegexCat(v47, v49)
and consume_right_28 (v0 : UH6, v1 : UH1) : UH1 =
    match v1 with
    | UH1_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH1 = language_remainders_27(v0, v3)
        let v6 : UH1 = consume_right_28(v0, v4)
        input_list_append_3(v5, v6)
    | UH1_InputListNil -> (* InputListNil *)
        UH1_InputListNil
and input_list_contains_31 (v0 : UH2, v1 : UH1) : bool =
    match v1 with
    | UH1_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_16(v0, v2)
        if v4 then
            true
        else
            input_list_contains_31(v0, v3)
    | UH1_InputListNil -> (* InputListNil *)
        false
and input_list_enqueue_new_30 (v0 : UH1, v1 : UH1, v2 : UH1) : struct (UH1 * UH1) =
    match v0 with
    | UH1_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_31(v3, v1)
        if v5 then
            input_list_enqueue_new_30(v4, v1, v2)
        else
            let v8 : UH1 = UH1_InputListCons(v3, v1)
            let v9 : UH1 = UH1_InputListCons(v3, v2)
            input_list_enqueue_new_30(v4, v8, v9)
    | UH1_InputListNil -> (* InputListNil *)
        struct (v1, v2)
and closure_29 (v0 : UH6, v1 : UH1, v2 : UH1) : UH1 =
    match v1 with
    | UH1_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH1 = language_remainders_27(v0, v3)
        let struct (v6 : UH1, v7 : UH1) = input_list_enqueue_new_30(v5, v2, v4)
        closure_29(v0, v7, v6)
    | UH1_InputListNil -> (* InputListNil *)
        v2
and language_remainders_27 (v0 : UH6, v1 : UH2) : UH1 =
    match v0 with
    | UH6_RegexAlt(v26, v27) -> (* RegexAlt *)
        let v28 : UH1 = language_remainders_27(v26, v1)
        let v29 : UH1 = language_remainders_27(v27, v1)
        input_list_append_3(v28, v29)
    | UH6_RegexCat(v31, v32) -> (* RegexCat *)
        let v33 : UH1 = language_remainders_27(v31, v1)
        consume_right_28(v32, v33)
    | UH6_RegexChar(v5) -> (* RegexChar *)
        match v1 with
        | UH2_InputCons(v7, v8) -> (* InputCons *)
            let v18 : US4 =
                match v5 with
                | US0_BitOne -> (* BitOne *)
                    match v7 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v7 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolSame
            let v19 : bool =
                match v18 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH1 = UH1_InputListNil
                UH1_InputListCons(v8, v20)
            else
                UH1_InputListNil
        | UH2_InputEmpty -> (* InputEmpty *)
            UH1_InputListNil
    | UH6_RegexEmpty -> (* RegexEmpty *)
        UH1_InputListNil
    | UH6_RegexEpsilon -> (* RegexEpsilon *)
        let v3 : UH1 = UH1_InputListNil
        UH1_InputListCons(v1, v3)
    | UH6_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH1 = UH1_InputListNil
        let v37 : UH1 = UH1_InputListCons(v1, v36)
        let v38 : UH1 = UH1_InputListNil
        let v39 : UH1 = UH1_InputListCons(v1, v38)
        closure_29(v35, v37, v39)
and input_list_remove_32 (v0 : UH2, v1 : UH1) : UH1 =
    match v1 with
    | UH1_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_equal_16(v0, v3)
        if v5 then
            input_list_remove_32(v0, v4)
        else
            let v7 : UH1 = input_list_remove_32(v0, v4)
            UH1_InputListCons(v3, v7)
    | UH1_InputListNil -> (* InputListNil *)
        UH1_InputListNil
and input_list_subset_33 (v0 : UH1, v1 : UH1) : bool =
    match v0 with
    | UH1_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_list_contains_31(v2, v1)
        if v4 then
            input_list_subset_33(v3, v1)
        else
            false
    | UH1_InputListNil -> (* InputListNil *)
        true
and derivative_remainder_proof_valid_26 (v0 : UH7) : bool =
    let v1 : UH6 = derivative_remainder_proof_source_12(v0)
    let v2 : US0 = derivative_remainder_proof_symbol_14(v0)
    let v3 : UH2 = derivative_remainder_proof_suffix_15(v0)
    let v4 : UH6 = derivative_remainder_proof_candidate_25(v0)
    let v5 : UH2 = UH2_InputCons(v2, v3)
    let v6 : UH2 = UH2_InputCons(v2, v3)
    let v7 : UH1 = language_remainders_27(v1, v6)
    let v8 : UH1 = input_list_remove_32(v5, v7)
    let v9 : UH1 = language_remainders_27(v4, v3)
    let v10 : bool = input_list_subset_33(v8, v9)
    let v12 : bool =
        if v10 then
            input_list_subset_33(v9, v8)
        else
            false
    if v12 then
        match v0 with
        | UH7_RemainderProofAlt(v20, v21, v22, v23) -> (* RemainderProofAlt *)
            let v24 : US0 = derivative_remainder_proof_symbol_14(v0)
            let v25 : US0 = derivative_remainder_proof_symbol_14(v22)
            let v35 : US4 =
                match v24 with
                | US0_BitOne -> (* BitOne *)
                    match v25 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v25 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolSame
            let v36 : bool =
                match v35 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v40 : bool =
                if v36 then
                    let v37 : UH2 = derivative_remainder_proof_suffix_15(v0)
                    let v38 : UH2 = derivative_remainder_proof_suffix_15(v22)
                    input_equal_16(v37, v38)
                else
                    false
            if v40 then
                let v41 : US0 = derivative_remainder_proof_symbol_14(v0)
                let v42 : US0 = derivative_remainder_proof_symbol_14(v23)
                let v52 : US4 =
                    match v41 with
                    | US0_BitOne -> (* BitOne *)
                        match v42 with
                        | US0_BitOne -> (* BitOne *)
                            US4_SymbolSame
                        | US0_BitZero -> (* BitZero *)
                            US4_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        match v42 with
                        | US0_BitOne -> (* BitOne *)
                            US4_SymbolLess
                        | US0_BitZero -> (* BitZero *)
                            US4_SymbolSame
                let v53 : bool =
                    match v52 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v57 : bool =
                    if v53 then
                        let v54 : UH2 = derivative_remainder_proof_suffix_15(v0)
                        let v55 : UH2 = derivative_remainder_proof_suffix_15(v23)
                        input_equal_16(v54, v55)
                    else
                        false
                if v57 then
                    let v58 : bool = derivative_remainder_proof_valid_26(v22)
                    if v58 then
                        derivative_remainder_proof_valid_26(v23)
                    else
                        false
                else
                    false
            else
                false
        | UH7_RemainderProofCat(v63, v64, v65, v66, v67) -> (* RemainderProofCat *)
            let v68 : UH6 = derivative_remainder_proof_source_12(v66)
            let v69 : US3 = nullable_11(v68)
            let v73 : US2 =
                match v69 with
                | US3_NonNullable -> (* NonNullable *)
                    US2_RemainderCatNonNullable
                | US3_Nullable -> (* Nullable *)
                    US2_RemainderCatNullable
            let v77 : bool =
                match v65 with
                | US2_RemainderCatNonNullable -> (* RemainderCatNonNullable *)
                    match v73 with
                    | US2_RemainderCatNonNullable -> (* RemainderCatNonNullable *)
                        true
                    | _ ->
                        false
                | US2_RemainderCatNullable -> (* RemainderCatNullable *)
                    match v73 with
                    | US2_RemainderCatNullable -> (* RemainderCatNullable *)
                        true
                    | _ ->
                        false
            if v77 then
                let v78 : US0 = derivative_remainder_proof_symbol_14(v0)
                let v79 : US0 = derivative_remainder_proof_symbol_14(v66)
                let v89 : US4 =
                    match v78 with
                    | US0_BitOne -> (* BitOne *)
                        match v79 with
                        | US0_BitOne -> (* BitOne *)
                            US4_SymbolSame
                        | US0_BitZero -> (* BitZero *)
                            US4_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        match v79 with
                        | US0_BitOne -> (* BitOne *)
                            US4_SymbolLess
                        | US0_BitZero -> (* BitZero *)
                            US4_SymbolSame
                let v90 : bool =
                    match v89 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v94 : bool =
                    if v90 then
                        let v91 : UH2 = derivative_remainder_proof_suffix_15(v0)
                        let v92 : UH2 = derivative_remainder_proof_suffix_15(v66)
                        input_equal_16(v91, v92)
                    else
                        false
                if v94 then
                    let v95 : US0 = derivative_remainder_proof_symbol_14(v0)
                    let v96 : US0 = derivative_remainder_proof_symbol_14(v67)
                    let v106 : US4 =
                        match v95 with
                        | US0_BitOne -> (* BitOne *)
                            match v96 with
                            | US0_BitOne -> (* BitOne *)
                                US4_SymbolSame
                            | US0_BitZero -> (* BitZero *)
                                US4_SymbolGreater
                        | US0_BitZero -> (* BitZero *)
                            match v96 with
                            | US0_BitOne -> (* BitOne *)
                                US4_SymbolLess
                            | US0_BitZero -> (* BitZero *)
                                US4_SymbolSame
                    let v107 : bool =
                        match v106 with
                        | US4_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    let v111 : bool =
                        if v107 then
                            let v108 : UH2 = derivative_remainder_proof_suffix_15(v0)
                            let v109 : UH2 = derivative_remainder_proof_suffix_15(v67)
                            input_equal_16(v108, v109)
                        else
                            false
                    if v111 then
                        let v112 : bool = derivative_remainder_proof_valid_26(v66)
                        if v112 then
                            derivative_remainder_proof_valid_26(v67)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        | UH7_RemainderProofChar(v17, v18, v19) -> (* RemainderProofChar *)
            true
        | UH7_RemainderProofEmpty(v13, v14) -> (* RemainderProofEmpty *)
            true
        | UH7_RemainderProofEpsilon(v15, v16) -> (* RemainderProofEpsilon *)
            true
        | UH7_RemainderProofStar(v118, v119, v120) -> (* RemainderProofStar *)
            let v121 : US0 = derivative_remainder_proof_symbol_14(v0)
            let v122 : US0 = derivative_remainder_proof_symbol_14(v120)
            let v132 : US4 =
                match v121 with
                | US0_BitOne -> (* BitOne *)
                    match v122 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v122 with
                    | US0_BitOne -> (* BitOne *)
                        US4_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US4_SymbolSame
            let v133 : bool =
                match v132 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v137 : bool =
                if v133 then
                    let v134 : UH2 = derivative_remainder_proof_suffix_15(v0)
                    let v135 : UH2 = derivative_remainder_proof_suffix_15(v120)
                    input_equal_16(v134, v135)
                else
                    false
            if v137 then
                derivative_remainder_proof_valid_26(v120)
            else
                false
    else
        false
and derivative_remainder_theorem_suffixes_9 (v0 : UH6, v1 : US0, v2 : UH1) : bool =
    match v2 with
    | UH1_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = derivative_remainder_proof_make_10(v0, v1, v3)
        let v6 : UH6 = derivative_remainder_proof_source_12(v5)
        let v7 : bool = regex_equal_13(v0, v6)
        let v30 : bool =
            if v7 then
                let v8 : US0 = derivative_remainder_proof_symbol_14(v5)
                let v18 : US4 =
                    match v1 with
                    | US0_BitOne -> (* BitOne *)
                        match v8 with
                        | US0_BitOne -> (* BitOne *)
                            US4_SymbolSame
                        | US0_BitZero -> (* BitZero *)
                            US4_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        match v8 with
                        | US0_BitOne -> (* BitOne *)
                            US4_SymbolLess
                        | US0_BitZero -> (* BitZero *)
                            US4_SymbolSame
                let v19 : bool =
                    match v18 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v19 then
                    let v20 : UH2 = derivative_remainder_proof_suffix_15(v5)
                    let v21 : bool = input_equal_16(v3, v20)
                    if v21 then
                        let v22 : UH6 = canonical_derivative_17(v0, v1)
                        let v23 : UH6 = derivative_remainder_proof_candidate_25(v5)
                        let v24 : UH6 = normalize_18(v23)
                        let v25 : bool = regex_equal_13(v22, v24)
                        if v25 then
                            derivative_remainder_proof_valid_26(v5)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v30 then
            derivative_remainder_theorem_suffixes_9(v0, v1, v4)
        else
            false
    | UH1_InputListNil -> (* InputListNil *)
        true
and derivative_remainder_theorem_symbols_8 (v0 : UH6, v1 : UH0, v2 : UH1) : bool =
    match v1 with
    | UH0_SymbolListCons(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = derivative_remainder_theorem_suffixes_9(v0, v3, v2)
        if v5 then
            derivative_remainder_theorem_symbols_8(v0, v4, v2)
        else
            false
    | UH0_SymbolListNil -> (* SymbolListNil *)
        true
and nullable_37 (v0 : UH8) : US3 =
    match v0 with
    | UH8_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_37(v5)
        let v8 : US3 = nullable_37(v6)
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
        let v18 : US3 = nullable_37(v16)
        let v19 : US3 = nullable_37(v17)
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
and derivative_remainder_proof_make_36 (v0 : UH8, v1 : US1, v2 : UH5) : UH9 =
    match v0 with
    | UH8_RegexAlt(v7, v8) -> (* RegexAlt *)
        let v9 : UH9 = derivative_remainder_proof_make_36(v7, v1, v2)
        let v10 : UH9 = derivative_remainder_proof_make_36(v8, v1, v2)
        UH9_RemainderProofAlt(v1, v2, v9, v10)
    | UH8_RegexCat(v12, v13) -> (* RegexCat *)
        let v14 : US3 = nullable_37(v12)
        let v18 : US2 =
            match v14 with
            | US3_NonNullable -> (* NonNullable *)
                US2_RemainderCatNonNullable
            | US3_Nullable -> (* Nullable *)
                US2_RemainderCatNullable
        let v19 : UH9 = derivative_remainder_proof_make_36(v12, v1, v2)
        let v20 : UH9 = derivative_remainder_proof_make_36(v13, v1, v2)
        UH9_RemainderProofCat(v1, v2, v18, v19, v20)
    | UH8_RegexChar(v5) -> (* RegexChar *)
        UH9_RemainderProofChar(v5, v1, v2)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH9_RemainderProofEmpty(v1, v2)
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH9_RemainderProofEpsilon(v1, v2)
    | UH8_RegexStar(v22) -> (* RegexStar *)
        let v23 : UH9 = derivative_remainder_proof_make_36(v22, v1, v2)
        UH9_RemainderProofStar(v1, v2, v23)
and derivative_remainder_proof_source_38 (v0 : UH9) : UH8 =
    match v0 with
    | UH9_RemainderProofAlt(v11, v12, v13, v14) -> (* RemainderProofAlt *)
        let v15 : UH8 = derivative_remainder_proof_source_38(v13)
        let v16 : UH8 = derivative_remainder_proof_source_38(v14)
        UH8_RegexAlt(v15, v16)
    | UH9_RemainderProofCat(v18, v19, v20, v21, v22) -> (* RemainderProofCat *)
        let v23 : UH8 = derivative_remainder_proof_source_38(v21)
        let v24 : UH8 = derivative_remainder_proof_source_38(v22)
        UH8_RegexCat(v23, v24)
    | UH9_RemainderProofChar(v7, v8, v9) -> (* RemainderProofChar *)
        UH8_RegexChar(v7)
    | UH9_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        UH8_RegexEmpty
    | UH9_RemainderProofEpsilon(v4, v5) -> (* RemainderProofEpsilon *)
        UH8_RegexEpsilon
    | UH9_RemainderProofStar(v26, v27, v28) -> (* RemainderProofStar *)
        let v29 : UH8 = derivative_remainder_proof_source_38(v28)
        UH8_RegexStar(v29)
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
            regex_equal_39(v40, v41)
        | _ ->
            false
and derivative_remainder_proof_symbol_40 (v0 : UH9) : US1 =
    match v0 with
    | UH9_RemainderProofAlt(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v8
    | UH9_RemainderProofCat(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v12
    | UH9_RemainderProofChar(v5, v6, v7) -> (* RemainderProofChar *)
        v6
    | UH9_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        v1
    | UH9_RemainderProofEpsilon(v3, v4) -> (* RemainderProofEpsilon *)
        v3
    | UH9_RemainderProofStar(v17, v18, v19) -> (* RemainderProofStar *)
        v17
and derivative_remainder_proof_suffix_41 (v0 : UH9) : UH5 =
    match v0 with
    | UH9_RemainderProofAlt(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v9
    | UH9_RemainderProofCat(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v13
    | UH9_RemainderProofChar(v5, v6, v7) -> (* RemainderProofChar *)
        v7
    | UH9_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        v2
    | UH9_RemainderProofEpsilon(v3, v4) -> (* RemainderProofEpsilon *)
        v4
    | UH9_RemainderProofStar(v17, v18, v19) -> (* RemainderProofStar *)
        v18
and input_equal_42 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_InputCons(v3, v4) -> (* InputCons *)
        match v1 with
        | UH5_InputCons(v5, v6) -> (* InputCons *)
            let v22 : US4 =
                match v3 with
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
                        match v3 with
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
            let v23 : bool =
                match v22 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                input_equal_42(v4, v6)
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
and regex_compare_47 (v0 : UH8, v1 : UH8) : US4 =
    match v0 with
    | UH8_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH8_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US4 = regex_compare_47(v59, v61)
            match v63 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_47(v60, v62)
            | _ ->
                v63
        | _ ->
            US4_SymbolGreater
    | UH8_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH8_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US4 = regex_compare_47(v34, v40)
            match v42 with
            | US4_SymbolSame -> (* SymbolSame *)
                regex_compare_47(v35, v41)
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
            regex_compare_47(v50, v54)
        | _ ->
            US4_SymbolGreater
and alt_insert_sorted_46 (v0 : UH8, v1 : UH8) : UH8 =
    match v1 with
    | UH8_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = regex_compare_47(v0, v2)
        match v4 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH8 = alt_insert_sorted_46(v0, v3)
            UH8_RegexAlt(v2, v6)
        | US4_SymbolLess -> (* SymbolLess *)
            UH8_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
    | UH8_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US4 = regex_compare_47(v0, v1)
        match v11 with
        | US4_SymbolGreater -> (* SymbolGreater *)
            UH8_RegexAlt(v1, v0)
        | US4_SymbolLess -> (* SymbolLess *)
            UH8_RegexAlt(v0, v1)
        | US4_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_45 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH8 = alt_insert_sorted_46(v2, v1)
        make_alt_45(v3, v4)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_46(v0, v1)
and make_cat_48 (v0 : UH8, v1 : UH8) : UH8 =
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
                        let v14 : UH8 = make_cat_48(v13, v1)
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
and make_star_49 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEpsilon
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEpsilon
    | UH8_RegexStar(v3) -> (* RegexStar *)
        UH8_RegexStar(v3)
    | _ ->
        UH8_RegexStar(v0)
and normalize_44 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH8 = normalize_44(v5)
        let v8 : UH8 = normalize_44(v6)
        make_alt_45(v7, v8)
    | UH8_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH8 = normalize_44(v10)
        let v13 : UH8 = normalize_44(v11)
        make_cat_48(v12, v13)
    | UH8_RegexChar(v3) -> (* RegexChar *)
        UH8_RegexChar(v3)
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH8_RegexEmpty
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        UH8_RegexEpsilon
    | UH8_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH8 = normalize_44(v15)
        make_star_49(v16)
and derivative_50 (v0 : UH8, v1 : US1) : UH8 =
    match v0 with
    | UH8_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH8 = derivative_50(v25, v1)
        let v28 : UH8 = derivative_50(v26, v1)
        make_alt_45(v27, v28)
    | UH8_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US3 = nullable_37(v30)
        match v32 with
        | US3_NonNullable -> (* NonNullable *)
            let v37 : UH8 = derivative_50(v30, v1)
            make_cat_48(v37, v31)
        | US3_Nullable -> (* Nullable *)
            let v33 : UH8 = derivative_50(v30, v1)
            let v34 : UH8 = make_cat_48(v33, v31)
            let v35 : UH8 = derivative_50(v31, v1)
            make_alt_45(v34, v35)
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
        let v42 : UH8 = derivative_50(v41, v1)
        let v43 : UH8 = make_star_49(v41)
        make_cat_48(v42, v43)
and canonical_derivative_43 (v0 : UH8, v1 : US1) : UH8 =
    let v2 : UH8 = normalize_44(v0)
    let v3 : UH8 = derivative_50(v2, v1)
    normalize_44(v3)
and derivative_remainder_proof_candidate_51 (v0 : UH9) : UH8 =
    match v0 with
    | UH9_RemainderProofAlt(v30, v31, v32, v33) -> (* RemainderProofAlt *)
        let v34 : UH8 = derivative_remainder_proof_candidate_51(v32)
        let v35 : UH8 = derivative_remainder_proof_candidate_51(v33)
        UH8_RegexAlt(v34, v35)
    | UH9_RemainderProofCat(v37, v38, v39, v40, v41) -> (* RemainderProofCat *)
        let v42 : UH8 = derivative_remainder_proof_candidate_51(v40)
        let v43 : UH8 = derivative_remainder_proof_candidate_51(v41)
        let v44 : UH8 = derivative_remainder_proof_source_38(v41)
        match v39 with
        | US2_RemainderCatNonNullable -> (* RemainderCatNonNullable *)
            UH8_RegexCat(v42, v44)
        | US2_RemainderCatNullable -> (* RemainderCatNullable *)
            let v45 : UH8 = UH8_RegexCat(v42, v44)
            UH8_RegexAlt(v45, v43)
    | UH9_RemainderProofChar(v7, v8, v9) -> (* RemainderProofChar *)
        let v25 : US4 =
            match v7 with
            | US1_TriA -> (* TriA *)
                match v8 with
                | US1_TriA -> (* TriA *)
                    US4_SymbolSame
                | _ ->
                    US4_SymbolLess
            | _ ->
                match v8 with
                | US1_TriA -> (* TriA *)
                    US4_SymbolGreater
                | _ ->
                    match v7 with
                    | US1_TriB -> (* TriB *)
                        match v8 with
                        | US1_TriB -> (* TriB *)
                            US4_SymbolSame
                        | US1_TriC -> (* TriC *)
                            US4_SymbolLess
                    | US1_TriC -> (* TriC *)
                        match v8 with
                        | US1_TriB -> (* TriB *)
                            US4_SymbolGreater
                        | US1_TriC -> (* TriC *)
                            US4_SymbolSame
        let v26 : bool =
            match v25 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v26 then
            UH8_RegexEpsilon
        else
            UH8_RegexEmpty
    | UH9_RemainderProofEmpty(v1, v2) -> (* RemainderProofEmpty *)
        UH8_RegexEmpty
    | UH9_RemainderProofEpsilon(v4, v5) -> (* RemainderProofEpsilon *)
        UH8_RegexEmpty
    | UH9_RemainderProofStar(v50, v51, v52) -> (* RemainderProofStar *)
        let v53 : UH8 = derivative_remainder_proof_candidate_51(v52)
        let v54 : UH8 = derivative_remainder_proof_source_38(v52)
        let v55 : UH8 = UH8_RegexStar(v54)
        UH8_RegexCat(v53, v55)
and consume_right_54 (v0 : UH8, v1 : UH4) : UH4 =
    match v1 with
    | UH4_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = language_remainders_53(v0, v3)
        let v6 : UH4 = consume_right_54(v0, v4)
        input_list_append_7(v5, v6)
    | UH4_InputListNil -> (* InputListNil *)
        UH4_InputListNil
and input_list_contains_57 (v0 : UH5, v1 : UH4) : bool =
    match v1 with
    | UH4_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_42(v0, v2)
        if v4 then
            true
        else
            input_list_contains_57(v0, v3)
    | UH4_InputListNil -> (* InputListNil *)
        false
and input_list_enqueue_new_56 (v0 : UH4, v1 : UH4, v2 : UH4) : struct (UH4 * UH4) =
    match v0 with
    | UH4_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_57(v3, v1)
        if v5 then
            input_list_enqueue_new_56(v4, v1, v2)
        else
            let v8 : UH4 = UH4_InputListCons(v3, v1)
            let v9 : UH4 = UH4_InputListCons(v3, v2)
            input_list_enqueue_new_56(v4, v8, v9)
    | UH4_InputListNil -> (* InputListNil *)
        struct (v1, v2)
and closure_55 (v0 : UH8, v1 : UH4, v2 : UH4) : UH4 =
    match v1 with
    | UH4_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = language_remainders_53(v0, v3)
        let struct (v6 : UH4, v7 : UH4) = input_list_enqueue_new_56(v5, v2, v4)
        closure_55(v0, v7, v6)
    | UH4_InputListNil -> (* InputListNil *)
        v2
and language_remainders_53 (v0 : UH8, v1 : UH5) : UH4 =
    match v0 with
    | UH8_RegexAlt(v32, v33) -> (* RegexAlt *)
        let v34 : UH4 = language_remainders_53(v32, v1)
        let v35 : UH4 = language_remainders_53(v33, v1)
        input_list_append_7(v34, v35)
    | UH8_RegexCat(v37, v38) -> (* RegexCat *)
        let v39 : UH4 = language_remainders_53(v37, v1)
        consume_right_54(v38, v39)
    | UH8_RegexChar(v5) -> (* RegexChar *)
        match v1 with
        | UH5_InputCons(v7, v8) -> (* InputCons *)
            let v24 : US4 =
                match v5 with
                | US1_TriA -> (* TriA *)
                    match v7 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolSame
                    | _ ->
                        US4_SymbolLess
                | _ ->
                    match v7 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolGreater
                    | _ ->
                        match v5 with
                        | US1_TriB -> (* TriB *)
                            match v7 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolSame
                            | US1_TriC -> (* TriC *)
                                US4_SymbolLess
                        | US1_TriC -> (* TriC *)
                            match v7 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolGreater
                            | US1_TriC -> (* TriC *)
                                US4_SymbolSame
            let v25 : bool =
                match v24 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH4 = UH4_InputListNil
                UH4_InputListCons(v8, v26)
            else
                UH4_InputListNil
        | UH5_InputEmpty -> (* InputEmpty *)
            UH4_InputListNil
    | UH8_RegexEmpty -> (* RegexEmpty *)
        UH4_InputListNil
    | UH8_RegexEpsilon -> (* RegexEpsilon *)
        let v3 : UH4 = UH4_InputListNil
        UH4_InputListCons(v1, v3)
    | UH8_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH4 = UH4_InputListNil
        let v43 : UH4 = UH4_InputListCons(v1, v42)
        let v44 : UH4 = UH4_InputListNil
        let v45 : UH4 = UH4_InputListCons(v1, v44)
        closure_55(v41, v43, v45)
and input_list_remove_58 (v0 : UH5, v1 : UH4) : UH4 =
    match v1 with
    | UH4_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_equal_42(v0, v3)
        if v5 then
            input_list_remove_58(v0, v4)
        else
            let v7 : UH4 = input_list_remove_58(v0, v4)
            UH4_InputListCons(v3, v7)
    | UH4_InputListNil -> (* InputListNil *)
        UH4_InputListNil
and input_list_subset_59 (v0 : UH4, v1 : UH4) : bool =
    match v0 with
    | UH4_InputListCons(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_list_contains_57(v2, v1)
        if v4 then
            input_list_subset_59(v3, v1)
        else
            false
    | UH4_InputListNil -> (* InputListNil *)
        true
and derivative_remainder_proof_valid_52 (v0 : UH9) : bool =
    let v1 : UH8 = derivative_remainder_proof_source_38(v0)
    let v2 : US1 = derivative_remainder_proof_symbol_40(v0)
    let v3 : UH5 = derivative_remainder_proof_suffix_41(v0)
    let v4 : UH8 = derivative_remainder_proof_candidate_51(v0)
    let v5 : UH5 = UH5_InputCons(v2, v3)
    let v6 : UH5 = UH5_InputCons(v2, v3)
    let v7 : UH4 = language_remainders_53(v1, v6)
    let v8 : UH4 = input_list_remove_58(v5, v7)
    let v9 : UH4 = language_remainders_53(v4, v3)
    let v10 : bool = input_list_subset_59(v8, v9)
    let v12 : bool =
        if v10 then
            input_list_subset_59(v9, v8)
        else
            false
    if v12 then
        match v0 with
        | UH9_RemainderProofAlt(v20, v21, v22, v23) -> (* RemainderProofAlt *)
            let v24 : US1 = derivative_remainder_proof_symbol_40(v0)
            let v25 : US1 = derivative_remainder_proof_symbol_40(v22)
            let v41 : US4 =
                match v24 with
                | US1_TriA -> (* TriA *)
                    match v25 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolSame
                    | _ ->
                        US4_SymbolLess
                | _ ->
                    match v25 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolGreater
                    | _ ->
                        match v24 with
                        | US1_TriB -> (* TriB *)
                            match v25 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolSame
                            | US1_TriC -> (* TriC *)
                                US4_SymbolLess
                        | US1_TriC -> (* TriC *)
                            match v25 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolGreater
                            | US1_TriC -> (* TriC *)
                                US4_SymbolSame
            let v42 : bool =
                match v41 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v46 : bool =
                if v42 then
                    let v43 : UH5 = derivative_remainder_proof_suffix_41(v0)
                    let v44 : UH5 = derivative_remainder_proof_suffix_41(v22)
                    input_equal_42(v43, v44)
                else
                    false
            if v46 then
                let v47 : US1 = derivative_remainder_proof_symbol_40(v0)
                let v48 : US1 = derivative_remainder_proof_symbol_40(v23)
                let v64 : US4 =
                    match v47 with
                    | US1_TriA -> (* TriA *)
                        match v48 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolSame
                        | _ ->
                            US4_SymbolLess
                    | _ ->
                        match v48 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolGreater
                        | _ ->
                            match v47 with
                            | US1_TriB -> (* TriB *)
                                match v48 with
                                | US1_TriB -> (* TriB *)
                                    US4_SymbolSame
                                | US1_TriC -> (* TriC *)
                                    US4_SymbolLess
                            | US1_TriC -> (* TriC *)
                                match v48 with
                                | US1_TriB -> (* TriB *)
                                    US4_SymbolGreater
                                | US1_TriC -> (* TriC *)
                                    US4_SymbolSame
                let v65 : bool =
                    match v64 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v69 : bool =
                    if v65 then
                        let v66 : UH5 = derivative_remainder_proof_suffix_41(v0)
                        let v67 : UH5 = derivative_remainder_proof_suffix_41(v23)
                        input_equal_42(v66, v67)
                    else
                        false
                if v69 then
                    let v70 : bool = derivative_remainder_proof_valid_52(v22)
                    if v70 then
                        derivative_remainder_proof_valid_52(v23)
                    else
                        false
                else
                    false
            else
                false
        | UH9_RemainderProofCat(v75, v76, v77, v78, v79) -> (* RemainderProofCat *)
            let v80 : UH8 = derivative_remainder_proof_source_38(v78)
            let v81 : US3 = nullable_37(v80)
            let v85 : US2 =
                match v81 with
                | US3_NonNullable -> (* NonNullable *)
                    US2_RemainderCatNonNullable
                | US3_Nullable -> (* Nullable *)
                    US2_RemainderCatNullable
            let v89 : bool =
                match v77 with
                | US2_RemainderCatNonNullable -> (* RemainderCatNonNullable *)
                    match v85 with
                    | US2_RemainderCatNonNullable -> (* RemainderCatNonNullable *)
                        true
                    | _ ->
                        false
                | US2_RemainderCatNullable -> (* RemainderCatNullable *)
                    match v85 with
                    | US2_RemainderCatNullable -> (* RemainderCatNullable *)
                        true
                    | _ ->
                        false
            if v89 then
                let v90 : US1 = derivative_remainder_proof_symbol_40(v0)
                let v91 : US1 = derivative_remainder_proof_symbol_40(v78)
                let v107 : US4 =
                    match v90 with
                    | US1_TriA -> (* TriA *)
                        match v91 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolSame
                        | _ ->
                            US4_SymbolLess
                    | _ ->
                        match v91 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolGreater
                        | _ ->
                            match v90 with
                            | US1_TriB -> (* TriB *)
                                match v91 with
                                | US1_TriB -> (* TriB *)
                                    US4_SymbolSame
                                | US1_TriC -> (* TriC *)
                                    US4_SymbolLess
                            | US1_TriC -> (* TriC *)
                                match v91 with
                                | US1_TriB -> (* TriB *)
                                    US4_SymbolGreater
                                | US1_TriC -> (* TriC *)
                                    US4_SymbolSame
                let v108 : bool =
                    match v107 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v112 : bool =
                    if v108 then
                        let v109 : UH5 = derivative_remainder_proof_suffix_41(v0)
                        let v110 : UH5 = derivative_remainder_proof_suffix_41(v78)
                        input_equal_42(v109, v110)
                    else
                        false
                if v112 then
                    let v113 : US1 = derivative_remainder_proof_symbol_40(v0)
                    let v114 : US1 = derivative_remainder_proof_symbol_40(v79)
                    let v130 : US4 =
                        match v113 with
                        | US1_TriA -> (* TriA *)
                            match v114 with
                            | US1_TriA -> (* TriA *)
                                US4_SymbolSame
                            | _ ->
                                US4_SymbolLess
                        | _ ->
                            match v114 with
                            | US1_TriA -> (* TriA *)
                                US4_SymbolGreater
                            | _ ->
                                match v113 with
                                | US1_TriB -> (* TriB *)
                                    match v114 with
                                    | US1_TriB -> (* TriB *)
                                        US4_SymbolSame
                                    | US1_TriC -> (* TriC *)
                                        US4_SymbolLess
                                | US1_TriC -> (* TriC *)
                                    match v114 with
                                    | US1_TriB -> (* TriB *)
                                        US4_SymbolGreater
                                    | US1_TriC -> (* TriC *)
                                        US4_SymbolSame
                    let v131 : bool =
                        match v130 with
                        | US4_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    let v135 : bool =
                        if v131 then
                            let v132 : UH5 = derivative_remainder_proof_suffix_41(v0)
                            let v133 : UH5 = derivative_remainder_proof_suffix_41(v79)
                            input_equal_42(v132, v133)
                        else
                            false
                    if v135 then
                        let v136 : bool = derivative_remainder_proof_valid_52(v78)
                        if v136 then
                            derivative_remainder_proof_valid_52(v79)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        | UH9_RemainderProofChar(v17, v18, v19) -> (* RemainderProofChar *)
            true
        | UH9_RemainderProofEmpty(v13, v14) -> (* RemainderProofEmpty *)
            true
        | UH9_RemainderProofEpsilon(v15, v16) -> (* RemainderProofEpsilon *)
            true
        | UH9_RemainderProofStar(v142, v143, v144) -> (* RemainderProofStar *)
            let v145 : US1 = derivative_remainder_proof_symbol_40(v0)
            let v146 : US1 = derivative_remainder_proof_symbol_40(v144)
            let v162 : US4 =
                match v145 with
                | US1_TriA -> (* TriA *)
                    match v146 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolSame
                    | _ ->
                        US4_SymbolLess
                | _ ->
                    match v146 with
                    | US1_TriA -> (* TriA *)
                        US4_SymbolGreater
                    | _ ->
                        match v145 with
                        | US1_TriB -> (* TriB *)
                            match v146 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolSame
                            | US1_TriC -> (* TriC *)
                                US4_SymbolLess
                        | US1_TriC -> (* TriC *)
                            match v146 with
                            | US1_TriB -> (* TriB *)
                                US4_SymbolGreater
                            | US1_TriC -> (* TriC *)
                                US4_SymbolSame
            let v163 : bool =
                match v162 with
                | US4_SymbolSame -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v167 : bool =
                if v163 then
                    let v164 : UH5 = derivative_remainder_proof_suffix_41(v0)
                    let v165 : UH5 = derivative_remainder_proof_suffix_41(v144)
                    input_equal_42(v164, v165)
                else
                    false
            if v167 then
                derivative_remainder_proof_valid_52(v144)
            else
                false
    else
        false
and derivative_remainder_theorem_suffixes_35 (v0 : UH8, v1 : US1, v2 : UH4) : bool =
    match v2 with
    | UH4_InputListCons(v3, v4) -> (* InputListCons *)
        let v5 : UH9 = derivative_remainder_proof_make_36(v0, v1, v3)
        let v6 : UH8 = derivative_remainder_proof_source_38(v5)
        let v7 : bool = regex_equal_39(v0, v6)
        let v36 : bool =
            if v7 then
                let v8 : US1 = derivative_remainder_proof_symbol_40(v5)
                let v24 : US4 =
                    match v1 with
                    | US1_TriA -> (* TriA *)
                        match v8 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolSame
                        | _ ->
                            US4_SymbolLess
                    | _ ->
                        match v8 with
                        | US1_TriA -> (* TriA *)
                            US4_SymbolGreater
                        | _ ->
                            match v1 with
                            | US1_TriB -> (* TriB *)
                                match v8 with
                                | US1_TriB -> (* TriB *)
                                    US4_SymbolSame
                                | US1_TriC -> (* TriC *)
                                    US4_SymbolLess
                            | US1_TriC -> (* TriC *)
                                match v8 with
                                | US1_TriB -> (* TriB *)
                                    US4_SymbolGreater
                                | US1_TriC -> (* TriC *)
                                    US4_SymbolSame
                let v25 : bool =
                    match v24 with
                    | US4_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v25 then
                    let v26 : UH5 = derivative_remainder_proof_suffix_41(v5)
                    let v27 : bool = input_equal_42(v3, v26)
                    if v27 then
                        let v28 : UH8 = canonical_derivative_43(v0, v1)
                        let v29 : UH8 = derivative_remainder_proof_candidate_51(v5)
                        let v30 : UH8 = normalize_44(v29)
                        let v31 : bool = regex_equal_39(v28, v30)
                        if v31 then
                            derivative_remainder_proof_valid_52(v5)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v36 then
            derivative_remainder_theorem_suffixes_35(v0, v1, v4)
        else
            false
    | UH4_InputListNil -> (* InputListNil *)
        true
and derivative_remainder_theorem_symbols_34 (v0 : UH8, v1 : UH3, v2 : UH4) : bool =
    match v1 with
    | UH3_SymbolListCons(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = derivative_remainder_theorem_suffixes_35(v0, v3, v2)
        if v5 then
            derivative_remainder_theorem_symbols_34(v0, v4, v2)
        else
            false
    | UH3_SymbolListNil -> (* SymbolListNil *)
        true
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
let v48 : UH6 = UH6_RegexEmpty
let v49 : UH6 = UH6_RegexEpsilon
let v50 : US0 = US0_BitZero
let v51 : UH6 = UH6_RegexChar(v50)
let v52 : US0 = US0_BitOne
let v53 : UH6 = UH6_RegexChar(v52)
let v54 : UH6 = UH6_RegexAlt(v51, v53)
let v55 : UH6 = UH6_RegexStar(v54)
let v56 : US0 = US0_BitZero
let v57 : UH6 = UH6_RegexChar(v56)
let v58 : UH6 = UH6_RegexCat(v55, v57)
let v59 : UH6 = UH6_RegexAlt(v49, v58)
let v60 : UH6 = UH6_RegexAlt(v48, v59)
let v61 : US0 = US0_BitZero
let v62 : US0 = US0_BitOne
let v63 : UH0 = UH0_SymbolListNil
let v64 : UH0 = UH0_SymbolListCons(v62, v63)
let v65 : UH0 = UH0_SymbolListCons(v61, v64)
let v66 : bool = derivative_remainder_theorem_symbols_8(v60, v65, v20)
if v66 then
    ()
else
    failwith<unit> "structural remainder theorem certificate should cover every regex constructor"
let v67 : US1 = US1_TriA
let v68 : UH8 = UH8_RegexChar(v67)
let v69 : US1 = US1_TriB
let v70 : UH8 = UH8_RegexChar(v69)
let v71 : UH8 = UH8_RegexAlt(v68, v70)
let v72 : UH8 = UH8_RegexStar(v71)
let v73 : US1 = US1_TriC
let v74 : UH8 = UH8_RegexChar(v73)
let v75 : UH8 = UH8_RegexCat(v72, v74)
let v76 : US1 = US1_TriA
let v77 : US1 = US1_TriB
let v78 : US1 = US1_TriC
let v79 : UH3 = UH3_SymbolListNil
let v80 : UH3 = UH3_SymbolListCons(v78, v79)
let v81 : UH3 = UH3_SymbolListCons(v77, v80)
let v82 : UH3 = UH3_SymbolListCons(v76, v81)
let v83 : bool = derivative_remainder_theorem_symbols_34(v75, v82, v47)
if v83 then
    ()
else
    failwith<unit> "structural remainder theorem certificate should generalize across nominal alphabets"
let v84 : US0 = US0_BitZero
let v85 : UH6 = UH6_RegexChar(v84)
let v86 : US0 = US0_BitOne
let v87 : UH6 = UH6_RegexChar(v86)
let v88 : UH6 = UH6_RegexAlt(v85, v87)
let v89 : UH6 = UH6_RegexStar(v88)
let v90 : US0 = US0_BitZero
let v91 : UH6 = UH6_RegexChar(v90)
let v92 : UH6 = UH6_RegexCat(v89, v91)
let v93 : US0 = US0_BitOne
let v94 : US0 = US0_BitOne
let v95 : US0 = US0_BitZero
let v96 : UH2 = UH2_InputEmpty
let v97 : UH2 = UH2_InputCons(v95, v96)
let v98 : UH2 = UH2_InputCons(v94, v97)
let v99 : UH7 = derivative_remainder_proof_make_10(v92, v93, v98)
let v100 : US0 = US0_BitZero
let v101 : UH6 = UH6_RegexChar(v100)
let v102 : US0 = US0_BitOne
let v103 : UH6 = UH6_RegexChar(v102)
let v104 : UH6 = UH6_RegexAlt(v101, v103)
let v105 : UH6 = UH6_RegexStar(v104)
let v106 : US0 = US0_BitZero
let v107 : UH6 = UH6_RegexChar(v106)
let v108 : UH6 = UH6_RegexCat(v105, v107)
let v109 : UH6 = derivative_remainder_proof_source_12(v99)
let v110 : bool = regex_equal_13(v108, v109)
let v142 : bool =
    if v110 then
        let v111 : US0 = derivative_remainder_proof_symbol_14(v99)
        let v115 : US4 =
            match v111 with
            | US0_BitOne -> (* BitOne *)
                US4_SymbolSame
            | US0_BitZero -> (* BitZero *)
                US4_SymbolGreater
        let v116 : bool =
            match v115 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v116 then
            let v117 : US0 = US0_BitOne
            let v118 : US0 = US0_BitZero
            let v119 : UH2 = UH2_InputEmpty
            let v120 : UH2 = UH2_InputCons(v118, v119)
            let v121 : UH2 = UH2_InputCons(v117, v120)
            let v122 : UH2 = derivative_remainder_proof_suffix_15(v99)
            let v123 : bool = input_equal_16(v121, v122)
            if v123 then
                let v124 : US0 = US0_BitZero
                let v125 : UH6 = UH6_RegexChar(v124)
                let v126 : US0 = US0_BitOne
                let v127 : UH6 = UH6_RegexChar(v126)
                let v128 : UH6 = UH6_RegexAlt(v125, v127)
                let v129 : UH6 = UH6_RegexStar(v128)
                let v130 : US0 = US0_BitZero
                let v131 : UH6 = UH6_RegexChar(v130)
                let v132 : UH6 = UH6_RegexCat(v129, v131)
                let v133 : US0 = US0_BitOne
                let v134 : UH6 = canonical_derivative_17(v132, v133)
                let v135 : UH6 = derivative_remainder_proof_candidate_25(v99)
                let v136 : UH6 = normalize_18(v135)
                let v137 : bool = regex_equal_13(v134, v136)
                if v137 then
                    derivative_remainder_proof_valid_26(v99)
                else
                    false
            else
                false
        else
            false
    else
        false
if v142 then
    ()
else
    failwith<unit> "well-formed derivative remainder theorem certificate should validate"
let v143 : UH2 = UH2_InputEmpty
let v144 : US0 = US0_BitZero
let v145 : UH6 = UH6_RegexChar(v144)
let v146 : UH6 = UH6_RegexStar(v145)
let v147 : US0 = US0_BitZero
let v148 : US0 = US0_BitOne
let v149 : UH2 = UH2_InputEmpty
let v150 : UH2 = UH2_InputCons(v148, v149)
let v151 : UH2 = UH2_InputCons(v147, v150)
let v152 : UH1 = language_remainders_27(v146, v151)
let v153 : bool = input_list_contains_31(v143, v152)
let v154 : UH2 = UH2_InputEmpty
let v155 : UH6 = UH6_RegexEmpty
let v156 : US0 = US0_BitOne
let v157 : UH2 = UH2_InputEmpty
let v158 : UH2 = UH2_InputCons(v156, v157)
let v159 : UH1 = language_remainders_27(v155, v158)
let v160 : bool = input_list_contains_31(v154, v159)
let v162 : bool =
    if v153 then
        v160
    else
        let v161 : bool = false = v160
        v161
if v162 then
    ()
else
    failwith<unit> "acceptance-only derivative law should miss a partial-remainder mutant when both decisions reject"
let v163 : US0 = US0_BitZero
let v164 : US0 = US0_BitOne
let v165 : UH2 = UH2_InputEmpty
let v166 : UH2 = UH2_InputCons(v164, v165)
let v167 : UH2 = UH2_InputCons(v163, v166)
let v168 : US0 = US0_BitZero
let v169 : UH6 = UH6_RegexChar(v168)
let v170 : UH6 = UH6_RegexStar(v169)
let v171 : US0 = US0_BitZero
let v172 : US0 = US0_BitOne
let v173 : UH2 = UH2_InputEmpty
let v174 : UH2 = UH2_InputCons(v172, v173)
let v175 : UH2 = UH2_InputCons(v171, v174)
let v176 : UH1 = language_remainders_27(v170, v175)
let v177 : UH1 = input_list_remove_32(v167, v176)
let v178 : UH6 = UH6_RegexEmpty
let v179 : US0 = US0_BitOne
let v180 : UH2 = UH2_InputEmpty
let v181 : UH2 = UH2_InputCons(v179, v180)
let v182 : UH1 = language_remainders_27(v178, v181)
let v183 : bool = input_list_subset_33(v177, v182)
let v185 : bool =
    if v183 then
        input_list_subset_33(v182, v177)
    else
        false
let v186 : bool = v185 = false
if v186 then
    ()
else
    failwith<unit> "remainder-set derivative law should reject the same partial-remainder mutant"
let v187 : US0 = US0_BitZero
let v188 : UH2 = UH2_InputEmpty
let v189 : US0 = US0_BitZero
let v190 : US0 = US0_BitZero
let v191 : UH2 = UH2_InputEmpty
let v192 : UH7 = UH7_RemainderProofChar(v189, v190, v191)
let v193 : US0 = US0_BitOne
let v194 : US0 = US0_BitOne
let v195 : UH2 = UH2_InputEmpty
let v196 : UH7 = UH7_RemainderProofChar(v193, v194, v195)
let v197 : UH7 = UH7_RemainderProofAlt(v187, v188, v192, v196)
let v198 : bool = derivative_remainder_proof_valid_26(v197)
let v199 : bool = v198 = false
if v199 then
    ()
else
    failwith<unit> "certificate validation should reject a child proof from a different derivative context"
let v200 : UH6 = UH6_RegexEpsilon
let v201 : US0 = US0_BitZero
let v202 : UH2 = UH2_InputEmpty
let v203 : UH7 = derivative_remainder_proof_make_10(v200, v201, v202)
let v204 : UH6 = UH6_RegexEmpty
let v205 : UH6 = derivative_remainder_proof_source_12(v203)
let v206 : bool = regex_equal_13(v204, v205)
let v226 : bool =
    if v206 then
        let v207 : US0 = derivative_remainder_proof_symbol_14(v203)
        let v211 : US4 =
            match v207 with
            | US0_BitOne -> (* BitOne *)
                US4_SymbolLess
            | US0_BitZero -> (* BitZero *)
                US4_SymbolSame
        let v212 : bool =
            match v211 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v212 then
            let v213 : UH2 = UH2_InputEmpty
            let v214 : UH2 = derivative_remainder_proof_suffix_15(v203)
            let v215 : bool = input_equal_16(v213, v214)
            if v215 then
                let v216 : UH6 = UH6_RegexEmpty
                let v217 : US0 = US0_BitZero
                let v218 : UH6 = canonical_derivative_17(v216, v217)
                let v219 : UH6 = derivative_remainder_proof_candidate_25(v203)
                let v220 : UH6 = normalize_18(v219)
                let v221 : bool = regex_equal_13(v218, v220)
                if v221 then
                    derivative_remainder_proof_valid_26(v203)
                else
                    false
            else
                false
        else
            false
    else
        false
let v227 : bool = v226 = false
if v227 then
    ()
else
    failwith<unit> "certificate validation should reject a forged source binding"
let v228 : US0 = US0_BitZero
let v229 : UH6 = UH6_RegexChar(v228)
let v230 : US0 = US0_BitZero
let v231 : UH2 = UH2_InputEmpty
let v232 : UH7 = derivative_remainder_proof_make_10(v229, v230, v231)
let v233 : US0 = US0_BitZero
let v234 : UH6 = UH6_RegexChar(v233)
let v235 : UH6 = derivative_remainder_proof_source_12(v232)
let v236 : bool = regex_equal_13(v234, v235)
let v257 : bool =
    if v236 then
        let v237 : US0 = derivative_remainder_proof_symbol_14(v232)
        let v241 : US4 =
            match v237 with
            | US0_BitOne -> (* BitOne *)
                US4_SymbolSame
            | US0_BitZero -> (* BitZero *)
                US4_SymbolGreater
        let v242 : bool =
            match v241 with
            | US4_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v242 then
            let v243 : UH2 = UH2_InputEmpty
            let v244 : UH2 = derivative_remainder_proof_suffix_15(v232)
            let v245 : bool = input_equal_16(v243, v244)
            if v245 then
                let v246 : US0 = US0_BitZero
                let v247 : UH6 = UH6_RegexChar(v246)
                let v248 : US0 = US0_BitOne
                let v249 : UH6 = canonical_derivative_17(v247, v248)
                let v250 : UH6 = derivative_remainder_proof_candidate_25(v232)
                let v251 : UH6 = normalize_18(v250)
                let v252 : bool = regex_equal_13(v249, v251)
                if v252 then
                    derivative_remainder_proof_valid_26(v232)
                else
                    false
            else
                false
        else
            false
    else
        false
let v258 : bool = v257 = false
if v258 then
    ()
else
    failwith<unit> "certificate validation should reject a forged symbol binding"
let v259 : UH6 = UH6_RegexEpsilon
let v260 : US0 = US0_BitZero
let v261 : UH2 = UH2_InputEmpty
let v262 : UH7 = derivative_remainder_proof_make_10(v259, v260, v261)
let v263 : US0 = US0_BitZero
let v264 : UH6 = UH6_RegexChar(v263)
let v265 : US0 = US0_BitZero
let v266 : UH2 = UH2_InputEmpty
let v267 : UH7 = derivative_remainder_proof_make_10(v264, v265, v266)
let v268 : US0 = US0_BitZero
let v269 : UH2 = UH2_InputEmpty
let v270 : US2 = US2_RemainderCatNonNullable
let v271 : UH7 = UH7_RemainderProofCat(v268, v269, v270, v262, v267)
let v272 : bool = derivative_remainder_proof_valid_26(v271)
let v273 : bool = v272 = false
if v273 then
    ()
else
    failwith<unit> "certificate validation should reject a forged nullable concatenation branch"
let v274 : string = "brzozowski-remainder-theorem-green"
v274
