type Mut0 = {mutable l0 : string}
let v0 : string = "no"
let v1 : Mut0 = {l0 = v0} : Mut0
let v2 : string = "hi"
v1.l0 <- v2
let v3 : string = v1.l0
let v4 : bool = v3 = "hi"
if v4 then
    0
else
    1
