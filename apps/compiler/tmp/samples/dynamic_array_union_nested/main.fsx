type [<Struct>] US0 =
    | US0_0
    | US0_1 of f1_0 : ((int32 []) [])
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_0 -> (* Empty *)
        0
    | US0_1(v1) -> (* Nested *)
        let v2 : (int32 []) = v1.[int 0]
        let v3 : (int32 []) = v1.[int 1]
        let v4 : int32 = v1.Length
        let v5 : int32 = v2.[int 0]
        let v6 : int32 = v4 + v5
        let v7 : int32 = v2.[int 1]
        let v8 : int32 = v6 + v7
        let v9 : int32 = v3.[int 0]
        let v10 : int32 = v8 + v9
        let v11 : int32 = v3.[int 1]
        let v12 : int32 = v10 + v11
        v12
let v0 : int32 = 2
let v1 : ((int32 []) []) = Array.zeroCreate<(int32 [])> (v0)
let v2 : (int32 []) = Array.zeroCreate<int32> (v0)
let v3 : (int32 []) = Array.zeroCreate<int32> (v0)
v2.[int 0] <- 3
v2.[int 1] <- 4
v3.[int 0] <- 5
v3.[int 1] <- 6
v1.[int 0] <- v2
v1.[int 1] <- v3
let v4 : US0 = US0_1(v1)
let v5 : int32 = score_0(v4)
let v6 : int32 = v5 - 20
v6
