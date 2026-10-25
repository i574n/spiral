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
local Us0_None, Us0_Held, score_0
function Us0_None() return { tag = "Us0_None" } end
function Us0_Held(v0, v1) return { tag = "Us0_Held",  _1 = v0,  _2 = v1 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Held" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = (v1)[(0)+1]
        local v4 = spiral_wrap_signed((v3 + v2), 32)
        local v5 = v4 == 7
        if v5 then
            return 0
        else
            return 1
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_None" then
        return 1
    end
end

local v0 = 3
local v1 = 4
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(1)
v2[(0)+1] = v0
local v3 = true
local getv6 = function()
    if v3 then
        return Us0_Held(v2, v1)
    else
        return Us0_None()
    end
end
local v6 = getv6()
return score_0(v6)
