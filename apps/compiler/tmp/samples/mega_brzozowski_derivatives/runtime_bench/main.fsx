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
and [<Struct>] US2 =
    | US2_0
    | US2_1
and UH2 =
    | UH2_0
    | UH2_1 of UH0 * UH2
let rec method1 (v0 : uint64, v1 : int32, v2 : UH1) : struct (UH1 * uint64) =
    let v3 : bool = 0 < v1
    if v3 then
        let v4 : uint64 = v0 * 1103515245UL
        let v5 : uint64 = v4 + 12345UL
        let v6 : uint64 = v5 &&& 2147483647UL
        let v7 : int32 = v1 - 1
        let v8 : uint64 = v6 >>> 16
        let v9 : uint64 = v8 &&& 1UL
        let v10 : bool = v9 = 0UL
        let v13 : US0 =
            if v10 then
                let v11 : US0 = US0_0
                v11
            else
                let v12 : US0 = US0_1
                v12
        let v14 : UH1 = UH1_1(v13, v2)
        method1(v6, v7, v14)
    else
        struct (v2, v0)
and method7 (v0 : UH0, v1 : UH0) : US1 =
    match v0 with
    | UH0_3(v53, v54) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v55, v56) -> (* RegexAlt *)
            let v57 : US1 = method7(v53, v55)
            match v57 with
            | US1_1 -> (* SymbolSame *)
                method7(v54, v56)
            | _ ->
                v57
        | _ ->
            US1_2
    | UH0_4(v28, v29) -> (* RegexCat *)
        match v1 with
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : US1 = method7(v28, v34)
            match v36 with
            | US1_1 -> (* SymbolSame *)
                method7(v29, v35)
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
            method7(v44, v48)
        | _ ->
            US1_2
and method6 (v0 : UH0, v1 : UH0) : UH0 =
    match v1 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : US1 = method7(v0, v2)
        match v4 with
        | US1_2 -> (* SymbolGreater *)
            let v6 : UH0 = method6(v0, v3)
            UH0_3(v2, v6)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
    | UH0_0 -> (* RegexEmpty *)
        v0
    | _ ->
        let v11 : US1 = method7(v0, v1)
        match v11 with
        | US1_2 -> (* SymbolGreater *)
            UH0_3(v1, v0)
        | US1_0 -> (* SymbolLess *)
            UH0_3(v0, v1)
        | US1_1 -> (* SymbolSame *)
            v1
and method5 (v0 : UH0, v1 : UH0) : UH0 =
    match v0 with
    | UH0_3(v2, v3) -> (* RegexAlt *)
        let v4 : UH0 = method6(v2, v1)
        method5(v3, v4)
    | UH0_0 -> (* RegexEmpty *)
        v1
    | _ ->
        method6(v0, v1)
and method9 (v0 : UH0, v1 : UH0) : bool =
    match v0 with
    | UH0_3(v18, v19) -> (* RegexAlt *)
        match v1 with
        | UH0_3(v20, v21) -> (* RegexAlt *)
            let v22 : bool = method9(v18, v20)
            if v22 then
                method9(v19, v21)
            else
                false
        | _ ->
            false
    | UH0_4(v26, v27) -> (* RegexCat *)
        match v1 with
        | UH0_4(v28, v29) -> (* RegexCat *)
            let v30 : bool = method9(v26, v28)
            if v30 then
                method9(v27, v29)
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
            method9(v34, v35)
        | _ ->
            false
and method8 (v0 : UH0, v1 : UH0) : UH0 =
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
                        let v14 : UH0 = method8(v13, v1)
                        UH0_4(v12, v14)
                    | UH0_5(v4) -> (* RegexStar *)
                        match v1 with
                        | UH0_5(v5) -> (* RegexStar *)
                            let v6 : bool = method9(v4, v5)
                            if v6 then
                                UH0_5(v4)
                            else
                                UH0_4(v0, v1)
                        | _ ->
                            UH0_4(v0, v1)
                    | _ ->
                        UH0_4(v0, v1)
and method10 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_0 -> (* RegexEmpty *)
        UH0_1
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v3) -> (* RegexStar *)
        UH0_5(v3)
    | _ ->
        UH0_5(v0)
and method4 (v0 : UH0) : UH0 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : UH0 = method4(v5)
        let v8 : UH0 = method4(v6)
        method5(v7, v8)
    | UH0_4(v10, v11) -> (* RegexCat *)
        let v12 : UH0 = method4(v10)
        let v13 : UH0 = method4(v11)
        method8(v12, v13)
    | UH0_2(v3) -> (* RegexChar *)
        UH0_2(v3)
    | UH0_0 -> (* RegexEmpty *)
        UH0_0
    | UH0_1 -> (* RegexEpsilon *)
        UH0_1
    | UH0_5(v15) -> (* RegexStar *)
        let v16 : UH0 = method4(v15)
        method10(v16)
