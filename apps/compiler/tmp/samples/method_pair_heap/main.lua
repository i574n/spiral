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
    return { [1]=v0, [2]=v1 }
end

local v0 = 3
local v1 = 4
local v2 = { __tag = "Heap0", l0 = v0 }
local v3 = { __tag = "Heap0", l0 = v1 }
local v4, v5 = (table.unpack or unpack)(method0(v2, v3))
local v6 = v4 ~= nil and v4.l0
local v7 = v5 ~= nil and v5.l0
local v8 = spiral_wrap_signed((v6 + v7), 32)
local v9 = v8 == 7
if v9 then
    return 0
else
    return 1
end
