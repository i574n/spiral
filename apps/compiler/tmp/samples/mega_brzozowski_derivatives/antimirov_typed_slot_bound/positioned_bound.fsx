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
    | UH2_2 of US0
and UH3 =
    | UH3_3 of UH2 * UH2
and UH4 =
    | UH4_5 of UH3
and UH5 =
    | UH5_4 of UH4 * UH2
and UH9 =
    | UH9_0
and UH8 =
    | UH8_1 of UH9
    | UH8_2 of UH9
and UH7 =
    | UH7_5 of UH8
and UH6 =
    | UH6_3 of UH7
    | UH6_4 of UH9
and [<Struct>] US3 =
    | US3_0
    | US3_1 of f1_0 : UH6
and [<Struct>] US2 =
    | US2_0
    | US2_1 of f1_0 : US3
and [<Struct>] US4 =
    | US4_0
    | US4_1 of f1_0 : UH6
and [<Struct>] US5 =
    | US5_0
    | US5_1 of f1_0 : UH7
and [<Struct>] US6 =
    | US6_0
    | US6_1 of f1_0 : UH8
and [<Struct>] US7 =
    | US7_0
    | US7_1 of f1_0 : UH9
and [<Struct>] US8 =
    | US8_0
    | US8_1 of f1_0 : UH5
and [<Struct>] US9 =
    | US9_0
    | US9_1
    | US9_2
and UH10 =
    | UH10_0
    | UH10_1
    | UH10_2 of US9
    | UH10_3 of UH10 * UH10
    | UH10_4 of UH10 * UH10
    | UH10_5 of UH10
and UH11 =
    | UH11_0
    | UH11_1 of UH10 * UH11
and UH12 =
    | UH12_2 of US9
and UH13 =
    | UH13_3 of UH12 * UH12
and UH14 =
    | UH14_5 of UH13
and UH15 =
    | UH15_4 of UH14 * UH12
and [<Struct>] US10 =
    | US10_0
    | US10_1 of f1_0 : UH15
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
and method10 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method5(v0, v2)
        if v4 then
            true
        else
            method10(v0, v3)
    | UH1_0 -> (* RegexListNil *)
        false
and method9 (v0 : UH0, v1 : UH1) : UH1 =
    let v2 : UH0 = method0(v0)
    let v3 : bool = method10(v2, v1)
    if v3 then
        v1
    else
        UH1_1(v2, v1)
and method8 (v0 : UH1, v1 : UH1) : UH1 =
    match v0 with
    | UH1_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH1 = method9(v2, v1)
        method8(v3, v4)
    | UH1_0 -> (* RegexListNil *)
        v1
and method11 (v0 : UH1, v1 : UH0) : UH1 =
    match v0 with
    | UH1_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH0 = method4(v3, v1)
        let v6 : UH1 = method11(v4, v1)
        method9(v5, v6)
    | UH1_0 -> (* RegexListNil *)
        UH1_0
and method7 (v0 : UH0) : UH1 =
    match v0 with
    | UH0_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH1 = method7(v7)
        let v10 : UH1 = method7(v8)
        method8(v9, v10)
    | UH0_4(v12, v13) -> (* RegexCat *)
        let v14 : UH1 = method7(v12)
        let v15 : UH1 = method11(v14, v13)
        let v16 : UH1 = method7(v13)
        method8(v15, v16)
    | UH0_2(v3) -> (* RegexChar *)
        let v4 : UH0 = UH0_1
        let v5 : UH1 = UH1_0
        UH1_1(v4, v5)
    | UH0_0 -> (* RegexEmpty *)
        UH1_0
    | UH0_1 -> (* RegexEpsilon *)
        UH1_0
    | UH0_5(v18) -> (* RegexStar *)
        let v19 : UH1 = method7(v18)
        let v20 : UH0 = UH0_5(v18)
        method11(v19, v20)
and method12 (v0 : UH1) : bool =
    match v0 with
    | UH1_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = method10(v1, v2)
        if v3 then
            false
        else
            method12(v2)
    | UH1_0 -> (* RegexListNil *)
        true
