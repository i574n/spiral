type Mut0 = {mutable l0 : int32}
let rec method0 (v0 : Mut0) : unit =
    let v1 : int32 = v0.l0
    let v2 : int32 = v1 + 5
    v0.l0 <- v2
    ()
and method1 (v0 : Mut0) : unit =
    ()
and method2 (v0 : Mut0) : unit =
    let v1 : int32 = v0.l0
    let v2 : int32 = v1 + 7
    v0.l0 <- v2
    ()
let v0 : Mut0 = {l0 = 0} : Mut0
method0(v0)
method1(v0)
method2(v0)
let v1 : int32 = v0.l0
let v2 : int32 = v1 - 12
v2
