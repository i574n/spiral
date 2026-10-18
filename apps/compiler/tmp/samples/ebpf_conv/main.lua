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
local v0 = -2147483648
local v1 = 4294967295
local v2 = -1
local v3 = 0.0
local v4 = 1.9
local v5 = 2.9
local v6 = 4294967294
local v7 = 5
local v8 = 0
local v9 = (v3 - v4)
local v10 = spiral_wrap_unsigned(v0, 32)
local v11 = spiral_wrap_signed(v10, 32)
local v12 = spiral_wrap_signed(v1, 32)
local v13 = spiral_wrap_unsigned(v2, 32)
local v14 = (math.modf(v9))
local v15 = (math.modf(v5))
local v16 = (math.modf(v10 / 2))
local v17 = (math.modf(v6 / 2))
local v18 = math.fmod(v7, 3)
local v19 = spiral_wrap_unsigned(bit.bnot(v8), 32)
local v20 = spiral_wrap_unsigned(bit.rshift(v1, 31), 32)
local v21 = v0 < -1
local getv23 = function()
    if v21 then
        local v22 = v0 <= v0
        return v22
    else
        return false
    end
end
local v23 = getv23()
local getv26 = function()
    if v23 then
        local v24 = v0 > 0
        local v25 = v24 == false
        return v25
    else
        return false
    end
end
local v26 = getv26()
if v26 then
    local v27 = v10 > 1
    local getv29 = function()
        if v27 then
            local v28 = v11 == v0
            return v28
        else
            return false
        end
    end
    local v29 = getv29()
    local getv31 = function()
        if v29 then
            local v30 = v12 == v2
            return v30
        else
            return false
        end
    end
    local v31 = getv31()
    local getv33 = function()
        if v31 then
            local v32 = v13 == v1
            return v32
        else
            return false
        end
    end
    local v33 = getv33()
    if v33 then
        local v34 = v14 == v2
        local getv36 = function()
            if v34 then
                local v35 = v15 == 2
                return v35
            else
                return false
            end
        end
        local v36 = getv36()
        if v36 then
            local v37 = v16 == 1073741824
            local getv39 = function()
                if v37 then
                    local v38 = v17 == 2147483647
                    return v38
                else
                    return false
                end
            end
            local v39 = getv39()
            local getv41 = function()
                if v39 then
                    local v40 = v18 == 2
                    return v40
                else
                    return false
                end
            end
            local v41 = getv41()
            if v41 then
                local v42 = v19 == v1
                local getv44 = function()
                    if v42 then
                        local v43 = v20 == 1
                        return v43
                    else
                        return false
                    end
                end
                local v44 = getv44()
                if v44 then
                    return 0
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
