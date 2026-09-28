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
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US1
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and UH3 =
    | UH3_0
    | UH3_1 of US1 * UH3
and [<Struct>] US2 =
    | US2_0
    | US2_1
    | US2_2
and [<Struct>] US3 =
    | US3_0
    | US3_1
and UH4 =
    | UH4_0
    | UH4_1 of UH1 * UH4
and UH5 =
    | UH5_0
    | UH5_1 of UH3 * UH5
let rec method4 (v0 : UH0, v1 : UH0) : US2 =
    match v0 with
    | UH0_3(v50, v51) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v52, v53) -> (* RegexAlt *)
            let v54 : US2 = method4(v50, v52)
            match v54 with
            | US2_2 -> (* SymbolGreater *)
                v54
            | US2_0 -> (* SymbolLess *)
                v54
            | US2_1 -> (* SymbolSame *)
                method4(v51, v53)
        | _ ->
            US2_2
    | UH0_4(v25, v26) -> (* RegexCat *)
        match v1 with
        | UH0_4(v31, v32) -> (* RegexCat *)
            let v33 : US2 = method4(v25, v31)
            match v33 with
            | US2_2 -> (* SymbolGreater *)
                v33
            | US2_0 -> (* SymbolLess *)
                v33
            | US2_1 -> (* SymbolSame *)
                method4(v26, v32)
        | UH0_2(v29) -> (* RegexChar *)
            US2_2
        | UH0_0 -> (* RegexEmpty *)
            US2_2
        | UH0_1 -> (* RegexEpsilon *)
            US2_2
        | _ ->
            US2_0
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_2(v13) -> (* RegexChar *)
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
        | UH0_0 -> (* RegexEmpty *)
            US2_2
        | UH0_1 -> (* RegexEpsilon *)
            US2_2
        | _ ->
            US2_0
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US2_1
        | _ ->
            US2_0
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US2_2
        | UH0_1 -> (* RegexEpsilon *)
            US2_1
        | _ ->
            US2_0
    | UH0_5(v41) -> (* RegexStar *)
        match v1 with
        | UH0_3(v42, v43) -> (* RegexAlt *)
            US2_0
        | UH0_5(v45) -> (* RegexStar *)
            method4(v41, v45)
        | _ ->
            US2_2
and method3 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method4(v0, v2)
        match v4 with
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH0 = method3(v0, v3)
            UH0_3(v2, v6)
        | US2_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
    | UH0_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US2 = method4(v0, v1)
        match v9 with
        | US2_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
        | US2_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
and method2 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method3(v2, v1)
        method2(v3, v4)
    | UH0_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method3(v0, v1)
and method6 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_3(v15, v16) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v17, v18) -> (* RegexAlt *)
            let v19 : bool = method6(v15, v17)
            if v19 then
                method6(v16, v18)
            else
                false
        | _ ->
            false
    | UH0_4(v23, v24) -> (* RegexCat *)
        match v1 with
        | UH0_4(v25, v26) -> (* RegexCat *)
            let v27 : bool = method6(v23, v25)
            if v27 then
                method6(v24, v26)
            else
                false
        | _ ->
            false
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
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
            method6(v31, v32)
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
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method1(v5)
        let v8 : UH0 = method1(v6)
        method2(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method1(v10)
        let v13 : UH0 = method1(v11)
        method5(v12, v13)
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method1(v15)
        method7(v16)
and method9 (v0 : UH0) : US3 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method9(v5)
        let v8 : US3 = method9(v6)
        match v7 with
        | US3_1 -> (* NonNullable *)
            match v8 with
            | US3_1 -> (* NonNullable *)
                US3_1
            | US3_0 -> (* Nullable *)
                US3_0
        | US3_0 -> (* Nullable *)
            US3_0
    | UH0_4(v14, v15) -> (* RegexCat *)
        let v16 : US3 = method9(v14)
        let v17 : US3 = method9(v15)
        match v16 with
        | US3_1 -> (* NonNullable *)
            US3_1
        | US3_0 -> (* Nullable *)
            match v17 with
            | US3_1 -> (* NonNullable *)
                US3_1
            | US3_0 -> (* Nullable *)
                US3_0
    | UH0_2(v3) -> (* RegexChar *)
        US3_1
    | UH0_0 -> (* RegexEmpty *)
        US3_1
    | UH0_1 -> (* RegexEpsilon *)
        US3_0
    | UH0_5(v23) -> (* RegexStar *)
        US3_0
and method8 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v16, v17) -> (* RegexAlt *)
        let v18 : UH0 = method8(v16, v1)
        let v19 : UH0 = method8(v17, v1)
        method2(v18, v19)
    | UH0_4(v21, v22) -> (* RegexCat *)
        let v23 : US3 = method9(v21)
        match v23 with
        | US3_1 -> (* NonNullable *)
            let v28 : UH0 = method8(v21, v1)
            method5(v28, v22)
        | US3_0 -> (* Nullable *)
            let v24 : UH0 = method8(v21, v1)
            let v25 : UH0 = method5(v24, v22)
            let v26 : UH0 = method8(v22, v1)
            method2(v25, v26)
    | UH0_2(v4) -> (* RegexChar *)
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
            UH0_1
        else
            UH0_0
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_5(v31) -> (* RegexStar *)
        let v32 : UH0 = method8(v31, v1)
        let v33 : UH0 = method7(v31)
        method5(v32, v33)
