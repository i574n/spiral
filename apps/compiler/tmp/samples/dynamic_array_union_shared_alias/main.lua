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
local Us0i0, Us0i1, method0, method1
function Us0i0() return { tag = "Us0i0" } end
function Us0i1(v0) return { tag = "Us0i1",  _1 = v0 } end

function method0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0i0" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Us0i1" then
        local v1 = __v[1]._1
        local v2 = (v1)[(0)+1]
        local v3 = spiral_wrap_signed((v2 + 1), 32)
        v1[(0)+1] = v3
        return 0
    end
end

function method1(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0i0" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Us0i1" then
        local v1 = __v[1]._1
        local v2 = #(v1)
        local v3 = (v1)[(0)+1]
        local v4 = spiral_wrap_signed((v2 + v3), 32)
        local v5 = (v1)[(1)+1]
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        return v6
    end
end

local v0 = 2
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 4
v1[(1)+1] = 5
local v2 = Us0i1(v1)
local v3 = method0(v2)
local v4 = Us0i1(v1)
local v5 = method1(v4)
local v6 = spiral_wrap_signed((v5 + v3), 32)
local v7 = spiral_wrap_signed((v6 - 12), 32)
return v7
