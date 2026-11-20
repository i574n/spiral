let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
type [<Struct>] US0 =
    | US0_Hit of f0_0 : int32
    | US0_Miss
and [<Struct>] US1 =
    | US1_Good of f0_0 : int32
    | US1_Bad of f1_0 : string
and UH0 =
    | UH0_End
    | UH0_Word of string * UH0
let rec closure1 (v0 : int32) (v1 : string) : US0 =
    let v2 : bool = v1 = "frames"
    if v2 then
        let v3 : int32 = v0 + 1
        US0_Hit(v3)
    else
        US0_Miss
and closure0 () (v0 : int32) : (string -> US0) =
    closure1(v0)
and closure4 (v0 : int32, v1 : string) (v2 : string) : US1 =
    let v3 : bool = v1 = "spi"
    if v3 then
        let v4 : int32 = v0 + 10
        US1_Good(v4)
    else
        let v6 : string = ("executor is fake, got " + v2)
        US1_Bad(v6)
and closure3 (v0 : int32) (v1 : string) : (string -> US1) =
    closure4(v0, v1)
and closure2 () (v0 : int32) : (string -> (string -> US1)) =
    closure3(v0)
and starts_1 (v0 : string, v1 : string) : bool =
    let v2 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
    let v3 : bool = 1 < v2
    if v3 then
        let v4 : string = (spiralStringSlice v1 (int 0) (int 1))
        let v5 : bool = v4 = v0
        v5
    else
        false
and continued_4 (v0 : (int32 -> (string -> US0)), v1 : (int32 -> (string -> (string -> US1))), v2 : US1, v3 : UH0) : US1 =
    match v2 with
    | US1_Bad(v6) -> (* Bad *)
        US1_Bad(v6)
    | US1_Good(v4) -> (* Good *)
        flags_parsed_0(v0, v1, v4, v3)
and valued_then_3 (v0 : (int32 -> (string -> US0)), v1 : (int32 -> (string -> (string -> US1))), v2 : int32, v3 : string, v4 : UH0) : US1 =
    match v4 with
    | UH0_End -> (* End *)
        let v18 : string = "--"
        let v19 : bool = starts_1(v18, v3)
        let v24 : string =
            if v19 then
                let v20 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
                let v21 : int32 = v20 - 1
                let v22 : string = (spiralStringSlice v3 (int 2) (int v21))
                v22
            else
                let v23 : string = ""
                v23
        let v25 : string = (v24 + " needs a value")
        US1_Bad(v25)
    | UH0_Word(v5, v6) -> (* Word *)
        let v7 : (string -> (string -> US1)) = v1 v2
        let v8 : string = "--"
        let v9 : bool = starts_1(v8, v3)
        let v14 : string =
            if v9 then
                let v10 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
                let v11 : int32 = v10 - 1
                let v12 : string = (spiralStringSlice v3 (int 2) (int v11))
                v12
            else
                let v13 : string = ""
                v13
        let v15 : (string -> US1) = v7 v14
        let v16 : US1 = v15 v5
        continued_4(v0, v1, v16, v6)
and arg_parsed_2 (v0 : (int32 -> (string -> US0)), v1 : (int32 -> (string -> (string -> US1))), v2 : int32, v3 : string, v4 : UH0) : US1 =
    let v5 : (string -> US0) = v0 v2
    let v6 : string = "--"
    let v7 : bool = starts_1(v6, v3)
    let v12 : string =
        if v7 then
            let v8 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
            let v9 : int32 = v8 - 1
            let v10 : string = (spiralStringSlice v3 (int 2) (int v9))
            v10
        else
            let v11 : string = ""
            v11
    let v13 : US0 = v5 v12
    match v13 with
    | US0_Hit(v14) -> (* Hit *)
        flags_parsed_0(v0, v1, v2, v4)
    | US0_Miss -> (* Miss *)
        valued_then_3(v0, v1, v2, v3, v4)
and flags_parsed_0 (v0 : (int32 -> (string -> US0)), v1 : (int32 -> (string -> (string -> US1))), v2 : int32, v3 : UH0) : US1 =
    match v3 with
    | UH0_End -> (* End *)
        US1_Good(v2)
    | UH0_Word(v5, v6) -> (* Word *)
        let v7 : string = "--"
        let v8 : bool = starts_1(v7, v5)
        let v13 : string =
            if v8 then
                let v9 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v5))
                let v10 : int32 = v9 - 1
                let v11 : string = (spiralStringSlice v5 (int 2) (int v10))
                v11
            else
                let v12 : string = ""
                v12
        let v14 : bool = v13 = ""
        if v14 then
            let v15 : string = ("unexpected " + v5)
            US1_Bad(v15)
        else
            arg_parsed_2(v0, v1, v2, v5, v6)
let v0 : (int32 -> (string -> US0)) = closure0()
let v1 : (int32 -> (string -> (string -> US1))) = closure2()
let v2 : int32 = 0
let v3 : string = "--spi"
let v4 : string = "a.spi"
let v5 : string = "--executor"
let v6 : string = "gpu"
let v7 : UH0 = UH0_End
let v8 : UH0 = UH0_Word(v6, v7)
let v9 : UH0 = UH0_Word(v5, v8)
let v10 : UH0 = UH0_Word(v4, v9)
let v11 : UH0 = UH0_Word(v3, v10)
let v12 : US1 = flags_parsed_0(v0, v1, v2, v11)
match v12 with
| US1_Bad(v13) -> (* Bad *)
    let v14 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v13))
    let v15 : bool = v14 = 25
    if v15 then
        0
    else
        1
| US1_Good(v17) -> (* Good *)
    2
