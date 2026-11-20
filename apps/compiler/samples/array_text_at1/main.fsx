let v0 : (string []) = Array.zeroCreate<string> (2)
let v1 : string = "hi"
v0.[int 1] <- v1
let v2 : string = v0.[int 1]
let v3 : bool = v2 = "hi"
if v3 then
    0
else
    1
