local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = 4
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 10
v1[(1)+1] = 20
v1[(2)+1] = 30
local v2 = (v1)[(0)+1]
local v3 = (v1)[(1)+1]
local v4 = spiral_wrap_signed((v2 + v3), 32)
v1[(3)+1] = v4
local v5 = (v1)[(2)+1]
local v6 = (v1)[(3)+1]
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = #(v1)
local v9 = v8 == v0
local getv11 = function()
    if v9 then
        local v10 = v7 == 60
        return v10
    else
        return false
    end
end
local v11 = getv11()
if v11 then
    return 0
else
    return 1
end
