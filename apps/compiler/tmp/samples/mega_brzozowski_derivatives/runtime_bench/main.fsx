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
and UH2 =
    | UH2_RegexListNil
    | UH2_RegexListCons of UH0 * UH2
let rec random_bit_input_1 (v0 : uint64, v1 : int32, v2 : UH1) : struct (UH1 * uint64) =
    let v3 : bool = 0 < v1
    if v3 then
        let v4 : uint64 = v0 * 1103515245UL
        let v5 : uint64 = v4 + 12345UL
        let v6 : uint64 = v5 &&& 2147483647UL
        let v7 : int32 = v1 - 1
        let v8 : uint64 = v6 >>> 16
        let v9 : uint64 = v8 &&& 1UL
        let v10 : bool = v9 = 0UL
        let v13 : US0 =
            if v10 then
                let v11 : US0 = US0_BitZero
                v11
            else
                let v12 : US0 = US0_BitOne
                v12
        let v14 : UH1 = UH1_InputCons(v13, v2)
        random_bit_input_1(v6, v7, v14)
    else
        struct (v2, v0)
and regex_compare_7 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = regex_compare_7(v53, v55)
            match v57 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_7(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_SymbolGreater
    | UH0_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US1 = regex_compare_7(v28, v34)
            match v36 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_7(v29, v35)
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
            regex_compare_7(v44, v48)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_6 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_7(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH0 = alt_insert_sorted_6(v0, v3)
            UH0_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_7(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH0_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_5 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = alt_insert_sorted_6(v2, v1)
        make_alt_5(v3, v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_6(v0, v1)
and regex_equal_9 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_9(v18, v20)
            if v22 then
                regex_equal_9(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_9(v26, v28)
            if v30 then
                regex_equal_9(v27, v29)
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
            regex_equal_9(v34, v35)
        | _ ->
            false
and make_cat_8 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = make_cat_8(v13, v1)
                        UH0_RegexCat(v12, v14)
                    | UH0_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_9(v4, v5)
                            if v6 then
                                UH0_RegexStar(v4)
                            else
                                UH0_RegexCat(v0, v1)
                        | _ ->
                            UH0_RegexCat(v0, v1)
                    | _ ->
                        UH0_RegexCat(v0, v1)
and make_star_10 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEpsilon
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v3) -> (* RegexStar *)
        UH0_RegexStar(v3)
    | _ ->
        UH0_RegexStar(v0)
and normalize_4 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = normalize_4(v5)
        let v8 : UH0 = normalize_4(v6)
        make_alt_5(v7, v8)
    | UH0_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = normalize_4(v10)
        let v13 : UH0 = normalize_4(v11)
        make_cat_8(v12, v13)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        UH0_RegexChar(v3)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEmpty
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH0 = normalize_4(v15)
        make_star_10(v16)
and nullable_12 (v0 : UH0) : US2 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_12(v5)
        let v8 : US2 = nullable_12(v6)
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
        let v18 : US2 = nullable_12(v16)
        let v19 : US2 = nullable_12(v17)
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
and derivative_11 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_11(v19, v1)
        let v22 : UH0 = derivative_11(v20, v1)
        make_alt_5(v21, v22)
    | UH0_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_12(v24)
        match v26 with
        | US2_NonNullable -> (* NonNullable *)
            let v31 : UH0 = derivative_11(v24, v1)
            make_cat_8(v31, v25)
        | US2_Nullable -> (* Nullable *)
            let v27 : UH0 = derivative_11(v24, v1)
            let v28 : UH0 = make_cat_8(v27, v25)
            let v29 : UH0 = derivative_11(v25, v1)
            make_alt_5(v28, v29)
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
        let v36 : UH0 = derivative_11(v35, v1)
        let v37 : UH0 = make_star_10(v35)
        make_cat_8(v36, v37)
and canonical_derivative_3 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_4(v0)
    let v3 : UH0 = derivative_11(v2, v1)
    normalize_4(v3)
and accepts_2 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH0 = canonical_derivative_3(v0, v6)
        accepts_2(v8, v7)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : UH0 = normalize_4(v0)
        let v3 : US2 = nullable_12(v2)
        match v3 with
        | US2_NonNullable -> (* NonNullable *)
            false
        | US2_Nullable -> (* Nullable *)
            true
and loop_0 (v0 : UH0, v1 : int32, v2 : int32, v3 : uint64, v4 : int32) : int32 =
    let v5 : bool = 0 < v2
    if v5 then
        let v6 : UH1 = UH1_InputEmpty
        let struct (v7 : UH1, v8 : uint64) = random_bit_input_1(v3, v1, v6)
        let v9 : bool = accepts_2(v0, v7)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v4 + 1
                v10
            else
                v4
        let v12 : int32 = v2 - 1
        loop_0(v0, v1, v12, v8, v11)
    else
        v4
and zeros_input_14 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_BitZero
        let v5 : UH1 = UH1_InputCons(v4, v1)
        zeros_input_14(v3, v5)
    else
        v1
and loop_13 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_InputEmpty
        let v6 : UH1 = zeros_input_14(v2, v5)
        let v7 : bool = accepts_2(v0, v6)
        let v9 : int32 =
            if v7 then
                let v8 : int32 = v3 + 1
                v8
            else
                v3
        let v10 : US0 = US0_BitOne
        let v11 : UH1 = UH1_InputEmpty
        let v12 : UH1 = UH1_InputCons(v10, v11)
        let v13 : UH1 = zeros_input_14(v2, v12)
        let v14 : bool = accepts_2(v0, v13)
        let v16 : int32 =
            if v14 then
                let v15 : int32 = v9 + 1
                v15
            else
                v9
        let v17 : int32 = v2 + 1
        loop_13(v0, v1, v17, v16)
and backtrack_stack_16 (v0 : UH2, v1 : UH1) : bool =
    match v0 with
    | UH2_RegexListCons(v6, v7) -> (* RegexListCons *)
        match v6 with
        | UH0_RegexAlt(v27, v28) -> (* RegexAlt *)
            let v29 : UH2 = UH2_RegexListCons(v27, v7)
            let v30 : bool = backtrack_stack_16(v29, v1)
            if v30 then
                true
            else
                let v31 : UH2 = UH2_RegexListCons(v28, v7)
                backtrack_stack_16(v31, v1)
        | UH0_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : UH2 = UH2_RegexListCons(v35, v7)
            let v37 : UH2 = UH2_RegexListCons(v34, v36)
            backtrack_stack_16(v37, v1)
        | UH0_RegexChar(v9) -> (* RegexChar *)
            match v1 with
            | UH1_InputCons(v10, v11) -> (* InputCons *)
                let v21 : US1 =
                    match v9 with
                    | US0_BitOne -> (* BitOne *)
                        match v10 with
                        | US0_BitOne -> (* BitOne *)
                            US1_SymbolSame
                        | US0_BitZero -> (* BitZero *)
                            US1_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        match v10 with
                        | US0_BitOne -> (* BitOne *)
                            US1_SymbolLess
                        | US0_BitZero -> (* BitZero *)
                            US1_SymbolSame
                let v22 : bool =
                    match v21 with
                    | US1_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v22 then
                    backtrack_stack_16(v7, v11)
                else
                    false
            | UH1_InputEmpty -> (* InputEmpty *)
                false
        | UH0_RegexEmpty -> (* RegexEmpty *)
            false
        | UH0_RegexEpsilon -> (* RegexEpsilon *)
            backtrack_stack_16(v7, v1)
        | UH0_RegexStar(v39) -> (* RegexStar *)
            let v40 : UH2 = UH2_RegexListCons(v39, v0)
            let v41 : bool = backtrack_stack_16(v40, v1)
            if v41 then
                true
            else
                backtrack_stack_16(v7, v1)
    | UH2_RegexListNil -> (* RegexListNil *)
        match v1 with
        | UH1_InputCons(v2, v3) -> (* InputCons *)
            false
        | UH1_InputEmpty -> (* InputEmpty *)
            true
and loop_15 (v0 : UH0, v1 : int32, v2 : int32, v3 : uint64, v4 : int32) : int32 =
    let v5 : bool = 0 < v2
    if v5 then
        let v6 : UH1 = UH1_InputEmpty
        let struct (v7 : UH1, v8 : uint64) = random_bit_input_1(v3, v1, v6)
        let v9 : UH2 = UH2_RegexListNil
        let v10 : UH2 = UH2_RegexListCons(v0, v9)
        let v11 : bool = backtrack_stack_16(v10, v7)
        let v13 : int32 =
            if v11 then
                let v12 : int32 = v4 + 1
                v12
            else
                v4
        let v14 : int32 = v2 - 1
        loop_15(v0, v1, v14, v8, v13)
    else
        v4
and loop_17 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_InputEmpty
        let v6 : UH1 = zeros_input_14(v2, v5)
        let v7 : UH2 = UH2_RegexListNil
        let v8 : UH2 = UH2_RegexListCons(v0, v7)
        let v9 : bool = backtrack_stack_16(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : US0 = US0_BitOne
        let v13 : UH1 = UH1_InputEmpty
        let v14 : UH1 = UH1_InputCons(v12, v13)
        let v15 : UH1 = zeros_input_14(v2, v14)
        let v16 : UH2 = UH2_RegexListNil
        let v17 : UH2 = UH2_RegexListCons(v0, v16)
        let v18 : bool = backtrack_stack_16(v17, v15)
        let v20 : int32 =
            if v18 then
                let v19 : int32 = v11 + 1
                v19
            else
                v11
        let v21 : int32 = v2 + 1
        loop_17(v0, v1, v21, v20)
and run_19 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v3, v4) -> (* InputCons *)
        match v3 with
        | US0_BitOne -> (* BitOne *)
            let v8 : bool = v0 = 0
            let v9 : int32 = 0
            run_19(v9, v4)
        | US0_BitZero -> (* BitZero *)
            let v5 : bool = v0 = 0
            let v6 : int32 = 1
            run_19(v6, v4)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 1
        v2
and loop_18 (v0 : int32, v1 : int32, v2 : uint64, v3 : int32) : int32 =
    let v4 : bool = 0 < v1
    if v4 then
        let v5 : UH1 = UH1_InputEmpty
        let struct (v6 : UH1, v7 : uint64) = random_bit_input_1(v2, v0, v5)
        let v8 : int32 = 0
        let v9 : bool = run_19(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : int32 = v1 - 1
        loop_18(v0, v12, v7, v11)
    else
        v3
and run_21 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v17, v18) -> (* InputCons *)
        match v17 with
        | US0_BitOne -> (* BitOne *)
            let v50 : bool = v0 = 0
            let v79 : int32 =
                if v50 then
                    1
                else
                    let v51 : bool = v0 = 1
                    if v51 then
                        6
                    else
                        let v52 : bool = v0 = 2
                        if v52 then
                            11
                        else
                            let v53 : bool = v0 = 3
                            if v53 then
                                5
                            else
                                let v54 : bool = v0 = 4
                                if v54 then
                                    1
                                else
                                    let v55 : bool = v0 = 5
                                    if v55 then
                                        6
                                    else
                                        let v56 : bool = v0 = 6
                                        if v56 then
                                            13
                                        else
                                            let v57 : bool = v0 = 7
                                            if v57 then
                                                9
                                            else
                                                let v58 : bool = v0 = 8
                                                if v58 then
                                                    5
                                                else
                                                    let v59 : bool = v0 = 9
                                                    if v59 then
                                                        12
                                                    else
                                                        let v60 : bool = v0 = 10
                                                        if v60 then
                                                            11
                                                        else
                                                            let v61 : bool = v0 = 11
                                                            if v61 then
                                                                12
                                                            else
                                                                let v62 : bool = v0 = 12
                                                                if v62 then
                                                                    13
                                                                else
                                                                    let v63 : bool = v0 = 13
                                                                    if v63 then
                                                                        15
                                                                    else
                                                                        let v64 : bool = v0 = 14
                                                                        if v64 then
                                                                            9
                                                                        else
                                                                            15
            run_21(v79, v18)
        | US0_BitZero -> (* BitZero *)
            let v19 : bool = v0 = 0
            let v48 : int32 =
                if v19 then
                    0
                else
                    let v20 : bool = v0 = 1
                    if v20 then
                        2
                    else
                        let v21 : bool = v0 = 2
                        if v21 then
                            3
                        else
                            let v22 : bool = v0 = 3
                            if v22 then
                                4
                            else
                                let v23 : bool = v0 = 4
                                if v23 then
                                    0
                                else
                                    let v24 : bool = v0 = 5
                                    if v24 then
                                        2
                                    else
                                        let v25 : bool = v0 = 6
                                        if v25 then
                                            7
                                        else
                                            let v26 : bool = v0 = 7
                                            if v26 then
                                                8
                                            else
                                                let v27 : bool = v0 = 8
                                                if v27 then
                                                    4
                                                else
                                                    let v28 : bool = v0 = 9
                                                    if v28 then
                                                        10
                                                    else
                                                        let v29 : bool = v0 = 10
                                                        if v29 then
                                                            3
                                                        else
                                                            let v30 : bool = v0 = 11
                                                            if v30 then
                                                                10
                                                            else
                                                                let v31 : bool = v0 = 12
                                                                if v31 then
                                                                    7
                                                                else
                                                                    let v32 : bool = v0 = 13
                                                                    if v32 then
                                                                        14
                                                                    else
                                                                        let v33 : bool = v0 = 14
                                                                        if v33 then
                                                                            8
                                                                        else
                                                                            14
            run_21(v48, v18)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 4
        if v2 then
            true
        else
            let v3 : bool = v0 = 5
            if v3 then
                true
            else
                let v4 : bool = v0 = 8
                if v4 then
                    true
                else
                    let v5 : bool = v0 = 9
                    if v5 then
                        true
                    else
                        let v6 : bool = v0 = 10
                        if v6 then
                            true
                        else
                            let v7 : bool = v0 = 12
                            if v7 then
                                true
                            else
                                let v8 : bool = v0 = 14
                                if v8 then
                                    true
                                else
                                    let v9 : bool = v0 = 15
                                    v9
and loop_20 (v0 : int32, v1 : int32, v2 : uint64, v3 : int32) : int32 =
    let v4 : bool = 0 < v1
    if v4 then
        let v5 : UH1 = UH1_InputEmpty
        let struct (v6 : UH1, v7 : uint64) = random_bit_input_1(v2, v0, v5)
        let v8 : int32 = 0
        let v9 : bool = run_21(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : int32 = v1 - 1
        loop_20(v0, v12, v7, v11)
    else
        v3
and run_23 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v3, v4) -> (* InputCons *)
        match v3 with
        | US0_BitOne -> (* BitOne *)
            let v13 : bool = v0 = 0
            let v19 : int32 =
                if v13 then
                    3
                else
                    let v14 : bool = v0 = 1
                    if v14 then
                        3
                    else
                        let v15 : bool = v0 = 2
                        if v15 then
                            3
                        else
                            let v16 : bool = v0 = 3
                            4
            run_23(v19, v4)
        | US0_BitZero -> (* BitZero *)
            let v5 : bool = v0 = 0
            let v11 : int32 =
                if v5 then
                    1
                else
                    let v6 : bool = v0 = 1
                    if v6 then
                        2
                    else
                        let v7 : bool = v0 = 2
                        if v7 then
                            2
                        else
                            let v8 : bool = v0 = 3
                            4
            run_23(v11, v4)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 3
        v2
and loop_22 (v0 : int32, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v0 < v1
    if v3 then
        v2
    else
        let v4 : UH1 = UH1_InputEmpty
        let v5 : UH1 = zeros_input_14(v1, v4)
        let v6 : int32 = 0
        let v7 : bool = run_23(v6, v5)
        let v9 : int32 =
            if v7 then
                let v8 : int32 = v2 + 1
                v8
            else
                v2
        let v10 : US0 = US0_BitOne
        let v11 : UH1 = UH1_InputEmpty
        let v12 : UH1 = UH1_InputCons(v10, v11)
        let v13 : UH1 = zeros_input_14(v1, v12)
        let v14 : int32 = 0
        let v15 : bool = run_23(v14, v13)
        let v17 : int32 =
            if v15 then
                let v16 : int32 = v9 + 1
                v16
            else
                v9
        let v18 : int32 = v1 + 1
        loop_22(v0, v18, v17)
and loop_24 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 8192
    if v2 then
        v0.[int v1] <- 0
        let v3 : int32 = v1 + 1
        loop_24(v0, v3)
and loop_25 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 1
    if v2 then
        v0.[int v1] <- 0
        let v3 : int32 = v1 + 1
        loop_25(v0, v3)
and probe_27 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : int32) : int32 =
    let v11 : int32 = v4.[int v10]
    let v12 : bool = v11 = 0
    if v12 then
        let v13 : int32 = v6.[int 0]
        let v14 : bool = v13 < 4096
        if v14 then
            v0.[int v13] <- v7
            v1.[int v13] <- v8
            v2.[int v13] <- v9
            let v15 : bool = v7 = 1
            let v32 : bool =
                if v15 then
                    true
                else
                    let v16 : bool = v7 = 5
                    if v16 then
                        true
                    else
                        let v17 : bool = v7 = 3
                        if v17 then
                            let v18 : int32 = v3.[int v8]
                            let v19 : bool = v18 = 1
                            if v19 then
                                true
                            else
                                let v20 : int32 = v3.[int v9]
                                let v21 : bool = v20 = 1
                                v21
                        else
                            let v23 : bool = v7 = 4
                            if v23 then
                                let v24 : int32 = v3.[int v8]
                                let v25 : bool = v24 = 1
                                if v25 then
                                    let v26 : int32 = v3.[int v9]
                                    let v27 : bool = v26 = 1
                                    v27
                                else
                                    false
                            else
                                false
            let v33 : int32 =
                if v32 then
                    1
                else
                    0
            v3.[int v13] <- v33
            let v34 : int32 = v13 + 1
            v4.[int v10] <- v34
            v6.[int 0] <- v34
            v13
        else
            failwith<int32> "brzozowski-interned-store-full"
    else
        let v37 : int32 = v11 - 1
        let v38 : int32 = v0.[int v37]
        let v39 : bool = v38 = v7
        let v42 : bool =
            if v39 then
                let v40 : int32 = v1.[int v37]
                let v41 : bool = v40 = v8
                v41
            else
                false
        let v45 : bool =
            if v42 then
                let v43 : int32 = v2.[int v37]
                let v44 : bool = v43 = v9
                v44
            else
                false
        if v45 then
            v37
        else
            let v46 : int32 = v10 + 1
            let v47 : int32 = v46 &&& 8191
            probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47)
and interned_node_26 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32) : int32 =
    let v10 : int32 = v7 * 1024
    let v11 : int32 = v10 + v8
    let v12 : int32 = v11 * 4099
    let v13 : int32 = v12 + v9
    let v14 : int32 = v13 &&& 8191
    probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
and interned_alt_insert_30 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v8 = 0
    if v9 then
        v7
    else
        let v10 : int32 = v0.[int v8]
        let v11 : bool = v10 = 3
        if v11 then
            let v12 : int32 = v1.[int v8]
            let v13 : bool = v7 < v12
            if v13 then
                let v14 : int32 = 3
                interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
            else
                let v16 : bool = v7 = v12
                if v16 then
                    v8
                else
                    let v17 : int32 = 3
                    let v18 : int32 = v2.[int v8]
                    let v19 : int32 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
        else
            let v23 : bool = v7 < v8
            if v23 then
                let v24 : int32 = 3
                interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
            else
                let v26 : bool = v7 = v8
                if v26 then
                    v8
                else
                    let v27 : int32 = 3
                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
and interned_make_alt_29 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v7 = 0
    if v9 then
        v8
    else
        let v10 : int32 = v0.[int v7]
        let v11 : bool = v10 = 3
        if v11 then
            let v12 : int32 = v2.[int v7]
            let v13 : int32 = v1.[int v7]
            let v14 : int32 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
            interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v12, v14)
        else
            interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and interned_make_cat_31 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v7 = 0
    if v9 then
        0
    else
        let v10 : bool = v8 = 0
        if v10 then
            0
        else
            let v11 : bool = v7 = 1
            if v11 then
                v8
            else
                let v12 : bool = v8 = 1
                if v12 then
                    v7
                else
                    let v13 : int32 = v0.[int v7]
                    let v14 : bool = v13 = 5
                    let v17 : bool =
                        if v14 then
                            let v15 : int32 = v0.[int v8]
                            let v16 : bool = v15 = 5
                            v16
                        else
                            false
                    if v17 then
                        let v18 : int32 = v1.[int v7]
                        let v19 : int32 = v1.[int v8]
                        let v20 : bool = v18 = v19
                        if v20 then
                            v7
                        else
                            let v21 : int32 = 4
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                    else
                        let v24 : int32 = v0.[int v7]
                        let v25 : bool = v24 = 4
                        if v25 then
                            let v26 : int32 = 4
                            let v27 : int32 = v1.[int v7]
                            let v28 : int32 = v2.[int v7]
                            let v29 : int32 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                        else
                            let v31 : int32 = 4
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
and interned_of_regex_raw_28 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : UH0) : int32 =
    match v7 with
    | UH0_RegexAlt(v14, v15) -> (* RegexAlt *)
        let v16 : int32 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14)
        let v17 : int32 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15)
        interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
    | UH0_RegexCat(v19, v20) -> (* RegexCat *)
        let v21 : int32 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19)
        let v22 : int32 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20)
        interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
    | UH0_RegexChar(v8) -> (* RegexChar *)
        let v9 : int32 = 2
        let v11 : int32 =
            match v8 with
            | US0_BitOne -> (* BitOne *)
                1
            | US0_BitZero -> (* BitZero *)
                0
        let v12 : int32 = 0
        interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        0
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        1
    | UH0_RegexStar(v24) -> (* RegexStar *)
        let v25 : int32 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24)
        let v26 : int32 = v0.[int v25]
        let v27 : bool = v26 < 2
        if v27 then
            1
        else
            let v28 : bool = v26 = 5
            if v28 then
                v25
            else
                let v29 : int32 = 5
                let v30 : int32 = 0
                interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
