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
and UH1 =
    | UH1_0 of US0
    | UH1_1 of US0
    | UH1_2 of US0 * US0
    | UH1_3 of US0 * UH1 * UH1
    | UH1_4 of US0 * US1 * UH1 * UH1
    | UH1_5 of US0 * UH1
and [<Struct>] US2 =
    | US2_0
    | US2_1
and [<Struct>] US3 =
    | US3_0
    | US3_1
    | US3_2
and UH2 =
    | UH2_0
    | UH2_1
    | UH2_2 of US3
    | UH2_3 of UH2 * UH2
    | UH2_4 of UH2 * UH2
    | UH2_5 of UH2
and UH3 =
    | UH3_0 of US3
    | UH3_1 of US3
    | UH3_2 of US3 * US3
    | UH3_3 of US3 * UH3 * UH3
    | UH3_4 of US3 * US1 * UH3 * UH3
    | UH3_5 of US3 * UH3
and [<Struct>] US4 =
    | US4_0
    | US4_1
    | US4_2
and UH4 =
    | UH4_0
    | UH4_1 of US0 * UH4
and UH6 =
    | UH6_0
    | UH6_1 of US0 * UH6
and UH5 =
    | UH5_0
    | UH5_1 of UH6 * UH5
and UH7 =
    | UH7_0
    | UH7_1 of US3 * UH7
and UH9 =
    | UH9_0
    | UH9_1 of US3 * UH9
and UH8 =
    | UH8_0
    | UH8_1 of UH9 * UH8
