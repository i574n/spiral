let rec method0 (v0 : (int32 [])) : int32 =
    let v1 : int32 = v0.[int 0]
    v1
and method1 (v0 : (int32 [])) : int32 =
    let v1 : int32 = v0.[int 0]
    v1
let v0 : int32 = 2
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
v1.[int 0] <- 3
v1.[int 1] <- 4
let v2 : int32 = method0(v1)
let v3 : int32 = method1(v1)
let v4 : int32 = v2 + v3
let v5 : int32 = v4 - 6
v5
