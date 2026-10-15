let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let v0 : string = "é"
let v1 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v0))
let v2 : char = (spiralStringIndex v0 (int 0))
let v3 : char = (spiralStringIndex v0 (int 1))
let v4 : string = "x"
let v5 : string = (v0 + v4)
let v6 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v5))
let v7 : string = "ab"
let v8 : char = (spiralStringIndex v7 (int 0))
let v9 : string = (spiralStringSlice v7 (int 0) (int 0))
let v10 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v9))
let v11 : string = (spiralStringSlice v7 (int 1) (int 0))
let v12 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v11))
let v13 : string = (spiralStringSlice v0 (int 0) (int 1))
let v14 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v13))
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
