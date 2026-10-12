type [<Struct>] US0 =
    | US0_Text of f0_0 : string
    | US0_Code of f1_0 : int32
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Code(v4) -> (* Code *)
        v4
    | US0_Text(v1) -> (* Text *)
        let v2 : bool = v1 = "hi"
        if v2 then
            2
        else
            3
let v0 : bool = true
let v1 : string = "hi"
let v4 : US0 =
    if v0 then
        US0_Text(v1)
    else
        US0_Code(1)
let v7 : US0 =
    if v0 then
        US0_Code(5)
    else
        US0_Text(v1)
let v8 : int32 = score_0(v4)
let v9 : bool = v8 = 2
let v12 : bool =
    if v9 then
        let v10 : int32 = score_0(v7)
        let v11 : bool = v10 = 5
        v11
    else
        false
if v12 then
    0
else
    1
