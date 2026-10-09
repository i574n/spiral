type [<Struct>] US0 =
    | US0_BitZero
    | US0_BitOne
and UH0 =
    | UH0_InputEmpty
    | UH0_InputCons of US0 * UH0
and [<Struct>] US1 =
    | US1_TriA
    | US1_TriB
    | US1_TriC
and UH1 =
    | UH1_InputEmpty
    | UH1_InputCons of US1 * UH1
and UH2 =
    | UH2_RegexEmpty
    | UH2_RegexEpsilon
    | UH2_RegexChar of US0
    | UH2_RegexAlt of UH2 * UH2
    | UH2_RegexCat of UH2 * UH2
    | UH2_RegexStar of UH2
and [<Struct>] US2 =
    | US2_SymbolLess
    | US2_SymbolSame
    | US2_SymbolGreater
and [<Struct>] US3 =
    | US3_Nullable
    | US3_NonNullable
and UH3 =
    | UH3_RegexEmpty
    | UH3_RegexEpsilon
    | UH3_RegexChar of US1
    | UH3_RegexAlt of UH3 * UH3
    | UH3_RegexCat of UH3 * UH3
    | UH3_RegexStar of UH3
and [<Struct>] US4 =
    | US4_BitMatcherRaw of f0_0 : UH2 * f0_1 : UH0
and [<Struct>] US5 =
    | US5_BitMatcherDecided of f0_0 : UH2 * f0_1 : UH0 * f0_2 : bool
let rec regex_compare_5 (v0 : UH2, v1 : UH2) : US2 =
    match v0 with
    | UH2_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US2 = regex_compare_5(v53, v55)
            match v57 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_5(v54, v56)
            | _ ->
                v57
        | _ ->
            US2_SymbolGreater
    | UH2_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US2 = regex_compare_5(v28, v34)
            match v36 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_5(v29, v35)
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
            regex_compare_5(v44, v48)
        | _ ->
            US2_SymbolGreater
and alt_insert_sorted_4 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = regex_compare_5(v0, v2)
        match v4 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH2 = alt_insert_sorted_4(v0, v3)
            UH2_RegexAlt(v2, v6)
        | US2_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US2 = regex_compare_5(v0, v1)
        match v11 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            UH2_RegexAlt(v1, v0)
        | US2_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_3 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = alt_insert_sorted_4(v2, v1)
        make_alt_3(v3, v4)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_4(v0, v1)
and regex_equal_7 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_7(v18, v20)
            if v22 then
                regex_equal_7(v19, v21)
            else
                false
        | _ ->
            false
    | UH2_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_7(v26, v28)
            if v30 then
                regex_equal_7(v27, v29)
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
            regex_equal_7(v34, v35)
        | _ ->
            false
and make_cat_6 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = make_cat_6(v13, v1)
                        UH2_RegexCat(v12, v14)
                    | UH2_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_7(v4, v5)
                            if v6 then
                                UH2_RegexStar(v4)
                            else
                                UH2_RegexCat(v0, v1)
                        | _ ->
                            UH2_RegexCat(v0, v1)
                    | _ ->
                        UH2_RegexCat(v0, v1)
and make_star_8 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEpsilon
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v3) -> (* RegexStar *)
        UH2_RegexStar(v3)
    | _ ->
        UH2_RegexStar(v0)
and normalize_2 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = normalize_2(v5)
        let v8 : UH2 = normalize_2(v6)
        make_alt_3(v7, v8)
    | UH2_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = normalize_2(v10)
        let v13 : UH2 = normalize_2(v11)
        make_cat_6(v12, v13)
    | UH2_RegexChar(v3) -> (* RegexChar *)
        UH2_RegexChar(v3)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH2 = normalize_2(v15)
        make_star_8(v16)
and nullable_10 (v0 : UH2) : US3 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_10(v5)
        let v8 : US3 = nullable_10(v6)
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
        let v18 : US3 = nullable_10(v16)
        let v19 : US3 = nullable_10(v17)
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
and derivative_9 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH2 = derivative_9(v19, v1)
        let v22 : UH2 = derivative_9(v20, v1)
        make_alt_3(v21, v22)
    | UH2_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US3 = nullable_10(v24)
        match v26 with
        | US3_NonNullable -> (* NonNullable *)
            let v31 : UH2 = derivative_9(v24, v1)
            make_cat_6(v31, v25)
        | US3_Nullable -> (* Nullable *)
            let v27 : UH2 = derivative_9(v24, v1)
            let v28 : UH2 = make_cat_6(v27, v25)
            let v29 : UH2 = derivative_9(v25, v1)
            make_alt_3(v28, v29)
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
        let v36 : UH2 = derivative_9(v35, v1)
        let v37 : UH2 = make_star_8(v35)
        make_cat_6(v36, v37)
