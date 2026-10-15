let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let v0 : string = "é"
let v1 : string = "x"
let v2 : string = (v0 + v1)
let v3 : string = "éx"
let v4 : string = "éy"
let v5 : string = ""
let v6 : string = (spiralStringSlice v3 (int 1) (int 0))
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
