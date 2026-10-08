type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0
    | UH0_1
    | UH0_2 of US0
    | UH0_3 of UH0 * UH0
    | UH0_4 of UH0 * UH0
    | UH0_5 of UH0
and [<Struct>] US1 =
    | US1_0
    | US1_1
and UH1 =
    | UH1_0 of US0
    | UH1_1 of US0
    | UH1_2 of US0 * US0
    | UH1_3 of US0 * UH1 * UH1
    | UH1_4 of US0 * US1 * UH1 * UH1
    | UH1_5 of US0 * UH1
and [<Struct>] US2 =
    | US2_0
    | US2_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US3
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and UH3 =
    | UH3_0 of US3
    | UH3_1 of US3
    | UH3_2 of US3 * US3
    | UH3_3 of US3 * UH3 * UH3
    | UH3_4 of US3 * US1 * UH3 * UH3
    | UH3_5 of US3 * UH3
and [<Struct>] US4 =
    | US4_0
    | US4_1
    | US4_2
and UH4 =
    | UH4_0
    | UH4_1 of US0 * UH4
and UH6 =
    | UH6_0
    | UH6_1 of US0 * UH6
and UH5 =
    | UH5_0
    | UH5_1 of UH6 * UH5
and UH7 =
    | UH7_0
    | UH7_1 of US3 * UH7
and UH9 =
    | UH9_0
    | UH9_1 of US3 * UH9
and UH8 =
    | UH8_0
    | UH8_1 of UH9 * UH8
let rec nullable_1 (v0 : UH0) : US2 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
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
    | UH0_4(v16, v17) -> (* RegexCat *)
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
    | UH0_2(v3) -> (* RegexChar *)
        US2_1
    | UH0_0 -> (* RegexEmpty *)
        US2_1
    | UH0_1 -> (* RegexEpsilon *)
        US2_0
    | UH0_5(v25) -> (* RegexStar *)
        US2_0
and derivative_equation_proof_make_0 (v0 : UH0, v1 : US0) : UH1 =
    match v0 with
    | UH0_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH1 = derivative_equation_proof_make_0(v6, v1)
        let v9 : UH1 = derivative_equation_proof_make_0(v7, v1)
        UH1_3(v1, v8, v9)
    | UH0_4(v11, v12) -> (* RegexCat *)
        let v13 : US2 = nullable_1(v11)
        let v17 : US1 =
            match v13 with
            | US2_1 -> (* NonNullable *)
                US1_1
            | US2_0 -> (* Nullable *)
                US1_0
        let v18 : UH1 = derivative_equation_proof_make_0(v11, v1)
        let v19 : UH1 = derivative_equation_proof_make_0(v12, v1)
        UH1_4(v1, v17, v18, v19)
    | UH0_2(v4) -> (* RegexChar *)
        UH1_2(v4, v1)
    | UH0_0 -> (* RegexEmpty *)
        UH1_0(v1)
    | UH0_1 -> (* RegexEpsilon *)
        UH1_1(v1)
    | UH0_5(v21) -> (* RegexStar *)
        let v22 : UH1 = derivative_equation_proof_make_0(v21, v1)
        UH1_5(v1, v22)
and nullable_3 (v0 : UH2) : US2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_3(v5)
        let v8 : US2 = nullable_3(v6)
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
        let v18 : US2 = nullable_3(v16)
        let v19 : US2 = nullable_3(v17)
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
and derivative_equation_proof_make_2 (v0 : UH2, v1 : US3) : UH3 =
    match v0 with
    | UH2_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH3 = derivative_equation_proof_make_2(v6, v1)
        let v9 : UH3 = derivative_equation_proof_make_2(v7, v1)
        UH3_3(v1, v8, v9)
    | UH2_4(v11, v12) -> (* RegexCat *)
        let v13 : US2 = nullable_3(v11)
        let v17 : US1 =
            match v13 with
            | US2_1 -> (* NonNullable *)
                US1_1
            | US2_0 -> (* Nullable *)
                US1_0
        let v18 : UH3 = derivative_equation_proof_make_2(v11, v1)
        let v19 : UH3 = derivative_equation_proof_make_2(v12, v1)
        UH3_4(v1, v17, v18, v19)
    | UH2_2(v4) -> (* RegexChar *)
        UH3_2(v4, v1)
    | UH2_0 -> (* RegexEmpty *)
        UH3_0(v1)
    | UH2_1 -> (* RegexEpsilon *)
        UH3_1(v1)
    | UH2_5(v21) -> (* RegexStar *)
        let v22 : UH3 = derivative_equation_proof_make_2(v21, v1)
        UH3_5(v1, v22)
and derivative_equation_proof_source_5 (v0 : UH1) : UH0 =
    match v0 with
    | UH1_3(v8, v9, v10) -> (* DerivativeEquationProofAlt *)
        let v11 : UH0 = derivative_equation_proof_source_5(v9)
        let v12 : UH0 = derivative_equation_proof_source_5(v10)
        UH0_3(v11, v12)
    | UH1_4(v14, v15, v16, v17) -> (* DerivativeEquationProofCat *)
        let v18 : UH0 = derivative_equation_proof_source_5(v16)
        let v19 : UH0 = derivative_equation_proof_source_5(v17)
        UH0_4(v18, v19)
    | UH1_2(v5, v6) -> (* DerivativeEquationProofChar *)
        UH0_2(v5)
    | UH1_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH0_0
    | UH1_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH0_1
    | UH1_5(v21, v22) -> (* DerivativeEquationProofStar *)
        let v23 : UH0 = derivative_equation_proof_source_5(v22)
        UH0_5(v23)
and derivative_equation_proof_symbol_6 (v0 : UH1) : US0 =
    match v0 with
    | UH1_3(v5, v6, v7) -> (* DerivativeEquationProofAlt *)
        v5
    | UH1_4(v8, v9, v10, v11) -> (* DerivativeEquationProofCat *)
        v8
    | UH1_2(v3, v4) -> (* DerivativeEquationProofChar *)
        v4
    | UH1_0(v1) -> (* DerivativeEquationProofEmpty *)
        v1
    | UH1_1(v2) -> (* DerivativeEquationProofEpsilon *)
        v2
    | UH1_5(v12, v13) -> (* DerivativeEquationProofStar *)
        v12
and derivative_equation_proof_candidate_7 (v0 : UH1) : UH0 =
    match v0 with
    | UH1_3(v21, v22, v23) -> (* DerivativeEquationProofAlt *)
        let v24 : UH0 = derivative_equation_proof_candidate_7(v22)
        let v25 : UH0 = derivative_equation_proof_candidate_7(v23)
        UH0_3(v24, v25)
    | UH1_4(v27, v28, v29, v30) -> (* DerivativeEquationProofCat *)
        let v31 : UH0 = derivative_equation_proof_candidate_7(v29)
        let v32 : UH0 = derivative_equation_proof_candidate_7(v30)
        let v33 : UH0 = derivative_equation_proof_source_5(v30)
        match v28 with
        | US1_1 -> (* EquationCatNonNullable *)
            UH0_4(v31, v33)
        | US1_0 -> (* EquationCatNullable *)
            let v34 : UH0 = UH0_4(v31, v33)
            UH0_3(v34, v32)
    | UH1_2(v5, v6) -> (* DerivativeEquationProofChar *)
        let v16 : US4 =
            match v5 with
            | US0_1 -> (* BitOne *)
                match v6 with
                | US0_1 -> (* BitOne *)
                    US4_1
                | US0_0 -> (* BitZero *)
                    US4_2
            | US0_0 -> (* BitZero *)
                match v6 with
                | US0_1 -> (* BitOne *)
                    US4_0
                | US0_0 -> (* BitZero *)
                    US4_1
        let v17 : bool =
            match v16 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v17 then
            UH0_1
        else
            UH0_0
    | UH1_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH0_0
    | UH1_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH0_0
    | UH1_5(v39, v40) -> (* DerivativeEquationProofStar *)
        let v41 : UH0 = derivative_equation_proof_candidate_7(v40)
        let v42 : UH0 = derivative_equation_proof_source_5(v40)
        let v43 : UH0 = UH0_5(v42)
        UH0_4(v41, v43)
