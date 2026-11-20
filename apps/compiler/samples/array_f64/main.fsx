let v0 : int32 = 2
let v1 : (float []) = Array.zeroCreate<float> (v0)
let v2 : float = 1.5
v1.[int 0] <- v2
v1.[int 1] <- 2.5
let v3 : float = v1.[int 0]
let v4 : bool = v3 = 1.5
if v4 then
    0
else
    1
