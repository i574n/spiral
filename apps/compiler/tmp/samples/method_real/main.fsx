let rec method0 (v0 : int32) : float =
    let v1 : bool = v0 = 0
    if v1 then
        0.0
    else
        1.5
let v0 : int32 = 7
let v1 : float = method0(v0)
let v2 : bool = v1 = 1.5
if v2 then
    0
else
    1
