local v0 = 2.7
local v1 = 3.2
local v2 = -2.5
local v3 = 3.5
local v4 = 0.5
local v5 = 1.0
local v6 = 2.7
local v9 = math.floor
local v10 = v9(v0)
local v22 = v10 == 2.0
local v23 = v22 ~= true
if v23 then
    return 1
else
    local v26 = math.ceil
    local v27 = v26(v0)
    local v40 = v27 == 3.0
    local v41 = v40 ~= true
    if v41 then
        return 2
    else
        local v59 = math.floor
        local v60 = v59(v0)
        local v61 = (v0 - v60)
        local v62 = v61 > 0.5
        local getv73 = function()
            if v62 then
                local v63 = (v60 + 1.0)
                return v63
            else
                local v64 = v61 < 0.5
                if v64 then
                    return v60
                else
                    local v65 = v60 / 2.0
                    local v66 = math.floor
                    local v67 = v66(v65)
                    local v68 = (v67 * 2.0)
                    local v69 = v68 == v60
                    if v69 then
                        return v60
                    else
                        local v70 = (v60 + 1.0)
                        return v70
                    end
                end
            end
        end
        local v73 = getv73()
        local v170 = v73 == 3.0
        local v171 = v170 ~= true
        if v171 then
            return 3
        else
            local v172 = math.floor
            local v173 = v172(v1)
            local v174 = (v1 - v173)
            local v175 = v174 > 0.5
            local getv186 = function()
                if v175 then
                    local v176 = (v173 + 1.0)
                    return v176
                else
                    local v177 = v174 < 0.5
                    if v177 then
                        return v173
                    else
                        local v178 = v173 / 2.0
                        local v179 = math.floor
                        local v180 = v179(v178)
                        local v181 = (v180 * 2.0)
                        local v182 = v181 == v173
                        if v182 then
                            return v173
                        else
                            local v183 = (v173 + 1.0)
                            return v183
                        end
                    end
                end
            end
            local v186 = getv186()
            local v187 = v186 == 3.0
            local v188 = v187 ~= true
            if v188 then
                return 4
            else
                local v189 = math.floor
                local v190 = v189(v2)
                local v191 = (v2 - v190)
                local v192 = v191 > 0.5
                local getv203 = function()
                    if v192 then
                        local v193 = (v190 + 1.0)
                        return v193
                    else
                        local v194 = v191 < 0.5
                        if v194 then
                            return v190
                        else
                            local v195 = v190 / 2.0
                            local v196 = math.floor
                            local v197 = v196(v195)
                            local v198 = (v197 * 2.0)
                            local v199 = v198 == v190
                            if v199 then
                                return v190
                            else
                                local v200 = (v190 + 1.0)
                                return v200
                            end
                        end
                    end
                end
                local v203 = getv203()
                local v204 = v203 == -2.0
                local v205 = v204 ~= true
                if v205 then
                    return 5
                else
                    local v206 = math.floor
                    local v207 = v206(v3)
                    local v208 = (v3 - v207)
                    local v209 = v208 > 0.5
                    local getv220 = function()
                        if v209 then
                            local v210 = (v207 + 1.0)
                            return v210
                        else
                            local v211 = v208 < 0.5
                            if v211 then
                                return v207
                            else
                                local v212 = v207 / 2.0
                                local v213 = math.floor
                                local v214 = v213(v212)
                                local v215 = (v214 * 2.0)
                                local v216 = v215 == v207
                                if v216 then
                                    return v207
                                else
                                    local v217 = (v207 + 1.0)
                                    return v217
                                end
                            end
                        end
                    end
                    local v220 = getv220()
                    local v221 = v220 == 4.0
                    local v222 = v221 ~= true
                    if v222 then
                        return 6
                    else
                        local v223 = math.floor
                        local v224 = v223(v4)
                        local v225 = (v4 - v224)
                        local v226 = v225 > 0.5
                        local getv237 = function()
                            if v226 then
                                local v227 = (v224 + 1.0)
                                return v227
                            else
                                local v228 = v225 < 0.5
                                if v228 then
                                    return v224
                                else
                                    local v229 = v224 / 2.0
                                    local v230 = math.floor
                                    local v231 = v230(v229)
                                    local v232 = (v231 * 2.0)
                                    local v233 = v232 == v224
                                    if v233 then
                                        return v224
                                    else
                                        local v234 = (v224 + 1.0)
                                        return v234
                                    end
                                end
                            end
                        end
                        local v237 = getv237()
                        local v238 = v237 == 0.0
                        local v239 = v238 ~= true
                        if v239 then
                            return 7
                        else
                            local v241 = math.atan2(v5, v5)
                            local v252 = (v241 * 1000.0)
                            local v253 = math.floor
                            local v254 = v253(v252)
                            local v255 = v254 == 785.0
                            local v256 = v255 ~= true
                            if v256 then
                                return 8
                            else
                                local v259 = math.floor
                                local v260 = v259(v6)
                                local v272 = v260 == 2.0
                                local v273 = v272 ~= true
                                if v273 then
                                    return 9
                                else
                                    return 0
                                end
                            end
                        end
                    end
                end
            end
        end
    end
end
