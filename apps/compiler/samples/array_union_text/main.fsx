type [<Struct>] US0 =
    | US0_None
    | US0_Both of f1_0 : string * f1_1 : string
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Both(v1, v2) -> (* Both *)
        let v3 : bool = v1 = "hi"
        let v5 : bool =
            if v3 then
                let v4 : bool = v2 = "yo"
                v4
            else
                false
        if v5 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : (US0 []) = Array.zeroCreate<US0> (1)
let v1 : string = "hi"
let v2 : string = "yo"
let v3 : bool = true
let v6 : US0 =
    if v3 then
        US0_Both(v1, v2)
    else
        US0_None
v0.[int 0] <- v6
let v7 : US0 = v0.[int 0]
score_0(v7)
