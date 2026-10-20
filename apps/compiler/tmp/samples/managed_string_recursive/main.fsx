type UH0 =
    | UH0_Empty
    | UH0_Node of string * UH0 * UH0
let rec score_0 (v0 : UH0) : int32 =
    match v0 with
    | UH0_Empty -> (* Empty *)
        0
    | UH0_Node(v1, v2, v3) -> (* Node *)
        let v4 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
        let v5 : int32 = score_0(v2)
        let v6 : int32 = v4 + v5
        let v7 : int32 = score_0(v3)
        let v8 : int32 = v6 + v7
        v8
let v0 : string = "ab"
let v1 : string = "qwe"
let v2 : UH0 = UH0_Empty
let v3 : UH0 = UH0_Node(v1, v2, v2)
let v4 : UH0 = UH0_Node(v0, v3, v3)
let v5 : int32 = score_0(v4)
let v6 : UH0 = UH0_Empty
let v7 : UH0 = UH0_Node(v1, v6, v6)
let v8 : UH0 = UH0_Node(v0, v7, v7)
let v9 : int32 = score_0(v8)
let v10 : int32 = v5 + v9
let v11 : int32 = v10 - 16
v11
