type Heap0 = {l0 : (int32 [])}
let v0 : int32 = 2
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
let v2 : int32 = 7
v1.[int 0] <- v2
let v3 : Heap0 = {l0 = v1} : Heap0
let v4 : (int32 []) = v3.l0
let v5 : int32 = v4.[int 0]
let v6 : bool = v5 = 7
if v6 then
    0
else
    1
