let v0 : char = 'A'
let v1 : char = 'B'
let v2 : bool = v0 = 'A'
if v2 then
    let v3 : bool = v1 = 'B'
    if v3 then
        let v4 : bool = v0 = v1
        if v4 then
            2
        else
            0
    else
        3
else
    1
