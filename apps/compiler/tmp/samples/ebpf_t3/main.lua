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
function method2(v0, v1, v2, v3)
    local v4 = spiral_wrap_signed((v0 - 1), 32)
    local v5 = spiral_wrap_signed((v1 + 1), 32)
    local v6 = spiral_wrap_signed((v2 + 2), 32)
    local v7 = spiral_wrap_signed((v3 + 3), 32)
    local v8 = v4 == 0
    if v8 then
        return { [1]=v5, [2]=v6, [3]=v7 }
    else
        return method2(v4, v5, v6, v7)
    end
end

function method1(v0)
    local v1 = 0
    local v2 = 0
    local v3 = 0
    local v4 = v0 == 0
    if v4 then
        return { [1]=v1, [2]=v2, [3]=v3 }
    else
        return method2(v0, v1, v2, v3)
    end
end

function method0(v0)
    local v1, v2, v3 = (table.unpack or unpack)(method1(v0))
    local v4 = v1 == 3
    local getv6 = function()
        if v4 then
            local v5 = v2 == 6
            return v5
        else
            return false
        end
    end
    local v6 = getv6()
    local getv8 = function()
        if v6 then
            local v7 = v3 == 9
            return v7
        else
            return false
        end
    end
    local v8 = getv8()
    if v8 then
        return 0
    else
        return 1
    end
end

local v0 = 3
return method0(v0)
