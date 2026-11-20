let rec closure1 (v0 : int32) (v1 : int32) : int32 =
    let v2 : int32 = v0 * 10
    let v3 : int32 = v2 + v1
    v3
and f_c0 () (v0 : int32) : (int32 -> int32) =
    closure1(v0)
let v0 : (int32 -> (int32 -> int32)) = f_c0()
let v1 : (int32 -> int32) = v0 3
let v2 : int32 = v1 4
let v3 : bool = v2 = 34
if v3 then
    0
else
    1
