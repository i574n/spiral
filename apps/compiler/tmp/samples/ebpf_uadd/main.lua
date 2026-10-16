local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local function spiral_mul_mod32(a, b)
    a = a % 4294967296
    b = b % 4294967296
    local a_low = a % 65536
    local a_high = (a - a_low) / 65536
    return (a_low * b + ((a_high * b) % 65536) * 65536) % 4294967296
end
local v0 = 2147483647
local v1 = 2
local v2 = 1
local v3 = spiral_wrap_unsigned((v0 + v1), 32)
local v4 = spiral_wrap_unsigned((v0 + v2), 32)
local v5 = v3 == 2147483649
local getv7 = function()
    if v5 then
        local v6 = v4 == 2147483648
        return v6
    else
        return false
    end
end
local v7 = getv7()
if v7 then
    return 0
else
    return 1
end
