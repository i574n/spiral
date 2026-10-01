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
let rec method4 (v0 : UH2, v1 : UH2) : US2 =
    match v0 with
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
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US2_2
        | UH2_1 -> (* RegexEpsilon *)
            US2_2
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_0 -> (* BitZero *)
                    US2_1
                | US0_1 -> (* BitOne *)
                    US2_0
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_0 -> (* BitZero *)
                    US2_2
                | US0_1 -> (* BitOne *)
                    US2_1
        | _ ->
            US2_0
    | UH2_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v55, v56) -> (* RegexAlt *)
            let v57 : US2 = method4(v53, v55)
            match v57 with
            | US2_1 -> (* SymbolSame *)
                method4(v54, v56)
            | _ ->
                v57
        | _ ->
            US2_2
    | UH2_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US2_2
        | UH2_1 -> (* RegexEpsilon *)
            US2_2
        | UH2_2(v32) -> (* RegexChar *)
            US2_2
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : US2 = method4(v28, v34)
            match v36 with
            | US2_1 -> (* SymbolSame *)
                method4(v29, v35)
            | _ ->
                v36
        | _ ->
            US2_0
    | UH2_5(v44) -> (* RegexStar *)
        match v1 with
        | UH2_3(v45, v46) -> (* RegexAlt *)
            US2_0
        | UH2_5(v48) -> (* RegexStar *)
            method4(v44, v48)
        | _ ->
            US2_2
and method3 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_0 -> (* RegexEmpty *)
        v0
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method4(v0, v2)
        match v4 with
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH2 = method3(v0, v3)
            UH2_3(v2, v6)
    | _ ->
        let v11 : US2 = method4(v0, v1)
        match v11 with
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
and method2 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        v1
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method3(v2, v1)
        method2(v3, v4)
    | _ ->
        method3(v0, v1)
and method6 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
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
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
            let v15 : US2 =
                match v4 with
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US2_1
                    | US0_1 -> (* BitOne *)
                        US2_0
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US2_2
                    | US0_1 -> (* BitOne *)
                        US2_1
            match v15 with
            | US2_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH2_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method6(v18, v20)
            if v22 then
                method6(v19, v21)
            else
                false
        | _ ->
            false
    | UH2_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH2_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method6(v26, v28)
            if v30 then
                method6(v27, v29)
            else
                false
        | _ ->
            false
    | UH2_5(v34) -> (* RegexStar *)
        match v1 with
        | UH2_5(v35) -> (* RegexStar *)
            method6(v34, v35)
        | _ ->
            false
