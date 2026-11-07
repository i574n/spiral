let rec method0 (v0 : int32) : struct (string * string) =
    let v1 : bool = v0 = 0
    if v1 then
        let v2 : string = "no"
        struct (v2, v2)
    else
        let v3 : string = "hi"
        let v4 : string = "yo"
        struct (v3, v4)
let v0 : int32 = 7
let struct (v1 : string, v2 : string) = method0(v0)
let v3 : bool = v1 = "hi"
let v5 : bool =
    if v3 then
        let v4 : bool = v2 = "yo"
        v4
    else
        false
if v5 then
    0
else
    1
