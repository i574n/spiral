#load "Lexed.fsx" "Parsed.fsx" "Spacing.fsx" "Check.fsx" "Convert.fsx" "Flatten.fsx" "Layout.fsx"

open System
open System.IO
open Lexed
open Parsed
open Spacing
open Check
open Convert
open Flatten
open Layout

type Entry =
    { Corpus : string
      Edition : Edition
      Path : string
      Rel : string }

let readEntries (inputs : string list) =
    inputs
    |> List.collect (fun input ->
        if input.EndsWith ".tsv" then
            File.ReadAllLines input
            |> Array.filter (fun row -> row.Length > 0)
            |> Array.map (fun row ->
                let cells = row.Split '\t'
                { Corpus = cells.[0]
                  Edition = (if cells.[1] = "2" then Edition2 else Edition3)
                  Path = cells.[2]
                  Rel = cells.[3] })
            |> List.ofArray
        else [ { Corpus = "files"; Edition = Edition3; Path = input; Rel = Path.GetFileName input } ])

let readText (entry : Entry) = File.ReadAllText(entry.Path).Replace ("\r\n", "\n")

type Tally() =
    let counts = Collections.Generic.SortedDictionary<string, int> (StringComparer.Ordinal)
    member _.Add (key : string) (amount : int) =
        counts.[key] <- (match counts.TryGetValue key with | true, current -> current + amount | _ -> amount)
    member _.Get (key : string) = match counts.TryGetValue key with | true, current -> current | _ -> 0
    member _.Rows = counts |> Seq.map (fun pair -> pair.Key, pair.Value) |> List.ofSeq

let printTally (title : string) (tally : Tally) =
    printfn "%s" title
    for key, value in tally.Rows do
        printfn "  %s\t%d" key value

let corpora (entries : Entry list) = entries |> List.map (fun entry -> entry.Corpus) |> List.distinct

let runCheck (entries : Entry list) (listing : TextWriter) =
    let tally = Tally ()
    for entry in entries do
        let source = lexText entry.Path entry.Edition (readText entry)
        tally.Add (entry.Corpus + "\tlines") source.SourceLines.Length
        for overflow in overflows source do
            let name = constructName overflow.Construct
            tally.Add (entry.Corpus + "\tover120") 1
            tally.Add (entry.Corpus + "\tover120\t" + name) 1
            listing.WriteLine (sprintf "%s:%d\t%d\t%s" entry.Rel overflow.Line overflow.Width name)
    printTally "check" tally
    tally

let changeName change =
    match change with
    | TrailingWhitespace -> "trailing-whitespace"
    | GuardKept -> "guard-kept"
    | Respaced reason -> sprintf "%A" reason

