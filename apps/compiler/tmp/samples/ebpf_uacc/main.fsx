let rec method1 (v0 : int32, v1 : uint32) : uint32 =
    let v2 : int32 = v0 - 1
    let v3 : uint32 = v1 + 3000000000u
    let v4 : bool = v2 = 0
    if v4 then
        v3
    else
        method1(v2, v3)
and method0 (v0 : int32, v1 : uint32) : uint32 =
    let v2 : bool = v0 = 0
    if v2 then
        v1
    else
        method1(v0, v1)
let v0 : int32 = 2
let v1 : uint32 = 0u
let v2 : uint32 = method0(v0, v1)
let v3 : bool = v2 = 1705032704u
if v3 then
    0
else
    1
