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
and UH1 =
    | UH1_InputEmpty
    | UH1_InputCons of US0 * UH1
and [<Struct>] US1 =
    | US1_SymbolLess
    | US1_SymbolSame
    | US1_SymbolGreater
and [<Struct>] US2 =
    | US2_Nullable
    | US2_NonNullable
and [<Struct>] US3 =
    | US3_TriA
    | US3_TriB
    | US3_TriC
and UH2 =
    | UH2_RegexEmpty
    | UH2_RegexEpsilon
    | UH2_RegexChar of US3
    | UH2_RegexAlt of UH2 * UH2
    | UH2_RegexCat of UH2 * UH2
    | UH2_RegexStar of UH2
and UH3 =
    | UH3_InputEmpty
    | UH3_InputCons of US3 * UH3
let rec regex_compare_5 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = regex_compare_5(v53, v55)
            match v57 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_5(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_SymbolGreater
    | UH0_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US1 = regex_compare_5(v28, v34)
            match v36 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_5(v29, v35)
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
            regex_compare_5(v44, v48)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_4 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_5(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH0 = alt_insert_sorted_4(v0, v3)
            UH0_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_5(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH0_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_3 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = alt_insert_sorted_4(v2, v1)
        make_alt_3(v3, v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_4(v0, v1)
and regex_equal_7 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_7(v18, v20)
            if v22 then
                regex_equal_7(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_7(v26, v28)
            if v30 then
                regex_equal_7(v27, v29)
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
            regex_equal_7(v34, v35)
        | _ ->
            false
and make_cat_6 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = make_cat_6(v13, v1)
                        UH0_RegexCat(v12, v14)
                    | UH0_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_7(v4, v5)
                            if v6 then
                                UH0_RegexStar(v4)
                            else
                                UH0_RegexCat(v0, v1)
                        | _ ->
                            UH0_RegexCat(v0, v1)
                    | _ ->
                        UH0_RegexCat(v0, v1)
and make_star_8 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEpsilon
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v3) -> (* RegexStar *)
        UH0_RegexStar(v3)
    | _ ->
        UH0_RegexStar(v0)
and normalize_2 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = normalize_2(v5)
        let v8 : UH0 = normalize_2(v6)
        make_alt_3(v7, v8)
    | UH0_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = normalize_2(v10)
        let v13 : UH0 = normalize_2(v11)
        make_cat_6(v12, v13)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        UH0_RegexChar(v3)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEmpty
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH0 = normalize_2(v15)
        make_star_8(v16)
and nullable_10 (v0 : UH0) : US2 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_10(v5)
        let v8 : US2 = nullable_10(v6)
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
        let v18 : US2 = nullable_10(v16)
        let v19 : US2 = nullable_10(v17)
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
and derivative_9 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_9(v19, v1)
        let v22 : UH0 = derivative_9(v20, v1)
        make_alt_3(v21, v22)
    | UH0_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_10(v24)
        match v26 with
        | US2_NonNullable -> (* NonNullable *)
            let v31 : UH0 = derivative_9(v24, v1)
            make_cat_6(v31, v25)
        | US2_Nullable -> (* Nullable *)
            let v27 : UH0 = derivative_9(v24, v1)
            let v28 : UH0 = make_cat_6(v27, v25)
            let v29 : UH0 = derivative_9(v25, v1)
            make_alt_3(v28, v29)
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
        let v36 : UH0 = derivative_9(v35, v1)
        let v37 : UH0 = make_star_8(v35)
        make_cat_6(v36, v37)
and canonical_derivative_1 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_2(v0)
    let v3 : UH0 = derivative_9(v2, v1)
    normalize_2(v3)
and accepts_0 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH0 = canonical_derivative_1(v0, v6)
        accepts_0(v8, v7)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : UH0 = normalize_2(v0)
        let v3 : US2 = nullable_10(v2)
        match v3 with
        | US2_NonNullable -> (* NonNullable *)
            false
        | US2_Nullable -> (* Nullable *)
            true
and regex_compare_16 (v0 : UH2, v1 : UH2) : US1 =
    match v0 with
    | UH2_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = regex_compare_16(v59, v61)
            match v63 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_16(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_SymbolGreater
    | UH2_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US1 = regex_compare_16(v34, v40)
            match v42 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_16(v35, v41)
            | _ ->
                v42
        | UH2_RegexChar(v38) -> (* RegexChar *)
            US1_SymbolGreater
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH2_RegexChar(v10) -> (* RegexChar *)
        match v1 with
        | UH2_RegexChar(v13) -> (* RegexChar *)
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
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolGreater
        | _ ->
            US1_SymbolLess
    | UH2_RegexEmpty -> (* RegexEmpty *)
        match v1 with
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        match v1 with
        | UH2_RegexEmpty -> (* RegexEmpty *)
            US1_SymbolGreater
        | UH2_RegexEpsilon -> (* RegexEpsilon *)
            US1_SymbolSame
        | _ ->
            US1_SymbolLess
    | UH2_RegexStar(v50) -> (* RegexStar *)
        match v1 with
        | UH2_RegexAlt(v51, v52) -> (* RegexAlt *)
            US1_SymbolLess
        | UH2_RegexStar(v54) -> (* RegexStar *)
            regex_compare_16(v50, v54)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_15 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_16(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH2 = alt_insert_sorted_15(v0, v3)
            UH2_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_16(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH2_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_14 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = alt_insert_sorted_15(v2, v1)
        make_alt_14(v3, v4)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_15(v0, v1)
and regex_equal_18 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_18(v24, v26)
            if v28 then
                regex_equal_18(v25, v27)
            else
                false
        | _ ->
            false
    | UH2_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_18(v32, v34)
            if v36 then
                regex_equal_18(v33, v35)
            else
                false
        | _ ->
            false
    | UH2_RegexChar(v4) -> (* RegexChar *)
        match v1 with
        | UH2_RegexChar(v5) -> (* RegexChar *)
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
    | UH2_RegexStar(v40) -> (* RegexStar *)
        match v1 with
        | UH2_RegexStar(v41) -> (* RegexStar *)
            regex_equal_18(v40, v41)
        | _ ->
            false
and make_cat_17 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = make_cat_17(v13, v1)
                        UH2_RegexCat(v12, v14)
                    | UH2_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_18(v4, v5)
                            if v6 then
                                UH2_RegexStar(v4)
                            else
                                UH2_RegexCat(v0, v1)
                        | _ ->
                            UH2_RegexCat(v0, v1)
                    | _ ->
                        UH2_RegexCat(v0, v1)
and make_star_19 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEpsilon
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v3) -> (* RegexStar *)
        UH2_RegexStar(v3)
    | _ ->
        UH2_RegexStar(v0)
and normalize_13 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = normalize_13(v5)
        let v8 : UH2 = normalize_13(v6)
        make_alt_14(v7, v8)
    | UH2_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = normalize_13(v10)
        let v13 : UH2 = normalize_13(v11)
        make_cat_17(v12, v13)
    | UH2_RegexChar(v3) -> (* RegexChar *)
        UH2_RegexChar(v3)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH2 = normalize_13(v15)
        make_star_19(v16)
and nullable_21 (v0 : UH2) : US2 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_21(v5)
        let v8 : US2 = nullable_21(v6)
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
    | UH2_RegexCat(v16, v17) -> (* RegexCat *)
        let v18 : US2 = nullable_21(v16)
        let v19 : US2 = nullable_21(v17)
        match v18 with
        | US2_Nullable -> (* Nullable *)
            match v19 with
            | US2_Nullable -> (* Nullable *)
                US2_Nullable
            | _ ->
                US2_NonNullable
        | _ ->
            US2_NonNullable
    | UH2_RegexChar(v3) -> (* RegexChar *)
        US2_NonNullable
    | UH2_RegexEmpty -> (* RegexEmpty *)
        US2_NonNullable
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        US2_Nullable
    | UH2_RegexStar(v25) -> (* RegexStar *)
        US2_Nullable
and derivative_20 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = derivative_20(v25, v1)
        let v28 : UH2 = derivative_20(v26, v1)
        make_alt_14(v27, v28)
    | UH2_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_21(v30)
        match v32 with
        | US2_NonNullable -> (* NonNullable *)
            let v37 : UH2 = derivative_20(v30, v1)
            make_cat_17(v37, v31)
        | US2_Nullable -> (* Nullable *)
            let v33 : UH2 = derivative_20(v30, v1)
            let v34 : UH2 = make_cat_17(v33, v31)
            let v35 : UH2 = derivative_20(v31, v1)
            make_alt_14(v34, v35)
    | UH2_RegexChar(v4) -> (* RegexChar *)
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
            UH2_RegexEpsilon
        else
            UH2_RegexEmpty
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEmpty
    | UH2_RegexStar(v41) -> (* RegexStar *)
        let v42 : UH2 = derivative_20(v41, v1)
        let v43 : UH2 = make_star_19(v41)
        make_cat_17(v42, v43)
and canonical_derivative_12 (v0 : UH2, v1 : US3) : UH2 =
    let v2 : UH2 = normalize_13(v0)
    let v3 : UH2 = derivative_20(v2, v1)
    normalize_13(v3)
and accepts_11 (v0 : UH2, v1 : UH3) : bool =
    match v1 with
    | UH3_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH2 = canonical_derivative_12(v0, v6)
        accepts_11(v8, v7)
    | UH3_InputEmpty -> (* InputEmpty *)
        let v2 : UH2 = normalize_13(v0)
        let v3 : US2 = nullable_21(v2)
        match v3 with
        | US2_NonNullable -> (* NonNullable *)
            false
        | US2_Nullable -> (* Nullable *)
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
let v9 : US0 = US0_BitOne
let v10 : US0 = US0_BitOne
let v11 : US0 = US0_BitZero
let v12 : UH1 = UH1_InputEmpty
let v13 : UH1 = UH1_InputCons(v11, v12)
let v14 : UH1 = UH1_InputCons(v10, v13)
let v15 : UH1 = UH1_InputCons(v9, v14)
let v16 : bool = accepts_0(v8, v15)
let v17 : US3 = US3_TriA
let v18 : UH2 = UH2_RegexChar(v17)
let v19 : UH2 = UH2_RegexStar(v18)
let v20 : US3 = US3_TriA
let v21 : US3 = US3_TriA
let v22 : US3 = US3_TriA
let v23 : UH3 = UH3_InputEmpty
let v24 : UH3 = UH3_InputCons(v22, v23)
let v25 : UH3 = UH3_InputCons(v21, v24)
let v26 : UH3 = UH3_InputCons(v20, v25)
let v27 : bool = accepts_11(v19, v26)
let v28 : bool = v16 && v27
let v29 : bool = v28 && v16
let v30 : bool = v29 && v27
v30
