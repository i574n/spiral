type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and Heap2 = {l0 : Heap1; l1 : int32}
and Mut0 = {mutable l0 : Heap2}
let v0 : int32 = 3
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : int32 = 2
let v6 : Heap2 = {l0 = v4; l1 = v5} : Heap2
let v7 : Mut0 = {l0 = v6} : Mut0
let v8 : int32 = 7
let v9 : string = "hi"
let v10 : Heap0 = {l0 = v8; l1 = v9} : Heap0
let v11 : int32 = 4
let v12 : Heap1 = {l0 = v10; l1 = v11} : Heap1
let v13 : int32 = 5
let v14 : Heap2 = {l0 = v12; l1 = v13} : Heap2
v7.l0 <- v14
let v15 : Heap2 = v7.l0
let struct (v16 : Heap1, v17 : int32) = v15.l0, v15.l1
let struct (v18 : Heap0, v19 : int32) = v16.l0, v16.l1
let struct (v20 : int32, v21 : string) = v18.l0, v18.l1
let v22 : bool = v20 = 7
let v24 : bool =
    if v22 then
        let v23 : bool = v21 = "hi"
        v23
    else
        false
let v26 : bool =
    if v24 then
        let v25 : bool = v19 = 4
        v25
    else
        false
let v28 : bool =
    if v26 then
        let v27 : bool = v17 = 5
        v27
    else
        false
if v28 then
    0
else
    1
