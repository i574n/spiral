let rec choose_0 (v0 : bool) : string =
    if v0 then
        let v1 : string = "alpha"
        v1
    else
        let v2 : string = "beta"
        v2
and measure_1 (v0 : string) : int32 =
    let v1 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v0))
    v1
let v0 : bool = true
let v1 : string = choose_0(v0)
let v2 : bool = false
let v3 : string = choose_0(v2)
let v4 : int32 = measure_1(v1)
let v5 : int32 = measure_1(v1)
let v6 : int32 = v4 + v5
let v7 : int32 = measure_1(v3)
let v8 : int32 = v6 + v7
let v9 : int32 = v8 - 14
v9
