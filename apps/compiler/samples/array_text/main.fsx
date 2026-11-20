let v0 : int32 = 2
let v1 : (string []) = Array.zeroCreate<string> (v0)
let v2 : string = "hi"
v1.[int 0] <- v2
let v3 : string = "yo"
v1.[int 1] <- v3
let v4 : string = v1.[int 0]
let v5 : bool = v4 = "hi"
if v5 then
    0
else
    1
