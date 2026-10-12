type Heap0 = {l0 : int8}
let v0 : int8 = 100y
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : int8 = v1.l0
let v3 : bool = v2 = 100y
if v3 then
    0
else
    1