and method0 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method1(v0)
    let v3 : UH0 = method8(v2, v1)
    method1(v3)
and method11 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_1(v2, v3) -> (* InputListCons *)
        let v4 : UH4 = method11(v3, v1)
        UH4_1(v2, v4)
    | UH4_0 -> (* InputListNil *)
        v1
and method12 (v0 : UH0, v1 : UH4) : UH4 =
    match v1 with
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = method10(v0, v3)
        let v6 : UH4 = method12(v0, v4)
        method11(v5, v6)
    | UH4_0 -> (* InputListNil *)
        UH4_0
and method16 (v0 : UH1, v1 : UH1) : bool =
    match v0 with
    | UH1_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH1_1(v5, v6) -> (* InputCons *)
            let v13 : US2 =
                match v3 with
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
            let v14 : bool =
                match v13 with
                | US2_2 -> (* SymbolGreater *)
                    false
                | US2_0 -> (* SymbolLess *)
                    false
                | US2_1 -> (* SymbolSame *)
                    true
            if v14 then
                method16(v4, v6)
            else
                false
        | _ ->
            false
    | UH1_0 -> (* InputEmpty *)
        match v1 with
        | UH1_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and method15 (v0 : UH1, v1 : UH4) : bool =
    match v1 with
    | UH4_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method16(v0, v2)
        if v4 then
            true
        else
            method15(v0, v3)
    | UH4_0 -> (* InputListNil *)
        false
and method14 (v0 : UH4, v1 : UH4, v2 : UH4) : struct (UH4 * UH4) =
    match v0 with
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method15(v3, v1)
        if v5 then
            method14(v4, v1, v2)
        else
            let v8 : UH4 = UH4_1(v3, v1)
            let v9 : UH4 = UH4_1(v3, v2)
            method14(v4, v8, v9)
    | UH4_0 -> (* InputListNil *)
        struct (v1, v2)
and method13 (v0 : UH0, v1 : UH4, v2 : UH4) : UH4 =
    match v1 with
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = method10(v0, v3)
        let struct (v6 : UH4, v7 : UH4) = method14(v5, v2, v4)
        method13(v0, v7, v6)
    | UH4_0 -> (* InputListNil *)
        v2
