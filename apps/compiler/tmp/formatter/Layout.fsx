#load "Lexed.fsx" "Flatten.fsx" "Parsed.fsx"

open System.Text
open Polyglot.spiral_compiler
open Lexed
open Flatten
open Parsed

type Node =
    | Leaf of Lexeme
    | Group of opening : Lexeme * inner : Node list * closing : Lexeme

type LaidLine = { Indent : int; Text : string }

let rec firstLexeme (node : Node) =
    match node with
    | Leaf lexeme -> lexeme
    | Group (opening, _, _) -> opening

let isStringGroup (node : Node) =
    match node with
    | Group (opening, _, _) -> opening.Token = TokStringOpen
    | _ -> false

let isConcatOperator (node : Node) =
    match node with
    | Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokOperator ("^^", _) -> true | _ -> false)
    | _ -> false

let rec mergeConcatenations (nodes : Node list) : Node list =
    match nodes with
    | (Group (opening, inner, _) as first) :: op :: (Group (_, nextInner, nextClosing) as second) :: rest when isStringGroup first && isConcatOperator op && isStringGroup second ->
        let glued =
            match nextInner with
            | Leaf lexeme :: tail -> Leaf { lexeme with Before = Whitespace 0 } :: tail
            | other -> other
        mergeConcatenations (Group (opening, inner @ glued, nextClosing) :: rest)
    | node :: rest -> node :: mergeConcatenations rest
    | [] -> []

let rec nodesOf (lexemes : Lexeme list) : Node list * Lexeme list =
    match lexemes with
    | [] -> [], []
    | lexeme :: rest ->
        match lexeme.Token with
        | TokParenthesis (_, Open) when not lexeme.InsideMacro ->
            let inner, afterInner = nodesOf rest
            match afterInner with
            | closing :: afterClosing ->
                let siblings, remaining = nodesOf afterClosing
                Group (lexeme, inner, closing) :: siblings, remaining
            | [] -> [ Leaf lexeme ], []
        | TokParenthesis (_, Close) when not lexeme.InsideMacro -> [], lexemes
        | TokStringOpen | TokMacroOpen ->
            let closing = match lexeme.Token with TokStringOpen -> TokStringClose | _ -> TokMacroClose
            let rec collect (rest : Lexeme list) (depth : int) (taken : Lexeme list) =
                match rest with
                | next :: tail when next.Token = lexeme.Token -> collect tail (depth + 1) (next :: taken)
                | next :: tail when next.Token = closing && depth = 0 -> List.rev taken, Some next, tail
                | next :: tail when next.Token = closing -> collect tail (depth - 1) (next :: taken)
                | next :: tail -> collect tail depth (next :: taken)
                | [] -> List.rev taken, None, []
            match collect rest 0 [] with
            | inside, Some closingLexeme, after ->
                let siblings, remaining = nodesOf after
                Group (lexeme, inside |> List.map Leaf, closingLexeme) :: siblings, remaining
            | _ ->
                let siblings, remaining = nodesOf rest
                Leaf lexeme :: siblings, remaining
        | _ ->
            let siblings, remaining = nodesOf rest
            Leaf lexeme :: siblings, remaining

let gapBefore (lexeme : Lexeme) =
    match lexeme.Before with
    | Whitespace 0 -> ""
    | Whitespace _ -> " "
    | Embedded text when text.Text.Replace("(* *)", "").Trim().Length = 0 -> " "
    | Embedded text -> text.Text

let commaBeforeKeyword (nodes : Node list) =
    nodes
    |> List.takeWhile (fun node -> match node with Leaf l -> not (not l.InsideMacro && (match l.Token with TokKeyword _ -> true | _ -> false)) | Group _ -> true)
    |> List.exists (fun node -> match node with Leaf l -> not l.InsideMacro && (match l.Token with TokOperator (",", _) -> true | _ -> false) | Group _ -> false)

let rec simplify (nodes : Node list) : Node list =
    let isRound (opening : Lexeme) = opening.Token = TokParenthesis (Round, Open)
    let mapped =
        nodes
        |> List.map (fun node ->
            match node with
            | Group (opening, [ Group (innerOpening, inner, innerClosing) ], _) when isRound opening && isRound innerOpening && not inner.IsEmpty ->
                Group (opening, simplify inner, innerClosing)
            | Group (opening, inner, closing) -> Group (opening, simplify inner, closing)
            | Leaf _ -> node)
    let rec afterArrow (rest : Node list) =
        match rest with
        | arrow :: [ Group (opening, inner, _) ] when (match arrow with Leaf l -> (match l.Token with TokOperator ("=>", _) | TokKeyword (SpecThen | SpecElse | SpecIn) -> not l.InsideMacro | _ -> false) | Group _ -> false)
                                                     && isRound opening && not inner.IsEmpty && not (match inner with Leaf l :: _ -> (match l.Token with TokKeyword (SpecInl | SpecLet | SpecOpen) -> true | _ -> false) | _ -> false) && not (List.exists (function Leaf l -> not l.InsideMacro && (l.Token = TokKeyword SpecIn || (match l.Token with TokOperator (".", _) -> true | _ -> false)) | Group _ -> false) inner) && ((match arrow with Leaf l -> (match l.Token with TokOperator ("=>", _) -> true | _ -> false) | Group _ -> false) || not (commaBeforeKeyword inner) || (match inner with Leaf l :: _ -> (match l.Token with TokKeyword _ -> true | _ -> false) | _ -> false)) ->
            [ arrow ] @ withGap arrow inner
        | node :: tail -> node :: afterArrow tail
        | [] -> []
    and withGap (arrow : Node) (inner : Node list) =
        match inner with
        | Leaf first :: tail -> Leaf { first with Before = Whitespace 1 } :: tail
        | Group (opening, i, c) :: tail -> Group ({ opening with Before = Whitespace 1 }, i, c) :: tail
        | [] -> []

    afterArrow mapped

let rec inlineText (raw : Node list) =
    let nodes = simplify raw
    let builder = StringBuilder ()
    let rec emit (first : bool) (node : Node) =
        match node with
        | Leaf lexeme ->
            if not first then builder.Append (gapBefore lexeme) |> ignore
            builder.Append lexeme.Text.Text |> ignore
        | Group (opening, inner, closing) ->
            if not first then builder.Append (gapBefore opening) |> ignore
            builder.Append opening.Text.Text |> ignore
            let padded =
                not inner.IsEmpty
                && not opening.InsideMacro
                && (match opening.Token with
                    | TokParenthesis (Square, Open) -> true
                    | TokParenthesis (Curly, Open) -> (match (firstLexeme (List.head inner)).Before with Whitespace 0 -> false | _ -> true)
                    | _ -> false)
            if padded then builder.Append ' ' |> ignore
            inner |> List.iteri (fun index child -> emit (index = 0) child)
            if padded then builder.Append ' ' |> ignore
            builder.Append closing.Text.Text |> ignore
    nodes |> List.iteri (fun index node -> emit (index = 0) node)
    builder.ToString ()

let bareTrailingLambda (list : Node list) =
    let isRound (opening : Lexeme) = opening.Token = TokParenthesis (Round, Open)
    let rec strip (node : Node) =
        match node with
        | Group (opening, [ (Group (innerOpening, _, _) as inner) ], _) when isRound opening && isRound innerOpening -> strip inner
        | _ -> node
    match List.rev list with
    | last :: before ->
        match strip last with
        | Group (opening, (first :: _ as inner), _) when isRound opening && (match first with Leaf l -> not l.InsideMacro && (l.Token = TokKeyword SpecFun || l.Token = TokKeyword SpecFunction) | Group _ -> false) ->
            List.rev before @ (match inner with Leaf l :: tail -> Leaf { l with Before = Whitespace 1 } :: tail | other -> other)
        | _ -> list
    | _ -> list

let inlineComplete (nodes : Node list) = inlineText (bareTrailingLambda (simplify nodes))

let isKeyword (keyword : TokenKeyword) (node : Node) =
    match node with
    | Leaf lexeme -> not lexeme.InsideMacro && lexeme.Token = TokKeyword keyword
    | Group _ -> false

let isOperator (name : string) (node : Node) =
    match node with
    | Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokOperator (found, _) -> found = name | _ -> false)
    | Group _ -> false

let splitOn (separator : Node -> bool) (nodes : Node list) =
    let segments = ResizeArray<Node list> ()
    let current = ResizeArray<Node> ()
    let mutable quantified = false
    for node in nodes do
        if isKeyword SpecForall node || isKeyword SpecExists node then quantified <- true
        if quantified && isOperator "." node then
            quantified <- false
            current.Add node
        elif separator node then
            segments.Add (List.ofSeq current)
            current.Clear ()
        else current.Add node
    segments.Add (List.ofSeq current)
    List.ofSeq segments

let isStatement (nodes : Node list) =
    match nodes with
    | first :: _ -> isKeyword SpecInl first || isKeyword SpecLet first || isKeyword SpecOpen first
    | [] -> false

let commentsIn (gap : string) =
    let parts = ResizeArray<string> ()
    let mutable rest = gap
    while rest.Contains "(*" && rest.Contains "*)" do
        let start = rest.IndexOf "(*"
        let stop = rest.IndexOf ("*)", start)
        parts.Add (rest.Substring(start + 2, stop - start - 2).Trim ())
        rest <- rest.Substring (stop + 2)
    List.ofSeq parts
let trailingRemark (node : Node) =
    match node with
    | Leaf lexeme ->
        match lexeme.Before with
        | Embedded gap -> (commentsIn gap.Text |> List.filter (fun comment -> comment <> "")).Length = 1
        | Whitespace _ -> false
    | Group _ -> false

let statements (nodes : Node list) =
    let segments = ResizeArray<Node list> ()
    let current = ResizeArray<Node> ()
    let mutable openStatements = 0
    let mutable quantified = false
    let mutable inArms = false
    for node in nodes do
        if isKeyword SpecForall node || isKeyword SpecExists node then quantified <- true
        if openStatements = 0 && (isKeyword SpecWith node || isKeyword SpecFunction node) then inArms <- true
        if quantified && isOperator "." node then
            quantified <- false
            current.Add node
        elif isKeyword SpecIn node then
            openStatements <- openStatements - 1
            if openStatements = 0 then
                if trailingRemark node then current.Add node
                segments.Add (List.ofSeq current)
                current.Clear ()
            else current.Add node
        elif isOperator "." node && openStatements = 0 && not inArms then
            if trailingRemark node then current.Add node
            segments.Add (List.ofSeq current)
            current.Clear ()
        else
            if (isKeyword SpecInl node || isKeyword SpecLet node || isKeyword SpecOpen node) && not (current.Count > 0 && isKeyword SpecAnd (current.[current.Count - 1])) then openStatements <- openStatements + 1
            current.Add node
    segments.Add (List.ofSeq current)
    segments |> List.ofSeq |> List.filter (fun segment -> not segment.IsEmpty)

let hasTopComma (nodes : Node list) = commaBeforeKeyword nodes

let startsWithKeyword (nodes : Node list) =
    match nodes with
    | Leaf lexeme :: _ -> not lexeme.InsideMacro && (match lexeme.Token with TokKeyword _ -> true | _ -> false)
    | _ -> false

let rec unwrapBody (nodes : Node list) =
    match nodes with
    | [ Group (opening, inner, _) ] when opening.Token = TokParenthesis (Round, Open) && not inner.IsEmpty ->
        let plain (gap : Gap) = match gap with Whitespace _ -> true | Embedded _ -> false
        let carried =
            match inner with
            | Leaf first :: tail when not (plain opening.Before) && plain first.Before -> Leaf { first with Before = opening.Before } :: tail
            | Group (innerOpening, innerNodes, innerClosing) :: tail when not (plain opening.Before) && plain innerOpening.Before ->
                Group ({ innerOpening with Before = opening.Before }, innerNodes, innerClosing) :: tail
            | _ -> inner
        unwrapBody carried
    | _ -> nodes

let fits (indent : int) (text : string) = indent + displayWidth text <= 120

let indexOfTop (predicate : Node -> bool) (nodes : Node list) =
    let mutable quantified = false
    let mutable found = None
    nodes
    |> List.iteri (fun index node ->
        if found.IsNone then
            if isKeyword SpecForall node || isKeyword SpecExists node then quantified <- true
            if quantified && isOperator "." node then quantified <- false
            elif not quantified && predicate node then found <- Some index)
    found


let rec withoutLeadingGap (nodes : Node list) : Node list * string list =
    match nodes with
    | Leaf lexeme :: tail ->
        match lexeme.Before with
        | Embedded gap -> Leaf { lexeme with Before = Whitespace 1 } :: tail, commentsIn gap.Text
        | Whitespace _ -> nodes, []
    | Group (opening, inner, closing) :: tail ->
        match opening.Before with
        | Embedded gap -> Group ({ opening with Before = Whitespace 1 }, inner, closing) :: tail, commentsIn gap.Text
        | Whitespace _ -> nodes, []
    | [] -> [], []

