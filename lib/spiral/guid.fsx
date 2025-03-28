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
    let v13 : string = v11 + v0 
    let v16 : string = "-"
    (* run_target_args'
    let v248 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v254 : int32 = 0 |> int32 
    let v267 : int32 = 8 |> int32 
    let v275 : int32 = v267 - 1
    let v277 : string = v13.[int v254..int v275]
    let v286 : int32 = 8 |> int32 
    let v299 : int32 = 12 |> int32 
    let v307 : int32 = v299 - 1
    let v309 : string = v13.[int v286..int v307]
    let v318 : int32 = 12 |> int32 
    let v331 : int32 = 16 |> int32 
    let v339 : int32 = v331 - 1
    let v341 : string = v13.[int v318..int v339]
    let v350 : int32 = 16 |> int32 
    let v363 : int32 = 20 |> int32 
    let v371 : int32 = v363 - 1
    let v373 : string = v13.[int v350..int v371]
    let v382 : int32 = 20 |> int32 
    let v395 : int32 = 32 |> int32 
    let v403 : int32 = v395 - 1
    let v405 : string = v13.[int v382..int v403]
    let v410 : string = v277 + v16 
    let v414 : string = v410 + v309 
    let v418 : string = v414 + v16 
    let v422 : string = v418 + v341 
    let v426 : string = v422 + v16 
    let v430 : string = v426 + v373 
    let v434 : string = v430 + v16 
    let v438 : string = v434 + v405 
    (* run_target_args'
    let v445 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v447 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v447 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v451 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v451 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v455 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v445 = v455 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v459 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v459 
    #endif
#if FABLE_COMPILER_PYTHON
    let v463 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v463 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v467 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v467 
    #endif
#else
    let v471 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v471 
    #endif
    let v474 : System.Guid = _run_target_args'_v445 
    let _run_target_args'_v248 = v474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v485 : int32 = 0 |> int32 
    let v498 : int32 = 8 |> int32 
    let v506 : int32 = v498 - 1
    let v508 : string = v13.[int v485..int v506]
    let v517 : int32 = 8 |> int32 
    let v530 : int32 = 12 |> int32 
    let v538 : int32 = v530 - 1
    let v540 : string = v13.[int v517..int v538]
    let v549 : int32 = 12 |> int32 
    let v562 : int32 = 16 |> int32 
    let v570 : int32 = v562 - 1
    let v572 : string = v13.[int v549..int v570]
    let v581 : int32 = 16 |> int32 
    let v594 : int32 = 20 |> int32 
    let v602 : int32 = v594 - 1
    let v604 : string = v13.[int v581..int v602]
    let v613 : int32 = 20 |> int32 
    let v626 : int32 = 32 |> int32 
    let v634 : int32 = v626 - 1
    let v636 : string = v13.[int v613..int v634]
    let v641 : string = v508 + v16 
    let v645 : string = v641 + v540 
    let v649 : string = v645 + v16 
    let v653 : string = v649 + v572 
    let v657 : string = v653 + v16 
    let v661 : string = v657 + v604 
    let v665 : string = v661 + v16 
    let v669 : string = v665 + v636 
    (* run_target_args'
    let v676 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v678 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v678 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v682 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v682 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v686 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v676 = v686 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v690 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v690 
    #endif
#if FABLE_COMPILER_PYTHON
    let v694 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v694 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v698 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v698 
    #endif
#else
    let v702 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v702 
    #endif
    let v705 : System.Guid = _run_target_args'_v676 
    let _run_target_args'_v248 = v705 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v712 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v248 = v712 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v720 : int32 = 0 |> int32 
    let v733 : int32 = 8 |> int32 
    let v741 : int32 = v733 - 1
    let v743 : string = v13.[int v720..int v741]
    let v752 : int32 = 8 |> int32 
    let v765 : int32 = 12 |> int32 
    let v773 : int32 = v765 - 1
    let v775 : string = v13.[int v752..int v773]
    let v784 : int32 = 12 |> int32 
    let v797 : int32 = 16 |> int32 
    let v805 : int32 = v797 - 1
    let v807 : string = v13.[int v784..int v805]
    let v816 : int32 = 16 |> int32 
    let v829 : int32 = 20 |> int32 
    let v837 : int32 = v829 - 1
    let v839 : string = v13.[int v816..int v837]
    let v848 : int32 = 20 |> int32 
    let v861 : int32 = 32 |> int32 
    let v869 : int32 = v861 - 1
    let v871 : string = v13.[int v848..int v869]
    let v876 : string = v743 + v16 
    let v880 : string = v876 + v775 
    let v884 : string = v880 + v16 
    let v888 : string = v884 + v807 
    let v892 : string = v888 + v16 
    let v896 : string = v892 + v839 
    let v900 : string = v896 + v16 
    let v904 : string = v900 + v871 
    (* run_target_args'
    let v911 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v913 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v913 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v917 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v917 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v921 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v911 = v921 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v925 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v925 
    #endif
#if FABLE_COMPILER_PYTHON
    let v929 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v929 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v933 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v933 
    #endif
#else
    let v937 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v937 
    #endif
    let v940 : System.Guid = _run_target_args'_v911 
    let _run_target_args'_v248 = v940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v951 : int32 = 0 |> int32 
    let v964 : int32 = 8 |> int32 
    let v972 : int32 = v964 - 1
    let v974 : string = v13.[int v951..int v972]
    let v983 : int32 = 8 |> int32 
    let v996 : int32 = 12 |> int32 
    let v1004 : int32 = v996 - 1
    let v1006 : string = v13.[int v983..int v1004]
    let v1015 : int32 = 12 |> int32 
    let v1028 : int32 = 16 |> int32 
    let v1036 : int32 = v1028 - 1
    let v1038 : string = v13.[int v1015..int v1036]
    let v1047 : int32 = 16 |> int32 
    let v1060 : int32 = 20 |> int32 
    let v1068 : int32 = v1060 - 1
    let v1070 : string = v13.[int v1047..int v1068]
    let v1079 : int32 = 20 |> int32 
    let v1092 : int32 = 32 |> int32 
    let v1100 : int32 = v1092 - 1
    let v1102 : string = v13.[int v1079..int v1100]
    let v1107 : string = v974 + v16 
    let v1111 : string = v1107 + v1006 
    let v1115 : string = v1111 + v16 
    let v1119 : string = v1115 + v1038 
    let v1123 : string = v1119 + v16 
    let v1127 : string = v1123 + v1070 
    let v1131 : string = v1127 + v16 
    let v1135 : string = v1131 + v1102 
    (* run_target_args'
    let v1142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1144 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1148 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1148 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1152 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1142 = v1152 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1156 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1156 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1160 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1160 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1164 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1164 
    #endif
#else
    let v1168 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1168 
    #endif
    let v1171 : System.Guid = _run_target_args'_v1142 
    let _run_target_args'_v248 = v1171 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1182 : int32 = 0 |> int32 
    let v1195 : int32 = 8 |> int32 
    let v1203 : int32 = v1195 - 1
    let v1205 : string = v13.[int v1182..int v1203]
    let v1214 : int32 = 8 |> int32 
    let v1227 : int32 = 12 |> int32 
    let v1235 : int32 = v1227 - 1
    let v1237 : string = v13.[int v1214..int v1235]
    let v1246 : int32 = 12 |> int32 
    let v1259 : int32 = 16 |> int32 
    let v1267 : int32 = v1259 - 1
    let v1269 : string = v13.[int v1246..int v1267]
    let v1278 : int32 = 16 |> int32 
    let v1291 : int32 = 20 |> int32 
    let v1299 : int32 = v1291 - 1
    let v1301 : string = v13.[int v1278..int v1299]
    let v1310 : int32 = 20 |> int32 
    let v1323 : int32 = 32 |> int32 
    let v1331 : int32 = v1323 - 1
    let v1333 : string = v13.[int v1310..int v1331]
    let v1338 : string = v1205 + v16 
    let v1342 : string = v1338 + v1237 
    let v1346 : string = v1342 + v16 
    let v1350 : string = v1346 + v1269 
    let v1354 : string = v1350 + v16 
    let v1358 : string = v1354 + v1301 
    let v1362 : string = v1358 + v16 
    let v1366 : string = v1362 + v1333 
    (* run_target_args'
    let v1373 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1375 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1375 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1379 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1379 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1383 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1373 = v1383 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1387 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1387 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1391 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1391 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1395 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1395 
    #endif
#else
    let v1399 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1399 
    #endif
    let v1402 : System.Guid = _run_target_args'_v1373 
    let _run_target_args'_v248 = v1402 
    #endif
#else
    let v1413 : int32 = 0 |> int32 
    let v1426 : int32 = 8 |> int32 
    let v1434 : int32 = v1426 - 1
    let v1436 : string = v13.[int v1413..int v1434]
    let v1445 : int32 = 8 |> int32 
    let v1458 : int32 = 12 |> int32 
    let v1466 : int32 = v1458 - 1
    let v1468 : string = v13.[int v1445..int v1466]
    let v1477 : int32 = 12 |> int32 
    let v1490 : int32 = 16 |> int32 
    let v1498 : int32 = v1490 - 1
    let v1500 : string = v13.[int v1477..int v1498]
    let v1509 : int32 = 16 |> int32 
    let v1522 : int32 = 20 |> int32 
    let v1530 : int32 = v1522 - 1
    let v1532 : string = v13.[int v1509..int v1530]
    let v1541 : int32 = 20 |> int32 
    let v1554 : int32 = 32 |> int32 
    let v1562 : int32 = v1554 - 1
    let v1564 : string = v13.[int v1541..int v1562]
    let v1569 : string = v1436 + v16 
    let v1573 : string = v1569 + v1468 
    let v1577 : string = v1573 + v16 
    let v1581 : string = v1577 + v1500 
    let v1585 : string = v1581 + v16 
    let v1589 : string = v1585 + v1532 
    let v1593 : string = v1589 + v16 
    let v1597 : string = v1593 + v1564 
    (* run_target_args'
    let v1604 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1606 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1606 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1610 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1610 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1614 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1604 = v1614 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1618 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1618 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1622 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1622 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1626 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1626 
    #endif
#else
    let v1630 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1630 
    #endif
    let v1633 : System.Guid = _run_target_args'_v1604 
    let _run_target_args'_v248 = v1633 
    #endif
    let v1639 : System.Guid = _run_target_args'_v248 
    v1639
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
