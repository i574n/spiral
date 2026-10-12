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
function method0(v0)
    local v1 = spiral_wrap_signed((v0 + 1), 32)
    local v2 = spiral_wrap_signed((v0 + 2), 32)
    local v3 = spiral_wrap_signed((v0 + 3), 32)
    return { [1]=v0, [2]=v1, [3]=v2, [4]=v3 }
end

function method1(v0, v1, v2, v3)
    local v4 = spiral_wrap_signed((v0 + v1), 32)
    local v5 = spiral_wrap_signed((v4 + v2), 32)
    local v6 = spiral_wrap_signed((v5 + v3), 32)
    local v7 = spiral_wrap_signed((v6 - 10), 32)
    return v7
end

local v0 = 1
local v1, v2, v3, v4 = (table.unpack or unpack)(method0(v0))
return method1(v1, v2, v3, v4)
