type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
and Heap2 = {l0 : Heap1; l1 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap2
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1) -> (* Held *)
        let struct (v2 : Heap1, v3 : int32) = v1.l0, v1.l1
        let struct (v4 : Heap0, v5 : Heap0) = v2.l0, v2.l1
        let struct (v6 : int32, v7 : string) = v4.l0, v4.l1
        let struct (v8 : int32, v9 : string) = v5.l0, v5.l1
        let v10 : bool = v6 = 7
        let v12 : bool =
            if v10 then
                let v11 : bool = v7 = "hi"
                v11
            else
                false
        let v14 : bool =
            if v12 then
                let v13 : bool = v8 = 4
                v13
            else
                false
        let v16 : bool =
            if v14 then
                let v15 : bool = v9 = "yo"
                v15
            else
                false
        let v18 : bool =
            if v16 then
                let v17 : bool = v3 = 2
                v17
            else
                false
        if v18 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let v7 : int32 = 2
let v8 : Heap2 = {l0 = v6; l1 = v7} : Heap2
let v9 : bool = true
let v12 : US0 =
    if v9 then
        US0_Held(v8)
    else
        US0_None
score_0(v12)
