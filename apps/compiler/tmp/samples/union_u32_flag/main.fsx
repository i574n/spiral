type [<Struct>] US0 =
    | US0_None
    | US0_All of f1_0 : uint32 * f1_1 : string * f1_2 : bool
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_All(v1, v2, v3) -> (* All *)
        let v4 : bool = v1 = 4000000000u
        let v6 : bool =
            if v4 then
                let v5 : bool = v2 = "hi"
                v5
            else
                false
        let v7 : bool = v6 && v3
        if v7 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : uint32 = 4000000000u
let v1 : string = "hi"
let v2 : bool = true
let v3 : bool = true
let v6 : US0 =
    if v3 then
        US0_All(v0, v1, v2)
    else
        US0_None
score_0(v6)
