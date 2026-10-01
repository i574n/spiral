type [<Struct>] US0 =
    | US0_0
    | US0_1
and UH0 =
    | UH0_0
    | UH0_1 of US0 * UH0
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US0
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
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
    | UH5_1
    | UH5_2 of US1
    | UH5_3 of UH5 * UH5
    | UH5_4 of UH5 * UH5
    | UH5_5 of UH5
and UH4 =
    | UH4_0
    | UH4_1 of UH5 * UH4
and [<Struct>] US2 =
    | US2_0
    | US2_1
    | US2_2
and [<Struct>] US3 =
    | US3_0
    | US3_1
let rec method0 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_0 -> (* SymbolListNil *)
        UH1_0
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH1 = method0(v3)
        let v5 : UH2 = UH2_2(v2)
        UH1_1(v5, v4)
and method1 (v0 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        UH1_0
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = method1(v3)
        let v5 : UH2 = UH2_5(v2)
        UH1_1(v5, v4)
and method3 (v0 : UH2, v1 : UH1) : UH1 =
    match v1 with
    | UH1_0 -> (* RegexListNil *)
        UH1_0
    | UH1_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH1 = method3(v0, v4)
        let v6 : UH2 = UH2_4(v0, v3)
        let v7 : UH1 = UH1_1(v6, v5)
        let v8 : UH2 = UH2_3(v0, v3)
        UH1_1(v8, v7)
and method4 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        v1
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = method4(v3, v1)
        UH1_1(v2, v4)
and method2 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        UH1_0
    | UH1_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH1 = method3(v3, v1)
        let v6 : UH1 = method2(v4, v1)
        method4(v5, v6)
and method5 (v0 : UH3) : UH4 =
    match v0 with
    | UH3_0 -> (* SymbolListNil *)
        UH4_0
    | UH3_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH4 = method5(v3)
        let v5 : UH5 = UH5_2(v2)
        UH4_1(v5, v4)
and method6 (v0 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        UH4_0
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = method6(v3)
        let v5 : UH5 = UH5_5(v2)
        UH4_1(v5, v4)
and method8 (v0 : UH5, v1 : UH4) : UH4 =
    match v1 with
    | UH4_0 -> (* RegexListNil *)
        UH4_0
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = method8(v0, v4)
        let v6 : UH5 = UH5_4(v0, v3)
        let v7 : UH4 = UH4_1(v6, v5)
        let v8 : UH5 = UH5_3(v0, v3)
        UH4_1(v8, v7)
and method9 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        v1
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH4 = method9(v3, v1)
        UH4_1(v2, v4)
and method7 (v0 : UH4, v1 : UH4) : UH4 =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        UH4_0
    | UH4_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH4 = method8(v3, v1)
        let v6 : UH4 = method7(v4, v1)
        method9(v5, v6)
and method14 (v0 : UH2, v1 : UH2) : US2 =
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
            let v57 : US2 = method14(v53, v55)
            match v57 with
            | US2_1 -> (* SymbolSame *)
                method14(v54, v56)
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
            let v36 : US2 = method14(v28, v34)
            match v36 with
            | US2_1 -> (* SymbolSame *)
                method14(v29, v35)
            | _ ->
                v36
        | _ ->
            US2_0
    | UH2_5(v44) -> (* RegexStar *)
        match v1 with
        | UH2_3(v45, v46) -> (* RegexAlt *)
            US2_0
        | UH2_5(v48) -> (* RegexStar *)
            method14(v44, v48)
        | _ ->
            US2_2
and method13 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_0 -> (* RegexEmpty *)
        v0
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method14(v0, v2)
        match v4 with
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH2 = method13(v0, v3)
            UH2_3(v2, v6)
    | _ ->
        let v11 : US2 = method14(v0, v1)
        match v11 with
        | US2_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
and method12 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        v1
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method13(v2, v1)
        method12(v3, v4)
    | _ ->
        method13(v0, v1)
and method16 (v0 : UH2, v1 : UH2) : bool =
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
            let v22 : bool = method16(v18, v20)
            if v22 then
                method16(v19, v21)
            else
                false
        | _ ->
            false
    | UH2_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH2_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method16(v26, v28)
            if v30 then
                method16(v27, v29)
            else
                false
        | _ ->
            false
    | UH2_5(v34) -> (* RegexStar *)
        match v1 with
        | UH2_5(v35) -> (* RegexStar *)
            method16(v34, v35)
        | _ ->
            false
and method15 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method15(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method16(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method17 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method11 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method11(v5)
        let v8 : UH2 = method11(v6)
        method12(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method11(v10)
        let v13 : UH2 = method11(v11)
        method15(v12, v13)
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method11(v15)
        method17(v16)
and method19 (v0 : UH2, v1 : UH2) : bool =
    match v1 with
    | UH2_0 -> (* RegexEmpty *)
        false
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method14(v0, v2)
        match v4 with
        | US2_0 -> (* SymbolLess *)
            method19(v2, v3)
        | _ ->
            false
    | _ ->
        let v7 : US2 = method14(v0, v1)
        match v7 with
        | US2_0 -> (* SymbolLess *)
            true
        | _ ->
            false
and method18 (v0 : UH2) : bool =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        true
    | UH2_1 -> (* RegexEpsilon *)
        true
    | UH2_2(v1) -> (* RegexChar *)
        true
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v7 : bool =
            match v2 with
            | UH2_0 -> (* RegexEmpty *)
                false
            | UH2_3(v4, v5) -> (* RegexAlt *)
                false
            | _ ->
                true
        let v9 : bool =
            if v7 then
                method18(v2)
            else
                false
        let v11 : bool =
            if v9 then
                method18(v3)
            else
                false
        if v11 then
            method19(v2, v3)
        else
            false
    | UH2_4(v14, v15) -> (* RegexCat *)
        let v20 : bool =
            match v14 with
            | UH2_0 -> (* RegexEmpty *)
                false
            | UH2_1 -> (* RegexEpsilon *)
                false
            | UH2_4(v16, v17) -> (* RegexCat *)
                false
            | _ ->
                true
        let v23 : bool =
            if v20 then
                match v15 with
                | UH2_0 -> (* RegexEmpty *)
                    false
                | UH2_1 -> (* RegexEpsilon *)
                    false
                | _ ->
                    true
            else
                false
        let v33 : bool =
            if v23 then
                match v14 with
                | UH2_5(v24) -> (* RegexStar *)
                    match v15 with
                    | UH2_5(v25) -> (* RegexStar *)
                        let v26 : bool = method16(v24, v25)
                        let v27 : bool = v26 = false
                        v27
                    | _ ->
                        true
                | _ ->
                    true
            else
                false
        let v35 : bool =
            if v33 then
                method18(v14)
            else
                false
        if v35 then
            method18(v15)
        else
            false
    | UH2_5(v38) -> (* RegexStar *)
        let v42 : bool =
            match v38 with
            | UH2_0 -> (* RegexEmpty *)
                false
            | UH2_1 -> (* RegexEpsilon *)
                false
            | UH2_5(v39) -> (* RegexStar *)
                false
            | _ ->
                true
        if v42 then
            method18(v38)
        else
            false
and method10 (v0 : UH1) : bool =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        true
    | UH1_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH2 = method11(v1)
        let v4 : bool = method18(v3)
        if v4 then
            method10(v2)
        else
            false
and method24 (v0 : UH5, v1 : UH5) : US2 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            US2_1
        | _ ->
            US2_0
    | UH5_1 -> (* RegexEpsilon *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            US2_2
        | UH5_1 -> (* RegexEpsilon *)
            US2_1
        | _ ->
            US2_0
    | UH5_2(v10) -> (* RegexChar *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            US2_2
        | UH5_1 -> (* RegexEpsilon *)
            US2_2
        | UH5_2(v13) -> (* RegexChar *)
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
    | UH5_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH5_3(v61, v62) -> (* RegexAlt *)
            let v63 : US2 = method24(v59, v61)
            match v63 with
            | US2_1 -> (* SymbolSame *)
                method24(v60, v62)
            | _ ->
                v63
        | _ ->
            US2_2
    | UH5_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            US2_2
        | UH5_1 -> (* RegexEpsilon *)
            US2_2
        | UH5_2(v38) -> (* RegexChar *)
            US2_2
        | UH5_4(v40, v41) -> (* RegexCat *)
            let v42 : US2 = method24(v34, v40)
            match v42 with
            | US2_1 -> (* SymbolSame *)
                method24(v35, v41)
            | _ ->
                v42
        | _ ->
            US2_0
    | UH5_5(v50) -> (* RegexStar *)
        match v1 with
        | UH5_3(v51, v52) -> (* RegexAlt *)
            US2_0
        | UH5_5(v54) -> (* RegexStar *)
            method24(v50, v54)
        | _ ->
            US2_2
and method23 (v0 : UH5, v1 : UH5) : UH5 =
    match v1 with
    | UH5_0 -> (* RegexEmpty *)
        v0
    | UH5_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method24(v0, v2)
        match v4 with
        | US2_0 -> (* SymbolLess *)
            UH5_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            let v6 : UH5 = method23(v0, v3)
            UH5_3(v2, v6)
    | _ ->
        let v11 : US2 = method24(v0, v1)
        match v11 with
        | US2_0 -> (* SymbolLess *)
            UH5_3(v0, v1)
        | US2_1 -> (* SymbolSame *)
            v1
        | US2_2 -> (* SymbolGreater *)
            UH5_3(v1, v0)
and method22 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        v1
    | UH5_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH5 = method23(v2, v1)
        method22(v3, v4)
    | _ ->
        method23(v0, v1)
and method26 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH5_1 -> (* RegexEpsilon *)
        match v1 with
        | UH5_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH5_2(v4) -> (* RegexChar *)
        match v1 with
        | UH5_2(v5) -> (* RegexChar *)
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
    | UH5_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH5_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method26(v24, v26)
            if v28 then
                method26(v25, v27)
            else
                false
        | _ ->
            false
    | UH5_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH5_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method26(v32, v34)
            if v36 then
                method26(v33, v35)
            else
                false
        | _ ->
            false
    | UH5_5(v40) -> (* RegexStar *)
        match v1 with
        | UH5_5(v41) -> (* RegexStar *)
            method26(v40, v41)
        | _ ->
            false
and method25 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        UH5_0
    | _ ->
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            UH5_0
        | _ ->
            match v0 with
            | UH5_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH5_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH5_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH5 = method25(v13, v1)
                        UH5_4(v12, v14)
                    | UH5_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH5_5(v5) -> (* RegexStar *)
                            let v6 : bool = method26(v4, v5)
                            if v6 then
                                UH5_5(v4)
                            else
                                UH5_4(v0, v1)
                        | _ ->
                            UH5_4(v0, v1)
                    | _ ->
                        UH5_4(v0, v1)
and method27 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        UH5_1
    | UH5_1 -> (* RegexEpsilon *)
        UH5_1
    | UH5_5(v3) -> (* RegexStar *)
        UH5_5(v3)
    | _ ->
        UH5_5(v0)
and method21 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        UH5_0
    | UH5_1 -> (* RegexEpsilon *)
        UH5_1
    | UH5_2(v3) -> (* RegexChar *)
        UH5_2(v3)
    | UH5_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH5 = method21(v5)
        let v8 : UH5 = method21(v6)
        method22(v7, v8)
    | UH5_4(v10, v11) -> (* RegexCat *)
        let v12 : UH5 = method21(v10)
        let v13 : UH5 = method21(v11)
        method25(v12, v13)
    | UH5_5(v15) -> (* RegexStar *)
        let v16 : UH5 = method21(v15)
        method27(v16)
and method29 (v0 : UH5, v1 : UH5) : bool =
    match v1 with
    | UH5_0 -> (* RegexEmpty *)
        false
    | UH5_3(v2, v3) -> (* RegexAlt *)
        let v4 : US2 = method24(v0, v2)
        match v4 with
        | US2_0 -> (* SymbolLess *)
            method29(v2, v3)
        | _ ->
            false
    | _ ->
        let v7 : US2 = method24(v0, v1)
        match v7 with
        | US2_0 -> (* SymbolLess *)
            true
        | _ ->
            false
and method28 (v0 : UH5) : bool =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        true
    | UH5_1 -> (* RegexEpsilon *)
        true
    | UH5_2(v1) -> (* RegexChar *)
        true
    | UH5_3(v2, v3) -> (* RegexAlt *)
        let v7 : bool =
            match v2 with
            | UH5_0 -> (* RegexEmpty *)
                false
            | UH5_3(v4, v5) -> (* RegexAlt *)
                false
            | _ ->
                true
        let v9 : bool =
            if v7 then
                method28(v2)
            else
                false
        let v11 : bool =
            if v9 then
                method28(v3)
            else
                false
        if v11 then
            method29(v2, v3)
        else
            false
    | UH5_4(v14, v15) -> (* RegexCat *)
        let v20 : bool =
            match v14 with
            | UH5_0 -> (* RegexEmpty *)
                false
            | UH5_1 -> (* RegexEpsilon *)
                false
            | UH5_4(v16, v17) -> (* RegexCat *)
                false
            | _ ->
                true
        let v23 : bool =
            if v20 then
                match v15 with
                | UH5_0 -> (* RegexEmpty *)
                    false
                | UH5_1 -> (* RegexEpsilon *)
                    false
                | _ ->
                    true
            else
                false
        let v33 : bool =
            if v23 then
                match v14 with
                | UH5_5(v24) -> (* RegexStar *)
                    match v15 with
                    | UH5_5(v25) -> (* RegexStar *)
                        let v26 : bool = method26(v24, v25)
                        let v27 : bool = v26 = false
                        v27
                    | _ ->
                        true
                | _ ->
                    true
            else
                false
        let v35 : bool =
            if v33 then
                method28(v14)
            else
                false
        if v35 then
            method28(v15)
        else
            false
    | UH5_5(v38) -> (* RegexStar *)
        let v42 : bool =
            match v38 with
            | UH5_0 -> (* RegexEmpty *)
                false
            | UH5_1 -> (* RegexEpsilon *)
                false
            | UH5_5(v39) -> (* RegexStar *)
                false
            | _ ->
                true
        if v42 then
            method28(v38)
        else
            false
and method20 (v0 : UH4) : bool =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        true
    | UH4_1(v1, v2) -> (* RegexListCons *)
        let v3 : UH5 = method21(v1)
        let v4 : bool = method28(v3)
        if v4 then
            method20(v2)
        else
            false
and method34 (v0 : UH2) : US3 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        US3_1
    | UH2_1 -> (* RegexEpsilon *)
        US3_0
    | UH2_2(v3) -> (* RegexChar *)
        US3_1
    | UH2_3(v5, v6) -> (* RegexAlt *)
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
    | UH2_4(v16, v17) -> (* RegexCat *)
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
    | UH2_5(v25) -> (* RegexStar *)
        US3_0
and method33 (v0 : UH2, v1 : US0) : UH2 =
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
        let v21 : UH2 = method33(v19, v1)
        let v22 : UH2 = method33(v20, v1)
        method12(v21, v22)
    | UH2_4(v24, v25) -> (* RegexCat *)
        let v26 : US3 = method34(v24)
        match v26 with
        | US3_0 -> (* Nullable *)
            let v27 : UH2 = method33(v24, v1)
            let v28 : UH2 = method15(v27, v25)
            let v29 : UH2 = method33(v25, v1)
            method12(v28, v29)
        | US3_1 -> (* NonNullable *)
            let v31 : UH2 = method33(v24, v1)
            method15(v31, v25)
    | UH2_5(v35) -> (* RegexStar *)
        let v36 : UH2 = method33(v35, v1)
        let v37 : UH2 = method17(v35)
        method15(v36, v37)
and method32 (v0 : UH2, v1 : US0) : UH2 =
    let v2 : UH2 = method11(v0)
    let v3 : UH2 = method33(v2, v1)
    method11(v3)
and method31 (v0 : UH2, v1 : UH0) : bool =
    match v1 with
    | UH0_0 -> (* SymbolListNil *)
        true
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH2 = method32(v0, v2)
        let v5 : bool = method18(v4)
        if v5 then
            method31(v0, v3)
        else
            false
and method30 (v0 : UH1, v1 : UH0) : bool =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        true
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method31(v2, v1)
        if v4 then
            method30(v3, v1)
        else
            false
and method39 (v0 : UH5) : US3 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        US3_1
    | UH5_1 -> (* RegexEpsilon *)
        US3_0
    | UH5_2(v3) -> (* RegexChar *)
        US3_1
    | UH5_3(v5, v6) -> (* RegexAlt *)
        let v7 : US3 = method39(v5)
        let v8 : US3 = method39(v6)
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
    | UH5_4(v16, v17) -> (* RegexCat *)
        let v18 : US3 = method39(v16)
        let v19 : US3 = method39(v17)
        match v18 with
        | US3_0 -> (* Nullable *)
            match v19 with
            | US3_0 -> (* Nullable *)
                US3_0
            | _ ->
                US3_1
        | _ ->
            US3_1
    | UH5_5(v25) -> (* RegexStar *)
        US3_0
and method38 (v0 : UH5, v1 : US1) : UH5 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        UH5_0
    | UH5_1 -> (* RegexEpsilon *)
        UH5_0
    | UH5_2(v4) -> (* RegexChar *)
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
            UH5_1
        else
            UH5_0
    | UH5_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH5 = method38(v25, v1)
        let v28 : UH5 = method38(v26, v1)
        method22(v27, v28)
    | UH5_4(v30, v31) -> (* RegexCat *)
        let v32 : US3 = method39(v30)
        match v32 with
        | US3_0 -> (* Nullable *)
            let v33 : UH5 = method38(v30, v1)
            let v34 : UH5 = method25(v33, v31)
            let v35 : UH5 = method38(v31, v1)
            method22(v34, v35)
        | US3_1 -> (* NonNullable *)
            let v37 : UH5 = method38(v30, v1)
            method25(v37, v31)
    | UH5_5(v41) -> (* RegexStar *)
        let v42 : UH5 = method38(v41, v1)
        let v43 : UH5 = method27(v41)
        method25(v42, v43)
and method37 (v0 : UH5, v1 : US1) : UH5 =
    let v2 : UH5 = method21(v0)
    let v3 : UH5 = method38(v2, v1)
    method21(v3)
and method36 (v0 : UH5, v1 : UH3) : bool =
    match v1 with
    | UH3_0 -> (* SymbolListNil *)
        true
    | UH3_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH5 = method37(v0, v2)
        let v5 : bool = method28(v4)
        if v5 then
            method36(v0, v3)
        else
            false
and method35 (v0 : UH4, v1 : UH3) : bool =
    match v0 with
    | UH4_0 -> (* RegexListNil *)
        true
    | UH4_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method36(v2, v1)
        if v4 then
            method35(v3, v1)
        else
            false
let v0 : UH0 = UH0_0
let v1 : US0 = US0_1
let v2 : UH0 = UH0_1(v1, v0)
let v3 : US0 = US0_0
let v4 : UH0 = UH0_1(v3, v2)
let v5 : UH1 = method0(v4)
let v6 : UH2 = UH2_1
let v7 : UH1 = UH1_1(v6, v5)
let v8 : UH2 = UH2_0
let v9 : UH1 = UH1_1(v8, v7)
let v10 : UH2 = UH2_1
let v11 : UH1 = UH1_1(v10, v5)
let v12 : UH2 = UH2_0
let v13 : UH1 = UH1_1(v12, v11)
let v14 : UH1 = method1(v13)
let v15 : UH2 = UH2_1
let v16 : UH1 = UH1_1(v15, v5)
let v17 : UH2 = UH2_0
let v18 : UH1 = UH1_1(v17, v16)
let v19 : UH2 = UH2_1
let v20 : UH1 = UH1_1(v19, v5)
let v21 : UH2 = UH2_0
let v22 : UH1 = UH1_1(v21, v20)
let v23 : UH1 = method2(v18, v22)
let v24 : UH1 = method4(v14, v23)
let v25 : UH1 = method4(v9, v24)
let v26 : UH3 = UH3_0
let v27 : US1 = US1_2
let v28 : UH3 = UH3_1(v27, v26)
let v29 : US1 = US1_1
let v30 : UH3 = UH3_1(v29, v28)
let v31 : US1 = US1_0
let v32 : UH3 = UH3_1(v31, v30)
let v33 : UH4 = method5(v32)
let v34 : UH5 = UH5_1
let v35 : UH4 = UH4_1(v34, v33)
let v36 : UH5 = UH5_0
let v37 : UH4 = UH4_1(v36, v35)
let v38 : UH5 = UH5_1
let v39 : UH4 = UH4_1(v38, v33)
let v40 : UH5 = UH5_0
let v41 : UH4 = UH4_1(v40, v39)
let v42 : UH4 = method6(v41)
let v43 : UH5 = UH5_1
let v44 : UH4 = UH4_1(v43, v33)
let v45 : UH5 = UH5_0
let v46 : UH4 = UH4_1(v45, v44)
let v47 : UH5 = UH5_1
let v48 : UH4 = UH4_1(v47, v33)
let v49 : UH5 = UH5_0
let v50 : UH4 = UH4_1(v49, v48)
let v51 : UH4 = method7(v46, v50)
let v52 : UH4 = method9(v42, v51)
let v53 : UH4 = method9(v37, v52)
let v54 : bool = method10(v25)
if v54 then
    ()
else
    let v55 : string = "every normalized bit corpus term must satisfy structural canonical form"
    failwith v55
    ()
let v56 : bool = method20(v53)
if v56 then
    ()
else
    let v57 : string = "every normalized ternary corpus term must satisfy structural canonical form"
    failwith v57
    ()
let v58 : UH0 = UH0_0
let v59 : US0 = US0_1
let v60 : UH0 = UH0_1(v59, v58)
let v61 : US0 = US0_0
let v62 : UH0 = UH0_1(v61, v60)
let v63 : bool = method30(v25, v62)
if v63 then
    ()
else
    let v64 : string = "every canonical bit derivative must already satisfy structural canonical form"
    failwith v64
    ()
let v65 : UH3 = UH3_0
let v66 : US1 = US1_2
let v67 : UH3 = UH3_1(v66, v65)
let v68 : US1 = US1_1
let v69 : UH3 = UH3_1(v68, v67)
let v70 : US1 = US1_0
let v71 : UH3 = UH3_1(v70, v69)
let v72 : bool = method35(v53, v71)
if v72 then
    ()
else
    let v73 : string = "every canonical ternary derivative must already satisfy structural canonical form"
    failwith v73
    ()
let v74 : US0 = US0_0
let v75 : UH2 = UH2_2(v74)
let v76 : US0 = US0_1
let v77 : UH2 = UH2_2(v76)
let v78 : UH2 = UH2_3(v77, v75)
let v79 : bool = method18(v78)
let v80 : bool = v79 = false
if v80 then
    ()
else
    let v81 : string = "unsorted alternation must not be canonical"
    failwith v81
    ()
let v82 : US0 = US0_0
let v83 : UH2 = UH2_2(v82)
let v84 : UH2 = UH2_3(v83, v83)
let v85 : bool = method18(v84)
let v86 : bool = v85 = false
if v86 then
    ()
else
    let v87 : string = "duplicate alternation must not be canonical"
    failwith v87
    ()
let v88 : UH2 = UH2_1
let v89 : US0 = US0_1
let v90 : UH2 = UH2_2(v89)
let v91 : US0 = US0_0
let v92 : UH2 = UH2_2(v91)
let v93 : UH2 = UH2_3(v92, v90)
let v94 : UH2 = UH2_3(v93, v88)
let v95 : bool = method18(v94)
let v96 : bool = v95 = false
if v96 then
    ()
else
    let v97 : string = "left-nested alternation must not be canonical"
    failwith v97
    ()
let v98 : US0 = US0_0
let v99 : UH2 = UH2_2(v98)
let v100 : UH2 = UH2_1
let v101 : UH2 = UH2_4(v100, v99)
let v102 : bool = method18(v101)
let v103 : bool = v102 = false
if v103 then
    ()
else
    let v104 : string = "epsilon concatenation identity must not remain in canonical form"
    failwith v104
    ()
let v105 : US0 = US0_0
let v106 : UH2 = UH2_2(v105)
let v107 : US0 = US0_1
let v108 : UH2 = UH2_2(v107)
let v109 : UH2 = UH2_4(v106, v108)
let v110 : UH2 = UH2_4(v109, v106)
let v111 : bool = method18(v110)
let v112 : bool = v111 = false
if v112 then
    ()
else
    let v113 : string = "left-associated concatenation must not remain in canonical form"
    failwith v113
    ()
let v114 : UH2 = UH2_0
let v115 : UH2 = UH2_5(v114)
let v116 : bool = method18(v115)
let v117 : bool = v116 = false
if v117 then
    ()
else
    let v118 : string = "star of empty must not remain in canonical form"
    failwith v118
    ()
let v119 : US0 = US0_0
let v120 : UH2 = UH2_2(v119)
let v121 : UH2 = UH2_5(v120)
let v122 : UH2 = UH2_5(v121)
let v123 : bool = method18(v122)
let v124 : bool = v123 = false
if v124 then
    ()
else
    let v125 : string = "nested star must not remain in canonical form"
    failwith v125
    ()
let v126 : US0 = US0_0
let v127 : UH2 = UH2_2(v126)
let v128 : UH2 = UH2_5(v127)
let v129 : UH2 = UH2_4(v128, v128)
let v130 : bool = method18(v129)
let v131 : bool = v130 = false
if v131 then
    ()
else
    let v132 : string = "duplicate adjacent stars must be reduced in canonical form"
    failwith v132
    ()
let v133 : US0 = US0_0
let v134 : UH2 = UH2_2(v133)
let v135 : US0 = US0_1
let v136 : UH2 = UH2_2(v135)
let v137 : UH2 = UH2_3(v136, v134)
let v138 : UH2 = method11(v137)
let v139 : bool = method18(v138)
if v139 then
    ()
else
    let v140 : string = "normalization must repair unsorted alternation"
    failwith v140
    ()
let v141 : US0 = US0_0
let v142 : UH2 = UH2_2(v141)
let v143 : UH2 = UH2_3(v142, v142)
let v144 : UH2 = method11(v143)
let v145 : bool = method18(v144)
if v145 then
    ()
else
    let v146 : string = "normalization must remove duplicate alternation"
    failwith v146
    ()
let v147 : US0 = US0_0
let v148 : UH2 = UH2_2(v147)
let v149 : UH2 = UH2_1
let v150 : UH2 = UH2_4(v149, v148)
let v151 : UH2 = method11(v150)
let v152 : bool = method18(v151)
if v152 then
    ()
else
    let v153 : string = "normalization must remove concatenation identity"
    failwith v153
    ()
let v154 : US0 = US0_0
let v155 : UH2 = UH2_2(v154)
let v156 : UH2 = UH2_5(v155)
let v157 : UH2 = UH2_5(v156)
let v158 : UH2 = method11(v157)
let v159 : bool = method18(v158)
if v159 then
    ()
else
    let v160 : string = "normalization must collapse nested star"
    failwith v160
    ()
let v161 : US0 = US0_0
let v162 : UH2 = UH2_2(v161)
let v163 : UH2 = UH2_5(v162)
let v164 : UH2 = UH2_4(v163, v163)
let v165 : UH2 = method11(v164)
let v166 : bool = method18(v165)
if v166 then
    ()
else
    let v167 : string = "normalization must collapse duplicate adjacent stars"
    failwith v167
    ()
let v168 : string = "brzozowski-canonical-form-certificate-green"
v168
