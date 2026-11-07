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
local v2 = { __tag = "Heap0", l0 = v0, l1 = v1 }
local v3, v4 = v2 ~= nil and v2.l0, v2 ~= nil and v2.l1
local v5 = spiral_wrap_signed((v3 + v4), 32)
local v6 = v5 == 7
if v6 then
    return 0
else
    return 1
end
