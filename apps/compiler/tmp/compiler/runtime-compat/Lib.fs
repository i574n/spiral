module Lib

open System
open System.IO
open System.Security.Cryptography
open System.Text
open Microsoft.FSharp.Core

let mutable private currentTraceLevel = Trace.US0.US0_0

let set_trace_level (new_level : Trace.US0) =
    currentTraceLevel <- new_level

let get_trace_level () = currentTraceLevel

module SpiralTrace =
    type TraceLevel = Trace.US0

module SpiralDateTime =
    let new_guid_from_date_time (value : DateTime) =
        let bytes = Encoding.UTF8.GetBytes(value.ToUniversalTime().Ticks.ToString(Globalization.CultureInfo.InvariantCulture))
        let hash = SHA256.HashData bytes
        Guid(hash.AsSpan(0, 16))

module SpiralPlatform =
    let get_executable_suffix () =
        if OperatingSystem.IsWindows() then ".exe" else ""

    let is_windows () = OperatingSystem.IsWindows()

module SpiralSm =
    let concat (separator : string) : FSharpFunc<seq<string>, string> =
        FuncConvert.FromFunc(Func<seq<string>, string>(fun values -> String.concat separator values))

    let contains (part : string) (text : string) = text.Contains(part, StringComparison.Ordinal)

    let ellipsis (length : int) : FSharpFunc<string, string> =
        FuncConvert.FromFunc(Func<string, string>(fun text ->
            if isNull text || text.Length <= length then text
            elif length <= 3 then text.Substring(0, max 0 length)
            else text.Substring(0, length - 3) + "..."))

    let ellipsis_end (length : int64) (text : string) =
        let length = int (min (int64 Int32.MaxValue) (max 0L length))
        if isNull text || text.Length <= length then text
        elif length <= 3 then text.Substring(max 0 (text.Length - length))
        else "..." + text.Substring(text.Length - (length - 3))

    let ends_with (suffix : string) : FSharpFunc<string, bool> =
        FuncConvert.FromFunc(Func<string, bool>(fun text -> text.EndsWith(suffix, StringComparison.Ordinal)))

    let format_exception (error : exn) = error.ToString()

    let replace (oldValue : string) : FSharpFunc<string, FSharpFunc<string, string>> =
        FuncConvert.FromFunc(Func<string, FSharpFunc<string, string>>(fun newValue ->
            FuncConvert.FromFunc(Func<string, string>(fun text -> text.Replace(oldValue, newValue, StringComparison.Ordinal)))))

    let replace_regex (pattern : string) (replacement : string) (text : string) = Text.RegularExpressions.Regex.Replace(text, pattern, replacement)
    let slice (fromIndex : int) (nearTo : int) (text : string) = text.Substring(fromIndex, nearTo - fromIndex)
    let split (separator : string) (text : string) = text.Split([| separator |], StringSplitOptions.None)
    let split_string (separators : string array) (text : string) = text.Split(separators, StringSplitOptions.None)

    let starts_with (prefix : string) : FSharpFunc<string, bool> =
        FuncConvert.FromFunc(Func<string, bool>(fun text -> text.StartsWith(prefix, StringComparison.Ordinal)))

    let substring (startIndex : int) (length : int) (text : string) = text.Substring(startIndex, length)
    let to_lower (text : string) = text.ToLowerInvariant()
    let trim (text : string) = text.Trim()
    let trim_start (characters : char array) (text : string) = text.TrimStart(characters)
    let trim_end (characters : char array) (text : string) = text.TrimEnd(characters)

module SpiralFileSystem =
    let private normalizeSeparators (path : string) = path.Replace('\\', '/')

    let get_workspace_root () =
        match Environment.GetEnvironmentVariable("SPIRAL_WORKSPACE_ROOT") with
        | value when not (String.IsNullOrWhiteSpace value) -> Path.GetFullPath value |> normalizeSeparators
        | _ -> Directory.GetCurrentDirectory() |> Path.GetFullPath |> normalizeSeparators

    let get_source_directory () = AppContext.BaseDirectory |> Path.GetFullPath |> normalizeSeparators
    let normalize_path (path : string) = Path.GetFullPath(path) |> normalizeSeparators
    let get_full_path (path : string) = Path.GetFullPath(path) |> normalizeSeparators
    let standardize_path (path : string) = normalize_path path
    let new_file_uri (path : string) = Uri(normalize_path path).AbsoluteUri

    let write_all_text_async (path : string) : FSharpFunc<string, Async<unit>> =
        FuncConvert.FromFunc(Func<string, Async<unit>>(fun text -> async {
            let parent = Path.GetDirectoryName(path)
            if not (String.IsNullOrWhiteSpace parent) then Directory.CreateDirectory(parent) |> ignore
            do! File.WriteAllTextAsync(path, text, Encoding.UTF8) |> Async.AwaitTask
        }))

    module Operators =
        let (</>) (left : string) : FSharpFunc<string, string> =
            FuncConvert.FromFunc(Func<string, string>(fun right -> Path.Combine(left, right) |> normalizeSeparators))
