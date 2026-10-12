let v0 : int32 = -1
let v1 : int32 = -8
let v2 : int32 = ~~~v0
let v3 : int32 = ~~~v1
let v4 : bool = v2 = 0
let v6 : bool =
    if v4 then
        let v5 : bool = v3 = 7
        v5
    else
        false
if v6 then
    0
else
    1
