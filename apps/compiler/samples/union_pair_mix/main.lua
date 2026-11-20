local Us0_One, Us0_Both, score_0
function Us0_One(v0) return { tag = "Us0_One",  _1 = v0 } end
function Us0_Both(v0, v1) return { tag = "Us0_Both",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Both" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = v2 == 3
        local getv6 = function()
            if v4 then
                local v5 = v3 == "hi"
                return v5
            else
                return false
            end
        end
        local v6 = getv6()
        if v6 then
            return 0
        else
            return 1
        end
    elseif v0 ~= nil and v0.tag == "Us0_One" then
        local v1 = v0._1
        return v1
    end
end

local v0 = true
local v1 = 3
local v2 = "hi"
local getv5 = function()
    if v0 then
        return Us0_Both(v1, v2)
    else
        return Us0_One(1)
    end
end
local v5 = getv5()
return score_0(v5)
