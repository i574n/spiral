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
local leaf_c_1, slow_a_0, fast_b_2
function leaf_c_1()
    return 0
end

function slow_a_0()
    local v0 = leaf_c_1()
    return v0
end

function fast_b_2()
    return 0
end

local v0 = slow_a_0()
local v1 = fast_b_2()
local v2 = spiral_wrap_signed((v0 + v1), 32)
return v2
