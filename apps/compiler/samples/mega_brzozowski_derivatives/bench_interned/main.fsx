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
    | UH0_RegexAlt(v14, v15) -> (* RegexAlt *)
        let v16 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v14)
        let v17 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v15)
        interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v16, v17)
    | UH0_RegexCat(v19, v20) -> (* RegexCat *)
        let v21 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v19)
        let v22 : int32 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v20)
        interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v21, v22)
    | UH0_RegexChar(v8) -> (* RegexChar *)
        let v9 : int32 = 2
        let v11 : int32 =
            match v8 with
            | US0_BitOne -> (* BitOne *)
                1
            | US0_BitZero -> (* BitZero *)
                0
        let v12 : int32 = 0
        interned_node_2(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
    | UH0_RegexEmpty -> (* RegexEmpty *)
        0
    | UH0_RegexEpsilon -> (* RegexEpsilon *)
        1
    | UH0_RegexStar(v24) -> (* RegexStar *)
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
and random_bit_input_9 (v0 : uint64, v1 : int32, v2 : UH1) : struct (UH1 * uint64) =
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
        random_bit_input_9(v6, v7, v14)
    else
        struct (v2, v0)
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
        | UH1_InputCons(v12, v13) -> (* InputCons *)
            let v15 : int32 =
                match v12 with
                | US0_BitOne -> (* BitOne *)
                    1
                | US0_BitZero -> (* BitZero *)
                    0
            let v16 : int32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v7, v15)
            loop_11(v0, v1, v2, v3, v4, v5, v6, v16, v13)
        | UH1_InputEmpty -> (* InputEmpty *)
            let v10 : int32 = v3.[int v7]
            let v11 : bool = v10 = 1
            v11
and interned_accepts_10 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    loop_11(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and loop_8 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : uint64, v11 : int32) : int32 =
    let v12 : bool = 0 < v9
    if v12 then
        let v13 : UH1 = UH1_InputEmpty
        let struct (v14 : UH1, v15 : uint64) = random_bit_input_9(v10, v7, v13)
        let v16 : bool = interned_accepts_10(v0, v1, v2, v3, v4, v5, v6, v8, v14)
        let v18 : int32 =
            if v16 then
                let v17 : int32 = v11 + 1
                v17
            else
                v11
        let v19 : int32 = v9 - 1
        loop_8(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18)
    else
        v11
let v0 : int32 = 2000
let v1 : int32 = 32
let v2 : (int32 []) = Array.zeroCreate<int32> (4096)
let v3 : (int32 []) = Array.zeroCreate<int32> (4096)
let v4 : (int32 []) = Array.zeroCreate<int32> (4096)
let v5 : (int32 []) = Array.zeroCreate<int32> (4096)
let v6 : (int32 []) = Array.zeroCreate<int32> (8192)
let v7 : (int32 []) = Array.zeroCreate<int32> (8192)
let v8 : (int32 []) = Array.zeroCreate<int32> (1)
let v9 : int32 = 0
loop_0(v6, v9)
let v10 : int32 = 0
loop_0(v7, v10)
let v11 : int32 = 0
loop_1(v8, v11)
let v12 : int32 = 0
let v13 : int32 = 0
let v14 : int32 = 0
let v15 : int32 = interned_node_2(v2, v3, v4, v5, v6, v7, v8, v12, v13, v14)
let v16 : int32 = 1
let v17 : int32 = 0
let v18 : int32 = 0
let v19 : int32 = interned_node_2(v2, v3, v4, v5, v6, v7, v8, v16, v17, v18)
let v20 : bool = v15 = 0
let v22 : bool =
    if v20 then
        let v21 : bool = v19 = 1
        v21
    else
        false
let struct (v30 : (int32 []), v31 : (int32 []), v32 : (int32 []), v33 : (int32 []), v34 : (int32 []), v35 : (int32 []), v36 : (int32 [])) =
    if v22 then
        struct (v2, v3, v4, v5, v6, v7, v8)
    else
        failwith<struct ((int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []))> "brzozowski-interned-store-init"
let v37 : US0 = US0_BitZero
let v38 : UH0 = UH0_RegexChar(v37)
let v39 : US0 = US0_BitOne
let v40 : UH0 = UH0_RegexChar(v39)
let v41 : UH0 = UH0_RegexAlt(v38, v40)
let v42 : UH0 = UH0_RegexStar(v41)
let v43 : US0 = US0_BitZero
let v44 : UH0 = UH0_RegexChar(v43)
let v45 : UH0 = UH0_RegexCat(v42, v44)
let v46 : int32 = interned_of_regex_raw_4(v30, v31, v32, v33, v34, v35, v36, v45)
let v47 : uint64 = 1UL
let v48 : int32 = 0
let v49 : int32 = loop_8(v30, v31, v32, v33, v34, v35, v36, v1, v46, v0, v47, v48)
let v50 : US0 = US0_BitZero
let v51 : UH0 = UH0_RegexChar(v50)
let v52 : US0 = US0_BitOne
let v53 : UH0 = UH0_RegexChar(v52)
let v54 : UH0 = UH0_RegexAlt(v51, v53)
let v55 : UH0 = UH0_RegexStar(v54)
let v56 : US0 = US0_BitOne
let v57 : UH0 = UH0_RegexChar(v56)
let v58 : US0 = US0_BitZero
let v59 : UH0 = UH0_RegexChar(v58)
let v60 : US0 = US0_BitOne
let v61 : UH0 = UH0_RegexChar(v60)
let v62 : UH0 = UH0_RegexAlt(v59, v61)
let v63 : US0 = US0_BitZero
let v64 : UH0 = UH0_RegexChar(v63)
let v65 : US0 = US0_BitOne
let v66 : UH0 = UH0_RegexChar(v65)
let v67 : UH0 = UH0_RegexAlt(v64, v66)
let v68 : US0 = US0_BitZero
let v69 : UH0 = UH0_RegexChar(v68)
let v70 : US0 = US0_BitOne
let v71 : UH0 = UH0_RegexChar(v70)
let v72 : UH0 = UH0_RegexAlt(v69, v71)
let v73 : UH0 = UH0_RegexCat(v67, v72)
let v74 : UH0 = UH0_RegexCat(v62, v73)
let v75 : UH0 = UH0_RegexCat(v57, v74)
let v76 : UH0 = UH0_RegexCat(v55, v75)
let v77 : int32 = interned_of_regex_raw_4(v30, v31, v32, v33, v34, v35, v36, v76)
let v78 : uint64 = 1UL
let v79 : int32 = 0
let v80 : int32 = loop_8(v30, v31, v32, v33, v34, v35, v36, v1, v77, v0, v78, v79)
let v81 : bool = v49 = 997
if v81 then
    ()
else
    failwith<unit> "brzozowski-bench-ends-with-zero-count"
let v82 : bool = v80 = 985
if v82 then
    ()
else
    failwith<unit> "brzozowski-bench-fourth-from-end-count"
0
