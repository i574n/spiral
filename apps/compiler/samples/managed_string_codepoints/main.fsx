let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let spiralStringSlice (s : string) (from : int) (upto : int) : string =
    let bytes = System.Text.Encoding.UTF8.GetBytes(s)
    let length = bytes.Length
    if from < 0 || from > length || upto < from - 1 || upto >= length then exit 3
    elif upto < from then ""
    elif (bytes.[from] &&& 0xC0uy) = 0x80uy || (upto + 1 < length && (bytes.[upto + 1] &&& 0xC0uy) = 0x80uy) then exit 3
    else System.Text.Encoding.UTF8.GetString(bytes, from, upto - from + 1)
let rec runtime_byte_0 (v0 : string, v1 : int32) : char =
    let v2 : char = (spiralStringIndex v0 (int v1))
    v2
and codepoint_length_loop_1 (v0 : string, v1 : char, v2 : char, v3 : int32, v4 : int32, v5 : int32) : int32 =
    let v6 : bool = v3 = v5
    if v6 then
        v4
    else
        let v7 : char = (spiralStringIndex v0 (int v3))
        let v8 : bool = v7 < v1
        let v10 : bool =
            if v8 then
                false
            else
                let v9 : bool = v7 < v2
                v9
        let v12 : int32 =
            if v10 then
                v4
            else
                let v11 : int32 = v4 + 1
                v11
        let v13 : int32 = v3 + 1
        codepoint_length_loop_1(v0, v1, v2, v13, v12, v5)
and codepoint_byte_offset_loop_2 (v0 : string, v1 : char, v2 : char, v3 : int32, v4 : int32, v5 : int32, v6 : int32) : int32 =
    let v7 : bool = v4 = v6
    if v7 then
        v6
    else
        let v8 : char = (spiralStringIndex v0 (int v4))
        let v9 : bool = v8 < v1
        let v11 : bool =
            if v9 then
                false
            else
                let v10 : bool = v8 < v2
                v10
        if v11 then
            let v12 : int32 = v4 + 1
            codepoint_byte_offset_loop_2(v0, v1, v2, v3, v12, v5, v6)
        else
            let v14 : bool = v5 = v3
            if v14 then
                v4
            else
                let v15 : int32 = v4 + 1
                let v16 : int32 = v5 + 1
                codepoint_byte_offset_loop_2(v0, v1, v2, v3, v15, v16, v6)
let v0 : string = "À"
let v1 : int32 = 1
let v2 : char = runtime_byte_0(v0, v1)
let v3 : string = "©"
let v4 : int32 = 0
let v5 : char = runtime_byte_0(v3, v4)
let v6 : string = "Aéλ🙂Z"
let v7 : int32 = 0
let v8 : int32 = 0
let v9 : int32 = 10
let v10 : int32 = codepoint_length_loop_1(v6, v2, v5, v7, v8, v9)
let v11 : int32 = 1
let v12 : char = runtime_byte_0(v0, v11)
let v13 : int32 = 0
let v14 : char = runtime_byte_0(v3, v13)
let v15 : int32 = 1
let v16 : int32 = 0
let v17 : int32 = 0
let v18 : int32 = 10
let v19 : int32 = codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18)
let v20 : int32 = 1
let v21 : char = runtime_byte_0(v0, v20)
let v22 : int32 = 0
let v23 : char = runtime_byte_0(v3, v22)
let v24 : int32 = 2
let v25 : int32 = 0
let v26 : int32 = 0
let v27 : int32 = 10
let v28 : int32 = codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27)
let v29 : int32 = v28 - 1
let v30 : string = (spiralStringSlice "Aéλ🙂Z" (int v19) (int v29))
let v31 : int32 = 1
let v32 : char = runtime_byte_0(v0, v31)
let v33 : int32 = 0
let v34 : char = runtime_byte_0(v3, v33)
let v35 : int32 = 3
let v36 : int32 = 0
let v37 : int32 = 0
let v38 : int32 = 10
let v39 : int32 = codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38)
let v40 : int32 = 1
let v41 : char = runtime_byte_0(v0, v40)
let v42 : int32 = 0
let v43 : char = runtime_byte_0(v3, v42)
let v44 : int32 = 4
let v45 : int32 = 0
let v46 : int32 = 0
let v47 : int32 = 10
let v48 : int32 = codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47)
let v49 : int32 = v48 - 1
let v50 : string = (spiralStringSlice "Aéλ🙂Z" (int v39) (int v49))
let v51 : int32 = 1
let v52 : char = runtime_byte_0(v0, v51)
let v53 : int32 = 0
let v54 : char = runtime_byte_0(v3, v53)
let v55 : int32 = 1
let v56 : int32 = 0
let v57 : int32 = 0
let v58 : int32 = 10
let v59 : int32 = codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58)
let v60 : int32 = 1
let v61 : char = runtime_byte_0(v0, v60)
let v62 : int32 = 0
let v63 : char = runtime_byte_0(v3, v62)
let v64 : int32 = 4
let v65 : int32 = 0
let v66 : int32 = 0
let v67 : int32 = 10
let v68 : int32 = codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67)
let v69 : int32 = v68 - 1
let v70 : string = (spiralStringSlice "Aéλ🙂Z" (int v59) (int v69))
let v71 : int32 = 1
let v72 : char = runtime_byte_0(v0, v71)
let v73 : int32 = 0
let v74 : char = runtime_byte_0(v3, v73)
let v75 : int32 = 3
let v76 : int32 = 0
let v77 : int32 = 0
let v78 : int32 = 10
let v79 : int32 = codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78)
let v80 : int32 = 0
let v81 : char = runtime_byte_0(v30, v80)
let v82 : string = "é"
let v83 : int32 = 0
let v84 : char = runtime_byte_0(v82, v83)
let v85 : int32 = 3
let v86 : char = runtime_byte_0(v50, v85)
let v87 : string = "🙂"
let v88 : int32 = 3
let v89 : char = runtime_byte_0(v87, v88)
let v90 : bool = v10 = 5
if v90 then
    let v91 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v30))
    let v92 : bool = v91 = 2
    if v92 then
        let v93 : bool = v81 = v84
        if v93 then
            let v94 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v50))
            let v95 : bool = v94 = 4
            if v95 then
                let v96 : bool = v86 = v89
                if v96 then
                    let v97 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v70))
                    let v98 : bool = v97 = 8
                    if v98 then
                        let v99 : bool = v79 = 5
                        if v99 then
                            0
                        else
                            1
                    else
                        2
                else
                    3
            else
                4
        else
            5
    else
        6
else
    7
