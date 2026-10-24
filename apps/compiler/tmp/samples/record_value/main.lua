local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0, method1
function method0(v0)
    local v1 = spiral_wrap_signed((v0 + 2), 32)
    local v2 = v0 > 0
    return { [1]=v0, [2]=v1, [3]=v2 }
end

function method1(v0, v1, v2)
    if v2 then
        local v3 = spiral_wrap_signed((v0 + v1), 32)
        local v4 = spiral_wrap_signed((v3 - 4), 32)
        return v4
    else
        return 1
    end
end

local v0 = 1
local v1, v2, v3 = (table.unpack or unpack)(method0(v0))
return method1(v1, v2, v3)
