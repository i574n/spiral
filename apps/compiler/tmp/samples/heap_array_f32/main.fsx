type Heap0 = {l0 : (float32 []); l1 : int32}
let v0 : (float32 []) = Array.zeroCreate<float32> (1)
let v1 : float32 = 1.5f
v0.[int 0] <- v1
let v2 : int32 = 7
let v3 : Heap0 = {l0 = v0; l1 = v2} : Heap0
let struct (v4 : (float32 []), v5 : int32) = v3.l0, v3.l1
let v6 : float32 = v4.[int 0]
let v7 : bool = v6 = 1.5f
let v9 : bool =
    if v7 then
        let v8 : bool = v5 = 7
        v8
    else
        false
if v9 then
    0
else
    1
