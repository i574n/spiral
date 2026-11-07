type Heap0 = {l0 : float32; l1 : uint32}
let v0 : float32 = 1.5f
let v1 : uint32 = 4000000000u
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let struct (v3 : float32, v4 : uint32) = v2.l0, v2.l1
let v5 : bool = v3 = 1.5f
let v7 : bool =
    if v5 then
        let v6 : bool = v4 = 4000000000u
        v6
    else
        false
if v7 then
    0
else
    1
