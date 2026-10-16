local Us0_None, Us0_Held, score_0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0, v1) return { tag = "Us0_Held",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = (v1)[(0)+1]
        local v4 = v3 == "hi"
        local v5 = (v4) and (v2)
        if v5 then
            return 0
        else
            return 1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
        return 1
    end
end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = "" end return t end)(1)
local v1 = "hi"
v0[(0)+1] = v1
local v2 = true
local getv5 = function()
    if v2 then
        return Us0_Held(v0, v2)
    else
        return Us0_None()
    end
end
local v5 = getv5()
return score_0(v5)
