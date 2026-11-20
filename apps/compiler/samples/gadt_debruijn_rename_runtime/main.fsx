type UH0 =
    | UH0_VZ
    | UH0_VS of UH0
and UH1 =
    | UH1_Var of UH0
    | UH1_Lam of UH1
    | UH1_App of UH1 * UH1
let rec closure0 () (v0 : UH0) : UH0 =
    UH0_VS(v0)
and closure1 (v0 : (UH0 -> UH0)) (v1 : UH0) : UH0 =
    match v1 with
    | UH0_VS(v3) -> (* VS *)
        let v4 : UH0 = v0 v3
        UH0_VS(v4)
    | UH0_VZ -> (* VZ *)
        UH0_VZ
and closure2 (v0 : (UH0 -> UH0)) (v1 : UH0) : UH0 =
    match v1 with
    | UH0_VS(v3) -> (* VS *)
        let v4 : UH0 = v0 v3
        UH0_VS(v4)
    | UH0_VZ -> (* VZ *)
        UH0_VZ
and closure3 (v0 : (UH0 -> UH0)) (v1 : UH0) : UH0 =
    match v1 with
    | UH0_VS(v3) -> (* VS *)
        let v4 : UH0 = v0 v3
        UH0_VS(v4)
    | UH0_VZ -> (* VZ *)
        UH0_VZ
and rename_5 (v0 : (UH0 -> UH0), v1 : UH1) : UH1 =
    match v1 with
    | UH1_App(v9, v10) -> (* App *)
        let v11 : UH1 = rename_5(v0, v9)
        let v12 : UH1 = rename_5(v0, v10)
        UH1_App(v11, v12)
    | UH1_Lam(v5) -> (* Lam *)
        let v6 : (UH0 -> UH0) = closure3(v0)
        let v7 : UH1 = rename_4(v6, v5)
        UH1_Lam(v7)
    | UH1_Var(v2) -> (* Var *)
        let v3 : UH0 = v0 v2
        UH1_Var(v3)
and rename_4 (v0 : (UH0 -> UH0), v1 : UH1) : UH1 =
    match v1 with
    | UH1_App(v9, v10) -> (* App *)
        let v11 : UH1 = rename_5(v0, v9)
        let v12 : UH1 = rename_5(v0, v10)
        UH1_App(v11, v12)
    | UH1_Lam(v5) -> (* Lam *)
        let v6 : (UH0 -> UH0) = closure3(v0)
        let v7 : UH1 = rename_4(v6, v5)
        UH1_Lam(v7)
    | UH1_Var(v2) -> (* Var *)
        let v3 : UH0 = v0 v2
        UH1_Var(v3)
and rename_3 (v0 : (UH0 -> UH0), v1 : UH1) : UH1 =
    match v1 with
    | UH1_App(v9, v10) -> (* App *)
        let v11 : UH1 = rename_3(v0, v9)
        let v12 : UH1 = rename_3(v0, v10)
        UH1_App(v11, v12)
    | UH1_Lam(v5) -> (* Lam *)
        let v6 : (UH0 -> UH0) = closure2(v0)
        let v7 : UH1 = rename_4(v6, v5)
        UH1_Lam(v7)
    | UH1_Var(v2) -> (* Var *)
        let v3 : UH0 = v0 v2
        UH1_Var(v3)
and rename_2 (v0 : (UH0 -> UH0), v1 : UH1) : UH1 =
    match v1 with
    | UH1_App(v9, v10) -> (* App *)
        let v11 : UH1 = rename_3(v0, v9)
        let v12 : UH1 = rename_3(v0, v10)
        UH1_App(v11, v12)
    | UH1_Lam(v5) -> (* Lam *)
        let v6 : (UH0 -> UH0) = closure2(v0)
        let v7 : UH1 = rename_4(v6, v5)
        UH1_Lam(v7)
    | UH1_Var(v2) -> (* Var *)
        let v3 : UH0 = v0 v2
        UH1_Var(v3)
and rename_1 (v0 : (UH0 -> UH0), v1 : UH1) : UH1 =
    match v1 with
    | UH1_App(v9, v10) -> (* App *)
        let v11 : UH1 = rename_1(v0, v9)
        let v12 : UH1 = rename_1(v0, v10)
        UH1_App(v11, v12)
    | UH1_Lam(v5) -> (* Lam *)
        let v6 : (UH0 -> UH0) = closure1(v0)
        let v7 : UH1 = rename_2(v6, v5)
        UH1_Lam(v7)
    | UH1_Var(v2) -> (* Var *)
        let v3 : UH0 = v0 v2
        UH1_Var(v3)
and rename_0 (v0 : (UH0 -> UH0), v1 : UH1) : UH1 =
    match v1 with
    | UH1_App(v9, v10) -> (* App *)
        let v11 : UH1 = rename_1(v0, v9)
        let v12 : UH1 = rename_1(v0, v10)
        UH1_App(v11, v12)
    | UH1_Lam(v5) -> (* Lam *)
        let v6 : (UH0 -> UH0) = closure1(v0)
        let v7 : UH1 = rename_2(v6, v5)
        UH1_Lam(v7)
    | UH1_Var(v2) -> (* Var *)
        let v3 : UH0 = v0 v2
        UH1_Var(v3)
and size_9 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_9(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_9(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_8(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
and size_8 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_9(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_9(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_8(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
and size_7 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_7(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_7(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_8(v2)
        let v4 : int32 = 1 + v3
        v4
    | UH1_Var(v1) -> (* Var *)
        1
and size_6 (v0 : UH1) : int32 =
    match v0 with
    | UH1_App(v5, v6) -> (* App *)
        let v7 : int32 = size_7(v5)
        let v8 : int32 = 1 + v7
        let v9 : int32 = size_7(v6)
        let v10 : int32 = v8 + v9
        v10
    | UH1_Lam(v2) -> (* Lam *)
        let v3 : int32 = size_8(v2)
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
let v8 : (UH0 -> UH0) = closure0()
let v9 : UH1 = rename_0(v8, v7)
size_6(v9)
