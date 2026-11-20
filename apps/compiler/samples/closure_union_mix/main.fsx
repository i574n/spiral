type [<Struct>] US0 =
    | US0_One of f0_0 : int32
    | US0_Both of f1_0 : int32 * f1_1 : string
let rec f_c0 (v0 : int32, v1 : string) (v2 : int32) : US0 =
    let v3 : bool = v2 = 0
    if v3 then
        US0_One(0)
    else
        US0_Both(v0, v1)
let v0 : int32 = 3
let v1 : string = "hi"
let v2 : (int32 -> US0) = f_c0(v0, v1)
let v3 : US0 = v2 1
match v3 with
| US0_Both(v5, v6) -> (* Both *)
    let v7 : bool = v5 = 3
    let v9 : bool =
        if v7 then
            let v8 : bool = v6 = "hi"
            v8
        else
            false
    if v9 then
        0
    else
        1
| US0_One(v4) -> (* One *)
    1
