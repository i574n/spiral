let v2 : (string -> unit) = System.Console.WriteLine
let v3 : string = "hello"
v2 v3
let v10 : int32 = 42
let v11 : (int32 -> unit) = System.Console.WriteLine
v11 v10
let v16 : string = "a"
v16 |> System.Console.Write
let v21 : string = "b"
v21 |> System.Console.Write
let v26 : (string -> unit) = System.Console.WriteLine
let v27 : string = ""
v26 v27
let v30 : int64 = -7L
let v31 : (int64 -> unit) = System.Console.WriteLine
v31 v30
0
