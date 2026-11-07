let rec f_c0 () (v0 : int32) : int32 =
    let v1 : int32 = v0 + 1
    v1
let v0 : (int32 -> int32) = f_c0()
let v1 : int32 = v0 6
let v2 : bool = v1 = 7
if v2 then
    0
else
    1
