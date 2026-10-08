type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0
    | UH0_1 of US0 * UH0
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and UH1 =
    | UH1_0
    | UH1_1 of US1 * UH1
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US0
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and [<Struct>] US2 =
    | US2_0
    | US2_1
and UH3 =
    | UH3_0
    | UH3_1
    | UH3_2 of US1
    | UH3_3 of UH3 * UH3
    | UH3_4 of UH3 * UH3
    | UH3_5 of UH3
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
and UH4 =
    | UH4_0
    | UH4_1 of US0 * UH4
and UH5 =
    | UH5_0
    | UH5_1 of UH0 * UH5
and UH6 =
    | UH6_0
    | UH6_1 of US1 * UH6
and UH7 =
    | UH7_0
    | UH7_1 of UH1 * UH7
and UH8 =
    | UH8_0
    | UH8_1 of UH8
and UH9 =
    | UH9_0
    | UH9_1 of UH2 * UH9
and [<Struct>] US4 =
    | US4_0 of f0_0 : UH9
    | US4_1 of f1_0 : UH9
and UH10 =
    | UH10_0
    | UH10_1 of UH3 * UH10
and UH11 =
    | UH11_0
    | UH11_1 of UH2 * UH2 * UH11
and UH12 =
    | UH12_0
    | UH12_1 of UH3 * UH3 * UH12
and [<Struct>] US5 =
    | US5_0 of f0_0 : UH2 * f0_1 : UH0
and [<Struct>] US6 =
    | US6_0 of f0_0 : UH2 * f0_1 : UH0 * f0_2 : bool
and UH13 =
    | UH13_0
    | UH13_1 of UH2 * US0 * UH2 * UH13
and [<Struct>] US7 =
    | US7_0 of f0_0 : UH2
    | US7_1
and [<Struct>] US8 =
    | US8_0 of f0_0 : UH10
    | US8_1 of f1_0 : UH10
and UH14 =
    | UH14_0
    | UH14_1 of UH3 * US1 * UH3 * UH14
and [<Struct>] US9 =
    | US9_0 of f0_0 : UH3
    | US9_1
and [<Struct>] US10 =
    | US10_0 of f0_0 : UH2
    | US10_1
and [<Struct>] US11 =
    | US11_0 of f0_0 : UH3
    | US11_1
and [<Struct>] US12 =
    | US12_0
    | US12_1
    | US12_2
