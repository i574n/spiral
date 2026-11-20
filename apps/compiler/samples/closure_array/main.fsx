let rec f_c0 (v0 : int32) (v1 : int32) : (int32 []) =
    let v2 : (int32 []) = Array.zeroCreate<int32> (1)
    v2.[int 0] <- v0
    v2
let v0 : int32 = 7
let v1 : (int32 -> (int32 [])) = f_c0(v0)
let v2 : (int32 []) = v1 1
let v3 : int32 = v2.[int 0]
let v4 : bool = v3 = 7
if v4 then
    0
else
    1
