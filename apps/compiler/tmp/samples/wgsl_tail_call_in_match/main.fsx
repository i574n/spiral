type [<Struct>] US0 =
    | US0_Done of f0_0 : int32
    | US0_More of f1_0 : int32
let rec layers_0 (v0 : int32) : int32 =
    let v1 : bool = v0 >= 5
    let v4 : US0 =
        if v1 then
            US0_Done(v0)
        else
            US0_More(v0)
    match v4 with
    | US0_Done(v8) -> (* Done *)
        let v9 : int32 = v8 * 2
        v9
    | US0_More(v5) -> (* More *)
        let v6 : int32 = v5 + 1
        layers_0(v6)
let v0 : int32 = 0
layers_0(v0)
