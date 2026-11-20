type Heap0 = {l0 : int32; l1 : string}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap0 * f1_1 : Heap0 * f1_2 : Heap0
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1, v2, v3) -> (* Held *)
        let struct (v4 : int32, v5 : string) = v1.l0, v1.l1
        let struct (v6 : int32, v7 : string) = v2.l0, v2.l1
        let struct (v8 : int32, v9 : string) = v3.l0, v3.l1
        let v10 : bool = v4 = 7
        let v12 : bool =
            if v10 then
                let v11 : bool = v5 = "hi"
                v11
            else
                false
        let v14 : bool =
            if v12 then
                let v13 : bool = v6 = 4
                v13
            else
                false
        let v16 : bool =
            if v14 then
                let v15 : bool = v7 = "yo"
                v15
            else
                false
        let v18 : bool =
            if v16 then
                let v17 : bool = v8 = 9
                v17
            else
                false
        let v20 : bool =
            if v18 then
                let v19 : bool = v9 = "ok"
                v19
            else
                false
        if v20 then
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
let v6 : int32 = 9
let v7 : string = "ok"
let v8 : Heap0 = {l0 = v6; l1 = v7} : Heap0
let v9 : (US0 []) = Array.zeroCreate<US0> (1)
let v10 : bool = true
let v13 : US0 =
    if v10 then
        US0_Held(v2, v5, v8)
    else
        US0_None
v9.[int 0] <- v13
let v14 : US0 = v9.[int 0]
score_0(v14)
