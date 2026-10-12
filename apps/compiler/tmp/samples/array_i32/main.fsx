let v0 : int32 = 4
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
v1.[int 0] <- 10
v1.[int 1] <- 20
v1.[int 2] <- 30
let v2 : int32 = v1.[int 0]
let v3 : int32 = v1.[int 1]
let v4 : int32 = v2 + v3
v1.[int 3] <- v4
let v5 : int32 = v1.[int 2]
let v6 : int32 = v1.[int 3]
let v7 : int32 = v5 + v6
let v8 : int32 = v1.Length
let v9 : bool = v8 = v0
let v11 : bool =
    if v9 then
        let v10 : bool = v7 = 60
        v10
    else
        false
if v11 then
    0
else
    1
