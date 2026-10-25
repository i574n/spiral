local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0
function method0(v0, v1)
    local v2 = spiral_wrap_signed((v0 + v1), 32)
    local v3 = spiral_wrap_signed((v2 - 42), 32)
    return v3
end

local v0 = 20
local v1 = 22
return method0(v0, v1)
