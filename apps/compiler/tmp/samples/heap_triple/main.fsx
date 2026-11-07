type Heap0 = {l0 : int32; l1 : string; l2 : bool}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : bool = true
let v3 : Heap0 = {l0 = v0; l1 = v1; l2 = v2} : Heap0
let struct (v4 : int32, v5 : string, v6 : bool) = v3.l0, v3.l1, v3.l2
let v7 : bool = v4 = 7
let v9 : bool =
    if v7 then
        let v8 : bool = v5 = "hi"
        v8
    else
        false
let v10 : bool = v9 && v6
if v10 then
    0
else
    1