let splitArms (nodes : Node list) : (string list * Node list) list =
    let arms = ResizeArray<string list * Node list> ()
    let current = ResizeArray<Node> ()
    let mutable carried : string list = []
    let mutable quantified = false
    let flush () =
        if current.Count > 0 then
            let stripped, leading = withoutLeadingGap (List.ofSeq current)
            arms.Add (carried @ leading, stripped)
            carried <- []
        current.Clear ()
    for node in nodes do
        if isKeyword SpecForall node || isKeyword SpecExists node then quantified <- true
        if quantified && isOperator "." node then
            quantified <- false
            current.Add node
        elif isOperator "|" node then
            flush ()
            match node with
            | Leaf lexeme ->
                match lexeme.Before with
                | Embedded gap -> carried <- carried @ commentsIn gap.Text
                | Whitespace _ -> ()
            | Group _ -> ()
        else current.Add node
    flush ()
    List.ofSeq arms
type LiteralSplitting() =
    member val Enabled = false with get, set

let literalSplitting = LiteralSplitting ()

let literalChain (indent : int) (node : Node) : LaidLine list option =
    match node with
    | Group (opening, inner, closing) when literalSplitting.Enabled && opening.Token = TokStringOpen && not (fits indent (inlineText [ node ])) ->
        let units =
            inner
            |> List.collect (fun child ->
                match child with
                | Leaf lexeme ->
                    match lexeme.Token with
                    | TokText text -> lexeme.Text.Text |> Seq.map string |> List.ofSeq
                    | _ -> [ lexeme.Text.Text ]
                | _ -> [ inlineText [ child ] ])
        let room = 120 - indent - 3 - 3
        let pieces = ResizeArray<string> ()
        let current = StringBuilder ()
        let mutable lastSpace = -1
        let mutable width = 0
        for unit in units do
            current.Append unit |> ignore
            width <- width + displayWidth unit
            if unit = " " then lastSpace <- current.Length
            if width >= room then
                let cut = if lastSpace > room / 2 then lastSpace else current.Length
                let text = current.ToString ()
                pieces.Add (text.Substring (0, cut))
                current.Clear().Append (text.Substring cut) |> ignore
                width <- displayWidth (current.ToString ())
                lastSpace <- -1
        if current.Length > 0 then pieces.Add (current.ToString ())
        Some (pieces |> List.ofSeq |> List.mapi (fun index piece -> { Indent = indent; Text = (if index = 0 then "" else "^^ ") + "\"" + piece + "\"" }))
    | _ -> None

let gluedWords (nodes : Node list) : Node list list =
    nodes
    |> List.fold (fun (words : Node list list) node ->
        match words, (firstLexeme node).Before with
        | word :: earlier, Whitespace 0 -> (word @ [ node ]) :: earlier
        | _ -> [ node ] :: words) []
    |> List.rev

let rec layoutBlock (indent : int) (nodes : Node list) : LaidLine list =
    let parts = statements nodes
    if parts.Length > 1 then parts |> List.collect (layoutRecursiveGroup indent)
    else layoutRecursiveGroup indent nodes

and layoutRecursiveGroup (indent : int) (nodes : Node list) : LaidLine list =
    let andAt =
        nodes
        |> List.indexed
        |> List.filter (fun (index, node) -> index > 0 && isKeyword SpecAnd node && (match List.tryItem (index + 1) nodes with Some next -> isKeyword SpecInl next || isKeyword SpecLet next | None -> false))
        |> List.map fst
    if andAt.IsEmpty || not (isStatement nodes) then layoutStatement indent nodes
    else
        let bounds = (0 :: andAt) @ [ nodes.Length ]
        List.pairwise bounds
        |> List.collect (fun (a, b) ->
            let part = nodes.[a .. b - 1]
            if a = 0 then layoutStatement indent part
            else
                match layoutStatement indent (List.tail part) with
                | first :: rest -> { first with Text = "and " + first.Text } :: rest
                | [] -> [])

and attachRemark (indent : int) (remark : string) (lines : LaidLine list) : LaidLine list =
    match List.rev lines with
    | last :: before when fits last.Indent (last.Text + " " + remark) -> List.rev ({ last with Text = last.Text + " " + remark } :: before)
    | _ :: _ -> { Indent = indent; Text = remark } :: lines
    | [] -> [ { Indent = indent; Text = remark } ]

and layoutStatement (indent : int) (wrapped : Node list) : LaidLine list =
    let closingRemark =
        match wrapped with
        | [ Group (opening, inner, closing) ] when opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && not inner.IsEmpty ->
            match closing.Before with
            | Embedded gap when (commentsIn gap.Text |> List.filter (fun comment -> comment <> "")).Length = 1 && (commentsIn gap.Text |> List.filter (fun comment -> comment <> "") |> List.head).StartsWith "//" ->
                Some (commentsIn gap.Text |> List.filter (fun comment -> comment <> "") |> List.head, Group (opening, inner, { closing with Before = Whitespace 0 }))
            | _ -> None
        | _ -> None
    match closingRemark with
    | Some (remark, bare) ->
        attachRemark indent remark (layoutStatement indent [ bare ])
    | None ->
    let stripped, comments = withoutLeadingGap (unwrapBody wrapped)
    if not comments.IsEmpty then
        (comments |> List.map (fun comment -> if comment = "" then { Indent = 0; Text = "" } else { Indent = indent; Text = comment })) @ layoutStatement indent stripped
    else
    match List.tryLast stripped with
    | Some (Leaf last as node) when (isKeyword SpecIn node || isOperator "." node) && trailingRemark node ->
        let remark = match last.Before with Embedded gap -> commentsIn gap.Text |> List.filter (fun comment -> comment <> "") |> String.concat " " | Whitespace _ -> ""
        attachRemark indent remark (layoutStatement indent (List.take (stripped.Length - 1) stripped))
    | _ ->
    let nodes = stripped
    match nodes with
    | first :: second :: _ when isKeyword SpecAnd first && (isKeyword SpecInl second || isKeyword SpecLet second) ->
        match layoutStatement indent (List.tail nodes) with
        | head :: rest -> { head with Text = inlineText [ first ] + " " + head.Text } :: rest
        | [] -> []
    | _ ->
    if (statements nodes).Length > 1 then layoutBlock indent nodes else
    let whole = inlineComplete nodes
    let unionAt = nodes |> List.tryFindIndex (fun node -> isKeyword SpecUnion node)
    match nodes with
    | first :: _ when (isKeyword SpecUnion first || (isKeyword SpecAnd first && unionAt = Some 1)) && (indexOfTop (isOperator "=") nodes).IsSome ->
        let at = (indexOfTop (isOperator "=") nodes).Value
        let cases = splitOn (isOperator "|") (List.skip (at + 1) nodes) |> List.filter (fun case -> not case.IsEmpty)
        let headText = inlineText (List.take (at + 1) nodes)
        let headLines = if fits indent headText then [ { Indent = indent; Text = headText } ] else packNodes indent "" "" (List.take (at + 1) nodes)
        headLines @ (cases |> List.collect (layoutUnionCase (indent + 4)))
    | first :: _ when (isKeyword SpecType first || isKeyword SpecNominal first) && (indexOfTop (isOperator "=") nodes).IsSome
                      && (match List.skip ((indexOfTop (isOperator "=") nodes).Value + 1) nodes with
                          | [ Leaf quote; Group (opening, inner, _) ] -> quote.Token = TokUnaryOperator ("`", SemanticTokenLegend.unary_operator) && opening.Token = TokParenthesis (Round, Open) && ((statements inner).Length > 1 || not (fits indent whole))
                          | _ -> false) ->
        let at = (indexOfTop (isOperator "=") nodes).Value
        match List.skip (at + 1) nodes with
        | [ Leaf quote; Group (opening, inner, closing) ] ->
            { Indent = indent; Text = inlineText (List.take (at + 1) nodes) }
            :: { Indent = indent + 4; Text = quote.Text.Text + opening.Text.Text }
            :: layoutBlock (indent + 8) inner
            @ [ { Indent = indent + 4; Text = closing.Text.Text } ]
        | _ -> [ { Indent = indent; Text = whole } ]
    | first :: _ when (isKeyword SpecType first || isKeyword SpecNominal first) && (indexOfTop (isOperator "=") nodes).IsSome && (not (fits indent whole) || (isKeyword SpecType first && (match List.skip ((indexOfTop (isOperator "=") nodes).Value + 1) nodes with [ record ] -> (match fieldRecord record with Some _ -> true | None -> false) | _ -> false))) ->
        let at = (indexOfTop (isOperator "=") nodes).Value
        match List.skip (at + 1) nodes with
        | [ Group (opening, inner, closing) ] when opening.Token = TokParenthesis (Curly, Open) ->
            { Indent = indent; Text = inlineText (List.take (at + 1) nodes) }
            :: { Indent = indent + 4; Text = opening.Text.Text }
            :: (splitOn (isOperator ";") inner |> List.filter (fun field -> not field.IsEmpty) |> List.map (fun field -> { Indent = indent + 8; Text = inlineText field }))
            @ [ { Indent = indent + 4; Text = closing.Text.Text } ]
        | prefix when (match List.tryLast prefix with Some (Group (opening, _, _)) -> opening.Token = TokParenthesis (Curly, Open) | _ -> false) ->
            match List.last prefix with
            | Group (opening, inner, closing) ->
                { Indent = indent; Text = inlineText (List.take (at + 1) nodes) }
                :: { Indent = indent + 4; Text = inlineText (List.take (prefix.Length - 1) prefix) + " " + opening.Text.Text }
                :: (splitOn (isOperator ";") inner |> List.filter (fun field -> not field.IsEmpty) |> List.map (fun field -> { Indent = indent + 8; Text = inlineText field }))
                @ [ { Indent = indent + 4; Text = closing.Text.Text } ]
            | _ -> [ { Indent = indent; Text = whole } ]
        | body when not (fits indent whole) ->
            let head = List.take (at + 1) nodes
            let headLines = if fits indent (inlineText head) then [ { Indent = indent; Text = inlineText head } ] else packNodes indent "" "" head
            headLines @ layoutType (indent + 4) "" body
        | _ -> [ { Indent = indent; Text = whole } ]
    | Leaf head :: _ when indent = 0 && head.Token = TokVar ("test", SemanticTokenLegend.variable) && (List.tryFindIndex (isOperator "=") nodes).IsSome ->
        let at = (List.tryFindIndex (isOperator "=") nodes).Value
        { Indent = indent; Text = inlineText (List.take (at + 1) nodes) } :: layoutBlock (indent + 4) (unwrapBody (List.skip (at + 1) nodes))
    | first :: _ when isKeyword SpecInl first || isKeyword SpecLet first || (isKeyword SpecInstance first && indent = 0) ->
        match indexOfTop (isOperator "=") nodes with
        | Some at ->
            let head = List.take (at + 1) nodes
            let body = unwrapBody (List.skip (at + 1) nodes)
            let headText = inlineText head
            let bodyParts = statements body
            let functionBody = match body with first :: (next :: _) when isKeyword SpecFunction first && isOperator "|" next -> true | _ -> false
            if functionBody then
                let arms = splitArms (List.tail body)
                { Indent = indent; Text = headText + " function" } :: layoutArms (indent + 4) arms
            elif bodyParts.Length = 1 && fits indent (headText + " " + inlineComplete body) && (indent > 0 || isKeyword SpecInstance first) && not (opensLayout body) then [ { Indent = indent; Text = headText + " " + inlineComplete body } ]
            elif indent > 0 && not (List.exists isPipe body) && fits indent headText && bodyParts.Length = 1 && (lastArgumentLambda indent headText body).IsSome && (trailingLambdaNeedsBlock body || not (fits indent whole)) then
                (lastArgumentLambda indent headText body).Value
            elif fits indent headText then { Indent = indent; Text = headText } :: layoutBlock (indent + 4) body
            else layoutHead indent (List.take at nodes) @ [ { Indent = indent + 4; Text = "=" } ] @ layoutBlock (indent + 4) body
        | None -> [ { Indent = indent; Text = whole } ]
    | _ -> layoutExpression indent nodes

and packNodes (indent : int) (prefix : string) (suffix : string) (nodes : Node list) : LaidLine list =
    let lines = ResizeArray<LaidLine> ()
    let current = ResizeArray<Node> ()
    let mutable lineIndent = indent
    let mutable linePrefix = prefix
    for word in gluedWords nodes do
        let candidate = linePrefix + inlineText (List.ofSeq current @ word)
        if current.Count > 0 && not (fits lineIndent (candidate + suffix)) then
            lines.Add { Indent = lineIndent; Text = linePrefix + inlineText (List.ofSeq current) }
            current.Clear ()
            lineIndent <- indent + 4
            linePrefix <- ""
        current.AddRange word
    if current.Count > 0 then lines.Add { Indent = lineIndent; Text = linePrefix + inlineText (List.ofSeq current) + suffix }
    List.ofSeq lines

