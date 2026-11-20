type Heap0 = {l0 : int32; l1 : string}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : (Heap0 []) = Array.zeroCreate<Heap0> (1)
v3.[int 0] <- v2
let v4 : Heap0 = v3.[int 0]
let struct (v5 : int32, v6 : string) = v4.l0, v4.l1
let v7 : bool = v5 = 7
let v9 : bool =
    if v7 then
        let v8 : bool = v6 = "hi"
        v8
    else
        false
if v9 then
    0
else
    1
