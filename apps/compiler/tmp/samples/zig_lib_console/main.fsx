let v0 : int32 = 41
let v37 : string = v0 |> _.ToString()
let v46 : (string -> unit) = System.Console.WriteLine
v46 v37
let v55 : (string -> unit) = System.Console.WriteLine
let v56 : string = "hi"
v55 v56
let v59 : bool = true
let v73 : string = v59 |> _.ToString()
let v82 : (string -> unit) = System.Console.WriteLine
v82 v73
let v83 : int32 = v0 + 1
let v84 : bool = v83 = 42
if v84 then
    0
else
    1
