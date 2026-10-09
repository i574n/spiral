type [<Struct>] US0 =
    | US0_ErpNetIntercompanyPayloadDecoded of f0_0 : string
    | US0_ErpNetIntercompanyPayloadRejected of f1_0 : string
and [<Struct>] US2 =
    | US2_OpposedMirrorPair of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : int64 * f0_5 : string * f0_6 : string
and [<Struct>] US1 =
    | US1_NetIntercompany of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : string * f0_5 : string * f0_6 : string * f0_7 : US2
let rec method0 (v0 : string, v1 : string) : unit =
    if v0 <> v1 then failwith "erp-NetIntercompany-typed-decode-roundtrip-mismatch"
    ()
and method1 (v0 : string) : unit =
    if v0 <> v0 then failwith "erp-NetIntercompany-typed-decode-roundtrip-mismatch"
    ()
let struct (v0 : int64, v1 : int64, v2 : int64, v3 : int64, v4 : int64, v5 : int64, v6 : int64, v7 : int64, v8 : int64, v9 : int64, v10 : string) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-fenced-lock-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let lockPath = System.IO.Path.Combine(root,"writer.lock") in let takeoverPath = System.IO.Path.Combine(root,"writer.takeover") in let markerPath = System.IO.Path.Combine(root,"owner-a.ready") in let commitPath = System.IO.Path.Combine(root,"commit.owner-b") in let ownerA = "owner-a" in let ownerB = "owner-b" in let ownerC = "owner-c" in let ownerD = "owner-d" in let now () = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() in let leaseExpiry = now() + 250L in let ownerARecord = System.String.Join("|",[|ownerA;"1";string leaseExpiry|]) in let writeDurable path (bytes : byte array) = use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in let runSync path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let script = "printf '%s' \"$1\" > \"$2\"; /usr/bin/sync -f \"$2\"; /usr/bin/touch \"$3\"; /usr/bin/sleep 30" in let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add(script); info.ArgumentList.Add("erp-owner-a"); info.ArgumentList.Add(ownerARecord); info.ArgumentList.Add(lockPath); info.ArgumentList.Add(markerPath); use child = System.Diagnostics.Process.Start(info) in let mutable attempts = 0 in while attempts < 200 && not (System.IO.File.Exists(markerPath)) do System.Threading.Thread.Sleep(25); attempts <- attempts + 1 done; let childReady = if System.IO.File.Exists(markerPath) then 1L else 0L in let ownerKilled = if childReady = 1L && not child.HasExited then (child.Kill(true); child.WaitForExit(); 1L) else 0L in while now() <= leaseExpiry do System.Threading.Thread.Sleep(10) done; let currentParts = System.IO.File.ReadAllText(lockPath).Split('|') in let currentFence = System.Int64.Parse(currentParts.[1]) in let currentExpiry = System.Int64.Parse(currentParts.[2]) in let leaseExpired = if now() > currentExpiry then 1L else 0L in let nextFence = currentFence + 1L in let ownerBRecord = System.String.Join("|",[|ownerB;string nextFence;string (now() + 5000L)|]) in writeDurable takeoverPath (System.Text.Encoding.UTF8.GetBytes(ownerBRecord)); System.IO.File.Move(takeoverPath,lockPath,true); let directorySync = runSync root in let installedParts = System.IO.File.ReadAllText(lockPath).Split('|') in let installedFence = System.Int64.Parse(installedParts.[1]) in let fenceAdvanced = if installedFence = 2L && installedFence > currentFence then 1L else 0L in let staleRejected = if installedParts.[0] <> ownerA || installedFence <> 1L then 1L else 0L in let newAccepted = if installedParts.[0] = ownerB && installedFence = 2L then (writeDurable commitPath (System.Text.Encoding.UTF8.GetBytes("owner-b-fence-2-commit")); 1L) else 0L in let ownerBInstalled = if installedParts.[0] = ownerB then 1L else 0L in let committedFenceTwo = if newAccepted = 1L && System.IO.File.ReadAllText(commitPath) = "owner-b-fence-2-commit" then 1L else 0L in let ownerCFence = installedFence + 1L in let ownerCRecord = System.String.Join("|",[|ownerC;string ownerCFence;string (now() + 5000L)|]) in writeDurable takeoverPath (System.Text.Encoding.UTF8.GetBytes(ownerCRecord)); System.IO.File.Move(takeoverPath,lockPath,true); let ownerCDirectorySync = runSync root in let ownerCParts = System.IO.File.ReadAllText(lockPath).Split('|') in let ownerCFenceInstalled = System.Int64.Parse(ownerCParts.[1]) in let ownerDFence = ownerCFenceInstalled + 1L in let ownerDRecord = System.String.Join("|",[|ownerD;string ownerDFence;string (now() + 5000L)|]) in writeDurable takeoverPath (System.Text.Encoding.UTF8.GetBytes(ownerDRecord)); System.IO.File.Move(takeoverPath,lockPath,true); let ownerDDirectorySync = runSync root in let finalParts = System.IO.File.ReadAllText(lockPath).Split('|') in let finalFence = System.Int64.Parse(finalParts.[1]) in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in childReady,ownerKilled,leaseExpired,fenceAdvanced,staleRejected,newAccepted,ownerBInstalled,committedFenceTwo,(if directorySync = 0L && ownerCDirectorySync = 0L && ownerDDirectorySync = 0L && cleanupAbsent = 1L then 1L else 0L),finalFence,System.String.Join("|",[|currentParts.[0];installedParts.[0];ownerCParts.[0];finalParts.[0]|]))
let v11 : bool = v0 = 1L
let v12 : bool = v1 = 1L
let v13 : bool = v2 = 1L
let v14 : bool = v3 = 1L
let v15 : bool = v4 = 1L
let v16 : bool = v5 = 1L
let v17 : bool = v6 = 1L
let v18 : bool = v7 = 1L
let v19 : bool = v8 = 1L
let v20 : bool = v11 && v12
let v21 : bool = v20 && v13
let v22 : bool = v21 && v14
let v23 : bool = v22 && v15
let v24 : bool = v23 && v16
let v25 : bool = v24 && v17
let v26 : bool = v25 && v18
let v27 : bool = v26 && v19
if v27 then
    ()