and method5 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method5(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method6(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method7 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method1 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method1(v5)
        let v8 : UH2 = method1(v6)
        method2(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method1(v10)
        let v13 : UH2 = method1(v11)
        method5(v12, v13)
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method1(v15)
        method7(v16)
and method8 (v0 : UH2) : US3 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        US3_1
    | UH2_1 -> (* RegexEpsilon *)
        US3_0
    | UH2_2(v3) -> (* RegexChar *)
        US3_1
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method8(v5)
        let v8 : US3 = method8(v6)
        match v7 with
        | US3_0 -> (* Nullable *)
            US3_0
        | _ ->
            match v8 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                match v7 with
                | US3_1 -> (* NonNullable *)
                    match v8 with
                    | US3_1 -> (* NonNullable *)
                        US3_1
    | UH2_4(v16, v17) -> (* RegexCat *)
        let v18 : US3 = method8(v16)
        let v19 : US3 = method8(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH2_5(v25) -> (* RegexStar *)
        US3_0
and method10 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_2(v4) -> (* RegexChar *)
        let v14 : US2 =
            match v4 with
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_0 -> (* BitZero *)
                    US2_1
                | US0_1 -> (* BitOne *)
                    US2_0
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_0 -> (* BitZero *)
                    US2_2
                | US0_1 -> (* BitOne *)
                    US2_1
        let v15 : bool =
            match v14 with
            | US2_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH2_1
        else
            UH2_0
    | UH2_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH2 = method10(v19, v1)
        let v22 : UH2 = method10(v20, v1)
        method2(v21, v22)
    | UH2_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method8(v24)
        match v26 with
        | US3_0 -> (* Nullable *)
            let v27 : UH2 = method10(v24, v1)
            let v28 : UH2 = method5(v27, v25)
            let v29 : UH2 = method10(v25, v1)
            method2(v28, v29)
        | US3_1 -> (* NonNullable *)
            let v31 : UH2 = method10(v24, v1)
            method5(v31, v25)
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH2 = method10(v35, v1)
        let v37 : UH2 = method7(v35)
        method5(v36, v37)
and method9 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = method1(v0)
    let v3 : UH2 = method10(v2, v1)
    method1(v3)
and method0 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_0 -> (* InputEmpty *)
        let v2 : UH2 = method1(v0)
        let v3 : US3 = method8(v2)
        match v3 with
        | US3_0 -> (* Nullable *)
            true
        | US3_1 -> (* NonNullable *)
            false
    | UH0_1(v6, v7) -> (* InputCons *)
        let v8 : UH2 = method9(v0, v6)
        method0(v8, v7)
and method15 (v0 : UH3, v1 : UH3) : US2 =
    match v0 with
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
    | UH3_2(v10) -> (* RegexChar *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US2_2
        | UH3_1 -> (* RegexEpsilon *)
            US2_2
        | UH3_2(v13) -> (* RegexChar *)
            match v10 with
            | US1_0 -> (* TriA *)
                match v13 with
                | US1_0 -> (* TriA *)
                    US2_1
                | _ ->
                    US2_0
            | _ ->
                match v13 with
                | US1_0 -> (* TriA *)
                    US2_2
                | _ ->
                    match v10 with
                    | US1_1 -> (* TriB *)
                        match v13 with
                        | US1_1 -> (* TriB *)
                            US2_1
                        | US1_2 -> (* TriC *)
                            US2_0
                    | US1_2 -> (* TriC *)
                        match v13 with
                        | US1_1 -> (* TriB *)
                            US2_2
                        | US1_2 -> (* TriC *)
                            US2_1
        | _ ->
            US2_0
    | UH3_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v61, v62) -> (* RegexAlt *)
            let v63 : US2 = method15(v59, v61)
            match v63 with
            | US2_1 -> (* SymbolSame *)
                method15(v60, v62)
            | _ ->
                v63
        | _ ->
            US2_2
    | UH3_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US2_2
        | UH3_1 -> (* RegexEpsilon *)
            US2_2
        | UH3_2(v38) -> (* RegexChar *)
            US2_2
        | UH3_4(v40, v41) -> (* RegexCat *)
            let v42 : US2 = method15(v34, v40)
            match v42 with
            | US2_1 -> (* SymbolSame *)
                method15(v35, v41)
            | _ ->
                v42
        | _ ->
            US2_0
    | UH3_5(v50) -> (* RegexStar *)
        match v1 with
        | UH3_3(v51, v52) -> (* RegexAlt *)
            US2_0
        | UH3_5(v54) -> (* RegexStar *)
            method15(v50, v54)
        | _ ->
            US2_2
and method14 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_0 -> (* RegexEmpty *)
        v0
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method15(v0, v2)
        match v4 with
        | US2_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH3 = method14(v0, v3)
            UH3_3(v2, v6)
    | _ ->
        let v11 : US2 = method15(v0, v1)
        match v11 with
        | US2_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            UH3_3(v1, v0)
and method13 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        v1
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH3 = method14(v2, v1)
        method13(v3, v4)
    | _ ->
        method14(v0, v1)
and method17 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
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
    | UH3_2(v4) -> (* RegexChar *)
        match v1 with
        | UH3_2(v5) -> (* RegexChar *)
            let v21 : US2 =
                match v4 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US2_1
                    | _ ->
                        US2_0
                | _ ->
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US2_2
                    | _ ->
                        match v4 with
                        | US1_1 -> (* TriB *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US2_1
                            | US1_2 -> (* TriC *)
                                US2_0
                        | US1_2 -> (* TriC *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US2_2
                            | US1_2 -> (* TriC *)
                                US2_1
            match v21 with
            | US2_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH3_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method17(v24, v26)
            if v28 then
                method17(v25, v27)
            else
                false
        | _ ->
            false
    | UH3_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH3_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method17(v32, v34)
            if v36 then
                method17(v33, v35)
            else
                false
        | _ ->
            false
    | UH3_5(v40) -> (* RegexStar *)
        match v1 with
        | UH3_5(v41) -> (* RegexStar *)
            method17(v40, v41)
        | _ ->
            false
and method16 (v0 : UH3, v1 : UH3) : UH3 =
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
                        let v14 : UH3 = method16(v13, v1)
                        UH3_4(v12, v14)
                    | UH3_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH3_5(v5) -> (* RegexStar *)
                            let v6 : bool = method17(v4, v5)
                            if v6 then
                                UH3_5(v4)
                            else
                                UH3_4(v0, v1)
                        | _ ->
                            UH3_4(v0, v1)
                    | _ ->
                        UH3_4(v0, v1)
and method18 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_1
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v3) -> (* RegexStar *)
        UH3_5(v3)
    | _ ->
        UH3_5(v0)
and method12 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_2(v3) -> (* RegexChar *)
        UH3_2(v3)
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH3 = method12(v5)
        let v8 : UH3 = method12(v6)
        method13(v7, v8)
    | UH3_4(v10, v11) -> (* RegexCat *)
        let v12 : UH3 = method12(v10)
        let v13 : UH3 = method12(v11)
        method16(v12, v13)
    | UH3_5(v15) -> (* RegexStar *)
        let v16 : UH3 = method12(v15)
        method18(v16)
and method19 (v0 : UH3) : US3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        US3_1
    | UH3_1 -> (* RegexEpsilon *)
        US3_0
    | UH3_2(v3) -> (* RegexChar *)
        US3_1
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method19(v5)
        let v8 : US3 = method19(v6)
        match v7 with
        | US3_0 -> (* Nullable *)
            US3_0
        | _ ->
            match v8 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                match v7 with
                | US3_1 -> (* NonNullable *)
                    match v8 with
                    | US3_1 -> (* NonNullable *)
                        US3_1
    | UH3_4(v16, v17) -> (* RegexCat *)
        let v18 : US3 = method19(v16)
        let v19 : US3 = method19(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH3_5(v25) -> (* RegexStar *)
        US3_0
and method21 (v0 : UH3, v1 : US1) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_2(v4) -> (* RegexChar *)
        let v20 : US2 =
            match v4 with
            | US1_0 -> (* TriA *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US2_1
                | _ ->
                    US2_0
            | _ ->
                match v1 with
                | US1_0 -> (* TriA *)
                    US2_2
                | _ ->
                    match v4 with
                    | US1_1 -> (* TriB *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US2_1
                        | US1_2 -> (* TriC *)
                            US2_0
                    | US1_2 -> (* TriC *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US2_2
                        | US1_2 -> (* TriC *)
                            US2_1
        let v21 : bool =
            match v20 with
            | US2_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH3_1
        else
            UH3_0
    | UH3_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH3 = method21(v25, v1)
        let v28 : UH3 = method21(v26, v1)
        method13(v27, v28)
    | UH3_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method19(v30)
        match v32 with
        | US3_0 -> (* Nullable *)
            let v33 : UH3 = method21(v30, v1)
            let v34 : UH3 = method16(v33, v31)
            let v35 : UH3 = method21(v31, v1)
            method13(v34, v35)
        | US3_1 -> (* NonNullable *)
            let v37 : UH3 = method21(v30, v1)
            method16(v37, v31)
    | UH3_5(v41) -> (* RegexStar *)
        let v42 : UH3 = method21(v41, v1)
        let v43 : UH3 = method18(v41)
        method16(v42, v43)
and method20 (v0 : UH3, v1 : US1) : UH3 =
    let v2 : UH3 = method12(v0)
    let v3 : UH3 = method21(v2, v1)
    method12(v3)
and method11 (v0 : UH3, v1 : UH1) : bool =
    match v1 with
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH3 = method12(v0)
        let v3 : US3 = method19(v2)
        match v3 with
        | US3_0 -> (* Nullable *)
            true
        | US3_1 -> (* NonNullable *)
            false
    | UH1_1(v6, v7) -> (* InputCons *)
        let v8 : UH3 = method20(v0, v6)
        method11(v8, v7)
let v0 : UH0 = UH0_0
let v1 : US0 = US0_0
let v2 : UH0 = UH0_1(v1, v0)
let v3 : US0 = US0_1
let v4 : UH0 = UH0_1(v3, v2)
let v5 : US0 = US0_1
let v6 : UH0 = UH0_1(v5, v4)
let v7 : UH0 = UH0_0
let v8 : US0 = US0_1
let v9 : UH0 = UH0_1(v8, v7)
let v10 : US0 = US0_1
let v11 : UH0 = UH0_1(v10, v9)
let v12 : US0 = US0_1
let v13 : UH0 = UH0_1(v12, v11)
let v14 : UH1 = UH1_0
let v15 : US1 = US1_0
let v16 : UH1 = UH1_1(v15, v14)
let v17 : US1 = US1_0
let v18 : UH1 = UH1_1(v17, v16)
let v19 : US1 = US1_0
let v20 : UH1 = UH1_1(v19, v18)
let v21 : UH1 = UH1_0
let v22 : US1 = US1_1
let v23 : UH1 = UH1_1(v22, v21)
let v24 : US1 = US1_0
let v25 : UH1 = UH1_1(v24, v23)
let v26 : US1 = US1_0
let v27 : UH1 = UH1_1(v26, v25)
let v28 : US0 = US0_0
let v29 : UH2 = UH2_2(v28)
let v30 : US0 = US0_1
let v31 : UH2 = UH2_2(v30)
let v32 : US0 = US0_0
let v33 : UH2 = UH2_2(v32)
let v34 : UH2 = UH2_3(v33, v31)
let v35 : UH2 = UH2_5(v34)
let v36 : UH2 = UH2_4(v35, v29)
let v37 : bool = method0(v36, v6)
if not v37 then failwith "brzozowski-expected-true"
let v38 : US0 = US0_0
let v39 : UH2 = UH2_2(v38)
let v40 : US0 = US0_1
let v41 : UH2 = UH2_2(v40)
let v42 : US0 = US0_0
let v43 : UH2 = UH2_2(v42)
let v44 : UH2 = UH2_3(v43, v41)
let v45 : UH2 = UH2_5(v44)
let v46 : UH2 = UH2_4(v45, v39)
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
