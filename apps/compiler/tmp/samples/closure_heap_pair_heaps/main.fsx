type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
and Heap2 = {l0 : Heap1; l1 : int32}
let rec f_c0 (v0 : Heap2) (v1 : int32) : Heap2 =
    let v2 : bool = v1 = 0
    v0
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let v7 : int32 = 2
let v8 : Heap2 = {l0 = v6; l1 = v7} : Heap2
let v9 : (int32 -> Heap2) = f_c0(v8)
let v10 : Heap2 = v9 1
let struct (v11 : Heap1, v12 : int32) = v10.l0, v10.l1
let struct (v13 : Heap0, v14 : Heap0) = v11.l0, v11.l1
let struct (v15 : int32, v16 : string) = v13.l0, v13.l1
let struct (v17 : int32, v18 : string) = v14.l0, v14.l1
let v19 : bool = v15 = 7
let v21 : bool =
    if v19 then
        let v20 : bool = v16 = "hi"
        v20
    else
        false
let v23 : bool =
    if v21 then
        let v22 : bool = v17 = 4
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v18 = "yo"
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = v12 = 2
        v26
    else
        false
if v27 then
    0
else
    1
