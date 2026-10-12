type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : int32}
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 1
let v4 : Heap1 = {l0 = v2; l1 = v3} : Heap1
let struct (v5 : Heap0, v6 : int32) = v4.l0, v4.l1
let struct (v7 : int32, v8 : string) = v5.l0, v5.l1
let v9 : bool = v7 = 7
let v11 : bool =
    if v9 then
        let v10 : bool = v8 = "hi"
        v10
    else
        false
let v13 : bool =
    if v11 then
        let v12 : bool = v6 = 1
        v12
    else
        false
if v13 then
    0
else
    1
