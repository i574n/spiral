local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Heap0, Us0_None, Us0_Held, score_0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0, v1) return { tag = "Us0_Held",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Held" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = v1 ~= nil and v1.l0
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
local v2 = { __tag = "Heap0", l0 = v0 }
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
