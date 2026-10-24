local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local function spiral_mul_mod32(a, b)
    a = a % 4294967296
    b = b % 4294967296
    local a_low = a % 65536
    local a_high = (a - a_low) / 65536
    return (a_low * b + ((a_high * b) % 65536) * 65536) % 4294967296
end
local v0 = 65536
local v1 = 65536
local v2 = 4294967295
local v3 = 3
local v4 = spiral_wrap_unsigned(spiral_mul_mod32(v0, v1), 32)
local v5 = spiral_wrap_unsigned(spiral_mul_mod32(v2, v3), 32)
local v6 = v4 == 0
local getv8 = function()
    if v6 then
        local v7 = v5 == 4294967293
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
