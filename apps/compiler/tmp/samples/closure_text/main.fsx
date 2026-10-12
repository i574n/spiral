let rec f_c0 (v0 : string) (v1 : int32) : string =
    let v2 : bool = v1 = 0
    if v2 then
        let v3 : string = "no"
        v3
    else
        v0
let v0 : string = "hi"
let v1 : (int32 -> string) = f_c0(v0)
let v2 : string = v1 1
let v3 : bool = v2 = "hi"
if v3 then
    0
else
    1