else
    failwith<unit> "erp-p2p-recoverable-fenced-lock-runtime-mismatch"
let v28 : int64 = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in int64 parts.Length)
let v29 : bool = v28 = v9
if v29 then
    ()
else
    failwith<unit> "erp-p2p-physical-owner-sequence-cardinality-fence-mismatch"
let v30 : int64 = 0L + 1L
let v31 : int64 = v28 - 2L
let v32 : int64 = v28 - 1L
let v33 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int 0L in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v34 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int v30 in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v35 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int v31 in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v36 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int v32 in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v37 : string = v33 + "|" + v34
let v38 : string = v37 + "|" + v35
let v39 : string = v38 + "|" + v36
let v40 : bool = v10 = v39
if v40 then
    ()
else
    failwith<unit> "erp-p2p-physical-owner-sequence-lineage-mismatch"
let v41 : int64 = 0L + 1L
let v42 : int64 = v41 + 1L
let v43 : int64 = v42 + 1L
let v44 : int64 = v43 + 1L
let v45 : bool = v9 = v44
if v45 then
    ()
else
    failwith<unit> "erp-p2p-physical-lineage-selected-fence-mismatch"
let v46 : int64 = 0L + 1L
let v47 : int64 = v46 + 1L
let v48 : int64 = v47 + 1L
let v49 : int64 = v48 + 1L
let v50 : bool = v9 = v49
if v50 then
    ()
else
    failwith<unit> "erp-p2p-recoverable-fenced-lock-snapshot-history-mismatch"
