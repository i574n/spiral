let rec method1 (v0 : int32, v1 : float32) : float32 =
    let v2 : int32 = v0 - 1
    let v3 : float32 = v1 + 1.5f
    let v4 : bool = v2 = 0
    if v4 then
        v3
    else
        method1(v2, v3)
and method0 (v0 : int32, v1 : float32) : float32 =
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        method1(v0, v1)
let v0 : int32 = 4
let v1 : float32 = 0.0f
let v2 : float32 = method0(v0, v1)
let v3 : bool = v2 = 6.0f
if v3 then
    0
else
    1
