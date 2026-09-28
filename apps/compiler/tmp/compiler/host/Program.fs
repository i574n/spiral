namespace Polyglot

open System
open System.IO
open System.Text
open System.Text.RegularExpressions
open System.Security.Cryptography
open System.Net.Sockets
open System.Collections.Generic
open Microsoft.FSharp.Reflection
open Hopac
open Hopac.Infixes
open Hopac.Stream
open Lib
open spiral_compiler

module Program =
    let private unionCase name =
        FSharpType.GetUnionCases(typeof<SupervisorReq>)
        |> Array.find (fun c -> c.Name = name)

    let private anonymousRecord (recordType : Type) (values : (string * obj) list) =
        let valueMap = Dictionary<string,obj>(StringComparer.OrdinalIgnoreCase)
        for key, value in values do valueMap.[key] <- value
        let fields = FSharpType.GetRecordFields recordType
        let args = fields |> Array.map (fun field -> valueMap.[field.Name])
        FSharpValue.MakeRecord(recordType, args)

    let private fileOpenRequest uri code =
        let case = unionCase "FileOpen"
        let payloadType = case.GetFields().[0].PropertyType
        let payload = anonymousRecord payloadType ["uri", box uri; "spiText", box code]
        FSharpValue.MakeUnion(case, [|payload|]) :?> SupervisorReq

    let private fileChangeRequest uri from nearTo lines =
        let case = unionCase "FileChange"
        let payloadType = case.GetFields().[0].PropertyType
        let spiEditType = FSharpType.GetRecordFields(payloadType) |> Array.find (fun field -> field.Name = "spiEdit") |> fun field -> field.PropertyType
        let spiEdit = anonymousRecord spiEditType ["from", box from; "nearTo", box nearTo; "lines", box lines]
        let payload = anonymousRecord payloadType ["uri", box uri; "spiEdit", spiEdit]
        FSharpValue.MakeUnion(case, [|payload|]) :?> SupervisorReq

    let private projectFileOpenRequest uri text =
        let case = unionCase "ProjectFileOpen"
        let payloadType = case.GetFields().[0].PropertyType
        let payload = anonymousRecord payloadType ["uri", box uri; "spiprojText", box text]
        FSharpValue.MakeUnion(case, [|payload|]) :?> SupervisorReq

    /// Experimental (SPIRAL_HOST_OPEN_PROJECT=1): like the editor, open the owning package.spiproj once per
    /// process before its files, so the core's attention loop may publish TypeErrors. Observed so far: it
    /// publishes PackageErrors for dependencies but not the file's TypeErrors before BuildFile fails.
    let private openedProjects = HashSet<string>(StringComparer.OrdinalIgnoreCase)
    let private openOwningProject (supervisor : Ch<SupervisorReq>) (inputPath : string) =
        let rec find (directory : DirectoryInfo) =
            if isNull directory then None
            else
                let candidate = Path.Combine(directory.FullName, "package.spiproj")
                if File.Exists candidate then Some candidate else find directory.Parent
        let enabled = String.Equals(Environment.GetEnvironmentVariable "SPIRAL_HOST_OPEN_PROJECT", "1", StringComparison.Ordinal)
        match (if enabled then find (Directory.GetParent inputPath) else None) with
        | Some spiproj when openedProjects.Add spiproj ->
            let uri = spiproj |> SpiralFileSystem.normalize_path |> SpiralFileSystem.new_file_uri
            Hopac.run (supervisor *<+ projectFileOpenRequest uri (File.ReadAllText spiproj))
        | _ -> ()

    let private buildFileRequest uri backend (result : IVar<string option>) =
        let case = unionCase "BuildFile"
        let payloadType = case.GetFields().[0].PropertyType
        let payload = anonymousRecord payloadType ["uri", box uri; "backend", box backend]
        FSharpValue.MakeUnion(case, [|payload; box result|]) :?> SupervisorReq

    let private declaredBinding (source : string) (binding : string) =
        source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        |> Array.exists (fun raw ->
            let line = raw.TrimStart()
            if not (line.StartsWith("let ", StringComparison.Ordinal)) then false
            else
                let rest = line.Substring(4)
                let stop = rest.IndexOfAny([|' '; '\t'; ':'; '='|])
                let name = if stop < 0 then rest else rest.Substring(0, stop)
                String.Equals(name, binding, StringComparison.Ordinal))

    let private validIdentifier (value : string) =
        if String.IsNullOrWhiteSpace value then false
        else
            let first = value.[0]
            (first = '_' || Char.IsAsciiLetter first)
            && value
               |> Seq.skip 1
               |> Seq.forall (fun ch -> ch = '_' || ch = '\'' || Char.IsAsciiLetterOrDigit ch)

    let private discoverEntryBinding (source : string) =
        let lines = source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let candidate =
            lines
            |> Array.rev
            |> Array.tryPick (fun raw ->
                let value = raw.Trim().TrimEnd(';').Trim()
                if String.IsNullOrWhiteSpace value || value.StartsWith("//") || value.StartsWith("#") then None
                else Some value)
        match candidate with
        | Some value when validIdentifier value && declaredBinding source value -> value
        | Some value -> failwith $"generated F# terminal expression is not a declared identifier: {value}"
        | None -> failwith "generated F# has no terminal expression"

    let private writeEntryManifest outputPath entryBinding generatedBytes revisionMode backend =
        // The receipt is an attestation sidecar. App builds do not read it, and the
        // EOIE cleaners delete it. Write it only when a caller asks.
        if String.Equals(Environment.GetEnvironmentVariable "SPIRAL_WRITE_ENTRY_MANIFEST", "1", StringComparison.Ordinal) then
            let manifestPath = outputPath + ".spiral-entry"
            let portable = String.Equals(backend, "Rust", StringComparison.Ordinal) || String.Equals(backend, "Delphi", StringComparison.Ordinal)
            let typedSource = String.Equals(revisionMode, "typed-source", StringComparison.Ordinal)
            let portableIr = if typedSource then "typed-layout-source-v1" elif portable then "expression-v3" else "native"
            let loweringSource = if typedSource then "Spiral" elif portable then "C" else backend
            let text =
                $"schema=2\nentry_binding={entryBinding}\nbackend={backend}\nserver_pid={Environment.ProcessId}\ngenerated_bytes={generatedBytes}\nrevision_mode={revisionMode}\nportable_ir={portableIr}\nlowering_source={loweringSource}\n"
            File.WriteAllText(manifestPath, text)

    type private PortableStatement =
        | PortableDeclare of cType : string * name : string
        | PortableAssign of name : string * expression : string
        | PortableReturn of expression : string
        | PortableIfStart of condition : string
        | PortableWhileStart of condition : string
        | PortableBreak
        | PortableContinue
        | PortableElse
        | PortableBlockEnd

    let private portableTypePattern = "(?:int8_t|int16_t|int32_t|int64_t|uint8_t|uint16_t|uint32_t|uint64_t|float|double|bool|String\\s*\\*)"
    let private portableAnyTypePattern = $"(?:{portableTypePattern}|Tuple[0-9]+)"

    let private normalizeCIntegerSuffixes (expression : string) =
        let withoutIntegerSuffixes = Regex.Replace(expression, "(?<=\\d)(?:ull|llu|ll|ul|lu|u|l)\\b", "", RegexOptions.IgnoreCase)
        Regex.Replace(withoutIntegerSuffixes, "(?<=\\d)f\\b", "", RegexOptions.IgnoreCase)

    let private parsePortableC (generated : string) =
        let statements = ResizeArray<PortableStatement>()
        let mutable inMain = false
        let mutable mainDepth = 0
        let mutable sawMain = false
        let mutable sawReturn = false
        let declaration = Regex($"^({portableTypePattern})\\s+([A-Za-z_][A-Za-z0-9_]*)\\s*;$")
        let assignment = Regex("^([A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(.+);$")
        let returning = Regex("^return\\s+(.+);$")
        let ifStart = Regex("^if\\s*\\((.+)\\)\\s*\\{$")
        let whileStart = Regex("^while\\s*\\((.+)\\)\\s*\\{$")
        for raw in generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None) do
            let line = raw.Trim()
            if String.IsNullOrWhiteSpace line || line.StartsWith("#include", StringComparison.Ordinal) then ()
            elif not inMain then
                if (line.StartsWith("int32_t main", StringComparison.Ordinal) || line.StartsWith("int main", StringComparison.Ordinal)) && line.EndsWith("{", StringComparison.Ordinal) then
                    inMain <- true
                    mainDepth <- 1
                    sawMain <- true
                else
                    failwith $"portable backend only supports scalar C main bodies; unsupported prelude: {line}"
            elif line = "} else {" then
                statements.Add PortableElse
            elif line = "}" then
                mainDepth <- mainDepth - 1
                if mainDepth = 0 then inMain <- false
                else statements.Add PortableBlockEnd
            elif line = "break;" then
                statements.Add PortableBreak
            elif line = "continue;" then
                statements.Add PortableContinue
            else
                let declarationMatch = declaration.Match line
                let assignmentMatch = assignment.Match line
                let returnMatch = returning.Match line
                let ifMatch = ifStart.Match line
                let whileMatch = whileStart.Match line
                if declarationMatch.Success then
                    statements.Add(PortableDeclare(declarationMatch.Groups.[1].Value, declarationMatch.Groups.[2].Value))
                elif returnMatch.Success then
                    statements.Add(PortableReturn(returnMatch.Groups.[1].Value))
                    sawReturn <- true
                elif assignmentMatch.Success then
                    statements.Add(PortableAssign(assignmentMatch.Groups.[1].Value, assignmentMatch.Groups.[2].Value))
                elif ifMatch.Success then
                    statements.Add(PortableIfStart(ifMatch.Groups.[1].Value))
                    mainDepth <- mainDepth + 1
                elif whileMatch.Success then
                    statements.Add(PortableWhileStart(whileMatch.Groups.[1].Value))
                    mainDepth <- mainDepth + 1
                else
                    failwith $"portable backend does not support this C statement yet: {line}"
        if not sawMain then
            let preview = if generated.Length <= 240 then generated else generated.Substring(0, 240)
            failwith $"portable backend could not find int32_t main() in C output; preview: {preview}"
        if inMain || mainDepth <> 0 then failwith "portable backend found an unterminated C main body"
        if not sawReturn then failwith "portable backend requires a return statement"
        statements |> Seq.toList

    let private rustType = function
        | "int8_t" -> "i8"
        | "int16_t" -> "i16"
        | "int32_t" -> "i32"
        | "int64_t" -> "i64"
        | "uint8_t" -> "u8"
        | "uint16_t" -> "u16"
        | "uint32_t" -> "u32"
        | "uint64_t" -> "u64"
        | "float" -> "f32"
        | "double" -> "f64"
        | "bool" -> "bool"
        | value when Regex.IsMatch(value, "^String\\s*\\*$") -> "&'static str"
        | value when Regex.IsMatch(value, "^Tuple[0-9]+$") -> value
        | value -> failwith $"portable Rust backend does not support C type: {value}"

    let private rustDefault = function
        | "bool" -> "false"
        | "f32" | "f64" -> "0.0"
        | _ -> "0"

    let private rustFromPortableC generated =
        let statements = parsePortableC generated
        let assignmentCounts = Dictionary<string,int>(StringComparer.Ordinal)
        for statement in statements do
            match statement with
            | PortableAssign(name, _) ->
                assignmentCounts.[name] <-
                    match assignmentCounts.TryGetValue name with
                    | true, count -> count + 1
                    | false, _ -> 1
            | _ -> ()
        let pendingDeclarations = Dictionary<string,string>(StringComparer.Ordinal)
        let output = StringBuilder()
        let mutable indentLevel = 1
        let emit text = output.AppendLine(String(' ', indentLevel * 4) + text) |> ignore
        let requireNoPending boundary =
            if pendingDeclarations.Count <> 0 then
                let names = pendingDeclarations.Keys |> String.concat ", "
                failwith $"portable Rust backend found uninitialized declarations before {boundary}: {names}"
        output.AppendLine("// Generated by Spiral portable Rust backend.") |> ignore
        output.AppendLine("fn spiral_main() -> i32 {") |> ignore
        for statement in statements do
            match statement with
            | PortableDeclare(cType, name) ->
                pendingDeclarations.[name] <- rustType cType
            | PortableAssign(name, expression) ->
                match pendingDeclarations.TryGetValue name with
                | true, targetType ->
                    let mutableKeyword =
                        match assignmentCounts.TryGetValue name with
                        | true, count when count > 1 -> "mut "
                        | _ -> ""
                    emit $"let {mutableKeyword}{name}: {targetType} = {normalizeCIntegerSuffixes expression};"
                    pendingDeclarations.Remove name |> ignore
                | false, _ ->
                    emit $"{name} = {normalizeCIntegerSuffixes expression};"
            | PortableReturn expression ->
                requireNoPending "return"
                emit $"return {normalizeCIntegerSuffixes expression};"
            | PortableIfStart condition ->
                requireNoPending "if"
                emit $"if {normalizeCIntegerSuffixes condition} {{"
                indentLevel <- indentLevel + 1
            | PortableWhileStart condition ->
                requireNoPending "while"
                emit $"while {normalizeCIntegerSuffixes condition} {{"
                indentLevel <- indentLevel + 1
            | PortableBreak ->
                requireNoPending "break"
                emit "break;"
            | PortableContinue ->
                requireNoPending "continue"
                emit "continue;"
            | PortableElse ->
                requireNoPending "else"
                indentLevel <- indentLevel - 1
                emit "} else {"
                indentLevel <- indentLevel + 1
            | PortableBlockEnd ->
                requireNoPending "block end"
                indentLevel <- indentLevel - 1
                emit "}"
        requireNoPending "function end"
        if indentLevel <> 1 then failwith "portable Rust backend indentation stack is unbalanced"
        output.AppendLine("}") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("fn main() {") |> ignore
        output.AppendLine("    std::process::exit(spiral_main());") |> ignore
        output.AppendLine("}") |> ignore
        output.ToString()

    let private delphiType = function
        | "int8_t" -> "ShortInt"
        | "int16_t" -> "SmallInt"
        | "int32_t" -> "LongInt"
        | "int64_t" -> "Int64"
        | "uint8_t" -> "Byte"
        | "uint16_t" -> "Word"
        | "uint32_t" -> "LongWord"
        | "uint64_t" -> "QWord"
        | "float" -> "Single"
        | "double" -> "Double"
        | "bool" -> "Boolean"
        | value when Regex.IsMatch(value, "^String\\s*\\*$") -> "AnsiString"
        | value when Regex.IsMatch(value, "^Tuple[0-9]+$") -> value
        | value -> failwith $"portable Delphi backend does not support C type: {value}"

    let private delphiExpression expression =
        (normalizeCIntegerSuffixes expression)
            .Replace("!=", "<>")
            .Replace("==", "=")
            .Replace("&&", " and ")
            .Replace("||", " or ")
            .Replace("%", " mod ")

    let private delphiFromPortableC generated =
        let statements = parsePortableC generated
        let declarations =
            statements
            |> List.choose (function PortableDeclare(cType, name) -> Some(name, delphiType cType) | _ -> None)
        let output = StringBuilder()
        let mutable indentLevel = 1
        let emit text = output.AppendLine(String(' ', indentLevel * 2) + text) |> ignore
        output.AppendLine("program SpiralGenerated;") |> ignore
        output.AppendLine("{$mode objfpc}{$H+}") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("function SpiralMain: LongInt;") |> ignore
        if not declarations.IsEmpty then
            output.AppendLine("var") |> ignore
            for name, targetType in declarations do
                output.AppendLine($"  {name}: {targetType};") |> ignore
        output.AppendLine("begin") |> ignore
        for statement in statements do
            match statement with
            | PortableDeclare _ -> ()
            | PortableAssign(name, expression) ->
                emit $"{name} := {delphiExpression expression};"
            | PortableReturn expression ->
                emit $"SpiralMain := {delphiExpression expression};"
            | PortableIfStart condition ->
                emit $"if {delphiExpression condition} then begin"
                indentLevel <- indentLevel + 1
            | PortableWhileStart condition ->
                emit $"while {delphiExpression condition} do begin"
                indentLevel <- indentLevel + 1
            | PortableBreak ->
                emit "Break;"
            | PortableContinue ->
                emit "Continue;"
            | PortableElse ->
                indentLevel <- indentLevel - 1
                emit "end else begin"
                indentLevel <- indentLevel + 1
            | PortableBlockEnd ->
                indentLevel <- indentLevel - 1
                emit "end;"
        if indentLevel <> 1 then failwith "portable Delphi backend indentation stack is unbalanced"
        output.AppendLine("end;") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("begin") |> ignore
        output.AppendLine("  Halt(SpiralMain);") |> ignore
        output.AppendLine("end.") |> ignore
        output.ToString()

    type private PortableParameterV2 = {
        cType : string
        name : string
        }

    type private PortableTupleTypeV2 = {
        name : string
        fields : PortableParameterV2 list
        mutable constructorParameters : PortableParameterV2 list
        }

    type private PortableExpressionV3 =
        | PortableNumberV3 of string
        | PortableStringV3 of string
        | PortableBooleanV3 of bool
        | PortableIdentifierV3 of string
        | PortableCallV3 of callee : PortableExpressionV3 * arguments : PortableExpressionV3 list
        | PortableUnaryV3 of operatorText : string * operand : PortableExpressionV3
        | PortableBinaryV3 of operatorText : string * left : PortableExpressionV3 * right : PortableExpressionV3
        | PortableFieldV3 of target : PortableExpressionV3 * fieldName : string

    type private PortableStatementV3 =
        | PortableDeclareV3 of cType : string * name : string
        | PortableAssignV3 of name : string * expression : PortableExpressionV3
        | PortableReturnV3 of expression : PortableExpressionV3 option
        | PortableIfStartV3 of condition : PortableExpressionV3
        | PortableWhileStartV3 of condition : PortableExpressionV3
        | PortableBreakV3
        | PortableContinueV3
        | PortableElseV3
        | PortableBlockEndV3

    type private PortableExpressionTokenV3 =
        | PortableIdentifierTokenV3 of string
        | PortableNumberTokenV3 of string
        | PortableStringTokenV3 of string
        | PortableBooleanTokenV3 of bool
        | PortableOperatorTokenV3 of string
        | PortableLeftParenTokenV3
        | PortableRightParenTokenV3
        | PortableCommaTokenV3
        | PortableDotTokenV3
        | PortableEndTokenV3

    let private tokenizePortableExpressionV3 (text : string) =
        let tokens = ResizeArray<PortableExpressionTokenV3>()
        let mutable index = 0
        let at offset =
            let position = index + offset
            if position < text.Length then Some text.[position] else None
        let consumeWhile predicate =
            let start = index
            while index < text.Length && predicate text.[index] do index <- index + 1
            text.Substring(start, index - start)
        while index < text.Length do
            let ch = text.[index]
            if Char.IsWhiteSpace ch then
                index <- index + 1
            elif ch = '"' then
                let start = index
                index <- index + 1
                let mutable escaped = false
                let mutable closed = false
                while index < text.Length && not closed do
                    let value = text.[index]
                    index <- index + 1
                    if escaped then escaped <- false
                    elif value = '\\' then escaped <- true
                    elif value = '"' then closed <- true
                if not closed then failwith $"portable expression v3 found an unterminated string literal in: {text}"
                tokens.Add(PortableStringTokenV3(text.Substring(start, index - start)))
            elif ch = '_' || Char.IsAsciiLetter ch then
                let value = consumeWhile (fun value -> value = '_' || Char.IsAsciiLetterOrDigit value)
                match value with
                | "true" -> tokens.Add(PortableBooleanTokenV3 true)
                | "false" -> tokens.Add(PortableBooleanTokenV3 false)
                | _ -> tokens.Add(PortableIdentifierTokenV3 value)
            elif Char.IsDigit ch || (ch = '.' && (match at 1 with Some value -> Char.IsDigit value | None -> false)) then
                let start = index
                let mutable sawExponent = false
                let mutable scanning = true
                while index < text.Length && scanning do
                    let value = text.[index]
                    if Char.IsDigit value || value = '.' then
                        index <- index + 1
                    elif (value = 'e' || value = 'E') && not sawExponent then
                        sawExponent <- true
                        index <- index + 1
                        if index < text.Length && (text.[index] = '+' || text.[index] = '-') then index <- index + 1
                    elif Char.IsAsciiLetter value then
                        index <- index + 1
                    else
                        scanning <- false
                tokens.Add(PortableNumberTokenV3(text.Substring(start, index - start)))
            else
                let pair = if index + 1 < text.Length then text.Substring(index, 2) else ""
                match pair with
                | "<=" | ">=" | "==" | "!=" | "&&" | "||" ->
                    tokens.Add(PortableOperatorTokenV3 pair)
                    index <- index + 2
                | _ ->
                    match ch with
                    | '+' | '-' | '*' | '/' | '%' | '!' | '<' | '>' ->
                        tokens.Add(PortableOperatorTokenV3(string ch))
                        index <- index + 1
                    | '(' -> tokens.Add PortableLeftParenTokenV3; index <- index + 1
                    | ')' -> tokens.Add PortableRightParenTokenV3; index <- index + 1
                    | ',' -> tokens.Add PortableCommaTokenV3; index <- index + 1
                    | '.' -> tokens.Add PortableDotTokenV3; index <- index + 1
                    | _ -> failwith $"portable expression v3 found unsupported character '{ch}' in: {text}"
        tokens.Add PortableEndTokenV3
        tokens.ToArray()

    let private portableBinaryPrecedenceV3 = function
        | "||" -> 1
        | "&&" -> 2
        | "==" | "!=" -> 3
        | "<" | "<=" | ">" | ">=" -> 4
        | "+" | "-" -> 5
        | "*" | "/" | "%" -> 6
        | value -> failwith $"portable expression v3 found unsupported binary operator: {value}"

    let private parsePortableExpressionV3 (text : string) =
        let tokens = tokenizePortableExpressionV3 text
        let mutable index = 0
        let current () = tokens.[index]
        let advance () = let token = tokens.[index] in index <- index + 1; token
        let expect expected =
            let actual = advance()
            if actual <> expected then failwith $"portable expression v3 expected {expected} but got {actual} in: {text}"
        let rec parseExpression minimumPrecedence =
            let mutable left = parseUnary()
            let mutable scanning = true
            while scanning do
                match current() with
                | PortableOperatorTokenV3 operatorText ->
                    let precedence = portableBinaryPrecedenceV3 operatorText
                    if precedence < minimumPrecedence then
                        scanning <- false
                    else
                        advance() |> ignore
                        let right = parseExpression (precedence + 1)
                        left <- PortableBinaryV3(operatorText, left, right)
                | _ -> scanning <- false
            left
        and parseUnary () =
            match current() with
            | PortableOperatorTokenV3 ("!" | "+" | "-" as operatorText) ->
                advance() |> ignore
                PortableUnaryV3(operatorText, parseUnary())
            | _ -> parsePostfix()
        and parsePostfix () =
            let mutable expression = parsePrimary()
            let mutable scanning = true
            while scanning do
                match current() with
                | PortableLeftParenTokenV3 ->
                    advance() |> ignore
                    let arguments = ResizeArray<PortableExpressionV3>()
                    if current() <> PortableRightParenTokenV3 then
                        arguments.Add(parseExpression 1)
                        while current() = PortableCommaTokenV3 do
                            advance() |> ignore
                            arguments.Add(parseExpression 1)
                    expect PortableRightParenTokenV3
                    expression <- PortableCallV3(expression, arguments |> Seq.toList)
                | PortableDotTokenV3 ->
                    advance() |> ignore
                    match advance() with
                    | PortableIdentifierTokenV3 fieldName -> expression <- PortableFieldV3(expression, fieldName)
                    | actual -> failwith $"portable expression v3 expected a field identifier but got {actual} in: {text}"
                | _ -> scanning <- false
            expression
        and parsePrimary () =
            match advance() with
            | PortableNumberTokenV3 value -> PortableNumberV3 value
            | PortableStringTokenV3 value -> PortableStringV3 value
            | PortableBooleanTokenV3 value -> PortableBooleanV3 value
            | PortableIdentifierTokenV3 value -> PortableIdentifierV3 value
            | PortableLeftParenTokenV3 ->
                let expression = parseExpression 1
                expect PortableRightParenTokenV3
                expression
            | actual -> failwith $"portable expression v3 expected a primary expression but got {actual} in: {text}"
        let expression = parseExpression 1
        if current() <> PortableEndTokenV3 then failwith $"portable expression v3 found trailing tokens in: {text}"
        expression

    let private normalizePortableNumberV3 value = normalizeCIntegerSuffixes value

    let private rustExpressionV3 expression =
        let rec render parentPrecedence expression =
            match expression with
            | PortableNumberV3 value -> normalizePortableNumberV3 value
            | PortableStringV3 value -> value
            | PortableBooleanV3 value -> if value then "true" else "false"
            | PortableIdentifierV3 "main" -> "spiral_main"
            | PortableIdentifierV3 value -> value
            | PortableCallV3(PortableIdentifierV3 "StringLit", [_; PortableStringV3 value]) -> value
            | PortableCallV3(callee, arguments) ->
                let arguments = arguments |> List.map (render 1) |> String.concat ", "
                $"{render 8 callee}({arguments})"
            | PortableFieldV3(target, fieldName) -> $"{render 8 target}.{fieldName}"
            | PortableUnaryV3(operatorText, operand) ->
                let precedence = 7
                let text = $"{operatorText}{render precedence operand}"
                if precedence < parentPrecedence then $"({text})" else text
            | PortableBinaryV3(operatorText, left, right) ->
                let precedence = portableBinaryPrecedenceV3 operatorText
                let text = $"{render precedence left} {operatorText} {render (precedence + 1) right}"
                if precedence < parentPrecedence then $"({text})" else text
        render 1 expression

    let private delphiStringLiteralV3 (value : string) =
        if value.Length < 2 || value.[0] <> '"' || value.[value.Length - 1] <> '"' then
            failwith $"portable Delphi backend received an invalid C string literal: {value}"
        let body = value.Substring(1, value.Length - 2)
        if body.Contains("\\n") || body.Contains("\\r") || body.Contains("\\t") then
            failwith $"portable Delphi backend does not yet support control escapes in string literal: {value}"
        let body = body.Replace("\\\"", "\"").Replace("\\\\", "\\").Replace("'", "''")
        $"'{body}'"

    let rec private delphiExpressionV3 = function
        | PortableNumberV3 value -> normalizePortableNumberV3 value
        | PortableStringV3 value -> delphiStringLiteralV3 value
        | PortableBooleanV3 value -> if value then "True" else "False"
        | PortableIdentifierV3 "main" -> "SpiralMain"
        | PortableIdentifierV3 value -> value
        | PortableCallV3(PortableIdentifierV3 "StringLit", [_; PortableStringV3 value]) -> delphiStringLiteralV3 value
        | PortableCallV3(callee, arguments) ->
            let arguments = arguments |> List.map delphiExpressionV3 |> String.concat ", "
            $"{delphiExpressionV3 callee}({arguments})"
        | PortableUnaryV3("!", operand) -> $"(not {delphiExpressionV3 operand})"
        | PortableUnaryV3(operatorText, operand) -> $"({operatorText}{delphiExpressionV3 operand})"
        | PortableBinaryV3(operatorText, left, right) ->
            let targetOperator =
                match operatorText with
                | "!=" -> "<>"
                | "==" -> "="
                | "&&" -> "and"
                | "||" -> "or"
                | "%" -> "mod"
                | value -> value
            $"({delphiExpressionV3 left} {targetOperator} {delphiExpressionV3 right})"
        | PortableFieldV3(target, fieldName) -> $"{delphiExpressionV3 target}.{fieldName}"

    type private PortableFunctionV2 = {
        returnType : string
        name : string
        parameters : PortableParameterV2 list
        statements : PortableStatementV3 list
        }

    let private parsePortableParametersV2 (text : string) =
        if String.IsNullOrWhiteSpace text || text.Trim() = "void" then []
        else
            let parameter = Regex($"^({portableAnyTypePattern})\\s+([A-Za-z_][A-Za-z0-9_]*)$")
            text.Split(',')
            |> Array.map (fun raw ->
                let value = raw.Trim()
                let matched = parameter.Match value
                if not matched.Success then failwith $"portable backend does not support this C parameter: {value}"
                { cType = matched.Groups.[1].Value; name = matched.Groups.[2].Value })
            |> Array.toList

    let private preprocessPortableProgramC (generated : string) =
        let tuples = ResizeArray<PortableTupleTypeV2>()
        let kept = ResizeArray<string>()
        let mutable inStruct = false
        let structFields = ResizeArray<string>()
        let mutable skippingHelper = false
        let mutable helperDepth = 0
        let tupleField = Regex($"^({portableTypePattern})\\s+([A-Za-z_][A-Za-z0-9_]*)\\s*;$")
        let structEnd = Regex("^}\\s+([A-Za-z_][A-Za-z0-9_]*);$")
        let tupleHelperStart = Regex($"^static inline (Tuple[0-9]+)\\s+(TupleCreate[0-9]+)\\s*\\((.*)\\)\\s*\\{{$")
        let runtimeHelperStart = Regex("^(?:static inline )?(?:void|Array[0-9]+\\s*\\*|String\\s*\\*)\\s+(?:ArrayDecrefBody[0-9]+|ArrayDecref[0-9]+|ArrayCreate[0-9]+|ArrayLit[0-9]+|StringDecref|StringLit)\\s*\\(.*\\)\\s*\\{$")
        let braceDelta (line : string) =
            (line |> Seq.filter ((=) '{') |> Seq.length) - (line |> Seq.filter ((=) '}') |> Seq.length)
        for raw in generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None) do
            let line = raw.Trim()
            let tupleHelperMatch = tupleHelperStart.Match line
            if skippingHelper then
                helperDepth <- helperDepth + braceDelta line
                if helperDepth <= 0 then
                    skippingHelper <- false
                    helperDepth <- 0
            elif inStruct then
                let endMatch = structEnd.Match line
                if endMatch.Success then
                    let structName = endMatch.Groups.[1].Value
                    if Regex.IsMatch(structName, "^Tuple[0-9]+$") then
                        let fields =
                            structFields
                            |> Seq.map (fun fieldLine ->
                                let fieldMatch = tupleField.Match fieldLine
                                if not fieldMatch.Success then failwith $"portable backend does not support this tuple field: {fieldLine}"
                                { cType = fieldMatch.Groups.[1].Value; name = fieldMatch.Groups.[2].Value })
                            |> Seq.toList
                        if fields.IsEmpty then failwith $"portable backend found an empty tuple type: {structName}"
                        tuples.Add { name = structName; fields = fields; constructorParameters = fields }
                    structFields.Clear()
                    inStruct <- false
                elif not (String.IsNullOrWhiteSpace line) then
                    structFields.Add line
            elif line = "typedef struct {" then
                inStruct <- true
            elif Regex.IsMatch(line, "^typedef\\s+Array[0-9]+\\s+String;$") then
                ()
            elif tupleHelperMatch.Success then
                let tupleName = tupleHelperMatch.Groups.[1].Value
                let parameters = parsePortableParametersV2 tupleHelperMatch.Groups.[3].Value
                match tuples |> Seq.tryFind (fun tupleType -> tupleType.name = tupleName) with
                | Some tupleType -> tupleType.constructorParameters <- parameters
                | None -> failwith $"portable backend found a constructor before its tuple type: {line}"
                helperDepth <- braceDelta line
                skippingHelper <- helperDepth > 0
            elif runtimeHelperStart.IsMatch line then
                helperDepth <- braceDelta line
                skippingHelper <- helperDepth > 0
            else
                kept.Add raw
        if inStruct then failwith "portable backend found an unterminated C struct typedef"
        if skippingHelper then failwith "portable backend found an unterminated helper function"
        tuples |> Seq.toList, String.Join("\n", kept)

    let private expandPortableCLines (generated : string) =
        seq {
            for raw in generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None) do
                let line = raw.Trim()
                if line.Contains(';') && not (line.Contains('{')) && not (line.Contains('}')) then
                    for part in line.Split(';') do
                        let part = part.Trim()
                        if not (String.IsNullOrWhiteSpace part) then yield part + ";"
                else
                    yield line
        }

    let private parsePortableProgramC (generated : string) =
        let tuples, generated = preprocessPortableProgramC generated
        let functions = ResizeArray<PortableFunctionV2>()
        let statements = ResizeArray<PortableStatementV3>()
        let mutable currentReturnType = ""
        let mutable currentName = ""
        let mutable currentParameters : PortableParameterV2 list = []
        let mutable depth = 0
        let mutable sawReturn = false
        let functionHeader = Regex($"^({portableAnyTypePattern}|void)\\s+([A-Za-z_][A-Za-z0-9_]*)\\s*\\((.*)\\)\\s*\\{{$")
        let declaration = Regex($"^({portableAnyTypePattern})\\s+([A-Za-z_][A-Za-z0-9_]*)\\s*;$")
        let initializedDeclaration = Regex($"^({portableAnyTypePattern})\\s+([A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(.+);$")
        let assignment = Regex("^([A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(.+);$")
        let returning = Regex("^return(?:\\s+(.+))?;$")
        let ifStart = Regex("^if\\s*\\((.+)\\)\\s*\\{$")
        let whileStart = Regex("^while\\s*\\((.+)\\)\\s*\\{$")
        let finishFunction () =
            if currentName = "" then failwith "portable backend tried to close a function that was not open"
            if currentReturnType <> "void" && not sawReturn then
                failwith $"portable backend requires a return statement in function {currentName}"
            functions.Add {
                returnType = currentReturnType
                name = currentName
                parameters = currentParameters
                statements = statements |> Seq.toList
                }
            statements.Clear()
            currentReturnType <- ""
            currentName <- ""
            currentParameters <- []
            depth <- 0
            sawReturn <- false
        for line in expandPortableCLines generated do
            if String.IsNullOrWhiteSpace line || line.StartsWith("#include", StringComparison.Ordinal) then ()
            elif currentName = "" then
                let matched = functionHeader.Match line
                if not matched.Success then
                    failwith $"portable backend does not support this C prelude: {line}"
                currentReturnType <- matched.Groups.[1].Value
                currentName <- matched.Groups.[2].Value
                currentParameters <- parsePortableParametersV2 matched.Groups.[3].Value
                depth <- 1
            elif line = "} else {" then
                statements.Add PortableElseV3
            elif line = "}" then
                depth <- depth - 1
                if depth = 0 then finishFunction()
                else statements.Add PortableBlockEndV3
            elif line = "break;" then
                statements.Add PortableBreakV3
            elif line = "continue;" then
                statements.Add PortableContinueV3
            elif Regex.IsMatch(line, "^StringDecref\\([A-Za-z_][A-Za-z0-9_]*\\);$") then
                ()
            elif Regex.IsMatch(line, "^[A-Za-z_][A-Za-z0-9_]*->refc\\+\\+;$") then
                ()
            else
                let initializedMatch = initializedDeclaration.Match line
                let declarationMatch = declaration.Match line
                let assignmentMatch = assignment.Match line
                let returnMatch = returning.Match line
                let ifMatch = ifStart.Match line
                let whileMatch = whileStart.Match line
                if initializedMatch.Success then
                    statements.Add(PortableDeclareV3(initializedMatch.Groups.[1].Value, initializedMatch.Groups.[2].Value))
                    statements.Add(PortableAssignV3(initializedMatch.Groups.[2].Value, parsePortableExpressionV3 initializedMatch.Groups.[3].Value))
                elif declarationMatch.Success then
                    statements.Add(PortableDeclareV3(declarationMatch.Groups.[1].Value, declarationMatch.Groups.[2].Value))
                elif returnMatch.Success then
                    let expression =
                        if returnMatch.Groups.[1].Success then Some(parsePortableExpressionV3 returnMatch.Groups.[1].Value)
                        else None
                    statements.Add(PortableReturnV3 expression)
                    sawReturn <- true
                elif assignmentMatch.Success then
                    statements.Add(PortableAssignV3(assignmentMatch.Groups.[1].Value, parsePortableExpressionV3 assignmentMatch.Groups.[2].Value))
                elif ifMatch.Success then
                    statements.Add(PortableIfStartV3(parsePortableExpressionV3 ifMatch.Groups.[1].Value))
                    depth <- depth + 1
                elif whileMatch.Success then
                    statements.Add(PortableWhileStartV3(parsePortableExpressionV3 whileMatch.Groups.[1].Value))
                    depth <- depth + 1
                else
                    failwith $"portable backend does not support this C statement yet in {currentName}: {line}"
        if currentName <> "" || depth <> 0 then failwith "portable backend found an unterminated C function"
        if functions.Count = 0 then failwith "portable backend found no C functions"
        if functions |> Seq.exists (fun fn -> fn.name = "main") |> not then
            failwith "portable backend requires a C main function"
        tuples, (functions |> Seq.toList)

    let private rustFunctionNameV2 name = if name = "main" then "spiral_main" else name

    let private rustExpressionV2 expression =
        let normalized = normalizeCIntegerSuffixes expression
        Regex.Replace(normalized, "\\bmain\\s*\\(", "spiral_main(")

    let private assignmentCountsV2 (statements : PortableStatementV3 list) =
        let counts = Dictionary<string,int>(StringComparer.Ordinal)
        for statement in statements do
            match statement with
            | PortableAssignV3(name, _) ->
                counts.[name] <-
                    match counts.TryGetValue name with
                    | true, count -> count + 1
                    | false, _ -> 1
            | _ -> ()
        counts

    let private rustFromPortableProgramC generated =
        let tuples, functions = parsePortableProgramC generated
        let output = StringBuilder()
        output.AppendLine("// Generated by Spiral portable Rust backend.") |> ignore
        output.AppendLine("#![allow(unused_mut, non_snake_case, dead_code, unused_variables, unused_assignments)]") |> ignore
        output.AppendLine() |> ignore
        for tupleType in tuples do
            output.AppendLine("#[derive(Clone, Copy)]") |> ignore
            output.AppendLine($"struct {tupleType.name} {{") |> ignore
            for field in tupleType.fields do
                output.AppendLine($"    {field.name}: {rustType field.cType},") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
            let constructorName = tupleType.name.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
            let parameters = tupleType.constructorParameters |> List.map (fun field -> $"{field.name}: {rustType field.cType}") |> String.concat ", "
            let fields = tupleType.fields |> List.map (fun field -> field.name) |> String.concat ", "
            output.AppendLine($"fn {constructorName}({parameters}) -> {tupleType.name} {{") |> ignore
            output.AppendLine($"    {tupleType.name} {{ {fields} }}") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        for fn in functions do
            let assignmentCounts = assignmentCountsV2 fn.statements
            let parameters =
                fn.parameters
                |> List.map (fun parameter ->
                    let mutableKeyword = if assignmentCounts.ContainsKey parameter.name then "mut " else ""
                    $"{mutableKeyword}{parameter.name}: {rustType parameter.cType}")
                |> String.concat ", "
            let returnType = if fn.returnType = "void" then "()" else rustType fn.returnType
            output.AppendLine($"fn {rustFunctionNameV2 fn.name}({parameters}) -> {returnType} {{") |> ignore
            let mutable indentLevel = 1
            let emit text = output.AppendLine(String(' ', indentLevel * 4) + text) |> ignore
            for statement in fn.statements do
                match statement with
                | PortableDeclareV3(cType, name) ->
                    let mutableKeyword =
                        match assignmentCounts.TryGetValue name with
                        | true, count when count > 1 -> "mut "
                        | _ -> ""
                    emit $"let {mutableKeyword}{name}: {rustType cType};"
                | PortableAssignV3(name, expression) ->
                    emit $"{name} = {rustExpressionV3 expression};"
                | PortableReturnV3 expression ->
                    match expression with
                    | None -> emit "return;"
                    | Some value -> emit $"return {rustExpressionV3 value};"
                | PortableIfStartV3 condition ->
                    emit $"if {rustExpressionV3 condition} {{"
                    indentLevel <- indentLevel + 1
                | PortableWhileStartV3 condition ->
                    emit $"while {rustExpressionV3 condition} {{"
                    indentLevel <- indentLevel + 1
                | PortableBreakV3 ->
                    emit "break;"
                | PortableContinueV3 ->
                    emit "continue;"
                | PortableElseV3 ->
                    indentLevel <- indentLevel - 1
                    emit "} else {"
                    indentLevel <- indentLevel + 1
                | PortableBlockEndV3 ->
                    indentLevel <- indentLevel - 1
                    emit "}"
            if indentLevel <> 1 then failwith $"portable Rust backend block stack is unbalanced in {fn.name}"
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        output.AppendLine("fn main() {") |> ignore
        output.AppendLine("    std::process::exit(spiral_main());") |> ignore
        output.AppendLine("}") |> ignore
        output.ToString()

    let private delphiFunctionNameV2 name = if name = "main" then "SpiralMain" else name

    let private delphiExpressionV2 expression =
        let normalized = delphiExpression expression
        Regex.Replace(normalized, "\\bmain\\s*\\(", "SpiralMain(")

    let private delphiFromPortableProgramC generated =
        let tuples, functions = parsePortableProgramC generated
        let output = StringBuilder()
        output.AppendLine("program SpiralGenerated;") |> ignore
        output.AppendLine("{$mode objfpc}{$H+}") |> ignore
        output.AppendLine() |> ignore
        if not tuples.IsEmpty then
            output.AppendLine("type") |> ignore
            for tupleType in tuples do
                output.AppendLine($"  {tupleType.name} = record") |> ignore
                for field in tupleType.fields do
                    output.AppendLine($"    {field.name}: {delphiType field.cType};") |> ignore
                output.AppendLine("  end;") |> ignore
            output.AppendLine() |> ignore
            for tupleType in tuples do
                let constructorName = tupleType.name.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
                let parameters = tupleType.constructorParameters |> List.map (fun field -> $"{field.name}: {delphiType field.cType}") |> String.concat "; "
                output.AppendLine($"function {constructorName}({parameters}): {tupleType.name};") |> ignore
                output.AppendLine("begin") |> ignore
                for field in tupleType.fields do
                    output.AppendLine($"  Result.{field.name} := {field.name};") |> ignore
                output.AppendLine("end;") |> ignore
                output.AppendLine() |> ignore
        for fn in functions do
            let functionName = delphiFunctionNameV2 fn.name
            let parameters =
                fn.parameters
                |> List.map (fun parameter -> $"{parameter.name}: {delphiType parameter.cType}")
                |> String.concat "; "
            let declarations =
                fn.statements
                |> List.choose (function PortableDeclareV3(cType, name) -> Some(name, delphiType cType) | _ -> None)
                |> List.distinct
            if fn.returnType = "void" then
                if parameters = "" then output.AppendLine($"procedure {functionName};") |> ignore
                else output.AppendLine($"procedure {functionName}({parameters});") |> ignore
            else
                let targetType = delphiType fn.returnType
                if parameters = "" then output.AppendLine($"function {functionName}: {targetType};") |> ignore
                else output.AppendLine($"function {functionName}({parameters}): {targetType};") |> ignore
            if not declarations.IsEmpty then
                output.AppendLine("var") |> ignore
                for name, targetType in declarations do
                    output.AppendLine($"  {name}: {targetType};") |> ignore
            output.AppendLine("begin") |> ignore
            let mutable indentLevel = 1
            let emit text = output.AppendLine(String(' ', indentLevel * 2) + text) |> ignore
            for statement in fn.statements do
                match statement with
                | PortableDeclareV3 _ -> ()
                | PortableAssignV3(name, expression) ->
                    emit $"{name} := {delphiExpressionV3 expression};"
                | PortableReturnV3 expression ->
                    match expression with
                    | None -> emit "Exit;"
                    | Some value -> emit $"Exit({delphiExpressionV3 value});"
                | PortableIfStartV3 condition ->
                    emit $"if {delphiExpressionV3 condition} then begin"
                    indentLevel <- indentLevel + 1
                | PortableWhileStartV3 condition ->
                    emit $"while {delphiExpressionV3 condition} do begin"
                    indentLevel <- indentLevel + 1
                | PortableBreakV3 ->
                    emit "Break;"
                | PortableContinueV3 ->
                    emit "Continue;"
                | PortableElseV3 ->
                    indentLevel <- indentLevel - 1
                    emit "end else begin"
                    indentLevel <- indentLevel + 1
                | PortableBlockEndV3 ->
                    indentLevel <- indentLevel - 1
                    emit "end;"
            if indentLevel <> 1 then failwith $"portable Delphi backend block stack is unbalanced in {fn.name}"
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        output.AppendLine("begin") |> ignore
        output.AppendLine("  Halt(SpiralMain);") |> ignore
        output.AppendLine("end.") |> ignore
        output.ToString()

    let private lowerPortableBackend (backend : string) (generated : string) =
        PortableBackends.lowerPortableBackend backend generated

    /// SPIRAL_HOST_TRACE_DIAGNOSTICS=1 echoes every diagnostic message the core sends to stderr.
    let private traceDiagnostics =
        String.Equals(Environment.GetEnvironmentVariable "SPIRAL_HOST_TRACE_DIAGNOSTICS", "1", StringComparison.Ordinal)

    /// How long a FatalError waits for the typer's detailed diagnostics before it is reported alone.
    let private fatalGraceMs =
        match Int32.TryParse(Environment.GetEnvironmentVariable "SPIRAL_HOST_FATAL_GRACE_MS") with
        | true, value when value >= 0 -> value
        | _ -> 750

    // Windows file URIs differ in drive-letter case and escaping between the host and the core.
    let private normalizeUri (uri : string) =
        Uri.UnescapeDataString(uri).Replace('\\', '/').TrimEnd('/')

    let private sameUri (a : string) (b : string) =
        String.Equals(normalizeUri a, normalizeUri b, StringComparison.OrdinalIgnoreCase)

    let private diagnosticFor uri = function
        | TypeErrors x when sameUri x.uri uri && not (List.isEmpty x.errors) ->
            Some $"TypeErrors: %A{x.errors}"
        | ParserErrors x when sameUri x.uri uri && not (List.isEmpty x.errors) ->
            Some $"ParserErrors: %A{x.errors}"
        | TokenizerErrors x when sameUri x.uri uri && not (List.isEmpty x.errors) ->
            Some $"TokenizerErrors: %A{x.errors}"
        | PackageErrors x when not (List.isEmpty x.errors) ->
            Some $"PackageErrors ({x.uri}): %A{x.errors}"
        | TracedError x -> Some $"TracedError: %A{x}"
        | _ -> None

    /// A diagnostic about some other file (e.g. an imported package) that explains a later FatalError.
    let private diagnosticForOther = function
        | TypeErrors x when not (List.isEmpty x.errors) -> Some $"TypeErrors ({x.uri}): %A{x.errors}"
        | ParserErrors x when not (List.isEmpty x.errors) -> Some $"ParserErrors ({x.uri}): %A{x.errors}"
        | TokenizerErrors x when not (List.isEmpty x.errors) -> Some $"TokenizerErrors ({x.uri}): %A{x.errors}"
        | _ -> None

    type private DiagnosticRouter() =
        let gate = obj()
        let mutable active : (string * Threading.Tasks.TaskCompletionSource<string>) option = None
        let mutable related : string option = None

        member _.Begin(uri) =
            let waiter =
                new Threading.Tasks.TaskCompletionSource<string>(
                    Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously)
            lock gate (fun () -> active <- Some (uri, waiter); related <- None)
            waiter

        member _.Clear(waiter : Threading.Tasks.TaskCompletionSource<string>) =
            lock gate (fun () ->
                match active with
                | Some (_, current) when Object.ReferenceEquals(current, waiter) -> active <- None
                | _ -> ())

        member _.Accept(message : ClientErrorsRes) =
            if traceDiagnostics then eprintfn "[diagnostic] %A" message
            match message with
            | FatalError fatal ->
                let pending = lock gate (fun () -> active)
                match pending with
                | Some (_, waiter) ->
                    Threading.Tasks.Task.Delay(fatalGraceMs).ContinueWith(fun (_ : Threading.Tasks.Task) ->
                        lock gate (fun () ->
                            match active with
                            | Some (_, current) when Object.ReferenceEquals(current, waiter) ->
                                let detail = match related with Some text -> $"\n{text}" | None -> ""
                                current.TrySetResult($"FatalError: {fatal}{detail}") |> ignore
                            | _ -> ()))
                    |> ignore
                | None -> ()
            | _ ->
                lock gate (fun () ->
                    match active with
                    | Some (uri, waiter) ->
                        match diagnosticFor uri message with
                        | Some diagnostic -> waiter.TrySetResult(diagnostic) |> ignore
                        | None ->
                            match diagnosticForOther message with
                            | Some text -> related <- Some text
                            | None -> ()
                    | None -> ())

    type private RevisionAction =
        | OpenSource of string
        | SourceUnchanged
        | ChangeSource of fromLine : int * nearToLine : int * lines : string []

    type private SourceRevisionStore() =
        let sources = Dictionary<string,string>(StringComparer.Ordinal)
        let splitLines (source : string) =
            source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)

        member _.Plan(uri, source) =
            match sources.TryGetValue uri with
            | false, _ -> OpenSource source
            | true, previous when String.Equals(previous, source, StringComparison.Ordinal) -> SourceUnchanged
            | true, previous ->
                let nearTo = splitLines previous |> Array.length
                let lines = splitLines source
                ChangeSource(0, nearTo, lines)

        member _.Commit(uri, source) =
            sources.[uri] <- source

    type private CachedCompilation =
        {
        fingerprint : string
        generated : string
        binding : string
        }

    type private CompilationCache() =
        let entries = Dictionary<string,CachedCompilation>(StringComparer.Ordinal)
        let key uri backend = backend + "\u0000" + uri

        member _.TryGet(uri, backend, fingerprint) =
            match entries.TryGetValue(key uri backend) with
            | true, cached when String.Equals(cached.fingerprint, fingerprint, StringComparison.Ordinal) -> Some cached
            | _ -> None

        member _.Put(uri, backend, fingerprint, generated, binding) =
            entries.[key uri backend] <-
                {
                fingerprint = fingerprint
                generated = generated
                binding = binding
                }

    let private sourceGraphFingerprint (inputPath : string) =
        let relevantSource (path : string) =
            let name = Path.GetFileName(path)
            let extension = Path.GetExtension(path)
            String.Equals(name, "package.spiproj", StringComparison.OrdinalIgnoreCase)
            || String.Equals(extension, ".spi", StringComparison.OrdinalIgnoreCase)
            || String.Equals(extension, ".spir", StringComparison.OrdinalIgnoreCase)
        let roots = ResizeArray<string>()
        let addRoot (value : string) =
            if not (String.IsNullOrWhiteSpace value) then
                let full = Path.GetFullPath value
                if Directory.Exists full && not (roots.Contains full) then roots.Add full
        addRoot (Path.GetDirectoryName inputPath)
        addRoot (Environment.GetEnvironmentVariable "SPIRAL_COMPILER_PACKAGE_DIR")
        let files =
            roots
            |> Seq.collect (fun root -> Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories))
            |> Seq.filter relevantSource
            |> Seq.map Path.GetFullPath
            |> Seq.distinct
            |> Seq.sort
            |> Seq.toArray
        use hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256)
        let appendText (value : string) = hash.AppendData(Encoding.UTF8.GetBytes value)
        for path in files do
            appendText path
            hash.AppendData([|0uy|])
            hash.AppendData(File.ReadAllBytes path)
            hash.AppendData([|0uy|])
        Convert.ToHexString(hash.GetHashAndReset())

    let private startDiagnosticPump errors (router : DiagnosticRouter) =
        errors
        |> FSharp.Control.AsyncSeq.iterAsync (fun message -> async { router.Accept message })
        |> Async.Start

    let private warmModulePipeline code =
        let defaultEnv = startupParse [|"--port"; "0"|]
        let state = wdiff_module_init_all defaultEnv true code
        state.parser.blocks
        |> List.iter (fun (_, parsed) -> Hopac.run parsed.block |> ignore)
        let rec drain stream =
            match Hopac.run stream with
            | Nil -> ()
            | Cons(_, next) -> drain next
        drain state.bundler

