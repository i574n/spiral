let v0 : int8 = -128y
let v1 : int16 = -32768s
let v2 : int32 = -5
let v3 : int64 = -1234567890123L
let v4 : uint8 = 255uy
let v5 : uint16 = 65535us
let v6 : uint32 = 4294967295u
let v7 : uint64 = 18446744073709551615UL
let v8 : bool = true
let v9 : bool = false
let v10 : char = 'a'
let v11 : string = (string (v0))
let v12 : bool = v11 = "-128"
let v13 : int32 =
    if v12 then
        0
    else
        1
let v14 : string = (string (v1))
let v15 : bool = v14 = "-32768"
let v16 : int32 =
    if v15 then
        0
    else
        1
let v17 : int32 = v13 + v16
let v18 : string = (string (v2))
let v19 : bool = v18 = "-5"
let v20 : int32 =
    if v19 then
        0
    else
        1
let v21 : int32 = v17 + v20
let v22 : string = (string (v3))
let v23 : bool = v22 = "-1234567890123"
let v24 : int32 =
    if v23 then
        0
    else
        1
let v25 : int32 = v21 + v24
let v26 : string = (string (v4))
let v27 : bool = v26 = "255"
let v28 : int32 =
    if v27 then
        0
    else
        1
let v29 : int32 = v25 + v28
let v30 : string = (string (v5))
let v31 : bool = v30 = "65535"
let v32 : int32 =
    if v31 then
        0
    else
        1
let v33 : int32 = v29 + v32
let v34 : string = (string (v6))
let v35 : bool = v34 = "4294967295"
let v36 : int32 =
    if v35 then
        0
    else
        1
let v37 : int32 = v33 + v36
let v38 : string = (string (v7))
let v39 : bool = v38 = "18446744073709551615"
let v40 : int32 =
    if v39 then
        0
    else
        1
let v41 : int32 = v37 + v40
let v42 : string = (if v8 then "true" else "false")
let v43 : bool = v42 = "true"
let v44 : int32 =
    if v43 then
        0
    else
        1
let v45 : int32 = v41 + v44
let v46 : string = (if v9 then "true" else "false")
let v47 : bool = v46 = "false"
let v48 : int32 =
    if v47 then
        0
    else
        1
let v49 : int32 = v45 + v48
let v50 : string = (string (v10))
let v51 : bool = v50 = "a"
let v52 : int32 =
    if v51 then
        0
    else
        1
let v53 : int32 = v49 + v52
let v54 : string = (string (7uy))
let v55 : bool = v54 = "7"
let v56 : int32 =
    if v55 then
        0
    else
        1
let v57 : int32 = v53 + v56
let v58 : string = (if false then "true" else "false")
let v59 : bool = v58 = "false"
let v60 : int32 =
    if v59 then
        0
    else
        1
let v61 : int32 = v57 + v60
let v62 : string = (string ('z'))
let v63 : bool = v62 = "z"
let v64 : int32 =
    if v63 then
        0
    else
        1
let v65 : int32 = v61 + v64
let v66 : string = (string (-3L))
let v67 : bool = v66 = "-3"
let v68 : int32 =
    if v67 then
        0
    else
        1
let v69 : int32 = v65 + v68
v69
