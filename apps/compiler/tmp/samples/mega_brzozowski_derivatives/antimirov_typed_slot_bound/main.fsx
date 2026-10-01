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
    | UH1_1 of UH0 * UH1
and UH2 =
    | UH2_0 of US0
and UH3 =
    | UH3_0 of UH2 * UH2
and UH4 =
    | UH4_0 of UH3
and UH5 =
    | UH5_0 of UH4 * UH2
and UH6 =
    | UH6_0
    | UH6_1 of UH6
and UH10 =
    | UH10_0
and UH9 =
    | UH9_0 of UH10
    | UH9_1 of UH10
and UH8 =
    | UH8_0 of UH9
and UH7 =
    | UH7_0 of UH8
    | UH7_1 of UH10
and [<Struct>] US3 =
    | US3_0
    | US3_1 of f1_0 : UH7
and [<Struct>] US2 =
    | US2_0
    | US2_1 of f1_0 : US3
and [<Struct>] US4 =
    | US4_0
    | US4_1 of f1_0 : UH7
and [<Struct>] US5 =
    | US5_0
    | US5_1 of f1_0 : UH8
and [<Struct>] US6 =
    | US6_0
    | US6_1 of f1_0 : UH9
and [<Struct>] US7 =
    | US7_0
    | US7_1 of f1_0 : UH10
and [<Struct>] US8 =
    | US8_0
    | US8_1
    | US8_2
and UH11 =
    | UH11_0
    | UH11_1
    | UH11_2 of US8
    | UH11_3 of UH11 * UH11
    | UH11_4 of UH11 * UH11
    | UH11_5 of UH11
and UH12 =
    | UH12_0
    | UH12_1 of UH11 * UH12
and UH13 =
    | UH13_0 of US8
and UH14 =
    | UH14_0 of UH13
and UH15 =
    | UH15_0 of UH10
and [<Struct>] US10 =
    | US10_0
    | US10_1 of f1_0 : UH15
and [<Struct>] US9 =
    | US9_0
    | US9_1 of f1_0 : US10
and [<Struct>] US11 =
    | US11_0
    | US11_1 of f1_0 : UH15
and UH16 =
    | UH16_0 of UH13 * UH13
and UH17 =
    | UH17_0 of UH16
and UH18 =
    | UH18_0 of UH17 * UH13
