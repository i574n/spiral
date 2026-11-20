type Heap0 = {l0 : int32}
let v0 : int32 = 2
let v1 : (Heap0 []) = Array.zeroCreate<Heap0> (v0)
let v2 : int32 = 4
let v3 : int32 = 6
let v4 : Heap0 = {l0 = v2} : Heap0
v1.[int 0] <- v4
let v5 : Heap0 = {l0 = v3} : Heap0
v1.[int 1] <- v5
let v6 : Heap0 = v1.[int 0]
let v7 : int32 = v6.l0
let v8 : Heap0 = v1.[int 1]
let v9 : int32 = v8.l0
let v10 : int32 = v7 + v9
let v11 : bool = v10 = 10
if v11 then
    0
else
    1
