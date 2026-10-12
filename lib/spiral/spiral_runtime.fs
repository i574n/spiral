#if !INTERACTIVE
module Lib
#endif

open System
open System.IO

module SpiralTrace =
    type TraceLevel =
        | Verbose
        | Debug
        | Info
        | Warning
        | Critical

    let private severity = function
        | Verbose -> 10
        | Debug -> 20
        | Info -> 30
        | Warning -> 40
        | Critical -> 50

    let private levelLetter = function
        | Verbose -> "v"
        | Debug -> "d"
        | Info -> "i"
        | Warning -> "w"
        | Critical -> "c"

    let private levelColor = function
        | Verbose -> "\u001b[90m"
        | Debug -> "\u001b[94m"
        | Info -> "\u001b[92m"
        | Warning -> "\u001b[33m"
        | Critical -> "\u001b[91m"

    let private colorReset = "\u001b[0m"

    let private levelFromName = function
        | "Verbose" -> Some Verbose
        | "Debug" -> Some Debug
        | "Info" -> Some Info
        | "Warning" -> Some Warning
        | "Critical" -> Some Critical
        | _ -> None

    type private ClockOrigin =
        | WallClock
        | AutomationStart of startTicks : int64

    type private TraceState =
        {
            mutable Count : int64
            mutable Level : TraceLevel
            mutable Enabled : bool
            Origin : ClockOrigin
        }

    let private state =
        lazy
            {
                Count = 1L
                Level = Environment.GetEnvironmentVariable "TRACE_LEVEL" |> levelFromName |> Option.defaultValue Verbose
                Enabled = true
                Origin =
                    if Environment.GetEnvironmentVariable "AUTOMATION" = "True" then AutomationStart DateTime.Now.Ticks
                    else WallClock
            }

    let set_trace_level (level : TraceLevel) = state.Value.Level <- level
    let get_trace_level () = state.Value.Level

    let private clockText () =
        match state.Value.Origin with
        | WallClock -> DateTime.Now.ToString "HH:mm:ss"
        | AutomationStart startTicks ->
            let elapsed = TimeSpan(DateTime.Now.Ticks - startTicks)
            DateTime(1, 1, 1, elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds).ToString "HH:mm:ss"

    let private isEmitted level =
        state.Value.Enabled && severity level >= severity state.Value.Level

    let private traceLine level (text : string) (locals : string) =
        if text = "" then ""
        else
            let levelText = levelColor level + levelLetter level + colorReset
            let localsText = if locals = "" then "" else " / " + locals
            $"{clockText ()} {levelText} #{state.Value.Count} {text}{localsText}".TrimStart().TrimEnd [| ' '; '/' |]

    let trace (level : TraceLevel) (text : unit -> string) (locals : unit -> string) =
        if isEmitted level then
            let line = traceLine level (text ()) (locals ())
            state.Value.Count <- state.Value.Count + 1L
            Console.WriteLine line

module SpiralCrypto =
    let hash_text (input : string) =
        Security.Cryptography.SHA256.HashData (Text.Encoding.UTF8.GetBytes input)
        |> Array.map (fun byte -> byte.ToString "x2")
        |> String.concat ""

module SpiralSm =
    let format_exception (error : exn) = $"{error.GetType ()}: {error.Message}"
    let concat (separator : string) (values : string seq) = String.concat separator values
    let starts_with (prefix : string) (text : string) = text.StartsWith (prefix, false, null)
    let slice (fromIndex : int) (throughIndex : int) (text : string) = text.[fromIndex..throughIndex]

    let ellipsis_end (maximum : int64) (text : string) =
        let length = int64 text.Length
        if length <= maximum then text
        else
            let half = float maximum / 2.0
            let head = text.[0 .. int (ceil half) - 1]
            let tail = text.[int (length - int64 (floor half)) .. int length - 1]
            head + "..." + tail

    let replace (oldValue : string) (newValue : string) (text : string) = text.Replace (oldValue, newValue)
    let split_string (separators : string array) (text : string) = text.Split (separators, StringSplitOptions.None)
    let trim (text : string) = text.Trim ()
    let trim_start (characters : char array) (text : string) = text.TrimStart characters

