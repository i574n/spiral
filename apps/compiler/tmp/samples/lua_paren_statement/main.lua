local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = 5
do (function() end)() end
local v1 = spiral_wrap_signed((v0 + 2), 32)
return v1
