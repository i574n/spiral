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
and UH1 =
    | UH1_0
    | UH1_1 of US0 * UH1
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and [<Struct>] US2 =
    | US2_0
    | US2_1
let rec zeros_input_1 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_0
        let v5 : UH1 = UH1_1(v4, v1)
        zeros_input_1(v3, v5)
    else
        v1
and regex_compare_7 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = regex_compare_7(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                regex_compare_7(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = regex_compare_7(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                regex_compare_7(v29, v35)
            | _ ->
                v36
        | UH0_2(v32) -> (* RegexChar *)
            US1_2
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US1_1
                | US0_0 -> (* BitZero *)
                    US1_2
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US1_0
                | US0_0 -> (* BitZero *)
                    US1_1
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH0_5(v44) -> (* RegexStar *)
        match v1 with
        | UH0_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH0_5(v48) -> (* RegexStar *)
            regex_compare_7(v44, v48)
        | _ ->
            US1_2
and alt_insert_sorted_6 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = regex_compare_7(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH0 = alt_insert_sorted_6(v0, v3)
            UH0_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH0_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = regex_compare_7(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and make_alt_5 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = alt_insert_sorted_6(v2, v1)
        make_alt_5(v3, v4)
    | UH0_0 -> (* RegexEmpty *)
        v1
    | _ ->
        alt_insert_sorted_6(v0, v1)
and regex_equal_9 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = regex_equal_9(v18, v20)
            if v22 then
                regex_equal_9(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = regex_equal_9(v26, v28)
            if v30 then
                regex_equal_9(v27, v29)
            else
                false
        | _ ->
            false
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
            let v15 : US1 =
                match v4 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US1_1
                    | US0_0 -> (* BitZero *)
                        US1_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US1_0
                    | US0_0 -> (* BitZero *)
                        US1_1
            match v15 with
            | US1_1 -> (* SymbolSame *)
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
            regex_equal_9(v34, v35)
        | _ ->
            false
and make_cat_8 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = make_cat_8(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = regex_equal_9(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and make_star_10 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and normalize_4 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = normalize_4(v5)
        let v8 : UH0 = normalize_4(v6)
        make_alt_5(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = normalize_4(v10)
        let v13 : UH0 = normalize_4(v11)
        make_cat_8(v12, v13)
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = normalize_4(v15)
        make_star_10(v16)
and nullable_12 (v0 : UH0) : US2 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = nullable_12(v5)
        let v8 : US2 = nullable_12(v6)
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
        let v18 : US2 = nullable_12(v16)
        let v19 : US2 = nullable_12(v17)
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
and derivative_11 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = derivative_11(v19, v1)
        let v22 : UH0 = derivative_11(v20, v1)
        make_alt_5(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = nullable_12(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = derivative_11(v24, v1)
            make_cat_8(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = derivative_11(v24, v1)
            let v28 : UH0 = make_cat_8(v27, v25)
            let v29 : UH0 = derivative_11(v25, v1)
            make_alt_5(v28, v29)
    | UH0_2(v4) -> (* RegexChar *)
        let v14 : US1 =
            match v4 with
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US1_1
                | US0_0 -> (* BitZero *)
                    US1_2
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US1_0
                | US0_0 -> (* BitZero *)
                    US1_1
        let v15 : bool =
            match v14 with
            | US1_1 -> (* SymbolSame *)
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
        let v36 : UH0 = derivative_11(v35, v1)
        let v37 : UH0 = make_star_10(v35)
        make_cat_8(v36, v37)
and canonical_derivative_3 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = normalize_4(v0)
    let v3 : UH0 = derivative_11(v2, v1)
    normalize_4(v3)
and accepts_2 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v6, v7) -> (* InputCons *)
        let v8 : UH0 = canonical_derivative_3(v0, v6)
        accepts_2(v8, v7)
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH0 = normalize_4(v0)
        let v3 : US2 = nullable_12(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and loop_0 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_0
        let v6 : UH1 = zeros_input_1(v2, v5)
        let v7 : bool = accepts_2(v0, v6)
        let v9 : int32 =
            if v7 then
                let v8 : int32 = v3 + 1
                v8
            else
                v3
        let v10 : US0 = US0_1
        let v11 : UH1 = UH1_0
        let v12 : UH1 = UH1_1(v10, v11)
        let v13 : UH1 = zeros_input_1(v2, v12)
        let v14 : bool = accepts_2(v0, v13)
        let v16 : int32 =
            if v14 then
                let v15 : int32 = v9 + 1
                v15
            else
                v9
        let v17 : int32 = v2 + 1
        loop_0(v0, v1, v17, v16)
let v0 : int32 = 26
let v1 : US0 = US0_0
let v2 : UH0 = UH0_2(v1)
let v3 : US0 = US0_0
let v4 : UH0 = UH0_2(v3)
let v5 : US0 = US0_0
let v6 : UH0 = UH0_2(v5)
let v7 : UH0 = UH0_4(v4, v6)
let v8 : UH0 = UH0_3(v2, v7)
let v9 : UH0 = UH0_5(v8)
let v10 : US0 = US0_1
let v11 : UH0 = UH0_2(v10)
let v12 : UH0 = UH0_4(v9, v11)
let v13 : int32 = 0
let v14 : int32 = 1
let v15 : int32 = loop_0(v12, v0, v14, v13)
let v16 : bool = v15 = 26
if v16 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
0
