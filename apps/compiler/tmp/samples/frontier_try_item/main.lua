local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v1 = 42
local v3 = spiral_wrap_signed((v1 - 42), 32)
return v3
