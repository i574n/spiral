local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local v0 = 2147483647
local v1 = 2
local v2 = 1
local v3 = spiral_wrap_unsigned((v0 + v1), 32)
local v4 = spiral_wrap_unsigned((v0 + v2), 32)
local v5 = v3 == 2147483649
local getv7 = function()
    if v5 then
        local v6 = v4 == 2147483648
        return v6
    else
        return false
    end
end
local v7 = getv7()
if v7 then
    return 0
else
    return 1
end
