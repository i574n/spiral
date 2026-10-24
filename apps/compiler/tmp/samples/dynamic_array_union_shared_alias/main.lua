local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Empty, Us0_Values, bump_0, score_1
function Us0_Empty() return { tag = "Us0_Empty" } end
function Us0_Values(v0) return { tag = "Us0_Values",  _1 = v0 } end

function bump_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Empty" then
        return 0
    elseif v0 ~= nil and v0.tag == "Us0_Values" then
        local v1 = v0._1
        local v2 = (v1)[(0)+1]
        local v3 = spiral_wrap_signed((v2 + 1), 32)
        v1[(0)+1] = v3
        return 0
    end
end

function score_1(v0)
    if v0 ~= nil and v0.tag == "Us0_Empty" then
        return 0
    elseif v0 ~= nil and v0.tag == "Us0_Values" then
        local v1 = v0._1
        local v2 = #(v1)
        local v3 = (v1)[(0)+1]
        local v4 = spiral_wrap_signed((v2 + v3), 32)
        local v5 = (v1)[(1)+1]
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        return v6
    end
end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 4
v1[(1)+1] = 5
local v2 = Us0_Values(v1)
local v3 = bump_0(v2)
local v4 = Us0_Values(v1)
local v5 = score_1(v4)
local v6 = spiral_wrap_signed((v5 + v3), 32)
local v7 = spiral_wrap_signed((v6 - 12), 32)
return v7