#if SPIRAL_CORE_HOPAC
    // The direct-project bypass reaches into single-flight internals (string ids, nominal_add)
    // that the Hopac core replaced with typed ids; Hopac mode always goes through the supervisor.
    let private directProjectCompileFsharp (_input : string) (_output : string) : Result<int * string * string, string> =
        Error "SPIRAL_DIRECT_PROJECT_BUILD is only available in single-flight mode"
#else
    let private directProjectCompileFsharp input output =
        try
            let inputPath = input |> Path.GetFullPath |> SpiralFileSystem.standardize_path
            let outputPath = output |> Path.GetFullPath
            let defaultEnv = startupParse [|"--port"; "0"|]
            let emptyState : SupervisorState =
                { packages = Map.empty
                  modules = Map.empty
                  packages_infer = {ok = Map.empty; error = Map.empty}
                  packages_prepass = {ok = Map.empty; error = Map.empty}
                  graph = mirrored_graph_empty
                  package_ids = Map.empty, Map.empty }
            let rec findOwner (directory : DirectoryInfo) =
                if isNull directory then failwith $"Cannot find package.spiproj for {inputPath}"
                let candidate = directory.FullName |> SpiralFileSystem.standardize_path
                if File.Exists(spiproj_suffix candidate) then candidate else findOwner directory.Parent
            let packageDir = findOwner (Directory.GetParent inputPath)
            let _, state = proj_open defaultEnv emptyState (packageDir, None)
            let pid = (fst state.package_ids).[packageDir]
            let tc =
                match Map.tryFind pid state.packages_infer.ok with
                | Some value -> value
                | None -> failwith $"Direct project typecheck did not produce package {packageDir}"
            let rec findModuleId = function
                | ProjFilesTree.File(mid, path, _) when String.Equals(path, inputPath, StringComparison.Ordinal) -> Some mid
                | ProjFilesTree.File _ -> None
                | ProjFilesTree.Directory(_, _, children) -> List.tryPick findModuleId children
            let mid = tc.files.files.tree |> List.tryPick findModuleId |> Option.defaultWith (fun () -> failwith $"Direct project input is not declared in package: {inputPath}")
            let typeState, typePropagated = tc.files.uids_file.[mid]
            let order, dirtyPackages = topological_sort' (fst state.graph) [packageDir]
            let prepassPackages =
                wdiff_projenvr_prepass defaultEnv (fst state.package_ids) state.packages state.packages_infer.ok state.packages_prepass (dirtyPackages, order.ToArray())
            let prepassPackage =
                match Map.tryFind pid prepassPackages.ok with
                | Some value -> value
                | None -> failwith $"Direct project prepass did not produce package {packageDir}"
            let prepassState, _ = prepassPackage.files.uids_file.[mid]
            let hasStateError, _ = Hopac.run typeState.state
            let hasPropagatedError, _ = Hopac.run typePropagated
            if hasStateError || hasPropagatedError then Error $"Direct project typecheck rejected {inputPath}"
            else
                let env = Hopac.run (prepass_results_summary prepassState.result)
                let compileTerm termName =
                    let term =
                        Map.tryFind termName env.term
                        |> Option.defaultWith (fun () -> failwith $"Cannot find `{termName}` in file {Path.GetFileNameWithoutExtension inputPath}.")
                    let prototypes_instances = Dictionary(env.prototypes_instances)
                    let nominals =
                        let table = HashConsTable()
                        let values = Dictionary()
                        env.nominals |> Map.iter (fun key value -> values.Add(key, nominal_add table key value))
                        values
                    let (arguments, _), body = peval {prototypes_instances = prototypes_instances; nominals = nominals; backend = "Fsharp"} term
                    termName, body, arguments
                let directTerms =
                    match Environment.GetEnvironmentVariable "SPIRAL_DIRECT_TERMS" with
                    | null | "" -> [||]
                    | value ->
                        value.Split([|','|], StringSplitOptions.RemoveEmptyEntries)
                        |> Array.map (fun term -> term.Trim())
                        |> Array.filter (String.IsNullOrWhiteSpace >> not)
                if directTerms.Length = 0 then
                    let _, body, arguments = compileTerm "main"
                    let generated = codegenFsharp body arguments
                    let binding = discoverEntryBinding generated
                    let parent = Path.GetDirectoryName outputPath
                    if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                    File.WriteAllText(outputPath, generated)
                    writeEntryManifest outputPath binding generated.Length "direct-project" "Fsharp"
                    Ok (generated.Length, binding, "direct-project")
                else
                    Directory.CreateDirectory outputPath |> ignore
                    let specialized = directTerms |> Array.map compileTerm
                    let compiled =
                        specialized
                        |> Array.map (fun (termName, body, arguments) ->
                            let generated = codegenFsharp body arguments
                            let binding = discoverEntryBinding generated
                            termName, generated, binding)
                    let mutable generatedBytes = 0
                    for termName, generated, binding in compiled do
                        let termOutput = Path.Combine(outputPath, termName + ".fsx")
                        File.WriteAllText(termOutput, generated)
                        writeEntryManifest termOutput binding generated.Length "direct-project-multi" "Fsharp"
                        generatedBytes <- generatedBytes + generated.Length
                    let binding = if compiled.Length = 1 then let _, _, value = compiled.[0] in value else "multi"
                    Ok (generatedBytes, binding, "direct-project-multi")
        with error -> Error error.Message
