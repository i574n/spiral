type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
and Mut0 = {mutable l0 : Heap1}
let v0 : int32 = 3
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let v5 : Mut0 = {l0 = v4} : Mut0
let v6 : int32 = 7
let v7 : string = "hi"
let v8 : Heap0 = {l0 = v6; l1 = v7} : Heap0
let v9 : int32 = 4
let v10 : Heap1 = {l0 = v8; l1 = v9} : Heap1
v5.l0 <- v10
let v11 : Heap1 = v5.l0
let struct (v12 : Heap0, v13 : int32) = v11.l0, v11.l1
let struct (v14 : int32, v15 : string) = v12.l0, v12.l1
let v16 : bool = v14 = 7
let v18 : bool =
    if v16 then
        let v17 : bool = v15 = "hi"
        v17
    else
        false
let v20 : bool =
    if v18 then
        let v19 : bool = v13 = 4
        v19
    else
        false
if v20 then
    0
else
    1
