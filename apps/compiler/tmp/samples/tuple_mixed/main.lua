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
    local v1 = v0 >= 3.5
    return { [1]=v1, [2]=v0, [3]=7 }
end

function method1(v0, v1, v2)
    if v0 then
        local v3 = v1 >= 3.5
        if v3 then
            local v4 = spiral_wrap_signed((v2 - 7), 32)
            return v4
        else
            return 1
        end
    else
        return 2
    end
end

local v0 = 4.0
local v1, v2, v3 = (table.unpack or unpack)(method0(v0))
return method1(v1, v2, v3)