#endif


    /// Backends the core does not generate itself: the host asks the core for C and translates it
    /// (PortableBackends). The single-flight core generates Rust and Delphi itself; the hopac core still
    /// has them translated until its backends are ported.
    let private translatedBackend (backend : string) =
#if SPIRAL_CORE_HOPAC
        backend = "Rust" || backend = "Delphi"
#else
        ignore backend
        false
#endif

    let private compileOne
        (supervisor : Ch<SupervisorReq>)
        (router : DiagnosticRouter)
        (revisions : SourceRevisionStore)
        (cache : CompilationCache)
        (jobVal : (IVar<string option> -> Job<unit>) -> Threading.Tasks.Task<string>)
        backend input output =
        try
            let inputPath = input |> Path.GetFullPath |> SpiralFileSystem.normalize_path
            let outputPath = output |> Path.GetFullPath
            let code = File.ReadAllText inputPath
            let uri = inputPath |> SpiralFileSystem.new_file_uri
            let revision = revisions.Plan(uri, code)
            let fingerprint = sourceGraphFingerprint inputPath
            let cached =
                match revision with
                | SourceUnchanged -> cache.TryGet(uri, backend, fingerprint)
                | _ -> None
            let revisionMode =
                match cached, revision with
                | Some _, _ -> "cache-hit"
                | None, OpenSource _ -> "open"
                | None, SourceUnchanged -> "unchanged"
                | None, ChangeSource _ -> "change"
            let typedGenerated = if translatedBackend backend || backend = "C" || backend = "Fsharp" then PortableBackends.tryLowerPortableSource backend code else None
            if cached.IsNone && typedGenerated.IsNone then warmModulePipeline code
            // Rust and Delphi are lowered from C that the core writes next to the input. That path is the C
            // build's own output (the one copy of it), so it is put back as it was afterwards, or removed if
            // this build created it.
            let portable = translatedBackend backend
            let cPath = Path.ChangeExtension(inputPath, ".c")
            let cOwned = portable && not (String.Equals(Path.GetFullPath cPath, outputPath, StringComparison.OrdinalIgnoreCase))
            let cBefore = if cOwned && File.Exists cPath then Some (File.ReadAllBytes cPath) else None
            // The core's BuildFile also writes its output next to the input, asynchronously. Wait for that
            // write instead of racing it (same file, same text): true once `path` holds `text`.
            let awaitCoreWrite (path : string) (text : string) =
                let deadline = DateTime.UtcNow.AddSeconds 5.0
                let mutable landed = false
                while not landed && DateTime.UtcNow < deadline do
                    landed <- (try File.Exists path && File.ReadAllText path = text with _ -> false)
                    if not landed then Threading.Thread.Sleep 20
                landed
            let rec writeWithRetry (path : string) (text : string) attempt =
                try File.WriteAllText(path, text)
                with :? IOException when attempt < 250 ->
                    Threading.Thread.Sleep 20
                    writeWithRetry path text (attempt + 1)
            let restoreC () =
                if cOwned then
                    try
                        match cBefore with
                        | Some bytes -> if not (File.Exists cPath) || File.ReadAllBytes cPath <> bytes then File.WriteAllBytes(cPath, bytes)
                        | None -> if File.Exists cPath then File.Delete cPath
                    with _ -> ()
            let waiter = router.Begin uri
            try
                if cached.IsNone && typedGenerated.IsNone then
                    match revision with
                    | OpenSource source ->
                        openOwningProject supervisor inputPath
                        fileOpenRequest uri source
                        |> fun request -> Hopac.run (supervisor *<+ request)
                        revisions.Commit(uri, code)
                    | ChangeSource(fromLine, nearToLine, lines) ->
                        fileChangeRequest uri fromLine nearToLine lines
                        |> fun request -> Hopac.run (supervisor *<+ request)
                        revisions.Commit(uri, code)
                    | SourceUnchanged -> ()

                let supervisorBackend =
                    match backend with
                    | backend when translatedBackend backend -> "C"
                    | _ -> backend
                let buildTask =
                    match cached, typedGenerated with
                    | Some cached, _ -> Threading.Tasks.Task.FromResult cached.generated
                    | None, Some generated -> Threading.Tasks.Task.FromResult generated
                    | None, None ->
                        jobVal (fun result ->
                            buildFileRequest uri supervisorBackend result
                            |> fun request -> supervisor *<+ request)
                let winner =
                    Threading.Tasks.Task.WhenAny(buildTask :> Threading.Tasks.Task, waiter.Task :> Threading.Tasks.Task)
                        .GetAwaiter().GetResult()

                if Object.ReferenceEquals(winner, waiter.Task) then
                    Error (waiter.Task.GetAwaiter().GetResult())
                else
                    let generated = buildTask.GetAwaiter().GetResult()
                    if isNull generated then
                        // The core fills BuildFile with None before its FatalError reaches the router; wait long
                        // enough for that diagnostic (plus its grace) so rejections are reported as such.
                        if waiter.Task.Wait(TimeSpan.FromMilliseconds(float (fatalGraceMs + 4000))) then Error (waiter.Task.GetAwaiter().GetResult())
                        else Error "BuildFile returned no code and no diagnostic arrived"
                    else
                        let coreWrites = cached.IsNone && typedGenerated.IsNone
                        let coreText = generated
                        let generated =
                            match cached, typedGenerated with
                            | Some _, _ -> generated
                            | None, Some _ -> generated
                            | None, None when (backend = "Rust" || backend = "Delphi") && not (translatedBackend backend) -> generated
                            | None, None -> lowerPortableBackend backend generated
                        let revisionMode =
                            match cached, typedGenerated with
                            | Some _, _ -> "cache-hit"
                            | None, Some _ -> "typed-source"
                            | None, None -> revisionMode
                        let parent = Path.GetDirectoryName outputPath
                        if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                        let coreFile = Path.ChangeExtension(inputPath, Path.GetExtension outputPath)
                        if coreWrites && not portable && String.Equals(Path.GetFullPath coreFile, outputPath, StringComparison.OrdinalIgnoreCase) then
                            // The output is the core's own file: one writer.
                            if not (awaitCoreWrite outputPath generated) then writeWithRetry outputPath generated 0
                        else
                            writeWithRetry outputPath generated 0
                            // Let the core's intermediate C land before restoreC puts the previous one back.
                            if coreWrites && cOwned then awaitCoreWrite cPath coreText |> ignore
                        let binding =
                            match cached with
                            | Some cached -> cached.binding
                            | None when String.Equals(backend, "Fsharp", StringComparison.Ordinal) -> discoverEntryBinding generated
                            | None -> "main"
                        cache.Put(uri, backend, fingerprint, generated, binding)
                        writeEntryManifest outputPath binding generated.Length revisionMode backend
                        Ok (generated.Length, binding, revisionMode)
            finally
                router.Clear waiter
                restoreC ()
        with error -> Error error.Message

    let private findMatchingRustBrace (text : string) openIndex =
        let mutable depth = 0
        let mutable index = openIndex
        let mutable result = -1
        while index < text.Length && result < 0 do
            match text.[index] with
            | '{' -> depth <- depth + 1
            | '}' ->
                depth <- depth - 1
                if depth = 0 then result <- index
            | _ -> ()
            index <- index + 1
        if result < 0 then failwith "canonical plan IR lowering found an unbalanced Rust function body"
        result

    let private decodeRustStringLiteral (literal : string) =
        let value = System.Text.Json.JsonSerializer.Deserialize<string>(literal)
        if isNull value then failwith "canonical plan IR contains a null Rust string literal"
        value

    let private planFieldHex (value : string) =
        Convert.ToHexString(Encoding.UTF8.GetBytes value).ToLowerInvariant()

    let private lowerPlanIrManifest (code : string) =
        let argument = "(?:\\\"(?:\\\\.|[^\\\"\\\\])*\\\"|v[0-9]+(?:\\.clone\\(\\))?)"
        let marker = Regex(
            "(?m)^[ \\t]*RustPlanOp\\((?<op>" + argument + "),[ \\t]*(?<target>" + argument + "),[ \\t]*(?<expected>" + argument + "),[ \\t]*(?<payload>" + argument + "),[ \\t]*(?<effect>" + argument + ")\\);[ \\t]*\\r?$",
            RegexOptions.CultureInvariant)
        let binding = Regex(
            "(?m)^[ \\t]*let (?<name>v[0-9]+): Rc<str> = Rc::<str>::from\\((?<value>\\\"(?:\\\\.|[^\\\"\\\\])*\\\")\\);[ \\t]*\\r?$",
            RegexOptions.CultureInvariant)
        let spiralMain = Regex.Match(code, "(?m)^fn spiral_main\\(\\) -> i32 \\{")
        if not spiralMain.Success then failwith "canonical plan IR lowering could not locate spiral_main"
        // The emitter writes top-level closing braces at column zero and escapes newlines
        // in literals. Do not count braces inside a plan's string payload.
        let bodyMatch = Regex.Match(code.Substring(spiralMain.Index), @"(?ms)^fn spiral_main\(\) -> i32 \{\r?\n(?<body>.*?)^\}")
        if not bodyMatch.Success then failwith "canonical plan IR has no complete entry body"
        let spiralBody = bodyMatch.Groups.["body"].Value
        let markers = marker.Matches spiralBody
        if markers.Count = 0 then failwith "canonical plan IR provider emitted no RustPlanOp markers"
        if marker.Matches(code).Count <> markers.Count then
            failwith "canonical plan IR markers must be contained entirely in spiral_main"
        let remainder = binding.Replace(marker.Replace(spiralBody, ""), "").Trim()
        if not (Regex.IsMatch(remainder, @"\A(?:return\s+)?0;?\z")) then
            failwith "canonical plan IR requires unconditional markers and a zero return; runtime control flow or unresolved operations are not attestable"
        let bindings =
            binding.Matches spiralBody
            |> Seq.cast<Match>
            |> Seq.map (fun item -> item.Groups.["name"].Value, item.Groups.["value"].Value |> decodeRustStringLiteral)
            |> Map.ofSeq
        let resolve (raw : string) =
            if raw.StartsWith("\"") then decodeRustStringLiteral raw
            else
                let name = raw.Split('.')[0]
                match Map.tryFind name bindings with
                | Some value -> value
                | None -> failwith $"canonical plan IR references an unresolved generated string binding: {raw}"
        let rows =
            markers
            |> Seq.cast<Match>
            |> Seq.map (fun item ->
                [| "op"
                   item.Groups.["op"].Value |> resolve |> planFieldHex
                   item.Groups.["target"].Value |> resolve |> planFieldHex
                   item.Groups.["expected"].Value |> resolve |> planFieldHex
                   item.Groups.["payload"].Value |> resolve |> planFieldHex
                   item.Groups.["effect"].Value |> resolve |> planFieldHex |]
                |> String.concat "\t")
            |> Seq.toArray
        String.concat Environment.NewLine (Array.append [| "EOIE-PLAN-IR\t1" |] rows) + Environment.NewLine

    let private temporaryAttestationPath extension =
        Path.Combine(Path.GetTempPath(), $"spiral-attestation-{Guid.NewGuid():N}{extension}")

    let private deleteAttestationArtifacts outputPath =
        for path in [ outputPath; outputPath + ".spiral-entry" ] do
            try if File.Exists path then File.Delete path with _ -> ()

    let private runCheck inputPath =
