type Heap0 = {l0 : int32}
let rec method0 (v0 : Heap0) : Heap0 =
    v0
let v0 : int32 = 7
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : Heap0 = method0(v1)
let v3 : int32 = v2.l0
let v4 : bool = v3 = 7
if v4 then
    0
else
    1
