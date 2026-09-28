type [<Struct>] US0 =
    | US0_0
    | US0_1 of f1_0 : (int32 [])
let rec method0 (v0 : US0) : int32 =
    match v0 with
    | US0_0 -> (* Empty *)
        0
    | US0_1(v1) -> (* Values *)
        let v2 : int32 = v1.Length
        let v3 : int32 = v1.[int 0]
        let v4 : int32 = v2 + v3
        let v5 : int32 = v1.[int 1]
        let v6 : int32 = v4 + v5
        v6
let v0 : int32 = 2
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
v1.[int 0] <- 4
v1.[int 1] <- 5
let v2 : US0 = US0_1(v1)
let v3 : int32 = method0(v2)
let v4 : int32 = v3 - 11
v4
