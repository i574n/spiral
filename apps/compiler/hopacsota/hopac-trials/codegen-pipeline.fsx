#r "nuget: Hopac, 0.5.1"
open System
open System.Diagnostics
open Hopac
open Hopac.Infixes

let methods = 400
let cost i = 20000 + (i * 7919 % 13) * 20000
let emit (i: int) = Job.thunk (fun () -> let mutable a = 0L in (for k in 1 .. cost i do a <- a + int64 (k % 3)); sprintf "m%d:%d" i (a % 97L))

let sequential () = job {
    let out = ResizeArray ()
    for i in 0 .. methods - 1 do
        let! s = emit i
        out.Add s
    return List.ofSeq out }

let collected () = job {
    let! xs = Job.conCollect (Seq.init methods emit)
    return List.ofSeq xs }

let pipelined degree () =
    Stream.ofSeq [0 .. methods - 1]
    |> Stream.mapPipelinedJob degree emit
    |> Stream.foldFun (fun acc s -> s :: acc) []
    |> Job.map List.rev

let time name (mk: unit -> Job<string list>) =
    let reference = run (sequential ())
    let sw = Stopwatch.StartNew ()
    let result = run (mk ())
    printfn "%-26s %7.1f ms  same order as sequential: %b" name sw.Elapsed.TotalMilliseconds (result = reference)

time "sequential" sequential
time "Job.conCollect" collected
for d in [2; 4; Environment.ProcessorCount] do time (sprintf "mapPipelinedJob degree %d" d) (pipelined d)
