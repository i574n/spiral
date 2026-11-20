let rec method0 (v0 : string, v1 : string) : struct (string * string) =
    let v2 : bool = v0 = ""
    if v2 then
        let v3 : string = "no"
        let v4 : string = "nay"
        struct (v3, v4)
    else
        struct (v0, v1)
let v0 : string = "hi"
let v1 : string = "yo"
let struct (v2 : string, v3 : string) = method0(v0, v1)
let v4 : bool = v2 = "hi"
let v6 : bool =
    if v4 then
        let v5 : bool = v3 = "yo"
        v5
    else
        false
if v6 then
    0
else
    1