and method12 (v0 : UH0) : US2 =
    match v0 with
    | UH0_3(v5, v6) -> (* RegexAlt *)
        let v7 : US2 = method12(v5)
        let v8 : US2 = method12(v6)
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
        let v18 : US2 = method12(v16)
        let v19 : US2 = method12(v17)
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
and method11 (v0 : UH0, v1 : US0) : UH0 =
    match v0 with
    | UH0_3(v19, v20) -> (* RegexAlt *)
        let v21 : UH0 = method11(v19, v1)
        let v22 : UH0 = method11(v20, v1)
        method5(v21, v22)
    | UH0_4(v24, v25) -> (* RegexCat *)
        let v26 : US2 = method12(v24)
        match v26 with
        | US2_1 -> (* NonNullable *)
            let v31 : UH0 = method11(v24, v1)
            method8(v31, v25)
        | US2_0 -> (* Nullable *)
            let v27 : UH0 = method11(v24, v1)
            let v28 : UH0 = method8(v27, v25)
            let v29 : UH0 = method11(v25, v1)
            method5(v28, v29)
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
        let v36 : UH0 = method11(v35, v1)
        let v37 : UH0 = method10(v35)
        method8(v36, v37)
and method3 (v0 : UH0, v1 : US0) : UH0 =
    let v2 : UH0 = method4(v0)
    let v3 : UH0 = method11(v2, v1)
    method4(v3)
and method2 (v0 : UH0, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v6, v7) -> (* InputCons *)
        let v8 : UH0 = method3(v0, v6)
        method2(v8, v7)
    | UH1_0 -> (* InputEmpty *)
        let v2 : UH0 = method4(v0)
        let v3 : US2 = method12(v2)
        match v3 with
        | US2_1 -> (* NonNullable *)
            false
        | US2_0 -> (* Nullable *)
            true
and method0 (v0 : UH0, v1 : int32, v2 : int32, v3 : uint64, v4 : int32) : int32 =
    let v5 : bool = 0 < v2
    if v5 then
        let v6 : UH1 = UH1_0
        let struct (v7 : UH1, v8 : uint64) = method1(v3, v1, v6)
        let v9 : bool = method2(v0, v7)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v4 + 1
                v10
            else
                v4
        let v12 : int32 = v2 - 1
        method0(v0, v1, v12, v8, v11)
    else
        v4
and method14 (v0 : int32, v1 : UH1) : UH1 =
    let v2 : bool = 0 < v0
    if v2 then
        let v3 : int32 = v0 - 1
        let v4 : US0 = US0_0
        let v5 : UH1 = UH1_1(v4, v1)
        method14(v3, v5)
    else
        v1
and method13 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_0
        let v6 : UH1 = method14(v2, v5)
        let v7 : bool = method2(v0, v6)
        let v9 : int32 =
            if v7 then
                let v8 : int32 = v3 + 1
                v8
            else
                v3
        let v10 : US0 = US0_1
        let v11 : UH1 = UH1_0
        let v12 : UH1 = UH1_1(v10, v11)
        let v13 : UH1 = method14(v2, v12)
        let v14 : bool = method2(v0, v13)
        let v16 : int32 =
            if v14 then
                let v15 : int32 = v9 + 1
                v15
            else
                v9
        let v17 : int32 = v2 + 1
        method13(v0, v1, v17, v16)
and method16 (v0 : UH2, v1 : UH1) : bool =
    match v0 with
    | UH2_1(v6, v7) -> (* RegexListCons *)
        match v6 with
        | UH0_3(v27, v28) -> (* RegexAlt *)
            let v29 : UH2 = UH2_1(v27, v7)
            let v30 : bool = method16(v29, v1)
            if v30 then
                true
            else
                let v31 : UH2 = UH2_1(v28, v7)
                method16(v31, v1)
        | UH0_4(v34, v35) -> (* RegexCat *)
            let v36 : UH2 = UH2_1(v35, v7)
            let v37 : UH2 = UH2_1(v34, v36)
            method16(v37, v1)
        | UH0_2(v9) -> (* RegexChar *)
            match v1 with
            | UH1_1(v10, v11) -> (* InputCons *)
                let v21 : US1 =
                    match v9 with
                    | US0_1 -> (* BitOne *)
                        match v10 with
                        | US0_1 -> (* BitOne *)
                            US1_1
                        | US0_0 -> (* BitZero *)
                            US1_2
                    | US0_0 -> (* BitZero *)
                        match v10 with
                        | US0_1 -> (* BitOne *)
                            US1_0
                        | US0_0 -> (* BitZero *)
                            US1_1
                let v22 : bool =
                    match v21 with
                    | US1_1 -> (* SymbolSame *)
                        true
                    | _ ->
                        false
                if v22 then
                    method16(v7, v11)
                else
                    false
            | UH1_0 -> (* InputEmpty *)
                false
        | UH0_0 -> (* RegexEmpty *)
            false
        | UH0_1 -> (* RegexEpsilon *)
            method16(v7, v1)
        | UH0_5(v39) -> (* RegexStar *)
            let v40 : UH2 = UH2_1(v39, v0)
            let v41 : bool = method16(v40, v1)
            if v41 then
                true
            else
                method16(v7, v1)
    | UH2_0 -> (* RegexListNil *)
        match v1 with
        | UH1_1(v2, v3) -> (* InputCons *)
            false
        | UH1_0 -> (* InputEmpty *)
            true
