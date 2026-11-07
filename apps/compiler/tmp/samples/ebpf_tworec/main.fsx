let rec method1 (v0 : int32, v1 : int32) : int32 =
    let v2 : int32 = v0 - 1
    let v3 : int32 = v1 + 3
    let v4 : bool = v2 = 0
    if v4 then
        v3
    else
        method1(v2, v3)
and method0 (v0 : int32) : int32 =
    let v1 : int32 = 0
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        method1(v0, v1)
and method3 (v0 : int32, v1 : int32) : int32 =
    let v2 : int32 = v0 - 1
    let v3 : int32 = v1 - 2
    let v4 : bool = v2 = 0
    if v4 then
        v3
    else
        method3(v2, v3)
and method2 (v0 : int32) : int32 =
    let v1 : int32 = 0
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        method3(v0, v1)
let v0 : int32 = 4
let v1 : int32 = method0(v0)
let v2 : int32 = method2(v0)
let v3 : bool = v1 = 12
let v5 : bool =
    if v3 then
        let v4 : bool = v2 = -8
        v4
    else
        false
if v5 then
    0
else
    1
