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
and [<Struct>] US4 =
    | US4_0
    | US4_1
    | US4_2
and UH4 =
    | UH4_0
    | UH4_1
    | UH4_2 of US4
    | UH4_3 of UH4 * UH4
    | UH4_4 of UH4 * UH4
    | UH4_5 of UH4
and UH5 =
    | UH5_0
    | UH5_1 of US4 * UH5
and UH6 =
    | UH6_0
    | UH6_1 of US0 * UH6
and UH7 =
    | UH7_0
    | UH7_1 of UH1 * UH7
and UH8 =
    | UH8_0
    | UH8_1 of US3 * UH8
and UH9 =
    | UH9_0
    | UH9_1 of UH3 * UH9
and UH12 =
    | UH12_0
and UH11 =
    | UH11_0
    | UH11_1 of UH12
and UH10 =
    | UH10_0
    | UH10_1 of UH11 * UH10
and [<Struct>] US5 =
    | US5_0
    | US5_1 of f1_0 : UH10
and [<Struct>] US6 =
    | US6_0
    | US6_1 of f1_0 : UH11
and [<Struct>] US7 =
    | US7_0
    | US7_1 of f1_0 : UH12
and [<Struct>] US8 =
    | US8_0
    | US8_1
    | US8_2
and UH15 =
    | UH15_0
and UH14 =
    | UH14_0 of UH11 * UH15
and UH13 =
    | UH13_0 of UH11 * UH14
and UH17 =
    | UH17_0
    | UH17_1 of UH11
and UH16 =
    | UH16_0
    | UH16_1 of UH17 * UH16
and [<Struct>] US9 =
    | US9_0
    | US9_1 of f1_0 : UH16
and [<Struct>] US10 =
    | US10_0
    | US10_1 of f1_0 : UH17
and UH21 =
    | UH21_0
and UH20 =
    | UH20_0 of UH17 * UH21
and UH19 =
    | UH19_0 of UH17 * UH20
and UH18 =
    | UH18_0 of UH17 * UH19
let rec method5 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_3(v50, v51) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v52, v53) -> (* RegexAlt *)
            let v54 : US1 = method5(v50, v52)
            match v54 with
            | US1_2 -> (* SymbolGreater *)
                v54
            | US1_0 -> (* SymbolLess *)
                v54
            | US1_1 -> (* SymbolSame *)
                method5(v51, v53)
        | _ ->
            US1_2
    | UH0_4(v25, v26) -> (* RegexCat *)
        match v1 with
        | UH0_4(v31, v32) -> (* RegexCat *)
            let v33 : US1 = method5(v25, v31)
            match v33 with
            | US1_2 -> (* SymbolGreater *)
                v33
            | US1_0 -> (* SymbolLess *)
                v33
            | US1_1 -> (* SymbolSame *)
                method5(v26, v32)
        | UH0_2(v29) -> (* RegexChar *)
            US1_2
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_2(v13) -> (* RegexChar *)
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
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
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
    | UH0_5(v41) -> (* RegexStar *)
        match v1 with
        | UH0_3(v42, v43) -> (* RegexAlt *)
            US1_0
        | UH0_5(v45) -> (* RegexStar *)
            method5(v41, v45)
        | _ ->
            US1_2
and method4 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method5(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH0 = method4(v0, v3)
            UH0_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH0_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US1 = method5(v0, v1)
        match v9 with
        | US1_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method3 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method4(v2, v1)
        method3(v3, v4)
    | UH0_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method4(v0, v1)
and method7 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_3(v15, v16) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v17, v18) -> (* RegexAlt *)
            let v19 : bool = method7(v15, v17)
            if v19 then
                method7(v16, v18)
            else
                false
        | _ ->
            false
    | UH0_4(v23, v24) -> (* RegexCat *)
        match v1 with
        | UH0_4(v25, v26) -> (* RegexCat *)
            let v27 : bool = method7(v23, v25)
            if v27 then
                method7(v24, v26)
            else
                false
        | _ ->
            false
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
            let v12 : US1 =
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
            match v12 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        | _ ->
            false
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
    | UH0_5(v31) -> (* RegexStar *)
        match v1 with
        | UH0_5(v32) -> (* RegexStar *)
            method7(v31, v32)
        | _ ->
            false
