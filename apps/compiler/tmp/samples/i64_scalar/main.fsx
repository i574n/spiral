let v0 : int64 = 5000000000L
let v1 : int64 = -4L
let v2 : int64 = v0 / v1
let v3 : int64 = 1000000L
let v4 : int64 = v3 * v3
let v5 : int64 = -8L
let v6 : int64 = v5 >>> 1
let v7 : int32 = 7
let v8 : int64 = int64 v7
let v9 : int64 = 9L
let v10 : int32 = int32 v9
let v11 : uint64 = 4294967296UL
let v12 : uint64 = v11 + 1UL
let v13 : uint64 = v11 >>> 1
let v14 : uint64 = uint64 v7
let v15 : bool = v2 = -1250000000L
let v17 : bool =
    if v15 then
        let v16 : bool = v4 = 1000000000000L
        v16
    else
        false
let v19 : bool =
    if v17 then
        let v18 : bool = v6 = -4L
        v18
    else
        false
let v21 : bool =
    if v19 then
        let v20 : bool = v8 = 7L
        v20
    else
        false
let v23 : bool =
    if v21 then
        let v22 : bool = v10 = 9
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v12 = 4294967297UL
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = v13 = 2147483648UL
        v26
    else
        false
let v29 : bool =
    if v27 then
        let v28 : bool = v14 = 7UL
        v28
    else
        false
if v29 then
    0
else
    1
