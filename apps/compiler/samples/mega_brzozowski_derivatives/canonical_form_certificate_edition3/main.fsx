type [<Struct>] US0 =
    | US0_BitZero
    | US0_BitOne
and UH0 =
    | UH0_SymbolListNil
    | UH0_SymbolListCons of US0 * UH0
and UH2 =
    | UH2_RegexEmpty
    | UH2_RegexEpsilon
    | UH2_RegexChar of US0
    | UH2_RegexAlt of UH2 * UH2
    | UH2_RegexCat of UH2 * UH2
    | UH2_RegexStar of UH2
and UH1 =
    | UH1_RegexListNil
    | UH1_RegexListCons of UH2 * UH1
and [<Struct>] US1 =
    | US1_TriA
    | US1_TriB
    | US1_TriC
and UH3 =
    | UH3_SymbolListNil
    | UH3_SymbolListCons of US1 * UH3
and UH5 =
    | UH5_RegexEmpty
    | UH5_RegexEpsilon
    | UH5_RegexChar of US1
    | UH5_RegexAlt of UH5 * UH5
    | UH5_RegexCat of UH5 * UH5
    | UH5_RegexStar of UH5
and UH4 =
    | UH4_RegexListNil
    | UH4_RegexListCons of UH5 * UH4
and [<Struct>] US2 =
    | US2_SymbolLess
    | US2_SymbolSame
    | US2_SymbolGreater
and [<Struct>] US3 =
    | US3_Nullable
    | US3_NonNullable
let rec regex_chars_from_symbols_0 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH1 = regex_chars_from_symbols_0(v3)
        let v5 : UH2 = UH2_RegexChar(v2)
        UH1_RegexListCons(v5, v4)
    | UH0_SymbolListNil -> (* SymbolListNil *)
        UH1_RegexListNil
