local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local a_c0, b_c1, method0
function a_c0(capt)
    return function(v0)
        local v1 = spiral_wrap_signed((v0 + 2), 32)
        return v1
    end
end

function b_c1(capt)
    return function(v0)
        local v1 = spiral_wrap_signed((v0 + 3), 32)
        return v1
    end
end

function method0(v0)
    return v0(40)
end

local v0 = true
local getv3 = function()
    if v0 then
        return a_c0(nil)
    else
        return b_c1(nil)
    end
end
local v3 = getv3()
return method0(v3)
