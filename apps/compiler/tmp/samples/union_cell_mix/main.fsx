type Heap0 = {l0 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap0 * f1_1 : int32
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1, v2) -> (* Held *)
        let v3 : int32 = v1.l0
        let v4 : int32 = v3 + v2
        let v5 : bool = v4 = 7
        if v5 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v0} : Heap0
let v3 : bool = true
let v6 : US0 =
    if v3 then
        US0_Held(v2, v1)
    else
        US0_None
score_0(v6)
