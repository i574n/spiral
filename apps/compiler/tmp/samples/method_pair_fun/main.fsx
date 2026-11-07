let rec left_c0 (v0 : int32) (v1 : int32) : int32 =
    let v2 : bool = v0 = 0
    if v2 then
        0
    else
        let v3 : int32 = v1 + v0
        v3
and right_c1 (v0 : int32) (v1 : int32) : int32 =
    let v2 : bool = v0 = 0
    if v2 then
        0
    else
        let v3 : int32 = v1 + v0
        v3
and method0 (v0 : int32, v1 : int32) : struct ((int32 -> int32) * (int32 -> int32)) =
    let v2 : (int32 -> int32) = left_c0(v0)
    let v3 : (int32 -> int32) = right_c1(v1)
    struct (v2, v3)
let v0 : int32 = 3
let v1 : int32 = 4
let struct (v2 : (int32 -> int32), v3 : (int32 -> int32)) = method0(v0, v1)
let v4 : int32 = v2 0
let v5 : int32 = v3 0
let v6 : int32 = v4 + v5
let v7 : bool = v6 = 7
if v7 then
    0
else
    1
