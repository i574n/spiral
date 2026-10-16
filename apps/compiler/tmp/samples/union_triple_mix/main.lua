local Us0_One, Us0_All, score_0
function Us0_One(v0) return { tag = "Us0_One",  _1 = v0 } end
function Us0_All(v0, v1, v2) return { tag = "Us0_All",  _1 = v0,  _2 = v1,  _3 = v2 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_All" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = __v[1]._3
        local v5 = v2 == 7
        local getv7 = function()
            if v5 then
                local v6 = v3 == "hi"
                return v6
            else
                return false
            end
        end
        local v7 = getv7()
        local v8 = (v7) and (v4)
        if v8 then
            return 0
        else
            return 1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_One" then
        local v1 = __v[1]._1
        return v1
    end
end

local v0 = true
local v1 = 7
local v2 = "hi"
local v3 = true
local getv6 = function()
    if v0 then
        return Us0_All(v1, v2, v3)
    else
        return Us0_One(1)
    end
end
local v6 = getv6()
return score_0(v6)
