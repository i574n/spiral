let rec f_c0 (v0 : string, v1 : string) (v2 : int32) : struct (string * string) =
    let v3 : bool = v2 = 0
    if v3 then
        let v4 : string = "no"
        let v5 : string = "nay"
        struct (v4, v5)
    else
        struct (v0, v1)
let v0 : string = "hi"
let v1 : string = "yo"
let v2 : (int32 -> struct (string * string)) = f_c0(v0, v1)
let struct (v3 : string, v4 : string) = v2 1
let v5 : bool = v3 = "hi"
let v7 : bool =
    if v5 then
        let v6 : bool = v4 = "yo"
        v6
    else
        false
if v7 then
    0
else
    1
