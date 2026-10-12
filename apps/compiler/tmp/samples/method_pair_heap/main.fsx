type Heap0 = {l0 : int32}
let rec method0 (v0 : Heap0, v1 : Heap0) : struct (Heap0 * Heap0) =
    struct (v0, v1)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v0} : Heap0
let v3 : Heap0 = {l0 = v1} : Heap0
let struct (v4 : Heap0, v5 : Heap0) = method0(v2, v3)
let v6 : int32 = v4.l0
let v7 : int32 = v5.l0
let v8 : int32 = v6 + v7
let v9 : bool = v8 = 7
if v9 then
    0
else
    1
