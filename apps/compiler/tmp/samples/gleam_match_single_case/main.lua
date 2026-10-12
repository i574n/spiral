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
local Us0_Step, walk_0
function Us0_Step(v0, v1, v2) return { tag = "Us0_Step",  _1 = v0,  _2 = v1,  _3 = v2 } end

function walk_0(v0)
    local v1 = v0 > 2
    local getv6 = function()
        if v1 then
            local v2 = spiral_wrap_signed((v0 + 1), 32)
            local v3 = spiral_wrap_signed((v0 + 2), 32)
            return Us0_Step(v0, v2, v3)
        else
            return Us0_Step(0, 1, 2)
        end
    end
    local v6 = getv6()
    local __v = { v6 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Step" then
        local v7 = __v[1]._1
        local v8 = __v[1]._2
        local v9 = __v[1]._3
        local v10 = spiral_wrap_signed(spiral_mul_mod32(v8, v9), 32)
        local v11 = spiral_wrap_signed((v7 + v10), 32)
        return v11
    end
end

local v0 = 5
local v1 = walk_0(v0)
local v2 = spiral_wrap_signed((v0 - 4), 32)
local v3 = walk_0(v2)
local v4 = spiral_wrap_signed((v1 + v3), 32)
return v4
