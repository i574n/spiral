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
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and UH1 =
    | UH1_0
    | UH1_1 of UH1
and UH2 =
    | UH2_0
    | UH2_1 of US0 * UH2
and UH3 =
    | UH3_0
    | UH3_1 of UH0 * UH3
and [<Struct>] US2 =
    | US2_0 of f0_0 : UH3
    | US2_1 of f1_0 : UH3
and [<Struct>] US3 =
    | US3_0
    | US3_1
and [<Struct>] US4 =
    | US4_0 of f0_0 : UH0
    | US4_1
and UH4 =
    | UH4_0
    | UH4_1 of UH0 * UH0 * UH4
and UH5 =
    | UH5_0
    | UH5_1 of US0 * UH5
and UH6 =
    | UH6_0
    | UH6_1 of UH0 * UH0 * UH5 * UH6
and [<Struct>] US5 =
    | US5_0
    | US5_1 of f1_0 : UH5
and UH7 =
    | UH7_0
    | UH7_1 of UH5 * UH7
and [<Struct>] US6 =
    | US6_0
    | US6_1
    | US6_2
and UH8 =
    | UH8_0
    | UH8_1
    | UH8_2 of US6
    | UH8_3 of UH8 * UH8
    | UH8_4 of UH8 * UH8
    | UH8_5 of UH8
and UH9 =
    | UH9_0
    | UH9_1 of US6 * UH9
and UH10 =
    | UH10_0
    | UH10_1 of UH8 * UH10
and [<Struct>] US7 =
    | US7_0 of f0_0 : UH10
    | US7_1 of f1_0 : UH10
and [<Struct>] US8 =
    | US8_0 of f0_0 : UH8
    | US8_1
and UH11 =
    | UH11_0
    | UH11_1 of UH8 * UH8 * UH11
and UH12 =
    | UH12_0
    | UH12_1 of US6 * UH12
and UH13 =
    | UH13_0
    | UH13_1 of UH8 * UH8 * UH12 * UH13
and [<Struct>] US9 =
    | US9_0
    | US9_1 of f1_0 : UH12
and UH14 =
    | UH14_0
    | UH14_1 of UH12 * UH14
