let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let rec first_codepoint_0 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 0) (int 1))
    v1
and second_codepoint_1 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 2) (int 3))
    v1
let v0 : string = "éλ"
let v1 : string = first_codepoint_0(v0)
let v2 : string = second_codepoint_1(v0)
let v3 : string = (v1 + v2)
let v4 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
let v5 : bool = v4 = 2
if v5 then
    let v6 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v2))
    let v7 : bool = v6 = 2
    if v7 then
        let v8 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
        let v9 : bool = v8 = 4
        if v9 then
            0
        else
            1
    else
        2
else
    3
