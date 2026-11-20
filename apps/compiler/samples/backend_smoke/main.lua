local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = 6
local v1 = 7
local v2 = spiral_wrap_signed((v0 + v1), 32)
return v2
