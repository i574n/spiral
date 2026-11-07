let rec method0 (v0 : int32) : struct (float * float) =
    let v1 : bool = v0 = 0
    if v1 then
        struct (0.0, 0.0)
    else
        struct (1.5, 2.5)
let v0 : int32 = 7
let struct (v1 : float, v2 : float) = method0(v0)
let v3 : bool = v1 = 1.5
let v5 : bool =
    if v3 then
        let v4 : bool = v2 = 2.5
        v4
    else
        false
if v5 then
    0
else
    1
