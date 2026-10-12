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
local Uh0_Empty, Uh0_Box, method2, method1, method0
function Uh0_Empty() return { tag = "Uh0_Empty" } end
function Uh0_Box(v0, v1) return { tag = "Uh0_Box",  _1 = v0,  _2 = v1 } end

function method2(v0)
    local v1 = spiral_wrap_signed((v0 - 1), 32)
    local v2 = v1 == 0
    if v2 then
        local v3 = Uh0_Empty()
        return Uh0_Box(7, v3)
    else
        return method1(v1)
    end
end

function method1(v0)
    local v1 = spiral_wrap_signed((v0 - 1), 32)
    local v2 = v1 == 0
    if v2 then
        local v3 = Uh0_Empty()
        return Uh0_Box(11, v3)
    else
        return method2(v1)
    end
end

function method0()
    local v0 = 1000000
    local v1 = v0 == 0
    if v1 then
        local v2 = Uh0_Empty()
        return Uh0_Box(7, v2)
    else
        return method1(v0)
    end
end

local v0 = method0()
local __v = { v0 }
if __v[1] ~= nil and __v[1].tag == "Uh0_Box" then
    local v1 = __v[1]._1
    local v2 = __v[1]._2
    local v3 = v1 == 7
    if v3 then
        return 0
    else
        return 3
    end
elseif __v[1] ~= nil and __v[1].tag == "Uh0_Empty" then
    return 1
end
