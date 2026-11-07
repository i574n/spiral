let v0 : (string -> unit) = System.Console.WriteLine
let v1 : string = "hello"
v0 v1
let v2 : int32 = 42
let v3 : (int32 -> unit) = System.Console.WriteLine
v3 v2
let v4 : string = "a"
v4 |> System.Console.Write
let v5 : string = "b"
v5 |> System.Console.Write
let v6 : (string -> unit) = System.Console.WriteLine
let v7 : string = ""
v6 v7
let v8 : int64 = -7L
let v9 : (int64 -> unit) = System.Console.WriteLine
v9 v8
0