#if SPIRAL_CORE_HOPAC
        eprintfn "Package attestation currently requires the single-flight compiler"
        5
#else
        try
            let inputPath = inputPath |> Path.GetFullPath |> SpiralFileSystem.standardize_path
            if not (File.Exists inputPath) then failwith $"Missing check input: {inputPath}"
            let rec findOwner (directory : DirectoryInfo) =
                if isNull directory then failwith $"Cannot find package.spiproj for {inputPath}"
                let candidate = directory.FullName |> SpiralFileSystem.standardize_path
                if File.Exists(spiproj_suffix candidate) then candidate else findOwner directory.Parent
            let packageDir = findOwner (Directory.GetParent inputPath)
            let emptyState : SupervisorState =
                { packages = Map.empty; modules = Map.empty
                  packages_infer = {ok = Map.empty; error = Map.empty}
                  packages_prepass = {ok = Map.empty; error = Map.empty}
                  graph = mirrored_graph_empty; package_ids = Map.empty, Map.empty }
            let _, state = proj_open (startupParse [|"--port"; "0"|]) emptyState (packageDir, None)
            if not state.packages_infer.error.IsEmpty then failwith $"Package graph rejected: {packageDir}"
            let pid = (fst state.package_ids).[packageDir]
            let package = state.packages_infer.ok.[pid]
            let rec containsInput = function
                | ProjFilesTree.File(_, path, _) -> String.Equals(path, inputPath, StringComparison.Ordinal)
                | ProjFilesTree.Directory(_, _, children) -> List.exists containsInput children
            if not (package.files.files.tree |> List.exists containsInput) then
                failwith $"Check input is not declared in package: {inputPath}"
            // Force the entire package result, including dependencies and modules after the input.
            // No specialization or code generation: package-only modules need no main binding.
            let hasError, _ = Hopac.run package.result
            if hasError then failwith $"Package typecheck rejected: {packageDir}"
            printfn "checked package %s" packageDir
            0
        with error ->
            eprintfn "%s" error.Message
            5
