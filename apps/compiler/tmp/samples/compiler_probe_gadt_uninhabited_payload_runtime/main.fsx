type UH0 =
    | UH0_PayloadZero
and UH1 =
    | UH1_PayloadRowNil
and UH2 =
    | UH2_PayloadRowCons of UH0 * UH1
let v0 : UH0 = UH0_PayloadZero
let v1 : UH0 = UH0_PayloadZero
let v2 : UH1 = UH1_PayloadRowNil
let v3 : UH2 = UH2_PayloadRowCons(v1, v2)
let v7 : UH0 =
    match v0 with
    | UH0_PayloadZero -> (* PayloadZero *)
        match v3 with
        | UH2_PayloadRowCons(v4, v5) -> (* PayloadRowCons *)
            v4
match v7 with
| UH0_PayloadZero -> (* PayloadZero *)
    true
