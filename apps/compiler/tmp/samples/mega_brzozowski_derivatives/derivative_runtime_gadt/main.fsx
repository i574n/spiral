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
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US2 = method4(v53, v55)
            match v57 with
            | US2_1 -> (* SymbolSame *)
                method4(v54, v56)
            | _ ->
                v57
        | _ ->
            US2_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US2 = method4(v28, v34)
            match v36 with
            | US2_1 -> (* SymbolSame *)
                method4(v29, v35)
            | _ ->
                v36
        | UH0_2(v32) -> (* RegexChar *)
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
    | UH0_5(v44) -> (* RegexStar *)
        match v1 with
        | UH0_3(v45, v46) -> (* RegexAlt *)
            US2_0
        | UH0_5(v48) -> (* RegexStar *)
            method4(v44, v48)
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
        let v11 : US2 = method4(v0, v1)
        match v11 with
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
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
            let v15 : US2 =
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
            match v15 with
            | US2_1 -> (* SymbolSame *)
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
        let v18 : US3 = method9(v16)
        let v19 : US3 = method9(v17)
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
and method8 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method8(v19, v1)
        let v22 : UH0 = method8(v20, v1)
        method2(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method9(v24)
        match v26 with
        | US3_1 -> (* NonNullable *)
            let v31 : UH0 = method8(v24, v1)
            method5(v31, v25)
        | US3_0 -> (* Nullable *)
            let v27 : UH0 = method8(v24, v1)
            let v28 : UH0 = method5(v27, v25)
            let v29 : UH0 = method8(v25, v1)
            method2(v28, v29)
    | UH0_2(v4) -> (* RegexChar *)
        let v14 : US2 =
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
        let v15 : bool =
            match v14 with
            | US2_1 -> (* SymbolSame *)
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
        let v36 : UH0 = method8(v35, v1)
        let v37 : UH0 = method7(v35)
        method5(v36, v37)
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
            let v16 : US2 =
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
            let v17 : bool =
                match v16 with
                | US2_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
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
    | UH0_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH4 = method10(v26, v1)
        let v29 : UH4 = method10(v27, v1)
        method11(v28, v29)
    | UH0_4(v31, v32) -> (* RegexCat *)
        let v33 : UH4 = method10(v31, v1)
        method12(v32, v33)
    | UH0_2(v5) -> (* RegexChar *)
        match v1 with
        | UH1_1(v7, v8) -> (* InputCons *)
            let v18 : US2 =
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
            let v19 : bool =
                match v18 with
                | US2_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v19 then
                let v20 : UH4 = UH4_0
                UH4_1(v8, v20)
            else
                UH4_0
        | UH1_0 -> (* InputEmpty *)
            UH4_0
    | UH0_0 -> (* RegexEmpty *)
        UH4_0
    | UH0_1 -> (* RegexEpsilon *)
        let v3 : UH4 = UH4_0
        UH4_1(v1, v3)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH4 = UH4_0
        let v37 : UH4 = UH4_1(v1, v36)
        let v38 : UH4 = UH4_0
        let v39 : UH4 = UH4_1(v1, v38)
        method13(v35, v37, v39)
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
    | UH2_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v61, v62) -> (* RegexAlt *)
            let v63 : US2 = method23(v59, v61)
            match v63 with
            | US2_1 -> (* SymbolSame *)
                method23(v60, v62)
            | _ ->
                v63
        | _ ->
            US2_2
    | UH2_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH2_4(v40, v41) -> (* RegexCat *)
            let v42 : US2 = method23(v34, v40)
            match v42 with
            | US2_1 -> (* SymbolSame *)
                method23(v35, v41)
            | _ ->
                v42
        | UH2_2(v38) -> (* RegexChar *)
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
    | UH2_5(v50) -> (* RegexStar *)
        match v1 with
        | UH2_3(v51, v52) -> (* RegexAlt *)
            US2_0
        | UH2_5(v54) -> (* RegexStar *)
            method23(v50, v54)
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
        let v11 : US2 = method23(v0, v1)
        match v11 with
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
    | UH2_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method25(v24, v26)
            if v28 then
                method25(v25, v27)
            else
                false
        | _ ->
            false
    | UH2_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method25(v32, v34)
            if v36 then
                method25(v33, v35)
            else
                false
        | _ ->
            false
    | UH2_2(v4) -> (* RegexChar *)
        match v1 with
        | UH2_2(v5) -> (* RegexChar *)
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
    | UH2_5(v40) -> (* RegexStar *)
        match v1 with
        | UH2_5(v41) -> (* RegexStar *)
            method25(v40, v41)
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
        let v18 : US3 = method28(v16)
        let v19 : US3 = method28(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH2_2(v3) -> (* RegexChar *)
        US3_1
    | UH2_0 -> (* RegexEmpty *)
        US3_1
    | UH2_1 -> (* RegexEpsilon *)
        US3_0
    | UH2_5(v25) -> (* RegexStar *)
        US3_0
and method27 (v0 : UH2, v1 : US1) : UH2 =
    match v0 with
    | UH2_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = method27(v25, v1)
        let v28 : UH2 = method27(v26, v1)
        method21(v27, v28)
    | UH2_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method28(v30)
        match v32 with
        | US3_1 -> (* NonNullable *)
            let v37 : UH2 = method27(v30, v1)
            method24(v37, v31)
        | US3_0 -> (* Nullable *)
            let v33 : UH2 = method27(v30, v1)
            let v34 : UH2 = method24(v33, v31)
            let v35 : UH2 = method27(v31, v1)
            method21(v34, v35)
    | UH2_2(v4) -> (* RegexChar *)
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
            UH2_1
        else
            UH2_0
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH2 = method27(v41, v1)
        let v43 : UH2 = method26(v41)
        method24(v42, v43)
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
            let v22 : US2 =
                match v3 with
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
                        match v3 with
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
            let v23 : bool =
                match v22 with
                | US2_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
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
    | UH2_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH5 = method29(v32, v1)
        let v35 : UH5 = method29(v33, v1)
        method30(v34, v35)
    | UH2_4(v37, v38) -> (* RegexCat *)
        let v39 : UH5 = method29(v37, v1)
        method31(v38, v39)
    | UH2_2(v5) -> (* RegexChar *)
        match v1 with
        | UH3_1(v7, v8) -> (* InputCons *)
            let v24 : US2 =
                match v5 with
                | US1_0 -> (* TriA *)
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US2_1
                    | _ ->
                        US2_0
                | _ ->
                    match v7 with
                    | US1_0 -> (* TriA *)
                        US2_2
                    | _ ->
                        match v5 with
                        | US1_1 -> (* TriB *)
                            match v7 with
                            | US1_1 -> (* TriB *)
                                US2_1
                            | US1_2 -> (* TriC *)
                                US2_0
                        | US1_2 -> (* TriC *)
                            match v7 with
                            | US1_1 -> (* TriB *)
                                US2_2
                            | US1_2 -> (* TriC *)
                                US2_1
            let v25 : bool =
                match v24 with
                | US2_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH5 = UH5_0
                UH5_1(v8, v26)
            else
                UH5_0
        | UH3_0 -> (* InputEmpty *)
            UH5_0
    | UH2_0 -> (* RegexEmpty *)
        UH5_0
    | UH2_1 -> (* RegexEpsilon *)
        let v3 : UH5 = UH5_0
        UH5_1(v1, v3)
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH5 = UH5_0
        let v43 : UH5 = UH5_1(v1, v42)
        let v44 : UH5 = UH5_0
        let v45 : UH5 = UH5_1(v1, v44)
        method32(v41, v43, v45)
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