and closure1 (v0 : UH0) (v1 : UH0) : UH0 =
    let v2 : UH0 = method4(v0, v1)
    method0(v2)
and closure0 () (v0 : UH0) : (UH0 -> UH0) =
    closure1(v0)
and closure3 (v0 : UH0) (v1 : UH0) : bool =
    method5(v0, v1)
and closure2 () (v0 : UH0) : (UH0 -> bool) =
    closure3(v0)
and method13 (v0 : (UH0 -> (UH0 -> UH0)), v1 : (UH0 -> (UH0 -> bool)), v2 : UH0, v3 : UH5, v4 : UH1) : bool =
    match v4 with
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
                    | UH5_4(v11, v12) -> (* PositionTreeCat *)
                        let v15 : UH0 =
                            match v12 with
                            | UH2_2(v13) -> (* PositionTreeChar *)
                                UH0_2(v13)
                        let v16 : (UH0 -> UH0) = v0 v15
                        let v17 : UH0 = UH0_1
                        let v18 : UH0 = v16 v17
                        let v75 : US5 =
                            match v11 with
                            | UH4_5(v19) -> (* PositionTreeStar *)
                                let v29 : UH0 =
                                    match v19 with
                                    | UH3_3(v20, v21) -> (* PositionTreeAlt *)
                                        let v24 : UH0 =
                                            match v20 with
                                            | UH2_2(v22) -> (* PositionTreeChar *)
                                                UH0_2(v22)
                                        let v27 : UH0 =
                                            match v21 with
                                            | UH2_2(v25) -> (* PositionTreeChar *)
                                                UH0_2(v25)
                                        UH0_3(v24, v27)
                                let v30 : UH0 = UH0_5(v29)
                                let v31 : (UH0 -> UH0) = v0 v30
                                let v32 : UH0 = v31 v18
                                let v68 : US6 =
                                    match v19 with
                                    | UH3_3(v33, v34) -> (* PositionTreeAlt *)
                                        let v45 : US7 =
                                            match v33 with
                                            | UH2_2(v35) -> (* PositionTreeChar *)
                                                let v36 : UH0 = UH0_1
                                                let v37 : (UH0 -> UH0) = v0 v36
                                                let v38 : UH0 = v37 v32
                                                let v39 : (UH0 -> bool) = v1 v5
                                                let v40 : bool = v39 v38
                                                if v40 then
                                                    let v41 : UH9 = UH9_0
                                                    US7_1(v41)
                                                else
                                                    US7_0
                                        match v45 with
                                        | US7_1(v46) -> (* OriginSlotFound *)
                                            let v47 : UH8 = UH8_1(v46)
                                            US6_1(v47)
                                        | US7_0 -> (* OriginSlotMissing *)
                                            let v59 : US7 =
                                                match v34 with
                                                | UH2_2(v49) -> (* PositionTreeChar *)
                                                    let v50 : UH0 = UH0_1
                                                    let v51 : (UH0 -> UH0) = v0 v50
                                                    let v52 : UH0 = v51 v32
                                                    let v53 : (UH0 -> bool) = v1 v5
                                                    let v54 : bool = v53 v52
                                                    if v54 then
                                                        let v55 : UH9 = UH9_0
                                                        US7_1(v55)
                                                    else
                                                        US7_0
                                            match v59 with
                                            | US7_1(v60) -> (* OriginSlotFound *)
                                                let v61 : UH8 = UH8_2(v60)
                                                US6_1(v61)
                                            | US7_0 -> (* OriginSlotMissing *)
                                                US6_0
                                match v68 with
                                | US6_1(v69) -> (* OriginSlotFound *)
                                    let v70 : UH7 = UH7_5(v69)
                                    US5_1(v70)
                                | US6_0 -> (* OriginSlotMissing *)
                                    US5_0
                        match v75 with
                        | US5_1(v76) -> (* OriginSlotFound *)
                            let v77 : UH6 = UH6_3(v76)
                            US4_1(v77)
                        | US5_0 -> (* OriginSlotMissing *)
                            let v90 : US7 =
                                match v12 with
                                | UH2_2(v79) -> (* PositionTreeChar *)
                                    let v80 : UH0 = UH0_1
                                    let v81 : (UH0 -> UH0) = v0 v80
                                    let v82 : UH0 = UH0_1
                                    let v83 : UH0 = v81 v82
                                    let v84 : (UH0 -> bool) = v1 v5
                                    let v85 : bool = v84 v83
                                    if v85 then
                                        let v86 : UH9 = UH9_0
                                        US7_1(v86)
                                    else
                                        US7_0
                            match v90 with
                            | US7_1(v91) -> (* OriginSlotFound *)
                                let v92 : UH6 = UH6_4(v91)
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
        | US2_1(v107) -> (* SupportSlotFound *)
            let v108 : (UH0 -> bool) = v1 v5
            let v167 : UH0 =
                match v107 with
                | US3_1(v109) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH5_4(v110, v111) -> (* PositionTreeCat *)
                        match v109 with
                        | UH6_3(v112) -> (* OriginSlotCatLeft *)
                            let v115 : UH0 =
                                match v111 with
                                | UH2_2(v113) -> (* PositionTreeChar *)
                                    UH0_2(v113)
                            let v116 : (UH0 -> UH0) = v0 v115
                            let v117 : UH0 = UH0_1
                            let v118 : UH0 = v116 v117
                            match v110 with
                            | UH4_5(v119) -> (* PositionTreeStar *)
                                match v112 with
                                | UH7_5(v120) -> (* OriginSlotStar *)
                                    let v130 : UH0 =
                                        match v119 with
                                        | UH3_3(v121, v122) -> (* PositionTreeAlt *)
                                            let v125 : UH0 =
                                                match v121 with
                                                | UH2_2(v123) -> (* PositionTreeChar *)
                                                    UH0_2(v123)
                                            let v128 : UH0 =
                                                match v122 with
                                                | UH2_2(v126) -> (* PositionTreeChar *)
                                                    UH0_2(v126)
                                            UH0_3(v125, v128)
                                    let v131 : UH0 = UH0_5(v130)
                                    let v132 : (UH0 -> UH0) = v0 v131
                                    let v133 : UH0 = v132 v118
                                    match v119 with
                                    | UH3_3(v134, v135) -> (* PositionTreeAlt *)
                                        match v120 with
                                        | UH8_1(v136) -> (* OriginSlotAltLeft *)
                                            match v134 with
                                            | UH2_2(v137) -> (* PositionTreeChar *)
                                                match v136 with
                                                | UH9_0 -> (* OriginSlotChar *)
                                                    let v138 : UH0 = UH0_1
                                                    let v139 : (UH0 -> UH0) = v0 v138
                                                    v139 v133
                                        | UH8_2(v143) -> (* OriginSlotAltRight *)
                                            match v135 with
                                            | UH2_2(v144) -> (* PositionTreeChar *)
                                                match v143 with
                                                | UH9_0 -> (* OriginSlotChar *)
                                                    let v145 : UH0 = UH0_1
                                                    let v146 : (UH0 -> UH0) = v0 v145
                                                    v146 v133
                        | UH6_4(v155) -> (* OriginSlotCatRight *)
                            match v111 with
                            | UH2_2(v156) -> (* PositionTreeChar *)
                                match v155 with
                                | UH9_0 -> (* OriginSlotChar *)
                                    let v157 : UH0 = UH0_1
                                    let v158 : (UH0 -> UH0) = v0 v157
                                    let v159 : UH0 = UH0_1
                                    v158 v159
                | US3_0 -> (* SupportSlotRoot *)
                    v2
            let v168 : bool = v108 v167
            if v168 then
                method13(v0, v1, v2, v3, v6)
            else
                false
        | US2_0 -> (* SupportSlotMissing *)
            false
    | UH1_0 -> (* RegexListNil *)
        true
