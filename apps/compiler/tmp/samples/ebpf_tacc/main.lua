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
local method2, method1, method0
function method2(v0, v1, v2)
    local v3 = spiral_wrap_signed((v0 - 1), 32)
    local v4 = spiral_wrap_signed((v1 + 1), 32)
    local v5 = spiral_wrap_signed((v2 + 2), 32)
    local v6 = v3 == 0
    if v6 then
        return { [1]=v4, [2]=v5 }
    else
        return method2(v3, v4, v5)
    end
end

function method1(v0)
    local v1 = 0
    local v2 = 0
    local v3 = v0 == 0
    if v3 then
        return { [1]=v1, [2]=v2 }
    else
        return method2(v0, v1, v2)
    end
end

function method0(v0)
    local v1, v2 = (table.unpack or unpack)(method1(v0))
    local v3 = v1 == 4
    local getv5 = function()
        if v3 then
            local v4 = v2 == 8
            return v4
        else
            return false
        end
    end
    local v5 = getv5()
    if v5 then
        return 0
    else
        return 1
    end
end

local v0 = 4
return method0(v0)
