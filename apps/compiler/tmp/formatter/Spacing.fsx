#load "Lexed.fsx"

open Spiral.spiral_compiler
open Lexed

type Respacing =
    | OperatorSpace
    | SeparatorTight
    | SeparatorSpace
    | ApplicationSpace
    | BracketInnerSpace
    | EmptyBracketTight
    | ConstraintBraceTight
    | OperatorSectionTight

type GapRule =
    | AsWritten
    | Fixed of Respacing * width : int

type LineChange =
    | TrailingWhitespace
    | Respaced of Respacing
    | GuardKept

type SpacedLine =
    { Line : Line<Spaced>
      Changes : LineChange list }

let binaryOperator token =
    match token with
    | TokOperator (name, _) -> Some name
    | _ -> None

let isUnary token =
    match token with
    | TokUnaryOperator _ -> true
    | _ -> false

let isOpening shape token =
    match token with
    | TokParenthesis (kind, Open) -> kind = shape
    | _ -> false

let isClosing shape token =
    match token with
    | TokParenthesis (kind, Close) -> kind = shape
    | _ -> false

let isAnyOpening token =
    match token with
    | TokParenthesis (_, Open) -> true
    | _ -> false

let isSeparator name = name = "," || name = ";"

let isSequence name = name = "."

let appliesToParenthesis token =
    match token with
    | TokVar _ -> true
    | TokParenthesis (Round, Close) -> true
    | _ -> false

let constraintBraces (lexemes : Lexeme[]) =
    let marks = Array.zeroCreate lexemes.Length
    let mutable inForall = false
    let mutable inInstanceHead = false
    let mutable braceDepth = 0
    lexemes
    |> Array.iteri (fun index lexeme ->
        match lexeme.Token with
        | TokKeyword SpecForall -> inForall <- true
        | TokKeyword SpecInstance when index = 0 -> inInstanceHead <- true
        | TokOperator (".", _) when inForall && braceDepth = 0 -> inForall <- false
        | TokOperator ("=", _) when inInstanceHead && braceDepth = 0 -> inInstanceHead <- false
        | TokParenthesis (Curly, Open) when inForall || inInstanceHead ->
            braceDepth <- braceDepth + 1
            marks.[index] <- true
        | TokParenthesis (Curly, Close) when braceDepth > 0 ->
            braceDepth <- braceDepth - 1
            marks.[index] <- true
        | _ -> ())
    marks

let gapRule (lexemes : Lexeme[]) (constraintMarks : bool[]) (index : int) =
    let left = lexemes.[index - 1]
    let right = lexemes.[index]
    let at offset = if index + offset >= 0 && index + offset < lexemes.Length then Some lexemes.[index + offset].Token else None
    let macroInterior =
        (right.InsideMacro && right.Token <> TokMacroOpen) || (left.InsideMacro && left.Token <> TokMacroClose)
    match left.Before, right.Before with
    | _, Embedded _ -> AsWritten
    | _ when macroInterior -> AsWritten
    | _ when isUnary left.Token -> AsWritten
    | _ ->
        let sectionOpen = isOpening Round left.Token && (binaryOperator right.Token).IsSome && (at 1 |> Option.exists (isClosing Round))
        let sectionClose = isClosing Round right.Token && (binaryOperator left.Token).IsSome && (at -2 |> Option.exists (isOpening Round))
        let innerOperator =
            ((binaryOperator left.Token).IsSome && (match right.Token with TokParenthesis (_, Close) -> true | _ -> false))
            || ((binaryOperator right.Token).IsSome && isAnyOpening left.Token)
        if sectionOpen || sectionClose then Fixed (OperatorSectionTight, 0)
        elif innerOperator then AsWritten
        else
            match binaryOperator left.Token, binaryOperator right.Token with
            | _, Some name when isSeparator name -> Fixed (SeparatorTight, 0)
            | Some name, _ when isSeparator name -> Fixed (SeparatorSpace, 1)
            | Some name, _ when isSequence name -> AsWritten
            | _, Some name when isSequence name -> AsWritten
            | Some _, _ -> Fixed (OperatorSpace, 1)
            | _, Some _ -> Fixed (OperatorSpace, 1)
            | None, None ->
                let constraintGap = constraintMarks.[index - 1] && isAnyOpening left.Token || constraintMarks.[index] && not (isAnyOpening right.Token)
                if constraintGap then Fixed (ConstraintBraceTight, 0)
                elif appliesToParenthesis left.Token && isOpening Round right.Token && left.Span.NearTo = right.Span.From then Fixed (ApplicationSpace, 1)
                elif isOpening Curly left.Token && isClosing Curly right.Token then Fixed (EmptyBracketTight, 0)
                elif isOpening Square left.Token && isClosing Square right.Token then Fixed (EmptyBracketTight, 0)
                elif isOpening Curly left.Token || isOpening Square left.Token then Fixed (BracketInnerSpace, 1)
                elif isClosing Curly right.Token || isClosing Square right.Token then Fixed (BracketInnerSpace, 1)
                else AsWritten

