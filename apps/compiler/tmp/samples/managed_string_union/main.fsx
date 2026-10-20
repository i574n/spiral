type [<Struct>] US0 =
    | US0_Text of f0_0 : string
    | US0_Number of f1_0 : int32
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Number(v3) -> (* Number *)
        v3
    | US0_Text(v1) -> (* Text *)
        let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
        v2
let v0 : bool = false
let v4 : US0 =
    if v0 then
        US0_Number(7)
    else
        let v2 : string = "qwe"
        US0_Text(v2)
let v5 : int32 = score_0(v4)
let v6 : int32 = score_0(v4)
let v7 : int32 = v5 + v6
let v8 : int32 = v7 - 6
v8
