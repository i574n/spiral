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
local Uh0_Nil, Uh0_Cons, sum_0
function Uh0_Nil() return { tag = "Uh0_Nil" } end
function Uh0_Cons(v0, v1) return { tag = "Uh0_Cons",  _1 = v0,  _2 = v1 } end

function sum_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0_Cons" then
        local v1 = __v[1]._1
        local v2 = __v[1]._2
        local v3 = sum_0(v2)
        local v4 = spiral_wrap_signed((v1 + v3), 32)
        return v4
    elseif __v[1] ~= nil and __v[1].tag == "Uh0_Nil" then
        return 0
    end
end

local v0 = 1
local v1 = 2
local v2 = 3
local v3 = Uh0_Nil()
local v4 = Uh0_Cons(v2, v3)
local v5 = Uh0_Cons(v1, v4)
local v6 = Uh0_Cons(v0, v5)
local v7 = sum_0(v6)
local v8 = spiral_wrap_signed((v7 - 6), 32)
return v8
