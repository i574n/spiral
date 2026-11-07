let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let rec middle_0 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 1) (int 3))
    v1
let v0 : string = "alpha"
let v1 : string = middle_0(v0)
let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
let v3 : bool = v2 = 3
if v3 then
    let v4 : char = (spiralStringIndex v1 (int 0))
    let v5 : bool = v4 = 'l'
    if v5 then
        let v6 : char = (spiralStringIndex v1 (int 2))
        let v7 : bool = v6 = 'h'
        if v7 then
            0
        else
            1
    else
        2
else
    3
