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
local Heap0, Us0_None, Us0_Some, method0
Heap0 = function(l0) return { __tag = "Heap0", l0 } end

function Us0_None() return { tag = "Us0_None" } end
function Us0_Some(v0) return { tag = "Us0_Some",  _1 = v0 } end

function method0(v0, v1)
    local v2 = Us0_Some(v0)
    return { [1]=v2, [2]=v1 }
end

local v0 = 3
local v1 = 4
local v2 = { __tag = "Heap0", l0 = v1 }
local v3, v4 = (table.unpack or unpack)(method0(v0, v2))
local __v = { v3 }
if __v[1] ~= nil and __v[1].tag == "Us0_None" then
    return 1
elseif __v[1] ~= nil and __v[1].tag == "Us0_Some" then
    local v5 = __v[1]._1
    local v6 = v4 ~= nil and v4.l0
    local v7 = spiral_wrap_signed((v5 + v6), 32)
    local v8 = v7 == 7
    if v8 then
        return 0
    else
        return 1
    end
end
