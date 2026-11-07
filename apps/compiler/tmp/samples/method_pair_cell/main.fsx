type Heap0 = {l0 : int32}
let rec method0 (v0 : int32, v1 : Heap0) : struct (Heap0 * int32) =
    struct (v1, v0)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v0} : Heap0
let struct (v3 : Heap0, v4 : int32) = method0(v1, v2)
let v5 : int32 = v3.l0
let v6 : int32 = v5 + v4
let v7 : bool = v6 = 7
if v7 then
    0
else
    1