and layoutUnionCase (indent : int) (case : Node list) : LaidLine list =
    let whole = "| " + inlineText case
    if fits indent whole then [ { Indent = indent; Text = whole } ]
    else
        let afterForall =
            match case |> List.tryFindIndex (fun node -> isKeyword SpecForall node) with
            | Some forallAt ->
                match case |> List.skip forallAt |> List.tryFindIndex (isOperator ".") with
                | Some dot -> forallAt + dot + 1
                | None -> 0
            | None -> 0
        let headEnd =
            if afterForall > 0 then afterForall
            else
                match indexOfTop (isOperator "::") case with
                | Some at -> at + 1
                | None -> match indexOfTop (isOperator ":") case with Some at -> at + 1 | None -> 0
        if headEnd = 0 then packNodes indent "| " "" case
        else
            let headLines = packNodes indent "| " "" (List.take headEnd case)
            let body = List.skip headEnd case
            let segments = splitOn (isOperator "->") body |> List.filter (fun segment -> not segment.IsEmpty)
            let segmentLines =
                segments
                |> List.mapi (fun index segment ->
                    let arrow = if index < segments.Length - 1 then " ->" else ""
                    if fits (indent + 4) (inlineText segment + arrow) then [ { Indent = indent + 4; Text = inlineText segment + arrow } ]
                    else
                    match segment with
                    | [ Group (opening, inner, closing) ] when opening.Token = TokParenthesis (Curly, Open) && not opening.InsideMacro && not inner.IsEmpty ->
                        { Indent = indent + 4; Text = opening.Text.Text }
                        :: (splitOn (isOperator ";") inner |> List.filter (fun field -> not field.IsEmpty) |> List.map (fun field -> { Indent = indent + 8; Text = inlineText field }))
                        @ [ { Indent = indent + 4; Text = closing.Text.Text + arrow } ]
                    | _ -> layoutType (indent + 4) arrow segment)
                |> List.concat
            headLines @ segmentLines

and quantifierPrefix (nodes : Node list) =
    match nodes with
    | first :: _ when isKeyword SpecExists first || isKeyword SpecForall first ->
        nodes |> List.tryFindIndex (isOperator ".") |> Option.filter (fun dot -> dot + 1 < nodes.Length) |> Option.map (fun dot -> List.take (dot + 1) nodes, List.skip (dot + 1) nodes)
    | _ -> None

and layoutTypeSeparated (at : int) (suffix : string) (separator : string) (parts : Node list list) : LaidLine list =
    parts
    |> List.mapi (fun position part -> layoutType at (if position < parts.Length - 1 then " " + separator else suffix) part)
    |> List.concat

and layoutType (at : int) (suffix : string) (nodes : Node list) : LaidLine list =
    let whole = inlineText nodes
    let topLevel (separator : string) = splitOn (isOperator separator) nodes |> List.filter (fun part -> not part.IsEmpty)
    if fits at (whole + suffix) then [ { Indent = at; Text = whole + suffix } ]
    else
    match quantifierPrefix nodes with
    | Some (prefix, body) ->
        let prefixLines = if fits at (inlineText prefix) then [ { Indent = at; Text = inlineText prefix } ] else packNodes at "" "" prefix
        prefixLines @ layoutType (at + 4) suffix body
    | None ->
    if (topLevel "->").Length > 1 then layoutTypeSeparated at suffix "->" (topLevel "->")
    elif (topLevel "*").Length > 1 then layoutTypeSeparated at suffix "*" (topLevel "*")
    else
    match nodes with
    | [ Group (opening, inner, closing) ] when opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && not inner.IsEmpty ->
        match quantifierPrefix inner with
        | Some (prefix, body) when fits at (opening.Text.Text + inlineText prefix) ->
            { Indent = at; Text = opening.Text.Text + inlineText prefix } :: layoutType (at + 4) (closing.Text.Text + suffix) body
        | _ -> { Indent = at; Text = opening.Text.Text } :: layoutType (at + 4) "" inner @ [ { Indent = at; Text = closing.Text.Text + suffix } ]
    | [ Group (opening, inner, closing) ] when opening.Token = TokParenthesis (Curly, Open) && not opening.InsideMacro && not inner.IsEmpty ->
        let fields = splitOn (isOperator ";") inner |> List.filter (fun field -> not field.IsEmpty)
        let fieldLines (field : Node list) =
            match indexOfTop (isOperator ":") field with
            | Some colon when colon > 0 && not (fits (at + 4) (inlineText field)) ->
                { Indent = at + 4; Text = inlineText (List.take (colon + 1) field) } :: layoutType (at + 8) "" (List.skip (colon + 1) field)
            | _ -> [ { Indent = at + 4; Text = inlineText field } ]
        { Indent = at; Text = opening.Text.Text } :: (fields |> List.collect fieldLines) @ [ { Indent = at; Text = closing.Text.Text + suffix } ]
    | _ ->
        let plainWord (word : Node list) = word |> List.forall (fun node -> match node with Leaf lexeme -> not lexeme.InsideMacro | Group _ -> false)
        match gluedWords nodes with
        | callee :: arguments when not arguments.IsEmpty && fits at (inlineText callee) && List.forall plainWord arguments ->
            let lines = ResizeArray<LaidLine> [ { Indent = at; Text = inlineText callee } ]
            let current = ResizeArray<Node> ()
            for word in arguments do
                if current.Count > 0 && not (fits (at + 4) (inlineText (List.ofSeq current @ word) + suffix)) then
                    lines.Add { Indent = at + 4; Text = inlineText (List.ofSeq current) }
                    current.Clear ()
                current.AddRange word
            lines.Add { Indent = at + 4; Text = inlineText (List.ofSeq current) + suffix }
            List.ofSeq lines
        | callee :: arguments when not arguments.IsEmpty && fits at (inlineText callee) ->
            let lines = ResizeArray<LaidLine> [ { Indent = at; Text = inlineText callee } ]
            let run = ResizeArray<Node> ()
            let flush (last : bool) =
                if run.Count > 0 then
                    lines.Add { Indent = at + 4; Text = inlineText (List.ofSeq run) + (if last then suffix else "") }
                    run.Clear ()
            arguments
            |> List.iteri (fun position argument ->
                let last = position = arguments.Length - 1
                if plainWord argument then
                    if run.Count > 0 && not (fits (at + 4) (inlineText (List.ofSeq run @ argument) + suffix)) then flush false
                    run.AddRange argument
                    if last then flush true
                else
                    flush false
                    lines.AddRange (layoutType (at + 4) (if last then suffix else "") argument))
            List.ofSeq lines
        | _ -> [ { Indent = at; Text = whole + suffix } ]

and layoutHead (indent : int) (head : Node list) : LaidLine list =
    let afterForall =
        match head |> List.tryFindIndex (fun node -> isKeyword SpecForall node) with
        | Some forallAt ->
            match head |> List.skip forallAt |> List.tryFindIndex (isOperator ".") with
            | Some dot -> forallAt + dot + 1
            | None -> 0
        | None -> 0
    let nameEnd =
        if afterForall > 0 then afterForall
        else
            let leading = head |> List.takeWhile (fun node -> isKeyword SpecInl node || isKeyword SpecLet node || isKeyword SpecRec node)
            min head.Length (leading.Length + 1)
    let first = List.take nameEnd head
    let rest = List.skip nameEnd head
    let annotationAt = indexOfTop (isOperator ":") rest
    let parameters, annotation =
        match annotationAt with
        | Some at -> List.take at rest, List.skip at rest
        | None -> rest, []
    let packed = ResizeArray<LaidLine> ()
    let current = ResizeArray<Node> ()
    let wideParameter (parameter : Node) =
        match parameter with
        | Group (opening, inner, closing) when opening.Token = TokParenthesis (Round, Open) && not (fits (indent + 4) (inlineText [ parameter ])) ->
            match List.rev inner with
            | Group (tupleOpening, tupleInner, tupleClosing) :: before when tupleOpening.Token = TokParenthesis (Round, Open) && hasTopComma tupleInner ->
                let items = splitOn (isOperator ",") tupleInner |> List.filter (fun item -> not item.IsEmpty)
                let head = opening.Text.Text + (if before.IsEmpty then "" else inlineText (List.rev before) + " ") + tupleOpening.Text.Text
                Some (
                    { Indent = indent + 4; Text = head }
                    :: (items |> List.mapi (fun index item -> { Indent = indent + 8; Text = inlineText item + (if index < items.Length - 1 then "," else "") }))
                    @ [ { Indent = indent + 4; Text = tupleClosing.Text.Text + closing.Text.Text } ])
            | _ ->
                match indexOfTop (isOperator ":") inner with
                | Some colon when colon > 0 && colon < inner.Length - 1 && fits (indent + 4) (opening.Text.Text + inlineText (List.take (colon + 1) inner)) ->
                    Some ({ Indent = indent + 4; Text = opening.Text.Text + inlineText (List.take (colon + 1) inner) } :: layoutType (indent + 8) closing.Text.Text (List.skip (colon + 1) inner))
                | _ -> None
        | _ -> None
    for parameter in parameters do
        let candidate = inlineText (List.ofSeq current @ [ parameter ])
        match wideParameter parameter with
        | Some lines ->
            if current.Count > 0 then packed.Add { Indent = indent + 4; Text = inlineText (List.ofSeq current) }
            current.Clear ()
            packed.AddRange lines
        | None ->
            if current.Count > 0 && not (fits (indent + 4) candidate) then
                packed.Add { Indent = indent + 4; Text = inlineText (List.ofSeq current) }
                current.Clear ()
            current.Add parameter
    if current.Count > 0 then packed.Add { Indent = indent + 4; Text = inlineText (List.ofSeq current) }
    let annotationLines =
        if annotation.IsEmpty then []
        elif fits (indent + 4) (inlineText annotation) then [ { Indent = indent + 4; Text = inlineText annotation } ]
        else
            let rec typeLines (at : int) (nodes : Node list) : LaidLine list =
                let packedNodes = packNodes at "" "" nodes
                match List.rev nodes with
                | Group (opening, inner, closing) :: before when packedNodes |> List.exists (fun line -> not (fits line.Indent line.Text)) && opening.Token = TokParenthesis (Round, Open) && not inner.IsEmpty && fits at ((if before.IsEmpty then "" else inlineText (List.rev before) + " ") + opening.Text.Text) ->
                    { Indent = at; Text = (if before.IsEmpty then "" else inlineText (List.rev before) + " ") + opening.Text.Text }
                    :: typeLines (at + 4) inner
                    @ [ { Indent = at; Text = closing.Text.Text } ]
                | _ -> packedNodes
            let packedAnnotation = typeLines (indent + 4) annotation
            let typeNodes = List.tail annotation
            let arrowsOrPairs = (splitOn (isOperator "->") typeNodes |> List.filter (fun part -> not part.IsEmpty)).Length > 1 || (splitOn (isOperator "*") typeNodes |> List.filter (fun part -> not part.IsEmpty)).Length > 1
            let packedFits = packedAnnotation |> List.forall (fun line -> fits line.Indent line.Text)
            if packedFits && (packedAnnotation.Length = 1 || not arrowsOrPairs) then packedAnnotation
            else
                let colon = inlineText [ List.head annotation ] + " "
                match layoutType (indent + 4 + colon.Length) "" typeNodes with
                | first :: rest -> { Indent = indent + 4; Text = colon + first.Text } :: (rest |> List.map (fun line -> { line with Indent = max (indent + 4) (line.Indent - colon.Length) }))
                | [] -> packedAnnotation
    let firstLines = if fits indent (inlineText first) then [ { Indent = indent; Text = inlineText first } ] else packNodes indent "" "" first
    firstLines @ List.ofSeq packed @ annotationLines

and longPipeline (nodes : Node list) =
    let firstKeyword = nodes |> List.tryFindIndex (fun node -> match node with Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokKeyword _ -> true | _ -> false) | Group _ -> false)
    let limit = defaultArg firstKeyword nodes.Length
    (nodes |> List.indexed |> List.filter (fun (index, node) -> index < limit && isPipe node) |> List.length) >= 3

and carriesComment (nodes : Node list) =
    let commented (gap : Gap) = match gap with Embedded text -> commentsIn text.Text |> List.exists (fun comment -> comment <> "") | Whitespace _ -> false
    nodes |> List.exists (fun node -> match node with Leaf lexeme -> commented lexeme.Before | Group (opening, inner, closing) -> commented opening.Before || commented closing.Before || carriesComment inner)

and fieldRecord (node : Node) =
    match node with
    | Group (opening, inner, _) when opening.Token = TokParenthesis (Curly, Open) && not opening.InsideMacro ->
        let fields = splitOn (isOperator ";") inner |> List.filter (fun field -> not field.IsEmpty)
        if fields.Length >= 2 then Some fields else None
    | _ -> None

and functionRecord (node : Node) =
    match node with
    | Group (opening, inner, _) when opening.Token = TokParenthesis (Curly, Open) && not opening.InsideMacro ->
        splitOn (isOperator ";") inner |> List.exists (fun field -> (indexOfTop (isOperator "=") field).IsSome && field |> List.exists (fun part -> isKeyword SpecFun part || (match unwrapLambda [ part ] with first :: _ -> isKeyword SpecFun first | [] -> false)))
    | _ -> false

