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
local method1, method0
function method1(v0, v1, v2)
    local v3 = spiral_wrap_signed((v0 - 1), 32)
    local v4 = v3 == 0
    if v4 then
        return v2
    else
        return method1(v3, v2, v1)
    end
end

function method0(v0, v1)
    local v2 = 1000000
    local v3 = v2 == 0
    if v3 then
        return v0
    else
        return method1(v2, v0, v1)
    end
end

local v0 = 1
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 7
v2[(0)+1] = 11
local v3 = method0(v1, v2)
v3[(0)+1] = 13
local v4 = (v1)[(0)+1]
local v5 = v4 == 13
if v5 then
    local v6 = (v2)[(0)+1]
    local v7 = v6 == 11
    if v7 then
        return 0
    else
        return 2
    end
else
    return 1
end
