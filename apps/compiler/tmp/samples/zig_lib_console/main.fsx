let v0 : int32 = 41
let v53 : string = v0 |> _.ToString()
let v65 : (string -> unit) = System.Console.WriteLine
v65 v53
let v74 : (string -> unit) = System.Console.WriteLine
let v75 : string = "hi"
v74 v75
let v78 : bool = true
let v95 : string = v78 |> _.ToString()
let v107 : (string -> unit) = System.Console.WriteLine
v107 v95
let v108 : int32 = v0 + 1
let v109 : bool = v108 = 42
if v109 then
    0
else
    1