and interned_derivative_raw_35 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : int32 = v7 * 2
    let v10 : int32 = v9 + v8
    let v11 : int32 = v5.[int v10]
    let v12 : bool = v11 = 0
    if v12 then
        let v13 : int32 = v0.[int v7]
        let v14 : bool = v13 < 2
        let v41 : int32 =
            if v14 then
                0
            else
                let v15 : bool = v13 = 2
                if v15 then
                    let v16 : int32 = v1.[int v7]
                    let v17 : bool = v16 = v8
                    if v17 then
                        1
                    else
                        0
                else
                    let v19 : bool = v13 = 3
                    if v19 then
                        let v20 : int32 = v1.[int v7]
                        let v21 : int32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                        let v22 : int32 = v2.[int v7]
                        let v23 : int32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                        interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                    else
                        let v25 : bool = v13 = 4
                        if v25 then
                            let v26 : int32 = v1.[int v7]
                            let v27 : int32 = v2.[int v7]
                            let v28 : int32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                            let v29 : int32 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                            let v30 : int32 = v3.[int v26]
                            let v31 : bool = v30 = 1
                            if v31 then
                                let v32 : int32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                                interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                            else
                                v29
                        else
                            let v35 : int32 = v1.[int v7]
                            let v36 : int32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                            interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
        let v42 : int32 = v41 + 1
        v5.[int v10] <- v42
        v41
    else
        let v43 : int32 = v11 - 1
        v43
