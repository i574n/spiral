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
    if v0 then
        local v1 = "alpha"
        return v1
    else
        local v2 = "beta"
        return v2
    end
end

function method1(v0)
    local v1 = string.len(v0)
    return v1
end

local v0 = true
local v1 = method0(v0)
local v2 = false
local v3 = method0(v2)
local v4 = method1(v1)
local v5 = method1(v1)
local v6 = spiral_wrap_signed((v4 + v5), 32)
local v7 = method1(v3)
local v8 = spiral_wrap_signed((v6 + v7), 32)
local v9 = spiral_wrap_signed((v8 - 14), 32)
return v9
