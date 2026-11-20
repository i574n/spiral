let v0 : int32 = 7
let v1 : int32 = -2
let v2 : int32 = -7
let v3 : uint32 = 100u
let v4 : uint32 = 7u
let v5 : int32 = v0 / v1
let v6 : int32 = v0 % v1
let v7 : int32 = v2 / v1
let v8 : int32 = v2 % v1
let v9 : uint32 = v3 / v4
let v10 : uint32 = v3 % v4
let v11 : bool = v5 = -3
let v13 : bool =
    if v11 then
        let v12 : bool = v6 = 1
        v12
    else
        false
let v15 : bool =
    if v13 then
        let v14 : bool = v7 = 3
        v14
    else
        false
let v17 : bool =
    if v15 then
        let v16 : bool = v8 = -1
        v16
    else
        false
let v19 : bool =
    if v17 then
        let v18 : bool = v9 = 14u
        v18
    else
        false
let v21 : bool =
    if v19 then
        let v20 : bool = v10 = 2u
        v20
    else
        false
if v21 then
    0
else
    1
