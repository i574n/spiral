type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
let rec f_c0 (v0 : Heap1) (v1 : int32) : Heap1 =
    let v2 : bool = v1 = 0
    v0
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : (int32 -> Heap1) = f_c0(v4)
let v6 : Heap1 = v5 1
let struct (v7 : Heap0, v8 : int32) = v6.l0, v6.l1
let struct (v9 : int32, v10 : string) = v7.l0, v7.l1
let v11 : bool = v9 = 7
let v13 : bool =
    if v11 then
        let v12 : bool = v10 = "hi"
        v12
    else
        false
let v15 : bool =
    if v13 then
        let v14 : bool = v8 = 1
        v14
    else
        false
if v15 then
    0
else
    1
