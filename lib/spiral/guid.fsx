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
    let v246 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v252 : int32 = 0 |> int32 
    let v265 : int32 = 8 |> int32 
    let v273 : int32 = v265 - 1
    let v275 : string = v13.[int v252..int v273]
    let v284 : int32 = 8 |> int32 
    let v297 : int32 = 12 |> int32 
    let v305 : int32 = v297 - 1
    let v307 : string = v13.[int v284..int v305]
    let v316 : int32 = 12 |> int32 
    let v329 : int32 = 16 |> int32 
    let v337 : int32 = v329 - 1
    let v339 : string = v13.[int v316..int v337]
    let v348 : int32 = 16 |> int32 
    let v361 : int32 = 20 |> int32 
    let v369 : int32 = v361 - 1
    let v371 : string = v13.[int v348..int v369]
    let v380 : int32 = 20 |> int32 
    let v393 : int32 = 32 |> int32 
    let v401 : int32 = v393 - 1
    let v403 : string = v13.[int v380..int v401]
    let v408 : string = v275 + v16 
    let v412 : string = v408 + v307 
    let v416 : string = v412 + v16 
    let v420 : string = v416 + v339 
    let v424 : string = v420 + v16 
    let v428 : string = v424 + v371 
    let v432 : string = v428 + v16 
    let v436 : string = v432 + v403 
    (* run_target_args'
    let v443 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v445 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v445 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v449 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v449 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v453 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v443 = v453 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v457 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v457 
    #endif
#if FABLE_COMPILER_PYTHON
    let v461 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v461 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v465 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v465 
    #endif
#else
    let v469 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v469 
    #endif
    let v472 : System.Guid = _run_target_args'_v443 
    let _run_target_args'_v246 = v472 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v486 : int32 = 0 |> int32 
    let v499 : int32 = 8 |> int32 
    let v507 : int32 = v499 - 1
    let v509 : string = v13.[int v486..int v507]
    let v518 : int32 = 8 |> int32 
    let v531 : int32 = 12 |> int32 
    let v539 : int32 = v531 - 1
    let v541 : string = v13.[int v518..int v539]
    let v550 : int32 = 12 |> int32 
    let v563 : int32 = 16 |> int32 
    let v571 : int32 = v563 - 1
    let v573 : string = v13.[int v550..int v571]
    let v582 : int32 = 16 |> int32 
    let v595 : int32 = 20 |> int32 
    let v603 : int32 = v595 - 1
    let v605 : string = v13.[int v582..int v603]
    let v614 : int32 = 20 |> int32 
    let v627 : int32 = 32 |> int32 
    let v635 : int32 = v627 - 1
    let v637 : string = v13.[int v614..int v635]
    let v642 : string = v509 + v16 
    let v646 : string = v642 + v541 
    let v650 : string = v646 + v16 
    let v654 : string = v650 + v573 
    let v658 : string = v654 + v16 
    let v662 : string = v658 + v605 
    let v666 : string = v662 + v16 
    let v670 : string = v666 + v637 
    (* run_target_args'
    let v677 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v679 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v679 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v683 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v683 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v687 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v677 = v687 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v691 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v691 
    #endif
#if FABLE_COMPILER_PYTHON
    let v695 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v695 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v699 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v699 
    #endif
#else
    let v703 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v703 
    #endif
    let v706 : System.Guid = _run_target_args'_v677 
    let _run_target_args'_v246 = v706 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v716 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v246 = v716 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v724 : int32 = 0 |> int32 
    let v737 : int32 = 8 |> int32 
    let v745 : int32 = v737 - 1
    let v747 : string = v13.[int v724..int v745]
    let v756 : int32 = 8 |> int32 
    let v769 : int32 = 12 |> int32 
    let v777 : int32 = v769 - 1
    let v779 : string = v13.[int v756..int v777]
    let v788 : int32 = 12 |> int32 
    let v801 : int32 = 16 |> int32 
    let v809 : int32 = v801 - 1
    let v811 : string = v13.[int v788..int v809]
    let v820 : int32 = 16 |> int32 
    let v833 : int32 = 20 |> int32 
    let v841 : int32 = v833 - 1
    let v843 : string = v13.[int v820..int v841]
    let v852 : int32 = 20 |> int32 
    let v865 : int32 = 32 |> int32 
    let v873 : int32 = v865 - 1
    let v875 : string = v13.[int v852..int v873]
    let v880 : string = v747 + v16 
    let v884 : string = v880 + v779 
    let v888 : string = v884 + v16 
    let v892 : string = v888 + v811 
    let v896 : string = v892 + v16 
    let v900 : string = v896 + v843 
    let v904 : string = v900 + v16 
    let v908 : string = v904 + v875 
    (* run_target_args'
    let v915 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v917 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v917 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v921 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v921 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v925 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v915 = v925 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v929 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v929 
    #endif
#if FABLE_COMPILER_PYTHON
    let v933 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v933 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v937 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v937 
    #endif
#else
    let v941 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v941 
    #endif
    let v944 : System.Guid = _run_target_args'_v915 
    let _run_target_args'_v246 = v944 
    #endif
#if FABLE_COMPILER_PYTHON
    let v958 : int32 = 0 |> int32 
    let v971 : int32 = 8 |> int32 
    let v979 : int32 = v971 - 1
    let v981 : string = v13.[int v958..int v979]
    let v990 : int32 = 8 |> int32 
    let v1003 : int32 = 12 |> int32 
    let v1011 : int32 = v1003 - 1
    let v1013 : string = v13.[int v990..int v1011]
    let v1022 : int32 = 12 |> int32 
    let v1035 : int32 = 16 |> int32 
    let v1043 : int32 = v1035 - 1
    let v1045 : string = v13.[int v1022..int v1043]
    let v1054 : int32 = 16 |> int32 
    let v1067 : int32 = 20 |> int32 
    let v1075 : int32 = v1067 - 1
    let v1077 : string = v13.[int v1054..int v1075]
    let v1086 : int32 = 20 |> int32 
    let v1099 : int32 = 32 |> int32 
    let v1107 : int32 = v1099 - 1
    let v1109 : string = v13.[int v1086..int v1107]
    let v1114 : string = v981 + v16 
    let v1118 : string = v1114 + v1013 
    let v1122 : string = v1118 + v16 
    let v1126 : string = v1122 + v1045 
    let v1130 : string = v1126 + v16 
    let v1134 : string = v1130 + v1077 
    let v1138 : string = v1134 + v16 
    let v1142 : string = v1138 + v1109 
    (* run_target_args'
    let v1149 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1151 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1151 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1155 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1155 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1159 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1149 = v1159 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1163 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1163 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1167 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1167 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1171 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1171 
    #endif
#else
    let v1175 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1175 
    #endif
    let v1178 : System.Guid = _run_target_args'_v1149 
    let _run_target_args'_v246 = v1178 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1192 : int32 = 0 |> int32 
    let v1205 : int32 = 8 |> int32 
    let v1213 : int32 = v1205 - 1
    let v1215 : string = v13.[int v1192..int v1213]
    let v1224 : int32 = 8 |> int32 
    let v1237 : int32 = 12 |> int32 
    let v1245 : int32 = v1237 - 1
    let v1247 : string = v13.[int v1224..int v1245]
    let v1256 : int32 = 12 |> int32 
    let v1269 : int32 = 16 |> int32 
    let v1277 : int32 = v1269 - 1
    let v1279 : string = v13.[int v1256..int v1277]
    let v1288 : int32 = 16 |> int32 
    let v1301 : int32 = 20 |> int32 
    let v1309 : int32 = v1301 - 1
    let v1311 : string = v13.[int v1288..int v1309]
    let v1320 : int32 = 20 |> int32 
    let v1333 : int32 = 32 |> int32 
    let v1341 : int32 = v1333 - 1
    let v1343 : string = v13.[int v1320..int v1341]
    let v1348 : string = v1215 + v16 
    let v1352 : string = v1348 + v1247 
    let v1356 : string = v1352 + v16 
    let v1360 : string = v1356 + v1279 
    let v1364 : string = v1360 + v16 
    let v1368 : string = v1364 + v1311 
    let v1372 : string = v1368 + v16 
    let v1376 : string = v1372 + v1343 
    (* run_target_args'
    let v1383 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1385 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1385 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1389 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1389 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1393 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1383 = v1393 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1397 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1397 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1401 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1401 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1405 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1405 
    #endif
#else
    let v1409 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1409 
    #endif
    let v1412 : System.Guid = _run_target_args'_v1383 
    let _run_target_args'_v246 = v1412 
    #endif
#else
    let v1426 : int32 = 0 |> int32 
    let v1439 : int32 = 8 |> int32 
    let v1447 : int32 = v1439 - 1
    let v1449 : string = v13.[int v1426..int v1447]
    let v1458 : int32 = 8 |> int32 
    let v1471 : int32 = 12 |> int32 
    let v1479 : int32 = v1471 - 1
    let v1481 : string = v13.[int v1458..int v1479]
    let v1490 : int32 = 12 |> int32 
    let v1503 : int32 = 16 |> int32 
    let v1511 : int32 = v1503 - 1
    let v1513 : string = v13.[int v1490..int v1511]
    let v1522 : int32 = 16 |> int32 
    let v1535 : int32 = 20 |> int32 
    let v1543 : int32 = v1535 - 1
    let v1545 : string = v13.[int v1522..int v1543]
    let v1554 : int32 = 20 |> int32 
    let v1567 : int32 = 32 |> int32 
    let v1575 : int32 = v1567 - 1
    let v1577 : string = v13.[int v1554..int v1575]
    let v1582 : string = v1449 + v16 
    let v1586 : string = v1582 + v1481 
    let v1590 : string = v1586 + v16 
    let v1594 : string = v1590 + v1513 
    let v1598 : string = v1594 + v16 
    let v1602 : string = v1598 + v1545 
    let v1606 : string = v1602 + v16 
    let v1610 : string = v1606 + v1577 
    (* run_target_args'
    let v1617 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1619 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1619 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1623 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1623 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1627 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1617 = v1627 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1631 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1631 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1635 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1639 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1639 
    #endif
#else
    let v1643 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1643 
    #endif
    let v1646 : System.Guid = _run_target_args'_v1617 
    let _run_target_args'_v246 = v1646 
    #endif
    let v1655 : System.Guid = _run_target_args'_v246 
    v1655
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
