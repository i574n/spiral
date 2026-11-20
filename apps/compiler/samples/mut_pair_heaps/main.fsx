type Heap0 = {l0 : int32; l1 : string}
and Mut0 = {mutable l0 : Heap0; mutable l1 : Heap0}
let v0 : int32 = 1
let v1 : string = "no"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 2
let v4 : string = "zz"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Mut0 = {l0 = v2; l1 = v5} : Mut0
let v7 : int32 = 7
let v8 : string = "hi"
let v9 : Heap0 = {l0 = v7; l1 = v8} : Heap0
let v10 : int32 = 4
let v11 : string = "yo"
let v12 : Heap0 = {l0 = v10; l1 = v11} : Heap0
v6.l0 <- v9
v6.l1 <- v12
let struct (v13 : Heap0, v14 : Heap0) = v6.l0, v6.l1
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
if v25 then
    0
else
    1
