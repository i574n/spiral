type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0; l2 : Heap0}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : int32 = 9
let v7 : string = "ok"
let v8 : Heap0 = {l0 = v6; l1 = v7} : Heap0
let v9 : Heap1 = {l0 = v2; l1 = v5; l2 = v8} : Heap1
let v10 : (Heap1 []) = Array.zeroCreate<Heap1> (1)
v10.[int 0] <- v9
let v11 : Heap1 = v10.[int 0]
let struct (v12 : Heap0, v13 : Heap0, v14 : Heap0) = v11.l0, v11.l1, v11.l2
let struct (v15 : int32, v16 : string) = v12.l0, v12.l1
let struct (v17 : int32, v18 : string) = v13.l0, v13.l1
let struct (v19 : int32, v20 : string) = v14.l0, v14.l1
let v21 : bool = v15 = 7
let v23 : bool =
    if v21 then
        let v22 : bool = v16 = "hi"
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v17 = 4
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = v18 = "yo"
        v26
    else
        false
let v29 : bool =
    if v27 then
        let v28 : bool = v19 = 9
        v28
    else
        false
let v31 : bool =
    if v29 then
        let v30 : bool = v20 = "ok"
        v30
    else
        false
if v31 then
    0
else
    1
