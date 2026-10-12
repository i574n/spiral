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
local method0, method1
function method0(v0, v1)
    return { [1]=v0, [2]=v1 }
end

function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 + v1), 32)
    return v2
end

local v0 = 20
local v1 = 22
local v2, v3 = (table.unpack or unpack)(method0(v0, v1))
local v4 = method1(v2, v3)
local v5 = spiral_wrap_signed((v4 - 42), 32)
return v5
