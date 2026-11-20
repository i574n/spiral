let v0 : int32 = 3
let v1 : (struct (int32 * bool) []) = Array.zeroCreate<struct (int32 * bool)> (v0)
let v2 : int32 = 4
v1.[int 0] <- struct (v2, true)
v1.[int 1] <- struct (7, false)
v1.[int 2] <- struct (9, true)
let struct (v3 : int32, v4 : bool) = v1.[int 0]
let struct (v5 : int32, v6 : bool) = v1.[int 1]
let v7 : int32 = 2
let struct (v8 : int32, v9 : bool) = v1.[int v7]
let v10 : int32 =
    if v4 then
        1
    else
        0
let v11 : int32 =
    if v6 then
        10
    else
        0
let v12 : int32 =
    if v9 then
        100
    else
        0
let v13 : int32 = v3 + v5
let v14 : int32 = v13 + v8
let v15 : int32 = v14 + v10
let v16 : int32 = v15 + v11
let v17 : int32 = v16 + v12
v17
