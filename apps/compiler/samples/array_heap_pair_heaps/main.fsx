type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let v7 : (Heap1 []) = Array.zeroCreate<Heap1> (1)
v7.[int 0] <- v6
let v8 : Heap1 = v7.[int 0]
let struct (v9 : Heap0, v10 : Heap0) = v8.l0, v8.l1
let struct (v11 : int32, v12 : string) = v9.l0, v9.l1
let struct (v13 : int32, v14 : string) = v10.l0, v10.l1
let v15 : bool = v11 = 7
let v17 : bool =
    if v15 then
        let v16 : bool = v12 = "hi"
        v16
    else
        false
let v19 : bool =
    if v17 then
        let v18 : bool = v13 = 4
        v18
    else
        false
let v21 : bool =
    if v19 then
        let v20 : bool = v14 = "yo"
        v20
    else
        false
if v21 then
    0
else
    1
