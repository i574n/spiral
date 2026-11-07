local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Hit, Us0_Miss, score_0
function Us0_Hit(v0) return { tag = "Us0_Hit",  _1 = v0 } end
function Us0_Miss(v0) return { tag = "Us0_Miss",  _1 = v0 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Hit" then
        local v1 = v0._1
        return v1
    elseif v0 ~= nil and v0.tag == "Us0_Miss" then
        local v2 = v0._1
        local v3 = spiral_wrap_signed(-(v2), 32)
        return v3
    end
end

local v0 = true
local getv3 = function()
    if v0 then
        return Us0_Hit(7)
    else
        return Us0_Miss(3)
    end
end
local v3 = getv3()
local v4 = score_0(v3)
local v5 = spiral_wrap_signed((v4 - 7), 32)
return v5