and method10 (v0 : UH0, v1 : UH1) : UH4 =
    match v0 with
    | UH0_3(v23, v24) -> (* RegexAlt *)
        let v25 : UH4 = method10(v23, v1)
        let v26 : UH4 = method10(v24, v1)
        method11(v25, v26)
    | UH0_4(v28, v29) -> (* RegexCat *)
        let v30 : UH4 = method10(v28, v1)
        method12(v29, v30)
    | UH0_2(v5) -> (* RegexChar *)
        match v1 with
        | UH1_1(v7, v8) -> (* InputCons *)
            let v15 : US2 =
                match v5 with
                | US0_1 -> (* BitOne *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US2_1
                    | US0_0 -> (* BitZero *)
                        US2_2
                | US0_0 -> (* BitZero *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US2_0
                    | US0_0 -> (* BitZero *)
                        US2_1
            let v16 : bool =
                match v15 with
                | US2_2 -> (* SymbolGreater *)
                    false
                | US2_0 -> (* SymbolLess *)
                    false
                | US2_1 -> (* SymbolSame *)
                    true
            if v16 then
                let v17 : UH4 = UH4_0
                UH4_1(v8, v17)
            else
                UH4_0
        | UH1_0 -> (* InputEmpty *)
            UH4_0
    | UH0_0 -> (* RegexEmpty *)
        UH4_0
    | UH0_1 -> (* RegexEpsilon *)
        let v3 : UH4 = UH4_0
        UH4_1(v1, v3)
    | UH0_5(v32) -> (* RegexStar *)
        let v33 : UH4 = UH4_0
        let v34 : UH4 = UH4_1(v1, v33)
        let v35 : UH4 = UH4_0
        let v36 : UH4 = UH4_1(v1, v35)
        method13(v32, v34, v36)
and method17 (v0 : UH1, v1 : UH4) : UH4 =
    match v1 with
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method16(v0, v3)
        if v5 then
            method17(v0, v4)
        else
            let v7 : UH4 = method17(v0, v4)
            UH4_1(v3, v7)
    | UH4_0 -> (* InputListNil *)
        UH4_0
and method18 (v0 : UH4, v1 : UH4) : bool =
    match v0 with
    | UH4_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method15(v2, v1)
        if v4 then
            method18(v3, v1)
        else
            false
    | UH4_0 -> (* InputListNil *)
        true
and method23 (v0 : UH2, v1 : UH2) : US2 =
    match v0 with
    | UH2_3(v56, v57) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v58, v59) -> (* RegexAlt *)
            let v60 : US2 = method23(v56, v58)
            match v60 with
            | US2_2 -> (* SymbolGreater *)
                v60
            | US2_0 -> (* SymbolLess *)
                v60
            | US2_1 -> (* SymbolSame *)
                method23(v57, v59)
        | _ ->
            US2_2
    | UH2_4(v31, v32) -> (* RegexCat *)
        match v1 with
        | UH2_4(v37, v38) -> (* RegexCat *)
            let v39 : US2 = method23(v31, v37)
            match v39 with
            | US2_2 -> (* SymbolGreater *)
                v39
            | US2_0 -> (* SymbolLess *)
                v39
            | US2_1 -> (* SymbolSame *)
                method23(v32, v38)
        | UH2_2(v35) -> (* RegexChar *)
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
    | UH2_5(v47) -> (* RegexStar *)
        match v1 with
        | UH2_3(v48, v49) -> (* RegexAlt *)
            US2_0
        | UH2_5(v51) -> (* RegexStar *)
            method23(v47, v51)
        | _ ->
            US2_2
and method22 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method23(v0, v2)
        match v4 with
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH2 = method22(v0, v3)
            UH2_3(v2, v6)
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
    | UH2_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v9 : US2 = method23(v0, v1)
        match v9 with
        | US2_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
and method21 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method22(v2, v1)
        method21(v3, v4)
    | UH2_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method22(v0, v1)
and method25 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_3(v21, v22) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v23, v24) -> (* RegexAlt *)
            let v25 : bool = method25(v21, v23)
            if v25 then
                method25(v22, v24)
            else
                false
        | _ ->
            false
    | UH2_4(v29, v30) -> (* RegexCat *)
        match v1 with
        | UH2_4(v31, v32) -> (* RegexCat *)
            let v33 : bool = method25(v29, v31)
            if v33 then
                method25(v30, v32)
            else
                false
        | _ ->
            false
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
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
            method25(v37, v38)
        | _ ->
            false
