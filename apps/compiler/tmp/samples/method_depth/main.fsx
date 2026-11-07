let rec h_c1 (v0 : int32) (v1 : int32) : int32 =
    let v2 : bool = v0 = 0
    if v2 then
        0
    else
        let v3 : int32 = v1 + v0
        v3
and g_c0 (v0 : int32) (v1 : int32) : (int32 -> int32) =
    h_c1(v0)
and method0 (v0 : int32) : (int32 -> (int32 -> int32)) =
    g_c0(v0)
let v0 : int32 = 7
let v1 : (int32 -> (int32 -> int32)) = method0(v0)
let v2 : (int32 -> int32) = v1 0
let v3 : int32 = v2 0
let v4 : bool = v3 = 7
if v4 then
    0
else
    1
