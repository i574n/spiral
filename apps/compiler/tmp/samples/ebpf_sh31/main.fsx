let v0 : uint32 = 1u
let v1 : int32 = 0
let v2 : int32 = 31
let v3 : uint32 = v0 <<< v2
let v4 : uint32 = v3 >>> v2
let v5 : uint32 = v0 <<< v1
let v6 : bool = v3 = 2147483648u
let v8 : bool =
    if v6 then
        let v7 : bool = v4 = 1u
        v7
    else
        false
let v10 : bool =
    if v8 then
        let v9 : bool = v5 = 1u
        v9
    else
        false
if v10 then
    0
else
    1
