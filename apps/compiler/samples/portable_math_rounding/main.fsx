let v0 : float = 2.7
let v1 : float = 3.2
let v2 : float = -2.5
let v3 : float = 3.5
let v4 : float = 0.5
let v5 : float = 1.0
let v6 : float32 = 2.7f
let v7 : (float -> float) = floor
let v8 : float = v7 v0
let v9 : bool = v8 <> 2.0
if v9 then
    1
else
    let v10 : (float -> float) = ceil
    let v11 : float = v10 v0
    let v12 : bool = v11 <> 3.0
    if v12 then
        2
    else
        let v13 : (float -> float) = round
        let v14 : float = v13 v0
        let v15 : bool = v14 <> 3.0
        if v15 then
            3
        else
            let v16 : (float -> float) = round
            let v17 : float = v16 v1
            let v18 : bool = v17 <> 3.0
            if v18 then
                4
            else
                let v19 : (float -> float) = round
                let v20 : float = v19 v2
                let v21 : bool = v20 <> -2.0
                if v21 then
                    5
                else
                    let v22 : (float -> float) = round
                    let v23 : float = v22 v3
                    let v24 : bool = v23 <> 4.0
                    if v24 then
                        6
                    else
                        let v25 : (float -> float) = round
                        let v26 : float = v25 v4
                        let v27 : bool = v26 <> 0.0
                        if v27 then
                            7
                        else
                            let v28 : float = System.Math.Atan2 (v5, v5)
                            let v29 : float = v28 * 1000.0
                            let v30 : (float -> float) = floor
                            let v31 : float = v30 v29
                            let v32 : bool = v31 <> 785.0
                            if v32 then
                                8
                            else
                                let v33 : (float32 -> float32) = floor
                                let v34 : float32 = v33 v6
                                let v35 : bool = v34 <> 2.0f
                                if v35 then
                                    9
                                else
                                    0