and splitListLambda (nodes : Node list) : (Node list * Node * Node list) option =
    let isList (node : Node) = match node with Group (opening, inner, _) -> opening.Token = TokParenthesis (Square, Open) && not opening.InsideMacro && not inner.IsEmpty | Leaf _ -> false
    let withArrow (lambda : Node list) = match lambda with first :: _ when isKeyword SpecFun first && (indexOfTop (isOperator "=>") lambda).IsSome -> Some lambda | _ -> None
    match List.rev nodes with
    | (Group _ as lambdaGroup) :: list :: before when not before.IsEmpty && isList list ->
        withArrow (unwrapLambda [ lambdaGroup ]) |> Option.map (fun lambda -> List.rev before, list, lambda)
    | _ ->
        match nodes |> List.tryFindIndex (fun node -> isKeyword SpecFun node) with
        | Some at when at >= 2 && isList nodes.[at - 1] ->
            withArrow (List.skip at nodes) |> Option.map (fun lambda -> List.take (at - 1) nodes, nodes.[at - 1], lambda)
        | _ -> None

and listThenLambda (nodes : Node list) = (splitListLambda nodes).IsSome

and opensLayout (nodes : Node list) =
    match nodes with
    | _ when listThenLambda nodes -> true
    | _ when nodes |> List.exists functionRecord -> true
    | _ when nodes.Length > 1 && trailingLambdaNeedsBlock nodes -> true
    | _ when longPipeline nodes -> true
    | _ when carriesComment nodes -> true
    | _ when (match List.tryFindIndex (fun node -> isKeyword SpecFunction node) nodes with Some at -> (match List.tryItem (at + 1) nodes with Some next -> isOperator "|" next | None -> false) | None -> false) -> true
    | first :: _ when isKeyword SpecMatch first || isKeyword SpecIf first || isKeyword SpecTypecase first -> true
    | first :: _ when isKeyword SpecFun first ->
        match indexOfTop (isOperator "=>") nodes with
        | Some arrow ->
            let body = unwrapBody (List.skip (arrow + 1) nodes)
            (statements body).Length > 1 || isStatement body || opensLayout body
        | None -> false
    | _ -> false

and layoutArms (indent : int) (arms : (string list * Node list) list) =
    let rec walk (pending : string list) (rest : (string list * Node list) list) =
        match rest with
        | [] -> pending |> List.rev |> List.map (fun pattern -> { Indent = indent; Text = "| " + pattern })
        | (comments, armNodes) :: tail ->
            let commentLines = comments |> List.map (fun comment -> if comment = "" then { Indent = 0; Text = "" } else { Indent = indent; Text = comment })
            let flushed = if comments.IsEmpty then [] else pending |> List.rev |> List.map (fun pattern -> { Indent = indent; Text = "| " + pattern })
            let pending = if comments.IsEmpty then pending else []
            if (indexOfTop (isOperator "=>") armNodes).IsNone && not (carriesComment armNodes) then
                flushed @ commentLines @ walk (inlineText armNodes :: pending) tail
            else
                let laid = layoutArm indent armNodes
                let merged =
                    match pending, laid with
                    | [], _ -> laid
                    | _, first :: others when first.Text.StartsWith "| " && fits indent ("| " + String.concat " | " (List.rev pending) + " " + first.Text) ->
                        { first with Text = "| " + String.concat " | " (List.rev pending) + " " + first.Text } :: others
                    | _, _ -> (pending |> List.rev |> List.map (fun pattern -> { Indent = indent; Text = "| " + pattern })) @ laid
                flushed @ commentLines @ merged @ walk [] tail
    walk [] arms

and layoutArm (indent : int) (armNodes : Node list) : LaidLine list =
        match indexOfTop (isOperator "=>") armNodes with
        | Some at ->
            let pattern = List.take (at + 1) armNodes
            let body = unwrapBody (List.skip (at + 1) armNodes)
            let line = "| " + inlineComplete armNodes
            let whenAt = indexOfTop (isKeyword SpecWhen) pattern
            if (statements body).Length = 1 && fits indent line && not (opensLayout body) then [ { Indent = indent; Text = line } ]
            elif whenAt.IsSome && not (fits indent ("| " + inlineText pattern)) then
                let at = whenAt.Value
                let guard = pattern.[at + 1 .. pattern.Length - 2]
                let guardLines = breakLong (indent + 4) guard
                let bodyText = "=> " + inlineComplete body
                let tail =
                    if (statements body).Length = 1 && fits (indent + 4) bodyText && not (opensLayout body) then [ { Indent = indent + 4; Text = bodyText } ]
                    else { Indent = indent + 4; Text = "=>" } :: layoutBlock (indent + 8) body
                { Indent = indent; Text = "| " + inlineText (List.take (at + 1) pattern) } :: guardLines @ tail
            elif whenAt.IsNone && not (fits indent ("| " + inlineText pattern)) && List.take at pattern |> List.exists (isOperator ",") then
                let components = splitOn (isOperator ",") (List.take at pattern) |> List.filter (fun part -> not part.IsEmpty)
                let bodyText = "=> " + inlineComplete body
                let tail =
                    if (statements body).Length = 1 && fits (indent + 4) bodyText && not (opensLayout body) then [ { Indent = indent + 4; Text = bodyText } ]
                    else { Indent = indent + 4; Text = "=>" } :: layoutBlock (indent + 8) body
                let componentLines =
                    components
                    |> List.mapi (fun index part ->
                        let comma = if index < components.Length - 1 then "," else ""
                        let prefix = if index = 0 then "| " else ""
                        let partIndent = if index = 0 then indent else indent + 4
                        match List.rev part with
                        | Group (opening, inner, closing) :: before when not (fits partIndent (prefix + inlineText part + comma)) && opening.Token = TokParenthesis (Round, Open) && List.exists (isOperator ",") inner ->
                            let items = splitOn (isOperator ",") inner |> List.filter (fun item -> not item.IsEmpty)
                            { Indent = partIndent; Text = prefix + (if before.IsEmpty then "" else inlineText (List.rev before) + " ") + opening.Text.Text }
                            :: (items |> List.mapi (fun position item -> layoutPatternItem (indent + 8) (if position < items.Length - 1 then "," else "") item) |> List.concat)
                            @ [ { Indent = indent + 4; Text = closing.Text.Text + comma } ]
                        | _ when prefix = "" -> layoutPatternItem partIndent comma part
                        | _ -> [ { Indent = partIndent; Text = prefix + inlineText part + comma } ])
                    |> List.concat
                componentLines @ tail
            elif whenAt.IsNone && not (fits indent ("| " + inlineText pattern))
                 && (match List.rev (List.take at pattern) with
                     | Group (opening, inner, _) :: before -> not before.IsEmpty && opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && List.exists (isOperator ",") inner && not (carriesComment inner)
                     | _ -> false) then
                match List.rev (List.take at pattern) with
                | Group (opening, inner, closing) :: before ->
                    let items = splitOn (isOperator ",") inner |> List.filter (fun item -> not item.IsEmpty)
                    let bodyText = "=> " + inlineComplete body
                    let tail =
                        if (statements body).Length = 1 && fits (indent + 4) bodyText && not (opensLayout body) then [ { Indent = indent + 4; Text = bodyText } ]
                        else { Indent = indent + 4; Text = "=>" } :: layoutBlock (indent + 8) body
                    { Indent = indent; Text = "| " + inlineText (List.rev before) + " " + opening.Text.Text }
                    :: (items |> List.mapi (fun position item -> layoutPatternItem (indent + 8) (if position < items.Length - 1 then "," else "") item) |> List.concat)
                    @ [ { Indent = indent + 4; Text = closing.Text.Text } ]
                    @ tail
                | _ -> [ { Indent = indent; Text = line } ]
            else
                match body with
                | first :: _ when isKeyword SpecFun first ->
                    match layoutExpression indent body with
                    | lambdaHead :: lambdaBody when fits indent ("| " + inlineText pattern + " " + lambdaHead.Text) && lambdaHead.Text.EndsWith "=>" ->
                        { Indent = indent; Text = "| " + inlineText pattern + " " + lambdaHead.Text } :: lambdaBody
                    | _ -> { Indent = indent; Text = "| " + inlineText pattern } :: layoutExpression (indent + 4) body
                | _ -> { Indent = indent; Text = "| " + inlineText pattern } :: layoutBlock (indent + 4) body
        | None -> [ { Indent = indent; Text = "| " + inlineText armNodes } ]

and layoutPatternItem (at : int) (suffix : string) (item : Node list) : LaidLine list =
    if fits at (inlineText item + suffix) then [ { Indent = at; Text = inlineText item + suffix } ]
    else
        match List.rev item with
        | Group (opening, inner, closing) :: before when opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && List.exists (isOperator ",") inner && not (carriesComment inner) ->
            let items = splitOn (isOperator ",") inner |> List.filter (fun part -> not part.IsEmpty)
            { Indent = at; Text = (if before.IsEmpty then "" else inlineText (List.rev before) + " ") + opening.Text.Text }
            :: (items |> List.mapi (fun position part -> layoutPatternItem (at + 4) (if position < items.Length - 1 then "," else "") part) |> List.concat)
            @ [ { Indent = at; Text = closing.Text.Text + suffix } ]
        | Group (opening, inner, closing) :: before when opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && not inner.IsEmpty && not (carriesComment inner) && fits at ((if before.IsEmpty then "" else inlineText (List.rev before) + " ") + opening.Text.Text) ->
            { Indent = at; Text = (if before.IsEmpty then "" else inlineText (List.rev before) + " ") + opening.Text.Text }
            :: layoutPatternItem (at + 4) "" inner
            @ [ { Indent = at; Text = closing.Text.Text + suffix } ]
        | _ -> [ { Indent = at; Text = inlineText item + suffix } ]

