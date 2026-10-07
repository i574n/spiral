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
    | UH1_1 of US0 * UH1
and UH2 =
    | UH2_0
    | UH2_1 of UH0 * UH2
and [<Struct>] US2 =
    | US2_0
    | US2_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
and UH3 =
    | UH3_0
    | UH3_1
    | UH3_2 of US3
    | UH3_3 of UH3 * UH3
    | UH3_4 of UH3 * UH3
    | UH3_5 of UH3
and UH4 =
    | UH4_0
    | UH4_1 of US3 * UH4
and UH5 =
    | UH5_0
    | UH5_1 of UH3 * UH5
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
and method11 (v0 : UH0) : US2 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method11(v5)
        let v8 : US2 = method11(v6)
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
        let v18 : US2 = method11(v16)
        let v19 : US2 = method11(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH0_2(v3) -> (* RegexChar *)
        US2_1
    | UH0_0 -> (* RegexEmpty *)
        US2_1
    | UH0_1 -> (* RegexEpsilon *)
        US2_0
    | UH0_5(v25) -> (* RegexStar *)
        US2_0
and method10 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method10(v19, v1)
        let v22 : UH0 = method10(v20, v1)
        method1(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = method11(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = method10(v24, v1)
            method4(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = method10(v24, v1)
            let v28 : UH0 = method4(v27, v25)
            let v29 : UH0 = method10(v25, v1)
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
        let v36 : UH0 = method10(v35, v1)
        let v37 : UH0 = method6(v35)
        method4(v36, v37)
and method9 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method0(v0)
    let v3 : UH0 = method10(v2, v1)
    method0(v3)
and method12 (v0 : UH0, v1 : UH2) : bool =
    match v1 with
    | UH2_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method5(v0, v2)
        if v4 then
            true
        else
            method12(v0, v3)
    | UH2_0 -> (* RegexListNil *)
        false
and method8 (v0 : UH0, v1 : UH1, v2 : UH2, v3 : UH2) : struct (UH2 * UH2) =
    match v1 with
    | UH1_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH0 = method9(v0, v4)
        let v7 : bool = method12(v6, v2)
        if v7 then
            method8(v0, v5, v2, v3)
        else
            let v10 : UH2 = UH2_1(v6, v2)
            let v11 : UH2 = UH2_1(v6, v3)
            method8(v0, v5, v10, v11)
    | UH1_0 -> (* SymbolListNil *)
        struct (v2, v3)
and method7 (v0 : UH1, v1 : UH2, v2 : UH2) : UH2 =
    match v2 with
    | UH2_1(v3, v4) -> (* RegexListCons *)
        let struct (v5 : UH2, v6 : UH2) = method8(v3, v0, v1, v4)
        method7(v0, v5, v6)
    | UH2_0 -> (* RegexListNil *)
        v1
and method13 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method12(v2, v1)
        if v4 then
            method13(v3, v1)
        else
            false
    | UH2_0 -> (* RegexListNil *)
        true
and method17 (v0 : UH3, v1 : UH3) : US1 =
    match v0 with
    | UH3_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method17(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method17(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH3_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH3_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method17(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method17(v35, v41)
            | _ ->
                v42
        | UH3_2(v38) -> (* RegexChar *)
            US1_2
        | UH3_0 -> (* RegexEmpty *)
            US1_2
        | UH3_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH3_2(v10) -> (* RegexChar *)
        match v1 with
        | UH3_2(v13) -> (* RegexChar *)
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
        | UH3_0 -> (* RegexEmpty *)
            US1_2
        | UH3_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH3_0 -> (* RegexEmpty *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH3_1 -> (* RegexEpsilon *)
        match v1 with
        | UH3_0 -> (* RegexEmpty *)
            US1_2
        | UH3_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH3_5(v50) -> (* RegexStar *)
        match v1 with
        | UH3_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH3_5(v54) -> (* RegexStar *)
            method17(v50, v54)
        | _ ->
            US1_2
and method16 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method17(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH3 = method16(v0, v3)
            UH3_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH3_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method17(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH3_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method15 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH3 = method16(v2, v1)
        method15(v3, v4)
    | UH3_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method16(v0, v1)
and method19 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method19(v24, v26)
            if v28 then
                method19(v25, v27)
            else
                false
        | _ ->
            false
    | UH3_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH3_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method19(v32, v34)
            if v36 then
                method19(v33, v35)
            else
                false
        | _ ->
            false
    | UH3_2(v4) -> (* RegexChar *)
        match v1 with
        | UH3_2(v5) -> (* RegexChar *)
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
    | UH3_5(v40) -> (* RegexStar *)
        match v1 with
        | UH3_5(v41) -> (* RegexStar *)
            method19(v40, v41)
        | _ ->
            false
and method18 (v0 : UH3, v1 : UH3) : UH3 =
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
                        let v14 : UH3 = method18(v13, v1)
                        UH3_4(v12, v14)
                    | UH3_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH3_5(v5) -> (* RegexStar *)
                            let v6 : bool = method19(v4, v5)
                            if v6 then
                                UH3_5(v4)
                            else
                                UH3_4(v0, v1)
                        | _ ->
                            UH3_4(v0, v1)
                    | _ ->
                        UH3_4(v0, v1)
and method20 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_0 -> (* RegexEmpty *)
        UH3_1
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v3) -> (* RegexStar *)
        UH3_5(v3)
    | _ ->
        UH3_5(v0)
and method14 (v0 : UH3) : UH3 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH3 = method14(v5)
        let v8 : UH3 = method14(v6)
        method15(v7, v8)
    | UH3_4(v10, v11) -> (* RegexCat *)
        let v12 : UH3 = method14(v10)
        let v13 : UH3 = method14(v11)
        method18(v12, v13)
    | UH3_2(v3) -> (* RegexChar *)
        UH3_2(v3)
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v15) -> (* RegexStar *)
        let v16 : UH3 = method14(v15)
        method20(v16)
and method25 (v0 : UH3) : US2 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method25(v5)
        let v8 : US2 = method25(v6)
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
    | UH3_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = method25(v16)
        let v19 : US2 = method25(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH3_2(v3) -> (* RegexChar *)
        US2_1
    | UH3_0 -> (* RegexEmpty *)
        US2_1
    | UH3_1 -> (* RegexEpsilon *)
        US2_0
    | UH3_5(v25) -> (* RegexStar *)
        US2_0
and method24 (v0 : UH3, v1 : US3) : UH3 =
    match v0 with
    | UH3_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH3 = method24(v25, v1)
        let v28 : UH3 = method24(v26, v1)
        method15(v27, v28)
    | UH3_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = method25(v30)
        match v32 with
        | US2_1 -> (* NonNullable *)
            let v37 : UH3 = method24(v30, v1)
            method18(v37, v31)
        | US2_0 -> (* Nullable *)
            let v33 : UH3 = method24(v30, v1)
            let v34 : UH3 = method18(v33, v31)
            let v35 : UH3 = method24(v31, v1)
            method15(v34, v35)
    | UH3_2(v4) -> (* RegexChar *)
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
            UH3_1
        else
            UH3_0
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_5(v41) -> (* RegexStar *)
        let v42 : UH3 = method24(v41, v1)
        let v43 : UH3 = method20(v41)
        method18(v42, v43)
and method23 (v0 : UH3, v1 : US3) : UH3 =
    let v2 : UH3 = method14(v0)
    let v3 : UH3 = method24(v2, v1)
    method14(v3)
and method26 (v0 : UH3, v1 : UH5) : bool =
    match v1 with
    | UH5_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method19(v0, v2)
        if v4 then
            true
        else
            method26(v0, v3)
    | UH5_0 -> (* RegexListNil *)
        false
and method22 (v0 : UH3, v1 : UH4, v2 : UH5, v3 : UH5) : struct (UH5 * UH5) =
    match v1 with
    | UH4_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH3 = method23(v0, v4)
        let v7 : bool = method26(v6, v2)
        if v7 then
            method22(v0, v5, v2, v3)
        else
            let v10 : UH5 = UH5_1(v6, v2)
            let v11 : UH5 = UH5_1(v6, v3)
            method22(v0, v5, v10, v11)
    | UH4_0 -> (* SymbolListNil *)
        struct (v2, v3)
and method21 (v0 : UH4, v1 : UH5, v2 : UH5) : UH5 =
    match v2 with
    | UH5_1(v3, v4) -> (* RegexListCons *)
        let struct (v5 : UH5, v6 : UH5) = method22(v3, v0, v1, v4)
        method21(v0, v5, v6)
    | UH5_0 -> (* RegexListNil *)
        v1
and method27 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method26(v2, v1)
        if v4 then
            method27(v3, v1)
        else
            false
    | UH5_0 -> (* RegexListNil *)
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
let v9 : UH0 = method0(v8)
let v10 : US0 = US0_0
let v11 : US0 = US0_1
let v12 : UH1 = UH1_0
let v13 : UH1 = UH1_1(v11, v12)
let v14 : UH1 = UH1_1(v10, v13)
let v15 : UH2 = UH2_0
let v16 : UH2 = UH2_1(v9, v15)
let v17 : UH2 = UH2_0
let v18 : UH2 = UH2_1(v9, v17)
let v19 : UH2 = method7(v14, v16, v18)
let v20 : UH0 = UH0_1
let v21 : US0 = US0_0
let v22 : UH0 = UH0_2(v21)
let v23 : US0 = US0_1
let v24 : UH0 = UH0_2(v23)
let v25 : UH0 = UH0_3(v22, v24)
let v26 : UH0 = UH0_5(v25)
let v27 : US0 = US0_0
let v28 : UH0 = UH0_2(v27)
let v29 : UH0 = UH0_4(v26, v28)
let v30 : UH0 = UH0_3(v20, v29)
let v31 : UH0 = UH0_2(v21)
let v32 : UH0 = UH0_2(v23)
let v33 : UH0 = UH0_3(v31, v32)
let v34 : UH0 = UH0_5(v33)
let v35 : UH0 = UH0_2(v27)
let v36 : UH0 = UH0_4(v34, v35)
let v37 : UH2 = UH2_0
let v38 : UH2 = UH2_1(v36, v37)
let v39 : UH2 = UH2_1(v30, v38)
let v40 : bool = method13(v39, v19)
let v62 : bool =
    if v40 then
        let v41 : UH0 = UH0_1
        let v42 : US0 = US0_0
        let v43 : UH0 = UH0_2(v42)
        let v44 : US0 = US0_1
        let v45 : UH0 = UH0_2(v44)
        let v46 : UH0 = UH0_3(v43, v45)
        let v47 : UH0 = UH0_5(v46)
        let v48 : US0 = US0_0
        let v49 : UH0 = UH0_2(v48)
        let v50 : UH0 = UH0_4(v47, v49)
        let v51 : UH0 = UH0_3(v41, v50)
        let v52 : UH0 = UH0_2(v42)
        let v53 : UH0 = UH0_2(v44)
        let v54 : UH0 = UH0_3(v52, v53)
        let v55 : UH0 = UH0_5(v54)
        let v56 : UH0 = UH0_2(v48)
        let v57 : UH0 = UH0_4(v55, v56)
        let v58 : UH2 = UH2_0
        let v59 : UH2 = UH2_1(v57, v58)
        let v60 : UH2 = UH2_1(v51, v59)
        method13(v19, v60)
    else
        false
if v62 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v63 : US0 = US0_0
let v64 : UH0 = UH0_2(v63)
let v65 : US0 = US0_1
let v66 : UH0 = UH0_2(v65)
let v67 : UH0 = UH0_3(v64, v66)
let v68 : UH0 = UH0_5(v67)
let v69 : US0 = US0_0
let v70 : UH0 = UH0_2(v69)
let v71 : UH0 = UH0_4(v68, v70)
let v72 : US0 = US0_0
let v73 : UH0 = UH0_2(v72)
let v74 : US0 = US0_1
let v75 : UH0 = UH0_2(v74)
let v76 : UH0 = UH0_3(v73, v75)
let v77 : UH0 = UH0_5(v76)
let v78 : US0 = US0_0
let v79 : UH0 = UH0_2(v78)
let v80 : UH0 = UH0_4(v77, v79)
let v81 : US0 = US0_1
let v82 : UH0 = method9(v80, v81)
let v83 : bool = method5(v71, v82)
if v83 then
    ()
else
    failwith<unit> "typed transition target must be the derivative for its indexed symbol"
let v84 : US3 = US3_0
let v85 : UH3 = UH3_2(v84)
let v86 : US3 = US3_1
let v87 : UH3 = UH3_2(v86)
let v88 : UH3 = UH3_3(v85, v87)
let v89 : UH3 = UH3_5(v88)
let v90 : US3 = US3_2
let v91 : UH3 = UH3_2(v90)
let v92 : UH3 = UH3_4(v89, v91)
let v93 : UH3 = method14(v92)
let v94 : US3 = US3_0
let v95 : US3 = US3_1
let v96 : US3 = US3_2
let v97 : UH4 = UH4_0
let v98 : UH4 = UH4_1(v96, v97)
let v99 : UH4 = UH4_1(v95, v98)
let v100 : UH4 = UH4_1(v94, v99)
let v101 : UH5 = UH5_0
let v102 : UH5 = UH5_1(v93, v101)
let v103 : UH5 = UH5_0
let v104 : UH5 = UH5_1(v93, v103)
let v105 : UH5 = method21(v100, v102, v104)
let v106 : UH3 = UH3_0
let v107 : UH3 = UH3_1
let v108 : US3 = US3_0
let v109 : UH3 = UH3_2(v108)
let v110 : US3 = US3_1
let v111 : UH3 = UH3_2(v110)
let v112 : UH3 = UH3_3(v109, v111)
let v113 : UH3 = UH3_5(v112)
let v114 : US3 = US3_2
let v115 : UH3 = UH3_2(v114)
let v116 : UH3 = UH3_4(v113, v115)
let v117 : UH5 = UH5_0
let v118 : UH5 = UH5_1(v116, v117)
let v119 : UH5 = UH5_1(v107, v118)
let v120 : UH5 = UH5_1(v106, v119)
let v121 : bool = method27(v120, v105)
let v138 : bool =
    if v121 then
        let v122 : UH3 = UH3_0
        let v123 : UH3 = UH3_1
        let v124 : US3 = US3_0
        let v125 : UH3 = UH3_2(v124)
        let v126 : US3 = US3_1
        let v127 : UH3 = UH3_2(v126)
        let v128 : UH3 = UH3_3(v125, v127)
        let v129 : UH3 = UH3_5(v128)
        let v130 : US3 = US3_2
        let v131 : UH3 = UH3_2(v130)
        let v132 : UH3 = UH3_4(v129, v131)
        let v133 : UH5 = UH5_0
        let v134 : UH5 = UH5_1(v132, v133)
        let v135 : UH5 = UH5_1(v123, v134)
        let v136 : UH5 = UH5_1(v122, v135)
        method27(v105, v136)
    else
        false
if v138 then
    ()
else
    failwith<unit> "brzozowski-expected-true"
let v139 : string = "brzozowski-indexed-dfa-contract-green"
v139