and loop_34 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    let v9 : bool = v7 = 0
    if v9 then
        false
    else
        match v8 with
        | UH1_InputCons(v12, v13) -> (* InputCons *)
            let v15 : int32 =
                match v12 with
                | US0_BitOne -> (* BitOne *)
                    1
                | US0_BitZero -> (* BitZero *)
                    0
            let v16 : int32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
            loop_34(v0, v1, v2, v3, v4, v5, v6, v16, v13)
        | UH1_InputEmpty -> (* InputEmpty *)
            let v10 : int32 = v3.[int v7]
            let v11 : bool = v10 = 1
            v11
and interned_accepts_33 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and loop_32 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : uint64, v11 : int32) : int32 =
    let v12 : bool = 0 < v9
    if v12 then
        let v13 : UH1 = UH1_InputEmpty
        let struct (v14 : UH1, v15 : uint64) = random_bit_input_1(v10, v7, v13)
        let v16 : bool = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
        let v18 : int32 =
            if v16 then
                let v17 : int32 = v11 + 1
                v17
            else
                v11
        let v19 : int32 = v9 - 1
        loop_32(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18)
    else
        v11
and loop_36 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : int32) : int32 =
    let v11 : bool = v7 < v9
    if v11 then
        v10
    else
        let v12 : UH1 = UH1_InputEmpty
        let v13 : UH1 = zeros_input_14(v9, v12)
        let v14 : bool = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
        let v16 : int32 =
            if v14 then
                let v15 : int32 = v10 + 1
                v15
            else
                v10
        let v17 : US0 = US0_BitOne
        let v18 : UH1 = UH1_InputEmpty
        let v19 : UH1 = UH1_InputCons(v17, v18)
        let v20 : UH1 = zeros_input_14(v9, v19)
        let v21 : bool = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
        let v23 : int32 =
            if v21 then
                let v22 : int32 = v16 + 1
                v22
            else
                v16
        let v24 : int32 = v9 + 1
        loop_36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23)