let rec nullable_0 (v0 : UH2) : US2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_0(v5)
        let v8 : US2 = nullable_0(v6)
        match v7 with
        | US2_0 -> (* Nullable *)
            US2_0
        | _ ->
            match v8 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                match v7 with
                | US2_1 -> (* NonNullable *)
                    match v8 with
                    | US2_1 -> (* NonNullable *)
                        US2_1
    | UH2_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = nullable_0(v16)
        let v19 : US2 = nullable_0(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH2_2(v3) -> (* RegexChar *)
        US2_1
    | UH2_0 -> (* RegexEmpty *)
        US2_1
    | UH2_1 -> (* RegexEpsilon *)
        US2_0
    | UH2_5(v25) -> (* RegexStar *)
        US2_0
and nullable_1 (v0 : UH3) : US2 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_1(v5)
        let v8 : US2 = nullable_1(v6)
        match v7 with
        | US2_0 -> (* Nullable *)
            US2_0
        | _ ->
            match v8 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                match v7 with
                | US2_1 -> (* NonNullable *)
                    match v8 with
                    | US2_1 -> (* NonNullable *)
                        US2_1
    | UH3_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = nullable_1(v16)
        let v19 : US2 = nullable_1(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH3_2(v3) -> (* RegexChar *)
        US2_1
    | UH3_0 -> (* RegexEmpty *)
        US2_1
    | UH3_1 -> (* RegexEpsilon *)
        US2_0
    | UH3_5(v25) -> (* RegexStar *)
        US2_0
and regex_compare_7 (v0 : UH2, v1 : UH2) : US3 =
    match v0 with
    | UH2_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v55, v56) -> (* RegexAlt *)
            let v57 : US3 = regex_compare_7(v53, v55)
            match v57 with
            | US3_1 -> (* SymbolSame *)
                regex_compare_7(v54, v56)
            | _ ->
                v57
        | _ ->
            US3_2
    | UH2_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : US3 = regex_compare_7(v28, v34)
            match v36 with
            | US3_1 -> (* SymbolSame *)
                regex_compare_7(v29, v35)
            | _ ->
                v36
        | UH2_2(v32) -> (* RegexChar *)
            US3_2
        | UH2_0 -> (* RegexEmpty *)
            US3_2
        | UH2_1 -> (* RegexEpsilon *)
            US3_2
        | _ ->
            US3_0
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US3_1
                | US0_0 -> (* BitZero *)
                    US3_2
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US3_0
                | US0_0 -> (* BitZero *)
                    US3_1
        | UH2_0 -> (* RegexEmpty *)
            US3_2
        | UH2_1 -> (* RegexEpsilon *)
            US3_2
        | _ ->
            US3_0
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US3_1
        | _ ->
            US3_0
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US3_2
        | UH2_1 -> (* RegexEpsilon *)
            US3_1
        | _ ->
            US3_0
    | UH2_5(v44) -> (* RegexStar *)
        match v1 with
        | UH2_3(v45, v46) -> (* RegexAlt *)
            US3_0
        | UH2_5(v48) -> (* RegexStar *)
            regex_compare_7(v44, v48)
        | _ ->
            US3_2
and alt_insert_sorted_6 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US3 = regex_compare_7(v0, v2)
        match v4 with
        | US3_2 -> (* SymbolGreater *)
            let v6 : UH2 = alt_insert_sorted_6(v0, v3)
            UH2_3(v2, v6)
        | US3_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US3_1 -> (* SymbolSame *)
            v1
    | UH2_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US3 = regex_compare_7(v0, v1)
        match v11 with
        | US3_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
        | US3_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US3_1 -> (* SymbolSame *)
            v1
and make_alt_5 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = alt_insert_sorted_6(v2, v1)
        make_alt_5(v3, v4)
    | UH2_0 -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_6(v0, v1)
and regex_equal_9 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_9(v18, v20)
            if v22 then
                regex_equal_9(v19, v21)
            else
                false
        | _ ->
            false
    | UH2_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH2_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_9(v26, v28)
            if v30 then
                regex_equal_9(v27, v29)
            else
                false
        | _ ->
            false
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
            let v15 : US3 =
                match v4 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US3_1
                    | US0_0 -> (* BitZero *)
                        US3_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US3_0
                    | US0_0 -> (* BitZero *)
                        US3_1
            match v15 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH2_5(v34) -> (* RegexStar *)
        match v1 with
        | UH2_5(v35) -> (* RegexStar *)
            regex_equal_9(v34, v35)
        | _ ->
            false
and make_cat_8 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | _ ->
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            UH2_0
        | _ ->
            match v0 with
            | UH2_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH2_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH2_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH2 = make_cat_8(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_9(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and make_star_10 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and normalize_4 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = normalize_4(v5)
        let v8 : UH2 = normalize_4(v6)
        make_alt_5(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = normalize_4(v10)
        let v13 : UH2 = normalize_4(v11)
        make_cat_8(v12, v13)
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = normalize_4(v15)
        make_star_10(v16)
and derivative_11 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH2 = derivative_11(v19, v1)
        let v22 : UH2 = derivative_11(v20, v1)
        make_alt_5(v21, v22)
    | UH2_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_0(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH2 = derivative_11(v24, v1)
            make_cat_8(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH2 = derivative_11(v24, v1)
            let v28 : UH2 = make_cat_8(v27, v25)
            let v29 : UH2 = derivative_11(v25, v1)
            make_alt_5(v28, v29)
    | UH2_2(v4) -> (* RegexChar *)
        let v14 : US3 =
            match v4 with
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US3_1
                | US0_0 -> (* BitZero *)
                    US3_2
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US3_0
                | US0_0 -> (* BitZero *)
                    US3_1
        let v15 : bool =
            match v14 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH2 = derivative_11(v35, v1)
        let v37 : UH2 = make_star_10(v35)
        make_cat_8(v36, v37)
and canonical_derivative_3 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = normalize_4(v0)
    let v3 : UH2 = derivative_11(v2, v1)
    normalize_4(v3)
and accepts_2 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v6, v7) -> (* InputCons *)
        let v8 : UH2 = canonical_derivative_3(v0, v6)
        accepts_2(v8, v7)
    | UH0_0 -> (* InputEmpty *)
        let v2 : UH2 = normalize_4(v0)
        let v3 : US2 = nullable_0(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and regex_compare_17 (v0 : UH3, v1 : UH3) : US3 =
    match v0 with
    | UH3_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v61, v62) -> (* RegexAlt *)
            let v63 : US3 = regex_compare_17(v59, v61)
            match v63 with
            | US3_1 -> (* SymbolSame *)
                regex_compare_17(v60, v62)
            | _ ->
                v63
        | _ ->
            US3_2
    | UH3_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH3_4(v40, v41) -> (* RegexCat *)
            let v42 : US3 = regex_compare_17(v34, v40)
            match v42 with
            | US3_1 -> (* SymbolSame *)
                regex_compare_17(v35, v41)
            | _ ->
                v42
        | UH3_2(v38) -> (* RegexChar *)
            US3_2
        | UH3_0 -> (* RegexEmpty *)
            US3_2
        | UH3_1 -> (* RegexEpsilon *)
            US3_2
        | _ ->
            US3_0
    | UH3_2(v10) -> (* RegexChar *)
        match v1 with
        | UH3_2(v13) -> (* RegexChar *)
            match v10 with
            | US1_0 -> (* TriA *)
                match v13 with
                | US1_0 -> (* TriA *)
                    US3_1
                | _ ->
                    US3_0
            | _ ->
                match v13 with
                | US1_0 -> (* TriA *)
                    US3_2
                | _ ->
                    match v10 with
                    | US1_1 -> (* TriB *)
                        match v13 with
                        | US1_1 -> (* TriB *)
                            US3_1
                        | US1_2 -> (* TriC *)
                            US3_0
                    | US1_2 -> (* TriC *)
                        match v13 with
                        | US1_1 -> (* TriB *)
                            US3_2
                        | US1_2 -> (* TriC *)
                            US3_1
        | UH3_0 -> (* RegexEmpty *)
            US3_2
        | UH3_1 -> (* RegexEpsilon *)
            US3_2
        | _ ->
            US3_0
    | UH3_0 -> (* RegexEmpty *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US3_1
        | _ ->
            US3_0
    | UH3_1 -> (* RegexEpsilon *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US3_2
        | UH3_1 -> (* RegexEpsilon *)
            US3_1
        | _ ->
            US3_0
    | UH3_5(v50) -> (* RegexStar *)
        match v1 with
        | UH3_3(v51, v52) -> (* RegexAlt *)
            US3_0
        | UH3_5(v54) -> (* RegexStar *)
            regex_compare_17(v50, v54)
        | _ ->
            US3_2
and alt_insert_sorted_16 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : US3 = regex_compare_17(v0, v2)
        match v4 with
        | US3_2 -> (* SymbolGreater *)
            let v6 : UH3 = alt_insert_sorted_16(v0, v3)
            UH3_3(v2, v6)
        | US3_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US3_1 -> (* SymbolSame *)
            v1
    | UH3_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US3 = regex_compare_17(v0, v1)
        match v11 with
        | US3_2 -> (* SymbolGreater *)
            UH3_3(v1, v0)
        | US3_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US3_1 -> (* SymbolSame *)
            v1
and make_alt_15 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH3 = alt_insert_sorted_16(v2, v1)
        make_alt_15(v3, v4)
    | UH3_0 -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_16(v0, v1)
and regex_equal_19 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_19(v24, v26)
            if v28 then
                regex_equal_19(v25, v27)
            else
                false
        | _ ->
            false
    | UH3_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH3_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_19(v32, v34)
            if v36 then
                regex_equal_19(v33, v35)
            else
                false
        | _ ->
            false
    | UH3_2(v4) -> (* RegexChar *)
        match v1 with
        | UH3_2(v5) -> (* RegexChar *)
            let v21 : US3 =
                match v4 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US3_1
                    | _ ->
                        US3_0
                | _ ->
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US3_2
                    | _ ->
                        match v4 with
                        | US1_1 -> (* TriB *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US3_1
                            | US1_2 -> (* TriC *)
                                US3_0
                        | US1_2 -> (* TriC *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US3_2
                            | US1_2 -> (* TriC *)
                                US3_1
            match v21 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH3_0 -> (* RegexEmpty *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH3_1 -> (* RegexEpsilon *)
        match v1 with
        | UH3_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH3_5(v40) -> (* RegexStar *)
        match v1 with
        | UH3_5(v41) -> (* RegexStar *)
            regex_equal_19(v40, v41)
        | _ ->
            false
and make_cat_18 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | _ ->
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            UH3_0
        | _ ->
            match v0 with
            | UH3_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH3_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH3_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH3 = make_cat_18(v13, v1)
                        UH3_4(v12, v14)
                    | UH3_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH3_5(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_19(v4, v5)
                            if v6 then
                                UH3_5(v4)
                            else
                                UH3_4(v0, v1)
                        | _ ->
                            UH3_4(v0, v1)
                    | _ ->
                        UH3_4(v0, v1)
and make_star_20 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_1
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v3) -> (* RegexStar *)
        UH3_5(v3)
    | _ ->
        UH3_5(v0)
and normalize_14 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH3 = normalize_14(v5)
        let v8 : UH3 = normalize_14(v6)
        make_alt_15(v7, v8)
    | UH3_4(v10, v11) -> (* RegexCat *)
        let v12 : UH3 = normalize_14(v10)
        let v13 : UH3 = normalize_14(v11)
        make_cat_18(v12, v13)
    | UH3_2(v3) -> (* RegexChar *)
        UH3_2(v3)
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v15) -> (* RegexStar *)
        let v16 : UH3 = normalize_14(v15)
        make_star_20(v16)
and derivative_21 (v0 : UH3, v1 : US1) : UH3 =
    match v0 with
    | UH3_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH3 = derivative_21(v25, v1)
        let v28 : UH3 = derivative_21(v26, v1)
        make_alt_15(v27, v28)
    | UH3_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_1(v30)
        match v32 with
        | US2_1 -> (* NonNullable *)
            let v37 : UH3 = derivative_21(v30, v1)
            make_cat_18(v37, v31)
        | US2_0 -> (* Nullable *)
            let v33 : UH3 = derivative_21(v30, v1)
            let v34 : UH3 = make_cat_18(v33, v31)
            let v35 : UH3 = derivative_21(v31, v1)
            make_alt_15(v34, v35)
    | UH3_2(v4) -> (* RegexChar *)
        let v20 : US3 =
            match v4 with
            | US1_0 -> (* TriA *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US3_1
                | _ ->
                    US3_0
            | _ ->
                match v1 with
                | US1_0 -> (* TriA *)
                    US3_2
                | _ ->
                    match v4 with
                    | US1_1 -> (* TriB *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US3_1
                        | US1_2 -> (* TriC *)
                            US3_0
                    | US1_2 -> (* TriC *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US3_2
                        | US1_2 -> (* TriC *)
                            US3_1
        let v21 : bool =
            match v20 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH3_1
        else
            UH3_0
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_5(v41) -> (* RegexStar *)
        let v42 : UH3 = derivative_21(v41, v1)
        let v43 : UH3 = make_star_20(v41)
        make_cat_18(v42, v43)
and canonical_derivative_13 (v0 : UH3, v1 : US1) : UH3 =
    let v2 : UH3 = normalize_14(v0)
    let v3 : UH3 = derivative_21(v2, v1)
    normalize_14(v3)
and accepts_12 (v0 : UH3, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v6, v7) -> (* InputCons *)
        let v8 : UH3 = canonical_derivative_13(v0, v6)
        accepts_12(v8, v7)
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH3 = normalize_14(v0)
        let v3 : US2 = nullable_1(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and input_suffixes_22 (v0 : UH0) : UH5 =
    match v0 with
    | UH0_1(v4, v5) -> (* InputCons *)
        let v6 : UH5 = input_suffixes_22(v5)
        UH5_1(v0, v6)
    | UH0_0 -> (* InputEmpty *)
        let v1 : UH0 = UH0_0
        let v2 : UH5 = UH5_0
        UH5_1(v1, v2)
and reference_derivative_26 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH2 = reference_derivative_26(v19, v1)
        let v22 : UH2 = reference_derivative_26(v20, v1)
        UH2_3(v21, v22)
    | UH2_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_0(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH2 = reference_derivative_26(v24, v1)
            UH2_4(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH2 = reference_derivative_26(v24, v1)
            let v28 : UH2 = reference_derivative_26(v25, v1)
            let v29 : UH2 = UH2_4(v27, v25)
            UH2_3(v29, v28)
    | UH2_2(v4) -> (* RegexChar *)
        let v14 : US3 =
            match v4 with
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US3_1
                | US0_0 -> (* BitZero *)
                    US3_2
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US3_0
                | US0_0 -> (* BitZero *)
                    US3_1
        let v15 : bool =
            match v14 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH2 = reference_derivative_26(v35, v1)
        let v37 : UH2 = UH2_5(v35)
        UH2_4(v36, v37)
and input_list_append_28 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : UH5 = input_list_append_28(v3, v1)
        UH5_1(v2, v4)
    | UH5_0 -> (* InputListNil *)
        v1
and consume_right_29 (v0 : UH2, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = language_remainders_27(v0, v3)
        let v6 : UH5 = consume_right_29(v0, v4)
        input_list_append_28(v5, v6)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and input_equal_33 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH0_1(v5, v6) -> (* InputCons *)
            let v16 : US3 =
                match v3 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US3_1
                    | US0_0 -> (* BitZero *)
                        US3_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US3_0
                    | US0_0 -> (* BitZero *)
                        US3_1
            let v17 : bool =
                match v16 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                input_equal_33(v4, v6)
            else
                false
        | _ ->
            false
    | UH0_0 -> (* InputEmpty *)
        match v1 with
        | UH0_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and input_list_contains_32 (v0 : UH0, v1 : UH5) : bool =
    match v1 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_33(v0, v2)
        if v4 then
            true
        else
            input_list_contains_32(v0, v3)
    | UH5_0 -> (* InputListNil *)
        false
and input_list_enqueue_new_31 (v0 : UH5, v1 : UH5, v2 : UH5) : struct (UH5 * UH5) =
    match v0 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_32(v3, v1)
        if v5 then
            input_list_enqueue_new_31(v4, v1, v2)
        else
            let v8 : UH5 = UH5_1(v3, v1)
            let v9 : UH5 = UH5_1(v3, v2)
            input_list_enqueue_new_31(v4, v8, v9)
    | UH5_0 -> (* InputListNil *)
        struct (v1, v2)
and closure_30 (v0 : UH2, v1 : UH5, v2 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = language_remainders_27(v0, v3)
        let struct (v6 : UH5, v7 : UH5) = input_list_enqueue_new_31(v5, v2, v4)
        closure_30(v0, v7, v6)
    | UH5_0 -> (* InputListNil *)
        v2
and language_remainders_27 (v0 : UH2, v1 : UH0) : UH5 =
    match v0 with
    | UH2_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH5 = language_remainders_27(v26, v1)
        let v29 : UH5 = language_remainders_27(v27, v1)
        input_list_append_28(v28, v29)
    | UH2_4(v31, v32) -> (* RegexCat *)
        let v33 : UH5 = language_remainders_27(v31, v1)
        consume_right_29(v32, v33)
    | UH2_2(v5) -> (* RegexChar *)
        match v1 with
        | UH0_1(v7, v8) -> (* InputCons *)
            let v18 : US3 =
                match v5 with
                | US0_1 -> (* BitOne *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US3_1
                    | US0_0 -> (* BitZero *)
                        US3_2
                | US0_0 -> (* BitZero *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US3_0
                    | US0_0 -> (* BitZero *)
                        US3_1
            let v19 : bool =
                match v18 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH5 = UH5_0
                UH5_1(v8, v20)
            else
                UH5_0
        | UH0_0 -> (* InputEmpty *)
            UH5_0
    | UH2_0 -> (* RegexEmpty *)
        UH5_0
    | UH2_1 -> (* RegexEpsilon *)
        let v3 : UH5 = UH5_0
        UH5_1(v1, v3)
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH5 = UH5_0
        let v37 : UH5 = UH5_1(v1, v36)
        let v38 : UH5 = UH5_0
        let v39 : UH5 = UH5_1(v1, v38)
        closure_30(v35, v37, v39)
and input_list_remove_34 (v0 : UH0, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_equal_33(v0, v3)
        if v5 then
            input_list_remove_34(v0, v4)
        else
            let v7 : UH5 = input_list_remove_34(v0, v4)
            UH5_1(v3, v7)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and input_list_subset_35 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_list_contains_32(v2, v1)
        if v4 then
            input_list_subset_35(v3, v1)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
and derivative_semantic_triangle_25 (v0 : UH2, v1 : US0, v2 : UH0) : bool =
    let v3 : UH2 = canonical_derivative_3(v0, v1)
    let v4 : UH2 = reference_derivative_26(v0, v1)
    let v5 : UH0 = UH0_1(v1, v2)
    let v6 : UH0 = UH0_1(v1, v2)
    let v7 : UH5 = language_remainders_27(v0, v6)
    let v8 : UH5 = input_list_remove_34(v5, v7)
    let v9 : UH5 = language_remainders_27(v3, v2)
    let v10 : bool = input_list_subset_35(v8, v9)
    let v12 : bool =
        if v10 then
            input_list_subset_35(v9, v8)
        else
            false
    if v12 then
        let v13 : UH0 = UH0_1(v1, v2)
        let v14 : UH0 = UH0_1(v1, v2)
        let v15 : UH5 = language_remainders_27(v0, v14)
        let v16 : UH5 = input_list_remove_34(v13, v15)
        let v17 : UH5 = language_remainders_27(v4, v2)
        let v18 : bool = input_list_subset_35(v16, v17)
        let v20 : bool =
            if v18 then
                input_list_subset_35(v17, v16)
            else
                false
        if v20 then
            let v21 : UH2 = normalize_4(v4)
            let v22 : bool = regex_equal_9(v3, v21)
            if v22 then
                match v0 with
                | UH2_3(v24, v25) -> (* RegexAlt *)
                    let v26 : bool = derivative_semantic_triangle_25(v24, v1, v2)
                    if v26 then
                        derivative_semantic_triangle_25(v25, v1, v2)
                    else
                        false
                | UH2_4(v29, v30) -> (* RegexCat *)
                    let v31 : bool = derivative_semantic_triangle_25(v29, v1, v2)
                    if v31 then
                        derivative_semantic_triangle_25(v30, v1, v2)
                    else
                        false
                | UH2_2(v23) -> (* RegexChar *)
                    true
                | UH2_0 -> (* RegexEmpty *)
                    true
                | UH2_1 -> (* RegexEpsilon *)
                    true
                | UH2_5(v34) -> (* RegexStar *)
                    derivative_semantic_triangle_25(v34, v1, v2)
            else
                false
        else
            false
    else
        false
and derivative_semantic_triangle_suffixes_24 (v0 : UH2, v1 : US0, v2 : UH5) : bool =
    match v2 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = derivative_semantic_triangle_25(v0, v1, v3)
        if v5 then
            derivative_semantic_triangle_suffixes_24(v0, v1, v4)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
and derivative_semantic_triangle_symbols_23 (v0 : UH2, v1 : UH4, v2 : UH5) : bool =
    match v1 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = derivative_semantic_triangle_suffixes_24(v0, v3, v2)
        if v5 then
            derivative_semantic_triangle_symbols_23(v0, v4, v2)
        else
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and input_suffixes_36 (v0 : UH1) : UH7 =
    match v0 with
    | UH1_1(v4, v5) -> (* InputCons *)
        let v6 : UH7 = input_suffixes_36(v5)
        UH7_1(v0, v6)
    | UH1_0 -> (* InputEmpty *)
        let v1 : UH1 = UH1_0
        let v2 : UH7 = UH7_0
        UH7_1(v1, v2)
and reference_derivative_40 (v0 : UH3, v1 : US1) : UH3 =
    match v0 with
    | UH3_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH3 = reference_derivative_40(v25, v1)
        let v28 : UH3 = reference_derivative_40(v26, v1)
        UH3_3(v27, v28)
    | UH3_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_1(v30)
        match v32 with
        | US2_1 -> (* NonNullable *)
            let v37 : UH3 = reference_derivative_40(v30, v1)
            UH3_4(v37, v31)
        | US2_0 -> (* Nullable *)
            let v33 : UH3 = reference_derivative_40(v30, v1)
            let v34 : UH3 = reference_derivative_40(v31, v1)
            let v35 : UH3 = UH3_4(v33, v31)
            UH3_3(v35, v34)
    | UH3_2(v4) -> (* RegexChar *)
        let v20 : US3 =
            match v4 with
            | US1_0 -> (* TriA *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US3_1
                | _ ->
                    US3_0
            | _ ->
                match v1 with
                | US1_0 -> (* TriA *)
                    US3_2
                | _ ->
                    match v4 with
                    | US1_1 -> (* TriB *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US3_1
                        | US1_2 -> (* TriC *)
                            US3_0
                    | US1_2 -> (* TriC *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US3_2
                        | US1_2 -> (* TriC *)
                            US3_1
        let v21 : bool =
            match v20 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH3_1
        else
            UH3_0
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_5(v41) -> (* RegexStar *)
        let v42 : UH3 = reference_derivative_40(v41, v1)
        let v43 : UH3 = UH3_5(v41)
        UH3_4(v42, v43)
and input_list_append_42 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : UH7 = input_list_append_42(v3, v1)
        UH7_1(v2, v4)
    | UH7_0 -> (* InputListNil *)
        v1
and consume_right_43 (v0 : UH3, v1 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = language_remainders_41(v0, v3)
        let v6 : UH7 = consume_right_43(v0, v4)
        input_list_append_42(v5, v6)
    | UH7_0 -> (* InputListNil *)
        UH7_0
and input_equal_47 (v0 : UH1, v1 : UH1) : bool =
    match v0 with
    | UH1_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH1_1(v5, v6) -> (* InputCons *)
            let v22 : US3 =
                match v3 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US3_1
                    | _ ->
                        US3_0
                | _ ->
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US3_2
                    | _ ->
                        match v3 with
                        | US1_1 -> (* TriB *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US3_1
                            | US1_2 -> (* TriC *)
                                US3_0
                        | US1_2 -> (* TriC *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US3_2
                            | US1_2 -> (* TriC *)
                                US3_1
            let v23 : bool =
                match v22 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                input_equal_47(v4, v6)
            else
                false
        | _ ->
            false
    | UH1_0 -> (* InputEmpty *)
        match v1 with
        | UH1_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and input_list_contains_46 (v0 : UH1, v1 : UH7) : bool =
    match v1 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_47(v0, v2)
        if v4 then
            true
        else
            input_list_contains_46(v0, v3)
    | UH7_0 -> (* InputListNil *)
        false
and input_list_enqueue_new_45 (v0 : UH7, v1 : UH7, v2 : UH7) : struct (UH7 * UH7) =
    match v0 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_46(v3, v1)
        if v5 then
            input_list_enqueue_new_45(v4, v1, v2)
        else
            let v8 : UH7 = UH7_1(v3, v1)
            let v9 : UH7 = UH7_1(v3, v2)
            input_list_enqueue_new_45(v4, v8, v9)
    | UH7_0 -> (* InputListNil *)
        struct (v1, v2)
and closure_44 (v0 : UH3, v1 : UH7, v2 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = language_remainders_41(v0, v3)
        let struct (v6 : UH7, v7 : UH7) = input_list_enqueue_new_45(v5, v2, v4)
        closure_44(v0, v7, v6)
    | UH7_0 -> (* InputListNil *)
        v2
and language_remainders_41 (v0 : UH3, v1 : UH1) : UH7 =
    match v0 with
    | UH3_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH7 = language_remainders_41(v32, v1)
        let v35 : UH7 = language_remainders_41(v33, v1)
        input_list_append_42(v34, v35)
    | UH3_4(v37, v38) -> (* RegexCat *)
        let v39 : UH7 = language_remainders_41(v37, v1)
        consume_right_43(v38, v39)
    | UH3_2(v5) -> (* RegexChar *)
        match v1 with
        | UH1_1(v7, v8) -> (* InputCons *)
            let v24 : US3 =
                match v5 with
                | US1_0 -> (* TriA *)
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US3_1
                    | _ ->
                        US3_0
                | _ ->
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US3_2
                    | _ ->
                        match v5 with
                        | US1_1 -> (* TriB *)
                            match v7 with
                            | US1_1 -> (* TriB *)
                                US3_1
                            | US1_2 -> (* TriC *)
                                US3_0
                        | US1_2 -> (* TriC *)
                            match v7 with
                            | US1_1 -> (* TriB *)
                                US3_2
                            | US1_2 -> (* TriC *)
                                US3_1
            let v25 : bool =
                match v24 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH7 = UH7_0
                UH7_1(v8, v26)
            else
                UH7_0
        | UH1_0 -> (* InputEmpty *)
            UH7_0
    | UH3_0 -> (* RegexEmpty *)
        UH7_0
    | UH3_1 -> (* RegexEpsilon *)
        let v3 : UH7 = UH7_0
        UH7_1(v1, v3)
    | UH3_5(v41) -> (* RegexStar *)
        let v42 : UH7 = UH7_0
        let v43 : UH7 = UH7_1(v1, v42)
        let v44 : UH7 = UH7_0
        let v45 : UH7 = UH7_1(v1, v44)
        closure_44(v41, v43, v45)
and input_list_remove_48 (v0 : UH1, v1 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_equal_47(v0, v3)
        if v5 then
            input_list_remove_48(v0, v4)
        else
            let v7 : UH7 = input_list_remove_48(v0, v4)
            UH7_1(v3, v7)
    | UH7_0 -> (* InputListNil *)
        UH7_0
and input_list_subset_49 (v0 : UH7, v1 : UH7) : bool =
    match v0 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_list_contains_46(v2, v1)
        if v4 then
            input_list_subset_49(v3, v1)
        else
            false
    | UH7_0 -> (* InputListNil *)
        true
and derivative_semantic_triangle_39 (v0 : UH3, v1 : US1, v2 : UH1) : bool =
    let v3 : UH3 = canonical_derivative_13(v0, v1)
    let v4 : UH3 = reference_derivative_40(v0, v1)
    let v5 : UH1 = UH1_1(v1, v2)
    let v6 : UH1 = UH1_1(v1, v2)
    let v7 : UH7 = language_remainders_41(v0, v6)
    let v8 : UH7 = input_list_remove_48(v5, v7)
    let v9 : UH7 = language_remainders_41(v3, v2)
    let v10 : bool = input_list_subset_49(v8, v9)
    let v12 : bool =
        if v10 then
            input_list_subset_49(v9, v8)
        else
            false
    if v12 then
        let v13 : UH1 = UH1_1(v1, v2)
        let v14 : UH1 = UH1_1(v1, v2)
        let v15 : UH7 = language_remainders_41(v0, v14)
        let v16 : UH7 = input_list_remove_48(v13, v15)
        let v17 : UH7 = language_remainders_41(v4, v2)
        let v18 : bool = input_list_subset_49(v16, v17)
        let v20 : bool =
            if v18 then
                input_list_subset_49(v17, v16)
            else
                false
        if v20 then
            let v21 : UH3 = normalize_14(v4)
            let v22 : bool = regex_equal_19(v3, v21)
            if v22 then
                match v0 with
                | UH3_3(v24, v25) -> (* RegexAlt *)
                    let v26 : bool = derivative_semantic_triangle_39(v24, v1, v2)
                    if v26 then
                        derivative_semantic_triangle_39(v25, v1, v2)
                    else
                        false
                | UH3_4(v29, v30) -> (* RegexCat *)
                    let v31 : bool = derivative_semantic_triangle_39(v29, v1, v2)
                    if v31 then
                        derivative_semantic_triangle_39(v30, v1, v2)
                    else
                        false
                | UH3_2(v23) -> (* RegexChar *)
                    true
                | UH3_0 -> (* RegexEmpty *)
                    true
                | UH3_1 -> (* RegexEpsilon *)
                    true
                | UH3_5(v34) -> (* RegexStar *)
                    derivative_semantic_triangle_39(v34, v1, v2)
            else
                false
        else
            false
    else
        false
and derivative_semantic_triangle_suffixes_38 (v0 : UH3, v1 : US1, v2 : UH7) : bool =
    match v2 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = derivative_semantic_triangle_39(v0, v1, v3)
        if v5 then
            derivative_semantic_triangle_suffixes_38(v0, v1, v4)
        else
            false
    | UH7_0 -> (* InputListNil *)
        true
and derivative_semantic_triangle_symbols_37 (v0 : UH3, v1 : UH6, v2 : UH7) : bool =
    match v1 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = derivative_semantic_triangle_suffixes_38(v0, v3, v2)
        if v5 then
            derivative_semantic_triangle_symbols_37(v0, v4, v2)
        else
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and normalization_language_law_suffixes_50 (v0 : UH2, v1 : UH5) : bool =
    match v1 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : UH2 = normalize_4(v0)
        let v5 : UH5 = language_remainders_27(v0, v2)
        let v6 : UH5 = language_remainders_27(v4, v2)
        let v7 : bool = input_list_subset_35(v5, v6)
        let v9 : bool =
            if v7 then
                input_list_subset_35(v6, v5)
            else
                false
        if v9 then
            normalization_language_law_suffixes_50(v0, v3)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
and normalization_language_law_suffixes_51 (v0 : UH3, v1 : UH7) : bool =
    match v1 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : UH3 = normalize_14(v0)
        let v5 : UH7 = language_remainders_41(v0, v2)
        let v6 : UH7 = language_remainders_41(v4, v2)
        let v7 : bool = input_list_subset_49(v5, v6)
        let v9 : bool =
            if v7 then
                input_list_subset_49(v6, v5)
            else
                false
        if v9 then
            normalization_language_law_suffixes_51(v0, v3)
        else
            false
    | UH7_0 -> (* InputListNil *)
        true
and contains_53 (v0 : US0, v1 : UH4) : bool =
    match v1 with
    | UH4_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US3 =
            match v0 with
            | US0_1 -> (* BitOne *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US3_1
                | US0_0 -> (* BitZero *)
                    US3_2
            | US0_0 -> (* BitZero *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US3_0
                | US0_0 -> (* BitZero *)
                    US3_1
        let v14 : bool =
            match v13 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v14 then
            true
        else
            contains_53(v0, v3)
    | UH4_0 -> (* SymbolListNil *)
        false
and input_symbols_covered_52 (v0 : UH0, v1 : UH4) : bool =
    match v0 with
    | UH0_1(v2, v3) -> (* InputCons *)
        let v4 : bool = contains_53(v2, v1)
        if v4 then
            input_symbols_covered_52(v3, v1)
        else
            false
    | UH0_0 -> (* InputEmpty *)
        true
and regex_list_contains_56 (v0 : UH2, v1 : UH9) : bool =
    match v1 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_9(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_56(v0, v3)
    | UH9_0 -> (* RegexListNil *)
        false
and dfa_enqueue_symbols_55 (v0 : UH2, v1 : UH4, v2 : UH9, v3 : UH9) : struct (UH9 * UH9) =
    match v1 with
    | UH4_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH2 = canonical_derivative_3(v0, v4)
        let v7 : bool = regex_list_contains_56(v6, v2)
        if v7 then
            dfa_enqueue_symbols_55(v0, v5, v2, v3)
        else
            let v10 : UH9 = UH9_1(v6, v2)
            let v11 : UH9 = UH9_1(v6, v3)
            dfa_enqueue_symbols_55(v0, v5, v10, v11)
    | UH4_0 -> (* SymbolListNil *)
        struct (v2, v3)
and dfa_closure_loop_bounded_54 (v0 : UH4, v1 : UH8, v2 : UH9, v3 : UH9) : US4 =
    match v3 with
    | UH9_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH8_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH9, v10 : UH9) = dfa_enqueue_symbols_55(v5, v0, v2, v6)
            dfa_closure_loop_bounded_54(v0, v8, v9, v10)
        | UH8_0 -> (* StateBudgetZero *)
            US4_1(v2)
    | UH9_0 -> (* RegexListNil *)
        US4_0(v2)
and regex_chars_from_symbols_57 (v0 : UH4) : UH9 =
    match v0 with
    | UH4_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH9 = regex_chars_from_symbols_57(v3)
        let v5 : UH2 = UH2_2(v2)
        UH9_1(v5, v4)
    | UH4_0 -> (* SymbolListNil *)
        UH9_0
and regex_star_corpus_58 (v0 : UH9) : UH9 =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH9 = regex_star_corpus_58(v3)
        let v5 : UH2 = UH2_5(v2)
        UH9_1(v5, v4)
    | UH9_0 -> (* RegexListNil *)
        UH9_0
and regex_pairs_with_60 (v0 : UH2, v1 : UH9) : UH9 =
    match v1 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH9 = regex_pairs_with_60(v0, v4)
        let v6 : UH2 = UH2_3(v0, v3)
        let v7 : UH2 = UH2_4(v0, v3)
        let v8 : UH9 = UH9_1(v7, v5)
        UH9_1(v6, v8)
    | UH9_0 -> (* RegexListNil *)
        UH9_0
and regex_list_append_61 (v0 : UH9, v1 : UH9) : UH9 =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH9 = regex_list_append_61(v3, v1)
        UH9_1(v2, v4)
    | UH9_0 -> (* RegexListNil *)
        v1
and regex_binary_corpus_59 (v0 : UH9, v1 : UH9) : UH9 =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH9 = regex_pairs_with_60(v3, v1)
        let v6 : UH9 = regex_binary_corpus_59(v4, v1)
        regex_list_append_61(v5, v6)
    | UH9_0 -> (* RegexListNil *)
        UH9_0
and derivative_language_law_suffixes_64 (v0 : UH2, v1 : US0, v2 : UH5) : bool =
    match v2 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH2 = canonical_derivative_3(v0, v1)
        let v6 : UH0 = UH0_1(v1, v3)
        let v7 : UH0 = UH0_1(v1, v3)
        let v8 : UH5 = language_remainders_27(v0, v7)
        let v9 : UH5 = input_list_remove_34(v6, v8)
        let v10 : UH5 = language_remainders_27(v5, v3)
        let v11 : bool = input_list_subset_35(v9, v10)
        let v13 : bool =
            if v11 then
                input_list_subset_35(v10, v9)
            else
                false
        if v13 then
            derivative_language_law_suffixes_64(v0, v1, v4)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
and derivative_language_law_symbols_63 (v0 : UH2, v1 : UH4, v2 : UH5) : bool =
    match v1 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = derivative_language_law_suffixes_64(v0, v3, v2)
        if v5 then
            derivative_language_law_symbols_63(v0, v4, v2)
        else
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and derivative_language_law_corpus_62 (v0 : UH9, v1 : UH4, v2 : UH5) : bool =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = derivative_language_law_symbols_63(v3, v1, v2)
        if v5 then
            derivative_language_law_corpus_62(v4, v1, v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and derivative_language_law_suffixes_67 (v0 : UH3, v1 : US1, v2 : UH7) : bool =
    match v2 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH3 = canonical_derivative_13(v0, v1)
        let v6 : UH1 = UH1_1(v1, v3)
        let v7 : UH1 = UH1_1(v1, v3)
        let v8 : UH7 = language_remainders_41(v0, v7)
        let v9 : UH7 = input_list_remove_48(v6, v8)
        let v10 : UH7 = language_remainders_41(v5, v3)
        let v11 : bool = input_list_subset_49(v9, v10)
        let v13 : bool =
            if v11 then
                input_list_subset_49(v10, v9)
            else
                false
        if v13 then
            derivative_language_law_suffixes_67(v0, v1, v4)
        else
            false
    | UH7_0 -> (* InputListNil *)
        true
and derivative_language_law_symbols_66 (v0 : UH3, v1 : UH6, v2 : UH7) : bool =
    match v1 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = derivative_language_law_suffixes_67(v0, v3, v2)
        if v5 then
            derivative_language_law_symbols_66(v0, v4, v2)
        else
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and derivative_language_law_corpus_65 (v0 : UH10, v1 : UH6, v2 : UH7) : bool =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = derivative_language_law_symbols_66(v3, v1, v2)
        if v5 then
            derivative_language_law_corpus_65(v4, v1, v2)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and normalization_language_law_corpus_68 (v0 : UH9, v1 : UH5) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = normalization_language_law_suffixes_50(v2, v1)
        if v4 then
            normalization_language_law_corpus_68(v3, v1)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and normalization_language_law_corpus_69 (v0 : UH10, v1 : UH7) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = normalization_language_law_suffixes_51(v2, v1)
        if v4 then
            normalization_language_law_corpus_69(v3, v1)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and input_singletons_from_symbols_71 (v0 : UH4) : UH5 =
    match v0 with
    | UH4_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH5 = input_singletons_from_symbols_71(v3)
        let v5 : UH0 = UH0_0
        let v6 : UH0 = UH0_1(v2, v5)
        UH5_1(v6, v4)
    | UH4_0 -> (* SymbolListNil *)
        UH5_0
and input_prepend_symbol_to_corpus_73 (v0 : US0, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = input_prepend_symbol_to_corpus_73(v0, v4)
        let v6 : UH0 = UH0_1(v0, v3)
        UH5_1(v6, v5)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and input_prepend_symbols_to_corpus_72 (v0 : UH4, v1 : UH5) : UH5 =
    match v0 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH5 = input_prepend_symbol_to_corpus_73(v3, v1)
        let v6 : UH5 = input_prepend_symbols_to_corpus_72(v4, v1)
        input_list_append_28(v5, v6)
    | UH4_0 -> (* SymbolListNil *)
        UH5_0
and dfa_formula_consistent_70 (v0 : UH9, v1 : UH4) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH5 = input_singletons_from_symbols_71(v1)
        let v5 : UH0 = UH0_0
        let v6 : UH5 = UH5_1(v5, v4)
        let v7 : UH5 = input_singletons_from_symbols_71(v1)
        let v8 : UH5 = input_prepend_symbols_to_corpus_72(v1, v7)
        let v9 : UH5 = input_list_append_28(v6, v8)
        let v10 : bool = derivative_semantic_triangle_symbols_23(v2, v1, v9)
        if v10 then
            dfa_formula_consistent_70(v3, v1)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_states_nullable_preserved_74 (v0 : UH9) : bool =
    match v0 with
    | UH9_1(v1, v2) -> (* RegexListCons *)
        let v3 : US2 = nullable_0(v1)
        let v4 : UH2 = normalize_4(v1)
        let v5 : US2 = nullable_0(v4)
        let v9 : bool =
            match v3 with
            | US2_1 -> (* NonNullable *)
                match v5 with
                | US2_1 -> (* NonNullable *)
                    true
                | _ ->
                    false
            | US2_0 -> (* Nullable *)
                match v5 with
                | US2_0 -> (* Nullable *)
                    true
                | _ ->
                    false
        if v9 then
            dfa_states_nullable_preserved_74(v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and regex_list_normalization_idempotent_75 (v0 : UH9) : bool =
    match v0 with
    | UH9_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH2 = normalize_4(v1)
        let v4 : UH2 = normalize_4(v1)
        let v5 : UH2 = normalize_4(v4)
        let v6 : bool = regex_equal_9(v3, v5)
        if v6 then
            regex_list_normalization_idempotent_75(v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and canonical_derivative_coherent_symbols_77 (v0 : UH2, v1 : UH4) : bool =
    match v1 with
    | UH4_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH2 = normalize_4(v0)
        let v5 : UH2 = derivative_11(v4, v2)
        let v6 : UH2 = normalize_4(v5)
        let v7 : UH2 = derivative_11(v0, v2)
        let v8 : UH2 = normalize_4(v7)
        let v9 : bool = regex_equal_9(v6, v8)
        if v9 then
            canonical_derivative_coherent_symbols_77(v0, v3)
        else
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and canonical_derivative_coherent_corpus_76 (v0 : UH9, v1 : UH4) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = canonical_derivative_coherent_symbols_77(v2, v1)
        if v4 then
            canonical_derivative_coherent_corpus_76(v3, v1)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and canonical_derivative_coherent_symbols_79 (v0 : UH3, v1 : UH6) : bool =
    match v1 with
    | UH6_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH3 = normalize_14(v0)
        let v5 : UH3 = derivative_21(v4, v2)
        let v6 : UH3 = normalize_14(v5)
        let v7 : UH3 = derivative_21(v0, v2)
        let v8 : UH3 = normalize_14(v7)
        let v9 : bool = regex_equal_19(v6, v8)
        if v9 then
            canonical_derivative_coherent_symbols_79(v0, v3)
        else
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and canonical_derivative_coherent_corpus_78 (v0 : UH10, v1 : UH6) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = canonical_derivative_coherent_symbols_79(v2, v1)
        if v4 then
            canonical_derivative_coherent_corpus_78(v3, v1)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_closure_loop_80 (v0 : UH4, v1 : UH9, v2 : UH9) : UH9 =
    match v2 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let struct (v5 : UH9, v6 : UH9) = dfa_enqueue_symbols_55(v3, v0, v1, v4)
        dfa_closure_loop_80(v0, v5, v6)
    | UH9_0 -> (* RegexListNil *)
        v1
and dfa_state_signature_transitions_same_83 (v0 : UH2, v1 : UH2, v2 : UH4) : bool =
    match v2 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH2 = canonical_derivative_3(v0, v3)
        let v6 : UH2 = canonical_derivative_3(v1, v3)
        let v7 : bool = regex_equal_9(v5, v6)
        if v7 then
            dfa_state_signature_transitions_same_83(v0, v1, v4)
        else
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and dfa_state_signature_against_82 (v0 : UH2, v1 : UH9, v2 : UH4) : bool =
    match v1 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : US2 = nullable_0(v0)
        let v6 : US2 = nullable_0(v3)
        let v10 : bool =
            match v5 with
            | US2_1 -> (* NonNullable *)
                match v6 with
                | US2_1 -> (* NonNullable *)
                    true
                | _ ->
                    false
            | US2_0 -> (* Nullable *)
                match v6 with
                | US2_0 -> (* Nullable *)
                    true
                | _ ->
                    false
        let v12 : bool =
            if v10 then
                dfa_state_signature_transitions_same_83(v0, v3, v2)
            else
                false
        if v12 then
            false
        else
            dfa_state_signature_against_82(v0, v4, v2)
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_partition_one_distinct_81 (v0 : UH9, v1 : UH4) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_signature_against_82(v2, v3, v1)
        if v4 then
            dfa_partition_one_distinct_81(v3, v1)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and regex_list_contains_86 (v0 : UH3, v1 : UH10) : bool =
    match v1 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = regex_equal_19(v0, v2)
        if v4 then
            true
        else
            regex_list_contains_86(v0, v3)
    | UH10_0 -> (* RegexListNil *)
        false
and dfa_enqueue_symbols_85 (v0 : UH3, v1 : UH6, v2 : UH10, v3 : UH10) : struct (UH10 * UH10) =
    match v1 with
    | UH6_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH3 = canonical_derivative_13(v0, v4)
        let v7 : bool = regex_list_contains_86(v6, v2)
        if v7 then
            dfa_enqueue_symbols_85(v0, v5, v2, v3)
        else
            let v10 : UH10 = UH10_1(v6, v2)
            let v11 : UH10 = UH10_1(v6, v3)
            dfa_enqueue_symbols_85(v0, v5, v10, v11)
    | UH6_0 -> (* SymbolListNil *)
        struct (v2, v3)
and dfa_closure_loop_84 (v0 : UH6, v1 : UH10, v2 : UH10) : UH10 =
    match v2 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let struct (v5 : UH10, v6 : UH10) = dfa_enqueue_symbols_85(v3, v0, v1, v4)
        dfa_closure_loop_84(v0, v5, v6)
    | UH10_0 -> (* RegexListNil *)
        v1
and dfa_state_signature_transitions_same_89 (v0 : UH3, v1 : UH3, v2 : UH6) : bool =
    match v2 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH3 = canonical_derivative_13(v0, v3)
        let v6 : UH3 = canonical_derivative_13(v1, v3)
        let v7 : bool = regex_equal_19(v5, v6)
        if v7 then
            dfa_state_signature_transitions_same_89(v0, v1, v4)
        else
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and dfa_state_signature_against_88 (v0 : UH3, v1 : UH10, v2 : UH6) : bool =
    match v1 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : US2 = nullable_1(v0)
        let v6 : US2 = nullable_1(v3)
        let v10 : bool =
            match v5 with
            | US2_1 -> (* NonNullable *)
                match v6 with
                | US2_1 -> (* NonNullable *)
                    true
                | _ ->
                    false
            | US2_0 -> (* Nullable *)
                match v6 with
                | US2_0 -> (* Nullable *)
                    true
                | _ ->
                    false
        let v12 : bool =
            if v10 then
                dfa_state_signature_transitions_same_89(v0, v3, v2)
            else
                false
        if v12 then
            false
        else
            dfa_state_signature_against_88(v0, v4, v2)
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_partition_one_distinct_87 (v0 : UH10, v1 : UH6) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_signature_against_88(v2, v3, v1)
        if v4 then
            dfa_partition_one_distinct_87(v3, v1)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_state_pair_list_contains_93 (v0 : UH2, v1 : UH2, v2 : UH11) : bool =
    match v2 with
    | UH11_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_9(v0, v3)
        let v11 : bool =
            if v6 then
                regex_equal_9(v1, v4)
            else
                let v8 : bool = regex_equal_9(v0, v4)
                if v8 then
                    regex_equal_9(v1, v3)
                else
                    false
        if v11 then
            true
        else
            dfa_state_pair_list_contains_93(v0, v1, v5)
    | UH11_0 -> (* DfaStatePairNil *)
        false
and dfa_state_pair_enqueue_symbols_94 (v0 : UH2, v1 : UH2, v2 : UH4, v3 : UH11) : UH11 =
    match v2 with
    | UH4_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH2 = canonical_derivative_3(v0, v4)
        let v7 : UH2 = canonical_derivative_3(v1, v4)
        let v8 : UH11 = UH11_1(v6, v7, v3)
        dfa_state_pair_enqueue_symbols_94(v0, v1, v5, v8)
    | UH4_0 -> (* SymbolListNil *)
        v3
and dfa_bisimulation_work_92 (v0 : UH4, v1 : UH11, v2 : UH11) : bool =
    match v1 with
    | UH11_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_9(v3, v4)
        if v6 then
            dfa_bisimulation_work_92(v0, v5, v2)
        else
            let v8 : bool = dfa_state_pair_list_contains_93(v3, v4, v2)
            if v8 then
                dfa_bisimulation_work_92(v0, v5, v2)
            else
                let v10 : US2 = nullable_0(v3)
                let v11 : US2 = nullable_0(v4)
                let v15 : bool =
                    match v10 with
                    | US2_1 -> (* NonNullable *)
                        match v11 with
                        | US2_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US2_0 -> (* Nullable *)
                        match v11 with
                        | US2_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH11 = dfa_state_pair_enqueue_symbols_94(v3, v4, v0, v5)
                    let v17 : UH11 = UH11_1(v3, v4, v2)
                    dfa_bisimulation_work_92(v0, v16, v17)
                else
                    false
    | UH11_0 -> (* DfaStatePairNil *)
        true
and dfa_state_behaviorally_distinct_against_91 (v0 : UH2, v1 : UH9, v2 : UH4) : bool =
    match v1 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH2 = normalize_4(v0)
        let v6 : UH2 = normalize_4(v3)
        let v7 : UH11 = UH11_0
        let v8 : UH11 = UH11_1(v5, v6, v7)
        let v9 : UH11 = UH11_0
        let v10 : bool = dfa_bisimulation_work_92(v2, v8, v9)
        if v10 then
            false
        else
            dfa_state_behaviorally_distinct_against_91(v0, v4, v2)
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_minimal_by_bisimulation_90 (v0 : UH9, v1 : UH4) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_behaviorally_distinct_against_91(v2, v3, v1)
        if v4 then
            dfa_minimal_by_bisimulation_90(v3, v1)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_state_pair_list_contains_98 (v0 : UH3, v1 : UH3, v2 : UH12) : bool =
    match v2 with
    | UH12_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_19(v0, v3)
        let v11 : bool =
            if v6 then
                regex_equal_19(v1, v4)
            else
                let v8 : bool = regex_equal_19(v0, v4)
                if v8 then
                    regex_equal_19(v1, v3)
                else
                    false
        if v11 then
            true
        else
            dfa_state_pair_list_contains_98(v0, v1, v5)
    | UH12_0 -> (* DfaStatePairNil *)
        false
and dfa_state_pair_enqueue_symbols_99 (v0 : UH3, v1 : UH3, v2 : UH6, v3 : UH12) : UH12 =
    match v2 with
    | UH6_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH3 = canonical_derivative_13(v0, v4)
        let v7 : UH3 = canonical_derivative_13(v1, v4)
        let v8 : UH12 = UH12_1(v6, v7, v3)
        dfa_state_pair_enqueue_symbols_99(v0, v1, v5, v8)
    | UH6_0 -> (* SymbolListNil *)
        v3
and dfa_bisimulation_work_97 (v0 : UH6, v1 : UH12, v2 : UH12) : bool =
    match v1 with
    | UH12_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = regex_equal_19(v3, v4)
        if v6 then
            dfa_bisimulation_work_97(v0, v5, v2)
        else
            let v8 : bool = dfa_state_pair_list_contains_98(v3, v4, v2)
            if v8 then
                dfa_bisimulation_work_97(v0, v5, v2)
            else
                let v10 : US2 = nullable_1(v3)
                let v11 : US2 = nullable_1(v4)
                let v15 : bool =
                    match v10 with
                    | US2_1 -> (* NonNullable *)
                        match v11 with
                        | US2_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US2_0 -> (* Nullable *)
                        match v11 with
                        | US2_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH12 = dfa_state_pair_enqueue_symbols_99(v3, v4, v0, v5)
                    let v17 : UH12 = UH12_1(v3, v4, v2)
                    dfa_bisimulation_work_97(v0, v16, v17)
                else
                    false
    | UH12_0 -> (* DfaStatePairNil *)
        true
and dfa_state_behaviorally_distinct_against_96 (v0 : UH3, v1 : UH10, v2 : UH6) : bool =
    match v1 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH3 = normalize_14(v0)
        let v6 : UH3 = normalize_14(v3)
        let v7 : UH12 = UH12_0
        let v8 : UH12 = UH12_1(v5, v6, v7)
        let v9 : UH12 = UH12_0
        let v10 : bool = dfa_bisimulation_work_97(v2, v8, v9)
        if v10 then
            false
        else
            dfa_state_behaviorally_distinct_against_96(v0, v4, v2)
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_minimal_by_bisimulation_95 (v0 : UH10, v1 : UH6) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_behaviorally_distinct_against_96(v2, v3, v1)
        if v4 then
            dfa_minimal_by_bisimulation_95(v3, v1)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and decide_bit_match_100 (v0 : US5) : US6 =
    match v0 with
    | US5_0(v1, v2) -> (* BitMatcherRaw *)
        let v3 : bool = accepts_2(v1, v2)
        US6_0(v1, v2, v3)
and bit_match_value_101 (v0 : US6) : bool =
    match v0 with
    | US6_0(v1, v2, v3) -> (* BitMatcherDecided *)
        v3
and state_budget_add_103 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_1(v2) -> (* StateBudgetSucc *)
        let v3 : UH8 = state_budget_add_103(v2, v1)
        UH8_1(v3)
    | UH8_0 -> (* StateBudgetZero *)
        v1
and regex_position_count_102 (v0 : UH2) : UH8 =
    match v0 with
    | UH2_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH8 = regex_position_count_102(v6)
        let v9 : UH8 = regex_position_count_102(v7)
        state_budget_add_103(v8, v9)
    | UH2_4(v11, v12) -> (* RegexCat *)
        let v13 : UH8 = regex_position_count_102(v11)
        let v14 : UH8 = regex_position_count_102(v12)
        state_budget_add_103(v13, v14)
    | UH2_2(v3) -> (* RegexChar *)
        let v4 : UH8 = UH8_0
        UH8_1(v4)
    | UH2_0 -> (* RegexEmpty *)
        UH8_0
    | UH2_1 -> (* RegexEpsilon *)
        UH8_0
    | UH2_5(v16) -> (* RegexStar *)
        regex_position_count_102(v16)
and state_budget_add_105 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_1(v1) -> (* StateBudgetSucc *)
        let v2 : UH8 = state_budget_add_103(v1, v0)
        UH8_1(v2)
    | UH8_0 -> (* StateBudgetZero *)
        v0
and state_budget_pow2_104 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_1(v3) -> (* StateBudgetSucc *)
        let v4 : UH8 = state_budget_pow2_104(v3)
        state_budget_add_105(v4)
    | UH8_0 -> (* StateBudgetZero *)
        let v1 : UH8 = UH8_0
        UH8_1(v1)
and dfa_transitions_from_state_107 (v0 : UH2, v1 : UH4) : UH13 =
    match v1 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH2 = canonical_derivative_3(v0, v3)
        let v6 : UH13 = dfa_transitions_from_state_107(v0, v4)
        UH13_1(v0, v3, v5, v6)
    | UH4_0 -> (* SymbolListNil *)
        UH13_0
and dfa_transition_append_108 (v0 : UH13, v1 : UH13) : UH13 =
    match v0 with
    | UH13_1(v2, v3, v4, v5) -> (* DfaTransitionCons *)
        let v6 : UH13 = dfa_transition_append_108(v5, v1)
        UH13_1(v2, v3, v4, v6)
    | UH13_0 -> (* DfaTransitionNil *)
        v1
and dfa_transition_table_106 (v0 : UH9, v1 : UH4) : UH13 =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH13 = dfa_transitions_from_state_107(v3, v1)
        let v6 : UH13 = dfa_transition_table_106(v4, v1)
        dfa_transition_append_108(v5, v6)
    | UH9_0 -> (* RegexListNil *)
        UH13_0
and dfa_state_closed_110 (v0 : UH2, v1 : UH4, v2 : UH9) : bool =
    match v1 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH2 = canonical_derivative_3(v0, v3)
        let v6 : bool = regex_list_contains_56(v5, v2)
        if v6 then
            dfa_state_closed_110(v0, v4, v2)
        else
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and dfa_closure_closed_111 (v0 : UH9, v1 : UH4, v2 : UH9) : bool =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = dfa_state_closed_110(v3, v1, v2)
        if v5 then
            dfa_closure_closed_111(v4, v1, v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_closure_closed_109 (v0 : UH9, v1 : UH4) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_closed_110(v2, v1, v0)
        if v4 then
            dfa_closure_closed_111(v3, v1, v0)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and regex_list_distinct_112 (v0 : UH9) : bool =
    match v0 with
    | UH9_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = regex_list_contains_56(v1, v2)
        if v3 then
            false
        else
            regex_list_distinct_112(v2)
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_transition_lookup_value_115 (v0 : UH2, v1 : US0, v2 : UH13) : US7 =
    match v2 with
    | UH13_1(v4, v5, v6, v7) -> (* DfaTransitionCons *)
        let v8 : bool = regex_equal_9(v0, v4)
        if v8 then
            let v18 : US3 =
                match v1 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US3_1
                    | US0_0 -> (* BitZero *)
                        US3_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US3_0
                    | US0_0 -> (* BitZero *)
                        US3_1
            let v19 : bool =
                match v18 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                US7_0(v6)
            else
                dfa_transition_lookup_value_115(v0, v1, v7)
        else
            dfa_transition_lookup_value_115(v0, v1, v7)
    | UH13_0 -> (* DfaTransitionNil *)
        US7_1
and dfa_state_transition_total_114 (v0 : UH2, v1 : UH4, v2 : UH13) : bool =
    match v1 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : US7 = dfa_transition_lookup_value_115(v0, v3, v2)
        match v5 with
        | US7_0(v6) -> (* DfaTransitionFound *)
            let v7 : UH2 = canonical_derivative_3(v0, v3)
            let v8 : bool = regex_equal_9(v6, v7)
            if v8 then
                dfa_state_transition_total_114(v0, v4, v2)
            else
                false
        | US7_1 -> (* DfaTransitionMissing *)
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and dfa_transition_table_total_113 (v0 : UH9, v1 : UH4, v2 : UH13) : bool =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = dfa_state_transition_total_114(v3, v1, v2)
        if v5 then
            dfa_transition_table_total_113(v4, v1, v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_transition_key_present_117 (v0 : UH2, v1 : US0, v2 : UH13) : bool =
    match v2 with
    | UH13_1(v3, v4, v5, v6) -> (* DfaTransitionCons *)
        let v7 : bool = regex_equal_9(v0, v3)
        if v7 then
            let v17 : US3 =
                match v1 with
                | US0_1 -> (* BitOne *)
                    match v4 with
                    | US0_1 -> (* BitOne *)
                        US3_1
                    | US0_0 -> (* BitZero *)
                        US3_2
                | US0_0 -> (* BitZero *)
                    match v4 with
                    | US0_1 -> (* BitOne *)
                        US3_0
                    | US0_0 -> (* BitZero *)
                        US3_1
            let v18 : bool =
                match v17 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v18 then
                true
            else
                dfa_transition_key_present_117(v0, v1, v6)
        else
            dfa_transition_key_present_117(v0, v1, v6)
    | UH13_0 -> (* DfaTransitionNil *)
        false
and dfa_transition_keys_distinct_116 (v0 : UH13) : bool =
    match v0 with
    | UH13_1(v1, v2, v3, v4) -> (* DfaTransitionCons *)
        let v5 : bool = dfa_transition_key_present_117(v1, v2, v4)
        if v5 then
            false
        else
            dfa_transition_keys_distinct_116(v4)
    | UH13_0 -> (* DfaTransitionNil *)
        true
and regex_list_within_budget_118 (v0 : UH9, v1 : UH8) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        match v1 with
        | UH8_1(v4) -> (* StateBudgetSucc *)
            regex_list_within_budget_118(v3, v4)
        | UH8_0 -> (* StateBudgetZero *)
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_states_normalized_119 (v0 : UH9) : bool =
    match v0 with
    | UH9_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH2 = normalize_4(v1)
        let v4 : bool = regex_equal_9(v1, v3)
        if v4 then
            dfa_states_normalized_119(v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and regex_compare_121 (v0 : UH2) : US3 =
    match v0 with
    | UH2_3(v15, v16) -> (* RegexAlt *)
        let v17 : US3 = regex_compare_121(v15)
        match v17 with
        | US3_1 -> (* SymbolSame *)
            regex_compare_121(v16)
        | _ ->
            v17
    | UH2_4(v8, v9) -> (* RegexCat *)
        let v10 : US3 = regex_compare_121(v8)
        match v10 with
        | US3_1 -> (* SymbolSame *)
            regex_compare_121(v9)
        | _ ->
            v10
    | UH2_2(v3) -> (* RegexChar *)
        match v3 with
        | US0_1 -> (* BitOne *)
            US3_1
        | US0_0 -> (* BitZero *)
            US3_1
    | UH2_0 -> (* RegexEmpty *)
        US3_1
    | UH2_1 -> (* RegexEpsilon *)
        US3_1
    | UH2_5(v13) -> (* RegexStar *)
        regex_compare_121(v13)
and regex_compare_against_122 (v0 : UH2, v1 : UH9) : bool =
    match v1 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : US3 = regex_compare_7(v0, v2)
        let v5 : US3 = regex_compare_7(v2, v0)
        let v12 : bool =
            match v4 with
            | US3_2 -> (* SymbolGreater *)
                match v5 with
                | US3_0 -> (* SymbolLess *)
                    true
                | _ ->
                    false
            | US3_0 -> (* SymbolLess *)
                match v5 with
                | US3_2 -> (* SymbolGreater *)
                    true
                | _ ->
                    false
            | US3_1 -> (* SymbolSame *)
                match v5 with
                | US3_1 -> (* SymbolSame *)
                    regex_equal_9(v0, v2)
                | _ ->
                    false
        if v12 then
            regex_compare_against_122(v0, v3)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and regex_order_laws_120 (v0 : UH9) : bool =
    match v0 with
    | UH9_1(v1, v2) -> (* RegexListCons *)
        let v3 : US3 = regex_compare_121(v1)
        match v3 with
        | US3_1 -> (* SymbolSame *)
            let v4 : bool = regex_compare_against_122(v1, v2)
            if v4 then
                regex_order_laws_120(v2)
            else
                false
        | _ ->
            false
    | UH9_0 -> (* RegexListNil *)
        true
and regex_position_count_123 (v0 : UH3) : UH8 =
    match v0 with
    | UH3_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH8 = regex_position_count_123(v6)
        let v9 : UH8 = regex_position_count_123(v7)
        state_budget_add_103(v8, v9)
    | UH3_4(v11, v12) -> (* RegexCat *)
        let v13 : UH8 = regex_position_count_123(v11)
        let v14 : UH8 = regex_position_count_123(v12)
        state_budget_add_103(v13, v14)
    | UH3_2(v3) -> (* RegexChar *)
        let v4 : UH8 = UH8_0
        UH8_1(v4)
    | UH3_0 -> (* RegexEmpty *)
        UH8_0
    | UH3_1 -> (* RegexEpsilon *)
        UH8_0
    | UH3_5(v16) -> (* RegexStar *)
        regex_position_count_123(v16)
and dfa_closure_loop_bounded_124 (v0 : UH6, v1 : UH8, v2 : UH10, v3 : UH10) : US8 =
    match v3 with
    | UH10_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH8_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH10, v10 : UH10) = dfa_enqueue_symbols_85(v5, v0, v2, v6)
            dfa_closure_loop_bounded_124(v0, v8, v9, v10)
        | UH8_0 -> (* StateBudgetZero *)
            US8_1(v2)
    | UH10_0 -> (* RegexListNil *)
        US8_0(v2)
and dfa_transitions_from_state_126 (v0 : UH3, v1 : UH6) : UH14 =
    match v1 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH3 = canonical_derivative_13(v0, v3)
        let v6 : UH14 = dfa_transitions_from_state_126(v0, v4)
        UH14_1(v0, v3, v5, v6)
    | UH6_0 -> (* SymbolListNil *)
        UH14_0
and dfa_transition_append_127 (v0 : UH14, v1 : UH14) : UH14 =
    match v0 with
    | UH14_1(v2, v3, v4, v5) -> (* DfaTransitionCons *)
        let v6 : UH14 = dfa_transition_append_127(v5, v1)
        UH14_1(v2, v3, v4, v6)
    | UH14_0 -> (* DfaTransitionNil *)
        v1
and dfa_transition_table_125 (v0 : UH10, v1 : UH6) : UH14 =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH14 = dfa_transitions_from_state_126(v3, v1)
        let v6 : UH14 = dfa_transition_table_125(v4, v1)
        dfa_transition_append_127(v5, v6)
    | UH10_0 -> (* RegexListNil *)
        UH14_0
and dfa_state_closed_129 (v0 : UH3, v1 : UH6, v2 : UH10) : bool =
    match v1 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH3 = canonical_derivative_13(v0, v3)
        let v6 : bool = regex_list_contains_86(v5, v2)
        if v6 then
            dfa_state_closed_129(v0, v4, v2)
        else
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and dfa_closure_closed_130 (v0 : UH10, v1 : UH6, v2 : UH10) : bool =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = dfa_state_closed_129(v3, v1, v2)
        if v5 then
            dfa_closure_closed_130(v4, v1, v2)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_closure_closed_128 (v0 : UH10, v1 : UH6) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_state_closed_129(v2, v1, v0)
        if v4 then
            dfa_closure_closed_130(v3, v1, v0)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and regex_list_distinct_131 (v0 : UH10) : bool =
    match v0 with
    | UH10_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = regex_list_contains_86(v1, v2)
        if v3 then
            false
        else
            regex_list_distinct_131(v2)
    | UH10_0 -> (* RegexListNil *)
        true
and input_singletons_from_symbols_133 (v0 : UH6) : UH7 =
    match v0 with
    | UH6_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH7 = input_singletons_from_symbols_133(v3)
        let v5 : UH1 = UH1_0
        let v6 : UH1 = UH1_1(v2, v5)
        UH7_1(v6, v4)
    | UH6_0 -> (* SymbolListNil *)
        UH7_0
and input_prepend_symbol_to_corpus_135 (v0 : US1, v1 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = input_prepend_symbol_to_corpus_135(v0, v4)
        let v6 : UH1 = UH1_1(v0, v3)
        UH7_1(v6, v5)
    | UH7_0 -> (* InputListNil *)
        UH7_0
and input_prepend_symbols_to_corpus_134 (v0 : UH6, v1 : UH7) : UH7 =
    match v0 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH7 = input_prepend_symbol_to_corpus_135(v3, v1)
        let v6 : UH7 = input_prepend_symbols_to_corpus_134(v4, v1)
        input_list_append_42(v5, v6)
    | UH6_0 -> (* SymbolListNil *)
        UH7_0
and dfa_formula_consistent_132 (v0 : UH10, v1 : UH6) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH7 = input_singletons_from_symbols_133(v1)
        let v5 : UH1 = UH1_0
        let v6 : UH7 = UH7_1(v5, v4)
        let v7 : UH7 = input_singletons_from_symbols_133(v1)
        let v8 : UH7 = input_prepend_symbols_to_corpus_134(v1, v7)
        let v9 : UH7 = input_list_append_42(v6, v8)
        let v10 : bool = derivative_semantic_triangle_symbols_37(v2, v1, v9)
        if v10 then
            dfa_formula_consistent_132(v3, v1)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_transition_lookup_value_138 (v0 : UH3, v1 : US1, v2 : UH14) : US9 =
    match v2 with
    | UH14_1(v4, v5, v6, v7) -> (* DfaTransitionCons *)
        let v8 : bool = regex_equal_19(v0, v4)
        if v8 then
            let v24 : US3 =
                match v1 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US3_1
                    | _ ->
                        US3_0
                | _ ->
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US3_2
                    | _ ->
                        match v1 with
                        | US1_1 -> (* TriB *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US3_1
                            | US1_2 -> (* TriC *)
                                US3_0
                        | US1_2 -> (* TriC *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US3_2
                            | US1_2 -> (* TriC *)
                                US3_1
            let v25 : bool =
                match v24 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                US9_0(v6)
            else
                dfa_transition_lookup_value_138(v0, v1, v7)
        else
            dfa_transition_lookup_value_138(v0, v1, v7)
    | UH14_0 -> (* DfaTransitionNil *)
        US9_1
and dfa_state_transition_total_137 (v0 : UH3, v1 : UH6, v2 : UH14) : bool =
    match v1 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : US9 = dfa_transition_lookup_value_138(v0, v3, v2)
        match v5 with
        | US9_0(v6) -> (* DfaTransitionFound *)
            let v7 : UH3 = canonical_derivative_13(v0, v3)
            let v8 : bool = regex_equal_19(v6, v7)
            if v8 then
                dfa_state_transition_total_137(v0, v4, v2)
            else
                false
        | US9_1 -> (* DfaTransitionMissing *)
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and dfa_transition_table_total_136 (v0 : UH10, v1 : UH6, v2 : UH14) : bool =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = dfa_state_transition_total_137(v3, v1, v2)
        if v5 then
            dfa_transition_table_total_136(v4, v1, v2)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_transition_key_present_140 (v0 : UH3, v1 : US1, v2 : UH14) : bool =
    match v2 with
    | UH14_1(v3, v4, v5, v6) -> (* DfaTransitionCons *)
        let v7 : bool = regex_equal_19(v0, v3)
        if v7 then
            let v23 : US3 =
                match v1 with
                | US1_0 -> (* TriA *)
                    match v4 with
                    | US1_0 -> (* TriA *)
                        US3_1
                    | _ ->
                        US3_0
                | _ ->
                    match v4 with
                    | US1_0 -> (* TriA *)
                        US3_2
                    | _ ->
                        match v1 with
                        | US1_1 -> (* TriB *)
                            match v4 with
                            | US1_1 -> (* TriB *)
                                US3_1
                            | US1_2 -> (* TriC *)
                                US3_0
                        | US1_2 -> (* TriC *)
                            match v4 with
                            | US1_1 -> (* TriB *)
                                US3_2
                            | US1_2 -> (* TriC *)
                                US3_1
            let v24 : bool =
                match v23 with
                | US3_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v24 then
                true
            else
                dfa_transition_key_present_140(v0, v1, v6)
        else
            dfa_transition_key_present_140(v0, v1, v6)
    | UH14_0 -> (* DfaTransitionNil *)
        false
and dfa_transition_keys_distinct_139 (v0 : UH14) : bool =
    match v0 with
    | UH14_1(v1, v2, v3, v4) -> (* DfaTransitionCons *)
        let v5 : bool = dfa_transition_key_present_140(v1, v2, v4)
        if v5 then
            false
        else
            dfa_transition_keys_distinct_139(v4)
    | UH14_0 -> (* DfaTransitionNil *)
        true
and regex_list_within_budget_141 (v0 : UH10, v1 : UH8) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        match v1 with
        | UH8_1(v4) -> (* StateBudgetSucc *)
            regex_list_within_budget_141(v3, v4)
        | UH8_0 -> (* StateBudgetZero *)
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_states_normalized_142 (v0 : UH10) : bool =
    match v0 with
    | UH10_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH3 = normalize_14(v1)
        let v4 : bool = regex_equal_19(v1, v3)
        if v4 then
            dfa_states_normalized_142(v2)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_states_nullable_preserved_143 (v0 : UH10) : bool =
    match v0 with
    | UH10_1(v1, v2) -> (* RegexListCons *)
        let v3 : US2 = nullable_1(v1)
        let v4 : UH3 = normalize_14(v1)
        let v5 : US2 = nullable_1(v4)
        let v9 : bool =
            match v3 with
            | US2_1 -> (* NonNullable *)
                match v5 with
                | US2_1 -> (* NonNullable *)
                    true
                | _ ->
                    false
            | US2_0 -> (* Nullable *)
                match v5 with
                | US2_0 -> (* Nullable *)
                    true
                | _ ->
                    false
        if v9 then
            dfa_states_nullable_preserved_143(v2)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and regex_compare_145 (v0 : UH3) : US3 =
    match v0 with
    | UH3_3(v17, v18) -> (* RegexAlt *)
        let v19 : US3 = regex_compare_145(v17)
        match v19 with
        | US3_1 -> (* SymbolSame *)
            regex_compare_145(v18)
        | _ ->
            v19
    | UH3_4(v10, v11) -> (* RegexCat *)
        let v12 : US3 = regex_compare_145(v10)
        match v12 with
        | US3_1 -> (* SymbolSame *)
            regex_compare_145(v11)
        | _ ->
            v12
    | UH3_2(v3) -> (* RegexChar *)
        match v3 with
        | US1_0 -> (* TriA *)
            US3_1
        | US1_1 -> (* TriB *)
            US3_1
        | US1_2 -> (* TriC *)
            US3_1
    | UH3_0 -> (* RegexEmpty *)
        US3_1
    | UH3_1 -> (* RegexEpsilon *)
        US3_1
    | UH3_5(v15) -> (* RegexStar *)
        regex_compare_145(v15)
and regex_compare_against_146 (v0 : UH3, v1 : UH10) : bool =
    match v1 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : US3 = regex_compare_17(v0, v2)
        let v5 : US3 = regex_compare_17(v2, v0)
        let v12 : bool =
            match v4 with
            | US3_2 -> (* SymbolGreater *)
                match v5 with
                | US3_0 -> (* SymbolLess *)
                    true
                | _ ->
                    false
            | US3_0 -> (* SymbolLess *)
                match v5 with
                | US3_2 -> (* SymbolGreater *)
                    true
                | _ ->
                    false
            | US3_1 -> (* SymbolSame *)
                match v5 with
                | US3_1 -> (* SymbolSame *)
                    regex_equal_19(v0, v2)
                | _ ->
                    false
        if v12 then
            regex_compare_against_146(v0, v3)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and regex_order_laws_144 (v0 : UH10) : bool =
    match v0 with
    | UH10_1(v1, v2) -> (* RegexListCons *)
        let v3 : US3 = regex_compare_145(v1)
        match v3 with
        | US3_1 -> (* SymbolSame *)
            let v4 : bool = regex_compare_against_146(v1, v2)
            if v4 then
                regex_order_laws_144(v2)
            else
                false
        | _ ->
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_find_bisimilar_representative_148 (v0 : UH2, v1 : UH9, v2 : UH4) : US10 =
    match v1 with
    | UH9_1(v4, v5) -> (* RegexListCons *)
        let v6 : UH2 = normalize_4(v0)
        let v7 : UH2 = normalize_4(v4)
        let v8 : UH11 = UH11_0
        let v9 : UH11 = UH11_1(v6, v7, v8)
        let v10 : UH11 = UH11_0
        let v11 : bool = dfa_bisimulation_work_92(v2, v9, v10)
        if v11 then
            US10_0(v4)
        else
            dfa_find_bisimilar_representative_148(v0, v5, v2)
    | UH9_0 -> (* RegexListNil *)
        US10_1
and dfa_minimize_states_loop_147 (v0 : UH9, v1 : UH4, v2 : UH9) : UH9 =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : US10 = dfa_find_bisimilar_representative_148(v3, v2, v1)
        match v5 with
        | US10_0(v6) -> (* DfaRepresentativeFound *)
            dfa_minimize_states_loop_147(v4, v1, v2)
        | US10_1 -> (* DfaRepresentativeMissing *)
            let v8 : UH9 = UH9_1(v3, v2)
            dfa_minimize_states_loop_147(v4, v1, v8)
    | UH9_0 -> (* RegexListNil *)
        v2
and dfa_states_have_representative_149 (v0 : UH9, v1 : UH9, v2 : UH4) : bool =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : US10 = dfa_find_bisimilar_representative_148(v3, v1, v2)
        match v5 with
        | US10_0(v6) -> (* DfaRepresentativeFound *)
            dfa_states_have_representative_149(v4, v1, v2)
        | US10_1 -> (* DfaRepresentativeMissing *)
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_quotient_state_closed_151 (v0 : UH2, v1 : UH4, v2 : UH9) : bool =
    match v1 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH2 = canonical_derivative_3(v0, v3)
        let v6 : US10 = dfa_find_bisimilar_representative_148(v5, v2, v1)
        match v6 with
        | US10_0(v7) -> (* DfaRepresentativeFound *)
            dfa_quotient_state_closed_151(v0, v4, v2)
        | US10_1 -> (* DfaRepresentativeMissing *)
            false
    | UH4_0 -> (* SymbolListNil *)
        true
and dfa_quotient_closed_152 (v0 : UH9, v1 : UH4, v2 : UH9) : bool =
    match v0 with
    | UH9_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = dfa_quotient_state_closed_151(v3, v1, v2)
        if v5 then
            dfa_quotient_closed_152(v4, v1, v2)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_quotient_closed_150 (v0 : UH9, v1 : UH4) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_quotient_state_closed_151(v2, v1, v0)
        if v4 then
            dfa_quotient_closed_152(v3, v1, v0)
        else
            false
    | UH9_0 -> (* RegexListNil *)
        true
and dfa_find_bisimilar_representative_154 (v0 : UH3, v1 : UH10, v2 : UH6) : US11 =
    match v1 with
    | UH10_1(v4, v5) -> (* RegexListCons *)
        let v6 : UH3 = normalize_14(v0)
        let v7 : UH3 = normalize_14(v4)
        let v8 : UH12 = UH12_0
        let v9 : UH12 = UH12_1(v6, v7, v8)
        let v10 : UH12 = UH12_0
        let v11 : bool = dfa_bisimulation_work_97(v2, v9, v10)
        if v11 then
            US11_0(v4)
        else
            dfa_find_bisimilar_representative_154(v0, v5, v2)
    | UH10_0 -> (* RegexListNil *)
        US11_1
and dfa_minimize_states_loop_153 (v0 : UH10, v1 : UH6, v2 : UH10) : UH10 =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : US11 = dfa_find_bisimilar_representative_154(v3, v2, v1)
        match v5 with
        | US11_0(v6) -> (* DfaRepresentativeFound *)
            dfa_minimize_states_loop_153(v4, v1, v2)
        | US11_1 -> (* DfaRepresentativeMissing *)
            let v8 : UH10 = UH10_1(v3, v2)
            dfa_minimize_states_loop_153(v4, v1, v8)
    | UH10_0 -> (* RegexListNil *)
        v2
and dfa_states_have_representative_155 (v0 : UH10, v1 : UH10, v2 : UH6) : bool =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : US11 = dfa_find_bisimilar_representative_154(v3, v1, v2)
        match v5 with
        | US11_0(v6) -> (* DfaRepresentativeFound *)
            dfa_states_have_representative_155(v4, v1, v2)
        | US11_1 -> (* DfaRepresentativeMissing *)
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_quotient_state_closed_157 (v0 : UH3, v1 : UH6, v2 : UH10) : bool =
    match v1 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH3 = canonical_derivative_13(v0, v3)
        let v6 : US11 = dfa_find_bisimilar_representative_154(v5, v2, v1)
        match v6 with
        | US11_0(v7) -> (* DfaRepresentativeFound *)
            dfa_quotient_state_closed_157(v0, v4, v2)
        | US11_1 -> (* DfaRepresentativeMissing *)
            false
    | UH6_0 -> (* SymbolListNil *)
        true
and dfa_quotient_closed_158 (v0 : UH10, v1 : UH6, v2 : UH10) : bool =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = dfa_quotient_state_closed_157(v3, v1, v2)
        if v5 then
            dfa_quotient_closed_158(v4, v1, v2)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_quotient_closed_156 (v0 : UH10, v1 : UH6) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = dfa_quotient_state_closed_157(v2, v1, v0)
        if v4 then
            dfa_quotient_closed_158(v3, v1, v0)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and dfa_run_in_closure_159 (v0 : UH2, v1 : UH9, v2 : UH0) : US12 =
    match v2 with
    | UH0_1(v8, v9) -> (* InputCons *)
        let v10 : UH2 = canonical_derivative_3(v0, v8)
        let v11 : bool = regex_list_contains_56(v10, v1)
        if v11 then
            dfa_run_in_closure_159(v10, v1, v9)
        else
            US12_2
    | UH0_0 -> (* InputEmpty *)
        let v3 : US2 = nullable_0(v0)
        match v3 with
        | US2_1 -> (* NonNullable *)
            US12_1
        | US2_0 -> (* Nullable *)
            US12_0
and contains_161 (v0 : US1, v1 : UH6) : bool =
    match v1 with
    | UH6_1(v2, v3) -> (* SymbolListCons *)
        let v19 : US3 =
            match v0 with
            | US1_0 -> (* TriA *)
                match v2 with
                | US1_0 -> (* TriA *)
                    US3_1
                | _ ->
                    US3_0
            | _ ->
                match v2 with
                | US1_0 -> (* TriA *)
                    US3_2
                | _ ->
                    match v0 with
                    | US1_1 -> (* TriB *)
                        match v2 with
                        | US1_1 -> (* TriB *)
                            US3_1
                        | US1_2 -> (* TriC *)
                            US3_0
                    | US1_2 -> (* TriC *)
                        match v2 with
                        | US1_1 -> (* TriB *)
                            US3_2
                        | US1_2 -> (* TriC *)
                            US3_1
        let v20 : bool =
            match v19 with
            | US3_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v20 then
            true
        else
            contains_161(v0, v3)
    | UH6_0 -> (* SymbolListNil *)
        false
and input_symbols_covered_160 (v0 : UH1, v1 : UH6) : bool =
    match v0 with
    | UH1_1(v2, v3) -> (* InputCons *)
        let v4 : bool = contains_161(v2, v1)
        if v4 then
            input_symbols_covered_160(v3, v1)
        else
            false
    | UH1_0 -> (* InputEmpty *)
        true
and dfa_run_in_closure_162 (v0 : UH3, v1 : UH10, v2 : UH1) : US12 =
    match v2 with
    | UH1_1(v8, v9) -> (* InputCons *)
        let v10 : UH3 = canonical_derivative_13(v0, v8)
        let v11 : bool = regex_list_contains_86(v10, v1)
        if v11 then
            dfa_run_in_closure_162(v10, v1, v9)
        else
            US12_2
    | UH1_0 -> (* InputEmpty *)
        let v3 : US2 = nullable_1(v0)
        match v3 with
        | US2_1 -> (* NonNullable *)
            US12_1
        | US2_0 -> (* Nullable *)
            US12_0
and dfa_run_minimized_in_representatives_163 (v0 : UH2, v1 : UH9, v2 : UH4, v3 : UH0) : US12 =
    match v3 with
    | UH0_1(v9, v10) -> (* InputCons *)
        let v11 : UH2 = canonical_derivative_3(v0, v9)
        let v12 : US10 = dfa_find_bisimilar_representative_148(v11, v1, v2)
        match v12 with
        | US10_0(v13) -> (* DfaRepresentativeFound *)
            dfa_run_minimized_in_representatives_163(v13, v1, v2, v10)
        | US10_1 -> (* DfaRepresentativeMissing *)
            US12_2
    | UH0_0 -> (* InputEmpty *)
        let v4 : US2 = nullable_0(v0)
        match v4 with
        | US2_1 -> (* NonNullable *)
            US12_1
        | US2_0 -> (* Nullable *)
            US12_0
and dfa_run_minimized_in_representatives_164 (v0 : UH3, v1 : UH10, v2 : UH6, v3 : UH1) : US12 =
    match v3 with
    | UH1_1(v9, v10) -> (* InputCons *)
        let v11 : UH3 = canonical_derivative_13(v0, v9)
        let v12 : US11 = dfa_find_bisimilar_representative_154(v11, v1, v2)
        match v12 with
        | US11_0(v13) -> (* DfaRepresentativeFound *)
            dfa_run_minimized_in_representatives_164(v13, v1, v2, v10)
        | US11_1 -> (* DfaRepresentativeMissing *)
            US12_2
    | UH1_0 -> (* InputEmpty *)
        let v4 : US2 = nullable_1(v0)
        match v4 with
        | US2_1 -> (* NonNullable *)
            US12_1
        | US2_0 -> (* Nullable *)
            US12_0
and reference_accepts_165 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v5, v6) -> (* InputCons *)
        let v7 : UH2 = reference_derivative_26(v0, v5)
        reference_accepts_165(v7, v6)
    | UH0_0 -> (* InputEmpty *)
        let v2 : US2 = nullable_0(v0)
        match v2 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and reference_accepts_166 (v0 : UH3, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v5, v6) -> (* InputCons *)
        let v7 : UH3 = reference_derivative_40(v0, v5)
        reference_accepts_166(v7, v6)
    | UH1_0 -> (* InputEmpty *)
        let v2 : US2 = nullable_1(v0)
        match v2 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
let v0 : US0 = US0_1
let v1 : US0 = US0_1
let v2 : US0 = US0_0
let v3 : UH0 = UH0_0
let v4 : UH0 = UH0_1(v2, v3)
let v5 : UH0 = UH0_1(v1, v4)
let v6 : UH0 = UH0_1(v0, v5)
let v7 : US0 = US0_1
let v8 : US0 = US0_1
let v9 : US0 = US0_1
let v10 : UH0 = UH0_0
let v11 : UH0 = UH0_1(v9, v10)
let v12 : UH0 = UH0_1(v8, v11)
let v13 : UH0 = UH0_1(v7, v12)
let v14 : UH0 = UH0_0
let v15 : US1 = US1_0
let v16 : US1 = US1_0
let v17 : US1 = US1_0
let v18 : UH1 = UH1_0
let v19 : UH1 = UH1_1(v17, v18)
let v20 : UH1 = UH1_1(v16, v19)
let v21 : UH1 = UH1_1(v15, v20)
let v22 : US1 = US1_0
let v23 : US1 = US1_0
let v24 : US1 = US1_1
let v25 : UH1 = UH1_0
let v26 : UH1 = UH1_1(v24, v25)
let v27 : UH1 = UH1_1(v23, v26)
let v28 : UH1 = UH1_1(v22, v27)
let v29 : US0 = US0_0
let v30 : UH2 = UH2_2(v29)
let v31 : US0 = US0_1
let v32 : UH2 = UH2_2(v31)
let v33 : UH2 = UH2_3(v30, v32)
let v34 : UH2 = UH2_5(v33)
let v35 : US0 = US0_0
let v36 : UH2 = UH2_2(v35)
let v37 : UH2 = UH2_4(v34, v36)
let v38 : US2 = nullable_0(v37)
let v39 : US1 = US1_0
let v40 : UH3 = UH3_2(v39)
let v41 : UH3 = UH3_5(v40)
let v42 : US2 = nullable_1(v41)
let v43 : US0 = US0_0
let v44 : UH2 = UH2_2(v43)
let v45 : US0 = US0_1
let v46 : UH2 = UH2_2(v45)
let v47 : UH2 = UH2_3(v44, v46)
let v48 : UH2 = UH2_5(v47)
let v49 : US0 = US0_0
let v50 : UH2 = UH2_2(v49)
let v51 : UH2 = UH2_4(v48, v50)
let v52 : US2 = nullable_0(v51)
let v54 : bool =
    match v52 with
    | US2_1 -> (* NonNullable *)
        true
    | US2_0 -> (* Nullable *)
        false
let v55 : US1 = US1_0
let v56 : UH3 = UH3_2(v55)
let v57 : UH3 = UH3_5(v56)
let v58 : US2 = nullable_1(v57)
let v60 : bool =
    match v58 with
    | US2_1 -> (* NonNullable *)
        false
    | US2_0 -> (* Nullable *)
        true
let v61 : bool = v54 && v60
if v61 then
    ()
else
    failwith<unit> "higher-ranked nullable batch should pass"
let v62 : US0 = US0_0
let v63 : UH2 = UH2_2(v62)
let v64 : US0 = US0_1
let v65 : UH2 = UH2_2(v64)
let v66 : UH2 = UH2_3(v63, v65)
let v67 : UH2 = UH2_5(v66)
let v68 : US0 = US0_0
let v69 : UH2 = UH2_2(v68)
let v70 : UH2 = UH2_4(v67, v69)
let v71 : US0 = US0_1
let v72 : US0 = US0_1
let v73 : US0 = US0_0
let v74 : UH0 = UH0_0
let v75 : UH0 = UH0_1(v73, v74)
let v76 : UH0 = UH0_1(v72, v75)
let v77 : UH0 = UH0_1(v71, v76)
let v78 : bool = accepts_2(v70, v77)
let v79 : US1 = US1_0
let v80 : UH3 = UH3_2(v79)
let v81 : UH3 = UH3_5(v80)
let v82 : US1 = US1_0
let v83 : US1 = US1_0
let v84 : US1 = US1_1
let v85 : UH1 = UH1_0
let v86 : UH1 = UH1_1(v84, v85)
let v87 : UH1 = UH1_1(v83, v86)
let v88 : UH1 = UH1_1(v82, v87)
let v89 : bool = accepts_12(v81, v88)
let v90 : bool = v89 = false
let v91 : bool = v78 && v90
if v91 then
    ()
else
    failwith<unit> "higher-ranked acceptance batch should preserve capability-resolved decisions"
let v92 : US0 = US0_0
let v93 : UH2 = UH2_2(v92)
let v94 : US0 = US0_1
let v95 : UH2 = UH2_2(v94)
let v96 : UH2 = UH2_3(v93, v95)
let v97 : UH2 = UH2_5(v96)
let v98 : US0 = US0_0
let v99 : UH2 = UH2_2(v98)
let v100 : UH2 = UH2_4(v97, v99)
let v101 : US0 = US0_1
let v102 : US0 = US0_1
let v103 : US0 = US0_0
let v104 : UH0 = UH0_0
let v105 : UH0 = UH0_1(v103, v104)
let v106 : UH0 = UH0_1(v102, v105)
let v107 : UH0 = UH0_1(v101, v106)
let v108 : bool = accepts_2(v100, v107)
let v109 : US1 = US1_0
let v110 : UH3 = UH3_2(v109)
let v111 : UH3 = UH3_5(v110)
let v112 : US1 = US1_0
let v113 : US1 = US1_0
let v114 : US1 = US1_1
let v115 : UH1 = UH1_0
let v116 : UH1 = UH1_1(v114, v115)
let v117 : UH1 = UH1_1(v113, v116)
let v118 : UH1 = UH1_1(v112, v117)
let v119 : bool = accepts_12(v111, v118)
let v120 : bool = v119 = false
let v121 : bool = v108 && v120
if v121 then
    ()
else
    failwith<unit> "higher-ranked matcher programs should execute captured alphabet capabilities"
let v122 : US0 = US0_0
let v123 : UH2 = UH2_2(v122)
let v124 : US0 = US0_1
let v125 : UH2 = UH2_2(v124)
let v126 : UH2 = UH2_3(v123, v125)
let v127 : UH2 = UH2_5(v126)
let v128 : US0 = US0_0
let v129 : UH2 = UH2_2(v128)
let v130 : UH2 = UH2_4(v127, v129)
let v131 : US0 = US0_1
let v132 : US0 = US0_1
let v133 : US0 = US0_0
let v134 : UH0 = UH0_0
let v135 : UH0 = UH0_1(v133, v134)
let v136 : UH0 = UH0_1(v132, v135)
let v137 : UH0 = UH0_1(v131, v136)
let v138 : bool = accepts_2(v130, v137)
let v151 : bool =
    if v138 then
        let v139 : US1 = US1_0
        let v140 : UH3 = UH3_2(v139)
        let v141 : UH3 = UH3_5(v140)
        let v142 : US1 = US1_0
        let v143 : US1 = US1_0
        let v144 : US1 = US1_1
        let v145 : UH1 = UH1_0
        let v146 : UH1 = UH1_1(v144, v145)
        let v147 : UH1 = UH1_1(v143, v146)
        let v148 : UH1 = UH1_1(v142, v147)
        let v149 : bool = accepts_12(v141, v148)
        let v150 : bool = v149 = false
        v150
    else
        false
if v151 then
    ()
else
    failwith<unit> "higher-ranked batch predicate should execute alphabet-indexed programs without erasing their family"
let v152 : US0 = US0_0
let v153 : UH2 = UH2_2(v152)
let v154 : US0 = US0_1
let v155 : UH2 = UH2_2(v154)
let v156 : UH2 = UH2_3(v153, v155)
let v157 : UH2 = UH2_5(v156)
let v158 : US0 = US0_0
let v159 : UH2 = UH2_2(v158)
let v160 : UH2 = UH2_4(v157, v159)
let v161 : US0 = US0_1
let v162 : US0 = US0_1
let v163 : US0 = US0_0
let v164 : UH0 = UH0_0
let v165 : UH0 = UH0_1(v163, v164)
let v166 : UH0 = UH0_1(v162, v165)
let v167 : UH0 = UH0_1(v161, v166)
let v168 : bool = accepts_2(v160, v167)
let v169 : US1 = US1_0
let v170 : UH3 = UH3_2(v169)
let v171 : UH3 = UH3_5(v170)
let v172 : US1 = US1_0
let v173 : US1 = US1_0
let v174 : US1 = US1_0
let v175 : UH1 = UH1_0
let v176 : UH1 = UH1_1(v174, v175)
let v177 : UH1 = UH1_1(v173, v176)
let v178 : UH1 = UH1_1(v172, v177)
let v179 : bool = accepts_12(v171, v178)
let v180 : bool = v168 && v179
if v180 then
    ()
else
    failwith<unit> "generic decided matcher states should coexist in a higher-ranked batch without erasing alphabet indices"
if v168 then
    ()
else
    failwith<unit> "generic decided matcher existential should preserve a bit decision"
if v179 then
    ()
else
    failwith<unit> "generic decided matcher existential should preserve a ternary decision"
let v181 : US0 = US0_0
let v182 : UH2 = UH2_2(v181)
let v183 : US0 = US0_1
let v184 : UH2 = UH2_2(v183)
let v185 : UH2 = UH2_3(v182, v184)
let v186 : UH2 = UH2_5(v185)
let v187 : US0 = US0_0
let v188 : UH2 = UH2_2(v187)
let v189 : UH2 = UH2_4(v186, v188)
let v190 : US0 = US0_0
let v191 : US0 = US0_1
let v192 : UH4 = UH4_0
let v193 : UH4 = UH4_1(v191, v192)
let v194 : UH4 = UH4_1(v190, v193)
let v195 : UH5 = input_suffixes_22(v6)
let v196 : bool = derivative_semantic_triangle_symbols_23(v189, v194, v195)
let v215 : bool =
    if v196 then
        let v197 : US1 = US1_0
        let v198 : UH3 = UH3_2(v197)
        let v199 : US1 = US1_1
        let v200 : UH3 = UH3_2(v199)
        let v201 : UH3 = UH3_3(v198, v200)
        let v202 : UH3 = UH3_5(v201)
        let v203 : US1 = US1_2
        let v204 : UH3 = UH3_2(v203)
        let v205 : UH3 = UH3_4(v202, v204)
        let v206 : US1 = US1_0
        let v207 : US1 = US1_1
        let v208 : US1 = US1_2
        let v209 : UH6 = UH6_0
        let v210 : UH6 = UH6_1(v208, v209)
        let v211 : UH6 = UH6_1(v207, v210)
        let v212 : UH6 = UH6_1(v206, v211)
        let v213 : UH7 = input_suffixes_36(v28)
        derivative_semantic_triangle_symbols_37(v205, v212, v213)
    else
        false
if v215 then
    ()
else
    failwith<unit> "higher-ranked derivative programs should preserve their alphabet-indexed law interpreters"
let v216 : US0 = US0_0
let v217 : UH2 = UH2_2(v216)
let v218 : US0 = US0_1
let v219 : UH2 = UH2_2(v218)
let v220 : UH2 = UH2_3(v217, v219)
let v221 : UH2 = UH2_5(v220)
let v222 : US0 = US0_0
let v223 : UH2 = UH2_2(v222)
let v224 : UH2 = UH2_4(v221, v223)
let v225 : US0 = US0_0
let v226 : US0 = US0_1
let v227 : UH4 = UH4_0
let v228 : UH4 = UH4_1(v226, v227)
let v229 : UH4 = UH4_1(v225, v228)
let v230 : UH5 = input_suffixes_22(v6)
let v231 : bool = derivative_semantic_triangle_symbols_23(v224, v229, v230)
if v231 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v232 : US1 = US1_0
let v233 : UH3 = UH3_2(v232)
let v234 : US1 = US1_1
let v235 : UH3 = UH3_2(v234)
let v236 : UH3 = UH3_3(v233, v235)
let v237 : UH3 = UH3_5(v236)
let v238 : US1 = US1_2
let v239 : UH3 = UH3_2(v238)
let v240 : UH3 = UH3_4(v237, v239)
let v241 : US1 = US1_0
let v242 : US1 = US1_1
let v243 : US1 = US1_2
let v244 : UH6 = UH6_0
let v245 : UH6 = UH6_1(v243, v244)
let v246 : UH6 = UH6_1(v242, v245)
let v247 : UH6 = UH6_1(v241, v246)
let v248 : UH7 = input_suffixes_36(v28)
let v249 : bool = derivative_semantic_triangle_symbols_37(v240, v247, v248)
if v249 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v250 : US0 = US0_0
let v251 : UH2 = UH2_2(v250)
let v252 : US0 = US0_1
let v253 : UH2 = UH2_2(v252)
let v254 : UH2 = UH2_3(v251, v253)
let v255 : UH2 = UH2_5(v254)
let v256 : US0 = US0_0
let v257 : UH2 = UH2_2(v256)
let v258 : UH2 = UH2_4(v255, v257)
let v259 : UH5 = input_suffixes_22(v6)
let v260 : bool = normalization_language_law_suffixes_50(v258, v259)
if v260 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v261 : US1 = US1_0
let v262 : UH3 = UH3_2(v261)
let v263 : US1 = US1_1
let v264 : UH3 = UH3_2(v263)
let v265 : UH3 = UH3_3(v262, v264)
let v266 : UH3 = UH3_5(v265)
let v267 : US1 = US1_2
let v268 : UH3 = UH3_2(v267)
let v269 : UH3 = UH3_4(v266, v268)
let v270 : UH7 = input_suffixes_36(v28)
let v271 : bool = normalization_language_law_suffixes_51(v269, v270)
if v271 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v272 : US0 = US0_1
let v273 : US0 = US0_1
let v274 : US0 = US0_1
let v275 : UH0 = UH0_0
let v276 : UH0 = UH0_1(v274, v275)
let v277 : UH0 = UH0_1(v273, v276)
let v278 : UH0 = UH0_1(v272, v277)
let v279 : US0 = US0_0
let v280 : UH4 = UH4_0
let v281 : UH4 = UH4_1(v279, v280)
let v282 : bool = input_symbols_covered_52(v278, v281)
let v283 : bool = v282 = false
if v283 then
    ()
else
    failwith<unit> "input coverage must detect symbols omitted from the claimed inventory"
let v284 : US0 = US0_0
let v285 : UH2 = UH2_2(v284)
let v286 : US0 = US0_1
let v287 : UH2 = UH2_2(v286)
let v288 : UH2 = UH2_3(v285, v287)
let v289 : UH2 = UH2_5(v288)
let v290 : US0 = US0_0
let v291 : UH2 = UH2_2(v290)
let v292 : UH2 = UH2_4(v289, v291)
let v293 : UH2 = normalize_4(v292)
let v294 : US0 = US0_0
let v295 : US0 = US0_1
let v296 : UH4 = UH4_0
let v297 : UH4 = UH4_1(v295, v296)
let v298 : UH4 = UH4_1(v294, v297)
let v299 : UH8 = UH8_0
let v300 : UH9 = UH9_0
let v301 : UH9 = UH9_1(v293, v300)
let v302 : UH9 = UH9_0
let v303 : UH9 = UH9_1(v293, v302)
let v304 : US4 = dfa_closure_loop_bounded_54(v298, v299, v301, v303)
let v308 : bool =
    match v304 with
    | US4_1(v306) -> (* DfaClosureBudgetExceeded *)
        false
    | US4_0(v305) -> (* DfaClosureComplete *)
        true
let v309 : bool = v308 = false
if v309 then
    ()
else
    failwith<unit> "zero closure budget must terminate as budget-exceeded rather than recurse without a bound"
let v310 : US0 = US0_0
let v311 : US0 = US0_1
let v312 : UH4 = UH4_0
let v313 : UH4 = UH4_1(v311, v312)
let v314 : UH4 = UH4_1(v310, v313)
let v315 : UH9 = regex_chars_from_symbols_57(v314)
let v316 : UH2 = UH2_0
let v317 : UH2 = UH2_1
let v318 : UH9 = UH9_1(v317, v315)
let v319 : UH9 = UH9_1(v316, v318)
let v320 : UH9 = regex_star_corpus_58(v319)
let v321 : UH2 = UH2_0
let v322 : UH2 = UH2_1
let v323 : UH9 = UH9_1(v322, v315)
let v324 : UH9 = UH9_1(v321, v323)
let v325 : UH2 = UH2_0
let v326 : UH2 = UH2_1
let v327 : UH9 = UH9_1(v326, v315)
let v328 : UH9 = UH9_1(v325, v327)
let v329 : UH9 = regex_binary_corpus_59(v324, v328)
let v330 : US0 = US0_0
let v331 : US0 = US0_1
let v332 : UH4 = UH4_0
let v333 : UH4 = UH4_1(v331, v332)
let v334 : UH4 = UH4_1(v330, v333)
let v335 : UH9 = regex_chars_from_symbols_57(v334)
let v336 : UH2 = UH2_0
let v337 : UH2 = UH2_1
let v338 : UH9 = UH9_1(v337, v335)
let v339 : UH9 = UH9_1(v336, v338)
let v340 : UH2 = UH2_0
let v341 : UH2 = UH2_1
let v342 : UH9 = UH9_1(v341, v335)
let v343 : UH9 = UH9_1(v340, v342)
let v344 : UH9 = regex_star_corpus_58(v343)
let v345 : UH2 = UH2_0
let v346 : UH2 = UH2_1
let v347 : UH9 = UH9_1(v346, v335)
let v348 : UH9 = UH9_1(v345, v347)
let v349 : UH2 = UH2_0
let v350 : UH2 = UH2_1
let v351 : UH9 = UH9_1(v350, v335)
let v352 : UH9 = UH9_1(v349, v351)
let v353 : UH9 = regex_binary_corpus_59(v348, v352)
let v354 : UH9 = regex_list_append_61(v344, v353)
let v355 : UH9 = regex_list_append_61(v339, v354)
let v356 : US0 = US0_0
let v357 : US0 = US0_1
let v358 : UH4 = UH4_0
let v359 : UH4 = UH4_1(v357, v358)
let v360 : UH4 = UH4_1(v356, v359)
let v361 : UH5 = input_suffixes_22(v6)
let v362 : bool = derivative_language_law_corpus_62(v355, v360, v361)
if v362 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v363 : UH3 = UH3_0
let v364 : UH3 = UH3_1
let v365 : US1 = US1_0
let v366 : UH3 = UH3_2(v365)
let v367 : US1 = US1_0
let v368 : UH3 = UH3_2(v367)
let v369 : US1 = US1_1
let v370 : UH3 = UH3_2(v369)
let v371 : UH3 = UH3_3(v368, v370)
let v372 : US1 = US1_0
let v373 : UH3 = UH3_2(v372)
let v374 : US1 = US1_2
let v375 : UH3 = UH3_2(v374)
let v376 : UH3 = UH3_4(v373, v375)
let v377 : US1 = US1_1
let v378 : UH3 = UH3_2(v377)
let v379 : UH3 = UH3_5(v378)
let v380 : UH10 = UH10_0
let v381 : UH10 = UH10_1(v379, v380)
let v382 : UH10 = UH10_1(v376, v381)
let v383 : UH10 = UH10_1(v371, v382)
let v384 : UH10 = UH10_1(v366, v383)
let v385 : UH10 = UH10_1(v364, v384)
let v386 : UH10 = UH10_1(v363, v385)
let v387 : US1 = US1_0
let v388 : US1 = US1_1
let v389 : US1 = US1_2
let v390 : UH6 = UH6_0
let v391 : UH6 = UH6_1(v389, v390)
let v392 : UH6 = UH6_1(v388, v391)
let v393 : UH6 = UH6_1(v387, v392)
let v394 : UH7 = input_suffixes_36(v21)
let v395 : bool = derivative_language_law_corpus_65(v386, v393, v394)
if v395 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v396 : UH5 = input_suffixes_22(v6)
let v397 : bool = normalization_language_law_corpus_68(v355, v396)
if v397 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v398 : UH3 = UH3_0
let v399 : UH3 = UH3_1
let v400 : US1 = US1_0
let v401 : UH3 = UH3_2(v400)
let v402 : US1 = US1_0
let v403 : UH3 = UH3_2(v402)
let v404 : US1 = US1_1
let v405 : UH3 = UH3_2(v404)
let v406 : UH3 = UH3_3(v403, v405)
let v407 : US1 = US1_0
let v408 : UH3 = UH3_2(v407)
let v409 : US1 = US1_2
let v410 : UH3 = UH3_2(v409)
let v411 : UH3 = UH3_4(v408, v410)
let v412 : US1 = US1_1
let v413 : UH3 = UH3_2(v412)
let v414 : UH3 = UH3_5(v413)
let v415 : UH10 = UH10_0
let v416 : UH10 = UH10_1(v414, v415)
let v417 : UH10 = UH10_1(v411, v416)
let v418 : UH10 = UH10_1(v406, v417)
let v419 : UH10 = UH10_1(v401, v418)
let v420 : UH10 = UH10_1(v399, v419)
let v421 : UH10 = UH10_1(v398, v420)
let v422 : UH7 = input_suffixes_36(v21)
let v423 : bool = normalization_language_law_corpus_69(v421, v422)
if v423 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v424 : UH2 = UH2_0
let v425 : UH2 = UH2_1
let v426 : UH9 = UH9_1(v425, v315)
let v427 : UH9 = UH9_1(v424, v426)
let v428 : US0 = US0_0
let v429 : US0 = US0_1
let v430 : UH4 = UH4_0
let v431 : UH4 = UH4_1(v429, v430)
let v432 : UH4 = UH4_1(v428, v431)
let v433 : bool = dfa_formula_consistent_70(v427, v432)
if v433 then
    ()
else
    failwith<unit> "base derivative equations should hold structurally"
let v434 : US0 = US0_0
let v435 : US0 = US0_1
let v436 : UH4 = UH4_0
let v437 : UH4 = UH4_1(v435, v436)
let v438 : UH4 = UH4_1(v434, v437)
let v439 : bool = dfa_formula_consistent_70(v320, v438)
if v439 then
    ()
else
    failwith<unit> "star derivative equations should hold structurally"
let v440 : US0 = US0_0
let v441 : US0 = US0_1
let v442 : UH4 = UH4_0
let v443 : UH4 = UH4_1(v441, v442)
let v444 : UH4 = UH4_1(v440, v443)
let v445 : bool = dfa_formula_consistent_70(v329, v444)
if v445 then
    ()
else
    failwith<unit> "binary derivative equations should hold structurally"
let v446 : US0 = US0_0
let v447 : US0 = US0_1
let v448 : UH4 = UH4_0
let v449 : UH4 = UH4_1(v447, v448)
let v450 : UH4 = UH4_1(v446, v449)
let v451 : bool = dfa_formula_consistent_70(v355, v450)
if v451 then
    ()
else
    failwith<unit> "generated derivative equations should hold structurally"
let v452 : bool = dfa_states_nullable_preserved_74(v355)
if v452 then
    ()
else
    failwith<unit> "generated corpus should preserve nullable under normalization"
let v453 : bool = regex_list_normalization_idempotent_75(v355)
if v453 then
    ()
else
    failwith<unit> "generated corpus normalization should be idempotent"
let v454 : US0 = US0_0
let v455 : US0 = US0_1
let v456 : UH4 = UH4_0
let v457 : UH4 = UH4_1(v455, v456)
let v458 : UH4 = UH4_1(v454, v457)
let v459 : bool = canonical_derivative_coherent_corpus_76(v355, v458)
if v459 then
    ()
else
    failwith<unit> "generated bit corpus should commute canonical derivation with prior normalization"
let v460 : UH3 = UH3_0
let v461 : UH3 = UH3_1
let v462 : US1 = US1_0
let v463 : UH3 = UH3_2(v462)
let v464 : US1 = US1_0
let v465 : UH3 = UH3_2(v464)
let v466 : US1 = US1_1
let v467 : UH3 = UH3_2(v466)
let v468 : UH3 = UH3_3(v465, v467)
let v469 : US1 = US1_0
let v470 : UH3 = UH3_2(v469)
let v471 : US1 = US1_2
let v472 : UH3 = UH3_2(v471)
let v473 : UH3 = UH3_4(v470, v472)
let v474 : US1 = US1_1
let v475 : UH3 = UH3_2(v474)
let v476 : UH3 = UH3_5(v475)
let v477 : UH10 = UH10_0
let v478 : UH10 = UH10_1(v476, v477)
let v479 : UH10 = UH10_1(v473, v478)
let v480 : UH10 = UH10_1(v468, v479)
let v481 : UH10 = UH10_1(v463, v480)
let v482 : UH10 = UH10_1(v461, v481)
let v483 : UH10 = UH10_1(v460, v482)
let v484 : US1 = US1_0
let v485 : US1 = US1_1
let v486 : US1 = US1_2
let v487 : UH6 = UH6_0
let v488 : UH6 = UH6_1(v486, v487)
let v489 : UH6 = UH6_1(v485, v488)
let v490 : UH6 = UH6_1(v484, v489)
let v491 : bool = canonical_derivative_coherent_corpus_78(v483, v490)
if v491 then
    ()
else
    failwith<unit> "ternary constructor corpus should commute canonical derivation with prior normalization"
let v492 : US0 = US0_0
let v493 : UH2 = UH2_2(v492)
let v494 : US0 = US0_1
let v495 : UH2 = UH2_2(v494)
let v496 : UH2 = UH2_3(v493, v495)
let v497 : UH2 = UH2_5(v496)
let v498 : US0 = US0_0
let v499 : UH2 = UH2_2(v498)
let v500 : UH2 = UH2_4(v497, v499)
let v501 : UH2 = normalize_4(v500)
let v502 : US0 = US0_0
let v503 : US0 = US0_1
let v504 : UH4 = UH4_0
let v505 : UH4 = UH4_1(v503, v504)
let v506 : UH4 = UH4_1(v502, v505)
let v507 : UH9 = UH9_0
let v508 : UH9 = UH9_1(v501, v507)
let v509 : UH9 = UH9_0
let v510 : UH9 = UH9_1(v501, v509)
let v511 : UH9 = dfa_closure_loop_80(v506, v508, v510)
let v512 : US0 = US0_0
let v513 : US0 = US0_1
let v514 : UH4 = UH4_0
let v515 : UH4 = UH4_1(v513, v514)
let v516 : UH4 = UH4_1(v512, v515)
let v517 : bool = dfa_partition_one_distinct_81(v511, v516)
if v517 then
    ()
else
    failwith<unit> "bit DFA one-step signatures should be distinct"
let v518 : US1 = US1_0
let v519 : UH3 = UH3_2(v518)
let v520 : UH3 = UH3_5(v519)
let v521 : UH3 = normalize_14(v520)
let v522 : US1 = US1_0
let v523 : US1 = US1_1
let v524 : US1 = US1_2
let v525 : UH6 = UH6_0
let v526 : UH6 = UH6_1(v524, v525)
let v527 : UH6 = UH6_1(v523, v526)
let v528 : UH6 = UH6_1(v522, v527)
let v529 : UH10 = UH10_0
let v530 : UH10 = UH10_1(v521, v529)
let v531 : UH10 = UH10_0
let v532 : UH10 = UH10_1(v521, v531)
let v533 : UH10 = dfa_closure_loop_84(v528, v530, v532)
let v534 : US1 = US1_0
let v535 : US1 = US1_1
let v536 : US1 = US1_2
let v537 : UH6 = UH6_0
let v538 : UH6 = UH6_1(v536, v537)
let v539 : UH6 = UH6_1(v535, v538)
let v540 : UH6 = UH6_1(v534, v539)
let v541 : bool = dfa_partition_one_distinct_87(v533, v540)
if v541 then
    ()
else
    failwith<unit> "ternary star one-step signatures should be distinct"
let v542 : US1 = US1_0
let v543 : UH3 = UH3_2(v542)
let v544 : US1 = US1_1
let v545 : UH3 = UH3_2(v544)
let v546 : UH3 = UH3_3(v543, v545)
let v547 : UH3 = UH3_5(v546)
let v548 : US1 = US1_2
let v549 : UH3 = UH3_2(v548)
let v550 : UH3 = UH3_4(v547, v549)
let v551 : UH3 = normalize_14(v550)
let v552 : US1 = US1_0
let v553 : US1 = US1_1
let v554 : US1 = US1_2
let v555 : UH6 = UH6_0
let v556 : UH6 = UH6_1(v554, v555)
let v557 : UH6 = UH6_1(v553, v556)
let v558 : UH6 = UH6_1(v552, v557)
let v559 : UH10 = UH10_0
let v560 : UH10 = UH10_1(v551, v559)
let v561 : UH10 = UH10_0
let v562 : UH10 = UH10_1(v551, v561)
let v563 : UH10 = dfa_closure_loop_84(v558, v560, v562)
let v564 : US1 = US1_0
let v565 : US1 = US1_1
let v566 : US1 = US1_2
let v567 : UH6 = UH6_0
let v568 : UH6 = UH6_1(v566, v567)
let v569 : UH6 = UH6_1(v565, v568)
let v570 : UH6 = UH6_1(v564, v569)
let v571 : bool = dfa_partition_one_distinct_87(v563, v570)
if v571 then
    ()
else
    failwith<unit> "ternary suffix one-step signatures should be distinct"
let v572 : US0 = US0_0
let v573 : UH2 = UH2_2(v572)
let v574 : US0 = US0_1
let v575 : UH2 = UH2_2(v574)
let v576 : UH2 = UH2_3(v573, v575)
let v577 : UH2 = UH2_5(v576)
let v578 : US0 = US0_0
let v579 : UH2 = UH2_2(v578)
let v580 : UH2 = UH2_4(v577, v579)
let v581 : UH2 = normalize_4(v580)
let v582 : US0 = US0_0
let v583 : US0 = US0_1
let v584 : UH4 = UH4_0
let v585 : UH4 = UH4_1(v583, v584)
let v586 : UH4 = UH4_1(v582, v585)
let v587 : UH9 = UH9_0
let v588 : UH9 = UH9_1(v581, v587)
let v589 : UH9 = UH9_0
let v590 : UH9 = UH9_1(v581, v589)
let v591 : UH9 = dfa_closure_loop_80(v586, v588, v590)
let v592 : US0 = US0_0
let v593 : US0 = US0_1
let v594 : UH4 = UH4_0
let v595 : UH4 = UH4_1(v593, v594)
let v596 : UH4 = UH4_1(v592, v595)
let v597 : bool = dfa_minimal_by_bisimulation_90(v591, v596)
if v597 then
    ()
else
    failwith<unit> "bit DFA should be behaviorally minimal"
let v598 : US1 = US1_0
let v599 : UH3 = UH3_2(v598)
let v600 : UH3 = UH3_5(v599)
let v601 : UH3 = normalize_14(v600)
let v602 : US1 = US1_0
let v603 : US1 = US1_1
let v604 : US1 = US1_2
let v605 : UH6 = UH6_0
let v606 : UH6 = UH6_1(v604, v605)
let v607 : UH6 = UH6_1(v603, v606)
let v608 : UH6 = UH6_1(v602, v607)
let v609 : UH10 = UH10_0
let v610 : UH10 = UH10_1(v601, v609)
let v611 : UH10 = UH10_0
let v612 : UH10 = UH10_1(v601, v611)
let v613 : UH10 = dfa_closure_loop_84(v608, v610, v612)
let v614 : US1 = US1_0
let v615 : US1 = US1_1
let v616 : US1 = US1_2
let v617 : UH6 = UH6_0
let v618 : UH6 = UH6_1(v616, v617)
let v619 : UH6 = UH6_1(v615, v618)
let v620 : UH6 = UH6_1(v614, v619)
let v621 : bool = dfa_minimal_by_bisimulation_95(v613, v620)
if v621 then
    ()
else
    failwith<unit> "ternary star DFA should be behaviorally minimal"
let v622 : US1 = US1_0
let v623 : UH3 = UH3_2(v622)
let v624 : US1 = US1_1
let v625 : UH3 = UH3_2(v624)
let v626 : UH3 = UH3_3(v623, v625)
let v627 : UH3 = UH3_5(v626)
let v628 : US1 = US1_2
let v629 : UH3 = UH3_2(v628)
let v630 : UH3 = UH3_4(v627, v629)
let v631 : UH3 = normalize_14(v630)
let v632 : US1 = US1_0
let v633 : US1 = US1_1
let v634 : US1 = US1_2
let v635 : UH6 = UH6_0
let v636 : UH6 = UH6_1(v634, v635)
let v637 : UH6 = UH6_1(v633, v636)
let v638 : UH6 = UH6_1(v632, v637)
let v639 : UH10 = UH10_0
let v640 : UH10 = UH10_1(v631, v639)
let v641 : UH10 = UH10_0
let v642 : UH10 = UH10_1(v631, v641)
let v643 : UH10 = dfa_closure_loop_84(v638, v640, v642)
let v644 : US1 = US1_0
let v645 : US1 = US1_1
let v646 : US1 = US1_2
let v647 : UH6 = UH6_0
let v648 : UH6 = UH6_1(v646, v647)
let v649 : UH6 = UH6_1(v645, v648)
let v650 : UH6 = UH6_1(v644, v649)
let v651 : bool = dfa_minimal_by_bisimulation_95(v643, v650)
if v651 then
    ()
else
    failwith<unit> "ternary suffix DFA should be behaviorally minimal"
let v652 : US1 = US1_0
let v653 : UH3 = UH3_2(v652)
let v654 : US1 = US1_0
let v655 : UH3 = UH3_2(v654)
let v656 : UH3 = UH3_5(v655)
let v657 : UH3 = UH3_4(v653, v656)
let v658 : US1 = US1_1
let v659 : UH3 = UH3_2(v658)
let v660 : US1 = US1_0
let v661 : UH3 = UH3_2(v660)
let v662 : US1 = US1_0
let v663 : UH3 = UH3_2(v662)
let v664 : UH3 = UH3_4(v661, v663)
let v665 : UH3 = UH3_5(v664)
let v666 : US1 = US1_0
let v667 : UH3 = UH3_2(v666)
let v668 : UH3 = UH3_4(v667, v665)
let v669 : UH3 = UH3_3(v665, v668)
let v670 : UH3 = UH3_4(v659, v669)
let v671 : UH3 = UH3_3(v657, v670)
let v672 : UH3 = normalize_14(v671)
let v673 : US1 = US1_0
let v674 : US1 = US1_1
let v675 : US1 = US1_2
let v676 : UH6 = UH6_0
let v677 : UH6 = UH6_1(v675, v676)
let v678 : UH6 = UH6_1(v674, v677)
let v679 : UH6 = UH6_1(v673, v678)
let v680 : UH10 = UH10_0
let v681 : UH10 = UH10_1(v672, v680)
let v682 : UH10 = UH10_0
let v683 : UH10 = UH10_1(v672, v682)
let v684 : UH10 = dfa_closure_loop_84(v679, v681, v683)
let v685 : US1 = US1_0
let v686 : US1 = US1_1
let v687 : US1 = US1_2
let v688 : UH6 = UH6_0
let v689 : UH6 = UH6_1(v687, v688)
let v690 : UH6 = UH6_1(v686, v689)
let v691 : UH6 = UH6_1(v685, v690)
let v692 : bool = dfa_partition_one_distinct_87(v684, v691)
if v692 then
    ()
else
    failwith<unit> "one-step partition should miss cyclic language equivalence"
let v693 : US1 = US1_0
let v694 : US1 = US1_1
let v695 : US1 = US1_2
let v696 : UH6 = UH6_0
let v697 : UH6 = UH6_1(v695, v696)
let v698 : UH6 = UH6_1(v694, v697)
let v699 : UH6 = UH6_1(v693, v698)
let v700 : bool = dfa_minimal_by_bisimulation_95(v684, v699)
let v701 : bool = v700 = false
if v701 then
    ()
else
    failwith<unit> "bisimulation should detect cyclic language equivalence"
let v702 : US0 = US0_0
let v703 : UH2 = UH2_2(v702)
let v704 : US0 = US0_1
let v705 : UH2 = UH2_2(v704)
let v706 : UH2 = UH2_3(v703, v705)
let v707 : UH2 = UH2_5(v706)
let v708 : US0 = US0_0
let v709 : UH2 = UH2_2(v708)
let v710 : UH2 = UH2_4(v707, v709)
let v711 : US0 = US0_1
let v712 : US0 = US0_1
let v713 : US0 = US0_0
let v714 : UH0 = UH0_0
let v715 : UH0 = UH0_1(v713, v714)
let v716 : UH0 = UH0_1(v712, v715)
let v717 : UH0 = UH0_1(v711, v716)
let v718 : US5 = US5_0(v710, v717)
let v719 : US6 = decide_bit_match_100(v718)
let v720 : US0 = US0_0
let v721 : UH2 = UH2_2(v720)
let v722 : US0 = US0_1
let v723 : UH2 = UH2_2(v722)
let v724 : UH2 = UH2_3(v721, v723)
let v725 : UH2 = UH2_5(v724)
let v726 : US0 = US0_0
let v727 : UH2 = UH2_2(v726)
let v728 : UH2 = UH2_4(v725, v727)
let v729 : US0 = US0_1
let v730 : US0 = US0_1
let v731 : US0 = US0_1
let v732 : UH0 = UH0_0
let v733 : UH0 = UH0_1(v731, v732)
let v734 : UH0 = UH0_1(v730, v733)
let v735 : UH0 = UH0_1(v729, v734)
let v736 : US5 = US5_0(v728, v735)
let v737 : US6 = decide_bit_match_100(v736)
let v738 : bool = bit_match_value_101(v719)
if v738 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v739 : bool = bit_match_value_101(v737)
if v739 then
    failwith<unit> "brzozowski-expected-false"
let v740 : US0 = US0_0
let v741 : UH2 = UH2_2(v740)
let v742 : US0 = US0_1
let v743 : UH2 = UH2_2(v742)
let v744 : UH2 = UH2_3(v741, v743)
let v745 : UH2 = UH2_5(v744)
let v746 : US0 = US0_0
let v747 : UH2 = UH2_2(v746)
let v748 : UH2 = UH2_4(v745, v747)
let v749 : US0 = US0_1
let v750 : US0 = US0_1
let v751 : US0 = US0_0
let v752 : UH0 = UH0_0
let v753 : UH0 = UH0_1(v751, v752)
let v754 : UH0 = UH0_1(v750, v753)
let v755 : UH0 = UH0_1(v749, v754)
let v756 : bool = accepts_2(v748, v755)
let v757 : US0 = US0_0
let v758 : UH2 = UH2_2(v757)
let v759 : US0 = US0_1
let v760 : UH2 = UH2_2(v759)
let v761 : UH2 = UH2_3(v758, v760)
let v762 : UH2 = UH2_5(v761)
let v763 : US0 = US0_0
let v764 : UH2 = UH2_2(v763)
let v765 : UH2 = UH2_4(v762, v764)
let v766 : US0 = US0_1
let v767 : US0 = US0_1
let v768 : US0 = US0_1
let v769 : UH0 = UH0_0
let v770 : UH0 = UH0_1(v768, v769)
let v771 : UH0 = UH0_1(v767, v770)
let v772 : UH0 = UH0_1(v766, v771)
let v773 : bool = accepts_2(v765, v772)
if v756 then
    ()
else
    failwith<unit> "existential match seal should preserve acceptance"
let v774 : bool = v773 = false
if v774 then
    ()
else
    failwith<unit> "existential match seal should preserve rejection"
let v775 : US0 = US0_0
let v776 : UH2 = UH2_2(v775)
let v777 : US0 = US0_1
let v778 : UH2 = UH2_2(v777)
let v779 : UH2 = UH2_3(v776, v778)
let v780 : UH2 = UH2_5(v779)
let v781 : US0 = US0_0
let v782 : UH2 = UH2_2(v781)
let v783 : UH2 = UH2_4(v780, v782)
let v784 : UH2 = normalize_4(v783)
let v785 : UH2 = normalize_4(v784)
let v786 : UH8 = regex_position_count_102(v785)
let v787 : UH8 = UH8_1(v786)
let v788 : UH8 = state_budget_pow2_104(v787)
let v789 : UH2 = normalize_4(v785)
let v790 : US0 = US0_0
let v791 : US0 = US0_1
let v792 : UH4 = UH4_0
let v793 : UH4 = UH4_1(v791, v792)
let v794 : UH4 = UH4_1(v790, v793)
let v795 : UH9 = UH9_0
let v796 : UH9 = UH9_1(v789, v795)
let v797 : UH9 = UH9_0
let v798 : UH9 = UH9_1(v789, v797)
let v799 : US4 = dfa_closure_loop_bounded_54(v794, v788, v796, v798)
let v803 : UH9 =
    match v799 with
    | US4_1(v801) -> (* DfaClosureBudgetExceeded *)
        v801
    | US4_0(v800) -> (* DfaClosureComplete *)
        v800
let v807 : bool =
    match v799 with
    | US4_1(v805) -> (* DfaClosureBudgetExceeded *)
        false
    | US4_0(v804) -> (* DfaClosureComplete *)
        true
let v808 : US0 = US0_0
let v809 : US0 = US0_1
let v810 : UH4 = UH4_0
let v811 : UH4 = UH4_1(v809, v810)
let v812 : UH4 = UH4_1(v808, v811)
let v813 : UH13 = dfa_transition_table_106(v803, v812)
let v820 : bool =
    if v807 then
        let v814 : US0 = US0_0
        let v815 : US0 = US0_1
        let v816 : UH4 = UH4_0
        let v817 : UH4 = UH4_1(v815, v816)
        let v818 : UH4 = UH4_1(v814, v817)
        dfa_closure_closed_109(v803, v818)
    else
        false
let v821 : bool = regex_list_distinct_112(v803)
let v828 : bool =
    if v807 then
        let v822 : US0 = US0_0
        let v823 : US0 = US0_1
        let v824 : UH4 = UH4_0
        let v825 : UH4 = UH4_1(v823, v824)
        let v826 : UH4 = UH4_1(v822, v825)
        dfa_formula_consistent_70(v803, v826)
    else
        false
let v835 : bool =
    if v807 then
        let v829 : US0 = US0_0
        let v830 : US0 = US0_1
        let v831 : UH4 = UH4_0
        let v832 : UH4 = UH4_1(v830, v831)
        let v833 : UH4 = UH4_1(v829, v832)
        dfa_transition_table_total_113(v803, v833, v813)
    else
        false
let v836 : bool = dfa_transition_keys_distinct_116(v813)
let v841 : bool =
    if v807 then
        let v837 : UH8 = regex_position_count_102(v784)
        let v838 : UH8 = UH8_1(v837)
        let v839 : UH8 = state_budget_pow2_104(v838)
        regex_list_within_budget_118(v803, v839)
    else
        false
let v842 : bool = dfa_states_normalized_119(v803)
let v843 : bool = dfa_states_nullable_preserved_74(v803)
let v844 : bool = regex_order_laws_120(v803)
let v845 : US1 = US1_0
let v846 : UH3 = UH3_2(v845)
let v847 : UH3 = UH3_5(v846)
let v848 : UH3 = normalize_14(v847)
let v849 : UH3 = normalize_14(v848)
let v850 : UH8 = regex_position_count_123(v849)
let v851 : UH8 = UH8_1(v850)
let v852 : UH8 = state_budget_pow2_104(v851)
let v853 : UH3 = normalize_14(v849)
let v854 : US1 = US1_0
let v855 : US1 = US1_1
let v856 : US1 = US1_2
let v857 : UH6 = UH6_0
let v858 : UH6 = UH6_1(v856, v857)
let v859 : UH6 = UH6_1(v855, v858)
let v860 : UH6 = UH6_1(v854, v859)
let v861 : UH10 = UH10_0
let v862 : UH10 = UH10_1(v853, v861)
let v863 : UH10 = UH10_0
let v864 : UH10 = UH10_1(v853, v863)
let v865 : US8 = dfa_closure_loop_bounded_124(v860, v852, v862, v864)
let v869 : UH10 =
    match v865 with
    | US8_1(v867) -> (* DfaClosureBudgetExceeded *)
        v867
    | US8_0(v866) -> (* DfaClosureComplete *)
        v866
let v873 : bool =
    match v865 with
    | US8_1(v871) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v870) -> (* DfaClosureComplete *)
        true
let v874 : US1 = US1_0
let v875 : US1 = US1_1
let v876 : US1 = US1_2
let v877 : UH6 = UH6_0
let v878 : UH6 = UH6_1(v876, v877)
let v879 : UH6 = UH6_1(v875, v878)
let v880 : UH6 = UH6_1(v874, v879)
let v881 : UH14 = dfa_transition_table_125(v869, v880)
let v890 : bool =
    if v873 then
        let v882 : US1 = US1_0
        let v883 : US1 = US1_1
        let v884 : US1 = US1_2
        let v885 : UH6 = UH6_0
        let v886 : UH6 = UH6_1(v884, v885)
        let v887 : UH6 = UH6_1(v883, v886)
        let v888 : UH6 = UH6_1(v882, v887)
        dfa_closure_closed_128(v869, v888)
    else
        false
let v891 : bool = regex_list_distinct_131(v869)
let v900 : bool =
    if v873 then
        let v892 : US1 = US1_0
        let v893 : US1 = US1_1
        let v894 : US1 = US1_2
        let v895 : UH6 = UH6_0
        let v896 : UH6 = UH6_1(v894, v895)
        let v897 : UH6 = UH6_1(v893, v896)
        let v898 : UH6 = UH6_1(v892, v897)
        dfa_formula_consistent_132(v869, v898)
    else
        false
let v909 : bool =
    if v873 then
        let v901 : US1 = US1_0
        let v902 : US1 = US1_1
        let v903 : US1 = US1_2
        let v904 : UH6 = UH6_0
        let v905 : UH6 = UH6_1(v903, v904)
        let v906 : UH6 = UH6_1(v902, v905)
        let v907 : UH6 = UH6_1(v901, v906)
        dfa_transition_table_total_136(v869, v907, v881)
    else
        false
let v910 : bool = dfa_transition_keys_distinct_139(v881)
let v915 : bool =
    if v873 then
        let v911 : UH8 = regex_position_count_123(v848)
        let v912 : UH8 = UH8_1(v911)
        let v913 : UH8 = state_budget_pow2_104(v912)
        regex_list_within_budget_141(v869, v913)
    else
        false
let v916 : bool = dfa_states_normalized_142(v869)
let v917 : bool = dfa_states_nullable_preserved_143(v869)
let v918 : bool = regex_order_laws_144(v869)
let v919 : US1 = US1_0
let v920 : UH3 = UH3_2(v919)
let v921 : US1 = US1_1
let v922 : UH3 = UH3_2(v921)
let v923 : UH3 = UH3_3(v920, v922)
let v924 : UH3 = UH3_5(v923)
let v925 : US1 = US1_2
let v926 : UH3 = UH3_2(v925)
let v927 : UH3 = UH3_4(v924, v926)
let v928 : UH3 = normalize_14(v927)
let v929 : UH3 = normalize_14(v928)
let v930 : UH8 = regex_position_count_123(v929)
let v931 : UH8 = UH8_1(v930)
let v932 : UH8 = state_budget_pow2_104(v931)
let v933 : UH3 = normalize_14(v929)
let v934 : US1 = US1_0
let v935 : US1 = US1_1
let v936 : US1 = US1_2
let v937 : UH6 = UH6_0
let v938 : UH6 = UH6_1(v936, v937)
let v939 : UH6 = UH6_1(v935, v938)
let v940 : UH6 = UH6_1(v934, v939)
let v941 : UH10 = UH10_0
let v942 : UH10 = UH10_1(v933, v941)
let v943 : UH10 = UH10_0
let v944 : UH10 = UH10_1(v933, v943)
let v945 : US8 = dfa_closure_loop_bounded_124(v940, v932, v942, v944)
let v949 : UH10 =
    match v945 with
    | US8_1(v947) -> (* DfaClosureBudgetExceeded *)
        v947
    | US8_0(v946) -> (* DfaClosureComplete *)
        v946
let v953 : bool =
    match v945 with
    | US8_1(v951) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v950) -> (* DfaClosureComplete *)
        true
let v954 : US1 = US1_0
let v955 : US1 = US1_1
let v956 : US1 = US1_2
let v957 : UH6 = UH6_0
let v958 : UH6 = UH6_1(v956, v957)
let v959 : UH6 = UH6_1(v955, v958)
let v960 : UH6 = UH6_1(v954, v959)
let v961 : UH14 = dfa_transition_table_125(v949, v960)
let v970 : bool =
    if v953 then
        let v962 : US1 = US1_0
        let v963 : US1 = US1_1
        let v964 : US1 = US1_2
        let v965 : UH6 = UH6_0
        let v966 : UH6 = UH6_1(v964, v965)
        let v967 : UH6 = UH6_1(v963, v966)
        let v968 : UH6 = UH6_1(v962, v967)
        dfa_closure_closed_128(v949, v968)
    else
        false
let v971 : bool = regex_list_distinct_131(v949)
let v980 : bool =
    if v953 then
        let v972 : US1 = US1_0
        let v973 : US1 = US1_1
        let v974 : US1 = US1_2
        let v975 : UH6 = UH6_0
        let v976 : UH6 = UH6_1(v974, v975)
        let v977 : UH6 = UH6_1(v973, v976)
        let v978 : UH6 = UH6_1(v972, v977)
        dfa_formula_consistent_132(v949, v978)
    else
        false
let v989 : bool =
    if v953 then
        let v981 : US1 = US1_0
        let v982 : US1 = US1_1
        let v983 : US1 = US1_2
        let v984 : UH6 = UH6_0
        let v985 : UH6 = UH6_1(v983, v984)
        let v986 : UH6 = UH6_1(v982, v985)
        let v987 : UH6 = UH6_1(v981, v986)
        dfa_transition_table_total_136(v949, v987, v961)
    else
        false
let v990 : bool = dfa_transition_keys_distinct_139(v961)
let v995 : bool =
    if v953 then
        let v991 : UH8 = regex_position_count_123(v928)
        let v992 : UH8 = UH8_1(v991)
        let v993 : UH8 = state_budget_pow2_104(v992)
        regex_list_within_budget_141(v949, v993)
    else
        false
let v996 : bool = dfa_states_normalized_142(v949)
let v997 : bool = dfa_states_nullable_preserved_143(v949)
let v998 : bool = regex_order_laws_144(v949)
let v999 : US0 = US0_0
let v1000 : UH2 = UH2_2(v999)
let v1001 : US0 = US0_1
let v1002 : UH2 = UH2_2(v1001)
let v1003 : UH2 = UH2_3(v1000, v1002)
let v1004 : UH2 = UH2_5(v1003)
let v1005 : US0 = US0_0
let v1006 : UH2 = UH2_2(v1005)
let v1007 : UH2 = UH2_4(v1004, v1006)
let v1008 : UH2 = normalize_4(v1007)
let v1009 : UH2 = normalize_4(v1008)
let v1010 : UH8 = regex_position_count_102(v1009)
let v1011 : UH8 = UH8_1(v1010)
let v1012 : UH8 = state_budget_pow2_104(v1011)
let v1013 : UH2 = normalize_4(v1009)
let v1014 : US0 = US0_0
let v1015 : US0 = US0_1
let v1016 : UH4 = UH4_0
let v1017 : UH4 = UH4_1(v1015, v1016)
let v1018 : UH4 = UH4_1(v1014, v1017)
let v1019 : UH9 = UH9_0
let v1020 : UH9 = UH9_1(v1013, v1019)
let v1021 : UH9 = UH9_0
let v1022 : UH9 = UH9_1(v1013, v1021)
let v1023 : US4 = dfa_closure_loop_bounded_54(v1018, v1012, v1020, v1022)
let v1027 : UH9 =
    match v1023 with
    | US4_1(v1025) -> (* DfaClosureBudgetExceeded *)
        v1025
    | US4_0(v1024) -> (* DfaClosureComplete *)
        v1024
let v1031 : bool =
    match v1023 with
    | US4_1(v1029) -> (* DfaClosureBudgetExceeded *)
        false
    | US4_0(v1028) -> (* DfaClosureComplete *)
        true
let v1032 : US0 = US0_0
let v1033 : US0 = US0_1
let v1034 : UH4 = UH4_0
let v1035 : UH4 = UH4_1(v1033, v1034)
let v1036 : UH4 = UH4_1(v1032, v1035)
let v1037 : UH9 = UH9_0
let v1038 : UH9 = dfa_minimize_states_loop_147(v1027, v1036, v1037)
let v1045 : bool =
    if v1031 then
        let v1039 : US0 = US0_0
        let v1040 : US0 = US0_1
        let v1041 : UH4 = UH4_0
        let v1042 : UH4 = UH4_1(v1040, v1041)
        let v1043 : UH4 = UH4_1(v1039, v1042)
        dfa_states_have_representative_149(v1027, v1038, v1043)
    else
        false
let v1052 : bool =
    if v1045 then
        let v1046 : US0 = US0_0
        let v1047 : US0 = US0_1
        let v1048 : UH4 = UH4_0
        let v1049 : UH4 = UH4_1(v1047, v1048)
        let v1050 : UH4 = UH4_1(v1046, v1049)
        dfa_minimal_by_bisimulation_90(v1038, v1050)
    else
        false
let v1059 : bool =
    if v1052 then
        let v1053 : US0 = US0_0
        let v1054 : US0 = US0_1
        let v1055 : UH4 = UH4_0
        let v1056 : UH4 = UH4_1(v1054, v1055)
        let v1057 : UH4 = UH4_1(v1053, v1056)
        dfa_quotient_closed_150(v1038, v1057)
    else
        false
let v1060 : US1 = US1_0
let v1061 : UH3 = UH3_2(v1060)
let v1062 : UH3 = UH3_5(v1061)
let v1063 : UH3 = normalize_14(v1062)
let v1064 : UH3 = normalize_14(v1063)
let v1065 : UH8 = regex_position_count_123(v1064)
let v1066 : UH8 = UH8_1(v1065)
let v1067 : UH8 = state_budget_pow2_104(v1066)
let v1068 : UH3 = normalize_14(v1064)
let v1069 : US1 = US1_0
let v1070 : US1 = US1_1
let v1071 : US1 = US1_2
let v1072 : UH6 = UH6_0
let v1073 : UH6 = UH6_1(v1071, v1072)
let v1074 : UH6 = UH6_1(v1070, v1073)
let v1075 : UH6 = UH6_1(v1069, v1074)
let v1076 : UH10 = UH10_0
let v1077 : UH10 = UH10_1(v1068, v1076)
let v1078 : UH10 = UH10_0
let v1079 : UH10 = UH10_1(v1068, v1078)
let v1080 : US8 = dfa_closure_loop_bounded_124(v1075, v1067, v1077, v1079)
let v1084 : UH10 =
    match v1080 with
    | US8_1(v1082) -> (* DfaClosureBudgetExceeded *)
        v1082
    | US8_0(v1081) -> (* DfaClosureComplete *)
        v1081
let v1088 : bool =
    match v1080 with
    | US8_1(v1086) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v1085) -> (* DfaClosureComplete *)
        true
let v1089 : US1 = US1_0
let v1090 : US1 = US1_1
let v1091 : US1 = US1_2
let v1092 : UH6 = UH6_0
let v1093 : UH6 = UH6_1(v1091, v1092)
let v1094 : UH6 = UH6_1(v1090, v1093)
let v1095 : UH6 = UH6_1(v1089, v1094)
let v1096 : UH10 = UH10_0
let v1097 : UH10 = dfa_minimize_states_loop_153(v1084, v1095, v1096)
let v1106 : bool =
    if v1088 then
        let v1098 : US1 = US1_0
        let v1099 : US1 = US1_1
        let v1100 : US1 = US1_2
        let v1101 : UH6 = UH6_0
        let v1102 : UH6 = UH6_1(v1100, v1101)
        let v1103 : UH6 = UH6_1(v1099, v1102)
        let v1104 : UH6 = UH6_1(v1098, v1103)
        dfa_states_have_representative_155(v1084, v1097, v1104)
    else
        false
let v1115 : bool =
    if v1106 then
        let v1107 : US1 = US1_0
        let v1108 : US1 = US1_1
        let v1109 : US1 = US1_2
        let v1110 : UH6 = UH6_0
        let v1111 : UH6 = UH6_1(v1109, v1110)
        let v1112 : UH6 = UH6_1(v1108, v1111)
        let v1113 : UH6 = UH6_1(v1107, v1112)
        dfa_minimal_by_bisimulation_95(v1097, v1113)
    else
        false
let v1124 : bool =
    if v1115 then
        let v1116 : US1 = US1_0
        let v1117 : US1 = US1_1
        let v1118 : US1 = US1_2
        let v1119 : UH6 = UH6_0
        let v1120 : UH6 = UH6_1(v1118, v1119)
        let v1121 : UH6 = UH6_1(v1117, v1120)
        let v1122 : UH6 = UH6_1(v1116, v1121)
        dfa_quotient_closed_156(v1097, v1122)
    else
        false
let v1125 : US1 = US1_0
let v1126 : UH3 = UH3_2(v1125)
let v1127 : US1 = US1_1
let v1128 : UH3 = UH3_2(v1127)
let v1129 : UH3 = UH3_3(v1126, v1128)
let v1130 : UH3 = UH3_5(v1129)
let v1131 : US1 = US1_2
let v1132 : UH3 = UH3_2(v1131)
let v1133 : UH3 = UH3_4(v1130, v1132)
let v1134 : UH3 = normalize_14(v1133)
let v1135 : UH3 = normalize_14(v1134)
let v1136 : UH8 = regex_position_count_123(v1135)
let v1137 : UH8 = UH8_1(v1136)
let v1138 : UH8 = state_budget_pow2_104(v1137)
let v1139 : UH3 = normalize_14(v1135)
let v1140 : US1 = US1_0
let v1141 : US1 = US1_1
let v1142 : US1 = US1_2
let v1143 : UH6 = UH6_0
let v1144 : UH6 = UH6_1(v1142, v1143)
let v1145 : UH6 = UH6_1(v1141, v1144)
let v1146 : UH6 = UH6_1(v1140, v1145)
let v1147 : UH10 = UH10_0
let v1148 : UH10 = UH10_1(v1139, v1147)
let v1149 : UH10 = UH10_0
let v1150 : UH10 = UH10_1(v1139, v1149)
let v1151 : US8 = dfa_closure_loop_bounded_124(v1146, v1138, v1148, v1150)
let v1155 : UH10 =
    match v1151 with
    | US8_1(v1153) -> (* DfaClosureBudgetExceeded *)
        v1153
    | US8_0(v1152) -> (* DfaClosureComplete *)
        v1152
let v1159 : bool =
    match v1151 with
    | US8_1(v1157) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v1156) -> (* DfaClosureComplete *)
        true
let v1160 : US1 = US1_0
let v1161 : US1 = US1_1
let v1162 : US1 = US1_2
let v1163 : UH6 = UH6_0
let v1164 : UH6 = UH6_1(v1162, v1163)
let v1165 : UH6 = UH6_1(v1161, v1164)
let v1166 : UH6 = UH6_1(v1160, v1165)
let v1167 : UH10 = UH10_0
let v1168 : UH10 = dfa_minimize_states_loop_153(v1155, v1166, v1167)
let v1177 : bool =
    if v1159 then
        let v1169 : US1 = US1_0
        let v1170 : US1 = US1_1
        let v1171 : US1 = US1_2
        let v1172 : UH6 = UH6_0
        let v1173 : UH6 = UH6_1(v1171, v1172)
        let v1174 : UH6 = UH6_1(v1170, v1173)
        let v1175 : UH6 = UH6_1(v1169, v1174)
        dfa_states_have_representative_155(v1155, v1168, v1175)
    else
        false
let v1186 : bool =
    if v1177 then
        let v1178 : US1 = US1_0
        let v1179 : US1 = US1_1
        let v1180 : US1 = US1_2
        let v1181 : UH6 = UH6_0
        let v1182 : UH6 = UH6_1(v1180, v1181)
        let v1183 : UH6 = UH6_1(v1179, v1182)
        let v1184 : UH6 = UH6_1(v1178, v1183)
        dfa_minimal_by_bisimulation_95(v1168, v1184)
    else
        false
let v1195 : bool =
    if v1186 then
        let v1187 : US1 = US1_0
        let v1188 : US1 = US1_1
        let v1189 : US1 = US1_2
        let v1190 : UH6 = UH6_0
        let v1191 : UH6 = UH6_1(v1189, v1190)
        let v1192 : UH6 = UH6_1(v1188, v1191)
        let v1193 : UH6 = UH6_1(v1187, v1192)
        dfa_quotient_closed_156(v1168, v1193)
    else
        false
let v1196 : US1 = US1_0
let v1197 : UH3 = UH3_2(v1196)
let v1198 : US1 = US1_0
let v1199 : UH3 = UH3_2(v1198)
let v1200 : UH3 = UH3_5(v1199)
let v1201 : UH3 = UH3_4(v1197, v1200)
let v1202 : US1 = US1_1
let v1203 : UH3 = UH3_2(v1202)
let v1204 : US1 = US1_0
let v1205 : UH3 = UH3_2(v1204)
let v1206 : US1 = US1_0
let v1207 : UH3 = UH3_2(v1206)
let v1208 : UH3 = UH3_4(v1205, v1207)
let v1209 : UH3 = UH3_5(v1208)
let v1210 : US1 = US1_0
let v1211 : UH3 = UH3_2(v1210)
let v1212 : UH3 = UH3_4(v1211, v1209)
let v1213 : UH3 = UH3_3(v1209, v1212)
let v1214 : UH3 = UH3_4(v1203, v1213)
let v1215 : UH3 = UH3_3(v1201, v1214)
let v1216 : UH3 = normalize_14(v1215)
let v1217 : UH3 = normalize_14(v1216)
let v1218 : UH8 = regex_position_count_123(v1217)
let v1219 : UH8 = UH8_1(v1218)
let v1220 : UH8 = state_budget_pow2_104(v1219)
let v1221 : UH3 = normalize_14(v1217)
let v1222 : US1 = US1_0
let v1223 : US1 = US1_1
let v1224 : US1 = US1_2
let v1225 : UH6 = UH6_0
let v1226 : UH6 = UH6_1(v1224, v1225)
let v1227 : UH6 = UH6_1(v1223, v1226)
let v1228 : UH6 = UH6_1(v1222, v1227)
let v1229 : UH10 = UH10_0
let v1230 : UH10 = UH10_1(v1221, v1229)
let v1231 : UH10 = UH10_0
let v1232 : UH10 = UH10_1(v1221, v1231)
let v1233 : US8 = dfa_closure_loop_bounded_124(v1228, v1220, v1230, v1232)
let v1237 : UH10 =
    match v1233 with
    | US8_1(v1235) -> (* DfaClosureBudgetExceeded *)
        v1235
    | US8_0(v1234) -> (* DfaClosureComplete *)
        v1234
let v1241 : bool =
    match v1233 with
    | US8_1(v1239) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v1238) -> (* DfaClosureComplete *)
        true
let v1242 : US1 = US1_0
let v1243 : US1 = US1_1
let v1244 : US1 = US1_2
let v1245 : UH6 = UH6_0
let v1246 : UH6 = UH6_1(v1244, v1245)
let v1247 : UH6 = UH6_1(v1243, v1246)
let v1248 : UH6 = UH6_1(v1242, v1247)
let v1249 : UH10 = UH10_0
let v1250 : UH10 = dfa_minimize_states_loop_153(v1237, v1248, v1249)
let v1259 : bool =
    if v1241 then
        let v1251 : US1 = US1_0
        let v1252 : US1 = US1_1
        let v1253 : US1 = US1_2
        let v1254 : UH6 = UH6_0
        let v1255 : UH6 = UH6_1(v1253, v1254)
        let v1256 : UH6 = UH6_1(v1252, v1255)
        let v1257 : UH6 = UH6_1(v1251, v1256)
        dfa_states_have_representative_155(v1237, v1250, v1257)
    else
        false
let v1268 : bool =
    if v1259 then
        let v1260 : US1 = US1_0
        let v1261 : US1 = US1_1
        let v1262 : US1 = US1_2
        let v1263 : UH6 = UH6_0
        let v1264 : UH6 = UH6_1(v1262, v1263)
        let v1265 : UH6 = UH6_1(v1261, v1264)
        let v1266 : UH6 = UH6_1(v1260, v1265)
        dfa_minimal_by_bisimulation_95(v1250, v1266)
    else
        false
let v1277 : bool =
    if v1268 then
        let v1269 : US1 = US1_0
        let v1270 : US1 = US1_1
        let v1271 : US1 = US1_2
        let v1272 : UH6 = UH6_0
        let v1273 : UH6 = UH6_1(v1271, v1272)
        let v1274 : UH6 = UH6_1(v1270, v1273)
        let v1275 : UH6 = UH6_1(v1269, v1274)
        dfa_quotient_closed_156(v1250, v1275)
    else
        false
let v1279 : bool =
    if v1045 then
        let v1278 : bool = v1052 && v1059
        v1278
    else
        false
if v1279 then
    ()
else
    failwith<unit> "bit minimized DFA should be certified"
let v1281 : bool =
    if v1106 then
        let v1280 : bool = v1115 && v1124
        v1280
    else
        false
if v1281 then
    ()
else
    failwith<unit> "ternary star minimized DFA should be certified"
let v1283 : bool =
    if v1177 then
        let v1282 : bool = v1186 && v1195
        v1282
    else
        false
if v1283 then
    ()
else
    failwith<unit> "ternary suffix minimized DFA should be certified"
let v1285 : bool =
    if v1259 then
        let v1284 : bool = v1268 && v1277
        v1284
    else
        false
if v1285 then
    ()
else
    failwith<unit> "cyclic quotient should be certified"
if v820 then
    ()
else
    failwith<unit> "bit DFA closure should be closed"
if v890 then
    ()
else
    failwith<unit> "ternary star DFA closure should be closed"
if v970 then
    ()
else
    failwith<unit> "ternary suffix DFA closure should be closed"
if v821 then
    ()
else
    failwith<unit> "bit DFA states should be distinct"
if v891 then
    ()
else
    failwith<unit> "ternary star DFA states should be distinct"
if v971 then
    ()
else
    failwith<unit> "ternary suffix DFA states should be distinct"
if v828 then
    ()
else
    failwith<unit> "bit DFA derivative formulas should be structurally consistent"
if v900 then
    ()
else
    failwith<unit> "ternary star DFA derivative formulas should be structurally consistent"
if v980 then
    ()
else
    failwith<unit> "ternary suffix DFA derivative formulas should be structurally consistent"
if v835 then
    ()
else
    failwith<unit> "bit DFA table should be total"
if v909 then
    ()
else
    failwith<unit> "ternary star DFA table should be total"
if v989 then
    ()
else
    failwith<unit> "ternary suffix DFA table should be total"
if v836 then
    ()
else
    failwith<unit> "bit DFA table keys should be unique"
if v910 then
    ()
else
    failwith<unit> "ternary star DFA table keys should be unique"
if v990 then
    ()
else
    failwith<unit> "ternary suffix DFA table keys should be unique"
if v841 then
    ()
else
    failwith<unit> "bit DFA should satisfy its structural position-subset bound"
if v915 then
    ()
else
    failwith<unit> "ternary star DFA should satisfy its structural position-subset bound"
if v995 then
    ()
else
    failwith<unit> "ternary suffix DFA should satisfy its structural position-subset bound"
if v842 then
    ()
else
    failwith<unit> "bit DFA states should be normalized"
if v916 then
    ()
else
    failwith<unit> "ternary star DFA states should be normalized"
if v996 then
    ()
else
    failwith<unit> "ternary suffix DFA states should be normalized"
if v843 then
    ()
else
    failwith<unit> "bit DFA normalization should preserve nullable"
if v917 then
    ()
else
    failwith<unit> "ternary star DFA normalization should preserve nullable"
if v997 then
    ()
else
    failwith<unit> "ternary suffix DFA normalization should preserve nullable"
if v844 then
    ()
else
    failwith<unit> "bit DFA ordering should be coherent"
if v918 then
    ()
else
    failwith<unit> "ternary star DFA ordering should be coherent"
if v998 then
    ()
else
    failwith<unit> "ternary suffix DFA ordering should be coherent"
let v1293 : bool =
    if v820 then
        if v821 then
            if v828 then
                if v835 then
                    if v836 then
                        if v841 then
                            if v842 then
                                let v1286 : bool = v843 && v844
                                v1286
                            else
                                false
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        else
            false
    else
        false
if v1293 then
    ()
else
    failwith<unit> "bit DFA surface should be certified"
let v1301 : bool =
    if v890 then
        if v891 then
            if v900 then
                if v909 then
                    if v910 then
                        if v915 then
                            if v916 then
                                let v1294 : bool = v917 && v918
                                v1294
                            else
                                false
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        else
            false
    else
        false
if v1301 then
    ()
else
    failwith<unit> "ternary star DFA surface should be certified"
let v1309 : bool =
    if v970 then
        if v971 then
            if v980 then
                if v989 then
                    if v990 then
                        if v995 then
                            if v996 then
                                let v1302 : bool = v997 && v998
                                v1302
                            else
                                false
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        else
            false
    else
        false
if v1309 then
    ()
else
    failwith<unit> "ternary suffix DFA surface should be certified"
let v1310 : US1 = US1_0
let v1311 : UH3 = UH3_2(v1310)
let v1312 : US1 = US1_1
let v1313 : UH3 = UH3_2(v1312)
let v1314 : US1 = US1_2
let v1315 : UH3 = UH3_2(v1314)
let v1316 : UH3 = UH3_4(v1313, v1315)
let v1317 : UH3 = UH3_4(v1311, v1316)
let v1318 : UH3 = normalize_14(v1317)
let v1319 : US1 = US1_0
let v1320 : US1 = US1_1
let v1321 : US1 = US1_2
let v1322 : UH6 = UH6_0
let v1323 : UH6 = UH6_1(v1321, v1322)
let v1324 : UH6 = UH6_1(v1320, v1323)
let v1325 : UH6 = UH6_1(v1319, v1324)
let v1326 : UH10 = UH10_0
let v1327 : UH10 = UH10_1(v1318, v1326)
let v1328 : UH10 = UH10_0
let v1329 : UH10 = UH10_1(v1318, v1328)
let v1330 : UH10 = dfa_closure_loop_84(v1325, v1327, v1329)
let v1331 : UH8 = UH8_0
let v1332 : UH8 = UH8_1(v1331)
let v1333 : UH8 = UH8_1(v1332)
let v1334 : UH8 = UH8_1(v1333)
let v1335 : UH8 = UH8_1(v1334)
let v1336 : bool = regex_list_within_budget_141(v1330, v1335)
let v1337 : bool = v1336 = false
if v1337 then
    ()
else
    failwith<unit> "three-symbol sequence should exceed the four-state budget"
let v1338 : UH8 = UH8_0
let v1339 : UH8 = UH8_1(v1338)
let v1340 : UH8 = UH8_1(v1339)
let v1341 : UH8 = UH8_1(v1340)
let v1342 : UH8 = UH8_1(v1341)
let v1343 : UH8 = UH8_1(v1342)
let v1344 : UH8 = UH8_1(v1343)
let v1345 : UH8 = UH8_1(v1344)
let v1346 : UH8 = UH8_1(v1345)
let v1347 : bool = regex_list_within_budget_141(v1330, v1346)
if v1347 then
    ()
else
    failwith<unit> "three-symbol sequence should fit the eight-state budget"
let v1348 : US0 = US0_0
let v1349 : UH2 = UH2_2(v1348)
let v1350 : US0 = US0_1
let v1351 : UH2 = UH2_2(v1350)
let v1352 : UH2 = UH2_3(v1349, v1351)
let v1353 : UH2 = UH2_5(v1352)
let v1354 : US0 = US0_0
let v1355 : UH2 = UH2_2(v1354)
let v1356 : UH2 = UH2_4(v1353, v1355)
let v1357 : UH2 = normalize_4(v1356)
let v1358 : UH2 = normalize_4(v1357)
let v1359 : UH8 = regex_position_count_102(v1358)
let v1360 : UH8 = UH8_1(v1359)
let v1361 : UH8 = state_budget_pow2_104(v1360)
let v1362 : UH2 = normalize_4(v1358)
let v1363 : US0 = US0_0
let v1364 : US0 = US0_1
let v1365 : UH4 = UH4_0
let v1366 : UH4 = UH4_1(v1364, v1365)
let v1367 : UH4 = UH4_1(v1363, v1366)
let v1368 : UH9 = UH9_0
let v1369 : UH9 = UH9_1(v1362, v1368)
let v1370 : UH9 = UH9_0
let v1371 : UH9 = UH9_1(v1362, v1370)
let v1372 : US4 = dfa_closure_loop_bounded_54(v1367, v1361, v1369, v1371)
let v1380 : bool =
    match v1372 with
    | US4_1(v1378) -> (* DfaClosureBudgetExceeded *)
        false
    | US4_0(v1373) -> (* DfaClosureComplete *)
        let v1374 : UH8 = regex_position_count_102(v1357)
        let v1375 : UH8 = UH8_1(v1374)
        let v1376 : UH8 = state_budget_pow2_104(v1375)
        regex_list_within_budget_118(v1373, v1376)
if v1380 then
    ()
else
    failwith<unit> "bit canonical closure should stay within its structural position-subset bound"
let v1381 : US1 = US1_0
let v1382 : UH3 = UH3_2(v1381)
let v1383 : US1 = US1_1
let v1384 : UH3 = UH3_2(v1383)
let v1385 : UH3 = UH3_3(v1382, v1384)
let v1386 : UH3 = UH3_5(v1385)
let v1387 : US1 = US1_2
let v1388 : UH3 = UH3_2(v1387)
let v1389 : UH3 = UH3_4(v1386, v1388)
let v1390 : UH3 = normalize_14(v1389)
let v1391 : UH3 = normalize_14(v1390)
let v1392 : UH8 = regex_position_count_123(v1391)
let v1393 : UH8 = UH8_1(v1392)
let v1394 : UH8 = state_budget_pow2_104(v1393)
let v1395 : UH3 = normalize_14(v1391)
let v1396 : US1 = US1_0
let v1397 : US1 = US1_1
let v1398 : US1 = US1_2
let v1399 : UH6 = UH6_0
let v1400 : UH6 = UH6_1(v1398, v1399)
let v1401 : UH6 = UH6_1(v1397, v1400)
let v1402 : UH6 = UH6_1(v1396, v1401)
let v1403 : UH10 = UH10_0
let v1404 : UH10 = UH10_1(v1395, v1403)
let v1405 : UH10 = UH10_0
let v1406 : UH10 = UH10_1(v1395, v1405)
let v1407 : US8 = dfa_closure_loop_bounded_124(v1402, v1394, v1404, v1406)
let v1415 : bool =
    match v1407 with
    | US8_1(v1413) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v1408) -> (* DfaClosureComplete *)
        let v1409 : UH8 = regex_position_count_123(v1390)
        let v1410 : UH8 = UH8_1(v1409)
        let v1411 : UH8 = state_budget_pow2_104(v1410)
        regex_list_within_budget_141(v1408, v1411)
if v1415 then
    ()
else
    failwith<unit> "ternary suffix closure should stay within its structural position-subset bound"
let v1416 : US0 = US0_0
let v1417 : UH2 = UH2_2(v1416)
let v1418 : US0 = US0_1
let v1419 : UH2 = UH2_2(v1418)
let v1420 : UH2 = UH2_3(v1417, v1419)
let v1421 : UH2 = UH2_5(v1420)
let v1422 : US0 = US0_0
let v1423 : UH2 = UH2_2(v1422)
let v1424 : UH2 = UH2_4(v1421, v1423)
let v1425 : UH2 = normalize_4(v1424)
let v1426 : UH2 = normalize_4(v1425)
let v1427 : UH8 = regex_position_count_102(v1426)
let v1428 : UH8 = UH8_1(v1427)
let v1429 : UH8 = state_budget_pow2_104(v1428)
let v1430 : UH2 = normalize_4(v1426)
let v1431 : US0 = US0_0
let v1432 : US0 = US0_1
let v1433 : UH4 = UH4_0
let v1434 : UH4 = UH4_1(v1432, v1433)
let v1435 : UH4 = UH4_1(v1431, v1434)
let v1436 : UH9 = UH9_0
let v1437 : UH9 = UH9_1(v1430, v1436)
let v1438 : UH9 = UH9_0
let v1439 : UH9 = UH9_1(v1430, v1438)
let v1440 : US4 = dfa_closure_loop_bounded_54(v1435, v1429, v1437, v1439)
let v1455 : bool =
    match v1440 with
    | US4_1(v1453) -> (* DfaClosureBudgetExceeded *)
        false
    | US4_0(v1441) -> (* DfaClosureComplete *)
        let v1442 : US0 = US0_0
        let v1443 : US0 = US0_1
        let v1444 : UH4 = UH4_0
        let v1445 : UH4 = UH4_1(v1443, v1444)
        let v1446 : UH4 = UH4_1(v1442, v1445)
        let v1447 : UH9 = UH9_0
        let v1448 : UH9 = dfa_minimize_states_loop_147(v1441, v1446, v1447)
        let v1449 : UH8 = regex_position_count_102(v1425)
        let v1450 : UH8 = UH8_1(v1449)
        let v1451 : UH8 = state_budget_pow2_104(v1450)
        regex_list_within_budget_118(v1448, v1451)
if v1455 then
    ()
else
    failwith<unit> "bit minimized DFA should stay within its structural position-subset bound"
let v1456 : US1 = US1_0
let v1457 : UH3 = UH3_2(v1456)
let v1458 : US1 = US1_0
let v1459 : UH3 = UH3_2(v1458)
let v1460 : UH3 = UH3_5(v1459)
let v1461 : UH3 = UH3_4(v1457, v1460)
let v1462 : US1 = US1_1
let v1463 : UH3 = UH3_2(v1462)
let v1464 : US1 = US1_0
let v1465 : UH3 = UH3_2(v1464)
let v1466 : US1 = US1_0
let v1467 : UH3 = UH3_2(v1466)
let v1468 : UH3 = UH3_4(v1465, v1467)
let v1469 : UH3 = UH3_5(v1468)
let v1470 : US1 = US1_0
let v1471 : UH3 = UH3_2(v1470)
let v1472 : UH3 = UH3_4(v1471, v1469)
let v1473 : UH3 = UH3_3(v1469, v1472)
let v1474 : UH3 = UH3_4(v1463, v1473)
let v1475 : UH3 = UH3_3(v1461, v1474)
let v1476 : UH3 = normalize_14(v1475)
let v1477 : UH3 = normalize_14(v1476)
let v1478 : UH8 = regex_position_count_123(v1477)
let v1479 : UH8 = UH8_1(v1478)
let v1480 : UH8 = state_budget_pow2_104(v1479)
let v1481 : UH3 = normalize_14(v1477)
let v1482 : US1 = US1_0
let v1483 : US1 = US1_1
let v1484 : US1 = US1_2
let v1485 : UH6 = UH6_0
let v1486 : UH6 = UH6_1(v1484, v1485)
let v1487 : UH6 = UH6_1(v1483, v1486)
let v1488 : UH6 = UH6_1(v1482, v1487)
let v1489 : UH10 = UH10_0
let v1490 : UH10 = UH10_1(v1481, v1489)
let v1491 : UH10 = UH10_0
let v1492 : UH10 = UH10_1(v1481, v1491)
let v1493 : US8 = dfa_closure_loop_bounded_124(v1488, v1480, v1490, v1492)
let v1510 : bool =
    match v1493 with
    | US8_1(v1508) -> (* DfaClosureBudgetExceeded *)
        false
    | US8_0(v1494) -> (* DfaClosureComplete *)
        let v1495 : US1 = US1_0
        let v1496 : US1 = US1_1
        let v1497 : US1 = US1_2
        let v1498 : UH6 = UH6_0
        let v1499 : UH6 = UH6_1(v1497, v1498)
        let v1500 : UH6 = UH6_1(v1496, v1499)
        let v1501 : UH6 = UH6_1(v1495, v1500)
        let v1502 : UH10 = UH10_0
        let v1503 : UH10 = dfa_minimize_states_loop_153(v1494, v1501, v1502)
        let v1504 : UH8 = regex_position_count_123(v1476)
        let v1505 : UH8 = UH8_1(v1504)
        let v1506 : UH8 = state_budget_pow2_104(v1505)
        regex_list_within_budget_141(v1503, v1506)
if v1510 then
    ()
else
    failwith<unit> "cyclic minimized DFA should stay within its structural position-subset bound"
let v1511 : US0 = US0_1
let v1512 : US0 = US0_1
let v1513 : US0 = US0_0
let v1514 : UH0 = UH0_0
let v1515 : UH0 = UH0_1(v1513, v1514)
let v1516 : UH0 = UH0_1(v1512, v1515)
let v1517 : UH0 = UH0_1(v1511, v1516)
let v1518 : US0 = US0_0
let v1519 : US0 = US0_1
let v1520 : UH4 = UH4_0
let v1521 : UH4 = UH4_1(v1519, v1520)
let v1522 : UH4 = UH4_1(v1518, v1521)
let v1523 : bool = input_symbols_covered_52(v1517, v1522)
let v1563 : US12 =
    if v1523 then
        let v1524 : US0 = US0_0
        let v1525 : UH2 = UH2_2(v1524)
        let v1526 : US0 = US0_1
        let v1527 : UH2 = UH2_2(v1526)
        let v1528 : UH2 = UH2_3(v1525, v1527)
        let v1529 : UH2 = UH2_5(v1528)
        let v1530 : US0 = US0_0
        let v1531 : UH2 = UH2_2(v1530)
        let v1532 : UH2 = UH2_4(v1529, v1531)
        let v1533 : UH2 = normalize_4(v1532)
        let v1534 : UH2 = normalize_4(v1533)
        let v1535 : UH8 = regex_position_count_102(v1534)
        let v1536 : UH8 = UH8_1(v1535)
        let v1537 : UH8 = state_budget_pow2_104(v1536)
        let v1538 : UH2 = normalize_4(v1534)
        let v1539 : US0 = US0_0
        let v1540 : US0 = US0_1
        let v1541 : UH4 = UH4_0
        let v1542 : UH4 = UH4_1(v1540, v1541)
        let v1543 : UH4 = UH4_1(v1539, v1542)
        let v1544 : UH9 = UH9_0
        let v1545 : UH9 = UH9_1(v1538, v1544)
        let v1546 : UH9 = UH9_0
        let v1547 : UH9 = UH9_1(v1538, v1546)
        let v1548 : US4 = dfa_closure_loop_bounded_54(v1543, v1537, v1545, v1547)
        match v1548 with
        | US4_1(v1558) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US4_0(v1549) -> (* DfaClosureComplete *)
            let v1550 : US0 = US0_1
            let v1551 : US0 = US0_1
            let v1552 : US0 = US0_0
            let v1553 : UH0 = UH0_0
            let v1554 : UH0 = UH0_1(v1552, v1553)
            let v1555 : UH0 = UH0_1(v1551, v1554)
            let v1556 : UH0 = UH0_1(v1550, v1555)
            dfa_run_in_closure_159(v1533, v1549, v1556)
    else
        US12_2
let v1564 : US0 = US0_0
let v1565 : UH2 = UH2_2(v1564)
let v1566 : US0 = US0_1
let v1567 : UH2 = UH2_2(v1566)
let v1568 : UH2 = UH2_3(v1565, v1567)
let v1569 : UH2 = UH2_5(v1568)
let v1570 : US0 = US0_0
let v1571 : UH2 = UH2_2(v1570)
let v1572 : UH2 = UH2_4(v1569, v1571)
let v1573 : US0 = US0_1
let v1574 : US0 = US0_1
let v1575 : US0 = US0_0
let v1576 : UH0 = UH0_0
let v1577 : UH0 = UH0_1(v1575, v1576)
let v1578 : UH0 = UH0_1(v1574, v1577)
let v1579 : UH0 = UH0_1(v1573, v1578)
let v1580 : bool = accepts_2(v1572, v1579)
let v1583 : bool =
    match v1563 with
    | US12_0 -> (* DfaAccepted *)
        v1580
    | US12_1 -> (* DfaRejected *)
        let v1581 : bool = false = v1580
        v1581
    | _ ->
        false
if v1583 then
    ()
else
    failwith<unit> "bit DFA runner should preserve acceptance"
let v1584 : US0 = US0_1
let v1585 : US0 = US0_1
let v1586 : US0 = US0_1
let v1587 : UH0 = UH0_0
let v1588 : UH0 = UH0_1(v1586, v1587)
let v1589 : UH0 = UH0_1(v1585, v1588)
let v1590 : UH0 = UH0_1(v1584, v1589)
let v1591 : US0 = US0_0
let v1592 : US0 = US0_1
let v1593 : UH4 = UH4_0
let v1594 : UH4 = UH4_1(v1592, v1593)
let v1595 : UH4 = UH4_1(v1591, v1594)
let v1596 : bool = input_symbols_covered_52(v1590, v1595)
let v1636 : US12 =
    if v1596 then
        let v1597 : US0 = US0_0
        let v1598 : UH2 = UH2_2(v1597)
        let v1599 : US0 = US0_1
        let v1600 : UH2 = UH2_2(v1599)
        let v1601 : UH2 = UH2_3(v1598, v1600)
        let v1602 : UH2 = UH2_5(v1601)
        let v1603 : US0 = US0_0
        let v1604 : UH2 = UH2_2(v1603)
        let v1605 : UH2 = UH2_4(v1602, v1604)
        let v1606 : UH2 = normalize_4(v1605)
        let v1607 : UH2 = normalize_4(v1606)
        let v1608 : UH8 = regex_position_count_102(v1607)
        let v1609 : UH8 = UH8_1(v1608)
        let v1610 : UH8 = state_budget_pow2_104(v1609)
        let v1611 : UH2 = normalize_4(v1607)
        let v1612 : US0 = US0_0
        let v1613 : US0 = US0_1
        let v1614 : UH4 = UH4_0
        let v1615 : UH4 = UH4_1(v1613, v1614)
        let v1616 : UH4 = UH4_1(v1612, v1615)
        let v1617 : UH9 = UH9_0
        let v1618 : UH9 = UH9_1(v1611, v1617)
        let v1619 : UH9 = UH9_0
        let v1620 : UH9 = UH9_1(v1611, v1619)
        let v1621 : US4 = dfa_closure_loop_bounded_54(v1616, v1610, v1618, v1620)
        match v1621 with
        | US4_1(v1631) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US4_0(v1622) -> (* DfaClosureComplete *)
            let v1623 : US0 = US0_1
            let v1624 : US0 = US0_1
            let v1625 : US0 = US0_1
            let v1626 : UH0 = UH0_0
            let v1627 : UH0 = UH0_1(v1625, v1626)
            let v1628 : UH0 = UH0_1(v1624, v1627)
            let v1629 : UH0 = UH0_1(v1623, v1628)
            dfa_run_in_closure_159(v1606, v1622, v1629)
    else
        US12_2
let v1637 : US0 = US0_0
let v1638 : UH2 = UH2_2(v1637)
let v1639 : US0 = US0_1
let v1640 : UH2 = UH2_2(v1639)
let v1641 : UH2 = UH2_3(v1638, v1640)
let v1642 : UH2 = UH2_5(v1641)
let v1643 : US0 = US0_0
let v1644 : UH2 = UH2_2(v1643)
let v1645 : UH2 = UH2_4(v1642, v1644)
let v1646 : US0 = US0_1
let v1647 : US0 = US0_1
let v1648 : US0 = US0_1
let v1649 : UH0 = UH0_0
let v1650 : UH0 = UH0_1(v1648, v1649)
let v1651 : UH0 = UH0_1(v1647, v1650)
let v1652 : UH0 = UH0_1(v1646, v1651)
let v1653 : bool = accepts_2(v1645, v1652)
let v1656 : bool =
    match v1636 with
    | US12_0 -> (* DfaAccepted *)
        v1653
    | US12_1 -> (* DfaRejected *)
        let v1654 : bool = false = v1653
        v1654
    | _ ->
        false
if v1656 then
    ()
else
    failwith<unit> "bit DFA runner should preserve rejection"
let v1657 : US1 = US1_0
let v1658 : US1 = US1_0
let v1659 : US1 = US1_0
let v1660 : UH1 = UH1_0
let v1661 : UH1 = UH1_1(v1659, v1660)
let v1662 : UH1 = UH1_1(v1658, v1661)
let v1663 : UH1 = UH1_1(v1657, v1662)
let v1664 : US1 = US1_0
let v1665 : US1 = US1_1
let v1666 : US1 = US1_2
let v1667 : UH6 = UH6_0
let v1668 : UH6 = UH6_1(v1666, v1667)
let v1669 : UH6 = UH6_1(v1665, v1668)
let v1670 : UH6 = UH6_1(v1664, v1669)
let v1671 : bool = input_symbols_covered_160(v1663, v1670)
let v1707 : US12 =
    if v1671 then
        let v1672 : US1 = US1_0
        let v1673 : UH3 = UH3_2(v1672)
        let v1674 : UH3 = UH3_5(v1673)
        let v1675 : UH3 = normalize_14(v1674)
        let v1676 : UH3 = normalize_14(v1675)
        let v1677 : UH8 = regex_position_count_123(v1676)
        let v1678 : UH8 = UH8_1(v1677)
        let v1679 : UH8 = state_budget_pow2_104(v1678)
        let v1680 : UH3 = normalize_14(v1676)
        let v1681 : US1 = US1_0
        let v1682 : US1 = US1_1
        let v1683 : US1 = US1_2
        let v1684 : UH6 = UH6_0
        let v1685 : UH6 = UH6_1(v1683, v1684)
        let v1686 : UH6 = UH6_1(v1682, v1685)
        let v1687 : UH6 = UH6_1(v1681, v1686)
        let v1688 : UH10 = UH10_0
        let v1689 : UH10 = UH10_1(v1680, v1688)
        let v1690 : UH10 = UH10_0
        let v1691 : UH10 = UH10_1(v1680, v1690)
        let v1692 : US8 = dfa_closure_loop_bounded_124(v1687, v1679, v1689, v1691)
        match v1692 with
        | US8_1(v1702) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v1693) -> (* DfaClosureComplete *)
            let v1694 : US1 = US1_0
            let v1695 : US1 = US1_0
            let v1696 : US1 = US1_0
            let v1697 : UH1 = UH1_0
            let v1698 : UH1 = UH1_1(v1696, v1697)
            let v1699 : UH1 = UH1_1(v1695, v1698)
            let v1700 : UH1 = UH1_1(v1694, v1699)
            dfa_run_in_closure_162(v1675, v1693, v1700)
    else
        US12_2
let v1708 : US1 = US1_0
let v1709 : UH3 = UH3_2(v1708)
let v1710 : UH3 = UH3_5(v1709)
let v1711 : US1 = US1_0
let v1712 : US1 = US1_0
let v1713 : US1 = US1_0
let v1714 : UH1 = UH1_0
let v1715 : UH1 = UH1_1(v1713, v1714)
let v1716 : UH1 = UH1_1(v1712, v1715)
let v1717 : UH1 = UH1_1(v1711, v1716)
let v1718 : bool = accepts_12(v1710, v1717)
let v1721 : bool =
    match v1707 with
    | US12_0 -> (* DfaAccepted *)
        v1718
    | US12_1 -> (* DfaRejected *)
        let v1719 : bool = false = v1718
        v1719
    | _ ->
        false
if v1721 then
    ()
else
    failwith<unit> "ternary star DFA runner should preserve acceptance"
let v1722 : US1 = US1_0
let v1723 : US1 = US1_0
let v1724 : US1 = US1_1
let v1725 : UH1 = UH1_0
let v1726 : UH1 = UH1_1(v1724, v1725)
let v1727 : UH1 = UH1_1(v1723, v1726)
let v1728 : UH1 = UH1_1(v1722, v1727)
let v1729 : US1 = US1_0
let v1730 : US1 = US1_1
let v1731 : US1 = US1_2
let v1732 : UH6 = UH6_0
let v1733 : UH6 = UH6_1(v1731, v1732)
let v1734 : UH6 = UH6_1(v1730, v1733)
let v1735 : UH6 = UH6_1(v1729, v1734)
let v1736 : bool = input_symbols_covered_160(v1728, v1735)
let v1772 : US12 =
    if v1736 then
        let v1737 : US1 = US1_0
        let v1738 : UH3 = UH3_2(v1737)
        let v1739 : UH3 = UH3_5(v1738)
        let v1740 : UH3 = normalize_14(v1739)
        let v1741 : UH3 = normalize_14(v1740)
        let v1742 : UH8 = regex_position_count_123(v1741)
        let v1743 : UH8 = UH8_1(v1742)
        let v1744 : UH8 = state_budget_pow2_104(v1743)
        let v1745 : UH3 = normalize_14(v1741)
        let v1746 : US1 = US1_0
        let v1747 : US1 = US1_1
        let v1748 : US1 = US1_2
        let v1749 : UH6 = UH6_0
        let v1750 : UH6 = UH6_1(v1748, v1749)
        let v1751 : UH6 = UH6_1(v1747, v1750)
        let v1752 : UH6 = UH6_1(v1746, v1751)
        let v1753 : UH10 = UH10_0
        let v1754 : UH10 = UH10_1(v1745, v1753)
        let v1755 : UH10 = UH10_0
        let v1756 : UH10 = UH10_1(v1745, v1755)
        let v1757 : US8 = dfa_closure_loop_bounded_124(v1752, v1744, v1754, v1756)
        match v1757 with
        | US8_1(v1767) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v1758) -> (* DfaClosureComplete *)
            let v1759 : US1 = US1_0
            let v1760 : US1 = US1_0
            let v1761 : US1 = US1_1
            let v1762 : UH1 = UH1_0
            let v1763 : UH1 = UH1_1(v1761, v1762)
            let v1764 : UH1 = UH1_1(v1760, v1763)
            let v1765 : UH1 = UH1_1(v1759, v1764)
            dfa_run_in_closure_162(v1740, v1758, v1765)
    else
        US12_2
let v1773 : US1 = US1_0
let v1774 : UH3 = UH3_2(v1773)
let v1775 : UH3 = UH3_5(v1774)
let v1776 : US1 = US1_0
let v1777 : US1 = US1_0
let v1778 : US1 = US1_1
let v1779 : UH1 = UH1_0
let v1780 : UH1 = UH1_1(v1778, v1779)
let v1781 : UH1 = UH1_1(v1777, v1780)
let v1782 : UH1 = UH1_1(v1776, v1781)
let v1783 : bool = accepts_12(v1775, v1782)
let v1786 : bool =
    match v1772 with
    | US12_0 -> (* DfaAccepted *)
        v1783
    | US12_1 -> (* DfaRejected *)
        let v1784 : bool = false = v1783
        v1784
    | _ ->
        false
if v1786 then
    ()
else
    failwith<unit> "ternary star DFA runner should preserve rejection"
let v1787 : US1 = US1_0
let v1788 : US1 = US1_1
let v1789 : US1 = US1_0
let v1790 : US1 = US1_2
let v1791 : UH1 = UH1_0
let v1792 : UH1 = UH1_1(v1790, v1791)
let v1793 : UH1 = UH1_1(v1789, v1792)
let v1794 : UH1 = UH1_1(v1788, v1793)
let v1795 : UH1 = UH1_1(v1787, v1794)
let v1796 : US1 = US1_0
let v1797 : US1 = US1_1
let v1798 : US1 = US1_2
let v1799 : UH6 = UH6_0
let v1800 : UH6 = UH6_1(v1798, v1799)
let v1801 : UH6 = UH6_1(v1797, v1800)
let v1802 : UH6 = UH6_1(v1796, v1801)
let v1803 : bool = input_symbols_covered_160(v1795, v1802)
let v1847 : US12 =
    if v1803 then
        let v1804 : US1 = US1_0
        let v1805 : UH3 = UH3_2(v1804)
        let v1806 : US1 = US1_1
        let v1807 : UH3 = UH3_2(v1806)
        let v1808 : UH3 = UH3_3(v1805, v1807)
        let v1809 : UH3 = UH3_5(v1808)
        let v1810 : US1 = US1_2
        let v1811 : UH3 = UH3_2(v1810)
        let v1812 : UH3 = UH3_4(v1809, v1811)
        let v1813 : UH3 = normalize_14(v1812)
        let v1814 : UH3 = normalize_14(v1813)
        let v1815 : UH8 = regex_position_count_123(v1814)
        let v1816 : UH8 = UH8_1(v1815)
        let v1817 : UH8 = state_budget_pow2_104(v1816)
        let v1818 : UH3 = normalize_14(v1814)
        let v1819 : US1 = US1_0
        let v1820 : US1 = US1_1
        let v1821 : US1 = US1_2
        let v1822 : UH6 = UH6_0
        let v1823 : UH6 = UH6_1(v1821, v1822)
        let v1824 : UH6 = UH6_1(v1820, v1823)
        let v1825 : UH6 = UH6_1(v1819, v1824)
        let v1826 : UH10 = UH10_0
        let v1827 : UH10 = UH10_1(v1818, v1826)
        let v1828 : UH10 = UH10_0
        let v1829 : UH10 = UH10_1(v1818, v1828)
        let v1830 : US8 = dfa_closure_loop_bounded_124(v1825, v1817, v1827, v1829)
        match v1830 with
        | US8_1(v1842) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v1831) -> (* DfaClosureComplete *)
            let v1832 : US1 = US1_0
            let v1833 : US1 = US1_1
            let v1834 : US1 = US1_0
            let v1835 : US1 = US1_2
            let v1836 : UH1 = UH1_0
            let v1837 : UH1 = UH1_1(v1835, v1836)
            let v1838 : UH1 = UH1_1(v1834, v1837)
            let v1839 : UH1 = UH1_1(v1833, v1838)
            let v1840 : UH1 = UH1_1(v1832, v1839)
            dfa_run_in_closure_162(v1813, v1831, v1840)
    else
        US12_2
let v1848 : US1 = US1_0
let v1849 : UH3 = UH3_2(v1848)
let v1850 : US1 = US1_1
let v1851 : UH3 = UH3_2(v1850)
let v1852 : UH3 = UH3_3(v1849, v1851)
let v1853 : UH3 = UH3_5(v1852)
let v1854 : US1 = US1_2
let v1855 : UH3 = UH3_2(v1854)
let v1856 : UH3 = UH3_4(v1853, v1855)
let v1857 : US1 = US1_0
let v1858 : US1 = US1_1
let v1859 : US1 = US1_0
let v1860 : US1 = US1_2
let v1861 : UH1 = UH1_0
let v1862 : UH1 = UH1_1(v1860, v1861)
let v1863 : UH1 = UH1_1(v1859, v1862)
let v1864 : UH1 = UH1_1(v1858, v1863)
let v1865 : UH1 = UH1_1(v1857, v1864)
let v1866 : bool = accepts_12(v1856, v1865)
let v1869 : bool =
    match v1847 with
    | US12_0 -> (* DfaAccepted *)
        v1866
    | US12_1 -> (* DfaRejected *)
        let v1867 : bool = false = v1866
        v1867
    | _ ->
        false
if v1869 then
    ()
else
    failwith<unit> "ternary suffix DFA runner should preserve acceptance"
let v1870 : US1 = US1_0
let v1871 : US1 = US1_1
let v1872 : US1 = US1_0
let v1873 : US1 = US1_1
let v1874 : UH1 = UH1_0
let v1875 : UH1 = UH1_1(v1873, v1874)
let v1876 : UH1 = UH1_1(v1872, v1875)
let v1877 : UH1 = UH1_1(v1871, v1876)
let v1878 : UH1 = UH1_1(v1870, v1877)
let v1879 : US1 = US1_0
let v1880 : US1 = US1_1
let v1881 : US1 = US1_2
let v1882 : UH6 = UH6_0
let v1883 : UH6 = UH6_1(v1881, v1882)
let v1884 : UH6 = UH6_1(v1880, v1883)
let v1885 : UH6 = UH6_1(v1879, v1884)
let v1886 : bool = input_symbols_covered_160(v1878, v1885)
let v1930 : US12 =
    if v1886 then
        let v1887 : US1 = US1_0
        let v1888 : UH3 = UH3_2(v1887)
        let v1889 : US1 = US1_1
        let v1890 : UH3 = UH3_2(v1889)
        let v1891 : UH3 = UH3_3(v1888, v1890)
        let v1892 : UH3 = UH3_5(v1891)
        let v1893 : US1 = US1_2
        let v1894 : UH3 = UH3_2(v1893)
        let v1895 : UH3 = UH3_4(v1892, v1894)
        let v1896 : UH3 = normalize_14(v1895)
        let v1897 : UH3 = normalize_14(v1896)
        let v1898 : UH8 = regex_position_count_123(v1897)
        let v1899 : UH8 = UH8_1(v1898)
        let v1900 : UH8 = state_budget_pow2_104(v1899)
        let v1901 : UH3 = normalize_14(v1897)
        let v1902 : US1 = US1_0
        let v1903 : US1 = US1_1
        let v1904 : US1 = US1_2
        let v1905 : UH6 = UH6_0
        let v1906 : UH6 = UH6_1(v1904, v1905)
        let v1907 : UH6 = UH6_1(v1903, v1906)
        let v1908 : UH6 = UH6_1(v1902, v1907)
        let v1909 : UH10 = UH10_0
        let v1910 : UH10 = UH10_1(v1901, v1909)
        let v1911 : UH10 = UH10_0
        let v1912 : UH10 = UH10_1(v1901, v1911)
        let v1913 : US8 = dfa_closure_loop_bounded_124(v1908, v1900, v1910, v1912)
        match v1913 with
        | US8_1(v1925) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v1914) -> (* DfaClosureComplete *)
            let v1915 : US1 = US1_0
            let v1916 : US1 = US1_1
            let v1917 : US1 = US1_0
            let v1918 : US1 = US1_1
            let v1919 : UH1 = UH1_0
            let v1920 : UH1 = UH1_1(v1918, v1919)
            let v1921 : UH1 = UH1_1(v1917, v1920)
            let v1922 : UH1 = UH1_1(v1916, v1921)
            let v1923 : UH1 = UH1_1(v1915, v1922)
            dfa_run_in_closure_162(v1896, v1914, v1923)
    else
        US12_2
let v1931 : US1 = US1_0
let v1932 : UH3 = UH3_2(v1931)
let v1933 : US1 = US1_1
let v1934 : UH3 = UH3_2(v1933)
let v1935 : UH3 = UH3_3(v1932, v1934)
let v1936 : UH3 = UH3_5(v1935)
let v1937 : US1 = US1_2
let v1938 : UH3 = UH3_2(v1937)
let v1939 : UH3 = UH3_4(v1936, v1938)
let v1940 : US1 = US1_0
let v1941 : US1 = US1_1
let v1942 : US1 = US1_0
let v1943 : US1 = US1_1
let v1944 : UH1 = UH1_0
let v1945 : UH1 = UH1_1(v1943, v1944)
let v1946 : UH1 = UH1_1(v1942, v1945)
let v1947 : UH1 = UH1_1(v1941, v1946)
let v1948 : UH1 = UH1_1(v1940, v1947)
let v1949 : bool = accepts_12(v1939, v1948)
let v1952 : bool =
    match v1930 with
    | US12_0 -> (* DfaAccepted *)
        v1949
    | US12_1 -> (* DfaRejected *)
        let v1950 : bool = false = v1949
        v1950
    | _ ->
        false
if v1952 then
    ()
else
    failwith<unit> "ternary suffix DFA runner should preserve rejection"
let v1953 : US0 = US0_1
let v1954 : US0 = US0_1
let v1955 : US0 = US0_0
let v1956 : UH0 = UH0_0
let v1957 : UH0 = UH0_1(v1955, v1956)
let v1958 : UH0 = UH0_1(v1954, v1957)
let v1959 : UH0 = UH0_1(v1953, v1958)
let v1960 : US0 = US0_0
let v1961 : US0 = US0_1
let v1962 : UH4 = UH4_0
let v1963 : UH4 = UH4_1(v1961, v1962)
let v1964 : UH4 = UH4_1(v1960, v1963)
let v1965 : bool = input_symbols_covered_52(v1959, v1964)
let v2027 : US12 =
    if v1965 then
        let v1966 : US0 = US0_0
        let v1967 : UH2 = UH2_2(v1966)
        let v1968 : US0 = US0_1
        let v1969 : UH2 = UH2_2(v1968)
        let v1970 : UH2 = UH2_3(v1967, v1969)
        let v1971 : UH2 = UH2_5(v1970)
        let v1972 : US0 = US0_0
        let v1973 : UH2 = UH2_2(v1972)
        let v1974 : UH2 = UH2_4(v1971, v1973)
        let v1975 : UH2 = normalize_4(v1974)
        let v1976 : UH2 = normalize_4(v1975)
        let v1977 : UH8 = regex_position_count_102(v1976)
        let v1978 : UH8 = UH8_1(v1977)
        let v1979 : UH8 = state_budget_pow2_104(v1978)
        let v1980 : UH2 = normalize_4(v1976)
        let v1981 : US0 = US0_0
        let v1982 : US0 = US0_1
        let v1983 : UH4 = UH4_0
        let v1984 : UH4 = UH4_1(v1982, v1983)
        let v1985 : UH4 = UH4_1(v1981, v1984)
        let v1986 : UH9 = UH9_0
        let v1987 : UH9 = UH9_1(v1980, v1986)
        let v1988 : UH9 = UH9_0
        let v1989 : UH9 = UH9_1(v1980, v1988)
        let v1990 : US4 = dfa_closure_loop_bounded_54(v1985, v1979, v1987, v1989)
        match v1990 with
        | US4_1(v2022) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US4_0(v1991) -> (* DfaClosureComplete *)
            let v1992 : US0 = US0_0
            let v1993 : US0 = US0_1
            let v1994 : UH4 = UH4_0
            let v1995 : UH4 = UH4_1(v1993, v1994)
            let v1996 : UH4 = UH4_1(v1992, v1995)
            let v1997 : UH9 = UH9_0
            let v1998 : UH9 = dfa_minimize_states_loop_147(v1991, v1996, v1997)
            let v1999 : US0 = US0_0
            let v2000 : US0 = US0_1
            let v2001 : UH4 = UH4_0
            let v2002 : UH4 = UH4_1(v2000, v2001)
            let v2003 : UH4 = UH4_1(v1999, v2002)
            let v2004 : US10 = dfa_find_bisimilar_representative_148(v1975, v1998, v2003)
            match v2004 with
            | US10_0(v2005) -> (* DfaRepresentativeFound *)
                let v2006 : US0 = US0_0
                let v2007 : US0 = US0_1
                let v2008 : UH4 = UH4_0
                let v2009 : UH4 = UH4_1(v2007, v2008)
                let v2010 : UH4 = UH4_1(v2006, v2009)
                let v2011 : US0 = US0_1
                let v2012 : US0 = US0_1
                let v2013 : US0 = US0_0
                let v2014 : UH0 = UH0_0
                let v2015 : UH0 = UH0_1(v2013, v2014)
                let v2016 : UH0 = UH0_1(v2012, v2015)
                let v2017 : UH0 = UH0_1(v2011, v2016)
                dfa_run_minimized_in_representatives_163(v2005, v1998, v2010, v2017)
            | US10_1 -> (* DfaRepresentativeMissing *)
                US12_2
    else
        US12_2
let v2028 : US0 = US0_0
let v2029 : UH2 = UH2_2(v2028)
let v2030 : US0 = US0_1
let v2031 : UH2 = UH2_2(v2030)
let v2032 : UH2 = UH2_3(v2029, v2031)
let v2033 : UH2 = UH2_5(v2032)
let v2034 : US0 = US0_0
let v2035 : UH2 = UH2_2(v2034)
let v2036 : UH2 = UH2_4(v2033, v2035)
let v2037 : US0 = US0_1
let v2038 : US0 = US0_1
let v2039 : US0 = US0_0
let v2040 : UH0 = UH0_0
let v2041 : UH0 = UH0_1(v2039, v2040)
let v2042 : UH0 = UH0_1(v2038, v2041)
let v2043 : UH0 = UH0_1(v2037, v2042)
let v2044 : bool = accepts_2(v2036, v2043)
let v2047 : bool =
    match v2027 with
    | US12_0 -> (* DfaAccepted *)
        v2044
    | US12_1 -> (* DfaRejected *)
        let v2045 : bool = false = v2044
        v2045
    | _ ->
        false
if v2047 then
    ()
else
    failwith<unit> "bit minimized runner should preserve acceptance"
let v2048 : US1 = US1_0
let v2049 : US1 = US1_0
let v2050 : US1 = US1_1
let v2051 : UH1 = UH1_0
let v2052 : UH1 = UH1_1(v2050, v2051)
let v2053 : UH1 = UH1_1(v2049, v2052)
let v2054 : UH1 = UH1_1(v2048, v2053)
let v2055 : US1 = US1_0
let v2056 : US1 = US1_1
let v2057 : US1 = US1_2
let v2058 : UH6 = UH6_0
let v2059 : UH6 = UH6_1(v2057, v2058)
let v2060 : UH6 = UH6_1(v2056, v2059)
let v2061 : UH6 = UH6_1(v2055, v2060)
let v2062 : bool = input_symbols_covered_160(v2054, v2061)
let v2126 : US12 =
    if v2062 then
        let v2063 : US1 = US1_0
        let v2064 : UH3 = UH3_2(v2063)
        let v2065 : UH3 = UH3_5(v2064)
        let v2066 : UH3 = normalize_14(v2065)
        let v2067 : UH3 = normalize_14(v2066)
        let v2068 : UH8 = regex_position_count_123(v2067)
        let v2069 : UH8 = UH8_1(v2068)
        let v2070 : UH8 = state_budget_pow2_104(v2069)
        let v2071 : UH3 = normalize_14(v2067)
        let v2072 : US1 = US1_0
        let v2073 : US1 = US1_1
        let v2074 : US1 = US1_2
        let v2075 : UH6 = UH6_0
        let v2076 : UH6 = UH6_1(v2074, v2075)
        let v2077 : UH6 = UH6_1(v2073, v2076)
        let v2078 : UH6 = UH6_1(v2072, v2077)
        let v2079 : UH10 = UH10_0
        let v2080 : UH10 = UH10_1(v2071, v2079)
        let v2081 : UH10 = UH10_0
        let v2082 : UH10 = UH10_1(v2071, v2081)
        let v2083 : US8 = dfa_closure_loop_bounded_124(v2078, v2070, v2080, v2082)
        match v2083 with
        | US8_1(v2121) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v2084) -> (* DfaClosureComplete *)
            let v2085 : US1 = US1_0
            let v2086 : US1 = US1_1
            let v2087 : US1 = US1_2
            let v2088 : UH6 = UH6_0
            let v2089 : UH6 = UH6_1(v2087, v2088)
            let v2090 : UH6 = UH6_1(v2086, v2089)
            let v2091 : UH6 = UH6_1(v2085, v2090)
            let v2092 : UH10 = UH10_0
            let v2093 : UH10 = dfa_minimize_states_loop_153(v2084, v2091, v2092)
            let v2094 : US1 = US1_0
            let v2095 : US1 = US1_1
            let v2096 : US1 = US1_2
            let v2097 : UH6 = UH6_0
            let v2098 : UH6 = UH6_1(v2096, v2097)
            let v2099 : UH6 = UH6_1(v2095, v2098)
            let v2100 : UH6 = UH6_1(v2094, v2099)
            let v2101 : US11 = dfa_find_bisimilar_representative_154(v2066, v2093, v2100)
            match v2101 with
            | US11_0(v2102) -> (* DfaRepresentativeFound *)
                let v2103 : US1 = US1_0
                let v2104 : US1 = US1_1
                let v2105 : US1 = US1_2
                let v2106 : UH6 = UH6_0
                let v2107 : UH6 = UH6_1(v2105, v2106)
                let v2108 : UH6 = UH6_1(v2104, v2107)
                let v2109 : UH6 = UH6_1(v2103, v2108)
                let v2110 : US1 = US1_0
                let v2111 : US1 = US1_0
                let v2112 : US1 = US1_1
                let v2113 : UH1 = UH1_0
                let v2114 : UH1 = UH1_1(v2112, v2113)
                let v2115 : UH1 = UH1_1(v2111, v2114)
                let v2116 : UH1 = UH1_1(v2110, v2115)
                dfa_run_minimized_in_representatives_164(v2102, v2093, v2109, v2116)
            | US11_1 -> (* DfaRepresentativeMissing *)
                US12_2
    else
        US12_2
let v2127 : US1 = US1_0
let v2128 : UH3 = UH3_2(v2127)
let v2129 : UH3 = UH3_5(v2128)
let v2130 : US1 = US1_0
let v2131 : US1 = US1_0
let v2132 : US1 = US1_1
let v2133 : UH1 = UH1_0
let v2134 : UH1 = UH1_1(v2132, v2133)
let v2135 : UH1 = UH1_1(v2131, v2134)
let v2136 : UH1 = UH1_1(v2130, v2135)
let v2137 : bool = accepts_12(v2129, v2136)
let v2140 : bool =
    match v2126 with
    | US12_0 -> (* DfaAccepted *)
        v2137
    | US12_1 -> (* DfaRejected *)
        let v2138 : bool = false = v2137
        v2138
    | _ ->
        false
if v2140 then
    ()
else
    failwith<unit> "ternary minimized runner should preserve rejection"
let v2141 : US1 = US1_0
let v2142 : US1 = US1_0
let v2143 : US1 = US1_0
let v2144 : UH1 = UH1_0
let v2145 : UH1 = UH1_1(v2143, v2144)
let v2146 : UH1 = UH1_1(v2142, v2145)
let v2147 : UH1 = UH1_1(v2141, v2146)
let v2148 : US1 = US1_0
let v2149 : US1 = US1_1
let v2150 : US1 = US1_2
let v2151 : UH6 = UH6_0
let v2152 : UH6 = UH6_1(v2150, v2151)
let v2153 : UH6 = UH6_1(v2149, v2152)
let v2154 : UH6 = UH6_1(v2148, v2153)
let v2155 : bool = input_symbols_covered_160(v2147, v2154)
let v2236 : US12 =
    if v2155 then
        let v2156 : US1 = US1_0
        let v2157 : UH3 = UH3_2(v2156)
        let v2158 : US1 = US1_0
        let v2159 : UH3 = UH3_2(v2158)
        let v2160 : UH3 = UH3_5(v2159)
        let v2161 : UH3 = UH3_4(v2157, v2160)
        let v2162 : US1 = US1_1
        let v2163 : UH3 = UH3_2(v2162)
        let v2164 : US1 = US1_0
        let v2165 : UH3 = UH3_2(v2164)
        let v2166 : US1 = US1_0
        let v2167 : UH3 = UH3_2(v2166)
        let v2168 : UH3 = UH3_4(v2165, v2167)
        let v2169 : UH3 = UH3_5(v2168)
        let v2170 : US1 = US1_0
        let v2171 : UH3 = UH3_2(v2170)
        let v2172 : UH3 = UH3_4(v2171, v2169)
        let v2173 : UH3 = UH3_3(v2169, v2172)
        let v2174 : UH3 = UH3_4(v2163, v2173)
        let v2175 : UH3 = UH3_3(v2161, v2174)
        let v2176 : UH3 = normalize_14(v2175)
        let v2177 : UH3 = normalize_14(v2176)
        let v2178 : UH8 = regex_position_count_123(v2177)
        let v2179 : UH8 = UH8_1(v2178)
        let v2180 : UH8 = state_budget_pow2_104(v2179)
        let v2181 : UH3 = normalize_14(v2177)
        let v2182 : US1 = US1_0
        let v2183 : US1 = US1_1
        let v2184 : US1 = US1_2
        let v2185 : UH6 = UH6_0
        let v2186 : UH6 = UH6_1(v2184, v2185)
        let v2187 : UH6 = UH6_1(v2183, v2186)
        let v2188 : UH6 = UH6_1(v2182, v2187)
        let v2189 : UH10 = UH10_0
        let v2190 : UH10 = UH10_1(v2181, v2189)
        let v2191 : UH10 = UH10_0
        let v2192 : UH10 = UH10_1(v2181, v2191)
        let v2193 : US8 = dfa_closure_loop_bounded_124(v2188, v2180, v2190, v2192)
        match v2193 with
        | US8_1(v2231) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v2194) -> (* DfaClosureComplete *)
            let v2195 : US1 = US1_0
            let v2196 : US1 = US1_1
            let v2197 : US1 = US1_2
            let v2198 : UH6 = UH6_0
            let v2199 : UH6 = UH6_1(v2197, v2198)
            let v2200 : UH6 = UH6_1(v2196, v2199)
            let v2201 : UH6 = UH6_1(v2195, v2200)
            let v2202 : UH10 = UH10_0
            let v2203 : UH10 = dfa_minimize_states_loop_153(v2194, v2201, v2202)
            let v2204 : US1 = US1_0
            let v2205 : US1 = US1_1
            let v2206 : US1 = US1_2
            let v2207 : UH6 = UH6_0
            let v2208 : UH6 = UH6_1(v2206, v2207)
            let v2209 : UH6 = UH6_1(v2205, v2208)
            let v2210 : UH6 = UH6_1(v2204, v2209)
            let v2211 : US11 = dfa_find_bisimilar_representative_154(v2176, v2203, v2210)
            match v2211 with
            | US11_0(v2212) -> (* DfaRepresentativeFound *)
                let v2213 : US1 = US1_0
                let v2214 : US1 = US1_1
                let v2215 : US1 = US1_2
                let v2216 : UH6 = UH6_0
                let v2217 : UH6 = UH6_1(v2215, v2216)
                let v2218 : UH6 = UH6_1(v2214, v2217)
                let v2219 : UH6 = UH6_1(v2213, v2218)
                let v2220 : US1 = US1_0
                let v2221 : US1 = US1_0
                let v2222 : US1 = US1_0
                let v2223 : UH1 = UH1_0
                let v2224 : UH1 = UH1_1(v2222, v2223)
                let v2225 : UH1 = UH1_1(v2221, v2224)
                let v2226 : UH1 = UH1_1(v2220, v2225)
                dfa_run_minimized_in_representatives_164(v2212, v2203, v2219, v2226)
            | US11_1 -> (* DfaRepresentativeMissing *)
                US12_2
    else
        US12_2
let v2237 : US1 = US1_0
let v2238 : UH3 = UH3_2(v2237)
let v2239 : US1 = US1_0
let v2240 : UH3 = UH3_2(v2239)
let v2241 : UH3 = UH3_5(v2240)
let v2242 : UH3 = UH3_4(v2238, v2241)
let v2243 : US1 = US1_1
let v2244 : UH3 = UH3_2(v2243)
let v2245 : US1 = US1_0
let v2246 : UH3 = UH3_2(v2245)
let v2247 : US1 = US1_0
let v2248 : UH3 = UH3_2(v2247)
let v2249 : UH3 = UH3_4(v2246, v2248)
let v2250 : UH3 = UH3_5(v2249)
let v2251 : US1 = US1_0
let v2252 : UH3 = UH3_2(v2251)
let v2253 : UH3 = UH3_4(v2252, v2250)
let v2254 : UH3 = UH3_3(v2250, v2253)
let v2255 : UH3 = UH3_4(v2244, v2254)
let v2256 : UH3 = UH3_3(v2242, v2255)
let v2257 : US1 = US1_0
let v2258 : US1 = US1_0
let v2259 : US1 = US1_0
let v2260 : UH1 = UH1_0
let v2261 : UH1 = UH1_1(v2259, v2260)
let v2262 : UH1 = UH1_1(v2258, v2261)
let v2263 : UH1 = UH1_1(v2257, v2262)
let v2264 : bool = accepts_12(v2256, v2263)
let v2267 : bool =
    match v2236 with
    | US12_0 -> (* DfaAccepted *)
        v2264
    | US12_1 -> (* DfaRejected *)
        let v2265 : bool = false = v2264
        v2265
    | _ ->
        false
if v2267 then
    ()
else
    failwith<unit> "cyclic quotient should preserve acceptance"
let v2268 : US1 = US1_0
let v2269 : US1 = US1_0
let v2270 : US1 = US1_1
let v2271 : UH1 = UH1_0
let v2272 : UH1 = UH1_1(v2270, v2271)
let v2273 : UH1 = UH1_1(v2269, v2272)
let v2274 : UH1 = UH1_1(v2268, v2273)
let v2275 : US1 = US1_0
let v2276 : US1 = US1_1
let v2277 : US1 = US1_2
let v2278 : UH6 = UH6_0
let v2279 : UH6 = UH6_1(v2277, v2278)
let v2280 : UH6 = UH6_1(v2276, v2279)
let v2281 : UH6 = UH6_1(v2275, v2280)
let v2282 : bool = input_symbols_covered_160(v2274, v2281)
let v2363 : US12 =
    if v2282 then
        let v2283 : US1 = US1_0
        let v2284 : UH3 = UH3_2(v2283)
        let v2285 : US1 = US1_0
        let v2286 : UH3 = UH3_2(v2285)
        let v2287 : UH3 = UH3_5(v2286)
        let v2288 : UH3 = UH3_4(v2284, v2287)
        let v2289 : US1 = US1_1
        let v2290 : UH3 = UH3_2(v2289)
        let v2291 : US1 = US1_0
        let v2292 : UH3 = UH3_2(v2291)
        let v2293 : US1 = US1_0
        let v2294 : UH3 = UH3_2(v2293)
        let v2295 : UH3 = UH3_4(v2292, v2294)
        let v2296 : UH3 = UH3_5(v2295)
        let v2297 : US1 = US1_0
        let v2298 : UH3 = UH3_2(v2297)
        let v2299 : UH3 = UH3_4(v2298, v2296)
        let v2300 : UH3 = UH3_3(v2296, v2299)
        let v2301 : UH3 = UH3_4(v2290, v2300)
        let v2302 : UH3 = UH3_3(v2288, v2301)
        let v2303 : UH3 = normalize_14(v2302)
        let v2304 : UH3 = normalize_14(v2303)
        let v2305 : UH8 = regex_position_count_123(v2304)
        let v2306 : UH8 = UH8_1(v2305)
        let v2307 : UH8 = state_budget_pow2_104(v2306)
        let v2308 : UH3 = normalize_14(v2304)
        let v2309 : US1 = US1_0
        let v2310 : US1 = US1_1
        let v2311 : US1 = US1_2
        let v2312 : UH6 = UH6_0
        let v2313 : UH6 = UH6_1(v2311, v2312)
        let v2314 : UH6 = UH6_1(v2310, v2313)
        let v2315 : UH6 = UH6_1(v2309, v2314)
        let v2316 : UH10 = UH10_0
        let v2317 : UH10 = UH10_1(v2308, v2316)
        let v2318 : UH10 = UH10_0
        let v2319 : UH10 = UH10_1(v2308, v2318)
        let v2320 : US8 = dfa_closure_loop_bounded_124(v2315, v2307, v2317, v2319)
        match v2320 with
        | US8_1(v2358) -> (* DfaClosureBudgetExceeded *)
            US12_2
        | US8_0(v2321) -> (* DfaClosureComplete *)
            let v2322 : US1 = US1_0
            let v2323 : US1 = US1_1
            let v2324 : US1 = US1_2
            let v2325 : UH6 = UH6_0
            let v2326 : UH6 = UH6_1(v2324, v2325)
            let v2327 : UH6 = UH6_1(v2323, v2326)
            let v2328 : UH6 = UH6_1(v2322, v2327)
            let v2329 : UH10 = UH10_0
            let v2330 : UH10 = dfa_minimize_states_loop_153(v2321, v2328, v2329)
            let v2331 : US1 = US1_0
            let v2332 : US1 = US1_1
            let v2333 : US1 = US1_2
            let v2334 : UH6 = UH6_0
            let v2335 : UH6 = UH6_1(v2333, v2334)
            let v2336 : UH6 = UH6_1(v2332, v2335)
            let v2337 : UH6 = UH6_1(v2331, v2336)
            let v2338 : US11 = dfa_find_bisimilar_representative_154(v2303, v2330, v2337)
            match v2338 with
            | US11_0(v2339) -> (* DfaRepresentativeFound *)
                let v2340 : US1 = US1_0
                let v2341 : US1 = US1_1
                let v2342 : US1 = US1_2
                let v2343 : UH6 = UH6_0
                let v2344 : UH6 = UH6_1(v2342, v2343)
                let v2345 : UH6 = UH6_1(v2341, v2344)
                let v2346 : UH6 = UH6_1(v2340, v2345)
                let v2347 : US1 = US1_0
                let v2348 : US1 = US1_0
                let v2349 : US1 = US1_1
                let v2350 : UH1 = UH1_0
                let v2351 : UH1 = UH1_1(v2349, v2350)
                let v2352 : UH1 = UH1_1(v2348, v2351)
                let v2353 : UH1 = UH1_1(v2347, v2352)
                dfa_run_minimized_in_representatives_164(v2339, v2330, v2346, v2353)
            | US11_1 -> (* DfaRepresentativeMissing *)
                US12_2
    else
        US12_2
let v2364 : US1 = US1_0
let v2365 : UH3 = UH3_2(v2364)
let v2366 : US1 = US1_0
let v2367 : UH3 = UH3_2(v2366)
let v2368 : UH3 = UH3_5(v2367)
let v2369 : UH3 = UH3_4(v2365, v2368)
let v2370 : US1 = US1_1
let v2371 : UH3 = UH3_2(v2370)
let v2372 : US1 = US1_0
let v2373 : UH3 = UH3_2(v2372)
let v2374 : US1 = US1_0
let v2375 : UH3 = UH3_2(v2374)
let v2376 : UH3 = UH3_4(v2373, v2375)
let v2377 : UH3 = UH3_5(v2376)
let v2378 : US1 = US1_0
let v2379 : UH3 = UH3_2(v2378)
let v2380 : UH3 = UH3_4(v2379, v2377)
let v2381 : UH3 = UH3_3(v2377, v2380)
let v2382 : UH3 = UH3_4(v2371, v2381)
let v2383 : UH3 = UH3_3(v2369, v2382)
let v2384 : US1 = US1_0
let v2385 : US1 = US1_0
let v2386 : US1 = US1_1
let v2387 : UH1 = UH1_0
let v2388 : UH1 = UH1_1(v2386, v2387)
let v2389 : UH1 = UH1_1(v2385, v2388)
let v2390 : UH1 = UH1_1(v2384, v2389)
let v2391 : bool = accepts_12(v2383, v2390)
let v2394 : bool =
    match v2363 with
    | US12_0 -> (* DfaAccepted *)
        v2391
    | US12_1 -> (* DfaRejected *)
        let v2392 : bool = false = v2391
        v2392
    | _ ->
        false
if v2394 then
    ()
else
    failwith<unit> "cyclic quotient should preserve rejection"
let v2395 : US0 = US0_1
let v2396 : UH2 = UH2_2(v2395)
let v2397 : US0 = US0_0
let v2398 : UH2 = UH2_2(v2397)
let v2399 : US0 = US0_1
let v2400 : UH2 = UH2_2(v2399)
let v2401 : UH2 = UH2_3(v2398, v2400)
let v2402 : UH2 = UH2_3(v2396, v2401)
let v2403 : UH2 = normalize_4(v2402)
let v2404 : US0 = US0_0
let v2405 : UH2 = UH2_2(v2404)
let v2406 : US0 = US0_1
let v2407 : UH2 = UH2_2(v2406)
let v2408 : UH2 = UH2_3(v2405, v2407)
let v2409 : UH2 = normalize_4(v2408)
let v2410 : bool = regex_equal_9(v2403, v2409)
if v2410 then
    ()
else
    failwith<unit> "alternative normalization should deduplicate and order"
let v2411 : US0 = US0_1
let v2412 : UH2 = UH2_2(v2411)
let v2413 : US0 = US0_0
let v2414 : UH2 = UH2_2(v2413)
let v2415 : UH2 = UH2_3(v2412, v2414)
let v2416 : UH2 = normalize_4(v2415)
let v2417 : US0 = US0_0
let v2418 : UH2 = UH2_2(v2417)
let v2419 : US0 = US0_1
let v2420 : UH2 = UH2_2(v2419)
let v2421 : UH2 = UH2_3(v2418, v2420)
let v2422 : UH2 = normalize_4(v2421)
let v2423 : bool = regex_equal_9(v2416, v2422)
if v2423 then
    ()
else
    failwith<unit> "alternative normalization should commute canonically"
let v2424 : US0 = US0_0
let v2425 : UH2 = UH2_2(v2424)
let v2426 : UH2 = UH2_1
let v2427 : UH2 = UH2_4(v2425, v2426)
let v2428 : US0 = US0_1
let v2429 : UH2 = UH2_2(v2428)
let v2430 : UH2 = UH2_4(v2427, v2429)
let v2431 : UH2 = normalize_4(v2430)
let v2432 : US0 = US0_0
let v2433 : UH2 = UH2_2(v2432)
let v2434 : UH2 = UH2_1
let v2435 : US0 = US0_1
let v2436 : UH2 = UH2_2(v2435)
let v2437 : UH2 = UH2_4(v2434, v2436)
let v2438 : UH2 = UH2_4(v2433, v2437)
let v2439 : UH2 = normalize_4(v2438)
let v2440 : bool = regex_equal_9(v2431, v2439)
if v2440 then
    ()
else
    failwith<unit> "concatenation normalization should reassociate canonically"
let v2441 : US0 = US0_0
let v2442 : UH2 = UH2_2(v2441)
let v2443 : UH2 = UH2_5(v2442)
let v2444 : UH2 = UH2_5(v2443)
let v2445 : UH2 = normalize_4(v2444)
let v2446 : US0 = US0_0
let v2447 : UH2 = UH2_2(v2446)
let v2448 : UH2 = UH2_5(v2447)
let v2449 : UH2 = normalize_4(v2448)
let v2450 : bool = regex_equal_9(v2445, v2449)
if v2450 then
    ()
else
    failwith<unit> "star normalization should collapse nested stars"
let v2451 : US0 = US0_0
let v2452 : UH2 = UH2_2(v2451)
let v2453 : UH2 = UH2_5(v2452)
let v2454 : UH2 = UH2_4(v2453, v2453)
let v2455 : UH2 = normalize_4(v2454)
let v2456 : US0 = US0_0
let v2457 : UH2 = UH2_2(v2456)
let v2458 : UH2 = UH2_5(v2457)
let v2459 : UH2 = normalize_4(v2458)
let v2460 : bool = regex_equal_9(v2455, v2459)
if v2460 then
    ()
else
    failwith<unit> "adjacent identical stars should collapse under concatenation"
let v2461 : US0 = US0_0
let v2462 : UH2 = UH2_2(v2461)
let v2463 : UH2 = UH2_5(v2462)
let v2464 : UH2 = UH2_5(v2463)
let v2465 : UH2 = normalize_4(v2464)
let v2466 : US0 = US0_0
let v2467 : UH2 = derivative_11(v2465, v2466)
let v2468 : UH2 = normalize_4(v2467)
let v2469 : US0 = US0_0
let v2470 : UH2 = UH2_2(v2469)
let v2471 : UH2 = UH2_5(v2470)
let v2472 : UH2 = UH2_5(v2471)
let v2473 : US0 = US0_0
let v2474 : UH2 = derivative_11(v2472, v2473)
let v2475 : UH2 = normalize_4(v2474)
let v2476 : bool = regex_equal_9(v2468, v2475)
if v2476 then
    ()
else
    failwith<unit> "nested-star canonical derivative should commute with normalization"
let v2477 : US0 = US0_1
let v2478 : UH2 = UH2_2(v2477)
let v2479 : US0 = US0_0
let v2480 : UH2 = UH2_2(v2479)
let v2481 : US0 = US0_1
let v2482 : UH2 = UH2_2(v2481)
let v2483 : UH2 = UH2_3(v2480, v2482)
let v2484 : UH2 = UH2_3(v2478, v2483)
let v2485 : UH2 = normalize_4(v2484)
let v2486 : US0 = US0_1
let v2487 : UH2 = UH2_2(v2486)
let v2488 : US0 = US0_0
let v2489 : UH2 = UH2_2(v2488)
let v2490 : US0 = US0_1
let v2491 : UH2 = UH2_2(v2490)
let v2492 : UH2 = UH2_3(v2489, v2491)
let v2493 : UH2 = UH2_3(v2487, v2492)
let v2494 : UH2 = normalize_4(v2493)
let v2495 : UH2 = normalize_4(v2494)
let v2496 : bool = regex_equal_9(v2485, v2495)
if v2496 then
    ()
else
    failwith<unit> "alternative normalization should be idempotent"
let v2497 : US0 = US0_0
let v2498 : UH2 = UH2_2(v2497)
let v2499 : UH2 = UH2_1
let v2500 : UH2 = UH2_4(v2498, v2499)
let v2501 : US0 = US0_1
let v2502 : UH2 = UH2_2(v2501)
let v2503 : UH2 = UH2_4(v2500, v2502)
let v2504 : UH2 = normalize_4(v2503)
let v2505 : US0 = US0_0
let v2506 : UH2 = UH2_2(v2505)
let v2507 : UH2 = UH2_1
let v2508 : UH2 = UH2_4(v2506, v2507)
let v2509 : US0 = US0_1
let v2510 : UH2 = UH2_2(v2509)
let v2511 : UH2 = UH2_4(v2508, v2510)
let v2512 : UH2 = normalize_4(v2511)
let v2513 : UH2 = normalize_4(v2512)
let v2514 : bool = regex_equal_9(v2504, v2513)
if v2514 then
    ()
else
    failwith<unit> "concatenation normalization should be idempotent"
let v2515 : US0 = US0_0
let v2516 : UH2 = UH2_2(v2515)
let v2517 : UH2 = UH2_5(v2516)
let v2518 : UH2 = UH2_5(v2517)
let v2519 : UH2 = normalize_4(v2518)
let v2520 : US0 = US0_0
let v2521 : UH2 = UH2_2(v2520)
let v2522 : UH2 = UH2_5(v2521)
let v2523 : UH2 = UH2_5(v2522)
let v2524 : UH2 = normalize_4(v2523)
let v2525 : UH2 = normalize_4(v2524)
let v2526 : bool = regex_equal_9(v2519, v2525)
if v2526 then
    ()
else
    failwith<unit> "star normalization should be idempotent"
let v2527 : US0 = US0_0
let v2528 : UH2 = UH2_2(v2527)
let v2529 : US0 = US0_1
let v2530 : UH2 = UH2_2(v2529)
let v2531 : UH2 = UH2_3(v2528, v2530)
let v2532 : UH2 = UH2_5(v2531)
let v2533 : US0 = US0_0
let v2534 : UH2 = UH2_2(v2533)
let v2535 : UH2 = UH2_4(v2532, v2534)
let v2536 : bool = accepts_2(v2535, v6)
if v2536 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v2537 : US0 = US0_0
let v2538 : UH2 = UH2_2(v2537)
let v2539 : US0 = US0_1
let v2540 : UH2 = UH2_2(v2539)
let v2541 : UH2 = UH2_3(v2538, v2540)
let v2542 : UH2 = UH2_5(v2541)
let v2543 : US0 = US0_0
let v2544 : UH2 = UH2_2(v2543)
let v2545 : UH2 = UH2_4(v2542, v2544)
let v2546 : bool = accepts_2(v2545, v13)
if v2546 then
    failwith<unit> "brzozowski-expected-false"
let v2547 : US1 = US1_0
let v2548 : UH3 = UH3_2(v2547)
let v2549 : UH3 = UH3_5(v2548)
let v2550 : bool = accepts_12(v2549, v21)
if v2550 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v2551 : US1 = US1_0
let v2552 : UH3 = UH3_2(v2551)
let v2553 : UH3 = UH3_5(v2552)
let v2554 : bool = accepts_12(v2553, v28)
if v2554 then
    failwith<unit> "brzozowski-expected-false"
let v2555 : US1 = US1_0
let v2556 : UH3 = UH3_2(v2555)
let v2557 : US1 = US1_1
let v2558 : UH3 = UH3_2(v2557)
let v2559 : UH3 = UH3_3(v2556, v2558)
let v2560 : UH3 = UH3_5(v2559)
let v2561 : US1 = US1_2
let v2562 : UH3 = UH3_2(v2561)
let v2563 : UH3 = UH3_4(v2560, v2562)
let v2564 : US1 = US1_0
let v2565 : US1 = US1_1
let v2566 : US1 = US1_0
let v2567 : US1 = US1_2
let v2568 : UH1 = UH1_0
let v2569 : UH1 = UH1_1(v2567, v2568)
let v2570 : UH1 = UH1_1(v2566, v2569)
let v2571 : UH1 = UH1_1(v2565, v2570)
let v2572 : UH1 = UH1_1(v2564, v2571)
let v2573 : bool = accepts_12(v2563, v2572)
if v2573 then
    ()
else
    failwith<unit> "ternary suffix matcher should accept the positive case"
let v2574 : US1 = US1_0
let v2575 : UH3 = UH3_2(v2574)
let v2576 : US1 = US1_1
let v2577 : UH3 = UH3_2(v2576)
let v2578 : UH3 = UH3_3(v2575, v2577)
let v2579 : UH3 = UH3_5(v2578)
let v2580 : US1 = US1_2
let v2581 : UH3 = UH3_2(v2580)
let v2582 : UH3 = UH3_4(v2579, v2581)
let v2583 : US1 = US1_0
let v2584 : US1 = US1_1
let v2585 : US1 = US1_0
let v2586 : US1 = US1_1
let v2587 : UH1 = UH1_0
let v2588 : UH1 = UH1_1(v2586, v2587)
let v2589 : UH1 = UH1_1(v2585, v2588)
let v2590 : UH1 = UH1_1(v2584, v2589)
let v2591 : UH1 = UH1_1(v2583, v2590)
let v2592 : bool = accepts_12(v2582, v2591)
let v2593 : bool = v2592 = false
if v2593 then
    ()
else
    failwith<unit> "ternary suffix matcher should reject the negative case"
let v2594 : UH2 = UH2_1
let v2595 : bool = accepts_2(v2594, v14)
if v2595 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v2596 : UH2 = UH2_0
let v2597 : bool = accepts_2(v2596, v14)
if v2597 then
    failwith<unit> "brzozowski-expected-false"
let v2598 : US0 = US0_0
let v2599 : UH2 = UH2_2(v2598)
let v2600 : US0 = US0_1
let v2601 : UH2 = UH2_2(v2600)
let v2602 : UH2 = UH2_3(v2599, v2601)
let v2603 : UH2 = UH2_5(v2602)
let v2604 : US0 = US0_0
let v2605 : UH2 = UH2_2(v2604)
let v2606 : UH2 = UH2_4(v2603, v2605)
let v2607 : US0 = US0_1
let v2608 : US0 = US0_1
let v2609 : US0 = US0_0
let v2610 : UH0 = UH0_0
let v2611 : UH0 = UH0_1(v2609, v2610)
let v2612 : UH0 = UH0_1(v2608, v2611)
let v2613 : UH0 = UH0_1(v2607, v2612)
let v2614 : bool = reference_accepts_165(v2606, v2613)
let v2615 : US0 = US0_0
let v2616 : UH2 = UH2_2(v2615)
let v2617 : US0 = US0_1
let v2618 : UH2 = UH2_2(v2617)
let v2619 : UH2 = UH2_3(v2616, v2618)
let v2620 : UH2 = UH2_5(v2619)
let v2621 : US0 = US0_0
let v2622 : UH2 = UH2_2(v2621)
let v2623 : UH2 = UH2_4(v2620, v2622)
let v2624 : US0 = US0_1
let v2625 : US0 = US0_1
let v2626 : US0 = US0_0
let v2627 : UH0 = UH0_0
let v2628 : UH0 = UH0_1(v2626, v2627)
let v2629 : UH0 = UH0_1(v2625, v2628)
let v2630 : UH0 = UH0_1(v2624, v2629)
let v2631 : bool = accepts_2(v2623, v2630)
let v2633 : bool =
    if v2614 then
        v2631
    else
        let v2632 : bool = false = v2631
        v2632
if v2633 then
    ()
else
    failwith<unit> "bit reference matcher should agree on acceptance"
let v2634 : US0 = US0_0
let v2635 : UH2 = UH2_2(v2634)
let v2636 : US0 = US0_1
let v2637 : UH2 = UH2_2(v2636)
let v2638 : UH2 = UH2_3(v2635, v2637)
let v2639 : UH2 = UH2_5(v2638)
let v2640 : US0 = US0_0
let v2641 : UH2 = UH2_2(v2640)
let v2642 : UH2 = UH2_4(v2639, v2641)
let v2643 : US0 = US0_1
let v2644 : US0 = US0_1
let v2645 : US0 = US0_1
let v2646 : UH0 = UH0_0
let v2647 : UH0 = UH0_1(v2645, v2646)
let v2648 : UH0 = UH0_1(v2644, v2647)
let v2649 : UH0 = UH0_1(v2643, v2648)
let v2650 : bool = reference_accepts_165(v2642, v2649)
let v2651 : US0 = US0_0
let v2652 : UH2 = UH2_2(v2651)
let v2653 : US0 = US0_1
let v2654 : UH2 = UH2_2(v2653)
let v2655 : UH2 = UH2_3(v2652, v2654)
let v2656 : UH2 = UH2_5(v2655)
let v2657 : US0 = US0_0
let v2658 : UH2 = UH2_2(v2657)
let v2659 : UH2 = UH2_4(v2656, v2658)
let v2660 : US0 = US0_1
let v2661 : US0 = US0_1
let v2662 : US0 = US0_1
let v2663 : UH0 = UH0_0
let v2664 : UH0 = UH0_1(v2662, v2663)
let v2665 : UH0 = UH0_1(v2661, v2664)
let v2666 : UH0 = UH0_1(v2660, v2665)
let v2667 : bool = accepts_2(v2659, v2666)
let v2669 : bool =
    if v2650 then
        v2667
    else
        let v2668 : bool = false = v2667
        v2668
if v2669 then
    ()
else
    failwith<unit> "bit reference matcher should agree on rejection"
let v2670 : US1 = US1_0
let v2671 : UH3 = UH3_2(v2670)
let v2672 : UH3 = UH3_5(v2671)
let v2673 : US1 = US1_0
let v2674 : US1 = US1_0
let v2675 : US1 = US1_0
let v2676 : UH1 = UH1_0
let v2677 : UH1 = UH1_1(v2675, v2676)
let v2678 : UH1 = UH1_1(v2674, v2677)
let v2679 : UH1 = UH1_1(v2673, v2678)
let v2680 : bool = reference_accepts_166(v2672, v2679)
let v2681 : US1 = US1_0
let v2682 : UH3 = UH3_2(v2681)
let v2683 : UH3 = UH3_5(v2682)
let v2684 : US1 = US1_0
let v2685 : US1 = US1_0
let v2686 : US1 = US1_0
let v2687 : UH1 = UH1_0
let v2688 : UH1 = UH1_1(v2686, v2687)
let v2689 : UH1 = UH1_1(v2685, v2688)
let v2690 : UH1 = UH1_1(v2684, v2689)
let v2691 : bool = accepts_12(v2683, v2690)
let v2693 : bool =
    if v2680 then
        v2691
    else
        let v2692 : bool = false = v2691
        v2692
if v2693 then
    ()
else
    failwith<unit> "ternary reference matcher should agree on acceptance"
let v2694 : US1 = US1_0
let v2695 : UH3 = UH3_2(v2694)
let v2696 : UH3 = UH3_5(v2695)
let v2697 : US1 = US1_0
let v2698 : US1 = US1_0
let v2699 : US1 = US1_1
let v2700 : UH1 = UH1_0
let v2701 : UH1 = UH1_1(v2699, v2700)
let v2702 : UH1 = UH1_1(v2698, v2701)
let v2703 : UH1 = UH1_1(v2697, v2702)
let v2704 : bool = reference_accepts_166(v2696, v2703)
let v2705 : US1 = US1_0
let v2706 : UH3 = UH3_2(v2705)
let v2707 : UH3 = UH3_5(v2706)
let v2708 : US1 = US1_0
let v2709 : US1 = US1_0
let v2710 : US1 = US1_1
let v2711 : UH1 = UH1_0
let v2712 : UH1 = UH1_1(v2710, v2711)
let v2713 : UH1 = UH1_1(v2709, v2712)
let v2714 : UH1 = UH1_1(v2708, v2713)
let v2715 : bool = accepts_12(v2707, v2714)
let v2717 : bool =
    if v2704 then
        v2715
    else
        let v2716 : bool = false = v2715
        v2716
if v2717 then
    ()
else
    failwith<unit> "ternary reference matcher should agree on rejection"
let v2718 : US1 = US1_0
let v2719 : UH3 = UH3_2(v2718)
let v2720 : US1 = US1_1
let v2721 : UH3 = UH3_2(v2720)
let v2722 : UH3 = UH3_3(v2719, v2721)
let v2723 : UH3 = UH3_5(v2722)
let v2724 : US1 = US1_2
let v2725 : UH3 = UH3_2(v2724)
let v2726 : UH3 = UH3_4(v2723, v2725)
let v2727 : US1 = US1_0
let v2728 : US1 = US1_1
let v2729 : US1 = US1_0
let v2730 : US1 = US1_2
let v2731 : UH1 = UH1_0
let v2732 : UH1 = UH1_1(v2730, v2731)
let v2733 : UH1 = UH1_1(v2729, v2732)
let v2734 : UH1 = UH1_1(v2728, v2733)
let v2735 : UH1 = UH1_1(v2727, v2734)
let v2736 : bool = reference_accepts_166(v2726, v2735)
let v2737 : US1 = US1_0
let v2738 : UH3 = UH3_2(v2737)
let v2739 : US1 = US1_1
let v2740 : UH3 = UH3_2(v2739)
let v2741 : UH3 = UH3_3(v2738, v2740)
let v2742 : UH3 = UH3_5(v2741)
let v2743 : US1 = US1_2
let v2744 : UH3 = UH3_2(v2743)
let v2745 : UH3 = UH3_4(v2742, v2744)
let v2746 : US1 = US1_0
let v2747 : US1 = US1_1
let v2748 : US1 = US1_0
let v2749 : US1 = US1_2
let v2750 : UH1 = UH1_0
let v2751 : UH1 = UH1_1(v2749, v2750)
let v2752 : UH1 = UH1_1(v2748, v2751)
let v2753 : UH1 = UH1_1(v2747, v2752)
let v2754 : UH1 = UH1_1(v2746, v2753)
let v2755 : bool = accepts_12(v2745, v2754)
let v2757 : bool =
    if v2736 then
        v2755
    else
        let v2756 : bool = false = v2755
        v2756
if v2757 then
    ()
else
    failwith<unit> "ternary suffix reference matcher should agree on acceptance"
let v2758 : US1 = US1_0
let v2759 : UH3 = UH3_2(v2758)
let v2760 : US1 = US1_1
let v2761 : UH3 = UH3_2(v2760)
let v2762 : UH3 = UH3_3(v2759, v2761)
let v2763 : UH3 = UH3_5(v2762)
let v2764 : US1 = US1_2
let v2765 : UH3 = UH3_2(v2764)
let v2766 : UH3 = UH3_4(v2763, v2765)
let v2767 : US1 = US1_0
let v2768 : US1 = US1_1
let v2769 : US1 = US1_0
let v2770 : US1 = US1_1
let v2771 : UH1 = UH1_0
let v2772 : UH1 = UH1_1(v2770, v2771)
let v2773 : UH1 = UH1_1(v2769, v2772)
let v2774 : UH1 = UH1_1(v2768, v2773)
let v2775 : UH1 = UH1_1(v2767, v2774)
let v2776 : bool = reference_accepts_166(v2766, v2775)
let v2777 : US1 = US1_0
let v2778 : UH3 = UH3_2(v2777)
let v2779 : US1 = US1_1
let v2780 : UH3 = UH3_2(v2779)
let v2781 : UH3 = UH3_3(v2778, v2780)
let v2782 : UH3 = UH3_5(v2781)
let v2783 : US1 = US1_2
let v2784 : UH3 = UH3_2(v2783)
let v2785 : UH3 = UH3_4(v2782, v2784)
let v2786 : US1 = US1_0
let v2787 : US1 = US1_1
let v2788 : US1 = US1_0
let v2789 : US1 = US1_1
let v2790 : UH1 = UH1_0
let v2791 : UH1 = UH1_1(v2789, v2790)
let v2792 : UH1 = UH1_1(v2788, v2791)
let v2793 : UH1 = UH1_1(v2787, v2792)
let v2794 : UH1 = UH1_1(v2786, v2793)
let v2795 : bool = accepts_12(v2785, v2794)
let v2797 : bool =
    if v2776 then
        v2795
    else
        let v2796 : bool = false = v2795
        v2796
if v2797 then
    ()
else
    failwith<unit> "ternary suffix reference matcher should agree on rejection"
let v2798 : UH0 = UH0_0
let v2799 : US0 = US0_0
let v2800 : UH2 = UH2_2(v2799)
let v2801 : US0 = US0_1
let v2802 : UH2 = UH2_2(v2801)
let v2803 : UH2 = UH2_3(v2800, v2802)
let v2804 : UH2 = UH2_5(v2803)
let v2805 : US0 = US0_0
let v2806 : UH2 = UH2_2(v2805)
let v2807 : UH2 = UH2_4(v2804, v2806)
let v2808 : US0 = US0_1
let v2809 : US0 = US0_1
let v2810 : US0 = US0_0
let v2811 : UH0 = UH0_0
let v2812 : UH0 = UH0_1(v2810, v2811)
let v2813 : UH0 = UH0_1(v2809, v2812)
let v2814 : UH0 = UH0_1(v2808, v2813)
let v2815 : UH5 = language_remainders_27(v2807, v2814)
let v2816 : bool = input_list_contains_32(v2798, v2815)
let v2817 : US0 = US0_0
let v2818 : UH2 = UH2_2(v2817)
let v2819 : US0 = US0_1
let v2820 : UH2 = UH2_2(v2819)
let v2821 : UH2 = UH2_3(v2818, v2820)
let v2822 : UH2 = UH2_5(v2821)
let v2823 : US0 = US0_0
let v2824 : UH2 = UH2_2(v2823)
let v2825 : UH2 = UH2_4(v2822, v2824)
let v2826 : US0 = US0_1
let v2827 : US0 = US0_1
let v2828 : US0 = US0_0
let v2829 : UH0 = UH0_0
let v2830 : UH0 = UH0_1(v2828, v2829)
let v2831 : UH0 = UH0_1(v2827, v2830)
let v2832 : UH0 = UH0_1(v2826, v2831)
let v2833 : bool = accepts_2(v2825, v2832)
let v2835 : bool =
    if v2816 then
        v2833
    else
        let v2834 : bool = false = v2833
        v2834
if v2835 then
    ()
else
    failwith<unit> "bit direct-language oracle should agree on acceptance"
let v2836 : UH0 = UH0_0
let v2837 : US0 = US0_0
let v2838 : UH2 = UH2_2(v2837)
let v2839 : US0 = US0_1
let v2840 : UH2 = UH2_2(v2839)
let v2841 : UH2 = UH2_3(v2838, v2840)
let v2842 : UH2 = UH2_5(v2841)
let v2843 : US0 = US0_0
let v2844 : UH2 = UH2_2(v2843)
let v2845 : UH2 = UH2_4(v2842, v2844)
let v2846 : US0 = US0_1
let v2847 : US0 = US0_1
let v2848 : US0 = US0_1
let v2849 : UH0 = UH0_0
let v2850 : UH0 = UH0_1(v2848, v2849)
let v2851 : UH0 = UH0_1(v2847, v2850)
let v2852 : UH0 = UH0_1(v2846, v2851)
let v2853 : UH5 = language_remainders_27(v2845, v2852)
let v2854 : bool = input_list_contains_32(v2836, v2853)
let v2855 : US0 = US0_0
let v2856 : UH2 = UH2_2(v2855)
let v2857 : US0 = US0_1
let v2858 : UH2 = UH2_2(v2857)
let v2859 : UH2 = UH2_3(v2856, v2858)
let v2860 : UH2 = UH2_5(v2859)
let v2861 : US0 = US0_0
let v2862 : UH2 = UH2_2(v2861)
let v2863 : UH2 = UH2_4(v2860, v2862)
let v2864 : US0 = US0_1
let v2865 : US0 = US0_1
let v2866 : US0 = US0_1
let v2867 : UH0 = UH0_0
let v2868 : UH0 = UH0_1(v2866, v2867)
let v2869 : UH0 = UH0_1(v2865, v2868)
let v2870 : UH0 = UH0_1(v2864, v2869)
let v2871 : bool = accepts_2(v2863, v2870)
let v2873 : bool =
    if v2854 then
        v2871
    else
        let v2872 : bool = false = v2871
        v2872
if v2873 then
    ()
else
    failwith<unit> "bit direct-language oracle should agree on rejection"
let v2874 : UH1 = UH1_0
let v2875 : US1 = US1_0
let v2876 : UH3 = UH3_2(v2875)
let v2877 : UH3 = UH3_5(v2876)
let v2878 : US1 = US1_0
let v2879 : US1 = US1_0
let v2880 : US1 = US1_0
let v2881 : UH1 = UH1_0
let v2882 : UH1 = UH1_1(v2880, v2881)
let v2883 : UH1 = UH1_1(v2879, v2882)
let v2884 : UH1 = UH1_1(v2878, v2883)
let v2885 : UH7 = language_remainders_41(v2877, v2884)
let v2886 : bool = input_list_contains_46(v2874, v2885)
let v2887 : US1 = US1_0
let v2888 : UH3 = UH3_2(v2887)
let v2889 : UH3 = UH3_5(v2888)
let v2890 : US1 = US1_0
let v2891 : US1 = US1_0
let v2892 : US1 = US1_0
let v2893 : UH1 = UH1_0
let v2894 : UH1 = UH1_1(v2892, v2893)
let v2895 : UH1 = UH1_1(v2891, v2894)
let v2896 : UH1 = UH1_1(v2890, v2895)
let v2897 : bool = accepts_12(v2889, v2896)
let v2899 : bool =
    if v2886 then
        v2897
    else
        let v2898 : bool = false = v2897
        v2898
if v2899 then
    ()
else
    failwith<unit> "ternary direct-language oracle should agree on acceptance"
let v2900 : UH1 = UH1_0
let v2901 : US1 = US1_0
let v2902 : UH3 = UH3_2(v2901)
let v2903 : UH3 = UH3_5(v2902)
let v2904 : US1 = US1_0
let v2905 : US1 = US1_0
let v2906 : US1 = US1_1
let v2907 : UH1 = UH1_0
let v2908 : UH1 = UH1_1(v2906, v2907)
let v2909 : UH1 = UH1_1(v2905, v2908)
let v2910 : UH1 = UH1_1(v2904, v2909)
let v2911 : UH7 = language_remainders_41(v2903, v2910)
let v2912 : bool = input_list_contains_46(v2900, v2911)
let v2913 : US1 = US1_0
let v2914 : UH3 = UH3_2(v2913)
let v2915 : UH3 = UH3_5(v2914)
let v2916 : US1 = US1_0
let v2917 : US1 = US1_0
let v2918 : US1 = US1_1
let v2919 : UH1 = UH1_0
let v2920 : UH1 = UH1_1(v2918, v2919)
let v2921 : UH1 = UH1_1(v2917, v2920)
let v2922 : UH1 = UH1_1(v2916, v2921)
let v2923 : bool = accepts_12(v2915, v2922)
let v2925 : bool =
    if v2912 then
        v2923
    else
        let v2924 : bool = false = v2923
        v2924
if v2925 then
    ()
else
    failwith<unit> "ternary direct-language oracle should agree on rejection"
let v2926 : UH1 = UH1_0
let v2927 : US1 = US1_0
let v2928 : UH3 = UH3_2(v2927)
let v2929 : US1 = US1_1
let v2930 : UH3 = UH3_2(v2929)
let v2931 : UH3 = UH3_3(v2928, v2930)
let v2932 : UH3 = UH3_5(v2931)
let v2933 : US1 = US1_2
let v2934 : UH3 = UH3_2(v2933)
let v2935 : UH3 = UH3_4(v2932, v2934)
let v2936 : US1 = US1_0
let v2937 : US1 = US1_1
let v2938 : US1 = US1_0
let v2939 : US1 = US1_2
let v2940 : UH1 = UH1_0
let v2941 : UH1 = UH1_1(v2939, v2940)
let v2942 : UH1 = UH1_1(v2938, v2941)
let v2943 : UH1 = UH1_1(v2937, v2942)
let v2944 : UH1 = UH1_1(v2936, v2943)
let v2945 : UH7 = language_remainders_41(v2935, v2944)
let v2946 : bool = input_list_contains_46(v2926, v2945)
let v2947 : US1 = US1_0
let v2948 : UH3 = UH3_2(v2947)
let v2949 : US1 = US1_1
let v2950 : UH3 = UH3_2(v2949)
let v2951 : UH3 = UH3_3(v2948, v2950)
let v2952 : UH3 = UH3_5(v2951)
let v2953 : US1 = US1_2
let v2954 : UH3 = UH3_2(v2953)
let v2955 : UH3 = UH3_4(v2952, v2954)
let v2956 : US1 = US1_0
let v2957 : US1 = US1_1
let v2958 : US1 = US1_0
let v2959 : US1 = US1_2
let v2960 : UH1 = UH1_0
let v2961 : UH1 = UH1_1(v2959, v2960)
let v2962 : UH1 = UH1_1(v2958, v2961)
let v2963 : UH1 = UH1_1(v2957, v2962)
let v2964 : UH1 = UH1_1(v2956, v2963)
let v2965 : bool = accepts_12(v2955, v2964)
let v2967 : bool =
    if v2946 then
        v2965
    else
        let v2966 : bool = false = v2965
        v2966
if v2967 then
    ()
else
    failwith<unit> "ternary suffix direct-language oracle should agree on acceptance"
let v2968 : UH1 = UH1_0
let v2969 : US1 = US1_0
let v2970 : UH3 = UH3_2(v2969)
let v2971 : US1 = US1_1
let v2972 : UH3 = UH3_2(v2971)
let v2973 : UH3 = UH3_3(v2970, v2972)
let v2974 : UH3 = UH3_5(v2973)
let v2975 : US1 = US1_2
let v2976 : UH3 = UH3_2(v2975)
let v2977 : UH3 = UH3_4(v2974, v2976)
let v2978 : US1 = US1_0
let v2979 : US1 = US1_1
let v2980 : US1 = US1_0
let v2981 : US1 = US1_1
let v2982 : UH1 = UH1_0
let v2983 : UH1 = UH1_1(v2981, v2982)
let v2984 : UH1 = UH1_1(v2980, v2983)
let v2985 : UH1 = UH1_1(v2979, v2984)
let v2986 : UH1 = UH1_1(v2978, v2985)
let v2987 : UH7 = language_remainders_41(v2977, v2986)
let v2988 : bool = input_list_contains_46(v2968, v2987)
let v2989 : US1 = US1_0
let v2990 : UH3 = UH3_2(v2989)
let v2991 : US1 = US1_1
let v2992 : UH3 = UH3_2(v2991)
let v2993 : UH3 = UH3_3(v2990, v2992)
let v2994 : UH3 = UH3_5(v2993)
let v2995 : US1 = US1_2
let v2996 : UH3 = UH3_2(v2995)
let v2997 : UH3 = UH3_4(v2994, v2996)
let v2998 : US1 = US1_0
let v2999 : US1 = US1_1
let v3000 : US1 = US1_0
let v3001 : US1 = US1_1
let v3002 : UH1 = UH1_0
let v3003 : UH1 = UH1_1(v3001, v3002)
let v3004 : UH1 = UH1_1(v3000, v3003)
let v3005 : UH1 = UH1_1(v2999, v3004)
let v3006 : UH1 = UH1_1(v2998, v3005)
let v3007 : bool = accepts_12(v2997, v3006)
let v3009 : bool =
    if v2988 then
        v3007
    else
        let v3008 : bool = false = v3007
        v3008
if v3009 then
    ()
else
    failwith<unit> "ternary suffix direct-language oracle should agree on rejection"
let v3010 : UH0 = UH0_0
let v3011 : US0 = US0_0
let v3012 : UH2 = UH2_2(v3011)
let v3013 : UH2 = UH2_5(v3012)
let v3014 : US0 = US0_0
let v3015 : US0 = US0_1
let v3016 : UH0 = UH0_0
let v3017 : UH0 = UH0_1(v3015, v3016)
let v3018 : UH0 = UH0_1(v3014, v3017)
let v3019 : UH5 = language_remainders_27(v3013, v3018)
let v3020 : bool = input_list_contains_32(v3010, v3019)
let v3021 : UH0 = UH0_0
let v3022 : UH2 = UH2_0
let v3023 : US0 = US0_0
let v3024 : US0 = US0_1
let v3025 : UH0 = UH0_0
let v3026 : UH0 = UH0_1(v3024, v3025)
let v3027 : UH0 = UH0_1(v3023, v3026)
let v3028 : UH5 = language_remainders_27(v3022, v3027)
let v3029 : bool = input_list_contains_32(v3021, v3028)
let v3031 : bool =
    if v3020 then
        v3029
    else
        let v3030 : bool = false = v3029
        v3030
if v3031 then
    ()
else
    failwith<unit> "boolean-only normalization observation must be able to miss a bad candidate"
let v3032 : US0 = US0_0
let v3033 : UH2 = UH2_2(v3032)
let v3034 : UH2 = UH2_5(v3033)
let v3035 : US0 = US0_0
let v3036 : US0 = US0_1
let v3037 : UH0 = UH0_0
let v3038 : UH0 = UH0_1(v3036, v3037)
let v3039 : UH0 = UH0_1(v3035, v3038)
let v3040 : UH5 = language_remainders_27(v3034, v3039)
let v3041 : UH2 = UH2_0
let v3042 : US0 = US0_0
let v3043 : US0 = US0_1
let v3044 : UH0 = UH0_0
let v3045 : UH0 = UH0_1(v3043, v3044)
let v3046 : UH0 = UH0_1(v3042, v3045)
let v3047 : UH5 = language_remainders_27(v3041, v3046)
let v3048 : bool = input_list_subset_35(v3040, v3047)
let v3050 : bool =
    if v3048 then
        input_list_subset_35(v3047, v3040)
    else
        false
let v3051 : bool = v3050 = false
if v3051 then
    ()
else
    failwith<unit> "remainder-set normalization law must distinguish a bad candidate hidden by the final boolean"
let v3052 : US0 = US0_0
let v3053 : US0 = US0_1
let v3054 : UH4 = UH4_0
let v3055 : UH4 = UH4_1(v3053, v3054)
let v3056 : UH4 = UH4_1(v3052, v3055)
let v3057 : UH5 = input_singletons_from_symbols_71(v3056)
let v3058 : UH0 = UH0_0
let v3059 : UH5 = UH5_1(v3058, v3057)
let v3060 : US0 = US0_0
let v3061 : US0 = US0_1
let v3062 : UH4 = UH4_0
let v3063 : UH4 = UH4_1(v3061, v3062)
let v3064 : UH4 = UH4_1(v3060, v3063)
let v3065 : US0 = US0_0
let v3066 : US0 = US0_1
let v3067 : UH4 = UH4_0
let v3068 : UH4 = UH4_1(v3066, v3067)
let v3069 : UH4 = UH4_1(v3065, v3068)
let v3070 : UH5 = input_singletons_from_symbols_71(v3069)
let v3071 : UH5 = input_prepend_symbols_to_corpus_72(v3064, v3070)
let v3072 : UH5 = input_list_append_28(v3059, v3071)
let v3073 : US1 = US1_0
let v3074 : US1 = US1_1
let v3075 : US1 = US1_2
let v3076 : UH6 = UH6_0
let v3077 : UH6 = UH6_1(v3075, v3076)
let v3078 : UH6 = UH6_1(v3074, v3077)
let v3079 : UH6 = UH6_1(v3073, v3078)
let v3080 : UH7 = input_singletons_from_symbols_133(v3079)
let v3081 : UH1 = UH1_0
let v3082 : UH7 = UH7_1(v3081, v3080)
let v3083 : US1 = US1_0
let v3084 : US1 = US1_1
let v3085 : US1 = US1_2
let v3086 : UH6 = UH6_0
let v3087 : UH6 = UH6_1(v3085, v3086)
let v3088 : UH6 = UH6_1(v3084, v3087)
let v3089 : UH6 = UH6_1(v3083, v3088)
let v3090 : US1 = US1_0
let v3091 : US1 = US1_1
let v3092 : US1 = US1_2
let v3093 : UH6 = UH6_0
let v3094 : UH6 = UH6_1(v3092, v3093)
let v3095 : UH6 = UH6_1(v3091, v3094)
let v3096 : UH6 = UH6_1(v3090, v3095)
let v3097 : UH7 = input_singletons_from_symbols_133(v3096)
let v3098 : UH7 = input_prepend_symbols_to_corpus_134(v3089, v3097)
let v3099 : UH7 = input_list_append_42(v3082, v3098)
let v3100 : UH2 = UH2_0
let v3101 : UH2 = UH2_1
let v3102 : UH9 = UH9_1(v3101, v315)
let v3103 : UH9 = UH9_1(v3100, v3102)
let v3104 : US0 = US0_0
let v3105 : US0 = US0_1
let v3106 : UH4 = UH4_0
let v3107 : UH4 = UH4_1(v3105, v3106)
let v3108 : UH4 = UH4_1(v3104, v3107)
let v3109 : bool = derivative_language_law_corpus_62(v3103, v3108, v3072)
if v3109 then
    ()
else
    failwith<unit> "direct-language oracle should validate bit derivative law corpus"
let v3110 : US1 = US1_0
let v3111 : UH3 = UH3_2(v3110)
let v3112 : UH3 = UH3_5(v3111)
let v3113 : US1 = US1_0
let v3114 : UH3 = UH3_2(v3113)
let v3115 : US1 = US1_1
let v3116 : UH3 = UH3_2(v3115)
let v3117 : UH3 = UH3_3(v3114, v3116)
let v3118 : UH3 = UH3_5(v3117)
let v3119 : US1 = US1_2
let v3120 : UH3 = UH3_2(v3119)
let v3121 : UH3 = UH3_4(v3118, v3120)
let v3122 : UH10 = UH10_0
let v3123 : UH10 = UH10_1(v3121, v3122)
let v3124 : UH10 = UH10_1(v3112, v3123)
let v3125 : US1 = US1_0
let v3126 : US1 = US1_1
let v3127 : US1 = US1_2
let v3128 : UH6 = UH6_0
let v3129 : UH6 = UH6_1(v3127, v3128)
let v3130 : UH6 = UH6_1(v3126, v3129)
let v3131 : UH6 = UH6_1(v3125, v3130)
let v3132 : bool = derivative_language_law_corpus_65(v3124, v3131, v3099)
if v3132 then
    ()
else
    failwith<unit> "direct-language oracle should validate ternary derivative law corpus"
let v3133 : UH2 = UH2_0
let v3134 : UH2 = UH2_1
let v3135 : US0 = US0_0
let v3136 : UH2 = UH2_2(v3135)
let v3137 : US0 = US0_1
let v3138 : UH2 = UH2_2(v3137)
let v3139 : UH2 = UH2_3(v3136, v3138)
let v3140 : UH2 = UH2_5(v3139)
let v3141 : US0 = US0_0
let v3142 : UH2 = UH2_2(v3141)
let v3143 : UH2 = UH2_4(v3140, v3142)
let v3144 : UH2 = UH2_3(v3134, v3143)
let v3145 : UH2 = UH2_3(v3133, v3144)
let v3146 : US0 = US0_0
let v3147 : US0 = US0_1
let v3148 : UH4 = UH4_0
let v3149 : UH4 = UH4_1(v3147, v3148)
let v3150 : UH4 = UH4_1(v3146, v3149)
let v3151 : bool = derivative_semantic_triangle_symbols_23(v3145, v3150, v3072)
if v3151 then
    ()
else
    failwith<unit> "structural semantic triangle should cover every regex constructor"
let v3152 : US1 = US1_0
let v3153 : UH3 = UH3_2(v3152)
let v3154 : US1 = US1_1
let v3155 : UH3 = UH3_2(v3154)
let v3156 : UH3 = UH3_3(v3153, v3155)
let v3157 : UH3 = UH3_5(v3156)
let v3158 : US1 = US1_2
let v3159 : UH3 = UH3_2(v3158)
let v3160 : UH3 = UH3_4(v3157, v3159)
let v3161 : US1 = US1_0
let v3162 : US1 = US1_1
let v3163 : US1 = US1_2
let v3164 : UH6 = UH6_0
let v3165 : UH6 = UH6_1(v3163, v3164)
let v3166 : UH6 = UH6_1(v3162, v3165)
let v3167 : UH6 = UH6_1(v3161, v3166)
let v3168 : bool = derivative_semantic_triangle_symbols_37(v3160, v3167, v3099)
if v3168 then
    ()
else
    failwith<unit> "structural semantic triangle should hold for ternary composite regex"
let v3169 : US0 = US0_0
let v3170 : UH2 = UH2_2(v3169)
let v3171 : UH2 = UH2_5(v3170)
let v3172 : US0 = US0_0
let v3173 : UH0 = UH0_0
let v3174 : UH0 = UH0_1(v3172, v3173)
let v3175 : UH5 = language_remainders_27(v3171, v3174)
let v3176 : US0 = US0_0
let v3177 : UH2 = UH2_2(v3176)
let v3178 : UH2 = UH2_5(v3177)
let v3179 : US0 = US0_0
let v3180 : UH2 = canonical_derivative_3(v3178, v3179)
let v3181 : UH0 = UH0_0
let v3182 : UH5 = language_remainders_27(v3180, v3181)
let v3183 : bool = input_list_subset_35(v3175, v3182)
let v3185 : bool =
    if v3183 then
        input_list_subset_35(v3182, v3175)
    else
        false
let v3186 : bool = v3185 = false
if v3186 then
    ()
else
    failwith<unit> "raw remainder equality must expose the nullable zero-consumption remainder"
let v3187 : US0 = US0_0
let v3188 : UH2 = UH2_2(v3187)
let v3189 : UH2 = UH2_5(v3188)
let v3190 : US0 = US0_0
let v3191 : UH2 = canonical_derivative_3(v3189, v3190)
let v3192 : US0 = US0_0
let v3193 : UH0 = UH0_0
let v3194 : UH0 = UH0_1(v3192, v3193)
let v3195 : US0 = US0_0
let v3196 : UH2 = UH2_2(v3195)
let v3197 : UH2 = UH2_5(v3196)
let v3198 : US0 = US0_0
let v3199 : UH0 = UH0_0
let v3200 : UH0 = UH0_1(v3198, v3199)
let v3201 : UH5 = language_remainders_27(v3197, v3200)
let v3202 : UH5 = input_list_remove_34(v3194, v3201)
let v3203 : UH0 = UH0_0
let v3204 : UH5 = language_remainders_27(v3191, v3203)
let v3205 : bool = input_list_subset_35(v3202, v3204)
let v3207 : bool =
    if v3205 then
        input_list_subset_35(v3204, v3202)
    else
        false
if v3207 then
    ()
else
    failwith<unit> "derivative remainder law should remove only the zero-consumption remainder"
let v3208 : UH2 = UH2_0
let v3209 : US0 = US0_0
let v3210 : UH2 = canonical_derivative_3(v3208, v3209)
let v3211 : US0 = US0_0
let v3212 : UH0 = UH0_0
let v3213 : UH0 = UH0_1(v3211, v3212)
let v3214 : UH2 = UH2_0
let v3215 : US0 = US0_0
let v3216 : UH0 = UH0_0
let v3217 : UH0 = UH0_1(v3215, v3216)
let v3218 : UH5 = language_remainders_27(v3214, v3217)
let v3219 : UH5 = input_list_remove_34(v3213, v3218)
let v3220 : UH0 = UH0_0
let v3221 : UH5 = language_remainders_27(v3210, v3220)
let v3222 : bool = input_list_subset_35(v3219, v3221)
let v3224 : bool =
    if v3222 then
        input_list_subset_35(v3221, v3219)
    else
        false
if v3224 then
    ()
else
    failwith<unit> "empty derivative step should preserve language"
let v3225 : UH2 = UH2_1
let v3226 : US0 = US0_0
let v3227 : UH2 = canonical_derivative_3(v3225, v3226)
let v3228 : US0 = US0_0
let v3229 : UH0 = UH0_0
let v3230 : UH0 = UH0_1(v3228, v3229)
let v3231 : UH2 = UH2_1
let v3232 : US0 = US0_0
let v3233 : UH0 = UH0_0
let v3234 : UH0 = UH0_1(v3232, v3233)
let v3235 : UH5 = language_remainders_27(v3231, v3234)
let v3236 : UH5 = input_list_remove_34(v3230, v3235)
let v3237 : UH0 = UH0_0
let v3238 : UH5 = language_remainders_27(v3227, v3237)
let v3239 : bool = input_list_subset_35(v3236, v3238)
let v3241 : bool =
    if v3239 then
        input_list_subset_35(v3238, v3236)
    else
        false
if v3241 then
    ()
else
    failwith<unit> "epsilon derivative step should preserve language"
let v3242 : US0 = US0_0
let v3243 : UH2 = UH2_2(v3242)
let v3244 : US0 = US0_0
let v3245 : UH2 = canonical_derivative_3(v3243, v3244)
let v3246 : US0 = US0_0
let v3247 : US0 = US0_1
let v3248 : US0 = US0_0
let v3249 : UH0 = UH0_0
let v3250 : UH0 = UH0_1(v3248, v3249)
let v3251 : UH0 = UH0_1(v3247, v3250)
let v3252 : UH0 = UH0_1(v3246, v3251)
let v3253 : US0 = US0_0
let v3254 : UH2 = UH2_2(v3253)
let v3255 : US0 = US0_0
let v3256 : US0 = US0_1
let v3257 : US0 = US0_0
let v3258 : UH0 = UH0_0
let v3259 : UH0 = UH0_1(v3257, v3258)
let v3260 : UH0 = UH0_1(v3256, v3259)
let v3261 : UH0 = UH0_1(v3255, v3260)
let v3262 : UH5 = language_remainders_27(v3254, v3261)
let v3263 : UH5 = input_list_remove_34(v3252, v3262)
let v3264 : US0 = US0_1
let v3265 : US0 = US0_0
let v3266 : UH0 = UH0_0
let v3267 : UH0 = UH0_1(v3265, v3266)
let v3268 : UH0 = UH0_1(v3264, v3267)
let v3269 : UH5 = language_remainders_27(v3245, v3268)
let v3270 : bool = input_list_subset_35(v3263, v3269)
let v3272 : bool =
    if v3270 then
        input_list_subset_35(v3269, v3263)
    else
        false
if v3272 then
    ()
else
    failwith<unit> "matching-char derivative step should preserve language"
let v3273 : US0 = US0_0
let v3274 : UH2 = UH2_2(v3273)
let v3275 : US0 = US0_1
let v3276 : UH2 = canonical_derivative_3(v3274, v3275)
let v3277 : US0 = US0_1
let v3278 : US0 = US0_1
let v3279 : US0 = US0_0
let v3280 : UH0 = UH0_0
let v3281 : UH0 = UH0_1(v3279, v3280)
let v3282 : UH0 = UH0_1(v3278, v3281)
let v3283 : UH0 = UH0_1(v3277, v3282)
let v3284 : US0 = US0_0
let v3285 : UH2 = UH2_2(v3284)
let v3286 : US0 = US0_1
let v3287 : US0 = US0_1
let v3288 : US0 = US0_0
let v3289 : UH0 = UH0_0
let v3290 : UH0 = UH0_1(v3288, v3289)
let v3291 : UH0 = UH0_1(v3287, v3290)
let v3292 : UH0 = UH0_1(v3286, v3291)
let v3293 : UH5 = language_remainders_27(v3285, v3292)
let v3294 : UH5 = input_list_remove_34(v3283, v3293)
let v3295 : US0 = US0_1
let v3296 : US0 = US0_0
let v3297 : UH0 = UH0_0
let v3298 : UH0 = UH0_1(v3296, v3297)
let v3299 : UH0 = UH0_1(v3295, v3298)
let v3300 : UH5 = language_remainders_27(v3276, v3299)
let v3301 : bool = input_list_subset_35(v3294, v3300)
let v3303 : bool =
    if v3301 then
        input_list_subset_35(v3300, v3294)
    else
        false
if v3303 then
    ()
else
    failwith<unit> "mismatching-char derivative step should preserve language"
let v3304 : US0 = US0_0
let v3305 : UH2 = UH2_2(v3304)
let v3306 : US0 = US0_1
let v3307 : UH2 = UH2_2(v3306)
let v3308 : UH2 = UH2_3(v3305, v3307)
let v3309 : US0 = US0_1
let v3310 : UH2 = canonical_derivative_3(v3308, v3309)
let v3311 : US0 = US0_1
let v3312 : US0 = US0_1
let v3313 : US0 = US0_0
let v3314 : UH0 = UH0_0
let v3315 : UH0 = UH0_1(v3313, v3314)
let v3316 : UH0 = UH0_1(v3312, v3315)
let v3317 : UH0 = UH0_1(v3311, v3316)
let v3318 : US0 = US0_0
let v3319 : UH2 = UH2_2(v3318)
let v3320 : US0 = US0_1
let v3321 : UH2 = UH2_2(v3320)
let v3322 : UH2 = UH2_3(v3319, v3321)
let v3323 : US0 = US0_1
let v3324 : US0 = US0_1
let v3325 : US0 = US0_0
let v3326 : UH0 = UH0_0
let v3327 : UH0 = UH0_1(v3325, v3326)
let v3328 : UH0 = UH0_1(v3324, v3327)
let v3329 : UH0 = UH0_1(v3323, v3328)
let v3330 : UH5 = language_remainders_27(v3322, v3329)
let v3331 : UH5 = input_list_remove_34(v3317, v3330)
let v3332 : US0 = US0_1
let v3333 : US0 = US0_0
let v3334 : UH0 = UH0_0
let v3335 : UH0 = UH0_1(v3333, v3334)
let v3336 : UH0 = UH0_1(v3332, v3335)
let v3337 : UH5 = language_remainders_27(v3310, v3336)
let v3338 : bool = input_list_subset_35(v3331, v3337)
let v3340 : bool =
    if v3338 then
        input_list_subset_35(v3337, v3331)
    else
        false
if v3340 then
    ()
else
    failwith<unit> "alternative derivative step should preserve language"
let v3341 : US0 = US0_0
let v3342 : UH2 = UH2_2(v3341)
let v3343 : US0 = US0_1
let v3344 : UH2 = UH2_2(v3343)
let v3345 : UH2 = UH2_4(v3342, v3344)
let v3346 : US0 = US0_0
let v3347 : UH2 = canonical_derivative_3(v3345, v3346)
let v3348 : US0 = US0_0
let v3349 : US0 = US0_1
let v3350 : US0 = US0_0
let v3351 : UH0 = UH0_0
let v3352 : UH0 = UH0_1(v3350, v3351)
let v3353 : UH0 = UH0_1(v3349, v3352)
let v3354 : UH0 = UH0_1(v3348, v3353)
let v3355 : US0 = US0_0
let v3356 : UH2 = UH2_2(v3355)
let v3357 : US0 = US0_1
let v3358 : UH2 = UH2_2(v3357)
let v3359 : UH2 = UH2_4(v3356, v3358)
let v3360 : US0 = US0_0
let v3361 : US0 = US0_1
let v3362 : US0 = US0_0
let v3363 : UH0 = UH0_0
let v3364 : UH0 = UH0_1(v3362, v3363)
let v3365 : UH0 = UH0_1(v3361, v3364)
let v3366 : UH0 = UH0_1(v3360, v3365)
let v3367 : UH5 = language_remainders_27(v3359, v3366)
let v3368 : UH5 = input_list_remove_34(v3354, v3367)
let v3369 : US0 = US0_1
let v3370 : US0 = US0_0
let v3371 : UH0 = UH0_0
let v3372 : UH0 = UH0_1(v3370, v3371)
let v3373 : UH0 = UH0_1(v3369, v3372)
let v3374 : UH5 = language_remainders_27(v3347, v3373)
let v3375 : bool = input_list_subset_35(v3368, v3374)
let v3377 : bool =
    if v3375 then
        input_list_subset_35(v3374, v3368)
    else
        false
if v3377 then
    ()
else
    failwith<unit> "nonnullable concatenation derivative step should preserve language"
let v3378 : UH2 = UH2_1
let v3379 : US0 = US0_1
let v3380 : UH2 = UH2_2(v3379)
let v3381 : UH2 = UH2_4(v3378, v3380)
let v3382 : US0 = US0_1
let v3383 : UH2 = canonical_derivative_3(v3381, v3382)
let v3384 : US0 = US0_1
let v3385 : US0 = US0_1
let v3386 : US0 = US0_0
let v3387 : UH0 = UH0_0
let v3388 : UH0 = UH0_1(v3386, v3387)
let v3389 : UH0 = UH0_1(v3385, v3388)
let v3390 : UH0 = UH0_1(v3384, v3389)
let v3391 : UH2 = UH2_1
let v3392 : US0 = US0_1
let v3393 : UH2 = UH2_2(v3392)
let v3394 : UH2 = UH2_4(v3391, v3393)
let v3395 : US0 = US0_1
let v3396 : US0 = US0_1
let v3397 : US0 = US0_0
let v3398 : UH0 = UH0_0
let v3399 : UH0 = UH0_1(v3397, v3398)
let v3400 : UH0 = UH0_1(v3396, v3399)
let v3401 : UH0 = UH0_1(v3395, v3400)
let v3402 : UH5 = language_remainders_27(v3394, v3401)
let v3403 : UH5 = input_list_remove_34(v3390, v3402)
let v3404 : US0 = US0_1
let v3405 : US0 = US0_0
let v3406 : UH0 = UH0_0
let v3407 : UH0 = UH0_1(v3405, v3406)
let v3408 : UH0 = UH0_1(v3404, v3407)
let v3409 : UH5 = language_remainders_27(v3383, v3408)
let v3410 : bool = input_list_subset_35(v3403, v3409)
let v3412 : bool =
    if v3410 then
        input_list_subset_35(v3409, v3403)
    else
        false
if v3412 then
    ()
else
    failwith<unit> "nullable concatenation derivative step should preserve language"
let v3413 : US0 = US0_0
let v3414 : UH2 = UH2_2(v3413)
let v3415 : UH2 = UH2_5(v3414)
let v3416 : US0 = US0_0
let v3417 : UH2 = canonical_derivative_3(v3415, v3416)
let v3418 : US0 = US0_0
let v3419 : US0 = US0_1
let v3420 : US0 = US0_0
let v3421 : UH0 = UH0_0
let v3422 : UH0 = UH0_1(v3420, v3421)
let v3423 : UH0 = UH0_1(v3419, v3422)
let v3424 : UH0 = UH0_1(v3418, v3423)
let v3425 : US0 = US0_0
let v3426 : UH2 = UH2_2(v3425)
let v3427 : UH2 = UH2_5(v3426)
let v3428 : US0 = US0_0
let v3429 : US0 = US0_1
let v3430 : US0 = US0_0
let v3431 : UH0 = UH0_0
let v3432 : UH0 = UH0_1(v3430, v3431)
let v3433 : UH0 = UH0_1(v3429, v3432)
let v3434 : UH0 = UH0_1(v3428, v3433)
let v3435 : UH5 = language_remainders_27(v3427, v3434)
let v3436 : UH5 = input_list_remove_34(v3424, v3435)
let v3437 : US0 = US0_1
let v3438 : US0 = US0_0
let v3439 : UH0 = UH0_0
let v3440 : UH0 = UH0_1(v3438, v3439)
let v3441 : UH0 = UH0_1(v3437, v3440)
let v3442 : UH5 = language_remainders_27(v3417, v3441)
let v3443 : bool = input_list_subset_35(v3436, v3442)
let v3445 : bool =
    if v3443 then
        input_list_subset_35(v3442, v3436)
    else
        false
if v3445 then
    ()
else
    failwith<unit> "star derivative step should preserve language"
let v3446 : US0 = US0_0
let v3447 : UH2 = UH2_2(v3446)
let v3448 : US0 = US0_1
let v3449 : UH2 = UH2_2(v3448)
let v3450 : UH2 = UH2_3(v3447, v3449)
let v3451 : UH2 = UH2_5(v3450)
let v3452 : US0 = US0_0
let v3453 : UH2 = UH2_2(v3452)
let v3454 : UH2 = UH2_4(v3451, v3453)
let v3455 : US0 = US0_1
let v3456 : UH2 = canonical_derivative_3(v3454, v3455)
let v3457 : US0 = US0_1
let v3458 : US0 = US0_1
let v3459 : US0 = US0_0
let v3460 : UH0 = UH0_0
let v3461 : UH0 = UH0_1(v3459, v3460)
let v3462 : UH0 = UH0_1(v3458, v3461)
let v3463 : UH0 = UH0_1(v3457, v3462)
let v3464 : US0 = US0_0
let v3465 : UH2 = UH2_2(v3464)
let v3466 : US0 = US0_1
let v3467 : UH2 = UH2_2(v3466)
let v3468 : UH2 = UH2_3(v3465, v3467)
let v3469 : UH2 = UH2_5(v3468)
let v3470 : US0 = US0_0
let v3471 : UH2 = UH2_2(v3470)
let v3472 : UH2 = UH2_4(v3469, v3471)
let v3473 : US0 = US0_1
let v3474 : US0 = US0_1
let v3475 : US0 = US0_0
let v3476 : UH0 = UH0_0
let v3477 : UH0 = UH0_1(v3475, v3476)
let v3478 : UH0 = UH0_1(v3474, v3477)
let v3479 : UH0 = UH0_1(v3473, v3478)
let v3480 : UH5 = language_remainders_27(v3472, v3479)
let v3481 : UH5 = input_list_remove_34(v3463, v3480)
let v3482 : US0 = US0_1
let v3483 : US0 = US0_0
let v3484 : UH0 = UH0_0
let v3485 : UH0 = UH0_1(v3483, v3484)
let v3486 : UH0 = UH0_1(v3482, v3485)
let v3487 : UH5 = language_remainders_27(v3456, v3486)
let v3488 : bool = input_list_subset_35(v3481, v3487)
let v3490 : bool =
    if v3488 then
        input_list_subset_35(v3487, v3481)
    else
        false
if v3490 then
    ()
else
    failwith<unit> "composite one derivative step should preserve language"
let v3491 : US0 = US0_0
let v3492 : UH2 = UH2_2(v3491)
let v3493 : US0 = US0_1
let v3494 : UH2 = UH2_2(v3493)
let v3495 : UH2 = UH2_3(v3492, v3494)
let v3496 : UH2 = UH2_5(v3495)
let v3497 : US0 = US0_0
let v3498 : UH2 = UH2_2(v3497)
let v3499 : UH2 = UH2_4(v3496, v3498)
let v3500 : US0 = US0_0
let v3501 : UH2 = canonical_derivative_3(v3499, v3500)
let v3502 : US0 = US0_0
let v3503 : US0 = US0_1
let v3504 : US0 = US0_0
let v3505 : UH0 = UH0_0
let v3506 : UH0 = UH0_1(v3504, v3505)
let v3507 : UH0 = UH0_1(v3503, v3506)
let v3508 : UH0 = UH0_1(v3502, v3507)
let v3509 : US0 = US0_0
let v3510 : UH2 = UH2_2(v3509)
let v3511 : US0 = US0_1
let v3512 : UH2 = UH2_2(v3511)
let v3513 : UH2 = UH2_3(v3510, v3512)
let v3514 : UH2 = UH2_5(v3513)
let v3515 : US0 = US0_0
let v3516 : UH2 = UH2_2(v3515)
let v3517 : UH2 = UH2_4(v3514, v3516)
let v3518 : US0 = US0_0
let v3519 : US0 = US0_1
let v3520 : US0 = US0_0
let v3521 : UH0 = UH0_0
let v3522 : UH0 = UH0_1(v3520, v3521)
let v3523 : UH0 = UH0_1(v3519, v3522)
let v3524 : UH0 = UH0_1(v3518, v3523)
let v3525 : UH5 = language_remainders_27(v3517, v3524)
let v3526 : UH5 = input_list_remove_34(v3508, v3525)
let v3527 : US0 = US0_1
let v3528 : US0 = US0_0
let v3529 : UH0 = UH0_0
let v3530 : UH0 = UH0_1(v3528, v3529)
let v3531 : UH0 = UH0_1(v3527, v3530)
let v3532 : UH5 = language_remainders_27(v3501, v3531)
let v3533 : bool = input_list_subset_35(v3526, v3532)
let v3535 : bool =
    if v3533 then
        input_list_subset_35(v3532, v3526)
    else
        false
if v3535 then
    ()
else
    failwith<unit> "composite zero derivative step should preserve language"
let v3536 : US1 = US1_0
let v3537 : UH3 = UH3_2(v3536)
let v3538 : UH3 = UH3_5(v3537)
let v3539 : US1 = US1_0
let v3540 : UH3 = canonical_derivative_13(v3538, v3539)
let v3541 : US1 = US1_0
let v3542 : US1 = US1_0
let v3543 : US1 = US1_0
let v3544 : UH1 = UH1_0
let v3545 : UH1 = UH1_1(v3543, v3544)
let v3546 : UH1 = UH1_1(v3542, v3545)
let v3547 : UH1 = UH1_1(v3541, v3546)
let v3548 : US1 = US1_0
let v3549 : UH3 = UH3_2(v3548)
let v3550 : UH3 = UH3_5(v3549)
let v3551 : US1 = US1_0
let v3552 : US1 = US1_0
let v3553 : US1 = US1_0
let v3554 : UH1 = UH1_0
let v3555 : UH1 = UH1_1(v3553, v3554)
let v3556 : UH1 = UH1_1(v3552, v3555)
let v3557 : UH1 = UH1_1(v3551, v3556)
let v3558 : UH7 = language_remainders_41(v3550, v3557)
let v3559 : UH7 = input_list_remove_48(v3547, v3558)
let v3560 : US1 = US1_0
let v3561 : US1 = US1_0
let v3562 : UH1 = UH1_0
let v3563 : UH1 = UH1_1(v3561, v3562)
let v3564 : UH1 = UH1_1(v3560, v3563)
let v3565 : UH7 = language_remainders_41(v3540, v3564)
let v3566 : bool = input_list_subset_49(v3559, v3565)
let v3568 : bool =
    if v3566 then
        input_list_subset_49(v3565, v3559)
    else
        false
if v3568 then
    ()
else
    failwith<unit> "ternary derivative step should preserve language"
let v3569 : US0 = US0_0
let v3570 : UH2 = UH2_2(v3569)
let v3571 : UH2 = UH2_5(v3570)
let v3572 : US0 = US0_1
let v3573 : UH2 = UH2_2(v3572)
let v3574 : UH2 = UH2_4(v3571, v3573)
let v3575 : US0 = US0_0
let v3576 : UH2 = canonical_derivative_3(v3574, v3575)
let v3577 : US0 = US0_0
let v3578 : US0 = US0_1
let v3579 : US0 = US0_0
let v3580 : UH0 = UH0_0
let v3581 : UH0 = UH0_1(v3579, v3580)
let v3582 : UH0 = UH0_1(v3578, v3581)
let v3583 : UH0 = UH0_1(v3577, v3582)
let v3584 : US0 = US0_0
let v3585 : UH2 = UH2_2(v3584)
let v3586 : UH2 = UH2_5(v3585)
let v3587 : US0 = US0_1
let v3588 : UH2 = UH2_2(v3587)
let v3589 : UH2 = UH2_4(v3586, v3588)
let v3590 : US0 = US0_0
let v3591 : US0 = US0_1
let v3592 : US0 = US0_0
let v3593 : UH0 = UH0_0
let v3594 : UH0 = UH0_1(v3592, v3593)
let v3595 : UH0 = UH0_1(v3591, v3594)
let v3596 : UH0 = UH0_1(v3590, v3595)
let v3597 : UH5 = language_remainders_27(v3589, v3596)
let v3598 : UH5 = input_list_remove_34(v3583, v3597)
let v3599 : US0 = US0_1
let v3600 : US0 = US0_0
let v3601 : UH0 = UH0_0
let v3602 : UH0 = UH0_1(v3600, v3601)
let v3603 : UH0 = UH0_1(v3599, v3602)
let v3604 : UH5 = language_remainders_27(v3576, v3603)
let v3605 : bool = input_list_subset_35(v3598, v3604)
let v3607 : bool =
    if v3605 then
        input_list_subset_35(v3604, v3598)
    else
        false
if v3607 then
    ()
else
    failwith<unit> "star-concatenation derivative step should preserve language"
let v3608 : string = "inventory-indexed-model-green"
v3608
