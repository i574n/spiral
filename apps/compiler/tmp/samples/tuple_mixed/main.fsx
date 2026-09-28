let rec method0 (v0 : float32) : struct (bool * float32 * int32) =
    let v1 : bool = v0 >= 3.5f
    struct (v1, v0, 7)
and method1 (v0 : bool, v1 : float32, v2 : int32) : int32 =
    if v0 then
        let v3 : bool = v1 >= 3.5f
        if v3 then
            let v4 : int32 = v2 - 7
            v4
        else
            1
    else
        2
let v0 : float32 = 4.0f
let struct (v1 : bool, v2 : float32, v3 : int32) = method0(v0)
method1(v1, v2, v3)
