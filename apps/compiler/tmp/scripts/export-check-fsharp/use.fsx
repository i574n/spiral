#load "main.fsx"
open Main
if add_one 6 = 7 && add_pair (2, 3) = 5 then printfn "FSX-EXPORT-OK" else exit 1
