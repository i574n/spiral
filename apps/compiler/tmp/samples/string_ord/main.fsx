let v0 : string = "a"
let v1 : string = "b"
let v2 : string = "é"
let v3 : string = "éx"
let v4 : string = ""
let v5 : bool = v0 < v0
if v5 then
    1
else
    let v6 : bool = v0 < v1
    let v8 : bool =
        if v6 then
            let v7 : bool = v1 < v2
            v7
        else
            false
    let v10 : bool =
        if v8 then
            let v9 : bool = v2 < v3
            v9
        else
            false
    let v12 : bool =
        if v10 then
            let v11 : bool = v4 < v0
            v11
        else
            false
    let v14 : bool =
        if v12 then
            let v13 : bool = v0 <= v0
            v13
        else
            false
    let v16 : bool =
        if v14 then
            let v15 : bool = v0 >= v0
            v15
        else
            false
    let v18 : bool =
        if v16 then
            let v17 : bool = v3 > v2
            v17
        else
            false
    let v20 : bool =
        if v18 then
            let v19 : bool = v1 >= v0
            v19
        else
            false
    if v20 then
        0
    else
        1
