type Heap0 = {l0 : int32; l1 : int32}
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let struct (v3 : int32, v4 : int32) = v2.l0, v2.l1
let v5 : int32 = v3 + v4
let v6 : bool = v5 = 7
if v6 then
    0
else
    1
