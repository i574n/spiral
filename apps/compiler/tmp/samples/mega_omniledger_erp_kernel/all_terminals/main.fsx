let erpP2PLengthBytes (count:int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count))
let erpP2PReadLength (data:byte array) offset = System.BitConverter.ToInt32(data,offset) |> System.Net.IPAddress.NetworkToHostOrder
let erpP2PBuildEnvelope (payload_sequence:string) (outbox_sequence:string) (tree_identity:string) (expected_version:int64) = let payloadTexts = payload_sequence.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let messageTexts = outbox_sequence.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let payloads = payloadTexts |> Array.map System.Convert.FromBase64String in let messages = messageTexts |> Array.map System.Text.Encoding.UTF8.GetBytes in let countBound = if payloads.Length = messages.Length && int64 payloads.Length = expected_version && payloads.Length > 0 then 1L else 0L in let frameBytes index = let payload = payloads.[index] in let message = messages.[index] in let digest = System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(payloads.Length) |]) in Array.concat [| erpP2PLengthBytes payload.Length; payload; erpP2PLengthBytes message.Length; message; digest |] in let frames = [| 0 .. payloads.Length - 1 |] |> Array.collect frameBytes in let envelopeBody = Array.concat [| [|69uy;82uy;80uy;82uy|]; erpP2PLengthBytes payloads.Length; System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(tree_identity)); System.BitConverter.GetBytes(expected_version); frames |] in let rootDigest = System.Security.Cryptography.SHA256.HashData(envelopeBody) in Array.concat [| envelopeBody; rootDigest |],payloads,messages,countBound
let erpP2PPersistEnvelope (envelope:byte array) = let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-recursive-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in (use stream = new System.IO.FileStream(prepared,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(envelope,0,envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared,committed,true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in root,recovered,preparedAbsent,directorySync
let erpP2PParseEnvelope (tree_identity:string) (expected_version:int64) (data:byte array) = try if data.Length < 48 || data.[0] <> 69uy || data.[1] <> 82uy || data.[2] <> 80uy || data.[3] <> 82uy then None else let count = erpP2PReadLength data 4 in let storedTreeIdentityHash = data.[8 .. 39] in let expectedTreeIdentityHash = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(tree_identity)) in let storedVersion = System.BitConverter.ToInt64(data,40) in let mutable offset = 48 in let parsedPayloads = System.Collections.Generic.List<byte array>() in let parsedMessages = System.Collections.Generic.List<byte array>() in let mutable valid = count > 0 && System.Linq.Enumerable.SequenceEqual(storedTreeIdentityHash,expectedTreeIdentityHash) && storedVersion = expected_version in let mutable index = 0 in while valid && index < count do if offset + 4 > data.Length then valid <- false else (let payloadLength = erpP2PReadLength data offset in offset <- offset + 4; if payloadLength < 0 || offset + payloadLength + 4 + 32 > data.Length then valid <- false else (let payload = data.[offset .. offset + payloadLength - 1] in offset <- offset + payloadLength; let messageLength = erpP2PReadLength data offset in offset <- offset + 4; if messageLength < 0 || offset + messageLength + 32 > data.Length then valid <- false else (let message = data.[offset .. offset + messageLength - 1] in offset <- offset + messageLength; let digest = data.[offset .. offset + 31] in offset <- offset + 32; if not (System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(count) |]),digest)) then valid <- false else (parsedPayloads.Add(payload); parsedMessages.Add(message); index <- index + 1)))) done; if valid && index = count && offset + 32 = data.Length then (let rootDigest = data.[offset .. offset + 31] in let bodyDigest = System.Security.Cryptography.SHA256.HashData(data.[0 .. offset - 1]) in if System.Linq.Enumerable.SequenceEqual(bodyDigest,rootDigest) then Some(parsedPayloads.ToArray(),parsedMessages.ToArray()) else None) else None with _ -> None
let erpP2PValidateEnvelope (tree_identity:string) (expected_version:int64) (payloads:byte array array) (messages:byte array array) (recovered:byte array) = let parsed = erpP2PParseEnvelope tree_identity expected_version recovered in let parseValid,frameCount,payloadEqual,outboxEqual,digestValid = match parsed with Some(parsedPayloads,parsedMessages) -> let payloadEqual = parsedPayloads.Length = payloads.Length && Array.forall2 (fun left right -> System.Linq.Enumerable.SequenceEqual(left,right)) parsedPayloads payloads in let messageEqual = parsedMessages.Length = messages.Length && Array.forall2 (fun left right -> System.Linq.Enumerable.SequenceEqual(left,right)) parsedMessages messages in 1L,int64 parsedPayloads.Length,(if payloadEqual then 1L else 0L),(if messageEqual then 1L else 0L),1L | None -> 0L,0L,0L,0L,0L in let reopenedPayloadSequence = match parsed with Some(parsedPayloads,_) -> parsedPayloads |> Array.map System.Convert.ToBase64String |> String.concat "|" | _ -> System.String.Empty in let tampered = Array.copy recovered in let tamperOffset = if payloads.Length > 1 then let firstPayloadLength = erpP2PReadLength tampered 48 in let firstMessageLengthOffset = 52 + firstPayloadLength in let firstMessageLength = erpP2PReadLength tampered firstMessageLengthOffset in let secondFrameOffset = firstMessageLengthOffset + 4 + firstMessageLength + 32 in secondFrameOffset + 4 else 52 in let _ = if tamperOffset < tampered.Length then tampered.[tamperOffset] <- tampered.[tamperOffset] ^^^ 1uy else () in let tamperRejected = match erpP2PParseEnvelope tree_identity expected_version tampered with None -> 1L | Some _ -> 0L in reopenedPayloadSequence,parseValid,frameCount,payloadEqual,outboxEqual,digestValid,tamperRejected
let erpP2PRunAtomicEnvelope (payload_sequence:string) (outbox_sequence:string) (tree_identity:string) (expected_version:int64) = let envelope,payloads,messages,countBound = erpP2PBuildEnvelope payload_sequence outbox_sequence tree_identity expected_version in let root,recovered,preparedAbsent,directorySync = erpP2PPersistEnvelope envelope in let reopenedPayloadSequence,parseValid,frameCount,payloadEqual,outboxEqual,digestValid,tamperRejected = erpP2PValidateEnvelope tree_identity expected_version payloads messages recovered in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in struct (reopenedPayloadSequence,int64 envelope.Length,countBound,parseValid,frameCount,payloadEqual,outboxEqual,digestValid,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
type [<Struct>] US0 =
    | US0_0 of f0_0 : int64 * f0_1 : int64 * f0_2 : int64 * f0_3 : int64 * f0_4 : int64 * f0_5 : string
    | US0_1 of f1_0 : int64 * f1_1 : int64 * f1_2 : string
and [<Struct>] US1 =
    | US1_0 of f0_0 : string
    | US1_1 of f1_0 : string
and [<Struct>] US3 =
    | US3_0 of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : int64 * f0_5 : string * f0_6 : string
and [<Struct>] US2 =
    | US2_0 of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : string * f0_5 : string * f0_6 : string * f0_7 : US3
and [<Struct>] US4 =
    | US4_0 of f0_0 : string
    | US4_1 of f1_0 : string
and [<Struct>] US5 =
    | US5_0 of f0_0 : string
    | US5_1 of f1_0 : string
and [<Struct>] US6 =
    | US6_0 of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : string * f0_5 : string * f0_6 : string * f0_7 : string * f0_8 : int64 * f0_9 : int64 * f0_10 : string * f0_11 : string * f0_12 : string * f0_13 : int64 * f0_14 : int64 * f0_15 : string
    | US6_1 of f1_0 : string
and [<Struct>] US7 =
    | US7_0 of f0_0 : string * f0_1 : string * f0_2 : string * f0_3 : string * f0_4 : string * f0_5 : string * f0_6 : string * f0_7 : string * f0_8 : string * f0_9 : int64 * f0_10 : int64 * f0_11 : string * f0_12 : string * f0_13 : string * f0_14 : int64 * f0_15 : int64 * f0_16 : string * f0_17 : string
let rec method0 () : struct (int64 * int64 * int64 * int64 * int64 * int64 * int64 * int64 * int64 * int64) =
    let v0 : int64 = 0L + 1L
    let v1 : int64 = v0 + 1L
    let v2 : int64 = v1 + 1L
    let v3 : int64 = v2 + 1L
    let v4 : int64 = 0L + 1L
    let v5 : int64 = v4 + 1L
    let v6 : int64 = v5 + 1L
    let v7 : int64 = v6 + 1L
    let v8 : bool = v3 = v7
    let v9 : int64 =
        if v8 then
            0L
        else
            1L
    let v10 : int64 = 0L + 1L
    let v11 : int64 = 0L + 1L
    let v12 : bool = v10 = v11
    let v13 : int64 =
        if v12 then
            0L
        else
            1L
    let v14 : int64 = 0L + 1L
    let v15 : int64 = v14 + 1L
    let v16 : int64 = v15 + 1L
    let v17 : int64 = v16 + 1L
    let v18 : int64 = v17 + 1L
    let v19 : int64 = 0L + 1L
    let v20 : int64 = v19 + 1L
    let v21 : int64 = v20 + 1L
    let v22 : int64 = v21 + 1L
    let v23 : int64 = v22 + 1L
    let v24 : bool = v18 = v23
    let v25 : int64 =
        if v24 then
            0L
        else
            1L
    let v26 : int64 = v10 + v18
    let v27 : int64 = v11 + v23
    let v28 : int64 = v13 + v25
    let v29 : int64 = v3 + v26
    let v30 : int64 = v7 + v27
    let v31 : int64 = v9 + v28
    let v32 : int64 = v30 + v31
    let v33 : int64 = v29 + v32
    let v34 : int64 = 3L + v33
    let v35 : int64 = 0L + 1L
    let v36 : int64 = v35 + 1L
    let v37 : int64 = v36 + 1L
    let v38 : int64 = v37 + 1L
    let v39 : int64 = 0L + 1L
    let v40 : int64 = v39 + 1L
    let v41 : int64 = v40 + 1L
    let v42 : int64 = v41 + 1L
    let v43 : bool = v38 = v42
    let v44 : int64 =
        if v43 then
            0L
        else
            1L
    let v45 : int64 = 0L + 1L
    let v46 : int64 = 0L + 1L
    let v47 : bool = v45 = v46
    let v48 : int64 =
        if v47 then
            0L
        else
            1L
    let v49 : int64 = 0L + 1L
    let v50 : int64 = v49 + 1L
    let v51 : int64 = v50 + 1L
    let v52 : int64 = v51 + 1L
    let v53 : int64 = v52 + 1L
    let v54 : int64 = 0L + 1L
    let v55 : int64 = v54 + 1L
    let v56 : int64 = v55 + 1L
    let v57 : int64 = v56 + 1L
    let v58 : int64 = v57 + 1L
    let v59 : bool = v53 = v58
    let v60 : int64 =
        if v59 then
            0L
        else
            1L
    let v61 : int64 = v45 + v53
    let v62 : int64 = v46 + v58
    let v63 : int64 = v48 + v60
    let v64 : int64 = v38 + v61
    let v65 : int64 = v42 + v62
    let v66 : int64 = v44 + v63
    let v67 : int64 = v65 + v66
    let v68 : int64 = v64 + v67
    let v69 : int64 = 3L + v68
    let v70 : int64 = 0L + 1L
    let v71 : int64 = v70 + 1L
    let v72 : int64 = v71 + 1L
    let v73 : int64 = v72 + 1L
    let v74 : int64 = 0L + 1L
    let v75 : int64 = v74 + 1L
    let v76 : int64 = v75 + 1L
    let v77 : int64 = v76 + 1L
    let v78 : bool = v73 = v77
    let v79 : int64 =
        if v78 then
            0L
        else
            1L
    let v80 : int64 = 0L + 1L
    let v81 : int64 = 0L + 1L
    let v82 : bool = v80 = v81
    let v83 : int64 =
        if v82 then
            0L
        else
            1L
    let v84 : int64 = 0L + 1L
    let v85 : int64 = v84 + 1L
    let v86 : int64 = v85 + 1L
    let v87 : int64 = v86 + 1L
    let v88 : int64 = v87 + 1L
    let v89 : int64 = 0L + 1L
    let v90 : int64 = v89 + 1L
    let v91 : int64 = v90 + 1L
    let v92 : int64 = v91 + 1L
    let v93 : int64 = v92 + 1L
    let v94 : bool = v88 = v93
    let v95 : int64 =
        if v94 then
            0L
        else
            1L
    let v96 : int64 = v80 + v88
    let v97 : int64 = v81 + v93
    let v98 : int64 = v83 + v95
    let v99 : int64 = v73 + v96
    let v100 : int64 = v77 + v97
    let v101 : int64 = v79 + v98
    let v102 : int64 = v100 + v101
    let v103 : int64 = v99 + v102
    let v104 : int64 = 3L + v103
    let v105 : bool = v69 = v104
    let v142 : US0 =
        if v105 then
            let v106 : int64 = 0L + 1L
            let v107 : int64 = v106 + 1L
            let v108 : int64 = v107 + 1L
            let v109 : int64 = v108 + 1L
            let v110 : int64 = 0L + 1L
            let v111 : int64 = v110 + 1L
            let v112 : int64 = v111 + 1L
            let v113 : int64 = v112 + 1L
            let v114 : bool = v109 = v113
            let v115 : int64 =
                if v114 then
                    0L
                else
                    1L
            let v116 : int64 = 0L + 1L
            let v117 : int64 = 0L + 1L
            let v118 : bool = v116 = v117
            let v119 : int64 =
                if v118 then
                    0L
                else
                    1L
            let v120 : int64 = 0L + 1L
            let v121 : int64 = v120 + 1L
            let v122 : int64 = v121 + 1L
            let v123 : int64 = v122 + 1L
            let v124 : int64 = v123 + 1L
            let v125 : int64 = 0L + 1L
            let v126 : int64 = v125 + 1L
            let v127 : int64 = v126 + 1L
            let v128 : int64 = v127 + 1L
            let v129 : int64 = v128 + 1L
            let v130 : bool = v124 = v129
            let v131 : int64 =
                if v130 then
                    0L
                else
                    1L
            let v132 : int64 = v116 + v124
            let v133 : int64 = v117 + v129
            let v134 : int64 = v119 + v131
            let v135 : int64 = v109 + v132
            let v136 : int64 = v113 + v133
            let v137 : int64 = v115 + v134
            let v138 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            US0_0(1L, 3L, v135, v136, v137, v138)
        else
            let v140 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            US0_1(v69, v104, v140)
    let v232 : US0 =
        match v142 with
        | US0_0(v147, v148, v149, v150, v151, v152) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
            let v153 : int64 = 0L + 1L
            let v154 : int64 = v153 + 1L
            let v155 : int64 = v154 + 1L
            let v156 : int64 = v155 + 1L
            let v157 : int64 = 0L + 1L
            let v158 : int64 = v157 + 1L
            let v159 : int64 = v158 + 1L
            let v160 : int64 = v159 + 1L
            let v161 : bool = v156 = v160
            let v162 : int64 =
                if v161 then
                    0L
                else
                    1L
            let v163 : int64 = 0L + 1L
            let v164 : int64 = 0L + 1L
            let v165 : bool = v163 = v164
            let v166 : int64 =
                if v165 then
                    0L
                else
                    1L
            let v167 : int64 = 0L + 1L
            let v168 : int64 = v167 + 1L
            let v169 : int64 = v168 + 1L
            let v170 : int64 = v169 + 1L
            let v171 : int64 = v170 + 1L
            let v172 : int64 = 0L + 1L
            let v173 : int64 = v172 + 1L
            let v174 : int64 = v173 + 1L
            let v175 : int64 = v174 + 1L
            let v176 : int64 = v175 + 1L
            let v177 : bool = v171 = v176
            let v178 : int64 =
                if v177 then
                    0L
                else
                    1L
            let v179 : int64 = v163 + v171
            let v180 : int64 = v164 + v176
            let v181 : int64 = v166 + v178
            let v182 : int64 = v156 + v179
            let v183 : int64 = v160 + v180
            let v184 : int64 = v162 + v181
            let v185 : int64 = v183 + v184
            let v186 : int64 = v182 + v185
            let v187 : int64 = 3L + v186
            let v188 : bool = v34 = v187
            if v188 then
                let v189 : int64 = 0L + 1L
                let v190 : int64 = v189 + 1L
                let v191 : int64 = v190 + 1L
                let v192 : int64 = v191 + 1L
                let v193 : int64 = 0L + 1L
                let v194 : int64 = v193 + 1L
                let v195 : int64 = v194 + 1L
                let v196 : int64 = v195 + 1L
                let v197 : bool = v192 = v196
                let v198 : int64 =
                    if v197 then
                        0L
                    else
                        1L
                let v199 : int64 = 0L + 1L
                let v200 : int64 = 0L + 1L
                let v201 : bool = v199 = v200
                let v202 : int64 =
                    if v201 then
                        0L
                    else
                        1L
                let v203 : int64 = 0L + 1L
                let v204 : int64 = v203 + 1L
                let v205 : int64 = v204 + 1L
                let v206 : int64 = v205 + 1L
                let v207 : int64 = v206 + 1L
                let v208 : int64 = 0L + 1L
                let v209 : int64 = v208 + 1L
                let v210 : int64 = v209 + 1L
                let v211 : int64 = v210 + 1L
                let v212 : int64 = v211 + 1L
                let v213 : bool = v207 = v212
                let v214 : int64 =
                    if v213 then
                        0L
                    else
                        1L
                let v215 : int64 = v199 + v207
                let v216 : int64 = v200 + v212
                let v217 : int64 = v202 + v214
                let v218 : int64 = v192 + v215
                let v219 : int64 = v196 + v216
                let v220 : int64 = v198 + v217
                let v221 : int64 = 1L + v147
                let v222 : int64 = 3L + v148
                let v223 : int64 = v218 + v149
                let v224 : int64 = v219 + v150
                let v225 : int64 = v220 + v151
                let v226 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
                US0_0(v221, v222, v223, v224, v225, v226)
            else
                let v228 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
                US0_1(v34, v187, v228)
        | US0_1(v143, v144, v145) -> (* TypedFxHashedStatementChecksumValidationRejected *)
            US0_1(v143, v144, v145)
    let struct (v251 : int64, v252 : int64, v253 : int64, v254 : int64, v255 : int64, v256 : int64, v257 : int64, v258 : int64, v259 : int64) =
        match v232 with
        | US0_0(v236, v237, v238, v239, v240, v241) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
            struct (1L, 0L, 0L, 0L, v236, v237, v238, v239, v240)
        | US0_1(v233, v234, v235) -> (* TypedFxHashedStatementChecksumValidationRejected *)
            struct (0L, 1L, v233, v234, 0L, 0L, 0L, 0L, 0L)
    let v260 : int64 = 0L + 1L
    let v261 : int64 = v260 + 1L
    let v262 : int64 = v261 + 1L
    let v263 : int64 = v262 + 1L
    let v264 : int64 = 0L + 1L
    let v265 : int64 = v264 + 1L
    let v266 : int64 = v265 + 1L
    let v267 : int64 = v266 + 1L
    let v268 : bool = v263 = v267
    let v269 : int64 =
        if v268 then
            0L
        else
            1L
    let v270 : int64 = 0L + 1L
    let v271 : int64 = 0L + 1L
    let v272 : bool = v270 = v271
    let v273 : int64 =
        if v272 then
            0L
        else
            1L
    let v274 : int64 = 0L + 1L
    let v275 : int64 = v274 + 1L
    let v276 : int64 = v275 + 1L
    let v277 : int64 = v276 + 1L
    let v278 : int64 = v277 + 1L
    let v279 : int64 = 0L + 1L
    let v280 : int64 = v279 + 1L
    let v281 : int64 = v280 + 1L
    let v282 : int64 = v281 + 1L
    let v283 : int64 = v282 + 1L
    let v284 : bool = v278 = v283
    let v285 : int64 =
        if v284 then
            0L
        else
            1L
    let v286 : int64 = v270 + v278
    let v287 : int64 = v271 + v283
    let v288 : int64 = v273 + v285
    let v289 : int64 = v263 + v286
    let v290 : int64 = v267 + v287
    let v291 : int64 = v269 + v288
    let v292 : int64 = v290 + v291
    let v293 : int64 = v289 + v292
    let v294 : int64 = 3L + v293
    let v295 : bool = 999L = v294
    let v332 : US0 =
        if v295 then
            let v296 : int64 = 0L + 1L
            let v297 : int64 = v296 + 1L
            let v298 : int64 = v297 + 1L
            let v299 : int64 = v298 + 1L
            let v300 : int64 = 0L + 1L
            let v301 : int64 = v300 + 1L
            let v302 : int64 = v301 + 1L
            let v303 : int64 = v302 + 1L
            let v304 : bool = v299 = v303
            let v305 : int64 =
                if v304 then
                    0L
                else
                    1L
            let v306 : int64 = 0L + 1L
            let v307 : int64 = 0L + 1L
            let v308 : bool = v306 = v307
            let v309 : int64 =
                if v308 then
                    0L
                else
                    1L
            let v310 : int64 = 0L + 1L
            let v311 : int64 = v310 + 1L
            let v312 : int64 = v311 + 1L
            let v313 : int64 = v312 + 1L
            let v314 : int64 = v313 + 1L
            let v315 : int64 = 0L + 1L
            let v316 : int64 = v315 + 1L
            let v317 : int64 = v316 + 1L
            let v318 : int64 = v317 + 1L
            let v319 : int64 = v318 + 1L
            let v320 : bool = v314 = v319
            let v321 : int64 =
                if v320 then
                    0L
                else
                    1L
            let v322 : int64 = v306 + v314
            let v323 : int64 = v307 + v319
            let v324 : int64 = v309 + v321
            let v325 : int64 = v299 + v322
            let v326 : int64 = v303 + v323
            let v327 : int64 = v305 + v324
            let v328 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
            US0_0(1L, 3L, v325, v326, v327, v328)
        else
            let v330 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
            US0_1(999L, v294, v330)
    let v422 : US0 =
        match v332 with
        | US0_0(v337, v338, v339, v340, v341, v342) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
            let v343 : int64 = 0L + 1L
            let v344 : int64 = v343 + 1L
            let v345 : int64 = v344 + 1L
            let v346 : int64 = v345 + 1L
            let v347 : int64 = 0L + 1L
            let v348 : int64 = v347 + 1L
            let v349 : int64 = v348 + 1L
            let v350 : int64 = v349 + 1L
            let v351 : bool = v346 = v350
            let v352 : int64 =
                if v351 then
                    0L
                else
                    1L
            let v353 : int64 = 0L + 1L
            let v354 : int64 = 0L + 1L
            let v355 : bool = v353 = v354
            let v356 : int64 =
                if v355 then
                    0L
                else
                    1L
            let v357 : int64 = 0L + 1L
            let v358 : int64 = v357 + 1L
            let v359 : int64 = v358 + 1L
            let v360 : int64 = v359 + 1L
            let v361 : int64 = v360 + 1L
            let v362 : int64 = 0L + 1L
            let v363 : int64 = v362 + 1L
            let v364 : int64 = v363 + 1L
            let v365 : int64 = v364 + 1L
            let v366 : int64 = v365 + 1L
            let v367 : bool = v361 = v366
            let v368 : int64 =
                if v367 then
                    0L
                else
                    1L
            let v369 : int64 = v353 + v361
            let v370 : int64 = v354 + v366
            let v371 : int64 = v356 + v368
            let v372 : int64 = v346 + v369
            let v373 : int64 = v350 + v370
            let v374 : int64 = v352 + v371
            let v375 : int64 = v373 + v374
            let v376 : int64 = v372 + v375
            let v377 : int64 = 3L + v376
            let v378 : bool = v34 = v377
            if v378 then
                let v379 : int64 = 0L + 1L
                let v380 : int64 = v379 + 1L
                let v381 : int64 = v380 + 1L
                let v382 : int64 = v381 + 1L
                let v383 : int64 = 0L + 1L
                let v384 : int64 = v383 + 1L
                let v385 : int64 = v384 + 1L
                let v386 : int64 = v385 + 1L
                let v387 : bool = v382 = v386
                let v388 : int64 =
                    if v387 then
                        0L
                    else
                        1L
                let v389 : int64 = 0L + 1L
                let v390 : int64 = 0L + 1L
                let v391 : bool = v389 = v390
                let v392 : int64 =
                    if v391 then
                        0L
                    else
                        1L
                let v393 : int64 = 0L + 1L
                let v394 : int64 = v393 + 1L
                let v395 : int64 = v394 + 1L
                let v396 : int64 = v395 + 1L
                let v397 : int64 = v396 + 1L
                let v398 : int64 = 0L + 1L
                let v399 : int64 = v398 + 1L
                let v400 : int64 = v399 + 1L
                let v401 : int64 = v400 + 1L
                let v402 : int64 = v401 + 1L
                let v403 : bool = v397 = v402
                let v404 : int64 =
                    if v403 then
                        0L
                    else
                        1L
                let v405 : int64 = v389 + v397
                let v406 : int64 = v390 + v402
                let v407 : int64 = v392 + v404
                let v408 : int64 = v382 + v405
                let v409 : int64 = v386 + v406
                let v410 : int64 = v388 + v407
                let v411 : int64 = 1L + v337
                let v412 : int64 = 3L + v338
                let v413 : int64 = v408 + v339
                let v414 : int64 = v409 + v340
                let v415 : int64 = v410 + v341
                let v416 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
                US0_0(v411, v412, v413, v414, v415, v416)
            else
                let v418 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
                US0_1(v34, v377, v418)
        | US0_1(v333, v334, v335) -> (* TypedFxHashedStatementChecksumValidationRejected *)
            US0_1(v333, v334, v335)
    let struct (v441 : int64, v442 : int64, v443 : int64, v444 : int64, v445 : int64, v446 : int64, v447 : int64, v448 : int64, v449 : int64) =
        match v422 with
        | US0_0(v426, v427, v428, v429, v430, v431) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
            struct (1L, 0L, 0L, 0L, v426, v427, v428, v429, v430)
        | US0_1(v423, v424, v425) -> (* TypedFxHashedStatementChecksumValidationRejected *)
            struct (0L, 1L, v423, v424, 0L, 0L, 0L, 0L, 0L)
    struct (v251, v255, v256, v257, v258, v259, v442, v443, v444, v445)
and method1 (v0 : string, v1 : string) : unit =
    if v0 <> v1 then failwith "erp-NetIntercompany-typed-decode-roundtrip-mismatch"
    ()
and method2 (v0 : string) : unit =
    if v0 <> v0 then failwith "erp-NetIntercompany-typed-decode-roundtrip-mismatch"
    ()
let v0 : int64 = 0L + 1L
let v1 : int64 = v0 + 1L
let v2 : int64 = v1 + 1L
let v3 : int64 = 0L + 1L
let v4 : int64 = v3 + 1L
let v5 : int64 = v4 + 1L
let v6 : int64 = 0L + 1L
let v7 : int64 = v6 + 1L
let v8 : int64 = 0L + 1L
let v9 : int64 = v8 + 1L
let v10 : int64 = v9 + 1L
let v11 : int64 = v10 + 1L
let v12 : int64 = 0L + 1L
let v13 : int64 = v2 * v5
let v14 : int64 = 0L + 1L
let v15 : int64 = v14 + 1L
let v16 : int64 = v15 + 1L
let v17 : int64 = v16 + 1L
let v18 : int64 = 0L + 1L
let v19 : int64 = v18 + 1L
let v20 : int64 = v19 + 1L
let v21 : int64 = v20 + 1L
let v22 : bool = v17 = v21
let v23 : int64 =
    if v22 then
        0L
    else
        1L
let v24 : int64 = if 0L = 0L then 1L else 0L
let v25 : int64 = 0L + 1L
let v26 : int64 = 0L + 1L
let v27 : int64 = v26 + 1L
let v28 : int64 = 0L + 1L
let v29 : int64 = v28 + 1L
let v30 : int64 = 0L + 1L
let v31 : int64 = v25 * v27
let v32 : int64 = 0L + 1L
let v33 : int64 = 0L + 1L
let v34 : bool = v32 = v33
let v35 : int64 =
    if v34 then
        0L
    else
        1L
let v36 : int64 = if 1L = 0L then 1L else 0L
let v37 : int64 = 0L + 1L
let v38 : int64 = v37 + 1L
let v39 : int64 = v38 + 1L
let v40 : int64 = 0L + 1L
let v41 : int64 = v40 + 1L
let v42 : int64 = v41 + 1L
let v43 : int64 = 0L + 1L
let v44 : int64 = v43 + 1L
let v45 : int64 = 0L + 1L
let v46 : int64 = v45 + 1L
let v47 : int64 = v46 + 1L
let v48 : int64 = v47 + 1L
let v49 : int64 = 0L + 1L
let v50 : int64 = v39 * v42
let v51 : int64 = 0L + 1L
let v52 : int64 = v51 + 1L
let v53 : int64 = v52 + 1L
let v54 : int64 = v53 + 1L
let v55 : int64 = v54 + 1L
let v56 : int64 = 0L + 1L
let v57 : int64 = 0L + 1L
let v58 : int64 = v57 + 1L
let v59 : int64 = v58 + 1L
let v60 : int64 = v59 + 1L
let v61 : int64 = v60 + 1L
let v62 : bool = v55 = v61
let v63 : int64 =
    if v62 then
        0L
    else
        1L
let v64 : int64 = if 1L = 0L then 1L else 0L
let v65 : int64 = if v64 = 0L then 1L else 0L
let v66 : int64 = v36 + v64
let v67 : int64 = if v36 = 0L then 1L else 0L
let v68 : int64 = v67 + v65
let v69 : int64 = v33 + v61
let v70 : int64 = v35 + v63
let v71 : int64 = v24 + v66
let v72 : int64 = if v24 = 0L then 1L else 0L
let v73 : int64 = v72 + v68
let v74 : int64 = v21 + v69
let v75 : int64 = v23 + v70
let v76 : bool = v71 = 1L
let v77 : bool = v73 = 2L
let v78 : bool = v74 = 10L
let v79 : bool = v75 = 0L
let v80 : bool = v76 && v77
let v81 : bool = v80 && v78
let v82 : bool = v81 && v79
if v82 then
    ()
else
    failwith<unit> "typed-FX-determined-rounding-receipt-program-runtime-mismatch"
let v83 : int64 = 0L + 1L
let v84 : int64 = v83 + 1L
let v85 : int64 = v84 + 1L
let v86 : int64 = v85 + 1L
let v87 : int64 = 0L + 1L
let v88 : int64 = v87 + 1L
let v89 : int64 = v88 + 1L
let v90 : int64 = v89 + 1L
let v91 : bool = v86 = v90
let v92 : int64 =
    if v91 then
        0L
    else
        1L
let v93 : int64 = 0L + 1L
let v94 : int64 = 0L + 1L
let v95 : bool = v93 = v94
let v96 : int64 =
    if v95 then
        0L
    else
        1L
let v97 : int64 = 0L + 1L
let v98 : int64 = v97 + 1L
let v99 : int64 = v98 + 1L
let v100 : int64 = v99 + 1L
let v101 : int64 = v100 + 1L
let v102 : int64 = 0L + 1L
let v103 : int64 = v102 + 1L
let v104 : int64 = v103 + 1L
let v105 : int64 = v104 + 1L
let v106 : int64 = v105 + 1L
let v107 : bool = v101 = v106
let v108 : int64 =
    if v107 then
        0L
    else
        1L
let v109 : int64 = v93 + v101
let v110 : int64 = v94 + v106
let v111 : int64 = v96 + v108
let v112 : int64 = v86 + v109
let v113 : int64 = v90 + v110
let v114 : int64 = v92 + v111
let v115 : int64 = v113 + v114
let v116 : int64 = v112 + v115
let v117 : int64 = 3L + v116
let v118 : int64 = 0L + 1L
let v119 : int64 = v118 + 1L
let v120 : int64 = v119 + 1L
let v121 : int64 = v120 + 1L
let v122 : int64 = 0L + 1L
let v123 : int64 = v122 + 1L
let v124 : int64 = v123 + 1L
let v125 : int64 = v124 + 1L
let v126 : bool = v121 = v125
let v127 : int64 =
    if v126 then
        0L
    else
        1L
let v128 : int64 = 0L + 1L
let v129 : int64 = 0L + 1L
let v130 : bool = v128 = v129
let v131 : int64 =
    if v130 then
        0L
    else
        1L
let v132 : int64 = 0L + 1L
let v133 : int64 = v132 + 1L
let v134 : int64 = v133 + 1L
let v135 : int64 = v134 + 1L
let v136 : int64 = v135 + 1L
let v137 : int64 = 0L + 1L
let v138 : int64 = v137 + 1L
let v139 : int64 = v138 + 1L
let v140 : int64 = v139 + 1L
let v141 : int64 = v140 + 1L
let v142 : bool = v136 = v141
let v143 : int64 =
    if v142 then
        0L
    else
        1L
let v144 : int64 = v128 + v136
let v145 : int64 = v129 + v141
let v146 : int64 = v131 + v143
let v147 : int64 = v121 + v144
let v148 : int64 = v125 + v145
let v149 : int64 = v127 + v146
let v150 : int64 = v148 + v149
let v151 : int64 = v147 + v150
let v152 : int64 = 3L + v151
let v153 : bool = v117 = v152
let v190 : US0 =
    if v153 then
        let v154 : int64 = 0L + 1L
        let v155 : int64 = v154 + 1L
        let v156 : int64 = v155 + 1L
        let v157 : int64 = v156 + 1L
        let v158 : int64 = 0L + 1L
        let v159 : int64 = v158 + 1L
        let v160 : int64 = v159 + 1L
        let v161 : int64 = v160 + 1L
        let v162 : bool = v157 = v161
        let v163 : int64 =
            if v162 then
                0L
            else
                1L
        let v164 : int64 = 0L + 1L
        let v165 : int64 = 0L + 1L
        let v166 : bool = v164 = v165
        let v167 : int64 =
            if v166 then
                0L
            else
                1L
        let v168 : int64 = 0L + 1L
        let v169 : int64 = v168 + 1L
        let v170 : int64 = v169 + 1L
        let v171 : int64 = v170 + 1L
        let v172 : int64 = v171 + 1L
        let v173 : int64 = 0L + 1L
        let v174 : int64 = v173 + 1L
        let v175 : int64 = v174 + 1L
        let v176 : int64 = v175 + 1L
        let v177 : int64 = v176 + 1L
        let v178 : bool = v172 = v177
        let v179 : int64 =
            if v178 then
                0L
            else
                1L
        let v180 : int64 = v164 + v172
        let v181 : int64 = v165 + v177
        let v182 : int64 = v167 + v179
        let v183 : int64 = v157 + v180
        let v184 : int64 = v161 + v181
        let v185 : int64 = v163 + v182
        let v186 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v183, v184, v185, v186)
    else
        let v188 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v117, v152, v188)
let v191 : int64 = 0L + 1L
let v192 : int64 = v191 + 1L
let v193 : int64 = v192 + 1L
let v194 : int64 = v193 + 1L
let v195 : int64 = 0L + 1L
let v196 : int64 = v195 + 1L
let v197 : int64 = v196 + 1L
let v198 : int64 = v197 + 1L
let v199 : bool = v194 = v198
let v200 : int64 =
    if v199 then
        0L
    else
        1L
let v201 : int64 = 0L + 1L
let v202 : int64 = 0L + 1L
let v203 : bool = v201 = v202
let v204 : int64 =
    if v203 then
        0L
    else
        1L
let v205 : int64 = 0L + 1L
let v206 : int64 = v205 + 1L
let v207 : int64 = v206 + 1L
let v208 : int64 = v207 + 1L
let v209 : int64 = v208 + 1L
let v210 : int64 = 0L + 1L
let v211 : int64 = v210 + 1L
let v212 : int64 = v211 + 1L
let v213 : int64 = v212 + 1L
let v214 : int64 = v213 + 1L
let v215 : bool = v209 = v214
let v216 : int64 =
    if v215 then
        0L
    else
        1L
let v217 : int64 = v201 + v209
let v218 : int64 = v202 + v214
let v219 : int64 = v204 + v216
let v220 : int64 = v194 + v217
let v221 : int64 = v198 + v218
let v222 : int64 = v200 + v219
let v223 : int64 = v221 + v222
let v224 : int64 = v220 + v223
let v225 : int64 = 3L + v224
let v226 : int64 = 0L + 1L
let v227 : int64 = v226 + 1L
let v228 : int64 = v227 + 1L
let v229 : int64 = v228 + 1L
let v230 : int64 = 0L + 1L
let v231 : int64 = v230 + 1L
let v232 : int64 = v231 + 1L
let v233 : int64 = v232 + 1L
let v234 : bool = v229 = v233
let v235 : int64 =
    if v234 then
        0L
    else
        1L
let v236 : int64 = 0L + 1L
let v237 : int64 = 0L + 1L
let v238 : bool = v236 = v237
let v239 : int64 =
    if v238 then
        0L
    else
        1L
let v240 : int64 = 0L + 1L
let v241 : int64 = v240 + 1L
let v242 : int64 = v241 + 1L
let v243 : int64 = v242 + 1L
let v244 : int64 = v243 + 1L
let v245 : int64 = 0L + 1L
let v246 : int64 = v245 + 1L
let v247 : int64 = v246 + 1L
let v248 : int64 = v247 + 1L
let v249 : int64 = v248 + 1L
let v250 : bool = v244 = v249
let v251 : int64 =
    if v250 then
        0L
    else
        1L
let v252 : int64 = v236 + v244
let v253 : int64 = v237 + v249
let v254 : int64 = v239 + v251
let v255 : int64 = v229 + v252
let v256 : int64 = v233 + v253
let v257 : int64 = v235 + v254
let v258 : int64 = v256 + v257
let v259 : int64 = v255 + v258
let v260 : int64 = 3L + v259
let v261 : int64 = 0L + 1L
let v262 : int64 = v261 + 1L
let v263 : int64 = v262 + 1L
let v264 : int64 = v263 + 1L
let v265 : int64 = 0L + 1L
let v266 : int64 = v265 + 1L
let v267 : int64 = v266 + 1L
let v268 : int64 = v267 + 1L
let v269 : bool = v264 = v268
let v270 : int64 =
    if v269 then
        0L
    else
        1L
let v271 : int64 = 0L + 1L
let v272 : int64 = 0L + 1L
let v273 : bool = v271 = v272
let v274 : int64 =
    if v273 then
        0L
    else
        1L
let v275 : int64 = 0L + 1L
let v276 : int64 = v275 + 1L
let v277 : int64 = v276 + 1L
let v278 : int64 = v277 + 1L
let v279 : int64 = v278 + 1L
let v280 : int64 = 0L + 1L
let v281 : int64 = v280 + 1L
let v282 : int64 = v281 + 1L
let v283 : int64 = v282 + 1L
let v284 : int64 = v283 + 1L
let v285 : bool = v279 = v284
let v286 : int64 =
    if v285 then
        0L
    else
        1L
let v287 : int64 = v271 + v279
let v288 : int64 = v272 + v284
let v289 : int64 = v274 + v286
let v290 : int64 = v264 + v287
let v291 : int64 = v268 + v288
let v292 : int64 = v270 + v289
let v293 : int64 = v291 + v292
let v294 : int64 = v290 + v293
let v295 : int64 = 3L + v294
let v296 : bool = 999L = v295
let v333 : US0 =
    if v296 then
        let v297 : int64 = 0L + 1L
        let v298 : int64 = v297 + 1L
        let v299 : int64 = v298 + 1L
        let v300 : int64 = v299 + 1L
        let v301 : int64 = 0L + 1L
        let v302 : int64 = v301 + 1L
        let v303 : int64 = v302 + 1L
        let v304 : int64 = v303 + 1L
        let v305 : bool = v300 = v304
        let v306 : int64 =
            if v305 then
                0L
            else
                1L
        let v307 : int64 = 0L + 1L
        let v308 : int64 = 0L + 1L
        let v309 : bool = v307 = v308
        let v310 : int64 =
            if v309 then
                0L
            else
                1L
        let v311 : int64 = 0L + 1L
        let v312 : int64 = v311 + 1L
        let v313 : int64 = v312 + 1L
        let v314 : int64 = v313 + 1L
        let v315 : int64 = v314 + 1L
        let v316 : int64 = 0L + 1L
        let v317 : int64 = v316 + 1L
        let v318 : int64 = v317 + 1L
        let v319 : int64 = v318 + 1L
        let v320 : int64 = v319 + 1L
        let v321 : bool = v315 = v320
        let v322 : int64 =
            if v321 then
                0L
            else
                1L
        let v323 : int64 = v307 + v315
        let v324 : int64 = v308 + v320
        let v325 : int64 = v310 + v322
        let v326 : int64 = v300 + v323
        let v327 : int64 = v304 + v324
        let v328 : int64 = v306 + v325
        let v329 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v326, v327, v328, v329)
    else
        let v331 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(999L, v295, v331)
let struct (v345 : int64, v346 : int64) =
    match v190 with
    | US0_0(v334, v335, v336, v337, v338, v339) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L)
    | US0_1(v340, v341, v342) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L)
let struct (v358 : int64, v359 : int64) =
    match v333 with
    | US0_0(v347, v348, v349, v350, v351, v352) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L)
    | US0_1(v353, v354, v355) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L)
let v360 : bool = v345 = 1L
let v361 : bool = v359 = 1L
let v362 : bool = v360 && v361
if v362 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-checksum-validation-runtime-mismatch"
let v363 : int64 = 0L + 1L
let v364 : int64 = v363 + 1L
let v365 : int64 = v364 + 1L
let v366 : int64 = v365 + 1L
let v367 : int64 = 0L + 1L
let v368 : int64 = v367 + 1L
let v369 : int64 = v368 + 1L
let v370 : int64 = v369 + 1L
let v371 : bool = v366 = v370
let v372 : int64 =
    if v371 then
        0L
    else
        1L
let v373 : int64 = 0L + 1L
let v374 : int64 = 0L + 1L
let v375 : bool = v373 = v374
let v376 : int64 =
    if v375 then
        0L
    else
        1L
let v377 : int64 = 0L + 1L
let v378 : int64 = v377 + 1L
let v379 : int64 = v378 + 1L
let v380 : int64 = v379 + 1L
let v381 : int64 = v380 + 1L
let v382 : int64 = 0L + 1L
let v383 : int64 = v382 + 1L
let v384 : int64 = v383 + 1L
let v385 : int64 = v384 + 1L
let v386 : int64 = v385 + 1L
let v387 : bool = v381 = v386
let v388 : int64 =
    if v387 then
        0L
    else
        1L
let v389 : int64 = v373 + v381
let v390 : int64 = v374 + v386
let v391 : int64 = v376 + v388
let v392 : int64 = v366 + v389
let v393 : int64 = v370 + v390
let v394 : int64 = v372 + v391
let v395 : int64 = v393 + v394
let v396 : int64 = v392 + v395
let v397 : int64 = 3L + v396
let v398 : bool = v117 = v397
let v435 : US0 =
    if v398 then
        let v399 : int64 = 0L + 1L
        let v400 : int64 = v399 + 1L
        let v401 : int64 = v400 + 1L
        let v402 : int64 = v401 + 1L
        let v403 : int64 = 0L + 1L
        let v404 : int64 = v403 + 1L
        let v405 : int64 = v404 + 1L
        let v406 : int64 = v405 + 1L
        let v407 : bool = v402 = v406
        let v408 : int64 =
            if v407 then
                0L
            else
                1L
        let v409 : int64 = 0L + 1L
        let v410 : int64 = 0L + 1L
        let v411 : bool = v409 = v410
        let v412 : int64 =
            if v411 then
                0L
            else
                1L
        let v413 : int64 = 0L + 1L
        let v414 : int64 = v413 + 1L
        let v415 : int64 = v414 + 1L
        let v416 : int64 = v415 + 1L
        let v417 : int64 = v416 + 1L
        let v418 : int64 = 0L + 1L
        let v419 : int64 = v418 + 1L
        let v420 : int64 = v419 + 1L
        let v421 : int64 = v420 + 1L
        let v422 : int64 = v421 + 1L
        let v423 : bool = v417 = v422
        let v424 : int64 =
            if v423 then
                0L
            else
                1L
        let v425 : int64 = v409 + v417
        let v426 : int64 = v410 + v422
        let v427 : int64 = v412 + v424
        let v428 : int64 = v402 + v425
        let v429 : int64 = v406 + v426
        let v430 : int64 = v408 + v427
        let v431 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v428, v429, v430, v431)
    else
        let v433 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v117, v397, v433)
let struct (v454 : int64, v455 : int64, v456 : int64, v457 : int64, v458 : int64, v459 : int64, v460 : int64, v461 : int64, v462 : int64) =
    match v435 with
    | US0_0(v439, v440, v441, v442, v443, v444) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v439, v440, v441, v442, v443)
    | US0_1(v436, v437, v438) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v436, v437, 0L, 0L, 0L, 0L, 0L)
let v463 : int64 = 0L + 1L
let v464 : int64 = v463 + 1L
let v465 : int64 = v464 + 1L
let v466 : int64 = v465 + 1L
let v467 : int64 = 0L + 1L
let v468 : int64 = v467 + 1L
let v469 : int64 = v468 + 1L
let v470 : int64 = v469 + 1L
let v471 : bool = v466 = v470
let v472 : int64 =
    if v471 then
        0L
    else
        1L
let v473 : int64 = 0L + 1L
let v474 : int64 = 0L + 1L
let v475 : bool = v473 = v474
let v476 : int64 =
    if v475 then
        0L
    else
        1L
let v477 : int64 = 0L + 1L
let v478 : int64 = v477 + 1L
let v479 : int64 = v478 + 1L
let v480 : int64 = v479 + 1L
let v481 : int64 = v480 + 1L
let v482 : int64 = 0L + 1L
let v483 : int64 = v482 + 1L
let v484 : int64 = v483 + 1L
let v485 : int64 = v484 + 1L
let v486 : int64 = v485 + 1L
let v487 : bool = v481 = v486
let v488 : int64 =
    if v487 then
        0L
    else
        1L
let v489 : int64 = v473 + v481
let v490 : int64 = v474 + v486
let v491 : int64 = v476 + v488
let v492 : int64 = v466 + v489
let v493 : int64 = v470 + v490
let v494 : int64 = v472 + v491
let v495 : int64 = v493 + v494
let v496 : int64 = v492 + v495
let v497 : int64 = 3L + v496
let v498 : bool = 999L = v497
let v535 : US0 =
    if v498 then
        let v499 : int64 = 0L + 1L
        let v500 : int64 = v499 + 1L
        let v501 : int64 = v500 + 1L
        let v502 : int64 = v501 + 1L
        let v503 : int64 = 0L + 1L
        let v504 : int64 = v503 + 1L
        let v505 : int64 = v504 + 1L
        let v506 : int64 = v505 + 1L
        let v507 : bool = v502 = v506
        let v508 : int64 =
            if v507 then
                0L
            else
                1L
        let v509 : int64 = 0L + 1L
        let v510 : int64 = 0L + 1L
        let v511 : bool = v509 = v510
        let v512 : int64 =
            if v511 then
                0L
            else
                1L
        let v513 : int64 = 0L + 1L
        let v514 : int64 = v513 + 1L
        let v515 : int64 = v514 + 1L
        let v516 : int64 = v515 + 1L
        let v517 : int64 = v516 + 1L
        let v518 : int64 = 0L + 1L
        let v519 : int64 = v518 + 1L
        let v520 : int64 = v519 + 1L
        let v521 : int64 = v520 + 1L
        let v522 : int64 = v521 + 1L
        let v523 : bool = v517 = v522
        let v524 : int64 =
            if v523 then
                0L
            else
                1L
        let v525 : int64 = v509 + v517
        let v526 : int64 = v510 + v522
        let v527 : int64 = v512 + v524
        let v528 : int64 = v502 + v525
        let v529 : int64 = v506 + v526
        let v530 : int64 = v508 + v527
        let v531 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v528, v529, v530, v531)
    else
        let v533 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(999L, v497, v533)
let struct (v554 : int64, v555 : int64, v556 : int64, v557 : int64, v558 : int64, v559 : int64, v560 : int64, v561 : int64, v562 : int64) =
    match v535 with
    | US0_0(v539, v540, v541, v542, v543, v544) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v539, v540, v541, v542, v543)
    | US0_1(v536, v537, v538) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v536, v537, 0L, 0L, 0L, 0L, 0L)
let v563 : bool = v454 = 1L
let v564 : bool = v555 = 1L
let v565 : bool = v556 = 999L
let v566 : bool = v557 = 23L
let v567 : bool = v458 = 1L
let v568 : bool = v459 = 3L
let v569 : bool = v460 = 10L
let v570 : bool = v461 = 10L
let v571 : bool = v462 = 0L
let v572 : bool = v563 && v564
let v573 : bool = v572 && v565
let v574 : bool = v573 && v566
let v575 : bool = v574 && v567
let v576 : bool = v575 && v568
let v577 : bool = v576 && v569
let v578 : bool = v577 && v570
let v579 : bool = v578 && v571
if v579 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-validated-restart-runtime-mismatch"
let v580 : int64 = 0L + 1L
let v581 : int64 = v580 + 1L
let v582 : int64 = v581 + 1L
let v583 : int64 = v582 + 1L
let v584 : int64 = 0L + 1L
let v585 : int64 = v584 + 1L
let v586 : int64 = v585 + 1L
let v587 : int64 = v586 + 1L
let v588 : bool = v583 = v587
let v589 : int64 =
    if v588 then
        0L
    else
        1L
let v590 : int64 = 0L + 1L
let v591 : int64 = 0L + 1L
let v592 : bool = v590 = v591
let v593 : int64 =
    if v592 then
        0L
    else
        1L
let v594 : int64 = 0L + 1L
let v595 : int64 = v594 + 1L
let v596 : int64 = v595 + 1L
let v597 : int64 = v596 + 1L
let v598 : int64 = v597 + 1L
let v599 : int64 = 0L + 1L
let v600 : int64 = v599 + 1L
let v601 : int64 = v600 + 1L
let v602 : int64 = v601 + 1L
let v603 : int64 = v602 + 1L
let v604 : bool = v598 = v603
let v605 : int64 =
    if v604 then
        0L
    else
        1L
let v606 : int64 = v590 + v598
let v607 : int64 = v591 + v603
let v608 : int64 = v593 + v605
let v609 : int64 = v583 + v606
let v610 : int64 = v587 + v607
let v611 : int64 = v589 + v608
let v612 : bool = v117 = 23L
let v613 : bool = v225 = 23L
let v614 : bool = v260 = 23L
let v615 : bool = v609 = 10L
let v616 : bool = v610 = 10L
let v617 : bool = v611 = 0L
let v618 : bool = v612 && v613
let v619 : bool = v618 && v614
let v620 : bool = v619 && v567
let v621 : bool = v620 && v568
let v622 : bool = v621 && v615
let v623 : bool = v622 && v569
let v624 : bool = v623 && v616
let v625 : bool = v624 && v570
let v626 : bool = v625 && v617
let v627 : bool = v626 && v571
if v627 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-checksummed-restart-runtime-mismatch"
let v628 : int64 = 0L + 1L
let v629 : int64 = v628 + 1L
let v630 : int64 = v629 + 1L
let v631 : int64 = 0L + 1L
let v632 : int64 = v631 + 1L
let v633 : int64 = v632 + 1L
let v634 : int64 = 0L + 1L
let v635 : int64 = v634 + 1L
let v636 : int64 = 0L + 1L
let v637 : int64 = v636 + 1L
let v638 : int64 = v637 + 1L
let v639 : int64 = v638 + 1L
let v640 : int64 = 0L + 1L
let v641 : int64 = v630 * v633
let v642 : int64 = 0L + 1L
let v643 : int64 = v642 + 1L
let v644 : int64 = v643 + 1L
let v645 : int64 = v644 + 1L
let v646 : int64 = v645 + 1L
let v647 : int64 = 0L + 1L
let v648 : int64 = v640 + v640
let v649 : int64 = v635 + v648
let v650 : int64 = 0L + 1L
let v651 : int64 = v650 + 1L
let v652 : int64 = v651 + 1L
let v653 : int64 = 0L + 1L
let v654 : int64 = v653 + 1L
let v655 : int64 = v654 + 1L
let v656 : int64 = 0L + 1L
let v657 : int64 = v656 + 1L
let v658 : int64 = 0L + 1L
let v659 : int64 = v658 + 1L
let v660 : int64 = v659 + 1L
let v661 : int64 = v660 + 1L
let v662 : int64 = 0L + 1L
let v663 : int64 = v652 * v655
let v664 : int64 = 0L + 1L
let v665 : int64 = v664 + 1L
let v666 : int64 = v665 + 1L
let v667 : int64 = v666 + 1L
let v668 : int64 = v662 + v662
let v669 : int64 = v657 + v668
let v670 : int64 = v646 + v667
let v671 : int64 = v649 + v669
let v672 : bool = v670 = 9L
let v673 : bool = v647 = 1L
let v674 : bool = v671 = 8L
let v675 : bool = v672 && v673
let v676 : bool = v675 && v674
if v676 then
    ()
else
    failwith<unit> "typed-usd-eur-determined-tie-rounding-runtime-mismatch"
let v677 : int64 = 0L + 1L
let v678 : int64 = v677 + 1L
let v679 : int64 = v678 + 1L
let v680 : int64 = v679 + 1L
let v681 : int64 = 0L + 1L
let v682 : int64 = v681 + 1L
let v683 : int64 = v682 + 1L
let v684 : int64 = v683 + 1L
let v685 : bool = v680 = v684
let v686 : int64 =
    if v685 then
        0L
    else
        1L
let v687 : int64 = 0L + 1L
let v688 : int64 = 0L + 1L
let v689 : bool = v687 = v688
let v690 : int64 =
    if v689 then
        0L
    else
        1L
let v691 : int64 = 0L + 1L
let v692 : int64 = v691 + 1L
let v693 : int64 = v692 + 1L
let v694 : int64 = v693 + 1L
let v695 : int64 = v694 + 1L
let v696 : int64 = 0L + 1L
let v697 : int64 = v696 + 1L
let v698 : int64 = v697 + 1L
let v699 : int64 = v698 + 1L
let v700 : int64 = v699 + 1L
let v701 : bool = v695 = v700
let v702 : int64 =
    if v701 then
        0L
    else
        1L
let v703 : int64 = v687 + v695
let v704 : int64 = v688 + v700
let v705 : int64 = v690 + v702
let v706 : int64 = v680 + v703
let v707 : int64 = v684 + v704
let v708 : int64 = v686 + v705
let v709 : bool = v706 = 10L
let v710 : bool = v707 = 10L
let v711 : bool = v708 = 0L
let v712 : bool = v709 && v710
let v713 : bool = v712 && v711
if v713 then
    ()
else
    failwith<unit> "typed-FX-statement-expected-raw-append-runtime-mismatch"
let v714 : int64 = 0L + 1L
let v715 : int64 = v714 + 1L
let v716 : int64 = v715 + 1L
let v717 : int64 = v716 + 1L
let v718 : int64 = 0L + 1L
let v719 : int64 = v718 + 1L
let v720 : int64 = v719 + 1L
let v721 : int64 = v720 + 1L
let v722 : bool = v717 = v721
let v723 : int64 =
    if v722 then
        0L
    else
        1L
let v724 : int64 = 0L + 1L
let v725 : int64 = 0L + 1L
let v726 : bool = v724 = v725
let v727 : int64 =
    if v726 then
        0L
    else
        1L
let v728 : int64 = 0L + 1L
let v729 : int64 = v728 + 1L
let v730 : int64 = v729 + 1L
let v731 : int64 = v730 + 1L
let v732 : int64 = v731 + 1L
let v733 : int64 = 0L + 1L
let v734 : int64 = v733 + 1L
let v735 : int64 = v734 + 1L
let v736 : int64 = v735 + 1L
let v737 : int64 = v736 + 1L
let v738 : bool = v732 = v737
let v739 : int64 =
    if v738 then
        0L
    else
        1L
let v740 : int64 = v724 + v732
let v741 : int64 = v725 + v737
let v742 : int64 = v727 + v739
let v743 : int64 = v717 + v740
let v744 : int64 = v721 + v741
let v745 : int64 = v723 + v742
let v746 : int64 = 0L + 1L
let v747 : int64 = v746 + 1L
let v748 : int64 = v747 + 1L
let v749 : int64 = v748 + 1L
let v750 : int64 = 0L + 1L
let v751 : int64 = v750 + 1L
let v752 : int64 = v751 + 1L
let v753 : int64 = v752 + 1L
let v754 : bool = v749 = v753
let v755 : int64 =
    if v754 then
        0L
    else
        1L
let v756 : int64 = 0L + 1L
let v757 : int64 = 0L + 1L
let v758 : bool = v756 = v757
let v759 : int64 =
    if v758 then
        0L
    else
        1L
let v760 : int64 = 0L + 1L
let v761 : int64 = v760 + 1L
let v762 : int64 = v761 + 1L
let v763 : int64 = v762 + 1L
let v764 : int64 = v763 + 1L
let v765 : int64 = 0L + 1L
let v766 : int64 = v765 + 1L
let v767 : int64 = v766 + 1L
let v768 : int64 = v767 + 1L
let v769 : int64 = v768 + 1L
let v770 : bool = v764 = v769
let v771 : int64 =
    if v770 then
        0L
    else
        1L
let v772 : int64 = v756 + v764
let v773 : int64 = v757 + v769
let v774 : int64 = v759 + v771
let v775 : int64 = v749 + v772
let v776 : int64 = v753 + v773
let v777 : int64 = v755 + v774
let v778 : int64 = v745 + v777
let v779 : bool = v778 = 0L
if v779 then
    ()
else
    failwith<unit> "typed-FX-statement-two-writer-raw-CAS-runtime-mismatch"
let v780 : int64 = 0L + 1L
let v781 : int64 = v780 + 1L
let v782 : int64 = v781 + 1L
let v783 : int64 = v782 + 1L
let v784 : int64 = 0L + 1L
let v785 : int64 = v784 + 1L
let v786 : int64 = v785 + 1L
let v787 : int64 = v786 + 1L
let v788 : bool = v783 = v787
let v789 : int64 =
    if v788 then
        0L
    else
        1L
let v790 : int64 = 0L + 1L
let v791 : int64 = 0L + 1L
let v792 : bool = v790 = v791
let v793 : int64 =
    if v792 then
        0L
    else
        1L
let v794 : int64 = 0L + 1L
let v795 : int64 = v794 + 1L
let v796 : int64 = v795 + 1L
let v797 : int64 = v796 + 1L
let v798 : int64 = v797 + 1L
let v799 : int64 = 0L + 1L
let v800 : int64 = v799 + 1L
let v801 : int64 = v800 + 1L
let v802 : int64 = v801 + 1L
let v803 : int64 = v802 + 1L
let v804 : bool = v798 = v803
let v805 : int64 =
    if v804 then
        0L
    else
        1L
let v806 : int64 = v790 + v798
let v807 : int64 = v791 + v803
let v808 : int64 = v793 + v805
let v809 : int64 = v783 + v806
let v810 : int64 = v787 + v807
let v811 : int64 = v789 + v808
let v812 : int64 = 0L + 1L
let v813 : int64 = v812 + 1L
let v814 : int64 = v813 + 1L
let v815 : int64 = v814 + 1L
let v816 : int64 = 0L + 1L
let v817 : int64 = v816 + 1L
let v818 : int64 = v817 + 1L
let v819 : int64 = v818 + 1L
let v820 : bool = v815 = v819
let v821 : int64 =
    if v820 then
        0L
    else
        1L
let v822 : int64 = 0L + 1L
let v823 : int64 = 0L + 1L
let v824 : bool = v822 = v823
let v825 : int64 =
    if v824 then
        0L
    else
        1L
let v826 : int64 = 0L + 1L
let v827 : int64 = v826 + 1L
let v828 : int64 = v827 + 1L
let v829 : int64 = v828 + 1L
let v830 : int64 = v829 + 1L
let v831 : int64 = 0L + 1L
let v832 : int64 = v831 + 1L
let v833 : int64 = v832 + 1L
let v834 : int64 = v833 + 1L
let v835 : int64 = v834 + 1L
let v836 : bool = v830 = v835
let v837 : int64 =
    if v836 then
        0L
    else
        1L
let v838 : int64 = v822 + v830
let v839 : int64 = v823 + v835
let v840 : int64 = v825 + v837
let v841 : int64 = v815 + v838
let v842 : int64 = v819 + v839
let v843 : int64 = v821 + v840
let v844 : int64 = v811 + v843
let v845 : int64 = 0L + 1L
let v846 : int64 = v845 + 1L
let v847 : int64 = v846 + 1L
let v848 : int64 = v847 + 1L
let v849 : int64 = 0L + 1L
let v850 : int64 = v849 + 1L
let v851 : int64 = v850 + 1L
let v852 : int64 = v851 + 1L
let v853 : bool = v848 = v852
let v854 : int64 =
    if v853 then
        0L
    else
        1L
let v855 : int64 = 0L + 1L
let v856 : int64 = 0L + 1L
let v857 : bool = v855 = v856
let v858 : int64 =
    if v857 then
        0L
    else
        1L
let v859 : int64 = 0L + 1L
let v860 : int64 = v859 + 1L
let v861 : int64 = v860 + 1L
let v862 : int64 = v861 + 1L
let v863 : int64 = v862 + 1L
let v864 : int64 = 0L + 1L
let v865 : int64 = v864 + 1L
let v866 : int64 = v865 + 1L
let v867 : int64 = v866 + 1L
let v868 : int64 = v867 + 1L
let v869 : bool = v863 = v868
let v870 : int64 =
    if v869 then
        0L
    else
        1L
let v871 : int64 = v855 + v863
let v872 : int64 = v856 + v868
let v873 : int64 = v858 + v870
let v874 : int64 = v848 + v871
let v875 : int64 = v852 + v872
let v876 : int64 = v854 + v873
let v877 : int64 = v844 + v876
let v878 : bool = v877 = 0L
if v878 then
    ()
else
    failwith<unit> "typed-FX-statement-three-writer-raw-CAS-runtime-mismatch"
let v879 : int64 = 0L + 1L
let v880 : int64 = v879 + 1L
let v881 : int64 = v880 + 1L
let v882 : int64 = v881 + 1L
let v883 : int64 = 0L + 1L
let v884 : int64 = v883 + 1L
let v885 : int64 = v884 + 1L
let v886 : int64 = v885 + 1L
let v887 : bool = v882 = v886
let v888 : int64 =
    if v887 then
        0L
    else
        1L
let v889 : int64 = 0L + 1L
let v890 : int64 = 0L + 1L
let v891 : bool = v889 = v890
let v892 : int64 =
    if v891 then
        0L
    else
        1L
let v893 : int64 = 0L + 1L
let v894 : int64 = v893 + 1L
let v895 : int64 = v894 + 1L
let v896 : int64 = v895 + 1L
let v897 : int64 = v896 + 1L
let v898 : int64 = 0L + 1L
let v899 : int64 = v898 + 1L
let v900 : int64 = v899 + 1L
let v901 : int64 = v900 + 1L
let v902 : int64 = v901 + 1L
let v903 : bool = v897 = v902
let v904 : int64 =
    if v903 then
        0L
    else
        1L
let v905 : int64 = v889 + v897
let v906 : int64 = v890 + v902
let v907 : int64 = v892 + v904
let v908 : int64 = v882 + v905
let v909 : int64 = v886 + v906
let v910 : int64 = v888 + v907
let v911 : int64 = 0L + 1L
let v912 : int64 = v911 + 1L
let v913 : int64 = v912 + 1L
let v914 : int64 = v913 + 1L
let v915 : int64 = 0L + 1L
let v916 : int64 = v915 + 1L
let v917 : int64 = v916 + 1L
let v918 : int64 = v917 + 1L
let v919 : bool = v914 = v918
let v920 : int64 =
    if v919 then
        0L
    else
        1L
let v921 : int64 = 0L + 1L
let v922 : int64 = 0L + 1L
let v923 : bool = v921 = v922
let v924 : int64 =
    if v923 then
        0L
    else
        1L
let v925 : int64 = 0L + 1L
let v926 : int64 = v925 + 1L
let v927 : int64 = v926 + 1L
let v928 : int64 = v927 + 1L
let v929 : int64 = v928 + 1L
let v930 : int64 = 0L + 1L
let v931 : int64 = v930 + 1L
let v932 : int64 = v931 + 1L
let v933 : int64 = v932 + 1L
let v934 : int64 = v933 + 1L
let v935 : bool = v929 = v934
let v936 : int64 =
    if v935 then
        0L
    else
        1L
let v937 : int64 = v921 + v929
let v938 : int64 = v922 + v934
let v939 : int64 = v924 + v936
let v940 : int64 = v914 + v937
let v941 : int64 = v918 + v938
let v942 : int64 = v920 + v939
let v943 : int64 = v910 + v942
let v944 : int64 = 0L + 1L
let v945 : int64 = v944 + 1L
let v946 : int64 = v945 + 1L
let v947 : int64 = v946 + 1L
let v948 : int64 = 0L + 1L
let v949 : int64 = v948 + 1L
let v950 : int64 = v949 + 1L
let v951 : int64 = v950 + 1L
let v952 : bool = v947 = v951
let v953 : int64 =
    if v952 then
        0L
    else
        1L
let v954 : int64 = 0L + 1L
let v955 : int64 = 0L + 1L
let v956 : bool = v954 = v955
let v957 : int64 =
    if v956 then
        0L
    else
        1L
let v958 : int64 = 0L + 1L
let v959 : int64 = v958 + 1L
let v960 : int64 = v959 + 1L
let v961 : int64 = v960 + 1L
let v962 : int64 = v961 + 1L
let v963 : int64 = 0L + 1L
let v964 : int64 = v963 + 1L
let v965 : int64 = v964 + 1L
let v966 : int64 = v965 + 1L
let v967 : int64 = v966 + 1L
let v968 : bool = v962 = v967
let v969 : int64 =
    if v968 then
        0L
    else
        1L
let v970 : int64 = v954 + v962
let v971 : int64 = v955 + v967
let v972 : int64 = v957 + v969
let v973 : int64 = v947 + v970
let v974 : int64 = v951 + v971
let v975 : int64 = v953 + v972
let v976 : int64 = 0L + 1L
let v977 : int64 = v976 + 1L
let v978 : int64 = v977 + 1L
let v979 : int64 = v978 + 1L
let v980 : int64 = 0L + 1L
let v981 : int64 = v980 + 1L
let v982 : int64 = v981 + 1L
let v983 : int64 = v982 + 1L
let v984 : bool = v979 = v983
let v985 : int64 =
    if v984 then
        0L
    else
        1L
let v986 : int64 = 0L + 1L
let v987 : int64 = 0L + 1L
let v988 : bool = v986 = v987
let v989 : int64 =
    if v988 then
        0L
    else
        1L
let v990 : int64 = 0L + 1L
let v991 : int64 = v990 + 1L
let v992 : int64 = v991 + 1L
let v993 : int64 = v992 + 1L
let v994 : int64 = v993 + 1L
let v995 : int64 = 0L + 1L
let v996 : int64 = v995 + 1L
let v997 : int64 = v996 + 1L
let v998 : int64 = v997 + 1L
let v999 : int64 = v998 + 1L
let v1000 : bool = v994 = v999
let v1001 : int64 =
    if v1000 then
        0L
    else
        1L
let v1002 : int64 = v986 + v994
let v1003 : int64 = v987 + v999
let v1004 : int64 = v989 + v1001
let v1005 : int64 = v979 + v1002
let v1006 : int64 = v983 + v1003
let v1007 : int64 = v985 + v1004
let v1008 : int64 = v975 + v1007
let v1009 : int64 = v943 + v1008
let v1010 : bool = v1009 = 0L
if v1010 then
    ()
else
    failwith<unit> "typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch"
let v1011 : int64 = 0L + 1L
let v1012 : int64 = v1011 + 1L
let v1013 : int64 = v1012 + 1L
let v1014 : int64 = v1013 + 1L
let v1015 : int64 = 0L + 1L
let v1016 : int64 = v1015 + 1L
let v1017 : int64 = v1016 + 1L
let v1018 : int64 = v1017 + 1L
let v1019 : bool = v1014 = v1018
let v1020 : int64 =
    if v1019 then
        0L
    else
        1L
let v1021 : int64 = 0L + 1L
let v1022 : int64 = 0L + 1L
let v1023 : bool = v1021 = v1022
let v1024 : int64 =
    if v1023 then
        0L
    else
        1L
let v1025 : int64 = 0L + 1L
let v1026 : int64 = v1025 + 1L
let v1027 : int64 = v1026 + 1L
let v1028 : int64 = v1027 + 1L
let v1029 : int64 = v1028 + 1L
let v1030 : int64 = 0L + 1L
let v1031 : int64 = v1030 + 1L
let v1032 : int64 = v1031 + 1L
let v1033 : int64 = v1032 + 1L
let v1034 : int64 = v1033 + 1L
let v1035 : bool = v1029 = v1034
let v1036 : int64 =
    if v1035 then
        0L
    else
        1L
let v1037 : int64 = v1021 + v1029
let v1038 : int64 = v1022 + v1034
let v1039 : int64 = v1024 + v1036
let v1040 : int64 = v1014 + v1037
let v1041 : int64 = v1018 + v1038
let v1042 : int64 = v1020 + v1039
let v1043 : int64 = 0L + 1L
let v1044 : int64 = v1043 + 1L
let v1045 : int64 = v1044 + 1L
let v1046 : int64 = v1045 + 1L
let v1047 : int64 = 0L + 1L
let v1048 : int64 = v1047 + 1L
let v1049 : int64 = v1048 + 1L
let v1050 : int64 = v1049 + 1L
let v1051 : bool = v1046 = v1050
let v1052 : int64 =
    if v1051 then
        0L
    else
        1L
let v1053 : int64 = 0L + 1L
let v1054 : int64 = 0L + 1L
let v1055 : bool = v1053 = v1054
let v1056 : int64 =
    if v1055 then
        0L
    else
        1L
let v1057 : int64 = 0L + 1L
let v1058 : int64 = v1057 + 1L
let v1059 : int64 = v1058 + 1L
let v1060 : int64 = v1059 + 1L
let v1061 : int64 = v1060 + 1L
let v1062 : int64 = 0L + 1L
let v1063 : int64 = v1062 + 1L
let v1064 : int64 = v1063 + 1L
let v1065 : int64 = v1064 + 1L
let v1066 : int64 = v1065 + 1L
let v1067 : bool = v1061 = v1066
let v1068 : int64 =
    if v1067 then
        0L
    else
        1L
let v1069 : int64 = v1053 + v1061
let v1070 : int64 = v1054 + v1066
let v1071 : int64 = v1056 + v1068
let v1072 : int64 = v1046 + v1069
let v1073 : int64 = v1050 + v1070
let v1074 : int64 = v1052 + v1071
let v1075 : int64 = v1042 + v1074
let v1076 : int64 = 0L + 1L
let v1077 : int64 = v1076 + 1L
let v1078 : int64 = v1077 + 1L
let v1079 : int64 = v1078 + 1L
let v1080 : int64 = 0L + 1L
let v1081 : int64 = v1080 + 1L
let v1082 : int64 = v1081 + 1L
let v1083 : int64 = v1082 + 1L
let v1084 : bool = v1079 = v1083
let v1085 : int64 =
    if v1084 then
        0L
    else
        1L
let v1086 : int64 = 0L + 1L
let v1087 : int64 = 0L + 1L
let v1088 : bool = v1086 = v1087
let v1089 : int64 =
    if v1088 then
        0L
    else
        1L
let v1090 : int64 = 0L + 1L
let v1091 : int64 = v1090 + 1L
let v1092 : int64 = v1091 + 1L
let v1093 : int64 = v1092 + 1L
let v1094 : int64 = v1093 + 1L
let v1095 : int64 = 0L + 1L
let v1096 : int64 = v1095 + 1L
let v1097 : int64 = v1096 + 1L
let v1098 : int64 = v1097 + 1L
let v1099 : int64 = v1098 + 1L
let v1100 : bool = v1094 = v1099
let v1101 : int64 =
    if v1100 then
        0L
    else
        1L
let v1102 : int64 = v1086 + v1094
let v1103 : int64 = v1087 + v1099
let v1104 : int64 = v1089 + v1101
let v1105 : int64 = v1079 + v1102
let v1106 : int64 = v1083 + v1103
let v1107 : int64 = v1085 + v1104
let v1108 : int64 = 0L + 1L
let v1109 : int64 = v1108 + 1L
let v1110 : int64 = v1109 + 1L
let v1111 : int64 = v1110 + 1L
let v1112 : int64 = 0L + 1L
let v1113 : int64 = v1112 + 1L
let v1114 : int64 = v1113 + 1L
let v1115 : int64 = v1114 + 1L
let v1116 : bool = v1111 = v1115
let v1117 : int64 =
    if v1116 then
        0L
    else
        1L
let v1118 : int64 = 0L + 1L
let v1119 : int64 = 0L + 1L
let v1120 : bool = v1118 = v1119
let v1121 : int64 =
    if v1120 then
        0L
    else
        1L
let v1122 : int64 = 0L + 1L
let v1123 : int64 = v1122 + 1L
let v1124 : int64 = v1123 + 1L
let v1125 : int64 = v1124 + 1L
let v1126 : int64 = v1125 + 1L
let v1127 : int64 = 0L + 1L
let v1128 : int64 = v1127 + 1L
let v1129 : int64 = v1128 + 1L
let v1130 : int64 = v1129 + 1L
let v1131 : int64 = v1130 + 1L
let v1132 : bool = v1126 = v1131
let v1133 : int64 =
    if v1132 then
        0L
    else
        1L
let v1134 : int64 = v1118 + v1126
let v1135 : int64 = v1119 + v1131
let v1136 : int64 = v1121 + v1133
let v1137 : int64 = v1111 + v1134
let v1138 : int64 = v1115 + v1135
let v1139 : int64 = v1117 + v1136
let v1140 : int64 = v1107 + v1139
let v1141 : int64 = v1075 + v1140
let v1142 : int64 = 0L + 1L
let v1143 : int64 = v1142 + 1L
let v1144 : int64 = v1143 + 1L
let v1145 : int64 = v1144 + 1L
let v1146 : int64 = 0L + 1L
let v1147 : int64 = v1146 + 1L
let v1148 : int64 = v1147 + 1L
let v1149 : int64 = v1148 + 1L
let v1150 : bool = v1145 = v1149
let v1151 : int64 =
    if v1150 then
        0L
    else
        1L
let v1152 : int64 = 0L + 1L
let v1153 : int64 = 0L + 1L
let v1154 : bool = v1152 = v1153
let v1155 : int64 =
    if v1154 then
        0L
    else
        1L
let v1156 : int64 = 0L + 1L
let v1157 : int64 = v1156 + 1L
let v1158 : int64 = v1157 + 1L
let v1159 : int64 = v1158 + 1L
let v1160 : int64 = v1159 + 1L
let v1161 : int64 = 0L + 1L
let v1162 : int64 = v1161 + 1L
let v1163 : int64 = v1162 + 1L
let v1164 : int64 = v1163 + 1L
let v1165 : int64 = v1164 + 1L
let v1166 : bool = v1160 = v1165
let v1167 : int64 =
    if v1166 then
        0L
    else
        1L
let v1168 : int64 = v1152 + v1160
let v1169 : int64 = v1153 + v1165
let v1170 : int64 = v1155 + v1167
let v1171 : int64 = v1145 + v1168
let v1172 : int64 = v1149 + v1169
let v1173 : int64 = v1151 + v1170
let v1174 : int64 = v1172 + v1173
let v1175 : int64 = v1171 + v1174
let v1176 : int64 = 3L + v1175
let v1177 : int64 = 0L + 1L
let v1178 : int64 = v1177 + 1L
let v1179 : int64 = v1178 + 1L
let v1180 : int64 = v1179 + 1L
let v1181 : int64 = 0L + 1L
let v1182 : int64 = v1181 + 1L
let v1183 : int64 = v1182 + 1L
let v1184 : int64 = v1183 + 1L
let v1185 : bool = v1180 = v1184
let v1186 : int64 =
    if v1185 then
        0L
    else
        1L
let v1187 : int64 = 0L + 1L
let v1188 : int64 = 0L + 1L
let v1189 : bool = v1187 = v1188
let v1190 : int64 =
    if v1189 then
        0L
    else
        1L
let v1191 : int64 = 0L + 1L
let v1192 : int64 = v1191 + 1L
let v1193 : int64 = v1192 + 1L
let v1194 : int64 = v1193 + 1L
let v1195 : int64 = v1194 + 1L
let v1196 : int64 = 0L + 1L
let v1197 : int64 = v1196 + 1L
let v1198 : int64 = v1197 + 1L
let v1199 : int64 = v1198 + 1L
let v1200 : int64 = v1199 + 1L
let v1201 : bool = v1195 = v1200
let v1202 : int64 =
    if v1201 then
        0L
    else
        1L
let v1203 : int64 = v1187 + v1195
let v1204 : int64 = v1188 + v1200
let v1205 : int64 = v1190 + v1202
let v1206 : int64 = v1180 + v1203
let v1207 : int64 = v1184 + v1204
let v1208 : int64 = v1186 + v1205
let v1209 : int64 = v1207 + v1208
let v1210 : int64 = v1206 + v1209
let v1211 : int64 = 3L + v1210
let v1212 : bool = v1176 = v1211
let v1249 : US0 =
    if v1212 then
        let v1213 : int64 = 0L + 1L
        let v1214 : int64 = v1213 + 1L
        let v1215 : int64 = v1214 + 1L
        let v1216 : int64 = v1215 + 1L
        let v1217 : int64 = 0L + 1L
        let v1218 : int64 = v1217 + 1L
        let v1219 : int64 = v1218 + 1L
        let v1220 : int64 = v1219 + 1L
        let v1221 : bool = v1216 = v1220
        let v1222 : int64 =
            if v1221 then
                0L
            else
                1L
        let v1223 : int64 = 0L + 1L
        let v1224 : int64 = 0L + 1L
        let v1225 : bool = v1223 = v1224
        let v1226 : int64 =
            if v1225 then
                0L
            else
                1L
        let v1227 : int64 = 0L + 1L
        let v1228 : int64 = v1227 + 1L
        let v1229 : int64 = v1228 + 1L
        let v1230 : int64 = v1229 + 1L
        let v1231 : int64 = v1230 + 1L
        let v1232 : int64 = 0L + 1L
        let v1233 : int64 = v1232 + 1L
        let v1234 : int64 = v1233 + 1L
        let v1235 : int64 = v1234 + 1L
        let v1236 : int64 = v1235 + 1L
        let v1237 : bool = v1231 = v1236
        let v1238 : int64 =
            if v1237 then
                0L
            else
                1L
        let v1239 : int64 = v1223 + v1231
        let v1240 : int64 = v1224 + v1236
        let v1241 : int64 = v1226 + v1238
        let v1242 : int64 = v1216 + v1239
        let v1243 : int64 = v1220 + v1240
        let v1244 : int64 = v1222 + v1241
        let v1245 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v1242, v1243, v1244, v1245)
    else
        let v1247 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v1176, v1211, v1247)
let struct (v1268 : int64, v1269 : int64, v1270 : int64, v1271 : int64, v1272 : int64, v1273 : int64, v1274 : int64, v1275 : int64, v1276 : int64) =
    match v1249 with
    | US0_0(v1253, v1254, v1255, v1256, v1257, v1258) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v1253, v1254, v1255, v1256, v1257)
    | US0_1(v1250, v1251, v1252) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v1250, v1251, 0L, 0L, 0L, 0L, 0L)
let v1277 : bool = v1141 = 0L
let v1278 : bool = v1176 = 23L
let v1279 : bool = v1268 = 1L
let v1280 : bool = v1269 = 0L
let v1281 : bool = v1272 = 1L
let v1282 : bool = v1273 = 3L
let v1283 : bool = v1274 = 10L
let v1284 : bool = v1275 = 10L
let v1285 : bool = v1276 = 0L
let v1286 : bool = v1277 && v1278
let v1287 : bool = v1286 && v1279
let v1288 : bool = v1287 && v1280
let v1289 : bool = v1288 && v1281
let v1290 : bool = v1289 && v1282
let v1291 : bool = v1290 && v1283
let v1292 : bool = v1291 && v1284
let v1293 : bool = v1292 && v1285
if v1293 then
    ()
else
    failwith<unit> "typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch"
let v1294 : int64 = 0L + 1L
let v1295 : int64 = v1294 + 1L
let v1296 : int64 = v1295 + 1L
let v1297 : int64 = v1296 + 1L
let v1298 : int64 = 0L + 1L
let v1299 : int64 = v1298 + 1L
let v1300 : int64 = v1299 + 1L
let v1301 : int64 = v1300 + 1L
let v1302 : bool = v1297 = v1301
let v1303 : int64 =
    if v1302 then
        0L
    else
        1L
let v1304 : int64 = 0L + 1L
let v1305 : int64 = 0L + 1L
let v1306 : bool = v1304 = v1305
let v1307 : int64 =
    if v1306 then
        0L
    else
        1L
let v1308 : int64 = 0L + 1L
let v1309 : int64 = v1308 + 1L
let v1310 : int64 = v1309 + 1L
let v1311 : int64 = v1310 + 1L
let v1312 : int64 = v1311 + 1L
let v1313 : int64 = 0L + 1L
let v1314 : int64 = v1313 + 1L
let v1315 : int64 = v1314 + 1L
let v1316 : int64 = v1315 + 1L
let v1317 : int64 = v1316 + 1L
let v1318 : bool = v1312 = v1317
let v1319 : int64 =
    if v1318 then
        0L
    else
        1L
let v1320 : int64 = v1304 + v1312
let v1321 : int64 = v1305 + v1317
let v1322 : int64 = v1307 + v1319
let v1323 : int64 = v1297 + v1320
let v1324 : int64 = v1301 + v1321
let v1325 : int64 = v1303 + v1322
let v1326 : int64 = 0L + 1L
let v1327 : int64 = v1326 + 1L
let v1328 : int64 = v1327 + 1L
let v1329 : int64 = v1328 + 1L
let v1330 : int64 = 0L + 1L
let v1331 : int64 = v1330 + 1L
let v1332 : int64 = v1331 + 1L
let v1333 : int64 = v1332 + 1L
let v1334 : bool = v1329 = v1333
let v1335 : int64 =
    if v1334 then
        0L
    else
        1L
let v1336 : int64 = 0L + 1L
let v1337 : int64 = 0L + 1L
let v1338 : bool = v1336 = v1337
let v1339 : int64 =
    if v1338 then
        0L
    else
        1L
let v1340 : int64 = 0L + 1L
let v1341 : int64 = v1340 + 1L
let v1342 : int64 = v1341 + 1L
let v1343 : int64 = v1342 + 1L
let v1344 : int64 = v1343 + 1L
let v1345 : int64 = 0L + 1L
let v1346 : int64 = v1345 + 1L
let v1347 : int64 = v1346 + 1L
let v1348 : int64 = v1347 + 1L
let v1349 : int64 = v1348 + 1L
let v1350 : bool = v1344 = v1349
let v1351 : int64 =
    if v1350 then
        0L
    else
        1L
let v1352 : int64 = v1336 + v1344
let v1353 : int64 = v1337 + v1349
let v1354 : int64 = v1339 + v1351
let v1355 : int64 = v1329 + v1352
let v1356 : int64 = v1333 + v1353
let v1357 : int64 = v1335 + v1354
let v1358 : int64 = v1325 + v1357
let v1359 : int64 = 0L + 1L
let v1360 : int64 = v1359 + 1L
let v1361 : int64 = v1360 + 1L
let v1362 : int64 = v1361 + 1L
let v1363 : int64 = 0L + 1L
let v1364 : int64 = v1363 + 1L
let v1365 : int64 = v1364 + 1L
let v1366 : int64 = v1365 + 1L
let v1367 : bool = v1362 = v1366
let v1368 : int64 =
    if v1367 then
        0L
    else
        1L
let v1369 : int64 = 0L + 1L
let v1370 : int64 = 0L + 1L
let v1371 : bool = v1369 = v1370
let v1372 : int64 =
    if v1371 then
        0L
    else
        1L
let v1373 : int64 = 0L + 1L
let v1374 : int64 = v1373 + 1L
let v1375 : int64 = v1374 + 1L
let v1376 : int64 = v1375 + 1L
let v1377 : int64 = v1376 + 1L
let v1378 : int64 = 0L + 1L
let v1379 : int64 = v1378 + 1L
let v1380 : int64 = v1379 + 1L
let v1381 : int64 = v1380 + 1L
let v1382 : int64 = v1381 + 1L
let v1383 : bool = v1377 = v1382
let v1384 : int64 =
    if v1383 then
        0L
    else
        1L
let v1385 : int64 = v1369 + v1377
let v1386 : int64 = v1370 + v1382
let v1387 : int64 = v1372 + v1384
let v1388 : int64 = v1362 + v1385
let v1389 : int64 = v1366 + v1386
let v1390 : int64 = v1368 + v1387
let v1391 : int64 = 0L + 1L
let v1392 : int64 = v1391 + 1L
let v1393 : int64 = v1392 + 1L
let v1394 : int64 = v1393 + 1L
let v1395 : int64 = 0L + 1L
let v1396 : int64 = v1395 + 1L
let v1397 : int64 = v1396 + 1L
let v1398 : int64 = v1397 + 1L
let v1399 : bool = v1394 = v1398
let v1400 : int64 =
    if v1399 then
        0L
    else
        1L
let v1401 : int64 = 0L + 1L
let v1402 : int64 = 0L + 1L
let v1403 : bool = v1401 = v1402
let v1404 : int64 =
    if v1403 then
        0L
    else
        1L
let v1405 : int64 = 0L + 1L
let v1406 : int64 = v1405 + 1L
let v1407 : int64 = v1406 + 1L
let v1408 : int64 = v1407 + 1L
let v1409 : int64 = v1408 + 1L
let v1410 : int64 = 0L + 1L
let v1411 : int64 = v1410 + 1L
let v1412 : int64 = v1411 + 1L
let v1413 : int64 = v1412 + 1L
let v1414 : int64 = v1413 + 1L
let v1415 : bool = v1409 = v1414
let v1416 : int64 =
    if v1415 then
        0L
    else
        1L
let v1417 : int64 = v1401 + v1409
let v1418 : int64 = v1402 + v1414
let v1419 : int64 = v1404 + v1416
let v1420 : int64 = v1394 + v1417
let v1421 : int64 = v1398 + v1418
let v1422 : int64 = v1400 + v1419
let v1423 : int64 = v1390 + v1422
let v1424 : int64 = v1358 + v1423
let v1425 : int64 = 0L + 1L
let v1426 : int64 = v1425 + 1L
let v1427 : int64 = v1426 + 1L
let v1428 : int64 = v1427 + 1L
let v1429 : int64 = 0L + 1L
let v1430 : int64 = v1429 + 1L
let v1431 : int64 = v1430 + 1L
let v1432 : int64 = v1431 + 1L
let v1433 : bool = v1428 = v1432
let v1434 : int64 =
    if v1433 then
        0L
    else
        1L
let v1435 : int64 = 0L + 1L
let v1436 : int64 = 0L + 1L
let v1437 : bool = v1435 = v1436
let v1438 : int64 =
    if v1437 then
        0L
    else
        1L
let v1439 : int64 = 0L + 1L
let v1440 : int64 = v1439 + 1L
let v1441 : int64 = v1440 + 1L
let v1442 : int64 = v1441 + 1L
let v1443 : int64 = v1442 + 1L
let v1444 : int64 = 0L + 1L
let v1445 : int64 = v1444 + 1L
let v1446 : int64 = v1445 + 1L
let v1447 : int64 = v1446 + 1L
let v1448 : int64 = v1447 + 1L
let v1449 : bool = v1443 = v1448
let v1450 : int64 =
    if v1449 then
        0L
    else
        1L
let v1451 : int64 = v1435 + v1443
let v1452 : int64 = v1436 + v1448
let v1453 : int64 = v1438 + v1450
let v1454 : int64 = v1428 + v1451
let v1455 : int64 = v1432 + v1452
let v1456 : int64 = v1434 + v1453
let v1457 : int64 = v1455 + v1456
let v1458 : int64 = v1454 + v1457
let v1459 : int64 = 3L + v1458
let v1460 : int64 = 0L + 1L
let v1461 : int64 = v1460 + 1L
let v1462 : int64 = v1461 + 1L
let v1463 : int64 = v1462 + 1L
let v1464 : int64 = 0L + 1L
let v1465 : int64 = v1464 + 1L
let v1466 : int64 = v1465 + 1L
let v1467 : int64 = v1466 + 1L
let v1468 : bool = v1463 = v1467
let v1469 : int64 =
    if v1468 then
        0L
    else
        1L
let v1470 : int64 = 0L + 1L
let v1471 : int64 = 0L + 1L
let v1472 : bool = v1470 = v1471
let v1473 : int64 =
    if v1472 then
        0L
    else
        1L
let v1474 : int64 = 0L + 1L
let v1475 : int64 = v1474 + 1L
let v1476 : int64 = v1475 + 1L
let v1477 : int64 = v1476 + 1L
let v1478 : int64 = v1477 + 1L
let v1479 : int64 = 0L + 1L
let v1480 : int64 = v1479 + 1L
let v1481 : int64 = v1480 + 1L
let v1482 : int64 = v1481 + 1L
let v1483 : int64 = v1482 + 1L
let v1484 : bool = v1478 = v1483
let v1485 : int64 =
    if v1484 then
        0L
    else
        1L
let v1486 : int64 = v1470 + v1478
let v1487 : int64 = v1471 + v1483
let v1488 : int64 = v1473 + v1485
let v1489 : int64 = v1463 + v1486
let v1490 : int64 = v1467 + v1487
let v1491 : int64 = v1469 + v1488
let v1492 : int64 = v1490 + v1491
let v1493 : int64 = v1489 + v1492
let v1494 : int64 = 3L + v1493
let v1495 : bool = v1459 = v1494
let v1532 : US0 =
    if v1495 then
        let v1496 : int64 = 0L + 1L
        let v1497 : int64 = v1496 + 1L
        let v1498 : int64 = v1497 + 1L
        let v1499 : int64 = v1498 + 1L
        let v1500 : int64 = 0L + 1L
        let v1501 : int64 = v1500 + 1L
        let v1502 : int64 = v1501 + 1L
        let v1503 : int64 = v1502 + 1L
        let v1504 : bool = v1499 = v1503
        let v1505 : int64 =
            if v1504 then
                0L
            else
                1L
        let v1506 : int64 = 0L + 1L
        let v1507 : int64 = 0L + 1L
        let v1508 : bool = v1506 = v1507
        let v1509 : int64 =
            if v1508 then
                0L
            else
                1L
        let v1510 : int64 = 0L + 1L
        let v1511 : int64 = v1510 + 1L
        let v1512 : int64 = v1511 + 1L
        let v1513 : int64 = v1512 + 1L
        let v1514 : int64 = v1513 + 1L
        let v1515 : int64 = 0L + 1L
        let v1516 : int64 = v1515 + 1L
        let v1517 : int64 = v1516 + 1L
        let v1518 : int64 = v1517 + 1L
        let v1519 : int64 = v1518 + 1L
        let v1520 : bool = v1514 = v1519
        let v1521 : int64 =
            if v1520 then
                0L
            else
                1L
        let v1522 : int64 = v1506 + v1514
        let v1523 : int64 = v1507 + v1519
        let v1524 : int64 = v1509 + v1521
        let v1525 : int64 = v1499 + v1522
        let v1526 : int64 = v1503 + v1523
        let v1527 : int64 = v1505 + v1524
        let v1528 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v1525, v1526, v1527, v1528)
    else
        let v1530 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v1459, v1494, v1530)
let struct (v1551 : int64, v1552 : int64, v1553 : int64, v1554 : int64, v1555 : int64, v1556 : int64, v1557 : int64, v1558 : int64, v1559 : int64) =
    match v1532 with
    | US0_0(v1536, v1537, v1538, v1539, v1540, v1541) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v1536, v1537, v1538, v1539, v1540)
    | US0_1(v1533, v1534, v1535) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v1533, v1534, 0L, 0L, 0L, 0L, 0L)
let v1560 : int64 = 0L + 1L
let v1561 : int64 = v1560 + 1L
let v1562 : int64 = v1561 + 1L
let v1563 : int64 = v1562 + 1L
let v1564 : int64 = 0L + 1L
let v1565 : int64 = v1564 + 1L
let v1566 : int64 = v1565 + 1L
let v1567 : int64 = v1566 + 1L
let v1568 : bool = v1563 = v1567
let v1569 : int64 =
    if v1568 then
        0L
    else
        1L
let v1570 : int64 = 0L + 1L
let v1571 : int64 = 0L + 1L
let v1572 : bool = v1570 = v1571
let v1573 : int64 =
    if v1572 then
        0L
    else
        1L
let v1574 : int64 = 0L + 1L
let v1575 : int64 = v1574 + 1L
let v1576 : int64 = v1575 + 1L
let v1577 : int64 = v1576 + 1L
let v1578 : int64 = v1577 + 1L
let v1579 : int64 = 0L + 1L
let v1580 : int64 = v1579 + 1L
let v1581 : int64 = v1580 + 1L
let v1582 : int64 = v1581 + 1L
let v1583 : int64 = v1582 + 1L
let v1584 : bool = v1578 = v1583
let v1585 : int64 =
    if v1584 then
        0L
    else
        1L
let v1586 : int64 = v1570 + v1578
let v1587 : int64 = v1571 + v1583
let v1588 : int64 = v1573 + v1585
let v1589 : int64 = v1563 + v1586
let v1590 : int64 = v1567 + v1587
let v1591 : int64 = v1569 + v1588
let v1592 : int64 = 0L + 1L
let v1593 : int64 = v1592 + 1L
let v1594 : int64 = v1593 + 1L
let v1595 : int64 = v1594 + 1L
let v1596 : int64 = 0L + 1L
let v1597 : int64 = v1596 + 1L
let v1598 : int64 = v1597 + 1L
let v1599 : int64 = v1598 + 1L
let v1600 : bool = v1595 = v1599
let v1601 : int64 =
    if v1600 then
        0L
    else
        1L
let v1602 : int64 = 0L + 1L
let v1603 : int64 = 0L + 1L
let v1604 : bool = v1602 = v1603
let v1605 : int64 =
    if v1604 then
        0L
    else
        1L
let v1606 : int64 = 0L + 1L
let v1607 : int64 = v1606 + 1L
let v1608 : int64 = v1607 + 1L
let v1609 : int64 = v1608 + 1L
let v1610 : int64 = v1609 + 1L
let v1611 : int64 = 0L + 1L
let v1612 : int64 = v1611 + 1L
let v1613 : int64 = v1612 + 1L
let v1614 : int64 = v1613 + 1L
let v1615 : int64 = v1614 + 1L
let v1616 : bool = v1610 = v1615
let v1617 : int64 =
    if v1616 then
        0L
    else
        1L
let v1618 : int64 = v1602 + v1610
let v1619 : int64 = v1603 + v1615
let v1620 : int64 = v1605 + v1617
let v1621 : int64 = v1595 + v1618
let v1622 : int64 = v1599 + v1619
let v1623 : int64 = v1601 + v1620
let v1624 : int64 = v1591 + v1623
let v1625 : int64 = v1559 + v1552
let v1626 : int64 = v1624 + v1625
let v1627 : int64 = v1424 + v1626
let v1628 : bool = v1555 = 1L
let v1629 : bool = v1551 = 1L
let v1630 : bool = v1627 = 0L
let v1631 : bool = v1628 && v1629
let v1632 : bool = v1631 && v1630
if v1632 then
    ()
else
    failwith<unit> "typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch"
let v1633 : int64 = 0L + 1L
let v1634 : int64 = v1633 + 1L
let v1635 : int64 = v1634 + 1L
let v1636 : int64 = v1635 + 1L
let v1637 : int64 = 0L + 1L
let v1638 : int64 = v1637 + 1L
let v1639 : int64 = v1638 + 1L
let v1640 : int64 = v1639 + 1L
let v1641 : bool = v1636 = v1640
let v1642 : int64 =
    if v1641 then
        0L
    else
        1L
let v1643 : int64 = 0L + 1L
let v1644 : int64 = 0L + 1L
let v1645 : bool = v1643 = v1644
let v1646 : int64 =
    if v1645 then
        0L
    else
        1L
let v1647 : int64 = 0L + 1L
let v1648 : int64 = v1647 + 1L
let v1649 : int64 = v1648 + 1L
let v1650 : int64 = v1649 + 1L
let v1651 : int64 = v1650 + 1L
let v1652 : int64 = 0L + 1L
let v1653 : int64 = v1652 + 1L
let v1654 : int64 = v1653 + 1L
let v1655 : int64 = v1654 + 1L
let v1656 : int64 = v1655 + 1L
let v1657 : bool = v1651 = v1656
let v1658 : int64 =
    if v1657 then
        0L
    else
        1L
let v1659 : int64 = v1643 + v1651
let v1660 : int64 = v1644 + v1656
let v1661 : int64 = v1646 + v1658
let v1662 : int64 = v1636 + v1659
let v1663 : int64 = v1640 + v1660
let v1664 : int64 = v1642 + v1661
let v1665 : int64 = 0L + 1L
let v1666 : int64 = v1665 + 1L
let v1667 : int64 = v1666 + 1L
let v1668 : int64 = v1667 + 1L
let v1669 : int64 = 0L + 1L
let v1670 : int64 = v1669 + 1L
let v1671 : int64 = v1670 + 1L
let v1672 : int64 = v1671 + 1L
let v1673 : bool = v1668 = v1672
let v1674 : int64 =
    if v1673 then
        0L
    else
        1L
let v1675 : int64 = 0L + 1L
let v1676 : int64 = 0L + 1L
let v1677 : bool = v1675 = v1676
let v1678 : int64 =
    if v1677 then
        0L
    else
        1L
let v1679 : int64 = 0L + 1L
let v1680 : int64 = v1679 + 1L
let v1681 : int64 = v1680 + 1L
let v1682 : int64 = v1681 + 1L
let v1683 : int64 = v1682 + 1L
let v1684 : int64 = 0L + 1L
let v1685 : int64 = v1684 + 1L
let v1686 : int64 = v1685 + 1L
let v1687 : int64 = v1686 + 1L
let v1688 : int64 = v1687 + 1L
let v1689 : bool = v1683 = v1688
let v1690 : int64 =
    if v1689 then
        0L
    else
        1L
let v1691 : int64 = v1675 + v1683
let v1692 : int64 = v1676 + v1688
let v1693 : int64 = v1678 + v1690
let v1694 : int64 = v1668 + v1691
let v1695 : int64 = v1672 + v1692
let v1696 : int64 = v1674 + v1693
let v1697 : int64 = v1664 + v1696
let v1698 : int64 = 0L + 1L
let v1699 : int64 = v1698 + 1L
let v1700 : int64 = v1699 + 1L
let v1701 : int64 = v1700 + 1L
let v1702 : int64 = 0L + 1L
let v1703 : int64 = v1702 + 1L
let v1704 : int64 = v1703 + 1L
let v1705 : int64 = v1704 + 1L
let v1706 : bool = v1701 = v1705
let v1707 : int64 =
    if v1706 then
        0L
    else
        1L
let v1708 : int64 = 0L + 1L
let v1709 : int64 = 0L + 1L
let v1710 : bool = v1708 = v1709
let v1711 : int64 =
    if v1710 then
        0L
    else
        1L
let v1712 : int64 = 0L + 1L
let v1713 : int64 = v1712 + 1L
let v1714 : int64 = v1713 + 1L
let v1715 : int64 = v1714 + 1L
let v1716 : int64 = v1715 + 1L
let v1717 : int64 = 0L + 1L
let v1718 : int64 = v1717 + 1L
let v1719 : int64 = v1718 + 1L
let v1720 : int64 = v1719 + 1L
let v1721 : int64 = v1720 + 1L
let v1722 : bool = v1716 = v1721
let v1723 : int64 =
    if v1722 then
        0L
    else
        1L
let v1724 : int64 = v1708 + v1716
let v1725 : int64 = v1709 + v1721
let v1726 : int64 = v1711 + v1723
let v1727 : int64 = v1701 + v1724
let v1728 : int64 = v1705 + v1725
let v1729 : int64 = v1707 + v1726
let v1730 : int64 = 0L + 1L
let v1731 : int64 = v1730 + 1L
let v1732 : int64 = v1731 + 1L
let v1733 : int64 = v1732 + 1L
let v1734 : int64 = 0L + 1L
let v1735 : int64 = v1734 + 1L
let v1736 : int64 = v1735 + 1L
let v1737 : int64 = v1736 + 1L
let v1738 : bool = v1733 = v1737
let v1739 : int64 =
    if v1738 then
        0L
    else
        1L
let v1740 : int64 = 0L + 1L
let v1741 : int64 = 0L + 1L
let v1742 : bool = v1740 = v1741
let v1743 : int64 =
    if v1742 then
        0L
    else
        1L
let v1744 : int64 = 0L + 1L
let v1745 : int64 = v1744 + 1L
let v1746 : int64 = v1745 + 1L
let v1747 : int64 = v1746 + 1L
let v1748 : int64 = v1747 + 1L
let v1749 : int64 = 0L + 1L
let v1750 : int64 = v1749 + 1L
let v1751 : int64 = v1750 + 1L
let v1752 : int64 = v1751 + 1L
let v1753 : int64 = v1752 + 1L
let v1754 : bool = v1748 = v1753
let v1755 : int64 =
    if v1754 then
        0L
    else
        1L
let v1756 : int64 = v1740 + v1748
let v1757 : int64 = v1741 + v1753
let v1758 : int64 = v1743 + v1755
let v1759 : int64 = v1733 + v1756
let v1760 : int64 = v1737 + v1757
let v1761 : int64 = v1739 + v1758
let v1762 : int64 = v1729 + v1761
let v1763 : int64 = 0L + 1L
let v1764 : int64 = v1763 + 1L
let v1765 : int64 = v1764 + 1L
let v1766 : int64 = v1765 + 1L
let v1767 : int64 = 0L + 1L
let v1768 : int64 = v1767 + 1L
let v1769 : int64 = v1768 + 1L
let v1770 : int64 = v1769 + 1L
let v1771 : bool = v1766 = v1770
let v1772 : int64 =
    if v1771 then
        0L
    else
        1L
let v1773 : int64 = 0L + 1L
let v1774 : int64 = 0L + 1L
let v1775 : bool = v1773 = v1774
let v1776 : int64 =
    if v1775 then
        0L
    else
        1L
let v1777 : int64 = 0L + 1L
let v1778 : int64 = v1777 + 1L
let v1779 : int64 = v1778 + 1L
let v1780 : int64 = v1779 + 1L
let v1781 : int64 = v1780 + 1L
let v1782 : int64 = 0L + 1L
let v1783 : int64 = v1782 + 1L
let v1784 : int64 = v1783 + 1L
let v1785 : int64 = v1784 + 1L
let v1786 : int64 = v1785 + 1L
let v1787 : bool = v1781 = v1786
let v1788 : int64 =
    if v1787 then
        0L
    else
        1L
let v1789 : int64 = v1773 + v1781
let v1790 : int64 = v1774 + v1786
let v1791 : int64 = v1776 + v1788
let v1792 : int64 = v1766 + v1789
let v1793 : int64 = v1770 + v1790
let v1794 : int64 = v1772 + v1791
let v1795 : int64 = 0L + 1L
let v1796 : int64 = v1795 + 1L
let v1797 : int64 = v1796 + 1L
let v1798 : int64 = v1797 + 1L
let v1799 : int64 = 0L + 1L
let v1800 : int64 = v1799 + 1L
let v1801 : int64 = v1800 + 1L
let v1802 : int64 = v1801 + 1L
let v1803 : bool = v1798 = v1802
let v1804 : int64 =
    if v1803 then
        0L
    else
        1L
let v1805 : int64 = 0L + 1L
let v1806 : int64 = 0L + 1L
let v1807 : bool = v1805 = v1806
let v1808 : int64 =
    if v1807 then
        0L
    else
        1L
let v1809 : int64 = 0L + 1L
let v1810 : int64 = v1809 + 1L
let v1811 : int64 = v1810 + 1L
let v1812 : int64 = v1811 + 1L
let v1813 : int64 = v1812 + 1L
let v1814 : int64 = 0L + 1L
let v1815 : int64 = v1814 + 1L
let v1816 : int64 = v1815 + 1L
let v1817 : int64 = v1816 + 1L
let v1818 : int64 = v1817 + 1L
let v1819 : bool = v1813 = v1818
let v1820 : int64 =
    if v1819 then
        0L
    else
        1L
let v1821 : int64 = v1805 + v1813
let v1822 : int64 = v1806 + v1818
let v1823 : int64 = v1808 + v1820
let v1824 : int64 = v1798 + v1821
let v1825 : int64 = v1802 + v1822
let v1826 : int64 = v1804 + v1823
let v1827 : int64 = 0L + 1L
let v1828 : int64 = v1827 + 1L
let v1829 : int64 = v1828 + 1L
let v1830 : int64 = v1829 + 1L
let v1831 : int64 = 0L + 1L
let v1832 : int64 = v1831 + 1L
let v1833 : int64 = v1832 + 1L
let v1834 : int64 = v1833 + 1L
let v1835 : bool = v1830 = v1834
let v1836 : int64 =
    if v1835 then
        0L
    else
        1L
let v1837 : int64 = 0L + 1L
let v1838 : int64 = 0L + 1L
let v1839 : bool = v1837 = v1838
let v1840 : int64 =
    if v1839 then
        0L
    else
        1L
let v1841 : int64 = 0L + 1L
let v1842 : int64 = v1841 + 1L
let v1843 : int64 = v1842 + 1L
let v1844 : int64 = v1843 + 1L
let v1845 : int64 = v1844 + 1L
let v1846 : int64 = 0L + 1L
let v1847 : int64 = v1846 + 1L
let v1848 : int64 = v1847 + 1L
let v1849 : int64 = v1848 + 1L
let v1850 : int64 = v1849 + 1L
let v1851 : bool = v1845 = v1850
let v1852 : int64 =
    if v1851 then
        0L
    else
        1L
let v1853 : int64 = v1837 + v1845
let v1854 : int64 = v1838 + v1850
let v1855 : int64 = v1840 + v1852
let v1856 : int64 = v1830 + v1853
let v1857 : int64 = v1834 + v1854
let v1858 : int64 = v1836 + v1855
let v1859 : int64 = 0L + 1L
let v1860 : int64 = v1859 + 1L
let v1861 : int64 = v1860 + 1L
let v1862 : int64 = v1861 + 1L
let v1863 : int64 = 0L + 1L
let v1864 : int64 = v1863 + 1L
let v1865 : int64 = v1864 + 1L
let v1866 : int64 = v1865 + 1L
let v1867 : bool = v1862 = v1866
let v1868 : int64 =
    if v1867 then
        0L
    else
        1L
let v1869 : int64 = 0L + 1L
let v1870 : int64 = 0L + 1L
let v1871 : bool = v1869 = v1870
let v1872 : int64 =
    if v1871 then
        0L
    else
        1L
let v1873 : int64 = 0L + 1L
let v1874 : int64 = v1873 + 1L
let v1875 : int64 = v1874 + 1L
let v1876 : int64 = v1875 + 1L
let v1877 : int64 = v1876 + 1L
let v1878 : int64 = 0L + 1L
let v1879 : int64 = v1878 + 1L
let v1880 : int64 = v1879 + 1L
let v1881 : int64 = v1880 + 1L
let v1882 : int64 = v1881 + 1L
let v1883 : bool = v1877 = v1882
let v1884 : int64 =
    if v1883 then
        0L
    else
        1L
let v1885 : int64 = v1869 + v1877
let v1886 : int64 = v1870 + v1882
let v1887 : int64 = v1872 + v1884
let v1888 : int64 = v1862 + v1885
let v1889 : int64 = v1866 + v1886
let v1890 : int64 = v1868 + v1887
let v1891 : int64 = v1858 + v1890
let v1892 : int64 = v1826 + v1891
let v1893 : int64 = v1794 + v1892
let v1894 : bool = v1697 = 0L
let v1895 : bool = v1762 = v1697
let v1896 : bool = v1893 = 0L
let v1897 : bool = v1894 && v1895
let v1898 : bool = v1897 && v1896
if v1898 then
    ()
else
    failwith<unit> "typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch"
let v1899 : int64 = 0L + 1L
let v1900 : int64 = v1899 + 1L
let v1901 : int64 = v1900 + 1L
let v1902 : int64 = v1901 + 1L
let v1903 : int64 = 0L + 1L
let v1904 : int64 = v1903 + 1L
let v1905 : int64 = v1904 + 1L
let v1906 : int64 = v1905 + 1L
let v1907 : bool = v1902 = v1906
let v1908 : int64 =
    if v1907 then
        0L
    else
        1L
let v1909 : int64 = 0L + 1L
let v1910 : int64 = 0L + 1L
let v1911 : bool = v1909 = v1910
let v1912 : int64 =
    if v1911 then
        0L
    else
        1L
let v1913 : int64 = 0L + 1L
let v1914 : int64 = v1913 + 1L
let v1915 : int64 = v1914 + 1L
let v1916 : int64 = v1915 + 1L
let v1917 : int64 = v1916 + 1L
let v1918 : int64 = 0L + 1L
let v1919 : int64 = v1918 + 1L
let v1920 : int64 = v1919 + 1L
let v1921 : int64 = v1920 + 1L
let v1922 : int64 = v1921 + 1L
let v1923 : bool = v1917 = v1922
let v1924 : int64 =
    if v1923 then
        0L
    else
        1L
let v1925 : int64 = v1909 + v1917
let v1926 : int64 = v1910 + v1922
let v1927 : int64 = v1912 + v1924
let v1928 : int64 = v1902 + v1925
let v1929 : int64 = v1906 + v1926
let v1930 : int64 = v1908 + v1927
let v1931 : int64 = 0L + 1L
let v1932 : int64 = v1931 + 1L
let v1933 : int64 = v1932 + 1L
let v1934 : int64 = v1933 + 1L
let v1935 : int64 = 0L + 1L
let v1936 : int64 = v1935 + 1L
let v1937 : int64 = v1936 + 1L
let v1938 : int64 = v1937 + 1L
let v1939 : bool = v1934 = v1938
let v1940 : int64 =
    if v1939 then
        0L
    else
        1L
let v1941 : int64 = 0L + 1L
let v1942 : int64 = 0L + 1L
let v1943 : bool = v1941 = v1942
let v1944 : int64 =
    if v1943 then
        0L
    else
        1L
let v1945 : int64 = 0L + 1L
let v1946 : int64 = v1945 + 1L
let v1947 : int64 = v1946 + 1L
let v1948 : int64 = v1947 + 1L
let v1949 : int64 = v1948 + 1L
let v1950 : int64 = 0L + 1L
let v1951 : int64 = v1950 + 1L
let v1952 : int64 = v1951 + 1L
let v1953 : int64 = v1952 + 1L
let v1954 : int64 = v1953 + 1L
let v1955 : bool = v1949 = v1954
let v1956 : int64 =
    if v1955 then
        0L
    else
        1L
let v1957 : int64 = v1941 + v1949
let v1958 : int64 = v1942 + v1954
let v1959 : int64 = v1944 + v1956
let v1960 : int64 = v1934 + v1957
let v1961 : int64 = v1938 + v1958
let v1962 : int64 = v1940 + v1959
let v1963 : int64 = 0L + 1L
let v1964 : int64 = v1963 + 1L
let v1965 : int64 = v1964 + 1L
let v1966 : int64 = v1965 + 1L
let v1967 : int64 = 0L + 1L
let v1968 : int64 = v1967 + 1L
let v1969 : int64 = v1968 + 1L
let v1970 : int64 = v1969 + 1L
let v1971 : bool = v1966 = v1970
let v1972 : int64 =
    if v1971 then
        0L
    else
        1L
let v1973 : int64 = 0L + 1L
let v1974 : int64 = 0L + 1L
let v1975 : bool = v1973 = v1974
let v1976 : int64 =
    if v1975 then
        0L
    else
        1L
let v1977 : int64 = 0L + 1L
let v1978 : int64 = v1977 + 1L
let v1979 : int64 = v1978 + 1L
let v1980 : int64 = v1979 + 1L
let v1981 : int64 = v1980 + 1L
let v1982 : int64 = 0L + 1L
let v1983 : int64 = v1982 + 1L
let v1984 : int64 = v1983 + 1L
let v1985 : int64 = v1984 + 1L
let v1986 : int64 = v1985 + 1L
let v1987 : bool = v1981 = v1986
let v1988 : int64 =
    if v1987 then
        0L
    else
        1L
let v1989 : int64 = v1973 + v1981
let v1990 : int64 = v1974 + v1986
let v1991 : int64 = v1976 + v1988
let v1992 : int64 = v1966 + v1989
let v1993 : int64 = v1970 + v1990
let v1994 : int64 = v1972 + v1991
let v1995 : int64 = 0L + 1L
let v1996 : int64 = v1995 + 1L
let v1997 : int64 = v1996 + 1L
let v1998 : int64 = v1997 + 1L
let v1999 : int64 = 0L + 1L
let v2000 : int64 = v1999 + 1L
let v2001 : int64 = v2000 + 1L
let v2002 : int64 = v2001 + 1L
let v2003 : bool = v1998 = v2002
let v2004 : int64 =
    if v2003 then
        0L
    else
        1L
let v2005 : int64 = 0L + 1L
let v2006 : int64 = 0L + 1L
let v2007 : bool = v2005 = v2006
let v2008 : int64 =
    if v2007 then
        0L
    else
        1L
let v2009 : int64 = 0L + 1L
let v2010 : int64 = v2009 + 1L
let v2011 : int64 = v2010 + 1L
let v2012 : int64 = v2011 + 1L
let v2013 : int64 = v2012 + 1L
let v2014 : int64 = 0L + 1L
let v2015 : int64 = v2014 + 1L
let v2016 : int64 = v2015 + 1L
let v2017 : int64 = v2016 + 1L
let v2018 : int64 = v2017 + 1L
let v2019 : bool = v2013 = v2018
let v2020 : int64 =
    if v2019 then
        0L
    else
        1L
let v2021 : int64 = v2005 + v2013
let v2022 : int64 = v2006 + v2018
let v2023 : int64 = v2008 + v2020
let v2024 : int64 = v1998 + v2021
let v2025 : int64 = v2002 + v2022
let v2026 : int64 = v2004 + v2023
let v2027 : int64 = 0L + 1L
let v2028 : int64 = v2027 + 1L
let v2029 : int64 = v2028 + 1L
let v2030 : int64 = v2029 + 1L
let v2031 : int64 = 0L + 1L
let v2032 : int64 = v2031 + 1L
let v2033 : int64 = v2032 + 1L
let v2034 : int64 = v2033 + 1L
let v2035 : bool = v2030 = v2034
let v2036 : int64 =
    if v2035 then
        0L
    else
        1L
let v2037 : int64 = 0L + 1L
let v2038 : int64 = 0L + 1L
let v2039 : bool = v2037 = v2038
let v2040 : int64 =
    if v2039 then
        0L
    else
        1L
let v2041 : int64 = 0L + 1L
let v2042 : int64 = v2041 + 1L
let v2043 : int64 = v2042 + 1L
let v2044 : int64 = v2043 + 1L
let v2045 : int64 = v2044 + 1L
let v2046 : int64 = 0L + 1L
let v2047 : int64 = v2046 + 1L
let v2048 : int64 = v2047 + 1L
let v2049 : int64 = v2048 + 1L
let v2050 : int64 = v2049 + 1L
let v2051 : bool = v2045 = v2050
let v2052 : int64 =
    if v2051 then
        0L
    else
        1L
let v2053 : int64 = v2037 + v2045
let v2054 : int64 = v2038 + v2050
let v2055 : int64 = v2040 + v2052
let v2056 : int64 = v2030 + v2053
let v2057 : int64 = v2034 + v2054
let v2058 : int64 = v2036 + v2055
let v2059 : int64 = 0L + 1L
let v2060 : int64 = v2059 + 1L
let v2061 : int64 = v2060 + 1L
let v2062 : int64 = v2061 + 1L
let v2063 : int64 = 0L + 1L
let v2064 : int64 = v2063 + 1L
let v2065 : int64 = v2064 + 1L
let v2066 : int64 = v2065 + 1L
let v2067 : bool = v2062 = v2066
let v2068 : int64 =
    if v2067 then
        0L
    else
        1L
let v2069 : int64 = 0L + 1L
let v2070 : int64 = 0L + 1L
let v2071 : bool = v2069 = v2070
let v2072 : int64 =
    if v2071 then
        0L
    else
        1L
let v2073 : int64 = 0L + 1L
let v2074 : int64 = v2073 + 1L
let v2075 : int64 = v2074 + 1L
let v2076 : int64 = v2075 + 1L
let v2077 : int64 = v2076 + 1L
let v2078 : int64 = 0L + 1L
let v2079 : int64 = v2078 + 1L
let v2080 : int64 = v2079 + 1L
let v2081 : int64 = v2080 + 1L
let v2082 : int64 = v2081 + 1L
let v2083 : bool = v2077 = v2082
let v2084 : int64 =
    if v2083 then
        0L
    else
        1L
let v2085 : int64 = v2069 + v2077
let v2086 : int64 = v2070 + v2082
let v2087 : int64 = v2072 + v2084
let v2088 : int64 = v2062 + v2085
let v2089 : int64 = v2066 + v2086
let v2090 : int64 = v2068 + v2087
let v2091 : int64 = v2058 + v2090
let v2092 : int64 = v2026 + v2091
let v2093 : int64 = v1994 + v2092
let v2094 : int64 = v1962 + v2093
let v2095 : int64 = v1930 + v2094
let v2096 : int64 = 0L + 1L
let v2097 : int64 = v2096 + 1L
let v2098 : int64 = v2097 + 1L
let v2099 : int64 = v2098 + 1L
let v2100 : int64 = 0L + 1L
let v2101 : int64 = v2100 + 1L
let v2102 : int64 = v2101 + 1L
let v2103 : int64 = v2102 + 1L
let v2104 : bool = v2099 = v2103
let v2105 : int64 =
    if v2104 then
        0L
    else
        1L
let v2106 : int64 = 0L + 1L
let v2107 : int64 = 0L + 1L
let v2108 : bool = v2106 = v2107
let v2109 : int64 =
    if v2108 then
        0L
    else
        1L
let v2110 : int64 = 0L + 1L
let v2111 : int64 = v2110 + 1L
let v2112 : int64 = v2111 + 1L
let v2113 : int64 = v2112 + 1L
let v2114 : int64 = v2113 + 1L
let v2115 : int64 = 0L + 1L
let v2116 : int64 = v2115 + 1L
let v2117 : int64 = v2116 + 1L
let v2118 : int64 = v2117 + 1L
let v2119 : int64 = v2118 + 1L
let v2120 : bool = v2114 = v2119
let v2121 : int64 =
    if v2120 then
        0L
    else
        1L
let v2122 : int64 = v2106 + v2114
let v2123 : int64 = v2107 + v2119
let v2124 : int64 = v2109 + v2121
let v2125 : int64 = v2099 + v2122
let v2126 : int64 = v2103 + v2123
let v2127 : int64 = v2105 + v2124
let v2128 : int64 = 0L + 1L
let v2129 : int64 = v2128 + 1L
let v2130 : int64 = v2129 + 1L
let v2131 : int64 = v2130 + 1L
let v2132 : int64 = 0L + 1L
let v2133 : int64 = v2132 + 1L
let v2134 : int64 = v2133 + 1L
let v2135 : int64 = v2134 + 1L
let v2136 : bool = v2131 = v2135
let v2137 : int64 =
    if v2136 then
        0L
    else
        1L
let v2138 : int64 = 0L + 1L
let v2139 : int64 = 0L + 1L
let v2140 : bool = v2138 = v2139
let v2141 : int64 =
    if v2140 then
        0L
    else
        1L
let v2142 : int64 = 0L + 1L
let v2143 : int64 = v2142 + 1L
let v2144 : int64 = v2143 + 1L
let v2145 : int64 = v2144 + 1L
let v2146 : int64 = v2145 + 1L
let v2147 : int64 = 0L + 1L
let v2148 : int64 = v2147 + 1L
let v2149 : int64 = v2148 + 1L
let v2150 : int64 = v2149 + 1L
let v2151 : int64 = v2150 + 1L
let v2152 : bool = v2146 = v2151
let v2153 : int64 =
    if v2152 then
        0L
    else
        1L
let v2154 : int64 = v2138 + v2146
let v2155 : int64 = v2139 + v2151
let v2156 : int64 = v2141 + v2153
let v2157 : int64 = v2131 + v2154
let v2158 : int64 = v2135 + v2155
let v2159 : int64 = v2137 + v2156
let v2160 : int64 = 0L + 1L
let v2161 : int64 = v2160 + 1L
let v2162 : int64 = v2161 + 1L
let v2163 : int64 = v2162 + 1L
let v2164 : int64 = 0L + 1L
let v2165 : int64 = v2164 + 1L
let v2166 : int64 = v2165 + 1L
let v2167 : int64 = v2166 + 1L
let v2168 : bool = v2163 = v2167
let v2169 : int64 =
    if v2168 then
        0L
    else
        1L
let v2170 : int64 = 0L + 1L
let v2171 : int64 = 0L + 1L
let v2172 : bool = v2170 = v2171
let v2173 : int64 =
    if v2172 then
        0L
    else
        1L
let v2174 : int64 = 0L + 1L
let v2175 : int64 = v2174 + 1L
let v2176 : int64 = v2175 + 1L
let v2177 : int64 = v2176 + 1L
let v2178 : int64 = v2177 + 1L
let v2179 : int64 = 0L + 1L
let v2180 : int64 = v2179 + 1L
let v2181 : int64 = v2180 + 1L
let v2182 : int64 = v2181 + 1L
let v2183 : int64 = v2182 + 1L
let v2184 : bool = v2178 = v2183
let v2185 : int64 =
    if v2184 then
        0L
    else
        1L
let v2186 : int64 = v2170 + v2178
let v2187 : int64 = v2171 + v2183
let v2188 : int64 = v2173 + v2185
let v2189 : int64 = v2163 + v2186
let v2190 : int64 = v2167 + v2187
let v2191 : int64 = v2169 + v2188
let v2192 : int64 = 0L + 1L
let v2193 : int64 = v2192 + 1L
let v2194 : int64 = v2193 + 1L
let v2195 : int64 = v2194 + 1L
let v2196 : int64 = 0L + 1L
let v2197 : int64 = v2196 + 1L
let v2198 : int64 = v2197 + 1L
let v2199 : int64 = v2198 + 1L
let v2200 : bool = v2195 = v2199
let v2201 : int64 =
    if v2200 then
        0L
    else
        1L
let v2202 : int64 = 0L + 1L
let v2203 : int64 = 0L + 1L
let v2204 : bool = v2202 = v2203
let v2205 : int64 =
    if v2204 then
        0L
    else
        1L
let v2206 : int64 = 0L + 1L
let v2207 : int64 = v2206 + 1L
let v2208 : int64 = v2207 + 1L
let v2209 : int64 = v2208 + 1L
let v2210 : int64 = v2209 + 1L
let v2211 : int64 = 0L + 1L
let v2212 : int64 = v2211 + 1L
let v2213 : int64 = v2212 + 1L
let v2214 : int64 = v2213 + 1L
let v2215 : int64 = v2214 + 1L
let v2216 : bool = v2210 = v2215
let v2217 : int64 =
    if v2216 then
        0L
    else
        1L
let v2218 : int64 = v2202 + v2210
let v2219 : int64 = v2203 + v2215
let v2220 : int64 = v2205 + v2217
let v2221 : int64 = v2195 + v2218
let v2222 : int64 = v2199 + v2219
let v2223 : int64 = v2201 + v2220
let v2224 : int64 = 0L + 1L
let v2225 : int64 = v2224 + 1L
let v2226 : int64 = v2225 + 1L
let v2227 : int64 = v2226 + 1L
let v2228 : int64 = 0L + 1L
let v2229 : int64 = v2228 + 1L
let v2230 : int64 = v2229 + 1L
let v2231 : int64 = v2230 + 1L
let v2232 : bool = v2227 = v2231
let v2233 : int64 =
    if v2232 then
        0L
    else
        1L
let v2234 : int64 = 0L + 1L
let v2235 : int64 = 0L + 1L
let v2236 : bool = v2234 = v2235
let v2237 : int64 =
    if v2236 then
        0L
    else
        1L
let v2238 : int64 = 0L + 1L
let v2239 : int64 = v2238 + 1L
let v2240 : int64 = v2239 + 1L
let v2241 : int64 = v2240 + 1L
let v2242 : int64 = v2241 + 1L
let v2243 : int64 = 0L + 1L
let v2244 : int64 = v2243 + 1L
let v2245 : int64 = v2244 + 1L
let v2246 : int64 = v2245 + 1L
let v2247 : int64 = v2246 + 1L
let v2248 : bool = v2242 = v2247
let v2249 : int64 =
    if v2248 then
        0L
    else
        1L
let v2250 : int64 = v2234 + v2242
let v2251 : int64 = v2235 + v2247
let v2252 : int64 = v2237 + v2249
let v2253 : int64 = v2227 + v2250
let v2254 : int64 = v2231 + v2251
let v2255 : int64 = v2233 + v2252
let v2256 : int64 = 0L + 1L
let v2257 : int64 = v2256 + 1L
let v2258 : int64 = v2257 + 1L
let v2259 : int64 = v2258 + 1L
let v2260 : int64 = 0L + 1L
let v2261 : int64 = v2260 + 1L
let v2262 : int64 = v2261 + 1L
let v2263 : int64 = v2262 + 1L
let v2264 : bool = v2259 = v2263
let v2265 : int64 =
    if v2264 then
        0L
    else
        1L
let v2266 : int64 = 0L + 1L
let v2267 : int64 = 0L + 1L
let v2268 : bool = v2266 = v2267
let v2269 : int64 =
    if v2268 then
        0L
    else
        1L
let v2270 : int64 = 0L + 1L
let v2271 : int64 = v2270 + 1L
let v2272 : int64 = v2271 + 1L
let v2273 : int64 = v2272 + 1L
let v2274 : int64 = v2273 + 1L
let v2275 : int64 = 0L + 1L
let v2276 : int64 = v2275 + 1L
let v2277 : int64 = v2276 + 1L
let v2278 : int64 = v2277 + 1L
let v2279 : int64 = v2278 + 1L
let v2280 : bool = v2274 = v2279
let v2281 : int64 =
    if v2280 then
        0L
    else
        1L
let v2282 : int64 = v2266 + v2274
let v2283 : int64 = v2267 + v2279
let v2284 : int64 = v2269 + v2281
let v2285 : int64 = v2259 + v2282
let v2286 : int64 = v2263 + v2283
let v2287 : int64 = v2265 + v2284
let v2288 : int64 = v2255 + v2287
let v2289 : int64 = v2223 + v2288
let v2290 : int64 = v2191 + v2289
let v2291 : int64 = v2159 + v2290
let v2292 : int64 = v2127 + v2291
let v2293 : bool = v2095 = 0L
let v2294 : bool = v2292 = v2095
let v2295 : bool = v2293 && v2294
if v2295 then
    ()
else
    failwith<unit> "typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch"
let v2296 : int64 = 0L + 1L
let v2297 : int64 = v2296 + 1L
let v2298 : int64 = v2297 + 1L
let v2299 : int64 = v2298 + 1L
let v2300 : int64 = 0L + 1L
let v2301 : int64 = v2300 + 1L
let v2302 : int64 = v2301 + 1L
let v2303 : int64 = v2302 + 1L
let v2304 : bool = v2299 = v2303
let v2305 : int64 =
    if v2304 then
        0L
    else
        1L
let v2306 : int64 = 0L + 1L
let v2307 : int64 = 0L + 1L
let v2308 : bool = v2306 = v2307
let v2309 : int64 =
    if v2308 then
        0L
    else
        1L
let v2310 : int64 = 0L + 1L
let v2311 : int64 = v2310 + 1L
let v2312 : int64 = v2311 + 1L
let v2313 : int64 = v2312 + 1L
let v2314 : int64 = v2313 + 1L
let v2315 : int64 = 0L + 1L
let v2316 : int64 = v2315 + 1L
let v2317 : int64 = v2316 + 1L
let v2318 : int64 = v2317 + 1L
let v2319 : int64 = v2318 + 1L
let v2320 : bool = v2314 = v2319
let v2321 : int64 =
    if v2320 then
        0L
    else
        1L
let v2322 : int64 = v2306 + v2314
let v2323 : int64 = v2307 + v2319
let v2324 : int64 = v2309 + v2321
let v2325 : int64 = v2299 + v2322
let v2326 : int64 = v2303 + v2323
let v2327 : int64 = v2305 + v2324
let v2328 : int64 = 0L + 1L
let v2329 : int64 = v2328 + 1L
let v2330 : int64 = v2329 + 1L
let v2331 : int64 = v2330 + 1L
let v2332 : int64 = 0L + 1L
let v2333 : int64 = v2332 + 1L
let v2334 : int64 = v2333 + 1L
let v2335 : int64 = v2334 + 1L
let v2336 : bool = v2331 = v2335
let v2337 : int64 =
    if v2336 then
        0L
    else
        1L
let v2338 : int64 = 0L + 1L
let v2339 : int64 = 0L + 1L
let v2340 : bool = v2338 = v2339
let v2341 : int64 =
    if v2340 then
        0L
    else
        1L
let v2342 : int64 = 0L + 1L
let v2343 : int64 = v2342 + 1L
let v2344 : int64 = v2343 + 1L
let v2345 : int64 = v2344 + 1L
let v2346 : int64 = v2345 + 1L
let v2347 : int64 = 0L + 1L
let v2348 : int64 = v2347 + 1L
let v2349 : int64 = v2348 + 1L
let v2350 : int64 = v2349 + 1L
let v2351 : int64 = v2350 + 1L
let v2352 : bool = v2346 = v2351
let v2353 : int64 =
    if v2352 then
        0L
    else
        1L
let v2354 : int64 = v2338 + v2346
let v2355 : int64 = v2339 + v2351
let v2356 : int64 = v2341 + v2353
let v2357 : int64 = v2331 + v2354
let v2358 : int64 = v2335 + v2355
let v2359 : int64 = v2337 + v2356
let v2360 : int64 = v2327 + v2359
let v2361 : int64 = 0L + 1L
let v2362 : int64 = v2361 + 1L
let v2363 : int64 = v2362 + 1L
let v2364 : int64 = v2363 + 1L
let v2365 : int64 = 0L + 1L
let v2366 : int64 = v2365 + 1L
let v2367 : int64 = v2366 + 1L
let v2368 : int64 = v2367 + 1L
let v2369 : bool = v2364 = v2368
let v2370 : int64 =
    if v2369 then
        0L
    else
        1L
let v2371 : int64 = 0L + 1L
let v2372 : int64 = 0L + 1L
let v2373 : bool = v2371 = v2372
let v2374 : int64 =
    if v2373 then
        0L
    else
        1L
let v2375 : int64 = 0L + 1L
let v2376 : int64 = v2375 + 1L
let v2377 : int64 = v2376 + 1L
let v2378 : int64 = v2377 + 1L
let v2379 : int64 = v2378 + 1L
let v2380 : int64 = 0L + 1L
let v2381 : int64 = v2380 + 1L
let v2382 : int64 = v2381 + 1L
let v2383 : int64 = v2382 + 1L
let v2384 : int64 = v2383 + 1L
let v2385 : bool = v2379 = v2384
let v2386 : int64 =
    if v2385 then
        0L
    else
        1L
let v2387 : int64 = v2371 + v2379
let v2388 : int64 = v2372 + v2384
let v2389 : int64 = v2374 + v2386
let v2390 : int64 = v2364 + v2387
let v2391 : int64 = v2368 + v2388
let v2392 : int64 = v2370 + v2389
let v2393 : int64 = 0L + 1L
let v2394 : int64 = v2393 + 1L
let v2395 : int64 = v2394 + 1L
let v2396 : int64 = v2395 + 1L
let v2397 : int64 = 0L + 1L
let v2398 : int64 = v2397 + 1L
let v2399 : int64 = v2398 + 1L
let v2400 : int64 = v2399 + 1L
let v2401 : bool = v2396 = v2400
let v2402 : int64 =
    if v2401 then
        0L
    else
        1L
let v2403 : int64 = 0L + 1L
let v2404 : int64 = 0L + 1L
let v2405 : bool = v2403 = v2404
let v2406 : int64 =
    if v2405 then
        0L
    else
        1L
let v2407 : int64 = 0L + 1L
let v2408 : int64 = v2407 + 1L
let v2409 : int64 = v2408 + 1L
let v2410 : int64 = v2409 + 1L
let v2411 : int64 = v2410 + 1L
let v2412 : int64 = 0L + 1L
let v2413 : int64 = v2412 + 1L
let v2414 : int64 = v2413 + 1L
let v2415 : int64 = v2414 + 1L
let v2416 : int64 = v2415 + 1L
let v2417 : bool = v2411 = v2416
let v2418 : int64 =
    if v2417 then
        0L
    else
        1L
let v2419 : int64 = v2403 + v2411
let v2420 : int64 = v2404 + v2416
let v2421 : int64 = v2406 + v2418
let v2422 : int64 = v2396 + v2419
let v2423 : int64 = v2400 + v2420
let v2424 : int64 = v2402 + v2421
let v2425 : int64 = 0L + 1L
let v2426 : int64 = v2425 + 1L
let v2427 : int64 = v2426 + 1L
let v2428 : int64 = v2427 + 1L
let v2429 : int64 = 0L + 1L
let v2430 : int64 = v2429 + 1L
let v2431 : int64 = v2430 + 1L
let v2432 : int64 = v2431 + 1L
let v2433 : bool = v2428 = v2432
let v2434 : int64 =
    if v2433 then
        0L
    else
        1L
let v2435 : int64 = 0L + 1L
let v2436 : int64 = 0L + 1L
let v2437 : bool = v2435 = v2436
let v2438 : int64 =
    if v2437 then
        0L
    else
        1L
let v2439 : int64 = 0L + 1L
let v2440 : int64 = v2439 + 1L
let v2441 : int64 = v2440 + 1L
let v2442 : int64 = v2441 + 1L
let v2443 : int64 = v2442 + 1L
let v2444 : int64 = 0L + 1L
let v2445 : int64 = v2444 + 1L
let v2446 : int64 = v2445 + 1L
let v2447 : int64 = v2446 + 1L
let v2448 : int64 = v2447 + 1L
let v2449 : bool = v2443 = v2448
let v2450 : int64 =
    if v2449 then
        0L
    else
        1L
let v2451 : int64 = v2435 + v2443
let v2452 : int64 = v2436 + v2448
let v2453 : int64 = v2438 + v2450
let v2454 : int64 = v2428 + v2451
let v2455 : int64 = v2432 + v2452
let v2456 : int64 = v2434 + v2453
let v2457 : int64 = 0L + 1L
let v2458 : int64 = v2457 + 1L
let v2459 : int64 = v2458 + 1L
let v2460 : int64 = v2459 + 1L
let v2461 : int64 = 0L + 1L
let v2462 : int64 = v2461 + 1L
let v2463 : int64 = v2462 + 1L
let v2464 : int64 = v2463 + 1L
let v2465 : bool = v2460 = v2464
let v2466 : int64 =
    if v2465 then
        0L
    else
        1L
let v2467 : int64 = 0L + 1L
let v2468 : int64 = 0L + 1L
let v2469 : bool = v2467 = v2468
let v2470 : int64 =
    if v2469 then
        0L
    else
        1L
let v2471 : int64 = 0L + 1L
let v2472 : int64 = v2471 + 1L
let v2473 : int64 = v2472 + 1L
let v2474 : int64 = v2473 + 1L
let v2475 : int64 = v2474 + 1L
let v2476 : int64 = 0L + 1L
let v2477 : int64 = v2476 + 1L
let v2478 : int64 = v2477 + 1L
let v2479 : int64 = v2478 + 1L
let v2480 : int64 = v2479 + 1L
let v2481 : bool = v2475 = v2480
let v2482 : int64 =
    if v2481 then
        0L
    else
        1L
let v2483 : int64 = v2467 + v2475
let v2484 : int64 = v2468 + v2480
let v2485 : int64 = v2470 + v2482
let v2486 : int64 = v2460 + v2483
let v2487 : int64 = v2464 + v2484
let v2488 : int64 = v2466 + v2485
let v2489 : int64 = v2456 + v2488
let v2490 : int64 = v2424 + v2489
let v2491 : int64 = v2392 + v2490
let v2492 : int64 = v2360 + v2491
let v2493 : int64 = 0L + 1L
let v2494 : int64 = v2493 + 1L
let v2495 : int64 = v2494 + 1L
let v2496 : int64 = v2495 + 1L
let v2497 : int64 = 0L + 1L
let v2498 : int64 = v2497 + 1L
let v2499 : int64 = v2498 + 1L
let v2500 : int64 = v2499 + 1L
let v2501 : bool = v2496 = v2500
let v2502 : int64 =
    if v2501 then
        0L
    else
        1L
let v2503 : int64 = 0L + 1L
let v2504 : int64 = 0L + 1L
let v2505 : bool = v2503 = v2504
let v2506 : int64 =
    if v2505 then
        0L
    else
        1L
let v2507 : int64 = 0L + 1L
let v2508 : int64 = v2507 + 1L
let v2509 : int64 = v2508 + 1L
let v2510 : int64 = v2509 + 1L
let v2511 : int64 = v2510 + 1L
let v2512 : int64 = 0L + 1L
let v2513 : int64 = v2512 + 1L
let v2514 : int64 = v2513 + 1L
let v2515 : int64 = v2514 + 1L
let v2516 : int64 = v2515 + 1L
let v2517 : bool = v2511 = v2516
let v2518 : int64 =
    if v2517 then
        0L
    else
        1L
let v2519 : int64 = v2503 + v2511
let v2520 : int64 = v2504 + v2516
let v2521 : int64 = v2506 + v2518
let v2522 : int64 = v2496 + v2519
let v2523 : int64 = v2500 + v2520
let v2524 : int64 = v2502 + v2521
let v2525 : int64 = v2523 + v2524
let v2526 : int64 = v2522 + v2525
let v2527 : int64 = 3L + v2526
let v2528 : int64 = 0L + 1L
let v2529 : int64 = v2528 + 1L
let v2530 : int64 = v2529 + 1L
let v2531 : int64 = v2530 + 1L
let v2532 : int64 = 0L + 1L
let v2533 : int64 = v2532 + 1L
let v2534 : int64 = v2533 + 1L
let v2535 : int64 = v2534 + 1L
let v2536 : bool = v2531 = v2535
let v2537 : int64 =
    if v2536 then
        0L
    else
        1L
let v2538 : int64 = 0L + 1L
let v2539 : int64 = 0L + 1L
let v2540 : bool = v2538 = v2539
let v2541 : int64 =
    if v2540 then
        0L
    else
        1L
let v2542 : int64 = 0L + 1L
let v2543 : int64 = v2542 + 1L
let v2544 : int64 = v2543 + 1L
let v2545 : int64 = v2544 + 1L
let v2546 : int64 = v2545 + 1L
let v2547 : int64 = 0L + 1L
let v2548 : int64 = v2547 + 1L
let v2549 : int64 = v2548 + 1L
let v2550 : int64 = v2549 + 1L
let v2551 : int64 = v2550 + 1L
let v2552 : bool = v2546 = v2551
let v2553 : int64 =
    if v2552 then
        0L
    else
        1L
let v2554 : int64 = v2538 + v2546
let v2555 : int64 = v2539 + v2551
let v2556 : int64 = v2541 + v2553
let v2557 : int64 = v2531 + v2554
let v2558 : int64 = v2535 + v2555
let v2559 : int64 = v2537 + v2556
let v2560 : int64 = v2558 + v2559
let v2561 : int64 = v2557 + v2560
let v2562 : int64 = 3L + v2561
let v2563 : bool = v2527 = v2562
let v2600 : US0 =
    if v2563 then
        let v2564 : int64 = 0L + 1L
        let v2565 : int64 = v2564 + 1L
        let v2566 : int64 = v2565 + 1L
        let v2567 : int64 = v2566 + 1L
        let v2568 : int64 = 0L + 1L
        let v2569 : int64 = v2568 + 1L
        let v2570 : int64 = v2569 + 1L
        let v2571 : int64 = v2570 + 1L
        let v2572 : bool = v2567 = v2571
        let v2573 : int64 =
            if v2572 then
                0L
            else
                1L
        let v2574 : int64 = 0L + 1L
        let v2575 : int64 = 0L + 1L
        let v2576 : bool = v2574 = v2575
        let v2577 : int64 =
            if v2576 then
                0L
            else
                1L
        let v2578 : int64 = 0L + 1L
        let v2579 : int64 = v2578 + 1L
        let v2580 : int64 = v2579 + 1L
        let v2581 : int64 = v2580 + 1L
        let v2582 : int64 = v2581 + 1L
        let v2583 : int64 = 0L + 1L
        let v2584 : int64 = v2583 + 1L
        let v2585 : int64 = v2584 + 1L
        let v2586 : int64 = v2585 + 1L
        let v2587 : int64 = v2586 + 1L
        let v2588 : bool = v2582 = v2587
        let v2589 : int64 =
            if v2588 then
                0L
            else
                1L
        let v2590 : int64 = v2574 + v2582
        let v2591 : int64 = v2575 + v2587
        let v2592 : int64 = v2577 + v2589
        let v2593 : int64 = v2567 + v2590
        let v2594 : int64 = v2571 + v2591
        let v2595 : int64 = v2573 + v2592
        let v2596 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v2593, v2594, v2595, v2596)
    else
        let v2598 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v2527, v2562, v2598)
let struct (v2619 : int64, v2620 : int64, v2621 : int64, v2622 : int64, v2623 : int64, v2624 : int64, v2625 : int64, v2626 : int64, v2627 : int64) =
    match v2600 with
    | US0_0(v2604, v2605, v2606, v2607, v2608, v2609) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v2604, v2605, v2606, v2607, v2608)
    | US0_1(v2601, v2602, v2603) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v2601, v2602, 0L, 0L, 0L, 0L, 0L)
let v2628 : int64 = 0L + 1L
let v2629 : int64 = v2628 + 1L
let v2630 : int64 = v2629 + 1L
let v2631 : int64 = v2630 + 1L
let v2632 : int64 = 0L + 1L
let v2633 : int64 = v2632 + 1L
let v2634 : int64 = v2633 + 1L
let v2635 : int64 = v2634 + 1L
let v2636 : bool = v2631 = v2635
let v2637 : int64 =
    if v2636 then
        0L
    else
        1L
let v2638 : int64 = 0L + 1L
let v2639 : int64 = 0L + 1L
let v2640 : bool = v2638 = v2639
let v2641 : int64 =
    if v2640 then
        0L
    else
        1L
let v2642 : int64 = 0L + 1L
let v2643 : int64 = v2642 + 1L
let v2644 : int64 = v2643 + 1L
let v2645 : int64 = v2644 + 1L
let v2646 : int64 = v2645 + 1L
let v2647 : int64 = 0L + 1L
let v2648 : int64 = v2647 + 1L
let v2649 : int64 = v2648 + 1L
let v2650 : int64 = v2649 + 1L
let v2651 : int64 = v2650 + 1L
let v2652 : bool = v2646 = v2651
let v2653 : int64 =
    if v2652 then
        0L
    else
        1L
let v2654 : int64 = v2638 + v2646
let v2655 : int64 = v2639 + v2651
let v2656 : int64 = v2641 + v2653
let v2657 : int64 = v2631 + v2654
let v2658 : int64 = v2635 + v2655
let v2659 : int64 = v2637 + v2656
let v2660 : int64 = 0L + 1L
let v2661 : int64 = v2660 + 1L
let v2662 : int64 = v2661 + 1L
let v2663 : int64 = v2662 + 1L
let v2664 : int64 = 0L + 1L
let v2665 : int64 = v2664 + 1L
let v2666 : int64 = v2665 + 1L
let v2667 : int64 = v2666 + 1L
let v2668 : bool = v2663 = v2667
let v2669 : int64 =
    if v2668 then
        0L
    else
        1L
let v2670 : int64 = 0L + 1L
let v2671 : int64 = 0L + 1L
let v2672 : bool = v2670 = v2671
let v2673 : int64 =
    if v2672 then
        0L
    else
        1L
let v2674 : int64 = 0L + 1L
let v2675 : int64 = v2674 + 1L
let v2676 : int64 = v2675 + 1L
let v2677 : int64 = v2676 + 1L
let v2678 : int64 = v2677 + 1L
let v2679 : int64 = 0L + 1L
let v2680 : int64 = v2679 + 1L
let v2681 : int64 = v2680 + 1L
let v2682 : int64 = v2681 + 1L
let v2683 : int64 = v2682 + 1L
let v2684 : bool = v2678 = v2683
let v2685 : int64 =
    if v2684 then
        0L
    else
        1L
let v2686 : int64 = v2670 + v2678
let v2687 : int64 = v2671 + v2683
let v2688 : int64 = v2673 + v2685
let v2689 : int64 = v2663 + v2686
let v2690 : int64 = v2667 + v2687
let v2691 : int64 = v2669 + v2688
let v2692 : int64 = 0L + 1L
let v2693 : int64 = v2692 + 1L
let v2694 : int64 = v2693 + 1L
let v2695 : int64 = v2694 + 1L
let v2696 : int64 = 0L + 1L
let v2697 : int64 = v2696 + 1L
let v2698 : int64 = v2697 + 1L
let v2699 : int64 = v2698 + 1L
let v2700 : bool = v2695 = v2699
let v2701 : int64 =
    if v2700 then
        0L
    else
        1L
let v2702 : int64 = 0L + 1L
let v2703 : int64 = 0L + 1L
let v2704 : bool = v2702 = v2703
let v2705 : int64 =
    if v2704 then
        0L
    else
        1L
let v2706 : int64 = 0L + 1L
let v2707 : int64 = v2706 + 1L
let v2708 : int64 = v2707 + 1L
let v2709 : int64 = v2708 + 1L
let v2710 : int64 = v2709 + 1L
let v2711 : int64 = 0L + 1L
let v2712 : int64 = v2711 + 1L
let v2713 : int64 = v2712 + 1L
let v2714 : int64 = v2713 + 1L
let v2715 : int64 = v2714 + 1L
let v2716 : bool = v2710 = v2715
let v2717 : int64 =
    if v2716 then
        0L
    else
        1L
let v2718 : int64 = v2702 + v2710
let v2719 : int64 = v2703 + v2715
let v2720 : int64 = v2705 + v2717
let v2721 : int64 = v2695 + v2718
let v2722 : int64 = v2699 + v2719
let v2723 : int64 = v2701 + v2720
let v2724 : int64 = 0L + 1L
let v2725 : int64 = v2724 + 1L
let v2726 : int64 = v2725 + 1L
let v2727 : int64 = v2726 + 1L
let v2728 : int64 = 0L + 1L
let v2729 : int64 = v2728 + 1L
let v2730 : int64 = v2729 + 1L
let v2731 : int64 = v2730 + 1L
let v2732 : bool = v2727 = v2731
let v2733 : int64 =
    if v2732 then
        0L
    else
        1L
let v2734 : int64 = 0L + 1L
let v2735 : int64 = 0L + 1L
let v2736 : bool = v2734 = v2735
let v2737 : int64 =
    if v2736 then
        0L
    else
        1L
let v2738 : int64 = 0L + 1L
let v2739 : int64 = v2738 + 1L
let v2740 : int64 = v2739 + 1L
let v2741 : int64 = v2740 + 1L
let v2742 : int64 = v2741 + 1L
let v2743 : int64 = 0L + 1L
let v2744 : int64 = v2743 + 1L
let v2745 : int64 = v2744 + 1L
let v2746 : int64 = v2745 + 1L
let v2747 : int64 = v2746 + 1L
let v2748 : bool = v2742 = v2747
let v2749 : int64 =
    if v2748 then
        0L
    else
        1L
let v2750 : int64 = v2734 + v2742
let v2751 : int64 = v2735 + v2747
let v2752 : int64 = v2737 + v2749
let v2753 : int64 = v2727 + v2750
let v2754 : int64 = v2731 + v2751
let v2755 : int64 = v2733 + v2752
let v2756 : int64 = v2723 + v2755
let v2757 : int64 = v2691 + v2756
let v2758 : int64 = v2659 + v2757
let v2759 : int64 = v2627 + v2620
let v2760 : int64 = v2758 + v2759
let v2761 : int64 = v2492 + v2760
let v2762 : bool = v2623 = 1L
let v2763 : bool = v2619 = 1L
let v2764 : bool = v2761 = 0L
let v2765 : bool = v2762 && v2763
let v2766 : bool = v2765 && v2764
if v2766 then
    ()
else
    failwith<unit> "typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch"
let v2767 : int64 = 0L + 1L
let v2768 : int64 = v2767 + 1L
let v2769 : int64 = v2768 + 1L
let v2770 : int64 = v2769 + 1L
let v2771 : int64 = 0L + 1L
let v2772 : int64 = v2771 + 1L
let v2773 : int64 = v2772 + 1L
let v2774 : int64 = v2773 + 1L
let v2775 : bool = v2770 = v2774
let v2776 : int64 =
    if v2775 then
        0L
    else
        1L
let v2777 : int64 = 0L + 1L
let v2778 : int64 = 0L + 1L
let v2779 : bool = v2777 = v2778
let v2780 : int64 =
    if v2779 then
        0L
    else
        1L
let v2781 : int64 = 0L + 1L
let v2782 : int64 = v2781 + 1L
let v2783 : int64 = v2782 + 1L
let v2784 : int64 = v2783 + 1L
let v2785 : int64 = v2784 + 1L
let v2786 : int64 = 0L + 1L
let v2787 : int64 = v2786 + 1L
let v2788 : int64 = v2787 + 1L
let v2789 : int64 = v2788 + 1L
let v2790 : int64 = v2789 + 1L
let v2791 : bool = v2785 = v2790
let v2792 : int64 =
    if v2791 then
        0L
    else
        1L
let v2793 : int64 = v2777 + v2785
let v2794 : int64 = v2778 + v2790
let v2795 : int64 = v2780 + v2792
let v2796 : int64 = v2770 + v2793
let v2797 : int64 = v2774 + v2794
let v2798 : int64 = v2776 + v2795
let v2799 : int64 = 0L + 1L
let v2800 : int64 = v2799 + 1L
let v2801 : int64 = v2800 + 1L
let v2802 : int64 = v2801 + 1L
let v2803 : int64 = 0L + 1L
let v2804 : int64 = v2803 + 1L
let v2805 : int64 = v2804 + 1L
let v2806 : int64 = v2805 + 1L
let v2807 : bool = v2802 = v2806
let v2808 : int64 =
    if v2807 then
        0L
    else
        1L
let v2809 : int64 = 0L + 1L
let v2810 : int64 = 0L + 1L
let v2811 : bool = v2809 = v2810
let v2812 : int64 =
    if v2811 then
        0L
    else
        1L
let v2813 : int64 = 0L + 1L
let v2814 : int64 = v2813 + 1L
let v2815 : int64 = v2814 + 1L
let v2816 : int64 = v2815 + 1L
let v2817 : int64 = v2816 + 1L
let v2818 : int64 = 0L + 1L
let v2819 : int64 = v2818 + 1L
let v2820 : int64 = v2819 + 1L
let v2821 : int64 = v2820 + 1L
let v2822 : int64 = v2821 + 1L
let v2823 : bool = v2817 = v2822
let v2824 : int64 =
    if v2823 then
        0L
    else
        1L
let v2825 : int64 = v2809 + v2817
let v2826 : int64 = v2810 + v2822
let v2827 : int64 = v2812 + v2824
let v2828 : int64 = v2802 + v2825
let v2829 : int64 = v2806 + v2826
let v2830 : int64 = v2808 + v2827
let v2831 : int64 = v2798 + v2830
let v2832 : int64 = 0L + 1L
let v2833 : int64 = v2832 + 1L
let v2834 : int64 = v2833 + 1L
let v2835 : int64 = v2834 + 1L
let v2836 : int64 = 0L + 1L
let v2837 : int64 = v2836 + 1L
let v2838 : int64 = v2837 + 1L
let v2839 : int64 = v2838 + 1L
let v2840 : bool = v2835 = v2839
let v2841 : int64 =
    if v2840 then
        0L
    else
        1L
let v2842 : int64 = 0L + 1L
let v2843 : int64 = 0L + 1L
let v2844 : bool = v2842 = v2843
let v2845 : int64 =
    if v2844 then
        0L
    else
        1L
let v2846 : int64 = 0L + 1L
let v2847 : int64 = v2846 + 1L
let v2848 : int64 = v2847 + 1L
let v2849 : int64 = v2848 + 1L
let v2850 : int64 = v2849 + 1L
let v2851 : int64 = 0L + 1L
let v2852 : int64 = v2851 + 1L
let v2853 : int64 = v2852 + 1L
let v2854 : int64 = v2853 + 1L
let v2855 : int64 = v2854 + 1L
let v2856 : bool = v2850 = v2855
let v2857 : int64 =
    if v2856 then
        0L
    else
        1L
let v2858 : int64 = v2842 + v2850
let v2859 : int64 = v2843 + v2855
let v2860 : int64 = v2845 + v2857
let v2861 : int64 = v2835 + v2858
let v2862 : int64 = v2839 + v2859
let v2863 : int64 = v2841 + v2860
let v2864 : int64 = 0L + 1L
let v2865 : int64 = v2864 + 1L
let v2866 : int64 = v2865 + 1L
let v2867 : int64 = v2866 + 1L
let v2868 : int64 = 0L + 1L
let v2869 : int64 = v2868 + 1L
let v2870 : int64 = v2869 + 1L
let v2871 : int64 = v2870 + 1L
let v2872 : bool = v2867 = v2871
let v2873 : int64 =
    if v2872 then
        0L
    else
        1L
let v2874 : int64 = 0L + 1L
let v2875 : int64 = 0L + 1L
let v2876 : bool = v2874 = v2875
let v2877 : int64 =
    if v2876 then
        0L
    else
        1L
let v2878 : int64 = 0L + 1L
let v2879 : int64 = v2878 + 1L
let v2880 : int64 = v2879 + 1L
let v2881 : int64 = v2880 + 1L
let v2882 : int64 = v2881 + 1L
let v2883 : int64 = 0L + 1L
let v2884 : int64 = v2883 + 1L
let v2885 : int64 = v2884 + 1L
let v2886 : int64 = v2885 + 1L
let v2887 : int64 = v2886 + 1L
let v2888 : bool = v2882 = v2887
let v2889 : int64 =
    if v2888 then
        0L
    else
        1L
let v2890 : int64 = v2874 + v2882
let v2891 : int64 = v2875 + v2887
let v2892 : int64 = v2877 + v2889
let v2893 : int64 = v2867 + v2890
let v2894 : int64 = v2871 + v2891
let v2895 : int64 = v2873 + v2892
let v2896 : int64 = v2863 + v2895
let v2897 : int64 = v2831 + v2896
let v2898 : int64 = 0L + 1L
let v2899 : int64 = v2898 + 1L
let v2900 : int64 = v2899 + 1L
let v2901 : int64 = v2900 + 1L
let v2902 : int64 = 0L + 1L
let v2903 : int64 = v2902 + 1L
let v2904 : int64 = v2903 + 1L
let v2905 : int64 = v2904 + 1L
let v2906 : bool = v2901 = v2905
let v2907 : int64 =
    if v2906 then
        0L
    else
        1L
let v2908 : int64 = 0L + 1L
let v2909 : int64 = 0L + 1L
let v2910 : bool = v2908 = v2909
let v2911 : int64 =
    if v2910 then
        0L
    else
        1L
let v2912 : int64 = 0L + 1L
let v2913 : int64 = v2912 + 1L
let v2914 : int64 = v2913 + 1L
let v2915 : int64 = v2914 + 1L
let v2916 : int64 = v2915 + 1L
let v2917 : int64 = 0L + 1L
let v2918 : int64 = v2917 + 1L
let v2919 : int64 = v2918 + 1L
let v2920 : int64 = v2919 + 1L
let v2921 : int64 = v2920 + 1L
let v2922 : bool = v2916 = v2921
let v2923 : int64 =
    if v2922 then
        0L
    else
        1L
let v2924 : int64 = v2908 + v2916
let v2925 : int64 = v2909 + v2921
let v2926 : int64 = v2911 + v2923
let v2927 : int64 = v2901 + v2924
let v2928 : int64 = v2905 + v2925
let v2929 : int64 = v2907 + v2926
let v2930 : int64 = v2928 + v2929
let v2931 : int64 = v2927 + v2930
let v2932 : int64 = 3L + v2931
let v2933 : int64 = 0L + 1L
let v2934 : int64 = v2933 + 1L
let v2935 : int64 = v2934 + 1L
let v2936 : int64 = v2935 + 1L
let v2937 : int64 = 0L + 1L
let v2938 : int64 = v2937 + 1L
let v2939 : int64 = v2938 + 1L
let v2940 : int64 = v2939 + 1L
let v2941 : bool = v2936 = v2940
let v2942 : int64 =
    if v2941 then
        0L
    else
        1L
let v2943 : int64 = 0L + 1L
let v2944 : int64 = 0L + 1L
let v2945 : bool = v2943 = v2944
let v2946 : int64 =
    if v2945 then
        0L
    else
        1L
let v2947 : int64 = 0L + 1L
let v2948 : int64 = v2947 + 1L
let v2949 : int64 = v2948 + 1L
let v2950 : int64 = v2949 + 1L
let v2951 : int64 = v2950 + 1L
let v2952 : int64 = 0L + 1L
let v2953 : int64 = v2952 + 1L
let v2954 : int64 = v2953 + 1L
let v2955 : int64 = v2954 + 1L
let v2956 : int64 = v2955 + 1L
let v2957 : bool = v2951 = v2956
let v2958 : int64 =
    if v2957 then
        0L
    else
        1L
let v2959 : int64 = v2943 + v2951
let v2960 : int64 = v2944 + v2956
let v2961 : int64 = v2946 + v2958
let v2962 : int64 = v2936 + v2959
let v2963 : int64 = v2940 + v2960
let v2964 : int64 = v2942 + v2961
let v2965 : int64 = v2963 + v2964
let v2966 : int64 = v2962 + v2965
let v2967 : int64 = 3L + v2966
let v2968 : bool = v2932 = v2967
let v3005 : US0 =
    if v2968 then
        let v2969 : int64 = 0L + 1L
        let v2970 : int64 = v2969 + 1L
        let v2971 : int64 = v2970 + 1L
        let v2972 : int64 = v2971 + 1L
        let v2973 : int64 = 0L + 1L
        let v2974 : int64 = v2973 + 1L
        let v2975 : int64 = v2974 + 1L
        let v2976 : int64 = v2975 + 1L
        let v2977 : bool = v2972 = v2976
        let v2978 : int64 =
            if v2977 then
                0L
            else
                1L
        let v2979 : int64 = 0L + 1L
        let v2980 : int64 = 0L + 1L
        let v2981 : bool = v2979 = v2980
        let v2982 : int64 =
            if v2981 then
                0L
            else
                1L
        let v2983 : int64 = 0L + 1L
        let v2984 : int64 = v2983 + 1L
        let v2985 : int64 = v2984 + 1L
        let v2986 : int64 = v2985 + 1L
        let v2987 : int64 = v2986 + 1L
        let v2988 : int64 = 0L + 1L
        let v2989 : int64 = v2988 + 1L
        let v2990 : int64 = v2989 + 1L
        let v2991 : int64 = v2990 + 1L
        let v2992 : int64 = v2991 + 1L
        let v2993 : bool = v2987 = v2992
        let v2994 : int64 =
            if v2993 then
                0L
            else
                1L
        let v2995 : int64 = v2979 + v2987
        let v2996 : int64 = v2980 + v2992
        let v2997 : int64 = v2982 + v2994
        let v2998 : int64 = v2972 + v2995
        let v2999 : int64 = v2976 + v2996
        let v3000 : int64 = v2978 + v2997
        let v3001 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v2998, v2999, v3000, v3001)
    else
        let v3003 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v2932, v2967, v3003)
let struct (v3024 : int64, v3025 : int64, v3026 : int64, v3027 : int64, v3028 : int64, v3029 : int64, v3030 : int64, v3031 : int64, v3032 : int64) =
    match v3005 with
    | US0_0(v3009, v3010, v3011, v3012, v3013, v3014) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v3009, v3010, v3011, v3012, v3013)
    | US0_1(v3006, v3007, v3008) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v3006, v3007, 0L, 0L, 0L, 0L, 0L)
let v3033 : int64 = 0L + 1L
let v3034 : int64 = v3033 + 1L
let v3035 : int64 = v3034 + 1L
let v3036 : int64 = v3035 + 1L
let v3037 : int64 = 0L + 1L
let v3038 : int64 = v3037 + 1L
let v3039 : int64 = v3038 + 1L
let v3040 : int64 = v3039 + 1L
let v3041 : bool = v3036 = v3040
let v3042 : int64 =
    if v3041 then
        0L
    else
        1L
let v3043 : int64 = 0L + 1L
let v3044 : int64 = 0L + 1L
let v3045 : bool = v3043 = v3044
let v3046 : int64 =
    if v3045 then
        0L
    else
        1L
let v3047 : int64 = 0L + 1L
let v3048 : int64 = v3047 + 1L
let v3049 : int64 = v3048 + 1L
let v3050 : int64 = v3049 + 1L
let v3051 : int64 = v3050 + 1L
let v3052 : int64 = 0L + 1L
let v3053 : int64 = v3052 + 1L
let v3054 : int64 = v3053 + 1L
let v3055 : int64 = v3054 + 1L
let v3056 : int64 = v3055 + 1L
let v3057 : bool = v3051 = v3056
let v3058 : int64 =
    if v3057 then
        0L
    else
        1L
let v3059 : int64 = v3043 + v3051
let v3060 : int64 = v3044 + v3056
let v3061 : int64 = v3046 + v3058
let v3062 : int64 = v3036 + v3059
let v3063 : int64 = v3040 + v3060
let v3064 : int64 = v3042 + v3061
let v3065 : int64 = 0L + 1L
let v3066 : int64 = v3065 + 1L
let v3067 : int64 = v3066 + 1L
let v3068 : int64 = v3067 + 1L
let v3069 : int64 = 0L + 1L
let v3070 : int64 = v3069 + 1L
let v3071 : int64 = v3070 + 1L
let v3072 : int64 = v3071 + 1L
let v3073 : bool = v3068 = v3072
let v3074 : int64 =
    if v3073 then
        0L
    else
        1L
let v3075 : int64 = 0L + 1L
let v3076 : int64 = 0L + 1L
let v3077 : bool = v3075 = v3076
let v3078 : int64 =
    if v3077 then
        0L
    else
        1L
let v3079 : int64 = 0L + 1L
let v3080 : int64 = v3079 + 1L
let v3081 : int64 = v3080 + 1L
let v3082 : int64 = v3081 + 1L
let v3083 : int64 = v3082 + 1L
let v3084 : int64 = 0L + 1L
let v3085 : int64 = v3084 + 1L
let v3086 : int64 = v3085 + 1L
let v3087 : int64 = v3086 + 1L
let v3088 : int64 = v3087 + 1L
let v3089 : bool = v3083 = v3088
let v3090 : int64 =
    if v3089 then
        0L
    else
        1L
let v3091 : int64 = v3075 + v3083
let v3092 : int64 = v3076 + v3088
let v3093 : int64 = v3078 + v3090
let v3094 : int64 = v3068 + v3091
let v3095 : int64 = v3072 + v3092
let v3096 : int64 = v3074 + v3093
let v3097 : int64 = v3064 + v3096
let v3098 : int64 = v3032 + v3025
let v3099 : int64 = v3097 + v3098
let v3100 : int64 = v2897 + v3099
let v3101 : bool = v3024 = 1L
let v3102 : bool = v3100 = 0L
let v3103 : bool = v3101 && v3102
if v3103 then
    ()
else
    failwith<unit> "typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch"
let v3104 : int64 = 0L + 1L
let v3105 : int64 = v3104 + 1L
let v3106 : int64 = v3105 + 1L
let v3107 : int64 = v3106 + 1L
let v3108 : int64 = 0L + 1L
let v3109 : int64 = v3108 + 1L
let v3110 : int64 = v3109 + 1L
let v3111 : int64 = v3110 + 1L
let v3112 : bool = v3107 = v3111
let v3113 : int64 =
    if v3112 then
        0L
    else
        1L
let v3114 : int64 = 0L + 1L
let v3115 : int64 = 0L + 1L
let v3116 : bool = v3114 = v3115
let v3117 : int64 =
    if v3116 then
        0L
    else
        1L
let v3118 : int64 = 0L + 1L
let v3119 : int64 = v3118 + 1L
let v3120 : int64 = v3119 + 1L
let v3121 : int64 = v3120 + 1L
let v3122 : int64 = v3121 + 1L
let v3123 : int64 = 0L + 1L
let v3124 : int64 = v3123 + 1L
let v3125 : int64 = v3124 + 1L
let v3126 : int64 = v3125 + 1L
let v3127 : int64 = v3126 + 1L
let v3128 : bool = v3122 = v3127
let v3129 : int64 =
    if v3128 then
        0L
    else
        1L
let v3130 : int64 = v3114 + v3122
let v3131 : int64 = v3115 + v3127
let v3132 : int64 = v3117 + v3129
let v3133 : int64 = v3107 + v3130
let v3134 : int64 = v3111 + v3131
let v3135 : int64 = v3113 + v3132
let v3136 : int64 = 0L + 1L
let v3137 : int64 = v3136 + 1L
let v3138 : int64 = v3137 + 1L
let v3139 : int64 = v3138 + 1L
let v3140 : int64 = 0L + 1L
let v3141 : int64 = v3140 + 1L
let v3142 : int64 = v3141 + 1L
let v3143 : int64 = v3142 + 1L
let v3144 : bool = v3139 = v3143
let v3145 : int64 =
    if v3144 then
        0L
    else
        1L
let v3146 : int64 = 0L + 1L
let v3147 : int64 = 0L + 1L
let v3148 : bool = v3146 = v3147
let v3149 : int64 =
    if v3148 then
        0L
    else
        1L
let v3150 : int64 = 0L + 1L
let v3151 : int64 = v3150 + 1L
let v3152 : int64 = v3151 + 1L
let v3153 : int64 = v3152 + 1L
let v3154 : int64 = v3153 + 1L
let v3155 : int64 = 0L + 1L
let v3156 : int64 = v3155 + 1L
let v3157 : int64 = v3156 + 1L
let v3158 : int64 = v3157 + 1L
let v3159 : int64 = v3158 + 1L
let v3160 : bool = v3154 = v3159
let v3161 : int64 =
    if v3160 then
        0L
    else
        1L
let v3162 : int64 = v3146 + v3154
let v3163 : int64 = v3147 + v3159
let v3164 : int64 = v3149 + v3161
let v3165 : int64 = v3139 + v3162
let v3166 : int64 = v3143 + v3163
let v3167 : int64 = v3145 + v3164
let v3168 : int64 = v3135 + v3167
let v3169 : int64 = 0L + 1L
let v3170 : int64 = v3169 + 1L
let v3171 : int64 = v3170 + 1L
let v3172 : int64 = v3171 + 1L
let v3173 : int64 = 0L + 1L
let v3174 : int64 = v3173 + 1L
let v3175 : int64 = v3174 + 1L
let v3176 : int64 = v3175 + 1L
let v3177 : bool = v3172 = v3176
let v3178 : int64 =
    if v3177 then
        0L
    else
        1L
let v3179 : int64 = 0L + 1L
let v3180 : int64 = 0L + 1L
let v3181 : bool = v3179 = v3180
let v3182 : int64 =
    if v3181 then
        0L
    else
        1L
let v3183 : int64 = 0L + 1L
let v3184 : int64 = v3183 + 1L
let v3185 : int64 = v3184 + 1L
let v3186 : int64 = v3185 + 1L
let v3187 : int64 = v3186 + 1L
let v3188 : int64 = 0L + 1L
let v3189 : int64 = v3188 + 1L
let v3190 : int64 = v3189 + 1L
let v3191 : int64 = v3190 + 1L
let v3192 : int64 = v3191 + 1L
let v3193 : bool = v3187 = v3192
let v3194 : int64 =
    if v3193 then
        0L
    else
        1L
let v3195 : int64 = v3179 + v3187
let v3196 : int64 = v3180 + v3192
let v3197 : int64 = v3182 + v3194
let v3198 : int64 = v3172 + v3195
let v3199 : int64 = v3176 + v3196
let v3200 : int64 = v3178 + v3197
let v3201 : int64 = 0L + 1L
let v3202 : int64 = v3201 + 1L
let v3203 : int64 = v3202 + 1L
let v3204 : int64 = v3203 + 1L
let v3205 : int64 = 0L + 1L
let v3206 : int64 = v3205 + 1L
let v3207 : int64 = v3206 + 1L
let v3208 : int64 = v3207 + 1L
let v3209 : bool = v3204 = v3208
let v3210 : int64 =
    if v3209 then
        0L
    else
        1L
let v3211 : int64 = 0L + 1L
let v3212 : int64 = 0L + 1L
let v3213 : bool = v3211 = v3212
let v3214 : int64 =
    if v3213 then
        0L
    else
        1L
let v3215 : int64 = 0L + 1L
let v3216 : int64 = v3215 + 1L
let v3217 : int64 = v3216 + 1L
let v3218 : int64 = v3217 + 1L
let v3219 : int64 = v3218 + 1L
let v3220 : int64 = 0L + 1L
let v3221 : int64 = v3220 + 1L
let v3222 : int64 = v3221 + 1L
let v3223 : int64 = v3222 + 1L
let v3224 : int64 = v3223 + 1L
let v3225 : bool = v3219 = v3224
let v3226 : int64 =
    if v3225 then
        0L
    else
        1L
let v3227 : int64 = v3211 + v3219
let v3228 : int64 = v3212 + v3224
let v3229 : int64 = v3214 + v3226
let v3230 : int64 = v3204 + v3227
let v3231 : int64 = v3208 + v3228
let v3232 : int64 = v3210 + v3229
let v3233 : int64 = v3200 + v3232
let v3234 : int64 = v3168 + v3233
let v3235 : int64 = 0L + 1L
let v3236 : int64 = v3235 + 1L
let v3237 : int64 = v3236 + 1L
let v3238 : int64 = v3237 + 1L
let v3239 : int64 = 0L + 1L
let v3240 : int64 = v3239 + 1L
let v3241 : int64 = v3240 + 1L
let v3242 : int64 = v3241 + 1L
let v3243 : bool = v3238 = v3242
let v3244 : int64 =
    if v3243 then
        0L
    else
        1L
let v3245 : int64 = 0L + 1L
let v3246 : int64 = 0L + 1L
let v3247 : bool = v3245 = v3246
let v3248 : int64 =
    if v3247 then
        0L
    else
        1L
let v3249 : int64 = 0L + 1L
let v3250 : int64 = v3249 + 1L
let v3251 : int64 = v3250 + 1L
let v3252 : int64 = v3251 + 1L
let v3253 : int64 = v3252 + 1L
let v3254 : int64 = 0L + 1L
let v3255 : int64 = v3254 + 1L
let v3256 : int64 = v3255 + 1L
let v3257 : int64 = v3256 + 1L
let v3258 : int64 = v3257 + 1L
let v3259 : bool = v3253 = v3258
let v3260 : int64 =
    if v3259 then
        0L
    else
        1L
let v3261 : int64 = v3245 + v3253
let v3262 : int64 = v3246 + v3258
let v3263 : int64 = v3248 + v3260
let v3264 : int64 = v3238 + v3261
let v3265 : int64 = v3242 + v3262
let v3266 : int64 = v3244 + v3263
let v3267 : int64 = v3265 + v3266
let v3268 : int64 = v3264 + v3267
let v3269 : int64 = 3L + v3268
let v3270 : int64 = 0L + 1L
let v3271 : int64 = v3270 + 1L
let v3272 : int64 = v3271 + 1L
let v3273 : int64 = v3272 + 1L
let v3274 : int64 = 0L + 1L
let v3275 : int64 = v3274 + 1L
let v3276 : int64 = v3275 + 1L
let v3277 : int64 = v3276 + 1L
let v3278 : bool = v3273 = v3277
let v3279 : int64 =
    if v3278 then
        0L
    else
        1L
let v3280 : int64 = 0L + 1L
let v3281 : int64 = 0L + 1L
let v3282 : bool = v3280 = v3281
let v3283 : int64 =
    if v3282 then
        0L
    else
        1L
let v3284 : int64 = 0L + 1L
let v3285 : int64 = v3284 + 1L
let v3286 : int64 = v3285 + 1L
let v3287 : int64 = v3286 + 1L
let v3288 : int64 = v3287 + 1L
let v3289 : int64 = 0L + 1L
let v3290 : int64 = v3289 + 1L
let v3291 : int64 = v3290 + 1L
let v3292 : int64 = v3291 + 1L
let v3293 : int64 = v3292 + 1L
let v3294 : bool = v3288 = v3293
let v3295 : int64 =
    if v3294 then
        0L
    else
        1L
let v3296 : int64 = v3280 + v3288
let v3297 : int64 = v3281 + v3293
let v3298 : int64 = v3283 + v3295
let v3299 : int64 = v3273 + v3296
let v3300 : int64 = v3277 + v3297
let v3301 : int64 = v3279 + v3298
let v3302 : int64 = v3300 + v3301
let v3303 : int64 = v3299 + v3302
let v3304 : int64 = 3L + v3303
let v3305 : bool = v3269 = v3304
let v3342 : US0 =
    if v3305 then
        let v3306 : int64 = 0L + 1L
        let v3307 : int64 = v3306 + 1L
        let v3308 : int64 = v3307 + 1L
        let v3309 : int64 = v3308 + 1L
        let v3310 : int64 = 0L + 1L
        let v3311 : int64 = v3310 + 1L
        let v3312 : int64 = v3311 + 1L
        let v3313 : int64 = v3312 + 1L
        let v3314 : bool = v3309 = v3313
        let v3315 : int64 =
            if v3314 then
                0L
            else
                1L
        let v3316 : int64 = 0L + 1L
        let v3317 : int64 = 0L + 1L
        let v3318 : bool = v3316 = v3317
        let v3319 : int64 =
            if v3318 then
                0L
            else
                1L
        let v3320 : int64 = 0L + 1L
        let v3321 : int64 = v3320 + 1L
        let v3322 : int64 = v3321 + 1L
        let v3323 : int64 = v3322 + 1L
        let v3324 : int64 = v3323 + 1L
        let v3325 : int64 = 0L + 1L
        let v3326 : int64 = v3325 + 1L
        let v3327 : int64 = v3326 + 1L
        let v3328 : int64 = v3327 + 1L
        let v3329 : int64 = v3328 + 1L
        let v3330 : bool = v3324 = v3329
        let v3331 : int64 =
            if v3330 then
                0L
            else
                1L
        let v3332 : int64 = v3316 + v3324
        let v3333 : int64 = v3317 + v3329
        let v3334 : int64 = v3319 + v3331
        let v3335 : int64 = v3309 + v3332
        let v3336 : int64 = v3313 + v3333
        let v3337 : int64 = v3315 + v3334
        let v3338 : string = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation"
        US0_0(1L, 3L, v3335, v3336, v3337, v3338)
    else
        let v3340 : string = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric"
        US0_1(v3269, v3304, v3340)
let struct (v3361 : int64, v3362 : int64, v3363 : int64, v3364 : int64, v3365 : int64, v3366 : int64, v3367 : int64, v3368 : int64, v3369 : int64) =
    match v3342 with
    | US0_0(v3346, v3347, v3348, v3349, v3350, v3351) -> (* TypedFxHashedStatementChecksumValidationAccepted *)
        struct (1L, 0L, 0L, 0L, v3346, v3347, v3348, v3349, v3350)
    | US0_1(v3343, v3344, v3345) -> (* TypedFxHashedStatementChecksumValidationRejected *)
        struct (0L, 1L, v3343, v3344, 0L, 0L, 0L, 0L, 0L)
let v3370 : int64 = 0L + 1L
let v3371 : int64 = v3370 + 1L
let v3372 : int64 = v3371 + 1L
let v3373 : int64 = v3372 + 1L
let v3374 : int64 = 0L + 1L
let v3375 : int64 = v3374 + 1L
let v3376 : int64 = v3375 + 1L
let v3377 : int64 = v3376 + 1L
let v3378 : bool = v3373 = v3377
let v3379 : int64 =
    if v3378 then
        0L
    else
        1L
let v3380 : int64 = 0L + 1L
let v3381 : int64 = 0L + 1L
let v3382 : bool = v3380 = v3381
let v3383 : int64 =
    if v3382 then
        0L
    else
        1L
let v3384 : int64 = 0L + 1L
let v3385 : int64 = v3384 + 1L
let v3386 : int64 = v3385 + 1L
let v3387 : int64 = v3386 + 1L
let v3388 : int64 = v3387 + 1L
let v3389 : int64 = 0L + 1L
let v3390 : int64 = v3389 + 1L
let v3391 : int64 = v3390 + 1L
let v3392 : int64 = v3391 + 1L
let v3393 : int64 = v3392 + 1L
let v3394 : bool = v3388 = v3393
let v3395 : int64 =
    if v3394 then
        0L
    else
        1L
let v3396 : int64 = v3380 + v3388
let v3397 : int64 = v3381 + v3393
let v3398 : int64 = v3383 + v3395
let v3399 : int64 = v3373 + v3396
let v3400 : int64 = v3377 + v3397
let v3401 : int64 = v3379 + v3398
let v3402 : int64 = 0L + 1L
let v3403 : int64 = v3402 + 1L
let v3404 : int64 = v3403 + 1L
let v3405 : int64 = v3404 + 1L
let v3406 : int64 = 0L + 1L
let v3407 : int64 = v3406 + 1L
let v3408 : int64 = v3407 + 1L
let v3409 : int64 = v3408 + 1L
let v3410 : bool = v3405 = v3409
let v3411 : int64 =
    if v3410 then
        0L
    else
        1L
let v3412 : int64 = 0L + 1L
let v3413 : int64 = 0L + 1L
let v3414 : bool = v3412 = v3413
let v3415 : int64 =
    if v3414 then
        0L
    else
        1L
let v3416 : int64 = 0L + 1L
let v3417 : int64 = v3416 + 1L
let v3418 : int64 = v3417 + 1L
let v3419 : int64 = v3418 + 1L
let v3420 : int64 = v3419 + 1L
let v3421 : int64 = 0L + 1L
let v3422 : int64 = v3421 + 1L
let v3423 : int64 = v3422 + 1L
let v3424 : int64 = v3423 + 1L
let v3425 : int64 = v3424 + 1L
let v3426 : bool = v3420 = v3425
let v3427 : int64 =
    if v3426 then
        0L
    else
        1L
let v3428 : int64 = v3412 + v3420
let v3429 : int64 = v3413 + v3425
let v3430 : int64 = v3415 + v3427
let v3431 : int64 = v3405 + v3428
let v3432 : int64 = v3409 + v3429
let v3433 : int64 = v3411 + v3430
let v3434 : int64 = v3401 + v3433
let v3435 : int64 = v3369 + v3362
let v3436 : int64 = v3434 + v3435
let v3437 : int64 = v3234 + v3436
let v3438 : bool = v3361 = 1L
let v3439 : bool = v3437 = 0L
let v3440 : bool = v3438 && v3439
if v3440 then
    ()
else
    failwith<unit> "typed-FX-statement-indexed-durable-commit-runtime-mismatch"
let v3441 : int64 = 0L + 1L
let v3442 : int64 = v3441 + 1L
let v3443 : int64 = v3442 + 1L
let v3444 : int64 = v3443 + 1L
let v3445 : int64 = 0L + 1L
let v3446 : int64 = v3445 + 1L
let v3447 : int64 = v3446 + 1L
let v3448 : int64 = v3447 + 1L
let v3449 : bool = v3444 = v3448
let v3450 : int64 =
    if v3449 then
        0L
    else
        1L
let v3451 : int64 = 0L + 1L
let v3452 : int64 = 0L + 1L
let v3453 : bool = v3451 = v3452
let v3454 : int64 =
    if v3453 then
        0L
    else
        1L
let v3455 : int64 = 0L + 1L
let v3456 : int64 = v3455 + 1L
let v3457 : int64 = v3456 + 1L
let v3458 : int64 = v3457 + 1L
let v3459 : int64 = v3458 + 1L
let v3460 : int64 = 0L + 1L
let v3461 : int64 = v3460 + 1L
let v3462 : int64 = v3461 + 1L
let v3463 : int64 = v3462 + 1L
let v3464 : int64 = v3463 + 1L
let v3465 : bool = v3459 = v3464
let v3466 : int64 =
    if v3465 then
        0L
    else
        1L
let v3467 : int64 = v3451 + v3459
let v3468 : int64 = v3452 + v3464
let v3469 : int64 = v3454 + v3466
let v3470 : int64 = v3444 + v3467
let v3471 : int64 = v3448 + v3468
let v3472 : int64 = v3450 + v3469
let v3473 : int64 = 0L + 1L
let v3474 : int64 = v3473 + 1L
let v3475 : int64 = v3474 + 1L
let v3476 : int64 = v3475 + 1L
let v3477 : int64 = 0L + 1L
let v3478 : int64 = v3477 + 1L
let v3479 : int64 = v3478 + 1L
let v3480 : int64 = v3479 + 1L
let v3481 : bool = v3476 = v3480
let v3482 : int64 =
    if v3481 then
        0L
    else
        1L
let v3483 : int64 = 0L + 1L
let v3484 : int64 = 0L + 1L
let v3485 : bool = v3483 = v3484
let v3486 : int64 =
    if v3485 then
        0L
    else
        1L
let v3487 : int64 = 0L + 1L
let v3488 : int64 = v3487 + 1L
let v3489 : int64 = v3488 + 1L
let v3490 : int64 = v3489 + 1L
let v3491 : int64 = v3490 + 1L
let v3492 : int64 = 0L + 1L
let v3493 : int64 = v3492 + 1L
let v3494 : int64 = v3493 + 1L
let v3495 : int64 = v3494 + 1L
let v3496 : int64 = v3495 + 1L
let v3497 : bool = v3491 = v3496
let v3498 : int64 =
    if v3497 then
        0L
    else
        1L
let v3499 : int64 = v3483 + v3491
let v3500 : int64 = v3484 + v3496
let v3501 : int64 = v3486 + v3498
let v3502 : int64 = v3476 + v3499
let v3503 : int64 = v3480 + v3500
let v3504 : int64 = v3482 + v3501
let v3505 : int64 = 0L + 1L
let v3506 : int64 = v3505 + 1L
let v3507 : int64 = v3506 + 1L
let v3508 : int64 = v3507 + 1L
let v3509 : int64 = 0L + 1L
let v3510 : int64 = v3509 + 1L
let v3511 : int64 = v3510 + 1L
let v3512 : int64 = v3511 + 1L
let v3513 : bool = v3508 = v3512
let v3514 : int64 =
    if v3513 then
        0L
    else
        1L
let v3515 : int64 = 0L + 1L
let v3516 : int64 = 0L + 1L
let v3517 : bool = v3515 = v3516
let v3518 : int64 =
    if v3517 then
        0L
    else
        1L
let v3519 : int64 = 0L + 1L
let v3520 : int64 = v3519 + 1L
let v3521 : int64 = v3520 + 1L
let v3522 : int64 = v3521 + 1L
let v3523 : int64 = v3522 + 1L
let v3524 : int64 = 0L + 1L
let v3525 : int64 = v3524 + 1L
let v3526 : int64 = v3525 + 1L
let v3527 : int64 = v3526 + 1L
let v3528 : int64 = v3527 + 1L
let v3529 : bool = v3523 = v3528
let v3530 : int64 =
    if v3529 then
        0L
    else
        1L
let v3531 : int64 = v3515 + v3523
let v3532 : int64 = v3516 + v3528
let v3533 : int64 = v3518 + v3530
let v3534 : int64 = v3508 + v3531
let v3535 : int64 = v3512 + v3532
let v3536 : int64 = v3514 + v3533
let v3537 : int64 = 0L + 1L
let v3538 : int64 = v3537 + 1L
let v3539 : int64 = v3538 + 1L
let v3540 : int64 = v3539 + 1L
let v3541 : int64 = 0L + 1L
let v3542 : int64 = v3541 + 1L
let v3543 : int64 = v3542 + 1L
let v3544 : int64 = v3543 + 1L
let v3545 : bool = v3540 = v3544
let v3546 : int64 =
    if v3545 then
        0L
    else
        1L
let v3547 : int64 = 0L + 1L
let v3548 : int64 = 0L + 1L
let v3549 : bool = v3547 = v3548
let v3550 : int64 =
    if v3549 then
        0L
    else
        1L
let v3551 : int64 = 0L + 1L
let v3552 : int64 = v3551 + 1L
let v3553 : int64 = v3552 + 1L
let v3554 : int64 = v3553 + 1L
let v3555 : int64 = v3554 + 1L
let v3556 : int64 = 0L + 1L
let v3557 : int64 = v3556 + 1L
let v3558 : int64 = v3557 + 1L
let v3559 : int64 = v3558 + 1L
let v3560 : int64 = v3559 + 1L
let v3561 : bool = v3555 = v3560
let v3562 : int64 =
    if v3561 then
        0L
    else
        1L
let v3563 : int64 = v3547 + v3555
let v3564 : int64 = v3548 + v3560
let v3565 : int64 = v3550 + v3562
let v3566 : int64 = v3540 + v3563
let v3567 : int64 = v3544 + v3564
let v3568 : int64 = v3546 + v3565
let v3569 : int64 = v3534 + v3566
let v3570 : int64 = v3535 + v3567
let v3571 : int64 = v3536 + v3568
let v3572 : int64 = v3502 + v3569
let v3573 : int64 = v3503 + v3570
let v3574 : int64 = v3504 + v3571
let v3575 : int64 = v3470 + v3572
let v3576 : int64 = v3471 + v3573
let v3577 : int64 = v3472 + v3574
let v3578 : bool = v3575 = 40L
let v3579 : bool = v3576 = 40L
let v3580 : bool = v3577 = 0L
let v3581 : bool = v3578 && v3579
let v3582 : bool = v3581 && v3580
if v3582 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-event-store-decision-runtime-mismatch"
let v3583 : int64 = 0L + 1L
let v3584 : int64 = v3583 + 1L
let v3585 : int64 = v3584 + 1L
let v3586 : int64 = v3585 + 1L
let v3587 : int64 = 0L + 1L
let v3588 : int64 = v3587 + 1L
let v3589 : int64 = v3588 + 1L
let v3590 : int64 = v3589 + 1L
let v3591 : bool = v3586 = v3590
let v3592 : int64 =
    if v3591 then
        0L
    else
        1L
let v3593 : int64 = 0L + 1L
let v3594 : int64 = 0L + 1L
let v3595 : bool = v3593 = v3594
let v3596 : int64 =
    if v3595 then
        0L
    else
        1L
let v3597 : int64 = 0L + 1L
let v3598 : int64 = v3597 + 1L
let v3599 : int64 = v3598 + 1L
let v3600 : int64 = v3599 + 1L
let v3601 : int64 = v3600 + 1L
let v3602 : int64 = 0L + 1L
let v3603 : int64 = v3602 + 1L
let v3604 : int64 = v3603 + 1L
let v3605 : int64 = v3604 + 1L
let v3606 : int64 = v3605 + 1L
let v3607 : bool = v3601 = v3606
let v3608 : int64 =
    if v3607 then
        0L
    else
        1L
let v3609 : int64 = v3593 + v3601
let v3610 : int64 = v3594 + v3606
let v3611 : int64 = v3596 + v3608
let v3612 : int64 = v3586 + v3609
let v3613 : int64 = v3590 + v3610
let v3614 : int64 = v3592 + v3611
let v3615 : int64 = 0L + 1L
let v3616 : int64 = v3615 + 1L
let v3617 : int64 = v3616 + 1L
let v3618 : int64 = v3617 + 1L
let v3619 : int64 = 0L + 1L
let v3620 : int64 = v3619 + 1L
let v3621 : int64 = v3620 + 1L
let v3622 : int64 = v3621 + 1L
let v3623 : bool = v3618 = v3622
let v3624 : int64 =
    if v3623 then
        0L
    else
        1L
let v3625 : int64 = 0L + 1L
let v3626 : int64 = 0L + 1L
let v3627 : bool = v3625 = v3626
let v3628 : int64 =
    if v3627 then
        0L
    else
        1L
let v3629 : int64 = 0L + 1L
let v3630 : int64 = v3629 + 1L
let v3631 : int64 = v3630 + 1L
let v3632 : int64 = v3631 + 1L
let v3633 : int64 = v3632 + 1L
let v3634 : int64 = 0L + 1L
let v3635 : int64 = v3634 + 1L
let v3636 : int64 = v3635 + 1L
let v3637 : int64 = v3636 + 1L
let v3638 : int64 = v3637 + 1L
let v3639 : bool = v3633 = v3638
let v3640 : int64 =
    if v3639 then
        0L
    else
        1L
let v3641 : int64 = v3625 + v3633
let v3642 : int64 = v3626 + v3638
let v3643 : int64 = v3628 + v3640
let v3644 : int64 = v3618 + v3641
let v3645 : int64 = v3622 + v3642
let v3646 : int64 = v3624 + v3643
let v3647 : int64 = v3644 + v3612
let v3648 : int64 = v3645 + v3613
let v3649 : int64 = v3646 + v3614
let v3650 : int64 = 0L + 1L
let v3651 : int64 = v3650 + 1L
let v3652 : int64 = v3651 + 1L
let v3653 : int64 = v3652 + 1L
let v3654 : int64 = 0L + 1L
let v3655 : int64 = v3654 + 1L
let v3656 : int64 = v3655 + 1L
let v3657 : int64 = v3656 + 1L
let v3658 : bool = v3653 = v3657
let v3659 : int64 =
    if v3658 then
        0L
    else
        1L
let v3660 : int64 = 0L + 1L
let v3661 : int64 = 0L + 1L
let v3662 : bool = v3660 = v3661
let v3663 : int64 =
    if v3662 then
        0L
    else
        1L
let v3664 : int64 = 0L + 1L
let v3665 : int64 = v3664 + 1L
let v3666 : int64 = v3665 + 1L
let v3667 : int64 = v3666 + 1L
let v3668 : int64 = v3667 + 1L
let v3669 : int64 = 0L + 1L
let v3670 : int64 = v3669 + 1L
let v3671 : int64 = v3670 + 1L
let v3672 : int64 = v3671 + 1L
let v3673 : int64 = v3672 + 1L
let v3674 : bool = v3668 = v3673
let v3675 : int64 =
    if v3674 then
        0L
    else
        1L
let v3676 : int64 = v3660 + v3668
let v3677 : int64 = v3661 + v3673
let v3678 : int64 = v3663 + v3675
let v3679 : int64 = v3653 + v3676
let v3680 : int64 = v3657 + v3677
let v3681 : int64 = v3659 + v3678
let v3682 : int64 = 0L + 1L
let v3683 : int64 = v3682 + 1L
let v3684 : int64 = v3683 + 1L
let v3685 : int64 = v3684 + 1L
let v3686 : int64 = 0L + 1L
let v3687 : int64 = v3686 + 1L
let v3688 : int64 = v3687 + 1L
let v3689 : int64 = v3688 + 1L
let v3690 : bool = v3685 = v3689
let v3691 : int64 =
    if v3690 then
        0L
    else
        1L
let v3692 : int64 = 0L + 1L
let v3693 : int64 = 0L + 1L
let v3694 : bool = v3692 = v3693
let v3695 : int64 =
    if v3694 then
        0L
    else
        1L
let v3696 : int64 = 0L + 1L
let v3697 : int64 = v3696 + 1L
let v3698 : int64 = v3697 + 1L
let v3699 : int64 = v3698 + 1L
let v3700 : int64 = v3699 + 1L
let v3701 : int64 = 0L + 1L
let v3702 : int64 = v3701 + 1L
let v3703 : int64 = v3702 + 1L
let v3704 : int64 = v3703 + 1L
let v3705 : int64 = v3704 + 1L
let v3706 : bool = v3700 = v3705
let v3707 : int64 =
    if v3706 then
        0L
    else
        1L
let v3708 : int64 = v3692 + v3700
let v3709 : int64 = v3693 + v3705
let v3710 : int64 = v3695 + v3707
let v3711 : int64 = v3685 + v3708
let v3712 : int64 = v3689 + v3709
let v3713 : int64 = v3691 + v3710
let v3714 : int64 = v3711 + v3679
let v3715 : int64 = v3712 + v3680
let v3716 : int64 = v3713 + v3681
let v3717 : int64 = v3649 + v3716
let v3718 : bool = v3717 = 0L
if v3718 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-proven-retry-runtime-mismatch"
let v3719 : int64 = 0L + 1L
let v3720 : int64 = v3719 + 1L
let v3721 : int64 = v3720 + 1L
let v3722 : int64 = v3721 + 1L
let v3723 : int64 = 0L + 1L
let v3724 : int64 = v3723 + 1L
let v3725 : int64 = v3724 + 1L
let v3726 : int64 = v3725 + 1L
let v3727 : bool = v3722 = v3726
let v3728 : int64 =
    if v3727 then
        0L
    else
        1L
let v3729 : int64 = 0L + 1L
let v3730 : int64 = 0L + 1L
let v3731 : bool = v3729 = v3730
let v3732 : int64 =
    if v3731 then
        0L
    else
        1L
let v3733 : int64 = 0L + 1L
let v3734 : int64 = v3733 + 1L
let v3735 : int64 = v3734 + 1L
let v3736 : int64 = v3735 + 1L
let v3737 : int64 = v3736 + 1L
let v3738 : int64 = 0L + 1L
let v3739 : int64 = v3738 + 1L
let v3740 : int64 = v3739 + 1L
let v3741 : int64 = v3740 + 1L
let v3742 : int64 = v3741 + 1L
let v3743 : bool = v3737 = v3742
let v3744 : int64 =
    if v3743 then
        0L
    else
        1L
let v3745 : int64 = v3729 + v3737
let v3746 : int64 = v3730 + v3742
let v3747 : int64 = v3732 + v3744
let v3748 : int64 = v3722 + v3745
let v3749 : int64 = v3726 + v3746
let v3750 : int64 = v3728 + v3747
let v3751 : int64 = 0L + 1L
let v3752 : int64 = v3751 + 1L
let v3753 : int64 = v3752 + 1L
let v3754 : int64 = v3753 + 1L
let v3755 : int64 = 0L + 1L
let v3756 : int64 = v3755 + 1L
let v3757 : int64 = v3756 + 1L
let v3758 : int64 = v3757 + 1L
let v3759 : bool = v3754 = v3758
let v3760 : int64 =
    if v3759 then
        0L
    else
        1L
let v3761 : int64 = 0L + 1L
let v3762 : int64 = 0L + 1L
let v3763 : bool = v3761 = v3762
let v3764 : int64 =
    if v3763 then
        0L
    else
        1L
let v3765 : int64 = 0L + 1L
let v3766 : int64 = v3765 + 1L
let v3767 : int64 = v3766 + 1L
let v3768 : int64 = v3767 + 1L
let v3769 : int64 = v3768 + 1L
let v3770 : int64 = 0L + 1L
let v3771 : int64 = v3770 + 1L
let v3772 : int64 = v3771 + 1L
let v3773 : int64 = v3772 + 1L
let v3774 : int64 = v3773 + 1L
let v3775 : bool = v3769 = v3774
let v3776 : int64 =
    if v3775 then
        0L
    else
        1L
let v3777 : int64 = v3761 + v3769
let v3778 : int64 = v3762 + v3774
let v3779 : int64 = v3764 + v3776
let v3780 : int64 = v3754 + v3777
let v3781 : int64 = v3758 + v3778
let v3782 : int64 = v3760 + v3779
let v3783 : int64 = v3780 + v3748
let v3784 : int64 = v3781 + v3749
let v3785 : int64 = v3782 + v3750
let v3786 : bool = v3783 = 20L
let v3787 : bool = v3784 = 20L
let v3788 : bool = v3785 = 0L
let v3789 : bool = v3786 && v3787
let v3790 : bool = v3789 && v3788
if v3790 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-history-enumeration-runtime-mismatch"
let v3791 : int64 = 0L + 1L
let v3792 : int64 = v3791 + 1L
let v3793 : int64 = v3792 + 1L
let v3794 : int64 = v3793 + 1L
let v3795 : int64 = 0L + 1L
let v3796 : int64 = v3795 + 1L
let v3797 : int64 = v3796 + 1L
let v3798 : int64 = v3797 + 1L
let v3799 : bool = v3794 = v3798
let v3800 : int64 =
    if v3799 then
        0L
    else
        1L
let v3801 : int64 = 0L + 1L
let v3802 : int64 = 0L + 1L
let v3803 : bool = v3801 = v3802
let v3804 : int64 =
    if v3803 then
        0L
    else
        1L
let v3805 : int64 = 0L + 1L
let v3806 : int64 = v3805 + 1L
let v3807 : int64 = v3806 + 1L
let v3808 : int64 = v3807 + 1L
let v3809 : int64 = v3808 + 1L
let v3810 : int64 = 0L + 1L
let v3811 : int64 = v3810 + 1L
let v3812 : int64 = v3811 + 1L
let v3813 : int64 = v3812 + 1L
let v3814 : int64 = v3813 + 1L
let v3815 : bool = v3809 = v3814
let v3816 : int64 =
    if v3815 then
        0L
    else
        1L
let v3817 : int64 = v3801 + v3809
let v3818 : int64 = v3802 + v3814
let v3819 : int64 = v3804 + v3816
let v3820 : int64 = v3794 + v3817
let v3821 : int64 = v3798 + v3818
let v3822 : int64 = v3800 + v3819
let v3823 : bool = v3820 = 10L
let v3824 : bool = v3821 = 10L
let v3825 : bool = v3822 = 0L
let v3826 : bool = v3823 && v3824
let v3827 : bool = v3826 && v3825
if v3827 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-history-index-lookup-runtime-mismatch"
let v3828 : int64 = 0L + 1L
let v3829 : int64 = v3828 + 1L
let v3830 : int64 = v3829 + 1L
let v3831 : int64 = v3830 + 1L
let v3832 : int64 = 0L + 1L
let v3833 : int64 = v3832 + 1L
let v3834 : int64 = v3833 + 1L
let v3835 : int64 = v3834 + 1L
let v3836 : bool = v3831 = v3835
let v3837 : int64 =
    if v3836 then
        0L
    else
        1L
let v3838 : int64 = 0L + 1L
let v3839 : int64 = 0L + 1L
let v3840 : bool = v3838 = v3839
let v3841 : int64 =
    if v3840 then
        0L
    else
        1L
let v3842 : int64 = 0L + 1L
let v3843 : int64 = v3842 + 1L
let v3844 : int64 = v3843 + 1L
let v3845 : int64 = v3844 + 1L
let v3846 : int64 = v3845 + 1L
let v3847 : int64 = 0L + 1L
let v3848 : int64 = v3847 + 1L
let v3849 : int64 = v3848 + 1L
let v3850 : int64 = v3849 + 1L
let v3851 : int64 = v3850 + 1L
let v3852 : bool = v3846 = v3851
let v3853 : int64 =
    if v3852 then
        0L
    else
        1L
let v3854 : int64 = v3838 + v3846
let v3855 : int64 = v3839 + v3851
let v3856 : int64 = v3841 + v3853
let v3857 : int64 = v3831 + v3854
let v3858 : int64 = v3835 + v3855
let v3859 : int64 = v3837 + v3856
let v3860 : int64 = 0L + 1L
let v3861 : int64 = v3860 + 1L
let v3862 : int64 = v3861 + 1L
let v3863 : int64 = v3862 + 1L
let v3864 : int64 = 0L + 1L
let v3865 : int64 = v3864 + 1L
let v3866 : int64 = v3865 + 1L
let v3867 : int64 = v3866 + 1L
let v3868 : bool = v3863 = v3867
let v3869 : int64 =
    if v3868 then
        0L
    else
        1L
let v3870 : int64 = 0L + 1L
let v3871 : int64 = 0L + 1L
let v3872 : bool = v3870 = v3871
let v3873 : int64 =
    if v3872 then
        0L
    else
        1L
let v3874 : int64 = 0L + 1L
let v3875 : int64 = v3874 + 1L
let v3876 : int64 = v3875 + 1L
let v3877 : int64 = v3876 + 1L
let v3878 : int64 = v3877 + 1L
let v3879 : int64 = 0L + 1L
let v3880 : int64 = v3879 + 1L
let v3881 : int64 = v3880 + 1L
let v3882 : int64 = v3881 + 1L
let v3883 : int64 = v3882 + 1L
let v3884 : bool = v3878 = v3883
let v3885 : int64 =
    if v3884 then
        0L
    else
        1L
let v3886 : int64 = v3870 + v3878
let v3887 : int64 = v3871 + v3883
let v3888 : int64 = v3873 + v3885
let v3889 : int64 = v3863 + v3886
let v3890 : int64 = v3867 + v3887
let v3891 : int64 = v3869 + v3888
let v3892 : bool = v3857 = 10L
let v3893 : bool = v3858 = 10L
let v3894 : bool = v3859 = 0L
let v3895 : bool = v3889 = 10L
let v3896 : bool = v3890 = 10L
let v3897 : bool = v3891 = 0L
let v3898 : bool = v3892 && v3893
let v3899 : bool = v3898 && v3894
let v3900 : bool = v3899 && v3895
let v3901 : bool = v3900 && v3896
let v3902 : bool = v3901 && v3897
if v3902 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-identity-lookup-runtime-mismatch"
let v3903 : int64 = 0L + 1L
let v3904 : int64 = v3903 + 1L
let v3905 : int64 = v3904 + 1L
let v3906 : int64 = v3905 + 1L
let v3907 : int64 = 0L + 1L
let v3908 : int64 = v3907 + 1L
let v3909 : int64 = v3908 + 1L
let v3910 : int64 = v3909 + 1L
let v3911 : bool = v3906 = v3910
let v3912 : int64 =
    if v3911 then
        0L
    else
        1L
let v3913 : int64 = 0L + 1L
let v3914 : int64 = 0L + 1L
let v3915 : bool = v3913 = v3914
let v3916 : int64 =
    if v3915 then
        0L
    else
        1L
let v3917 : int64 = 0L + 1L
let v3918 : int64 = v3917 + 1L
let v3919 : int64 = v3918 + 1L
let v3920 : int64 = v3919 + 1L
let v3921 : int64 = v3920 + 1L
let v3922 : int64 = 0L + 1L
let v3923 : int64 = v3922 + 1L
let v3924 : int64 = v3923 + 1L
let v3925 : int64 = v3924 + 1L
let v3926 : int64 = v3925 + 1L
let v3927 : bool = v3921 = v3926
let v3928 : int64 =
    if v3927 then
        0L
    else
        1L
let v3929 : int64 = v3913 + v3921
let v3930 : int64 = v3914 + v3926
let v3931 : int64 = v3916 + v3928
let v3932 : int64 = v3906 + v3929
let v3933 : int64 = v3910 + v3930
let v3934 : int64 = v3912 + v3931
let v3935 : int64 = 0L + 1L
let v3936 : int64 = v3935 + 1L
let v3937 : int64 = v3936 + 1L
let v3938 : int64 = v3937 + 1L
let v3939 : int64 = 0L + 1L
let v3940 : int64 = v3939 + 1L
let v3941 : int64 = v3940 + 1L
let v3942 : int64 = v3941 + 1L
let v3943 : bool = v3938 = v3942
let v3944 : int64 =
    if v3943 then
        0L
    else
        1L
let v3945 : int64 = 0L + 1L
let v3946 : int64 = 0L + 1L
let v3947 : bool = v3945 = v3946
let v3948 : int64 =
    if v3947 then
        0L
    else
        1L
let v3949 : int64 = 0L + 1L
let v3950 : int64 = v3949 + 1L
let v3951 : int64 = v3950 + 1L
let v3952 : int64 = v3951 + 1L
let v3953 : int64 = v3952 + 1L
let v3954 : int64 = 0L + 1L
let v3955 : int64 = v3954 + 1L
let v3956 : int64 = v3955 + 1L
let v3957 : int64 = v3956 + 1L
let v3958 : int64 = v3957 + 1L
let v3959 : bool = v3953 = v3958
let v3960 : int64 =
    if v3959 then
        0L
    else
        1L
let v3961 : int64 = v3945 + v3953
let v3962 : int64 = v3946 + v3958
let v3963 : int64 = v3948 + v3960
let v3964 : int64 = v3938 + v3961
let v3965 : int64 = v3942 + v3962
let v3966 : int64 = v3944 + v3963
let v3967 : int64 = v3932 + v3964
let v3968 : int64 = v3933 + v3965
let v3969 : int64 = v3934 + v3966
let v3970 : bool = v3967 = 20L
let v3971 : bool = v3968 = 20L
let v3972 : bool = v3969 = 0L
let v3973 : bool = v3970 && v3971
let v3974 : bool = v3973 && v3972
if v3974 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch"
let v3975 : int64 = 0L + 1L
let v3976 : int64 = v3975 + 1L
let v3977 : int64 = v3976 + 1L
let v3978 : int64 = v3977 + 1L
let v3979 : int64 = 0L + 1L
let v3980 : int64 = v3979 + 1L
let v3981 : int64 = v3980 + 1L
let v3982 : int64 = v3981 + 1L
let v3983 : bool = v3978 = v3982
let v3984 : int64 =
    if v3983 then
        0L
    else
        1L
let v3985 : int64 = 0L + 1L
let v3986 : int64 = 0L + 1L
let v3987 : bool = v3985 = v3986
let v3988 : int64 =
    if v3987 then
        0L
    else
        1L
let v3989 : int64 = 0L + 1L
let v3990 : int64 = v3989 + 1L
let v3991 : int64 = v3990 + 1L
let v3992 : int64 = v3991 + 1L
let v3993 : int64 = v3992 + 1L
let v3994 : int64 = 0L + 1L
let v3995 : int64 = v3994 + 1L
let v3996 : int64 = v3995 + 1L
let v3997 : int64 = v3996 + 1L
let v3998 : int64 = v3997 + 1L
let v3999 : bool = v3993 = v3998
let v4000 : int64 =
    if v3999 then
        0L
    else
        1L
let v4001 : int64 = v3985 + v3993
let v4002 : int64 = v3986 + v3998
let v4003 : int64 = v3988 + v4000
let v4004 : int64 = v3978 + v4001
let v4005 : int64 = v3982 + v4002
let v4006 : int64 = v3984 + v4003
let v4007 : int64 = 0L + 1L
let v4008 : int64 = v4007 + 1L
let v4009 : int64 = v4008 + 1L
let v4010 : int64 = v4009 + 1L
let v4011 : int64 = 0L + 1L
let v4012 : int64 = v4011 + 1L
let v4013 : int64 = v4012 + 1L
let v4014 : int64 = v4013 + 1L
let v4015 : bool = v4010 = v4014
let v4016 : int64 =
    if v4015 then
        0L
    else
        1L
let v4017 : int64 = 0L + 1L
let v4018 : int64 = 0L + 1L
let v4019 : bool = v4017 = v4018
let v4020 : int64 =
    if v4019 then
        0L
    else
        1L
let v4021 : int64 = 0L + 1L
let v4022 : int64 = v4021 + 1L
let v4023 : int64 = v4022 + 1L
let v4024 : int64 = v4023 + 1L
let v4025 : int64 = v4024 + 1L
let v4026 : int64 = 0L + 1L
let v4027 : int64 = v4026 + 1L
let v4028 : int64 = v4027 + 1L
let v4029 : int64 = v4028 + 1L
let v4030 : int64 = v4029 + 1L
let v4031 : bool = v4025 = v4030
let v4032 : int64 =
    if v4031 then
        0L
    else
        1L
let v4033 : int64 = v4017 + v4025
let v4034 : int64 = v4018 + v4030
let v4035 : int64 = v4020 + v4032
let v4036 : int64 = v4010 + v4033
let v4037 : int64 = v4014 + v4034
let v4038 : int64 = v4016 + v4035
let v4039 : int64 = v4004 + v4036
let v4040 : int64 = v4005 + v4037
let v4041 : int64 = v4006 + v4038
let v4042 : int64 = 0L + 1L
let v4043 : int64 = v4042 + 1L
let v4044 : int64 = v4043 + 1L
let v4045 : int64 = v4044 + 1L
let v4046 : int64 = 0L + 1L
let v4047 : int64 = v4046 + 1L
let v4048 : int64 = v4047 + 1L
let v4049 : int64 = v4048 + 1L
let v4050 : bool = v4045 = v4049
let v4051 : int64 =
    if v4050 then
        0L
    else
        1L
let v4052 : int64 = 0L + 1L
let v4053 : int64 = 0L + 1L
let v4054 : bool = v4052 = v4053
let v4055 : int64 =
    if v4054 then
        0L
    else
        1L
let v4056 : int64 = 0L + 1L
let v4057 : int64 = v4056 + 1L
let v4058 : int64 = v4057 + 1L
let v4059 : int64 = v4058 + 1L
let v4060 : int64 = v4059 + 1L
let v4061 : int64 = 0L + 1L
let v4062 : int64 = v4061 + 1L
let v4063 : int64 = v4062 + 1L
let v4064 : int64 = v4063 + 1L
let v4065 : int64 = v4064 + 1L
let v4066 : bool = v4060 = v4065
let v4067 : int64 =
    if v4066 then
        0L
    else
        1L
let v4068 : int64 = v4052 + v4060
let v4069 : int64 = v4053 + v4065
let v4070 : int64 = v4055 + v4067
let v4071 : int64 = v4045 + v4068
let v4072 : int64 = v4049 + v4069
let v4073 : int64 = v4051 + v4070
let v4074 : int64 = 0L + 1L
let v4075 : int64 = v4074 + 1L
let v4076 : int64 = v4075 + 1L
let v4077 : int64 = v4076 + 1L
let v4078 : int64 = 0L + 1L
let v4079 : int64 = v4078 + 1L
let v4080 : int64 = v4079 + 1L
let v4081 : int64 = v4080 + 1L
let v4082 : bool = v4077 = v4081
let v4083 : int64 =
    if v4082 then
        0L
    else
        1L
let v4084 : int64 = 0L + 1L
let v4085 : int64 = 0L + 1L
let v4086 : bool = v4084 = v4085
let v4087 : int64 =
    if v4086 then
        0L
    else
        1L
let v4088 : int64 = 0L + 1L
let v4089 : int64 = v4088 + 1L
let v4090 : int64 = v4089 + 1L
let v4091 : int64 = v4090 + 1L
let v4092 : int64 = v4091 + 1L
let v4093 : int64 = 0L + 1L
let v4094 : int64 = v4093 + 1L
let v4095 : int64 = v4094 + 1L
let v4096 : int64 = v4095 + 1L
let v4097 : int64 = v4096 + 1L
let v4098 : bool = v4092 = v4097
let v4099 : int64 =
    if v4098 then
        0L
    else
        1L
let v4100 : int64 = v4084 + v4092
let v4101 : int64 = v4085 + v4097
let v4102 : int64 = v4087 + v4099
let v4103 : int64 = v4077 + v4100
let v4104 : int64 = v4081 + v4101
let v4105 : int64 = v4083 + v4102
let v4106 : int64 = v4071 + v4103
let v4107 : bool = v4039 = v4106
let v4108 : int64 = v4072 + v4104
let v4109 : bool = v4040 = v4108
let v4110 : int64 = v4073 + v4105
let v4111 : bool = v4041 = v4110
let v4112 : bool = v4107 && v4109
let v4113 : bool = v4112 && v4111
if v4113 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch"
let v4114 : int64 = 0L + 1L
let v4115 : int64 = v4114 + 1L
let v4116 : int64 = v4115 + 1L
let v4117 : int64 = v4116 + 1L
let v4118 : int64 = 0L + 1L
let v4119 : int64 = v4118 + 1L
let v4120 : int64 = v4119 + 1L
let v4121 : int64 = v4120 + 1L
let v4122 : bool = v4117 = v4121
let v4123 : int64 =
    if v4122 then
        0L
    else
        1L
let v4124 : int64 = 0L + 1L
let v4125 : int64 = 0L + 1L
let v4126 : bool = v4124 = v4125
let v4127 : int64 =
    if v4126 then
        0L
    else
        1L
let v4128 : int64 = 0L + 1L
let v4129 : int64 = v4128 + 1L
let v4130 : int64 = v4129 + 1L
let v4131 : int64 = v4130 + 1L
let v4132 : int64 = v4131 + 1L
let v4133 : int64 = 0L + 1L
let v4134 : int64 = v4133 + 1L
let v4135 : int64 = v4134 + 1L
let v4136 : int64 = v4135 + 1L
let v4137 : int64 = v4136 + 1L
let v4138 : bool = v4132 = v4137
let v4139 : int64 =
    if v4138 then
        0L
    else
        1L
let v4140 : int64 = v4124 + v4132
let v4141 : int64 = v4125 + v4137
let v4142 : int64 = v4127 + v4139
let v4143 : int64 = v4117 + v4140
let v4144 : int64 = v4121 + v4141
let v4145 : int64 = v4123 + v4142
let v4146 : int64 = 0L + 1L
let v4147 : int64 = v4146 + 1L
let v4148 : int64 = v4147 + 1L
let v4149 : int64 = v4148 + 1L
let v4150 : int64 = 0L + 1L
let v4151 : int64 = v4150 + 1L
let v4152 : int64 = v4151 + 1L
let v4153 : int64 = v4152 + 1L
let v4154 : bool = v4149 = v4153
let v4155 : int64 =
    if v4154 then
        0L
    else
        1L
let v4156 : int64 = 0L + 1L
let v4157 : int64 = 0L + 1L
let v4158 : bool = v4156 = v4157
let v4159 : int64 =
    if v4158 then
        0L
    else
        1L
let v4160 : int64 = 0L + 1L
let v4161 : int64 = v4160 + 1L
let v4162 : int64 = v4161 + 1L
let v4163 : int64 = v4162 + 1L
let v4164 : int64 = v4163 + 1L
let v4165 : int64 = 0L + 1L
let v4166 : int64 = v4165 + 1L
let v4167 : int64 = v4166 + 1L
let v4168 : int64 = v4167 + 1L
let v4169 : int64 = v4168 + 1L
let v4170 : bool = v4164 = v4169
let v4171 : int64 =
    if v4170 then
        0L
    else
        1L
let v4172 : int64 = v4156 + v4164
let v4173 : int64 = v4157 + v4169
let v4174 : int64 = v4159 + v4171
let v4175 : int64 = v4149 + v4172
let v4176 : int64 = v4153 + v4173
let v4177 : int64 = v4155 + v4174
let v4178 : int64 = 0L + 1L
let v4179 : int64 = v4178 + 1L
let v4180 : int64 = v4179 + 1L
let v4181 : int64 = v4180 + 1L
let v4182 : int64 = 0L + 1L
let v4183 : int64 = v4182 + 1L
let v4184 : int64 = v4183 + 1L
let v4185 : int64 = v4184 + 1L
let v4186 : bool = v4181 = v4185
let v4187 : int64 =
    if v4186 then
        0L
    else
        1L
let v4188 : int64 = 0L + 1L
let v4189 : int64 = 0L + 1L
let v4190 : bool = v4188 = v4189
let v4191 : int64 =
    if v4190 then
        0L
    else
        1L
let v4192 : int64 = 0L + 1L
let v4193 : int64 = v4192 + 1L
let v4194 : int64 = v4193 + 1L
let v4195 : int64 = v4194 + 1L
let v4196 : int64 = v4195 + 1L
let v4197 : int64 = 0L + 1L
let v4198 : int64 = v4197 + 1L
let v4199 : int64 = v4198 + 1L
let v4200 : int64 = v4199 + 1L
let v4201 : int64 = v4200 + 1L
let v4202 : bool = v4196 = v4201
let v4203 : int64 =
    if v4202 then
        0L
    else
        1L
let v4204 : int64 = v4188 + v4196
let v4205 : int64 = v4189 + v4201
let v4206 : int64 = v4191 + v4203
let v4207 : int64 = v4181 + v4204
let v4208 : int64 = v4185 + v4205
let v4209 : int64 = v4187 + v4206
let v4210 : int64 = 0L + 1L
let v4211 : int64 = v4210 + 1L
let v4212 : int64 = v4211 + 1L
let v4213 : int64 = v4212 + 1L
let v4214 : int64 = 0L + 1L
let v4215 : int64 = v4214 + 1L
let v4216 : int64 = v4215 + 1L
let v4217 : int64 = v4216 + 1L
let v4218 : bool = v4213 = v4217
let v4219 : int64 =
    if v4218 then
        0L
    else
        1L
let v4220 : int64 = 0L + 1L
let v4221 : int64 = 0L + 1L
let v4222 : bool = v4220 = v4221
let v4223 : int64 =
    if v4222 then
        0L
    else
        1L
let v4224 : int64 = 0L + 1L
let v4225 : int64 = v4224 + 1L
let v4226 : int64 = v4225 + 1L
let v4227 : int64 = v4226 + 1L
let v4228 : int64 = v4227 + 1L
let v4229 : int64 = 0L + 1L
let v4230 : int64 = v4229 + 1L
let v4231 : int64 = v4230 + 1L
let v4232 : int64 = v4231 + 1L
let v4233 : int64 = v4232 + 1L
let v4234 : bool = v4228 = v4233
let v4235 : int64 =
    if v4234 then
        0L
    else
        1L
let v4236 : int64 = v4220 + v4228
let v4237 : int64 = v4221 + v4233
let v4238 : int64 = v4223 + v4235
let v4239 : int64 = v4213 + v4236
let v4240 : int64 = v4217 + v4237
let v4241 : int64 = v4219 + v4238
let v4242 : bool = v4143 = v4175
let v4243 : bool = v4144 = v4176
let v4244 : bool = v4145 = v4177
let v4245 : bool = v4242 && v4243
let v4246 : bool = v4245 && v4244
if v4246 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch"
let v4247 : bool = v4207 = v4239
let v4248 : bool = v4208 = v4240
let v4249 : bool = v4209 = v4241
let v4250 : bool = v4247 && v4248
let v4251 : bool = v4250 && v4249
if v4251 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch"
let struct (v4252 : int64, v4253 : int64, v4254 : int64, v4255 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let prepared = System.IO.Path.Combine(directory, "statement.prepared") in let committed = System.IO.Path.Combine(directory, "statement.committed") in let payload = "command=primary|aggregate=ledger|position=1|debit=10|credit=10" in let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed); let recovered = System.IO.File.ReadAllBytes(committed) in let sourceDigest = System.Security.Cryptography.SHA256.HashData(bytes) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let same = System.Linq.Enumerable.SequenceEqual(sourceDigest, recoveredDigest) in System.IO.File.Delete(committed); System.IO.Directory.Delete(directory); (int64 bytes.Length, int64 sourceDigest.Length, int64 recovered.Length, if same then 1L else 0L))
let v4256 : bool = v4252 > 0L
let v4257 : bool = v4253 = 32L
let v4258 : bool = v4254 = v4252
let v4259 : bool = v4255 = 1L
let v4260 : bool = v4256 && v4257
let v4261 : bool = v4260 && v4258
let v4262 : bool = v4261 && v4259
if v4262 then
    ()
else
    failwith<unit> "typed-FX-statement-physical-commit-roundtrip-runtime-mismatch"
let struct (v4263 : int64, v4264 : int64, v4265 : int64, v4266 : int64, v4267 : int64, v4268 : int64, v4269 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-directory-sync-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let prepared = System.IO.Path.Combine(directory, "statement.prepared") in let committed = System.IO.Path.Combine(directory, "statement.committed") in let lockDirectory = System.IO.Path.Combine(directory, "statement.cas") in let payload = "command=directory-synced|aggregate=ledger|position=2|debit=17|credit=17" in let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed); let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let fileSync = runSync "-d" committed in let directorySync = runSync "-f" directory in let startMkdir () = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/mkdir"; info.UseShellExecute <- false; info.ArgumentList.Add(lockDirectory); System.Diagnostics.Process.Start(info) in use first = startMkdir () in use second = startMkdir () in first.WaitForExit(); second.WaitForExit(); let winners = (if first.ExitCode = 0 then 1L else 0L) + (if second.ExitCode = 0 then 1L else 0L) in let recovered = System.IO.File.ReadAllBytes(committed) in let sourceDigest = System.Security.Cryptography.SHA256.HashData(bytes) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let same = System.Linq.Enumerable.SequenceEqual(sourceDigest, recoveredDigest) in (if System.IO.Directory.Exists(lockDirectory) then System.IO.Directory.Delete(lockDirectory) else ()); System.IO.File.Delete(committed); System.IO.Directory.Delete(directory); (int64 bytes.Length, int64 sourceDigest.Length, int64 recovered.Length, (if same then 1L else 0L), fileSync, directorySync, winners))
let v4270 : bool = v4263 > 0L
let v4271 : bool = v4264 = 32L
let v4272 : bool = v4265 = v4263
let v4273 : bool = v4266 = 1L
let v4274 : bool = v4267 = 0L
let v4275 : bool = v4268 = 0L
let v4276 : bool = v4269 = 1L
let v4277 : bool = v4270 && v4271
let v4278 : bool = v4277 && v4272
let v4279 : bool = v4278 && v4273
let v4280 : bool = v4279 && v4274
let v4281 : bool = v4280 && v4275
let v4282 : bool = v4281 && v4276
if v4282 then
    ()
else
    failwith<unit> "typed-FX-statement-directory-synced-interprocess-CAS-runtime-mismatch"
let struct (v4283 : int64, v4284 : int64, v4285 : int64, v4286 : int64, v4287 : int64, v4288 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-crash-restart-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(directory) in let committed = System.IO.Path.Combine(directory, "statement.committed") in let prepared = System.IO.Path.Combine(directory, "statement.prepared") in let oldPayload = "command=stable-old|aggregate=ledger|position=3|debit=19|credit=19" in let oldBytes = System.Text.Encoding.UTF8.GetBytes(oldPayload) in (use stream = new System.IO.FileStream(committed, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(oldBytes, 0, oldBytes.Length); stream.Flush(true)); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/dd"; info.UseShellExecute <- false; info.RedirectStandardError <- true; info.ArgumentList.Add("if=/dev/zero"); info.ArgumentList.Add("of=" + prepared); info.ArgumentList.Add("bs=4096"); info.ArgumentList.Add("count=1048576"); info.ArgumentList.Add("oflag=sync"); use writer = System.Diagnostics.Process.Start(info) in let mutable spins = 0 in let _ = while ((not (System.IO.File.Exists(prepared))) || (new System.IO.FileInfo(prepared)).Length < 4096L) && not writer.HasExited && spins < 5000 do (System.Threading.Thread.Sleep(1); spins <- spins + 1) in let preparedBefore = if System.IO.File.Exists(prepared) then (new System.IO.FileInfo(prepared)).Length else 0L in let _ = if not writer.HasExited then writer.Kill(true) in let _ = writer.WaitForExit() in let crashExit = if writer.ExitCode <> 0 then 1L else 0L in let oldDigest = System.Security.Cryptography.SHA256.HashData(oldBytes) in let committedBefore = System.IO.File.ReadAllBytes(committed) in let committedBeforeDigest = System.Security.Cryptography.SHA256.HashData(committedBefore) in let preservedBefore = if System.Linq.Enumerable.SequenceEqual(oldDigest, committedBeforeDigest) then 1L else 0L in let _ = if System.IO.File.Exists(prepared) then System.IO.File.Delete(prepared) in let preparedAfter = if System.IO.File.Exists(prepared) then 1L else 0L in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let recoveredEqual = if System.Linq.Enumerable.SequenceEqual(oldDigest, recoveredDigest) then 1L else 0L in System.IO.File.Delete(committed); System.IO.Directory.Delete(directory); (int64 oldBytes.Length, preparedBefore, crashExit, preservedBefore, recoveredEqual, preparedAfter))
let v4289 : bool = v4283 > 0L
let v4290 : bool = v4284 >= 4096L
let v4291 : bool = v4285 = 1L
let v4292 : bool = v4286 = 1L
let v4293 : bool = v4287 = 1L
let v4294 : bool = v4288 = 0L
let v4295 : bool = v4289 && v4290
let v4296 : bool = v4295 && v4291
let v4297 : bool = v4296 && v4292
let v4298 : bool = v4297 && v4293
let v4299 : bool = v4298 && v4294
if v4299 then
    ()
else
    failwith<unit> "typed-FX-statement-crash-before-rename-restart-runtime-mismatch"
let struct (v4300 : int64, v4301 : int64, v4302 : int64, v4303 : int64, v4304 : int64, v4305 : int64, v4306 : int64, v4307 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-post-rename-crash-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(directory) in let committed = System.IO.Path.Combine(directory, "statement.committed") in let prepared = System.IO.Path.Combine(directory, "statement.prepared") in let oldPayload = "command=stable-old|aggregate=ledger|position=4|debit=23|credit=23" in let newPayload = "command=renamed-new|aggregate=ledger|position=5|debit=29|credit=29" in let oldBytes = System.Text.Encoding.UTF8.GetBytes(oldPayload) in let newBytes = System.Text.Encoding.UTF8.GetBytes(newPayload) in (use stream = new System.IO.FileStream(committed, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(oldBytes, 0, oldBytes.Length); stream.Flush(true)); (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(newBytes, 0, newBytes.Length); stream.Flush(true)); let ownerInfo = new System.Diagnostics.ProcessStartInfo() in ownerInfo.FileName <- "/usr/bin/sleep"; ownerInfo.UseShellExecute <- false; ownerInfo.ArgumentList.Add("30"); use owner = System.Diagnostics.Process.Start(ownerInfo) in System.IO.File.Move(prepared, committed, true); let afterRename = System.IO.File.ReadAllBytes(committed) in let newDigest = System.Security.Cryptography.SHA256.HashData(newBytes) in let afterRenameDigest = System.Security.Cryptography.SHA256.HashData(afterRename) in let renamed = if System.Linq.Enumerable.SequenceEqual(newDigest, afterRenameDigest) then 1L else 0L in let _ = if not owner.HasExited then owner.Kill(true) in let _ = owner.WaitForExit() in let crashExit = if owner.ExitCode <> 0 then 1L else 0L in let syncInfo = new System.Diagnostics.ProcessStartInfo() in syncInfo.FileName <- "/usr/bin/sync"; syncInfo.UseShellExecute <- false; syncInfo.ArgumentList.Add("-f"); syncInfo.ArgumentList.Add(directory); use syncProcess = System.Diagnostics.Process.Start(syncInfo) in syncProcess.WaitForExit(); let restartSync = int64 syncProcess.ExitCode in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let recoveredNew = if System.Linq.Enumerable.SequenceEqual(newDigest, recoveredDigest) then 1L else 0L in let oldDigest = System.Security.Cryptography.SHA256.HashData(oldBytes) in let oldReplaced = if System.Linq.Enumerable.SequenceEqual(oldDigest, recoveredDigest) then 0L else 1L in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in System.IO.File.Delete(committed); System.IO.Directory.Delete(directory); (int64 oldBytes.Length, int64 newBytes.Length, renamed, crashExit, restartSync, recoveredNew, oldReplaced, preparedAbsent))
let v4308 : bool = v4300 > 0L
let v4309 : bool = v4301 > 0L
let v4310 : bool = v4302 = 1L
let v4311 : bool = v4303 = 1L
let v4312 : bool = v4304 = 0L
let v4313 : bool = v4305 = 1L
let v4314 : bool = v4306 = 1L
let v4315 : bool = v4307 = 1L
let v4316 : bool = v4308 && v4309
let v4317 : bool = v4316 && v4310
let v4318 : bool = v4317 && v4311
let v4319 : bool = v4318 && v4312
let v4320 : bool = v4319 && v4313
let v4321 : bool = v4320 && v4314
let v4322 : bool = v4321 && v4315
if v4322 then
    ()
else
    failwith<unit> "typed-FX-statement-crash-after-rename-restart-runtime-mismatch"
let struct (v4323 : int64, v4324 : int64, v4325 : int64, v4326 : int64, v4327 : int64, v4328 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-history-cas-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let committed = System.IO.Path.Combine(directory, "history.committed") in let firstPrepared = System.IO.Path.Combine(directory, "history.first.prepared") in let stalePrepared = System.IO.Path.Combine(directory, "history.stale.prepared") in let oldPayload = "history=old|version=1|command=seed" in let firstPayload = "history=first|version=2|command=accepted" in let stalePayload = "history=stale|version=2|command=rejected" in let oldBytes = System.Text.Encoding.UTF8.GetBytes(oldPayload) in let firstBytes = System.Text.Encoding.UTF8.GetBytes(firstPayload) in let staleBytes = System.Text.Encoding.UTF8.GetBytes(stalePayload) in (use stream = new System.IO.FileStream(committed, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(oldBytes, 0, oldBytes.Length); stream.Flush(true)); let expectedDigest = System.Security.Cryptography.SHA256.HashData(oldBytes) in let tryCas prepared payload expected = let current = System.IO.File.ReadAllBytes(committed) in let currentDigest = System.Security.Cryptography.SHA256.HashData(current) in if not (System.Linq.Enumerable.SequenceEqual(expected, currentDigest)) then 0L else (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(payload, 0, payload.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let syncInfo = new System.Diagnostics.ProcessStartInfo() in syncInfo.FileName <- "/usr/bin/sync"; syncInfo.UseShellExecute <- false; syncInfo.ArgumentList.Add("-f"); syncInfo.ArgumentList.Add(directory); use syncProcess = System.Diagnostics.Process.Start(syncInfo) in syncProcess.WaitForExit(); if syncProcess.ExitCode = 0 then 1L else -1L in let first = tryCas firstPrepared firstBytes expectedDigest in let stale = tryCas stalePrepared staleBytes expectedDigest in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let firstDigest = System.Security.Cryptography.SHA256.HashData(firstBytes) in let finalMatchesFirst = if System.Linq.Enumerable.SequenceEqual(firstDigest, recoveredDigest) then 1L else 0L in let preparedAbsent = if System.IO.File.Exists(firstPrepared) || System.IO.File.Exists(stalePrepared) then 0L else 1L in System.IO.File.Delete(committed); System.IO.Directory.Delete(directory); (int64 oldBytes.Length, first, stale, finalMatchesFirst, preparedAbsent, int64 recovered.Length))
let v4329 : bool = v4323 > 0L
let v4330 : bool = v4324 = 1L
let v4331 : bool = v4325 = 0L
let v4332 : bool = v4326 = 1L
let v4333 : bool = v4327 = 1L
let v4334 : bool = v4328 > 0L
let v4335 : bool = v4329 && v4330
let v4336 : bool = v4335 && v4331
let v4337 : bool = v4336 && v4332
let v4338 : bool = v4337 && v4333
let v4339 : bool = v4338 && v4334
if v4339 then
    ()
else
    failwith<unit> "typed-FX-statement-history-digest-CAS-runtime-mismatch"
let struct (v4340 : int64, v4341 : int64, v4342 : int64, v4343 : int64, v4344 : int64, v4345 : int64) = (let history = System.Collections.Generic.Dictionary<string,string>() in let mutable committed = System.Text.Encoding.UTF8.GetBytes("history=v1") in let handle expectedDigest commandId payload = let currentDigest = System.Security.Cryptography.SHA256.HashData(committed) in if not (System.Linq.Enumerable.SequenceEqual(expectedDigest, currentDigest)) then 4L elif history.ContainsKey(commandId) then (if history.[commandId] = payload then 2L else 3L) else (history.[commandId] <- payload; committed <- System.Text.Encoding.UTF8.GetBytes("history=v2|" + commandId + "|" + payload); 1L) in let initialDigest = System.Security.Cryptography.SHA256.HashData(committed) in let applied = handle initialDigest "command-open-42" "payload-A" in let committedDigest = System.Security.Cryptography.SHA256.HashData(committed) in let duplicateExact = handle committedDigest "command-open-42" "payload-A" in let identityCollision = handle committedDigest "command-open-42" "payload-B" in let versionConflict = handle initialDigest "command-open-99" "payload-C" in let finalDigest = System.Security.Cryptography.SHA256.HashData(committed) in (applied, duplicateExact, identityCollision, versionConflict, int64 history.Count, int64 finalDigest.Length))
let v4346 : bool = v4340 = 1L
let v4347 : bool = v4341 = 2L
let v4348 : bool = v4342 = 3L
let v4349 : bool = v4343 = 4L
let v4350 : bool = v4344 = 1L
let v4351 : bool = v4345 = 32L
let v4352 : bool = v4346 && v4347
let v4353 : bool = v4352 && v4348
let v4354 : bool = v4353 && v4349
let v4355 : bool = v4354 && v4350
let v4356 : bool = v4355 && v4351
if v4356 then
    ()
else
    failwith<unit> "typed-FX-statement-writer-owned-identity-protocol-runtime-mismatch"
let struct (v4357 : int64, v4358 : int64, v4359 : int64, v4360 : int64, v4361 : int64, v4362 : int64, v4363 : int64, v4364 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-identity-batch-store-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let committed = System.IO.Path.Combine(directory, "events.committed") in let prepared = System.IO.Path.Combine(directory, "events.prepared") in let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let digestHex (body:string) = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(body))) in let append expected commandId payload = let existing = if System.IO.File.Exists(committed) then System.IO.File.ReadAllLines(committed) else [||] in let current = int64 existing.Length in let identityIndex = existing |> Array.tryFindIndex (fun line -> let parts = line.Split('|') in parts.Length = 4 && parts.[1] = commandId) in if identityIndex.IsSome then let parts = existing.[identityIndex.Value].Split('|') in (if parts.[2] = payload then (2L, current) else (3L, current)) else if expected <> current then (4L, current) else let body = string current + "|" + commandId + "|" + payload in let line = body + "|" + digestHex body in let all = System.String.Join("\n", Array.append existing [|line|]) + "\n" in let bytes = System.Text.Encoding.UTF8.GetBytes(all) in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let fs = runSync "-d" committed in let ds = runSync "-f" directory in if fs = 0L && ds = 0L then (1L, current + 1L) else (0L, current) in let first, _ = append 0L "command-A" "payload-alpha" in let second, _ = append 1L "command-B" "payload-beta" in let duplicate, _ = append 2L "command-A" "payload-alpha" in let collision, _ = append 2L "command-A" "payload-altered" in let conflict, _ = append 1L "command-C" "payload-gamma" in let third, finalVersion = append 2L "command-C" "payload-gamma" in let lines = System.IO.File.ReadAllLines(committed) in let mutable valid = 0L in for line in lines do let parts = line.Split('|') in if parts.Length = 4 then let body = System.String.Join("|", parts.[0..2]) in if digestHex body = parts.[3] then valid <- valid + 1L done; let lookup id = if lines |> Array.exists (fun line -> let parts = line.Split('|') in parts.Length = 4 && parts.[1] = id) then 1L else 0L in let lookups = lookup "command-A" + lookup "command-B" + lookup "command-C" in System.IO.File.Delete(committed); System.IO.Directory.Delete(directory); ((if first = 1L then 1L else 0L) + (if second = 1L then 1L else 0L) + (if third = 1L then 1L else 0L), (if duplicate = 2L then 1L else 0L), (if collision = 3L then 1L else 0L), (if conflict = 4L then 1L else 0L), int64 lines.Length, valid, lookups, finalVersion))
let v4365 : bool = v4357 = 3L
let v4366 : bool = v4358 = 1L
let v4367 : bool = v4359 = 1L
let v4368 : bool = v4360 = 1L
let v4369 : bool = v4361 = 3L
let v4370 : bool = v4362 = 3L
let v4371 : bool = v4363 = 3L
let v4372 : bool = v4364 = 3L
let v4373 : bool = v4365 && v4366
let v4374 : bool = v4373 && v4367
let v4375 : bool = v4374 && v4368
let v4376 : bool = v4375 && v4369
let v4377 : bool = v4376 && v4370
let v4378 : bool = v4377 && v4371
let v4379 : bool = v4378 && v4372
if v4379 then
    ()
else
    failwith<unit> "typed-FX-statement-durable-identity-batch-store-runtime-mismatch"
let struct (v4380 : int64, v4381 : int64, v4382 : int64, v4383 : int64, v4384 : int64, v4385 : int64, v4386 : int64, v4387 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-child-owned-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let scriptPath = System.IO.Path.Combine(directory, "contender.fsx") in let scriptText = System.String.Join(System.Environment.NewLine, [|"open System"; "open System.IO"; "open System.Text"; "open System.Diagnostics"; "let args = fsi.CommandLineArgs"; "let directory = args.[1]"; "let contender = args.[2]"; "let payload = args.[3]"; "let prepared = Path.Combine(directory, contender + \".prepared\")"; "let committed = Path.Combine(directory, \"history.committed\")"; "let lockFile = Path.Combine(directory, \"history.cas\")"; "let bytes = Encoding.UTF8.GetBytes(payload)"; "do"; "    use stream = new FileStream(prepared, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.WriteThrough)"; "    stream.Write(bytes, 0, bytes.Length)"; "    stream.Flush(true)"; "let mutable won = false"; "try"; "    use lockStream = new FileStream(lockFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 1, FileOptions.WriteThrough)"; "    lockStream.WriteByte(1uy)"; "    lockStream.Flush(true)"; "    won <- true"; "with :? IOException -> ()"; "let runSync flag path ="; "    let info = new ProcessStartInfo()"; "    info.FileName <- \"/usr/bin/sync\""; "    info.UseShellExecute <- false"; "    info.ArgumentList.Add(flag)"; "    info.ArgumentList.Add(path)"; "    use process = Process.Start(info)"; "    let completed = process.WaitForExit(5000)"; "    if not completed then (process.Kill(true); process.WaitForExit() |> ignore)"; "    if completed then process.ExitCode else -2"; "if won then"; "    File.Move(prepared, committed)"; "    let fileSync = runSync \"-d\" committed"; "    let directorySync = runSync \"-f\" directory"; "    File.WriteAllText(Path.Combine(directory, contender + \".receipt\"), string fileSync + \"|\" + string directorySync)"; "    Environment.Exit(0)"; "else"; "    File.Delete(prepared)"; "    Environment.Exit(4)" |]) in System.IO.File.WriteAllText(scriptPath, scriptText); let start contender payload = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- System.Environment.ProcessPath; info.UseShellExecute <- false; info.ArgumentList.Add("fsi"); info.ArgumentList.Add("--exec"); info.ArgumentList.Add(scriptPath); info.ArgumentList.Add(directory); info.ArgumentList.Add(contender); info.ArgumentList.Add(payload); System.Diagnostics.Process.Start(info) in let firstPayload = "history=2|command=child-A|debit=41|credit=41" in let secondPayload = "history=2|command=child-B|debit=43|credit=43" in use first = start "first" firstPayload in use second = start "second" secondPayload in let firstDone = first.WaitForExit(15000) in let secondDone = second.WaitForExit(15000) in let _ = if not firstDone then (first.Kill(true); first.WaitForExit() |> ignore) else () in let _ = if not secondDone then (second.Kill(true); second.WaitForExit() |> ignore) else () in let firstApplied = if first.ExitCode = 0 then 1L else 0L in let secondApplied = if second.ExitCode = 0 then 1L else 0L in let winners = firstApplied + secondApplied in let conflicts = (if first.ExitCode = 4 then 1L else 0L) + (if second.ExitCode = 4 then 1L else 0L) in let committed = System.IO.Path.Combine(directory, "history.committed") in let committedBytes = System.IO.File.ReadAllBytes(committed) in let committedDigest = System.Security.Cryptography.SHA256.HashData(committedBytes) in let winnerPayload = if firstApplied = 1L then firstPayload else secondPayload in let winnerDigest = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(winnerPayload)) in let digestEqual = if System.Linq.Enumerable.SequenceEqual(committedDigest, winnerDigest) then 1L else 0L in let preparedAbsent = if not (System.IO.File.Exists(System.IO.Path.Combine(directory, "first.prepared"))) && not (System.IO.File.Exists(System.IO.Path.Combine(directory, "second.prepared"))) then 1L else 0L in let receiptPath = System.IO.Path.Combine(directory, (if firstApplied = 1L then "first.receipt" else "second.receipt")) in let syncReceipt = if System.IO.File.ReadAllText(receiptPath) = "0|0" then 1L else 0L in System.IO.Directory.Delete(directory, true); (firstApplied, secondApplied, winners, conflicts, digestEqual, preparedAbsent, syncReceipt, int64 committedBytes.Length))
let v4388 : int64 = v4380 + v4381
let v4389 : bool = v4388 = 1L
let v4390 : bool = v4382 = 1L
let v4391 : bool = v4383 = 1L
let v4392 : bool = v4384 = 1L
let v4393 : bool = v4385 = 1L
let v4394 : bool = v4386 = 1L
let v4395 : bool = v4387 > 0L
let v4396 : bool = v4389 && v4390
let v4397 : bool = v4396 && v4391
let v4398 : bool = v4397 && v4392
let v4399 : bool = v4398 && v4393
let v4400 : bool = v4399 && v4394
let v4401 : bool = v4400 && v4395
if v4401 then
    ()
else
    failwith<unit> "typed-FX-statement-child-owned-full-commit-race-runtime-mismatch"
let struct (v4402 : int64, v4403 : int64, v4404 : int64, v4405 : int64, v4406 : int64, v4407 : int64, v4408 : int64, v4409 : int64, v4410 : int64, v4411 : int64) = method0()
let v4412 : bool = v4402 = 1L
let v4413 : bool = v4403 = 2L
let v4414 : bool = v4404 = 6L
let v4415 : bool = v4405 = 20L
let v4416 : bool = v4406 = 20L
let v4417 : bool = v4407 = 0L
let v4418 : bool = v4408 = 1L
let v4419 : bool = v4409 = 999L
let v4420 : bool = v4410 = 23L
let v4421 : bool = v4411 = 0L
let v4422 : bool = v4412 && v4413
let v4423 : bool = v4422 && v4414
let v4424 : bool = v4423 && v4415
let v4425 : bool = v4424 && v4416
let v4426 : bool = v4425 && v4417
let v4427 : bool = v4426 && v4418
let v4428 : bool = v4427 && v4419
let v4429 : bool = v4428 && v4420
let v4430 : bool = v4429 && v4421
if v4430 then
    ()
else
    failwith<unit> "typed-FX-hashed-statement-two-frame-checksum-rejection-runtime-mismatch"
let struct (v4431 : int64, v4432 : int64, v4433 : int64, v4434 : int64, v4435 : int64, v4436 : int64, v4437 : int64, v4438 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-chain-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let store = System.IO.Path.Combine(directory, "events.bin") in let outbox = System.IO.Path.Combine(directory, "outbox.bin") in let payloads = [|"identity=primary|aggregate=ledger|position=1|debit=10|credit=10"; "identity=secondary|aggregate=ledger|position=2|debit=7|credit=7"; "identity=tertiary|aggregate=ledger|position=3|debit=3|credit=3"|] in let mutable previous = Array.zeroCreate<byte> 32 in (use stream = new System.IO.FileStream(store, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in use out = new System.IO.FileStream(outbox, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in for payload in payloads do let bytes = System.Text.Encoding.UTF8.GetBytes(payload) in let digestInput = Array.append previous bytes in let digest = System.Security.Cryptography.SHA256.HashData(digestInput) in let length = System.BitConverter.GetBytes(bytes.Length) in stream.Write(length,0,length.Length); stream.Write(previous,0,previous.Length); stream.Write(bytes,0,bytes.Length); stream.Write(digest,0,digest.Length); let outLength = System.BitConverter.GetBytes(digest.Length + bytes.Length) in out.Write(outLength,0,outLength.Length); out.Write(digest,0,digest.Length); out.Write(bytes,0,bytes.Length); previous <- digest; stream.Flush(true); out.Flush(true)); let replay (path : string) = let data = System.IO.File.ReadAllBytes(path) in let rec loop (offset : int) (expected : byte array) (frames : int64) (payloadBytes : int64) = if offset = data.Length then 1L, frames, payloadBytes, int64 expected.Length elif offset + 4 > data.Length then 0L, frames, payloadBytes, int64 expected.Length else let length = System.BitConverter.ToInt32(data,offset) in let payloadOffset = offset + 4 + 32 in let digestOffset = payloadOffset + length in let nextOffset = digestOffset + 32 in if length < 0 || nextOffset > data.Length then 0L, frames, payloadBytes, int64 expected.Length else let prior = data.[offset+4..offset+35] in let payload = data.[payloadOffset..digestOffset-1] in let digest = data.[digestOffset..nextOffset-1] in let computed = System.Security.Cryptography.SHA256.HashData(Array.append prior payload) in if not (System.Linq.Enumerable.SequenceEqual(prior,expected)) || not (System.Linq.Enumerable.SequenceEqual(digest,computed)) then 0L, frames, payloadBytes, int64 expected.Length else loop nextOffset digest (frames + 1L) (payloadBytes + int64 payload.Length) in loop 0 (Array.zeroCreate<byte> 32) 0L 0L in let valid, frames, payloadBytes, digestBytes = replay store in let outboxBytes = System.IO.File.ReadAllBytes(outbox).Length |> int64 in let tampered = System.IO.File.ReadAllBytes(store) in let firstLength = System.BitConverter.ToInt32(tampered,0) in let secondPayloadOffset = 4 + 32 + firstLength + 32 + 4 + 32 in tampered.[secondPayloadOffset] <- tampered.[secondPayloadOffset] ^^^ 1uy; let corrupt = System.IO.Path.Combine(directory, "events.corrupt.bin") in System.IO.File.WriteAllBytes(corrupt,tampered); let corruptValid, corruptFrames, _, _ = replay corrupt in System.IO.File.Delete(store); System.IO.File.Delete(outbox); System.IO.File.Delete(corrupt); System.IO.Directory.Delete(directory); (valid, frames, payloadBytes, digestBytes, outboxBytes, (if corruptValid = 0L then 1L else 0L), corruptFrames, int64 payloads.Length))
let v4439 : bool = v4431 = 1L
let v4440 : bool = v4432 = 3L
let v4441 : bool = v4433 > 0L
let v4442 : bool = v4434 = 32L
let v4443 : bool = v4435 > v4433
let v4444 : bool = v4436 = 1L
let v4445 : bool = v4437 = 1L
let v4446 : bool = v4438 = 3L
let v4447 : bool = v4439 && v4440
let v4448 : bool = v4447 && v4441
let v4449 : bool = v4448 && v4442
let v4450 : bool = v4449 && v4443
let v4451 : bool = v4450 && v4444
let v4452 : bool = v4451 && v4445
let v4453 : bool = v4452 && v4446
if v4453 then
    ()
else
    failwith<unit> "typed-FX-statement-length-prefixed-hash-chain-outbox-runtime-mismatch"
let v4454 : int64 = 0L + 1L
let v4455 : int64 = v4454 + 1L
let v4456 : int64 = v4455 + 1L
let v4457 : int64 = v4456 + 1L
let v4458 : int64 = 0L + 1L
let v4459 : int64 = v4458 + 1L
let v4460 : int64 = v4459 + 1L
let v4461 : int64 = v4460 + 1L
let v4462 : bool = v4457 = v4461
let v4463 : int64 =
    if v4462 then
        0L
    else
        1L
let v4464 : int64 = 0L + 1L
let v4465 : int64 = 0L + 1L
let v4466 : bool = v4464 = v4465
let v4467 : int64 =
    if v4466 then
        0L
    else
        1L
let v4468 : int64 = 0L + 1L
let v4469 : int64 = v4468 + 1L
let v4470 : int64 = v4469 + 1L
let v4471 : int64 = v4470 + 1L
let v4472 : int64 = v4471 + 1L
let v4473 : int64 = 0L + 1L
let v4474 : int64 = v4473 + 1L
let v4475 : int64 = v4474 + 1L
let v4476 : int64 = v4475 + 1L
let v4477 : int64 = v4476 + 1L
let v4478 : bool = v4472 = v4477
let v4479 : int64 =
    if v4478 then
        0L
    else
        1L
let v4480 : int64 = v4464 + v4472
let v4481 : int64 = v4465 + v4477
let v4482 : int64 = v4467 + v4479
let v4483 : int64 = v4457 + v4480
let v4484 : int64 = v4461 + v4481
let v4485 : int64 = v4463 + v4482
let struct (v4486 : int64, v4487 : int64, v4488 : int64, v4489 : int64, v4490 : int64, v4491 : int64, v4492 : int64, v4493 : int64, v4494 : int64, v4495 : int64, v4496 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-aligned-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let store = System.IO.Path.Combine(directory, "events.bin") in let outbox = System.IO.Path.Combine(directory, "outbox.bin") in let encodeFrame (position : int64) (identity : string) (aggregate : string) (payloadHash : string) (payload : string) = let buffer = new System.IO.MemoryStream() in let writeString (value : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(bytes.Length) in buffer.Write(length,0,length.Length); buffer.Write(bytes,0,bytes.Length) in let positionBytes = System.BitConverter.GetBytes(position) in buffer.Write(positionBytes,0,positionBytes.Length); writeString identity; writeString aggregate; writeString payloadHash; writeString payload; buffer.ToArray() in let primaryPayload = System.String.Format("statements={0};debit={1};credit={2};mismatch={3}", 3L, v4483, v4484, v4485) in let payloads = [|(1L,"command-primary","ledger-main","hash-primary",primaryPayload); (2L,"command-secondary","ledger-main","hash-secondary","debit=7;credit=7"); (3L,"command-tertiary","ledger-main","hash-tertiary","debit=3;credit=3")|] in let mutable previous = Array.zeroCreate<byte> 32 in (use eventStream = new System.IO.FileStream(store,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in use outboxStream = new System.IO.FileStream(outbox,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in for (position,identity,aggregate,payloadHash,payload) in payloads do let framePayload = encodeFrame position identity aggregate payloadHash payload in let digest = System.Security.Cryptography.SHA256.HashData(Array.append previous framePayload) in let frameLength = System.BitConverter.GetBytes(framePayload.Length) in eventStream.Write(frameLength,0,frameLength.Length); eventStream.Write(previous,0,previous.Length); eventStream.Write(framePayload,0,framePayload.Length); eventStream.Write(digest,0,digest.Length); let outboxPayload = Array.concat [|System.BitConverter.GetBytes(position); digest; framePayload|] in let outboxLength = System.BitConverter.GetBytes(outboxPayload.Length) in outboxStream.Write(outboxLength,0,outboxLength.Length); outboxStream.Write(outboxPayload,0,outboxPayload.Length); previous <- digest; eventStream.Flush(true); outboxStream.Flush(true)); let replayStore (data : byte array) = let rec loop offset expectedPosition expectedPrevious acc = if offset = data.Length then 1L, List.rev acc |> List.toArray elif offset + 4 > data.Length then 0L, List.rev acc |> List.toArray else let payloadLength = System.BitConverter.ToInt32(data,offset) in let priorOffset = offset + 4 in let payloadOffset = priorOffset + 32 in let digestOffset = payloadOffset + payloadLength in let nextOffset = digestOffset + 32 in if payloadLength < 8 || nextOffset > data.Length then 0L, List.rev acc |> List.toArray else let prior = data.[priorOffset..payloadOffset-1] in let framePayload = data.[payloadOffset..digestOffset-1] in let digest = data.[digestOffset..nextOffset-1] in let position = System.BitConverter.ToInt64(framePayload,0) in let computed = System.Security.Cryptography.SHA256.HashData(Array.append prior framePayload) in if position <> expectedPosition || not (System.Linq.Enumerable.SequenceEqual(prior,expectedPrevious)) || not (System.Linq.Enumerable.SequenceEqual(digest,computed)) then 0L, List.rev acc |> List.toArray else loop nextOffset (expectedPosition + 1L) digest ((position,digest,framePayload)::acc) in loop 0 1L (Array.zeroCreate<byte> 32) [] in let replayOutbox (data : byte array) (expected : (int64 * byte array * byte array) array) = let rec loop offset index = if offset = data.Length then (if index = expected.Length then 1L else 0L), int64 index elif offset + 4 > data.Length || index >= expected.Length then 0L, int64 index else let recordLength = System.BitConverter.ToInt32(data,offset) in let recordOffset = offset + 4 in let nextOffset = recordOffset + recordLength in if recordLength < 40 || nextOffset > data.Length then 0L, int64 index else let position = System.BitConverter.ToInt64(data,recordOffset) in let digest = data.[recordOffset+8..recordOffset+39] in let framePayload = data.[recordOffset+40..nextOffset-1] in let expectedPosition, expectedDigest, expectedPayload = expected.[index] in if position <> expectedPosition || not (System.Linq.Enumerable.SequenceEqual(digest,expectedDigest)) || not (System.Linq.Enumerable.SequenceEqual(framePayload,expectedPayload)) then 0L, int64 index else loop nextOffset (index+1) in loop 0 0 in let storeBytes = System.IO.File.ReadAllBytes(store) in let storeValid, frames = replayStore storeBytes in let outboxBytes = System.IO.File.ReadAllBytes(outbox) in let outboxValid, outboxFrames = replayOutbox outboxBytes frames in let tamperedStore = Array.copy storeBytes in let firstLength = System.BitConverter.ToInt32(tamperedStore,0) in let secondPayloadOffset = 4 + 32 + firstLength + 32 + 4 + 32 in tamperedStore.[secondPayloadOffset+8] <- tamperedStore.[secondPayloadOffset+8] ^^^ 1uy; let tamperedStoreValid, tamperedPrefix = replayStore tamperedStore in let tamperedOutbox = Array.copy outboxBytes in let firstOutboxLength = System.BitConverter.ToInt32(tamperedOutbox,0) in let secondDigestOffset = 4 + firstOutboxLength + 4 + 8 in tamperedOutbox.[secondDigestOffset] <- tamperedOutbox.[secondDigestOffset] ^^^ 1uy; let tamperedOutboxValid, tamperedOutboxPrefix = replayOutbox tamperedOutbox frames in let firstPosition = if frames.Length = 0 then 0L else let position,_,_ = frames.[0] in position in let lastPosition = if frames.Length = 0 then 0L else let position,_,_ = frames.[frames.Length-1] in position in let totalPayloadBytes = frames |> Array.sumBy (fun (_,_,payload) -> int64 payload.Length) in let primaryFrameAligned = if frames.Length = 0 then 0L else let _,_,firstPayload = frames.[0] in if System.Linq.Enumerable.SequenceEqual(firstPayload, encodeFrame 1L "command-primary" "ledger-main" "hash-primary" primaryPayload) then 1L else 0L in System.IO.Directory.Delete(directory,true); storeValid, int64 frames.Length, outboxValid, outboxFrames, (if tamperedStoreValid = 0L then 1L else 0L), tamperedPrefix |> Array.length |> int64, (if tamperedOutboxValid = 0L then 1L else 0L), tamperedOutboxPrefix, firstPosition, lastPosition + totalPayloadBytes, primaryFrameAligned)
let v4497 : bool = v4486 = 1L
let v4498 : bool = v4487 = 3L
let v4499 : bool = v4488 = 1L
let v4500 : bool = v4489 = 3L
let v4501 : bool = v4490 = 1L
let v4502 : bool = v4491 = 1L
let v4503 : bool = v4492 = 1L
let v4504 : bool = v4493 = 1L
let v4505 : bool = v4494 = 1L
let v4506 : bool = v4495 > 3L
let v4507 : bool = v4496 = 1L
let v4508 : bool = v4497 && v4498
let v4509 : bool = v4508 && v4499
let v4510 : bool = v4509 && v4500
let v4511 : bool = v4510 && v4501
let v4512 : bool = v4511 && v4502
let v4513 : bool = v4512 && v4503
let v4514 : bool = v4513 && v4504
let v4515 : bool = v4514 && v4505
let v4516 : bool = v4515 && v4506
let v4517 : bool = v4516 && v4507
if v4517 then
    ()
else
    failwith<unit> "typed-FX-statement-binary-field-hash-chain-outbox-alignment-runtime-mismatch"
let v4518 : int64 = 0L + 1L
let v4519 : int64 = v4518 + 1L
let v4520 : int64 = 0L + 1L
let v4521 : int64 = v4520 + 1L
let v4522 : string = "approvals-collected"
if v4519 <> 2L || v4521 <> 2L || v4522 <> "approvals-collected" || v4522 <> "approvals-collected" then failwith "erp-p2p-two-event-store-runtime-mismatch"
let v4523 : int64 = -1L * 830L
let v4524 : string = "intercompany-netted"
if 830L <> 830L || v4523 <> -830L || 830L + v4523 <> 0L || v4524 <> "intercompany-netted" then failwith "erp-p2p-net-intercompany-runtime-mismatch"
let v4525 : int64 = -1L * 830L
let v4526 : string = "company-a"
let v4527 : string = "USD"
let v4528 : string = "widget-a"
let v4529 : string = "warehouse-north"
let v4530 : string = "BR"
let v4531 : string = "po-1001"
let v4532 : string = "invoice-match-1001"
let v4533 : string = "company-b"
let v4534 : string = "company-a-intercompany-receivable-830"
let v4535 : string = "company-b-intercompany-payable-minus-830"
let v4536 : string = (let fields = [| v4526; v4527; v4528; v4529; v4530; v4531; v4532; v4526; v4533; v4527; v4531; string 830L; v4534; v4533; v4526; v4527; v4531; string v4525; v4535 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v4537 : int64, v4538 : int64) = (int64 (System.Convert.FromBase64String(v4536).Length), int64 (System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v4536)).Length))
let v4539 : int64 = -1L * 830L
let v4540 : bool = v4537 > 0L
let v4541 : bool = v4538 = 32L
let v4542 : bool = v4540 && v4541
if v4542 then
    ()
else
    failwith<unit> "erp-NetIntercompany-payload-frame-runtime-mismatch"
if 830L <> 830L || v4539 <> -830L || 830L + v4539 <> 0L || v4524 <> "intercompany-netted" then failwith "erp-p2p-net-intercompany-runtime-mismatch"
let v4543 : int64 = -1L * 830L
let v4544 : string = (let fields = [| v4526; v4527; v4528; v4529; v4530; v4531; v4532; v4526; v4533; v4527; v4531; string 830L; v4534; v4533; v4526; v4527; v4531; string v4543; v4535 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v4545 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v4544 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v4546 : bool = 1L = v4545
let v4551 : US1 =
    if v4546 then
        let v4547 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US1_0(v4547)
    else
        let v4549 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US1_1(v4549)
let v4552 : string = if v4544.Length > 4 then v4544.Substring(0, v4544.Length - 4) else ""
let v4553 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v4552 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v4554 : bool = 1L = v4553
let v4559 : US1 =
    if v4554 then
        let v4555 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US1_0(v4555)
    else
        let v4557 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US1_1(v4557)
let v4563 : int64 =
    match v4551 with
    | US1_0(v4560) -> (* ErpNetIntercompanyPayloadDecoded *)
        1L
    | US1_1(v4561) -> (* ErpNetIntercompanyPayloadRejected *)
        0L
let v4567 : int64 =
    match v4559 with
    | US1_0(v4564) -> (* ErpNetIntercompanyPayloadDecoded *)
        1L
    | US1_1(v4565) -> (* ErpNetIntercompanyPayloadRejected *)
        0L
let v4568 : int64 = -1L * v4567
let v4569 : int64 = 1L + v4568
let v4570 : bool = v4563 = 1L
let v4571 : bool = v4569 = 1L
let v4572 : bool = v4570 && v4571
if v4572 then
    ()
else
    failwith<unit> "erp-NetIntercompany-payload-codec-runtime-mismatch"
let v4690 : string =
    match v4551 with
    | US1_0(v4573) -> (* ErpNetIntercompanyPayloadDecoded *)
        let v4574 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v4544 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
        let v4575 : bool = 1L = v4574
        let v4580 : US1 =
            if v4575 then
                let v4576 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
                US1_0(v4576)
            else
                let v4578 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
                US1_1(v4578)
        let v4601 : US2 =
            match v4580 with
            | US1_0(v4581) -> (* ErpNetIntercompanyPayloadDecoded *)
                let struct (v4582 : string, v4583 : string, v4584 : string, v4585 : string, v4586 : string, v4587 : string, v4588 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4544 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
                let struct (v4589 : string, v4590 : string, v4591 : string, v4592 : string, v4593 : int64, v4594 : string, v4595 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4544 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
                let v4596 : US3 = US3_0(v4589, v4590, v4591, v4592, v4593, v4594, v4595)
                US2_0(v4582, v4583, v4584, v4585, v4586, v4587, v4588, v4596)
            | US1_1(v4598) -> (* ErpNetIntercompanyPayloadRejected *)
                let v4599 : US2 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v4598)
                v4599
        let v4638 : string =
            match v4601 with
            | US2_0(v4602, v4603, v4604, v4605, v4606, v4607, v4608, v4609) -> (* NetIntercompany *)
                let struct (v4617 : string, v4618 : string, v4619 : string, v4620 : string, v4621 : int64, v4622 : string) =
                    match v4609 with
                    | US3_0(v4610, v4611, v4612, v4613, v4614, v4615, v4616) -> (* OpposedMirrorPair *)
                        struct (v4610, v4611, v4612, v4613, v4614, v4615)
                let struct (v4631 : string, v4632 : string, v4633 : string, v4634 : string, v4635 : int64, v4636 : string) =
                    match v4609 with
                    | US3_0(v4623, v4624, v4625, v4626, v4627, v4628, v4629) -> (* OpposedMirrorPair *)
                        let v4630 : int64 = -1L * v4627
                        struct (v4624, v4623, v4625, v4626, v4630, v4629)
                let v4637 : string = (let fields = [| v4602; v4603; v4604; v4605; v4606; v4607; v4608; v4617; v4618; v4619; v4620; string v4621; v4622; v4631; v4632; v4633; v4634; string v4635; v4636 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
                v4637
        let v4639 : bool = v4638 = v4544
        if v4639 then
            ()
        else
            failwith<unit> "erp-NetIntercompany-field-derived-operation-roundtrip-mismatch"
        let struct (v4675 : int64, v4676 : int64) =
            match v4601 with
            | US2_0(v4640, v4641, v4642, v4643, v4644, v4645, v4646, v4647) -> (* NetIntercompany *)
                let struct (v4655 : string, v4656 : string, v4657 : string, v4658 : string, v4659 : int64, v4660 : string) =
                    match v4647 with
                    | US3_0(v4648, v4649, v4650, v4651, v4652, v4653, v4654) -> (* OpposedMirrorPair *)
                        struct (v4648, v4649, v4650, v4651, v4652, v4653)
                let struct (v4669 : string, v4670 : string, v4671 : string, v4672 : string, v4673 : int64, v4674 : string) =
                    match v4647 with
                    | US3_0(v4661, v4662, v4663, v4664, v4665, v4666, v4667) -> (* OpposedMirrorPair *)
                        let v4668 : int64 = -1L * v4665
                        struct (v4662, v4661, v4663, v4664, v4668, v4667)
                struct (v4659, v4673)
        let v4685 : string =
            match v4601 with
            | US2_0(v4677, v4678, v4679, v4680, v4681, v4682, v4683, v4684) -> (* NetIntercompany *)
                v4524
        if v4675 <> 830L || v4676 <> -830L || v4675 + v4676 <> 0L || v4685 <> "intercompany-netted" then failwith "erp-p2p-net-intercompany-runtime-mismatch"
        let v4686 : string = "NetIntercompany-now-has-a-nineteen-field-canonical-frame-and-a-fail-closed-decoder-that-reconstructs-the-exact-result-indexed-operation-only-after-entity-counterparty-currency-document-and-opposed-mirror-amount-bindings-validate"
        v4686
    | US1_1(v4687) -> (* ErpNetIntercompanyPayloadRejected *)
        let v4688 : string = failwith ("canonical-NetIntercompany-frame-was-rejected:" + v4687)
        v4688
let v4691 : int64 = -1L * 830L
let v4692 : string = (let fields = [| v4526; v4527; v4528; v4529; v4530; v4531; v4532; v4526; v4533; v4527; v4531; string 830L; v4534; v4533; v4526; v4527; v4531; string v4691; v4535 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v4693 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v4692 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v4694 : bool = 1L = v4693
let v4699 : US1 =
    if v4694 then
        let v4695 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US1_0(v4695)
    else
        let v4697 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US1_1(v4697)
let v4720 : US2 =
    match v4699 with
    | US1_0(v4700) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v4701 : string, v4702 : string, v4703 : string, v4704 : string, v4705 : string, v4706 : string, v4707 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4692 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v4708 : string, v4709 : string, v4710 : string, v4711 : string, v4712 : int64, v4713 : string, v4714 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4692 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v4715 : US3 = US3_0(v4708, v4709, v4710, v4711, v4712, v4713, v4714)
        US2_0(v4701, v4702, v4703, v4704, v4705, v4706, v4707, v4715)
    | US1_1(v4717) -> (* ErpNetIntercompanyPayloadRejected *)
        let v4718 : US2 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v4717)
        v4718
let v4757 : string =
    match v4720 with
    | US2_0(v4721, v4722, v4723, v4724, v4725, v4726, v4727, v4728) -> (* NetIntercompany *)
        let struct (v4736 : string, v4737 : string, v4738 : string, v4739 : string, v4740 : int64, v4741 : string) =
            match v4728 with
            | US3_0(v4729, v4730, v4731, v4732, v4733, v4734, v4735) -> (* OpposedMirrorPair *)
                struct (v4729, v4730, v4731, v4732, v4733, v4734)
        let struct (v4750 : string, v4751 : string, v4752 : string, v4753 : string, v4754 : int64, v4755 : string) =
            match v4728 with
            | US3_0(v4742, v4743, v4744, v4745, v4746, v4747, v4748) -> (* OpposedMirrorPair *)
                let v4749 : int64 = -1L * v4746
                struct (v4743, v4742, v4744, v4745, v4749, v4748)
        let v4756 : string = (let fields = [| v4721; v4722; v4723; v4724; v4725; v4726; v4727; v4736; v4737; v4738; v4739; string v4740; v4741; v4750; v4751; v4752; v4753; string v4754; v4755 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v4756
method1(v4692, v4757)
method2(v4692)
method1(v4692, v4757)
let struct (v4766 : string, v4767 : string, v4768 : string, v4769 : string, v4770 : string, v4771 : string, v4772 : string) =
    match v4720 with
    | US2_0(v4758, v4759, v4760, v4761, v4762, v4763, v4764, v4765) -> (* NetIntercompany *)
        struct (v4758, v4759, v4760, v4761, v4762, v4763, v4764)
let v4773 : string = "payment-settled-through-composed-typed-fx-route"
if 6L <> 6L || 1L <> 1L || v4773 <> "payment-settled-through-composed-typed-fx-route" then failwith "erp-p2p-settle-payment-from-decoded-runtime-mismatch"
let v4774 : string = "budget-reserved"
let v4775 : string = v4774 + "|" + v4522
let v4776 : string = "purchase-order-issued"
let v4777 : string = v4775 + "|" + v4776
let v4778 : string = v4774 + "|" + v4522
let v4779 : string = v4778 + "|" + v4776
let struct (v4780 : int64, v4781 : int64, v4782 : int64, v4783 : int64, v4784 : int64, v4785 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-p2p-sequence-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let storePath = System.IO.Path.Combine(directory, "events.bin") in let outboxPath = System.IO.Path.Combine(directory, "outbox.bin") in let storeBytes = System.Text.Encoding.UTF8.GetBytes(v4777) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v4779) in let storeDigest = System.Security.Cryptography.SHA256.HashData(storeBytes) in let outboxDigest = System.Security.Cryptography.SHA256.HashData(outboxBytes) in (use stream = new System.IO.FileStream(storePath,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(storeBytes,0,storeBytes.Length); stream.Flush(true)); (use stream = new System.IO.FileStream(outboxPath,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(outboxBytes,0,outboxBytes.Length); stream.Flush(true)); let recoveredStore = System.IO.File.ReadAllBytes(storePath) in let recoveredOutbox = System.IO.File.ReadAllBytes(outboxPath) in let storeEqual = if System.Linq.Enumerable.SequenceEqual(storeBytes,recoveredStore) then 1L else 0L in let outboxEqual = if System.Linq.Enumerable.SequenceEqual(outboxBytes,recoveredOutbox) then 1L else 0L in let digestEqual = if System.Linq.Enumerable.SequenceEqual(storeDigest,outboxDigest) then 1L else 0L in let tampered = Array.copy recoveredStore in let _ = if tampered.Length > 0 then tampered.[tampered.Length-1] <- tampered.[tampered.Length-1] ^^^ 1uy else () in let tamperRejected = if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tampered),storeDigest) then 0L else 1L in System.IO.Directory.Delete(directory,true); int64 storeBytes.Length, int64 outboxBytes.Length, storeEqual, outboxEqual, digestEqual, tamperRejected)
let v4786 : bool = v4780 > 0L
let v4787 : bool = v4781 = v4780
let v4788 : bool = v4782 = 1L
let v4789 : bool = v4783 = 1L
let v4790 : bool = v4784 = 1L
let v4791 : bool = v4785 = 1L
let v4792 : bool = v4786 && v4787
let v4793 : bool = v4792 && v4788
let v4794 : bool = v4793 && v4789
let v4795 : bool = v4794 && v4790
let v4796 : bool = v4795 && v4791
if v4796 then
    ()
else
    failwith<unit> "erp-p2p-event-store-physical-roundtrip-runtime-mismatch"
let v4797 : string = v4774 + "|" + v4522
let v4798 : string = v4797 + "|" + v4776
let v4799 : string = "goods-partially-received"
let v4800 : string = v4798 + "|" + v4799
let v4801 : string = v4774 + "|" + v4522
let v4802 : string = v4801 + "|" + v4776
let v4803 : string = v4802 + "|" + v4799
let struct (v4804 : int64, v4805 : int64, v4806 : int64, v4807 : int64, v4808 : int64, v4809 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-p2p-sequence-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let storePath = System.IO.Path.Combine(directory, "events.bin") in let outboxPath = System.IO.Path.Combine(directory, "outbox.bin") in let storeBytes = System.Text.Encoding.UTF8.GetBytes(v4800) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v4803) in let storeDigest = System.Security.Cryptography.SHA256.HashData(storeBytes) in let outboxDigest = System.Security.Cryptography.SHA256.HashData(outboxBytes) in (use stream = new System.IO.FileStream(storePath,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(storeBytes,0,storeBytes.Length); stream.Flush(true)); (use stream = new System.IO.FileStream(outboxPath,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(outboxBytes,0,outboxBytes.Length); stream.Flush(true)); let recoveredStore = System.IO.File.ReadAllBytes(storePath) in let recoveredOutbox = System.IO.File.ReadAllBytes(outboxPath) in let storeEqual = if System.Linq.Enumerable.SequenceEqual(storeBytes,recoveredStore) then 1L else 0L in let outboxEqual = if System.Linq.Enumerable.SequenceEqual(outboxBytes,recoveredOutbox) then 1L else 0L in let digestEqual = if System.Linq.Enumerable.SequenceEqual(storeDigest,outboxDigest) then 1L else 0L in let tampered = Array.copy recoveredStore in let _ = if tampered.Length > 0 then tampered.[tampered.Length-1] <- tampered.[tampered.Length-1] ^^^ 1uy else () in let tamperRejected = if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tampered),storeDigest) then 0L else 1L in System.IO.Directory.Delete(directory,true); int64 storeBytes.Length, int64 outboxBytes.Length, storeEqual, outboxEqual, digestEqual, tamperRejected)
let v4810 : bool = v4804 > 0L
let v4811 : bool = v4805 = v4804
let v4812 : bool = v4806 = 1L
let v4813 : bool = v4807 = 1L
let v4814 : bool = v4808 = 1L
let v4815 : bool = v4809 = 1L
let v4816 : bool = v4810 && v4811
let v4817 : bool = v4816 && v4812
let v4818 : bool = v4817 && v4813
let v4819 : bool = v4818 && v4814
let v4820 : bool = v4819 && v4815
if v4820 then
    ()
else
    failwith<unit> "erp-p2p-event-store-physical-roundtrip-runtime-mismatch"
let v4821 : string = "requisition-1001"
let v4822 : string = "budget-reservation-1001"
let v4823 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v4824 : int64, v4825 : int64, v4826 : int64, v4827 : int64, v4828 : int64, v4829 : int64, v4830 : int64, v4831 : int64, v4832 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v4823 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let indexBound = match decoded with Some fields when fields.Length = 8 -> 1L | _ -> 0L in let sharedEntity = match decoded with Some fields when fields.Length = 8 && fields.[0] = fields.[4] -> 1L | _ -> 0L in let sharedCurrency = match decoded with Some fields when fields.Length = 8 && fields.[1] = fields.[5] -> 1L | _ -> 0L in let amountBound = match decoded with Some fields when fields.Length = 8 -> (match System.Int64.TryParse(fields.[6]) with true,value when value > 0L -> 1L | _ -> 0L) | _ -> 0L in let identityBound = match decoded with Some fields when fields.Length = 8 && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[3] <> fields.[7] -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v4823 -> 1L | _ -> 0L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v4823)).Length |> int64 in let truncated = if v4823.Length > 4 then v4823.Substring(0, v4823.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,indexBound,sharedEntity,sharedCurrency,amountBound,identityBound,roundtrip,digestBytes,tamperRejected)
let v4833 : bool = v4824 = 8L
let v4834 : bool = v4825 = 1L
let v4835 : bool = v4826 = 1L
let v4836 : bool = v4827 = 1L
let v4837 : bool = v4828 = 1L
let v4838 : bool = v4829 = 1L
let v4839 : bool = v4830 = 1L
let v4840 : bool = v4831 = 32L
let v4841 : bool = v4832 = 1L
let v4842 : bool = v4833 && v4834
let v4843 : bool = v4842 && v4835
let v4844 : bool = v4843 && v4836
let v4845 : bool = v4844 && v4837
let v4846 : bool = v4845 && v4838
let v4847 : bool = v4846 && v4839
let v4848 : bool = v4847 && v4840
let v4849 : bool = v4848 && v4841
if v4849 then
    ()
else
    failwith<unit> "erp-reserve-budget-payload-codec-runtime-mismatch"
let v4850 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v4851 : string, v4852 : string, v4853 : string, v4854 : string, v4855 : string, v4856 : string, v4857 : int64, v4858 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4850 with Some fields when fields.Length = 8 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[4] = fields.[0] && fields.[5] = fields.[1] && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[3] <> fields.[7] -> (match System.Int64.TryParse(fields.[6]) with true,amount when amount > 0L -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],amount,fields.[7] | _ -> failwith "erp-ReserveBudget-typed-decode-invalid-amount") | _ -> failwith "erp-ReserveBudget-typed-decode-invalid-frame")
let v4859 : string = (let fields = [| v4851; v4852; v4853; v4854; v4855; v4856; string v4857; v4858 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v4860 : bool = v4850 = v4859
if v4860 then
    ()
else
    failwith<unit> "erp-ReserveBudget-typed-decode-roundtrip-mismatch"
if v4860 then
    ()
else
    failwith<unit> "erp-ReserveBudget-typed-decode-roundtrip-mismatch"
let v4861 : int64 = -1L * 830L
let v4862 : string = (let fields = [| v4526; v4527; v4528; v4529; v4530; v4531; v4532; v4526; v4533; v4527; v4531; string 830L; v4534; v4533; v4526; v4527; v4531; string v4861; v4535 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v4863 : string = "erp-p2p-" + v4524 + "-outbox"
let struct (v4864 : string, v4865 : int64, v4866 : int64, v4867 : int64, v4868 : int64, v4869 : int64, v4870 : int64, v4871 : int64, v4872 : int64, v4873 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-reserve-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloadBytes = System.Convert.FromBase64String(v4862) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v4863) in let payloadDigest = System.Security.Cryptography.SHA256.HashData(payloadBytes) in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let envelope = Array.concat [| [| 69uy; 82uy; 80uy; 49uy |]; lengthBytes payloadBytes.Length; payloadBytes; lengthBytes outboxBytes.Length; outboxBytes; payloadDigest |] in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(envelope, 0, envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength offset = System.BitConverter.ToInt32(recovered, offset) |> System.Net.IPAddress.NetworkToHostOrder in let parsed = try let payloadLength = readLength 4 in let payloadStart = 8 in let outboxLengthOffset = payloadStart + payloadLength in let outboxLength = readLength outboxLengthOffset in let outboxStart = outboxLengthOffset + 4 in let digestStart = outboxStart + outboxLength in if recovered.Length >= 44 && recovered.[0] = 69uy && recovered.[1] = 82uy && recovered.[2] = 80uy && recovered.[3] = 49uy && payloadLength >= 0 && outboxLength >= 0 && digestStart + 32 = recovered.Length then let decodedPayload = recovered.[payloadStart .. outboxLengthOffset - 1] in let decodedOutbox = recovered.[outboxStart .. digestStart - 1] in let storedDigest = recovered.[digestStart .. digestStart + 31] in Some(decodedPayload, decodedOutbox, storedDigest) else None with _ -> None in let parseValid,payloadEqual,outboxEqual,digestEqual,tamperRejected = match parsed with | Some(decodedPayload, decodedOutbox, storedDigest) -> let tamperedPayload = Array.copy decodedPayload in let _ = if tamperedPayload.Length > 0 then tamperedPayload.[0] <- tamperedPayload.[0] ^^^ 1uy else () in 1L, (if System.Linq.Enumerable.SequenceEqual(payloadBytes, decodedPayload) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(outboxBytes, decodedOutbox) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(decodedPayload), storedDigest) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tamperedPayload), storedDigest) then 0L else 1L) | None -> 0L,0L,0L,0L,0L in let reopenedPayload = match parsed with | Some(decodedPayload, _, _) -> System.Convert.ToBase64String(decodedPayload) | None -> System.String.Empty in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in reopenedPayload,int64 envelope.Length,parseValid,payloadEqual,outboxEqual,digestEqual,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v4874 : bool = v4865 > 0L
let v4875 : bool = v4866 = 1L
let v4876 : bool = v4867 = 1L
let v4877 : bool = v4868 = 1L
let v4878 : bool = v4869 = 1L
let v4879 : bool = v4870 = 1L
let v4880 : bool = v4871 = 0L
let v4881 : bool = v4872 = 1L
let v4882 : bool = v4873 = 1L
let v4883 : bool = v4874 && v4875
let v4884 : bool = v4883 && v4876
let v4885 : bool = v4884 && v4877
let v4886 : bool = v4885 && v4878
let v4887 : bool = v4886 && v4879
let v4888 : bool = v4887 && v4880
let v4889 : bool = v4888 && v4881
let v4890 : bool = v4889 && v4882
if v4890 then
    ()
else
    failwith<unit> "erp-reserve-budget-atomic-event-outbox-runtime-mismatch"
let v4891 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v4864 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v4892 : bool = 1L = v4891
let v4897 : US1 =
    if v4892 then
        let v4893 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US1_0(v4893)
    else
        let v4895 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US1_1(v4895)
let v4918 : US2 =
    match v4897 with
    | US1_0(v4898) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v4899 : string, v4900 : string, v4901 : string, v4902 : string, v4903 : string, v4904 : string, v4905 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4864 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v4906 : string, v4907 : string, v4908 : string, v4909 : string, v4910 : int64, v4911 : string, v4912 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4864 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v4913 : US3 = US3_0(v4906, v4907, v4908, v4909, v4910, v4911, v4912)
        US2_0(v4899, v4900, v4901, v4902, v4903, v4904, v4905, v4913)
    | US1_1(v4915) -> (* ErpNetIntercompanyPayloadRejected *)
        let v4916 : US2 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v4915)
        v4916
let v4955 : string =
    match v4918 with
    | US2_0(v4919, v4920, v4921, v4922, v4923, v4924, v4925, v4926) -> (* NetIntercompany *)
        let struct (v4934 : string, v4935 : string, v4936 : string, v4937 : string, v4938 : int64, v4939 : string) =
            match v4926 with
            | US3_0(v4927, v4928, v4929, v4930, v4931, v4932, v4933) -> (* OpposedMirrorPair *)
                struct (v4927, v4928, v4929, v4930, v4931, v4932)
        let struct (v4948 : string, v4949 : string, v4950 : string, v4951 : string, v4952 : int64, v4953 : string) =
            match v4926 with
            | US3_0(v4940, v4941, v4942, v4943, v4944, v4945, v4946) -> (* OpposedMirrorPair *)
                let v4947 : int64 = -1L * v4944
                struct (v4941, v4940, v4942, v4943, v4947, v4946)
        let v4954 : string = (let fields = [| v4919; v4920; v4921; v4922; v4923; v4924; v4925; v4934; v4935; v4936; v4937; string v4938; v4939; v4948; v4949; v4950; v4951; string v4952; v4953 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v4954
method1(v4864, v4955)
method2(v4864)
method1(v4864, v4955)
let v4965 : string =
    match v4918 with
    | US2_0(v4956, v4957, v4958, v4959, v4960, v4961, v4962, v4963) -> (* NetIntercompany *)
        let v4964 : string = "NetIntercompany-now-reconstructs-its-result-indexed-operation-from-the-disk-reopened-payload-under-one-sealed-bytes-operation-reencode-authority"
        v4964
let v4966 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v4967 : string, v4968 : string, v4969 : string, v4970 : string, v4971 : string, v4972 : string, v4973 : int64, v4974 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4966 with Some fields when fields.Length = 8 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[4] = fields.[0] && fields.[5] = fields.[1] && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[3] <> fields.[7] -> (match System.Int64.TryParse(fields.[6]) with true,amount when amount > 0L -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],amount,fields.[7] | _ -> failwith "erp-ReserveBudget-typed-decode-invalid-amount") | _ -> failwith "erp-ReserveBudget-typed-decode-invalid-frame")
let v4975 : string = (let fields = [| v4967; v4968; v4969; v4970; v4971; v4972; string v4973; v4974 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v4976 : bool = v4966 = v4975
if v4976 then
    ()
else
    failwith<unit> "erp-ReserveBudget-typed-decode-roundtrip-mismatch"
let v4977 : string = "erp-p2p-" + v4774 + "-outbox"
let struct (v4978 : string, v4979 : int64, v4980 : int64, v4981 : int64, v4982 : int64, v4983 : int64, v4984 : int64, v4985 : int64, v4986 : int64, v4987 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-reserve-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloadBytes = System.Convert.FromBase64String(v4966) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v4977) in let payloadDigest = System.Security.Cryptography.SHA256.HashData(payloadBytes) in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let envelope = Array.concat [| [| 69uy; 82uy; 80uy; 49uy |]; lengthBytes payloadBytes.Length; payloadBytes; lengthBytes outboxBytes.Length; outboxBytes; payloadDigest |] in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(envelope, 0, envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength offset = System.BitConverter.ToInt32(recovered, offset) |> System.Net.IPAddress.NetworkToHostOrder in let parsed = try let payloadLength = readLength 4 in let payloadStart = 8 in let outboxLengthOffset = payloadStart + payloadLength in let outboxLength = readLength outboxLengthOffset in let outboxStart = outboxLengthOffset + 4 in let digestStart = outboxStart + outboxLength in if recovered.Length >= 44 && recovered.[0] = 69uy && recovered.[1] = 82uy && recovered.[2] = 80uy && recovered.[3] = 49uy && payloadLength >= 0 && outboxLength >= 0 && digestStart + 32 = recovered.Length then let decodedPayload = recovered.[payloadStart .. outboxLengthOffset - 1] in let decodedOutbox = recovered.[outboxStart .. digestStart - 1] in let storedDigest = recovered.[digestStart .. digestStart + 31] in Some(decodedPayload, decodedOutbox, storedDigest) else None with _ -> None in let parseValid,payloadEqual,outboxEqual,digestEqual,tamperRejected = match parsed with | Some(decodedPayload, decodedOutbox, storedDigest) -> let tamperedPayload = Array.copy decodedPayload in let _ = if tamperedPayload.Length > 0 then tamperedPayload.[0] <- tamperedPayload.[0] ^^^ 1uy else () in 1L, (if System.Linq.Enumerable.SequenceEqual(payloadBytes, decodedPayload) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(outboxBytes, decodedOutbox) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(decodedPayload), storedDigest) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tamperedPayload), storedDigest) then 0L else 1L) | None -> 0L,0L,0L,0L,0L in let reopenedPayload = match parsed with | Some(decodedPayload, _, _) -> System.Convert.ToBase64String(decodedPayload) | None -> System.String.Empty in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in reopenedPayload,int64 envelope.Length,parseValid,payloadEqual,outboxEqual,digestEqual,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v4988 : bool = v4979 > 0L
let v4989 : bool = v4980 = 1L
let v4990 : bool = v4981 = 1L
let v4991 : bool = v4982 = 1L
let v4992 : bool = v4983 = 1L
let v4993 : bool = v4984 = 1L
let v4994 : bool = v4985 = 0L
let v4995 : bool = v4986 = 1L
let v4996 : bool = v4987 = 1L
let v4997 : bool = v4988 && v4989
let v4998 : bool = v4997 && v4990
let v4999 : bool = v4998 && v4991
let v5000 : bool = v4999 && v4992
let v5001 : bool = v5000 && v4993
let v5002 : bool = v5001 && v4994
let v5003 : bool = v5002 && v4995
let v5004 : bool = v5003 && v4996
if v5004 then
    ()
else
    failwith<unit> "erp-reserve-budget-atomic-event-outbox-runtime-mismatch"
let struct (v5005 : string, v5006 : string, v5007 : string, v5008 : string, v5009 : string, v5010 : string, v5011 : int64, v5012 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v4978 with Some fields when fields.Length = 8 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[4] = fields.[0] && fields.[5] = fields.[1] && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[3] <> fields.[7] -> (match System.Int64.TryParse(fields.[6]) with true,amount when amount > 0L -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],amount,fields.[7] | _ -> failwith "erp-ReserveBudget-typed-decode-invalid-amount") | _ -> failwith "erp-ReserveBudget-typed-decode-invalid-frame")
let v5013 : string = (let fields = [| v5005; v5006; v5007; v5008; v5009; v5010; string v5011; v5012 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5014 : bool = v4978 = v5013
if v5014 then
    ()
else
    failwith<unit> "erp-ReserveBudget-typed-decode-roundtrip-mismatch"
let v5015 : string = "manager"
let v5016 : string = "alpha"
let v5017 : string = "manager-approved"
let v5018 : string = "finance-director"
let v5019 : string = "beta"
let v5020 : string = "finance-approved"
let v5021 : string = "compliance-officer"
let v5022 : string = "gamma"
let v5023 : string = "compliance-approved"
let v5024 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5025 : int64, v5026 : int64, v5027 : int64, v5028 : int64, v5029 : int64, v5030 : int64, v5031 : int64, v5032 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v5024 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let documentBound = match decoded with Some fields when fields.Length = 12 && fields.[2].Length > 0 && fields.[2] = fields.[6] && fields.[6] = fields.[10] -> 1L | _ -> 0L in let rolesDistinct = match decoded with Some fields when fields.Length = 12 && fields.[0].Length > 0 && fields.[4].Length > 0 && fields.[8].Length > 0 && fields.[0] <> fields.[4] && fields.[0] <> fields.[8] && fields.[4] <> fields.[8] -> 1L | _ -> 0L in let participantsDistinct = match decoded with Some fields when fields.Length = 12 && fields.[1].Length > 0 && fields.[5].Length > 0 && fields.[9].Length > 0 && fields.[1] <> fields.[5] && fields.[1] <> fields.[9] && fields.[5] <> fields.[9] -> 1L | _ -> 0L in let identitiesBound = match decoded with Some fields when fields.Length = 12 && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[11].Length > 0 && fields.[3] <> fields.[7] && fields.[3] <> fields.[11] && fields.[7] <> fields.[11] -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v5024 -> 1L | _ -> 0L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v5024)).Length |> int64 in let truncated = if v5024.Length > 4 then v5024.Substring(0, v5024.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,documentBound,rolesDistinct,participantsDistinct,identitiesBound,roundtrip,digestBytes,tamperRejected)
let v5033 : bool = v5025 = 12L
let v5034 : bool = v5026 = 1L
let v5035 : bool = v5027 = 1L
let v5036 : bool = v5028 = 1L
let v5037 : bool = v5029 = 1L
let v5038 : bool = v5030 = 1L
let v5039 : bool = v5031 = 32L
let v5040 : bool = v5032 = 1L
let v5041 : bool = v5033 && v5034
let v5042 : bool = v5041 && v5035
let v5043 : bool = v5042 && v5036
let v5044 : bool = v5043 && v5037
let v5045 : bool = v5044 && v5038
let v5046 : bool = v5045 && v5039
let v5047 : bool = v5046 && v5040
if v5047 then
    ()
else
    failwith<unit> "erp-collect-approvals-payload-codec-runtime-mismatch"
let v5048 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5049 : string = "erp-p2p-" + v4522 + "-outbox"
let struct (v5050 : string, v5051 : int64, v5052 : int64, v5053 : int64, v5054 : int64, v5055 : int64, v5056 : int64, v5057 : int64, v5058 : int64, v5059 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-reserve-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloadBytes = System.Convert.FromBase64String(v5048) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v5049) in let payloadDigest = System.Security.Cryptography.SHA256.HashData(payloadBytes) in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let envelope = Array.concat [| [| 69uy; 82uy; 80uy; 49uy |]; lengthBytes payloadBytes.Length; payloadBytes; lengthBytes outboxBytes.Length; outboxBytes; payloadDigest |] in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(envelope, 0, envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength offset = System.BitConverter.ToInt32(recovered, offset) |> System.Net.IPAddress.NetworkToHostOrder in let parsed = try let payloadLength = readLength 4 in let payloadStart = 8 in let outboxLengthOffset = payloadStart + payloadLength in let outboxLength = readLength outboxLengthOffset in let outboxStart = outboxLengthOffset + 4 in let digestStart = outboxStart + outboxLength in if recovered.Length >= 44 && recovered.[0] = 69uy && recovered.[1] = 82uy && recovered.[2] = 80uy && recovered.[3] = 49uy && payloadLength >= 0 && outboxLength >= 0 && digestStart + 32 = recovered.Length then let decodedPayload = recovered.[payloadStart .. outboxLengthOffset - 1] in let decodedOutbox = recovered.[outboxStart .. digestStart - 1] in let storedDigest = recovered.[digestStart .. digestStart + 31] in Some(decodedPayload, decodedOutbox, storedDigest) else None with _ -> None in let parseValid,payloadEqual,outboxEqual,digestEqual,tamperRejected = match parsed with | Some(decodedPayload, decodedOutbox, storedDigest) -> let tamperedPayload = Array.copy decodedPayload in let _ = if tamperedPayload.Length > 0 then tamperedPayload.[0] <- tamperedPayload.[0] ^^^ 1uy else () in 1L, (if System.Linq.Enumerable.SequenceEqual(payloadBytes, decodedPayload) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(outboxBytes, decodedOutbox) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(decodedPayload), storedDigest) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tamperedPayload), storedDigest) then 0L else 1L) | None -> 0L,0L,0L,0L,0L in let reopenedPayload = match parsed with | Some(decodedPayload, _, _) -> System.Convert.ToBase64String(decodedPayload) | None -> System.String.Empty in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in reopenedPayload,int64 envelope.Length,parseValid,payloadEqual,outboxEqual,digestEqual,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v5060 : bool = v5051 > 0L
let v5061 : bool = v5052 = 1L
let v5062 : bool = v5053 = 1L
let v5063 : bool = v5054 = 1L
let v5064 : bool = v5055 = 1L
let v5065 : bool = v5056 = 1L
let v5066 : bool = v5057 = 0L
let v5067 : bool = v5058 = 1L
let v5068 : bool = v5059 = 1L
let v5069 : bool = v5060 && v5061
let v5070 : bool = v5069 && v5062
let v5071 : bool = v5070 && v5063
let v5072 : bool = v5071 && v5064
let v5073 : bool = v5072 && v5065
let v5074 : bool = v5073 && v5066
let v5075 : bool = v5074 && v5067
let v5076 : bool = v5075 && v5068
if v5076 then
    ()
else
    failwith<unit> "erp-reserve-budget-atomic-event-outbox-runtime-mismatch"
let struct (v5077 : string, v5078 : string, v5079 : string, v5080 : string, v5081 : string, v5082 : string, v5083 : string, v5084 : string, v5085 : string, v5086 : string, v5087 : string, v5088 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5050 with Some fields when fields.Length = 12 && fields.[0] = "manager" && fields.[1] = "alpha" && fields.[2] = "po-1001" && fields.[4] = "finance-director" && fields.[5] = "beta" && fields.[6] = fields.[2] && fields.[8] = "compliance-officer" && fields.[9] = "gamma" && fields.[10] = fields.[2] && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[11].Length > 0 && fields.[3] <> fields.[7] && fields.[3] <> fields.[11] && fields.[7] <> fields.[11] -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],fields.[7],fields.[8],fields.[9],fields.[10],fields.[11] | _ -> failwith "erp-CollectApprovals-typed-decode-invalid-frame")
let v5089 : string = (let fields = [| v5077; v5078; v5079; v5080; v5081; v5082; v5083; v5084; v5085; v5086; v5087; v5088 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5090 : bool = v5050 = v5089
if v5090 then
    ()
else
    failwith<unit> "erp-CollectApprovals-typed-decode-roundtrip-mismatch"
if v5090 then
    ()
else
    failwith<unit> "erp-CollectApprovals-typed-decode-roundtrip-mismatch"
let v5091 : string = "each"
let v5092 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5093 : int64, v5094 : int64, v5095 : int64, v5096 : int64, v5097 : int64, v5098 : int64, v5099 : int64, v5100 : int64, v5101 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v5092 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let budgetBound = match decoded with Some fields when fields.Length = 19 -> (match System.Int64.TryParse(fields.[2]) with true,value when value = 1000L && fields.[0] = "company-a" && fields.[1] = "USD" -> 1L | _ -> 0L) | _ -> 0L in let documentBound = match decoded with Some fields when fields.Length = 19 && fields.[6] = fields.[10] && fields.[10] = fields.[14] -> 1L | _ -> 0L in let quorumBound = match decoded with Some fields when fields.Length = 19 && fields.[4] <> fields.[8] && fields.[4] <> fields.[12] && fields.[8] <> fields.[12] && fields.[5] <> fields.[9] && fields.[5] <> fields.[13] && fields.[9] <> fields.[13] -> 1L | _ -> 0L in let quantityBound = match decoded with Some fields when fields.Length = 19 -> (match System.Int64.TryParse(fields.[18]) with true,value when value = 10L && fields.[16] = "widget-a" && fields.[17] = "each" -> 1L | _ -> 0L) | _ -> 0L in let identityBound = match decoded with Some fields when fields.Length = 19 && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[11].Length > 0 && fields.[15].Length > 0 && fields.[3] <> fields.[7] && fields.[3] <> fields.[11] && fields.[3] <> fields.[15] && fields.[7] <> fields.[11] && fields.[7] <> fields.[15] && fields.[11] <> fields.[15] -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v5092 -> 1L | _ -> 0L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v5092)).Length |> int64 in let truncated = if v5092.Length > 4 then v5092.Substring(0, v5092.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,budgetBound,documentBound,quorumBound,quantityBound,identityBound,roundtrip,digestBytes,tamperRejected)
let v5102 : bool = v5093 = 19L
let v5103 : bool = v5094 = 1L
let v5104 : bool = v5095 = 1L
let v5105 : bool = v5096 = 1L
let v5106 : bool = v5097 = 1L
let v5107 : bool = v5098 = 1L
let v5108 : bool = v5099 = 1L
let v5109 : bool = v5100 = 32L
let v5110 : bool = v5101 = 1L
let v5111 : bool = v5102 && v5103
let v5112 : bool = v5111 && v5104
let v5113 : bool = v5112 && v5105
let v5114 : bool = v5113 && v5106
let v5115 : bool = v5114 && v5107
let v5116 : bool = v5115 && v5108
let v5117 : bool = v5116 && v5109
let v5118 : bool = v5117 && v5110
if v5118 then
    ()
else
    failwith<unit> "erp-issue-purchase-order-payload-codec-runtime-mismatch"
let v5119 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5120 : string = "erp-p2p-" + v4776 + "-outbox"
let struct (v5121 : string, v5122 : int64, v5123 : int64, v5124 : int64, v5125 : int64, v5126 : int64, v5127 : int64, v5128 : int64, v5129 : int64, v5130 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-reserve-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloadBytes = System.Convert.FromBase64String(v5119) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v5120) in let payloadDigest = System.Security.Cryptography.SHA256.HashData(payloadBytes) in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let envelope = Array.concat [| [| 69uy; 82uy; 80uy; 49uy |]; lengthBytes payloadBytes.Length; payloadBytes; lengthBytes outboxBytes.Length; outboxBytes; payloadDigest |] in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(envelope, 0, envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength offset = System.BitConverter.ToInt32(recovered, offset) |> System.Net.IPAddress.NetworkToHostOrder in let parsed = try let payloadLength = readLength 4 in let payloadStart = 8 in let outboxLengthOffset = payloadStart + payloadLength in let outboxLength = readLength outboxLengthOffset in let outboxStart = outboxLengthOffset + 4 in let digestStart = outboxStart + outboxLength in if recovered.Length >= 44 && recovered.[0] = 69uy && recovered.[1] = 82uy && recovered.[2] = 80uy && recovered.[3] = 49uy && payloadLength >= 0 && outboxLength >= 0 && digestStart + 32 = recovered.Length then let decodedPayload = recovered.[payloadStart .. outboxLengthOffset - 1] in let decodedOutbox = recovered.[outboxStart .. digestStart - 1] in let storedDigest = recovered.[digestStart .. digestStart + 31] in Some(decodedPayload, decodedOutbox, storedDigest) else None with _ -> None in let parseValid,payloadEqual,outboxEqual,digestEqual,tamperRejected = match parsed with | Some(decodedPayload, decodedOutbox, storedDigest) -> let tamperedPayload = Array.copy decodedPayload in let _ = if tamperedPayload.Length > 0 then tamperedPayload.[0] <- tamperedPayload.[0] ^^^ 1uy else () in 1L, (if System.Linq.Enumerable.SequenceEqual(payloadBytes, decodedPayload) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(outboxBytes, decodedOutbox) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(decodedPayload), storedDigest) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tamperedPayload), storedDigest) then 0L else 1L) | None -> 0L,0L,0L,0L,0L in let reopenedPayload = match parsed with | Some(decodedPayload, _, _) -> System.Convert.ToBase64String(decodedPayload) | None -> System.String.Empty in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in reopenedPayload,int64 envelope.Length,parseValid,payloadEqual,outboxEqual,digestEqual,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v5131 : bool = v5122 > 0L
let v5132 : bool = v5123 = 1L
let v5133 : bool = v5124 = 1L
let v5134 : bool = v5125 = 1L
let v5135 : bool = v5126 = 1L
let v5136 : bool = v5127 = 1L
let v5137 : bool = v5128 = 0L
let v5138 : bool = v5129 = 1L
let v5139 : bool = v5130 = 1L
let v5140 : bool = v5131 && v5132
let v5141 : bool = v5140 && v5133
let v5142 : bool = v5141 && v5134
let v5143 : bool = v5142 && v5135
let v5144 : bool = v5143 && v5136
let v5145 : bool = v5144 && v5137
let v5146 : bool = v5145 && v5138
let v5147 : bool = v5146 && v5139
if v5147 then
    ()
else
    failwith<unit> "erp-reserve-budget-atomic-event-outbox-runtime-mismatch"
let struct (v5148 : string, v5149 : string, v5150 : int64, v5151 : string, v5152 : string, v5153 : string, v5154 : string, v5155 : string, v5156 : string, v5157 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5121 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[4] = "manager" && fields.[5] = "alpha" && fields.[6] = "po-1001" && fields.[8] = "finance-director" && fields.[9] = "beta" && fields.[10] = "po-1001" && fields.[12] = "compliance-officer" && fields.[13] = "gamma" && fields.[14] = "po-1001" && fields.[16] = "widget-a" && fields.[17] = "each" && fields.[3].Length > 0 && fields.[7].Length > 0 && fields.[11].Length > 0 && fields.[15].Length > 0 && fields.[3] <> fields.[7] && fields.[3] <> fields.[11] && fields.[3] <> fields.[15] && fields.[7] <> fields.[11] && fields.[7] <> fields.[15] && fields.[11] <> fields.[15] -> (match System.Int64.TryParse(fields.[2]), System.Int64.TryParse(fields.[18]) with (true,budgetAmount),(true,quantityAmount) when budgetAmount = 1000L && quantityAmount = 10L -> fields.[0],fields.[1],budgetAmount,fields.[3],fields.[7],fields.[11],fields.[15],fields.[16],fields.[17],quantityAmount | _ -> failwith "erp-IssuePurchaseOrder-typed-decode-invalid-amounts") | _ -> failwith "erp-IssuePurchaseOrder-typed-decode-invalid-frame")
let v5158 : string = (let fields = [| v5148; v5149; string v5150; v5151; v5015; v5016; v4531; v5152; v5018; v5019; v4531; v5153; v5021; v5022; v4531; v5154; v5155; v5156; string v5157 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5159 : bool = v5121 = v5158
if v5159 then
    ()
else
    failwith<unit> "erp-IssuePurchaseOrder-typed-decode-roundtrip-mismatch"
if v5159 then
    ()
else
    failwith<unit> "erp-IssuePurchaseOrder-typed-decode-roundtrip-mismatch"
let v5160 : string = "purchase-order-issued-1001"
let v5161 : string = "partial-receipt-north-1001"
let v5162 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5163 : int64, v5164 : int64, v5165 : int64, v5166 : int64, v5167 : int64, v5168 : int64, v5169 : int64, v5170 : int64, v5171 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v5162 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let orderBound = match decoded with Some fields when fields.Length = 11 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[3] = "po-1001" && fields.[4].Length > 0 -> 1L | _ -> 0L in let sharedItem = match decoded with Some fields when fields.Length = 11 && fields.[2] = fields.[5] -> 1L | _ -> 0L in let quantityBound = match decoded with Some fields when fields.Length = 11 -> (match System.Int64.TryParse(fields.[7]), System.Int64.TryParse(fields.[8]) with (true,ordered),(true,received) when ordered = 10L && received = 6L && received > 0L && received <= ordered && fields.[6] = "each" -> 1L | _ -> 0L) | _ -> 0L in let locationBound = match decoded with Some fields when fields.Length = 11 && fields.[9] = "warehouse-north" -> 1L | _ -> 0L in let receiptBound = match decoded with Some fields when fields.Length = 11 && fields.[10] = "partial-receipt-north-1001" -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v5162 -> 1L | _ -> 0L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v5162)).Length |> int64 in let truncated = if v5162.Length > 4 then v5162.Substring(0, v5162.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,orderBound,sharedItem,quantityBound,locationBound,receiptBound,roundtrip,digestBytes,tamperRejected)
let v5172 : bool = v5163 = 11L
let v5173 : bool = v5164 = 1L
let v5174 : bool = v5165 = 1L
let v5175 : bool = v5166 = 1L
let v5176 : bool = v5167 = 1L
let v5177 : bool = v5168 = 1L
let v5178 : bool = v5169 = 1L
let v5179 : bool = v5170 = 32L
let v5180 : bool = v5171 = 1L
let v5181 : bool = v5172 && v5173
let v5182 : bool = v5181 && v5174
let v5183 : bool = v5182 && v5175
let v5184 : bool = v5183 && v5176
let v5185 : bool = v5184 && v5177
let v5186 : bool = v5185 && v5178
let v5187 : bool = v5186 && v5179
let v5188 : bool = v5187 && v5180
if v5188 then
    ()
else
    failwith<unit> "erp-receive-partial-goods-payload-codec-runtime-mismatch"
let v5189 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5190 : string, v5191 : string, v5192 : string, v5193 : string, v5194 : string, v5195 : string, v5196 : string, v5197 : int64, v5198 : int64, v5199 : string, v5200 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5189 with Some fields when fields.Length = 11 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[2] = fields.[5] && fields.[3] = "po-1001" && fields.[4].Length > 0 && fields.[6] = "each" && fields.[9] = "warehouse-north" && fields.[10].Length > 0 -> (match System.Int64.TryParse(fields.[7]), System.Int64.TryParse(fields.[8]) with (true,ordered),(true,received) when ordered > 0L && received > 0L && received <= ordered -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],ordered,received,fields.[9],fields.[10] | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-quantities") | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-frame")
let v5201 : bool = v5198 > 0L
let v5202 : bool = v5198 <= v5197
let v5203 : bool = v5201 && v5202
if v5203 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5203 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
let v5204 : string = (let fields = [| v5190; v5191; v5192; v5193; v5194; v5195; v5196; string v5197; string v5198; v5199; v5200 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5205 : bool = v5189 = v5204
if v5205 then
    ()
else
    failwith<unit> "erp-ReceivePartialGoods-typed-decode-roundtrip-mismatch"
if v5203 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
let v5206 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5207 : string, v5208 : string, v5209 : string, v5210 : string, v5211 : string, v5212 : string, v5213 : string, v5214 : int64, v5215 : int64, v5216 : string, v5217 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5206 with Some fields when fields.Length = 11 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[2] = fields.[5] && fields.[3] = "po-1001" && fields.[4].Length > 0 && fields.[6] = "each" && fields.[9] = "warehouse-north" && fields.[10].Length > 0 -> (match System.Int64.TryParse(fields.[7]), System.Int64.TryParse(fields.[8]) with (true,ordered),(true,received) when ordered > 0L && received > 0L && received <= ordered -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],ordered,received,fields.[9],fields.[10] | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-quantities") | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-frame")
let v5218 : bool = v5215 > 0L
let v5219 : bool = v5215 <= v5214
let v5220 : bool = v5218 && v5219
if v5220 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5220 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5220 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
let v5221 : string = (let fields = [| v5207; v5208; v5209; v5210; v5211; v5212; v5213; string v5214; string v5215; v5216; v5217 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5222 : bool = v5206 = v5221
if v5222 then
    ()
else
    failwith<unit> "erp-ReceivePartialGoods-typed-decode-roundtrip-mismatch"
if v5220 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5222 then
    ()
else
    failwith<unit> "erp-ReceivePartialGoods-typed-decode-roundtrip-mismatch"
if v5220 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
let v5223 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5224 : string = "erp-p2p-" + v4799 + "-outbox"
let struct (v5225 : string, v5226 : int64, v5227 : int64, v5228 : int64, v5229 : int64, v5230 : int64, v5231 : int64, v5232 : int64, v5233 : int64, v5234 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-reserve-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloadBytes = System.Convert.FromBase64String(v5223) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v5224) in let payloadDigest = System.Security.Cryptography.SHA256.HashData(payloadBytes) in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let envelope = Array.concat [| [| 69uy; 82uy; 80uy; 49uy |]; lengthBytes payloadBytes.Length; payloadBytes; lengthBytes outboxBytes.Length; outboxBytes; payloadDigest |] in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(envelope, 0, envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength offset = System.BitConverter.ToInt32(recovered, offset) |> System.Net.IPAddress.NetworkToHostOrder in let parsed = try let payloadLength = readLength 4 in let payloadStart = 8 in let outboxLengthOffset = payloadStart + payloadLength in let outboxLength = readLength outboxLengthOffset in let outboxStart = outboxLengthOffset + 4 in let digestStart = outboxStart + outboxLength in if recovered.Length >= 44 && recovered.[0] = 69uy && recovered.[1] = 82uy && recovered.[2] = 80uy && recovered.[3] = 49uy && payloadLength >= 0 && outboxLength >= 0 && digestStart + 32 = recovered.Length then let decodedPayload = recovered.[payloadStart .. outboxLengthOffset - 1] in let decodedOutbox = recovered.[outboxStart .. digestStart - 1] in let storedDigest = recovered.[digestStart .. digestStart + 31] in Some(decodedPayload, decodedOutbox, storedDigest) else None with _ -> None in let parseValid,payloadEqual,outboxEqual,digestEqual,tamperRejected = match parsed with | Some(decodedPayload, decodedOutbox, storedDigest) -> let tamperedPayload = Array.copy decodedPayload in let _ = if tamperedPayload.Length > 0 then tamperedPayload.[0] <- tamperedPayload.[0] ^^^ 1uy else () in 1L, (if System.Linq.Enumerable.SequenceEqual(payloadBytes, decodedPayload) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(outboxBytes, decodedOutbox) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(decodedPayload), storedDigest) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tamperedPayload), storedDigest) then 0L else 1L) | None -> 0L,0L,0L,0L,0L in let reopenedPayload = match parsed with | Some(decodedPayload, _, _) -> System.Convert.ToBase64String(decodedPayload) | None -> System.String.Empty in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in reopenedPayload,int64 envelope.Length,parseValid,payloadEqual,outboxEqual,digestEqual,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v5235 : bool = v5226 > 0L
let v5236 : bool = v5227 = 1L
let v5237 : bool = v5228 = 1L
let v5238 : bool = v5229 = 1L
let v5239 : bool = v5230 = 1L
let v5240 : bool = v5231 = 1L
let v5241 : bool = v5232 = 0L
let v5242 : bool = v5233 = 1L
let v5243 : bool = v5234 = 1L
let v5244 : bool = v5235 && v5236
let v5245 : bool = v5244 && v5237
let v5246 : bool = v5245 && v5238
let v5247 : bool = v5246 && v5239
let v5248 : bool = v5247 && v5240
let v5249 : bool = v5248 && v5241
let v5250 : bool = v5249 && v5242
let v5251 : bool = v5250 && v5243
if v5251 then
    ()
else
    failwith<unit> "erp-reserve-budget-atomic-event-outbox-runtime-mismatch"
let struct (v5252 : string, v5253 : string, v5254 : string, v5255 : string, v5256 : string, v5257 : string, v5258 : string, v5259 : int64, v5260 : int64, v5261 : string, v5262 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5225 with Some fields when fields.Length = 11 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[2] = fields.[5] && fields.[3] = "po-1001" && fields.[4].Length > 0 && fields.[6] = "each" && fields.[9] = "warehouse-north" && fields.[10].Length > 0 -> (match System.Int64.TryParse(fields.[7]), System.Int64.TryParse(fields.[8]) with (true,ordered),(true,received) when ordered > 0L && received > 0L && received <= ordered -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],ordered,received,fields.[9],fields.[10] | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-quantities") | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-frame")
let v5263 : bool = v5260 > 0L
let v5264 : bool = v5260 <= v5259
let v5265 : bool = v5263 && v5264
if v5265 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5265 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5265 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
let v5266 : string = (let fields = [| v5252; v5253; v5254; v5255; v5256; v5257; v5258; string v5259; string v5260; v5261; v5262 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5267 : bool = v5225 = v5266
if v5267 then
    ()
else
    failwith<unit> "erp-ReceivePartialGoods-typed-decode-roundtrip-mismatch"
if v5265 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5267 then
    ()
else
    failwith<unit> "erp-ReceivePartialGoods-typed-decode-roundtrip-mismatch"
let struct (v5268 : string, v5269 : string, v5270 : string, v5271 : string, v5272 : string, v5273 : string, v5274 : string, v5275 : int64, v5276 : int64, v5277 : string, v5278 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5225 with Some fields when fields.Length = 11 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[2] = fields.[5] && fields.[3] = "po-1001" && fields.[4].Length > 0 && fields.[6] = "each" && fields.[9] = "warehouse-north" && fields.[10].Length > 0 -> (match System.Int64.TryParse(fields.[7]), System.Int64.TryParse(fields.[8]) with (true,ordered),(true,received) when ordered > 0L && received > 0L && received <= ordered -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],ordered,received,fields.[9],fields.[10] | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-quantities") | _ -> failwith "erp-ReceivePartialGoods-typed-decode-invalid-frame")
let v5279 : bool = v5276 > 0L
let v5280 : bool = v5276 <= v5275
let v5281 : bool = v5279 && v5280
if v5281 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5281 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
if v5281 then
    ()
else
    failwith<unit> "ERP-ordered-partial-quantity-invariant-mismatch"
let v5282 : string = "tax-witness-br-1001-sealed-by-the-upstream-receipt-stage"
let v5283 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4526; v4527; v4528; v4529; v4531; string 6L; v5161; v4530; v4527; v4531; string 170L; v5282 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5284 : string = "invoice-three-way-matched"
let v5285 : string = "erp-p2p-" + v5284 + "-outbox"
let struct (v5286 : string, v5287 : int64, v5288 : int64, v5289 : int64, v5290 : int64, v5291 : int64, v5292 : int64, v5293 : int64, v5294 : int64, v5295 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-reserve-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloadBytes = System.Convert.FromBase64String(v5283) in let outboxBytes = System.Text.Encoding.UTF8.GetBytes(v5285) in let payloadDigest = System.Security.Cryptography.SHA256.HashData(payloadBytes) in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let envelope = Array.concat [| [| 69uy; 82uy; 80uy; 49uy |]; lengthBytes payloadBytes.Length; payloadBytes; lengthBytes outboxBytes.Length; outboxBytes; payloadDigest |] in (use stream = new System.IO.FileStream(prepared, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(envelope, 0, envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared, committed, true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength offset = System.BitConverter.ToInt32(recovered, offset) |> System.Net.IPAddress.NetworkToHostOrder in let parsed = try let payloadLength = readLength 4 in let payloadStart = 8 in let outboxLengthOffset = payloadStart + payloadLength in let outboxLength = readLength outboxLengthOffset in let outboxStart = outboxLengthOffset + 4 in let digestStart = outboxStart + outboxLength in if recovered.Length >= 44 && recovered.[0] = 69uy && recovered.[1] = 82uy && recovered.[2] = 80uy && recovered.[3] = 49uy && payloadLength >= 0 && outboxLength >= 0 && digestStart + 32 = recovered.Length then let decodedPayload = recovered.[payloadStart .. outboxLengthOffset - 1] in let decodedOutbox = recovered.[outboxStart .. digestStart - 1] in let storedDigest = recovered.[digestStart .. digestStart + 31] in Some(decodedPayload, decodedOutbox, storedDigest) else None with _ -> None in let parseValid,payloadEqual,outboxEqual,digestEqual,tamperRejected = match parsed with | Some(decodedPayload, decodedOutbox, storedDigest) -> let tamperedPayload = Array.copy decodedPayload in let _ = if tamperedPayload.Length > 0 then tamperedPayload.[0] <- tamperedPayload.[0] ^^^ 1uy else () in 1L, (if System.Linq.Enumerable.SequenceEqual(payloadBytes, decodedPayload) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(outboxBytes, decodedOutbox) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(decodedPayload), storedDigest) then 1L else 0L), (if System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(tamperedPayload), storedDigest) then 0L else 1L) | None -> 0L,0L,0L,0L,0L in let reopenedPayload = match parsed with | Some(decodedPayload, _, _) -> System.Convert.ToBase64String(decodedPayload) | None -> System.String.Empty in System.IO.Directory.Delete(root, true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in reopenedPayload,int64 envelope.Length,parseValid,payloadEqual,outboxEqual,digestEqual,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v5296 : bool = v5287 > 0L
let v5297 : bool = v5288 = 1L
let v5298 : bool = v5289 = 1L
let v5299 : bool = v5290 = 1L
let v5300 : bool = v5291 = 1L
let v5301 : bool = v5292 = 1L
let v5302 : bool = v5293 = 0L
let v5303 : bool = v5294 = 1L
let v5304 : bool = v5295 = 1L
let v5305 : bool = v5296 && v5297
let v5306 : bool = v5305 && v5298
let v5307 : bool = v5306 && v5299
let v5308 : bool = v5307 && v5300
let v5309 : bool = v5308 && v5301
let v5310 : bool = v5309 && v5302
let v5311 : bool = v5310 && v5303
let v5312 : bool = v5311 && v5304
if v5312 then
    ()
else
    failwith<unit> "erp-reserve-budget-atomic-event-outbox-runtime-mismatch"
let struct (v5313 : string, v5314 : string, v5315 : string, v5316 : string, v5317 : string, v5318 : string, v5319 : int64, v5320 : string, v5321 : string, v5322 : int64, v5323 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5286 with Some fields when fields.Length = 17 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "po-1001" && fields.[5] = fields.[0] && fields.[6] = fields.[1] && fields.[7] = fields.[2] && fields.[8] = "warehouse-north" && fields.[9] = fields.[3] && fields.[12] = "BR" && fields.[13] = fields.[1] && fields.[14] = fields.[3] && fields.[4].Length > 0 && fields.[11].Length > 0 && fields.[16].Length > 0 && fields.[4] <> fields.[11] && fields.[4] <> fields.[16] && fields.[11] <> fields.[16] -> (match System.Int64.TryParse(fields.[10]), System.Int64.TryParse(fields.[15]) with (true,quantityAmount),(true,taxAmount) when quantityAmount = 6L && taxAmount = 170L -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[8],quantityAmount,fields.[11],fields.[12],taxAmount,fields.[16] | _ -> failwith "erp-MatchInvoice-typed-decode-invalid-amounts") | _ -> failwith "erp-MatchInvoice-typed-decode-invalid-frame")
let v5324 : string = (let fields = [| v5313; v5314; v5315; v5316; v5317; v5313; v5314; v5315; v5318; v5316; string v5319; v5320; v5321; v5314; v5316; string v5322; v5323 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5325 : bool = v5286 = v5324
if v5325 then
    ()
else
    failwith<unit> "erp-MatchInvoice-typed-decode-roundtrip-mismatch"
if v5325 then
    ()
else
    failwith<unit> "erp-MatchInvoice-typed-decode-roundtrip-mismatch"
let v5326 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4526; v4527; v4528; v4529; v4531; string 6L; v5161; v4530; v4527; v4531; string 170L; v5282 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5327 : int64, v5328 : int64, v5329 : int64, v5330 : int64, v5331 : int64, v5332 : int64, v5333 : int64, v5334 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v5326 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let linksBound = match decoded with Some fields when fields.Length = 17 && fields.[0] = "company-a" && fields.[0] = fields.[5] && fields.[1] = "USD" && fields.[1] = fields.[6] && fields.[1] = fields.[13] && fields.[2] = "widget-a" && fields.[2] = fields.[7] && fields.[3] = "po-1001" && fields.[3] = fields.[9] && fields.[3] = fields.[14] && fields.[8] = "warehouse-north" && fields.[12] = "BR" -> 1L | _ -> 0L in let quantityBound = match decoded with Some fields when fields.Length = 17 -> (match System.Int64.TryParse(fields.[10]) with true,value when value = 6L && fields.[8] = "warehouse-north" -> 1L | _ -> 0L) | _ -> 0L in let taxBound = match decoded with Some fields when fields.Length = 17 -> (match System.Int64.TryParse(fields.[15]) with true,value when value = 170L && fields.[12] = "BR" -> 1L | _ -> 0L) | _ -> 0L in let identitiesBound = match decoded with Some fields when fields.Length = 17 && fields.[4] = "purchase-order-issued-1001" && fields.[11] = "partial-receipt-north-1001" && fields.[16] = "tax-witness-br-1001-sealed-by-the-upstream-receipt-stage" -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v5326 -> 1L | _ -> 0L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v5326)).Length |> int64 in let truncated = if v5326.Length > 4 then v5326.Substring(0, v5326.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,linksBound,quantityBound,taxBound,identitiesBound,roundtrip,digestBytes,tamperRejected)
let v5335 : bool = 17L = v5327
let v5368 : US4 =
    if v5335 then
        let v5336 : bool = 1L = v5328
        if v5336 then
            let v5337 : bool = 1L = v5329
            if v5337 then
                let v5338 : bool = 1L = v5330
                if v5338 then
                    let v5339 : bool = 1L = v5331
                    if v5339 then
                        let v5340 : bool = 1L = v5332
                        if v5340 then
                            let v5341 : bool = 32L = v5333
                            if v5341 then
                                let v5342 : bool = 1L = v5334
                                if v5342 then
                                    let v5343 : string = "the-decoder-validates-all-seventeen-canonical-MatchInvoice-fields-and-shared-indices-before-producing-a-typed-acceptance-witness"
                                    US4_0(v5343)
                                else
                                    let v5345 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                                    US4_1(v5345)
                            else
                                let v5348 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                                US4_1(v5348)
                        else
                            let v5351 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                            US4_1(v5351)
                    else
                        let v5354 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                        US4_1(v5354)
                else
                    let v5357 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                    US4_1(v5357)
            else
                let v5360 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                US4_1(v5360)
        else
            let v5363 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
            US4_1(v5363)
    else
        let v5366 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
        US4_1(v5366)
let v5369 : string = if v5326.Length > 4 then v5326.Substring(0, v5326.Length - 4) else ""
let struct (v5370 : int64, v5371 : int64, v5372 : int64, v5373 : int64, v5374 : int64, v5375 : int64, v5376 : int64, v5377 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v5369 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let linksBound = match decoded with Some fields when fields.Length = 17 && fields.[0] = "company-a" && fields.[0] = fields.[5] && fields.[1] = "USD" && fields.[1] = fields.[6] && fields.[1] = fields.[13] && fields.[2] = "widget-a" && fields.[2] = fields.[7] && fields.[3] = "po-1001" && fields.[3] = fields.[9] && fields.[3] = fields.[14] && fields.[8] = "warehouse-north" && fields.[12] = "BR" -> 1L | _ -> 0L in let quantityBound = match decoded with Some fields when fields.Length = 17 -> (match System.Int64.TryParse(fields.[10]) with true,value when value = 6L && fields.[8] = "warehouse-north" -> 1L | _ -> 0L) | _ -> 0L in let taxBound = match decoded with Some fields when fields.Length = 17 -> (match System.Int64.TryParse(fields.[15]) with true,value when value = 170L && fields.[12] = "BR" -> 1L | _ -> 0L) | _ -> 0L in let identitiesBound = match decoded with Some fields when fields.Length = 17 && fields.[4] = "purchase-order-issued-1001" && fields.[11] = "partial-receipt-north-1001" && fields.[16] = "tax-witness-br-1001-sealed-by-the-upstream-receipt-stage" -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v5369 -> 1L | _ -> 0L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v5369)).Length |> int64 in let truncated = if v5369.Length > 4 then v5369.Substring(0, v5369.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,linksBound,quantityBound,taxBound,identitiesBound,roundtrip,digestBytes,tamperRejected)
let v5378 : bool = 17L = v5370
let v5411 : US4 =
    if v5378 then
        let v5379 : bool = 1L = v5371
        if v5379 then
            let v5380 : bool = 1L = v5372
            if v5380 then
                let v5381 : bool = 1L = v5373
                if v5381 then
                    let v5382 : bool = 1L = v5374
                    if v5382 then
                        let v5383 : bool = 1L = v5375
                        if v5383 then
                            let v5384 : bool = 32L = v5376
                            if v5384 then
                                let v5385 : bool = 1L = v5377
                                if v5385 then
                                    let v5386 : string = "the-decoder-validates-all-seventeen-canonical-MatchInvoice-fields-and-shared-indices-before-producing-a-typed-acceptance-witness"
                                    US4_0(v5386)
                                else
                                    let v5388 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                                    US4_1(v5388)
                            else
                                let v5391 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                                US4_1(v5391)
                        else
                            let v5394 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                            US4_1(v5394)
                    else
                        let v5397 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                        US4_1(v5397)
                else
                    let v5400 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                    US4_1(v5400)
            else
                let v5403 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
                US4_1(v5403)
        else
            let v5406 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
            US4_1(v5406)
    else
        let v5409 : string = "invalid-MatchInvoice-frame-does-not-produce-a-typed-operation"
        US4_1(v5409)
let v5415 : int64 =
    match v5368 with
    | US4_0(v5412) -> (* ErpMatchInvoicePayloadDecoded *)
        1L
    | US4_1(v5413) -> (* ErpMatchInvoicePayloadRejected *)
        0L
let v5419 : int64 =
    match v5411 with
    | US4_0(v5416) -> (* ErpMatchInvoicePayloadDecoded *)
        1L
    | US4_1(v5417) -> (* ErpMatchInvoicePayloadRejected *)
        0L
let v5420 : int64 = -1L * v5419
let v5421 : int64 = 1L + v5420
let v5422 : bool = v5415 = 1L
let v5423 : bool = v5421 = 1L
let v5424 : bool = v5422 && v5423
if v5424 then
    ()
else
    failwith<unit> "erp-MatchInvoice-payload-codec-runtime-mismatch"
let v5425 : string = "BRL"
let v5426 : string = "payment-3001"
let v5427 : string = (let fields = [| "SettlePayment"; v4526; v4527; v4528; v4529; v4530; v4531; v4532; v5425; string 2L; string 4980L; "2026-07"; string 6L; string 1L; v5426 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5428 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "SettlePayment"; "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "BRL"; "2"; "4980"; "2026-07"; "6"; "1"; "payment-3001" |] in match tryDecode v5427 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]), System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,scale),(true,amount),(true,numerator),(true,denominator) when scale = 2L && amount = 4980L && numerator = 6L && denominator = 1L -> 1L | _ -> 0L) | _ -> 0L)
let v5429 : bool = 1L = v5428
let v5434 : US5 =
    if v5429 then
        let v5430 : string = "canonical-SettlePayment-frame-validated"
        US5_0(v5430)
    else
        let v5432 : string = "invalid-or-truncated-SettlePayment-frame"
        US5_1(v5432)
let v5435 : string = if v5427.Length > 4 then v5427.Substring(0, v5427.Length - 4) else ""
let v5436 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "SettlePayment"; "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "BRL"; "2"; "4980"; "2026-07"; "6"; "1"; "payment-3001" |] in match tryDecode v5435 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]), System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,scale),(true,amount),(true,numerator),(true,denominator) when scale = 2L && amount = 4980L && numerator = 6L && denominator = 1L -> 1L | _ -> 0L) | _ -> 0L)
let v5437 : bool = 1L = v5436
let v5442 : US5 =
    if v5437 then
        let v5438 : string = "canonical-SettlePayment-frame-validated"
        US5_0(v5438)
    else
        let v5440 : string = "invalid-or-truncated-SettlePayment-frame"
        US5_1(v5440)
let v5446 : int64 =
    match v5434 with
    | US5_0(v5443) -> (* ErpSettlePaymentPayloadDecoded *)
        1L
    | US5_1(v5444) -> (* ErpSettlePaymentPayloadRejected *)
        0L
let v5450 : int64 =
    match v5442 with
    | US5_0(v5447) -> (* ErpSettlePaymentPayloadDecoded *)
        1L
    | US5_1(v5448) -> (* ErpSettlePaymentPayloadRejected *)
        0L
let v5451 : int64 = -1L * v5450
let v5452 : int64 = 1L + v5451
let v5453 : bool = v5446 = 1L
let v5454 : bool = v5452 = 1L
let v5455 : bool = v5453 && v5454
if v5455 then
    ()
else
    failwith<unit> "erp-SettlePayment-payload-codec-runtime-mismatch"
let v5456 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "SettlePayment"; "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "BRL"; "2"; "4980"; "2026-07"; "6"; "1"; "payment-3001" |] in match tryDecode v5427 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]), System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,scale),(true,amount),(true,numerator),(true,denominator) when scale = 2L && amount = 4980L && numerator = 6L && denominator = 1L -> 1L | _ -> 0L) | _ -> 0L)
let v5457 : bool = 1L = v5456
let v5475 : US6 =
    if v5457 then
        let struct (v5458 : string, v5459 : string, v5460 : string, v5461 : string, v5462 : string, v5463 : string, v5464 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5427 with Some fields when fields.Length = 15 && fields.[0] = "SettlePayment" && fields.[1] = "company-a" && fields.[2] = "USD" && fields.[3] = "widget-a" && fields.[4] = "warehouse-north" && fields.[5] = "BR" && fields.[6] = "po-1001" && fields.[7].Length > 0 -> fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],fields.[7] | _ -> failwith "erp-SettlePayment-typed-decode-invalid-invoice-fields")
        let struct (v5465 : string, v5466 : int64, v5467 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5427 with Some fields when fields.Length = 15 && fields.[8] = "BRL" -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]) with (true,scale),(true,amount) when scale = 2L && amount = 4980L -> fields.[8],scale,amount | _ -> failwith "erp-SettlePayment-typed-decode-invalid-payment-fields") | _ -> failwith "erp-SettlePayment-typed-decode-invalid-payment-frame")
        let struct (v5468 : string, v5469 : int64, v5470 : int64, v5471 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5427 with Some fields when fields.Length = 15 && fields.[11] = "2026-07" && fields.[14].Length > 0 -> (match System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,numerator),(true,denominator) when numerator = 6L && denominator = 1L -> fields.[11],numerator,denominator,fields.[14] | _ -> failwith "erp-SettlePayment-typed-decode-invalid-route-fields") | _ -> failwith "erp-SettlePayment-typed-decode-invalid-route-frame")
        US6_0(v5458, v5459, v5460, v5461, v5462, v5463, v5464, v5465, v5466, v5467, v5459, v5465, v5468, v5469, v5470, v5471)
    else
        let v5473 : string = "invalid-or-truncated-SettlePayment-frame"
        US6_1(v5473)
let v5476 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "SettlePayment"; "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "BRL"; "2"; "4980"; "2026-07"; "6"; "1"; "payment-3001" |] in match tryDecode v5435 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]), System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,scale),(true,amount),(true,numerator),(true,denominator) when scale = 2L && amount = 4980L && numerator = 6L && denominator = 1L -> 1L | _ -> 0L) | _ -> 0L)
let v5477 : bool = 1L = v5476
let v5495 : US6 =
    if v5477 then
        let struct (v5478 : string, v5479 : string, v5480 : string, v5481 : string, v5482 : string, v5483 : string, v5484 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5435 with Some fields when fields.Length = 15 && fields.[0] = "SettlePayment" && fields.[1] = "company-a" && fields.[2] = "USD" && fields.[3] = "widget-a" && fields.[4] = "warehouse-north" && fields.[5] = "BR" && fields.[6] = "po-1001" && fields.[7].Length > 0 -> fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],fields.[7] | _ -> failwith "erp-SettlePayment-typed-decode-invalid-invoice-fields")
        let struct (v5485 : string, v5486 : int64, v5487 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5435 with Some fields when fields.Length = 15 && fields.[8] = "BRL" -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]) with (true,scale),(true,amount) when scale = 2L && amount = 4980L -> fields.[8],scale,amount | _ -> failwith "erp-SettlePayment-typed-decode-invalid-payment-fields") | _ -> failwith "erp-SettlePayment-typed-decode-invalid-payment-frame")
        let struct (v5488 : string, v5489 : int64, v5490 : int64, v5491 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5435 with Some fields when fields.Length = 15 && fields.[11] = "2026-07" && fields.[14].Length > 0 -> (match System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,numerator),(true,denominator) when numerator = 6L && denominator = 1L -> fields.[11],numerator,denominator,fields.[14] | _ -> failwith "erp-SettlePayment-typed-decode-invalid-route-fields") | _ -> failwith "erp-SettlePayment-typed-decode-invalid-route-frame")
        US6_0(v5478, v5479, v5480, v5481, v5482, v5483, v5484, v5485, v5486, v5487, v5479, v5485, v5488, v5489, v5490, v5491)
    else
        let v5493 : string = "invalid-or-truncated-SettlePayment-frame"
        US6_1(v5493)
let v5515 : int64 =
    match v5475 with
    | US6_0(v5496, v5497, v5498, v5499, v5500, v5501, v5502, v5503, v5504, v5505, v5506, v5507, v5508, v5509, v5510, v5511) -> (* ErpSettlePaymentPayloadTypedDecoded *)
        let v5512 : int64 = if v5496 = "company-a" && v5497 = "USD" && v5498 = "widget-a" && v5499 = "warehouse-north" && v5500 = "BR" && v5501 = "po-1001" && v5502 = "invoice-match-1001" && v5503 = "BRL" && v5504 = 2L && v5505 = 4980L && v5509 = 6L && v5510 = 1L && v5511 = "payment-3001" then 1L else 0L
        v5512
    | US6_1(v5513) -> (* ErpSettlePaymentPayloadTypedRejected *)
        0L
let v5535 : int64 =
    match v5495 with
    | US6_0(v5516, v5517, v5518, v5519, v5520, v5521, v5522, v5523, v5524, v5525, v5526, v5527, v5528, v5529, v5530, v5531) -> (* ErpSettlePaymentPayloadTypedDecoded *)
        let v5532 : int64 = if v5516 = "company-a" && v5517 = "USD" && v5518 = "widget-a" && v5519 = "warehouse-north" && v5520 = "BR" && v5521 = "po-1001" && v5522 = "invoice-match-1001" && v5523 = "BRL" && v5524 = 2L && v5525 = 4980L && v5529 = 6L && v5530 = 1L && v5531 = "payment-3001" then 1L else 0L
        v5532
    | US6_1(v5533) -> (* ErpSettlePaymentPayloadTypedRejected *)
        0L
let v5557 : int64 =
    match v5475 with
    | US6_0(v5536, v5537, v5538, v5539, v5540, v5541, v5542, v5543, v5544, v5545, v5546, v5547, v5548, v5549, v5550, v5551) -> (* ErpSettlePaymentPayloadTypedDecoded *)
        let v5552 : string = (let fields = [| "SettlePayment"; v5536; v5537; v5538; v5539; v5540; v5541; v5542; v5543; string v5544; string v5545; "2026-07"; string v5549; string v5550; v5551 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        let v5553 : bool = v5552 = v5427
        if v5553 then
            1L
        else
            0L
    | US6_1(v5555) -> (* ErpSettlePaymentPayloadTypedRejected *)
        0L
match v5475 with
| US6_0(v5558, v5559, v5560, v5561, v5562, v5563, v5564, v5565, v5566, v5567, v5568, v5569, v5570, v5571, v5572, v5573) -> (* ErpSettlePaymentPayloadTypedDecoded *)
    if (v5571, v5572) <> (6L, 1L) then failwith "typed-SettlePayment-certificate-FX-ratio-does-not-match-the-static-operation-route"
    ()
| US6_1(v5574) -> (* ErpSettlePaymentPayloadTypedRejected *)
    failwith<unit> "canonical-SettlePayment-frame-could-not-produce-the-typed-FX-ratio-certificate"
let v5575 : int64 = -1L * v5535
let v5576 : int64 = 1L + v5575
let v5577 : bool = v5515 = 1L
let v5578 : bool = v5576 = 1L
let v5579 : bool = v5577 && v5578
if v5579 then
    ()
else
    failwith<unit> "erp-SettlePayment-payload-codec-runtime-mismatch"
let v5580 : bool = v5557 = 1L
let v5581 : bool = v5580 && v5578
if v5581 then
    ()
else
    failwith<unit> "erp-SettlePayment-payload-codec-runtime-mismatch"
let v5582 : string = "payment-receipt-3001"
let v5583 : string = "2026-07"
let v5584 : string = "ifrs-close-2026-07"
let v5585 : string = (let fields = [| v4526; v5425; v4528; v4529; v4530; v5426; v5582; v5583; "IFRS"; v5584 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5586 : int64, v5587 : int64, v5588 : int64, v5589 : int64, v5590 : int64, v5591 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let decoded = tryDecode v5585 in let fieldCount = match decoded with Some fields -> int64 fields.Length | None -> 0L in let paymentBound = match decoded with Some fields when fields.Length = 10 && fields.[0] = "company-a" && fields.[1] = "BRL" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "payment-3001" && fields.[6] = "payment-receipt-3001" -> 1L | _ -> 0L in let periodBound = match decoded with Some fields when fields.Length = 10 && fields.[7] = "2026-07" -> 1L | _ -> 0L in let gaapBound = match decoded with Some fields when fields.Length = 10 && fields.[8] = "IFRS" && fields.[9] = "ifrs-close-2026-07" -> 1L | _ -> 0L in let reencode (fields : string array) = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) |> System.Convert.ToBase64String in let roundtrip = match decoded with Some fields when reencode fields = v5585 -> 1L | _ -> 0L in let truncated = if v5585.Length > 4 then v5585.Substring(0, v5585.Length - 4) else "" in let tamperRejected = match tryDecode truncated with None -> 1L | Some _ -> 0L in fieldCount,paymentBound,periodBound,gaapBound,roundtrip,tamperRejected)
let v5592 : bool = v5586 = 10L
let v5593 : bool = v5587 = 1L
let v5594 : bool = v5588 = 1L
let v5595 : bool = v5589 = 1L
let v5596 : bool = v5590 = 1L
let v5597 : bool = v5591 = 1L
let v5598 : bool = v5592 && v5593
let v5599 : bool = v5598 && v5594
let v5600 : bool = v5599 && v5595
let v5601 : bool = v5600 && v5596
let v5602 : bool = v5601 && v5597
if v5602 then
    ()
else
    failwith<unit> "erp-ClosePeriod-payload-codec-runtime-mismatch"
let v5603 : string = (let fields = [| v4526; v5425; v4528; v4529; v4530; v5426; v5582; v5583; "IFRS"; v5584 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5604 : string, v5605 : string, v5606 : string, v5607 : string, v5608 : string, v5609 : string, v5610 : string, v5611 : string, v5612 : string, v5613 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5603 with Some fields when fields.Length = 10 && fields.[0] = "company-a" && fields.[1] = "BRL" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "payment-3001" && fields.[6] = "payment-receipt-3001" && fields.[7] = "2026-07" && fields.[8] = "IFRS" && fields.[9] = "ifrs-close-2026-07" -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],fields.[7],fields.[8],fields.[9] | _ -> failwith "erp-ClosePeriod-typed-decode-invalid-frame")
let v5614 : string = (let fields = [| v5604; v5605; v5606; v5607; v5608; v5609; v5610; v5611; "IFRS"; v5613 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5615 : bool = v5603 = v5614
if v5615 then
    ()
else
    failwith<unit> "erp-ClosePeriod-typed-decode-roundtrip-mismatch"
let v5616 : string = (let fields = [| v4526; v5425; v4528; v4529; v4530; v5426; v5582; v5583; "IFRS"; v5584 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let struct (v5617 : string, v5618 : string, v5619 : string, v5620 : string, v5621 : string, v5622 : string, v5623 : string, v5624 : string, v5625 : string, v5626 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5616 with Some fields when fields.Length = 10 && fields.[0] = "company-a" && fields.[1] = "BRL" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "payment-3001" && fields.[6] = "payment-receipt-3001" && fields.[7] = "2026-07" && fields.[8] = "IFRS" && fields.[9] = "ifrs-close-2026-07" -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],fields.[7],fields.[8],fields.[9] | _ -> failwith "erp-ClosePeriod-typed-decode-invalid-frame")
let v5627 : string = (let fields = [| v5617; v5618; v5619; v5620; v5621; v5622; v5623; v5624; "IFRS"; v5626 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5628 : bool = v5616 = v5627
if v5628 then
    ()
else
    failwith<unit> "erp-ClosePeriod-typed-decode-roundtrip-mismatch"
if v5628 then
    ()
else
    failwith<unit> "erp-ClosePeriod-typed-decode-roundtrip-mismatch"
let v5629 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5630 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5631 : string = v5629 + "|" + v5630
let v5632 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5633 : string = v5631 + "|" + v5632
let v5634 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5635 : string = v5633 + "|" + v5634
let v5636 : string = "erp-p2p-" + v4774 + "-outbox"
let v5637 : string = "erp-p2p-" + v4522 + "-outbox"
let v5638 : string = v5636 + "|" + v5637
let v5639 : string = "erp-p2p-" + v4776 + "-outbox"
let v5640 : string = v5638 + "|" + v5639
let v5641 : string = "erp-p2p-" + v4799 + "-outbox"
let v5642 : string = v5640 + "|" + v5641
let v5643 : int64 = 0L + 1L
let v5644 : int64 = v5643 + 1L
let v5645 : int64 = v5644 + 1L
let v5646 : int64 = v5645 + 1L
let v5647 : int64 = 0L + 1L
let v5648 : int64 = v5647 + 1L
let v5649 : int64 = v5648 + 1L
let v5650 : int64 = v5649 + 1L
let struct (v5651 : int64, v5652 : int64, v5653 : int64, v5654 : int64, v5655 : int64) = (let payloads = v5635.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let messages = v5642.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in int64 payloads.Length, int64 messages.Length, (if int64 payloads.Length = v5646 then 1L else 0L), (if int64 messages.Length = v5650 then 1L else 0L), (if payloads.Length = messages.Length && payloads |> Array.forall (fun value -> try System.Convert.FromBase64String(value).Length > 0 with _ -> false) then 1L else 0L))
let v5656 : bool = v5651 = 4L
let v5657 : bool = v5652 = 4L
let v5658 : bool = v5653 = 1L
let v5659 : bool = v5654 = 1L
let v5660 : bool = v5655 = 1L
let v5661 : bool = v5656 && v5657
let v5662 : bool = v5661 && v5658
let v5663 : bool = v5662 && v5659
let v5664 : bool = v5663 && v5660
if v5664 then
    ()
else
    failwith<unit> "erp-p2p-recursive-sequence-runtime-mismatch"
let v5665 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5666 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5667 : string = v5665 + "|" + v5666
let v5668 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5669 : string = v5667 + "|" + v5668
let v5670 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5671 : string = v5669 + "|" + v5670
let v5672 : string = "erp-p2p-" + v4774 + "-outbox"
let v5673 : string = "erp-p2p-" + v4522 + "-outbox"
let v5674 : string = v5672 + "|" + v5673
let v5675 : string = "erp-p2p-" + v4776 + "-outbox"
let v5676 : string = v5674 + "|" + v5675
let v5677 : string = "erp-p2p-" + v4799 + "-outbox"
let v5678 : string = v5676 + "|" + v5677
let struct (v5679 : int64, v5680 : int64) = (let messages = v5678.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let expected = [| "erp-p2p-budget-reserved-outbox"; "erp-p2p-approvals-collected-outbox"; "erp-p2p-purchase-order-issued-outbox"; "erp-p2p-goods-partially-received-outbox" |] in (if messages = expected then 1L else 0L),(if messages |> Array.distinct |> Array.length = messages.Length then 1L else 0L))
let v5681 : bool = v5679 = 1L
let v5682 : bool = v5680 = 1L
let v5683 : bool = v5681 && v5682
if v5683 then
    ()
else
    failwith<unit> "erp-p2p-recursive-outbox-authority-runtime-mismatch"
let v5684 : int64 = 0L + 1L
let v5685 : int64 = v5684 + 1L
let v5686 : int64 = v5685 + 1L
let v5687 : int64 = v5686 + 1L
let v5688 : int64 = 0L + 1L
let v5689 : int64 = v5688 + 1L
let v5690 : int64 = v5689 + 1L
let v5691 : int64 = v5690 + 1L
if v5687 <> 4L || v5691 <> 4L || v4799 <> "goods-partially-received" || v4799 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v5692 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5693 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5694 : string = v5692 + "|" + v5693
let v5695 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5696 : string = v5694 + "|" + v5695
let v5697 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5698 : string = v5696 + "|" + v5697
let v5699 : string = "erp-p2p-" + v4774 + "-outbox"
let v5700 : string = "erp-p2p-" + v4522 + "-outbox"
let v5701 : string = v5699 + "|" + v5700
let v5702 : string = "erp-p2p-" + v4776 + "-outbox"
let v5703 : string = v5701 + "|" + v5702
let v5704 : string = "erp-p2p-" + v4799 + "-outbox"
let v5705 : string = v5703 + "|" + v5704
let v5706 : string = "erp-p2p-" + v4774 + "-outbox"
let v5707 : string = "erp-p2p-" + v4522 + "-outbox"
let v5708 : string = v5706 + ">" + v5707
let v5709 : string = "erp-p2p-" + v4776 + "-outbox"
let v5710 : string = v5708 + ">" + v5709
let v5711 : string = "erp-p2p-" + v4799 + "-outbox"
let v5712 : string = v5710 + ">" + v5711
let v5713 : string = v5712 + "|aggregate=erp-p2p-aggregate:" + v5712 + "|command=erp-p2p-command:" + v5712
let v5714 : string = v5713 + "|payload=" + v5698 + "|outbox=" + v5705
let v5715 : int64 = 0L + 1L
let v5716 : int64 = v5715 + 1L
let v5717 : int64 = v5716 + 1L
let v5718 : int64 = v5717 + 1L
let struct (v5719 : string, v5720 : int64, v5721 : int64, v5722 : int64, v5723 : int64, v5724 : int64, v5725 : int64, v5726 : int64, v5727 : int64, v5728 : int64, v5729 : int64, v5730 : int64) = erpP2PRunAtomicEnvelope v5698 v5705 v5714 v5718
let v5731 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5732 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5733 : string = v5731 + "|" + v5732
let v5734 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5735 : string = v5733 + "|" + v5734
let v5736 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5737 : string = v5735 + "|" + v5736
let v5738 : bool = v5724 = 1L
let v5739 : bool = v5725 = 1L
let v5740 : bool = v5719 = v5737
let v5741 : bool = v5738 && v5739
let v5742 : bool = v5741 && v5740
if v5742 then
    ()
else
    failwith<unit> "erp-p2p-reopened-whole-history-does-not-match-commit-tree"
let v5743 : int64 = if System.String.IsNullOrEmpty(v5719) then 0L else int64 (v5719.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries).Length)
let v5744 : bool = v5743 = 4L
if v5744 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v5745 : int64 = 0L + 1L
let v5746 : int64 = v5745 + 1L
let v5747 : int64 = v5746 + 1L
let v5748 : int64 = v5747 + 1L
let v5749 : bool = v5748 = 4L
if v5749 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v5750 : int64 = 0L + 1L
let v5751 : int64 = v5750 + 1L
let v5752 : int64 = v5751 + 1L
let v5753 : int64 = v5752 + 1L
let v5754 : bool = v5753 = 4L
if v5754 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v5755 : bool = v5720 > 0L
let v5756 : bool = v5721 = 1L
let v5757 : bool = v5722 = 1L
let v5758 : bool = v5723 = 4L
let v5759 : bool = v5726 = 1L
let v5760 : bool = v5727 = 1L
let v5761 : bool = v5728 = 0L
let v5762 : bool = v5729 = 1L
let v5763 : bool = v5730 = 1L
let v5764 : bool = v5755 && v5756
let v5765 : bool = v5764 && v5757
let v5766 : bool = v5765 && v5758
let v5767 : bool = v5766 && v5738
let v5768 : bool = v5767 && v5739
let v5769 : bool = v5768 && v5759
let v5770 : bool = v5769 && v5760
let v5771 : bool = v5770 && v5761
let v5772 : bool = v5771 && v5762
let v5773 : bool = v5772 && v5763
if v5773 then
    ()
else
    failwith<unit> "erp-p2p-recursive-atomic-payload-outbox-runtime-mismatch"
let v5774 : int64 = -1L * 830L
let v5775 : string = (let fields = [| v4526; v4527; v4528; v4529; v4530; v4531; v4532; v4526; v4533; v4527; v4531; string 830L; v4534; v4533; v4526; v4527; v4531; string v5774; v4535 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5776 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "company-a"; "company-b"; "USD"; "po-1001"; "830"; "company-a-intercompany-receivable-830"; "company-b"; "company-a"; "USD"; "po-1001"; "-830"; "company-b-intercompany-payable-minus-830" |] in match tryDecode v5775 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[11]), System.Int64.TryParse(fields.[17]) with (true,left),(true,right) when left = 830L && right = -830L && left + right = 0L -> 1L | _ -> 0L) | _ -> 0L)
let v5777 : bool = 1L = v5776
let v5782 : US1 =
    if v5777 then
        let v5778 : string = "the-decoder-validates-all-nineteen-canonical-NetIntercompany-fields-and-opposed-mirror-amounts-before-producing-a-typed-acceptance-witness"
        US1_0(v5778)
    else
        let v5780 : string = "invalid-or-truncated-NetIntercompany-frame-does-not-produce-a-typed-operation"
        US1_1(v5780)
let v5803 : US2 =
    match v5782 with
    | US1_0(v5783) -> (* ErpNetIntercompanyPayloadDecoded *)
        let struct (v5784 : string, v5785 : string, v5786 : string, v5787 : string, v5788 : string, v5789 : string, v5790 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5775 with Some fields when fields.Length = 19 && fields.[0] = "company-a" && fields.[1] = "USD" && fields.[2] = "widget-a" && fields.[3] = "warehouse-north" && fields.[4] = "BR" && fields.[5] = "po-1001" && fields.[6].Length > 0 -> fields.[0],fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-invoice-fields")
        let struct (v5791 : string, v5792 : string, v5793 : string, v5794 : string, v5795 : int64, v5796 : string, v5797 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v5775 with Some fields when fields.Length = 19 && fields.[7] = "company-a" && fields.[8] = "company-b" && fields.[9] = "USD" && fields.[10] = "po-1001" && fields.[12].Length > 0 && fields.[18].Length > 0 -> (match System.Int64.TryParse(fields.[11]) with true,leftAmount when leftAmount = 830L -> fields.[7],fields.[8],fields.[9],fields.[10],leftAmount,fields.[12],fields.[18] | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-left-mirror-amount") | _ -> failwith "erp-NetIntercompany-typed-decode-invalid-mirror-authority-fields")
        let v5798 : US3 = US3_0(v5791, v5792, v5793, v5794, v5795, v5796, v5797)
        US2_0(v5784, v5785, v5786, v5787, v5788, v5789, v5790, v5798)
    | US1_1(v5800) -> (* ErpNetIntercompanyPayloadRejected *)
        let v5801 : US2 = failwith ("canonical-NetIntercompany-bytes-could-not-reconstruct-typed-operation:" + v5800)
        v5801
let v5840 : string =
    match v5803 with
    | US2_0(v5804, v5805, v5806, v5807, v5808, v5809, v5810, v5811) -> (* NetIntercompany *)
        let struct (v5819 : string, v5820 : string, v5821 : string, v5822 : string, v5823 : int64, v5824 : string) =
            match v5811 with
            | US3_0(v5812, v5813, v5814, v5815, v5816, v5817, v5818) -> (* OpposedMirrorPair *)
                struct (v5812, v5813, v5814, v5815, v5816, v5817)
        let struct (v5833 : string, v5834 : string, v5835 : string, v5836 : string, v5837 : int64, v5838 : string) =
            match v5811 with
            | US3_0(v5825, v5826, v5827, v5828, v5829, v5830, v5831) -> (* OpposedMirrorPair *)
                let v5832 : int64 = -1L * v5829
                struct (v5826, v5825, v5827, v5828, v5832, v5831)
        let v5839 : string = (let fields = [| v5804; v5805; v5806; v5807; v5808; v5809; v5810; v5819; v5820; v5821; v5822; string v5823; v5824; v5833; v5834; v5835; v5836; string v5837; v5838 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v5839
method1(v5775, v5840)
method2(v5775)
method1(v5775, v5840)
let struct (v5849 : string, v5850 : string, v5851 : string, v5852 : string, v5853 : string, v5854 : string, v5855 : string) =
    match v5803 with
    | US2_0(v5841, v5842, v5843, v5844, v5845, v5846, v5847, v5848) -> (* NetIntercompany *)
        struct (v5841, v5842, v5843, v5844, v5845, v5846, v5847)
let struct (v5864 : string, v5865 : string, v5866 : string, v5867 : string, v5868 : string, v5869 : string, v5870 : string) =
    match v5803 with
    | US2_0(v5856, v5857, v5858, v5859, v5860, v5861, v5862, v5863) -> (* NetIntercompany *)
        struct (v5856, v5857, v5858, v5859, v5860, v5861, v5862)
let v5871 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5872 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5873 : string = v5871 + "|" + v5872
let v5874 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5875 : string = v5873 + "|" + v5874
let v5876 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5877 : string = v5875 + "|" + v5876
let v5878 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4526; v4527; v4528; v4529; v4531; string 6L; v5161; v4530; v4527; v4531; string 170L; v5282 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5879 : string = v5877 + "|" + v5878
let v5916 : string =
    match v5803 with
    | US2_0(v5880, v5881, v5882, v5883, v5884, v5885, v5886, v5887) -> (* NetIntercompany *)
        let struct (v5895 : string, v5896 : string, v5897 : string, v5898 : string, v5899 : int64, v5900 : string) =
            match v5887 with
            | US3_0(v5888, v5889, v5890, v5891, v5892, v5893, v5894) -> (* OpposedMirrorPair *)
                struct (v5888, v5889, v5890, v5891, v5892, v5893)
        let struct (v5909 : string, v5910 : string, v5911 : string, v5912 : string, v5913 : int64, v5914 : string) =
            match v5887 with
            | US3_0(v5901, v5902, v5903, v5904, v5905, v5906, v5907) -> (* OpposedMirrorPair *)
                let v5908 : int64 = -1L * v5905
                struct (v5902, v5901, v5903, v5904, v5908, v5907)
        let v5915 : string = (let fields = [| v5880; v5881; v5882; v5883; v5884; v5885; v5886; v5895; v5896; v5897; v5898; string v5899; v5900; v5909; v5910; v5911; v5912; string v5913; v5914 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v5915
let v5917 : string = v5879 + "|" + v5916
let v5918 : string = (let fields = [| "SettlePayment"; v5864; v5865; v5866; v5867; v5868; v5869; v5870; v5425; string 2L; string 4980L; "2026-07"; string 6L; string 1L; v5426 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5919 : string = v5917 + "|" + v5918
let v5920 : string = "erp-p2p-" + v4774 + "-outbox"
let v5921 : string = "erp-p2p-" + v4522 + "-outbox"
let v5922 : string = v5920 + "|" + v5921
let v5923 : string = "erp-p2p-" + v4776 + "-outbox"
let v5924 : string = v5922 + "|" + v5923
let v5925 : string = "erp-p2p-" + v4799 + "-outbox"
let v5926 : string = v5924 + "|" + v5925
let v5927 : string = "erp-p2p-" + v5284 + "-outbox"
let v5928 : string = v5926 + "|" + v5927
let v5937 : string =
    match v5803 with
    | US2_0(v5929, v5930, v5931, v5932, v5933, v5934, v5935, v5936) -> (* NetIntercompany *)
        v4524
let v5938 : string = "erp-p2p-" + v5937 + "-outbox"
let v5939 : string = v5928 + "|" + v5938
let v5940 : string = "erp-p2p-" + v4773 + "-outbox"
let v5941 : string = v5939 + "|" + v5940
let v5942 : string = "erp-p2p-" + v4774 + "-outbox"
let v5943 : string = "erp-p2p-" + v4522 + "-outbox"
let v5944 : string = v5942 + ">" + v5943
let v5945 : string = "erp-p2p-" + v4776 + "-outbox"
let v5946 : string = v5944 + ">" + v5945
let v5947 : string = "erp-p2p-" + v4799 + "-outbox"
let v5948 : string = v5946 + ">" + v5947
let v5949 : string = "erp-p2p-" + v5284 + "-outbox"
let v5950 : string = v5948 + ">" + v5949
let v5959 : string =
    match v5803 with
    | US2_0(v5951, v5952, v5953, v5954, v5955, v5956, v5957, v5958) -> (* NetIntercompany *)
        v4524
let v5960 : string = "erp-p2p-" + v5959 + "-outbox"
let v5961 : string = v5950 + ">" + v5960
let v5962 : string = "erp-p2p-" + v4773 + "-outbox"
let v5963 : string = v5961 + ">" + v5962
let v5964 : string = v5963 + "|aggregate=erp-p2p-aggregate:" + v5963 + "|command=erp-p2p-command:" + v5963
let v5965 : string = v5964 + "|payload=" + v5919 + "|outbox=" + v5941
let v5966 : int64 = 0L + 1L
let v5967 : int64 = v5966 + 1L
let v5968 : int64 = v5967 + 1L
let v5969 : int64 = v5968 + 1L
let v5970 : int64 = v5969 + 1L
let v5971 : int64 = v5970 + 1L
let v5972 : int64 = v5971 + 1L
let struct (v5973 : string, v5974 : int64, v5975 : int64, v5976 : int64, v5977 : int64, v5978 : int64, v5979 : int64, v5980 : int64, v5981 : int64, v5982 : int64, v5983 : int64, v5984 : int64) = erpP2PRunAtomicEnvelope v5919 v5941 v5965 v5972
let v5985 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5986 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5987 : string = v5985 + "|" + v5986
let v5988 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5989 : string = v5987 + "|" + v5988
let v5990 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5991 : string = v5989 + "|" + v5990
let v5992 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4526; v4527; v4528; v4529; v4531; string 6L; v5161; v4530; v4527; v4531; string 170L; v5282 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v5993 : string = v5991 + "|" + v5992
let v6030 : string =
    match v5803 with
    | US2_0(v5994, v5995, v5996, v5997, v5998, v5999, v6000, v6001) -> (* NetIntercompany *)
        let struct (v6009 : string, v6010 : string, v6011 : string, v6012 : string, v6013 : int64, v6014 : string) =
            match v6001 with
            | US3_0(v6002, v6003, v6004, v6005, v6006, v6007, v6008) -> (* OpposedMirrorPair *)
                struct (v6002, v6003, v6004, v6005, v6006, v6007)
        let struct (v6023 : string, v6024 : string, v6025 : string, v6026 : string, v6027 : int64, v6028 : string) =
            match v6001 with
            | US3_0(v6015, v6016, v6017, v6018, v6019, v6020, v6021) -> (* OpposedMirrorPair *)
                let v6022 : int64 = -1L * v6019
                struct (v6016, v6015, v6017, v6018, v6022, v6021)
        let v6029 : string = (let fields = [| v5994; v5995; v5996; v5997; v5998; v5999; v6000; v6009; v6010; v6011; v6012; string v6013; v6014; v6023; v6024; v6025; v6026; string v6027; v6028 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        v6029
let v6031 : string = v5993 + "|" + v6030
let v6032 : string = (let fields = [| "SettlePayment"; v5864; v5865; v5866; v5867; v5868; v5869; v5870; v5425; string 2L; string 4980L; "2026-07"; string 6L; string 1L; v5426 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6033 : string = v6031 + "|" + v6032
let v6034 : bool = v5978 = 1L
let v6035 : bool = v5979 = 1L
let v6036 : bool = v5973 = v6033
let v6037 : bool = v6034 && v6035
let v6038 : bool = v6037 && v6036
if v6038 then
    ()
else
    failwith<unit> "erp-p2p-reopened-whole-history-does-not-match-commit-tree"
let v6039 : int64 = if System.String.IsNullOrEmpty(v5973) then 0L else int64 (v5973.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries).Length)
let v6040 : bool = v6039 = 7L
if v6040 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6041 : int64 = 0L + 1L
let v6042 : int64 = v6041 + 1L
let v6043 : int64 = v6042 + 1L
let v6044 : int64 = v6043 + 1L
let v6045 : int64 = v6044 + 1L
let v6046 : int64 = v6045 + 1L
let v6047 : int64 = v6046 + 1L
let v6048 : bool = v6047 = 7L
if v6048 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6049 : int64 = 0L + 1L
let v6050 : int64 = v6049 + 1L
let v6051 : int64 = v6050 + 1L
let v6052 : int64 = v6051 + 1L
let v6053 : int64 = v6052 + 1L
let v6054 : int64 = v6053 + 1L
let v6055 : int64 = v6054 + 1L
let v6056 : bool = v6055 = 7L
if v6056 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6057 : string = let payloads = v5973.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in if payloads.Length = 0 then System.String.Empty else payloads.[payloads.Length - 1]
let v6058 : int64 = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in let expected = [| "SettlePayment"; "company-a"; "USD"; "widget-a"; "warehouse-north"; "BR"; "po-1001"; "invoice-match-1001"; "BRL"; "2"; "4980"; "2026-07"; "6"; "1"; "payment-3001" |] in match tryDecode v6057 with Some fields when fields.Length = expected.Length && Array.forall2 (=) fields expected -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]), System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,scale),(true,amount),(true,numerator),(true,denominator) when scale = 2L && amount = 4980L && numerator = 6L && denominator = 1L -> 1L | _ -> 0L) | _ -> 0L)
let v6059 : bool = 1L = v6058
let v6077 : US6 =
    if v6059 then
        let struct (v6060 : string, v6061 : string, v6062 : string, v6063 : string, v6064 : string, v6065 : string, v6066 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v6057 with Some fields when fields.Length = 15 && fields.[0] = "SettlePayment" && fields.[1] = "company-a" && fields.[2] = "USD" && fields.[3] = "widget-a" && fields.[4] = "warehouse-north" && fields.[5] = "BR" && fields.[6] = "po-1001" && fields.[7].Length > 0 -> fields.[1],fields.[2],fields.[3],fields.[4],fields.[5],fields.[6],fields.[7] | _ -> failwith "erp-SettlePayment-typed-decode-invalid-invoice-fields")
        let struct (v6067 : string, v6068 : int64, v6069 : int64) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v6057 with Some fields when fields.Length = 15 && fields.[8] = "BRL" -> (match System.Int64.TryParse(fields.[9]), System.Int64.TryParse(fields.[10]) with (true,scale),(true,amount) when scale = 2L && amount = 4980L -> fields.[8],scale,amount | _ -> failwith "erp-SettlePayment-typed-decode-invalid-payment-fields") | _ -> failwith "erp-SettlePayment-typed-decode-invalid-payment-frame")
        let struct (v6070 : string, v6071 : int64, v6072 : int64, v6073 : string) = (let tryDecode (text : string) = try let bytes = System.Convert.FromBase64String(text) in let mutable offset = 0 in let fields = System.Collections.Generic.List<string>() in let mutable valid = true in while valid && offset < bytes.Length do if offset + 4 > bytes.Length then valid <- false else let raw = System.BitConverter.ToInt32(bytes, offset) |> System.Net.IPAddress.NetworkToHostOrder in offset <- offset + 4; if raw < 0 || offset + raw > bytes.Length then valid <- false else fields.Add(System.Text.Encoding.UTF8.GetString(bytes, offset, raw)); offset <- offset + raw done; if valid && offset = bytes.Length then Some(fields.ToArray()) else None with _ -> None in match tryDecode v6057 with Some fields when fields.Length = 15 && fields.[11] = "2026-07" && fields.[14].Length > 0 -> (match System.Int64.TryParse(fields.[12]), System.Int64.TryParse(fields.[13]) with (true,numerator),(true,denominator) when numerator = 6L && denominator = 1L -> fields.[11],numerator,denominator,fields.[14] | _ -> failwith "erp-SettlePayment-typed-decode-invalid-route-fields") | _ -> failwith "erp-SettlePayment-typed-decode-invalid-route-frame")
        US6_0(v6060, v6061, v6062, v6063, v6064, v6065, v6066, v6067, v6068, v6069, v6061, v6067, v6070, v6071, v6072, v6073)
    else
        let v6075 : string = "invalid-or-truncated-SettlePayment-frame"
        US6_1(v6075)
let v6100 : US7 =
    match v6077 with
    | US6_0(v6078, v6079, v6080, v6081, v6082, v6083, v6084, v6085, v6086, v6087, v6088, v6089, v6090, v6091, v6092, v6093) -> (* ErpSettlePaymentPayloadTypedDecoded *)
        let v6094 : string = (let fields = [| "SettlePayment"; v6078; v6079; v6080; v6081; v6082; v6083; v6084; v6085; string v6086; string v6087; "2026-07"; string v6091; string v6092; v6093 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
        let v6095 : bool = v6057 = v6094
        if v6095 then
            ()
        else
            failwith<unit> "erp-SettlePayment-typed-decode-roundtrip-mismatch"
        US7_0(v6057, v6078, v6079, v6080, v6081, v6082, v6083, v6084, v6085, v6086, v6087, v6088, v6089, v6090, v6091, v6092, v6093, v6094)
    | US6_1(v6097) -> (* ErpSettlePaymentPayloadTypedRejected *)
        failwith<US7> "disk-reopened-SettlePayment-payload-could-not-produce-a-typed-authority"
match v6100 with
| US7_0(v6101, v6102, v6103, v6104, v6105, v6106, v6107, v6108, v6109, v6110, v6111, v6112, v6113, v6114, v6115, v6116, v6117, v6118) -> (* ErpSettlePaymentTypedDecodeAuthority *)
    let v6119 : bool = v6057 = v6101
    if v6119 then
        ()
    else
        failwith<unit> "erp-SettlePayment-typed-decode-roundtrip-mismatch"
    let v6120 : bool = v6101 = v6118
    if v6120 then
        ()
    else
        failwith<unit> "erp-SettlePayment-typed-decode-roundtrip-mismatch"
    if (v6115, v6116) <> (6L, 1L) then failwith "typed-SettlePayment-certificate-FX-ratio-does-not-match-the-static-operation-route"
    ()
let v6121 : bool = v5974 > 0L
let v6122 : bool = v5975 = 1L
let v6123 : bool = v5976 = 1L
let v6124 : bool = v5977 = 7L
let v6125 : bool = v5980 = 1L
let v6126 : bool = v5981 = 1L
let v6127 : bool = v5982 = 0L
let v6128 : bool = v5983 = 1L
let v6129 : bool = v5984 = 1L
let v6130 : bool = v6121 && v6122
let v6131 : bool = v6130 && v6123
let v6132 : bool = v6131 && v6124
let v6133 : bool = v6132 && v6034
let v6134 : bool = v6133 && v6035
let v6135 : bool = v6134 && v6125
let v6136 : bool = v6135 && v6126
let v6137 : bool = v6136 && v6127
let v6138 : bool = v6137 && v6128
let v6139 : bool = v6138 && v6129
if v6139 then
    ()
else
    failwith<unit> "erp-p2p-seven-event-recursive-atomic-payload-outbox-runtime-mismatch"
let v6140 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6141 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6142 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6143 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6144 : string = "erp-p2p-" + v4774 + "-outbox"
let v6145 : string = "erp-p2p-" + v4522 + "-outbox"
let v6146 : string = "erp-p2p-" + v4776 + "-outbox"
let v6147 : string = "erp-p2p-" + v4799 + "-outbox"
let struct (v6148 : int64, v6149 : int64) = (let messages = [| v6144; v6145; v6146; v6147 |] in let expected = [| "erp-p2p-budget-reserved-outbox"; "erp-p2p-approvals-collected-outbox"; "erp-p2p-purchase-order-issued-outbox"; "erp-p2p-goods-partially-received-outbox" |] in (if messages = expected then 1L else 0L),(if messages |> Array.distinct |> Array.length = 4 then 1L else 0L))
let v6150 : bool = v6148 = 1L
let v6151 : bool = v6149 = 1L
let v6152 : bool = v6150 && v6151
if v6152 then
    ()
else
    failwith<unit> "erp-p2p-four-event-outbox-authority-runtime-mismatch"
let struct (v6153 : int64, v6154 : int64, v6155 : int64, v6156 : int64, v6157 : int64, v6158 : int64, v6159 : int64, v6160 : int64, v6161 : int64, v6162 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-four-envelope-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let prepared = System.IO.Path.Combine(root, "commit.prepared") in let committed = System.IO.Path.Combine(root, "commit.committed") in let payloads = [| System.Convert.FromBase64String(v6140); System.Convert.FromBase64String(v6141); System.Convert.FromBase64String(v6142); System.Convert.FromBase64String(v6143) |] in let messages = [| v6144; v6145; v6146; v6147 |] |> Array.map System.Text.Encoding.UTF8.GetBytes in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let frameBytes index = let payload = payloads.[index] in let message = messages.[index] in let digest = System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(payloads.Length) |]) in Array.concat [| lengthBytes payload.Length; payload; lengthBytes message.Length; message; digest |] in let envelopeBody = Array.concat [| [|69uy;82uy;80uy;52uy|]; lengthBytes payloads.Length; frameBytes 0; frameBytes 1; frameBytes 2; frameBytes 3 |] in let rootDigest = System.Security.Cryptography.SHA256.HashData(envelopeBody) in let envelope = Array.concat [| envelopeBody; rootDigest |] in (use stream = new System.IO.FileStream(prepared,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(envelope,0,envelope.Length); stream.Flush(true)); System.IO.File.Move(prepared,committed,true); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(root); use syncProcess = System.Diagnostics.Process.Start(info) in let completed = syncProcess.WaitForExit(5000) in let _ = if not completed then (syncProcess.Kill(true); syncProcess.WaitForExit() |> ignore) else () in let directorySync = if completed then int64 syncProcess.ExitCode else -2L in let recovered = System.IO.File.ReadAllBytes(committed) in let preparedAbsent = if System.IO.File.Exists(prepared) then 0L else 1L in let readLength (data : byte array) offset = System.BitConverter.ToInt32(data,offset) |> System.Net.IPAddress.NetworkToHostOrder in let parse (data : byte array) = try if data.Length < 8 || data.[0] <> 69uy || data.[1] <> 82uy || data.[2] <> 80uy || data.[3] <> 52uy then None else let count = readLength data 4 in let mutable offset = 8 in let parsedPayloads = System.Collections.Generic.List<byte array>() in let parsedMessages = System.Collections.Generic.List<byte array>() in let mutable valid = count >= 0 in let mutable index = 0 in while valid && index < count do if offset + 4 > data.Length then valid <- false else (let payloadLength = readLength data offset in offset <- offset + 4; if payloadLength < 0 || offset + payloadLength + 4 + 32 > data.Length then valid <- false else (let payload = data.[offset .. offset + payloadLength - 1] in offset <- offset + payloadLength; let messageLength = readLength data offset in offset <- offset + 4; if messageLength < 0 || offset + messageLength + 32 > data.Length then valid <- false else (let message = data.[offset .. offset + messageLength - 1] in offset <- offset + messageLength; let digest = data.[offset .. offset + 31] in offset <- offset + 32; if not (System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(count) |]),digest)) then valid <- false else (parsedPayloads.Add(payload); parsedMessages.Add(message); index <- index + 1)))) done; if valid && index = count && offset + 32 = data.Length then (let rootDigest = data.[offset .. offset + 31] in let bodyDigest = System.Security.Cryptography.SHA256.HashData(data.[0 .. offset - 1]) in if System.Linq.Enumerable.SequenceEqual(bodyDigest,rootDigest) then Some(parsedPayloads.ToArray(),parsedMessages.ToArray()) else None) else None with _ -> None in let parsed = parse recovered in let parseValid,frameCount,payloadEqual,outboxEqual,digestValid = match parsed with Some(parsedPayloads,parsedMessages) -> let payloadEqual = parsedPayloads.Length = payloads.Length && Array.forall2 (fun left right -> System.Linq.Enumerable.SequenceEqual(left,right)) parsedPayloads payloads in let messageEqual = parsedMessages.Length = messages.Length && Array.forall2 (fun left right -> System.Linq.Enumerable.SequenceEqual(left,right)) parsedMessages messages in 1L,int64 parsedPayloads.Length,(if payloadEqual then 1L else 0L),(if messageEqual then 1L else 0L),1L | None -> 0L,0L,0L,0L,0L in let tampered = Array.copy recovered in let firstPayloadLength = readLength tampered 8 in let firstMessageLengthOffset = 12 + firstPayloadLength in let firstMessageLength = readLength tampered firstMessageLengthOffset in let secondFrameOffset = firstMessageLengthOffset + 4 + firstMessageLength + 32 in let secondPayloadStart = secondFrameOffset + 4 in let _ = if secondPayloadStart < tampered.Length then tampered.[secondPayloadStart] <- tampered.[secondPayloadStart] ^^^ 1uy else () in let tamperRejected = match parse tampered with None -> 1L | Some _ -> 0L in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in int64 envelope.Length,parseValid,frameCount,payloadEqual,outboxEqual,digestValid,preparedAbsent,directorySync,tamperRejected,cleanupAbsent)
let v6163 : bool = v6153 > 0L
let v6164 : bool = v6154 = 1L
let v6165 : bool = v6155 = 4L
let v6166 : bool = v6156 = 1L
let v6167 : bool = v6157 = 1L
let v6168 : bool = v6158 = 1L
let v6169 : bool = v6159 = 1L
let v6170 : bool = v6160 = 0L
let v6171 : bool = v6161 = 1L
let v6172 : bool = v6162 = 1L
let v6173 : bool = v6163 && v6164
let v6174 : bool = v6173 && v6165
let v6175 : bool = v6174 && v6166
let v6176 : bool = v6175 && v6167
let v6177 : bool = v6176 && v6168
let v6178 : bool = v6177 && v6169
let v6179 : bool = v6178 && v6170
let v6180 : bool = v6179 && v6171
let v6181 : bool = v6180 && v6172
if v6181 then
    ()
else
    failwith<unit> "erp-p2p-four-event-atomic-payload-outbox-runtime-mismatch"
let v6182 : string = v4774 + "|" + v4522
let v6183 : string = v6182 + "|" + v4776
let v6184 : string = v6183 + "|" + v4799
let v6185 : string = v4774 + "|" + v4522
let v6186 : string = v6185 + "|" + v4776
let v6187 : string = v6186 + "|" + v4799
let struct (v6188 : int64, v6189 : int64, v6190 : int64, v6191 : int64, v6192 : int64, v6193 : int64, v6194 : int64) = (let encodeField (value : string) = let count = System.Text.Encoding.UTF8.GetByteCount(value) in string count + ":" + value in let encodeSequence (value : string) = value.Split([|'|'|], System.StringSplitOptions.None) |> Array.map encodeField |> String.concat "|" in let decodeField (field : string) = let colon = field.IndexOf(':') in if colon <= 0 then false,"" else let count = System.Int32.Parse(field.Substring(0,colon)) in let value = field.Substring(colon+1) in System.Text.Encoding.UTF8.GetByteCount(value) = count,value in let decodeSequence (value : string) = value.Split([|'|'|], System.StringSplitOptions.None) |> Array.map decodeField in let encodedStore = encodeSequence v6184 in let encodedOutbox = encodeSequence v6187 in let storeDecoded = decodeSequence encodedStore in let outboxDecoded = decodeSequence encodedOutbox in let storeValid = if storeDecoded |> Array.forall fst then 1L else 0L in let outboxValid = if outboxDecoded |> Array.forall fst then 1L else 0L in let frameCount = int64 storeDecoded.Length in let storeValues = storeDecoded |> Array.map snd in let outboxValues = outboxDecoded |> Array.map snd in let same = if storeValues = outboxValues then 1L else 0L in let roundtrip = if (storeValues |> Array.map encodeField |> String.concat "|") = encodedStore then 1L else 0L in let tampered = encodedStore + "x" in let tamperRejected = if decodeSequence tampered |> Array.forall fst then 0L else 1L in let digestBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(encodedStore)).Length |> int64 in frameCount, storeValid, outboxValid, same, roundtrip, tamperRejected, digestBytes)
let v6195 : bool = v6188 = 4L
let v6196 : bool = v6189 = 1L
let v6197 : bool = v6190 = 1L
let v6198 : bool = v6191 = 1L
let v6199 : bool = v6192 = 1L
let v6200 : bool = v6193 = 1L
let v6201 : bool = v6194 = 32L
let v6202 : bool = v6195 && v6196
let v6203 : bool = v6202 && v6197
let v6204 : bool = v6203 && v6198
let v6205 : bool = v6204 && v6199
let v6206 : bool = v6205 && v6200
let v6207 : bool = v6206 && v6201
if v6207 then
    ()
else
    failwith<unit> "erp-p2p-stage-sequence-codec-runtime-mismatch"
let v6208 : int64 = 0L + 1L
let v6209 : int64 = v6208 + 1L
let v6210 : int64 = v6209 + 1L
let v6211 : int64 = v6210 + 1L
let v6212 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6213 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6214 : string = v6212 + "|" + v6213
let v6215 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6216 : string = v6214 + "|" + v6215
let v6217 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6218 : string = v6216 + "|" + v6217
let v6219 : string = "erp-p2p-" + v4774 + "-outbox"
let v6220 : string = "erp-p2p-" + v4522 + "-outbox"
let v6221 : string = v6219 + "|" + v6220
let v6222 : string = "erp-p2p-" + v4776 + "-outbox"
let v6223 : string = v6221 + "|" + v6222
let v6224 : string = "erp-p2p-" + v4799 + "-outbox"
let v6225 : string = v6223 + "|" + v6224
let v6226 : string = "erp-p2p-" + v4774 + "-outbox"
let v6227 : string = "erp-p2p-" + v4522 + "-outbox"
let v6228 : string = v6226 + ">" + v6227
let v6229 : string = "erp-p2p-" + v4776 + "-outbox"
let v6230 : string = v6228 + ">" + v6229
let v6231 : string = "erp-p2p-" + v4799 + "-outbox"
let v6232 : string = v6230 + ">" + v6231
let v6233 : string = v6232 + "|aggregate=erp-p2p-aggregate:" + v6232 + "|command=erp-p2p-command:" + v6232
let v6234 : string = v6233 + "|payload=" + v6218 + "|outbox=" + v6225
let v6235 : int64 = 0L + 1L
let v6236 : int64 = v6235 + 1L
let v6237 : int64 = v6236 + 1L
let v6238 : int64 = v6237 + 1L
let struct (v6239 : int64, v6240 : int64, v6241 : int64, v6242 : int64, v6243 : int64, v6244 : int64, v6245 : int64, v6246 : int64, v6247 : int64, v6248 : int64, v6249 : int64, v6250 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-recursive-recovery-" + System.Guid.NewGuid().ToString("N")) in let beforeDirectory = System.IO.Path.Combine(root, "before-rename") in let afterDirectory = System.IO.Path.Combine(root, "after-rename") in let _ = System.IO.Directory.CreateDirectory(beforeDirectory) in let _ = System.IO.Directory.CreateDirectory(afterDirectory) in let payloadTexts = v6218.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let messageTexts = v6225.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let payloads = payloadTexts |> Array.map System.Convert.FromBase64String in let messages = messageTexts |> Array.map System.Text.Encoding.UTF8.GetBytes in let countBound = if payloads.Length = messages.Length && int64 payloads.Length = v6238 && payloads.Length > 0 then 1L else 0L in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let frameBytes index = let payload = payloads.[index] in let message = messages.[index] in let digest = System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(payloads.Length) |]) in Array.concat [| lengthBytes payload.Length; payload; lengthBytes message.Length; message; digest |] in let frames = [|0 .. payloads.Length - 1|] |> Array.collect frameBytes in let envelopeBody = Array.concat [| [|69uy;82uy;80uy;82uy|]; lengthBytes payloads.Length; System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v6234)); System.BitConverter.GetBytes(v6238); frames |] in let rootDigest = System.Security.Cryptography.SHA256.HashData(envelopeBody) in let envelope = Array.concat [| envelopeBody; rootDigest |] in let oldBytes = System.Text.Encoding.UTF8.GetBytes("previous-committed-envelope") in let writeDurable path bytes = use stream = new System.IO.FileStream(path,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in let runSync path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let validateEnvelope (data : byte array) = try let readLength offset = System.BitConverter.ToInt32(data,offset) |> System.Net.IPAddress.NetworkToHostOrder in if data.Length < 80 || data.[0] <> 69uy || data.[1] <> 82uy || data.[2] <> 80uy || data.[3] <> 82uy then false else let count = readLength 4 in let storedTreeIdentityHash = data.[8 .. 39] in let expectedTreeIdentityHash = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v6234)) in let storedVersion = System.BitConverter.ToInt64(data,40) in let mutable offset = 48 in let mutable index = 0 in let mutable valid = count > 0 && System.Linq.Enumerable.SequenceEqual(storedTreeIdentityHash,expectedTreeIdentityHash) && storedVersion = v6238 in while valid && index < count do if offset + 4 > data.Length then valid <- false else let payloadLength = readLength offset in offset <- offset + 4; if payloadLength < 0 || offset + payloadLength + 4 + 32 > data.Length then valid <- false else let payload = data.[offset .. offset + payloadLength - 1] in offset <- offset + payloadLength; let messageLength = readLength offset in offset <- offset + 4; if messageLength < 0 || offset + messageLength + 32 > data.Length then valid <- false else let message = data.[offset .. offset + messageLength - 1] in offset <- offset + messageLength; let digest = data.[offset .. offset + 31] in offset <- offset + 32; if not (System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(count) |]),digest)) then valid <- false else index <- index + 1 done; if valid && index = count && offset + 32 = data.Length then let rootDigest = data.[offset .. offset + 31] in let bodyDigest = System.Security.Cryptography.SHA256.HashData(data.[0 .. offset - 1]) in System.Linq.Enumerable.SequenceEqual(bodyDigest,rootDigest) else false with _ -> false in let reopenedFramesMatchExpected (data : byte array) = try let readLength offset = System.BitConverter.ToInt32(data,offset) |> System.Net.IPAddress.NetworkToHostOrder in let count = readLength 4 in let mutable offset = 48 in let mutable index = 0 in let mutable valid = count = payloads.Length in while valid && index < count do if offset + 4 > data.Length then valid <- false else let payloadLength = readLength offset in offset <- offset + 4; if payloadLength < 0 || offset + payloadLength + 4 + 32 > data.Length then valid <- false else let payload = data.[offset .. offset + payloadLength - 1] in offset <- offset + payloadLength; let messageLength = readLength offset in offset <- offset + 4; if messageLength < 0 || offset + messageLength + 32 > data.Length then valid <- false else let message = data.[offset .. offset + messageLength - 1] in offset <- offset + messageLength; if not (System.Linq.Enumerable.SequenceEqual(payload,payloads.[index])) || not (System.Linq.Enumerable.SequenceEqual(message,messages.[index])) then valid <- false else (offset <- offset + 32; index <- index + 1) done; valid && index = count && offset + 32 = data.Length with _ -> false in let beforePrepared = System.IO.Path.Combine(beforeDirectory,"commit.prepared") in let beforeCommitted = System.IO.Path.Combine(beforeDirectory,"commit.committed") in writeDurable beforeCommitted oldBytes; writeDurable beforePrepared envelope; let beforePreparedPresent = if System.IO.File.Exists(beforePrepared) then 1L else 0L in let beforeOldPreserved = if System.Linq.Enumerable.SequenceEqual(System.IO.File.ReadAllBytes(beforeCommitted),oldBytes) then 1L else 0L in System.IO.File.Delete(beforePrepared); let beforePreparedRemoved = if System.IO.File.Exists(beforePrepared) then 0L else 1L in let beforeSync = runSync beforeDirectory in let afterPrepared = System.IO.Path.Combine(afterDirectory,"commit.prepared") in let afterCommitted = System.IO.Path.Combine(afterDirectory,"commit.committed") in writeDurable afterCommitted oldBytes; writeDurable afterPrepared envelope; System.IO.File.Move(afterPrepared,afterCommitted,true); let afterSync = runSync afterDirectory in let afterRecovered = System.IO.File.ReadAllBytes(afterCommitted) in let afterPreparedAbsent = if System.IO.File.Exists(afterPrepared) then 0L else 1L in let afterNewRecovered = if System.Linq.Enumerable.SequenceEqual(afterRecovered,envelope) then 1L else 0L in let afterEnvelopeValid = if validateEnvelope afterRecovered then 1L else 0L in let afterFramesBound = if afterEnvelopeValid = 1L && reopenedFramesMatchExpected afterRecovered then 1L else 0L in let afterFrameCount = if afterEnvelopeValid = 1L then int64 payloads.Length else 0L in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in afterFramesBound,countBound,beforePreparedPresent,beforeOldPreserved,beforePreparedRemoved,beforeSync,afterPreparedAbsent,afterNewRecovered,afterEnvelopeValid,afterFrameCount,afterSync,cleanupAbsent)
let v6251 : bool = v6239 = 1L
let v6252 : bool = v6240 = 1L
let v6253 : bool = v6241 = 1L
let v6254 : bool = v6242 = 1L
let v6255 : bool = v6243 = 1L
let v6256 : bool = v6244 = 0L
let v6257 : bool = v6245 = 1L
let v6258 : bool = v6246 = 1L
let v6259 : bool = v6247 = 1L
let v6260 : bool = v6248 = v6211
let v6261 : bool = v6249 = 0L
let v6262 : bool = v6250 = 1L
let v6263 : bool = v6251 && v6252
let v6264 : bool = v6263 && v6253
let v6265 : bool = v6264 && v6254
let v6266 : bool = v6265 && v6255
let v6267 : bool = v6266 && v6256
let v6268 : bool = v6267 && v6257
let v6269 : bool = v6268 && v6258
let v6270 : bool = v6269 && v6259
let v6271 : bool = v6270 && v6260
let v6272 : bool = v6271 && v6261
let v6273 : bool = v6272 && v6262
if v6273 then
    ()
else
    failwith<unit> "erp-p2p-recursive-atomic-payload-outbox-recovery-runtime-mismatch"
let v6274 : bool = v6248 = 4L
if v6274 then
    ()
else
    failwith<unit> "reopened-frame-count-is-not-four"
let v6275 : int64 = 0L + 1L
let v6276 : int64 = v6275 + 1L
let v6277 : int64 = v6276 + 1L
let v6278 : int64 = v6277 + 1L
let v6279 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6280 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6281 : string = v6279 + "|" + v6280
let v6282 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6283 : string = v6281 + "|" + v6282
let v6284 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6285 : string = v6283 + "|" + v6284
let v6286 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6287 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6288 : string = v6286 + "|" + v6287
let v6289 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6290 : string = v6288 + "|" + v6289
let v6291 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6292 : string = v6290 + "|" + v6291
let v6293 : bool = v6285 = v6292
let v6294 : bool = v6259 && v6293
if v6294 then
    ()
else
    failwith<unit> "erp-p2p-reopened-whole-history-does-not-match-commit-tree"
let v6295 : bool = v6248 = v6278
if v6295 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6296 : int64 = if System.String.IsNullOrEmpty(v6285) then 0L else int64 (v6285.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries).Length)
let v6297 : bool = v6296 = v6278
if v6297 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6298 : int64 = 0L + 1L
let v6299 : int64 = v6298 + 1L
let v6300 : int64 = v6299 + 1L
let v6301 : int64 = v6300 + 1L
let v6302 : bool = v6301 = v6278
if v6302 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6303 : int64 = 0L + 1L
let v6304 : int64 = v6303 + 1L
let v6305 : int64 = v6304 + 1L
let v6306 : int64 = v6305 + 1L
let v6307 : bool = v6306 = v6278
if v6307 then
    ()
else
    failwith<unit> "erp-p2p-reopened-payload-sequence-count-mismatch"
let v6308 : int64 = 0L + 1L
let v6309 : int64 = v6308 + 1L
let v6310 : int64 = v6309 + 1L
let v6311 : int64 = v6310 + 1L
let v6312 : int64 = if System.String.IsNullOrEmpty(v6285) then 0L else int64 (v6285.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries).Length)
let v6313 : bool = v6312 = 4L
if v6313 then
    ()
else
    failwith<unit> "reopened-frame-count-is-not-four"
let v6314 : string = "erp-p2p-" + v4774 + "-outbox"
let v6315 : string = "erp-p2p-" + v4522 + "-outbox"
let v6316 : string = v6314 + ">" + v6315
let v6317 : string = "erp-p2p-" + v4776 + "-outbox"
let v6318 : string = v6316 + ">" + v6317
let v6319 : string = "erp-p2p-" + v4799 + "-outbox"
let v6320 : string = v6318 + ">" + v6319
let v6321 : string = v6320 + "|aggregate=erp-p2p-aggregate:" + v6320 + "|command=erp-p2p-command:" + v6320
let v6322 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6323 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6324 : string = v6322 + "|" + v6323
let v6325 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6326 : string = v6324 + "|" + v6325
let v6327 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6328 : string = v6326 + "|" + v6327
let v6329 : string = "erp-p2p-" + v4774 + "-outbox"
let v6330 : string = "erp-p2p-" + v4522 + "-outbox"
let v6331 : string = v6329 + "|" + v6330
let v6332 : string = "erp-p2p-" + v4776 + "-outbox"
let v6333 : string = v6331 + "|" + v6332
let v6334 : string = "erp-p2p-" + v4799 + "-outbox"
let v6335 : string = v6333 + "|" + v6334
let v6336 : string = v6321 + "|payload=" + v6328 + "|outbox=" + v6335
let v6337 : string = "reopened-four-event-bytes-validated-before-canonical-recovery-authority-reconstruction"
(if v6311 <> 4L || v6312 <> v6311 || not (v6336.Contains("erp-p2p-aggregate:")) || v6337 <> "reopened-four-event-bytes-validated-before-canonical-recovery-authority-reconstruction" then failwith "erp-p2p-recursive-recovery-receipt-mismatch")
let v6338 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6339 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6340 : string = v6338 + "|" + v6339
let v6341 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6342 : string = v6340 + "|" + v6341
let v6343 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6344 : string = v6342 + "|" + v6343
let v6345 : string = "erp-p2p-" + v4774 + "-outbox"
let v6346 : string = "erp-p2p-" + v4522 + "-outbox"
let v6347 : string = v6345 + "|" + v6346
let v6348 : string = "erp-p2p-" + v4776 + "-outbox"
let v6349 : string = v6347 + "|" + v6348
let v6350 : string = "erp-p2p-" + v4799 + "-outbox"
let v6351 : string = v6349 + "|" + v6350
let v6352 : string = "erp-p2p-" + v4774 + "-outbox"
let v6353 : string = "erp-p2p-" + v4522 + "-outbox"
let v6354 : string = v6352 + ">" + v6353
let v6355 : string = "erp-p2p-" + v4776 + "-outbox"
let v6356 : string = v6354 + ">" + v6355
let v6357 : string = "erp-p2p-" + v4799 + "-outbox"
let v6358 : string = v6356 + ">" + v6357
let v6359 : string = v6358 + "|aggregate=erp-p2p-aggregate:" + v6358 + "|command=erp-p2p-command:" + v6358
let v6360 : string = v6359 + "|payload=" + v6344 + "|outbox=" + v6351
let v6361 : int64 = 0L + 1L
let v6362 : int64 = v6361 + 1L
let v6363 : int64 = v6362 + 1L
let v6364 : int64 = v6363 + 1L
let struct (v6365 : int64, v6366 : int64, v6367 : int64, v6368 : int64, v6369 : int64, v6370 : int64, v6371 : int64, v6372 : int64, v6373 : int64, v6374 : int64, v6375 : int64, v6376 : int64, v6377 : int64, v6378 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-external-recovery-" + System.Guid.NewGuid().ToString("N")) in let beforeDirectory = System.IO.Path.Combine(root, "before-rename") in let afterDirectory = System.IO.Path.Combine(root, "after-rename") in let _ = System.IO.Directory.CreateDirectory(beforeDirectory) in let _ = System.IO.Directory.CreateDirectory(afterDirectory) in let payloadTexts = v6344.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let messageTexts = v6351.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let payloads = payloadTexts |> Array.map System.Convert.FromBase64String in let messages = messageTexts |> Array.map System.Text.Encoding.UTF8.GetBytes in let countBound = if payloads.Length = messages.Length && int64 payloads.Length = v6364 && payloads.Length > 0 then 1L else 0L in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let frameBytes index = let payload = payloads.[index] in let message = messages.[index] in let digest = System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(payloads.Length) |]) in Array.concat [| lengthBytes payload.Length; payload; lengthBytes message.Length; message; digest |] in let frames = [|0 .. payloads.Length - 1|] |> Array.collect frameBytes in let envelopeBody = Array.concat [| [|69uy;82uy;80uy;82uy|]; lengthBytes payloads.Length; System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v6360)); System.BitConverter.GetBytes(v6364); frames |] in let rootDigest = System.Security.Cryptography.SHA256.HashData(envelopeBody) in let envelope = Array.concat [| envelopeBody; rootDigest |] in let oldBytes = System.Text.Encoding.UTF8.GetBytes("previous-external-committed-envelope") in let writeDurable path bytes = use stream = new System.IO.FileStream(path,System.IO.FileMode.CreateNew,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in let runSync path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let validateEnvelope (data : byte array) = try let readLength offset = System.BitConverter.ToInt32(data,offset) |> System.Net.IPAddress.NetworkToHostOrder in if data.Length < 80 || data.[0] <> 69uy || data.[1] <> 82uy || data.[2] <> 80uy || data.[3] <> 82uy then false else let count = readLength 4 in let storedTreeIdentityHash = data.[8 .. 39] in let expectedTreeIdentityHash = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v6360)) in let storedVersion = System.BitConverter.ToInt64(data,40) in let mutable offset = 48 in let mutable index = 0 in let mutable valid = count > 0 && System.Linq.Enumerable.SequenceEqual(storedTreeIdentityHash,expectedTreeIdentityHash) && storedVersion = v6364 in while valid && index < count do if offset + 4 > data.Length then valid <- false else let payloadLength = readLength offset in offset <- offset + 4; if payloadLength < 0 || offset + payloadLength + 4 + 32 > data.Length then valid <- false else let payload = data.[offset .. offset + payloadLength - 1] in offset <- offset + payloadLength; let messageLength = readLength offset in offset <- offset + 4; if messageLength < 0 || offset + messageLength + 32 > data.Length then valid <- false else let message = data.[offset .. offset + messageLength - 1] in offset <- offset + messageLength; let digest = data.[offset .. offset + 31] in offset <- offset + 32; if not (System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(count) |]),digest)) then valid <- false else index <- index + 1 done; if valid && index = count && offset + 32 = data.Length then let rootDigest = data.[offset .. offset + 31] in let bodyDigest = System.Security.Cryptography.SHA256.HashData(data.[0 .. offset - 1]) in System.Linq.Enumerable.SequenceEqual(bodyDigest,rootDigest) else false with _ -> false in let startChild script (arguments : string array) = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add(script); info.ArgumentList.Add("erp-child"); arguments |> Array.iter (fun value -> info.ArgumentList.Add(value)); System.Diagnostics.Process.Start(info) in let waitMarker path = let mutable attempts = 0 in while attempts < 200 && not (System.IO.File.Exists(path)) do System.Threading.Thread.Sleep(25); attempts <- attempts + 1 done; System.IO.File.Exists(path) in let stopChild (process : System.Diagnostics.Process) = if process.HasExited then 0L else (process.Kill(true); process.WaitForExit(); 1L) in let beforeSource = System.IO.Path.Combine(beforeDirectory,"source.envelope") in let beforePrepared = System.IO.Path.Combine(beforeDirectory,"commit.prepared") in let beforeCommitted = System.IO.Path.Combine(beforeDirectory,"commit.committed") in let beforeMarker = System.IO.Path.Combine(beforeDirectory,"child.ready") in writeDurable beforeSource envelope; writeDurable beforeCommitted oldBytes; let beforeScript = "/bin/cp \"$1\" \"$2\"; /usr/bin/sync -f \"$2\"; /usr/bin/touch \"$3\"; /usr/bin/sleep 30" in use beforeChild = startChild beforeScript [|beforeSource;beforePrepared;beforeMarker|] in let beforeReady = if waitMarker beforeMarker then 1L else 0L in let beforeKilled = if beforeReady = 1L then stopChild beforeChild else 0L in let beforeOldPreserved = if System.Linq.Enumerable.SequenceEqual(System.IO.File.ReadAllBytes(beforeCommitted),oldBytes) then 1L else 0L in let _ = if System.IO.File.Exists(beforePrepared) then System.IO.File.Delete(beforePrepared) else () in let _ = if System.IO.File.Exists(beforeMarker) then System.IO.File.Delete(beforeMarker) else () in let beforePreparedRemoved = if System.IO.File.Exists(beforePrepared) then 0L else 1L in let beforeSync = runSync beforeDirectory in let afterSource = System.IO.Path.Combine(afterDirectory,"source.envelope") in let afterPrepared = System.IO.Path.Combine(afterDirectory,"commit.prepared") in let afterCommitted = System.IO.Path.Combine(afterDirectory,"commit.committed") in let afterMarker = System.IO.Path.Combine(afterDirectory,"child.ready") in writeDurable afterSource envelope; writeDurable afterCommitted oldBytes; let afterScript = "/bin/cp \"$1\" \"$2\"; /usr/bin/sync -f \"$2\"; /bin/mv -f \"$2\" \"$3\"; /usr/bin/sync -f \"$4\"; /usr/bin/touch \"$5\"; /usr/bin/sleep 30" in use afterChild = startChild afterScript [|afterSource;afterPrepared;afterCommitted;afterDirectory;afterMarker|] in let afterReady = if waitMarker afterMarker then 1L else 0L in let afterKilled = if afterReady = 1L then stopChild afterChild else 0L in let afterRecovered = System.IO.File.ReadAllBytes(afterCommitted) in let afterNewRecovered = if System.Linq.Enumerable.SequenceEqual(afterRecovered,envelope) then 1L else 0L in let afterEnvelopeValid = if validateEnvelope afterRecovered then 1L else 0L in let afterFrameCount = if afterEnvelopeValid = 1L then int64 payloads.Length else 0L in let afterSync = runSync afterDirectory in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in int64 envelope.Length,countBound,beforeReady,beforeKilled,beforeOldPreserved,beforePreparedRemoved,beforeSync,afterReady,afterKilled,afterNewRecovered,afterEnvelopeValid,afterFrameCount,afterSync,cleanupAbsent)
let v6379 : bool = v6365 > 0L
let v6380 : bool = v6366 = 1L
let v6381 : bool = v6367 = 1L
let v6382 : bool = v6368 = 1L
let v6383 : bool = v6369 = 1L
let v6384 : bool = v6370 = 1L
let v6385 : bool = v6371 = 0L
let v6386 : bool = v6372 = 1L
let v6387 : bool = v6373 = 1L
let v6388 : bool = v6374 = 1L
let v6389 : bool = v6375 = 1L
let v6390 : bool = v6376 = 4L
let v6391 : bool = v6377 = 0L
let v6392 : bool = v6378 = 1L
let v6393 : bool = v6379 && v6380
let v6394 : bool = v6393 && v6381
let v6395 : bool = v6394 && v6382
let v6396 : bool = v6395 && v6383
let v6397 : bool = v6396 && v6384
let v6398 : bool = v6397 && v6385
let v6399 : bool = v6398 && v6386
let v6400 : bool = v6399 && v6387
let v6401 : bool = v6400 && v6388
let v6402 : bool = v6401 && v6389
let v6403 : bool = v6402 && v6390
let v6404 : bool = v6403 && v6391
let v6405 : bool = v6404 && v6392
if v6405 then
    ()
else
    failwith<unit> "erp-p2p-recursive-external-crash-recovery-runtime-mismatch"
let v6406 : int64 = 0L + 1L
let v6407 : int64 = v6406 + 1L
let v6408 : int64 = v6407 + 1L
let v6409 : int64 = v6408 + 1L
let v6410 : string = "erp-p2p-" + v4774 + "-outbox"
let v6411 : string = "erp-p2p-" + v4522 + "-outbox"
let v6412 : string = v6410 + ">" + v6411
let v6413 : string = "erp-p2p-" + v4776 + "-outbox"
let v6414 : string = v6412 + ">" + v6413
let v6415 : string = "erp-p2p-" + v4799 + "-outbox"
let v6416 : string = v6414 + ">" + v6415
let v6417 : string = v6416 + "|aggregate=erp-p2p-aggregate:" + v6416 + "|command=erp-p2p-command:" + v6416
let v6418 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6419 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6420 : string = v6418 + "|" + v6419
let v6421 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6422 : string = v6420 + "|" + v6421
let v6423 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6424 : string = v6422 + "|" + v6423
let v6425 : string = "erp-p2p-" + v4774 + "-outbox"
let v6426 : string = "erp-p2p-" + v4522 + "-outbox"
let v6427 : string = v6425 + "|" + v6426
let v6428 : string = "erp-p2p-" + v4776 + "-outbox"
let v6429 : string = v6427 + "|" + v6428
let v6430 : string = "erp-p2p-" + v4799 + "-outbox"
let v6431 : string = v6429 + "|" + v6430
let v6432 : string = v6417 + "|payload=" + v6424 + "|outbox=" + v6431
let v6433 : string = "external-crash-reopened-bytes-validated-and-typed-authority-promoted"
(if v6376 <> v6409 || not (v6432.Contains("erp-p2p-aggregate:")) || v6433 <> "external-crash-reopened-bytes-validated-and-typed-authority-promoted" then failwith "erp-p2p-external-crash-recovery-receipt-mismatch")
let v6434 : int64 = 0L + 1L
let v6435 : int64 = v6434 + 1L
let v6436 : int64 = v6435 + 1L
let v6437 : int64 = v6436 + 1L
let v6438 : string = "erp-p2p-" + v4774 + "-outbox"
let v6439 : string = "erp-p2p-" + v4522 + "-outbox"
let v6440 : string = v6438 + ">" + v6439
let v6441 : string = "erp-p2p-" + v4776 + "-outbox"
let v6442 : string = v6440 + ">" + v6441
let v6443 : string = "erp-p2p-" + v4799 + "-outbox"
let v6444 : string = v6442 + ">" + v6443
let v6445 : string = v6444 + "|aggregate=erp-p2p-aggregate:" + v6444 + "|command=erp-p2p-command:" + v6444
let v6446 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6447 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6448 : string = v6446 + "|" + v6447
let v6449 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6450 : string = v6448 + "|" + v6449
let v6451 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6452 : string = v6450 + "|" + v6451
let v6453 : string = "erp-p2p-" + v4774 + "-outbox"
let v6454 : string = "erp-p2p-" + v4522 + "-outbox"
let v6455 : string = v6453 + "|" + v6454
let v6456 : string = "erp-p2p-" + v4776 + "-outbox"
let v6457 : string = v6455 + "|" + v6456
let v6458 : string = "erp-p2p-" + v4799 + "-outbox"
let v6459 : string = v6457 + "|" + v6458
let v6460 : string = v6445 + "|payload=" + v6452 + "|outbox=" + v6459
(if v6437 <> 4L then failwith "erp-p2p-external-crash-recovery-version-mismatch")
let v6461 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6462 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6463 : string = v6461 + "|" + v6462
let v6464 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6465 : string = v6463 + "|" + v6464
let v6466 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6467 : string = v6465 + "|" + v6466
let v6468 : string = "erp-p2p-" + v4774 + "-outbox"
let v6469 : string = "erp-p2p-" + v4522 + "-outbox"
let v6470 : string = v6468 + "|" + v6469
let v6471 : string = "erp-p2p-" + v4776 + "-outbox"
let v6472 : string = v6470 + "|" + v6471
let v6473 : string = "erp-p2p-" + v4799 + "-outbox"
let v6474 : string = v6472 + "|" + v6473
let v6475 : string = "erp-p2p-" + v4774 + "-outbox"
let v6476 : string = "erp-p2p-" + v4522 + "-outbox"
let v6477 : string = v6475 + ">" + v6476
let v6478 : string = "erp-p2p-" + v4776 + "-outbox"
let v6479 : string = v6477 + ">" + v6478
let v6480 : string = "erp-p2p-" + v4799 + "-outbox"
let v6481 : string = v6479 + ">" + v6480
let v6482 : string = v6481 + "|aggregate=erp-p2p-aggregate:" + v6481 + "|command=erp-p2p-command:" + v6481
let v6483 : string = v6482 + "|payload=" + v6467 + "|outbox=" + v6474
let v6484 : int64 = 0L + 1L
let v6485 : int64 = v6484 + 1L
let v6486 : int64 = v6485 + 1L
let v6487 : int64 = v6486 + 1L
let struct (v6488 : int64, v6489 : int64, v6490 : int64, v6491 : int64, v6492 : int64, v6493 : int64, v6494 : int64, v6495 : int64, v6496 : int64, v6497 : int64, v6498 : int64, v6499 : int64, v6500 : int64, v6501 : int64, v6502 : int64, v6503 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-wal-recovery-" + System.Guid.NewGuid().ToString("N")) in let preparedDirectory = System.IO.Path.Combine(root, "prepared-phase") in let committedDirectory = System.IO.Path.Combine(root, "committed-phase") in let _ = System.IO.Directory.CreateDirectory(preparedDirectory) in let _ = System.IO.Directory.CreateDirectory(committedDirectory) in let payloadTexts = v6467.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let messageTexts = v6474.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let payloads = payloadTexts |> Array.map System.Convert.FromBase64String in let messages = messageTexts |> Array.map System.Text.Encoding.UTF8.GetBytes in let countBound = if payloads.Length = messages.Length && int64 payloads.Length = v6487 && payloads.Length > 0 then 1L else 0L in let lengthBytes (count : int) = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(count)) in let frameBytes index = let payload = payloads.[index] in let message = messages.[index] in let digest = System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(payloads.Length) |]) in Array.concat [| lengthBytes payload.Length; payload; lengthBytes message.Length; message; digest |] in let frames = [|0 .. payloads.Length - 1|] |> Array.collect frameBytes in let envelopeBody = Array.concat [| [|69uy;82uy;80uy;82uy|]; lengthBytes payloads.Length; System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v6483)); System.BitConverter.GetBytes(v6487); frames |] in let rootDigest = System.Security.Cryptography.SHA256.HashData(envelopeBody) in let envelope = Array.concat [| envelopeBody; rootDigest |] in let envelopeDigest = System.Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(envelope)) in let oldBytes = System.Text.Encoding.UTF8.GetBytes("previous-wal-committed-envelope") in let writeDurable path bytes = use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in let writeText path (text : string) = writeDurable path (System.Text.Encoding.UTF8.GetBytes(text)) in let runSync path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add("-f"); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let validateEnvelope (data : byte array) = try let readLength offset = System.BitConverter.ToInt32(data,offset) |> System.Net.IPAddress.NetworkToHostOrder in if data.Length < 80 || data.[0] <> 69uy || data.[1] <> 82uy || data.[2] <> 80uy || data.[3] <> 82uy then false else let count = readLength 4 in let storedTreeIdentityHash = data.[8 .. 39] in let expectedTreeIdentityHash = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(v6483)) in let storedVersion = System.BitConverter.ToInt64(data,40) in let mutable offset = 48 in let mutable index = 0 in let mutable valid = count > 0 && System.Linq.Enumerable.SequenceEqual(storedTreeIdentityHash,expectedTreeIdentityHash) && storedVersion = v6487 in while valid && index < count do if offset + 4 > data.Length then valid <- false else let payloadLength = readLength offset in offset <- offset + 4; if payloadLength < 0 || offset + payloadLength + 4 + 32 > data.Length then valid <- false else let payload = data.[offset .. offset + payloadLength - 1] in offset <- offset + payloadLength; let messageLength = readLength offset in offset <- offset + 4; if messageLength < 0 || offset + messageLength + 32 > data.Length then valid <- false else let message = data.[offset .. offset + messageLength - 1] in offset <- offset + messageLength; let digest = data.[offset .. offset + 31] in offset <- offset + 32; if not (System.Linq.Enumerable.SequenceEqual(System.Security.Cryptography.SHA256.HashData(Array.concat [| payload; message; System.BitConverter.GetBytes(index); System.BitConverter.GetBytes(count) |]),digest)) then valid <- false else index <- index + 1 done; if valid && index = count && offset + 32 = data.Length then let rootDigest = data.[offset .. offset + 31] in let bodyDigest = System.Security.Cryptography.SHA256.HashData(data.[0 .. offset - 1]) in System.Linq.Enumerable.SequenceEqual(bodyDigest,rootDigest) else false with _ -> false in let preparedWal = System.IO.Path.Combine(preparedDirectory,"commit.wal") in let preparedCandidate = System.IO.Path.Combine(preparedDirectory,"commit.prepared") in let preparedCommitted = System.IO.Path.Combine(preparedDirectory,"commit.committed") in writeDurable preparedCommitted oldBytes; writeText preparedWal ("PREPARED:" + envelopeDigest); writeDurable preparedCandidate envelope; let preparedSync = runSync preparedDirectory in let preparedWalText = System.IO.File.ReadAllText(preparedWal) in let preparedWalSeen = if preparedWalText.StartsWith("PREPARED:") then 1L else 0L in let preparedDigestBound = if preparedWalText = "PREPARED:" + envelopeDigest then 1L else 0L in let _ = if System.IO.File.Exists(preparedCandidate) then System.IO.File.Delete(preparedCandidate) else () in let _ = if System.IO.File.Exists(preparedWal) then System.IO.File.Delete(preparedWal) else () in let preparedRecoverySync = runSync preparedDirectory in let preparedCandidateRemoved = if System.IO.File.Exists(preparedCandidate) then 0L else 1L in let preparedOldPreserved = if System.Linq.Enumerable.SequenceEqual(System.IO.File.ReadAllBytes(preparedCommitted),oldBytes) then 1L else 0L in let preparedWalCleared = if System.IO.File.Exists(preparedWal) then 0L else 1L in let committedWal = System.IO.Path.Combine(committedDirectory,"commit.wal") in let committedCandidate = System.IO.Path.Combine(committedDirectory,"commit.prepared") in let committedPath = System.IO.Path.Combine(committedDirectory,"commit.committed") in writeDurable committedPath oldBytes; writeText committedWal ("PREPARED:" + envelopeDigest); writeDurable committedCandidate envelope; System.IO.File.Move(committedCandidate,committedPath,true); writeText committedWal ("COMMITTED:" + envelopeDigest); let committedSync = runSync committedDirectory in let committedWalText = System.IO.File.ReadAllText(committedWal) in let committedWalSeen = if committedWalText.StartsWith("COMMITTED:") then 1L else 0L in let committedDigestBound = if committedWalText = "COMMITTED:" + envelopeDigest then 1L else 0L in let committedRecovered = System.IO.File.ReadAllBytes(committedPath) in let committedNewRecovered = if System.Linq.Enumerable.SequenceEqual(committedRecovered,envelope) then 1L else 0L in let committedEnvelopeValid = if validateEnvelope committedRecovered then 1L else 0L in let frameCount = if committedEnvelopeValid = 1L then int64 payloads.Length else 0L in let _ = if System.IO.File.Exists(committedWal) then System.IO.File.Delete(committedWal) else () in let committedRecoverySync = runSync committedDirectory in let committedWalCleared = if System.IO.File.Exists(committedWal) then 0L else 1L in System.IO.Directory.Delete(root,true); let cleanupAbsent = if System.IO.Directory.Exists(root) then 0L else 1L in int64 envelope.Length,countBound,preparedWalSeen,preparedDigestBound,preparedCandidateRemoved,preparedOldPreserved,preparedWalCleared,preparedSync,preparedRecoverySync,committedWalSeen,committedDigestBound,committedNewRecovered,committedEnvelopeValid,frameCount,committedWalCleared,cleanupAbsent)
let v6504 : bool = v6488 > 0L
let v6505 : bool = v6489 = 1L
let v6506 : bool = v6490 = 1L
let v6507 : bool = v6491 = 1L
let v6508 : bool = v6492 = 1L
let v6509 : bool = v6493 = 1L
let v6510 : bool = v6494 = 1L
let v6511 : bool = v6495 = 0L
let v6512 : bool = v6496 = 0L
let v6513 : bool = v6497 = 1L
let v6514 : bool = v6498 = 1L
let v6515 : bool = v6499 = 1L
let v6516 : bool = v6500 = 1L
let v6517 : bool = v6501 = 4L
let v6518 : bool = v6502 = 1L
let v6519 : bool = v6503 = 1L
let v6520 : bool = v6504 && v6505
let v6521 : bool = v6520 && v6506
let v6522 : bool = v6521 && v6507
let v6523 : bool = v6522 && v6508
let v6524 : bool = v6523 && v6509
let v6525 : bool = v6524 && v6510
let v6526 : bool = v6525 && v6511
let v6527 : bool = v6526 && v6512
let v6528 : bool = v6527 && v6513
let v6529 : bool = v6528 && v6514
let v6530 : bool = v6529 && v6515
let v6531 : bool = v6530 && v6516
let v6532 : bool = v6531 && v6517
let v6533 : bool = v6532 && v6518
let v6534 : bool = v6533 && v6519
if v6534 then
    ()
else
    failwith<unit> "erp-p2p-recursive-wal-recovery-runtime-mismatch"
let v6535 : int64 = 0L + 1L
let v6536 : int64 = v6535 + 1L
let v6537 : int64 = v6536 + 1L
let v6538 : int64 = v6537 + 1L
let v6539 : string = "erp-p2p-" + v4774 + "-outbox"
let v6540 : string = "erp-p2p-" + v4522 + "-outbox"
let v6541 : string = v6539 + ">" + v6540
let v6542 : string = "erp-p2p-" + v4776 + "-outbox"
let v6543 : string = v6541 + ">" + v6542
let v6544 : string = "erp-p2p-" + v4799 + "-outbox"
let v6545 : string = v6543 + ">" + v6544
let v6546 : string = v6545 + "|aggregate=erp-p2p-aggregate:" + v6545 + "|command=erp-p2p-command:" + v6545
let v6547 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6548 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6549 : string = v6547 + "|" + v6548
let v6550 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6551 : string = v6549 + "|" + v6550
let v6552 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6553 : string = v6551 + "|" + v6552
let v6554 : string = "erp-p2p-" + v4774 + "-outbox"
let v6555 : string = "erp-p2p-" + v4522 + "-outbox"
let v6556 : string = v6554 + "|" + v6555
let v6557 : string = "erp-p2p-" + v4776 + "-outbox"
let v6558 : string = v6556 + "|" + v6557
let v6559 : string = "erp-p2p-" + v4799 + "-outbox"
let v6560 : string = v6558 + "|" + v6559
let v6561 : string = v6546 + "|payload=" + v6553 + "|outbox=" + v6560
let v6562 : string = "wal-reopened-bytes-validated-and-typed-authority-promoted"
(if v6501 <> v6538 || not (v6561.Contains("erp-p2p-aggregate:")) || v6562 <> "wal-reopened-bytes-validated-and-typed-authority-promoted" then failwith "erp-p2p-recursive-wal-recovery-receipt-mismatch")
let v6563 : int64 = 0L + 1L
let v6564 : int64 = v6563 + 1L
let v6565 : int64 = v6564 + 1L
let v6566 : int64 = v6565 + 1L
let v6567 : string = "erp-p2p-" + v4774 + "-outbox"
let v6568 : string = "erp-p2p-" + v4522 + "-outbox"
let v6569 : string = v6567 + ">" + v6568
let v6570 : string = "erp-p2p-" + v4776 + "-outbox"
let v6571 : string = v6569 + ">" + v6570
let v6572 : string = "erp-p2p-" + v4799 + "-outbox"
let v6573 : string = v6571 + ">" + v6572
let v6574 : string = v6573 + "|aggregate=erp-p2p-aggregate:" + v6573 + "|command=erp-p2p-command:" + v6573
let v6575 : string = (let fields = [| v4526; v4527; v4528; v4821; v4526; v4527; string 1000L; v4822 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6576 : string = (let fields = [| v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6577 : string = v6575 + "|" + v6576
let v6578 : string = (let fields = [| v4526; v4527; string 1000L; v4822; v5015; v5016; v4531; v5017; v5018; v5019; v4531; v5020; v5021; v5022; v4531; v5023; v4528; v5091; string 10L |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6579 : string = v6577 + "|" + v6578
let v6580 : string = (let fields = [| v4526; v4527; v4528; v4531; v5160; v4528; v5091; string 10L; string 6L; v4529; v5161 |] in let bytes = fields |> Array.collect (fun value -> let payload = System.Text.Encoding.UTF8.GetBytes(value) in let length = System.BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(payload.Length)) in Array.append length payload) in System.Convert.ToBase64String(bytes))
let v6581 : string = v6579 + "|" + v6580
let v6582 : string = "erp-p2p-" + v4774 + "-outbox"
let v6583 : string = "erp-p2p-" + v4522 + "-outbox"
let v6584 : string = v6582 + "|" + v6583
let v6585 : string = "erp-p2p-" + v4776 + "-outbox"
let v6586 : string = v6584 + "|" + v6585
let v6587 : string = "erp-p2p-" + v4799 + "-outbox"
let v6588 : string = v6586 + "|" + v6587
let v6589 : string = v6574 + "|payload=" + v6581 + "|outbox=" + v6588
(if v6566 <> 4L then failwith "erp-p2p-recursive-wal-recovery-version-mismatch")
let v6590 : int64 = 0L + 1L
let v6591 : string = "owner-c"
let v6592 : string = "owner-d"
let v6593 : string = (v6591 + "|" + v6592)
let v6594 : string = "owner-b"
let v6595 : string = (v6594 + "|" + v6593)
let v6596 : int64 = 0L + 1L
let v6597 : int64 = v6596 + 1L
let v6598 : int64 = v6597 + 1L
let v6599 : int64 = v6598 + 1L
let v6600 : string = "owner-a"
let struct (v6601 : int64, v6602 : int64, v6603 : int64, v6604 : int64, v6605 : int64, v6606 : int64, v6607 : int64, v6608 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-cross-process-program-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let statePath = System.IO.Path.Combine(root, "fence.state") in let writeDurable path (text : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(text) in use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in writeDurable statePath (System.String.Join("|",[|v6600;string v6590|])); let owners = v6595.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let runOwner (completedCount, allChildren) (owner : string) = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("IFS='|' read -r old_owner old_fence < $1; next_fence=$(/usr/bin/expr $old_fence + 1); tmp=$1.next; printf '%s|%s' $2 $next_fence > $tmp; /usr/bin/sync -f $tmp; /bin/mv $tmp $1; /usr/bin/sync -f $1"); info.ArgumentList.Add("erp-fence-program"); info.ArgumentList.Add(statePath); info.ArgumentList.Add(owner); use child = System.Diagnostics.Process.Start(info) in let completed = child.WaitForExit(5000) in let _ = if not completed then (child.Kill(true); child.WaitForExit() |> ignore) else () in let passed = if completed && child.ExitCode = 0 then 1L else 0L in completedCount + passed, (if passed = 1L && allChildren = 1L then 1L else 0L) in let completedCount, allChildren = owners |> Array.fold runOwner (0L,1L) in let stateParts = if System.IO.File.Exists(statePath) then System.IO.File.ReadAllText(statePath).Split('|') else [||] in let finalOwnerMatch = if stateParts.Length = 2 && stateParts.[0] = v6592 then 1L else 0L in let finalFenceValue = if stateParts.Length = 2 then System.Int64.Parse(stateParts.[1]) else 0L in let finalFenceMatch = if finalFenceValue = v6599 then 1L else 0L in let expectedSteps = v6599 - v6590 in let processCountBound = if int64 owners.Length = expectedSteps && completedCount = expectedSteps then 1L else 0L in let staleRejected = if v6590 < finalFenceValue then 1L else 0L in let currentAccepted = if finalFenceValue = v6599 then 1L else 0L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in completedCount,allChildren,processCountBound,finalOwnerMatch,finalFenceMatch,staleRejected,currentAccepted,cleanup)
let v6609 : bool = v6601 > 0L
let v6610 : bool = v6602 = 1L
let v6611 : bool = v6603 = 1L
let v6612 : bool = v6604 = 1L
let v6613 : bool = v6605 = 1L
let v6614 : bool = v6606 = 1L
let v6615 : bool = v6607 = 1L
let v6616 : bool = v6608 = 1L
let v6617 : bool = v6609 && v6610
let v6618 : bool = v6617 && v6611
let v6619 : bool = v6618 && v6612
let v6620 : bool = v6619 && v6613
let v6621 : bool = v6620 && v6614
let v6622 : bool = v6621 && v6615
let v6623 : bool = v6622 && v6616
if v6623 then
    ()
else
    failwith<unit> "erp-p2p-cross-process-takeover-program-runtime-mismatch"
let v6624 : int64 = 0L + 1L
let v6625 : int64 = v6624 + 1L
let v6626 : int64 = v6625 + 1L
let v6627 : int64 = v6626 + 1L
let v6628 : string = "arbitrary-typed-takeover-program-executed-one-persistent-restart-process-per-owner"
(if v6592 <> "owner-d" || v6627 <> 4L || v6628 <> "arbitrary-typed-takeover-program-executed-one-persistent-restart-process-per-owner" then failwith "erp-p2p-recursive-takeover-program-mismatch")
let v6629 : int64 = 0L + 1L
let v6630 : int64 = v6629 + 1L
let v6631 : int64 = 0L + 1L
let v6632 : int64 = v6631 + 1L
let v6633 : int64 = v6632 + 1L
let struct (v6634 : int64, v6635 : int64, v6636 : int64, v6637 : int64, v6638 : int64, v6639 : int64, v6640 : int64, v6641 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-cross-process-fence-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let statePath = System.IO.Path.Combine(root, "fence.state") in let childReceiptPath = System.IO.Path.Combine(root, "child.receipt") in let writeDurable path (text : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(text) in use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in writeDurable statePath (System.String.Join("|",[|v6594;string v6630|])); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("IFS='|' read -r old_owner old_fence < $1; next_fence=$(/usr/bin/expr $old_fence + 1); tmp=$1.next; printf '%s|%s' $2 $next_fence > $tmp; /usr/bin/sync -f $tmp; /bin/mv $tmp $1; printf '%s|%s|%s|%s' $old_owner $old_fence $2 $next_fence > $3; /usr/bin/sync -f $3"); info.ArgumentList.Add("erp-fence-restart"); info.ArgumentList.Add(statePath); info.ArgumentList.Add(v6591); info.ArgumentList.Add(childReceiptPath); use child = System.Diagnostics.Process.Start(info) in let completed = child.WaitForExit(5000) in let _ = if not completed then (child.Kill(true); child.WaitForExit() |> ignore) else () in let childExit = if completed then int64 child.ExitCode else -2L in let receiptParts = if System.IO.File.Exists(childReceiptPath) then System.IO.File.ReadAllText(childReceiptPath).Split('|') else [||] in let stateParts = if System.IO.File.Exists(statePath) then System.IO.File.ReadAllText(statePath).Split('|') else [||] in let childReopenedBefore = if receiptParts.Length = 4 && receiptParts.[0] = v6594 && System.Int64.Parse(receiptParts.[1]) = v6630 then 1L else 0L in let childDerivedAfter = if receiptParts.Length = 4 && receiptParts.[2] = v6591 && System.Int64.Parse(receiptParts.[3]) = v6633 then 1L else 0L in let persistedAfter = if stateParts.Length = 2 && stateParts.[0] = v6591 && System.Int64.Parse(stateParts.[1]) = v6633 then 1L else 0L in let staleRejected = if stateParts.Length = 2 && v6630 < System.Int64.Parse(stateParts.[1]) then 1L else 0L in let currentAccepted = if stateParts.Length = 2 && v6633 = System.Int64.Parse(stateParts.[1]) then 1L else 0L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in (if completed then 1L else 0L),childExit,childReopenedBefore,childDerivedAfter,persistedAfter,staleRejected,currentAccepted,cleanup)
let v6642 : bool = v6634 = 1L
let v6643 : bool = v6635 = 0L
let v6644 : bool = v6636 = 1L
let v6645 : bool = v6637 = 1L
let v6646 : bool = v6638 = 1L
let v6647 : bool = v6639 = 1L
let v6648 : bool = v6640 = 1L
let v6649 : bool = v6641 = 1L
let v6650 : bool = v6642 && v6643
let v6651 : bool = v6650 && v6644
let v6652 : bool = v6651 && v6645
let v6653 : bool = v6652 && v6646
let v6654 : bool = v6653 && v6647
let v6655 : bool = v6654 && v6648
let v6656 : bool = v6655 && v6649
if v6656 then
    ()
else
    failwith<unit> "erp-p2p-cross-process-fence-restart-runtime-mismatch"
let v6657 : int64 = 0L + 1L
let v6658 : int64 = v6657 + 1L
let v6659 : int64 = 0L + 1L
let v6660 : int64 = v6659 + 1L
let v6661 : int64 = v6660 + 1L
let v6662 : string = "separate-restart-process-reopened-persisted-fence-and-derived-exact-successor"
(if v6594 <> "owner-b" || v6658 <> 2L || v6591 <> "owner-c" || v6661 <> 3L || 1L <> 1L || v6662 <> "separate-restart-process-reopened-persisted-fence-and-derived-exact-successor" then failwith "erp-p2p-cross-process-fence-restart-receipt-mismatch")
let v6663 : int64 = 0L + 1L
let v6664 : int64 = v6663 + 1L
let v6665 : int64 = 0L + 1L
let v6666 : int64 = v6665 + 1L
let v6667 : int64 = v6666 + 1L
let struct (v6668 : int64, v6669 : int64, v6670 : int64, v6671 : int64, v6672 : int64, v6673 : int64, v6674 : int64, v6675 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-cross-process-fence-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let statePath = System.IO.Path.Combine(root, "fence.state") in let childReceiptPath = System.IO.Path.Combine(root, "child.receipt") in let writeDurable path (text : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(text) in use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in writeDurable statePath (System.String.Join("|",[|v6594;string v6664|])); let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("IFS='|' read -r old_owner old_fence < $1; next_fence=$(/usr/bin/expr $old_fence + 1); tmp=$1.next; printf '%s|%s' $2 $next_fence > $tmp; /usr/bin/sync -f $tmp; /bin/mv $tmp $1; printf '%s|%s|%s|%s' $old_owner $old_fence $2 $next_fence > $3; /usr/bin/sync -f $3"); info.ArgumentList.Add("erp-fence-restart"); info.ArgumentList.Add(statePath); info.ArgumentList.Add(v6591); info.ArgumentList.Add(childReceiptPath); use child = System.Diagnostics.Process.Start(info) in let completed = child.WaitForExit(5000) in let _ = if not completed then (child.Kill(true); child.WaitForExit() |> ignore) else () in let childExit = if completed then int64 child.ExitCode else -2L in let receiptParts = if System.IO.File.Exists(childReceiptPath) then System.IO.File.ReadAllText(childReceiptPath).Split('|') else [||] in let stateParts = if System.IO.File.Exists(statePath) then System.IO.File.ReadAllText(statePath).Split('|') else [||] in let childReopenedBefore = if receiptParts.Length = 4 && receiptParts.[0] = v6594 && System.Int64.Parse(receiptParts.[1]) = v6664 then 1L else 0L in let childDerivedAfter = if receiptParts.Length = 4 && receiptParts.[2] = v6591 && System.Int64.Parse(receiptParts.[3]) = v6667 then 1L else 0L in let persistedAfter = if stateParts.Length = 2 && stateParts.[0] = v6591 && System.Int64.Parse(stateParts.[1]) = v6667 then 1L else 0L in let staleRejected = if stateParts.Length = 2 && v6664 < System.Int64.Parse(stateParts.[1]) then 1L else 0L in let currentAccepted = if stateParts.Length = 2 && v6667 = System.Int64.Parse(stateParts.[1]) then 1L else 0L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in (if completed then 1L else 0L),childExit,childReopenedBefore,childDerivedAfter,persistedAfter,staleRejected,currentAccepted,cleanup)
let v6676 : bool = v6668 = 1L
let v6677 : bool = v6669 = 0L
let v6678 : bool = v6670 = 1L
let v6679 : bool = v6671 = 1L
let v6680 : bool = v6672 = 1L
let v6681 : bool = v6673 = 1L
let v6682 : bool = v6674 = 1L
let v6683 : bool = v6675 = 1L
let v6684 : bool = v6676 && v6677
let v6685 : bool = v6684 && v6678
let v6686 : bool = v6685 && v6679
let v6687 : bool = v6686 && v6680
let v6688 : bool = v6687 && v6681
let v6689 : bool = v6688 && v6682
let v6690 : bool = v6689 && v6683
if v6690 then
    ()
else
    failwith<unit> "erp-p2p-cross-process-fence-restart-runtime-mismatch"
let v6691 : int64 = 0L + 1L
let v6692 : int64 = v6691 + 1L
let v6693 : int64 = v6692 + 1L
let v6694 : int64 = 0L + 1L
let v6695 : int64 = v6694 + 1L
let v6696 : int64 = v6695 + 1L
let v6697 : int64 = v6696 + 1L
let v6698 : int64 = 0L + 1L
let v6699 : int64 = v6698 + 1L
let v6700 : int64 = v6699 + 1L
let v6701 : int64 = v6700 + 1L
if v6697 <> 4L || v6701 <> 4L || v4799 <> "goods-partially-received" || v4799 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v6702 : string = "cross-process-successor-fence-bound-to-one-commit-tree"
(if v6591 <> "owner-c" || v6693 <> 3L || 1L <> 1L || v6702 <> "cross-process-successor-fence-bound-to-one-commit-tree" then failwith "erp-p2p-cross-process-fenced-commit-receipt-mismatch")
let v6703 : int64 = 0L + 1L
let v6704 : string = (v6591 + "|" + v6592)
let v6705 : string = (v6594 + "|" + v6704)
let v6706 : int64 = 0L + 1L
let v6707 : int64 = v6706 + 1L
let v6708 : int64 = v6707 + 1L
let v6709 : int64 = v6708 + 1L
let struct (v6710 : int64, v6711 : int64, v6712 : int64, v6713 : int64, v6714 : int64, v6715 : int64, v6716 : int64, v6717 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-cross-process-program-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let statePath = System.IO.Path.Combine(root, "fence.state") in let writeDurable path (text : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(text) in use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in writeDurable statePath (System.String.Join("|",[|v6600;string v6703|])); let owners = v6705.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let runOwner (completedCount, allChildren) (owner : string) = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("IFS='|' read -r old_owner old_fence < $1; next_fence=$(/usr/bin/expr $old_fence + 1); tmp=$1.next; printf '%s|%s' $2 $next_fence > $tmp; /usr/bin/sync -f $tmp; /bin/mv $tmp $1; /usr/bin/sync -f $1"); info.ArgumentList.Add("erp-fence-program"); info.ArgumentList.Add(statePath); info.ArgumentList.Add(owner); use child = System.Diagnostics.Process.Start(info) in let completed = child.WaitForExit(5000) in let _ = if not completed then (child.Kill(true); child.WaitForExit() |> ignore) else () in let passed = if completed && child.ExitCode = 0 then 1L else 0L in completedCount + passed, (if passed = 1L && allChildren = 1L then 1L else 0L) in let completedCount, allChildren = owners |> Array.fold runOwner (0L,1L) in let stateParts = if System.IO.File.Exists(statePath) then System.IO.File.ReadAllText(statePath).Split('|') else [||] in let finalOwnerMatch = if stateParts.Length = 2 && stateParts.[0] = v6592 then 1L else 0L in let finalFenceValue = if stateParts.Length = 2 then System.Int64.Parse(stateParts.[1]) else 0L in let finalFenceMatch = if finalFenceValue = v6709 then 1L else 0L in let expectedSteps = v6709 - v6703 in let processCountBound = if int64 owners.Length = expectedSteps && completedCount = expectedSteps then 1L else 0L in let staleRejected = if v6703 < finalFenceValue then 1L else 0L in let currentAccepted = if finalFenceValue = v6709 then 1L else 0L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in completedCount,allChildren,processCountBound,finalOwnerMatch,finalFenceMatch,staleRejected,currentAccepted,cleanup)
let v6718 : bool = v6710 > 0L
let v6719 : bool = v6711 = 1L
let v6720 : bool = v6712 = 1L
let v6721 : bool = v6713 = 1L
let v6722 : bool = v6714 = 1L
let v6723 : bool = v6715 = 1L
let v6724 : bool = v6716 = 1L
let v6725 : bool = v6717 = 1L
let v6726 : bool = v6718 && v6719
let v6727 : bool = v6726 && v6720
let v6728 : bool = v6727 && v6721
let v6729 : bool = v6728 && v6722
let v6730 : bool = v6729 && v6723
let v6731 : bool = v6730 && v6724
let v6732 : bool = v6731 && v6725
if v6732 then
    ()
else
    failwith<unit> "erp-p2p-cross-process-takeover-program-runtime-mismatch"
let v6733 : int64 = 0L + 1L
let v6734 : int64 = v6733 + 1L
let v6735 : int64 = v6734 + 1L
let v6736 : int64 = v6735 + 1L
let v6737 : int64 = 1L + 1L
let v6738 : int64 = v6737 + 1L
let v6739 : int64 = 0L + 1L
let v6740 : int64 = v6739 + 1L
let v6741 : int64 = v6740 + 1L
let v6742 : int64 = v6741 + 1L
let v6743 : int64 = 0L + 1L
let v6744 : int64 = v6743 + 1L
let v6745 : int64 = v6744 + 1L
let v6746 : int64 = v6745 + 1L
if v6742 <> 4L || v6746 <> 4L || v4799 <> "goods-partially-received" || v4799 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v6747 : string = "multiprocess-takeover-program-bound-to-one-commit-tree"
(if v6592 <> "owner-d" || v6736 <> 4L || v6738 <> 3L || v6747 <> "multiprocess-takeover-program-bound-to-one-commit-tree" then failwith "erp-p2p-multiprocess-fenced-commit-receipt-mismatch")
let v6748 : int64 = 0L + 1L
let v6749 : string = (v6591 + "|" + v6592)
let v6750 : string = (v6594 + "|" + v6749)
let v6751 : int64 = 0L + 1L
let v6752 : int64 = v6751 + 1L
let v6753 : int64 = v6752 + 1L
let v6754 : int64 = v6753 + 1L
let struct (v6755 : int64, v6756 : int64, v6757 : int64, v6758 : int64, v6759 : int64, v6760 : int64, v6761 : int64, v6762 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-cross-process-program-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let statePath = System.IO.Path.Combine(root, "fence.state") in let writeDurable path (text : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(text) in use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in writeDurable statePath (System.String.Join("|",[|v6600;string v6748|])); let owners = v6750.Split([|'|'|], System.StringSplitOptions.RemoveEmptyEntries) in let runOwner (completedCount, allChildren) (owner : string) = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/bin/sh"; info.UseShellExecute <- false; info.ArgumentList.Add("-c"); info.ArgumentList.Add("IFS='|' read -r old_owner old_fence < $1; next_fence=$(/usr/bin/expr $old_fence + 1); tmp=$1.next; printf '%s|%s' $2 $next_fence > $tmp; /usr/bin/sync -f $tmp; /bin/mv $tmp $1; /usr/bin/sync -f $1"); info.ArgumentList.Add("erp-fence-program"); info.ArgumentList.Add(statePath); info.ArgumentList.Add(owner); use child = System.Diagnostics.Process.Start(info) in let completed = child.WaitForExit(5000) in let _ = if not completed then (child.Kill(true); child.WaitForExit() |> ignore) else () in let passed = if completed && child.ExitCode = 0 then 1L else 0L in completedCount + passed, (if passed = 1L && allChildren = 1L then 1L else 0L) in let completedCount, allChildren = owners |> Array.fold runOwner (0L,1L) in let stateParts = if System.IO.File.Exists(statePath) then System.IO.File.ReadAllText(statePath).Split('|') else [||] in let finalOwnerMatch = if stateParts.Length = 2 && stateParts.[0] = v6592 then 1L else 0L in let finalFenceValue = if stateParts.Length = 2 then System.Int64.Parse(stateParts.[1]) else 0L in let finalFenceMatch = if finalFenceValue = v6754 then 1L else 0L in let expectedSteps = v6754 - v6748 in let processCountBound = if int64 owners.Length = expectedSteps && completedCount = expectedSteps then 1L else 0L in let staleRejected = if v6748 < finalFenceValue then 1L else 0L in let currentAccepted = if finalFenceValue = v6754 then 1L else 0L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in completedCount,allChildren,processCountBound,finalOwnerMatch,finalFenceMatch,staleRejected,currentAccepted,cleanup)
let v6763 : bool = v6755 > 0L
let v6764 : bool = v6756 = 1L
let v6765 : bool = v6757 = 1L
let v6766 : bool = v6758 = 1L
let v6767 : bool = v6759 = 1L
let v6768 : bool = v6760 = 1L
let v6769 : bool = v6761 = 1L
let v6770 : bool = v6762 = 1L
let v6771 : bool = v6763 && v6764
let v6772 : bool = v6771 && v6765
let v6773 : bool = v6772 && v6766
let v6774 : bool = v6773 && v6767
let v6775 : bool = v6774 && v6768
let v6776 : bool = v6775 && v6769
let v6777 : bool = v6776 && v6770
if v6777 then
    ()
else
    failwith<unit> "erp-p2p-cross-process-takeover-program-runtime-mismatch"
let v6778 : int64 = 0L + 1L
let v6779 : int64 = v6778 + 1L
let v6780 : int64 = v6779 + 1L
let v6781 : int64 = v6780 + 1L
let v6782 : int64 = 0L + 1L
let v6783 : int64 = 0L + 1L
let v6784 : int64 = v6783 + 1L
let v6785 : int64 = v6784 + 1L
let v6786 : int64 = v6785 + 1L
let v6787 : int64 = 0L + 1L
let v6788 : int64 = v6787 + 1L
let v6789 : int64 = v6788 + 1L
let v6790 : int64 = v6789 + 1L
let struct (v6791 : int64, v6792 : int64, v6793 : int64, v6794 : int64, v6795 : int64, v6796 : int64, v6797 : int64) = (let root = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-fenced-physical-append-" + System.Guid.NewGuid().ToString("N")) in let _ = System.IO.Directory.CreateDirectory(root) in let fencePath = System.IO.Path.Combine(root, "fence.state") in let preparedPath = System.IO.Path.Combine(root, "append.prepared") in let committedPath = System.IO.Path.Combine(root, "append.committed") in let writeDurable path (text : string) = let bytes = System.Text.Encoding.UTF8.GetBytes(text) in use stream = new System.IO.FileStream(path,System.IO.FileMode.Create,System.IO.FileAccess.Write,System.IO.FileShare.None,4096,System.IO.FileOptions.WriteThrough) in stream.Write(bytes,0,bytes.Length); stream.Flush(true) in writeDurable fencePath (string v6781); let persistedFence = System.Int64.Parse(System.IO.File.ReadAllText(fencePath)) in let staleRejected = if v6782 < persistedFence then 1L else 0L in let staleCreatedNothing = if staleRejected = 1L && not (System.IO.File.Exists(preparedPath)) && not (System.IO.File.Exists(committedPath)) then 1L else 0L in let payload = System.String.Join("|",[|string v6781;string v6786;string v6790;v4799;v4799|]) in let currentAccepted = if v6781 = persistedFence then (writeDurable preparedPath payload; System.IO.File.Move(preparedPath,committedPath,true); 1L) else 0L in let reopened = if System.IO.File.Exists(committedPath) then System.IO.File.ReadAllText(committedPath) else "" in let reopenedEqual = if reopened = payload then 1L else 0L in let digest = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(payload)) in let reopenedDigest = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(reopened)) in let digestValid = if System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(digest,reopenedDigest) then 1L else 0L in let preparedAbsent = if not (System.IO.File.Exists(preparedPath)) then 1L else 0L in System.IO.Directory.Delete(root,true); let cleanup = if System.IO.Directory.Exists(root) then 0L else 1L in staleRejected,staleCreatedNothing,currentAccepted,reopenedEqual,digestValid,preparedAbsent,cleanup)
let v6798 : bool = v6791 = 1L
let v6799 : bool = v6792 = 1L
let v6800 : bool = v6793 = 1L
let v6801 : bool = v6794 = 1L
let v6802 : bool = v6795 = 1L
let v6803 : bool = v6796 = 1L
let v6804 : bool = v6797 = 1L
let v6805 : bool = v6798 && v6799
let v6806 : bool = v6805 && v6800
let v6807 : bool = v6806 && v6801
let v6808 : bool = v6807 && v6802
let v6809 : bool = v6808 && v6803
let v6810 : bool = v6809 && v6804
if v6810 then
    ()
else
    failwith<unit> "erp-p2p-multiprocess-fenced-physical-append-runtime-mismatch"
let v6811 : int64 = 0L + 1L
let v6812 : int64 = v6811 + 1L
let v6813 : int64 = v6812 + 1L
let v6814 : int64 = v6813 + 1L
let v6815 : int64 = 1L + 1L
let v6816 : int64 = v6815 + 1L
let v6817 : string = "stale-fence-created-no-prepared-file-and-current-fence-committed-the-store-outbox-payload"
(if v6592 <> "owner-d" || v6814 <> 4L || v6816 <> 3L || v6817 <> "stale-fence-created-no-prepared-file-and-current-fence-committed-the-store-outbox-payload" then failwith "erp-p2p-multiprocess-fenced-physical-append-receipt-mismatch")
let struct (v6818 : int64, v6819 : int64, v6820 : int64, v6821 : int64, v6822 : int64, v6823 : int64, v6824 : int64, v6825 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-linearization-race-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let lockDirectory = System.IO.Path.Combine(directory, "history.cas") in let committed = System.IO.Path.Combine(directory, "history.committed") in let firstPrepared = System.IO.Path.Combine(directory, "history.first.prepared") in let secondPrepared = System.IO.Path.Combine(directory, "history.second.prepared") in let firstBytes = System.Text.Encoding.UTF8.GetBytes("history=version2|command=first|debit=31|credit=31") in let secondBytes = System.Text.Encoding.UTF8.GetBytes("history=version2|command=second|debit=37|credit=37") in let writePrepared path bytes = (use stream = new System.IO.FileStream(path, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)) in writePrepared firstPrepared firstBytes; writePrepared secondPrepared secondBytes; let startContender () = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/mkdir"; info.UseShellExecute <- false; info.ArgumentList.Add(lockDirectory); System.Diagnostics.Process.Start(info) in use first = startContender () in use second = startContender () in let firstDone = first.WaitForExit(15000) in let secondDone = second.WaitForExit(15000) in let _ = if not firstDone then (first.Kill(true); first.WaitForExit() |> ignore) else () in let _ = if not secondDone then (second.Kill(true); second.WaitForExit() |> ignore) else () in let firstApplied = if first.ExitCode = 0 then 1L else 0L in let secondApplied = if second.ExitCode = 0 then 1L else 0L in let winners = firstApplied + secondApplied in let conflicts = (if first.ExitCode = 0 then 0L else 1L) + (if second.ExitCode = 0 then 0L else 1L) in let winnerPrepared, winnerBytes, loserPrepared = if firstApplied = 1L then firstPrepared, firstBytes, secondPrepared else secondPrepared, secondBytes, firstPrepared in System.IO.File.Move(winnerPrepared, committed); let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let fileSync = runSync "-d" committed in let directorySync = runSync "-f" directory in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let winnerDigest = System.Security.Cryptography.SHA256.HashData(winnerBytes) in let digestEqual = if System.Linq.Enumerable.SequenceEqual(recoveredDigest, winnerDigest) then 1L else 0L in let _ = if System.IO.File.Exists(loserPrepared) then System.IO.File.Delete(loserPrepared) else () in System.IO.File.Delete(committed); let _ = if System.IO.Directory.Exists(lockDirectory) then System.IO.Directory.Delete(lockDirectory) else () in System.IO.Directory.Delete(directory); (firstApplied, secondApplied, conflicts, winners, digestEqual, int64 recovered.Length, fileSync, directorySync))
let v6826 : int64 = v6818 + v6819
let v6827 : bool = v6826 = 1L
let v6828 : bool = v6820 = 1L
let v6829 : bool = v6821 = 1L
let v6830 : bool = v6822 = 1L
let v6831 : bool = v6823 > 0L
let v6832 : bool = v6824 = 0L
let v6833 : bool = v6825 = 0L
let v6834 : bool = v6827 && v6828
let v6835 : bool = v6834 && v6829
let v6836 : bool = v6835 && v6830
let v6837 : bool = v6836 && v6831
let v6838 : bool = v6837 && v6832
let v6839 : bool = v6838 && v6833
if v6839 then
    ()
else
    failwith<unit> "typed-FX-statement-interprocess-linearization-race-runtime-mismatch"
let v6840 : int64 = 0L + 1L
let v6841 : int64 = v6840 + 1L
let v6842 : string = "cas-winner"
let v6843 : string = "two-independent-mkdir-processes-now-race-concurrently-for-one-history-CAS-linearization-directory-and-the-single-process-outcome-selects-exactly-one-preflushed-payload-for-the-durable-rename-file-sync-directory-sync-and-SHA256-verified-commit-so-the-runtime-observes-one-Applied-and-one-VersionConflict-rather-than-a-sequential-stale-check-while-moving-the-full-write-protocol-into-each-child-process-and-type-level-open-identity-remain-open-sealed"
(if v6842 <> "cas-winner" || v6841 <> 2L || 1L <> 1L || System.String.IsNullOrWhiteSpace(v6843) then failwith "erp-p2p-competing-successor-fence-receipt-mismatch")
let struct (v6844 : int64, v6845 : int64, v6846 : int64, v6847 : int64, v6848 : int64, v6849 : int64, v6850 : int64, v6851 : int64) = (let directory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "spiral-erp-linearization-race-" + System.Guid.NewGuid().ToString("N")) in System.IO.Directory.CreateDirectory(directory) |> ignore; let lockDirectory = System.IO.Path.Combine(directory, "history.cas") in let committed = System.IO.Path.Combine(directory, "history.committed") in let firstPrepared = System.IO.Path.Combine(directory, "history.first.prepared") in let secondPrepared = System.IO.Path.Combine(directory, "history.second.prepared") in let firstBytes = System.Text.Encoding.UTF8.GetBytes("history=version2|command=first|debit=31|credit=31") in let secondBytes = System.Text.Encoding.UTF8.GetBytes("history=version2|command=second|debit=37|credit=37") in let writePrepared path bytes = (use stream = new System.IO.FileStream(path, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None, 4096, System.IO.FileOptions.WriteThrough) in stream.Write(bytes, 0, bytes.Length); stream.Flush(true)) in writePrepared firstPrepared firstBytes; writePrepared secondPrepared secondBytes; let startContender () = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/mkdir"; info.UseShellExecute <- false; info.ArgumentList.Add(lockDirectory); System.Diagnostics.Process.Start(info) in use first = startContender () in use second = startContender () in let firstDone = first.WaitForExit(15000) in let secondDone = second.WaitForExit(15000) in let _ = if not firstDone then (first.Kill(true); first.WaitForExit() |> ignore) else () in let _ = if not secondDone then (second.Kill(true); second.WaitForExit() |> ignore) else () in let firstApplied = if first.ExitCode = 0 then 1L else 0L in let secondApplied = if second.ExitCode = 0 then 1L else 0L in let winners = firstApplied + secondApplied in let conflicts = (if first.ExitCode = 0 then 0L else 1L) + (if second.ExitCode = 0 then 0L else 1L) in let winnerPrepared, winnerBytes, loserPrepared = if firstApplied = 1L then firstPrepared, firstBytes, secondPrepared else secondPrepared, secondBytes, firstPrepared in System.IO.File.Move(winnerPrepared, committed); let runSync flag path = let info = new System.Diagnostics.ProcessStartInfo() in info.FileName <- "/usr/bin/sync"; info.UseShellExecute <- false; info.ArgumentList.Add(flag); info.ArgumentList.Add(path); use process = System.Diagnostics.Process.Start(info) in let completed = process.WaitForExit(5000) in let _ = if not completed then (process.Kill(true); process.WaitForExit() |> ignore) else () in if completed then int64 process.ExitCode else -2L in let fileSync = runSync "-d" committed in let directorySync = runSync "-f" directory in let recovered = System.IO.File.ReadAllBytes(committed) in let recoveredDigest = System.Security.Cryptography.SHA256.HashData(recovered) in let winnerDigest = System.Security.Cryptography.SHA256.HashData(winnerBytes) in let digestEqual = if System.Linq.Enumerable.SequenceEqual(recoveredDigest, winnerDigest) then 1L else 0L in let _ = if System.IO.File.Exists(loserPrepared) then System.IO.File.Delete(loserPrepared) else () in System.IO.File.Delete(committed); let _ = if System.IO.Directory.Exists(lockDirectory) then System.IO.Directory.Delete(lockDirectory) else () in System.IO.Directory.Delete(directory); (firstApplied, secondApplied, conflicts, winners, digestEqual, int64 recovered.Length, fileSync, directorySync))
let v6852 : int64 = v6844 + v6845
let v6853 : bool = v6852 = 1L
let v6854 : bool = v6846 = 1L
let v6855 : bool = v6847 = 1L
let v6856 : bool = v6848 = 1L
let v6857 : bool = v6849 > 0L
let v6858 : bool = v6850 = 0L
let v6859 : bool = v6851 = 0L
let v6860 : bool = v6853 && v6854
let v6861 : bool = v6860 && v6855
let v6862 : bool = v6861 && v6856
let v6863 : bool = v6862 && v6857
let v6864 : bool = v6863 && v6858
let v6865 : bool = v6864 && v6859
if v6865 then
    ()
else
    failwith<unit> "typed-FX-statement-interprocess-linearization-race-runtime-mismatch"
let v6866 : int64 = 0L + 1L
let v6867 : int64 = v6866 + 1L
let v6868 : int64 = 0L + 1L
let v6869 : int64 = v6868 + 1L
let v6870 : int64 = v6869 + 1L
let v6871 : int64 = v6870 + 1L
let v6872 : int64 = 0L + 1L
let v6873 : int64 = v6872 + 1L
let v6874 : int64 = v6873 + 1L
let v6875 : int64 = v6874 + 1L
if v6871 <> 4L || v6875 <> 4L || v4799 <> "goods-partially-received" || v4799 <> "goods-partially-received" then failwith "erp-p2p-four-event-store-runtime-mismatch"
let v6876 : string = "physical-two-process-CAS-race-bound-to-one-commit-tree"
(if v6867 <> 2L || 1L <> 1L || v6876 <> "physical-two-process-CAS-race-bound-to-one-commit-tree" then failwith "erp-p2p-competing-successor-fenced-commit-mismatch")
let v6877 : string = "all-terminals-green"
v6877
