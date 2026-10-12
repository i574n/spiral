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
local method1, method0
function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = spiral_wrap_signed((v1 + v0), 32)
    local v4 = v2 == 0
    if v4 then
        return v3
    else
        return method1(v2, v3)
    end
end

function method0(v0)
    local v1 = 0
    local v2 = v0 == 0
    local getv4 = function()
        if v2 then
            return v1
        else
            return method1(v0, v1)
        end
    end
    local v4 = getv4()
    local v5 = spiral_wrap_signed((v4 - 55), 32)
    return v5
end

local v0 = 10
return method0(v0)