let tokenStream (source : Source<'phase>) =
    source.SourceLines
    |> Array.collect (fun line ->
        match line.Shape with
        | Code (_, lexemes, _) -> tokenKinds lexemes |> Array.map (fun (kind, text) -> kind + " " + text)
        | Opaque (text, _) -> [| "opaque " + text.Text.TrimEnd () |]
        | Remark _ | Blank -> [||])

let runSpace (entries : Entry list) (outDir : string option) (listing : TextWriter) (verifyParse : bool) =
    let tally = Tally ()
    for entry in entries do
        let text = readText entry
        let source = lexText entry.Path entry.Edition text
        let spaced, changes = respace source
        let output = joinLines (renderAll spaced)
        let changedLines = changes |> Array.filter (fun (_, lineChanges, _) -> not (List.isEmpty lineChanges))
        tally.Add (entry.Corpus + "\tfiles") 1
        tally.Add (entry.Corpus + "\tlines") source.SourceLines.Length
        tally.Add (entry.Corpus + "\tlines-changed") (changedLines |> Array.filter (fun (_, c, _) -> c <> [ GuardKept ]) |> Array.length)
        if output <> text then tally.Add (entry.Corpus + "\tfiles-changed") 1
        for number, lineChanges, guard in changedLines do
            for change in List.distinct lineChanges do
                tally.Add (entry.Corpus + "\trule\t" + changeName change) 1
            let names = lineChanges |> List.map changeName |> List.distinct |> String.concat ","
            listing.WriteLine (sprintf "%s:%d\t%s%s" entry.Rel number names (match guard with Some rejected -> "\t" + rejected | None -> ""))
        let again, _ = respace (lexText entry.Path entry.Edition output)
        if joinLines (renderAll again) <> output then
            tally.Add (entry.Corpus + "\tG1-not-idempotent") 1
            listing.WriteLine (sprintf "%s\tG1-not-idempotent" entry.Rel)
        if tokenStream source <> tokenStream spaced then
            tally.Add (entry.Corpus + "\tF6-token-drift") 1
            listing.WriteLine (sprintf "%s\tF6-token-drift" entry.Rel)
        if verifyParse && output <> text then
            match compareParses entry.Edition spaced.FileUnit text output with
            | SameParse -> tally.Add (entry.Corpus + "\tparse-same") 1
            | OriginalHasErrors -> tally.Add (entry.Corpus + "\tparse-original-has-errors") 1
            | ParseDiffers line ->
                tally.Add (entry.Corpus + "\tparse-differs") 1
                listing.WriteLine (sprintf "%s:%d\tparse-differs" entry.Rel line)
        match outDir with
        | Some dir ->
            let target = Path.Combine (dir, entry.Corpus, entry.Rel.Replace ('/', Path.DirectorySeparatorChar))
            Directory.CreateDirectory (Path.GetDirectoryName target) |> ignore
            File.WriteAllText (target, output)
        | None -> ()
    printTally "space" tally
    tally

let runConvert (entries : Entry list) (outDir : string option) (listing : TextWriter) (verifyParse : bool) =
    let tally = Tally ()
    for entry in entries do
        let text = readText entry
        let source = lexText entry.Path entry.Edition text
        let original = joinLines (renderAll source)
        let symbols, converted, rejected = convert Symbols source
        let symbolText = joinLines symbols
        let words, _, rejectedBack = convert Words (lexText entry.Path Edition3 symbolText)
        let roundTrip = joinLines words
        tally.Add (entry.Corpus + "\tfiles") 1
        tally.Add (entry.Corpus + "\tlines-converted") converted
        tally.Add (entry.Corpus + "\tlines-rejected") rejected.Length
        tally.Add (entry.Corpus + "\tlines-rejected-back") rejectedBack.Length
        for number, attempted in rejected do
            listing.WriteLine (sprintf "%s:%d\trejected\t%s" entry.Rel number attempted)
        if roundTrip = original then tally.Add (entry.Corpus + "\tround-trip-identical") 1
        else
            tally.Add (entry.Corpus + "\tround-trip-differs") 1
            listing.WriteLine (sprintf "%s\tround-trip-differs" entry.Rel)
        if verifyParse && converted > 0 then
            match compareParses entry.Edition source.FileUnit original symbolText with
            | SameParse -> tally.Add (entry.Corpus + "\tparse-same") 1
            | OriginalHasErrors -> tally.Add (entry.Corpus + "\tparse-original-has-errors") 1
            | ParseDiffers line ->
                tally.Add (entry.Corpus + "\tparse-differs") 1
                listing.WriteLine (sprintf "%s:%d\tparse-differs" entry.Rel line)
        match outDir with
        | Some dir ->
            let target = Path.Combine (dir, entry.Corpus, entry.Rel.Replace ('/', Path.DirectorySeparatorChar))
            Directory.CreateDirectory (Path.GetDirectoryName target) |> ignore
            File.WriteAllText (target, symbolText)
        | None -> ()
    printTally "convert" tally
    tally

let runFlatten (entries : Entry list) (outDir : string option) (listing : TextWriter) =
    let tally = Tally ()
    for entry in entries do
        let text = readText entry
        let source = lexText entry.Path entry.Edition text
        let lines, blocks = flatten source
        let flatText = joinLines (Array.ofList lines)
        tally.Add (entry.Corpus + "\tfiles") 1
        tally.Add (entry.Corpus + "\tlines-in") source.SourceLines.Length
        tally.Add (entry.Corpus + "\tlines-out") lines.Length
        for block in blocks do
            match block with
            | Flattened _ -> tally.Add (entry.Corpus + "\tblocks-flattened") 1
            | Refused (reason, line, _) ->
                tally.Add (entry.Corpus + "\tblocks-refused\t" + (sprintf "%A" reason)) 1
                listing.WriteLine (sprintf "%s:%d\trefused\t%A" entry.Rel line reason)
        let relexed = lexText entry.Path entry.Edition flatText
        let opaque = relexed.SourceLines |> Array.filter (fun line -> match line.Shape with Opaque _ -> true | _ -> false) |> Array.length
        let opaqueBefore = source.SourceLines |> Array.filter (fun line -> match line.Shape with Opaque _ -> true | _ -> false) |> Array.length
        if opaque > opaqueBefore then
            tally.Add (entry.Corpus + "\tG7-1-lex-errors") 1
            listing.WriteLine (sprintf "%s\tG7-1-lex-errors\t%d" entry.Rel (opaque - opaqueBefore))
        match compareParses entry.Edition source.FileUnit text flatText with
        | SameParse -> tally.Add (entry.Corpus + "\tG7-parse-same") 1
        | OriginalHasErrors -> tally.Add (entry.Corpus + "\tG7-original-has-errors") 1
        | ParseDiffers line ->
            tally.Add (entry.Corpus + "\tG7-parse-differs") 1
            listing.WriteLine (sprintf "%s:%d\tG7-parse-differs" entry.Rel line)
        match outDir with
        | Some dir ->
            let target = Path.Combine (dir, entry.Corpus, entry.Rel.Replace ('/', Path.DirectorySeparatorChar))
            Directory.CreateDirectory (Path.GetDirectoryName target) |> ignore
            File.WriteAllText (target, flatText)
        | None -> ()
    printTally "flatten" tally
    tally

let formatText (path : string) (edition : Edition) (text : string) =
    let prespaced = let spaced, _ = respace (lexText path edition (joinMacroContinuations text)) in joinLines (renderAll spaced)
    let laid = joinLines (Array.ofList (layout (lexText path edition prespaced)))
    let spaced, _ = respace (lexText path edition laid)
    joinLines (renderAll spaced)

let commentWords (source : Source<'phase>) =
    let words (text : string) =
        text.Replace("(*", " ").Replace("*)", " ").Split ([| ' '; '\t' |], StringSplitOptions.RemoveEmptyEntries)
        |> Array.map (fun word -> word.TrimStart '/')
        |> Array.filter (fun word -> word.Length > 0 && word <> "!" && word <> "-" && word <> ">")
    source.SourceLines
    |> Array.collect (fun line ->
        match line.Shape with
        | Remark text -> words text.Text
        | Opaque (text, (InComment | Unlexable)) -> words text.Text
        | Opaque (_, (InString | InMacro)) -> [||]
        | Code (_, lexemes, tail) ->
            let embedded = lexemes |> Array.collect (fun lexeme -> match lexeme.Before with Embedded gap -> words gap.Text | Whitespace _ -> [||])
            Array.append embedded (words tail.Text)
        | Blank -> [||])

let runFormat (entries : Entry list) (outDir : string option) (listing : TextWriter) =
    let tally = Tally ()
    for entry in entries do
        let text = readText entry
        let original = joinLines (renderAll (lexText entry.Path entry.Edition text))
        let guardedBefore = layoutTally.GuardedBlocks
        let blocksBefore = layoutTally.VerbatimBlocks
        let linesBefore = layoutTally.VerbatimLines
        let keptBefore = layoutTally.Kept.Count
        let formatted = formatText entry.Path entry.Edition text
        for index in keptBefore .. layoutTally.Kept.Count - 1 do
            let reason, head = layoutTally.Kept.[index]
            listing.WriteLine (sprintf "%s\tkept-verbatim\t%s\t%s" entry.Rel reason (head.Trim ()))
        tally.Add (entry.Corpus + "\tverbatim-comment-blocks") (layoutTally.VerbatimBlocks - blocksBefore)
        tally.Add (entry.Corpus + "\tverbatim-parse-guard-blocks") (layoutTally.GuardedBlocks - guardedBefore)
        tally.Add (entry.Corpus + "\tverbatim-comment-block-lines") (layoutTally.VerbatimLines - linesBefore)
        let originalLines = splitLines original |> Array.filter (fun line -> line.Trim().Length > 0)
        let formattedLines = splitLines formatted |> Array.filter (fun line -> line.Trim().Length > 0)
        let originalSet = System.Collections.Generic.HashSet<string> (originalLines |> Array.map (fun l -> l.TrimEnd ()))
        let kept = formattedLines |> Array.filter (fun line -> originalSet.Contains line) |> Array.length
        tally.Add (entry.Corpus + "\tfiles") 1
        tally.Add (entry.Corpus + "\tlines-in-nonblank") originalLines.Length
        tally.Add (entry.Corpus + "\tlines-out-nonblank") formattedLines.Length
        tally.Add (entry.Corpus + "\tlines-out-found-in-input") kept
        tally.Add (entry.Corpus + "\tover120-out") (formattedLines |> Array.filter (fun l -> l.Length > 120) |> Array.length)
        let formattedSource = lexText entry.Path entry.Edition formatted
        let inputSource = lexText entry.Path entry.Edition text
        let layoutOverflows (source : Source<'p>) =
            overflows source |> Array.filter (fun overflow -> match overflow.Construct with LiteralTooWide _ | CommentTail | OpaqueText -> false | _ -> true)
        tally.Add (entry.Corpus + "\tover120-layout-in") (layoutOverflows inputSource).Length
        tally.Add (entry.Corpus + "\tover120-layout-out") (layoutOverflows formattedSource).Length
        let inputTrimmed = System.Collections.Generic.HashSet<string> (originalLines |> Array.map (fun l -> l.Trim ()))
        let created = layoutOverflows formattedSource |> Array.filter (fun overflow -> not (inputTrimmed.Contains ((splitLines formatted).[overflow.Line - 1].Trim ())))
        tally.Add (entry.Corpus + "\tover120-layout-created") created.Length
        for overflow in created do listing.WriteLine (sprintf "%s:%d\tover120-created\t%s" entry.Rel overflow.Line (constructName overflow.Construct))
        let before = commentWords inputSource |> Array.sort
        let after = commentWords formattedSource |> Array.sort
        if before <> after then
            tally.Add (entry.Corpus + "\tcomments-differ") 1
            listing.WriteLine (sprintf "%s\tcomments-differ\t%d\t%d" entry.Rel before.Length after.Length)
        else tally.Add (entry.Corpus + "\tcomments-same") 1
        if formatted = original then tally.Add (entry.Corpus + "\tfiles-unchanged") 1
        let again = formatText entry.Path entry.Edition formatted
        if again <> formatted then
            tally.Add (entry.Corpus + "\tG1-not-idempotent") 1
            listing.WriteLine (sprintf "%s\tG1-not-idempotent" entry.Rel)
        let flatText = let lines, _ = flatten (lexText entry.Path entry.Edition (joinMacroContinuations text)) in joinLines (Array.ofList lines)
        if formatText entry.Path entry.Edition flatText <> formatted then
            tally.Add (entry.Corpus + "\tG7-2-format-of-flat-differs") 1
            listing.WriteLine (sprintf "%s\tG7-2-format-of-flat-differs" entry.Rel)
        else tally.Add (entry.Corpus + "\tG7-2-same") 1
        match compareParses entry.Edition (lexText entry.Path entry.Edition text).FileUnit text formatted with
        | SameParse -> tally.Add (entry.Corpus + "\tparse-same") 1
        | OriginalHasErrors -> tally.Add (entry.Corpus + "\tparse-original-has-errors") 1
        | ParseDiffers line ->
            tally.Add (entry.Corpus + "\tparse-differs") 1
            listing.WriteLine (sprintf "%s:%d\tparse-differs" entry.Rel line)
        match outDir with
        | Some dir ->
            let target = Path.Combine (dir, entry.Corpus, entry.Rel.Replace ('/', Path.DirectorySeparatorChar))
            Directory.CreateDirectory (Path.GetDirectoryName target) |> ignore
            File.WriteAllText (target, formatted)
        | None -> ()
    printTally "format" tally
    tally

let arguments = fsi.CommandLineArgs |> Array.skip 1 |> List.ofArray

let option name (args : string list) =
    let rec find rest =
        match rest with
        | key :: value :: _ when key = name -> Some value
        | _ :: tail -> find tail
        | [] -> None
    find args

let positional (args : string list) =
    let rec collect (rest : string list) =
        match rest with
        | key :: _ :: tail when key.StartsWith "--" && key <> "--no-parse" && key <> "--split-literals" -> collect tail
        | key :: tail when key = "--no-parse" || key = "--split-literals" -> collect tail
        | value :: tail -> value :: collect tail
        | [] -> []
    collect args

let withListing (path : string option) (action : TextWriter -> 'result) =
    match path with
    | Some file ->
        use writer = new StreamWriter (file, false, Text.UTF8Encoding false)
        writer.NewLine <- "\n"
        action writer
    | None -> action TextWriter.Null

match arguments with
| "check" :: rest ->
    let tally = withListing (option "--list" rest) (runCheck (readEntries (positional rest)))
    exit (if corpora (readEntries (positional rest)) |> List.exists (fun corpus -> tally.Get (corpus + "\tover120") > 0) then 1 else 0)
| "space" :: rest ->
    withListing (option "--list" rest) (fun writer -> runSpace (readEntries (positional rest)) (option "--out" rest) writer (not (List.contains "--no-parse" rest))) |> ignore
| "convert" :: rest ->
    withListing (option "--list" rest) (fun writer -> runConvert (readEntries (positional rest)) (option "--out" rest) writer (not (List.contains "--no-parse" rest))) |> ignore
| "flatten" :: rest ->
    withListing (option "--list" rest) (fun writer -> runFlatten (readEntries (positional rest)) (option "--out" rest) writer) |> ignore
| "format" :: rest ->
    literalSplitting.Enabled <- List.contains "--split-literals" rest
    withListing (option "--list" rest) (fun writer -> runFormat (readEntries (positional rest)) (option "--out" rest) writer) |> ignore
| _ ->
    eprintfn "usage: Format.fsx check|space|convert|flatten|format [--list file] [--out dir] [--no-parse] <corpus.tsv|file.spi>..."
    exit 2
