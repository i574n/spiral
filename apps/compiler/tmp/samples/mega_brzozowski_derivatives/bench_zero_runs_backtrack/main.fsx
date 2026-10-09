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
and UH2 =
    | UH2_RegexListNil
    | UH2_RegexListCons of UH0 * UH2
and [<Struct>] US1 =
    | US1_SymbolLess
    | US1_SymbolSame
    | US1_SymbolGreater
let rec zeros_input_1 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_BitZero
        let v5 : UH1 = UH1_InputCons(v4, v1)
        zeros_input_1(v3, v5)
    else
        v1
and backtrack_stack_2 (v0 : UH2, v1 : UH1) : bool =
    match v0 with
    | UH2_RegexListCons(v6, v7) -> (* RegexListCons *)
        match v6 with
        | UH0_RegexAlt(v27, v28) -> (* RegexAlt *)
            let v29 : UH2 = UH2_RegexListCons(v27, v7)
            let v30 : bool = backtrack_stack_2(v29, v1)
            if v30 then
                true
            else
                let v31 : UH2 = UH2_RegexListCons(v28, v7)
                backtrack_stack_2(v31, v1)
        | UH0_RegexCat(v34, v35) -> (* RegexCat *)
            let v36 : UH2 = UH2_RegexListCons(v35, v7)
            let v37 : UH2 = UH2_RegexListCons(v34, v36)
            backtrack_stack_2(v37, v1)
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
                    backtrack_stack_2(v7, v11)
                else
                    false
            | UH1_InputEmpty -> (* InputEmpty *)
                false
        | UH0_RegexEmpty -> (* RegexEmpty *)
            false
        | UH0_RegexEpsilon -> (* RegexEpsilon *)
            backtrack_stack_2(v7, v1)
        | UH0_RegexStar(v39) -> (* RegexStar *)
            let v40 : UH2 = UH2_RegexListCons(v39, v0)
            let v41 : bool = backtrack_stack_2(v40, v1)
            if v41 then
                true
            else
                backtrack_stack_2(v7, v1)
    | UH2_RegexListNil -> (* RegexListNil *)
        match v1 with
        | UH1_InputCons(v2, v3) -> (* InputCons *)
            false
        | UH1_InputEmpty -> (* InputEmpty *)
            true
and loop_0 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_InputEmpty
        let v6 : UH1 = zeros_input_1(v2, v5)
        let v7 : UH2 = UH2_RegexListNil
        let v8 : UH2 = UH2_RegexListCons(v0, v7)
        let v9 : bool = backtrack_stack_2(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : US0 = US0_BitOne
        let v13 : UH1 = UH1_InputEmpty
        let v14 : UH1 = UH1_InputCons(v12, v13)
        let v15 : UH1 = zeros_input_1(v2, v14)
        let v16 : UH2 = UH2_RegexListNil
        let v17 : UH2 = UH2_RegexListCons(v0, v16)
        let v18 : bool = backtrack_stack_2(v17, v15)
        let v20 : int32 =
            if v18 then
                let v19 : int32 = v11 + 1
                v19
            else
                v11
        let v21 : int32 = v2 + 1
        loop_0(v0, v1, v21, v20)
let v0 : int32 = 26
let v1 : US0 = US0_BitZero
let v2 : UH0 = UH0_RegexChar(v1)
let v3 : US0 = US0_BitZero
let v4 : UH0 = UH0_RegexChar(v3)
let v5 : US0 = US0_BitZero
let v6 : UH0 = UH0_RegexChar(v5)
let v7 : UH0 = UH0_RegexCat(v4, v6)
let v8 : UH0 = UH0_RegexAlt(v2, v7)
let v9 : UH0 = UH0_RegexStar(v8)
let v10 : US0 = US0_BitOne
let v11 : UH0 = UH0_RegexChar(v10)
let v12 : UH0 = UH0_RegexCat(v9, v11)
let v13 : int32 = 0
let v14 : int32 = 1
let v15 : int32 = loop_0(v12, v0, v14, v13)
let v16 : bool = v15 = 26
if v16 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
0
