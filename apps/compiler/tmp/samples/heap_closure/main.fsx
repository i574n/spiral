type Heap0 = {l0 : (int32 -> int32)}
let rec f_c0 (v0 : int32) (v1 : int32) : int32 =
    let v2 : int32 = v1 + v0
    v2
let v0 : int32 = 3
let v1 : (int32 -> int32) = f_c0(v0)
let v2 : Heap0 = {l0 = v1} : Heap0
let v3 : (int32 -> int32) = v2.l0
let v4 : int32 = v3 4
let v5 : bool = v4 = 7
if v5 then
    0
else
    1