and canonical_derivative_1 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = normalize_2(v0)
    let v3 : UH2 = derivative_9(v2, v1)
    normalize_2(v3)
and accepts_0 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH2 = canonical_derivative_1(v0, v6)
        accepts_0(v8, v7)
    | UH0_InputEmpty -> (* InputEmpty *)
        let v2 : UH2 = normalize_2(v0)
        let v3 : US3 = nullable_10(v2)
        match v3 with
        | US3_NonNullable -> (* NonNullable *)
            false
        | US3_Nullable -> (* Nullable *)
            true
and regex_compare_16 (v0 : UH3, v1 : UH3) : US2 =
    match v0 with
    | UH3_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH3_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US2 = regex_compare_16(v59, v61)
            match v63 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_16(v60, v62)
            | _ ->
                v63
        | _ ->
            US2_SymbolGreater
    | UH3_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH3_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US2 = regex_compare_16(v34, v40)
            match v42 with
            | US2_SymbolSame -> (* SymbolSame *)
                regex_compare_16(v35, v41)
            | _ ->
                v42
        | UH3_RegexChar(v38) -> (* RegexChar *)
            US2_SymbolGreater
        | UH3_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH3_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolGreater
        | _ ->
            US2_SymbolLess
    | UH3_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH3_RegexChar(v13) -> (* RegexChar *)
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
        | UH3_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH3_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolGreater
        | _ ->
            US2_SymbolLess
    | UH3_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH3_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolSame
        | _ ->
            US2_SymbolLess
    | UH3_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH3_RegexEmpty -> (* RegexEmpty *)
            US2_SymbolGreater
        | UH3_RegexEpsilon -> (* RegexEpsilon *)
            US2_SymbolSame
        | _ ->
            US2_SymbolLess
    | UH3_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH3_RegexAlt(v51, v52) -> (* RegexAlt *)
            US2_SymbolLess
        | UH3_RegexStar(v54) -> (* RegexStar *)
            regex_compare_16(v50, v54)
        | _ ->
            US2_SymbolGreater
and alt_insert_sorted_15 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = regex_compare_16(v0, v2)
        match v4 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH3 = alt_insert_sorted_15(v0, v3)
            UH3_RegexAlt(v2, v6)
        | US2_SymbolLess -> (* SymbolLess *)
            UH3_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
    | UH3_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US2 = regex_compare_16(v0, v1)
        match v11 with
        | US2_SymbolGreater -> (* SymbolGreater *)
            UH3_RegexAlt(v1, v0)
        | US2_SymbolLess -> (* SymbolLess *)
            UH3_RegexAlt(v0, v1)
        | US2_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_14 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH3 = alt_insert_sorted_15(v2, v1)
        make_alt_14(v3, v4)
    | UH3_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_15(v0, v1)
and regex_equal_18 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH3_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_18(v24, v26)
            if v28 then
                regex_equal_18(v25, v27)
            else
                false
        | _ ->
            false
    | UH3_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH3_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_18(v32, v34)
            if v36 then
                regex_equal_18(v33, v35)
            else
                false
        | _ ->
            false
    | UH3_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH3_RegexChar(v5) -> (* RegexChar *)
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
    | UH3_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH3_RegexEmpty -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH3_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH3_RegexEpsilon -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH3_RegexStar(v40) -> (* RegexStar *)
        match v1 with
        | UH3_RegexStar(v41) -> (* RegexStar *)
            regex_equal_18(v40, v41)
        | _ ->
            false
and make_cat_17 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_RegexEmpty -> (* RegexEmpty *)
        UH3_RegexEmpty
    | _ ->
        match v1 with
        | UH3_RegexEmpty -> (* RegexEmpty *)
            UH3_RegexEmpty
        | _ ->
            match v0 with
            | UH3_RegexEpsilon -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH3_RegexEpsilon -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH3_RegexCat(v12, v13) -> (* RegexCat *)
                        let v14 : UH3 = make_cat_17(v13, v1)
                        UH3_RegexCat(v12, v14)
                    | UH3_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH3_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_18(v4, v5)
                            if v6 then
                                UH3_RegexStar(v4)
                            else
                                UH3_RegexCat(v0, v1)
                        | _ ->
                            UH3_RegexCat(v0, v1)
                    | _ ->
                        UH3_RegexCat(v0, v1)
