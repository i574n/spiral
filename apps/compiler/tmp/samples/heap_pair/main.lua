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
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = 3
local v1 = 4
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3, v4 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
local v5 = spiral_wrap_signed((v3 + v4), 32)
local v6 = v5 == 7
if v6 then
    return 0
else
    return 1
end
