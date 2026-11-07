let v0 : (int32 []) = Array.zeroCreate<int32> (4)
v0.[int 0] <- 7
v0.[int 1] <- 7
v0.[int 2] <- 7
v0.[int 3] <- 7
let v1 : int32 = v0.[int 3]
let v2 : (int32 []) = Array.zeroCreate<int32> (4)
v2.[int 0] <- 5
let v3 : int32 = v2.[int 3]
let v4 : int32 = v2.[int 0]
let v5 : int32 = v3 * 100
let v6 : int32 = v5 + v4
let v7 : int32 = v1 - 7
let v8 : int32 = v6 + v7
v8
