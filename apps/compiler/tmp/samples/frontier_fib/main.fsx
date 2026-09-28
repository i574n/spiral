let rec method0 (v0 : int32) : int32 =
    let v1 : bool = v0 <= 1
    if v1 then
        v0
    else
        let v2 : int32 = v0 - 1
        let v3 : int32 = method0(v2)
        let v4 : int32 = v0 - 2
        let v5 : int32 = method0(v4)
        let v6 : int32 = v3 + v5
        v6
let v0 : int32 = 10
let v1 : int32 = method0(v0)
let v2 : int32 = v1 - 55
v2
