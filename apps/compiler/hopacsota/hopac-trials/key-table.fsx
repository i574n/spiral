#r "nuget: Hopac, 0.5.1"
open System
open System.Collections.Generic
open System.Collections.Concurrent
open System.Diagnostics
open Hopac
open Hopac.Infixes

let keys = 4096
let lookupsPerJob = 20000
let jobs = 8

let keyAt (job: int) (i: int) = (job * 7919 + i * 104729) % keys

type Table =
    abstract Cell : int -> Job<IVar<int>>

let concurrentTable () =
    let d = ConcurrentDictionary<int, IVar<int>> ()
    { new Table with member _.Cell k = Job.result (d.GetOrAdd (k, fun _ -> IVar ())) }

let serverTable () =
    let requests = Ch<int * IVar<IVar<int>>> ()
    let d = Dictionary<int, IVar<int>> ()
    let serve = Job.foreverServer (Ch.take requests >>= fun (k, reply) ->
        let cell = match d.TryGetValue k with | true, c -> c | _ -> let c = IVar () in d.[k] <- c; c
        IVar.fill reply cell)
    run serve
    { new Table with
        member _.Cell k = job {
            let reply = IVar ()
            do! Ch.send requests (k, reply)
            return! IVar.read reply } }

let mvarTable () =
    let m = MVar (Dictionary<int, IVar<int>> ())
    { new Table with
        member _.Cell k = MVar.modifyFun (fun (d: Dictionary<int, IVar<int>>) ->
            match d.TryGetValue k with
            | true, c -> d, c
            | _ -> let c = IVar () in d.[k] <- c; d, c) m }

let workload (t: Table) = job {
    let worker j = job {
        for i in 0 .. lookupsPerJob - 1 do
            let! cell = t.Cell (keyAt j i)
            do! IVar.tryFill cell (keyAt j i)
        return () }
    do! Job.conIgnore (Seq.init jobs worker) }

let measure name (mk: unit -> Table) =
    run (workload (mk ()))
    let sw = Stopwatch.StartNew ()
    let reps = 5
    for _ in 1 .. reps do run (workload (mk ()))
    let total = float (reps * jobs * lookupsPerJob)
    printfn "%-34s %7.0f ns per lookup+fill (%d jobs x %d lookups over %d keys)" name (sw.Elapsed.TotalMilliseconds * 1e6 / total) jobs lookupsPerJob keys

measure "ConcurrentDictionary.GetOrAdd" concurrentTable
measure "owner server (foreverServer)" serverTable
measure "MVar.modifyFun over Dictionary" mvarTable
