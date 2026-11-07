type Heap0 = {l0 : (float [])}
let v0 : (float []) = Array.zeroCreate<float> (1)
let v1 : float = 1.5
v0.[int 0] <- v1
let v2 : Heap0 = {l0 = v0} : Heap0
let v3 : (float []) = v2.l0
let v4 : float = v3.[int 0]
let v5 : bool = v4 = 1.5
if v5 then
    0
else
    1
