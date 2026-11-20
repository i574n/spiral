let rec measure_0 (v0 : string) : int32 =
    let v1 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v0))
    v1
let v0 : string = "qwe"
let v1 : int32 = measure_0(v0)
let v2 : int32 = measure_0(v0)
let v3 : int32 = v1 + v2
let v4 : int32 = v3 - 6
v4