let tokenSignature (lexemes : Lexeme[]) =
    lexemes |> Array.map (fun lexeme -> lexeme.Text.Text, (sprintf "%A" lexeme.Token).GetHashCode ())

let tokenKinds (lexemes : Lexeme[]) =
    lexemes
    |> Array.map (fun lexeme ->
        let kind =
            match lexeme.Token with
            | TokOperator _ -> "op"
            | TokUnaryOperator _ -> "unary"
            | TokVar _ -> "var"
            | TokSymbol _ -> "symbol"
            | TokKeyword keyword -> sprintf "%A" keyword
            | TokParenthesis (shape, state) -> sprintf "%A%A" shape state
            | other -> (sprintf "%A" other).Split(' ').[0]
        kind, lexeme.Text.Text)

let respaceLine (line : Line<AsRead>) : Line<Spaced> * LineChange list * string option =
    match line.Shape with
    | Blank | Opaque _ -> { Number = line.Number; Shape = line.Shape }, [], None
    | Remark text ->
        let trimmed = trimmedTail text
        if trimmed.Length = text.Length then { Number = line.Number; Shape = line.Shape }, [], None
        else
            match lexLine lex_state_init trimmed.Text with
            | Remark _, _ -> { Number = line.Number; Shape = Remark trimmed }, [ TrailingWhitespace ], None
            | Blank, _ -> { Number = line.Number; Shape = Blank }, [ TrailingWhitespace ], None
            | _ -> { Number = line.Number; Shape = line.Shape }, [ GuardKept ], Some trimmed.Text
    | Code (indent, lexemes, tail) ->
        let marks = constraintBraces lexemes
        let changes = ResizeArray ()
        let respaced =
            lexemes
            |> Array.mapi (fun index lexeme ->
                if index = 0 then lexeme
                else
                    match gapRule lexemes marks index, lexeme.Before with
                    | Fixed (reason, width), Whitespace current when current <> width ->
                        changes.Add (Respaced reason)
                        { lexeme with Before = Whitespace width }
                    | _ -> lexeme)
        let trimmed = trimmedTail tail
        if trimmed.Length <> tail.Length then changes.Add TrailingWhitespace
        let candidate = { Number = line.Number; Shape = Code (indent, respaced, trimmed) }
        if changes.Count = 0 then candidate, [], None
        else
            let text = render candidate
            match lexLine lex_state_init text with
            | Code (_, relexed, _), _ when tokenKinds relexed = tokenKinds lexemes -> candidate, List.ofSeq changes, None
            | _ ->
                let original = { Number = line.Number; Shape = Code (indent, lexemes, trimmed) }
                original, [ GuardKept ], Some text

let respace (source : Source<AsRead>) =
    let results = source.SourceLines |> Array.map respaceLine
    let lines = results |> Array.map (fun (line, _, _) -> line)
    let mutable last = lines.Length
    while last > 0 && (match lines.[last - 1].Shape with Blank -> true | _ -> false) do
        last <- last - 1
    let texts = lines.[0 .. last - 1] |> Array.map render
    let spaced : Source<Spaced> = relex source texts
    let changes = results |> Array.map (fun (line, changes, guard) -> line.Number, changes, guard)
    spaced, changes
