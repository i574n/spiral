local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Uh0_Node, sum_0
Uh0_Leaf = (function() local shared = { tag = "Uh0_Leaf" } return function() return shared end end)()
Uh0_Marker = (function() local shared = { tag = "Uh0_Marker" } return function() return shared end end)()
function Uh0_Node(v0, v1, v2) return { tag = "Uh0_Node",  _1 = v0,  _2 = v1,  _3 = v2 } end

function sum_0(v0)
    if v0 ~= nil and v0.tag == "Uh0_Leaf" then
        return 0
    elseif v0 ~= nil and v0.tag == "Uh0_Marker" then
        return 0
    elseif v0 ~= nil and v0.tag == "Uh0_Node" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = v0._3
        local v4 = sum_0(v2)
        local v5 = sum_0(v3)
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = spiral_wrap_signed((v1 + v6), 32)
        return v7
    end
end

local v0 = 1
local v1 = 2
local v2 = Uh0_Leaf()
local v3 = Uh0_Marker()
local v4 = Uh0_Node(v1, v2, v3)
local v5 = Uh0_Node(v0, v4, v4)
local v6 = sum_0(v5)
local v7 = spiral_wrap_signed((v6 - 5), 32)
return v7
