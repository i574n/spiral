type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0
    | UH0_1 of US0 * UH0
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and UH1 =
    | UH1_0
    | UH1_1 of US1 * UH1
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US0
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and [<Struct>] US2 =
    | US2_0
    | US2_1
    | US2_2
and [<Struct>] US3 =
    | US3_0
    | US3_1
and UH3 =
    | UH3_0
    | UH3_1
    | UH3_2 of US1
    | UH3_3 of UH3 * UH3
    | UH3_4 of UH3 * UH3
    | UH3_5 of UH3
let rec method5 (v0 : UH2, v1 : UH2) : US2 =
    match v0 with
    | UH2_3(v50, v51) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v52, v53) -> (* RegexAlt *)
            let v54 : US2 = method5(v50, v52)
            match v54 with
            | US2_2 -> (* SymbolGreater *)
                v54
            | US2_0 -> (* SymbolLess *)
                v54
            | US2_1 -> (* SymbolSame *)
                method5(v51, v53)
        | _ ->
            US2_2
    | UH2_4(v25, v26) -> (* RegexCat *)
        match v1 with
        | UH2_4(v31, v32) -> (* RegexCat *)
            let v33 : US2 = method5(v25, v31)
            match v33 with
            | US2_2 -> (* SymbolGreater *)
                v33
            | US2_0 -> (* SymbolLess *)
                v33
            | US2_1 -> (* SymbolSame *)
                method5(v26, v32)
        | UH2_2(v29) -> (* RegexChar *)
            US2_2
        | UH2_0 -> (* RegexEmpty *)
            US2_2
        | UH2_1 -> (* RegexEpsilon *)
            US2_2
        | _ ->
            US2_0
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US2_1
                | US0_0 -> (* BitZero *)
                    US2_2
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_1 -> (* BitOne *)
                    US2_0
                | US0_0 -> (* BitZero *)
                    US2_1
        | UH2_0 -> (* RegexEmpty *)
            US2_2
        | UH2_1 -> (* RegexEpsilon *)
            US2_2
        | _ ->
            US2_0
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US2_1
        | _ ->
            US2_0
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US2_2
        | UH2_1 -> (* RegexEpsilon *)
            US2_1
        | _ ->
            US2_0
    | UH2_5(v41) -> (* RegexStar *)
        match v1 with
        | UH2_3(v42, v43) -> (* RegexAlt *)
            US2_0
        | UH2_5(v45) -> (* RegexStar *)
            method5(v41, v45)
        | _ ->
            US2_2
and method4 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method5(v0, v2)
        match v4 with
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH2 = method4(v0, v3)
            UH2_3(v2, v6)
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
    | UH2_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US2 = method5(v0, v1)
        match v9 with
        | US2_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
and method3 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method4(v2, v1)
        method3(v3, v4)
    | UH2_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method4(v0, v1)
and method7 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_3(v15, v16) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v17, v18) -> (* RegexAlt *)
            let v19 : bool = method7(v15, v17)
            if v19 then
                method7(v16, v18)
            else
                false
        | _ ->
            false
    | UH2_4(v23, v24) -> (* RegexCat *)
        match v1 with
        | UH2_4(v25, v26) -> (* RegexCat *)
            let v27 : bool = method7(v23, v25)
            if v27 then
                method7(v24, v26)
            else
                false
        | _ ->
            false
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
            let v12 : US2 =
                match v4 with
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US2_1
                    | US0_0 -> (* BitZero *)
                        US2_2
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_1 -> (* BitOne *)
                        US2_0
                    | US0_0 -> (* BitZero *)
                        US2_1
            match v12 with
            | US2_2 -> (* SymbolGreater *)
                false
            | US2_0 -> (* SymbolLess *)
                false
            | US2_1 -> (* SymbolSame *)
                true
        | _ ->
            false
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH2_5(v31) -> (* RegexStar *)
        match v1 with
        | UH2_5(v32) -> (* RegexStar *)
            method7(v31, v32)
        | _ ->
            false
