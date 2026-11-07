local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local left_c0, right_c1, method0
function left_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v0 == 0
        if v2 then
            return 0
        else
            local v3 = spiral_wrap_signed((v1 + v0), 32)
            return v3
        end
    end
end

function right_c1(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = v0 == 0
        if v2 then
            return 0
        else
            local v3 = spiral_wrap_signed((v1 + v0), 32)
            return v3
        end
    end
end

function method0(v0, v1)
    local v2 = left_c0({ v0 })
    local v3 = right_c1({ v1 })
    return { [1]=v2, [2]=v3 }
end

local v0 = 3
local v1 = 4
local v2, v3 = (table.unpack or unpack)(method0(v0, v1))
local v4 = v2(0)
local v5 = v3(0)
local v6 = spiral_wrap_signed((v4 + v5), 32)
local v7 = v6 == 7
if v7 then
    return 0
else
    return 1
end
