let v0 : int32 = -3
let v1 : int32 = -4
let v2 : int32 = -3
let v3 : uint32 = 4294967295u
let v4 : uint32 = 0u
let v5 : uint32 = 4294967295u
let v6 : float32 = -1.5f
let v7 : float32 = -0.5f
let v8 : float32 = -1.5f
let v9 : bool = v0 <> v1
let v10 : bool = v0 <> v2
let v11 : bool = v3 <> v4
let v12 : bool = v3 <> v5
let v13 : bool = v6 <> v7
let v14 : bool = v6 <> v8
let v15 : bool = v9 && v11
let v16 : bool = v15 && v13
if v16 then
    if v10 then
        1
    else
        if v12 then
            2
        else
            if v14 then
                3
            else
                0
else
    4
