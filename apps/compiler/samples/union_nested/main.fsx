type [<Struct>] US1 =
    | US1_A of f0_0 : int32
    | US1_B of f1_0 : int32
and [<Struct>] US0 =
    | US0_Wrap of f0_0 : US1
    | US0_Other of f1_0 : int32
let rec score_inner_1 (v0 : US1) : int32 =
    match v0 with
    | US1_A(v1) -> (* A *)
        v1
    | US1_B(v2) -> (* B *)
        let v3 : int32 =  -v2
        v3
and score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Other(v3) -> (* Other *)
        v3
    | US0_Wrap(v1) -> (* Wrap *)
        score_inner_1(v1)
let v0 : bool = true
let v4 : US0 =
    if v0 then
        let v1 : US1 = US1_A(7)
        US0_Wrap(v1)
    else
        US0_Other(1)
let v8 : US0 =
    if v0 then
        US0_Other(4)
    else
        let v6 : US1 = US1_B(2)
        US0_Wrap(v6)
let v9 : int32 = score_0(v4)
let v10 : bool = v9 = 7
let v13 : bool =
    if v10 then
        let v11 : int32 = score_0(v8)
        let v12 : bool = v11 = 4
        v12
    else
        false
if v13 then
    0
else
    1
