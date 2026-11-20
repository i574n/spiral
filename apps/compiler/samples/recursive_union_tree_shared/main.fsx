type UH0 =
    | UH0_Leaf
    | UH0_Node of int32 * UH0 * UH0
let rec sum_0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_Leaf -> (* Leaf *)
        0
    | UH0_Node(v1, v2, v3) -> (* Node *)
        let v4 : int32 = sum_0(v2)
        let v5 : int32 = sum_0(v3)
        let v6 : int32 = v4 + v5
        let v7 : int32 = v1 + v6
        v7
let v0 : int32 = 1
let v1 : int32 = 2
let v2 : UH0 = UH0_Leaf
let v3 : UH0 = UH0_Node(v1, v2, v2)
let v4 : UH0 = UH0_Node(v0, v3, v3)
let v5 : int32 = sum_0(v4)
let v6 : int32 = v5 - 5
v6
