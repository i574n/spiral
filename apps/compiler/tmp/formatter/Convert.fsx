#load "Lexed.fsx"

open Spiral.spiral_compiler
open Lexed

type Spelling =
    | Words
    | Symbols

let symbolOf keyword =
    match keyword with
    | SpecInl -> Some ":="
    | SpecLet -> Some ":~"
    | SpecRec -> Some "^"
    | SpecAnd -> Some ":&"
    | SpecIn -> Some ";;"
    | SpecFun -> Some "\\"
    | SpecFunction -> Some "\\|"
    | SpecForall -> Some "\\*"
    | SpecExists -> Some "\\?"
    | SpecIf -> Some "?"
    | SpecThen -> Some "?>"
    | SpecElif -> Some "|?"
    | SpecElse -> Some "|:"
    | SpecMatch -> Some "?="
    | SpecTypecase -> Some "?:"
    | SpecWith -> Some "?|"
    | SpecWithout -> Some "-|"
    | SpecAs -> Some "&="
    | SpecWhen -> Some "?&"
    | SpecType -> Some ":=="
    | SpecNominal -> Some ":!"
    | SpecUnion -> Some ":|"
    | SpecPrototype -> Some ":?"
    | SpecInstance -> Some ":+"
    | SpecOpen -> Some ":<"
    | SpecReal -> Some "~>"
    | SpecJoin -> Some "~~"
    | SpecJoinBackend -> Some "~~>"
    | SpecInm | SpecInb | SpecWildcard -> None

let wordOf keyword =
    match keyword with
    | SpecIn -> "in" | SpecAnd -> "and" | SpecFun -> "fun" | SpecMatch -> "match" | SpecTypecase -> "typecase"
    | SpecFunction -> "function" | SpecWith -> "with" | SpecWithout -> "without" | SpecAs -> "as" | SpecWhen -> "when"
    | SpecInl -> "inl" | SpecForall -> "forall" | SpecExists -> "exists" | SpecLet -> "let" | SpecInm -> "inm"
    | SpecInb -> "inb" | SpecRec -> "rec" | SpecIf -> "if" | SpecThen -> "then" | SpecElif -> "elif" | SpecElse -> "else"
    | SpecJoin -> "join" | SpecJoinBackend -> "join_backend" | SpecType -> "type" | SpecNominal -> "nominal"
    | SpecReal -> "real" | SpecUnion -> "union" | SpecOpen -> "open" | SpecWildcard -> "_" | SpecPrototype -> "prototype"
    | SpecInstance -> "instance"

let isWordText (text : string) = text.Length > 0 && (System.Char.IsLetterOrDigit text.[0] || text.[0] = '_')

let respell (target : Spelling) (lexeme : Lexeme) =
    if lexeme.InsideMacro then None
    else
        match target, lexeme.Token with
        | Symbols, TokKeyword keyword when isWordText lexeme.Text.Text -> symbolOf keyword
        | Symbols, TokValue (LitBool value) when isWordText lexeme.Text.Text -> Some (if value then "!+" else "!-")
        | Words, TokKeyword keyword when not (isWordText lexeme.Text.Text) -> Some (wordOf keyword)
        | Words, TokValue (LitBool value) when not (isWordText lexeme.Text.Text) -> Some (if value then "true" else "false")
        | _ -> None

let tokenIdentity (token : SpiralToken) =
    match token with
    | TokKeyword keyword -> sprintf "keyword %A" keyword
    | TokValue (LitBool value) -> sprintf "bool %b" value
    | TokOperator (name, _) -> "op " + name
    | TokUnaryOperator (name, _) -> "unary " + name
    | other -> sprintf "%A" other

let fuses (left : string) (right : string) =
    let last = left.[left.Length - 1]
    let first = right.[0]
    (is_var_char last && is_var_char first) || (is_operator_char last && is_operator_char first && first <> ',')

type LineConversion =
    | Unchanged
    | Converted of string
    | Rejected of attempted : string

let convertLine (target : Spelling) (line : Line<'phase>) =
    match line.Shape with
    | Code (_, lexemes, tail) ->
        let pieces = lexemes |> Array.map (fun lexeme -> lexeme, respell target lexeme)
        if pieces |> Array.forall (fun (_, spelled) -> spelled.IsNone) then Unchanged
        else
            let builder = System.Text.StringBuilder ()
            pieces
            |> Array.iteri (fun index (lexeme, spelled) ->
                let text = defaultArg spelled lexeme.Text.Text
                if index = 0 then builder.Append (' ', lexeme.Span.From) |> ignore
                else
                    let previousEnd = (fst pieces.[index - 1]).Span.NearTo
                    let gap = lexeme.Span.From - previousEnd
                    let previousText = match snd pieces.[index - 1] with Some t -> t | None -> (fst pieces.[index - 1]).Text.Text
                    let needsSpace = gap = 0 && (spelled.IsSome || (snd pieces.[index - 1]).IsSome) && fuses previousText text
                    match lexeme.Before with
                    | Embedded embedded -> builder.Append embedded.Text |> ignore
                    | Whitespace width -> builder.Append (' ', (if needsSpace then max 1 width else width)) |> ignore
                builder.Append text |> ignore)
            builder.Append tail.Text |> ignore
            let attempted = builder.ToString ()
            match lexLine lex_state_init attempted with
            | Code (_, relexed, _), _ when (relexed |> Array.map (fun l -> tokenIdentity l.Token)) = (lexemes |> Array.map (fun l -> tokenIdentity l.Token)) -> Converted attempted
            | _ -> Rejected attempted
    | _ -> Unchanged

let convert (target : Spelling) (source : Source<'phase>) =
    let results = source.SourceLines |> Array.map (fun line -> line, convertLine target line)
    let texts =
        results
        |> Array.map (fun (line, result) ->
            match result with
            | Converted text -> text
            | Unchanged | Rejected _ -> render line)
    let rejected = results |> Array.choose (fun (line, result) -> match result with Rejected text -> Some (line.Number, text) | _ -> None)
    let converted = results |> Array.filter (fun (_, result) -> match result with Converted _ -> true | _ -> false) |> Array.length
    texts, converted, rejected
