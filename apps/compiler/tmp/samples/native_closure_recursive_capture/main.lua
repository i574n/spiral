local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local function spiral_mul_mod32(a, b)
    a = a % 4294967296
    b = b % 4294967296
    local a_low = a % 65536
    local a_high = (a - a_low) / 65536
    return (a_low * b + ((a_high * b) % 65536) * 65536) % 4294967296
end
local Uh0_Leaf, Uh0_Node, sum_0, closure0
function Uh0_Leaf() return { tag = "Uh0_Leaf" } end
function Uh0_Node(v0, v1, v2) return { tag = "Uh0_Node",  _1 = v0,  _2 = v1,  _3 = v2 } end

function sum_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_Leaf" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Uh0_Node" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = __v[1]._3
        local v4 = sum_0(v2)
        local v5 = sum_0(v3)
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = spiral_wrap_signed((v1 + v6), 32)
        return v7
    end
end

function closure0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(v1)
        local v2 = sum_0(v0)
        local v3 = spiral_wrap_signed((v2 + v1), 32)
        return v3
    end
end

local v0 = Uh0_Leaf()
local v1 = 2
local v2 = Uh0_Node(v1, v0, v0)
local v3 = closure0({ v2 })
local v4 = v3(19)
local v5 = v3(19)
local v6 = spiral_wrap_signed((v4 + v5), 32)
return v6