let v0 : int32 = 200
let v1 : int32 = 32
let v2 : US0 = US0_BitZero
let v3 : UH0 = UH0_RegexChar(v2)
let v4 : US0 = US0_BitOne
let v5 : UH0 = UH0_RegexChar(v4)
let v6 : UH0 = UH0_RegexAlt(v3, v5)
let v7 : UH0 = UH0_RegexStar(v6)
let v8 : US0 = US0_BitZero
let v9 : UH0 = UH0_RegexChar(v8)
let v10 : UH0 = UH0_RegexCat(v7, v9)
let v11 : US0 = US0_BitZero
let v12 : UH0 = UH0_RegexChar(v11)
let v13 : US0 = US0_BitOne
let v14 : UH0 = UH0_RegexChar(v13)
let v15 : UH0 = UH0_RegexAlt(v12, v14)
let v16 : UH0 = UH0_RegexStar(v15)
let v17 : US0 = US0_BitOne
let v18 : UH0 = UH0_RegexChar(v17)
let v19 : US0 = US0_BitZero
let v20 : UH0 = UH0_RegexChar(v19)
let v21 : US0 = US0_BitOne
let v22 : UH0 = UH0_RegexChar(v21)
let v23 : UH0 = UH0_RegexAlt(v20, v22)
let v24 : US0 = US0_BitZero
let v25 : UH0 = UH0_RegexChar(v24)
let v26 : US0 = US0_BitOne
let v27 : UH0 = UH0_RegexChar(v26)
let v28 : UH0 = UH0_RegexAlt(v25, v27)
let v29 : US0 = US0_BitZero
let v30 : UH0 = UH0_RegexChar(v29)
let v31 : US0 = US0_BitOne
let v32 : UH0 = UH0_RegexChar(v31)
let v33 : UH0 = UH0_RegexAlt(v30, v32)
let v34 : UH0 = UH0_RegexCat(v28, v33)
let v35 : UH0 = UH0_RegexCat(v23, v34)
let v36 : UH0 = UH0_RegexCat(v18, v35)
let v37 : UH0 = UH0_RegexCat(v16, v36)
let v38 : uint64 = 1UL
let v39 : int32 = 0
let v40 : int32 = loop_0(v10, v1, v0, v38, v39)
let v41 : int32 = loop_0(v37, v1, v0, v38, v39)
let v42 : int32 = 16
let v43 : US0 = US0_BitZero
let v44 : UH0 = UH0_RegexChar(v43)
let v45 : US0 = US0_BitZero
let v46 : UH0 = UH0_RegexChar(v45)
let v47 : US0 = US0_BitZero
let v48 : UH0 = UH0_RegexChar(v47)
let v49 : UH0 = UH0_RegexCat(v46, v48)
let v50 : UH0 = UH0_RegexAlt(v44, v49)
let v51 : UH0 = UH0_RegexStar(v50)
let v52 : US0 = US0_BitOne
let v53 : UH0 = UH0_RegexChar(v52)
let v54 : UH0 = UH0_RegexCat(v51, v53)
let v55 : int32 = 0
let v56 : int32 = 1
let v57 : int32 = loop_13(v54, v42, v56, v55)
let v58 : int32 = 200
let v59 : int32 = 32
let v60 : US0 = US0_BitZero
let v61 : UH0 = UH0_RegexChar(v60)
let v62 : US0 = US0_BitOne
let v63 : UH0 = UH0_RegexChar(v62)
let v64 : UH0 = UH0_RegexAlt(v61, v63)
let v65 : UH0 = UH0_RegexStar(v64)
let v66 : US0 = US0_BitZero
let v67 : UH0 = UH0_RegexChar(v66)
let v68 : UH0 = UH0_RegexCat(v65, v67)
let v69 : US0 = US0_BitZero
let v70 : UH0 = UH0_RegexChar(v69)
let v71 : US0 = US0_BitOne
let v72 : UH0 = UH0_RegexChar(v71)
let v73 : UH0 = UH0_RegexAlt(v70, v72)
let v74 : UH0 = UH0_RegexStar(v73)
let v75 : US0 = US0_BitOne
let v76 : UH0 = UH0_RegexChar(v75)
let v77 : US0 = US0_BitZero
let v78 : UH0 = UH0_RegexChar(v77)
let v79 : US0 = US0_BitOne
let v80 : UH0 = UH0_RegexChar(v79)
let v81 : UH0 = UH0_RegexAlt(v78, v80)
let v82 : US0 = US0_BitZero
let v83 : UH0 = UH0_RegexChar(v82)
let v84 : US0 = US0_BitOne
let v85 : UH0 = UH0_RegexChar(v84)
let v86 : UH0 = UH0_RegexAlt(v83, v85)
let v87 : US0 = US0_BitZero
let v88 : UH0 = UH0_RegexChar(v87)
let v89 : US0 = US0_BitOne
let v90 : UH0 = UH0_RegexChar(v89)
let v91 : UH0 = UH0_RegexAlt(v88, v90)
let v92 : UH0 = UH0_RegexCat(v86, v91)
let v93 : UH0 = UH0_RegexCat(v81, v92)
let v94 : UH0 = UH0_RegexCat(v76, v93)
let v95 : UH0 = UH0_RegexCat(v74, v94)
let v96 : uint64 = 1UL
let v97 : int32 = 0
let v98 : int32 = loop_15(v68, v59, v58, v96, v97)
let v99 : int32 = loop_15(v95, v59, v58, v96, v97)
let v100 : int32 = 16
let v101 : US0 = US0_BitZero
let v102 : UH0 = UH0_RegexChar(v101)
let v103 : US0 = US0_BitZero
let v104 : UH0 = UH0_RegexChar(v103)
let v105 : US0 = US0_BitZero
let v106 : UH0 = UH0_RegexChar(v105)
let v107 : UH0 = UH0_RegexCat(v104, v106)
let v108 : UH0 = UH0_RegexAlt(v102, v107)
let v109 : UH0 = UH0_RegexStar(v108)
let v110 : US0 = US0_BitOne
let v111 : UH0 = UH0_RegexChar(v110)
let v112 : UH0 = UH0_RegexCat(v109, v111)
let v113 : int32 = 0
let v114 : int32 = 1
let v115 : int32 = loop_17(v112, v100, v114, v113)
let v116 : bool = v40 = v98
let v118 : bool =
    if v116 then
        let v117 : bool = v41 = v99
        v117
    else
        false
