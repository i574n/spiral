let v0 : (uint16 []) = Array.zeroCreate<uint16> (1)
let v1 : uint16 = 40000us
v0.[int 0] <- v1
let v2 : uint16 = v0.[int 0]
let v3 : bool = v2 = 40000us
if v3 then
    0
else
    1
