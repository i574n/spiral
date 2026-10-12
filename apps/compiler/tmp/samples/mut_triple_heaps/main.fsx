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
let v10 : int32 = 7
let v11 : string = "hi"
let v12 : Heap0 = {l0 = v10; l1 = v11} : Heap0
let v13 : int32 = 4
let v14 : string = "yo"
let v15 : Heap0 = {l0 = v13; l1 = v14} : Heap0
let v16 : int32 = 9
let v17 : string = "ok"
let v18 : Heap0 = {l0 = v16; l1 = v17} : Heap0
v9.l0 <- v12
v9.l1 <- v15
v9.l2 <- v18
let struct (v19 : Heap0, v20 : Heap0, v21 : Heap0) = v9.l0, v9.l1, v9.l2
let struct (v22 : int32, v23 : string) = v19.l0, v19.l1
let struct (v24 : int32, v25 : string) = v20.l0, v20.l1
let struct (v26 : int32, v27 : string) = v21.l0, v21.l1
let v28 : bool = v22 = 7
let v30 : bool =
    if v28 then
        let v29 : bool = v23 = "hi"
        v29
    else
        false
let v32 : bool =
    if v30 then
        let v31 : bool = v24 = 4
        v31
    else
        false
let v34 : bool =
    if v32 then
        let v33 : bool = v25 = "yo"
        v33
    else
        false
let v36 : bool =
    if v34 then
        let v35 : bool = v26 = 9
        v35
    else
        false
let v38 : bool =
    if v36 then
        let v37 : bool = v27 = "ok"
        v37
    else
        false
if v38 then
    0
else
    1
