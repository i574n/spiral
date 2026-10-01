type UH1 =
    | UH1_0 of UH0
    | UH1_1
and UH0 =
    | UH0_0 of UH1
    | UH0_1
let v0 : bool = true
let v5 : UH0 =
    if v0 then
        let v1 : UH0 = UH0_1
        let v2 : UH1 = UH1_0(v1)
        UH0_0(v2)
    else
        UH0_1
match v5 with
| UH0_1 -> (* StopA *)
    0
| UH0_0(v6) -> (* A *)
    0
