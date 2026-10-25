local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = 7
local v1 = 5
local v2 = v1 * 2
local v3 = v0
local v4 = spiral_wrap_signed((v2 + v3), 32)
return v4
