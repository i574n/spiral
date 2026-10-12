let v0 : float = 2.7
let v1 : float = 3.2
let v2 : float = -2.5
let v3 : float = 3.5
let v4 : float = 0.5
let v5 : float = 1.0
let v6 : float32 = 2.7f
let v7 : (float -> float) = floor
let v8 : float = v7 v0
let v9 : bool = v8 = 2.0
let v10 : bool = v9 <> true
if v10 then
    1
else
    let v11 : (float -> float) = ceil
    let v12 : float = v11 v0
    let v13 : bool = v12 = 3.0
    let v14 : bool = v13 <> true
    if v14 then
        2
    else
        let v15 : (float -> float) = round
        let v16 : float = v15 v0
        let v17 : bool = v16 = 3.0
        let v18 : bool = v17 <> true
        if v18 then
            3
        else
            let v19 : (float -> float) = round
            let v20 : float = v19 v1
            let v21 : bool = v20 = 3.0
            let v22 : bool = v21 <> true
            if v22 then
                4
            else
                let v23 : (float -> float) = round
                let v24 : float = v23 v2
                let v25 : bool = v24 = -2.0
                let v26 : bool = v25 <> true
                if v26 then
                    5
                else
                    let v27 : (float -> float) = round
                    let v28 : float = v27 v3
                    let v29 : bool = v28 = 4.0
                    let v30 : bool = v29 <> true
                    if v30 then
                        6
                    else
                        let v31 : (float -> float) = round
                        let v32 : float = v31 v4
                        let v33 : bool = v32 = 0.0
                        let v34 : bool = v33 <> true
                        if v34 then
                            7
                        else
                            let v35 : float = System.Math.Atan2 (v5, v5)
                            let v36 : float = v35 * 1000.0
                            let v37 : (float -> float) = floor
                            let v38 : float = v37 v36
                            let v39 : bool = v38 = 785.0
                            let v40 : bool = v39 <> true
                            if v40 then
                                8
                            else
                                let v41 : (float32 -> float32) = floor
                                let v42 : float32 = v41 v6
                                let v43 : bool = v42 = 2.0f
                                let v44 : bool = v43 <> true
                                if v44 then
                                    9
                                else
                                    0
