#r "nuget: Hopac, 0.5.1"
open Hopac
open Hopac.Infixes

let finishes (s: Stream<int>) =
    run (Promise.start (Stream.foldFun (+) 0 s) >>= fun p -> (p ^-> fun v -> v = 55) <|> (timeOutMillis 2000 ^->. false))

let trials = 30
let rate name (mk: unit -> Stream<int>) =
    let ok = Seq.init trials (fun _ -> finishes (mk ())) |> Seq.filter id |> Seq.length
    printfn "%-36s finished %2d of %d" name ok trials

for degree in [1; 2; 4; 8] do
    rate (sprintf "mapPipelinedJob %d Job.result" degree) (fun () -> Stream.ofSeq [1 .. 10] |> Stream.mapPipelinedJob degree Job.result)
rate "mapPipelinedJob 2 Job.thunk" (fun () -> Stream.ofSeq [1 .. 10] |> Stream.mapPipelinedJob 2 (fun x -> Job.thunk (fun () -> x)))
rate "mapPipelinedFun 2" (fun () -> Stream.ofSeq [1 .. 10] |> Stream.mapPipelinedFun 2 id)
rate "mapJob (control)" (fun () -> Stream.ofSeq [1 .. 10] |> Stream.mapJob Job.result)
