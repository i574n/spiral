type Heap0 = {l0 : uint64; l1 : string}
let v0 : uint64 = 4294967297UL
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let struct (v3 : uint64, v4 : string) = v2.l0, v2.l1
let v5 : bool = v3 = 4294967297UL
let v7 : bool =
    if v5 then
        let v6 : bool = v4 = "hi"
        v6
    else
        false
if v7 then
    0
else
    1
