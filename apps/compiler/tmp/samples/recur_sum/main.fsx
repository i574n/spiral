let rec sum_0 (v0 : int32) : int32 =
    let v1 : bool = v0 < 1
    if v1 then
        0
    else
        let v2 : int32 = v0 - 1
        let v3 : int32 = sum_0(v2)
        let v4 : int32 = v0 + v3
        v4
let v0 : int32 = 4
let v1 : int32 = sum_0(v0)
let v2 : bool = v1 = 10
if v2 then
    0
else
    1
