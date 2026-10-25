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
local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(3)
v0[(0)+1] = 2
v0[(1)+1] = 3
v0[(2)+1] = 5
local v1 = (v0)[(0)+1]
local v2 = (v0)[(1)+1]
local v3 = (v0)[(2)+1]
local v4 = spiral_wrap_signed((v1 + v2), 32)
local v5 = spiral_wrap_signed((v4 + v3), 32)
local v6 = spiral_wrap_signed((v5 - 10), 32)
return v6
