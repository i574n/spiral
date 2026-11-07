let rec f_c0 (v0 : int32, v1 : string) (v2 : int32) : struct (int32 * string) =
    let v3 : bool = v2 = 0
    if v3 then
        let v4 : string = "no"
        struct (0, v4)
    else
        struct (v0, v1)
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : (int32 -> struct (int32 * string)) = f_c0(v0, v1)
let struct (v3 : int32, v4 : string) = v2 1
let v5 : bool = v3 = 7
let v7 : bool =
    if v5 then
        let v6 : bool = v4 = "hi"
        v6
    else
        false
if v7 then
    0
else
    1
