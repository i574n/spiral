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
local fib_0
function fib_0(v0)
    local v1 = v0 <= 1
    if v1 then
        return v0
    else
        local v2 = spiral_wrap_signed((v0 - 1), 32)
        local v3 = fib_0(v2)
        local v4 = spiral_wrap_signed((v0 - 2), 32)
        local v5 = fib_0(v4)
        local v6 = spiral_wrap_signed((v3 + v5), 32)
        return v6
    end
end

local v0 = 10
local v1 = fib_0(v0)
local v2 = spiral_wrap_signed((v1 - 55), 32)
return v2
