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
local Uh0i0, Uh0i1, sum_0
function Uh0i0() return { tag = "Uh0i0" } end
function Uh0i1(v0, v1) return { tag = "Uh0i1",  _1 = v0,  _2 = v1 } end

function sum_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0i1" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = #(v1)
        local v4 = sum_0(v2)
        local v5 = spiral_wrap_signed((v3 + v4), 32)
        return v5
    elseif __v[1] ~= nil and __v[1].tag == "Uh0i0" then
        return 0
    end
end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v2 = Uh0i0()
local v3 = Uh0i1(v1, v2)
local v4 = Uh0i1(v1, v3)
local v5 = sum_0(v4)
local v6 = spiral_wrap_signed((v5 - 4), 32)
return v6