and method6 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = method6(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = method7(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and method8 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and method2 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method2(v5)
        let v8 : UH0 = method2(v6)
        method3(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method2(v10)
        let v13 : UH0 = method2(v11)
        method6(v12, v13)
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method2(v15)
        method8(v16)
and method10 (v0 : UH0) : US2 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method10(v5)
        let v8 : US2 = method10(v6)
        match v7 with
        | US2_1 -> (* NonNullable *)
            match v8 with
            | US2_1 -> (* NonNullable *)
                US2_1
            | US2_0 -> (* Nullable *)
                US2_0
        | US2_0 -> (* Nullable *)
            US2_0
    | UH0_4(v14, v15) -> (* RegexCat *)
        let v16 : US2 = method10(v14)
        let v17 : US2 = method10(v15)
        match v16 with
        | US2_1 -> (* NonNullable *)
            US2_1
        | US2_0 -> (* Nullable *)
            match v17 with
            | US2_1 -> (* NonNullable *)
                US2_1
            | US2_0 -> (* Nullable *)
                US2_0
    | UH0_2(v3) -> (* RegexChar *)
        US2_1
    | UH0_0 -> (* RegexEmpty *)
        US2_1
    | UH0_1 -> (* RegexEpsilon *)
        US2_0
    | UH0_5(v23) -> (* RegexStar *)
        US2_0
and method9 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v16, v17) -> (* RegexAlt *)
        let v18 : UH0 = method9(v16, v1)
        let v19 : UH0 = method9(v17, v1)
        method3(v18, v19)
    | UH0_4(v21, v22) -> (* RegexCat *)
        let v23 : US2 = method10(v21)
        match v23 with
        | US2_1 -> (* NonNullable *)
            let v28 : UH0 = method9(v21, v1)
            method6(v28, v22)
        | US2_0 -> (* Nullable *)
            let v24 : UH0 = method9(v21, v1)
            let v25 : UH0 = method6(v24, v22)
            let v26 : UH0 = method9(v22, v1)
            method3(v25, v26)
    | UH0_2(v4) -> (* RegexChar *)
        let v11 : US1 =
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
        let v12 : bool =
            match v11 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        if v12 then
            UH0_1
        else
            UH0_0
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_5(v31) -> (* RegexStar *)
        let v32 : UH0 = method9(v31, v1)
        let v33 : UH0 = method8(v31)
        method6(v32, v33)
and method1 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method2(v0)
    let v3 : UH0 = method9(v2, v1)
    method2(v3)
and method0 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v5, v6) -> (* InputCons *)
        let v7 : UH0 = method1(v0, v5)
        method0(v7, v6)
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH0 = method2(v0)
        let v3 : US2 = method10(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and method16 (v0 : UH2, v1 : UH2) : US1 =
    match v0 with
    | UH2_3(v56, v57) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v58, v59) -> (* RegexAlt *)
            let v60 : US1 = method16(v56, v58)
            match v60 with
            | US1_2 -> (* SymbolGreater *)
                v60
            | US1_0 -> (* SymbolLess *)
                v60
            | US1_1 -> (* SymbolSame *)
                method16(v57, v59)
        | _ ->
            US1_2
    | UH2_4(v31, v32) -> (* RegexCat *)
        match v1 with
        | UH2_4(v37, v38) -> (* RegexCat *)
            let v39 : US1 = method16(v31, v37)
            match v39 with
            | US1_2 -> (* SymbolGreater *)
                v39
            | US1_0 -> (* SymbolLess *)
                v39
            | US1_1 -> (* SymbolSame *)
                method16(v32, v38)
        | UH2_2(v35) -> (* RegexChar *)
            US1_2
        | UH2_0 -> (* RegexEmpty *)
            US1_2
        | UH2_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US3_0 -> (* TriA *)
                match v13 with
                | US3_0 -> (* TriA *)
                    US1_1
                | US3_1 -> (* TriB *)
                    US1_0
                | US3_2 -> (* TriC *)
                    US1_0
            | US3_1 -> (* TriB *)
                match v13 with
                | US3_0 -> (* TriA *)
                    US1_2
                | US3_1 -> (* TriB *)
                    US1_1
                | US3_2 -> (* TriC *)
                    US1_0
            | US3_2 -> (* TriC *)
                match v13 with
                | US3_0 -> (* TriA *)
                    US1_2
                | US3_1 -> (* TriB *)
                    US1_2
                | US3_2 -> (* TriC *)
                    US1_1
        | UH2_0 -> (* RegexEmpty *)
            US1_2
        | UH2_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
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
    | UH2_5(v47) -> (* RegexStar *)
        match v1 with
        | UH2_3(v48, v49) -> (* RegexAlt *)
            US1_0
        | UH2_5(v51) -> (* RegexStar *)
            method16(v47, v51)
        | _ ->
            US1_2
and method15 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method16(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH2 = method15(v0, v3)
            UH2_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH2_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US1 = method16(v0, v1)
        match v9 with
        | US1_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method14 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method15(v2, v1)
        method14(v3, v4)
    | UH2_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method15(v0, v1)
and method18 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_3(v21, v22) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v23, v24) -> (* RegexAlt *)
            let v25 : bool = method18(v21, v23)
            if v25 then
                method18(v22, v24)
            else
                false
        | _ ->
            false
    | UH2_4(v29, v30) -> (* RegexCat *)
        match v1 with
        | UH2_4(v31, v32) -> (* RegexCat *)
            let v33 : bool = method18(v29, v31)
            if v33 then
                method18(v30, v32)
            else
                false
        | _ ->
            false
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
            let v18 : US1 =
                match v4 with
                | US3_0 -> (* TriA *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US1_1
                    | US3_1 -> (* TriB *)
                        US1_0
                    | US3_2 -> (* TriC *)
                        US1_0
                | US3_1 -> (* TriB *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US1_2
                    | US3_1 -> (* TriB *)
                        US1_1
                    | US3_2 -> (* TriC *)
                        US1_0
                | US3_2 -> (* TriC *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US1_2
                    | US3_1 -> (* TriB *)
                        US1_2
                    | US3_2 -> (* TriC *)
                        US1_1
            match v18 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
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
    | UH2_5(v37) -> (* RegexStar *)
        match v1 with
        | UH2_5(v38) -> (* RegexStar *)
            method18(v37, v38)
        | _ ->
            false
and method17 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method17(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method18(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method19 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method13 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method13(v5)
        let v8 : UH2 = method13(v6)
        method14(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method13(v10)
        let v13 : UH2 = method13(v11)
        method17(v12, v13)
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method13(v15)
        method19(v16)
and method21 (v0 : UH2) : US2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method21(v5)
        let v8 : US2 = method21(v6)
        match v7 with
        | US2_1 -> (* NonNullable *)
            match v8 with
            | US2_1 -> (* NonNullable *)
                US2_1
            | US2_0 -> (* Nullable *)
                US2_0
        | US2_0 -> (* Nullable *)
            US2_0
    | UH2_4(v14, v15) -> (* RegexCat *)
        let v16 : US2 = method21(v14)
        let v17 : US2 = method21(v15)
        match v16 with
        | US2_1 -> (* NonNullable *)
            US2_1
        | US2_0 -> (* Nullable *)
            match v17 with
            | US2_1 -> (* NonNullable *)
                US2_1
            | US2_0 -> (* Nullable *)
                US2_0
    | UH2_2(v3) -> (* RegexChar *)
        US2_1
    | UH2_0 -> (* RegexEmpty *)
        US2_1
    | UH2_1 -> (* RegexEpsilon *)
        US2_0
    | UH2_5(v23) -> (* RegexStar *)
        US2_0
and method20 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_3(v22, v23) -> (* RegexAlt *)
        let v24 : UH2 = method20(v22, v1)
        let v25 : UH2 = method20(v23, v1)
        method14(v24, v25)
    | UH2_4(v27, v28) -> (* RegexCat *)
        let v29 : US2 = method21(v27)
        match v29 with
        | US2_1 -> (* NonNullable *)
            let v34 : UH2 = method20(v27, v1)
            method17(v34, v28)
        | US2_0 -> (* Nullable *)
            let v30 : UH2 = method20(v27, v1)
            let v31 : UH2 = method17(v30, v28)
            let v32 : UH2 = method20(v28, v1)
            method14(v31, v32)
    | UH2_2(v4) -> (* RegexChar *)
        let v17 : US1 =
            match v4 with
            | US3_0 -> (* TriA *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US1_1
                | US3_1 -> (* TriB *)
                    US1_0
                | US3_2 -> (* TriC *)
                    US1_0
            | US3_1 -> (* TriB *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US1_2
                | US3_1 -> (* TriB *)
                    US1_1
                | US3_2 -> (* TriC *)
                    US1_0
            | US3_2 -> (* TriC *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US1_2
                | US3_1 -> (* TriB *)
                    US1_2
                | US3_2 -> (* TriC *)
                    US1_1
        let v18 : bool =
            match v17 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        if v18 then
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v37) -> (* RegexStar *)
        let v38 : UH2 = method20(v37, v1)
        let v39 : UH2 = method19(v37)
        method17(v38, v39)
and method12 (v0 : UH2, v1 : US3) : UH2 =
    let v2 : UH2 = method13(v0)
    let v3 : UH2 = method20(v2, v1)
    method13(v3)
and method11 (v0 : UH2, v1 : UH3) : bool =
    match v1 with
    | UH3_1(v5, v6) -> (* InputCons *)
        let v7 : UH2 = method12(v0, v5)
        method11(v7, v6)
    | UH3_0 -> (* InputEmpty *)
        let v2 : UH2 = method13(v0)
        let v3 : US2 = method21(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and method27 (v0 : UH4, v1 : UH4) : US1 =
    match v0 with
    | UH4_3(v56, v57) -> (* RegexAlt *)
        match v1 with
        | UH4_3(v58, v59) -> (* RegexAlt *)
            let v60 : US1 = method27(v56, v58)
            match v60 with
            | US1_2 -> (* SymbolGreater *)
                v60
            | US1_0 -> (* SymbolLess *)
                v60
            | US1_1 -> (* SymbolSame *)
                method27(v57, v59)
        | _ ->
            US1_2
    | UH4_4(v31, v32) -> (* RegexCat *)
        match v1 with
        | UH4_4(v37, v38) -> (* RegexCat *)
            let v39 : US1 = method27(v31, v37)
            match v39 with
            | US1_2 -> (* SymbolGreater *)
                v39
            | US1_0 -> (* SymbolLess *)
                v39
            | US1_1 -> (* SymbolSame *)
                method27(v32, v38)
        | UH4_2(v35) -> (* RegexChar *)
            US1_2
        | UH4_0 -> (* RegexEmpty *)
            US1_2
        | UH4_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH4_2(v10) -> (* RegexChar *)
        match v1 with
        | UH4_2(v13) -> (* RegexChar *)
            match v10 with
            | US4_0 -> (* ModelA *)
                match v13 with
                | US4_0 -> (* ModelA *)
                    US1_1
                | US4_1 -> (* ModelB *)
                    US1_0
                | US4_2 -> (* ModelC *)
                    US1_0
            | US4_1 -> (* ModelB *)
                match v13 with
                | US4_0 -> (* ModelA *)
                    US1_2
                | US4_1 -> (* ModelB *)
                    US1_1
                | US4_2 -> (* ModelC *)
                    US1_0
            | US4_2 -> (* ModelC *)
                match v13 with
                | US4_0 -> (* ModelA *)
                    US1_2
                | US4_1 -> (* ModelB *)
                    US1_2
                | US4_2 -> (* ModelC *)
                    US1_1
        | UH4_0 -> (* RegexEmpty *)
            US1_2
        | UH4_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH4_0 -> (* RegexEmpty *)
        match v1 with
        | UH4_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH4_1 -> (* RegexEpsilon *)
        match v1 with
        | UH4_0 -> (* RegexEmpty *)
            US1_2
        | UH4_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH4_5(v47) -> (* RegexStar *)
        match v1 with
        | UH4_3(v48, v49) -> (* RegexAlt *)
            US1_0
        | UH4_5(v51) -> (* RegexStar *)
            method27(v47, v51)
        | _ ->
            US1_2
and method26 (v0 : UH4, v1 : UH4) : UH4 =
    match v1 with
    | UH4_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method27(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH4 = method26(v0, v3)
            UH4_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH4_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH4_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US1 = method27(v0, v1)
        match v9 with
        | US1_2 -> (* SymbolGreater *)
            UH4_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH4_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method25 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH4 = method26(v2, v1)
        method25(v3, v4)
    | UH4_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method26(v0, v1)
and method29 (v0 : UH4, v1 : UH4) : bool =
    match v0 with
    | UH4_3(v21, v22) -> (* RegexAlt *)
        match v1 with
        | UH4_3(v23, v24) -> (* RegexAlt *)
            let v25 : bool = method29(v21, v23)
            if v25 then
                method29(v22, v24)
            else
                false
        | _ ->
            false
    | UH4_4(v29, v30) -> (* RegexCat *)
        match v1 with
        | UH4_4(v31, v32) -> (* RegexCat *)
            let v33 : bool = method29(v29, v31)
            if v33 then
                method29(v30, v32)
            else
                false
        | _ ->
            false
    | UH4_2(v4) -> (* RegexChar *)
        match v1 with
        | UH4_2(v5) -> (* RegexChar *)
            let v18 : US1 =
                match v4 with
                | US4_0 -> (* ModelA *)
                    match v5 with
                    | US4_0 -> (* ModelA *)
                        US1_1
                    | US4_1 -> (* ModelB *)
                        US1_0
                    | US4_2 -> (* ModelC *)
                        US1_0
                | US4_1 -> (* ModelB *)
                    match v5 with
                    | US4_0 -> (* ModelA *)
                        US1_2
                    | US4_1 -> (* ModelB *)
                        US1_1
                    | US4_2 -> (* ModelC *)
                        US1_0
                | US4_2 -> (* ModelC *)
                    match v5 with
                    | US4_0 -> (* ModelA *)
                        US1_2
                    | US4_1 -> (* ModelB *)
                        US1_2
                    | US4_2 -> (* ModelC *)
                        US1_1
            match v18 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        | _ ->
            false
    | UH4_0 -> (* RegexEmpty *)
        match v1 with
        | UH4_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH4_1 -> (* RegexEpsilon *)
        match v1 with
        | UH4_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH4_5(v37) -> (* RegexStar *)
        match v1 with
        | UH4_5(v38) -> (* RegexStar *)
            method29(v37, v38)
        | _ ->
            false
and method28 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* RegexEmpty *)
        UH4_0
    | _ ->
        match v1 with
        | UH4_0 -> (* RegexEmpty *)
            UH4_0
        | _ ->
            match v0 with
            | UH4_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH4_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH4_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH4 = method28(v13, v1)
                        UH4_4(v12, v14)
                    | UH4_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH4_5(v5) -> (* RegexStar *)
                            let v6 : bool = method29(v4, v5)
                            if v6 then
                                UH4_5(v4)
                            else
                                UH4_4(v0, v1)
                        | _ ->
                            UH4_4(v0, v1)
                    | _ ->
                        UH4_4(v0, v1)
and method30 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* RegexEmpty *)
        UH4_1
    | UH4_1 -> (* RegexEpsilon *)
        UH4_1
    | UH4_5(v3) -> (* RegexStar *)
        UH4_5(v3)
    | _ ->
        UH4_5(v0)
and method24 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH4 = method24(v5)
        let v8 : UH4 = method24(v6)
        method25(v7, v8)
    | UH4_4(v10, v11) -> (* RegexCat *)
        let v12 : UH4 = method24(v10)
        let v13 : UH4 = method24(v11)
        method28(v12, v13)
    | UH4_2(v3) -> (* RegexChar *)
        UH4_2(v3)
    | UH4_0 -> (* RegexEmpty *)
        UH4_0
    | UH4_1 -> (* RegexEpsilon *)
        UH4_1
    | UH4_5(v15) -> (* RegexStar *)
        let v16 : UH4 = method24(v15)
        method30(v16)
and method32 (v0 : UH4) : US2 =
    match v0 with
    | UH4_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method32(v5)
        let v8 : US2 = method32(v6)
        match v7 with
        | US2_1 -> (* NonNullable *)
            match v8 with
            | US2_1 -> (* NonNullable *)
                US2_1
            | US2_0 -> (* Nullable *)
                US2_0
        | US2_0 -> (* Nullable *)
            US2_0
    | UH4_4(v14, v15) -> (* RegexCat *)
        let v16 : US2 = method32(v14)
        let v17 : US2 = method32(v15)
        match v16 with
        | US2_1 -> (* NonNullable *)
            US2_1
        | US2_0 -> (* Nullable *)
            match v17 with
            | US2_1 -> (* NonNullable *)
                US2_1
            | US2_0 -> (* Nullable *)
                US2_0
    | UH4_2(v3) -> (* RegexChar *)
        US2_1
    | UH4_0 -> (* RegexEmpty *)
        US2_1
    | UH4_1 -> (* RegexEpsilon *)
        US2_0
    | UH4_5(v23) -> (* RegexStar *)
        US2_0
and method31 (v0 : UH4, v1 : US4) : UH4 =
    match v0 with
    | UH4_3(v22, v23) -> (* RegexAlt *)
        let v24 : UH4 = method31(v22, v1)
        let v25 : UH4 = method31(v23, v1)
        method25(v24, v25)
    | UH4_4(v27, v28) -> (* RegexCat *)
        let v29 : US2 = method32(v27)
        match v29 with
        | US2_1 -> (* NonNullable *)
            let v34 : UH4 = method31(v27, v1)
            method28(v34, v28)
        | US2_0 -> (* Nullable *)
            let v30 : UH4 = method31(v27, v1)
            let v31 : UH4 = method28(v30, v28)
            let v32 : UH4 = method31(v28, v1)
            method25(v31, v32)
    | UH4_2(v4) -> (* RegexChar *)
        let v17 : US1 =
            match v4 with
            | US4_0 -> (* ModelA *)
                match v1 with
                | US4_0 -> (* ModelA *)
                    US1_1
                | US4_1 -> (* ModelB *)
                    US1_0
                | US4_2 -> (* ModelC *)
                    US1_0
            | US4_1 -> (* ModelB *)
                match v1 with
                | US4_0 -> (* ModelA *)
                    US1_2
                | US4_1 -> (* ModelB *)
                    US1_1
                | US4_2 -> (* ModelC *)
                    US1_0
            | US4_2 -> (* ModelC *)
                match v1 with
                | US4_0 -> (* ModelA *)
                    US1_2
                | US4_1 -> (* ModelB *)
                    US1_2
                | US4_2 -> (* ModelC *)
                    US1_1
        let v18 : bool =
            match v17 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        if v18 then
            UH4_1
        else
            UH4_0
    | UH4_0 -> (* RegexEmpty *)
        UH4_0
    | UH4_1 -> (* RegexEpsilon *)
        UH4_0
    | UH4_5(v37) -> (* RegexStar *)
        let v38 : UH4 = method31(v37, v1)
        let v39 : UH4 = method30(v37)
        method28(v38, v39)
and method23 (v0 : UH4, v1 : US4) : UH4 =
    let v2 : UH4 = method24(v0)
    let v3 : UH4 = method31(v2, v1)
    method24(v3)
and method22 (v0 : UH4, v1 : UH5) : bool =
    match v1 with
    | UH5_1(v5, v6) -> (* InputCons *)
        let v7 : UH4 = method23(v0, v5)
        method22(v7, v6)
    | UH5_0 -> (* InputEmpty *)
        let v2 : UH4 = method24(v0)
        let v3 : US2 = method32(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and method33 (v0 : UH6) : UH7 =
    match v0 with
    | UH6_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH7 = method33(v3)
        let v5 : UH1 = UH1_0
        let v6 : UH1 = UH1_1(v2, v5)
        UH7_1(v6, v4)
    | UH6_0 -> (* SymbolListNil *)
        UH7_0
and method35 (v0 : US0, v1 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = method35(v0, v4)
        let v6 : UH1 = UH1_1(v0, v3)
        UH7_1(v6, v5)
    | UH7_0 -> (* InputListNil *)
        UH7_0
and method36 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : UH7 = method36(v3, v1)
        UH7_1(v2, v4)
    | UH7_0 -> (* InputListNil *)
        v1
and method34 (v0 : UH6, v1 : UH7) : UH7 =
    match v0 with
    | UH6_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH7 = method35(v3, v1)
        let v6 : UH7 = method34(v4, v1)
        method36(v5, v6)
    | UH6_0 -> (* SymbolListNil *)
        UH7_0
and method37 (v0 : UH8) : UH9 =
    match v0 with
    | UH8_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH9 = method37(v3)
        let v5 : UH3 = UH3_0
        let v6 : UH3 = UH3_1(v2, v5)
        UH9_1(v6, v4)
    | UH8_0 -> (* SymbolListNil *)
        UH9_0
and method39 (v0 : US3, v1 : UH9) : UH9 =
    match v1 with
    | UH9_1(v3, v4) -> (* InputListCons *)
        let v5 : UH9 = method39(v0, v4)
        let v6 : UH3 = UH3_1(v0, v3)
        UH9_1(v6, v5)
    | UH9_0 -> (* InputListNil *)
        UH9_0
and method40 (v0 : UH9, v1 : UH9) : UH9 =
    match v0 with
    | UH9_1(v2, v3) -> (* InputListCons *)
        let v4 : UH9 = method40(v3, v1)
        UH9_1(v2, v4)
    | UH9_0 -> (* InputListNil *)
        v1
and method38 (v0 : UH8, v1 : UH9) : UH9 =
    match v0 with
    | UH8_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH9 = method39(v3, v1)
        let v6 : UH9 = method38(v4, v1)
        method40(v5, v6)
    | UH8_0 -> (* SymbolListNil *)
        UH9_0
and method42 (v0 : UH1) : US5 =
    match v0 with
    | UH1_1(v3, v4) -> (* InputCons *)
        let v7 : US1 =
            match v3 with
            | US0_1 -> (* BitOne *)
                US1_2
            | US0_0 -> (* BitZero *)
                US1_1
        let v8 : bool =
            match v7 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        let v25 : US6 =
            if v8 then
                let v9 : UH11 = UH11_0
                US6_1(v9)
            else
                let v13 : US1 =
                    match v3 with
                    | US0_1 -> (* BitOne *)
                        US1_1
                    | US0_0 -> (* BitZero *)
                        US1_0
                let v14 : bool =
                    match v13 with
                    | US1_2 -> (* SymbolGreater *)
                        false
                    | US1_0 -> (* SymbolLess *)
                        false
                    | US1_1 -> (* SymbolSame *)
                        true
                let v18 : US7 =
                    if v14 then
                        let v15 : UH12 = UH12_0
                        US7_1(v15)
                    else
                        US7_0
                match v18 with
                | US7_1(v20) -> (* FiniteSymbolFound *)
                    let v21 : UH11 = UH11_1(v20)
                    US6_1(v21)
                | US7_0 -> (* FiniteSymbolMissing *)
                    US6_0
        match v25 with
        | US6_1(v27) -> (* FiniteSymbolFound *)
            let v28 : US5 = method42(v4)
            match v28 with
            | US5_1(v30) -> (* InventoryInputCertified *)
                let v31 : UH10 = UH10_1(v27, v30)
                US5_1(v31)
            | US5_0 -> (* InventoryInputRejected *)
                US5_0
        | US6_0 -> (* FiniteSymbolMissing *)
            US5_0
    | UH1_0 -> (* InputEmpty *)
        let v1 : UH10 = UH10_0
        US5_1(v1)
and method43 (v0 : UH11, v1 : UH10) : bool =
    match v1 with
    | UH10_1(v6, v7) -> (* InventoryInputCons *)
        let v23 : UH13 =
            match v0 with
            | UH11_1(v14) -> (* FiniteSymbolIndexSucc *)
                match v14 with
                | UH12_0 -> (* FiniteSymbolIndexZero *)
                    let v15 : UH11 = UH11_0
                    let v16 : UH12 = UH12_0
                    let v17 : UH11 = UH11_1(v16)
                    let v18 : UH15 = UH15_0
                    let v19 : UH14 = UH14_0(v17, v18)
                    UH13_0(v15, v19)
            | UH11_0 -> (* FiniteSymbolIndexZero *)
                let v8 : UH11 = UH11_0
                let v9 : UH12 = UH12_0
                let v10 : UH11 = UH11_1(v9)
                let v11 : UH15 = UH15_0
                let v12 : UH14 = UH14_0(v10, v11)
                UH13_0(v8, v12)
        let v36 : UH11 =
            match v6 with
            | UH11_1(v27) -> (* FiniteSymbolIndexSucc *)
                match v23 with
                | UH13_0(v28, v29) -> (* InventoryDfaTargetVectorCons *)
                    match v27 with
                    | UH12_0 -> (* FiniteSymbolIndexZero *)
                        match v29 with
                        | UH14_0(v30, v31) -> (* InventoryDfaTargetVectorCons *)
                            v30
            | UH11_0 -> (* FiniteSymbolIndexZero *)
                match v23 with
                | UH13_0(v24, v25) -> (* InventoryDfaTargetVectorCons *)
                    v24
        method43(v36, v7)
    | UH10_0 -> (* InventoryInputEmpty *)
        match v0 with
        | UH11_1(v2) -> (* FiniteSymbolIndexSucc *)
            match v2 with
            | UH12_0 -> (* FiniteSymbolIndexZero *)
                false
        | UH11_0 -> (* FiniteSymbolIndexZero *)
            true
and method41 (v0 : UH7) : bool =
    match v0 with
    | UH7_1(v1, v2) -> (* InputListCons *)
        let v3 : US5 = method42(v1)
        let v13 : US8 =
            match v3 with
            | US5_1(v5) -> (* InventoryInputCertified *)
                let v6 : UH12 = UH12_0
                let v7 : UH11 = UH11_1(v6)
                let v8 : bool = method43(v7, v5)
                if v8 then
                    US8_0
                else
                    US8_1
            | US5_0 -> (* InventoryInputRejected *)
                US8_2
        let v35 : bool =
            match v13 with
            | US8_0 -> (* InventoryDfaAccepted *)
                let v14 : US0 = US0_0
                let v15 : UH0 = UH0_2(v14)
                let v16 : US0 = US0_1
                let v17 : UH0 = UH0_2(v16)
                let v18 : UH0 = UH0_3(v15, v17)
                let v19 : UH0 = UH0_5(v18)
                let v20 : US0 = US0_0
                let v21 : UH0 = UH0_2(v20)
                let v22 : UH0 = UH0_4(v19, v21)
                method0(v22, v1)
            | US8_2 -> (* InventoryDfaInputOutsideInventory *)
                false
            | US8_1 -> (* InventoryDfaRejected *)
                let v24 : US0 = US0_0
                let v25 : UH0 = UH0_2(v24)
                let v26 : US0 = US0_1
                let v27 : UH0 = UH0_2(v26)
                let v28 : UH0 = UH0_3(v25, v27)
                let v29 : UH0 = UH0_5(v28)
                let v30 : US0 = US0_0
                let v31 : UH0 = UH0_2(v30)
                let v32 : UH0 = UH0_4(v29, v31)
                let v33 : bool = method0(v32, v1)
                let v34 : bool = v33 = false
                v34
        if v35 then
            method41(v2)
        else
            false
    | UH7_0 -> (* InputListNil *)
        true
and method45 (v0 : UH3) : US9 =
    match v0 with
    | UH3_1(v3, v4) -> (* InputCons *)
        let v8 : US1 =
            match v3 with
            | US3_0 -> (* TriA *)
                US1_1
            | US3_1 -> (* TriB *)
                US1_2
            | US3_2 -> (* TriC *)
                US1_2
        let v9 : bool =
            match v8 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        let v41 : US10 =
            if v9 then
                let v10 : UH17 = UH17_0
                US10_1(v10)
            else
                let v15 : US1 =
                    match v3 with
                    | US3_0 -> (* TriA *)
                        US1_0
                    | US3_1 -> (* TriB *)
                        US1_1
                    | US3_2 -> (* TriC *)
                        US1_2
                let v16 : bool =
                    match v15 with
                    | US1_2 -> (* SymbolGreater *)
                        false
                    | US1_0 -> (* SymbolLess *)
                        false
                    | US1_1 -> (* SymbolSame *)
                        true
                let v34 : US6 =
                    if v16 then
                        let v17 : UH11 = UH11_0
                        US6_1(v17)
                    else
                        let v22 : US1 =
                            match v3 with
                            | US3_0 -> (* TriA *)
                                US1_0
                            | US3_1 -> (* TriB *)
                                US1_0
                            | US3_2 -> (* TriC *)
                                US1_1
                        let v23 : bool =
                            match v22 with
                            | US1_2 -> (* SymbolGreater *)
                                false
                            | US1_0 -> (* SymbolLess *)
                                false
                            | US1_1 -> (* SymbolSame *)
                                true
                        let v27 : US7 =
                            if v23 then
                                let v24 : UH12 = UH12_0
                                US7_1(v24)
                            else
                                US7_0
                        match v27 with
                        | US7_1(v29) -> (* FiniteSymbolFound *)
                            let v30 : UH11 = UH11_1(v29)
                            US6_1(v30)
                        | US7_0 -> (* FiniteSymbolMissing *)
                            US6_0
                match v34 with
                | US6_1(v36) -> (* FiniteSymbolFound *)
                    let v37 : UH17 = UH17_1(v36)
                    US10_1(v37)
                | US6_0 -> (* FiniteSymbolMissing *)
                    US10_0
        match v41 with
        | US10_1(v43) -> (* FiniteSymbolFound *)
            let v44 : US9 = method45(v4)
            match v44 with
            | US9_1(v46) -> (* InventoryInputCertified *)
                let v47 : UH16 = UH16_1(v43, v46)
                US9_1(v47)
            | US9_0 -> (* InventoryInputRejected *)
                US9_0
        | US10_0 -> (* FiniteSymbolMissing *)
            US9_0
    | UH3_0 -> (* InputEmpty *)
        let v1 : UH16 = UH16_0
        US9_1(v1)
and method46 (v0 : UH17, v1 : UH16) : bool =
    match v1 with
    | UH16_1(v9, v10) -> (* InventoryInputCons *)
        let v43 : UH18 =
            match v0 with
            | UH17_1(v18) -> (* FiniteSymbolIndexSucc *)
                match v18 with
                | UH11_1(v26) -> (* FiniteSymbolIndexSucc *)
                    match v26 with
                    | UH12_0 -> (* FiniteSymbolIndexZero *)
                        let v27 : UH12 = UH12_0
                        let v28 : UH11 = UH11_1(v27)
                        let v29 : UH17 = UH17_1(v28)
                        let v30 : UH12 = UH12_0
                        let v31 : UH11 = UH11_1(v30)
                        let v32 : UH17 = UH17_1(v31)
                        let v33 : UH11 = UH11_0
                        let v34 : UH17 = UH17_1(v33)
                        let v35 : UH21 = UH21_0
                        let v36 : UH20 = UH20_0(v34, v35)
                        let v37 : UH19 = UH19_0(v32, v36)
                        UH18_0(v29, v37)
                | UH11_0 -> (* FiniteSymbolIndexZero *)
                    let v19 : UH17 = UH17_0
                    let v20 : UH17 = UH17_0
                    let v21 : UH17 = UH17_0
                    let v22 : UH21 = UH21_0
                    let v23 : UH20 = UH20_0(v21, v22)
                    let v24 : UH19 = UH19_0(v20, v23)
                    UH18_0(v19, v24)
            | UH17_0 -> (* FiniteSymbolIndexZero *)
                let v11 : UH17 = UH17_0
                let v12 : UH17 = UH17_0
                let v13 : UH17 = UH17_0
                let v14 : UH21 = UH21_0
                let v15 : UH20 = UH20_0(v13, v14)
                let v16 : UH19 = UH19_0(v12, v15)
                UH18_0(v11, v16)
        let v65 : UH17 =
            match v9 with
            | UH17_1(v47) -> (* FiniteSymbolIndexSucc *)
                match v43 with
                | UH18_0(v48, v49) -> (* InventoryDfaTargetVectorCons *)
                    match v47 with
                    | UH11_1(v53) -> (* FiniteSymbolIndexSucc *)
                        match v49 with
                        | UH19_0(v54, v55) -> (* InventoryDfaTargetVectorCons *)
                            match v53 with
                            | UH12_0 -> (* FiniteSymbolIndexZero *)
                                match v55 with
                                | UH20_0(v56, v57) -> (* InventoryDfaTargetVectorCons *)
                                    v56
                    | UH11_0 -> (* FiniteSymbolIndexZero *)
                        match v49 with
                        | UH19_0(v50, v51) -> (* InventoryDfaTargetVectorCons *)
                            v50
            | UH17_0 -> (* FiniteSymbolIndexZero *)
                match v43 with
                | UH18_0(v44, v45) -> (* InventoryDfaTargetVectorCons *)
                    v44
        method46(v65, v10)
    | UH16_0 -> (* InventoryInputEmpty *)
        match v0 with
        | UH17_1(v2) -> (* FiniteSymbolIndexSucc *)
            match v2 with
            | UH11_1(v3) -> (* FiniteSymbolIndexSucc *)
                match v3 with
                | UH12_0 -> (* FiniteSymbolIndexZero *)
                    false
            | UH11_0 -> (* FiniteSymbolIndexZero *)
                true
        | UH17_0 -> (* FiniteSymbolIndexZero *)
            false
and method44 (v0 : UH9) : bool =
    match v0 with
    | UH9_1(v1, v2) -> (* InputListCons *)
        let v3 : US9 = method45(v1)
        let v14 : US8 =
            match v3 with
            | US9_1(v5) -> (* InventoryInputCertified *)
                let v6 : UH12 = UH12_0
                let v7 : UH11 = UH11_1(v6)
                let v8 : UH17 = UH17_1(v7)
                let v9 : bool = method46(v8, v5)
                if v9 then
                    US8_0
                else
                    US8_1
            | US9_0 -> (* InventoryInputRejected *)
                US8_2
        let v36 : bool =
            match v14 with
            | US8_0 -> (* InventoryDfaAccepted *)
                let v15 : US3 = US3_0
                let v16 : UH2 = UH2_2(v15)
                let v17 : US3 = US3_1
                let v18 : UH2 = UH2_2(v17)
                let v19 : UH2 = UH2_3(v16, v18)
                let v20 : UH2 = UH2_5(v19)
                let v21 : US3 = US3_2
                let v22 : UH2 = UH2_2(v21)
                let v23 : UH2 = UH2_4(v20, v22)
                method11(v23, v1)
            | US8_2 -> (* InventoryDfaInputOutsideInventory *)
                false
            | US8_1 -> (* InventoryDfaRejected *)
                let v25 : US3 = US3_0
                let v26 : UH2 = UH2_2(v25)
                let v27 : US3 = US3_1
                let v28 : UH2 = UH2_2(v27)
                let v29 : UH2 = UH2_3(v26, v28)
                let v30 : UH2 = UH2_5(v29)
                let v31 : US3 = US3_2
                let v32 : UH2 = UH2_2(v31)
                let v33 : UH2 = UH2_4(v30, v32)
                let v34 : bool = method11(v33, v1)
                let v35 : bool = v34 = false
                v35
        if v36 then
            method44(v2)
        else
            false
    | UH9_0 -> (* InputListNil *)
        true
and method47 (v0 : UH5) : US5 =
    match v0 with
    | UH5_1(v3, v4) -> (* InputCons *)
        let v8 : US1 =
            match v3 with
            | US4_0 -> (* ModelA *)
                US1_1
            | US4_1 -> (* ModelB *)
                US1_2
            | US4_2 -> (* ModelC *)
                US1_2
        let v9 : bool =
            match v8 with
            | US1_2 -> (* SymbolGreater *)
                false
            | US1_0 -> (* SymbolLess *)
                false
            | US1_1 -> (* SymbolSame *)
                true
        let v27 : US6 =
            if v9 then
                let v10 : UH11 = UH11_0
                US6_1(v10)
            else
                let v15 : US1 =
                    match v3 with
                    | US4_0 -> (* ModelA *)
                        US1_0
                    | US4_1 -> (* ModelB *)
                        US1_1
                    | US4_2 -> (* ModelC *)
                        US1_2
                let v16 : bool =
                    match v15 with
                    | US1_2 -> (* SymbolGreater *)
                        false
                    | US1_0 -> (* SymbolLess *)
                        false
                    | US1_1 -> (* SymbolSame *)
                        true
                let v20 : US7 =
                    if v16 then
                        let v17 : UH12 = UH12_0
                        US7_1(v17)
                    else
                        US7_0
                match v20 with
                | US7_1(v22) -> (* FiniteSymbolFound *)
                    let v23 : UH11 = UH11_1(v22)
                    US6_1(v23)
                | US7_0 -> (* FiniteSymbolMissing *)
                    US6_0
        match v27 with
        | US6_1(v29) -> (* FiniteSymbolFound *)
            let v30 : US5 = method47(v4)
            match v30 with
            | US5_1(v32) -> (* InventoryInputCertified *)
                let v33 : UH10 = UH10_1(v29, v32)
                US5_1(v33)
            | US5_0 -> (* InventoryInputRejected *)
                US5_0
        | US6_0 -> (* FiniteSymbolMissing *)
            US5_0
    | UH5_0 -> (* InputEmpty *)
        let v1 : UH10 = UH10_0
        US5_1(v1)
and method48 (v0 : UH11, v1 : UH10) : bool =
    match v1 with
    | UH10_1(v6, v7) -> (* InventoryInputCons *)
        let v22 : UH13 =
            match v0 with
            | UH11_1(v13) -> (* FiniteSymbolIndexSucc *)
                match v13 with
                | UH12_0 -> (* FiniteSymbolIndexZero *)
                    let v14 : UH12 = UH12_0
                    let v15 : UH11 = UH11_1(v14)
                    let v16 : UH11 = UH11_0
                    let v17 : UH15 = UH15_0
                    let v18 : UH14 = UH14_0(v16, v17)
                    UH13_0(v15, v18)
            | UH11_0 -> (* FiniteSymbolIndexZero *)
                let v8 : UH11 = UH11_0
                let v9 : UH11 = UH11_0
                let v10 : UH15 = UH15_0
                let v11 : UH14 = UH14_0(v9, v10)
                UH13_0(v8, v11)
        let v35 : UH11 =
            match v6 with
            | UH11_1(v26) -> (* FiniteSymbolIndexSucc *)
                match v22 with
                | UH13_0(v27, v28) -> (* InventoryDfaTargetVectorCons *)
                    match v26 with
                    | UH12_0 -> (* FiniteSymbolIndexZero *)
                        match v28 with
                        | UH14_0(v29, v30) -> (* InventoryDfaTargetVectorCons *)
                            v29
            | UH11_0 -> (* FiniteSymbolIndexZero *)
                match v22 with
                | UH13_0(v23, v24) -> (* InventoryDfaTargetVectorCons *)
                    v23
        method48(v35, v7)
    | UH10_0 -> (* InventoryInputEmpty *)
        match v0 with
        | UH11_1(v2) -> (* FiniteSymbolIndexSucc *)
            match v2 with
            | UH12_0 -> (* FiniteSymbolIndexZero *)
                true
        | UH11_0 -> (* FiniteSymbolIndexZero *)
            false
let v0 : UH0 = UH0_1
let v1 : US0 = US0_0
let v2 : UH0 = UH0_2(v1)
let v3 : US0 = US0_1
let v4 : UH0 = UH0_2(v3)
let v5 : UH0 = UH0_3(v2, v4)
let v6 : UH0 = UH0_5(v5)
let v7 : UH0 = UH0_2(v1)
let v8 : UH0 = UH0_4(v6, v7)
let v9 : UH0 = UH0_3(v0, v8)
let v10 : UH1 = UH1_0
let v11 : bool = method0(v9, v10)
let v23 : bool =
    if v11 then
        let v12 : US0 = US0_0
        let v13 : UH0 = UH0_2(v12)
        let v14 : US0 = US0_1
        let v15 : UH0 = UH0_2(v14)
        let v16 : UH0 = UH0_3(v13, v15)
        let v17 : UH0 = UH0_5(v16)
        let v18 : UH0 = UH0_2(v12)
        let v19 : UH0 = UH0_4(v17, v18)
        let v20 : UH1 = UH1_0
        let v21 : bool = method0(v19, v20)
        let v22 : bool = false = v21
        v22
    else
        false
let v111 : bool =
    if v23 then
        let v24 : UH0 = UH0_1
        let v25 : US0 = US0_0
        let v26 : UH0 = UH0_2(v25)
        let v27 : US0 = US0_1
        let v28 : UH0 = UH0_2(v27)
        let v29 : UH0 = UH0_3(v26, v28)
        let v30 : UH0 = UH0_5(v29)
        let v31 : UH0 = UH0_2(v25)
        let v32 : UH0 = UH0_4(v30, v31)
        let v33 : UH0 = UH0_3(v24, v32)
        let v34 : US0 = US0_0
        let v35 : UH0 = method1(v33, v34)
        let v36 : UH0 = UH0_1
        let v37 : US0 = US0_0
        let v38 : UH0 = UH0_2(v37)
        let v39 : US0 = US0_1
        let v40 : UH0 = UH0_2(v39)
        let v41 : UH0 = UH0_3(v38, v40)
        let v42 : UH0 = UH0_5(v41)
        let v43 : UH0 = UH0_2(v37)
        let v44 : UH0 = UH0_4(v42, v43)
        let v45 : UH0 = UH0_3(v36, v44)
        let v46 : bool = method7(v35, v45)
        let v68 : bool =
            if v46 then
                let v47 : UH0 = UH0_1
                let v48 : US0 = US0_0
                let v49 : UH0 = UH0_2(v48)
                let v50 : US0 = US0_1
                let v51 : UH0 = UH0_2(v50)
                let v52 : UH0 = UH0_3(v49, v51)
                let v53 : UH0 = UH0_5(v52)
                let v54 : UH0 = UH0_2(v48)
                let v55 : UH0 = UH0_4(v53, v54)
                let v56 : UH0 = UH0_3(v47, v55)
                let v57 : US0 = US0_1
                let v58 : UH0 = method1(v56, v57)
                let v59 : US0 = US0_0
                let v60 : UH0 = UH0_2(v59)
                let v61 : US0 = US0_1
                let v62 : UH0 = UH0_2(v61)
                let v63 : UH0 = UH0_3(v60, v62)
                let v64 : UH0 = UH0_5(v63)
                let v65 : UH0 = UH0_2(v59)
                let v66 : UH0 = UH0_4(v64, v65)
                method7(v58, v66)
            else
                false
        if v68 then
            let v69 : US0 = US0_0
            let v70 : UH0 = UH0_2(v69)
            let v71 : US0 = US0_1
            let v72 : UH0 = UH0_2(v71)
            let v73 : UH0 = UH0_3(v70, v72)
            let v74 : UH0 = UH0_5(v73)
            let v75 : UH0 = UH0_2(v69)
            let v76 : UH0 = UH0_4(v74, v75)
            let v77 : US0 = US0_0
            let v78 : UH0 = method1(v76, v77)
            let v79 : UH0 = UH0_1
            let v80 : US0 = US0_0
            let v81 : UH0 = UH0_2(v80)
            let v82 : US0 = US0_1
            let v83 : UH0 = UH0_2(v82)
            let v84 : UH0 = UH0_3(v81, v83)
            let v85 : UH0 = UH0_5(v84)
            let v86 : UH0 = UH0_2(v80)
            let v87 : UH0 = UH0_4(v85, v86)
            let v88 : UH0 = UH0_3(v79, v87)
            let v89 : bool = method7(v78, v88)
            if v89 then
                let v90 : US0 = US0_0
                let v91 : UH0 = UH0_2(v90)
                let v92 : US0 = US0_1
                let v93 : UH0 = UH0_2(v92)
                let v94 : UH0 = UH0_3(v91, v93)
                let v95 : UH0 = UH0_5(v94)
                let v96 : UH0 = UH0_2(v90)
                let v97 : UH0 = UH0_4(v95, v96)
                let v98 : US0 = US0_1
                let v99 : UH0 = method1(v97, v98)
                let v100 : US0 = US0_0
                let v101 : UH0 = UH0_2(v100)
                let v102 : US0 = US0_1
                let v103 : UH0 = UH0_2(v102)
                let v104 : UH0 = UH0_3(v101, v103)
                let v105 : UH0 = UH0_5(v104)
                let v106 : UH0 = UH0_2(v100)
                let v107 : UH0 = UH0_4(v105, v106)
                method7(v99, v107)
            else
                false
        else
            false
    else
        false
let v227 : bool =
    if v111 then
        let v112 : UH2 = UH2_0
        let v113 : UH3 = UH3_0
        let v114 : bool = method11(v112, v113)
        let v115 : bool = false = v114
        let v132 : bool =
            if v115 then
                let v116 : UH2 = UH2_1
                let v117 : UH3 = UH3_0
                let v118 : bool = method11(v116, v117)
                if v118 then
                    let v119 : US3 = US3_0
                    let v120 : UH2 = UH2_2(v119)
                    let v121 : US3 = US3_1
                    let v122 : UH2 = UH2_2(v121)
                    let v123 : UH2 = UH2_3(v120, v122)
                    let v124 : UH2 = UH2_5(v123)
                    let v125 : US3 = US3_2
                    let v126 : UH2 = UH2_2(v125)
                    let v127 : UH2 = UH2_4(v124, v126)
                    let v128 : UH3 = UH3_0
                    let v129 : bool = method11(v127, v128)
                    let v130 : bool = false = v129
                    v130
                else
                    false
            else
                false
        if v132 then
            let v133 : UH2 = UH2_0
            let v134 : US3 = US3_0
            let v135 : UH2 = method12(v133, v134)
            let v136 : UH2 = UH2_0
            let v137 : bool = method18(v135, v136)
            let v149 : bool =
                if v137 then
                    let v138 : UH2 = UH2_0
                    let v139 : US3 = US3_1
                    let v140 : UH2 = method12(v138, v139)
                    let v141 : UH2 = UH2_0
                    let v142 : bool = method18(v140, v141)
                    if v142 then
                        let v143 : UH2 = UH2_0
                        let v144 : US3 = US3_2
                        let v145 : UH2 = method12(v143, v144)
                        let v146 : UH2 = UH2_0
                        method18(v145, v146)
                    else
                        false
                else
                    false
            if v149 then
                let v150 : UH2 = UH2_1
                let v151 : US3 = US3_0
                let v152 : UH2 = method12(v150, v151)
                let v153 : UH2 = UH2_0
                let v154 : bool = method18(v152, v153)
                let v166 : bool =
                    if v154 then
                        let v155 : UH2 = UH2_1
                        let v156 : US3 = US3_1
                        let v157 : UH2 = method12(v155, v156)
                        let v158 : UH2 = UH2_0
                        let v159 : bool = method18(v157, v158)
                        if v159 then
                            let v160 : UH2 = UH2_1
                            let v161 : US3 = US3_2
                            let v162 : UH2 = method12(v160, v161)
                            let v163 : UH2 = UH2_0
                            method18(v162, v163)
                        else
                            false
                    else
                        false
                if v166 then
                    let v167 : US3 = US3_0
                    let v168 : UH2 = UH2_2(v167)
                    let v169 : US3 = US3_1
                    let v170 : UH2 = UH2_2(v169)
                    let v171 : UH2 = UH2_3(v168, v170)
                    let v172 : UH2 = UH2_5(v171)
                    let v173 : US3 = US3_2
                    let v174 : UH2 = UH2_2(v173)
                    let v175 : UH2 = UH2_4(v172, v174)
                    let v176 : US3 = US3_0
                    let v177 : UH2 = method12(v175, v176)
                    let v178 : US3 = US3_0
                    let v179 : UH2 = UH2_2(v178)
                    let v180 : US3 = US3_1
                    let v181 : UH2 = UH2_2(v180)
                    let v182 : UH2 = UH2_3(v179, v181)
                    let v183 : UH2 = UH2_5(v182)
                    let v184 : US3 = US3_2
                    let v185 : UH2 = UH2_2(v184)
                    let v186 : UH2 = UH2_4(v183, v185)
                    let v187 : bool = method18(v177, v186)
                    if v187 then
                        let v188 : US3 = US3_0
                        let v189 : UH2 = UH2_2(v188)
                        let v190 : US3 = US3_1
                        let v191 : UH2 = UH2_2(v190)
                        let v192 : UH2 = UH2_3(v189, v191)
                        let v193 : UH2 = UH2_5(v192)
                        let v194 : US3 = US3_2
                        let v195 : UH2 = UH2_2(v194)
                        let v196 : UH2 = UH2_4(v193, v195)
                        let v197 : US3 = US3_1
                        let v198 : UH2 = method12(v196, v197)
                        let v199 : US3 = US3_0
                        let v200 : UH2 = UH2_2(v199)
                        let v201 : US3 = US3_1
                        let v202 : UH2 = UH2_2(v201)
                        let v203 : UH2 = UH2_3(v200, v202)
                        let v204 : UH2 = UH2_5(v203)
                        let v205 : US3 = US3_2
                        let v206 : UH2 = UH2_2(v205)
                        let v207 : UH2 = UH2_4(v204, v206)
                        let v208 : bool = method18(v198, v207)
                        if v208 then
                            let v209 : US3 = US3_0
                            let v210 : UH2 = UH2_2(v209)
                            let v211 : US3 = US3_1
                            let v212 : UH2 = UH2_2(v211)
                            let v213 : UH2 = UH2_3(v210, v212)
                            let v214 : UH2 = UH2_5(v213)
                            let v215 : US3 = US3_2
                            let v216 : UH2 = UH2_2(v215)
                            let v217 : UH2 = UH2_4(v214, v216)
                            let v218 : US3 = US3_2
                            let v219 : UH2 = method12(v217, v218)
                            let v220 : UH2 = UH2_1
                            method18(v219, v220)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        else
            false
    else
        false
let v268 : bool =
    if v227 then
        let v228 : UH4 = UH4_0
        let v229 : UH5 = UH5_0
        let v230 : bool = method22(v228, v229)
        let v231 : bool = false = v230
        let v237 : bool =
            if v231 then
                let v232 : US4 = US4_0
                let v233 : UH4 = UH4_2(v232)
                let v234 : UH4 = UH4_5(v233)
                let v235 : UH5 = UH5_0
                method22(v234, v235)
            else
                false
        if v237 then
            let v238 : UH4 = UH4_0
            let v239 : US4 = US4_0
            let v240 : UH4 = method23(v238, v239)
            let v241 : UH4 = UH4_0
            let v242 : bool = method29(v240, v241)
            let v248 : bool =
                if v242 then
                    let v243 : UH4 = UH4_0
                    let v244 : US4 = US4_1
                    let v245 : UH4 = method23(v243, v244)
                    let v246 : UH4 = UH4_0
                    method29(v245, v246)
                else
                    false
            if v248 then
                let v249 : US4 = US4_0
                let v250 : UH4 = UH4_2(v249)
                let v251 : UH4 = UH4_5(v250)
                let v252 : US4 = US4_0
                let v253 : UH4 = method23(v251, v252)
                let v254 : US4 = US4_0
                let v255 : UH4 = UH4_2(v254)
                let v256 : UH4 = UH4_5(v255)
                let v257 : bool = method29(v253, v256)
                if v257 then
                    let v258 : US4 = US4_0
                    let v259 : UH4 = UH4_2(v258)
                    let v260 : UH4 = UH4_5(v259)
                    let v261 : US4 = US4_1
                    let v262 : UH4 = method23(v260, v261)
                    let v263 : UH4 = UH4_0
                    method29(v262, v263)
                else
                    false
            else
                false
        else
            false
    else
        false
let v269 : US0 = US0_0
let v270 : US0 = US0_1
let v271 : UH6 = UH6_0
let v272 : UH6 = UH6_1(v270, v271)
let v273 : UH6 = UH6_1(v269, v272)
let v274 : UH7 = method33(v273)
let v275 : UH1 = UH1_0
let v276 : UH7 = UH7_1(v275, v274)
let v277 : US0 = US0_0
let v278 : US0 = US0_1
let v279 : UH6 = UH6_0
let v280 : UH6 = UH6_1(v278, v279)
let v281 : UH6 = UH6_1(v277, v280)
let v282 : US0 = US0_0
let v283 : US0 = US0_1
let v284 : UH6 = UH6_0
let v285 : UH6 = UH6_1(v283, v284)
let v286 : UH6 = UH6_1(v282, v285)
let v287 : UH7 = method33(v286)
let v288 : UH7 = method34(v281, v287)
let v289 : UH7 = method36(v276, v288)
let v290 : US3 = US3_0
let v291 : US3 = US3_1
let v292 : US3 = US3_2
let v293 : UH8 = UH8_0
let v294 : UH8 = UH8_1(v292, v293)
let v295 : UH8 = UH8_1(v291, v294)
let v296 : UH8 = UH8_1(v290, v295)
let v297 : UH9 = method37(v296)
let v298 : UH3 = UH3_0
let v299 : UH9 = UH9_1(v298, v297)
let v300 : US3 = US3_0
let v301 : US3 = US3_1
let v302 : US3 = US3_2
let v303 : UH8 = UH8_0
let v304 : UH8 = UH8_1(v302, v303)
let v305 : UH8 = UH8_1(v301, v304)
let v306 : UH8 = UH8_1(v300, v305)
let v307 : US3 = US3_0
let v308 : US3 = US3_1
let v309 : US3 = US3_2
let v310 : UH8 = UH8_0
let v311 : UH8 = UH8_1(v309, v310)
let v312 : UH8 = UH8_1(v308, v311)
let v313 : UH8 = UH8_1(v307, v312)
let v314 : UH9 = method37(v313)
let v315 : UH9 = method38(v306, v314)
let v316 : UH9 = method40(v299, v315)
let v317 : US4 = US4_2
let v318 : UH5 = UH5_0
let v319 : UH5 = UH5_1(v317, v318)
let v336 : bool =
    if v268 then
        let v320 : bool = method41(v289)
        if v320 then
            let v321 : bool = method44(v316)
            if v321 then
                let v322 : US5 = method47(v319)
                let v332 : US8 =
                    match v322 with
                    | US5_1(v324) -> (* InventoryInputCertified *)
                        let v325 : UH12 = UH12_0
                        let v326 : UH11 = UH11_1(v325)
                        let v327 : bool = method48(v326, v324)
                        if v327 then
                            US8_0
                        else
                            US8_1
                    | US5_0 -> (* InventoryInputRejected *)
                        US8_2
                match v332 with
                | US8_0 -> (* InventoryDfaAccepted *)
                    false
                | US8_2 -> (* InventoryDfaInputOutsideInventory *)
                    true
                | US8_1 -> (* InventoryDfaRejected *)
                    false
            else
                false
        else
            false
    else
        false
if not v336 then failwith "brzozowski-expected-true"
true
