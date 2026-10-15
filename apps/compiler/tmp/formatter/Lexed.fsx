#r "dll/FSharpx.Collections.dll"
#r "dll/FSharp.Control.AsyncSeq.dll"
#r "dll/Hopac.Core.dll"
#r "dll/Hopac.dll"
#r "dll/SpiralCompilerCore.dll"

open Polyglot.spiral_compiler

[<AbstractClass; Sealed>]
type AsRead = class end

[<AbstractClass; Sealed>]
type Spaced = class end

[<AbstractClass; Sealed>]
type Flat = class end

[<AbstractClass; Sealed>]
type Laid = class end

[<Struct>]
type Span = { From : int; NearTo : int }

type Verbatim =
    private
    | Verbatim of string
    member this.Text = let (Verbatim text) = this in text
    member this.Length = this.Text.Length

type Gap =
    | Whitespace of int
    | Embedded of Verbatim

type Lexeme =
    { Span : Span
      Token : SpiralToken
      Text : Verbatim
      InsideMacro : bool
      Before : Gap }

type OpaqueCause =
    | InComment
    | InString
    | InMacro
    | Unlexable

type LineShape =
    | Blank
    | Code of indent : int * lexemes : Lexeme[] * tail : Verbatim
    | Opaque of Verbatim * OpaqueCause
    | Remark of Verbatim

type Line<'phase> = { Number : int; Shape : LineShape }

type Edition =
    | Edition2
    | Edition3

type Unit' =
    | TopDown
    | BottomUp

type Source<'phase> =
    private
        { Path : string
          Edition : Edition
          Unit : Unit'
          Lines : Line<'phase>[] }
    member this.FilePath = this.Path
    member this.FileEdition = this.Edition
    member this.FileUnit = this.Unit
    member this.SourceLines = this.Lines

type SourceUser<'result> =
    abstract Use<'phase> : Source<'phase> -> 'result

type AnySource =
    abstract Apply<'result> : SourceUser<'result> -> 'result

let seal (source : Source<'phase>) =
    { new AnySource with
        member _.Apply user = user.Use source }

let verbatimOf (text : string) (span : Span) = Verbatim (text.Substring (span.From, span.NearTo - span.From))

let verbatimTail (text : string) (from : int) = Verbatim (text.Substring from)

let trimmedTail (tail : Verbatim) = Verbatim (tail.Text.TrimEnd ())

let verbatimLine (text : string) = Verbatim text

let render (line : Line<'phase>) =
    match line.Shape with
    | Blank -> ""
    | Opaque (text, _) -> text.Text
    | Remark text -> text.Text
    | Code (indent, lexemes, tail) ->
        let builder = System.Text.StringBuilder ()
        builder.Append (' ', indent) |> ignore
        lexemes
        |> Array.iteri (fun index lexeme ->
            if index > 0 then
                match lexeme.Before with
                | Whitespace count -> builder.Append (' ', count) |> ignore
                | Embedded text -> builder.Append text.Text |> ignore
            builder.Append lexeme.Text.Text |> ignore)
        builder.Append(tail.Text).ToString ()

let displayWidth (text : string) =
    let wide (rune : int) =
        (rune >= 0x1100 && rune <= 0x115F) || (rune >= 0x2E80 && rune <= 0xA4CF) || (rune >= 0xAC00 && rune <= 0xD7A3)
        || (rune >= 0xF900 && rune <= 0xFAFF) || (rune >= 0xFE30 && rune <= 0xFE4F) || (rune >= 0xFF00 && rune <= 0xFF60)
        || (rune >= 0xFFE0 && rune <= 0xFFE6) || (rune >= 0x1F300 && rune <= 0x1FAFF) || (rune >= 0x20000 && rune <= 0x3FFFD)
    let elements = System.Globalization.StringInfo.GetTextElementEnumerator text
    let mutable width = 0
    while elements.MoveNext () do
        let element = elements.GetTextElement ()
        let rune = System.Char.ConvertToUtf32 (element, 0)
        width <- width + (if wide rune then 2 elif System.Globalization.CharUnicodeInfo.GetUnicodeCategory rune = System.Globalization.UnicodeCategory.NonSpacingMark then 0 else 1)
    width

let isMacroOpening token =
    match token with
    | TokMacroOpen -> true
    | _ -> false

let isMacroClosing token =
    match token with
    | TokMacroClose -> true
    | _ -> false

let lexLine (state : LexState) (text : string) =
    let tokens, errors, next = tokenize_line state text
    let startsPlain = state = lex_state_init
    let endsPlain = next = lex_state_init
    let shape =
        if text.Length = 0 && startsPlain && endsPlain then Blank
        elif not startsPlain || not endsPlain || not (List.isEmpty errors) then
            let cause =
                if 0 < state.comment_depth || 0 < next.comment_depth then InComment
                elif state.in_triple || next.in_triple then InString
                elif not (List.isEmpty errors) then Unlexable
                else InMacro
            Opaque (verbatimLine text, cause)
        elif tokens.Length = 0 then Remark (verbatimLine text)
        else
            let mutable depth = 0
            let mutable previous = 0
            let lexemes =
                [| for (range, token) in tokens do
                       if isMacroOpening token then depth <- depth + 1
                       let inside = depth > 0
                       if isMacroClosing token then depth <- depth - 1
                       let span = { From = range.from; NearTo = range.nearTo }
                       let between = text.Substring (previous, max 0 (range.from - previous))
                       let gap = if between.Trim().Length = 0 then Whitespace between.Length else Embedded (Verbatim between)
                       previous <- range.nearTo
                       yield { Span = span; Token = token; Text = verbatimOf text span; InsideMacro = inside; Before = gap } |]
            let last = lexemes.[lexemes.Length - 1].Span.NearTo
            Code (lexemes.[0].Span.From, lexemes, verbatimTail text last)
    shape, next

let splitLines (text : string) =
    let lines = text.Replace("\r\n", "\n").Split '\n'
    if lines.Length > 1 && lines.[lines.Length - 1] = "" then lines.[0 .. lines.Length - 2] else lines

let lexText (path : string) (edition : Edition) (text : string) : Source<AsRead> =
    let mutable state = lex_state_init
    let lines =
        splitLines text
        |> Array.mapi (fun index lineText ->
            let shape, next = lexLine state lineText
            state <- next
            { Number = index + 1; Shape = shape })
    { Path = path
      Edition = edition
      Unit = (if path.EndsWith ".spir" then BottomUp else TopDown)
      Lines = lines }

let relex (source : Source<'phase>) (texts : string[]) : Source<'next> =
    let mutable state = lex_state_init
    let lines =
        texts
        |> Array.mapi (fun index lineText ->
            let shape, next = lexLine state lineText
            state <- next
            { Number = index + 1; Shape = shape })
    { Path = source.Path
      Edition = source.Edition
      Unit = source.Unit
      Lines = lines }

let renderAll (source : Source<'phase>) = source.Lines |> Array.map render

let joinLines (lines : string[]) = String.concat "\n" lines + "\n"
