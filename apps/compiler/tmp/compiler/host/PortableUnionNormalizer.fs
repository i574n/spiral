namespace Polyglot

open System
open System.Collections.Generic
open System.Text.RegularExpressions

module PortableUnionNormalizer =
    let private portableTypePattern =
        "(?:int8_t|int16_t|int32_t|int64_t|uint8_t|uint16_t|uint32_t|uint64_t|float|double|bool|char|String\\s*\\*|Array[0-9]+\\s*\\*|(?:Heap|Mut)[0-9]+\\s*\\*)"

    let private portableAnyTypePattern =
        $"(?:{portableTypePattern}|US[0-9]+|Tuple[0-9]+|ClosureValue[0-9]+|OptionalRecursive[0-9]+|WeakRecursive[0-9]+|Recursive[0-9]+)"

    let private unionPattern =
        Regex("typedef struct \\{\\s*int tag;\\s*union \\{(?<cases>.*?)\\};\\s*\\}\\s*(?<name>US[0-9]+);", RegexOptions.Singleline ||| RegexOptions.CultureInvariant)

    type private Constructor = { Tag : int; Types : string list }
    type private Payload = { Tag : int; Index : int; Type : string; Synthetic : bool }

    let private findMatchingDelimiter (text : string) openIndex openCharacter closeCharacter =
        let mutable depth = 0
        let mutable index = openIndex
        let mutable result = -1
        let mutable quote = '\000'
        let mutable escaped = false
        let mutable lineComment = false
        let mutable blockComment = false
        while index < text.Length && result < 0 do
            let current = text.[index]
            let next = if index + 1 < text.Length then text.[index + 1] else '\000'
            if lineComment then
                if current = '\n' then lineComment <- false
            elif blockComment then
                if current = '*' && next = '/' then
                    blockComment <- false
                    index <- index + 1
            elif quote <> '\000' then
                if escaped then escaped <- false
                elif current = '\\' then escaped <- true
                elif current = quote then quote <- '\000'
            elif current = '/' && next = '/' then
                lineComment <- true
                index <- index + 1
            elif current = '/' && next = '*' then
                blockComment <- true
                index <- index + 1
            elif current = '"' || current = '\'' then quote <- current
            elif current = openCharacter then depth <- depth + 1
            elif current = closeCharacter then
                depth <- depth - 1
                if depth = 0 then result <- index
            index <- index + 1
        if result < 0 then failwith $"portable backend found an unterminated {openCharacter}{closeCharacter} block"
        result

    let private rewriteDenseUnionSwitches (generated : string) =
        let mutable text = generated
        let mutable searchFrom = 0
        let mutable keepSearching = true
        while keepSearching do
            let switchIndex = text.IndexOf("switch (", searchFrom, StringComparison.Ordinal)
            if switchIndex < 0 then
                keepSearching <- false
            else
                let parenOpen = text.IndexOf('(', switchIndex)
                let parenClose = findMatchingDelimiter text parenOpen '(' ')'
                let braceOpen = text.IndexOf('{', parenClose)
                if braceOpen < 0 then failwith "portable backend found a switch without a body"
                let braceClose = findMatchingDelimiter text braceOpen '{' '}'
                let discriminator = text.Substring(parenOpen + 1, parenClose - parenOpen - 1).Trim()
                let body = text.Substring(braceOpen + 1, braceClose - braceOpen - 1)
                let cases = ResizeArray<int * string>()
                let mutable bodyIndex = 0
                while bodyIndex < body.Length do
                    let matched = Regex.Match(body.Substring(bodyIndex), "case\\s+(?<index>[0-9]+)\\s*:\\s*\\{")
                    if not matched.Success then
                        bodyIndex <- body.Length
                    else
                        let caseOpen = bodyIndex + matched.Index + matched.Length - 1
                        let caseClose = findMatchingDelimiter body caseOpen '{' '}'
                        let caseBody = body.Substring(caseOpen + 1, caseClose - caseOpen - 1)
                        let withoutBreak = Regex.Replace(caseBody, "\\s*break;\\s*$", "", RegexOptions.Singleline).TrimEnd()
                        let withoutComment = Regex.Replace(withoutBreak, "^\\s*//[^\\n]*(?:\\n|$)", "", RegexOptions.Singleline)
                        cases.Add(Int32.Parse(matched.Groups.["index"].Value), withoutComment)
                        bodyIndex <- caseClose + 1
                let defaultBody =
                    let matched = Regex.Match(body, "default\\s*:\\s*\\{")
                    if not matched.Success then None
                    else
                        let defaultOpen = matched.Index + matched.Length - 1
                        let defaultClose = findMatchingDelimiter body defaultOpen '{' '}'
                        let raw = body.Substring(defaultOpen + 1, defaultClose - defaultOpen - 1)
                        let withoutBreak = Regex.Replace(raw, "\\s*break;\\s*$", "", RegexOptions.Singleline).TrimEnd()
                        Some(Regex.Replace(withoutBreak, "^\\s*//[^\\n]*(?:\\n|$)", "", RegexOptions.Singleline))
                if cases.Count = 0 then
                    if String.IsNullOrWhiteSpace body then
                        text <- text.Substring(0, switchIndex) + text.Substring(braceClose + 1)
                        searchFrom <- switchIndex
                    else
                        searchFrom <- braceClose + 1
                else
                    let ordered = cases |> Seq.toList
                    let rec render remaining =
                        match remaining with
                        | [] -> defaultBody |> Option.defaultWith (fun () -> failwith "portable backend union switch had no terminal branch")
                        | [(tag, lastBody)] when defaultBody.IsNone ->
                            $"if ({discriminator} == {tag}) {{\n{lastBody}\n    }} else {{\n        abort();\n    }}"
                        | (tag, caseBody) :: tail ->
                            let inner = render tail
                            $"if ({discriminator} == {tag}) {{\n{caseBody}\n    }} else {{\n{inner}\n    }}"
                    let replacement = render ordered
                    text <- text.Substring(0, switchIndex) + replacement + text.Substring(braceClose + 1)
                    searchFrom <- switchIndex
        text

    // Generated names are reused between functions; a file-wide v0 -> union map
    // can rewrite an unrelated union's payload in another function.
    let private mapFunctions transform (generated : string) =
        let starts = Regex(@"(?m)^(?:static inline )?[A-Za-z_][^\r\n;{}]*\([^;\r\n{}]*\)\s*\{")
        let mutable text = generated
        for matched in starts.Matches(generated) |> Seq.cast<Match> |> Seq.toArray |> Array.rev do
            let braceOpen = matched.Index + matched.Length - 1
            let braceClose = findMatchingDelimiter generated braceOpen '{' '}'
            let body = generated.Substring(matched.Index, braceClose - matched.Index + 1)
            text <- text.Remove(matched.Index, body.Length).Insert(matched.Index, transform body)
        text

    let private normalizeOneDenseUnion (generated : string) =
        let unionMatch = unionPattern.Match generated
        if not unionMatch.Success then generated
        else
            let unionName = unionMatch.Groups.["name"].Value
            let payloadCasePattern = Regex("struct \\{(?<fields>.*?)\\}\\s+case(?<index>[0-9]+);", RegexOptions.Singleline ||| RegexOptions.CultureInvariant)
            let payloadFieldPattern = Regex($"(?<type>{portableAnyTypePattern})\\s+v(?<index>[0-9]+);", RegexOptions.Singleline ||| RegexOptions.CultureInvariant)
            let payloadTypes = Dictionary<int,string list>()
            for caseMatch in payloadCasePattern.Matches(unionMatch.Groups.["cases"].Value) |> Seq.cast<Match> do
                let fields =
                    payloadFieldPattern.Matches(caseMatch.Groups.["fields"].Value)
                    |> Seq.cast<Match>
                    |> Seq.map (fun fieldMatch -> Int32.Parse(fieldMatch.Groups.["index"].Value), fieldMatch.Groups.["type"].Value)
                    |> Seq.sortBy fst
                    |> Seq.toList
                let tag = Int32.Parse(caseMatch.Groups.["index"].Value)
                if fields |> List.map fst <> [0 .. fields.Length - 1] then
                    failwith $"portable backend requires dense union payload fields at tag {tag}"
                payloadTypes.[tag] <- fields |> List.map snd

            let constructorPattern = Regex($"(?m)^{Regex.Escape unionName}\\s+{Regex.Escape unionName}_(?<index>[0-9]+)\\((?<parameters>[^)]*)\\)\\s*\\{{")
            let constructors =
                constructorPattern.Matches generated
                |> Seq.cast<Match>
                |> Seq.map (fun matched ->
                    let tag = Int32.Parse(matched.Groups.["index"].Value)
                    let parameters = matched.Groups.["parameters"].Value.Trim()
                    let types =
                        if String.IsNullOrWhiteSpace parameters then []
                        else
                            parameters.Split(',', StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
                            |> Array.mapi (fun parameterIndex parameter ->
                                let parameterMatch = Regex.Match(parameter, $"^(?<type>{portableAnyTypePattern})\\s+v(?<index>[0-9]+)$")
                                if not parameterMatch.Success then failwith $"portable backend found an unsupported union payload parameter: {parameter}"
                                let actualIndex = Int32.Parse(parameterMatch.Groups.["index"].Value)
                                if actualIndex <> parameterIndex then failwith $"portable backend requires dense union constructor payload fields: {parameters}"
                                parameterMatch.Groups.["type"].Value)
                            |> Array.toList
                    { Tag = tag; Types = types })
                |> Seq.sortBy (fun item -> item.Tag)
                |> Seq.toList

            if constructors.Length < 1 || constructors.Length > 8 then
                failwith "portable backend supports dense scalar unions with 1..8 cases"
            if constructors |> List.map (fun item -> item.Tag) <> [0 .. constructors.Length - 1] then
                failwith "portable backend requires dense scalar union tags starting at zero"
            for constructor in constructors do
                match payloadTypes.TryGetValue constructor.Tag with
                | true, actual when actual = constructor.Types -> ()
                | true, actual -> failwith $"portable backend union payload mismatch at tag {constructor.Tag}: {constructor.Types} versus {actual}"
                | false, _ when constructor.Types.IsEmpty -> ()
                | false, _ -> failwith $"portable backend union payload metadata missing at tag {constructor.Tag}"

            let tupleName = "Tuple9" + unionName.Substring(2).PadLeft(3, '0')
            if generated.Contains(tupleName, StringComparison.Ordinal) then failwith $"portable backend tuple collision: {tupleName}"
            let tupleConstructor = tupleName.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
            let payloads =
                constructors
                |> List.collect (fun constructor ->
                    if constructor.Types.IsEmpty then
                        [{ Tag = constructor.Tag; Index = 0; Type = "int32_t"; Synthetic = true }]
                    else
                        constructor.Types
                        |> List.mapi (fun index payloadType -> { Tag = constructor.Tag; Index = index; Type = payloadType; Synthetic = false }))
            let fieldForTag = Dictionary<string,int>(StringComparer.Ordinal)
            payloads |> List.iteri (fun position payload -> fieldForTag.[$"{payload.Tag}:{payload.Index}"] <- position + 1)

            let rec defaultValue payloadType =
                if payloadType = "bool" then "false"
                elif payloadType = "float" then "0.0f"
                elif payloadType = "double" then "0.0"
                elif Regex.IsMatch(payloadType, "^String\\s*\\*$") then "StringLit(0, \"\")"
                else
                    let arrayMatch = Regex.Match(payloadType, "^Array(?<id>[0-9]+)\\s*\\*$")
                    if arrayMatch.Success then
                        let arrayId = arrayMatch.Groups.["id"].Value
                        $"ArrayCreate{arrayId}(0, false)"
                    elif Regex.IsMatch(payloadType, "^Tuple[0-9]+$") then
                        let constructor = payloadType.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
                        let signature = Regex.Match(generated, $"static inline {Regex.Escape payloadType} {Regex.Escape constructor}\\((?<parameters>[^)]*)\\)")
                        if not signature.Success then failwith $"portable backend could not resolve normalized tuple default: {payloadType}"
                        let defaults =
                            signature.Groups.["parameters"].Value.Split(',', StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
                            |> Array.map (fun parameter ->
                                let parameterMatch = Regex.Match(parameter, $"^(?<type>{portableAnyTypePattern})\\s+v[0-9]+$")
                                if not parameterMatch.Success then failwith $"portable backend found an unsupported normalized tuple parameter: {parameter}"
                                defaultValue parameterMatch.Groups.["type"].Value)
                            |> String.concat ", "
                        $"{constructor}({defaults})"
                    else "0"

            let tupleFields =
                payloads |> List.mapi (fun position payload -> $"    {payload.Type} v{position + 1};") |> String.concat "\n"
            let tupleParameters =
                payloads |> List.mapi (fun position payload -> $"{payload.Type} v{position + 1}") |> String.concat ", "
            let tupleAssignments =
                payloads |> List.mapi (fun position _ -> $"x.v{position + 1} = v{position + 1};") |> String.concat " "
            let signature = if payloads.IsEmpty then "int32_t v0" else $"int32_t v0, {tupleParameters}"
            let tuplePrelude =
                $"typedef struct {{\n    int32_t v0;\n{tupleFields}\n}} {tupleName};\nstatic inline {tupleName} {tupleConstructor}({signature}){{\n    {tupleName} x;\n    x.v0 = v0; {tupleAssignments}\n    return x;\n}}"

            let mutable normalized = generated
            let unionId = unionName.Substring(2)
            normalized <- mapFunctions (fun body ->
                if Regex.IsMatch(body, $"^(?:static inline )?void US(?:Incref|Decref)(?:Body)?{unionId}\\(") then "" else body) normalized
            let constructorDefinitionPattern = Regex($"^{Regex.Escape unionName}\\s+{Regex.Escape unionName}_[0-9]+\\([^)]*\\)\\s*\\{{.*?^\\}}\\s*", RegexOptions.Singleline ||| RegexOptions.Multiline)
            normalized <- constructorDefinitionPattern.Replace(normalized, "")

            let emittedConstructorTags =
                Regex.Matches(generated, $"\\b{Regex.Escape unionName}_(?<tag>[0-9]+)\\s*\\(")
                |> Seq.cast<Match>
                |> Seq.map (fun matched -> Int32.Parse matched.Groups.["tag"].Value)
                |> Seq.distinct
                |> Seq.toList
            let resolveConstructor emittedTag =
                match constructors |> List.tryFind (fun constructor -> constructor.Tag = emittedTag) with
                | Some constructor -> constructor
                | None when constructors.Length = 1 -> constructors.Head
                | None -> failwith $"portable backend could not resolve emitted union constructor {unionName}_{emittedTag}"
            for emittedTag in emittedConstructorTags do
                let constructor = resolveConstructor emittedTag
                let callPattern = Regex($"\\b{Regex.Escape unionName}_{emittedTag}\\s*\\(\\s*(?<values>[^()]*)\\s*\\)")
                normalized <- callPattern.Replace(normalized, MatchEvaluator(fun matched ->
                    let rawValues = matched.Groups.["values"].Value.Trim()
                    let activeValues =
                        if String.IsNullOrWhiteSpace rawValues then []
                        else rawValues.Split(',', StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries) |> Array.toList
                    if activeValues.Length <> constructor.Types.Length then
                        failwith $"portable backend union constructor payload count mismatch at tag {constructor.Tag}"
                    let arguments =
                        payloads
                        |> List.map (fun payload ->
                            if payload.Tag = constructor.Tag && not payload.Synthetic then activeValues.[payload.Index]
                            else defaultValue payload.Type)
                        |> fun values -> string constructor.Tag :: values
                    let joinedArguments = String.concat ", " arguments
                    $"{tupleConstructor}({joinedArguments})"))

            normalized <- unionPattern.Replace(normalized, tuplePrelude, 1)
            let unionReferencePattern = Regex($"(?m)(?<indent>[ \\t]*)US(?<operation>Incref|Decref){unionId}\\s*\\(&\\((?<variable>[A-Za-z_][A-Za-z0-9_]*)\\)\\);[ \\t]*")
            normalized <- unionReferencePattern.Replace(normalized, MatchEvaluator(fun matched ->
                let indent = matched.Groups.["indent"].Value
                let operation = matched.Groups.["operation"].Value
                let variable = matched.Groups.["variable"].Value
                payloads
                |> List.choose (fun payload ->
                    let arrayMatch = Regex.Match(payload.Type, "^Array(?<id>[0-9]+)\\s*\\*$")
                    if arrayMatch.Success then
                        let helper = if operation = "Incref" then "DynamicArrayClone" else "DynamicArrayDrop"
                        let arrayId = arrayMatch.Groups.["id"].Value
                        let fieldKey = $"{payload.Tag}:{payload.Index}"
                        let field = fieldForTag.[fieldKey]
                        Some $"{indent}if ({variable}.v0 == {payload.Tag}) {{\n{indent}    {helper}{arrayId}({variable}.v{field});\n{indent}}}"
                    elif Regex.IsMatch(payload.Type, "^String\\s*\\*$") then
                        if operation = "Incref" then failwith $"portable managed union string clone requires a tag-selected copy target: {unionName}"
                        let fieldKey = $"{payload.Tag}:{payload.Index}"
                        let field = fieldForTag.[fieldKey]
                        Some $"{indent}if ({variable}.v0 == {payload.Tag}) {{\n{indent}    PortableStringDrop({variable}.v{field});\n{indent}}}"
                    else None)
                |> String.concat Environment.NewLine))

            let rewriteFunction (body : string) =
              let unionVariables =
                Regex.Matches(body, $"\\b{Regex.Escape unionName}\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\b")
                |> Seq.cast<Match>
                |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                |> Set.ofSeq
              let actualTagForField emittedTag field =
                if fieldForTag.ContainsKey($"{emittedTag}:{field}") then emittedTag
                elif constructors.Length = 1 then constructors.Head.Tag
                else emittedTag
              let mutable body = Regex.Replace(body, "\\b(?<variable>[A-Za-z_][A-Za-z0-9_]*)\\.case(?<tag>[0-9]+)\\.v(?<field>[0-9]+)", MatchEvaluator(fun matched ->
                let variable = matched.Groups.["variable"].Value
                if not (Set.contains variable unionVariables) then matched.Value else
                let tagText = matched.Groups.["tag"].Value
                let fieldText = matched.Groups.["field"].Value
                let emittedTag = Int32.Parse tagText
                let field = Int32.Parse fieldText
                let key = $"{actualTagForField emittedTag field}:{field}"
                match fieldForTag.TryGetValue key with
                | true, field -> $"{variable}.v{field}"
                | false, _ -> failwith $"portable backend found payload access for empty union case {key}"))
              for variable in unionVariables do
                body <- Regex.Replace(body, $"\\b{Regex.Escape variable}\\.tag\\b", $"{variable}.v0")
                if constructors.Length = 1 then
                    let switchCasePattern = Regex($"(?ms)(switch \\({Regex.Escape variable}\\.v0\\) \\{{.*?case\\s+)[0-9]+(\\s*:)")
                    body <- switchCasePattern.Replace(body, MatchEvaluator(fun matched ->
                        matched.Groups.[1].Value + "0" + matched.Groups.[2].Value))
              body
            normalized <- mapFunctions rewriteFunction normalized
            normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape unionName}\\b", tupleName)
            let initializedDeclarationPattern = Regex($"^(?<indent>\\s*)(?<type>{portableAnyTypePattern})\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<expr>.+);\\s*$", RegexOptions.Multiline)
            initializedDeclarationPattern.Replace(normalized, MatchEvaluator(fun matched ->
                let indent = matched.Groups.["indent"].Value
                let valueType = matched.Groups.["type"].Value
                let name = matched.Groups.["name"].Value
                let expression = matched.Groups.["expr"].Value
                $"{indent}{valueType} {name};\n{indent}{name} = {expression};"))

    let normalizeAllDenseUnions (generated : string) =
        // Preserve the established lowering for an ordinary, single union.
        // This compatibility pass handles specialized GADTs and multiple unions.
        let unions = unionPattern.Matches generated
        let needsNormalization =
            unions.Count > 1 ||
            (unions.Count = 1 &&
             let name = unions.[0].Groups.["name"].Value
             Regex.Matches(generated, $"(?m)^{Regex.Escape name}\\s+{Regex.Escape name}_[0-9]+\\(").Count = 1)
        let mutable normalized = generated
        let mutable passes = 0
        while needsNormalization && unionPattern.IsMatch normalized do
            if passes >= 64 then failwith "portable backend exceeded the dense union normalization pass limit"
            let next = normalizeOneDenseUnion normalized
            if String.Equals(next, normalized, StringComparison.Ordinal) then failwith "portable backend dense union normalization made no progress"
            normalized <- next
            passes <- passes + 1
        if needsNormalization then normalized <- rewriteDenseUnionSwitches normalized
        let unsupportedIndex = if needsNormalization then normalized.IndexOf("switch (", StringComparison.Ordinal) else -1
        if unsupportedIndex >= 0 then
            let snippetLength = min 1200 (normalized.Length - unsupportedIndex)
            let snippet = normalized.Substring(unsupportedIndex, snippetLength)
            failwith $"portable backend found an unsupported union switch: {snippet}"
        normalized
