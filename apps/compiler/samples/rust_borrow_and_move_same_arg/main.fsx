let rec pick_0 (v0 : string, v1 : string) : string =
    let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v0))
    let v3 : bool = v2 > 2
    if v3 then
        v1
    else
        let v4 : string = ""
        v4
let v0 : string = "abc"
let v1 : string = pick_0(v0, v0)
let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
let v3 : int32 = v2 - 3
v3
