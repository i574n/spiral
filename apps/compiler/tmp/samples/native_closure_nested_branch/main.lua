local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local left_c0, right_c1, method0
function left_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 > 0
        if v3 then
            local v4 = string.len(v0)
            local v5 = spiral_wrap_signed((v4 + v1), 32)
            local v6 = spiral_wrap_signed((v5 + v2), 32)
            return v6
        else
            return 0
        end
    end
end

function right_c1(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 > 0
        if v3 then
            local v4 = string.len(v0)
            local v5 = spiral_wrap_signed((v4 + v1), 32)
            local v6 = spiral_wrap_signed((v5 + v2), 32)
            local v7 = spiral_wrap_signed((v6 - 1), 32)
            return v7
        else
            return -1
        end
    end
end

function method0(v0)
    return v0(37)
end

local v0 = "abc"
local v1 = "wxyz"
local v2 = 2
local v3 = 2
local v4 = true
local getv7 = function()
    if v4 then
        return left_c0({ v0, v2 })
    else
        return right_c1({ v1, v3 })
    end
end
local v7 = getv7()
return method0(v7)
