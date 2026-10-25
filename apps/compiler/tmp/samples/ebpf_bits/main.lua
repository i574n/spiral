local function spiral_bit_combine(a, b, keep)
    a = a % 4294967296
    b = b % 4294967296
    local result, place = 0, 1
    for _ = 1, 32 do
        local a_bit, b_bit = a % 2, b % 2
        if keep(a_bit, b_bit) then result = result + place end
        a = (a - a_bit) / 2
        b = (b - b_bit) / 2
        place = place * 2
    end
    return result
end
local bit = bit32 or bit or {
    band = function(a, b) return spiral_bit_combine(a, b, function(x, y) return x == 1 and y == 1 end) end,
    bor = function(a, b) return spiral_bit_combine(a, b, function(x, y) return x == 1 or y == 1 end) end,
    bxor = function(a, b) return spiral_bit_combine(a, b, function(x, y) return x ~= y end) end,
    bnot = function(a) return 4294967295 - a % 4294967296 end,
    lshift = function(a, n) return (a % 4294967296) * 2 ^ n % 4294967296 end,
    rshift = function(a, n) return math.floor((a % 4294967296) / 2 ^ n) end,
}
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
local v0 = 4294967295
local v1 = 15
local v2 = spiral_wrap_unsigned(bit.band(v0, v1), 32)
local v3 = spiral_wrap_unsigned(bit.bor(v0, v1), 32)
local v4 = spiral_wrap_unsigned(bit.bxor(v0, v1), 32)
local v5 = spiral_wrap_unsigned(bit.bnot(v1), 32)
local v6 = v2 == 15
local getv8 = function()
    if v6 then
        local v7 = v3 == v0
        return v7
    else
        return false
    end
end
local v8 = getv8()
local getv10 = function()
    if v8 then
        local v9 = v4 == v5
        return v9
    else
        return false
    end
end
local v10 = getv10()
local getv12 = function()
    if v10 then
        local v11 = v5 == 4294967280
        return v11
    else
        return false
    end
end
local v12 = getv12()
if v12 then
    return 0
else
    return 1
end
