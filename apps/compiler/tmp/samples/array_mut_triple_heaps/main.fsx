type Heap0 = {l0 : int32; l1 : string}
and Mut0 = {mutable l0 : Heap0; mutable l1 : Heap0; mutable l2 : Heap0}
let v0 : int32 = 1
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 2
let v4 : string = "zz"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : int32 = 3
let v7 : string = "aa"
let v8 : Heap0 = {l0 = v6; l1 = v7} : Heap0
let v9 : Mut0 = {l0 = v2; l1 = v5; l2 = v8} : Mut0
let v10 : (Mut0 []) = Array.zeroCreate<Mut0> (1)
v10.[int 0] <- v9
let v11 : int32 = 7
let v12 : string = "hi"
let v13 : Heap0 = {l0 = v11; l1 = v12} : Heap0
let v14 : int32 = 4
let v15 : string = "yo"
let v16 : Heap0 = {l0 = v14; l1 = v15} : Heap0
let v17 : int32 = 9
let v18 : string = "ok"
let v19 : Heap0 = {l0 = v17; l1 = v18} : Heap0
let v20 : Mut0 = v10.[int 0]
v20.l0 <- v13
v20.l1 <- v16
v20.l2 <- v19
let struct (v21 : Heap0, v22 : Heap0, v23 : Heap0) = v20.l0, v20.l1, v20.l2
let struct (v24 : int32, v25 : string) = v21.l0, v21.l1
let struct (v26 : int32, v27 : string) = v22.l0, v22.l1
let struct (v28 : int32, v29 : string) = v23.l0, v23.l1
let v30 : bool = v24 = 7
let v32 : bool =
    if v30 then
        let v31 : bool = v25 = "hi"
        v31
    else
        false
let v34 : bool =
    if v32 then
        let v33 : bool = v26 = 4
        v33
    else
        false
let v36 : bool =
    if v34 then
        let v35 : bool = v27 = "yo"
        v35
    else
        false
let v38 : bool =
    if v36 then
        let v37 : bool = v28 = 9
        v37
    else
        false
let v40 : bool =
    if v38 then
        let v39 : bool = v29 = "ok"
        v39
    else
        false
if v40 then
    0
else
    1
