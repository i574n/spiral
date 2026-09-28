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
and UH2 =
    | UH2_0
    | UH2_1 of UH2
and [<Struct>] US2 =
    | US2_0
    | US2_1 of f1_0 : US0
and [<Struct>] US3 =
    | US3_0
    | US3_1
and UH3 =
    | UH3_0
    | UH3_1 of US3 * UH3
and [<Struct>] US4 =
    | US4_0
    | US4_1
    | US4_2
and UH4 =
    | UH4_0
    | UH4_1 of US0 * UH4
and UH5 =
    | UH5_0
    | UH5_1
    | UH5_2 of US0
    | UH5_3 of UH5 * UH5
    | UH5_4 of UH5 * UH5
    | UH5_5 of UH5
and UH6 =
    | UH6_0
    | UH6_1 of UH6
and UH7 =
    | UH7_0
    | UH7_1 of UH5 * UH7
and [<Struct>] US5 =
    | US5_0 of f0_0 : UH7
    | US5_1 of f1_0 : UH7
and [<Struct>] US6 =
    | US6_0
    | US6_1
let rec method1 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_0 -> (* AdversarialLeft *)
                match v2 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_1
                | US0_1 -> (* AdversarialRight *)
                    US1_0
            | US0_1 -> (* AdversarialRight *)
                match v2 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_2
                | US0_1 -> (* AdversarialRight *)
                    US1_1
        let v23 : US1 =
            match v2 with
            | US0_0 -> (* AdversarialLeft *)
                match v0 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_1
                | US0_1 -> (* AdversarialRight *)
                    US1_0
            | US0_1 -> (* AdversarialRight *)
                match v0 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_2
                | US0_1 -> (* AdversarialRight *)
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
                        | US0_0 -> (* AdversarialLeft *)
                            match v2 with
                            | US0_0 -> (* AdversarialLeft *)
                                US1_1
                            | US0_1 -> (* AdversarialRight *)
                                US1_0
                        | US0_1 -> (* AdversarialRight *)
                            match v2 with
                            | US0_0 -> (* AdversarialLeft *)
                                US1_2
                            | US0_1 -> (* AdversarialRight *)
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
            | US0_0 -> (* AdversarialLeft *)
                US1_1
            | US0_1 -> (* AdversarialRight *)
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
            | US0_0 -> (* AdversarialLeft *)
                match v2 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_1
                | US0_1 -> (* AdversarialRight *)
                    US1_0
            | US0_1 -> (* AdversarialRight *)
                match v2 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_2
                | US0_1 -> (* AdversarialRight *)
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
                | US0_0 -> (* AdversarialLeft *)
                    match v5 with
                    | US0_0 -> (* AdversarialLeft *)
                        US1_1
                    | US0_1 -> (* AdversarialRight *)
                        US1_0
                | US0_1 -> (* AdversarialRight *)
                    match v5 with
                    | US0_0 -> (* AdversarialLeft *)
                        US1_2
                    | US0_1 -> (* AdversarialRight *)
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
and method6 (v0 : UH0, v1 : UH2) : US2 =
    match v0 with
    | UH0_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH2_1(v6) -> (* AlphabetRankSucc *)
            method6(v4, v6)
        | UH2_0 -> (* AlphabetRankZero *)
            US2_1(v3)
    | UH0_0 -> (* SymbolListNil *)
        US2_0
and method8 (v0 : US3, v1 : UH3) : bool =
    match v1 with
    | UH3_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US3_1 -> (* BitOne *)
                match v2 with
                | US3_1 -> (* BitOne *)
                    US1_1
                | US3_0 -> (* BitZero *)
                    US1_2
            | US3_0 -> (* BitZero *)
                match v2 with
                | US3_1 -> (* BitOne *)
                    US1_0
                | US3_0 -> (* BitZero *)
                    US1_1
        let v23 : US1 =
            match v2 with
            | US3_1 -> (* BitOne *)
                match v0 with
                | US3_1 -> (* BitOne *)
                    US1_1
                | US3_0 -> (* BitZero *)
                    US1_2
            | US3_0 -> (* BitZero *)
                match v0 with
                | US3_1 -> (* BitOne *)
                    US1_0
                | US3_0 -> (* BitZero *)
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
                        | US3_1 -> (* BitOne *)
                            match v2 with
                            | US3_1 -> (* BitOne *)
                                US1_1
                            | US3_0 -> (* BitZero *)
                                US1_2
                        | US3_0 -> (* BitZero *)
                            match v2 with
                            | US3_1 -> (* BitOne *)
                                US1_0
                            | US3_0 -> (* BitZero *)
                                US1_1
                    match v33 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                | _ ->
                    false
        if v40 then
            method8(v0, v3)
        else
            false
    | UH3_0 -> (* SymbolListNil *)
        true
