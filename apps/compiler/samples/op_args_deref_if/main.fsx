type Mut0 = {mutable l0 : string}
let v0 : string = "deref"
let v1 : Mut0 = {l0 = v0} : Mut0
let v2 : int32 = 3
let v3 : string = "deref!"
v1.l0 <- v3
let v4 : string = v1.l0
let v5 : bool = v2 = 3
let v7 : int32 =
    if v5 then
        let v6 : int32 = v2 + 1
        v6
    else
        0
System.Console.Write(v4 + " " + string (v7) + "\n")
let v8 : int32 = v2 * 2
let v9 : bool = v2 > 0
let v10 : int32 =
    if v9 then
        6
    else
        0
let v11 : bool = v8 = v10
if v11 then
    0
else
    1
