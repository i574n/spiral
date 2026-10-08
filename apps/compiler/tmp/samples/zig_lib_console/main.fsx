let v0 : int32 = 41
let v29 : string = v0 |> _.ToString()
let v39 : (string -> unit) = System.Console.WriteLine
v39 v29
let v48 : (string -> unit) = System.Console.WriteLine
let v49 : string = "hi"
v48 v49
let v52 : bool = true
let v67 : string = v52 |> _.ToString()
let v77 : (string -> unit) = System.Console.WriteLine
v77 v67
let v78 : int32 = v0 + 1
let v79 : bool = v78 = 42
if v79 then
    0
else
    1
