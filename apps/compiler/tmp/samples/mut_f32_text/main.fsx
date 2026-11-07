type Mut0 = {mutable l0 : float32; mutable l1 : string}
let v0 : float32 = 1.5f
let v1 : string = "no"
let v2 : Mut0 = {l0 = v0; l1 = v1} : Mut0
let v3 : float32 = 2.5f
let v4 : string = "hi"
v2.l0 <- v3
v2.l1 <- v4
let struct (v5 : float32, v6 : string) = v2.l0, v2.l1
let v7 : bool = v5 = 2.5f
let v9 : bool =
    if v7 then
        let v8 : bool = v6 = "hi"
        v8
    else
        false
if v9 then
    0
else
    1
