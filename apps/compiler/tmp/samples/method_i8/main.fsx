let rec method0 (v0 : int8) : int8 =
    let v1 : bool = v0 = 0y
    if v1 then
        1y
    else
        v0
let v0 : int8 = 100y
let v1 : int8 = method0(v0)
let v2 : bool = v1 = 100y
if v2 then
    0
else
    1
