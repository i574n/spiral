let v0 : int32 = 3
let v1 : (uint32 []) = Array.zeroCreate<uint32> (v0)
v1.[int 0] <- 4000000000u
v1.[int 1] <- 1u
let v2 : uint32 = v1.[int 0]
let v3 : uint32 = v1.[int 1]
let v4 : uint32 = v2 + v3
let v5 : int32 = v1.Length
let v6 : bool = v5 = v0
let v8 : bool =
    if v6 then
        let v7 : bool = v4 = 4000000001u
        v7
    else
        false
if v8 then
    0
else
    1
