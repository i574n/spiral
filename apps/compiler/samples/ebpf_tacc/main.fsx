let rec method2 (v0 : int32, v1 : int32, v2 : int32) : struct (int32 * int32) =
    let v3 : int32 = v0 - 1
    let v4 : int32 = v1 + 1
    let v5 : int32 = v2 + 2
    let v6 : bool = v3 = 0
    if v6 then
        struct (v4, v5)
    else
        method2(v3, v4, v5)
and method1 (v0 : int32) : struct (int32 * int32) =
    let v1 : int32 = 0
    let v2 : int32 = 0
    let v3 : bool = v0 = 0
    if v3 then
        struct (v1, v2)
    else
        method2(v0, v1, v2)
and method0 (v0 : int32) : int32 =
    let struct (v1 : int32, v2 : int32) = method1(v0)
    let v3 : bool = v1 = 4
    let v5 : bool =
        if v3 then
            let v4 : bool = v2 = 8
            v4
        else
            false
    if v5 then
        0
    else
        1
let v0 : int32 = 4
method0(v0)