let v51 : int64 = 0L + 1L
let v52 : int64 = v51 + 1L
let v53 : int64 = v52 + 1L
let v54 : int64 = v53 + 1L
let v55 : int64 = 0L + 1L
let v56 : int64 = v55 + 1L
let v57 : int64 = v56 + 1L
let v58 : int64 = v57 + 1L
let v59 : string = "physical-owner-store-outbox-bound-after-fenced-takeover"
(if v54 <> v58 || v59 <> "physical-owner-store-outbox-bound-after-fenced-takeover" then failwith "erp-p2p-recoverable-fenced-lock-receipt-validation-mismatch")
let v60 : int64 = 0L + 1L
let v61 : int64 = v60 + 1L
let v62 : int64 = v61 + 1L
let v63 : int64 = v62 + 1L
let v64 : int64 = 0L + 1L
let v65 : int64 = v64 + 1L
let v66 : int64 = v65 + 1L
let v67 : int64 = v66 + 1L
let v68 : string = "goods-partially-received"
if v63 <> 4L || v67 <> 4L || v68 <> "goods-partially-received" || v68 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let struct (v69 : int64, v70 : int64, v71 : int64, v72 : int64, v73 : int64, v74 : int64, v75 : int64, v76 : int64, v77 : int64, v78 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-wal-cutpoints-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let walPath = System.IO.Path.Combine(root,"successor.wal") in let committedPath = System.IO.Path.Combine(root,"successor.committed") in let store64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v68)) in let outbox64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v68)) in let body = store64 + "|" + outbox64 in let digest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(body))) in let envelope = System.String.Join("|",[|"cutpoint-owner";"2";store64;outbox64;digest|]) in let recover () = if System.IO.File.Exists(committedPath) then ((if System.IO.File.Exists(walPath) then System.IO.File.Delete(walPath) else ()); 2L) elif System.IO.File.Exists(walPath) then (System.IO.File.Move(walPath,committedPath,true); 1L) else 0L in let crashAt mode = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("printf '%s' \"$1\" > \"$2\"; /usr/bin/sync -f \"$2\"; if [ \"$4\" = wal ]; then /bin/kill -9 $$; fi; /bin/mv \"$2\" \"$3\"; /usr/bin/sync -f \"$3\"; /bin/kill -9 $$"); info.ArgumentList.Add("erp-wal-cutpoint"); info.ArgumentList.Add(envelope); info.ArgumentList.Add(walPath); info.ArgumentList.Add(committedPath); info.ArgumentList.Add(mode); System.Diagnostics.Process.Start(info) in let beforeWal = recover() in use walCrash = crashAt "wal" in walCrash.WaitForExit(); let walProcessKilled = if walCrash.ExitCode <> 0 then 1L else 0L in let afterWal = recover() in System.IO.File.Delete(committedPath); use renameCrash = crashAt "rename" in renameCrash.WaitForExit(); let renameProcessKilled = if renameCrash.ExitCode <> 0 then 1L else 0L in let afterRename = recover() in let installed = System.IO.File.ReadAllText(committedPath).Split('|') in let decodedStore = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[2])) in let decodedOutbox = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[3])) in let payloadMatch = if decodedStore = v68 && decodedOutbox = v68 then 1L else 0L in let installedBody = installed.[2] + "|" + installed.[3] in let installedDigest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(installedBody))) in let digestMatch = if installed.[4] = installedDigest then 1L else 0L in System.IO.File.WriteAllText(walPath,"stale-cutpoint-wal"); let stalePreferred = recover() in let noWal = if System.IO.File.Exists(walPath) then 0L else 1L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in beforeWal,walProcessKilled,afterWal,renameProcessKilled,afterRename,stalePreferred,payloadMatch,digestMatch,noWal,cleanup)
let v79 : bool = v69 = 0L
let v80 : bool = v70 = 1L
let v81 : bool = v71 = 1L
let v82 : bool = v72 = 1L
let v83 : bool = v73 = 2L
let v84 : bool = v74 = 2L
let v85 : bool = v75 = 1L
let v86 : bool = v76 = 1L
let v87 : bool = v77 = 1L
let v88 : bool = v78 = 1L
let v89 : bool = v79 && v80
let v90 : bool = v89 && v81
let v91 : bool = v90 && v82
let v92 : bool = v91 && v83
let v93 : bool = v92 && v84
let v94 : bool = v93 && v85
let v95 : bool = v94 && v86
let v96 : bool = v95 && v87
let v97 : bool = v96 && v88
if v97 then
    ()
else
    failwith<unit> "erp-p2p-atomic-successor-WAL-crash-cutpoint-runtime-mismatch"
