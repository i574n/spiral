local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0
function method0(v0)
    local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
    v1[(0)+1] = 2
    v1[(1)+1] = 3
    v1[(2)+1] = 5
    v1[(3)+1] = 7
    local v2 = 2
    local v3 = (v1)[(v2)+1]
    local v4 = #(v1)
    local v5 = spiral_wrap_signed((v3 + v4), 32)
    local v6 = spiral_wrap_signed((v5 - 9), 32)
    return v6
end

local v0 = 4
return method0(v0)
