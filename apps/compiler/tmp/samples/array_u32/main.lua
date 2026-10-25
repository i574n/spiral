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
local v0 = 3
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 4000000000
v1[(1)+1] = 1
local v2 = (v1)[(0)+1]
local v3 = (v1)[(1)+1]
local v4 = spiral_wrap_unsigned((v2 + v3), 32)
local v5 = #(v1)
local v6 = v5 == v0
local getv8 = function()
    if v6 then
        local v7 = v4 == 4000000001
        return v7
    else
        return false
    end
end
local v8 = getv8()
if v8 then
    return 0
else
    return 1
end
