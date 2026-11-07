type Heap0 = {l0 : int32; l1 : string}
let rec f_c0 (v0 : Heap0, v1 : Heap0, v2 : Heap0) (v3 : int32) : struct (Heap0 * Heap0 * Heap0) =
    let v4 : bool = v3 = 0
    struct (v0, v1, v2)
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : int32 = 9
let v7 : string = "ok"
let v8 : Heap0 = {l0 = v6; l1 = v7} : Heap0
let v9 : (int32 -> struct (Heap0 * Heap0 * Heap0)) = f_c0(v2, v5, v8)
let struct (v10 : Heap0, v11 : Heap0, v12 : Heap0) = v9 1
let struct (v13 : int32, v14 : string) = v10.l0, v10.l1
let struct (v15 : int32, v16 : string) = v11.l0, v11.l1
let struct (v17 : int32, v18 : string) = v12.l0, v12.l1
let v19 : bool = v13 = 7
let v21 : bool =
    if v19 then
        let v20 : bool = v14 = "hi"
        v20
    else
        false
let v23 : bool =
    if v21 then
        let v22 : bool = v15 = 4
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v16 = "yo"
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = v17 = 9
        v26
    else
        false
let v29 : bool =
    if v27 then
        let v28 : bool = v18 = "ok"
        v28
    else
        false
if v29 then
    0
else
    1
