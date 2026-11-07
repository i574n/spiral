let rec method1 (v0 : int32, v1 : int32) : struct (int32 * int32) =
    struct (v0, v1)
and method0 (v0 : int32, v1 : int32) : int32 =
    let struct (v2 : int32, v3 : int32) = method1(v0, v1)
    let v4 : int32 = v2 + v3
    v4
and method3 (v0 : int32, v1 : int32, v2 : int32) : struct (int32 * int32 * int32) =
    struct (v0, v1, v2)
and method2 (v0 : int32, v1 : int32, v2 : int32) : int32 =
    let struct (v3 : int32, v4 : int32, v5 : int32) = method3(v0, v1, v2)
    let v6 : int32 = v3 + v4
    let v7 : int32 = v6 + v5
    v7
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = 3
let v3 : int32 = method0(v0, v1)
let v4 : int32 = method2(v0, v1, v2)
let v5 : int32 = v3 + v4
let v6 : int32 = v5 - 9
v6
