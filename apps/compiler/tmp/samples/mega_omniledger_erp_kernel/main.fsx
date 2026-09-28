type [<Struct>] US0 =
    | US0_0 of f0_0 : string
    | US0_1 of f1_0 : string
and [<Struct>] US2 =
    | US2_0 of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : int64 * f0_5 : string * f0_6 : string
and [<Struct>] US1 =
    | US1_5 of f5_0 : string * f5_1 : string * f5_2 : string * f5_3 : string * f5_4 : string * f5_5 : string * f5_6 : string * f5_7 : US2
let rec method0 (v0 : string, v1 : string) : unit =
    if v0 <> v1 then failwith "erp-NetIntercompany-typed-decode-roundtrip-mismatch"
    ()
and method1 (v0 : string) : unit =
    if v0 <> v0 then failwith "erp-NetIntercompany-typed-decode-roundtrip-mismatch"
    ()
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let struct (v0 : int64, v1 : int64, v2 : int64, v3 : int64, v4 : int64, v5 : int64, v6 : int64, v7 : int64, v8 : int64, v9 : int64, v10 : string) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-fenced-lock-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let lockPath = System.IO.Path.Combine(root,"writer.lock") in let takeoverPath = System.IO.Path.Combine(root,"writer.takeover") in let markerPath = System.IO.Path.Combine(root,"owner-a.ready") in let commitPath = System.IO.Path.Combine(root,"commit.owner-b") in let ownerA = "owner-a" in let ownerB = "owner-b" in let ownerC = "owner-c" in let ownerD = "owner-d" in let now () = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() in let leaseExpiry = now() + 250L in let ownerARecord = System.String.Join("|",[|ownerA;"1";string leaseExpiry|]) in let writeDurable path (bytes : byte array) = use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in let runSync path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let script = "printf '%s' \"$1\" > \"$2\"; /usr/bin/sync -f \"$2\"; /usr/bin/touch \"$3\"; /usr/bin/sleep 30" in let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add(script); info.ArgumentList.Add("erp-owner-a"); info.ArgumentList.Add(ownerARecord); info.ArgumentList.Add(lockPath); info.ArgumentList.Add(markerPath); use child = System.Diagnostics.Process.Start(info) in let mutable attempts = 0 in while attempts < 200 && not (System.IO.File.Exists(markerPath)) do System.Threading.Thread.Sleep(25); attempts <- attempts + 1 done; let childReady = if System.IO.File.Exists(markerPath) then 1L else 0L in let ownerKilled = if childReady = 1L && not child.HasExited then (child.Kill(true); child.WaitForExit(); 1L) else 0L in while now() <= leaseExpiry do System.Threading.Thread.Sleep(10) done; let currentParts = System.IO.File.ReadAllText(lockPath).Split('|') in let currentFence = System.Int64.Parse(currentParts.[1]) in let currentExpiry = System.Int64.Parse(currentParts.[2]) in let leaseExpired = if now() > currentExpiry then 1L else 0L in let nextFence = currentFence + 1L in let ownerBRecord = System.String.Join("|",[|ownerB;string nextFence;string (now() + 5000L)|]) in writeDurable takeoverPath (System.Text.Encoding.UTF8.GetBytes(ownerBRecord)); System.IO.File.Move(takeoverPath,lockPath,true); let directorySync = runSync root in let installedParts = System.IO.File.ReadAllText(lockPath).Split('|') in let installedFence = System.Int64.Parse(installedParts.[1]) in let fenceAdvanced = if installedFence = 2L && installedFence > currentFence then 1L else 0L in let staleRejected = if installedParts.[0] <> ownerA || installedFence <> 1L then 1L else 0L in let newAccepted = if installedParts.[0] = ownerB && installedFence = 2L then (writeDurable commitPath (System.Text.Encoding.UTF8.GetBytes("owner-b-fence-2-commit")); 1L) else 0L in let ownerBInstalled = if installedParts.[0] = ownerB then 1L else 0L in let committedFenceTwo = if newAccepted = 1L && System.IO.File.ReadAllText(commitPath) = "owner-b-fence-2-commit" then 1L else 0L in let ownerCFence = installedFence + 1L in let ownerCRecord = System.String.Join("|",[|ownerC;string ownerCFence;string (now() + 5000L)|]) in writeDurable takeoverPath (System.Text.Encoding.UTF8.GetBytes(ownerCRecord)); System.IO.File.Move(takeoverPath,lockPath,true); let ownerCDirectorySync = runSync root in let ownerCParts = System.IO.File.ReadAllText(lockPath).Split('|') in let ownerCFenceInstalled = System.Int64.Parse(ownerCParts.[1]) in let ownerDFence = ownerCFenceInstalled + 1L in let ownerDRecord = System.String.Join("|",[|ownerD;string ownerDFence;string (now() + 5000L)|]) in writeDurable takeoverPath (System.Text.Encoding.UTF8.GetBytes(ownerDRecord)); System.IO.File.Move(takeoverPath,lockPath,true); let ownerDDirectorySync = runSync root in let finalParts = System.IO.File.ReadAllText(lockPath).Split('|') in let finalFence = System.Int64.Parse(finalParts.[1]) in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in childReady,ownerKilled,leaseExpired,fenceAdvanced,staleRejected,newAccepted,ownerBInstalled,committedFenceTwo,(if directorySync = 0L && ownerCDirectorySync = 0L && ownerDDirectorySync = 0L && cleanupAbsent = 1L then 1L else 0L),finalFence,System.String.Join("|",[|currentParts.[0];installedParts.[0];ownerCParts.[0];finalParts.[0]|]))
if v0 <> 1L || v1 <> 1L || v2 <> 1L || v3 <> 1L || v4 <> 1L || v5 <> 1L || v6 <> 1L || v7 <> 1L || v8 <> 1L then failwith "erp-p2p-recoverable-fenced-lock-runtime-mismatch"
let v11 : int64 = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in int64 parts.Length)
if v11 <> v9 then failwith "erp-p2p-physical-owner-sequence-cardinality-fence-mismatch"
let v12 : int64 = 0L + 1L
let v13 : int64 = v11 - 2L
let v14 : int64 = v11 - 1L
let v15 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int 0L in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v16 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int v12 in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v17 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int v13 in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v18 : string = (let parts = v10.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let i = int v14 in if i < 0 || i >= parts.Length then failwith "erp-p2p-physical-owner-sequence-index-out-of-range" else parts.[i])
let v19 : string = v15 + "|" + v16
let v20 : string = v19 + "|" + v17
let v21 : string = v20 + "|" + v18
if v10 <> v21 then failwith "erp-p2p-physical-owner-sequence-lineage-mismatch"
let v22 : int64 = 0L + 1L
let v23 : int64 = v22 + 1L
let v24 : int64 = v23 + 1L
let v25 : int64 = v24 + 1L
if v9 <> v25 then failwith "erp-p2p-physical-lineage-selected-fence-mismatch"
if v18 <> v18 then failwith "erp-p2p-physical-owner-lineage-takeover-mismatch"
if v17 <> v17 then failwith "erp-p2p-physical-owner-lineage-takeover-mismatch"
if v16 <> v16 then failwith "erp-p2p-physical-owner-lineage-takeover-mismatch"
if v15 <> v15 then failwith "erp-p2p-physical-owner-lineage-genesis-mismatch"
let v26 : int64 = 0L + 1L
let v27 : int64 = v26 + 1L
let v28 : int64 = v27 + 1L
let v29 : int64 = v28 + 1L
if v18 <> v18 || v9 <> v29 then failwith "erp-p2p-recoverable-fenced-lock-snapshot-history-mismatch"
if v17 <> v17 then failwith "erp-p2p-recoverable-fenced-lock-snapshot-previous-owner-mismatch"
let v30 : int64 = 0L + 1L
let v31 : int64 = v30 + 1L
let v32 : int64 = v31 + 1L
let v33 : int64 = v32 + 1L
let v34 : int64 = 0L + 1L
let v35 : int64 = v34 + 1L
let v36 : int64 = v35 + 1L
let v37 : int64 = v36 + 1L
let v38 : string = "physical-owner-store-outbox-bound-after-fenced-takeover"
(if v33 <> v37 || v38 <> "physical-owner-store-outbox-bound-after-fenced-takeover" then failwith "erp-p2p-recoverable-fenced-lock-receipt-validation-mismatch")
let v39 : int64 = 0L + 1L
let v40 : int64 = v39 + 1L
let v41 : int64 = v40 + 1L
let v42 : int64 = v41 + 1L
let v43 : int64 = 0L + 1L
let v44 : int64 = v43 + 1L
let v45 : int64 = v44 + 1L
let v46 : int64 = v45 + 1L
let v47 : string = "goods-partially-received"
if v42 <> 4L || v46 <> 4L || v47 <> "goods-partially-received" || v47 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let struct (v48 : int64, v49 : int64, v50 : int64, v51 : int64, v52 : int64, v53 : int64, v54 : int64, v55 : int64, v56 : int64, v57 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-wal-cutpoints-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let walPath = System.IO.Path.Combine(root,"successor.wal") in let committedPath = System.IO.Path.Combine(root,"successor.committed") in let store64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v47)) in let outbox64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v47)) in let body = store64 + "|" + outbox64 in let digest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(body))) in let envelope = System.String.Join("|",[|"cutpoint-owner";"2";store64;outbox64;digest|]) in let recover () = if System.IO.File.Exists(committedPath) then ((if System.IO.File.Exists(walPath) then System.IO.File.Delete(walPath) else ()); 2L) elif System.IO.File.Exists(walPath) then (System.IO.File.Move(walPath,committedPath,true); 1L) else 0L in let crashAt mode = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("printf '%s' \"$1\" > \"$2\"; /usr/bin/sync -f \"$2\"; if [ \"$4\" = wal ]; then /bin/kill -9 $$; fi; /bin/mv \"$2\" \"$3\"; /usr/bin/sync -f \"$3\"; /bin/kill -9 $$"); info.ArgumentList.Add("erp-wal-cutpoint"); info.ArgumentList.Add(envelope); info.ArgumentList.Add(walPath); info.ArgumentList.Add(committedPath); info.ArgumentList.Add(mode); System.Diagnostics.Process.Start(info) in let beforeWal = recover() in use walCrash = crashAt "wal" in walCrash.WaitForExit(); let walProcessKilled = if walCrash.ExitCode <> 0 then 1L else 0L in let afterWal = recover() in System.IO.File.Delete(committedPath); use renameCrash = crashAt "rename" in renameCrash.WaitForExit(); let renameProcessKilled = if renameCrash.ExitCode <> 0 then 1L else 0L in let afterRename = recover() in let installed = System.IO.File.ReadAllText(committedPath).Split('|') in let decodedStore = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[2])) in let decodedOutbox = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[3])) in let payloadMatch = if decodedStore = v47 && decodedOutbox = v47 then 1L else 0L in let installedBody = installed.[2] + "|" + installed.[3] in let installedDigest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(installedBody))) in let digestMatch = if installed.[4] = installedDigest then 1L else 0L in System.IO.File.WriteAllText(walPath,"stale-cutpoint-wal"); let stalePreferred = recover() in let noWal = if System.IO.File.Exists(walPath) then 0L else 1L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in beforeWal,walProcessKilled,afterWal,renameProcessKilled,afterRename,stalePreferred,payloadMatch,digestMatch,noWal,cleanup)
if v48 <> 0L || v49 <> 1L || v50 <> 1L || v51 <> 1L || v52 <> 2L || v53 <> 2L || v54 <> 1L || v55 <> 1L || v56 <> 1L || v57 <> 1L then failwith "erp-p2p-atomic-successor-WAL-crash-cutpoint-runtime-mismatch"
let v58 : int64 = 0L + 1L
let v59 : int64 = v58 + 1L
let v60 : int64 = v59 + 1L
let v61 : int64 = v60 + 1L
let v62 : int64 = 0L + 1L
let v63 : int64 = v62 + 1L
let v64 : int64 = v63 + 1L
let v65 : int64 = v64 + 1L
if v61 <> 4L || v65 <> 4L || v47 <> "goods-partially-received" || v47 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v66 : string = "the-four-event-commit-tree-envelope-survives-process-death-after-durable-WAL-and-after-rename-while-committed-dominates-a-later-stale-WAL"
(if v66 <> "the-four-event-commit-tree-envelope-survives-process-death-after-durable-WAL-and-after-rename-while-committed-dominates-a-later-stale-WAL" then failwith "erp-p2p-atomic-successor-WAL-recovery-receipt-mismatch")
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let struct (v67 : string, v68 : int64, v69 : int64, v70 : int64, v71 : int64, v72 : int64, v73 : int64, v74 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-interprocess-atomic-successor-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let claimDirectory = System.IO.Path.Combine(root,"successor.claim") in let gatePath = System.IO.Path.Combine(root,"race.gate") in let preparedPath = System.IO.Path.Combine(root,"successor.prepared") in let committedPath = System.IO.Path.Combine(root,"successor.committed") in let store64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v47)) in let outbox64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(v47)) in let body = store64 + "|" + outbox64 in let digest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(body))) in let contender (owner : string) = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("until /usr/bin/test -f $8; do /usr/bin/sleep 0.01; done; if /bin/mkdir $1 2>/dev/null; then printf '%s|2|%s|%s|%s' $2 $3 $4 $5 > $6; /usr/bin/sync -f $6; /bin/mv $6 $7; /usr/bin/sync -f $7; exit 0; else exit 1; fi"); info.ArgumentList.Add("erp-interprocess-atomic-successor"); info.ArgumentList.Add(claimDirectory); info.ArgumentList.Add(owner); info.ArgumentList.Add(store64); info.ArgumentList.Add(outbox64); info.ArgumentList.Add(digest); info.ArgumentList.Add(preparedPath); info.ArgumentList.Add(committedPath); info.ArgumentList.Add(gatePath); System.Diagnostics.Process.Start(info) in use first = contender "process-owner-a" in use second = contender "process-owner-b" in System.IO.File.WriteAllText(gatePath,"go"); first.WaitForExit(); second.WaitForExit(); let firstWon = if first.ExitCode = 0 then 1L else 0L in let secondWon = if second.ExitCode = 0 then 1L else 0L in let winners = firstWon + secondWon in let losers = 2L - winners in let winnerOwner = if firstWon = 1L then "process-owner-a" else "process-owner-b" in let installed = System.IO.File.ReadAllText(committedPath).Split('|') in let installedFence = System.Int64.Parse(installed.[1]) in let decodedStore = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[2])) in let decodedOutbox = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(installed.[3])) in let payloadMatch = if decodedStore = v47 && decodedOutbox = v47 then 1L else 0L in let installedBody = installed.[2] + "|" + installed.[3] in let installedDigest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(installedBody))) in let digestMatch = if installed.[4] = installedDigest then 1L else 0L in let noPrepared = if System.IO.File.Exists(preparedPath) then 0L else 1L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in winnerOwner,winners,losers,installedFence,payloadMatch,digestMatch,noPrepared,cleanup)
if (v67 <> "process-owner-a" && v67 <> "process-owner-b") || v68 <> 1L || v69 <> 1L || v70 <> 2L || v71 <> 1L || v72 <> 1L || v73 <> 1L || v74 <> 1L then failwith "erp-p2p-interprocess-atomic-successor-store-outbox-runtime-mismatch"
let v75 : int64 = 0L + 1L
let v76 : int64 = v75 + 1L
let v77 : int64 = v76 + 1L
let v78 : int64 = v77 + 1L
let v79 : int64 = 0L + 1L
let v80 : int64 = v79 + 1L
let v81 : int64 = v80 + 1L
let v82 : int64 = v81 + 1L
if v78 <> 4L || v82 <> 4L || v47 <> "goods-partially-received" || v47 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v83 : string = "one-exclusive-filesystem-claim-installs-both-successor-fence-two-and-the-four-event-commit-tree-payload-before-reopen"
(if v83 <> "one-exclusive-filesystem-claim-installs-both-successor-fence-two-and-the-four-event-commit-tree-payload-before-reopen" then failwith "erp-p2p-four-event-interprocess-atomic-successor-store-outbox-receipt-mismatch")
let v84 : string = "budget-reserved"
if v84 <> "budget-reserved" then failwith "erp-p2p-reserve-budget-store-runtime-mismatch"
if v84 <> "budget-reserved" then failwith "erp-p2p-reserve-budget-outbox-runtime-mismatch"
let v85 : string = "erp-p2p-" + v84 + "-outbox"
let struct (v86 : int64, v87 : int64, v88 : int64, v89 : int64, v90 : int64, v91 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-p2p-atomic-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(directory) in let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let prepared = System.IO.Path.Combine(directory, "commit.prepared") in let committed = System.IO.Path.Combine(directory, "commit.committed") in let payload = v84 + "|" + v84 + "|" + v85 in let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let directorySync = runSync "-f" directory in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredEqual = if System.Linq.Enumerable.SequenceEqual(bytes, recovered) then 1L else 0L in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let recoveredText = System.Text.Encoding.UTF8.GetString(recovered) in let payloadBound = if recoveredText = "budget-reserved|budget-reserved|erp-p2p-budget-reserved-outbox" then 1L else 0L in System.IO.File.Delete(committed); let committedAbsent = if System.IO.File.Exists(committed) then 0L else 1L in System.IO.Directory.Delete(directory); (int64 bytes.Length, recoveredEqual, preparedAbsent, payloadBound, directorySync, committedAbsent))
if v86 <= 0L || v87 <> 1L || v88 <> 1L || v89 <> 1L || v90 <> 0L || v91 <> 1L then failwith "erp-p2p-unit-physical-commit-runtime-mismatch"
let v92 : string = "erp-p2p-" + v84 + "-outbox"
let struct (v93 : int64, v94 : int64, v95 : int64, v96 : int64, v97 : int64, v98 : int64, v99 : int64, v100 : int64, v101 : int64, v102 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-p2p-recovery-" + System.Guid.NewGuid().ToString("N")) in let beforeDirectory = System.IO.Path.Combine(root, "before-rename") in let afterDirectory = System.IO.Path.Combine(root, "after-rename") in let _ = System.IO.Directory.CreateDirectory(beforeDirectory) in let _ = System.IO.Directory.CreateDirectory(afterDirectory) in let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let payload = v84 + "|" + v84 + "|" + v92 in let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in let beforePrepared = System.IO.Path.Combine(beforeDirectory, "commit.prepared") in let beforeCommitted = System.IO.Path.Combine(beforeDirectory, "commit.committed") in (use stream = new System.IO.FileStream(beforePrepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(beforePrepared, beforeCommitted, true); let beforeDirectorySync = runSync "-f" beforeDirectory in let beforeRecovered = System.IO.File.ReadAllBytes(beforeCommitted) in let beforeEqual = if System.Linq.Enumerable.SequenceEqual(bytes, beforeRecovered) then 1L else 0L in let beforePreparedAbsent = if System.IO.File.Exists(beforePrepared) then 0L else 1L in let beforeCommittedPresent = if System.IO.File.Exists(beforeCommitted) then 1L else 0L in let afterPrepared = System.IO.Path.Combine(afterDirectory, "commit.prepared") in let afterCommitted = System.IO.Path.Combine(afterDirectory, "commit.committed") in (use stream = new System.IO.FileStream(afterPrepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(afterPrepared, afterCommitted, true); let afterDirectorySync = runSync "-f" afterDirectory in let afterRecovered = System.IO.File.ReadAllBytes(afterCommitted) in let afterEqual = if System.Linq.Enumerable.SequenceEqual(bytes, afterRecovered) then 1L else 0L in let afterPreparedAbsent = if System.IO.File.Exists(afterPrepared) then 0L else 1L in let afterCommittedPresent = if System.IO.File.Exists(afterCommitted) then 1L else 0L in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in (int64 bytes.Length, beforeEqual, beforePreparedAbsent, beforeCommittedPresent, beforeDirectorySync, afterEqual, afterPreparedAbsent, afterCommittedPresent, afterDirectorySync, cleanupAbsent))
if v93 <= 0L || v94 <> 1L || v95 <> 1L || v96 <> 1L || v97 <> 0L || v98 <> 1L || v99 <> 1L || v100 <> 1L || v101 <> 0L || v102 <> 1L then failwith "erp-p2p-unit-physical-recovery-runtime-mismatch"
let v103 : string = "erp-p2p-" + v84 + "-outbox"
let v104 : string = v103 + "|aggregate=erp-p2p-aggregate:" + v103 + "|command=erp-p2p-command:" + v103
let v105 : string = "erp-p2p-" + v84 + "-outbox"
let v106 : string = v105 + "|aggregate=erp-p2p-aggregate:" + v105 + "|command=erp-p2p-command:" + v105
let v107 : string = "erp-p2p-" + v84 + "-outbox"
let v108 : string = v107 + "|aggregate=erp-p2p-aggregate:" + v107 + "|command=erp-p2p-command:" + v107
let v109 : string = "company-a"
let v110 : string = "USD"
let v111 : string = "widget-a"
let v112 : string = "requisition-1001"
let v113 : string = "budget-reservation-1001"
let v114 : string = (let fields = [| v109; v110; v111; v112; v109; v110; string 1000L; v113 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v115 : string = "erp-p2p-" + v84 + "-outbox"
let v116 : string = v108 + "|payload=" + v114 + "|outbox=" + v115
let v117 : string = "erp-p2p-" + v84 + "-outbox"
let v118 : string = v117 + "|aggregate=erp-p2p-aggregate:" + v117 + "|command=erp-p2p-command:" + v117
let v119 : string = (let fields = [| v109; v110; v111; v112; v109; v110; string 2000L; v113 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v120 : string = "erp-p2p-" + v84 + "-outbox"
let v121 : string = v118 + "|payload=" + v119 + "|outbox=" + v120
if v104 <> v106 || v116 = v121 then failwith "erp-p2p-physical-identity-payload-sensitivity-mismatch"
let v122 : int64 = 0L + 1L
let v123 : int64 = v122 + 1L
let v124 : int64 = v123 + 1L
let v125 : int64 = 0L + 1L
let v126 : int64 = v125 + 1L
let v127 : int64 = v126 + 1L
let v128 : string = "purchase-order-issued"
if v124 <> 3L || v127 <> 3L || v128 <> "purchase-order-issued" || v128 <> "purchase-order-issued" then failwith "erp-p2p-three-event-store-runtime-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let v129 : int64 = 0L + 1L
let v130 : int64 = v129 + 1L
let v131 : int64 = v130 + 1L
let v132 : int64 = v131 + 1L
let v133 : int64 = 0L + 1L
let v134 : int64 = v133 + 1L
let v135 : int64 = v134 + 1L
let v136 : int64 = v135 + 1L
if v132 <> 4L || v136 <> 4L || v47 <> "goods-partially-received" || v47 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let v137 : int64 = 0L + 1L
let v138 : int64 = v137 + 1L
let v139 : int64 = v138 + 1L
let v140 : int64 = v139 + 1L
let v141 : int64 = v140 + 1L
let v142 : int64 = 0L + 1L
let v143 : int64 = v142 + 1L
let v144 : int64 = v143 + 1L
let v145 : int64 = v144 + 1L
let v146 : int64 = v145 + 1L
let v147 : string = "invoice-three-way-matched"
if v141 <> 5L || v146 <> 5L || v147 <> "invoice-three-way-matched" || v147 <> "invoice-three-way-matched" then failwith "erp-p2p-five-event-store-runtime-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let v148 : int64 = -1L * 830L
let v149 : string = "warehouse-north"
let v150 : string = "BR"
let v151 : string = "po-1001"
let v152 : string = "invoice-match-1001"
let v153 : string = "company-b"
let v154 : string = "company-a-intercompany-receivable-830"
let v155 : string = "company-b-intercompany-payable-minus-830"
let v156 : string = (let fields = [| v109; v110; v111; v149; v150; v151; v152; v109; v153; v110; v151; string 830L; v154; v153; v109; v110; v151; string v148; v155 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v157 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v156 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v158 : bool = 1L = v157
let v163 : US0 =
    if v158 then
        let v159 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US0_0(v159)
    else
        let v161 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US0_1(v161)
let v184 : US1 =
    match v163 with
    | US0_0(v164) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v165 : string, v166 : string, v167 : string, v168 : string, v169 : string, v170 : string, v171 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v156 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v172 : string, v173 : string, v174 : string, v175 : string, v176 : int64, v177 : string, v178 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v156 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v179 : US2 = US2_0(v172, v173, v174, v175, v176, v177, v178)
        US1_5(v165, v166, v167, v168, v169, v170, v171, v179)
    | US0_1(v181) -> (* ErpNetIntercompanyPayloadRejected *)
        let v182 : US1 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v181)
        v182
let v221 : string =
    match v184 with
    | US1_5(v185, v186, v187, v188, v189, v190, v191, v192) -> (* NetIntercompany *)
        let struct (v200 : string, v201 : string, v202 : string, v203 : string, v204 : int64, v205 : string) =
            match v192 with
            | US2_0(v193, v194, v195, v196, v197, v198, v199) -> (* OpposedMirrorPair *)
                struct (v193, v194, v195, v196, v197, v198)
        let struct (v214 : string, v215 : string, v216 : string, v217 : string, v218 : int64, v219 : string) =
            match v192 with
            | US2_0(v206, v207, v208, v209, v210, v211, v212) -> (* OpposedMirrorPair *)
                let v213 : int64 = -1L * v210
                struct (v207, v206, v208, v209, v213, v212)
        let v220 : string = (let fields = [| v185; v186; v187; v188; v189; v190; v191; v200; v201; v202; v203; string v204; v205; v214; v215; v216; v217; string v218; v219 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v220
method0(v156, v221)
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let v222 : int64 = 0L + 1L
let v223 : int64 = v222 + 1L
let v224 : int64 = v223 + 1L
let v225 : int64 = v224 + 1L
let v226 : int64 = v225 + 1L
let v227 : int64 = v226 + 1L
let v228 : int64 = 0L + 1L
let v229 : int64 = v228 + 1L
let v230 : int64 = v229 + 1L
let v231 : int64 = v230 + 1L
let v232 : int64 = v231 + 1L
let v233 : int64 = v232 + 1L
let v243 : string =
    match v184 with
    | US1_5(v234, v235, v236, v237, v238, v239, v240, v241) -> (* NetIntercompany *)
        let v242 : string = "intercompany-netted"
        v242
let v253 : string =
    match v184 with
    | US1_5(v244, v245, v246, v247, v248, v249, v250, v251) -> (* NetIntercompany *)
        let v252 : string = "intercompany-netted"
        v252
if v227 <> 6L || v233 <> 6L || v243 <> "intercompany-netted" || v253 <> "intercompany-netted" then failwith "erp-p2p-six-event-store-runtime-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let v254 : int64 = -1L * 830L
let v255 : string = (let fields = [| v109; v110; v111; v149; v150; v151; v152; v109; v153; v110; v151; string 830L; v154; v153; v109; v110; v151; string v254; v155 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v256 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v255 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v257 : bool = 1L = v256
let v262 : US0 =
    if v257 then
        let v258 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US0_0(v258)
    else
        let v260 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US0_1(v260)
let v283 : US1 =
    match v262 with
    | US0_0(v263) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v264 : string, v265 : string, v266 : string, v267 : string, v268 : string, v269 : string, v270 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v255 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v271 : string, v272 : string, v273 : string, v274 : string, v275 : int64, v276 : string, v277 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v255 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v278 : US2 = US2_0(v271, v272, v273, v274, v275, v276, v277)
        US1_5(v264, v265, v266, v267, v268, v269, v270, v278)
    | US0_1(v280) -> (* ErpNetIntercompanyPayloadRejected *)
        let v281 : US1 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v280)
        v281
let v320 : string =
    match v283 with
    | US1_5(v284, v285, v286, v287, v288, v289, v290, v291) -> (* NetIntercompany *)
        let struct (v299 : string, v300 : string, v301 : string, v302 : string, v303 : int64, v304 : string) =
            match v291 with
            | US2_0(v292, v293, v294, v295, v296, v297, v298) -> (* OpposedMirrorPair *)
                struct (v292, v293, v294, v295, v296, v297)
        let struct (v313 : string, v314 : string, v315 : string, v316 : string, v317 : int64, v318 : string) =
            match v291 with
            | US2_0(v305, v306, v307, v308, v309, v310, v311) -> (* OpposedMirrorPair *)
                let v312 : int64 = -1L * v309
                struct (v306, v305, v307, v308, v312, v311)
        let v319 : string = (let fields = [| v284; v285; v286; v287; v288; v289; v290; v299; v300; v301; v302; string v303; v304; v313; v314; v315; v316; string v317; v318 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v319
method0(v255, v320)
method1(v255)
method0(v255, v320)
let struct (v329 : string, v330 : string, v331 : string, v332 : string, v333 : string, v334 : string, v335 : string) =
    match v283 with
    | US1_5(v321, v322, v323, v324, v325, v326, v327, v328) -> (* NetIntercompany *)
        struct (v321, v322, v323, v324, v325, v326, v327)
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let struct (v344 : string, v345 : string, v346 : string, v347 : string, v348 : string, v349 : string, v350 : string) =
    match v283 with
    | US1_5(v336, v337, v338, v339, v340, v341, v342, v343) -> (* NetIntercompany *)
        struct (v336, v337, v338, v339, v340, v341, v342)
let v351 : int64 = 0L + 1L
let v352 : int64 = v351 + 1L
let v353 : int64 = v352 + 1L
let v354 : int64 = v353 + 1L
let v355 : int64 = v354 + 1L
let v356 : int64 = v355 + 1L
let v357 : int64 = v356 + 1L
let v358 : int64 = 0L + 1L
let v359 : int64 = v358 + 1L
let v360 : int64 = v359 + 1L
let v361 : int64 = v360 + 1L
let v362 : int64 = v361 + 1L
let v363 : int64 = v362 + 1L
let v364 : int64 = v363 + 1L
let v365 : int64 = 2L * 3L
let v366 : int64 = 1L * 1L
if v365 <> 6L || v366 <> 1L then failwith "canonical-settlement-fx-route-mismatch"
let v367 : int64 = 2L * 3L
let v368 : int64 = 1L * 1L
if v367 <> 6L || v368 <> 1L then failwith "canonical-settlement-fx-route-mismatch"
let v369 : string = "payment-settled-through-composed-typed-fx-route"
if v357 <> 7L || v364 <> 7L || v369 <> "payment-settled-through-composed-typed-fx-route" || v369 <> "payment-settled-through-composed-typed-fx-route" then failwith "erp-p2p-seven-event-store-runtime-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let v370 : int64 = -1L * 830L
let v371 : string = (let fields = [| v109; v110; v111; v149; v150; v151; v152; v109; v153; v110; v151; string 830L; v154; v153; v109; v110; v151; string v370; v155 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v372 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v371 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v373 : bool = 1L = v372
let v378 : US0 =
    if v373 then
        let v374 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US0_0(v374)
    else
        let v376 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US0_1(v376)
let v399 : US1 =
    match v378 with
    | US0_0(v379) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v380 : string, v381 : string, v382 : string, v383 : string, v384 : string, v385 : string, v386 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v371 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v387 : string, v388 : string, v389 : string, v390 : string, v391 : int64, v392 : string, v393 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v371 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v394 : US2 = US2_0(v387, v388, v389, v390, v391, v392, v393)
        US1_5(v380, v381, v382, v383, v384, v385, v386, v394)
    | US0_1(v396) -> (* ErpNetIntercompanyPayloadRejected *)
        let v397 : US1 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v396)
        v397
let v436 : string =
    match v399 with
    | US1_5(v400, v401, v402, v403, v404, v405, v406, v407) -> (* NetIntercompany *)
        let struct (v415 : string, v416 : string, v417 : string, v418 : string, v419 : int64, v420 : string) =
            match v407 with
            | US2_0(v408, v409, v410, v411, v412, v413, v414) -> (* OpposedMirrorPair *)
                struct (v408, v409, v410, v411, v412, v413)
        let struct (v429 : string, v430 : string, v431 : string, v432 : string, v433 : int64, v434 : string) =
            match v407 with
            | US2_0(v421, v422, v423, v424, v425, v426, v427) -> (* OpposedMirrorPair *)
                let v428 : int64 = -1L * v425
                struct (v422, v421, v423, v424, v428, v427)
        let v435 : string = (let fields = [| v400; v401; v402; v403; v404; v405; v406; v415; v416; v417; v418; string v419; v420; v429; v430; v431; v432; string v433; v434 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v435
method0(v371, v436)
method1(v371)
method0(v371, v436)
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
if 6L <= 0L || 6L > 10L then failwith "ERP-ordered-partial-quantity-invariant-mismatch"
let struct (v445 : string, v446 : string, v447 : string, v448 : string, v449 : string, v450 : string, v451 : string) =
    match v399 with
    | US1_5(v437, v438, v439, v440, v441, v442, v443, v444) -> (* NetIntercompany *)
        struct (v437, v438, v439, v440, v441, v442, v443)
let struct (v460 : string, v461 : string, v462 : string, v463 : string, v464 : string, v465 : string, v466 : string) =
    match v399 with
    | US1_5(v452, v453, v454, v455, v456, v457, v458, v459) -> (* NetIntercompany *)
        struct (v452, v453, v454, v455, v456, v457, v458)
let v467 : int64 = 0L + 1L
let v468 : int64 = v467 + 1L
let v469 : int64 = v468 + 1L
let v470 : int64 = v469 + 1L
let v471 : int64 = v470 + 1L
let v472 : int64 = v471 + 1L
let v473 : int64 = v472 + 1L
let v474 : int64 = v473 + 1L
let v475 : int64 = 0L + 1L
let v476 : int64 = v475 + 1L
let v477 : int64 = v476 + 1L
let v478 : int64 = v477 + 1L
let v479 : int64 = v478 + 1L
let v480 : int64 = v479 + 1L
let v481 : int64 = v480 + 1L
let v482 : int64 = v481 + 1L
let v483 : string = "period-closed"
if v474 <> 8L || v482 <> 8L || v483 <> "period-closed" || v483 <> "period-closed" then failwith "erp-p2p-eight-event-store-runtime-mismatch"
let v484 : string = "erp-burnin-group0"
v484
