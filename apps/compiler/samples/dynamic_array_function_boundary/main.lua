local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0
function method0(v0, v1)
    local v2 = (v0)[(v1)+1]
    local v3 = #(v0)
    local v4 = spiral_wrap_signed((v2 + v3), 32)
    local v5 = spiral_wrap_signed((v4 - 10), 32)
    return v5
end

local v0 = 3
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 2
v1[(1)+1] = 5
v1[(2)+1] = 7
local v2 = 2
return method0(v1, v2)
