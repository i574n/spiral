local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method2, method1, method0
function method2()
    return 14
end

function method1()
    local v0 = method2()
    local v1 = spiral_wrap_signed((14 + v0), 32)
    return v1
end

function method0()
    local v0 = method1()
    local v1 = spiral_wrap_signed((14 + v0), 32)
    return v1
end

return method0()
