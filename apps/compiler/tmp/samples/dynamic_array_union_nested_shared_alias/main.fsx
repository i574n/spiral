type [<Struct>] US0 =
    | US0_0
    | US0_1 of f1_0 : ((int32 []) [])
let rec method0 (v0 : US0) : int32 =
    match v0 with
    | US0_0 -> (* Empty *)
        0
    | US0_1(v1) -> (* Nested *)
        let v2 : (int32 []) = v1.[int 0]
        let v3 : int32 = v2.[int 0]
        let v4 : int32 = v3 + 1
        v2.[int 0] <- v4
        0
and method1 (v0 : US0) : int32 =
    match v0 with
    | US0_0 -> (* Empty *)
        0
    | US0_1(v1) -> (* Nested *)
        let v2 : (int32 []) = v1.[int 0]
        let v3 : (int32 []) = v1.[int 1]
        let v4 : int32 = v2.[int 0]
        let v5 : int32 = v2.[int 1]
        let v6 : int32 = v4 + v5
        let v7 : int32 = v3.[int 0]
        let v8 : int32 = v6 + v7
        let v9 : int32 = v3.[int 1]
        let v10 : int32 = v8 + v9
        v10
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
let v5 : int32 = method0(v4)
let v6 : US0 = US0_1(v1)
let v7 : int32 = method1(v6)
let v8 : int32 = v7 + v5
let v9 : int32 = v8 - 19
v9