and regex_star_corpus_1 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = regex_star_corpus_1(v3)
        let v5 : UH2 = UH2_RegexStar(v2)
        UH1_RegexListCons(v5, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and regex_pairs_with_3 (v0 : UH2, v1 : UH1) : UH1 =
    match v1 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH1 = regex_pairs_with_3(v0, v4)
        let v6 : UH2 = UH2_RegexAlt(v0, v3)
        let v7 : UH2 = UH2_RegexCat(v0, v3)
        let v8 : UH1 = UH1_RegexListCons(v7, v5)
        UH1_RegexListCons(v6, v8)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and regex_list_append_4 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = regex_list_append_4(v3, v1)
        UH1_RegexListCons(v2, v4)
    | UH1_RegexListNil -> (* RegexListNil *)
        v1
and regex_binary_corpus_2 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH1 = regex_pairs_with_3(v3, v1)
        let v6 : UH1 = regex_binary_corpus_2(v4, v1)
        regex_list_append_4(v5, v6)
    | UH1_RegexListNil -> (* RegexListNil *)
        UH1_RegexListNil
and regex_chars_from_symbols_5 (v0 : UH3) : UH4 =
    match v0 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = regex_chars_from_symbols_5(v3)
        let v5 : UH5 = UH5_RegexChar(v2)
        UH4_RegexListCons(v5, v4)
    | UH3_SymbolListNil -> (* SymbolListNil *)
        UH4_RegexListNil
and regex_star_corpus_6 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = regex_star_corpus_6(v3)
        let v5 : UH5 = UH5_RegexStar(v2)
        UH4_RegexListCons(v5, v4)
    | UH4_RegexListNil -> (* RegexListNil *)
        UH4_RegexListNil
and regex_pairs_with_8 (v0 : UH5, v1 : UH4) : UH4 =
    match v1 with
    | UH4_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = regex_pairs_with_8(v0, v4)
        let v6 : UH5 = UH5_RegexAlt(v0, v3)
        let v7 : UH5 = UH5_RegexCat(v0, v3)
        let v8 : UH4 = UH4_RegexListCons(v7, v5)
        UH4_RegexListCons(v6, v8)
    | UH4_RegexListNil -> (* RegexListNil *)
        UH4_RegexListNil
and regex_list_append_9 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = regex_list_append_9(v3, v1)
        UH4_RegexListCons(v2, v4)
    | UH4_RegexListNil -> (* RegexListNil *)
        v1
and regex_binary_corpus_7 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_RegexListCons(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = regex_pairs_with_8(v3, v1)
        let v6 : UH4 = regex_binary_corpus_7(v4, v1)
        regex_list_append_9(v5, v6)
    | UH4_RegexListNil -> (* RegexListNil *)
        UH4_RegexListNil
and regex_compare_14 (v0 : UH2, v1 : UH2) : US2 =
    match v0 with
    | UH2_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US2 = regex_compare_14(v53, v55)
            match v57 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_14(v54, v56)
            | _ ->
                v57
        | _ ->
            US2_SymbolGreater
    | UH2_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US2 = regex_compare_14(v28, v34)
            match v36 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_14(v29, v35)
            | _ ->
                v36
        | UH2_RegexChar(v32) -> (* RegexChar *)
            US2_SymbolGreater
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolGreater
        | _ ->
            US2_SymbolLess
    | UH2_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH2_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US0_BitOne -> (* BitOne *)
                match v13 with
                | US0_BitOne -> (* BitOne *)
                    US2_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US2_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v13 with
                | US0_BitOne -> (* BitOne *)
                    US2_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US2_SymbolSame
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolGreater
        | _ ->
            US2_SymbolLess
    | UH2_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolSame
        | _ ->
            US2_SymbolLess
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolSame
        | _ ->
            US2_SymbolLess
    | UH2_RegexStar(v44) -> (* RegexStar *)
        match v1 with
        | UH2_RegexAlt(v45, v46) -> (* RegexAlt *)
            US2_SymbolLess
        | UH2_RegexStar(v48) -> (* RegexStar *)
            regex_compare_14(v44, v48)
        | _ ->
            US2_SymbolGreater
and alt_insert_sorted_13 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = regex_compare_14(v0, v2)
        match v4 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH2 = alt_insert_sorted_13(v0, v3)
            UH2_RegexAlt(v2, v6)
        | US2_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US2 = regex_compare_14(v0, v1)
        match v11 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            UH2_RegexAlt(v1, v0)
        | US2_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_12 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = alt_insert_sorted_13(v2, v1)
        make_alt_12(v3, v4)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_13(v0, v1)
and regex_equal_16 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_16(v18, v20)
            if v22 then
                regex_equal_16(v19, v21)
            else
                false
        | _ ->
            false
    | UH2_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_16(v26, v28)
            if v30 then
                regex_equal_16(v27, v29)
            else
                false
        | _ ->
            false
    | UH2_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH2_RegexChar(v5) -> (* RegexChar *)
            let v15 : US2 =
                match v4 with
                | US0_BitOne -> (* BitOne *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US2_SymbolSame
                    | US0_BitZero -> (* BitZero *)
                        US2_SymbolGreater
                | US0_BitZero -> (* BitZero *)
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US2_SymbolLess
                    | US0_BitZero -> (* BitZero *)
                        US2_SymbolSame
            match v15 with
            | US2_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH2_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH2_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH2_RegexStar(v34) -> (* RegexStar *)
        match v1 with
        | UH2_RegexStar(v35) -> (* RegexStar *)
            regex_equal_16(v34, v35)
        | _ ->
            false
and make_cat_15 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | _ ->
        match v1 with
        | UH2_RegexEmpty -> (* RegexEmpty *)
            UH2_RegexEmpty
        | _ ->
            match v0 with
            | UH2_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH2_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH2_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH2 = make_cat_15(v13, v1)
                        UH2_RegexCat(v12, v14)
                    | UH2_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_16(v4, v5)
                            if v6 then
                                UH2_RegexStar(v4)
                            else
                                UH2_RegexCat(v0, v1)
                        | _ ->
                            UH2_RegexCat(v0, v1)
                    | _ ->
                        UH2_RegexCat(v0, v1)
and make_star_17 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEpsilon
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v3) -> (* RegexStar *)
        UH2_RegexStar(v3)
    | _ ->
        UH2_RegexStar(v0)
and normalize_11 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = normalize_11(v5)
        let v8 : UH2 = normalize_11(v6)
        make_alt_12(v7, v8)
    | UH2_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = normalize_11(v10)
        let v13 : UH2 = normalize_11(v11)
        make_cat_15(v12, v13)
    | UH2_RegexChar(v3) -> (* RegexChar *)
        UH2_RegexChar(v3)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH2 = normalize_11(v15)
        make_star_17(v16)
and canonical_alt_ordered_19 (v0 : UH2, v1 : UH2) : bool =
    match v1 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = regex_compare_14(v0, v2)
        match v4 with
        | US2_SymbolLess -> (* SymbolLess *)
            canonical_alt_ordered_19(v2, v3)
        | _ ->
            false
    | UH2_RegexEmpty -> (* RegexEmpty *)
        false
    | _ ->
        let v7 : US2 = regex_compare_14(v0, v1)
        match v7 with
        | US2_SymbolLess -> (* SymbolLess *)
            true
        | _ ->
            false
and canonical_regex_form_18 (v0 : UH2) : bool =
    match v0 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v7 : bool =
            match v2 with
            | UH2_RegexAlt(v4, v5) -> (* RegexAlt *)
                false
            | UH2_RegexEmpty -> (* RegexEmpty *)
                false
            | _ ->
                true
        let v9 : bool =
            if v7 then
                canonical_regex_form_18(v2)
            else
                false
        let v11 : bool =
            if v9 then
                canonical_regex_form_18(v3)
            else
                false
        if v11 then
            canonical_alt_ordered_19(v2, v3)
        else
            false
    | UH2_RegexCat(v14, v15) -> (* RegexCat *)
        let v20 : bool =
            match v14 with
            | UH2_RegexCat(v16, v17) -> (* RegexCat *)
                false
            | UH2_RegexEmpty -> (* RegexEmpty *)
                false
            | UH2_RegexEpsilon -> (* RegexEpsilon *)
                false
            | _ ->
                true
        let v23 : bool =
            if v20 then
                match v15 with
                | UH2_RegexEmpty -> (* RegexEmpty *)
                    false
                | UH2_RegexEpsilon -> (* RegexEpsilon *)
                    false
                | _ ->
                    true
            else
                false
        let v30 : bool =
            if v23 then
                match v14 with
                | UH2_RegexStar(v24) -> (* RegexStar *)
                    match v15 with
                    | UH2_RegexStar(v25) -> (* RegexStar *)
                        let v26 : bool = regex_equal_16(v24, v25)
                        let v27 : bool = v26 = false
                        v27
                    | _ ->
                        true
                | _ ->
                    true
            else
                false
        let v32 : bool =
            if v30 then
                canonical_regex_form_18(v14)
            else
                false
        if v32 then
            canonical_regex_form_18(v15)
        else
            false
    | UH2_RegexChar(v1) -> (* RegexChar *)
        true
    | UH2_RegexEmpty -> (* RegexEmpty *)
        true
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        true
    | UH2_RegexStar(v35) -> (* RegexStar *)
        let v39 : bool =
            match v35 with
            | UH2_RegexEmpty -> (* RegexEmpty *)
                false
            | UH2_RegexEpsilon -> (* RegexEpsilon *)
                false
            | UH2_RegexStar(v36) -> (* RegexStar *)
                false
            | _ ->
                true
        if v39 then
            canonical_regex_form_18(v35)
        else
            false
and normalized_corpus_is_canonical_10 (v0 : UH1) : bool =
    match v0 with
    | UH1_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : UH2 = normalize_11(v1)
        let v4 : bool = canonical_regex_form_18(v3)
        if v4 then
            normalized_corpus_is_canonical_10(v2)
        else
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and regex_compare_24 (v0 : UH5, v1 : UH5) : US2 =
    match v0 with
    | UH5_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH5_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US2 = regex_compare_24(v59, v61)
            match v63 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_24(v60, v62)
            | _ ->
                v63
        | _ ->
            US2_SymbolGreater
    | UH5_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH5_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US2 = regex_compare_24(v34, v40)
            match v42 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_24(v35, v41)
            | _ ->
                v42
        | UH5_RegexChar(v38) -> (* RegexChar *)
            US2_SymbolGreater
        | UH5_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH5_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolGreater
        | _ ->
            US2_SymbolLess
    | UH5_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH5_RegexChar(v13) -> (* RegexChar *)
            match v10 with
            | US1_TriA -> (* TriA *)
                match v13 with
                | US1_TriA -> (* TriA *)
                    US2_SymbolSame
                | _ ->
                    US2_SymbolLess
            | _ ->
                match v13 with
                | US1_TriA -> (* TriA *)
                    US2_SymbolGreater
                | _ ->
                    match v10 with
                    | US1_TriB -> (* TriB *)
                        match v13 with
                        | US1_TriB -> (* TriB *)
                            US2_SymbolSame
                        | US1_TriC -> (* TriC *)
                            US2_SymbolLess
                    | US1_TriC -> (* TriC *)
                        match v13 with
                        | US1_TriB -> (* TriB *)
                            US2_SymbolGreater
                        | US1_TriC -> (* TriC *)
                            US2_SymbolSame
        | UH5_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH5_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolGreater
        | _ ->
            US2_SymbolLess
    | UH5_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH5_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolSame
        | _ ->
            US2_SymbolLess
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH5_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH5_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolSame
        | _ ->
            US2_SymbolLess
    | UH5_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH5_RegexAlt(v51, v52) -> (* RegexAlt *)
            US2_SymbolLess
        | UH5_RegexStar(v54) -> (* RegexStar *)
            regex_compare_24(v50, v54)
        | _ ->
            US2_SymbolGreater
and alt_insert_sorted_23 (v0 : UH5, v1 : UH5) : UH5 =
    match v1 with
    | UH5_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = regex_compare_24(v0, v2)
        match v4 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH5 = alt_insert_sorted_23(v0, v3)
            UH5_RegexAlt(v2, v6)
        | US2_SymbolLess -> (* SymbolLess *)
            UH5_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
    | UH5_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US2 = regex_compare_24(v0, v1)
        match v11 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            UH5_RegexAlt(v1, v0)
        | US2_SymbolLess -> (* SymbolLess *)
            UH5_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_22 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH5 = alt_insert_sorted_23(v2, v1)
        make_alt_22(v3, v4)
    | UH5_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_23(v0, v1)
and regex_equal_26 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH5_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_26(v24, v26)
            if v28 then
                regex_equal_26(v25, v27)
            else
                false
        | _ ->
            false
    | UH5_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH5_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_26(v32, v34)
            if v36 then
                regex_equal_26(v33, v35)
            else
                false
        | _ ->
            false
    | UH5_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH5_RegexChar(v5) -> (* RegexChar *)
            let v21 : US2 =
                match v4 with
                | US1_TriA -> (* TriA *)
                    match v5 with
                    | US1_TriA -> (* TriA *)
                        US2_SymbolSame
                    | _ ->
                        US2_SymbolLess
                | _ ->
                    match v5 with
                    | US1_TriA -> (* TriA *)
                        US2_SymbolGreater
                    | _ ->
                        match v4 with
                        | US1_TriB -> (* TriB *)
                            match v5 with
                            | US1_TriB -> (* TriB *)
                                US2_SymbolSame
                            | US1_TriC -> (* TriC *)
                                US2_SymbolLess
                        | US1_TriC -> (* TriC *)
                            match v5 with
                            | US1_TriB -> (* TriB *)
                                US2_SymbolGreater
                            | US1_TriC -> (* TriC *)
                                US2_SymbolSame
            match v21 with
            | US2_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH5_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH5_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH5_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH5_RegexStar(v40) -> (* RegexStar *)
        match v1 with
        | UH5_RegexStar(v41) -> (* RegexStar *)
            regex_equal_26(v40, v41)
        | _ ->
            false
and make_cat_25 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexEmpty
    | _ ->
        match v1 with
        | UH5_RegexEmpty -> (* RegexEmpty *)
            UH5_RegexEmpty
        | _ ->
            match v0 with
            | UH5_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH5_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH5_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH5 = make_cat_25(v13, v1)
                        UH5_RegexCat(v12, v14)
                    | UH5_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH5_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_26(v4, v5)
                            if v6 then
                                UH5_RegexStar(v4)
                            else
                                UH5_RegexCat(v0, v1)
                        | _ ->
                            UH5_RegexCat(v0, v1)
                    | _ ->
                        UH5_RegexCat(v0, v1)
and make_star_27 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexEpsilon
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        UH5_RegexEpsilon
    | UH5_RegexStar(v3) -> (* RegexStar *)
        UH5_RegexStar(v3)
    | _ ->
        UH5_RegexStar(v0)
and normalize_21 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH5 = normalize_21(v5)
        let v8 : UH5 = normalize_21(v6)
        make_alt_22(v7, v8)
    | UH5_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH5 = normalize_21(v10)
        let v13 : UH5 = normalize_21(v11)
        make_cat_25(v12, v13)
    | UH5_RegexChar(v3) -> (* RegexChar *)
        UH5_RegexChar(v3)
    | UH5_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexEmpty
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        UH5_RegexEpsilon
    | UH5_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH5 = normalize_21(v15)
        make_star_27(v16)
and canonical_alt_ordered_29 (v0 : UH5, v1 : UH5) : bool =
    match v1 with
    | UH5_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = regex_compare_24(v0, v2)
        match v4 with
        | US2_SymbolLess -> (* SymbolLess *)
            canonical_alt_ordered_29(v2, v3)
        | _ ->
            false
    | UH5_RegexEmpty -> (* RegexEmpty *)
        false
    | _ ->
        let v7 : US2 = regex_compare_24(v0, v1)
        match v7 with
        | US2_SymbolLess -> (* SymbolLess *)
            true
        | _ ->
            false
and canonical_regex_form_28 (v0 : UH5) : bool =
    match v0 with
    | UH5_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v7 : bool =
            match v2 with
            | UH5_RegexAlt(v4, v5) -> (* RegexAlt *)
                false
            | UH5_RegexEmpty -> (* RegexEmpty *)
                false
            | _ ->
                true
        let v9 : bool =
            if v7 then
                canonical_regex_form_28(v2)
            else
                false
        let v11 : bool =
            if v9 then
                canonical_regex_form_28(v3)
            else
                false
        if v11 then
            canonical_alt_ordered_29(v2, v3)
        else
            false
    | UH5_RegexCat(v14, v15) -> (* RegexCat *)
        let v20 : bool =
            match v14 with
            | UH5_RegexCat(v16, v17) -> (* RegexCat *)
                false
            | UH5_RegexEmpty -> (* RegexEmpty *)
                false
            | UH5_RegexEpsilon -> (* RegexEpsilon *)
                false
            | _ ->
                true
        let v23 : bool =
            if v20 then
                match v15 with
                | UH5_RegexEmpty -> (* RegexEmpty *)
                    false
                | UH5_RegexEpsilon -> (* RegexEpsilon *)
                    false
                | _ ->
                    true
            else
                false
        let v30 : bool =
            if v23 then
                match v14 with
                | UH5_RegexStar(v24) -> (* RegexStar *)
                    match v15 with
                    | UH5_RegexStar(v25) -> (* RegexStar *)
                        let v26 : bool = regex_equal_26(v24, v25)
                        let v27 : bool = v26 = false
                        v27
                    | _ ->
                        true
                | _ ->
                    true
            else
                false
        let v32 : bool =
            if v30 then
                canonical_regex_form_28(v14)
            else
                false
        if v32 then
            canonical_regex_form_28(v15)
        else
            false
    | UH5_RegexChar(v1) -> (* RegexChar *)
        true
    | UH5_RegexEmpty -> (* RegexEmpty *)
        true
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        true
    | UH5_RegexStar(v35) -> (* RegexStar *)
        let v39 : bool =
            match v35 with
            | UH5_RegexEmpty -> (* RegexEmpty *)
                false
            | UH5_RegexEpsilon -> (* RegexEpsilon *)
                false
            | UH5_RegexStar(v36) -> (* RegexStar *)
                false
            | _ ->
                true
        if v39 then
            canonical_regex_form_28(v35)
        else
            false
and normalized_corpus_is_canonical_20 (v0 : UH4) : bool =
    match v0 with
    | UH4_RegexListCons(v1, v2) -> (* RegexListCons *)
        let v3 : UH5 = normalize_21(v1)
        let v4 : bool = canonical_regex_form_28(v3)
        if v4 then
            normalized_corpus_is_canonical_20(v2)
        else
            false
    | UH4_RegexListNil -> (* RegexListNil *)
        true
and nullable_34 (v0 : UH2) : US3 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_34(v5)
        let v8 : US3 = nullable_34(v6)
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
    | UH2_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US3 = nullable_34(v16)
        let v19 : US3 = nullable_34(v17)
        match v18 with
        | US3_Nullable -> (* Nullable *)
            match v19 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                US3_NonNullable
        | _ ->
            US3_NonNullable
    | UH2_RegexChar(v3) -> (* RegexChar *)
        US3_NonNullable
    | UH2_RegexEmpty -> (* RegexEmpty *)
        US3_NonNullable
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        US3_Nullable
    | UH2_RegexStar(v25) -> (* RegexStar *)
        US3_Nullable
and derivative_33 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH2 = derivative_33(v19, v1)
        let v22 : UH2 = derivative_33(v20, v1)
        make_alt_12(v21, v22)
    | UH2_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US3 = nullable_34(v24)
        match v26 with
        | US3_NonNullable -> (* NonNullable *)
            let v31 : UH2 = derivative_33(v24, v1)
            make_cat_15(v31, v25)
        | US3_Nullable -> (* Nullable *)
            let v27 : UH2 = derivative_33(v24, v1)
            let v28 : UH2 = make_cat_15(v27, v25)
            let v29 : UH2 = derivative_33(v25, v1)
            make_alt_12(v28, v29)
    | UH2_RegexChar(v4) -> (* RegexChar *)
        let v14 : US2 =
            match v4 with
            | US0_BitOne -> (* BitOne *)
                match v1 with
                | US0_BitOne -> (* BitOne *)
                    US2_SymbolSame
                | US0_BitZero -> (* BitZero *)
                    US2_SymbolGreater
            | US0_BitZero -> (* BitZero *)
                match v1 with
                | US0_BitOne -> (* BitOne *)
                    US2_SymbolLess
                | US0_BitZero -> (* BitZero *)
                    US2_SymbolSame
        let v15 : bool =
            match v14 with
            | US2_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH2_RegexEpsilon
        else
            UH2_RegexEmpty
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEmpty
    | UH2_RegexStar(v35) -> (* RegexStar *)
        let v36 : UH2 = derivative_33(v35, v1)
        let v37 : UH2 = make_star_17(v35)
        make_cat_15(v36, v37)
and canonical_derivative_32 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = normalize_11(v0)
    let v3 : UH2 = derivative_33(v2, v1)
    normalize_11(v3)
and canonical_derivatives_are_canonical_symbols_31 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH2 = canonical_derivative_32(v0, v2)
        let v5 : bool = canonical_regex_form_18(v4)
        if v5 then
            canonical_derivatives_are_canonical_symbols_31(v0, v3)
        else
            false
    | UH0_SymbolListNil -> (* SymbolListNil *)
        true
and canonical_derivatives_are_canonical_corpus_30 (v0 : UH1, v1 : UH0) : bool =
    match v0 with
    | UH1_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = canonical_derivatives_are_canonical_symbols_31(v2, v1)
        if v4 then
            canonical_derivatives_are_canonical_corpus_30(v3, v1)
        else
            false
    | UH1_RegexListNil -> (* RegexListNil *)
        true
and nullable_39 (v0 : UH5) : US3 =
    match v0 with
    | UH5_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_39(v5)
        let v8 : US3 = nullable_39(v6)
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
    | UH5_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US3 = nullable_39(v16)
        let v19 : US3 = nullable_39(v17)
        match v18 with
        | US3_Nullable -> (* Nullable *)
            match v19 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                US3_NonNullable
        | _ ->
            US3_NonNullable
    | UH5_RegexChar(v3) -> (* RegexChar *)
        US3_NonNullable
    | UH5_RegexEmpty -> (* RegexEmpty *)
        US3_NonNullable
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        US3_Nullable
    | UH5_RegexStar(v25) -> (* RegexStar *)
        US3_Nullable
and derivative_38 (v0 : UH5, v1 : US1) : UH5 =
    match v0 with
    | UH5_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH5 = derivative_38(v25, v1)
        let v28 : UH5 = derivative_38(v26, v1)
        make_alt_22(v27, v28)
    | UH5_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US3 = nullable_39(v30)
        match v32 with
        | US3_NonNullable -> (* NonNullable *)
            let v37 : UH5 = derivative_38(v30, v1)
            make_cat_25(v37, v31)
        | US3_Nullable -> (* Nullable *)
            let v33 : UH5 = derivative_38(v30, v1)
            let v34 : UH5 = make_cat_25(v33, v31)
            let v35 : UH5 = derivative_38(v31, v1)
            make_alt_22(v34, v35)
    | UH5_RegexChar(v4) -> (* RegexChar *)
        let v20 : US2 =
            match v4 with
            | US1_TriA -> (* TriA *)
                match v1 with
                | US1_TriA -> (* TriA *)
                    US2_SymbolSame
                | _ ->
                    US2_SymbolLess
            | _ ->
                match v1 with
                | US1_TriA -> (* TriA *)
                    US2_SymbolGreater
                | _ ->
                    match v4 with
                    | US1_TriB -> (* TriB *)
                        match v1 with
                        | US1_TriB -> (* TriB *)
                            US2_SymbolSame
                        | US1_TriC -> (* TriC *)
                            US2_SymbolLess
                    | US1_TriC -> (* TriC *)
                        match v1 with
                        | US1_TriB -> (* TriB *)
                            US2_SymbolGreater
                        | US1_TriC -> (* TriC *)
                            US2_SymbolSame
        let v21 : bool =
            match v20 with
            | US2_SymbolSame -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH5_RegexEpsilon
        else
            UH5_RegexEmpty
    | UH5_RegexEmpty -> (* RegexEmpty *)
        UH5_RegexEmpty
    | UH5_RegexEpsilon -> (* RegexEpsilon *)
        UH5_RegexEmpty
    | UH5_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH5 = derivative_38(v41, v1)
        let v43 : UH5 = make_star_27(v41)
        make_cat_25(v42, v43)
and canonical_derivative_37 (v0 : UH5, v1 : US1) : UH5 =
    let v2 : UH5 = normalize_21(v0)
    let v3 : UH5 = derivative_38(v2, v1)
    normalize_21(v3)
and canonical_derivatives_are_canonical_symbols_36 (v0 : UH5, v1 : UH3) : bool =
    match v1 with
    | UH3_SymbolListCons(v2, v3) -> (* SymbolListCons *)
        let v4 : UH5 = canonical_derivative_37(v0, v2)
        let v5 : bool = canonical_regex_form_28(v4)
        if v5 then
            canonical_derivatives_are_canonical_symbols_36(v0, v3)
        else
            false
    | UH3_SymbolListNil -> (* SymbolListNil *)
        true
and canonical_derivatives_are_canonical_corpus_35 (v0 : UH4, v1 : UH3) : bool =
    match v0 with
    | UH4_RegexListCons(v2, v3) -> (* RegexListCons *)
        let v4 : bool = canonical_derivatives_are_canonical_symbols_36(v2, v1)
        if v4 then
            canonical_derivatives_are_canonical_corpus_35(v3, v1)
        else
            false
    | UH4_RegexListNil -> (* RegexListNil *)
        true
let v0 : US0 = US0_BitZero
let v1 : US0 = US0_BitOne
let v2 : UH0 = UH0_SymbolListNil
let v3 : UH0 = UH0_SymbolListCons(v1, v2)
let v4 : UH0 = UH0_SymbolListCons(v0, v3)
let v5 : UH1 = regex_chars_from_symbols_0(v4)
let v6 : UH2 = UH2_RegexEmpty
let v7 : UH2 = UH2_RegexEpsilon
let v8 : UH1 = UH1_RegexListCons(v7, v5)
let v9 : UH1 = UH1_RegexListCons(v6, v8)
let v10 : UH2 = UH2_RegexEmpty
let v11 : UH2 = UH2_RegexEpsilon
let v12 : UH1 = UH1_RegexListCons(v11, v5)
let v13 : UH1 = UH1_RegexListCons(v10, v12)
let v14 : UH1 = regex_star_corpus_1(v13)
let v15 : UH2 = UH2_RegexEmpty
let v16 : UH2 = UH2_RegexEpsilon
let v17 : UH1 = UH1_RegexListCons(v16, v5)
let v18 : UH1 = UH1_RegexListCons(v15, v17)
let v19 : UH2 = UH2_RegexEmpty
let v20 : UH2 = UH2_RegexEpsilon
let v21 : UH1 = UH1_RegexListCons(v20, v5)
let v22 : UH1 = UH1_RegexListCons(v19, v21)
let v23 : UH1 = regex_binary_corpus_2(v18, v22)
let v24 : UH1 = regex_list_append_4(v14, v23)
let v25 : UH1 = regex_list_append_4(v9, v24)
let v26 : US1 = US1_TriA
let v27 : US1 = US1_TriB
let v28 : US1 = US1_TriC
let v29 : UH3 = UH3_SymbolListNil
let v30 : UH3 = UH3_SymbolListCons(v28, v29)
let v31 : UH3 = UH3_SymbolListCons(v27, v30)
let v32 : UH3 = UH3_SymbolListCons(v26, v31)
let v33 : UH4 = regex_chars_from_symbols_5(v32)
let v34 : UH5 = UH5_RegexEmpty
let v35 : UH5 = UH5_RegexEpsilon
let v36 : UH4 = UH4_RegexListCons(v35, v33)
let v37 : UH4 = UH4_RegexListCons(v34, v36)
let v38 : UH5 = UH5_RegexEmpty
let v39 : UH5 = UH5_RegexEpsilon
let v40 : UH4 = UH4_RegexListCons(v39, v33)
let v41 : UH4 = UH4_RegexListCons(v38, v40)
let v42 : UH4 = regex_star_corpus_6(v41)
let v43 : UH5 = UH5_RegexEmpty
let v44 : UH5 = UH5_RegexEpsilon
let v45 : UH4 = UH4_RegexListCons(v44, v33)
let v46 : UH4 = UH4_RegexListCons(v43, v45)
let v47 : UH5 = UH5_RegexEmpty
let v48 : UH5 = UH5_RegexEpsilon
let v49 : UH4 = UH4_RegexListCons(v48, v33)
let v50 : UH4 = UH4_RegexListCons(v47, v49)
let v51 : UH4 = regex_binary_corpus_7(v46, v50)
let v52 : UH4 = regex_list_append_9(v42, v51)
let v53 : UH4 = regex_list_append_9(v37, v52)
let v54 : bool = normalized_corpus_is_canonical_10(v25)
if v54 then
    ()
else
    failwith<unit> "every normalized bit corpus term must satisfy structural canonical form"
let v55 : bool = normalized_corpus_is_canonical_20(v53)
if v55 then
    ()
else
    failwith<unit> "every normalized ternary corpus term must satisfy structural canonical form"
let v56 : US0 = US0_BitZero
let v57 : US0 = US0_BitOne
let v58 : UH0 = UH0_SymbolListNil
let v59 : UH0 = UH0_SymbolListCons(v57, v58)
let v60 : UH0 = UH0_SymbolListCons(v56, v59)
let v61 : bool = canonical_derivatives_are_canonical_corpus_30(v25, v60)
if v61 then
    ()
else
    failwith<unit> "every canonical bit derivative must already satisfy structural canonical form"
let v62 : US1 = US1_TriA
let v63 : US1 = US1_TriB
let v64 : US1 = US1_TriC
let v65 : UH3 = UH3_SymbolListNil
let v66 : UH3 = UH3_SymbolListCons(v64, v65)
let v67 : UH3 = UH3_SymbolListCons(v63, v66)
let v68 : UH3 = UH3_SymbolListCons(v62, v67)
let v69 : bool = canonical_derivatives_are_canonical_corpus_35(v53, v68)
if v69 then
    ()
else
    failwith<unit> "every canonical ternary derivative must already satisfy structural canonical form"
let v70 : US0 = US0_BitOne
let v71 : UH2 = UH2_RegexChar(v70)
let v72 : US0 = US0_BitZero
let v73 : UH2 = UH2_RegexChar(v72)
let v74 : UH2 = UH2_RegexAlt(v71, v73)
let v75 : bool = canonical_regex_form_18(v74)
let v76 : bool = v75 = false
if v76 then
    ()
else
    failwith<unit> "unsorted alternation must not be canonical"
let v77 : US0 = US0_BitZero
let v78 : UH2 = UH2_RegexChar(v77)
let v79 : UH2 = UH2_RegexAlt(v78, v78)
let v80 : bool = canonical_regex_form_18(v79)
let v81 : bool = v80 = false
if v81 then
    ()
else
    failwith<unit> "duplicate alternation must not be canonical"
let v82 : US0 = US0_BitZero
let v83 : UH2 = UH2_RegexChar(v82)
let v84 : US0 = US0_BitOne
let v85 : UH2 = UH2_RegexChar(v84)
let v86 : UH2 = UH2_RegexAlt(v83, v85)
let v87 : UH2 = UH2_RegexEpsilon
let v88 : UH2 = UH2_RegexAlt(v86, v87)
let v89 : bool = canonical_regex_form_18(v88)
let v90 : bool = v89 = false
if v90 then
    ()
else
    failwith<unit> "left-nested alternation must not be canonical"
let v91 : UH2 = UH2_RegexEpsilon
let v92 : US0 = US0_BitZero
let v93 : UH2 = UH2_RegexChar(v92)
let v94 : UH2 = UH2_RegexCat(v91, v93)
let v95 : bool = canonical_regex_form_18(v94)
let v96 : bool = v95 = false
if v96 then
    ()
else
    failwith<unit> "epsilon concatenation identity must not remain in canonical form"
let v97 : US0 = US0_BitZero
let v98 : UH2 = UH2_RegexChar(v97)
let v99 : US0 = US0_BitOne
let v100 : UH2 = UH2_RegexChar(v99)
let v101 : UH2 = UH2_RegexCat(v98, v100)
let v102 : UH2 = UH2_RegexCat(v101, v98)
let v103 : bool = canonical_regex_form_18(v102)
let v104 : bool = v103 = false
if v104 then
    ()
else
    failwith<unit> "left-associated concatenation must not remain in canonical form"
let v105 : UH2 = UH2_RegexEmpty
let v106 : UH2 = UH2_RegexStar(v105)
let v107 : bool = canonical_regex_form_18(v106)
let v108 : bool = v107 = false
if v108 then
    ()
else
    failwith<unit> "star of empty must not remain in canonical form"
let v109 : US0 = US0_BitZero
let v110 : UH2 = UH2_RegexChar(v109)
let v111 : UH2 = UH2_RegexStar(v110)
let v112 : UH2 = UH2_RegexStar(v111)
let v113 : bool = canonical_regex_form_18(v112)
let v114 : bool = v113 = false
if v114 then
    ()
else
    failwith<unit> "nested star must not remain in canonical form"
let v115 : US0 = US0_BitZero
let v116 : UH2 = UH2_RegexChar(v115)
let v117 : UH2 = UH2_RegexStar(v116)
let v118 : UH2 = UH2_RegexCat(v117, v117)
let v119 : bool = canonical_regex_form_18(v118)
let v120 : bool = v119 = false
if v120 then
    ()
else
    failwith<unit> "duplicate adjacent stars must be reduced in canonical form"
let v121 : US0 = US0_BitOne
let v122 : UH2 = UH2_RegexChar(v121)
let v123 : US0 = US0_BitZero
let v124 : UH2 = UH2_RegexChar(v123)
let v125 : UH2 = UH2_RegexAlt(v122, v124)
let v126 : UH2 = normalize_11(v125)
let v127 : bool = canonical_regex_form_18(v126)
if v127 then
    ()
else
    failwith<unit> "normalization must repair unsorted alternation"
let v128 : US0 = US0_BitZero
let v129 : UH2 = UH2_RegexChar(v128)
let v130 : UH2 = UH2_RegexAlt(v129, v129)
let v131 : UH2 = normalize_11(v130)
let v132 : bool = canonical_regex_form_18(v131)
if v132 then
    ()
else
    failwith<unit> "normalization must remove duplicate alternation"
let v133 : UH2 = UH2_RegexEpsilon
let v134 : US0 = US0_BitZero
let v135 : UH2 = UH2_RegexChar(v134)
let v136 : UH2 = UH2_RegexCat(v133, v135)
let v137 : UH2 = normalize_11(v136)
let v138 : bool = canonical_regex_form_18(v137)
if v138 then
    ()
else
    failwith<unit> "normalization must remove concatenation identity"
let v139 : US0 = US0_BitZero
let v140 : UH2 = UH2_RegexChar(v139)
let v141 : UH2 = UH2_RegexStar(v140)
let v142 : UH2 = UH2_RegexStar(v141)
let v143 : UH2 = normalize_11(v142)
let v144 : bool = canonical_regex_form_18(v143)
if v144 then
    ()
else
    failwith<unit> "normalization must collapse nested star"
let v145 : US0 = US0_BitZero
let v146 : UH2 = UH2_RegexChar(v145)
let v147 : UH2 = UH2_RegexStar(v146)
let v148 : UH2 = UH2_RegexCat(v147, v147)
let v149 : UH2 = normalize_11(v148)
let v150 : bool = canonical_regex_form_18(v149)
if v150 then
    ()
else
    failwith<unit> "normalization must collapse duplicate adjacent stars"
let v151 : string = "brzozowski-canonical-form-certificate-green"
v151
