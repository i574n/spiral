type UH0 =
    | UH0_0
and UH1 =
    | UH1_0
and UH2 =
    | UH2_0 of UH0 * UH1
let v0 : UH0 = UH0_0
let v1 : UH0 = UH0_0
let v2 : UH1 = UH1_0
let v3 : UH2 = UH2_0(v1, v2)
let v7 : UH0 =
    match v0 with
    | UH0_0 -> (* PayloadZero *)
        match v3 with
        | UH2_0(v4, v5) -> (* PayloadRowCons *)
            v4
match v7 with
| UH0_0 -> (* PayloadZero *)
    true
