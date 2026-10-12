type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let struct (v7 : Heap0, v8 : Heap0) = v6.l0, v6.l1
let struct (v9 : int32, v10 : string) = v7.l0, v7.l1
let struct (v11 : int32, v12 : string) = v8.l0, v8.l1
let v13 : bool = v9 = 7
let v15 : bool =
    if v13 then
        let v14 : bool = v10 = "hi"
        v14
    else
        false
let v17 : bool =
    if v15 then
        let v16 : bool = v11 = 4
        v16
    else
        false
let v19 : bool =
    if v17 then
        let v18 : bool = v12 = "yo"
        v18
    else
        false
if v19 then
    0
else
    1
