#r "nuget: Hopac, 0.5.1"
open System
open System.Diagnostics
open Hopac
open Hopac.Infixes

let work (n: int) = Job.thunk (fun () -> let mutable a = 0 in (for i in 1 .. n do a <- a + i % 7); a)

let children = 64
let rounds = 2000
let grain = 2000

let viaIVarCounting () = job {
    let results = Array.zeroCreate children
    let remaining = ref children
    let all = IVar ()
    for i in 0 .. children - 1 do
        do! Job.start (work grain >>= fun v ->
            results.[i] <- v
            if Threading.Interlocked.Decrement remaining = 0 then IVar.fill all () else Job.unit ())
    do! IVar.read all
    return Array.sum results }

let viaLatch () = job {
    let results = Array.zeroCreate children
    let latch = Latch children
    for i in 0 .. children - 1 do
        do! Job.queue (work grain >>= fun v -> results.[i] <- v; Latch.decrement latch)
    do! Latch.await latch
    return Array.sum results }

let viaConCollect () = job {
    let! results = Job.conCollect (Seq.init children (fun _ -> work grain))
    return Seq.sum results }

let viaPromises () = job {
    let! ps = Job.seqCollect (Seq.init children (fun _ -> Promise.start (work grain)))
    let! vs = Job.seqCollect (ps |> Seq.map Promise.read)
    return Seq.sum vs }

let time name (mk: unit -> Job<int>) =
    let check = run (mk ())
    let sw = Stopwatch.StartNew ()
    for _ in 1 .. rounds do run (mk ()) |> ignore
    printfn "%-28s %8.1f us per fork-join of %d children (sum %d)" name (sw.Elapsed.TotalMilliseconds * 1000.0 / float rounds) children check

time "IVar + Interlocked counting" viaIVarCounting
time "Latch" viaLatch
time "Job.conCollect" viaConCollect
time "Promise.start + read" viaPromises

let perBuildScheduler () =
    let sw = Stopwatch.StartNew ()
    let n = 50
    for _ in 1 .. n do
        let s = Scheduler.create { Scheduler.Create.Def with NumWorkers = Some Environment.ProcessorCount; MaxStackSize = Some (1536 * 1024 * 1024) }
        Scheduler.run s (viaLatch ()) |> ignore
        Scheduler.kill s
    printfn "%-28s %8.1f ms per create + one fork-join + kill (1.5 GB worker stacks reserved)" "Scheduler per build" (sw.Elapsed.TotalMilliseconds / float n)
perBuildScheduler ()

let isolateCost () =
    let n = 2000
    let sw = Stopwatch.StartNew ()
    for _ in 1 .. n do run (Job.Scheduler.isolate (fun () -> 1)) |> ignore
    let isolated = sw.Elapsed.TotalMilliseconds * 1000.0 / float n
    sw.Restart ()
    for _ in 1 .. n do run (Job.thunk (fun () -> 1)) |> ignore
    printfn "%-28s %8.1f us isolate vs %.1f us plain thunk" "Job.Scheduler.isolate" isolated (sw.Elapsed.TotalMilliseconds * 1000.0 / float n)
isolateCost ()

let nackCleanup () =
    let cancelled = ref 0
    let n = 2000
    let sw = Stopwatch.StartNew ()
    for _ in 1 .. n do
        let winner = Alt.always 1
        let loser = Alt.withNackJob (fun nack -> job {
            do! Job.start (nack >>= fun () -> Threading.Interlocked.Increment cancelled |> ignore; Job.unit ())
            return Alt.never () })
        run (loser <|> winner) |> ignore
    Threading.Thread.Sleep 100
    printfn "%-28s %8.1f us per race; loser nacks seen %d of %d" "withNackJob speculation" (sw.Elapsed.TotalMilliseconds * 1000.0 / float n) cancelled.Value n
nackCleanup ()
