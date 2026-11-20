let v0 : (int32 []) = Array.zeroCreate<int32> (4)
v0.[int 0] <- 2
v0.[int 1] <- 3
v0.[int 2] <- 5
v0.[int 3] <- 7
let v1 : int32 = 2
let v2 : int32 = v0.[int v1]
let v3 : int32 = v2 - 5
v3
