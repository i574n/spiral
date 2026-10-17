#load "Lexed.fsx"

open Spiral.spiral_compiler
open Lexed

let lineLimit = 120

type LiteralKind =
    | PlainString
    | Macro
    | RawString
    | Character

type Construct =
    | LiteralTooWide of LiteralKind * width : int
    | CommentTail
    | OpaqueText
    | DefinitionHead
    | Binding
    | Pipeline
    | MatchArm
    | IfThenElse
    | Record
    | UnionCase
    | TypeDefinition
    | Application

type Overflow =
    { Line : int
      Width : int
      Construct : Construct }

let constructName construct =
    match construct with
    | LiteralTooWide (PlainString, _) -> "literal-string"
    | LiteralTooWide (Macro, _) -> "literal-macro"
    | LiteralTooWide (RawString, _) -> "literal-raw"
    | LiteralTooWide (Character, _) -> "literal-char"
    | CommentTail -> "comment"
    | OpaqueText -> "opaque"
    | DefinitionHead -> "head"
    | Binding -> "binding"
    | Pipeline -> "pipeline"
    | MatchArm -> "arm"
    | IfThenElse -> "if"
    | Record -> "record"
    | UnionCase -> "union-case"
    | TypeDefinition -> "type"
    | Application -> "application"

let literalSpans (lexemes : Lexeme[]) =
    let spans = ResizeArray ()
    let mutable opened = None
    for lexeme in lexemes do
        match lexeme.Token, opened with
        | TokMacroOpen, None -> opened <- Some (Macro, lexeme.Span.From)
        | TokStringOpen, None -> opened <- Some (PlainString, lexeme.Span.From)
        | TokMacroClose, Some (Macro, from) ->
            spans.Add (Macro, lexeme.Span.NearTo - from)
            opened <- None
        | TokStringClose, Some (PlainString, from) ->
            spans.Add (PlainString, lexeme.Span.NearTo - from)
            opened <- None
        | TokValue (LitString _), None -> spans.Add (RawString, lexeme.Span.NearTo - lexeme.Span.From)
        | TokValue (LitChar _), None -> spans.Add (Character, lexeme.Span.NearTo - lexeme.Span.From)
        | _ -> ()
    List.ofSeq spans

let topLevelOperators (lexemes : Lexeme[]) =
    let mutable depth = 0
    [ for lexeme in lexemes do
          match lexeme.Token with
          | _ when lexeme.InsideMacro -> ()
          | TokParenthesis (_, Open) -> depth <- depth + 1
          | TokParenthesis (_, Close) -> depth <- depth - 1
          | TokOperator (name, _) when depth = 0 -> yield name, lexeme
          | TokKeyword keyword when depth = 0 -> yield sprintf "%A" keyword, lexeme
          | _ -> () ]

let classify (indent : int) (lexemes : Lexeme[]) =
    let room = lineLimit - indent - 4
    let codeEnd = lexemes.[lexemes.Length - 1].Span.NearTo
    match literalSpans lexemes |> List.tryFind (fun (_, width) -> width > room) with
    | Some (kind, width) -> LiteralTooWide (kind, width)
    | None when codeEnd <= lineLimit -> CommentTail
    | None ->
        let operators = topLevelOperators lexemes
        let has name = operators |> List.exists (fun (found, _) -> found = name)
        match lexemes.[0].Token with
        | TokKeyword (SpecInl | SpecLet | SpecAnd) ->
            match operators |> List.tryFind (fun (name, _) -> name = "=") with
            | Some (_, equals) when equals.Span.NearTo < codeEnd && equals.Span.NearTo <= lineLimit -> Binding
            | _ -> DefinitionHead
        | TokKeyword (SpecType | SpecNominal | SpecUnion | SpecPrototype | SpecInstance) -> TypeDefinition
        | TokOperator ("|", _) -> if has "=>" then MatchArm else UnionCase
        | TokKeyword (SpecIf | SpecElif | SpecThen | SpecElse) -> IfThenElse
        | _ when has "SpecIf" -> IfThenElse
        | _ when has "|>" || has "||>" || has "|||>" -> Pipeline
        | TokParenthesis (Curly, Open) -> Record
        | _ -> Application

let overflows (source : Source<'phase>) =
    source.SourceLines
    |> Array.choose (fun line ->
        let text = render line
        if displayWidth text <= lineLimit then None
        else
            let construct =
                match line.Shape with
                | Code (indent, lexemes, _) -> classify indent lexemes
                | Remark _ -> CommentTail
                | Opaque _ | Blank -> OpaqueText
            Some { Line = line.Number; Width = displayWidth text; Construct = construct })
