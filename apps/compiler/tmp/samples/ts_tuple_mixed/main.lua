local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0, method1
function method0(v0)
    local v1 = v0 >= 3.5
    return { [1]=v1, [2]=v0, [3]=7 }
end

function method1(v0, v1, v2)
    if v0 then
        local v3 = v1 >= 3.5
        if v3 then
            local v4 = spiral_wrap_signed((v2 - 7), 32)
            return v4
        else
            return 1
        end
    else
        return 2
    end
end

local v0 = 4.0
local v1, v2, v3 = (table.unpack or unpack)(method0(v0))
return method1(v1, v2, v3)
