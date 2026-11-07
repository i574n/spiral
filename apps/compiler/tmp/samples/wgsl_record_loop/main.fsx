let rec loop_0 (v0 : int32, v1 : int32, v2 : int32, v3 : int32) : struct (int32 * int32) =
    let v4 : bool = v1 >= v0
    let struct (v9 : int32, v10 : int32) =
        if v4 then
            struct (v2, v3)
        else
            let v5 : int32 = v1 + 1
            let v6 : int32 = v2 + 1
            let struct (v7 : int32, v8 : int32) = loop_0(v0, v5, v6, v3)
            struct (v7, v8)
    struct (v9, v10)
let v0 : int32 = 5
let v1 : int32 = 0
let v2 : int32 = 1
let v3 : int32 = 2
let struct (v4 : int32, v5 : int32) = loop_0(v0, v1, v2, v3)
let v6 : int32 = v4 + v5
v6
