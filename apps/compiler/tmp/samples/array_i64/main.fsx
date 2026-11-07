let v0 : (int64 []) = Array.zeroCreate<int64> (1)
let v1 : int64 = 5000000000L
v0.[int 0] <- v1
let v2 : int64 = v0.[int 0]
let v3 : bool = v2 = 5000000000L
if v3 then
    0
else
    1
