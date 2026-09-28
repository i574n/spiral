type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
    | US0_3
let rec method0 (v0 : US0) : int32 =
    match v0 with
    | US0_0 -> (* Cold *)
        1
    | US0_3 -> (* Done *)
        4
    | US0_2 -> (* Hot *)
        3
    | US0_1 -> (* Warm *)
        2
let v0 : int32 = 3
let v1 : bool = v0 == 0 
let v10 : US0 =
    if v1 then
        US0_0
    else
        let v3 : bool = v0 == 1 
        if v3 then
            US0_1
        else
            let v5 : bool = v0 == 2 
            if v5 then
                US0_2
            else
                US0_3
let v11 : int32 = method0(v10)
let v12 : int32 = v11 - 4 
v12