and method17 (v0 : UH10, v1 : UH10) : US1 =
    match v0 with
    | UH10_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH10_3(v61, v62) -> (* RegexAlt *)
            let v63 : US1 = method17(v59, v61)
            match v63 with
            | US1_1 -> (* SymbolSame *)
                method17(v60, v62)
            | _ ->
                v63
        | _ ->
            US1_2
    | UH10_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH10_4(v40, v41) -> (* RegexCat *)
            let v42 : US1 = method17(v34, v40)
            match v42 with
            | US1_1 -> (* SymbolSame *)
                method17(v35, v41)
            | _ ->
                v42
        | UH10_2(v38) -> (* RegexChar *)
            US1_2
        | UH10_0 -> (* RegexEmpty *)
            US1_2
        | UH10_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
    | UH10_2(v10) -> (* RegexChar *)
        match v1 with
        | UH10_2(v13) -> (* RegexChar *)
            match v10 with
            | US9_0 -> (* TriA *)
                match v13 with
                | US9_0 -> (* TriA *)
                    US1_1
                | _ ->
                    US1_0
            | _ ->
                match v13 with
                | US9_0 -> (* TriA *)
                    US1_2
                | _ ->
                    match v10 with
                    | US9_1 -> (* TriB *)
                        match v13 with
                        | US9_1 -> (* TriB *)
                            US1_1
                        | US9_2 -> (* TriC *)
                            US1_0
                    | US9_2 -> (* TriC *)
                        match v13 with
                        | US9_1 -> (* TriB *)
                            US1_2
                        | US9_2 -> (* TriC *)
                            US1_1
        | UH10_0 -> (* RegexEmpty *)
            US1_2
        | UH10_1 -> (* RegexEpsilon *)
            US1_2
        | _ ->
            US1_0
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
    | UH10_5(v50) -> (* RegexStar *)
        match v1 with
        | UH10_3(v51, v52) -> (* RegexAlt *)
            US1_0
        | UH10_5(v54) -> (* RegexStar *)
            method17(v50, v54)
        | _ ->
            US1_2
