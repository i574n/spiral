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
let rec loop_0 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 8192
    if v2 then
        v0.[int v1] <- 0
        let v3 : int32 = v1 + 1
        loop_0(v0, v3)
and loop_1 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 1
    if v2 then
        v0.[int v1] <- 0
        let v3 : int32 = v1 + 1
        loop_1(v0, v3)
and probe_3 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : int32) : int32 =
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
            probe_3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47)
and interned_node_2 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32) : int32 =
    let v10 : int32 = v7 * 1024
    let v11 : int32 = v10 + v8
    let v12 : int32 = v11 * 4099
    let v13 : int32 = v12 + v9
    let v14 : int32 = v13 &&& 8191
    probe_3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
and interned_alt_insert_6 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
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
                interned_node_2(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
            else
                let v16 : bool = v7 = v12
                if v16 then
                    v8
                else
                    let v17 : int32 = 3
                    let v18 : int32 = v2.[int v8]
                    let v19 : int32 = interned_alt_insert_6(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                    interned_node_2(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
        else
            let v23 : bool = v7 < v8
            if v23 then
                let v24 : int32 = 3
                interned_node_2(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
            else
                let v26 : bool = v7 = v8
                if v26 then
                    v8
                else
                    let v27 : int32 = 3
                    interned_node_2(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
and interned_make_alt_5 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v7 = 0
    if v9 then
        v8
    else
        let v10 : int32 = v0.[int v7]
        let v11 : bool = v10 = 3
        if v11 then
            let v12 : int32 = v2.[int v7]
            let v13 : int32 = v1.[int v7]
            let v14 : int32 = interned_alt_insert_6(v0, v1, v2, v3, v4, v5, v6, v13, v8)
            interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v12, v14)
        else
            interned_alt_insert_6(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and interned_make_cat_7 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
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
                            interned_node_2(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                    else
                        let v24 : int32 = v0.[int v7]
                        let v25 : bool = v24 = 4
                        if v25 then
                            let v26 : int32 = 4
                            let v27 : int32 = v1.[int v7]
                            let v28 : int32 = v2.[int v7]
                            let v29 : int32 = interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                            interned_node_2(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                        else
                            let v31 : int32 = 4
                            interned_node_2(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
and interned_of_regex_raw_4 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : UH0) : int32 =
    match v7 with
    | UH0_3(v14, v15) -> (* RegexAlt *)
        let v16 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v14)
        let v17 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v15)
        interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v16, v17)
    | UH0_4(v19, v20) -> (* RegexCat *)
        let v21 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v19)
        let v22 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v20)
        interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v21, v22)
    | UH0_2(v8) -> (* RegexChar *)
        let v9 : int32 = 2
        let v11 : int32 =
            match v8 with
            | US0_1 -> (* BitOne *)
                1
            | US0_0 -> (* BitZero *)
                0
        let v12 : int32 = 0
        interned_node_2(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
    | UH0_0 -> (* RegexEmpty *)
        0
    | UH0_1 -> (* RegexEpsilon *)
        1
    | UH0_5(v24) -> (* RegexStar *)
        let v25 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v24)
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
                interned_node_2(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
and zeros_input_9 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_0
        let v5 : UH1 = UH1_1(v4, v1)
        zeros_input_9(v3, v5)
    else
        v1
and interned_derivative_raw_12 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
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
                        let v21 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                        let v22 : int32 = v2.[int v7]
                        let v23 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                        interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                    else
                        let v25 : bool = v13 = 4
                        if v25 then
                            let v26 : int32 = v1.[int v7]
                            let v27 : int32 = v2.[int v7]
                            let v28 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                            let v29 : int32 = interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                            let v30 : int32 = v3.[int v26]
                            let v31 : bool = v30 = 1
                            if v31 then
                                let v32 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                                interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                            else
                                v29
                        else
                            let v35 : int32 = v1.[int v7]
                            let v36 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                            interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v36, v7)
        let v42 : int32 = v41 + 1
        v5.[int v10] <- v42
        v41
    else
        let v43 : int32 = v11 - 1
        v43
and loop_11 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    let v9 : bool = v7 = 0
    if v9 then
        false
    else
        match v8 with
        | UH1_1(v12, v13) -> (* InputCons *)
            let v15 : int32 =
                match v12 with
                | US0_1 -> (* BitOne *)
                    1
                | US0_0 -> (* BitZero *)
                    0
            let v16 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v7, v15)
            loop_11(v0, v1, v2, v3, v4, v5, v6, v16, v13)
        | UH1_0 -> (* InputEmpty *)
            let v10 : int32 = v3.[int v7]
            let v11 : bool = v10 = 1
            v11
