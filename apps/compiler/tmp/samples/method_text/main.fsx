let rec method0 (v0 : int32) : string =
    let v1 : bool = v0 = 0
    if v1 then
        let v2 : string = "no"
        v2
    else
        let v3 : string = "hi"
        v3
let v0 : int32 = 7
let v1 : string = method0(v0)
let v2 : bool = v1 = "hi"
if v2 then
    0
else
    1
