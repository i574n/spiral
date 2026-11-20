let rec f_c0 (v0 : bool) (v1 : int32) : struct (bool * bool) =
    let v2 : bool = v1 = 0
    if v2 then
        struct (false, false)
    else
        struct (v0, true)
let v0 : bool = true
let v1 : (int32 -> struct (bool * bool)) = f_c0(v0)
let struct (v2 : bool, v3 : bool) = v1 1
let v4 : bool = v2 && v3
if v4 then
    0
else
    1
