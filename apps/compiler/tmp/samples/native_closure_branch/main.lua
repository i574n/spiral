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
local closure0, closure1, method0
function closure0(capt)
    return function(v0)
        local v1 = spiral_wrap_signed((v0 + 2), 32)
        return v1
    end
end

function closure1(capt)
    return function(v0)
        local v1 = spiral_wrap_signed((v0 + 3), 32)
        return v1
    end
end

function method0(v0)
    return v0(40)
end

local v0 = true
local getv3 = function()
    if v0 then
        return closure0(nil)
    else
        return closure1(nil)
    end
end
local v3 = getv3()
return method0(v3)
