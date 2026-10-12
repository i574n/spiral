type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap1
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1) -> (* Held *)
        let struct (v2 : Heap0, v3 : int32) = v1.l0, v1.l1
        let struct (v4 : int32, v5 : string) = v2.l0, v2.l1
        let v6 : bool = v4 = 7
        let v8 : bool =
            if v6 then
                let v7 : bool = v5 = "hi"
                v7
            else
                false
        let v10 : bool =
            if v8 then
                let v9 : bool = v3 = 1
                v9
            else
                false
        if v10 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : bool = true
let v8 : US0 =
    if v5 then
        US0_Held(v4)
    else
        US0_None
score_0(v8)
