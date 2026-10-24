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
local Us0_One, Us0_Both, sum_0
function Us0_One(v0) return { tag = "Us0_One",  _1 = v0 } end
function Us0_Both(v0, v1) return { tag = "Us0_Both",  _1 = v0,  _2 = v1 } end

function sum_0(v0)
    if v0 ~= nil and v0.tag == "Us0_Both" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = spiral_wrap_signed(spiral_mul_mod32(v2, 10), 32)
        local v5 = spiral_wrap_signed((v4 + v3), 32)
        return v5
    elseif v0 ~= nil and v0.tag == "Us0_One" then
        local v1 = v0._1
        return v1
    end
end

local v0 = true
local getv3 = function()
    if v0 then
        return Us0_Both(3, 4)
    else
        return Us0_One(1)
    end
end
local v3 = getv3()
local getv6 = function()
    if v0 then
        return Us0_One(5)
    else
        return Us0_Both(1, 1)
    end
end
local v6 = getv6()
local v7 = sum_0(v3)
local v8 = v7 == 34
local getv11 = function()
    if v8 then
        local v9 = sum_0(v6)
        local v10 = v9 == 5
        return v10
    else
        return false
    end
end
local v11 = getv11()
if v11 then
    return 0
else
    return 1
end
