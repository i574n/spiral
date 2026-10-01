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
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and [<Struct>] US2 =
    | US2_0
    | US2_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US3
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and UH3 =
    | UH3_0
    | UH3_1 of US3 * UH3
let rec method4 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | UH0_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_0 -> (* BitZero *)
                    US1_1
                | US0_1 -> (* BitOne *)
                    US1_0
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_0 -> (* BitZero *)
                    US1_2
                | US0_1 -> (* BitOne *)
                    US1_1
        | _ ->
            US1_0
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method4(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method4(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | UH0_2(v32) -> (* RegexChar *)
            US1_2
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method4(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method4(v29, v35)
            | _ ->
                v36
        | _ ->
            US1_0
    | UH0_5(v44) -> (* RegexStar *)
        match v1 with
        | UH0_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH0_5(v48) -> (* RegexStar *)
            method4(v44, v48)
        | _ ->
            US1_2
and method3 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_0 -> (* RegexEmpty *)
        v0
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method4(v0, v2)
        match v4 with
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH0 = method3(v0, v3)
            UH0_3(v2, v6)
    | _ ->
        let v11 : US1 = method4(v0, v1)
        match v11 with
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
and method2 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        v1
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method3(v2, v1)
        method2(v3, v4)
    | _ ->
        method3(v0, v1)
and method6 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
            let v15 : US1 =
                match v4 with
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US1_1
                    | US0_1 -> (* BitOne *)
                        US1_0
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US1_2
                    | US0_1 -> (* BitOne *)
                        US1_1
            match v15 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH0_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method6(v18, v20)
            if v22 then
                method6(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method6(v26, v28)
            if v30 then
                method6(v27, v29)
            else
                false
        | _ ->
            false
    | UH0_5(v34) -> (* RegexStar *)
        match v1 with
        | UH0_5(v35) -> (* RegexStar *)
            method6(v34, v35)
        | _ ->
            false
and method5 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | _ ->
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            UH0_0
        | _ ->
            match v0 with
            | UH0_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH0_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH0_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH0 = method5(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = method6(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and method7 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and method1 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method1(v5)
        let v8 : UH0 = method1(v6)
        method2(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method1(v10)
        let v13 : UH0 = method1(v11)
        method5(v12, v13)
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method1(v15)
        method7(v16)
and method8 (v0 : UH0) : US2 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        US2_1
    | UH0_1 -> (* RegexEpsilon *)
        US2_0
    | UH0_2(v3) -> (* RegexChar *)
        US2_1
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method8(v5)
        let v8 : US2 = method8(v6)
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
    | UH0_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = method8(v16)
        let v19 : US2 = method8(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH0_5(v25) -> (* RegexStar *)
        US2_0
and method10 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_2(v4) -> (* RegexChar *)
        let v14 : US1 =
            match v4 with
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_0 -> (* BitZero *)
                    US1_1
                | US0_1 -> (* BitOne *)
                    US1_0
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_0 -> (* BitZero *)
                    US1_2
                | US0_1 -> (* BitOne *)
                    US1_1
        let v15 : bool =
            match v14 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH0_1
        else
            UH0_0
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method10(v19, v1)
        let v22 : UH0 = method10(v20, v1)
        method2(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = method8(v24)
        match v26 with
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = method10(v24, v1)
            let v28 : UH0 = method5(v27, v25)
            let v29 : UH0 = method10(v25, v1)
            method2(v28, v29)
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = method10(v24, v1)
            method5(v31, v25)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH0 = method10(v35, v1)
        let v37 : UH0 = method7(v35)
        method5(v36, v37)
and method9 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method1(v0)
    let v3 : UH0 = method10(v2, v1)
    method1(v3)
and method0 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH0 = method1(v0)
        let v3 : US2 = method8(v2)
        match v3 with
        | US2_0 -> (* Nullable *)
            true
        | US2_1 -> (* NonNullable *)
            false
    | UH1_1(v6, v7) -> (* InputCons *)
        let v8 : UH0 = method9(v0, v6)
        method0(v8, v7)
and method15 (v0 : UH2, v1 : UH2) : US1 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US1_2
        | UH2_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US1_2
        | UH2_1 -> (* RegexEpsilon *)
            US1_2
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US3_0 -> (* TriA *)
                match v13 with
                | US3_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v13 with
                | US3_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v10 with
                    | US3_1 -> (* TriB *)
                        match v13 with
                        | US3_1 -> (* TriB *)
                            US1_1
                        | US3_2 -> (* TriC *)
                            US1_0
                    | US3_2 -> (* TriC *)
                        match v13 with
                        | US3_1 -> (* TriB *)
                            US1_2
                        | US3_2 -> (* TriC *)
                            US1_1
        | _ ->
            US1_0
    | UH2_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method15(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method15(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH2_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US1_2
        | UH2_1 -> (* RegexEpsilon *)
            US1_2
        | UH2_2(v38) -> (* RegexChar *)
            US1_2
        | UH2_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method15(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method15(v35, v41)
            | _ ->
                v42
        | _ ->
            US1_0
    | UH2_5(v50) -> (* RegexStar *)
        match v1 with
        | UH2_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH2_5(v54) -> (* RegexStar *)
            method15(v50, v54)
        | _ ->
            US1_2
and method14 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_0 -> (* RegexEmpty *)
        v0
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method15(v0, v2)
        match v4 with
        | US1_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH2 = method14(v0, v3)
            UH2_3(v2, v6)
    | _ ->
        let v11 : US1 = method15(v0, v1)
        match v11 with
        | US1_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
and method13 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        v1
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method14(v2, v1)
        method13(v3, v4)
    | _ ->
        method14(v0, v1)
and method17 (v0 : UH2, v1 : UH2) : bool =
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
            let v21 : US1 =
                match v4 with
                | US3_0 -> (* TriA *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v4 with
                        | US3_1 -> (* TriB *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US1_1
                            | US3_2 -> (* TriC *)
                                US1_0
                        | US3_2 -> (* TriC *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US1_2
                            | US3_2 -> (* TriC *)
                                US1_1
            match v21 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH2_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method17(v24, v26)
            if v28 then
                method17(v25, v27)
            else
                false
        | _ ->
            false
    | UH2_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method17(v32, v34)
            if v36 then
                method17(v33, v35)
            else
                false
        | _ ->
            false
    | UH2_5(v40) -> (* RegexStar *)
        match v1 with
        | UH2_5(v41) -> (* RegexStar *)
            method17(v40, v41)
        | _ ->
            false
and method16 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method16(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method17(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method18 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method12 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method12(v5)
        let v8 : UH2 = method12(v6)
        method13(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method12(v10)
        let v13 : UH2 = method12(v11)
        method16(v12, v13)
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method12(v15)
        method18(v16)
and method19 (v0 : UH2) : US2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        US2_1
    | UH2_1 -> (* RegexEpsilon *)
        US2_0
    | UH2_2(v3) -> (* RegexChar *)
        US2_1
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method19(v5)
        let v8 : US2 = method19(v6)
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
    | UH2_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = method19(v16)
        let v19 : US2 = method19(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH2_5(v25) -> (* RegexStar *)
        US2_0
and method21 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_2(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US3_0 -> (* TriA *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v1 with
                | US3_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v4 with
                    | US3_1 -> (* TriB *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US1_1
                        | US3_2 -> (* TriC *)
                            US1_0
                    | US3_2 -> (* TriC *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US1_2
                        | US3_2 -> (* TriC *)
                            US1_1
        let v21 : bool =
            match v20 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH2_1
        else
            UH2_0
    | UH2_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = method21(v25, v1)
        let v28 : UH2 = method21(v26, v1)
        method13(v27, v28)
    | UH2_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = method19(v30)
        match v32 with
        | US2_0 -> (* Nullable *)
            let v33 : UH2 = method21(v30, v1)
            let v34 : UH2 = method16(v33, v31)
            let v35 : UH2 = method21(v31, v1)
            method13(v34, v35)
        | US2_1 -> (* NonNullable *)
            let v37 : UH2 = method21(v30, v1)
            method16(v37, v31)
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH2 = method21(v41, v1)
        let v43 : UH2 = method18(v41)
        method16(v42, v43)
and method20 (v0 : UH2, v1 : US3) : UH2 =
    let v2 : UH2 = method12(v0)
    let v3 : UH2 = method21(v2, v1)
    method12(v3)
and method11 (v0 : UH2, v1 : UH3) : bool =
    match v1 with
    | UH3_0 -> (* InputEmpty *)
        let v2 : UH2 = method12(v0)
        let v3 : US2 = method19(v2)
        match v3 with
        | US2_0 -> (* Nullable *)
            true
        | US2_1 -> (* NonNullable *)
            false
    | UH3_1(v6, v7) -> (* InputCons *)
        let v8 : UH2 = method20(v0, v6)
        method11(v8, v7)
let v0 : US0 = US0_0
let v1 : UH0 = UH0_2(v0)
let v2 : US0 = US0_1
let v3 : UH0 = UH0_2(v2)
let v4 : US0 = US0_0
let v5 : UH0 = UH0_2(v4)
let v6 : UH0 = UH0_3(v5, v3)
let v7 : UH0 = UH0_5(v6)
let v8 : UH0 = UH0_4(v7, v1)
let v9 : UH1 = UH1_0
let v10 : US0 = US0_0
let v11 : UH1 = UH1_1(v10, v9)
let v12 : US0 = US0_1
let v13 : UH1 = UH1_1(v12, v11)
let v14 : US0 = US0_1
let v15 : UH1 = UH1_1(v14, v13)
let v16 : bool = method0(v8, v15)
let v17 : US3 = US3_0
let v18 : UH2 = UH2_2(v17)
let v19 : UH2 = UH2_5(v18)
let v20 : UH3 = UH3_0
let v21 : US3 = US3_0
let v22 : UH3 = UH3_1(v21, v20)
let v23 : US3 = US3_0
let v24 : UH3 = UH3_1(v23, v22)
let v25 : US3 = US3_0
let v26 : UH3 = UH3_1(v25, v24)
let v27 : bool = method11(v19, v26)
let v28 : bool = v16 && v27
let v29 : bool = v28 && v16
let v30 : bool = v29 && v27
v30
