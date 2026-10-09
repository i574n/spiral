local v0 = 2.7
local v1 = 3.2
local v2 = -2.5
local v3 = 3.5
local v4 = 0.5
local v5 = 1.0
local v6 = 2.7
local v9 = math.floor
local v10 = v9(v0)
local v23 = v10 == 2.0
local v24 = v23 ~= true
if v24 then
    return 1
else
    local v27 = math.ceil
    local v28 = v27(v0)
    local v42 = v28 == 3.0
    local v43 = v42 ~= true
    if v43 then
        return 2
    else
        local v61 = math.floor
        local v62 = v61(v0)
        local v63 = (v0 - v62)
        local v64 = v63 > 0.5
        local getv75 = function()
            if v64 then
                local v65 = (v62 + 1.0)
                return v65
            else
                local v66 = v63 < 0.5
                if v66 then
                    return v62
                else
                    local v67 = v62 / 2.0
                    local v68 = math.floor
                    local v69 = v68(v67)
                    local v70 = (v69 * 2.0)
                    local v71 = v70 == v62
                    if v71 then
                        return v62
                    else
                        local v72 = (v62 + 1.0)
                        return v72
                    end
                end
            end
        end
        local v75 = getv75()
        local v173 = v75 == 3.0
        local v174 = v173 ~= true
        if v174 then
            return 3
        else
            local v175 = math.floor
            local v176 = v175(v1)
            local v177 = (v1 - v176)
            local v178 = v177 > 0.5
            local getv189 = function()
                if v178 then
                    local v179 = (v176 + 1.0)
                    return v179
                else
                    local v180 = v177 < 0.5
                    if v180 then
                        return v176
                    else
                        local v181 = v176 / 2.0
                        local v182 = math.floor
                        local v183 = v182(v181)
                        local v184 = (v183 * 2.0)
                        local v185 = v184 == v176
                        if v185 then
                            return v176
                        else
                            local v186 = (v176 + 1.0)
                            return v186
                        end
                    end
                end
            end
            local v189 = getv189()
            local v190 = v189 == 3.0
            local v191 = v190 ~= true
            if v191 then
                return 4
            else
                local v192 = math.floor
                local v193 = v192(v2)
                local v194 = (v2 - v193)
                local v195 = v194 > 0.5
                local getv206 = function()
                    if v195 then
                        local v196 = (v193 + 1.0)
                        return v196
                    else
                        local v197 = v194 < 0.5
                        if v197 then
                            return v193
                        else
                            local v198 = v193 / 2.0
                            local v199 = math.floor
                            local v200 = v199(v198)
                            local v201 = (v200 * 2.0)
                            local v202 = v201 == v193
                            if v202 then
                                return v193
                            else
                                local v203 = (v193 + 1.0)
                                return v203
                            end
                        end
                    end
                end
                local v206 = getv206()
                local v207 = v206 == -2.0
                local v208 = v207 ~= true
                if v208 then
                    return 5
                else
                    local v209 = math.floor
                    local v210 = v209(v3)
                    local v211 = (v3 - v210)
                    local v212 = v211 > 0.5
                    local getv223 = function()
                        if v212 then
                            local v213 = (v210 + 1.0)
                            return v213
                        else
                            local v214 = v211 < 0.5
                            if v214 then
                                return v210
                            else
                                local v215 = v210 / 2.0
                                local v216 = math.floor
                                local v217 = v216(v215)
                                local v218 = (v217 * 2.0)
                                local v219 = v218 == v210
                                if v219 then
                                    return v210
                                else
                                    local v220 = (v210 + 1.0)
                                    return v220
                                end
                            end
                        end
                    end
                    local v223 = getv223()
                    local v224 = v223 == 4.0
                    local v225 = v224 ~= true
                    if v225 then
                        return 6
                    else
                        local v226 = math.floor
                        local v227 = v226(v4)
                        local v228 = (v4 - v227)
                        local v229 = v228 > 0.5
                        local getv240 = function()
                            if v229 then
                                local v230 = (v227 + 1.0)
                                return v230
                            else
                                local v231 = v228 < 0.5
                                if v231 then
                                    return v227
                                else
                                    local v232 = v227 / 2.0
                                    local v233 = math.floor
                                    local v234 = v233(v232)
                                    local v235 = (v234 * 2.0)
                                    local v236 = v235 == v227
                                    if v236 then
                                        return v227
                                    else
                                        local v237 = (v227 + 1.0)
                                        return v237
                                    end
                                end
                            end
                        end
                        local v240 = getv240()
                        local v241 = v240 == 0.0
                        local v242 = v241 ~= true
                        if v242 then
                            return 7
                        else
                            local v244 = math.atan2(v5, v5)
                            local v256 = (v244 * 1000.0)
                            local v257 = math.floor
                            local v258 = v257(v256)
                            local v259 = v258 == 785.0
                            local v260 = v259 ~= true
                            if v260 then
                                return 8
                            else
                                local v263 = math.floor
                                local v264 = v263(v6)
                                local v277 = v264 == 2.0
                                local v278 = v277 ~= true
                                if v278 then
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
