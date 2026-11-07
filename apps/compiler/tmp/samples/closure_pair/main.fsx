let rec f_c0 () (v0 : int32) : struct (int32 * int32) =
    let v1 : int32 = v0 + 1
    struct (v0, v1)
let v0 : int32 = 3
let v1 : (int32 -> struct (int32 * int32)) = f_c0()
let struct (v2 : int32, v3 : int32) = v1 v0
let v4 : bool = v2 = 3
let v6 : bool =
    if v4 then
        let v5 : bool = v3 = 4
        v5
    else
        false
if v6 then
    0
else
    1
