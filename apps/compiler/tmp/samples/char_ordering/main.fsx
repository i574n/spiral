let v0 : char = 'a'
let v1 : char = 'b'
let v2 : bool = v0 < v1
if v2 then
    let v3 : bool = v1 > v0
    if v3 then
        let v4 : bool = v0 <= v0
        if v4 then
            0
        else
            3
    else
        2
else
    1
