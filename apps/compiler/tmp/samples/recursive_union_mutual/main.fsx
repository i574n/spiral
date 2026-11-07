type UH1 =
    | UH1_B of UH0
    | UH1_StopB
and UH0 =
    | UH0_A of UH1
    | UH0_StopA
let v0 : bool = true
let v5 : UH0 =
    if v0 then
        let v1 : UH0 = UH0_StopA
        let v2 : UH1 = UH1_B(v1)
        UH0_A(v2)
    else
        UH0_StopA
match v5 with
| UH0_A(v6) -> (* A *)
    0
| UH0_StopA -> (* StopA *)
    0
