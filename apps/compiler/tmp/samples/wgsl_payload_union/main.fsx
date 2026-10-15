type [<Struct>] US0 =
    | US0_Circle of f0_0 : int32
    | US0_Rect of f1_0 : int32 * f1_1 : int32
    | US0_Empty
let v0 : int32 = 2
let v1 : US0 = US0_Circle(v0)
let v2 : int32 = 3
let v3 : int32 = 4
let v4 : US0 = US0_Rect(v2, v3)
let v5 : US0 = US0_Empty
let v6 : int32 = 2
let v7 : US0 = US0_Circle(v6)
let v18 : bool =
    match v1, v7 with
    | US0_Circle(v8), US0_Circle(v9) -> (* Circle *)
        let v10 : bool = v8 = v9
        v10
    | US0_Empty, US0_Empty -> (* Empty *)
        true
    | US0_Rect(v11, v12), US0_Rect(v13, v14) -> (* Rect *)
        let v15 : bool = v11 = v13
        if v15 then
            let v16 : bool = v12 = v14
            v16
        else
            false
    | _ ->
        false
let v19 : int32 =
    if v18 then
        100
    else
        0
let v28 : int32 =
    match v1 with
    | US0_Circle(v20) -> (* Circle *)
        let v21 : int32 = 3 * v20
        let v22 : int32 = v21 * v20
        v22
    | US0_Empty -> (* Empty *)
        0
    | US0_Rect(v23, v24) -> (* Rect *)
        let v25 : int32 = v23 * v24
        v25
let v37 : int32 =
    match v4 with
    | US0_Circle(v29) -> (* Circle *)
        let v30 : int32 = 3 * v29
        let v31 : int32 = v30 * v29
        v31
    | US0_Empty -> (* Empty *)
        0
    | US0_Rect(v32, v33) -> (* Rect *)
        let v34 : int32 = v32 * v33
        v34
let v38 : int32 = v28 + v37
let v47 : int32 =
    match v5 with
    | US0_Circle(v39) -> (* Circle *)
        let v40 : int32 = 3 * v39
        let v41 : int32 = v40 * v39
        v41
    | US0_Empty -> (* Empty *)
        0
    | US0_Rect(v42, v43) -> (* Rect *)
        let v44 : int32 = v42 * v43
        v44
let v48 : int32 = v38 + v47
let v49 : int32 = v48 + v19
v49
