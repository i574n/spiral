type [<Struct>] US0 =
    | US0_One of f0_0 : int32
    | US0_Both of f1_0 : int32 * f1_1 : string
let rec method0 (v0 : int32, v1 : string) : US0 =
    let v2 : bool = v0 = 0
    if v2 then
        US0_One(0)
    else
        US0_Both(v0, v1)
let v0 : int32 = 3
let v1 : string = "hi"
let v2 : US0 = method0(v0, v1)
match v2 with
| US0_Both(v4, v5) -> (* Both *)
    let v6 : bool = v4 = 3
    let v8 : bool =
        if v6 then
            let v7 : bool = v5 = "hi"
            v7
        else
            false
    if v8 then
        0
    else
        1
| US0_One(v3) -> (* One *)
    1
