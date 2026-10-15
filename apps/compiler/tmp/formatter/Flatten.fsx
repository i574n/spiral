#load "Lexed.fsx"

open System.Text
open Polyglot.spiral_compiler
open Lexed

type Unflattenable =
    | MultilineLiteralOrComment
    | CommentWithDelimiters
    | IndentationBelowBlock

type FlatLine =
    | Kept of string
    | Joined of string

type FlatBlock =
    | Flattened of FlatLine list * original : string list
    | Refused of Unflattenable * firstLine : int * lines : string list

type CodeLine =
    { Number : int
      Indent : int
      Lexemes : Lexeme[]
      Remark : string option
      Leading : string list }

let blankMarker = "(* *)"

let leadingPrefix (line : CodeLine) = if line.Leading.IsEmpty then "" else String.concat " " line.Leading + " "

let codeText (lexemes : Lexeme[]) =
    let builder = StringBuilder ()
    lexemes
    |> Array.iteri (fun index lexeme ->
        if index > 0 then
            match lexeme.Before with
            | Whitespace count -> builder.Append (' ', count) |> ignore
            | Embedded text -> builder.Append text.Text |> ignore
        builder.Append lexeme.Text.Text |> ignore)
    builder.ToString ()

let inlineComment (text : string) =
    let body = text.Trim ()
    if body.Contains "(*" || body.Contains "*)" then None
    else Some ("(* " + body + " *)")

let isStatementStart (lexemes : Lexeme[]) =
    match lexemes.[0].Token with
    | TokKeyword (SpecInl | SpecLet | SpecOpen) -> true
    | _ -> false

let startsAsContinuation (lexemes : Lexeme[]) =
    match lexemes.[0].Token with
    | TokOperator _ -> true
    | TokKeyword (SpecThen | SpecElse | SpecElif | SpecWith | SpecWhen | SpecIn | SpecAs | SpecAnd) -> true
    | TokParenthesis (_, Close) -> true
    | _ -> false

type Opening =
    | BodyOpening
    | ItemsOpening
    | GroupOpening
    | NoOpening

let unclosedCurly (lexemes : Lexeme[]) =
    let depth =
        lexemes
        |> Array.fold (fun depth lexeme ->
            match lexeme.Token with
            | TokParenthesis (Curly, Open) when not lexeme.InsideMacro -> depth + 1
            | TokParenthesis (Curly, Close) when not lexeme.InsideMacro -> depth - 1
            | _ -> depth) 0
    depth > 0

let openingOf (lexemes : Lexeme[]) =
    match lexemes.[lexemes.Length - 1].Token with
    | TokKeyword SpecWith when unclosedCurly lexemes -> ItemsOpening
    | TokOperator (("=" | "=>"), _) -> BodyOpening
    | TokKeyword (SpecThen | SpecElse | SpecIn | SpecReal | SpecFunction | SpecWith | SpecJoin | SpecJoinBackend) -> BodyOpening
    | TokParenthesis ((Curly | Square), Open) -> ItemsOpening
    | TokParenthesis (Round, Open) -> GroupOpening
    | _ -> NoOpening

let lambdaStart (lexemes : Lexeme[]) =
    match lexemes.[lexemes.Length - 1].Token with
    | TokOperator ("=>", _) ->
        let arm = match lexemes.[0].Token with TokOperator ("|", _) -> true | _ -> false
        if arm then None
        else
            match lexemes |> Array.tryFindIndexBack (fun lexeme -> lexeme.Token = TokKeyword SpecFun || lexeme.Token = TokKeyword SpecFunction) with
            | Some index -> Some index
            | None -> lexemes |> Array.tryFindIndex (fun lexeme -> lexeme.Token = TokKeyword SpecForall)
    | _ -> None

