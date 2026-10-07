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
let rec method1 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_0
        let v5 : UH1 = UH1_1(v4, v1)
        method1(v3, v5)
    else
        v1
and method2 (v0 : UH2, v1 : UH1) : bool =
    match v0 with
    | UH2_1(v6, v7) -> (* RegexListCons *)
        match v6 with
        | UH0_3(v27, v28) -> (* RegexAlt *)
            let v29 : UH2 = UH2_1(v27, v7)
            let v30 : bool = method2(v29, v1)
            if v30 then
                true
            else
                let v31 : UH2 = UH2_1(v28, v7)
                method2(v31, v1)
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : UH2 = UH2_1(v35, v7)
            let v37 : UH2 = UH2_1(v34, v36)
            method2(v37, v1)
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
                    method2(v7, v11)
                else
                    false
            | UH1_0 -> (* InputEmpty *)
                false
        | UH0_0 -> (* RegexEmpty *)
            false
        | UH0_1 -> (* RegexEpsilon *)
            method2(v7, v1)
        | UH0_5(v39) -> (* RegexStar *)
            let v40 : UH2 = UH2_1(v39, v0)
            let v41 : bool = method2(v40, v1)
            if v41 then
                true
            else
                method2(v7, v1)
    | UH2_0 -> (* RegexListNil *)
        match v1 with
        | UH1_1(v2, v3) -> (* InputCons *)
            false
        | UH1_0 -> (* InputEmpty *)
            true
and method0 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_0
        let v6 : UH1 = method1(v2, v5)
        let v7 : UH2 = UH2_0
        let v8 : UH2 = UH2_1(v0, v7)
        let v9 : bool = method2(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : US0 = US0_1
        let v13 : UH1 = UH1_0
        let v14 : UH1 = UH1_1(v12, v13)
        let v15 : UH1 = method1(v2, v14)
        let v16 : UH2 = UH2_0
        let v17 : UH2 = UH2_1(v0, v16)
        let v18 : bool = method2(v17, v15)
        let v20 : int32 =
            if v18 then
                let v19 : int32 = v11 + 1
                v19
            else
                v11
        let v21 : int32 = v2 + 1
        method0(v0, v1, v21, v20)
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
let v15 : int32 = method0(v12, v0, v14, v13)
let v16 : bool = v15 = 26
if v16 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
0
