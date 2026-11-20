type Heap0 = {l0 : string; l1 : string}
let v0 : string = "hi"
let v1 : Heap0 = {l0 = v0; l1 = v0} : Heap0
let struct (v2 : string, v3 : string) = v1.l0, v1.l1
let v4 : bool = v2 = v3
if v4 then
    0
else
    1
