type UH0 =
    | UH0_Nil
    | UH0_Cons of (int32 []) * UH0
let rec sum_0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_Cons(v1, v2) -> (* Cons *)
        let v3 : int32 = v1.Length
        let v4 : int32 = sum_0(v2)
        let v5 : int32 = v3 + v4
        v5
    | UH0_Nil -> (* Nil *)
        0
let v0 : int32 = 2
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
let v2 : UH0 = UH0_Nil
let v3 : UH0 = UH0_Cons(v1, v2)
let v4 : UH0 = UH0_Cons(v1, v3)
let v5 : int32 = sum_0(v4)
let v6 : int32 = v5 - 4
v6
