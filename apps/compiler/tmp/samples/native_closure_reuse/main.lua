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
local closure0
function closure0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = spiral_wrap_signed((v0 + v1), 32)
        local v4 = spiral_wrap_signed((v3 + v2), 32)
        return v4
    end
end

local v0 = 1
local v1 = 2
local v2 = closure0({ v0, v1 })
local v3 = v2(10)
local v4 = v2(20)
local v5 = v2(3)
local v6 = spiral_wrap_signed((v3 + v4), 32)
local v7 = spiral_wrap_signed((v6 + v5), 32)
return v7
