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
local f_c0
function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
        local v4 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
        local v5 = v2 == 0
        if v5 then
            v3[(0)+1] = 0
            v4[(0)+1] = 0
            return { [1]=v3, [2]=v4 }
        else
            v3[(0)+1] = v0
            v4[(0)+1] = v1
            return { [1]=v3, [2]=v4 }
        end
    end
end

local v0 = 3
local v1 = 4
local v2 = f_c0({ v0, v1 })
local v3, v4 = (table.unpack or unpack)(v2(1))
local v5 = (v3)[(0)+1]
local v6 = (v4)[(0)+1]
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = v7 == 7
if v8 then
    return 0
else
    return 1
end
