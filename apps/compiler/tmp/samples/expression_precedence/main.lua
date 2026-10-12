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
local method0
function method0(v0, v1)
    local v2 = -v0 
    local v3 = v2 <= 0
    if v3 then
        local v4 = spiral_wrap_signed(spiral_mul_mod32(v1, 2), 32)
        local v5 = spiral_wrap_signed((v0 + v4), 32)
        local v6 = v5 >= 9
        if v6 then
            return true
        else
            local v7 = v1 == 0
            return v7
        end
    else
        return false
    end
end

local v0 = 3
local v1 = 3
local v2 = method0(v0, v1)
if v2 then
    return 0
else
    return 1
end
