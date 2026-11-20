type Heap0 = {l0 : int32}
let rec g_c1 (v0 : Heap0, v1 : int32) (v2 : int32) : int32 =
    let v3 : int32 = v0.l0
    let v4 : bool = v1 = 0
    if v4 then
        0
    else
        v3
and f_c0 (v0 : Heap0) (v1 : int32) : (int32 -> int32) =
    g_c1(v0, v1)
let v0 : int32 = 7
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : (int32 -> (int32 -> int32)) = f_c0(v1)
let v3 : (int32 -> int32) = v2 1
let v4 : int32 = v3 0
let v5 : bool = v4 = 7
if v5 then
    0
else
    1