#endif

    let private runAttestationBounded timeoutMs work =
        let mutable result = 5
        let thread = Threading.Thread(Threading.ThreadStart(fun () ->
            try result <- work ()
            with error -> eprintfn "%s" error.Message), 64 * 1024 * 1024)
        thread.IsBackground <- true
        thread.Start()
        if thread.Join(timeoutMs : int) then result
        else
            eprintfn "Attestation timed out after %d ms" timeoutMs
            3

    let private runPlanIr inputPath outputPath =
        let generatedPath = temporaryAttestationPath ".rs"
        let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
        let router = DiagnosticRouter()
        let revisions = SourceRevisionStore()
        let cache = CompilationCache()
        startDiagnosticPump server.errors router
        try
            try
                match compileOne server.supervisor router revisions cache server.job_val "Rust" inputPath generatedPath with
                | Error message -> eprintfn "%s" message; 5
                | Ok _ ->
                    let manifest = lowerPlanIrManifest (File.ReadAllText generatedPath)
                    let parent = Path.GetDirectoryName(Path.GetFullPath outputPath)
                    if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                    File.WriteAllText(outputPath, manifest, UTF8Encoding(false))
                    printfn "compiled canonical plan IR %s -> %s" inputPath outputPath
                    0
            with error ->
                eprintfn "%s" error.Message
                5
        finally
            deleteAttestationArtifacts generatedPath

    let private cleanProtocolText (value : string) =
        value.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ')

    let private backendOfOutput (output : string) =
        match Path.GetExtension(output).ToLowerInvariant() with
        | ".fsx" | ".fs" -> "Fsharp"
        | ".c" -> "C"
        | ".rs" -> "Rust"
        | ".pas" | ".dpr" -> "Delphi"
        | ".py" -> "Python + Cuda"
        | ".cpp" -> "Cpp + Cuda"
        | ".lua" -> "Lua"
        | ".gleam" -> "Gleam"
        | other -> failwith $"cannot infer a backend from output extension '{other}'; pass --backend"

    /// Where a timed-out compile stopped. The Hopac core exposes its last BuildFile stage lock-free, so this
    /// works even when the Hopac scheduler is wedged and the core's own watchdog cannot report.
    let private stallDetail () =
