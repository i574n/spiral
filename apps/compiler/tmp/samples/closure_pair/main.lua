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
local f_c0
function f_c0(capt)
    return function(v0)
        local v1 = spiral_wrap_signed((v0 + 1), 32)
        return { [1]=v0, [2]=v1 }
    end
end

local v0 = 3
local v1 = f_c0(nil)
local v2, v3 = (table.unpack or unpack)(v1(v0))
local v4 = v2 == 3
local getv6 = function()
    if v4 then
        local v5 = v3 == 4
        return v5
    else
        return false
    end
end
local v6 = getv6()
if v6 then
    return 0
else
    return 1
end
