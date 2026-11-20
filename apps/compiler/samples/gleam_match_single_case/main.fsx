type [<Struct>] US0 =
    | US0_Step of f0_0 : int32 * f0_1 : int32 * f0_2 : int32
let rec walk_0 (v0 : int32) : int32 =
    let v1 : bool = v0 > 2
    let v6 : US0 =
        if v1 then
            let v2 : int32 = v0 + 1
            let v3 : int32 = v0 + 2
            US0_Step(v0, v2, v3)
        else
            US0_Step(0, 1, 2)
    match v6 with
    | US0_Step(v7, v8, v9) -> (* Step *)
        let v10 : int32 = v8 * v9
        let v11 : int32 = v7 + v10
        v11
let v0 : int32 = 5
let v1 : int32 = walk_0(v0)
let v2 : int32 = v0 - 4
let v3 : int32 = walk_0(v2)
let v4 : int32 = v1 + v3
v4
