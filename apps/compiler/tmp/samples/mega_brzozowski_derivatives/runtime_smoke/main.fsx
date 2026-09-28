type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0
    | UH0_1 of US0 * UH0
and UH1 =
    | UH1_0
    | UH1_1
    | UH1_2 of US0
    | UH1_3 of UH1 * UH1
    | UH1_4 of UH1 * UH1
    | UH1_5 of UH1
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and [<Struct>] US2 =
    | US2_0
    | US2_1
and [<Struct>] US3 =
    | US3_0 of f0_0 : UH1 * f0_1 : UH0
and [<Struct>] US4 =
    | US4_1 of f1_0 : UH1 * f1_1 : UH0 * f1_2 : bool
let rec method5 (v0 : UH1, v1 : UH1) : US1 =
    match v0 with
    | UH1_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH1_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method5(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method5(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH1_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH1_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method5(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method5(v29, v35)
            | _ ->
                v36
        | UH1_2(v32) -> (* RegexChar *)
            US1_2
        | UH1_0 -> (* RegexEmpty *)
            US1_2
        | UH1_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH1_2(v10) -> (* RegexChar *)
        match v1 with
        | UH1_2(v13) -> (* RegexChar *)
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
        | UH1_0 -> (* RegexEmpty *)
            US1_2
        | UH1_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH1_0 -> (* RegexEmpty *)
        match v1 with
        | UH1_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH1_1 -> (* RegexEpsilon *)
        match v1 with
        | UH1_0 -> (* RegexEmpty *)
            US1_2
        | UH1_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH1_5(v44) -> (* RegexStar *)
        match v1 with
        | UH1_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH1_5(v48) -> (* RegexStar *)
            method5(v44, v48)
        | _ ->
            US1_2
and method4 (v0 : UH1, v1 : UH1) : UH1 =
    match v1 with
    | UH1_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method5(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH1 = method4(v0, v3)
            UH1_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH1_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH1_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method5(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH1_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH1_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method3 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH1 = method4(v2, v1)
        method3(v3, v4)
    | UH1_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method4(v0, v1)
and method7 (v0 : UH1, v1 : UH1) : bool =
    match v0 with
    | UH1_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH1_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method7(v18, v20)
            if v22 then
                method7(v19, v21)
            else
                false
        | _ ->
            false
    | UH1_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH1_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method7(v26, v28)
            if v30 then
                method7(v27, v29)
            else
                false
        | _ ->
            false
    | UH1_2(v4) -> (* RegexChar *)
        match v1 with
        | UH1_2(v5) -> (* RegexChar *)
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
    | UH1_0 -> (* RegexEmpty *)
        match v1 with
        | UH1_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH1_1 -> (* RegexEpsilon *)
        match v1 with
        | UH1_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH1_5(v34) -> (* RegexStar *)
        match v1 with
        | UH1_5(v35) -> (* RegexStar *)
            method7(v34, v35)
        | _ ->
            false
and method6 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexEmpty *)
        UH1_0
    | _ ->
        match v1 with
        | UH1_0 -> (* RegexEmpty *)
            UH1_0
        | _ ->
            match v0 with
            | UH1_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH1_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH1_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH1 = method6(v13, v1)
                        UH1_4(v12, v14)
                    | UH1_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH1_5(v5) -> (* RegexStar *)
                            let v6 : bool = method7(v4, v5)
                            if v6 then
                                UH1_5(v4)
                            else
                                UH1_4(v0, v1)
                        | _ ->
                            UH1_4(v0, v1)
                    | _ ->
                        UH1_4(v0, v1)
and method8 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexEmpty *)
        UH1_1
    | UH1_1 -> (* RegexEpsilon *)
        UH1_1
    | UH1_5(v3) -> (* RegexStar *)
        UH1_5(v3)
    | _ ->
        UH1_5(v0)
and method2 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH1 = method2(v5)
        let v8 : UH1 = method2(v6)
        method3(v7, v8)
    | UH1_4(v10, v11) -> (* RegexCat *)
        let v12 : UH1 = method2(v10)
        let v13 : UH1 = method2(v11)
        method6(v12, v13)
    | UH1_2(v3) -> (* RegexChar *)
        UH1_2(v3)
    | UH1_0 -> (* RegexEmpty *)
        UH1_0
    | UH1_1 -> (* RegexEpsilon *)
        UH1_1
    | UH1_5(v15) -> (* RegexStar *)
        let v16 : UH1 = method2(v15)
        method8(v16)
and method10 (v0 : UH1) : US2 =
    match v0 with
    | UH1_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method10(v5)
        let v8 : US2 = method10(v6)
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
    | UH1_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = method10(v16)
        let v19 : US2 = method10(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH1_2(v3) -> (* RegexChar *)
        US2_1
    | UH1_0 -> (* RegexEmpty *)
        US2_1
    | UH1_1 -> (* RegexEpsilon *)
        US2_0
    | UH1_5(v25) -> (* RegexStar *)
        US2_0
and method9 (v0 : UH1, v1 : US0) : UH1 =
    match v0 with
    | UH1_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH1 = method9(v19, v1)
        let v22 : UH1 = method9(v20, v1)
        method3(v21, v22)
    | UH1_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = method10(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH1 = method9(v24, v1)
            method6(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH1 = method9(v24, v1)
            let v28 : UH1 = method6(v27, v25)
            let v29 : UH1 = method9(v25, v1)
            method3(v28, v29)
    | UH1_2(v4) -> (* RegexChar *)
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
            UH1_1
        else
            UH1_0
    | UH1_0 -> (* RegexEmpty *)
        UH1_0
    | UH1_1 -> (* RegexEpsilon *)
        UH1_0
    | UH1_5(v35) -> (* RegexStar *)
        let v36 : UH1 = method9(v35, v1)
        let v37 : UH1 = method8(v35)
        method6(v36, v37)
and method1 (v0 : UH1, v1 : US0) : UH1 =
    let v2 : UH1 = method2(v0)
    let v3 : UH1 = method9(v2, v1)
    method2(v3)
and method0 (v0 : UH1, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v6, v7) -> (* InputCons *)
        let v8 : UH1 = method1(v0, v6)
        method0(v8, v7)
    | UH0_0 -> (* InputEmpty *)
        let v2 : UH1 = method2(v0)
        let v3 : US2 = method10(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and method11 (v0 : US3) : US4 =
    match v0 with
    | US3_0(v1, v2) -> (* BitMatcherRaw *)
        let v3 : bool = method0(v1, v2)
        US4_1(v1, v2, v3)
and method12 (v0 : US4) : bool =
    match v0 with
    | US4_1(v1, v2, v3) -> (* BitMatcherDecided *)
        v3
let v0 : US0 = US0_1
let v1 : US0 = US0_1
let v2 : US0 = US0_0
let v3 : UH0 = UH0_0
let v4 : UH0 = UH0_1(v2, v3)
let v5 : UH0 = UH0_1(v1, v4)
let v6 : UH0 = UH0_1(v0, v5)
let v7 : US0 = US0_1
let v8 : US0 = US0_1
let v9 : US0 = US0_1
let v10 : UH0 = UH0_0
let v11 : UH0 = UH0_1(v9, v10)
let v12 : UH0 = UH0_1(v8, v11)
let v13 : UH0 = UH0_1(v7, v12)
let v14 : US0 = US0_0
let v15 : UH1 = UH1_2(v14)
let v16 : US0 = US0_1
let v17 : UH1 = UH1_2(v16)
let v18 : UH1 = UH1_3(v15, v17)
let v19 : UH1 = UH1_5(v18)
let v20 : US0 = US0_0
let v21 : UH1 = UH1_2(v20)
let v22 : UH1 = UH1_4(v19, v21)
let v23 : bool = method0(v22, v6)
if not v23 then failwith "brzozowski-expected-true"
let v24 : US0 = US0_0
let v25 : UH1 = UH1_2(v24)
let v26 : US0 = US0_1
let v27 : UH1 = UH1_2(v26)
let v28 : UH1 = UH1_3(v25, v27)
let v29 : UH1 = UH1_5(v28)
let v30 : US0 = US0_0
let v31 : UH1 = UH1_2(v30)
let v32 : UH1 = UH1_4(v29, v31)
let v33 : bool = method0(v32, v13)
if v33 then failwith "brzozowski-expected-false"
let v34 : US0 = US0_0
let v35 : UH1 = UH1_2(v34)
let v36 : US0 = US0_1
let v37 : UH1 = UH1_2(v36)
let v38 : UH1 = UH1_3(v35, v37)
let v39 : UH1 = UH1_5(v38)
let v40 : US0 = US0_0
let v41 : UH1 = UH1_2(v40)
let v42 : UH1 = UH1_4(v39, v41)
let v43 : US3 = US3_0(v42, v6)
let v44 : US4 = method11(v43)
let v45 : US0 = US0_0
let v46 : UH1 = UH1_2(v45)
let v47 : US0 = US0_1
let v48 : UH1 = UH1_2(v47)
let v49 : UH1 = UH1_3(v46, v48)
let v50 : UH1 = UH1_5(v49)
let v51 : US0 = US0_0
let v52 : UH1 = UH1_2(v51)
let v53 : UH1 = UH1_4(v50, v52)
let v54 : US3 = US3_0(v53, v13)
let v55 : US4 = method11(v54)
let v56 : bool = method12(v44)
if not v56 then failwith "brzozowski-expected-true"
let v57 : bool = method12(v55)
if v57 then failwith "brzozowski-expected-false"
let v58 : string = "brzozowski-runtime-smoke-green"
v58
