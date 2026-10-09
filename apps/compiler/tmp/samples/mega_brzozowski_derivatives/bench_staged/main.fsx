type [<Struct>] US0 =
    | US0_BitZero
    | US0_BitOne
and UH0 =
    | UH0_InputEmpty
    | UH0_InputCons of US0 * UH0
let rec random_bit_input_1 (v0 : uint64, v1 : int32, v2 : UH0) : struct (UH0 * uint64) =
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
        let v14 : UH0 = UH0_InputCons(v13, v2)
        random_bit_input_1(v6, v7, v14)
    else
        struct (v2, v0)
and run_2 (v0 : int32, v1 : UH0) : bool =
    match v1 with
    | UH0_InputCons(v3, v4) -> (* InputCons *)
        match v3 with
        | US0_BitOne -> (* BitOne *)
            let v8 : bool = v0 = 0
            let v9 : int32 = 0
            run_2(v9, v4)
        | US0_BitZero -> (* BitZero *)
            let v5 : bool = v0 = 0
            let v6 : int32 = 1
            run_2(v6, v4)
    | UH0_InputEmpty -> (* InputEmpty *)
        let v2 : bool = v0 = 1
        v2
and loop_0 (v0 : int32, v1 : int32, v2 : uint64, v3 : int32) : int32 =
    let v4 : bool = 0 < v1
    if v4 then
        let v5 : UH0 = UH0_InputEmpty
        let struct (v6 : UH0, v7 : uint64) = random_bit_input_1(v2, v0, v5)
        let v8 : int32 = 0
        let v9 : bool = run_2(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : int32 = v1 - 1
        loop_0(v0, v12, v7, v11)
    else
        v3
and run_4 (v0 : int32, v1 : UH0) : bool =
    match v1 with
    | UH0_InputCons(v17, v18) -> (* InputCons *)
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
            run_4(v79, v18)
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
            run_4(v48, v18)
    | UH0_InputEmpty -> (* InputEmpty *)
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
and loop_3 (v0 : int32, v1 : int32, v2 : uint64, v3 : int32) : int32 =
    let v4 : bool = 0 < v1
    if v4 then
        let v5 : UH0 = UH0_InputEmpty
        let struct (v6 : UH0, v7 : uint64) = random_bit_input_1(v2, v0, v5)
        let v8 : int32 = 0
        let v9 : bool = run_4(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : int32 = v1 - 1
        loop_3(v0, v12, v7, v11)
    else
        v3
let v0 : int32 = 2000
let v1 : int32 = 32
let v2 : uint64 = 1UL
let v3 : int32 = 0
let v4 : int32 = loop_0(v1, v0, v2, v3)
let v5 : int32 = loop_3(v1, v0, v2, v3)
let v6 : bool = v4 = 997
if v6 then
    ()
else
    failwith<unit> "brzozowski-bench-ends-with-zero-count"
let v7 : bool = v5 = 985
if v7 then
    ()
else
    failwith<unit> "brzozowski-bench-fourth-from-end-count"
0