and layoutExpression (indent : int) (nodes : Node list) : LaidLine list =
    let whole = inlineComplete nodes
    let hasTopKeyword = nodes |> List.exists (fun node -> match node with Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokKeyword _ -> true | TokOperator ("=>", _) -> true | _ -> false) | _ -> false)
    let annotationAt =
        if hasTopKeyword then None
        elif not (fits indent whole) then indexOfTop (isOperator ":") nodes
        else
            match indexOfTop (isOperator ":") nodes with
            | Some at when at > 0 && opensLayout (unwrapBody (List.take at nodes)) -> Some at
            | _ -> None
    let arrowAt =
        if fits indent whole then None
        else
            match nodes with
            | first :: _ when isOperator "|" first || isKeyword SpecMatch first || isKeyword SpecFunction first || isKeyword SpecTypecase first || isKeyword SpecIf first -> None
            | _ when nodes |> List.exists (fun node -> isPipe node || (match node with Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokKeyword keyword -> keyword <> SpecForall | _ -> false) | _ -> false)) -> None
            | _ -> indexOfTop (isOperator "=>") nodes
    match nodes with
    | [ single ] when (literalChain indent single).IsSome -> (literalChain indent single).Value
    | _ when annotationAt.IsSome && annotationAt.Value > 0 ->
        let at = annotationAt.Value
        let left = List.take at nodes
        let annotation = inlineText (List.skip at nodes)
        match layoutExpression indent left with
        | [ single ] when fits single.Indent (single.Text + " " + annotation) -> [ { single with Text = single.Text + " " + annotation } ]
        | laid -> laid @ [ { Indent = indent; Text = annotation } ]
    | _ when arrowAt.IsSome && fits indent (inlineText (List.take (arrowAt.Value + 1) nodes)) ->
        let at = arrowAt.Value
        { Indent = indent; Text = inlineText (List.take (at + 1) nodes) } :: layoutBlock (indent + 4) (unwrapBody (List.skip (at + 1) nodes))
    | [ (Leaf tick); (Group (opening, inner, closing)) ] when not tick.InsideMacro && (match tick.Token with TokUnaryOperator ("`", _) -> true | _ -> false) && opening.Token = TokParenthesis (Round, Open) && not (fits indent whole) && not inner.IsEmpty && not (carriesComment inner) ->
        { Indent = indent; Text = tick.Text.Text + opening.Text.Text } :: layoutType (indent + 4) "" inner @ [ { Indent = indent; Text = closing.Text.Text } ]
    | [ (Leaf unary); (Group (opening, inner, closing)) ] when (match unary.Token with TokUnaryOperator _ -> true | _ -> false) && opening.Token = TokParenthesis (Square, Open) && not (fits indent whole) && not inner.IsEmpty ->
        let items = splitOn (isOperator ";") inner |> List.filter (fun item -> not item.IsEmpty)
        { Indent = indent; Text = unary.Text.Text + opening.Text.Text } :: (items |> List.collect (layoutExpression (indent + 4))) @ [ { Indent = indent; Text = closing.Text.Text } ]
    | [ Group (opening, inner, closing) as record ] when opening.Token = TokParenthesis (Curly, Open) && functionRecord record ->
        let openText, fields = recordOpening opening inner
        { Indent = indent; Text = openText } :: layoutFields (indent + 4) fields @ [ { Indent = indent; Text = closing.Text.Text } ]
    | [ Group (opening, _, _) as record ] when (opening.Token = TokParenthesis (Curly, Open) || opening.Token = TokParenthesis (Square, Open)) && not (fits indent whole) -> layoutArgument indent record
    | [ first; (Group (opening, inner, _)) ] when (isKeyword SpecReal first || isKeyword SpecJoin first) && opening.Token = TokParenthesis (Round, Open) && (not (fits indent whole) || (statements (unwrapBody inner)).Length > 1 || isStatement (unwrapBody inner) || opensLayout (unwrapBody inner)) ->
        { Indent = indent; Text = inlineText [ first ] } :: layoutBlock (indent + 4) (unwrapBody inner)
    | first :: (_ :: _ :: _ as rest) when isKeyword SpecJoin first && not (fits indent whole) && not (carriesComment nodes) ->
        { Indent = indent; Text = inlineText [ first ] } :: layoutBlock (indent + 4) rest
    | first :: (second :: _ as rest) when isKeyword SpecReal first && not (fits indent whole) && (match second with Group (opening, _, _) -> opening.Token <> TokParenthesis (Round, Open) | Leaf _ -> true) ->
        { Indent = indent; Text = inlineText [ first ] } :: layoutBlock (indent + 4) rest
    | [ Group (opening, _, _) ] when opening.Token = TokParenthesis (Round, Open) && (not (fits indent whole) || opensLayout (unwrapLambda nodes)) && (match unwrapLambda nodes with first :: _ -> isKeyword SpecFun first || isKeyword SpecFunction first | [] -> false) ->
        layoutExpression indent (unwrapLambda nodes)
    | [ Group (opening, _, _) ] when opening.Token = TokParenthesis (Round, Open) && (not (fits indent whole) || opensLayout (unwrapBody nodes)) && (match unwrapBody nodes with first :: _ -> isKeyword SpecIf first || isKeyword SpecMatch first || isKeyword SpecTypecase first || isKeyword SpecReal first || (List.tryFindIndex (fun node -> isKeyword SpecFunction node) (unwrapBody nodes)).IsSome | [] -> false) ->
        layoutExpression indent (unwrapBody nodes)
    | [ Group (opening, inner, _) as group ] when opening.Token = TokParenthesis (Round, Open) && not inner.IsEmpty && not (fits indent whole) && (match unwrapLambda nodes with first :: _ -> not (isKeyword SpecFun first) | [] -> true) ->
        layoutArgument indent group
    | first :: _ when isKeyword SpecMatch first || isKeyword SpecTypecase first ->
        match indexOfTop (isKeyword SpecWith) nodes with
        | Some at ->
            let head = List.take (at + 1) nodes
            let arms = splitArms (List.skip (at + 1) nodes)
            let headLines =
                if fits indent (inlineText head) || at < 2 then [ { Indent = indent; Text = inlineText head } ]
                else
                    { Indent = indent; Text = inlineText [ List.head head ] }
                    :: layoutExpression (indent + 4) (head.[1 .. head.Length - 2])
                    @ [ { Indent = indent; Text = inlineText [ List.last head ] } ]
            headLines @ layoutArms indent arms
        | None -> [ { Indent = indent; Text = whole } ]
    | first :: _ when isKeyword SpecIf first ->
        let branches = ResizeArray<Node * Node list> ()
        let mutable keyword = first
        let current = ResizeArray<Node> ()
        let mutable depth = 0
        for node in List.tail nodes do
            if isKeyword SpecIf node then depth <- depth + 1
            if depth = 0 && (isKeyword SpecThen node || isKeyword SpecElif node || isKeyword SpecElse node) then
                branches.Add (keyword, List.ofSeq current)
                current.Clear ()
                keyword <- node
            else
                if isKeyword SpecElse node && depth > 0 then depth <- depth - 1
                current.Add node
        branches.Add (keyword, List.ofSeq current)
        branches
        |> List.ofSeq
        |> List.collect (fun (keywordNode, branch) ->
            let keywordComments =
                match keywordNode with
                | Leaf lexeme ->
                    match lexeme.Before with
                    | Embedded gap -> commentsIn gap.Text |> List.filter (fun comment -> comment <> "") |> List.map (fun comment -> { Indent = indent; Text = comment })
                    | Whitespace _ -> []
                | Group _ -> []
            let word = inlineText [ keywordNode ]
            let body = if isKeyword SpecIf keywordNode || isKeyword SpecElif keywordNode then branch else unwrapBody branch
            let line = word + " " + inlineComplete (if isKeyword SpecIf keywordNode || isKeyword SpecElif keywordNode then branch else body)
            let laid =
                if (statements body).Length = 1 && fits indent line && not (opensLayout body) then [ { Indent = indent; Text = line } ]
                else { Indent = indent; Text = word } :: layoutBlock (indent + 4) body
            keywordComments @ laid)
    | _ ->
        match List.tryFindIndexBack (isKeyword SpecFunction) nodes with
        | Some at when at = nodes.Length - 1 || (match List.tryItem (at + 1) nodes with Some next -> isOperator "|" next | None -> false) ->
            let head = List.take (at + 1) nodes
            let arms = splitArms (List.skip (at + 1) nodes)
            if arms.IsEmpty then [ { Indent = indent; Text = whole } ]
            else
                let headLines = if fits indent (inlineText head) then [ { Indent = indent; Text = inlineText head } ] else breakLong indent head
                headLines @ layoutArms (indent + 4) arms
        | _ when fits indent whole && trailingLambdaNeedsBlock nodes -> (if List.exists isPipe nodes then breakLong indent nodes else match lastArgumentLambda indent "" nodes with Some lines -> lines | None -> breakLong indent nodes)
        | _ ->
            let pipeBeforeLambda =
                match nodes |> List.tryFindIndex (fun node -> isKeyword SpecFun node) with
                | Some at -> nodes |> List.take at |> List.exists (fun node -> isPipe node || (match node with Leaf l -> not l.InsideMacro && (match l.Token with TokOperator (name, _) -> not (List.contains name [ ","; ":"; "="; "=>"; "|"; "."; ";"; "<-" ]) | _ -> false) | _ -> false))
                | None -> false
            match nodes |> List.tryFindIndexBack (fun node -> isKeyword SpecFun node) with
            | _ when pipeBeforeLambda && (not (fits indent whole) || opensLayout (List.skip (List.findIndex (fun node -> isKeyword SpecFun node) nodes) nodes)) -> breakLong indent nodes
            | Some at when (indexOfTop (isOperator "=>") (List.skip at nodes)).IsSome && (let arrow = (indexOfTop (isOperator "=>") (List.skip at nodes)).Value in let body = unwrapBody (List.skip (at + arrow + 1) nodes) in (statements body).Length > 1 || opensLayout body || not (fits indent whole)) ->
                let arrow = (indexOfTop (isOperator "=>") (List.skip at nodes)).Value
                let head = List.take (at + arrow + 1) nodes
                let body = unwrapBody (List.skip (at + arrow + 1) nodes)
                if listThenLambda nodes then breakLong indent nodes else
                match body with
                | [ Group (opening, inner, closing) as record ] when opening.Token = TokParenthesis (Curly, Open) && not opening.InsideMacro && (fieldRecord record).IsSome && fits indent (inlineText head + " " + fst (recordOpening opening inner)) ->
                    let openText, fields = recordOpening opening inner
                    { Indent = indent; Text = inlineText head + " " + openText } :: layoutFields (indent + 4) fields @ [ { Indent = indent; Text = closing.Text.Text } ]
                | _ ->
                if fits indent (inlineText head) || at = 0 then { Indent = indent; Text = inlineText head } :: layoutBlock (indent + 4) body
                else breakLong indent nodes
            | _ -> if fits indent whole && not (longPipeline nodes) && not (carriesComment nodes) && not (nodes |> List.exists functionRecord) && not (listThenLambda nodes) then [ { Indent = indent; Text = whole } ] else breakLong indent nodes

and isPipe (node : Node) = isOperator "|>" node || isOperator "||>" node || isOperator "|||>" node

