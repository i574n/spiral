local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0, method1
function method0(v0, v1)
    return { [1]=v0, [2]=v1 }
end

function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 + v1), 32)
    return v2
end

local v0 = 20
local v1 = 22
local v2, v3 = (table.unpack or unpack)(method0(v0, v1))
local v4 = method1(v2, v3)
local v5 = spiral_wrap_signed((v4 - 42), 32)
return v5