#if SPIRAL_CORE_HOPAC
        try $"; stalled at stage {buildFileInitializationStageNow ()}" with _ -> ""
#else
        ""
#endif

    /// Compiles every job of a TSV (id, backend, input.spi, output) in one warm process.
    /// Each result row is appended and flushed as soon as the job finishes, so a caller can
    /// resume after a crash from the first job without a row. A job that exceeds the timeout
    /// is recorded and the process exits, because the supervisor may be wedged behind it.
    let private runBatch (jobsPath : string) (resultsPath : string) (timeoutMs : int) =
        let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
        let router = DiagnosticRouter()
        let revisions = SourceRevisionStore()
        let cache = CompilationCache()
        startDiagnosticPump server.errors router
        let jobs =
            File.ReadAllLines jobsPath
            |> Array.filter (fun line -> not (String.IsNullOrWhiteSpace line) && not (line.StartsWith "#"))
        let budgetFromCaller = not (String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable "SPIRAL_BUILD_BUDGET_MS"))
        use results = new StreamWriter(resultsPath, true, UTF8Encoding(false))
        results.AutoFlush <- true
        let mutable exitCode = 0
        let mutable index = 0
        let mutable timedOut = false
        while not timedOut && index < jobs.Length do
            let fields = jobs.[index].Split('\t')
            let id, backend, input, output = fields.[0], fields.[1], fields.[2], fields.[3]
            // Optional fifth column: per-job timeout in milliseconds (fast samples get seconds, mega samples minutes).
            let jobTimeoutMs = if fields.Length >= 5 && not (String.IsNullOrWhiteSpace fields.[4]) then int fields.[4] else timeoutMs
            // Give the core a build deadline 3 s before the job timeout, so a stalled Hopac evaluation reports
            // its own diagnostic before the host gives up. It is absolute (TickCount64) because the job clock
            // also covers opening the file and warming the `core` package, which happen before BuildFile.
            // The single-flight core ignores it. An explicit SPIRAL_BUILD_BUDGET_MS from the caller wins.
            if not budgetFromCaller then
                Environment.SetEnvironmentVariable("SPIRAL_BUILD_DEADLINE_MS", string (Environment.TickCount64 + int64 (max 1000 (jobTimeoutMs - 3000))))
            let stopwatch = Diagnostics.Stopwatch.StartNew()
            let work = Threading.Tasks.Task.Run(fun () -> compileOne server.supervisor router revisions cache server.job_val backend input output)
            try
                if work.Wait jobTimeoutMs then
                    match work.Result with
                    | Ok (bytes, binding, revisionMode) ->
                        results.WriteLine($"{id}\tok\t{stopwatch.ElapsedMilliseconds}\tbytes={bytes} entry={binding} revision={revisionMode}")
                    | Error message ->
                        exitCode <- 1
                        results.WriteLine($"{id}\terror\t{stopwatch.ElapsedMilliseconds}\t{cleanProtocolText message}")
                else
                    exitCode <- 3
                    timedOut <- true
                    results.WriteLine($"{id}\ttimeout\t{stopwatch.ElapsedMilliseconds}\tno result within {jobTimeoutMs} ms{stallDetail ()}")
            with error ->
                exitCode <- 1
                results.WriteLine($"{id}\terror\t{stopwatch.ElapsedMilliseconds}\t{cleanProtocolText error.Message}")
            index <- index + 1
        exitCode

    let private runServer socketPath _initialInput =
        let socketPath = Path.GetFullPath socketPath
        let parent = Path.GetDirectoryName socketPath
        if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
        if File.Exists socketPath then File.Delete socketPath
        let pidPath = socketPath + ".pid"
        use listener = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified)
        listener.Bind(UnixDomainSocketEndPoint(socketPath))
        listener.Listen(128)
        File.WriteAllText(pidPath, Environment.ProcessId.ToString())
        let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
        let router = DiagnosticRouter()
        let revisions = SourceRevisionStore()
        let cache = CompilationCache()
        startDiagnosticPump server.errors router
        printfn "spiral-session-ready socket=%s pid=%d" socketPath Environment.ProcessId
        Console.Out.Flush()
        try
            let mutable running = true
            while running do
                use client = listener.Accept()
                use stream = new NetworkStream(client, true)
                use reader = new StreamReader(stream, UTF8Encoding(false), false, 4096, true)
                use writer = new StreamWriter(stream, UTF8Encoding(false), 4096, true)
                writer.AutoFlush <- true
                match reader.ReadLine() with
                | null -> ()
                | line ->
                    let fields = line.Split('\t')
                    if fields.Length = 1 && fields.[0] = "quit" then
                        writer.WriteLine($"spiral-session\tquit\t{Environment.ProcessId}")
                        running <- false
                    elif (fields.Length = 3 || fields.Length = 4) && fields.[0] = "compile" then
                        let backend, input, output =
                            if fields.Length = 4 then fields.[1], fields.[2], fields.[3]
                            else "Fsharp", fields.[1], fields.[2]
                        match compileOne server.supervisor router revisions cache server.job_val backend input output with
                        | Ok (bytes, binding, revisionMode) ->
                            writer.WriteLine($"spiral-session\tok\t{Environment.ProcessId}\t{bytes}\t{binding}\t{revisionMode}\t{backend}")
                        | Error message ->
                            writer.WriteLine($"spiral-session\terror\t{Environment.ProcessId}\t{cleanProtocolText message}")
                    else
                        writer.WriteLine($"spiral-session\terror\t{Environment.ProcessId}\tinvalid request")
            0
        finally
            try File.Delete socketPath with _ -> ()
            try File.Delete pidPath with _ -> ()

    /// Determinism knobs for debugging the Hopac core. SPIRAL_HOPAC_WORKERS sets the Hopac scheduler's worker
    /// count (default: one per core) and SPIRAL_DOP caps the core's parallel map/iter helpers. With both at 1 a
    /// stall reproduces run after run, and a build that deadlocks only at 1 worker is blocking a worker thread.
    /// The scheduler must be configured before anything touches Scheduler.Global, so this runs first in main.
    let private configureHopacFromEnvironment () =
