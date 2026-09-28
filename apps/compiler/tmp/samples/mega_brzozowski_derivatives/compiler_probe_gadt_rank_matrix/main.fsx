type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
and [<Struct>] US1 =
    | US1_1 of f1_0 : int32 * f1_1 : bool
and [<Struct>] US2 =
    | US2_1 of f1_0 : int32
and [<Struct>] US3 =
    | US3_0 of f0_0 : bool * f0_1 : int32
and [<Struct>] US4 =
    | US4_0 of f0_0 : int32
and [<Struct>] US5 =
    | US5_1 of f1_0 : int32 * f1_1 : bool
and [<Struct>] US6 =
    | US6_2 of f2_0 : bool
let rec method0 (v0 : US0) : US1 =
    match v0 with
    | US0_0(v1) -> (* RawA *)
        US1_0(v1, true)
and method1 (v0 : US2) : US3 =
    match v0 with
    | US2_0(v1) -> (* RawB *)
        US3_0(true, v1)
and method2 (v0 : US4) : US5 =
    match v0 with
    | US4_0(v1) -> (* RawC *)
        US5_0(v1, true)
and method3 (v0 : US5) : US6 =
    match v0 with
    | US5_0(v1, v2) -> (* DecidedC *)
        US6_0(v2)
let v0 : int32 = 7
let v1 : US0 = US0_0(v0)
let v2 : US1 = method0(v1)
let v3 : int32 = 9
let v4 : US2 = US2_0(v3)
let v5 : US3 = method1(v4)
let v6 : int32 = 11
let v7 : US4 = US4_0(v6)
let v8 : US5 = method2(v7)
let v9 : US6 = method3(v8)
let v12 : bool =
    match v2 with
    | US1_0(v10, v11) -> (* DecidedA *)
        v11
let v15 : bool =
    match v5 with
    | US3_0(v13, v14) -> (* DecidedB *)
        v13
let v17 : bool =
    match v9 with
    | US6_0(v16) -> (* FinalC *)
        v16
let v18 : bool = v12 && v15
let v19 : bool = v18 && v17
v19