let separatorAfter (typeLevel : bool) (context : Opening) (element : CodeLine) (lastLine : CodeLine) (next : CodeLine) =
    if startsAsContinuation next.Lexemes then " "
    else
        match lastLine.Lexemes.[lastLine.Lexemes.Length - 1].Token with
        | TokOperator _ | TokParenthesis (_, Open) -> " "
        | TokKeyword (SpecThen | SpecElse | SpecIn | SpecWith | SpecFun) -> " "
        | _ when context = ItemsOpening -> "; "
        | _ when typeLevel -> " "
        | _ when context = NoOpening -> " "
        | _ when isStatementStart element.Lexemes -> " in "
        | _ -> " . "

let roundDepth (lexemes : Lexeme[]) =
    lexemes
    |> Array.fold (fun depth lexeme ->
        match lexeme.Token with
        | TokParenthesis (Round, Open) when not lexeme.InsideMacro -> depth + 1
        | TokParenthesis (Round, Close) when not lexeme.InsideMacro -> depth - 1
        | _ -> depth) 0

let itemDepth (lexemes : Lexeme[]) =
    lexemes
    |> Array.fold (fun depth lexeme ->
        match lexeme.Token with
        | TokParenthesis ((Curly | Square), Open) when not lexeme.InsideMacro -> depth + 1
        | TokParenthesis ((Curly | Square), Close) when not lexeme.InsideMacro -> depth - 1
        | _ -> depth) 0

let remarkSuffix (line : CodeLine) = match line.Remark with Some comment when comment <> "" -> " " + comment | _ -> ""

