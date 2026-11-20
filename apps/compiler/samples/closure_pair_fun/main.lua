local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local right_c1, left_c2, f_c0
function right_c1(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v1 == 0
        if v3 then
            return 0
        else
            local v4 = spiral_wrap_signed((v2 + v0), 32)
            return v4
        end
    end
end

function left_c2(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v1 == 0
        if v3 then
            return 0
        else
            local v4 = spiral_wrap_signed((v2 + v0), 32)
            return v4
        end
    end
end

function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = v2 == 0
        if v3 then
            local v4 = right_c1({ v1, v2 })
            local v5 = left_c2({ v0, v2 })
            return { [1]=v4, [2]=v5 }
        else
            local v6 = left_c2({ v0, v2 })
            local v7 = right_c1({ v1, v2 })
            return { [1]=v6, [2]=v7 }
        end
    end
end

local v0 = 3
local v1 = 4
local v2 = f_c0({ v0, v1 })
local v3, v4 = (table.unpack or unpack)(v2(1))
local v5 = v3(0)
local v6 = v4(0)
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = v7 == 7
if v8 then
    return 0
else
    return 1
end
