let v0 : (bool []) = Array.zeroCreate<bool> (1)
let v1 : bool = true
v0.[int 0] <- v1
let v2 : bool = v0.[int 0]
if v2 then
    0
else
    1
