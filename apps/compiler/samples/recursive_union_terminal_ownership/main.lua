local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Uh0_Node, sum_1, consume_pair_0
Uh0_Leaf = (function() local shared = { tag = "Uh0_Leaf" } return function() return shared end end)()
function Uh0_Node(v0, v1, v2) return { tag = "Uh0_Node",  _1 = v0,  _2 = v1,  _3 = v2 } end

function sum_1(v0)
    if v0 ~= nil and v0.tag == "Uh0_Leaf" then
        return 0
    elseif v0 ~= nil and v0.tag == "Uh0_Node" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = v0._3
        local v4 = sum_1(v2)
        local v5 = sum_1(v3)
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = spiral_wrap_signed((v1 + v6), 32)
        return v7
    end
end

function consume_pair_0(v0, v1)
    local v2 = sum_1(v0)
    local v3 = sum_1(v1)
    local v4 = spiral_wrap_signed((v2 + v3), 32)
    return v4
end

local v0 = 1
local v1 = 2
local v2 = Uh0_Leaf()
local v3 = Uh0_Node(v1, v2, v2)
local v4 = Uh0_Node(v0, v3, v3)
local v5 = 1
local v6 = 2
local v7 = Uh0_Leaf()
local v8 = Uh0_Node(v6, v7, v7)
local v9 = Uh0_Node(v5, v8, v8)
local v10 = consume_pair_0(v4, v9)
local v11 = spiral_wrap_signed((v10 - 10), 32)
return v11
