type [<Struct>] US0 =
    | US0_BitZero
    | US0_BitOne
and UH0 =
    | UH0_InputEmpty
    | UH0_InputCons of US0 * UH0
let rec zeros_input_1 (v0 : int32, v1 : UH0) : UH0 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_BitZero
        let v5 : UH0 = UH0_InputCons(v4, v1)
        zeros_input_1(v3, v5)
    else
        v1
and run_2 (v0 : int32, v1 : UH0) : bool =
    match v1 with
    | UH0_InputCons(v3, v4) -> (* InputCons *)
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
            run_2(v19, v4)
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
            run_2(v11, v4)
    | UH0_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 3
        v2
and loop_0 (v0 : int32, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v0 < v1
    if v3 then
        v2
    else
        let v4 : UH0 = UH0_InputEmpty
        let v5 : UH0 = zeros_input_1(v1, v4)
        let v6 : int32 = 0
        let v7 : bool = run_2(v6, v5)
        let v9 : int32 =
            if v7 then
                let v8 : int32 = v2 + 1
                v8
            else
                v2
        let v10 : US0 = US0_BitOne
        let v11 : UH0 = UH0_InputEmpty
        let v12 : UH0 = UH0_InputCons(v10, v11)
        let v13 : UH0 = zeros_input_1(v1, v12)
        let v14 : int32 = 0
        let v15 : bool = run_2(v14, v13)
        let v17 : int32 =
            if v15 then
                let v16 : int32 = v9 + 1
                v16
            else
                v9
        let v18 : int32 = v1 + 1
        loop_0(v0, v18, v17)
let v0 : int32 = 26
let v1 : int32 = 0
let v2 : int32 = 1
let v3 : int32 = loop_0(v0, v2, v1)
let v4 : bool = v3 = 26
if v4 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
0
