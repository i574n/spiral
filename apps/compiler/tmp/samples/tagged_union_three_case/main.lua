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
local Us0i0, Us0i1, Us0i2, method0
function Us0i0() return { tag = "Us0i0" } end
function Us0i1(v0) return { tag = "Us0i1",  _1 = v0 } end
function Us0i2(v0) return { tag = "Us0i2",  _1 = v0 } end

function method0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0i2" then
        local v2 = __v[1]._1
        if v2 then
            return 11
        else
            return 5
        end
    elseif __v[1] ~= nil and __v[1].tag == "Us0i1" then
        local v1 = __v[1]._1
        return v1
    elseif __v[1] ~= nil and __v[1].tag == "Us0i0" then
        return 3
    end
end

local v0 = 2
local v1 = v0 == 0
local getv7 = function()
    if v1 then
        return Us0i0()
    else
        local v3 = v0 == 1
        if v3 then
            return Us0i1(7)
        else
            return Us0i2(true)
        end
    end
end
local v7 = getv7()
local v8 = method0(v7)
local v9 = spiral_wrap_signed((v8 - 11), 32)
return v9
