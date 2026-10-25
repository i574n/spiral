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
local v0 = 5
local v1 = (function(n) local t = {} for i = 1, n do t[i] = 0 end return t end)(v0)
v1[(0)+1] = 0
v1[(1)+1] = 1
v1[(2)+1] = 4
local v2 = 3
v1[(v2)+1] = 9
local v3 = spiral_wrap_signed((v2 + 1), 32)
v1[(v3)+1] = 16
local v4 = (function(n) local t = {} for i = 1, n do t[i] = false end return t end)(3)
v4[(0)+1] = false
v4[(1)+1] = true
v4[(2)+1] = false
local v5 = (v1)[(1)+1]
local v6 = (v1)[(2)+1]
local v7 = spiral_wrap_signed((v5 + v6), 32)
local v8 = (v1)[(3)+1]
local v9 = spiral_wrap_signed((v7 + v8), 32)
local v10 = (v1)[(4)+1]
local v11 = spiral_wrap_signed((v9 + v10), 32)
local v12 = (v4)[(1)+1]
local getv15 = function()
    if v12 then
        local v13 = (v4)[(0)+1]
        if v13 then
            return 0
        else
            return 100
        end
    else
        return 0
    end
end
local v15 = getv15()
local v16 = spiral_wrap_signed((v11 + v15), 32)
local v17 = #(v1)
local v18 = spiral_wrap_signed((v16 + v17), 32)
return v18