#if SPIRAL_CORE_HOPAC
        let positive name =
            match Int32.TryParse(Environment.GetEnvironmentVariable name) with
            | true, value when value > 0 -> Some value
            | _ -> None
        match positive "SPIRAL_HOPAC_WORKERS" with
        | Some workers -> Scheduler.Global.setCreate { Scheduler.Create.Def with NumWorkers = Some workers }
        | None -> ()
        match positive "SPIRAL_DOP" with
        | Some dop -> HopacExtensions.forceConcurrency dop
        | None -> ()
#else
        ()
#endif

    [<EntryPoint>]
    let main argv =
        configureHopacFromEnvironment ()
        if argv.Length = 1 && argv.[0] = "--version" then
            printfn "SpiralCompiler alpha418"
            0
        elif argv.Length = 6 && argv.[0] = "--lower-portable-project-package" then
            try
                let backend = argv.[1]
                let projectPath = Path.GetFullPath argv.[2]
                let entrySourcePath = Path.GetFullPath argv.[3]
                let inputPath = Path.GetFullPath argv.[4]
                let outputDirectory = Path.GetFullPath argv.[5]
                let generated = File.ReadAllText inputPath
                let files = PortableBackends.lowerPortableProjectPackage backend projectPath entrySourcePath generated
                let projectDirectory = Path.GetDirectoryName projectPath
                let projectIdentity = Path.Combine(projectDirectory, "package.spiproj") |> Path.GetFullPath
                Directory.CreateDirectory outputDirectory |> ignore
                for relativePath, content in files do
                    let platformRelative = relativePath.Replace('/', Path.DirectorySeparatorChar)
                    if Path.IsPathRooted platformRelative || platformRelative.Split(Path.DirectorySeparatorChar) |> Array.exists ((=) "..") then
                        failwith $"portable project package emitted an unsafe path: {relativePath}"
                    let outputPath = Path.Combine(outputDirectory, platformRelative)
                    let parent = Path.GetDirectoryName outputPath
                    if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                    File.WriteAllText(outputPath, content)
                let manifest =
                    [ "schema=3"
                      $"backend={backend}"
                      $"project={projectIdentity}"
                      $"entry={entrySourcePath}"
                      $"file_count={files.Length}"
                      yield! files |> List.map (fun (relativePath, content) -> $"file={relativePath}\tbytes={content.Length}") ]
                    |> String.concat "\n"
                File.WriteAllText(Path.Combine(outputDirectory, "spiral-package.tsv"), manifest + "\n")
                printfn "lowered portable project package %s -> %s (%s, %d files)" projectPath outputDirectory backend files.Length
                0
            with
            | PortableBackends.PortableProvenanceDiagnosticException(code, message) ->
                eprintfn "diagnostic-category=%s" code
                eprintfn "%s" message
                5
            | error ->
                eprintfn "%s" error.Message
                5
        elif argv.Length = 4 && argv.[0] = "--lower-portable-package" then
            try
                let backend = argv.[1]
                let inputPath = Path.GetFullPath argv.[2]
                let outputDirectory = Path.GetFullPath argv.[3]
                let generated = File.ReadAllText inputPath
                let files = PortableBackends.lowerPortablePackage backend generated
                Directory.CreateDirectory outputDirectory |> ignore
                for relativePath, content in files do
                    let platformRelative = relativePath.Replace('/', Path.DirectorySeparatorChar)
                    if Path.IsPathRooted platformRelative || platformRelative.Split(Path.DirectorySeparatorChar) |> Array.exists ((=) "..") then
                        failwith $"portable package emitted an unsafe path: {relativePath}"
                    let outputPath = Path.Combine(outputDirectory, platformRelative)
                    let parent = Path.GetDirectoryName outputPath
                    if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                    File.WriteAllText(outputPath, content)
                let manifest =
                    [ "schema=1"
                      $"backend={backend}"
                      $"file_count={files.Length}"
                      yield! files |> List.map (fun (relativePath, content) -> $"file={relativePath}\tbytes={content.Length}") ]
                    |> String.concat "\n"
                File.WriteAllText(Path.Combine(outputDirectory, "spiral-package.tsv"), manifest + "\n")
                printfn "lowered portable package %s -> %s (%s, %d files)" inputPath outputDirectory backend files.Length
                0
            with error ->
                eprintfn "%s" error.Message
                5
        elif argv.Length = 4 && argv.[0] = "--lower-portable" then
            try
                let backend = argv.[1]
                let inputPath = Path.GetFullPath argv.[2]
                let outputPath = Path.GetFullPath argv.[3]
                let generated = File.ReadAllText inputPath
                let lowered = lowerPortableBackend backend generated
                let parent = Path.GetDirectoryName outputPath
                if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                File.WriteAllText(outputPath, lowered)
                printfn "lowered %s -> %s (%s, %d bytes)" inputPath outputPath backend lowered.Length
                0
            with error ->
                eprintfn "%s" error.Message
                5
        elif argv.Length = 3 && argv.[0] = "--server" then
            runServer argv.[1] argv.[2]
        elif argv.Length = 2 && argv.[0] = "--check" then
            exit (runAttestationBounded 30000 (fun () -> runCheck argv.[1]))
        elif (argv.Length = 3 || (argv.Length = 5 && argv.[1] = "--timeout-ms")) && argv.[0] = "--plan-ir" then
            let inputIndex = if argv.Length = 5 then 3 else 1
            let outputIndex = if argv.Length = 5 then 4 else 2
            let parsed, timeoutMs = if argv.Length = 5 then Int32.TryParse argv.[2] else true, 30000
            if not parsed || timeoutMs <= 0 then
                eprintfn "--timeout-ms must be a positive 32-bit integer"
                2
            else
                exit (runAttestationBounded timeoutMs (fun () -> runPlanIr argv.[inputIndex] argv.[outputIndex]))
        elif (argv.Length = 3 || argv.Length = 5) && argv.[0] = "--batch" then
            let timeoutMs = if argv.Length = 5 && argv.[3] = "--timeout-ms" then int argv.[4] else 120000
            // Hard exit: a timed-out job leaves compiler threads running that would keep the process alive.
            exit (runBatch argv.[1] argv.[2] timeoutMs)
        elif argv.Length = 2 || (argv.Length = 4 && argv.[0] = "--backend") then
            let backend, input, output =
                if argv.Length = 4 then argv.[1], argv.[2], argv.[3]
                else backendOfOutput argv.[1], argv.[0], argv.[1]
            let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
            let router = DiagnosticRouter()
            let revisions = SourceRevisionStore()
            let cache = CompilationCache()
            startDiagnosticPump server.errors router
            let compileResult =
                if backend = "Fsharp" && String.Equals(Environment.GetEnvironmentVariable "SPIRAL_DIRECT_PROJECT_BUILD", "1", StringComparison.Ordinal) then
                    directProjectCompileFsharp input output
                else
                    compileOne server.supervisor router revisions cache server.job_val backend input output
            match compileResult with
            | Ok (bytes, binding, revisionMode) ->
                printfn "compiled %s -> %s (%s, %d bytes, entry=%s, revision=%s, pid=%d)" input output backend bytes binding revisionMode Environment.ProcessId
                0
            | Error message ->
                eprintfn "%s" message
                5
        else
            eprintfn "usage: SpiralCompiler [--backend Fsharp|C|Rust|Delphi] <input.spi> <output.fsx|.c|.rs|.pas> | --check INPUT.spi | --plan-ir [--timeout-ms N] INPUT.spi OUTPUT.ir | --batch JOBS.tsv RESULTS.tsv [--timeout-ms N] | --server SOCKET INPUT.spi | --lower-portable BACKEND INPUT.c OUTPUT | --lower-portable-package BACKEND INPUT.c OUTPUT_DIR | --lower-portable-project-package BACKEND PROJECT.spiproj ENTRY.spi INPUT.c OUTPUT_DIR"
            2
