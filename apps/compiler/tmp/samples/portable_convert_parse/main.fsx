type [<Struct>] US0 =
    | US0_0 of f0_0 : int32
    | US0_1 of f1_0 : exn
and [<Struct>] US1 =
    | US1_0 of f0_0 : int32
    | US1_1
let rec closure0 (v0 : string) () : int32 =
    let v1 : int32 = v0 |> int32 
    v1
and closure1 () (v0 : int32) : US0 =
    US0_0(v0)
and closure2 () (v0 : (unit -> exn)) : exn =
    v0 ()
and closure3 () (v0 : exn) : US0 =
    US0_1(v0)
and method0 (v0 : string) : US0 =
    let v1 : (unit -> int32) = closure0(v0)
    let v2 : (int32 -> US0) = closure1()
    let v3 : ((unit -> exn) -> exn) = closure2()
    let v4 : (exn -> US0) = closure3()
    let v5 : US0 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
let v0 : string = "ff"
let v12 : int32 = System.Convert.ToInt32 (v0, 16)
let v62 : (int32 -> unit) = System.Console.WriteLine
v62 v12
let v69 : string = "1011"
let v81 : int32 = System.Convert.ToInt32 (v69, 2)
let v94 : (int32 -> unit) = System.Console.WriteLine
v94 v81
let v95 : string = "-42"
let v131 : int32 = System.Convert.ToInt32(v95)
let v144 : (int32 -> unit) = System.Console.WriteLine
v144 v131
let v145 : string = " 123 "
let v211 : US0 = method0(v145)
let v306 : US1 =
    match v211 with
    | US0_1(v303) -> (* Error *)
        US1_1
    | US0_0(v301) -> (* Ok *)
        US1_0(v301)
match v306 with
| US1_1 -> (* None *)
    let v801 : (string -> unit) = System.Console.WriteLine
    let v802 : string = "none"
    v801 v802
| US1_0(v797) -> (* Some *)
    let v798 : (int32 -> unit) = System.Console.WriteLine
    v798 v797
let v805 : string = "12x"
let v806 : US0 = method0(v805)
let v812 : US1 =
    match v806 with
    | US0_1(v809) -> (* Error *)
        US1_1
    | US0_0(v807) -> (* Ok *)
        US1_0(v807)
match v812 with
| US1_1 -> (* None *)
    let v815 : (string -> unit) = System.Console.WriteLine
    let v816 : string = "none"
    v815 v816
| US1_0(v813) -> (* Some *)
    let v814 : (int32 -> unit) = System.Console.WriteLine
    v814 v813
let v817 : string = ""
let v818 : US0 = method0(v817)
let v824 : US1 =
    match v818 with
    | US0_1(v821) -> (* Error *)
        US1_1
    | US0_0(v819) -> (* Ok *)
        US1_0(v819)
match v824 with
| US1_1 -> (* None *)
    let v827 : (string -> unit) = System.Console.WriteLine
    let v828 : string = "none"
    v827 v828
| US1_0(v825) -> (* Some *)
    let v826 : (int32 -> unit) = System.Console.WriteLine
    v826 v825
let v829 : string = "+7"
let v830 : US0 = method0(v829)
let v836 : US1 =
    match v830 with
    | US0_1(v833) -> (* Error *)
        US1_1
    | US0_0(v831) -> (* Ok *)
        US1_0(v831)
match v836 with
| US1_1 -> (* None *)
    let v839 : (string -> unit) = System.Console.WriteLine
    let v840 : string = "none"
    v839 v840
| US1_0(v837) -> (* Some *)
    let v838 : (int32 -> unit) = System.Console.WriteLine
    v838 v837
0
