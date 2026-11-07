type Mut0 = {mutable l0 : float; mutable l1 : string}
let v0 : float = 1.5
let v1 : string = "no"
let v2 : Mut0 = {l0 = v0; l1 = v1} : Mut0
let v3 : float = 2.5
let v4 : string = "hi"
v2.l0 <- v3
v2.l1 <- v4
let struct (v5 : float, v6 : string) = v2.l0, v2.l1
let v7 : bool = v5 = 2.5
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