and method24 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method24(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method25(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method26 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method20 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method20(v5)
        let v8 : UH2 = method20(v6)
        method21(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method20(v10)
        let v13 : UH2 = method20(v11)
        method24(v12, v13)
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method20(v15)
        method26(v16)
and method28 (v0 : UH2) : US3 =
    match v0 with
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method28(v5)
        let v8 : US3 = method28(v6)
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
        let v16 : US3 = method28(v14)
        let v17 : US3 = method28(v15)
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
and method27 (v0 : UH2, v1 : US1) : UH2 =
    match v0 with
    | UH2_3(v22, v23) -> (* RegexAlt *)
        let v24 : UH2 = method27(v22, v1)
        let v25 : UH2 = method27(v23, v1)
        method21(v24, v25)
    | UH2_4(v27, v28) -> (* RegexCat *)
        let v29 : US3 = method28(v27)
        match v29 with
        | US3_1 -> (* NonNullable *)
            let v34 : UH2 = method27(v27, v1)
            method24(v34, v28)
        | US3_0 -> (* Nullable *)
            let v30 : UH2 = method27(v27, v1)
            let v31 : UH2 = method24(v30, v28)
            let v32 : UH2 = method27(v28, v1)
            method21(v31, v32)
    | UH2_2(v4) -> (* RegexChar *)
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
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v37) -> (* RegexStar *)
        let v38 : UH2 = method27(v37, v1)
        let v39 : UH2 = method26(v37)
        method24(v38, v39)
and method19 (v0 : UH2, v1 : US1) : UH2 =
    let v2 : UH2 = method20(v0)
    let v3 : UH2 = method27(v2, v1)
    method20(v3)
and method30 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : UH5 = method30(v3, v1)
        UH5_1(v2, v4)
    | UH5_0 -> (* InputListNil *)
        v1
and method31 (v0 : UH2, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = method29(v0, v3)
        let v6 : UH5 = method31(v0, v4)
        method30(v5, v6)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and method35 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH3_1(v5, v6) -> (* InputCons *)
            let v19 : US2 =
                match v3 with
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
            let v20 : bool =
                match v19 with
                | US2_2 -> (* SymbolGreater *)
                    false
                | US2_0 -> (* SymbolLess *)
                    false
                | US2_1 -> (* SymbolSame *)
                    true
            if v20 then
                method35(v4, v6)
            else
                false
        | _ ->
            false
    | UH3_0 -> (* InputEmpty *)
        match v1 with
        | UH3_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and method34 (v0 : UH3, v1 : UH5) : bool =
    match v1 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method35(v0, v2)
        if v4 then
            true
        else
            method34(v0, v3)
    | UH5_0 -> (* InputListNil *)
        false
and method33 (v0 : UH5, v1 : UH5, v2 : UH5) : struct (UH5 * UH5) =
    match v0 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method34(v3, v1)
        if v5 then
            method33(v4, v1, v2)
        else
            let v8 : UH5 = UH5_1(v3, v1)
            let v9 : UH5 = UH5_1(v3, v2)
            method33(v4, v8, v9)
    | UH5_0 -> (* InputListNil *)
        struct (v1, v2)
and method32 (v0 : UH2, v1 : UH5, v2 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = method29(v0, v3)
        let struct (v6 : UH5, v7 : UH5) = method33(v5, v2, v4)
        method32(v0, v7, v6)
    | UH5_0 -> (* InputListNil *)
        v2
and method29 (v0 : UH2, v1 : UH3) : UH5 =
    match v0 with
    | UH2_3(v29, v30) -> (* RegexAlt *)
        let v31 : UH5 = method29(v29, v1)
        let v32 : UH5 = method29(v30, v1)
        method30(v31, v32)
    | UH2_4(v34, v35) -> (* RegexCat *)
        let v36 : UH5 = method29(v34, v1)
        method31(v35, v36)
    | UH2_2(v5) -> (* RegexChar *)
        match v1 with
        | UH3_1(v7, v8) -> (* InputCons *)
            let v21 : US2 =
                match v5 with
                | US1_0 -> (* TriA *)
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US2_1
                    | US1_1 -> (* TriB *)
                        US2_0
                    | US1_2 -> (* TriC *)
                        US2_0
                | US1_1 -> (* TriB *)
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US2_2
                    | US1_1 -> (* TriB *)
                        US2_1
                    | US1_2 -> (* TriC *)
                        US2_0
                | US1_2 -> (* TriC *)
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US2_2
                    | US1_1 -> (* TriB *)
                        US2_2
                    | US1_2 -> (* TriC *)
                        US2_1
            let v22 : bool =
                match v21 with
                | US2_2 -> (* SymbolGreater *)
                    false
                | US2_0 -> (* SymbolLess *)
                    false
                | US2_1 -> (* SymbolSame *)
                    true
            if v22 then
                let v23 : UH5 = UH5_0
                UH5_1(v8, v23)
            else
                UH5_0
        | UH3_0 -> (* InputEmpty *)
            UH5_0
    | UH2_0 -> (* RegexEmpty *)
        UH5_0
    | UH2_1 -> (* RegexEpsilon *)
        let v3 : UH5 = UH5_0
        UH5_1(v1, v3)
    | UH2_5(v38) -> (* RegexStar *)
        let v39 : UH5 = UH5_0
        let v40 : UH5 = UH5_1(v1, v39)
        let v41 : UH5 = UH5_0
        let v42 : UH5 = UH5_1(v1, v41)
        method32(v38, v40, v42)
and method36 (v0 : UH3, v1 : UH5) : UH5 =
    match v1 with
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method35(v0, v3)
        if v5 then
            method36(v0, v4)
        else
            let v7 : UH5 = method36(v0, v4)
            UH5_1(v3, v7)
    | UH5_0 -> (* InputListNil *)
        UH5_0
and method37 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method34(v2, v1)
        if v4 then
            method37(v3, v1)
        else
            false
    | UH5_0 -> (* InputListNil *)
        true
let v0 : US0 = US0_0
let v1 : UH0 = UH0_2(v0)
let v2 : US0 = US0_1
let v3 : UH0 = UH0_2(v2)
let v4 : UH0 = UH0_3(v1, v3)
let v5 : UH0 = UH0_5(v4)
let v6 : US0 = US0_0
let v7 : UH0 = UH0_2(v6)
let v8 : UH0 = UH0_4(v5, v7)
let v9 : US0 = US0_0
let v10 : US0 = US0_1
let v11 : US0 = US0_1
let v12 : US0 = US0_0
let v13 : UH1 = UH1_0
let v14 : UH1 = UH1_1(v12, v13)
let v15 : UH1 = UH1_1(v11, v14)
let v16 : UH1 = UH1_1(v10, v15)
let v17 : US1 = US1_0
let v18 : UH2 = UH2_2(v17)
let v19 : US1 = US1_1
let v20 : UH2 = UH2_2(v19)
let v21 : UH2 = UH2_3(v18, v20)
let v22 : UH2 = UH2_5(v21)
let v23 : US1 = US1_2
let v24 : UH2 = UH2_2(v23)
let v25 : UH2 = UH2_4(v22, v24)
let v26 : US1 = US1_0
let v27 : US1 = US1_1
let v28 : US1 = US1_2
let v29 : UH3 = UH3_0
let v30 : UH3 = UH3_1(v28, v29)
let v31 : UH3 = UH3_1(v27, v30)
let v32 : UH0 = method0(v8, v9)
let v33 : UH1 = UH1_1(v9, v16)
let v34 : UH1 = UH1_1(v9, v16)
let v35 : UH4 = method10(v8, v34)
let v36 : UH4 = method17(v33, v35)
let v37 : UH4 = method10(v32, v16)
let v38 : bool = method18(v36, v37)
let v40 : bool =
    if v38 then
        method18(v37, v36)
    else
        false
let v41 : UH2 = method19(v25, v26)
let v42 : UH3 = UH3_1(v26, v31)
let v43 : UH3 = UH3_1(v26, v31)
let v44 : UH5 = method29(v25, v43)
let v45 : UH5 = method36(v42, v44)
let v46 : UH5 = method29(v41, v31)
let v47 : bool = method37(v45, v46)
let v49 : bool =
    if v47 then
        method37(v46, v45)
    else
        false
let v50 : bool = v40 && v49
v50