and make_star_19 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_RegexEmpty -> (* RegexEmpty *)
        UH3_RegexEpsilon
    | UH3_RegexEpsilon -> (* RegexEpsilon *)
        UH3_RegexEpsilon
    | UH3_RegexStar(v3) -> (* RegexStar *)
        UH3_RegexStar(v3)
    | _ ->
        UH3_RegexStar(v0)
and normalize_13 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH3 = normalize_13(v5)
        let v8 : UH3 = normalize_13(v6)
        make_alt_14(v7, v8)
    | UH3_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH3 = normalize_13(v10)
        let v13 : UH3 = normalize_13(v11)
        make_cat_17(v12, v13)
    | UH3_RegexChar(v3) -> (* RegexChar *)
        UH3_RegexChar(v3)
    | UH3_RegexEmpty -> (* RegexEmpty *)
        UH3_RegexEmpty
    | UH3_RegexEpsilon -> (* RegexEpsilon *)
        UH3_RegexEpsilon
    | UH3_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH3 = normalize_13(v15)
        make_star_19(v16)
and nullable_21 (v0 : UH3) : US3 =
    match v0 with
    | UH3_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = nullable_21(v5)
        let v8 : US3 = nullable_21(v6)
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
    | UH3_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US3 = nullable_21(v16)
        let v19 : US3 = nullable_21(v17)
        match v18 with
        | US3_Nullable -> (* Nullable *)
            match v19 with
            | US3_Nullable -> (* Nullable *)
                US3_Nullable
            | _ ->
                US3_NonNullable
        | _ ->
            US3_NonNullable
    | UH3_RegexChar(v3) -> (* RegexChar *)
        US3_NonNullable
    | UH3_RegexEmpty -> (* RegexEmpty *)
        US3_NonNullable
    | UH3_RegexEpsilon -> (* RegexEpsilon *)
        US3_Nullable
    | UH3_RegexStar(v25) -> (* RegexStar *)
        US3_Nullable
and derivative_20 (v0 : UH3, v1 : US1) : UH3 =
    match v0 with
    | UH3_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH3 = derivative_20(v25, v1)
        let v28 : UH3 = derivative_20(v26, v1)
        make_alt_14(v27, v28)
    | UH3_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US3 = nullable_21(v30)
        match v32 with
        | US3_NonNullable -> (* NonNullable *)
            let v37 : UH3 = derivative_20(v30, v1)
            make_cat_17(v37, v31)
        | US3_Nullable -> (* Nullable *)
            let v33 : UH3 = derivative_20(v30, v1)
            let v34 : UH3 = make_cat_17(v33, v31)
            let v35 : UH3 = derivative_20(v31, v1)
            make_alt_14(v34, v35)
    | UH3_RegexChar(v4) -> (* RegexChar *)
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
            UH3_RegexEpsilon
        else
            UH3_RegexEmpty
    | UH3_RegexEmpty -> (* RegexEmpty *)
        UH3_RegexEmpty
    | UH3_RegexEpsilon -> (* RegexEpsilon *)
        UH3_RegexEmpty
    | UH3_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH3 = derivative_20(v41, v1)
        let v43 : UH3 = make_star_19(v41)
        make_cat_17(v42, v43)
and canonical_derivative_12 (v0 : UH3, v1 : US1) : UH3 =
    let v2 : UH3 = normalize_13(v0)
    let v3 : UH3 = derivative_20(v2, v1)
    normalize_13(v3)
