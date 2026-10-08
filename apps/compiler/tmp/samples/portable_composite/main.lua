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
local method1, method2, method4, method5, method7, method9, method11, method10, method8, method6, method3, method0
function method1(v0)
    local v1 = spiral_wrap_signed((v0 + 2), 32)
    local v2 = v0 > 0
    return { [1]=v0, [2]=v1, [3]=v2 }
end

function method2(v0, v1, v2)
    if v2 then
        local v3 = spiral_wrap_signed((v0 + v1), 32)
        local v4 = spiral_wrap_signed((v3 - 4), 32)
        return v4
    else
        return 1
    end
end

function method4(v0)
    local v1 = v0 >= 3.5
    return { [1]=v1, [2]=v0, [3]=7 }
end

function method5(v0, v1, v2)
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

function method7(v0)
    return true
end

function method9(v0)
    local v1 = spiral_wrap_unsigned((v0 + 5), 32)
    local v2 = math.fmod(v1, 4)
    local v3 = v2 == 0
    return v3
end

function method11(v0, v1)
    local v2 = spiral_wrap_signed(spiral_mul_mod32(v0, v1), 32)
    local v3 = spiral_wrap_signed((v2 + 5), 32)
    local v4 = (math.modf(v3 / 3))
    return v4
end

function method10(v0)
    local v1 = 4
    local v2 = 4
    local v3 = method11(v1, v2)
    local v4 = spiral_wrap_signed((v0 + v3), 32)
    local v5 = spiral_wrap_signed((v4 - 7), 32)
    return v5
end

function method8(v0)
    local v1 = 7
    local v2 = method9(v1)
    if v2 then
        return method10(v0)
    else
        return 1
    end
end

function method6(v0)
    local v1 = "spiral"
    local v2 = method7(v1)
    if v2 then
        return method8(v0)
    else
        return 1
    end
end

function method3(v0)
    local v1 = 4.0
    local v2, v3, v4 = (table.unpack or unpack)(method4(v1))
    local v5 = method5(v2, v3, v4)
    local v6 = spiral_wrap_signed((v0 + v5), 32)
    return method6(v6)
end

function method0(v0)
    local v1 = 1
    local v2, v3, v4 = (table.unpack or unpack)(method1(v1))
    local v5 = method2(v2, v3, v4)
    local v6 = spiral_wrap_signed((v0 + v5), 32)
    return method3(v6)
end

local v0 = 0
return method0(v0)
