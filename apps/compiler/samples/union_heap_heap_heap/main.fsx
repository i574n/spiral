type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and Heap2 = {l0 : Heap1; l1 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap2
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1) -> (* Held *)
        let struct (v2 : Heap1, v3 : int32) = v1.l0, v1.l1
        let struct (v4 : Heap0, v5 : int32) = v2.l0, v2.l1
        let struct (v6 : int32, v7 : string) = v4.l0, v4.l1
        let v8 : bool = v6 = 7
        let v10 : bool =
            if v8 then
                let v9 : bool = v7 = "hi"
                v9
            else
                false
        let v12 : bool =
            if v10 then
                let v11 : bool = v5 = 1
                v11
            else
                false
        let v14 : bool =
            if v12 then
                let v13 : bool = v3 = 2
                v13
            else
                false
        if v14 then
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
let v5 : int32 = 2
let v6 : Heap2 = {l0 = v4; l1 = v5} : Heap2
let v7 : bool = true
let v10 : US0 =
    if v7 then
        US0_Held(v6)
    else
        US0_None
score_0(v10)
