type [<Struct>] US0 =
    | US0_Red
    | US0_Amber
    | US0_Green
let v0 : US0 = US0_Amber
let v1 : int32 = (match v0 with | US0_Red -> 0 | US0_Amber -> 1 | US0_Green -> 2)
v1