and method7 (v0 : UH3) : bool =
    match v0 with
    | UH3_1(v1, v2) -> (* SymbolListCons *)
        let v6 : US1 =
            match v1 with
            | US3_1 -> (* BitOne *)
                US1_1
            | US3_0 -> (* BitZero *)
                US1_1
        match v6 with
        | US1_1 -> (* SymbolSame *)
            let v7 : bool = method8(v1, v2)
            if v7 then
                method7(v2)
            else
                false
        | _ ->
            false
    | UH3_0 -> (* SymbolListNil *)
        true
and method10 (v0 : US3, v1 : UH3) : bool =
    match v1 with
    | UH3_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US3_1 -> (* BitOne *)
                match v2 with
                | US3_1 -> (* BitOne *)
                    US1_1
                | US3_0 -> (* BitZero *)
                    US1_2
            | US3_0 -> (* BitZero *)
                match v2 with
                | US3_1 -> (* BitOne *)
                    US1_0
                | US3_0 -> (* BitZero *)
                    US1_1
        match v13 with
        | US1_0 -> (* SymbolLess *)
            method10(v0, v3)
        | _ ->
            false
    | UH3_0 -> (* SymbolListNil *)
        true
and method9 (v0 : UH3) : bool =
    match v0 with
    | UH3_1(v1, v2) -> (* SymbolListCons *)
        let v3 : bool = method10(v1, v2)
        if v3 then
            method9(v2)
        else
            false
    | UH3_0 -> (* SymbolListNil *)
        true
and method11 (v0 : UH3, v1 : UH1) : bool =
    match v0 with
    | UH3_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH1_1(v5) -> (* AlphabetCardinalitySucc *)
            method11(v4, v5)
        | _ ->
            false
    | UH3_0 -> (* SymbolListNil *)
        match v1 with
        | UH1_0 -> (* AlphabetCardinalityZero *)
            true
        | _ ->
            false
and method12 (v0 : UH3, v1 : UH3) : bool =
    match v0 with
    | UH3_1(v3, v4) -> (* SymbolListCons *)
        match v1 with
        | UH3_1(v5, v6) -> (* SymbolListCons *)
            let v16 : US1 =
                match v3 with
                | US3_1 -> (* BitOne *)
                    match v5 with
                    | US3_1 -> (* BitOne *)
                        US1_1
                    | US3_0 -> (* BitZero *)
                        US1_2
                | US3_0 -> (* BitZero *)
                    match v5 with
                    | US3_1 -> (* BitOne *)
                        US1_0
                    | US3_0 -> (* BitZero *)
                        US1_1
            let v17 : bool =
                match v16 with
                | US1_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v17 then
                method12(v4, v6)
            else
                false
        | _ ->
            false
    | UH3_0 -> (* SymbolListNil *)
        match v1 with
        | UH3_0 -> (* SymbolListNil *)
            true
        | _ ->
            false
and method14 (v0 : US0, v1 : UH0) : bool =
    match v1 with
    | UH0_1(v2, v3) -> (* SymbolListCons *)
        let v13 : US1 =
            match v0 with
            | US0_0 -> (* AdversarialLeft *)
                match v2 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_1
                | US0_1 -> (* AdversarialRight *)
                    US1_0
            | US0_1 -> (* AdversarialRight *)
                match v2 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_2
                | US0_1 -> (* AdversarialRight *)
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
            method14(v0, v3)
    | UH0_0 -> (* SymbolListNil *)
        false
and method13 (v0 : UH4, v1 : UH0) : bool =
    match v0 with
    | UH4_1(v2, v3) -> (* InputCons *)
        let v4 : bool = method14(v2, v1)
        if v4 then
            method13(v3, v1)
        else
            false
    | UH4_0 -> (* InputEmpty *)
        true
