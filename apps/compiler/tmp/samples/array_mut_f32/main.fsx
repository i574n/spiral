type Mut0 = {mutable l0 : float32; mutable l1 : string}
let v0 : float32 = 1.5f
let v1 : string = "no"
let v2 : Mut0 = {l0 = v0; l1 = v1} : Mut0
let v3 : (Mut0 []) = Array.zeroCreate<Mut0> (1)
v3.[int 0] <- v2
let v4 : Mut0 = v3.[int 0]
let v5 : float32 = 2.5f
let v6 : string = "hi"
v4.l0 <- v5
v4.l1 <- v6
let struct (v7 : float32, v8 : string) = v4.l0, v4.l1
let v9 : bool = v7 = 2.5f
let v11 : bool =
    if v9 then
        let v10 : bool = v8 = "hi"
        v10
    else
        false
if v11 then
    0
else
    1