and method15 (v0 : UH0, v1 : int32, v2 : int32, v3 : uint64, v4 : int32) : int32 =
    let v5 : bool = 0 < v2
    if v5 then
        let v6 : UH1 = UH1_0
        let struct (v7 : UH1, v8 : uint64) = method1(v3, v1, v6)
        let v9 : UH2 = UH2_0
        let v10 : UH2 = UH2_1(v0, v9)
        let v11 : bool = method16(v10, v7)
        let v13 : int32 =
            if v11 then
                let v12 : int32 = v4 + 1
                v12
            else
                v4
        let v14 : int32 = v2 - 1
        method15(v0, v1, v14, v8, v13)
    else
        v4
and method17 (v0 : UH0, v1 : int32, v2 : int32, v3 : int32) : int32 =
    let v4 : bool = v1 < v2
    if v4 then
        v3
    else
        let v5 : UH1 = UH1_0
        let v6 : UH1 = method14(v2, v5)
        let v7 : UH2 = UH2_0
        let v8 : UH2 = UH2_1(v0, v7)
        let v9 : bool = method16(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : US0 = US0_1
        let v13 : UH1 = UH1_0
        let v14 : UH1 = UH1_1(v12, v13)
        let v15 : UH1 = method14(v2, v14)
        let v16 : UH2 = UH2_0
        let v17 : UH2 = UH2_1(v0, v16)
        let v18 : bool = method16(v17, v15)
        let v20 : int32 =
            if v18 then
                let v19 : int32 = v11 + 1
                v19
            else
                v11
        let v21 : int32 = v2 + 1
        method17(v0, v1, v21, v20)
and method19 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v3, v4) -> (* InputCons *)
        match v3 with
        | US0_1 -> (* BitOne *)
            let v8 : bool = v0 = 0
            let v9 : int32 = 0
            method19(v9, v4)
        | US0_0 -> (* BitZero *)
            let v5 : bool = v0 = 0
            let v6 : int32 = 1
            method19(v6, v4)
    | UH1_0 -> (* InputEmpty *)
        let v2 : bool = v0 = 1
        v2
and method18 (v0 : int32, v1 : int32, v2 : uint64, v3 : int32) : int32 =
    let v4 : bool = 0 < v1
    if v4 then
        let v5 : UH1 = UH1_0
        let struct (v6 : UH1, v7 : uint64) = method1(v2, v0, v5)
        let v8 : int32 = 0
        let v9 : bool = method19(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : int32 = v1 - 1
        method18(v0, v12, v7, v11)
    else
        v3
and method21 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v17, v18) -> (* InputCons *)
        match v17 with
        | US0_1 -> (* BitOne *)
            let v50 : bool = v0 = 0
            let v79 : int32 =
                if v50 then
                    1
                else
                    let v51 : bool = v0 = 1
                    if v51 then
                        6
                    else
                        let v52 : bool = v0 = 2
                        if v52 then
                            11
                        else
                            let v53 : bool = v0 = 3
                            if v53 then
                                5
                            else
                                let v54 : bool = v0 = 4
                                if v54 then
                                    1
                                else
                                    let v55 : bool = v0 = 5
                                    if v55 then
                                        6
                                    else
                                        let v56 : bool = v0 = 6
                                        if v56 then
                                            13
                                        else
                                            let v57 : bool = v0 = 7
                                            if v57 then
                                                9
                                            else
                                                let v58 : bool = v0 = 8
                                                if v58 then
                                                    5
                                                else
                                                    let v59 : bool = v0 = 9
                                                    if v59 then
                                                        12
                                                    else
                                                        let v60 : bool = v0 = 10
                                                        if v60 then
                                                            11
                                                        else
                                                            let v61 : bool = v0 = 11
                                                            if v61 then
                                                                12
                                                            else
                                                                let v62 : bool = v0 = 12
                                                                if v62 then
                                                                    13
                                                                else
                                                                    let v63 : bool = v0 = 13
                                                                    if v63 then
                                                                        15
                                                                    else
                                                                        let v64 : bool = v0 = 14
                                                                        if v64 then
                                                                            9
                                                                        else
                                                                            15
            method21(v79, v18)
        | US0_0 -> (* BitZero *)
            let v19 : bool = v0 = 0
            let v48 : int32 =
                if v19 then
                    0
                else
                    let v20 : bool = v0 = 1
                    if v20 then
                        2
                    else
                        let v21 : bool = v0 = 2
                        if v21 then
                            3
                        else
                            let v22 : bool = v0 = 3
                            if v22 then
                                4
                            else
                                let v23 : bool = v0 = 4
                                if v23 then
                                    0
                                else
                                    let v24 : bool = v0 = 5
                                    if v24 then
                                        2
                                    else
                                        let v25 : bool = v0 = 6
                                        if v25 then
                                            7
                                        else
                                            let v26 : bool = v0 = 7
                                            if v26 then
                                                8
                                            else
                                                let v27 : bool = v0 = 8
                                                if v27 then
                                                    4
                                                else
                                                    let v28 : bool = v0 = 9
                                                    if v28 then
                                                        10
                                                    else
                                                        let v29 : bool = v0 = 10
                                                        if v29 then
                                                            3
                                                        else
                                                            let v30 : bool = v0 = 11
                                                            if v30 then
                                                                10
                                                            else
                                                                let v31 : bool = v0 = 12
                                                                if v31 then
                                                                    7
                                                                else
                                                                    let v32 : bool = v0 = 13
                                                                    if v32 then
                                                                        14
                                                                    else
                                                                        let v33 : bool = v0 = 14
                                                                        if v33 then
                                                                            8
                                                                        else
                                                                            14
            method21(v48, v18)
    | UH1_0 -> (* InputEmpty *)
        let v2 : bool = v0 = 4
        if v2 then
            true
        else
            let v3 : bool = v0 = 5
            if v3 then
                true
            else
                let v4 : bool = v0 = 8
                if v4 then
                    true
                else
                    let v5 : bool = v0 = 9
                    if v5 then
                        true
                    else
                        let v6 : bool = v0 = 10
                        if v6 then
                            true
                        else
                            let v7 : bool = v0 = 12
                            if v7 then
                                true
                            else
                                let v8 : bool = v0 = 14
                                if v8 then
                                    true
                                else
                                    let v9 : bool = v0 = 15
                                    v9
