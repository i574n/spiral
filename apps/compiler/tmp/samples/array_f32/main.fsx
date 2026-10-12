let v0 : (float32 []) = Array.zeroCreate<float32> (1)
let v1 : float32 = 1.5f
v0.[int 0] <- v1
let v2 : float32 = v0.[int 0]
let v3 : bool = v2 = 1.5f
if v3 then
    0
else
    1
