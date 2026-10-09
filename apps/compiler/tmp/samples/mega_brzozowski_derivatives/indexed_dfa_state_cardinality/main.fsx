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
and run_2 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v4, v5) -> (* InputCons *)
        let v6 : bool = v0 = 0
        let v19 : int32 =
            if v6 then
                let v10 : US1 =
                    match v4 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolSame
                let v11 : bool =
                    match v10 with
                    | US1_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v11 then
                    1
                else
                    0
            else
                let v16 : US1 =
                    match v4 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolSame
                let v17 : bool =
                    match v16 with
                    | US1_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v17 then
                    1
                else
                    0
        run_2(v19, v5)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 0
        let v3 : bool = v2 = false
        v3
and regex_compare_8 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_RegexAlt(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = regex_compare_8(v53, v55)
            match v57 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_8(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_SymbolGreater
    | UH0_RegexCat(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : US1 = regex_compare_8(v28, v34)
            match v36 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_8(v29, v35)
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
            regex_compare_8(v44, v48)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_7 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_8(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH0 = alt_insert_sorted_7(v0, v3)
            UH0_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_8(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH0_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH0_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_6 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = alt_insert_sorted_7(v2, v1)
        make_alt_6(v3, v4)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_7(v0, v1)
and regex_equal_10 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_RegexAlt(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_RegexAlt(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_10(v18, v20)
            if v22 then
                regex_equal_10(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_RegexCat(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_RegexCat(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_10(v26, v28)
            if v30 then
                regex_equal_10(v27, v29)
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
            regex_equal_10(v34, v35)
        | _ ->
            false
and make_cat_9 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = make_cat_9(v13, v1)
                        UH0_RegexCat(v12, v14)
                    | UH0_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_10(v4, v5)
                            if v6 then
                                UH0_RegexStar(v4)
                            else
                                UH0_RegexCat(v0, v1)
                        | _ ->
                            UH0_RegexCat(v0, v1)
                    | _ ->
                        UH0_RegexCat(v0, v1)
and make_star_11 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEpsilon
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v3) -> (* RegexStar *)
        UH0_RegexStar(v3)
    | _ ->
        UH0_RegexStar(v0)
and normalize_5 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = normalize_5(v5)
        let v8 : UH0 = normalize_5(v6)
        make_alt_6(v7, v8)
    | UH0_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = normalize_5(v10)
        let v13 : UH0 = normalize_5(v11)
        make_cat_9(v12, v13)
    | UH0_RegexChar(v3) -> (* RegexChar *)
        UH0_RegexChar(v3)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        UH0_RegexEmpty
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        UH0_RegexEpsilon
    | UH0_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH0 = normalize_5(v15)
        make_star_11(v16)
and nullable_13 (v0 : UH0) : US2 =
    match v0 with
    | UH0_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_13(v5)
        let v8 : US2 = nullable_13(v6)
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
        let v18 : US2 = nullable_13(v16)
        let v19 : US2 = nullable_13(v17)
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
and derivative_12 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_RegexAlt(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_12(v19, v1)
        let v22 : UH0 = derivative_12(v20, v1)
        make_alt_6(v21, v22)
    | UH0_RegexCat(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_13(v24)
        match v26 with
        | US2_NonNullable -> (* NonNullable *)
            let v31 : UH0 = derivative_12(v24, v1)
            make_cat_9(v31, v25)
        | US2_Nullable -> (* Nullable *)
            let v27 : UH0 = derivative_12(v24, v1)
            let v28 : UH0 = make_cat_9(v27, v25)
            let v29 : UH0 = derivative_12(v25, v1)
            make_alt_6(v28, v29)
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
        let v36 : UH0 = derivative_12(v35, v1)
        let v37 : UH0 = make_star_11(v35)
        make_cat_9(v36, v37)
and canonical_derivative_4 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_5(v0)
    let v3 : UH0 = derivative_12(v2, v1)
    normalize_5(v3)
and accepts_3 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH0 = canonical_derivative_4(v0, v6)
        accepts_3(v8, v7)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : UH0 = normalize_5(v0)
        let v3 : US2 = nullable_13(v2)
        match v3 with
        | US2_NonNullable -> (* NonNullable *)
            false
        | US2_Nullable -> (* Nullable *)
            true
and loop_0 (v0 : int32, v1 : UH0, v2 : int32, v3 : uint64, v4 : int32) : int32 =
    let v5 : bool = 0 < v2
    if v5 then
        let v6 : UH1 = UH1_InputEmpty
        let struct (v7 : UH1, v8 : uint64) = random_bit_input_1(v3, v0, v6)
        let v9 : int32 = 0
        let v10 : bool = run_2(v9, v7)
        let v11 : bool = accepts_3(v1, v7)
        let v13 : bool =
            if v10 then
                v11
            else
                let v12 : bool = false = v11
                v12
        if v13 then
            let v14 : int32 = v2 - 1
            let v16 : int32 =
                if v10 then
                    let v15 : int32 = v4 + 1
                    v15
                else
                    v4
            loop_0(v0, v1, v14, v8, v16)
        else
            failwith<int32> "brzozowski-compiled-core-disagrees-on-random-input"
    else
        v4
and zeros_input_15 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_BitZero
        let v5 : UH1 = UH1_InputCons(v4, v1)
        zeros_input_15(v3, v5)
    else
        v1
and run_16 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_InputCons(v5, v6) -> (* InputCons *)
        let v7 : bool = v0 = 0
        let v26 : int32 =
            if v7 then
                let v11 : US1 =
                    match v5 with
                    | US0_BitOne -> (* BitOne *)
                        US1_SymbolGreater
                    | US0_BitZero -> (* BitZero *)
                        US1_SymbolSame
                let v12 : bool =
                    match v11 with
                    | US1_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                1
            else
                let v13 : bool = v0 = 1
                if v13 then
                    let v17 : US1 =
                        match v5 with
                        | US0_BitOne -> (* BitOne *)
                            US1_SymbolGreater
                        | US0_BitZero -> (* BitZero *)
                            US1_SymbolSame
                    let v18 : bool =
                        match v17 with
                        | US1_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    1
                else
                    let v22 : US1 =
                        match v5 with
                        | US0_BitOne -> (* BitOne *)
                            US1_SymbolGreater
                        | US0_BitZero -> (* BitZero *)
                            US1_SymbolSame
                    let v23 : bool =
                        match v22 with
                        | US1_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    if v23 then
                        2
                    else
                        0
        run_16(v26, v6)
    | UH1_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 0
        if v2 then
            true
        else
            let v3 : bool = v0 = 1
            false
and loop_14 (v0 : int32, v1 : UH0, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v0 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_InputEmpty
        let v6 : UH1 = zeros_input_15(v2, v5)
        let v7 : int32 = 2
        let v8 : bool = run_16(v7, v6)
        let v9 : bool = accepts_3(v1, v6)
        let v11 : bool =
            if v8 then
                v9
            else
                let v10 : bool = false = v9
                v10
        let v15 : int32 =
            if v11 then
                if v8 then
                    let v12 : int32 = v3 + 1
                    v12
                else
                    v3
            else
                failwith<int32> "brzozowski-compiled-core-disagrees-on-zero-run"
        let v16 : US0 = US0_BitOne
        let v17 : UH1 = UH1_InputEmpty
        let v18 : UH1 = UH1_InputCons(v16, v17)
        let v19 : UH1 = zeros_input_15(v2, v18)
        let v20 : int32 = 2
        let v21 : bool = run_16(v20, v19)
        let v22 : bool = accepts_3(v1, v19)
        let v24 : bool =
            if v21 then
                v22
            else
                let v23 : bool = false = v22
                v23
        let v28 : int32 =
            if v24 then
                if v21 then
                    let v25 : int32 = v15 + 1
                    v25
                else
                    v15
            else
                failwith<int32> "brzozowski-compiled-core-disagrees-on-zero-run"
        let v29 : int32 = v2 + 1
        loop_14(v0, v1, v29, v28)
and run_17 (v0 : int32, v1 : UH3) : bool =
    match v1 with
    | UH3_InputCons(v5, v6) -> (* InputCons *)
        let v7 : bool = v0 = 0
        let v47 : int32 =
            if v7 then
                let v10 : US1 =
                    match v5 with
                    | US3_TriA -> (* TriA *)
                        US1_SymbolSame
                    | _ ->
                        US1_SymbolGreater
                let v11 : bool =
                    match v10 with
                    | US1_SymbolSame -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v11 then
                    0
                else
                    let v17 : US1 =
                        match v5 with
                        | US3_TriA -> (* TriA *)
                            US1_SymbolLess
                        | US3_TriB -> (* TriB *)
                            US1_SymbolSame
                        | US3_TriC -> (* TriC *)
                            US1_SymbolGreater
                    let v18 : bool =
                        match v17 with
                        | US1_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    if v18 then
                        0
                    else
                        1
            else
                let v21 : bool = v0 = 1
                if v21 then
                    let v24 : US1 =
                        match v5 with
                        | US3_TriA -> (* TriA *)
                            US1_SymbolSame
                        | _ ->
                            US1_SymbolGreater
                    let v25 : bool =
                        match v24 with
                        | US1_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    if v25 then
                        2
                    else
                        let v31 : US1 =
                            match v5 with
                            | US3_TriA -> (* TriA *)
                                US1_SymbolLess
                            | US3_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US3_TriC -> (* TriC *)
                                US1_SymbolGreater
                        let v32 : bool =
                            match v31 with
                            | US1_SymbolSame -> (* SymbolSame *)
                                true
                            | _ ->
                                false
                        2
                else
                    let v36 : US1 =
                        match v5 with
                        | US3_TriA -> (* TriA *)
                            US1_SymbolSame
                        | _ ->
                            US1_SymbolGreater
                    let v37 : bool =
                        match v36 with
                        | US1_SymbolSame -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    if v37 then
                        2
                    else
                        let v43 : US1 =
                            match v5 with
                            | US3_TriA -> (* TriA *)
                                US1_SymbolLess
                            | US3_TriB -> (* TriB *)
                                US1_SymbolSame
                            | US3_TriC -> (* TriC *)
                                US1_SymbolGreater
                        let v44 : bool =
                            match v43 with
                            | US1_SymbolSame -> (* SymbolSame *)
                                true
                            | _ ->
                                false
                        2
        run_17(v47, v6)
    | UH3_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 0
        if v2 then
            false
        else
            let v3 : bool = v0 = 1
            v3
and regex_compare_23 (v0 : UH2, v1 : UH2) : US1 =
    match v0 with
    | UH2_RegexAlt(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = regex_compare_23(v59, v61)
            match v63 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_23(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_SymbolGreater
    | UH2_RegexCat(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v40, v41) -> (* RegexCat *)
            let v42 : US1 = regex_compare_23(v34, v40)
            match v42 with
            | US1_SymbolSame -> (* SymbolSame *)
                regex_compare_23(v35, v41)
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
            regex_compare_23(v50, v54)
        | _ ->
            US1_SymbolGreater
and alt_insert_sorted_22 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_23(v0, v2)
        match v4 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            let v6 : UH2 = alt_insert_sorted_22(v0, v3)
            UH2_RegexAlt(v2, v6)
        | US1_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_23(v0, v1)
        match v11 with
        | US1_SymbolGreater -> (* SymbolGreater *)
            UH2_RegexAlt(v1, v0)
        | US1_SymbolLess -> (* SymbolLess *)
            UH2_RegexAlt(v0, v1)
        | US1_SymbolSame -> (* SymbolSame *)
            v1
and make_alt_21 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = alt_insert_sorted_22(v2, v1)
        make_alt_21(v3, v4)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_22(v0, v1)
and regex_equal_25 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_RegexAlt(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH2_RegexAlt(v26, v27) -> (* RegexAlt *)
            let v28 : bool = regex_equal_25(v24, v26)
            if v28 then
                regex_equal_25(v25, v27)
            else
                false
        | _ ->
            false
    | UH2_RegexCat(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH2_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : bool = regex_equal_25(v32, v34)
            if v36 then
                regex_equal_25(v33, v35)
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
            regex_equal_25(v40, v41)
        | _ ->
            false
and make_cat_24 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = make_cat_24(v13, v1)
                        UH2_RegexCat(v12, v14)
                    | UH2_RegexStar(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_RegexStar(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_25(v4, v5)
                            if v6 then
                                UH2_RegexStar(v4)
                            else
                                UH2_RegexCat(v0, v1)
                        | _ ->
                            UH2_RegexCat(v0, v1)
                    | _ ->
                        UH2_RegexCat(v0, v1)
and make_star_26 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEpsilon
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v3) -> (* RegexStar *)
        UH2_RegexStar(v3)
    | _ ->
        UH2_RegexStar(v0)
and normalize_20 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = normalize_20(v5)
        let v8 : UH2 = normalize_20(v6)
        make_alt_21(v7, v8)
    | UH2_RegexCat(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = normalize_20(v10)
        let v13 : UH2 = normalize_20(v11)
        make_cat_24(v12, v13)
    | UH2_RegexChar(v3) -> (* RegexChar *)
        UH2_RegexChar(v3)
    | UH2_RegexEmpty -> (* RegexEmpty *)
        UH2_RegexEmpty
    | UH2_RegexEpsilon -> (* RegexEpsilon *)
        UH2_RegexEpsilon
    | UH2_RegexStar(v15) -> (* RegexStar *)
        let v16 : UH2 = normalize_20(v15)
        make_star_26(v16)
and nullable_28 (v0 : UH2) : US2 =
    match v0 with
    | UH2_RegexAlt(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_28(v5)
        let v8 : US2 = nullable_28(v6)
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
        let v18 : US2 = nullable_28(v16)
        let v19 : US2 = nullable_28(v17)
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
and derivative_27 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_RegexAlt(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = derivative_27(v25, v1)
        let v28 : UH2 = derivative_27(v26, v1)
        make_alt_21(v27, v28)
    | UH2_RegexCat(v30, v31) -> (* RegexCat *)
        let v32 : US2 = nullable_28(v30)
        match v32 with
        | US2_NonNullable -> (* NonNullable *)
            let v37 : UH2 = derivative_27(v30, v1)
            make_cat_24(v37, v31)
        | US2_Nullable -> (* Nullable *)
            let v33 : UH2 = derivative_27(v30, v1)
            let v34 : UH2 = make_cat_24(v33, v31)
            let v35 : UH2 = derivative_27(v31, v1)
            make_alt_21(v34, v35)
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
        let v42 : UH2 = derivative_27(v41, v1)
        let v43 : UH2 = make_star_26(v41)
        make_cat_24(v42, v43)
and canonical_derivative_19 (v0 : UH2, v1 : US3) : UH2 =
    let v2 : UH2 = normalize_20(v0)
    let v3 : UH2 = derivative_27(v2, v1)
    normalize_20(v3)
and accepts_18 (v0 : UH2, v1 : UH3) : bool =
    match v1 with
    | UH3_InputCons(v6, v7) -> (* InputCons *)
        let v8 : UH2 = canonical_derivative_19(v0, v6)
        accepts_18(v8, v7)
    | UH3_InputEmpty -> (* InputEmpty *)
        let v2 : UH2 = normalize_20(v0)
        let v3 : US2 = nullable_28(v2)
        match v3 with
        | US2_NonNullable -> (* NonNullable *)
            false
        | US2_Nullable -> (* Nullable *)
            true
let v0 : int32 = 200
let v1 : int32 = 32
let v2 : int32 = 16
let v3 : US0 = US0_BitZero
let v4 : UH0 = UH0_RegexChar(v3)
let v5 : US0 = US0_BitOne
let v6 : UH0 = UH0_RegexChar(v5)
let v7 : UH0 = UH0_RegexAlt(v4, v6)
let v8 : UH0 = UH0_RegexStar(v7)
let v9 : US0 = US0_BitZero
let v10 : UH0 = UH0_RegexChar(v9)
let v11 : UH0 = UH0_RegexCat(v8, v10)
let v12 : uint64 = 1UL
let v13 : int32 = 0
let v14 : int32 = loop_0(v1, v11, v0, v12, v13)
let v15 : bool = v14 = 93
if v15 then
    ()
else
    failwith<unit> "brzozowski-compiled-ends-with-zero-count"
let v16 : US0 = US0_BitZero
let v17 : UH0 = UH0_RegexChar(v16)
let v18 : US0 = US0_BitZero
let v19 : UH0 = UH0_RegexChar(v18)
let v20 : US0 = US0_BitZero
let v21 : UH0 = UH0_RegexChar(v20)
let v22 : UH0 = UH0_RegexCat(v19, v21)
let v23 : UH0 = UH0_RegexAlt(v17, v22)
let v24 : UH0 = UH0_RegexStar(v23)
let v25 : US0 = US0_BitOne
let v26 : UH0 = UH0_RegexChar(v25)
let v27 : UH0 = UH0_RegexCat(v24, v26)
let v28 : int32 = 1
let v29 : int32 = 0
let v30 : int32 = loop_14(v2, v27, v28, v29)
let v31 : bool = v30 = 16
if v31 then
    ()
else
    failwith<unit> "brzozowski-compiled-zero-runs-count"
let v32 : US3 = US3_TriA
let v33 : UH2 = UH2_RegexChar(v32)
let v34 : US3 = US3_TriB
let v35 : UH2 = UH2_RegexChar(v34)
let v36 : UH2 = UH2_RegexAlt(v33, v35)
let v37 : UH2 = UH2_RegexStar(v36)
let v38 : US3 = US3_TriC
let v39 : UH2 = UH2_RegexChar(v38)
let v40 : UH2 = UH2_RegexCat(v37, v39)
let v41 : US3 = US3_TriA
let v42 : US3 = US3_TriB
let v43 : US3 = US3_TriA
let v44 : US3 = US3_TriC
let v45 : UH3 = UH3_InputEmpty
let v46 : UH3 = UH3_InputCons(v44, v45)
let v47 : UH3 = UH3_InputCons(v43, v46)
let v48 : UH3 = UH3_InputCons(v42, v47)
let v49 : UH3 = UH3_InputCons(v41, v48)
let v50 : US3 = US3_TriA
let v51 : US3 = US3_TriB
let v52 : US3 = US3_TriA
let v53 : US3 = US3_TriB
let v54 : UH3 = UH3_InputEmpty
let v55 : UH3 = UH3_InputCons(v53, v54)
let v56 : UH3 = UH3_InputCons(v52, v55)
let v57 : UH3 = UH3_InputCons(v51, v56)
let v58 : UH3 = UH3_InputCons(v50, v57)
let v59 : int32 = 0
let v60 : bool = run_17(v59, v49)
let v62 : bool =
    if v60 then
        accepts_18(v40, v49)
    else
        false
let v68 : bool =
    if v62 then
        let v63 : int32 = 0
        let v64 : bool = run_17(v63, v58)
        if v64 then
            false
        else
            let v65 : bool = accepts_18(v40, v58)
            let v66 : bool = v65 = false
            v66
    else
        false
if v68 then
    0
else
    failwith<int32> "brzozowski-compiled-ternary-disagrees"
