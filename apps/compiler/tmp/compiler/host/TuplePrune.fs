namespace Polyglot

open System.Text.RegularExpressions

module TuplePrune =
    let private helperBlock =
        Regex(
            @"(?ms)^\#\[derive\([^\]]+\)\]\s*\r?\nstruct\s+(?<type>Tuple[0-9]+)\s*\{.*?^\}\s*\r?\n\s*fn\s+(?<ctor>TupleCreate[0-9]+)\([^)]*\)\s*->\s*\k<type>\s*\{.*?^\}\s*\r?\n?",
            RegexOptions.CultureInvariant)

    let apply (code : string) =
        let mutable current = code
        let mutable keepPruning = true
        while keepPruning do
            let mutable removed = false
            let matches = helperBlock.Matches current |> Seq.cast<Match> |> Seq.toArray
            for matched in matches do
                if not removed then
                    let outside = current.Remove(matched.Index, matched.Length)
                    let tupleType = matched.Groups.["type"].Value
                    let constructor = matched.Groups.["ctor"].Value
                    let typeUsed = Regex.IsMatch(outside, @"\b" + Regex.Escape tupleType + @"\b")
                    let constructorUsed = Regex.IsMatch(outside, @"\b" + Regex.Escape constructor + @"\b")
                    if not typeUsed && not constructorUsed then
                        current <- outside
                        removed <- true
            keepPruning <- removed
        current
