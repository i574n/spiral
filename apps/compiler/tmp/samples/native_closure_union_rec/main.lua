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
local Uh0i0, Uh0i1, closure0, method0, method1
function Uh0i0(v0, v1) return { tag = "Uh0i0",  _1 = v0,  _2 = v1 } end
function Uh0i1() return { tag = "Uh0i1" } end

function closure0(capt)
    local v0 = (table.unpack or unpack)(capt)
    return function(dom)
        local v1 = (v0 - 1)
        return method0(v1)
    end
end

function method0(v0)
    local v1 = v0 == 0
    if v1 then
        return Uh0i1()
    else
        local v3 = closure0({ v0 })
        return Uh0i0(v0, v3)
    end
end

function method1(v0, v1)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Uh0i0" then
        local v2 = __v[1]._1
        local v3 = __v[1]._2
        local v4 = v3(nil)
        local v5 = (v1 + v2)
        return method1(v4, v5)
    elseif __v[1] ~= nil and __v[1].tag == "Uh0i1" then
        return v1
    end
end

local v0 = 10
local v1 = method0(v0)
local v2 = 0
local v3 = method1(v1, v2)
local v4 = 5
local v5 = v3
local v6 = spiral_wrap_signed(spiral_mul_mod32(v4, 2), 32)
local v7 = spiral_wrap_signed((v4 + v6), 32)
local v8 = spiral_wrap_signed((v5 + v7), 32)
return v8
