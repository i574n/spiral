type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and Mut0 = {mutable l0 : Heap1}
let v0 : int32 = 3
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : Mut0 = {l0 = v4} : Mut0
let v6 : (Mut0 []) = Array.zeroCreate<Mut0> (1)
v6.[int 0] <- v5
let v7 : int32 = 7
let v8 : string = "hi"
let v9 : Heap0 = {l0 = v7; l1 = v8} : Heap0
let v10 : int32 = 4
let v11 : Heap1 = {l0 = v9; l1 = v10} : Heap1
let v12 : Mut0 = v6.[int 0]
v12.l0 <- v11
let v13 : Heap1 = v12.l0
let struct (v14 : Heap0, v15 : int32) = v13.l0, v13.l1
let struct (v16 : int32, v17 : string) = v14.l0, v14.l1
let v18 : bool = v16 = 7
let v20 : bool =
    if v18 then
        let v19 : bool = v17 = "hi"
        v19
    else
        false
let v22 : bool =
    if v20 then
        let v21 : bool = v15 = 4
        v21
    else
        false
if v22 then
    0
else
    1
