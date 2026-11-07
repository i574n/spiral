local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Us0_None, Us0_Some, Heap0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

Heap0 = function(l0, l1) return { __tag = "Heap0", l0, l1 } end

local v0 = 3
local v1 = 4
local v2 = Us0_Some(v0)
local v3 = { __tag = "Heap0", l0 = v2, l1 = v1 }
local v4, v5 = v3 ~= nil and v3.l0, v3 ~= nil and v3.l1
if v4 ~= nil and v4.tag == "Us0_None" then
    return 1
elseif v4 ~= nil and v4.tag == "Us0_Some" then
    local v6 = v4._1
    local v7 = spiral_wrap_signed((v6 + v5), 32)
    local v8 = v7 == 7
    if v8 then
        return 0
    else
        return 1
    end
end
