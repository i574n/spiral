type UH1 =
    | UH1_Eps
    | UH1_NotNo of UH0
and UH0 =
    | UH0_Never
    | UH0_NotYes of UH1
let rec no_depth_1 (v0 : UH0) : int32 =
    match v0 with
    | UH0_Never -> (* Never *)
        2
    | UH0_NotYes(v1) -> (* NotYes *)
        let v2 : int32 = yes_depth_0(v1)
        let v3 : int32 = 1 + v2
        v3
and yes_depth_0 (v0 : UH1) : int32 =
    match v0 with
    | UH1_Eps -> (* Eps *)
        1
    | UH1_NotNo(v1) -> (* NotNo *)
        let v2 : int32 = no_depth_1(v1)
        let v3 : int32 = 1 + v2
        v3
let v0 : UH0 = UH0_Never
let v1 : UH1 = UH1_NotNo(v0)
let v2 : UH0 = UH0_NotYes(v1)
let v3 : UH1 = UH1_NotNo(v2)
yes_depth_0(v3)
