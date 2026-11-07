let v0 : float32 = -2.0f
let v1 : float32 = -1.0f
let v2 : float32 = 0.0f
let v3 : bool = v0 < v1
let v5 : bool =
    if v3 then
        let v4 : bool = v1 < v2
        v4
    else
        false
let v8 : bool =
    if v5 then
        let v6 : bool = v0 > v1
        let v7 : bool = v6 = false
        v7
    else
        false
let v11 : bool =
    if v8 then
        let v9 : bool = v0 >= v1
        let v10 : bool = v9 = false
        v10
    else
        false
let v13 : bool =
    if v11 then
        let v12 : bool = v1 <= v2
        v12
    else
        false
if v13 then
    0
else
    1
