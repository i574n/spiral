let v0 : int32 = 2
let v1 : ((int32 []) []) = Array.zeroCreate<(int32 [])> (v0)
let v2 : (int32 []) = Array.zeroCreate<int32> (v0)
let v3 : (int32 []) = Array.zeroCreate<int32> (v0)
v2.[int 0] <- 3
v2.[int 1] <- 4
v3.[int 0] <- 5
v3.[int 1] <- 6
v1.[int 0] <- v2
v1.[int 1] <- v3
let v5 : (int32 []) = v1.[int 0]
let v6 : (int32 []) = v1.[int 1]
let v7 : int32 = v5.[int 0]
let v8 : int32 = v5.[int 1]
let v9 : int32 = v7 + v8
let v10 : int32 = v6.[int 0]
let v11 : int32 = v9 + v10
let v12 : int32 = v6.[int 1]
let v13 : int32 = v11 + v12
let v14 : int32 = v13 - 18
v14
