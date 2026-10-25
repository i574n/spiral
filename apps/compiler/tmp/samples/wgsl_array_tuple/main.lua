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
local v0 = 3
local v1 = {}
local v2 = 4
v1[(0)+1] = { [1]=v2, [2]=true }
v1[(1)+1] = { [1]=7, [2]=false }
v1[(2)+1] = { [1]=9, [2]=true }
local v3, v4 = (table.unpack or unpack)((v1)[(0)+1])
local v5, v6 = (table.unpack or unpack)((v1)[(1)+1])
local v7 = 2
local v8, v9 = (table.unpack or unpack)((v1)[(v7)+1])
local getv10 = function()
    if v4 then
        return 1
    else
        return 0
    end
end
local v10 = getv10()
local getv11 = function()
    if v6 then
        return 10
    else
        return 0
    end
end
local v11 = getv11()
local getv12 = function()
    if v9 then
        return 100
    else
        return 0
    end
end
local v12 = getv12()
local v13 = spiral_wrap_signed((v3 + v5), 32)
local v14 = spiral_wrap_signed((v13 + v8), 32)
local v15 = spiral_wrap_signed((v14 + v10), 32)
local v16 = spiral_wrap_signed((v15 + v11), 32)
local v17 = spiral_wrap_signed((v16 + v12), 32)
return v17
