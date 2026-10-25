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
local Us0_Hit, Us0_Flag, score_0
function Us0_Hit(v0) return { tag = "Us0_Hit",  _1 = v0 } end
function Us0_Flag(v0) return { tag = "Us0_Flag",  _1 = v0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0_Flag" then
        local v2 = __v[1]._1
        if v2 then
            return 9
        else
            return 4
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0_Hit" then
        local v1 = __v[1]._1
        return v1
    end
end

local v0 = false
local getv3 = function()
    if v0 then
        return Us0_Hit(7)
    else
        return Us0_Flag(true)
    end
end
local v3 = getv3()
local v4 = score_0(v3)
local v5 = spiral_wrap_signed((v4 - 9), 32)
return v5
