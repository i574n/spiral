let v0 : int32 = 5
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
v1.[int 0] <- 0
v1.[int 1] <- 1
v1.[int 2] <- 4
let v2 : int32 = 3
v1.[int v2] <- 9
let v3 : int32 = v2 + 1
v1.[int v3] <- 16
let v4 : (bool []) = Array.zeroCreate<bool> (3)
v4.[int 0] <- false
v4.[int 1] <- true
v4.[int 2] <- false
let v5 : int32 = v1.[int 1]
let v6 : int32 = v1.[int 2]
let v7 : int32 = v5 + v6
let v8 : int32 = v1.[int 3]
let v9 : int32 = v7 + v8
let v10 : int32 = v1.[int 4]
let v11 : int32 = v9 + v10
let v12 : bool = v4.[int 1]
let v15 : int32 =
    if v12 then
        let v13 : bool = v4.[int 0]
        if v13 then
            0
        else
            100
    else
        0
let v16 : int32 = v11 + v15
let v17 : int32 = v1.Length
let v18 : int32 = v16 + v17
v18
