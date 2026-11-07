let rec f_c0 (v0 : int32, v1 : int32) (v2 : int32) : int32 =
    let v3 : int32 = v0 + v1
    let v4 : int32 = v3 + v2
    v4
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : (int32 -> int32) = f_c0(v0, v1)
v2 39
