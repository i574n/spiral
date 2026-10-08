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
and UH2 =
    | UH2_0
    | UH2_1 of UH0 * UH2
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
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
                let v11 : US0 = US0_0
                v11
            else
                let v12 : US0 = US0_1
                v12
        let v14 : UH1 = UH1_1(v13, v2)
        random_bit_input_1(v6, v7, v14)
    else
        struct (v2, v0)
and backtrack_stack_2 (v0 : UH2, v1 : UH1) : bool =
    match v0 with
    | UH2_1(v6, v7) -> (* RegexListCons *)
        match v6 with
        | UH0_3(v27, v28) -> (* RegexAlt *)
            let v29 : UH2 = UH2_1(v27, v7)
            let v30 : bool = backtrack_stack_2(v29, v1)
            if v30 then
                true
            else
                let v31 : UH2 = UH2_1(v28, v7)
                backtrack_stack_2(v31, v1)
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : UH2 = UH2_1(v35, v7)
            let v37 : UH2 = UH2_1(v34, v36)
            backtrack_stack_2(v37, v1)
        | UH0_2(v9) -> (* RegexChar *)
            match v1 with
            | UH1_1(v10, v11) -> (* InputCons *)
                let v21 : US1 =
                    match v9 with
                    | US0_1 -> (* BitOne *)
                        match v10 with
                        | US0_1 -> (* BitOne *)
                            US1_1
                        | US0_0 -> (* BitZero *)
                            US1_2
                    | US0_0 -> (* BitZero *)
                        match v10 with
                        | US0_1 -> (* BitOne *)
                            US1_0
                        | US0_0 -> (* BitZero *)
                            US1_1
                let v22 : bool =
                    match v21 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v22 then
                    backtrack_stack_2(v7, v11)
                else
                    false
            | UH1_0 -> (* InputEmpty *)
                false
        | UH0_0 -> (* RegexEmpty *)
            false
        | UH0_1 -> (* RegexEpsilon *)
            backtrack_stack_2(v7, v1)
        | UH0_5(v39) -> (* RegexStar *)
            let v40 : UH2 = UH2_1(v39, v0)
            let v41 : bool = backtrack_stack_2(v40, v1)
            if v41 then
                true
            else
                backtrack_stack_2(v7, v1)
    | UH2_0 -> (* RegexListNil *)
        match v1 with
        | UH1_1(v2, v3) -> (* InputCons *)
            false
        | UH1_0 -> (* InputEmpty *)
            true
and loop_0 (v0 : UH0, v1 : int32, v2 : int32, v3 : uint64, v4 : int32) : int32 =
    let v5 : bool = 0 < v2
    if v5 then
        let v6 : UH1 = UH1_0
        let struct (v7 : UH1, v8 : uint64) = random_bit_input_1(v3, v1, v6)
        let v9 : UH2 = UH2_0
        let v10 : UH2 = UH2_1(v0, v9)
        let v11 : bool = backtrack_stack_2(v10, v7)
        let v13 : int32 =
            if v11 then
                let v12 : int32 = v4 + 1
                v12
            else
                v4
        let v14 : int32 = v2 - 1
        loop_0(v0, v1, v14, v8, v13)
    else
        v4
let v0 : int32 = 2000
let v1 : int32 = 32
let v2 : US0 = US0_0
let v3 : UH0 = UH0_2(v2)
let v4 : US0 = US0_1
let v5 : UH0 = UH0_2(v4)
let v6 : UH0 = UH0_3(v3, v5)
let v7 : UH0 = UH0_5(v6)
let v8 : US0 = US0_0
let v9 : UH0 = UH0_2(v8)
let v10 : UH0 = UH0_4(v7, v9)
let v11 : US0 = US0_0
let v12 : UH0 = UH0_2(v11)
let v13 : US0 = US0_1
let v14 : UH0 = UH0_2(v13)
let v15 : UH0 = UH0_3(v12, v14)
let v16 : UH0 = UH0_5(v15)
let v17 : US0 = US0_1
let v18 : UH0 = UH0_2(v17)
let v19 : US0 = US0_0
let v20 : UH0 = UH0_2(v19)
let v21 : US0 = US0_1
let v22 : UH0 = UH0_2(v21)
let v23 : UH0 = UH0_3(v20, v22)
let v24 : US0 = US0_0
let v25 : UH0 = UH0_2(v24)
let v26 : US0 = US0_1
let v27 : UH0 = UH0_2(v26)
let v28 : UH0 = UH0_3(v25, v27)
let v29 : US0 = US0_0
let v30 : UH0 = UH0_2(v29)
let v31 : US0 = US0_1
let v32 : UH0 = UH0_2(v31)
let v33 : UH0 = UH0_3(v30, v32)
let v34 : UH0 = UH0_4(v28, v33)
let v35 : UH0 = UH0_4(v23, v34)
let v36 : UH0 = UH0_4(v18, v35)
let v37 : UH0 = UH0_4(v16, v36)
let v38 : uint64 = 1UL
let v39 : int32 = 0
let v40 : int32 = loop_0(v10, v1, v0, v38, v39)
let v41 : int32 = loop_0(v37, v1, v0, v38, v39)
let v42 : bool = v40 = 997
if v42 then
    ()
else
    failwith<unit> "brzozowski-bench-ends-with-zero-count"
let v43 : bool = v41 = 985
if v43 then
    ()
else
    failwith<unit> "brzozowski-bench-fourth-from-end-count"
0
