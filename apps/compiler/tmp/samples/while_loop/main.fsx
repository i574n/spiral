let rec method0 (v0 : int32) : bool =
    let v1 : bool = v0 < 10
    v1
let v0 : int32 = 0
let v1 : int32 = 0
while method0(v0) do
    let v3 : int32 = v1 + v0 
    v1 = v3
    let v4 : int32 = v0 + 1 
    v0 = v4
    ()
let v5 : int32 = v1 - 45 
v5
