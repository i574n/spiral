let rec f_c0 (v0 : string) (v1 : int32) : struct (string * string) =
    let v2 : bool = v1 = 0
    if v2 then
        let v3 : string = "no"
        struct (v3, v3)
    else
        let v4 : string = "yo"
        struct (v0, v4)
let v0 : string = "hi"
let v1 : (int32 -> struct (string * string)) = f_c0(v0)
let struct (v2 : string, v3 : string) = v1 1
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