let v98 : int64 = 0L + 1L
let v99 : int64 = v98 + 1L
let v100 : int64 = v99 + 1L
let v101 : int64 = v100 + 1L
let v102 : int64 = 0L + 1L
let v103 : int64 = v102 + 1L
let v104 : int64 = v103 + 1L
let v105 : int64 = v104 + 1L
if v101 <> 4L || v105 <> 4L || v68 <> "goods-partially-received" || v68 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v106 : string = "the-four-event-commit-tree-envelope-survives-process-death-after-durable-WAL-and-after-rename-while-committed-dominates-a-later-stale-WAL"
(if v106 <> "the-four-event-commit-tree-envelope-survives-process-death-after-durable-WAL-and-after-rename-while-committed-dominates-a-later-stale-WAL" then failwith "erp-p2p-atomic-successor-WAL-recovery-receipt-mismatch")
let struct (v107 : string, v108 : int64, v109 : int64, v110 : int64, v111 : int64, v112 : int64, v113 : int64, v114 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-interprocess-atomic-successor-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let claimDirectory = System.IO.Path.Combine(root,"successor.claim") in let gatePath = System.IO.Path.Combine(root,"race.gate") in let preparedPath = System.IO.Path.Combine(root,"successor.prepared") in let committedPath = System.IO.Path.Combine(root,"successor.committed") in let store64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v68)) in let outbox64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v68)) in let body = store64 + "|" + outbox64 in let digest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(body))) in let contender (owner : string) = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("until /usr/bin/test -f $8; do /usr/bin/sleep 0.01; done; if /bin/mkdir $1 2>/dev/null; then printf '%s|2|%s|%s|%s' $2 $3 $4 $5 > $6; /usr/bin/sync -f $6; /bin/mv $6 $7; /usr/bin/sync -f $7; exit 0; else exit 1; fi"); info.ArgumentList.Add("erp-interprocess-atomic-successor"); info.ArgumentList.Add(claimDirectory); info.ArgumentList.Add(owner); info.ArgumentList.Add(store64); info.ArgumentList.Add(outbox64); info.ArgumentList.Add(digest); info.ArgumentList.Add(preparedPath); info.ArgumentList.Add(committedPath); info.ArgumentList.Add(gatePath); System.Diagnostics.Process.Start(info) in use first = contender "process-owner-a" in use second = contender "process-owner-b" in System.IO.File.WriteAllText(gatePath,"go"); first.WaitForExit(); second.WaitForExit(); let firstWon = if first.ExitCode = 0 then 1L else 0L in let secondWon = if second.ExitCode = 0 then 1L else 0L in let winners = firstWon + secondWon in let losers = 2L - winners in let winnerOwner = if firstWon = 1L then "process-owner-a" else "process-owner-b" in let installed = System.IO.File.ReadAllText(committedPath).Split('|') in let installedFence = System.Int64.Parse(installed.[1]) in let decodedStore = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[2])) in let decodedOutbox = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[3])) in let payloadMatch = if decodedStore = v68 && decodedOutbox = v68 then 1L else 0L in let installedBody = installed.[2] + "|" + installed.[3] in let installedDigest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(installedBody))) in let digestMatch = if installed.[4] = installedDigest then 1L else 0L in let noPrepared = if System.IO.File.Exists(preparedPath) then 0L else 1L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in winnerOwner,winners,losers,installedFence,payloadMatch,digestMatch,noPrepared,cleanup)
if (v107 <> "process-owner-a" && v107 <> "process-owner-b") || v108 <> 1L || v109 <> 1L || v110 <> 2L || v111 <> 1L || v112 <> 1L || v113 <> 1L || v114 <> 1L then failwith "erp-p2p-interprocess-atomic-successor-store-outbox-runtime-mismatch"
let v115 : int64 = 0L + 1L
let v116 : int64 = v115 + 1L
let v117 : int64 = v116 + 1L
let v118 : int64 = v117 + 1L
let v119 : int64 = 0L + 1L
let v120 : int64 = v119 + 1L
let v121 : int64 = v120 + 1L
let v122 : int64 = v121 + 1L
if v118 <> 4L || v122 <> 4L || v68 <> "goods-partially-received" || v68 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v123 : string = "one-exclusive-filesystem-claim-installs-both-successor-fence-two-and-the-four-event-commit-tree-payload-before-reopen"
(if v123 <> "one-exclusive-filesystem-claim-installs-both-successor-fence-two-and-the-four-event-commit-tree-payload-before-reopen" then failwith "erp-p2p-four-event-interprocess-atomic-successor-store-outbox-receipt-mismatch")
let v124 : string = "budget-reserved"
if v124 <> "budget-reserved" then failwith "erp-p2p-reserve-budget-store-runtime-mismatch"
if v124 <> "budget-reserved" then failwith "erp-p2p-reserve-budget-outbox-runtime-mismatch"
let v125 : string = "erp-p2p-" + v124 + "-outbox"
let struct (v126 : int64, v127 : int64, v128 : int64, v129 : int64, v130 : int64, v131 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-p2p-atomic-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(directory) in let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let prepared = System.IO.Path.Combine(directory, "commit.prepared") in let committed = System.IO.Path.Combine(directory, "commit.committed") in let payload = v124 + "|" + v124 + "|" + v125 in let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let directorySync = runSync "-f" directory in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredEqual = if System.Linq.Enumerable.SequenceEqual(bytes, recovered) then 1L else 0L in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let recoveredText = System.Text.Encoding.UTF8.GetString(recovered) in let payloadBound = if recoveredText = "budget-reserved|budget-reserved|erp-p2p-budget-reserved-outbox" then 1L else 0L in System.IO.File.Delete(committed); let committedAbsent = if System.IO.File.Exists(committed) then 0L else 1L in System.IO.Directory.Delete(directory); (int64 bytes.Length, recoveredEqual, preparedAbsent, payloadBound, directorySync, committedAbsent))
let v132 : bool = v126 > 0L
let v133 : bool = v127 = 1L
let v134 : bool = v128 = 1L
let v135 : bool = v129 = 1L
let v136 : bool = v130 = 0L
let v137 : bool = v131 = 1L
let v138 : bool = v132 && v133
let v139 : bool = v138 && v134
let v140 : bool = v139 && v135
let v141 : bool = v140 && v136
let v142 : bool = v141 && v137
if v142 then
    ()
