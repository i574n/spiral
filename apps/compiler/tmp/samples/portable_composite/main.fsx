let rec method1 (v0 : int32) : struct (int32 * int32 * bool) =
    let v1 : int32 = v0 + 2
    let v2 : bool = v0 > 0
    struct (v0, v1, v2)
and method2 (v0 : int32, v1 : int32, v2 : bool) : int32 =
    if v2 then
        let v3 : int32 = v0 + v1
        let v4 : int32 = v3 - 4
        v4
    else
        1
and method4 (v0 : float32) : struct (bool * float32 * int32) =
    let v1 : bool = v0 >= 3.5f
    struct (v1, v0, 7)
and method5 (v0 : int32, v1 : float32, v2 : bool) : int32 =
    if v2 then
        let v3 : bool = v1 >= 3.5f
        if v3 then
            let v4 : int32 = v0 - 7
            v4
        else
            1
    else
        2
and method7 (v0 : string) : bool =
    true
and method9 (v0 : uint32) : bool =
    let v1 : uint32 = v0 + 5u
    let v2 : uint32 = v1 % 4u
    let v3 : bool = v2 = 0u
    v3
and method11 (v0 : int32, v1 : int32) : int32 =
    let v2 : int32 = v0 * v1
    let v3 : int32 = v2 + 5
    let v4 : int32 = v3 / 3
    v4
and method10 (v0 : int32) : int32 =
    let v1 : int32 = 4
    let v2 : int32 = 4
    let v3 : int32 = method11(v1, v2)
    let v4 : int32 = v0 + v3
    let v5 : int32 = v4 - 7
    v5
and method8 (v0 : int32) : int32 =
    let v1 : uint32 = 7u
    let v2 : bool = method9(v1)
    if v2 then
        method10(v0)
    else
        1
and method6 (v0 : int32) : int32 =
    let v1 : string = "spiral"
    let v2 : bool = method7(v1)
    if v2 then
        method8(v0)
    else
        1
and method3 (v0 : int32) : int32 =
    let v1 : float32 = 4.0f
    let struct (v2 : bool, v3 : float32, v4 : int32) = method4(v1)
    let v5 : int32 = method5(v4, v3, v2)
    let v6 : int32 = v0 + v5
    method6(v6)
and method0 (v0 : int32) : int32 =
    let v1 : int32 = 1
    let struct (v2 : int32, v3 : int32, v4 : bool) = method1(v1)
    let v5 : int32 = method2(v2, v3, v4)
    let v6 : int32 = v0 + v5
    method3(v6)
let v0 : int32 = 0
method0(v0)
