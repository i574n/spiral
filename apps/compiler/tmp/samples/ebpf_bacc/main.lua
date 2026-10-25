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
local method1, method0, method2
function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local getv4 = function()
        if v1 then
            local v3 = v0 > 0
            return v3
        else
            return false
        end
    end
    local v4 = getv4()
    local v5 = v2 == 0
    if v5 then
        return v4
    else
        return method1(v2, v4)
    end
end

function method0(v0)
    local v1 = true
    local v2 = v0 == 0
    if v2 then
        return v1
    else
        return method1(v0, v1)
    end
end

function method2(v0)
    local v1 = false
    local v2 = v0 == 0
    if v2 then
        return v1
    else
        return method1(v0, v1)
    end
end

local v0 = 3
local v1 = method0(v0)
local v2 = method2(v0)
if v1 then
    if v2 then
        return 1
    else
        return 0
    end
else
    return 2
end
