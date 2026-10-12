type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and Heap2 = {l0 : Heap1; l1 : int32}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : int32 = 2
let v6 : Heap2 = {l0 = v4; l1 = v5} : Heap2
let v7 : (Heap2 []) = Array.zeroCreate<Heap2> (1)
v7.[int 0] <- v6
let v8 : Heap2 = v7.[int 0]
let struct (v9 : Heap1, v10 : int32) = v8.l0, v8.l1
let struct (v11 : Heap0, v12 : int32) = v9.l0, v9.l1
let struct (v13 : int32, v14 : string) = v11.l0, v11.l1
let v15 : bool = v13 = 7
let v17 : bool =
    if v15 then
        let v16 : bool = v14 = "hi"
        v16
    else
        false
let v19 : bool =
    if v17 then
        let v18 : bool = v12 = 1
        v18
    else
        false
let v21 : bool =
    if v19 then
        let v20 : bool = v10 = 2
        v20
    else
        false
if v21 then
    0
else
    1
