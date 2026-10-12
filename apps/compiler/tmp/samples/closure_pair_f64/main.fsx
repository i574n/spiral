let rec f_c0 (v0 : float) (v1 : int32) : struct (float * float) =
    let v2 : bool = v1 = 0
    if v2 then
        struct (0.0, 0.0)
    else
        struct (v0, 2.5)
let v0 : float = 1.5
let v1 : (int32 -> struct (float * float)) = f_c0(v0)
let struct (v2 : float, v3 : float) = v1 1
let v4 : bool = v2 = 1.5
let v6 : bool =
    if v4 then
        let v5 : bool = v3 = 2.5
        v5
    else
        false
if v6 then
    0
else
    1
