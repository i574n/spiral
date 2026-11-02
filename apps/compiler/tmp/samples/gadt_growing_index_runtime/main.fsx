type UH0 =
    | UH0_VZ
and UH3 =
    | UH3_VZ
    | UH3_VS of UH0
and UH5 =
    | UH5_VZ
    | UH5_VS of UH3
and UH7 =
    | UH7_VZ
    | UH7_VS of UH5
and UH9 =
    | UH9_VZ
    | UH9_VS of UH9
and UH8 =
    | UH8_Var of UH9
    | UH8_Lam of UH8
    | UH8_App of UH8 * UH8
and UH6 =
    | UH6_Var of UH7
    | UH6_Lam of UH8
    | UH6_App of UH6 * UH6
and UH4 =
    | UH4_Var of UH5
    | UH4_Lam of UH6
    | UH4_App of UH4 * UH4
and UH2 =
    | UH2_Var of UH3
    | UH2_Lam of UH4
    | UH2_App of UH2 * UH2
and UH1 =
    | UH1_Var of UH0
    | UH1_Lam of UH2
    | UH1_App of UH1 * UH1
and UH10 =
    | UH10_Lam of UH1
    | UH10_App of UH10 * UH10
let rec size_7 (v0 : UH8) : int32 =
    match v0 with
    | UH8_App(v5, v6) -> (* App *)
        let v7 : int32 = size_6(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_6(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH8_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_7(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH8_Var(v1) -> (* Var *)
        1
and size_6 (v0 : UH8) : int32 =
    match v0 with
    | UH8_App(v5, v6) -> (* App *)
        let v7 : int32 = size_6(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_6(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH8_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_7(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH8_Var(v1) -> (* Var *)
        1
and size_5 (v0 : UH8) : int32 =
    match v0 with
    | UH8_App(v5, v6) -> (* App *)
        let v7 : int32 = size_6(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_6(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH8_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_7(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH8_Var(v1) -> (* Var *)
        1
and size_4 (v0 : UH6) : int32 =
    match v0 with
    | UH6_App(v5, v6) -> (* App *)
        let v7 : int32 = size_4(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_4(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH6_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_5(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH6_Var(v1) -> (* Var *)
        1
and size_3 (v0 : UH4) : int32 =
    match v0 with
    | UH4_App(v5, v6) -> (* App *)
        let v7 : int32 = size_3(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_3(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH4_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_4(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH4_Var(v1) -> (* Var *)
        1
and size_2 (v0 : UH2) : int32 =
    match v0 with
    | UH2_App(v5, v6) -> (* App *)
        let v7 : int32 = size_2(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_2(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH2_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_3(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH2_Var(v1) -> (* Var *)
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
and size_0 (v0 : UH10) : int32 =
    match v0 with
    | UH10_App(v4, v5) -> (* App *)
        let v6 : int32 = size_0(v4)
        let v7 : int32 = 1 + v6
        let v8 : int32 = size_0(v5)
        let v9 : int32 = v7 + v8
        v9
    | UH10_Lam(v1) -> (* Lam *)
        let v2 : int32 = size_1(v1)
        let v3 : int32 = 1 + v2
        v3
let v0 : UH0 = UH0_VZ
let v1 : UH1 = UH1_Var(v0)
let v2 : UH0 = UH0_VZ
let v3 : UH3 = UH3_VS(v2)
let v4 : UH2 = UH2_Var(v3)
let v5 : UH1 = UH1_Lam(v4)
let v6 : UH1 = UH1_App(v1, v5)
let v7 : UH10 = UH10_Lam(v6)
size_0(v7)
