type Mut0 = {mutable l0 : int32}
and Mut1 = {mutable l0 : int32}
and UH0 =
    | UH0_0
    | UH0_1 of int32 * UH0
and Mut2 = {mutable l0 : UH0}
let rec method0 (v0 : Mut0) : bool =
    let v1 : int32 = v0.l0
    let v2 : bool = v1 < 3
    v2
and method1 (v0 : Mut1) : bool =
    let v1 : int32 = v0.l0
    let v2 : bool = v1 < 4
    v2
let v0 : (int32 []) = Array.zeroCreate<int32> (3)
let v1 : Mut0 = {l0 = 0} : Mut0
while method0(v1) do
    let v3 : int32 = v1.l0
    let v4 : int32 = v3 * 5
    v0.[int v3] <- v4
    let v5 : int32 = v3 + 1
    v1.l0 <- v5
    ()
let v6 : Mut1 = {l0 = 0} : Mut1
let v7 : Mut1 = {l0 = 0} : Mut1
let v8 : UH0 = UH0_0
let v9 : Mut2 = {l0 = v8} : Mut2
while method1(v6) do
    let v11 : int32 = v6.l0
    let v12 : int32 = v11 % 2
    let v13 : bool = v12 = 1
    if v13 then
        let v14 : int32 = v7.l0
        let v15 : int32 = v14 + 1
        v7.l0 <- v15
        ()
    let v16 : UH0 = v9.l0
    let v17 : UH0 = UH0_1(v11, v16)
    v9.l0 <- v17
    let v18 : int32 = v11 + 1
    v6.l0 <- v18
    ()
let v19 : UH0 = v9.l0
let v38 : int32 =
    match v19 with
    | UH0_1(v20, v21) -> (* Cons *)
        match v21 with
        | UH0_1(v22, v23) -> (* Cons *)
            match v23 with
            | UH0_1(v24, v25) -> (* Cons *)
                match v25 with
                | UH0_1(v26, v27) -> (* Cons *)
                    match v27 with
                    | UH0_0 -> (* Nil *)
                        let v28 : int32 = v20 * 64
                        let v29 : int32 = v22 * 16
                        let v30 : int32 = v28 + v29
                        let v31 : int32 = v24 * 4
                        let v32 : int32 = v30 + v31
                        let v33 : int32 = v32 + v26
                        v33
                    | _ ->
                        -1
                | _ ->
                    -1
            | _ ->
                -1
        | _ ->
            -1
    | _ ->
        -1
let v39 : int32 = v7.l0
let v40 : int32 = v38 + v39
let v41 : int32 = v0.[int 2]
let v42 : int32 = v40 + v41
let v43 : int32 = v0.[int 1]
let v44 : int32 = v42 - v43
v44
