let rec g_c1 (v0 : string, v1 : int32) (v2 : int32) : string =
    let v3 : bool = v1 = 0
    if v3 then
        let v4 : string = "no"
        v4
    else
        v0
and f_c0 (v0 : string) (v1 : int32) : (int32 -> string) =
    g_c1(v0, v1)
let v0 : string = "hi"
let v1 : (int32 -> (int32 -> string)) = f_c0(v0)
let v2 : (int32 -> string) = v1 1
let v3 : string = v2 0
let v4 : bool = v3 = "hi"
if v4 then
    0
else
    1
