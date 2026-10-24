local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Mut0
Mut0 = function(l0, l1) return { __tag = "Mut0", l0 = l0, l1 = l1 } end

local v0 = { __tag = "Mut0", l0 = 1, l1 = 2 }
v0.l0 = 3
v0.l1 = 4
local v1, v2 = v0 ~= nil and v0.l0, v0 ~= nil and v0.l1
local v3 = spiral_wrap_signed((v1 + v2), 32)
return v3
