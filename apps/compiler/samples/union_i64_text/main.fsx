type [<Struct>] US0 =
    | US0_None
    | US0_Both of f1_0 : int64 * f1_1 : string
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Both(v1, v2) -> (* Both *)
        let v3 : bool = v1 = 5000000000L
        let v5 : bool =
            if v3 then
                let v4 : bool = v2 = "hi"
                v4
            else
                false
        if v5 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : int64 = 5000000000L
let v1 : string = "hi"
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Both(v0, v1)
    else
        US0_None
score_0(v5)
