type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
and Heap2 = {l0 : Heap1; l1 : int32}
and Mut0 = {mutable l0 : Heap2}
let v0 : int32 = 1
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 2
let v4 : string = "zz"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let v7 : int32 = 3
let v8 : Heap2 = {l0 = v6; l1 = v7} : Heap2
let v9 : Mut0 = {l0 = v8} : Mut0
let v10 : int32 = 7
let v11 : string = "hi"
let v12 : Heap0 = {l0 = v10; l1 = v11} : Heap0
let v13 : int32 = 4
let v14 : string = "yo"
let v15 : Heap0 = {l0 = v13; l1 = v14} : Heap0
let v16 : Heap1 = {l0 = v12; l1 = v15} : Heap1
let v17 : int32 = 2
let v18 : Heap2 = {l0 = v16; l1 = v17} : Heap2
v9.l0 <- v18
let v19 : Heap2 = v9.l0
let struct (v20 : Heap1, v21 : int32) = v19.l0, v19.l1
let struct (v22 : Heap0, v23 : Heap0) = v20.l0, v20.l1
let struct (v24 : int32, v25 : string) = v22.l0, v22.l1
let struct (v26 : int32, v27 : string) = v23.l0, v23.l1
let v28 : bool = v24 = 7
let v30 : bool =
    if v28 then
        let v29 : bool = v25 = "hi"
        v29
    else
        false
let v32 : bool =
    if v30 then
        let v31 : bool = v26 = 4
        v31
    else
        false
let v34 : bool =
    if v32 then
        let v33 : bool = v27 = "yo"
        v33
    else
        false
let v36 : bool =
    if v34 then
        let v35 : bool = v21 = 2
        v35
    else
        false
if v36 then
    0
else
    1
