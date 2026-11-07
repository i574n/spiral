type UH0 =
    | UH0_Nil
    | UH0_Cons of int32 * UH0
let rec sum_0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_Cons(v1, v2) -> (* Cons *)
        let v3 : int32 = sum_0(v2)
        let v4 : int32 = v1 + v3
        v4
    | UH0_Nil -> (* Nil *)
        0
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = 3
let v3 : UH0 = UH0_Nil
let v4 : UH0 = UH0_Cons(v2, v3)
let v5 : UH0 = UH0_Cons(v1, v4)
let v6 : UH0 = UH0_Cons(v0, v5)
let v7 : int32 = sum_0(v6)
let v8 : int32 = v7 - 6
v8
