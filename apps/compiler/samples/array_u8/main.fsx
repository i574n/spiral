let v0 : (uint8 []) = Array.zeroCreate<uint8> (1)
let v1 : uint8 = 200uy
v0.[int 0] <- v1
let v2 : uint8 = v0.[int 0]
let v3 : bool = v2 = 200uy
if v3 then
    0
else
    1
