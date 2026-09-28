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
    | US2_0
    | US2_1
    | US2_2
and UH2 =
    | UH2_0
    | UH2_1 of US2 * UH2
and UH3 =
    | UH3_0
    | UH3_1
    | UH3_2 of US0
    | UH3_3 of UH3 * UH3
    | UH3_4 of UH3 * UH3
    | UH3_5 of UH3
and UH4 =
    | UH4_0
    | UH4_1 of UH3 * UH4
and UH5 =
    | UH5_0
    | UH5_1 of UH5
and [<Struct>] US3 =
    | US3_0
    | US3_1
and UH6 =
    | UH6_0
    | UH6_1
    | UH6_2 of US2
    | UH6_3 of UH6 * UH6
    | UH6_4 of UH6 * UH6
    | UH6_5 of UH6
and UH7 =
    | UH7_0
    | UH7_1 of UH6 * UH7
and UH8 =
    | UH8_0
    | UH8_1 of US0 * UH8
and [<Struct>] US5 =
    | US5_2 of f2_0 : UH3 * f2_1 : US0 * f2_2 : UH3
and [<Struct>] US4 =
    | US4_0
    | US4_1 of f1_0 : US5
and UH9 =
    | UH9_0
    | UH9_1 of US2 * UH9
and [<Struct>] US7 =
    | US7_2 of f2_0 : UH6 * f2_1 : US2 * f2_2 : UH6
and [<Struct>] US6 =
    | US6_0
    | US6_1 of f1_0 : US7
