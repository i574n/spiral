local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method2, method1, method0
function method2(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = v2 == 0
    if v3 then
        local v4 = string.len(v1)
        return v4
    else
        return method1(v2, v1)
    end
end

function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = v2 == 0
    if v3 then
        return 99
    else
        return method2(v2, v1)
    end
end

function method0(v0, v1)
    local v2 = v0 == 0
    local getv5 = function()
        if v2 then
            local v3 = string.len(v1)
            return v3
        else
            return method1(v0, v1)
        end
    end
    local v5 = getv5()
    local v6 = spiral_wrap_signed((v5 - 2), 32)
    return v6
end

local v0 = 1000000
local v1 = math.fmod(v0, 2)
local v2 = v1 == 0
local getv5 = function()
    if v2 then
        local v3 = "ok"
        return v3
    else
        local v4 = "go"
        return v4
    end
end
local v5 = getv5()
return method0(v0, v5)
