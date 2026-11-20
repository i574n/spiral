type Heap0 = {l0 : (int32 -> int32); l1 : int32}
let rec add_c0 (v0 : int32) (v1 : int32) : int32 =
    let v2 : int32 = v1 + v0
    v2
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : (int32 -> int32) = add_c0(v0)
let v3 : Heap0 = {l0 = v2; l1 = v1} : Heap0
let struct (v4 : (int32 -> int32), v5 : int32) = v3.l0, v3.l1
let v6 : int32 = v4 0
let v7 : int32 = v6 + v5
let v8 : bool = v7 = 7
if v8 then
    0
else
    1
