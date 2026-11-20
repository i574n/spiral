let v0 : int8 = 100y
let v1 : int8 = 3y
let v2 : int8 = v0 * v1
let v3 : int8 = -8y
let v4 : int8 = 2y
let v5 : int8 = v3 / v4
let v6 : int8 = v3 % v1
let v7 : int8 =  -v1
let v8 : int8 = v0 <<< 1
let v9 : uint8 = 200uy
let v10 : uint8 = 3uy
let v11 : uint8 = v9 / v10
let v12 : uint8 = v9 % v10
let v13 : uint8 = 15uy
let v14 : uint8 = v9 &&& v13
let v15 : uint8 = v9 ||| v13
let v16 : uint8 = v9 ^^^ v13
let v17 : uint8 = ~~~v13
let v18 : int16 = 20000s
let v19 : int16 = 7s
let v20 : int16 = v18 / v19
let v21 : int16 = v18 % v19
let v22 : int16 =  -v18
let v23 : uint16 = 40000us
let v24 : uint16 = v23 <<< 1
let v25 : bool = v2 = 44y
let v27 : bool =
    if v25 then
        let v26 : bool = v5 = -4y
        v26
    else
        false
let v29 : bool =
    if v27 then
        let v28 : bool = v6 = -2y
        v28
    else
        false
let v31 : bool =
    if v29 then
        let v30 : bool = v7 = -3y
        v30
    else
        false
let v33 : bool =
    if v31 then
        let v32 : bool = v8 = -56y
        v32
    else
        false
let v35 : bool =
    if v33 then
        let v34 : bool = v11 = 66uy
        v34
    else
        false
let v37 : bool =
    if v35 then
        let v36 : bool = v12 = 2uy
        v36
    else
        false
let v39 : bool =
    if v37 then
        let v38 : bool = v14 = 8uy
        v38
    else
        false
let v41 : bool =
    if v39 then
        let v40 : bool = v15 = 207uy
        v40
    else
        false
let v43 : bool =
    if v41 then
        let v42 : bool = v16 = 199uy
        v42
    else
        false
let v45 : bool =
    if v43 then
        let v44 : bool = v17 = 240uy
        v44
    else
        false
let v47 : bool =
    if v45 then
        let v46 : bool = v20 = 2857s
        v46
    else
        false
let v49 : bool =
    if v47 then
        let v48 : bool = v21 = 1s
        v48
    else
        false
let v51 : bool =
    if v49 then
        let v50 : bool = v22 = -20000s
        v50
    else
        false
let v53 : bool =
    if v51 then
        let v52 : bool = v24 = 14464us
        v52
    else
        false
if v53 then
    0
else
    1
