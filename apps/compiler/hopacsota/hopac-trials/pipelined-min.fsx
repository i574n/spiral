#r "nuget: Hopac, 0.5.1"
open Hopac
open Hopac.Infixes

let trial name (s: Stream<int>) =
    let t = System.Diagnostics.Stopwatch.StartNew ()
    let r = run (Promise.start (Stream.foldFun (+) 0 s) >>= fun p -> (p ^-> Some) <|> (timeOutMillis 5000 ^->. None))
    printfn "%-44s %A in %d ms" name r t.ElapsedMilliseconds

let xs = Stream.ofSeq [1 .. 10]
trial "mapFun" (xs |> Stream.mapFun id)
trial "mapJob Job.result" (xs |> Stream.mapJob Job.result)
trial "mapPipelinedJob 2 Job.result" (xs |> Stream.mapPipelinedJob 2 Job.result)
trial "mapPipelinedJob 1 Job.result" (xs |> Stream.mapPipelinedJob 1 Job.result)
trial "mapPipelinedFun 2 id" (xs |> Stream.mapPipelinedFun 2 id)
