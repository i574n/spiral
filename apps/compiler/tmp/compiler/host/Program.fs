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
        | Some _ -> "(expression)"
        | None -> failwith "generated F# has no terminal expression"

    let private writeEntryManifest outputPath entryBinding generatedBytes revisionMode backend =
        if String.Equals(Environment.GetEnvironmentVariable "SPIRAL_WRITE_ENTRY_MANIFEST", "1", StringComparison.Ordinal) then
            let manifestPath = outputPath + ".spiral-entry"
            let text =
                $"schema=3\nentry_binding={entryBinding}\nbackend={backend}\nserver_pid={Environment.ProcessId}\ngenerated_bytes={generatedBytes}\nrevision_mode={revisionMode}\n"
            File.WriteAllText(manifestPath, text)

    let private traceDiagnostics =
        String.Equals(Environment.GetEnvironmentVariable "SPIRAL_HOST_TRACE_DIAGNOSTICS", "1", StringComparison.Ordinal)

    let private fatalGraceMs =
        match Int32.TryParse(Environment.GetEnvironmentVariable "SPIRAL_HOST_FATAL_GRACE_MS") with
        | true, value when value >= 0 -> value
        | _ -> 750

    let private normalizeUri (uri : string) =
        Uri.UnescapeDataString(uri).Replace('\\', '/').TrimEnd('/')

    let private sameUri (a : string) (b : string) =
        String.Equals(normalizeUri a, normalizeUri b, StringComparison.OrdinalIgnoreCase)

    let private renderTracedError (message : string) (trace : string list) =
        let message = "TracedError: " + (if isNull message then "" else message.TrimEnd())
        match trace with
        | [] -> message
        | frames ->
            let frames =
                frames
                |> List.map (fun (frame : string) -> "  " + (if isNull frame then "" else frame.TrimEnd().Replace("\n", "\n  ")))
                |> String.concat "\n"
            message + "\ntrace (innermost first):\n" + frames

    let private diagnosticFor uri = function
        | TypeErrors x when sameUri x.uri uri && not (List.isEmpty x.errors) ->
            Some $"TypeErrors: %A{x.errors}"
        | TokenizerErrors x when sameUri x.uri uri && not (List.isEmpty x.errors) ->
            Some $"TokenizerErrors: %A{x.errors}"
        | PackageErrors x when not (List.isEmpty x.errors) ->
            Some $"PackageErrors ({x.uri}): %A{x.errors}"
        | TracedError x -> Some (renderTracedError x.message x.trace)
        | _ -> None

    let private diagnosticForOther = function
        | TypeErrors x when not (List.isEmpty x.errors) -> Some $"TypeErrors ({x.uri}): %A{x.errors}"
        | ParserErrors x when not (List.isEmpty x.errors) -> Some $"ParserErrors ({x.uri}): %A{x.errors}"
        | TokenizerErrors x when not (List.isEmpty x.errors) -> Some $"TokenizerErrors ({x.uri}): %A{x.errors}"
        | _ -> None

    type private DiagnosticRouter() =
        let gate = obj()
        let mutable active : (string * Threading.Tasks.TaskCompletionSource<string>) option = None
        let mutable related : string option = None
        let mutable entryTypeErrors : string option = None

        member _.Begin(uri) =
            let waiter =
                new Threading.Tasks.TaskCompletionSource<string>(
                    Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously)
            lock gate (fun () -> active <- Some (uri, waiter); related <- None; entryTypeErrors <- None)
            waiter

        member _.Clear(waiter : Threading.Tasks.TaskCompletionSource<string>) =
            lock gate (fun () ->
                match active with
                | Some (_, current) when Object.ReferenceEquals(current, waiter) -> active <- None
                | _ -> ())

        member _.Accept(message : ClientErrorsRes) =
            if traceDiagnostics then eprintfn "[diagnostic] %A" message
            match message with
            | FatalError fatal when lock gate (fun () -> entryTypeErrors.IsSome) ->
                lock gate (fun () ->
                    match active with
                    | Some (_, waiter) -> waiter.TrySetResult($"FatalError: {fatal}") |> ignore
                    | None -> ())
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
                        | Some diagnostic when (match message with TypeErrors _ -> true | _ -> false) ->
                            entryTypeErrors <- Some diagnostic
                            Threading.Tasks.Task.Delay(1000).ContinueWith(fun (_ : Threading.Tasks.Task) ->
                                waiter.TrySetResult(diagnostic) |> ignore)
                            |> ignore
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

    type private CompilationCache(reuse : bool) =
        let entries = Dictionary<string,CachedCompilation>(StringComparer.Ordinal)
        let key uri backend = backend + "\u0000" + uri

        member _.Reuse = reuse

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


    let private rewriteRustEmitExpr (generated : string) =
        if not (generated.Contains("__spiral_emit_rust", StringComparison.Ordinal)) then generated
        else
            let lines = generated.Split([|"\r\n"; "\n"|], StringSplitOptions.None)
            let bindingPattern = Regex(@"^\s*let mut (v[0-9]+): Rc<str> = (""(?:\\.|[^""\\])*"");\s*$")
            let emitPattern = Regex(@"^(?<prefix>\s*let mut v[0-9]+: [^=]+ = )__spiral_emit_rust (?<args>.*?) (?<code>v[0-9]+) ;\s*$")
            let unescape (literal : string) =
                let body = literal.Substring(1, literal.Length - 2)
                let text = StringBuilder()
                let mutable i = 0
                while i < body.Length do
                    if body.[i] = '\\' && i + 1 < body.Length then
                        match body.[i + 1] with
                        | 'n' -> text.Append('\n') |> ignore
                        | 'r' -> text.Append('\r') |> ignore
                        | 't' -> text.Append('\t') |> ignore
                        | '"' -> text.Append('"') |> ignore
                        | '\\' -> text.Append('\\') |> ignore
                        | other -> text.Append('\\').Append(other) |> ignore
                        i <- i + 2
                    else
                        text.Append(body.[i]) |> ignore
                        i <- i + 1
                text.ToString()
            let splitArgs (value : string) =
                let value = value.Trim()
                if value = "()" then []
                else
                    let body =
                        if value.Length >= 2 && value.[0] = '(' && value.[value.Length - 1] = ')' then
                            value.Substring(1, value.Length - 2)
                        else value
                    if not (body.Contains ',') then [body.Trim()]
                    else
                        let parts = ResizeArray<string>()
                        let mutable start = 0
                        let mutable depth = 0
                        for index = 0 to body.Length - 1 do
                            match body.[index] with
                            | '(' -> depth <- depth + 1
                            | ')' -> depth <- depth - 1
                            | ',' when depth = 0 ->
                                parts.Add(body.Substring(start, index - start).Trim())
                                start <- index + 1
                            | _ -> ()
                        parts.Add(body.Substring(start).Trim())
                        parts |> Seq.filter (fun part -> part <> "") |> Seq.toList
            let borrow (argument : string) =
                let cloned = Regex.Match(argument, @"^v[0-9]+\.clone\(\)$")
                if cloned.Success then argument.Substring(0, argument.Length - ".clone()".Length) else argument
            let snippets = Dictionary<string, string>(StringComparer.Ordinal)
            let bindingLine = Dictionary<string, int>(StringComparer.Ordinal)
            let drop = HashSet<int>()
            let rewritten = Array.copy lines
            for index = 0 to lines.Length - 1 do
                let binding = bindingPattern.Match lines.[index]
                if binding.Success then
                    let name = binding.Groups.[1].Value
                    snippets.[name] <- unescape binding.Groups.[2].Value
                    bindingLine.[name] <- index
                let emitted = emitPattern.Match lines.[index]
                if emitted.Success then
                    let code = emitted.Groups.["code"].Value
                    match snippets.TryGetValue code, bindingLine.TryGetValue code with
                    | (true, payload), (true, lineIndex) ->
                        drop.Add lineIndex |> ignore
                        let args = splitArgs emitted.Groups.["args"].Value |> List.map borrow
                        let mutable expression = payload
                        for argIndex = args.Length - 1 downto 0 do
                            expression <- expression.Replace($"${argIndex}", args.[argIndex])
                        rewritten.[index] <- emitted.Groups.["prefix"].Value + expression + ";"
                    | _ -> ()
            rewritten
            |> Array.mapi (fun index line -> if drop.Contains index then None else Some line)
            |> Array.choose id
            |> String.concat "\n"

    let private multiFileSuffixes = function
        | "Cpp + Cuda" -> Some [ ".corelib.hpp"; ".hpp"; ".cpp"; ".cu" ]
        | "Python + Cuda" -> Some [ "_auto.py"; ".py" ]
        | _ -> None

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
            let fingerprint = if cache.Reuse then sourceGraphFingerprint inputPath else ""
            let multiFile = multiFileSuffixes backend
            let started = DateTime.UtcNow
            let cached =
                match revision with
                | SourceUnchanged when multiFile.IsNone && cache.Reuse -> cache.TryGet(uri, backend, fingerprint)
                | _ -> None
            let revisionMode =
                match cached, revision with
                | Some _, _ -> "cache-hit"
                | None, OpenSource _ -> "open"
                | None, SourceUnchanged -> "unchanged"
                | None, ChangeSource _ -> "change"
            if cached.IsNone then warmModulePipeline code
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
            let coreOutputs =
                let coreBase = Path.ChangeExtension(inputPath, null)
                match multiFile with
                | Some suffixes -> suffixes |> List.map (fun suffix -> coreBase + suffix)
                | None -> [ Path.ChangeExtension(inputPath, Path.GetExtension outputPath) ]
            let elsewhere =
                let outBase = Path.Combine(Path.GetDirectoryName(Path.GetFullPath outputPath), Path.GetFileNameWithoutExtension outputPath)
                not (String.Equals(Path.GetFullPath(Path.ChangeExtension(inputPath, null)), outBase, StringComparison.OrdinalIgnoreCase))
            let coreSnapshots =
                if elsewhere then coreOutputs |> List.map (fun path -> path, (if File.Exists path then Some (File.ReadAllBytes path) else None))
                else []
            let restoreCoreOutputs () =
                for path, before in coreSnapshots do
                    try
                        match before with
                        | Some bytes -> if not (File.Exists path && File.ReadAllBytes path = bytes) then File.WriteAllBytes(path, bytes)
                        | None -> if File.Exists path then File.Delete path
                    with _ -> ()
            let waiter = router.Begin uri
            try
                if cached.IsNone then
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

                let buildTask =
                    match cached with
                    | Some cached -> Threading.Tasks.Task.FromResult cached.generated
                    | None ->
                        jobVal (fun result ->
                            buildFileRequest uri backend result
                            |> fun request -> supervisor *<+ request)
                let winner =
                    Threading.Tasks.Task.WhenAny(buildTask :> Threading.Tasks.Task, waiter.Task :> Threading.Tasks.Task)
                        .GetAwaiter().GetResult()

                if Object.ReferenceEquals(winner, waiter.Task) then
                    Error (waiter.Task.GetAwaiter().GetResult())
                else
                    let generated = buildTask.GetAwaiter().GetResult()
                    if isNull generated then
                        if waiter.Task.Wait(TimeSpan.FromMilliseconds(float (fatalGraceMs + 10000))) then Error (waiter.Task.GetAwaiter().GetResult())
                        else Error "BuildFile returned no code and no diagnostic arrived"
                    else
                        let coreWrites = cached.IsNone
                        let generated = if coreWrites && backend = "Rust" then rewriteRustEmitExpr generated else generated
                        let parent = Path.GetDirectoryName outputPath
                        if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory parent |> ignore
                        let coreFile = Path.ChangeExtension(inputPath, Path.GetExtension outputPath)
                        match multiFile with
                        | Some suffixes ->
                            let coreBase = Path.ChangeExtension(inputPath, null)
                            let outBase = Path.Combine(Path.GetDirectoryName outputPath, Path.GetFileNameWithoutExtension outputPath)
                            let deadline = DateTime.UtcNow.AddSeconds 5.0
                            let landed (suffix : string) =
                                let path = coreBase + suffix
                                File.Exists path && File.GetLastWriteTimeUtc path >= started.AddSeconds -2.0
                            while not (suffixes |> List.forall landed) && DateTime.UtcNow < deadline do
                                Threading.Thread.Sleep 20
                            if not (String.Equals(Path.GetFullPath coreBase, Path.GetFullPath outBase, StringComparison.OrdinalIgnoreCase)) then
                                for suffix in suffixes do
                                    let source = coreBase + suffix
                                    if File.Exists source then File.Copy(source, outBase + suffix, true)
                        | None ->
                            if coreWrites && String.Equals(Path.GetFullPath coreFile, outputPath, StringComparison.OrdinalIgnoreCase) then
                                if not (awaitCoreWrite outputPath generated) then writeWithRetry outputPath generated 0
                            else
                                writeWithRetry outputPath generated 0
                                if coreWrites && not coreSnapshots.IsEmpty then awaitCoreWrite coreFile generated |> ignore
                        restoreCoreOutputs ()
                        let binding =
                            match cached with
                            | Some cached -> cached.binding
                            | None when String.Equals(backend, "Fsharp", StringComparison.Ordinal) -> discoverEntryBinding generated
                            | None -> "main"
                        if multiFile.IsNone && cache.Reuse then cache.Put(uri, backend, fingerprint, generated, binding)
                        writeEntryManifest outputPath binding generated.Length revisionMode backend
                        Ok (generated.Length, binding, revisionMode)
            finally
                restoreCoreOutputs ()
                router.Clear waiter
        with error -> Error error.Message

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
        let bodyMatch = Regex.Match(code.Substring(spiralMain.Index), @"(?ms)^fn spiral_main\(\) -> i32 \{\r?\n(?<body>.*?)^\}")
        if not bodyMatch.Success then failwith "canonical plan IR has no complete entry body"
        let spiralBody = bodyMatch.Groups.["body"].Value
        let markers = marker.Matches spiralBody
        if markers.Count = 0 then failwith "canonical plan IR provider emitted no RustPlanOp markers"
        if marker.Matches(code).Count <> markers.Count then
            failwith "canonical plan IR markers must be contained entirely in spiral_main"
        let remainder = binding.Replace(marker.Replace(spiralBody, ""), "").Trim()
        if not (Regex.IsMatch(remainder, @"\A(?:return\s+)?0(?:i32|i64|u32|u64|i8|i16|u8|u16|isize|usize)?;?\s*\z")) then
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
            if not state.packages_infer.error.IsEmpty then
                let failedPackages =
                    state.packages_infer.error
                    |> Map.toList
                    |> List.map (fun (pid, _) -> snd state.package_ids |> Map.tryFind pid |> Option.map string |> Option.defaultWith (fun () -> string pid))
                    |> String.concat ", "
                failwith $"Package graph rejected: {packageDir}; packages that failed to type check: {failedPackages}. A packages: entry that does not resolve (|core- needs SPIRAL_COMPILER_PACKAGE_DIR or a deps/The-Spiral-Language clone) leaves the packages importing it unchecked."
            let pid = (fst state.package_ids).[packageDir]
            let package = state.packages_infer.ok.[pid]
            let rec containsInput = function
                | ProjFilesTree.File(_, path, _) -> String.Equals(path, inputPath, StringComparison.Ordinal)
                | ProjFilesTree.Directory(_, _, children) -> List.exists containsInput children
            if not (package.files.files.tree |> List.exists containsInput) then
                failwith $"Check input is not declared in package: {inputPath}"
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
        let cache = CompilationCache(false)
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
        | ".zig" -> "Zig"
        | ".wat" -> "Wasm"
        | ".lean" -> "Lean"
        | ".bend" -> "Bend"
        | ".py" -> "Python + Cuda"
        | ".cpp" -> "Cpp + Cuda"
        | ".lua" -> "Lua"
        | ".gleam" -> "Gleam"
        | ".ts" | ".mts" -> "TypeScript"
        | other -> failwith $"cannot infer a backend from output extension '{other}'; pass --backend"

    let private stallDetail () =
