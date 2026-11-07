let rec method1 (v0 : int32, v1 : bool) : bool =
    let v2 : int32 = v0 - 1
    let v4 : bool =
        if v1 then
            let v3 : bool = v0 > 0
            v3
        else
            false
    let v5 : bool = v2 = 0
    if v5 then
        v4
    else
        method1(v2, v4)
and method0 (v0 : int32) : bool =
    let v1 : bool = true
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        method1(v0, v1)
and method2 (v0 : int32) : bool =
    let v1 : bool = false
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        method1(v0, v1)
let v0 : int32 = 3
let v1 : bool = method0(v0)
let v2 : bool = method2(v0)
if v1 then
    if v2 then
        1
    else
        0
else
    2
