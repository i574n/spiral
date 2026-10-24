let rec run_0 (v0 : int32, v1 : string, v2 : string, v3 : int32) : struct (string * string * int32) =
    let v4 : bool = v0 <= 0
    let struct (v11 : string, v12 : string, v13 : int32) =
        if v4 then
            struct (v1, v2, v3)
        else
            let v5 : int32 = v0 - 1
            let v6 : int32 = v3 + 1
            let v7 : string = "y"
            let struct (v8 : string, v9 : string, v10 : int32) = run_0(v5, v2, v7, v6)
            struct (v8, v9, v10)
    struct (v11, v12, v13)
let v0 : int32 = 5
let v1 : string = ""
let v2 : int32 = 0
let struct (v3 : string, v4 : string, v5 : int32) = run_0(v0, v1, v1, v2)
let v6 : int32 = v5 - 5
v6
