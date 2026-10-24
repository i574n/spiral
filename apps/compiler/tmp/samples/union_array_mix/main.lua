local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_None, Us0_Held, score_0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0, v1) return { tag = "Us0_Held",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Held" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = (v1)[(0)+1]
        local v4 = spiral_wrap_signed((v3 + v2), 32)
        local v5 = v4 == 7
        if v5 then
            return 0
        else
            return 1
        end
    elseif v0 ~= nil and v0.tag == "Us0_None" then
        return 1
    end
end

local v0 = 3
local v1 = 4
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
v2[(0)+1] = v0
local v3 = true
local getv6 = function()
    if v3 then
        return Us0_Held(v2, v1)
    else
        return Us0_None()
    end
end
local v6 = getv6()
return score_0(v6)
