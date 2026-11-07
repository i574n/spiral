let v0 : (uint64 []) = Array.zeroCreate<uint64> (1)
let v1 : uint64 = 4294967297UL
v0.[int 0] <- v1
let v2 : uint64 = v0.[int 0]
let v3 : bool = v2 = 4294967297UL
if v3 then
    0
else
    1
