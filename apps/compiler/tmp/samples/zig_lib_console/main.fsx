let v0 : int32 = 41
let v1 : string = v0 |> _.ToString()
let v2 : (string -> unit) = System.Console.WriteLine
v2 v1
let v3 : (string -> unit) = System.Console.WriteLine
let v4 : string = "hi"
v3 v4
let v5 : bool = true
let v6 : string = v5 |> _.ToString()
let v7 : (string -> unit) = System.Console.WriteLine
v7 v6
let v8 : int32 = v0 + 1
let v9 : bool = v8 = 42
if v9 then
    0
else
    1
