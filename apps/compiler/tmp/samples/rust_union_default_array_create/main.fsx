type [<Struct>] US0 =
    | US0_Nothing
    | US0_Just of f1_0 : string
let v0 : int32 = 2
let v1 : (struct (string * US0 * bool) []) = Array.zeroCreate<struct (string * US0 * bool)> (v0)
let v2 : string = "a"
let v3 : string = "x"
let v4 : US0 = US0_Just(v3)
v1.[int 0] <- struct (v2, v4, true)
let v5 : string = "b"
let v6 : US0 = US0_Nothing
v1.[int 1] <- struct (v5, v6, false)
let struct (v7 : string, v8 : US0, v9 : bool) = v1.[int 0]
match v8 with
| US0_Just(v10) -> (* Just *)
    let v11 : bool = v10 = "x"
    if v11 then
        7
    else
        1
| US0_Nothing -> (* Nothing *)
    2
