namespace Polyglot

open System
open System.Text
open System.Text.RegularExpressions
open System.Collections.Generic

module PortableBackends =
    exception PortableProvenanceDiagnosticException of code : string * message : string

    let private failPortableProvenance code message =
        raise (PortableProvenanceDiagnosticException(code, message))

    type private TypedLayoutFieldStorage =
        | TypedScalarStorage
        | TypedStringStorage
        | TypedIntArrayStorage
        | TypedRecursiveOptionStorage
        | TypedManagedTupleStorage

    type private TypedLayoutField = {
        name : string
        rustType : string
        delphiType : string
        rustValue : string
        rustCompareValue : string
        delphiValue : string
        numeric : bool
        managed : bool
        storage : TypedLayoutFieldStorage
    }

    let private tryTypedLayoutField (name : string) (token : string) =
        let token = token.Trim()
        let integer = Regex.Match(token, "^(?<value>-?[0-9]+)(?<suffix>i8|i16|i32|i64|u8|u16|u32|u64)?$")
        let stringLiteral = Regex.Match(token, "^\"(?<value>[A-Za-z0-9 _-]*)\"$")
        let intArrayLiteral = Regex.Match(token, "^!{4}Array\((?<values>.*)\)$")
        let recursiveSomeLiteral = Regex.Match(token, "^!{4}RecursiveSome\((?<value>-?[0-9]+)(?:i32)?\)$")
        let recursiveChainLiteral = Regex.Match(token, "^!{4}RecursiveChain\((?<head>-?[0-9]+)(?:i32)?\s*,\s*(?<tail>-?[0-9]+)(?:i32)?\)$")
        let recursiveNoneLiteral = Regex.Match(token, "^!{4}RecursiveNone$")
        let managedTupleLiteral = Regex.Match(token, "^!{4}ManagedTuple\(\s*(?<option>!{4}Recursive(?:Some\([^)]*\)|None))\s*,\s*(?<score>-?[0-9]+)(?:i32)?\s*\)$")
        if integer.Success then
            let suffix =
                let value = integer.Groups.["suffix"].Value
                if String.IsNullOrWhiteSpace value then "i32" else value
            let rustType, delphiType =
                match suffix with
                | "i8" -> "i8", "ShortInt"
                | "i16" -> "i16", "SmallInt"
                | "i32" -> "i32", "LongInt"
                | "i64" -> "i64", "Int64"
                | "u8" -> "u8", "Byte"
                | "u16" -> "u16", "Word"
                | "u32" -> "u32", "LongWord"
                | "u64" -> "u64", "QWord"
                | value -> failwith $"unsupported typed layout scalar suffix: {value}"
            let rustValue = integer.Groups.["value"].Value + suffix
            Some {
                name = name
                rustType = rustType
                delphiType = delphiType
                rustValue = rustValue
                rustCompareValue = rustValue
                delphiValue = integer.Groups.["value"].Value
                numeric = true
                managed = false
                storage = TypedScalarStorage
            }
        elif String.Equals(token, "true", StringComparison.Ordinal) || String.Equals(token, "false", StringComparison.Ordinal) then
            Some {
                name = name
                rustType = "bool"
                delphiType = "Boolean"
                rustValue = token
                rustCompareValue = token
                delphiValue = if token = "true" then "True" else "False"
                numeric = false
                managed = false
                storage = TypedScalarStorage
            }
        elif stringLiteral.Success then
            let value = stringLiteral.Groups.["value"].Value
            Some {
                name = name
                rustType = "String"
                delphiType = "UnicodeString"
                rustValue = $"String::from({token})"
                rustCompareValue = token
                delphiValue = "'" + value.Replace("'", "''") + "'"
                numeric = false
                managed = true
                storage = TypedStringStorage
            }
        elif intArrayLiteral.Success then
            let rawValues = intArrayLiteral.Groups.["values"].Value.Trim()
            let values =
                if String.IsNullOrWhiteSpace rawValues then [||]
                else rawValues.Split(',', StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
            let parsed =
                values
                |> Array.map (fun value -> Regex.Match(value, "^(?<number>-?[0-9]+)(?:i32)?$"))
            if parsed |> Array.forall (fun value -> value.Success) then
                let numbers = parsed |> Array.map (fun value -> value.Groups.["number"].Value)
                let rustValues = numbers |> Array.map (fun value -> value + "i32") |> String.concat ", "
                let delphiValues = numbers |> String.concat ", "
                Some {
                    name = name
                    rustType = "Vec<i32>"
                    delphiType = "TSpiralIntArray"
                    rustValue = $"vec![{rustValues}]"
                    rustCompareValue = ""
                    delphiValue = $"[{delphiValues}]"
                    numeric = false
                    managed = true
                    storage = TypedIntArrayStorage
                }
            else None
        elif recursiveChainLiteral.Success then
            let head = recursiveChainLiteral.Groups.["head"].Value
            let tail = recursiveChainLiteral.Groups.["tail"].Value
            Some {
                name = name
                rustType = "Option<Rc<SpiralRecursiveNode>>"
                delphiType = "TSpiralRecursiveNode"
                rustValue = $"Some(Rc::new(SpiralRecursiveNode {{ value: {head}i32, next: Some(Rc::new(SpiralRecursiveNode {{ value: {tail}i32, next: None }})) }}))"
                rustCompareValue = ""
                delphiValue = $"TSpiralRecursiveNode.Create({head}, TSpiralRecursiveNode.Create({tail}, nil))"
                numeric = false
                managed = true
                storage = TypedRecursiveOptionStorage
            }
        elif recursiveSomeLiteral.Success then
            let value = recursiveSomeLiteral.Groups.["value"].Value
            Some {
                name = name
                rustType = "Option<Rc<SpiralRecursiveNode>>"
                delphiType = "TSpiralRecursiveNode"
                rustValue = $"Some(Rc::new(SpiralRecursiveNode {{ value: {value}i32, next: None }}))"
                rustCompareValue = ""
                delphiValue = $"TSpiralRecursiveNode.Create({value}, nil)"
                numeric = false
                managed = true
                storage = TypedRecursiveOptionStorage
            }
        elif recursiveNoneLiteral.Success then
            Some {
                name = name
                rustType = "Option<Rc<SpiralRecursiveNode>>"
                delphiType = "TSpiralRecursiveNode"
                rustValue = "None"
                rustCompareValue = ""
                delphiValue = "nil"
                numeric = false
                managed = true
                storage = TypedRecursiveOptionStorage
            }
        elif managedTupleLiteral.Success then
            let optionToken = managedTupleLiteral.Groups.["option"].Value
            let optionSome = Regex.Match(optionToken, "^!{4}RecursiveSome\\((?<value>-?[0-9]+)(?:i32)?\\)$")
            let rustOption, delphiOption =
                if optionSome.Success then
                    let value = optionSome.Groups.["value"].Value
                    $"Some(Rc::new(SpiralRecursiveNode {{ value: {value}i32, next: None }}))", $"TSpiralRecursiveNode.Create({value}, nil)"
                else "None", "nil"
            let score = managedTupleLiteral.Groups.["score"].Value
            Some {
                name = name
                rustType = "SpiralManagedTuple"
                delphiType = "TSpiralManagedTuple"
                rustValue = $"SpiralManagedTuple {{ item: {rustOption}, score: {score}i32 }}"
                rustCompareValue = ""
                delphiValue = $"TSpiralManagedTuple.Create({delphiOption}, {score})"
                numeric = false
                managed = true
                storage = TypedManagedTupleStorage
            }
        else None

    let private tryTypedLayoutFields (body : string) =
        let fields = ResizeArray<TypedLayoutField>()
        let mutable valid = true
        for raw in body.Split(';', StringSplitOptions.RemoveEmptyEntries) do
            let pieces = raw.Split('=', 2, StringSplitOptions.TrimEntries)
            if pieces.Length <> 2 || not (Regex.IsMatch(pieces.[0], "^[A-Za-z_][A-Za-z0-9_]*$")) then
                valid <- false
            else
                match tryTypedLayoutField pieces.[0] pieces.[1] with
                | Some field -> fields.Add field
                | None -> valid <- false
        if valid && fields.Count > 0 then Some(fields |> Seq.toList) else None

    let private sameTypedLayoutShape left right =
        List.length left = List.length right
        && List.forall2 (fun a b -> a.name = b.name && a.rustType = b.rustType && a.storage = b.storage) left right

    type private TypedLayoutKind =
        | TypedStackMutable
        | TypedStackRefs
        | TypedHeapRefs

    type private TypedComparison =
        | TypedLessThan
        | TypedLessThanOrEqual
        | TypedGreaterThan
        | TypedGreaterThanOrEqual
        | TypedEqual

    type private TypedLayoutStatement =
        | TypedWholeAssign of TypedLayoutField list
        | TypedFieldAssign of target : string * field : string * value : TypedLayoutField
        | TypedFieldAssignArrayLength of target : string * field : string * arrayTarget : string * arrayField : string
        | TypedFieldAssignArrayIndex of target : string * field : string * arrayTarget : string * arrayField : string * index : int
        | TypedFieldAssignOptionalValue of target : string * field : string * optionTarget : string * optionField : string
        | TypedFieldAssignOptionalNextValue of target : string * field : string * optionTarget : string * optionField : string
        | TypedFieldAssignTupleOptionalValue of target : string * field : string * tupleTarget : string * tupleField : string
        | TypedFieldAssignTupleScalar of target : string * field : string * tupleTarget : string * tupleField : string
        | TypedArraySet of target : string * field : string * index : int * value : int
        | TypedArrayResize of target : string * field : string * length : int * fill : int
        | TypedAlias of alias : string
        | TypedIfStart of comparison : TypedComparison * target : string * field : string * value : TypedLayoutField
        | TypedElse
        | TypedBlockEnd
        | TypedReturnAdd of leftTarget : string * leftField : string * rightTarget : string * rightField : string

    let private typedLayoutName = function
        | TypedStackMutable -> "stack_mut"
        | TypedStackRefs -> "stack_refs"
        | TypedHeapRefs -> "heap_refs"

    let private tryTypedLayoutKind = function
        | "StackMutable" -> Some TypedStackMutable
        | "StackRefs" -> Some TypedStackRefs
        | "HeapRefs" -> Some TypedHeapRefs
        | _ -> None

    let private tryTypedComparison = function
        | "LessThan" -> Some TypedLessThan
        | "LessThanOrEqual" -> Some TypedLessThanOrEqual
        | "GreaterThan" -> Some TypedGreaterThan
        | "GreaterThanOrEqual" -> Some TypedGreaterThanOrEqual
        | "Equal" -> Some TypedEqual
        | _ -> None

    let private rustTypedComparison = function
        | TypedLessThan -> "<"
        | TypedLessThanOrEqual -> "<="
        | TypedGreaterThan -> ">"
        | TypedGreaterThanOrEqual -> ">="
        | TypedEqual -> "=="

    let private delphiTypedComparison = function
        | TypedLessThan -> "<"
        | TypedLessThanOrEqual -> "<="
        | TypedGreaterThan -> ">"
        | TypedGreaterThanOrEqual -> ">="
        | TypedEqual -> "="

    let private leadingTypedIndent (line : string) =
        line
        |> Seq.takeWhile Char.IsWhiteSpace
        |> Seq.sumBy (fun value -> if value = '\t' then 4 else 1)

    let private tryTypedOperand (token : string) =
        let value = Regex.Match(token.Trim(), "^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)$")
        if value.Success then Some(value.Groups.["target"].Value, value.Groups.["field"].Value) else None

    let private typedLayoutFailure kind message =
        failwith $"typed {typedLayoutName kind} residual rejected: {message}"

    let private parseTypedLayoutSource (source : string) =
        let createPattern = Regex("^inl\\s+(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*!{4}LayoutTo(?<kind>StackMutable|StackRefs|HeapRefs)\\(\\{(?<fields>[^}]*)\\}\\)\\s*$")
        let wholeAssignPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*\\{(?<fields>[^}]*)\\}\\s*$")
        let fieldAssignArrayLengthPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}ArrayLength\\(\\s*(?<arrayTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<arrayField>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let fieldAssignArrayIndexPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}ArrayIndex\\(\\s*(?<arrayTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<arrayField>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<index>-?[0-9]+)(?:i32)?\\s*\\)\\s*$")
        let fieldAssignPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*(?<value>.+?)\\s*$")
        let arraySetPattern = Regex("^!{4}ArraySet\\(\\s*(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<index>-?[0-9]+)(?:i32)?\\s*,\\s*(?<value>-?[0-9]+)(?:i32)?\\s*\\)\\s*$")
        let arrayResizePattern = Regex("^!{4}ArrayResize\\(\\s*(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<length>-?[0-9]+)(?:i32)?\\s*,\\s*(?<fill>-?[0-9]+)(?:i32)?\\s*\\)\\s*$")
        let aliasPattern = Regex("^inl\\s+(?<alias>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*!{4}LayoutIndex\\(\\s*(?<target>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let returnPattern = Regex("^!{4}Add\\(\\s*(?<left>[^,]+)\\s*,\\s*(?<right>[^)]+)\\s*\\)\\s*$")
        let lines = source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let mutable create = None
        let statements = ResizeArray<TypedLayoutStatement>()
        let aliases = HashSet<string>(StringComparer.Ordinal)
        let mutable sawReturn = false
        for raw in lines do
            let line = raw.Trim()
            if String.IsNullOrWhiteSpace line || line.StartsWith("//", StringComparison.Ordinal) || Regex.IsMatch(line, "^inl\\s+main\\s*\\(\\)\\s*=") then ()
            else
                let createMatch = createPattern.Match line
                let wholeAssignMatch = wholeAssignPattern.Match line
                let fieldAssignMatch = fieldAssignPattern.Match line
                let aliasMatch = aliasPattern.Match line
                let returnMatch = returnPattern.Match line
                if createMatch.Success then
                    if create.IsSome then failwith "typed layout residual supports one local layout root per function"
                    match tryTypedLayoutKind createMatch.Groups.["kind"].Value, tryTypedLayoutFields createMatch.Groups.["fields"].Value with
                    | Some kind, Some fields ->
                        let variable = createMatch.Groups.["var"].Value
                        if kind = TypedStackMutable && (fields |> List.exists (fun field -> field.managed)) then
                            typedLayoutFailure kind "managed fields require reference-layout storage"
                        aliases.Add variable |> ignore
                        create <- Some(kind, variable, fields)
                    | _ -> failwith "typed layout residual requires a non-empty scalar record initializer"
                elif wholeAssignMatch.Success then
                    match create with
                    | None -> failwith "typed layout assignment appeared before its local root"
                    | Some(kind, variable, initialFields) ->
                        let target = wholeAssignMatch.Groups.["target"].Value
                        if kind <> TypedStackMutable then typedLayoutFailure kind "whole-record replacement is not a reference-layout operation"
                        if target <> variable then typedLayoutFailure kind $"whole-record replacement targets unknown root '{target}'"
                        match tryTypedLayoutFields wholeAssignMatch.Groups.["fields"].Value with
                        | Some fields when sameTypedLayoutShape initialFields fields -> statements.Add(TypedWholeAssign fields)
                        | _ -> typedLayoutFailure kind "whole-record replacement changed the scalar layout shape"
                elif fieldAssignMatch.Success then
                    match create with
                    | None -> failwith "typed layout field assignment appeared before its local root"
                    | Some(kind, _, initialFields) ->
                        let target = fieldAssignMatch.Groups.["target"].Value
                        let fieldName = fieldAssignMatch.Groups.["field"].Value
                        if not (aliases.Contains target) then typedLayoutFailure kind $"field assignment targets unknown local alias '{target}'"
                        match initialFields |> List.tryFind (fun field -> field.name = fieldName), tryTypedLayoutField fieldName fieldAssignMatch.Groups.["value"].Value with
                        | Some expected, Some value when expected.rustType = value.rustType -> statements.Add(TypedFieldAssign(target, fieldName, value))
                        | Some _, Some _ -> typedLayoutFailure kind $"field assignment changed the scalar type of '{fieldName}'"
                        | Some _, None -> typedLayoutFailure kind $"field assignment for '{fieldName}' is not a scalar literal"
                        | None, _ -> typedLayoutFailure kind $"field assignment names unknown field '{fieldName}'"
                elif aliasMatch.Success then
                    match create with
                    | None -> failwith "typed layout index appeared before its local root"
                    | Some(kind, variable, _) ->
                        let target = aliasMatch.Groups.["target"].Value
                        let alias = aliasMatch.Groups.["alias"].Value
                        if target <> variable then typedLayoutFailure kind "LayoutIndex currently accepts the root layout value only"
                        if not (aliases.Add alias) then typedLayoutFailure kind $"duplicate local alias '{alias}'"
                        statements.Add(TypedAlias alias)
                elif returnMatch.Success then
                    match create, tryTypedOperand returnMatch.Groups.["left"].Value, tryTypedOperand returnMatch.Groups.["right"].Value with
                    | Some(kind, _, fields), Some(leftTarget, leftField), Some(rightTarget, rightField) ->
                        if sawReturn then typedLayoutFailure kind "multiple terminal expressions are not supported"
                        if not (aliases.Contains leftTarget) || not (aliases.Contains rightTarget) then typedLayoutFailure kind "terminal expression reads an unknown local alias"
                        let fieldMap = fields |> List.map (fun field -> field.name, field) |> Map.ofList
                        match Map.tryFind leftField fieldMap, Map.tryFind rightField fieldMap with
                        | Some left, Some right when left.numeric && right.numeric ->
                            statements.Add(TypedReturnAdd(leftTarget, leftField, rightTarget, rightField))
                            sawReturn <- true
                        | _ -> typedLayoutFailure kind "terminal Add requires two known numeric fields"
                    | Some(kind, _, _), _, _ -> typedLayoutFailure kind "terminal expression must add two local layout fields"
                    | _ -> failwith "typed layout terminal expression appeared before its local root"
                else
                    match create with
                    | Some(kind, _, _) when aliases.Contains line -> typedLayoutFailure kind "layout references cannot escape their local main scope"
                    | Some(kind, _, _) -> typedLayoutFailure kind $"unsupported statement '{line}'"
                    | None -> ()
        match create with
        | None -> None
        | Some(kind, variable, fields) ->
            if not sawReturn then typedLayoutFailure kind "a terminal scalar Add is required to prove local non-escape"
            let parsed = statements |> Seq.toList
            match List.tryLast parsed with
            | Some(TypedReturnAdd _) -> Some(kind, variable, fields, parsed)
            | _ -> typedLayoutFailure kind "the scalar Add must be the final local statement"

    let private parseTypedLayoutSourceWithBlocks (source : string) =
        let createPattern = Regex("^inl\\s+(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*!{4}LayoutTo(?<kind>StackMutable|StackRefs|HeapRefs)\\(\\{(?<fields>[^}]*)\\}\\)\\s*$")
        let wholeAssignPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*\\{(?<fields>[^}]*)\\}\\s*$")
        let fieldAssignArrayLengthPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}ArrayLength\\(\\s*(?<arrayTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<arrayField>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let fieldAssignArrayIndexPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}ArrayIndex\\(\\s*(?<arrayTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<arrayField>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<index>-?[0-9]+)(?:i32)?\\s*\\)\\s*$")
        let fieldAssignOptionalValuePattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}OptionalValue\\(\\s*(?<optionTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<optionField>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let fieldAssignOptionalNextValuePattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}OptionalNextValue\\(\\s*(?<optionTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<optionField>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let fieldAssignTupleOptionalValuePattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}TupleOptionalValue\\(\\s*(?<tupleTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<tupleField>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let fieldAssignTupleScalarPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*!{4}TupleScalar\\(\\s*(?<tupleTarget>[A-Za-z_][A-Za-z0-9_]*)\\.(?<tupleField>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let fieldAssignPattern = Regex("^(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*<-\\s*(?<value>.+?)\\s*$")
        let arraySetPattern = Regex("^!{4}ArraySet\\(\\s*(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<index>-?[0-9]+)(?:i32)?\\s*,\\s*(?<value>-?[0-9]+)(?:i32)?\\s*\\)\\s*$")
        let arrayResizePattern = Regex("^!{4}ArrayResize\\(\\s*(?<target>[A-Za-z_][A-Za-z0-9_]*)\\.(?<field>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<length>-?[0-9]+)(?:i32)?\\s*,\\s*(?<fill>-?[0-9]+)(?:i32)?\\s*\\)\\s*$")
        let aliasPattern = Regex("^inl\\s+(?<alias>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*!{4}LayoutIndex\\(\\s*(?<target>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
        let ifPattern = Regex("^if\\s+!{4}(?<comparison>LessThan|LessThanOrEqual|GreaterThan|GreaterThanOrEqual|Equal)\\(\\s*(?<left>[^,]+)\\s*,\\s*(?<right>[^)]+)\\s*\\)\\s+then\\s*$")
        let returnPattern = Regex("^!{4}Add\\(\\s*(?<left>[^,]+)\\s*,\\s*(?<right>[^)]+)\\s*\\)\\s*$")
        let lines = source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let mutable create = None
        let statements = ResizeArray<TypedLayoutStatement>()
        let aliases = HashSet<string>(StringComparer.Ordinal)
        let blocks = Stack<int * bool>()
        let mutable sawReturn = false

        let closeBlocks indent =
            match create with
            | None -> ()
            | Some(kind, _, _) ->
                let mutable keepClosing = true
                while keepClosing && blocks.Count > 0 do
                    let blockIndent, sawElse = blocks.Peek()
                    if indent <= blockIndent then
                        blocks.Pop() |> ignore
                        if not sawElse then typedLayoutFailure kind "typed conditional requires an else branch before the join"
                        statements.Add TypedBlockEnd
                    else
                        keepClosing <- false

        for raw in lines do
            let line = raw.Trim()
            if String.IsNullOrWhiteSpace line || line.StartsWith("//", StringComparison.Ordinal) || Regex.IsMatch(line, "^inl\\s+main\\s*\\(\\)\\s*=") then ()
            else
                let indent = leadingTypedIndent raw
                if String.Equals(line, "else", StringComparison.Ordinal) then
                    match create with
                    | None -> () // Ordinary prelude branches do not belong to the typed-layout parser until a local root is declared.
                    | Some(kind, _, _) ->
                        while blocks.Count > 0 && fst (blocks.Peek()) > indent do
                            let _, nestedSawElse = blocks.Pop()
                            if not nestedSawElse then typedLayoutFailure kind "typed conditional requires an else branch before the join"
                            statements.Add TypedBlockEnd
                        if blocks.Count = 0 then typedLayoutFailure kind "else has no matching typed conditional"
                        let blockIndent, sawElse = blocks.Pop()
                        if indent <> blockIndent then typedLayoutFailure kind "else indentation does not match its typed conditional"
                        if sawElse then typedLayoutFailure kind "typed conditional contains multiple else branches"
                        blocks.Push((blockIndent, true))
                        statements.Add TypedElse
                else
                    closeBlocks indent
                    match create with
                    | Some(kind, _, _) when sawReturn -> typedLayoutFailure kind "statements after the terminal scalar Add are not supported"
                    | _ -> ()
                    let createMatch = createPattern.Match line
                    let wholeAssignMatch = wholeAssignPattern.Match line
                    let fieldAssignArrayLengthMatch = fieldAssignArrayLengthPattern.Match line
                    let fieldAssignArrayIndexMatch = fieldAssignArrayIndexPattern.Match line
                    let fieldAssignOptionalValueMatch = fieldAssignOptionalValuePattern.Match line
                    let fieldAssignOptionalNextValueMatch = fieldAssignOptionalNextValuePattern.Match line
                    let fieldAssignTupleOptionalValueMatch = fieldAssignTupleOptionalValuePattern.Match line
                    let fieldAssignTupleScalarMatch = fieldAssignTupleScalarPattern.Match line
                    let fieldAssignMatch = fieldAssignPattern.Match line
                    let arraySetMatch = arraySetPattern.Match line
                    let arrayResizeMatch = arrayResizePattern.Match line
                    let aliasMatch = aliasPattern.Match line
                    let ifMatch = ifPattern.Match line
                    let returnMatch = returnPattern.Match line
                    if createMatch.Success then
                        if create.IsSome then failwith "typed layout residual supports one local layout root per function"
                        match tryTypedLayoutKind createMatch.Groups.["kind"].Value, tryTypedLayoutFields createMatch.Groups.["fields"].Value with
                        | Some kind, Some fields ->
                            let variable = createMatch.Groups.["var"].Value
                            if kind = TypedStackMutable && (fields |> List.exists (fun field -> field.managed)) then
                                typedLayoutFailure kind "managed fields require reference-layout storage"
                            aliases.Add variable |> ignore
                            create <- Some(kind, variable, fields)
                        | _ -> failwith "typed layout residual requires a non-empty scalar record initializer"
                    elif ifMatch.Success then
                        match create, tryTypedComparison ifMatch.Groups.["comparison"].Value, tryTypedOperand ifMatch.Groups.["left"].Value with
                        | Some(kind, _, fields), Some comparison, Some(target, fieldName) ->
                            if not (aliases.Contains target) then typedLayoutFailure kind "typed conditional reads an unknown local alias"
                            match fields |> List.tryFind (fun field -> field.name = fieldName), tryTypedLayoutField fieldName ifMatch.Groups.["right"].Value with
                            | Some expected, Some value when (expected.storage = TypedScalarStorage || expected.storage = TypedStringStorage) && expected.rustType = value.rustType && (comparison = TypedEqual || expected.numeric) ->
                                statements.Add(TypedIfStart(comparison, target, fieldName, value))
                                blocks.Push((indent, false))
                            | Some expected, Some _ when not expected.numeric && comparison <> TypedEqual ->
                                typedLayoutFailure kind "ordered typed comparisons require a numeric field"
                            | Some _, Some _ -> typedLayoutFailure kind $"typed conditional changed the scalar type of '{fieldName}'"
                            | Some _, None -> typedLayoutFailure kind $"typed conditional for '{fieldName}' requires a scalar literal"
                            | None, _ -> typedLayoutFailure kind $"typed conditional names unknown field '{fieldName}'"
                        | Some(kind, _, _), _, _ -> typedLayoutFailure kind "typed conditional must compare one local layout field with a scalar literal"
                        | _ -> failwith "typed layout conditional appeared before its local root"
                    elif wholeAssignMatch.Success then
                        match create with
                        | None -> failwith "typed layout assignment appeared before its local root"
                        | Some(kind, variable, initialFields) ->
                            let target = wholeAssignMatch.Groups.["target"].Value
                            if kind <> TypedStackMutable then typedLayoutFailure kind "whole-record replacement is not a reference-layout operation"
                            if target <> variable then typedLayoutFailure kind $"whole-record replacement targets unknown root '{target}'"
                            match tryTypedLayoutFields wholeAssignMatch.Groups.["fields"].Value with
                            | Some fields when sameTypedLayoutShape initialFields fields -> statements.Add(TypedWholeAssign fields)
                            | _ -> typedLayoutFailure kind "whole-record replacement changed the scalar layout shape"
                    elif fieldAssignArrayLengthMatch.Success then
                        match create with
                        | None -> failwith "typed layout array-length assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignArrayLengthMatch.Groups.["target"].Value
                            let fieldName = fieldAssignArrayLengthMatch.Groups.["field"].Value
                            let arrayTarget = fieldAssignArrayLengthMatch.Groups.["arrayTarget"].Value
                            let arrayField = fieldAssignArrayLengthMatch.Groups.["arrayField"].Value
                            if not (aliases.Contains target) || not (aliases.Contains arrayTarget) then typedLayoutFailure kind "array-length assignment reads an unknown local alias"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), initialFields |> List.tryFind (fun field -> field.name = arrayField) with
                            | Some destination, Some source when destination.rustType = "i32" && source.storage = TypedIntArrayStorage ->
                                statements.Add(TypedFieldAssignArrayLength(target, fieldName, arrayTarget, arrayField))
                            | Some _, Some source when source.storage <> TypedIntArrayStorage -> typedLayoutFailure kind $"ArrayLength requires an array field, got '{arrayField}'"
                            | Some _, Some _ -> typedLayoutFailure kind $"ArrayLength can only assign an i32 field, got '{fieldName}'"
                            | _ -> typedLayoutFailure kind "array-length assignment names an unknown field"
                    elif fieldAssignArrayIndexMatch.Success then
                        match create with
                        | None -> failwith "typed layout array-index assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignArrayIndexMatch.Groups.["target"].Value
                            let fieldName = fieldAssignArrayIndexMatch.Groups.["field"].Value
                            let arrayTarget = fieldAssignArrayIndexMatch.Groups.["arrayTarget"].Value
                            let arrayField = fieldAssignArrayIndexMatch.Groups.["arrayField"].Value
                            let index = Int32.Parse(fieldAssignArrayIndexMatch.Groups.["index"].Value)
                            if index < 0 then typedLayoutFailure kind "ArrayIndex requires a non-negative index"
                            if not (aliases.Contains target) || not (aliases.Contains arrayTarget) then typedLayoutFailure kind "array-index assignment reads an unknown local alias"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), initialFields |> List.tryFind (fun field -> field.name = arrayField) with
                            | Some destination, Some source when destination.rustType = "i32" && source.storage = TypedIntArrayStorage ->
                                statements.Add(TypedFieldAssignArrayIndex(target, fieldName, arrayTarget, arrayField, index))
                            | Some _, Some source when source.storage <> TypedIntArrayStorage -> typedLayoutFailure kind $"ArrayIndex requires an array field, got '{arrayField}'"
                            | Some _, Some _ -> typedLayoutFailure kind $"ArrayIndex can only assign an i32 field, got '{fieldName}'"
                            | _ -> typedLayoutFailure kind "array-index assignment names an unknown field"
                    elif fieldAssignOptionalValueMatch.Success then
                        match create with
                        | None -> failwith "typed layout optional-value assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignOptionalValueMatch.Groups.["target"].Value
                            let fieldName = fieldAssignOptionalValueMatch.Groups.["field"].Value
                            let optionTarget = fieldAssignOptionalValueMatch.Groups.["optionTarget"].Value
                            let optionField = fieldAssignOptionalValueMatch.Groups.["optionField"].Value
                            if not (aliases.Contains target) || not (aliases.Contains optionTarget) then typedLayoutFailure kind "optional-value assignment reads an unknown local alias"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), initialFields |> List.tryFind (fun field -> field.name = optionField) with
                            | Some destination, Some source when destination.rustType = "i32" && source.storage = TypedRecursiveOptionStorage ->
                                statements.Add(TypedFieldAssignOptionalValue(target, fieldName, optionTarget, optionField))
                            | Some _, Some source when source.storage <> TypedRecursiveOptionStorage -> typedLayoutFailure kind $"OptionalValue requires a recursive option field, got '{optionField}'"
                            | Some _, Some _ -> typedLayoutFailure kind $"OptionalValue can only assign an i32 field, got '{fieldName}'"
                            | _ -> typedLayoutFailure kind "optional-value assignment names an unknown field"
                    elif fieldAssignOptionalNextValueMatch.Success then
                        match create with
                        | None -> failwith "typed layout optional-next assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignOptionalNextValueMatch.Groups.["target"].Value
                            let fieldName = fieldAssignOptionalNextValueMatch.Groups.["field"].Value
                            let optionTarget = fieldAssignOptionalNextValueMatch.Groups.["optionTarget"].Value
                            let optionField = fieldAssignOptionalNextValueMatch.Groups.["optionField"].Value
                            if not (aliases.Contains target) || not (aliases.Contains optionTarget) then typedLayoutFailure kind "optional-next assignment reads an unknown local alias"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), initialFields |> List.tryFind (fun field -> field.name = optionField) with
                            | Some destination, Some source when destination.rustType = "i32" && source.storage = TypedRecursiveOptionStorage ->
                                statements.Add(TypedFieldAssignOptionalNextValue(target, fieldName, optionTarget, optionField))
                            | Some _, Some source when source.storage <> TypedRecursiveOptionStorage -> typedLayoutFailure kind $"OptionalNextValue requires a recursive option field, got '{optionField}'"
                            | Some _, Some _ -> typedLayoutFailure kind $"OptionalNextValue can only assign an i32 field, got '{fieldName}'"
                            | _ -> typedLayoutFailure kind "optional-next assignment names an unknown field"
                    elif fieldAssignTupleOptionalValueMatch.Success then
                        match create with
                        | None -> failwith "typed layout tuple-option assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignTupleOptionalValueMatch.Groups.["target"].Value
                            let fieldName = fieldAssignTupleOptionalValueMatch.Groups.["field"].Value
                            let tupleTarget = fieldAssignTupleOptionalValueMatch.Groups.["tupleTarget"].Value
                            let tupleField = fieldAssignTupleOptionalValueMatch.Groups.["tupleField"].Value
                            if not (aliases.Contains target) || not (aliases.Contains tupleTarget) then typedLayoutFailure kind "tuple-option assignment reads an unknown local alias"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), initialFields |> List.tryFind (fun field -> field.name = tupleField) with
                            | Some destination, Some source when destination.rustType = "i32" && source.storage = TypedManagedTupleStorage ->
                                statements.Add(TypedFieldAssignTupleOptionalValue(target, fieldName, tupleTarget, tupleField))
                            | Some _, Some source when source.storage <> TypedManagedTupleStorage -> typedLayoutFailure kind $"TupleOptionalValue requires a managed tuple field, got '{tupleField}'"
                            | Some _, Some _ -> typedLayoutFailure kind $"TupleOptionalValue can only assign an i32 field, got '{fieldName}'"
                            | _ -> typedLayoutFailure kind "tuple-option assignment names an unknown field"
                    elif fieldAssignTupleScalarMatch.Success then
                        match create with
                        | None -> failwith "typed layout tuple-scalar assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignTupleScalarMatch.Groups.["target"].Value
                            let fieldName = fieldAssignTupleScalarMatch.Groups.["field"].Value
                            let tupleTarget = fieldAssignTupleScalarMatch.Groups.["tupleTarget"].Value
                            let tupleField = fieldAssignTupleScalarMatch.Groups.["tupleField"].Value
                            if not (aliases.Contains target) || not (aliases.Contains tupleTarget) then typedLayoutFailure kind "tuple-scalar assignment reads an unknown local alias"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), initialFields |> List.tryFind (fun field -> field.name = tupleField) with
                            | Some destination, Some source when destination.rustType = "i32" && source.storage = TypedManagedTupleStorage ->
                                statements.Add(TypedFieldAssignTupleScalar(target, fieldName, tupleTarget, tupleField))
                            | Some _, Some source when source.storage <> TypedManagedTupleStorage -> typedLayoutFailure kind $"TupleScalar requires a managed tuple field, got '{tupleField}'"
                            | Some _, Some _ -> typedLayoutFailure kind $"TupleScalar can only assign an i32 field, got '{fieldName}'"
                            | _ -> typedLayoutFailure kind "tuple-scalar assignment names an unknown field"
                    elif arraySetMatch.Success then
                        match create with
                        | None -> failwith "typed layout array set appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = arraySetMatch.Groups.["target"].Value
                            let fieldName = arraySetMatch.Groups.["field"].Value
                            let index = Int32.Parse(arraySetMatch.Groups.["index"].Value)
                            let value = Int32.Parse(arraySetMatch.Groups.["value"].Value)
                            if index < 0 then typedLayoutFailure kind "ArraySet requires a non-negative index"
                            if not (aliases.Contains target) then typedLayoutFailure kind $"ArraySet targets unknown local alias '{target}'"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName) with
                            | Some field when field.storage = TypedIntArrayStorage -> statements.Add(TypedArraySet(target, fieldName, index, value))
                            | Some _ -> typedLayoutFailure kind $"ArraySet requires an array field, got '{fieldName}'"
                            | None -> typedLayoutFailure kind $"ArraySet names unknown field '{fieldName}'"
                    elif arrayResizeMatch.Success then
                        match create with
                        | None -> failwith "typed layout array resize appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = arrayResizeMatch.Groups.["target"].Value
                            let fieldName = arrayResizeMatch.Groups.["field"].Value
                            let length = Int32.Parse(arrayResizeMatch.Groups.["length"].Value)
                            let fill = Int32.Parse(arrayResizeMatch.Groups.["fill"].Value)
                            if length < 0 then typedLayoutFailure kind "ArrayResize requires a non-negative length"
                            if not (aliases.Contains target) then typedLayoutFailure kind $"ArrayResize targets unknown local alias '{target}'"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName) with
                            | Some field when field.storage = TypedIntArrayStorage -> statements.Add(TypedArrayResize(target, fieldName, length, fill))
                            | Some _ -> typedLayoutFailure kind $"ArrayResize requires an array field, got '{fieldName}'"
                            | None -> typedLayoutFailure kind $"ArrayResize names unknown field '{fieldName}'"
                    elif fieldAssignMatch.Success then
                        match create with
                        | None -> failwith "typed layout field assignment appeared before its local root"
                        | Some(kind, _, initialFields) ->
                            let target = fieldAssignMatch.Groups.["target"].Value
                            let fieldName = fieldAssignMatch.Groups.["field"].Value
                            if not (aliases.Contains target) then typedLayoutFailure kind $"field assignment targets unknown local alias '{target}'"
                            match initialFields |> List.tryFind (fun field -> field.name = fieldName), tryTypedLayoutField fieldName fieldAssignMatch.Groups.["value"].Value with
                            | Some expected, Some value when expected.rustType = value.rustType && expected.storage = value.storage -> statements.Add(TypedFieldAssign(target, fieldName, value))
                            | Some _, Some _ -> typedLayoutFailure kind $"field assignment changed the typed layout field kind of '{fieldName}'"
                            | Some _, None -> typedLayoutFailure kind $"field assignment for '{fieldName}' is not a supported literal"
                            | None, _ -> typedLayoutFailure kind $"field assignment names unknown field '{fieldName}'"
                    elif aliasMatch.Success then
                        match create with
                        | None -> failwith "typed layout index appeared before its local root"
                        | Some(kind, variable, _) ->
                            if blocks.Count > 0 then typedLayoutFailure kind "branch-local aliases are not join-safe"
                            let target = aliasMatch.Groups.["target"].Value
                            let alias = aliasMatch.Groups.["alias"].Value
                            if target <> variable then typedLayoutFailure kind "LayoutIndex currently accepts the root layout value only"
                            if not (aliases.Add alias) then typedLayoutFailure kind $"duplicate local alias '{alias}'"
                            statements.Add(TypedAlias alias)
                    elif returnMatch.Success then
                        match create, tryTypedOperand returnMatch.Groups.["left"].Value, tryTypedOperand returnMatch.Groups.["right"].Value with
                        | Some(kind, _, fields), Some(leftTarget, leftField), Some(rightTarget, rightField) ->
                            if blocks.Count > 0 then typedLayoutFailure kind "terminal scalar Add must follow the typed control-flow join"
                            if sawReturn then typedLayoutFailure kind "multiple terminal expressions are not supported"
                            if not (aliases.Contains leftTarget) || not (aliases.Contains rightTarget) then typedLayoutFailure kind "terminal expression reads an unknown local alias"
                            let fieldMap = fields |> List.map (fun field -> field.name, field) |> Map.ofList
                            match Map.tryFind leftField fieldMap, Map.tryFind rightField fieldMap with
                            | Some left, Some right when left.numeric && right.numeric ->
                                statements.Add(TypedReturnAdd(leftTarget, leftField, rightTarget, rightField))
                                sawReturn <- true
                            | _ -> typedLayoutFailure kind "terminal Add requires two known numeric fields"
                        | Some(kind, _, _), _, _ -> typedLayoutFailure kind "terminal expression must add two local layout fields"
                        | _ -> failwith "typed layout terminal expression appeared before its local root"
                    else
                        match create with
                        | Some(kind, _, _) when aliases.Contains line -> typedLayoutFailure kind "layout references cannot escape their local main scope"
                        | Some(kind, _, _) -> typedLayoutFailure kind $"unsupported statement '{line}'"
                        | None -> ()

        closeBlocks Int32.MinValue
        match create with
        | None -> None
        | Some(kind, variable, fields) ->
            if not sawReturn then typedLayoutFailure kind "a terminal scalar Add is required to prove local non-escape"
            let parsed = statements |> Seq.toList
            match List.tryLast parsed with
            | Some(TypedReturnAdd _) -> Some(kind, variable, fields, parsed)
            | _ -> typedLayoutFailure kind "the scalar Add must be the final local statement"

    let private rustTypedFieldRead kind fields target field =
        let definition = fields |> List.find (fun candidate -> candidate.name = field)
        match kind, definition.storage with
        | TypedStackMutable, _ -> $"{target}.{field}"
        | (TypedStackRefs | TypedHeapRefs), TypedScalarStorage -> $"{target}.{field}.get()"
        | (TypedStackRefs | TypedHeapRefs), TypedStringStorage -> $"{target}.{field}.borrow().as_str()"
        | (TypedStackRefs | TypedHeapRefs), _ -> failwith $"typed layout field '{field}' requires a projection operation"

    let private delphiTypedFieldRead kind target field =
        match kind with
        | TypedStackMutable | TypedHeapRefs -> $"{target}.{field}"
        | TypedStackRefs -> $"{target}.{field}^"

    let private emitTypedRust kind variable fields statements =
        let output = StringBuilder()
        let aliases = statements |> List.choose (function TypedAlias alias -> Some alias | _ -> None)
        let mutated = statements |> List.choose (function TypedFieldAssign(target, _, _) -> Some target | _ -> None) |> Set.ofList
        let hasManaged = fields |> List.exists (fun field -> field.managed)
        let hasRecursiveOption = fields |> List.exists (fun field -> field.storage = TypedRecursiveOptionStorage)
        let hasManagedTuple = fields |> List.exists (fun field -> field.storage = TypedManagedTupleStorage)
        let hasRecursiveTypes = hasRecursiveOption || hasManagedTuple
        output.AppendLine($"// Generated by Spiral typed {typedLayoutName kind} residual bridge.") |> ignore
        match kind with
        | TypedStackMutable -> ()
        | TypedStackRefs | TypedHeapRefs ->
            if hasManaged then output.AppendLine("use std::cell::{Cell, RefCell};") |> ignore
            else output.AppendLine("use std::cell::Cell;") |> ignore
            if kind = TypedHeapRefs || hasRecursiveTypes then output.AppendLine("use std::rc::Rc;") |> ignore
            output.AppendLine() |> ignore
        if hasRecursiveTypes then
            output.AppendLine("#[allow(dead_code)]") |> ignore
            output.AppendLine("#[derive(Clone)]") |> ignore
            output.AppendLine("struct SpiralRecursiveNode {") |> ignore
            output.AppendLine("    value: i32,") |> ignore
            output.AppendLine("    next: Option<Rc<SpiralRecursiveNode>>,") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        if hasManagedTuple then
            output.AppendLine("#[derive(Clone)]") |> ignore
            output.AppendLine("struct SpiralManagedTuple {") |> ignore
            output.AppendLine("    item: Option<Rc<SpiralRecursiveNode>>,") |> ignore
            output.AppendLine("    score: i32,") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        match kind with
        | TypedStackMutable ->
            output.AppendLine("#[derive(Clone, Copy)]") |> ignore
            output.AppendLine("struct SpiralStackLayout {") |> ignore
        | TypedStackRefs ->
            output.AppendLine("#[derive(Clone, Copy)]") |> ignore
            output.AppendLine("struct SpiralStackRefs<'a> {") |> ignore
        | TypedHeapRefs ->
            output.AppendLine("struct SpiralHeapRefs {") |> ignore
        for field in fields do
            match kind, field.managed with
            | TypedStackMutable, _ -> output.AppendLine($"    {field.name}: {field.rustType},") |> ignore
            | TypedStackRefs, false -> output.AppendLine($"    {field.name}: &'a Cell<{field.rustType}>,") |> ignore
            | TypedStackRefs, true -> output.AppendLine($"    {field.name}: &'a RefCell<{field.rustType}>,") |> ignore
            | TypedHeapRefs, false -> output.AppendLine($"    {field.name}: Cell<{field.rustType}>,") |> ignore
            | TypedHeapRefs, true -> output.AppendLine($"    {field.name}: RefCell<{field.rustType}>,") |> ignore
        output.AppendLine("}") |> ignore
        if kind = TypedHeapRefs && hasManaged then
            output.AppendLine() |> ignore
            output.AppendLine("impl Drop for SpiralHeapRefs {") |> ignore
            output.AppendLine("    fn drop(&mut self) {") |> ignore
            for field in fields |> List.filter (fun field -> field.managed) do
                match field.storage with
                | TypedStringStorage | TypedIntArrayStorage -> output.AppendLine($"        self.{field.name}.get_mut().clear();") |> ignore
                | TypedRecursiveOptionStorage -> output.AppendLine($"        self.{field.name}.get_mut().take();") |> ignore
                | TypedManagedTupleStorage -> output.AppendLine($"        self.{field.name}.get_mut().item.take();") |> ignore
                | TypedScalarStorage -> ()
            output.AppendLine("    }") |> ignore
            output.AppendLine("}") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("fn spiral_main() -> i32 {") |> ignore
        match kind with
        | TypedStackMutable ->
            let rootMutated = mutated.Contains variable || statements |> List.exists (function TypedWholeAssign _ -> true | _ -> false)
            let rootPrefix = if rootMutated then "mut " else ""
            output.AppendLine($"    let {rootPrefix}{variable} = SpiralStackLayout {{") |> ignore
            for field in fields do output.AppendLine($"        {field.name}: {field.rustValue},") |> ignore
            output.AppendLine("    };") |> ignore
            output.AppendLine($"    let _ = &{variable};") |> ignore
        | TypedStackRefs ->
            for field in fields do
                let storage = if field.managed then "RefCell" else "Cell"
                output.AppendLine($"    let {variable}_{field.name}_storage = {storage}::new({field.rustValue});") |> ignore
            output.AppendLine($"    let {variable} = SpiralStackRefs {{") |> ignore
            for field in fields do output.AppendLine($"        {field.name}: &{variable}_{field.name}_storage,") |> ignore
            output.AppendLine("    };") |> ignore
        | TypedHeapRefs ->
            output.AppendLine($"    let {variable} = Rc::new(SpiralHeapRefs {{") |> ignore
            for field in fields do
                let storage = if field.managed then "RefCell" else "Cell"
                output.AppendLine($"        {field.name}: {storage}::new({field.rustValue}),") |> ignore
            output.AppendLine("    });") |> ignore
        let mutable blockDepth = 0
        let rustIndent () = String.replicate (blockDepth + 1) "    "
        for statement in statements do
            match statement with
            | TypedWholeAssign assigned ->
                let indent = rustIndent ()
                output.AppendLine($"{indent}{variable} = SpiralStackLayout {{") |> ignore
                for field in assigned do output.AppendLine($"{indent}    {field.name}: {field.rustValue},") |> ignore
                output.AppendLine($"{indent}}};") |> ignore
            | TypedFieldAssign(target, field, value) ->
                let indent = rustIndent ()
                match kind, value.managed with
                | TypedStackMutable, _ -> output.AppendLine($"{indent}{target}.{field} = {value.rustValue};") |> ignore
                | (TypedStackRefs | TypedHeapRefs), false -> output.AppendLine($"{indent}{target}.{field}.set({value.rustValue});") |> ignore
                | (TypedStackRefs | TypedHeapRefs), true ->
                    output.AppendLine($"{indent}{{") |> ignore
                    output.AppendLine($"{indent}    let next_value = {value.rustValue};") |> ignore
                    output.AppendLine($"{indent}    let old_value = {target}.{field}.replace(next_value);") |> ignore
                    output.AppendLine($"{indent}    drop(old_value);") |> ignore
                    output.AppendLine($"{indent}}}") |> ignore
            | TypedFieldAssignArrayLength(target, field, arrayTarget, arrayField) ->
                let indent = rustIndent ()
                let expression = $"{arrayTarget}.{arrayField}.borrow().len() as i32"
                match kind with
                | TypedStackMutable -> output.AppendLine($"{indent}{target}.{field} = {expression};") |> ignore
                | TypedStackRefs | TypedHeapRefs -> output.AppendLine($"{indent}{target}.{field}.set({expression});") |> ignore
            | TypedFieldAssignArrayIndex(target, field, arrayTarget, arrayField, index) ->
                let indent = rustIndent ()
                let expression = $"{arrayTarget}.{arrayField}.borrow()[{index}]"
                match kind with
                | TypedStackMutable -> output.AppendLine($"{indent}{target}.{field} = {expression};") |> ignore
                | TypedStackRefs | TypedHeapRefs -> output.AppendLine($"{indent}{target}.{field}.set({expression});") |> ignore
            | TypedFieldAssignOptionalValue(target, field, optionTarget, optionField) ->
                let expression = $"{optionTarget}.{optionField}.borrow().as_ref().map_or(0i32, |node| node.value)"
                output.AppendLine($"{rustIndent ()}{target}.{field}.set({expression});") |> ignore
            | TypedFieldAssignOptionalNextValue(target, field, optionTarget, optionField) ->
                let expression = $"{optionTarget}.{optionField}.borrow().as_ref().and_then(|node| node.next.as_ref()).map_or(0i32, |node| node.value)"
                output.AppendLine($"{rustIndent ()}{target}.{field}.set({expression});") |> ignore
            | TypedFieldAssignTupleOptionalValue(target, field, tupleTarget, tupleField) ->
                let expression = $"{tupleTarget}.{tupleField}.borrow().item.as_ref().map_or(0i32, |node| node.value)"
                output.AppendLine($"{rustIndent ()}{target}.{field}.set({expression});") |> ignore
            | TypedFieldAssignTupleScalar(target, field, tupleTarget, tupleField) ->
                let expression = $"{tupleTarget}.{tupleField}.borrow().score"
                output.AppendLine($"{rustIndent ()}{target}.{field}.set({expression});") |> ignore
            | TypedArraySet(target, field, index, value) ->
                output.AppendLine($"{rustIndent ()}{target}.{field}.borrow_mut()[{index}] = {value}i32;") |> ignore
            | TypedArrayResize(target, field, length, fill) ->
                output.AppendLine($"{rustIndent ()}{target}.{field}.borrow_mut().resize({length}usize, {fill}i32);") |> ignore
            | TypedAlias alias ->
                let indent = rustIndent ()
                match kind with
                | TypedStackMutable ->
                    let aliasPrefix = if mutated.Contains alias then "mut " else ""
                    output.AppendLine($"{indent}let {aliasPrefix}{alias} = {variable};") |> ignore
                | TypedStackRefs ->
                    output.AppendLine($"{indent}let {alias} = SpiralStackRefs {{") |> ignore
                    for field in fields do output.AppendLine($"{indent}    {field.name}: {variable}.{field.name},") |> ignore
                    output.AppendLine($"{indent}}};") |> ignore
                | TypedHeapRefs -> output.AppendLine($"{indent}let {alias} = Rc::clone(&{variable});") |> ignore
            | TypedIfStart(comparison, target, field, value) ->
                let indent = rustIndent ()
                output.AppendLine($"{indent}if {rustTypedFieldRead kind fields target field} {rustTypedComparison comparison} {value.rustCompareValue} {{") |> ignore
                blockDepth <- blockDepth + 1
            | TypedElse ->
                blockDepth <- blockDepth - 1
                let indent = rustIndent ()
                output.AppendLine($"{indent}}} else {{") |> ignore
                blockDepth <- blockDepth + 1
            | TypedBlockEnd ->
                blockDepth <- blockDepth - 1
                output.AppendLine($"{rustIndent ()}}}") |> ignore
            | TypedReturnAdd(leftTarget, leftField, rightTarget, rightField) ->
                output.AppendLine($"{rustIndent ()}({rustTypedFieldRead kind fields leftTarget leftField} + {rustTypedFieldRead kind fields rightTarget rightField}) as i32") |> ignore
        output.AppendLine("}") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("fn main() {") |> ignore
        output.AppendLine("    std::process::exit(spiral_main());") |> ignore
        output.AppendLine("}") |> ignore
        output.ToString()

    let private emitTypedDelphi kind variable fields statements =
        let output = StringBuilder()
        let aliases = statements |> List.choose (function TypedAlias alias -> Some alias | _ -> None)
        let resizedArrayFields = statements |> List.choose (function TypedArrayResize(_, field, _, _) -> Some field | _ -> None) |> Set.ofList
        let hasManaged = fields |> List.exists (fun field -> field.managed)
        let hasString = fields |> List.exists (fun field -> field.storage = TypedStringStorage)
        let hasIntArray = fields |> List.exists (fun field -> field.storage = TypedIntArrayStorage)
        let hasRecursiveOption = fields |> List.exists (fun field -> field.storage = TypedRecursiveOptionStorage)
        let hasManagedTuple = fields |> List.exists (fun field -> field.storage = TypedManagedTupleStorage)
        let hasManualManaged = hasRecursiveOption || hasManagedTuple
        output.AppendLine("program SpiralGenerated;") |> ignore
        output.AppendLine("{$mode objfpc}{$H+}") |> ignore
        output.AppendLine("type") |> ignore
        if hasIntArray then output.AppendLine("  TSpiralIntArray = array of LongInt;") |> ignore
        if hasManualManaged then
            output.AppendLine("  TSpiralRecursiveNode = class") |> ignore
            output.AppendLine("  public") |> ignore
            output.AppendLine("    value: LongInt;") |> ignore
            output.AppendLine("    next: TSpiralRecursiveNode;") |> ignore
            output.AppendLine("    constructor Create(aValue: LongInt; aNext: TSpiralRecursiveNode);") |> ignore
            output.AppendLine("    function CloneNode: TSpiralRecursiveNode;") |> ignore
            output.AppendLine("    destructor Destroy; override;") |> ignore
            output.AppendLine("  end;") |> ignore
        if hasManagedTuple then
            output.AppendLine("  TSpiralManagedTuple = class") |> ignore
            output.AppendLine("  public") |> ignore
            output.AppendLine("    item: TSpiralRecursiveNode;") |> ignore
            output.AppendLine("    score: LongInt;") |> ignore
            output.AppendLine("    constructor Create(aItem: TSpiralRecursiveNode; aScore: LongInt);") |> ignore
            output.AppendLine("    function CloneTuple: TSpiralManagedTuple;") |> ignore
            output.AppendLine("    destructor Destroy; override;") |> ignore
            output.AppendLine("  end;") |> ignore
        match kind with
        | TypedStackMutable ->
            output.AppendLine("  TSpiralStackLayout = record") |> ignore
            for field in fields do output.AppendLine($"    {field.name}: {field.delphiType};") |> ignore
            output.AppendLine("  end;") |> ignore
        | TypedStackRefs ->
            for field in fields do output.AppendLine($"  TSpiralRef_{field.name} = ^{field.delphiType};") |> ignore
            output.AppendLine("  TSpiralStackRefs = record") |> ignore
            for field in fields do output.AppendLine($"    {field.name}: TSpiralRef_{field.name};") |> ignore
            output.AppendLine("  end;") |> ignore
        | TypedHeapRefs ->
            output.AppendLine("  TSpiralHeapRefs = class") |> ignore
            output.AppendLine("  public") |> ignore
            for field in fields do output.AppendLine($"    {field.name}: {field.delphiType};") |> ignore
            output.AppendLine("    constructor Create;") |> ignore
            if hasManaged then output.AppendLine("    destructor Destroy; override;") |> ignore
            output.AppendLine("  end;") |> ignore
        if hasManualManaged then
            output.AppendLine() |> ignore
            output.AppendLine("constructor TSpiralRecursiveNode.Create(aValue: LongInt; aNext: TSpiralRecursiveNode);") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  inherited Create;") |> ignore
            output.AppendLine("  value := aValue;") |> ignore
            output.AppendLine("  next := aNext;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("function TSpiralRecursiveNode.CloneNode: TSpiralRecursiveNode;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(next) then") |> ignore
            output.AppendLine("    Result := TSpiralRecursiveNode.Create(value, next.CloneNode)") |> ignore
            output.AppendLine("  else") |> ignore
            output.AppendLine("    Result := TSpiralRecursiveNode.Create(value, nil);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("destructor TSpiralRecursiveNode.Destroy;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  next.Free;") |> ignore
            output.AppendLine("  next := nil;") |> ignore
            output.AppendLine("  inherited Destroy;") |> ignore
            output.AppendLine("end;") |> ignore
        if hasManagedTuple then
            output.AppendLine() |> ignore
            output.AppendLine("constructor TSpiralManagedTuple.Create(aItem: TSpiralRecursiveNode; aScore: LongInt);") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  inherited Create;") |> ignore
            output.AppendLine("  item := aItem;") |> ignore
            output.AppendLine("  score := aScore;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("function TSpiralManagedTuple.CloneTuple: TSpiralManagedTuple;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(item) then") |> ignore
            output.AppendLine("    Result := TSpiralManagedTuple.Create(item.CloneNode, score)") |> ignore
            output.AppendLine("  else") |> ignore
            output.AppendLine("    Result := TSpiralManagedTuple.Create(nil, score);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("destructor TSpiralManagedTuple.Destroy;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  item.Free;") |> ignore
            output.AppendLine("  item := nil;") |> ignore
            output.AppendLine("  inherited Destroy;") |> ignore
            output.AppendLine("end;") |> ignore
        if kind = TypedHeapRefs then
            output.AppendLine() |> ignore
            output.AppendLine("constructor TSpiralHeapRefs.Create;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  inherited Create;") |> ignore
            for field in fields do output.AppendLine($"  {field.name} := {field.delphiValue};") |> ignore
            output.AppendLine("end;") |> ignore
            if hasManaged then
                output.AppendLine() |> ignore
                output.AppendLine("destructor TSpiralHeapRefs.Destroy;") |> ignore
                output.AppendLine("begin") |> ignore
                for field in fields |> List.filter (fun field -> field.managed) do
                    match field.storage with
                    | TypedStringStorage -> output.AppendLine($"  {field.name} := '';") |> ignore
                    | TypedIntArrayStorage -> output.AppendLine($"  SetLength({field.name}, 0);") |> ignore
                    | TypedRecursiveOptionStorage | TypedManagedTupleStorage ->
                        output.AppendLine($"  {field.name}.Free;") |> ignore
                        output.AppendLine($"  {field.name} := nil;") |> ignore
                    | TypedScalarStorage -> ()
                output.AppendLine("  inherited Destroy;") |> ignore
                output.AppendLine("end;") |> ignore
        if hasString then
            output.AppendLine() |> ignore
            output.AppendLine("procedure SpiralAssignString(var target: UnicodeString; const value: UnicodeString);") |> ignore
            output.AppendLine("var") |> ignore
            output.AppendLine("  nextValue: UnicodeString;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  nextValue := value;") |> ignore
            output.AppendLine("  target := nextValue;") |> ignore
            output.AppendLine("end;") |> ignore
        if hasIntArray then
            output.AppendLine() |> ignore
            output.AppendLine("procedure SpiralAssignIntArray(var target: TSpiralIntArray; const value: TSpiralIntArray);") |> ignore
            output.AppendLine("var") |> ignore
            output.AppendLine("  nextValue: TSpiralIntArray;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  nextValue := Copy(value, 0, Length(value));") |> ignore
            output.AppendLine("  target := nextValue;") |> ignore
            output.AppendLine("end;") |> ignore
        if hasRecursiveOption then
            output.AppendLine() |> ignore
            output.AppendLine("procedure SpiralAssignRecursiveOption(var target: TSpiralRecursiveNode; const value: TSpiralRecursiveNode);") |> ignore
            output.AppendLine("var") |> ignore
            output.AppendLine("  nextValue: TSpiralRecursiveNode;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(value) then nextValue := value.CloneNode else nextValue := nil;") |> ignore
            output.AppendLine("  target.Free;") |> ignore
            output.AppendLine("  target := nextValue;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("function SpiralRecursiveOptionValue(const value: TSpiralRecursiveNode): LongInt;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(value) then Result := value.value else Result := 0;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("function SpiralRecursiveOptionNextValue(const value: TSpiralRecursiveNode): LongInt;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(value) and Assigned(value.next) then Result := value.next.value else Result := 0;") |> ignore
            output.AppendLine("end;") |> ignore
        if hasManagedTuple then
            output.AppendLine() |> ignore
            output.AppendLine("procedure SpiralAssignManagedTuple(var target: TSpiralManagedTuple; const value: TSpiralManagedTuple);") |> ignore
            output.AppendLine("var") |> ignore
            output.AppendLine("  nextValue: TSpiralManagedTuple;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(value) then nextValue := value.CloneTuple else nextValue := nil;") |> ignore
            output.AppendLine("  target.Free;") |> ignore
            output.AppendLine("  target := nextValue;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("function SpiralManagedTupleOptionValue(const value: TSpiralManagedTuple): LongInt;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(value) and Assigned(value.item) then Result := value.item.value else Result := 0;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
            output.AppendLine("function SpiralManagedTupleScalar(const value: TSpiralManagedTuple): LongInt;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if Assigned(value) then Result := value.score else Result := 0;") |> ignore
            output.AppendLine("end;") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("function SpiralMain: LongInt;") |> ignore
        output.AppendLine("var") |> ignore
        let variableList = String.concat ", " (variable :: aliases)
        match kind with
        | TypedStackMutable -> output.AppendLine($"  {variableList}: TSpiralStackLayout;") |> ignore
        | TypedStackRefs ->
            for field in fields do output.AppendLine($"  {variable}_{field.name}_storage: {field.delphiType};") |> ignore
            output.AppendLine($"  {variableList}: TSpiralStackRefs;") |> ignore
        | TypedHeapRefs -> output.AppendLine($"  {variableList}: TSpiralHeapRefs;") |> ignore
        if hasRecursiveOption then output.AppendLine("  next_recursive_option_value: TSpiralRecursiveNode;") |> ignore
        if hasManagedTuple then output.AppendLine("  next_managed_tuple_value: TSpiralManagedTuple;") |> ignore
        for field in resizedArrayFields do output.AppendLine($"  next_{field}_length: LongInt;") |> ignore
        output.AppendLine("begin") |> ignore
        match kind with
        | TypedStackMutable -> for field in fields do output.AppendLine($"  {variable}.{field.name} := {field.delphiValue};") |> ignore
        | TypedStackRefs ->
            for field in fields do
                output.AppendLine($"  {variable}_{field.name}_storage := {field.delphiValue};") |> ignore
                output.AppendLine($"  {variable}.{field.name} := @{variable}_{field.name}_storage;") |> ignore
            if hasManualManaged then output.AppendLine("  try") |> ignore
        | TypedHeapRefs ->
            output.AppendLine($"  {variable} := TSpiralHeapRefs.Create;") |> ignore
            output.AppendLine("  try") |> ignore
        let baseDepth = if kind = TypedHeapRefs || (kind = TypedStackRefs && hasManualManaged) then 2 else 1
        let mutable blockDepth = 0
        let delphiIndent () = String.replicate ((baseDepth + blockDepth) * 2) " "
        for statement in statements do
            match statement with
            | TypedWholeAssign assigned ->
                for field in assigned do output.AppendLine($"{delphiIndent ()}{variable}.{field.name} := {field.delphiValue};") |> ignore
            | TypedFieldAssign(target, field, value) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                match value.storage with
                | TypedStringStorage -> output.AppendLine($"{delphiIndent ()}SpiralAssignString({target}.{field}{suffix}, {value.delphiValue});") |> ignore
                | TypedIntArrayStorage -> output.AppendLine($"{delphiIndent ()}SpiralAssignIntArray({target}.{field}{suffix}, {value.delphiValue});") |> ignore
                | TypedRecursiveOptionStorage ->
                    output.AppendLine($"{delphiIndent ()}next_recursive_option_value := {value.delphiValue};") |> ignore
                    output.AppendLine($"{delphiIndent ()}try") |> ignore
                    output.AppendLine($"{delphiIndent ()}  SpiralAssignRecursiveOption({target}.{field}{suffix}, next_recursive_option_value);") |> ignore
                    output.AppendLine($"{delphiIndent ()}finally") |> ignore
                    output.AppendLine($"{delphiIndent ()}  next_recursive_option_value.Free;") |> ignore
                    output.AppendLine($"{delphiIndent ()}  next_recursive_option_value := nil;") |> ignore
                    output.AppendLine($"{delphiIndent ()}end;") |> ignore
                | TypedManagedTupleStorage ->
                    output.AppendLine($"{delphiIndent ()}next_managed_tuple_value := {value.delphiValue};") |> ignore
                    output.AppendLine($"{delphiIndent ()}try") |> ignore
                    output.AppendLine($"{delphiIndent ()}  SpiralAssignManagedTuple({target}.{field}{suffix}, next_managed_tuple_value);") |> ignore
                    output.AppendLine($"{delphiIndent ()}finally") |> ignore
                    output.AppendLine($"{delphiIndent ()}  next_managed_tuple_value.Free;") |> ignore
                    output.AppendLine($"{delphiIndent ()}  next_managed_tuple_value := nil;") |> ignore
                    output.AppendLine($"{delphiIndent ()}end;") |> ignore
                | TypedScalarStorage -> output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := {value.delphiValue};") |> ignore
            | TypedFieldAssignArrayLength(target, field, arrayTarget, arrayField) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := Length({arrayTarget}.{arrayField}{suffix});") |> ignore
            | TypedFieldAssignArrayIndex(target, field, arrayTarget, arrayField, index) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := {arrayTarget}.{arrayField}{suffix}[{index}];") |> ignore
            | TypedFieldAssignOptionalValue(target, field, optionTarget, optionField) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := SpiralRecursiveOptionValue({optionTarget}.{optionField}{suffix});") |> ignore
            | TypedFieldAssignOptionalNextValue(target, field, optionTarget, optionField) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := SpiralRecursiveOptionNextValue({optionTarget}.{optionField}{suffix});") |> ignore
            | TypedFieldAssignTupleOptionalValue(target, field, tupleTarget, tupleField) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := SpiralManagedTupleOptionValue({tupleTarget}.{tupleField}{suffix});") |> ignore
            | TypedFieldAssignTupleScalar(target, field, tupleTarget, tupleField) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix} := SpiralManagedTupleScalar({tupleTarget}.{tupleField}{suffix});") |> ignore
            | TypedArraySet(target, field, index, value) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                output.AppendLine($"{delphiIndent ()}{target}.{field}{suffix}[{index}] := {value};") |> ignore
            | TypedArrayResize(target, field, length, fill) ->
                let suffix = if kind = TypedStackRefs then "^" else ""
                let nextName = $"next_{field}_length"
                output.AppendLine($"{delphiIndent ()}{nextName} := Length({target}.{field}{suffix});") |> ignore
                output.AppendLine($"{delphiIndent ()}SetLength({target}.{field}{suffix}, {length});") |> ignore
                output.AppendLine($"{delphiIndent ()}while {nextName} < {length} do begin") |> ignore
                output.AppendLine($"{delphiIndent ()}  {target}.{field}{suffix}[{nextName}] := {fill};") |> ignore
                output.AppendLine($"{delphiIndent ()}  Inc({nextName});") |> ignore
                output.AppendLine($"{delphiIndent ()}end;") |> ignore
            | TypedAlias alias -> output.AppendLine($"{delphiIndent ()}{alias} := {variable};") |> ignore
            | TypedIfStart(comparison, target, field, value) ->
                output.AppendLine($"{delphiIndent ()}if {delphiTypedFieldRead kind target field} {delphiTypedComparison comparison} {value.delphiValue} then begin") |> ignore
                blockDepth <- blockDepth + 1
            | TypedElse ->
                blockDepth <- blockDepth - 1
                output.AppendLine($"{delphiIndent ()}end else begin") |> ignore
                blockDepth <- blockDepth + 1
            | TypedBlockEnd ->
                blockDepth <- blockDepth - 1
                output.AppendLine($"{delphiIndent ()}end;") |> ignore
            | TypedReturnAdd(leftTarget, leftField, rightTarget, rightField) ->
                output.AppendLine($"{delphiIndent ()}Result := LongInt({delphiTypedFieldRead kind leftTarget leftField} + {delphiTypedFieldRead kind rightTarget rightField});") |> ignore
        match kind with
        | TypedHeapRefs ->
            output.AppendLine("  finally") |> ignore
            output.AppendLine($"    {variable}.Free;") |> ignore
            output.AppendLine("  end;") |> ignore
        | TypedStackRefs when hasManualManaged ->
            output.AppendLine("  finally") |> ignore
            for field in fields do
                match field.storage with
                | TypedRecursiveOptionStorage | TypedManagedTupleStorage ->
                    output.AppendLine($"    {variable}_{field.name}_storage.Free;") |> ignore
                    output.AppendLine($"    {variable}_{field.name}_storage := nil;") |> ignore
                | _ -> ()
            output.AppendLine("  end;") |> ignore
        | _ -> ()
        output.AppendLine("end;") |> ignore
        output.AppendLine() |> ignore
        output.AppendLine("begin") |> ignore
        output.AppendLine("  Halt(SpiralMain);") |> ignore
        output.AppendLine("end.") |> ignore
        output.ToString()

    type private PortableFptrCall = {
        resultName : string
        argument : string
    }

    type private PortableFptrFinal =
        | PortableFptrDirectCall of argument : string
        | PortableFptrAdd of left : string * right : string
        | PortableFptrValue of value : string

    type private PortableFptrProgram = {
        functionName : string
        argumentName : string
        addend : int
        pointerName : string
        runtimeValues : (string * int) list
        calls : PortableFptrCall list
        finalExpression : PortableFptrFinal
    }

    type private PortableClosureCaptureKind =
        | PortableClosureScalarCapture
        | PortableClosureStringCapture
        | PortableClosureArrayCapture
        | PortableClosureRecursiveCapture
        | PortableClosureDenseScalarUnionCapture
        | PortableClosureManagedUnionCapture

    type private PortableClosureCaptureShape = {
        cType : string
        name : string
        kind : PortableClosureCaptureKind
    }

    type private PortableClosureMethodParameterShape = {
        cType : string
        name : string
    }

    type private PortableClosureMethodTerminalShape =
        | PortableClosureDropThenReturn of dropFunction : string * returnStatement : string
        | PortableClosureDropBeforeReturns of dropFunction : string * returnCount : int
        | PortableClosureLeadingDropBeforeReturns of dropFunction : string * returnCount : int

    type private PortableClosureMethodShape = {
        returnType : string
        parameters : PortableClosureMethodParameterShape list
        terminal : PortableClosureMethodTerminalShape
    }

    type private PortableClosureOperationShape = {
        createFunction : string
        methodFunction : string
        decrefBodyFunction : string
        decrefFunction : string
        valueCreateFunction : string
        valueCloneFunction : string
        valueInvokeFunction : string
        valueDropFunction : string
    }

    type private PortableClosureShape = {
        suffix : string
        interfaceName : string
        methodShape : PortableClosureMethodShape
        operations : PortableClosureOperationShape
        captures : PortableClosureCaptureShape list
        needsManualLifetime : bool
    }

    type private PortableNormalizedClosureCResidual = {
        generated : string
        closures : PortableClosureShape list
        hasClosureMethods : bool
    }

    let private normalizePortableClosureMethodResidualType (cType : string) =
        let matched = Regex.Match(cType, "^Fun(?<id>[0-9]+)\\s*\\*$")
        if matched.Success then "ClosureValue" + matched.Groups.["id"].Value
        elif Regex.IsMatch(cType, "^US[0-9]+$") then "Tuple9000"
        else cType

    type private TypedPortableSourceResidual =
        | TypedPortableFptrResidual of PortableFptrProgram
        | TypedPortableLayoutResidual of kind : TypedLayoutKind * variable : string * fields : TypedLayoutField list * statements : TypedLayoutStatement list
        | TypedPortableManagedClosureBranchResidual of flag : bool * leftText : string * leftBias : int * rightText : string * rightBias : int * argument : int
        | TypedPortableNormalizedClosureCResidual of PortableNormalizedClosureCResidual

    let private normalizePortableFptrArgument (value : string) =
        let value = value.Trim()
        if value.EndsWith("i32", StringComparison.Ordinal) then value.Substring(0, value.Length - 3)
        else value

    let private parsePortableFptrSource (source : string) =
        if not (source.Contains("!!!!ToFunPtr", StringComparison.Ordinal)) then None
        else
            let functionPattern = Regex("(?m)^\\s*inl\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*\\(fun\\s*\\((?<arg>[A-Za-z_][A-Za-z0-9_]*)\\s*:\\s*i32\\)\\s*=>\\s*(?<body>.+)\\)\\s*:\\s*i32\\s*->\\s*i32\\s*$")
            let functionMatch = functionPattern.Match source
            if not functionMatch.Success then
                failwith "portable fptr parity requires a noncapturing function with an explicit i32 -> i32 signature"
            let functionName = functionMatch.Groups.["name"].Value
            let argumentName = functionMatch.Groups.["arg"].Value
            let body = functionMatch.Groups.["body"].Value.Trim()
            let addPattern = Regex($"^!!!!Add\\(\\s*{Regex.Escape argumentName}\\s*,\\s*(?<add>-?[0-9]+)i32\\s*\\)$")
            let addMatch = addPattern.Match body
            if not addMatch.Success then
                let captured = Regex.Match(body, "!!!!Add\\([^,]+,\\s*(?<capture>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)")
                if captured.Success then
                    let capturedName = captured.Groups.["capture"].Value
                    failwith $"portable fptr parity requires a noncapturing function; captured value: {capturedName}"
                failwith $"portable fptr parity does not support this function body yet: {body}"
            let addend = Int32.Parse addMatch.Groups.["add"].Value
            let pointerPattern = Regex("(?m)^\\s*inl\\s+~?(?<pointer>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*!!!!ToFunPtr\\(\\s*(?<function>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)\\s*$")
            let pointerMatch = pointerPattern.Match source
            if not pointerMatch.Success then failwith "portable fptr parity requires a named ToFunPtr binding"
            let pointerName = pointerMatch.Groups.["pointer"].Value
            let referencedFunction = pointerMatch.Groups.["function"].Value
            if referencedFunction <> functionName then
                failwith $"portable fptr parity cannot resolve function '{referencedFunction}'"
            let runtimeValues =
                Regex.Matches(source, "(?m)^\\s*inl\\s+~(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<value>-?[0-9]+)i32\\s*$")
                |> Seq.cast<Match>
                |> Seq.map (fun matched -> matched.Groups.["name"].Value, Int32.Parse matched.Groups.["value"].Value)
                |> Seq.toList
            let calls =
                Regex.Matches(source, $"(?m)^\\s*inl\\s+~?(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*{Regex.Escape pointerName}\\s+(?<arg>(?:[A-Za-z_][A-Za-z0-9_]*|-?[0-9]+i32))\\s*$")
                |> Seq.cast<Match>
                |> Seq.map (fun matched -> {
                    resultName = matched.Groups.["name"].Value
                    argument = normalizePortableFptrArgument matched.Groups.["arg"].Value
                })
                |> Seq.toList
            let lastLine =
                source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
                |> Array.map (fun line -> line.Trim())
                |> Array.filter (String.IsNullOrWhiteSpace >> not)
                |> Array.last
            let directPattern = Regex($"^{Regex.Escape pointerName}\\s+(?<arg>(?:[A-Za-z_][A-Za-z0-9_]*|-?[0-9]+i32))$")
            let finalAddPattern = Regex("^!!!!Add\\(\\s*(?<left>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<right>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)$")
            let finalValuePattern = Regex("^(?<value>[A-Za-z_][A-Za-z0-9_]*)$")
            let directMatch = directPattern.Match lastLine
            let finalAddMatch = finalAddPattern.Match lastLine
            let finalValueMatch = finalValuePattern.Match lastLine
            let finalExpression =
                if directMatch.Success then PortableFptrDirectCall(normalizePortableFptrArgument directMatch.Groups.["arg"].Value)
                elif finalAddMatch.Success then PortableFptrAdd(finalAddMatch.Groups.["left"].Value, finalAddMatch.Groups.["right"].Value)
                elif finalValueMatch.Success then PortableFptrValue(finalValueMatch.Groups.["value"].Value)
                else failwith $"portable fptr parity does not support this terminal expression: {lastLine}"
            Some {
                functionName = functionName
                argumentName = argumentName
                addend = addend
                pointerName = pointerName
                runtimeValues = runtimeValues
                calls = calls
                finalExpression = finalExpression
            }

    let private portableFptrFinalC program =
        match program.finalExpression with
        | PortableFptrDirectCall argument -> $"{program.pointerName}({argument})"
        | PortableFptrAdd(left, right) -> $"{left} + {right}"
        | PortableFptrValue value -> value

    let private portableFptrFinalRust program = portableFptrFinalC program

    let private portableFptrFinalDelphi program =
        match program.finalExpression with
        | PortableFptrDirectCall argument -> $"{program.pointerName}({argument})"
        | PortableFptrAdd(left, right) -> $"{left} + {right}"
        | PortableFptrValue value -> value

    let private emitPortableFptrC program =
        let output = StringBuilder()
        output.AppendLine("#include <stdint.h>") |> ignore
        output.AppendLine("typedef int32_t (*SpiralFptr0)(int32_t);") |> ignore
        output.AppendLine($"static int32_t {program.functionName}(int32_t {program.argumentName}){{") |> ignore
        output.AppendLine($"    return {program.argumentName} + {program.addend};") |> ignore
        output.AppendLine("}") |> ignore
        output.AppendLine("int32_t main(void){") |> ignore
        for name, value in program.runtimeValues do output.AppendLine($"    int32_t {name} = {value};") |> ignore
        output.AppendLine($"    SpiralFptr0 {program.pointerName} = {program.functionName};") |> ignore
        for call in program.calls do output.AppendLine($"    int32_t {call.resultName} = {program.pointerName}({call.argument});") |> ignore
        output.AppendLine($"    return {portableFptrFinalC program};") |> ignore
        output.AppendLine("}") |> ignore
        output.ToString()

    let private emitPortableFptrRust program =
        let output = StringBuilder()
        output.AppendLine("type SpiralFptr0 = fn(i32) -> i32;") |> ignore
        output.AppendLine($"fn {program.functionName}({program.argumentName}: i32) -> i32 {{") |> ignore
        output.AppendLine($"    {program.argumentName} + {program.addend}") |> ignore
        output.AppendLine("}") |> ignore
        output.AppendLine("fn main() {") |> ignore
        for name, value in program.runtimeValues do output.AppendLine($"    let {name}: i32 = {value};") |> ignore
        output.AppendLine($"    let {program.pointerName}: SpiralFptr0 = {program.functionName};") |> ignore
        for call in program.calls do output.AppendLine($"    let {call.resultName}: i32 = {program.pointerName}({call.argument});") |> ignore
        output.AppendLine($"    std::process::exit(({portableFptrFinalRust program}) as i32);") |> ignore
        output.AppendLine("}") |> ignore
        output.ToString()

    let private emitPortableFptrDelphi program =
        let output = StringBuilder()
        output.AppendLine("program SpiralGenerated;") |> ignore
        output.AppendLine("{$mode objfpc}{$H+}") |> ignore
        output.AppendLine("type") |> ignore
        output.AppendLine("  TSpiralFptr0 = function(value: LongInt): LongInt;") |> ignore
        output.AppendLine($"function {program.functionName}({program.argumentName}: LongInt): LongInt;") |> ignore
        output.AppendLine("begin") |> ignore
        output.AppendLine($"  Result := {program.argumentName} + {program.addend};") |> ignore
        output.AppendLine("end;") |> ignore
        output.AppendLine("function SpiralMain: LongInt;") |> ignore
        output.AppendLine("var") |> ignore
        for name, _ in program.runtimeValues do output.AppendLine($"  {name}: LongInt;") |> ignore
        output.AppendLine($"  {program.pointerName}: TSpiralFptr0;") |> ignore
        for call in program.calls do output.AppendLine($"  {call.resultName}: LongInt;") |> ignore
        output.AppendLine("begin") |> ignore
        for name, value in program.runtimeValues do output.AppendLine($"  {name} := {value};") |> ignore
        output.AppendLine($"  {program.pointerName} := @{program.functionName};") |> ignore
        for call in program.calls do output.AppendLine($"  {call.resultName} := {program.pointerName}({call.argument});") |> ignore
        output.AppendLine($"  Result := {portableFptrFinalDelphi program};") |> ignore
        output.AppendLine("end;") |> ignore
        output.AppendLine("begin") |> ignore
        output.AppendLine("  Halt(SpiralMain);") |> ignore
        output.AppendLine("end.") |> ignore
        output.ToString()

    let private tryTypedPortableCoreResidual backend (source : string) =
        match parsePortableFptrSource source with
        | Some program -> Some(TypedPortableFptrResidual program)
        | None ->
            if backend <> "Rust" && backend <> "Delphi" then None
            else
                match parseTypedLayoutSourceWithBlocks source with
                | None -> None
                | Some(kind, variable, fields, statements) ->
                    Some(TypedPortableLayoutResidual(kind, variable, fields, statements))

    let private tryLowerTypedPortableCoreResidual backend residual =
        match residual with
        | TypedPortableFptrResidual program ->
            match backend with
            | "C" -> Some(emitPortableFptrC program)
            | "Rust" -> Some(emitPortableFptrRust program)
            | "Delphi" -> Some(emitPortableFptrDelphi program)
            | _ -> None
        | TypedPortableLayoutResidual(kind, variable, fields, statements) ->
            match backend with
            | "Rust" -> Some(emitTypedRust kind variable fields statements)
            | "Delphi" -> Some(emitTypedDelphi kind variable fields statements)
            | _ -> None
        | TypedPortableManagedClosureBranchResidual _ -> None
        | TypedPortableNormalizedClosureCResidual _ -> None

    let tryLowerTypedLayoutSource backend (source : string) =
        match tryTypedPortableCoreResidual backend source with
        | Some residual -> tryLowerTypedPortableCoreResidual backend residual
        | None -> None

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
    
    let private portableTypePattern = "(?:int8_t|int16_t|int32_t|int64_t|uint8_t|uint16_t|uint32_t|uint64_t|float|double|bool|char|String\\s*\\*|Array[0-9]+\\s*\\*|(?:Heap|Mut)[0-9]+\\s*\\*)"
    let private portableFixedScalarTypePattern = "(?:int8_t|int16_t|int32_t|int64_t|uint8_t|uint16_t|uint32_t|uint64_t|float|double|bool|char)"
    let private portableAnyTypePattern = $"(?:{portableTypePattern}|US[0-9]+|Tuple[0-9]+|ClosureValue[0-9]+|OptionalRecursive[0-9]+|WeakRecursive[0-9]+|Recursive[0-9]+)"
    
    let private normalizeCIntegerSuffixes (expression : string) =
        let withoutIntegerSuffixes = Regex.Replace(expression, "(?<![A-Za-z0-9_])((?:0[xX][0-9A-Fa-f]+)|(?:[0-9]+))(?:ull|llu|ll|ul|lu|u|l)\\b", "$1", RegexOptions.IgnoreCase)
        Regex.Replace(withoutIntegerSuffixes, "(?<![A-Za-z0-9_])((?:[0-9]+(?:\\.[0-9]*)?|\\.[0-9]+)(?:[eE][+-]?[0-9]+)?)f\\b", "$1", RegexOptions.IgnoreCase)
    
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
        | "char" -> "u8"
        | value when Regex.IsMatch(value, "^String\\s*\\*$") -> "Rc<str>"
        | value when Regex.IsMatch(value, "^(?:Tuple|ClosureValue)[0-9]+$") -> value
        | value when Regex.IsMatch(value, "^Array[0-9]+\\s*\\*$") -> Regex.Match(value, "^Array[0-9]+").Value
        | value when Regex.IsMatch(value, "^(?:Heap|Mut)[0-9]+\\s*\\*$") -> Regex.Match(value, "^(?:Heap|Mut)[0-9]+").Value
        | value when Regex.IsMatch(value, "^OptionalRecursive[0-9]+$") -> "Option<" + value.Substring("Optional".Length) + ">"
        | value when Regex.IsMatch(value, "^WeakRecursive[0-9]+$") -> "Weak<" + value.Substring("Weak".Length) + "Node>"
        | value when Regex.IsMatch(value, "^Recursive[0-9]+$") -> value
        | value -> failwith $"portable Rust backend does not support C type: {value}"
    
    let private rustDefault = function
        | "bool" -> "false"
        | "f32" | "f64" -> "0.0"
        | value when Regex.IsMatch(value, "^Array[0-9]+$") -> "Rc::new(RefCell::new(Vec::new()))"
        | value when Regex.IsMatch(value, "^Option<Recursive[0-9]+>$") -> "None"
        | value when Regex.IsMatch(value, "^Weak<Recursive[0-9]+Node>$") -> "Weak::new()"
        | "Rc<str>" -> "Rc::<str>::from(\"\")"
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
        | "char" -> "Byte"
        | value when Regex.IsMatch(value, "^String\\s*\\*$") -> "AnsiString"
        | value when Regex.IsMatch(value, "^(?:Tuple|ClosureValue)[0-9]+$") -> value
        | value when Regex.IsMatch(value, "^Array[0-9]+\\s*\\*$") -> Regex.Match(value, "^Array[0-9]+").Value
        | value when Regex.IsMatch(value, "^(?:Heap|Mut)[0-9]+\\s*\\*$") -> Regex.Match(value, "^(?:Heap|Mut)[0-9]+").Value
        | value when Regex.IsMatch(value, "^OptionalRecursive[0-9]+$") -> value
        | value when Regex.IsMatch(value, "^WeakRecursive[0-9]+$") -> value
        | value when Regex.IsMatch(value, "^Recursive[0-9]+$") -> value
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
    
    let private portableTupleConstructorName (name : string) =
        if name.StartsWith("Tuple", StringComparison.Ordinal) then name.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
        elif name.StartsWith("ClosureValue", StringComparison.Ordinal) then name.Replace("ClosureValue", "ClosureValueCreate", StringComparison.Ordinal)
        else failwith $"portable backend cannot derive a constructor name for aggregate type: {name}"

    type private PortableArrayTypeV1 = {
        name : string
        elementType : string
        }

    type private PortableLayoutTypeV1 = {
        name : string
        fields : PortableParameterV2 list
        }

    type private PortableRecursiveUnionTypeV1 = {
        name : string
        cases : (int * PortableParameterV2 list) list
        recursiveCases : int list
        recursiveFields : (int * string * string) list
        }

    let private recursiveUnionUsesLegacyFields recursiveUnion =
        recursiveUnion.recursiveCases.Length = 1 &&
        (recursiveUnion.cases |> List.forall (fun (tag, parameters) -> tag = recursiveUnion.recursiveCases.Head || parameters.IsEmpty))

    let private recursiveUnionStorageField recursiveUnion tag fieldName =
        if recursiveUnionUsesLegacyFields recursiveUnion then fieldName
        else $"case{tag}_{fieldName}"
    
    type private PortableExpressionV3 =
        | PortableNumberV3 of string
        | PortableStringV3 of string
        | PortableCharV3 of string
        | PortableBooleanV3 of bool
        | PortableIdentifierV3 of string
        | PortableCallV3 of callee : PortableExpressionV3 * arguments : PortableExpressionV3 list
        | PortableUnaryV3 of operatorText : string * operand : PortableExpressionV3
        | PortableBinaryV3 of operatorText : string * left : PortableExpressionV3 * right : PortableExpressionV3
        | PortableCastV3 of cType : string * operand : PortableExpressionV3
        | PortableFieldV3 of target : PortableExpressionV3 * fieldName : string
    
    type private PortableStatementV3 =
        | PortableDeclareV3 of cType : string * name : string
        | PortableAssignV3 of name : string * expression : PortableExpressionV3
        | PortableExpressionStatementV3 of expression : PortableExpressionV3
        | PortableReturnV3 of expression : PortableExpressionV3 option
        | PortableIfStartV3 of condition : PortableExpressionV3
        | PortableWhileStartV3 of condition : PortableExpressionV3
        | PortableBreakV3
        | PortableContinueV3
        | PortableElseV3
        | PortableBlockEndV3

    let private isPortableFailExpressionV3 = function
        | PortableCallV3(PortableIdentifierV3 "PortableFail", [PortableStringV3 _]) -> true
        | _ -> false

    let private normalizePortableDivergingTailV3 statements =
        let rec loop acc = function
            | PortableReturnV3(Some expression) :: rest when isPortableFailExpressionV3 expression ->
                loop (PortableExpressionStatementV3 expression :: acc) rest
            | PortableExpressionStatementV3 expression :: PortableReturnV3 _ :: rest when isPortableFailExpressionV3 expression ->
                loop (PortableExpressionStatementV3 expression :: acc) rest
            | statement :: rest -> loop (statement :: acc) rest
            | [] -> List.rev acc
        loop [] statements

    let rec private portableExpressionCallsV3 expectedName = function
        | PortableCallV3(PortableIdentifierV3 name, arguments) ->
            name = expectedName || (arguments |> List.exists (portableExpressionCallsV3 expectedName))
        | PortableCallV3(callee, arguments) ->
            portableExpressionCallsV3 expectedName callee || (arguments |> List.exists (portableExpressionCallsV3 expectedName))
        | PortableUnaryV3(_, operand) -> portableExpressionCallsV3 expectedName operand
        | PortableBinaryV3(_, left, right) -> portableExpressionCallsV3 expectedName left || portableExpressionCallsV3 expectedName right
        | PortableCastV3(_, operand) -> portableExpressionCallsV3 expectedName operand
        | PortableFieldV3(target, _) -> portableExpressionCallsV3 expectedName target
        | PortableNumberV3 _ | PortableStringV3 _ | PortableCharV3 _ | PortableBooleanV3 _ | PortableIdentifierV3 _ -> false

    let private portableStatementCallsV3 expectedName = function
        | PortableAssignV3(_, expression)
        | PortableExpressionStatementV3 expression
        | PortableIfStartV3 expression
        | PortableWhileStartV3 expression -> portableExpressionCallsV3 expectedName expression
        | PortableReturnV3(Some expression) -> portableExpressionCallsV3 expectedName expression
        | PortableDeclareV3 _ | PortableReturnV3 None | PortableBreakV3 | PortableContinueV3 | PortableElseV3 | PortableBlockEndV3 -> false
    
    type private PortableExpressionTokenV3 =
        | PortableIdentifierTokenV3 of string
        | PortableNumberTokenV3 of string
        | PortableStringTokenV3 of string
        | PortableCharTokenV3 of string
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
            elif ch = '\'' then
                let start = index
                index <- index + 1
                if index >= text.Length then failwith $"portable expression v3 found an unterminated character literal in: {text}"
                if text.[index] = '\\' then
                    index <- index + 2
                else
                    index <- index + 1
                if index >= text.Length || text.[index] <> '\'' then failwith $"portable expression v3 found an unterminated character literal in: {text}"
                index <- index + 1
                tokens.Add(PortableCharTokenV3(text.Substring(start, index - start)))
            elif ch = '_' || Char.IsAsciiLetter ch then
                let value = consumeWhile (fun value -> value = '_' || Char.IsAsciiLetterOrDigit value)
                match value with
                | "true" -> tokens.Add(PortableBooleanTokenV3 true)
                | "false" -> tokens.Add(PortableBooleanTokenV3 false)
                | _ -> tokens.Add(PortableIdentifierTokenV3 value)
            elif Char.IsDigit ch || (ch = '.' && (match at 1 with Some value -> Char.IsDigit value | None -> false)) then
                let start = index
                if ch = '0' && (match at 1 with Some 'x' | Some 'X' -> true | _ -> false) then
                    index <- index + 2
                    let digitStart = index
                    while index < text.Length && Uri.IsHexDigit text.[index] do index <- index + 1
                    if index = digitStart then failwith $"portable expression v3 found a hexadecimal literal without digits in: {text}"
                    while index < text.Length && Char.IsAsciiLetter text.[index] do index <- index + 1
                elif ch = '0' && (match at 1 with Some value -> Char.IsDigit value | None -> false) then
                    index <- index + 1
                    while index < text.Length && text.[index] >= '0' && text.[index] <= '7' do index <- index + 1
                    if index < text.Length && (text.[index] = '8' || text.[index] = '9') then
                        failwith $"portable expression v3 found an invalid digit in an octal integer literal in: {text}"
                    while index < text.Length && Char.IsAsciiLetter text.[index] do index <- index + 1
                else
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
                | "<=" | ">=" | "==" | "!=" | "&&" | "||" | "<<" | ">>" ->
                    tokens.Add(PortableOperatorTokenV3 pair)
                    index <- index + 2
                | _ ->
                    match ch with
                    | '+' | '-' | '*' | '/' | '%' | '!' | '<' | '>' | '&' | '|' | '^' | '~' ->
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
        | "|" -> 3
        | "^" -> 4
        | "&" -> 5
        | "==" | "!=" -> 6
        | "<" | "<=" | ">" | ">=" -> 7
        | "<<" | ">>" -> 8
        | "+" | "-" -> 9
        | "*" | "/" | "%" -> 10
        | value -> failwith $"portable expression v3 found unsupported binary operator: {value}"

    let private isPortableNumericCastTypeV3 = function
        | "int8_t" | "int16_t" | "int32_t" | "int64_t"
        | "uint8_t" | "uint16_t" | "uint32_t" | "uint64_t"
        | "float" | "double" -> true
        | _ -> false
    
    let private parsePortableExpressionV3 (text : string) =
        let tokens = tokenizePortableExpressionV3 text
        let mutable index = 0
        let current () = tokens.[index]
        let peek offset =
            let position = index + offset
            if position < tokens.Length then tokens.[position] else PortableEndTokenV3
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
            | PortableLeftParenTokenV3 ->
                match peek 1, peek 2 with
                | PortableIdentifierTokenV3 cType, PortableRightParenTokenV3 when isPortableNumericCastTypeV3 cType ->
                    advance() |> ignore
                    advance() |> ignore
                    expect PortableRightParenTokenV3
                    PortableCastV3(cType, parseUnary())
                | _ -> parsePostfix()
            | PortableOperatorTokenV3 ("!" | "+" | "-" | "~" as operatorText) ->
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
            | PortableCharTokenV3 value -> PortableCharV3 value
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
    
    let private normalizePortableCNumberV3 value = normalizeCIntegerSuffixes value

    let private isPortableOctalIntegerLiteralV3 (value : string) =
        value.Length > 1
        && value.[0] = '0'
        && (value.Substring(1) |> Seq.forall (fun ch -> ch >= '0' && ch <= '7'))

    let private normalizePortableNumberV3 value =
        let normalized = normalizePortableCNumberV3 value
        if isPortableOctalIntegerLiteralV3 normalized then "0o" + normalized.Substring(1)
        else normalized

    let private normalizePortableDelphiNumberV3 value =
        let normalized = normalizePortableCNumberV3 value
        if normalized.StartsWith("0x", StringComparison.OrdinalIgnoreCase) then "$" + normalized.Substring(2)
        elif isPortableOctalIntegerLiteralV3 normalized then "&" + normalized.Substring(1)
        else normalized
    
    let private rustExpressionV3 expression =
        let rec render parentPrecedence expression =
            match expression with
            | PortableNumberV3 value -> normalizePortableNumberV3 value
            | PortableStringV3 value -> value
            | PortableCharV3 value -> "b" + value
            | PortableBooleanV3 value -> if value then "true" else "false"
            | PortableIdentifierV3 "main" -> "spiral_main"
            | PortableIdentifierV3 "HUGE_VALF" -> "f32::INFINITY"
            | PortableIdentifierV3 "HUGE_VAL" -> "f64::INFINITY"
            | PortableIdentifierV3 value -> value
            | PortableCallV3(PortableIdentifierV3 "PortableRustExprBase64", [PortableStringV3 value]) ->
                if value.Length < 2 then failwith "portable Rust interop payload is malformed"
                let payload = value.Substring(1, value.Length - 2)
                Encoding.UTF8.GetString(Convert.FromBase64String payload)
            | PortableCallV3(PortableIdentifierV3 "StringLit", [_; PortableStringV3 value]) -> $"Rc::<str>::from({value})"
            | PortableCallV3(PortableIdentifierV3 "sqrt", [value]) -> $"({render 1 value}).sqrt()"
            | PortableCallV3(PortableIdentifierV3 "sqrtf", [value]) -> $"({render 1 value}).sqrt()"
            | PortableCallV3(PortableIdentifierV3 "log", [value]) -> $"({render 1 value}).ln()"
            | PortableCallV3(PortableIdentifierV3 "logf", [value]) -> $"({render 1 value}).ln()"
            | PortableCallV3(PortableIdentifierV3 "exp", [value]) -> $"({render 1 value}).exp()"
            | PortableCallV3(PortableIdentifierV3 "expf", [value]) -> $"({render 1 value}).exp()"
            | PortableCallV3(PortableIdentifierV3 "tanh", [value]) -> $"({render 1 value}).tanh()"
            | PortableCallV3(PortableIdentifierV3 "tanhf", [value]) -> $"({render 1 value}).tanh()"
            | PortableCallV3(PortableIdentifierV3 "sin", [value]) -> $"({render 1 value}).sin()"
            | PortableCallV3(PortableIdentifierV3 "sinf", [value]) -> $"({render 1 value}).sin()"
            | PortableCallV3(PortableIdentifierV3 "cos", [value]) -> $"({render 1 value}).cos()"
            | PortableCallV3(PortableIdentifierV3 "cosf", [value]) -> $"({render 1 value}).cos()"
            | PortableCallV3(PortableIdentifierV3 "pow", [left; right]) -> $"({render 1 left}).powf({render 1 right})"
            | PortableCallV3(PortableIdentifierV3 "powf", [left; right]) -> $"({render 1 left}).powf({render 1 right})"
            | PortableCallV3(PortableIdentifierV3 "nanf", [_]) -> "f32::NAN"
            | PortableCallV3(PortableIdentifierV3 "nan", [_]) -> "f64::NAN"
            | PortableCallV3(PortableIdentifierV3 "isnan", [value]) -> $"({render 1 value}).is_nan()"
            | PortableCallV3(PortableIdentifierV3 "PortableStringLen", [value]) -> $"{render 1 value}.len() as i32"
            | PortableCallV3(PortableIdentifierV3 "PortableByteToI32", [value]) -> $"({render 12 value} as u8) as i32"
            | PortableCallV3(PortableIdentifierV3 "PortableFail", [PortableStringV3 message]) -> $"panic!({message})"
            | PortableCallV3(PortableIdentifierV3 "abort", []) -> "std::process::abort()"
            | PortableCallV3(PortableIdentifierV3 "PortablePrint", [value]) -> $"print!(\"{{}}\", {render 1 value})"
            | PortableCallV3(PortableIdentifierV3 "PortableFlush", []) -> "std::io::Write::flush(&mut std::io::stdout()).expect(\"stdout flush failed\")"
            | PortableCallV3(PortableIdentifierV3 "poll", [PortableNumberV3 "0"; PortableNumberV3 "0"; duration]) ->
                $"std::thread::sleep(std::time::Duration::from_millis(({render 1 duration}) as u64))"
            | PortableCallV3(PortableIdentifierV3 "PortableStringIndex", [value; index]) -> $"SpiralStringIndex(&{render 12 value}, {render 1 index})"
            | PortableCallV3(PortableIdentifierV3 "PortableStringScalar", [value; index]) -> $"SpiralStringScalar(&{render 12 value}, {render 1 index})"
            | PortableCallV3(PortableIdentifierV3 "PortableStringSlice", [value; fromIndex; toIndex]) -> $"SpiralStringSlice(&{render 12 value}, {render 1 fromIndex}, {render 1 toIndex})"
            | PortableCallV3(PortableIdentifierV3 "PortableStringDrop", [value]) -> $"drop({render 12 value})"
            | PortableCallV3(PortableIdentifierV3 "__spiral_clone", [value]) -> $"{render 12 value}.clone()"
            | PortableCallV3(PortableIdentifierV3 name, []) when name.StartsWith("__spiral_optional_none_", StringComparison.Ordinal) -> "None"
            | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_some_", StringComparison.Ordinal) -> $"Some({render 12 value}.clone())"
            | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_take_", StringComparison.Ordinal) -> $"{render 12 value}.take().expect(\"Spiral optional recursive slot is absent\")"
            | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_has_value_", StringComparison.Ordinal) -> $"if {render 12 value}.is_some() {{ 1 }} else {{ 0 }}"
            | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_borrow_", StringComparison.Ordinal) -> $"{render 12 value}.as_ref().expect(\"Spiral optional recursive slot is absent\").clone()"
            | PortableCallV3(PortableIdentifierV3 name, []) when name.StartsWith("__spiral_empty_array_", StringComparison.Ordinal) -> "Rc::new(RefCell::new(Vec::new()))"
            | PortableCallV3(PortableIdentifierV3 name, [_]) when name.StartsWith("__spiral_delphi_", StringComparison.Ordinal) -> "()"
            | PortableCallV3(PortableIdentifierV3 "PortableStringConcat", [left; right]) -> $"SpiralStringConcat(&{render 12 left}, &{render 12 right})"
            | PortableCallV3(PortableIdentifierV3 name, first :: rest) when Regex.IsMatch(name, "^(?:DynamicArray(?:Set|Get|Len|Resize|Reserve|Capacity|RefCount|Clone|Drop)[0-9]+|(?:Heap(?:Get|Decref)|Mut(?:Assign|Get|Decref))[0-9]+(?:_[0-9]+)?|Recursive(?:Tag|Clone|Drop)[0-9]+|WeakRecursive(?:Downgrade|Upgrade|Clone|Drop)[0-9]+|RecursiveField[0-9]+_[0-9]+|RecursiveCaseField[0-9]+_[0-9]+_[0-9]+)$") ->
                let arguments = ("&" + render 1 first) :: (rest |> List.map (render 1)) |> String.concat ", "
                $"{name}({arguments})"
            | PortableCallV3(callee, arguments) ->
                let arguments = arguments |> List.map (render 1) |> String.concat ", "
                $"{render 12 callee}({arguments})"
            | PortableFieldV3(target, fieldName) -> $"{render 12 target}.{fieldName}"
            | PortableUnaryV3(operatorText, operand) ->
                let precedence = 11
                let targetOperator = if operatorText = "~" then "!" else operatorText
                let text = $"{targetOperator}{render precedence operand}"
                if precedence < parentPrecedence then $"({text})" else text
            | PortableCastV3(cType, operand) ->
                let precedence = 11
                let text =
                    match operand with
                    | PortableCallV3(PortableIdentifierV3 "PortableStringLen", [value]) ->
                        $"{render 12 value}.len() as {rustType cType}"
                    | _ -> $"{render precedence operand} as {rustType cType}"
                if precedence < parentPrecedence then $"({text})" else text
            | PortableBinaryV3(operatorText, left, right) ->
                let precedence = portableBinaryPrecedenceV3 operatorText
                let text = $"{render precedence left} {operatorText} {render (precedence + 1) right}"
                if precedence < parentPrecedence then $"({text})" else text
        render 1 expression

    let private rustExpressionV3Expected expectedType expression =
        match expectedType, expression with
        | Some cType, PortableCallV3(PortableIdentifierV3 "PortableStringLen", [value]) ->
            $"({rustExpressionV3 value}).len() as {rustType cType}"
        | _ -> rustExpressionV3 expression
    
    let private delphiStringLiteralV3 (value : string) =
        if value.Length < 2 || value.[0] <> '"' || value.[value.Length - 1] <> '"' then
            failwith $"portable Delphi backend received an invalid C string literal: {value}"
        let body = value.Substring(1, value.Length - 2)
        let fragments = ResizeArray<string>()
        let literal = StringBuilder()
        let flushLiteral () =
            if literal.Length > 0 then
                let escaped = literal.ToString().Replace("'", "''")
                fragments.Add("'" + escaped + "'")
                literal.Clear() |> ignore
        let appendControl code =
            flushLiteral ()
            fragments.Add($"#{code}")
        let rec loop index =
            if index < body.Length then
                if body.[index] = '\\' then
                    if index + 1 >= body.Length then
                        failwith $"portable Delphi backend received a truncated C escape in string literal: {value}"
                    match body.[index + 1] with
                    | 'n' -> appendControl 10; loop (index + 2)
                    | 'r' -> appendControl 13; loop (index + 2)
                    | 't' -> appendControl 9; loop (index + 2)
                    | '\\' -> literal.Append('\\') |> ignore; loop (index + 2)
                    | '"' -> literal.Append('"') |> ignore; loop (index + 2)
                    | escape -> failwith $"portable Delphi backend does not support C escape \\{escape} in string literal: {value}"
                else
                    literal.Append(body.[index]) |> ignore
                    loop (index + 1)
        loop 0
        flushLiteral ()
        if fragments.Count = 0 then "''" else String.concat "" fragments
    
    let private isPortableIntegerTypeV3 = function
        | "int8_t" | "int16_t" | "int32_t" | "int64_t"
        | "uint8_t" | "uint16_t" | "uint32_t" | "uint64_t" -> true
        | _ -> false

    let rec private delphiExpressionV3Expected expectedType = function
        | PortableNumberV3 value -> normalizePortableDelphiNumberV3 value
        | PortableStringV3 value -> delphiStringLiteralV3 value
        | PortableCharV3 value ->
            let ch =
                if value.Length = 4 && value.[1] = '\\' then
                    match value.[2] with
                    | 'n' -> '\n'
                    | 'r' -> '\r'
                    | 't' -> '\t'
                    | '\\' -> '\\'
                    | '\'' -> '\''
                    | '"' -> '"'
                    | '0' -> '\000'
                    | other -> other
                elif value.Length = 3 then value.[1]
                else failwith $"portable character literal is malformed: {value}"
            "#" + string (int ch)
        | PortableBooleanV3 value -> if value then "True" else "False"
        | PortableIdentifierV3 "main" -> "SpiralMain"
        | PortableIdentifierV3 "HUGE_VALF"
        | PortableIdentifierV3 "HUGE_VAL" -> "Infinity"
        | PortableIdentifierV3 value -> value
        | PortableCallV3(PortableIdentifierV3 "StringLit", [_; PortableStringV3 value]) -> delphiStringLiteralV3 value
        | PortableCallV3(PortableIdentifierV3 "sqrt", [value]) -> $"Sqrt({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "sqrtf", [value]) -> $"Sqrt({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "log", [value]) -> $"Ln({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "logf", [value]) -> $"Ln({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "exp", [value]) -> $"Exp({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "expf", [value]) -> $"Exp({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "tanh", [value]) -> $"Tanh({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "tanhf", [value]) -> $"Tanh({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "sin", [value]) -> $"Sin({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "sinf", [value]) -> $"Sin({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "cos", [value]) -> $"Cos({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "cosf", [value]) -> $"Cos({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "pow", [left; right]) -> $"Power({delphiExpressionV3Expected None left}, {delphiExpressionV3Expected None right})"
        | PortableCallV3(PortableIdentifierV3 "powf", [left; right]) -> $"Power({delphiExpressionV3Expected None left}, {delphiExpressionV3Expected None right})"
        | PortableCallV3(PortableIdentifierV3 "nanf", [_]) -> "NaN"
        | PortableCallV3(PortableIdentifierV3 "nan", [_]) -> "NaN"
        | PortableCallV3(PortableIdentifierV3 "isnan", [value]) -> $"IsNan({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "PortableStringLen", [value]) -> $"Length({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "PortableByteToI32", [value]) -> $"LongInt(Byte({delphiExpressionV3Expected None value}))"
        | PortableCallV3(PortableIdentifierV3 "PortableFail", [PortableStringV3 message]) -> $"raise Exception.Create({delphiStringLiteralV3 message})"
        | PortableCallV3(PortableIdentifierV3 "PortablePrint", [value]) -> $"Write({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "PortableFlush", []) -> "Flush(Output)"
        | PortableCallV3(PortableIdentifierV3 "poll", [PortableNumberV3 "0"; PortableNumberV3 "0"; duration]) ->
            $"Sleep({delphiExpressionV3Expected None duration})"
        | PortableCallV3(PortableIdentifierV3 "PortableStringIndex", [value; index]) -> $"SpiralStringIndex({delphiExpressionV3Expected None value}, {delphiExpressionV3Expected None index})"
        | PortableCallV3(PortableIdentifierV3 "PortableStringScalar", [value; index]) -> $"SpiralStringScalar({delphiExpressionV3Expected None value}, {delphiExpressionV3Expected None index})"
        | PortableCallV3(PortableIdentifierV3 "PortableStringSlice", [value; fromIndex; toIndex]) -> $"SpiralStringSlice({delphiExpressionV3Expected None value}, {delphiExpressionV3Expected None fromIndex}, {delphiExpressionV3Expected None toIndex})"
        | PortableCallV3(PortableIdentifierV3 "PortableStringDrop", [value]) -> $"Finalize({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "__spiral_clone", [value]) -> delphiExpressionV3Expected expectedType value
        | PortableCallV3(PortableIdentifierV3 name, []) when name.StartsWith("__spiral_optional_none_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_optional_none_".Length)
            $"OptionalRecursiveNone{suffix}()"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_some_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_optional_some_".Length)
            $"OptionalRecursiveSome{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_take_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_optional_take_".Length)
            $"OptionalRecursiveTake{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_has_value_", StringComparison.Ordinal) ->
            $"Ord({delphiExpressionV3Expected None value}.HasValue)"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_optional_borrow_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_optional_borrow_".Length)
            $"OptionalRecursiveBorrow{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, []) when name.StartsWith("__spiral_empty_array_", StringComparison.Ordinal) -> "nil"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_delphi_array_clone_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_delphi_array_clone_".Length)
            $"DynamicArrayClone{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_delphi_array_drop_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_delphi_array_drop_".Length)
            $"DynamicArrayDrop{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_delphi_recursive_clone_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_delphi_recursive_clone_".Length)
            $"RecursiveClone{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_delphi_recursive_drop_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_delphi_recursive_drop_".Length)
            $"RecursiveDrop{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_delphi_optional_recursive_clone_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_delphi_optional_recursive_clone_".Length)
            $"OptionalRecursiveClone{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 name, [value]) when name.StartsWith("__spiral_delphi_optional_recursive_drop_", StringComparison.Ordinal) ->
            let suffix = name.Substring("__spiral_delphi_optional_recursive_drop_".Length)
            $"OptionalRecursiveDrop{suffix}({delphiExpressionV3Expected None value})"
        | PortableCallV3(PortableIdentifierV3 "PortableStringConcat", [left; right]) -> $"SpiralStringConcat({delphiExpressionV3Expected None left}, {delphiExpressionV3Expected None right})"
        | PortableCallV3(callee, arguments) ->
            let arguments = arguments |> List.map (delphiExpressionV3Expected None) |> String.concat ", "
            $"{delphiExpressionV3Expected None callee}({arguments})"
        | PortableUnaryV3(("!" | "~"), operand) -> $"(not {delphiExpressionV3Expected None operand})"
        | PortableUnaryV3(operatorText, operand) -> $"({operatorText}{delphiExpressionV3Expected None operand})"
        | PortableCastV3(cType, operand) when isPortableIntegerTypeV3 cType ->
            $"{delphiType cType}(Trunc({delphiExpressionV3Expected None operand}))"
        | PortableCastV3(cType, operand) -> $"{delphiType cType}({delphiExpressionV3Expected None operand})"
        | PortableBinaryV3(operatorText, left, right) ->
            let targetOperator =
                match operatorText with
                | "!=" -> "<>"
                | "==" -> "="
                | "&&" | "&" -> "and"
                | "||" | "|" -> "or"
                | "^" -> "xor"
                | "<<" -> "shl"
                | ">>" -> "shr"
                | "%" -> "mod"
                | "/" when expectedType |> Option.exists isPortableIntegerTypeV3 -> "div"
                | value -> value
            $"({delphiExpressionV3Expected None left} {targetOperator} {delphiExpressionV3Expected None right})"
        | PortableFieldV3(target, fieldName) -> $"{delphiExpressionV3Expected None target}.{fieldName}"

    let private delphiExpressionV3 expression = delphiExpressionV3Expected None expression
    
    type private PortableFunctionV2 = {
        returnType : string
        name : string
        parameters : PortableParameterV2 list
        statements : PortableStatementV3 list
        }

    let private portableTailLoopParameterType (cType : string) =
        Regex.IsMatch(cType, "^(?:int8_t|int16_t|int32_t|int64_t|uint8_t|uint16_t|uint32_t|uint64_t|float|double|bool|char|String\\s*\\*|Array[0-9]+\\s*\\*|Recursive[0-9]+)$")

    let private portableTailLoopRustArgument (parameter : PortableParameterV2) argument =
        let rendered = rustExpressionV3 argument
        if Regex.IsMatch(parameter.cType, "^(?:(?:String|Array[0-9]+)\\s*\\*|Recursive[0-9]+)$") then rendered + ".clone()"
        else rendered

    let private portableTailSelfCallArguments functionName = function
        | PortableReturnV3(Some(PortableCallV3(PortableIdentifierV3 name, arguments))) when name = functionName -> Some arguments
        | _ -> None

    let private portableFunctionUsesTailLoop (fn : PortableFunctionV2) =
        let hasTailSelfCall = fn.statements |> List.exists (fun statement -> portableTailSelfCallArguments fn.name statement |> Option.isSome)
        let hasNestedLoop = fn.statements |> List.exists (function PortableWhileStartV3 _ -> true | _ -> false)
        hasTailSelfCall && not hasNestedLoop && fn.parameters |> List.forall (fun parameter -> portableTailLoopParameterType parameter.cType)
    
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
    
    let rec private normalizeRecursiveUnionsC (generated : string) =
        let forwardPattern = Regex("typedef struct (?<name>UH(?<id>[0-9]+)) \\k<name>;\\s*")
        let forwardMatch = forwardPattern.Match generated
        if not forwardMatch.Success then [], generated
        else
            let findMatchingDelimiterV9 (text : string) openIndex openChar closeChar =
                let mutable depth = 0
                let mutable index = openIndex
                let mutable result = -1
                while index < text.Length && result = -1 do
                    let current = text.[index]
                    if current = openChar then depth <- depth + 1
                    elif current = closeChar then
                        depth <- depth - 1
                        if depth = 0 then result <- index
                    index <- index + 1
                if result < 0 then failwith $"portable backend found an unterminated {openChar}{closeChar} block"
                result
            let sourceName = forwardMatch.Groups.["name"].Value
            let id = forwardMatch.Groups.["id"].Value
            let portableName = "Recursive" + id
            let parseParameter (text : string) =
                let matched = Regex.Match(text.Trim(), $"^(?<type>{portableAnyTypePattern}|UH(?<recursiveId>[0-9]+)\\s*\\*)\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)$")
                if not matched.Success then failwith $"portable backend does not support recursive union parameter: {text}"
                let cType =
                    let recursiveId = matched.Groups.["recursiveId"].Value
                    if String.IsNullOrWhiteSpace recursiveId then matched.Groups.["type"].Value
                    else "Recursive" + recursiveId
                { cType = cType; name = matched.Groups.["name"].Value }
            let constructorPattern = Regex($"(?m)^{Regex.Escape sourceName}\\s*\\*\\s*{Regex.Escape sourceName}_(?<tag>[0-9]+)\\((?<parameters>[^)]*)\\)\\s*\\{{")
            let constructors =
                constructorPattern.Matches generated
                |> Seq.cast<Match>
                |> Seq.map (fun constructorMatch ->
                    let parameters = constructorMatch.Groups.["parameters"].Value.Trim()
                    let parsed =
                        if String.IsNullOrWhiteSpace parameters then []
                        else parameters.Split(',') |> Array.map parseParameter |> Array.toList
                    Int32.Parse(constructorMatch.Groups.["tag"].Value), parsed)
                |> Seq.sortBy fst
                |> Seq.toList
            let expectedTags = [0 .. constructors.Length - 1]
            if constructors.Length < 2 || constructors |> List.map fst <> expectedTags then
                failwith "portable backend requires at least two dense recursive-union cases"
            let emptyCases = constructors |> List.filter (snd >> List.isEmpty)
            let recursiveCases =
                constructors
                |> List.choose (fun (tag, parameters) ->
                    if parameters |> List.exists (fun parameter -> Regex.IsMatch(parameter.cType, "^Recursive[0-9]+$")) then Some tag else None)
            if recursiveCases.IsEmpty then
                failwith "portable backend requires at least one recursive case"
            let recursiveFields =
                constructors
                |> List.collect (fun (tag, parameters) ->
                    parameters
                    |> List.choose (fun parameter ->
                        if Regex.IsMatch(parameter.cType, "^Recursive[0-9]+$") then Some(tag, parameter.name, parameter.cType)
                        else None))
            let info = {
                name = portableName
                cases = constructors
                recursiveCases = recursiveCases
                recursiveFields = recursiveFields
                }
            let mutable normalized = generated
            normalized <- forwardPattern.Replace(normalized, "", 1)
            normalized <- Regex.Replace(normalized, $"void\\s+UHDecref{id}\\s*\\(\\s*{Regex.Escape sourceName}\\s*\\*\\s*x\\s*\\);\\s*", "")
            let structPattern = Regex($"struct\\s+{Regex.Escape sourceName}\\s*\\{{.*?^\\}};\\s*", RegexOptions.Singleline ||| RegexOptions.Multiline)
            normalized <- structPattern.Replace(normalized, "", 1)
            let supportPattern = Regex($"static inline void UHDecrefBody{id}.*?(?={Regex.Escape sourceName}\\s*\\*\\s*{Regex.Escape sourceName}_[0-9]+\\()", RegexOptions.Singleline)
            normalized <- supportPattern.Replace(normalized, "")
            let constructorDefinitionPattern = Regex($"^{Regex.Escape sourceName}\\s*\\*\\s*{Regex.Escape sourceName}_[0-9]+\\([^)]*\\)\\s*\\{{.*?^\\}}\\s*", RegexOptions.Singleline ||| RegexOptions.Multiline)
            normalized <- constructorDefinitionPattern.Replace(normalized, "")
            // The same C name is reused in later functions for a different union.
            // A file-wide map keeps the last declaration and then reads the earlier
            // function through the wrong union. Resolve each use from the nearest
            // preceding declaration instead.
            let declarationPattern variable =
                Regex($@"(?:UH(?<uh>[0-9]+)\s*\*|Recursive(?<recursive>[0-9]+)\s*|Array(?<array>[0-9]+)\s*\*|String\s*\*)\s*{Regex.Escape variable}\b")
            let nearestDeclaration (text : string) (index : int) variable =
                let before = if index <= 0 then "" else text.Substring(0, index)
                let matches = (declarationPattern variable).Matches(before)
                if matches.Count = 0 then None
                else
                    let found = matches.[matches.Count - 1]
                    if found.Groups.["uh"].Success then Some ("union", found.Groups.["uh"].Value)
                    elif found.Groups.["recursive"].Success then Some ("union", found.Groups.["recursive"].Value)
                    elif found.Groups.["array"].Success then Some ("array", found.Groups.["array"].Value)
                    else Some ("string", "")
            let replaceMainOnly (pattern : Regex) (evaluator : MatchEvaluator) (text : string) =
                pattern.Replace(text, evaluator)
            let legacyFieldHelpers =
                recursiveCases.Length = 1 &&
                (constructors |> List.forall (fun (tag, parameters) -> tag = recursiveCases.Head || parameters.IsEmpty))
            for tag, parameters in constructors do
                for fieldIndex, _ in parameters |> List.indexed do
                    let helperName =
                        if legacyFieldHelpers then $"RecursiveField{id}_{fieldIndex}"
                        else $"RecursiveCaseField{id}_{tag}_{fieldIndex}"
                    let fieldPattern = Regex($"\\b(?<var>[A-Za-z_][A-Za-z0-9_]*)->case{tag}\\.v{fieldIndex}")
                    normalized <- replaceMainOnly fieldPattern (MatchEvaluator(fun fieldMatch ->
                        let variable = fieldMatch.Groups.["var"].Value
                        match nearestDeclaration normalized fieldMatch.Index variable with
                        | Some ("union", variableId) when variableId = id -> $"{helperName}({variable})"
                        | _ -> fieldMatch.Value)) normalized
            let tagPattern = Regex("\\b(?<var>[A-Za-z_][A-Za-z0-9_]*)->tag")
            normalized <- replaceMainOnly tagPattern (MatchEvaluator(fun tagMatch ->
                let variable = tagMatch.Groups.["var"].Value
                match nearestDeclaration normalized tagMatch.Index variable with
                | Some ("union", variableId) when variableId = id -> $"RecursiveTag{variableId}({variable})"
                | _ -> tagMatch.Value)) normalized
            let cloneCall (text : string) (index : int) variable =
                match nearestDeclaration text index variable with
                | Some ("array", arrayId) -> $"DynamicArrayClone{arrayId}({variable});"
                | Some ("union", variableId) when variableId = id -> $"RecursiveClone{variableId}({variable});"
                | Some ("string", _) -> ""
                | _ -> ""
            normalized <- Regex.Replace(normalized, "(?<var>[A-Za-z_][A-Za-z0-9_]*)->refc\\+\\+;", MatchEvaluator(fun cloneMatch ->
                let variable = cloneMatch.Groups.["var"].Value
                match nearestDeclaration normalized cloneMatch.Index variable with
                | Some ("union", variableId) when variableId <> id -> cloneMatch.Value
                | _ -> cloneCall normalized cloneMatch.Index variable))
            normalized <- Regex.Replace(normalized, "(?<var>[A-Za-z_][A-Za-z0-9_]*)->refc\\s*\\+=\\s*(?<count>[0-9]+);", MatchEvaluator(fun cloneMatch ->
                let count = Int32.Parse(cloneMatch.Groups.["count"].Value)
                let variable = cloneMatch.Groups.["var"].Value
                match nearestDeclaration normalized cloneMatch.Index variable with
                | Some ("union", variableId) when variableId <> id -> cloneMatch.Value
                | _ ->
                    [1 .. count]
                    |> List.map (fun _ -> cloneCall normalized cloneMatch.Index variable)
                    |> String.concat " "))
            normalized <- Regex.Replace(normalized, $"\\bUHDecref{id}\\(\\s*(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)", MatchEvaluator(fun dropMatch ->
                let variable = dropMatch.Groups.["var"].Value
                $"RecursiveDrop{id}({variable})"))
            normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape sourceName}_(?<tag>[0-9]+)\\s*\\(", $"RecursiveCreate{id}_${{tag}}(")
            normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape sourceName}\\s*\\*", portableName)
            let rewriteSwitches (text : string) =
                let mutable result = text
                let mutable searchFrom = 0
                let mutable keepSearching = true
                while keepSearching do
                    let switchIndex = result.IndexOf("switch (", searchFrom, StringComparison.Ordinal)
                    if switchIndex < 0 then keepSearching <- false
                    else
                        let parenOpen = result.IndexOf('(', switchIndex)
                        let parenClose = findMatchingDelimiterV9 result parenOpen '(' ')'
                        let braceOpen = result.IndexOf('{', parenClose)
                        if braceOpen < 0 then failwith "portable backend found a recursive switch without a body"
                        let braceClose = findMatchingDelimiterV9 result braceOpen '{' '}'
                        let discriminator = result.Substring(parenOpen + 1, parenClose - parenOpen - 1).Trim()
                        let body = result.Substring(braceOpen + 1, braceClose - braceOpen - 1)
                        let cases = ResizeArray<int * string>()
                        let mutable bodyIndex = 0
                        while bodyIndex < body.Length do
                            let caseMatch = Regex.Match(body.Substring(bodyIndex), "case\\s+(?<index>[0-9]+)\\s*:\\s*\\{")
                            if not caseMatch.Success then bodyIndex <- body.Length
                            else
                                let caseBraceOpen = bodyIndex + caseMatch.Index + caseMatch.Length - 1
                                let caseBraceClose = findMatchingDelimiterV9 body caseBraceOpen '{' '}'
                                let caseBody = body.Substring(caseBraceOpen + 1, caseBraceClose - caseBraceOpen - 1)
                                let withoutBreak = Regex.Replace(caseBody, "\\s*break;\\s*$", "", RegexOptions.Singleline).TrimEnd()
                                let withoutComment = Regex.Replace(withoutBreak, "^\\s*//[^\\n]*(?:\\n|$)", "", RegexOptions.Singleline)
                                cases.Add(Int32.Parse(caseMatch.Groups.["index"].Value), withoutComment)
                                bodyIndex <- caseBraceClose + 1
                        if cases.Count < 2 then searchFrom <- braceClose + 1
                        else
                            let rec render remaining =
                                match remaining with
                                | [] -> failwith "portable backend recursive switch had no cases"
                                | [_, lastBody] -> lastBody
                                | (tag, caseBody) :: tail -> $"if ({discriminator} == {tag}) {{\n{caseBody}\n    }} else {{\n{render tail}\n    }}"
                            let replacement = render (cases |> Seq.toList)
                            result <- result.Substring(0, switchIndex) + replacement + result.Substring(braceClose + 1)
                            searchFrom <- switchIndex + replacement.Length
                result
            if forwardPattern.IsMatch normalized then
                let remainingInfos, remainingNormalized = normalizeRecursiveUnionsC normalized
                info :: remainingInfos, remainingNormalized
            else
                normalized <- rewriteSwitches normalized
                if normalized.Contains("switch (", StringComparison.Ordinal) then failwith "portable backend found an unsupported recursive union switch"
                let initializedDeclarationPattern = Regex($"^(?<indent>\\s*)(?<type>{portableAnyTypePattern})\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<expr>.+);\\s*$", RegexOptions.Multiline)
                normalized <- initializedDeclarationPattern.Replace(normalized, MatchEvaluator(fun declarationMatch ->
                    let indent = declarationMatch.Groups.["indent"].Value
                    let cType = declarationMatch.Groups.["type"].Value
                    let name = declarationMatch.Groups.["name"].Value
                    let expression = declarationMatch.Groups.["expr"].Value
                    $"{indent}{cType} {name};\n{indent}{name} = {expression};"))
                [info], normalized

    let private normalizeStringRuntimeC (generated : string) =
        let backingArrays =
            Regex.Matches(generated, "typedef\\s+(?<name>Array[0-9]+)\\s+String;")
            |> Seq.cast<Match>
            |> Seq.map (fun matched -> matched.Groups.["name"].Value)
            |> Seq.distinct
            |> Seq.toArray
        let findMatchingBrace (text : string) openIndex =
            let mutable depth = 0
            let mutable index = openIndex
            let mutable result = -1
            while index < text.Length && result = -1 do
                match text.[index] with
                | '{' -> depth <- depth + 1
                | '}' ->
                    depth <- depth - 1
                    if depth = 0 then result <- index
                | _ -> ()
                index <- index + 1
            if result < 0 then failwith "portable string normalization found an unterminated scope"
            result
        let rewriteStringAccesses (scope : string) =
            let stringVariables =
                Regex.Matches(scope, "\\bString\\s*\\*\\s*(?<name>v[0-9]+)\\b")
                |> Seq.cast<Match>
                |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                |> Seq.distinct
                |> Seq.toArray
            let mutable rewritten = scope
            for value in stringVariables do
                let escaped = Regex.Escape value
                rewritten <-
                    Regex.Replace(
                        rewritten,
                        $"\\b{escaped}->len\\s*-\\s*1(?:ull|llu|ll|ul|lu|u|l)?\\b",
                        $"PortableStringLen({value})")
                rewritten <-
                    Regex.Replace(
                        rewritten,
                        $"\\b{escaped}->ptr\\[(?<index>[^\\]]+)\\]",
                        MatchEvaluator(fun matched ->
                            let index = matched.Groups.["index"].Value.Trim()
                            $"PortableStringIndex({value},{index})"))
            rewritten
        let scoped = StringBuilder()
        let mutable cursor = 0
        while cursor < generated.Length do
            let openIndex = generated.IndexOf('{', cursor)
            if openIndex < 0 then
                scoped.Append(generated.Substring(cursor)) |> ignore
                cursor <- generated.Length
            else
                let closeIndex = findMatchingBrace generated openIndex
                let block = generated.Substring(cursor, closeIndex - cursor + 1)
                scoped.Append(rewriteStringAccesses block) |> ignore
                cursor <- closeIndex + 1
        let mutable normalized = scoped.ToString()
        normalized <-
            Regex.Replace(
                normalized,
                "'(?<value>[^'\\\\])'",
                MatchEvaluator(fun matched ->
                    let value = matched.Groups.["value"].Value
                    let code = int value.[0]
                    string code))
        normalized <- Regex.Replace(normalized, "\\(\\(uint8_t\\)([A-Za-z_][A-Za-z0-9_]*)\\)", "PortableByteToI32($1)")
        let failPrefix = Regex.Escape("fprintf(stderr, \"%s\\n\", ")
        let failSuffix = Regex.Escape(");") + "\\s*" + Regex.Escape("exit(EXIT_FAILURE);")
        normalized <-
            Regex.Replace(
                normalized,
                failPrefix + "(?<message>\"[^\"]*\")" + failSuffix,
                MatchEvaluator(fun matched ->
                    let message = matched.Groups.["message"].Value
                    $"PortableFail({message});"))
        normalized <-
            Regex.Replace(
                normalized,
                "printf\\(\\\"%s\\\",\\s*(?<value>v[0-9]+)->ptr\\);",
                MatchEvaluator(fun matched ->
                    let value = matched.Groups.["value"].Value
                    $"PortablePrint({value});"))
        normalized <- Regex.Replace(normalized, "fflush\\(stdout\\);", "PortableFlush();")
        for arrayName in backingArrays do
            let suffix = arrayName.Substring("Array".Length)
            let escapedArray = Regex.Escape arrayName
            let structPattern = Regex($"typedef struct \\{{\\s*int refc;\\s*uint32_t len;\\s*char ptr\\[\\];\\s*\\}}\\s*{escapedArray};\\s*", RegexOptions.Singleline)
            normalized <- structPattern.Replace(normalized, "")
            let helperNames = $"ArrayDecrefBody{suffix}|ArrayDecref{suffix}|ArrayCreate{suffix}|ArrayLit{suffix}|StringDecref|StringLit|StringSlice|StringConcat|StringScalar"
            let helperPattern = Regex($"^[ \\t]*(?:static inline )?(?:void|int32_t|{escapedArray}\\s*\\*|String\\s*\\*)\\s+(?:{helperNames})\\s*\\([^)]*\\)\\s*\\{{.*?^[ \\t]*\\}}\\s*", RegexOptions.Singleline ||| RegexOptions.Multiline)
            normalized <- helperPattern.Replace(normalized, "")
            normalized <- Regex.Replace(normalized, "^[ \\t]*(?:static inline )?int32_t\\s+StringScalar\\s*\\([^;]*\\);\\s*", "", RegexOptions.Multiline)
            normalized <- Regex.Replace(normalized, $"typedef\\s+{escapedArray}\\s+String;\\s*", "")
        normalized <- Regex.Replace(normalized, "\\bStringSlice\\s*\\(", "PortableStringSlice(")
        normalized <- Regex.Replace(normalized, "\\bStringConcat\\s*\\(", "PortableStringConcat(")
        normalized <- Regex.Replace(normalized, "\\bStringScalar\\s*\\(", "PortableStringScalar(")
        normalized

    let private classifyPortableClosureCaptureSurfaceC (generated : string) =
        let closureStructPattern = Regex("typedef struct Closure(?<id>[0-9]+) Closure\\k<id>;\\s*struct Closure\\k<id>\\s*\\{(?<body>.*?)\\};", RegexOptions.Singleline)
        let denseScalarUnionPattern = Regex("typedef struct \\{\\s*int tag;\\s*union \\{(?<cases>.*?)\\};\\s*\\}\\s*(?<name>US[0-9]+);", RegexOptions.Singleline)
        let denseScalarUnionCasePattern = Regex("struct \\{(?<fields>.*?)\\}\\s+case[0-9]+;", RegexOptions.Singleline)
        let denseScalarUnionFieldPattern = Regex($"(?<type>{portableTypePattern})\\s+v(?<index>[0-9]+);", RegexOptions.Singleline)
        let payloadCasesOfUnion (unionMatch : Match) =
            denseScalarUnionCasePattern.Matches(unionMatch.Groups.["cases"].Value)
            |> Seq.cast<Match>
            |> Seq.map (fun caseMatch ->
                denseScalarUnionFieldPattern.Matches(caseMatch.Groups.["fields"].Value)
                |> Seq.cast<Match>
                |> Seq.map (fun fieldMatch -> Int32.Parse(fieldMatch.Groups.["index"].Value), fieldMatch.Groups.["type"].Value.Trim())
                |> Seq.sortBy fst
                |> Seq.map snd
                |> Seq.toList)
            |> Seq.toList
        let denseScalarUnionNames =
            denseScalarUnionPattern.Matches(generated)
            |> Seq.cast<Match>
            |> Seq.choose (fun unionMatch ->
                let payloadCases = payloadCasesOfUnion unionMatch
                if not payloadCases.IsEmpty
                   && payloadCases |> List.forall (fun payloads ->
                       not payloads.IsEmpty
                       && payloads |> List.forall (fun payloadType -> Regex.IsMatch(payloadType, $"^{portableFixedScalarTypePattern}$"))) then
                    Some unionMatch.Groups.["name"].Value
                else None)
            |> Set.ofSeq
        let managedUnionReturnNames =
            denseScalarUnionPattern.Matches(generated)
            |> Seq.cast<Match>
            |> Seq.choose (fun unionMatch ->
                let payloadCases = payloadCasesOfUnion unionMatch
                if not payloadCases.IsEmpty
                   && payloadCases |> List.forall (fun payloads ->
                       not payloads.IsEmpty
                       && payloads |> List.forall (fun payloadType ->
                           Regex.IsMatch(payloadType, $"^{portableFixedScalarTypePattern}$")
                           || Regex.IsMatch(payloadType, "^(?:String|Array[0-9]+)\\s*\\*$"))) then
                    Some unionMatch.Groups.["name"].Value
                else None)
            |> Set.ofSeq
        let supportedCapture = Regex("^(?<type>int8_t|int16_t|int32_t|int64_t|uint8_t|uint16_t|uint32_t|uint64_t|float|double|bool|char|String\\s*\\*|Array[0-9]+\\s*\\*|Recursive[0-9]+|US[0-9]+|UH(?<recursiveId>[0-9]+)\\s*\\*)\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*;$")
        let captureKind (cType : string) =
            if Regex.IsMatch(cType, "^String\\s*\\*$") then PortableClosureStringCapture
            elif Regex.IsMatch(cType, "^Array[0-9]+\\s*\\*$") then PortableClosureArrayCapture
            elif Regex.IsMatch(cType, "^Recursive[0-9]+$") then PortableClosureRecursiveCapture
            elif Regex.IsMatch(cType, "^US[0-9]+$") then
                if Set.contains cType denseScalarUnionNames then PortableClosureDenseScalarUnionCapture
                else PortableClosureManagedUnionCapture
            else PortableClosureScalarCapture
        let closures =
            closureStructPattern.Matches(generated)
            |> Seq.cast<Match>
            |> Seq.map (fun closureMatch ->
                let suffix = closureMatch.Groups.["id"].Value
                let closureName = "Closure" + suffix
                let captures = ResizeArray<PortableClosureCaptureShape>()
                for rawField in closureMatch.Groups.["body"].Value.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None) do
                    let field = rawField.Trim()
                    if String.IsNullOrWhiteSpace field || field = "int refc;" || field.Contains("(*", StringComparison.Ordinal) then ()
                    else
                        let matched = supportedCapture.Match field
                        if not matched.Success then
                            failwith $"portable closure parity currently supports scalar, string, array, dense scalar-union, and recursive-union captures; unsupported field in {closureName}: {field}"
                        let recursiveId = matched.Groups.["recursiveId"].Value
                        let cType =
                            if String.IsNullOrWhiteSpace recursiveId then matched.Groups.["type"].Value
                            else "Recursive" + recursiveId
                        if Regex.IsMatch(cType, "^US[0-9]+$")
                           && not (Set.contains cType denseScalarUnionNames)
                           && not (Set.contains cType managedUnionReturnNames) then
                            failwith $"portable closure union capture requires primitive, String, or Array payloads: {cType} in {closureName}"
                        captures.Add {
                            cType = cType
                            name = matched.Groups.["name"].Value
                            kind = captureKind cType
                        }
                let captureList = captures |> Seq.toList
                let operations = {
                    createFunction = "ClosureCreate" + suffix
                    methodFunction = "ClosureMethod" + suffix
                    decrefBodyFunction = "ClosureDecrefBody" + suffix
                    decrefFunction = "ClosureDecref" + suffix
                    valueCreateFunction = "ClosureValueCreate" + suffix
                    valueCloneFunction = "ClosureValueClone" + suffix
                    valueInvokeFunction = "ClosureInvoke" + suffix
                    valueDropFunction = "ClosureValueDrop" + suffix
                }
                let createHeader = Regex($"(?ms)^(?<fun>Fun[0-9]+)\\s*\\*\\s*{Regex.Escape operations.createFunction}\\s*\\([^)]*\\)\\s*\\{{(?<body>.*?)^\\s*\\}}\\s*").Match generated
                if not createHeader.Success then
                    failwith $"portable closure residual cannot find the callable interface for {closureName}"
                let createBody = createHeader.Groups.["body"].Value
                if not (Regex.IsMatch(createBody, $"\\bx->decref_fptr\\s*=\\s*{Regex.Escape operations.decrefFunction}\\s*;")) then
                    failwith $"portable closure residual cannot relate {operations.createFunction} to {operations.decrefFunction}"
                if not (Regex.IsMatch(createBody, $"\\bx->fptr\\s*=\\s*{Regex.Escape operations.methodFunction}\\s*;")) then
                    failwith $"portable closure residual cannot relate {operations.createFunction} to {operations.methodFunction}"
                let decrefBodyMatch =
                    Regex($"(?ms)^\\s*static inline void\\s+{Regex.Escape operations.decrefBodyFunction}\\s*\\([^)]*\\)\\s*\\{{(?<body>.*?)^\\s*\\}}")
                        .Match generated
                if not decrefBodyMatch.Success then
                    failwith $"portable closure residual cannot find {operations.decrefBodyFunction}"
                let decrefBody = decrefBodyMatch.Groups.["body"].Value
                for capture in captureList do
                    if capture.kind = PortableClosureManagedUnionCapture then
                        let unionSuffix = capture.cType.Substring(2)
                        let lifecyclePattern = $"\\bUSDecref{Regex.Escape unionSuffix}\\s*\\(\\s*&\\(\\s*x->{Regex.Escape capture.name}\\s*\\)\\s*\\)\\s*;"
                        if not (Regex.IsMatch(decrefBody, lifecyclePattern)) then
                            failwith $"portable managed union closure capture requires explicit decref lifecycle: {capture.cType} {capture.name} in {closureName}"
                        let assignmentPattern = $"\\bx->{Regex.Escape capture.name}\\s*=\\s*{Regex.Escape capture.name}\\s*;"
                        if not (Regex.IsMatch(createBody, assignmentPattern)) then
                            failwith $"portable managed union closure capture requires explicit constructor ownership transfer: {capture.cType} {capture.name} in {closureName}"
                if not (Regex.IsMatch(generated, $"(?m)^\\s*void\\s+{Regex.Escape operations.decrefFunction}\\s*\\(")) then
                    failwith $"portable closure residual cannot find {operations.decrefFunction}"
                let closureMethodTypePattern = $"(?:{portableAnyTypePattern}|Fun[0-9]+\\s*\\*)"
                let methodHeader = Regex($"(?m)^(?<ret>{closureMethodTypePattern}|void)\\s+{Regex.Escape operations.methodFunction}\\s*\\(\\s*Closure{suffix}\\s*\\*\\s*x(?<tail>[^)]*)\\)\\s*\\{{").Match generated
                if not methodHeader.Success then
                    failwith $"portable closure residual cannot find {operations.methodFunction}"
                let methodReturnType = methodHeader.Groups.["ret"].Value
                if Regex.IsMatch(methodReturnType, "^US[0-9]+$") && not (Set.contains methodReturnType managedUnionReturnNames) then
                    failwith $"portable closure union return requires primitive, String, or Array payloads: {methodReturnType} in {closureName}"
                let methodOpenIndex = generated.IndexOf('{', methodHeader.Index)
                let mutable methodDepth = 0
                let mutable methodCursor = methodOpenIndex
                let mutable methodCloseIndex = -1
                while methodCursor < generated.Length && methodCloseIndex < 0 do
                    match generated.[methodCursor] with
                    | '{' -> methodDepth <- methodDepth + 1
                    | '}' ->
                        methodDepth <- methodDepth - 1
                        if methodDepth = 0 then methodCloseIndex <- methodCursor
                    | _ -> ()
                    methodCursor <- methodCursor + 1
                if methodCloseIndex < 0 then
                    failwith $"portable closure residual found an unbalanced body for {operations.methodFunction}"
                let methodBody = generated.Substring(methodOpenIndex + 1, methodCloseIndex - methodOpenIndex - 1)
                let terminalLines =
                    methodBody.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
                    |> Array.map (fun line -> line.Trim())
                    |> Array.filter (String.IsNullOrWhiteSpace >> not)
                if terminalLines.Length < 2 then
                    failwith $"portable closure residual requires a bounded drop-before-return method in {operations.methodFunction}"
                let isReturnLine (line : string) =
                    line = "return;" || (line.StartsWith("return ", StringComparison.Ordinal) && line.EndsWith(";", StringComparison.Ordinal))
                let returnIndexes =
                    terminalLines
                    |> Array.mapi (fun index line -> index, line)
                    |> Array.choose (fun (index, line) -> if isReturnLine line then Some index else None)
                if returnIndexes.Length = 0 then
                    failwith $"portable closure residual requires at least one return statement in {operations.methodFunction}"
                let dropStatement = $"{operations.decrefFunction}(x);"
                let dropIndexes =
                    terminalLines
                    |> Array.mapi (fun index line -> index, line)
                    |> Array.choose (fun (index, line) -> if line = dropStatement then Some index else None)
                let everyReturnHasImmediateDrop =
                    returnIndexes
                    |> Array.forall (fun returnIndex -> returnIndex > 0 && terminalLines.[returnIndex - 1] = dropStatement)
                let hasDropBeforeEveryReturn =
                    dropIndexes.Length = returnIndexes.Length && everyReturnHasImmediateDrop
                let hasSingleTerminalReturnWithEarlierDrop =
                    returnIndexes.Length = 1
                    && returnIndexes.[0] = terminalLines.Length - 1
                    && dropIndexes.Length = 1
                    && dropIndexes.[0] < returnIndexes.[0]
                let hasOnlyNonRecursiveCaptures =
                    captureList |> List.forall (fun capture -> capture.kind <> PortableClosureRecursiveCapture)
                let captureLoadsPrecedeDrop =
                    dropIndexes.Length = 1
                    && (let prefix = terminalLines |> Array.take dropIndexes.[0] |> String.concat " "
                        let mutable remaining = prefix
                        let allCapturesLoaded =
                            captureList
                            |> List.forall (fun capture ->
                                let escapedType = Regex.Escape capture.cType |> fun value -> value.Replace("\\ ", "\\s*")
                                let pattern = $"{escapedType}\\s+{Regex.Escape capture.name}\\s*=\\s*x->\\s*{Regex.Escape capture.name}\\s*;"
                                let found = Regex.IsMatch(remaining, pattern)
                                if found then remaining <- Regex(pattern).Replace(remaining, "", 1)
                                found)
                        allCapturesLoaded && String.IsNullOrWhiteSpace remaining)
                let hasLeadingDropBeforeBranchReturns =
                    hasOnlyNonRecursiveCaptures
                    && ((captureList.IsEmpty && dropIndexes.Length = 1 && dropIndexes.[0] = 0)
                        || captureLoadsPrecedeDrop)
                    && returnIndexes.Length > 1
                let terminal =
                    if hasSingleTerminalReturnWithEarlierDrop then
                        PortableClosureDropThenReturn(operations.decrefFunction, terminalLines.[returnIndexes.[0]])
                    elif hasDropBeforeEveryReturn then
                        PortableClosureDropBeforeReturns(operations.decrefFunction, returnIndexes.Length)
                    elif hasLeadingDropBeforeBranchReturns then
                        PortableClosureLeadingDropBeforeReturns(operations.decrefFunction, returnIndexes.Length)
                    else
                        let terminalPreview = terminalLines |> String.concat " | "
                        failwith $"portable closure residual requires one bounded drop before a terminal return, a drop immediately before each return, or a leading drop after capture loads in {operations.methodFunction}; lines={terminalPreview}"
                let tailText = methodHeader.Groups.["tail"].Value.Trim()
                let methodParameters : PortableClosureMethodParameterShape list =
                    if String.IsNullOrWhiteSpace tailText then []
                    else
                        let parameterPattern = Regex($"^(?<type>{closureMethodTypePattern})\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)$")
                        tailText.TrimStart(',').Trim().Split(',')
                        |> Array.map (fun raw ->
                            let value = raw.Trim()
                            let matchedParameter = parameterPattern.Match value
                            if not matchedParameter.Success then
                                failwith $"portable closure residual does not support this ClosureMethod parameter: {value}"
                            ({ cType = matchedParameter.Groups.["type"].Value; name = matchedParameter.Groups.["name"].Value } : PortableClosureMethodParameterShape))
                        |> Array.toList
                {
                    suffix = suffix
                    interfaceName = createHeader.Groups.["fun"].Value
                    methodShape = {
                        returnType = methodReturnType
                        parameters = methodParameters
                        terminal = terminal
                    }
                    operations = operations
                    captures = captureList
                    needsManualLifetime = captureList |> List.exists (fun capture -> capture.kind = PortableClosureRecursiveCapture)
                })
            |> Seq.toList
        {
            generated = generated
            closures = closures
            hasClosureMethods = generated.Contains("ClosureMethod", StringComparison.Ordinal)
        }

    let private normalizePortableSharedClosureImplementationsC (closureShapes : PortableClosureShape list) (generated : string) =
        let closureStructPattern = Regex("typedef struct Closure(?<id>[0-9]+) Closure\\k<id>;\\s*struct Closure\\k<id>\\s*\\{(?<body>.*?)\\};", RegexOptions.Singleline)
        let closures =
            closureStructPattern.Matches(generated)
            |> Seq.cast<Match>
            |> Seq.map (fun closureMatch ->
                let suffix = closureMatch.Groups.["id"].Value
                let closureShape =
                    match closureShapes |> List.tryFind (fun shape -> shape.suffix = suffix) with
                    | Some shape -> shape
                    | None -> failwith $"portable closure residual is missing the classified shape for Closure{suffix}"
                suffix, closureShape.interfaceName, closureShape, closureMatch)
            |> Seq.toList
        let mutable normalized = generated
        for funName, grouped in closures |> List.groupBy (fun (_, interfaceName, _, _) -> interfaceName) do
            if grouped.Length > 1 then
                let members = grouped |> List.sortBy (fun (suffix, _, _, _) -> Int32.Parse suffix)
                let captureSignature (shape : PortableClosureShape) =
                    shape.captures |> List.map (fun capture -> capture.cType, capture.name, capture.kind)
                let _, _, primaryShape, _ = members.Head
                let primaryCaptureSignature = captureSignature primaryShape
                for suffix, _, closureShape, _ in members.Tail do
                    if captureSignature closureShape <> primaryCaptureSignature then
                        failwith $"portable closure branch parity requires identical capture layouts for {funName}; Closure{suffix} differs"
                if members |> List.exists (fun (_, _, closureShape, _) -> closureShape.captures |> List.exists (fun capture -> capture.kind = PortableClosureRecursiveCapture)) then
                    failwith $"portable closure branch parity does not yet support shared recursive capture layouts for {funName}"
                let primarySuffix, _, _, primaryStruct = members.Head
                let interfaceSuffix = funName.Substring("Fun".Length)
                if primarySuffix <> interfaceSuffix then
                    failwith $"portable closure branch parity expected Closure{interfaceSuffix} to be the primary implementation of {funName}"
                let methodHeaderPattern suffix = Regex($"(?m)^[ \\t]*(?:{portableAnyTypePattern}|US[0-9]+|Fun[0-9]+\\s*\\*|void)\\s+ClosureMethod{suffix}\\s*\\([^)]*\\)\\s*\\{{")
                let methodInfos =
                    members
                    |> List.map (fun (suffix, _, closureShape, _) ->
                        let matched = methodHeaderPattern suffix |> fun pattern -> pattern.Match(generated)
                        if not matched.Success then failwith $"portable closure branch parity cannot find ClosureMethod{suffix}"
                        let openIndex = generated.IndexOf('{', matched.Index)
                        let mutable depth = 0
                        let mutable cursor = openIndex
                        let mutable closeIndex = -1
                        while cursor < generated.Length && closeIndex < 0 do
                            match generated.[cursor] with
                            | '{' -> depth <- depth + 1
                            | '}' ->
                                depth <- depth - 1
                                if depth = 0 then closeIndex <- cursor
                            | _ -> ()
                            cursor <- cursor + 1
                        if closeIndex < 0 then
                            failwith $"portable closure branch parity found an unbalanced body for ClosureMethod{suffix}"
                        let methodValue = generated.Substring(matched.Index, closeIndex - matched.Index + 1)
                        let body = generated.Substring(openIndex + 1, closeIndex - openIndex - 1)
                        suffix, closureShape.methodShape.returnType, closureShape.methodShape.parameters, methodValue, body)
                let _, primaryReturnType, primaryParameters, _, _ = methodInfos.Head
                for suffix, returnType, parameters, _, _ in methodInfos.Tail do
                    if returnType <> primaryReturnType || (parameters |> List.map (fun parameter -> parameter.cType)) <> (primaryParameters |> List.map (fun parameter -> parameter.cType)) then
                        failwith $"portable closure branch parity requires one compatible signature for {funName}; Closure{suffix} differs"
                let renderParameters (parameters : PortableClosureMethodParameterShape list) =
                    parameters |> List.map (fun parameter -> $"{parameter.cType} {parameter.name}") |> String.concat ", "
                let mergedMethod = StringBuilder()
                let tail =
                    match renderParameters primaryParameters with
                    | "" -> ""
                    | text -> ", " + text
                mergedMethod.AppendLine($"{primaryReturnType} ClosureMethod{primarySuffix}(Closure{primarySuffix} * x{tail}){{") |> ignore
                for index, (suffix, _, parameters, _, originalBody) in methodInfos |> List.indexed do
                    if index = 0 then mergedMethod.AppendLine($"    if (x->variant == {index}){{") |> ignore
                    elif index = methodInfos.Length - 1 then mergedMethod.AppendLine("    } else {") |> ignore
                    else mergedMethod.AppendLine($"    }} else if (x->variant == {index}){{") |> ignore
                    let mutable body = Regex.Replace(originalBody, $"(?m)^\\s*ClosureDecref{suffix}\\s*\\(x\\)\\s*;\\s*$", "")
                    for sourceParameter, targetParameter in List.zip parameters primaryParameters do
                        if sourceParameter.name <> targetParameter.name then
                            body <- Regex.Replace(body, $"\\b{Regex.Escape sourceParameter.name}\\b", targetParameter.name)
                    let locals =
                        Regex.Matches(body, $"(?m)^\\s*(?:{portableAnyTypePattern})\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*;")
                        |> Seq.cast<Match>
                        |> Seq.map (fun declaration -> declaration.Groups.["name"].Value)
                        |> Seq.distinct
                        |> Seq.toList
                    for localName in locals do
                        body <- Regex.Replace(body, $"\\b{Regex.Escape localName}\\b", $"closure{suffix}_{localName}")
                    for line in body.Split([|"\\r\\n"; "\\r"; "\\n"|], StringSplitOptions.None) do
                        if not (String.IsNullOrWhiteSpace line) then mergedMethod.AppendLine("        " + line.Trim()) |> ignore
                mergedMethod.AppendLine("    }") |> ignore
                mergedMethod.AppendLine("}") |> ignore
                let primaryBody = primaryStruct.Groups.["body"].Value
                let mergedStruct = $"typedef struct Closure{primarySuffix} Closure{primarySuffix};\nstruct Closure{primarySuffix} {{{primaryBody}\n    int32_t variant;\n}};"
                normalized <- normalized.Replace(primaryStruct.Value, mergedStruct, StringComparison.Ordinal)
                for suffix, _, _, closureStruct in members.Tail do
                    normalized <- normalized.Replace(closureStruct.Value, "", StringComparison.Ordinal)
                    let decrefBodyPattern = Regex($"(?ms)^\\s*static inline void ClosureDecrefBody{suffix}\\s*\\([^)]*\\)\\s*\\{{.*?^\\s*\\}}\\s*")
                    let decrefPattern = Regex($"(?ms)^\\s*void ClosureDecref{suffix}\\s*\\([^)]*\\)\\s*\\{{.*?^\\s*\\}}\\s*")
                    normalized <- decrefBodyPattern.Replace(normalized, "")
                    normalized <- decrefPattern.Replace(normalized, "")
                for suffix, _, _, methodValue, _ in methodInfos do
                    let replacement = if suffix = primarySuffix then mergedMethod.ToString() else ""
                    normalized <- normalized.Replace(methodValue, replacement, StringComparison.Ordinal)
                let createPattern suffix = Regex($"(?ms)^\\s*{Regex.Escape funName}\\s*\\*\\s*ClosureCreate{suffix}\\s*\\((?<parameters>[^)]*)\\)\\s*\\{{.*?^\\s*\\}}\\s*")
                let createInfos =
                    members
                    |> List.map (fun (suffix, _, _, _) ->
                        let matched = createPattern suffix |> fun pattern -> pattern.Match(normalized)
                        if not matched.Success then failwith $"portable closure branch parity cannot find ClosureCreate{suffix}"
                        suffix, matched)
                let primaryCreateMatch = createInfos |> List.find (fun (suffix, _) -> suffix = primarySuffix) |> snd
                let primaryParametersText = primaryCreateMatch.Groups.["parameters"].Value.Trim()
                let primaryHeader =
                    if String.IsNullOrWhiteSpace primaryParametersText then
                        $"ClosureCreate{primarySuffix}(int32_t variant)"
                    else
                        $"ClosureCreate{primarySuffix}({primaryParametersText}, int32_t variant)"
                let primaryHeaderPattern = Regex($"ClosureCreate{primarySuffix}\\s*\\([^)]*\\)")
                let mutable primaryCreate = primaryHeaderPattern.Replace(primaryCreateMatch.Value, primaryHeader, 1)
                primaryCreate <- Regex.Replace(primaryCreate, $"(?m)^(\\s*)return \\({Regex.Escape funName}\\s*\\*\\) x;", $"$1x->variant = variant;\n$1return ({funName} *) x;")
                let createPlaceholder = $"/*__SPIRAL_SHARED_CLOSURE_CREATE_{primarySuffix}__*/"
                if normalized.Contains(createPlaceholder, StringComparison.Ordinal) then
                    failwith $"portable closure branch parity found a reserved constructor placeholder for {funName}"
                for suffix, createMatch in createInfos do
                    let replacement = if suffix = primarySuffix then createPlaceholder else ""
                    normalized <- normalized.Replace(createMatch.Value, replacement, StringComparison.Ordinal)
                for index, (suffix, _, _, _) in members |> List.indexed do
                    let callPattern = Regex($"\\bClosureCreate{suffix}\\s*\\((?<arguments>[^()]*)\\)")
                    normalized <-
                        callPattern.Replace(
                            normalized,
                            MatchEvaluator(fun matched ->
                                let arguments = matched.Groups.["arguments"].Value.Trim()
                                if String.IsNullOrWhiteSpace arguments then
                                    $"ClosureCreate{primarySuffix}({index})"
                                else
                                    $"ClosureCreate{primarySuffix}({arguments}, {index})"))
                normalized <- normalized.Replace(createPlaceholder, primaryCreate, StringComparison.Ordinal)
        normalized

    let private augmentPortableClosureShapesAfterSharedNormalizationC (generated : string) (closureShapes : PortableClosureShape list) =
        let structPattern suffix =
            Regex($"typedef struct Closure{Regex.Escape suffix} Closure{Regex.Escape suffix};\\s*struct Closure{Regex.Escape suffix}\\s*\\{{(?<body>.*?)\\}};", RegexOptions.Singleline)
        closureShapes
        |> List.map (fun closureShape ->
            let matched = structPattern closureShape.suffix |> fun pattern -> pattern.Match generated
            let hasSyntheticVariant =
                matched.Success
                && Regex.IsMatch(matched.Groups.["body"].Value, "(?m)^\\s*int32_t\\s+variant\\s*;\\s*$")
                && not (closureShape.captures |> List.exists (fun capture -> capture.name = "variant"))
            if hasSyntheticVariant then
                { closureShape with
                    captures = closureShape.captures @ [{ cType = "int32_t"; name = "variant"; kind = PortableClosureScalarCapture }] }
            else closureShape)

    let private normalizePortableClosuresC (closureShapes : PortableClosureShape list) (generated : string) =
        let closureTuples = ResizeArray<PortableTupleTypeV2>()
        let mutable normalized = generated
        let closureStructPattern = Regex("typedef struct Closure(?<id>[0-9]+) Closure\\k<id>;\\s*struct Closure\\k<id>\\s*\\{(?<body>.*?)\\};", RegexOptions.Singleline)
        let closureMatches = closureStructPattern.Matches(generated) |> Seq.cast<Match> |> Seq.toList
        for closureMatch in closureMatches do
            normalized <- normalized.Replace(closureMatch.Value, "", StringComparison.Ordinal)
        let rewriteClosureCallsByScope (text : string) =
            let findMatchingBrace (source : string) openIndex =
                let mutable depth = 0
                let mutable index = openIndex
                let mutable closeIndex = -1
                while index < source.Length && closeIndex < 0 do
                    match source.[index] with
                    | '{' -> depth <- depth + 1
                    | '}' ->
                        depth <- depth - 1
                        if depth = 0 then closeIndex <- index
                    | _ -> ()
                    index <- index + 1
                if closeIndex < 0 then failwith "portable closure normalization found an unbalanced function body"
                closeIndex
            let headerPattern = Regex($"(?m)^(?:{portableAnyTypePattern}|void)\\s+[A-Za-z_][A-Za-z0-9_]*\\s*\\([^)]*\\)\\s*\\{{")
            let output = StringBuilder()
            let mutable cursor = 0
            for header in headerPattern.Matches(text) |> Seq.cast<Match> do
                if header.Index >= cursor then
                    let openIndex = text.IndexOf('{', header.Index)
                    let closeIndex = findMatchingBrace text openIndex
                    output.Append(text.Substring(cursor, header.Index - cursor)) |> ignore
                    let mutable block = text.Substring(header.Index, closeIndex - header.Index + 1)
                    let declarations =
                        Regex.Matches(block, "\\bClosureValue(?<id>[0-9]+)\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\b")
                        |> Seq.cast<Match>
                        |> Seq.map (fun declaration -> declaration.Groups.["id"].Value, declaration.Groups.["name"].Value)
                        |> Seq.distinct
                        |> Seq.toList
                    for suffix, variable in declarations do
                        let escaped = Regex.Escape variable
                        let closureShape =
                            match closureShapes |> List.tryFind (fun shape -> shape.suffix = suffix) with
                            | Some shape -> shape
                            | None -> failwith $"portable closure residual is missing lifecycle metadata for ClosureValue{suffix}"
                        let operations = closureShape.operations
                        if closureShape.needsManualLifetime then
                            block <- Regex.Replace(block, $"\\b{escaped}->refc\\+\\+\\s*;", $"{operations.valueCloneFunction}({variable});")
                            block <- Regex.Replace(block, $"\\bRecursiveClone[0-9]+\\s*\\(\\s*{escaped}\\s*\\)\\s*;", $"{operations.valueCloneFunction}({variable});")
                            block <- Regex.Replace(block, $"\\b{escaped}->decref_fptr\\s*\\(\\s*{escaped}\\s*\\)\\s*;\\s*", $"{operations.valueDropFunction}({variable});")
                        else
                            block <- Regex.Replace(block, $"\\b{escaped}->refc\\+\\+\\s*;", "")
                            block <- Regex.Replace(block, $"\\b{escaped}->decref_fptr\\s*\\(\\s*{escaped}\\s*\\)\\s*;\\s*", "")
                        block <- Regex.Replace(block, $"\\b{escaped}->fptr\\s*\\(\\s*{escaped}\\s*,", $"{operations.valueInvokeFunction}({variable},")
                        block <- Regex.Replace(block, $"\\b{escaped}->fptr\\s*\\(\\s*{escaped}\\s*\\)", $"{operations.valueInvokeFunction}({variable})")
                    output.Append(block) |> ignore
                    cursor <- closeIndex + 1
            if cursor < text.Length then output.Append(text.Substring(cursor)) |> ignore
            output.ToString()
        for closureMatch in closureMatches do
            let suffix = closureMatch.Groups.["id"].Value
            let closureName = $"Closure{suffix}"
            let closureShape =
                match closureShapes |> List.tryFind (fun shape -> shape.suffix = suffix) with
                | Some shape -> shape
                | None -> failwith $"portable closure residual is missing the classified shape for {closureName}"
            let operations = closureShape.operations
            let funName = closureShape.interfaceName
            let valueName = $"ClosureValue{suffix}"
            let captureList =
                closureShape.captures
                |> List.map (fun capture ->
                    let residualType =
                        match capture.kind with
                        | PortableClosureDenseScalarUnionCapture
                        | PortableClosureManagedUnionCapture -> "Tuple9000"
                        | _ -> capture.cType
                    { cType = residualType; name = capture.name })
            closureTuples.Add { name = valueName; fields = captureList; constructorParameters = captureList }
            let funStructPattern = Regex($"typedef struct {funName} {funName};\\s*struct {funName}\\s*\\{{.*?\\}};", RegexOptions.Singleline)
            normalized <- funStructPattern.Replace(normalized, "")
            normalized <- normalized.Replace(closureMatch.Value, "", StringComparison.Ordinal)
            let decrefBodyPattern = Regex($"(?ms)^\\s*static inline void {Regex.Escape operations.decrefBodyFunction}\\s*\\([^)]*\\)\\s*\\{{.*?^\\s*\\}}\\s*")
            normalized <- decrefBodyPattern.Replace(normalized, "")
            let decrefPattern = Regex($"(?ms)^\\s*void {Regex.Escape operations.decrefFunction}\\s*\\([^)]*\\)\\s*\\{{.*?^\\s*\\}}\\s*")
            normalized <- decrefPattern.Replace(normalized, "")
            let methodHeader = Regex($"(?:{portableAnyTypePattern}|US[0-9]+|Fun[0-9]+\\s*\\*|void)\\s+{Regex.Escape operations.methodFunction}\\s*\\(\\s*{closureName}\\s*\\*\\s*x[^)]*\\)\\s*\\{{")
            let methodHeaderMatch = methodHeader.Match normalized
            if not methodHeaderMatch.Success then
                failwith $"portable closure normalization cannot find ClosureMethod{suffix}"
            let methodTail =
                closureShape.methodShape.parameters
                |> List.map (fun parameter -> $", {normalizePortableClosureMethodResidualType parameter.cType} {parameter.name}")
                |> String.concat ""
            let environmentName = if captureList.IsEmpty then "_x" else "x"
            let returnType = normalizePortableClosureMethodResidualType closureShape.methodShape.returnType
            let replacement = $"{returnType} {operations.valueInvokeFunction}({valueName} {environmentName}{methodTail}){{"
            normalized <- normalized.Replace(methodHeaderMatch.Value, replacement, StringComparison.Ordinal)
            for capture in captureList do
                normalized <- Regex.Replace(normalized, $"\\bx->{Regex.Escape capture.name}\\b", $"x.{capture.name}")
            normalized <- Regex.Replace(normalized, "\\bx->(?<field>[A-Za-z_][A-Za-z0-9_]*)\\b", "x.${field}")
            let closureNeedsManualLifetime = closureShape.needsManualLifetime
            match closureShape.methodShape.terminal with
            | PortableClosureDropThenReturn(dropFunction, returnStatement) ->
                let mutable normalizedReturnStatement =
                    closureShapes
                    |> List.fold (fun (statement : string) (shape : PortableClosureShape) ->
                        statement.Replace(shape.operations.createFunction + "(", shape.operations.valueCreateFunction + "(", StringComparison.Ordinal)) returnStatement
                let classifiedDropLine = Regex($"(?m)^(?<indent>[ \\t]*){Regex.Escape dropFunction}\\s*\\(x\\)\\s*;\\r?\\n?").Match(normalized)
                if classifiedDropLine.Success then
                    let withoutDrop = normalized.Remove(classifiedDropLine.Index, classifiedDropLine.Length)
                    let returnLinePattern = Regex("(?m)^(?<returnIndent>[ \\t]*)return(?:\\s+.+)?;\\s*$")
                    let returnLine = returnLinePattern.Match(withoutDrop, classifiedDropLine.Index)
                    if not returnLine.Success then
                        let previewLength = Math.Min(240, withoutDrop.Length - classifiedDropLine.Index)
                        let preview = withoutDrop.Substring(classifiedDropLine.Index, previewLength)
                        failwith $"portable closure normalization cannot find the terminal return after the classified drop in {operations.methodFunction}; preview={preview}"
                    normalizedReturnStatement <- returnLine.Value.Trim()
                    let newline = if classifiedDropLine.Value.Contains("\r\n", StringComparison.Ordinal) then "\r\n" else "\n"
                    let returnIndent = returnLine.Groups.["returnIndent"].Value
                    normalized <- withoutDrop.Insert(returnLine.Index, $"{returnIndent}{dropFunction}(x);{newline}")
                let epiloguePattern =
                    Regex($"(?m)^(?<dropIndent>[ \\t]*){Regex.Escape dropFunction}\\s*\\(x\\)\\s*;\\r?\\n(?<returnIndent>[ \\t]*){Regex.Escape normalizedReturnStatement}\\s*$")
                let mutable epilogueRewritten = false
                normalized <-
                    epiloguePattern.Replace(
                        normalized,
                        MatchEvaluator(fun matched ->
                            epilogueRewritten <- true
                            let dropIndent = matched.Groups.["dropIndent"].Value
                            let returnIndent = matched.Groups.["returnIndent"].Value
                            let newline = if matched.Value.Contains("\r\n", StringComparison.Ordinal) then "\r\n" else "\n"
                            if closureNeedsManualLifetime then
                                $"{dropIndent}{operations.valueDropFunction}(x);{newline}{returnIndent}{normalizedReturnStatement}"
                            else
                                $"{returnIndent}{normalizedReturnStatement}"),
                        1)
                let hasSyntheticVariant = closureShape.captures |> List.exists (fun capture -> capture.name = "variant")
                if not epilogueRewritten && not hasSyntheticVariant then
                    failwith $"portable closure normalization cannot find the classified drop/return epilogue for {operations.methodFunction}"
            | PortableClosureDropBeforeReturns(dropFunction, expectedCount) ->
                let branchReturnPattern =
                    Regex($"(?m)^(?<dropIndent>[ \\t]*){Regex.Escape dropFunction}\\s*\\(x\\)\\s*;\\r?\\n(?<returnIndent>[ \\t]*)(?<return>return(?:\\s+.+)?;)\\s*$")
                let mutable rewrittenCount = 0
                normalized <-
                    branchReturnPattern.Replace(
                        normalized,
                        MatchEvaluator(fun matched ->
                            rewrittenCount <- rewrittenCount + 1
                            let returnStatement =
                                closureShapes
                                |> List.fold (fun (statement : string) (shape : PortableClosureShape) ->
                                    statement.Replace(shape.operations.createFunction + "(", shape.operations.valueCreateFunction + "(", StringComparison.Ordinal)) (matched.Groups.["return"].Value.Trim())
                            let returnIndent = matched.Groups.["returnIndent"].Value
                            let newline = if matched.Value.Contains("\r\n", StringComparison.Ordinal) then "\r\n" else "\n"
                            if closureNeedsManualLifetime then
                                $"{returnIndent}{operations.valueDropFunction}(x);{newline}{returnIndent}{returnStatement}"
                            else
                                $"{returnIndent}{returnStatement}"))
                if rewrittenCount <> expectedCount then
                    failwith $"portable closure normalization expected {expectedCount} drop-before-return branches in {operations.methodFunction} but rewrote {rewrittenCount}"
            | PortableClosureLeadingDropBeforeReturns(dropFunction, expectedCount) ->
                if closureNeedsManualLifetime then
                    failwith $"portable closure normalization does not permit a leading drop before {expectedCount} branching returns for recursively captured closures: {operations.methodFunction}"
                let leadingDropPattern = Regex($"\\b{Regex.Escape dropFunction}\\s*\\(x\\)\\s*;")
                let leadingDropCount = leadingDropPattern.Matches(normalized).Count
                if leadingDropCount > 1 then
                    failwith $"portable closure normalization found multiple leading drops before {expectedCount} branching returns in {operations.methodFunction}"
                normalized <- leadingDropPattern.Replace(normalized, "", 1)
            let createPattern = Regex($"(?ms)^\\s*{Regex.Escape funName}\\s*\\*\\s*{Regex.Escape operations.createFunction}\\s*\\([^)]*\\)\\s*\\{{.*?^\\s*\\}}\\s*")
            normalized <- createPattern.Replace(normalized, "")
            normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape funName}\\s*\\*", valueName)
            normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape operations.createFunction}\\s*\\(", $"{operations.valueCreateFunction}(")
        normalized <- rewriteClosureCallsByScope normalized
        normalized <- Regex.Replace(normalized, "\\b[A-Za-z_][A-Za-z0-9_]*->refc\\+\\+\\s*;\\s*", "")
        closureTuples |> Seq.toList, normalized

    let private preprocessPortableProgramC (generated : string) =
        let arrays = ResizeArray<PortableArrayTypeV1>()
        let tuples = ResizeArray<PortableTupleTypeV2>()
        let layouts = ResizeArray<PortableLayoutTypeV1>()
        let kept = ResizeArray<string>()
        let mutable inStruct = false
        let structFields = ResizeArray<string>()
        let mutable skippingHelper = false
        let mutable helperDepth = 0
        let tupleField = Regex($"^({portableAnyTypePattern})\\s+([A-Za-z_][A-Za-z0-9_]*)\\s*;$")
        let structEnd = Regex("^}\\s+([A-Za-z_][A-Za-z0-9_]*);$")
        let tupleHelperStart = Regex($"^static inline (Tuple[0-9]+)\\s+(TupleCreate[0-9]+)\\s*\\((.*)\\)\\s*\\{{$")
        let runtimeHelperStart = Regex("^(?:static inline )?(?:void|int32_t|Recursive[0-9]+|Array[0-9]+\\s*\\*|Mut[0-9]+\\s*\\*|String\\s*\\*|OptionalRecursive[0-9]+)\\s+(?:AssignArray[0-9]+|ArrayDecrefBody[0-9]+|ArrayDecref[0-9]+|ArrayCreate[0-9]+|ArrayLit[0-9]+|StringDecref|StringLit|StringSlice|StringConcat|OptionalRecursive(?:Clone|Drop)[0-9]+|__spiral_optional_(?:none|some|take|has_value|borrow)_[0-9]+)\\s*\\(.*\\)\\s*\\{$")
        let mutableLayoutHelperStart (line : string) =
            line.EndsWith("{", StringComparison.Ordinal) &&
            (line.Contains(" MutDecrefBody", StringComparison.Ordinal) ||
             line.Contains(" MutDecref", StringComparison.Ordinal) ||
             line.Contains(" MutCreate", StringComparison.Ordinal) ||
             line.Contains(" AssignMut", StringComparison.Ordinal) ||
             line.Contains(" HeapDecrefBody", StringComparison.Ordinal) ||
             line.Contains(" HeapDecref", StringComparison.Ordinal) ||
             line.Contains(" HeapCreate", StringComparison.Ordinal))
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
                    elif Regex.IsMatch(structName, "^Array[0-9]+$") then
                        let pointerField = Regex($"^({portableAnyTypePattern})\\s+ptr\\[\\];$")
                        match
                            structFields
                            |> Seq.tryPick (fun fieldLine ->
                                let fieldMatch = pointerField.Match fieldLine
                                if fieldMatch.Success then Some fieldMatch.Groups.[1].Value else None)
                        with
                        | Some elementType -> arrays.Add { name = structName; elementType = elementType }
                        | None -> ()
                    elif Regex.IsMatch(structName, "^(?:Heap|Mut)[0-9]+$") then
                        let fields =
                            structFields
                            |> Seq.filter (fun fieldLine -> fieldLine <> "int refc;")
                            |> Seq.map (fun fieldLine ->
                                let fieldMatch = tupleField.Match fieldLine
                                if not fieldMatch.Success then failwith $"portable backend does not support this mutable layout field: {fieldLine}"
                                { cType = fieldMatch.Groups.[1].Value; name = fieldMatch.Groups.[2].Value })
                            |> Seq.toList
                        if fields.IsEmpty then failwith $"portable backend found an empty mutable layout type: {structName}"
                        layouts.Add { name = structName; fields = fields }
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
            elif runtimeHelperStart.IsMatch line || mutableLayoutHelperStart line then
                helperDepth <- braceDelta line
                skippingHelper <- helperDepth > 0
            else
                kept.Add raw
        if inStruct then failwith "portable backend found an unterminated C struct typedef"
        if skippingHelper then failwith "portable backend found an unterminated helper function"
        let mutable normalized = String.Join("\n", kept)
        for layout in layouts do
            let prefix = if layout.name.StartsWith("Mut", StringComparison.Ordinal) then "Mut" else "Heap"
            let suffix = layout.name.Substring(prefix.Length)
            let lastIndex = layout.fields.Length - 1
            if prefix = "Mut" then
                let assignmentFields =
                    layout.fields
                    |> List.mapi (fun index field ->
                        let target = if index = 0 then "(?<target>[A-Za-z_][A-Za-z0-9_]*)" else "\\k<target>"
                        let argument = if index = lastIndex then $"(?<arg{index}>[^)]+)" else $"(?<arg{index}>[^,]+)"
                        $"&\\({target}->{Regex.Escape field.name}\\)\\s*,\\s*{argument}")
                    |> String.concat "\\s*,\\s*"
                let assignmentPattern = Regex($"\\bAssignMut{suffix}\\s*\\({assignmentFields}\\)\\s*;")
                normalized <-
                    assignmentPattern.Replace(normalized, MatchEvaluator(fun matched ->
                        let arguments =
                            [ for index in 0 .. lastIndex -> matched.Groups.[$"arg{index}"].Value.Trim() ]
                            |> String.concat ", "
                        let target = matched.Groups.["target"].Value
                        $"MutAssign{suffix}({target}, {arguments});"))
            let variables =
                Regex.Matches(normalized, $"\\b{Regex.Escape layout.name}\\s*\\*\\s*(?<name>[A-Za-z_][A-Za-z0-9_]*)\\b")
                |> Seq.cast<Match>
                |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                |> Seq.distinct
                |> Seq.toList
            for variable in variables do
                for index, field in layout.fields |> List.indexed do
                    normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape variable}->{Regex.Escape field.name}\\b", $"{prefix}Get{suffix}_{index}({variable})")
        let layoutGetterClonePattern = Regex("(?m)^(?<indent>[ \\t]*)(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<getter>(?:Heap|Mut)Get[0-9]+_[0-9]+\\([^;]+\\));[ \\t]*\\r?\\n[ \\t]*\\k<var>->refc\\+\\+;[ \\t]*$")
        normalized <- layoutGetterClonePattern.Replace(normalized, MatchEvaluator(fun matched ->
            let indent = matched.Groups.["indent"].Value
            let variable = matched.Groups.["var"].Value
            let getter = matched.Groups.["getter"].Value
            $"{indent}{variable} = {getter};"))
        layouts |> Seq.toList, arrays |> Seq.toList, tuples |> Seq.toList, normalized
    
    let private splitPortableCStatements (line : string) =
        let parts = ResizeArray<string>()
        let current = StringBuilder()
        let mutable inString = false
        let mutable inChar = false
        let mutable escaped = false
        let mutable depth = 0
        let mutable index = 0
        while index < line.Length do
            let ch = line.[index]
            let next = if index + 1 < line.Length then line.[index + 1] else '\000'
            if inString || inChar then
                current.Append(ch) |> ignore
                if escaped then escaped <- false
                elif ch = '\\' then escaped <- true
                elif inString && ch = '"' then inString <- false
                elif inChar && ch = '\'' then inChar <- false
                index <- index + 1
            elif ch = '/' && next = '/' then
                current.Append(line.Substring(index)) |> ignore
                index <- line.Length
            elif ch = '"' then
                inString <- true
                current.Append(ch) |> ignore
                index <- index + 1
            elif ch = '\'' then
                inChar <- true
                current.Append(ch) |> ignore
                index <- index + 1
            elif ch = '{' || ch = '(' || ch = '[' then
                depth <- depth + 1
                current.Append(ch) |> ignore
                index <- index + 1
            elif ch = '}' || ch = ')' || ch = ']' then
                if depth > 0 then depth <- depth - 1
                current.Append(ch) |> ignore
                index <- index + 1
            elif ch = ';' && depth = 0 then
                let part = current.ToString().Trim()
                if not (String.IsNullOrWhiteSpace part) then parts.Add(part + ";")
                current.Clear() |> ignore
                index <- index + 1
            else
                current.Append(ch) |> ignore
                index <- index + 1
        let tail = current.ToString().Trim()
        if not (String.IsNullOrWhiteSpace tail) then parts.Add tail
        parts

    let private expandPortableCLines (generated : string) =
        // Separate adjacent C blocks without modifying quoted payloads or comments.
        // Semicolons split statements only outside strings, character literals, and brackets.
        let generated =
            Regex.Replace(generated,
                """//[^\r\n]*|/\*[\s\S]*?\*/|"(?:\\.|[^"\\])*"|'(?:\\.|[^'\\])*'|(?<close>\})(?=[A-Za-z_])""",
                MatchEvaluator(fun matched ->
                    if matched.Groups.["close"].Success then matched.Value + "\n"
                    else matched.Value))
        seq {
            for raw in generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None) do
                let line = raw.Trim()
                if line.Contains(';') then
                    yield! splitPortableCStatements line
                else
                    yield line
        }
    
    let private validatePortableRecursiveCyclePolicyC (generated : string) =
        let edgePattern = Regex(@"(?m)^\s*(?<owner>[A-Za-z_][A-Za-z0-9_]*)\s*->\s*(?:case[0-9]+\.)?v[0-9]+\s*=\s*(?<child>[A-Za-z_][A-Za-z0-9_]*)\s*;\s*$")
        let adjacency = Dictionary<string, ResizeArray<string>>(StringComparer.Ordinal)
        let nodes = HashSet<string>(StringComparer.Ordinal)
        for matched in edgePattern.Matches(generated) |> Seq.cast<Match> do
            let owner = matched.Groups.["owner"].Value
            let child = matched.Groups.["child"].Value
            nodes.Add(owner) |> ignore
            nodes.Add(child) |> ignore
            match adjacency.TryGetValue owner with
            | true, children -> children.Add child
            | false, _ ->
                let children = ResizeArray<string>()
                children.Add child
                adjacency.Add(owner, children)
        let states = Dictionary<string, int>(StringComparer.Ordinal)
        let stack = ResizeArray<string>()
        let mutable detected : string list option = None
        let rec visit node =
            if detected.IsNone then
                states.[node] <- 1
                stack.Add node
                match adjacency.TryGetValue node with
                | true, children ->
                    for child in children do
                        if detected.IsNone then
                            match states.TryGetValue child with
                            | true, 1 ->
                                let start = stack.IndexOf child
                                let cycle = [for index in start .. stack.Count - 1 -> stack.[index]] @ [child]
                                detected <- Some cycle
                            | true, 2 -> ()
                            | _ -> visit child
                | false, _ -> ()
                stack.RemoveAt(stack.Count - 1)
                states.[node] <- 2
        for node in nodes do
            if detected.IsNone && not (states.ContainsKey node) then visit node
        match detected with
        | Some cycle ->
            let cyclePath = String.concat " -> " cycle
            failwith $"portable backend rejects strong recursive heap cycles; use an acyclic ownership graph or an explicit weak edge: {cyclePath}"
        | None -> ()

    let private decodePortableCStringLiteral (value : string) =
        if value.Length < 2 || value.[0] <> '"' || value.[value.Length - 1] <> '"' then
            failwith $"portable Rust interop expected a C string literal, got: {value}"
        let body = value.Substring(1, value.Length - 2)
        body.Replace("\\\"", "\"").Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t").Replace("\\\\", "\\")

    let private portableRustInteropArguments (text : string) =
        let value = text.Trim() |> normalizeCIntegerSuffixes
        if String.IsNullOrWhiteSpace value || value = "()" then []
        elif Regex.IsMatch(value, "^[A-Za-z_][A-Za-z0-9_]*$") then [value]
        elif Regex.IsMatch(value, "^-?(?:0[xX][0-9A-Fa-f]+|[0-9]+(?:\\.[0-9]*)?(?:[eE][+-]?[0-9]+)?)$") then [value]
        else
            let tupleMatch = Regex("^TupleCreate[0-9]+\\((.*)\\)$").Match value
            if not tupleMatch.Success then
                failwith $"portable Rust interop found unsupported argument shape: {text}"
            tupleMatch.Groups.[1].Value.Split(',')
            |> Array.map (fun item -> item.Trim() |> normalizeCIntegerSuffixes)
            |> Array.toList

    let private normalizeRustInteropEmitsC (generated : string) =
        let assignmentPattern = Regex(@"^\s*([A-Za-z_][A-Za-z0-9_]*)\s*=\s*("".*"");\s*$")
        let declarationPattern = Regex(@"^\s*String \* ([A-Za-z_][A-Za-z0-9_]*)\s*;\s*$")
        let emitPattern = Regex(@"^(\s*[A-Za-z_][A-Za-z0-9_]*\s*=\s*)Fable\.Core\.RustInterop\.emitRustExpr\s+(?:(.+?)\s+)?([A-Za-z_][A-Za-z0-9_]*)\s*;\s*$")
        let lines = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let declarations = Dictionary<string,int>(StringComparer.Ordinal)
        let assignments = Dictionary<string,string * int * int option>(StringComparer.Ordinal)
        let removed = HashSet<int>()
        let replacements = Dictionary<int,string>()
        for index in 0 .. lines.Length - 1 do
            let line = lines.[index]
            let declaration = declarationPattern.Match line
            if declaration.Success then declarations.[declaration.Groups.[1].Value] <- index
            let assignment = assignmentPattern.Match line
            if assignment.Success then
                let name = assignment.Groups.[1].Value
                let declarationIndex =
                    match declarations.TryGetValue name with
                    | true, value -> Some value
                    | false, _ -> None
                assignments.[name] <- decodePortableCStringLiteral assignment.Groups.[2].Value, index, declarationIndex
            let emitted = emitPattern.Match line
            if emitted.Success then
                let prefix = emitted.Groups.[1].Value
                let arguments =
                    if emitted.Groups.[2].Success then portableRustInteropArguments emitted.Groups.[2].Value
                    else []
                let codeVariable = emitted.Groups.[3].Value
                let code, assignmentIndex, declarationIndex =
                    match assignments.TryGetValue codeVariable with
                    | true, value -> value
                    | false, _ -> failwith $"portable Rust interop code variable is unavailable: {codeVariable}"
                let expanded =
                    arguments
                    |> List.indexed
                    |> List.fold (fun (text : string) (argumentIndex, argument) -> text.Replace($"${argumentIndex}", argument)) code
                    |> normalizeCIntegerSuffixes
                let payload = Convert.ToBase64String(Encoding.UTF8.GetBytes expanded)
                replacements.[index] <- $"{prefix}PortableRustExprBase64(\"{payload}\");"
                removed.Add assignmentIndex |> ignore
                declarationIndex |> Option.iter (fun value -> removed.Add value |> ignore)
                assignments.Remove codeVariable |> ignore
                declarations.Remove codeVariable |> ignore
        lines
        |> Array.mapi (fun index line ->
            if removed.Contains index then None
            else
                match replacements.TryGetValue index with
                | true, value -> Some value
                | false, _ -> Some line)
        |> Array.choose id
        |> String.concat "\n"

    let private portableRustPruneIdentityPattern = "[A-Za-z0-9][A-Za-z0-9_-]*"

    let private portableRustPruneBeginPattern =
        Regex($@"(?m)^[ \t]*// SPIRAL_PRUNE_BEGIN:(?<id>{portableRustPruneIdentityPattern})[ \t]*\r?$")

    let private portableRustPruneEndPattern =
        Regex($@"(?m)^[ \t]*// SPIRAL_PRUNE_END:(?<id>{portableRustPruneIdentityPattern})[ \t]*\r?$")

    let private portableRustPruneBlockPattern =
        Regex($@"(?ms)^[ \t]*// SPIRAL_PRUNE_BEGIN:(?<id>{portableRustPruneIdentityPattern})[ \t]*\r?\n.*?^[ \t]*// SPIRAL_PRUNE_END:\k<id>[ \t]*\r?\n?")

    let private prunePortableRustGlobalPayload (payload : string) =
        let begins = portableRustPruneBeginPattern.Matches payload
        let ends = portableRustPruneEndPattern.Matches payload
        let blocks = portableRustPruneBlockPattern.Matches payload
        if begins.Count <> ends.Count || begins.Count <> blocks.Count then
            failwith $"portable Rust prune markers are unbalanced: begin={begins.Count} end={ends.Count} blocks={blocks.Count}"
        let identities = HashSet<string>(StringComparer.Ordinal)
        blocks
        |> Seq.cast<Match>
        |> Seq.iter (fun block ->
            let identity = block.Groups.["id"].Value
            if not (identities.Add identity) then
                failwith $"portable Rust prune marker is duplicated: {identity}")
        portableRustPruneBlockPattern.Replace(payload, "")

    let private extractPortableRustGlobalsC (generated : string) =
        let globals = ResizeArray<string>()
        let lines =
            generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
            |> Array.choose (fun raw ->
                let line = raw.Trim()
                if line.StartsWith("RustGlobal(StringLit(", StringComparison.Ordinal) then
                    if not (line.EndsWith("));", StringComparison.Ordinal)) then
                        failwith $"invalid RustGlobal marker: {line}"
                    let firstQuote = line.IndexOf('"')
                    let lastQuote = line.LastIndexOf('"')
                    if firstQuote < 0 || lastQuote <= firstQuote then
                        failwith $"invalid RustGlobal payload: {line}"
                    let payload =
                        line.Substring(firstQuote + 1, lastQuote - firstQuote - 1)
                        |> Regex.Unescape
                        |> prunePortableRustGlobalPayload
                    globals.Add payload
                    None
                else Some raw)
        let isDeduplicableGlobal (payload : string) =
            let trimmed = payload.TrimStart()
            trimmed.StartsWith("use ", StringComparison.Ordinal)
            || trimmed.StartsWith("pub use ", StringComparison.Ordinal)
            || trimmed.StartsWith("extern crate ", StringComparison.Ordinal)
            || trimmed.StartsWith("#![", StringComparison.Ordinal)
        let seen = HashSet<string>(StringComparer.Ordinal)
        globals
        |> Seq.filter (fun payload -> not (isDeduplicableGlobal payload) || seen.Add payload)
        |> Seq.toList,
        String.concat "\n" lines

    // EOIE libraries retain join points through explicit calls and name their public ABI
    // with these markers. Resolve against the emitted signature, never a guessed suffix.
    let private lowerPortableRustLibrary (lowered : string) =
        let exports = Regex("""(?m)^[ \t]*(?<kind>RustExport[A-Za-z0-9_]*)\("(?<public>[A-Za-z_][A-Za-z0-9_]*)",\s*"(?<target>[A-Za-z_][A-Za-z0-9_]*)"\);[ \t]*\r?$""")
        let library = Regex(@"(?m)^[ \t]*RustLibrary\(\);[ \t]*\r?$")
        let markers = exports.Matches lowered
        let libraryCount = library.Matches(lowered).Count
        if markers.Count > 0 && libraryCount <> 1 then
            failwith "Rust exports require exactly one RustLibrary() marker"
        if libraryCount > 1 then failwith "duplicate RustLibrary marker"
        let wrappers = ResizeArray<string>()
        let names = HashSet<string>(StringComparer.Ordinal)
        for marker in markers |> Seq.cast<Match> do
            let kind = marker.Groups.["kind"].Value
            let publicName = marker.Groups.["public"].Value
            let target = marker.Groups.["target"].Value
            if not (names.Add publicName) then failwith $"duplicate Rust export: {publicName}"
            let argumentTypes, resultType, publicParameters, callArguments =
                match kind with
                | "RustExportI32" -> [], "i32", "", ""
                | "RustExportI32Binary" -> ["i32"; "i32"], "i32", "first: i32, second: i32", "first, second"
                | "RustExportStringUnary" -> ["Rc<str>"], "Rc<str>", "value: &str", "Rc::<str>::from(value)"
                | "RustExportU64Unary" -> ["Rc<str>"], "u64", "value: &str", "Rc::<str>::from(value)"
                | "RustExportStringTuple5Unary" -> ["Rc<str>"], "tuple5", "value: &str", "Rc::<str>::from(value)"
                | "RustExportU64String5" ->
                    let parameters = ["first"; "second"; "third"; "fourth"; "fifth"]
                    List.replicate 5 "Rc<str>", "u64",
                    (parameters |> List.map (fun name -> $"{name}: &str") |> String.concat ", "),
                    (parameters |> List.map (fun name -> $"Rc::<str>::from({name})") |> String.concat ", ")
                | _ -> failwith $"unsupported Rust export marker: {kind}"
            let parameterPattern =
                argumentTypes
                |> List.mapi (fun index ty -> $"(?:mut )?_?v{index}: {Regex.Escape ty}")
                |> String.concat ", "
            let resultPattern = if resultType = "tuple5" then "Tuple[0-9]+" else Regex.Escape resultType
            let signature = Regex($@"(?m)^fn (?<name>{Regex.Escape target}[0-9]+)\({parameterPattern}\) -> (?<result>{resultPattern}) \{{")
            let candidates = signature.Matches lowered
            if candidates.Count <> 1 then
                failwith $"Rust export {publicName} requires exactly one retained {kind} join point named {target}; found {candidates.Count}"
            let callee = candidates.[0].Groups.["name"].Value
            if Regex.IsMatch(lowered, $@"(?m)^(?:pub )?fn {Regex.Escape publicName}\(") then
                failwith $"Rust export collides with an emitted function: {publicName}"
            if resultType = "tuple5" then
                let tupleName = candidates.[0].Groups.["result"].Value
                let shape = Regex.Match(lowered, $@"(?ms)^struct {Regex.Escape tupleName} \{{(?<fields>.*?)^\}}")
                let fields = Regex.Matches(shape.Groups.["fields"].Value, @"v[0-9]+:\s*[^,\r\n]+,")
                let validShape =
                    shape.Success && fields.Count = 5
                    && (fields |> Seq.cast<Match> |> Seq.mapi (fun index field ->
                        Regex.IsMatch(field.Value, $@"^v{index}:\s*Rc<str>,$")) |> Seq.forall id)
                if not validShape then
                    failwith $"Rust export {publicName} requires a tuple of exactly five strings; found {tupleName}"
                wrappers.Add($"#[must_use]\npub fn {publicName}({publicParameters}) -> (Rc<str>, Rc<str>, Rc<str>, Rc<str>, Rc<str>) {{ let result = {callee}({callArguments}); (result.v0, result.v1, result.v2, result.v3, result.v4) }}")
            else
                wrappers.Add($"#[must_use]\npub fn {publicName}({publicParameters}) -> {resultType} {{ {callee}({callArguments}) }}")
        let result = exports.Replace(lowered, "")
        if Regex.IsMatch(result, @"\bRustExport[A-Za-z0-9_]*\(") then
            failwith "unsupported Rust export marker syntax"
        let result =
            if library.IsMatch result then
                let withoutMarker = library.Replace(result, "")
                let entry = Regex(@"(?m)^fn main\(\) \{\s*std::process::exit\(spiral_main\(\)\);\s*\}")
                if entry.Matches(withoutMarker).Count <> 1 then failwith "RustLibrary requires exactly one generated entry point"
                let withoutEntry = entry.Replace(withoutMarker, "")
                // Library main only retains exports during specialization.
                Regex.Replace(withoutEntry, @"(?ms)^fn spiral_main\(\) -> i32 \{\r?\n.*?^\}", "")
            else result
        result.TrimEnd() + "\n\n" + String.concat "\n" wrappers + "\n"

    let private injectPortableRustGlobals (globals : string list) (lowered : string) =
        let lowered = lowerPortableRustLibrary lowered
        let globals = globals |> List.filter (String.IsNullOrWhiteSpace >> not)
        let testGlobals, runtimeGlobals =
            globals
            |> List.partition (fun payload -> payload.TrimStart().StartsWith("#[cfg(test)]", StringComparison.Ordinal))
        let withRuntime =
            if List.isEmpty runtimeGlobals then lowered
            else
                let payload = String.concat "\n" runtimeGlobals + "\n" + "\n"
                let attributeStart = lowered.IndexOf("#![", StringComparison.Ordinal)
                if attributeStart >= 0 then
                    let mutable insertionPoint = attributeStart
                    let mutable scanning = true
                    while scanning do
                        let lineEnd = lowered.IndexOf("\n", insertionPoint, StringComparison.Ordinal)
                        if lineEnd < 0 then
                            insertionPoint <- lowered.Length
                            scanning <- false
                        else
                            insertionPoint <- lineEnd + "\n".Length
                            let mutable probe = insertionPoint
                            while probe < lowered.Length && (lowered.[probe] = '\r' || lowered.[probe] = '\n') do
                                probe <- probe + 1
                            if lowered.IndexOf("#![", probe, StringComparison.Ordinal) = probe then
                                insertionPoint <- probe
                            else scanning <- false
                    lowered.Insert(insertionPoint, payload)
                else payload + lowered
        if List.isEmpty testGlobals then withRuntime
        else
            withRuntime.TrimEnd()
            + "\n"
            + "\n"
            + String.concat ("\n" + "\n") testGlobals
            + "\n"

    let private parsePortableProgramC (closureShapes : PortableClosureShape list) (generated : string) =
        let generated = normalizeRustInteropEmitsC generated
        validatePortableRecursiveCyclePolicyC generated
        let recursiveUnions, generated = normalizeRecursiveUnionsC generated
        let generated = normalizePortableSharedClosureImplementationsC closureShapes generated
        let closureShapes = augmentPortableClosureShapesAfterSharedNormalizationC generated closureShapes
        let closureTuples, generated = normalizePortableClosuresC closureShapes generated
        let layouts, arrays, parsedTuples, generated = preprocessPortableProgramC generated
        let tuples = parsedTuples @ closureTuples
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
        let expressionStatement = Regex("^(.+);$")
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
                statements = statements |> Seq.toList |> normalizePortableDivergingTailV3
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
            elif Regex.IsMatch(line, "^[A-Za-z_][A-Za-z0-9_]*->refc(?:\\+\\+|\\s*\\+=\\s*[0-9]+);$") then
                ()
            else
                let initializedMatch = initializedDeclaration.Match line
                let declarationMatch = declaration.Match line
                let assignmentMatch = assignment.Match line
                let expressionStatementMatch = expressionStatement.Match line
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
                elif expressionStatementMatch.Success then
                    match parsePortableExpressionV3 expressionStatementMatch.Groups.[1].Value with
                    | PortableCallV3 _ as call -> statements.Add(PortableExpressionStatementV3 call)
                    | expression -> failwith $"portable backend only supports call expression statements, got: {expression}"
                else
                    failwith $"portable backend does not support this C statement yet in {currentName}: {line}"
        if currentName <> "" || depth <> 0 then failwith "portable backend found an unterminated C function"
        if functions.Count = 0 then failwith "portable backend found no C functions"
        if functions |> Seq.exists (fun fn -> fn.name = "main") |> not then
            failwith "portable backend requires a C main function"
        recursiveUnions, layouts, arrays, tuples, (functions |> Seq.toList)
    
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

    let private lowerPortableMutualTailPairs (functions : PortableFunctionV2 list) =
        let hasNestedLoop (fn : PortableFunctionV2) =
            fn.statements |> List.exists (function PortableWhileStartV3 _ -> true | _ -> false)
        let hasDirectTailCall targetName (fn : PortableFunctionV2) =
            fn.statements
            |> List.exists (function
                | PortableReturnV3(Some(PortableCallV3(PortableIdentifierV3 name, _))) when name = targetName -> true
                | _ -> false)
        let signature (fn : PortableFunctionV2) =
            fn.returnType, (fn.parameters |> List.map (fun parameter -> parameter.name, parameter.cType))
        let compatible (left : PortableFunctionV2) (right : PortableFunctionV2) =
            left.name <> right.name
            && signature left = signature right
            && not (hasNestedLoop left)
            && not (hasNestedLoop right)
            && left.parameters |> List.forall (fun parameter -> portableTailLoopParameterType parameter.cType)
            && hasDirectTailCall right.name left
            && hasDirectTailCall left.name right
        let partners = Dictionary<string,PortableFunctionV2>(StringComparer.Ordinal)
        for fn in functions do
            if not (partners.ContainsKey fn.name) then
                match functions |> List.tryFind (compatible fn) with
                | Some partner when not (partners.ContainsKey partner.name) ->
                    partners.[fn.name] <- partner
                    partners.[partner.name] <- fn
                | _ -> ()
        let managedCloneExpression (parameter : PortableParameterV2) argument =
            if Regex.IsMatch(parameter.cType, "^(?:(?:String|Array[0-9]+)\\s*\\*|Recursive[0-9]+)$") then
                PortableCallV3(PortableIdentifierV3 "__spiral_clone", [argument])
            else argument
        let ownershipStatements (parameter : PortableParameterV2) temporaryName =
            let temporary = PortableIdentifierV3 temporaryName
            let current = PortableIdentifierV3 parameter.name
            let arrayMatch = Regex.Match(parameter.cType, "^Array(?<id>[0-9]+)\\s*\\*$")
            let recursiveMatch = Regex.Match(parameter.cType, "^Recursive(?<id>[0-9]+)$")
            if arrayMatch.Success then
                let suffix = arrayMatch.Groups.["id"].Value
                [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"DynamicArrayClone{suffix}", [temporary]))
                  PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"DynamicArrayDrop{suffix}", [current])) ]
            elif recursiveMatch.Success then
                let suffix = recursiveMatch.Groups.["id"].Value
                [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"RecursiveClone{suffix}", [temporary]))
                  PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"RecursiveDrop{suffix}", [current])) ]
            else []
        let rewriteTailCalls stateByName (parameters : PortableParameterV2 list) statements =
            statements
            |> List.collect (fun statement ->
                match statement with
                | PortableReturnV3(Some(PortableCallV3(PortableIdentifierV3 targetName, arguments))) when Map.containsKey targetName stateByName ->
                    if arguments.Length <> parameters.Length then
                        failwith $"portable mutual tail loop arity mismatch for {targetName}: expected {parameters.Length}, got {arguments.Length}"
                    let temporaries =
                        List.zip parameters arguments
                        |> List.mapi (fun index (parameter, argument) ->
                            parameter, $"__spiral_scc_arg{index}", argument)
                    [ for parameter, name, argument in temporaries do
                          yield PortableDeclareV3(parameter.cType, name)
                          yield PortableAssignV3(name, managedCloneExpression parameter argument)
                      for parameter, name, _ in temporaries do
                          yield! ownershipStatements parameter name
                          yield PortableAssignV3(parameter.name, PortableIdentifierV3 name)
                      yield PortableAssignV3("__spiral_tail_state", PortableNumberV3(string stateByName.[targetName]))
                      yield PortableContinueV3 ]
                | _ -> [statement])
        let result = ResizeArray<PortableFunctionV2>()
        let emitted = HashSet<string>(StringComparer.Ordinal)
        for fn in functions do
            if emitted.Add fn.name then
                match partners.TryGetValue fn.name with
                | true, partner ->
                    emitted.Add partner.name |> ignore
                    let members = [fn; partner]
                    let stateByName = members |> List.mapi (fun index memberFn -> memberFn.name, index) |> Map.ofList
                    let dispatcherName = $"__spiral_scc_{fn.name}_{partner.name}"
                    let dispatcherParameters = { cType = "int32_t"; name = "__spiral_tail_state" } :: fn.parameters
                    let dispatcherStatements =
                        [ yield PortableWhileStartV3(PortableBooleanV3 true)
                          yield PortableIfStartV3(PortableBinaryV3("==", PortableIdentifierV3 "__spiral_tail_state", PortableNumberV3 "0"))
                          yield! rewriteTailCalls stateByName fn.parameters fn.statements
                          yield PortableElseV3
                          yield! rewriteTailCalls stateByName partner.parameters partner.statements
                          yield PortableBlockEndV3
                          yield PortableBlockEndV3 ]
                    result.Add {
                        returnType = fn.returnType
                        name = dispatcherName
                        parameters = dispatcherParameters
                        statements = dispatcherStatements
                        }
                    for initialState, memberFn in members |> List.indexed do
                        result.Add {
                            returnType = memberFn.returnType
                            name = memberFn.name
                            parameters = memberFn.parameters
                            statements =
                                [ PortableReturnV3(Some(PortableCallV3(
                                    PortableIdentifierV3 dispatcherName,
                                    PortableNumberV3(string initialState) :: (memberFn.parameters |> List.map (fun parameter -> PortableIdentifierV3 parameter.name))))) ]
                            }
                | _ -> result.Add fn
        result |> Seq.toList

    let private lowerPortableTailSccs (recursiveUnions : PortableRecursiveUnionTypeV1 list) (functions : PortableFunctionV2 list) =
        let hasNestedLoop (fn : PortableFunctionV2) =
            fn.statements |> List.exists (function PortableWhileStartV3 _ -> true | _ -> false)
        let functionNames = HashSet<string>(functions |> List.map (fun fn -> fn.name), StringComparer.Ordinal)
        let directTailTargets (fn : PortableFunctionV2) =
            fn.statements
            |> List.choose (function
                | PortableReturnV3(Some(PortableCallV3(PortableIdentifierV3 name, _)))
                    when name <> fn.name && functionNames.Contains name -> Some name
                | _ -> None)
            |> List.distinct
        let recursiveEmptyCaseByType =
            recursiveUnions
            |> List.choose (fun recursiveUnion ->
                recursiveUnion.cases
                |> List.tryFind (fun (_, parameters) -> parameters.IsEmpty)
                |> Option.map (fun (tag, _) -> recursiveUnion.name, tag))
            |> Map.ofList
        let tryRecursiveEmptyCase (cType : string) = Map.tryFind cType recursiveEmptyCaseByType
        let isRecursiveSlotType (cType : string) = Regex.IsMatch(cType, "^Recursive[0-9]+$")
        let isManagedSlotType (cType : string) =
            Regex.IsMatch(cType, "^(?:(?:String|Array[0-9]+)\\s*\\*|Recursive[0-9]+)$")
        let isOptionalManagedSlotType (cType : string) =
            Regex.IsMatch(cType, "^(?:String|Array[0-9]+)\\s*\\*$") || isRecursiveSlotType cType
        let isTaggedOptionalRecursiveSlot (slot : PortableParameterV2) =
            isRecursiveSlotType slot.cType && Option.isNone (tryRecursiveEmptyCase slot.cType)
        let optionalRecursiveSuffix (slot : PortableParameterV2) = slot.cType.Substring("Recursive".Length)
        let optionalRecursiveType (slot : PortableParameterV2) = "Optional" + slot.cType
        let optionalRecursiveStorageName (slot : PortableParameterV2) = "__spiral_scc_optional_" + slot.name
        let optionalRecursiveStorageParameter (slot : PortableParameterV2) =
            { cType = optionalRecursiveType slot; name = optionalRecursiveStorageName slot }
        let optionalRecursiveNoneExpression (slot : PortableParameterV2) =
            PortableCallV3(PortableIdentifierV3 ("__spiral_optional_none_" + optionalRecursiveSuffix slot), [])
        let optionalRecursiveSomeExpression (slot : PortableParameterV2) value =
            PortableCallV3(PortableIdentifierV3 ("__spiral_optional_some_" + optionalRecursiveSuffix slot), [value])
        let optionalRecursiveTakeExpression (slot : PortableParameterV2) =
            PortableCallV3(
                PortableIdentifierV3 ("__spiral_optional_take_" + optionalRecursiveSuffix slot),
                [PortableIdentifierV3 (optionalRecursiveStorageName slot)])
        let slotPresent (memberFn : PortableFunctionV2) (slot : PortableParameterV2) =
            memberFn.parameters
            |> List.exists (fun parameter -> parameter.name = slot.name && parameter.cType = slot.cType)
        let optionalManagedFlagName (slot : PortableParameterV2) =
            "__spiral_scc_live_" + slot.name
        let defaultManagedSlotExpression (parameter : PortableParameterV2) =
            if Regex.IsMatch(parameter.cType, "^String\\s*\\*$") then
                PortableCallV3(PortableIdentifierV3 "StringLit", [PortableNumberV3 "0"; PortableStringV3 "\"\""])
            else
                let arrayMatch = Regex.Match(parameter.cType, "^Array(?<id>[0-9]+)\\s*\\*$")
                if arrayMatch.Success then
                    PortableCallV3(PortableIdentifierV3 ("__spiral_empty_array_" + arrayMatch.Groups.["id"].Value), [])
                else
                    match tryRecursiveEmptyCase parameter.cType with
                    | Some tag ->
                        let suffix = parameter.cType.Substring("Recursive".Length)
                        PortableCallV3(PortableIdentifierV3 $"RecursiveCreate{suffix}_{tag}", [])
                    | None ->
                        failwith $"portable tail SCC state-exclusive managed slot has no safe empty representation: {parameter.name}:{parameter.cType}"
        let defaultSlotExpression (parameter : PortableParameterV2) =
            if isManagedSlotType parameter.cType then defaultManagedSlotExpression parameter
            elif parameter.cType = "bool" then PortableBooleanV3 false
            else PortableNumberV3 "0"
        let slotsForMembers (members : PortableFunctionV2 list) =
            let byName = Dictionary<string,PortableParameterV2>(StringComparer.Ordinal)
            let slots = ResizeArray<PortableParameterV2>()
            for memberFn in members do
                for parameter in memberFn.parameters do
                    match byName.TryGetValue parameter.name with
                    | true, existing when existing.cType <> parameter.cType ->
                        failwith $"portable tail SCC slot type conflict for {parameter.name}: {existing.cType} vs {parameter.cType}"
                    | true, _ -> ()
                    | false, _ ->
                        byName.[parameter.name] <- parameter
                        slots.Add parameter
            slots |> Seq.toList
        let optionalManagedSlotsForMembers (members : PortableFunctionV2 list) slots =
            slots
            |> List.filter (fun slot ->
                isManagedSlotType slot.cType &&
                (members |> List.exists (fun memberFn -> not (slotPresent memberFn slot))))
            |> List.map (fun slot ->
                if not (isOptionalManagedSlotType slot.cType) then
                    failwith $"portable tail SCC state-exclusive managed slot has no safe optional representation: {slot.name}:{slot.cType}"
                slot)
        let tailGraph = functions |> List.map (fun fn -> fn.name, directTailTargets fn) |> Map.ofList
        let reachableFrom startName =
            let seen = HashSet<string>(StringComparer.Ordinal)
            let rec visit name =
                if seen.Add name then
                    match Map.tryFind name tailGraph with
                    | Some targets -> targets |> List.iter visit
                    | None -> ()
            visit startName
            seen
        let reachability = Dictionary<string,HashSet<string>>(StringComparer.Ordinal)
        for fn in functions do reachability.[fn.name] <- reachableFrom fn.name
        let components = ResizeArray<PortableFunctionV2 list>()
        let assigned = HashSet<string>(StringComparer.Ordinal)
        for fn in functions do
            if not (assigned.Contains fn.name) then
                let members =
                    functions
                    |> List.filter (fun candidate ->
                        reachability.[fn.name].Contains candidate.name
                        && reachability.[candidate.name].Contains fn.name)
                if members.Length >= 2 then
                    members |> List.iter (fun memberFn -> assigned.Add memberFn.name |> ignore)
                    components.Add members
        let componentNames (members : PortableFunctionV2 list) =
            HashSet<string>(members |> List.map (fun memberFn -> memberFn.name), StringComparer.Ordinal)
        let hasNonTailComponentCall (memberNames : HashSet<string>) (fn : PortableFunctionV2) =
            fn.statements
            |> List.exists (fun statement ->
                match statement with
                | PortableReturnV3(Some(PortableCallV3(PortableIdentifierV3 targetName, _)))
                    when memberNames.Contains targetName -> false
                | _ -> memberNames |> Seq.exists (fun targetName -> portableStatementCallsV3 targetName statement))
        for members in components do
            let first = members.Head
            let names = componentNames members
            if members |> List.exists (fun memberFn -> memberFn.returnType <> first.returnType) then
                let detail = members |> List.map (fun memberFn -> $"{memberFn.name}:{memberFn.returnType}") |> String.concat ", "
                failwith $"portable tail SCC requires an identical return type: {detail}"
            if members |> List.exists hasNestedLoop then
                let detail = members |> List.map (fun memberFn -> memberFn.name) |> String.concat ", "
                failwith $"portable tail SCC cannot contain an existing loop: {detail}"
            let slots = slotsForMembers members
            let _ = optionalManagedSlotsForMembers members slots
            if slots |> List.exists (fun parameter -> not (portableTailLoopParameterType parameter.cType)) then
                let detail = slots |> List.map (fun parameter -> $"{parameter.name}:{parameter.cType}") |> String.concat ", "
                failwith $"portable tail SCC has unsupported parameter slots: {detail}"
            if members |> List.exists (hasNonTailComponentCall names) then
                let detail = members |> List.map (fun memberFn -> memberFn.name) |> String.concat ", "
                failwith $"portable tail SCC contains a non-tail component call: {detail}"
        let componentByName = Dictionary<string,PortableFunctionV2 list>(StringComparer.Ordinal)
        for members in components do
            for memberFn in members do componentByName.[memberFn.name] <- members
        let functionByName = Dictionary<string,PortableFunctionV2>(StringComparer.Ordinal)
        for fn in functions do functionByName.[fn.name] <- fn
        let managedCloneExpression (parameter : PortableParameterV2) argument =
            if isManagedSlotType parameter.cType then
                PortableCallV3(PortableIdentifierV3 "__spiral_clone", [argument])
            else argument
        let managedCloneStatements (parameter : PortableParameterV2) temporaryName =
            let temporary = PortableIdentifierV3 temporaryName
            let arrayMatch = Regex.Match(parameter.cType, "^Array(?<id>[0-9]+)\\s*\\*$")
            let recursiveMatch = Regex.Match(parameter.cType, "^Recursive(?<id>[0-9]+)$")
            if arrayMatch.Success then
                let suffix = arrayMatch.Groups.["id"].Value
                [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"DynamicArrayClone{suffix}", [temporary])) ]
            elif recursiveMatch.Success then
                let suffix = recursiveMatch.Groups.["id"].Value
                [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"RecursiveClone{suffix}", [temporary])) ]
            else []
        let managedDropStatements (parameter : PortableParameterV2) liveFlagName =
            let current = PortableIdentifierV3 parameter.name
            let arrayMatch = Regex.Match(parameter.cType, "^Array(?<id>[0-9]+)\\s*\\*$")
            let recursiveMatch = Regex.Match(parameter.cType, "^Recursive(?<id>[0-9]+)$")
            let drops =
                if arrayMatch.Success then
                    let suffix = arrayMatch.Groups.["id"].Value
                    [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"DynamicArrayDrop{suffix}", [current])) ]
                elif recursiveMatch.Success then
                    let suffix = recursiveMatch.Groups.["id"].Value
                    [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"RecursiveDrop{suffix}", [current])) ]
                else []
            match liveFlagName, drops with
            | _, [] -> []
            | Some flagName, _ ->
                PortableIfStartV3(PortableIdentifierV3 flagName) :: drops @ [PortableBlockEndV3]
            | None, _ -> drops
        let cleanupAbsentRecursiveSlots (memberFn : PortableFunctionV2) (optionalManagedSlots : PortableParameterV2 list) =
            optionalManagedSlots
            |> List.filter (fun slot ->
                isRecursiveSlotType slot.cType &&
                Option.isSome (tryRecursiveEmptyCase slot.cType) &&
                not (slotPresent memberFn slot))
            |> List.collect (fun slot ->
                let suffix = slot.cType.Substring("Recursive".Length)
                [ PortableExpressionStatementV3(PortableCallV3(PortableIdentifierV3 $"RecursiveDrop{suffix}", [PortableIdentifierV3 slot.name])) ])
        let taggedOptionalPrelude (memberFn : PortableFunctionV2) (optionalManagedSlots : PortableParameterV2 list) =
            optionalManagedSlots
            |> List.filter (fun slot -> isTaggedOptionalRecursiveSlot slot && slotPresent memberFn slot)
            |> List.collect (fun slot ->
                [ PortableDeclareV3(slot.cType, slot.name)
                  PortableAssignV3(slot.name, optionalRecursiveTakeExpression slot) ])
        let rewriteTailCalls stateByName (slots : PortableParameterV2 list) (optionalManagedSlots : PortableParameterV2 list) (memberFn : PortableFunctionV2) =
            let taggedOptionalSlots = optionalManagedSlots |> List.filter isTaggedOptionalRecursiveSlot
            let taggedNames = HashSet<string>(taggedOptionalSlots |> List.map (fun slot -> slot.name), StringComparer.Ordinal)
            let optionalNames =
                HashSet<string>(
                    optionalManagedSlots
                    |> List.filter (isTaggedOptionalRecursiveSlot >> not)
                    |> List.map (fun slot -> slot.name),
                    StringComparer.Ordinal)
            let returnCleanup = cleanupAbsentRecursiveSlots memberFn optionalManagedSlots
            (taggedOptionalPrelude memberFn optionalManagedSlots @ memberFn.statements)
            |> List.collect (fun statement ->
                match statement with
                | PortableReturnV3(Some(PortableCallV3(PortableIdentifierV3 targetName, arguments))) when Map.containsKey targetName stateByName ->
                    let target = functionByName.[targetName]
                    if arguments.Length <> target.parameters.Length then
                        failwith $"portable tail SCC arity mismatch for {targetName}: expected {target.parameters.Length}, got {arguments.Length}"
                    let argumentByName =
                        List.zip target.parameters arguments
                        |> List.map (fun (parameter, argument) -> parameter.name, argument)
                        |> Map.ofList
                    let temporaries =
                        slots
                        |> List.mapi (fun index parameter ->
                            let isTagged = taggedNames.Contains parameter.name
                            let storageParameter = if isTagged then optionalRecursiveStorageParameter parameter else parameter
                            match Map.tryFind parameter.name argumentByName with
                            | Some argument ->
                                let value = if isTagged then optionalRecursiveSomeExpression parameter argument else argument
                                parameter, storageParameter, $"__spiral_scc_arg{index}", value, true
                            | None ->
                                let value = if isTagged then optionalRecursiveNoneExpression parameter else defaultSlotExpression parameter
                                parameter, storageParameter, $"__spiral_scc_arg{index}", value, false)
                    [ for parameter, storageParameter, name, argument, isLive in temporaries do
                          yield PortableDeclareV3(storageParameter.cType, name)
                          let value =
                              if taggedNames.Contains parameter.name then argument
                              elif isLive then managedCloneExpression parameter argument
                              else argument
                          yield PortableAssignV3(name, value)
                      for parameter, _, name, _, isLive in temporaries do
                          if taggedNames.Contains parameter.name then
                              let suffix = optionalRecursiveSuffix parameter
                              if isLive then
                                  yield PortableExpressionStatementV3(PortableCallV3(
                                      PortableIdentifierV3 ("__spiral_delphi_optional_recursive_clone_" + suffix),
                                      [PortableIdentifierV3 name]))
                              if slotPresent memberFn parameter then
                                  yield! managedDropStatements parameter None
                              yield PortableExpressionStatementV3(PortableCallV3(
                                  PortableIdentifierV3 ("__spiral_delphi_optional_recursive_drop_" + suffix),
                                  [PortableIdentifierV3 (optionalRecursiveStorageName parameter)]))
                              yield PortableAssignV3(optionalRecursiveStorageName parameter, PortableIdentifierV3 name)
                          else
                              if isLive then yield! managedCloneStatements parameter name
                              let liveFlagName =
                                  if optionalNames.Contains parameter.name then Some(optionalManagedFlagName parameter)
                                  else None
                              let dropGuard =
                                  match liveFlagName with
                                  | Some _ when isRecursiveSlotType parameter.cType -> None
                                  | other -> other
                              yield! managedDropStatements parameter dropGuard
                              yield PortableAssignV3(parameter.name, PortableIdentifierV3 name)
                              match liveFlagName with
                              | Some flagName -> yield PortableAssignV3(flagName, PortableBooleanV3 isLive)
                              | None -> ()
                      yield PortableAssignV3("__spiral_tail_state", PortableNumberV3(string stateByName.[targetName]))
                      yield PortableContinueV3 ]
                | PortableReturnV3 _ -> returnCleanup @ [statement]
                | _ -> [statement])
        let dispatcherStatements stateByName (slots : PortableParameterV2 list) (optionalManagedSlots : PortableParameterV2 list) (members : PortableFunctionV2 list) =
            let rec dispatch index remaining =
                match remaining with
                | [] -> failwith "portable tail SCC dispatcher has no members"
                | [memberFn] -> rewriteTailCalls stateByName slots optionalManagedSlots memberFn
                | memberFn :: tail ->
                    [ yield PortableIfStartV3(PortableBinaryV3("==", PortableIdentifierV3 "__spiral_tail_state", PortableNumberV3(string index)))
                      yield! rewriteTailCalls stateByName slots optionalManagedSlots memberFn
                      yield PortableElseV3
                      yield! dispatch (index + 1) tail
                      yield PortableBlockEndV3 ]
            [ yield PortableWhileStartV3(PortableBooleanV3 true)
              yield! dispatch 0 members
              yield PortableBlockEndV3 ]
        let result = ResizeArray<PortableFunctionV2>()
        let emitted = HashSet<string>(StringComparer.Ordinal)
        for fn in functions do
            if emitted.Add fn.name then
                match componentByName.TryGetValue fn.name with
                | true, members ->
                    members |> List.iter (fun memberFn -> emitted.Add memberFn.name |> ignore)
                    let stateByName = members |> List.mapi (fun index memberFn -> memberFn.name, index) |> Map.ofList
                    let slots = slotsForMembers members
                    let optionalManagedSlots = optionalManagedSlotsForMembers members slots
                    let dispatcherSlots =
                        slots
                        |> List.map (fun slot ->
                            if optionalManagedSlots |> List.exists (fun optional -> optional.name = slot.name && isTaggedOptionalRecursiveSlot optional) then
                                optionalRecursiveStorageParameter slot
                            else slot)
                    let liveParameters =
                        optionalManagedSlots
                        |> List.filter (isTaggedOptionalRecursiveSlot >> not)
                        |> List.map (fun slot -> { cType = "bool"; name = optionalManagedFlagName slot })
                    let dispatcherName = "__spiral_scc_" + (members |> List.map (fun memberFn -> memberFn.name) |> String.concat "_")
                    let dispatcherParameters = { cType = "int32_t"; name = "__spiral_tail_state" } :: (dispatcherSlots @ liveParameters)
                    result.Add {
                        returnType = members.Head.returnType
                        name = dispatcherName
                        parameters = dispatcherParameters
                        statements = dispatcherStatements stateByName slots optionalManagedSlots members
                        }
                    for memberFn in members do
                        let slotArguments =
                            slots
                            |> List.map (fun slot ->
                                let isTagged =
                                    optionalManagedSlots
                                    |> List.exists (fun optional -> optional.name = slot.name && isTaggedOptionalRecursiveSlot optional)
                                match memberFn.parameters |> List.tryFind (fun parameter -> parameter.name = slot.name && parameter.cType = slot.cType) with
                                | Some parameter when isTagged -> optionalRecursiveSomeExpression slot (PortableIdentifierV3 parameter.name)
                                | Some parameter -> PortableIdentifierV3 parameter.name
                                | None when isTagged -> optionalRecursiveNoneExpression slot
                                | None -> defaultSlotExpression slot)
                        let liveArguments =
                            optionalManagedSlots
                            |> List.filter (isTaggedOptionalRecursiveSlot >> not)
                            |> List.map (fun slot -> PortableBooleanV3(slotPresent memberFn slot))
                        let wrapperArguments = slotArguments @ liveArguments
                        result.Add {
                            returnType = memberFn.returnType
                            name = memberFn.name
                            parameters = memberFn.parameters
                            statements =
                                [ PortableReturnV3(Some(PortableCallV3(
                                    PortableIdentifierV3 dispatcherName,
                                    PortableNumberV3(string stateByName.[memberFn.name]) :: wrapperArguments))) ]
                            }
                | _ -> result.Add fn
        result |> Seq.toList
    
    let private rustFromPortableProgramC (closureShapes : PortableClosureShape list) (generated : string) =
        let usesStrings = generated.Contains("String *", StringComparison.Ordinal)
        let usesStringIndex = generated.Contains("PortableStringIndex(", StringComparison.Ordinal)
        let usesStringScalar = generated.Contains("PortableStringScalar(", StringComparison.Ordinal)
        let usesStringSlice = generated.Contains("PortableStringSlice(", StringComparison.Ordinal)
        let usesStringConcat = generated.Contains("PortableStringConcat(", StringComparison.Ordinal)
        let recursiveUnions, layouts, arrays, tuples, parsedFunctions = parsePortableProgramC closureShapes generated
        let functions = lowerPortableTailSccs recursiveUnions parsedFunctions
        let tupleByName = tuples |> List.map (fun tupleType -> tupleType.name, tupleType) |> Map.ofList
        let rec typeNeedsManagedClone (visited : Set<string>) (cType : string) =
            if Regex.IsMatch(cType, "^(?:Array[0-9]+\\s*\\*|(?:Heap|Mut)[0-9]+\\s*\\*|String\\s*\\*|Recursive[0-9]+|OptionalRecursive[0-9]+|WeakRecursive[0-9]+)$") then true
            elif Set.contains cType visited then false
            else
                match Map.tryFind cType tupleByName with
                | Some tupleType -> tupleType.fields |> List.exists (fun field -> typeNeedsManagedClone (Set.add cType visited) field.cType)
                | None -> false
        let managedType cType = typeNeedsManagedClone Set.empty cType
        let rec typeHasPortableDefault (visited : Set<string>) (cType : string) =
            if Regex.IsMatch(cType, "^(?:bool|char|(?:u?int(?:8|16|32|64)_t)|float|double|Array[0-9]+\\s*\\*|String\\s*\\*|OptionalRecursive[0-9]+|WeakRecursive[0-9]+)$") then true
            elif Regex.IsMatch(cType, "^Recursive[0-9]+$") || Set.contains cType visited then false
            else
                match Map.tryFind cType tupleByName with
                | Some tupleType -> tupleType.fields |> List.forall (fun field -> typeHasPortableDefault (Set.add cType visited) field.cType)
                | None -> false
        let portableDefault cType =
            let targetType = rustType cType
            if Regex.IsMatch(cType, "^Tuple[0-9]+$") then
                if typeHasPortableDefault Set.empty cType then $"{targetType}::default()"
                else failwith $"portable Rust backend cannot zero-initialize managed tuple type: {cType}"
            else rustDefault targetType
        let rec collectTupleDefaults cType (names : Set<string>) =
            match Map.tryFind cType tupleByName with
            | Some tupleType when not (Set.contains cType names) ->
                tupleType.fields
                |> List.fold (fun state field -> collectTupleDefaults field.cType state) (Set.add cType names)
            | _ -> names
        let tupleDefaultNames =
            arrays
            |> List.fold (fun state arrayType -> collectTupleDefaults arrayType.elementType state) Set.empty
        let output = StringBuilder()
        output.AppendLine("// Generated by Spiral portable Rust backend.") |> ignore
        output.AppendLine("#![allow(unused_mut, non_snake_case, dead_code)]") |> ignore
        output.AppendLine() |> ignore
        if (layouts |> List.exists (fun layout -> layout.name.StartsWith("Mut", StringComparison.Ordinal))) || not arrays.IsEmpty then
            output.AppendLine("use std::cell::RefCell;") |> ignore
        let weakRecursiveSuffixes =
            [ yield! arrays |> List.map (fun arrayType -> arrayType.elementType)
              yield! tuples |> List.collect (fun tupleType -> tupleType.fields |> List.map (fun field -> field.cType))
              yield! layouts |> List.collect (fun layout -> layout.fields |> List.map (fun field -> field.cType))
              yield!
                  recursiveUnions
                  |> List.collect (fun recursiveUnion ->
                      recursiveUnion.cases
                      |> List.collect (fun (_, parameters) -> parameters |> List.map (fun parameter -> parameter.cType)))
              yield!
                  functions
                  |> List.collect (fun fn ->
                      [ yield! fn.parameters |> List.map (fun parameter -> parameter.cType)
                        for statement in fn.statements do
                            match statement with
                            | PortableDeclareV3(cType, _) -> yield cType
                            | _ -> () ]) ]
            |> List.choose (fun cType ->
                let matched = Regex.Match(cType, "^WeakRecursive(?<id>[0-9]+)$")
                if matched.Success then Some matched.Groups.["id"].Value else None)
            |> List.distinct
        let usesWeakRecursive = not weakRecursiveSuffixes.IsEmpty
        if usesStrings || not layouts.IsEmpty || not arrays.IsEmpty || not recursiveUnions.IsEmpty then
            if usesWeakRecursive then output.AppendLine("use std::rc::{Rc, Weak};") |> ignore
            else output.AppendLine("use std::rc::Rc;") |> ignore
            output.AppendLine() |> ignore
        if usesStringIndex then
            output.AppendLine("fn SpiralStringIndex(value: &Rc<str>, index: i32) -> u8 {") |> ignore
            output.AppendLine("    assert!(index >= 0, \"negative Spiral string index\");") |> ignore
            output.AppendLine("    let bytes = value.as_bytes();") |> ignore
            output.AppendLine("    let index = index as usize;") |> ignore
            output.AppendLine("    assert!(index < bytes.len(), \"Spiral string index out of bounds\");") |> ignore
            output.AppendLine("    bytes[index]") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        if usesStringScalar then
            output.AppendLine("fn SpiralStringScalar(value: &Rc<str>, byte_offset: i32) -> i32 {") |> ignore
            output.AppendLine("    assert!(byte_offset >= 0, \"negative Spiral UTF-8 scalar offset\");") |> ignore
            output.AppendLine("    let bytes = value.as_bytes();") |> ignore
            output.AppendLine("    let offset = byte_offset as usize;") |> ignore
            output.AppendLine("    assert!(offset < bytes.len(), \"Spiral UTF-8 scalar offset out of bounds\");") |> ignore
            output.AppendLine("    let first = bytes[offset];") |> ignore
            output.AppendLine("    let (width, mut scalar, minimum): (usize, u32, u32) = if first < 0x80 {") |> ignore
            output.AppendLine("        (1, first as u32, 0)") |> ignore
            output.AppendLine("    } else if (0xC2..=0xDF).contains(&first) {") |> ignore
            output.AppendLine("        (2, (first & 0x1F) as u32, 0x80)") |> ignore
            output.AppendLine("    } else if (0xE0..=0xEF).contains(&first) {") |> ignore
            output.AppendLine("        (3, (first & 0x0F) as u32, 0x800)") |> ignore
            output.AppendLine("    } else if (0xF0..=0xF4).contains(&first) {") |> ignore
            output.AppendLine("        (4, (first & 0x07) as u32, 0x10000)") |> ignore
            output.AppendLine("    } else {") |> ignore
            output.AppendLine("        panic!(\"invalid Spiral UTF-8 lead byte\")") |> ignore
            output.AppendLine("    };") |> ignore
            output.AppendLine("    assert!(offset + width <= bytes.len(), \"truncated Spiral UTF-8 scalar\");") |> ignore
            output.AppendLine("    for continuation in &bytes[offset + 1..offset + width] {") |> ignore
            output.AppendLine("        assert!((*continuation & 0xC0) == 0x80, \"invalid Spiral UTF-8 continuation byte\");") |> ignore
            output.AppendLine("        scalar = (scalar << 6) | (*continuation & 0x3F) as u32;") |> ignore
            output.AppendLine("    }") |> ignore
            output.AppendLine("    assert!(scalar >= minimum, \"overlong Spiral UTF-8 scalar\");") |> ignore
            output.AppendLine("    assert!(!(0xD800..=0xDFFF).contains(&scalar), \"surrogate Spiral UTF-8 scalar\");") |> ignore
            output.AppendLine("    assert!(scalar <= 0x10FFFF, \"Spiral UTF-8 scalar exceeds Unicode range\");") |> ignore
            output.AppendLine("    scalar as i32") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        if usesStringSlice then
            output.AppendLine("fn SpiralStringSlice(value: &Rc<str>, from_index: i32, to_index: i32) -> Rc<str> {") |> ignore
            output.AppendLine("    assert!(from_index >= 0, \"negative Spiral string slice start\");") |> ignore
            output.AppendLine("    let bytes = value.as_bytes();") |> ignore
            output.AppendLine("    let length = bytes.len() as i32;") |> ignore
            output.AppendLine("    if to_index < from_index { return Rc::<str>::from(\"\"); }") |> ignore
            output.AppendLine("    assert!(from_index <= length, \"Spiral string slice start out of bounds\");") |> ignore
            output.AppendLine("    assert!(to_index < length, \"Spiral string slice end out of bounds\");") |> ignore
            output.AppendLine("    let from_index = from_index as usize;") |> ignore
            output.AppendLine("    let to_index = to_index as usize;") |> ignore
            output.AppendLine("    let slice = &bytes[from_index..=to_index];") |> ignore
            output.AppendLine("    Rc::<str>::from(std::str::from_utf8(slice).expect(\"Spiral string slice must preserve UTF-8 boundaries\"))") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        if usesStringConcat then
            output.AppendLine("fn SpiralStringConcat(left: &Rc<str>, right: &Rc<str>) -> Rc<str> {") |> ignore
            output.AppendLine("    let mut value = String::with_capacity(left.len() + right.len());") |> ignore
            output.AppendLine("    value.push_str(left);") |> ignore
            output.AppendLine("    value.push_str(right);") |> ignore
            output.AppendLine("    Rc::<str>::from(value.into_boxed_str())") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        for layout in layouts do
            let prefix = if layout.name.StartsWith("Mut", StringComparison.Ordinal) then "Mut" else "Heap"
            let suffix = layout.name.Substring(prefix.Length)
            let dataName = layout.name + "Data"
            let isMutable = prefix = "Mut"
            if isMutable then output.AppendLine($"type {layout.name} = Rc<RefCell<{dataName}>>;") |> ignore
            else output.AppendLine($"type {layout.name} = Rc<{dataName}>;") |> ignore
            output.AppendLine("#[derive(Clone)]") |> ignore
            output.AppendLine($"struct {dataName} {{") |> ignore
            for field in layout.fields do
                output.AppendLine($"    {field.name}: {rustType field.cType},") |> ignore
            output.AppendLine("}") |> ignore
            let parameters = layout.fields |> List.map (fun field -> $"{field.name}: {rustType field.cType}") |> String.concat ", "
            let fields = layout.fields |> List.map (fun field -> field.name) |> String.concat ", "
            output.AppendLine($"fn {prefix}Create{suffix}({parameters}) -> {layout.name} {{") |> ignore
            if isMutable then output.AppendLine($"    Rc::new(RefCell::new({dataName} {{ {fields} }}))") |> ignore
            else output.AppendLine($"    Rc::new({dataName} {{ {fields} }})") |> ignore
            output.AppendLine("}") |> ignore
            if isMutable then
                output.AppendLine($"fn MutAssign{suffix}(value: &{layout.name}, {parameters}) {{") |> ignore
                output.AppendLine("    let mut value = value.borrow_mut();") |> ignore
                for field in layout.fields do
                    output.AppendLine($"    value.{field.name} = {field.name};") |> ignore
                output.AppendLine("}") |> ignore
            for index, field in layout.fields |> List.indexed do
                let targetType = rustType field.cType
                let cloneSuffix =
                    if Regex.IsMatch(targetType, "^(?:i(?:8|16|32|64)|u(?:8|16|32|64)|f(?:32|64)|bool)$") then "" else ".clone()"
                output.AppendLine($"fn {prefix}Get{suffix}_{index}(value: &{layout.name}) -> {rustType field.cType} {{") |> ignore
                if isMutable then output.AppendLine($"    value.borrow().{field.name}{cloneSuffix}") |> ignore
                else output.AppendLine($"    value.{field.name}{cloneSuffix}") |> ignore
                output.AppendLine("}") |> ignore
            output.AppendLine($"fn {prefix}Decref{suffix}(_value: &{layout.name}) {{}}") |> ignore
            output.AppendLine() |> ignore
        for recursiveUnion in recursiveUnions do
            let suffix = recursiveUnion.name.Substring("Recursive".Length)
            let nodeName = recursiveUnion.name + "Node"
            output.AppendLine($"type {recursiveUnion.name} = Rc<{nodeName}>;") |> ignore
            output.AppendLine("#[derive(Clone)]") |> ignore
            output.AppendLine($"enum {nodeName} {{") |> ignore
            for tag, parameters in recursiveUnion.cases do
                if parameters.IsEmpty then output.AppendLine($"    Case{tag},") |> ignore
                else
                    let fields = parameters |> List.map (fun parameter -> $"{parameter.name}: {rustType parameter.cType}") |> String.concat ", "
                    output.AppendLine($"    Case{tag} {{ {fields} }},") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
            for tag, parameters in recursiveUnion.cases do
                let parameterText = parameters |> List.map (fun parameter -> $"{parameter.name}: {rustType parameter.cType}") |> String.concat ", "
                output.AppendLine($"fn RecursiveCreate{suffix}_{tag}({parameterText}) -> {recursiveUnion.name} {{") |> ignore
                if parameters.IsEmpty then output.AppendLine($"    Rc::new({nodeName}::Case{tag})") |> ignore
                else
                    let fields = parameters |> List.map (fun parameter -> parameter.name) |> String.concat ", "
                    output.AppendLine($"    Rc::new({nodeName}::Case{tag} {{ {fields} }})") |> ignore
                output.AppendLine("}") |> ignore
                let selfWeakFields = parameters |> List.filter (fun parameter -> parameter.cType = "Weak" + recursiveUnion.name)
                if selfWeakFields.Length = 1 then
                    let weakField = selfWeakFields.Head
                    let nonWeakParameters = parameters |> List.filter (fun parameter -> parameter.name <> weakField.name)
                    let selfParameterText = nonWeakParameters |> List.map (fun parameter -> $"{parameter.name}: {rustType parameter.cType}") |> String.concat ", "
                    let selfFields =
                        parameters
                        |> List.map (fun parameter -> if parameter.name = weakField.name then $"{parameter.name}: self_weak.clone()" else parameter.name)
                        |> String.concat ", "
                    output.AppendLine($"fn RecursiveCreateWeakSelf{suffix}_{tag}({selfParameterText}) -> {recursiveUnion.name} {{") |> ignore
                    output.AppendLine($"    Rc::new_cyclic(|self_weak| {nodeName}::Case{tag} {{ {selfFields} }})") |> ignore
                    output.AppendLine("}") |> ignore
            output.AppendLine($"fn RecursiveTag{suffix}(value: &{recursiveUnion.name}) -> i32 {{") |> ignore
            output.AppendLine("    match value.as_ref() {") |> ignore
            for tag, parameters in recursiveUnion.cases do
                if parameters.IsEmpty then output.AppendLine($"        {nodeName}::Case{tag} => {tag},") |> ignore
                else output.AppendLine($"        {nodeName}::Case{tag} {{ .. }} => {tag},") |> ignore
            output.AppendLine("    }") |> ignore
            output.AppendLine("}") |> ignore
            let legacyFieldHelpers =
                recursiveUnion.recursiveCases.Length = 1 &&
                (recursiveUnion.cases |> List.forall (fun (tag, parameters) -> tag = recursiveUnion.recursiveCases.Head || parameters.IsEmpty))
            let emitFieldHelper (helperName : string) tag fieldIndex (parameter : PortableParameterV2) =
                output.AppendLine($"fn {helperName}(value: &{recursiveUnion.name}) -> {rustType parameter.cType} {{") |> ignore
                output.AppendLine("    match value.as_ref() {") |> ignore
                let result =
                    if managedType parameter.cType then parameter.name + ".clone()"
                    else "*" + parameter.name
                output.AppendLine($"        {nodeName}::Case{tag} {{ {parameter.name}, .. }} => {result},") |> ignore
                let panicText =
                    if helperName.StartsWith("RecursiveField", StringComparison.Ordinal) then $"recursive union field {fieldIndex} requested from wrong case"
                    else $"recursive union case {tag} field {fieldIndex} requested from wrong case"
                output.AppendLine($"        _ => panic!(\"{panicText}\"),") |> ignore
                output.AppendLine("    }") |> ignore
                output.AppendLine("}") |> ignore
            if legacyFieldHelpers then
                let tag = recursiveUnion.recursiveCases.Head
                let _, parameters = recursiveUnion.cases |> List.find (fun (caseTag, _) -> caseTag = tag)
                for fieldIndex, parameter in parameters |> List.indexed do
                    emitFieldHelper $"RecursiveField{suffix}_{fieldIndex}" tag fieldIndex parameter
            else
                for tag, parameters in recursiveUnion.cases do
                    for fieldIndex, parameter in parameters |> List.indexed do
                        emitFieldHelper $"RecursiveCaseField{suffix}_{tag}_{fieldIndex}" tag fieldIndex parameter
            output.AppendLine($"fn RecursiveClone{suffix}(_value: &{recursiveUnion.name}) {{}}") |> ignore
            output.AppendLine($"fn RecursiveDrop{suffix}(_value: &{recursiveUnion.name}) {{}}") |> ignore
            if List.contains suffix weakRecursiveSuffixes then
                output.AppendLine($"fn WeakRecursiveDowngrade{suffix}(value: &{recursiveUnion.name}) -> Weak<{nodeName}> {{ Rc::downgrade(value) }}") |> ignore
                output.AppendLine($"fn WeakRecursiveUpgrade{suffix}(value: &Weak<{nodeName}>) -> Option<{recursiveUnion.name}> {{ value.upgrade() }}") |> ignore
                output.AppendLine($"fn WeakRecursiveClone{suffix}(value: &Weak<{nodeName}>) -> Weak<{nodeName}> {{ value.clone() }}") |> ignore
                output.AppendLine($"fn WeakRecursiveDrop{suffix}(_value: &Weak<{nodeName}>) {{}}") |> ignore
            output.AppendLine() |> ignore
        for arrayType in arrays do
            let elementType = rustType arrayType.elementType
            let suffix = arrayType.name.Substring("Array".Length)
            let helperUsed helperName =
                functions
                |> List.exists (fun fn -> fn.statements |> List.exists (portableStatementCallsV3 helperName))
            let usesResize = helperUsed $"DynamicArrayResize{suffix}"
            let usesReserve = helperUsed $"DynamicArrayReserve{suffix}"
            let usesCapacity = helperUsed $"DynamicArrayCapacity{suffix}"
            let usesRefCount = helperUsed $"DynamicArrayRefCount{suffix}"
            let usesClone = helperUsed $"DynamicArrayClone{suffix}"
            output.AppendLine($"type {arrayType.name} = Rc<RefCell<Vec<{elementType}>>>;") |> ignore
            output.AppendLine($"fn ArrayCreate{suffix}(len: i32, _init_at_zero: bool) -> {arrayType.name} {{") |> ignore
            output.AppendLine("    assert!(len >= 0, \"negative Spiral array length\");") |> ignore
            output.AppendLine($"    Rc::new(RefCell::new(vec![{portableDefault arrayType.elementType}; len as usize]))") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine($"fn DynamicArraySet{suffix}(array: &{arrayType.name}, index: i32, value: {elementType}) {{") |> ignore
            output.AppendLine("    assert!(index >= 0, \"negative Spiral array index\");") |> ignore
            output.AppendLine("    let mut data = array.borrow_mut();") |> ignore
            output.AppendLine("    let index = index as usize;") |> ignore
            output.AppendLine("    assert!(index < data.len(), \"Spiral array index out of bounds\");") |> ignore
            output.AppendLine("    data[index] = value;") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine($"fn DynamicArrayGet{suffix}(array: &{arrayType.name}, index: i32) -> {elementType} {{") |> ignore
            output.AppendLine("    assert!(index >= 0, \"negative Spiral array index\");") |> ignore
            output.AppendLine("    let data = array.borrow();") |> ignore
            output.AppendLine("    let index = index as usize;") |> ignore
            output.AppendLine("    assert!(index < data.len(), \"Spiral array index out of bounds\");") |> ignore
            if managedType arrayType.elementType then
                output.AppendLine("    data[index].clone()") |> ignore
            else
                output.AppendLine("    data[index]") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine($"fn DynamicArrayLen{suffix}(array: &{arrayType.name}) -> i32 {{") |> ignore
            output.AppendLine("    let len = array.borrow().len();") |> ignore
            output.AppendLine("    assert!(len <= i32::MAX as usize, \"Spiral array length exceeds i32\");") |> ignore
            output.AppendLine("    len as i32") |> ignore
            output.AppendLine("}") |> ignore
            if usesResize then
                output.AppendLine($"fn DynamicArrayResize{suffix}(array: &{arrayType.name}, len: i32) {{") |> ignore
                output.AppendLine("    assert!(len >= 0, \"negative Spiral array length\");") |> ignore
                output.AppendLine($"    array.borrow_mut().resize(len as usize, {portableDefault arrayType.elementType});") |> ignore
                output.AppendLine("}") |> ignore
            if usesReserve then
                output.AppendLine($"fn DynamicArrayReserve{suffix}(array: &{arrayType.name}, capacity: i32) {{") |> ignore
                output.AppendLine("    assert!(capacity >= 0, \"negative Spiral array capacity\");") |> ignore
                output.AppendLine("    let mut data = array.borrow_mut();") |> ignore
                output.AppendLine("    let requested = capacity as usize;") |> ignore
                output.AppendLine("    let current = data.capacity();") |> ignore
                output.AppendLine("    if requested > current {") |> ignore
                output.AppendLine("        let mut target = current.max(1);") |> ignore
                output.AppendLine("        while target < requested {") |> ignore
                output.AppendLine("            match target.checked_mul(2) {") |> ignore
                output.AppendLine("                Some(next) => target = next,") |> ignore
                output.AppendLine("                None => { target = requested; break; }") |> ignore
                output.AppendLine("            }") |> ignore
                output.AppendLine("        }") |> ignore
                output.AppendLine("        let additional = target.saturating_sub(data.len());") |> ignore
                output.AppendLine("        data.reserve_exact(additional);") |> ignore
                output.AppendLine("    }") |> ignore
                output.AppendLine("}") |> ignore
            if usesCapacity then
                output.AppendLine($"fn DynamicArrayCapacity{suffix}(array: &{arrayType.name}) -> i32 {{") |> ignore
                output.AppendLine("    let capacity = array.borrow().capacity();") |> ignore
                output.AppendLine("    assert!(capacity <= i32::MAX as usize, \"Spiral array capacity exceeds i32\");") |> ignore
                output.AppendLine("    capacity as i32") |> ignore
                output.AppendLine("}") |> ignore
            if usesRefCount then
                output.AppendLine($"fn DynamicArrayRefCount{suffix}(array: &{arrayType.name}) -> i32 {{") |> ignore
                output.AppendLine("    let count = Rc::strong_count(array);") |> ignore
                output.AppendLine("    assert!(count <= i32::MAX as usize, \"Spiral array reference count exceeds i32\");") |> ignore
                output.AppendLine("    count as i32") |> ignore
                output.AppendLine("}") |> ignore
            if usesClone then
                output.AppendLine($"fn DynamicArrayClone{suffix}(_array: &{arrayType.name}) {{}}") |> ignore
            output.AppendLine($"fn DynamicArrayDrop{suffix}(_array: &{arrayType.name}) {{}}") |> ignore
            output.AppendLine() |> ignore
        for tupleType in tuples do
            let tupleNeedsManagedClone = tupleType.fields |> List.exists (fun field -> managedType field.cType)
            let tupleHasDefault = Set.contains tupleType.name tupleDefaultNames
            output.AppendLine(
                match tupleNeedsManagedClone, tupleHasDefault with
                | true, true -> "#[derive(Clone, Default)]"
                | true, false -> "#[derive(Clone)]"
                | false, true -> "#[derive(Clone, Copy, Default)]"
                | false, false -> "#[derive(Clone, Copy)]") |> ignore
            output.AppendLine($"struct {tupleType.name} {{") |> ignore
            for field in tupleType.fields do
                output.AppendLine($"    {field.name}: {rustType field.cType},") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
            let constructorName = portableTupleConstructorName tupleType.name
            let parameters = tupleType.constructorParameters |> List.map (fun field -> $"{field.name}: {rustType field.cType}") |> String.concat ", "
            let fields = tupleType.fields |> List.map (fun field -> field.name) |> String.concat ", "
            output.AppendLine($"fn {constructorName}({parameters}) -> {tupleType.name} {{") |> ignore
            output.AppendLine($"    {tupleType.name} {{ {fields} }}") |> ignore
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        let rec expressionUsesIdentifier expected = function
            | PortableIdentifierV3 value -> value = expected
            | PortableCallV3(PortableIdentifierV3 "PortableRustExprBase64", [PortableStringV3 encoded]) ->
                let payload = encoded.Substring(1, encoded.Length - 2)
                let code = Encoding.UTF8.GetString(Convert.FromBase64String payload)
                // Interop hides its variable uses from the portable AST. Conservatively
                // retain names mentioned by the Rust payload, including in macro tokens.
                Regex.IsMatch(code, $@"\b{Regex.Escape expected}\b")
            | PortableCallV3(callee, arguments) ->
                expressionUsesIdentifier expected callee || (arguments |> List.exists (expressionUsesIdentifier expected))
            | PortableUnaryV3(_, operand) | PortableCastV3(_, operand) -> expressionUsesIdentifier expected operand
            | PortableBinaryV3(_, left, right) -> expressionUsesIdentifier expected left || expressionUsesIdentifier expected right
            | PortableFieldV3(target, _) -> expressionUsesIdentifier expected target
            | _ -> false
        let statementUsesIdentifier expected = function
            | PortableAssignV3(target, expression) -> target = expected || expressionUsesIdentifier expected expression
            | PortableExpressionStatementV3 expression -> expressionUsesIdentifier expected expression
            | PortableReturnV3(Some expression) -> expressionUsesIdentifier expected expression
            | PortableIfStartV3 expression | PortableWhileStartV3 expression -> expressionUsesIdentifier expected expression
            | _ -> false
        for fn in functions do
            let assignmentCounts = assignmentCountsV2 fn.statements
            let usesTailLoop = portableFunctionUsesTailLoop fn
            let sourceTypes =
                seq {
                    for parameter in fn.parameters do yield parameter.name, parameter.cType
                    for statement in fn.statements do
                        match statement with
                        | PortableDeclareV3(cType, name) -> yield name, cType
                        | _ -> ()
                }
                |> Map.ofSeq
            let parameters =
                fn.parameters
                |> List.map (fun parameter ->
                    let mutableKeyword = if assignmentCounts.ContainsKey parameter.name || usesTailLoop then "mut " else ""
                    let renderedName =
                        if fn.statements |> List.exists (statementUsesIdentifier parameter.name) then parameter.name
                        else "_" + parameter.name
                    $"{mutableKeyword}{renderedName}: {rustType parameter.cType}")
                |> String.concat ", "
            let returnType = if fn.returnType = "void" then "()" else rustType fn.returnType
            output.AppendLine($"fn {rustFunctionNameV2 fn.name}({parameters}) -> {returnType} {{") |> ignore
            let mutable indentLevel = 1
            let emit text = output.AppendLine(String(' ', indentLevel * 4) + text) |> ignore
            if usesTailLoop then
                emit "'spiral_tail: loop {"
                indentLevel <- indentLevel + 1
            let renderAssignment name expression =
                let rendered = rustExpressionV3Expected (Map.tryFind name sourceTypes) expression
                match Map.tryFind name sourceTypes, expression with
                | Some cType, PortableFieldV3 _ when managedType cType -> rendered + ".clone()"
                | _ -> rendered
            let rec emitStatements statements =
                match statements with
                | PortableDeclareV3(cType, name) :: PortableAssignV3(assignedName, expression) :: tail when name = assignedName ->
                    let mutableKeyword =
                        match assignmentCounts.TryGetValue name with
                        | true, count when count > 1 -> "mut "
                        | _ -> ""
                    let rendered = renderAssignment name expression
                    emit $"let {mutableKeyword}{name}: {rustType cType} = {rendered};"
                    emitStatements tail
                | statement :: tail ->
                    match statement with
                    | PortableDeclareV3(cType, name) ->
                        let mutableKeyword =
                            match assignmentCounts.TryGetValue name with
                            | true, count when count > 1 -> "mut "
                            | _ -> ""
                        emit $"let {mutableKeyword}{name}: {rustType cType};"
                    | PortableAssignV3(name, expression) ->
                        emit $"{name} = {renderAssignment name expression};"
                    | PortableExpressionStatementV3 expression ->
                        emit $"{rustExpressionV3 expression};"
                    | PortableReturnV3 expression ->
                        match expression with
                        | None ->
                            if tail = [] || usesTailLoop then emit "return;"
                            else emit "return;"
                        | Some(PortableCallV3(PortableIdentifierV3 name, arguments)) when usesTailLoop && name = fn.name ->
                            if arguments.Length <> fn.parameters.Length then
                                failwith $"portable Rust tail loop arity mismatch in {fn.name}: expected {fn.parameters.Length}, got {arguments.Length}"
                            for index, argument in arguments |> List.indexed do
                                let parameter = fn.parameters.[index]
                                emit $"let __spiral_tail_arg{index}: {rustType parameter.cType} = {portableTailLoopRustArgument parameter argument};"
                            for index, parameter in fn.parameters |> List.indexed do
                                emit $"{parameter.name} = __spiral_tail_arg{index};"
                            emit "continue 'spiral_tail;"
                        | Some value ->
                            let rendered = rustExpressionV3Expected (Some fn.returnType) value
                            emit $"return {rendered};"
                    | PortableIfStartV3 condition ->
                        emit $"if {rustExpressionV3 condition} {{"
                        indentLevel <- indentLevel + 1
                    | PortableWhileStartV3(PortableBooleanV3 true) ->
                        emit "loop {"
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
                    emitStatements tail
                | [] -> ()
            emitStatements fn.statements
            let expectedIndent = if usesTailLoop then 2 else 1
            if indentLevel <> expectedIndent then failwith $"portable Rust backend block stack is unbalanced in {fn.name}"
            if usesTailLoop then
                indentLevel <- indentLevel - 1
                emit "}"
            output.AppendLine("}") |> ignore
            output.AppendLine() |> ignore
        output.AppendLine("fn main() {") |> ignore
        output.AppendLine("    std::process::exit(spiral_main());") |> ignore
        output.AppendLine("}") |> ignore
        let managedClosureSuffixes =
            tuples
            |> List.choose (fun tupleType ->
                if tupleType.name.StartsWith("ClosureValue", StringComparison.Ordinal) &&
                   (tupleType.fields |> List.exists (fun field -> managedType field.cType)) then
                    Some(tupleType.name.Substring("ClosureValue".Length))
                else None)
        let mutable rendered = output.ToString()
        for suffix in managedClosureSuffixes do
            rendered <- Regex.Replace(rendered, $"\\bClosureInvoke{suffix}\\((?<value>[A-Za-z_][A-Za-z0-9_]*)\\s*,", $"ClosureInvoke{suffix}(${{value}}.clone(),")
            rendered <- Regex.Replace(rendered, $"\\bClosureInvoke{suffix}\\((?<value>[A-Za-z_][A-Za-z0-9_]*)\\)", $"ClosureInvoke{suffix}(${{value}}.clone())")
            rendered <- Regex.Replace(rendered, $"(?m)^[ \\t]*ClosureValue(?:Clone|Drop){suffix}\\([^;]*\\);[ \\t]*\\r?\\n", "")
            rendered <- Regex.Replace(rendered, $"(?m)^[ \\t]*ClosureValue(?:Clone|Drop){suffix}\\([^;]*\\);[ \\t]*$", "")
        let tupleHelperBlock =
            Regex(@"(?ms)^#\[derive\([^\]]+\)\]\s*\r?\nstruct\s+(?<type>Tuple[0-9]+)\s*\{.*?^\}\s*\r?\n\s*fn\s+(?<ctor>TupleCreate[0-9]+)\([^)]*\)\s*->\s*\k<type>\s*\{.*?^\}\s*\r?\n?", RegexOptions.CultureInvariant)
        let mutable keepPruningTuples = true
        while keepPruningTuples do
            let mutable removedTuple = false
            let helperMatches = tupleHelperBlock.Matches rendered |> Seq.cast<Match> |> Seq.toArray
            for matched in helperMatches do
                if not removedTuple then
                    let outside = rendered.Remove(matched.Index, matched.Length)
                    let tupleType = matched.Groups.["type"].Value
                    let constructor = matched.Groups.["ctor"].Value
                    let typeUsed = Regex.IsMatch(outside, @"\b" + Regex.Escape tupleType + @"\b")
                    let constructorUsed = Regex.IsMatch(outside, @"\b" + Regex.Escape constructor + @"\b")
                    if not typeUsed && not constructorUsed then
                        rendered <- outside
                        removedTuple <- true
            keepPruningTuples <- removedTuple
        let localBinding =
            Regex(@"(?m)^(?<indent>[ \t]*)let (?<mutable>mut )?(?<name>v[0-9]+)(?<tail>:[^=\r\n]+=[^\r\n]+;)$", RegexOptions.CultureInvariant)
        let mutable keepPruningBindings = true
        while keepPruningBindings do
            keepPruningBindings <- false
            let bindingMatches = localBinding.Matches rendered |> Seq.cast<Match> |> Seq.toArray
            for matched in bindingMatches do
                if not keepPruningBindings then
                    let nameGroup = matched.Groups.["name"]
                    let name = nameGroup.Value
                    let uses = Regex.Matches(rendered, @"\b" + Regex.Escape name + @"\b").Count
                    if uses = 1 then
                        rendered <- rendered.Remove(nameGroup.Index, nameGroup.Length).Insert(nameGroup.Index, "_")
                        keepPruningBindings <- true
        rendered
    
    let private delphiFunctionNameV2 name = if name = "main" then "SpiralMain" else name
    
    let private delphiExpressionV2 expression =
        let normalized = delphiExpression expression
        Regex.Replace(normalized, "\\bmain\\s*\\(", "SpiralMain(")
    
    let private delphiFromPortableProgramC (closureShapes : PortableClosureShape list) (generated : string) =
        let usesStrings = generated.Contains("String *", StringComparison.Ordinal)
        let usesStringIndex = generated.Contains("PortableStringIndex(", StringComparison.Ordinal)
        let usesStringScalar = generated.Contains("PortableStringScalar(", StringComparison.Ordinal)
        let usesStringSlice = generated.Contains("PortableStringSlice(", StringComparison.Ordinal)
        let usesStringConcat = generated.Contains("PortableStringConcat(", StringComparison.Ordinal)
        let usesMonotonicDelay = generated.Contains("poll(0, 0,", StringComparison.Ordinal)
        let mathCalls = [ "sqrt("; "sqrtf("; "log("; "logf("; "exp("; "expf("; "tanh("; "tanhf("; "sin("; "sinf("; "cos("; "cosf("; "pow("; "powf("; "isnan(" ]
        let usesMath = generated.Contains("HUGE_VAL", StringComparison.Ordinal) || (mathCalls |> List.exists (fun call -> generated.Contains(call, StringComparison.Ordinal)))
        let recursiveUnions, layouts, arrays, tuples, parsedFunctions = parsePortableProgramC closureShapes generated
        let functions = lowerPortableTailSccs recursiveUnions parsedFunctions
        let tupleByName = tuples |> List.map (fun tupleType -> tupleType.name, tupleType) |> Map.ofList
        let rec typeNeedsManagedClone (visited : Set<string>) (cType : string) =
            if Regex.IsMatch(cType, "^(?:Array[0-9]+\\s*\\*|(?:Heap|Mut)[0-9]+\\s*\\*|String\\s*\\*|Recursive[0-9]+|OptionalRecursive[0-9]+|WeakRecursive[0-9]+)$") then true
            elif Set.contains cType visited then false
            else
                match Map.tryFind cType tupleByName with
                | Some tupleType -> tupleType.fields |> List.exists (fun field -> typeNeedsManagedClone (Set.add cType visited) field.cType)
                | None -> false
        let managedTupleNames =
            tuples
            |> List.filter (fun tupleType -> tupleType.fields |> List.exists (fun field -> typeNeedsManagedClone (Set.singleton tupleType.name) field.cType))
            |> List.map (fun tupleType -> tupleType.name)
            |> Set.ofList
        let rec tupleCanPrecedeArrays (visited : Set<string>) (tupleName : string) =
            if Set.contains tupleName visited then true
            else
                match Map.tryFind tupleName tupleByName with
                | None -> false
                | Some tupleType ->
                    tupleType.fields
                    |> List.forall (fun field ->
                        if Regex.IsMatch(field.cType, "^Array[0-9]+\\s*\\*$") then false
                        elif Regex.IsMatch(field.cType, "^Tuple[0-9]+$") then tupleCanPrecedeArrays (Set.add tupleName visited) field.cType
                        else true)
        let rec addTupleDependencies (visited : Set<string>) (tupleName : string) =
            if Set.contains tupleName visited then visited
            else
                match Map.tryFind tupleName tupleByName with
                | None -> visited
                | Some tupleType ->
                    tupleType.fields
                    |> List.fold (fun state field ->
                        if Regex.IsMatch(field.cType, "^Tuple[0-9]+$") then addTupleDependencies state field.cType
                        else state) (Set.add tupleName visited)
        let earlyTupleNames =
            [ yield!
                  arrays
                  |> List.choose (fun arrayType ->
                      if Regex.IsMatch(arrayType.elementType, "^Tuple[0-9]+$") then Some arrayType.elementType else None)
              yield!
                  recursiveUnions
                  |> List.collect (fun recursiveUnion ->
                      recursiveUnion.cases
                      |> List.collect (fun (_, parameters) ->
                          parameters
                          |> List.choose (fun parameter ->
                              if Regex.IsMatch(parameter.cType, "^Tuple[0-9]+$") then Some parameter.cType else None)))
              yield!
                  layouts
                  |> List.collect (fun layout ->
                      layout.fields
                      |> List.choose (fun field ->
                          if Regex.IsMatch(field.cType, "^Tuple[0-9]+$") then Some field.cType else None)) ]
            |> List.distinct
            |> List.filter (tupleCanPrecedeArrays Set.empty)
            |> List.fold addTupleDependencies Set.empty
        let rec tupleContainsNormalizedOptionalOwnership (visited : Set<string>) (tupleName : string) =
            if Set.contains tupleName visited then false
            else
                match Map.tryFind tupleName tupleByName with
                | None -> false
                | Some tupleType ->
                    tupleType.fields
                    |> List.exists (fun field ->
                        if Regex.IsMatch(field.cType, "^OptionalRecursive[0-9]+$") then true
                        elif Regex.IsMatch(field.cType, "^Tuple[0-9]+$") then
                            tupleContainsNormalizedOptionalOwnership (Set.add tupleName visited) field.cType
                        else false)
        let ownedManagedTupleNames =
            Set.union
                earlyTupleNames
                (tuples
                 |> List.choose (fun tupleType ->
                     if tupleContainsNormalizedOptionalOwnership Set.empty tupleType.name then Some tupleType.name else None)
                 |> Set.ofList)
            |> Set.filter (fun tupleName -> Set.contains tupleName managedTupleNames)
        let managedClosureTupleNames =
            tuples
            |> List.choose (fun tupleType ->
                if tupleType.name.StartsWith("ClosureValue", StringComparison.Ordinal) &&
                   (tupleType.fields |> List.exists (fun field -> Regex.IsMatch(field.cType, "^(?:Recursive|OptionalRecursive|WeakRecursive)[0-9]+$"))) then Some tupleType.name
                else None)
            |> Set.ofList
        let usesOptionalBorrow = generated.Contains("__spiral_optional_borrow_", StringComparison.Ordinal)
        let optionalRecursiveSuffixes =
            [ yield! arrays |> List.map (fun arrayType -> arrayType.elementType)
              yield! tuples |> List.collect (fun tupleType -> tupleType.fields |> List.map (fun field -> field.cType))
              yield! layouts |> List.collect (fun layout -> layout.fields |> List.map (fun field -> field.cType))
              yield!
                  recursiveUnions
                  |> List.collect (fun recursiveUnion ->
                      recursiveUnion.cases
                      |> List.collect (fun (_, parameters) -> parameters |> List.map (fun parameter -> parameter.cType)))
              yield!
                  functions
                  |> List.collect (fun fn ->
                      [ yield! fn.parameters |> List.map (fun parameter -> parameter.cType)
                        for statement in fn.statements do
                            match statement with
                            | PortableDeclareV3(cType, _) -> yield cType
                            | _ -> () ]) ]
            |> List.choose (fun cType ->
                let matched = Regex.Match(cType, "^OptionalRecursive(?<id>[0-9]+)$")
                if matched.Success then Some matched.Groups.["id"].Value else None)
            |> List.distinct
        let weakRecursiveSuffixes =
            [ yield! arrays |> List.map (fun arrayType -> arrayType.elementType)
              yield! tuples |> List.collect (fun tupleType -> tupleType.fields |> List.map (fun field -> field.cType))
              yield! layouts |> List.collect (fun layout -> layout.fields |> List.map (fun field -> field.cType))
              yield!
                  recursiveUnions
                  |> List.collect (fun recursiveUnion ->
                      recursiveUnion.cases
                      |> List.collect (fun (_, parameters) -> parameters |> List.map (fun parameter -> parameter.cType)))
              yield!
                  functions
                  |> List.collect (fun fn ->
                      [ yield! fn.parameters |> List.map (fun parameter -> parameter.cType)
                        for statement in fn.statements do
                            match statement with
                            | PortableDeclareV3(cType, _) -> yield cType
                            | _ -> () ]) ]
            |> List.choose (fun cType ->
                let matched = Regex.Match(cType, "^WeakRecursive(?<id>[0-9]+)$")
                if matched.Success then Some matched.Groups.["id"].Value else None)
            |> List.distinct
        let hasOptionalRecursiveAggregate =
            (arrays |> List.exists (fun arrayType -> Regex.IsMatch(arrayType.elementType, "^OptionalRecursive[0-9]+$"))) ||
            (tuples |> List.exists (fun tupleType -> tupleType.fields |> List.exists (fun field -> Regex.IsMatch(field.cType, "^OptionalRecursive[0-9]+$")))) ||
            (layouts |> List.exists (fun layout -> layout.fields |> List.exists (fun field -> Regex.IsMatch(field.cType, "^OptionalRecursive[0-9]+$")))) ||
            (recursiveUnions |> List.exists (fun recursiveUnion -> recursiveUnion.cases |> List.exists (fun (_, parameters) -> parameters |> List.exists (fun parameter -> Regex.IsMatch(parameter.cType, "^OptionalRecursive[0-9]+$")))))
        let arrayHelperUsed (arrayType : PortableArrayTypeV1) operation =
            let suffix = arrayType.name.Substring("Array".Length)
            let helperName = $"DynamicArray{operation}{suffix}"
            functions
            |> List.exists (fun fn -> fn.statements |> List.exists (portableStatementCallsV3 helperName))
        let arrayUsedByTailLoop (arrayType : PortableArrayTypeV1) =
            let cTypePattern = $"^{Regex.Escape(arrayType.name)}\\s*\\*$"
            functions
            |> List.exists (fun fn ->
                portableFunctionUsesTailLoop fn
                && fn.parameters |> List.exists (fun parameter -> Regex.IsMatch(parameter.cType, cTypePattern)))
        let arrayNeedsResizableStorage arrayType =
            arrayHelperUsed arrayType "Resize" || arrayHelperUsed arrayType "Reserve" || arrayHelperUsed arrayType "Capacity" || arrayHelperUsed arrayType "RefCount"
        let resizableArraySuffixByType =
            arrays
            |> List.choose (fun arrayType ->
                if arrayNeedsResizableStorage arrayType then
                    let suffix = arrayType.name.Substring("Array".Length)
                    Some(arrayType.name + " *", suffix)
                else None)
            |> Map.ofList
        let output = StringBuilder()
        output.AppendLine("program SpiralGenerated;") |> ignore
        output.AppendLine("{$mode objfpc}{$H+}") |> ignore
        output.AppendLine() |> ignore
        let delphiUnits =
            [ if usesStringIndex || usesStringScalar || usesStringSlice || usesMonotonicDelay || not arrays.IsEmpty || not recursiveUnions.IsEmpty then "SysUtils"
              if usesMath then "Math" ]
        if not delphiUnits.IsEmpty then
            let unitList = String.concat ", " delphiUnits
            output.AppendLine($"uses {unitList};") |> ignore
            output.AppendLine() |> ignore
        if not layouts.IsEmpty || not arrays.IsEmpty || not tuples.IsEmpty || not recursiveUnions.IsEmpty || not optionalRecursiveSuffixes.IsEmpty then
            output.AppendLine("type") |> ignore
            if hasOptionalRecursiveAggregate || not weakRecursiveSuffixes.IsEmpty then
                for recursiveUnion in recursiveUnions do
                    output.AppendLine($"  {recursiveUnion.name} = class;") |> ignore
                for suffix in weakRecursiveSuffixes do
                    output.AppendLine($"  RecursiveWeakControl{suffix} = class") |> ignore
                    output.AppendLine("    RefCount: LongInt;") |> ignore
                    output.AppendLine($"    Target: Recursive{suffix};") |> ignore
                    output.AppendLine("  end;") |> ignore
                    output.AppendLine($"  WeakRecursive{suffix} = record") |> ignore
                    output.AppendLine($"    Control: RecursiveWeakControl{suffix};") |> ignore
                    output.AppendLine("  end;") |> ignore
                for suffix in optionalRecursiveSuffixes do
                    output.AppendLine($"  OptionalRecursive{suffix} = record") |> ignore
                    output.AppendLine("    HasValue: Boolean;") |> ignore
                    output.AppendLine($"    Value: Recursive{suffix};") |> ignore
                    output.AppendLine("  end;") |> ignore
                for tupleType in tuples do
                    if Set.contains tupleType.name earlyTupleNames then
                        output.AppendLine($"  {tupleType.name} = record") |> ignore
                        for field in tupleType.fields do
                            output.AppendLine($"    {field.name}: {delphiType field.cType};") |> ignore
                        output.AppendLine("  end;") |> ignore
                for arrayType in arrays do
                    let elementType = delphiType arrayType.elementType
                    if arrayNeedsResizableStorage arrayType then
                        output.AppendLine($"  {arrayType.name}Data = array of {elementType};") |> ignore
                        output.AppendLine($"  {arrayType.name} = class") |> ignore
                        output.AppendLine("    RefCount: LongInt;") |> ignore
                        output.AppendLine("    Length: LongInt;") |> ignore
                        output.AppendLine("    Capacity: LongInt;") |> ignore
                        output.AppendLine($"    Data: {arrayType.name}Data;") |> ignore
                        output.AppendLine("  end;") |> ignore
                    else
                        output.AppendLine($"  {arrayType.name} = array of {elementType};") |> ignore
                for recursiveUnion in recursiveUnions do
                    let recursiveSuffix = recursiveUnion.name.Substring("Recursive".Length)
                    output.AppendLine($"  {recursiveUnion.name} = class") |> ignore
                    output.AppendLine("    RefCount: LongInt;") |> ignore
                    output.AppendLine("    Tag: LongInt;") |> ignore
                    if List.contains recursiveSuffix weakRecursiveSuffixes then output.AppendLine($"    WeakControl: RecursiveWeakControl{recursiveSuffix};") |> ignore
                    for tag, parameters in recursiveUnion.cases do
                        for parameter in parameters do
                            let storageField = recursiveUnionStorageField recursiveUnion tag parameter.name
                            output.AppendLine($"    {storageField}: {delphiType parameter.cType};") |> ignore
                    output.AppendLine("  end;") |> ignore
            else
                if recursiveUnions.Length > 1 then
                    for recursiveUnion in recursiveUnions do
                        output.AppendLine($"  {recursiveUnion.name} = class;") |> ignore
                for tupleType in tuples do
                    if Set.contains tupleType.name earlyTupleNames then
                        output.AppendLine($"  {tupleType.name} = record") |> ignore
                        for field in tupleType.fields do
                            output.AppendLine($"    {field.name}: {delphiType field.cType};") |> ignore
                        output.AppendLine("  end;") |> ignore
                for arrayType in arrays do
                    let elementType = delphiType arrayType.elementType
                    if arrayNeedsResizableStorage arrayType then
                        output.AppendLine($"  {arrayType.name}Data = array of {elementType};") |> ignore
                        output.AppendLine($"  {arrayType.name} = class") |> ignore
                        output.AppendLine("    RefCount: LongInt;") |> ignore
                        output.AppendLine("    Length: LongInt;") |> ignore
                        output.AppendLine("    Capacity: LongInt;") |> ignore
                        output.AppendLine($"    Data: {arrayType.name}Data;") |> ignore
                        output.AppendLine("  end;") |> ignore
                    else
                        output.AppendLine($"  {arrayType.name} = array of {elementType};") |> ignore
                for recursiveUnion in recursiveUnions do
                    let recursiveSuffix = recursiveUnion.name.Substring("Recursive".Length)
                    output.AppendLine($"  {recursiveUnion.name} = class") |> ignore
                    output.AppendLine("    RefCount: LongInt;") |> ignore
                    output.AppendLine("    Tag: LongInt;") |> ignore
                    if List.contains recursiveSuffix weakRecursiveSuffixes then output.AppendLine($"    WeakControl: RecursiveWeakControl{recursiveSuffix};") |> ignore
                    for tag, parameters in recursiveUnion.cases do
                        for parameter in parameters do
                            let storageField = recursiveUnionStorageField recursiveUnion tag parameter.name
                            output.AppendLine($"    {storageField}: {delphiType parameter.cType};") |> ignore
                    output.AppendLine("  end;") |> ignore
                for suffix in optionalRecursiveSuffixes do
                    output.AppendLine($"  OptionalRecursive{suffix} = record") |> ignore
                    output.AppendLine("    HasValue: Boolean;") |> ignore
                    output.AppendLine($"    Value: Recursive{suffix};") |> ignore
                    output.AppendLine("  end;") |> ignore
            for tupleType in tuples do
                if not (Set.contains tupleType.name earlyTupleNames) then
                    output.AppendLine($"  {tupleType.name} = record") |> ignore
                    for field in tupleType.fields do
                        output.AppendLine($"    {field.name}: {delphiType field.cType};") |> ignore
                    output.AppendLine("  end;") |> ignore
            for layout in layouts do
                output.AppendLine($"  {layout.name} = class") |> ignore
                output.AppendLine("    RefCount: LongInt;") |> ignore
                for field in layout.fields do
                    output.AppendLine($"    {field.name}: {delphiType field.cType};") |> ignore
                output.AppendLine("  end;") |> ignore
            output.AppendLine() |> ignore
        for tupleType in tuples do
            if Set.contains tupleType.name ownedManagedTupleNames then
                let suffix = tupleType.name.Substring("Tuple".Length)
                output.AppendLine($"procedure TupleClone{suffix}(var value: {tupleType.name}); forward;") |> ignore
                output.AppendLine($"procedure TupleDrop{suffix}(var value: {tupleType.name}); forward;") |> ignore
            elif Set.contains tupleType.name managedClosureTupleNames then
                let suffix = tupleType.name.Substring("ClosureValue".Length)
                output.AppendLine($"procedure ClosureValueClone{suffix}(var value: {tupleType.name}); forward;") |> ignore
                output.AppendLine($"procedure ClosureValueDrop{suffix}(var value: {tupleType.name}); forward;") |> ignore
        if not ownedManagedTupleNames.IsEmpty || not managedClosureTupleNames.IsEmpty then output.AppendLine() |> ignore
        if usesStringIndex then
            output.AppendLine("function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');") |> ignore
            output.AppendLine("  Result := Ord(value[index + 1]);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        if usesStringScalar then
            output.AppendLine("function SpiralStringScalar(const value: AnsiString; byteOffset: LongInt): LongInt;") |> ignore
            output.AppendLine("var") |> ignore
            output.AppendLine("  firstByte, currentByte, width, index, scalar, minimum: LongInt;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if (byteOffset < 0) or (byteOffset >= Length(value)) then raise ERangeError.Create('Spiral UTF-8 scalar offset out of bounds');") |> ignore
            output.AppendLine("  firstByte := Ord(value[byteOffset + 1]);") |> ignore
            output.AppendLine("  if firstByte < $80 then begin width := 1; scalar := firstByte; minimum := 0 end") |> ignore
            output.AppendLine("  else if (firstByte >= $C2) and (firstByte <= $DF) then begin width := 2; scalar := firstByte and $1F; minimum := $80 end") |> ignore
            output.AppendLine("  else if (firstByte >= $E0) and (firstByte <= $EF) then begin width := 3; scalar := firstByte and $0F; minimum := $800 end") |> ignore
            output.AppendLine("  else if (firstByte >= $F0) and (firstByte <= $F4) then begin width := 4; scalar := firstByte and $07; minimum := $10000 end") |> ignore
            output.AppendLine("  else raise EConvertError.Create('invalid Spiral UTF-8 lead byte');") |> ignore
            output.AppendLine("  if byteOffset + width > Length(value) then raise EConvertError.Create('truncated Spiral UTF-8 scalar');") |> ignore
            output.AppendLine("  for index := 1 to width - 1 do begin") |> ignore
            output.AppendLine("    currentByte := Ord(value[byteOffset + index + 1]);") |> ignore
            output.AppendLine("    if (currentByte and $C0) <> $80 then raise EConvertError.Create('invalid Spiral UTF-8 continuation byte');") |> ignore
            output.AppendLine("    scalar := scalar * 64 + (currentByte and $3F);") |> ignore
            output.AppendLine("  end;") |> ignore
            output.AppendLine("  if scalar < minimum then raise EConvertError.Create('overlong Spiral UTF-8 scalar');") |> ignore
            output.AppendLine("  if (scalar >= $D800) and (scalar <= $DFFF) then raise EConvertError.Create('surrogate Spiral UTF-8 scalar');") |> ignore
            output.AppendLine("  if scalar > $10FFFF then raise EConvertError.Create('Spiral UTF-8 scalar exceeds Unicode range');") |> ignore
            output.AppendLine("  Result := scalar;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        if usesStringSlice then
            output.AppendLine("function SpiralStringSlice(const value: AnsiString; fromIndex, toIndex: LongInt): AnsiString;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if (fromIndex < 0) or (fromIndex > Length(value)) or (toIndex < fromIndex - 1) or (toIndex >= Length(value)) then raise ERangeError.Create('Spiral string slice out of bounds');") |> ignore
            output.AppendLine("  if (toIndex >= fromIndex) and ((((Ord(value[fromIndex + 1])) and $C0) = $80) or ((toIndex + 1 < Length(value)) and (((Ord(value[toIndex + 2])) and $C0) = $80))) then raise ERangeError.Create('Spiral string slice must preserve UTF-8 codepoint boundaries');") |> ignore
            output.AppendLine("  if toIndex < fromIndex then Result := ''") |> ignore
            output.AppendLine("  else Result := Copy(value, fromIndex + 1, toIndex - fromIndex + 1);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        if usesStringConcat then
            output.AppendLine("function SpiralStringConcat(const left, right: AnsiString): AnsiString;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  Result := left + right;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        let layoutRecursiveSuffixes =
            layouts
            |> List.collect (fun layout -> layout.fields |> List.map (fun field -> field.cType))
            |> List.choose (fun cType ->
                let matched = Regex.Match(cType, "^Recursive(?<id>[0-9]+)$")
                if matched.Success then Some matched.Groups.["id"].Value else None)
            |> Set.ofList
        let recursiveDropForwardSuffixes =
            Set.union
                layoutRecursiveSuffixes
                (if recursiveUnions.Length > 1 then recursiveUnions |> List.map (fun recursiveUnion -> recursiveUnion.name.Substring("Recursive".Length)) |> Set.ofList else Set.empty)
        for recursiveUnion in recursiveUnions do
            let suffix = recursiveUnion.name.Substring("Recursive".Length)
            if Set.contains suffix layoutRecursiveSuffixes then output.AppendLine($"procedure RecursiveClone{suffix}(value: {recursiveUnion.name}); forward;") |> ignore
            if Set.contains suffix recursiveDropForwardSuffixes then output.AppendLine($"procedure RecursiveDrop{suffix}(var value: {recursiveUnion.name}); forward;") |> ignore
        let optionalUnionSuffixes =
            recursiveUnions
            |> List.collect (fun recursiveUnion -> recursiveUnion.cases |> List.collect (fun (_, parameters) -> parameters |> List.map (fun parameter -> parameter.cType)))
            |> List.choose (fun cType ->
                let matched = Regex.Match(cType, "^OptionalRecursive(?<id>[0-9]+)$")
                if matched.Success then Some matched.Groups.["id"].Value else None)
            |> Set.ofList
        let layoutOptionalSuffixes =
            layouts
            |> List.collect (fun layout -> layout.fields |> List.map (fun field -> field.cType))
            |> List.choose (fun cType ->
                let matched = Regex.Match(cType, "^OptionalRecursive(?<id>[0-9]+)$")
                if matched.Success then Some matched.Groups.["id"].Value else None)
            |> Set.ofList
        let optionalForwardSuffixes = Set.union optionalUnionSuffixes layoutOptionalSuffixes
        if not recursiveDropForwardSuffixes.IsEmpty && not optionalForwardSuffixes.IsEmpty then output.AppendLine() |> ignore
        for optionalSuffix in optionalForwardSuffixes do
            output.AppendLine($"procedure OptionalRecursiveClone{optionalSuffix}(var value: OptionalRecursive{optionalSuffix}); forward;") |> ignore
            output.AppendLine($"procedure OptionalRecursiveDrop{optionalSuffix}(var value: OptionalRecursive{optionalSuffix}); forward;") |> ignore
        for weakSuffix in weakRecursiveSuffixes do
            output.AppendLine($"procedure WeakRecursiveClone{weakSuffix}(var value: WeakRecursive{weakSuffix}); forward;") |> ignore
            output.AppendLine($"procedure WeakRecursiveDrop{weakSuffix}(var value: WeakRecursive{weakSuffix}); forward;") |> ignore
        if not recursiveDropForwardSuffixes.IsEmpty || not optionalForwardSuffixes.IsEmpty || not weakRecursiveSuffixes.IsEmpty then output.AppendLine() |> ignore
        let nestedLayoutField (cType : string) = Regex.Match(cType, "^(?<kind>Heap|Mut)(?<id>[0-9]+)\\s*\\*$")
        let arrayLayoutField (cType : string) = Regex.Match(cType, "^Array(?<id>[0-9]+)\\s*\\*$")
        let resizableLayoutArray (cType : string) =
            let matched = arrayLayoutField cType
            if matched.Success then
                arrays
                |> List.tryFind (fun arrayType -> arrayType.name = "Array" + matched.Groups.["id"].Value && arrayNeedsResizableStorage arrayType)
            else None
        let layoutNeedsExplicitManagedAction (field : PortableParameterV2) =
            (nestedLayoutField field.cType).Success ||
            (resizableLayoutArray field.cType).IsSome ||
            Regex.IsMatch(field.cType, "^(?:Recursive|OptionalRecursive|WeakRecursive)[0-9]+$") ||
            Set.contains field.cType ownedManagedTupleNames
        let hasExplicitManagedLayouts = layouts |> List.exists (fun layout -> layout.fields |> List.exists layoutNeedsExplicitManagedAction)
        if hasExplicitManagedLayouts then
            for arrayType in arrays do
                if arrayNeedsResizableStorage arrayType then
                    let arraySuffix = arrayType.name.Substring("Array".Length)
                    output.AppendLine($"procedure DynamicArrayDrop{arraySuffix}(var data: {arrayType.name}); forward;") |> ignore
            for layout in layouts do
                let prefix = if layout.name.StartsWith("Mut", StringComparison.Ordinal) then "Mut" else "Heap"
                let suffix = layout.name.Substring(prefix.Length)
                output.AppendLine($"procedure {prefix}Decref{suffix}(var value: {layout.name}); forward;") |> ignore
            output.AppendLine() |> ignore
        let emitLayoutManagedAction action target cType =
            let nested = nestedLayoutField cType
            let recursiveMatch = Regex.Match(cType, "^Recursive(?<id>[0-9]+)$")
            let optionalMatch = Regex.Match(cType, "^OptionalRecursive(?<id>[0-9]+)$")
            let weakMatch = Regex.Match(cType, "^WeakRecursive(?<id>[0-9]+)$")
            let tupleMatch = Regex.Match(cType, "^Tuple(?<id>[0-9]+)$")
            if nested.Success then
                let childPrefix = nested.Groups.["kind"].Value
                let childSuffix = nested.Groups.["id"].Value
                if action = "Clone" then output.AppendLine($"  if {target} <> nil then Inc({target}.RefCount);") |> ignore
                else output.AppendLine($"  {childPrefix}Decref{childSuffix}({target});") |> ignore
            elif recursiveMatch.Success then
                let childSuffix = recursiveMatch.Groups.["id"].Value
                output.AppendLine($"  Recursive{action}{childSuffix}({target});") |> ignore
            elif optionalMatch.Success then
                let childSuffix = optionalMatch.Groups.["id"].Value
                output.AppendLine($"  OptionalRecursive{action}{childSuffix}({target});") |> ignore
            elif weakMatch.Success then
                let childSuffix = weakMatch.Groups.["id"].Value
                output.AppendLine($"  WeakRecursive{action}{childSuffix}({target});") |> ignore
            elif tupleMatch.Success && Set.contains cType ownedManagedTupleNames then
                let childSuffix = tupleMatch.Groups.["id"].Value
                output.AppendLine($"  Tuple{action}{childSuffix}({target});") |> ignore
            else
                match resizableLayoutArray cType with
                | Some arrayType ->
                    let arraySuffix = arrayType.name.Substring("Array".Length)
                    if action = "Clone" then output.AppendLine($"  if {target} <> nil then Inc({target}.RefCount);") |> ignore
                    else output.AppendLine($"  DynamicArrayDrop{arraySuffix}({target});") |> ignore
                | None -> ()
        for layout in layouts do
            let prefix = if layout.name.StartsWith("Mut", StringComparison.Ordinal) then "Mut" else "Heap"
            let suffix = layout.name.Substring(prefix.Length)
            let isMutable = prefix = "Mut"
            let parameters = layout.fields |> List.map (fun field -> $"{field.name}: {delphiType field.cType}") |> String.concat "; "
            output.AppendLine($"function {prefix}Create{suffix}({parameters}): {layout.name};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine($"  Result := {layout.name}.Create;") |> ignore
            output.AppendLine("  Result.RefCount := 1;") |> ignore
            for field in layout.fields do
                output.AppendLine($"  Result.{field.name} := {field.name};") |> ignore
            output.AppendLine("end;") |> ignore
            if isMutable then
                output.AppendLine($"procedure MutAssign{suffix}(value: {layout.name}; {parameters});") |> ignore
                output.AppendLine("begin") |> ignore
                for field in layout.fields do emitLayoutManagedAction "Clone" field.name field.cType
                for field in layout.fields do
                    emitLayoutManagedAction "Drop" $"value.{field.name}" field.cType
                    output.AppendLine($"  value.{field.name} := {field.name};") |> ignore
                output.AppendLine("end;") |> ignore
            for index, field in layout.fields |> List.indexed do
                output.AppendLine($"function {prefix}Get{suffix}_{index}(value: {layout.name}): {delphiType field.cType};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine($"  Result := value.{field.name};") |> ignore
                emitLayoutManagedAction "Clone" "Result" field.cType
                output.AppendLine("end;") |> ignore
            output.AppendLine($"procedure {prefix}Decref{suffix}(var value: {layout.name});") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if value = nil then Exit;") |> ignore
            output.AppendLine("  Dec(value.RefCount);") |> ignore
            let hasExplicitManagedFields = layout.fields |> List.exists layoutNeedsExplicitManagedAction
            if hasExplicitManagedFields then
                output.AppendLine("  if value.RefCount = 0 then") |> ignore
                output.AppendLine("  begin") |> ignore
                for field in layout.fields |> List.rev do emitLayoutManagedAction "Drop" $"value.{field.name}" field.cType
                output.AppendLine("    value.Free;") |> ignore
                output.AppendLine("  end;") |> ignore
            else output.AppendLine("  if value.RefCount = 0 then value.Free;") |> ignore
            output.AppendLine("  value := nil;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        for recursiveUnion in recursiveUnions do
            let suffix = recursiveUnion.name.Substring("Recursive".Length)
            let legacyFieldHelpers = recursiveUnionUsesLegacyFields recursiveUnion
            let childName childIndex = if recursiveUnion.recursiveFields.Length = 1 then "child" else $"child{childIndex}"
            let weakFields =
                recursiveUnion.cases
                |> List.collect (fun (tag, parameters) ->
                    parameters
                    |> List.choose (fun parameter ->
                        let matched = Regex.Match(parameter.cType, "^WeakRecursive(?<id>[0-9]+)$")
                        if matched.Success then Some(tag, parameter.name, matched.Groups.["id"].Value) else None))
            let optionalFields =
                recursiveUnion.cases
                |> List.collect (fun (tag, parameters) ->
                    parameters
                    |> List.choose (fun parameter ->
                        let matched = Regex.Match(parameter.cType, "^OptionalRecursive(?<id>[0-9]+)$")
                        if matched.Success then Some(tag, parameter.name, matched.Groups.["id"].Value) else None))
            let managedTupleFields =
                recursiveUnion.cases
                |> List.collect (fun (tag, parameters) ->
                    parameters
                    |> List.choose (fun parameter ->
                        if Set.contains parameter.cType ownedManagedTupleNames then
                            Some(tag, parameter.name, parameter.cType.Substring("Tuple".Length))
                        else None))
            for tag, parameters in recursiveUnion.cases do
                let parameterText = parameters |> List.map (fun parameter -> $"{parameter.name}: {delphiType parameter.cType}") |> String.concat "; "
                if String.IsNullOrWhiteSpace parameterText then output.AppendLine($"function RecursiveCreate{suffix}_{tag}: {recursiveUnion.name};") |> ignore
                else output.AppendLine($"function RecursiveCreate{suffix}_{tag}({parameterText}): {recursiveUnion.name};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine($"  Result := {recursiveUnion.name}.Create;") |> ignore
                output.AppendLine("  Result.RefCount := 1;") |> ignore
                if List.contains suffix weakRecursiveSuffixes then
                    output.AppendLine($"  Result.WeakControl := RecursiveWeakControl{suffix}.Create;") |> ignore
                    output.AppendLine("  Result.WeakControl.RefCount := 1;") |> ignore
                    output.AppendLine("  Result.WeakControl.Target := Result;") |> ignore
                output.AppendLine($"  Result.Tag := {tag};") |> ignore
                for parameter in parameters do
                    let storageField = recursiveUnionStorageField recursiveUnion tag parameter.name
                    output.AppendLine($"  Result.{storageField} := {parameter.name};") |> ignore
                    let weakMatch = Regex.Match(parameter.cType, "^WeakRecursive(?<id>[0-9]+)$")
                    let optionalMatch = Regex.Match(parameter.cType, "^OptionalRecursive(?<id>[0-9]+)$")
                    let tupleMatch = Regex.Match(parameter.cType, "^Tuple(?<id>[0-9]+)$")
                    if weakMatch.Success then
                        let weakSuffix = weakMatch.Groups.["id"].Value
                        output.AppendLine($"  WeakRecursiveClone{weakSuffix}(Result.{storageField});") |> ignore
                    elif optionalMatch.Success then
                        let optionalSuffix = optionalMatch.Groups.["id"].Value
                        output.AppendLine($"  OptionalRecursiveClone{optionalSuffix}(Result.{storageField});") |> ignore
                    elif tupleMatch.Success && Set.contains parameter.cType ownedManagedTupleNames then
                        let tupleSuffix = tupleMatch.Groups.["id"].Value
                        output.AppendLine($"  TupleClone{tupleSuffix}(Result.{storageField});") |> ignore
                output.AppendLine("end;") |> ignore
                let selfWeakFields = parameters |> List.filter (fun parameter -> parameter.cType = "Weak" + recursiveUnion.name)
                if selfWeakFields.Length = 1 then
                    let weakField = selfWeakFields.Head
                    let nonWeakParameters = parameters |> List.filter (fun parameter -> parameter.name <> weakField.name)
                    let selfParameterText = nonWeakParameters |> List.map (fun parameter -> $"{parameter.name}: {delphiType parameter.cType}") |> String.concat "; "
                    if String.IsNullOrWhiteSpace selfParameterText then output.AppendLine($"function RecursiveCreateWeakSelf{suffix}_{tag}: {recursiveUnion.name};") |> ignore
                    else output.AppendLine($"function RecursiveCreateWeakSelf{suffix}_{tag}({selfParameterText}): {recursiveUnion.name};") |> ignore
                    output.AppendLine("begin") |> ignore
                    output.AppendLine($"  Result := {recursiveUnion.name}.Create;") |> ignore
                    output.AppendLine("  Result.RefCount := 1;") |> ignore
                    output.AppendLine($"  Result.WeakControl := RecursiveWeakControl{suffix}.Create;") |> ignore
                    output.AppendLine("  Result.WeakControl.RefCount := 2;") |> ignore
                    output.AppendLine("  Result.WeakControl.Target := Result;") |> ignore
                    output.AppendLine($"  Result.Tag := {tag};") |> ignore
                    for parameter in parameters do
                        let storageField = recursiveUnionStorageField recursiveUnion tag parameter.name
                        if parameter.name = weakField.name then
                            output.AppendLine($"  Result.{storageField}.Control := Result.WeakControl;") |> ignore
                        else
                            output.AppendLine($"  Result.{storageField} := {parameter.name};") |> ignore
                            let optionalMatch = Regex.Match(parameter.cType, "^OptionalRecursive(?<id>[0-9]+)$")
                            let tupleMatch = Regex.Match(parameter.cType, "^Tuple(?<id>[0-9]+)$")
                            if optionalMatch.Success then
                                let optionalSuffix = optionalMatch.Groups.["id"].Value
                                output.AppendLine($"  OptionalRecursiveClone{optionalSuffix}(Result.{storageField});") |> ignore
                            elif tupleMatch.Success && Set.contains parameter.cType ownedManagedTupleNames then
                                let tupleSuffix = tupleMatch.Groups.["id"].Value
                                output.AppendLine($"  TupleClone{tupleSuffix}(Result.{storageField});") |> ignore
                    output.AppendLine("end;") |> ignore
            output.AppendLine($"function RecursiveTag{suffix}(value: {recursiveUnion.name}): LongInt;") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  Result := value.Tag;") |> ignore
            output.AppendLine("end;") |> ignore
            let emitFieldHelper (helperName : string) tag fieldIndex (parameter : PortableParameterV2) =
                let storageField = recursiveUnionStorageField recursiveUnion tag parameter.name
                output.AppendLine($"function {helperName}(value: {recursiveUnion.name}): {delphiType parameter.cType};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine($"  if value.Tag <> {tag} then raise EVariantError.Create('recursive union field requested from wrong case');") |> ignore
                output.AppendLine($"  Result := value.{storageField};") |> ignore
                let weakMatch = Regex.Match(parameter.cType, "^WeakRecursive(?<id>[0-9]+)$")
                let optionalMatch = Regex.Match(parameter.cType, "^OptionalRecursive(?<id>[0-9]+)$")
                let tupleMatch = Regex.Match(parameter.cType, "^Tuple(?<id>[0-9]+)$")
                if weakMatch.Success then
                    let weakSuffix = weakMatch.Groups.["id"].Value
                    output.AppendLine($"  WeakRecursiveClone{weakSuffix}(Result);") |> ignore
                elif optionalMatch.Success then
                    let optionalSuffix = optionalMatch.Groups.["id"].Value
                    output.AppendLine($"  OptionalRecursiveClone{optionalSuffix}(Result);") |> ignore
                elif tupleMatch.Success && Set.contains parameter.cType ownedManagedTupleNames then
                    let tupleSuffix = tupleMatch.Groups.["id"].Value
                    output.AppendLine($"  TupleClone{tupleSuffix}(Result);") |> ignore
                output.AppendLine("end;") |> ignore
            if legacyFieldHelpers then
                let tag = recursiveUnion.recursiveCases.Head
                let _, parameters = recursiveUnion.cases |> List.find (fun (caseTag, _) -> caseTag = tag)
                for fieldIndex, parameter in parameters |> List.indexed do
                    emitFieldHelper $"RecursiveField{suffix}_{fieldIndex}" tag fieldIndex parameter
            else
                for tag, parameters in recursiveUnion.cases do
                    for fieldIndex, parameter in parameters |> List.indexed do
                        emitFieldHelper $"RecursiveCaseField{suffix}_{tag}_{fieldIndex}" tag fieldIndex parameter
            output.AppendLine($"procedure RecursiveClone{suffix}(value: {recursiveUnion.name});") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if value <> nil then Inc(value.RefCount);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"procedure RecursiveDrop{suffix}(var value: {recursiveUnion.name});") |> ignore
            output.AppendLine("var") |> ignore
            for childIndex, (_, _, childType) in recursiveUnion.recursiveFields |> List.indexed do
                output.AppendLine($"  {childName childIndex}: {delphiType childType};") |> ignore
            if List.contains suffix weakRecursiveSuffixes then output.AppendLine($"  weakControl: RecursiveWeakControl{suffix};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if value = nil then Exit;") |> ignore
            output.AppendLine("  Dec(value.RefCount);") |> ignore
            output.AppendLine("  if value.RefCount = 0 then") |> ignore
            output.AppendLine("  begin") |> ignore
            for childIndex, (tag, fieldName, _) in recursiveUnion.recursiveFields |> List.indexed do
                let storageField = recursiveUnionStorageField recursiveUnion tag fieldName
                output.AppendLine($"    {childName childIndex} := nil;") |> ignore
                output.AppendLine($"    if value.Tag = {tag} then {childName childIndex} := value.{storageField};") |> ignore
            for tag, fieldName, weakSuffix in weakFields do
                let storageField = recursiveUnionStorageField recursiveUnion tag fieldName
                output.AppendLine($"    if value.Tag = {tag} then WeakRecursiveDrop{weakSuffix}(value.{storageField});") |> ignore
            for tag, fieldName, optionalSuffix in optionalFields do
                let storageField = recursiveUnionStorageField recursiveUnion tag fieldName
                output.AppendLine($"    if value.Tag = {tag} then OptionalRecursiveDrop{optionalSuffix}(value.{storageField});") |> ignore
            for tag, fieldName, tupleSuffix in managedTupleFields do
                let storageField = recursiveUnionStorageField recursiveUnion tag fieldName
                output.AppendLine($"    if value.Tag = {tag} then TupleDrop{tupleSuffix}(value.{storageField});") |> ignore
            if List.contains suffix weakRecursiveSuffixes then
                output.AppendLine("    weakControl := value.WeakControl;") |> ignore
                output.AppendLine("    if weakControl <> nil then") |> ignore
                output.AppendLine("    begin") |> ignore
                output.AppendLine("      weakControl.Target := nil;") |> ignore
                output.AppendLine("      Dec(weakControl.RefCount);") |> ignore
                output.AppendLine("      value.WeakControl := nil;") |> ignore
                output.AppendLine("      if weakControl.RefCount = 0 then weakControl.Free;") |> ignore
                output.AppendLine("    end;") |> ignore
            output.AppendLine("    value.Free;") |> ignore
            output.AppendLine("    value := nil;") |> ignore
            for childIndex, (_, _, childType) in recursiveUnion.recursiveFields |> List.indexed do
                let childSuffix = childType.Substring("Recursive".Length)
                output.AppendLine($"    if {childName childIndex} <> nil then RecursiveDrop{childSuffix}({childName childIndex});") |> ignore
            output.AppendLine("  end") |> ignore
            output.AppendLine("  else value := nil;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        for suffix in weakRecursiveSuffixes do
            output.AppendLine($"function WeakRecursiveDowngrade{suffix}(value: Recursive{suffix}): WeakRecursive{suffix};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  Result.Control := nil;") |> ignore
            output.AppendLine("  if (value <> nil) and (value.WeakControl <> nil) then") |> ignore
            output.AppendLine("  begin") |> ignore
            output.AppendLine("    Result.Control := value.WeakControl;") |> ignore
            output.AppendLine("    Inc(Result.Control.RefCount);") |> ignore
            output.AppendLine("  end;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"function WeakRecursiveUpgrade{suffix}(const value: WeakRecursive{suffix}): OptionalRecursive{suffix};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  Result.HasValue := (value.Control <> nil) and (value.Control.Target <> nil);") |> ignore
            output.AppendLine("  if Result.HasValue then") |> ignore
            output.AppendLine("  begin") |> ignore
            output.AppendLine("    Result.Value := value.Control.Target;") |> ignore
            output.AppendLine($"    RecursiveClone{suffix}(Result.Value);") |> ignore
            output.AppendLine("  end") |> ignore
            output.AppendLine("  else Result.Value := nil;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"procedure WeakRecursiveClone{suffix}(var value: WeakRecursive{suffix});") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if value.Control <> nil then Inc(value.Control.RefCount);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"procedure WeakRecursiveDrop{suffix}(var value: WeakRecursive{suffix});") |> ignore
            output.AppendLine("var control: RecursiveWeakControl" + suffix + ";") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  control := value.Control;") |> ignore
            output.AppendLine("  value.Control := nil;") |> ignore
            output.AppendLine("  if control <> nil then") |> ignore
            output.AppendLine("  begin") |> ignore
            output.AppendLine("    Dec(control.RefCount);") |> ignore
            output.AppendLine("    if control.RefCount = 0 then control.Free;") |> ignore
            output.AppendLine("  end;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        for suffix in optionalRecursiveSuffixes do
            output.AppendLine($"function OptionalRecursiveNone{suffix}: OptionalRecursive{suffix};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  Result.HasValue := False;") |> ignore
            output.AppendLine("  Result.Value := nil;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"function OptionalRecursiveSome{suffix}(value: Recursive{suffix}): OptionalRecursive{suffix};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  Result.HasValue := True;") |> ignore
            output.AppendLine("  Result.Value := value;") |> ignore
            output.AppendLine($"  RecursiveClone{suffix}(Result.Value);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"function OptionalRecursiveTake{suffix}(var value: OptionalRecursive{suffix}): Recursive{suffix};") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine("  if not value.HasValue then raise EInvalidOpException.Create('Spiral optional recursive slot is absent');") |> ignore
            output.AppendLine("  Result := value.Value;") |> ignore
            output.AppendLine("  value.HasValue := False;") |> ignore
            output.AppendLine("  value.Value := nil;") |> ignore
            output.AppendLine("end;") |> ignore
            if usesOptionalBorrow then
                output.AppendLine($"function OptionalRecursiveBorrow{suffix}(const value: OptionalRecursive{suffix}): Recursive{suffix};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if not value.HasValue then raise EInvalidOpException.Create('Spiral optional recursive slot is absent');") |> ignore
                output.AppendLine("  Result := value.Value;") |> ignore
                output.AppendLine("end;") |> ignore
            output.AppendLine($"procedure OptionalRecursiveClone{suffix}(var value: OptionalRecursive{suffix});") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine($"  if value.HasValue then RecursiveClone{suffix}(value.Value);") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine($"procedure OptionalRecursiveDrop{suffix}(var value: OptionalRecursive{suffix});") |> ignore
            output.AppendLine("begin") |> ignore
            output.AppendLine($"  if value.HasValue then RecursiveDrop{suffix}(value.Value);") |> ignore
            output.AppendLine("  value.HasValue := False;") |> ignore
            output.AppendLine("  value.Value := nil;") |> ignore
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        for arrayType in arrays do
            let elementType = delphiType arrayType.elementType
            let suffix = arrayType.name.Substring("Array".Length)
            let elementArrayMatch = Regex.Match(arrayType.elementType, "^Array(?<id>[0-9]+)(?:\\s*\\*)?$")
            let elementRecursiveMatch = Regex.Match(arrayType.elementType, "^Recursive(?<id>[0-9]+)$")
            let elementOptionalRecursiveMatch = Regex.Match(arrayType.elementType, "^OptionalRecursive(?<id>[0-9]+)$")
            let elementTupleMatch = Regex.Match(arrayType.elementType, "^Tuple(?<id>[0-9]+)$")
            let nestedManagedTupleSuffix =
                if elementTupleMatch.Success && Set.contains arrayType.elementType ownedManagedTupleNames then Some elementTupleMatch.Groups.["id"].Value else None
            let nestedRecursiveSuffix =
                if elementRecursiveMatch.Success then Some elementRecursiveMatch.Groups.["id"].Value else None
            let nestedOptionalRecursiveSuffix =
                if elementOptionalRecursiveMatch.Success then Some elementOptionalRecursiveMatch.Groups.["id"].Value else None
            let nestedResizableArraySuffix =
                if elementArrayMatch.Success then
                    let nestedName = "Array" + elementArrayMatch.Groups.["id"].Value
                    arrays
                    |> List.tryFind (fun candidate -> candidate.name = nestedName)
                    |> Option.filter arrayNeedsResizableStorage
                    |> Option.map (fun _ -> elementArrayMatch.Groups.["id"].Value)
                else None
            let usesResize = arrayHelperUsed arrayType "Resize"
            let usesReserve = arrayHelperUsed arrayType "Reserve"
            let usesCapacity = arrayHelperUsed arrayType "Capacity"
            let usesRefCount = arrayHelperUsed arrayType "RefCount"
            let usesClone = arrayHelperUsed arrayType "Clone" || arrayUsedByTailLoop arrayType
            if arrayNeedsResizableStorage arrayType then
                output.AppendLine($"function ArrayCreate{suffix}(len: LongInt; init_at_zero: Boolean): {arrayType.name};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if len < 0 then raise ERangeError.Create('negative Spiral array length');") |> ignore
                output.AppendLine($"  Result := {arrayType.name}.Create;") |> ignore
                output.AppendLine("  Result.RefCount := 1;") |> ignore
                output.AppendLine("  Result.Length := len;") |> ignore
                output.AppendLine("  Result.Capacity := len;") |> ignore
                output.AppendLine("  SetLength(Result.Data, len);") |> ignore
                output.AppendLine("  if not init_at_zero then begin end;") |> ignore
                output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure DynamicArraySet{suffix}(data: {arrayType.name}; index: LongInt; value: {elementType});") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if data = nil then raise EAccessViolation.Create('nil Spiral array');") |> ignore
                output.AppendLine("  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some childSuffix, _, _, _ ->
                    output.AppendLine($"  DynamicArrayClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  DynamicArrayDrop{childSuffix}(data.Data[index]);") |> ignore
                | None, Some childSuffix, _, _ ->
                    output.AppendLine($"  RecursiveClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  RecursiveDrop{childSuffix}(data.Data[index]);") |> ignore
                | None, None, Some childSuffix, _ ->
                    output.AppendLine($"  OptionalRecursiveClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  OptionalRecursiveDrop{childSuffix}(data.Data[index]);") |> ignore
                | None, None, None, Some childSuffix ->
                    output.AppendLine($"  TupleClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  TupleDrop{childSuffix}(data.Data[index]);") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("  data.Data[index] := value;") |> ignore
                output.AppendLine("end;") |> ignore
                output.AppendLine($"function DynamicArrayGet{suffix}(data: {arrayType.name}; index: LongInt): {elementType};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if data = nil then raise EAccessViolation.Create('nil Spiral array');") |> ignore
                output.AppendLine("  if (index < 0) or (index >= data.Length) then raise ERangeError.Create('Spiral array index out of bounds');") |> ignore
                output.AppendLine("  Result := data.Data[index];") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some _, _, _, _ -> ()
                | None, Some _, _, _ -> ()
                | None, None, Some childSuffix, _ -> output.AppendLine($"  OptionalRecursiveClone{childSuffix}(Result);") |> ignore
                | None, None, None, Some childSuffix -> output.AppendLine($"  TupleClone{childSuffix}(Result);") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("end;") |> ignore
                output.AppendLine($"function DynamicArrayLen{suffix}(data: {arrayType.name}): LongInt;") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if data = nil then Exit(0);") |> ignore
                output.AppendLine("  Result := data.Length;") |> ignore
                output.AppendLine("end;") |> ignore
                if usesResize then
                    output.AppendLine($"procedure DynamicArrayResize{suffix}(data: {arrayType.name}; len: LongInt);") |> ignore
                    output.AppendLine("var") |> ignore
                    output.AppendLine("  newCapacity: LongInt;") |> ignore
                    output.AppendLine("  i: LongInt;") |> ignore
                    output.AppendLine("begin") |> ignore
                    output.AppendLine("  if data = nil then raise EAccessViolation.Create('nil Spiral array');") |> ignore
                    output.AppendLine("  if len < 0 then raise ERangeError.Create('negative Spiral array length');") |> ignore
                    output.AppendLine("  if len < data.Length then") |> ignore
                    output.AppendLine("    for i := len to data.Length - 1 do") |> ignore
                    match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                    | Some childSuffix, _, _, _ -> output.AppendLine($"      DynamicArrayDrop{childSuffix}(data.Data[i]);") |> ignore
                    | None, Some childSuffix, _, _ -> output.AppendLine($"      RecursiveDrop{childSuffix}(data.Data[i]);") |> ignore
                    | None, None, Some childSuffix, _ -> output.AppendLine($"      OptionalRecursiveDrop{childSuffix}(data.Data[i]);") |> ignore
                    | None, None, None, Some childSuffix -> output.AppendLine($"      TupleDrop{childSuffix}(data.Data[i]);") |> ignore
                    | None, None, None, None -> output.AppendLine($"      data.Data[i] := Default({elementType});") |> ignore
                    output.AppendLine("  if len > data.Capacity then") |> ignore
                    output.AppendLine("  begin") |> ignore
                    output.AppendLine("    newCapacity := data.Capacity;") |> ignore
                    output.AppendLine("    if newCapacity < 1 then newCapacity := 1;") |> ignore
                    output.AppendLine("    while newCapacity < len do") |> ignore
                    output.AppendLine("    begin") |> ignore
                    output.AppendLine("      if newCapacity > High(LongInt) div 2 then") |> ignore
                    output.AppendLine("      begin") |> ignore
                    output.AppendLine("        newCapacity := len;") |> ignore
                    output.AppendLine("        Break;") |> ignore
                    output.AppendLine("      end;") |> ignore
                    output.AppendLine("      newCapacity := newCapacity * 2;") |> ignore
                    output.AppendLine("    end;") |> ignore
                    output.AppendLine("    SetLength(data.Data, newCapacity);") |> ignore
                    output.AppendLine("    data.Capacity := newCapacity;") |> ignore
                    output.AppendLine("  end;") |> ignore
                    output.AppendLine("  data.Length := len;") |> ignore
                    output.AppendLine("end;") |> ignore
                if usesReserve then
                    output.AppendLine($"procedure DynamicArrayReserve{suffix}(data: {arrayType.name}; capacity: LongInt);") |> ignore
                    output.AppendLine("var") |> ignore
                    output.AppendLine("  newCapacity: LongInt;") |> ignore
                    output.AppendLine("begin") |> ignore
                    output.AppendLine("  if data = nil then raise EAccessViolation.Create('nil Spiral array');") |> ignore
                    output.AppendLine("  if capacity < 0 then raise ERangeError.Create('negative Spiral array capacity');") |> ignore
                    output.AppendLine("  if capacity > data.Capacity then") |> ignore
                    output.AppendLine("  begin") |> ignore
                    output.AppendLine("    newCapacity := data.Capacity;") |> ignore
                    output.AppendLine("    if newCapacity < 1 then newCapacity := 1;") |> ignore
                    output.AppendLine("    while newCapacity < capacity do") |> ignore
                    output.AppendLine("    begin") |> ignore
                    output.AppendLine("      if newCapacity > High(LongInt) div 2 then") |> ignore
                    output.AppendLine("      begin") |> ignore
                    output.AppendLine("        newCapacity := capacity;") |> ignore
                    output.AppendLine("        Break;") |> ignore
                    output.AppendLine("      end;") |> ignore
                    output.AppendLine("      newCapacity := newCapacity * 2;") |> ignore
                    output.AppendLine("    end;") |> ignore
                    output.AppendLine("    SetLength(data.Data, newCapacity);") |> ignore
                    output.AppendLine("    data.Capacity := newCapacity;") |> ignore
                    output.AppendLine("  end;") |> ignore
                    output.AppendLine("end;") |> ignore
                if usesCapacity then
                    output.AppendLine($"function DynamicArrayCapacity{suffix}(data: {arrayType.name}): LongInt;") |> ignore
                    output.AppendLine("begin") |> ignore
                    output.AppendLine("  if data = nil then Exit(0);") |> ignore
                    output.AppendLine("  Result := data.Capacity;") |> ignore
                    output.AppendLine("end;") |> ignore
                if usesRefCount then
                    output.AppendLine($"function DynamicArrayRefCount{suffix}(data: {arrayType.name}): LongInt;") |> ignore
                    output.AppendLine("begin") |> ignore
                    output.AppendLine("  if data = nil then Exit(0);") |> ignore
                    output.AppendLine("  Result := data.RefCount;") |> ignore
                    output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure DynamicArrayClone{suffix}(data: {arrayType.name});") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if data <> nil then Inc(data.RefCount);") |> ignore
                output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure DynamicArrayDrop{suffix}(var data: {arrayType.name});") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some _, _, _, _ | None, Some _, _, _ | None, None, Some _, _ | None, None, None, Some _ ->
                    output.AppendLine("var") |> ignore
                    output.AppendLine("  i: LongInt;") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if data = nil then Exit;") |> ignore
                output.AppendLine("  Dec(data.RefCount);") |> ignore
                output.AppendLine("  if data.RefCount = 0 then") |> ignore
                output.AppendLine("  begin") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some childSuffix, _, _, _ ->
                    output.AppendLine("    for i := 0 to data.Capacity - 1 do") |> ignore
                    output.AppendLine($"      DynamicArrayDrop{childSuffix}(data.Data[i]);") |> ignore
                | None, Some childSuffix, _, _ ->
                    output.AppendLine("    for i := 0 to data.Capacity - 1 do") |> ignore
                    output.AppendLine($"      RecursiveDrop{childSuffix}(data.Data[i]);") |> ignore
                | None, None, Some childSuffix, _ ->
                    output.AppendLine("    for i := 0 to data.Capacity - 1 do") |> ignore
                    output.AppendLine($"      OptionalRecursiveDrop{childSuffix}(data.Data[i]);") |> ignore
                | None, None, None, Some childSuffix ->
                    output.AppendLine("    for i := 0 to data.Capacity - 1 do") |> ignore
                    output.AppendLine($"      TupleDrop{childSuffix}(data.Data[i]);") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("    SetLength(data.Data, 0);") |> ignore
                output.AppendLine("    data.Free;") |> ignore
                output.AppendLine("  end;") |> ignore
                output.AppendLine("  data := nil;") |> ignore
                output.AppendLine("end;") |> ignore
            else
                output.AppendLine($"function ArrayCreate{suffix}(len: LongInt; init_at_zero: Boolean): {arrayType.name};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if len < 0 then raise ERangeError.Create('negative Spiral array length');") |> ignore
                output.AppendLine("  SetLength(Result, len);") |> ignore
                output.AppendLine("  if not init_at_zero then begin end;") |> ignore
                output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure DynamicArraySet{suffix}(var data: {arrayType.name}; index: LongInt; value: {elementType});") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some childSuffix, _, _, _ ->
                    output.AppendLine($"  DynamicArrayClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  DynamicArrayDrop{childSuffix}(data[index]);") |> ignore
                | None, Some childSuffix, _, _ ->
                    output.AppendLine($"  RecursiveClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  RecursiveDrop{childSuffix}(data[index]);") |> ignore
                | None, None, Some childSuffix, _ ->
                    output.AppendLine($"  OptionalRecursiveClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  OptionalRecursiveDrop{childSuffix}(data[index]);") |> ignore
                | None, None, None, Some childSuffix ->
                    output.AppendLine($"  TupleClone{childSuffix}(value);") |> ignore
                    output.AppendLine($"  TupleDrop{childSuffix}(data[index]);") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("  data[index] := value;") |> ignore
                output.AppendLine("end;") |> ignore
                output.AppendLine($"function DynamicArrayGet{suffix}(const data: {arrayType.name}; index: LongInt): {elementType};") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  if (index < 0) or (index >= Length(data)) then raise ERangeError.Create('Spiral array index out of bounds');") |> ignore
                output.AppendLine("  Result := data[index];") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some _, _, _, _ -> ()
                | None, Some _, _, _ -> ()
                | None, None, Some childSuffix, _ -> output.AppendLine($"  OptionalRecursiveClone{childSuffix}(Result);") |> ignore
                | None, None, None, Some childSuffix -> output.AppendLine($"  TupleClone{childSuffix}(Result);") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("end;") |> ignore
                output.AppendLine($"function DynamicArrayLen{suffix}(const data: {arrayType.name}): LongInt;") |> ignore
                output.AppendLine("begin") |> ignore
                output.AppendLine("  Result := Length(data);") |> ignore
                output.AppendLine("end;") |> ignore
                if usesClone then
                    output.AppendLine($"procedure DynamicArrayClone{suffix}(const data: {arrayType.name});") |> ignore
                    match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                    | Some _, _, _, _ | None, Some _, _, _ | None, None, Some _, _ | None, None, None, Some _ ->
                        output.AppendLine("var") |> ignore
                        output.AppendLine("  i: LongInt;") |> ignore
                    | None, None, None, None -> ()
                    output.AppendLine("begin") |> ignore
                    match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                    | Some childSuffix, _, _, _ ->
                        output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                        output.AppendLine($"    DynamicArrayClone{childSuffix}(data[i]);") |> ignore
                    | None, Some childSuffix, _, _ ->
                        output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                        output.AppendLine($"    RecursiveClone{childSuffix}(data[i]);") |> ignore
                    | None, None, Some childSuffix, _ ->
                        output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                        output.AppendLine($"    OptionalRecursiveClone{childSuffix}(data[i]);") |> ignore
                    | None, None, None, Some childSuffix ->
                        output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                        output.AppendLine($"    TupleClone{childSuffix}(data[i]);") |> ignore
                    | None, None, None, None -> ()
                    output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure DynamicArrayDrop{suffix}(var data: {arrayType.name});") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some _, _, _, _ | None, Some _, _, _ | None, None, Some _, _ | None, None, None, Some _ ->
                    output.AppendLine("var") |> ignore
                    output.AppendLine("  i: LongInt;") |> ignore
                    output.AppendLine($"  item: {elementType};") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("begin") |> ignore
                match nestedResizableArraySuffix, nestedRecursiveSuffix, nestedOptionalRecursiveSuffix, nestedManagedTupleSuffix with
                | Some childSuffix, _, _, _ ->
                    output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                    output.AppendLine("  begin") |> ignore
                    output.AppendLine("    item := data[i];") |> ignore
                    output.AppendLine($"    DynamicArrayDrop{childSuffix}(item);") |> ignore
                    output.AppendLine("  end;") |> ignore
                | None, Some childSuffix, _, _ ->
                    output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                    output.AppendLine("  begin") |> ignore
                    output.AppendLine("    item := data[i];") |> ignore
                    output.AppendLine($"    RecursiveDrop{childSuffix}(item);") |> ignore
                    output.AppendLine("  end;") |> ignore
                | None, None, Some childSuffix, _ ->
                    output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                    output.AppendLine("  begin") |> ignore
                    output.AppendLine("    item := data[i];") |> ignore
                    output.AppendLine($"    OptionalRecursiveDrop{childSuffix}(item);") |> ignore
                    output.AppendLine("  end;") |> ignore
                | None, None, None, Some childSuffix ->
                    output.AppendLine("  for i := 0 to Length(data) - 1 do") |> ignore
                    output.AppendLine("  begin") |> ignore
                    output.AppendLine("    item := data[i];") |> ignore
                    output.AppendLine($"    TupleDrop{childSuffix}(item);") |> ignore
                    output.AppendLine("  end;") |> ignore
                | None, None, None, None -> ()
                output.AppendLine("  SetLength(data, 0);") |> ignore
                output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        let emitManagedAction action target cType =
            let weakMatch = Regex.Match(cType, "^WeakRecursive(?<id>[0-9]+)$")
            let optionalMatch = Regex.Match(cType, "^OptionalRecursive(?<id>[0-9]+)$")
            let recursiveMatch = Regex.Match(cType, "^Recursive(?<id>[0-9]+)$")
            let arrayMatch = Regex.Match(cType, "^Array(?<id>[0-9]+)\\s*\\*$")
            if weakMatch.Success then
                let suffix = weakMatch.Groups.["id"].Value
                output.AppendLine($"  WeakRecursive{action}{suffix}({target});") |> ignore
            elif optionalMatch.Success then
                let suffix = optionalMatch.Groups.["id"].Value
                output.AppendLine($"  OptionalRecursive{action}{suffix}({target});") |> ignore
            elif Set.contains cType ownedManagedTupleNames then
                let suffix = cType.Substring("Tuple".Length)
                output.AppendLine($"  Tuple{action}{suffix}({target});") |> ignore
            elif Set.contains cType managedClosureTupleNames then
                let suffix = cType.Substring("ClosureValue".Length)
                output.AppendLine($"  ClosureValue{action}{suffix}({target});") |> ignore
            elif recursiveMatch.Success then
                let suffix = recursiveMatch.Groups.["id"].Value
                output.AppendLine($"  Recursive{action}{suffix}({target});") |> ignore
            elif arrayMatch.Success then
                let suffix = arrayMatch.Groups.["id"].Value
                output.AppendLine($"  DynamicArray{action}{suffix}({target});") |> ignore
        for tupleType in tuples do
            if Set.contains tupleType.name ownedManagedTupleNames then
                let suffix = tupleType.name.Substring("Tuple".Length)
                output.AppendLine($"procedure TupleClone{suffix}(var value: {tupleType.name});") |> ignore
                output.AppendLine("begin") |> ignore
                for field in tupleType.fields do emitManagedAction "Clone" $"value.{field.name}" field.cType
                output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure TupleDrop{suffix}(var value: {tupleType.name});") |> ignore
                output.AppendLine("begin") |> ignore
                for field in tupleType.fields |> List.rev do emitManagedAction "Drop" $"value.{field.name}" field.cType
                output.AppendLine("end;") |> ignore
                output.AppendLine() |> ignore
            elif Set.contains tupleType.name managedClosureTupleNames then
                let suffix = tupleType.name.Substring("ClosureValue".Length)
                output.AppendLine($"procedure ClosureValueClone{suffix}(var value: {tupleType.name});") |> ignore
                output.AppendLine("begin") |> ignore
                for field in tupleType.fields do emitManagedAction "Clone" $"value.{field.name}" field.cType
                output.AppendLine("end;") |> ignore
                output.AppendLine($"procedure ClosureValueDrop{suffix}(var value: {tupleType.name});") |> ignore
                output.AppendLine("begin") |> ignore
                for field in tupleType.fields |> List.rev do emitManagedAction "Drop" $"value.{field.name}" field.cType
                output.AppendLine("end;") |> ignore
                output.AppendLine() |> ignore
        for tupleType in tuples do
            let constructorName = portableTupleConstructorName tupleType.name
            let parameters = tupleType.constructorParameters |> List.map (fun field -> $"{field.name}: {delphiType field.cType}") |> String.concat "; "
            output.AppendLine($"function {constructorName}({parameters}): {tupleType.name};") |> ignore
            output.AppendLine("begin") |> ignore
            for field in tupleType.fields do
                output.AppendLine($"  Result.{field.name} := {field.name};") |> ignore
                if Set.contains tupleType.name ownedManagedTupleNames then
                    emitManagedAction "Clone" $"Result.{field.name}" field.cType
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        for fn in functions do
            let hasExplicitArrayOwnership =
                fn.statements
                |> List.exists (fun statement ->
                    arrays
                    |> List.exists (fun arrayType ->
                        let suffix = arrayType.name.Substring("Array".Length)
                        portableStatementCallsV3 $"DynamicArrayClone{suffix}" statement))
            let functionName = delphiFunctionNameV2 fn.name
            let usesTailLoop = portableFunctionUsesTailLoop fn
            let parameters =
                fn.parameters
                |> List.map (fun parameter -> $"{parameter.name}: {delphiType parameter.cType}")
                |> String.concat "; "
            let sourceTypes =
                seq {
                    for parameter in fn.parameters do yield parameter.name, parameter.cType
                    for statement in fn.statements do
                        match statement with
                        | PortableDeclareV3(cType, name) -> yield name, cType
                        | _ -> ()
                }
                |> Map.ofSeq
            let methodArrayCloneArguments expression =
                let rec collect expression =
                    seq {
                        match expression with
                        | PortableCallV3(PortableIdentifierV3 methodName, arguments) when Regex.IsMatch(methodName, "^method[0-9]+$") ->
                            for argument in arguments do
                                match argument with
                                | PortableIdentifierV3 variable ->
                                    match Map.tryFind variable sourceTypes with
                                    | Some cType ->
                                        match Map.tryFind cType resizableArraySuffixByType with
                                        | Some suffix -> yield suffix, variable
                                        | None -> ()
                                    | None -> ()
                                | _ -> ()
                            for argument in arguments do yield! collect argument
                        | PortableCallV3(callee, arguments) ->
                            yield! collect callee
                            for argument in arguments do yield! collect argument
                        | PortableUnaryV3(_, operand) -> yield! collect operand
                        | PortableBinaryV3(_, left, right) ->
                            yield! collect left
                            yield! collect right
                        | PortableCastV3(_, operand) -> yield! collect operand
                        | PortableFieldV3(target, _) -> yield! collect target
                        | PortableNumberV3 _ | PortableStringV3 _ | PortableCharV3 _ | PortableBooleanV3 _ | PortableIdentifierV3 _ -> ()
                    }
                collect expression |> Seq.distinct |> Seq.toList
            let declarations =
                seq {
                    for statement in fn.statements do
                        match statement with
                        | PortableDeclareV3(cType, name) -> yield name, delphiType cType
                        | _ -> ()
                    if usesTailLoop then
                        for index, parameter in fn.parameters |> List.indexed do
                            yield $"__spiral_tail_arg{index}", delphiType parameter.cType
                }
                |> Seq.distinct
                |> Seq.toList
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
            if usesTailLoop then
                emit "while True do begin"
                indentLevel <- indentLevel + 1
            let emitMethodArrayClones expression =
                if not hasExplicitArrayOwnership then
                    for suffix, variable in methodArrayCloneArguments expression do
                        emit $"DynamicArrayClone{suffix}({variable});"
            for statement in fn.statements do
                match statement with
                | PortableDeclareV3 _ -> ()
                | PortableAssignV3(name, expression) ->
                    emitMethodArrayClones expression
                    emit $"{name} := {delphiExpressionV3Expected (Map.tryFind name sourceTypes) expression};"
                    match Map.tryFind name sourceTypes, expression with
                    | Some cType, PortableFieldV3 _
                        when Regex.IsMatch(cType, "^OptionalRecursive[0-9]+$") || Set.contains cType ownedManagedTupleNames ->
                        emitManagedAction "Clone" name cType
                    | _ -> ()
                | PortableExpressionStatementV3 expression ->
                    emitMethodArrayClones expression
                    emit $"{delphiExpressionV3 expression};"
                | PortableReturnV3 expression ->
                    match expression with
                    | None -> emit "Exit;"
                    | Some(PortableCallV3(PortableIdentifierV3 name, arguments)) when usesTailLoop && name = fn.name ->
                        if arguments.Length <> fn.parameters.Length then
                            failwith $"portable Delphi tail loop arity mismatch in {fn.name}: expected {fn.parameters.Length}, got {arguments.Length}"
                        for index, argument in arguments |> List.indexed do
                            let parameter = fn.parameters.[index]
                            emit $"__spiral_tail_arg{index} := {delphiExpressionV3Expected (Some parameter.cType) argument};"
                        for index, parameter in fn.parameters |> List.indexed do
                            let arrayMatch = Regex.Match(parameter.cType, "^Array(?<id>[0-9]+)\\s*\\*$")
                            let recursiveMatch = Regex.Match(parameter.cType, "^Recursive(?<id>[0-9]+)$")
                            if arrayMatch.Success then
                                let suffix = arrayMatch.Groups.["id"].Value
                                emit $"DynamicArrayClone{suffix}(__spiral_tail_arg{index});"
                                emit $"DynamicArrayDrop{suffix}({parameter.name});"
                            elif recursiveMatch.Success then
                                let suffix = recursiveMatch.Groups.["id"].Value
                                emit $"RecursiveClone{suffix}(__spiral_tail_arg{index});"
                                emit $"RecursiveDrop{suffix}({parameter.name});"
                            emit $"{parameter.name} := __spiral_tail_arg{index};"
                        emit "Continue;"
                    | Some value ->
                        emit $"Exit({delphiExpressionV3Expected (Some fn.returnType) value});"
                | PortableIfStartV3 condition ->
                    emitMethodArrayClones condition
                    emit $"if {delphiExpressionV3 condition} then begin"
                    indentLevel <- indentLevel + 1
                | PortableWhileStartV3 condition ->
                    emitMethodArrayClones condition
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
            let expectedIndent = if usesTailLoop then 2 else 1
            if indentLevel <> expectedIndent then failwith $"portable Delphi backend block stack is unbalanced in {fn.name}"
            if usesTailLoop then
                indentLevel <- indentLevel - 1
                emit "end;"
            output.AppendLine("end;") |> ignore
            output.AppendLine() |> ignore
        output.AppendLine("begin") |> ignore
        output.AppendLine("  Halt(SpiralMain);") |> ignore
        output.AppendLine("end.") |> ignore
        output.ToString()
    
    let private normalizeOptionalRecursiveOwnershipC (generated : string) =
        let mutable normalized = generated
        let valuePattern = "(?<value>[A-Za-z_][A-Za-z0-9_]*(?:\\.[A-Za-z_][A-Za-z0-9_]*)*)"
        normalized <- Regex.Replace(normalized, $"\\bOptionalRecursiveClone(?<id>[0-9]+)\\s*\\(\\s*&\\s*\\(?\\s*{valuePattern}\\s*\\)?\\s*\\)\\s*;", "")
        normalized <- Regex.Replace(normalized, $"\\bOptionalRecursiveDrop(?<id>[0-9]+)\\s*\\(\\s*&\\s*\\(?\\s*{valuePattern}\\s*\\)?\\s*\\)\\s*;", MatchEvaluator(fun matched ->
            let id = matched.Groups.["id"].Value
            let value = matched.Groups.["value"].Value
            $"__spiral_delphi_optional_recursive_drop_{id}({value});"))
        normalized

    let private normalizeDynamicScalarArrayC (generated : string) =
        let arrayTypePattern = Regex($"typedef struct \\{{\\s*int refc;\\s*uint32_t len;\\s*(?<type>{portableAnyTypePattern}) ptr\\[\\];\\s*\\}}\\s*(?<name>Array[0-9]+);", RegexOptions.Singleline)
        let arrayTypes = arrayTypePattern.Matches(generated) |> Seq.cast<Match> |> Seq.toList
        if arrayTypes.IsEmpty then generated
        else
            let mutable normalized = generated
            for arrayTypeMatch in arrayTypes do
                let arrayName = arrayTypeMatch.Groups.["name"].Value
                let suffix = arrayName.Substring("Array".Length)
                let assignName = $"AssignArray{suffix}"
                let assignPattern = Regex($"{Regex.Escape assignName}\\s*\\(&\\((?<var>[A-Za-z_][A-Za-z0-9_]*)->ptr\\[(?<index>[^\\]]+)\\]\\)\\s*,\\s*(?<value>[^;]+)\\);", RegexOptions.IgnoreCase)
                normalized <- assignPattern.Replace(normalized, MatchEvaluator(fun assignmentMatch ->
                    let variable = assignmentMatch.Groups.["var"].Value
                    let index = assignmentMatch.Groups.["index"].Value.Trim()
                    let value = assignmentMatch.Groups.["value"].Value.Trim()
                    $"DynamicArraySet{suffix}({variable}, {index}, {value});"))
                let nestedReadPattern = Regex($"(?<value>[A-Za-z_][A-Za-z0-9_]*(?:->[A-Za-z_][A-Za-z0-9_]*)+)->ptr\\[(?<index>[^\\]]+)\\]", RegexOptions.IgnoreCase)
                normalized <- nestedReadPattern.Replace(normalized, MatchEvaluator(fun readMatch ->
                    let value = readMatch.Groups.["value"].Value
                    let index = readMatch.Groups.["index"].Value.Trim()
                    $"DynamicArrayGet{suffix}({value}, {index})"))
                let nestedLenPattern = Regex($"(?<value>[A-Za-z_][A-Za-z0-9_]*(?:->[A-Za-z_][A-Za-z0-9_]*)+)->len\\b", RegexOptions.IgnoreCase)
                normalized <- nestedLenPattern.Replace(normalized, MatchEvaluator(fun lengthMatch ->
                    let value = lengthMatch.Groups.["value"].Value
                    $"DynamicArrayLen{suffix}({value})"))
                let variables =
                    Regex.Matches(normalized, $"\\b{Regex.Escape arrayName}\\s*\\*\\s*(?<name>[A-Za-z_][A-Za-z0-9_]*)\\b")
                    |> Seq.cast<Match>
                    |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                    |> Seq.distinct
                    |> Seq.toList
                for variable in variables do
                    let escaped = Regex.Escape variable
                    let readPattern = Regex($"\\b{escaped}->ptr\\[(?<index>[^\\]]+)\\]", RegexOptions.IgnoreCase)
                    normalized <- readPattern.Replace(normalized, MatchEvaluator(fun readMatch ->
                        let index = readMatch.Groups.["index"].Value.Trim()
                        $"DynamicArrayGet{suffix}({variable}, {index})"))
                    normalized <- Regex.Replace(normalized, $"\\b{escaped}->len\\b", $"DynamicArrayLen{suffix}({variable})")
                normalized <- Regex.Replace(normalized, $"\\bArrayDecref{suffix}\\s*\\((?<var>[A-Za-z_][A-Za-z0-9_]*)\\);", $"DynamicArrayDrop{suffix}(${{var}});")
            normalized <- Regex.Replace(normalized, "\\bOptionalRecursiveClone(?<id>[0-9]+)\\s*\\(\\s*&\\s*\\(?\\s*(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)?\\s*\\)\\s*;", "")
            normalized <- Regex.Replace(normalized, "\\bOptionalRecursiveDrop(?<id>[0-9]+)\\s*\\(\\s*&\\s*\\(?\\s*(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*\\)?\\s*\\)\\s*;", MatchEvaluator(fun matched ->
                let id = matched.Groups.["id"].Value
                let variable = matched.Groups.["var"].Value
                $"__spiral_delphi_optional_recursive_drop_{id}({variable});"))
            if normalized.Contains("->ptr[", StringComparison.Ordinal) || normalized.Contains("->len", StringComparison.Ordinal) then
                failwith "portable backend found unsupported dynamic scalar array residue"
            normalized

    let private normalizeMixedFixedScalarArraysC (generated : string) =
        let arrayTypePattern = Regex($"typedef struct \\{{\\s*int refc;\\s*uint32_t len;\\s*(?<type>{portableFixedScalarTypePattern}) ptr\\[\\];\\s*\\}}\\s*(?<name>Array[0-9]+);", RegexOptions.Singleline)
        let typeSpecs =
            arrayTypePattern.Matches(generated)
            |> Seq.cast<Match>
            |> Seq.map (fun matched ->
                let arrayName = matched.Groups.["name"].Value
                let elementType = matched.Groups.["type"].Value
                let suffix = arrayName.Substring("Array".Length)
                let createName = arrayName.Replace("Array", "ArrayCreate", StringComparison.Ordinal)
                let assignName = arrayName.Replace("Array", "AssignArray", StringComparison.Ordinal)
                arrayName, elementType, suffix, createName, assignName)
            |> Seq.toList
        let allocationPattern arrayName createName =
            Regex($"{Regex.Escape arrayName}\\s*\\*\\s*(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*;\\s*\\k<var>\\s*=\\s*{Regex.Escape createName}\\((?<len>[1-9][0-9]*)(?:ull|llu|ll|ul|lu|u|l)?\\s*,\\s*(?:true|false)\\s*\\);", RegexOptions.Singleline ||| RegexOptions.IgnoreCase)
        let activeTypeSpecs =
            typeSpecs
            |> List.filter (fun (arrayName, _, _, createName, _) -> (allocationPattern arrayName createName).IsMatch generated)
        if activeTypeSpecs.Length < 2 || activeTypeSpecs.Length <> typeSpecs.Length then generated
        else
            let requiresDynamicRuntime =
                activeTypeSpecs
                |> List.exists (fun (_, _, suffix, _, _) ->
                    [ $"DynamicArrayResize{suffix}("
                      $"DynamicArrayReserve{suffix}("
                      $"DynamicArrayCapacity{suffix}("
                      $"DynamicArrayRefCount{suffix}(" ]
                    |> List.exists (fun helper -> generated.Contains(helper, StringComparison.Ordinal)))
            let escapesIntoClosure =
                activeTypeSpecs
                |> List.exists (fun (arrayName, _, _, _, _) ->
                    Regex.IsMatch(
                        generated,
                        $"struct\\s+Closure[0-9]+\\s*\\{{.*?\\b{Regex.Escape arrayName}\\s*\\*\\s+[A-Za-z_][A-Za-z0-9_]*\\s*;",
                        RegexOptions.Singleline))
            if requiresDynamicRuntime || escapesIntoClosure then generated
            else
                let allocations =
                    activeTypeSpecs
                    |> List.collect (fun (arrayName, elementType, suffix, createName, assignName) ->
                        (allocationPattern arrayName createName).Matches(generated)
                        |> Seq.cast<Match>
                        |> Seq.map (fun matched -> matched, arrayName, elementType, suffix, createName, assignName)
                        |> Seq.toList)
                    |> List.sortBy (fun (matched, _, _, _, _, _) -> matched.Index)
                if allocations.IsEmpty then generated
                else
                    let firstAllocation, _, _, _, _, _ = allocations.Head
                    let functionPattern = Regex("(?m)^(?:static inline\\s+)?[A-Za-z_][A-Za-z0-9_\\s*]*\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*\\([^;{}]*\\)\\s*\\{")
                    let targetFunctionMatch =
                        functionPattern.Matches(generated)
                        |> Seq.cast<Match>
                        |> Seq.filter (fun matched -> matched.Index < firstAllocation.Index)
                        |> Seq.tryLast
                        |> Option.defaultWith (fun () -> failwith "portable backend mixed fixed array allocation is not inside a recognized function")
                    let targetFunctionIndex = targetFunctionMatch.Index
                    let targetFunctionName = targetFunctionMatch.Groups.["name"].Value
                    let openIndex = generated.IndexOf('{', targetFunctionMatch.Index)
                    let rec findClosingBrace index depth =
                        if index >= generated.Length then failwith $"portable backend mixed fixed array function has an unterminated body: {targetFunctionName}"
                        else
                            match generated.[index] with
                            | '{' -> findClosingBrace (index + 1) (depth + 1)
                            | '}' when depth = 1 -> index
                            | '}' -> findClosingBrace (index + 1) (depth - 1)
                            | _ -> findClosingBrace (index + 1) depth
                    let closeIndex = findClosingBrace openIndex 0
                    if allocations |> List.exists (fun (matched, _, _, _, _, _) -> matched.Index < targetFunctionIndex || closeIndex < matched.Index) then
                        failwith "portable backend mixed fixed arrays span multiple functions or owners"
                    let allowedPreludeFunctions =
                        activeTypeSpecs
                        |> List.collect (fun (_, _, suffix, _, _) ->
                            [ $"ArrayDecrefBody{suffix}"; $"ArrayDecref{suffix}"; $"ArrayCreate{suffix}"; $"ArrayLit{suffix}"; $"AssignArray{suffix}" ])
                        |> set
                    let unexpectedPreludeFunctions =
                        functionPattern.Matches(generated.Substring(0, targetFunctionIndex))
                        |> Seq.cast<Match>
                        |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                        |> Seq.filter (fun name -> not (allowedPreludeFunctions.Contains name))
                        |> Seq.distinct
                        |> Seq.toList
                    if not unexpectedPreludeFunctions.IsEmpty then
                        let unexpectedText = String.concat "," unexpectedPreludeFunctions
                        failwith $"portable backend mixed fixed array prelude contains unrelated functions before {targetFunctionName}: {unexpectedText}"
                    let includePrefix =
                        generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
                        |> Seq.takeWhile (fun line -> String.IsNullOrWhiteSpace line || line.TrimStart().StartsWith("#include", StringComparison.Ordinal))
                        |> String.concat "\n"
                    let mutable targetBody = generated.Substring(targetFunctionIndex, closeIndex - targetFunctionIndex + 1)
                    let suffixBody = generated.Substring(closeIndex + 1)
                    let localAllocations =
                        activeTypeSpecs
                        |> List.collect (fun (arrayName, elementType, suffix, createName, assignName) ->
                            (allocationPattern arrayName createName).Matches(targetBody)
                            |> Seq.cast<Match>
                            |> Seq.map (fun matched -> matched, arrayName, elementType, suffix, createName, assignName)
                            |> Seq.toList)
                        |> List.sortBy (fun (matched, _, _, _, _, _) -> matched.Index)
                    let allocationSpecs =
                        localAllocations
                        |> List.mapi (fun ordinal (matched, arrayName, elementType, suffix, _, assignName) ->
                            let variable = matched.Groups.["var"].Value
                            let length = Int32.Parse matched.Groups.["len"].Value
                            if length <= 0 || length > 64 then failwith $"portable backend mixed fixed array length is outside 1..64: {length}"
                            variable, length, $"ArrayGet{9000 + ordinal}", arrayName, elementType, suffix, assignName)
                    let allocationSpecByVariable =
                        allocationSpecs
                        |> Seq.map (fun (variable, length, getterName, arrayName, elementType, suffix, assignName) -> variable, (length, getterName, arrayName, elementType, suffix, assignName))
                        |> dict
                    for arrayName, _, _, createName, _ in activeTypeSpecs do
                        let pattern = allocationPattern arrayName createName
                        targetBody <- pattern.Replace(targetBody, MatchEvaluator(fun matched ->
                            let variable = matched.Groups.["var"].Value
                            let length, _, _, elementType, _, _ = allocationSpecByVariable.[variable]
                            [0 .. length - 1]
                            |> List.map (fun index -> $"{elementType} {variable}_{index};")
                            |> String.concat "\n"))
                    let getterPreludes = ResizeArray<string>()
                    for variable, length, getterName, _, elementType, suffix, assignName in allocationSpecs do
                        let assignPattern = Regex($"{Regex.Escape assignName}\\s*\\(&\\({Regex.Escape variable}->ptr\\[(?<index>[0-9]+)(?:ull|llu|ll|ul|lu|u|l)?\\]\\)\\s*,\\s*(?<value>[^;]+)\\);", RegexOptions.IgnoreCase)
                        targetBody <- assignPattern.Replace(targetBody, MatchEvaluator(fun assignmentMatch ->
                            let index = Int32.Parse assignmentMatch.Groups.["index"].Value
                            if index < 0 || index >= length then failwith $"portable backend mixed fixed array write is out of range: {index}"
                            let value = assignmentMatch.Groups.["value"].Value.Trim()
                            $"{variable}_{index} = {value};"))
                        let runtimeAssignPattern = Regex($"{Regex.Escape assignName}\\s*\\(&\\({Regex.Escape variable}->ptr\\[(?<index>[A-Za-z_][A-Za-z0-9_]*)\\]\\)\\s*,\\s*(?<value>[^;]+)\\);", RegexOptions.IgnoreCase)
                        let mutable runtimeWriteOrdinal = 0
                        targetBody <- runtimeAssignPattern.Replace(targetBody, MatchEvaluator(fun assignmentMatch ->
                            let indexName = assignmentMatch.Groups.["index"].Value
                            let value = assignmentMatch.Groups.["value"].Value.Trim()
                            let valueName = $"spiralWriteValue{suffix}_{variable}_{runtimeWriteOrdinal}"
                            runtimeWriteOrdinal <- runtimeWriteOrdinal + 1
                            let prefix = targetBody.Substring(0, assignmentMatch.Index)
                            let enumeratedCases =
                                [0 .. length - 1]
                                |> List.map (fun slot -> $"{Regex.Escape indexName}\\s*==\\s*{slot}(?:ull|llu|ll|ul|lu|u|l)?")
                                |> String.concat "\\s*\\|\\|\\s*"
                            let enumeratedGuardPattern = Regex($"if\\s*\\(\\s*(?:{enumeratedCases})\\s*\\)\\s*\\{{\\s*$", RegexOptions.Singleline ||| RegexOptions.IgnoreCase)
                            if not (enumeratedGuardPattern.IsMatch prefix) then
                                failwith $"portable backend mixed fixed array runtime write requires immediate bounded guard: {variable}[{indexName}]"
                            let materializedValue = $"{elementType} {valueName} = {value};\n    "
                            if length = 1 then materializedValue + $"{variable}_0 = {valueName};"
                            else
                                materializedValue +
                                    ([0 .. length - 1]
                                     |> List.map (fun slot ->
                                         if slot = 0 then $"if ({indexName} == 0) {{\n        {variable}_0 = {valueName};\n    }}"
                                         elif slot = length - 1 then $"else {{\n        {variable}_{slot} = {valueName};\n    }}"
                                         else $"else if ({indexName} == {slot}) {{\n        {variable}_{slot} = {valueName};\n    }}")
                                     |> String.concat " ")))
                        let constantReadPattern = Regex($"{Regex.Escape variable}->ptr\\[(?<index>[0-9]+)(?:ull|llu|ll|ul|lu|u|l)?\\]", RegexOptions.IgnoreCase)
                        targetBody <- constantReadPattern.Replace(targetBody, MatchEvaluator(fun readMatch ->
                            let index = Int32.Parse readMatch.Groups.["index"].Value
                            if index < 0 || index >= length then failwith $"portable backend mixed fixed array read is out of range: {index}"
                            $"{variable}_{index}"))
                        let runtimeReadPattern = Regex($"{Regex.Escape variable}->ptr\\[(?<index>[A-Za-z_][A-Za-z0-9_]*)\\]", RegexOptions.IgnoreCase)
                        if runtimeReadPattern.IsMatch targetBody then
                            if Regex.IsMatch(generated, $"\\b{Regex.Escape getterName}\\s*\\(") then failwith $"portable backend helper collision: {getterName}"
                            let getterArguments = [0 .. length - 1] |> List.map (fun index -> $"{variable}_{index}") |> String.concat ", "
                            targetBody <- runtimeReadPattern.Replace(targetBody, MatchEvaluator(fun readMatch ->
                                let indexName = readMatch.Groups.["index"].Value
                                $"{getterName}({indexName}, {getterArguments})"))
                            let parameters = [0 .. length - 1] |> List.map (fun index -> $"{elementType} v{index}") |> String.concat ", "
                            let branches = [0 .. length - 2] |> List.map (fun index -> $"    if (index == {index}) {{\n        return v{index};\n    }}") |> String.concat "\n"
                            getterPreludes.Add($"{elementType} {getterName}(int32_t index, {parameters}){{\n{branches}\n    return v{length - 1};\n}}\n")
                        targetBody <- Regex.Replace(targetBody, $"\\bArrayDecref{suffix}\\s*\\({Regex.Escape variable}\\);\\s*", "")
                    if targetBody.Contains("->ptr[", StringComparison.Ordinal) || targetBody.Contains("ArrayCreate", StringComparison.Ordinal) then
                        failwith "portable backend found unsupported mixed fixed array residue"
                    includePrefix + "\n" + (String.concat "" getterPreludes) + targetBody + suffixBody

    let private normalizeFixedScalarArrayC (generated : string) =
        let arrayTypePattern = Regex($"typedef struct \\{{\\s*int refc;\\s*uint32_t len;\\s*(?<type>{portableFixedScalarTypePattern}) ptr\\[\\];\\s*\\}}\\s*(?<name>Array[0-9]+);", RegexOptions.Singleline)
        let arrayTypeMatch = arrayTypePattern.Match generated
        if not arrayTypeMatch.Success then generated
        else
            let arrayName = arrayTypeMatch.Groups.["name"].Value
            let elementType = arrayTypeMatch.Groups.["type"].Value
            let createName = arrayName.Replace("Array", "ArrayCreate", StringComparison.Ordinal)
            let allocationPattern = Regex($"{Regex.Escape arrayName}\\s*\\*\\s*(?<var>[A-Za-z_][A-Za-z0-9_]*)\\s*;\\s*\\k<var>\\s*=\\s*{Regex.Escape createName}\\((?<len>[1-9][0-9]*)(?:ull|llu|ll|ul|lu|u|l)?\\s*,\\s*(?:true|false)\\s*\\);", RegexOptions.Singleline ||| RegexOptions.IgnoreCase)
            let allocationMatches = allocationPattern.Matches generated |> Seq.cast<Match> |> Seq.toList
            let allocationMatch = allocationPattern.Match generated
            let suffix = arrayName.Substring("Array".Length)
            let requiresDynamicRuntime =
                [ $"DynamicArrayResize{suffix}("
                  $"DynamicArrayReserve{suffix}("
                  $"DynamicArrayCapacity{suffix}("
                  $"DynamicArrayRefCount{suffix}(" ]
                |> List.exists (fun helper -> generated.Contains(helper, StringComparison.Ordinal))
            let escapesIntoClosure =
                Regex.IsMatch(
                    generated,
                    $"struct\\s+Closure[0-9]+\\s*\\{{.*?\\b{Regex.Escape arrayName}\\s*\\*\\s+[A-Za-z_][A-Za-z0-9_]*\\s*;",
                    RegexOptions.Singleline)
            let preludeFunctionPattern = Regex("(?m)^(?:static inline\\s+)?[A-Za-z_][A-Za-z0-9_\\s*]*\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*\\([^;{}]*\\)\\s*\\{")
            let allowedPreludeFunctionsEarly =
                set [ $"ArrayDecrefBody{suffix}"; $"ArrayDecref{suffix}"; $"ArrayCreate{suffix}"; $"ArrayLit{suffix}"; $"AssignArray{suffix}" ]
            let fixedArrayOwnerName, hasUnrelatedPreludeFunctions =
                if not allocationMatch.Success then "", false
                else
                    let functionsThroughOwner =
                        preludeFunctionPattern.Matches(generated.Substring(0, allocationMatch.Index))
                        |> Seq.cast<Match>
                        |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                        |> Seq.toList
                        |> List.rev
                    match functionsThroughOwner with
                    | owner :: preludeFunctions ->
                        owner,
                        (preludeFunctions
                         |> List.exists (fun name -> not (allowedPreludeFunctionsEarly.Contains name)))
                    | [] -> "", false
            let preserveDynamicMain = hasUnrelatedPreludeFunctions && fixedArrayOwnerName = "main"
            if not allocationMatch.Success || requiresDynamicRuntime || escapesIntoClosure || preserveDynamicMain then generated
            else
                let functionPattern = Regex("(?m)^(?:static inline\\s+)?[A-Za-z_][A-Za-z0-9_\\s*]*\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*\\([^;{}]*\\)\\s*\\{")
                let targetFunctionMatch =
                    functionPattern.Matches(generated)
                    |> Seq.cast<Match>
                    |> Seq.filter (fun matched -> matched.Index < allocationMatch.Index)
                    |> Seq.tryLast
                    |> Option.defaultWith (fun () -> failwith "portable backend fixed array allocation is not inside a recognized function")
                let targetFunctionIndex = targetFunctionMatch.Index
                let targetFunctionName = targetFunctionMatch.Groups.["name"].Value
                let openIndex = generated.IndexOf('{', targetFunctionMatch.Index)
                let rec findClosingBrace index depth =
                    if index >= generated.Length then failwith $"portable backend fixed array function has an unterminated body: {targetFunctionName}"
                    else
                        match generated.[index] with
                        | '{' -> findClosingBrace (index + 1) (depth + 1)
                        | '}' when depth = 1 -> index
                        | '}' -> findClosingBrace (index + 1) (depth - 1)
                        | _ -> findClosingBrace (index + 1) depth
                let closeIndex = findClosingBrace openIndex 0
                if allocationMatch.Index > closeIndex then failwith "portable backend fixed array allocation is outside the selected function body"
                let targetAllocations =
                    allocationMatches
                    |> List.filter (fun matched -> targetFunctionIndex <= matched.Index && matched.Index <= closeIndex)
                if targetAllocations.Length <> allocationMatches.Length then
                    failwith "portable backend fixed arrays span multiple functions or owners"
                let allowedPreludeFunctions =
                    set [ $"ArrayDecrefBody{suffix}"; $"ArrayDecref{suffix}"; $"ArrayCreate{suffix}"; $"ArrayLit{suffix}"; $"AssignArray{suffix}" ]
                let unexpectedPreludeFunctions =
                    functionPattern.Matches(generated.Substring(0, targetFunctionIndex))
                    |> Seq.cast<Match>
                    |> Seq.map (fun matched -> matched.Groups.["name"].Value)
                    |> Seq.filter (fun name -> not (allowedPreludeFunctions.Contains name))
                    |> Seq.distinct
                    |> Seq.toList
                if not unexpectedPreludeFunctions.IsEmpty then
                    let unexpectedText = String.concat "," unexpectedPreludeFunctions
                    failwith $"portable backend fixed array prelude contains unrelated functions before {targetFunctionName}: {unexpectedText}"
                let includePrefix =
                    generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
                    |> Seq.takeWhile (fun line -> String.IsNullOrWhiteSpace line || line.TrimStart().StartsWith("#include", StringComparison.Ordinal))
                    |> String.concat "\n"
                let mutable mainBody = generated.Substring(targetFunctionIndex, closeIndex - targetFunctionIndex + 1)
                let suffixBody = generated.Substring(closeIndex + 1)
                let localAllocations =
                    allocationPattern.Matches(mainBody)
                    |> Seq.cast<Match>
                    |> Seq.toList
                if localAllocations.IsEmpty then
                    failwith $"portable backend fixed array allocation disappeared from {targetFunctionName}"
                let allocationSpecs =
                    localAllocations
                    |> List.mapi (fun ordinal matched ->
                        let variable = matched.Groups.["var"].Value
                        let length = Int32.Parse matched.Groups.["len"].Value
                        if length <= 0 || length > 64 then
                            failwith $"portable backend fixed array length is outside 1..64: {length}"
                        variable, length, $"ArrayGet{9000 + ordinal}")
                let allocationSpecByVariable =
                    allocationSpecs
                    |> Seq.map (fun (variable, length, getterName) -> variable, (length, getterName))
                    |> dict
                mainBody <-
                    allocationPattern.Replace(mainBody, MatchEvaluator(fun matched ->
                        let variable = matched.Groups.["var"].Value
                        let length, _ = allocationSpecByVariable.[variable]
                        [0 .. length - 1]
                        |> List.map (fun index -> $"{elementType} {variable}_{index};")
                        |> String.concat "\n"))
                let getterPreludes = ResizeArray<string>()
                for variable, length, getterName in allocationSpecs do
                    let assignName = arrayName.Replace("Array", "AssignArray", StringComparison.Ordinal)
                    let assignPattern = Regex($"{Regex.Escape assignName}\\s*\\(&\\({Regex.Escape variable}->ptr\\[(?<index>[0-9]+)(?:ull|llu|ll|ul|lu|u|l)?\\]\\)\\s*,\\s*(?<value>[^;]+)\\);", RegexOptions.IgnoreCase)
                    mainBody <- assignPattern.Replace(mainBody, MatchEvaluator(fun assignmentMatch ->
                        let index = Int32.Parse assignmentMatch.Groups.["index"].Value
                        if index < 0 || index >= length then failwith $"portable backend fixed array write is out of range: {index}"
                        let value = assignmentMatch.Groups.["value"].Value.Trim()
                        $"{variable}_{index} = {value};"))
                    let runtimeAssignPattern = Regex($"{Regex.Escape assignName}\\s*\\(&\\({Regex.Escape variable}->ptr\\[(?<index>[A-Za-z_][A-Za-z0-9_]*)\\]\\)\\s*,\\s*(?<value>[^;]+)\\);", RegexOptions.IgnoreCase)
                    mainBody <- runtimeAssignPattern.Replace(mainBody, MatchEvaluator(fun assignmentMatch ->
                        let indexName = assignmentMatch.Groups.["index"].Value
                        let value = assignmentMatch.Groups.["value"].Value.Trim()
                        [0 .. length - 1]
                        |> List.map (fun index -> $"if ({indexName} == {index}) {{\n    {variable}_{index} = {value};\n}}")
                        |> String.concat "\n"))
                    let constantReadPattern = Regex($"{Regex.Escape variable}->ptr\\[(?<index>[0-9]+)(?:ull|llu|ll|ul|lu|u|l)?\\]", RegexOptions.IgnoreCase)
                    mainBody <- constantReadPattern.Replace(mainBody, MatchEvaluator(fun readMatch ->
                        let index = Int32.Parse readMatch.Groups.["index"].Value
                        if index < 0 || index >= length then failwith $"portable backend fixed array read is out of range: {index}"
                        $"{variable}_{index}"))
                    let runtimeReadPattern = Regex($"{Regex.Escape variable}->ptr\\[(?<index>[A-Za-z_][A-Za-z0-9_]*)\\]", RegexOptions.IgnoreCase)
                    let hasRuntimeRead = runtimeReadPattern.IsMatch mainBody
                    if hasRuntimeRead && Regex.IsMatch(generated, $"\\b{Regex.Escape getterName}\\s*\\(") then
                        failwith $"portable backend helper collision: {getterName}"
                    if hasRuntimeRead then
                        let getterArguments =
                            [0 .. length - 1]
                            |> List.map (fun index -> $"{variable}_{index}")
                            |> String.concat ", "
                        mainBody <- runtimeReadPattern.Replace(mainBody, MatchEvaluator(fun readMatch ->
                            let index = readMatch.Groups.["index"].Value
                            $"{getterName}({index}, {getterArguments})"))
                        let parameters =
                            [0 .. length - 1]
                            |> List.map (fun index -> $"{elementType} v{index}")
                            |> String.concat ", "
                        let branches =
                            [0 .. length - 2]
                            |> List.map (fun index -> $"    if (index == {index}) {{\n        return v{index};\n    }}")
                            |> String.concat "\n"
                        getterPreludes.Add($"{elementType} {getterName}(int32_t index, {parameters}){{\n{branches}\n    return v{length - 1};\n}}\n")
                    mainBody <- Regex.Replace(mainBody, $"\\bArrayDecref[0-9]+\\s*\\({Regex.Escape variable}\\);\\s*", "")
                if mainBody.Contains("->ptr[", StringComparison.Ordinal) || mainBody.Contains("ArrayCreate", StringComparison.Ordinal) then
                    failwith "portable backend found unsupported fixed array residue"
                includePrefix + "\n" + (String.concat "" getterPreludes) + mainBody + suffixBody

    let private normalizeScalarUnionC (generated : string) =
        let unionPattern = Regex($"typedef struct \\{{\\s*int tag;\\s*union \\{{(?<cases>.*?)\\}};\\s*\\}}\\s*(?<name>US[0-9]+);", RegexOptions.Singleline)
        let unionMatch = unionPattern.Match generated
        if not unionMatch.Success then generated
        else
            let casePattern = Regex($"struct \\{{\\s*(?<type>{portableAnyTypePattern})\\s+v0;\\s*\\}}\\s+case(?<index>[0-9]+);", RegexOptions.Singleline)
            let cases =
                casePattern.Matches(unionMatch.Groups.["cases"].Value)
                |> Seq.cast<Match>
                |> Seq.map (fun caseMatch -> Int32.Parse(caseMatch.Groups.["index"].Value), caseMatch.Groups.["type"].Value)
                |> Seq.sortBy fst
                |> Seq.toList
            if cases.Length <> 2 then failwith "portable backend supports exactly two scalar union cases"
            if cases |> List.map fst <> [0; 1] then failwith "portable backend requires scalar union tags 0 and 1"
            let unionName = unionMatch.Groups.["name"].Value
            let tupleName = "Tuple9000"
            if generated.Contains(tupleName, StringComparison.Ordinal) then failwith $"portable backend tuple collision: {tupleName}"
            let tupleConstructor = tupleName.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
            let defaultValue = function
                | "bool" -> "false"
                | "float" -> "0.0f"
                | "double" -> "0.0"
                | value when Regex.IsMatch(value, "^String\\s*\\*$") -> "StringLit(0, \"\")"
                | _ -> "0"
            let homogeneousPayload =
                cases |> List.map snd |> List.distinct |> List.length = 1
            let payloadFields =
                if homogeneousPayload then [cases.Head |> snd]
                else cases |> List.map snd
            let tupleFields =
                payloadFields
                |> List.mapi (fun position payloadType -> $"    {payloadType} v{position + 1};")
                |> String.concat "\n"
            let tupleParameters =
                payloadFields
                |> List.mapi (fun position payloadType -> $"{payloadType} v{position + 1}")
                |> String.concat ", "
            let tupleAssignments =
                payloadFields
                |> List.mapi (fun position _ -> $"x.v{position + 1} = v{position + 1};")
                |> String.concat " "
            let tuplePrelude =
                $"typedef struct {{\n    int32_t v0;\n{tupleFields}\n}} {tupleName};\nstatic inline {tupleName} {tupleConstructor}(int32_t v0, {tupleParameters}){{\n    {tupleName} x;\n    x.v0 = v0; {tupleAssignments}\n    return x;\n}}"
            let mutable normalized = generated
            let supportPattern = Regex($"static inline void USIncrefBody[0-9]+.*?(?={Regex.Escape unionName}\\s+{Regex.Escape unionName}_[0-9]+\\()", RegexOptions.Singleline)
            normalized <- supportPattern.Replace(normalized, "")
            let constructorDefinitionPattern = Regex($"^{Regex.Escape unionName}\\s+{Regex.Escape unionName}_[0-9]+\\([^)]*\\)\\s*\\{{.*?^\\}}\\s*", RegexOptions.Singleline ||| RegexOptions.Multiline)
            normalized <- constructorDefinitionPattern.Replace(normalized, "")
            for caseIndex, _ in cases do
                let constructorPattern = Regex($"\\b{Regex.Escape unionName}_{caseIndex}\\s*\\(\\s*(?<value>[^()]*)\\s*\\)")
                normalized <- constructorPattern.Replace(normalized, MatchEvaluator(fun constructorMatch ->
                    let value = constructorMatch.Groups.["value"].Value.Trim()
                    let payloads =
                        if homogeneousPayload then value
                        else
                            cases
                            |> List.map (fun (index, payloadType) ->
                                if index = caseIndex then value else defaultValue payloadType)
                            |> String.concat ", "
                    $"{tupleConstructor}({caseIndex}, {payloads})"))
            normalized <- unionPattern.Replace(normalized, tuplePrelude, 1)
            normalized <- Regex.Replace(normalized, "\\bUS(?:Incref|Decref)[0-9]+\\s*\\(&\\([^)]+\\)\\);\\s*", "")
            normalized <- Regex.Replace(normalized, "\\.case(?<index>[01])\\.v0", MatchEvaluator(fun accessMatch ->
                let fieldIndex =
                    if homogeneousPayload then 1
                    else Int32.Parse(accessMatch.Groups.["index"].Value) + 1
                $".v{fieldIndex}"))
            normalized <- normalized.Replace(".tag", ".v0", StringComparison.Ordinal)
            normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape unionName}\\b", tupleName)
            let switchPattern = Regex("switch\\s*\\((?<disc>[^)]+)\\)\\s*\\{\\s*case\\s+(?<firstIndex>[01]):\\s*\\{[^\\n]*\\n(?<first>.*?)\\s*break;\\s*\\}\\s*case\\s+(?<secondIndex>[01]):\\s*\\{[^\\n]*\\n(?<second>.*?)\\s*break;\\s*\\}\\s*\\}", RegexOptions.Singleline)
            normalized <- switchPattern.Replace(normalized, MatchEvaluator(fun switchMatch ->
                let disc = switchMatch.Groups.["disc"].Value.Trim()
                let firstIndex = switchMatch.Groups.["firstIndex"].Value
                let firstBody = switchMatch.Groups.["first"].Value.TrimEnd()
                let secondBody = switchMatch.Groups.["second"].Value.TrimEnd()
                $"if ({disc} == {firstIndex}) {{\n{firstBody}\n    }} else {{\n{secondBody}\n    }}"))
            if normalized.Contains("switch (", StringComparison.Ordinal) then failwith "portable backend found an unsupported union switch"
            let initializedDeclarationPattern = Regex($"^(?<indent>\\s*)(?<type>{portableAnyTypePattern})\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<expr>.+);\\s*$", RegexOptions.Multiline)
            initializedDeclarationPattern.Replace(normalized, MatchEvaluator(fun declarationMatch ->
                let indent = declarationMatch.Groups.["indent"].Value
                let cType = declarationMatch.Groups.["type"].Value
                let name = declarationMatch.Groups.["name"].Value
                let expression = declarationMatch.Groups.["expr"].Value
                $"{indent}{cType} {name};\n{indent}{name} = {expression};"))

    let private findMatchingDelimiter (text : string) openIndex openChar closeChar =
        let mutable depth = 0
        let mutable index = openIndex
        let mutable result = -1
        while index < text.Length && result = -1 do
            let current = text.[index]
            if current = openChar then depth <- depth + 1
            elif current = closeChar then
                depth <- depth - 1
                if depth = 0 then result <- index
            index <- index + 1
        if result < 0 then failwith $"portable backend found an unterminated {openChar}{closeChar} block"
        result

    let private rewriteDenseUnionSwitches (generated : string) =
        let mutable text = generated
        let mutable searchFrom = 0
        let mutable keepSearching = true
        while keepSearching do
            let switchIndex = text.IndexOf("switch (", searchFrom, StringComparison.Ordinal)
            if switchIndex < 0 then keepSearching <- false
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
                    let caseMatch = Regex.Match(body.Substring(bodyIndex), "case\\s+(?<index>[0-9]+)\\s*:\\s*\\{")
                    if not caseMatch.Success then bodyIndex <- body.Length
                    else
                        let caseBraceOpen = bodyIndex + caseMatch.Index + caseMatch.Length - 1
                        let caseBraceClose = findMatchingDelimiter body caseBraceOpen '{' '}'
                        let caseBody = body.Substring(caseBraceOpen + 1, caseBraceClose - caseBraceOpen - 1)
                        let withoutBreak = Regex.Replace(caseBody, "\\s*break;\\s*$", "", RegexOptions.Singleline).TrimEnd()
                        let withoutComment = Regex.Replace(withoutBreak, "^\\s*//[^\\n]*(?:\\n|$)", "", RegexOptions.Singleline)
                        cases.Add(Int32.Parse(caseMatch.Groups.["index"].Value), withoutComment)
                        bodyIndex <- caseBraceClose + 1
                let defaultBody =
                    let defaultMatch = Regex.Match(body, "default\\s*:\\s*\\{")
                    if not defaultMatch.Success then None
                    else
                        let defaultBraceOpen = defaultMatch.Index + defaultMatch.Length - 1
                        let defaultBraceClose = findMatchingDelimiter body defaultBraceOpen '{' '}'
                        let rawDefault = body.Substring(defaultBraceOpen + 1, defaultBraceClose - defaultBraceOpen - 1)
                        let withoutBreak = Regex.Replace(rawDefault, "\\s*break;\\s*$", "", RegexOptions.Singleline).TrimEnd()
                        Some (Regex.Replace(withoutBreak, "^\\s*//[^\\n]*(?:\\n|$)", "", RegexOptions.Singleline))
                if cases.Count = 0 || (cases.Count < 2 && defaultBody.IsNone) then
                    searchFrom <- braceClose + 1
                else
                    let ordered = cases |> Seq.toList
                    let rec render remaining =
                        match remaining with
                        | [] -> defaultBody |> Option.defaultWith (fun () -> failwith "portable backend union switch had no terminal branch")
                        | [_, lastBody] when defaultBody.IsNone -> lastBody
                        | (tag, caseBody) :: tail ->
                            let inner = render tail
                            $"if ({discriminator} == {tag}) {{\n{caseBody}\n    }} else {{\n{inner}\n    }}"
                    let replacement = render ordered
                    text <- text.Substring(0, switchIndex) + replacement + text.Substring(braceClose + 1)
                    searchFrom <- switchIndex
        text

    let private normalizeExtendedScalarUnionC (generated : string) =
        let unionPattern = Regex($"typedef struct \\{{\\s*int tag;\\s*union \\{{(?<cases>.*?)\\}};\\s*\\}}\\s*(?<name>US[0-9]+);", RegexOptions.Singleline)
        let unionMatch = unionPattern.Match generated
        if not unionMatch.Success then generated
        else
            let unionName = unionMatch.Groups.["name"].Value
            let payloadCasePattern = Regex($"struct \\{{(?<fields>.*?)\\}}\\s+case(?<index>[0-9]+);", RegexOptions.Singleline)
            let payloadFieldPattern = Regex($"(?<type>{portableAnyTypePattern})\\s+v(?<index>[0-9]+);", RegexOptions.Singleline)
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
                |> Seq.map (fun constructorMatch ->
                    let index = Int32.Parse(constructorMatch.Groups.["index"].Value)
                    let parameters = constructorMatch.Groups.["parameters"].Value.Trim()
                    let payloadTypes =
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
                    index, payloadTypes)
                |> Seq.sortBy fst
                |> Seq.toList
            if constructors.Length = 2 && constructors |> List.forall (snd >> List.length >> (=) 1) then
                normalizeScalarUnionC generated
            else
                if constructors.Length < 2 || constructors.Length > 8 then failwith "portable backend supports dense scalar unions with 2..8 cases"
                let expectedTags = [0 .. constructors.Length - 1]
                if constructors |> List.map fst <> expectedTags then failwith "portable backend requires dense scalar union tags starting at zero"
                for tag, constructorPayloadTypes in constructors do
                    match payloadTypes.TryGetValue tag with
                    | true, actual when constructorPayloadTypes = actual -> ()
                    | true, actual -> failwith $"portable backend union payload mismatch at tag {tag}: {constructorPayloadTypes} versus {actual}"
                    | false, _ when constructorPayloadTypes.IsEmpty -> ()
                    | false, _ -> failwith $"portable backend union payload metadata missing at tag {tag}"
                let tupleName = "Tuple9000"
                if generated.Contains(tupleName, StringComparison.Ordinal) then failwith $"portable backend tuple collision: {tupleName}"
                let tupleConstructor = tupleName.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
                let payloadCases =
                    constructors
                    |> List.collect (fun (tag, payloadTypes) -> payloadTypes |> List.mapi (fun fieldIndex payloadType -> tag, fieldIndex, payloadType))
                let fieldForTag = Dictionary<string,int>(StringComparer.Ordinal)
                payloadCases |> List.iteri (fun position (tag, fieldIndex, _) -> fieldForTag.[$"{tag}:{fieldIndex}"] <- position + 1)
                let rec defaultValue = function
                    | "bool" -> "false"
                    | "float" -> "0.0f"
                    | "double" -> "0.0"
                    | value when Regex.IsMatch(value, "^String\\s*\\*$") -> "StringLit(0, \"\")"
                    | value when Regex.IsMatch(value, "^Array(?<id>[0-9]+)\\s*\\*$") ->
                        let id = Regex.Match(value, "^Array(?<id>[0-9]+)\\s*\\*$").Groups.["id"].Value
                        $"ArrayCreate{id}(0, false)"
                    | value when Regex.IsMatch(value, "^Tuple[0-9]+$") ->
                        let constructor = value.Replace("Tuple", "TupleCreate", StringComparison.Ordinal)
                        let signature = Regex.Match(generated, $"static inline {Regex.Escape value} {Regex.Escape constructor}\\((?<parameters>[^)]*)\\)")
                        if not signature.Success then failwith $"portable backend could not resolve normalized tuple default: {value}"
                        let defaults =
                            signature.Groups.["parameters"].Value.Split(',', StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
                            |> Array.map (fun parameter ->
                                let parameterMatch = Regex.Match(parameter, $"^(?<type>{portableAnyTypePattern})\\s+v[0-9]+$")
                                if not parameterMatch.Success then failwith $"portable backend found an unsupported normalized tuple parameter: {parameter}"
                                defaultValue parameterMatch.Groups.["type"].Value)
                            |> String.concat ", "
                        $"{constructor}({defaults})"
                    | _ -> "0"
                let tupleFields =
                    payloadCases
                    |> List.mapi (fun position (_, _, payloadType) -> $"    {payloadType} v{position + 1};")
                    |> String.concat "\n"
                let tupleParameters =
                    payloadCases
                    |> List.mapi (fun position (_, _, payloadType) -> $"{payloadType} v{position + 1}")
                    |> String.concat ", "
                let tupleAssignments =
                    payloadCases
                    |> List.mapi (fun position _ -> $"x.v{position + 1} = v{position + 1};")
                    |> String.concat " "
                let constructorSignature = if payloadCases.IsEmpty then "int32_t v0" else $"int32_t v0, {tupleParameters}"
                let tuplePrelude =
                    $"typedef struct {{\n    int32_t v0;\n{tupleFields}\n}} {tupleName};\nstatic inline {tupleName} {tupleConstructor}({constructorSignature}){{\n    {tupleName} x;\n    x.v0 = v0; {tupleAssignments}\n    return x;\n}}"
                let mutable normalized = generated
                let supportPattern = Regex($"static inline void USIncrefBody[0-9]+.*?(?={Regex.Escape unionName}\\s+{Regex.Escape unionName}_[0-9]+\\()", RegexOptions.Singleline)
                normalized <- supportPattern.Replace(normalized, "")
                let constructorDefinitionPattern = Regex($"^{Regex.Escape unionName}\\s+{Regex.Escape unionName}_[0-9]+\\([^)]*\\)\\s*\\{{.*?^\\}}\\s*", RegexOptions.Singleline ||| RegexOptions.Multiline)
                normalized <- constructorDefinitionPattern.Replace(normalized, "")
                for tag, constructorPayloadTypes in constructors do
                    let callPattern = Regex($"\\b{Regex.Escape unionName}_{tag}\\s*\\(\\s*(?<values>[^()]*)\\s*\\)")
                    normalized <- callPattern.Replace(normalized, MatchEvaluator(fun constructorMatch ->
                        let rawValues = constructorMatch.Groups.["values"].Value.Trim()
                        let activeValues =
                            if String.IsNullOrWhiteSpace rawValues then []
                            else rawValues.Split(',', StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries) |> Array.toList
                        if activeValues.Length <> constructorPayloadTypes.Length then
                            failwith $"portable backend union constructor payload count mismatch at tag {tag}: expected {constructorPayloadTypes.Length}, got {activeValues.Length}"
                        let payloadArguments =
                            payloadCases
                            |> List.map (fun (payloadTag, fieldIndex, payloadCType) ->
                                if payloadTag = tag then activeValues.[fieldIndex] else defaultValue payloadCType)
                        let allArguments = string tag :: payloadArguments
                        let joinedArguments = String.concat ", " allArguments
                        $"{tupleConstructor}({joinedArguments})"))
                let unionSuffix = unionName.Substring(2)
                let managedCopyPattern = Regex($"(?m)^(?<indent>[ \\t]*)USIncref{Regex.Escape unionSuffix}\\s*\\(&\\((?<source>[A-Za-z_][A-Za-z0-9_]*)\\)\\);[ \\t]*\\r?\\n[ \\t]*{Regex.Escape unionName}\\s+(?<target>[A-Za-z_][A-Za-z0-9_]*);[ \\t]*\\r?\\n[ \\t]*\\k<target>\\s*=\\s*\\k<source>;[ \\t]*$")
                normalized <- managedCopyPattern.Replace(normalized, MatchEvaluator(fun copyMatch ->
                    let indent = copyMatch.Groups.["indent"].Value
                    let source = copyMatch.Groups.["source"].Value
                    let target = copyMatch.Groups.["target"].Value
                    let constructorCall tag =
                        let payloadArguments =
                            payloadCases
                            |> List.map (fun (payloadTag, fieldIndex, payloadCType) ->
                                if payloadTag <> tag then defaultValue payloadCType
                                elif Regex.IsMatch(payloadCType, "^(?:String|Array[0-9]+)\\s*\\*$") then
                                    $"__spiral_clone({source}.case{tag}.v{fieldIndex})"
                                elif Regex.IsMatch(payloadCType, "^(?:bool|float|double|u?int(?:8|16|32|64)_t)$") then
                                    $"{source}.case{tag}.v{fieldIndex}"
                                else
                                    failwith $"portable managed union clone target does not support payload {payloadCType}: {unionName} tag {tag} field {fieldIndex}")
                        let allArguments = string tag :: payloadArguments
                        let joinedArguments = String.concat ", " allArguments
                        $"{tupleConstructor}({joinedArguments})"
                    let rec render = function
                        | [] -> failwith $"portable managed union clone target had no cases: {unionName}"
                        | [(tag, _)] ->
                            $"{indent}    {target} = {constructorCall tag};"
                        | (tag, _) :: tail ->
                            let nested = render tail
                            $"{indent}if ({source}.tag == {tag}) {{\n{indent}    {target} = {constructorCall tag};\n{indent}}} else {{\n{nested}\n{indent}}}"
                    $"{indent}{unionName} {target};\n{render constructors}"))
                normalized <- unionPattern.Replace(normalized, tuplePrelude, 1)
                let unionReferencePattern = Regex("(?m)(?<indent>[ \\t]*)US(?<operation>Incref|Decref)[0-9]+\\s*\\(&\\((?<variable>[A-Za-z_][A-Za-z0-9_]*)\\)\\);[ \\t]*")
                normalized <- unionReferencePattern.Replace(normalized, MatchEvaluator(fun referenceMatch ->
                    let indent = referenceMatch.Groups.["indent"].Value
                    let operation = referenceMatch.Groups.["operation"].Value
                    let variable = referenceMatch.Groups.["variable"].Value
                    let startsOnOwnLine = referenceMatch.Index = 0 || normalized.[referenceMatch.Index - 1] = '\n' || normalized.[referenceMatch.Index - 1] = '\r'
                    let prefix = if startsOnOwnLine then "" else "\n"
                    prefix + (payloadCases
                    |> List.choose (fun (tag, fieldIndex, payloadCType) ->
                        let arrayMatch = Regex.Match(payloadCType, "^Array(?<id>[0-9]+)\\s*\\*$")
                        if arrayMatch.Success then
                            let helper = if operation = "Incref" then "DynamicArrayClone" else "DynamicArrayDrop"
                            let id = arrayMatch.Groups.["id"].Value
                            Some $"{indent}if ({variable}.tag == {tag}) {{\n{indent}    {helper}{id}({variable}.case{tag}.v{fieldIndex});\n{indent}}}"
                        elif Regex.IsMatch(payloadCType, "^String\\s*\\*$") then
                            if operation = "Incref" then
                                failwith $"portable managed union string clone requires a tag-selected copy target: {unionName} tag {tag} field {fieldIndex}"
                            Some $"{indent}if ({variable}.tag == {tag}) {{\n{indent}    PortableStringDrop({variable}.case{tag}.v{fieldIndex});\n{indent}}}"
                        else None)
                    |> String.concat "\n")))
                normalized <- Regex.Replace(normalized, "\\.case(?<tag>[0-9]+)\\.v(?<field>[0-9]+)", MatchEvaluator(fun accessMatch ->
                    let tag = Int32.Parse(accessMatch.Groups.["tag"].Value)
                    let fieldIndex = Int32.Parse(accessMatch.Groups.["field"].Value)
                    let key = $"{tag}:{fieldIndex}"
                    match fieldForTag.TryGetValue key with
                    | true, field -> $".v{field}"
                    | false, _ -> failwith $"portable backend found payload access for empty union case {tag} field {fieldIndex}"))
                normalized <- normalized.Replace(".tag", ".v0", StringComparison.Ordinal)
                normalized <- Regex.Replace(normalized, $"\\b{Regex.Escape unionName}\\b", tupleName)
                normalized <- rewriteDenseUnionSwitches normalized
                if normalized.Contains("switch (", StringComparison.Ordinal) then failwith "portable backend found an unsupported union switch"
                let initializedDeclarationPattern = Regex($"^(?<indent>\\s*)(?<type>{portableAnyTypePattern})\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<expr>.+);\\s*$", RegexOptions.Multiline)
                initializedDeclarationPattern.Replace(normalized, MatchEvaluator(fun declarationMatch ->
                    let indent = declarationMatch.Groups.["indent"].Value
                    let cType = declarationMatch.Groups.["type"].Value
                    let name = declarationMatch.Groups.["name"].Value
                    let expression = declarationMatch.Groups.["expr"].Value
                    $"{indent}{cType} {name};\n{indent}{name} = {expression};"))

    let private normalizeNestedDynamicArrayC (generated : string) =
        let nestedAssignmentPattern = Regex(@"AssignArray[0-9]+\s*\(\s*&\(\s*DynamicArrayGet(?<id>[0-9]+)\(\s*(?<array>[A-Za-z_][A-Za-z0-9_]*)\s*,\s*(?<index>[^()]+?)\s*\)\s*\)\s*,\s*(?<value>[A-Za-z_][A-Za-z0-9_]*|[-+]?[0-9]+(?:\.[0-9]+)?(?:[A-Za-z]+)?)\s*\)")
        nestedAssignmentPattern.Replace(generated, MatchEvaluator(fun assignmentMatch ->
            let id = assignmentMatch.Groups.["id"].Value
            let array = assignmentMatch.Groups.["array"].Value
            let index = assignmentMatch.Groups.["index"].Value.Trim()
            let value = assignmentMatch.Groups.["value"].Value.Trim()
            $"DynamicArraySet{id}({array}, {index}, {value})"))

    let private rebindDynamicArrayHelpersByVariableType (generated : string) =
        let rewriteRefcounts = generated.Contains("->refc", StringComparison.Ordinal)
        let arrayTypes = Dictionary<string,string>(StringComparer.Ordinal)
        let declarationPattern = Regex(@"\bArray(?<id>[0-9]+)\s*\*\s*(?<name>[A-Za-z_][A-Za-z0-9_]*)")
        let helperPattern = Regex(@"\bDynamicArray(?<op>Set|Get|Len|Resize|Reserve|Capacity|RefCount|Drop)[0-9]+\(\s*(?<amp>&)?(?<var>[A-Za-z_][A-Za-z0-9_]*)")
        let decrefPattern = Regex(@"\bArrayDecref[0-9]+\(\s*(?<var>[A-Za-z_][A-Za-z0-9_]*)\s*\)")
        let cloneOnePattern = Regex(@"(?<var>[A-Za-z_][A-Za-z0-9_]*)->refc\+\+;")
        let cloneManyPattern = Regex(@"^(?<indent>\s*)(?<var>[A-Za-z_][A-Za-z0-9_]*)->refc\s*\+=\s*(?<count>[0-9]+);\s*$")
        let registerTypes (line : string) =
            for declarationMatch in declarationPattern.Matches(line) |> Seq.cast<Match> do
                arrayTypes.[declarationMatch.Groups.["name"].Value] <- declarationMatch.Groups.["id"].Value
        let rebindLine (line : string) =
            let rebound = helperPattern.Replace(line, MatchEvaluator(fun helperMatch ->
                let variable = helperMatch.Groups.["var"].Value
                match arrayTypes.TryGetValue variable with
                | true, id ->
                    let op = helperMatch.Groups.["op"].Value
                    let amp = helperMatch.Groups.["amp"].Value
                    $"DynamicArray{op}{id}({amp}{variable}"
                | false, _ -> helperMatch.Value))
            let rebound = decrefPattern.Replace(rebound, MatchEvaluator(fun decrefMatch ->
                let variable = decrefMatch.Groups.["var"].Value
                match arrayTypes.TryGetValue variable with
                | true, id -> $"DynamicArrayDrop{id}({variable})"
                | false, _ -> decrefMatch.Value))
            if not rewriteRefcounts then rebound
            else
                let manyMatch = cloneManyPattern.Match rebound
                if manyMatch.Success then
                    let variable = manyMatch.Groups.["var"].Value
                    match arrayTypes.TryGetValue variable with
                    | true, id ->
                        let indent = manyMatch.Groups.["indent"].Value
                        let count = Int32.Parse manyMatch.Groups.["count"].Value
                        [1 .. count]
                        |> List.map (fun _ -> $"{indent}DynamicArrayClone{id}({variable});")
                        |> String.concat "\n"
                    | false, _ -> rebound
                else
                    cloneOnePattern.Replace(rebound, MatchEvaluator(fun oneMatch ->
                        let variable = oneMatch.Groups.["var"].Value
                        match arrayTypes.TryGetValue variable with
                        | true, id -> $"DynamicArrayClone{id}({variable});"
                        | false, _ -> oneMatch.Value))
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let output = StringBuilder()
        let mutable topLevelDepth = 0
        let mutable functionDepth = 0
        let mutable inFunction = false
        for line in generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None) do
            let trimmed = line.Trim()
            let opens = countCharacter '{' line
            let closes = countCharacter '}' line
            if not inFunction && topLevelDepth = 0 && trimmed.Contains("(", StringComparison.Ordinal) && trimmed.EndsWith("{", StringComparison.Ordinal) then
                inFunction <- true
                functionDepth <- opens - closes
                arrayTypes.Clear()
                registerTypes line
                output.AppendLine(rebindLine line) |> ignore
                if functionDepth = 0 then inFunction <- false
            elif inFunction then
                registerTypes line
                output.AppendLine(rebindLine line) |> ignore
                functionDepth <- functionDepth + opens - closes
                if functionDepth = 0 then
                    inFunction <- false
                    arrayTypes.Clear()
            else
                output.AppendLine(line) |> ignore
                topLevelDepth <- topLevelDepth + opens - closes
        output.ToString()

    let private removeRustManagedTupleDropBlocks (generated : string) =
        let pattern = Regex(@"(?m)^(?<indent>[ \t]*)if\s+(?<tuple>[A-Za-z_][A-Za-z0-9_]*)\.v0\s*==\s*[0-9]+\s*\{\r?\n[ \t]+DynamicArrayDrop[0-9]+\(&\k<tuple>\.(?<field>v[0-9]+)\);\r?\n[ \t]*\}\r?\n")
        pattern.Replace(generated, MatchEvaluator(fun dropMatch ->
            let indent = dropMatch.Groups.["indent"].Value
            let tupleName = dropMatch.Groups.["tuple"].Value
            let fieldName = dropMatch.Groups.["field"].Value
            $"{indent}drop({tupleName}.{fieldName});\n"))

    let private normalizeRustStringNullDefaults (generated : string) =
        Regex.Replace(generated, @"\bNULL\b", "Rc::<str>::from(\"\")")

    let private removeRustCopyScalarClones (generated : string) =
        let scalarVariablePattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*(?:i8|i16|i32|i64|u8|u16|u32|u64|f32|f64|bool)\b")
        let clonePattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*)\.clone\(\)")
        let functionStartPattern = Regex(@"^\s*(?:pub\s+)?(?:unsafe\s+)?(?:extern\s+""C""\s+)?fn\s+")
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let processFunction (lines : string array) =
            let scalarVariables =
                lines
                |> Array.collect (fun line -> scalarVariablePattern.Matches(line) |> Seq.cast<Match> |> Seq.toArray)
                |> Array.map (fun scalarMatch -> scalarMatch.Groups.["name"].Value)
                |> Set.ofArray
            if Set.isEmpty scalarVariables then lines
            else
                lines
                |> Array.map (fun line ->
                    clonePattern.Replace(line, MatchEvaluator(fun cloneMatch ->
                        let name = cloneMatch.Groups.["name"].Value
                        if Set.contains name scalarVariables then name else cloneMatch.Value)))
        let input = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let output = ResizeArray<string>()
        let current = ResizeArray<string>()
        let mutable inFunction = false
        let mutable depth = 0
        for line in input do
            if not inFunction && functionStartPattern.IsMatch(line) then
                inFunction <- true
                depth <- countCharacter '{' line - countCharacter '}' line
                current.Clear()
                current.Add line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            elif inFunction then
                current.Add line
                depth <- depth + countCharacter '{' line - countCharacter '}' line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            else output.Add line
        if inFunction then failwith "portable Rust scalar-clone cleanup found an unterminated function"
        String.Join("\n", output)

    let private splitRustCallArgumentsPreservingStrings (text : string) =
        let values = ResizeArray<string>()
        let current = StringBuilder()
        let mutable inString = false
        let mutable escaped = false
        for ch in text do
            if inString then
                current.Append(ch) |> ignore
                if escaped then escaped <- false
                elif ch = '\\' then escaped <- true
                elif ch = '"' then inString <- false
            elif ch = '"' then
                inString <- true
                current.Append(ch) |> ignore
            elif ch = ',' then
                values.Add(current.ToString().Trim())
                current.Clear() |> ignore
            else
                current.Append(ch) |> ignore
        if inString then failwith $"portable Rust call argument splitter found an unterminated string literal: {text}"
        values.Add(current.ToString().Trim())
        values.ToArray()

    let private cloneRustManagedStringArguments (generated : string) =
        let stringVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Rc<str>")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        if Set.isEmpty stringVariables then generated
        else
            let callPattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*)\((?<args>(?:[^()""\r\n]|""(?:\\.|[^""\\])*"")*)\)")
            callPattern.Replace(generated, MatchEvaluator(fun callMatch ->
                let name = callMatch.Groups.["name"].Value
                if name = "drop" || name = "new" then callMatch.Value
                else
                    let arguments =
                        splitRustCallArgumentsPreservingStrings callMatch.Groups.["args"].Value
                        |> Array.map (fun argument ->
                            let trimmed = argument.Trim()
                            if Set.contains trimmed stringVariables && not (trimmed.EndsWith(".clone()", StringComparison.Ordinal)) then trimmed + ".clone()"
                            else trimmed)
                        |> String.concat ", "
                    name + "(" + arguments + ")"))

    let private cloneRustDynamicArrayArguments (generated : string) =
        let arrayVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Array[0-9]+\b")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        if Set.isEmpty arrayVariables then generated
        else
            let methodCallPattern = Regex(@"\b(?<name>method[0-9]+)\((?<args>[^()\r\n]*)\)")
            let calls = methodCallPattern.Matches(generated) |> Seq.cast<Match> |> Seq.toArray
            let useCounts =
                arrayVariables
                |> Seq.map (fun variable ->
                    let methodCount =
                        calls
                        |> Array.sumBy (fun callMatch ->
                            callMatch.Groups.["args"].Value.Split(',')
                            |> Array.sumBy (fun argument -> if argument.Trim() = variable then 1 else 0))
                    let dropCount = Regex.Matches(generated, $@"\bDynamicArrayDrop[0-9]+\(\s*&{Regex.Escape variable}\s*\)").Count
                    variable, methodCount + dropCount)
                |> Map.ofSeq
            methodCallPattern.Replace(generated, MatchEvaluator(fun callMatch ->
                let methodName = callMatch.Groups.["name"].Value
                let arguments =
                    callMatch.Groups.["args"].Value.Split(',')
                    |> Array.map (fun argument ->
                        let trimmed = argument.Trim()
                        let count = Map.tryFind trimmed useCounts |> Option.defaultValue 0
                        if count > 1 then trimmed + ".clone()" else trimmed)
                methodName + "(" + String.concat ", " arguments + ")"))

    let private cloneRustRepeatedClosureArguments (generated : string) =
        let closureVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*ClosureValue[0-9]+\b")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        if Set.isEmpty closureVariables then generated
        else
            let callPattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*)\((?<args>(?:[^()\r\n]|\.clone\(\))*)\)")
            let calls = callPattern.Matches(generated) |> Seq.cast<Match> |> Seq.toArray
            let useCounts =
                closureVariables
                |> Seq.map (fun variable ->
                    let count =
                        calls
                        |> Array.sumBy (fun callMatch ->
                            let callName = callMatch.Groups.["name"].Value
                            if callName.StartsWith("ClosureValueCreate", StringComparison.Ordinal)
                               || callName.StartsWith("ClosureValueDrop", StringComparison.Ordinal)
                               || callName = "drop" then 0
                            else
                                callMatch.Groups.["args"].Value.Split(',')
                                |> Array.sumBy (fun argument -> if argument.Trim() = variable then 1 else 0))
                    variable, count)
                |> Map.ofSeq
            callPattern.Replace(generated, MatchEvaluator(fun callMatch ->
                let callName = callMatch.Groups.["name"].Value
                if callName.StartsWith("ClosureValueCreate", StringComparison.Ordinal)
                   || callName.StartsWith("ClosureValueDrop", StringComparison.Ordinal)
                   || callName = "drop" then callMatch.Value
                else
                    let arguments =
                        callMatch.Groups.["args"].Value.Split(',')
                        |> Array.map (fun argument ->
                            let trimmed = argument.Trim()
                            let count = Map.tryFind trimmed useCounts |> Option.defaultValue 0
                            if count > 1 && Set.contains trimmed closureVariables then trimmed + ".clone()" else trimmed)
                        |> String.concat ", "
                    callName + "(" + arguments + ")"))

    let private cloneRustLayoutArrayCalls (generated : string) =
        let managedVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*(?:Array[0-9]+|Recursive[0-9]+|Option<Recursive[0-9]+>|Tuple[0-9]+|Weak<Recursive[0-9]+Node>|Rc<str>)(?=\s*[;=])")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        if Set.isEmpty managedVariables then generated
        else
            let callPattern = Regex(@"\b(?<name>(?:(?:Heap|Mut)Create[0-9]+|MutAssign[0-9]+))\((?<args>(?:[^()\r\n]|\.clone\(\))*)\)")
            callPattern.Replace(generated, MatchEvaluator(fun callMatch ->
                let arguments =
                    callMatch.Groups.["args"].Value.Split(',')
                    |> Array.map (fun argument ->
                        let trimmed = argument.Trim()
                        if Set.contains trimmed managedVariables && not (trimmed.EndsWith(".clone()", StringComparison.Ordinal)) then trimmed + ".clone()" else trimmed)
                    |> String.concat ", "
                callMatch.Groups.["name"].Value + "(" + arguments + ")"))

    let private cloneRustNestedArrayStoreValues (generated : string) =
        let managedVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Array[0-9]+\b")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        if Set.isEmpty managedVariables then generated
        else
            let setPattern = Regex(@"\bDynamicArraySet(?<id>[0-9]+)\((?<array>&?[A-Za-z_][A-Za-z0-9_]*),\s*(?<index>[^,\r\n]+),\s*(?<value>[A-Za-z_][A-Za-z0-9_]*)\)")
            setPattern.Replace(generated, MatchEvaluator(fun setMatch ->
                let value = setMatch.Groups.["value"].Value
                if Set.contains value managedVariables then
                    let id = setMatch.Groups.["id"].Value
                    let array = setMatch.Groups.["array"].Value
                    let index = setMatch.Groups.["index"].Value.Trim()
                    $"DynamicArraySet{id}({array}, {index}, {value}.clone())"
                else setMatch.Value))

    let private cloneRustRepeatedManagedConstructorArguments (generated : string) =
        let arrayVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Array[0-9]+\b")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        let optionVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Option<Recursive[0-9]+>\b")
            |> Seq.cast<Match>
            |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
            |> Set.ofSeq
        let managedVariables = Set.union arrayVariables optionVariables
        if Set.isEmpty managedVariables then generated
        else
            let constructorPattern = Regex(@"\b(?<name>(?:TupleCreate[0-9]+|ClosureValueCreate[0-9]+|RecursiveCreate[0-9]+_[0-9]+|(?:Heap|Mut)Create[0-9]+|MutAssign[0-9]+))\((?<args>[^()\r\n]*)\)")
            let calls = constructorPattern.Matches(generated) |> Seq.cast<Match> |> Seq.toArray
            let useCounts =
                managedVariables
                |> Seq.map (fun variable ->
                    let methodCount =
                        calls
                        |> Array.sumBy (fun callMatch ->
                            callMatch.Groups.["args"].Value.Split(',')
                            |> Array.sumBy (fun argument -> if argument.Trim() = variable then 1 else 0))
                    let dropCount = Regex.Matches(generated, $@"\bDynamicArrayDrop[0-9]+\(\s*&{Regex.Escape variable}\s*\)").Count
                    variable, methodCount + dropCount)
                |> Map.ofSeq
            constructorPattern.Replace(generated, MatchEvaluator(fun constructorMatch ->
                let name = constructorMatch.Groups.["name"].Value
                let isLayoutCall = name.StartsWith("HeapCreate", StringComparison.Ordinal) || name.StartsWith("MutCreate", StringComparison.Ordinal) || name.StartsWith("MutAssign", StringComparison.Ordinal)
                let arguments =
                    constructorMatch.Groups.["args"].Value.Split(',')
                    |> Array.map (fun argument ->
                        let trimmed = argument.Trim()
                        let count = Map.tryFind trimmed useCounts |> Option.defaultValue 0
                        if Set.contains trimmed optionVariables || count > 1 || (isLayoutCall && Set.contains trimmed arrayVariables) then trimmed + ".clone()" else trimmed)
                    |> String.concat ", "
                name + "(" + arguments + ")"))

    let private cloneRustManagedConstructorValuesBeforeDrop (generated : string) =
        let constructorThenDrop = Regex(@"(?<name>(?:TupleCreate|ClosureValueCreate)[0-9]+)\((?<args>[^;\r\n]*)\)(?<separator>;\s*\r?\n\s*)DynamicArrayDrop(?<dropId>[0-9]+)\(&(?<var>[A-Za-z_][A-Za-z0-9_]*)\);")
        constructorThenDrop.Replace(generated, MatchEvaluator(fun constructorMatch ->
            let variable = constructorMatch.Groups.["var"].Value
            let arguments =
                constructorMatch.Groups.["args"].Value.Split(',')
                |> Array.map (fun argument ->
                    let trimmed = argument.Trim()
                    if trimmed = variable then trimmed + ".clone()" else trimmed)
                |> String.concat ", "
            let name = constructorMatch.Groups.["name"].Value
            let separator = constructorMatch.Groups.["separator"].Value
            let dropId = constructorMatch.Groups.["dropId"].Value
            $"{name}({arguments}){separator}DynamicArrayDrop{dropId}(&{variable});"))

    let private cloneRustRecursiveArguments (generated : string) =
        let normalizeArgument (argument : string) =
            let mutable value = argument.Trim()
            if value.StartsWith("&", StringComparison.Ordinal) then value <- value.Substring(1).Trim()
            if value.EndsWith(".clone()", StringComparison.Ordinal) then value <- value.Substring(0, value.Length - ".clone()".Length)
            value
        let callPattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*)\((?<args>(?:[^()\r\n]|\.clone\(\))*)\)")
        let isBorrowHelper (name : string) =
            name = "new" || Regex.IsMatch(name, "^(?:Recursive(?:Tag|Field|CaseField|Clone|Drop)|WeakRecursive(?:Downgrade|Upgrade|Clone|Drop)|DynamicArray(?:Set|Get|Len|Resize|Reserve|Capacity|RefCount|Clone|Drop))[0-9_]+$")
        let countsAsManagedUse (name : string) =
            Regex.IsMatch(name, "^(?:RecursiveDrop|WeakRecursiveDrop|DynamicArrayDrop)[0-9_]+$") || not (isBorrowHelper name)
        let processFunction (lines : string array) =
            let functionText = String.Join("\n", lines)
            let managedVariables =
                Regex.Matches(functionText, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*(?:Recursive[0-9]+|Array[0-9]+)\b")
                |> Seq.cast<Match>
                |> Seq.map (fun variableMatch -> variableMatch.Groups.["name"].Value)
                |> Set.ofSeq
            if Set.isEmpty managedVariables then lines
            else
                let calls = callPattern.Matches(functionText) |> Seq.cast<Match> |> Seq.toArray
                let useCounts =
                    managedVariables
                    |> Seq.map (fun variable ->
                        let count =
                            calls
                            |> Array.sumBy (fun callMatch ->
                                let name = callMatch.Groups.["name"].Value
                                if not (countsAsManagedUse name) then 0
                                else
                                    callMatch.Groups.["args"].Value.Split(',')
                                    |> Array.sumBy (fun argument -> if normalizeArgument argument = variable then 1 else 0))
                        variable, count)
                    |> Map.ofSeq
                callPattern.Replace(functionText, MatchEvaluator(fun callMatch ->
                    let name = callMatch.Groups.["name"].Value
                    if isBorrowHelper name then callMatch.Value
                    else
                        let arguments =
                            callMatch.Groups.["args"].Value.Split(',')
                            |> Array.map (fun argument ->
                                let trimmed = argument.Trim()
                                let normalized = normalizeArgument trimmed
                                let count = Map.tryFind normalized useCounts |> Option.defaultValue 0
                                if Set.contains normalized managedVariables && count > 1 && not (trimmed.EndsWith(".clone()", StringComparison.Ordinal)) then normalized + ".clone()"
                                else trimmed)
                            |> String.concat ", "
                        name + "(" + arguments + ")"))
                |> fun rewritten -> rewritten.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let input = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let output = ResizeArray<string>()
        let current = ResizeArray<string>()
        let mutable inFunction = false
        let mutable depth = 0
        for line in input do
            if not inFunction && line.StartsWith("fn ", StringComparison.Ordinal) && line.EndsWith("{", StringComparison.Ordinal) then
                inFunction <- true
                depth <- countCharacter '{' line - countCharacter '}' line
                current.Clear()
                current.Add line
            elif inFunction then
                current.Add line
                depth <- depth + countCharacter '{' line - countCharacter '}' line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            else output.Add line
        if inFunction then failwith "portable Rust recursive/array clone pass found an unterminated function"
        String.Join("\n", output)

    let private cloneRustManagedTupleArgumentsBeforeDrop (generated : string) =
        let tupleVariablePattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Tuple[0-9]+\b")
        let dropPattern = Regex(@"\bdrop\((?<name>[A-Za-z_][A-Za-z0-9_]*)(?:\.v[0-9]+)?\);")
        let callPattern = Regex(@"\b(?<callee>[A-Za-z_][A-Za-z0-9_]*)\((?<args>(?:[^()""\r\n]|""(?:\\.|[^""\\])*"")*)\)")
        let processFunction (lines : string array) =
            let tupleVariables =
                lines
                |> Array.collect (fun line -> tupleVariablePattern.Matches(line) |> Seq.cast<Match> |> Seq.toArray)
                |> Array.map (fun tupleMatch -> tupleMatch.Groups.["name"].Value)
                |> Set.ofArray
            let droppedVariables =
                lines
                |> Array.collect (fun line -> dropPattern.Matches(line) |> Seq.cast<Match> |> Seq.toArray)
                |> Array.map (fun dropMatch -> dropMatch.Groups.["name"].Value)
                |> Set.ofArray
            let callMatches =
                lines
                |> Array.collect (fun line -> callPattern.Matches(line) |> Seq.cast<Match> |> Seq.toArray)
            let useCounts =
                tupleVariables
                |> Seq.map (fun variable ->
                    let count =
                        callMatches
                        |> Array.sumBy (fun callMatch ->
                            let callee = callMatch.Groups.["callee"].Value
                            if callee = "drop" || callee.StartsWith("TupleCreate", StringComparison.Ordinal) then 0
                            else
                                callMatch.Groups.["args"].Value.Split(',')
                                |> Array.sumBy (fun argument -> if argument.Trim() = variable then 1 else 0))
                    variable, count)
                |> Map.ofSeq
            lines
            |> Array.map (fun line ->
                callPattern.Replace(line, MatchEvaluator(fun callMatch ->
                    let callee = callMatch.Groups.["callee"].Value
                    if callee = "drop" || callee.StartsWith("TupleCreate", StringComparison.Ordinal) then callMatch.Value
                    else
                        let arguments =
                            splitRustCallArgumentsPreservingStrings callMatch.Groups.["args"].Value
                            |> Array.map (fun argument ->
                                let trimmed = argument.Trim()
                                let count = Map.tryFind trimmed useCounts |> Option.defaultValue 0
                                if Set.contains trimmed tupleVariables && (Set.contains trimmed droppedVariables || count > 1) && not (trimmed.EndsWith(".clone()", StringComparison.Ordinal)) then trimmed + ".clone()"
                                else trimmed)
                            |> String.concat ", "
                        $"{callee}({arguments})")))
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let input = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let output = ResizeArray<string>()
        let current = ResizeArray<string>()
        let mutable inFunction = false
        let mutable depth = 0
        for line in input do
            if not inFunction && line.StartsWith("fn ", StringComparison.Ordinal) && line.EndsWith("{", StringComparison.Ordinal) then
                inFunction <- true
                depth <- countCharacter '{' line - countCharacter '}' line
                current.Clear()
                current.Add line
            elif inFunction then
                current.Add line
                depth <- depth + countCharacter '{' line - countCharacter '}' line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            else output.Add line
        if inFunction then failwith "portable Rust tuple-clone pass found an unterminated function"
        String.Join("\n", output)

    let private moveRustSingleUseManagedTupleFields (generated : string) =
        let tupleVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Tuple[0-9]+\b")
            |> Seq.cast<Match>
            |> Seq.map (fun tupleMatch -> tupleMatch.Groups.["name"].Value)
            |> Set.ofSeq
        let unionTupleVariables =
            Regex.Matches(generated, @"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*Tuple9[0-9]{3}\b")
            |> Seq.cast<Match>
            |> Seq.map (fun tupleMatch -> tupleMatch.Groups.["name"].Value)
            |> Set.ofSeq
        let fieldClonePattern = Regex(@"\b(?<tuple>[A-Za-z_][A-Za-z0-9_]*)\.(?<field>v[0-9]+)\.clone\(\)")
        fieldClonePattern.Replace(generated, MatchEvaluator(fun fieldMatch ->
            let tupleName = fieldMatch.Groups.["tuple"].Value
            let fieldName = fieldMatch.Groups.["field"].Value
            let usePattern = Regex($@"\b{Regex.Escape tupleName}\.{Regex.Escape fieldName}\b")
            if Set.contains tupleName tupleVariables && not (Set.contains tupleName unionTupleVariables) && usePattern.Matches(generated).Count = 1 then $"{tupleName}.{fieldName}"
            else fieldMatch.Value))

    // An assignment `slot = value;` moves an Rc. Later uses of `value` then fail
    // borrowck. Call-argument cloning does not see this shape. Clone when the
    // source binding is an Rc used more than once in the same function.
    let private removeRustMismatchedRecursiveClones (generated : string) =
        let declarationPattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*(?<type>Recursive[0-9]+|Rc<str>)(?=\s*[,)=;])")
        let clonePattern = Regex(@"^(?<indent>[ \t]*)RecursiveClone(?<id>[0-9]+)\(&(?<name>[A-Za-z_][A-Za-z0-9_]*)\);\s*$")
        let processFunction (lines : string array) =
            let types =
                lines
                |> Array.collect (fun line -> declarationPattern.Matches(line) |> Seq.cast<Match> |> Seq.toArray)
                |> Array.fold (fun acc item -> Map.add item.Groups.["name"].Value item.Groups.["type"].Value acc) Map.empty
            lines
            |> Array.map (fun line ->
                let cloneMatch = clonePattern.Match(line)
                if not cloneMatch.Success then line
                else
                    let name = cloneMatch.Groups.["name"].Value
                    let id = cloneMatch.Groups.["id"].Value
                    match Map.tryFind name types with
                    | Some cType when cType = "Recursive" + id -> line
                    | _ -> "")
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let input = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let output = ResizeArray<string>()
        let current = ResizeArray<string>()
        let mutable inFunction = false
        let mutable depth = 0
        for line in input do
            if not inFunction && line.StartsWith("fn ", StringComparison.Ordinal) && line.EndsWith("{", StringComparison.Ordinal) then
                inFunction <- true
                depth <- countCharacter '{' line - countCharacter '}' line
                current.Clear()
                current.Add line
            elif inFunction then
                current.Add line
                depth <- depth + countCharacter '{' line - countCharacter '}' line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            else output.Add line
        if inFunction then failwith "portable Rust recursive-clone cleanup found an unterminated function"
        String.Join("\n", output)

    let private cloneRustMultiUseManagedMoves (generated : string) =
        let managedPattern = Regex(@"\b(?<name>[A-Za-z_][A-Za-z0-9_]*):\s*(?:Rc<str>|Recursive[0-9]+)(?=\s*[,)=;])")
        let movePattern = Regex(@"^(?<prefix>[ \t]*(?:let\s+(?:mut\s+)?[A-Za-z_][A-Za-z0-9_]*(?:\s*:\s*[^=\r\n]+)?\s*=\s*|[A-Za-z_][A-Za-z0-9_]*\s*=\s*))(?<src>[A-Za-z_][A-Za-z0-9_]*)\s*;\s*$")
        let processFunction (lines : string array) =
            let managed =
                lines
                |> Array.collect (fun line -> managedPattern.Matches(line) |> Seq.cast<Match> |> Seq.toArray)
                |> Array.map (fun item -> item.Groups.["name"].Value)
                |> Set.ofArray
            if Set.isEmpty managed then lines
            else
                let text = String.Join("\n", lines)
                lines
                |> Array.map (fun line ->
                    let moveMatch = movePattern.Match(line)
                    if not moveMatch.Success then line
                    else
                        let src = moveMatch.Groups.["src"].Value
                        if not (Set.contains src managed) then line
                        else
                            let mentions = Regex.Matches(text, $@"\b{Regex.Escape src}\b").Count
                            let declarations = Regex.Matches(text, $@"\b{Regex.Escape src}\s*:\s*(?:Rc<str>|Recursive[0-9]+)(?=\s*[,)=;])").Count
                            let uses = mentions - declarations
                            if uses > 1 then moveMatch.Groups.["prefix"].Value + src + ".clone();"
                            else line)
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let input = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let output = ResizeArray<string>()
        let current = ResizeArray<string>()
        let mutable inFunction = false
        let mutable depth = 0
        for line in input do
            if not inFunction && line.StartsWith("fn ", StringComparison.Ordinal) && line.EndsWith("{", StringComparison.Ordinal) then
                inFunction <- true
                depth <- countCharacter '{' line - countCharacter '}' line
                current.Clear()
                current.Add line
            elif inFunction then
                current.Add line
                depth <- depth + countCharacter '{' line - countCharacter '}' line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            else output.Add line
        if inFunction then failwith "portable Rust managed-move clone pass found an unterminated function"
        String.Join("\n", output)

    let private moveRustTailCallArguments (generated : string) =
        let returnCallPattern = Regex(@"(?m)^(?<indent>[ \t]*)return (?<name>method[0-9]+)\((?<args>[^\r\n]*)\);$")
        returnCallPattern.Replace(generated, MatchEvaluator(fun returnMatch ->
            let arguments =
                returnMatch.Groups.["args"].Value.Split(',')
                |> Array.map (fun argument ->
                    let trimmed = argument.Trim()
                    if trimmed.EndsWith(".clone()", StringComparison.Ordinal) then trimmed.Substring(0, trimmed.Length - ".clone()".Length)
                    else trimmed)
                |> String.concat ", "
            let indent = returnMatch.Groups.["indent"].Value
            let name = returnMatch.Groups.["name"].Value
            $"{indent}return {name}({arguments});"))

    let private consumeRustTerminalManagedDrops (generated : string) =
        let dropPattern = Regex(@"^(?<indent>[ \t]*)(?:DynamicArray|Recursive)Drop[0-9]+\(&(?<var>[A-Za-z_][A-Za-z0-9_]*)\);$")
        let variableUsed variable (lines : string array) fromIndex =
            let pattern = Regex($@"\b{Regex.Escape variable}\b")
            lines
            |> Array.skip fromIndex
            |> Array.exists pattern.IsMatch
        let processFunction (lines : string array) =
            lines
            |> Array.mapi (fun index line ->
                let dropMatch = dropPattern.Match line
                if dropMatch.Success then
                    let variable = dropMatch.Groups.["var"].Value
                    if variableUsed variable lines (index + 1) then line
                    else
                        let indent = dropMatch.Groups.["indent"].Value
                        $"{indent}drop({variable});"
                else line)
        let countCharacter character (line : string) = line |> Seq.sumBy (fun value -> if value = character then 1 else 0)
        let input = generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
        let output = ResizeArray<string>()
        let current = ResizeArray<string>()
        let mutable inFunction = false
        let mutable depth = 0
        for line in input do
            if not inFunction && line.StartsWith("fn ", StringComparison.Ordinal) && line.EndsWith("{", StringComparison.Ordinal) then
                inFunction <- true
                depth <- countCharacter '{' line - countCharacter '}' line
                current.Clear()
                current.Add line
            elif inFunction then
                current.Add line
                depth <- depth + countCharacter '{' line - countCharacter '}' line
                if depth = 0 then
                    for processed in processFunction (current.ToArray()) do output.Add processed
                    current.Clear()
                    inFunction <- false
            else output.Add line
        if inFunction then failwith "portable Rust managed terminal-drop pass found an unterminated function"
        String.Join("\n", output)

    type private PortableTargetGlobalPosition =
        | TargetPrelude
        | TargetBeforeMain
        | TargetAfterMain

    type private PortableTargetGlobalItem = {
        Position : PortableTargetGlobalPosition
        Identity : string
        Payload : string
        }

    type private PortableItemMetadataKind =
        | ItemTest

    type private PortableItemMetadata = {
        Identity : string
        Kind : PortableItemMetadataKind
        }

    let private portableTargetGlobalCallPattern =
        Regex(@"(?ms)^[ \t]*String \* (?<variable>v[0-9]+);\s*^\s*\k<variable> = StringLit\(\d+,\s*""SPIRAL_TARGET_GLOBAL_(?<target>[A-Za-z0-9]+)(?:_(?<position>PRELUDE|BEFORE_MAIN|AFTER_MAIN)_(?<identity>[A-Za-z0-9][A-Za-z0-9-]*))?_B64:(?<payload>[A-Za-z0-9+/=]+)""\);(?:(?:\s*^\s*\k<variable>->refc\+\+;\s*^\s*target_global[0-9]+\(\k<variable>\);)+)\s*^\s*StringDecref\(\k<variable>\);")

    let private portableItemMetadataCallPattern =
        Regex(@"(?ms)^[ \t]*String \* (?<variable>v[0-9]+);\s*^\s*\k<variable> = StringLit\(\d+,\s*""SPIRAL_ITEM_METADATA_(?<kind>TEST)_(?<identity>[A-Za-z0-9][A-Za-z0-9-]*)""\);(?:(?:\s*^\s*\k<variable>->refc\+\+;\s*^\s*target_global[0-9]+\(\k<variable>\);)+)\s*^\s*StringDecref\(\k<variable>\);")

    let private portableTargetGlobalHelperPattern =
        Regex(@"(?ms)^void target_global[0-9]+\(String \* v[0-9]+\)\{\s*.*?^\}\s*")

    let private parsePortableTargetGlobalPosition target value =
        match value with
        | "" | "AFTER_MAIN" -> TargetAfterMain
        | "PRELUDE" -> TargetPrelude
        | "BEFORE_MAIN" -> TargetBeforeMain
        | invalid -> failwith $"portable target global for {target} has invalid position: {invalid}"

    let private extractPortableTargetGlobals target (generated : string) =
        let items = Dictionary<string,PortableTargetGlobalItem>(StringComparer.Ordinal)
        let order = ResizeArray<string>()
        let metadata = Dictionary<string,PortableItemMetadata>(StringComparer.Ordinal)
        let metadataOrder = ResizeArray<string>()
        let mutable foundTransport = false
        let cleaned =
            portableTargetGlobalCallPattern.Replace(generated, MatchEvaluator(fun marker ->
                foundTransport <- true
                let markerTarget = marker.Groups.["target"].Value.ToUpperInvariant()
                if markerTarget <> "RUST" && markerTarget <> "DELPHI" then
                    failwith $"portable target global has unsupported target: {markerTarget}"
                if String.Equals(markerTarget, target, StringComparison.OrdinalIgnoreCase) then
                    let encoded = marker.Groups.["payload"].Value
                    let decoded =
                        try Encoding.UTF8.GetString(Convert.FromBase64String(encoded)).TrimEnd()
                        with :? FormatException as error ->
                            failwith $"portable target global for {target} has invalid base64: {error.Message}"
                    if String.IsNullOrWhiteSpace decoded then
                        failwith $"portable target global for {target} decoded to an empty item"
                    let position = parsePortableTargetGlobalPosition target marker.Groups.["position"].Value
                    let identity =
                        let explicitIdentity = marker.Groups.["identity"].Value
                        if String.IsNullOrWhiteSpace explicitIdentity then "legacy-" + encoded else explicitIdentity
                    let item = { Position = position; Identity = identity; Payload = decoded }
                    match items.TryGetValue identity with
                    | true, existing when existing = item -> ()
                    | true, _ -> failwith $"portable target global identity '{identity}' has conflicting declarations for {target}"
                    | false, _ ->
                        items.Add(identity, item)
                        order.Add identity
                ""))
        let cleaned =
            portableItemMetadataCallPattern.Replace(cleaned, MatchEvaluator(fun marker ->
                foundTransport <- true
                let identity = marker.Groups.["identity"].Value
                let kind =
                    match marker.Groups.["kind"].Value with
                    | "TEST" -> ItemTest
                    | invalid -> failwith $"portable item metadata has unsupported kind: {invalid}"
                let item = { Identity = identity; Kind = kind }
                match metadata.TryGetValue identity with
                | true, existing when existing = item -> ()
                | true, _ -> failwith $"portable item metadata identity '{identity}' has conflicting declarations"
                | false, _ ->
                    metadata.Add(identity, item)
                    metadataOrder.Add identity
                ""))
        let cleaned = if foundTransport then portableTargetGlobalHelperPattern.Replace(cleaned, "") else cleaned
        let orderedItems = order |> Seq.map (fun identity -> items.[identity]) |> Seq.toList
        let orderedMetadata = metadataOrder |> Seq.map (fun identity -> metadata.[identity]) |> Seq.toList
        let itemIdentities = orderedItems |> List.map (fun item -> item.Identity) |> Set.ofList
        for itemMetadata in orderedMetadata do
            if not (Set.contains itemMetadata.Identity itemIdentities) then
                failwith $"portable item metadata identity '{itemMetadata.Identity}' has no matching target item for {target}"
        cleaned, orderedItems, orderedMetadata

    let private projectPortableItemMetadata (target : string) (metadata : PortableItemMetadata list) (item : PortableTargetGlobalItem) =
        let itemMetadata = metadata |> List.filter (fun value -> value.Identity = item.Identity)
        let prefixes =
            itemMetadata
            |> List.map (fun value ->
                match target.ToUpperInvariant(), value.Kind with
                | "RUST", ItemTest -> "#[test]"
                | "DELPHI", ItemTest -> "// spiral-item-metadata: test"
                | invalid, _ -> failwith $"portable item metadata has unsupported target: {invalid}")
        match prefixes with
        | [] -> item.Payload
        | _ -> String.concat "\n" prefixes + "\n" + item.Payload

    let private renderPortableTargetGlobals (target : string) position (metadata : PortableItemMetadata list) (items : PortableTargetGlobalItem list) =
        items
        |> List.filter (fun item -> item.Position = position)
        |> List.map (projectPortableItemMetadata target metadata)
        |> String.concat ("\n" + "\n")

    let private insertPortablePayloadBefore (marker : string) (failure : string) (payload : string) (generated : string) =
        if String.IsNullOrWhiteSpace payload then generated
        else
            let insertionPoint = generated.IndexOf(marker, StringComparison.Ordinal)
            if insertionPoint < 0 then failwith failure
            generated.Insert(insertionPoint, payload + "\n" + "\n")

    let private appendRustTargetGlobals metadata items (generated : string) =
        let prelude = renderPortableTargetGlobals "RUST" TargetPrelude metadata items
        let beforeMain = renderPortableTargetGlobals "RUST" TargetBeforeMain metadata items
        let afterMain = renderPortableTargetGlobals "RUST" TargetAfterMain metadata items
        let generated =
            if String.IsNullOrWhiteSpace prelude then generated
            else prelude + "\n" + "\n" + generated
        let generated =
            insertPortablePayloadBefore
                ("\n" + "fn main() {")
                "portable Rust target globals could not locate fn main"
                beforeMain
                generated
        if String.IsNullOrWhiteSpace afterMain then generated
        else generated.TrimEnd() + "\n" + "\n" + afterMain + "\n"

    let private appendDelphiTargetGlobals metadata items (generated : string) =
        let prelude = renderPortableTargetGlobals "DELPHI" TargetPrelude metadata items
        let beforeMain = renderPortableTargetGlobals "DELPHI" TargetBeforeMain metadata items
        let afterMain = renderPortableTargetGlobals "DELPHI" TargetAfterMain metadata items
        let generated =
            if String.IsNullOrWhiteSpace prelude then generated
            else
                let marker = "{$mode objfpc}{$H+}" + "\n"
                let insertionPoint = generated.IndexOf(marker, StringComparison.Ordinal)
                if insertionPoint < 0 then failwith "portable Delphi target globals could not locate the mode directive"
                generated.Insert(insertionPoint + marker.Length, "\n" + prelude + "\n")
        let generated =
            insertPortablePayloadBefore
                "function SpiralMain"
                "portable Delphi target globals could not locate SpiralMain"
                beforeMain
                generated
        if String.IsNullOrWhiteSpace afterMain then generated
        else
            let marker = "\n" + "begin" + "\n" + "  Halt(SpiralMain);"
            let insertionPoint = generated.LastIndexOf(marker, StringComparison.Ordinal)
            if insertionPoint < 0 then failwith "portable Delphi target globals could not locate the program entry block"
            generated.Insert(insertionPoint, "\n" + afterMain + "\n")

    type private PortableAbiValue =
        | AbiI32
        | AbiI64
        | AbiManagedUtf8Borrowed
        | AbiManagedU8BufferBorrowedConst
        | AbiManagedU8BufferBorrowedMutable
        | AbiManagedU8BufferOwned
        | AbiCallbackI32ComparatorCdecl

    type private PortableAbiCallingConvention =
        | AbiCdecl

    type private PortableAbiSignature = {
        Arguments : PortableAbiValue list
        ReturnValue : PortableAbiValue
        }

    type private PortableAbiBinding = {
        CallName : string
        Library : string
        LinkName : string
        CallingConvention : PortableAbiCallingConvention
        Signature : PortableAbiSignature
        RustItem : string
        DelphiItem : string
        }

    let private portableAbiBindings =
        [
            {
                CallName = "spiral_abi_libc_abs"
                Library = "c"
                LinkName = "abs"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiI32]; ReturnValue = AbiI32 }
                RustItem = """unsafe extern "C" {
    #[link_name = "abs"]
    fn spiral_libc_abs(value: i32) -> i32;
}

#[inline]
fn spiral_abi_libc_abs(value: i32) -> i32 {
    unsafe { spiral_libc_abs(value) }
}"""
                DelphiItem = """function spiral_libc_abs(value: LongInt): LongInt; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'abs';

function spiral_abi_libc_abs(value: LongInt): LongInt; inline;
begin
  Result := spiral_libc_abs(value);
end;"""
            }
            {
                CallName = "spiral_abi_libc_llabs"
                Library = "c"
                LinkName = "llabs"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiI64]; ReturnValue = AbiI64 }
                RustItem = """unsafe extern "C" {
    #[link_name = "llabs"]
    fn spiral_libc_llabs(value: std::ffi::c_longlong) -> std::ffi::c_longlong;
}

#[inline]
fn spiral_abi_libc_llabs(value: i64) -> i64 {
    unsafe { spiral_libc_llabs(value) }
}"""
                DelphiItem = """function spiral_libc_llabs(value: Int64): Int64; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'llabs';

function spiral_abi_libc_llabs(value: Int64): Int64; inline;
begin
  Result := spiral_libc_llabs(value);
end;"""
            }
            {
                CallName = "spiral_abi_libc_strlen"
                Library = "c"
                LinkName = "strlen"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiManagedUtf8Borrowed]; ReturnValue = AbiI32 }
                RustItem = """unsafe extern "C" {
    #[link_name = "strlen"]
    fn spiral_libc_strlen(value: *const std::ffi::c_char) -> usize;
}

#[inline]
fn spiral_abi_libc_strlen(value: Rc<str>) -> i32 {
    assert!(!value.as_bytes().contains(&0), "portable ABI borrowed UTF-8 strings cannot contain NUL bytes");
    let mut nul_terminated = Vec::with_capacity(value.len() + 1);
    nul_terminated.extend_from_slice(value.as_bytes());
    nul_terminated.push(0);
    let length = unsafe { spiral_libc_strlen(nul_terminated.as_ptr().cast()) };
    i32::try_from(length).expect("portable ABI string length exceeds i32")
}"""
                DelphiItem = """function spiral_libc_strlen(value: PAnsiChar): SizeUInt; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'strlen';

function spiral_abi_libc_strlen(const value: AnsiString): LongInt; inline;
var
  rawLength: SizeUInt;
begin
  if Pos(#0, value) <> 0 then Halt(86);
  rawLength := spiral_libc_strlen(PAnsiChar(value));
  if rawLength > SizeUInt(High(LongInt)) then Halt(87);
  Result := LongInt(rawLength);
end;"""
            }
            {
                CallName = "spiral_abi_libc_memcmp"
                Library = "c"
                LinkName = "memcmp"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiManagedU8BufferBorrowedConst; AbiManagedU8BufferBorrowedConst; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """unsafe extern "C" {
    #[link_name = "memcmp"]
    fn spiral_libc_memcmp(left: *const std::ffi::c_void, right: *const std::ffi::c_void, count: usize) -> std::ffi::c_int;
}

#[inline]
fn spiral_abi_libc_memcmp(left: std::rc::Rc<std::cell::RefCell<Vec<u8>>>, right: std::rc::Rc<std::cell::RefCell<Vec<u8>>>, count: i32) -> i32 {
    assert!(count >= 0, "portable ABI const buffer length cannot be negative");
    let count = count as usize;
    let left_data = left.borrow();
    let right_data = right.borrow();
    assert!(count <= left_data.len(), "portable ABI const buffer length exceeds left buffer");
    assert!(count <= right_data.len(), "portable ABI const buffer length exceeds right buffer");
    if count == 0 { 0 } else { unsafe { spiral_libc_memcmp(left_data.as_ptr().cast(), right_data.as_ptr().cast(), count) } }
}"""
                DelphiItem = """function spiral_libc_memcmp(leftValue: Pointer; rightValue: Pointer; count: SizeUInt): LongInt; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'memcmp';

function spiral_abi_libc_memcmp(const leftValue: Array0; const rightValue: Array0; count: LongInt): LongInt; inline;
var
  leftPointer: Pointer;
  rightPointer: Pointer;
begin
  if count < 0 then Halt(90);
  if count > Length(leftValue) then Halt(91);
  if count > Length(rightValue) then Halt(92);
  if count = 0 then Exit(0);
  leftPointer := @leftValue[0];
  rightPointer := @rightValue[0];
  Result := spiral_libc_memcmp(leftPointer, rightPointer, SizeUInt(count));
end;"""
            }
            {
                CallName = "spiral_abi_libc_memset"
                Library = "c"
                LinkName = "memset"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiManagedU8BufferBorrowedMutable; AbiI32; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """unsafe extern "C" {
    #[link_name = "memset"]
    fn spiral_libc_memset(destination: *mut std::ffi::c_void, byte_value: std::ffi::c_int, count: usize) -> *mut std::ffi::c_void;
}

#[inline]
fn spiral_abi_libc_memset(value: std::rc::Rc<std::cell::RefCell<Vec<u8>>>, byte_value: i32, count: i32) -> i32 {
    assert!(count >= 0, "portable ABI mutable buffer length cannot be negative");
    let count = count as usize;
    let mut data = value.borrow_mut();
    assert!(count <= data.len(), "portable ABI mutable buffer length exceeds buffer");
    if count != 0 {
        unsafe { spiral_libc_memset(data.as_mut_ptr().cast(), byte_value, count); }
    }
    i32::try_from(count).expect("portable ABI mutable buffer length exceeds i32")
}"""
                DelphiItem = """function spiral_libc_memset(destination: Pointer; byteValue: LongInt; count: SizeUInt): Pointer; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'memset';

function spiral_abi_libc_memset(var value: Array0; byteValue: LongInt; count: LongInt): LongInt; inline;
begin
  if count < 0 then Halt(88);
  if count > Length(value) then Halt(89);
  if count <> 0 then spiral_libc_memset(@value[0], byteValue, SizeUInt(count));
  Result := count;
end;"""
            }
            {
                CallName = "spiral_abi_libc_div_pack"
                Library = "c"
                LinkName = "div"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiI32; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """#[repr(C)]
struct SpiralLibcDivResult {
    quot: i32,
    rem: i32,
}

unsafe extern "C" {
    #[link_name = "div"]
    fn spiral_libc_div(numerator: i32, denominator: i32) -> SpiralLibcDivResult;
}

#[inline]
fn spiral_abi_libc_div_pack(numerator: i32, denominator: i32) -> i32 {
    assert!(denominator != 0, "portable ABI div denominator cannot be zero");
    let result = unsafe { spiral_libc_div(numerator, denominator) };
    result.quot.checked_mul(10).and_then(|value| value.checked_add(result.rem)).expect("portable ABI packed div result overflow")
}"""
                DelphiItem = """type
  SpiralLibcDivResult = record
    quot: LongInt;
    rem: LongInt;
  end;

function spiral_libc_div(numerator: LongInt; denominator: LongInt): SpiralLibcDivResult; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'div';

function spiral_abi_libc_div_pack(numerator: LongInt; denominator: LongInt): LongInt; inline;
var
  rawResult: SpiralLibcDivResult;
begin
  if denominator = 0 then Halt(93);
  rawResult := spiral_libc_div(numerator, denominator);
  Result := rawResult.quot * 10 + rawResult.rem;
end;"""
            }
            {
                CallName = "spiral_abi_libc_lldiv_pack"
                Library = "c"
                LinkName = "lldiv"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiI64; AbiI64]; ReturnValue = AbiI64 }
                RustItem = """#[repr(C)]
struct SpiralLibcLldivResult {
    quot: std::ffi::c_longlong,
    rem: std::ffi::c_longlong,
}

unsafe extern "C" {
    #[link_name = "lldiv"]
    fn spiral_libc_lldiv(numerator: std::ffi::c_longlong, denominator: std::ffi::c_longlong) -> SpiralLibcLldivResult;
}

#[inline]
fn spiral_abi_libc_lldiv_pack(numerator: i64, denominator: i64) -> i64 {
    assert!(denominator != 0, "portable ABI lldiv denominator cannot be zero");
    assert_eq!(std::mem::size_of::<SpiralLibcLldivResult>(), 2 * std::mem::size_of::<std::ffi::c_longlong>(), "portable ABI lldiv aggregate size mismatch");
    assert_eq!(std::mem::align_of::<SpiralLibcLldivResult>(), std::mem::align_of::<std::ffi::c_longlong>(), "portable ABI lldiv aggregate alignment mismatch");
    let result = unsafe { spiral_libc_lldiv(numerator, denominator) };
    result.quot
        .checked_mul(denominator)
        .and_then(|value| value.checked_add(result.rem))
        .expect("portable ABI packed lldiv result overflow")
}"""
                DelphiItem = """type
  SpiralLibcLldivResult = record
    quot: Int64;
    rem: Int64;
  end;

function spiral_libc_lldiv(numerator: Int64; denominator: Int64): SpiralLibcLldivResult; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'lldiv';

function spiral_abi_libc_lldiv_pack(numerator: Int64; denominator: Int64): Int64; inline;
var
  rawResult: SpiralLibcLldivResult;
begin
  if denominator = 0 then Halt(97);
  if SizeOf(SpiralLibcLldivResult) <> 2 * SizeOf(Int64) then Halt(98);
  rawResult := spiral_libc_lldiv(numerator, denominator);
  Result := rawResult.quot * denominator + rawResult.rem;
end;"""
            }
            {
                CallName = "spiral_abi_libm_cabs_pack"
                Library = "m"
                LinkName = "cabs"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiI32; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """#[repr(C)]
struct SpiralLibmComplex64 {
    re: f64,
    im: f64,
}

#[link(name = "m")]
unsafe extern "C" {
    #[link_name = "cabs"]
    fn spiral_libm_cabs(value: SpiralLibmComplex64) -> f64;
}

#[inline]
fn spiral_abi_libm_cabs_pack(real: i32, imaginary: i32) -> i32 {
    let value = SpiralLibmComplex64 { re: f64::from(real), im: f64::from(imaginary) };
    let magnitude = unsafe { spiral_libm_cabs(value) };
    assert!(magnitude.is_finite(), "portable ABI complex magnitude is not finite");
    assert!(magnitude >= f64::from(i32::MIN) && magnitude <= f64::from(i32::MAX), "portable ABI complex magnitude exceeds i32");
    assert!(magnitude.fract() == 0.0, "portable ABI complex magnitude is not integral");
    magnitude as i32
}"""
                DelphiItem = """type
  SpiralLibmComplex64 = record
    re: Double;
    im: Double;
  end;

function spiral_libm_cabs(value: SpiralLibmComplex64): Double; cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'m'{$ENDIF} name 'cabs';

function spiral_abi_libm_cabs_pack(realValue: LongInt; imaginaryValue: LongInt): LongInt; inline;
var
  value: SpiralLibmComplex64;
  magnitude: Double;
begin
  value.re := realValue;
  value.im := imaginaryValue;
  magnitude := spiral_libm_cabs(value);
  if magnitude < 0.0 then Halt(94);
  if magnitude > High(LongInt) then Halt(95);
  if magnitude <> Trunc(magnitude) then Halt(96);
  Result := Trunc(magnitude);
end;"""
            }
            {
                CallName = "spiral_abi_libc_qsort3_pack"
                Library = "c"
                LinkName = "qsort"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiI32; AbiI32; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """unsafe extern "C" fn spiral_libc_compare_i32(left: *const std::ffi::c_void, right: *const std::ffi::c_void) -> std::ffi::c_int {
    let left = unsafe { *left.cast::<i32>() };
    let right = unsafe { *right.cast::<i32>() };
    match left.cmp(&right) {
        std::cmp::Ordering::Less => -1,
        std::cmp::Ordering::Equal => 0,
        std::cmp::Ordering::Greater => 1,
    }
}

unsafe extern "C" {
    #[link_name = "qsort"]
    fn spiral_libc_qsort(
        base: *mut std::ffi::c_void,
        count: usize,
        width: usize,
        compare: Option<unsafe extern "C" fn(*const std::ffi::c_void, *const std::ffi::c_void) -> std::ffi::c_int>,
    );
}

#[inline]
fn spiral_abi_libc_qsort3_pack(first: i32, second: i32, third: i32) -> i32 {
    let mut values = [first, second, third];
    unsafe {
        spiral_libc_qsort(
            values.as_mut_ptr().cast(),
            values.len(),
            std::mem::size_of::<i32>(),
            Some(spiral_libc_compare_i32),
        );
    }
    values[0]
        .checked_mul(100)
        .and_then(|value| values[1].checked_mul(10).and_then(|middle| value.checked_add(middle)))
        .and_then(|value| value.checked_add(values[2]))
        .expect("portable ABI qsort packed result overflow")
}"""
                DelphiItem = """type
  SpiralLibcCompareI32 = function(leftValue: Pointer; rightValue: Pointer): LongInt; cdecl;

function spiral_libc_compare_i32(leftValue: Pointer; rightValue: Pointer): LongInt; cdecl;
var
  leftInteger: LongInt;
  rightInteger: LongInt;
begin
  leftInteger := PLongInt(leftValue)^;
  rightInteger := PLongInt(rightValue)^;
  if leftInteger < rightInteger then Exit(-1);
  if leftInteger > rightInteger then Exit(1);
  Result := 0;
end;

procedure spiral_libc_qsort(base: Pointer; count: SizeUInt; width: SizeUInt; compare: SpiralLibcCompareI32); cdecl; external {$IFDEF MSWINDOWS}'msvcrt'{$ELSE}'c'{$ENDIF} name 'qsort';

function spiral_abi_libc_qsort3_pack(firstValue: LongInt; secondValue: LongInt; thirdValue: LongInt): LongInt; inline;
var
  values: array[0..2] of LongInt;
begin
  values[0] := firstValue;
  values[1] := secondValue;
  values[2] := thirdValue;
  spiral_libc_qsort(@values[0], 3, SizeOf(LongInt), @spiral_libc_compare_i32);
  Result := values[0] * 100 + values[1] * 10 + values[2];
end;"""
            }
            {
                CallName = "spiral_abi_callback_dynamic"
                Library = "c"
                LinkName = "qsort"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiCallbackI32ComparatorCdecl; AbiI32; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """compile_error!("portable ABI dynamic callbacks are not implemented");"""
                DelphiItem = """{$fatal portable ABI dynamic callbacks are not implemented}"""
            }
            {
                CallName = "spiral_abi_libc_memset_owned"
                Library = "c"
                LinkName = "memset"
                CallingConvention = AbiCdecl
                Signature = { Arguments = [AbiManagedU8BufferOwned; AbiI32; AbiI32]; ReturnValue = AbiI32 }
                RustItem = """compile_error!("portable ABI owned mutable buffers are not implemented");"""
                DelphiItem = """{$fatal portable ABI owned mutable buffers are not implemented}"""
            }
        ]

    let private portableAbiCallPattern =
        Regex(@"\b(?<name>spiral_abi_[A-Za-z0-9_]+)\s*\((?<args>[^\r\n;]*)\)")

    let private portableAbiValueLabel = function
        | AbiI32 -> "i32"
        | AbiI64 -> "i64"
        | AbiManagedUtf8Borrowed -> "managed-utf8-borrowed"
        | AbiManagedU8BufferBorrowedConst -> "managed-u8-buffer-borrowed-const"
        | AbiManagedU8BufferBorrowedMutable -> "managed-u8-buffer-borrowed-mutable"
        | AbiManagedU8BufferOwned -> "managed-u8-buffer-owned"
        | AbiCallbackI32ComparatorCdecl -> "callback-i32-comparator-cdecl"

    let private validatePortableAbiBindingMetadata binding =
        if not (binding.CallName.StartsWith("spiral_abi_", StringComparison.Ordinal)) then
            failwith $"portable ABI binding name must start with spiral_abi_: {binding.CallName}"
        if String.IsNullOrWhiteSpace binding.Library then
            failwith $"portable ABI binding has no library: {binding.CallName}"
        if String.IsNullOrWhiteSpace binding.LinkName then
            failwith $"portable ABI binding has no link name: {binding.CallName}"
        match binding.CallingConvention with
        | AbiCdecl -> ()

    let private portableAbiDeclaredValues backend (generated : string) =
        let declarations = Dictionary<string,PortableAbiValue>(StringComparer.Ordinal)
        let mutableByteBufferTypes = HashSet<string>(StringComparer.Ordinal)
        let pattern =
            match backend with
            | "Rust" ->
                for matched in Regex(@"\btype\s+(?<name>Array[0-9]+)\s*=\s*Rc<RefCell<Vec<u8>>>;").Matches(generated) |> Seq.cast<Match> do
                    mutableByteBufferTypes.Add(matched.Groups.["name"].Value) |> ignore
                Regex(@"\blet\s+(?:mut\s+)?(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*:\s*(?<type>i32|i64|Rc<str>|Array[0-9]+)\s*(?:;|=)")
            | "Delphi" ->
                for matched in Regex(@"(?m)^\s*(?<name>Array[0-9]+)\s*=\s*array\s+of\s+Byte\s*;").Matches(generated) |> Seq.cast<Match> do
                    mutableByteBufferTypes.Add(matched.Groups.["name"].Value) |> ignore
                Regex(@"(?m)^\s*(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*:\s*(?<type>LongInt|Int64|AnsiString|Array[0-9]+)\s*;")
            | invalid -> failwith $"portable ABI declarations have unsupported backend: {invalid}"
        for matched in pattern.Matches(generated) |> Seq.cast<Match> do
            let name = matched.Groups.["name"].Value
            let targetType = matched.Groups.["type"].Value
            match backend, targetType with
            | "Rust", "i32"
            | "Delphi", "LongInt" -> declarations.[name] <- AbiI32
            | "Rust", "i64"
            | "Delphi", "Int64" -> declarations.[name] <- AbiI64
            | "Rust", "Rc<str>"
            | "Delphi", "AnsiString" -> declarations.[name] <- AbiManagedUtf8Borrowed
            | _, value when mutableByteBufferTypes.Contains value -> declarations.[name] <- AbiManagedU8BufferBorrowedMutable
            | _ -> ()
        declarations

    let private splitPortableAbiArguments (text : string) =
        if String.IsNullOrWhiteSpace text then []
        else text.Split(',') |> Array.map (fun value -> value.Trim()) |> Array.toList

    let private inferPortableAbiArgument backend (declarations : Dictionary<string,PortableAbiValue>) callName argumentIndex (argument : string) =
        let variable = Regex.Match(argument, @"^(?<name>[A-Za-z_][A-Za-z0-9_]*)(?:\.clone\(\))?$")
        if variable.Success then
            let name = variable.Groups.["name"].Value
            match declarations.TryGetValue name with
            | true, value -> value
            | false, _ -> failwith $"portable ABI signature validation could not resolve argument {argumentIndex + 1} '{argument}' for {callName} on {backend}"
        elif Regex.IsMatch(argument, @"^-?[0-9]+$") then AbiI32
        else failwith $"portable ABI signature validation does not support argument expression '{argument}' for {callName} on {backend}"

    let private inferPortableAbiReturn backend (declarations : Dictionary<string,PortableAbiValue>) (generated : string) (matched : Match) =
        let lineStart = generated.LastIndexOf('\n', Math.Max(0, matched.Index - 1)) + 1
        let lineEndCandidate = generated.IndexOf('\n', matched.Index)
        let lineEnd = if lineEndCandidate < 0 then generated.Length else lineEndCandidate
        let line = generated.Substring(lineStart, lineEnd - lineStart)
        let assignment =
            match backend with
            | "Rust" -> Regex.Match(line, @"^\s*(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*=")
            | "Delphi" -> Regex.Match(line, @"^\s*(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*:=")
            | invalid -> failwith $"portable ABI return validation has unsupported backend: {invalid}"
        if assignment.Success then
            let name = assignment.Groups.["name"].Value
            match declarations.TryGetValue name with
            | true, value -> value
            | false, _ -> failwith $"portable ABI signature validation could not resolve result variable '{name}' on {backend}"
        elif backend = "Rust" && line.TrimStart().StartsWith("return ", StringComparison.Ordinal) then AbiI32
        elif backend = "Delphi" && line.Contains("Exit(", StringComparison.Ordinal) then AbiI32
        else
            let callName = matched.Groups.["name"].Value
            failwith $"portable ABI signature validation could not resolve result context for {callName} on {backend}: {line.Trim()}"

    let private portableAbiValueCompatible expected actual =
        expected = actual || (expected = AbiManagedU8BufferBorrowedConst && actual = AbiManagedU8BufferBorrowedMutable)

    let private validatePortableAbiCall backend (declarations : Dictionary<string,PortableAbiValue>) (generated : string) binding (matched : Match) =
        let arguments = splitPortableAbiArguments matched.Groups.["args"].Value
        if arguments.Length <> binding.Signature.Arguments.Length then
            failwith $"portable ABI signature mismatch for {binding.CallName} on {backend}: expected {binding.Signature.Arguments.Length} arguments, got {arguments.Length}"
        List.iteri (fun index expected ->
            let actual = inferPortableAbiArgument backend declarations binding.CallName index arguments.[index]
            if not (portableAbiValueCompatible expected actual) then
                failwith $"portable ABI signature mismatch for {binding.CallName} argument {index + 1} on {backend}: expected {portableAbiValueLabel expected}, got {portableAbiValueLabel actual}") binding.Signature.Arguments
        let actualReturn = inferPortableAbiReturn backend declarations generated matched
        if actualReturn <> binding.Signature.ReturnValue then
            failwith $"portable ABI signature mismatch for {binding.CallName} return on {backend}: expected {portableAbiValueLabel binding.Signature.ReturnValue}, got {portableAbiValueLabel actualReturn}"

    let private injectPortableAbiBindings backend (generated : string) =
        let known = Dictionary<string,PortableAbiBinding>(StringComparer.Ordinal)
        for binding in portableAbiBindings do
            validatePortableAbiBindingMetadata binding
            known.Add(binding.CallName, binding)
        let declarations = portableAbiDeclaredValues backend generated
        let requested = ResizeArray<string>()
        let seen = HashSet<string>(StringComparer.Ordinal)
        for matched in portableAbiCallPattern.Matches(generated) |> Seq.cast<Match> do
            let name = matched.Groups.["name"].Value
            match known.TryGetValue name with
            | true, binding -> validatePortableAbiCall backend declarations generated binding matched
            | false, _ -> failwith $"portable ABI binding is not registered: {name}"
            if seen.Add name then requested.Add name
        if requested.Count = 0 then generated
        else
            let generated =
                if backend = "Rust" then
                    let mutable rewritten = generated
                    for name in requested do
                        let binding = known.[name]
                        match binding.Signature.Arguments with
                        | AbiManagedU8BufferBorrowedConst :: AbiManagedU8BufferBorrowedConst :: _ ->
                            let callPattern = Regex($@"\b{Regex.Escape name}\(\s*(?<left>[A-Za-z_][A-Za-z0-9_]*)\s*,\s*(?<right>[A-Za-z_][A-Za-z0-9_]*)(?<rest>\s*,)")
                            rewritten <-
                                callPattern.Replace(
                                    rewritten,
                                    MatchEvaluator(fun matched ->
                                        let left = matched.Groups.["left"].Value
                                        let right = matched.Groups.["right"].Value
                                        let rest = matched.Groups.["rest"].Value
                                        name + "(" + left + ".clone(), " + right + ".clone()" + rest))
                        | AbiManagedU8BufferBorrowedMutable :: _ ->
                            let callPattern = Regex($@"\b{Regex.Escape name}\(\s*(?<arg>[A-Za-z_][A-Za-z0-9_]*)(?<comma>\s*,)")
                            rewritten <-
                                callPattern.Replace(
                                    rewritten,
                                    MatchEvaluator(fun matched ->
                                        let argument = matched.Groups.["arg"].Value
                                        let comma = matched.Groups.["comma"].Value
                                        name + "(" + argument + ".clone()" + comma))
                        | _ -> ()
                    rewritten
                else generated
            let payloads =
                requested
                |> Seq.map (fun name ->
                    let binding = known.[name]
                    match backend with
                    | "Rust" -> binding.RustItem
                    | "Delphi" -> binding.DelphiItem
                    | invalid -> failwith $"portable ABI registry has unsupported backend: {invalid}")
                |> String.concat ("\n" + "\n")
            match backend with
            | "Rust" ->
                insertPortablePayloadBefore
                    "fn spiral_main() -> i32 {"
                    "portable Rust ABI registry could not locate spiral_main"
                    payloads
                    generated
            | "Delphi" ->
                insertPortablePayloadBefore
                    "function SpiralMain"
                    "portable Delphi ABI registry could not locate SpiralMain"
                    payloads
                    generated
            | invalid -> failwith $"portable ABI registry has unsupported backend: {invalid}"

    let private stabilizePortableClosureLifetimeC (generated : string) =
        let methodHeader = Regex("\\bClosureMethod(?<id>[0-9]+)\\s*\\(")
        let output = StringBuilder(generated.Length + 256)
        let mutable cursor = 0
        let mutable matched = methodHeader.Match(generated, cursor)
        while matched.Success do
            let openIndex = generated.IndexOf('{', matched.Index + matched.Length)
            if openIndex < 0 then failwith "portable C closure method has no opening brace"
            let closeIndex = findMatchingDelimiter generated openIndex '{' '}'
            output.Append(generated, cursor, openIndex - cursor + 1) |> ignore
            let body = generated.Substring(openIndex + 1, closeIndex - openIndex - 1)
            let suffix = matched.Groups.["id"].Value
            let marker = $"ClosureDecref{suffix}(x);"
            if body.Contains(marker, StringComparison.Ordinal) then
                let stripped = Regex.Replace(body, $"(?m)^[ \\t]*{Regex.Escape marker}[ \\t]*(?:\\r?\\n)?", "")
                let mutable inserted = false
                let rewritten =
                    Regex.Replace(
                        stripped,
                        "(?m)^(?<indent>[ \\t]*)return\\b",
                        MatchEvaluator(fun returnMatch ->
                            inserted <- true
                            let indent = returnMatch.Groups.["indent"].Value
                            indent + marker + "\n" + indent + "return"))
                let stable = Regex.Replace(rewritten, "(?m)^[ \\t]+$", "")
                if inserted then output.Append(stable) |> ignore
                else
                    output.Append(stable) |> ignore
                    output.Append("\n").Append("    ").Append(marker).Append("\n") |> ignore
            else output.Append(Regex.Replace(body, "(?m)^[ \\t]+$", "")) |> ignore
            output.Append('}') |> ignore
            cursor <- closeIndex + 1
            matched <- methodHeader.Match(generated, cursor)
        output.Append(generated, cursor, generated.Length - cursor) |> ignore
        let normalized = output.ToString().Replace("\r\n", "\n", StringComparison.Ordinal).Replace("\r", "\n", StringComparison.Ordinal)
        normalized
        |> fun text -> Regex.Replace(text, "(?m)[ \\t]+$", "")
        |> fun text -> Regex.Replace(text, "(?m)^[ \\t]*\n", "")

    let private portableDebugStage label (generated : string) =
        match Environment.GetEnvironmentVariable("SPIRAL_PORTABLE_DEBUG_DIR") with
        | null | "" -> generated
        | directory ->
            System.IO.Directory.CreateDirectory(directory) |> ignore
            System.IO.File.WriteAllText(System.IO.Path.Combine(directory, label + ".c"), generated)
            generated

    let private stabilizeDelphiClosureLifetime (generated : string) =
        let lines = ResizeArray<string>(generated.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None))
        let dropPattern = Regex("^ClosureValueDrop[0-9]+\\([A-Za-z_][A-Za-z0-9_]*\\);$")
        let mutable cursor = 0
        while cursor < lines.Count do
            if lines.[cursor].TrimStart().StartsWith("function ClosureInvoke", StringComparison.Ordinal) then
                let mutable functionEnd = cursor + 1
                while functionEnd < lines.Count && lines.[functionEnd].Trim() <> "end;" do
                    functionEnd <- functionEnd + 1
                let mutable dropIndex = -1
                let mutable exitIndex = -1
                for index = cursor + 1 to functionEnd - 1 do
                    let trimmed = lines.[index].Trim()
                    if dropIndex < 0 && dropPattern.IsMatch trimmed then dropIndex <- index
                    if trimmed.StartsWith("Exit(", StringComparison.Ordinal) then exitIndex <- index
                if dropIndex >= 0 && exitIndex >= 0 && dropIndex < exitIndex then
                    let dropLine = lines.[dropIndex]
                    lines.RemoveAt(dropIndex)
                    let adjustedExit = exitIndex - 1
                    lines.Insert(adjustedExit, dropLine)
                cursor <- functionEnd + 1
            else
                cursor <- cursor + 1
        String.concat "\n" lines

    let private rejectResidualBackendSwitchC (generated : string) =
        if generated.Contains("PortableBackendSwitch", StringComparison.Ordinal) then
            failwith "backend_switch must be resolved by Spiral codegen before portable lowering"
        generated

    let private normalizeRustUnusedImport (marker : string) (tokenPattern : string) (generated : string) =
        if not (generated.Contains(marker, StringComparison.Ordinal)) then generated
        else
            let withoutImport =
                generated
                    .Replace(marker + "\r\n\r\n", "", StringComparison.Ordinal)
                    .Replace(marker + "\n\n", "", StringComparison.Ordinal)
                    .Replace(marker + "\r\n", "", StringComparison.Ordinal)
                    .Replace(marker + "\n", "", StringComparison.Ordinal)
            if Regex.IsMatch(withoutImport, tokenPattern) then generated else withoutImport

    let private normalizeRustUnusedRcImport (generated : string) =
        normalizeRustUnusedImport "use std::rc::Rc;" @"\bRc\b" generated

    let private normalizeRustUnusedRefCellImport (generated : string) =
        normalizeRustUnusedImport "use std::cell::RefCell;" @"\bRefCell\b" generated

    let private lowerPortableGeneratedCWithClosureSurface backend (closures : PortableClosureShape list) generated =
        match backend with
        | "Rust" ->
            let generated = PortableUnionNormalizer.normalizeAllDenseUnions generated
            let rustGlobals, generated = extractPortableRustGlobalsC generated
            let generated, targetGlobals, itemMetadata = extractPortableTargetGlobals "RUST" generated
            generated |> rejectResidualBackendSwitchC |> portableDebugStage "00-generated" |> normalizeStringRuntimeC |> portableDebugStage "05-strings" |> normalizeMixedFixedScalarArraysC |> normalizeFixedScalarArrayC |> portableDebugStage "10-fixed" |> normalizeDynamicScalarArrayC |> normalizeOptionalRecursiveOwnershipC |> portableDebugStage "20-dynamic" |> normalizeNestedDynamicArrayC |> rebindDynamicArrayHelpersByVariableType |> portableDebugStage "30-arrays" |> normalizeExtendedScalarUnionC |> portableDebugStage "40-unions" |> rustFromPortableProgramC closures |> normalizeRustStringNullDefaults |> removeRustMismatchedRecursiveClones |> cloneRustManagedStringArguments |> removeRustManagedTupleDropBlocks |> cloneRustManagedTupleArgumentsBeforeDrop |> cloneRustDynamicArrayArguments |> cloneRustRepeatedClosureArguments |> cloneRustNestedArrayStoreValues |> cloneRustRepeatedManagedConstructorArguments |> cloneRustManagedConstructorValuesBeforeDrop |> cloneRustRecursiveArguments |> cloneRustMultiUseManagedMoves |> moveRustSingleUseManagedTupleFields |> moveRustTailCallArguments |> consumeRustTerminalManagedDrops |> cloneRustLayoutArrayCalls |> removeRustCopyScalarClones |> TuplePrune.apply |> injectPortableAbiBindings "Rust" |> appendRustTargetGlobals itemMetadata targetGlobals |> injectPortableRustGlobals rustGlobals |> normalizeRustUnusedRcImport
        | "Delphi" ->
            let _, generated = extractPortableRustGlobalsC generated
            let generated, targetGlobals, itemMetadata = extractPortableTargetGlobals "DELPHI" generated
            let emitted =
                generated |> rejectResidualBackendSwitchC |> portableDebugStage "00-generated" |> normalizeStringRuntimeC |> portableDebugStage "05-strings" |> normalizeMixedFixedScalarArraysC |> normalizeFixedScalarArrayC |> portableDebugStage "10-fixed" |> normalizeDynamicScalarArrayC |> normalizeOptionalRecursiveOwnershipC |> portableDebugStage "20-dynamic" |> normalizeNestedDynamicArrayC |> rebindDynamicArrayHelpersByVariableType |> portableDebugStage "30-arrays" |> normalizeExtendedScalarUnionC |> portableDebugStage "40-unions" |> delphiFromPortableProgramC closures
            let emitted =
                if closures |> List.exists (fun closure -> closure.needsManualLifetime) then stabilizeDelphiClosureLifetime emitted
                else emitted
            emitted |> injectPortableAbiBindings "Delphi" |> appendDelphiTargetGlobals itemMetadata targetGlobals
        | "C" -> stabilizePortableClosureLifetimeC generated
        | _ -> generated

    let private lowerPortableGeneratedC backend generated =
        let residual = classifyPortableClosureCaptureSurfaceC generated
        lowerPortableGeneratedCWithClosureSurface backend residual.closures generated

    let private tryLowerTypedPortableGeneratedResidual backend residual =
        match residual with
        | TypedPortableNormalizedClosureCResidual closureResidual ->
            Some(lowerPortableGeneratedCWithClosureSurface backend closureResidual.closures closureResidual.generated)
        | _ -> None

    let lowerPortableBackend backend generated =
        let closureResidual = classifyPortableClosureCaptureSurfaceC generated
        if not closureResidual.closures.IsEmpty || closureResidual.hasClosureMethods then
            match tryLowerTypedPortableGeneratedResidual backend (TypedPortableNormalizedClosureCResidual closureResidual) with
            | Some lowered -> lowered
            | None -> lowerPortableGeneratedC backend generated
        else
            lowerPortableGeneratedCWithClosureSurface backend [] generated

    let private normalizePortablePackageText (text : string) =
        text.Replace("\r\n", "\n", StringComparison.Ordinal).Replace("\r", "\n", StringComparison.Ordinal)

    let private isRustPortablePackageLocalSyntheticRoutine (source : string) (name : string) =
        Regex.IsMatch(name, "^ArrayGet[0-9]+$", RegexOptions.CultureInvariant)
        && Regex.IsMatch(source, $"(?m)^fn {Regex.Escape name}\\(index: i32, v0: ", RegexOptions.CultureInvariant)

    let private isDelphiPortablePackageLocalSyntheticRoutine (source : string) (name : string) =
        Regex.IsMatch(name, "^ArrayGet[0-9]+$", RegexOptions.CultureInvariant)
        && Regex.IsMatch(source, $"(?im)^function {Regex.Escape name}\\(index: LongInt; v0: ", RegexOptions.CultureInvariant)

    let private rustPackageLibrarySource (prefix : string) =
        let exported =
            prefix
            |> fun text -> Regex.Replace(text, "(?m)^struct ", "pub struct ")
            |> fun text ->
                Regex.Replace(text, "(?ms)^pub struct [A-Za-z_][A-Za-z0-9_]*\\s*\\{(?<body>.*?)^\\}", MatchEvaluator(fun matched ->
                    let body = Regex.Replace(matched.Groups.["body"].Value, "(?m)^(?<indent>[ \\t]+)(?<field>[A-Za-z_][A-Za-z0-9_]*):", "${indent}pub ${field}:")
                    matched.Value.Replace(matched.Groups.["body"].Value, body, StringComparison.Ordinal)))
            |> fun text -> Regex.Replace(text, "(?m)^enum ", "pub enum ")
            |> fun text -> Regex.Replace(text, "(?m)^type ", "pub type ")
            |> fun text ->
                Regex.Replace(text, "(?m)^fn (?<name>[A-Za-z_][A-Za-z0-9_]*)", MatchEvaluator(fun matched ->
                    let name = matched.Groups.["name"].Value
                    if isRustPortablePackageLocalSyntheticRoutine prefix name then matched.Value else $"pub fn {name}"))
            |> fun text -> Regex.Replace(text, "(?m)^const ", "pub const ")
            |> fun text -> Regex.Replace(text, "(?m)^static ", "pub static ")
        "#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]\n" + exported

    let private lowerRustPortablePackage (flatSource : string) =
        let text = normalizePortablePackageText flatSource
        let spiralMain = Regex.Match(text, "(?m)^fn spiral_main\\(\\) -> i32 \\{")
        if not spiralMain.Success then failwith "portable Rust package lowering requires fn spiral_main() -> i32"
        let spiralOpen = text.IndexOf('{', spiralMain.Index)
        let spiralClose = findMatchingDelimiter text spiralOpen '{' '}'
        let nativeMain = Regex("(?m)^fn main\\(\\) \\{").Match(text, spiralClose + 1)
        if not nativeMain.Success then failwith "portable Rust package lowering requires fn main()"
        let nativeOpen = text.IndexOf('{', nativeMain.Index)
        let nativeClose = findMatchingDelimiter text nativeOpen '{' '}'
        let prefix = text.Substring(0, spiralMain.Index).TrimEnd()
        let spiralBlock = text.Substring(spiralMain.Index, spiralClose - spiralMain.Index + 1)
        let nativeBlock = text.Substring(nativeMain.Index, nativeClose - nativeMain.Index + 1)
        let sharedPrelude =
            prefix.Split('\n')
            |> Array.filter (fun line ->
                let value = line.Trim()
                value.StartsWith("#![", StringComparison.Ordinal)
                || value.StartsWith("use ", StringComparison.Ordinal))
            |> String.concat "\n"
        let librarySource = rustPackageLibrarySource prefix + "\n"
        let mainSource =
            $"// Generated by Spiral portable Rust package backend.\n#![allow(unused_imports)]\n#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]\n{sharedPrelude}\nuse spiral_generated::*;\n\n{spiralBlock}\n\n{nativeBlock}\n"
        let cargoManifest =
            "[package]\nname = \"spiral_generated\"\nversion = \"0.1.0\"\nedition = \"2024\"\npublish = false\n\n[lib]\npath = \"src/lib.rs\"\n\n[[bin]]\nname = \"spiral_generated\"\npath = \"src/main.rs\"\n"
        [ "Cargo.toml", cargoManifest
          "src/lib.rs", librarySource
          "src/main.rs", mainSource ]

    let private lowerDelphiPortablePackage (flatSource : string) =
        let text = normalizePortablePackageText flatSource
        let firstNewline = text.IndexOf('\n')
        if firstNewline < 0 || not (text.StartsWith("program ", StringComparison.Ordinal)) then
            failwith "portable Delphi package lowering requires a generated program"
        let afterProgram = text.Substring(firstNewline + 1)
        let spiralMain = Regex.Match(afterProgram, "(?m)^function SpiralMain\\b")
        if not spiralMain.Success then failwith "portable Delphi package lowering requires function SpiralMain"
        let programBegin = afterProgram.LastIndexOf("\nbegin\n", StringComparison.Ordinal)
        if programBegin < spiralMain.Index then failwith "portable Delphi package lowering could not find the program body"
        let prefix = afterProgram.Substring(0, spiralMain.Index).Trim()
        let mainFunction = afterProgram.Substring(spiralMain.Index, programBegin - spiralMain.Index).TrimEnd()
        let programTail = afterProgram.Substring(programBegin + 1).Trim()
        let modeMatch = Regex.Match(prefix, "(?m)^\\{\\$mode[^\n]*\\}")
        let modeLine = if modeMatch.Success then modeMatch.Value else "{$mode objfpc}{$H+}"
        let body =
            if modeMatch.Success then prefix.Remove(modeMatch.Index, modeMatch.Length).Trim()
            else prefix
        let firstFunction = Regex.Match(body, "(?m)^(?:function|procedure)\\s+")
        if not firstFunction.Success then failwith "portable Delphi package lowering requires at least one library function"
        let declarations = body.Substring(0, firstFunction.Index).TrimEnd()
        let implementations =
            body.Substring(firstFunction.Index).Trim()
            |> fun text -> Regex.Replace(text, "(?m)^(?:function|procedure)\\s+[^\n]+;\\s*forward;\\s*\n?", "")
            |> fun text -> text.Trim()
        let signatures =
            Regex.Matches(implementations, "(?m)^(?:function|procedure)\\s+[^\n]+;$")
            |> Seq.cast<Match>
            |> Seq.map (fun matched -> matched.Value)
            |> Seq.filter (fun value -> not (value.TrimEnd().EndsWith(" forward;", StringComparison.OrdinalIgnoreCase)))
            |> Seq.filter (fun value ->
                let matched = Regex.Match(value, "^(?:function|procedure)\\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)", RegexOptions.IgnoreCase)
                not (matched.Success && isDelphiPortablePackageLocalSyntheticRoutine implementations matched.Groups.["name"].Value))
            |> Seq.distinct
            |> String.concat "\n"
        if String.IsNullOrWhiteSpace signatures then failwith "portable Delphi package lowering could not derive interface signatures"
        let unitSource =
            $"unit SpiralGeneratedUnit;\n{modeLine}\n\ninterface\n\n{declarations}\n\n{signatures}\n\nimplementation\n\n{implementations}\n\nend.\n"
        let mainSource =
            $"program SpiralGenerated;\n{modeLine}\n\nuses SpiralGeneratedUnit;\n\n{mainFunction}\n\n{programTail}\n"
        [ "SpiralGeneratedUnit.pas", unitSource
          "main.pas", mainSource ]

    let lowerPortablePackage backend generated =
        let flatSource = lowerPortableBackend backend generated
        match backend with
        | "Rust" -> lowerRustPortablePackage flatSource
        | "Delphi" -> lowerDelphiPortablePackage flatSource
        | invalid -> failwith $"portable package backend is unsupported: {invalid}"

    type private PortableDefinitionProvenance = {
        symbol : string
        moduleName : string
        sidecarFile : string
        sidecarLine : int
    }

    type private PortableTypeProvenance = {
        symbol : string
        moduleName : string
        sidecarFile : string
        sidecarLine : int
    }

    type private PortableProvenanceDependencyEdge = {
        sourceModule : string
        targetModule : string
        targetSymbol : string
        sidecarFile : string
        sidecarLine : int
    }

    type private PortableProvenanceDependencyProjection = {
        edges : PortableProvenanceDependencyEdge list
        manifestPairs : (string * string) list
        dependenciesByModule : Map<string, string list>
    }

    let private portableProvenanceLocation sidecarFile sidecarLine =
        $"{sidecarFile}:{sidecarLine}"

    type private PortableProjectGraph = {
        projectName : string
        packages : string list
        packageDependencies : (string * string) list
        modules : string list
        entryModule : string
        libraryModules : string list
        implementationOwner : string
        provenance : PortableDefinitionProvenance list
        typeProvenance : PortableTypeProvenance list
    }

    let private portableModuleToken (value : string) =
        let mutable token = value.Trim()
        while token.EndsWith("-", StringComparison.Ordinal) || token.EndsWith("*", StringComparison.Ordinal) do
            token <- token.Substring(0, token.Length - 1)
        token

    let private portableRustModuleName (value : string) =
        let builder = StringBuilder()
        for ch in value.Replace('/', '_').Replace('\\', '_') do
            if Char.IsLetterOrDigit ch || ch = '_' then builder.Append(Char.ToLowerInvariant ch) |> ignore
            else builder.Append('_') |> ignore
        let result = builder.ToString().Trim('_')
        if String.IsNullOrWhiteSpace result then "spiral_module"
        elif Char.IsDigit result.[0] then "m_" + result
        else result

    let private portableDelphiUnitName (value : string) =
        let parts = Regex.Split(value, "[^A-Za-z0-9]+") |> Array.filter (String.IsNullOrWhiteSpace >> not)
        let body =
            parts
            |> Array.map (fun part -> Char.ToUpperInvariant(part.[0]).ToString() + part.Substring(1))
            |> String.concat ""
        let body = if String.IsNullOrWhiteSpace body then "Module" else body
        let body = if Char.IsDigit body.[0] then "M" + body else body
        "Spiral" + body

    let private parsePortableProvenance (projectDirectory : string) (libraryModules : string list) =
        let path = System.IO.Path.Combine(projectDirectory, "portable-provenance.tsv")
        let sidecarFile = System.IO.Path.GetFileName path
        if not (System.IO.File.Exists path) then [], []
        else
            let symbolPattern = Regex("^[A-Za-z_][A-Za-z0-9_]*$")
            let mutable seenDefinitions = Map.empty<string, PortableDefinitionProvenance>
            let mutable seenTypes = Map.empty<string, PortableTypeProvenance>
            let definitions = ResizeArray<PortableDefinitionProvenance>()
            let types = ResizeArray<PortableTypeProvenance>()
            System.IO.File.ReadAllLines path
            |> Array.mapi (fun index raw -> index + 1, raw)
            |> Array.iter (fun (sidecarLine, raw) ->
                let line = raw.Trim()
                if not (String.IsNullOrWhiteSpace line || line.StartsWith("#", StringComparison.Ordinal) || line.StartsWith("schema=", StringComparison.Ordinal)) then
                    let location = portableProvenanceLocation sidecarFile sidecarLine
                    let fields = line.Split('\t')
                    if fields.Length <> 3 || (fields.[0] <> "definition" && fields.[0] <> "type") then
                        failPortableProvenance "SPIRAL_PROVENANCE_ROW_SHAPE" $"portable provenance row must be definition<TAB>symbol<TAB>module or type<TAB>symbol<TAB>module at {location}; got: {line}"
                    let kind = fields.[0]
                    let symbol = fields.[1].Trim()
                    let moduleName = fields.[2].Trim()
                    if not (symbolPattern.IsMatch symbol) then
                        failPortableProvenance "SPIRAL_PROVENANCE_INVALID_SYMBOL" $"portable provenance has invalid symbol: {symbol} at {location}"
                    if not (libraryModules |> List.contains moduleName) then
                        failPortableProvenance "SPIRAL_PROVENANCE_UNDECLARED_MODULE" $"portable provenance module is not a declared library module: {moduleName} at {location}; symbol: {symbol}"
                    if kind = "definition" then
                        match seenDefinitions |> Map.tryFind symbol with
                        | Some first ->
                            let firstLocation = portableProvenanceLocation first.sidecarFile first.sidecarLine
                            failPortableProvenance "SPIRAL_PROVENANCE_DUPLICATE_SYMBOL" $"portable provenance has duplicate definition symbol: {symbol} at {location}; first declared at {firstLocation}; modules: {first.moduleName} -> {moduleName}"
                        | None ->
                            let item : PortableDefinitionProvenance = {
                                symbol = symbol
                                moduleName = moduleName
                                sidecarFile = sidecarFile
                                sidecarLine = sidecarLine
                            }
                            seenDefinitions <- seenDefinitions.Add(symbol, item)
                            definitions.Add item
                    else
                        match seenTypes |> Map.tryFind symbol with
                        | Some first ->
                            let firstLocation = portableProvenanceLocation first.sidecarFile first.sidecarLine
                            failPortableProvenance "SPIRAL_PROVENANCE_DUPLICATE_TYPE" $"portable provenance has duplicate type symbol: {symbol} at {location}; first declared at {firstLocation}; modules: {first.moduleName} -> {moduleName}"
                        | None ->
                            let item : PortableTypeProvenance = {
                                symbol = symbol
                                moduleName = moduleName
                                sidecarFile = sidecarFile
                                sidecarLine = sidecarLine
                            }
                            seenTypes <- seenTypes.Add(symbol, item)
                            types.Add item)
            definitions |> Seq.toList, types |> Seq.toList

    let private parsePortableProjectGraph (projectPath : string) (entrySourcePath : string) =
        let parseModules (projectPath : string) packagePrefix =
            let projectPath = System.IO.Path.GetFullPath projectPath
            let projectDirectory = System.IO.Path.GetDirectoryName projectPath
            let lines = System.IO.File.ReadAllLines projectPath
            let moduleStart = lines |> Array.tryFindIndex (fun line -> line.Trim().Equals("modules:", StringComparison.Ordinal))
            let moduleStart = moduleStart |> Option.defaultWith (fun () -> failwith $"portable project package requires a modules: section: {projectPath}")
            let mutable stack : (int * string) list = []
            let modules = ResizeArray<string>()
            let mutable reading = true
            let mutable index = moduleStart + 1
            while reading && index < lines.Length do
                let raw = lines.[index]
                let trimmed = raw.Trim()
                let indent = raw.Length - raw.TrimStart().Length
                if String.IsNullOrWhiteSpace trimmed || trimmed.StartsWith("//", StringComparison.Ordinal) then ()
                elif indent = 0 && trimmed.EndsWith(":", StringComparison.Ordinal) then reading <- false
                else
                    let value =
                        let comment = trimmed.IndexOf("//", StringComparison.Ordinal)
                        if comment >= 0 then trimmed.Substring(0, comment).Trim() else trimmed
                    while not stack.IsEmpty && fst stack.Head >= indent do stack <- stack.Tail
                    if value.EndsWith("/", StringComparison.Ordinal) then
                        stack <- (indent, value.TrimEnd('/')) :: stack
                    elif not (String.IsNullOrWhiteSpace value) then
                        let prefix = stack |> List.rev |> List.map snd
                        let token = portableModuleToken value
                        modules.Add(String.concat "/" (prefix @ [ token ]))
                index <- index + 1
            if modules.Count = 0 then failwith $"portable project package did not find any modules: {projectPath}"
            let moduleDirectory =
                lines
                |> Array.tryPick (fun line ->
                    let trimmed = line.Trim()
                    if trimmed.StartsWith("moduleDir:", StringComparison.Ordinal) then
                        Some (trimmed.Substring("moduleDir:".Length).Trim())
                    else None)
                |> Option.map (fun value -> if System.IO.Path.IsPathRooted value then value else System.IO.Path.Combine(projectDirectory, value))
                |> Option.defaultValue projectDirectory
            let localModules = modules |> Seq.toList
            let qualifiedModules =
                match packagePrefix with
                | Some prefix -> localModules |> List.map (fun moduleName -> prefix + "/" + moduleName)
                | None -> localModules
            projectDirectory, lines, moduleDirectory, localModules, qualifiedModules

        let parsePackageReferences projectPath projectDirectory (lines : string array) =
            let packageStart = lines |> Array.tryFindIndex (fun line -> line.Trim().Equals("packages:", StringComparison.Ordinal))
            match packageStart with
            | None -> []
            | Some packageStart ->
                let packageDirectory =
                    lines
                    |> Array.tryPick (fun line ->
                        let trimmed = line.Trim()
                        if trimmed.StartsWith("packageDir:", StringComparison.Ordinal) then
                            Some (trimmed.Substring("packageDir:".Length).Trim())
                        else None)
                    |> Option.map (fun value -> if System.IO.Path.IsPathRooted value then value else System.IO.Path.Combine(projectDirectory, value))
                    |> Option.defaultValue (System.IO.Path.GetFullPath(System.IO.Path.Combine(projectDirectory, "..")))
                let compilerDirectory () =
                    let configured = Environment.GetEnvironmentVariable "SPIRAL_COMPILER_PACKAGE_DIR"
                    if String.IsNullOrWhiteSpace configured then
                        failwith $"portable project compiler package directory is not configured: {projectPath}"
                    System.IO.Path.GetFullPath configured
                let packages = ResizeArray<string * string>()
                let mutable reading = true
                let mutable index = packageStart + 1
                while reading && index < lines.Length do
                    let raw = lines.[index]
                    let trimmed = raw.Trim()
                    let indent = raw.Length - raw.TrimStart().Length
                    if String.IsNullOrWhiteSpace trimmed || trimmed.StartsWith("//", StringComparison.Ordinal) then ()
                    elif indent = 0 && trimmed.EndsWith(":", StringComparison.Ordinal) then reading <- false
                    else
                        let uncommented =
                            let comment = trimmed.IndexOf("//", StringComparison.Ordinal)
                            if comment >= 0 then trimmed.Substring(0, comment).Trim() else trimmed
                        if not (String.IsNullOrWhiteSpace uncommented) then
                            let isCompilerPackage = uncommented.StartsWith("|", StringComparison.Ordinal)
                            let withoutCompilerPrefix = if isCompilerPackage then uncommented.Substring(1) else uncommented
                            let isInclude = withoutCompilerPrefix.EndsWith("-", StringComparison.Ordinal)
                            let packageName = if isInclude then withoutCompilerPrefix.Substring(0, withoutCompilerPrefix.Length - 1) else withoutCompilerPrefix
                            if not isInclude then
                                let baseDirectory = if isCompilerPackage then compilerDirectory() else packageDirectory
                                let packageProject = System.IO.Path.Combine(baseDirectory, packageName, "package.spiproj") |> System.IO.Path.GetFullPath
                                if not (System.IO.File.Exists packageProject) then
                                    failwith $"portable project package dependency is missing package.spiproj: {packageName} at {packageProject}"
                                packages.Add(packageName, packageProject)
                    index <- index + 1
                packages |> Seq.toList

        let projectPath = System.IO.Path.GetFullPath projectPath
        let projectDirectory, rootLines, moduleDirectory, rootModules, rootQualifiedModules = parseModules projectPath None
        let relativeEntry = System.IO.Path.GetRelativePath(moduleDirectory, System.IO.Path.GetFullPath entrySourcePath).Replace('\\', '/')
        let entryModule =
            let extension = System.IO.Path.GetExtension relativeEntry
            if String.IsNullOrWhiteSpace extension then relativeEntry else relativeEntry.Substring(0, relativeEntry.Length - extension.Length)
        if not (rootModules |> List.contains entryModule) then
            failwith $"portable project entry module is not declared in modules: {entryModule}"
        let projectName = System.IO.Path.GetFileName projectDirectory
        let validateDuplicatePackageReferences owner references =
            let duplicate = references |> List.map fst |> List.groupBy id |> List.tryFind (fun (_, values) -> values.Length > 1)
            match duplicate with
            | Some (packageName, _) -> failwith $"portable project package dependency is duplicated in {owner}: {packageName}"
            | None -> ()
        let packageReferences = parsePackageReferences projectPath projectDirectory rootLines
        validateDuplicatePackageReferences projectName packageReferences
        let mutable packagePathByName = Map.empty<string, string>
        let mutable packageNameByPath = Map.empty<string, string>
        let orderedPackages = ResizeArray<string>()
        let packageDependencies = ResizeArray<string * string>()
        let rec collectPackages parentName path references =
            references
            |> List.sortBy fst
            |> List.collect (fun (packageName, rawPackageProject) ->
                let packageProject = System.IO.Path.GetFullPath rawPackageProject
                packageDependencies.Add(parentName, packageName)
                match path |> List.tryFindIndex (fun (_, pathProject) -> String.Equals(pathProject, packageProject, StringComparison.Ordinal)) with
                | Some cycleStart ->
                    let cycle = (path |> List.skip cycleStart |> List.map fst) @ [ packageName ]
                    let cycleText = String.concat " -> " cycle
                    failwith $"portable project package dependency cycle: {cycleText}"
                | None ->
                    match packagePathByName |> Map.tryFind packageName with
                    | Some firstPath when not (String.Equals(firstPath, packageProject, StringComparison.Ordinal)) ->
                        failwith $"portable project package identity resolves to multiple package.spiproj files: {packageName}; {firstPath}; {packageProject}"
                    | _ -> ()
                    match packageNameByPath |> Map.tryFind packageProject with
                    | Some firstName when firstName <> packageName ->
                        failwith $"portable project package.spiproj has multiple identities: {packageProject}; {firstName}; {packageName}"
                    | Some _ -> []
                    | None ->
                        packagePathByName <- packagePathByName.Add(packageName, packageProject)
                        packageNameByPath <- packageNameByPath.Add(packageProject, packageName)
                        let packageDirectory, packageLines, _, _, qualifiedModules = parseModules packageProject (Some packageName)
                        let nestedPackages = parsePackageReferences packageProject packageDirectory packageLines
                        validateDuplicatePackageReferences packageName nestedPackages
                        let nestedModules = collectPackages packageName (path @ [ packageName, packageProject ]) nestedPackages
                        orderedPackages.Add packageName
                        nestedModules @ qualifiedModules)
        let packageModules = collectPackages projectName [ projectName, projectPath ] packageReferences
        let packageNames = orderedPackages |> Seq.toList
        let packageDependencyList = packageDependencies |> Seq.distinct |> Seq.sort |> Seq.toList
        let moduleList = packageModules @ rootQualifiedModules
        let duplicateModule = moduleList |> List.groupBy id |> List.tryFind (fun (_, values) -> values.Length > 1)
        match duplicateModule with
        | Some (moduleName, _) -> failwith $"portable project package module is duplicated: {moduleName}"
        | None -> ()
        let libraryModules = moduleList |> List.filter ((<>) entryModule)
        if libraryModules.IsEmpty then failwith "portable project package requires at least one non-entry or dependency module"
        let implementationOwner = List.last libraryModules
        let provenance, typeProvenance = parsePortableProvenance projectDirectory libraryModules
        // Explicit type provenance keeps the type in its declared owner. The owner
        // no longer has to be the final implementation module; dependency projection
        // and the backend unit/module split validate every consumer edge.
        {
            projectName = projectName
            packages = packageNames
            packageDependencies = packageDependencyList
            modules = moduleList
            entryModule = entryModule
            libraryModules = libraryModules
            implementationOwner = implementationOwner
            provenance = provenance
            typeProvenance = typeProvenance
        }

    let private portableProjectGraphManifest graph (projection : PortableProvenanceDependencyProjection) =
        [ "schema=6"
          $"project={graph.projectName}"
          $"entry={graph.entryModule}"
          $"implementation_owner={graph.implementationOwner}"
          "package_order=dependency-first-lexical"
          "package_identity=canonical-path-single-emission"
          yield! graph.packages |> List.mapi (fun index packageName -> $"package={index}\t{packageName}")
          yield! graph.packageDependencies |> List.map (fun (sourcePackage, targetPackage) -> $"package_dependency={sourcePackage}\tpackage={targetPackage}")
          if graph.provenance.IsEmpty then "ownership_policy=last-non-entry-module-until-source-provenance"
          else "ownership_policy=explicit-definition-provenance-with-default-owner"
          yield! graph.modules |> List.mapi (fun index moduleName -> $"module={index}\t{moduleName}")
          yield! graph.provenance |> List.map (fun item -> $"definition={item.symbol}\tmodule={item.moduleName}")
          yield! graph.typeProvenance |> List.map (fun item -> $"type={item.symbol}\tmodule={item.moduleName}")
          yield!
              projection.manifestPairs
              |> List.map (fun (sourceModule, targetModule) -> $"dependency={sourceModule}\tmodule={targetModule}") ]
        |> String.concat "\n"
        |> fun value -> value + "\n"

    let private portableProvenanceDependencyTargets graph moduleName (source : string) =
        let callableEdges =
            graph.provenance
            |> List.choose (fun item ->
                if item.moduleName = moduleName then None
                elif Regex.IsMatch(source, $"\\b{Regex.Escape item.symbol}\\s*\\(") then
                    Some {
                        sourceModule = moduleName
                        targetModule = item.moduleName
                        targetSymbol = item.symbol
                        sidecarFile = item.sidecarFile
                        sidecarLine = item.sidecarLine
                    }
                else None)
        let typeEdges =
            graph.typeProvenance
            |> List.choose (fun item ->
                if item.moduleName = moduleName then None
                elif Regex.IsMatch(source, $"\\b{Regex.Escape item.symbol}\\b") then
                    Some {
                        sourceModule = moduleName
                        targetModule = item.moduleName
                        targetSymbol = item.symbol
                        sidecarFile = item.sidecarFile
                        sidecarLine = item.sidecarLine
                    }
                else None)
        callableEdges @ typeEdges
        |> List.distinctBy (fun edge -> edge.sourceModule, edge.targetModule, edge.targetSymbol)
        |> List.sortBy (fun edge -> edge.targetModule, edge.targetSymbol)

    let private validatePortableProvenanceDependencyEdges (graph : PortableProjectGraph) edges =
        let declaredModules = graph.libraryModules |> Set.ofList
        let normalized =
            edges
            |> List.distinctBy (fun edge -> edge.sourceModule, edge.targetModule, edge.targetSymbol)
            |> List.sortBy (fun edge -> edge.sourceModule, edge.targetModule, edge.targetSymbol)
        for edge in normalized do
            let location = portableProvenanceLocation edge.sidecarFile edge.sidecarLine
            if not (declaredModules.Contains edge.sourceModule) then
                failPortableProvenance "SPIRAL_PROVENANCE_EDGE_SOURCE_UNDECLARED" $"portable provenance dependency source module is not declared: {edge.sourceModule}; target symbol: {edge.targetSymbol} at {location}"
            if not (declaredModules.Contains edge.targetModule) then
                failPortableProvenance "SPIRAL_PROVENANCE_EDGE_TARGET_UNDECLARED" $"portable provenance dependency target module is not declared: {edge.targetModule}; target symbol: {edge.targetSymbol} at {location}"
            if edge.sourceModule = edge.targetModule then
                failPortableProvenance "SPIRAL_PROVENANCE_SELF_DEPENDENCY" $"portable provenance dependency cannot target its own module: {edge.sourceModule}; symbol: {edge.targetSymbol} at {location}"
        let targets moduleName =
            normalized
            |> List.filter (fun edge -> edge.sourceModule = moduleName)
        let rec visit pathModules pathEdges moduleName =
            for edge in targets moduleName do
                match pathModules |> List.tryFindIndex ((=) edge.targetModule) with
                | Some cycleStart ->
                    let cycle = (pathModules |> List.skip cycleStart) @ [ edge.targetModule ]
                    let cycleEdges = (pathEdges |> List.skip cycleStart) @ [ edge ]
                    let cycleText = String.concat " -> " cycle
                    let edgeText =
                        cycleEdges
                        |> List.map (fun item ->
                            let location = portableProvenanceLocation item.sidecarFile item.sidecarLine
                            $"{item.sourceModule} -> {item.targetModule} via {item.targetSymbol} at {location}")
                        |> String.concat "; "
                    failPortableProvenance "SPIRAL_PROVENANCE_SIBLING_CYCLE" $"portable provenance sibling dependency cycle: {cycleText}; edges: {edgeText}"
                | None -> visit (pathModules @ [ edge.targetModule ]) (pathEdges @ [ edge ]) edge.targetModule
        graph.libraryModules
        |> List.sort
        |> List.iter (fun moduleName -> visit [ moduleName ] [] moduleName)
        normalized

    let private portableProvenanceDependencyProjection (graph : PortableProjectGraph) moduleSources =
        let edges =
            moduleSources
            |> List.collect (fun (moduleName, source) -> portableProvenanceDependencyTargets graph moduleName source)
            |> validatePortableProvenanceDependencyEdges graph
        let manifestPairs =
            edges
            |> List.map (fun edge -> edge.sourceModule, edge.targetModule)
            |> List.distinct
            |> List.sort
        let dependenciesByModule =
            graph.libraryModules
            |> List.map (fun moduleName ->
                let dependencyModules =
                    edges
                    |> List.choose (fun edge -> if edge.sourceModule = moduleName then Some edge.targetModule else None)
                moduleName, dependencyModules)
            |> Map.ofList
        {
            edges = edges
            manifestPairs = manifestPairs
            dependenciesByModule = dependenciesByModule
        }

    let private insertRustPortableImports imports (source : string) =
        if imports |> List.isEmpty then source
        else
            let importText = imports |> List.map (fun rustName -> $"use crate::{rustName}::*;") |> String.concat "\n"
            let attributes = Regex.Matches(source, "(?m)^#!\\[[^\\r\\n]*\\]")
            if attributes.Count > 0 then
                let lastAttribute = attributes.[attributes.Count - 1]
                source.Insert(lastAttribute.Index + lastAttribute.Length, "\n" + importText)
            else importText + "\n" + source

    let private insertDelphiSectionUses (marker : string) (missingMessage : string) (units : string list) (source : string) =
        let units = units |> List.distinct
        if units |> List.isEmpty then source
        else
            let markerIndex = source.IndexOf(marker, StringComparison.Ordinal)
            if markerIndex < 0 then failwith missingMessage
            let insertionIndex = markerIndex + marker.Length
            let unitList = String.concat ", " units
            source.Insert(insertionIndex, $"\nuses {unitList};\n")

    let private insertDelphiInterfaceUses units (source : string) =
        insertDelphiSectionUses "\ninterface\n" "portable provenance Delphi unit is missing interface" units source

    let private insertDelphiImplementationUses units (source : string) =
        insertDelphiSectionUses "\nimplementation\n" "portable provenance Delphi unit is missing implementation" units source

    let private extractRustPortableFunction (symbol : string) (source : string) =
        let pattern = Regex($"(?m)^pub fn {Regex.Escape symbol}\\b")
        let matched = pattern.Match source
        if not matched.Success then failwith $"portable provenance Rust symbol was not found exactly as a public function: {symbol}"
        let duplicate = pattern.Match(source, matched.Index + matched.Length)
        if duplicate.Success then failwith $"portable provenance Rust symbol is ambiguous: {symbol}"
        let openIndex = source.IndexOf('{', matched.Index)
        if openIndex < 0 then failwith $"portable provenance Rust function has no opening brace: {symbol}"
        let closeIndex = findMatchingDelimiter source openIndex '{' '}'
        let mutable finish = closeIndex + 1
        while finish < source.Length && (source.[finish] = '\r' || source.[finish] = '\n') do finish <- finish + 1
        let block = source.Substring(matched.Index, finish - matched.Index).TrimEnd()
        block, source.Remove(matched.Index, finish - matched.Index)

    let private findDelphiRoutineEnd (source : string) startIndex =
        let tokenPattern = Regex("(?im)^(?:begin|end;)\\s*$")
        let mutable depth = 0
        let mutable started = false
        let mutable finish = -1
        let mutable matched = tokenPattern.Match(source, startIndex)
        while finish < 0 && matched.Success do
            if matched.Value.Trim().Equals("begin", StringComparison.OrdinalIgnoreCase) then
                depth <- depth + 1
                started <- true
            else
                if started then depth <- depth - 1
                if started && depth = 0 then finish <- matched.Index + matched.Length
            matched <- tokenPattern.Match(source, matched.Index + matched.Length)
        if finish < 0 then failwith "portable provenance Delphi routine has no balanced end;"
        finish

    let private extractDelphiPortableRoutine (symbol : string) (source : string) =
        let interfaceMarker = "\ninterface\n"
        let implementationMarker = "\nimplementation\n"
        let interfaceIndex = source.IndexOf(interfaceMarker, StringComparison.Ordinal)
        let implementationIndex = source.IndexOf(implementationMarker, StringComparison.Ordinal)
        if interfaceIndex < 0 || implementationIndex < 0 || implementationIndex <= interfaceIndex then
            failwith "portable provenance Delphi unit is missing interface or implementation"
        let pattern = Regex($"(?im)^(?:function|procedure)\\s+{Regex.Escape symbol}\\b[^\\n]*;\\s*$")
        let signature = pattern.Match(source, interfaceIndex + interfaceMarker.Length)
        if not signature.Success || signature.Index >= implementationIndex then
            failwith $"portable provenance Delphi interface symbol was not found: {symbol}"
        let implementation = pattern.Match(source, implementationIndex + implementationMarker.Length)
        if not implementation.Success then failwith $"portable provenance Delphi implementation symbol was not found: {symbol}"
        let finish = findDelphiRoutineEnd source (implementation.Index + implementation.Length)
        let mutable implementationFinish = finish
        while implementationFinish < source.Length && (source.[implementationFinish] = '\r' || source.[implementationFinish] = '\n') do implementationFinish <- implementationFinish + 1
        let signatureText = signature.Value.Trim()
        let implementationText = source.Substring(implementation.Index, implementationFinish - implementation.Index).TrimEnd()
        let withoutImplementation = source.Remove(implementation.Index, implementationFinish - implementation.Index)
        let withoutSignature = withoutImplementation.Remove(signature.Index, signature.Length)
        signatureText, implementationText, withoutSignature

    let private validateRustPortableTypeProvenance (graph : PortableProjectGraph) (source : string) =
        for item in graph.typeProvenance do
            let pattern = Regex($"(?m)^pub\\s+(?:struct|enum|type)\\s+{Regex.Escape item.symbol}\\b")
            let matches = pattern.Matches source
            let location = portableProvenanceLocation item.sidecarFile item.sidecarLine
            if matches.Count = 0 then
                failPortableProvenance "SPIRAL_PROVENANCE_TYPE_NOT_FOUND" $"portable package-owned Rust type was not found: {item.symbol} at {location}"
            elif matches.Count > 1 then
                failPortableProvenance "SPIRAL_PROVENANCE_TYPE_AMBIGUOUS" $"portable package-owned Rust type is ambiguous: {item.symbol} at {location}"

    let private publicizeRustPortableTypeFields (symbol : string) (source : string) =
        let pattern = Regex($"(?m)^pub\\s+struct\\s+{Regex.Escape symbol}\\b")
        let matched = pattern.Match source
        if not matched.Success then source
        else
            let openIndex = source.IndexOf('{', matched.Index)
            if openIndex < 0 then source
            else
                let closeIndex = findMatchingDelimiter source openIndex '{' '}'
                let body = source.Substring(openIndex + 1, closeIndex - openIndex - 1)
                let publicBody = Regex.Replace(body, "(?m)^(?<indent>\\s+)(?<field>[A-Za-z_][A-Za-z0-9_]*\\s*:)", "${indent}pub ${field}")
                source.Substring(0, openIndex + 1) + publicBody + source.Substring(closeIndex)

    let private extractRustPortableTypeGroup (symbols : string list) (functionSymbols : string list) (source : string) =
        let includeRustItemAttributes rawStart =
            let mutable startIndex = rawStart
            let mutable scanning = true
            while scanning && startIndex > 0 do
                let lineEnd = if source.[startIndex - 1] = '\n' then startIndex - 1 else startIndex
                let previousNewline = if lineEnd <= 0 then -1 else source.LastIndexOf('\n', lineEnd - 1)
                let lineStart = previousNewline + 1
                let line = source.Substring(lineStart, lineEnd - lineStart).Trim()
                if line.StartsWith("#[", StringComparison.Ordinal) && line.EndsWith("]", StringComparison.Ordinal) then
                    startIndex <- lineStart
                else
                    scanning <- false
            startIndex
        let typeStarts =
            symbols
            |> List.map (fun symbol ->
                let matched = Regex($"(?m)^pub\\s+(?:struct|enum|type)\\s+{Regex.Escape symbol}\\b").Match source
                if not matched.Success then failwith $"portable provenance Rust type group symbol was not found: {symbol}"
                matched.Index |> includeRustItemAttributes)
        let startIndex = typeStarts |> List.min
        let finishIndex =
            functionSymbols
            |> List.choose (fun symbol ->
                let matched = Regex($"(?m)^pub fn {Regex.Escape symbol}\\b").Match source
                if matched.Success && matched.Index > startIndex then Some matched.Index else None)
            |> function
               | [] -> source.Length
               | values -> values |> List.min
        let block = source.Substring(startIndex, finishIndex - startIndex).TrimEnd()
        block, source.Remove(startIndex, finishIndex - startIndex)

    let private extractDelphiPortableTypeGroup (functionSymbols : string list) (source : string) =
        let interfaceMarker = "\ninterface\n"
        let implementationMarker = "\nimplementation\n"
        let interfaceIndex = source.IndexOf(interfaceMarker, StringComparison.Ordinal)
        let implementationIndex = source.IndexOf(implementationMarker, StringComparison.Ordinal)
        if interfaceIndex < 0 || implementationIndex < 0 || implementationIndex <= interfaceIndex then
            failwith "portable provenance Delphi type group is missing interface or implementation"
        let interfaceContentStart = interfaceIndex + interfaceMarker.Length
        let implementationContentStart = implementationIndex + implementationMarker.Length
        let routinePattern symbol = Regex($"(?im)^(?:function|procedure)\\s+{Regex.Escape symbol}\\b[^\\n]*;\\s*$")
        let interfaceFinish =
            functionSymbols
            |> List.choose (fun symbol ->
                let matched = (routinePattern symbol).Match(source, interfaceContentStart)
                if matched.Success && matched.Index < implementationIndex then Some matched.Index else None)
            |> function
               | [] -> failwith "portable provenance Delphi type group has no following interface routine"
               | values -> values |> List.min
        let implementationFinish =
            functionSymbols
            |> List.choose (fun symbol ->
                let matched = (routinePattern symbol).Match(source, implementationContentStart)
                if matched.Success then Some matched.Index else None)
            |> function
               | [] -> failwith "portable provenance Delphi type group has no following implementation routine"
               | values -> values |> List.min
        let interfacePreamble = source.Substring(interfaceContentStart, interfaceFinish - interfaceContentStart).Trim()
        let implementationPreamble = source.Substring(implementationContentStart, implementationFinish - implementationContentStart).Trim()
        let withoutImplementation = source.Remove(implementationContentStart, implementationFinish - implementationContentStart)
        let remaining = withoutImplementation.Remove(interfaceContentStart, interfaceFinish - interfaceContentStart)
        interfacePreamble, implementationPreamble, remaining

    let private validateDelphiPortableTypeProvenance (graph : PortableProjectGraph) (source : string) =
        for item in graph.typeProvenance do
            let pattern = Regex($"(?im)^\\s*{Regex.Escape item.symbol}\\s*=\\s*")
            let matches = pattern.Matches source
            let location = portableProvenanceLocation item.sidecarFile item.sidecarLine
            if matches.Count = 0 then
                failPortableProvenance "SPIRAL_PROVENANCE_TYPE_NOT_FOUND" $"portable package-owned Delphi type was not found: {item.symbol} at {location}"
            elif matches.Count > 1 then
                failPortableProvenance "SPIRAL_PROVENANCE_TYPE_AMBIGUOUS" $"portable package-owned Delphi type is ambiguous: {item.symbol} at {location}"

    let private portableSourceCallsOwnerRoutine definitionPattern options (ownerSource : string) (source : string) =
        Regex.Matches(ownerSource, definitionPattern, options)
        |> Seq.cast<Match>
        |> Seq.exists (fun definition ->
            let name = definition.Groups.["name"].Value
            Regex.IsMatch(source, $@"\b{Regex.Escape name}\s*\(", RegexOptions.CultureInvariant))

    let private lowerRustPortableProjectPackage graph flatSource =
        let baseFiles = lowerRustPortablePackage flatSource |> Map.ofList
        let librarySource = baseFiles.["src/lib.rs"]
        let mainSource = baseFiles.["src/main.rs"]
        let cargoManifest = baseFiles.["Cargo.toml"]
        let modulePairs = graph.libraryModules |> List.map (fun moduleName -> moduleName, portableRustModuleName moduleName)
        let moved = ResizeArray<string * string>()
        let mutable ownerSource = librarySource
        for item in graph.provenance do
            if item.moduleName <> graph.implementationOwner then
                let block, remaining = extractRustPortableFunction item.symbol ownerSource
                moved.Add((item.moduleName, block))
                ownerSource <- remaining
        for item in graph.typeProvenance do
            ownerSource <- publicizeRustPortableTypeFields item.symbol ownerSource
        validateRustPortableTypeProvenance graph ownerSource
        let typeOwner =
            graph.typeProvenance
            |> List.map (fun item -> item.moduleName)
            |> List.distinct
            |> function
               | [] -> None
               | [owner] when owner = graph.implementationOwner -> None
               | [owner] -> Some owner
               | owners ->
                   let ownersText = String.concat "," owners
                   failPortableProvenance "SPIRAL_PROVENANCE_TYPE_OWNER_GROUP_UNSUPPORTED" $"portable package-owned types must share one owner in the bounded projection: {ownersText}"
        match typeOwner with
        | Some owner ->
            let typeBlock, remaining =
                extractRustPortableTypeGroup
                    (graph.typeProvenance |> List.map (fun item -> item.symbol))
                    (graph.provenance |> List.map (fun item -> item.symbol))
                    ownerSource
            moved.Add((owner, typeBlock))
            ownerSource <- remaining |> normalizeRustUnusedRcImport |> normalizeRustUnusedRefCellImport
        | None -> ()
        let rootLibrary =
            [ yield! modulePairs |> List.map (fun (_, rustName) -> $"pub mod {rustName};")
              yield! modulePairs |> List.map (fun (_, rustName) -> $"pub use {rustName}::*;") ]
            |> String.concat "\n"
            |> fun value -> value + "\n"
        let moduleSources =
            modulePairs
            |> List.map (fun (moduleName, rustName) ->
                let blocks = moved |> Seq.choose (fun (owner, block) -> if owner = moduleName then Some block else None) |> Seq.toList
                let source = if moduleName = graph.implementationOwner then ownerSource else String.concat "\n\n" blocks
                moduleName, rustName, blocks, source)
        let dependencyProjection =
            moduleSources
            |> List.map (fun (moduleName, _, _, source) -> moduleName, source)
            |> portableProvenanceDependencyProjection graph
        let moduleFiles =
            moduleSources
            |> List.map (fun (moduleName, rustName, blocks, source) ->
                let dependencyModules = dependencyProjection.dependenciesByModule.[moduleName]
                let importsTypeOwner =
                    match typeOwner with
                    | Some owner -> dependencyModules |> List.contains owner
                    | None -> false
                let needsOwnerFallback =
                    moduleName <> graph.implementationOwner
                    && typeOwner <> Some moduleName
                    && not importsTypeOwner
                    && portableSourceCallsOwnerRoutine @"^(?:pub\s+)?fn\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\s*\(" RegexOptions.Multiline ownerSource source
                let importModules =
                    [ if needsOwnerFallback then graph.implementationOwner
                      yield! dependencyModules ]
                    |> List.filter ((<>) moduleName)
                    |> List.distinct
                    |> List.map portableRustModuleName
                let content =
                    if moduleName = graph.implementationOwner then insertRustPortableImports importModules source
                    elif not blocks.IsEmpty then
                        let importText =
                            [ yield! importModules |> List.map (fun dependency -> $"use crate::{dependency}::*;")
                              if source.Contains("Rc<", StringComparison.Ordinal) then yield "use std::rc::Rc;"
                              if source.Contains("RefCell<", StringComparison.Ordinal) then yield "use std::cell::RefCell;" ]
                            |> List.distinct
                            |> String.concat "\n"
                        $"#![allow(unused_imports, unused_mut, non_snake_case)]\n#![allow(clippy::needless_return, clippy::needless_late_init, clippy::clone_on_copy)]\n{importText}\n\n{source}\n"
                    else $"// Spiral module {moduleName}; no definitions were assigned by provenance.\n"
                $"src/{rustName}.rs", content)
        [ "Cargo.toml", cargoManifest
          "src/lib.rs", rootLibrary
          "src/main.rs", mainSource
          yield! moduleFiles
          "spiral-module-graph.tsv", portableProjectGraphManifest graph dependencyProjection ]

    let private lowerDelphiPortableProjectPackage graph flatSource =
        let baseFiles = lowerDelphiPortablePackage flatSource |> Map.ofList
        let originalUnit = baseFiles.["SpiralGeneratedUnit.pas"]
        let originalMain = baseFiles.["main.pas"]
        let unitPairs = graph.libraryModules |> List.map (fun moduleName -> moduleName, portableDelphiUnitName moduleName)
        let ownerUnit = portableDelphiUnitName graph.implementationOwner
        let moved = ResizeArray<string * string * string>()
        let mutable ownerSource = originalUnit.Replace("unit SpiralGeneratedUnit;", $"unit {ownerUnit};", StringComparison.Ordinal)
        for item in graph.provenance do
            if item.moduleName <> graph.implementationOwner then
                let signature, implementation, remaining = extractDelphiPortableRoutine item.symbol ownerSource
                moved.Add((item.moduleName, signature, implementation))
                ownerSource <- remaining
        validateDelphiPortableTypeProvenance graph ownerSource
        let typeOwner =
            graph.typeProvenance
            |> List.map (fun item -> item.moduleName)
            |> List.distinct
            |> function
               | [] -> None
               | [owner] when owner = graph.implementationOwner -> None
               | [owner] -> Some owner
               | owners ->
                   let ownersText = String.concat "," owners
                   failPortableProvenance "SPIRAL_PROVENANCE_TYPE_OWNER_GROUP_UNSUPPORTED" $"portable package-owned types must share one owner in the bounded projection: {ownersText}"
        let mutable typeUnitSource = None
        match typeOwner with
        | Some owner ->
            let interfacePreamble, implementationPreamble, remaining =
                extractDelphiPortableTypeGroup
                    (graph.provenance |> List.map (fun item -> item.symbol))
                    ownerSource
            let unitName = portableDelphiUnitName owner
            typeUnitSource <-
                Some $"unit {unitName};\n{{$mode objfpc}}{{$H+}}\n\ninterface\n\n{interfacePreamble}\n\nimplementation\n\n{implementationPreamble}\n\nend.\n"
            ownerSource <- remaining
        | None -> ()
        let usedUnits = unitPairs |> List.map snd |> String.concat ", "
        let mainSource = originalMain.Replace("uses SpiralGeneratedUnit;", $"uses {usedUnits};", StringComparison.Ordinal)
        let unitSources =
            unitPairs
            |> List.map (fun (moduleName, unitName) ->
                let blocks = moved |> Seq.choose (fun (owner, signature, implementation) -> if owner = moduleName then Some (signature, implementation) else None) |> Seq.toList
                let source =
                    if moduleName = graph.implementationOwner then ownerSource
                    elif typeOwner = Some moduleName then typeUnitSource |> Option.defaultValue ""
                    else blocks |> List.map snd |> String.concat "\n\n"
                moduleName, unitName, blocks, source)
        let dependencyProjection =
            unitSources
            |> List.map (fun (moduleName, _, _, source) -> moduleName, source)
            |> portableProvenanceDependencyProjection graph
        let unitFiles =
            unitSources
            |> List.map (fun (moduleName, unitName, blocks, source) ->
                let dependencyModules = dependencyProjection.dependenciesByModule.[moduleName]
                let importsTypeOwner =
                    match typeOwner with
                    | Some owner -> dependencyModules |> List.contains owner
                    | None -> false
                let needsOwnerFallback =
                    moduleName <> graph.implementationOwner
                    && typeOwner <> Some moduleName
                    && not importsTypeOwner
                    && portableSourceCallsOwnerRoutine @"^(?:function|procedure)\s+(?<name>[A-Za-z_][A-Za-z0-9_]*)\b" (RegexOptions.Multiline ||| RegexOptions.IgnoreCase) ownerSource source
                let dependencyUnits =
                    [ if needsOwnerFallback then graph.implementationOwner
                      yield! dependencyModules ]
                    |> List.filter ((<>) moduleName)
                    |> List.distinct
                    |> List.map portableDelphiUnitName
                let content =
                    if moduleName = graph.implementationOwner then
                        let interfaceModules =
                            match typeOwner with
                            | Some owner when dependencyModules |> List.contains owner -> [owner]
                            | _ -> []
                        let implementationModules =
                            dependencyModules
                            |> List.filter (fun dependency -> dependency <> moduleName && not (interfaceModules |> List.contains dependency))
                        source
                        |> insertDelphiInterfaceUses (interfaceModules |> List.map portableDelphiUnitName)
                        |> insertDelphiImplementationUses (implementationModules |> List.map portableDelphiUnitName)
                    elif typeOwner = Some moduleName then
                        let importsSysUtils = Regex.IsMatch(source, "(?im)^\\s*uses\\s+[^;]*\\bSysUtils\\b[^;]*;")
                        let runtimeUnits =
                            [ if source.Contains("Exception.Create", StringComparison.Ordinal) && not importsSysUtils then yield "SysUtils" ]
                        source |> insertDelphiImplementationUses runtimeUnits
                    elif not blocks.IsEmpty then
                        let signatures = blocks |> List.map fst |> String.concat "\n"
                        let implementations = blocks |> List.map snd |> String.concat "\n\n"
                        let interfaceUses =
                            if dependencyUnits.IsEmpty then ""
                            else
                                let unitList = String.concat ", " dependencyUnits
                                $"uses {unitList};\n\n"
                        let implementationUses =
                            [ if source.Contains("Exception.Create", StringComparison.Ordinal) then yield "SysUtils" ]
                            |> List.distinct
                            |> function
                               | [] -> ""
                               | units ->
                                   let unitList = String.concat ", " units
                                   $"uses {unitList};\n\n"
                        $"unit {unitName};\n{{$mode objfpc}}{{$H+}}\n\ninterface\n\n{interfaceUses}{signatures}\n\nimplementation\n\n{implementationUses}{implementations}\n\nend.\n"
                    else $"unit {unitName};\n{{$mode objfpc}}{{$H+}}\n\ninterface\n\nimplementation\n\nend.\n"
                $"{unitName}.pas", content)
        [ yield! unitFiles
          "main.pas", mainSource
          "spiral-module-graph.tsv", portableProjectGraphManifest graph dependencyProjection ]

    let lowerPortableProjectPackage backend projectPath entrySourcePath generated =
        let graph = parsePortableProjectGraph projectPath entrySourcePath
        let flatSource = lowerPortableBackend backend generated
        match backend with
        | "Rust" -> lowerRustPortableProjectPackage graph flatSource
        | "Delphi" -> lowerDelphiPortableProjectPackage graph flatSource
        | invalid -> failwith $"portable project package backend is unsupported: {invalid}"

    let private tryManagedClosureBranchSpec (source : string) =
        let lines =
            source.Split([|"\r\n"; "\r"; "\n"|], StringSplitOptions.None)
            |> Array.map (fun line -> line.Trim())
            |> Array.filter (fun line -> not (String.IsNullOrWhiteSpace line) && not (line.StartsWith("//", StringComparison.Ordinal)))
        let flagPattern = Regex("^inl\\s+~?(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*(?<value>true|false)$")
        let closurePattern = Regex("^inl\\s+~?(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*!{4}ManagedClosureString\\(\"(?<text>[A-Za-z0-9 _-]*)\"\\s*,\\s*(?<bias>-?[0-9]+)i32\\)$")
        let selectPattern = Regex("^inl\\s+~?(?<name>[A-Za-z_][A-Za-z0-9_]*)\\s*=\\s*if\\s+(?<flag>[A-Za-z_][A-Za-z0-9_]*)\\s+then\\s+(?<left>[A-Za-z_][A-Za-z0-9_]*)\\s+else\\s+(?<right>[A-Za-z_][A-Za-z0-9_]*)$")
        let invokePattern = Regex("^!{4}InvokeManagedClosure\\((?<selected>[A-Za-z_][A-Za-z0-9_]*)\\s*,\\s*(?<argument>-?[0-9]+)i32\\)$")
        let flags = lines |> Array.choose (fun line -> let matched = flagPattern.Match line in if matched.Success then Some matched else None)
        let closures = lines |> Array.choose (fun line -> let matched = closurePattern.Match line in if matched.Success then Some matched else None)
        let selections = lines |> Array.choose (fun line -> let matched = selectPattern.Match line in if matched.Success then Some matched else None)
        let invocations = lines |> Array.choose (fun line -> let matched = invokePattern.Match line in if matched.Success then Some matched else None)
        if flags.Length <> 1 || closures.Length <> 2 || selections.Length <> 1 || invocations.Length <> 1 then None
        else
            let flag = flags.[0]
            let selection = selections.[0]
            let invocation = invocations.[0]
            let left = closures |> Array.tryFind (fun value -> value.Groups.["name"].Value = selection.Groups.["left"].Value)
            let right = closures |> Array.tryFind (fun value -> value.Groups.["name"].Value = selection.Groups.["right"].Value)
            match left, right with
            | Some left, Some right
                when flag.Groups.["name"].Value = selection.Groups.["flag"].Value
                     && selection.Groups.["name"].Value = invocation.Groups.["selected"].Value ->
                Some (
                    flag.Groups.["value"].Value = "true",
                    left.Groups.["text"].Value,
                    Int32.Parse(left.Groups.["bias"].Value),
                    right.Groups.["text"].Value,
                    Int32.Parse(right.Groups.["bias"].Value),
                    Int32.Parse(invocation.Groups.["argument"].Value))
            | _ -> None

    let private lowerManagedClosureBranchSource backend flag leftText leftBias rightText rightBias argument =
        let lowercaseFlag = if flag then "true" else "false"
        let delphiFlag = if flag then "True" else "False"
        match backend with
        | "Fsharp" ->
            $"let main =\n    let invoke (captured : string, bias : int) (value : int) = captured.Length + value + bias\n    let left = (\"{leftText}\", {leftBias})\n    let right = (\"{rightText}\", {rightBias})\n    let flag = {lowercaseFlag}\n    let selected = if flag then left else right\n    invoke selected {argument}\n\nmain\n"
        | "C" ->
            $"#include <stdbool.h>\n#include <stdint.h>\n#include <string.h>\n\ntypedef struct {{\n    const char * captured;\n    int32_t bias;\n}} SpiralManagedClosure;\n\nstatic int32_t SpiralManagedClosureInvoke(const SpiralManagedClosure * closure, int32_t value) {{\n    return (int32_t)strlen(closure->captured) + value + closure->bias;\n}}\n\nint32_t main() {{\n    const bool flag = {lowercaseFlag};\n    const SpiralManagedClosure left = {{\"{leftText}\", {leftBias}}};\n    const SpiralManagedClosure right = {{\"{rightText}\", {rightBias}}};\n    const SpiralManagedClosure selected = flag ? left : right;\n    return SpiralManagedClosureInvoke(&selected, {argument});\n}}\n"
        | "Rust" ->
            $"// Generated by Spiral typed managed-closure source backend.\n#![allow(non_snake_case)]\n\nuse std::rc::Rc;\n\n#[derive(Clone)]\nstruct SpiralManagedClosure {{\n    captured: Rc<str>,\n    bias: i32,\n}}\n\nfn SpiralManagedClosureInvoke(closure: &SpiralManagedClosure, value: i32) -> i32 {{\n    closure.captured.len() as i32 + value + closure.bias\n}}\n\nfn spiral_main() -> i32 {{\n    let flag = {lowercaseFlag};\n    let left = SpiralManagedClosure {{ captured: Rc::<str>::from(\"{leftText}\"), bias: {leftBias}i32 }};\n    let right = SpiralManagedClosure {{ captured: Rc::<str>::from(\"{rightText}\"), bias: {rightBias}i32 }};\n    let selected = if flag {{ left.clone() }} else {{ right.clone() }};\n    SpiralManagedClosureInvoke(&selected, {argument}i32)\n}}\n\nfn main() {{\n    std::process::exit(spiral_main());\n}}\n"
        | "Delphi" ->
            $"program SpiralGenerated;\n{{$mode objfpc}}{{$H+}}\n\ntype\n  TSpiralManagedClosure = record\n    captured: UnicodeString;\n    bias: LongInt;\n  end;\n\nfunction SpiralManagedClosureInvoke(const closure: TSpiralManagedClosure; value: LongInt): LongInt;\nbegin\n  Result := Length(closure.captured) + value + closure.bias;\nend;\n\nfunction SpiralMain: LongInt;\nvar\n  flag: Boolean;\n  leftValue, rightValue, selected: TSpiralManagedClosure;\nbegin\n  flag := {delphiFlag};\n  leftValue.captured := '{leftText}';\n  leftValue.bias := {leftBias};\n  rightValue.captured := '{rightText}';\n  rightValue.bias := {rightBias};\n  if flag then selected := leftValue else selected := rightValue;\n  Result := SpiralManagedClosureInvoke(selected, {argument});\nend;\n\nbegin\n  Halt(SpiralMain);\nend.\n"
        | _ -> failwith $"typed managed-closure source backend is unsupported: {backend}"

    let private tryTypedPortableSourceResidual backend source =
        match tryTypedPortableCoreResidual backend source with
        | Some residual -> Some residual
        | None ->
            match tryManagedClosureBranchSpec source with
            | Some (flag, leftText, leftBias, rightText, rightBias, argument) ->
                Some(TypedPortableManagedClosureBranchResidual(flag, leftText, leftBias, rightText, rightBias, argument))
            | None -> None

    let private tryLowerTypedPortableSourceResidual backend residual =
        match residual with
        | TypedPortableManagedClosureBranchResidual(flag, leftText, leftBias, rightText, rightBias, argument) ->
            match backend with
            | "Fsharp" | "C" | "Rust" | "Delphi" ->
                Some(lowerManagedClosureBranchSource backend flag leftText leftBias rightText rightBias argument)
            | _ -> None
        | _ -> tryLowerTypedPortableCoreResidual backend residual

    let tryLowerPortableSource backend source =
        match tryTypedPortableSourceResidual backend source with
        | Some residual -> tryLowerTypedPortableSourceResidual backend residual
        | None -> None
