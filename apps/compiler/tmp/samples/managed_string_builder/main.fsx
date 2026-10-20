let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let rec method2 (v0 : int32, v1 : string, v2 : string) : string =
    let v3 : int32 = v0 - 1
    let v4 : string = (v1 + v2)
    let v5 : bool = v3 = 0
    if v5 then
        v4
    else
        let v6 : int32 = v3 % 2
        let v7 : bool = v6 = 0
        let v10 : string =
            if v7 then
                let v8 : string = "ab"
                v8
            else
                let v9 : string = "c"
                v9
        method2(v3, v4, v10)
and method1 (v0 : int32, v1 : string) : string =
    let v2 : int32 = v0 - 1
    let v3 : string = ("" + v1)
    let v4 : bool = v2 = 0
    if v4 then
        v3
    else
        let v5 : int32 = v2 % 2
        let v6 : bool = v5 = 0
        let v9 : string =
            if v6 then
                let v7 : string = "ab"
                v7
            else
                let v8 : string = "c"
                v8
        method2(v2, v3, v9)
and method0 () : string =
    let v0 : int32 = 4
    let v1 : bool = v0 = 0
    if v1 then
        let v2 : string = ""
        v2
    else
        let v3 : int32 = v0 % 2
        let v4 : bool = v3 = 0
        let v7 : string =
            if v4 then
                let v5 : string = "ab"
                v5
            else
                let v6 : string = "c"
                v6
        method1(v0, v7)
let v0 : string = method0()
let v1 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v0))
let v2 : bool = v1 = 6
if v2 then
    let v3 : char = (spiralStringIndex v0 (int 0))
    let v4 : bool = v3 = 'a'
    if v4 then
        let v5 : char = (spiralStringIndex v0 (int 5))
        let v6 : bool = v5 = 'c'
        if v6 then
            0
        else
            1
    else
        2
else
    3
