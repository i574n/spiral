#r "nuget: Hopac, 0.5.1"
open Hopac
open Hopac.Infixes

let probe name (s: Stream<int>) =
    let t = System.Diagnostics.Stopwatch.StartNew ()
    let r = run (Promise.start (Stream.foldFun (+) 0 s) >>= fun p -> (p ^-> Some) <|> (timeOutMillis 5000 ^->. None))
    printfn "%-44s %A in %d ms" name r t.ElapsedMilliseconds

let xs = Stream.ofSeq [1 .. 10]
probe "mapFun" (xs |> Stream.mapFun id)
probe "mapJob Job.result" (xs |> Stream.mapJob Job.result)
probe "mapPipelinedJob 2 Job.result" (xs |> Stream.mapPipelinedJob 2 Job.result)
probe "mapPipelinedJob 1 Job.result" (xs |> Stream.mapPipelinedJob 1 Job.result)
probe "mapPipelinedFun 2 id" (xs |> Stream.mapPipelinedFun 2 id)
