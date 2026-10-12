type [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : (string []) * f1_1 : bool
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1, v2) -> (* Held *)
        let v3 : string = v1.[int 0]
        let v4 : bool = v3 = "hi"
        let v5 : bool = v4 && v2
        if v5 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : (string []) = Array.zeroCreate<string> (1)
let v1 : string = "hi"
v0.[int 0] <- v1
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Held(v0, v2)
    else
        US0_None
score_0(v5)
