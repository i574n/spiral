local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local f_c0
function f_c0(capt)
    return function(v0)
        local v1 = spiral_wrap_signed((v0 + 1), 32)
        return v1
    end
end

local v0 = f_c0(nil)
local v1 = v0(6)
local v2 = v1 == 7
if v2 then
    return 0
else
    return 1
end