let rec method3 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method3(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method3(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method3(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method3(v29, v35)
            | _ ->
                v36
        | UH0_2(v32) -> (* RegexChar *)
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
    | UH0_5(v44) -> (* RegexStar *)
        match v1 with
        | UH0_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH0_5(v48) -> (* RegexStar *)
            method3(v44, v48)
        | _ ->
            US1_2
and method2 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method3(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH0 = method2(v0, v3)
            UH0_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH0_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method3(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method1 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method2(v2, v1)
        method1(v3, v4)
    | UH0_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method2(v0, v1)
and method5 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method5(v18, v20)
            if v22 then
                method5(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method5(v26, v28)
            if v30 then
                method5(v27, v29)
            else
                false
        | _ ->
            false
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
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
    | UH0_5(v34) -> (* RegexStar *)
        match v1 with
        | UH0_5(v35) -> (* RegexStar *)
            method5(v34, v35)
        | _ ->
            false
and method4 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = method4(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = method5(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and method6 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and method0 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method0(v5)
        let v8 : UH0 = method0(v6)
        method1(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method0(v10)
        let v13 : UH0 = method0(v11)
        method4(v12, v13)
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method0(v15)
        method6(v16)
and method8 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_1(v2) -> (* StateBudgetSucc *)
        let v3 : UH1 = method8(v2, v1)
        UH1_1(v3)
    | UH1_0 -> (* StateBudgetZero *)
        v1
and method7 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH1 = method7(v6)
        let v9 : UH1 = method7(v7)
        method8(v8, v9)
    | UH0_4(v11, v12) -> (* RegexCat *)
        let v13 : UH1 = method7(v11)
        let v14 : UH1 = method7(v12)
        method8(v13, v14)
    | UH0_2(v3) -> (* RegexChar *)
        let v4 : UH1 = UH1_0
        UH1_1(v4)
    | UH0_0 -> (* RegexEmpty *)
        UH1_0
    | UH0_1 -> (* RegexEpsilon *)
        UH1_0
    | UH0_5(v16) -> (* RegexStar *)
        method7(v16)
and method10 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_1(v1) -> (* StateBudgetSucc *)
        let v2 : UH1 = method8(v1, v0)
        UH1_1(v2)
    | UH1_0 -> (* StateBudgetZero *)
        v0
and method9 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_1(v3) -> (* StateBudgetSucc *)
        let v4 : UH1 = method9(v3)
        method10(v4)
    | UH1_0 -> (* StateBudgetZero *)
        let v1 : UH1 = UH1_0
        UH1_1(v1)
and method15 (v0 : UH0) : US3 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method15(v5)
        let v8 : US3 = method15(v6)
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
    | UH0_4(v16, v17) -> (* RegexCat *)
        let v18 : US3 = method15(v16)
        let v19 : US3 = method15(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH0_2(v3) -> (* RegexChar *)
        US3_1
    | UH0_0 -> (* RegexEmpty *)
        US3_1
    | UH0_1 -> (* RegexEpsilon *)
        US3_0
    | UH0_5(v25) -> (* RegexStar *)
        US3_0
and method14 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method14(v19, v1)
        let v22 : UH0 = method14(v20, v1)
        method1(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method15(v24)
        match v26 with
        | US3_1 -> (* NonNullable *)
            let v31 : UH0 = method14(v24, v1)
            method4(v31, v25)
        | US3_0 -> (* Nullable *)
            let v27 : UH0 = method14(v24, v1)
            let v28 : UH0 = method4(v27, v25)
            let v29 : UH0 = method14(v25, v1)
            method1(v28, v29)
    | UH0_2(v4) -> (* RegexChar *)
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
            UH0_1
        else
            UH0_0
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH0 = method14(v35, v1)
        let v37 : UH0 = method6(v35)
        method4(v36, v37)
and method13 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method0(v0)
    let v3 : UH0 = method14(v2, v1)
    method0(v3)
and method16 (v0 : UH0, v1 : UH3) : bool =
    match v1 with
    | UH3_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method5(v0, v2)
        if v4 then
            true
        else
            method16(v0, v3)
    | UH3_0 -> (* RegexListNil *)
        false
and method12 (v0 : UH0, v1 : UH2, v2 : UH3, v3 : UH3) : struct (UH3 * UH3) =
    match v1 with
    | UH2_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH0 = method13(v0, v4)
        let v7 : bool = method16(v6, v2)
        if v7 then
            method12(v0, v5, v2, v3)
        else
            let v10 : UH3 = UH3_1(v6, v2)
            let v11 : UH3 = UH3_1(v6, v3)
            method12(v0, v5, v10, v11)
    | UH2_0 -> (* SymbolListNil *)
        struct (v2, v3)
and method11 (v0 : UH2, v1 : UH1, v2 : UH3, v3 : UH3) : US2 =
    match v3 with
    | UH3_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH1_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH3, v10 : UH3) = method12(v5, v0, v2, v6)
            method11(v0, v8, v9, v10)
        | UH1_0 -> (* StateBudgetZero *)
            US2_1(v2)
    | UH3_0 -> (* RegexListNil *)
        US2_0(v2)
and method20 (v0 : UH0, v1 : UH0, v2 : UH4) : bool =
    match v2 with
    | UH4_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method5(v0, v3)
        let v11 : bool =
            if v6 then
                method5(v1, v4)
            else
                let v8 : bool = method5(v0, v4)
                if v8 then
                    method5(v1, v3)
                else
                    false
        if v11 then
            true
        else
            method20(v0, v1, v5)
    | UH4_0 -> (* DfaStatePairNil *)
        false
and method21 (v0 : UH0, v1 : UH0, v2 : UH2, v3 : UH4) : UH4 =
    match v2 with
    | UH2_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH0 = method13(v0, v4)
        let v7 : UH0 = method13(v1, v4)
        let v8 : UH4 = UH4_1(v6, v7, v3)
        method21(v0, v1, v5, v8)
    | UH2_0 -> (* SymbolListNil *)
        v3
and method19 (v0 : UH2, v1 : UH4, v2 : UH4) : bool =
    match v1 with
    | UH4_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method5(v3, v4)
        if v6 then
            method19(v0, v5, v2)
        else
            let v8 : bool = method20(v3, v4, v2)
            if v8 then
                method19(v0, v5, v2)
            else
                let v10 : US3 = method15(v3)
                let v11 : US3 = method15(v4)
                let v15 : bool =
                    match v10 with
                    | US3_1 -> (* NonNullable *)
                        match v11 with
                        | US3_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_0 -> (* Nullable *)
                        match v11 with
                        | US3_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH4 = method21(v3, v4, v0, v5)
                    let v17 : UH4 = UH4_1(v3, v4, v2)
                    method19(v0, v16, v17)
                else
                    false
    | UH4_0 -> (* DfaStatePairNil *)
        true
and method18 (v0 : UH0, v1 : UH3, v2 : UH2) : US4 =
    match v1 with
    | UH3_1(v4, v5) -> (* RegexListCons *)
        let v6 : UH0 = method0(v0)
        let v7 : UH0 = method0(v4)
        let v8 : UH4 = UH4_0
        let v9 : UH4 = UH4_1(v6, v7, v8)
        let v10 : UH4 = UH4_0
        let v11 : bool = method19(v2, v9, v10)
        if v11 then
            US4_0(v4)
        else
            method18(v0, v5, v2)
    | UH3_0 -> (* RegexListNil *)
        US4_1
and method17 (v0 : UH3, v1 : UH2, v2 : UH3) : UH3 =
    match v0 with
    | UH3_1(v3, v4) -> (* RegexListCons *)
        let v5 : US4 = method18(v3, v2, v1)
        match v5 with
        | US4_0(v6) -> (* DfaRepresentativeFound *)
            method17(v4, v1, v2)
        | US4_1 -> (* DfaRepresentativeMissing *)
            let v8 : UH3 = UH3_1(v3, v2)
            method17(v4, v1, v8)
    | UH3_0 -> (* RegexListNil *)
        v2
and method26 (v0 : UH5, v1 : US0) : UH5 =
    match v0 with
    | UH5_1(v4, v5) -> (* InputCons *)
        let v6 : UH5 = method26(v5, v1)
        UH5_1(v4, v6)
    | UH5_0 -> (* InputEmpty *)
        let v2 : UH5 = UH5_0
        UH5_1(v1, v2)
and method25 (v0 : UH0, v1 : UH0, v2 : UH5, v3 : UH2, v4 : UH6) : UH6 =
    match v3 with
    | UH2_1(v5, v6) -> (* SymbolListCons *)
        let v7 : UH0 = method13(v0, v5)
        let v8 : UH0 = method13(v1, v5)
        let v9 : UH5 = method26(v2, v5)
        let v10 : UH6 = UH6_1(v7, v8, v9, v4)
        method25(v0, v1, v2, v6, v10)
    | UH2_0 -> (* SymbolListNil *)
        v4
and method24 (v0 : UH2, v1 : UH6, v2 : UH4) : US5 =
    match v1 with
    | UH6_1(v4, v5, v6, v7) -> (* DfaConstructivePairTraceCons *)
        let v8 : bool = method5(v4, v5)
        if v8 then
            method24(v0, v7, v2)
        else
            let v10 : bool = method20(v4, v5, v2)
            if v10 then
                method24(v0, v7, v2)
            else
                let v12 : US3 = method15(v4)
                let v13 : US3 = method15(v5)
                let v17 : bool =
                    match v12 with
                    | US3_1 -> (* NonNullable *)
                        match v13 with
                        | US3_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_0 -> (* Nullable *)
                        match v13 with
                        | US3_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v17 then
                    let v18 : UH6 = method25(v4, v5, v6, v0, v7)
                    let v19 : UH4 = UH4_1(v4, v5, v2)
                    method24(v0, v18, v19)
                else
                    US5_1(v6)
    | UH6_0 -> (* DfaConstructivePairTraceNil *)
        US5_0
and method28 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : UH7 = method28(v3, v1)
        UH7_1(v2, v4)
    | UH7_0 -> (* InputListNil *)
        v1
and method29 (v0 : UH0, v1 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = method27(v0, v3)
        let v6 : UH7 = method29(v0, v4)
        method28(v5, v6)
    | UH7_0 -> (* InputListNil *)
        UH7_0
and method33 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH5_1(v5, v6) -> (* InputCons *)
            let v16 : US1 =
                match v3 with
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
            let v17 : bool =
                match v16 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                method33(v4, v6)
            else
                false
        | _ ->
            false
    | UH5_0 -> (* InputEmpty *)
        match v1 with
        | UH5_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and method32 (v0 : UH5, v1 : UH7) : bool =
    match v1 with
    | UH7_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method33(v0, v2)
        if v4 then
            true
        else
            method32(v0, v3)
    | UH7_0 -> (* InputListNil *)
        false
and method31 (v0 : UH7, v1 : UH7, v2 : UH7) : struct (UH7 * UH7) =
    match v0 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method32(v3, v1)
        if v5 then
            method31(v4, v1, v2)
        else
            let v8 : UH7 = UH7_1(v3, v1)
            let v9 : UH7 = UH7_1(v3, v2)
            method31(v4, v8, v9)
    | UH7_0 -> (* InputListNil *)
        struct (v1, v2)
and method30 (v0 : UH0, v1 : UH7, v2 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = method27(v0, v3)
        let struct (v6 : UH7, v7 : UH7) = method31(v5, v2, v4)
        method30(v0, v7, v6)
    | UH7_0 -> (* InputListNil *)
        v2
and method27 (v0 : UH0, v1 : UH5) : UH7 =
    match v0 with
    | UH0_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH7 = method27(v26, v1)
        let v29 : UH7 = method27(v27, v1)
        method28(v28, v29)
    | UH0_4(v31, v32) -> (* RegexCat *)
        let v33 : UH7 = method27(v31, v1)
        method29(v32, v33)
    | UH0_2(v5) -> (* RegexChar *)
        match v1 with
        | UH5_1(v7, v8) -> (* InputCons *)
            let v18 : US1 =
                match v5 with
                | US0_1 -> (* BitOne *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US1_1
                    | US0_0 -> (* BitZero *)
                        US1_2
                | US0_0 -> (* BitZero *)
                    match v7 with
                    | US0_1 -> (* BitOne *)
                        US1_0
                    | US0_0 -> (* BitZero *)
                        US1_1
            let v19 : bool =
                match v18 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH7 = UH7_0
                UH7_1(v8, v20)
            else
                UH7_0
        | UH5_0 -> (* InputEmpty *)
            UH7_0
    | UH0_0 -> (* RegexEmpty *)
        UH7_0
    | UH0_1 -> (* RegexEpsilon *)
        let v3 : UH7 = UH7_0
        UH7_1(v1, v3)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH7 = UH7_0
        let v37 : UH7 = UH7_1(v1, v36)
        let v38 : UH7 = UH7_0
        let v39 : UH7 = UH7_1(v1, v38)
        method30(v35, v37, v39)
and method23 (v0 : UH0, v1 : UH3, v2 : UH2) : bool =
    match v1 with
    | UH3_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH0 = method0(v0)
        let v6 : UH0 = method0(v3)
        let v7 : UH5 = UH5_0
        let v8 : UH6 = UH6_0
        let v9 : UH6 = UH6_1(v5, v6, v7, v8)
        let v10 : UH4 = UH4_0
        let v11 : US5 = method24(v2, v9, v10)
        match v11 with
        | US5_1(v12) -> (* DfaConstructiveDistinguished *)
            let v13 : UH0 = method0(v0)
            let v14 : UH5 = UH5_0
            let v15 : UH7 = method27(v13, v12)
            let v16 : bool = method32(v14, v15)
            let v17 : UH0 = method0(v3)
            let v18 : UH5 = UH5_0
            let v19 : UH7 = method27(v17, v12)
            let v20 : bool = method32(v18, v19)
            let v22 : bool =
                if v16 then
                    v20
                else
                    let v21 : bool = false = v20
                    v21
            let v23 : bool = v22 = false
            if v23 then
                method23(v0, v4, v2)
            else
                false
        | US5_0 -> (* DfaConstructiveEquivalent *)
            false
    | UH3_0 -> (* RegexListNil *)
        true
and method22 (v0 : UH3, v1 : UH2) : bool =
    match v0 with
    | UH3_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method23(v2, v3, v1)
        if v4 then
            method22(v3, v1)
        else
            false
    | UH3_0 -> (* RegexListNil *)
        true
and method37 (v0 : UH8, v1 : UH8) : US1 =
    match v0 with
    | UH8_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH8_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method37(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method37(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH8_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH8_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method37(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method37(v35, v41)
            | _ ->
                v42
        | UH8_2(v38) -> (* RegexChar *)
            US1_2
        | UH8_0 -> (* RegexEmpty *)
            US1_2
        | UH8_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH8_2(v10) -> (* RegexChar *)
        match v1 with
        | UH8_2(v13) -> (* RegexChar *)
            match v10 with
            | US6_0 -> (* TriA *)
                match v13 with
                | US6_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v13 with
                | US6_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v10 with
                    | US6_1 -> (* TriB *)
                        match v13 with
                        | US6_1 -> (* TriB *)
                            US1_1
                        | US6_2 -> (* TriC *)
                            US1_0
                    | US6_2 -> (* TriC *)
                        match v13 with
                        | US6_1 -> (* TriB *)
                            US1_2
                        | US6_2 -> (* TriC *)
                            US1_1
        | UH8_0 -> (* RegexEmpty *)
            US1_2
        | UH8_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH8_0 -> (* RegexEmpty *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH8_1 -> (* RegexEpsilon *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            US1_2
        | UH8_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH8_5(v50) -> (* RegexStar *)
        match v1 with
        | UH8_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH8_5(v54) -> (* RegexStar *)
            method37(v50, v54)
        | _ ->
            US1_2
and method36 (v0 : UH8, v1 : UH8) : UH8 =
    match v1 with
    | UH8_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method37(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH8 = method36(v0, v3)
            UH8_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH8_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH8_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method37(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH8_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH8_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method35 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH8 = method36(v2, v1)
        method35(v3, v4)
    | UH8_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method36(v0, v1)
and method39 (v0 : UH8, v1 : UH8) : bool =
    match v0 with
    | UH8_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH8_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method39(v24, v26)
            if v28 then
                method39(v25, v27)
            else
                false
        | _ ->
            false
    | UH8_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH8_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method39(v32, v34)
            if v36 then
                method39(v33, v35)
            else
                false
        | _ ->
            false
    | UH8_2(v4) -> (* RegexChar *)
        match v1 with
        | UH8_2(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US6_0 -> (* TriA *)
                    match v5 with
                    | US6_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US6_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v4 with
                        | US6_1 -> (* TriB *)
                            match v5 with
                            | US6_1 -> (* TriB *)
                                US1_1
                            | US6_2 -> (* TriC *)
                                US1_0
                        | US6_2 -> (* TriC *)
                            match v5 with
                            | US6_1 -> (* TriB *)
                                US1_2
                            | US6_2 -> (* TriC *)
                                US1_1
            match v21 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH8_0 -> (* RegexEmpty *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH8_1 -> (* RegexEpsilon *)
        match v1 with
        | UH8_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH8_5(v40) -> (* RegexStar *)
        match v1 with
        | UH8_5(v41) -> (* RegexStar *)
            method39(v40, v41)
        | _ ->
            false
and method38 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH8_0
    | _ ->
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            UH8_0
        | _ ->
            match v0 with
            | UH8_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH8_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH8_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH8 = method38(v13, v1)
                        UH8_4(v12, v14)
                    | UH8_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH8_5(v5) -> (* RegexStar *)
                            let v6 : bool = method39(v4, v5)
                            if v6 then
                                UH8_5(v4)
                            else
                                UH8_4(v0, v1)
                        | _ ->
                            UH8_4(v0, v1)
                    | _ ->
                        UH8_4(v0, v1)
and method40 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH8_1
    | UH8_1 -> (* RegexEpsilon *)
        UH8_1
    | UH8_5(v3) -> (* RegexStar *)
        UH8_5(v3)
    | _ ->
        UH8_5(v0)
and method34 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH8 = method34(v5)
        let v8 : UH8 = method34(v6)
        method35(v7, v8)
    | UH8_4(v10, v11) -> (* RegexCat *)
        let v12 : UH8 = method34(v10)
        let v13 : UH8 = method34(v11)
        method38(v12, v13)
    | UH8_2(v3) -> (* RegexChar *)
        UH8_2(v3)
    | UH8_0 -> (* RegexEmpty *)
        UH8_0
    | UH8_1 -> (* RegexEpsilon *)
        UH8_1
    | UH8_5(v15) -> (* RegexStar *)
        let v16 : UH8 = method34(v15)
        method40(v16)
and method41 (v0 : UH8) : UH1 =
    match v0 with
    | UH8_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH1 = method41(v6)
        let v9 : UH1 = method41(v7)
        method8(v8, v9)
    | UH8_4(v11, v12) -> (* RegexCat *)
        let v13 : UH1 = method41(v11)
        let v14 : UH1 = method41(v12)
        method8(v13, v14)
    | UH8_2(v3) -> (* RegexChar *)
        let v4 : UH1 = UH1_0
        UH1_1(v4)
    | UH8_0 -> (* RegexEmpty *)
        UH1_0
    | UH8_1 -> (* RegexEpsilon *)
        UH1_0
    | UH8_5(v16) -> (* RegexStar *)
        method41(v16)
and method46 (v0 : UH8) : US3 =
    match v0 with
    | UH8_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method46(v5)
        let v8 : US3 = method46(v6)
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
    | UH8_4(v16, v17) -> (* RegexCat *)
        let v18 : US3 = method46(v16)
        let v19 : US3 = method46(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH8_2(v3) -> (* RegexChar *)
        US3_1
    | UH8_0 -> (* RegexEmpty *)
        US3_1
    | UH8_1 -> (* RegexEpsilon *)
        US3_0
    | UH8_5(v25) -> (* RegexStar *)
        US3_0
and method45 (v0 : UH8, v1 : US6) : UH8 =
    match v0 with
    | UH8_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH8 = method45(v25, v1)
        let v28 : UH8 = method45(v26, v1)
        method35(v27, v28)
    | UH8_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method46(v30)
        match v32 with
        | US3_1 -> (* NonNullable *)
            let v37 : UH8 = method45(v30, v1)
            method38(v37, v31)
        | US3_0 -> (* Nullable *)
            let v33 : UH8 = method45(v30, v1)
            let v34 : UH8 = method38(v33, v31)
            let v35 : UH8 = method45(v31, v1)
            method35(v34, v35)
    | UH8_2(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US6_0 -> (* TriA *)
                match v1 with
                | US6_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v1 with
                | US6_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v4 with
                    | US6_1 -> (* TriB *)
                        match v1 with
                        | US6_1 -> (* TriB *)
                            US1_1
                        | US6_2 -> (* TriC *)
                            US1_0
                    | US6_2 -> (* TriC *)
                        match v1 with
                        | US6_1 -> (* TriB *)
                            US1_2
                        | US6_2 -> (* TriC *)
                            US1_1
        let v21 : bool =
            match v20 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH8_1
        else
            UH8_0
    | UH8_0 -> (* RegexEmpty *)
        UH8_0
    | UH8_1 -> (* RegexEpsilon *)
        UH8_0
    | UH8_5(v41) -> (* RegexStar *)
        let v42 : UH8 = method45(v41, v1)
        let v43 : UH8 = method40(v41)
        method38(v42, v43)
and method44 (v0 : UH8, v1 : US6) : UH8 =
    let v2 : UH8 = method34(v0)
    let v3 : UH8 = method45(v2, v1)
    method34(v3)
and method47 (v0 : UH8, v1 : UH10) : bool =
    match v1 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method39(v0, v2)
        if v4 then
            true
        else
            method47(v0, v3)
    | UH10_0 -> (* RegexListNil *)
        false
and method43 (v0 : UH8, v1 : UH9, v2 : UH10, v3 : UH10) : struct (UH10 * UH10) =
    match v1 with
    | UH9_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH8 = method44(v0, v4)
        let v7 : bool = method47(v6, v2)
        if v7 then
            method43(v0, v5, v2, v3)
        else
            let v10 : UH10 = UH10_1(v6, v2)
            let v11 : UH10 = UH10_1(v6, v3)
            method43(v0, v5, v10, v11)
    | UH9_0 -> (* SymbolListNil *)
        struct (v2, v3)
and method42 (v0 : UH9, v1 : UH1, v2 : UH10, v3 : UH10) : US7 =
    match v3 with
    | UH10_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH1_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH10, v10 : UH10) = method43(v5, v0, v2, v6)
            method42(v0, v8, v9, v10)
        | UH1_0 -> (* StateBudgetZero *)
            US7_1(v2)
    | UH10_0 -> (* RegexListNil *)
        US7_0(v2)
and method51 (v0 : UH8, v1 : UH8, v2 : UH11) : bool =
    match v2 with
    | UH11_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method39(v0, v3)
        let v11 : bool =
            if v6 then
                method39(v1, v4)
            else
                let v8 : bool = method39(v0, v4)
                if v8 then
                    method39(v1, v3)
                else
                    false
        if v11 then
            true
        else
            method51(v0, v1, v5)
    | UH11_0 -> (* DfaStatePairNil *)
        false
and method52 (v0 : UH8, v1 : UH8, v2 : UH9, v3 : UH11) : UH11 =
    match v2 with
    | UH9_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH8 = method44(v0, v4)
        let v7 : UH8 = method44(v1, v4)
        let v8 : UH11 = UH11_1(v6, v7, v3)
        method52(v0, v1, v5, v8)
    | UH9_0 -> (* SymbolListNil *)
        v3
and method50 (v0 : UH9, v1 : UH11, v2 : UH11) : bool =
    match v1 with
    | UH11_1(v3, v4, v5) -> (* DfaStatePairCons *)
        let v6 : bool = method39(v3, v4)
        if v6 then
            method50(v0, v5, v2)
        else
            let v8 : bool = method51(v3, v4, v2)
            if v8 then
                method50(v0, v5, v2)
            else
                let v10 : US3 = method46(v3)
                let v11 : US3 = method46(v4)
                let v15 : bool =
                    match v10 with
                    | US3_1 -> (* NonNullable *)
                        match v11 with
                        | US3_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_0 -> (* Nullable *)
                        match v11 with
                        | US3_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v15 then
                    let v16 : UH11 = method52(v3, v4, v0, v5)
                    let v17 : UH11 = UH11_1(v3, v4, v2)
                    method50(v0, v16, v17)
                else
                    false
    | UH11_0 -> (* DfaStatePairNil *)
        true
and method49 (v0 : UH8, v1 : UH10, v2 : UH9) : US8 =
    match v1 with
    | UH10_1(v4, v5) -> (* RegexListCons *)
        let v6 : UH8 = method34(v0)
        let v7 : UH8 = method34(v4)
        let v8 : UH11 = UH11_0
        let v9 : UH11 = UH11_1(v6, v7, v8)
        let v10 : UH11 = UH11_0
        let v11 : bool = method50(v2, v9, v10)
        if v11 then
            US8_0(v4)
        else
            method49(v0, v5, v2)
    | UH10_0 -> (* RegexListNil *)
        US8_1
and method48 (v0 : UH10, v1 : UH9, v2 : UH10) : UH10 =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : US8 = method49(v3, v2, v1)
        match v5 with
        | US8_0(v6) -> (* DfaRepresentativeFound *)
            method48(v4, v1, v2)
        | US8_1 -> (* DfaRepresentativeMissing *)
            let v8 : UH10 = UH10_1(v3, v2)
            method48(v4, v1, v8)
    | UH10_0 -> (* RegexListNil *)
        v2
and method57 (v0 : UH12, v1 : US6) : UH12 =
    match v0 with
    | UH12_1(v4, v5) -> (* InputCons *)
        let v6 : UH12 = method57(v5, v1)
        UH12_1(v4, v6)
    | UH12_0 -> (* InputEmpty *)
        let v2 : UH12 = UH12_0
        UH12_1(v1, v2)
and method56 (v0 : UH8, v1 : UH8, v2 : UH12, v3 : UH9, v4 : UH13) : UH13 =
    match v3 with
    | UH9_1(v5, v6) -> (* SymbolListCons *)
        let v7 : UH8 = method44(v0, v5)
        let v8 : UH8 = method44(v1, v5)
        let v9 : UH12 = method57(v2, v5)
        let v10 : UH13 = UH13_1(v7, v8, v9, v4)
        method56(v0, v1, v2, v6, v10)
    | UH9_0 -> (* SymbolListNil *)
        v4
and method55 (v0 : UH9, v1 : UH13, v2 : UH11) : US9 =
    match v1 with
    | UH13_1(v4, v5, v6, v7) -> (* DfaConstructivePairTraceCons *)
        let v8 : bool = method39(v4, v5)
        if v8 then
            method55(v0, v7, v2)
        else
            let v10 : bool = method51(v4, v5, v2)
            if v10 then
                method55(v0, v7, v2)
            else
                let v12 : US3 = method46(v4)
                let v13 : US3 = method46(v5)
                let v17 : bool =
                    match v12 with
                    | US3_1 -> (* NonNullable *)
                        match v13 with
                        | US3_1 -> (* NonNullable *)
                            true
                        | _ ->
                            false
                    | US3_0 -> (* Nullable *)
                        match v13 with
                        | US3_0 -> (* Nullable *)
                            true
                        | _ ->
                            false
                if v17 then
                    let v18 : UH13 = method56(v4, v5, v6, v0, v7)
                    let v19 : UH11 = UH11_1(v4, v5, v2)
                    method55(v0, v18, v19)
                else
                    US9_1(v6)
    | UH13_0 -> (* DfaConstructivePairTraceNil *)
        US9_0
and method59 (v0 : UH14, v1 : UH14) : UH14 =
    match v0 with
    | UH14_1(v2, v3) -> (* InputListCons *)
        let v4 : UH14 = method59(v3, v1)
        UH14_1(v2, v4)
    | UH14_0 -> (* InputListNil *)
        v1
and method60 (v0 : UH8, v1 : UH14) : UH14 =
    match v1 with
    | UH14_1(v3, v4) -> (* InputListCons *)
        let v5 : UH14 = method58(v0, v3)
        let v6 : UH14 = method60(v0, v4)
        method59(v5, v6)
    | UH14_0 -> (* InputListNil *)
        UH14_0
and method64 (v0 : UH12, v1 : UH12) : bool =
    match v0 with
    | UH12_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH12_1(v5, v6) -> (* InputCons *)
            let v22 : US1 =
                match v3 with
                | US6_0 -> (* TriA *)
                    match v5 with
                    | US6_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US6_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v3 with
                        | US6_1 -> (* TriB *)
                            match v5 with
                            | US6_1 -> (* TriB *)
                                US1_1
                            | US6_2 -> (* TriC *)
                                US1_0
                        | US6_2 -> (* TriC *)
                            match v5 with
                            | US6_1 -> (* TriB *)
                                US1_2
                            | US6_2 -> (* TriC *)
                                US1_1
            let v23 : bool =
                match v22 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                method64(v4, v6)
            else
                false
        | _ ->
            false
    | UH12_0 -> (* InputEmpty *)
        match v1 with
        | UH12_0 -> (* InputEmpty *)
            true
        | _ ->
            false
and method63 (v0 : UH12, v1 : UH14) : bool =
    match v1 with
    | UH14_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method64(v0, v2)
        if v4 then
            true
        else
            method63(v0, v3)
    | UH14_0 -> (* InputListNil *)
        false
and method62 (v0 : UH14, v1 : UH14, v2 : UH14) : struct (UH14 * UH14) =
    match v0 with
    | UH14_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method63(v3, v1)
        if v5 then
            method62(v4, v1, v2)
        else
            let v8 : UH14 = UH14_1(v3, v1)
            let v9 : UH14 = UH14_1(v3, v2)
            method62(v4, v8, v9)
    | UH14_0 -> (* InputListNil *)
        struct (v1, v2)
and method61 (v0 : UH8, v1 : UH14, v2 : UH14) : UH14 =
    match v1 with
    | UH14_1(v3, v4) -> (* InputListCons *)
        let v5 : UH14 = method58(v0, v3)
        let struct (v6 : UH14, v7 : UH14) = method62(v5, v2, v4)
        method61(v0, v7, v6)
    | UH14_0 -> (* InputListNil *)
        v2
and method58 (v0 : UH8, v1 : UH12) : UH14 =
    match v0 with
    | UH8_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH14 = method58(v32, v1)
        let v35 : UH14 = method58(v33, v1)
        method59(v34, v35)
    | UH8_4(v37, v38) -> (* RegexCat *)
        let v39 : UH14 = method58(v37, v1)
        method60(v38, v39)
    | UH8_2(v5) -> (* RegexChar *)
        match v1 with
        | UH12_1(v7, v8) -> (* InputCons *)
            let v24 : US1 =
                match v5 with
                | US6_0 -> (* TriA *)
                    match v7 with
                    | US6_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v7 with
                    | US6_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v5 with
                        | US6_1 -> (* TriB *)
                            match v7 with
                            | US6_1 -> (* TriB *)
                                US1_1
                            | US6_2 -> (* TriC *)
                                US1_0
                        | US6_2 -> (* TriC *)
                            match v7 with
                            | US6_1 -> (* TriB *)
                                US1_2
                            | US6_2 -> (* TriC *)
                                US1_1
            let v25 : bool =
                match v24 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH14 = UH14_0
                UH14_1(v8, v26)
            else
                UH14_0
        | UH12_0 -> (* InputEmpty *)
            UH14_0
    | UH8_0 -> (* RegexEmpty *)
        UH14_0
    | UH8_1 -> (* RegexEpsilon *)
        let v3 : UH14 = UH14_0
        UH14_1(v1, v3)
    | UH8_5(v41) -> (* RegexStar *)
        let v42 : UH14 = UH14_0
        let v43 : UH14 = UH14_1(v1, v42)
        let v44 : UH14 = UH14_0
        let v45 : UH14 = UH14_1(v1, v44)
        method61(v41, v43, v45)
and method54 (v0 : UH8, v1 : UH10, v2 : UH9) : bool =
    match v1 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH8 = method34(v0)
        let v6 : UH8 = method34(v3)
        let v7 : UH12 = UH12_0
        let v8 : UH13 = UH13_0
        let v9 : UH13 = UH13_1(v5, v6, v7, v8)
        let v10 : UH11 = UH11_0
        let v11 : US9 = method55(v2, v9, v10)
        match v11 with
        | US9_1(v12) -> (* DfaConstructiveDistinguished *)
            let v13 : UH8 = method34(v0)
            let v14 : UH12 = UH12_0
            let v15 : UH14 = method58(v13, v12)
            let v16 : bool = method63(v14, v15)
            let v17 : UH8 = method34(v3)
            let v18 : UH12 = UH12_0
            let v19 : UH14 = method58(v17, v12)
            let v20 : bool = method63(v18, v19)
            let v22 : bool =
                if v16 then
                    v20
                else
                    let v21 : bool = false = v20
                    v21
            let v23 : bool = v22 = false
            if v23 then
                method54(v0, v4, v2)
            else
                false
        | US9_0 -> (* DfaConstructiveEquivalent *)
            false
    | UH10_0 -> (* RegexListNil *)
        true
and method53 (v0 : UH10, v1 : UH9) : bool =
    match v0 with
    | UH10_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method54(v2, v3, v1)
        if v4 then
            method53(v3, v1)
        else
            false
    | UH10_0 -> (* RegexListNil *)
        true
and method65 (v0 : UH3, v1 : UH1) : bool =
    match v0 with
    | UH3_1(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH1_1(v5) -> (* StateBudgetSucc *)
            method65(v4, v5)
        | _ ->
            false
    | UH3_0 -> (* RegexListNil *)
        match v1 with
        | UH1_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
and method66 (v0 : UH10, v1 : UH1) : bool =
    match v0 with
    | UH10_1(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH1_1(v5) -> (* StateBudgetSucc *)
            method66(v4, v5)
        | _ ->
            false
    | UH10_0 -> (* RegexListNil *)
        match v1 with
        | UH1_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
let v0 : US0 = US0_0
let v1 : UH0 = UH0_2(v0)
let v2 : US0 = US0_1
let v3 : UH0 = UH0_2(v2)
let v4 : UH0 = UH0_3(v1, v3)
let v5 : UH0 = UH0_5(v4)
let v6 : US0 = US0_0
let v7 : UH0 = UH0_2(v6)
let v8 : UH0 = UH0_4(v5, v7)
let v9 : UH0 = method0(v8)
let v10 : UH0 = method0(v9)
let v11 : UH1 = method7(v10)
let v12 : UH1 = UH1_1(v11)
let v13 : UH1 = method9(v12)
let v14 : UH0 = method0(v10)
let v15 : US0 = US0_0
let v16 : US0 = US0_1
let v17 : UH2 = UH2_0
let v18 : UH2 = UH2_1(v16, v17)
let v19 : UH2 = UH2_1(v15, v18)
let v20 : UH3 = UH3_0
let v21 : UH3 = UH3_1(v14, v20)
let v22 : UH3 = UH3_0
let v23 : UH3 = UH3_1(v14, v22)
let v24 : US2 = method11(v19, v13, v21, v23)
let v41 : bool =
    match v24 with
    | US2_1(v25) -> (* DfaClosureBudgetExceeded *)
        false
    | US2_0(v26) -> (* DfaClosureComplete *)
        let v27 : US0 = US0_0
        let v28 : US0 = US0_1
        let v29 : UH2 = UH2_0
        let v30 : UH2 = UH2_1(v28, v29)
        let v31 : UH2 = UH2_1(v27, v30)
        let v32 : UH3 = UH3_0
        let v33 : UH3 = method17(v26, v31, v32)
        let v34 : US0 = US0_0
        let v35 : US0 = US0_1
        let v36 : UH2 = UH2_0
        let v37 : UH2 = UH2_1(v35, v36)
        let v38 : UH2 = UH2_1(v34, v37)
        method22(v33, v38)
if v41 then
    ()
else
    failwith<unit> "bit minimized DFA representatives should carry independent distinguishing words"
let v42 : US6 = US6_0
let v43 : UH8 = UH8_2(v42)
let v44 : UH8 = UH8_5(v43)
let v45 : UH8 = method34(v44)
let v46 : UH8 = method34(v45)
let v47 : UH1 = method41(v46)
let v48 : UH1 = UH1_1(v47)
let v49 : UH1 = method9(v48)
let v50 : UH8 = method34(v46)
let v51 : US6 = US6_0
let v52 : US6 = US6_1
let v53 : US6 = US6_2
let v54 : UH9 = UH9_0
let v55 : UH9 = UH9_1(v53, v54)
let v56 : UH9 = UH9_1(v52, v55)
let v57 : UH9 = UH9_1(v51, v56)
let v58 : UH10 = UH10_0
let v59 : UH10 = UH10_1(v50, v58)
let v60 : UH10 = UH10_0
let v61 : UH10 = UH10_1(v50, v60)
let v62 : US7 = method42(v57, v49, v59, v61)
let v83 : bool =
    match v62 with
    | US7_1(v63) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_0(v64) -> (* DfaClosureComplete *)
        let v65 : US6 = US6_0
        let v66 : US6 = US6_1
        let v67 : US6 = US6_2
        let v68 : UH9 = UH9_0
        let v69 : UH9 = UH9_1(v67, v68)
        let v70 : UH9 = UH9_1(v66, v69)
        let v71 : UH9 = UH9_1(v65, v70)
        let v72 : UH10 = UH10_0
        let v73 : UH10 = method48(v64, v71, v72)
        let v74 : US6 = US6_0
        let v75 : US6 = US6_1
        let v76 : US6 = US6_2
        let v77 : UH9 = UH9_0
        let v78 : UH9 = UH9_1(v76, v77)
        let v79 : UH9 = UH9_1(v75, v78)
        let v80 : UH9 = UH9_1(v74, v79)
        method53(v73, v80)
if v83 then
    ()
else
    failwith<unit> "ternary star minimized DFA representatives should carry independent distinguishing words"
let v84 : US6 = US6_0
let v85 : UH8 = UH8_2(v84)
let v86 : US6 = US6_0
let v87 : UH8 = UH8_2(v86)
let v88 : UH8 = UH8_5(v87)
let v89 : UH8 = UH8_4(v85, v88)
let v90 : US6 = US6_1
let v91 : UH8 = UH8_2(v90)
let v92 : US6 = US6_0
let v93 : UH8 = UH8_2(v92)
let v94 : US6 = US6_0
let v95 : UH8 = UH8_2(v94)
let v96 : UH8 = UH8_4(v93, v95)
let v97 : UH8 = UH8_5(v96)
let v98 : US6 = US6_0
let v99 : UH8 = UH8_2(v98)
let v100 : UH8 = UH8_4(v99, v97)
let v101 : UH8 = UH8_3(v97, v100)
let v102 : UH8 = UH8_4(v91, v101)
let v103 : UH8 = UH8_3(v89, v102)
let v104 : UH8 = method34(v103)
let v105 : UH8 = method34(v104)
let v106 : UH1 = method41(v105)
let v107 : UH1 = UH1_1(v106)
let v108 : UH1 = method9(v107)
let v109 : UH8 = method34(v105)
let v110 : US6 = US6_0
let v111 : US6 = US6_1
let v112 : US6 = US6_2
let v113 : UH9 = UH9_0
let v114 : UH9 = UH9_1(v112, v113)
let v115 : UH9 = UH9_1(v111, v114)
let v116 : UH9 = UH9_1(v110, v115)
let v117 : UH10 = UH10_0
let v118 : UH10 = UH10_1(v109, v117)
let v119 : UH10 = UH10_0
let v120 : UH10 = UH10_1(v109, v119)
let v121 : US7 = method42(v116, v108, v118, v120)
let v142 : bool =
    match v121 with
    | US7_1(v122) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_0(v123) -> (* DfaClosureComplete *)
        let v124 : US6 = US6_0
        let v125 : US6 = US6_1
        let v126 : US6 = US6_2
        let v127 : UH9 = UH9_0
        let v128 : UH9 = UH9_1(v126, v127)
        let v129 : UH9 = UH9_1(v125, v128)
        let v130 : UH9 = UH9_1(v124, v129)
        let v131 : UH10 = UH10_0
        let v132 : UH10 = method48(v123, v130, v131)
        let v133 : US6 = US6_0
        let v134 : US6 = US6_1
        let v135 : US6 = US6_2
        let v136 : UH9 = UH9_0
        let v137 : UH9 = UH9_1(v135, v136)
        let v138 : UH9 = UH9_1(v134, v137)
        let v139 : UH9 = UH9_1(v133, v138)
        method53(v132, v139)
if v142 then
    ()
else
    failwith<unit> "cyclic quotient representatives should carry independent distinguishing words"
let v143 : US0 = US0_0
let v144 : UH0 = UH0_2(v143)
let v145 : US0 = US0_1
let v146 : UH0 = UH0_2(v145)
let v147 : UH0 = UH0_3(v144, v146)
let v148 : UH0 = UH0_5(v147)
let v149 : US0 = US0_0
let v150 : UH0 = UH0_2(v149)
let v151 : UH0 = UH0_4(v148, v150)
let v152 : UH0 = method0(v151)
let v153 : UH0 = method0(v152)
let v154 : UH1 = method7(v153)
let v155 : UH1 = UH1_1(v154)
let v156 : UH1 = method9(v155)
let v157 : UH0 = method0(v153)
let v158 : US0 = US0_0
let v159 : US0 = US0_1
let v160 : UH2 = UH2_0
let v161 : UH2 = UH2_1(v159, v160)
let v162 : UH2 = UH2_1(v158, v161)
let v163 : UH3 = UH3_0
let v164 : UH3 = UH3_1(v157, v163)
let v165 : UH3 = UH3_0
let v166 : UH3 = UH3_1(v157, v165)
let v167 : US2 = method11(v162, v156, v164, v166)
let v182 : bool =
    match v167 with
    | US2_1(v168) -> (* DfaClosureBudgetExceeded *)
        false
    | US2_0(v169) -> (* DfaClosureComplete *)
        let v170 : US0 = US0_0
        let v171 : US0 = US0_1
        let v172 : UH2 = UH2_0
        let v173 : UH2 = UH2_1(v171, v172)
        let v174 : UH2 = UH2_1(v170, v173)
        let v175 : UH3 = UH3_0
        let v176 : UH3 = method17(v169, v174, v175)
        let v177 : UH1 = UH1_0
        let v178 : UH1 = UH1_1(v177)
        let v179 : UH1 = UH1_1(v178)
        method65(v176, v179)
if v182 then
    ()
else
    failwith<unit> "bit minimized DFA should match the independent two-state reference quotient"
let v183 : US6 = US6_0
let v184 : UH8 = UH8_2(v183)
let v185 : UH8 = UH8_5(v184)
let v186 : UH8 = method34(v185)
let v187 : UH8 = method34(v186)
let v188 : UH1 = method41(v187)
let v189 : UH1 = UH1_1(v188)
let v190 : UH1 = method9(v189)
let v191 : UH8 = method34(v187)
let v192 : US6 = US6_0
let v193 : US6 = US6_1
let v194 : US6 = US6_2
let v195 : UH9 = UH9_0
let v196 : UH9 = UH9_1(v194, v195)
let v197 : UH9 = UH9_1(v193, v196)
let v198 : UH9 = UH9_1(v192, v197)
let v199 : UH10 = UH10_0
let v200 : UH10 = UH10_1(v191, v199)
let v201 : UH10 = UH10_0
let v202 : UH10 = UH10_1(v191, v201)
let v203 : US7 = method42(v198, v190, v200, v202)
let v220 : bool =
    match v203 with
    | US7_1(v204) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_0(v205) -> (* DfaClosureComplete *)
        let v206 : US6 = US6_0
        let v207 : US6 = US6_1
        let v208 : US6 = US6_2
        let v209 : UH9 = UH9_0
        let v210 : UH9 = UH9_1(v208, v209)
        let v211 : UH9 = UH9_1(v207, v210)
        let v212 : UH9 = UH9_1(v206, v211)
        let v213 : UH10 = UH10_0
        let v214 : UH10 = method48(v205, v212, v213)
        let v215 : UH1 = UH1_0
        let v216 : UH1 = UH1_1(v215)
        let v217 : UH1 = UH1_1(v216)
        method66(v214, v217)
if v220 then
    ()
else
    failwith<unit> "ternary star minimized DFA should match the independent two-state reference quotient"
let v221 : US6 = US6_0
let v222 : UH8 = UH8_2(v221)
let v223 : US6 = US6_0
let v224 : UH8 = UH8_2(v223)
let v225 : UH8 = UH8_5(v224)
let v226 : UH8 = UH8_4(v222, v225)
let v227 : US6 = US6_1
let v228 : UH8 = UH8_2(v227)
let v229 : US6 = US6_0
let v230 : UH8 = UH8_2(v229)
let v231 : US6 = US6_0
let v232 : UH8 = UH8_2(v231)
let v233 : UH8 = UH8_4(v230, v232)
let v234 : UH8 = UH8_5(v233)
let v235 : US6 = US6_0
let v236 : UH8 = UH8_2(v235)
let v237 : UH8 = UH8_4(v236, v234)
let v238 : UH8 = UH8_3(v234, v237)
let v239 : UH8 = UH8_4(v228, v238)
let v240 : UH8 = UH8_3(v226, v239)
let v241 : UH8 = method34(v240)
let v242 : UH8 = method34(v241)
let v243 : UH1 = method41(v242)
let v244 : UH1 = UH1_1(v243)
let v245 : UH1 = method9(v244)
let v246 : UH8 = method34(v242)
let v247 : US6 = US6_0
let v248 : US6 = US6_1
let v249 : US6 = US6_2
let v250 : UH9 = UH9_0
let v251 : UH9 = UH9_1(v249, v250)
let v252 : UH9 = UH9_1(v248, v251)
let v253 : UH9 = UH9_1(v247, v252)
let v254 : UH10 = UH10_0
let v255 : UH10 = UH10_1(v246, v254)
let v256 : UH10 = UH10_0
let v257 : UH10 = UH10_1(v246, v256)
let v258 : US7 = method42(v253, v245, v255, v257)
let v276 : bool =
    match v258 with
    | US7_1(v259) -> (* DfaClosureBudgetExceeded *)
        false
    | US7_0(v260) -> (* DfaClosureComplete *)
        let v261 : US6 = US6_0
        let v262 : US6 = US6_1
        let v263 : US6 = US6_2
        let v264 : UH9 = UH9_0
        let v265 : UH9 = UH9_1(v263, v264)
        let v266 : UH9 = UH9_1(v262, v265)
        let v267 : UH9 = UH9_1(v261, v266)
        let v268 : UH10 = UH10_0
        let v269 : UH10 = method48(v260, v267, v268)
        let v270 : UH1 = UH1_0
        let v271 : UH1 = UH1_1(v270)
        let v272 : UH1 = UH1_1(v271)
        let v273 : UH1 = UH1_1(v272)
        method66(v269, v273)
if v276 then
    ()
else
    failwith<unit> "cyclic minimized DFA should match the independent three-state reference quotient"
let v277 : UH0 = UH0_1
let v278 : UH0 = method0(v277)
let v279 : UH0 = UH0_0
let v280 : UH0 = method0(v279)
let v281 : US0 = US0_0
let v282 : US0 = US0_1
let v283 : UH2 = UH2_0
let v284 : UH2 = UH2_1(v282, v283)
let v285 : UH2 = UH2_1(v281, v284)
let v286 : UH5 = UH5_0
let v287 : UH6 = UH6_0
let v288 : UH6 = UH6_1(v278, v280, v286, v287)
let v289 : UH4 = UH4_0
let v290 : US5 = method24(v285, v288, v289)
let v319 : bool =
    match v290 with
    | US5_1(v304) -> (* DfaConstructiveDistinguished *)
        let v305 : UH0 = UH0_1
        let v306 : UH0 = method0(v305)
        let v307 : UH5 = UH5_0
        let v308 : UH7 = method27(v306, v304)
        let v309 : bool = method32(v307, v308)
        let v310 : UH0 = UH0_0
        let v311 : UH0 = method0(v310)
        let v312 : UH5 = UH5_0
        let v313 : UH7 = method27(v311, v304)
        let v314 : bool = method32(v312, v313)
        let v316 : bool =
            if v309 then
                v314
            else
                let v315 : bool = false = v314
                v315
        let v317 : bool = v316 = false
        v317
    | US5_0 -> (* DfaConstructiveEquivalent *)
        let v291 : UH0 = UH0_1
        let v292 : UH0 = method0(v291)
        let v293 : UH0 = UH0_0
        let v294 : UH0 = method0(v293)
        let v295 : US0 = US0_0
        let v296 : US0 = US0_1
        let v297 : UH2 = UH2_0
        let v298 : UH2 = UH2_1(v296, v297)
        let v299 : UH2 = UH2_1(v295, v298)
        let v300 : UH4 = UH4_0
        let v301 : UH4 = UH4_1(v292, v294, v300)
        let v302 : UH4 = UH4_0
        method19(v299, v301, v302)
if v319 then
    ()
else
    failwith<unit> "nullable mismatch should produce a language-valid distinguishing word"
let v320 : UH0 = UH0_1
let v321 : UH0 = method0(v320)
let v322 : UH5 = UH5_0
let v323 : US0 = US0_0
let v324 : UH5 = UH5_0
let v325 : UH5 = UH5_1(v323, v324)
let v326 : UH7 = method27(v321, v325)
let v327 : bool = method32(v322, v326)
let v328 : UH0 = UH0_0
let v329 : UH0 = method0(v328)
let v330 : UH5 = UH5_0
let v331 : US0 = US0_0
let v332 : UH5 = UH5_0
let v333 : UH5 = UH5_1(v331, v332)
let v334 : UH7 = method27(v329, v333)
let v335 : bool = method32(v330, v334)
let v337 : bool =
    if v327 then
        v335
    else
        let v336 : bool = false = v335
        v336
let v338 : bool = v337 = false
let v339 : bool = v338 = false
if v339 then
    ()
else
    failwith<unit> "independent language semantics must reject a forged non-distinguishing word"
let v340 : US0 = US0_0
let v341 : UH0 = UH0_2(v340)
let v342 : US0 = US0_0
let v343 : UH0 = UH0_2(v342)
let v344 : UH0 = UH0_3(v341, v343)
let v345 : UH0 = method0(v344)
let v346 : US0 = US0_0
let v347 : UH0 = UH0_2(v346)
let v348 : UH0 = method0(v347)
let v349 : US0 = US0_0
let v350 : US0 = US0_1
let v351 : UH2 = UH2_0
let v352 : UH2 = UH2_1(v350, v351)
let v353 : UH2 = UH2_1(v349, v352)
let v354 : UH5 = UH5_0
let v355 : UH6 = UH6_0
let v356 : UH6 = UH6_1(v345, v348, v354, v355)
let v357 : UH4 = UH4_0
let v358 : US5 = method24(v353, v356, v357)
let v397 : bool =
    match v358 with
    | US5_1(v377) -> (* DfaConstructiveDistinguished *)
        let v378 : US0 = US0_0
        let v379 : UH0 = UH0_2(v378)
        let v380 : US0 = US0_0
        let v381 : UH0 = UH0_2(v380)
        let v382 : UH0 = UH0_3(v379, v381)
        let v383 : UH0 = method0(v382)
        let v384 : UH5 = UH5_0
        let v385 : UH7 = method27(v383, v377)
        let v386 : bool = method32(v384, v385)
        let v387 : US0 = US0_0
        let v388 : UH0 = UH0_2(v387)
        let v389 : UH0 = method0(v388)
        let v390 : UH5 = UH5_0
        let v391 : UH7 = method27(v389, v377)
        let v392 : bool = method32(v390, v391)
        let v394 : bool =
            if v386 then
                v392
            else
                let v393 : bool = false = v392
                v393
        let v395 : bool = v394 = false
        v395
    | US5_0 -> (* DfaConstructiveEquivalent *)
        let v359 : US0 = US0_0
        let v360 : UH0 = UH0_2(v359)
        let v361 : US0 = US0_0
        let v362 : UH0 = UH0_2(v361)
        let v363 : UH0 = UH0_3(v360, v362)
        let v364 : UH0 = method0(v363)
        let v365 : US0 = US0_0
        let v366 : UH0 = UH0_2(v365)
        let v367 : UH0 = method0(v366)
        let v368 : US0 = US0_0
        let v369 : US0 = US0_1
        let v370 : UH2 = UH2_0
        let v371 : UH2 = UH2_1(v369, v370)
        let v372 : UH2 = UH2_1(v368, v371)
        let v373 : UH4 = UH4_0
        let v374 : UH4 = UH4_1(v364, v367, v373)
        let v375 : UH4 = UH4_0
        method19(v372, v374, v375)
if v397 then
    ()
else
    failwith<unit> "normalized language-equivalent states should remain bisimilar"
let v398 : string = "brzozowski-minimization-witness-green"
v398
