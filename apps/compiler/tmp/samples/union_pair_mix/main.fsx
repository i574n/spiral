type [<Struct>] US0 =
    | US0_One of f0_0 : int32
    | US0_Both of f1_0 : int32 * f1_1 : string
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Both(v2, v3) -> (* Both *)
        let v4 : bool = v2 = 3
        let v6 : bool =
            if v4 then
                let v5 : bool = v3 = "hi"
                v5
            else
                false
        if v6 then
            0
        else
            1
    | US0_One(v1) -> (* One *)
        v1
let v0 : bool = true
let v1 : int32 = 3
let v2 : string = "hi"
let v5 : US0 =
    if v0 then
        US0_Both(v1, v2)
    else
        US0_One(1)
score_0(v5)
