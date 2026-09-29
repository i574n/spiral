type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
and [<Struct>] US1 =
    | US1_1 of f1_0 : int32 * f1_1 : bool
let rec method0 (v0 : US0) : US1 =
    match v0 with
    | US0_0(v1) -> (* RawState *)
        US1_0(v1, true)
let v0 : int32 = 7
let v1 : US0 = US0_0(v0)
let v2 : US1 = method0(v1)
match v2 with
| US1_0(v3, v4) -> (* DecidedState *)
    v4
