let v0 : float32 = 0.0f
let v1 : float32 = 1.0f
let v2 : float32 = 4.0f
let v3 : float32 = 3.0f
let v4 : float32 = infinityf
let v5 : float32 = v4 - v4
let v6 : float32 = sqrt v2
let v7 : bool = v6 = 2.0f
let v10 : bool =
    if v7 then
        let v8 : float32 = exp v0
        let v9 : bool = v8 = v1
        v9
    else
        false
let v13 : bool =
    if v10 then
        let v11 : float32 = log v1
        let v12 : bool = v11 = v0
        v12
    else
        false
let v16 : bool =
    if v13 then
        let v14 : float32 = sin v0
        let v15 : bool = v14 = v0
        v15
    else
        false
let v19 : bool =
    if v16 then
        let v17 : float32 = cos v0
        let v18 : bool = v17 = v1
        v18
    else
        false
let v22 : bool =
    if v19 then
        let v20 : float32 = tanh v0
        let v21 : bool = v20 = v0
        v21
    else
        false
let v25 : bool =
    if v22 then
        let v23 : float32 = v3 ** v1
        let v24 : bool = v23 = v3
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = System.Single.IsNaN(v5)
        v26
    else
        false
if v27 then
    let v28 : bool = System.Single.IsNaN(v1)
    if v28 then
        2
    else
        0
else
    1
