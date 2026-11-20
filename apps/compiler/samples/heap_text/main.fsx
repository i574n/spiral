type Heap0 = {l0 : string}
let v0 : string = "hi"
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : string = v1.l0
let v3 : bool = v2 = "hi"
if v3 then
    0
else
    1
