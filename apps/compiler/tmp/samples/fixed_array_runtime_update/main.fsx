let v0 : (int32 []) = Array.zeroCreate<int32> (4)
v0.[int 0] <- 2
v0.[int 1] <- 3
v0.[int 2] <- 5
v0.[int 3] <- 7
let v1 : int32 = 1
v0.[int v1] <- 11
let v2 : int32 = v0.[int 0]
let v3 : int32 = v0.[int 1]
let v4 : int32 = v0.[int 2]
let v5 : int32 = v0.[int 3]
let v6 : int32 = v2 + v3 
let v7 : int32 = v6 + v4 
let v8 : int32 = v7 + v5 
let v9 : int32 = v8 - 25 
v9
