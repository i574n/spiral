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
let v60 : (int32 -> unit) = System.Console.WriteLine
v60 v12
let v67 : string = "1011"
let v79 : int32 = System.Convert.ToInt32 (v67, 2)
let v91 : (int32 -> unit) = System.Console.WriteLine
v91 v79
let v92 : string = "-42"
let v127 : int32 = System.Convert.ToInt32(v92)
let v139 : (int32 -> unit) = System.Console.WriteLine
v139 v127
let v140 : string = " 123 "
let v192 : US0 = method0(v140)
let v276 : US1 =
    match v192 with
    | US0_1(v273) -> (* Error *)
        US1_1
    | US0_0(v271) -> (* Ok *)
        US1_0(v271)
match v276 with
| US1_1 -> (* None *)
    let v706 : (string -> unit) = System.Console.WriteLine
    let v707 : string = "none"
    v706 v707
| US1_0(v702) -> (* Some *)
    let v703 : (int32 -> unit) = System.Console.WriteLine
    v703 v702
let v710 : string = "12x"
let v711 : US0 = method0(v710)
let v717 : US1 =
    match v711 with
    | US0_1(v714) -> (* Error *)
        US1_1
    | US0_0(v712) -> (* Ok *)
        US1_0(v712)
match v717 with
| US1_1 -> (* None *)
    let v720 : (string -> unit) = System.Console.WriteLine
    let v721 : string = "none"
    v720 v721
| US1_0(v718) -> (* Some *)
    let v719 : (int32 -> unit) = System.Console.WriteLine
    v719 v718
let v722 : string = ""
let v723 : US0 = method0(v722)
let v729 : US1 =
    match v723 with
    | US0_1(v726) -> (* Error *)
        US1_1
    | US0_0(v724) -> (* Ok *)
        US1_0(v724)
match v729 with
| US1_1 -> (* None *)
    let v732 : (string -> unit) = System.Console.WriteLine
    let v733 : string = "none"
    v732 v733
| US1_0(v730) -> (* Some *)
    let v731 : (int32 -> unit) = System.Console.WriteLine
    v731 v730
let v734 : string = "+7"
let v735 : US0 = method0(v734)
let v741 : US1 =
    match v735 with
    | US0_1(v738) -> (* Error *)
        US1_1
    | US0_0(v736) -> (* Ok *)
        US1_0(v736)
match v741 with
| US1_1 -> (* None *)
    let v744 : (string -> unit) = System.Console.WriteLine
    let v745 : string = "none"
    v744 v745
| US1_0(v742) -> (* Some *)
    let v743 : (int32 -> unit) = System.Console.WriteLine
    v743 v742
0
