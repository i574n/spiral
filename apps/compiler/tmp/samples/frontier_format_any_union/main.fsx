type Mut0 = {mutable l0 : string}
let rec method2 () : string =
    let v0 : string = ""
    v0
and method3 (v0 : Mut0, v1 : string) : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and format_real_1 (v0 : int32) : string =
    let v1 : string = method2()
    let v2 : Mut0 = {l0 = v1} : Mut0
    let v3 : string = $"{v0}"
    method3(v2, v3)
    let v4 : string = v2.l0
    v4
and method0 () : string =
    let v0 : string = "Some"
    let v1 : string = "("
    let v2 : string = v0 + v1 
    let v3 : int32 = 1
    let v4 : string = format_real_1(v3)
    let v5 : string = v2 + v4 
    let v6 : string = ")"
    let v7 : string = v5 + v6 
    v7
let v0 : string = method0()
let v1 : string = "x: "
let v2 : string = v1 + v0 
let v3 : bool = v2 = ""
if v3 then
    1
else
    0
