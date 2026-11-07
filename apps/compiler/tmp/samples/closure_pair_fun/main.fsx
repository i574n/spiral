let rec right_c1 (v0 : int32, v1 : int32) (v2 : int32) : int32 =
    let v3 : bool = v1 = 0
    if v3 then
        0
    else
        let v4 : int32 = v2 + v0
        v4
and left_c2 (v0 : int32, v1 : int32) (v2 : int32) : int32 =
    let v3 : bool = v1 = 0
    if v3 then
        0
    else
        let v4 : int32 = v2 + v0
        v4
and f_c0 (v0 : int32, v1 : int32) (v2 : int32) : struct ((int32 -> int32) * (int32 -> int32)) =
    let v3 : bool = v2 = 0
    if v3 then
        let v4 : (int32 -> int32) = right_c1(v1, v2)
        let v5 : (int32 -> int32) = left_c2(v0, v2)
        struct (v4, v5)
    else
        let v6 : (int32 -> int32) = left_c2(v0, v2)
        let v7 : (int32 -> int32) = right_c1(v1, v2)
        struct (v6, v7)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : (int32 -> struct ((int32 -> int32) * (int32 -> int32))) = f_c0(v0, v1)
let struct (v3 : (int32 -> int32), v4 : (int32 -> int32)) = v2 1
let v5 : int32 = v3 0
let v6 : int32 = v4 0
let v7 : int32 = v5 + v6
let v8 : bool = v7 = 7
if v8 then
    0
else
    1
