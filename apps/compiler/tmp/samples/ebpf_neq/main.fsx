let v0 : int32 = 3
let v1 : int32 = 4
let v2 : uint32 = 1u
let v3 : uint32 = 1u
let v4 : float32 = 1.5f
let v5 : float32 =  -v4
let v6 : bool = v0 <> v1
if v6 then
    let v7 : bool = v2 <> v3
    if v7 then
        2
    else
        let v8 : bool = v5 = -1.5f
        if v8 then
            0
        else
            3
else
    1
