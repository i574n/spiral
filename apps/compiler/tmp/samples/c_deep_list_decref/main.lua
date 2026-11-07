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
local Uh0_Link, build_0, sum_1
function Uh0_Link(v0, v1) return { tag = "Uh0_Link",  _1 = v0,  _2 = v1 } end
Uh0_End = (function() local shared = { tag = "Uh0_End" } return function() return shared end end)()

function build_0(v0, v1)
    local v2 = v0 == 0
    if v2 then
        return v1
    else
        local v3 = spiral_wrap_signed((v0 - 1), 32)
        local v4 = Uh0_Link(v0, v1)
        return build_0(v3, v4)
    end
end

function sum_1(v0, v1)
    if v0 ~= nil and v0.tag == "Uh0_End" then
        return v1
    elseif v0 ~= nil and v0.tag == "Uh0_Link" then
        local v2 = v0._1
        local v3 = v0._2
        local v4 = spiral_wrap_signed(spiral_mul_mod32(v1, 31), 32)
        local v5 = spiral_wrap_signed((v4 + v2), 32)
        local v6 = math.fmod(v5, 9973)
        return sum_1(v3, v6)
    end
end

local v0 = 1000000
local v1 = Uh0_End()
local v2 = build_0(v0, v1)
local v3 = 0
local v4 = sum_1(v2, v3)
local v5 = math.fmod(v4, 256)
return v5