and accepts_11 (v0 : UH3, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH3 = canonical_derivative_12(v0, v6)
        accepts_11(v8, v7)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : UH3 = normalize_13(v0)
        let v3 : US3 = nullable_21(v2)
        match v3 with
        | US3_NonNullable -> (* NonNullable *)
            false
        | US3_Nullable -> (* Nullable *)
            true
and decide_bit_match_22 (v0 : US4) : US5 =
    match v0 with
    | US4_BitMatcherRaw(v1, v2) -> (* BitMatcherRaw *)
        let v3 : bool = accepts_0(v1, v2)
        US5_BitMatcherDecided(v1, v2, v3)
and bit_match_value_23 (v0 : US5) : bool =
    match v0 with
    | US5_BitMatcherDecided(v1, v2, v3) -> (* BitMatcherDecided *)
        v3
let v0 : US0 = US0_BitOne
let v1 : US0 = US0_BitOne
let v2 : US0 = US0_BitZero
let v3 : UH0 = UH0_InputEmpty
let v4 : UH0 = UH0_InputCons(v2, v3)
let v5 : UH0 = UH0_InputCons(v1, v4)
let v6 : UH0 = UH0_InputCons(v0, v5)
let v7 : US0 = US0_BitOne
let v8 : US0 = US0_BitOne
let v9 : US0 = US0_BitOne
let v10 : UH0 = UH0_InputEmpty
let v11 : UH0 = UH0_InputCons(v9, v10)
let v12 : UH0 = UH0_InputCons(v8, v11)
let v13 : UH0 = UH0_InputCons(v7, v12)
let v14 : US1 = US1_TriA
let v15 : US1 = US1_TriA
let v16 : US1 = US1_TriA
let v17 : UH1 = UH1_InputEmpty
let v18 : UH1 = UH1_InputCons(v16, v17)
let v19 : UH1 = UH1_InputCons(v15, v18)
let v20 : UH1 = UH1_InputCons(v14, v19)
let v21 : US1 = US1_TriA
let v22 : US1 = US1_TriA
let v23 : US1 = US1_TriB
let v24 : UH1 = UH1_InputEmpty
let v25 : UH1 = UH1_InputCons(v23, v24)
let v26 : UH1 = UH1_InputCons(v22, v25)
let v27 : UH1 = UH1_InputCons(v21, v26)
let v28 : US0 = US0_BitZero
let v29 : UH2 = UH2_RegexChar(v28)
let v30 : US0 = US0_BitOne
let v31 : UH2 = UH2_RegexChar(v30)
let v32 : UH2 = UH2_RegexAlt(v29, v31)
let v33 : UH2 = UH2_RegexStar(v32)
let v34 : US0 = US0_BitZero
let v35 : UH2 = UH2_RegexChar(v34)
let v36 : UH2 = UH2_RegexCat(v33, v35)
let v37 : bool = accepts_0(v36, v6)
if v37 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v38 : US0 = US0_BitZero
let v39 : UH2 = UH2_RegexChar(v38)
let v40 : US0 = US0_BitOne
let v41 : UH2 = UH2_RegexChar(v40)
let v42 : UH2 = UH2_RegexAlt(v39, v41)
let v43 : UH2 = UH2_RegexStar(v42)
let v44 : US0 = US0_BitZero
let v45 : UH2 = UH2_RegexChar(v44)
let v46 : UH2 = UH2_RegexCat(v43, v45)
let v47 : bool = accepts_0(v46, v13)
if v47 then
    failwith<unit> "brzozowski-expected-false"
let v48 : US1 = US1_TriA
let v49 : UH3 = UH3_RegexChar(v48)
let v50 : UH3 = UH3_RegexStar(v49)
let v51 : bool = accepts_11(v50, v20)
if v51 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v52 : US1 = US1_TriA
let v53 : UH3 = UH3_RegexChar(v52)
let v54 : UH3 = UH3_RegexStar(v53)
let v55 : bool = accepts_11(v54, v27)
if v55 then
    failwith<unit> "brzozowski-expected-false"
let v56 : US0 = US0_BitZero
let v57 : UH2 = UH2_RegexChar(v56)
let v58 : US0 = US0_BitOne
let v59 : UH2 = UH2_RegexChar(v58)
let v60 : UH2 = UH2_RegexAlt(v57, v59)
let v61 : UH2 = UH2_RegexStar(v60)
let v62 : US0 = US0_BitZero
let v63 : UH2 = UH2_RegexChar(v62)
let v64 : UH2 = UH2_RegexCat(v61, v63)
let v65 : US4 = US4_BitMatcherRaw(v64, v6)
let v66 : US5 = decide_bit_match_22(v65)
let v67 : US0 = US0_BitZero
let v68 : UH2 = UH2_RegexChar(v67)
let v69 : US0 = US0_BitOne
let v70 : UH2 = UH2_RegexChar(v69)
let v71 : UH2 = UH2_RegexAlt(v68, v70)
let v72 : UH2 = UH2_RegexStar(v71)
let v73 : US0 = US0_BitZero
let v74 : UH2 = UH2_RegexChar(v73)
let v75 : UH2 = UH2_RegexCat(v72, v74)
let v76 : US4 = US4_BitMatcherRaw(v75, v13)
let v77 : US5 = decide_bit_match_22(v76)
let v78 : bool = bit_match_value_23(v66)
if v78 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v79 : bool = bit_match_value_23(v77)
if v79 then
    failwith<unit> "brzozowski-expected-false"
0
