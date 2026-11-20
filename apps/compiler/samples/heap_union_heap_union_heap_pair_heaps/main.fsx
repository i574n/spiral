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
and Heap4 = {l0 : US1}
let rec score_0 (v0 : US1) : int32 =
    match v0 with
    | US1_Absent -> (* Absent *)
        1
    | US1_Box(v1) -> (* Box *)
        let v2 : US0 = v1.l0
        match v2 with
        | US0_Held(v3) -> (* Held *)
            let struct (v4 : Heap1, v5 : int32) = v3.l0, v3.l1
            let struct (v6 : Heap0, v7 : Heap0) = v4.l0, v4.l1
            let struct (v8 : int32, v9 : string) = v6.l0, v6.l1
            let struct (v10 : int32, v11 : string) = v7.l0, v7.l1
            let v12 : bool = v8 = 7
            let v14 : bool =
                if v12 then
                    let v13 : bool = v9 = "hi"
                    v13
                else
                    false
            let v16 : bool =
                if v14 then
                    let v15 : bool = v10 = 4
                    v15
                else
                    false
            let v18 : bool =
                if v16 then
                    let v17 : bool = v11 = "yo"
                    v17
                else
                    false
            let v20 : bool =
                if v18 then
                    let v19 : bool = v5 = 2
                    v19
                else
                    false
            if v20 then
                0
            else
                1
        | US0_None -> (* None *)
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
        US1_Absent
let v18 : Heap4 = {l0 = v17} : Heap4
let v19 : US1 = v18.l0
score_0(v19)
