local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Uh0_Cons, sum_0
Uh0_Nil = (function() local shared = { tag = "Uh0_Nil" } return function() return shared end end)()
function Uh0_Cons(v0, v1) return { tag = "Uh0_Cons",  _1 = v0,  _2 = v1 } end

function sum_0(v0)
    if v0 ~= nil and v0.tag == "Uh0_Cons" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = #(v1)
        local v4 = sum_0(v2)
        local v5 = spiral_wrap_signed((v3 + v4), 32)
        return v5
    elseif v0 ~= nil and v0.tag == "Uh0_Nil" then
        return 0
    end
end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v2 = Uh0_Nil()
local v3 = Uh0_Cons(v1, v2)
local v4 = Uh0_Cons(v1, v3)
local v5 = sum_0(v4)
local v6 = spiral_wrap_signed((v5 - 4), 32)
return v6