and regex_compare_12 (v0 : UH0, v1 : UH0) : US4 =
    match v0 with
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US4 = regex_compare_12(v53, v55)
            match v57 with
            | US4_1 -> (* SymbolSame *)
                regex_compare_12(v54, v56)
            | _ ->
                v57
        | _ ->
            US4_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US4 = regex_compare_12(v28, v34)
            match v36 with
            | US4_1 -> (* SymbolSame *)
                regex_compare_12(v29, v35)
            | _ ->
                v36
        | UH0_2(v32) -> (* RegexChar *)
            US4_2
        | UH0_0 -> (* RegexEmpty *)
            US4_2
        | UH0_1 -> (* RegexEpsilon *)
            US4_2
        | _ ->
            US4_0
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US4_1
                | US0_0 -> (* BitZero *)
                    US4_2
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US4_0
                | US0_0 -> (* BitZero *)
                    US4_1
        | UH0_0 -> (* RegexEmpty *)
            US4_2
        | UH0_1 -> (* RegexEpsilon *)
            US4_2
        | _ ->
            US4_0
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US4_1
        | _ ->
            US4_0
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US4_2
        | UH0_1 -> (* RegexEpsilon *)
            US4_1
        | _ ->
            US4_0
    | UH0_5(v44) -> (* RegexStar *)
        match v1 with
        | UH0_3(v45, v46) -> (* RegexAlt *)
            US4_0
        | UH0_5(v48) -> (* RegexStar *)
            regex_compare_12(v44, v48)
        | _ ->
            US4_2
and alt_insert_sorted_11 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = regex_compare_12(v0, v2)
        match v4 with
        | US4_2 -> (* SymbolGreater *)
            let v6 : UH0 = alt_insert_sorted_11(v0, v3)
            UH0_3(v2, v6)
        | US4_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US4_1 -> (* SymbolSame *)
            v1
    | UH0_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US4 = regex_compare_12(v0, v1)
        match v11 with
        | US4_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
        | US4_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US4_1 -> (* SymbolSame *)
            v1
and make_alt_10 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = alt_insert_sorted_11(v2, v1)
        make_alt_10(v3, v4)
    | UH0_0 -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_11(v0, v1)
