let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let rec choose_left_0 (v0 : bool) : string =
    if v0 then
        let v1 : string = "spi"
        v1
    else
        let v2 : string = "bad"
        v2
and choose_right_1 (v0 : bool) : string =
    if v0 then
        let v1 : string = "bad"
        v1
    else
        let v2 : string = "ral"
        v2
let v0 : bool = true
let v1 : string = choose_left_0(v0)
let v2 : bool = false
let v3 : string = choose_right_1(v2)
let v4 : string = (v1 + v3)
let v5 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v4))
let v6 : bool = v5 = 6
if v6 then
    let v7 : char = (spiralStringIndex v4 (int 0))
    let v8 : bool = v7 = 's'
    if v8 then
        let v9 : char = (spiralStringIndex v4 (int 5))
        let v10 : bool = v9 = 'l'
        if v10 then
            0
        else
            1
    else
        2
else
    3
