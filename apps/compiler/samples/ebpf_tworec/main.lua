local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method1, method0, method3, method2
function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = spiral_wrap_signed((v1 + 3), 32)
    local v4 = v2 == 0
    if v4 then
        return v3
    else
        return method1(v2, v3)
    end
end

function method0(v0)
    local v1 = 0
    local v2 = v0 == 0
    if v2 then
        return v1
    else
        return method1(v0, v1)
    end
end

function method3(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = spiral_wrap_signed((v1 - 2), 32)
    local v4 = v2 == 0
    if v4 then
        return v3
    else
        return method3(v2, v3)
    end
end

function method2(v0)
    local v1 = 0
    local v2 = v0 == 0
    if v2 then
        return v1
    else
        return method3(v0, v1)
    end
end

local v0 = 4
local v1 = method0(v0)
local v2 = method2(v0)
local v3 = v1 == 12
local getv5 = function()
    if v3 then
        local v4 = v2 == -8
        return v4
    else
        return false
    end
end
local v5 = getv5()
if v5 then
    return 0
else
    return 1
end
