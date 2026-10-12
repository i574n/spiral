let v0 : string = "é"
let v1 : string = "x"
let v2 : string = (v0 + v1)
let v3 : string = "éx"
let v4 : string = "éy"
let v5 : string = ""
let v6 : string = v3.[int 1..int 0]
let v7 : bool = v2 = v3
let v9 : bool =
    if v7 then
        let v8 : bool = v2 <> v4
        v8
    else
        false
let v11 : bool =
    if v9 then
        let v10 : bool = v0 <> v3
        v10
    else
        false
let v13 : bool =
    if v11 then
        let v12 : bool = v5 = v6
        v12
    else
        false
let v15 : bool =
    if v13 then
        let v14 : bool = v5 <> v0
        v14
    else
        false
if v15 then
    0
else
    1