and breakLong (indent : int) (nodes : Node list) : LaidLine list =
    let whole = inlineText nodes
    let firstKeyword = nodes |> List.tryFindIndex (fun node -> match node with Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokKeyword _ -> true | _ -> false) | Group _ -> false)
    let limit = defaultArg firstKeyword nodes.Length
    let pipes = nodes |> List.indexed |> List.filter (fun (index, node) -> index < limit && isPipe node) |> List.map fst
    let precedenceOf (node : Node) =
        match node with
        | Leaf lexeme when not lexeme.InsideMacro ->
            match lexeme.Token with
            | TokOperator (name, _) ->
                match name with
                | "," | ":" | "=>" | "|" | "." | ";" | "<-" -> None
                | "||" -> Some 20
                | "&&" -> Some 30
                | "=" | "=." | "<>." | "<" | "<=" | ">" | ">=" | "<>" -> Some 40
                | "::" -> Some 50
                | _ when name.StartsWith "+" || name.StartsWith "-" -> Some 60
                | _ when name.StartsWith "*" || name.StartsWith "/" || name.StartsWith "%" -> Some 70
                | _ -> Some 45
            | _ -> None
        | _ -> None
    let operators = nodes |> List.indexed |> List.filter (fun (index, node) -> index > 0 && index < limit && (precedenceOf node).IsSome)
    let commaItems =
        if not (hasTopComma nodes) then []
        elif firstKeyword.IsNone then splitOn (isOperator ",") nodes |> List.filter (fun item -> not item.IsEmpty)
        else
            let lastCommaBeforeKeyword = nodes |> List.take firstKeyword.Value |> List.findIndexBack (isOperator ",")
            (splitOn (isOperator ",") (List.take lastCommaBeforeKeyword nodes) |> List.filter (fun item -> not item.IsEmpty))
            @ [ List.skip (lastCommaBeforeKeyword + 1) nodes ]
    if commaItems.Length > 1 then
        commaItems
        |> List.mapi (fun index item ->
            let lines =
                match layoutExpression indent item with
                | [ single ] when index < commaItems.Length - 1 && not (fits single.Indent (single.Text + ",")) ->
                    layoutExpression (indent + 1) item |> List.map (fun line -> { line with Indent = max 0 (line.Indent - 1) })
                | laid -> laid
            let lines = if index < commaItems.Length - 1 then keepLambdaParentheses item lines else lines
            if index = commaItems.Length - 1 then lines
            else
                match List.rev lines with
                | last :: before -> List.rev ({ last with Text = last.Text + "," } :: before)
                | [] -> [])
        |> List.concat
    elif pipes.IsEmpty && not operators.IsEmpty then
        let lowest = operators |> List.map (fun (_, node) -> (precedenceOf node).Value) |> List.min
        let cuts = operators |> List.filter (fun (_, node) -> (precedenceOf node).Value = lowest) |> List.map fst
        let bounds = (0 :: cuts) @ [ nodes.Length ]
        let pureApplication (inner : Node list) =
            not inner.IsEmpty
            && inner |> List.forall (fun node ->
                match node with
                | Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokVar _ | TokSymbol _ | TokValue _ | TokValueSuffix | TokDefaultValue _ -> true | _ -> false)
                | Group (opening, _, _) -> opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro)
        let unwrapApplication (operand : Node list) =
            match operand with
            | [ Group (opening, inner, _) ] when opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && pureApplication inner && not (carriesComment operand) -> inner
            | [ op; Group (opening, inner, _) ] when (precedenceOf op).IsSome && opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && pureApplication inner && not (carriesComment operand) ->
                op :: (match inner with Leaf first :: tail -> Leaf { first with Before = Whitespace 1 } :: tail | other -> other)
            | _ -> operand
        List.pairwise bounds
        |> List.mapi (fun index (a, b) ->
            let withGap = unwrapApplication nodes.[a .. b - 1]
            if index = 0 then
                match withGap with
                | [ single ] when lowest >= 45 && (literalChain (indent + 4) single).IsSome ->
                    { Indent = indent; Text = "(" } :: (literalChain (indent + 4) single).Value @ [ { Indent = indent; Text = ")" } ]
                | _ -> layoutExpression indent withGap
            else
                let segment, comments = withoutLeadingGap withGap
                let commentLines = comments |> List.map (fun comment -> if comment = "" then { Indent = 0; Text = "" } else { Indent = indent; Text = comment })
                let op = inlineText [ List.head segment ]
                let operand = List.tail segment
                let text = op + " " + inlineComplete operand
                let lambdaOperand =
                    match operand with
                    | first :: _ when isKeyword SpecFun first -> Some operand
                    | [ Group _ ] when index = bounds.Length - 2 && (match unwrapLambda operand with first :: _ -> isKeyword SpecFun first | [] -> false) -> Some (unwrapLambda operand)
                    | _ -> None
                let laidOperand =
                    if fits indent text && not (carriesComment operand) then [ { Indent = indent; Text = text } ]
                    elif lambdaOperand.IsSome && not (carriesComment operand) then
                        match layoutExpression indent lambdaOperand.Value with
                        | first :: rest -> { Indent = indent; Text = op + " " + first.Text } :: rest
                        | [] -> [ { Indent = indent; Text = text } ]
                    elif (match operand with [ single ] -> (literalChain (indent + 4) single).IsSome | _ -> false) then
                        { Indent = indent; Text = op + " (" } :: (literalChain (indent + 4) (List.head operand)).Value @ [ { Indent = indent; Text = ")" } ]
                    elif (match operand with [ Group (opening, inner, _) ] -> opening.Token = TokParenthesis (Round, Open) && not inner.IsEmpty && not (hasTopComma inner) && not (fits indent text) | _ -> false) then
                        match operand with
                        | [ Group (_, inner, _) ] -> { Indent = indent; Text = op + " (" } :: layoutBlock (indent + 4) (unwrapBody inner) @ [ { Indent = indent; Text = ")" } ]
                        | _ -> [ { Indent = indent; Text = text } ]
                    else
                        match layoutExpression (indent + op.Length + 1) operand with
                        | first :: rest -> { Indent = indent; Text = op + " " + first.Text } :: rest
                        | [] -> [ { Indent = indent; Text = op } ]
                commentLines @ laidOperand)
        |> List.concat
    elif not pipes.IsEmpty then
        let bounds = (0 :: pipes) @ [ nodes.Length ]
        let segments = List.pairwise bounds |> List.map (fun (a, b) -> nodes.[a .. b - 1])
        segments
        |> List.mapi (fun index withGap ->
            if index = 0 then
                let endsWithLambda =
                    match List.tryLast withGap with
                    | Some (Group _ as last) -> (match unwrapLambda [ last ] with first :: _ -> isKeyword SpecFun first | [] -> false)
                    | _ -> false
                if not endsWithLambda then layoutExpression indent withGap
                elif fits indent (inlineText withGap) && not (carriesComment withGap) && not (listThenLambda withGap) && not (opensLayout (unwrapLambda [ List.last withGap ])) then [ { Indent = indent; Text = inlineText withGap } ]
                elif withGap.Length = 1 then layoutExpression indent withGap
                else breakLong indent withGap
            else
                let segment, comments = withoutLeadingGap withGap
                let commentLines = comments |> List.map (fun comment -> if comment = "" then { Indent = 0; Text = "" } else { Indent = indent; Text = comment })
                let op = inlineText [ List.head segment ]
                let stage = List.tail segment
                let stageText = op + " " + (if index < segments.Length - 1 then inlineText stage else inlineComplete stage)
                let laidStage =
                    if fits indent stageText && not (opensLayout stage) && not (trailingLambdaNeedsBlock stage) && not (stage |> List.exists (fun node -> isKeyword SpecFun node) && opensLayout (List.skip (List.findIndex (fun node -> isKeyword SpecFun node) stage) stage)) then [ { Indent = indent; Text = stageText } ]
                    else
                        match lastArgumentLambda indent op stage with
                        | Some lines -> lines
                        | None ->
                            let wrappedLambda = index = segments.Length - 1 && (match stage with [ Group _ ] -> (match unwrapLambda stage with first :: _ -> isKeyword SpecFun first | [] -> false) | _ -> false)
                            let bareLambda = wrappedLambda || stage |> List.exists (fun node -> isKeyword SpecFun node)
                            match layoutExpression (if bareLambda then indent else indent + op.Length + 1) (if wrappedLambda && index = segments.Length - 1 then unwrapLambda stage else stage) with
                            | first :: rest -> { Indent = indent; Text = op + " " + first.Text } :: rest
                            | [] -> [ { Indent = indent; Text = op } ]
                commentLines @ laidStage)
        |> List.concat
    else
        let isSimple (node : Node) =
            match node with
            | Leaf lexeme ->
                not lexeme.InsideMacro
                && (match lexeme.Token with
                    | TokVar _ | TokSymbol _ | TokValue _ | TokDefaultValue _ | TokValueSuffix | TokUnaryOperator _ | TokKeyword SpecExists -> true
                    | _ -> false)
            | Group (opening, [ Leaf section ], _) ->
                opening.Token = TokParenthesis (Round, Open) && (match section.Token with TokOperator _ | TokUnaryOperator _ -> true | _ -> false)
            | Group _ -> false
        let isUnary (node : Node) = match node with Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokUnaryOperator _ -> true | _ -> false) | _ -> false
        let rec countHead (index : int) =
            if index >= nodes.Length then index
            elif isUnary nodes.[index] && index + 2 < nodes.Length && (match nodes.[index + 2] with Group (opening, [ Group (innerOpening, _, _) ], _) when innerOpening.Token = TokParenthesis (Curly, Open) -> false | Group (opening, _, _) -> opening.Token = TokParenthesis (Round, Open) && (match nodes.[index] with Leaf l -> l.Text.Text.StartsWith "!!!!" | _ -> false) | _ -> false) then countHead (index + 3)
            elif isUnary nodes.[index] then countHead (index + 2)
            elif isSimple nodes.[index] then countHead (index + 1)
            else index
        let adjacent (node : Node) = match (firstLexeme node).Before with Whitespace 0 -> true | _ -> false
        let rec extendHead (count : int) = if count < nodes.Length && count > 0 && adjacent nodes.[count] && (match nodes.[count] with Group _ -> false | _ -> true) then extendHead (count + 1) else count
        let plainCallee = match nodes with Leaf callee :: _ -> not callee.InsideMacro && (match callee.Token with TokVar _ | TokSymbol _ -> true | _ -> false) | _ -> false
        let headCount =
            let counted = extendHead (min nodes.Length (countHead 0))
            if counted > 1 && plainCallee && extendHead 1 = 1 && not (fits indent (inlineText (List.take counted nodes))) then 1 else counted
        let rest = List.skip headCount nodes
        let rec bindUnary (items : Node list) : Node list list =
            match items with
            | unary :: operand :: tail when isUnary unary -> [ unary; operand ] :: bindUnary tail
            | node :: tail -> [ node ] :: bindUnary tail
            | [] -> []
        let arguments =
            bindUnary rest
            |> List.fold (fun (groups : Node list list) group ->
                match groups, group with
                | previous :: earlier, first :: _ when adjacent first -> (previous @ group) :: earlier
                | _ -> group :: groups) []
            |> List.rev
        let restIsArguments =
            headCount > 0 && not rest.IsEmpty && not (List.take headCount nodes |> List.forall isUnary)
            && rest |> List.forall (fun node -> match node with Group _ -> true | Leaf lexeme -> not lexeme.InsideMacro && (match lexeme.Token with TokVar _ | TokSymbol _ | TokValue _ | TokValueSuffix | TokDefaultValue _ | TokUnaryOperator _ -> true | _ -> false))
        let isCurly (node : Node) = match node with Group (opening, _, _) -> opening.Token = TokParenthesis (Curly, Open) | Leaf _ -> false
        let intrinsicHead = nodes.Length - 1
        let intrinsicTuple =
            match nodes with
            | Leaf bang :: _ when not bang.InsideMacro && (match bang.Token with TokUnaryOperator _ -> true | _ -> false) && (intrinsicHead = 1 || intrinsicHead = 2) ->
                match List.last nodes with
                | Group (opening, inner, _) -> opening.Token = TokParenthesis (Round, Open) && hasTopComma inner && not (fits indent whole) && (List.take intrinsicHead nodes |> List.forall (fun node -> match node with Leaf _ -> true | Group _ -> false))
                | Leaf _ -> false
            | _ -> false
        let bracketThenLambda =
            match splitListLambda nodes with
            | Some (before, Group (opening, inner, closing), lambda) ->
                    let arrow = (indexOfTop (isOperator "=>") lambda).Value
                    let headText = inlineText before
                    let lambdaHead = inlineText (List.take (arrow + 1) lambda)
                    let simpleHead = before |> List.forall (fun node -> match node with Leaf l -> not l.InsideMacro && (match l.Token with TokVar _ | TokSymbol _ | TokValue _ | TokUnaryOperator _ -> true | _ -> false) | Group _ -> true)
                    if simpleHead && fits indent (headText + " " + opening.Text.Text) then
                        let items = splitOn (isOperator ";") inner |> List.filter (fun item -> not item.IsEmpty)
                        Some (
                            { Indent = indent; Text = headText + " " + opening.Text.Text }
                            :: (items |> List.collect (layoutExpression (indent + 4)))
                            @ [ { Indent = indent; Text = closing.Text.Text + " " + lambdaHead } ]
                            @ layoutBlock (indent + 4) (unwrapBody (List.skip (arrow + 1) lambda)))
                    else None
            | _ -> None
        let rec soleLiteral (inner : Node list) =
            match inner with
            | [ literal ] when isStringGroup literal -> Some literal
            | [ Group (opening, nested, _) ] when opening.Token = TokParenthesis (Round, Open) -> soleLiteral nested
            | _ -> None
        let intrinsicLiteral =
            match nodes with
            | [ Leaf bang; Leaf name; Group (opening, inner, closing) ]
                when not bang.InsideMacro && bang.Text.Text.StartsWith "!!!!" && opening.Token = TokParenthesis (Round, Open) && (soleLiteral inner).IsSome && not (fits indent whole) ->
                let literal = (soleLiteral inner).Value
                literalChain (indent + 4) literal
                |> Option.map (fun pieces ->
                    let gap = match opening.Before with Whitespace 0 -> "" | _ -> " "
                    { Indent = indent; Text = inlineText [ Leaf bang; Leaf name ] + gap + opening.Text.Text }
                    :: pieces
                    @ [ { Indent = indent; Text = closing.Text.Text } ])
            | _ -> None
        match (if intrinsicTuple then None elif intrinsicLiteral.IsSome then intrinsicLiteral elif bracketThenLambda.IsSome then bracketThenLambda else lastArgumentLambda indent "" nodes) with
        | Some lines -> lines
        | None when (match List.rev nodes with
                     | Group (opening, inner, _) :: Leaf unary :: before ->
                         not before.IsEmpty && not unary.InsideMacro && (match unary.Token with TokUnaryOperator _ -> true | _ -> false)
                         && opening.Token = TokParenthesis (Square, Open) && not inner.IsEmpty && not (fits indent whole)
                         && (match opening.Before with Whitespace 0 -> true | _ -> false)
                         && fits indent (inlineText (List.rev before) + " " + unary.Text.Text + opening.Text.Text)
                     | _ -> false) ->
            match List.rev nodes with
            | Group (opening, inner, closing) :: Leaf unary :: before ->
                let items = splitOn (isOperator ";") inner |> List.filter (fun item -> not item.IsEmpty)
                { Indent = indent; Text = inlineText (List.rev before) + " " + unary.Text.Text + opening.Text.Text }
                :: (items |> List.collect (layoutExpression (indent + 4)))
                @ [ { Indent = indent; Text = closing.Text.Text } ]
            | _ -> [ { Indent = indent; Text = whole } ]
        | None when (match List.rev nodes with
                     | (Group (opening, _, _) as record) :: before ->
                         not before.IsEmpty && opening.Token = TokParenthesis (Curly, Open) && not opening.InsideMacro
                         && (functionRecord record || not (fits indent whole))
                         && fits indent (inlineText (List.rev before) + " " + opening.Text.Text)
                         && not (List.rev before |> List.exists (fun node -> isPipe node || (match node with Leaf l -> not l.InsideMacro && (match l.Token with TokKeyword _ | TokOperator _ -> true | _ -> false) | Group _ -> false)))
                     | _ -> false) ->
            match List.rev nodes with
            | Group (opening, inner, closing) :: before ->
                let openText, fields = recordOpening opening inner
                { Indent = indent; Text = inlineText (List.rev before) + " " + openText }
                :: layoutFields (indent + 4) fields
                @ [ { Indent = indent; Text = closing.Text.Text } ]
            | _ -> [ { Indent = indent; Text = whole } ]
        | None when (match List.rev nodes with
                     | Group (opening, inner, _) :: before ->
                         not before.IsEmpty && opening.Token = TokParenthesis (Square, Open) && not opening.InsideMacro && not inner.IsEmpty
                         && not (fits indent whole)
                         && (match opening.Before with Whitespace 0 -> false | _ -> true)
                         && fits indent (inlineText (List.rev before) + " " + opening.Text.Text)
                         && List.rev before |> List.forall (fun node -> match node with Leaf l -> not l.InsideMacro && (match l.Token with TokVar _ | TokSymbol _ | TokValue _ -> true | _ -> false) | Group _ -> true)
                     | _ -> false) ->
            match List.rev nodes with
            | Group (opening, inner, closing) :: before ->
                let items = splitOn (isOperator ";") inner |> List.filter (fun item -> not item.IsEmpty)
                { Indent = indent; Text = inlineText (List.rev before) + " " + opening.Text.Text }
                :: (items |> List.collect (layoutExpression (indent + 4)))
                @ [ { Indent = indent; Text = closing.Text.Text } ]
            | _ -> [ { Indent = indent; Text = whole } ]
        | None when intrinsicTuple ->
            match layoutTuple indent (List.last nodes) with
            | opening :: inner -> { Indent = indent; Text = inlineText (List.take intrinsicHead nodes) + (match (firstLexeme (List.last nodes)).Before with Whitespace 0 -> "" | _ -> " ") + opening.Text } :: inner
            | [] -> [ { Indent = indent; Text = whole } ]
        | None ->
        let intrinsicRecord =
            match rest with
            | [ Group (opening, [ Group (innerOpening, _, _) ], _) ] -> opening.Token = TokParenthesis (Round, Open) && innerOpening.Token = TokParenthesis (Curly, Open)
            | _ -> false
        let tupleArgument =
            match rest with
            | [ Group (opening, inner, _) ] -> opening.Token = TokParenthesis (Round, Open) && hasTopComma inner && not (fits indent whole) && fits indent (inlineText (List.take headCount nodes) + " " + opening.Text.Text)
            | _ -> false
        if restIsArguments && tupleArgument then
            match layoutTuple indent (List.head rest) with
            | opening :: inner -> { Indent = indent; Text = inlineText (List.take headCount nodes) + " " + opening.Text } :: inner
            | [] -> [ { Indent = indent; Text = whole } ]
        elif restIsArguments && rest.Length = 1 && not intrinsicRecord && not (fits indent whole) && fits indent (inlineText (List.take headCount nodes) + " (")
             && (match List.head rest with Group (opening, inner, _) -> opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && not inner.IsEmpty && not (carriesComment [ List.head rest ]) | Leaf _ -> false)
             && (match unwrapLambda [ List.head rest ] with first :: _ -> not (isKeyword SpecFun first || isKeyword SpecFunction first) | [] -> false) then
            let opened =
                match List.head rest with
                | Group (_, inner, closing) when not (hasTopComma inner) -> layoutBlock (indent + 4) (unwrapBody inner) @ [ { Indent = indent; Text = closing.Text.Text } ]
                | group -> List.tail (layoutTuple indent group)
            { Indent = indent; Text = inlineText (List.take headCount nodes) + " (" } :: opened
        elif restIsArguments && intrinsicRecord then
            match List.head rest with
            | Group (opening, [ Group (innerOpening, fields, innerClosing) ], closing) ->
                { Indent = indent; Text = inlineText (List.take headCount nodes) + " " + opening.Text.Text + innerOpening.Text.Text }
                :: layoutFields (indent + 4) fields
                @ [ { Indent = indent; Text = innerClosing.Text.Text + closing.Text.Text } ]
            | _ -> [ { Indent = indent; Text = whole } ]
        elif restIsArguments && rest.Length = 1 && isCurly (List.head rest) then
            match List.head rest with
            | Group (opening, inner, closing) ->
                let openText, fields = recordOpening opening inner
                { Indent = indent; Text = inlineText (List.take headCount nodes) + " " + openText }
                :: layoutFields (indent + 4) fields
                @ [ { Indent = indent; Text = closing.Text.Text } ]
            | Leaf _ -> [ { Indent = indent; Text = whole } ]
        elif restIsArguments && rest.Length = 1 && (literalChain (indent + 4) (match List.head rest with Group (opening, [ single ], _) when opening.Token = TokParenthesis (Round, Open) && isStringGroup single -> single | other -> other)).IsSome then
            let literal = match List.head rest with Group (opening, [ single ], _) when opening.Token = TokParenthesis (Round, Open) && isStringGroup single -> single | other -> other
            { Indent = indent; Text = inlineText (List.take headCount nodes) + " (" } :: (literalChain (indent + 4) literal).Value @ [ { Indent = indent; Text = ")" } ]
        elif restIsArguments && rest.Length = 1 && (match List.head rest with Group (opening, _, _) -> (match opening.Token with TokStringOpen | TokMacroOpen -> true | _ -> false) | _ -> false) && not (fits (indent + 4) (inlineText rest)) then
            [ { Indent = indent; Text = whole } ]
        elif restIsArguments then
            { Indent = indent; Text = inlineText (List.take headCount nodes) }
            :: (arguments |> List.collect (fun withGap -> let argument, comments = withoutLeadingGap withGap in (comments |> List.map (fun comment -> if comment = "" then { Indent = 0; Text = "" } else { Indent = indent + 4; Text = comment })) @ match argument with [ single ] when not (fits (indent + 4) (inlineText [ single ])) && (literalChain (indent + 8) single).IsSome -> { Indent = indent + 4; Text = "(" } :: (literalChain (indent + 8) single).Value @ [ { Indent = indent + 4; Text = ")" } ] | [ single ] -> layoutArgument (indent + 4) single | [ unary; (Group (opening, _, _) as array) ] when opening.Token = TokParenthesis (Square, Open) && not (fits (indent + 4) (inlineComplete argument)) -> (match layoutArgument (indent + 4) array with first :: rest -> { first with Text = inlineText [ unary ] + first.Text } :: rest | [] -> []) | bound -> [ { Indent = indent + 4; Text = inlineComplete bound } ]))
        elif headCount = nodes.Length && not (fits indent whole) && nodes |> List.forall (fun node -> match node with Leaf l -> not l.InsideMacro && (match l.Token with TokVar _ | TokSymbol _ | TokValue _ | TokValueSuffix | TokDefaultValue _ | TokUnaryOperator _ | TokOperator (".", _) -> true | _ -> false) | Group _ -> false) && (gluedWords nodes).Length >= 2 then
            match gluedWords nodes with
            | callee :: words -> { Indent = indent; Text = inlineText callee } :: (words |> List.map (fun word -> { Indent = indent + 4; Text = inlineText word }))
            | [] -> [ { Indent = indent; Text = whole } ]
        elif nodes.Length > 1 && not (fits indent whole)
             && (match List.last nodes with Group (opening, inner, _) -> opening.Token = TokParenthesis (Round, Open) && not opening.InsideMacro && hasTopComma inner && not (carriesComment inner) | Leaf _ -> false)
             && List.take (nodes.Length - 1) nodes |> List.forall (fun node -> match node with Leaf l -> not l.InsideMacro && (match l.Token with TokVar _ | TokSymbol _ | TokUnaryOperator _ -> true | _ -> false) | Group _ -> false)
             && fits indent (inlineText (List.take (nodes.Length - 1) nodes) + " (") then
            match layoutTuple indent (List.last nodes) with
            | opening :: inner -> { Indent = indent; Text = inlineText (List.take (nodes.Length - 1) nodes) + (match (firstLexeme (List.last nodes)).Before with Whitespace 0 -> "" | _ -> " ") + opening.Text } :: inner
            | [] -> [ { Indent = indent; Text = whole } ]
        else [ { Indent = indent; Text = whole } ]

