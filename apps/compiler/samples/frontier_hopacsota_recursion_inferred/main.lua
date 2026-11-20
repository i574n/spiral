local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local count_0
function count_0(v0)
    local v1 = v0 <= 0
    if v1 then
        return 0
    else
        local v2 = spiral_wrap_signed((v0 - 1), 32)
        return count_0(v2)
    end
end

local v0 = 5
return count_0(v0)
