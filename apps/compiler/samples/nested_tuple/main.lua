local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0, method1
function method0(v0)
    local v1 = spiral_wrap_signed((v0 + 1), 32)
    local v2 = spiral_wrap_signed((v0 + 2), 32)
    local v3 = spiral_wrap_signed((v0 + 3), 32)
    return { [1]=v0, [2]=v1, [3]=v2, [4]=v3 }
end

function method1(v0, v1, v2, v3)
    local v4 = spiral_wrap_signed((v0 + v1), 32)
    local v5 = spiral_wrap_signed((v4 + v2), 32)
    local v6 = spiral_wrap_signed((v5 + v3), 32)
    local v7 = spiral_wrap_signed((v6 - 10), 32)
    return v7
end

local v0 = 1
local v1, v2, v3, v4 = (table.unpack or unpack)(method0(v0))
return method1(v1, v2, v3, v4)
