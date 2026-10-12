let v0 : (int16 []) = Array.zeroCreate<int16> (1)
let v1 : int16 = 20000s
v0.[int 0] <- v1
let v2 : int16 = v0.[int 0]
let v3 : bool = v2 = 20000s
if v3 then
    0
else
    1