and method20 (v0 : int32, v1 : int32, v2 : uint64, v3 : int32) : int32 =
    let v4 : bool = 0 < v1
    if v4 then
        let v5 : UH1 = UH1_0
        let struct (v6 : UH1, v7 : uint64) = method1(v2, v0, v5)
        let v8 : int32 = 0
        let v9 : bool = method21(v8, v6)
        let v11 : int32 =
            if v9 then
                let v10 : int32 = v3 + 1
                v10
            else
                v3
        let v12 : int32 = v1 - 1
        method20(v0, v12, v7, v11)
    else
        v3
and method23 (v0 : int32, v1 : UH1) : bool =
    match v1 with
    | UH1_1(v3, v4) -> (* InputCons *)
        match v3 with
        | US0_1 -> (* BitOne *)
            let v13 : bool = v0 = 0
            let v19 : int32 =
                if v13 then
                    3
                else
                    let v14 : bool = v0 = 1
                    if v14 then
                        3
                    else
                        let v15 : bool = v0 = 2
                        if v15 then
                            3
                        else
                            let v16 : bool = v0 = 3
                            4
            method23(v19, v4)
        | US0_0 -> (* BitZero *)
            let v5 : bool = v0 = 0
            let v11 : int32 =
                if v5 then
                    1
                else
                    let v6 : bool = v0 = 1
                    if v6 then
                        2
                    else
                        let v7 : bool = v0 = 2
                        if v7 then
                            2
                        else
                            let v8 : bool = v0 = 3
                            4
            method23(v11, v4)
    | UH1_0 -> (* InputEmpty *)
        let v2 : bool = v0 = 3
        v2
and method22 (v0 : int32, v1 : int32, v2 : int32) : int32 =
    let v3 : bool = v0 < v1
    if v3 then
        v2
    else
        let v4 : UH1 = UH1_0
        let v5 : UH1 = method14(v1, v4)
        let v6 : int32 = 0
        let v7 : bool = method23(v6, v5)
        let v9 : int32 =
            if v7 then
                let v8 : int32 = v2 + 1
                v8
            else
                v2
        let v10 : US0 = US0_1
        let v11 : UH1 = UH1_0
        let v12 : UH1 = UH1_1(v10, v11)
        let v13 : UH1 = method14(v1, v12)
        let v14 : int32 = 0
        let v15 : bool = method23(v14, v13)
        let v17 : int32 =
            if v15 then
                let v16 : int32 = v9 + 1
                v16
            else
                v9
        let v18 : int32 = v1 + 1
        method22(v0, v18, v17)
and method24 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 8192
    if v2 then
        v0.[int v1] <- 0
        let v3 : int32 = v1 + 1
        method24(v0, v3)
and method25 (v0 : (int32 []), v1 : int32) : unit =
    let v2 : bool = v1 < 1
    if v2 then
        v0.[int v1] <- 0
        let v3 : int32 = v1 + 1
        method25(v0, v3)
and method27 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : int32) : int32 =
    let v11 : int32 = v4.[int v10]
    let v12 : bool = v11 = 0
    if v12 then
        let v13 : int32 = v6.[int 0]
        let v14 : bool = v13 < 4096
        if v14 then
            v0.[int v13] <- v7
            v1.[int v13] <- v8
            v2.[int v13] <- v9
            let v15 : bool = v7 = 1
            let v32 : bool =
                if v15 then
                    true
                else
                    let v16 : bool = v7 = 5
                    if v16 then
                        true
                    else
                        let v17 : bool = v7 = 3
                        if v17 then
                            let v18 : int32 = v3.[int v8]
                            let v19 : bool = v18 = 1
                            if v19 then
                                true
                            else
                                let v20 : int32 = v3.[int v9]
                                let v21 : bool = v20 = 1
                                v21
                        else
                            let v23 : bool = v7 = 4
                            if v23 then
                                let v24 : int32 = v3.[int v8]
                                let v25 : bool = v24 = 1
                                if v25 then
                                    let v26 : int32 = v3.[int v9]
                                    let v27 : bool = v26 = 1
                                    v27
                                else
                                    false
                            else
                                false
            let v33 : int32 =
                if v32 then
                    1
                else
                    0
            v3.[int v13] <- v33
            let v34 : int32 = v13 + 1
            v4.[int v10] <- v34
            v6.[int 0] <- v34
            v13
        else
            failwith<int32> "brzozowski-interned-store-full"
    else
        let v37 : int32 = v11 - 1
        let v38 : int32 = v0.[int v37]
        let v39 : bool = v38 = v7
        let v42 : bool =
            if v39 then
                let v40 : int32 = v1.[int v37]
                let v41 : bool = v40 = v8
                v41
            else
                false
        let v45 : bool =
            if v42 then
                let v43 : int32 = v2.[int v37]
                let v44 : bool = v43 = v9
                v44
            else
                false
        if v45 then
            v37
        else
            let v46 : int32 = v10 + 1
            let v47 : int32 = v46 &&& 8191
            method27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47)