else
    failwith<unit> "erp-p2p-unit-physical-commit-runtime-mismatch"
let v143 : string = "erp-p2p-" + v124 + "-outbox"
let struct (v144 : int64, v145 : int64, v146 : int64, v147 : int64, v148 : int64, v149 : int64, v150 : int64, v151 : int64, v152 : int64, v153 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-p2p-recovery-" + System.Guid.NewGuid().ToString("N")) in let beforeDirectory = System.IO.Path.Combine(root, "before-rename") in let afterDirectory = System.IO.Path.Combine(root, "after-rename") in let _ = System.IO.Directory.CreateDirectory(beforeDirectory) in let _ = System.IO.Directory.CreateDirectory(afterDirectory) in let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let payload = v124 + "|" + v124 + "|" + v143 in let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in let beforePrepared = System.IO.Path.Combine(beforeDirectory, "commit.prepared") in let beforeCommitted = System.IO.Path.Combine(beforeDirectory, "commit.committed") in (use stream = new System.IO.FileStream(beforePrepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(beforePrepared, beforeCommitted, true); let beforeDirectorySync = runSync "-f" beforeDirectory in let beforeRecovered = System.IO.File.ReadAllBytes(beforeCommitted) in let beforeEqual = if System.Linq.Enumerable.SequenceEqual(bytes, beforeRecovered) then 1L else 0L in let beforePreparedAbsent = if System.IO.File.Exists(beforePrepared) then 0L else 1L in let beforeCommittedPresent = if System.IO.File.Exists(beforeCommitted) then 1L else 0L in let afterPrepared = System.IO.Path.Combine(afterDirectory, "commit.prepared") in let afterCommitted = System.IO.Path.Combine(afterDirectory, "commit.committed") in (use stream = new System.IO.FileStream(afterPrepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(afterPrepared, afterCommitted, true); let afterDirectorySync = runSync "-f" afterDirectory in let afterRecovered = System.IO.File.ReadAllBytes(afterCommitted) in let afterEqual = if System.Linq.Enumerable.SequenceEqual(bytes, afterRecovered) then 1L else 0L in let afterPreparedAbsent = if System.IO.File.Exists(afterPrepared) then 0L else 1L in let afterCommittedPresent = if System.IO.File.Exists(afterCommitted) then 1L else 0L in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in (int64 bytes.Length, beforeEqual, beforePreparedAbsent, beforeCommittedPresent, beforeDirectorySync, afterEqual, afterPreparedAbsent, afterCommittedPresent, afterDirectorySync, cleanupAbsent))
let v154 : bool = v144 > 0L
let v155 : bool = v145 = 1L
let v156 : bool = v146 = 1L
let v157 : bool = v147 = 1L
let v158 : bool = v148 = 0L
let v159 : bool = v149 = 1L
let v160 : bool = v150 = 1L
let v161 : bool = v151 = 1L
let v162 : bool = v152 = 0L
let v163 : bool = v153 = 1L
let v164 : bool = v154 && v155
let v165 : bool = v164 && v156
let v166 : bool = v165 && v157
let v167 : bool = v166 && v158
let v168 : bool = v167 && v159
let v169 : bool = v168 && v160
let v170 : bool = v169 && v161
let v171 : bool = v170 && v162
let v172 : bool = v171 && v163
if v172 then
    ()
else
    failwith<unit> "erp-p2p-unit-physical-recovery-runtime-mismatch"
let v173 : string = "erp-p2p-" + v124 + "-outbox"
let v174 : string = v173 + "|aggregate=erp-p2p-aggregate:" + v173 + "|command=erp-p2p-command:" + v173
let v175 : string = "erp-p2p-" + v124 + "-outbox"
let v176 : string = v175 + "|aggregate=erp-p2p-aggregate:" + v175 + "|command=erp-p2p-command:" + v175
let v177 : string = "erp-p2p-" + v124 + "-outbox"
let v178 : string = v177 + "|aggregate=erp-p2p-aggregate:" + v177 + "|command=erp-p2p-command:" + v177
let v179 : string = "company-a"
let v180 : string = "USD"
let v181 : string = "widget-a"
let v182 : string = "requisition-1001"
let v183 : string = "budget-reservation-1001"
let v184 : string = (let fields = [| v179; v180; v181; v182; v179; v180; string 1000L; v183 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v185 : string = "erp-p2p-" + v124 + "-outbox"
let v186 : string = v178 + "|payload=" + v184 + "|outbox=" + v185
let v187 : string = "erp-p2p-" + v124 + "-outbox"
let v188 : string = v187 + "|aggregate=erp-p2p-aggregate:" + v187 + "|command=erp-p2p-command:" + v187
let v189 : string = (let fields = [| v179; v180; v181; v182; v179; v180; string 2000L; v183 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v190 : string = "erp-p2p-" + v124 + "-outbox"
let v191 : string = v188 + "|payload=" + v189 + "|outbox=" + v190
let v192 : bool = v174 = v176
let v193 : bool = v186 = v191
let v194 : bool = v193 = false
let v195 : bool = v192 && v194
if v195 then
    ()
else
    failwith<unit> "erp-p2p-physical-identity-payload-sensitivity-mismatch"
let v196 : int64 = 0L + 1L
let v197 : int64 = v196 + 1L
let v198 : int64 = v197 + 1L
let v199 : int64 = 0L + 1L
let v200 : int64 = v199 + 1L
let v201 : int64 = v200 + 1L
let v202 : string = "purchase-order-issued"
if v198 <> 3L || v201 <> 3L || v202 <> "purchase-order-issued" || v202 <> "purchase-order-issued" then failwith "erp-p2p-three-event-store-runtime-mismatch"
let v203 : int64 = 0L + 1L
let v204 : int64 = v203 + 1L
let v205 : int64 = v204 + 1L
let v206 : int64 = v205 + 1L
let v207 : int64 = 0L + 1L
let v208 : int64 = v207 + 1L
let v209 : int64 = v208 + 1L
let v210 : int64 = v209 + 1L
if v206 <> 4L || v210 <> 4L || v68 <> "goods-partially-received" || v68 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v211 : int64 = 0L + 1L
let v212 : int64 = v211 + 1L
let v213 : int64 = v212 + 1L
let v214 : int64 = v213 + 1L
let v215 : int64 = v214 + 1L
let v216 : int64 = 0L + 1L
let v217 : int64 = v216 + 1L
let v218 : int64 = v217 + 1L
let v219 : int64 = v218 + 1L
let v220 : int64 = v219 + 1L
let v221 : string = "invoice-three-way-matched"
if v215 <> 5L || v220 <> 5L || v221 <> "invoice-three-way-matched" || v221 <> "invoice-three-way-matched" then failwith "erp-p2p-five-event-store-runtime-mismatch"
let v222 : int64 = -1L * 830L
let v223 : string = "warehouse-north"
let v224 : string = "BR"
let v225 : string = "po-1001"
let v226 : string = "invoice-match-1001"
let v227 : string = "company-b"
let v228 : string = "company-a-intercompany-receivable-830"
let v229 : string = "company-b-intercompany-payable-minus-830"
let v230 : string = (let fields = [| v179; v180; v181; v223; v224; v225; v226; v179; v227; v180; v225; string 830L; v228; v227; v179; v180; v225; string v222; v229 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v231 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v230 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v232 : bool = 1L = v231
let v237 : US0 =
    if v232 then
        let v233 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US0_ErpNetIntercompanyPayloadDecoded(v233)
    else
        let v235 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US0_ErpNetIntercompanyPayloadRejected(v235)
let v258 : US1 =
    match v237 with
    | US0_ErpNetIntercompanyPayloadDecoded(v238) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v239 : string, v240 : string, v241 : string, v242 : string, v243 : string, v244 : string, v245 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v230 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v246 : string, v247 : string, v248 : string, v249 : string, v250 : int64, v251 : string, v252 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v230 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v253 : US2 = US2_OpposedMirrorPair(v246, v247, v248, v249, v250, v251, v252)
        US1_NetIntercompany(v239, v240, v241, v242, v243, v244, v245, v253)
    | US0_ErpNetIntercompanyPayloadRejected(v255) -> (* ErpNetIntercompanyPayloadRejected *)
        let v256 : US1 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v255)
        v256
let v295 : string =
    match v258 with
    | US1_NetIntercompany(v259, v260, v261, v262, v263, v264, v265, v266) -> (* NetIntercompany *)
        let struct (v274 : string, v275 : string, v276 : string, v277 : string, v278 : int64, v279 : string) =
            match v266 with
            | US2_OpposedMirrorPair(v267, v268, v269, v270, v271, v272, v273) -> (* OpposedMirrorPair *)
                struct (v267, v268, v269, v270, v271, v272)
        let struct (v288 : string, v289 : string, v290 : string, v291 : string, v292 : int64, v293 : string) =
            match v266 with
            | US2_OpposedMirrorPair(v280, v281, v282, v283, v284, v285, v286) -> (* OpposedMirrorPair *)
                let v287 : int64 = -1L * v284
                struct (v281, v280, v282, v283, v287, v286)
        let v294 : string = (let fields = [| v259; v260; v261; v262; v263; v264; v265; v274; v275; v276; v277; string v278; v279; v288; v289; v290; v291; string v292; v293 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v294
method0(v230, v295)
let v296 : int64 = 0L + 1L
let v297 : int64 = v296 + 1L
let v298 : int64 = v297 + 1L
let v299 : int64 = v298 + 1L
let v300 : int64 = v299 + 1L
let v301 : int64 = v300 + 1L
let v302 : int64 = 0L + 1L
let v303 : int64 = v302 + 1L
let v304 : int64 = v303 + 1L
let v305 : int64 = v304 + 1L
let v306 : int64 = v305 + 1L
let v307 : int64 = v306 + 1L
let v317 : string =
    match v258 with
    | US1_NetIntercompany(v308, v309, v310, v311, v312, v313, v314, v315) -> (* NetIntercompany *)
        let v316 : string = "intercompany-netted"
        v316
let v327 : string =
    match v258 with
    | US1_NetIntercompany(v318, v319, v320, v321, v322, v323, v324, v325) -> (* NetIntercompany *)
        let v326 : string = "intercompany-netted"
        v326
if v301 <> 6L || v307 <> 6L || v317 <> "intercompany-netted" || v327 <> "intercompany-netted" then failwith "erp-p2p-six-event-store-runtime-mismatch"
let v328 : int64 = -1L * 830L
let v329 : string = (let fields = [| v179; v180; v181; v223; v224; v225; v226; v179; v227; v180; v225; string 830L; v228; v227; v179; v180; v225; string v328; v229 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v330 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v329 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v331 : bool = 1L = v330
let v336 : US0 =
    if v331 then
        let v332 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US0_ErpNetIntercompanyPayloadDecoded(v332)
    else
        let v334 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US0_ErpNetIntercompanyPayloadRejected(v334)
let v357 : US1 =
    match v336 with
    | US0_ErpNetIntercompanyPayloadDecoded(v337) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v338 : string, v339 : string, v340 : string, v341 : string, v342 : string, v343 : string, v344 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v329 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v345 : string, v346 : string, v347 : string, v348 : string, v349 : int64, v350 : string, v351 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v329 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v352 : US2 = US2_OpposedMirrorPair(v345, v346, v347, v348, v349, v350, v351)
        US1_NetIntercompany(v338, v339, v340, v341, v342, v343, v344, v352)
    | US0_ErpNetIntercompanyPayloadRejected(v354) -> (* ErpNetIntercompanyPayloadRejected *)
        let v355 : US1 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v354)
        v355
let v394 : string =
    match v357 with
    | US1_NetIntercompany(v358, v359, v360, v361, v362, v363, v364, v365) -> (* NetIntercompany *)
        let struct (v373 : string, v374 : string, v375 : string, v376 : string, v377 : int64, v378 : string) =
            match v365 with
            | US2_OpposedMirrorPair(v366, v367, v368, v369, v370, v371, v372) -> (* OpposedMirrorPair *)
                struct (v366, v367, v368, v369, v370, v371)
        let struct (v387 : string, v388 : string, v389 : string, v390 : string, v391 : int64, v392 : string) =
            match v365 with
            | US2_OpposedMirrorPair(v379, v380, v381, v382, v383, v384, v385) -> (* OpposedMirrorPair *)
                let v386 : int64 = -1L * v383
                struct (v380, v379, v381, v382, v386, v385)
        let v393 : string = (let fields = [| v358; v359; v360; v361; v362; v363; v364; v373; v374; v375; v376; string v377; v378; v387; v388; v389; v390; string v391; v392 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v393
method0(v329, v394)
method1(v329)
method0(v329, v394)
let struct (v403 : string, v404 : string, v405 : string, v406 : string, v407 : string, v408 : string, v409 : string) =
    match v357 with
    | US1_NetIntercompany(v395, v396, v397, v398, v399, v400, v401, v402) -> (* NetIntercompany *)
        struct (v395, v396, v397, v398, v399, v400, v401)
let struct (v418 : string, v419 : string, v420 : string, v421 : string, v422 : string, v423 : string, v424 : string) =
    match v357 with
    | US1_NetIntercompany(v410, v411, v412, v413, v414, v415, v416, v417) -> (* NetIntercompany *)
        struct (v410, v411, v412, v413, v414, v415, v416)
let v425 : int64 = 0L + 1L
let v426 : int64 = v425 + 1L
let v427 : int64 = v426 + 1L
let v428 : int64 = v427 + 1L
let v429 : int64 = v428 + 1L
let v430 : int64 = v429 + 1L
let v431 : int64 = v430 + 1L
let v432 : int64 = 0L + 1L
let v433 : int64 = v432 + 1L
let v434 : int64 = v433 + 1L
let v435 : int64 = v434 + 1L
let v436 : int64 = v435 + 1L
let v437 : int64 = v436 + 1L
let v438 : int64 = v437 + 1L
let v439 : string = "payment-settled-through-composed-typed-fx-route"
if v431 <> 7L || v438 <> 7L || v439 <> "payment-settled-through-composed-typed-fx-route" || v439 <> "payment-settled-through-composed-typed-fx-route" then failwith "erp-p2p-seven-event-store-runtime-mismatch"
let v440 : int64 = -1L * 830L
let v441 : string = (let fields = [| v179; v180; v181; v223; v224; v225; v226; v179; v227; v180; v225; string 830L; v228; v227; v179; v180; v225; string v440; v229 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v442 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v441 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v443 : bool = 1L = v442
let v448 : US0 =
    if v443 then
        let v444 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US0_ErpNetIntercompanyPayloadDecoded(v444)
    else
        let v446 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US0_ErpNetIntercompanyPayloadRejected(v446)
let v469 : US1 =
    match v448 with
    | US0_ErpNetIntercompanyPayloadDecoded(v449) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v450 : string, v451 : string, v452 : string, v453 : string, v454 : string, v455 : string, v456 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v441 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v457 : string, v458 : string, v459 : string, v460 : string, v461 : int64, v462 : string, v463 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v441 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v464 : US2 = US2_OpposedMirrorPair(v457, v458, v459, v460, v461, v462, v463)
        US1_NetIntercompany(v450, v451, v452, v453, v454, v455, v456, v464)
    | US0_ErpNetIntercompanyPayloadRejected(v466) -> (* ErpNetIntercompanyPayloadRejected *)
        let v467 : US1 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v466)
        v467
let v506 : string =
    match v469 with
    | US1_NetIntercompany(v470, v471, v472, v473, v474, v475, v476, v477) -> (* NetIntercompany *)
        let struct (v485 : string, v486 : string, v487 : string, v488 : string, v489 : int64, v490 : string) =
            match v477 with
            | US2_OpposedMirrorPair(v478, v479, v480, v481, v482, v483, v484) -> (* OpposedMirrorPair *)
                struct (v478, v479, v480, v481, v482, v483)
        let struct (v499 : string, v500 : string, v501 : string, v502 : string, v503 : int64, v504 : string) =
            match v477 with
            | US2_OpposedMirrorPair(v491, v492, v493, v494, v495, v496, v497) -> (* OpposedMirrorPair *)
                let v498 : int64 = -1L * v495
                struct (v492, v491, v493, v494, v498, v497)
        let v505 : string = (let fields = [| v470; v471; v472; v473; v474; v475; v476; v485; v486; v487; v488; string v489; v490; v499; v500; v501; v502; string v503; v504 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v505
method0(v441, v506)
method1(v441)
method0(v441, v506)
let struct (v515 : string, v516 : string, v517 : string, v518 : string, v519 : string, v520 : string, v521 : string) =
    match v469 with
    | US1_NetIntercompany(v507, v508, v509, v510, v511, v512, v513, v514) -> (* NetIntercompany *)
        struct (v507, v508, v509, v510, v511, v512, v513)
let struct (v530 : string, v531 : string, v532 : string, v533 : string, v534 : string, v535 : string, v536 : string) =
    match v469 with
    | US1_NetIntercompany(v522, v523, v524, v525, v526, v527, v528, v529) -> (* NetIntercompany *)
        struct (v522, v523, v524, v525, v526, v527, v528)
let v537 : int64 = 0L + 1L
let v538 : int64 = v537 + 1L
let v539 : int64 = v538 + 1L
let v540 : int64 = v539 + 1L
let v541 : int64 = v540 + 1L
let v542 : int64 = v541 + 1L
let v543 : int64 = v542 + 1L
let v544 : int64 = v543 + 1L
let v545 : int64 = 0L + 1L
let v546 : int64 = v545 + 1L
let v547 : int64 = v546 + 1L
let v548 : int64 = v547 + 1L
let v549 : int64 = v548 + 1L
let v550 : int64 = v549 + 1L
let v551 : int64 = v550 + 1L
let v552 : int64 = v551 + 1L
let v553 : string = "period-closed"
if v544 <> 8L || v552 <> 8L || v553 <> "period-closed" || v553 <> "period-closed" then failwith "erp-p2p-eight-event-store-runtime-mismatch"
let v554 : string = "erp-burnin-group0"
v554
