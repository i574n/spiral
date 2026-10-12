type Heap0 = {l0 : int32}
and Heap1 = {l0 : Heap0}
let v0 : int32 = 7
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : Heap1 = {l0 = v1} : Heap1
let v3 : Heap0 = v2.l0
let v4 : int32 = v3.l0
let v5 : bool = v4 = 7
if v5 then
    0
else
    1
