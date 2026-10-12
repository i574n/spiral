type Heap0 = {l0 : float32; l1 : string}
let rec f_c0 (v0 : Heap0) (v1 : int32) : Heap0 =
    let v2 : bool = v1 = 0
    v0
let v0 : float32 = 1.5f
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : (int32 -> Heap0) = f_c0(v2)
let v4 : Heap0 = v3 1
let struct (v5 : float32, v6 : string) = v4.l0, v4.l1
let v7 : bool = v5 = 1.5f
let v9 : bool =
    if v7 then
        let v8 : bool = v6 = "hi"
        v8
    else
        false
if v9 then
    0
else
    1
