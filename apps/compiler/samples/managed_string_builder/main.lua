local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method2, method1, method0
function method2(v0, v1, v2)
    local v3 = spiral_wrap_signed((v0 - 1), 32)
    local v4 = (v1 .. v2)
    local v5 = v3 == 0
    if v5 then
        return v4
    else
        local v6 = math.fmod(v3, 2)
        local v7 = v6 == 0
        local getv10 = function()
            if v7 then
                local v8 = "ab"
                return v8
            else
                local v9 = "c"
                return v9
            end
        end
        local v10 = getv10()
        return method2(v3, v4, v10)
    end
end

function method1(v0, v1)
    local v2 = spiral_wrap_signed((v0 - 1), 32)
    local v3 = ("" .. v1)
    local v4 = v2 == 0
    if v4 then
        return v3
    else
        local v5 = math.fmod(v2, 2)
        local v6 = v5 == 0
        local getv9 = function()
            if v6 then
                local v7 = "ab"
                return v7
            else
                local v8 = "c"
                return v8
            end
        end
        local v9 = getv9()
        return method2(v2, v3, v9)
    end
end

function method0()
    local v0 = 4
    local v1 = v0 == 0
    if v1 then
        local v2 = ""
        return v2
    else
        local v3 = math.fmod(v0, 2)
        local v4 = v3 == 0
        local getv7 = function()
            if v4 then
                local v5 = "ab"
                return v5
            else
                local v6 = "c"
                return v6
            end
        end
        local v7 = getv7()
        return method1(v0, v7)
    end
end

local v0 = method0()
local v1 = string.len(v0)
local v2 = v1 == 6
if v2 then
    local v3 = string.sub(v0, (0)+1, (0)+1)
    local v4 = v3 == "a"
    if v4 then
        local v5 = string.sub(v0, (5)+1, (5)+1)
        local v6 = v5 == "c"
        if v6 then
            return 0
        else
            return 1
        end
    else
        return 2
    end
else
    return 3
end
