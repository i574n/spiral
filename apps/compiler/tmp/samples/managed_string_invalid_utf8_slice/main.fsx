let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let rec invalid_middle_0 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 1) (int 1))
    v1
let v0 : string = "é"
let v1 : string = invalid_middle_0(v0)
let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
v2
