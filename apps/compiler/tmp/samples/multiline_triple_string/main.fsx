let v0 : string = "a \"b\" c"
let v1 : string = ""
let v2 : string = "a\\nb"
let v3 : string = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented"
let v4 : string = "\ntop\n\nlevel"
let v5 : int32 = v0.Length
let v6 : bool = v5 = 7
let v7 : bool = v6 <> true
if v7 then
    1
else
    let v8 : char = v0.[int 2]
    let v9 : bool = v8 = '"'
    let v10 : bool = v9 <> true
    if v10 then
        2
    else
        let v11 : int32 = v1.Length
        let v12 : bool = v11 = 0
        let v13 : bool = v12 <> true
        if v13 then
            3
        else
            let v14 : int32 = v2.Length
            let v15 : bool = v14 = 4
            let v16 : bool = v15 <> true
            if v16 then
                4
            else
                let v17 : char = v2.[int 1]
                let v18 : bool = v17 = '\\'
                let v19 : bool = v18 <> true
                if v19 then
                    5
                else
                    let v20 : int32 = v3.Length
                    let v21 : bool = v20 = 83
                    let v22 : bool = v21 <> true
                    if v22 then
                        6
                    else
                        let v23 : char = v3.[int 5]
                        let v24 : bool = v23 = '\n'
                        let v25 : bool = v24 <> true
                        if v25 then
                            7
                        else
                            let v26 : char = v3.[int 37]
                            let v27 : bool = v26 = '\n'
                            let v28 : bool = v27 <> true
                            if v28 then
                                8
                            else
                                let v29 : char = v3.[int 38]
                                let v30 : bool = v29 = '\n'
                                let v31 : bool = v30 <> true
                                if v31 then
                                    9
                                else
                                    let v32 : char = v3.[int 39]
                                    let v33 : bool = v32 = '$'
                                    let v34 : bool = v33 <> true
                                    if v34 then
                                        10
                                    else
                                        let v35 : char = v3.[int 57]
                                        let v36 : bool = v35 = 'i'
                                        let v37 : bool = v36 <> true
                                        if v37 then
                                            11
                                        else
                                            let v38 : char = v3.[int 82]
                                            let v39 : bool = v38 = 'd'
                                            let v40 : bool = v39 <> true
                                            if v40 then
                                                12
                                            else
                                                let v41 : int32 = v4.Length
                                                let v42 : bool = v41 = 11
                                                let v43 : bool = v42 <> true
                                                if v43 then
                                                    13
                                                else
                                                    let v44 : char = v4.[int 0]
                                                    let v45 : bool = v44 = '\n'
                                                    let v46 : bool = v45 <> true
                                                    if v46 then
                                                        14
                                                    else
                                                        let v47 : char = v4.[int 5]
                                                        let v48 : bool = v47 = '\n'
                                                        let v49 : bool = v48 <> true
                                                        if v49 then
                                                            15
                                                        else
                                                            0
