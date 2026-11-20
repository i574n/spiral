let v0 : (int8 []) = Array.zeroCreate<int8> (1)
let v1 : int8 = 100y
v0.[int 0] <- v1
let v2 : int8 = v0.[int 0]
let v3 : bool = v2 = 100y
if v3 then
    0
else
    1
