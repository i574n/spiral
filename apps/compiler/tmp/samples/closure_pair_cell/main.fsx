type Heap0 = {l0 : int32}
let rec f_c0 (v0 : int32, v1 : Heap0) (v2 : int32) : struct (Heap0 * int32) =
    let v3 : bool = v2 = 0
    if v3 then
        struct (v1, 0)
    else
        struct (v1, v0)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v0} : Heap0
let v3 : (int32 -> struct (Heap0 * int32)) = f_c0(v1, v2)
let struct (v4 : Heap0, v5 : int32) = v3 1
let v6 : int32 = v4.l0
let v7 : int32 = v6 + v5
let v8 : bool = v7 = 7
if v8 then
    0
else
    1
