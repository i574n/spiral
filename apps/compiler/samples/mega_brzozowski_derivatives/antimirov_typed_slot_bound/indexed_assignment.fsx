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
let v10 : string = "brzozowski-antimirov-indexed-slot-alignment-green"
v10
