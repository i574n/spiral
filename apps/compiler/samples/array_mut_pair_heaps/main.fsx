type Heap0 = {l0 : int32; l1 : string}
and Mut0 = {mutable l0 : Heap0; mutable l1 : Heap0}
let v0 : int32 = 1
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 2
let v4 : string = "zz"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Mut0 = {l0 = v2; l1 = v5} : Mut0
let v7 : (Mut0 []) = Array.zeroCreate<Mut0> (1)
v7.[int 0] <- v6
let v8 : int32 = 7
let v9 : string = "hi"
let v10 : Heap0 = {l0 = v8; l1 = v9} : Heap0
let v11 : int32 = 4
let v12 : string = "yo"
let v13 : Heap0 = {l0 = v11; l1 = v12} : Heap0
let v14 : Mut0 = v7.[int 0]
v14.l0 <- v10
v14.l1 <- v13
let struct (v15 : Heap0, v16 : Heap0) = v14.l0, v14.l1
let struct (v17 : int32, v18 : string) = v15.l0, v15.l1
let struct (v19 : int32, v20 : string) = v16.l0, v16.l1
let v21 : bool = v17 = 7
let v23 : bool =
    if v21 then
        let v22 : bool = v18 = "hi"
        v22
    else
        false
let v25 : bool =
    if v23 then
        let v24 : bool = v19 = 4
        v24
    else
        false
let v27 : bool =
    if v25 then
        let v26 : bool = v20 = "yo"
        v26
    else
        false
if v27 then
    0
else
    1