and method18 (v0 : UH5, v1 : UH5) : US1 =
    match v0 with
    | UH5_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH5_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method18(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method18(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH5_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH5_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method18(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method18(v29, v35)
            | _ ->
                v36
        | UH5_2(v32) -> (* RegexChar *)
            US1_2
        | UH5_0 -> (* RegexEmpty *)
            US1_2
        | UH5_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH5_2(v10) -> (* RegexChar *)
        match v1 with
        | UH5_2(v13) -> (* RegexChar *)
            match v10 with
            | US0_0 -> (* AdversarialLeft *)
                match v13 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_1
                | US0_1 -> (* AdversarialRight *)
                    US1_0
            | US0_1 -> (* AdversarialRight *)
                match v13 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_2
                | US0_1 -> (* AdversarialRight *)
                    US1_1
        | UH5_0 -> (* RegexEmpty *)
            US1_2
        | UH5_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH5_0 -> (* RegexEmpty *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH5_1 -> (* RegexEpsilon *)
        match v1 with
        | UH5_0 -> (* RegexEmpty *)
            US1_2
        | UH5_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH5_5(v44) -> (* RegexStar *)
        match v1 with
        | UH5_3(v45, v46) -> (* RegexAlt *)
            US1_0
        | UH5_5(v48) -> (* RegexStar *)
            method18(v44, v48)
        | _ ->
            US1_2
and method17 (v0 : UH5, v1 : UH5) : UH5 =
    match v1 with
    | UH5_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method18(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH5 = method17(v0, v3)
            UH5_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH5_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH5_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method18(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH5_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH5_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method16 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH5 = method17(v2, v1)
        method16(v3, v4)
    | UH5_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method17(v0, v1)
and method20 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH5_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method20(v18, v20)
            if v22 then
                method20(v19, v21)
            else
                false
        | _ ->
            false
    | UH5_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH5_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method20(v26, v28)
            if v30 then
                method20(v27, v29)
            else
                false
        | _ ->
            false
    | UH5_2(v4) -> (* RegexChar *)
        match v1 with
        | UH5_2(v5) -> (* RegexChar *)
            let v15 : US1 =
                match v4 with
                | US0_0 -> (* AdversarialLeft *)
                    match v5 with
                    | US0_0 -> (* AdversarialLeft *)
                        US1_1
                    | US0_1 -> (* AdversarialRight *)
                        US1_0
                | US0_1 -> (* AdversarialRight *)
                    match v5 with
                    | US0_0 -> (* AdversarialLeft *)
                        US1_2
                    | US0_1 -> (* AdversarialRight *)
                        US1_1
            match v15 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
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
    | UH5_5(v34) -> (* RegexStar *)
        match v1 with
        | UH5_5(v35) -> (* RegexStar *)
            method20(v34, v35)
        | _ ->
            false
and method19 (v0 : UH5, v1 : UH5) : UH5 =
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
                        let v14 : UH5 = method19(v13, v1)
                        UH5_4(v12, v14)
                    | UH5_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH5_5(v5) -> (* RegexStar *)
                            let v6 : bool = method20(v4, v5)
                            if v6 then
                                UH5_5(v4)
                            else
                                UH5_4(v0, v1)
                        | _ ->
                            UH5_4(v0, v1)
                    | _ ->
                        UH5_4(v0, v1)
and method21 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_0 -> (* RegexEmpty *)
        UH5_1
    | UH5_1 -> (* RegexEpsilon *)
        UH5_1
    | UH5_5(v3) -> (* RegexStar *)
        UH5_5(v3)
    | _ ->
        UH5_5(v0)
and method15 (v0 : UH5) : UH5 =
    match v0 with
    | UH5_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH5 = method15(v5)
        let v8 : UH5 = method15(v6)
        method16(v7, v8)
    | UH5_4(v10, v11) -> (* RegexCat *)
        let v12 : UH5 = method15(v10)
        let v13 : UH5 = method15(v11)
        method19(v12, v13)
    | UH5_2(v3) -> (* RegexChar *)
        UH5_2(v3)
    | UH5_0 -> (* RegexEmpty *)
        UH5_0
    | UH5_1 -> (* RegexEpsilon *)
        UH5_1
    | UH5_5(v15) -> (* RegexStar *)
        let v16 : UH5 = method15(v15)
        method21(v16)
and method23 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_1(v2) -> (* StateBudgetSucc *)
        let v3 : UH6 = method23(v2, v1)
        UH6_1(v3)
    | UH6_0 -> (* StateBudgetZero *)
        v1
and method22 (v0 : UH5) : UH6 =
    match v0 with
    | UH5_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH6 = method22(v6)
        let v9 : UH6 = method22(v7)
        method23(v8, v9)
    | UH5_4(v11, v12) -> (* RegexCat *)
        let v13 : UH6 = method22(v11)
        let v14 : UH6 = method22(v12)
        method23(v13, v14)
    | UH5_2(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_0
        UH6_1(v4)
    | UH5_0 -> (* RegexEmpty *)
        UH6_0
    | UH5_1 -> (* RegexEpsilon *)
        UH6_0
    | UH5_5(v16) -> (* RegexStar *)
        method22(v16)
and method25 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_1(v1) -> (* StateBudgetSucc *)
        let v2 : UH6 = method23(v1, v0)
        UH6_1(v2)
    | UH6_0 -> (* StateBudgetZero *)
        v0
and method24 (v0 : UH6) : UH6 =
    match v0 with
    | UH6_1(v3) -> (* StateBudgetSucc *)
        let v4 : UH6 = method24(v3)
        method25(v4)
    | UH6_0 -> (* StateBudgetZero *)
        let v1 : UH6 = UH6_0
        UH6_1(v1)
and method30 (v0 : UH5) : US6 =
    match v0 with
    | UH5_3(v5, v6) -> (* RegexAlt *)
        let v7 : US6 = method30(v5)
        let v8 : US6 = method30(v6)
        match v7 with
        | US6_0 -> (* Nullable *)
            US6_0
        | _ ->
            match v8 with
            | US6_0 -> (* Nullable *)
                US6_0
            | _ ->
                match v7 with
                | US6_1 -> (* NonNullable *)
                    match v8 with
                    | US6_1 -> (* NonNullable *)
                        US6_1
    | UH5_4(v16, v17) -> (* RegexCat *)
        let v18 : US6 = method30(v16)
        let v19 : US6 = method30(v17)
        match v18 with
        | US6_0 -> (* Nullable *)
            match v19 with
            | US6_0 -> (* Nullable *)
                US6_0
            | _ ->
                US6_1
        | _ ->
            US6_1
    | UH5_2(v3) -> (* RegexChar *)
        US6_1
    | UH5_0 -> (* RegexEmpty *)
        US6_1
    | UH5_1 -> (* RegexEpsilon *)
        US6_0
    | UH5_5(v25) -> (* RegexStar *)
        US6_0
and method29 (v0 : UH5, v1 : US0) : UH5 =
    match v0 with
    | UH5_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH5 = method29(v19, v1)
        let v22 : UH5 = method29(v20, v1)
        method16(v21, v22)
    | UH5_4(v24, v25) -> (* RegexCat *)
        let v26 : US6 = method30(v24)
        match v26 with
        | US6_1 -> (* NonNullable *)
            let v31 : UH5 = method29(v24, v1)
            method19(v31, v25)
        | US6_0 -> (* Nullable *)
            let v27 : UH5 = method29(v24, v1)
            let v28 : UH5 = method19(v27, v25)
            let v29 : UH5 = method29(v25, v1)
            method16(v28, v29)
    | UH5_2(v4) -> (* RegexChar *)
        let v14 : US1 =
            match v4 with
            | US0_0 -> (* AdversarialLeft *)
                match v1 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_1
                | US0_1 -> (* AdversarialRight *)
                    US1_0
            | US0_1 -> (* AdversarialRight *)
                match v1 with
                | US0_0 -> (* AdversarialLeft *)
                    US1_2
                | US0_1 -> (* AdversarialRight *)
                    US1_1
        let v15 : bool =
            match v14 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v15 then
            UH5_1
        else
            UH5_0
    | UH5_0 -> (* RegexEmpty *)
        UH5_0
    | UH5_1 -> (* RegexEpsilon *)
        UH5_0
    | UH5_5(v35) -> (* RegexStar *)
        let v36 : UH5 = method29(v35, v1)
        let v37 : UH5 = method21(v35)
        method19(v36, v37)
and method28 (v0 : UH5, v1 : US0) : UH5 =
    let v2 : UH5 = method15(v0)
    let v3 : UH5 = method29(v2, v1)
    method15(v3)
and method31 (v0 : UH5, v1 : UH7) : bool =
    match v1 with
    | UH7_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method20(v0, v2)
        if v4 then
            true
        else
            method31(v0, v3)
    | UH7_0 -> (* RegexListNil *)
        false
and method27 (v0 : UH5, v1 : UH0, v2 : UH7, v3 : UH7) : struct (UH7 * UH7) =
    match v1 with
    | UH0_1(v4, v5) -> (* SymbolListCons *)
        let v6 : UH5 = method28(v0, v4)
        let v7 : bool = method31(v6, v2)
        if v7 then
            method27(v0, v5, v2, v3)
        else
            let v10 : UH7 = UH7_1(v6, v2)
            let v11 : UH7 = UH7_1(v6, v3)
            method27(v0, v5, v10, v11)
    | UH0_0 -> (* SymbolListNil *)
        struct (v2, v3)
and method26 (v0 : UH0, v1 : UH6, v2 : UH7, v3 : UH7) : US5 =
    match v3 with
    | UH7_1(v5, v6) -> (* RegexListCons *)
        match v1 with
        | UH6_1(v8) -> (* StateBudgetSucc *)
            let struct (v9 : UH7, v10 : UH7) = method27(v5, v0, v2, v6)
            method26(v0, v8, v9, v10)
        | UH6_0 -> (* StateBudgetZero *)
            US5_1(v2)
    | UH7_0 -> (* RegexListNil *)
        US5_0(v2)
and method32 (v0 : UH5, v1 : UH7, v2 : UH4) : US4 =
    match v2 with
    | UH4_1(v8, v9) -> (* InputCons *)
        let v10 : UH5 = method28(v0, v8)
        let v11 : bool = method31(v10, v1)
        if v11 then
            method32(v10, v1, v9)
        else
            US4_2
    | UH4_0 -> (* InputEmpty *)
        let v3 : US6 = method30(v0)
        match v3 with
        | US6_1 -> (* NonNullable *)
            US4_1
        | US6_0 -> (* Nullable *)
            US4_0
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
    let v45 : string = "ordered inventory with matching independent cardinality must certify"
    failwith v45
    ()
let v46 : US0 = US0_0
let v47 : US0 = US0_1
let v48 : UH0 = UH0_0
let v49 : UH0 = UH0_1(v47, v48)
let v50 : UH0 = UH0_1(v46, v49)
let v51 : UH2 = UH2_0
let v52 : US2 = method6(v50, v51)
let v88 : bool =
    match v52 with
    | US2_0 -> (* AlphabetRankEnd *)
        false
    | US2_1(v53) -> (* AlphabetRankFound *)
        let v57 : US1 =
            match v53 with
            | US0_0 -> (* AdversarialLeft *)
                US1_1
            | US0_1 -> (* AdversarialRight *)
                US1_2
        match v57 with
        | US1_1 -> (* SymbolSame *)
            let v58 : US0 = US0_0
            let v59 : US0 = US0_1
            let v60 : UH0 = UH0_0
            let v61 : UH0 = UH0_1(v59, v60)
            let v62 : UH0 = UH0_1(v58, v61)
            let v63 : UH2 = UH2_0
            let v64 : UH2 = UH2_1(v63)
            let v65 : US2 = method6(v62, v64)
            match v65 with
            | US2_0 -> (* AlphabetRankEnd *)
                false
            | US2_1(v66) -> (* AlphabetRankFound *)
                let v70 : US1 =
                    match v66 with
                    | US0_0 -> (* AdversarialLeft *)
                        US1_0
                    | US0_1 -> (* AdversarialRight *)
                        US1_1
                match v70 with
                | US1_1 -> (* SymbolSame *)
                    let v71 : US0 = US0_0
                    let v72 : US0 = US0_1
                    let v73 : UH0 = UH0_0
                    let v74 : UH0 = UH0_1(v72, v73)
                    let v75 : UH0 = UH0_1(v71, v74)
                    let v76 : UH2 = UH2_0
                    let v77 : UH2 = UH2_1(v76)
                    let v78 : UH2 = UH2_1(v77)
                    let v79 : US2 = method6(v75, v78)
                    match v79 with
                    | US2_0 -> (* AlphabetRankEnd *)
                        true
                    | US2_1(v80) -> (* AlphabetRankFound *)
                        false
                | _ ->
                    false
        | _ ->
            false
if v88 then
    ()
else
    let v89 : string = "rank lookup must be derived deterministically from the certified inventory"
    failwith v89
    ()
let v90 : US0 = US0_1
let v91 : US0 = US0_0
let v92 : UH0 = UH0_0
let v93 : UH0 = UH0_1(v91, v92)
let v94 : UH0 = UH0_1(v90, v93)
let v95 : bool = method0(v94)
let v102 : bool =
    if v95 then
        let v96 : US0 = US0_1
        let v97 : US0 = US0_0
        let v98 : UH0 = UH0_0
        let v99 : UH0 = UH0_1(v97, v98)
        let v100 : UH0 = UH0_1(v96, v99)
        method2(v100)
    else
        false
let v134 : bool =
    if v102 then
        let v103 : US0 = US0_1
        let v104 : US0 = US0_0
        let v105 : UH0 = UH0_0
        let v106 : UH0 = UH0_1(v104, v105)
        let v107 : UH0 = UH0_1(v103, v106)
        let v108 : UH1 = UH1_0
        let v109 : UH1 = UH1_1(v108)
        let v110 : UH1 = UH1_1(v109)
        let v111 : bool = method4(v107, v110)
        let v121 : bool =
            if v111 then
                let v112 : US0 = US0_0
                let v113 : US0 = US0_1
                let v114 : UH0 = UH0_0
                let v115 : UH0 = UH0_1(v113, v114)
                let v116 : UH0 = UH0_1(v112, v115)
                let v117 : UH1 = UH1_0
                let v118 : UH1 = UH1_1(v117)
                let v119 : UH1 = UH1_1(v118)
                method4(v116, v119)
            else
                false
        if v121 then
            let v122 : US0 = US0_1
            let v123 : US0 = US0_0
            let v124 : UH0 = UH0_0
            let v125 : UH0 = UH0_1(v123, v124)
            let v126 : UH0 = UH0_1(v122, v125)
            let v127 : US0 = US0_0
            let v128 : US0 = US0_1
            let v129 : UH0 = UH0_0
            let v130 : UH0 = UH0_1(v128, v129)
            let v131 : UH0 = UH0_1(v127, v130)
            method5(v126, v131)
        else
            false
    else
        false
let v135 : bool = v134 = false
if v135 then
    ()
else
    let v136 : string = "swapped descriptor inventory must fail canonical ordering"
    failwith v136
    ()
let v137 : US0 = US0_0
let v138 : UH0 = UH0_0
let v139 : UH0 = UH0_1(v137, v138)
let v140 : bool = method0(v139)
let v145 : bool =
    if v140 then
        let v141 : US0 = US0_0
        let v142 : UH0 = UH0_0
        let v143 : UH0 = UH0_1(v141, v142)
        method2(v143)
    else
        false
if v145 then
    ()
else
    let v146 : string = "short inventory may be locally ordered"
    failwith v146
    ()
let v147 : US0 = US0_0
let v148 : UH0 = UH0_0
let v149 : UH0 = UH0_1(v147, v148)
let v150 : bool = method0(v149)
let v155 : bool =
    if v150 then
        let v151 : US0 = US0_0
        let v152 : UH0 = UH0_0
        let v153 : UH0 = UH0_1(v151, v152)
        method2(v153)
    else
        false
let v183 : bool =
    if v155 then
        let v156 : US0 = US0_0
        let v157 : UH0 = UH0_0
        let v158 : UH0 = UH0_1(v156, v157)
        let v159 : UH1 = UH1_0
        let v160 : UH1 = UH1_1(v159)
        let v161 : UH1 = UH1_1(v160)
        let v162 : bool = method4(v158, v161)
        let v172 : bool =
            if v162 then
                let v163 : US0 = US0_0
                let v164 : US0 = US0_1
                let v165 : UH0 = UH0_0
                let v166 : UH0 = UH0_1(v164, v165)
                let v167 : UH0 = UH0_1(v163, v166)
                let v168 : UH1 = UH1_0
                let v169 : UH1 = UH1_1(v168)
                let v170 : UH1 = UH1_1(v169)
                method4(v167, v170)
            else
                false
        if v172 then
            let v173 : US0 = US0_0
            let v174 : UH0 = UH0_0
            let v175 : UH0 = UH0_1(v173, v174)
            let v176 : US0 = US0_0
            let v177 : US0 = US0_1
            let v178 : UH0 = UH0_0
            let v179 : UH0 = UH0_1(v177, v178)
            let v180 : UH0 = UH0_1(v176, v179)
            method5(v175, v180)
        else
            false
    else
        false
let v184 : bool = v183 = false
if v184 then
    ()
else
    let v185 : string = "cardinality must reject an inventory that omits a domain slot"
    failwith v185
    ()
let v186 : US0 = US0_0
let v187 : UH0 = UH0_0
let v188 : UH0 = UH0_1(v186, v187)
let v189 : UH1 = UH1_0
let v190 : UH1 = UH1_1(v189)
let v191 : bool = method4(v188, v190)
if v191 then
    ()
else
    let v192 : string = "self-consistent short descriptor should demonstrate the old circularity"
    failwith v192
    ()
let v193 : US0 = US0_0
let v194 : UH0 = UH0_0
let v195 : UH0 = UH0_1(v193, v194)
let v196 : bool = method0(v195)
let v201 : bool =
    if v196 then
        let v197 : US0 = US0_0
        let v198 : UH0 = UH0_0
        let v199 : UH0 = UH0_1(v197, v198)
        method2(v199)
    else
        false
let v228 : bool =
    if v201 then
        let v202 : US0 = US0_0
        let v203 : UH0 = UH0_0
        let v204 : UH0 = UH0_1(v202, v203)
        let v205 : UH1 = UH1_0
        let v206 : UH1 = UH1_1(v205)
        let v207 : bool = method4(v204, v206)
        let v217 : bool =
            if v207 then
                let v208 : US0 = US0_0
                let v209 : US0 = US0_1
                let v210 : UH0 = UH0_0
                let v211 : UH0 = UH0_1(v209, v210)
                let v212 : UH0 = UH0_1(v208, v211)
                let v213 : UH1 = UH1_0
                let v214 : UH1 = UH1_1(v213)
                let v215 : UH1 = UH1_1(v214)
                method4(v212, v215)
            else
                false
        if v217 then
            let v218 : US0 = US0_0
            let v219 : UH0 = UH0_0
            let v220 : UH0 = UH0_1(v218, v219)
            let v221 : US0 = US0_0
            let v222 : US0 = US0_1
            let v223 : UH0 = UH0_0
            let v224 : UH0 = UH0_1(v222, v223)
            let v225 : UH0 = UH0_1(v221, v224)
            method5(v220, v225)
        else
            false
    else
        false
let v229 : bool = v228 = false
if v229 then
    ()
else
    let v230 : string = "canonical finite-domain authority must reject a self-consistent truncated descriptor"
    failwith v230
    ()
let v231 : US0 = US0_0
let v232 : US0 = US0_1
let v233 : UH0 = UH0_0
let v234 : UH0 = UH0_1(v232, v233)
let v235 : UH0 = UH0_1(v231, v234)
let v236 : bool = method0(v235)
let v243 : bool =
    if v236 then
        let v237 : US0 = US0_0
        let v238 : US0 = US0_1
        let v239 : UH0 = UH0_0
        let v240 : UH0 = UH0_1(v238, v239)
        let v241 : UH0 = UH0_1(v237, v240)
        method2(v241)
    else
        false
let v276 : bool =
    if v243 then
        let v244 : US0 = US0_0
        let v245 : US0 = US0_1
        let v246 : UH0 = UH0_0
        let v247 : UH0 = UH0_1(v245, v246)
        let v248 : UH0 = UH0_1(v244, v247)
        let v249 : UH1 = UH1_0
        let v250 : UH1 = UH1_1(v249)
        let v251 : UH1 = UH1_1(v250)
        let v252 : UH1 = UH1_1(v251)
        let v253 : bool = method4(v248, v252)
        let v263 : bool =
            if v253 then
                let v254 : US0 = US0_0
                let v255 : US0 = US0_1
                let v256 : UH0 = UH0_0
                let v257 : UH0 = UH0_1(v255, v256)
                let v258 : UH0 = UH0_1(v254, v257)
                let v259 : UH1 = UH1_0
                let v260 : UH1 = UH1_1(v259)
                let v261 : UH1 = UH1_1(v260)
                method4(v258, v261)
            else
                false
        if v263 then
            let v264 : US0 = US0_0
            let v265 : US0 = US0_1
            let v266 : UH0 = UH0_0
            let v267 : UH0 = UH0_1(v265, v266)
            let v268 : UH0 = UH0_1(v264, v267)
            let v269 : US0 = US0_0
            let v270 : US0 = US0_1
            let v271 : UH0 = UH0_0
            let v272 : UH0 = UH0_1(v270, v271)
            let v273 : UH0 = UH0_1(v269, v272)
            method5(v268, v273)
        else
            false
    else
        false
let v277 : bool = v276 = false
if v277 then
    ()
else
    let v278 : string = "cardinality must reject a descriptor claiming more slots than its inventory carries"
    failwith v278
    ()
let v279 : US0 = US0_0
let v280 : US0 = US0_0
let v281 : UH0 = UH0_0
let v282 : UH0 = UH0_1(v280, v281)
let v283 : UH0 = UH0_1(v279, v282)
let v284 : bool = method0(v283)
let v291 : bool =
    if v284 then
        let v285 : US0 = US0_0
        let v286 : US0 = US0_0
        let v287 : UH0 = UH0_0
        let v288 : UH0 = UH0_1(v286, v287)
        let v289 : UH0 = UH0_1(v285, v288)
        method2(v289)
    else
        false
let v323 : bool =
    if v291 then
        let v292 : US0 = US0_0
        let v293 : US0 = US0_0
        let v294 : UH0 = UH0_0
        let v295 : UH0 = UH0_1(v293, v294)
        let v296 : UH0 = UH0_1(v292, v295)
        let v297 : UH1 = UH1_0
        let v298 : UH1 = UH1_1(v297)
        let v299 : UH1 = UH1_1(v298)
        let v300 : bool = method4(v296, v299)
        let v310 : bool =
            if v300 then
                let v301 : US0 = US0_0
                let v302 : US0 = US0_1
                let v303 : UH0 = UH0_0
                let v304 : UH0 = UH0_1(v302, v303)
                let v305 : UH0 = UH0_1(v301, v304)
                let v306 : UH1 = UH1_0
                let v307 : UH1 = UH1_1(v306)
                let v308 : UH1 = UH1_1(v307)
                method4(v305, v308)
            else
                false
        if v310 then
            let v311 : US0 = US0_0
            let v312 : US0 = US0_0
            let v313 : UH0 = UH0_0
            let v314 : UH0 = UH0_1(v312, v313)
            let v315 : UH0 = UH0_1(v311, v314)
            let v316 : US0 = US0_0
            let v317 : US0 = US0_1
            let v318 : UH0 = UH0_0
            let v319 : UH0 = UH0_1(v317, v318)
            let v320 : UH0 = UH0_1(v316, v319)
            method5(v315, v320)
        else
            false
    else
        false
let v324 : bool = v323 = false
if v324 then
    ()
else
    let v325 : string = "duplicate inventory values must not certify even when cardinality matches"
    failwith v325
    ()
let v326 : US3 = US3_0
let v327 : US3 = US3_1
let v328 : UH3 = UH3_0
let v329 : UH3 = UH3_1(v327, v328)
let v330 : UH3 = UH3_1(v326, v329)
let v331 : bool = method7(v330)
let v338 : bool =
    if v331 then
        let v332 : US3 = US3_0
        let v333 : US3 = US3_1
        let v334 : UH3 = UH3_0
        let v335 : UH3 = UH3_1(v333, v334)
        let v336 : UH3 = UH3_1(v332, v335)
        method9(v336)
    else
        false
let v370 : bool =
    if v338 then
        let v339 : US3 = US3_0
        let v340 : US3 = US3_1
        let v341 : UH3 = UH3_0
        let v342 : UH3 = UH3_1(v340, v341)
        let v343 : UH3 = UH3_1(v339, v342)
        let v344 : UH1 = UH1_0
        let v345 : UH1 = UH1_1(v344)
        let v346 : UH1 = UH1_1(v345)
        let v347 : bool = method11(v343, v346)
        let v357 : bool =
            if v347 then
                let v348 : US3 = US3_0
                let v349 : US3 = US3_1
                let v350 : UH3 = UH3_0
                let v351 : UH3 = UH3_1(v349, v350)
                let v352 : UH3 = UH3_1(v348, v351)
                let v353 : UH1 = UH1_0
                let v354 : UH1 = UH1_1(v353)
                let v355 : UH1 = UH1_1(v354)
                method11(v352, v355)
            else
                false
        if v357 then
            let v358 : US3 = US3_0
            let v359 : US3 = US3_1
            let v360 : UH3 = UH3_0
            let v361 : UH3 = UH3_1(v359, v360)
            let v362 : UH3 = UH3_1(v358, v361)
            let v363 : US3 = US3_0
            let v364 : US3 = US3_1
            let v365 : UH3 = UH3_0
            let v366 : UH3 = UH3_1(v364, v365)
            let v367 : UH3 = UH3_1(v363, v366)
            method12(v362, v367)
        else
            false
    else
        false
if v370 then
    ()
else
    let v371 : string = "production bit descriptor must certify through list plus cardinality only"
    failwith v371
    ()
let v372 : US0 = US0_0
let v373 : UH0 = UH0_0
let v374 : UH0 = UH0_1(v372, v373)
let v375 : bool = method0(v374)
let v380 : bool =
    if v375 then
        let v376 : US0 = US0_0
        let v377 : UH0 = UH0_0
        let v378 : UH0 = UH0_1(v376, v377)
        method2(v378)
    else
        false
let v408 : bool =
    if v380 then
        let v381 : US0 = US0_0
        let v382 : UH0 = UH0_0
        let v383 : UH0 = UH0_1(v381, v382)
        let v384 : UH1 = UH1_0
        let v385 : UH1 = UH1_1(v384)
        let v386 : UH1 = UH1_1(v385)
        let v387 : bool = method4(v383, v386)
        let v397 : bool =
            if v387 then
                let v388 : US0 = US0_0
                let v389 : US0 = US0_1
                let v390 : UH0 = UH0_0
                let v391 : UH0 = UH0_1(v389, v390)
                let v392 : UH0 = UH0_1(v388, v391)
                let v393 : UH1 = UH1_0
                let v394 : UH1 = UH1_1(v393)
                let v395 : UH1 = UH1_1(v394)
                method4(v392, v395)
            else
                false
        if v397 then
            let v398 : US0 = US0_0
            let v399 : UH0 = UH0_0
            let v400 : UH0 = UH0_1(v398, v399)
            let v401 : US0 = US0_0
            let v402 : US0 = US0_1
            let v403 : UH0 = UH0_0
            let v404 : UH0 = UH0_1(v402, v403)
            let v405 : UH0 = UH0_1(v401, v404)
            method5(v400, v405)
        else
            false
    else
        false
let v439 : US4 =
    if v408 then
        let v409 : UH4 = UH4_0
        let v410 : US0 = US0_0
        let v411 : UH0 = UH0_0
        let v412 : UH0 = UH0_1(v410, v411)
        let v413 : bool = method13(v409, v412)
        if v413 then
            let v414 : UH5 = UH5_1
            let v415 : UH5 = method15(v414)
            let v416 : UH5 = method15(v415)
            let v417 : UH6 = method22(v416)
            let v418 : UH6 = UH6_1(v417)
            let v419 : UH6 = method24(v418)
            let v420 : UH5 = method15(v416)
            let v421 : US0 = US0_0
            let v422 : UH0 = UH0_0
            let v423 : UH0 = UH0_1(v421, v422)
            let v424 : UH7 = UH7_0
            let v425 : UH7 = UH7_1(v420, v424)
            let v426 : UH7 = UH7_0
            let v427 : UH7 = UH7_1(v420, v426)
            let v428 : US5 = method26(v423, v419, v425, v427)
            match v428 with
            | US5_1(v432) -> (* DfaClosureBudgetExceeded *)
                US4_2
            | US5_0(v429) -> (* DfaClosureComplete *)
                let v430 : UH4 = UH4_0
                method32(v415, v429, v430)
        else
            US4_2
    else
        US4_2
let v440 : bool =
    match v439 with
    | US4_2 -> (* DfaEscapedClosure *)
        true
    | _ ->
        false
if v440 then
    ()
else
    let v441 : string = "a publicly forged certified descriptor nominal must be revalidated by the runner"
    failwith v441
    ()
let v442 : string = "brzozowski-finite-inventory-adversarial-green"
v442
