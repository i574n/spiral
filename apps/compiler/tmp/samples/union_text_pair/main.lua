local Us0_None, Us0_Both, score_0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Both(v0, v1) return { tag = "Us0_Both",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Both" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = v1 == "hi"
        local getv5 = function()
            if v3 then
                local v4 = v2 == "yo"
                return v4
            else
                return false
            end
        end
        local v5 = getv5()
        if v5 then
            return 0
        else
            return 1
        end
    elseif v0 ~= nil and v0.tag == "Us0_None" then
        return 1
    end
end

local v0 = "hi"
local v1 = "yo"
local v2 = true
local getv5 = function()
    if v2 then
        return Us0_Both(v0, v1)
    else
        return Us0_None()
    end
end
local v5 = getv5()
return score_0(v5)
