let rec closure0 () (v0 : string) : System.Guid =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : System.Guid = v0 |> System.Guid 
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : System.Guid = v0 |> System.Guid 
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : System.Guid = v0 |> System.Guid 
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : System.Guid = v0 |> System.Guid 
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : System.Guid = v0 |> System.Guid 
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v31 : System.Guid = v0 |> System.Guid 
    let _run_target_args'_v5 = v31 
    #endif
    let v34 : System.Guid = _run_target_args'_v5 
    v34
and closure2 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method1(v0, v1, v5)
        let v8 : string = v3 + v1 
        v6 v8
and method1 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure2(v0, v1, v2)
and method0 (v0 : string) : System.Guid =
    let v2 : (char -> string) = _.ToString()
    let v3 : string = v2 '0'
    let v6 : int32 = v0.Length
    let v7 : int32 = 32 - v6
    let v8 : int32 = 0
    let v9 : (string -> string) = method1(v7, v3, v8)
    let v10 : string = ""
    let v11 : string = v9 v10
    let v12 : string = v11 + v0 
    (* run_target_args'
    let v213 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : int32 = 0 |> int32 
    let v232 : int32 = 8 |> int32 
    let v240 : int32 = v232 - 1
    let v242 : string = v12.[int v219..int v240]
    let v251 : int32 = 8 |> int32 
    let v264 : int32 = 12 |> int32 
    let v272 : int32 = v264 - 1
    let v274 : string = v12.[int v251..int v272]
    let v283 : int32 = 12 |> int32 
    let v296 : int32 = 16 |> int32 
    let v304 : int32 = v296 - 1
    let v306 : string = v12.[int v283..int v304]
    let v315 : int32 = 16 |> int32 
    let v328 : int32 = 20 |> int32 
    let v336 : int32 = v328 - 1
    let v338 : string = v12.[int v315..int v336]
    let v347 : int32 = 20 |> int32 
    let v360 : int32 = 32 |> int32 
    let v368 : int32 = v360 - 1
    let v370 : string = v12.[int v347..int v368]
    let v374 : string = $"{v242}-{v274}-{v306}-{v338}-{v370}"
    (* run_target_args'
    let v379 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v381 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v381 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v385 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v385 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v389 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v379 = v389 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v393 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v393 
    #endif
#if FABLE_COMPILER_PYTHON
    let v397 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v397 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v401 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v401 
    #endif
#else
    let v405 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v405 
    #endif
    let v408 : System.Guid = _run_target_args'_v379 
    let _run_target_args'_v213 = v408 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v419 : int32 = 0 |> int32 
    let v432 : int32 = 8 |> int32 
    let v440 : int32 = v432 - 1
    let v442 : string = v12.[int v419..int v440]
    let v451 : int32 = 8 |> int32 
    let v464 : int32 = 12 |> int32 
    let v472 : int32 = v464 - 1
    let v474 : string = v12.[int v451..int v472]
    let v483 : int32 = 12 |> int32 
    let v496 : int32 = 16 |> int32 
    let v504 : int32 = v496 - 1
    let v506 : string = v12.[int v483..int v504]
    let v515 : int32 = 16 |> int32 
    let v528 : int32 = 20 |> int32 
    let v536 : int32 = v528 - 1
    let v538 : string = v12.[int v515..int v536]
    let v547 : int32 = 20 |> int32 
    let v560 : int32 = 32 |> int32 
    let v568 : int32 = v560 - 1
    let v570 : string = v12.[int v547..int v568]
    let v574 : string = $"{v442}-{v474}-{v506}-{v538}-{v570}"
    (* run_target_args'
    let v579 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v581 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v581 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v585 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v585 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v589 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v579 = v589 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v593 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v597 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v597 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v601 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v601 
    #endif
#else
    let v605 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v605 
    #endif
    let v608 : System.Guid = _run_target_args'_v579 
    let _run_target_args'_v213 = v608 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v615 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v213 = v615 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v623 : int32 = 0 |> int32 
    let v636 : int32 = 8 |> int32 
    let v644 : int32 = v636 - 1
    let v646 : string = v12.[int v623..int v644]
    let v655 : int32 = 8 |> int32 
    let v668 : int32 = 12 |> int32 
    let v676 : int32 = v668 - 1
    let v678 : string = v12.[int v655..int v676]
    let v687 : int32 = 12 |> int32 
    let v700 : int32 = 16 |> int32 
    let v708 : int32 = v700 - 1
    let v710 : string = v12.[int v687..int v708]
    let v719 : int32 = 16 |> int32 
    let v732 : int32 = 20 |> int32 
    let v740 : int32 = v732 - 1
    let v742 : string = v12.[int v719..int v740]
    let v751 : int32 = 20 |> int32 
    let v764 : int32 = 32 |> int32 
    let v772 : int32 = v764 - 1
    let v774 : string = v12.[int v751..int v772]
    let v778 : string = $"{v646}-{v678}-{v710}-{v742}-{v774}"
    (* run_target_args'
    let v783 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v785 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v785 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v789 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v789 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v793 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v783 = v793 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v797 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v797 
    #endif
#if FABLE_COMPILER_PYTHON
    let v801 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v801 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v805 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v805 
    #endif
#else
    let v809 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v809 
    #endif
    let v812 : System.Guid = _run_target_args'_v783 
    let _run_target_args'_v213 = v812 
    #endif
#if FABLE_COMPILER_PYTHON
    let v823 : int32 = 0 |> int32 
    let v836 : int32 = 8 |> int32 
    let v844 : int32 = v836 - 1
    let v846 : string = v12.[int v823..int v844]
    let v855 : int32 = 8 |> int32 
    let v868 : int32 = 12 |> int32 
    let v876 : int32 = v868 - 1
    let v878 : string = v12.[int v855..int v876]
    let v887 : int32 = 12 |> int32 
    let v900 : int32 = 16 |> int32 
    let v908 : int32 = v900 - 1
    let v910 : string = v12.[int v887..int v908]
    let v919 : int32 = 16 |> int32 
    let v932 : int32 = 20 |> int32 
    let v940 : int32 = v932 - 1
    let v942 : string = v12.[int v919..int v940]
    let v951 : int32 = 20 |> int32 
    let v964 : int32 = 32 |> int32 
    let v972 : int32 = v964 - 1
    let v974 : string = v12.[int v951..int v972]
    let v978 : string = $"{v846}-{v878}-{v910}-{v942}-{v974}"
    (* run_target_args'
    let v983 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v985 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v985 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v989 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v989 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v993 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v983 = v993 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v997 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v997 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1001 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v1001 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1005 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v1005 
    #endif
#else
    let v1009 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v1009 
    #endif
    let v1012 : System.Guid = _run_target_args'_v983 
    let _run_target_args'_v213 = v1012 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1023 : int32 = 0 |> int32 
    let v1036 : int32 = 8 |> int32 
    let v1044 : int32 = v1036 - 1
    let v1046 : string = v12.[int v1023..int v1044]
    let v1055 : int32 = 8 |> int32 
    let v1068 : int32 = 12 |> int32 
    let v1076 : int32 = v1068 - 1
    let v1078 : string = v12.[int v1055..int v1076]
    let v1087 : int32 = 12 |> int32 
    let v1100 : int32 = 16 |> int32 
    let v1108 : int32 = v1100 - 1
    let v1110 : string = v12.[int v1087..int v1108]
    let v1119 : int32 = 16 |> int32 
    let v1132 : int32 = 20 |> int32 
    let v1140 : int32 = v1132 - 1
    let v1142 : string = v12.[int v1119..int v1140]
    let v1151 : int32 = 20 |> int32 
    let v1164 : int32 = 32 |> int32 
    let v1172 : int32 = v1164 - 1
    let v1174 : string = v12.[int v1151..int v1172]
    let v1178 : string = $"{v1046}-{v1078}-{v1110}-{v1142}-{v1174}"
    (* run_target_args'
    let v1183 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1185 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1185 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1189 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1189 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1193 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1183 = v1193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1197 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1197 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1201 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1201 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1205 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1205 
    #endif
#else
    let v1209 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1209 
    #endif
    let v1212 : System.Guid = _run_target_args'_v1183 
    let _run_target_args'_v213 = v1212 
    #endif
#else
    let v1223 : int32 = 0 |> int32 
    let v1236 : int32 = 8 |> int32 
    let v1244 : int32 = v1236 - 1
    let v1246 : string = v12.[int v1223..int v1244]
    let v1255 : int32 = 8 |> int32 
    let v1268 : int32 = 12 |> int32 
    let v1276 : int32 = v1268 - 1
    let v1278 : string = v12.[int v1255..int v1276]
    let v1287 : int32 = 12 |> int32 
    let v1300 : int32 = 16 |> int32 
    let v1308 : int32 = v1300 - 1
    let v1310 : string = v12.[int v1287..int v1308]
    let v1319 : int32 = 16 |> int32 
    let v1332 : int32 = 20 |> int32 
    let v1340 : int32 = v1332 - 1
    let v1342 : string = v12.[int v1319..int v1340]
    let v1351 : int32 = 20 |> int32 
    let v1364 : int32 = 32 |> int32 
    let v1372 : int32 = v1364 - 1
    let v1374 : string = v12.[int v1351..int v1372]
    let v1378 : string = $"{v1246}-{v1278}-{v1310}-{v1342}-{v1374}"
    (* run_target_args'
    let v1383 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1385 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1385 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1389 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1389 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1393 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1383 = v1393 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1397 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1397 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1401 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1401 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1405 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1405 
    #endif
#else
    let v1409 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1409 
    #endif
    let v1412 : System.Guid = _run_target_args'_v1383 
    let _run_target_args'_v213 = v1412 
    #endif
    let v1418 : System.Guid = _run_target_args'_v213 
    v1418
and closure1 () (v0 : string) : System.Guid =
    method0(v0)
and closure3 () () : System.Guid =
    let v1 : (unit -> System.Guid) = System.Guid.NewGuid
    v1 ()
let v0 : (string -> System.Guid) = closure0()
let new_guid x = v0 x
let v1 : (string -> System.Guid) = closure1()
let hash_guid x = v1 x
let v2 : (unit -> System.Guid) = closure3()
let new_raw_guid x = v2 x
()
