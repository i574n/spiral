let v0 : string = "é"
let v1 : int32 = v0.Length
let v2 : char = v0.[int 0]
let v3 : char = v0.[int 1]
let v4 : string = "x"
let v5 : string = (v0 + v4)
let v6 : int32 = v5.Length
let v7 : string = "ab"
let v8 : char = v7.[int 0]
let v9 : string = v7.[int 0..int 0]
let v10 : int32 = v9.Length
let v11 : string = v7.[int 1..int 0]
let v12 : int32 = v11.Length
let v13 : string = v0.[int 0..int 1]
let v14 : int32 = v13.Length
let v15 : bool = v2 = v3
if v15 then
    1
else
    let v16 : bool = v1 = 2
    let v18 : bool =
        if v16 then
            let v17 : bool = v8 = 'a'
            v17
        else
            false
    let v20 : bool =
        if v18 then
            let v19 : bool = v6 = 3
            v19
        else
            false
    let v22 : bool =
        if v20 then
            let v21 : bool = v10 = 1
            v21
        else
            false
    let v24 : bool =
        if v22 then
            let v23 : bool = v12 = 0
            v23
        else
            false
    let v26 : bool =
        if v24 then
            let v25 : bool = v14 = 2
            v25
        else
            false
    if v26 then
        0
    else
        1
