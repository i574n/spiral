let rec count_odd_2 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        let v3 : int32 = v0 - 1
        count_even_0(v3, v1)
and bump_1 (v0 : int32) : int32 =
    let v1 : bool = v0 = 4
    if v1 then
        let v2 : int32 = 0
        let v3 : int32 = 1
        count_odd_2(v2, v3)
    else
        0
and count_even_0 (v0 : int32, v1 : int32) : int32 =
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        let v3 : int32 = v0 - 1
        let v4 : int32 = bump_1(v0)
        let v5 : int32 = v1 + v4
        count_odd_2(v3, v5)
let v0 : int32 = 10
let v1 : int32 = 0
let v2 : int32 = count_even_0(v0, v1)
let v3 : int32 = v2 - 1
v3
