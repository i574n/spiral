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
local a_c0, b_c1, method0
function a_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = spiral_wrap_signed((v1 + v0), 32)
        return v2
    end
end

function b_c1(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = spiral_wrap_signed((v1 + v0), 32)
        return v2
    end
end

function method0(v0)
    return v0(40)
end

local v0 = 2
local v1 = 3
local v2 = true
local getv5 = function()
    if v2 then
        return a_c0({ v0 })
    else
        return b_c1({ v1 })
    end
end
local v5 = getv5()
return method0(v5)
