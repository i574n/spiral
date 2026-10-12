type Heap0 = {l0 : int32; l1 : string}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap0 * f1_1 : Heap0
let rec f_c0 (v0 : Heap0, v1 : Heap0) (v2 : int32) : US0 =
    let v3 : bool = v2 = 0
    if v3 then
        US0_None
    else
        US0_Held(v0, v1)
and score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Held(v1, v2) -> (* Held *)
        let struct (v3 : int32, v4 : string) = v1.l0, v1.l1
        let struct (v5 : int32, v6 : string) = v2.l0, v2.l1
        let v7 : bool = v3 = 7
        let v9 : bool =
            if v7 then
                let v8 : bool = v4 = "hi"
                v8
            else
                false
        let v11 : bool =
            if v9 then
                let v10 : bool = v5 = 4
                v10
            else
                false
        let v13 : bool =
            if v11 then
                let v12 : bool = v6 = "yo"
                v12
            else
                false
        if v13 then
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
let v6 : (int32 -> US0) = f_c0(v2, v5)
let v7 : US0 = v6 1
score_0(v7)