and method26 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32) : int32 =
    let v10 : int32 = v7 * 1024
    let v11 : int32 = v10 + v8
    let v12 : int32 = v11 * 4099
    let v13 : int32 = v12 + v9
    let v14 : int32 = v13 &&& 8191
    method27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
and method30 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v8 = 0
    if v9 then
        v7
    else
        let v10 : int32 = v0.[int v8]
        let v11 : bool = v10 = 3
        if v11 then
            let v12 : int32 = v1.[int v8]
            let v13 : bool = v7 < v12
            if v13 then
                let v14 : int32 = 3
                method26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
            else
                let v16 : bool = v7 = v12
                if v16 then
                    v8
                else
                    let v17 : int32 = 3
                    let v18 : int32 = v2.[int v8]
                    let v19 : int32 = method30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                    method26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
        else
            let v23 : bool = v7 < v8
            if v23 then
                let v24 : int32 = 3
                method26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
            else
                let v26 : bool = v7 = v8
                if v26 then
                    v8
                else
                    let v27 : int32 = 3
                    method26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
and method29 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v7 = 0
    if v9 then
        v8
    else
        let v10 : int32 = v0.[int v7]
        let v11 : bool = v10 = 3
        if v11 then
            let v12 : int32 = v2.[int v7]
            let v13 : int32 = v1.[int v7]
            let v14 : int32 = method30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
            method29(v0, v1, v2, v3, v4, v5, v6, v12, v14)
        else
            method30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and method31 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : bool = v7 = 0
    if v9 then
        0
    else
        let v10 : bool = v8 = 0
        if v10 then
            0
        else
            let v11 : bool = v7 = 1
            if v11 then
                v8
            else
                let v12 : bool = v8 = 1
                if v12 then
                    v7
                else
                    let v13 : int32 = v0.[int v7]
                    let v14 : bool = v13 = 5
                    let v17 : bool =
                        if v14 then
                            let v15 : int32 = v0.[int v8]
                            let v16 : bool = v15 = 5
                            v16
                        else
                            false
                    if v17 then
                        let v18 : int32 = v1.[int v7]
                        let v19 : int32 = v1.[int v8]
                        let v20 : bool = v18 = v19
                        if v20 then
                            v7
                        else
                            let v21 : int32 = 4
                            method26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                    else
                        let v24 : int32 = v0.[int v7]
                        let v25 : bool = v24 = 4
                        if v25 then
                            let v26 : int32 = 4
                            let v27 : int32 = v1.[int v7]
                            let v28 : int32 = v2.[int v7]
                            let v29 : int32 = method31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                            method26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                        else
                            let v31 : int32 = 4
                            method26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
and method28 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : UH0) : int32 =
    match v7 with
    | UH0_3(v14, v15) -> (* RegexAlt *)
        let v16 : int32 = method28(v0, v1, v2, v3, v4, v5, v6, v14)
        let v17 : int32 = method28(v0, v1, v2, v3, v4, v5, v6, v15)
        method29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
    | UH0_4(v19, v20) -> (* RegexCat *)
        let v21 : int32 = method28(v0, v1, v2, v3, v4, v5, v6, v19)
        let v22 : int32 = method28(v0, v1, v2, v3, v4, v5, v6, v20)
        method31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
    | UH0_2(v8) -> (* RegexChar *)
        let v9 : int32 = 2
        let v11 : int32 =
            match v8 with
            | US0_1 -> (* BitOne *)
                1
            | US0_0 -> (* BitZero *)
                0
        let v12 : int32 = 0
        method26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
    | UH0_0 -> (* RegexEmpty *)
        0
    | UH0_1 -> (* RegexEpsilon *)
        1
    | UH0_5(v24) -> (* RegexStar *)
        let v25 : int32 = method28(v0, v1, v2, v3, v4, v5, v6, v24)
        let v26 : int32 = v0.[int v25]
        let v27 : bool = v26 < 2
        if v27 then
            1
        else
            let v28 : bool = v26 = 5
            if v28 then
                v25
            else
                let v29 : int32 = 5
                let v30 : int32 = 0
                method26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
and method35 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32) : int32 =
    let v9 : int32 = v7 * 2
    let v10 : int32 = v9 + v8
    let v11 : int32 = v5.[int v10]
    let v12 : bool = v11 = 0
    if v12 then
        let v13 : int32 = v0.[int v7]
        let v14 : bool = v13 < 2
        let v41 : int32 =
            if v14 then
                0
            else
                let v15 : bool = v13 = 2
                if v15 then
                    let v16 : int32 = v1.[int v7]
                    let v17 : bool = v16 = v8
                    if v17 then
                        1
                    else
                        0
                else
                    let v19 : bool = v13 = 3
                    if v19 then
                        let v20 : int32 = v1.[int v7]
                        let v21 : int32 = method35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                        let v22 : int32 = v2.[int v7]
                        let v23 : int32 = method35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                        method29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                    else
                        let v25 : bool = v13 = 4
                        if v25 then
                            let v26 : int32 = v1.[int v7]
                            let v27 : int32 = v2.[int v7]
                            let v28 : int32 = method35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                            let v29 : int32 = method31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                            let v30 : int32 = v3.[int v26]
                            let v31 : bool = v30 = 1
                            if v31 then
                                let v32 : int32 = method35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                                method29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                            else
                                v29
                        else
                            let v35 : int32 = v1.[int v7]
                            let v36 : int32 = method35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                            method31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
        let v42 : int32 = v41 + 1
        v5.[int v10] <- v42
        v41
    else
        let v43 : int32 = v11 - 1
        v43
