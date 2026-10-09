type [<Struct>] US0 =
    | US0_Some of f0_0 : int32
    | US0_None
and Mut0 = {mutable l0 : string}
let rec method2 () : string =
    let v0 : string = ""
    v0
and method3 (v0 : Mut0, v1 : string) : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and format_real_1 (v0 : US0) : string =
    let v1 : string = method2()
    let v56 : Mut0 = {l0 = v1} : Mut0
    let v59 : string = $"%A{v0}"
    method3(v56, v59)
    let v105 : string = v56.l0
    v105
and method0 () : string =
    let v0 : int32 = 1
    let v1 : US0 = US0_Some(v0)
    let v2 : string = format_real_1(v1)
    let v7 : string = "x: "
    let v8 : string = v7 + v2 
    v8
let v0 : string = method0()
let v1 : bool = v0 = ""
if v1 then
    1
else
    0