and method16 (v0 : UH10, v1 : UH10) : UH10 =
    match v1 with
    | UH10_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method17(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH10 = method16(v0, v3)
            UH10_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH10_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH10_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method17(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH10_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH10_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method15 (v0 : UH10, v1 : UH10) : UH10 =
    match v0 with
    | UH10_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH10 = method16(v2, v1)
        method15(v3, v4)
    | UH10_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method16(v0, v1)
and method19 (v0 : UH10, v1 : UH10) : bool =
    match v0 with
    | UH10_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH10_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method19(v24, v26)
            if v28 then
                method19(v25, v27)
            else
                false
        | _ ->
            false
    | UH10_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH10_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method19(v32, v34)
            if v36 then
                method19(v33, v35)
            else
                false
        | _ ->
            false
    | UH10_2(v4) -> (* RegexChar *)
        match v1 with
        | UH10_2(v5) -> (* RegexChar *)
            let v21 : US1 =
                match v4 with
                | US9_0 -> (* TriA *)
                    match v5 with
                    | US9_0 -> (* TriA *)
                        US1_1
                    | _ ->
                        US1_0
                | _ ->
                    match v5 with
                    | US9_0 -> (* TriA *)
                        US1_2
                    | _ ->
                        match v4 with
                        | US9_1 -> (* TriB *)
                            match v5 with
                            | US9_1 -> (* TriB *)
                                US1_1
                            | US9_2 -> (* TriC *)
                                US1_0
                        | US9_2 -> (* TriC *)
                            match v5 with
                            | US9_1 -> (* TriB *)
                                US1_2
                            | US9_2 -> (* TriC *)
                                US1_1
            match v21 with
            | US1_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
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
    | UH10_5(v40) -> (* RegexStar *)
        match v1 with
        | UH10_5(v41) -> (* RegexStar *)
            method19(v40, v41)
        | _ ->
            false
and method18 (v0 : UH10, v1 : UH10) : UH10 =
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
                        let v14 : UH10 = method18(v13, v1)
                        UH10_4(v12, v14)
                    | UH10_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH10_5(v5) -> (* RegexStar *)
                            let v6 : bool = method19(v4, v5)
                            if v6 then
                                UH10_5(v4)
                            else
                                UH10_4(v0, v1)
                        | _ ->
                            UH10_4(v0, v1)
                    | _ ->
                        UH10_4(v0, v1)
and method20 (v0 : UH10) : UH10 =
    match v0 with
    | UH10_0 -> (* RegexEmpty *)
        UH10_1
    | UH10_1 -> (* RegexEpsilon *)
        UH10_1
    | UH10_5(v3) -> (* RegexStar *)
        UH10_5(v3)
    | _ ->
        UH10_5(v0)
and method14 (v0 : UH10) : UH10 =
    match v0 with
    | UH10_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH10 = method14(v5)
        let v8 : UH10 = method14(v6)
        method15(v7, v8)
    | UH10_4(v10, v11) -> (* RegexCat *)
        let v12 : UH10 = method14(v10)
        let v13 : UH10 = method14(v11)
        method18(v12, v13)
    | UH10_2(v3) -> (* RegexChar *)
        UH10_2(v3)
    | UH10_0 -> (* RegexEmpty *)
        UH10_0
    | UH10_1 -> (* RegexEpsilon *)
        UH10_1
    | UH10_5(v15) -> (* RegexStar *)
        let v16 : UH10 = method14(v15)
        method20(v16)
and method24 (v0 : UH10, v1 : UH11) : bool =
    match v1 with
    | UH11_1(v2, v3) -> (* RegexListCons *)
        let v4 : bool = method19(v0, v2)
        if v4 then
            true
        else
            method24(v0, v3)
    | UH11_0 -> (* RegexListNil *)
        false
and method23 (v0 : UH10, v1 : UH11) : UH11 =
    let v2 : UH10 = method14(v0)
    let v3 : bool = method24(v2, v1)
    if v3 then
        v1
    else
        UH11_1(v2, v1)
and method22 (v0 : UH11, v1 : UH11) : UH11 =
    match v0 with
    | UH11_1(v2, v3) -> (* RegexListCons *)
        let v4 : UH11 = method23(v2, v1)
        method22(v3, v4)
    | UH11_0 -> (* RegexListNil *)
        v1
and method25 (v0 : UH11, v1 : UH10) : UH11 =
    match v0 with
    | UH11_1(v3, v4) -> (* RegexListCons *)
        let v5 : UH10 = method18(v3, v1)
        let v6 : UH11 = method25(v4, v1)
        method23(v5, v6)
    | UH11_0 -> (* RegexListNil *)
        UH11_0
and method21 (v0 : UH10) : UH11 =
    match v0 with
    | UH10_3(v7, v8) -> (* RegexAlt *)
        let v9 : UH11 = method21(v7)
        let v10 : UH11 = method21(v8)
        method22(v9, v10)
    | UH10_4(v12, v13) -> (* RegexCat *)
        let v14 : UH11 = method21(v12)
        let v15 : UH11 = method25(v14, v13)
        let v16 : UH11 = method21(v13)
        method22(v15, v16)
    | UH10_2(v3) -> (* RegexChar *)
        let v4 : UH10 = UH10_1
        let v5 : UH11 = UH11_0
        UH11_1(v4, v5)
    | UH10_0 -> (* RegexEmpty *)
        UH11_0
    | UH10_1 -> (* RegexEpsilon *)
        UH11_0
    | UH10_5(v18) -> (* RegexStar *)
        let v19 : UH11 = method21(v18)
        let v20 : UH10 = UH10_5(v18)
        method25(v19, v20)
and method26 (v0 : UH11) : bool =
    match v0 with
    | UH11_1(v1, v2) -> (* RegexListCons *)
        let v3 : bool = method24(v1, v2)
        if v3 then
            false
        else
            method26(v2)
    | UH11_0 -> (* RegexListNil *)
        true
and closure5 (v0 : UH10) (v1 : UH10) : UH10 =
    let v2 : UH10 = method18(v0, v1)
    method14(v2)
and closure4 () (v0 : UH10) : (UH10 -> UH10) =
    closure5(v0)
and closure7 (v0 : UH10) (v1 : UH10) : bool =
    method19(v0, v1)
and closure6 () (v0 : UH10) : (UH10 -> bool) =
    closure7(v0)
and method27 (v0 : (UH10 -> (UH10 -> UH10)), v1 : (UH10 -> (UH10 -> bool)), v2 : UH10, v3 : UH15, v4 : UH11) : bool =
    match v4 with
    | UH11_1(v5, v6) -> (* RegexListCons *)
        let v7 : (UH10 -> bool) = v1 v2
        let v8 : bool = v7 v5
        let v106 : US2 =
            if v8 then
                let v9 : US3 = US3_0
                US2_1(v9)
            else
                let v99 : US4 =
                    match v3 with
                    | UH15_4(v11, v12) -> (* PositionTreeCat *)
                        let v15 : UH10 =
                            match v12 with
                            | UH12_2(v13) -> (* PositionTreeChar *)
                                UH10_2(v13)
                        let v16 : (UH10 -> UH10) = v0 v15
                        let v17 : UH10 = UH10_1
                        let v18 : UH10 = v16 v17
                        let v75 : US5 =
                            match v11 with
                            | UH14_5(v19) -> (* PositionTreeStar *)
                                let v29 : UH10 =
                                    match v19 with
                                    | UH13_3(v20, v21) -> (* PositionTreeAlt *)
                                        let v24 : UH10 =
                                            match v20 with
                                            | UH12_2(v22) -> (* PositionTreeChar *)
                                                UH10_2(v22)
                                        let v27 : UH10 =
                                            match v21 with
                                            | UH12_2(v25) -> (* PositionTreeChar *)
                                                UH10_2(v25)
                                        UH10_3(v24, v27)
                                let v30 : UH10 = UH10_5(v29)
                                let v31 : (UH10 -> UH10) = v0 v30
                                let v32 : UH10 = v31 v18
                                let v68 : US6 =
                                    match v19 with
                                    | UH13_3(v33, v34) -> (* PositionTreeAlt *)
                                        let v45 : US7 =
                                            match v33 with
                                            | UH12_2(v35) -> (* PositionTreeChar *)
                                                let v36 : UH10 = UH10_1
                                                let v37 : (UH10 -> UH10) = v0 v36
                                                let v38 : UH10 = v37 v32
                                                let v39 : (UH10 -> bool) = v1 v5
                                                let v40 : bool = v39 v38
                                                if v40 then
                                                    let v41 : UH9 = UH9_0
                                                    US7_1(v41)
                                                else
                                                    US7_0
                                        match v45 with
                                        | US7_1(v46) -> (* OriginSlotFound *)
                                            let v47 : UH8 = UH8_1(v46)
                                            US6_1(v47)
                                        | US7_0 -> (* OriginSlotMissing *)
                                            let v59 : US7 =
                                                match v34 with
                                                | UH12_2(v49) -> (* PositionTreeChar *)
                                                    let v50 : UH10 = UH10_1
                                                    let v51 : (UH10 -> UH10) = v0 v50
                                                    let v52 : UH10 = v51 v32
                                                    let v53 : (UH10 -> bool) = v1 v5
                                                    let v54 : bool = v53 v52
                                                    if v54 then
                                                        let v55 : UH9 = UH9_0
                                                        US7_1(v55)
                                                    else
                                                        US7_0
                                            match v59 with
                                            | US7_1(v60) -> (* OriginSlotFound *)
                                                let v61 : UH8 = UH8_2(v60)
                                                US6_1(v61)
                                            | US7_0 -> (* OriginSlotMissing *)
                                                US6_0
                                match v68 with
                                | US6_1(v69) -> (* OriginSlotFound *)
                                    let v70 : UH7 = UH7_5(v69)
                                    US5_1(v70)
                                | US6_0 -> (* OriginSlotMissing *)
                                    US5_0
                        match v75 with
                        | US5_1(v76) -> (* OriginSlotFound *)
                            let v77 : UH6 = UH6_3(v76)
                            US4_1(v77)
                        | US5_0 -> (* OriginSlotMissing *)
                            let v90 : US7 =
                                match v12 with
                                | UH12_2(v79) -> (* PositionTreeChar *)
                                    let v80 : UH10 = UH10_1
                                    let v81 : (UH10 -> UH10) = v0 v80
                                    let v82 : UH10 = UH10_1
                                    let v83 : UH10 = v81 v82
                                    let v84 : (UH10 -> bool) = v1 v5
                                    let v85 : bool = v84 v83
                                    if v85 then
                                        let v86 : UH9 = UH9_0
                                        US7_1(v86)
                                    else
                                        US7_0
                            match v90 with
                            | US7_1(v91) -> (* OriginSlotFound *)
                                let v92 : UH6 = UH6_4(v91)
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
        | US2_1(v107) -> (* SupportSlotFound *)
            let v108 : (UH10 -> bool) = v1 v5
            let v167 : UH10 =
                match v107 with
                | US3_1(v109) -> (* SupportSlotOrigin *)
                    match v3 with
                    | UH15_4(v110, v111) -> (* PositionTreeCat *)
                        match v109 with
                        | UH6_3(v112) -> (* OriginSlotCatLeft *)
                            let v115 : UH10 =
                                match v111 with
                                | UH12_2(v113) -> (* PositionTreeChar *)
                                    UH10_2(v113)
                            let v116 : (UH10 -> UH10) = v0 v115
                            let v117 : UH10 = UH10_1
                            let v118 : UH10 = v116 v117
                            match v110 with
                            | UH14_5(v119) -> (* PositionTreeStar *)
                                match v112 with
                                | UH7_5(v120) -> (* OriginSlotStar *)
                                    let v130 : UH10 =
                                        match v119 with
                                        | UH13_3(v121, v122) -> (* PositionTreeAlt *)
                                            let v125 : UH10 =
                                                match v121 with
                                                | UH12_2(v123) -> (* PositionTreeChar *)
                                                    UH10_2(v123)
                                            let v128 : UH10 =
                                                match v122 with
                                                | UH12_2(v126) -> (* PositionTreeChar *)
                                                    UH10_2(v126)
                                            UH10_3(v125, v128)
                                    let v131 : UH10 = UH10_5(v130)
                                    let v132 : (UH10 -> UH10) = v0 v131
                                    let v133 : UH10 = v132 v118
                                    match v119 with
                                    | UH13_3(v134, v135) -> (* PositionTreeAlt *)
                                        match v120 with
                                        | UH8_1(v136) -> (* OriginSlotAltLeft *)
                                            match v134 with
                                            | UH12_2(v137) -> (* PositionTreeChar *)
                                                match v136 with
                                                | UH9_0 -> (* OriginSlotChar *)
                                                    let v138 : UH10 = UH10_1
                                                    let v139 : (UH10 -> UH10) = v0 v138
                                                    v139 v133
                                        | UH8_2(v143) -> (* OriginSlotAltRight *)
                                            match v135 with
                                            | UH12_2(v144) -> (* PositionTreeChar *)
                                                match v143 with
                                                | UH9_0 -> (* OriginSlotChar *)
                                                    let v145 : UH10 = UH10_1
                                                    let v146 : (UH10 -> UH10) = v0 v145
                                                    v146 v133
                        | UH6_4(v155) -> (* OriginSlotCatRight *)
                            match v111 with
                            | UH12_2(v156) -> (* PositionTreeChar *)
                                match v155 with
                                | UH9_0 -> (* OriginSlotChar *)
                                    let v157 : UH10 = UH10_1
                                    let v158 : (UH10 -> UH10) = v0 v157
                                    let v159 : UH10 = UH10_1
                                    v158 v159
                | US3_0 -> (* SupportSlotRoot *)
                    v2
            let v168 : bool = v108 v167
            if v168 then
                method27(v0, v1, v2, v3, v6)
            else
                false
        | US2_0 -> (* SupportSlotMissing *)
            false
    | UH11_0 -> (* RegexListNil *)
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
let v10 : UH0 = method0(v9)
let v11 : UH1 = method7(v10)
let v12 : UH1 = method9(v10, v11)
let v13 : bool = method12(v12)
let v26 : bool =
    if v13 then
        let v14 : (UH0 -> (UH0 -> UH0)) = closure0()
        let v15 : (UH0 -> (UH0 -> bool)) = closure2()
        let v16 : US0 = US0_0
        let v17 : UH2 = UH2_2(v16)
        let v18 : US0 = US0_1
        let v19 : UH2 = UH2_2(v18)
        let v20 : UH3 = UH3_3(v17, v19)
        let v21 : UH4 = UH4_5(v20)
        let v22 : US0 = US0_0
        let v23 : UH2 = UH2_2(v22)
        let v24 : UH5 = UH5_4(v21, v23)
        method13(v14, v15, v9, v24, v12)
    else
        false
let v38 : US8 =
    if v26 then
        let v27 : US0 = US0_0
        let v28 : UH2 = UH2_2(v27)
        let v29 : US0 = US0_1
        let v30 : UH2 = UH2_2(v29)
        let v31 : UH3 = UH3_3(v28, v30)
        let v32 : UH4 = UH4_5(v31)
        let v33 : US0 = US0_0
        let v34 : UH2 = UH2_2(v33)
        let v35 : UH5 = UH5_4(v32, v34)
        US8_1(v35)
    else
        US8_0
let v41 : bool =
    match v38 with
    | US8_1(v39) -> (* AntimirovPositionedSlotBoundCertified *)
        true
    | US8_0 -> (* AntimirovPositionedSlotBoundRejected *)
        false
if v41 then
    ()
else
    let v42 : string = "bit positioned regex must certify root-plus-position slot coverage"
    failwith v42
    ()
let v43 : US9 = US9_0
let v44 : UH10 = UH10_2(v43)
let v45 : US9 = US9_1
let v46 : UH10 = UH10_2(v45)
let v47 : UH10 = UH10_3(v44, v46)
let v48 : UH10 = UH10_5(v47)
let v49 : US9 = US9_2
let v50 : UH10 = UH10_2(v49)
let v51 : UH10 = UH10_4(v48, v50)
let v52 : UH10 = method14(v51)
let v53 : UH10 = method14(v52)
let v54 : UH11 = method21(v53)
let v55 : UH11 = method23(v53, v54)
let v56 : bool = method26(v55)
let v69 : bool =
    if v56 then
        let v57 : (UH10 -> (UH10 -> UH10)) = closure4()
        let v58 : (UH10 -> (UH10 -> bool)) = closure6()
        let v59 : US9 = US9_0
        let v60 : UH12 = UH12_2(v59)
        let v61 : US9 = US9_1
        let v62 : UH12 = UH12_2(v61)
        let v63 : UH13 = UH13_3(v60, v62)
        let v64 : UH14 = UH14_5(v63)
        let v65 : US9 = US9_2
        let v66 : UH12 = UH12_2(v65)
        let v67 : UH15 = UH15_4(v64, v66)
        method27(v57, v58, v52, v67, v55)
    else
        false
let v81 : US10 =
    if v69 then
        let v70 : US9 = US9_0
        let v71 : UH12 = UH12_2(v70)
        let v72 : US9 = US9_1
        let v73 : UH12 = UH12_2(v72)
        let v74 : UH13 = UH13_3(v71, v73)
        let v75 : UH14 = UH14_5(v74)
        let v76 : US9 = US9_2
        let v77 : UH12 = UH12_2(v76)
        let v78 : UH15 = UH15_4(v75, v77)
        US10_1(v78)
    else
        US10_0
let v84 : bool =
    match v81 with
    | US10_1(v82) -> (* AntimirovPositionedSlotBoundCertified *)
        true
    | US10_0 -> (* AntimirovPositionedSlotBoundRejected *)
        false
if v84 then
    ()
else
    let v85 : string = "ternary positioned regex must certify root-plus-position slot coverage"
    failwith v85
    ()
let v86 : string = "brzozowski-antimirov-positioned-bound-green"
v86
