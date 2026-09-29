let rec method0 () : bool =
    true
let v0 : int32 = 0
let v1 : int32 = 0
while method0() do
    let v2 : int32 = v0 + 1
    v0 <- v2
    let v3 : bool = v0 < 3
    if v3 then
        continue
        ()
    else
        let v4 : bool = v0 >= 6
        if v4 then
            break
            ()
        else
            let v5 : int32 = v1 + v0
            v1 <- v5
            ()
let v6 : int32 = v1 - 12
v6
