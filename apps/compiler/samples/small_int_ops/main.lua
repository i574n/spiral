local function spiral_wrap_unsigned(value, bits)
    return value % (2 ^ bits)
end
local function spiral_wrap_signed(value, bits)
    local modulus = 2 ^ bits
    value = value % modulus
    if value >= modulus / 2 then value = value - modulus end
    return value
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
local v1 = 3
local v2 = spiral_wrap_signed((v0 * v1), 8)
local v3 = -8
local v4 = 2
local v5 = (math.modf(v3 / v4))
local v6 = math.fmod(v3, v1)
local v7 = spiral_wrap_signed(-(v1), 8)
local v8 = spiral_wrap_signed(bit.lshift(v0, 1), 8)
local v9 = 200
local v10 = 3
local v11 = (math.modf(v9 / v10))
local v12 = math.fmod(v9, v10)
local v13 = 15
local v14 = spiral_wrap_unsigned(bit.band(v9, v13), 8)
local v15 = spiral_wrap_unsigned(bit.bor(v9, v13), 8)
local v16 = spiral_wrap_unsigned(bit.bxor(v9, v13), 8)
local v17 = spiral_wrap_unsigned(bit.bnot(v13), 8)
local v18 = 20000
local v19 = 7
local v20 = (math.modf(v18 / v19))
local v21 = math.fmod(v18, v19)
local v22 = spiral_wrap_signed(-(v18), 16)
local v23 = 40000
local v24 = spiral_wrap_unsigned(bit.lshift(v23, 1), 16)
local v25 = v2 == 44
local getv27 = function()
    if v25 then
        local v26 = v5 == -4
        return v26
    else
        return false
    end
end
local v27 = getv27()
local getv29 = function()
    if v27 then
        local v28 = v6 == -2
        return v28
    else
        return false
    end
end
local v29 = getv29()
local getv31 = function()
    if v29 then
        local v30 = v7 == -3
        return v30
    else
        return false
    end
end
local v31 = getv31()
local getv33 = function()
    if v31 then
        local v32 = v8 == -56
        return v32
    else
        return false
    end
end
local v33 = getv33()
local getv35 = function()
    if v33 then
        local v34 = v11 == 66
        return v34
    else
        return false
    end
end
local v35 = getv35()
local getv37 = function()
    if v35 then
        local v36 = v12 == 2
        return v36
    else
        return false
    end
end
local v37 = getv37()
local getv39 = function()
    if v37 then
        local v38 = v14 == 8
        return v38
    else
        return false
    end
end
local v39 = getv39()
local getv41 = function()
    if v39 then
        local v40 = v15 == 207
        return v40
    else
        return false
    end
end
local v41 = getv41()
local getv43 = function()
    if v41 then
        local v42 = v16 == 199
        return v42
    else
        return false
    end
end
local v43 = getv43()
local getv45 = function()
    if v43 then
        local v44 = v17 == 240
        return v44
    else
        return false
    end
end
local v45 = getv45()
local getv47 = function()
    if v45 then
        local v46 = v20 == 2857
        return v46
    else
        return false
    end
end
local v47 = getv47()
local getv49 = function()
    if v47 then
        local v48 = v21 == 1
        return v48
    else
        return false
    end
end
local v49 = getv49()
local getv51 = function()
    if v49 then
        local v50 = v22 == -20000
        return v50
    else
        return false
    end
end
local v51 = getv51()
local getv53 = function()
    if v51 then
        local v52 = v24 == 14464
        return v52
    else
        return false
    end
end
local v53 = getv53()
if v53 then
    return 0
else
    return 1
end
