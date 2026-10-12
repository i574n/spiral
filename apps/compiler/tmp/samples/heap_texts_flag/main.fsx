type Heap0 = {l0 : (string []); l1 : bool}
let v0 : (string []) = Array.zeroCreate<string> (1)
let v1 : string = "hi"
v0.[int 0] <- v1
let v2 : bool = true
let v3 : Heap0 = {l0 = v0; l1 = v2} : Heap0
let struct (v4 : (string []), v5 : bool) = v3.l0, v3.l1
let v6 : string = v4.[int 0]
let v7 : bool = v6 = "hi"
let v8 : bool = v7 && v5
if v8 then
    0
else
    1
