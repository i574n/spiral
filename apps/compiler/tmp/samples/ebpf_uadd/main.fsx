let v0 : uint32 = 2147483647u
let v1 : uint32 = 2u
let v2 : uint32 = 1u
let v3 : uint32 = v0 + v1
let v4 : uint32 = v0 + v2
let v5 : bool = v3 = 2147483649u
let v7 : bool =
    if v5 then
        let v6 : bool = v4 = 2147483648u
        v6
    else
        false
if v7 then
    0
else
    1
