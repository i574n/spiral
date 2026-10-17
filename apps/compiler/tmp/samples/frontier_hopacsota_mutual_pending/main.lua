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
local is_odd_1, is_even_0
function is_odd_1(v0)
    local v1 = v0 == 0
    if v1 then
        return false
    else
        local v2 = spiral_wrap_signed((v0 - 1), 32)
        return is_even_0(v2)
    end
end

function is_even_0(v0)
    local v1 = v0 == 0
    if v1 then
        return true
    else
        local v2 = spiral_wrap_signed((v0 - 1), 32)
        return is_odd_1(v2)
    end
end

local v0 = 10
local v1 = is_even_0(v0)
if v1 then
    return 0
else
    return 1
end
