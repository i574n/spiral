type Mut0 = {mutable l0 : int32}
let v0 : (Mut0 []) = Array.zeroCreate<Mut0> (1)
let v1 : Mut0 = {l0 = 1} : Mut0
v0.[int 0] <- v1
let v2 : Mut0 = v0.[int 0]
v2.l0 <- 7
let v3 : int32 = v2.l0
let v4 : bool = v3 = 7
if v4 then
    0
else
    1
