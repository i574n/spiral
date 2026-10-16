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
local Heap0, method0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function method0(v0, v1)
    return { [1]=v1, [2]=v0 }
end

local v0 = 3
local v1 = 4
local v2 = { __tag = "Heap0", l0 = v0 }
local v3, v4 = (table.unpack or unpack)(method0(v1, v2))
local v5 = v3 ~= nil and v3.l0
local v6 = spiral_wrap_signed((v5 + v4), 32)
local v7 = v6 == 7
if v7 then
    return 0
else
    return 1
end