module SpiralPlatform =
    let is_windows () = OperatingSystem.IsWindows ()
    let get_executable_suffix () = if is_windows () then ".exe" else ""

let new_disposable (dispose : unit -> unit) : IDisposable =
    { new IDisposable with member _.Dispose () = dispose () }

let retry_fn (attempts : int) (operation : unit -> 'result) : 'result option =
    let rec attempt (retry : int) =
        if retry >= attempts then None
        else
            try Some (operation ())
            with error ->
                SpiralTrace.trace SpiralTrace.Warning (fun () -> "common.retry_fn") (fun () -> $"{{ retry = {retry}; ex = {error} }}")
                attempt (retry + 1)
    attempt 0

module SpiralFileSystem =
    type private ReadAttempt =
        | FirstAttempt
        | Retry of number : int64

    type private LockedFileRead =
        | InitialRead
        | RereadAfterFailure

    let private maximumRetry = 3L
    let private retryDelayMs = 10

    let read_all_text_async (path : string) : Async<string> =
        let rec attempt (current : ReadAttempt) =
            async {
                try
                    return! File.ReadAllTextAsync path |> Async.AwaitTask
                with _ ->
                    do! Async.Sleep retryDelayMs
                    match current with
                    | FirstAttempt -> return! attempt (Retry 1L)
                    | Retry number when number < maximumRetry -> return! attempt (Retry (number + 1L))
                    | Retry number -> return failwith $"file_system.read_all_text_async / retry: {number} / path: {path}"
            }
        attempt FirstAttempt

    let read_all_text_retry_async (path : string) : Async<string option> =
        let rec read (current : LockedFileRead) =
            async {
                try
                    let! text = read_all_text_async path
                    return Some text
                with _ ->
                    match current with
                    | InitialRead -> return! read RereadAfterFailure
                    | RereadAfterFailure -> return None
            }
        read InitialRead

    let write_all_text_async (path : string) (text : string) : Async<unit> =
        File.WriteAllTextAsync (path, text) |> Async.AwaitTask

    type private FileOperationAttempt =
        | Attempted of retries : int64

    let private retryFileOperation (operation : unit -> unit) : Async<int64> =
        let rec attempt (Attempted retries) =
            async {
                try
                    operation ()
                    return retries
                with _ when retries < maximumRetry ->
                    do! Async.Sleep retryDelayMs
                    return! attempt (Attempted (retries + 1L))
            }
        attempt (Attempted 0L)

    let delete_file_async (path : string) : Async<int64> =
        retryFileOperation (fun () -> File.Delete path)

    let move_file_async (newPath : string) (oldPath : string) : Async<int64> =
        retryFileOperation (fun () -> File.Move (oldPath, newPath, true))

    let private hashGuid (hash : string) =
        let digits = hash.PadLeft (32, '0')
        Guid $"{digits.[0..7]}-{digits.[8..11]}-{digits.[12..15]}-{digits.[16..19]}-{digits.[20..31]}"

    let private temporaryPathFor (guid : Guid) =
        let entryAssembly = Reflection.Assembly.GetEntryAssembly ()
        let entryName = if isNull entryAssembly then "" else entryAssembly.GetName().Name
        Path.Combine (Path.GetTempPath (), "!create_temp_path_", entryName, string guid)

    let private createDirectory (directory : string) : IDisposable =
        Directory.CreateDirectory directory |> ignore
        new_disposable (fun () -> if Directory.Exists directory then Directory.Delete (directory, true))

    let create_temp_dir () : struct (string * IDisposable) =
        let directory = temporaryPathFor (Guid.NewGuid ())
        struct (directory, createDirectory directory)

    let create_temp_dir' (hash : string) : struct (string * IDisposable) =
        let directory = temporaryPathFor (hashGuid hash)
        struct (directory, createDirectory directory)

    module Operators =
        let (</>) (left : string) (right : string) = Path.Combine (left, right)
