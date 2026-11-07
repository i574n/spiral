let v0 : float = 1.5
let v1 : float = -2.0
let v2 : float = v0 / v1
let v3 : float = 1000000.0
let v4 : float = v3 * v3
let v5 : float = v4 * v3
let v6 : float = v5 * 10000.0
let v7 : float = v6 * v6
let v8 : int32 = 3
let v9 : float = float v8
let v10 : float = 2.9
let v11 : float = -1.9
let v12 : int32 = int32 v10
let v13 : int32 = int32 v11
let v14 : float32 = 1.5f
let v15 : float = float v14
let v16 : bool = v2 = -0.75
let v18 : bool =
    if v16 then
        let v17 : bool = v7 > v6
        v17
    else
        false
let v21 : bool =
    if v18 then
        let v19 : float = v7 * v6
        let v20 : bool = v7 < v19
        v20
    else
        false
let v23 : bool =
    if v21 then
        let v22 : bool = v9 = 3.0
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v12 = 2
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = v13 = -1
        v26
    else
        false
let v29 : bool =
    if v27 then
        let v28 : bool = v15 = 1.5
        v28
    else
        false
if v29 then
    0
else
    1
