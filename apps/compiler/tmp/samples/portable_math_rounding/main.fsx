let v0 : float = 2.7
let v1 : float = 3.2
let v2 : float = -2.5
let v3 : float = 3.5
let v4 : float = 0.5
let v5 : float = 1.0
let v6 : float32 = 2.7f
let v11 : (float -> float) = floor
let v12 : float = v11 v0
let v23 : bool = v12 = 2.0
let v24 : bool = v23 <> true
if v24 then
    1
else
    let v29 : (float -> float) = ceil
    let v30 : float = v29 v0
    let v42 : bool = v30 = 3.0
    let v43 : bool = v42 <> true
    if v43 then
        2
    else
        let v76 : (float -> float) = round
        let v77 : float = v76 v0
        let v173 : bool = v77 = 3.0
        let v174 : bool = v173 <> true
        if v174 then
            3
        else
            let v175 : (float -> float) = round
            let v176 : float = v175 v1
            let v177 : bool = v176 = 3.0
            let v178 : bool = v177 <> true
            if v178 then
                4
            else
                let v179 : (float -> float) = round
                let v180 : float = v179 v2
                let v181 : bool = v180 = -2.0
                let v182 : bool = v181 <> true
                if v182 then
                    5
                else
                    let v183 : (float -> float) = round
                    let v184 : float = v183 v3
                    let v185 : bool = v184 = 4.0
                    let v186 : bool = v185 <> true
                    if v186 then
                        6
                    else
                        let v187 : (float -> float) = round
                        let v188 : float = v187 v4
                        let v189 : bool = v188 = 0.0
                        let v190 : bool = v189 <> true
                        if v190 then
                            7
                        else
                            let v193 : float = System.Math.Atan2 (v5, v5)
                            let v204 : float = v193 * 1000.0
                            let v205 : (float -> float) = floor
                            let v206 : float = v205 v204
                            let v207 : bool = v206 = 785.0
                            let v208 : bool = v207 <> true
                            if v208 then
                                8
                            else
                                let v213 : (float32 -> float32) = floor
                                let v214 : float32 = v213 v6
                                let v225 : bool = v214 = 2.0f
                                let v226 : bool = v225 <> true
                                if v226 then
                                    9
                                else
                                    0
