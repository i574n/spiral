type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap1
let rec f_c0 (v0 : Heap1) (v1 : int32) : US0 =
    let v2 : bool = v1 = 0
    if v2 then
        US0_None
    else
        US0_Held(v0)
and score_0 (v0 : US0) : int32 =
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
let v5 : (int32 -> US0) = f_c0(v4)
let v6 : US0 = v5 1
score_0(v6)
