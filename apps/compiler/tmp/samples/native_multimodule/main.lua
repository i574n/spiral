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
local method0
function method0(v0, v1, v2)
    local v3 = spiral_wrap_signed(spiral_mul_mod32(v0, v1), 32)
    local v4 = spiral_wrap_signed((v3 + v2), 32)
    local v5 = spiral_wrap_signed((v4 - 42), 32)
    return v5
end

local v0 = 5
local v1 = 8
local v2 = 2
return method0(v0, v1, v2)
