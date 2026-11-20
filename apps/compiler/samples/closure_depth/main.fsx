let rec h_c2 (v0 : int32, v1 : int32) (v2 : int32) : int32 =
    let v3 : bool = v1 = 0
    if v3 then
        0
    else
        let v4 : int32 = v2 + v0
        v4
and g_c1 (v0 : int32, v1 : int32) (v2 : int32) : (int32 -> int32) =
    h_c2(v0, v1)
and f_c0 (v0 : int32) (v1 : int32) : (int32 -> (int32 -> int32)) =
    g_c1(v0, v1)
let v0 : int32 = 7
let v1 : (int32 -> (int32 -> (int32 -> int32))) = f_c0(v0)
let v2 : (int32 -> (int32 -> int32)) = v1 1
let v3 : (int32 -> int32) = v2 0
let v4 : int32 = v3 0
let v5 : bool = v4 = 7
if v5 then
    0
else
    1
