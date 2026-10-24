local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local f_c0
function f_c0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = string.len(v0)
        local v3 = spiral_wrap_signed((v2 + v1), 32)
        return v3
    end
end

local v0 = "abc"
local v1 = f_c0({ v0 })
return v1(39)
