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
local v0 = 7
local v1 = 2
local v2 = 4294967295
local v3 = spiral_wrap_signed(-(v0), 32)
local v4 = -3
local v5 = -12
local v6 = -4
local v7 = -1
local v8 = (math.modf(v3 / v1))
local v9 = v8 == v4
if v9 then
    local v10 = math.fmod(v3, v1)
    local v11 = v10 == v7
    if v11 then
        local v12 = spiral_wrap_signed(math.floor(v3 / 2 ^ 1), 32)
        local v13 = v12 == v6
        if v13 then
            local v14 = spiral_wrap_signed(bit.lshift(v4, 2), 32)
            local v15 = v14 == v5
            if v15 then
                local v16 = spiral_wrap_unsigned((v2 + 1), 32)
                local v17 = v16 == 0
                if v17 then
                    local v18 = spiral_wrap_unsigned(spiral_mul_mod32(v2, v2), 32)
                    local v19 = v18 == 1
                    if v19 then
                        local v20 = spiral_wrap_unsigned(bit.rshift(v2, 28), 32)
                        local v21 = v20 == 15
                        if v21 then
                            return 0
                        else
                            return 7
                        end
                    else
                        return 6
                    end
                else
                    return 5
                end
            else
                return 4
            end
        else
            return 3
        end
    else
        return 2
    end
else
    return 1
end
