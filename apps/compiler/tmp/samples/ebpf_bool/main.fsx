let rec method0 (v0 : bool) : int32 =
    if v0 then
        1
    else
        3
and method1 (v0 : bool, v1 : bool) : int32 =
    let v2 : bool = v0 && v1
    if v2 then
        1
    else
        let v3 : bool = v0 || v1
        if v3 then
            2
        else
            3
and method2 (v0 : bool) : int32 =
    if v0 then
        1
    else
        3
let v0 : bool = true
let v1 : bool = false
let v2 : int32 = method0(v0)
let v3 : int32 = method1(v0, v1)
let v4 : int32 = method2(v1)
let v5 : bool = v0 = v1
let v6 : bool = v5 = false
let v7 : bool = v2 = 1
let v9 : bool =
    if v7 then
        let v8 : bool = v3 = 2
        v8
    else
        false
let v11 : bool =
    if v9 then
        let v10 : bool = v4 = 3
        v10
    else
        false
let v12 : bool = v11 && v6
if v12 then
    0
else
    1
