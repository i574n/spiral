type UH0 =
    | UH0_0
    | UH0_1 of int32 * UH0
let rec method0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_1(v1, v2) -> (* Cons *)
        let v3 : int32 = method0(v2)
        let v4 : int32 = v1 + v3 
        v4
    | UH0_0 -> (* Nil *)
        0
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : int32 = 3
let v3 : UH0 = UH0_0
let v4 : UH0 = UH0_1(v2, v3)
let v5 : UH0 = UH0_1(v1, v4)
let v6 : UH0 = UH0_1(v0, v5)
let v7 : int32 = method0(v6)
let v8 : int32 = v7 - 6 
v8
