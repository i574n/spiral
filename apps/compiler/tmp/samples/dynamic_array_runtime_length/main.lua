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
function method0(v0)
    local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
    v1[(0)+1] = 2
    v1[(1)+1] = 3
    v1[(2)+1] = 5
    v1[(3)+1] = 7
    local v2 = 2
    local v3 = (v1)[(v2)+1]
    local v4 = #(v1)
    local v5 = spiral_wrap_signed((v3 + v4), 32)
    local v6 = spiral_wrap_signed((v5 - 9), 32)
    return v6
end

local v0 = 4
return method0(v0)
