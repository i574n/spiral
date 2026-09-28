let rec method0 (v0 : int32) : struct (int32 * int32 * bool) =
    let v1 : int32 = v0 + 2 
    let v2 : bool = v0 > 0
    struct (v0, v1, v2)
and method1 (v0 : int32, v1 : int32, v2 : bool) : int32 =
    if v2 then
        let v3 : int32 = v0 + v1 
        let v4 : int32 = v3 - 4 
        v4
    else
        1
let v0 : int32 = 1
let struct (v1 : int32, v2 : int32, v3 : bool) = method0(v0)
method1(v1, v2, v3)
