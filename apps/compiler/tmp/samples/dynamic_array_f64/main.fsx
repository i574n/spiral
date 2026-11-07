let v0 : int32 = 2
let v1 : (float []) = Array.zeroCreate<float> (v0)
v1.[int 0] <- 1.5
v1.[int 1] <- 2.5
let v2 : int32 = 1
let v3 : float = v1.[int v2]
let v4 : bool = v3 >= 2.0
if v4 then
    0
else
    1
