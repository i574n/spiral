let rec method0 (v0 : string) : struct (string * int32) =
    let v1 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v0))
    struct (v0, v1)
and score_1 (v0 : int32, v1 : string) : int32 =
    let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
    let v3 : int32 = v2 + v0
    v3
let v0 : string = "qwe"
let struct (v1 : string, v2 : int32) = method0(v0)
let v3 : int32 = score_1(v2, v1)
let v4 : int32 = score_1(v2, v1)
let v5 : int32 = v3 + v4
let v6 : int32 = v5 - 12
v6