and trailingLambdaNeedsBlock (nodes : Node list) =
    match List.tryLast nodes with
    | Some last ->
        match unwrapLambda [ last ] with
        | (first :: _) as lambda when isKeyword SpecFun first -> opensLayout lambda
        | first :: next :: _ when isKeyword SpecFunction first && isOperator "|" next -> true
        | _ -> false
    | _ -> false

and lastArgumentLambda (indent : int) (prefix : string) (nodes : Node list) : LaidLine list option =
    let isLambdaGroup (node : Node) =
        match node with
        | Group _ -> (match unwrapLambda [ node ] with first :: _ -> isKeyword SpecFun first | [] -> false)
        | Leaf _ -> false
    let otherLambdas = nodes |> List.take (max 0 (nodes.Length - 1)) |> List.exists isLambdaGroup
    match List.tryLast nodes with
    | Some _ when otherLambdas -> None
    | Some last when nodes.Length > 1 ->
        match unwrapLambda [ last ] with
        | first :: arms when isKeyword SpecFunction first && (match arms with next :: _ -> isOperator "|" next | [] -> false) ->
            let headText = (if prefix = "" then "" else prefix + " ") + inlineText (List.take (nodes.Length - 1) nodes) + " " + inlineText [ first ]
            if fits indent headText then Some ({ Indent = indent; Text = headText } :: layoutArms (indent + 4) (splitArms arms)) else None
        | (first :: _) as lambda when isKeyword SpecFun first ->
            match indexOfTop (isOperator "=>") lambda with
            | Some arrow ->
                let lambdaHead = List.take (arrow + 1) lambda
                let body = unwrapBody (List.skip (arrow + 1) lambda)
                let headText = (if prefix = "" then "" else prefix + " ") + inlineText (List.take (nodes.Length - 1) nodes) + " " + inlineText lambdaHead
                if fits indent headText then Some ({ Indent = indent; Text = headText } :: layoutBlock (indent + 4) body)
                else None
            | None -> None
        | _ -> None
    | _ -> None

and layoutArgument (indent : int) (argument : Node) : LaidLine list =
    match argument with
    | Group (opening, inner, closing) when opening.Token = TokParenthesis (Square, Open) && not inner.IsEmpty && not (fits indent (inlineText [ argument ])) ->
        let items = splitOn (isOperator ";") inner |> List.filter (fun item -> not item.IsEmpty)
        { Indent = indent; Text = opening.Text.Text } :: (items |> List.collect (layoutExpression (indent + 4))) @ [ { Indent = indent; Text = closing.Text.Text } ]
    | Group (opening, inner, closing) when opening.Token = TokParenthesis (Round, Open) && not inner.IsEmpty && not (hasTopComma inner) && (not (fits indent (inlineText [ argument ])) || carriesComment [ argument ]) && (match unwrapLambda [ argument ] with first :: _ -> not (isKeyword SpecFun first) | [] -> true) ->
        let closingComments =
            match closing.Before with
            | Embedded gap -> commentsIn gap.Text |> List.filter (fun comment -> comment <> "") |> List.map (fun comment -> { Indent = indent + 4; Text = comment })
            | Whitespace _ -> []
        { Indent = indent; Text = opening.Text.Text } :: layoutBlock (indent + 4) (unwrapBody inner) @ closingComments @ [ { Indent = indent; Text = closing.Text.Text } ]
    | Group (opening, inner, _) when opening.Token = TokParenthesis (Round, Open) && hasTopComma inner && not (fits indent (inlineText [ argument ])) -> layoutTuple indent argument
    | Group (opening, inner, closing) when opening.Token = TokParenthesis (Curly, Open) && not (fits indent (inlineText [ argument ])) ->
        let openText, fields = recordOpening opening inner
        { Indent = indent; Text = openText } :: layoutFields (indent + 4) fields @ [ { Indent = indent; Text = closing.Text.Text } ]
    | _ -> layoutExpression indent (unwrapLambda [ argument ])

and keepLambdaParentheses (item : Node list) (lines : LaidLine list) =
    let opensScope =
        match unwrapBody item with
        | first :: _ -> isKeyword SpecFun first || isKeyword SpecFunction first || isKeyword SpecMatch first || isKeyword SpecTypecase first || isKeyword SpecIf first
        | [] -> false
    let scopeWords = [ "fun "; "function"; "match "; "typecase "; "if " ]
    match lines with
    | first :: _ when opensScope && scopeWords |> List.exists (fun word -> first.Text.StartsWith word || first.Text = word.Trim ()) ->
        let wrapped = { first with Text = "(" + first.Text } :: List.tail lines
        match List.rev wrapped with
        | last :: before -> List.rev ({ last with Text = last.Text + ")" } :: before)
        | [] -> wrapped
    | _ -> lines

and layoutTuple (indent : int) (argument : Node) : LaidLine list =
    match argument with
    | Group (opening, inner, closing) ->
        let items = splitOn (isOperator ",") inner |> List.filter (fun item -> not item.IsEmpty)
        let laid =
            items
            |> List.mapi (fun index item ->
                let lines =
                    match layoutExpression (indent + 4) item with
                    | [ single ] when index < items.Length - 1 && not (fits single.Indent (single.Text + ",")) ->
                        layoutExpression (indent + 5) item |> List.map (fun line -> { line with Indent = max 0 (line.Indent - 1) })
                    | laid -> laid
                let lines = if index < items.Length - 1 then keepLambdaParentheses item lines else lines
                if index = items.Length - 1 then lines
                else
                    match List.rev lines with
                    | last :: before -> List.rev ({ last with Text = last.Text + "," } :: before)
                    | [] -> [])
            |> List.concat
        { Indent = indent; Text = opening.Text.Text } :: laid @ [ { Indent = indent; Text = closing.Text.Text } ]
    | Leaf _ -> layoutExpression indent [ argument ]

and recordOpening (opening : Lexeme) (inner : Node list) =
    match indexOfTop (isKeyword SpecWith) inner with
    | Some at when at > 0 -> opening.Text.Text + " " + inlineText (List.take (at + 1) inner), List.skip (at + 1) inner
    | _ -> opening.Text.Text, inner

and layoutFields (indent : int) (inner : Node list) : LaidLine list =
    splitOn (isOperator ";") inner
    |> List.filter (fun field -> not field.IsEmpty)
    |> List.collect (fun field ->
        let text = inlineComplete field
        match indexOfTop (isOperator "=") field with
        | Some at when not (fits indent text) || opensLayout (unwrapBody (List.skip (at + 1) field)) || (statements (unwrapBody (List.skip (at + 1) field))).Length > 1 ->
            let body = unwrapBody (List.skip (at + 1) field)
            let headText = inlineText (List.take (at + 1) field)
            match body with
            | first :: _ when isKeyword SpecFun first && (indexOfTop (isOperator "=>") body).IsSome ->
                let arrow = (indexOfTop (isOperator "=>") body).Value
                let lambdaHead = inlineText (List.take (arrow + 1) body)
                { Indent = indent; Text = headText + " " + lambdaHead } :: layoutBlock (indent + 4) (unwrapBody (List.skip (arrow + 1) body))
            | _ -> { Indent = indent; Text = headText } :: layoutBlock (indent + 4) body
        | _ -> [ { Indent = indent; Text = text } ])

