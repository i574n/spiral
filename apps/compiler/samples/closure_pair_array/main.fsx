let rec f_c0 (v0 : int32, v1 : int32) (v2 : int32) : struct ((int32 []) * (int32 [])) =
    let v3 : (int32 []) = Array.zeroCreate<int32> (1)
    let v4 : (int32 []) = Array.zeroCreate<int32> (1)
    let v5 : bool = v2 = 0
    if v5 then
        v3.[int 0] <- 0
        v4.[int 0] <- 0
        struct (v3, v4)
    else
        v3.[int 0] <- v0
        v4.[int 0] <- v1
        struct (v3, v4)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : (int32 -> struct ((int32 []) * (int32 []))) = f_c0(v0, v1)
let struct (v3 : (int32 []), v4 : (int32 [])) = v2 1
let v5 : int32 = v3.[int 0]
let v6 : int32 = v4.[int 0]
let v7 : int32 = v5 + v6
let v8 : bool = v7 = 7
if v8 then
    0
else
    1
