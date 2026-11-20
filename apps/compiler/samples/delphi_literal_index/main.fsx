let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let v0 : int32 = 0
let v1 : char = (spiralStringIndex "z" (int v0))
let v2 : bool = v1 = 'z'
if v2 then
    42
else
    1
