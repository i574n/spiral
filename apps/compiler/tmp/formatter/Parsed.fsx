#load "Lexed.fsx"

open System
open System.Text
open Microsoft.FSharp.Reflection
open Spiral.spiral_compiler
open Lexed

let environmentOf edition : DefaultEnv =
    { port = 0
      default_int = Int32T
      default_uint = UInt32T
      default_float = Float64T
      edition = (match edition with Edition2 -> UpstreamEdition2 | Edition3 -> ForkEdition3) }

let isPosition (shape : Type) =
    FSharpType.IsRecord (shape, true)
    && (FSharpType.GetRecordFields (shape, true) |> Array.map (fun field -> field.Name) |> Array.sort) = [| "character"; "line" |]

let rec foldedConcat (value : obj) : string option =
    if isNull value then None
    else
        let shape = value.GetType ()
        if not (FSharpType.IsUnion (shape, true)) then None
        else
            let case, fields = FSharpValue.GetUnionFields (value, shape, true)
            match case.Name with
            | "RawLit" when fields.Length = 2 ->
                let literal = fields.[1]
                let literalCase, literalFields = FSharpValue.GetUnionFields (literal, literal.GetType (), true)
                if literalCase.Name = "LitString" then Some (literalFields.[0] :?> string) else None
            | "RawApply" when fields.Length = 3 && not (isNull fields.[1]) ->
                let inner = fields.[1]
                let innerCase, innerFields = FSharpValue.GetUnionFields (inner, inner.GetType (), true)
                if innerCase.Name <> "RawApply" || innerFields.Length <> 3 || isNull innerFields.[1] then None
                else
                    let operatorCase, operatorFields = FSharpValue.GetUnionFields (innerFields.[1], innerFields.[1].GetType (), true)
                    if operatorCase.Name = "RawV" && operatorFields.Length >= 2 && (operatorFields.[1] :? string) && (operatorFields.[1] :?> string) = "^^" then
                        match foldedConcat innerFields.[2], foldedConcat fields.[2] with
                        | Some a, Some b -> Some (a + b)
                        | _ -> None
                    else None
            | "RawAnnot" when fields.Length = 3 && not (isNull fields.[2]) ->
                let typeCase, typeFields = FSharpValue.GetUnionFields (fields.[2], fields.[2].GetType (), true)
                if typeCase.Name = "RawTPrim" && typeFields.Length = 2 && string typeFields.[1] = "StringT" then foldedConcat fields.[1] else None
            | "RawOp" when fields.Length = 3 ->
                let opCase, _ = FSharpValue.GetUnionFields (fields.[1], fields.[1].GetType (), true)
                if opCase.Name <> "StaticStringConcat" then None
                else
                    let args = (fields.[2] :?> Collections.IEnumerable) |> Seq.cast<obj> |> List.ofSeq
                    match args |> List.map foldedConcat with
                    | [ Some a; Some b ] -> Some (a + b)
                    | _ -> None
            | _ -> None

type ShapeStep =
    | Emit of string
    | Visit of obj

let rawSeqHalves (item : obj) =
    if isNull item || not (FSharpType.IsUnion (item.GetType (), true)) then None
    else
        let case, fields = FSharpValue.GetUnionFields (item, item.GetType (), true)
        if case.Name = "RawSeq" && fields.Length = 3 then Some (fields.[1], fields.[2]) else None

let sequenced (value : obj) =
    let items = ResizeArray<obj> ()
    let unopened = Collections.Generic.Stack<obj> ()
    unopened.Push value
    while unopened.Count > 0 do
        let item = unopened.Pop ()
        match rawSeqHalves item with
        | Some (first, rest) ->
            unopened.Push rest
            unopened.Push first
        | None -> items.Add item
    List.ofSeq items

let macroTextOf (item : obj) =
    if isNull item || not (FSharpType.IsUnion (item.GetType (), true)) then None
    else
        let case, fields = FSharpValue.GetUnionFields (item, item.GetType (), true)
        if case.Name = "RawMacroText" && fields.Length = 2 && (fields.[1] :? string) then Some (fields.[1] :?> string) else None

let enumeratedSteps (value : Collections.IEnumerable) =
    let steps = ResizeArray<ShapeStep> ()
    let joined = StringBuilder ()
    let flush () =
        if joined.Length > 0 then
            steps.Add (Emit ("(RawMacroText <pp> \"" + string joined.Length + ":" + joined.ToString () + ")"))
            joined.Clear () |> ignore
    for item in value do
        match macroTextOf item with
        | Some text -> joined.Append text |> ignore
        | None ->
            flush ()
            steps.Add (Visit item)
    flush ()
    List.ofSeq steps

