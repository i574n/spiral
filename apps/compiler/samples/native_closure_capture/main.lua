local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local f_c0
function f_c0(capt)
    local v0, v1 = (table.unpack or unpack)(capt)
    return function(v2)
        local v3 = spiral_wrap_signed((v0 + v1), 32)
        local v4 = spiral_wrap_signed((v3 + v2), 32)
        return v4
    end
end

local v0 = 1
local v1 = 2
local v2 = f_c0({ v0, v1 })
return v2(39)
