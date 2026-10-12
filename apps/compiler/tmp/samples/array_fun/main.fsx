let rec f_c0 (v0 : int32) (v1 : int32) : int32 =
    let v2 : int32 = v1 + v0
    v2
let v0 : int32 = 3
let v1 : (int32 -> int32) = f_c0(v0)
let v2 : int32 = 1
let v3 : ((int32 -> int32) []) = Array.zeroCreate<(int32 -> int32)> (v2)
v3.[int 0] <- v1
let v4 : (int32 -> int32) = v3.[int 0]
let v5 : int32 = v4 4
let v6 : bool = v5 = 7
if v6 then
    0
else
    1