let rec flattenRegion (typeLevel : bool) (context : Opening) (lines : CodeLine list) : string =
    match lines with
    | [] -> ""
    | first :: _ ->
        let column = first.Indent
        let rec split (rest : CodeLine list) =
            match rest with
            | [] -> []
            | head :: tail ->
                let inside = tail |> List.takeWhile (fun line -> line.Indent > column)
                (head, inside) :: split (List.skip inside.Length tail)
        let rec elementText (head : CodeLine) (inside : CodeLine list) =
            let prefix = leadingPrefix head
            if prefix <> "" then prefix + elementText { head with Leading = [] } inside else
            let headText = codeText head.Lexemes + remarkSuffix head
            if inside.IsEmpty then headText
            else
                let opening =
                    match openingOf head.Lexemes with
                    | BodyOpening when context = ItemsOpening && head.Lexemes.[head.Lexemes.Length - 1].Token = TokKeyword SpecWith -> ItemsOpening
                    | other -> other
                let quotesTerm =
                    head.Lexemes.Length >= 2
                    && (match head.Lexemes.[head.Lexemes.Length - 2].Token with TokUnaryOperator ("`", _) -> true | _ -> false)
                let innerTypeLevel = typeLevel && not quotesTerm
                let trailingClosers =
                    List.rev inside |> List.takeWhile (fun line -> match line.Lexemes.[0].Token with TokParenthesis (Round, Close) -> true | _ -> false) |> List.rev
                let beforeClosers = List.take (inside.Length - trailingClosers.Length) inside
                let unclosedRound = roundDepth head.Lexemes > 0 && roundDepth head.Lexemes + (beforeClosers |> List.sumBy (fun line -> roundDepth line.Lexemes)) > 0
                let closers, bodyLines = if unclosedRound then trailingClosers, beforeClosers else [], inside
                let closerText = closers |> List.map (fun line -> codeText line.Lexemes + remarkSuffix line) |> String.concat " "
                let withClosers (text : string) = if closerText = "" then text else text + " " + closerText
                if bodyLines.IsEmpty then withClosers headText else
                let body = flattenRegion innerTypeLevel opening bodyLines
                let armsOrCases = match (List.head bodyLines).Lexemes.[0].Token with TokOperator ("|", _) -> true | _ -> false
                let armColumn = (List.head bodyLines).Indent
                let operatorAfterArms =
                    if not armsOrCases || innerTypeLevel || opening <> BodyOpening then None
                    else
                        bodyLines
                        |> List.tryFindIndex (fun line -> line.Indent = armColumn && (match line.Lexemes.[0].Token with TokOperator (name, _) -> name <> "|" | _ -> false))
                        |> Option.bind (fun at ->
                            head.Lexemes
                            |> Array.tryFindIndexBack (fun lexeme -> not lexeme.InsideMacro && (lexeme.Token = TokKeyword SpecFunction || lexeme.Token = TokKeyword SpecMatch))
                            |> Option.map (fun opener -> at, opener))
                match operatorAfterArms with
                | Some (at, opener) when closers.IsEmpty ->
                    let arms = flattenRegion innerTypeLevel opening (List.take at bodyLines)
                    let after = flattenRegion typeLevel NoOpening (List.skip at bodyLines)
                    let before = if opener = 0 then "" else codeText head.Lexemes.[0 .. opener - 1] + " "
                    before + "(" + codeText head.Lexemes.[opener ..] + " " + arms + ")" + remarkSuffix head + " " + after
                | _ ->
                match opening with
                | BodyOpening when innerTypeLevel || armsOrCases -> withClosers (headText + " " + body)
                | BodyOpening ->
                    match lambdaStart head.Lexemes with
                    | Some index when not unclosedRound ->
                        let before = if index = 0 then "" else codeText head.Lexemes.[0 .. index - 1] + " "
                        before + "(" + codeText head.Lexemes.[index ..] + " (" + body + "))" + remarkSuffix head
                    | _ -> withClosers (headText + " (" + body + ")")
                | ItemsOpening | GroupOpening | NoOpening -> withClosers (headText + " " + body)
        let opensScope (head : CodeLine) =
            head.Lexemes
            |> Array.exists (fun lexeme ->
                not lexeme.InsideMacro
                && (match lexeme.Token with
                    | TokKeyword (SpecFun | SpecFunction | SpecMatch | SpecIf | SpecInl | SpecLet) -> true
                    | _ -> false))
        let continues (last : CodeLine) (next : CodeLine) =
            startsAsContinuation next.Lexemes
            || (match last.Lexemes.[last.Lexemes.Length - 1].Token with
                | TokOperator _ | TokParenthesis (_, Open) -> true
                | TokKeyword (SpecThen | SpecElse | SpecIn | SpecWith | SpecFun) -> true
                | _ -> false)
        let items =
            let grouped = ResizeArray<ResizeArray<CodeLine * CodeLine list>> ()
            let rec absorbBody (elements : (CodeLine * CodeLine list) list) =
                match elements with
                | (head, []) :: rest when not rest.IsEmpty && (match head.Lexemes.[head.Lexemes.Length - 1].Token with TokOperator ("=", _) -> true | _ -> false) ->
                    [ (head, rest |> List.collect (fun (h, i) -> h :: i)) ]
                | (head, inside) :: rest when not rest.IsEmpty && not inside.IsEmpty && (let last = List.last inside in match last.Lexemes.[last.Lexemes.Length - 1].Token with TokOperator ("=", _) -> true | _ -> false) ->
                    let last = List.last inside
                    let absorbed = rest |> List.collect (fun (h, i) -> h :: i)
                    let shift = last.Indent + 4 - (absorbed |> List.map (fun line -> line.Indent) |> List.min)
                    [ (head, inside @ (absorbed |> List.map (fun line -> { line with Indent = line.Indent + max 0 shift }))) ]
                | (head, inside) :: rest when not rest.IsEmpty && (let last = (match List.tryLast inside with Some l -> l | None -> head) in match last.Lexemes.[last.Lexemes.Length - 1].Token with TokKeyword (SpecThen | SpecElse) | TokOperator ("=>", _) -> true | _ -> false)
                                              && not (startsAsContinuation (fst (List.head rest)).Lexemes) ->
                    let last = match List.tryLast inside with Some l -> l | None -> head
                    let taken =
                        let balanceOf (h : CodeLine, i : CodeLine list) = (h :: i) |> List.sumBy (fun line -> itemDepth line.Lexemes + roundDepth line.Lexemes)
                        let opensArms (h : CodeLine, i : CodeLine list) =
                            let lastLine = match List.tryLast i with Some line -> line | None -> h
                            match lastLine.Lexemes.[lastLine.Lexemes.Length - 1].Token with
                            | TokKeyword (SpecWith | SpecFunction) -> true
                            | _ -> false
                        let isArm (h : CodeLine) = match h.Lexemes.[0].Token with TokOperator ("|", _) -> true | _ -> false
                        let rec take (items : (CodeLine * CodeLine list) list) (openIfs : int) (balance : int) (armsOpen : bool) =
                            match items with
                            | (h, i) :: tail when balance > 0 && balance + balanceOf (h, i) >= 0 ->
                                (h, i) :: take tail openIfs (balance + balanceOf (h, i)) (armsOpen || opensArms (h, i))
                            | (h, i) :: tail when armsOpen && isArm h ->
                                (h, i) :: take tail openIfs (balance + balanceOf (h, i)) true
                            | (h, i) :: tail when not (startsAsContinuation h.Lexemes) ->
                                let opensIf = h.Lexemes.[0].Token = TokKeyword SpecIf
                                (h, i) :: take tail (if opensIf then openIfs + 1 else openIfs) (balance + balanceOf (h, i)) (armsOpen || opensArms (h, i))
                            | (h, i) :: tail when openIfs > 0 && (h.Lexemes.[0].Token = TokKeyword SpecElse || h.Lexemes.[0].Token = TokKeyword SpecElif || h.Lexemes.[0].Token = TokKeyword SpecThen) ->
                                (h, i) :: take tail (if h.Lexemes.[0].Token = TokKeyword SpecElse then openIfs - 1 else openIfs) (balance + balanceOf (h, i)) armsOpen
                            | _ -> []
                        take rest 0 0 false
                    let remaining = List.skip taken.Length rest
                    let absorbed = taken |> List.collect (fun (h, i) -> h :: i)
                    let shift = last.Indent + 4 - (absorbed |> List.map (fun line -> line.Indent) |> List.min)
                    (head, inside @ (absorbed |> List.map (fun line -> { line with Indent = line.Indent + max 0 shift }))) :: absorbBody remaining
                | element :: rest -> element :: absorbBody rest
                | [] -> []
            let mutable openBrackets = 0
            for (head, inside) in absorbBody (split lines) do
                let lastOfCurrent =
                    if grouped.Count = 0 then None
                    else
                        let (h, i) = grouped.[grouped.Count - 1].[grouped.[grouped.Count - 1].Count - 1]
                        Some (match List.tryLast i with Some line -> line | None -> h)
                let balance = itemDepth head.Lexemes + (inside |> List.sumBy (fun line -> itemDepth line.Lexemes))
                match lastOfCurrent with
                | Some last when openBrackets > 0 || continues last head ->
                    grouped.[grouped.Count - 1].Add (head, inside)
                    openBrackets <- openBrackets + balance
                | _ ->
                    grouped.Add (ResizeArray [ (head, inside) ])
                    openBrackets <- max 0 balance
            grouped |> Seq.map List.ofSeq |> List.ofSeq
        let statementRegion = not typeLevel && context <> ItemsOpening && context <> NoOpening && items.Length > 1
        let openerIndex (lexemes : Lexeme[]) =
            let mutable depth = 0
            let mutable found = None
            for index in 0 .. lexemes.Length - 1 do
                let lexeme = lexemes.[index]
                if not lexeme.InsideMacro && found.IsNone then
                    match lexeme.Token with
                    | TokParenthesis (_, Open) -> depth <- depth + 1
                    | TokParenthesis (_, Close) -> depth <- max 0 (depth - 1)
                    | TokKeyword (SpecFun | SpecFunction | SpecMatch | SpecIf | SpecReal | SpecJoin | SpecJoinBackend) when depth = 0 -> found <- Some index
                    | _ -> ()
            found
        let isOperatorContinuation (head : CodeLine) =
            match head.Lexemes.[0].Token with
            | TokOperator (name, _) -> name <> "|"
            | _ -> false
        let itemText (item : (CodeLine * CodeLine list) list) =
            let array = Array.ofList item
            let first = fst array.[0]
            let builder = StringBuilder ()
            let openers = System.Collections.Generic.Stack<int * bool> ()
            let note (head : CodeLine) (start : int) =
                let isArm = match head.Lexemes.[0].Token with TokOperator ("|", _) -> true | _ -> false
                if not isArm then
                    match openerIndex head.Lexemes with
                    | Some at ->
                        let prefix = (leadingPrefix head).Length + (if at = 0 then 0 else (codeText head.Lexemes.[0 .. at - 1]).Length + 1)
                        openers.Push ((start + prefix, head.Lexemes.[at].Token = TokKeyword SpecIf))
                    | None -> ()
            let close (stopAtIf : bool) =
                let mutable stop = false
                while openers.Count > 0 && not stop do
                    let position, isIf = openers.Peek ()
                    if stopAtIf && isIf then stop <- true
                    else
                        openers.Pop () |> ignore
                        builder.Insert (position, "(") |> ignore
                        builder.Append ")" |> ignore
            let depthOf (head : CodeLine, inside : CodeLine list) = itemDepth head.Lexemes + (inside |> List.sumBy (fun line -> itemDepth line.Lexemes))
            let mutable bracketDepth = depthOf array.[0]
            note first 0
            builder.Append (elementText first (snd array.[0])) |> ignore
            for index in 1 .. array.Length - 1 do
                let head, inside = array.[index]
                let previousHead, previousInside = array.[index - 1]
                let previousLast = match List.tryLast previousInside with Some line -> line | None -> previousHead
                let previousOpen =
                    match previousLast.Lexemes.[previousLast.Lexemes.Length - 1].Token with
                    | TokOperator _ | TokParenthesis (_, Open) -> true
                    | _ -> false
                let field = bracketDepth > 0 && not previousOpen && not (startsAsContinuation head.Lexemes)
                bracketDepth <- bracketDepth + depthOf (head, inside)
                if isOperatorContinuation head then close false
                else
                    match head.Lexemes.[0].Token with
                    | TokKeyword (SpecThen | SpecElse | SpecElif) -> close true
                    | _ -> ()
                builder.Append (if field then "; " else " ") |> ignore
                let start = builder.Length
                note head start
                builder.Append (elementText head inside) |> ignore
            let text = builder.ToString ()
            let head = first
            if context = NoOpening && head.Indent > 0 && opensScope head && not (startsAsContinuation head.Lexemes) then "(" + text + ")"
            elif statementRegion && not (isStatementStart head.Lexemes) then "(" + text + ")"
            else text
        let rec join (items : (CodeLine * CodeLine list) list list) =
            match items with
            | [] -> ""
            | item :: rest ->
                let text = itemText item
                match rest with
                | [] -> text
                | next :: _ ->
                    let head = fst (List.head item)
                    let nextHead = fst (List.head next)
                    let separator =
                        if context = ItemsOpening then "; "
                        elif typeLevel || context = NoOpening then " "
                        elif isStatementStart head.Lexemes then " in "
                        else " . "
                    let tail = join rest
                    let tail = if separator = " . " && isStatementStart nextHead.Lexemes then "(" + tail + ")" else tail
                    text + separator + tail
        join items

