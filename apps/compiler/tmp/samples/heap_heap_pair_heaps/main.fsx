type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
and Heap2 = {l0 : Heap1; l1 : int32}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let v7 : int32 = 2
let v8 : Heap2 = {l0 = v6; l1 = v7} : Heap2
let struct (v9 : Heap1, v10 : int32) = v8.l0, v8.l1
let struct (v11 : Heap0, v12 : Heap0) = v9.l0, v9.l1
let struct (v13 : int32, v14 : string) = v11.l0, v11.l1
let struct (v15 : int32, v16 : string) = v12.l0, v12.l1
let v17 : bool = v13 = 7
let v19 : bool =
    if v17 then
        let v18 : bool = v14 = "hi"
        v18
    else
        false
let v21 : bool =
    if v19 then
        let v20 : bool = v15 = 4
        v20
    else
        false
let v23 : bool =
    if v21 then
        let v22 : bool = v16 = "yo"
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v10 = 2
        v24
    else
        false
if v25 then
    0
else
    1
