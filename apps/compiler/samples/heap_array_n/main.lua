local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Heap0
Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = 3
local v1 = 4
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
v2[(0)+1] = v0
local v3 = { __tag = "Heap0", l0 = v2, l1 = v1 }
local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
local v6 = (v4)[(0)+1]
local v7 = spiral_wrap_signed((v6 + v5), 32)
local v8 = v7 == 7
if v8 then
    return 0
else
    return 1
end
