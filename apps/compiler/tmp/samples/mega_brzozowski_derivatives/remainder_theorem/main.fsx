type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0
    | UH0_1 of US0 * UH0
and UH2 =
    | UH2_0
    | UH2_1 of US0 * UH2
and UH1 =
    | UH1_0
    | UH1_1 of UH2 * UH1
and [<Struct>] US1 =
    | US1_0
    | US1_1
    | US1_2
and UH3 =
    | UH3_0
    | UH3_1 of US1 * UH3
and UH5 =
    | UH5_0
    | UH5_1 of US1 * UH5
and UH4 =
    | UH4_0
    | UH4_1 of UH5 * UH4
and UH6 =
    | UH6_0
    | UH6_1
    | UH6_2 of US0
    | UH6_3 of UH6 * UH6
    | UH6_4 of UH6 * UH6
    | UH6_5 of UH6
and [<Struct>] US2 =
    | US2_0
    | US2_1
and UH7 =
    | UH7_0 of US0 * UH2
    | UH7_1 of US0 * UH2
    | UH7_2 of US0 * US0 * UH2
    | UH7_3 of US0 * UH2 * UH7 * UH7
    | UH7_4 of US0 * UH2 * US2 * UH7 * UH7
    | UH7_5 of US0 * UH2 * UH7
and [<Struct>] US3 =
    | US3_0
    | US3_1
and [<Struct>] US4 =
    | US4_0
    | US4_1
    | US4_2
and UH8 =
    | UH8_0
    | UH8_1
    | UH8_2 of US1
    | UH8_3 of UH8 * UH8
    | UH8_4 of UH8 * UH8
    | UH8_5 of UH8
and UH9 =
    | UH9_0 of US1 * UH5
    | UH9_1 of US1 * UH5
    | UH9_2 of US1 * US1 * UH5
    | UH9_3 of US1 * UH5 * UH9 * UH9
    | UH9_4 of US1 * UH5 * US2 * UH9 * UH9
    | UH9_5 of US1 * UH5 * UH9
let rec method0 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        UH1_0
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH1 = method0(v3)
        let v5 : UH2 = UH2_0
        let v6 : UH2 = UH2_1(v2, v5)
        UH1_1(v6, v4)
and method2 (v0 : US0, v1 : UH1) : UH1 =
    match v1 with
    | UH1_0 -> (* InputListNil *)
        UH1_0
    | UH1_1(v3, v4) -> (* InputListCons *)
        let v5 : UH1 = method2(v0, v4)
        let v6 : UH2 = UH2_1(v0, v3)
        UH1_1(v6, v5)
and method3 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* InputListNil *)
        v1
    | UH1_1(v2, v3) -> (* InputListCons *)
        let v4 : UH1 = method3(v3, v1)
        UH1_1(v2, v4)
and method1 (v0 : UH0, v1 : UH1) : UH1 =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        UH1_0
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH1 = method2(v3, v1)
        let v6 : UH1 = method1(v4, v1)
        method3(v5, v6)
and method4 (v0 : UH3) : UH4 =
    match v0 with
    | UH3_0 -> (* SymbolListNil *)
        UH4_0
    | UH3_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = method4(v3)
        let v5 : UH5 = UH5_0
        let v6 : UH5 = UH5_1(v2, v5)
        UH4_1(v6, v4)
and method6 (v0 : US1, v1 : UH4) : UH4 =
    match v1 with
    | UH4_0 -> (* InputListNil *)
        UH4_0
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = method6(v0, v4)
        let v6 : UH5 = UH5_1(v0, v3)
        UH4_1(v6, v5)
and method7 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* InputListNil *)
        v1
    | UH4_1(v2, v3) -> (* InputListCons *)
        let v4 : UH4 = method7(v3, v1)
        UH4_1(v2, v4)
and method5 (v0 : UH3, v1 : UH4) : UH4 =
    match v0 with
    | UH3_0 -> (* SymbolListNil *)
        UH4_0
    | UH3_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH4 = method6(v3, v1)
        let v6 : UH4 = method5(v4, v1)
        method7(v5, v6)
