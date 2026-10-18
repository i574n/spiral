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
local v0 = 100
local v1 = spiral_wrap_signed((v0 + v0), 8)
local v2 = 200
local v3 = 100
local v4 = spiral_wrap_unsigned((v2 + v3), 8)
local v5 = -8
local v6 = spiral_wrap_signed(math.floor(v5 / 2 ^ 1), 8)
local v7 = spiral_wrap_unsigned(bit.rshift(v2, 1), 8)
local v8 = 20000
local v9 = spiral_wrap_signed((v8 + v8), 16)
local v10 = 40000
local v11 = spiral_wrap_unsigned((v10 + v10), 16)
local v12 = 7
local v13 = spiral_wrap_signed(v12, 8)
local v14 = 9
local v15 = v14
local v16 = v1 == -56
local getv18 = function()
    if v16 then
        local v17 = v4 == 44
        return v17
    else
        return false
    end
end
local v18 = getv18()
local getv20 = function()
    if v18 then
        local v19 = v6 == -4
        return v19
    else
        return false
    end
end
local v20 = getv20()
local getv22 = function()
    if v20 then
        local v21 = v7 == 100
        return v21
    else
        return false
    end
end
local v22 = getv22()
local getv24 = function()
    if v22 then
        local v23 = v9 == -25536
        return v23
    else
        return false
    end
end
local v24 = getv24()
local getv26 = function()
    if v24 then
        local v25 = v11 == 14464
        return v25
    else
        return false
    end
end
local v26 = getv26()
local getv28 = function()
    if v26 then
        local v27 = v13 == 7
        return v27
    else
        return false
    end
end
local v28 = getv28()
local getv30 = function()
    if v28 then
        local v29 = v15 == 9
        return v29
    else
        return false
    end
end
local v30 = getv30()
if v30 then
    return 0
else
    return 1
end
