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
local Heap0, f_c0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = spiral_wrap_signed((v1 + v0), 32)
        return v2
    end
end

local v0 = 3
local v1 = f_c0({ v0 })
local v2 = { __tag = "Heap0", l0 = v1 }
local v3 = v2 ~= nil and v2.l0
local v4 = v3(4)
local v5 = v4 == 7
if v5 then
    return 0
else
    return 1
end
