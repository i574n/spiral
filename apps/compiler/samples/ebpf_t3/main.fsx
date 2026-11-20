let rec method2 (v0 : int32, v1 : int32, v2 : int32, v3 : int32) : struct (int32 * int32 * int32) =
    let v4 : int32 = v0 - 1
    let v5 : int32 = v1 + 1
    let v6 : int32 = v2 + 2
    let v7 : int32 = v3 + 3
    let v8 : bool = v4 = 0
    if v8 then
        struct (v5, v6, v7)
    else
        method2(v4, v5, v6, v7)
and method1 (v0 : int32) : struct (int32 * int32 * int32) =
    let v1 : int32 = 0
    let v2 : int32 = 0
    let v3 : int32 = 0
    let v4 : bool = v0 = 0
    if v4 then
        struct (v1, v2, v3)
    else
        method2(v0, v1, v2, v3)
and method0 (v0 : int32) : int32 =
    let struct (v1 : int32, v2 : int32, v3 : int32) = method1(v0)
    let v4 : bool = v1 = 3
    let v6 : bool =
        if v4 then
            let v5 : bool = v2 = 6
            v5
        else
            false
    let v8 : bool =
        if v6 then
            let v7 : bool = v3 = 9
            v7
        else
            false
    if v8 then
        0
    else
        1
let v0 : int32 = 3
method0(v0)
