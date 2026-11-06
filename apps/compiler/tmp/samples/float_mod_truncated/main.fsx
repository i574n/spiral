let v0 : float = 7.5
let v1 : float = 2.0
let v2 : float = -7.5
let v3 : float = v0 % v1
let v4 : bool = v3 = 1.5
let v7 : bool =
    if v4 then
        let v5 : float = v2 % v1
        let v6 : bool = v5 = -1.5
        v6
    else
        false
if v7 then
    15
else
    1
