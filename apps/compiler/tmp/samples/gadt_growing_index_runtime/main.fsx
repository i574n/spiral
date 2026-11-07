type UH0 =
    | UH0_VZ
    | UH0_VS of UH0
and UH1 =
    | UH1_Var of UH0
    | UH1_Lam of UH1
    | UH1_App of UH1 * UH1
let rec size_3 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_3(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_3(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_2(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
and size_2 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_3(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_3(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_2(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
and size_1 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_1(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_1(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_2(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
and size_0 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_1(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_1(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_2(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
let v0 : UH0 = UH0_VZ
let v1 : UH1 = UH1_Var(v0)
let v2 : UH0 = UH0_VZ
let v3 : UH0 = UH0_VS(v2)
let v4 : UH1 = UH1_Var(v3)
let v5 : UH1 = UH1_Lam(v4)
let v6 : UH1 = UH1_App(v1, v5)
let v7 : UH1 = UH1_Lam(v6)
size_0(v7)
