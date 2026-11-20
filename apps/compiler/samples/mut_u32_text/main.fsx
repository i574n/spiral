type Mut0 = {mutable l0 : uint32; mutable l1 : string}
let v0 : uint32 = 1u
let v1 : string = "no"
let v2 : Mut0 = {l0 = v0; l1 = v1} : Mut0
let v3 : uint32 = 4000000000u
let v4 : string = "hi"
v2.l0 <- v3
v2.l1 <- v4
let struct (v5 : uint32, v6 : string) = v2.l0, v2.l1
let v7 : bool = v5 = 4000000000u
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
