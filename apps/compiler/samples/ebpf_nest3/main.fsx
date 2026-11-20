let rec method1 (v0 : int32, v1 : uint32, v2 : float32) : struct (int32 * uint32 * float32) =
    struct (v0, v1, v2)
and method0 (v0 : int32, v1 : uint32, v2 : float32) : int32 =
    let struct (v3 : int32, v4 : uint32, v5 : float32) = method1(v0, v1, v2)
    let v6 : bool = v3 = 2
    let v8 : bool =
        if v6 then
            let v7 : bool = v4 = 3u
            v7
        else
            false
    let v10 : bool =
        if v8 then
            let v9 : bool = v5 = 1.5f
            v9
        else
            false
    if v10 then
        0
    else
        1
let v0 : int32 = 2
let v1 : uint32 = 3u
let v2 : float32 = 1.5f
method0(v0, v1, v2)
