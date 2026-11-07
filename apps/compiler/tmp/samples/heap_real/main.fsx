type Heap0 = {l0 : float}
let v0 : float = 1.5
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : float = v1.l0
let v3 : bool = v2 = 1.5
if v3 then
    0
else
    1
