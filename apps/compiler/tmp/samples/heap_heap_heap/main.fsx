type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and Heap2 = {l0 : Heap1; l1 : int32}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : int32 = 2
let v6 : Heap2 = {l0 = v4; l1 = v5} : Heap2
let struct (v7 : Heap1, v8 : int32) = v6.l0, v6.l1
let struct (v9 : Heap0, v10 : int32) = v7.l0, v7.l1
let struct (v11 : int32, v12 : string) = v9.l0, v9.l1
let v13 : bool = v11 = 7
let v15 : bool =
    if v13 then
        let v14 : bool = v12 = "hi"
        v14
    else
        false
let v17 : bool =
    if v15 then
        let v16 : bool = v10 = 1
        v16
    else
        false
let v19 : bool =
    if v17 then
        let v18 : bool = v8 = 2
        v18
    else
        false
if v19 then
    0
else
    1
