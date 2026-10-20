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
let v12 : bool = v11 <> 7
if v12 then
    1
else
    let v13 : char = (spiralStringIndex v6 (int 2))
    let v14 : bool = v13 <> '"'
    if v14 then
        2
    else
        let v15 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v7))
        let v16 : bool = v15 <> 0
        if v16 then
            3
        else
            let v17 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v8))
            let v18 : bool = v17 <> 4
            if v18 then
                4
            else
                let v19 : char = (spiralStringIndex v8 (int 1))
                let v20 : bool = v19 <> '\\'
                if v20 then
                    5
                else
                    let v21 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v9))
                    let v22 : bool = v21 <> 83
                    if v22 then
                        6
                    else
                        let v23 : char = (spiralStringIndex v9 (int 5))
                        let v24 : bool = v23 <> '\n'
                        if v24 then
                            7
                        else
                            let v25 : char = (spiralStringIndex v9 (int 37))
                            let v26 : bool = v25 <> '\n'
                            if v26 then
                                8
                            else
                                let v27 : char = (spiralStringIndex v9 (int 38))
                                let v28 : bool = v27 <> '\n'
                                if v28 then
                                    9
                                else
                                    let v29 : char = (spiralStringIndex v9 (int 39))
                                    let v30 : bool = v29 <> '$'
                                    if v30 then
                                        10
                                    else
                                        let v31 : char = (spiralStringIndex v9 (int 57))
                                        let v32 : bool = v31 <> 'i'
                                        if v32 then
                                            11
                                        else
                                            let v33 : char = (spiralStringIndex v9 (int 82))
                                            let v34 : bool = v33 <> 'd'
                                            if v34 then
                                                12
                                            else
                                                let v35 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v10))
                                                let v36 : bool = v35 <> 11
                                                if v36 then
                                                    13
                                                else
                                                    let v37 : char = (spiralStringIndex v10 (int 0))
                                                    let v38 : bool = v37 <> '\n'
                                                    if v38 then
                                                        14
                                                    else
                                                        let v39 : char = (spiralStringIndex v10 (int 5))
                                                        let v40 : bool = v39 <> '\n'
                                                        if v40 then
                                                            15
                                                        else
                                                            let v41 : bool = v0 <> 16
                                                            if v41 then
                                                                16
                                                            else
                                                                let v42 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v1))
                                                                let v43 : bool = v42 <> 3
                                                                if v43 then
                                                                    17
                                                                else
                                                                    let v44 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v2))
                                                                    let v45 : bool = v44 <> 8
                                                                    if v45 then
                                                                        18
                                                                    else
                                                                        let v46 : char = (spiralStringIndex v2 (int 7))
                                                                        let v47 : bool = v46 <> '"'
                                                                        if v47 then
                                                                            19
                                                                        else
                                                                            let v48 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v3))
                                                                            let v49 : bool = v48 <> 7
                                                                            if v49 then
                                                                                20
                                                                            else
                                                                                let v50 : char = (spiralStringIndex v3 (int 4))
                                                                                let v51 : bool = v50 <> '"'
                                                                                if v51 then
                                                                                    21
                                                                                else
                                                                                    let v52 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v4))
                                                                                    let v53 : bool = v52 <> 23
                                                                                    if v53 then
                                                                                        22
                                                                                    else
                                                                                        let v54 : char = (spiralStringIndex v4 (int 6))
                                                                                        let v55 : bool = v54 <> ' '
                                                                                        if v55 then
                                                                                            23
                                                                                        else
                                                                                            let v56 : char = (spiralStringIndex v4 (int 10))
                                                                                            let v57 : bool = v56 <> 's'
                                                                                            if v57 then
                                                                                                24
                                                                                            else
                                                                                                let v58 : char = (spiralStringIndex v4 (int 17))
                                                                                                let v59 : bool = v58 <> '\n'
                                                                                                if v59 then
                                                                                                    25
                                                                                                else
                                                                                                    let v60 : char = (spiralStringIndex v4 (int 22))
                                                                                                    let v61 : bool = v60 <> 'd'
                                                                                                    if v61 then
                                                                                                        26
                                                                                                    else
                                                                                                        let v62 : int32 = (System.Text.Encoding.UTF8.GetByteCount(v5))
                                                                                                        let v63 : bool = v62 <> 5
                                                                                                        if v63 then
                                                                                                            27
                                                                                                        else
                                                                                                            let v64 : char = (spiralStringIndex v5 (int 3))
                                                                                                            let v65 : bool = v64 <> 'c'
                                                                                                            if v65 then
                                                                                                                28
                                                                                                            else
                                                                                                                0