let shapeSteps (value : obj) : ShapeStep list =
    let enclosed (opening : string) (children : obj seq) (closing : string) = Emit opening :: [ for child in children -> Visit child ] @ [ Emit closing ]
    let spaced (opening : string) (children : obj seq) = Emit opening :: [ for child in children do yield! [ Emit " "; Visit child ] ] @ [ Emit ")" ]
    match value with
    | null -> [ Emit "n" ]
    | :? string as text -> [ Emit ("\"" + string text.Length + ":" + text) ]
    | :? bool | :? char | :? int | :? int8 | :? int16 | :? int64 | :? uint8 | :? uint16 | :? uint32 | :? uint64 -> [ Emit (value.ToString () + ";") ]
    | :? float32 as number -> [ Emit (string (BitConverter.SingleToInt32Bits number) + "f") ]
    | :? float as number -> [ Emit (string (BitConverter.DoubleToInt64Bits number) + "d") ]
    | _ ->
        let shape = value.GetType ()
        if isPosition shape then [ Emit "p" ]
        elif shape.IsEnum then [ Emit (value.ToString () + ";") ]
        elif FSharpType.IsUnion (shape, true) then
            match foldedConcat value with
            | Some text -> [ Emit ("(RawLit <pp> (LitString \"" + string text.Length + ":" + text + "))") ]
            | None when (rawSeqHalves value).IsSome -> spaced "(RawSeq*" (sequenced value)
            | None ->
                let case, fields = FSharpValue.GetUnionFields (value, shape, true)
                spaced ("(" + case.Name) fields
        elif FSharpType.IsTuple shape then enclosed "<" (FSharpValue.GetTupleFields value) ">"
        elif FSharpType.IsRecord (shape, true) then enclosed "{" (FSharpValue.GetRecordFields (value, true)) "}"
        elif shape.IsGenericType && shape.GetGenericTypeDefinition () = typedefof<Collections.Generic.KeyValuePair<_, _>> then
            enclosed "{" [ shape.GetProperty("Key").GetValue value; shape.GetProperty("Value").GetValue value ] "}"
        elif shape.IsArray then enclosed "[" (Seq.cast<obj> (value :?> Array)) "]"
        elif typeof<Collections.IEnumerable>.IsAssignableFrom shape then
            Emit "[" :: enumeratedSteps (value :?> Collections.IEnumerable) @ [ Emit "]" ]
        else [ Emit ("?" + shape.Name) ]

let shapeOf (builder : StringBuilder) (root : obj) =
    let pending = Collections.Generic.Stack<ShapeStep> ()
    pending.Push (Visit root)
    while pending.Count > 0 do
        match pending.Pop () with
        | Emit text -> builder.Append text |> ignore
        | Visit value -> for step in List.rev (shapeSteps value) do pending.Push step

type BlockShape =
    { Offset : int
      Shape : string }

let blockShapes (edition : Edition) (unit : Unit') (text : string) =
    let state = wdiff_tokenizer_all wdiff_tokenizer_init text
    let environment = environmentOf edition
    let topDown = (match unit with TopDown -> true | BottomUp -> false)
    let shapeOfResult (result : ParseResult) =
        let builder = StringBuilder ()
        match result with
        | Ok statement -> shapeOf builder (box statement)
        | Error errors ->
            builder.Append "error" |> ignore
            for (_, error) in errors do
                builder.Append ' ' |> ignore
                shapeOf builder (box error)
        builder.ToString ()
    let testHeader (block : LineTokens Block) =
        block.block
        |> Seq.tryFindIndex (fun line -> line.Length > 0)
        |> Option.bind (fun index ->
            match snd block.block.[index].[0] with
            | TokVar ("test", _) -> Some index
            | _ -> None)
    state.blocks
    |> List.map (fun block ->
        match testHeader block with
        | Some header ->
            let body = [ for index in header + 1 .. block.block.Length - 1 -> state.lines_text.[block.offset + index] ]
            let headerText = state.lines_text.[block.offset + header]
            let sameLine =
                block.block.[header]
                |> Seq.tryFind (fun (_, token) -> match token with TokOperator ("=", _) -> true | _ -> false)
                |> Option.map (fun (range, _) -> headerText.Substring range.nearTo)
                |> Option.defaultValue ""
            let synthetic = String.concat "\n" (("inl test_block_body () =" + sameLine) :: body)
            let inner = wdiff_tokenizer_all wdiff_tokenizer_init synthetic
            let shape =
                match inner.blocks with
                | first :: _ ->
                    "test " + shapeOfResult (parse_block environment topDown first.block).result
                | [] -> "test empty"
            { Offset = block.offset; Shape = shape }
        | None -> { Offset = block.offset; Shape = shapeOfResult (parse_block environment topDown block.block).result })

let shapeKeyOf (shapes : BlockShape list) =
    shapes |> List.map (fun shape -> shape.Shape) |> String.concat "\n"

type ParseAgreement =
    | SameParse
    | ParseDiffers of firstBlockLine : int
    | OriginalHasErrors

let compareParses (edition : Edition) (unit : Unit') (before : string) (after : string) =
    let left = blockShapes edition unit before |> List.filter (fun block -> block.Shape <> "error")
    let leftHasErrors = left |> List.exists (fun block -> block.Shape.StartsWith "error (" || block.Shape.StartsWith "test error (")
    let right = blockShapes edition unit after |> List.filter (fun block -> block.Shape <> "error")
    let pairs = List.zip (List.truncate (min left.Length right.Length) left) (List.truncate (min left.Length right.Length) right)
    match pairs |> List.tryFind (fun (a, b) -> a.Shape <> b.Shape && not (a.Shape.StartsWith "error (") && not (a.Shape.StartsWith "test error (")) with
    | Some (a, _) when not leftHasErrors || left.Length = right.Length -> ParseDiffers (a.Offset + 1)
    | _ when left.Length <> right.Length && leftHasErrors -> OriginalHasErrors
    | Some (a, _) -> ParseDiffers (a.Offset + 1)
    | None when left.Length <> right.Length ->
        let line = if left.Length < right.Length then right.[left.Length].Offset else left.[right.Length].Offset
        ParseDiffers (line + 1)
    | None -> SameParse
