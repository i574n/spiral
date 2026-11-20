let rec f_c0 (v0 : int32, v1 : string, v2 : bool) (v3 : int32) : struct (int32 * string * bool) =
    let v4 : bool = v3 = 0
    if v4 then
        let v5 : string = "no"
        struct (0, v5, false)
    else
        struct (v0, v1, v2)
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : bool = true
let v3 : (int32 -> struct (int32 * string * bool)) = f_c0(v0, v1, v2)
let struct (v4 : int32, v5 : string, v6 : bool) = v3 1
let v7 : bool = v4 = 7
let v9 : bool =
    if v7 then
        let v8 : bool = v5 = "hi"
        v8
    else
        false
let v10 : bool = v9 && v6
if v10 then
    0
else
    1
