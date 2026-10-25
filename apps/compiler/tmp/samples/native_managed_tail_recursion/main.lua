local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method1, method0
function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = v2 == 0
    if v3 then
        return v1
    else
        local v4 = math.fmod(v2, 2)
        local v5 = v4 == 0
        local getv8 = function()
            if v5 then
                local v6 = "ok"
                return v6
            else
                local v7 = "go"
                return v7
            end
        end
        local v8 = getv8()
        return method1(v2, v8)
    end
end

function method0()
    local v0 = 1000000
    local v1 = v0 == 0
    if v1 then
        local v2 = "seed"
        return v2
    else
        local v3 = math.fmod(v0, 2)
        local v4 = v3 == 0
        local getv7 = function()
            if v4 then
                local v5 = "ok"
                return v5
            else
                local v6 = "go"
                return v6
            end
        end
        local v7 = getv7()
        return method1(v0, v7)
    end
end

local v0 = method0()
local v1 = string.len(v0)
local v2 = v1 == 2
if v2 then
    return 0
else
    return 1
end
