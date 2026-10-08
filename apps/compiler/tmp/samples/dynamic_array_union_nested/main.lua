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
local Us0i0, Us0i1, score_0
function Us0i0() return { tag = "Us0i0" } end
function Us0i1(v0) return { tag = "Us0i1",  _1 = v0 } end

function score_0(v0)
    local __v = { v0 }
    if __v[1] ~= nil and __v[1].tag == "Us0i0" then
        return 0
    elseif __v[1] ~= nil and __v[1].tag == "Us0i1" then
        local v1 = __v[1]._1
        local v2 = (v1)[(0)+1]
        local v3 = (v1)[(1)+1]
        local v4 = #(v1)
        local v5 = (v2)[(0)+1]
        local v6 = spiral_wrap_signed((v4 + v5), 32)
        local v7 = (v2)[(1)+1]
        local v8 = spiral_wrap_signed((v6 + v7), 32)
        local v9 = (v3)[(0)+1]
        local v10 = spiral_wrap_signed((v8 + v9), 32)
        local v11 = (v3)[(1)+1]
        local v12 = spiral_wrap_signed((v10 + v11), 32)
        return v12
    end
end

local v0 = 2
local v1 = {}
local v2 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
local v3 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v2[(0)+1] = 3
v2[(1)+1] = 4
v3[(0)+1] = 5
v3[(1)+1] = 6
v1[(0)+1] = v2
v1[(1)+1] = v3
local v4 = Us0i1(v1)
local v5 = score_0(v4)
local v6 = spiral_wrap_signed((v5 - 20), 32)
return v6
