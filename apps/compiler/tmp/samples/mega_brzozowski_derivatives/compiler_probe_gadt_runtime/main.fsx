type [<Struct>] US0 =
    | US0_RawState of f0_0 : int32
and [<Struct>] US1 =
    | US1_DecidedState of f0_0 : int32 * f0_1 : bool
let rec decide_state_0 (v0 : US0) : US1 =
    match v0 with
    | US0_RawState(v1) -> (* RawState *)
        US1_DecidedState(v1, true)
let v0 : int32 = 7
let v1 : US0 = US0_RawState(v0)
let v2 : US1 = decide_state_0(v1)
match v2 with
| US1_DecidedState(v3, v4) -> (* DecidedState *)
    v4
