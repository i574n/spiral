local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = (function(n) local t = {} for i = 1, n do t[i] = "" end return t end)(2)
local v1 = "ab"
v0[(0)+1] = v1
local v2 = "cde"
v0[(1)+1] = v2
local v3 = (v0)[(0)+1]
local v4 = (v0)[(1)+1]
local v5 = string.len(v3)
local v6 = string.len(v4)
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = spiral_wrap_signed((v7 - 5), 32)
return v8
