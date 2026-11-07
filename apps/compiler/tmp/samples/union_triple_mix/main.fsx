type [<Struct>] US0 =
    | US0_One of f0_0 : int32
    | US0_All of f1_0 : int32 * f1_1 : string * f1_2 : bool
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_All(v2, v3, v4) -> (* All *)
        let v5 : bool = v2 = 7
        let v7 : bool =
            if v5 then
                let v6 : bool = v3 = "hi"
                v6
            else
                false
        let v8 : bool = v7 && v4
        if v8 then
            0
        else
            1
    | US0_One(v1) -> (* One *)
        v1
let v0 : bool = true
let v1 : int32 = 7
let v2 : string = "hi"
let v3 : bool = true
let v6 : US0 =
    if v0 then
        US0_All(v1, v2, v3)
    else
        US0_One(1)
score_0(v6)
