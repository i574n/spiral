let v0 : (int32 []) = Array.zeroCreate<int32> (3)
v0.[int 0] <- 2
v0.[int 1] <- 3
v0.[int 2] <- 5
let v1 : int32 = v0.[int 0]
let v2 : int32 = v0.[int 1]
let v3 : int32 = v0.[int 2]
let v4 : int32 = v1 + v2
let v5 : int32 = v4 + v3
let v6 : int32 = v5 - 10
v6
