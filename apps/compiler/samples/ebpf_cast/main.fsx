let v0 : int32 = 3
let v1 : int32 = -2
let v2 : uint32 = 7u
let v3 : float32 = 2.9f
let v4 : float32 = float32 v0
let v5 : float32 = float32 v1
let v6 : float32 = float32 v2
let v7 : uint32 = uint32 v3
let v8 : bool = v4 = 3.0f
let v10 : bool =
    if v8 then
        let v9 : bool = v5 = -2.0f
        v9
    else
        false
let v12 : bool =
    if v10 then
        let v11 : bool = v6 = 7.0f
        v11
    else
        false
let v14 : bool =
    if v12 then
        let v13 : bool = v7 = 2u
        v13
    else
        false
if v14 then
    0
else
    1
