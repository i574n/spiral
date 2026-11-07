local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local method0, method1, method2
function method0(v0)
    local v1 = 1
    local v2 = 9
    v0[(v1)+1] = v2
    return nil
end

function method1(v0)
    local v1 = 0
    local v2 = (v0)[(v1)+1]
    return v2
end

function method2(v0)
    local v1 = 1
    local v2 = (v0)[(v1)+1]
    return v2
end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 1
v1[(1)+1] = 2
method0(v1)
local v2 = method1(v1)
local v3 = method2(v1)
local v4 = spiral_wrap_signed((v2 + v3), 32)
local v5 = spiral_wrap_signed((v4 - 10), 32)
return v5
