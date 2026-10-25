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
local loop_0
function loop_0(v0, v1, v2, v3)
    local v4 = v1 >= v0
    local getv9 = function()
        if v4 then
            return { [1]=v2, [2]=v3 }
        else
            local v5 = spiral_wrap_signed((v1 + 1), 32)
            local v6 = spiral_wrap_signed((v2 + 1), 32)
            local v7, v8 = (table.unpack or unpack)(loop_0(v0, v5, v6, v3))
            return { [1]=v7, [2]=v8 }
        end
    end
    local v9, v10 = (table.unpack or unpack)(getv9())
    return { [1]=v9, [2]=v10 }
end

local v0 = 5
local v1 = 0
local v2 = 1
local v3 = 2
local v4, v5 = (table.unpack or unpack)(loop_0(v0, v1, v2, v3))
local v6 = spiral_wrap_signed((v4 + v5), 32)
return v6
