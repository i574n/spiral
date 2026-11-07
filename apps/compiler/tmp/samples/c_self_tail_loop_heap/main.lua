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
local loop_0
function loop_0(v0, v1, v2, v3, v4)
    local v5 = v3 >= v0
    if v5 then
        return v4
    else
        local v6 = math.fmod(v3, 4)
        local v7 = (v1)[(v6)+1]
        local v8 = spiral_wrap_signed((v3 + 1), 32)
        local v9 = spiral_wrap_signed(spiral_mul_mod32(v4, 7), 32)
        local v10 = spiral_wrap_signed((v9 + v7), 32)
        local v11 = spiral_wrap_signed((v10 + v2), 32)
        local v12 = math.fmod(v11, 9973)
        return loop_0(v0, v1, v2, v8, v12)
    end
end

local v0 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(4)
v0[(0)+1] = 1
v0[(1)+1] = 2
v0[(2)+1] = 3
v0[(3)+1] = 4
local v1 = 0
local v2 = 1000000
local v3 = 0
local v4 = 0
local v5 = loop_0(v2, v0, v1, v3, v4)
local v6 = math.fmod(v5, 256)
return v6
