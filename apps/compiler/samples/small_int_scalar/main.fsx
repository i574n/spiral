let v0 : int8 = 100y
let v1 : int8 = v0 + v0
let v2 : uint8 = 200uy
let v3 : uint8 = 100uy
let v4 : uint8 = v2 + v3
let v5 : int8 = -8y
let v6 : int8 = v5 >>> 1
let v7 : uint8 = v2 >>> 1
let v8 : int16 = 20000s
let v9 : int16 = v8 + v8
let v10 : uint16 = 40000us
let v11 : uint16 = v10 + v10
let v12 : int32 = 7
let v13 : int8 = int8 v12
let v14 : int8 = 9y
let v15 : int32 = int32 v14
let v16 : bool = v1 = -56y
let v18 : bool =
    if v16 then
        let v17 : bool = v4 = 44uy
        v17
    else
        false
let v20 : bool =
    if v18 then
        let v19 : bool = v6 = -4y
        v19
    else
        false
let v22 : bool =
    if v20 then
        let v21 : bool = v7 = 100uy
        v21
    else
        false
let v24 : bool =
    if v22 then
        let v23 : bool = v9 = -25536s
        v23
    else
        false
let v26 : bool =
    if v24 then
        let v25 : bool = v11 = 14464us
        v25
    else
        false
let v28 : bool =
    if v26 then
        let v27 : bool = v13 = 7y
        v27
    else
        false
let v30 : bool =
    if v28 then
        let v29 : bool = v15 = 9
        v29
    else
        false
if v30 then
    0
else
    1
