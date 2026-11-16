type [<Struct>] US0 =
    | US0_RawA of f0_0 : int32
and [<Struct>] US1 =
    | US1_DecidedA of f0_0 : int32 * f0_1 : bool
and [<Struct>] US2 =
    | US2_RawB of f0_0 : int32
and [<Struct>] US3 =
    | US3_DecidedB of f0_0 : bool * f0_1 : int32
and [<Struct>] US4 =
    | US4_RawC of f0_0 : int32
and [<Struct>] US5 =
    | US5_DecidedC of f0_0 : int32 * f0_1 : bool
and [<Struct>] US6 =
    | US6_FinalC of f0_0 : bool
let rec decide_a_0 (v0 : US0) : US1 =
    match v0 with
    | US0_RawA(v1) -> (* RawA *)
        US1_DecidedA(v1, true)
and decide_b_1 (v0 : US2) : US3 =
    match v0 with
    | US2_RawB(v1) -> (* RawB *)
        US3_DecidedB(true, v1)
and decide_c_2 (v0 : US4) : US5 =
    match v0 with
    | US4_RawC(v1) -> (* RawC *)
        US5_DecidedC(v1, true)
and finalize_c_3 (v0 : US5) : US6 =
    match v0 with
    | US5_DecidedC(v1, v2) -> (* DecidedC *)
        US6_FinalC(v2)
let v0 : int32 = 7
let v1 : US0 = US0_RawA(v0)
let v2 : US1 = decide_a_0(v1)
let v3 : int32 = 9
let v4 : US2 = US2_RawB(v3)
let v5 : US3 = decide_b_1(v4)
let v6 : int32 = 11
let v7 : US4 = US4_RawC(v6)
let v8 : US5 = decide_c_2(v7)
let v9 : US6 = finalize_c_3(v8)
let v12 : bool =
    match v2 with
    | US1_DecidedA(v10, v11) -> (* DecidedA *)
        v11
let v15 : bool =
    match v5 with
    | US3_DecidedB(v13, v14) -> (* DecidedB *)
        v13
let v17 : bool =
    match v9 with
    | US6_FinalC(v16) -> (* FinalC *)
        v16
let v18 : bool = v12 && v15
let v19 : bool = v18 && v17
v19
