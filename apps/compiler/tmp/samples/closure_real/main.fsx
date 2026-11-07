let rec f_c0 (v0 : float) (v1 : int32) : float =
    let v2 : bool = v1 = 0
    if v2 then
        0.0
    else
        v0
let v0 : float = 1.5
let v1 : (int32 -> float) = f_c0(v0)
let v2 : float = v1 1
let v3 : bool = v2 = 1.5
if v3 then
    0
else
    1
