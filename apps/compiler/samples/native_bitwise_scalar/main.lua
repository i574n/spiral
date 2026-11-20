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
local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
end
local v0 = 43
local v1 = 15
local v2 = 2
local v3 = 5
local v4 = spiral_wrap_signed(bit.band(v0, v1), 32)
local v5 = spiral_wrap_signed(bit.bor(v0, v1), 32)
local v6 = spiral_wrap_signed(bit.bxor(v0, v1), 32)
local v7 = spiral_wrap_signed(bit.bnot(v0), 32)
local v8 = spiral_wrap_signed(bit.band(v7, 255), 32)
local v9 = spiral_wrap_signed(bit.lshift(1, v3), 32)
local v10 = spiral_wrap_signed(math.floor(168 / 2 ^ v2), 32)
local v11 = spiral_wrap_signed((v4 - 11), 32)
local v12 = spiral_wrap_signed((v10 + v11), 32)
local v13 = spiral_wrap_signed((v5 - 47), 32)
local v14 = spiral_wrap_signed((v12 + v13), 32)
local v15 = spiral_wrap_signed((v6 - 36), 32)
local v16 = spiral_wrap_signed((v14 + v15), 32)
local v17 = spiral_wrap_signed((v8 - 212), 32)
local v18 = spiral_wrap_signed((v16 + v17), 32)
local v19 = spiral_wrap_signed((v9 - 32), 32)
local v20 = spiral_wrap_signed((v18 + v19), 32)
return v20
