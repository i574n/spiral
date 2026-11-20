type Heap0 = {l0 : (string [])}
let v0 : (string []) = Array.zeroCreate<string> (1)
let v1 : string = "hi"
v0.[int 0] <- v1
let v2 : Heap0 = {l0 = v0} : Heap0
let v3 : (string []) = v2.l0
let v4 : string = v3.[int 0]
let v5 : bool = v4 = "hi"
if v5 then
    0
else
    1