and interned_accepts_10 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    loop_11(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and loop_8 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : int32) : int32 =
    let v11 : bool = v7 < v9
    if v11 then
        v10
    else
        let v12 : UH1 = UH1_0
        let v13 : UH1 = zeros_input_9(v9, v12)
        let v14 : bool = interned_accepts_10(v0, v1, v2, v3, v4, v5, v6, v8, v13)
        let v16 : int32 =
            if v14 then
                let v15 : int32 = v10 + 1
                v15
            else
                v10
        let v17 : US0 = US0_1
        let v18 : UH1 = UH1_0
        let v19 : UH1 = UH1_1(v17, v18)
        let v20 : UH1 = zeros_input_9(v9, v19)
        let v21 : bool = interned_accepts_10(v0, v1, v2, v3, v4, v5, v6, v8, v20)
        let v23 : int32 =
            if v21 then
                let v22 : int32 = v16 + 1
                v22
            else
                v16
        let v24 : int32 = v9 + 1
        loop_8(v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23)
let v0 : int32 = 26
let v1 : (int32 []) = Array.zeroCreate<int32> (4096)
let v2 : (int32 []) = Array.zeroCreate<int32> (4096)
let v3 : (int32 []) = Array.zeroCreate<int32> (4096)
let v4 : (int32 []) = Array.zeroCreate<int32> (4096)
let v5 : (int32 []) = Array.zeroCreate<int32> (8192)
let v6 : (int32 []) = Array.zeroCreate<int32> (8192)
let v7 : (int32 []) = Array.zeroCreate<int32> (1)
let v8 : int32 = 0
loop_0(v5, v8)
let v9 : int32 = 0
loop_0(v6, v9)
let v10 : int32 = 0
loop_1(v7, v10)
let v11 : int32 = 0
let v12 : int32 = 0
let v13 : int32 = 0
let v14 : int32 = interned_node_2(v1, v2, v3, v4, v5, v6, v7, v11, v12, v13)
let v15 : int32 = 1
let v16 : int32 = 0
let v17 : int32 = 0
let v18 : int32 = interned_node_2(v1, v2, v3, v4, v5, v6, v7, v15, v16, v17)
let v19 : bool = v14 = 0
let v21 : bool =
    if v19 then
        let v20 : bool = v18 = 1
        v20
    else
        false
let struct (v29 : (int32 []), v30 : (int32 []), v31 : (int32 []), v32 : (int32 []), v33 : (int32 []), v34 : (int32 []), v35 : (int32 [])) =
    if v21 then
        struct (v1, v2, v3, v4, v5, v6, v7)
    else
        failwith<struct ((int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []))> "brzozowski-interned-store-init"
let v36 : US0 = US0_0
let v37 : UH0 = UH0_2(v36)
let v38 : US0 = US0_0
let v39 : UH0 = UH0_2(v38)
let v40 : US0 = US0_0
let v41 : UH0 = UH0_2(v40)
let v42 : UH0 = UH0_4(v39, v41)
let v43 : UH0 = UH0_3(v37, v42)
let v44 : UH0 = UH0_5(v43)
let v45 : US0 = US0_1
let v46 : UH0 = UH0_2(v45)
let v47 : UH0 = UH0_4(v44, v46)
let v48 : int32 = interned_of_regex_raw_4(v29, v30, v31, v32, v33, v34, v35, v47)
let v49 : int32 = 1
let v50 : int32 = 0
let v51 : int32 = loop_8(v29, v30, v31, v32, v33, v34, v35, v0, v48, v49, v50)
let v52 : bool = v51 = 26
if v52 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
0
