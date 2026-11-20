let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let rec empty_middle_0 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 2) (int 1))
    v1
and empty_end_1 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 5) (int 4))
    v1
and empty_source_2 (v0 : string) : string =
    let v1 : string = (spiralStringSlice v0 (int 0) (int -1))
    v1
let v0 : string = "alpha"
let v1 : string = empty_middle_0(v0)
let v2 : string = empty_end_1(v0)
let v3 : string = ""
let v4 : string = empty_source_2(v3)
let v5 : string = (v1 + v2)
let v6 : string = (v4 + "ok")
let v7 : string = (v5 + v6)
let v8 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
let v9 : bool = v8 = 0
if v9 then
    let v10 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v2))
    let v11 : bool = v10 = 0
    if v11 then
        let v12 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v4))
        let v13 : bool = v12 = 0
        if v13 then
            let v14 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v7))
            let v15 : bool = v14 = 2
            if v15 then
                let v16 : char = (spiralStringIndex v7 (int 0))
                let v17 : bool = v16 = 'o'
                if v17 then
                    let v18 : char = (spiralStringIndex v7 (int 1))
                    let v19 : bool = v18 = 'k'
                    if v19 then
                        0
                    else
                        1
                else
                    2
            else
                3
        else
            4
    else
        5
else
    6
