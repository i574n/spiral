let v0 : int32 = 2
let v1 : (bool []) = Array.zeroCreate<bool> (v0)
v1.[int 0] <- true
v1.[int 1] <- false
let v2 : int32 = 0
let v3 : bool = v1.[int v2]
if v3 then
    0
else
    1
