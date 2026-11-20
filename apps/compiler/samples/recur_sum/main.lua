local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local sum_0
function sum_0(v0)
    local v1 = v0 < 1
    if v1 then
        return 0
    else
        local v2 = spiral_wrap_signed((v0 - 1), 32)
        local v3 = sum_0(v2)
        local v4 = spiral_wrap_signed((v0 + v3), 32)
        return v4
    end
end

local v0 = 4
local v1 = sum_0(v0)
local v2 = v1 == 10
if v2 then
    return 0
else
    return 1
end
