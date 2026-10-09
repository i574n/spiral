let v0 : int32 = 41
let v65 : string = v0 |> _.ToString()
let v78 : (string -> unit) = System.Console.WriteLine
v78 v65
let v87 : (string -> unit) = System.Console.WriteLine
let v88 : string = "hi"
v87 v88
let v91 : bool = true
let v109 : string = v91 |> _.ToString()
let v122 : (string -> unit) = System.Console.WriteLine
v122 v109
let v123 : int32 = v0 + 1
let v124 : bool = v123 = 42
if v124 then
    0
else
    1