let rec method1 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_1 -> (* BitOne *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US1_1
                | US0_0 -> (* BitZero *)
                    US1_2
            | US0_0 -> (* BitZero *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US1_0
                | US0_0 -> (* BitZero *)
                    US1_1
        let v23 : US1 =
            match v2 with
            | US0_1 -> (* BitOne *)
                match v0 with
                | US0_1 -> (* BitOne *)
                    US1_1
                | US0_0 -> (* BitZero *)
                    US1_2
            | US0_0 -> (* BitZero *)
                match v0 with
                | US0_1 -> (* BitOne *)
                    US1_0
                | US0_0 -> (* BitZero *)
                    US1_1
        let v40 : bool =
            match v13 with
            | US1_2 -> (* SymbolGreater *)
                match v23 with
                | US1_0 -> (* SymbolLess *)
                    true
                | _ ->
                    false
            | US1_0 -> (* SymbolLess *)
                match v23 with
                | US1_2 -> (* SymbolGreater *)
                    true
                | _ ->
                    false
            | US1_1 -> (* SymbolSame *)
                match v23 with
                | US1_1 -> (* SymbolSame *)
                    let v33 : US1 =
                        match v0 with
                        | US0_1 -> (* BitOne *)
                            match v2 with
                            | US0_1 -> (* BitOne *)
                                US1_1
                            | US0_0 -> (* BitZero *)
                                US1_2
                        | US0_0 -> (* BitZero *)
                            match v2 with
                            | US0_1 -> (* BitOne *)
                                US1_0
                            | US0_0 -> (* BitZero *)
                                US1_1
                    match v33 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                | _ ->
                    false
        if v40 then
            method1(v0, v3)
        else
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method0 (v0 : UH0) : bool =
    match v0 with
    | UH0_1(v1, v2) -> (* SymbolListCons *)
        let v6 : US1 =
            match v1 with
            | US0_1 -> (* BitOne *)
                US1_1
            | US0_0 -> (* BitZero *)
                US1_1
        match v6 with
        | US1_1 -> (* SymbolSame *)
            let v7 : bool = method1(v1, v2)
            if v7 then
                method0(v2)
            else
                false
        | _ ->
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method3 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_1 -> (* BitOne *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US1_1
                | US0_0 -> (* BitZero *)
                    US1_2
            | US0_0 -> (* BitZero *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US1_0
                | US0_0 -> (* BitZero *)
                    US1_1
        match v13 with
        | US1_0 -> (* SymbolLess *)
            method3(v0, v3)
        | _ ->
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method2 (v0 : UH0) : bool =
    match v0 with
    | UH0_1(v1, v2) -> (* SymbolListCons *)
        let v3 : bool = method3(v1, v2)
        if v3 then
            method2(v2)
        else
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method4 (v0 : UH0, v1 : UH1) : bool =
    match v0 with
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH1_1(v5) -> (* AlphabetCardinalitySucc *)
            method4(v4, v5)
        | _ ->
            false
    | UH0_0 -> (* SymbolListNil *)
        match v1 with
        | UH1_0 -> (* AlphabetCardinalityZero *)
            true
        | _ ->
            false
and method5 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH0_1(v5, v6) -> (* SymbolListCons *)
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
                method5(v4, v6)
            else
                false
        | _ ->
            false
    | UH0_0 -> (* SymbolListNil *)
        match v1 with
        | UH0_0 -> (* SymbolListNil *)
            true
        | _ ->
            false
and method7 (v0 : US2, v1 : UH2) : bool =
    match v1 with
    | UH2_1(v2, v3) -> (* SymbolListCons *)
        let v19 : US1 =
            match v0 with
            | US2_0 -> (* TriA *)
                match v2 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v2 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v0 with
                    | US2_1 -> (* TriB *)
                        match v2 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v2 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        let v35 : US1 =
            match v2 with
            | US2_0 -> (* TriA *)
                match v0 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v0 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v2 with
                    | US2_1 -> (* TriB *)
                        match v0 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v0 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        let v58 : bool =
            match v19 with
            | US1_2 -> (* SymbolGreater *)
                match v35 with
                | US1_0 -> (* SymbolLess *)
                    true
                | _ ->
                    false
            | US1_0 -> (* SymbolLess *)
                match v35 with
                | US1_2 -> (* SymbolGreater *)
                    true
                | _ ->
                    false
            | US1_1 -> (* SymbolSame *)
                match v35 with
                | US1_1 -> (* SymbolSame *)
                    let v51 : US1 =
                        match v0 with
                        | US2_0 -> (* TriA *)
                            match v2 with
                            | US2_0 -> (* TriA *)
                                US1_1
                            | _ ->
                                US1_0
                        | _ ->
                            match v2 with
                            | US2_0 -> (* TriA *)
                                US1_2
                            | _ ->
                                match v0 with
                                | US2_1 -> (* TriB *)
                                    match v2 with
                                    | US2_1 -> (* TriB *)
                                        US1_1
                                    | US2_2 -> (* TriC *)
                                        US1_0
                                | US2_2 -> (* TriC *)
                                    match v2 with
                                    | US2_1 -> (* TriB *)
                                        US1_2
                                    | US2_2 -> (* TriC *)
                                        US1_1
                    match v51 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                | _ ->
                    false
        if v58 then
            method7(v0, v3)
        else
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method6 (v0 : UH2) : bool =
    match v0 with
    | UH2_1(v1, v2) -> (* SymbolListCons *)
        let v8 : US1 =
            match v1 with
            | US2_0 -> (* TriA *)
                US1_1
            | US2_1 -> (* TriB *)
                US1_1
            | US2_2 -> (* TriC *)
                US1_1
        match v8 with
        | US1_1 -> (* SymbolSame *)
            let v9 : bool = method7(v1, v2)
            if v9 then
                method6(v2)
            else
                false
        | _ ->
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method9 (v0 : US2, v1 : UH2) : bool =
    match v1 with
    | UH2_1(v2, v3) -> (* SymbolListCons *)
        let v19 : US1 =
            match v0 with
            | US2_0 -> (* TriA *)
                match v2 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v2 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v0 with
                    | US2_1 -> (* TriB *)
                        match v2 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v2 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        match v19 with
        | US1_0 -> (* SymbolLess *)
            method9(v0, v3)
        | _ ->
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method8 (v0 : UH2) : bool =
    match v0 with
    | UH2_1(v1, v2) -> (* SymbolListCons *)
        let v3 : bool = method9(v1, v2)
        if v3 then
            method8(v2)
        else
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method10 (v0 : UH2, v1 : UH1) : bool =
    match v0 with
    | UH2_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH1_1(v5) -> (* AlphabetCardinalitySucc *)
            method10(v4, v5)
        | _ ->
            false
    | UH2_0 -> (* SymbolListNil *)
        match v1 with
        | UH1_0 -> (* AlphabetCardinalityZero *)
            true
        | _ ->
            false
and method11 (v0 : UH2, v1 : UH2) : bool =
    match v0 with
    | UH2_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH2_1(v5, v6) -> (* SymbolListCons *)
            let v22 : US1 =
                match v3 with
                | US2_0 -> (* TriA *)
                    match v5 with
                    | US2_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US2_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v3 with
                        | US2_1 -> (* TriB *)
                            match v5 with
                            | US2_1 -> (* TriB *)
                                US1_1
                            | US2_2 -> (* TriC *)
                                US1_0
                        | US2_2 -> (* TriC *)
                            match v5 with
                            | US2_1 -> (* TriB *)
                                US1_2
                            | US2_2 -> (* TriC *)
                                US1_1
            let v23 : bool =
                match v22 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                method11(v4, v6)
            else
                false
        | _ ->
            false
    | UH2_0 -> (* SymbolListNil *)
        match v1 with
        | UH2_0 -> (* SymbolListNil *)
            true
        | _ ->
            false
and method15 (v0 : UH3, v1 : UH3) : US1 =
    match v0 with
    | UH3_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method15(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method15(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH3_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH3_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method15(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method15(v29, v35)
            | _ ->
                v36
        | UH3_2(v32) -> (* RegexChar *)
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
    | UH3_5(v44) -> (* RegexStar *)
        match v1 with
        | UH3_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH3_5(v48) -> (* RegexStar *)
            method15(v44, v48)
        | _ ->
            US1_2
and method14 (v0 : UH3, v1 : UH3) : UH3 =
    match v1 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method15(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH3 = method14(v0, v3)
            UH3_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH3_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method15(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH3_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH3_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method13 (v0 : UH3, v1 : UH3) : UH3 =
    match v0 with
    | UH3_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH3 = method14(v2, v1)
        method13(v3, v4)
    | UH3_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method14(v0, v1)
and method17 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH3_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method17(v18, v20)
            if v22 then
                method17(v19, v21)
            else
                false
        | _ ->
            false
    | UH3_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH3_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method17(v26, v28)
            if v30 then
                method17(v27, v29)
            else
                false
        | _ ->
            false
    | UH3_2(v4) -> (* RegexChar *)
        match v1 with
        | UH3_2(v5) -> (* RegexChar *)
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
    | UH3_5(v34) -> (* RegexStar *)
        match v1 with
        | UH3_5(v35) -> (* RegexStar *)
            method17(v34, v35)
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
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH3 = method12(v5)
        let v8 : UH3 = method12(v6)
        method13(v7, v8)
    | UH3_4(v10, v11) -> (* RegexCat *)
        let v12 : UH3 = method12(v10)
        let v13 : UH3 = method12(v11)
        method16(v12, v13)
    | UH3_2(v3) -> (* RegexChar *)
        UH3_2(v3)
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_1
    | UH3_5(v15) -> (* RegexStar *)
        let v16 : UH3 = method12(v15)
        method18(v16)
and method22 (v0 : UH3, v1 : UH4) : bool =
    match v1 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method17(v0, v2)
        if v4 then
            true
        else
            method22(v0, v3)
    | UH4_0 -> (* RegexListNil *)
        false
and method21 (v0 : UH3, v1 : UH4) : UH4 =
    let v2 : UH3 = method12(v0)
    let v3 : bool = method22(v2, v1)
    if v3 then
        v1
    else
        UH4_1(v2, v1)
and method20 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = method21(v2, v1)
        method20(v3, v4)
    | UH4_0 -> (* RegexListNil *)
        v1
and method23 (v0 : UH4, v1 : UH3) : UH4 =
    match v0 with
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH3 = method16(v3, v1)
        let v6 : UH4 = method23(v4, v1)
        method21(v5, v6)
    | UH4_0 -> (* RegexListNil *)
        UH4_0
and method19 (v0 : UH3) : UH4 =
    match v0 with
    | UH3_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH4 = method19(v7)
        let v10 : UH4 = method19(v8)
        method20(v9, v10)
    | UH3_4(v12, v13) -> (* RegexCat *)
        let v14 : UH4 = method19(v12)
        let v15 : UH4 = method23(v14, v13)
        let v16 : UH4 = method19(v13)
        method20(v15, v16)
    | UH3_2(v3) -> (* RegexChar *)
        let v4 : UH3 = UH3_1
        let v5 : UH4 = UH4_0
        UH4_1(v4, v5)
    | UH3_0 -> (* RegexEmpty *)
        UH4_0
    | UH3_1 -> (* RegexEpsilon *)
        UH4_0
    | UH3_5(v18) -> (* RegexStar *)
        let v19 : UH4 = method19(v18)
        let v20 : UH3 = UH3_5(v18)
        method23(v19, v20)
and method25 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = method25(v3, v1)
        UH4_1(v2, v4)
    | UH4_0 -> (* RegexListNil *)
        v1
and method26 (v0 : UH4, v1 : UH3) : UH4 =
    match v0 with
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH3 = method16(v3, v1)
        let v6 : UH3 = method12(v5)
        let v7 : UH4 = method26(v4, v1)
        UH4_1(v6, v7)
    | UH4_0 -> (* RegexListNil *)
        UH4_0
and method24 (v0 : UH3) : UH4 =
    match v0 with
    | UH3_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH4 = method24(v7)
        let v10 : UH4 = method24(v8)
        method25(v9, v10)
    | UH3_4(v12, v13) -> (* RegexCat *)
        let v14 : UH4 = method24(v12)
        let v15 : UH4 = method26(v14, v13)
        let v16 : UH4 = method24(v13)
        method25(v15, v16)
    | UH3_2(v3) -> (* RegexChar *)
        let v4 : UH3 = UH3_1
        let v5 : UH4 = UH4_0
        UH4_1(v4, v5)
    | UH3_0 -> (* RegexEmpty *)
        UH4_0
    | UH3_1 -> (* RegexEpsilon *)
        UH4_0
    | UH3_5(v18) -> (* RegexStar *)
        let v19 : UH4 = method24(v18)
        let v20 : UH3 = UH3_5(v18)
        method26(v19, v20)
and method27 (v0 : UH4) : bool =
    match v0 with
    | UH4_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = method22(v1, v2)
        if v3 then
            false
        else
            method27(v2)
    | UH4_0 -> (* RegexListNil *)
        true
and method28 (v0 : UH4, v1 : UH4) : bool =
    match v0 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH3 = method12(v2)
        let v5 : bool = method22(v4, v1)
        if v5 then
            method28(v3, v1)
        else
            false
    | UH4_0 -> (* RegexListNil *)
        true
and method30 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_1(v2) -> (* StateBudgetSucc *)
        let v3 : UH5 = method30(v2, v1)
        UH5_1(v3)
    | UH5_0 -> (* StateBudgetZero *)
        v1
and method29 (v0 : UH3) : UH5 =
    match v0 with
    | UH3_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH5 = method29(v6)
        let v9 : UH5 = method29(v7)
        method30(v8, v9)
    | UH3_4(v11, v12) -> (* RegexCat *)
        let v13 : UH5 = method29(v11)
        let v14 : UH5 = method29(v12)
        method30(v13, v14)
    | UH3_2(v3) -> (* RegexChar *)
        let v4 : UH5 = UH5_0
        UH5_1(v4)
    | UH3_0 -> (* RegexEmpty *)
        UH5_0
    | UH3_1 -> (* RegexEpsilon *)
        UH5_0
    | UH3_5(v16) -> (* RegexStar *)
        method29(v16)
and method31 (v0 : UH4, v1 : UH5) : bool =
    match v0 with
    | UH4_1(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH5_1(v5) -> (* StateBudgetSucc *)
            method31(v4, v5)
        | _ ->
            false
    | UH4_0 -> (* RegexListNil *)
        match v1 with
        | UH5_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
and method34 (v0 : UH3) : US3 =
    match v0 with
    | UH3_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method34(v5)
        let v8 : US3 = method34(v6)
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
        let v18 : US3 = method34(v16)
        let v19 : US3 = method34(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH3_2(v3) -> (* RegexChar *)
        US3_1
    | UH3_0 -> (* RegexEmpty *)
        US3_1
    | UH3_1 -> (* RegexEpsilon *)
        US3_0
    | UH3_5(v25) -> (* RegexStar *)
        US3_0
and method33 (v0 : UH3, v1 : US0) : UH4 =
    match v0 with
    | UH3_3(v21, v22) -> (* RegexAlt *)
        let v23 : UH4 = method33(v21, v1)
        let v24 : UH4 = method33(v22, v1)
        method20(v23, v24)
    | UH3_4(v26, v27) -> (* RegexCat *)
        let v28 : UH4 = method33(v26, v1)
        let v29 : UH4 = method23(v28, v27)
        let v30 : US3 = method34(v26)
        match v30 with
        | US3_1 -> (* NonNullable *)
            v29
        | US3_0 -> (* Nullable *)
            let v31 : UH4 = method33(v27, v1)
            method20(v29, v31)
    | UH3_2(v4) -> (* RegexChar *)
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
            let v16 : UH3 = UH3_1
            let v17 : UH4 = UH4_0
            UH4_1(v16, v17)
        else
            UH4_0
    | UH3_0 -> (* RegexEmpty *)
        UH4_0
    | UH3_1 -> (* RegexEpsilon *)
        UH4_0
    | UH3_5(v35) -> (* RegexStar *)
        let v36 : UH4 = method33(v35, v1)
        let v37 : UH3 = UH3_5(v35)
        method23(v36, v37)
and method32 (v0 : UH3, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH3 = method12(v0)
        let v5 : UH4 = method33(v4, v2)
        let v6 : UH4 = method24(v4)
        let v7 : bool = method28(v5, v6)
        if v7 then
            method32(v0, v3)
        else
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method36 (v0 : UH3, v1 : UH3, v2 : UH0) : bool =
    match v2 with
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH3 = method12(v1)
        let v6 : UH4 = method33(v5, v3)
        let v7 : UH3 = method12(v0)
        let v8 : UH4 = method19(v7)
        let v9 : UH4 = method21(v7, v8)
        let v10 : bool = method28(v6, v9)
        if v10 then
            method36(v0, v1, v4)
        else
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method35 (v0 : UH3, v1 : UH4, v2 : UH0) : bool =
    match v1 with
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = method36(v0, v3, v2)
        if v5 then
            method35(v0, v4, v2)
        else
            false
    | UH4_0 -> (* RegexListNil *)
        true
and method38 (v0 : UH4) : UH3 =
    match v0 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH3 = method38(v3)
        method13(v2, v4)
    | UH4_0 -> (* RegexListNil *)
        UH3_0
and method40 (v0 : UH3, v1 : US0) : UH3 =
    match v0 with
    | UH3_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH3 = method40(v19, v1)
        let v22 : UH3 = method40(v20, v1)
        method13(v21, v22)
    | UH3_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method34(v24)
        match v26 with
        | US3_1 -> (* NonNullable *)
            let v31 : UH3 = method40(v24, v1)
            method16(v31, v25)
        | US3_0 -> (* Nullable *)
            let v27 : UH3 = method40(v24, v1)
            let v28 : UH3 = method16(v27, v25)
            let v29 : UH3 = method40(v25, v1)
            method13(v28, v29)
    | UH3_2(v4) -> (* RegexChar *)
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
            UH3_1
        else
            UH3_0
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_5(v35) -> (* RegexStar *)
        let v36 : UH3 = method40(v35, v1)
        let v37 : UH3 = method18(v35)
        method16(v36, v37)
and method39 (v0 : UH3, v1 : US0) : UH3 =
    let v2 : UH3 = method12(v0)
    let v3 : UH3 = method40(v2, v1)
    method12(v3)
and method37 (v0 : UH3, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH3 = method12(v0)
        let v5 : UH4 = method33(v4, v2)
        let v6 : UH3 = method38(v5)
        let v7 : UH3 = method12(v6)
        let v8 : UH3 = method39(v4, v2)
        let v9 : bool = method17(v7, v8)
        if v9 then
            method37(v0, v3)
        else
            false
    | UH0_0 -> (* SymbolListNil *)
        true
and method44 (v0 : UH6, v1 : UH6) : US1 =
    match v0 with
    | UH6_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH6_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method44(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method44(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH6_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH6_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method44(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method44(v35, v41)
            | _ ->
                v42
        | UH6_2(v38) -> (* RegexChar *)
            US1_2
        | UH6_0 -> (* RegexEmpty *)
            US1_2
        | UH6_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH6_2(v10) -> (* RegexChar *)
        match v1 with
        | UH6_2(v13) -> (* RegexChar *)
            match v10 with
            | US2_0 -> (* TriA *)
                match v13 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v13 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v10 with
                    | US2_1 -> (* TriB *)
                        match v13 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v13 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        | UH6_0 -> (* RegexEmpty *)
            US1_2
        | UH6_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH6_0 -> (* RegexEmpty *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH6_1 -> (* RegexEpsilon *)
        match v1 with
        | UH6_0 -> (* RegexEmpty *)
            US1_2
        | UH6_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH6_5(v50) -> (* RegexStar *)
        match v1 with
        | UH6_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH6_5(v54) -> (* RegexStar *)
            method44(v50, v54)
        | _ ->
            US1_2
and method43 (v0 : UH6, v1 : UH6) : UH6 =
    match v1 with
    | UH6_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method44(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH6 = method43(v0, v3)
            UH6_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH6_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH6_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method44(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH6_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH6_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method42 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH6 = method43(v2, v1)
        method42(v3, v4)
    | UH6_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method43(v0, v1)
and method46 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH6_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method46(v24, v26)
            if v28 then
                method46(v25, v27)
            else
                false
        | _ ->
            false
    | UH6_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH6_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method46(v32, v34)
            if v36 then
                method46(v33, v35)
            else
                false
        | _ ->
            false
    | UH6_2(v4) -> (* RegexChar *)
        match v1 with
        | UH6_2(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US2_0 -> (* TriA *)
                    match v5 with
                    | US2_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US2_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v4 with
                        | US2_1 -> (* TriB *)
                            match v5 with
                            | US2_1 -> (* TriB *)
                                US1_1
                            | US2_2 -> (* TriC *)
                                US1_0
                        | US2_2 -> (* TriC *)
                            match v5 with
                            | US2_1 -> (* TriB *)
                                US1_2
                            | US2_2 -> (* TriC *)
                                US1_1
            match v21 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
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
    | UH6_5(v40) -> (* RegexStar *)
        match v1 with
        | UH6_5(v41) -> (* RegexStar *)
            method46(v40, v41)
        | _ ->
            false
and method45 (v0 : UH6, v1 : UH6) : UH6 =
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
                        let v14 : UH6 = method45(v13, v1)
                        UH6_4(v12, v14)
                    | UH6_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH6_5(v5) -> (* RegexStar *)
                            let v6 : bool = method46(v4, v5)
                            if v6 then
                                UH6_5(v4)
                            else
                                UH6_4(v0, v1)
                        | _ ->
                            UH6_4(v0, v1)
                    | _ ->
                        UH6_4(v0, v1)
and method47 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_0 -> (* RegexEmpty *)
        UH6_1
    | UH6_1 -> (* RegexEpsilon *)
        UH6_1
    | UH6_5(v3) -> (* RegexStar *)
        UH6_5(v3)
    | _ ->
        UH6_5(v0)
and method41 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH6 = method41(v5)
        let v8 : UH6 = method41(v6)
        method42(v7, v8)
    | UH6_4(v10, v11) -> (* RegexCat *)
        let v12 : UH6 = method41(v10)
        let v13 : UH6 = method41(v11)
        method45(v12, v13)
    | UH6_2(v3) -> (* RegexChar *)
        UH6_2(v3)
    | UH6_0 -> (* RegexEmpty *)
        UH6_0
    | UH6_1 -> (* RegexEpsilon *)
        UH6_1
    | UH6_5(v15) -> (* RegexStar *)
        let v16 : UH6 = method41(v15)
        method47(v16)
and method51 (v0 : UH6, v1 : UH7) : bool =
    match v1 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method46(v0, v2)
        if v4 then
            true
        else
            method51(v0, v3)
    | UH7_0 -> (* RegexListNil *)
        false
and method50 (v0 : UH6, v1 : UH7) : UH7 =
    let v2 : UH6 = method41(v0)
    let v3 : bool = method51(v2, v1)
    if v3 then
        v1
    else
        UH7_1(v2, v1)
and method49 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH7 = method50(v2, v1)
        method49(v3, v4)
    | UH7_0 -> (* RegexListNil *)
        v1
and method52 (v0 : UH7, v1 : UH6) : UH7 =
    match v0 with
    | UH7_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH6 = method45(v3, v1)
        let v6 : UH7 = method52(v4, v1)
        method50(v5, v6)
    | UH7_0 -> (* RegexListNil *)
        UH7_0
and method48 (v0 : UH6) : UH7 =
    match v0 with
    | UH6_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH7 = method48(v7)
        let v10 : UH7 = method48(v8)
        method49(v9, v10)
    | UH6_4(v12, v13) -> (* RegexCat *)
        let v14 : UH7 = method48(v12)
        let v15 : UH7 = method52(v14, v13)
        let v16 : UH7 = method48(v13)
        method49(v15, v16)
    | UH6_2(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_1
        let v5 : UH7 = UH7_0
        UH7_1(v4, v5)
    | UH6_0 -> (* RegexEmpty *)
        UH7_0
    | UH6_1 -> (* RegexEpsilon *)
        UH7_0
    | UH6_5(v18) -> (* RegexStar *)
        let v19 : UH7 = method48(v18)
        let v20 : UH6 = UH6_5(v18)
        method52(v19, v20)
and method54 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH7 = method54(v3, v1)
        UH7_1(v2, v4)
    | UH7_0 -> (* RegexListNil *)
        v1
and method55 (v0 : UH7, v1 : UH6) : UH7 =
    match v0 with
    | UH7_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH6 = method45(v3, v1)
        let v6 : UH6 = method41(v5)
        let v7 : UH7 = method55(v4, v1)
        UH7_1(v6, v7)
    | UH7_0 -> (* RegexListNil *)
        UH7_0
and method53 (v0 : UH6) : UH7 =
    match v0 with
    | UH6_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH7 = method53(v7)
        let v10 : UH7 = method53(v8)
        method54(v9, v10)
    | UH6_4(v12, v13) -> (* RegexCat *)
        let v14 : UH7 = method53(v12)
        let v15 : UH7 = method55(v14, v13)
        let v16 : UH7 = method53(v13)
        method54(v15, v16)
    | UH6_2(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_1
        let v5 : UH7 = UH7_0
        UH7_1(v4, v5)
    | UH6_0 -> (* RegexEmpty *)
        UH7_0
    | UH6_1 -> (* RegexEpsilon *)
        UH7_0
    | UH6_5(v18) -> (* RegexStar *)
        let v19 : UH7 = method53(v18)
        let v20 : UH6 = UH6_5(v18)
        method55(v19, v20)
and method56 (v0 : UH7) : bool =
    match v0 with
    | UH7_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = method51(v1, v2)
        if v3 then
            false
        else
            method56(v2)
    | UH7_0 -> (* RegexListNil *)
        true
and method57 (v0 : UH7, v1 : UH7) : bool =
    match v0 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH6 = method41(v2)
        let v5 : bool = method51(v4, v1)
        if v5 then
            method57(v3, v1)
        else
            false
    | UH7_0 -> (* RegexListNil *)
        true
and method58 (v0 : UH6) : UH5 =
    match v0 with
    | UH6_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH5 = method58(v6)
        let v9 : UH5 = method58(v7)
        method30(v8, v9)
    | UH6_4(v11, v12) -> (* RegexCat *)
        let v13 : UH5 = method58(v11)
        let v14 : UH5 = method58(v12)
        method30(v13, v14)
    | UH6_2(v3) -> (* RegexChar *)
        let v4 : UH5 = UH5_0
        UH5_1(v4)
    | UH6_0 -> (* RegexEmpty *)
        UH5_0
    | UH6_1 -> (* RegexEpsilon *)
        UH5_0
    | UH6_5(v16) -> (* RegexStar *)
        method58(v16)
and method59 (v0 : UH7, v1 : UH5) : bool =
    match v0 with
    | UH7_1(v3, v4) -> (* RegexListCons *)
        match v1 with
        | UH5_1(v5) -> (* StateBudgetSucc *)
            method59(v4, v5)
        | _ ->
            false
    | UH7_0 -> (* RegexListNil *)
        match v1 with
        | UH5_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
and method62 (v0 : UH6) : US3 =
    match v0 with
    | UH6_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method62(v5)
        let v8 : US3 = method62(v6)
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
        let v18 : US3 = method62(v16)
        let v19 : US3 = method62(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH6_2(v3) -> (* RegexChar *)
        US3_1
    | UH6_0 -> (* RegexEmpty *)
        US3_1
    | UH6_1 -> (* RegexEpsilon *)
        US3_0
    | UH6_5(v25) -> (* RegexStar *)
        US3_0
and method61 (v0 : UH6, v1 : US2) : UH7 =
    match v0 with
    | UH6_3(v27, v28) -> (* RegexAlt *)
        let v29 : UH7 = method61(v27, v1)
        let v30 : UH7 = method61(v28, v1)
        method49(v29, v30)
    | UH6_4(v32, v33) -> (* RegexCat *)
        let v34 : UH7 = method61(v32, v1)
        let v35 : UH7 = method52(v34, v33)
        let v36 : US3 = method62(v32)
        match v36 with
        | US3_1 -> (* NonNullable *)
            v35
        | US3_0 -> (* Nullable *)
            let v37 : UH7 = method61(v33, v1)
            method49(v35, v37)
    | UH6_2(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US2_0 -> (* TriA *)
                match v1 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v1 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v4 with
                    | US2_1 -> (* TriB *)
                        match v1 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v1 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        let v21 : bool =
            match v20 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            let v22 : UH6 = UH6_1
            let v23 : UH7 = UH7_0
            UH7_1(v22, v23)
        else
            UH7_0
    | UH6_0 -> (* RegexEmpty *)
        UH7_0
    | UH6_1 -> (* RegexEpsilon *)
        UH7_0
    | UH6_5(v41) -> (* RegexStar *)
        let v42 : UH7 = method61(v41, v1)
        let v43 : UH6 = UH6_5(v41)
        method52(v42, v43)
and method60 (v0 : UH6, v1 : UH2) : bool =
    match v1 with
    | UH2_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH6 = method41(v0)
        let v5 : UH7 = method61(v4, v2)
        let v6 : UH7 = method53(v4)
        let v7 : bool = method57(v5, v6)
        if v7 then
            method60(v0, v3)
        else
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method64 (v0 : UH6, v1 : UH6, v2 : UH2) : bool =
    match v2 with
    | UH2_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH6 = method41(v1)
        let v6 : UH7 = method61(v5, v3)
        let v7 : UH6 = method41(v0)
        let v8 : UH7 = method48(v7)
        let v9 : UH7 = method50(v7, v8)
        let v10 : bool = method57(v6, v9)
        if v10 then
            method64(v0, v1, v4)
        else
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method63 (v0 : UH6, v1 : UH7, v2 : UH2) : bool =
    match v1 with
    | UH7_1(v3, v4) -> (* RegexListCons *)
        let v5 : bool = method64(v0, v3, v2)
        if v5 then
            method63(v0, v4, v2)
        else
            false
    | UH7_0 -> (* RegexListNil *)
        true
and method66 (v0 : UH7) : UH6 =
    match v0 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH6 = method66(v3)
        method42(v2, v4)
    | UH7_0 -> (* RegexListNil *)
        UH6_0
and method68 (v0 : UH6, v1 : US2) : UH6 =
    match v0 with
    | UH6_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH6 = method68(v25, v1)
        let v28 : UH6 = method68(v26, v1)
        method42(v27, v28)
    | UH6_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method62(v30)
        match v32 with
        | US3_1 -> (* NonNullable *)
            let v37 : UH6 = method68(v30, v1)
            method45(v37, v31)
        | US3_0 -> (* Nullable *)
            let v33 : UH6 = method68(v30, v1)
            let v34 : UH6 = method45(v33, v31)
            let v35 : UH6 = method68(v31, v1)
            method42(v34, v35)
    | UH6_2(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US2_0 -> (* TriA *)
                match v1 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v1 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v4 with
                    | US2_1 -> (* TriB *)
                        match v1 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v1 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        let v21 : bool =
            match v20 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH6_1
        else
            UH6_0
    | UH6_0 -> (* RegexEmpty *)
        UH6_0
    | UH6_1 -> (* RegexEpsilon *)
        UH6_0
    | UH6_5(v41) -> (* RegexStar *)
        let v42 : UH6 = method68(v41, v1)
        let v43 : UH6 = method47(v41)
        method45(v42, v43)
and method67 (v0 : UH6, v1 : US2) : UH6 =
    let v2 : UH6 = method41(v0)
    let v3 : UH6 = method68(v2, v1)
    method41(v3)
and method65 (v0 : UH6, v1 : UH2) : bool =
    match v1 with
    | UH2_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH6 = method41(v0)
        let v5 : UH7 = method61(v4, v2)
        let v6 : UH6 = method66(v5)
        let v7 : UH6 = method41(v6)
        let v8 : UH6 = method67(v4, v2)
        let v9 : bool = method46(v7, v8)
        if v9 then
            method65(v0, v3)
        else
            false
    | UH2_0 -> (* SymbolListNil *)
        true
and method69 (v0 : UH0) : UH4 =
    match v0 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = method69(v3)
        let v5 : UH3 = UH3_2(v2)
        UH4_1(v5, v4)
    | UH0_0 -> (* SymbolListNil *)
        UH4_0
and method70 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = method70(v3)
        let v5 : UH3 = UH3_5(v2)
        UH4_1(v5, v4)
    | UH4_0 -> (* RegexListNil *)
        UH4_0
and method72 (v0 : UH3, v1 : UH4) : UH4 =
    match v1 with
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = method72(v0, v4)
        let v6 : UH3 = UH3_3(v0, v3)
        let v7 : UH3 = UH3_4(v0, v3)
        let v8 : UH4 = UH4_1(v7, v5)
        UH4_1(v6, v8)
    | UH4_0 -> (* RegexListNil *)
        UH4_0
and method73 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = method73(v3, v1)
        UH4_1(v2, v4)
    | UH4_0 -> (* RegexListNil *)
        v1
and method71 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = method72(v3, v1)
        let v6 : UH4 = method71(v4, v1)
        method73(v5, v6)
    | UH4_0 -> (* RegexListNil *)
        UH4_0
and method74 (v0 : UH2) : UH7 =
    match v0 with
    | UH2_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH7 = method74(v3)
        let v5 : UH6 = UH6_2(v2)
        UH7_1(v5, v4)
    | UH2_0 -> (* SymbolListNil *)
        UH7_0
and method75 (v0 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH7 = method75(v3)
        let v5 : UH6 = UH6_5(v2)
        UH7_1(v5, v4)
    | UH7_0 -> (* RegexListNil *)
        UH7_0
and method77 (v0 : UH6, v1 : UH7) : UH7 =
    match v1 with
    | UH7_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH7 = method77(v0, v4)
        let v6 : UH6 = UH6_3(v0, v3)
        let v7 : UH6 = UH6_4(v0, v3)
        let v8 : UH7 = UH7_1(v7, v5)
        UH7_1(v6, v8)
    | UH7_0 -> (* RegexListNil *)
        UH7_0
and method78 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH7 = method78(v3, v1)
        UH7_1(v2, v4)
    | UH7_0 -> (* RegexListNil *)
        v1
and method76 (v0 : UH7, v1 : UH7) : UH7 =
    match v0 with
    | UH7_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH7 = method77(v3, v1)
        let v6 : UH7 = method76(v4, v1)
        method78(v5, v6)
    | UH7_0 -> (* RegexListNil *)
        UH7_0
and method79 (v0 : UH4) : bool =
    match v0 with
    | UH4_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH3 = method12(v1)
        let v4 : UH4 = method19(v3)
        let v5 : UH4 = method21(v3, v4)
        let v6 : US0 = US0_0
        let v7 : US0 = US0_1
        let v8 : UH0 = UH0_0
        let v9 : UH0 = UH0_1(v7, v8)
        let v10 : UH0 = UH0_1(v6, v9)
        let v11 : bool = method0(v10)
        let v18 : bool =
            if v11 then
                let v12 : US0 = US0_0
                let v13 : US0 = US0_1
                let v14 : UH0 = UH0_0
                let v15 : UH0 = UH0_1(v13, v14)
                let v16 : UH0 = UH0_1(v12, v15)
                method2(v16)
            else
                false
        let v50 : bool =
            if v18 then
                let v19 : US0 = US0_0
                let v20 : US0 = US0_1
                let v21 : UH0 = UH0_0
                let v22 : UH0 = UH0_1(v20, v21)
                let v23 : UH0 = UH0_1(v19, v22)
                let v24 : UH1 = UH1_0
                let v25 : UH1 = UH1_1(v24)
                let v26 : UH1 = UH1_1(v25)
                let v27 : bool = method4(v23, v26)
                let v37 : bool =
                    if v27 then
                        let v28 : US0 = US0_0
                        let v29 : US0 = US0_1
                        let v30 : UH0 = UH0_0
                        let v31 : UH0 = UH0_1(v29, v30)
                        let v32 : UH0 = UH0_1(v28, v31)
                        let v33 : UH1 = UH1_0
                        let v34 : UH1 = UH1_1(v33)
                        let v35 : UH1 = UH1_1(v34)
                        method4(v32, v35)
                    else
                        false
                if v37 then
                    let v38 : US0 = US0_0
                    let v39 : US0 = US0_1
                    let v40 : UH0 = UH0_0
                    let v41 : UH0 = UH0_1(v39, v40)
                    let v42 : UH0 = UH0_1(v38, v41)
                    let v43 : US0 = US0_0
                    let v44 : US0 = US0_1
                    let v45 : UH0 = UH0_0
                    let v46 : UH0 = UH0_1(v44, v45)
                    let v47 : UH0 = UH0_1(v43, v46)
                    method5(v42, v47)
                else
                    false
            else
                false
        let v95 : bool =
            if v50 then
                let v51 : UH3 = method12(v1)
                let v52 : UH4 = method24(v51)
                let v53 : UH3 = method12(v1)
                let v54 : UH4 = method19(v53)
                let v55 : UH3 = method12(v53)
                let v56 : UH4 = method19(v55)
                let v57 : UH4 = method21(v55, v56)
                let v58 : bool = method27(v57)
                let v60 : bool =
                    if v58 then
                        method28(v54, v52)
                    else
                        false
                let v62 : bool =
                    if v60 then
                        method28(v52, v54)
                    else
                        false
                let v65 : bool =
                    if v62 then
                        let v63 : UH4 = UH4_1(v53, v52)
                        method28(v57, v63)
                    else
                        false
                let v68 : bool =
                    if v65 then
                        let v66 : UH5 = method29(v53)
                        method31(v52, v66)
                    else
                        false
                let v73 : bool =
                    if v68 then
                        let v69 : UH4 = UH4_1(v53, v52)
                        let v70 : UH5 = method29(v53)
                        let v71 : UH5 = UH5_1(v70)
                        method31(v69, v71)
                    else
                        false
                if v73 then
                    let v74 : US0 = US0_0
                    let v75 : US0 = US0_1
                    let v76 : UH0 = UH0_0
                    let v77 : UH0 = UH0_1(v75, v76)
                    let v78 : UH0 = UH0_1(v74, v77)
                    let v79 : bool = method32(v1, v78)
                    if v79 then
                        let v80 : US0 = US0_0
                        let v81 : US0 = US0_1
                        let v82 : UH0 = UH0_0
                        let v83 : UH0 = UH0_1(v81, v82)
                        let v84 : UH0 = UH0_1(v80, v83)
                        let v85 : bool = method35(v1, v5, v84)
                        if v85 then
                            let v86 : US0 = US0_0
                            let v87 : US0 = US0_1
                            let v88 : UH0 = UH0_0
                            let v89 : UH0 = UH0_1(v87, v88)
                            let v90 : UH0 = UH0_1(v86, v89)
                            method37(v1, v90)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v95 then
            method79(v2)
        else
            false
    | UH4_0 -> (* RegexListNil *)
        true
and method80 (v0 : UH7) : bool =
    match v0 with
    | UH7_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH6 = method41(v1)
        let v4 : UH7 = method48(v3)
        let v5 : UH7 = method50(v3, v4)
        let v6 : US2 = US2_0
        let v7 : US2 = US2_1
        let v8 : US2 = US2_2
        let v9 : UH2 = UH2_0
        let v10 : UH2 = UH2_1(v8, v9)
        let v11 : UH2 = UH2_1(v7, v10)
        let v12 : UH2 = UH2_1(v6, v11)
        let v13 : bool = method6(v12)
        let v22 : bool =
            if v13 then
                let v14 : US2 = US2_0
                let v15 : US2 = US2_1
                let v16 : US2 = US2_2
                let v17 : UH2 = UH2_0
                let v18 : UH2 = UH2_1(v16, v17)
                let v19 : UH2 = UH2_1(v15, v18)
                let v20 : UH2 = UH2_1(v14, v19)
                method8(v20)
            else
                false
        let v64 : bool =
            if v22 then
                let v23 : US2 = US2_0
                let v24 : US2 = US2_1
                let v25 : US2 = US2_2
                let v26 : UH2 = UH2_0
                let v27 : UH2 = UH2_1(v25, v26)
                let v28 : UH2 = UH2_1(v24, v27)
                let v29 : UH2 = UH2_1(v23, v28)
                let v30 : UH1 = UH1_0
                let v31 : UH1 = UH1_1(v30)
                let v32 : UH1 = UH1_1(v31)
                let v33 : UH1 = UH1_1(v32)
                let v34 : bool = method10(v29, v33)
                let v47 : bool =
                    if v34 then
                        let v35 : US2 = US2_0
                        let v36 : US2 = US2_1
                        let v37 : US2 = US2_2
                        let v38 : UH2 = UH2_0
                        let v39 : UH2 = UH2_1(v37, v38)
                        let v40 : UH2 = UH2_1(v36, v39)
                        let v41 : UH2 = UH2_1(v35, v40)
                        let v42 : UH1 = UH1_0
                        let v43 : UH1 = UH1_1(v42)
                        let v44 : UH1 = UH1_1(v43)
                        let v45 : UH1 = UH1_1(v44)
                        method10(v41, v45)
                    else
                        false
                if v47 then
                    let v48 : US2 = US2_0
                    let v49 : US2 = US2_1
                    let v50 : US2 = US2_2
                    let v51 : UH2 = UH2_0
                    let v52 : UH2 = UH2_1(v50, v51)
                    let v53 : UH2 = UH2_1(v49, v52)
                    let v54 : UH2 = UH2_1(v48, v53)
                    let v55 : US2 = US2_0
                    let v56 : US2 = US2_1
                    let v57 : US2 = US2_2
                    let v58 : UH2 = UH2_0
                    let v59 : UH2 = UH2_1(v57, v58)
                    let v60 : UH2 = UH2_1(v56, v59)
                    let v61 : UH2 = UH2_1(v55, v60)
                    method11(v54, v61)
                else
                    false
            else
                false
        let v115 : bool =
            if v64 then
                let v65 : UH6 = method41(v1)
                let v66 : UH7 = method53(v65)
                let v67 : UH6 = method41(v1)
                let v68 : UH7 = method48(v67)
                let v69 : UH6 = method41(v67)
                let v70 : UH7 = method48(v69)
                let v71 : UH7 = method50(v69, v70)
                let v72 : bool = method56(v71)
                let v74 : bool =
                    if v72 then
                        method57(v68, v66)
                    else
                        false
                let v76 : bool =
                    if v74 then
                        method57(v66, v68)
                    else
                        false
                let v79 : bool =
                    if v76 then
                        let v77 : UH7 = UH7_1(v67, v66)
                        method57(v71, v77)
                    else
                        false
                let v82 : bool =
                    if v79 then
                        let v80 : UH5 = method58(v67)
                        method59(v66, v80)
                    else
                        false
                let v87 : bool =
                    if v82 then
                        let v83 : UH7 = UH7_1(v67, v66)
                        let v84 : UH5 = method58(v67)
                        let v85 : UH5 = UH5_1(v84)
                        method59(v83, v85)
                    else
                        false
                if v87 then
                    let v88 : US2 = US2_0
                    let v89 : US2 = US2_1
                    let v90 : US2 = US2_2
                    let v91 : UH2 = UH2_0
                    let v92 : UH2 = UH2_1(v90, v91)
                    let v93 : UH2 = UH2_1(v89, v92)
                    let v94 : UH2 = UH2_1(v88, v93)
                    let v95 : bool = method60(v1, v94)
                    if v95 then
                        let v96 : US2 = US2_0
                        let v97 : US2 = US2_1
                        let v98 : US2 = US2_2
                        let v99 : UH2 = UH2_0
                        let v100 : UH2 = UH2_1(v98, v99)
                        let v101 : UH2 = UH2_1(v97, v100)
                        let v102 : UH2 = UH2_1(v96, v101)
                        let v103 : bool = method63(v1, v5, v102)
                        if v103 then
                            let v104 : US2 = US2_0
                            let v105 : US2 = US2_1
                            let v106 : US2 = US2_2
                            let v107 : UH2 = UH2_0
                            let v108 : UH2 = UH2_1(v106, v107)
                            let v109 : UH2 = UH2_1(v105, v108)
                            let v110 : UH2 = UH2_1(v104, v109)
                            method65(v1, v110)
                        else
                            false
                    else
                        false
                else
                    false
            else
                false
        if v115 then
            method80(v2)
        else
            false
    | UH7_0 -> (* RegexListNil *)
        true
and method81 (v0 : UH3, v1 : US0) : UH3 =
    match v0 with
    | UH3_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH3 = method81(v19, v1)
        let v22 : UH3 = method81(v20, v1)
        UH3_3(v21, v22)
    | UH3_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method34(v24)
        match v26 with
        | US3_1 -> (* NonNullable *)
            let v31 : UH3 = method81(v24, v1)
            UH3_4(v31, v25)
        | US3_0 -> (* Nullable *)
            let v27 : UH3 = method81(v24, v1)
            let v28 : UH3 = method81(v25, v1)
            let v29 : UH3 = UH3_4(v27, v25)
            UH3_3(v29, v28)
    | UH3_2(v4) -> (* RegexChar *)
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
            UH3_1
        else
            UH3_0
    | UH3_0 -> (* RegexEmpty *)
        UH3_0
    | UH3_1 -> (* RegexEpsilon *)
        UH3_0
    | UH3_5(v35) -> (* RegexStar *)
        let v36 : UH3 = method81(v35, v1)
        let v37 : UH3 = UH3_5(v35)
        UH3_4(v36, v37)
and method83 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_1 -> (* BitOne *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US1_1
                | US0_0 -> (* BitZero *)
                    US1_2
            | US0_0 -> (* BitZero *)
                match v2 with
                | US0_1 -> (* BitOne *)
                    US1_0
                | US0_0 -> (* BitZero *)
                    US1_1
        let v14 : bool =
            match v13 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v14 then
            true
        else
            method83(v0, v3)
    | UH0_0 -> (* SymbolListNil *)
        false
and method82 (v0 : UH8, v1 : UH0) : bool =
    match v0 with
    | UH8_1(v2, v3) -> (* InputCons *)
        let v4 : bool = method83(v2, v1)
        if v4 then
            method82(v3, v1)
        else
            false
    | UH8_0 -> (* InputEmpty *)
        true
and method84 (v0 : UH6, v1 : US2) : UH6 =
    match v0 with
    | UH6_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH6 = method84(v25, v1)
        let v28 : UH6 = method84(v26, v1)
        UH6_3(v27, v28)
    | UH6_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method62(v30)
        match v32 with
        | US3_1 -> (* NonNullable *)
            let v37 : UH6 = method84(v30, v1)
            UH6_4(v37, v31)
        | US3_0 -> (* Nullable *)
            let v33 : UH6 = method84(v30, v1)
            let v34 : UH6 = method84(v31, v1)
            let v35 : UH6 = UH6_4(v33, v31)
            UH6_3(v35, v34)
    | UH6_2(v4) -> (* RegexChar *)
        let v20 : US1 =
            match v4 with
            | US2_0 -> (* TriA *)
                match v1 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v1 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v4 with
                    | US2_1 -> (* TriB *)
                        match v1 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v1 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        let v21 : bool =
            match v20 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH6_1
        else
            UH6_0
    | UH6_0 -> (* RegexEmpty *)
        UH6_0
    | UH6_1 -> (* RegexEpsilon *)
        UH6_0
    | UH6_5(v41) -> (* RegexStar *)
        let v42 : UH6 = method84(v41, v1)
        let v43 : UH6 = UH6_5(v41)
        UH6_4(v42, v43)
and method86 (v0 : US2, v1 : UH2) : bool =
    match v1 with
    | UH2_1(v2, v3) -> (* SymbolListCons *)
        let v19 : US1 =
            match v0 with
            | US2_0 -> (* TriA *)
                match v2 with
                | US2_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v2 with
                | US2_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v0 with
                    | US2_1 -> (* TriB *)
                        match v2 with
                        | US2_1 -> (* TriB *)
                            US1_1
                        | US2_2 -> (* TriC *)
                            US1_0
                    | US2_2 -> (* TriC *)
                        match v2 with
                        | US2_1 -> (* TriB *)
                            US1_2
                        | US2_2 -> (* TriC *)
                            US1_1
        let v20 : bool =
            match v19 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v20 then
            true
        else
            method86(v0, v3)
    | UH2_0 -> (* SymbolListNil *)
        false
and method85 (v0 : UH9, v1 : UH2) : bool =
    match v0 with
    | UH9_1(v2, v3) -> (* InputCons *)
        let v4 : bool = method86(v2, v1)
        if v4 then
            method85(v3, v1)
        else
            false
    | UH9_0 -> (* InputEmpty *)
        true
let v0 : US0 = US0_0
let v1 : US0 = US0_1
let v2 : UH0 = UH0_0
let v3 : UH0 = UH0_1(v1, v2)
let v4 : UH0 = UH0_1(v0, v3)
let v5 : bool = method0(v4)
let v12 : bool =
    if v5 then
        let v6 : US0 = US0_0
        let v7 : US0 = US0_1
        let v8 : UH0 = UH0_0
        let v9 : UH0 = UH0_1(v7, v8)
        let v10 : UH0 = UH0_1(v6, v9)
        method2(v10)
    else
        false
let v44 : bool =
    if v12 then
        let v13 : US0 = US0_0
        let v14 : US0 = US0_1
        let v15 : UH0 = UH0_0
        let v16 : UH0 = UH0_1(v14, v15)
        let v17 : UH0 = UH0_1(v13, v16)
        let v18 : UH1 = UH1_0
        let v19 : UH1 = UH1_1(v18)
        let v20 : UH1 = UH1_1(v19)
        let v21 : bool = method4(v17, v20)
        let v31 : bool =
            if v21 then
                let v22 : US0 = US0_0
                let v23 : US0 = US0_1
                let v24 : UH0 = UH0_0
                let v25 : UH0 = UH0_1(v23, v24)
                let v26 : UH0 = UH0_1(v22, v25)
                let v27 : UH1 = UH1_0
                let v28 : UH1 = UH1_1(v27)
                let v29 : UH1 = UH1_1(v28)
                method4(v26, v29)
            else
                false
        if v31 then
            let v32 : US0 = US0_0
            let v33 : US0 = US0_1
            let v34 : UH0 = UH0_0
            let v35 : UH0 = UH0_1(v33, v34)
            let v36 : UH0 = UH0_1(v32, v35)
            let v37 : US0 = US0_0
            let v38 : US0 = US0_1
            let v39 : UH0 = UH0_0
            let v40 : UH0 = UH0_1(v38, v39)
            let v41 : UH0 = UH0_1(v37, v40)
            method5(v36, v41)
        else
            false
    else
        false
if v44 then
    ()
else
    let v45 : string = "Antimirov certificate requires the canonical bit finite-domain descriptor"
    failwith v45
    ()
let v46 : US2 = US2_0
let v47 : US2 = US2_1
let v48 : US2 = US2_2
let v49 : UH2 = UH2_0
let v50 : UH2 = UH2_1(v48, v49)
let v51 : UH2 = UH2_1(v47, v50)
let v52 : UH2 = UH2_1(v46, v51)
let v53 : bool = method6(v52)
let v62 : bool =
    if v53 then
        let v54 : US2 = US2_0
        let v55 : US2 = US2_1
        let v56 : US2 = US2_2
        let v57 : UH2 = UH2_0
        let v58 : UH2 = UH2_1(v56, v57)
        let v59 : UH2 = UH2_1(v55, v58)
        let v60 : UH2 = UH2_1(v54, v59)
        method8(v60)
    else
        false
let v104 : bool =
    if v62 then
        let v63 : US2 = US2_0
        let v64 : US2 = US2_1
        let v65 : US2 = US2_2
        let v66 : UH2 = UH2_0
        let v67 : UH2 = UH2_1(v65, v66)
        let v68 : UH2 = UH2_1(v64, v67)
        let v69 : UH2 = UH2_1(v63, v68)
        let v70 : UH1 = UH1_0
        let v71 : UH1 = UH1_1(v70)
        let v72 : UH1 = UH1_1(v71)
        let v73 : UH1 = UH1_1(v72)
        let v74 : bool = method10(v69, v73)
        let v87 : bool =
            if v74 then
                let v75 : US2 = US2_0
                let v76 : US2 = US2_1
                let v77 : US2 = US2_2
                let v78 : UH2 = UH2_0
                let v79 : UH2 = UH2_1(v77, v78)
                let v80 : UH2 = UH2_1(v76, v79)
                let v81 : UH2 = UH2_1(v75, v80)
                let v82 : UH1 = UH1_0
                let v83 : UH1 = UH1_1(v82)
                let v84 : UH1 = UH1_1(v83)
                let v85 : UH1 = UH1_1(v84)
                method10(v81, v85)
            else
                false
        if v87 then
            let v88 : US2 = US2_0
            let v89 : US2 = US2_1
            let v90 : US2 = US2_2
            let v91 : UH2 = UH2_0
            let v92 : UH2 = UH2_1(v90, v91)
            let v93 : UH2 = UH2_1(v89, v92)
            let v94 : UH2 = UH2_1(v88, v93)
            let v95 : US2 = US2_0
            let v96 : US2 = US2_1
            let v97 : US2 = US2_2
            let v98 : UH2 = UH2_0
            let v99 : UH2 = UH2_1(v97, v98)
            let v100 : UH2 = UH2_1(v96, v99)
            let v101 : UH2 = UH2_1(v95, v100)
            method11(v94, v101)
        else
            false
    else
        false
if v104 then
    ()
else
    let v105 : string = "Antimirov certificate requires the canonical ternary finite-domain descriptor"
    failwith v105
    ()
let v106 : US0 = US0_0
let v107 : UH3 = UH3_2(v106)
let v108 : US0 = US0_1
let v109 : UH3 = UH3_2(v108)
let v110 : UH3 = UH3_3(v107, v109)
let v111 : UH3 = UH3_5(v110)
let v112 : US0 = US0_0
let v113 : UH3 = UH3_2(v112)
let v114 : UH3 = UH3_4(v111, v113)
let v115 : UH3 = method12(v114)
let v116 : UH4 = method19(v115)
let v117 : UH4 = method21(v115, v116)
let v118 : US0 = US0_0
let v119 : US0 = US0_1
let v120 : UH0 = UH0_0
let v121 : UH0 = UH0_1(v119, v120)
let v122 : UH0 = UH0_1(v118, v121)
let v123 : bool = method0(v122)
let v130 : bool =
    if v123 then
        let v124 : US0 = US0_0
        let v125 : US0 = US0_1
        let v126 : UH0 = UH0_0
        let v127 : UH0 = UH0_1(v125, v126)
        let v128 : UH0 = UH0_1(v124, v127)
        method2(v128)
    else
        false
let v162 : bool =
    if v130 then
        let v131 : US0 = US0_0
        let v132 : US0 = US0_1
        let v133 : UH0 = UH0_0
        let v134 : UH0 = UH0_1(v132, v133)
        let v135 : UH0 = UH0_1(v131, v134)
        let v136 : UH1 = UH1_0
        let v137 : UH1 = UH1_1(v136)
        let v138 : UH1 = UH1_1(v137)
        let v139 : bool = method4(v135, v138)
        let v149 : bool =
            if v139 then
                let v140 : US0 = US0_0
                let v141 : US0 = US0_1
                let v142 : UH0 = UH0_0
                let v143 : UH0 = UH0_1(v141, v142)
                let v144 : UH0 = UH0_1(v140, v143)
                let v145 : UH1 = UH1_0
                let v146 : UH1 = UH1_1(v145)
                let v147 : UH1 = UH1_1(v146)
                method4(v144, v147)
            else
                false
        if v149 then
            let v150 : US0 = US0_0
            let v151 : US0 = US0_1
            let v152 : UH0 = UH0_0
            let v153 : UH0 = UH0_1(v151, v152)
            let v154 : UH0 = UH0_1(v150, v153)
            let v155 : US0 = US0_0
            let v156 : US0 = US0_1
            let v157 : UH0 = UH0_0
            let v158 : UH0 = UH0_1(v156, v157)
            let v159 : UH0 = UH0_1(v155, v158)
            method5(v154, v159)
        else
            false
    else
        false
let v252 : bool =
    if v162 then
        let v163 : US0 = US0_0
        let v164 : UH3 = UH3_2(v163)
        let v165 : US0 = US0_1
        let v166 : UH3 = UH3_2(v165)
        let v167 : UH3 = UH3_3(v164, v166)
        let v168 : UH3 = UH3_5(v167)
        let v169 : US0 = US0_0
        let v170 : UH3 = UH3_2(v169)
        let v171 : UH3 = UH3_4(v168, v170)
        let v172 : UH3 = method12(v171)
        let v173 : UH4 = method24(v172)
        let v174 : US0 = US0_0
        let v175 : UH3 = UH3_2(v174)
        let v176 : US0 = US0_1
        let v177 : UH3 = UH3_2(v176)
        let v178 : UH3 = UH3_3(v175, v177)
        let v179 : UH3 = UH3_5(v178)
        let v180 : US0 = US0_0
        let v181 : UH3 = UH3_2(v180)
        let v182 : UH3 = UH3_4(v179, v181)
        let v183 : UH3 = method12(v182)
        let v184 : UH4 = method19(v183)
        let v185 : UH3 = method12(v183)
        let v186 : UH4 = method19(v185)
        let v187 : UH4 = method21(v185, v186)
        let v188 : bool = method27(v187)
        let v190 : bool =
            if v188 then
                method28(v184, v173)
            else
                false
        let v192 : bool =
            if v190 then
                method28(v173, v184)
            else
                false
        let v195 : bool =
            if v192 then
                let v193 : UH4 = UH4_1(v183, v173)
                method28(v187, v193)
            else
                false
        let v198 : bool =
            if v195 then
                let v196 : UH5 = method29(v183)
                method31(v173, v196)
            else
                false
        let v203 : bool =
            if v198 then
                let v199 : UH4 = UH4_1(v183, v173)
                let v200 : UH5 = method29(v183)
                let v201 : UH5 = UH5_1(v200)
                method31(v199, v201)
            else
                false
        if v203 then
            let v204 : US0 = US0_0
            let v205 : UH3 = UH3_2(v204)
            let v206 : US0 = US0_1
            let v207 : UH3 = UH3_2(v206)
            let v208 : UH3 = UH3_3(v205, v207)
            let v209 : UH3 = UH3_5(v208)
            let v210 : US0 = US0_0
            let v211 : UH3 = UH3_2(v210)
            let v212 : UH3 = UH3_4(v209, v211)
            let v213 : US0 = US0_0
            let v214 : US0 = US0_1
            let v215 : UH0 = UH0_0
            let v216 : UH0 = UH0_1(v214, v215)
            let v217 : UH0 = UH0_1(v213, v216)
            let v218 : bool = method32(v212, v217)
            if v218 then
                let v219 : US0 = US0_0
                let v220 : UH3 = UH3_2(v219)
                let v221 : US0 = US0_1
                let v222 : UH3 = UH3_2(v221)
                let v223 : UH3 = UH3_3(v220, v222)
                let v224 : UH3 = UH3_5(v223)
                let v225 : US0 = US0_0
                let v226 : UH3 = UH3_2(v225)
                let v227 : UH3 = UH3_4(v224, v226)
                let v228 : US0 = US0_0
                let v229 : US0 = US0_1
                let v230 : UH0 = UH0_0
                let v231 : UH0 = UH0_1(v229, v230)
                let v232 : UH0 = UH0_1(v228, v231)
                let v233 : bool = method35(v227, v117, v232)
                if v233 then
                    let v234 : US0 = US0_0
                    let v235 : UH3 = UH3_2(v234)
                    let v236 : US0 = US0_1
                    let v237 : UH3 = UH3_2(v236)
                    let v238 : UH3 = UH3_3(v235, v237)
                    let v239 : UH3 = UH3_5(v238)
                    let v240 : US0 = US0_0
                    let v241 : UH3 = UH3_2(v240)
                    let v242 : UH3 = UH3_4(v239, v241)
                    let v243 : US0 = US0_0
                    let v244 : US0 = US0_1
                    let v245 : UH0 = UH0_0
                    let v246 : UH0 = UH0_1(v244, v245)
                    let v247 : UH0 = UH0_1(v243, v246)
                    method37(v242, v247)
                else
                    false
            else
                false
        else
            false
    else
        false
if v252 then
    ()
else
    let v253 : string = "Brzozowski state must reconstruct from its Antimirov partial-derivative subset"
    failwith v253
    ()
let v254 : US0 = US0_0
let v255 : UH3 = UH3_2(v254)
let v256 : US0 = US0_1
let v257 : UH3 = UH3_2(v256)
let v258 : UH3 = UH3_3(v255, v257)
let v259 : UH3 = UH3_5(v258)
let v260 : US0 = US0_0
let v261 : UH3 = UH3_2(v260)
let v262 : UH3 = UH3_4(v259, v261)
let v263 : UH3 = method12(v262)
let v264 : UH4 = method24(v263)
let v271 : bool =
    match v264 with
    | UH4_1(v265, v266) -> (* RegexListCons *)
        let v267 : UH5 = method29(v263)
        let v268 : bool = method31(v266, v267)
        let v269 : bool = v268 = false
        v269
    | UH4_0 -> (* RegexListNil *)
        false
if v271 then
    ()
else
    let v272 : string = "removing one concrete bit origin must violate the exact position count"
    failwith v272
    ()
let v273 : UH4 = method24(v263)
let v309 : bool =
    match v273 with
    | UH4_1(v274, v275) -> (* RegexListCons *)
        let v276 : UH3 = method12(v263)
        let v277 : UH4 = method19(v276)
        let v278 : UH3 = method12(v276)
        let v279 : UH4 = method19(v278)
        let v280 : UH4 = method21(v278, v279)
        let v281 : bool = method27(v280)
        let v285 : bool =
            if v281 then
                let v282 : UH3 = UH3_0
                let v283 : UH4 = UH4_1(v282, v275)
                method28(v277, v283)
            else
                false
        let v289 : bool =
            if v285 then
                let v286 : UH3 = UH3_0
                let v287 : UH4 = UH4_1(v286, v275)
                method28(v287, v277)
            else
                false
        let v294 : bool =
            if v289 then
                let v290 : UH3 = UH3_0
                let v291 : UH4 = UH4_1(v290, v275)
                let v292 : UH4 = UH4_1(v276, v291)
                method28(v280, v292)
            else
                false
        let v299 : bool =
            if v294 then
                let v295 : UH3 = UH3_0
                let v296 : UH4 = UH4_1(v295, v275)
                let v297 : UH5 = method29(v276)
                method31(v296, v297)
            else
                false
        let v306 : bool =
            if v299 then
                let v300 : UH3 = UH3_0
                let v301 : UH4 = UH4_1(v300, v275)
                let v302 : UH4 = UH4_1(v276, v301)
                let v303 : UH5 = method29(v276)
                let v304 : UH5 = UH5_1(v303)
                method31(v302, v304)
            else
                false
        let v307 : bool = v306 = false
        v307
    | UH4_0 -> (* RegexListNil *)
        false
if v309 then
    ()
else
    let v310 : string = "a same-cardinality forged origin set must fail semantic origin validation"
    failwith v310
    ()
let v311 : US2 = US2_0
let v312 : UH6 = UH6_2(v311)
let v313 : UH6 = UH6_5(v312)
let v314 : UH6 = method41(v313)
let v315 : UH7 = method48(v314)
let v316 : UH7 = method50(v314, v315)
let v317 : US2 = US2_0
let v318 : US2 = US2_1
let v319 : US2 = US2_2
let v320 : UH2 = UH2_0
let v321 : UH2 = UH2_1(v319, v320)
let v322 : UH2 = UH2_1(v318, v321)
let v323 : UH2 = UH2_1(v317, v322)
let v324 : bool = method6(v323)
let v333 : bool =
    if v324 then
        let v325 : US2 = US2_0
        let v326 : US2 = US2_1
        let v327 : US2 = US2_2
        let v328 : UH2 = UH2_0
        let v329 : UH2 = UH2_1(v327, v328)
        let v330 : UH2 = UH2_1(v326, v329)
        let v331 : UH2 = UH2_1(v325, v330)
        method8(v331)
    else
        false
let v375 : bool =
    if v333 then
        let v334 : US2 = US2_0
        let v335 : US2 = US2_1
        let v336 : US2 = US2_2
        let v337 : UH2 = UH2_0
        let v338 : UH2 = UH2_1(v336, v337)
        let v339 : UH2 = UH2_1(v335, v338)
        let v340 : UH2 = UH2_1(v334, v339)
        let v341 : UH1 = UH1_0
        let v342 : UH1 = UH1_1(v341)
        let v343 : UH1 = UH1_1(v342)
        let v344 : UH1 = UH1_1(v343)
        let v345 : bool = method10(v340, v344)
        let v358 : bool =
            if v345 then
                let v346 : US2 = US2_0
                let v347 : US2 = US2_1
                let v348 : US2 = US2_2
                let v349 : UH2 = UH2_0
                let v350 : UH2 = UH2_1(v348, v349)
                let v351 : UH2 = UH2_1(v347, v350)
                let v352 : UH2 = UH2_1(v346, v351)
                let v353 : UH1 = UH1_0
                let v354 : UH1 = UH1_1(v353)
                let v355 : UH1 = UH1_1(v354)
                let v356 : UH1 = UH1_1(v355)
                method10(v352, v356)
            else
                false
        if v358 then
            let v359 : US2 = US2_0
            let v360 : US2 = US2_1
            let v361 : US2 = US2_2
            let v362 : UH2 = UH2_0
            let v363 : UH2 = UH2_1(v361, v362)
            let v364 : UH2 = UH2_1(v360, v363)
            let v365 : UH2 = UH2_1(v359, v364)
            let v366 : US2 = US2_0
            let v367 : US2 = US2_1
            let v368 : US2 = US2_2
            let v369 : UH2 = UH2_0
            let v370 : UH2 = UH2_1(v368, v369)
            let v371 : UH2 = UH2_1(v367, v370)
            let v372 : UH2 = UH2_1(v366, v371)
            method11(v365, v372)
        else
            false
    else
        false
let v441 : bool =
    if v375 then
        let v376 : US2 = US2_0
        let v377 : UH6 = UH6_2(v376)
        let v378 : UH6 = UH6_5(v377)
        let v379 : UH6 = method41(v378)
        let v380 : UH7 = method53(v379)
        let v381 : US2 = US2_0
        let v382 : UH6 = UH6_2(v381)
        let v383 : UH6 = UH6_5(v382)
        let v384 : UH6 = method41(v383)
        let v385 : UH7 = method48(v384)
        let v386 : UH6 = method41(v384)
        let v387 : UH7 = method48(v386)
        let v388 : UH7 = method50(v386, v387)
        let v389 : bool = method56(v388)
        let v391 : bool =
            if v389 then
                method57(v385, v380)
            else
                false
        let v393 : bool =
            if v391 then
                method57(v380, v385)
            else
                false
        let v396 : bool =
            if v393 then
                let v394 : UH7 = UH7_1(v384, v380)
                method57(v388, v394)
            else
                false
        let v399 : bool =
            if v396 then
                let v397 : UH5 = method58(v384)
                method59(v380, v397)
            else
                false
        let v404 : bool =
            if v399 then
                let v400 : UH7 = UH7_1(v384, v380)
                let v401 : UH5 = method58(v384)
                let v402 : UH5 = UH5_1(v401)
                method59(v400, v402)
            else
                false
        if v404 then
            let v405 : US2 = US2_0
            let v406 : UH6 = UH6_2(v405)
            let v407 : UH6 = UH6_5(v406)
            let v408 : US2 = US2_0
            let v409 : US2 = US2_1
            let v410 : US2 = US2_2
            let v411 : UH2 = UH2_0
            let v412 : UH2 = UH2_1(v410, v411)
            let v413 : UH2 = UH2_1(v409, v412)
            let v414 : UH2 = UH2_1(v408, v413)
            let v415 : bool = method60(v407, v414)
            if v415 then
                let v416 : US2 = US2_0
                let v417 : UH6 = UH6_2(v416)
                let v418 : UH6 = UH6_5(v417)
                let v419 : US2 = US2_0
                let v420 : US2 = US2_1
                let v421 : US2 = US2_2
                let v422 : UH2 = UH2_0
                let v423 : UH2 = UH2_1(v421, v422)
                let v424 : UH2 = UH2_1(v420, v423)
                let v425 : UH2 = UH2_1(v419, v424)
                let v426 : bool = method63(v418, v316, v425)
                if v426 then
                    let v427 : US2 = US2_0
                    let v428 : UH6 = UH6_2(v427)
                    let v429 : UH6 = UH6_5(v428)
                    let v430 : US2 = US2_0
                    let v431 : US2 = US2_1
                    let v432 : US2 = US2_2
                    let v433 : UH2 = UH2_0
                    let v434 : UH2 = UH2_1(v432, v433)
                    let v435 : UH2 = UH2_1(v431, v434)
                    let v436 : UH2 = UH2_1(v430, v435)
                    method65(v429, v436)
                else
                    false
            else
                false
        else
            false
    else
        false
if v441 then
    ()
else
    let v442 : string = "ternary star partial-derivative support must remain bounded and closed"
    failwith v442
    ()
let v443 : US2 = US2_0
let v444 : UH6 = UH6_2(v443)
let v445 : US2 = US2_1
let v446 : UH6 = UH6_2(v445)
let v447 : UH6 = UH6_3(v444, v446)
let v448 : UH6 = UH6_5(v447)
let v449 : US2 = US2_2
let v450 : UH6 = UH6_2(v449)
let v451 : UH6 = UH6_4(v448, v450)
let v452 : UH6 = method41(v451)
let v453 : UH7 = method48(v452)
let v454 : UH7 = method50(v452, v453)
let v455 : US2 = US2_0
let v456 : US2 = US2_1
let v457 : US2 = US2_2
let v458 : UH2 = UH2_0
let v459 : UH2 = UH2_1(v457, v458)
let v460 : UH2 = UH2_1(v456, v459)
let v461 : UH2 = UH2_1(v455, v460)
let v462 : bool = method6(v461)
let v471 : bool =
    if v462 then
        let v463 : US2 = US2_0
        let v464 : US2 = US2_1
        let v465 : US2 = US2_2
        let v466 : UH2 = UH2_0
        let v467 : UH2 = UH2_1(v465, v466)
        let v468 : UH2 = UH2_1(v464, v467)
        let v469 : UH2 = UH2_1(v463, v468)
        method8(v469)
    else
        false
let v513 : bool =
    if v471 then
        let v472 : US2 = US2_0
        let v473 : US2 = US2_1
        let v474 : US2 = US2_2
        let v475 : UH2 = UH2_0
        let v476 : UH2 = UH2_1(v474, v475)
        let v477 : UH2 = UH2_1(v473, v476)
        let v478 : UH2 = UH2_1(v472, v477)
        let v479 : UH1 = UH1_0
        let v480 : UH1 = UH1_1(v479)
        let v481 : UH1 = UH1_1(v480)
        let v482 : UH1 = UH1_1(v481)
        let v483 : bool = method10(v478, v482)
        let v496 : bool =
            if v483 then
                let v484 : US2 = US2_0
                let v485 : US2 = US2_1
                let v486 : US2 = US2_2
                let v487 : UH2 = UH2_0
                let v488 : UH2 = UH2_1(v486, v487)
                let v489 : UH2 = UH2_1(v485, v488)
                let v490 : UH2 = UH2_1(v484, v489)
                let v491 : UH1 = UH1_0
                let v492 : UH1 = UH1_1(v491)
                let v493 : UH1 = UH1_1(v492)
                let v494 : UH1 = UH1_1(v493)
                method10(v490, v494)
            else
                false
        if v496 then
            let v497 : US2 = US2_0
            let v498 : US2 = US2_1
            let v499 : US2 = US2_2
            let v500 : UH2 = UH2_0
            let v501 : UH2 = UH2_1(v499, v500)
            let v502 : UH2 = UH2_1(v498, v501)
            let v503 : UH2 = UH2_1(v497, v502)
            let v504 : US2 = US2_0
            let v505 : US2 = US2_1
            let v506 : US2 = US2_2
            let v507 : UH2 = UH2_0
            let v508 : UH2 = UH2_1(v506, v507)
            let v509 : UH2 = UH2_1(v505, v508)
            let v510 : UH2 = UH2_1(v504, v509)
            method11(v503, v510)
        else
            false
    else
        false
let v609 : bool =
    if v513 then
        let v514 : US2 = US2_0
        let v515 : UH6 = UH6_2(v514)
        let v516 : US2 = US2_1
        let v517 : UH6 = UH6_2(v516)
        let v518 : UH6 = UH6_3(v515, v517)
        let v519 : UH6 = UH6_5(v518)
        let v520 : US2 = US2_2
        let v521 : UH6 = UH6_2(v520)
        let v522 : UH6 = UH6_4(v519, v521)
        let v523 : UH6 = method41(v522)
        let v524 : UH7 = method53(v523)
        let v525 : US2 = US2_0
        let v526 : UH6 = UH6_2(v525)
        let v527 : US2 = US2_1
        let v528 : UH6 = UH6_2(v527)
        let v529 : UH6 = UH6_3(v526, v528)
        let v530 : UH6 = UH6_5(v529)
        let v531 : US2 = US2_2
        let v532 : UH6 = UH6_2(v531)
        let v533 : UH6 = UH6_4(v530, v532)
        let v534 : UH6 = method41(v533)
        let v535 : UH7 = method48(v534)
        let v536 : UH6 = method41(v534)
        let v537 : UH7 = method48(v536)
        let v538 : UH7 = method50(v536, v537)
        let v539 : bool = method56(v538)
        let v541 : bool =
            if v539 then
                method57(v535, v524)
            else
                false
        let v543 : bool =
            if v541 then
                method57(v524, v535)
            else
                false
        let v546 : bool =
            if v543 then
                let v544 : UH7 = UH7_1(v534, v524)
                method57(v538, v544)
            else
                false
        let v549 : bool =
            if v546 then
                let v547 : UH5 = method58(v534)
                method59(v524, v547)
            else
                false
        let v554 : bool =
            if v549 then
                let v550 : UH7 = UH7_1(v534, v524)
                let v551 : UH5 = method58(v534)
                let v552 : UH5 = UH5_1(v551)
                method59(v550, v552)
            else
                false
        if v554 then
            let v555 : US2 = US2_0
            let v556 : UH6 = UH6_2(v555)
            let v557 : US2 = US2_1
            let v558 : UH6 = UH6_2(v557)
            let v559 : UH6 = UH6_3(v556, v558)
            let v560 : UH6 = UH6_5(v559)
            let v561 : US2 = US2_2
            let v562 : UH6 = UH6_2(v561)
            let v563 : UH6 = UH6_4(v560, v562)
            let v564 : US2 = US2_0
            let v565 : US2 = US2_1
            let v566 : US2 = US2_2
            let v567 : UH2 = UH2_0
            let v568 : UH2 = UH2_1(v566, v567)
            let v569 : UH2 = UH2_1(v565, v568)
            let v570 : UH2 = UH2_1(v564, v569)
            let v571 : bool = method60(v563, v570)
            if v571 then
                let v572 : US2 = US2_0
                let v573 : UH6 = UH6_2(v572)
                let v574 : US2 = US2_1
                let v575 : UH6 = UH6_2(v574)
                let v576 : UH6 = UH6_3(v573, v575)
                let v577 : UH6 = UH6_5(v576)
                let v578 : US2 = US2_2
                let v579 : UH6 = UH6_2(v578)
                let v580 : UH6 = UH6_4(v577, v579)
                let v581 : US2 = US2_0
                let v582 : US2 = US2_1
                let v583 : US2 = US2_2
                let v584 : UH2 = UH2_0
                let v585 : UH2 = UH2_1(v583, v584)
                let v586 : UH2 = UH2_1(v582, v585)
                let v587 : UH2 = UH2_1(v581, v586)
                let v588 : bool = method63(v580, v454, v587)
                if v588 then
                    let v589 : US2 = US2_0
                    let v590 : UH6 = UH6_2(v589)
                    let v591 : US2 = US2_1
                    let v592 : UH6 = UH6_2(v591)
                    let v593 : UH6 = UH6_3(v590, v592)
                    let v594 : UH6 = UH6_5(v593)
                    let v595 : US2 = US2_2
                    let v596 : UH6 = UH6_2(v595)
                    let v597 : UH6 = UH6_4(v594, v596)
                    let v598 : US2 = US2_0
                    let v599 : US2 = US2_1
                    let v600 : US2 = US2_2
                    let v601 : UH2 = UH2_0
                    let v602 : UH2 = UH2_1(v600, v601)
                    let v603 : UH2 = UH2_1(v599, v602)
                    let v604 : UH2 = UH2_1(v598, v603)
                    method65(v597, v604)
                else
                    false
            else
                false
        else
            false
    else
        false
if v609 then
    ()
else
    let v610 : string = "ternary concatenation/alt/star support must remain bounded and closed"
    failwith v610
    ()
let v611 : US2 = US2_0
let v612 : UH6 = UH6_2(v611)
let v613 : US2 = US2_1
let v614 : UH6 = UH6_2(v613)
let v615 : UH6 = UH6_3(v612, v614)
let v616 : UH6 = UH6_5(v615)
let v617 : US2 = US2_2
let v618 : UH6 = UH6_2(v617)
let v619 : UH6 = UH6_4(v616, v618)
let v620 : UH6 = method41(v619)
let v621 : UH7 = method53(v620)
let v628 : bool =
    match v621 with
    | UH7_1(v622, v623) -> (* RegexListCons *)
        let v624 : UH5 = method58(v620)
        let v625 : bool = method59(v623, v624)
        let v626 : bool = v625 = false
        v626
    | UH7_0 -> (* RegexListNil *)
        false
if v628 then
    ()
else
    let v629 : string = "removing one concrete ternary origin must violate the exact position count"
    failwith v629
    ()
let v630 : US0 = US0_0
let v631 : US0 = US0_1
let v632 : UH0 = UH0_0
let v633 : UH0 = UH0_1(v631, v632)
let v634 : UH0 = UH0_1(v630, v633)
let v635 : UH4 = method69(v634)
let v636 : UH3 = UH3_0
let v637 : UH3 = UH3_1
let v638 : UH4 = UH4_1(v637, v635)
let v639 : UH4 = UH4_1(v636, v638)
let v640 : UH3 = UH3_0
let v641 : UH3 = UH3_1
let v642 : UH4 = UH4_1(v641, v635)
let v643 : UH4 = UH4_1(v640, v642)
let v644 : UH4 = method70(v643)
let v645 : UH3 = UH3_0
let v646 : UH3 = UH3_1
let v647 : UH4 = UH4_1(v646, v635)
let v648 : UH4 = UH4_1(v645, v647)
let v649 : UH3 = UH3_0
let v650 : UH3 = UH3_1
let v651 : UH4 = UH4_1(v650, v635)
let v652 : UH4 = UH4_1(v649, v651)
let v653 : UH4 = method71(v648, v652)
let v654 : UH4 = method73(v644, v653)
let v655 : UH4 = method73(v639, v654)
let v656 : US2 = US2_0
let v657 : US2 = US2_1
let v658 : US2 = US2_2
let v659 : UH2 = UH2_0
let v660 : UH2 = UH2_1(v658, v659)
let v661 : UH2 = UH2_1(v657, v660)
let v662 : UH2 = UH2_1(v656, v661)
let v663 : UH7 = method74(v662)
let v664 : UH6 = UH6_0
let v665 : UH6 = UH6_1
let v666 : UH7 = UH7_1(v665, v663)
let v667 : UH7 = UH7_1(v664, v666)
let v668 : UH6 = UH6_0
let v669 : UH6 = UH6_1
let v670 : UH7 = UH7_1(v669, v663)
let v671 : UH7 = UH7_1(v668, v670)
let v672 : UH7 = method75(v671)
let v673 : UH6 = UH6_0
let v674 : UH6 = UH6_1
let v675 : UH7 = UH7_1(v674, v663)
let v676 : UH7 = UH7_1(v673, v675)
let v677 : UH6 = UH6_0
let v678 : UH6 = UH6_1
let v679 : UH7 = UH7_1(v678, v663)
let v680 : UH7 = UH7_1(v677, v679)
let v681 : UH7 = method76(v676, v680)
let v682 : UH7 = method78(v672, v681)
let v683 : UH7 = method78(v667, v682)
let v684 : bool = method79(v655)
if v684 then
    ()
else
    let v685 : string = "depth-one bit corpus must satisfy Antimirov reconstruction, support closure and positions-plus-one bound"
    failwith v685
    ()
let v686 : bool = method80(v683)
if v686 then
    ()
else
    let v687 : string = "depth-one ternary corpus must satisfy Antimirov reconstruction, support closure and positions-plus-one bound"
    failwith v687
    ()
let v688 : US0 = US0_0
let v689 : UH3 = UH3_2(v688)
let v690 : US0 = US0_1
let v691 : UH3 = UH3_2(v690)
let v692 : UH3 = UH3_3(v689, v691)
let v693 : UH3 = UH3_5(v692)
let v694 : US0 = US0_0
let v695 : UH3 = UH3_2(v694)
let v696 : UH3 = UH3_4(v693, v695)
let v697 : UH3 = method12(v696)
let v698 : UH4 = method19(v697)
let v699 : UH4 = method21(v697, v698)
let v700 : US0 = US0_0
let v701 : US0 = US0_1
let v702 : UH0 = UH0_0
let v703 : UH0 = UH0_1(v701, v702)
let v704 : UH0 = UH0_1(v700, v703)
let v705 : bool = method0(v704)
let v712 : bool =
    if v705 then
        let v706 : US0 = US0_0
        let v707 : US0 = US0_1
        let v708 : UH0 = UH0_0
        let v709 : UH0 = UH0_1(v707, v708)
        let v710 : UH0 = UH0_1(v706, v709)
        method2(v710)
    else
        false
let v744 : bool =
    if v712 then
        let v713 : US0 = US0_0
        let v714 : US0 = US0_1
        let v715 : UH0 = UH0_0
        let v716 : UH0 = UH0_1(v714, v715)
        let v717 : UH0 = UH0_1(v713, v716)
        let v718 : UH1 = UH1_0
        let v719 : UH1 = UH1_1(v718)
        let v720 : UH1 = UH1_1(v719)
        let v721 : bool = method4(v717, v720)
        let v731 : bool =
            if v721 then
                let v722 : US0 = US0_0
                let v723 : US0 = US0_1
                let v724 : UH0 = UH0_0
                let v725 : UH0 = UH0_1(v723, v724)
                let v726 : UH0 = UH0_1(v722, v725)
                let v727 : UH1 = UH1_0
                let v728 : UH1 = UH1_1(v727)
                let v729 : UH1 = UH1_1(v728)
                method4(v726, v729)
            else
                false
        if v731 then
            let v732 : US0 = US0_0
            let v733 : US0 = US0_1
            let v734 : UH0 = UH0_0
            let v735 : UH0 = UH0_1(v733, v734)
            let v736 : UH0 = UH0_1(v732, v735)
            let v737 : US0 = US0_0
            let v738 : US0 = US0_1
            let v739 : UH0 = UH0_0
            let v740 : UH0 = UH0_1(v738, v739)
            let v741 : UH0 = UH0_1(v737, v740)
            method5(v736, v741)
        else
            false
    else
        false
let v834 : bool =
    if v744 then
        let v745 : US0 = US0_0
        let v746 : UH3 = UH3_2(v745)
        let v747 : US0 = US0_1
        let v748 : UH3 = UH3_2(v747)
        let v749 : UH3 = UH3_3(v746, v748)
        let v750 : UH3 = UH3_5(v749)
        let v751 : US0 = US0_0
        let v752 : UH3 = UH3_2(v751)
        let v753 : UH3 = UH3_4(v750, v752)
        let v754 : UH3 = method12(v753)
        let v755 : UH4 = method24(v754)
        let v756 : US0 = US0_0
        let v757 : UH3 = UH3_2(v756)
        let v758 : US0 = US0_1
        let v759 : UH3 = UH3_2(v758)
        let v760 : UH3 = UH3_3(v757, v759)
        let v761 : UH3 = UH3_5(v760)
        let v762 : US0 = US0_0
        let v763 : UH3 = UH3_2(v762)
        let v764 : UH3 = UH3_4(v761, v763)
        let v765 : UH3 = method12(v764)
        let v766 : UH4 = method19(v765)
        let v767 : UH3 = method12(v765)
        let v768 : UH4 = method19(v767)
        let v769 : UH4 = method21(v767, v768)
        let v770 : bool = method27(v769)
        let v772 : bool =
            if v770 then
                method28(v766, v755)
            else
                false
        let v774 : bool =
            if v772 then
                method28(v755, v766)
            else
                false
        let v777 : bool =
            if v774 then
                let v775 : UH4 = UH4_1(v765, v755)
                method28(v769, v775)
            else
                false
        let v780 : bool =
            if v777 then
                let v778 : UH5 = method29(v765)
                method31(v755, v778)
            else
                false
        let v785 : bool =
            if v780 then
                let v781 : UH4 = UH4_1(v765, v755)
                let v782 : UH5 = method29(v765)
                let v783 : UH5 = UH5_1(v782)
                method31(v781, v783)
            else
                false
        if v785 then
            let v786 : US0 = US0_0
            let v787 : UH3 = UH3_2(v786)
            let v788 : US0 = US0_1
            let v789 : UH3 = UH3_2(v788)
            let v790 : UH3 = UH3_3(v787, v789)
            let v791 : UH3 = UH3_5(v790)
            let v792 : US0 = US0_0
            let v793 : UH3 = UH3_2(v792)
            let v794 : UH3 = UH3_4(v791, v793)
            let v795 : US0 = US0_0
            let v796 : US0 = US0_1
            let v797 : UH0 = UH0_0
            let v798 : UH0 = UH0_1(v796, v797)
            let v799 : UH0 = UH0_1(v795, v798)
            let v800 : bool = method32(v794, v799)
            if v800 then
                let v801 : US0 = US0_0
                let v802 : UH3 = UH3_2(v801)
                let v803 : US0 = US0_1
                let v804 : UH3 = UH3_2(v803)
                let v805 : UH3 = UH3_3(v802, v804)
                let v806 : UH3 = UH3_5(v805)
                let v807 : US0 = US0_0
                let v808 : UH3 = UH3_2(v807)
                let v809 : UH3 = UH3_4(v806, v808)
                let v810 : US0 = US0_0
                let v811 : US0 = US0_1
                let v812 : UH0 = UH0_0
                let v813 : UH0 = UH0_1(v811, v812)
                let v814 : UH0 = UH0_1(v810, v813)
                let v815 : bool = method35(v809, v699, v814)
                if v815 then
                    let v816 : US0 = US0_0
                    let v817 : UH3 = UH3_2(v816)
                    let v818 : US0 = US0_1
                    let v819 : UH3 = UH3_2(v818)
                    let v820 : UH3 = UH3_3(v817, v819)
                    let v821 : UH3 = UH3_5(v820)
                    let v822 : US0 = US0_0
                    let v823 : UH3 = UH3_2(v822)
                    let v824 : UH3 = UH3_4(v821, v823)
                    let v825 : US0 = US0_0
                    let v826 : US0 = US0_1
                    let v827 : UH0 = UH0_0
                    let v828 : UH0 = UH0_1(v826, v827)
                    let v829 : UH0 = UH0_1(v825, v828)
                    method37(v824, v829)
                else
                    false
            else
                false
        else
            false
    else
        false
let v1002 : bool =
    if v834 then
        let v835 : US2 = US2_0
        let v836 : UH6 = UH6_2(v835)
        let v837 : US2 = US2_1
        let v838 : UH6 = UH6_2(v837)
        let v839 : UH6 = UH6_3(v836, v838)
        let v840 : UH6 = UH6_5(v839)
        let v841 : US2 = US2_2
        let v842 : UH6 = UH6_2(v841)
        let v843 : UH6 = UH6_4(v840, v842)
        let v844 : UH6 = method41(v843)
        let v845 : UH7 = method48(v844)
        let v846 : UH7 = method50(v844, v845)
        let v847 : US2 = US2_0
        let v848 : US2 = US2_1
        let v849 : US2 = US2_2
        let v850 : UH2 = UH2_0
        let v851 : UH2 = UH2_1(v849, v850)
        let v852 : UH2 = UH2_1(v848, v851)
        let v853 : UH2 = UH2_1(v847, v852)
        let v854 : bool = method6(v853)
        let v863 : bool =
            if v854 then
                let v855 : US2 = US2_0
                let v856 : US2 = US2_1
                let v857 : US2 = US2_2
                let v858 : UH2 = UH2_0
                let v859 : UH2 = UH2_1(v857, v858)
                let v860 : UH2 = UH2_1(v856, v859)
                let v861 : UH2 = UH2_1(v855, v860)
                method8(v861)
            else
                false
        let v905 : bool =
            if v863 then
                let v864 : US2 = US2_0
                let v865 : US2 = US2_1
                let v866 : US2 = US2_2
                let v867 : UH2 = UH2_0
                let v868 : UH2 = UH2_1(v866, v867)
                let v869 : UH2 = UH2_1(v865, v868)
                let v870 : UH2 = UH2_1(v864, v869)
                let v871 : UH1 = UH1_0
                let v872 : UH1 = UH1_1(v871)
                let v873 : UH1 = UH1_1(v872)
                let v874 : UH1 = UH1_1(v873)
                let v875 : bool = method10(v870, v874)
                let v888 : bool =
                    if v875 then
                        let v876 : US2 = US2_0
                        let v877 : US2 = US2_1
                        let v878 : US2 = US2_2
                        let v879 : UH2 = UH2_0
                        let v880 : UH2 = UH2_1(v878, v879)
                        let v881 : UH2 = UH2_1(v877, v880)
                        let v882 : UH2 = UH2_1(v876, v881)
                        let v883 : UH1 = UH1_0
                        let v884 : UH1 = UH1_1(v883)
                        let v885 : UH1 = UH1_1(v884)
                        let v886 : UH1 = UH1_1(v885)
                        method10(v882, v886)
                    else
                        false
                if v888 then
                    let v889 : US2 = US2_0
                    let v890 : US2 = US2_1
                    let v891 : US2 = US2_2
                    let v892 : UH2 = UH2_0
                    let v893 : UH2 = UH2_1(v891, v892)
                    let v894 : UH2 = UH2_1(v890, v893)
                    let v895 : UH2 = UH2_1(v889, v894)
                    let v896 : US2 = US2_0
                    let v897 : US2 = US2_1
                    let v898 : US2 = US2_2
                    let v899 : UH2 = UH2_0
                    let v900 : UH2 = UH2_1(v898, v899)
                    let v901 : UH2 = UH2_1(v897, v900)
                    let v902 : UH2 = UH2_1(v896, v901)
                    method11(v895, v902)
                else
                    false
            else
                false
        if v905 then
            let v906 : US2 = US2_0
            let v907 : UH6 = UH6_2(v906)
            let v908 : US2 = US2_1
            let v909 : UH6 = UH6_2(v908)
            let v910 : UH6 = UH6_3(v907, v909)
            let v911 : UH6 = UH6_5(v910)
            let v912 : US2 = US2_2
            let v913 : UH6 = UH6_2(v912)
            let v914 : UH6 = UH6_4(v911, v913)
            let v915 : UH6 = method41(v914)
            let v916 : UH7 = method53(v915)
            let v917 : US2 = US2_0
            let v918 : UH6 = UH6_2(v917)
            let v919 : US2 = US2_1
            let v920 : UH6 = UH6_2(v919)
            let v921 : UH6 = UH6_3(v918, v920)
            let v922 : UH6 = UH6_5(v921)
            let v923 : US2 = US2_2
            let v924 : UH6 = UH6_2(v923)
            let v925 : UH6 = UH6_4(v922, v924)
            let v926 : UH6 = method41(v925)
            let v927 : UH7 = method48(v926)
            let v928 : UH6 = method41(v926)
            let v929 : UH7 = method48(v928)
            let v930 : UH7 = method50(v928, v929)
            let v931 : bool = method56(v930)
            let v933 : bool =
                if v931 then
                    method57(v927, v916)
                else
                    false
            let v935 : bool =
                if v933 then
                    method57(v916, v927)
                else
                    false
            let v938 : bool =
                if v935 then
                    let v936 : UH7 = UH7_1(v926, v916)
                    method57(v930, v936)
                else
                    false
            let v941 : bool =
                if v938 then
                    let v939 : UH5 = method58(v926)
                    method59(v916, v939)
                else
                    false
            let v946 : bool =
                if v941 then
                    let v942 : UH7 = UH7_1(v926, v916)
                    let v943 : UH5 = method58(v926)
                    let v944 : UH5 = UH5_1(v943)
                    method59(v942, v944)
                else
                    false
            if v946 then
                let v947 : US2 = US2_0
                let v948 : UH6 = UH6_2(v947)
                let v949 : US2 = US2_1
                let v950 : UH6 = UH6_2(v949)
                let v951 : UH6 = UH6_3(v948, v950)
                let v952 : UH6 = UH6_5(v951)
                let v953 : US2 = US2_2
                let v954 : UH6 = UH6_2(v953)
                let v955 : UH6 = UH6_4(v952, v954)
                let v956 : US2 = US2_0
                let v957 : US2 = US2_1
                let v958 : US2 = US2_2
                let v959 : UH2 = UH2_0
                let v960 : UH2 = UH2_1(v958, v959)
                let v961 : UH2 = UH2_1(v957, v960)
                let v962 : UH2 = UH2_1(v956, v961)
                let v963 : bool = method60(v955, v962)
                if v963 then
                    let v964 : US2 = US2_0
                    let v965 : UH6 = UH6_2(v964)
                    let v966 : US2 = US2_1
                    let v967 : UH6 = UH6_2(v966)
                    let v968 : UH6 = UH6_3(v965, v967)
                    let v969 : UH6 = UH6_5(v968)
                    let v970 : US2 = US2_2
                    let v971 : UH6 = UH6_2(v970)
                    let v972 : UH6 = UH6_4(v969, v971)
                    let v973 : US2 = US2_0
                    let v974 : US2 = US2_1
                    let v975 : US2 = US2_2
                    let v976 : UH2 = UH2_0
                    let v977 : UH2 = UH2_1(v975, v976)
                    let v978 : UH2 = UH2_1(v974, v977)
                    let v979 : UH2 = UH2_1(v973, v978)
                    let v980 : bool = method63(v972, v846, v979)
                    if v980 then
                        let v981 : US2 = US2_0
                        let v982 : UH6 = UH6_2(v981)
                        let v983 : US2 = US2_1
                        let v984 : UH6 = UH6_2(v983)
                        let v985 : UH6 = UH6_3(v982, v984)
                        let v986 : UH6 = UH6_5(v985)
                        let v987 : US2 = US2_2
                        let v988 : UH6 = UH6_2(v987)
                        let v989 : UH6 = UH6_4(v986, v988)
                        let v990 : US2 = US2_0
                        let v991 : US2 = US2_1
                        let v992 : US2 = US2_2
                        let v993 : UH2 = UH2_0
                        let v994 : UH2 = UH2_1(v992, v993)
                        let v995 : UH2 = UH2_1(v991, v994)
                        let v996 : UH2 = UH2_1(v990, v995)
                        method65(v989, v996)
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
if v1002 then
    ()
else
    let v1003 : string = "higher-ranked Antimirov programs must execute alphabet-indexed certificates without erasing their family"
    failwith v1003
    ()
let v1004 : US0 = US0_0
let v1005 : UH3 = UH3_2(v1004)
let v1006 : UH3 = UH3_5(v1005)
let v1007 : UH3 = method12(v1006)
let v1008 : US0 = US0_0
let v1009 : UH3 = method39(v1007, v1008)
let v1010 : US0 = US0_0
let v1011 : UH3 = method81(v1007, v1010)
let v1012 : UH3 = method12(v1011)
let v1013 : US0 = US0_0
let v1014 : UH4 = method33(v1007, v1013)
let v1015 : UH3 = method38(v1014)
let v1016 : UH3 = method12(v1015)
let v1017 : US0 = US0_0
let v1018 : US0 = US0_1
let v1019 : UH0 = UH0_0
let v1020 : UH0 = UH0_1(v1018, v1019)
let v1021 : UH0 = UH0_1(v1017, v1020)
let v1022 : bool = method0(v1021)
let v1029 : bool =
    if v1022 then
        let v1023 : US0 = US0_0
        let v1024 : US0 = US0_1
        let v1025 : UH0 = UH0_0
        let v1026 : UH0 = UH0_1(v1024, v1025)
        let v1027 : UH0 = UH0_1(v1023, v1026)
        method2(v1027)
    else
        false
let v1061 : bool =
    if v1029 then
        let v1030 : US0 = US0_0
        let v1031 : US0 = US0_1
        let v1032 : UH0 = UH0_0
        let v1033 : UH0 = UH0_1(v1031, v1032)
        let v1034 : UH0 = UH0_1(v1030, v1033)
        let v1035 : UH1 = UH1_0
        let v1036 : UH1 = UH1_1(v1035)
        let v1037 : UH1 = UH1_1(v1036)
        let v1038 : bool = method4(v1034, v1037)
        let v1048 : bool =
            if v1038 then
                let v1039 : US0 = US0_0
                let v1040 : US0 = US0_1
                let v1041 : UH0 = UH0_0
                let v1042 : UH0 = UH0_1(v1040, v1041)
                let v1043 : UH0 = UH0_1(v1039, v1042)
                let v1044 : UH1 = UH1_0
                let v1045 : UH1 = UH1_1(v1044)
                let v1046 : UH1 = UH1_1(v1045)
                method4(v1043, v1046)
            else
                false
        if v1048 then
            let v1049 : US0 = US0_0
            let v1050 : US0 = US0_1
            let v1051 : UH0 = UH0_0
            let v1052 : UH0 = UH0_1(v1050, v1051)
            let v1053 : UH0 = UH0_1(v1049, v1052)
            let v1054 : US0 = US0_0
            let v1055 : US0 = US0_1
            let v1056 : UH0 = UH0_0
            let v1057 : UH0 = UH0_1(v1055, v1056)
            let v1058 : UH0 = UH0_1(v1054, v1057)
            method5(v1053, v1058)
        else
            false
    else
        false
let v1071 : bool =
    if v1061 then
        let v1062 : US0 = US0_0
        let v1063 : UH8 = UH8_0
        let v1064 : UH8 = UH8_1(v1062, v1063)
        let v1065 : US0 = US0_0
        let v1066 : US0 = US0_1
        let v1067 : UH0 = UH0_0
        let v1068 : UH0 = UH0_1(v1066, v1067)
        let v1069 : UH0 = UH0_1(v1065, v1068)
        method82(v1064, v1069)
    else
        false
let v1095 : bool =
    if v1071 then
        let v1072 : UH3 = method12(v1007)
        let v1073 : UH4 = method24(v1072)
        let v1074 : UH3 = method12(v1007)
        let v1075 : UH4 = method19(v1074)
        let v1076 : UH3 = method12(v1074)
        let v1077 : UH4 = method19(v1076)
        let v1078 : UH4 = method21(v1076, v1077)
        let v1079 : bool = method27(v1078)
        let v1081 : bool =
            if v1079 then
                method28(v1075, v1073)
            else
                false
        let v1083 : bool =
            if v1081 then
                method28(v1073, v1075)
            else
                false
        let v1086 : bool =
            if v1083 then
                let v1084 : UH4 = UH4_1(v1074, v1073)
                method28(v1078, v1084)
            else
                false
        let v1089 : bool =
            if v1086 then
                let v1087 : UH5 = method29(v1074)
                method31(v1073, v1087)
            else
                false
        if v1089 then
            let v1090 : UH4 = UH4_1(v1074, v1073)
            let v1091 : UH5 = method29(v1074)
            let v1092 : UH5 = UH5_1(v1091)
            method31(v1090, v1092)
        else
            false
    else
        false
let v1101 : bool =
    if v1095 then
        let v1096 : UH3 = method12(v1007)
        let v1097 : US0 = US0_0
        let v1098 : UH4 = method33(v1096, v1097)
        let v1099 : UH4 = method24(v1096)
        method28(v1098, v1099)
    else
        false
let v1103 : bool =
    if v1101 then
        method17(v1009, v1012)
    else
        false
let v1105 : bool =
    if v1103 then
        method17(v1009, v1016)
    else
        false
let v1110 : US4 =
    if v1105 then
        let v1106 : US0 = US0_0
        let v1107 : US5 = US5_2(v1007, v1106, v1009)
        US4_1(v1107)
    else
        US4_0
let v1113 : bool =
    match v1110 with
    | US4_0 -> (* DerivativePipelineRejected *)
        false
    | US4_1(v1111) -> (* DerivativePipelineVerified *)
        true
let v1240 : bool =
    if v1113 then
        let v1114 : US2 = US2_0
        let v1115 : UH6 = UH6_2(v1114)
        let v1116 : UH6 = UH6_5(v1115)
        let v1117 : UH6 = method41(v1116)
        let v1118 : US2 = US2_0
        let v1119 : UH6 = method67(v1117, v1118)
        let v1120 : US2 = US2_0
        let v1121 : UH6 = method84(v1117, v1120)
        let v1122 : UH6 = method41(v1121)
        let v1123 : US2 = US2_0
        let v1124 : UH7 = method61(v1117, v1123)
        let v1125 : UH6 = method66(v1124)
        let v1126 : UH6 = method41(v1125)
        let v1127 : US2 = US2_0
        let v1128 : US2 = US2_1
        let v1129 : US2 = US2_2
        let v1130 : UH2 = UH2_0
        let v1131 : UH2 = UH2_1(v1129, v1130)
        let v1132 : UH2 = UH2_1(v1128, v1131)
        let v1133 : UH2 = UH2_1(v1127, v1132)
        let v1134 : bool = method6(v1133)
        let v1143 : bool =
            if v1134 then
                let v1135 : US2 = US2_0
                let v1136 : US2 = US2_1
                let v1137 : US2 = US2_2
                let v1138 : UH2 = UH2_0
                let v1139 : UH2 = UH2_1(v1137, v1138)
                let v1140 : UH2 = UH2_1(v1136, v1139)
                let v1141 : UH2 = UH2_1(v1135, v1140)
                method8(v1141)
            else
                false
        let v1185 : bool =
            if v1143 then
                let v1144 : US2 = US2_0
                let v1145 : US2 = US2_1
                let v1146 : US2 = US2_2
                let v1147 : UH2 = UH2_0
                let v1148 : UH2 = UH2_1(v1146, v1147)
                let v1149 : UH2 = UH2_1(v1145, v1148)
                let v1150 : UH2 = UH2_1(v1144, v1149)
                let v1151 : UH1 = UH1_0
                let v1152 : UH1 = UH1_1(v1151)
                let v1153 : UH1 = UH1_1(v1152)
                let v1154 : UH1 = UH1_1(v1153)
                let v1155 : bool = method10(v1150, v1154)
                let v1168 : bool =
                    if v1155 then
                        let v1156 : US2 = US2_0
                        let v1157 : US2 = US2_1
                        let v1158 : US2 = US2_2
                        let v1159 : UH2 = UH2_0
                        let v1160 : UH2 = UH2_1(v1158, v1159)
                        let v1161 : UH2 = UH2_1(v1157, v1160)
                        let v1162 : UH2 = UH2_1(v1156, v1161)
                        let v1163 : UH1 = UH1_0
                        let v1164 : UH1 = UH1_1(v1163)
                        let v1165 : UH1 = UH1_1(v1164)
                        let v1166 : UH1 = UH1_1(v1165)
                        method10(v1162, v1166)
                    else
                        false
                if v1168 then
                    let v1169 : US2 = US2_0
                    let v1170 : US2 = US2_1
                    let v1171 : US2 = US2_2
                    let v1172 : UH2 = UH2_0
                    let v1173 : UH2 = UH2_1(v1171, v1172)
                    let v1174 : UH2 = UH2_1(v1170, v1173)
                    let v1175 : UH2 = UH2_1(v1169, v1174)
                    let v1176 : US2 = US2_0
                    let v1177 : US2 = US2_1
                    let v1178 : US2 = US2_2
                    let v1179 : UH2 = UH2_0
                    let v1180 : UH2 = UH2_1(v1178, v1179)
                    let v1181 : UH2 = UH2_1(v1177, v1180)
                    let v1182 : UH2 = UH2_1(v1176, v1181)
                    method11(v1175, v1182)
                else
                    false
            else
                false
        let v1197 : bool =
            if v1185 then
                let v1186 : US2 = US2_0
                let v1187 : UH9 = UH9_0
                let v1188 : UH9 = UH9_1(v1186, v1187)
                let v1189 : US2 = US2_0
                let v1190 : US2 = US2_1
                let v1191 : US2 = US2_2
                let v1192 : UH2 = UH2_0
                let v1193 : UH2 = UH2_1(v1191, v1192)
                let v1194 : UH2 = UH2_1(v1190, v1193)
                let v1195 : UH2 = UH2_1(v1189, v1194)
                method85(v1188, v1195)
            else
                false
        let v1221 : bool =
            if v1197 then
                let v1198 : UH6 = method41(v1117)
                let v1199 : UH7 = method53(v1198)
                let v1200 : UH6 = method41(v1117)
                let v1201 : UH7 = method48(v1200)
                let v1202 : UH6 = method41(v1200)
                let v1203 : UH7 = method48(v1202)
                let v1204 : UH7 = method50(v1202, v1203)
                let v1205 : bool = method56(v1204)
                let v1207 : bool =
                    if v1205 then
                        method57(v1201, v1199)
                    else
                        false
                let v1209 : bool =
                    if v1207 then
                        method57(v1199, v1201)
                    else
                        false
                let v1212 : bool =
                    if v1209 then
                        let v1210 : UH7 = UH7_1(v1200, v1199)
                        method57(v1204, v1210)
                    else
                        false
                let v1215 : bool =
                    if v1212 then
                        let v1213 : UH5 = method58(v1200)
                        method59(v1199, v1213)
                    else
                        false
                if v1215 then
                    let v1216 : UH7 = UH7_1(v1200, v1199)
                    let v1217 : UH5 = method58(v1200)
                    let v1218 : UH5 = UH5_1(v1217)
                    method59(v1216, v1218)
                else
                    false
            else
                false
        let v1227 : bool =
            if v1221 then
                let v1222 : UH6 = method41(v1117)
                let v1223 : US2 = US2_0
                let v1224 : UH7 = method61(v1222, v1223)
                let v1225 : UH7 = method53(v1222)
                method57(v1224, v1225)
            else
                false
        let v1229 : bool =
            if v1227 then
                method46(v1119, v1122)
            else
                false
        let v1231 : bool =
            if v1229 then
                method46(v1119, v1126)
            else
                false
        let v1236 : US6 =
            if v1231 then
                let v1232 : US2 = US2_0
                let v1233 : US7 = US7_2(v1117, v1232, v1119)
                US6_1(v1233)
            else
                US6_0
        let v1239 : bool =
            match v1236 with
            | US6_0 -> (* DerivativePipelineRejected *)
                false
            | US6_1(v1237) -> (* DerivativePipelineVerified *)
                true
        v1239
    else
        false
if v1240 then
    ()
else
    let v1241 : string = "higher-ranked derivative programs must enforce normalize-then-verify before sealing across alphabets"
    failwith v1241
    ()
let v1242 : US0 = US0_0
let v1243 : UH3 = UH3_2(v1242)
let v1244 : UH3 = UH3_5(v1243)
let v1245 : UH3 = method12(v1244)
let v1246 : string = "brzozowski-antimirov-certificate-green"
v1246
