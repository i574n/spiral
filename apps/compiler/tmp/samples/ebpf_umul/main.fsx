let v0 : uint32 = 65536u
let v1 : uint32 = 65536u
let v2 : uint32 = 4294967295u
let v3 : uint32 = 3u
let v4 : uint32 = v0 * v1
let v5 : uint32 = v2 * v3
let v6 : bool = v4 = 0u
let v8 : bool =
    if v6 then
        let v7 : bool = v5 = 4294967293u
        v7
    else
        false
if v8 then
    0
else
    1
