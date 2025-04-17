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
    let v256 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v258 : int32 = 1
    let v264 : int32 = 0 |> int32 
    let v277 : int32 = 8 |> int32 
    let v285 : int32 = v277 - v258
    let v287 : string = v13.[int v264..int v285]
    let v292 : int32 = 1
    let v298 : int32 = 8 |> int32 
    let v311 : int32 = 12 |> int32 
    let v319 : int32 = v311 - v292
    let v321 : string = v13.[int v298..int v319]
    let v326 : int32 = 1
    let v332 : int32 = 12 |> int32 
    let v345 : int32 = 16 |> int32 
    let v353 : int32 = v345 - v326
    let v355 : string = v13.[int v332..int v353]
    let v360 : int32 = 1
    let v366 : int32 = 16 |> int32 
    let v379 : int32 = 20 |> int32 
    let v387 : int32 = v379 - v360
    let v389 : string = v13.[int v366..int v387]
    let v394 : int32 = 1
    let v400 : int32 = 20 |> int32 
    let v413 : int32 = 32 |> int32 
    let v421 : int32 = v413 - v394
    let v423 : string = v13.[int v400..int v421]
    let v428 : string = v287 + v16 
    let v432 : string = v428 + v321 
    let v436 : string = v432 + v16 
    let v440 : string = v436 + v355 
    let v444 : string = v440 + v16 
    let v448 : string = v444 + v389 
    let v452 : string = v448 + v16 
    let v456 : string = v452 + v423 
    (* run_target_args'
    let v463 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v465 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v465 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v469 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v469 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v473 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v463 = v473 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v477 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v477 
    #endif
#if FABLE_COMPILER_PYTHON
    let v481 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v481 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v485 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v485 
    #endif
#else
    let v489 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v489 
    #endif
    let v492 : System.Guid = _run_target_args'_v463 
    let _run_target_args'_v256 = v492 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v502 : int32 = 1
    let v508 : int32 = 0 |> int32 
    let v521 : int32 = 8 |> int32 
    let v529 : int32 = v521 - v502
    let v531 : string = v13.[int v508..int v529]
    let v536 : int32 = 1
    let v542 : int32 = 8 |> int32 
    let v555 : int32 = 12 |> int32 
    let v563 : int32 = v555 - v536
    let v565 : string = v13.[int v542..int v563]
    let v570 : int32 = 1
    let v576 : int32 = 12 |> int32 
    let v589 : int32 = 16 |> int32 
    let v597 : int32 = v589 - v570
    let v599 : string = v13.[int v576..int v597]
    let v604 : int32 = 1
    let v610 : int32 = 16 |> int32 
    let v623 : int32 = 20 |> int32 
    let v631 : int32 = v623 - v604
    let v633 : string = v13.[int v610..int v631]
    let v638 : int32 = 1
    let v644 : int32 = 20 |> int32 
    let v657 : int32 = 32 |> int32 
    let v665 : int32 = v657 - v638
    let v667 : string = v13.[int v644..int v665]
    let v672 : string = v531 + v16 
    let v676 : string = v672 + v565 
    let v680 : string = v676 + v16 
    let v684 : string = v680 + v599 
    let v688 : string = v684 + v16 
    let v692 : string = v688 + v633 
    let v696 : string = v692 + v16 
    let v700 : string = v696 + v667 
    (* run_target_args'
    let v707 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v709 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v709 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v713 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v713 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v717 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v707 = v717 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v721 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v721 
    #endif
#if FABLE_COMPILER_PYTHON
    let v725 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v725 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v729 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v729 
    #endif
#else
    let v733 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v733 
    #endif
    let v736 : System.Guid = _run_target_args'_v707 
    let _run_target_args'_v256 = v736 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v746 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v256 = v746 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v750 : int32 = 1
    let v756 : int32 = 0 |> int32 
    let v769 : int32 = 8 |> int32 
    let v777 : int32 = v769 - v750
    let v779 : string = v13.[int v756..int v777]
    let v784 : int32 = 1
    let v790 : int32 = 8 |> int32 
    let v803 : int32 = 12 |> int32 
    let v811 : int32 = v803 - v784
    let v813 : string = v13.[int v790..int v811]
    let v818 : int32 = 1
    let v824 : int32 = 12 |> int32 
    let v837 : int32 = 16 |> int32 
    let v845 : int32 = v837 - v818
    let v847 : string = v13.[int v824..int v845]
    let v852 : int32 = 1
    let v858 : int32 = 16 |> int32 
    let v871 : int32 = 20 |> int32 
    let v879 : int32 = v871 - v852
    let v881 : string = v13.[int v858..int v879]
    let v886 : int32 = 1
    let v892 : int32 = 20 |> int32 
    let v905 : int32 = 32 |> int32 
    let v913 : int32 = v905 - v886
    let v915 : string = v13.[int v892..int v913]
    let v920 : string = v779 + v16 
    let v924 : string = v920 + v813 
    let v928 : string = v924 + v16 
    let v932 : string = v928 + v847 
    let v936 : string = v932 + v16 
    let v940 : string = v936 + v881 
    let v944 : string = v940 + v16 
    let v948 : string = v944 + v915 
    (* run_target_args'
    let v955 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v957 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v957 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v961 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v961 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v965 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v955 = v965 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v969 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v969 
    #endif
#if FABLE_COMPILER_PYTHON
    let v973 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v973 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v977 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v977 
    #endif
#else
    let v981 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v981 
    #endif
    let v984 : System.Guid = _run_target_args'_v955 
    let _run_target_args'_v256 = v984 
    #endif
#if FABLE_COMPILER_PYTHON
    let v994 : int32 = 1
    let v1000 : int32 = 0 |> int32 
    let v1013 : int32 = 8 |> int32 
    let v1021 : int32 = v1013 - v994
    let v1023 : string = v13.[int v1000..int v1021]
    let v1028 : int32 = 1
    let v1034 : int32 = 8 |> int32 
    let v1047 : int32 = 12 |> int32 
    let v1055 : int32 = v1047 - v1028
    let v1057 : string = v13.[int v1034..int v1055]
    let v1062 : int32 = 1
    let v1068 : int32 = 12 |> int32 
    let v1081 : int32 = 16 |> int32 
    let v1089 : int32 = v1081 - v1062
    let v1091 : string = v13.[int v1068..int v1089]
    let v1096 : int32 = 1
    let v1102 : int32 = 16 |> int32 
    let v1115 : int32 = 20 |> int32 
    let v1123 : int32 = v1115 - v1096
    let v1125 : string = v13.[int v1102..int v1123]
    let v1130 : int32 = 1
    let v1136 : int32 = 20 |> int32 
    let v1149 : int32 = 32 |> int32 
    let v1157 : int32 = v1149 - v1130
    let v1159 : string = v13.[int v1136..int v1157]
    let v1164 : string = v1023 + v16 
    let v1168 : string = v1164 + v1057 
    let v1172 : string = v1168 + v16 
    let v1176 : string = v1172 + v1091 
    let v1180 : string = v1176 + v16 
    let v1184 : string = v1180 + v1125 
    let v1188 : string = v1184 + v16 
    let v1192 : string = v1188 + v1159 
    (* run_target_args'
    let v1199 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1201 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1201 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1205 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1205 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1209 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1199 = v1209 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1213 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1213 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1217 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1217 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1221 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1221 
    #endif
#else
    let v1225 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1225 
    #endif
    let v1228 : System.Guid = _run_target_args'_v1199 
    let _run_target_args'_v256 = v1228 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1238 : int32 = 1
    let v1244 : int32 = 0 |> int32 
    let v1257 : int32 = 8 |> int32 
    let v1265 : int32 = v1257 - v1238
    let v1267 : string = v13.[int v1244..int v1265]
    let v1272 : int32 = 1
    let v1278 : int32 = 8 |> int32 
    let v1291 : int32 = 12 |> int32 
    let v1299 : int32 = v1291 - v1272
    let v1301 : string = v13.[int v1278..int v1299]
    let v1306 : int32 = 1
    let v1312 : int32 = 12 |> int32 
    let v1325 : int32 = 16 |> int32 
    let v1333 : int32 = v1325 - v1306
    let v1335 : string = v13.[int v1312..int v1333]
    let v1340 : int32 = 1
    let v1346 : int32 = 16 |> int32 
    let v1359 : int32 = 20 |> int32 
    let v1367 : int32 = v1359 - v1340
    let v1369 : string = v13.[int v1346..int v1367]
    let v1374 : int32 = 1
    let v1380 : int32 = 20 |> int32 
    let v1393 : int32 = 32 |> int32 
    let v1401 : int32 = v1393 - v1374
    let v1403 : string = v13.[int v1380..int v1401]
    let v1408 : string = v1267 + v16 
    let v1412 : string = v1408 + v1301 
    let v1416 : string = v1412 + v16 
    let v1420 : string = v1416 + v1335 
    let v1424 : string = v1420 + v16 
    let v1428 : string = v1424 + v1369 
    let v1432 : string = v1428 + v16 
    let v1436 : string = v1432 + v1403 
    (* run_target_args'
    let v1443 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1445 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1445 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1449 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1449 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1453 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1443 = v1453 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1457 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1457 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1461 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1461 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1465 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1465 
    #endif
#else
    let v1469 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1469 
    #endif
    let v1472 : System.Guid = _run_target_args'_v1443 
    let _run_target_args'_v256 = v1472 
    #endif
#else
    let v1482 : int32 = 1
    let v1488 : int32 = 0 |> int32 
    let v1501 : int32 = 8 |> int32 
    let v1509 : int32 = v1501 - v1482
    let v1511 : string = v13.[int v1488..int v1509]
    let v1516 : int32 = 1
    let v1522 : int32 = 8 |> int32 
    let v1535 : int32 = 12 |> int32 
    let v1543 : int32 = v1535 - v1516
    let v1545 : string = v13.[int v1522..int v1543]
    let v1550 : int32 = 1
    let v1556 : int32 = 12 |> int32 
    let v1569 : int32 = 16 |> int32 
    let v1577 : int32 = v1569 - v1550
    let v1579 : string = v13.[int v1556..int v1577]
    let v1584 : int32 = 1
    let v1590 : int32 = 16 |> int32 
    let v1603 : int32 = 20 |> int32 
    let v1611 : int32 = v1603 - v1584
    let v1613 : string = v13.[int v1590..int v1611]
    let v1618 : int32 = 1
    let v1624 : int32 = 20 |> int32 
    let v1637 : int32 = 32 |> int32 
    let v1645 : int32 = v1637 - v1618
    let v1647 : string = v13.[int v1624..int v1645]
    let v1652 : string = v1511 + v16 
    let v1656 : string = v1652 + v1545 
    let v1660 : string = v1656 + v16 
    let v1664 : string = v1660 + v1579 
    let v1668 : string = v1664 + v16 
    let v1672 : string = v1668 + v1613 
    let v1676 : string = v1672 + v16 
    let v1680 : string = v1676 + v1647 
    (* run_target_args'
    let v1687 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1689 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1689 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1693 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1693 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1697 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1687 = v1697 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1701 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1701 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1705 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1705 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1709 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1709 
    #endif
#else
    let v1713 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1713 
    #endif
    let v1716 : System.Guid = _run_target_args'_v1687 
    let _run_target_args'_v256 = v1716 
    #endif
    let v1725 : System.Guid = _run_target_args'_v256 
    v1725
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
