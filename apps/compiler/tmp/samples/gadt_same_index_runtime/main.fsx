type UH0 =
    | UH0_Leaf
    | UH0_Node of UH0 * UH0
let rec count_0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_Leaf -> (* Leaf *)
        1
    | UH0_Node(v1, v2) -> (* Node *)
        let v3 : int32 = count_0(v1)
        let v4 : int32 = count_0(v2)
        let v5 : int32 = v3 + v4
        v5
let v0 : UH0 = UH0_Leaf
let v1 : UH0 = UH0_Leaf
let v2 : UH0 = UH0_Leaf
let v3 : UH0 = UH0_Node(v1, v2)
let v4 : UH0 = UH0_Node(v0, v3)
count_0(v4)