let v120 : bool =
    if v118 then
        let v119 : bool = v57 = v115
        v119
    else
        false
if v120 then
    ()
else
    failwith<unit> "brzozowski-bench-engines-disagree"
let v121 : int32 = 200
let v122 : int32 = 32
let v123 : uint64 = 1UL
let v124 : int32 = 0
let v125 : int32 = loop_18(v122, v121, v123, v124)
let v126 : int32 = loop_20(v122, v121, v123, v124)
let v127 : int32 = 16
let v128 : int32 = 0
let v129 : int32 = 1
let v130 : int32 = loop_22(v127, v129, v128)
let v131 : bool = v40 = v125
let v133 : bool =
    if v131 then
        let v132 : bool = v41 = v126
        v132
    else
        false
let v135 : bool =
    if v133 then
        let v134 : bool = v57 = v130
        v134
    else
        false
if v135 then
    ()
else
    failwith<unit> "brzozowski-bench-engines-disagree"
let v136 : int32 = 200
let v137 : int32 = 32
let v138 : (int32 []) = Array.zeroCreate<int32> (4096)
let v139 : (int32 []) = Array.zeroCreate<int32> (4096)
let v140 : (int32 []) = Array.zeroCreate<int32> (4096)
let v141 : (int32 []) = Array.zeroCreate<int32> (4096)
let v142 : (int32 []) = Array.zeroCreate<int32> (8192)
let v143 : (int32 []) = Array.zeroCreate<int32> (8192)
let v144 : (int32 []) = Array.zeroCreate<int32> (1)
let v145 : int32 = 0
loop_24(v142, v145)
let v146 : int32 = 0
loop_24(v143, v146)
let v147 : int32 = 0
loop_25(v144, v147)
let v148 : int32 = 0
let v149 : int32 = 0
let v150 : int32 = 0
let v151 : int32 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
let v152 : int32 = 1
let v153 : int32 = 0
let v154 : int32 = 0
let v155 : int32 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
let v156 : bool = v151 = 0
let v158 : bool =
    if v156 then
        let v157 : bool = v155 = 1
        v157
    else
        false
