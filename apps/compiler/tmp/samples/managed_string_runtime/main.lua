local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = "qwe"
local v1 = string.len(v0)
local v2 = spiral_wrap_signed((v1 + v1), 32)
local v3 = spiral_wrap_signed((v2 - 6), 32)
return v3
