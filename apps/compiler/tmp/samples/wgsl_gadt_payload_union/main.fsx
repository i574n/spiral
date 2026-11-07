type [<Struct>] US1 =
    | US1_Living of f0_0 : int32 * f0_1 : int32
and [<Struct>] US2 =
    | US2_Fallen of f0_0 : int32
and [<Struct>] US0 =
    | US0_Survived of f0_0 : US1
    | US0_Slain of f1_0 : US2
let v0 : int32 = 60
let v1 : bool = v0 > 0
let v6 : US0 =
    if v1 then
        let v2 : US1 = US1_Living(v0, 100)
        US0_Survived(v2)
    else
        let v4 : US2 = US2_Fallen(100)
        US0_Slain(v4)
match v6 with
| US0_Slain(v13) -> (* Slain *)
    2
| US0_Survived(v7) -> (* Survived *)
    match v7 with
    | US1_Living(v8, v9) -> (* Living *)
        let v10 : bool = v8 = 60
        if v10 then
            0
        else
            1
