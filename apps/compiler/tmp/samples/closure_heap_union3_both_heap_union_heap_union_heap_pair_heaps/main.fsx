type Heap0 = {l0 : int32; l1 : string}
and Heap1 = {l0 : Heap0; l1 : Heap0}
and Heap2 = {l0 : Heap1; l1 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Held of f1_0 : Heap2
and Heap3 = {l0 : US0}
and [<Struct>] US1 =
    | US1_Absent
    | US1_Box of f1_0 : Heap3
    | US1_Mark of f2_0 : int32
and Heap4 = {l0 : US1}
and Mut0 = {mutable l0 : Heap4}
let rec f_c0 (v0 : Heap4, v1 : Heap4) (v2 : int32) : Heap4 =
    let v3 : bool = v2 = 0
    if v3 then
        v1
    else
        v0
and score_0 (v0 : US1) : int32 =
    match v0 with
    | US1_Absent -> (* Absent *)
        1
    | US1_Box(v3) -> (* Box *)
        let v4 : US0 = v3.l0
        match v4 with
        | US0_Held(v5) -> (* Held *)
            let struct (v6 : Heap1, v7 : int32) = v5.l0, v5.l1
            let struct (v8 : Heap0, v9 : Heap0) = v6.l0, v6.l1
            let struct (v10 : int32, v11 : string) = v8.l0, v8.l1
            let struct (v12 : int32, v13 : string) = v9.l0, v9.l1
            let v14 : bool = v10 = 7
            let v16 : bool =
                if v14 then
                    let v15 : bool = v11 = "hi"
                    v15
                else
                    false
            let v18 : bool =
                if v16 then
                    let v17 : bool = v12 = 4
                    v17
                else
                    false
            let v20 : bool =
                if v18 then
                    let v19 : bool = v13 = "yo"
                    v19
                else
                    false
            let v22 : bool =
                if v20 then
                    let v21 : bool = v7 = 2
                    v21
                else
                    false
            if v22 then
                0
            else
                1
        | US0_None -> (* None *)
            1
    | US1_Mark(v1) -> (* Mark *)
        let v2 : bool = v1 = 0
        1
let v0 : int32 = 7
let v1 : string = "hi"
let v2 : Heap0 = {l0 = v0; l1 = v1} : Heap0
let v3 : int32 = 4
let v4 : string = "yo"
let v5 : Heap0 = {l0 = v3; l1 = v4} : Heap0
let v6 : Heap1 = {l0 = v2; l1 = v5} : Heap1
let v7 : int32 = 2
let v8 : Heap2 = {l0 = v6; l1 = v7} : Heap2
let v9 : bool = true
let v12 : US0 =
    if v9 then
        US0_Held(v8)
    else
        US0_None
let v13 : Heap3 = {l0 = v12} : Heap3
let v14 : bool = true
let v17 : US1 =
    if v14 then
        US1_Box(v13)
    else
        US1_Mark(1)
let v18 : int32 = 3
let v19 : Heap4 = {l0 = v17} : Heap4
let v20 : US1 = US1_Mark(v18)
let v21 : Heap4 = {l0 = v20} : Heap4
let v22 : (int32 -> Heap4) = f_c0(v19, v21)
let v23 : Heap4 = v22 1
let v24 : Mut0 = {l0 = v23} : Mut0
let v25 : Heap4 = v24.l0
let v26 : US1 = v25.l0
let v27 : int32 = score_0(v26)
let v28 : Heap4 = v22 0
v24.l0 <- v28
let v29 : Heap4 = v24.l0
let v30 : US1 = v29.l0
let v31 : int32 = score_0(v30)
let v32 : bool = v27 = 0
let v34 : bool =
    if v32 then
        let v33 : bool = v31 = 1
        v33
    else
        false
if v34 then
    0
else
    1
