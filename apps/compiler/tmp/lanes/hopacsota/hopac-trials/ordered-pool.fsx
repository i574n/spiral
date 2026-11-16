#r "nuget: Hopac, 0.5.1"
open System
open System.Diagnostics
open Hopac
open Hopac.Infixes

let methods = 400
let cost i = 20000 + (i * 7919 % 13) * 20000
let emit (i: int) = Job.thunk (fun () -> let mutable a = 0L in (for k in 1 .. cost i do a <- a + int64 (k % 3)); sprintf "m%d:%d" i (a % 97L))

let chunked (degree: int) (items: int list) (f: int -> Job<string>) : Job<string list> = job {
    let out = ResizeArray ()
    for chunk in List.chunkBySize degree items do
        let! xs = Job.conCollect (chunk |> Seq.map f)
        out.AddRange xs
    return List.ofSeq out }

let tokenPool (degree: int) (items: int list) (f: int -> Job<string>) : Job<string list> = job {
    let tokens = Ch ()
    do! Job.start (Job.forN degree (Ch.give tokens ()))
    let! promises =
        items |> Seq.map (fun i -> Ch.take tokens >>= fun () -> Promise.start (f i >>= fun r -> Job.start (Ch.give tokens ()) >>-. r)) |> Job.seqCollect
    let! results = promises |> Seq.map Promise.read |> Job.seqCollect
    return List.ofSeq results }

let reference = run (Job.seqCollect (Seq.init methods emit)) |> List.ofSeq
let items = [0 .. methods - 1]

let trial name (mk: unit -> Job<string list>) =
    let finished = Seq.init 30 (fun _ -> run (Promise.start (mk ()) >>= fun p -> (p ^-> fun r -> r = reference) <|> (timeOutMillis 10000 ^->. false))) |> Seq.filter id |> Seq.length
    let sw = Stopwatch.StartNew ()
    let r = run (mk ())
    printfn "%-28s correct+finished %2d/30, one run %6.1f ms, same order: %b" name finished sw.Elapsed.TotalMilliseconds (r = reference)

trial "conCollect (unbounded)" (fun () -> Job.conCollect (Seq.init methods emit) |> Job.map List.ofSeq)
for d in [2; 4; 8] do
    trial (sprintf "chunked conCollect d=%d" d) (fun () -> chunked d items emit)
    trial (sprintf "token pool d=%d" d) (fun () -> tokenPool d items emit)
