local Us0_None, Us0_All, score_0
function Us0_None() return { tag = "Us0_None" } end
function Us0_All(v0, v1, v2) return { tag = "Us0_All",  _1 = v0,  _2 = v1,  _3 = v2 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_All" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = __v[1]._3
        local v4 = v1 == 4000000000
        local getv6 = function()
            if v4 then
                local v5 = v2 == "hi"
                return v5
            else
                return false
            end
        end
        local v6 = getv6()
        local v7 = (v6) and (v3)
        if v7 then
            return 0
        else
            return 1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
        return 1
    end
end

local v0 = 4000000000
local v1 = "hi"
local v2 = true
local v3 = true
local getv6 = function()
    if v3 then
        return Us0_All(v0, v1, v2)
    else
        return Us0_None()
    end
end
local v6 = getv6()
return score_0(v6)
