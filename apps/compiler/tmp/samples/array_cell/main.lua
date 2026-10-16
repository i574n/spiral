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
local Heap0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

local v0 = 2
local v1 = {}
local v2 = 4
local v3 = 6
local v4 = { __tag = "Heap0", l0 = v2 }
v1[(0)+1] = v4
local v5 = { __tag = "Heap0", l0 = v3 }
v1[(1)+1] = v5
local v6 = (v1)[(0)+1]
local v7 = v6 ~= nil and v6.l0
local v8 = (v1)[(1)+1]
local v9 = v8 ~= nil and v8.l0
local v10 = spiral_wrap_signed((v7 + v9), 32)
local v11 = v10 == 10
if v11 then
    return 0
else
    return 1
end
