let v0 : float32 = 1.5f
let v1 : float32 = -2.0f
let v2 : float32 = -0.5f
let v3 : float32 = v0 / v1
let v4 : float32 = v2 / v1
let v5 : bool = v3 = -0.75f
let v7 : bool =
    if v5 then
        let v6 : bool = v4 = 0.25f
        v6
    else
        false
if v7 then
    0
else
    1
