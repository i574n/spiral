let rec fill_0 (v0 : int32, v1 : (int32 []), v2 : int32) : unit =
    let v3 : bool = v2 < v0
    if v3 then
        v1.[int v2] <- v2
        let v4 : int32 = v2 + 1
        fill_0(v0, v1, v4)
let v0 : int32 = 6
let v1 : (int32 []) = Array.zeroCreate<int32> (6)
let v2 : int32 = 0
fill_0(v0, v1, v2)
let v3 : int32 = v1.[int 5]
let v4 : int32 = v3 + 2
v4
