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
    | UH1_1 of UH1
and [<Struct>] US2 =
    | US2_0 of f0_0 : UH0 * f0_1 : UH1
    | US2_1
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US0
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and UH3 =
    | UH3_0
    | UH3_1 of UH3
and UH4 =
    | UH4_0
    | UH4_1 of UH2 * UH4
and [<Struct>] US3 =
    | US3_0 of f0_0 : UH4
    | US3_1 of f1_0 : UH4
and [<Struct>] US4 =
    | US4_0
    | US4_1
and [<Struct>] US5 =
    | US5_0 of f0_0 : UH2
    | US5_1
and UH5 =
    | UH5_0
    | UH5_1 of UH2 * UH2 * UH5
and UH7 =
    | UH7_0
    | UH7_1 of US0 * UH7
and UH6 =
    | UH6_0
    | UH6_1 of UH2 * UH2 * UH7 * UH6
and [<Struct>] US6 =
    | US6_0
    | US6_1 of f1_0 : UH7
and UH8 =
    | UH8_0
    | UH8_1 of UH7 * UH8
and [<Struct>] US7 =
    | US7_0
    | US7_1
    | US7_2
and UH9 =
    | UH9_0
    | UH9_1 of US7 * UH9
and [<Struct>] US8 =
    | US8_0 of f0_0 : UH9 * f0_1 : UH1
    | US8_1
and UH10 =
    | UH10_0
    | UH10_1
    | UH10_2 of US7
    | UH10_3 of UH10 * UH10
    | UH10_4 of UH10 * UH10
    | UH10_5 of UH10
and UH11 =
    | UH11_0
    | UH11_1 of UH10 * UH11
and [<Struct>] US9 =
    | US9_0 of f0_0 : UH11
    | US9_1 of f1_0 : UH11
and [<Struct>] US10 =
    | US10_0 of f0_0 : UH10
    | US10_1
and UH12 =
    | UH12_0
    | UH12_1 of UH10 * UH10 * UH12
and UH14 =
    | UH14_0
    | UH14_1 of US7 * UH14
and UH13 =
    | UH13_0
    | UH13_1 of UH10 * UH10 * UH14 * UH13
and [<Struct>] US11 =
    | US11_0
    | US11_1 of f1_0 : UH14
and UH15 =
    | UH15_0
    | UH15_1 of UH14 * UH15
let rec method1 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_0 -> (* SymbolListNil *)
        true
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_0 -> (* BitZero *)
                match v2 with
                | US0_0 -> (* BitZero *)
                    US1_1
                | US0_1 -> (* BitOne *)
                    US1_0
            | US0_1 -> (* BitOne *)
                match v2 with
                | US0_0 -> (* BitZero *)
                    US1_2
                | US0_1 -> (* BitOne *)
                    US1_1
        let v23 : US1 =
            match v2 with
            | US0_0 -> (* BitZero *)
                match v0 with
                | US0_0 -> (* BitZero *)
                    US1_1
                | US0_1 -> (* BitOne *)
                    US1_0
            | US0_1 -> (* BitOne *)
                match v0 with
                | US0_0 -> (* BitZero *)
                    US1_2
                | US0_1 -> (* BitOne *)
                    US1_1
        let v40 : bool =
            match v13 with
            | US1_1 -> (* SymbolSame *)
                match v23 with
                | US1_1 -> (* SymbolSame *)
                    let v33 : US1 =
                        match v0 with
                        | US0_0 -> (* BitZero *)
                            match v2 with
                            | US0_0 -> (* BitZero *)
                                US1_1
                            | US0_1 -> (* BitOne *)
                                US1_0
                        | US0_1 -> (* BitOne *)
                            match v2 with
                            | US0_0 -> (* BitZero *)
                                US1_2
                            | US0_1 -> (* BitOne *)
                                US1_1
                    match v33 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                | _ ->
                    false
            | US1_0 -> (* SymbolLess *)
                match v23 with
                | US1_2 -> (* SymbolGreater *)
                    true
                | _ ->
                    false
            | US1_2 -> (* SymbolGreater *)
                match v23 with
                | US1_0 -> (* SymbolLess *)
                    true
                | _ ->
                    false
        if v40 then
            method1(v0, v3)
        else
            false
and method0 (v0 : UH0) : bool =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        true
    | UH0_1(v1, v2) -> (* SymbolListCons *)
        let v9 : US1 =
            match v1 with
            | US0_0 -> (* BitZero *)
                US1_1
            | US0_1 -> (* BitOne *)
                US1_1
        match v9 with
        | US1_1 -> (* SymbolSame *)
            let v11 : bool = method1(v1, v2)
            if v11 then
                method0(v2)
            else
                false
        | _ ->
            false
and method3 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_0 -> (* SymbolListNil *)
        true
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_0 -> (* BitZero *)
                match v2 with
                | US0_0 -> (* BitZero *)
                    US1_1
                | US0_1 -> (* BitOne *)
                    US1_0
            | US0_1 -> (* BitOne *)
                match v2 with
                | US0_0 -> (* BitZero *)
                    US1_2
                | US0_1 -> (* BitOne *)
                    US1_1
        match v13 with
        | US1_0 -> (* SymbolLess *)
            method3(v0, v3)
        | _ ->
            false
and method2 (v0 : UH0) : bool =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        true
    | UH0_1(v1, v2) -> (* SymbolListCons *)
        let v3 : bool = method3(v1, v2)
        if v3 then
            method2(v2)
        else
            false
and method4 (v0 : UH0, v1 : UH1) : bool =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        match v1 with
        | UH1_0 -> (* AlphabetCardinalityZero *)
            true
        | _ ->
            false
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH1_1(v5) -> (* AlphabetCardinalitySucc *)
            method4(v4, v5)
        | _ ->
            false
and method5 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        match v1 with
        | UH0_0 -> (* SymbolListNil *)
            true
        | _ ->
            false
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH0_1(v5, v6) -> (* SymbolListCons *)
            let v16 : US1 =
                match v3 with
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
            let v17 : bool =
                match v16 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                method5(v4, v6)
            else
                false
        | _ ->
            false
