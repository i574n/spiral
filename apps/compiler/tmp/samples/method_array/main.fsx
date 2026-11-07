let rec method0 (v0 : int32) : (int32 []) =
    let v1 : (int32 []) = Array.zeroCreate<int32> (1)
    v1.[int 0] <- v0
    v1
let v0 : int32 = 7
let v1 : (int32 []) = method0(v0)
let v2 : int32 = v1.[int 0]
let v3 : bool = v2 = 7
if v3 then
    0
else
    1
