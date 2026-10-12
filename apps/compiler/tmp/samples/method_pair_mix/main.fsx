let rec method0 (v0 : int32, v1 : string) : struct (int32 * string) =
    let v2 : bool = v0 = 0
    if v2 then
        let v3 : string = "no"
        struct (0, v3)
    else
        struct (v0, v1)
let v0 : int32 = 7
let v1 : string = "hi"
let struct (v2 : int32, v3 : string) = method0(v0, v1)
let v4 : bool = v2 = 7
let v6 : bool =
    if v4 then
        let v5 : bool = v3 = "hi"
        v5
    else
        false
if v6 then
    0
else
    1
