local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local Uh0_Node, score_0
Uh0_Empty = (function() local shared = { tag = "Uh0_Empty" } return function() return shared end end)()
function Uh0_Node(v0, v1, v2) return { tag = "Uh0_Node",  _1 = v0,  _2 = v1,  _3 = v2 } end

function score_0(v0)
    if v0 ~= nil and v0.tag == "Uh0_Empty" then
        return 0
    elseif v0 ~= nil and v0.tag == "Uh0_Node" then
        local v1 = v0._1
        local v2 = v0._2
        local v3 = v0._3
        local v4 = string.len(v1)
        local v5 = score_0(v2)
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = score_0(v3)
        local v8 = spiral_wrap_signed((v6 + v7), 32)
        return v8
    end
end

local v0 = "ab"
local v1 = "qwe"
local v2 = Uh0_Empty()
local v3 = Uh0_Node(v1, v2, v2)
local v4 = Uh0_Node(v0, v3, v3)
local v5 = score_0(v4)
local v6 = Uh0_Empty()
local v7 = Uh0_Node(v1, v6, v6)
local v8 = Uh0_Node(v0, v7, v7)
local v9 = score_0(v8)
local v10 = spiral_wrap_signed((v5 + v9), 32)
local v11 = spiral_wrap_signed((v10 - 16), 32)
return v11
