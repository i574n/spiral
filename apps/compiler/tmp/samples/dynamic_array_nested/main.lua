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
local v0 = 2
local v1 = {}
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v3 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v2[(0)+1] = 3
v2[(1)+1] = 4
v3[(0)+1] = 5
v3[(1)+1] = 6
v1[(0)+1] = v2
v1[(1)+1] = v3
local v4 = (v1)[(0)+1]
local v5 = (v1)[(1)+1]
local v6 = (v4)[(0)+1]
local v7 = (v4)[(1)+1]
local v8 = spiral_wrap_signed((v6 + v7), 32)
local v9 = (v5)[(0)+1]
local v10 = spiral_wrap_signed((v8 + v9), 32)
local v11 = (v5)[(1)+1]
local v12 = spiral_wrap_signed((v10 + v11), 32)
local v13 = spiral_wrap_signed((v12 - 18), 32)
return v13