let rec method3 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
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
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | UH0_2(v13) -> (* RegexChar *)
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
        | UH0_0 -> (* RegexEmpty *)
            US1_2
        | UH0_1 -> (* RegexEpsilon *)
            US1_2
        | UH0_2(v32) -> (* RegexChar *)
            US1_2
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method3(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method3(v29, v35)
            | _ ->
                v36
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
    | UH0_0 -> (* RegexEmpty *)
        v0
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method3(v0, v2)
        match v4 with
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH0 = method2(v0, v3)
            UH0_3(v2, v6)
    | _ ->
        let v11 : US1 = method3(v0, v1)
        match v11 with
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
and method1 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        v1
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method2(v2, v1)
        method1(v3, v4)
    | _ ->
        method2(v0, v1)
and method5 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
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
    | UH0_2(v4) -> (* RegexChar *)
        match v1 with
        | UH0_2(v5) -> (* RegexChar *)
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
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method0(v5)
        let v8 : UH0 = method0(v6)
        method1(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method0(v10)
        let v13 : UH0 = method0(v11)
        method4(v12, v13)
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method0(v15)
        method6(v16)
and method10 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_0 -> (* RegexListNil *)
        false
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method5(v0, v2)
        if v4 then
            true
        else
            method10(v0, v3)
and method9 (v0 : UH0, v1 : UH1) : UH1 =
    let v2 : UH0 = method0(v0)
    let v3 : bool = method10(v2, v1)
    if v3 then
        v1
    else
        UH1_1(v2, v1)
and method8 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        v1
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = method9(v2, v1)
        method8(v3, v4)
and method11 (v0 : UH1, v1 : UH0) : UH1 =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        UH1_0
    | UH1_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH0 = method4(v3, v1)
        let v6 : UH1 = method11(v4, v1)
        method9(v5, v6)
and method7 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH1_0
    | UH0_1 -> (* RegexEpsilon *)
        UH1_0
    | UH0_2(v3) -> (* RegexChar *)
        let v4 : UH1 = UH1_0
        let v5 : UH0 = UH0_1
        UH1_1(v5, v4)
    | UH0_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH1 = method7(v7)
        let v10 : UH1 = method7(v8)
        method8(v9, v10)
    | UH0_4(v12, v13) -> (* RegexCat *)
        let v14 : UH1 = method7(v12)
        let v15 : UH1 = method11(v14, v13)
        let v16 : UH1 = method7(v13)
        method8(v15, v16)
    | UH0_5(v18) -> (* RegexStar *)
        let v19 : UH1 = method7(v18)
        let v20 : UH0 = UH0_5(v18)
        method11(v19, v20)
and method12 (v0 : UH1) : bool =
    match v0 with
    | UH1_0 -> (* RegexListNil *)
        true
    | UH1_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = method10(v1, v2)
        if v3 then
            false
        else
            method12(v2)
and method16 (v0 : UH2) : UH6 =
    match v0 with
    | UH2_0(v1) -> (* PositionTreeChar *)
        let v2 : UH6 = UH6_0
        UH6_1(v2)
and method17 (v0 : UH6, v1 : UH6) : UH6 =
    match v0 with
    | UH6_0 -> (* StateBudgetZero *)
        v1
    | UH6_1(v2) -> (* StateBudgetSucc *)
        let v3 : UH6 = method17(v2, v1)
        UH6_1(v3)
and method15 (v0 : UH3) : UH6 =
    match v0 with
    | UH3_0(v1, v2) -> (* PositionTreeAlt *)
        let v3 : UH6 = method16(v1)
        let v4 : UH6 = method16(v2)
        method17(v3, v4)
and method14 (v0 : UH4) : UH6 =
    match v0 with
    | UH4_0(v1) -> (* PositionTreeStar *)
        method15(v1)
and method13 (v0 : UH5) : UH6 =
    match v0 with
    | UH5_0(v1, v2) -> (* PositionTreeCat *)
        let v3 : UH6 = method14(v1)
        let v4 : UH6 = method16(v2)
        method17(v3, v4)
and method18 (v0 : UH0) : UH6 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH6_0
    | UH0_1 -> (* RegexEpsilon *)
        UH6_0
    | UH0_2(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_0
        UH6_1(v4)
    | UH0_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH6 = method18(v6)
        let v9 : UH6 = method18(v7)
        method17(v8, v9)
    | UH0_4(v11, v12) -> (* RegexCat *)
        let v13 : UH6 = method18(v11)
        let v14 : UH6 = method18(v12)
        method17(v13, v14)
    | UH0_5(v16) -> (* RegexStar *)
        method18(v16)
and method19 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_0 -> (* StateBudgetZero *)
        match v1 with
        | UH6_0 -> (* StateBudgetZero *)
            true
        | _ ->
            false
    | UH6_1(v3) -> (* StateBudgetSucc *)
        match v1 with
        | UH6_1(v4) -> (* StateBudgetSucc *)
            method19(v3, v4)
        | _ ->
            false
and closure1 (v0 : UH0) (v1 : UH0) : UH0 =
    let v2 : UH0 = method4(v0, v1)
    method0(v2)
and closure0 () (v0 : UH0) : (UH0 -> UH0) =
    closure1(v0)
and closure3 (v0 : UH0) (v1 : UH0) : bool =
    method5(v0, v1)
and closure2 () (v0 : UH0) : (UH0 -> bool) =
    closure3(v0)
and method20 (v0 : (UH0 -> (UH0 -> UH0)), v1 : (UH0 -> (UH0 -> bool)), v2 : UH0, v3 : UH5, v4 : UH1) : bool =
    match v4 with
    | UH1_0 -> (* RegexListNil *)
        true
    | UH1_1(v5, v6) -> (* RegexListCons *)
        let v7 : (UH0 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v106 : US2 =
            if v8 then
                let v9 : US3 = US3_0
                US2_1(v9)
            else
                let v99 : US4 =
                    match v3 with
                    | UH5_0(v11, v12) -> (* PositionTreeCat *)
                        let v15 : UH0 =
                            match v12 with
                            | UH2_0(v13) -> (* PositionTreeChar *)
                                UH0_2(v13)
                        let v16 : (UH0 -> UH0) = v0 v15
                        let v17 : UH0 = UH0_1
                        let v18 : UH0 = v16 v17
                        let v75 : US5 =
                            match v11 with
                            | UH4_0(v19) -> (* PositionTreeStar *)
                                let v29 : UH0 =
                                    match v19 with
                                    | UH3_0(v20, v21) -> (* PositionTreeAlt *)
                                        let v24 : UH0 =
                                            match v20 with
                                            | UH2_0(v22) -> (* PositionTreeChar *)
                                                UH0_2(v22)
                                        let v27 : UH0 =
                                            match v21 with
                                            | UH2_0(v25) -> (* PositionTreeChar *)
                                                UH0_2(v25)
                                        UH0_3(v24, v27)
                                let v30 : UH0 = UH0_5(v29)
                                let v31 : (UH0 -> UH0) = v0 v30
                                let v32 : UH0 = v31 v18
                                let v68 : US6 =
                                    match v19 with
                                    | UH3_0(v33, v34) -> (* PositionTreeAlt *)
                                        let v45 : US7 =
                                            match v33 with
                                            | UH2_0(v35) -> (* PositionTreeChar *)
                                                let v36 : UH0 = UH0_1
                                                let v37 : (UH0 -> UH0) = v0 v36
                                                let v38 : UH0 = v37 v32
                                                let v39 : (UH0 -> bool) = v1 v5
                                                let v40 : bool = v39 v38
                                                if v40 then
                                                    let v41 : UH10 = UH10_0
                                                    US7_1(v41)
                                                else
                                                    US7_0
                                        match v45 with
                                        | US7_1(v46) -> (* OriginSlotFound *)
                                            let v47 : UH9 = UH9_0(v46)
                                            US6_1(v47)
                                        | US7_0 -> (* OriginSlotMissing *)
                                            let v59 : US7 =
                                                match v34 with
                                                | UH2_0(v49) -> (* PositionTreeChar *)
                                                    let v50 : UH0 = UH0_1
                                                    let v51 : (UH0 -> UH0) = v0 v50
                                                    let v52 : UH0 = v51 v32
                                                    let v53 : (UH0 -> bool) = v1 v5
                                                    let v54 : bool = v53 v52
                                                    if v54 then
                                                        let v55 : UH10 = UH10_0
                                                        US7_1(v55)
                                                    else
                                                        US7_0
                                            match v59 with
                                            | US7_1(v60) -> (* OriginSlotFound *)
                                                let v61 : UH9 = UH9_1(v60)
                                                US6_1(v61)
                                            | US7_0 -> (* OriginSlotMissing *)
                                                US6_0
                                match v68 with
                                | US6_1(v69) -> (* OriginSlotFound *)
                                    let v70 : UH8 = UH8_0(v69)
                                    US5_1(v70)
                                | US6_0 -> (* OriginSlotMissing *)
                                    US5_0
                        match v75 with
                        | US5_1(v76) -> (* OriginSlotFound *)
                            let v77 : UH7 = UH7_0(v76)
                            US4_1(v77)
                        | US5_0 -> (* OriginSlotMissing *)
                            let v90 : US7 =
                                match v12 with
                                | UH2_0(v79) -> (* PositionTreeChar *)
                                    let v80 : UH0 = UH0_1
                                    let v81 : (UH0 -> UH0) = v0 v80
                                    let v82 : UH0 = UH0_1
                                    let v83 : UH0 = v81 v82
                                    let v84 : (UH0 -> bool) = v1 v5
                                    let v85 : bool = v84 v83
                                    if v85 then
                                        let v86 : UH10 = UH10_0
                                        US7_1(v86)
                                    else
                                        US7_0
                            match v90 with
                            | US7_1(v91) -> (* OriginSlotFound *)
                                let v92 : UH7 = UH7_1(v91)
                                US4_1(v92)
                            | US7_0 -> (* OriginSlotMissing *)
                                US4_0
                match v99 with
                | US4_1(v100) -> (* OriginSlotFound *)
                    let v101 : US3 = US3_1(v100)
                    US2_1(v101)
                | US4_0 -> (* OriginSlotMissing *)
                    US2_0
        match v106 with
        | US2_0 -> (* SupportSlotMissing *)
            false
        | US2_1(v107) -> (* SupportSlotFound *)
            let v108 : (UH0 -> bool) = v1 v5
            let v167 : UH0 =
                match v107 with
                | US3_0 -> (* SupportSlotRoot *)
                    v2
                | US3_1(v109) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH5_0(v110, v111) -> (* PositionTreeCat *)
                        match v109 with
                        | UH7_0(v112) -> (* OriginSlotCatLeft *)
                            let v115 : UH0 =
                                match v111 with
                                | UH2_0(v113) -> (* PositionTreeChar *)
                                    UH0_2(v113)
                            let v116 : (UH0 -> UH0) = v0 v115
                            let v117 : UH0 = UH0_1
                            let v118 : UH0 = v116 v117
                            match v110 with
                            | UH4_0(v119) -> (* PositionTreeStar *)
                                match v112 with
                                | UH8_0(v120) -> (* OriginSlotStar *)
                                    let v130 : UH0 =
                                        match v119 with
                                        | UH3_0(v121, v122) -> (* PositionTreeAlt *)
                                            let v125 : UH0 =
                                                match v121 with
                                                | UH2_0(v123) -> (* PositionTreeChar *)
                                                    UH0_2(v123)
                                            let v128 : UH0 =
                                                match v122 with
                                                | UH2_0(v126) -> (* PositionTreeChar *)
                                                    UH0_2(v126)
                                            UH0_3(v125, v128)
                                    let v131 : UH0 = UH0_5(v130)
                                    let v132 : (UH0 -> UH0) = v0 v131
                                    let v133 : UH0 = v132 v118
                                    match v119 with
                                    | UH3_0(v134, v135) -> (* PositionTreeAlt *)
                                        match v120 with
                                        | UH9_0(v136) -> (* OriginSlotAltLeft *)
                                            match v134 with
                                            | UH2_0(v137) -> (* PositionTreeChar *)
                                                match v136 with
                                                | UH10_0 -> (* OriginSlotChar *)
                                                    let v138 : UH0 = UH0_1
                                                    let v139 : (UH0 -> UH0) = v0 v138
                                                    v139 v133
                                        | UH9_1(v143) -> (* OriginSlotAltRight *)
                                            match v135 with
                                            | UH2_0(v144) -> (* PositionTreeChar *)
                                                match v143 with
                                                | UH10_0 -> (* OriginSlotChar *)
                                                    let v145 : UH0 = UH0_1
                                                    let v146 : (UH0 -> UH0) = v0 v145
                                                    v146 v133
                        | UH7_1(v155) -> (* OriginSlotCatRight *)
                            match v111 with
                            | UH2_0(v156) -> (* PositionTreeChar *)
                                match v155 with
                                | UH10_0 -> (* OriginSlotChar *)
                                    let v157 : UH0 = UH0_1
                                    let v158 : (UH0 -> UH0) = v0 v157
                                    let v159 : UH0 = UH0_1
                                    v158 v159
            let v168 : bool = v108 v167
            if v168 then
                method20(v0, v1, v2, v3, v6)
            else
                false
and method24 (v0 : UH11, v1 : UH11) : US1 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        match v1 with
        | UH11_0 -> (* RegexEmpty *)
            US1_1
        | _ ->
            US1_0
    | UH11_1 -> (* RegexEpsilon *)
        match v1 with
        | UH11_0 -> (* RegexEmpty *)
            US1_2
        | UH11_1 -> (* RegexEpsilon *)
            US1_1
        | _ ->
            US1_0
    | UH11_2(v10) -> (* RegexChar *)
        match v1 with
        | UH11_0 -> (* RegexEmpty *)
            US1_2
        | UH11_1 -> (* RegexEpsilon *)
            US1_2
        | UH11_2(v13) -> (* RegexChar *)
            match v10 with
            | US8_0 -> (* TriA *)
                match v13 with
                | US8_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v13 with
                | US8_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v10 with
                    | US8_1 -> (* TriB *)
                        match v13 with
                        | US8_1 -> (* TriB *)
                            US1_1
                        | US8_2 -> (* TriC *)
                            US1_0
                    | US8_2 -> (* TriC *)
                        match v13 with
                        | US8_1 -> (* TriB *)
                            US1_2
                        | US8_2 -> (* TriC *)
                            US1_1
        | _ ->
            US1_0
    | UH11_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH11_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method24(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method24(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH11_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH11_0 -> (* RegexEmpty *)
            US1_2
        | UH11_1 -> (* RegexEpsilon *)
            US1_2
        | UH11_2(v38) -> (* RegexChar *)
            US1_2
        | UH11_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method24(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method24(v35, v41)
            | _ ->
                v42
        | _ ->
            US1_0
    | UH11_5(v50) -> (* RegexStar *)
        match v1 with
        | UH11_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH11_5(v54) -> (* RegexStar *)
            method24(v50, v54)
        | _ ->
            US1_2
and method23 (v0 : UH11, v1 : UH11) : UH11 =
    match v1 with
    | UH11_0 -> (* RegexEmpty *)
        v0
    | UH11_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method24(v0, v2)
        match v4 with
        | US1_0 -> (* SymbolLess *)
            UH11_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH11 = method23(v0, v3)
            UH11_3(v2, v6)
    | _ ->
        let v11 : US1 = method24(v0, v1)
        match v11 with
        | US1_0 -> (* SymbolLess *)
            UH11_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
        | US1_2 -> (* SymbolGreater *)
            UH11_3(v1, v0)
and method22 (v0 : UH11, v1 : UH11) : UH11 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        v1
    | UH11_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH11 = method23(v2, v1)
        method22(v3, v4)
    | _ ->
        method23(v0, v1)
and method26 (v0 : UH11, v1 : UH11) : bool =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        match v1 with
        | UH11_0 -> (* RegexEmpty *)
            true
        | _ ->
            false
    | UH11_1 -> (* RegexEpsilon *)
        match v1 with
        | UH11_1 -> (* RegexEpsilon *)
            true
        | _ ->
            false
    | UH11_2(v4) -> (* RegexChar *)
        match v1 with
        | UH11_2(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US8_0 -> (* TriA *)
                    match v5 with
                    | US8_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US8_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v4 with
                        | US8_1 -> (* TriB *)
                            match v5 with
                            | US8_1 -> (* TriB *)
                                US1_1
                            | US8_2 -> (* TriC *)
                                US1_0
                        | US8_2 -> (* TriC *)
                            match v5 with
                            | US8_1 -> (* TriB *)
                                US1_2
                            | US8_2 -> (* TriC *)
                                US1_1
            match v21 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH11_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH11_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method26(v24, v26)
            if v28 then
                method26(v25, v27)
            else
                false
        | _ ->
            false
    | UH11_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH11_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method26(v32, v34)
            if v36 then
                method26(v33, v35)
            else
                false
        | _ ->
            false
    | UH11_5(v40) -> (* RegexStar *)
        match v1 with
        | UH11_5(v41) -> (* RegexStar *)
            method26(v40, v41)
        | _ ->
            false
and method25 (v0 : UH11, v1 : UH11) : UH11 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        UH11_0
    | _ ->
        match v1 with
        | UH11_0 -> (* RegexEmpty *)
            UH11_0
        | _ ->
            match v0 with
            | UH11_1 -> (* RegexEpsilon *)
                v1
            | _ ->
                match v1 with
                | UH11_1 -> (* RegexEpsilon *)
                    v0
                | _ ->
                    match v0 with
                    | UH11_4(v12, v13) -> (* RegexCat *)
                        let v14 : UH11 = method25(v13, v1)
                        UH11_4(v12, v14)
                    | UH11_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH11_5(v5) -> (* RegexStar *)
                            let v6 : bool = method26(v4, v5)
                            if v6 then
                                UH11_5(v4)
                            else
                                UH11_4(v0, v1)
                        | _ ->
                            UH11_4(v0, v1)
                    | _ ->
                        UH11_4(v0, v1)
and method27 (v0 : UH11) : UH11 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        UH11_1
    | UH11_1 -> (* RegexEpsilon *)
        UH11_1
    | UH11_5(v3) -> (* RegexStar *)
        UH11_5(v3)
    | _ ->
        UH11_5(v0)
and method21 (v0 : UH11) : UH11 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        UH11_0
    | UH11_1 -> (* RegexEpsilon *)
        UH11_1
    | UH11_2(v3) -> (* RegexChar *)
        UH11_2(v3)
    | UH11_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH11 = method21(v5)
        let v8 : UH11 = method21(v6)
        method22(v7, v8)
    | UH11_4(v10, v11) -> (* RegexCat *)
        let v12 : UH11 = method21(v10)
        let v13 : UH11 = method21(v11)
        method25(v12, v13)
    | UH11_5(v15) -> (* RegexStar *)
        let v16 : UH11 = method21(v15)
        method27(v16)
and method31 (v0 : UH11, v1 : UH12) : bool =
    match v1 with
    | UH12_0 -> (* RegexListNil *)
        false
    | UH12_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method26(v0, v2)
        if v4 then
            true
        else
            method31(v0, v3)
and method30 (v0 : UH11, v1 : UH12) : UH12 =
    let v2 : UH11 = method21(v0)
    let v3 : bool = method31(v2, v1)
    if v3 then
        v1
    else
        UH12_1(v2, v1)
and method29 (v0 : UH12, v1 : UH12) : UH12 =
    match v0 with
    | UH12_0 -> (* RegexListNil *)
        v1
    | UH12_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH12 = method30(v2, v1)
        method29(v3, v4)
and method32 (v0 : UH12, v1 : UH11) : UH12 =
    match v0 with
    | UH12_0 -> (* RegexListNil *)
        UH12_0
    | UH12_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH11 = method25(v3, v1)
        let v6 : UH12 = method32(v4, v1)
        method30(v5, v6)
and method28 (v0 : UH11) : UH12 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        UH12_0
    | UH11_1 -> (* RegexEpsilon *)
        UH12_0
    | UH11_2(v3) -> (* RegexChar *)
        let v4 : UH12 = UH12_0
        let v5 : UH11 = UH11_1
        UH12_1(v5, v4)
    | UH11_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH12 = method28(v7)
        let v10 : UH12 = method28(v8)
        method29(v9, v10)
    | UH11_4(v12, v13) -> (* RegexCat *)
        let v14 : UH12 = method28(v12)
        let v15 : UH12 = method32(v14, v13)
        let v16 : UH12 = method28(v13)
        method29(v15, v16)
    | UH11_5(v18) -> (* RegexStar *)
        let v19 : UH12 = method28(v18)
        let v20 : UH11 = UH11_5(v18)
        method32(v19, v20)
and method33 (v0 : UH12) : bool =
    match v0 with
    | UH12_0 -> (* RegexListNil *)
        true
    | UH12_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = method31(v1, v2)
        if v3 then
            false
        else
            method33(v2)
and method35 (v0 : UH13) : UH6 =
    match v0 with
    | UH13_0(v1) -> (* PositionTreeChar *)
        let v2 : UH6 = UH6_0
        UH6_1(v2)
and method34 (v0 : UH14) : UH6 =
    match v0 with
    | UH14_0(v1) -> (* PositionTreeStar *)
        method35(v1)
and method36 (v0 : UH11) : UH6 =
    match v0 with
    | UH11_0 -> (* RegexEmpty *)
        UH6_0
    | UH11_1 -> (* RegexEpsilon *)
        UH6_0
    | UH11_2(v3) -> (* RegexChar *)
        let v4 : UH6 = UH6_0
        UH6_1(v4)
    | UH11_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH6 = method36(v6)
        let v9 : UH6 = method36(v7)
        method17(v8, v9)
    | UH11_4(v11, v12) -> (* RegexCat *)
        let v13 : UH6 = method36(v11)
        let v14 : UH6 = method36(v12)
        method17(v13, v14)
    | UH11_5(v16) -> (* RegexStar *)
        method36(v16)
and closure5 (v0 : UH11) (v1 : UH11) : UH11 =
    let v2 : UH11 = method25(v0, v1)
    method21(v2)
and closure4 () (v0 : UH11) : (UH11 -> UH11) =
    closure5(v0)
and closure7 (v0 : UH11) (v1 : UH11) : bool =
    method26(v0, v1)
and closure6 () (v0 : UH11) : (UH11 -> bool) =
    closure7(v0)
and method37 (v0 : (UH11 -> (UH11 -> UH11)), v1 : (UH11 -> (UH11 -> bool)), v2 : UH11, v3 : UH14, v4 : UH12) : bool =
    match v4 with
    | UH12_0 -> (* RegexListNil *)
        true
    | UH12_1(v5, v6) -> (* RegexListCons *)
        let v7 : (UH11 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v43 : US9 =
            if v8 then
                let v9 : US10 = US10_0
                US9_1(v9)
            else
                let v36 : US11 =
                    match v3 with
                    | UH14_0(v11) -> (* PositionTreeStar *)
                        let v14 : UH11 =
                            match v11 with
                            | UH13_0(v12) -> (* PositionTreeChar *)
                                UH11_2(v12)
                        let v15 : UH11 = UH11_5(v14)
                        let v16 : (UH11 -> UH11) = v0 v15
                        let v17 : UH11 = UH11_1
                        let v18 : UH11 = v16 v17
                        let v29 : US7 =
                            match v11 with
                            | UH13_0(v19) -> (* PositionTreeChar *)
                                let v20 : UH11 = UH11_1
                                let v21 : (UH11 -> UH11) = v0 v20
                                let v22 : UH11 = v21 v18
                                let v23 : (UH11 -> bool) = v1 v5
                                let v24 : bool = v23 v22
                                if v24 then
                                    let v25 : UH10 = UH10_0
                                    US7_1(v25)
                                else
                                    US7_0
                        match v29 with
                        | US7_1(v30) -> (* OriginSlotFound *)
                            let v31 : UH15 = UH15_0(v30)
                            US11_1(v31)
                        | US7_0 -> (* OriginSlotMissing *)
                            US11_0
                match v36 with
                | US11_1(v37) -> (* OriginSlotFound *)
                    let v38 : US10 = US10_1(v37)
                    US9_1(v38)
                | US11_0 -> (* OriginSlotMissing *)
                    US9_0
        match v43 with
        | US9_0 -> (* SupportSlotMissing *)
            false
        | US9_1(v44) -> (* SupportSlotFound *)
            let v45 : (UH11 -> bool) = v1 v5
            let v65 : UH11 =
                match v44 with
                | US10_0 -> (* SupportSlotRoot *)
                    v2
                | US10_1(v46) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH14_0(v47) -> (* PositionTreeStar *)
                        match v46 with
                        | UH15_0(v48) -> (* OriginSlotStar *)
                            let v51 : UH11 =
                                match v47 with
                                | UH13_0(v49) -> (* PositionTreeChar *)
                                    UH11_2(v49)
                            let v52 : UH11 = UH11_5(v51)
                            let v53 : (UH11 -> UH11) = v0 v52
                            let v54 : UH11 = UH11_1
                            let v55 : UH11 = v53 v54
                            match v47 with
                            | UH13_0(v56) -> (* PositionTreeChar *)
                                match v48 with
                                | UH10_0 -> (* OriginSlotChar *)
                                    let v57 : UH11 = UH11_1
                                    let v58 : (UH11 -> UH11) = v0 v57
                                    v58 v55
            let v66 : bool = v45 v65
            if v66 then
                method37(v0, v1, v2, v3, v6)
            else
                false
and method40 (v0 : UH16) : UH6 =
    match v0 with
    | UH16_0(v1, v2) -> (* PositionTreeAlt *)
        let v3 : UH6 = method35(v1)
        let v4 : UH6 = method35(v2)
        method17(v3, v4)
and method39 (v0 : UH17) : UH6 =
    match v0 with
    | UH17_0(v1) -> (* PositionTreeStar *)
        method40(v1)
and method38 (v0 : UH18) : UH6 =
    match v0 with
    | UH18_0(v1, v2) -> (* PositionTreeCat *)
        let v3 : UH6 = method39(v1)
        let v4 : UH6 = method35(v2)
        method17(v3, v4)
and method41 (v0 : (UH11 -> (UH11 -> UH11)), v1 : (UH11 -> (UH11 -> bool)), v2 : UH11, v3 : UH18, v4 : UH12) : bool =
    match v4 with
    | UH12_0 -> (* RegexListNil *)
        true
    | UH12_1(v5, v6) -> (* RegexListCons *)
        let v7 : (UH11 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v106 : US2 =
            if v8 then
                let v9 : US3 = US3_0
                US2_1(v9)
            else
                let v99 : US4 =
                    match v3 with
                    | UH18_0(v11, v12) -> (* PositionTreeCat *)
                        let v15 : UH11 =
                            match v12 with
                            | UH13_0(v13) -> (* PositionTreeChar *)
                                UH11_2(v13)
                        let v16 : (UH11 -> UH11) = v0 v15
                        let v17 : UH11 = UH11_1
                        let v18 : UH11 = v16 v17
                        let v75 : US5 =
                            match v11 with
                            | UH17_0(v19) -> (* PositionTreeStar *)
                                let v29 : UH11 =
                                    match v19 with
                                    | UH16_0(v20, v21) -> (* PositionTreeAlt *)
                                        let v24 : UH11 =
                                            match v20 with
                                            | UH13_0(v22) -> (* PositionTreeChar *)
                                                UH11_2(v22)
                                        let v27 : UH11 =
                                            match v21 with
                                            | UH13_0(v25) -> (* PositionTreeChar *)
                                                UH11_2(v25)
                                        UH11_3(v24, v27)
                                let v30 : UH11 = UH11_5(v29)
                                let v31 : (UH11 -> UH11) = v0 v30
                                let v32 : UH11 = v31 v18
                                let v68 : US6 =
                                    match v19 with
                                    | UH16_0(v33, v34) -> (* PositionTreeAlt *)
                                        let v45 : US7 =
                                            match v33 with
                                            | UH13_0(v35) -> (* PositionTreeChar *)
                                                let v36 : UH11 = UH11_1
                                                let v37 : (UH11 -> UH11) = v0 v36
                                                let v38 : UH11 = v37 v32
                                                let v39 : (UH11 -> bool) = v1 v5
                                                let v40 : bool = v39 v38
                                                if v40 then
                                                    let v41 : UH10 = UH10_0
                                                    US7_1(v41)
                                                else
                                                    US7_0
                                        match v45 with
                                        | US7_1(v46) -> (* OriginSlotFound *)
                                            let v47 : UH9 = UH9_0(v46)
                                            US6_1(v47)
                                        | US7_0 -> (* OriginSlotMissing *)
                                            let v59 : US7 =
                                                match v34 with
                                                | UH13_0(v49) -> (* PositionTreeChar *)
                                                    let v50 : UH11 = UH11_1
                                                    let v51 : (UH11 -> UH11) = v0 v50
                                                    let v52 : UH11 = v51 v32
                                                    let v53 : (UH11 -> bool) = v1 v5
                                                    let v54 : bool = v53 v52
                                                    if v54 then
                                                        let v55 : UH10 = UH10_0
                                                        US7_1(v55)
                                                    else
                                                        US7_0
                                            match v59 with
                                            | US7_1(v60) -> (* OriginSlotFound *)
                                                let v61 : UH9 = UH9_1(v60)
                                                US6_1(v61)
                                            | US7_0 -> (* OriginSlotMissing *)
                                                US6_0
                                match v68 with
                                | US6_1(v69) -> (* OriginSlotFound *)
                                    let v70 : UH8 = UH8_0(v69)
                                    US5_1(v70)
                                | US6_0 -> (* OriginSlotMissing *)
                                    US5_0
                        match v75 with
                        | US5_1(v76) -> (* OriginSlotFound *)
                            let v77 : UH7 = UH7_0(v76)
                            US4_1(v77)
                        | US5_0 -> (* OriginSlotMissing *)
                            let v90 : US7 =
                                match v12 with
                                | UH13_0(v79) -> (* PositionTreeChar *)
                                    let v80 : UH11 = UH11_1
                                    let v81 : (UH11 -> UH11) = v0 v80
                                    let v82 : UH11 = UH11_1
                                    let v83 : UH11 = v81 v82
                                    let v84 : (UH11 -> bool) = v1 v5
                                    let v85 : bool = v84 v83
                                    if v85 then
                                        let v86 : UH10 = UH10_0
                                        US7_1(v86)
                                    else
                                        US7_0
                            match v90 with
                            | US7_1(v91) -> (* OriginSlotFound *)
                                let v92 : UH7 = UH7_1(v91)
                                US4_1(v92)
                            | US7_0 -> (* OriginSlotMissing *)
                                US4_0
                match v99 with
                | US4_1(v100) -> (* OriginSlotFound *)
                    let v101 : US3 = US3_1(v100)
                    US2_1(v101)
                | US4_0 -> (* OriginSlotMissing *)
                    US2_0
        match v106 with
        | US2_0 -> (* SupportSlotMissing *)
            false
        | US2_1(v107) -> (* SupportSlotFound *)
            let v108 : (UH11 -> bool) = v1 v5
            let v167 : UH11 =
                match v107 with
                | US3_0 -> (* SupportSlotRoot *)
                    v2
                | US3_1(v109) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH18_0(v110, v111) -> (* PositionTreeCat *)
                        match v109 with
                        | UH7_0(v112) -> (* OriginSlotCatLeft *)
                            let v115 : UH11 =
                                match v111 with
                                | UH13_0(v113) -> (* PositionTreeChar *)
                                    UH11_2(v113)
                            let v116 : (UH11 -> UH11) = v0 v115
                            let v117 : UH11 = UH11_1
                            let v118 : UH11 = v116 v117
                            match v110 with
                            | UH17_0(v119) -> (* PositionTreeStar *)
                                match v112 with
                                | UH8_0(v120) -> (* OriginSlotStar *)
                                    let v130 : UH11 =
                                        match v119 with
                                        | UH16_0(v121, v122) -> (* PositionTreeAlt *)
                                            let v125 : UH11 =
                                                match v121 with
                                                | UH13_0(v123) -> (* PositionTreeChar *)
                                                    UH11_2(v123)
                                            let v128 : UH11 =
                                                match v122 with
                                                | UH13_0(v126) -> (* PositionTreeChar *)
                                                    UH11_2(v126)
                                            UH11_3(v125, v128)
                                    let v131 : UH11 = UH11_5(v130)
                                    let v132 : (UH11 -> UH11) = v0 v131
                                    let v133 : UH11 = v132 v118
                                    match v119 with
                                    | UH16_0(v134, v135) -> (* PositionTreeAlt *)
                                        match v120 with
                                        | UH9_0(v136) -> (* OriginSlotAltLeft *)
                                            match v134 with
                                            | UH13_0(v137) -> (* PositionTreeChar *)
                                                match v136 with
                                                | UH10_0 -> (* OriginSlotChar *)
                                                    let v138 : UH11 = UH11_1
                                                    let v139 : (UH11 -> UH11) = v0 v138
                                                    v139 v133
                                        | UH9_1(v143) -> (* OriginSlotAltRight *)
                                            match v135 with
                                            | UH13_0(v144) -> (* PositionTreeChar *)
                                                match v143 with
                                                | UH10_0 -> (* OriginSlotChar *)
                                                    let v145 : UH11 = UH11_1
                                                    let v146 : (UH11 -> UH11) = v0 v145
                                                    v146 v133
                        | UH7_1(v155) -> (* OriginSlotCatRight *)
                            match v111 with
                            | UH13_0(v156) -> (* PositionTreeChar *)
                                match v155 with
                                | UH10_0 -> (* OriginSlotChar *)
                                    let v157 : UH11 = UH11_1
                                    let v158 : (UH11 -> UH11) = v0 v157
                                    let v159 : UH11 = UH11_1
                                    v158 v159
            let v168 : bool = v108 v167
            if v168 then
                method41(v0, v1, v2, v3, v6)
            else
                false
let v0 : US0 = US0_0
let v1 : UH0 = UH0_2(v0)
let v2 : US0 = US0_1
let v3 : UH0 = UH0_2(v2)
let v4 : US0 = US0_0
let v5 : UH0 = UH0_2(v4)
let v6 : UH0 = UH0_3(v5, v3)
let v7 : UH0 = UH0_5(v6)
let v8 : UH0 = UH0_4(v7, v1)
let v9 : UH0 = method0(v8)
let v10 : UH0 = method0(v9)
let v11 : UH1 = method7(v10)
let v12 : UH1 = method9(v10, v11)
let v13 : bool = method12(v12)
let v14 : US0 = US0_0
let v15 : UH0 = UH0_2(v14)
let v16 : US0 = US0_1
let v17 : UH0 = UH0_2(v16)
let v18 : US0 = US0_0
let v19 : UH0 = UH0_2(v18)
let v20 : UH0 = UH0_3(v19, v17)
let v21 : UH0 = UH0_5(v20)
let v22 : UH0 = UH0_4(v21, v15)
let v23 : UH0 = method0(v22)
let v24 : bool = method5(v23, v9)
let v37 : bool =
    if v24 then
        let v25 : US0 = US0_0
        let v26 : UH2 = UH2_0(v25)
        let v27 : US0 = US0_1
        let v28 : UH2 = UH2_0(v27)
        let v29 : US0 = US0_0
        let v30 : UH2 = UH2_0(v29)
        let v31 : UH3 = UH3_0(v30, v28)
        let v32 : UH4 = UH4_0(v31)
        let v33 : UH5 = UH5_0(v32, v26)
        let v34 : UH6 = method13(v33)
        let v35 : UH6 = method18(v9)
        method19(v34, v35)
    else
        false
let v38 : bool = v37 && v13
let v51 : bool =
    if v38 then
        let v39 : (UH0 -> (UH0 -> UH0)) = closure0()
        let v40 : (UH0 -> (UH0 -> bool)) = closure2()
        let v41 : US0 = US0_0
        let v42 : UH2 = UH2_0(v41)
        let v43 : US0 = US0_1
        let v44 : UH2 = UH2_0(v43)
        let v45 : US0 = US0_0
        let v46 : UH2 = UH2_0(v45)
        let v47 : UH3 = UH3_0(v46, v44)
        let v48 : UH4 = UH4_0(v47)
        let v49 : UH5 = UH5_0(v48, v42)
        method20(v39, v40, v9, v49, v12)
    else
        false
if v51 then
    ()
else
    let v52 : string = "bit Antimirov support must fit the typed root-plus-position slot universe"
    failwith v52
    ()
let v53 : US0 = US0_0
let v54 : UH0 = UH0_2(v53)
let v55 : US0 = US0_1
let v56 : UH0 = UH0_2(v55)
let v57 : US0 = US0_0
let v58 : UH0 = UH0_2(v57)
let v59 : UH0 = UH0_3(v58, v56)
let v60 : UH0 = UH0_5(v59)
let v61 : UH0 = UH0_4(v60, v54)
let v62 : UH0 = method0(v61)
let v63 : UH0 = method0(v62)
let v64 : UH1 = method7(v63)
let v65 : UH1 = method9(v63, v64)
let v66 : bool = method12(v65)
let v67 : US0 = US0_1
let v68 : UH0 = UH0_2(v67)
let v69 : US0 = US0_1
let v70 : UH0 = UH0_2(v69)
let v71 : US0 = US0_0
let v72 : UH0 = UH0_2(v71)
let v73 : UH0 = UH0_3(v72, v70)
let v74 : UH0 = UH0_5(v73)
let v75 : UH0 = UH0_4(v74, v68)
let v76 : UH0 = method0(v75)
let v77 : bool = method5(v76, v62)
let v90 : bool =
    if v77 then
        let v78 : US0 = US0_1
        let v79 : UH2 = UH2_0(v78)
        let v80 : US0 = US0_1
        let v81 : UH2 = UH2_0(v80)
        let v82 : US0 = US0_0
        let v83 : UH2 = UH2_0(v82)
        let v84 : UH3 = UH3_0(v83, v81)
        let v85 : UH4 = UH4_0(v84)
        let v86 : UH5 = UH5_0(v85, v79)
        let v87 : UH6 = method13(v86)
        let v88 : UH6 = method18(v62)
        method19(v87, v88)
    else
        false
let v91 : bool = v90 && v66
let v104 : bool =
    if v91 then
        let v92 : (UH0 -> (UH0 -> UH0)) = closure0()
        let v93 : (UH0 -> (UH0 -> bool)) = closure2()
        let v94 : US0 = US0_1
        let v95 : UH2 = UH2_0(v94)
        let v96 : US0 = US0_1
        let v97 : UH2 = UH2_0(v96)
        let v98 : US0 = US0_0
        let v99 : UH2 = UH2_0(v98)
        let v100 : UH3 = UH3_0(v99, v97)
        let v101 : UH4 = UH4_0(v100)
        let v102 : UH5 = UH5_0(v101, v95)
        method20(v92, v93, v62, v102, v65)
    else
        false
let v105 : bool = v104 = false
if v105 then
    ()
else
    let v106 : string = "same-cardinality forged typed position tree must not certify the source regex"
    failwith v106
    ()
let v107 : US8 = US8_0
let v108 : UH11 = UH11_2(v107)
let v109 : UH11 = UH11_5(v108)
let v110 : UH11 = method21(v109)
let v111 : UH11 = method21(v110)
let v112 : UH12 = method28(v111)
let v113 : UH12 = method30(v111, v112)
let v114 : bool = method33(v113)
let v115 : US8 = US8_0
let v116 : UH11 = UH11_2(v115)
let v117 : UH11 = UH11_5(v116)
let v118 : UH11 = method21(v117)
let v119 : bool = method26(v118, v110)
let v126 : bool =
    if v119 then
        let v120 : US8 = US8_0
        let v121 : UH13 = UH13_0(v120)
        let v122 : UH14 = UH14_0(v121)
        let v123 : UH6 = method34(v122)
        let v124 : UH6 = method36(v110)
        method19(v123, v124)
    else
        false
let v127 : bool = v126 && v114
let v134 : bool =
    if v127 then
        let v128 : (UH11 -> (UH11 -> UH11)) = closure4()
        let v129 : (UH11 -> (UH11 -> bool)) = closure6()
        let v130 : US8 = US8_0
        let v131 : UH13 = UH13_0(v130)
        let v132 : UH14 = UH14_0(v131)
        method37(v128, v129, v110, v132, v113)
    else
        false
if v134 then
    ()
else
    let v135 : string = "ternary star support must fit the typed root-plus-position slot universe"
    failwith v135
    ()
let v136 : US8 = US8_2
let v137 : UH11 = UH11_2(v136)
let v138 : US8 = US8_1
let v139 : UH11 = UH11_2(v138)
let v140 : US8 = US8_0
let v141 : UH11 = UH11_2(v140)
let v142 : UH11 = UH11_3(v141, v139)
let v143 : UH11 = UH11_5(v142)
let v144 : UH11 = UH11_4(v143, v137)
let v145 : UH11 = method21(v144)
let v146 : UH11 = method21(v145)
let v147 : UH12 = method28(v146)
let v148 : UH12 = method30(v146, v147)
let v149 : bool = method33(v148)
let v150 : US8 = US8_2
let v151 : UH11 = UH11_2(v150)
let v152 : US8 = US8_1
let v153 : UH11 = UH11_2(v152)
let v154 : US8 = US8_0
let v155 : UH11 = UH11_2(v154)
let v156 : UH11 = UH11_3(v155, v153)
let v157 : UH11 = UH11_5(v156)
let v158 : UH11 = UH11_4(v157, v151)
let v159 : UH11 = method21(v158)
let v160 : bool = method26(v159, v145)
let v173 : bool =
    if v160 then
        let v161 : US8 = US8_2
        let v162 : UH13 = UH13_0(v161)
        let v163 : US8 = US8_1
        let v164 : UH13 = UH13_0(v163)
        let v165 : US8 = US8_0
        let v166 : UH13 = UH13_0(v165)
        let v167 : UH16 = UH16_0(v166, v164)
        let v168 : UH17 = UH17_0(v167)
        let v169 : UH18 = UH18_0(v168, v162)
        let v170 : UH6 = method38(v169)
        let v171 : UH6 = method36(v145)
        method19(v170, v171)
    else
        false
let v174 : bool = v173 && v149
let v187 : bool =
    if v174 then
        let v175 : (UH11 -> (UH11 -> UH11)) = closure4()
        let v176 : (UH11 -> (UH11 -> bool)) = closure6()
        let v177 : US8 = US8_2
        let v178 : UH13 = UH13_0(v177)
        let v179 : US8 = US8_1
        let v180 : UH13 = UH13_0(v179)
        let v181 : US8 = US8_0
        let v182 : UH13 = UH13_0(v181)
        let v183 : UH16 = UH16_0(v182, v180)
        let v184 : UH17 = UH17_0(v183)
        let v185 : UH18 = UH18_0(v184, v178)
        method41(v175, v176, v145, v185, v148)
    else
        false
if v187 then
    ()
else
    let v188 : string = "ternary cat/alt/star support must fit the typed root-plus-position slot universe"
    failwith v188
    ()
let v189 : string = "brzozowski-antimirov-typed-slot-bound-green"
v189