and method34 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    let v9 : bool = v7 = 0
    if v9 then
        false
    else
        match v8 with
        | UH1_1(v12, v13) -> (* InputCons *)
            let v15 : int32 =
                match v12 with
                | US0_1 -> (* BitOne *)
                    1
                | US0_0 -> (* BitZero *)
                    0
            let v16 : int32 = method35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
            method34(v0, v1, v2, v3, v4, v5, v6, v16, v13)
        | UH1_0 -> (* InputEmpty *)
            let v10 : int32 = v3.[int v7]
            let v11 : bool = v10 = 1
            v11
and method33 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : UH1) : bool =
    method34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
and method32 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : uint64, v11 : int32) : int32 =
    let v12 : bool = 0 < v9
    if v12 then
        let v13 : UH1 = UH1_0
        let struct (v14 : UH1, v15 : uint64) = method1(v10, v7, v13)
        let v16 : bool = method33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
        let v18 : int32 =
            if v16 then
                let v17 : int32 = v11 + 1
                v17
            else
                v11
        let v19 : int32 = v9 - 1
        method32(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18)
    else
        v11
and method36 (v0 : (int32 []), v1 : (int32 []), v2 : (int32 []), v3 : (int32 []), v4 : (int32 []), v5 : (int32 []), v6 : (int32 []), v7 : int32, v8 : int32, v9 : int32, v10 : int32) : int32 =
    let v11 : bool = v7 < v9
    if v11 then
        v10
    else
        let v12 : UH1 = UH1_0
        let v13 : UH1 = method14(v9, v12)
        let v14 : bool = method33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
        let v16 : int32 =
            if v14 then
                let v15 : int32 = v10 + 1
                v15
            else
                v10
        let v17 : US0 = US0_1
        let v18 : UH1 = UH1_0
        let v19 : UH1 = UH1_1(v17, v18)
        let v20 : UH1 = method14(v9, v19)
        let v21 : bool = method33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
        let v23 : int32 =
            if v21 then
                let v22 : int32 = v16 + 1
                v22
            else
                v16
        let v24 : int32 = v9 + 1
        method36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23)
