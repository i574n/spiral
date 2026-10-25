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
local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(4)
v0[(0)+1] = 2
v0[(1)+1] = 3
v0[(2)+1] = 5
v0[(3)+1] = 7
local v1 = 1
v0[(v1)+1] = 11
local v2 = (v0)[(0)+1]
local v3 = (v0)[(1)+1]
local v4 = (v0)[(2)+1]
local v5 = (v0)[(3)+1]
local v6 = spiral_wrap_signed((v2 + v3), 32)
local v7 = spiral_wrap_signed((v6 + v4), 32)
local v8 = spiral_wrap_signed((v7 + v5), 32)
local v9 = spiral_wrap_signed((v8 - 25), 32)
return v9
