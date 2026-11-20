let v0 : (string []) = Array.zeroCreate<string> (2)
let v1 : string = "ab"
v0.[int 0] <- v1
let v2 : string = "cde"
v0.[int 1] <- v2
let v3 : string = v0.[int 0]
let v4 : string = v0.[int 1]
let v5 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
let v6 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v4))
let v7 : int32 = v5 + v6
let v8 : int32 = v7 - 5
v8
