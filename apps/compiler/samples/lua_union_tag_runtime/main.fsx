type [<Struct>] US0 =
    | US0_Northward
    | US0_Eastward
    | US0_Southward
    | US0_Westward
let v0 : US0 = US0_Southward
let v1 : int32 = (match v0 with | US0_Northward -> 0 | US0_Eastward -> 1 | US0_Southward -> 2 | US0_Westward -> 3)
let v2 : bool = v1 = 2
if v2 then
    0
else
    1
