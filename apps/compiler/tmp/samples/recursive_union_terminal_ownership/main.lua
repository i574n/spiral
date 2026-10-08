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
local Uh0i0, Uh0i1, sum_1, consume_pair_0
function Uh0i0() return { tag = "Uh0i0" } end
function Uh0i1(v0, v1, v2) return { tag = "Uh0i1",  _1 = v0,  _2 = v1,  _3 = v2 } end

function sum_1(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0i0" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Uh0i1" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = __v[1]._3
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
local v2 = Uh0i0()
local v3 = Uh0i1(v1, v2, v2)
local v4 = Uh0i1(v0, v3, v3)
local v5 = 1
local v6 = 2
local v7 = Uh0i0()
local v8 = Uh0i1(v6, v7, v7)
local v9 = Uh0i1(v5, v8, v8)
local v10 = consume_pair_0(v4, v9)
local v11 = spiral_wrap_signed((v10 - 10), 32)
return v11
