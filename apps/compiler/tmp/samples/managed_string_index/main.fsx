let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let v0 : string = "qwe"
let v1 : char = (spiralStringIndex v0 (int 1))
let v2 : bool = v1 = 'w'
if v2 then
    0
else
    1
