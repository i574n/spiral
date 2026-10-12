let v0 : uint32 = 4294967295u
let v1 : uint32 = 15u
let v2 : uint32 = v0 &&& v1
let v3 : uint32 = v0 ||| v1
let v4 : uint32 = v0 ^^^ v1
let v5 : uint32 = ~~~v1
let v6 : bool = v2 = 15u
let v8 : bool =
    if v6 then
        let v7 : bool = v3 = v0
        v7
    else
        false
let v10 : bool =
    if v8 then
        let v9 : bool = v4 = v5
        v9
    else
        false
let v12 : bool =
    if v10 then
        let v11 : bool = v5 = 4294967280u
        v11
    else
        false
if v12 then
    0
else
    1
