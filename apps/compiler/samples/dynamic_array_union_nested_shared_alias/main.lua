local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_Empty, Us0_Nested, bump_0, score_1
function Us0_Empty() return { tag = "Us0_Empty" } end
function Us0_Nested(v0) return { tag = "Us0_Nested",  _1 = v0 } end

function bump_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Empty" then
        return 0
    elseif v0 ~= nil and v0.tag == "Us0_Nested" then
        local v1 = v0._1
        local v2 = (v1)[(0)+1]
        local v3 = (v2)[(0)+1]
        local v4 = spiral_wrap_signed((v3 + 1), 32)
        v2[(0)+1] = v4
        return 0
    end
end

function score_1(v0)
    if v0 ~= nil and v0.tag == "Us0_Empty" then
        return 0
    elseif v0 ~= nil and v0.tag == "Us0_Nested" then
        local v1 = v0._1
        local v2 = (v1)[(0)+1]
        local v3 = (v1)[(1)+1]
        local v4 = (v2)[(0)+1]
        local v5 = (v2)[(1)+1]
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = (v3)[(0)+1]
        local v8 = spiral_wrap_signed((v6 + v7), 32)
        local v9 = (v3)[(1)+1]
        local v10 = spiral_wrap_signed((v8 + v9), 32)
        return v10
    end
end

local v0 = 2
local v1 = {}
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v3 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v2[(0)+1] = 3
v2[(1)+1] = 4
v3[(0)+1] = 5
v3[(1)+1] = 6
v1[(0)+1] = v2
v1[(1)+1] = v3
local v4 = Us0_Nested(v1)
local v5 = bump_0(v4)
local v6 = Us0_Nested(v1)
local v7 = score_1(v6)
local v8 = spiral_wrap_signed((v7 + v5), 32)
local v9 = spiral_wrap_signed((v8 - 19), 32)
return v9
