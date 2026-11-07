let rec f_c0 (v0 : int8) (v1 : int32) : struct (int8 * int8) =
    let v2 : bool = v1 = 0
    if v2 then
        struct (0y, 0y)
    else
        struct (v0, 7y)
let v0 : int8 = 100y
let v1 : (int32 -> struct (int8 * int8)) = f_c0(v0)
let struct (v2 : int8, v3 : int8) = v1 1
let v4 : bool = v2 = 100y
let v6 : bool =
    if v4 then
        let v5 : bool = v3 = 7y
        v5
    else
        false
if v6 then
    0
else
    1
