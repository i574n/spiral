local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method1, method0
function method1(v0)
    local v1 = spiral_wrap_signed((v0 - 1), 32)
    local v2 = v1 == 0
    if v2 then
        return 0
    else
        return method1(v1)
    end
end

function method0(v0)
    local v1 = v0 == 0
    if v1 then
        return 0
    else
        return method1(v0)
    end
end

local v0 = 1000000
return method0(v0)