#if SPIRAL_CORE_HOPAC
        try $"; stalled at stage {buildFileInitializationStageNow ()}" with _ -> ""
#else
        ""
#endif

    let private runBatch (jobsPath : string) (resultsPath : string) (timeoutMs : int) =
        let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
        let router = DiagnosticRouter()
        let revisions = SourceRevisionStore()
        startDiagnosticPump server.errors router
        let jobs =
            File.ReadAllLines jobsPath
            |> Array.filter (fun line -> not (String.IsNullOrWhiteSpace line) && not (line.StartsWith "#"))
        let cache = CompilationCache(jobs.Length > 1)
        let budgetFromCaller = not (String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable "SPIRAL_BUILD_BUDGET_MS"))
        use results = new StreamWriter(resultsPath, true, UTF8Encoding(false))
        results.AutoFlush <- true
        let recycleAfterError = String.Equals(Environment.GetEnvironmentVariable "SPIRAL_BATCH_RECYCLE_AFTER_ERROR", "1", StringComparison.Ordinal)
        let mutable exitCode = 0
        let mutable index = 0
        let mutable timedOut = false
        let mutable recycle = false
        let mutable failureDeferredToFreshProcess = false
        while not timedOut && not recycle && index < jobs.Length do
            let fields = jobs.[index].Split('\t')
            let id, backend, input, output = fields.[0], fields.[1], fields.[2], fields.[3]
            let jobTimeoutMs = if fields.Length >= 5 && not (String.IsNullOrWhiteSpace fields.[4]) then int fields.[4] else timeoutMs
            let failureMayComeFromEarlierBuild = recycleAfterError && index > 0
            let recordFailure (line : string) =
                recycle <- recycleAfterError
                if failureMayComeFromEarlierBuild then failureDeferredToFreshProcess <- true
                else results.WriteLine line
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
                        recordFailure $"{id}\terror\t{stopwatch.ElapsedMilliseconds}\t{cleanProtocolText message}"
                elif failureMayComeFromEarlierBuild then
                    recordFailure ""
                else
                    exitCode <- 3
                    timedOut <- true
                    results.WriteLine($"{id}\ttimeout\t{stopwatch.ElapsedMilliseconds}\tno result within {jobTimeoutMs} ms{stallDetail ()}")
            with error ->
                exitCode <- 1
                recordFailure $"{id}\terror\t{stopwatch.ElapsedMilliseconds}\t{cleanProtocolText error.Message}"
            if not failureDeferredToFreshProcess then index <- index + 1
        if recycle && index < jobs.Length then 4 else exitCode

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
        let cache = CompilationCache(true)
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

    let private parseBuildFileArgs (argv : string []) =
        let positional = ResizeArray<string>()
        let mutable timeoutMs = 60 * 60 * 1000
        let mutable exitOnError = false
        let mutable error = None
        let mutable i = 1
        while error.IsNone && i < argv.Length do
            match argv.[i] with
            | "--build-file" | "build-file" -> i <- i + 1
            | "--exit-on-error" -> exitOnError <- true; i <- i + 1
            | "--timeout" | "--timeout-ms" when i + 1 < argv.Length ->
                (match Int32.TryParse argv.[i + 1] with
                 | true, ms when ms > 0 -> timeoutMs <- ms; i <- i + 2
                 | _ -> error <- Some $"{argv.[i]} must be a positive 32-bit integer")
            | "--spi-path" | "-s" when i + 1 < argv.Length -> positional.Add argv.[i + 1]; i <- i + 2
            | x when x.StartsWith "-" -> error <- Some $"unknown option {x}"
            | x -> positional.Add x; i <- i + 1
        match error with
        | Some e -> Error e
        | None ->
            try
                if argv.[0] = "fsharp" then
                    if positional.Count = 0 then Error "fsharp: no input .spi"
                    else Ok ([ for x in positional -> "Fsharp", x, Path.ChangeExtension(x, ".fsx") ], timeoutMs, exitOnError)
                elif positional.Count = 0 || positional.Count % 2 <> 0 then Error "build-file: expected IN OUT pairs"
                else Ok ([ for k in 0 .. 2 .. positional.Count - 1 -> backendOfOutput positional.[k + 1], positional.[k], positional.[k + 1] ], timeoutMs, exitOnError)
            with e -> Error e.Message

    let private runBuildFiles (jobs : (string * string * string) list) (timeoutMs : int) (exitOnError : bool) =
        let mutable result = 5
        let work () =
            let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
            let router = DiagnosticRouter()
            let revisions = SourceRevisionStore()
            let cache = CompilationCache(List.length jobs > 1)
            startDiagnosticPump server.errors router
            let mutable failed = 0
            for backend, input, output in jobs do
                if not (exitOnError && failed > 0) then
                    match compileOne server.supervisor router revisions cache server.job_val backend input output with
                    | Ok (bytes, binding, revisionMode) ->
                        printfn "compiled %s -> %s (%s, %d bytes, entry=%s, revision=%s, pid=%d)" input output backend bytes binding revisionMode Environment.ProcessId
                    | Error message ->
                        eprintfn "%s" message
                        failed <- failed + 1
            result <- if failed = 0 then 0 else 5
        let thread = Threading.Thread(Threading.ThreadStart(fun () -> try work () with error -> eprintfn "%s" error.Message), 64 * 1024 * 1024)
        thread.IsBackground <- true
        thread.Start()
        if thread.Join timeoutMs then exit result
        else
            eprintfn "build-file timed out after %d ms" timeoutMs
            exit 3

    [<EntryPoint>]
    let main argv =
        configureHopacFromEnvironment ()
        if isNull (Environment.GetEnvironmentVariable "SPIRAL_HOVERS") then Environment.SetEnvironmentVariable("SPIRAL_HOVERS", "0")
        if argv.Length = 1 && argv.[0] = "--version" then
            printfn "SpiralCompiler alpha418"
            0
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
            exit (runBatch argv.[1] argv.[2] timeoutMs)
        elif argv.Length >= 1 && (argv.[0] = "build-file" || argv.[0] = "--build-file" || argv.[0] = "fsharp") then
            match parseBuildFileArgs argv with
            | Ok (jobs, timeoutMs, exitOnError) -> runBuildFiles jobs timeoutMs exitOnError
            | Error message ->
                eprintfn "%s" message
                2
        elif argv.Length = 2 || (argv.Length = 4 && argv.[0] = "--backend") then
            let backend, input, output =
                if argv.Length = 4 then argv.[1], argv.[2], argv.[3]
                else backendOfOutput argv.[1], argv.[0], argv.[1]
            let backend = match backend with "Cpp" -> "Cpp + Cuda" | "Python" -> "Python + Cuda" | b -> b
            let server = new_server<Job<unit>, obj, string option, Job<unit>, unit> ()
            let router = DiagnosticRouter()
            let revisions = SourceRevisionStore()
            let cache = CompilationCache(false)
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
            eprintfn "usage: SpiralCompiler [--backend Fsharp|C|Rust|Delphi|Zig|TypeScript|Lua|Gleam|\"Cpp + Cuda\"|\"Python + Cuda\"] <input.spi> <output.fsx|.c|.rs|.pas|.zig|.ts|.lua|.gleam|.cpp|.py> | --check INPUT.spi | --plan-ir [--timeout-ms N] INPUT.spi OUTPUT.ir | --batch JOBS.tsv RESULTS.tsv [--timeout-ms N] | --server SOCKET INPUT.spi | build-file IN OUT [IN OUT ...] [--timeout MS] [--exit-on-error] | fsharp IN.spi [--timeout MS]"
            2
