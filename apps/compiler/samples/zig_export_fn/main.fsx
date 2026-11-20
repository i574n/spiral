let rec closure0 () struct (v0 : int32, v1 : int32) : int32 =
    let v2 : int32 = v0 + v1
    v2
let spiral_add (v0 : int32, v1 : int32) : int32 =
    closure0 () (struct (v0, v1))
let v0 : (struct (int32 * int32) -> int32) = closure0()
let v1 : int32 = 40
let v2 : int32 = v1 + 2
let v3 : bool = v2 = 42
if v3 then
    0
else
    1