let v0 : int32 = 200
let v1 : int32 = 32
let v2 : US0 = US0_0
let v3 : UH0 = UH0_2(v2)
let v4 : US0 = US0_1
let v5 : UH0 = UH0_2(v4)
let v6 : UH0 = UH0_3(v3, v5)
let v7 : UH0 = UH0_5(v6)
let v8 : US0 = US0_0
let v9 : UH0 = UH0_2(v8)
let v10 : UH0 = UH0_4(v7, v9)
let v11 : US0 = US0_0
let v12 : UH0 = UH0_2(v11)
let v13 : US0 = US0_1
let v14 : UH0 = UH0_2(v13)
let v15 : UH0 = UH0_3(v12, v14)
let v16 : UH0 = UH0_5(v15)
let v17 : US0 = US0_1
let v18 : UH0 = UH0_2(v17)
let v19 : US0 = US0_0
let v20 : UH0 = UH0_2(v19)
let v21 : US0 = US0_1
let v22 : UH0 = UH0_2(v21)
let v23 : UH0 = UH0_3(v20, v22)
let v24 : US0 = US0_0
let v25 : UH0 = UH0_2(v24)
let v26 : US0 = US0_1
let v27 : UH0 = UH0_2(v26)
let v28 : UH0 = UH0_3(v25, v27)
let v29 : US0 = US0_0
let v30 : UH0 = UH0_2(v29)
let v31 : US0 = US0_1
let v32 : UH0 = UH0_2(v31)
let v33 : UH0 = UH0_3(v30, v32)
let v34 : UH0 = UH0_4(v28, v33)
let v35 : UH0 = UH0_4(v23, v34)
let v36 : UH0 = UH0_4(v18, v35)
let v37 : UH0 = UH0_4(v16, v36)
let v38 : uint64 = 1UL
let v39 : int32 = 0
let v40 : int32 = method0(v10, v1, v0, v38, v39)
let v41 : int32 = method0(v37, v1, v0, v38, v39)
let v42 : int32 = 16
let v43 : US0 = US0_0
let v44 : UH0 = UH0_2(v43)
let v45 : US0 = US0_0
let v46 : UH0 = UH0_2(v45)
let v47 : US0 = US0_0
let v48 : UH0 = UH0_2(v47)
let v49 : UH0 = UH0_4(v46, v48)
let v50 : UH0 = UH0_3(v44, v49)
let v51 : UH0 = UH0_5(v50)
let v52 : US0 = US0_1
let v53 : UH0 = UH0_2(v52)
let v54 : UH0 = UH0_4(v51, v53)
let v55 : int32 = 0
let v56 : int32 = 1
let v57 : int32 = method13(v54, v42, v56, v55)
let v58 : int32 = 200
let v59 : int32 = 32
let v60 : US0 = US0_0
let v61 : UH0 = UH0_2(v60)
let v62 : US0 = US0_1
let v63 : UH0 = UH0_2(v62)
let v64 : UH0 = UH0_3(v61, v63)
let v65 : UH0 = UH0_5(v64)
let v66 : US0 = US0_0
let v67 : UH0 = UH0_2(v66)
let v68 : UH0 = UH0_4(v65, v67)
let v69 : US0 = US0_0
let v70 : UH0 = UH0_2(v69)
let v71 : US0 = US0_1
let v72 : UH0 = UH0_2(v71)
let v73 : UH0 = UH0_3(v70, v72)
let v74 : UH0 = UH0_5(v73)
let v75 : US0 = US0_1
let v76 : UH0 = UH0_2(v75)
let v77 : US0 = US0_0
let v78 : UH0 = UH0_2(v77)
let v79 : US0 = US0_1
let v80 : UH0 = UH0_2(v79)
let v81 : UH0 = UH0_3(v78, v80)
let v82 : US0 = US0_0
let v83 : UH0 = UH0_2(v82)
let v84 : US0 = US0_1
let v85 : UH0 = UH0_2(v84)
let v86 : UH0 = UH0_3(v83, v85)
let v87 : US0 = US0_0
let v88 : UH0 = UH0_2(v87)
let v89 : US0 = US0_1
let v90 : UH0 = UH0_2(v89)
let v91 : UH0 = UH0_3(v88, v90)
let v92 : UH0 = UH0_4(v86, v91)
let v93 : UH0 = UH0_4(v81, v92)
let v94 : UH0 = UH0_4(v76, v93)
let v95 : UH0 = UH0_4(v74, v94)
let v96 : uint64 = 1UL
let v97 : int32 = 0
let v98 : int32 = method15(v68, v59, v58, v96, v97)
let v99 : int32 = method15(v95, v59, v58, v96, v97)
let v100 : int32 = 16
let v101 : US0 = US0_0
let v102 : UH0 = UH0_2(v101)
let v103 : US0 = US0_0
let v104 : UH0 = UH0_2(v103)
let v105 : US0 = US0_0
let v106 : UH0 = UH0_2(v105)
let v107 : UH0 = UH0_4(v104, v106)
let v108 : UH0 = UH0_3(v102, v107)
let v109 : UH0 = UH0_5(v108)
let v110 : US0 = US0_1
let v111 : UH0 = UH0_2(v110)
let v112 : UH0 = UH0_4(v109, v111)
let v113 : int32 = 0
let v114 : int32 = 1
let v115 : int32 = method17(v112, v100, v114, v113)
let v116 : bool = v40 = v98
let v118 : bool =
    if v116 then
        let v117 : bool = v41 = v99
        v117
    else
        false
let v120 : bool =
    if v118 then
        let v119 : bool = v57 = v115
        v119
    else
        false
if v120 then
    ()
else
    failwith<unit> "brzozowski-bench-engines-disagree"
let v121 : int32 = 200
let v122 : int32 = 32
let v123 : uint64 = 1UL
let v124 : int32 = 0
let v125 : int32 = method18(v122, v121, v123, v124)
let v126 : int32 = method20(v122, v121, v123, v124)
let v127 : int32 = 16
let v128 : int32 = 0
let v129 : int32 = 1
let v130 : int32 = method22(v127, v129, v128)
let v131 : bool = v40 = v125
let v133 : bool =
    if v131 then
        let v132 : bool = v41 = v126
        v132
    else
        false
let v135 : bool =
    if v133 then
        let v134 : bool = v57 = v130
        v134
    else
        false
if v135 then
    ()
else
    failwith<unit> "brzozowski-bench-engines-disagree"
let v136 : int32 = 200
let v137 : int32 = 32
let v138 : (int32 []) = Array.zeroCreate<int32> (4096)
let v139 : (int32 []) = Array.zeroCreate<int32> (4096)
let v140 : (int32 []) = Array.zeroCreate<int32> (4096)
let v141 : (int32 []) = Array.zeroCreate<int32> (4096)
let v142 : (int32 []) = Array.zeroCreate<int32> (8192)
let v143 : (int32 []) = Array.zeroCreate<int32> (8192)
let v144 : (int32 []) = Array.zeroCreate<int32> (1)
let v145 : int32 = 0
method24(v142, v145)
let v146 : int32 = 0
method24(v143, v146)
let v147 : int32 = 0
method25(v144, v147)
let v148 : int32 = 0
let v149 : int32 = 0
let v150 : int32 = 0
let v151 : int32 = method26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
let v152 : int32 = 1
let v153 : int32 = 0
let v154 : int32 = 0
let v155 : int32 = method26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
let v156 : bool = v151 = 0
let v158 : bool =
    if v156 then
        let v157 : bool = v155 = 1
        v157
    else
        false
