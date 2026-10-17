let rec is_odd_1 (v0 : int32) : bool =
    let v1 : bool = v0 = 0
    if v1 then
        false
    else
        let v2 : int32 = v0 - 1
        is_even_0(v2)
and is_even_0 (v0 : int32) : bool =
    let v1 : bool = v0 = 0
    if v1 then
        true
    else
        let v2 : int32 = v0 - 1
        is_odd_1(v2)
let v0 : int32 = 10
let v1 : bool = is_even_0(v0)
if v1 then
    0
else
    1
