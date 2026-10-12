type [<Struct>] US0 =
    | US0_Circle of f0_0 : int32
    | US0_Square of f1_0 : int32
    | US0_Tri of f2_0 : int32
    | US0_Dot
let rec pick_0 (v0 : int32) : US0 =
    let v1 : bool = v0 = 0
    if v1 then
        US0_Circle(5)
    else
        let v3 : bool = v0 = 1
        if v3 then
            US0_Square(4)
        else
            let v5 : bool = v0 = 2
            if v5 then
                US0_Tri(7)
            else
                US0_Dot
and measure_1 (v0 : US0, v1 : int32) : int32 =
    match v0 with
    | US0_Circle(v2) -> (* Circle *)
        let v3 : int32 = v2 * 3
        v3
    | _ ->
        let v4 : int32 = v1 * v1
        let v5 : bool = v4 > 3
        match v0 with
        | US0_Dot -> (* Dot *)
            v4
        | US0_Square(v6) -> (* Square *)
            if v5 then
                let v7 : int32 = v6 * v6
                v7
            else
                v6
        | US0_Tri(v9) -> (* Tri *)
            if v5 then
                let v10 : int32 = v9 * 2
                v10
            else
                v9
and measure_tri_2 (v0 : US0, v1 : int32) : int32 =
    match v0 with
    | US0_Circle(v2) -> (* Circle *)
        v2
    | US0_Dot -> (* Dot *)
        0
    | US0_Square(v3) -> (* Square *)
        v3
    | _ ->
        let v4 : int32 = v1 + 2
        match v0 with
        | US0_Tri(v5) -> (* Tri *)
            let v6 : int32 = v5 * v4
            v6
let v0 : int32 = 0
let v1 : US0 = pick_0(v0)
let v2 : int32 = measure_1(v1, v0)
let v3 : int32 = v0 + 1
let v4 : US0 = pick_0(v3)
let v5 : int32 = measure_1(v4, v3)
let v6 : int32 = v2 + v5
let v7 : int32 = v0 + 2
let v8 : US0 = pick_0(v7)
let v9 : int32 = measure_1(v8, v7)
let v10 : int32 = v6 + v9
let v11 : int32 = v0 + 3
let v12 : US0 = pick_0(v11)
let v13 : int32 = measure_1(v12, v11)
let v14 : int32 = v10 + v13
let v15 : US0 = pick_0(v7)
let v16 : int32 = measure_tri_2(v15, v0)
let v17 : int32 = v14 + v16
let v18 : US0 = pick_0(v0)
let v19 : int32 = measure_tri_2(v18, v0)
let v20 : int32 = v17 + v19
v20
