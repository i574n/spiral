let rec method0 (v0 : int32) : int32 =
    let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
    v1.[int 0] <- 2
    v1.[int 1] <- 3
    v1.[int 2] <- 5
    v1.[int 3] <- 7
    let v2 : int32 = 2
    let v3 : int32 = v1.[int v2]
    let v4 : int32 = v1.Length
    let v5 : int32 = v3 + v4 
    let v6 : int32 = v5 - 9 
    v6
let v0 : int32 = 4
method0(v0)