let rec method1 (v0 : UH0) : US2 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        US2_1
    | UH0_1 -> (* RegexEpsilon *)
        US2_0
    | UH0_2(v3) -> (* RegexChar *)
        US2_1
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method1(v5)
        let v8 : US2 = method1(v6)
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
        let v18 : US2 = method1(v16)
        let v19 : US2 = method1(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH0_5(v25) -> (* RegexStar *)
        US2_0
and method0 (v0 : UH0, v1 : US0) : UH1 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH1_0(v1)
    | UH0_1 -> (* RegexEpsilon *)
        UH1_1(v1)
    | UH0_2(v4) -> (* RegexChar *)
        UH1_2(v4, v1)
    | UH0_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH1 = method0(v6, v1)
        let v9 : UH1 = method0(v7, v1)
        UH1_3(v1, v8, v9)
    | UH0_4(v11, v12) -> (* RegexCat *)
        let v13 : US2 = method1(v11)
        let v17 : US1 =
            match v13 with
            | US2_0 -> (* Nullable *)
                US1_0
            | US2_1 -> (* NonNullable *)
                US1_1
        let v18 : UH1 = method0(v11, v1)
        let v20 : UH1 = method0(v12, v1)
        UH1_4(v1, v17, v18, v20)
    | UH0_5(v24) -> (* RegexStar *)
        let v25 : UH1 = method0(v24, v1)
        UH1_5(v1, v25)
and method3 (v0 : UH2) : US2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        US2_1
    | UH2_1 -> (* RegexEpsilon *)
        US2_0
    | UH2_2(v3) -> (* RegexChar *)
        US2_1
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method3(v5)
        let v8 : US2 = method3(v6)
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
    | UH2_4(v16, v17) -> (* RegexCat *)
        let v18 : US2 = method3(v16)
        let v19 : US2 = method3(v17)
        match v18 with
        | US2_0 -> (* Nullable *)
            match v19 with
            | US2_0 -> (* Nullable *)
                US2_0
            | _ ->
                US2_1
        | _ ->
            US2_1
    | UH2_5(v25) -> (* RegexStar *)
        US2_0
and method2 (v0 : UH2, v1 : US3) : UH3 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH3_0(v1)
    | UH2_1 -> (* RegexEpsilon *)
        UH3_1(v1)
    | UH2_2(v4) -> (* RegexChar *)
        UH3_2(v4, v1)
    | UH2_3(v6, v7) -> (* RegexAlt *)
        let v8 : UH3 = method2(v6, v1)
        let v9 : UH3 = method2(v7, v1)
        UH3_3(v1, v8, v9)
    | UH2_4(v11, v12) -> (* RegexCat *)
        let v13 : US2 = method3(v11)
        let v17 : US1 =
            match v13 with
            | US2_0 -> (* Nullable *)
                US1_0
            | US2_1 -> (* NonNullable *)
                US1_1
        let v18 : UH3 = method2(v11, v1)
        let v19 : UH3 = method2(v12, v1)
        UH3_4(v1, v17, v18, v19)
    | UH2_5(v21) -> (* RegexStar *)
        let v22 : UH3 = method2(v21, v1)
        UH3_5(v1, v22)
and method5 (v0 : UH1) : UH0 =
    match v0 with
    | UH1_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH0_0
    | UH1_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH0_1
    | UH1_2(v5, v6) -> (* DerivativeEquationProofChar *)
        UH0_2(v5)
    | UH1_3(v8, v9, v10) -> (* DerivativeEquationProofAlt *)
        let v11 : UH0 = method5(v9)
        let v12 : UH0 = method5(v10)
        UH0_3(v11, v12)
    | UH1_4(v14, v15, v16, v17) -> (* DerivativeEquationProofCat *)
        let v18 : UH0 = method5(v16)
        let v19 : UH0 = method5(v17)
        UH0_4(v18, v19)
    | UH1_5(v21, v22) -> (* DerivativeEquationProofStar *)
        let v23 : UH0 = method5(v22)
        UH0_5(v23)
and method6 (v0 : UH1) : US0 =
    match v0 with
    | UH1_0(v1) -> (* DerivativeEquationProofEmpty *)
        v1
    | UH1_1(v2) -> (* DerivativeEquationProofEpsilon *)
        v2
    | UH1_2(v3, v4) -> (* DerivativeEquationProofChar *)
        v4
    | UH1_3(v5, v6, v7) -> (* DerivativeEquationProofAlt *)
        v5
    | UH1_4(v8, v9, v10, v11) -> (* DerivativeEquationProofCat *)
        v8
    | UH1_5(v12, v13) -> (* DerivativeEquationProofStar *)
        v12
and method7 (v0 : UH1) : UH0 =
    match v0 with
    | UH1_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH0_0
    | UH1_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH0_0
    | UH1_2(v5, v6) -> (* DerivativeEquationProofChar *)
        let v16 : US4 =
            match v5 with
            | US0_0 -> (* BitZero *)
                match v6 with
                | US0_0 -> (* BitZero *)
                    US4_1
                | US0_1 -> (* BitOne *)
                    US4_0
            | US0_1 -> (* BitOne *)
                match v6 with
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
            UH0_1
        else
            UH0_0
    | UH1_3(v34, v35, v37) -> (* DerivativeEquationProofAlt *)
        let v40 : UH0 = method7(v35)
        let v41 : UH0 = method7(v37)
        UH0_3(v40, v41)
    | UH1_4(v43, v44, v45, v46) -> (* DerivativeEquationProofCat *)
        let v47 : UH0 = method7(v45)
        let v48 : UH0 = method7(v46)
        let v49 : UH0 = method5(v46)
        match v44 with
        | US1_0 -> (* EquationCatNullable *)
            let v50 : UH0 = UH0_4(v47, v49)
            UH0_3(v50, v48)
        | US1_1 -> (* EquationCatNonNullable *)
            UH0_4(v47, v49)
    | UH1_5(v55, v56) -> (* DerivativeEquationProofStar *)
        let v57 : UH0 = method7(v56)
        let v58 : UH0 = method5(v56)
        let v59 : UH0 = UH0_5(v58)
        UH0_4(v57, v59)
and method12 (v0 : UH0, v1 : UH0) : US4 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US4_1
        | _ ->
            US4_0
    | UH0_1 -> (* RegexEpsilon *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US4_2
        | UH0_1 -> (* RegexEpsilon *)
            US4_1
        | _ ->
            US4_0
    | UH0_2(v10) -> (* RegexChar *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US4_2
        | UH0_1 -> (* RegexEpsilon *)
            US4_2
        | UH0_2(v13) -> (* RegexChar *)
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
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US4 = method12(v53, v55)
            match v57 with
            | US4_1 -> (* SymbolSame *)
                method12(v54, v56)
            | _ ->
                v57
        | _ ->
            US4_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_0 -> (* RegexEmpty *)
            US4_2
        | UH0_1 -> (* RegexEpsilon *)
            US4_2
        | UH0_2(v32) -> (* RegexChar *)
            US4_2
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US4 = method12(v28, v34)
            match v36 with
            | US4_1 -> (* SymbolSame *)
                method12(v29, v35)
            | _ ->
                v36
        | _ ->
            US4_0
    | UH0_5(v44) -> (* RegexStar *)
        match v1 with
        | UH0_3(v45, v46) -> (* RegexAlt *)
            US4_0
        | UH0_5(v48) -> (* RegexStar *)
            method12(v44, v48)
        | _ ->
            US4_2
and method11 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_0 -> (* RegexEmpty *)
        v0
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = method12(v0, v2)
        match v4 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            let v6 : UH0 = method11(v0, v3)
            UH0_3(v2, v6)
    | _ ->
        let v11 : US4 = method12(v0, v1)
        match v11 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
and method10 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        v1
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method11(v2, v1)
        method10(v3, v4)
    | _ ->
        method11(v0, v1)
and method14 (v0 : UH0, v1 : UH0) : bool =
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
    | UH0_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method14(v18, v20)
            if v22 then
                method14(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method14(v26, v28)
            if v30 then
                method14(v27, v29)
            else
                false
        | _ ->
            false
    | UH0_5(v34) -> (* RegexStar *)
        match v1 with
        | UH0_5(v35) -> (* RegexStar *)
            method14(v34, v35)
        | _ ->
            false
and method13 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = method13(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = method14(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and method15 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and method9 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method9(v5)
        let v8 : UH0 = method9(v6)
        method10(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method9(v10)
        let v13 : UH0 = method9(v11)
        method13(v12, v13)
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method9(v15)
        method15(v16)
and method16 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_2(v4) -> (* RegexChar *)
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
            UH0_1
        else
            UH0_0
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method16(v19, v1)
        let v22 : UH0 = method16(v20, v1)
        method10(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = method1(v24)
        match v26 with
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = method16(v24, v1)
            let v28 : UH0 = method13(v27, v25)
            let v29 : UH0 = method16(v25, v1)
            method10(v28, v29)
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = method16(v24, v1)
            method13(v31, v25)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH0 = method16(v35, v1)
        let v37 : UH0 = method15(v35)
        method13(v36, v37)
and method8 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method9(v0)
    let v3 : UH0 = method16(v2, v1)
    method9(v3)
and method17 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_0
    | UH0_2(v4) -> (* RegexChar *)
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
            UH0_1
        else
            UH0_0
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method17(v19, v1)
        let v22 : UH0 = method17(v20, v1)
        UH0_3(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = method1(v24)
        match v26 with
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = method17(v24, v1)
            let v28 : UH0 = method17(v25, v1)
            let v29 : UH0 = UH0_4(v27, v25)
            UH0_3(v29, v28)
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = method17(v24, v1)
            UH0_4(v31, v25)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH0 = method17(v35, v1)
        let v37 : UH0 = UH0_5(v35)
        UH0_4(v36, v37)
and method4 (v0 : UH1) : bool =
    let v1 : UH0 = method5(v0)
    let v2 : US0 = method6(v0)
    let v3 : UH0 = method7(v0)
    let v4 : UH0 = method8(v1, v2)
    let v5 : UH0 = method17(v1, v2)
    let v6 : UH0 = method9(v5)
    let v7 : UH0 = method9(v3)
    let v8 : bool = method14(v7, v4)
    let v11 : bool =
        if v8 then
            let v9 : UH0 = method9(v3)
            method14(v9, v6)
        else
            false
    let v18 : bool =
        if v11 then
            let v12 : UH0 = method9(v1)
            let v13 : UH0 = method16(v12, v2)
            let v14 : UH0 = method9(v13)
            let v15 : UH0 = method16(v1, v2)
            let v16 : UH0 = method9(v15)
            method14(v14, v16)
        else
            false
    if v18 then
        match v0 with
        | UH1_0(v19) -> (* DerivativeEquationProofEmpty *)
            true
        | UH1_1(v20) -> (* DerivativeEquationProofEpsilon *)
            true
        | UH1_2(v21, v22) -> (* DerivativeEquationProofChar *)
            true
        | UH1_3(v23, v24, v25) -> (* DerivativeEquationProofAlt *)
            let v26 : US0 = method6(v0)
            let v27 : US0 = method6(v24)
            let v37 : US4 =
                match v26 with
                | US0_0 -> (* BitZero *)
                    match v27 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v27 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            let v38 : bool =
                match v37 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v52 : bool =
                if v38 then
                    let v39 : US0 = method6(v0)
                    let v40 : US0 = method6(v25)
                    let v50 : US4 =
                        match v39 with
                        | US0_0 -> (* BitZero *)
                            match v40 with
                            | US0_0 -> (* BitZero *)
                                US4_1
                            | US0_1 -> (* BitOne *)
                                US4_0
                        | US0_1 -> (* BitOne *)
                            match v40 with
                            | US0_0 -> (* BitZero *)
                                US4_2
                            | US0_1 -> (* BitOne *)
                                US4_1
                    match v50 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v54 : bool =
                if v52 then
                    method4(v24)
                else
                    false
            if v54 then
                method4(v25)
            else
                false
        | UH1_4(v57, v58, v59, v60) -> (* DerivativeEquationProofCat *)
            let v61 : UH0 = method5(v59)
            let v62 : US2 = method1(v61)
            let v66 : US1 =
                match v62 with
                | US2_0 -> (* Nullable *)
                    US1_0
                | US2_1 -> (* NonNullable *)
                    US1_1
            let v70 : bool =
                match v58 with
                | US1_0 -> (* EquationCatNullable *)
                    match v66 with
                    | US1_0 -> (* EquationCatNullable *)
                        true
                    | _ ->
                        false
                | US1_1 -> (* EquationCatNonNullable *)
                    match v66 with
                    | US1_1 -> (* EquationCatNonNullable *)
                        true
                    | _ ->
                        false
            let v84 : bool =
                if v70 then
                    let v71 : US0 = method6(v0)
                    let v72 : US0 = method6(v59)
                    let v82 : US4 =
                        match v71 with
                        | US0_0 -> (* BitZero *)
                            match v72 with
                            | US0_0 -> (* BitZero *)
                                US4_1
                            | US0_1 -> (* BitOne *)
                                US4_0
                        | US0_1 -> (* BitOne *)
                            match v72 with
                            | US0_0 -> (* BitZero *)
                                US4_2
                            | US0_1 -> (* BitOne *)
                                US4_1
                    match v82 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v98 : bool =
                if v84 then
                    let v85 : US0 = method6(v0)
                    let v86 : US0 = method6(v60)
                    let v96 : US4 =
                        match v85 with
                        | US0_0 -> (* BitZero *)
                            match v86 with
                            | US0_0 -> (* BitZero *)
                                US4_1
                            | US0_1 -> (* BitOne *)
                                US4_0
                        | US0_1 -> (* BitOne *)
                            match v86 with
                            | US0_0 -> (* BitZero *)
                                US4_2
                            | US0_1 -> (* BitOne *)
                                US4_1
                    match v96 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v100 : bool =
                if v98 then
                    method4(v59)
                else
                    false
            if v100 then
                method4(v60)
            else
                false
        | UH1_5(v103, v104) -> (* DerivativeEquationProofStar *)
            let v105 : US0 = method6(v0)
            let v106 : US0 = method6(v104)
            let v116 : US4 =
                match v105 with
                | US0_0 -> (* BitZero *)
                    match v106 with
                    | US0_0 -> (* BitZero *)
                        US4_1
                    | US0_1 -> (* BitOne *)
                        US4_0
                | US0_1 -> (* BitOne *)
                    match v106 with
                    | US0_0 -> (* BitZero *)
                        US4_2
                    | US0_1 -> (* BitOne *)
                        US4_1
            let v117 : bool =
                match v116 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v117 then
                method4(v104)
            else
                false
    else
        false
and method19 (v0 : UH3) : UH2 =
    match v0 with
    | UH3_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH2_0
    | UH3_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH2_1
    | UH3_2(v5, v6) -> (* DerivativeEquationProofChar *)
        UH2_2(v5)
    | UH3_3(v8, v9, v10) -> (* DerivativeEquationProofAlt *)
        let v11 : UH2 = method19(v9)
        let v12 : UH2 = method19(v10)
        UH2_3(v11, v12)
    | UH3_4(v14, v15, v16, v17) -> (* DerivativeEquationProofCat *)
        let v18 : UH2 = method19(v16)
        let v19 : UH2 = method19(v17)
        UH2_4(v18, v19)
    | UH3_5(v21, v22) -> (* DerivativeEquationProofStar *)
        let v23 : UH2 = method19(v22)
        UH2_5(v23)
and method20 (v0 : UH3) : US3 =
    match v0 with
    | UH3_0(v1) -> (* DerivativeEquationProofEmpty *)
        v1
    | UH3_1(v2) -> (* DerivativeEquationProofEpsilon *)
        v2
    | UH3_2(v3, v4) -> (* DerivativeEquationProofChar *)
        v4
    | UH3_3(v5, v6, v7) -> (* DerivativeEquationProofAlt *)
        v5
    | UH3_4(v8, v9, v10, v11) -> (* DerivativeEquationProofCat *)
        v8
    | UH3_5(v12, v13) -> (* DerivativeEquationProofStar *)
        v12
and method21 (v0 : UH3) : UH2 =
    match v0 with
    | UH3_0(v1) -> (* DerivativeEquationProofEmpty *)
        UH2_0
    | UH3_1(v3) -> (* DerivativeEquationProofEpsilon *)
        UH2_0
    | UH3_2(v5, v6) -> (* DerivativeEquationProofChar *)
        let v22 : US4 =
            match v5 with
            | US3_0 -> (* TriA *)
                match v6 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v6 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v5 with
                    | US3_1 -> (* TriB *)
                        match v6 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v6 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        let v23 : bool =
            match v22 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v23 then
            UH2_1
        else
            UH2_0
    | UH3_3(v27, v28, v29) -> (* DerivativeEquationProofAlt *)
        let v30 : UH2 = method21(v28)
        let v31 : UH2 = method21(v29)
        UH2_3(v30, v31)
    | UH3_4(v33, v34, v35, v36) -> (* DerivativeEquationProofCat *)
        let v37 : UH2 = method21(v35)
        let v38 : UH2 = method21(v36)
        let v39 : UH2 = method19(v36)
        match v34 with
        | US1_0 -> (* EquationCatNullable *)
            let v40 : UH2 = UH2_4(v37, v39)
            UH2_3(v40, v38)
        | US1_1 -> (* EquationCatNonNullable *)
            UH2_4(v37, v39)
    | UH3_5(v45, v46) -> (* DerivativeEquationProofStar *)
        let v47 : UH2 = method21(v46)
        let v48 : UH2 = method19(v46)
        let v49 : UH2 = UH2_5(v48)
        UH2_4(v47, v49)
and method26 (v0 : UH2, v1 : UH2) : US4 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US4_1
        | _ ->
            US4_0
    | UH2_1 -> (* RegexEpsilon *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US4_2
        | UH2_1 -> (* RegexEpsilon *)
            US4_1
        | _ ->
            US4_0
    | UH2_2(v10) -> (* RegexChar *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US4_2
        | UH2_1 -> (* RegexEpsilon *)
            US4_2
        | UH2_2(v13) -> (* RegexChar *)
            match v10 with
            | US3_0 -> (* TriA *)
                match v13 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v13 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v10 with
                    | US3_1 -> (* TriB *)
                        match v13 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v13 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        | _ ->
            US4_0
    | UH2_3(v59, v60) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v61, v62) -> (* RegexAlt *)
            let v63 : US4 = method26(v59, v61)
            match v63 with
            | US4_1 -> (* SymbolSame *)
                method26(v60, v62)
            | _ ->
                v63
        | _ ->
            US4_2
    | UH2_4(v34, v35) -> (* RegexCat *)
        match v1 with
        | UH2_0 -> (* RegexEmpty *)
            US4_2
        | UH2_1 -> (* RegexEpsilon *)
            US4_2
        | UH2_2(v38) -> (* RegexChar *)
            US4_2
        | UH2_4(v40, v41) -> (* RegexCat *)
            let v42 : US4 = method26(v34, v40)
            match v42 with
            | US4_1 -> (* SymbolSame *)
                method26(v35, v41)
            | _ ->
                v42
        | _ ->
            US4_0
    | UH2_5(v50) -> (* RegexStar *)
        match v1 with
        | UH2_3(v51, v52) -> (* RegexAlt *)
            US4_0
        | UH2_5(v54) -> (* RegexStar *)
            method26(v50, v54)
        | _ ->
            US4_2
and method25 (v0 : UH2, v1 : UH2) : UH2 =
    match v1 with
    | UH2_0 -> (* RegexEmpty *)
        v0
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : US4 = method26(v0, v2)
        match v4 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            let v6 : UH2 = method25(v0, v3)
            UH2_3(v2, v6)
    | _ ->
        let v11 : US4 = method26(v0, v1)
        match v11 with
        | US4_1 -> (* SymbolSame *)
            v1
        | US4_0 -> (* SymbolLess *)
            UH2_3(v0, v1)
        | US4_2 -> (* SymbolGreater *)
            UH2_3(v1, v0)
and method24 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        v1
    | UH2_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH2 = method25(v2, v1)
        method24(v3, v4)
    | _ ->
        method25(v0, v1)
and method28 (v0 : UH2, v1 : UH2) : bool =
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
            let v21 : US4 =
                match v4 with
                | US3_0 -> (* TriA *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v4 with
                        | US3_1 -> (* TriB *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            match v21 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        | _ ->
            false
    | UH2_3(v24, v25) -> (* RegexAlt *)
        match v1 with
        | UH2_3(v26, v27) -> (* RegexAlt *)
            let v28 : bool = method28(v24, v26)
            if v28 then
                method28(v25, v27)
            else
                false
        | _ ->
            false
    | UH2_4(v32, v33) -> (* RegexCat *)
        match v1 with
        | UH2_4(v34, v35) -> (* RegexCat *)
            let v36 : bool = method28(v32, v34)
            if v36 then
                method28(v33, v35)
            else
                false
        | _ ->
            false
    | UH2_5(v40) -> (* RegexStar *)
        match v1 with
        | UH2_5(v41) -> (* RegexStar *)
            method28(v40, v41)
        | _ ->
            false
and method27 (v0 : UH2, v1 : UH2) : UH2 =
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
                        let v14 : UH2 = method27(v13, v1)
                        UH2_4(v12, v14)
                    | UH2_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH2_5(v5) -> (* RegexStar *)
                            let v6 : bool = method28(v4, v5)
                            if v6 then
                                UH2_5(v4)
                            else
                                UH2_4(v0, v1)
                        | _ ->
                            UH2_4(v0, v1)
                    | _ ->
                        UH2_4(v0, v1)
and method29 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_1
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_5(v3) -> (* RegexStar *)
        UH2_5(v3)
    | _ ->
        UH2_5(v0)
and method23 (v0 : UH2) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_1
    | UH2_2(v3) -> (* RegexChar *)
        UH2_2(v3)
    | UH2_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH2 = method23(v5)
        let v8 : UH2 = method23(v6)
        method24(v7, v8)
    | UH2_4(v10, v11) -> (* RegexCat *)
        let v12 : UH2 = method23(v10)
        let v13 : UH2 = method23(v11)
        method27(v12, v13)
    | UH2_5(v15) -> (* RegexStar *)
        let v16 : UH2 = method23(v15)
        method29(v16)
and method30 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_2(v4) -> (* RegexChar *)
        let v20 : US4 =
            match v4 with
            | US3_0 -> (* TriA *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v4 with
                    | US3_1 -> (* TriB *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        let v21 : bool =
            match v20 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH2_1
        else
            UH2_0
    | UH2_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = method30(v25, v1)
        let v28 : UH2 = method30(v26, v1)
        method24(v27, v28)
    | UH2_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = method3(v30)
        match v32 with
        | US2_0 -> (* Nullable *)
            let v33 : UH2 = method30(v30, v1)
            let v34 : UH2 = method27(v33, v31)
            let v35 : UH2 = method30(v31, v1)
            method24(v34, v35)
        | US2_1 -> (* NonNullable *)
            let v37 : UH2 = method30(v30, v1)
            method27(v37, v31)
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH2 = method30(v41, v1)
        let v43 : UH2 = method29(v41)
        method27(v42, v43)
and method22 (v0 : UH2, v1 : US3) : UH2 =
    let v2 : UH2 = method23(v0)
    let v3 : UH2 = method30(v2, v1)
    method23(v3)
and method31 (v0 : UH2, v1 : US3) : UH2 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH2_0
    | UH2_1 -> (* RegexEpsilon *)
        UH2_0
    | UH2_2(v4) -> (* RegexChar *)
        let v20 : US4 =
            match v4 with
            | US3_0 -> (* TriA *)
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_1
                | _ ->
                    US4_0
            | _ ->
                match v1 with
                | US3_0 -> (* TriA *)
                    US4_2
                | _ ->
                    match v4 with
                    | US3_1 -> (* TriB *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_1
                        | US3_2 -> (* TriC *)
                            US4_0
                    | US3_2 -> (* TriC *)
                        match v1 with
                        | US3_1 -> (* TriB *)
                            US4_2
                        | US3_2 -> (* TriC *)
                            US4_1
        let v21 : bool =
            match v20 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v21 then
            UH2_1
        else
            UH2_0
    | UH2_3(v25, v26) -> (* RegexAlt *)
        let v27 : UH2 = method31(v25, v1)
        let v28 : UH2 = method31(v26, v1)
        UH2_3(v27, v28)
    | UH2_4(v30, v31) -> (* RegexCat *)
        let v32 : US2 = method3(v30)
        match v32 with
        | US2_0 -> (* Nullable *)
            let v33 : UH2 = method31(v30, v1)
            let v34 : UH2 = method31(v31, v1)
            let v35 : UH2 = UH2_4(v33, v31)
            UH2_3(v35, v34)
        | US2_1 -> (* NonNullable *)
            let v37 : UH2 = method31(v30, v1)
            UH2_4(v37, v31)
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH2 = method31(v41, v1)
        let v43 : UH2 = UH2_5(v41)
        UH2_4(v42, v43)
and method18 (v0 : UH3) : bool =
    let v1 : UH2 = method19(v0)
    let v2 : US3 = method20(v0)
    let v3 : UH2 = method21(v0)
    let v4 : UH2 = method22(v1, v2)
    let v5 : UH2 = method31(v1, v2)
    let v6 : UH2 = method23(v5)
    let v7 : UH2 = method23(v3)
    let v8 : bool = method28(v7, v4)
    let v11 : bool =
        if v8 then
            let v9 : UH2 = method23(v3)
            method28(v9, v6)
        else
            false
    let v18 : bool =
        if v11 then
            let v12 : UH2 = method23(v1)
            let v13 : UH2 = method30(v12, v2)
            let v14 : UH2 = method23(v13)
            let v15 : UH2 = method30(v1, v2)
            let v16 : UH2 = method23(v15)
            method28(v14, v16)
        else
            false
    if v18 then
        match v0 with
        | UH3_0(v19) -> (* DerivativeEquationProofEmpty *)
            true
        | UH3_1(v20) -> (* DerivativeEquationProofEpsilon *)
            true
        | UH3_2(v21, v22) -> (* DerivativeEquationProofChar *)
            true
        | UH3_3(v23, v24, v25) -> (* DerivativeEquationProofAlt *)
            let v26 : US3 = method20(v0)
            let v27 : US3 = method20(v24)
            let v43 : US4 =
                match v26 with
                | US3_0 -> (* TriA *)
                    match v27 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v27 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v26 with
                        | US3_1 -> (* TriB *)
                            match v27 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v27 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v44 : bool =
                match v43 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            let v64 : bool =
                if v44 then
                    let v45 : US3 = method20(v0)
                    let v46 : US3 = method20(v25)
                    let v62 : US4 =
                        match v45 with
                        | US3_0 -> (* TriA *)
                            match v46 with
                            | US3_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v46 with
                            | US3_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v45 with
                                | US3_1 -> (* TriB *)
                                    match v46 with
                                    | US3_1 -> (* TriB *)
                                        US4_1
                                    | US3_2 -> (* TriC *)
                                        US4_0
                                | US3_2 -> (* TriC *)
                                    match v46 with
                                    | US3_1 -> (* TriB *)
                                        US4_2
                                    | US3_2 -> (* TriC *)
                                        US4_1
                    match v62 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v66 : bool =
                if v64 then
                    method18(v24)
                else
                    false
            if v66 then
                method18(v25)
            else
                false
        | UH3_4(v69, v70, v71, v72) -> (* DerivativeEquationProofCat *)
            let v73 : UH2 = method19(v71)
            let v74 : US2 = method3(v73)
            let v78 : US1 =
                match v74 with
                | US2_0 -> (* Nullable *)
                    US1_0
                | US2_1 -> (* NonNullable *)
                    US1_1
            let v82 : bool =
                match v70 with
                | US1_0 -> (* EquationCatNullable *)
                    match v78 with
                    | US1_0 -> (* EquationCatNullable *)
                        true
                    | _ ->
                        false
                | US1_1 -> (* EquationCatNonNullable *)
                    match v78 with
                    | US1_1 -> (* EquationCatNonNullable *)
                        true
                    | _ ->
                        false
            let v102 : bool =
                if v82 then
                    let v83 : US3 = method20(v0)
                    let v84 : US3 = method20(v71)
                    let v100 : US4 =
                        match v83 with
                        | US3_0 -> (* TriA *)
                            match v84 with
                            | US3_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v84 with
                            | US3_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v83 with
                                | US3_1 -> (* TriB *)
                                    match v84 with
                                    | US3_1 -> (* TriB *)
                                        US4_1
                                    | US3_2 -> (* TriC *)
                                        US4_0
                                | US3_2 -> (* TriC *)
                                    match v84 with
                                    | US3_1 -> (* TriB *)
                                        US4_2
                                    | US3_2 -> (* TriC *)
                                        US4_1
                    match v100 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v122 : bool =
                if v102 then
                    let v103 : US3 = method20(v0)
                    let v104 : US3 = method20(v72)
                    let v120 : US4 =
                        match v103 with
                        | US3_0 -> (* TriA *)
                            match v104 with
                            | US3_0 -> (* TriA *)
                                US4_1
                            | _ ->
                                US4_0
                        | _ ->
                            match v104 with
                            | US3_0 -> (* TriA *)
                                US4_2
                            | _ ->
                                match v103 with
                                | US3_1 -> (* TriB *)
                                    match v104 with
                                    | US3_1 -> (* TriB *)
                                        US4_1
                                    | US3_2 -> (* TriC *)
                                        US4_0
                                | US3_2 -> (* TriC *)
                                    match v104 with
                                    | US3_1 -> (* TriB *)
                                        US4_2
                                    | US3_2 -> (* TriC *)
                                        US4_1
                    match v120 with
                    | US4_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                else
                    false
            let v124 : bool =
                if v122 then
                    method18(v71)
                else
                    false
            if v124 then
                method18(v72)
            else
                false
        | UH3_5(v127, v128) -> (* DerivativeEquationProofStar *)
            let v129 : US3 = method20(v0)
            let v130 : US3 = method20(v128)
            let v146 : US4 =
                match v129 with
                | US3_0 -> (* TriA *)
                    match v130 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v130 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v129 with
                        | US3_1 -> (* TriB *)
                            match v130 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v130 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v147 : bool =
                match v146 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v147 then
                method18(v128)
            else
                false
    else
        false
and method32 (v0 : UH4) : UH5 =
    match v0 with
    | UH4_0 -> (* SymbolListNil *)
        UH5_0
    | UH4_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH5 = method32(v3)
        let v5 : UH6 = UH6_0
        let v6 : UH6 = UH6_1(v2, v5)
        UH5_1(v6, v4)
and method34 (v0 : US0, v1 : UH5) : UH5 =
    match v1 with
    | UH5_0 -> (* InputListNil *)
        UH5_0
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = method34(v0, v4)
        let v6 : UH6 = UH6_1(v0, v3)
        UH5_1(v6, v5)
and method35 (v0 : UH5, v1 : UH5) : UH5 =
    match v0 with
    | UH5_0 -> (* InputListNil *)
        v1
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : UH5 = method35(v3, v1)
        UH5_1(v2, v4)
and method33 (v0 : UH4, v1 : UH5) : UH5 =
    match v0 with
    | UH4_0 -> (* SymbolListNil *)
        UH5_0
    | UH4_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH5 = method34(v3, v1)
        let v6 : UH5 = method33(v4, v1)
        method35(v5, v6)
and method36 (v0 : UH7) : UH8 =
    match v0 with
    | UH7_0 -> (* SymbolListNil *)
        UH8_0
    | UH7_1(v2, v3) -> (* SymbolListCons *)
        let v4 : UH8 = method36(v3)
        let v5 : UH9 = UH9_0
        let v6 : UH9 = UH9_1(v2, v5)
        UH8_1(v6, v4)
and method38 (v0 : US3, v1 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        UH8_0
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = method38(v0, v4)
        let v6 : UH9 = UH9_1(v0, v3)
        UH8_1(v6, v5)
and method39 (v0 : UH8, v1 : UH8) : UH8 =
    match v0 with
    | UH8_0 -> (* InputListNil *)
        v1
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : UH8 = method39(v3, v1)
        UH8_1(v2, v4)
and method37 (v0 : UH7, v1 : UH8) : UH8 =
    match v0 with
    | UH7_0 -> (* SymbolListNil *)
        UH8_0
    | UH7_1(v3, v4) -> (* SymbolListCons *)
        let v5 : UH8 = method38(v3, v1)
        let v6 : UH8 = method37(v4, v1)
        method39(v5, v6)
and method41 (v0 : UH0, v1 : UH5) : UH5 =
    match v1 with
    | UH5_0 -> (* InputListNil *)
        UH5_0
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = method40(v0, v3)
        let v6 : UH5 = method41(v0, v4)
        method35(v5, v6)
and method45 (v0 : UH6, v1 : UH6) : bool =
    match v0 with
    | UH6_0 -> (* InputEmpty *)
        match v1 with
        | UH6_0 -> (* InputEmpty *)
            true
        | _ ->
            false
    | UH6_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH6_1(v5, v6) -> (* InputCons *)
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
                method45(v4, v6)
            else
                false
        | _ ->
            false
and method44 (v0 : UH6, v1 : UH5) : bool =
    match v1 with
    | UH5_0 -> (* InputListNil *)
        false
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method45(v0, v2)
        if v4 then
            true
        else
            method44(v0, v3)
and method43 (v0 : UH5, v1 : UH5, v2 : UH5) : struct (UH5 * UH5) =
    match v0 with
    | UH5_0 -> (* InputListNil *)
        struct (v1, v2)
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method44(v3, v1)
        if v5 then
            method43(v4, v1, v2)
        else
            let v8 : UH5 = UH5_1(v3, v1)
            let v9 : UH5 = UH5_1(v3, v2)
            method43(v4, v8, v9)
and method42 (v0 : UH0, v1 : UH5, v2 : UH5) : UH5 =
    match v1 with
    | UH5_0 -> (* InputListNil *)
        v2
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : UH5 = method40(v0, v3)
        let struct (v6 : UH5, v7 : UH5) = method43(v5, v2, v4)
        method42(v0, v7, v6)
and method40 (v0 : UH0, v1 : UH6) : UH5 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH5_0
    | UH0_1 -> (* RegexEpsilon *)
        let v3 : UH5 = UH5_0
        UH5_1(v1, v3)
    | UH0_2(v5) -> (* RegexChar *)
        match v1 with
        | UH6_0 -> (* InputEmpty *)
            UH5_0
        | UH6_1(v7, v8) -> (* InputCons *)
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
                let v20 : UH5 = UH5_0
                UH5_1(v8, v20)
            else
                UH5_0
    | UH0_3(v26, v27) -> (* RegexAlt *)
        let v28 : UH5 = method40(v26, v1)
        let v29 : UH5 = method40(v27, v1)
        method35(v28, v29)
    | UH0_4(v31, v32) -> (* RegexCat *)
        let v33 : UH5 = method40(v31, v1)
        method41(v32, v33)
    | UH0_5(v35) -> (* RegexStar *)
        let v36 : UH5 = UH5_0
        let v37 : UH5 = UH5_1(v1, v36)
        let v38 : UH5 = UH5_0
        let v39 : UH5 = UH5_1(v1, v38)
        method42(v35, v37, v39)
and method46 (v0 : UH6, v1 : UH5) : UH5 =
    match v1 with
    | UH5_0 -> (* InputListNil *)
        UH5_0
    | UH5_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method45(v0, v3)
        if v5 then
            method46(v0, v4)
        else
            let v7 : UH5 = method46(v0, v4)
            UH5_1(v3, v7)
and method47 (v0 : UH5, v1 : UH5) : bool =
    match v0 with
    | UH5_0 -> (* InputListNil *)
        true
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method44(v2, v1)
        if v4 then
            method47(v3, v1)
        else
            false
and closure0 (v0 : bool, v1 : UH0) (v2 : UH6) : bool =
    let v22 : bool =
        if v0 then
            let v3 : US0 = US0_0
            let v4 : UH6 = UH6_1(v3, v2)
            let v5 : US0 = US0_0
            let v6 : UH0 = UH0_2(v5)
            let v7 : US0 = US0_1
            let v8 : UH0 = UH0_2(v7)
            let v9 : US0 = US0_0
            let v10 : UH0 = UH0_2(v9)
            let v11 : UH0 = UH0_3(v10, v8)
            let v12 : UH0 = UH0_5(v11)
            let v13 : UH0 = UH0_4(v12, v6)
            let v14 : US0 = US0_0
            let v15 : UH6 = UH6_1(v14, v2)
            let v16 : UH5 = method40(v13, v15)
            let v17 : UH5 = method46(v4, v16)
            let v18 : UH5 = method40(v1, v2)
            let v19 : bool = method47(v17, v18)
            if v19 then
                method47(v18, v17)
            else
                false
        else
            false
    v22
and method48 (v0 : (UH6 -> bool), v1 : UH5) : bool =
    match v1 with
    | UH5_0 -> (* InputListNil *)
        true
    | UH5_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = v0 v2
        if v4 then
            method48(v0, v3)
        else
            false
and method50 (v0 : UH2, v1 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        UH8_0
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = method49(v0, v3)
        let v6 : UH8 = method50(v0, v4)
        method39(v5, v6)
and method54 (v0 : UH9, v1 : UH9) : bool =
    match v0 with
    | UH9_0 -> (* InputEmpty *)
        match v1 with
        | UH9_0 -> (* InputEmpty *)
            true
        | _ ->
            false
    | UH9_1(v3, v4) -> (* InputCons *)
        match v1 with
        | UH9_1(v5, v6) -> (* InputCons *)
            let v22 : US4 =
                match v3 with
                | US3_0 -> (* TriA *)
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v5 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v3 with
                        | US3_1 -> (* TriB *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v5 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v23 : bool =
                match v22 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v23 then
                method54(v4, v6)
            else
                false
        | _ ->
            false
and method53 (v0 : UH9, v1 : UH8) : bool =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        false
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method54(v0, v2)
        if v4 then
            true
        else
            method53(v0, v3)
and method52 (v0 : UH8, v1 : UH8, v2 : UH8) : struct (UH8 * UH8) =
    match v0 with
    | UH8_0 -> (* InputListNil *)
        struct (v1, v2)
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method53(v3, v1)
        if v5 then
            method52(v4, v1, v2)
        else
            let v8 : UH8 = UH8_1(v3, v1)
            let v9 : UH8 = UH8_1(v3, v2)
            method52(v4, v8, v9)
and method51 (v0 : UH2, v1 : UH8, v2 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        v2
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : UH8 = method49(v0, v3)
        let struct (v6 : UH8, v7 : UH8) = method52(v5, v2, v4)
        method51(v0, v7, v6)
and method49 (v0 : UH2, v1 : UH9) : UH8 =
    match v0 with
    | UH2_0 -> (* RegexEmpty *)
        UH8_0
    | UH2_1 -> (* RegexEpsilon *)
        let v3 : UH8 = UH8_0
        UH8_1(v1, v3)
    | UH2_2(v5) -> (* RegexChar *)
        match v1 with
        | UH9_0 -> (* InputEmpty *)
            UH8_0
        | UH9_1(v7, v8) -> (* InputCons *)
            let v24 : US4 =
                match v5 with
                | US3_0 -> (* TriA *)
                    match v7 with
                    | US3_0 -> (* TriA *)
                        US4_1
                    | _ ->
                        US4_0
                | _ ->
                    match v7 with
                    | US3_0 -> (* TriA *)
                        US4_2
                    | _ ->
                        match v5 with
                        | US3_1 -> (* TriB *)
                            match v7 with
                            | US3_1 -> (* TriB *)
                                US4_1
                            | US3_2 -> (* TriC *)
                                US4_0
                        | US3_2 -> (* TriC *)
                            match v7 with
                            | US3_1 -> (* TriB *)
                                US4_2
                            | US3_2 -> (* TriC *)
                                US4_1
            let v25 : bool =
                match v24 with
                | US4_1 -> (* SymbolSame *)
                    true
                | _ ->
                    false
            if v25 then
                let v26 : UH8 = UH8_0
                UH8_1(v8, v26)
            else
                UH8_0
    | UH2_3(v32, v33) -> (* RegexAlt *)
        let v34 : UH8 = method49(v32, v1)
        let v35 : UH8 = method49(v33, v1)
        method39(v34, v35)
    | UH2_4(v37, v38) -> (* RegexCat *)
        let v39 : UH8 = method49(v37, v1)
        method50(v38, v39)
    | UH2_5(v41) -> (* RegexStar *)
        let v42 : UH8 = UH8_0
        let v43 : UH8 = UH8_1(v1, v42)
        let v44 : UH8 = UH8_0
        let v45 : UH8 = UH8_1(v1, v44)
        method51(v41, v43, v45)
and method55 (v0 : UH9, v1 : UH8) : UH8 =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        UH8_0
    | UH8_1(v3, v4) -> (* InputListCons *)
        let v5 : bool = method54(v0, v3)
        if v5 then
            method55(v0, v4)
        else
            let v7 : UH8 = method55(v0, v4)
            UH8_1(v3, v7)
and method56 (v0 : UH8, v1 : UH8) : bool =
    match v0 with
    | UH8_0 -> (* InputListNil *)
        true
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = method53(v2, v1)
        if v4 then
            method56(v3, v1)
        else
            false
and closure1 (v0 : bool, v1 : UH2) (v2 : UH9) : bool =
    let v22 : bool =
        if v0 then
            let v3 : US3 = US3_0
            let v4 : UH9 = UH9_1(v3, v2)
            let v5 : US3 = US3_2
            let v6 : UH2 = UH2_2(v5)
            let v7 : US3 = US3_1
            let v8 : UH2 = UH2_2(v7)
            let v9 : US3 = US3_0
            let v10 : UH2 = UH2_2(v9)
            let v11 : UH2 = UH2_3(v10, v8)
            let v12 : UH2 = UH2_5(v11)
            let v13 : UH2 = UH2_4(v12, v6)
            let v14 : US3 = US3_0
            let v15 : UH9 = UH9_1(v14, v2)
            let v16 : UH8 = method49(v13, v15)
            let v17 : UH8 = method55(v4, v16)
            let v18 : UH8 = method49(v1, v2)
            let v19 : bool = method56(v17, v18)
            if v19 then
                method56(v18, v17)
            else
                false
        else
            false
    v22
and method57 (v0 : (UH9 -> bool), v1 : UH8) : bool =
    match v1 with
    | UH8_0 -> (* InputListNil *)
        true
    | UH8_1(v2, v3) -> (* InputListCons *)
        let v4 : bool = v0 v2
        if v4 then
            method57(v0, v3)
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
let v9 : US0 = US0_0
let v10 : UH1 = method0(v8, v9)
let v11 : US3 = US3_2
let v12 : UH2 = UH2_2(v11)
let v13 : US3 = US3_1
let v14 : UH2 = UH2_2(v13)
let v15 : US3 = US3_0
let v16 : UH2 = UH2_2(v15)
let v17 : UH2 = UH2_3(v16, v14)
let v18 : UH2 = UH2_5(v17)
let v19 : UH2 = UH2_4(v18, v12)
let v20 : US3 = US3_0
let v21 : UH3 = method2(v19, v20)
let v22 : US0 = US0_0
let v23 : UH0 = UH0_2(v22)
let v24 : US0 = US0_1
let v25 : UH0 = UH0_2(v24)
let v26 : US0 = US0_0
let v27 : UH0 = UH0_2(v26)
let v28 : UH0 = UH0_3(v27, v25)
let v29 : UH0 = UH0_5(v28)
let v30 : UH0 = UH0_4(v29, v23)
let v31 : US0 = US0_0
let v32 : UH1 = method0(v30, v31)
let v33 : US3 = US3_2
let v34 : UH2 = UH2_2(v33)
let v35 : US3 = US3_1
let v36 : UH2 = UH2_2(v35)
let v37 : US3 = US3_0
let v38 : UH2 = UH2_2(v37)
let v39 : UH2 = UH2_3(v38, v36)
let v40 : UH2 = UH2_5(v39)
let v41 : UH2 = UH2_4(v40, v34)
let v42 : US3 = US3_0
let v43 : UH3 = method2(v41, v42)
let v44 : bool = method4(v10)
if v44 then
    ()
else
    let v45 : string = "suffix-independent bit derivative equation proof must validate"
    failwith v45
    ()
let v46 : bool = method18(v21)
if v46 then
    ()
else
    let v47 : string = "suffix-independent ternary derivative equation proof must validate"
    failwith v47
    ()
let v48 : US0 = US0_0
let v49 : UH0 = UH0_2(v48)
let v50 : US0 = US0_1
let v51 : UH0 = UH0_2(v50)
let v52 : US0 = US0_0
let v53 : UH0 = UH0_2(v52)
let v54 : UH0 = UH0_3(v53, v51)
let v55 : UH0 = UH0_5(v54)
let v56 : UH0 = UH0_4(v55, v49)
let v57 : UH0 = method5(v32)
let v58 : bool = method14(v56, v57)
let v67 : bool =
    if v58 then
        let v59 : US0 = method6(v32)
        let v63 : US4 =
            match v59 with
            | US0_0 -> (* BitZero *)
                US4_1
            | US0_1 -> (* BitOne *)
                US4_0
        let v64 : bool =
            match v63 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v64 then
            method4(v32)
        else
            false
    else
        false
if v67 then
    ()
else
    let v68 : string = "bit derivative equation certificate must bind source and symbol"
    failwith v68
    ()
let v69 : US3 = US3_2
let v70 : UH2 = UH2_2(v69)
let v71 : US3 = US3_1
let v72 : UH2 = UH2_2(v71)
let v73 : US3 = US3_0
let v74 : UH2 = UH2_2(v73)
let v75 : UH2 = UH2_3(v74, v72)
let v76 : UH2 = UH2_5(v75)
let v77 : UH2 = UH2_4(v76, v70)
let v78 : UH2 = method19(v43)
let v79 : bool = method28(v77, v78)
let v87 : bool =
    if v79 then
        let v80 : US3 = method20(v43)
        let v83 : US4 =
            match v80 with
            | US3_0 -> (* TriA *)
                US4_1
            | _ ->
                US4_0
        let v84 : bool =
            match v83 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v84 then
            method18(v43)
        else
            false
    else
        false
if v87 then
    ()
else
    let v88 : string = "ternary derivative equation certificate must bind source and symbol"
    failwith v88
    ()
let v89 : US0 = US0_0
let v90 : UH0 = UH0_2(v89)
let v91 : US0 = US0_1
let v92 : UH0 = UH0_2(v91)
let v93 : US0 = US0_0
let v94 : UH0 = UH0_2(v93)
let v95 : UH0 = UH0_3(v94, v92)
let v96 : UH0 = UH0_5(v95)
let v97 : UH0 = UH0_4(v96, v90)
let v98 : US0 = US0_0
let v99 : UH1 = method0(v97, v98)
let v100 : US0 = US0_0
let v101 : UH0 = UH0_2(v100)
let v102 : US0 = US0_1
let v103 : UH0 = UH0_2(v102)
let v104 : US0 = US0_0
let v105 : UH0 = UH0_2(v104)
let v106 : UH0 = UH0_3(v105, v103)
let v107 : UH0 = UH0_5(v106)
let v108 : UH0 = UH0_4(v107, v101)
let v109 : UH0 = method5(v99)
let v110 : bool = method14(v108, v109)
let v119 : bool =
    if v110 then
        let v111 : US0 = method6(v99)
        let v115 : US4 =
            match v111 with
            | US0_0 -> (* BitZero *)
                US4_1
            | US0_1 -> (* BitOne *)
                US4_0
        let v116 : bool =
            match v115 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v116 then
            method4(v99)
        else
            false
    else
        false
let v120 : US0 = US0_0
let v121 : UH0 = UH0_2(v120)
let v122 : US0 = US0_1
let v123 : UH0 = UH0_2(v122)
let v124 : US0 = US0_0
let v125 : UH0 = UH0_2(v124)
let v126 : UH0 = UH0_3(v125, v123)
let v127 : UH0 = UH0_5(v126)
let v128 : UH0 = UH0_4(v127, v121)
let v129 : US0 = US0_0
let v130 : UH0 = method8(v128, v129)
let v131 : US3 = US3_2
let v132 : UH2 = UH2_2(v131)
let v133 : US3 = US3_1
let v134 : UH2 = UH2_2(v133)
let v135 : US3 = US3_0
let v136 : UH2 = UH2_2(v135)
let v137 : UH2 = UH2_3(v136, v134)
let v138 : UH2 = UH2_5(v137)
let v139 : UH2 = UH2_4(v138, v132)
let v140 : US3 = US3_0
let v141 : UH3 = method2(v139, v140)
let v142 : US3 = US3_2
let v143 : UH2 = UH2_2(v142)
let v144 : US3 = US3_1
let v145 : UH2 = UH2_2(v144)
let v146 : US3 = US3_0
let v147 : UH2 = UH2_2(v146)
let v148 : UH2 = UH2_3(v147, v145)
let v149 : UH2 = UH2_5(v148)
let v150 : UH2 = UH2_4(v149, v143)
let v151 : UH2 = method19(v141)
let v152 : bool = method28(v150, v151)
let v160 : bool =
    if v152 then
        let v153 : US3 = method20(v141)
        let v156 : US4 =
            match v153 with
            | US3_0 -> (* TriA *)
                US4_1
            | _ ->
                US4_0
        let v157 : bool =
            match v156 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v157 then
            method18(v141)
        else
            false
    else
        false
let v161 : US3 = US3_2
let v162 : UH2 = UH2_2(v161)
let v163 : US3 = US3_1
let v164 : UH2 = UH2_2(v163)
let v165 : US3 = US3_0
let v166 : UH2 = UH2_2(v165)
let v167 : UH2 = UH2_3(v166, v164)
let v168 : UH2 = UH2_5(v167)
let v169 : UH2 = UH2_4(v168, v162)
let v170 : US3 = US3_0
let v171 : UH2 = method22(v169, v170)
let v172 : UH4 = UH4_0
let v173 : US0 = US0_1
let v174 : UH4 = UH4_1(v173, v172)
let v175 : US0 = US0_0
let v176 : UH4 = UH4_1(v175, v174)
let v177 : UH5 = method32(v176)
let v178 : UH6 = UH6_0
let v179 : UH5 = UH5_1(v178, v177)
let v180 : UH4 = UH4_0
let v181 : US0 = US0_1
let v182 : UH4 = UH4_1(v181, v180)
let v183 : US0 = US0_0
let v184 : UH4 = UH4_1(v183, v182)
let v185 : UH4 = UH4_0
let v186 : US0 = US0_1
let v187 : UH4 = UH4_1(v186, v185)
let v188 : US0 = US0_0
let v189 : UH4 = UH4_1(v188, v187)
let v190 : UH5 = method32(v189)
let v191 : UH5 = method33(v184, v190)
let v192 : UH5 = method35(v179, v191)
let v193 : UH7 = UH7_0
let v194 : US3 = US3_2
let v195 : UH7 = UH7_1(v194, v193)
let v196 : US3 = US3_1
let v197 : UH7 = UH7_1(v196, v195)
let v198 : US3 = US3_0
let v199 : UH7 = UH7_1(v198, v197)
let v200 : UH8 = method36(v199)
let v201 : UH9 = UH9_0
let v202 : UH8 = UH8_1(v201, v200)
let v203 : UH7 = UH7_0
let v204 : US3 = US3_2
let v205 : UH7 = UH7_1(v204, v203)
let v206 : US3 = US3_1
let v207 : UH7 = UH7_1(v206, v205)
let v208 : US3 = US3_0
let v209 : UH7 = UH7_1(v208, v207)
let v210 : UH7 = UH7_0
let v211 : US3 = US3_2
let v212 : UH7 = UH7_1(v211, v210)
let v213 : US3 = US3_1
let v214 : UH7 = UH7_1(v213, v212)
let v215 : US3 = US3_0
let v216 : UH7 = UH7_1(v215, v214)
let v217 : UH8 = method36(v216)
let v218 : UH8 = method37(v209, v217)
let v219 : UH8 = method39(v202, v218)
let v220 : (UH6 -> bool) = closure0(v119, v130)
let v221 : bool = method48(v220, v192)
if v221 then
    ()
else
    let v222 : string = "one bit structural certificate must instantiate over every finite suffix probe"
    failwith v222
    ()
let v223 : (UH9 -> bool) = closure1(v160, v171)
let v224 : bool = method57(v223, v219)
if v224 then
    ()
else
    let v225 : string = "one ternary structural certificate must instantiate over every finite suffix probe"
    failwith v225
    ()
let v226 : UH6 = UH6_0
let v227 : US0 = US0_0
let v228 : UH6 = UH6_1(v227, v226)
let v229 : US0 = US0_1
let v230 : UH6 = UH6_1(v229, v228)
let v231 : US0 = US0_1
let v232 : UH6 = UH6_1(v231, v230)
let v233 : UH9 = UH9_0
let v234 : US3 = US3_2
let v235 : UH9 = UH9_1(v234, v233)
let v236 : US3 = US3_1
let v237 : UH9 = UH9_1(v236, v235)
let v257 : bool =
    if v119 then
        let v238 : US0 = US0_0
        let v239 : UH6 = UH6_1(v238, v232)
        let v240 : US0 = US0_0
        let v241 : UH0 = UH0_2(v240)
        let v242 : US0 = US0_1
        let v243 : UH0 = UH0_2(v242)
        let v244 : US0 = US0_0
        let v245 : UH0 = UH0_2(v244)
        let v246 : UH0 = UH0_3(v245, v243)
        let v247 : UH0 = UH0_5(v246)
        let v248 : UH0 = UH0_4(v247, v241)
        let v249 : US0 = US0_0
        let v250 : UH6 = UH6_1(v249, v232)
        let v251 : UH5 = method40(v248, v250)
        let v252 : UH5 = method46(v239, v251)
        let v253 : UH5 = method40(v130, v232)
        let v254 : bool = method47(v252, v253)
        if v254 then
            method47(v253, v252)
        else
            false
    else
        false
if not v257 then failwith "brzozowski-expected-true"
let v277 : bool =
    if v160 then
        let v258 : US3 = US3_0
        let v259 : UH9 = UH9_1(v258, v237)
        let v260 : US3 = US3_2
        let v261 : UH2 = UH2_2(v260)
        let v262 : US3 = US3_1
        let v263 : UH2 = UH2_2(v262)
        let v264 : US3 = US3_0
        let v265 : UH2 = UH2_2(v264)
        let v266 : UH2 = UH2_3(v265, v263)
        let v267 : UH2 = UH2_5(v266)
        let v268 : UH2 = UH2_4(v267, v261)
        let v269 : US3 = US3_0
        let v270 : UH9 = UH9_1(v269, v237)
        let v271 : UH8 = method49(v268, v270)
        let v272 : UH8 = method55(v259, v271)
        let v273 : UH8 = method49(v171, v237)
        let v274 : bool = method56(v272, v273)
        if v274 then
            method56(v273, v272)
        else
            false
    else
        false
if not v277 then failwith "brzozowski-expected-true"
let v278 : UH0 = UH0_1
let v279 : US0 = US0_0
let v280 : UH1 = method0(v278, v279)
let v281 : US0 = US0_0
let v282 : UH0 = UH0_2(v281)
let v283 : US0 = US0_0
let v284 : UH1 = method0(v282, v283)
let v285 : UH0 = UH0_1
let v286 : US0 = US0_0
let v287 : UH1 = method0(v285, v286)
let v288 : US0 = US0_1
let v289 : US0 = US0_1
let v290 : UH1 = UH1_2(v289, v288)
let v291 : US0 = US0_0
let v292 : US0 = US0_0
let v293 : UH1 = UH1_2(v292, v291)
let v294 : US0 = US0_0
let v295 : UH1 = UH1_3(v294, v293, v290)
let v296 : bool = method4(v295)
let v297 : bool = v296 = false
if v297 then
    ()
else
    let v298 : string = "a child proof from another symbol context must be rejected"
    failwith v298
    ()
let v299 : US1 = US1_1
let v300 : US0 = US0_0
let v301 : UH1 = UH1_4(v300, v299, v280, v284)
let v302 : bool = method4(v301)
let v303 : bool = v302 = false
if v303 then
    ()
else
    let v304 : string = "a forged nullable concatenation branch must be rejected"
    failwith v304
    ()
let v305 : UH0 = UH0_0
let v306 : UH0 = method5(v287)
let v307 : bool = method14(v305, v306)
let v316 : bool =
    if v307 then
        let v308 : US0 = method6(v287)
        let v312 : US4 =
            match v308 with
            | US0_0 -> (* BitZero *)
                US4_1
            | US0_1 -> (* BitOne *)
                US4_0
        let v313 : bool =
            match v312 with
            | US4_1 -> (* SymbolSame *)
                true
            | _ ->
                false
        if v313 then
            method4(v287)
        else
            false
    else
        false
let v317 : bool = v316 = false
if v317 then
    ()
else
    let v318 : string = "a forged source binding must be rejected"
    failwith v318
    ()
let v319 : string = "brzozowski-derivative-universal-witness-green"
v319