let struct (v166 : (int32 []), v167 : (int32 []), v168 : (int32 []), v169 : (int32 []), v170 : (int32 []), v171 : (int32 []), v172 : (int32 [])) =
    if v158 then
        struct (v138, v139, v140, v141, v142, v143, v144)
    else
        failwith<struct ((int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []))> "brzozowski-interned-store-init"
let v173 : US0 = US0_BitZero
let v174 : UH0 = UH0_RegexChar(v173)
let v175 : US0 = US0_BitOne
let v176 : UH0 = UH0_RegexChar(v175)
let v177 : UH0 = UH0_RegexAlt(v174, v176)
let v178 : UH0 = UH0_RegexStar(v177)
let v179 : US0 = US0_BitZero
let v180 : UH0 = UH0_RegexChar(v179)
let v181 : UH0 = UH0_RegexCat(v178, v180)
let v182 : int32 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
let v183 : uint64 = 1UL
let v184 : int32 = 0
let v185 : int32 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
let v186 : US0 = US0_BitZero
let v187 : UH0 = UH0_RegexChar(v186)
let v188 : US0 = US0_BitOne
let v189 : UH0 = UH0_RegexChar(v188)
let v190 : UH0 = UH0_RegexAlt(v187, v189)
let v191 : UH0 = UH0_RegexStar(v190)
let v192 : US0 = US0_BitOne
let v193 : UH0 = UH0_RegexChar(v192)
let v194 : US0 = US0_BitZero
let v195 : UH0 = UH0_RegexChar(v194)
let v196 : US0 = US0_BitOne
let v197 : UH0 = UH0_RegexChar(v196)
let v198 : UH0 = UH0_RegexAlt(v195, v197)
let v199 : US0 = US0_BitZero
let v200 : UH0 = UH0_RegexChar(v199)
let v201 : US0 = US0_BitOne
let v202 : UH0 = UH0_RegexChar(v201)
let v203 : UH0 = UH0_RegexAlt(v200, v202)
let v204 : US0 = US0_BitZero
let v205 : UH0 = UH0_RegexChar(v204)
let v206 : US0 = US0_BitOne
let v207 : UH0 = UH0_RegexChar(v206)
let v208 : UH0 = UH0_RegexAlt(v205, v207)
let v209 : UH0 = UH0_RegexCat(v203, v208)
let v210 : UH0 = UH0_RegexCat(v198, v209)
let v211 : UH0 = UH0_RegexCat(v193, v210)
let v212 : UH0 = UH0_RegexCat(v191, v211)
let v213 : int32 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
let v214 : uint64 = 1UL
let v215 : int32 = 0
let v216 : int32 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
let v217 : int32 = 16
let v218 : (int32 []) = Array.zeroCreate<int32> (4096)
let v219 : (int32 []) = Array.zeroCreate<int32> (4096)
let v220 : (int32 []) = Array.zeroCreate<int32> (4096)
let v221 : (int32 []) = Array.zeroCreate<int32> (4096)
let v222 : (int32 []) = Array.zeroCreate<int32> (8192)
let v223 : (int32 []) = Array.zeroCreate<int32> (8192)
let v224 : (int32 []) = Array.zeroCreate<int32> (1)
let v225 : int32 = 0
loop_24(v222, v225)
let v226 : int32 = 0
loop_24(v223, v226)
let v227 : int32 = 0
loop_25(v224, v227)
let v228 : int32 = 0
let v229 : int32 = 0
let v230 : int32 = 0
let v231 : int32 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
let v232 : int32 = 1
let v233 : int32 = 0
let v234 : int32 = 0
let v235 : int32 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
let v236 : bool = v231 = 0
let v238 : bool =
    if v236 then
        let v237 : bool = v235 = 1
        v237
    else
        false
