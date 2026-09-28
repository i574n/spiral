let rec method0 () : bool =
    true
let v0 : int32 = 0
let v1 : int32 = 0
while method0() do
    let v3 : int32 = v0 + 1
    v0 = v3
    let v4 : bool = v0 < 3
    if v4 then
        continue
        ()
    else
        let v5 : bool = v0 >= 6
        if v5 then
            break
            ()
        else
            let v6 : int32 = v1 + v0
            v1 = v6
            ()
let v7 : int32 = v1 - 12
v7
