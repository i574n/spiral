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
let v10 : (Mut0 []) = Array.zeroCreate<Mut0> (1)
v10.[int 0] <- v9
let v11 : int32 = 7
let v12 : string = "hi"
let v13 : Heap0 = {l0 = v11; l1 = v12} : Heap0
let v14 : int32 = 4
let v15 : string = "yo"
let v16 : Heap0 = {l0 = v14; l1 = v15} : Heap0
let v17 : Heap1 = {l0 = v13; l1 = v16} : Heap1
let v18 : int32 = 2
let v19 : Heap2 = {l0 = v17; l1 = v18} : Heap2
let v20 : Mut0 = v10.[int 0]
v20.l0 <- v19
let v21 : Heap2 = v20.l0
let struct (v22 : Heap1, v23 : int32) = v21.l0, v21.l1
let struct (v24 : Heap0, v25 : Heap0) = v22.l0, v22.l1
let struct (v26 : int32, v27 : string) = v24.l0, v24.l1
let struct (v28 : int32, v29 : string) = v25.l0, v25.l1
let v30 : bool = v26 = 7
let v32 : bool =
    if v30 then
        let v31 : bool = v27 = "hi"
        v31
    else
        false
let v34 : bool =
    if v32 then
        let v33 : bool = v28 = 4
        v33
    else
        false
let v36 : bool =
    if v34 then
        let v35 : bool = v29 = "yo"
        v35
    else
        false
let v38 : bool =
    if v36 then
        let v37 : bool = v23 = 2
        v37
    else
        false
if v38 then
    0
else
    1
