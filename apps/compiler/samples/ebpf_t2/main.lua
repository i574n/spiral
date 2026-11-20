local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method1, method0, method3, method2
function method1(v0, v1)
    return { [1]=v0, [2]=v1 }
end

function method0(v0, v1)
    local v2, v3 = (table.unpack or unpack)(method1(v0, v1))
    local v4 = spiral_wrap_signed((v2 + v3), 32)
    return v4
end

function method3(v0, v1, v2)
    return { [1]=v0, [2]=v1, [3]=v2 }
end

function method2(v0, v1, v2)
    local v3, v4, v5 = (table.unpack or unpack)(method3(v0, v1, v2))
    local v6 = spiral_wrap_signed((v3 + v4), 32)
    local v7 = spiral_wrap_signed((v6 + v5), 32)
    return v7
end

local v0 = 1
local v1 = 2
local v2 = 3
local v3 = method0(v0, v1)
local v4 = method2(v0, v1, v2)
local v5 = spiral_wrap_signed((v3 + v4), 32)
local v6 = spiral_wrap_signed((v5 - 9), 32)
return v6