let struct (v246 : (int32 []), v247 : (int32 []), v248 : (int32 []), v249 : (int32 []), v250 : (int32 []), v251 : (int32 []), v252 : (int32 [])) =
    if v238 then
        struct (v218, v219, v220, v221, v222, v223, v224)
    else
        failwith<struct ((int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []))> "brzozowski-interned-store-init"
let v253 : US0 = US0_BitZero
let v254 : UH0 = UH0_RegexChar(v253)
let v255 : US0 = US0_BitZero
let v256 : UH0 = UH0_RegexChar(v255)
let v257 : US0 = US0_BitZero
let v258 : UH0 = UH0_RegexChar(v257)
let v259 : UH0 = UH0_RegexCat(v256, v258)
let v260 : UH0 = UH0_RegexAlt(v254, v259)
let v261 : UH0 = UH0_RegexStar(v260)
let v262 : US0 = US0_BitOne
let v263 : UH0 = UH0_RegexChar(v262)
let v264 : UH0 = UH0_RegexCat(v261, v263)
let v265 : int32 = interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
let v266 : int32 = 1
let v267 : int32 = 0
let v268 : int32 = loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
let v269 : bool = v40 = v185
let v271 : bool =
    if v269 then
        let v270 : bool = v41 = v216
        v270
    else
        false
let v273 : bool =
    if v271 then
        let v272 : bool = v57 = v268
        v272
    else
        false
if v273 then
    ()
else
    failwith<unit> "brzozowski-bench-engines-disagree"
let v274 : bool = v57 = 16
if v274 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
let v275 : bool = v40 = 93
if v275 then
    ()
else
    failwith<unit> "brzozowski-bench-ends-with-zero-count"
let v276 : bool = v41 = 97
if v276 then
    ()
else
    failwith<unit> "brzozowski-bench-fourth-from-end-count"
0
