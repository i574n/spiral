let rec count_0 (v0 : int32) : int32 =
    let v1 : bool = v0 <= 0
    if v1 then
        0
    else
        let v2 : int32 = v0 - 1
        count_0(v2)
let v0 : int32 = 5
count_0(v0)
