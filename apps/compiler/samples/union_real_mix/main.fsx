type [<Struct>] US0 =
    | US0_None
    | US0_Both of f1_0 : float * f1_1 : int32
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Both(v1, v2) -> (* Both *)
        let v3 : bool = v1 = 1.5
        let v5 : bool =
            if v3 then
                let v4 : bool = v2 = 7
                v4
            else
                false
        if v5 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : float = 1.5
let v1 : int32 = 7
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Both(v0, v1)
    else
        US0_None
score_0(v5)
