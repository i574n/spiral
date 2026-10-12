let v0 : int32 = 3
let v1 : int32 = 4
let v2 : uint32 = 1u
let v3 : uint32 = 1u
let v4 : float32 = 1.5f
let v5 : float32 =  -v4
let v6 : bool = v0 = v1
let v7 : bool = v6 <> true
if v7 then
    let v8 : bool = v2 = v3
    let v9 : bool = v8 <> true
    if v9 then
        2
    else
        let v10 : bool = v5 = -1.5f
        if v10 then
            0
        else
            3
else
    1