let struct (v166 : (int32 []), v167 : (int32 []), v168 : (int32 []), v169 : (int32 []), v170 : (int32 []), v171 : (int32 []), v172 : (int32 [])) =
    if v158 then
        struct (v138, v139, v140, v141, v142, v143, v144)
    else
        failwith<struct ((int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []))> "brzozowski-interned-store-init"
let v173 : US0 = US0_0
let v174 : UH0 = UH0_2(v173)
let v175 : US0 = US0_1
let v176 : UH0 = UH0_2(v175)
let v177 : UH0 = UH0_3(v174, v176)
let v178 : UH0 = UH0_5(v177)
let v179 : US0 = US0_0
let v180 : UH0 = UH0_2(v179)
let v181 : UH0 = UH0_4(v178, v180)
let v182 : int32 = method28(v166, v167, v168, v169, v170, v171, v172, v181)
let v183 : uint64 = 1UL
let v184 : int32 = 0
let v185 : int32 = method32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
let v186 : US0 = US0_0
let v187 : UH0 = UH0_2(v186)
let v188 : US0 = US0_1
let v189 : UH0 = UH0_2(v188)
let v190 : UH0 = UH0_3(v187, v189)
let v191 : UH0 = UH0_5(v190)
let v192 : US0 = US0_1
let v193 : UH0 = UH0_2(v192)
let v194 : US0 = US0_0
let v195 : UH0 = UH0_2(v194)
let v196 : US0 = US0_1
let v197 : UH0 = UH0_2(v196)
let v198 : UH0 = UH0_3(v195, v197)
let v199 : US0 = US0_0
let v200 : UH0 = UH0_2(v199)
let v201 : US0 = US0_1
let v202 : UH0 = UH0_2(v201)
let v203 : UH0 = UH0_3(v200, v202)
let v204 : US0 = US0_0
let v205 : UH0 = UH0_2(v204)
let v206 : US0 = US0_1
let v207 : UH0 = UH0_2(v206)
let v208 : UH0 = UH0_3(v205, v207)
let v209 : UH0 = UH0_4(v203, v208)
let v210 : UH0 = UH0_4(v198, v209)
let v211 : UH0 = UH0_4(v193, v210)
let v212 : UH0 = UH0_4(v191, v211)
let v213 : int32 = method28(v166, v167, v168, v169, v170, v171, v172, v212)
let v214 : uint64 = 1UL
let v215 : int32 = 0
let v216 : int32 = method32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
let v217 : int32 = 16
let v218 : (int32 []) = Array.zeroCreate<int32> (4096)
let v219 : (int32 []) = Array.zeroCreate<int32> (4096)
let v220 : (int32 []) = Array.zeroCreate<int32> (4096)
let v221 : (int32 []) = Array.zeroCreate<int32> (4096)
let v222 : (int32 []) = Array.zeroCreate<int32> (8192)
let v223 : (int32 []) = Array.zeroCreate<int32> (8192)
let v224 : (int32 []) = Array.zeroCreate<int32> (1)
let v225 : int32 = 0
method24(v222, v225)
let v226 : int32 = 0
method24(v223, v226)
let v227 : int32 = 0
method25(v224, v227)
let v228 : int32 = 0
let v229 : int32 = 0
let v230 : int32 = 0
let v231 : int32 = method26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
let v232 : int32 = 1
let v233 : int32 = 0
let v234 : int32 = 0
let v235 : int32 = method26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
let v236 : bool = v231 = 0
let v238 : bool =
    if v236 then
        let v237 : bool = v235 = 1
        v237
    else
        false
let struct (v246 : (int32 []), v247 : (int32 []), v248 : (int32 []), v249 : (int32 []), v250 : (int32 []), v251 : (int32 []), v252 : (int32 [])) =
    if v238 then
        struct (v218, v219, v220, v221, v222, v223, v224)
    else
        failwith<struct ((int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []) * (int32 []))> "brzozowski-interned-store-init"
let v253 : US0 = US0_0
let v254 : UH0 = UH0_2(v253)
let v255 : US0 = US0_0
let v256 : UH0 = UH0_2(v255)
let v257 : US0 = US0_0
let v258 : UH0 = UH0_2(v257)
let v259 : UH0 = UH0_4(v256, v258)
let v260 : UH0 = UH0_3(v254, v259)
let v261 : UH0 = UH0_5(v260)
let v262 : US0 = US0_1
let v263 : UH0 = UH0_2(v262)
let v264 : UH0 = UH0_4(v261, v263)
let v265 : int32 = method28(v246, v247, v248, v249, v250, v251, v252, v264)
let v266 : int32 = 1
let v267 : int32 = 0
let v268 : int32 = method36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
let v269 : bool = v40 = v185
let v271 : bool =
    if v269 then
        let v270 : bool = v41 = v216
        v270
    else
        false
let v273 : bool =
    if v271 then
        let v272 : bool = v57 = v268
        v272
    else
        false
if v273 then
    ()
else
    failwith<unit> "brzozowski-bench-engines-disagree"
let v274 : bool = v57 = 16
if v274 then
    ()
else
    failwith<unit> "brzozowski-bench-zero-runs-count"
let v275 : bool = v40 = 93
if v275 then
    ()
else
    failwith<unit> "brzozowski-bench-ends-with-zero-count"
let v276 : bool = v41 = 97
if v276 then
    ()
else
    failwith<unit> "brzozowski-bench-fourth-from-end-count"
0
