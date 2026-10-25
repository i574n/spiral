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
local Mut0
Mut0 = function(l0) return { __tag = "Mut0", l0 = l0 } end

local v0 = "deref"
local v1 = { __tag = "Mut0", l0 = v0 }
local v2 = 3
local v3 = "deref!"
v1.l0 = v3
local v4 = v1 ~= nil and v1.l0
local v5 = v2 == 3
local getv7 = function()
    if v5 then
        local v6 = spiral_wrap_signed((v2 + 1), 32)
        return v6
    else
        return 0
    end
end
local v7 = getv7()
io.write(v4, " ", string.format("%d", v7), "\n")
local v8 = spiral_wrap_signed(spiral_mul_mod32(v2, 2), 32)
local v9 = v2 > 0
local getv10 = function()
    if v9 then
        return 6
    else
        return 0
    end
end
local v10 = getv10()
local v11 = v8 == v10
if v11 then
    return 0
else
    return 1
end