and method6 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | _ ->
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            UH2_0
        | _ ->
            match v0 with
            | UH2_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH2_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH2_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH2 = method6(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method7(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method8 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method2 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method2(v5)
        let v8 : UH2 = method2(v6)
        method3(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method2(v10)
        let v13 : UH2 = method2(v11)
        method6(v12, v13)
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method2(v15)
        method8(v16)
and method10 (v0 : UH2) : US3 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method10(v5)
        let v8 : US3 = method10(v6)
        match v7 with
        | US3_1 -> (* NonNullable *)
            match v8 with
            | US3_1 -> (* NonNullable *)
                US3_1
            | US3_0 -> (* Nullable *)
                US3_0
        | US3_0 -> (* Nullable *)
            US3_0
    | UH2_4(v14, v15) -> (* RegexCat *)
        let v16 : US3 = method10(v14)
        let v17 : US3 = method10(v15)
        match v16 with
        | US3_1 -> (* NonNullable *)
            US3_1
        | US3_0 -> (* Nullable *)
            match v17 with
            | US3_1 -> (* NonNullable *)
                US3_1
            | US3_0 -> (* Nullable *)
                US3_0
    | UH2_2(v3) -> (* RegexChar *)
        US3_1
    | UH2_0 -> (* RegexEmpty *)
        US3_1
    | UH2_1 -> (* RegexEpsilon *)
        US3_0
    | UH2_5(v23) -> (* RegexStar *)
        US3_0
and method9 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_3(v16, v17) -> (* RegexAlt *)
        let v18 : UH2 = method9(v16, v1)
        let v19 : UH2 = method9(v17, v1)
        method3(v18, v19)
    | UH2_4(v21, v22) -> (* RegexCat *)
        let v23 : US3 = method10(v21)
        match v23 with
        | US3_1 -> (* NonNullable *)
            let v28 : UH2 = method9(v21, v1)
            method6(v28, v22)
        | US3_0 -> (* Nullable *)
            let v24 : UH2 = method9(v21, v1)
            let v25 : UH2 = method6(v24, v22)
            let v26 : UH2 = method9(v22, v1)
            method3(v25, v26)
    | UH2_2(v4) -> (* RegexChar *)
        let v11 : US2 =
            match v4 with
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US2_1
                | US0_0 -> (* BitZero *)
                    US2_2
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_1 -> (* BitOne *)
                    US2_0
                | US0_0 -> (* BitZero *)
                    US2_1
        let v12 : bool =
            match v11 with
            | US2_2 -> (* SymbolGreater *)
                false
            | US2_0 -> (* SymbolLess *)
                false
            | US2_1 -> (* SymbolSame *)
                true
        if v12 then
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v31) -> (* RegexStar *)
        let v32 : UH2 = method9(v31, v1)
        let v33 : UH2 = method8(v31)
        method6(v32, v33)
and method1 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = method2(v0)
    let v3 : UH2 = method9(v2, v1)
    method2(v3)
and method0 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v5, v6) -> (* InputCons *)
        let v7 : UH2 = method1(v0, v5)
        method0(v7, v6)
    | UH0_0 -> (* InputEmpty *)
        let v2 : UH2 = method2(v0)
        let v3 : US3 = method10(v2)
        match v3 with
        | US3_1 -> (* NonNullable *)
            false
        | US3_0 -> (* Nullable *)
            true
and method16 (v0 : UH3, v1 : UH3) : US2 =
    match v0 with
    | UH3_3(v56, v57) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v58, v59) -> (* RegexAlt *)
            let v60 : US2 = method16(v56, v58)
            match v60 with
            | US2_2 -> (* SymbolGreater *)
                v60
            | US2_0 -> (* SymbolLess *)
                v60
            | US2_1 -> (* SymbolSame *)
                method16(v57, v59)
        | _ ->
            US2_2
    | UH3_4(v31, v32) -> (* RegexCat *)
        match v1 with
        | UH3_4(v37, v38) -> (* RegexCat *)
            let v39 : US2 = method16(v31, v37)
            match v39 with
            | US2_2 -> (* SymbolGreater *)
                v39
            | US2_0 -> (* SymbolLess *)
                v39
            | US2_1 -> (* SymbolSame *)
                method16(v32, v38)
        | UH3_2(v35) -> (* RegexChar *)
            US2_2
        | UH3_0 -> (* RegexEmpty *)
            US2_2
        | UH3_1 -> (* RegexEpsilon *)
            US2_2
        | _ ->
            US2_0
    | UH3_2(v10) -> (* RegexChar *)
        match v1 with
        | UH3_2(v13) -> (* RegexChar *)
            match v10 with
            | US1_0 -> (* TriA *)
                match v13 with
                | US1_0 -> (* TriA *)
                    US2_1
                | US1_1 -> (* TriB *)
                    US2_0
                | US1_2 -> (* TriC *)
                    US2_0
            | US1_1 -> (* TriB *)
                match v13 with
                | US1_0 -> (* TriA *)
                    US2_2
                | US1_1 -> (* TriB *)
                    US2_1
                | US1_2 -> (* TriC *)
                    US2_0
            | US1_2 -> (* TriC *)
                match v13 with
                | US1_0 -> (* TriA *)
                    US2_2
                | US1_1 -> (* TriB *)
                    US2_2
                | US1_2 -> (* TriC *)
                    US2_1
        | UH3_0 -> (* RegexEmpty *)
            US2_2
        | UH3_1 -> (* RegexEpsilon *)
            US2_2
        | _ ->
            US2_0
    | UH3_0 -> (* RegexEmpty *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US2_1
        | _ ->
            US2_0
    | UH3_1 -> (* RegexEpsilon *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US2_2
        | UH3_1 -> (* RegexEpsilon *)
            US2_1
        | _ ->
            US2_0
    | UH3_5(v47) -> (* RegexStar *)
        match v1 with
        | UH3_3(v48, v49) -> (* RegexAlt *)
            US2_0
        | UH3_5(v51) -> (* RegexStar *)
            method16(v47, v51)
        | _ ->
            US2_2
and method15 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method16(v0, v2)
        match v4 with
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH3 = method15(v0, v3)
            UH3_3(v2, v6)
        | US2_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
    | UH3_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US2 = method16(v0, v1)
        match v9 with
        | US2_2 -> (* SymbolGreater *)
            UH3_3(v1, v0)
        | US2_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
and method14 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH3 = method15(v2, v1)
        method14(v3, v4)
    | UH3_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method15(v0, v1)
and method18 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_3(v21, v22) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v23, v24) -> (* RegexAlt *)
            let v25 : bool = method18(v21, v23)
            if v25 then
                method18(v22, v24)
            else
                false
        | _ ->
            false
    | UH3_4(v29, v30) -> (* RegexCat *)
        match v1 with
        | UH3_4(v31, v32) -> (* RegexCat *)
            let v33 : bool = method18(v29, v31)
            if v33 then
                method18(v30, v32)
            else
                false
        | _ ->
            false
    | UH3_2(v4) -> (* RegexChar *)
        match v1 with
        | UH3_2(v5) -> (* RegexChar *)
            let v18 : US2 =
                match v4 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US2_1
                    | US1_1 -> (* TriB *)
                        US2_0
                    | US1_2 -> (* TriC *)
                        US2_0
                | US1_1 -> (* TriB *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US2_2
                    | US1_1 -> (* TriB *)
                        US2_1
                    | US1_2 -> (* TriC *)
                        US2_0
                | US1_2 -> (* TriC *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US2_2
                    | US1_1 -> (* TriB *)
                        US2_2
                    | US1_2 -> (* TriC *)
                        US2_1
            match v18 with
            | US2_2 -> (* SymbolGreater *)
                false
            | US2_0 -> (* SymbolLess *)
                false
            | US2_1 -> (* SymbolSame *)
                true
        | _ ->
            false
    | UH3_0 -> (* RegexEmpty *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH3_1 -> (* RegexEpsilon *)
        match v1 with
        | UH3_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH3_5(v37) -> (* RegexStar *)
        match v1 with
        | UH3_5(v38) -> (* RegexStar *)
            method18(v37, v38)
        | _ ->
            false
and method17 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | _ ->
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            UH3_0
        | _ ->
            match v0 with
            | UH3_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH3_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH3_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH3 = method17(v13, v1)
                        UH3_4(v12, v14)
                    | UH3_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH3_5(v5) -> (* RegexStar *)
                            let v6 : bool = method18(v4, v5)
                            if v6 then
                                UH3_5(v4)
                            else
                                UH3_4(v0, v1)
                        | _ ->
                            UH3_4(v0, v1)
                    | _ ->
                        UH3_4(v0, v1)
and method19 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_1
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v3) -> (* RegexStar *)
        UH3_5(v3)
    | _ ->
        UH3_5(v0)
and method13 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH3 = method13(v5)
        let v8 : UH3 = method13(v6)
        method14(v7, v8)
    | UH3_4(v10, v11) -> (* RegexCat *)
        let v12 : UH3 = method13(v10)
        let v13 : UH3 = method13(v11)
        method17(v12, v13)
    | UH3_2(v3) -> (* RegexChar *)
        UH3_2(v3)
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v15) -> (* RegexStar *)
        let v16 : UH3 = method13(v15)
        method19(v16)
and method21 (v0 : UH3) : US3 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method21(v5)
        let v8 : US3 = method21(v6)
        match v7 with
        | US3_1 -> (* NonNullable *)
            match v8 with
            | US3_1 -> (* NonNullable *)
                US3_1
            | US3_0 -> (* Nullable *)
                US3_0
        | US3_0 -> (* Nullable *)
            US3_0
    | UH3_4(v14, v15) -> (* RegexCat *)
        let v16 : US3 = method21(v14)
        let v17 : US3 = method21(v15)
        match v16 with
        | US3_1 -> (* NonNullable *)
            US3_1
        | US3_0 -> (* Nullable *)
            match v17 with
            | US3_1 -> (* NonNullable *)
                US3_1
            | US3_0 -> (* Nullable *)
                US3_0
    | UH3_2(v3) -> (* RegexChar *)
        US3_1
    | UH3_0 -> (* RegexEmpty *)
        US3_1
    | UH3_1 -> (* RegexEpsilon *)
        US3_0
    | UH3_5(v23) -> (* RegexStar *)
        US3_0
and method20 (v0 : UH3, v1 : US1) : UH3 =
    match v0 with
    | UH3_3(v22, v23) -> (* RegexAlt *)
        let v24 : UH3 = method20(v22, v1)
        let v25 : UH3 = method20(v23, v1)
        method14(v24, v25)
    | UH3_4(v27, v28) -> (* RegexCat *)
        let v29 : US3 = method21(v27)
        match v29 with
        | US3_1 -> (* NonNullable *)
            let v34 : UH3 = method20(v27, v1)
            method17(v34, v28)
        | US3_0 -> (* Nullable *)
            let v30 : UH3 = method20(v27, v1)
            let v31 : UH3 = method17(v30, v28)
            let v32 : UH3 = method20(v28, v1)
            method14(v31, v32)
    | UH3_2(v4) -> (* RegexChar *)
        let v17 : US2 =
            match v4 with
            | US1_0 -> (* TriA *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US2_1
                | US1_1 -> (* TriB *)
                    US2_0
                | US1_2 -> (* TriC *)
                    US2_0
            | US1_1 -> (* TriB *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US2_2
                | US1_1 -> (* TriB *)
                    US2_1
                | US1_2 -> (* TriC *)
                    US2_0
            | US1_2 -> (* TriC *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US2_2
                | US1_1 -> (* TriB *)
                    US2_2
                | US1_2 -> (* TriC *)
                    US2_1
        let v18 : bool =
            match v17 with
            | US2_2 -> (* SymbolGreater *)
                false
            | US2_0 -> (* SymbolLess *)
                false
            | US2_1 -> (* SymbolSame *)
                true
        if v18 then
            UH3_1
        else
            UH3_0
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_5(v37) -> (* RegexStar *)
        let v38 : UH3 = method20(v37, v1)
        let v39 : UH3 = method19(v37)
        method17(v38, v39)
and method12 (v0 : UH3, v1 : US1) : UH3 =
    let v2 : UH3 = method13(v0)
    let v3 : UH3 = method20(v2, v1)
    method13(v3)
and method11 (v0 : UH3, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v5, v6) -> (* InputCons *)
        let v7 : UH3 = method12(v0, v5)
        method11(v7, v6)
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH3 = method13(v0)
        let v3 : US3 = method21(v2)
        match v3 with
        | US3_1 -> (* NonNullable *)
            false
        | US3_0 -> (* Nullable *)
            true
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
let v14 : US1 = US1_0
let v15 : US1 = US1_0
let v16 : US1 = US1_0
let v17 : UH1 = UH1_0
let v18 : UH1 = UH1_1(v16, v17)
let v19 : UH1 = UH1_1(v15, v18)
let v20 : UH1 = UH1_1(v14, v19)
let v21 : US1 = US1_0
let v22 : US1 = US1_0
let v23 : US1 = US1_1
let v24 : UH1 = UH1_0
let v25 : UH1 = UH1_1(v23, v24)
let v26 : UH1 = UH1_1(v22, v25)
let v27 : UH1 = UH1_1(v21, v26)
let v28 : US0 = US0_0
let v29 : UH2 = UH2_2(v28)
let v30 : US0 = US0_1
let v31 : UH2 = UH2_2(v30)
let v32 : UH2 = UH2_3(v29, v31)
let v33 : UH2 = UH2_5(v32)
let v34 : US0 = US0_0
let v35 : UH2 = UH2_2(v34)
let v36 : UH2 = UH2_4(v33, v35)
let v37 : bool = method0(v36, v6)
if not v37 then failwith "brzozowski-expected-true"
let v38 : US0 = US0_0
let v39 : UH2 = UH2_2(v38)
let v40 : US0 = US0_1
let v41 : UH2 = UH2_2(v40)
let v42 : UH2 = UH2_3(v39, v41)
let v43 : UH2 = UH2_5(v42)
let v44 : US0 = US0_0
let v45 : UH2 = UH2_2(v44)
let v46 : UH2 = UH2_4(v43, v45)
let v47 : bool = method0(v46, v13)
if v47 then failwith "brzozowski-expected-false"
let v48 : US1 = US1_0
let v49 : UH3 = UH3_2(v48)
let v50 : UH3 = UH3_5(v49)
let v51 : bool = method11(v50, v20)
if not v51 then failwith "brzozowski-expected-true"
let v52 : US1 = US1_0
let v53 : UH3 = UH3_2(v52)
let v54 : UH3 = UH3_5(v53)
let v55 : bool = method11(v54, v27)
if v55 then failwith "brzozowski-expected-false"
let v56 : string = "brzozowski-runtime-bench-green"
v56
