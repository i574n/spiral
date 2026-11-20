let rec method0 () : struct ((int32 []) * int32) =
    let v0 : int32 = 2
    let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
    v1.[int 0] <- 3
    v1.[int 1] <- 4
    struct (v1, 1)
and method1 (v0 : (int32 []), v1 : int32) : int32 =
    let v2 : int32 = v0.[int 0]
    let v3 : int32 = v2 + v1
    let v4 : int32 = v3 - 1
    v4
and method2 (v0 : (int32 []), v1 : int32) : int32 =
    let v2 : int32 = v0.[int 0]
    let v3 : int32 = v0.[int 1]
    let v4 : int32 = v2 + v3
    let v5 : int32 = v4 + v1
    v5
let struct (v0 : (int32 []), v1 : int32) = method0()
let v2 : int32 = method1(v0, v1)
let v3 : int32 = method2(v0, v1)
let v4 : int32 = v2 + v3
let v5 : int32 = v4 - 11
v5
