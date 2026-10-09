type [<Struct>] US0 =
    | US0_Cold
    | US0_Warm
    | US0_Hot
    | US0_Done
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Cold -> (* Cold *)
        1
    | US0_Done -> (* Done *)
        4
    | US0_Hot -> (* Hot *)
        3
    | US0_Warm -> (* Warm *)
        2
let v0 : int32 = 3
let v1 : bool = v0 = 0
let v10 : US0 =
    if v1 then
        US0_Cold
    else
        let v3 : bool = v0 = 1
        if v3 then
            US0_Warm
        else
            let v5 : bool = v0 = 2
            if v5 then
                US0_Hot
            else
                US0_Done
let v11 : int32 = score_0(v10)
let v12 : int32 = v11 - 4
v12
