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
local count_down_0
function count_down_0(v0, v1)
    local v2 = 0 < v0
    if v2 then
        local v3 = spiral_wrap_signed((v0 - 1), 32)
        local v4 = spiral_wrap_signed((v1 + 1), 32)
        return count_down_0(v3, v4)
    else
        return v1
    end
end

local v0 = 5000
local v1 = 0
local v2 = count_down_0(v0, v1)
local v3 = v2 == 5000
if v3 then
    return 0
else
    return 1
end