let flattenBlock (lines : Line<'phase> list) : FlatBlock =
    let leading = lines |> List.takeWhile (fun line -> match line.Shape with Code (0, _, _) -> false | _ -> true)
    let afterLeading = lines |> List.skip leading.Length
    let lastCode = afterLeading |> List.tryFindIndexBack (fun line -> match line.Shape with Code _ | Opaque _ -> true | _ -> false)
    let rest, trailingLines =
        match lastCode with
        | Some at -> List.take (at + 1) afterLeading, List.skip (at + 1) afterLeading
        | None -> afterLeading, []
    let leadingText = leading |> List.map (fun line -> Kept (render line))
    let trailingText = trailingLines |> List.map (fun line -> Kept (render line))
    if rest |> List.exists (fun line -> match line.Shape with Opaque _ -> true | _ -> false) then
        Refused (MultilineLiteralOrComment, (List.head lines).Number, lines |> List.map render)
    elif rest.IsEmpty then Flattened (leadingText @ trailingText, [])
    else
        let code = ResizeArray<CodeLine> ()
        let pending = ResizeArray<string> ()
        let mutable refused = None
        for line in rest do
            match line.Shape with
            | Code (indent, lexemes, tail) ->
                let remark = if tail.Text.Trim().Length = 0 then None else inlineComment tail.Text
                if tail.Text.Trim().Length > 0 && remark.IsNone then refused <- Some CommentWithDelimiters
                code.Add { Number = line.Number; Indent = indent; Lexemes = lexemes; Remark = remark; Leading = List.ofSeq pending }
                pending.Clear ()
            | Remark text ->
                match inlineComment text.Text with
                | Some comment -> pending.Add comment
                | None -> refused <- Some CommentWithDelimiters
            | Blank -> if code.Count > 0 && (pending.Count = 0 || pending.[pending.Count - 1] <> blankMarker) then pending.Add blankMarker
            | Opaque _ -> ()

        match refused with
        | Some reason -> Refused (reason, (List.head lines).Number, lines |> List.map render)
        | None ->
            let typeLevel =
                match code.[0].Lexemes.[0].Token with
                | TokKeyword (SpecType | SpecNominal | SpecUnion | SpecPrototype) -> true
                | TokKeyword SpecAnd when code.[0].Lexemes.Length > 1 && code.[0].Lexemes.[1].Token = TokKeyword SpecUnion -> true
                | _ -> false
            let startsArm (line : CodeLine) = match line.Lexemes.[0].Token with TokOperator ("|", _) -> true | _ -> false
            let endsWithArrow (line : CodeLine) = match line.Lexemes.[line.Lexemes.Length - 1].Token with TokOperator ("=>", _) -> true | _ -> false
            let guardOnOwnLine (previous : CodeLine) (line : CodeLine) =
                line.Lexemes.[0].Token = TokKeyword SpecWhen && line.Leading.IsEmpty && previous.Remark.IsNone
                && startsArm previous && not (endsWithArrow previous) && line.Indent > previous.Indent
            let armsWithGuards =
                code
                |> Seq.fold (fun (merged : CodeLine list) line ->
                    match merged with
                    | previous :: earlier when guardOnOwnLine previous line ->
                        let glued = Array.append [| { line.Lexemes.[0] with Before = Whitespace 1 } |] line.Lexemes.[1..]
                        { previous with Lexemes = Array.append previous.Lexemes glued; Remark = line.Remark } :: earlier
                    | _ -> line :: merged) []
                |> List.rev
            let text = flattenRegion typeLevel NoOpening armsWithGuards
            Flattened (leadingText @ [ Joined text ] @ trailingText, rest |> List.map render)

let blocksOf (source : Source<'phase>) =
    let lines = List.ofArray source.SourceLines
    let rec split (rest : Line<'phase> list) (current : Line<'phase> list) (seenCode : bool) =
        match rest with
        | [] -> if current.IsEmpty then [] else [ List.rev current ]
        | line :: tail ->
            let startsBlock = match line.Shape with Code (0, _, _) -> true | _ -> false
            let isLead = match line.Shape with Remark _ | Blank -> true | _ -> false
            if startsBlock && seenCode then List.rev current :: split tail [ line ] true
            elif isLead && seenCode && (match tail |> List.tryFind (fun l -> match l.Shape with Remark _ | Blank -> false | _ -> true) with Some next -> (match next.Shape with Code (0, _, _) -> true | _ -> false) | None -> false) && (match line.Shape with Remark text -> not (text.Text.StartsWith " ") | _ -> true) then
                List.rev current :: split tail [ line ] false
            else split tail (line :: current) (seenCode || startsBlock)
    split lines [] false

let flatten (source : Source<'phase>) =
    let blocks = blocksOf source |> List.map flattenBlock
    let lines =
        blocks
        |> List.collect (function
            | Flattened (flat, _) -> flat |> List.map (function Kept text | Joined text -> text)
            | Refused (_, _, original) -> original)
    lines, blocks
