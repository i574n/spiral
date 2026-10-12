let rec method0 (v0 : (int32 []), v1 : int32) : int32 =
    let v2 : int32 = v0.[int v1]
    let v3 : int32 = v0.Length
    let v4 : int32 = v2 + v3
    let v5 : int32 = v4 - 10
    v5
let v0 : int32 = 3
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
v1.[int 0] <- 2
v1.[int 1] <- 5
v1.[int 2] <- 7
let v2 : int32 = 2
method0(v1, v2)