and method11 (v0 : UH6) : US3 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        US3_1
    | UH6_1 -> (* RegexEpsilon *)
        US3_0
    | UH6_2(v3) -> (* RegexChar *)
        US3_1
    | UH6_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method11(v5)
        let v8 : US3 = method11(v6)
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
    | UH6_4(v16, v17) -> (* RegexCat *)
        let v18 : US3 = method11(v16)
        let v19 : US3 = method11(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH6_5(v25) -> (* RegexStar *)
        US3_0
and method10 (v0 : UH6, v1 : US0, v2 : UH2) : UH7 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH7_0(v1, v2)
    | UH6_1 -> (* RegexEpsilon *)
        UH7_1(v1, v2)
    | UH6_2(v5) -> (* RegexChar *)
        UH7_2(v5, v1, v2)
    | UH6_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH7 = method10(v7, v1, v2)
        let v10 : UH7 = method10(v8, v1, v2)
        UH7_3(v1, v2, v9, v10)
    | UH6_4(v12, v13) -> (* RegexCat *)
        let v14 : US3 = method11(v12)
        let v18 : US2 =
            match v14 with
            | US3_0 -> (* Nullable *)
                US2_0
            | US3_1 -> (* NonNullable *)
                US2_1
        let v19 : UH7 = method10(v12, v1, v2)
        let v20 : UH7 = method10(v13, v1, v2)
        UH7_4(v1, v2, v18, v19, v20)
    | UH6_5(v22) -> (* RegexStar *)
        let v23 : UH7 = method10(v22, v1, v2)
        UH7_5(v1, v2, v23)
and method12 (v0 : UH7) : UH6 =
    match v0 with
    | UH7_0(v1, v2) -> (* RemainderProofEmpty *)
        UH6_0
    | UH7_1(v4, v5) -> (* RemainderProofEpsilon *)
        UH6_1
    | UH7_2(v7, v8, v9) -> (* RemainderProofChar *)
        UH6_2(v7)
    | UH7_3(v11, v12, v13, v14) -> (* RemainderProofAlt *)
        let v15 : UH6 = method12(v13)
        let v16 : UH6 = method12(v14)
        UH6_3(v15, v16)
    | UH7_4(v18, v19, v20, v21, v22) -> (* RemainderProofCat *)
        let v23 : UH6 = method12(v21)
        let v24 : UH6 = method12(v22)
        UH6_4(v23, v24)
    | UH7_5(v26, v27, v28) -> (* RemainderProofStar *)
        let v29 : UH6 = method12(v28)
        UH6_5(v29)
and method13 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH6_1 -> (* RegexEpsilon *)
        match v1 with
        | UH6_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH6_2(v4) -> (* RegexChar *)
        match v1 with
        | UH6_2(v5) -> (* RegexChar *)
            let v15 : US4 =
                match v4 with
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            match v15 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH6_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH6_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method13(v18, v20)
            if v22 then
                method13(v19, v21)
            else
                false
        | _ ->
            false
    | UH6_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH6_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method13(v26, v28)
            if v30 then
                method13(v27, v29)
            else
                false
        | _ ->
            false
    | UH6_5(v34) -> (* RegexStar *)
        match v1 with
        | UH6_5(v35) -> (* RegexStar *)
            method13(v34, v35)
        | _ ->
            false
and method14 (v0 : UH7) : US0 =
    match v0 with
    | UH7_0(v1, v2) -> (* RemainderProofEmpty *)
        v1
    | UH7_1(v3, v4) -> (* RemainderProofEpsilon *)
        v3
    | UH7_2(v5, v6, v7) -> (* RemainderProofChar *)
        v6
    | UH7_3(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v8
    | UH7_4(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v12
    | UH7_5(v17, v18, v19) -> (* RemainderProofStar *)
        v17
and method15 (v0 : UH7) : UH2 =
    match v0 with
    | UH7_0(v1, v2) -> (* RemainderProofEmpty *)
        v2
    | UH7_1(v3, v4) -> (* RemainderProofEpsilon *)
        v4
    | UH7_2(v5, v6, v7) -> (* RemainderProofChar *)
        v7
    | UH7_3(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v9
    | UH7_4(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v13
    | UH7_5(v17, v18, v19) -> (* RemainderProofStar *)
        v18
and method16 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_0 -> (* InputEmpty *)
        match v1 with
        | UH2_0 -> (* InputEmpty *)
            true
        | _ ->
            false
    | UH2_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH2_1(v5, v6) -> (* InputCons *)
            let v16 : US4 =
                match v3 with
                | US0_0 -> (* BitZero *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v5 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            let v17 : bool =
                match v16 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                method16(v4, v6)
            else
                false
        | _ ->
            false
and method21 (v0 : UH6, v1 : UH6) : US4 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            US4_1
        | _ ->
            US4_0
    | UH6_1 -> (* RegexEpsilon *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            US4_2
        | UH6_1 -> (* RegexEpsilon *)
            US4_1
        | _ ->
            US4_0
    | UH6_2(v10) -> (* RegexChar *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            US4_2
        | UH6_1 -> (* RegexEpsilon *)
            US4_2
        | UH6_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_0 -> (* BitZero *)
                match v13 with
                | US0_0 -> (* BitZero *)
                    US4_1
                | US0_1 -> (* BitOne *)
                    US4_0
            | US0_1 -> (* BitOne *)
                match v13 with
                | US0_0 -> (* BitZero *)
                    US4_2
                | US0_1 -> (* BitOne *)
                    US4_1
        | _ ->
            US4_0
    | UH6_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH6_3(v55, v56) -> (* RegexAlt *)
            let v57 : US4 = method21(v53, v55)
            match v57 with
            | US4_1 -> (* SymbolSame *)
                method21(v54, v56)
            | _ ->
                v57
        | _ ->
            US4_2
    | UH6_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            US4_2
        | UH6_1 -> (* RegexEpsilon *)
            US4_2
        | UH6_2(v32) -> (* RegexChar *)
            US4_2
        | UH6_4(v34, v35) -> (* RegexCat *)
            let v36 : US4 = method21(v28, v34)
            match v36 with
            | US4_1 -> (* SymbolSame *)
                method21(v29, v35)
            | _ ->
                v36
        | _ ->
            US4_0
    | UH6_5(v44) -> (* RegexStar *)
        match v1 with
        | UH6_3(v45, v46) -> (* RegexAlt *)
            US4_0
        | UH6_5(v48) -> (* RegexStar *)
            method21(v44, v48)
        | _ ->
            US4_2
and method20 (v0 : UH6, v1 : UH6) : UH6 =
    match v1 with
    | UH6_0 -> (* RegexEmpty *)
        v0
    | UH6_3(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = method21(v0, v2)
        match v4 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH6_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            let v6 : UH6 = method20(v0, v3)
            UH6_3(v2, v6)
    | _ ->
        let v11 : US4 = method21(v0, v1)
        match v11 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH6_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            UH6_3(v1, v0)
and method19 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        v1
    | UH6_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH6 = method20(v2, v1)
        method19(v3, v4)
    | _ ->
        method20(v0, v1)
and method22 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH6_0
    | _ ->
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            UH6_0
        | _ ->
            match v0 with
            | UH6_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH6_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH6_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH6 = method22(v13, v1)
                        UH6_4(v12, v14)
                    | UH6_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH6_5(v5) -> (* RegexStar *)
                            let v6 : bool = method13(v4, v5)
                            if v6 then
                                UH6_5(v4)
                            else
                                UH6_4(v0, v1)
                        | _ ->
                            UH6_4(v0, v1)
                    | _ ->
                        UH6_4(v0, v1)
and method23 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH6_1
    | UH6_1 -> (* RegexEpsilon *)
        UH6_1
    | UH6_5(v3) -> (* RegexStar *)
        UH6_5(v3)
    | _ ->
        UH6_5(v0)
and method18 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH6_0
    | UH6_1 -> (* RegexEpsilon *)
        UH6_1
    | UH6_2(v3) -> (* RegexChar *)
        UH6_2(v3)
    | UH6_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH6 = method18(v5)
        let v8 : UH6 = method18(v6)
        method19(v7, v8)
    | UH6_4(v10, v11) -> (* RegexCat *)
        let v12 : UH6 = method18(v10)
        let v13 : UH6 = method18(v11)
        method22(v12, v13)
    | UH6_5(v15) -> (* RegexStar *)
        let v16 : UH6 = method18(v15)
        method23(v16)
and method24 (v0 : UH6, v1 : US0) : UH6 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH6_0
    | UH6_1 -> (* RegexEpsilon *)
        UH6_0
    | UH6_2(v4) -> (* RegexChar *)
        let v14 : US4 =
            match v4 with
            | US0_0 -> (* BitZero *)
                match v1 with
                | US0_0 -> (* BitZero *)
                    US4_1
                | US0_1 -> (* BitOne *)
                    US4_0
            | US0_1 -> (* BitOne *)
                match v1 with
                | US0_0 -> (* BitZero *)
                    US4_2
                | US0_1 -> (* BitOne *)
                    US4_1
        let v15 : bool =
            match v14 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH6_1
        else
            UH6_0
    | UH6_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH6 = method24(v19, v1)
        let v22 : UH6 = method24(v20, v1)
        method19(v21, v22)
    | UH6_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method11(v24)
        match v26 with
        | US3_0 -> (* Nullable *)
            let v27 : UH6 = method24(v24, v1)
            let v28 : UH6 = method22(v27, v25)
            let v29 : UH6 = method24(v25, v1)
            method19(v28, v29)
        | US3_1 -> (* NonNullable *)
            let v31 : UH6 = method24(v24, v1)
            method22(v31, v25)
    | UH6_5(v35) -> (* RegexStar *)
        let v36 : UH6 = method24(v35, v1)
        let v37 : UH6 = method23(v35)
        method22(v36, v37)
and method17 (v0 : UH6, v1 : US0) : UH6 =
    let v2 : UH6 = method18(v0)
    let v3 : UH6 = method24(v2, v1)
    method18(v3)
and method25 (v0 : UH7) : UH6 =
    match v0 with
    | UH7_0(v1, v2) -> (* RemainderProofEmpty *)
        UH6_0
    | UH7_1(v4, v5) -> (* RemainderProofEpsilon *)
        UH6_0
    | UH7_2(v7, v8, v9) -> (* RemainderProofChar *)
        let v19 : US4 =
            match v7 with
            | US0_0 -> (* BitZero *)
                match v8 with
                | US0_0 -> (* BitZero *)
                    US4_1
                | US0_1 -> (* BitOne *)
                    US4_0
            | US0_1 -> (* BitOne *)
                match v8 with
                | US0_0 -> (* BitZero *)
                    US4_2
                | US0_1 -> (* BitOne *)
                    US4_1
        let v20 : bool =
            match v19 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v20 then
            UH6_1
        else
            UH6_0
    | UH7_3(v24, v25, v26, v27) -> (* RemainderProofAlt *)
        let v28 : UH6 = method25(v26)
        let v29 : UH6 = method25(v27)
        UH6_3(v28, v29)
    | UH7_4(v31, v32, v33, v34, v35) -> (* RemainderProofCat *)
        let v36 : UH6 = method25(v34)
        let v37 : UH6 = method25(v35)
        let v38 : UH6 = method12(v35)
        match v33 with
        | US2_0 -> (* RemainderCatNullable *)
            let v39 : UH6 = UH6_4(v36, v38)
            UH6_3(v39, v37)
        | US2_1 -> (* RemainderCatNonNullable *)
            UH6_4(v36, v38)
    | UH7_5(v44, v45, v46) -> (* RemainderProofStar *)
        let v47 : UH6 = method25(v46)
        let v48 : UH6 = method12(v46)
        let v49 : UH6 = UH6_5(v48)
        UH6_4(v47, v49)
and method28 (v0 : UH6, v1 : UH1) : UH1 =
    match v1 with
    | UH1_0 -> (* InputListNil *)
        UH1_0
    | UH1_1(v3, v4) -> (* InputListCons *)
        let v5 : UH1 = method27(v0, v3)
        let v6 : UH1 = method28(v0, v4)
        method3(v5, v6)
and method31 (v0 : UH2, v1 : UH1) : bool =
    match v1 with
    | UH1_0 -> (* InputListNil *)
        false
    | UH1_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method16(v0, v2)
        if v4 then
            true
        else
            method31(v0, v3)
and method30 (v0 : UH1, v1 : UH1, v2 : UH1) : struct (UH1 * UH1) =
    match v0 with
    | UH1_0 -> (* InputListNil *)
        struct (v1, v2)
    | UH1_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method31(v3, v1)
        if v5 then
            method30(v4, v1, v2)
        else
            let v8 : UH1 = UH1_1(v3, v1)
            let v9 : UH1 = UH1_1(v3, v2)
            method30(v4, v8, v9)
and method29 (v0 : UH6, v1 : UH1, v2 : UH1) : UH1 =
    match v1 with
    | UH1_0 -> (* InputListNil *)
        v2
    | UH1_1(v3, v4) -> (* InputListCons *)
        let v5 : UH1 = method27(v0, v3)
        let struct (v6 : UH1, v7 : UH1) = method30(v5, v2, v4)
        method29(v0, v7, v6)
and method27 (v0 : UH6, v1 : UH2) : UH1 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH1_0
    | UH6_1 -> (* RegexEpsilon *)
        let v3 : UH1 = UH1_0
        UH1_1(v1, v3)
    | UH6_2(v5) -> (* RegexChar *)
        match v1 with
        | UH2_0 -> (* InputEmpty *)
            UH1_0
        | UH2_1(v7, v8) -> (* InputCons *)
            let v18 : US4 =
                match v5 with
                | US0_0 -> (* BitZero *)
                    match v7 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v7 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            let v19 : bool =
                match v18 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH1 = UH1_0
                UH1_1(v8, v20)
            else
                UH1_0
    | UH6_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH1 = method27(v26, v1)
        let v29 : UH1 = method27(v27, v1)
        method3(v28, v29)
    | UH6_4(v31, v32) -> (* RegexCat *)
        let v33 : UH1 = method27(v31, v1)
        method28(v32, v33)
    | UH6_5(v35) -> (* RegexStar *)
        let v36 : UH1 = UH1_0
        let v37 : UH1 = UH1_1(v1, v36)
        let v38 : UH1 = UH1_0
        let v39 : UH1 = UH1_1(v1, v38)
        method29(v35, v37, v39)
and method32 (v0 : UH2, v1 : UH1) : UH1 =
    match v1 with
    | UH1_0 -> (* InputListNil *)
        UH1_0
    | UH1_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method16(v0, v3)
        if v5 then
            method32(v0, v4)
        else
            let v7 : UH1 = method32(v0, v4)
            UH1_1(v3, v7)
and method33 (v0 : UH1, v1 : UH1) : bool =
    match v0 with
    | UH1_0 -> (* InputListNil *)
        true
    | UH1_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method31(v2, v1)
        if v4 then
            method33(v3, v1)
        else
            false
and method26 (v0 : UH7) : bool =
    let v1 : UH6 = method12(v0)
    let v2 : US0 = method14(v0)
    let v3 : UH2 = method15(v0)
    let v4 : UH6 = method25(v0)
    let v5 : UH2 = UH2_1(v2, v3)
    let v6 : UH2 = UH2_1(v2, v3)
    let v7 : UH1 = method27(v1, v6)
    let v8 : UH1 = method32(v5, v7)
    let v9 : UH1 = method27(v4, v3)
    let v10 : bool = method33(v8, v9)
    let v12 : bool =
        if v10 then
            method33(v9, v8)
        else
            false
    if v12 then
        match v0 with
        | UH7_0(v13, v14) -> (* RemainderProofEmpty *)
            true
        | UH7_1(v15, v16) -> (* RemainderProofEpsilon *)
            true
        | UH7_2(v17, v18, v19) -> (* RemainderProofChar *)
            true
        | UH7_3(v20, v21, v22, v23) -> (* RemainderProofAlt *)
            let v24 : US0 = method14(v0)
            let v25 : US0 = method14(v22)
            let v35 : US4 =
                match v24 with
                | US0_0 -> (* BitZero *)
                    match v25 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v25 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            let v36 : bool =
                match v35 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v40 : bool =
                if v36 then
                    let v37 : UH2 = method15(v0)
                    let v38 : UH2 = method15(v22)
                    method16(v37, v38)
                else
                    false
            if v40 then
                let v41 : US0 = method14(v0)
                let v42 : US0 = method14(v23)
                let v52 : US4 =
                    match v41 with
                    | US0_0 -> (* BitZero *)
                        match v42 with
                        | US0_0 -> (* BitZero *)
                            US4_1
                        | US0_1 -> (* BitOne *)
                            US4_0
                    | US0_1 -> (* BitOne *)
                        match v42 with
                        | US0_0 -> (* BitZero *)
                            US4_2
                        | US0_1 -> (* BitOne *)
                            US4_1
                let v53 : bool =
                    match v52 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v57 : bool =
                    if v53 then
                        let v54 : UH2 = method15(v0)
                        let v55 : UH2 = method15(v23)
                        method16(v54, v55)
                    else
                        false
                if v57 then
                    let v58 : bool = method26(v22)
                    if v58 then
                        method26(v23)
                    else
                        false
                else
                    false
            else
                false
        | UH7_4(v63, v64, v65, v66, v67) -> (* RemainderProofCat *)
            let v68 : UH6 = method12(v66)
            let v69 : US3 = method11(v68)
            let v73 : US2 =
                match v69 with
                | US3_0 -> (* Nullable *)
                    US2_0
                | US3_1 -> (* NonNullable *)
                    US2_1
            let v77 : bool =
                match v65 with
                | US2_0 -> (* RemainderCatNullable *)
                    match v73 with
                    | US2_0 -> (* RemainderCatNullable *)
                        true
                    | _ ->
                        false
                | US2_1 -> (* RemainderCatNonNullable *)
                    match v73 with
                    | US2_1 -> (* RemainderCatNonNullable *)
                        true
                    | _ ->
                        false
            if v77 then
                let v78 : US0 = method14(v0)
                let v79 : US0 = method14(v66)
                let v89 : US4 =
                    match v78 with
                    | US0_0 -> (* BitZero *)
                        match v79 with
                        | US0_0 -> (* BitZero *)
                            US4_1
                        | US0_1 -> (* BitOne *)
                            US4_0
                    | US0_1 -> (* BitOne *)
                        match v79 with
                        | US0_0 -> (* BitZero *)
                            US4_2
                        | US0_1 -> (* BitOne *)
                            US4_1
                let v90 : bool =
                    match v89 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v94 : bool =
                    if v90 then
                        let v91 : UH2 = method15(v0)
                        let v92 : UH2 = method15(v66)
                        method16(v91, v92)
                    else
                        false
                if v94 then
                    let v95 : US0 = method14(v0)
                    let v96 : US0 = method14(v67)
                    let v106 : US4 =
                        match v95 with
                        | US0_0 -> (* BitZero *)
                            match v96 with
                            | US0_0 -> (* BitZero *)
                                US4_1
                            | US0_1 -> (* BitOne *)
                                US4_0
                        | US0_1 -> (* BitOne *)
                            match v96 with
                            | US0_0 -> (* BitZero *)
                                US4_2
                            | US0_1 -> (* BitOne *)
                                US4_1
                    let v107 : bool =
                        match v106 with
                        | US4_1 -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    let v111 : bool =
                        if v107 then
                            let v108 : UH2 = method15(v0)
                            let v109 : UH2 = method15(v67)
                            method16(v108, v109)
                        else
                            false
                    if v111 then
                        let v112 : bool = method26(v66)
                        if v112 then
                            method26(v67)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        | UH7_5(v118, v119, v120) -> (* RemainderProofStar *)
            let v121 : US0 = method14(v0)
            let v122 : US0 = method14(v120)
            let v132 : US4 =
                match v121 with
                | US0_0 -> (* BitZero *)
                    match v122 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v122 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            let v133 : bool =
                match v132 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v137 : bool =
                if v133 then
                    let v134 : UH2 = method15(v0)
                    let v135 : UH2 = method15(v120)
                    method16(v134, v135)
                else
                    false
            if v137 then
                method26(v120)
            else
                false
    else
        false
and method9 (v0 : UH6, v1 : US0, v2 : UH1) : bool =
    match v2 with
    | UH1_0 -> (* InputListNil *)
        true
    | UH1_1(v3, v4) -> (* InputListCons *)
        let v5 : UH7 = method10(v0, v1, v3)
        let v6 : UH6 = method12(v5)
        let v7 : bool = method13(v0, v6)
        let v30 : bool =
            if v7 then
                let v8 : US0 = method14(v5)
                let v18 : US4 =
                    match v1 with
                    | US0_0 -> (* BitZero *)
                        match v8 with
                        | US0_0 -> (* BitZero *)
                            US4_1
                        | US0_1 -> (* BitOne *)
                            US4_0
                    | US0_1 -> (* BitOne *)
                        match v8 with
                        | US0_0 -> (* BitZero *)
                            US4_2
                        | US0_1 -> (* BitOne *)
                            US4_1
                let v19 : bool =
                    match v18 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v19 then
                    let v20 : UH2 = method15(v5)
                    let v21 : bool = method16(v3, v20)
                    if v21 then
                        let v22 : UH6 = method17(v0, v1)
                        let v23 : UH6 = method25(v5)
                        let v24 : UH6 = method18(v23)
                        let v25 : bool = method13(v22, v24)
                        if v25 then
                            method26(v5)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v30 then
            method9(v0, v1, v4)
        else
            false
and method8 (v0 : UH6, v1 : UH0, v2 : UH1) : bool =
    match v1 with
    | UH0_0 -> (* SymbolListNil *)
        true
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = method9(v0, v3, v2)
        if v5 then
            method8(v0, v4, v2)
        else
            false
and method37 (v0 : UH8) : US3 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        US3_1
    | UH8_1 -> (* RegexEpsilon *)
        US3_0
    | UH8_2(v3) -> (* RegexChar *)
        US3_1
    | UH8_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method37(v5)
        let v8 : US3 = method37(v6)
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
        let v18 : US3 = method37(v16)
        let v19 : US3 = method37(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH8_5(v25) -> (* RegexStar *)
        US3_0
and method36 (v0 : UH8, v1 : US1, v2 : UH5) : UH9 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH9_0(v1, v2)
    | UH8_1 -> (* RegexEpsilon *)
        UH9_1(v1, v2)
    | UH8_2(v5) -> (* RegexChar *)
        UH9_2(v5, v1, v2)
    | UH8_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH9 = method36(v7, v1, v2)
        let v10 : UH9 = method36(v8, v1, v2)
        UH9_3(v1, v2, v9, v10)
    | UH8_4(v12, v13) -> (* RegexCat *)
        let v14 : US3 = method37(v12)
        let v18 : US2 =
            match v14 with
            | US3_0 -> (* Nullable *)
                US2_0
            | US3_1 -> (* NonNullable *)
                US2_1
        let v19 : UH9 = method36(v12, v1, v2)
        let v20 : UH9 = method36(v13, v1, v2)
        UH9_4(v1, v2, v18, v19, v20)
    | UH8_5(v22) -> (* RegexStar *)
        let v23 : UH9 = method36(v22, v1, v2)
        UH9_5(v1, v2, v23)
and method38 (v0 : UH9) : UH8 =
    match v0 with
    | UH9_0(v1, v2) -> (* RemainderProofEmpty *)
        UH8_0
    | UH9_1(v4, v5) -> (* RemainderProofEpsilon *)
        UH8_1
    | UH9_2(v7, v8, v9) -> (* RemainderProofChar *)
        UH8_2(v7)
    | UH9_3(v11, v12, v13, v14) -> (* RemainderProofAlt *)
        let v15 : UH8 = method38(v13)
        let v16 : UH8 = method38(v14)
        UH8_3(v15, v16)
    | UH9_4(v18, v19, v20, v21, v22) -> (* RemainderProofCat *)
        let v23 : UH8 = method38(v21)
        let v24 : UH8 = method38(v22)
        UH8_4(v23, v24)
    | UH9_5(v26, v27, v28) -> (* RemainderProofStar *)
        let v29 : UH8 = method38(v28)
        UH8_5(v29)
and method39 (v0 : UH8, v1 : UH8) : bool =
    match v0 with
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
    | UH8_2(v4) -> (* RegexChar *)
        match v1 with
        | UH8_2(v5) -> (* RegexChar *)
            let v21 : US4 =
                match v4 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v4 with
                        | US1_1 -> (* TriB *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US4_1
                            | US1_2 -> (* TriC *)
                                US4_0
                        | US1_2 -> (* TriC *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US4_2
                            | US1_2 -> (* TriC *)
                                US4_1
            match v21 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
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
    | UH8_5(v40) -> (* RegexStar *)
        match v1 with
        | UH8_5(v41) -> (* RegexStar *)
            method39(v40, v41)
        | _ ->
            false
and method40 (v0 : UH9) : US1 =
    match v0 with
    | UH9_0(v1, v2) -> (* RemainderProofEmpty *)
        v1
    | UH9_1(v3, v4) -> (* RemainderProofEpsilon *)
        v3
    | UH9_2(v5, v6, v7) -> (* RemainderProofChar *)
        v6
    | UH9_3(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v8
    | UH9_4(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v12
    | UH9_5(v17, v18, v19) -> (* RemainderProofStar *)
        v17
and method41 (v0 : UH9) : UH5 =
    match v0 with
    | UH9_0(v1, v2) -> (* RemainderProofEmpty *)
        v2
    | UH9_1(v3, v4) -> (* RemainderProofEpsilon *)
        v4
    | UH9_2(v5, v6, v7) -> (* RemainderProofChar *)
        v7
    | UH9_3(v8, v9, v10, v11) -> (* RemainderProofAlt *)
        v9
    | UH9_4(v12, v13, v14, v15, v16) -> (* RemainderProofCat *)
        v13
    | UH9_5(v17, v18, v19) -> (* RemainderProofStar *)
        v18
and method42 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_0 -> (* InputEmpty *)
        match v1 with
        | UH5_0 -> (* InputEmpty *)
            true
        | _ ->
            false
    | UH5_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH5_1(v5, v6) -> (* InputCons *)
            let v22 : US4 =
                match v3 with
                | US1_0 -> (* TriA *)
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v5 with
                    | US1_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v3 with
                        | US1_1 -> (* TriB *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US4_1
                            | US1_2 -> (* TriC *)
                                US4_0
                        | US1_2 -> (* TriC *)
                            match v5 with
                            | US1_1 -> (* TriB *)
                                US4_2
                            | US1_2 -> (* TriC *)
                                US4_1
            let v23 : bool =
                match v22 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                method42(v4, v6)
            else
                false
        | _ ->
            false
and method47 (v0 : UH8, v1 : UH8) : US4 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            US4_1
        | _ ->
            US4_0
    | UH8_1 -> (* RegexEpsilon *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            US4_2
        | UH8_1 -> (* RegexEpsilon *)
            US4_1
        | _ ->
            US4_0
    | UH8_2(v10) -> (* RegexChar *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            US4_2
        | UH8_1 -> (* RegexEpsilon *)
            US4_2
        | UH8_2(v13) -> (* RegexChar *)
            match v10 with
            | US1_0 -> (* TriA *)
                match v13 with
                | US1_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v13 with
                | US1_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v10 with
                    | US1_1 -> (* TriB *)
                        match v13 with
                        | US1_1 -> (* TriB *)
                            US4_1
                        | US1_2 -> (* TriC *)
                            US4_0
                    | US1_2 -> (* TriC *)
                        match v13 with
                        | US1_1 -> (* TriB *)
                            US4_2
                        | US1_2 -> (* TriC *)
                            US4_1
        | _ ->
            US4_0
    | UH8_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH8_3(v61, v62) -> (* RegexAlt *)
            let v63 : US4 = method47(v59, v61)
            match v63 with
            | US4_1 -> (* SymbolSame *)
                method47(v60, v62)
            | _ ->
                v63
        | _ ->
            US4_2
    | UH8_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH8_0 -> (* RegexEmpty *)
            US4_2
        | UH8_1 -> (* RegexEpsilon *)
            US4_2
        | UH8_2(v38) -> (* RegexChar *)
            US4_2
        | UH8_4(v40, v41) -> (* RegexCat *)
            let v42 : US4 = method47(v34, v40)
            match v42 with
            | US4_1 -> (* SymbolSame *)
                method47(v35, v41)
            | _ ->
                v42
        | _ ->
            US4_0
    | UH8_5(v50) -> (* RegexStar *)
        match v1 with
        | UH8_3(v51, v52) -> (* RegexAlt *)
            US4_0
        | UH8_5(v54) -> (* RegexStar *)
            method47(v50, v54)
        | _ ->
            US4_2
and method46 (v0 : UH8, v1 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* RegexEmpty *)
        v0
    | UH8_3(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = method47(v0, v2)
        match v4 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH8_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            let v6 : UH8 = method46(v0, v3)
            UH8_3(v2, v6)
    | _ ->
        let v11 : US4 = method47(v0, v1)
        match v11 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH8_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            UH8_3(v1, v0)
and method45 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        v1
    | UH8_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH8 = method46(v2, v1)
        method45(v3, v4)
    | _ ->
        method46(v0, v1)
and method48 (v0 : UH8, v1 : UH8) : UH8 =
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
                        let v14 : UH8 = method48(v13, v1)
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
and method49 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH8_1
    | UH8_1 -> (* RegexEpsilon *)
        UH8_1
    | UH8_5(v3) -> (* RegexStar *)
        UH8_5(v3)
    | _ ->
        UH8_5(v0)
and method44 (v0 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH8_0
    | UH8_1 -> (* RegexEpsilon *)
        UH8_1
    | UH8_2(v3) -> (* RegexChar *)
        UH8_2(v3)
    | UH8_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH8 = method44(v5)
        let v8 : UH8 = method44(v6)
        method45(v7, v8)
    | UH8_4(v10, v11) -> (* RegexCat *)
        let v12 : UH8 = method44(v10)
        let v13 : UH8 = method44(v11)
        method48(v12, v13)
    | UH8_5(v15) -> (* RegexStar *)
        let v16 : UH8 = method44(v15)
        method49(v16)
and method50 (v0 : UH8, v1 : US1) : UH8 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH8_0
    | UH8_1 -> (* RegexEpsilon *)
        UH8_0
    | UH8_2(v4) -> (* RegexChar *)
        let v20 : US4 =
            match v4 with
            | US1_0 -> (* TriA *)
                match v1 with
                | US1_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v1 with
                | US1_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v4 with
                    | US1_1 -> (* TriB *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US4_1
                        | US1_2 -> (* TriC *)
                            US4_0
                    | US1_2 -> (* TriC *)
                        match v1 with
                        | US1_1 -> (* TriB *)
                            US4_2
                        | US1_2 -> (* TriC *)
                            US4_1
        let v21 : bool =
            match v20 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH8_1
        else
            UH8_0
    | UH8_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH8 = method50(v25, v1)
        let v28 : UH8 = method50(v26, v1)
        method45(v27, v28)
    | UH8_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method37(v30)
        match v32 with
        | US3_0 -> (* Nullable *)
            let v33 : UH8 = method50(v30, v1)
            let v34 : UH8 = method48(v33, v31)
            let v35 : UH8 = method50(v31, v1)
            method45(v34, v35)
        | US3_1 -> (* NonNullable *)
            let v37 : UH8 = method50(v30, v1)
            method48(v37, v31)
    | UH8_5(v41) -> (* RegexStar *)
        let v42 : UH8 = method50(v41, v1)
        let v43 : UH8 = method49(v41)
        method48(v42, v43)
and method43 (v0 : UH8, v1 : US1) : UH8 =
    let v2 : UH8 = method44(v0)
    let v3 : UH8 = method50(v2, v1)
    method44(v3)
and method51 (v0 : UH9) : UH8 =
    match v0 with
    | UH9_0(v1, v2) -> (* RemainderProofEmpty *)
        UH8_0
    | UH9_1(v4, v5) -> (* RemainderProofEpsilon *)
        UH8_0
    | UH9_2(v7, v8, v9) -> (* RemainderProofChar *)
        let v25 : US4 =
            match v7 with
            | US1_0 -> (* TriA *)
                match v8 with
                | US1_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v8 with
                | US1_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v7 with
                    | US1_1 -> (* TriB *)
                        match v8 with
                        | US1_1 -> (* TriB *)
                            US4_1
                        | US1_2 -> (* TriC *)
                            US4_0
                    | US1_2 -> (* TriC *)
                        match v8 with
                        | US1_1 -> (* TriB *)
                            US4_2
                        | US1_2 -> (* TriC *)
                            US4_1
        let v26 : bool =
            match v25 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v26 then
            UH8_1
        else
            UH8_0
    | UH9_3(v30, v31, v32, v33) -> (* RemainderProofAlt *)
        let v34 : UH8 = method51(v32)
        let v35 : UH8 = method51(v33)
        UH8_3(v34, v35)
    | UH9_4(v37, v38, v39, v40, v41) -> (* RemainderProofCat *)
        let v42 : UH8 = method51(v40)
        let v43 : UH8 = method51(v41)
        let v44 : UH8 = method38(v41)
        match v39 with
        | US2_0 -> (* RemainderCatNullable *)
            let v45 : UH8 = UH8_4(v42, v44)
            UH8_3(v45, v43)
        | US2_1 -> (* RemainderCatNonNullable *)
            UH8_4(v42, v44)
    | UH9_5(v50, v51, v52) -> (* RemainderProofStar *)
        let v53 : UH8 = method51(v52)
        let v54 : UH8 = method38(v52)
        let v55 : UH8 = UH8_5(v54)
        UH8_4(v53, v55)
and method54 (v0 : UH8, v1 : UH4) : UH4 =
    match v1 with
    | UH4_0 -> (* InputListNil *)
        UH4_0
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = method53(v0, v3)
        let v6 : UH4 = method54(v0, v4)
        method7(v5, v6)
and method57 (v0 : UH5, v1 : UH4) : bool =
    match v1 with
    | UH4_0 -> (* InputListNil *)
        false
    | UH4_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method42(v0, v2)
        if v4 then
            true
        else
            method57(v0, v3)
and method56 (v0 : UH4, v1 : UH4, v2 : UH4) : struct (UH4 * UH4) =
    match v0 with
    | UH4_0 -> (* InputListNil *)
        struct (v1, v2)
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method57(v3, v1)
        if v5 then
            method56(v4, v1, v2)
        else
            let v8 : UH4 = UH4_1(v3, v1)
            let v9 : UH4 = UH4_1(v3, v2)
            method56(v4, v8, v9)
and method55 (v0 : UH8, v1 : UH4, v2 : UH4) : UH4 =
    match v1 with
    | UH4_0 -> (* InputListNil *)
        v2
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : UH4 = method53(v0, v3)
        let struct (v6 : UH4, v7 : UH4) = method56(v5, v2, v4)
        method55(v0, v7, v6)
and method53 (v0 : UH8, v1 : UH5) : UH4 =
    match v0 with
    | UH8_0 -> (* RegexEmpty *)
        UH4_0
    | UH8_1 -> (* RegexEpsilon *)
        let v3 : UH4 = UH4_0
        UH4_1(v1, v3)
    | UH8_2(v5) -> (* RegexChar *)
        match v1 with
        | UH5_0 -> (* InputEmpty *)
            UH4_0
        | UH5_1(v7, v8) -> (* InputCons *)
            let v24 : US4 =
                match v5 with
                | US1_0 -> (* TriA *)
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v5 with
                        | US1_1 -> (* TriB *)
                            match v7 with
                            | US1_1 -> (* TriB *)
                                US4_1
                            | US1_2 -> (* TriC *)
                                US4_0
                        | US1_2 -> (* TriC *)
                            match v7 with
                            | US1_1 -> (* TriB *)
                                US4_2
                            | US1_2 -> (* TriC *)
                                US4_1
            let v25 : bool =
                match v24 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH4 = UH4_0
                UH4_1(v8, v26)
            else
                UH4_0
    | UH8_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH4 = method53(v32, v1)
        let v35 : UH4 = method53(v33, v1)
        method7(v34, v35)
    | UH8_4(v37, v38) -> (* RegexCat *)
        let v39 : UH4 = method53(v37, v1)
        method54(v38, v39)
    | UH8_5(v41) -> (* RegexStar *)
        let v42 : UH4 = UH4_0
        let v43 : UH4 = UH4_1(v1, v42)
        let v44 : UH4 = UH4_0
        let v45 : UH4 = UH4_1(v1, v44)
        method55(v41, v43, v45)
and method58 (v0 : UH5, v1 : UH4) : UH4 =
    match v1 with
    | UH4_0 -> (* InputListNil *)
        UH4_0
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method42(v0, v3)
        if v5 then
            method58(v0, v4)
        else
            let v7 : UH4 = method58(v0, v4)
            UH4_1(v3, v7)
and method59 (v0 : UH4, v1 : UH4) : bool =
    match v0 with
    | UH4_0 -> (* InputListNil *)
        true
    | UH4_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method57(v2, v1)
        if v4 then
            method59(v3, v1)
        else
            false
and method52 (v0 : UH9) : bool =
    let v1 : UH8 = method38(v0)
    let v2 : US1 = method40(v0)
    let v3 : UH5 = method41(v0)
    let v4 : UH8 = method51(v0)
    let v5 : UH5 = UH5_1(v2, v3)
    let v6 : UH5 = UH5_1(v2, v3)
    let v7 : UH4 = method53(v1, v6)
    let v8 : UH4 = method58(v5, v7)
    let v9 : UH4 = method53(v4, v3)
    let v10 : bool = method59(v8, v9)
    let v12 : bool =
        if v10 then
            method59(v9, v8)
        else
            false
    if v12 then
        match v0 with
        | UH9_0(v13, v14) -> (* RemainderProofEmpty *)
            true
        | UH9_1(v15, v16) -> (* RemainderProofEpsilon *)
            true
        | UH9_2(v17, v18, v19) -> (* RemainderProofChar *)
            true
        | UH9_3(v20, v21, v22, v23) -> (* RemainderProofAlt *)
            let v24 : US1 = method40(v0)
            let v25 : US1 = method40(v22)
            let v41 : US4 =
                match v24 with
                | US1_0 -> (* TriA *)
                    match v25 with
                    | US1_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v25 with
                    | US1_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v24 with
                        | US1_1 -> (* TriB *)
                            match v25 with
                            | US1_1 -> (* TriB *)
                                US4_1
                            | US1_2 -> (* TriC *)
                                US4_0
                        | US1_2 -> (* TriC *)
                            match v25 with
                            | US1_1 -> (* TriB *)
                                US4_2
                            | US1_2 -> (* TriC *)
                                US4_1
            let v42 : bool =
                match v41 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v46 : bool =
                if v42 then
                    let v43 : UH5 = method41(v0)
                    let v44 : UH5 = method41(v22)
                    method42(v43, v44)
                else
                    false
            if v46 then
                let v47 : US1 = method40(v0)
                let v48 : US1 = method40(v23)
                let v64 : US4 =
                    match v47 with
                    | US1_0 -> (* TriA *)
                        match v48 with
                        | US1_0 -> (* TriA *)
                            US4_1
                        | _ ->
                            US4_0
                    | _ ->
                        match v48 with
                        | US1_0 -> (* TriA *)
                            US4_2
                        | _ ->
                            match v47 with
                            | US1_1 -> (* TriB *)
                                match v48 with
                                | US1_1 -> (* TriB *)
                                    US4_1
                                | US1_2 -> (* TriC *)
                                    US4_0
                            | US1_2 -> (* TriC *)
                                match v48 with
                                | US1_1 -> (* TriB *)
                                    US4_2
                                | US1_2 -> (* TriC *)
                                    US4_1
                let v65 : bool =
                    match v64 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v69 : bool =
                    if v65 then
                        let v66 : UH5 = method41(v0)
                        let v67 : UH5 = method41(v23)
                        method42(v66, v67)
                    else
                        false
                if v69 then
                    let v70 : bool = method52(v22)
                    if v70 then
                        method52(v23)
                    else
                        false
                else
                    false
            else
                false
        | UH9_4(v75, v76, v77, v78, v79) -> (* RemainderProofCat *)
            let v80 : UH8 = method38(v78)
            let v81 : US3 = method37(v80)
            let v85 : US2 =
                match v81 with
                | US3_0 -> (* Nullable *)
                    US2_0
                | US3_1 -> (* NonNullable *)
                    US2_1
            let v89 : bool =
                match v77 with
                | US2_0 -> (* RemainderCatNullable *)
                    match v85 with
                    | US2_0 -> (* RemainderCatNullable *)
                        true
                    | _ ->
                        false
                | US2_1 -> (* RemainderCatNonNullable *)
                    match v85 with
                    | US2_1 -> (* RemainderCatNonNullable *)
                        true
                    | _ ->
                        false
            if v89 then
                let v90 : US1 = method40(v0)
                let v91 : US1 = method40(v78)
                let v107 : US4 =
                    match v90 with
                    | US1_0 -> (* TriA *)
                        match v91 with
                        | US1_0 -> (* TriA *)
                            US4_1
                        | _ ->
                            US4_0
                    | _ ->
                        match v91 with
                        | US1_0 -> (* TriA *)
                            US4_2
                        | _ ->
                            match v90 with
                            | US1_1 -> (* TriB *)
                                match v91 with
                                | US1_1 -> (* TriB *)
                                    US4_1
                                | US1_2 -> (* TriC *)
                                    US4_0
                            | US1_2 -> (* TriC *)
                                match v91 with
                                | US1_1 -> (* TriB *)
                                    US4_2
                                | US1_2 -> (* TriC *)
                                    US4_1
                let v108 : bool =
                    match v107 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                let v112 : bool =
                    if v108 then
                        let v109 : UH5 = method41(v0)
                        let v110 : UH5 = method41(v78)
                        method42(v109, v110)
                    else
                        false
                if v112 then
                    let v113 : US1 = method40(v0)
                    let v114 : US1 = method40(v79)
                    let v130 : US4 =
                        match v113 with
                        | US1_0 -> (* TriA *)
                            match v114 with
                            | US1_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v114 with
                            | US1_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v113 with
                                | US1_1 -> (* TriB *)
                                    match v114 with
                                    | US1_1 -> (* TriB *)
                                        US4_1
                                    | US1_2 -> (* TriC *)
                                        US4_0
                                | US1_2 -> (* TriC *)
                                    match v114 with
                                    | US1_1 -> (* TriB *)
                                        US4_2
                                    | US1_2 -> (* TriC *)
                                        US4_1
                    let v131 : bool =
                        match v130 with
                        | US4_1 -> (* SymbolSame *)
                            true
                        | _ ->
                            false
                    let v135 : bool =
                        if v131 then
                            let v132 : UH5 = method41(v0)
                            let v133 : UH5 = method41(v79)
                            method42(v132, v133)
                        else
                            false
                    if v135 then
                        let v136 : bool = method52(v78)
                        if v136 then
                            method52(v79)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        | UH9_5(v142, v143, v144) -> (* RemainderProofStar *)
            let v145 : US1 = method40(v0)
            let v146 : US1 = method40(v144)
            let v162 : US4 =
                match v145 with
                | US1_0 -> (* TriA *)
                    match v146 with
                    | US1_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v146 with
                    | US1_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v145 with
                        | US1_1 -> (* TriB *)
                            match v146 with
                            | US1_1 -> (* TriB *)
                                US4_1
                            | US1_2 -> (* TriC *)
                                US4_0
                        | US1_2 -> (* TriC *)
                            match v146 with
                            | US1_1 -> (* TriB *)
                                US4_2
                            | US1_2 -> (* TriC *)
                                US4_1
            let v163 : bool =
                match v162 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v167 : bool =
                if v163 then
                    let v164 : UH5 = method41(v0)
                    let v165 : UH5 = method41(v144)
                    method42(v164, v165)
                else
                    false
            if v167 then
                method52(v144)
            else
                false
    else
        false
and method35 (v0 : UH8, v1 : US1, v2 : UH4) : bool =
    match v2 with
    | UH4_0 -> (* InputListNil *)
        true
    | UH4_1(v3, v4) -> (* InputListCons *)
        let v5 : UH9 = method36(v0, v1, v3)
        let v6 : UH8 = method38(v5)
        let v7 : bool = method39(v0, v6)
        let v36 : bool =
            if v7 then
                let v8 : US1 = method40(v5)
                let v24 : US4 =
                    match v1 with
                    | US1_0 -> (* TriA *)
                        match v8 with
                        | US1_0 -> (* TriA *)
                            US4_1
                        | _ ->
                            US4_0
                    | _ ->
                        match v8 with
                        | US1_0 -> (* TriA *)
                            US4_2
                        | _ ->
                            match v1 with
                            | US1_1 -> (* TriB *)
                                match v8 with
                                | US1_1 -> (* TriB *)
                                    US4_1
                                | US1_2 -> (* TriC *)
                                    US4_0
                            | US1_2 -> (* TriC *)
                                match v8 with
                                | US1_1 -> (* TriB *)
                                    US4_2
                                | US1_2 -> (* TriC *)
                                    US4_1
                let v25 : bool =
                    match v24 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v25 then
                    let v26 : UH5 = method41(v5)
                    let v27 : bool = method42(v3, v26)
                    if v27 then
                        let v28 : UH8 = method43(v0, v1)
                        let v29 : UH8 = method51(v5)
                        let v30 : UH8 = method44(v29)
                        let v31 : bool = method39(v28, v30)
                        if v31 then
                            method52(v5)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v36 then
            method35(v0, v1, v4)
        else
            false
and method34 (v0 : UH8, v1 : UH3, v2 : UH4) : bool =
    match v1 with
    | UH3_0 -> (* SymbolListNil *)
        true
    | UH3_1(v3, v4) -> (* SymbolListCons *)
        let v5 : bool = method35(v0, v3, v2)
        if v5 then
            method34(v0, v4, v2)
        else
            false
let v0 : UH0 = UH0_0
let v1 : US0 = US0_1
let v2 : UH0 = UH0_1(v1, v0)
let v3 : US0 = US0_0
let v4 : UH0 = UH0_1(v3, v2)
let v5 : UH1 = method0(v4)
let v6 : UH2 = UH2_0
let v7 : UH1 = UH1_1(v6, v5)
let v8 : UH0 = UH0_0
let v9 : US0 = US0_1
let v10 : UH0 = UH0_1(v9, v8)
let v11 : US0 = US0_0
let v12 : UH0 = UH0_1(v11, v10)
let v13 : UH0 = UH0_0
let v14 : US0 = US0_1
let v15 : UH0 = UH0_1(v14, v13)
let v16 : US0 = US0_0
let v17 : UH0 = UH0_1(v16, v15)
let v18 : UH1 = method0(v17)
let v19 : UH1 = method1(v12, v18)
let v20 : UH1 = method3(v7, v19)
let v21 : UH3 = UH3_0
let v22 : US1 = US1_2
let v23 : UH3 = UH3_1(v22, v21)
let v24 : US1 = US1_1
let v25 : UH3 = UH3_1(v24, v23)
let v26 : US1 = US1_0
let v27 : UH3 = UH3_1(v26, v25)
let v28 : UH4 = method4(v27)
let v29 : UH5 = UH5_0
let v30 : UH4 = UH4_1(v29, v28)
let v31 : UH3 = UH3_0
let v32 : US1 = US1_2
let v33 : UH3 = UH3_1(v32, v31)
let v34 : US1 = US1_1
let v35 : UH3 = UH3_1(v34, v33)
let v36 : US1 = US1_0
let v37 : UH3 = UH3_1(v36, v35)
let v38 : UH3 = UH3_0
let v39 : US1 = US1_2
let v40 : UH3 = UH3_1(v39, v38)
let v41 : US1 = US1_1
let v42 : UH3 = UH3_1(v41, v40)
let v43 : US1 = US1_0
let v44 : UH3 = UH3_1(v43, v42)
let v45 : UH4 = method4(v44)
let v46 : UH4 = method5(v37, v45)
let v47 : UH4 = method7(v30, v46)
let v48 : US0 = US0_0
let v49 : UH6 = UH6_2(v48)
let v50 : US0 = US0_1
let v51 : UH6 = UH6_2(v50)
let v52 : US0 = US0_0
let v53 : UH6 = UH6_2(v52)
let v54 : UH6 = UH6_3(v53, v51)
let v55 : UH6 = UH6_5(v54)
let v56 : UH6 = UH6_4(v55, v49)
let v57 : UH6 = UH6_1
let v58 : UH6 = UH6_3(v57, v56)
let v59 : UH6 = UH6_0
let v60 : UH6 = UH6_3(v59, v58)
let v61 : UH0 = UH0_0
let v62 : US0 = US0_1
let v63 : UH0 = UH0_1(v62, v61)
let v64 : US0 = US0_0
let v65 : UH0 = UH0_1(v64, v63)
let v66 : bool = method8(v60, v65, v20)
if v66 then
    ()
else
    let v67 : string = "structural remainder theorem certificate should cover every regex constructor"
    failwith v67
    ()
let v68 : US1 = US1_2
let v69 : UH8 = UH8_2(v68)
let v70 : US1 = US1_1
let v71 : UH8 = UH8_2(v70)
let v72 : US1 = US1_0
let v73 : UH8 = UH8_2(v72)
let v74 : UH8 = UH8_3(v73, v71)
let v75 : UH8 = UH8_5(v74)
let v76 : UH8 = UH8_4(v75, v69)
let v77 : UH3 = UH3_0
let v78 : US1 = US1_2
let v79 : UH3 = UH3_1(v78, v77)
let v80 : US1 = US1_1
let v81 : UH3 = UH3_1(v80, v79)
let v82 : US1 = US1_0
let v83 : UH3 = UH3_1(v82, v81)
let v84 : bool = method34(v76, v83, v47)
if v84 then
    ()
else
    let v85 : string = "structural remainder theorem certificate should generalize across nominal alphabets"
    failwith v85
    ()
let v86 : US0 = US0_0
let v87 : UH6 = UH6_2(v86)
let v88 : US0 = US0_1
let v89 : UH6 = UH6_2(v88)
let v90 : US0 = US0_0
let v91 : UH6 = UH6_2(v90)
let v92 : UH6 = UH6_3(v91, v89)
let v93 : UH6 = UH6_5(v92)
let v94 : UH6 = UH6_4(v93, v87)
let v95 : US0 = US0_1
let v96 : UH2 = UH2_0
let v97 : US0 = US0_0
let v98 : UH2 = UH2_1(v97, v96)
let v99 : US0 = US0_1
let v100 : UH2 = UH2_1(v99, v98)
let v101 : UH7 = method10(v94, v95, v100)
let v102 : US0 = US0_0
let v103 : UH6 = UH6_2(v102)
let v104 : US0 = US0_1
let v105 : UH6 = UH6_2(v104)
let v106 : US0 = US0_0
let v107 : UH6 = UH6_2(v106)
let v108 : UH6 = UH6_3(v107, v105)
let v109 : UH6 = UH6_5(v108)
let v110 : UH6 = UH6_4(v109, v103)
let v111 : UH6 = method12(v101)
let v112 : bool = method13(v110, v111)
let v144 : bool =
    if v112 then
        let v113 : US0 = method14(v101)
        let v117 : US4 =
            match v113 with
            | US0_0 -> (* BitZero *)
                US4_2
            | US0_1 -> (* BitOne *)
                US4_1
        let v118 : bool =
            match v117 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v118 then
            let v119 : UH2 = UH2_0
            let v120 : US0 = US0_0
            let v121 : UH2 = UH2_1(v120, v119)
            let v122 : US0 = US0_1
            let v123 : UH2 = UH2_1(v122, v121)
            let v124 : UH2 = method15(v101)
            let v125 : bool = method16(v123, v124)
            if v125 then
                let v126 : US0 = US0_0
                let v127 : UH6 = UH6_2(v126)
                let v128 : US0 = US0_1
                let v129 : UH6 = UH6_2(v128)
                let v130 : US0 = US0_0
                let v131 : UH6 = UH6_2(v130)
                let v132 : UH6 = UH6_3(v131, v129)
                let v133 : UH6 = UH6_5(v132)
                let v134 : UH6 = UH6_4(v133, v127)
                let v135 : US0 = US0_1
                let v136 : UH6 = method17(v134, v135)
                let v137 : UH6 = method25(v101)
                let v138 : UH6 = method18(v137)
                let v139 : bool = method13(v136, v138)
                if v139 then
                    method26(v101)
                else
                    false
            else
                false
        else
            false
    else
        false
if v144 then
    ()
else
    let v145 : string = "well-formed derivative remainder theorem certificate should validate"
    failwith v145
    ()
let v146 : UH2 = UH2_0
let v147 : US0 = US0_0
let v148 : UH6 = UH6_2(v147)
let v149 : UH6 = UH6_5(v148)
let v150 : UH2 = UH2_0
let v151 : US0 = US0_1
let v152 : UH2 = UH2_1(v151, v150)
let v153 : US0 = US0_0
let v154 : UH2 = UH2_1(v153, v152)
let v155 : UH1 = method27(v149, v154)
let v156 : bool = method31(v146, v155)
let v157 : UH2 = UH2_0
let v158 : UH6 = UH6_0
let v159 : UH2 = UH2_0
let v160 : US0 = US0_1
let v161 : UH2 = UH2_1(v160, v159)
let v162 : UH1 = method27(v158, v161)
let v163 : bool = method31(v157, v162)
let v165 : bool =
    if v156 then
        v163
    else
        let v164 : bool = false = v163
        v164
if v165 then
    ()
else
    let v166 : string = "acceptance-only derivative law should miss a partial-remainder mutant when both decisions reject"
    failwith v166
    ()
let v167 : UH2 = UH2_0
let v168 : US0 = US0_1
let v169 : UH2 = UH2_1(v168, v167)
let v170 : US0 = US0_0
let v171 : UH2 = UH2_1(v170, v169)
let v172 : US0 = US0_0
let v173 : UH6 = UH6_2(v172)
let v174 : UH6 = UH6_5(v173)
let v175 : UH2 = UH2_0
let v176 : US0 = US0_1
let v177 : UH2 = UH2_1(v176, v175)
let v178 : US0 = US0_0
let v179 : UH2 = UH2_1(v178, v177)
let v180 : UH1 = method27(v174, v179)
let v181 : UH1 = method32(v171, v180)
let v182 : UH6 = UH6_0
let v183 : UH2 = UH2_0
let v184 : US0 = US0_1
let v185 : UH2 = UH2_1(v184, v183)
let v186 : UH1 = method27(v182, v185)
let v187 : bool = method33(v181, v186)
let v189 : bool =
    if v187 then
        method33(v186, v181)
    else
        false
let v190 : bool = v189 = false
if v190 then
    ()
else
    let v191 : string = "remainder-set derivative law should reject the same partial-remainder mutant"
    failwith v191
    ()
let v192 : UH2 = UH2_0
let v193 : US0 = US0_1
let v194 : US0 = US0_1
let v195 : UH7 = UH7_2(v194, v193, v192)
let v196 : UH2 = UH2_0
let v197 : US0 = US0_0
let v198 : US0 = US0_0
let v199 : UH7 = UH7_2(v198, v197, v196)
let v200 : UH2 = UH2_0
let v201 : US0 = US0_0
let v202 : UH7 = UH7_3(v201, v200, v199, v195)
let v203 : bool = method26(v202)
let v204 : bool = v203 = false
if v204 then
    ()
else
    let v205 : string = "certificate validation should reject a child proof from a different derivative context"
    failwith v205
    ()
let v206 : UH6 = UH6_1
let v207 : US0 = US0_0
let v208 : UH2 = UH2_0
let v209 : UH7 = method10(v206, v207, v208)
let v210 : UH6 = UH6_0
let v211 : UH6 = method12(v209)
let v212 : bool = method13(v210, v211)
let v232 : bool =
    if v212 then
        let v213 : US0 = method14(v209)
        let v217 : US4 =
            match v213 with
            | US0_0 -> (* BitZero *)
                US4_1
            | US0_1 -> (* BitOne *)
                US4_0
        let v218 : bool =
            match v217 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v218 then
            let v219 : UH2 = UH2_0
            let v220 : UH2 = method15(v209)
            let v221 : bool = method16(v219, v220)
            if v221 then
                let v222 : UH6 = UH6_0
                let v223 : US0 = US0_0
                let v224 : UH6 = method17(v222, v223)
                let v225 : UH6 = method25(v209)
                let v226 : UH6 = method18(v225)
                let v227 : bool = method13(v224, v226)
                if v227 then
                    method26(v209)
                else
                    false
            else
                false
        else
            false
    else
        false
let v233 : bool = v232 = false
if v233 then
    ()
else
    let v234 : string = "certificate validation should reject a forged source binding"
    failwith v234
    ()
let v235 : US0 = US0_0
let v236 : UH6 = UH6_2(v235)
let v237 : US0 = US0_0
let v238 : UH2 = UH2_0
let v239 : UH7 = method10(v236, v237, v238)
let v240 : US0 = US0_0
let v241 : UH6 = UH6_2(v240)
let v242 : UH6 = method12(v239)
let v243 : bool = method13(v241, v242)
let v264 : bool =
    if v243 then
        let v244 : US0 = method14(v239)
        let v248 : US4 =
            match v244 with
            | US0_0 -> (* BitZero *)
                US4_2
            | US0_1 -> (* BitOne *)
                US4_1
        let v249 : bool =
            match v248 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v249 then
            let v250 : UH2 = UH2_0
            let v251 : UH2 = method15(v239)
            let v252 : bool = method16(v250, v251)
            if v252 then
                let v253 : US0 = US0_0
                let v254 : UH6 = UH6_2(v253)
                let v255 : US0 = US0_1
                let v256 : UH6 = method17(v254, v255)
                let v257 : UH6 = method25(v239)
                let v258 : UH6 = method18(v257)
                let v259 : bool = method13(v256, v258)
                if v259 then
                    method26(v239)
                else
                    false
            else
                false
        else
            false
    else
        false
let v265 : bool = v264 = false
if v265 then
    ()
else
    let v266 : string = "certificate validation should reject a forged symbol binding"
    failwith v266
    ()
let v267 : UH6 = UH6_1
let v268 : US0 = US0_0
let v269 : UH2 = UH2_0
let v270 : UH7 = method10(v267, v268, v269)
let v271 : US0 = US0_0
let v272 : UH6 = UH6_2(v271)
let v273 : US0 = US0_0
let v274 : UH2 = UH2_0
let v275 : UH7 = method10(v272, v273, v274)
let v276 : US2 = US2_1
let v277 : UH2 = UH2_0
let v278 : US0 = US0_0
let v279 : UH7 = UH7_4(v278, v277, v276, v270, v275)
let v280 : bool = method26(v279)
let v281 : bool = v280 = false
if v281 then
    ()
else
    let v282 : string = "certificate validation should reject a forged nullable concatenation branch"
    failwith v282
    ()
let v283 : string = "brzozowski-remainder-theorem-green"
v283
