type [<Struct>] US0 =
    | US0_Vowel of f0_0 : int32
and UH0 =
    | UH0_Nil
    | UH0_Cons of US0 * UH0
let rec method0 (v0 : UH0, v1 : UH0) : bool =
    match v1, v0 with
    | UH0_Cons(v2, v3), UH0_Cons(v4, v5) -> (* Cons *)
        let v9 : bool =
            match v2, v4 with
            | US0_Vowel(v6), US0_Vowel(v7) -> (* Vowel *)
                let v8 : bool = v6 = v7
                v8
            | _ ->
                false
        if v9 then
            method0(v5, v3)
        else
            false
    | UH0_Nil, UH0_Nil -> (* Nil *)
        true
    | _ ->
        false
let v0 : int32 = 1
let v1 : US0 = US0_Vowel(v0)
let v2 : int32 = 1
let v3 : US0 = US0_Vowel(v2)
let v4 : int32 = 2
let v5 : US0 = US0_Vowel(v4)
let v6 : UH0 = UH0_Nil
let v7 : UH0 = UH0_Cons(v5, v6)
let v8 : UH0 = UH0_Cons(v1, v7)
let v9 : UH0 = UH0_Nil
let v10 : UH0 = UH0_Cons(v5, v9)
let v11 : UH0 = UH0_Cons(v3, v10)
let v12 : UH0 = UH0_Nil
let v13 : UH0 = UH0_Cons(v1, v12)
let v17 : bool =
    match v1, v3 with
    | US0_Vowel(v14), US0_Vowel(v15) -> (* Vowel *)
        let v16 : bool = v14 = v15
        v16
    | _ ->
        false
let v23 : bool =
    if v17 then
        let v21 : bool =
            match v1, v5 with
            | US0_Vowel(v18), US0_Vowel(v19) -> (* Vowel *)
                let v20 : bool = v18 = v19
                v20
            | _ ->
                false
        let v22 : bool = v21 = false
        v22
    else
        false
let v30 : bool =
    if v23 then
        let v27 : bool =
            match v1, v3 with
            | US0_Vowel(v24), US0_Vowel(v25) -> (* Vowel *)
                let v26 : bool = v24 = v25
                v26
            | _ ->
                false
        if v27 then
            method0(v11, v8)
        else
            false
    else
        false
let v38 : bool =
    if v30 then
        let v34 : bool =
            match v1, v5 with
            | US0_Vowel(v31), US0_Vowel(v32) -> (* Vowel *)
                let v33 : bool = v31 = v32
                v33
            | _ ->
                false
        let v36 : bool =
            if v34 then
                method0(v13, v8)
            else
                false
        let v37 : bool = v36 = false
        v37
    else
        false
if v38 then
    0
else
    1