and unwrapLambda (nodes : Node list) =
    match nodes with
    | [ Group (opening, (first :: _ as inner), _) ] when opening.Token = TokParenthesis (Round, Open) && (isKeyword SpecFun first || isKeyword SpecFunction first) -> inner
    | [ Group (opening, ([ Group _ ] as inner), _) ] when opening.Token = TokParenthesis (Round, Open) ->
        match unwrapLambda inner with
        | first :: _ as unwrapped when isKeyword SpecFun first || isKeyword SpecFunction first -> unwrapped
        | _ -> nodes
    | _ -> nodes

let rec mergeAll (nodes : Node list) : Node list =
    nodes
    |> List.map (fun node ->
        match node with
        | Group (opening, inner, closing) when opening.Token <> TokStringOpen && opening.Token <> TokMacroOpen -> Group (opening, mergeAll inner, closing)
        | _ -> node)
    |> fun merged -> if literalSplitting.Enabled then mergeConcatenations merged else merged

type FlatLayout =
    | LaidOut of string list
    | CommentsMisplaced of expected : int * placed : int
    | CommentsInline of count : int
    | NotOneCodeLine

let layoutFlatLine (text : string) : FlatLayout =
    match lexLine lex_state_init text with
    | Code (0, lexemes, tail), _ when tail.Text.Trim().Length = 0 ->
        let expected = lexemes |> Array.sumBy (fun lexeme -> match lexeme.Before with Embedded gap -> (commentsIn gap.Text |> List.filter (fun comment -> comment <> "")).Length | Whitespace _ -> 0)
        let nodes = mergeAll (fst (nodesOf (List.ofArray lexemes)))
        let laid = layoutBlock 0 nodes |> List.map (fun line -> System.String (' ', line.Indent) + line.Text)
        let mutable state = lex_state_init
        let mutable placed = 0
        let mutable inlined = 0
        for line in laid do
            let shape, next = lexLine state line
            state <- next
            match shape with
            | Remark _ -> placed <- placed + 1
            | Code (_, lexemes, tail) ->
                let embedded = lexemes |> Array.sumBy (fun lexeme -> match lexeme.Before with Embedded gap -> (commentsIn gap.Text |> List.filter (fun comment -> comment <> "")).Length | Whitespace _ -> 0)
                inlined <- inlined + embedded + (if tail.Text.Contains "(*" then 1 else 0)
                if tail.Text.TrimStart().StartsWith "//" then placed <- placed + 1
            | Opaque _ | Blank -> ()
        if inlined > 0 then CommentsInline inlined
        elif placed <> expected then CommentsMisplaced (expected, placed)
        else LaidOut laid
    | _ -> NotOneCodeLine

let isOpenLine (text : string) = text.StartsWith "open "

let joinMacroContinuations (text : string) =
    if not literalSplitting.Enabled then text
    else
        let output = ResizeArray<string> ()
        let mutable state = lex_state_init
        let mutable pending : string option = None
        for line in splitLines text do
            let shape, next = lexLine state line
            let joined = match pending with Some head -> head + line.TrimStart () | None -> line
            match shape with
            | Opaque (_, InMacro) when line.EndsWith "\\" && next <> lex_state_init -> pending <- Some (joined.Substring (0, joined.Length - 1))
            | _ ->
                output.Add joined
                pending <- None
            state <- next
        pending |> Option.iter output.Add
        String.concat "\n" output + (if text.EndsWith "\n" then "\n" else "")

let splitMacroLine (line : string) : string list =
    if not literalSplitting.Enabled || line.Length <= 120 then [ line ]
    else
        match lexLine lex_state_init line with
        | Code (indent, lexemes, tail), _ when tail.Text.Trim().Length = 0 ->
            let opens = lexemes |> Array.indexed |> Array.filter (fun (_, lexeme) -> lexeme.Token = TokMacroOpen) |> Array.map fst
            let spans =
                opens
                |> Array.choose (fun start ->
                    let rec find index depth =
                        if index >= lexemes.Length then None
                        else
                            match lexemes.[index].Token with
                            | TokMacroOpen when index <> start -> find (index + 1) (depth + 1)
                            | TokMacroClose when depth = 0 -> Some index
                            | TokMacroClose -> find (index + 1) (depth - 1)
                            | _ -> find (index + 1) depth
                    find (start + 1) 0 |> Option.map (fun stop -> start, stop))
            match spans |> Array.filter (fun (start, stop) -> lexemes.[stop].Span.NearTo - lexemes.[start].Span.From >= 24) |> Array.sortByDescending (fun (start, stop) -> lexemes.[stop].Span.NearTo - lexemes.[start].Span.From) |> Array.tryHead with
            | Some (start, stop) ->
                let openText = lexemes.[start].Text.Text
                let closeText = lexemes.[stop].Text.Text
                let units =
                    let rec collect index (acc : string list) =
                        if index >= stop then List.rev acc
                        else
                            let lexeme = lexemes.[index]
                            let gapBefore at = line.Substring (lexemes.[at - 1].Span.NearTo, lexemes.[at].Span.From - lexemes.[at - 1].Span.NearTo)
                            match lexeme.Token with
                            | TokMacroExpression (_, Open) ->
                                let rec closing at depth =
                                    if at >= stop then stop - 1
                                    else
                                        match lexemes.[at].Token with
                                        | TokMacroExpression (_, Close) when depth = 0 -> at
                                        | TokMacroExpression (_, Close) -> closing (at + 1) (depth - 1)
                                        | TokMacroExpression (_, Open) -> closing (at + 1) (depth + 1)
                                        | _ -> closing (at + 1) depth
                                let last = closing (index + 1) 0
                                let whole = gapBefore index + line.Substring (lexeme.Span.From, lexemes.[last].Span.NearTo - lexeme.Span.From)
                                collect (last + 1) (whole :: acc)
                            | TokText _ when (gapBefore index).Length = 0 -> collect (index + 1) (List.rev (lexeme.Text.Text |> Seq.map string |> List.ofSeq) @ acc)
                            | _ -> collect (index + 1) ((gapBefore index + lexeme.Text.Text) :: acc)
                    collect (start + 1) []
                let prefix = line.Substring (0, lexemes.[start].Span.From)
                let suffix = line.Substring lexemes.[stop].Span.NearTo
                let roomFor (index : int) = if index = 0 then 120 - prefix.Length - openText.Length - 2 else 120 - indent - 4 - 2
                let pieces = ResizeArray<string> ()
                let current = StringBuilder ()
                let mutable lastSpace = -1
                for unit in units do
                    current.Append unit |> ignore
                    let leadingSpaces = unit.Length - unit.TrimStart(' ').Length
                    if unit = " " then lastSpace <- current.Length
                    elif leadingSpaces > 0 && leadingSpaces < unit.Length then lastSpace <- current.Length - unit.Length + leadingSpaces
                    let room = roomFor pieces.Count
                    if current.Length >= room then
                        let cut = if lastSpace > room / 2 then lastSpace else current.Length
                        let text = current.ToString ()
                        pieces.Add (text.Substring (0, cut))
                        current.Clear().Append (text.Substring cut) |> ignore
                        lastSpace <- -1
                if current.Length > 0 then pieces.Add (current.ToString ())
                let pieces =
                    pieces
                    |> List.ofSeq
                    |> List.fold (fun (kept : string list) piece ->
                        let leadingSpaces = piece.Length - piece.TrimStart(' ').Length
                        match kept with
                        | previous :: earlier when leadingSpaces > 0 -> piece.Substring leadingSpaces :: (previous + piece.Substring (0, leadingSpaces)) :: earlier
                        | _ -> piece :: kept) []
                    |> List.rev
                    |> List.filter (fun piece -> piece.Length > 0)
                if pieces.Length < 2 || roomFor 0 < 12 || pieces |> List.exists (fun piece -> piece.StartsWith " ") then [ line ]
                else
                    let continuation = System.String (' ', indent + 4)
                    pieces
                    |> List.mapi (fun index piece ->
                        let lead = if index = 0 then prefix + openText else continuation
                        let trail = if index = pieces.Length - 1 then closeText + suffix else "\\"
                        lead + piece + trail)
            | None -> [ line ]
        | _ -> [ line ]

type LayoutTally() =
    member val VerbatimBlocks = 0 with get, set
    member val VerbatimLines = 0 with get, set
    member val GuardedBlocks = 0 with get, set
    member val Kept = ResizeArray<string * string> ()

let layoutTally = LayoutTally ()

let rewrapComments (lines : string list) =
    let mutable fenced = false
    lines
    |> List.collect (fun line ->
        let trimmed = line.TrimStart ()
        if not (trimmed.StartsWith "//") then [ line ]
        else
            let indent = line.Length - trimmed.Length
            let slashes = trimmed |> Seq.takeWhile (fun c -> c = '/') |> Seq.length
            let marker = trimmed.Substring (0, slashes)
            let body = trimmed.Substring(slashes).TrimStart ()
            if body.StartsWith "```" then
                fenced <- not fenced
                [ line ]
            elif fenced || line.Length <= 120 || body.StartsWith "#" || body.StartsWith ">" then [ line ]
            else
                let prefix = System.String (' ', indent) + marker + " "
                let words = body.Split ' ' |> Array.filter (fun word -> word.Length > 0)
                let output = ResizeArray<string> ()
                let current = StringBuilder (prefix)
                for word in words do
                    if current.Length > prefix.Length && current.Length + 1 + word.Length > 120 then
                        output.Add (current.ToString ())
                        current.Clear().Append(prefix) |> ignore
                    if current.Length > prefix.Length then current.Append ' ' |> ignore
                    current.Append word |> ignore
                if current.Length > prefix.Length then output.Add (current.ToString ())
                List.ofSeq output)

let layout (source : Source<'phase>) =
    let _, blocks = flatten source
    let output = ResizeArray<string> ()
    let mutable previousCode : string option = None
    let mutable previousSingleInstance = false
    for block in blocks do
        let lines =
            match block with
            | Flattened (flat, original) ->
                flat |> List.collect (function
                    | Kept text -> [ text ]
                    | Joined text ->
                        let shapes (lines : string list) =
                            blockShapes source.FileEdition source.FileUnit (String.concat "\n" lines + "\n")
                            |> List.map (fun block -> block.Shape)
                            |> List.filter (fun shape -> shape <> "error")
                        let kept () = original |> List.rev |> List.skipWhile (fun line -> line.Trim().Length = 0) |> List.rev
                        let head () = original |> List.tryFind (fun line -> line.Trim().Length > 0 && not (line.TrimStart().StartsWith "//")) |> Option.defaultValue ""
                        let expected = shapes original
                        let sameParse (lines : string list) = shapes lines = expected && not (expected |> List.exists (fun shape -> shape.StartsWith "error ("))
                        match layoutFlatLine text with
                        | LaidOut laid when sameParse laid ->
                            let split = laid |> List.collect splitMacroLine
                            if split = laid || sameParse split then split else laid
                        | LaidOut _ ->
                            layoutTally.GuardedBlocks <- layoutTally.GuardedBlocks + 1
                            layoutTally.Kept.Add ("parse-guard", head ())
                            kept ()
                        | refusal ->
                            let lines = kept ()
                            layoutTally.VerbatimBlocks <- layoutTally.VerbatimBlocks + 1
                            layoutTally.VerbatimLines <- layoutTally.VerbatimLines + lines.Length
                            let reason =
                                match refusal with
                                | CommentsInline count -> sprintf "comments-inline %d" count
                                | CommentsMisplaced (expected, placed) -> sprintf "comments-misplaced %d/%d" placed expected
                                | NotOneCodeLine | LaidOut _ -> "not-one-code-line"
                            layoutTally.Kept.Add (reason, head ())
                            lines)
            | Refused (_, _, original) -> original
        let lines = lines |> List.skipWhile (fun line -> line.Trim().Length = 0) |> List.rev |> List.skipWhile (fun line -> line.Trim().Length = 0) |> List.rev
        match lines with
        | [] -> ()
        | first :: _ ->
            let codeStart = lines |> List.tryFind (fun line -> not (line.TrimStart().StartsWith "//") && line.Trim().Length > 0)
            let codeLines = lines |> List.filter (fun line -> not (line.TrimStart().StartsWith "//") && line.Trim().Length > 0)
            let oneLineInstance = codeLines.Length = 1 && codeLines.Head.StartsWith "instance "
            let singleInstance = oneLineInstance && first = codeLines.Head
            match previousCode with
            | Some previous when not (isOpenLine previous && (match codeStart with Some c -> isOpenLine c && first = c | None -> false)) && not (singleInstance && previousSingleInstance) -> output.Add ""
            | _ -> ()
            match block with
            | Refused _ -> output.AddRange lines
            | Flattened _ ->
                for line in rewrapComments lines do
                    if not (line.Trim().Length = 0 && output.Count > 0 && output.[output.Count - 1].Trim().Length = 0) then output.Add line
            previousCode <- match codeStart with Some c -> Some c | None -> previousCode
            previousSingleInstance <- oneLineInstance
    List.ofSeq output