and regex_equal_14 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_14(v18, v20)
            if v22 then
                regex_equal_14(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_14(v26, v28)
            if v30 then
                regex_equal_14(v27, v29)
            else
                false
        | _ ->
            false
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
            let v15 : US4 =
                match v4 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US4_1
                    | US0_0 -> (* BitZero *)
                        US4_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US4_0
                    | US0_0 -> (* BitZero *)
                        US4_1
            match v15 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH0_5(v34) -> (* RegexStar *)
        match v1 with
        | UH0_5(v35) -> (* RegexStar *)
            regex_equal_14(v34, v35)
        | _ ->
            false
and make_cat_13 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | _ ->
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            UH0_0
        | _ ->
            match v0 with
            | UH0_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH0_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH0_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH0 = make_cat_13(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_14(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and make_star_15 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and normalize_9 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = normalize_9(v5)
        let v8 : UH0 = normalize_9(v6)
        make_alt_10(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = normalize_9(v10)
        let v13 : UH0 = normalize_9(v11)
        make_cat_13(v12, v13)
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = normalize_9(v15)
        make_star_15(v16)
and derivative_16 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_16(v19, v1)
        let v22 : UH0 = derivative_16(v20, v1)
        make_alt_10(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_1(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = derivative_16(v24, v1)
            make_cat_13(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = derivative_16(v24, v1)
            let v28 : UH0 = make_cat_13(v27, v25)
            let v29 : UH0 = derivative_16(v25, v1)
            make_alt_10(v28, v29)
    | UH0_2(v4) -> (* RegexChar *)
        let v14 : US4 =
            match v4 with
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US4_1
                | US0_0 -> (* BitZero *)
                    US4_2
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US4_0
                | US0_0 -> (* BitZero *)
                    US4_1
        let v15 : bool =
            match v14 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH0_1
        else
            UH0_0
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH0 = derivative_16(v35, v1)
        let v37 : UH0 = make_star_15(v35)
        make_cat_13(v36, v37)
and canonical_derivative_8 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_9(v0)
    let v3 : UH0 = derivative_16(v2, v1)
    normalize_9(v3)
and reference_derivative_17 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = reference_derivative_17(v19, v1)
        let v22 : UH0 = reference_derivative_17(v20, v1)
        UH0_3(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_1(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = reference_derivative_17(v24, v1)
            UH0_4(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = reference_derivative_17(v24, v1)
            let v28 : UH0 = reference_derivative_17(v25, v1)
            let v29 : UH0 = UH0_4(v27, v25)
            UH0_3(v29, v28)
    | UH0_2(v4) -> (* RegexChar *)
        let v14 : US4 =
            match v4 with
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US4_1
                | US0_0 -> (* BitZero *)
                    US4_2
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US4_0
                | US0_0 -> (* BitZero *)
                    US4_1
        let v15 : bool =
            match v14 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH0_1
        else
            UH0_0
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH0 = reference_derivative_17(v35, v1)
        let v37 : UH0 = UH0_5(v35)
        UH0_4(v36, v37)
and derivative_equation_proof_valid_4 (v0 : UH1) : bool =
    let v1 : UH0 = derivative_equation_proof_source_5(v0)
    let v2 : US0 = derivative_equation_proof_symbol_6(v0)
    let v3 : UH0 = derivative_equation_proof_candidate_7(v0)
    let v4 : UH0 = canonical_derivative_8(v1, v2)
    let v5 : UH0 = reference_derivative_17(v1, v2)
    let v6 : UH0 = normalize_9(v5)
    let v7 : UH0 = normalize_9(v3)
    let v8 : bool = regex_equal_14(v7, v4)
    let v11 : bool =
        if v8 then
            let v9 : UH0 = normalize_9(v3)
            regex_equal_14(v9, v6)
        else
            false
    let v18 : bool =
        if v11 then
            let v12 : UH0 = normalize_9(v1)
            let v13 : UH0 = derivative_16(v12, v2)
            let v14 : UH0 = normalize_9(v13)
            let v15 : UH0 = derivative_16(v1, v2)
            let v16 : UH0 = normalize_9(v15)
            regex_equal_14(v14, v16)
        else
            false
    if v18 then
        match v0 with
        | UH1_3(v23, v24, v25) -> (* DerivativeEquationProofAlt *)
            let v26 : US0 = derivative_equation_proof_symbol_6(v0)
            let v27 : US0 = derivative_equation_proof_symbol_6(v24)
            let v37 : US4 =
                match v26 with
                | US0_1 -> (* BitOne *)
                    match v27 with
                    | US0_1 -> (* BitOne *)
                        US4_1
                    | US0_0 -> (* BitZero *)
                        US4_2
                | US0_0 -> (* BitZero *)
                    match v27 with
                    | US0_1 -> (* BitOne *)
                        US4_0
                    | US0_0 -> (* BitZero *)
                        US4_1
            let v38 : bool =
                match v37 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v52 : bool =
                if v38 then
                    let v39 : US0 = derivative_equation_proof_symbol_6(v0)
                    let v40 : US0 = derivative_equation_proof_symbol_6(v25)
                    let v50 : US4 =
                        match v39 with
                        | US0_1 -> (* BitOne *)
                            match v40 with
                            | US0_1 -> (* BitOne *)
                                US4_1
                            | US0_0 -> (* BitZero *)
                                US4_2
                        | US0_0 -> (* BitZero *)
                            match v40 with
                            | US0_1 -> (* BitOne *)
                                US4_0
                            | US0_0 -> (* BitZero *)
                                US4_1
                    match v50 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v54 : bool =
                if v52 then
                    derivative_equation_proof_valid_4(v24)
                else
                    false
            if v54 then
                derivative_equation_proof_valid_4(v25)
            else
                false
        | UH1_4(v57, v58, v59, v60) -> (* DerivativeEquationProofCat *)
            let v61 : UH0 = derivative_equation_proof_source_5(v59)
            let v62 : US2 = nullable_1(v61)
            let v66 : US1 =
                match v62 with
                | US2_1 -> (* NonNullable *)
                    US1_1
                | US2_0 -> (* Nullable *)
                    US1_0
            let v70 : bool =
                match v58 with
                | US1_1 -> (* EquationCatNonNullable *)
                    match v66 with
                    | US1_1 -> (* EquationCatNonNullable *)
                        true
                    | _ ->
                        false
                | US1_0 -> (* EquationCatNullable *)
                    match v66 with
                    | US1_0 -> (* EquationCatNullable *)
                        true
                    | _ ->
                        false
            let v84 : bool =
                if v70 then
                    let v71 : US0 = derivative_equation_proof_symbol_6(v0)
                    let v72 : US0 = derivative_equation_proof_symbol_6(v59)
                    let v82 : US4 =
                        match v71 with
                        | US0_1 -> (* BitOne *)
                            match v72 with
                            | US0_1 -> (* BitOne *)
                                US4_1
                            | US0_0 -> (* BitZero *)
                                US4_2
                        | US0_0 -> (* BitZero *)
                            match v72 with
                            | US0_1 -> (* BitOne *)
                                US4_0
                            | US0_0 -> (* BitZero *)
                                US4_1
                    match v82 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v98 : bool =
                if v84 then
                    let v85 : US0 = derivative_equation_proof_symbol_6(v0)
                    let v86 : US0 = derivative_equation_proof_symbol_6(v60)
                    let v96 : US4 =
                        match v85 with
                        | US0_1 -> (* BitOne *)
                            match v86 with
                            | US0_1 -> (* BitOne *)
                                US4_1
                            | US0_0 -> (* BitZero *)
                                US4_2
                        | US0_0 -> (* BitZero *)
                            match v86 with
                            | US0_1 -> (* BitOne *)
                                US4_0
                            | US0_0 -> (* BitZero *)
                                US4_1
                    match v96 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v100 : bool =
                if v98 then
                    derivative_equation_proof_valid_4(v59)
                else
                    false
            if v100 then
                derivative_equation_proof_valid_4(v60)
            else
                false
        | UH1_2(v21, v22) -> (* DerivativeEquationProofChar *)
            true
        | UH1_0(v19) -> (* DerivativeEquationProofEmpty *)
            true
        | UH1_1(v20) -> (* DerivativeEquationProofEpsilon *)
            true
        | UH1_5(v103, v104) -> (* DerivativeEquationProofStar *)
            let v105 : US0 = derivative_equation_proof_symbol_6(v0)
            let v106 : US0 = derivative_equation_proof_symbol_6(v104)
            let v116 : US4 =
                match v105 with
                | US0_1 -> (* BitOne *)
                    match v106 with
                    | US0_1 -> (* BitOne *)
                        US4_1
                    | US0_0 -> (* BitZero *)
                        US4_2
                | US0_0 -> (* BitZero *)
                    match v106 with
                    | US0_1 -> (* BitOne *)
                        US4_0
                    | US0_0 -> (* BitZero *)
                        US4_1
            let v117 : bool =
                match v116 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v117 then
                derivative_equation_proof_valid_4(v104)
            else
                false
    else
        false
and derivative_equation_proof_source_19 (v0 : UH3) : UH2 =
    match v0 with
    | UH3_3(v8, v9, v10) -> (* DerivativeEquationProofAlt *)
        let v11 : UH2 = derivative_equation_proof_source_19(v9)
        let v12 : UH2 = derivative_equation_proof_source_19(v10)
        UH2_3(v11, v12)
    | UH3_4(v14, v15, v16, v17) -> (* DerivativeEquationProofCat *)
        let v18 : UH2 = derivative_equation_proof_source_19(v16)
        let v19 : UH2 = derivative_equation_proof_source_19(v17)
        UH2_4(v18, v19)
    | UH3_2(v5, v6) -> (* DerivativeEquationProofChar *)
        UH2_2(v5)
    | UH3_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH2_0
    | UH3_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH2_1
    | UH3_5(v21, v22) -> (* DerivativeEquationProofStar *)
        let v23 : UH2 = derivative_equation_proof_source_19(v22)
        UH2_5(v23)
and derivative_equation_proof_symbol_20 (v0 : UH3) : US3 =
    match v0 with
    | UH3_3(v5, v6, v7) -> (* DerivativeEquationProofAlt *)
        v5
    | UH3_4(v8, v9, v10, v11) -> (* DerivativeEquationProofCat *)
        v8
    | UH3_2(v3, v4) -> (* DerivativeEquationProofChar *)
        v4
    | UH3_0(v1) -> (* DerivativeEquationProofEmpty *)
        v1
    | UH3_1(v2) -> (* DerivativeEquationProofEpsilon *)
        v2
    | UH3_5(v12, v13) -> (* DerivativeEquationProofStar *)
        v12
and derivative_equation_proof_candidate_21 (v0 : UH3) : UH2 =
    match v0 with
    | UH3_3(v27, v28, v29) -> (* DerivativeEquationProofAlt *)
        let v30 : UH2 = derivative_equation_proof_candidate_21(v28)
        let v31 : UH2 = derivative_equation_proof_candidate_21(v29)
        UH2_3(v30, v31)
    | UH3_4(v33, v34, v35, v36) -> (* DerivativeEquationProofCat *)
        let v37 : UH2 = derivative_equation_proof_candidate_21(v35)
        let v38 : UH2 = derivative_equation_proof_candidate_21(v36)
        let v39 : UH2 = derivative_equation_proof_source_19(v36)
        match v34 with
        | US1_1 -> (* EquationCatNonNullable *)
            UH2_4(v37, v39)
        | US1_0 -> (* EquationCatNullable *)
            let v40 : UH2 = UH2_4(v37, v39)
            UH2_3(v40, v38)
    | UH3_2(v5, v6) -> (* DerivativeEquationProofChar *)
        let v22 : US4 =
            match v5 with
            | US3_0 -> (* TriA *)
                match v6 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v6 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v5 with
                    | US3_1 -> (* TriB *)
                        match v6 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v6 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        let v23 : bool =
            match v22 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v23 then
            UH2_1
        else
            UH2_0
    | UH3_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH2_0
    | UH3_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH2_0
    | UH3_5(v45, v46) -> (* DerivativeEquationProofStar *)
        let v47 : UH2 = derivative_equation_proof_candidate_21(v46)
        let v48 : UH2 = derivative_equation_proof_source_19(v46)
        let v49 : UH2 = UH2_5(v48)
        UH2_4(v47, v49)
and regex_compare_26 (v0 : UH2, v1 : UH2) : US4 =
    match v0 with
    | UH2_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v61, v62) -> (* RegexAlt *)
            let v63 : US4 = regex_compare_26(v59, v61)
            match v63 with
            | US4_1 -> (* SymbolSame *)
                regex_compare_26(v60, v62)
            | _ ->
                v63
        | _ ->
            US4_2
    | UH2_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH2_4(v40, v41) -> (* RegexCat *)
            let v42 : US4 = regex_compare_26(v34, v40)
            match v42 with
            | US4_1 -> (* SymbolSame *)
                regex_compare_26(v35, v41)
            | _ ->
                v42
        | UH2_2(v38) -> (* RegexChar *)
            US4_2
        | UH2_0 -> (* RegexEmpty *)
            US4_2
        | UH2_1 -> (* RegexEpsilon *)
            US4_2
        | _ ->
            US4_0
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US3_0 -> (* TriA *)
                match v13 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v13 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v10 with
                    | US3_1 -> (* TriB *)
                        match v13 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v13 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        | UH2_0 -> (* RegexEmpty *)
            US4_2
        | UH2_1 -> (* RegexEpsilon *)
            US4_2
        | _ ->
            US4_0
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US4_1
        | _ ->
            US4_0
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US4_2
        | UH2_1 -> (* RegexEpsilon *)
            US4_1
        | _ ->
            US4_0
    | UH2_5(v50) -> (* RegexStar *)
        match v1 with
        | UH2_3(v51, v52) -> (* RegexAlt *)
            US4_0
        | UH2_5(v54) -> (* RegexStar *)
            regex_compare_26(v50, v54)
        | _ ->
            US4_2
and alt_insert_sorted_25 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = regex_compare_26(v0, v2)
        match v4 with
        | US4_2 -> (* SymbolGreater *)
            let v6 : UH2 = alt_insert_sorted_25(v0, v3)
            UH2_3(v2, v6)
        | US4_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US4_1 -> (* SymbolSame *)
            v1
    | UH2_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US4 = regex_compare_26(v0, v1)
        match v11 with
        | US4_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
        | US4_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US4_1 -> (* SymbolSame *)
            v1
and make_alt_24 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = alt_insert_sorted_25(v2, v1)
        make_alt_24(v3, v4)
    | UH2_0 -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_25(v0, v1)
and regex_equal_28 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_28(v24, v26)
            if v28 then
                regex_equal_28(v25, v27)
            else
                false
        | _ ->
            false
    | UH2_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_28(v32, v34)
            if v36 then
                regex_equal_28(v33, v35)
            else
                false
        | _ ->
            false
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
            let v21 : US4 =
                match v4 with
                | US3_0 -> (* TriA *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v4 with
                        | US3_1 -> (* TriB *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            match v21 with
            | US4_1 -> (* SymbolSame *)
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
    | UH2_5(v40) -> (* RegexStar *)
        match v1 with
        | UH2_5(v41) -> (* RegexStar *)
            regex_equal_28(v40, v41)
        | _ ->
            false
and make_cat_27 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = make_cat_27(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_28(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and make_star_29 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and normalize_23 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = normalize_23(v5)
        let v8 : UH2 = normalize_23(v6)
        make_alt_24(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = normalize_23(v10)
        let v13 : UH2 = normalize_23(v11)
        make_cat_27(v12, v13)
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = normalize_23(v15)
        make_star_29(v16)
and derivative_30 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = derivative_30(v25, v1)
        let v28 : UH2 = derivative_30(v26, v1)
        make_alt_24(v27, v28)
    | UH2_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_3(v30)
        match v32 with
        | US2_1 -> (* NonNullable *)
            let v37 : UH2 = derivative_30(v30, v1)
            make_cat_27(v37, v31)
        | US2_0 -> (* Nullable *)
            let v33 : UH2 = derivative_30(v30, v1)
            let v34 : UH2 = make_cat_27(v33, v31)
            let v35 : UH2 = derivative_30(v31, v1)
            make_alt_24(v34, v35)
    | UH2_2(v4) -> (* RegexChar *)
        let v20 : US4 =
            match v4 with
            | US3_0 -> (* TriA *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v4 with
                    | US3_1 -> (* TriB *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        let v21 : bool =
            match v20 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH2 = derivative_30(v41, v1)
        let v43 : UH2 = make_star_29(v41)
        make_cat_27(v42, v43)
and canonical_derivative_22 (v0 : UH2, v1 : US3) : UH2 =
    let v2 : UH2 = normalize_23(v0)
    let v3 : UH2 = derivative_30(v2, v1)
    normalize_23(v3)
and reference_derivative_31 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = reference_derivative_31(v25, v1)
        let v28 : UH2 = reference_derivative_31(v26, v1)
        UH2_3(v27, v28)
    | UH2_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_3(v30)
        match v32 with
        | US2_1 -> (* NonNullable *)
            let v37 : UH2 = reference_derivative_31(v30, v1)
            UH2_4(v37, v31)
        | US2_0 -> (* Nullable *)
            let v33 : UH2 = reference_derivative_31(v30, v1)
            let v34 : UH2 = reference_derivative_31(v31, v1)
            let v35 : UH2 = UH2_4(v33, v31)
            UH2_3(v35, v34)
    | UH2_2(v4) -> (* RegexChar *)
        let v20 : US4 =
            match v4 with
            | US3_0 -> (* TriA *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v4 with
                    | US3_1 -> (* TriB *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        let v21 : bool =
            match v20 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH2 = reference_derivative_31(v41, v1)
        let v43 : UH2 = UH2_5(v41)
        UH2_4(v42, v43)
and derivative_equation_proof_valid_18 (v0 : UH3) : bool =
    let v1 : UH2 = derivative_equation_proof_source_19(v0)
    let v2 : US3 = derivative_equation_proof_symbol_20(v0)
    let v3 : UH2 = derivative_equation_proof_candidate_21(v0)
    let v4 : UH2 = canonical_derivative_22(v1, v2)
    let v5 : UH2 = reference_derivative_31(v1, v2)
    let v6 : UH2 = normalize_23(v5)
    let v7 : UH2 = normalize_23(v3)
    let v8 : bool = regex_equal_28(v7, v4)
    let v11 : bool =
        if v8 then
            let v9 : UH2 = normalize_23(v3)
            regex_equal_28(v9, v6)
        else
            false
    let v18 : bool =
        if v11 then
            let v12 : UH2 = normalize_23(v1)
            let v13 : UH2 = derivative_30(v12, v2)
            let v14 : UH2 = normalize_23(v13)
            let v15 : UH2 = derivative_30(v1, v2)
            let v16 : UH2 = normalize_23(v15)
            regex_equal_28(v14, v16)
        else
            false
    if v18 then
        match v0 with
        | UH3_3(v23, v24, v25) -> (* DerivativeEquationProofAlt *)
            let v26 : US3 = derivative_equation_proof_symbol_20(v0)
            let v27 : US3 = derivative_equation_proof_symbol_20(v24)
            let v43 : US4 =
                match v26 with
                | US3_0 -> (* TriA *)
                    match v27 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v27 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v26 with
                        | US3_1 -> (* TriB *)
                            match v27 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v27 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v44 : bool =
                match v43 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v64 : bool =
                if v44 then
                    let v45 : US3 = derivative_equation_proof_symbol_20(v0)
                    let v46 : US3 = derivative_equation_proof_symbol_20(v25)
                    let v62 : US4 =
                        match v45 with
                        | US3_0 -> (* TriA *)
                            match v46 with
                            | US3_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v46 with
                            | US3_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v45 with
                                | US3_1 -> (* TriB *)
                                    match v46 with
                                    | US3_1 -> (* TriB *)
                                        US4_1
                                    | US3_2 -> (* TriC *)
                                        US4_0
                                | US3_2 -> (* TriC *)
                                    match v46 with
                                    | US3_1 -> (* TriB *)
                                        US4_2
                                    | US3_2 -> (* TriC *)
                                        US4_1
                    match v62 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v66 : bool =
                if v64 then
                    derivative_equation_proof_valid_18(v24)
                else
                    false
            if v66 then
                derivative_equation_proof_valid_18(v25)
            else
                false
        | UH3_4(v69, v70, v71, v72) -> (* DerivativeEquationProofCat *)
            let v73 : UH2 = derivative_equation_proof_source_19(v71)
            let v74 : US2 = nullable_3(v73)
            let v78 : US1 =
                match v74 with
                | US2_1 -> (* NonNullable *)
                    US1_1
                | US2_0 -> (* Nullable *)
                    US1_0
            let v82 : bool =
                match v70 with
                | US1_1 -> (* EquationCatNonNullable *)
                    match v78 with
                    | US1_1 -> (* EquationCatNonNullable *)
                        true
                    | _ ->
                        false
                | US1_0 -> (* EquationCatNullable *)
                    match v78 with
                    | US1_0 -> (* EquationCatNullable *)
                        true
                    | _ ->
                        false
            let v102 : bool =
                if v82 then
                    let v83 : US3 = derivative_equation_proof_symbol_20(v0)
                    let v84 : US3 = derivative_equation_proof_symbol_20(v71)
                    let v100 : US4 =
                        match v83 with
                        | US3_0 -> (* TriA *)
                            match v84 with
                            | US3_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v84 with
                            | US3_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v83 with
                                | US3_1 -> (* TriB *)
                                    match v84 with
                                    | US3_1 -> (* TriB *)
                                        US4_1
                                    | US3_2 -> (* TriC *)
                                        US4_0
                                | US3_2 -> (* TriC *)
                                    match v84 with
                                    | US3_1 -> (* TriB *)
                                        US4_2
                                    | US3_2 -> (* TriC *)
                                        US4_1
                    match v100 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v122 : bool =
                if v102 then
                    let v103 : US3 = derivative_equation_proof_symbol_20(v0)
                    let v104 : US3 = derivative_equation_proof_symbol_20(v72)
                    let v120 : US4 =
                        match v103 with
                        | US3_0 -> (* TriA *)
                            match v104 with
                            | US3_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v104 with
                            | US3_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v103 with
                                | US3_1 -> (* TriB *)
                                    match v104 with
                                    | US3_1 -> (* TriB *)
                                        US4_1
                                    | US3_2 -> (* TriC *)
                                        US4_0
                                | US3_2 -> (* TriC *)
                                    match v104 with
                                    | US3_1 -> (* TriB *)
                                        US4_2
                                    | US3_2 -> (* TriC *)
                                        US4_1
                    match v120 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v124 : bool =
                if v122 then
                    derivative_equation_proof_valid_18(v71)
                else
                    false
            if v124 then
                derivative_equation_proof_valid_18(v72)
            else
                false
        | UH3_2(v21, v22) -> (* DerivativeEquationProofChar *)
            true
        | UH3_0(v19) -> (* DerivativeEquationProofEmpty *)
            true
        | UH3_1(v20) -> (* DerivativeEquationProofEpsilon *)
            true
        | UH3_5(v127, v128) -> (* DerivativeEquationProofStar *)
            let v129 : US3 = derivative_equation_proof_symbol_20(v0)
            let v130 : US3 = derivative_equation_proof_symbol_20(v128)
            let v146 : US4 =
                match v129 with
                | US3_0 -> (* TriA *)
                    match v130 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v130 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v129 with
                        | US3_1 -> (* TriB *)
                            match v130 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v130 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v147 : bool =
                match v146 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v147 then
                derivative_equation_proof_valid_18(v128)
            else
                false
    else
        false
and input_singletons_from_symbols_32 (v0 : UH4) : UH5 =
    match v0 with
    | UH4_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH5 = input_singletons_from_symbols_32(v3)
        let v5 : UH6 = UH6_0
        let v6 : UH6 = UH6_1(v2, v5)
        UH5_1(v6, v4)
    | UH4_0 -> (* SymbolListNil *)
        UH5_0
and input_prepend_symbol_to_corpus_34 (v0 : US0, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = input_prepend_symbol_to_corpus_34(v0, v4)
        let v6 : UH6 = UH6_1(v0, v3)
        UH5_1(v6, v5)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and input_list_append_35 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : UH5 = input_list_append_35(v3, v1)
        UH5_1(v2, v4)
    | UH5_0 -> (* InputListNil *)
        v1
and input_prepend_symbols_to_corpus_33 (v0 : UH4, v1 : UH5) : UH5 =
    match v0 with
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH5 = input_prepend_symbol_to_corpus_34(v3, v1)
        let v6 : UH5 = input_prepend_symbols_to_corpus_33(v4, v1)
        input_list_append_35(v5, v6)
    | UH4_0 -> (* SymbolListNil *)
        UH5_0
and input_singletons_from_symbols_36 (v0 : UH7) : UH8 =
    match v0 with
    | UH7_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH8 = input_singletons_from_symbols_36(v3)
        let v5 : UH9 = UH9_0
        let v6 : UH9 = UH9_1(v2, v5)
        UH8_1(v6, v4)
    | UH7_0 -> (* SymbolListNil *)
        UH8_0
and input_prepend_symbol_to_corpus_38 (v0 : US3, v1 : UH8) : UH8 =
    match v1 with
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = input_prepend_symbol_to_corpus_38(v0, v4)
        let v6 : UH9 = UH9_1(v0, v3)
        UH8_1(v6, v5)
    | UH8_0 -> (* InputListNil *)
        UH8_0
and input_list_append_39 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : UH8 = input_list_append_39(v3, v1)
        UH8_1(v2, v4)
    | UH8_0 -> (* InputListNil *)
        v1
and input_prepend_symbols_to_corpus_37 (v0 : UH7, v1 : UH8) : UH8 =
    match v0 with
    | UH7_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH8 = input_prepend_symbol_to_corpus_38(v3, v1)
        let v6 : UH8 = input_prepend_symbols_to_corpus_37(v4, v1)
        input_list_append_39(v5, v6)
    | UH7_0 -> (* SymbolListNil *)
        UH8_0
and consume_right_41 (v0 : UH0, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = language_remainders_40(v0, v3)
        let v6 : UH5 = consume_right_41(v0, v4)
        input_list_append_35(v5, v6)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and input_equal_45 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH6_1(v5, v6) -> (* InputCons *)
            let v16 : US4 =
                match v3 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US4_1
                    | US0_0 -> (* BitZero *)
                        US4_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US4_0
                    | US0_0 -> (* BitZero *)
                        US4_1
            let v17 : bool =
                match v16 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                input_equal_45(v4, v6)
            else
                false
        | _ ->
            false
    | UH6_0 -> (* InputEmpty *)
        match v1 with
        | UH6_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and input_list_contains_44 (v0 : UH6, v1 : UH5) : bool =
    match v1 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_45(v0, v2)
        if v4 then
            true
        else
            input_list_contains_44(v0, v3)
    | UH5_0 -> (* InputListNil *)
        false
and input_list_enqueue_new_43 (v0 : UH5, v1 : UH5, v2 : UH5) : struct (UH5 * UH5) =
    match v0 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_44(v3, v1)
        if v5 then
            input_list_enqueue_new_43(v4, v1, v2)
        else
            let v8 : UH5 = UH5_1(v3, v1)
            let v9 : UH5 = UH5_1(v3, v2)
            input_list_enqueue_new_43(v4, v8, v9)
    | UH5_0 -> (* InputListNil *)
        struct (v1, v2)
and closure_42 (v0 : UH0, v1 : UH5, v2 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = language_remainders_40(v0, v3)
        let struct (v6 : UH5, v7 : UH5) = input_list_enqueue_new_43(v5, v2, v4)
        closure_42(v0, v7, v6)
    | UH5_0 -> (* InputListNil *)
        v2
and language_remainders_40 (v0 : UH0, v1 : UH6) : UH5 =
    match v0 with
    | UH0_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH5 = language_remainders_40(v26, v1)
        let v29 : UH5 = language_remainders_40(v27, v1)
        input_list_append_35(v28, v29)
    | UH0_4(v31, v32) -> (* RegexCat *)
        let v33 : UH5 = language_remainders_40(v31, v1)
        consume_right_41(v32, v33)
    | UH0_2(v5) -> (* RegexChar *)
        match v1 with
        | UH6_1(v7, v8) -> (* InputCons *)
            let v18 : US4 =
                match v5 with
                | US0_1 -> (* BitOne *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US4_1
                    | US0_0 -> (* BitZero *)
                        US4_2
                | US0_0 -> (* BitZero *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US4_0
                    | US0_0 -> (* BitZero *)
                        US4_1
            let v19 : bool =
                match v18 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH5 = UH5_0
                UH5_1(v8, v20)
            else
                UH5_0
        | UH6_0 -> (* InputEmpty *)
            UH5_0
    | UH0_0 -> (* RegexEmpty *)
        UH5_0
    | UH0_1 -> (* RegexEpsilon *)
        let v3 : UH5 = UH5_0
        UH5_1(v1, v3)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH5 = UH5_0
        let v37 : UH5 = UH5_1(v1, v36)
        let v38 : UH5 = UH5_0
        let v39 : UH5 = UH5_1(v1, v38)
        closure_42(v35, v37, v39)
and input_list_remove_46 (v0 : UH6, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_equal_45(v0, v3)
        if v5 then
            input_list_remove_46(v0, v4)
        else
            let v7 : UH5 = input_list_remove_46(v0, v4)
            UH5_1(v3, v7)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and input_list_subset_47 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_list_contains_44(v2, v1)
        if v4 then
            input_list_subset_47(v3, v1)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
and closure0 (v0 : bool, v1 : UH0) (v2 : UH6) : bool =
    let v22 : bool =
        if v0 then
            let v3 : US0 = US0_0
            let v4 : UH6 = UH6_1(v3, v2)
            let v5 : US0 = US0_0
            let v6 : UH0 = UH0_2(v5)
            let v7 : US0 = US0_1
            let v8 : UH0 = UH0_2(v7)
            let v9 : UH0 = UH0_3(v6, v8)
            let v10 : UH0 = UH0_5(v9)
            let v11 : US0 = US0_0
            let v12 : UH0 = UH0_2(v11)
            let v13 : UH0 = UH0_4(v10, v12)
            let v14 : US0 = US0_0
            let v15 : UH6 = UH6_1(v14, v2)
            let v16 : UH5 = language_remainders_40(v13, v15)
            let v17 : UH5 = input_list_remove_46(v4, v16)
            let v18 : UH5 = language_remainders_40(v1, v2)
            let v19 : bool = input_list_subset_47(v17, v18)
            if v19 then
                input_list_subset_47(v18, v17)
            else
                false
        else
            false
    v22
and derivative_universal_remainder_family_suffixes_48 (v0 : (UH6 -> bool), v1 : UH5) : bool =
    match v1 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = v0 v2
        if v4 then
            derivative_universal_remainder_family_suffixes_48(v0, v3)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
and consume_right_50 (v0 : UH2, v1 : UH8) : UH8 =
    match v1 with
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = language_remainders_49(v0, v3)
        let v6 : UH8 = consume_right_50(v0, v4)
        input_list_append_39(v5, v6)
    | UH8_0 -> (* InputListNil *)
        UH8_0
and input_equal_54 (v0 : UH9, v1 : UH9) : bool =
    match v0 with
    | UH9_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH9_1(v5, v6) -> (* InputCons *)
            let v22 : US4 =
                match v3 with
                | US3_0 -> (* TriA *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v3 with
                        | US3_1 -> (* TriB *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v23 : bool =
                match v22 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                input_equal_54(v4, v6)
            else
                false
        | _ ->
            false
    | UH9_0 -> (* InputEmpty *)
        match v1 with
        | UH9_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and input_list_contains_53 (v0 : UH9, v1 : UH8) : bool =
    match v1 with
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_equal_54(v0, v2)
        if v4 then
            true
        else
            input_list_contains_53(v0, v3)
    | UH8_0 -> (* InputListNil *)
        false
and input_list_enqueue_new_52 (v0 : UH8, v1 : UH8, v2 : UH8) : struct (UH8 * UH8) =
    match v0 with
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_list_contains_53(v3, v1)
        if v5 then
            input_list_enqueue_new_52(v4, v1, v2)
        else
            let v8 : UH8 = UH8_1(v3, v1)
            let v9 : UH8 = UH8_1(v3, v2)
            input_list_enqueue_new_52(v4, v8, v9)
    | UH8_0 -> (* InputListNil *)
        struct (v1, v2)
and closure_51 (v0 : UH2, v1 : UH8, v2 : UH8) : UH8 =
    match v1 with
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = language_remainders_49(v0, v3)
        let struct (v6 : UH8, v7 : UH8) = input_list_enqueue_new_52(v5, v2, v4)
        closure_51(v0, v7, v6)
    | UH8_0 -> (* InputListNil *)
        v2
and language_remainders_49 (v0 : UH2, v1 : UH9) : UH8 =
    match v0 with
    | UH2_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH8 = language_remainders_49(v32, v1)
        let v35 : UH8 = language_remainders_49(v33, v1)
        input_list_append_39(v34, v35)
    | UH2_4(v37, v38) -> (* RegexCat *)
        let v39 : UH8 = language_remainders_49(v37, v1)
        consume_right_50(v38, v39)
    | UH2_2(v5) -> (* RegexChar *)
        match v1 with
        | UH9_1(v7, v8) -> (* InputCons *)
            let v24 : US4 =
                match v5 with
                | US3_0 -> (* TriA *)
                    match v7 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v7 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v5 with
                        | US3_1 -> (* TriB *)
                            match v7 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v7 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v25 : bool =
                match v24 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH8 = UH8_0
                UH8_1(v8, v26)
            else
                UH8_0
        | UH9_0 -> (* InputEmpty *)
            UH8_0
    | UH2_0 -> (* RegexEmpty *)
        UH8_0
    | UH2_1 -> (* RegexEpsilon *)
        let v3 : UH8 = UH8_0
        UH8_1(v1, v3)
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH8 = UH8_0
        let v43 : UH8 = UH8_1(v1, v42)
        let v44 : UH8 = UH8_0
        let v45 : UH8 = UH8_1(v1, v44)
        closure_51(v41, v43, v45)
and input_list_remove_55 (v0 : UH9, v1 : UH8) : UH8 =
    match v1 with
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = input_equal_54(v0, v3)
        if v5 then
            input_list_remove_55(v0, v4)
        else
            let v7 : UH8 = input_list_remove_55(v0, v4)
            UH8_1(v3, v7)
    | UH8_0 -> (* InputListNil *)
        UH8_0
and input_list_subset_56 (v0 : UH8, v1 : UH8) : bool =
    match v0 with
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = input_list_contains_53(v2, v1)
        if v4 then
            input_list_subset_56(v3, v1)
        else
            false
    | UH8_0 -> (* InputListNil *)
        true
and closure1 (v0 : bool, v1 : UH2) (v2 : UH9) : bool =
    let v22 : bool =
        if v0 then
            let v3 : US3 = US3_0
            let v4 : UH9 = UH9_1(v3, v2)
            let v5 : US3 = US3_0
            let v6 : UH2 = UH2_2(v5)
            let v7 : US3 = US3_1
            let v8 : UH2 = UH2_2(v7)
            let v9 : UH2 = UH2_3(v6, v8)
            let v10 : UH2 = UH2_5(v9)
            let v11 : US3 = US3_2
            let v12 : UH2 = UH2_2(v11)
            let v13 : UH2 = UH2_4(v10, v12)
            let v14 : US3 = US3_0
            let v15 : UH9 = UH9_1(v14, v2)
            let v16 : UH8 = language_remainders_49(v13, v15)
            let v17 : UH8 = input_list_remove_55(v4, v16)
            let v18 : UH8 = language_remainders_49(v1, v2)
            let v19 : bool = input_list_subset_56(v17, v18)
            if v19 then
                input_list_subset_56(v18, v17)
            else
                false
        else
            false
    v22
and derivative_universal_remainder_family_suffixes_57 (v0 : (UH9 -> bool), v1 : UH8) : bool =
    match v1 with
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = v0 v2
        if v4 then
            derivative_universal_remainder_family_suffixes_57(v0, v3)
        else
            false
    | UH8_0 -> (* InputListNil *)
        true
let v0 : US0 = US0_0
let v1 : UH0 = UH0_2(v0)
let v2 : US0 = US0_1
let v3 : UH0 = UH0_2(v2)
let v4 : UH0 = UH0_3(v1, v3)
let v5 : UH0 = UH0_5(v4)
let v6 : US0 = US0_0
let v7 : UH0 = UH0_2(v6)
let v8 : UH0 = UH0_4(v5, v7)
let v9 : US0 = US0_0
let v10 : UH1 = derivative_equation_proof_make_0(v8, v9)
let v11 : US3 = US3_0
let v12 : UH2 = UH2_2(v11)
let v13 : US3 = US3_1
let v14 : UH2 = UH2_2(v13)
let v15 : UH2 = UH2_3(v12, v14)
let v16 : UH2 = UH2_5(v15)
let v17 : US3 = US3_2
let v18 : UH2 = UH2_2(v17)
let v19 : UH2 = UH2_4(v16, v18)
let v20 : US3 = US3_0
let v21 : UH3 = derivative_equation_proof_make_2(v19, v20)
let v22 : US0 = US0_0
let v23 : UH0 = UH0_2(v22)
let v24 : US0 = US0_1
let v25 : UH0 = UH0_2(v24)
let v26 : UH0 = UH0_3(v23, v25)
let v27 : UH0 = UH0_5(v26)
let v28 : US0 = US0_0
let v29 : UH0 = UH0_2(v28)
let v30 : UH0 = UH0_4(v27, v29)
let v31 : US0 = US0_0
let v32 : UH1 = derivative_equation_proof_make_0(v30, v31)
let v33 : US3 = US3_0
let v34 : UH2 = UH2_2(v33)
let v35 : US3 = US3_1
let v36 : UH2 = UH2_2(v35)
let v37 : UH2 = UH2_3(v34, v36)
let v38 : UH2 = UH2_5(v37)
let v39 : US3 = US3_2
let v40 : UH2 = UH2_2(v39)
let v41 : UH2 = UH2_4(v38, v40)
let v42 : US3 = US3_0
let v43 : UH3 = derivative_equation_proof_make_2(v41, v42)
let v44 : bool = derivative_equation_proof_valid_4(v10)
if v44 then
    ()
else
    failwith<unit> "suffix-independent bit derivative equation proof must validate"
let v45 : bool = derivative_equation_proof_valid_18(v21)
if v45 then
    ()
else
    failwith<unit> "suffix-independent ternary derivative equation proof must validate"
let v46 : US0 = US0_0
let v47 : UH0 = UH0_2(v46)
let v48 : US0 = US0_1
let v49 : UH0 = UH0_2(v48)
let v50 : UH0 = UH0_3(v47, v49)
let v51 : UH0 = UH0_5(v50)
let v52 : US0 = US0_0
let v53 : UH0 = UH0_2(v52)
let v54 : UH0 = UH0_4(v51, v53)
let v55 : UH0 = derivative_equation_proof_source_5(v32)
let v56 : bool = regex_equal_14(v54, v55)
let v65 : bool =
    if v56 then
        let v57 : US0 = derivative_equation_proof_symbol_6(v32)
        let v61 : US4 =
            match v57 with
            | US0_1 -> (* BitOne *)
                US4_0
            | US0_0 -> (* BitZero *)
                US4_1
        let v62 : bool =
            match v61 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v62 then
            derivative_equation_proof_valid_4(v32)
        else
            false
    else
        false
if v65 then
    ()
else
    failwith<unit> "bit derivative equation certificate must bind source and symbol"
let v66 : US3 = US3_0
let v67 : UH2 = UH2_2(v66)
let v68 : US3 = US3_1
let v69 : UH2 = UH2_2(v68)
let v70 : UH2 = UH2_3(v67, v69)
let v71 : UH2 = UH2_5(v70)
let v72 : US3 = US3_2
let v73 : UH2 = UH2_2(v72)
let v74 : UH2 = UH2_4(v71, v73)
let v75 : UH2 = derivative_equation_proof_source_19(v43)
let v76 : bool = regex_equal_28(v74, v75)
let v84 : bool =
    if v76 then
        let v77 : US3 = derivative_equation_proof_symbol_20(v43)
        let v80 : US4 =
            match v77 with
            | US3_0 -> (* TriA *)
                US4_1
            | _ ->
                US4_0
        let v81 : bool =
            match v80 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v81 then
            derivative_equation_proof_valid_18(v43)
        else
            false
    else
        false
if v84 then
    ()
else
    failwith<unit> "ternary derivative equation certificate must bind source and symbol"
let v85 : US0 = US0_0
let v86 : UH0 = UH0_2(v85)
let v87 : US0 = US0_1
let v88 : UH0 = UH0_2(v87)
let v89 : UH0 = UH0_3(v86, v88)
let v90 : UH0 = UH0_5(v89)
let v91 : US0 = US0_0
let v92 : UH0 = UH0_2(v91)
let v93 : UH0 = UH0_4(v90, v92)
let v94 : US0 = US0_0
let v95 : UH1 = derivative_equation_proof_make_0(v93, v94)
let v96 : US0 = US0_0
let v97 : UH0 = UH0_2(v96)
let v98 : US0 = US0_1
let v99 : UH0 = UH0_2(v98)
let v100 : UH0 = UH0_3(v97, v99)
let v101 : UH0 = UH0_5(v100)
let v102 : US0 = US0_0
let v103 : UH0 = UH0_2(v102)
let v104 : UH0 = UH0_4(v101, v103)
let v105 : UH0 = derivative_equation_proof_source_5(v95)
let v106 : bool = regex_equal_14(v104, v105)
let v115 : bool =
    if v106 then
        let v107 : US0 = derivative_equation_proof_symbol_6(v95)
        let v111 : US4 =
            match v107 with
            | US0_1 -> (* BitOne *)
                US4_0
            | US0_0 -> (* BitZero *)
                US4_1
        let v112 : bool =
            match v111 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v112 then
            derivative_equation_proof_valid_4(v95)
        else
            false
    else
        false
let v116 : US0 = US0_0
let v117 : UH0 = UH0_2(v116)
let v118 : US0 = US0_1
let v119 : UH0 = UH0_2(v118)
let v120 : UH0 = UH0_3(v117, v119)
let v121 : UH0 = UH0_5(v120)
let v122 : US0 = US0_0
let v123 : UH0 = UH0_2(v122)
let v124 : UH0 = UH0_4(v121, v123)
let v125 : US0 = US0_0
let v126 : UH0 = canonical_derivative_8(v124, v125)
let v127 : US3 = US3_0
let v128 : UH2 = UH2_2(v127)
let v129 : US3 = US3_1
let v130 : UH2 = UH2_2(v129)
let v131 : UH2 = UH2_3(v128, v130)
let v132 : UH2 = UH2_5(v131)
let v133 : US3 = US3_2
let v134 : UH2 = UH2_2(v133)
let v135 : UH2 = UH2_4(v132, v134)
let v136 : US3 = US3_0
let v137 : UH3 = derivative_equation_proof_make_2(v135, v136)
let v138 : US3 = US3_0
let v139 : UH2 = UH2_2(v138)
let v140 : US3 = US3_1
let v141 : UH2 = UH2_2(v140)
let v142 : UH2 = UH2_3(v139, v141)
let v143 : UH2 = UH2_5(v142)
let v144 : US3 = US3_2
let v145 : UH2 = UH2_2(v144)
let v146 : UH2 = UH2_4(v143, v145)
let v147 : UH2 = derivative_equation_proof_source_19(v137)
let v148 : bool = regex_equal_28(v146, v147)
let v156 : bool =
    if v148 then
        let v149 : US3 = derivative_equation_proof_symbol_20(v137)
        let v152 : US4 =
            match v149 with
            | US3_0 -> (* TriA *)
                US4_1
            | _ ->
                US4_0
        let v153 : bool =
            match v152 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v153 then
            derivative_equation_proof_valid_18(v137)
        else
            false
    else
        false
let v157 : US3 = US3_0
let v158 : UH2 = UH2_2(v157)
let v159 : US3 = US3_1
let v160 : UH2 = UH2_2(v159)
let v161 : UH2 = UH2_3(v158, v160)
let v162 : UH2 = UH2_5(v161)
let v163 : US3 = US3_2
let v164 : UH2 = UH2_2(v163)
let v165 : UH2 = UH2_4(v162, v164)
let v166 : US3 = US3_0
let v167 : UH2 = canonical_derivative_22(v165, v166)
let v168 : US0 = US0_0
let v169 : US0 = US0_1
let v170 : UH4 = UH4_0
let v171 : UH4 = UH4_1(v169, v170)
let v172 : UH4 = UH4_1(v168, v171)
let v173 : UH5 = input_singletons_from_symbols_32(v172)
let v174 : UH6 = UH6_0
let v175 : UH5 = UH5_1(v174, v173)
let v176 : US0 = US0_0
let v177 : US0 = US0_1
let v178 : UH4 = UH4_0
let v179 : UH4 = UH4_1(v177, v178)
let v180 : UH4 = UH4_1(v176, v179)
let v181 : US0 = US0_0
let v182 : US0 = US0_1
let v183 : UH4 = UH4_0
let v184 : UH4 = UH4_1(v182, v183)
let v185 : UH4 = UH4_1(v181, v184)
let v186 : UH5 = input_singletons_from_symbols_32(v185)
let v187 : UH5 = input_prepend_symbols_to_corpus_33(v180, v186)
let v188 : UH5 = input_list_append_35(v175, v187)
let v189 : US3 = US3_0
let v190 : US3 = US3_1
let v191 : US3 = US3_2
let v192 : UH7 = UH7_0
let v193 : UH7 = UH7_1(v191, v192)
let v194 : UH7 = UH7_1(v190, v193)
let v195 : UH7 = UH7_1(v189, v194)
let v196 : UH8 = input_singletons_from_symbols_36(v195)
let v197 : UH9 = UH9_0
let v198 : UH8 = UH8_1(v197, v196)
let v199 : US3 = US3_0
let v200 : US3 = US3_1
let v201 : US3 = US3_2
let v202 : UH7 = UH7_0
let v203 : UH7 = UH7_1(v201, v202)
let v204 : UH7 = UH7_1(v200, v203)
let v205 : UH7 = UH7_1(v199, v204)
let v206 : US3 = US3_0
let v207 : US3 = US3_1
let v208 : US3 = US3_2
let v209 : UH7 = UH7_0
let v210 : UH7 = UH7_1(v208, v209)
let v211 : UH7 = UH7_1(v207, v210)
let v212 : UH7 = UH7_1(v206, v211)
let v213 : UH8 = input_singletons_from_symbols_36(v212)
let v214 : UH8 = input_prepend_symbols_to_corpus_37(v205, v213)
let v215 : UH8 = input_list_append_39(v198, v214)
let v216 : (UH6 -> bool) = closure0(v115, v126)
let v217 : bool = derivative_universal_remainder_family_suffixes_48(v216, v188)
if v217 then
    ()
else
    failwith<unit> "one bit structural certificate must instantiate over every finite suffix probe"
let v218 : (UH9 -> bool) = closure1(v156, v167)
let v219 : bool = derivative_universal_remainder_family_suffixes_57(v218, v215)
if v219 then
    ()
else
    failwith<unit> "one ternary structural certificate must instantiate over every finite suffix probe"
let v220 : US0 = US0_1
let v221 : US0 = US0_1
let v222 : US0 = US0_0
let v223 : UH6 = UH6_0
let v224 : UH6 = UH6_1(v222, v223)
let v225 : UH6 = UH6_1(v221, v224)
let v226 : UH6 = UH6_1(v220, v225)
let v227 : US3 = US3_1
let v228 : US3 = US3_2
let v229 : UH9 = UH9_0
let v230 : UH9 = UH9_1(v228, v229)
let v231 : UH9 = UH9_1(v227, v230)
let v251 : bool =
    if v115 then
        let v232 : US0 = US0_0
        let v233 : UH6 = UH6_1(v232, v226)
        let v234 : US0 = US0_0
        let v235 : UH0 = UH0_2(v234)
        let v236 : US0 = US0_1
        let v237 : UH0 = UH0_2(v236)
        let v238 : UH0 = UH0_3(v235, v237)
        let v239 : UH0 = UH0_5(v238)
        let v240 : US0 = US0_0
        let v241 : UH0 = UH0_2(v240)
        let v242 : UH0 = UH0_4(v239, v241)
        let v243 : US0 = US0_0
        let v244 : UH6 = UH6_1(v243, v226)
        let v245 : UH5 = language_remainders_40(v242, v244)
        let v246 : UH5 = input_list_remove_46(v233, v245)
        let v247 : UH5 = language_remainders_40(v126, v226)
        let v248 : bool = input_list_subset_47(v246, v247)
        if v248 then
            input_list_subset_47(v247, v246)
        else
            false
    else
        false
if v251 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v271 : bool =
    if v156 then
        let v252 : US3 = US3_0
        let v253 : UH9 = UH9_1(v252, v231)
        let v254 : US3 = US3_0
        let v255 : UH2 = UH2_2(v254)
        let v256 : US3 = US3_1
        let v257 : UH2 = UH2_2(v256)
        let v258 : UH2 = UH2_3(v255, v257)
        let v259 : UH2 = UH2_5(v258)
        let v260 : US3 = US3_2
        let v261 : UH2 = UH2_2(v260)
        let v262 : UH2 = UH2_4(v259, v261)
        let v263 : US3 = US3_0
        let v264 : UH9 = UH9_1(v263, v231)
        let v265 : UH8 = language_remainders_49(v262, v264)
        let v266 : UH8 = input_list_remove_55(v253, v265)
        let v267 : UH8 = language_remainders_49(v167, v231)
        let v268 : bool = input_list_subset_56(v266, v267)
        if v268 then
            input_list_subset_56(v267, v266)
        else
            false
    else
        false
if v271 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v272 : UH0 = UH0_1
let v273 : US0 = US0_0
let v274 : UH1 = derivative_equation_proof_make_0(v272, v273)
let v275 : US0 = US0_0
let v276 : UH0 = UH0_2(v275)
let v277 : US0 = US0_0
let v278 : UH1 = derivative_equation_proof_make_0(v276, v277)
let v279 : UH0 = UH0_1
let v280 : US0 = US0_0
let v281 : UH1 = derivative_equation_proof_make_0(v279, v280)
let v282 : US0 = US0_0
let v283 : US0 = US0_0
let v284 : US0 = US0_0
let v285 : UH1 = UH1_2(v283, v284)
let v286 : US0 = US0_1
let v287 : US0 = US0_1
let v288 : UH1 = UH1_2(v286, v287)
let v289 : UH1 = UH1_3(v282, v285, v288)
let v290 : bool = derivative_equation_proof_valid_4(v289)
let v291 : bool = v290 = false
if v291 then
    ()
else
    failwith<unit> "a child proof from another symbol context must be rejected"
let v292 : US0 = US0_0
let v293 : US1 = US1_1
let v294 : UH1 = UH1_4(v292, v293, v274, v278)
let v295 : bool = derivative_equation_proof_valid_4(v294)
let v296 : bool = v295 = false
if v296 then
    ()
else
    failwith<unit> "a forged nullable concatenation branch must be rejected"
let v297 : UH0 = UH0_0
let v298 : UH0 = derivative_equation_proof_source_5(v281)
let v299 : bool = regex_equal_14(v297, v298)
let v308 : bool =
    if v299 then
        let v300 : US0 = derivative_equation_proof_symbol_6(v281)
        let v304 : US4 =
            match v300 with
            | US0_1 -> (* BitOne *)
                US4_0
            | US0_0 -> (* BitZero *)
                US4_1
        let v305 : bool =
            match v304 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v305 then
            derivative_equation_proof_valid_4(v281)
        else
            false
    else
        false
let v309 : bool = v308 = false
if v309 then
    ()
else
    failwith<unit> "a forged source binding must be rejected"
let v310 : string = "brzozowski-derivative-universal-witness-green"
v310
