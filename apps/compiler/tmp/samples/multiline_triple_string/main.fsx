let spiralStringIndex (s : string) (i : int) : char = char (System.Text.Encoding.UTF8.GetBytes(s).[i])
let v0 : int32 = 16
let v1 : string = "x\ny"
let v2 : string = "say \"hi\""
let v3 : string = "a \"\"\" b"
let v4 : string = "first\n    second\n\nthird"
let v5 : string = "ab\ncd"
let v6 : string = "a \"b\" c"
let v7 : string = ""
let v8 : string = "a\\nb"
let v9 : string = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
let v10 : string = "\ntop\n\nlevel"
let v11 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v6))
let v12 : bool = v11 = 7
let v13 : bool = v12 <> true
if v13 then
    1
else
    let v14 : char = (spiralStringIndex v6 (int 2))
    let v15 : bool = v14 = '"'
    let v16 : bool = v15 <> true
    if v16 then
        2
    else
        let v17 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v7))
        let v18 : bool = v17 = 0
        let v19 : bool = v18 <> true
        if v19 then
            3
        else
            let v20 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v8))
            let v21 : bool = v20 = 4
            let v22 : bool = v21 <> true
            if v22 then
                4
            else
                let v23 : char = (spiralStringIndex v8 (int 1))
                let v24 : bool = v23 = '\\'
                let v25 : bool = v24 <> true
                if v25 then
                    5
                else
                    let v26 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v9))
                    let v27 : bool = v26 = 83
                    let v28 : bool = v27 <> true
                    if v28 then
                        6
                    else
                        let v29 : char = (spiralStringIndex v9 (int 5))
                        let v30 : bool = v29 = '\n'
                        let v31 : bool = v30 <> true
                        if v31 then
                            7
                        else
                            let v32 : char = (spiralStringIndex v9 (int 37))
                            let v33 : bool = v32 = '\n'
                            let v34 : bool = v33 <> true
                            if v34 then
                                8
                            else
                                let v35 : char = (spiralStringIndex v9 (int 38))
                                let v36 : bool = v35 = '\n'
                                let v37 : bool = v36 <> true
                                if v37 then
                                    9
                                else
                                    let v38 : char = (spiralStringIndex v9 (int 39))
                                    let v39 : bool = v38 = '$'
                                    let v40 : bool = v39 <> true
                                    if v40 then
                                        10
                                    else
                                        let v41 : char = (spiralStringIndex v9 (int 57))
                                        let v42 : bool = v41 = 'i'
                                        let v43 : bool = v42 <> true
                                        if v43 then
                                            11
                                        else
                                            let v44 : char = (spiralStringIndex v9 (int 82))
                                            let v45 : bool = v44 = 'd'
                                            let v46 : bool = v45 <> true
                                            if v46 then
                                                12
                                            else
                                                let v47 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v10))
                                                let v48 : bool = v47 = 11
                                                let v49 : bool = v48 <> true
                                                if v49 then
                                                    13
                                                else
                                                    let v50 : char = (spiralStringIndex v10 (int 0))
                                                    let v51 : bool = v50 = '\n'
                                                    let v52 : bool = v51 <> true
                                                    if v52 then
                                                        14
                                                    else
                                                        let v53 : char = (spiralStringIndex v10 (int 5))
                                                        let v54 : bool = v53 = '\n'
                                                        let v55 : bool = v54 <> true
                                                        if v55 then
                                                            15
                                                        else
                                                            let v56 : bool = v0 = 16
                                                            let v57 : bool = v56 <> true
                                                            if v57 then
                                                                16
                                                            else
                                                                let v58 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
                                                                let v59 : bool = v58 = 3
                                                                let v60 : bool = v59 <> true
                                                                if v60 then
                                                                    17
                                                                else
                                                                    let v61 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v2))
                                                                    let v62 : bool = v61 = 8
                                                                    let v63 : bool = v62 <> true
                                                                    if v63 then
                                                                        18
                                                                    else
                                                                        let v64 : char = (spiralStringIndex v2 (int 7))
                                                                        let v65 : bool = v64 = '"'
                                                                        let v66 : bool = v65 <> true
                                                                        if v66 then
                                                                            19
                                                                        else
                                                                            let v67 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
                                                                            let v68 : bool = v67 = 7
                                                                            let v69 : bool = v68 <> true
                                                                            if v69 then
                                                                                20
                                                                            else
                                                                                let v70 : char = (spiralStringIndex v3 (int 4))
                                                                                let v71 : bool = v70 = '"'
                                                                                let v72 : bool = v71 <> true
                                                                                if v72 then
                                                                                    21
                                                                                else
                                                                                    let v73 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v4))
                                                                                    let v74 : bool = v73 = 23
                                                                                    let v75 : bool = v74 <> true
                                                                                    if v75 then
                                                                                        22
                                                                                    else
                                                                                        let v76 : char = (spiralStringIndex v4 (int 6))
                                                                                        let v77 : bool = v76 = ' '
                                                                                        let v78 : bool = v77 <> true
                                                                                        if v78 then
                                                                                            23
                                                                                        else
                                                                                            let v79 : char = (spiralStringIndex v4 (int 10))
                                                                                            let v80 : bool = v79 = 's'
                                                                                            let v81 : bool = v80 <> true
                                                                                            if v81 then
                                                                                                24
                                                                                            else
                                                                                                let v82 : char = (spiralStringIndex v4 (int 17))
                                                                                                let v83 : bool = v82 = '\n'
                                                                                                let v84 : bool = v83 <> true
                                                                                                if v84 then
                                                                                                    25
                                                                                                else
                                                                                                    let v85 : char = (spiralStringIndex v4 (int 22))
                                                                                                    let v86 : bool = v85 = 'd'
                                                                                                    let v87 : bool = v86 <> true
                                                                                                    if v87 then
                                                                                                        26
                                                                                                    else
                                                                                                        let v88 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v5))
                                                                                                        let v89 : bool = v88 = 5
                                                                                                        let v90 : bool = v89 <> true
                                                                                                        if v90 then
                                                                                                            27
                                                                                                        else
                                                                                                            let v91 : char = (spiralStringIndex v5 (int 3))
                                                                                                            let v92 : bool = v91 = 'c'
                                                                                                            let v93 : bool = v92 <> true
                                                                                                            if v93 then
                                                                                                                28
                                                                                                            else
                                                                                                                0
