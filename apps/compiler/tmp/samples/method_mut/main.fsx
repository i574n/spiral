type Mut0 = {mutable l0 : int32}
let rec method0 (v0 : Mut0) : Mut0 =
    v0
let v0 : Mut0 = {l0 = 1} : Mut0
let v1 : Mut0 = method0(v0)
v1.l0 <- 7
let v2 : int32 = v1.l0
let v3 : bool = v2 = 7
if v3 then
    0
else
    1
