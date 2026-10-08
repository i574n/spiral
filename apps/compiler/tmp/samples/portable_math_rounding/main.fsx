let v0 : float = 2.7
let v1 : float = 3.2
let v2 : float = -2.5
let v3 : float = 3.5
let v4 : float = 0.5
let v5 : float = 1.0
let v6 : float32 = 2.7f
let v11 : (float -> float) = floor
let v12 : float = v11 v0
let v22 : bool = v12 = 2.0
let v23 : bool = v22 <> true
if v23 then
    1
else
    let v28 : (float -> float) = ceil
    let v29 : float = v28 v0
    let v40 : bool = v29 = 3.0
    let v41 : bool = v40 <> true
    if v41 then
        2
    else
        let v74 : (float -> float) = round
        let v75 : float = v74 v0
        let v170 : bool = v75 = 3.0
        let v171 : bool = v170 <> true
        if v171 then
            3
        else
            let v172 : (float -> float) = round
            let v173 : float = v172 v1
            let v174 : bool = v173 = 3.0
            let v175 : bool = v174 <> true
            if v175 then
                4
            else
                let v176 : (float -> float) = round
                let v177 : float = v176 v2
                let v178 : bool = v177 = -2.0
                let v179 : bool = v178 <> true
                if v179 then
                    5
                else
                    let v180 : (float -> float) = round
                    let v181 : float = v180 v3
                    let v182 : bool = v181 = 4.0
                    let v183 : bool = v182 <> true
                    if v183 then
                        6
                    else
                        let v184 : (float -> float) = round
                        let v185 : float = v184 v4
                        let v186 : bool = v185 = 0.0
                        let v187 : bool = v186 <> true
                        if v187 then
                            7
                        else
                            let v190 : float = System.Math.Atan2 (v5, v5)
                            let v200 : float = v190 * 1000.0
                            let v201 : (float -> float) = floor
                            let v202 : float = v201 v200
                            let v203 : bool = v202 = 785.0
                            let v204 : bool = v203 <> true
                            if v204 then
                                8
                            else
                                let v209 : (float32 -> float32) = floor
                                let v210 : float32 = v209 v6
                                let v220 : bool = v210 = 2.0f
                                let v221 : bool = v220 <> true
                                if v221 then
                                    9
                                else
                                    0
