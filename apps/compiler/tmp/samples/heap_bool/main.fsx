type Heap0 = {l0 : bool}
let v0 : bool = true
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : bool = v1.l0
if v2 then
    0
else
    1
