type Heap0 = {l0 : int32}
let rec f_c0 (v0 : Heap0, v1 : Heap0) (v2 : int32) : struct (Heap0 * Heap0) =
    let v3 : bool = v2 = 0
    if v3 then
        struct (v1, v0)
    else
        struct (v0, v1)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v0} : Heap0
let v3 : Heap0 = {l0 = v1} : Heap0
let v4 : (int32 -> struct (Heap0 * Heap0)) = f_c0(v2, v3)
let struct (v5 : Heap0, v6 : Heap0) = v4 1
let v7 : int32 = v5.l0
let v8 : int32 = v6.l0
let v9 : int32 = v7 + v8
let v10 : bool = v9 = 7
if v10 then
    0
else
    1
