type Heap0 = {l0 : bool; l1 : string}
let v0 : bool = true
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let struct (v3 : bool, v4 : string) = v2.l0, v2.l1
let v6 : bool =
    if v3 then
        let v5 : bool = v4 = "hi"
        v5
    else
        false
if v6 then
    0
else
    1