and method9 (v0 : UH2, v1 : UH2) : US1 =
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
    | UH2_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method9(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method9(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH2_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US1_2
        | UH2_1 -> (* RegexEpsilon *)
            US1_2
        | UH2_2(v32) -> (* RegexChar *)
            US1_2
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method9(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method9(v29, v35)
            | _ ->
                v36
        | _ ->
            US1_0
    | UH2_5(v44) -> (* RegexStar *)
        match v1 with
        | UH2_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH2_5(v48) -> (* RegexStar *)
            method9(v44, v48)
        | _ ->
            US1_2
and method8 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_0 -> (* RegexEmpty *)
        v0
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method9(v0, v2)
        match v4 with
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH2 = method8(v0, v3)
            UH2_3(v2, v6)
    | _ ->
        let v11 : US1 = method9(v0, v1)
        match v11 with
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US1_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
and method7 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        v1
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method8(v2, v1)
        method7(v3, v4)
    | _ ->
        method8(v0, v1)
and method11 (v0 : UH2, v1 : UH2) : bool =
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
    | UH2_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method11(v18, v20)
            if v22 then
                method11(v19, v21)
            else
                false
        | _ ->
            false
    | UH2_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH2_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method11(v26, v28)
            if v30 then
                method11(v27, v29)
            else
                false
        | _ ->
            false
    | UH2_5(v34) -> (* RegexStar *)
        match v1 with
        | UH2_5(v35) -> (* RegexStar *)
            method11(v34, v35)
        | _ ->
            false
and method10 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method10(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method11(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method12 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method6 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method6(v5)
        let v8 : UH2 = method6(v6)
        method7(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method6(v10)
        let v13 : UH2 = method6(v11)
        method10(v12, v13)
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method6(v15)
        method12(v16)
and method14 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* StateBudgetZero *)
        v1
    | UH3_1(v2) -> (* StateBudgetSucc *)
        let v3 : UH3 = method14(v2, v1)
        UH3_1(v3)
and method13 (v0 : UH2) : UH3 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH3_0
    | UH2_1 -> (* RegexEpsilon *)
        UH3_0
    | UH2_2(v3) -> (* RegexChar *)
        let v4 : UH3 = UH3_0
        UH3_1(v4)
    | UH2_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH3 = method13(v6)
        let v9 : UH3 = method13(v7)
        method14(v8, v9)
    | UH2_4(v11, v12) -> (* RegexCat *)
        let v13 : UH3 = method13(v11)
        let v14 : UH3 = method13(v12)
        method14(v13, v14)
    | UH2_5(v16) -> (* RegexStar *)
        method13(v16)
and method16 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* StateBudgetZero *)
        v0
    | UH3_1(v1) -> (* StateBudgetSucc *)
        let v2 : UH3 = method14(v1, v0)
        UH3_1(v2)
and method15 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* StateBudgetZero *)
        let v1 : UH3 = UH3_0
        UH3_1(v1)
    | UH3_1(v3) -> (* StateBudgetSucc *)
        let v4 : UH3 = method15(v3)
        method16(v4)
and method21 (v0 : UH2) : US4 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        US4_1
    | UH2_1 -> (* RegexEpsilon *)
        US4_0
    | UH2_2(v3) -> (* RegexChar *)
        US4_1
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US4 = method21(v5)
        let v8 : US4 = method21(v6)
        match v7 with
        | US4_0 -> (* Nullable *)
            US4_0
        | _ ->
            match v8 with
            | US4_0 -> (* Nullable *)
                US4_0
            | _ ->
                match v7 with
                | US4_1 -> (* NonNullable *)
                    match v8 with
                    | US4_1 -> (* NonNullable *)
                        US4_1
    | UH2_4(v16, v17) -> (* RegexCat *)
        let v18 : US4 = method21(v16)
        let v19 : US4 = method21(v17)
        match v18 with
        | US4_0 -> (* Nullable *)
            match v19 with
            | US4_0 -> (* Nullable *)
                US4_0
            | _ ->
                US4_1
        | _ ->
            US4_1
    | UH2_5(v25) -> (* RegexStar *)
        US4_0
and method20 (v0 : UH2, v1 : US0) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_2(v4) -> (* RegexChar *)
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
            UH2_1
        else
            UH2_0
    | UH2_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH2 = method20(v19, v1)
        let v22 : UH2 = method20(v20, v1)
        method7(v21, v22)
    | UH2_4(v24, v25) -> (* RegexCat *)
        let v26 : US4 = method21(v24)
        match v26 with
        | US4_0 -> (* Nullable *)
            let v27 : UH2 = method20(v24, v1)
            let v28 : UH2 = method10(v27, v25)
            let v29 : UH2 = method20(v25, v1)
            method7(v28, v29)
        | US4_1 -> (* NonNullable *)
            let v31 : UH2 = method20(v24, v1)
            method10(v31, v25)
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH2 = method20(v35, v1)
        let v37 : UH2 = method12(v35)
        method10(v36, v37)
and method19 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = method6(v0)
    let v3 : UH2 = method20(v2, v1)
    method6(v3)
and method22 (v0 : UH2, v1 : UH4) : bool =
    match v1 with
    | UH4_0 -> (* RegexListNil *)
        false
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method11(v0, v2)
        if v4 then
            true
        else
            method22(v0, v3)
and method18 (v0 : UH2, v1 : UH0, v2 : UH4, v3 : UH4) : struct (UH4 * UH4) =
    match v1 with
    | UH0_0 -> (* SymbolListNil *)
        struct (v2, v3)
    | UH0_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH2 = method19(v0, v4)
        let v7 : bool = method22(v6, v2)
        if v7 then
            method18(v0, v5, v2, v3)
        else
            let v10 : UH4 = UH4_1(v6, v2)
            let v11 : UH4 = UH4_1(v6, v3)
            method18(v0, v5, v10, v11)
and method17 (v0 : UH0, v1 : UH3, v2 : UH4, v3 : UH4) : US3 =
    match v3 with
    | UH4_0 -> (* RegexListNil *)
        US3_0(v2)
    | UH4_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH3_0 -> (* StateBudgetZero *)
            US3_1(v2)
        | UH3_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH4, v10 : UH4) = method18(v5, v0, v2, v6)
            method17(v0, v8, v9, v10)
and method26 (v0 : UH2, v1 : UH2, v2 : UH5) : bool =
    match v2 with
    | UH5_0 -> (* DfaStatePairNil *)
        false
    | UH5_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method11(v1, v3)
        let v11 : bool =
            if v6 then
                method11(v0, v4)
            else
                let v8 : bool = method11(v1, v4)
                if v8 then
                    method11(v0, v3)
                else
                    false
        if v11 then
            true
        else
            method26(v0, v1, v5)
and method27 (v0 : UH2, v1 : UH2, v2 : UH0, v3 : UH5) : UH5 =
    match v2 with
    | UH0_0 -> (* SymbolListNil *)
        v3
    | UH0_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH2 = method19(v0, v4)
        let v7 : UH2 = method19(v1, v4)
        let v8 : UH5 = UH5_1(v6, v7, v3)
        method27(v0, v1, v5, v8)
and method25 (v0 : UH0, v1 : UH5, v2 : UH5) : bool =
    match v1 with
    | UH5_0 -> (* DfaStatePairNil *)
        true
    | UH5_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method11(v3, v4)
        if v6 then
            method25(v0, v5, v2)
        else
            let v8 : bool = method26(v4, v3, v2)
            if v8 then
                method25(v0, v5, v2)
            else
                let v10 : US4 = method21(v3)
                let v11 : US4 = method21(v4)
                let v15 : bool =
                    match v10 with
                    | US4_0 -> (* Nullable *)
                        match v11 with
                        | US4_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                    | US4_1 -> (* NonNullable *)
                        match v11 with
                        | US4_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH5 = method27(v3, v4, v0, v5)
                    let v17 : UH5 = UH5_1(v3, v4, v2)
                    method25(v0, v16, v17)
                else
                    false
and method24 (v0 : UH2, v1 : UH4, v2 : UH0) : US5 =
    match v1 with
    | UH4_0 -> (* RegexListNil *)
        US5_1
    | UH4_1(v4, v5) -> (* RegexListCons *)
        let v6 : UH2 = method6(v0)
        let v7 : UH2 = method6(v4)
        let v8 : UH5 = UH5_0
        let v9 : UH5 = UH5_1(v6, v7, v8)
        let v10 : UH5 = UH5_0
        let v11 : bool = method25(v2, v9, v10)
        if v11 then
            US5_0(v4)
        else
            method24(v0, v5, v2)
and method23 (v0 : UH4, v1 : UH0, v2 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        v2
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : US5 = method24(v3, v2, v1)
        match v5 with
        | US5_0(v6) -> (* DfaRepresentativeFound *)
            method23(v4, v1, v2)
        | US5_1 -> (* DfaRepresentativeMissing *)
            let v8 : UH4 = UH4_1(v3, v2)
            method23(v4, v1, v8)
and method32 (v0 : UH7, v1 : US0) : UH7 =
    match v0 with
    | UH7_0 -> (* InputEmpty *)
        let v2 : UH7 = UH7_0
        UH7_1(v1, v2)
    | UH7_1(v4, v5) -> (* InputCons *)
        let v6 : UH7 = method32(v5, v1)
        UH7_1(v4, v6)
and method31 (v0 : UH2, v1 : UH2, v2 : UH7, v3 : UH0, v4 : UH6) : UH6 =
    match v3 with
    | UH0_0 -> (* SymbolListNil *)
        v4
    | UH0_1(v5, v6) -> (* SymbolListCons *)
        let v7 : UH2 = method19(v0, v5)
        let v8 : UH2 = method19(v1, v5)
        let v9 : UH7 = method32(v2, v5)
        let v10 : UH6 = UH6_1(v7, v8, v9, v4)
        method31(v0, v1, v2, v6, v10)
and method30 (v0 : UH0, v1 : UH6, v2 : UH5) : US6 =
    match v1 with
    | UH6_0 -> (* DfaConstructivePairTraceNil *)
        US6_0
    | UH6_1(v4, v5, v6, v7) -> (* DfaConstructivePairTraceCons *)
        let v8 : bool = method11(v4, v5)
        if v8 then
            method30(v0, v7, v2)
        else
            let v10 : bool = method26(v5, v4, v2)
            if v10 then
                method30(v0, v7, v2)
            else
                let v12 : US4 = method21(v4)
                let v13 : US4 = method21(v5)
                let v17 : bool =
                    match v12 with
                    | US4_0 -> (* Nullable *)
                        match v13 with
                        | US4_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                    | US4_1 -> (* NonNullable *)
                        match v13 with
                        | US4_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                if v17 then
                    let v18 : UH6 = method31(v4, v5, v6, v0, v7)
                    let v19 : UH5 = UH5_1(v4, v5, v2)
                    method30(v0, v18, v19)
                else
                    US6_1(v6)
and method34 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* InputListNil *)
        v1
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : UH8 = method34(v3, v1)
        UH8_1(v2, v4)
and method35 (v0 : UH2, v1 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        UH8_0
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = method33(v0, v3)
        let v6 : UH8 = method35(v0, v4)
        method34(v5, v6)
and method39 (v0 : UH7, v1 : UH7) : bool =
    match v0 with
    | UH7_0 -> (* InputEmpty *)
        match v1 with
        | UH7_0 -> (* InputEmpty *)
            true
        | _ ->
            false
    | UH7_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH7_1(v5, v6) -> (* InputCons *)
            let v16 : US1 =
                match v3 with
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
            let v17 : bool =
                match v16 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                method39(v4, v6)
            else
                false
        | _ ->
            false
and method38 (v0 : UH7, v1 : UH8) : bool =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        false
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method39(v0, v2)
        if v4 then
            true
        else
            method38(v0, v3)
and method37 (v0 : UH8, v1 : UH8, v2 : UH8) : struct (UH8 * UH8) =
    match v0 with
    | UH8_0 -> (* InputListNil *)
        struct (v1, v2)
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method38(v3, v1)
        if v5 then
            method37(v4, v1, v2)
        else
            let v8 : UH8 = UH8_1(v3, v1)
            let v9 : UH8 = UH8_1(v3, v2)
            method37(v4, v8, v9)
and method36 (v0 : UH2, v1 : UH8, v2 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        v2
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = method33(v0, v3)
        let struct (v6 : UH8, v7 : UH8) = method37(v5, v2, v4)
        method36(v0, v7, v6)
and method33 (v0 : UH2, v1 : UH7) : UH8 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH8_0
    | UH2_1 -> (* RegexEpsilon *)
        let v3 : UH8 = UH8_0
        UH8_1(v1, v3)
    | UH2_2(v5) -> (* RegexChar *)
        match v1 with
        | UH7_0 -> (* InputEmpty *)
            UH8_0
        | UH7_1(v7, v8) -> (* InputCons *)
            let v18 : US1 =
                match v5 with
                | US0_0 -> (* BitZero *)
                    match v7 with
                    | US0_0 -> (* BitZero *)
                        US1_1
                    | US0_1 -> (* BitOne *)
                        US1_0
                | US0_1 -> (* BitOne *)
                    match v7 with
                    | US0_0 -> (* BitZero *)
                        US1_2
                    | US0_1 -> (* BitOne *)
                        US1_1
            let v19 : bool =
                match v18 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH8 = UH8_0
                UH8_1(v8, v20)
            else
                UH8_0
    | UH2_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH8 = method33(v26, v1)
        let v29 : UH8 = method33(v27, v1)
        method34(v28, v29)
    | UH2_4(v31, v32) -> (* RegexCat *)
        let v33 : UH8 = method33(v31, v1)
        method35(v32, v33)
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH8 = UH8_0
        let v37 : UH8 = UH8_1(v1, v36)
        let v38 : UH8 = UH8_0
        let v39 : UH8 = UH8_1(v1, v38)
        method36(v35, v37, v39)
and method29 (v0 : UH2, v1 : UH4, v2 : UH0) : bool =
    match v1 with
    | UH4_0 -> (* RegexListNil *)
        true
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH2 = method6(v0)
        let v6 : UH2 = method6(v3)
        let v7 : UH6 = UH6_0
        let v8 : UH7 = UH7_0
        let v9 : UH6 = UH6_1(v5, v6, v8, v7)
        let v10 : UH5 = UH5_0
        let v11 : US6 = method30(v2, v9, v10)
        match v11 with
        | US6_0 -> (* DfaConstructiveEquivalent *)
            false
        | US6_1(v12) -> (* DfaConstructiveDistinguished *)
            let v13 : UH2 = method6(v0)
            let v14 : UH7 = UH7_0
            let v15 : UH8 = method33(v13, v12)
            let v16 : bool = method38(v14, v15)
            let v17 : UH2 = method6(v3)
            let v18 : UH7 = UH7_0
            let v19 : UH8 = method33(v17, v12)
            let v20 : bool = method38(v18, v19)
            let v22 : bool =
                if v16 then
                    v20
                else
                    let v21 : bool = false = v20
                    v21
            let v23 : bool = v22 = false
            if v23 then
                method29(v0, v4, v2)
            else
                false
and method28 (v0 : UH4, v1 : UH0) : bool =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        true
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method29(v2, v3, v1)
        if v4 then
            method28(v3, v1)
        else
            false
and method41 (v0 : US7, v1 : UH9) : bool =
    match v1 with
    | UH9_0 -> (* SymbolListNil *)
        true
    | UH9_1(v2, v3) -> (* SymbolListCons *)
        let v19 : US1 =
            match v0 with
            | US7_0 -> (* TriA *)
                match v2 with
                | US7_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v2 with
                | US7_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v0 with
                    | US7_1 -> (* TriB *)
                        match v2 with
                        | US7_1 -> (* TriB *)
                            US1_1
                        | US7_2 -> (* TriC *)
                            US1_0
                    | US7_2 -> (* TriC *)
                        match v2 with
                        | US7_1 -> (* TriB *)
                            US1_2
                        | US7_2 -> (* TriC *)
                            US1_1
        let v35 : US1 =
            match v2 with
            | US7_0 -> (* TriA *)
                match v0 with
                | US7_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v0 with
                | US7_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v2 with
                    | US7_1 -> (* TriB *)
                        match v0 with
                        | US7_1 -> (* TriB *)
                            US1_1
                        | US7_2 -> (* TriC *)
                            US1_0
                    | US7_2 -> (* TriC *)
                        match v0 with
                        | US7_1 -> (* TriB *)
                            US1_2
                        | US7_2 -> (* TriC *)
                            US1_1
        let v58 : bool =
            match v19 with
            | US1_1 -> (* SymbolSame *)
                match v35 with
                | US1_1 -> (* SymbolSame *)
                    let v51 : US1 =
                        match v0 with
                        | US7_0 -> (* TriA *)
                            match v2 with
                            | US7_0 -> (* TriA *)
                                US1_1
                            | _ ->
                                US1_0
                        | _ ->
                            match v2 with
                            | US7_0 -> (* TriA *)
                                US1_2
                            | _ ->
                                match v0 with
                                | US7_1 -> (* TriB *)
                                    match v2 with
                                    | US7_1 -> (* TriB *)
                                        US1_1
                                    | US7_2 -> (* TriC *)
                                        US1_0
                                | US7_2 -> (* TriC *)
                                    match v2 with
                                    | US7_1 -> (* TriB *)
                                        US1_2
                                    | US7_2 -> (* TriC *)
                                        US1_1
                    match v51 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                | _ ->
                    false
            | US1_0 -> (* SymbolLess *)
                match v35 with
                | US1_2 -> (* SymbolGreater *)
                    true
                | _ ->
                    false
            | US1_2 -> (* SymbolGreater *)
                match v35 with
                | US1_0 -> (* SymbolLess *)
                    true
                | _ ->
                    false
        if v58 then
            method41(v0, v3)
        else
            false
and method40 (v0 : UH9) : bool =
    match v0 with
    | UH9_0 -> (* SymbolListNil *)
        true
    | UH9_1(v1, v2) -> (* SymbolListCons *)
        let v8 : US1 =
            match v1 with
            | US7_0 -> (* TriA *)
                US1_1
            | US7_1 -> (* TriB *)
                US1_1
            | US7_2 -> (* TriC *)
                US1_1
        match v8 with
        | US1_1 -> (* SymbolSame *)
            let v9 : bool = method41(v1, v2)
            if v9 then
                method40(v2)
            else
                false
        | _ ->
            false
and method43 (v0 : US7, v1 : UH9) : bool =
    match v1 with
    | UH9_0 -> (* SymbolListNil *)
        true
    | UH9_1(v2, v3) -> (* SymbolListCons *)
        let v19 : US1 =
            match v0 with
            | US7_0 -> (* TriA *)
                match v2 with
                | US7_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v2 with
                | US7_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v0 with
                    | US7_1 -> (* TriB *)
                        match v2 with
                        | US7_1 -> (* TriB *)
                            US1_1
                        | US7_2 -> (* TriC *)
                            US1_0
                    | US7_2 -> (* TriC *)
                        match v2 with
                        | US7_1 -> (* TriB *)
                            US1_2
                        | US7_2 -> (* TriC *)
                            US1_1
        match v19 with
        | US1_0 -> (* SymbolLess *)
            method43(v0, v3)
        | _ ->
            false
and method42 (v0 : UH9) : bool =
    match v0 with
    | UH9_0 -> (* SymbolListNil *)
        true
    | UH9_1(v1, v2) -> (* SymbolListCons *)
        let v3 : bool = method43(v1, v2)
        if v3 then
            method42(v2)
        else
            false
and method44 (v0 : UH9, v1 : UH1) : bool =
    match v0 with
    | UH9_0 -> (* SymbolListNil *)
        match v1 with
        | UH1_0 -> (* AlphabetCardinalityZero *)
            true
        | _ ->
            false
    | UH9_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH1_1(v5) -> (* AlphabetCardinalitySucc *)
            method44(v4, v5)
        | _ ->
            false
and method45 (v0 : UH9, v1 : UH9) : bool =
    match v0 with
    | UH9_0 -> (* SymbolListNil *)
        match v1 with
        | UH9_0 -> (* SymbolListNil *)
            true
        | _ ->
            false
    | UH9_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH9_1(v5, v6) -> (* SymbolListCons *)
            let v22 : US1 =
                match v3 with
                | US7_0 -> (* TriA *)
                    match v5 with
                    | US7_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US7_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v3 with
                        | US7_1 -> (* TriB *)
                            match v5 with
                            | US7_1 -> (* TriB *)
                                US1_1
                            | US7_2 -> (* TriC *)
                                US1_0
                        | US7_2 -> (* TriC *)
                            match v5 with
                            | US7_1 -> (* TriB *)
                                US1_2
                            | US7_2 -> (* TriC *)
                                US1_1
            let v23 : bool =
                match v22 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                method45(v4, v6)
            else
                false
        | _ ->
            false
and method49 (v0 : UH10, v1 : UH10) : US1 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        match v1 with
        | UH10_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH10_1 -> (* RegexEpsilon *)
        match v1 with
        | UH10_0 -> (* RegexEmpty *)
            US1_2
        | UH10_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH10_2(v10) -> (* RegexChar *)
        match v1 with
        | UH10_0 -> (* RegexEmpty *)
            US1_2
        | UH10_1 -> (* RegexEpsilon *)
            US1_2
        | UH10_2(v13) -> (* RegexChar *)
            match v10 with
            | US7_0 -> (* TriA *)
                match v13 with
                | US7_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v13 with
                | US7_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v10 with
                    | US7_1 -> (* TriB *)
                        match v13 with
                        | US7_1 -> (* TriB *)
                            US1_1
                        | US7_2 -> (* TriC *)
                            US1_0
                    | US7_2 -> (* TriC *)
                        match v13 with
                        | US7_1 -> (* TriB *)
                            US1_2
                        | US7_2 -> (* TriC *)
                            US1_1
        | _ ->
            US1_0
    | UH10_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH10_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method49(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method49(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH10_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH10_0 -> (* RegexEmpty *)
            US1_2
        | UH10_1 -> (* RegexEpsilon *)
            US1_2
        | UH10_2(v38) -> (* RegexChar *)
            US1_2
        | UH10_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method49(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method49(v35, v41)
            | _ ->
                v42
        | _ ->
            US1_0
    | UH10_5(v50) -> (* RegexStar *)
        match v1 with
        | UH10_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH10_5(v54) -> (* RegexStar *)
            method49(v50, v54)
        | _ ->
            US1_2
and method48 (v0 : UH10, v1 : UH10) : UH10 =
    match v1 with
    | UH10_0 -> (* RegexEmpty *)
        v0
    | UH10_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method49(v0, v2)
        match v4 with
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_0 -> (* SymbolLess *)
            UH10_3(v0, v1)
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH10 = method48(v0, v3)
            UH10_3(v2, v6)
    | _ ->
        let v11 : US1 = method49(v0, v1)
        match v11 with
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_0 -> (* SymbolLess *)
            UH10_3(v0, v1)
        | US1_2 -> (* SymbolGreater *)
            UH10_3(v1, v0)
and method47 (v0 : UH10, v1 : UH10) : UH10 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        v1
    | UH10_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH10 = method48(v2, v1)
        method47(v3, v4)
    | _ ->
        method48(v0, v1)
and method51 (v0 : UH10, v1 : UH10) : bool =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        match v1 with
        | UH10_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH10_1 -> (* RegexEpsilon *)
        match v1 with
        | UH10_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH10_2(v4) -> (* RegexChar *)
        match v1 with
        | UH10_2(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US7_0 -> (* TriA *)
                    match v5 with
                    | US7_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US7_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v4 with
                        | US7_1 -> (* TriB *)
                            match v5 with
                            | US7_1 -> (* TriB *)
                                US1_1
                            | US7_2 -> (* TriC *)
                                US1_0
                        | US7_2 -> (* TriC *)
                            match v5 with
                            | US7_1 -> (* TriB *)
                                US1_2
                            | US7_2 -> (* TriC *)
                                US1_1
            match v21 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH10_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH10_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method51(v24, v26)
            if v28 then
                method51(v25, v27)
            else
                false
        | _ ->
            false
    | UH10_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH10_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method51(v32, v34)
            if v36 then
                method51(v33, v35)
            else
                false
        | _ ->
            false
    | UH10_5(v40) -> (* RegexStar *)
        match v1 with
        | UH10_5(v41) -> (* RegexStar *)
            method51(v40, v41)
        | _ ->
            false
and method50 (v0 : UH10, v1 : UH10) : UH10 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH10_0
    | _ ->
        match v1 with
        | UH10_0 -> (* RegexEmpty *)
            UH10_0
        | _ ->
            match v0 with
            | UH10_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH10_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH10_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH10 = method50(v13, v1)
                        UH10_4(v12, v14)
                    | UH10_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH10_5(v5) -> (* RegexStar *)
                            let v6 : bool = method51(v4, v5)
                            if v6 then
                                UH10_5(v4)
                            else
                                UH10_4(v0, v1)
                        | _ ->
                            UH10_4(v0, v1)
                    | _ ->
                        UH10_4(v0, v1)
and method52 (v0 : UH10) : UH10 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH10_1
    | UH10_1 -> (* RegexEpsilon *)
        UH10_1
    | UH10_5(v3) -> (* RegexStar *)
        UH10_5(v3)
    | _ ->
        UH10_5(v0)
and method46 (v0 : UH10) : UH10 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH10_0
    | UH10_1 -> (* RegexEpsilon *)
        UH10_1
    | UH10_2(v3) -> (* RegexChar *)
        UH10_2(v3)
    | UH10_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH10 = method46(v5)
        let v8 : UH10 = method46(v6)
        method47(v7, v8)
    | UH10_4(v10, v11) -> (* RegexCat *)
        let v12 : UH10 = method46(v10)
        let v13 : UH10 = method46(v11)
        method50(v12, v13)
    | UH10_5(v15) -> (* RegexStar *)
        let v16 : UH10 = method46(v15)
        method52(v16)
and method53 (v0 : UH10) : UH3 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH3_0
    | UH10_1 -> (* RegexEpsilon *)
        UH3_0
    | UH10_2(v3) -> (* RegexChar *)
        let v4 : UH3 = UH3_0
        UH3_1(v4)
    | UH10_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH3 = method53(v6)
        let v9 : UH3 = method53(v7)
        method14(v8, v9)
    | UH10_4(v11, v12) -> (* RegexCat *)
        let v13 : UH3 = method53(v11)
        let v14 : UH3 = method53(v12)
        method14(v13, v14)
    | UH10_5(v16) -> (* RegexStar *)
        method53(v16)
and method58 (v0 : UH10) : US4 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        US4_1
    | UH10_1 -> (* RegexEpsilon *)
        US4_0
    | UH10_2(v3) -> (* RegexChar *)
        US4_1
    | UH10_3(v5, v6) -> (* RegexAlt *)
        let v7 : US4 = method58(v5)
        let v8 : US4 = method58(v6)
        match v7 with
        | US4_0 -> (* Nullable *)
            US4_0
        | _ ->
            match v8 with
            | US4_0 -> (* Nullable *)
                US4_0
            | _ ->
                match v7 with
                | US4_1 -> (* NonNullable *)
                    match v8 with
                    | US4_1 -> (* NonNullable *)
                        US4_1
    | UH10_4(v16, v17) -> (* RegexCat *)
        let v18 : US4 = method58(v16)
        let v19 : US4 = method58(v17)
        match v18 with
        | US4_0 -> (* Nullable *)
            match v19 with
            | US4_0 -> (* Nullable *)
                US4_0
            | _ ->
                US4_1
        | _ ->
            US4_1
    | UH10_5(v25) -> (* RegexStar *)
        US4_0
and method57 (v0 : UH10, v1 : US7) : UH10 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH10_0
    | UH10_1 -> (* RegexEpsilon *)
        UH10_0
    | UH10_2(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US7_0 -> (* TriA *)
                match v1 with
                | US7_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v1 with
                | US7_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v4 with
                    | US7_1 -> (* TriB *)
                        match v1 with
                        | US7_1 -> (* TriB *)
                            US1_1
                        | US7_2 -> (* TriC *)
                            US1_0
                    | US7_2 -> (* TriC *)
                        match v1 with
                        | US7_1 -> (* TriB *)
                            US1_2
                        | US7_2 -> (* TriC *)
                            US1_1
        let v21 : bool =
            match v20 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH10_1
        else
            UH10_0
    | UH10_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH10 = method57(v25, v1)
        let v28 : UH10 = method57(v26, v1)
        method47(v27, v28)
    | UH10_4(v30, v31) -> (* RegexCat *)
        let v32 : US4 = method58(v30)
        match v32 with
        | US4_0 -> (* Nullable *)
            let v33 : UH10 = method57(v30, v1)
            let v34 : UH10 = method50(v33, v31)
            let v35 : UH10 = method57(v31, v1)
            method47(v34, v35)
        | US4_1 -> (* NonNullable *)
            let v37 : UH10 = method57(v30, v1)
            method50(v37, v31)
    | UH10_5(v41) -> (* RegexStar *)
        let v42 : UH10 = method57(v41, v1)
        let v43 : UH10 = method52(v41)
        method50(v42, v43)
and method56 (v0 : UH10, v1 : US7) : UH10 =
    let v2 : UH10 = method46(v0)
    let v3 : UH10 = method57(v2, v1)
    method46(v3)
and method59 (v0 : UH10, v1 : UH11) : bool =
    match v1 with
    | UH11_0 -> (* RegexListNil *)
        false
    | UH11_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method51(v0, v2)
        if v4 then
            true
        else
            method59(v0, v3)
and method55 (v0 : UH10, v1 : UH9, v2 : UH11, v3 : UH11) : struct (UH11 * UH11) =
    match v1 with
    | UH9_0 -> (* SymbolListNil *)
        struct (v2, v3)
    | UH9_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH10 = method56(v0, v4)
        let v7 : bool = method59(v6, v2)
        if v7 then
            method55(v0, v5, v2, v3)
        else
            let v10 : UH11 = UH11_1(v6, v2)
            let v11 : UH11 = UH11_1(v6, v3)
            method55(v0, v5, v10, v11)
and method54 (v0 : UH9, v1 : UH3, v2 : UH11, v3 : UH11) : US9 =
    match v3 with
    | UH11_0 -> (* RegexListNil *)
        US9_0(v2)
    | UH11_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH3_0 -> (* StateBudgetZero *)
            US9_1(v2)
        | UH3_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH11, v10 : UH11) = method55(v5, v0, v2, v6)
            method54(v0, v8, v9, v10)
and method63 (v0 : UH10, v1 : UH10, v2 : UH12) : bool =
    match v2 with
    | UH12_0 -> (* DfaStatePairNil *)
        false
    | UH12_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method51(v1, v3)
        let v11 : bool =
            if v6 then
                method51(v0, v4)
            else
                let v8 : bool = method51(v1, v4)
                if v8 then
                    method51(v0, v3)
                else
                    false
        if v11 then
            true
        else
            method63(v0, v1, v5)
and method64 (v0 : UH10, v1 : UH10, v2 : UH9, v3 : UH12) : UH12 =
    match v2 with
    | UH9_0 -> (* SymbolListNil *)
        v3
    | UH9_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH10 = method56(v0, v4)
        let v7 : UH10 = method56(v1, v4)
        let v8 : UH12 = UH12_1(v6, v7, v3)
        method64(v0, v1, v5, v8)
and method62 (v0 : UH9, v1 : UH12, v2 : UH12) : bool =
    match v1 with
    | UH12_0 -> (* DfaStatePairNil *)
        true
    | UH12_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method51(v3, v4)
        if v6 then
            method62(v0, v5, v2)
        else
            let v8 : bool = method63(v4, v3, v2)
            if v8 then
                method62(v0, v5, v2)
            else
                let v10 : US4 = method58(v3)
                let v11 : US4 = method58(v4)
                let v15 : bool =
                    match v10 with
                    | US4_0 -> (* Nullable *)
                        match v11 with
                        | US4_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                    | US4_1 -> (* NonNullable *)
                        match v11 with
                        | US4_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH12 = method64(v3, v4, v0, v5)
                    let v17 : UH12 = UH12_1(v3, v4, v2)
                    method62(v0, v16, v17)
                else
                    false
and method61 (v0 : UH10, v1 : UH11, v2 : UH9) : US10 =
    match v1 with
    | UH11_0 -> (* RegexListNil *)
        US10_1
    | UH11_1(v4, v5) -> (* RegexListCons *)
        let v6 : UH10 = method46(v0)
        let v7 : UH10 = method46(v4)
        let v8 : UH12 = UH12_0
        let v9 : UH12 = UH12_1(v6, v7, v8)
        let v10 : UH12 = UH12_0
        let v11 : bool = method62(v2, v9, v10)
        if v11 then
            US10_0(v4)
        else
            method61(v0, v5, v2)
and method60 (v0 : UH11, v1 : UH9, v2 : UH11) : UH11 =
    match v0 with
    | UH11_0 -> (* RegexListNil *)
        v2
    | UH11_1(v3, v4) -> (* RegexListCons *)
        let v5 : US10 = method61(v3, v2, v1)
        match v5 with
        | US10_0(v6) -> (* DfaRepresentativeFound *)
            method60(v4, v1, v2)
        | US10_1 -> (* DfaRepresentativeMissing *)
            let v8 : UH11 = UH11_1(v3, v2)
            method60(v4, v1, v8)
and method69 (v0 : UH14, v1 : US7) : UH14 =
    match v0 with
    | UH14_0 -> (* InputEmpty *)
        let v2 : UH14 = UH14_0
        UH14_1(v1, v2)
    | UH14_1(v4, v5) -> (* InputCons *)
        let v6 : UH14 = method69(v5, v1)
        UH14_1(v4, v6)
and method68 (v0 : UH10, v1 : UH10, v2 : UH14, v3 : UH9, v4 : UH13) : UH13 =
    match v3 with
    | UH9_0 -> (* SymbolListNil *)
        v4
    | UH9_1(v5, v6) -> (* SymbolListCons *)
        let v7 : UH10 = method56(v0, v5)
        let v8 : UH10 = method56(v1, v5)
        let v9 : UH14 = method69(v2, v5)
        let v10 : UH13 = UH13_1(v7, v8, v9, v4)
        method68(v0, v1, v2, v6, v10)
and method67 (v0 : UH9, v1 : UH13, v2 : UH12) : US11 =
    match v1 with
    | UH13_0 -> (* DfaConstructivePairTraceNil *)
        US11_0
    | UH13_1(v4, v5, v6, v7) -> (* DfaConstructivePairTraceCons *)
        let v8 : bool = method51(v4, v5)
        if v8 then
            method67(v0, v7, v2)
        else
            let v10 : bool = method63(v5, v4, v2)
            if v10 then
                method67(v0, v7, v2)
            else
                let v12 : US4 = method58(v4)
                let v13 : US4 = method58(v5)
                let v17 : bool =
                    match v12 with
                    | US4_0 -> (* Nullable *)
                        match v13 with
                        | US4_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                    | US4_1 -> (* NonNullable *)
                        match v13 with
                        | US4_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                if v17 then
                    let v18 : UH13 = method68(v4, v5, v6, v0, v7)
                    let v19 : UH12 = UH12_1(v4, v5, v2)
                    method67(v0, v18, v19)
                else
                    US11_1(v6)
and method71 (v0 : UH15, v1 : UH15) : UH15 =
    match v0 with
    | UH15_0 -> (* InputListNil *)
        v1
    | UH15_1(v2, v3) -> (* InputListCons *)
        let v4 : UH15 = method71(v3, v1)
        UH15_1(v2, v4)
and method72 (v0 : UH10, v1 : UH15) : UH15 =
    match v1 with
    | UH15_0 -> (* InputListNil *)
        UH15_0
    | UH15_1(v3, v4) -> (* InputListCons *)
        let v5 : UH15 = method70(v0, v3)
        let v6 : UH15 = method72(v0, v4)
        method71(v5, v6)
and method76 (v0 : UH14, v1 : UH14) : bool =
    match v0 with
    | UH14_0 -> (* InputEmpty *)
        match v1 with
        | UH14_0 -> (* InputEmpty *)
            true
        | _ ->
            false
    | UH14_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH14_1(v5, v6) -> (* InputCons *)
            let v22 : US1 =
                match v3 with
                | US7_0 -> (* TriA *)
                    match v5 with
                    | US7_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US7_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v3 with
                        | US7_1 -> (* TriB *)
                            match v5 with
                            | US7_1 -> (* TriB *)
                                US1_1
                            | US7_2 -> (* TriC *)
                                US1_0
                        | US7_2 -> (* TriC *)
                            match v5 with
                            | US7_1 -> (* TriB *)
                                US1_2
                            | US7_2 -> (* TriC *)
                                US1_1
            let v23 : bool =
                match v22 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                method76(v4, v6)
            else
                false
        | _ ->
            false
and method75 (v0 : UH14, v1 : UH15) : bool =
    match v1 with
    | UH15_0 -> (* InputListNil *)
        false
    | UH15_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method76(v0, v2)
        if v4 then
            true
        else
            method75(v0, v3)
and method74 (v0 : UH15, v1 : UH15, v2 : UH15) : struct (UH15 * UH15) =
    match v0 with
    | UH15_0 -> (* InputListNil *)
        struct (v1, v2)
    | UH15_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method75(v3, v1)
        if v5 then
            method74(v4, v1, v2)
        else
            let v8 : UH15 = UH15_1(v3, v1)
            let v9 : UH15 = UH15_1(v3, v2)
            method74(v4, v8, v9)
and method73 (v0 : UH10, v1 : UH15, v2 : UH15) : UH15 =
    match v1 with
    | UH15_0 -> (* InputListNil *)
        v2
    | UH15_1(v3, v4) -> (* InputListCons *)
        let v5 : UH15 = method70(v0, v3)
        let struct (v6 : UH15, v7 : UH15) = method74(v5, v2, v4)
        method73(v0, v7, v6)
and method70 (v0 : UH10, v1 : UH14) : UH15 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH15_0
    | UH10_1 -> (* RegexEpsilon *)
        let v3 : UH15 = UH15_0
        UH15_1(v1, v3)
    | UH10_2(v5) -> (* RegexChar *)
        match v1 with
        | UH14_0 -> (* InputEmpty *)
            UH15_0
        | UH14_1(v7, v8) -> (* InputCons *)
            let v24 : US1 =
                match v5 with
                | US7_0 -> (* TriA *)
                    match v7 with
                    | US7_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v7 with
                    | US7_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v5 with
                        | US7_1 -> (* TriB *)
                            match v7 with
                            | US7_1 -> (* TriB *)
                                US1_1
                            | US7_2 -> (* TriC *)
                                US1_0
                        | US7_2 -> (* TriC *)
                            match v7 with
                            | US7_1 -> (* TriB *)
                                US1_2
                            | US7_2 -> (* TriC *)
                                US1_1
            let v25 : bool =
                match v24 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH15 = UH15_0
                UH15_1(v8, v26)
            else
                UH15_0
    | UH10_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH15 = method70(v32, v1)
        let v35 : UH15 = method70(v33, v1)
        method71(v34, v35)
    | UH10_4(v37, v38) -> (* RegexCat *)
        let v39 : UH15 = method70(v37, v1)
        method72(v38, v39)
    | UH10_5(v41) -> (* RegexStar *)
        let v42 : UH15 = UH15_0
        let v43 : UH15 = UH15_1(v1, v42)
        let v44 : UH15 = UH15_0
        let v45 : UH15 = UH15_1(v1, v44)
        method73(v41, v43, v45)
and method66 (v0 : UH10, v1 : UH11, v2 : UH9) : bool =
    match v1 with
    | UH11_0 -> (* RegexListNil *)
        true
    | UH11_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH10 = method46(v0)
        let v6 : UH10 = method46(v3)
        let v7 : UH13 = UH13_0
        let v8 : UH14 = UH14_0
        let v9 : UH13 = UH13_1(v5, v6, v8, v7)
        let v10 : UH12 = UH12_0
        let v11 : US11 = method67(v2, v9, v10)
        match v11 with
        | US11_0 -> (* DfaConstructiveEquivalent *)
            false
        | US11_1(v12) -> (* DfaConstructiveDistinguished *)
            let v13 : UH10 = method46(v0)
            let v14 : UH14 = UH14_0
            let v15 : UH15 = method70(v13, v12)
            let v16 : bool = method75(v14, v15)
            let v17 : UH10 = method46(v3)
            let v18 : UH14 = UH14_0
            let v19 : UH15 = method70(v17, v12)
            let v20 : bool = method75(v18, v19)
            let v22 : bool =
                if v16 then
                    v20
                else
                    let v21 : bool = false = v20
                    v21
            let v23 : bool = v22 = false
            if v23 then
                method66(v0, v4, v2)
            else
                false
and method65 (v0 : UH11, v1 : UH9) : bool =
    match v0 with
    | UH11_0 -> (* RegexListNil *)
        true
    | UH11_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method66(v2, v3, v1)
        if v4 then
            method65(v3, v1)
        else
            false
and method77 (v0 : UH4, v1 : UH3) : bool =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        match v1 with
        | UH3_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
    | UH4_1(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH3_1(v5) -> (* StateBudgetSucc *)
            method77(v4, v5)
        | _ ->
            false
and method78 (v0 : UH11, v1 : UH3) : bool =
    match v0 with
    | UH11_0 -> (* RegexListNil *)
        match v1 with
        | UH3_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
    | UH11_1(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH3_1(v5) -> (* StateBudgetSucc *)
            method78(v4, v5)
        | _ ->
            false
let v0 : UH0 = UH0_0
let v1 : US0 = US0_1
let v2 : UH0 = UH0_1(v1, v0)
let v3 : US0 = US0_0
let v4 : UH0 = UH0_1(v3, v2)
let v5 : bool = method0(v4)
let v12 : bool =
    if v5 then
        let v6 : UH0 = UH0_0
        let v7 : US0 = US0_1
        let v8 : UH0 = UH0_1(v7, v6)
        let v9 : US0 = US0_0
        let v10 : UH0 = UH0_1(v9, v8)
        method2(v10)
    else
        false
let v44 : bool =
    if v12 then
        let v13 : UH0 = UH0_0
        let v14 : US0 = US0_1
        let v15 : UH0 = UH0_1(v14, v13)
        let v16 : US0 = US0_0
        let v17 : UH0 = UH0_1(v16, v15)
        let v18 : UH1 = UH1_0
        let v19 : UH1 = UH1_1(v18)
        let v20 : UH1 = UH1_1(v19)
        let v21 : bool = method4(v17, v20)
        let v31 : bool =
            if v21 then
                let v22 : UH0 = UH0_0
                let v23 : US0 = US0_1
                let v24 : UH0 = UH0_1(v23, v22)
                let v25 : US0 = US0_0
                let v26 : UH0 = UH0_1(v25, v24)
                let v27 : UH1 = UH1_0
                let v28 : UH1 = UH1_1(v27)
                let v29 : UH1 = UH1_1(v28)
                method4(v26, v29)
            else
                false
        if v31 then
            let v32 : UH0 = UH0_0
            let v33 : US0 = US0_1
            let v34 : UH0 = UH0_1(v33, v32)
            let v35 : US0 = US0_0
            let v36 : UH0 = UH0_1(v35, v34)
            let v37 : UH0 = UH0_0
            let v38 : US0 = US0_1
            let v39 : UH0 = UH0_1(v38, v37)
            let v40 : US0 = US0_0
            let v41 : UH0 = UH0_1(v40, v39)
            method5(v36, v41)
        else
            false
    else
        false
let v55 : US2 =
    if v44 then
        let v45 : UH1 = UH1_0
        let v46 : UH1 = UH1_1(v45)
        let v47 : UH1 = UH1_1(v46)
        let v48 : UH0 = UH0_0
        let v49 : US0 = US0_1
        let v50 : UH0 = UH0_1(v49, v48)
        let v51 : US0 = US0_0
        let v52 : UH0 = UH0_1(v51, v50)
        US2_0(v52, v47)
    else
        US2_1
let v86 : bool =
    match v55 with
    | US2_1 -> (* AlphabetInventoryRejected *)
        false
    | US2_0(v56, v57) -> (* AlphabetInventoryCertified *)
        let v58 : US0 = US0_0
        let v59 : UH2 = UH2_2(v58)
        let v60 : US0 = US0_1
        let v61 : UH2 = UH2_2(v60)
        let v62 : US0 = US0_0
        let v63 : UH2 = UH2_2(v62)
        let v64 : UH2 = UH2_3(v63, v61)
        let v65 : UH2 = UH2_5(v64)
        let v66 : UH2 = UH2_4(v65, v59)
        let v67 : UH2 = method6(v66)
        let v68 : UH2 = method6(v67)
        let v69 : UH3 = method13(v68)
        let v70 : UH3 = UH3_1(v69)
        let v71 : UH3 = method15(v70)
        let v72 : UH2 = method6(v68)
        let v73 : UH4 = UH4_0
        let v74 : UH4 = UH4_1(v72, v73)
        let v75 : UH4 = UH4_0
        let v76 : UH4 = UH4_1(v72, v75)
        let v77 : US3 = method17(v56, v71, v74, v76)
        match v77 with
        | US3_1(v78) -> (* DfaClosureBudgetExceeded *)
            false
        | US3_0(v79) -> (* DfaClosureComplete *)
            let v80 : UH4 = UH4_0
            let v81 : UH4 = method23(v79, v56, v80)
            method28(v81, v56)
if v86 then
    ()
else
    let v87 : string = "bit minimized DFA representatives should carry independent distinguishing words"
    failwith v87
    ()
let v88 : UH9 = UH9_0
let v89 : US7 = US7_2
let v90 : UH9 = UH9_1(v89, v88)
let v91 : US7 = US7_1
let v92 : UH9 = UH9_1(v91, v90)
let v93 : US7 = US7_0
let v94 : UH9 = UH9_1(v93, v92)
let v95 : bool = method40(v94)
let v104 : bool =
    if v95 then
        let v96 : UH9 = UH9_0
        let v97 : US7 = US7_2
        let v98 : UH9 = UH9_1(v97, v96)
        let v99 : US7 = US7_1
        let v100 : UH9 = UH9_1(v99, v98)
        let v101 : US7 = US7_0
        let v102 : UH9 = UH9_1(v101, v100)
        method42(v102)
    else
        false
let v146 : bool =
    if v104 then
        let v105 : UH9 = UH9_0
        let v106 : US7 = US7_2
        let v107 : UH9 = UH9_1(v106, v105)
        let v108 : US7 = US7_1
        let v109 : UH9 = UH9_1(v108, v107)
        let v110 : US7 = US7_0
        let v111 : UH9 = UH9_1(v110, v109)
        let v112 : UH1 = UH1_0
        let v113 : UH1 = UH1_1(v112)
        let v114 : UH1 = UH1_1(v113)
        let v115 : UH1 = UH1_1(v114)
        let v116 : bool = method44(v111, v115)
        let v129 : bool =
            if v116 then
                let v117 : UH9 = UH9_0
                let v118 : US7 = US7_2
                let v119 : UH9 = UH9_1(v118, v117)
                let v120 : US7 = US7_1
                let v121 : UH9 = UH9_1(v120, v119)
                let v122 : US7 = US7_0
                let v123 : UH9 = UH9_1(v122, v121)
                let v124 : UH1 = UH1_0
                let v125 : UH1 = UH1_1(v124)
                let v126 : UH1 = UH1_1(v125)
                let v127 : UH1 = UH1_1(v126)
                method44(v123, v127)
            else
                false
        if v129 then
            let v130 : UH9 = UH9_0
            let v131 : US7 = US7_2
            let v132 : UH9 = UH9_1(v131, v130)
            let v133 : US7 = US7_1
            let v134 : UH9 = UH9_1(v133, v132)
            let v135 : US7 = US7_0
            let v136 : UH9 = UH9_1(v135, v134)
            let v137 : UH9 = UH9_0
            let v138 : US7 = US7_2
            let v139 : UH9 = UH9_1(v138, v137)
            let v140 : US7 = US7_1
            let v141 : UH9 = UH9_1(v140, v139)
            let v142 : US7 = US7_0
            let v143 : UH9 = UH9_1(v142, v141)
            method45(v136, v143)
        else
            false
    else
        false
let v160 : US8 =
    if v146 then
        let v147 : UH1 = UH1_0
        let v148 : UH1 = UH1_1(v147)
        let v149 : UH1 = UH1_1(v148)
        let v150 : UH1 = UH1_1(v149)
        let v151 : UH9 = UH9_0
        let v152 : US7 = US7_2
        let v153 : UH9 = UH9_1(v152, v151)
        let v154 : US7 = US7_1
        let v155 : UH9 = UH9_1(v154, v153)
        let v156 : US7 = US7_0
        let v157 : UH9 = UH9_1(v156, v155)
        US8_0(v157, v150)
    else
        US8_1
let v185 : bool =
    match v160 with
    | US8_1 -> (* AlphabetInventoryRejected *)
        false
    | US8_0(v161, v162) -> (* AlphabetInventoryCertified *)
        let v163 : US7 = US7_0
        let v164 : UH10 = UH10_2(v163)
        let v165 : UH10 = UH10_5(v164)
        let v166 : UH10 = method46(v165)
        let v167 : UH10 = method46(v166)
        let v168 : UH3 = method53(v167)
        let v169 : UH3 = UH3_1(v168)
        let v170 : UH3 = method15(v169)
        let v171 : UH10 = method46(v167)
        let v172 : UH11 = UH11_0
        let v173 : UH11 = UH11_1(v171, v172)
        let v174 : UH11 = UH11_0
        let v175 : UH11 = UH11_1(v171, v174)
        let v176 : US9 = method54(v161, v170, v173, v175)
        match v176 with
        | US9_1(v177) -> (* DfaClosureBudgetExceeded *)
            false
        | US9_0(v178) -> (* DfaClosureComplete *)
            let v179 : UH11 = UH11_0
            let v180 : UH11 = method60(v178, v161, v179)
            method65(v180, v161)
if v185 then
    ()
else
    let v186 : string = "ternary star minimized DFA representatives should carry independent distinguishing words"
    failwith v186
    ()
let v187 : UH9 = UH9_0
let v188 : US7 = US7_2
let v189 : UH9 = UH9_1(v188, v187)
let v190 : US7 = US7_1
let v191 : UH9 = UH9_1(v190, v189)
let v192 : US7 = US7_0
let v193 : UH9 = UH9_1(v192, v191)
let v194 : bool = method40(v193)
let v203 : bool =
    if v194 then
        let v195 : UH9 = UH9_0
        let v196 : US7 = US7_2
        let v197 : UH9 = UH9_1(v196, v195)
        let v198 : US7 = US7_1
        let v199 : UH9 = UH9_1(v198, v197)
        let v200 : US7 = US7_0
        let v201 : UH9 = UH9_1(v200, v199)
        method42(v201)
    else
        false
let v245 : bool =
    if v203 then
        let v204 : UH9 = UH9_0
        let v205 : US7 = US7_2
        let v206 : UH9 = UH9_1(v205, v204)
        let v207 : US7 = US7_1
        let v208 : UH9 = UH9_1(v207, v206)
        let v209 : US7 = US7_0
        let v210 : UH9 = UH9_1(v209, v208)
        let v211 : UH1 = UH1_0
        let v212 : UH1 = UH1_1(v211)
        let v213 : UH1 = UH1_1(v212)
        let v214 : UH1 = UH1_1(v213)
        let v215 : bool = method44(v210, v214)
        let v228 : bool =
            if v215 then
                let v216 : UH9 = UH9_0
                let v217 : US7 = US7_2
                let v218 : UH9 = UH9_1(v217, v216)
                let v219 : US7 = US7_1
                let v220 : UH9 = UH9_1(v219, v218)
                let v221 : US7 = US7_0
                let v222 : UH9 = UH9_1(v221, v220)
                let v223 : UH1 = UH1_0
                let v224 : UH1 = UH1_1(v223)
                let v225 : UH1 = UH1_1(v224)
                let v226 : UH1 = UH1_1(v225)
                method44(v222, v226)
            else
                false
        if v228 then
            let v229 : UH9 = UH9_0
            let v230 : US7 = US7_2
            let v231 : UH9 = UH9_1(v230, v229)
            let v232 : US7 = US7_1
            let v233 : UH9 = UH9_1(v232, v231)
            let v234 : US7 = US7_0
            let v235 : UH9 = UH9_1(v234, v233)
            let v236 : UH9 = UH9_0
            let v237 : US7 = US7_2
            let v238 : UH9 = UH9_1(v237, v236)
            let v239 : US7 = US7_1
            let v240 : UH9 = UH9_1(v239, v238)
            let v241 : US7 = US7_0
            let v242 : UH9 = UH9_1(v241, v240)
            method45(v235, v242)
        else
            false
    else
        false
let v259 : US8 =
    if v245 then
        let v246 : UH1 = UH1_0
        let v247 : UH1 = UH1_1(v246)
        let v248 : UH1 = UH1_1(v247)
        let v249 : UH1 = UH1_1(v248)
        let v250 : UH9 = UH9_0
        let v251 : US7 = US7_2
        let v252 : UH9 = UH9_1(v251, v250)
        let v253 : US7 = US7_1
        let v254 : UH9 = UH9_1(v253, v252)
        let v255 : US7 = US7_0
        let v256 : UH9 = UH9_1(v255, v254)
        US8_0(v256, v249)
    else
        US8_1
let v301 : bool =
    match v259 with
    | US8_1 -> (* AlphabetInventoryRejected *)
        false
    | US8_0(v260, v261) -> (* AlphabetInventoryCertified *)
        let v262 : US7 = US7_0
        let v263 : UH10 = UH10_2(v262)
        let v264 : US7 = US7_0
        let v265 : UH10 = UH10_2(v264)
        let v266 : UH10 = UH10_4(v265, v263)
        let v267 : UH10 = UH10_5(v266)
        let v268 : US7 = US7_0
        let v269 : UH10 = UH10_2(v268)
        let v270 : UH10 = UH10_4(v269, v267)
        let v271 : UH10 = UH10_3(v267, v270)
        let v272 : US7 = US7_1
        let v273 : UH10 = UH10_2(v272)
        let v274 : UH10 = UH10_4(v273, v271)
        let v275 : US7 = US7_0
        let v276 : UH10 = UH10_2(v275)
        let v277 : UH10 = UH10_5(v276)
        let v278 : US7 = US7_0
        let v279 : UH10 = UH10_2(v278)
        let v280 : UH10 = UH10_4(v279, v277)
        let v281 : UH10 = UH10_3(v280, v274)
        let v282 : UH10 = method46(v281)
        let v283 : UH10 = method46(v282)
        let v284 : UH3 = method53(v283)
        let v285 : UH3 = UH3_1(v284)
        let v286 : UH3 = method15(v285)
        let v287 : UH10 = method46(v283)
        let v288 : UH11 = UH11_0
        let v289 : UH11 = UH11_1(v287, v288)
        let v290 : UH11 = UH11_0
        let v291 : UH11 = UH11_1(v287, v290)
        let v292 : US9 = method54(v260, v286, v289, v291)
        match v292 with
        | US9_1(v293) -> (* DfaClosureBudgetExceeded *)
            false
        | US9_0(v294) -> (* DfaClosureComplete *)
            let v295 : UH11 = UH11_0
            let v296 : UH11 = method60(v294, v260, v295)
            method65(v296, v260)
if v301 then
    ()
else
    let v302 : string = "cyclic quotient representatives should carry independent distinguishing words"
    failwith v302
    ()
let v303 : UH0 = UH0_0
let v304 : US0 = US0_1
let v305 : UH0 = UH0_1(v304, v303)
let v306 : US0 = US0_0
let v307 : UH0 = UH0_1(v306, v305)
let v308 : bool = method0(v307)
let v315 : bool =
    if v308 then
        let v309 : UH0 = UH0_0
        let v310 : US0 = US0_1
        let v311 : UH0 = UH0_1(v310, v309)
        let v312 : US0 = US0_0
        let v313 : UH0 = UH0_1(v312, v311)
        method2(v313)
    else
        false
let v347 : bool =
    if v315 then
        let v316 : UH0 = UH0_0
        let v317 : US0 = US0_1
        let v318 : UH0 = UH0_1(v317, v316)
        let v319 : US0 = US0_0
        let v320 : UH0 = UH0_1(v319, v318)
        let v321 : UH1 = UH1_0
        let v322 : UH1 = UH1_1(v321)
        let v323 : UH1 = UH1_1(v322)
        let v324 : bool = method4(v320, v323)
        let v334 : bool =
            if v324 then
                let v325 : UH0 = UH0_0
                let v326 : US0 = US0_1
                let v327 : UH0 = UH0_1(v326, v325)
                let v328 : US0 = US0_0
                let v329 : UH0 = UH0_1(v328, v327)
                let v330 : UH1 = UH1_0
                let v331 : UH1 = UH1_1(v330)
                let v332 : UH1 = UH1_1(v331)
                method4(v329, v332)
            else
                false
        if v334 then
            let v335 : UH0 = UH0_0
            let v336 : US0 = US0_1
            let v337 : UH0 = UH0_1(v336, v335)
            let v338 : US0 = US0_0
            let v339 : UH0 = UH0_1(v338, v337)
            let v340 : UH0 = UH0_0
            let v341 : US0 = US0_1
            let v342 : UH0 = UH0_1(v341, v340)
            let v343 : US0 = US0_0
            let v344 : UH0 = UH0_1(v343, v342)
            method5(v339, v344)
        else
            false
    else
        false
let v358 : US2 =
    if v347 then
        let v348 : UH1 = UH1_0
        let v349 : UH1 = UH1_1(v348)
        let v350 : UH1 = UH1_1(v349)
        let v351 : UH0 = UH0_0
        let v352 : US0 = US0_1
        let v353 : UH0 = UH0_1(v352, v351)
        let v354 : US0 = US0_0
        let v355 : UH0 = UH0_1(v354, v353)
        US2_0(v355, v350)
    else
        US2_1
let v392 : bool =
    match v358 with
    | US2_1 -> (* AlphabetInventoryRejected *)
        false
    | US2_0(v359, v360) -> (* AlphabetInventoryCertified *)
        let v361 : US0 = US0_0
        let v362 : UH2 = UH2_2(v361)
        let v363 : US0 = US0_1
        let v364 : UH2 = UH2_2(v363)
        let v365 : US0 = US0_0
        let v366 : UH2 = UH2_2(v365)
        let v367 : UH2 = UH2_3(v366, v364)
        let v368 : UH2 = UH2_5(v367)
        let v369 : UH2 = UH2_4(v368, v362)
        let v370 : UH2 = method6(v369)
        let v371 : UH2 = method6(v370)
        let v372 : UH3 = method13(v371)
        let v373 : UH3 = UH3_1(v372)
        let v374 : UH3 = method15(v373)
        let v375 : UH2 = method6(v371)
        let v376 : UH4 = UH4_0
        let v377 : UH4 = UH4_1(v375, v376)
        let v378 : UH4 = UH4_0
        let v379 : UH4 = UH4_1(v375, v378)
        let v380 : US3 = method17(v359, v374, v377, v379)
        match v380 with
        | US3_1(v381) -> (* DfaClosureBudgetExceeded *)
            false
        | US3_0(v382) -> (* DfaClosureComplete *)
            let v383 : UH4 = UH4_0
            let v384 : UH4 = method23(v382, v359, v383)
            let v385 : UH3 = UH3_0
            let v386 : UH3 = UH3_1(v385)
            let v387 : UH3 = UH3_1(v386)
            method77(v384, v387)
if v392 then
    ()
else
    let v393 : string = "bit minimized DFA should match the independent two-state reference quotient"
    failwith v393
    ()
let v394 : UH9 = UH9_0
let v395 : US7 = US7_2
let v396 : UH9 = UH9_1(v395, v394)
let v397 : US7 = US7_1
let v398 : UH9 = UH9_1(v397, v396)
let v399 : US7 = US7_0
let v400 : UH9 = UH9_1(v399, v398)
let v401 : bool = method40(v400)
let v410 : bool =
    if v401 then
        let v402 : UH9 = UH9_0
        let v403 : US7 = US7_2
        let v404 : UH9 = UH9_1(v403, v402)
        let v405 : US7 = US7_1
        let v406 : UH9 = UH9_1(v405, v404)
        let v407 : US7 = US7_0
        let v408 : UH9 = UH9_1(v407, v406)
        method42(v408)
    else
        false
let v452 : bool =
    if v410 then
        let v411 : UH9 = UH9_0
        let v412 : US7 = US7_2
        let v413 : UH9 = UH9_1(v412, v411)
        let v414 : US7 = US7_1
        let v415 : UH9 = UH9_1(v414, v413)
        let v416 : US7 = US7_0
        let v417 : UH9 = UH9_1(v416, v415)
        let v418 : UH1 = UH1_0
        let v419 : UH1 = UH1_1(v418)
        let v420 : UH1 = UH1_1(v419)
        let v421 : UH1 = UH1_1(v420)
        let v422 : bool = method44(v417, v421)
        let v435 : bool =
            if v422 then
                let v423 : UH9 = UH9_0
                let v424 : US7 = US7_2
                let v425 : UH9 = UH9_1(v424, v423)
                let v426 : US7 = US7_1
                let v427 : UH9 = UH9_1(v426, v425)
                let v428 : US7 = US7_0
                let v429 : UH9 = UH9_1(v428, v427)
                let v430 : UH1 = UH1_0
                let v431 : UH1 = UH1_1(v430)
                let v432 : UH1 = UH1_1(v431)
                let v433 : UH1 = UH1_1(v432)
                method44(v429, v433)
            else
                false
        if v435 then
            let v436 : UH9 = UH9_0
            let v437 : US7 = US7_2
            let v438 : UH9 = UH9_1(v437, v436)
            let v439 : US7 = US7_1
            let v440 : UH9 = UH9_1(v439, v438)
            let v441 : US7 = US7_0
            let v442 : UH9 = UH9_1(v441, v440)
            let v443 : UH9 = UH9_0
            let v444 : US7 = US7_2
            let v445 : UH9 = UH9_1(v444, v443)
            let v446 : US7 = US7_1
            let v447 : UH9 = UH9_1(v446, v445)
            let v448 : US7 = US7_0
            let v449 : UH9 = UH9_1(v448, v447)
            method45(v442, v449)
        else
            false
    else
        false
let v466 : US8 =
    if v452 then
        let v453 : UH1 = UH1_0
        let v454 : UH1 = UH1_1(v453)
        let v455 : UH1 = UH1_1(v454)
        let v456 : UH1 = UH1_1(v455)
        let v457 : UH9 = UH9_0
        let v458 : US7 = US7_2
        let v459 : UH9 = UH9_1(v458, v457)
        let v460 : US7 = US7_1
        let v461 : UH9 = UH9_1(v460, v459)
        let v462 : US7 = US7_0
        let v463 : UH9 = UH9_1(v462, v461)
        US8_0(v463, v456)
    else
        US8_1
let v494 : bool =
    match v466 with
    | US8_1 -> (* AlphabetInventoryRejected *)
        false
    | US8_0(v467, v468) -> (* AlphabetInventoryCertified *)
        let v469 : US7 = US7_0
        let v470 : UH10 = UH10_2(v469)
        let v471 : UH10 = UH10_5(v470)
        let v472 : UH10 = method46(v471)
        let v473 : UH10 = method46(v472)
        let v474 : UH3 = method53(v473)
        let v475 : UH3 = UH3_1(v474)
        let v476 : UH3 = method15(v475)
        let v477 : UH10 = method46(v473)
        let v478 : UH11 = UH11_0
        let v479 : UH11 = UH11_1(v477, v478)
        let v480 : UH11 = UH11_0
        let v481 : UH11 = UH11_1(v477, v480)
        let v482 : US9 = method54(v467, v476, v479, v481)
        match v482 with
        | US9_1(v483) -> (* DfaClosureBudgetExceeded *)
            false
        | US9_0(v484) -> (* DfaClosureComplete *)
            let v485 : UH11 = UH11_0
            let v486 : UH11 = method60(v484, v467, v485)
            let v487 : UH3 = UH3_0
            let v488 : UH3 = UH3_1(v487)
            let v489 : UH3 = UH3_1(v488)
            method78(v486, v489)
if v494 then
    ()
else
    let v495 : string = "ternary star minimized DFA should match the independent two-state reference quotient"
    failwith v495
    ()
let v496 : UH9 = UH9_0
let v497 : US7 = US7_2
let v498 : UH9 = UH9_1(v497, v496)
let v499 : US7 = US7_1
let v500 : UH9 = UH9_1(v499, v498)
let v501 : US7 = US7_0
let v502 : UH9 = UH9_1(v501, v500)
let v503 : bool = method40(v502)
let v512 : bool =
    if v503 then
        let v504 : UH9 = UH9_0
        let v505 : US7 = US7_2
        let v506 : UH9 = UH9_1(v505, v504)
        let v507 : US7 = US7_1
        let v508 : UH9 = UH9_1(v507, v506)
        let v509 : US7 = US7_0
        let v510 : UH9 = UH9_1(v509, v508)
        method42(v510)
    else
        false
let v554 : bool =
    if v512 then
        let v513 : UH9 = UH9_0
        let v514 : US7 = US7_2
        let v515 : UH9 = UH9_1(v514, v513)
        let v516 : US7 = US7_1
        let v517 : UH9 = UH9_1(v516, v515)
        let v518 : US7 = US7_0
        let v519 : UH9 = UH9_1(v518, v517)
        let v520 : UH1 = UH1_0
        let v521 : UH1 = UH1_1(v520)
        let v522 : UH1 = UH1_1(v521)
        let v523 : UH1 = UH1_1(v522)
        let v524 : bool = method44(v519, v523)
        let v537 : bool =
            if v524 then
                let v525 : UH9 = UH9_0
                let v526 : US7 = US7_2
                let v527 : UH9 = UH9_1(v526, v525)
                let v528 : US7 = US7_1
                let v529 : UH9 = UH9_1(v528, v527)
                let v530 : US7 = US7_0
                let v531 : UH9 = UH9_1(v530, v529)
                let v532 : UH1 = UH1_0
                let v533 : UH1 = UH1_1(v532)
                let v534 : UH1 = UH1_1(v533)
                let v535 : UH1 = UH1_1(v534)
                method44(v531, v535)
            else
                false
        if v537 then
            let v538 : UH9 = UH9_0
            let v539 : US7 = US7_2
            let v540 : UH9 = UH9_1(v539, v538)
            let v541 : US7 = US7_1
            let v542 : UH9 = UH9_1(v541, v540)
            let v543 : US7 = US7_0
            let v544 : UH9 = UH9_1(v543, v542)
            let v545 : UH9 = UH9_0
            let v546 : US7 = US7_2
            let v547 : UH9 = UH9_1(v546, v545)
            let v548 : US7 = US7_1
            let v549 : UH9 = UH9_1(v548, v547)
            let v550 : US7 = US7_0
            let v551 : UH9 = UH9_1(v550, v549)
            method45(v544, v551)
        else
            false
    else
        false
let v568 : US8 =
    if v554 then
        let v555 : UH1 = UH1_0
        let v556 : UH1 = UH1_1(v555)
        let v557 : UH1 = UH1_1(v556)
        let v558 : UH1 = UH1_1(v557)
        let v559 : UH9 = UH9_0
        let v560 : US7 = US7_2
        let v561 : UH9 = UH9_1(v560, v559)
        let v562 : US7 = US7_1
        let v563 : UH9 = UH9_1(v562, v561)
        let v564 : US7 = US7_0
        let v565 : UH9 = UH9_1(v564, v563)
        US8_0(v565, v558)
    else
        US8_1
let v614 : bool =
    match v568 with
    | US8_1 -> (* AlphabetInventoryRejected *)
        false
    | US8_0(v569, v570) -> (* AlphabetInventoryCertified *)
        let v571 : US7 = US7_0
        let v572 : UH10 = UH10_2(v571)
        let v573 : US7 = US7_0
        let v574 : UH10 = UH10_2(v573)
        let v575 : UH10 = UH10_4(v574, v572)
        let v576 : UH10 = UH10_5(v575)
        let v577 : US7 = US7_0
        let v578 : UH10 = UH10_2(v577)
        let v579 : UH10 = UH10_4(v578, v576)
        let v580 : UH10 = UH10_3(v576, v579)
        let v581 : US7 = US7_1
        let v582 : UH10 = UH10_2(v581)
        let v583 : UH10 = UH10_4(v582, v580)
        let v584 : US7 = US7_0
        let v585 : UH10 = UH10_2(v584)
        let v586 : UH10 = UH10_5(v585)
        let v587 : US7 = US7_0
        let v588 : UH10 = UH10_2(v587)
        let v589 : UH10 = UH10_4(v588, v586)
        let v590 : UH10 = UH10_3(v589, v583)
        let v591 : UH10 = method46(v590)
        let v592 : UH10 = method46(v591)
        let v593 : UH3 = method53(v592)
        let v594 : UH3 = UH3_1(v593)
        let v595 : UH3 = method15(v594)
        let v596 : UH10 = method46(v592)
        let v597 : UH11 = UH11_0
        let v598 : UH11 = UH11_1(v596, v597)
        let v599 : UH11 = UH11_0
        let v600 : UH11 = UH11_1(v596, v599)
        let v601 : US9 = method54(v569, v595, v598, v600)
        match v601 with
        | US9_1(v602) -> (* DfaClosureBudgetExceeded *)
            false
        | US9_0(v603) -> (* DfaClosureComplete *)
            let v604 : UH11 = UH11_0
            let v605 : UH11 = method60(v603, v569, v604)
            let v606 : UH3 = UH3_0
            let v607 : UH3 = UH3_1(v606)
            let v608 : UH3 = UH3_1(v607)
            let v609 : UH3 = UH3_1(v608)
            method78(v605, v609)
if v614 then
    ()
else
    let v615 : string = "cyclic minimized DFA should match the independent three-state reference quotient"
    failwith v615
    ()
let v616 : UH2 = UH2_1
let v617 : UH2 = method6(v616)
let v618 : UH2 = UH2_0
let v619 : UH2 = method6(v618)
let v620 : UH0 = UH0_0
let v621 : US0 = US0_1
let v622 : UH0 = UH0_1(v621, v620)
let v623 : US0 = US0_0
let v624 : UH0 = UH0_1(v623, v622)
let v625 : UH6 = UH6_0
let v626 : UH7 = UH7_0
let v627 : UH6 = UH6_1(v617, v619, v626, v625)
let v628 : UH5 = UH5_0
let v629 : US6 = method30(v624, v627, v628)
let v658 : bool =
    match v629 with
    | US6_0 -> (* DfaConstructiveEquivalent *)
        let v630 : UH2 = UH2_1
        let v631 : UH2 = method6(v630)
        let v632 : UH2 = UH2_0
        let v633 : UH2 = method6(v632)
        let v634 : UH0 = UH0_0
        let v635 : US0 = US0_1
        let v636 : UH0 = UH0_1(v635, v634)
        let v637 : US0 = US0_0
        let v638 : UH0 = UH0_1(v637, v636)
        let v639 : UH5 = UH5_0
        let v640 : UH5 = UH5_1(v631, v633, v639)
        let v641 : UH5 = UH5_0
        method25(v638, v640, v641)
    | US6_1(v643) -> (* DfaConstructiveDistinguished *)
        let v644 : UH2 = UH2_1
        let v645 : UH2 = method6(v644)
        let v646 : UH7 = UH7_0
        let v647 : UH8 = method33(v645, v643)
        let v648 : bool = method38(v646, v647)
        let v649 : UH2 = UH2_0
        let v650 : UH2 = method6(v649)
        let v651 : UH7 = UH7_0
        let v652 : UH8 = method33(v650, v643)
        let v653 : bool = method38(v651, v652)
        let v655 : bool =
            if v648 then
                v653
            else
                let v654 : bool = false = v653
                v654
        let v656 : bool = v655 = false
        v656
if v658 then
    ()
else
    let v659 : string = "nullable mismatch should produce a language-valid distinguishing word"
    failwith v659
    ()
let v660 : UH2 = UH2_1
let v661 : UH2 = method6(v660)
let v662 : UH7 = UH7_0
let v663 : UH7 = UH7_0
let v664 : US0 = US0_0
let v665 : UH7 = UH7_1(v664, v663)
let v666 : UH8 = method33(v661, v665)
let v667 : bool = method38(v662, v666)
let v668 : UH2 = UH2_0
let v669 : UH2 = method6(v668)
let v670 : UH7 = UH7_0
let v671 : UH7 = UH7_0
let v672 : US0 = US0_0
let v673 : UH7 = UH7_1(v672, v671)
let v674 : UH8 = method33(v669, v673)
let v675 : bool = method38(v670, v674)
let v677 : bool =
    if v667 then
        v675
    else
        let v676 : bool = false = v675
        v676
let v678 : bool = v677 = false
let v679 : bool = v678 = false
if v679 then
    ()
else
    let v680 : string = "independent language semantics must reject a forged non-distinguishing word"
    failwith v680
    ()
let v681 : US0 = US0_0
let v682 : UH2 = UH2_2(v681)
let v683 : US0 = US0_0
let v684 : UH2 = UH2_2(v683)
let v685 : UH2 = UH2_3(v684, v682)
let v686 : UH2 = method6(v685)
let v687 : US0 = US0_0
let v688 : UH2 = UH2_2(v687)
let v689 : UH2 = method6(v688)
let v690 : UH0 = UH0_0
let v691 : US0 = US0_1
let v692 : UH0 = UH0_1(v691, v690)
let v693 : US0 = US0_0
let v694 : UH0 = UH0_1(v693, v692)
let v695 : UH6 = UH6_0
let v696 : UH7 = UH7_0
let v697 : UH6 = UH6_1(v686, v689, v696, v695)
let v698 : UH5 = UH5_0
let v699 : US6 = method30(v694, v697, v698)
let v738 : bool =
    match v699 with
    | US6_0 -> (* DfaConstructiveEquivalent *)
        let v700 : US0 = US0_0
        let v701 : UH2 = UH2_2(v700)
        let v702 : US0 = US0_0
        let v703 : UH2 = UH2_2(v702)
        let v704 : UH2 = UH2_3(v703, v701)
        let v705 : UH2 = method6(v704)
        let v706 : US0 = US0_0
        let v707 : UH2 = UH2_2(v706)
        let v708 : UH2 = method6(v707)
        let v709 : UH0 = UH0_0
        let v710 : US0 = US0_1
        let v711 : UH0 = UH0_1(v710, v709)
        let v712 : US0 = US0_0
        let v713 : UH0 = UH0_1(v712, v711)
        let v714 : UH5 = UH5_0
        let v715 : UH5 = UH5_1(v705, v708, v714)
        let v716 : UH5 = UH5_0
        method25(v713, v715, v716)
    | US6_1(v718) -> (* DfaConstructiveDistinguished *)
        let v719 : US0 = US0_0
        let v720 : UH2 = UH2_2(v719)
        let v721 : US0 = US0_0
        let v722 : UH2 = UH2_2(v721)
        let v723 : UH2 = UH2_3(v722, v720)
        let v724 : UH2 = method6(v723)
        let v725 : UH7 = UH7_0
        let v726 : UH8 = method33(v724, v718)
        let v727 : bool = method38(v725, v726)
        let v728 : US0 = US0_0
        let v729 : UH2 = UH2_2(v728)
        let v730 : UH2 = method6(v729)
        let v731 : UH7 = UH7_0
        let v732 : UH8 = method33(v730, v718)
        let v733 : bool = method38(v731, v732)
        let v735 : bool =
            if v727 then
                v733
            else
                let v734 : bool = false = v733
                v734
        let v736 : bool = v735 = false
        v736
if v738 then
    ()
else
    let v739 : string = "normalized language-equivalent states should remain bisimilar"
    failwith v739
    ()
let v740 : string = "brzozowski-minimization-witness-green"
v740
